/////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials			Desc
//	16 Dec 2013		BR					Ticket Tradingapplication/92. Modified function Callback to accomodate
//										MAX_SYMBOLS in QuotesStream only.
//////////////////////////////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "pipeserver.h"

#include "Buffer.h"
#include "BL_MDE.h"
#include "math.h"

#include "xlogger.h"
#include "UtilitiesAPI.h"

#include <float.h>

#define MAX_WAIT			20000
#define MAX_WAIT_CONNECT	500
#define PENDING_CONNECTS	50

typedef std::pair<CPipeServer*, SOverlapped*> PAIRINST;

VOID WINAPI CPipeServer::Callback(
  LPCVOID	pMessage,
  DWORD		dwMessageLen,
  LPVOID	pAns,
  DWORD*	pdwAnsLen,
  BL_MDE*	pMDE,
  CPipeServer *pServer)
{
	EnterCriticalSection(&pServer->m_csPipe);

	MQLTick tick;
	memcpy(&tick, pMessage, sizeof(MQLTick));

	int xx = sizeof(MQLTick);

	QuotesStream  qstream;
	qstream.Header.StructSize = sizeof(QuotesStream);
	qstream.Header.MessageType = QUOTES_STREAM;
	qstream.NoOfSymbols = 0;
	char cProductType;

	cProductType = tick.productType;
	double markup = 0;
	int nSymbolCount = 0;

	if (tick.LTP == 0)
	{
		tick.LTP = tick.Bid;
	}

	MQLTick dest;
	memcpy(&dest, &tick, sizeof(tick));
	

	pMDE->ManipulateMQLTick(tick, dest);

	COleDateTime oleDate = COleDateTime::GetCurrentTime();

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Callback Tick Values. Symbol=%s,Bid=%lf, Ask=%lf, LTP=%lf , Bid Size = %lf, Ask Size = %lf, LAST Size=%lf OHLC = %lf:%lf:%lf:%lf Time=%d:%d:%d", 
									tick.contract, 
									tick.Bid, 
									tick.Ask, 
									tick.LTP, 
									tick.dBidSize,
									tick.dAskSize,
									tick.dLastSize,
									tick.dOpen,
									tick.dHigh,
									tick.dLow,
									tick.dClose,
									oleDate.GetHour(), 
									oleDate.GetMinute(), 
									oleDate.GetSecond());

	double valMult = pMDE->GetConversionFormula(dest.contract);

	if (dest.Ask != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_ASK, qstream, valMult, oleDate, 0, "ECX", dest.Ask);
	if (dest.Bid != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_BID, qstream, valMult, oleDate, 0, "ECX", dest.Bid);
	if (dest.dClose != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_CLOSE, qstream, valMult, oleDate, 0, "ECX", dest.dClose);
	if (dest.dHigh != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_HIGH, qstream, valMult, oleDate, 0, "ECX", dest.dHigh);
	if (dest.dLow != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_LOW, qstream, valMult, oleDate, 0, "ECX", dest.dLow);
	if (dest.dOpen != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_OPEN, qstream, valMult, oleDate, 0, "ECX", dest.dOpen);
	if (dest.LTP != 0)pMDE->PrepareQuotesStream(dest, QUOTES_STREAM_TYPE_LAST, qstream, valMult, oleDate, 0, "ECX", dest.LTP);

	if( qstream.NoOfSymbols > 0 )
	{
		pMDE->BroadcastQuoteItem(&qstream);
	}

	LeaveCriticalSection(&pServer->m_csPipe);
}

CPipeServer::CPipeServer(void)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "CPipeServer::CPipeServer, PipeServer created");
	m_nPendingConnects	= 0;
	m_hIOCP				= NULL;

	m_hThMain		= NULL;
	m_hThConnect	= NULL;

	InitializeCriticalSection(&m_csPipe);

	_control87(_PC_64 , _MCW_PC );
}

CPipeServer::~CPipeServer(void)
{
	Destroy();
}

void CPipeServer::CleanUp()
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

DWORD WINAPI CPipeServer::ThInst(LPVOID lpvd)
{
	PAIRINST *p = (PAIRINST*) lpvd;

	if (p)
	{
		p->first->OnRead(p->second);
		delete p;
	}

	return 0;
}

