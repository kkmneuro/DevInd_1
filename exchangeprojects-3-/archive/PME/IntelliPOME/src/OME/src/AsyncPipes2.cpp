////////////////////////////////////////////////////////////////////////////////
// H. Seldon 02.06.11
// http://veridium.net
// hseldon@veridium.net
//
// This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.


#include "stdafx.h"
#include "AsyncPipes2.h"

#include "Buffer.h"

#define MAX_WAIT			20000
#define MAX_WAIT_CONNECT	500
#define PENDING_CONNECTS	50

typedef std::pair<CAsyncPipesServer2*, SOverlapped*> PAIRINST;


CAsyncPipesServer2::CAsyncPipesServer2(void)
{
	m_nPendingConnects	= 0;
	m_hIOCP				= NULL;

	m_hThMain		= NULL;
	m_hThConnect	= NULL;
}

CAsyncPipesServer2::~CAsyncPipesServer2(void)
{
	Destroy();
}

void CAsyncPipesServer2::CleanUp()
{
	CXCritSec::CLocker lock(m_csOlp);

	unsigned uiCount = m_vecOverlapped.size();
	for (unsigned i = 0; i < uiCount; ++i)
	{
		CancelIo(m_vecOverlapped.at(i)->hPipe);
		CloseHandle(m_vecOverlapped.at(i)->hPipe);

		delete m_vecOverlapped.at(i);
	}

	m_vecOverlapped.clear();

	m_nPendingConnects = 0;
}

DWORD WINAPI CAsyncPipesServer2::ThInst(LPVOID lpvd)
{
	PAIRINST *p = (PAIRINST*) lpvd;
	p->first->OnRead(p->second);
	delete p;


	return 0;
}

void CAsyncPipesServer2::OnRead(SOverlapped* pOlp)
{
	CBuffer myBuffAns;
	DWORD dwAns = myBuffAns.GetSize();

	m_pCallback(pOlp->pBuff->GetPTR(),
				pOlp->pBuff->GetCurrLen(),
				myBuffAns.GetPTR(),
				&dwAns);


	myBuffAns.SetCurrLen(dwAns);
	pOlp->pBuff->Assign(myBuffAns);


	DWORD dwWritten = 0;

	if (WriteFile(pOlp->hPipe,
			pOlp->pBuff->GetPTR(),
			pOlp->pBuff->GetCurrLen(),
			&dwWritten,
			&pOlp->ol))
	{
		PostQueuedCompletionStatus(m_hIOCP,
						dwWritten,
						(ULONG_PTR)pOlp->hPipe,
						&pOlp->ol);
	}
	else if (GetLastError() != ERROR_IO_PENDING)
	{
		//probably pipe is being closed, or pipe not connected
		RemoveOverlapped(pOlp, true);
	}


}

DWORD WINAPI CAsyncPipesServer2::ThConnect(LPVOID lpvd)
{
	//wait for multiple objects: shutdown/more connects
	//see CServerSocks::Accept...if ConnectNamedPipe completed immediately PostQueuedStatus ...

	CAsyncPipesServer2* p = (CAsyncPipesServer2*) lpvd;


	HANDLE arrHandles[2];

	arrHandles[0] = p->m_eventShutdown.GetEvent();
	arrHandles[1] = p->m_eventMoreConnects.GetEvent();

	DWORD	dwWaitRes;
	HANDLE	hPipe;

	SOverlapped* pOlp;


	do
	{
		{
			CXCritSec::CLocker lock(p->m_csOlp);

			while (p->m_nPendingConnects < PENDING_CONNECTS)
			{
				if ((hPipe = CreateNamedPipe(
					p->m_strPipeName.c_str(),
					PIPE_ACCESS_DUPLEX | FILE_FLAG_OVERLAPPED,
					PIPE_TYPE_MESSAGE |
					PIPE_READMODE_MESSAGE,
					PIPE_UNLIMITED_INSTANCES,
					MAX_BUFF_SIZE,
					MAX_BUFF_SIZE,
					0,
					NULL)) == INVALID_HANDLE_VALUE)
				{	
					_ASSERT(NULL);
					break;
				}

				
				///////////////////////////////////////////////////////////

				// add the new pipe instance to the completion port
			
				CreateIoCompletionPort(hPipe, p->m_hIOCP, (ULONG_PTR) hPipe, 0);


				///////////////////////////////////////////////////////////

				if (!(pOlp = new SOverlapped))
				{
					CloseHandle(hPipe);
					break;
				}


				pOlp->hPipe		= hPipe;
				pOlp->nOpCode	= OP_CONNECT;

				if (!ConnectNamedPipe(hPipe, &pOlp->ol))
				{
					DWORD dwLastErr = GetLastError();
					if (dwLastErr == ERROR_PIPE_CONNECTED)
					{
						p->m_vecOverlapped.push_back(pOlp);
						PostQueuedCompletionStatus(p->m_hIOCP, 0, (ULONG_PTR)hPipe, &pOlp->ol);
						continue;
					}
					else if (dwLastErr == ERROR_NO_DATA) //connected and disconnected before ConnectNamedPipe called
					{
						delete pOlp;

						DisconnectNamedPipe(hPipe);
						CloseHandle(hPipe);

						continue;
					}
					else if (dwLastErr != ERROR_PIPE_LISTENING
						&& dwLastErr != ERROR_IO_PENDING)
					{
						_ASSERT(NULL);

						delete pOlp;
						CloseHandle(hPipe);

						continue;
					}
				} // ConnectNamedPipe


				//////////////////////////////////////////////////////////////

				p->m_vecOverlapped.push_back(pOlp);
				++p->m_nPendingConnects;

			} // while

		} // CritSec


		dwWaitRes = WaitForMultipleObjects(2, arrHandles, FALSE, INFINITE);


		p->m_eventMoreConnects.Reset();

	} 
	while (dwWaitRes != WAIT_OBJECT_0);


	return 0;
}