void CPipeServer::OnRead(SOverlapped* pOlp)
{
	CBuffer myBuffAns;
	DWORD dwAns = myBuffAns.GetSize();

	m_pCallback(pOlp->pBuff->GetPTR(),
				pOlp->pBuff->GetCurrLen(),
				myBuffAns.GetPTR(),
				&dwAns,
				m_pMDE,
				this);
	
	// Uncommented - BR
	RemoveOverlapped(pOlp, true);

	//myBuffAns.SetCurrLen(pOlp->pBuff->GetCurrLen());
	//myBuffAns.Assign(pOlp->pBuff->GetPTR(), pOlp->pBuff->GetCurrLen());
	//pOlp->pBuff->Assign(myBuffAns);

	//DWORD dwWritten = 0;

	//if (WriteFile(pOlp->hPipe,
	//		pOlp->pBuff->GetPTR(),
	//		pOlp->pBuff->GetCurrLen(),
	//		&dwWritten,
	//		&pOlp->ol))
	//{
	//	PostQueuedCompletionStatus(m_hIOCP,
	//					dwWritten,
	//					(ULONG_PTR)pOlp->hPipe,
	//					&pOlp->ol);
	//}
	//else if (GetLastError() != ERROR_IO_PENDING)
	//{
	//	//probably pipe is being closed, or pipe not connected
	//	RemoveOverlapped(pOlp, true);
	//}
}

DWORD WINAPI CPipeServer::ThConnect(LPVOID lpvd)
{
	//wait for multiple objects: shutdown/more connects
	//see CServerSocks::Accept...if ConnectNamedPipe completed immediately PostQueuedStatus ...

	CPipeServer* p = (CPipeServer*) lpvd;

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


DWORD CPipeServer::ThMain(LPVOID lpvd)
{
	CPipeServer* p = (CPipeServer*) lpvd;

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
						//_ASSERT(NULL);
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

				//DWORD dwBytesRead = 0;
				//if (!ReadFile(pOverlapPlus->hPipe,
				//		pOverlapPlus->pBuff->GetPTR(),
				//		pOverlapPlus->pBuff->GetSize(),
				//		&dwBytesRead,
				//		&pOverlapPlus->ol))
				//{
				//	DWORD dwErr;
				//	if ((dwErr = GetLastError()) != ERROR_IO_PENDING
				//		&& dwErr != ERROR_PIPE_LISTENING)
				//	{
				//		//_ASSERT(NULL);
				//		p->RemoveOverlapped(pOverlapPlus);
				//		break;
				//	}

				//}
				//else //completed immediately
				//{
				//	pOverlapPlus->pBuff->SetCurrLen(dwBytesRead);

				//	PostQueuedCompletionStatus(p->m_hIOCP,
				//		dwBytesRead,
				//		(ULONG_PTR)pOverlapPlus->hPipe,
				//		&pOverlapPlus->ol);
				//}
			}
			break;

		case OP_WRITE:
			{
				//write complete
				//set op and wait for client to read data we have written and disconnect

				pOverlapPlus->nOpCode = OP_DISCONNECT;
				//pOverlapPlus->nOpCode = OP_READ;
				//DWORD dwBytesRead = 0;
				//if (!ReadFile(pOverlapPlus->hPipe,
				//		pOverlapPlus->pBuff->GetPTR(),
				//		pOverlapPlus->pBuff->GetSize(),
				//		&dwBytesRead,
				//		&pOverlapPlus->ol))
				//{
				//	DWORD dwErr;
				//	if ((dwErr = GetLastError()) != ERROR_IO_PENDING
				//		&& dwErr != ERROR_PIPE_LISTENING)
				//	{
				//		//_ASSERT(NULL);
				//		p->RemoveOverlapped(pOverlapPlus);
				//		break;
				//	}

				//}
				//else //completed immediately
				//{
				//	pOverlapPlus->pBuff->SetCurrLen(dwBytesRead);

				//	PostQueuedCompletionStatus(p->m_hIOCP,
				//		dwBytesRead,
				//		(ULONG_PTR)pOverlapPlus->hPipe,
				//		&pOverlapPlus->ol);
				//}
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


BOOL CPipeServer::Create(BL_MDE *pMDE, LPCTSTR pIpc, PASYNCPIPES_CALLBACK pCallback)
{
	m_pCallback = pCallback;

	m_pMDE = pMDE;
	m_strPipeName = ("\\\\.\\pipe\\");
	m_strPipeName += pIpc;

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
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "PipeServer::Create, PIPE Not created");
		_ASSERT(NULL);
		return FALSE;
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "PipeServer::Create, Created PIPE");

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

	SendSignal(SERVER_PIPEGATEWAY, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_EXTERNAL_CONNS_UP);

	//// Start the KA Server
	StartKAthread(SERVER_PIPEGATEWAY);

	return TRUE;
}


void CPipeServer::RemoveOverlapped(SOverlapped *pOlp, bool bDecreaseRef)
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


BOOL CPipeServer::Destroy()
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