DWORD CAsyncPipesServer2::ThMain(LPVOID lpvd)
{
	CAsyncPipesServer2* p = (CAsyncPipesServer2*) lpvd;


	/////////////////////////////////////////////////////////////////////

	if (p->m_hIOCP == NULL)
	{
		//keep m_hPipe open till Destroy...pipe will be destroyed
		//when all instances are closed..must always keep one open
		//(e.g.: all pipes connected before new one created)

		if ((p->m_hIOCP = CreateIoCompletionPort(p->m_hPipe, NULL, 0, 0)) == NULL)
		{
			_ASSERT(NULL);
			return 0;
		}

		//an open pipe without a read on it will cause first request from a client to never be fullfilled
		CloseHandle(p->m_hPipe);
	}


	////////////////////////////////////////////////////////////////////////////

	DWORD dwThreadID;
	p->m_hThConnect = CreateThread(NULL,
								0,
								(LPTHREAD_START_ROUTINE)ThConnect,
								p,
								NULL,
								&dwThreadID);


	//////////////////////////////////////////////////////////////////////////////////////

	ULONG_PTR*		pPerHandleKey = 0;
	OVERLAPPED*		pOverlap;
	SOverlapped*	pOverlapPlus;
	DWORD           dwBytesXfered = 0;
	bool			bRet;


    while (true)
    {

         // continually loop to service io completion packets
		bRet = GetQueuedCompletionStatus(p->m_hIOCP,
							&dwBytesXfered,
							(PULONG_PTR)&pPerHandleKey,
							&pOverlap,
							INFINITE) == TRUE;


        if (/*bRet == 0 || */pPerHandleKey == NULL || pOverlap == NULL)
        {
            //shutting down
            break;
        }


        pOverlapPlus = CONTAINING_RECORD(pOverlap, SOverlapped, ol);


		switch (pOverlapPlus->nOpCode)
		{
		case OP_CONNECT:
			{
				////////////////////////////////////////////////////////////

				{
					CXCritSec::CLocker (p->m_csOlp);
					--p->m_nPendingConnects;
				}

				p->m_eventMoreConnects.Set();


				///////////////////////////////////////////////////////////

				pOverlapPlus->nOpCode = OP_READ;
				if (!(pOverlapPlus->pBuff = new CBuffer))
				{
					_ASSERT(NULL);
					p->RemoveOverlapped(pOverlapPlus);
					break;
				}

				DWORD dwBytesRead = 0;

				if (!ReadFile(pOverlapPlus->hPipe,
						pOverlapPlus->pBuff->GetPTR(),
						pOverlapPlus->pBuff->GetSize(),
						&dwBytesRead,
						&pOverlapPlus->ol))
				{
					DWORD dwErr;
					if ((dwErr = GetLastError()) != ERROR_IO_PENDING
						&& dwErr != ERROR_PIPE_LISTENING)
					{
						_ASSERT(NULL);
						p->RemoveOverlapped(pOverlapPlus);
						break;
					}

				}
				else //completed immediately
				{
					pOverlapPlus->pBuff->SetCurrLen(dwBytesRead);

					PostQueuedCompletionStatus(p->m_hIOCP,
						dwBytesRead,
						(ULONG_PTR)pOverlapPlus->hPipe,
						&pOverlapPlus->ol);
				}

			}
			break;

		case OP_READ:
			{
				//read complete

				pOverlapPlus->nOpCode = OP_WRITE;
				++pOverlapPlus->nRefCount;

				PAIRINST *param = new PAIRINST(p, pOverlapPlus);

				HANDLE hThread;
				DWORD dwThId = 0;
				if ((hThread = CreateThread(NULL,
							0,
							(LPTHREAD_START_ROUTINE) ThInst,
							param,
							0,
							&dwThId)))
				{
					CloseHandle(hThread);
				}

			}
			break;

		case OP_WRITE:
			{
				//write complete
				//set op and wait for client to read data we have written and disconnect

				//pOverlapPlus->nOpCode = OP_DISCONNECT;

			}
			break;

		case OP_DISCONNECT:
			{
				DisconnectNamedPipe(pOverlapPlus->hPipe);
				p->RemoveOverlapped(pOverlapPlus, true);
			}
			break;
		}


	} //while


	return 0;
}


BOOL CAsyncPipesServer2::Create(LPCTSTR pIpc, PASYNCPIPES_CALLBACK pCallback)
{
	m_pCallback = pCallback;


	//m_strPipeName = _T("\\\\.\\pipe\\");
	m_strPipeName = ("\\\\.\\pipe\\MT5");
	//m_strPipeName += pIpc;


	if ((m_hPipe = CreateNamedPipe(
			m_strPipeName.c_str(),
			PIPE_ACCESS_DUPLEX | FILE_FLAG_OVERLAPPED,
			PIPE_TYPE_MESSAGE |
			PIPE_READMODE_MESSAGE,
			PIPE_UNLIMITED_INSTANCES,
			MAX_BUFF_SIZE,
			MAX_BUFF_SIZE,
			0,
			NULL)) == INVALID_HANDLE_VALUE)
	{
		_ASSERT(NULL);
		return FALSE;
	}


	DWORD dwThMainId = 0;
	if ((m_hThMain = CreateThread(NULL,
							0,
							(LPTHREAD_START_ROUTINE) ThMain,
							this,
							0,
							&dwThMainId)) == NULL)
	{
		return FALSE;
	}


	return TRUE;
}


void CAsyncPipesServer2::RemoveOverlapped(SOverlapped *pOlp, bool bDecreaseRef)
{
	CXCritSec::CLocker lock(m_csOlp);

	if(bDecreaseRef)
		--pOlp->nRefCount;
	if (pOlp->nRefCount > 1)
		return;

	unsigned uiCount = m_vecOverlapped.size();
	for (unsigned i = 0; i < uiCount; ++i)
	{
		if (pOlp == m_vecOverlapped.at(i))
		{
			DisconnectNamedPipe(pOlp->hPipe);
			CloseHandle(pOlp->hPipe);
			delete pOlp;

			m_vecOverlapped.erase(m_vecOverlapped.begin() + i);

			break;
		}
	}
}


BOOL CAsyncPipesServer2::Destroy()
{
	if (m_hIOCP == NULL)
		return FALSE;


	m_eventShutdown.Set();
	
	WaitForSingleObject(m_hThConnect, INFINITE);
	CloseHandle(m_hThConnect);


	PostQueuedCompletionStatus(m_hIOCP, 0, 0, NULL);

	WaitForSingleObject(m_hThMain, INFINITE);
	CloseHandle(m_hThMain);


	//CloseHandle(m_hPipe);
	CloseHandle(m_hIOCP);


	CleanUp();


	return TRUE;
}

CAsyncPipesClient2::CAsyncPipesClient2()
{
}

CAsyncPipesClient2::~CAsyncPipesClient2()
{
}

HANDLE hPipe = 0;

BOOL CAsyncPipesClient2::SendMsg(LPCTSTR  pIpc,
		PVOID   pMessage,
		DWORD   dwMessageLen,
		PVOID   pAns,
		DWORD   dwAnsLen,
		DWORD   dwAnsTimeOut)
{
	std::string strPipeName = "\\\\.\\pipe\\MT5300039439";
	//std::string strPipeName = "\\\\.\\pipe\\MT5153373";

	//strPipeName += pIpc;

	//hPipe = 0;
	


_BEGIN:

	//if (hPipe == 0)
	{
		if ((hPipe = CreateFile(strPipeName.c_str(),
					GENERIC_READ |
					GENERIC_WRITE,
					FILE_SHARE_READ | FILE_SHARE_WRITE,
					NULL,
					OPEN_EXISTING,
					FILE_FLAG_OVERLAPPED,
					NULL)) == INVALID_HANDLE_VALUE)
		{
			if (GetLastError() == ERROR_PIPE_BUSY)
			{
				if (WaitNamedPipe(strPipeName.c_str(), MAX_WAIT_CONNECT))
					goto _BEGIN;
			}
			else
				return FALSE;

			return FALSE;
		}
		
		//_ASSERT(NULL);

		
	}


	// Pipe connected; change to message-read mode. 
	DWORD dwMode = PIPE_READMODE_MESSAGE; 
	if (!SetNamedPipeHandleState( 
					hPipe,    // pipe handle 
					&dwMode,  // new pipe mode 
					NULL,
					NULL))
	{
		DWORD dwError = GetLastError();
		//_ASSERT(NULL);
		CloseHandle(hPipe);
		return FALSE;
	}


	OVERLAPPED olp;
	CXEvent eventTransact;

	memset(&olp, 0, sizeof(olp));
	olp.hEvent = eventTransact.GetEvent();

	DWORD dwBytesRead = 0;
	if (!TransactNamedPipe( 
					hPipe,
					pMessage,
					dwMessageLen,
					pAns,
					dwAnsLen,
					&dwBytesRead,
					&olp))
	{
		DWORD dwLastErr = GetLastError();
		if (dwLastErr == ERROR_MORE_DATA) 
		{
			//ReadFile..
		}
		else if (dwLastErr == ERROR_IO_PENDING)
		{
			if (pAns)
				eventTransact.Wait(dwAnsTimeOut);
		}
		else
		{
			CloseHandle(hPipe);
			return FALSE;
		}
	}


//	CloseHandle(hPipe); 


	return TRUE;
}
