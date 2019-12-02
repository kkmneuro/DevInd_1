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


#pragma once

#include "Stdafx.h"

#include "tstring.h"
#include "XEvent.h"
#include "XCritSec.h"
#include "Buffer.h"

#include <vector>
using std::vector;



enum
{
	OP_CONNECT,
	OP_READ,
	OP_WRITE,
	OP_DISCONNECT
};


struct SOverlapped
{
    OVERLAPPED	ol;
	HANDLE		hPipe;
	//HANDLE		hThread;
    int			nOpCode;
	int			nRefCount;

	CBuffer*	pBuff;

	SOverlapped()
	{
		memset(&ol, 0, sizeof(ol));
		pBuff = NULL;
		nRefCount = 1;
		//hThread = NULL;
	}

	~SOverlapped()
	{
		if (pBuff)
		{
			delete pBuff;
			pBuff = NULL;
		}
	}
};


typedef vector<SOverlapped*> VECOVERLAPPED;

class BL_MDE;
class CPipeServer
{
protected:
	typedef VOID (WINAPI *PASYNCPIPES_CALLBACK)(
	  LPCVOID	pMessage,
	  DWORD		dwMessageLen,
	  LPVOID	pAns,
	  DWORD*	pdwAnsLen,
	  BL_MDE*	pMDE,
	  CPipeServer *pServer
	);


	PASYNCPIPES_CALLBACK m_pCallback;

	void OnRead(SOverlapped* pOlp);

	static DWORD WINAPI ThMain(LPVOID lpvd);
	static DWORD WINAPI ThInst(LPVOID lpvd);
	static DWORD WINAPI ThConnect(LPVOID lpvd);


	CXEvent m_eventShutdown;
	CXEvent m_eventMoreConnects;

	std::string		m_strPipeName;
	HANDLE		m_hIOCP;
	HANDLE		m_hPipe;


	HANDLE		m_hThMain;
	HANDLE		m_hThConnect;
	HANDLE		m_hThInst;


	CXCritSec		m_csOlp;
	VECOVERLAPPED	m_vecOverlapped;
	int				m_nPendingConnects;

	BL_MDE*			m_pMDE;

	void CleanUp();


public:

	CPipeServer(void);
	~CPipeServer(void);

	BOOL Create(BL_MDE *pMDE, LPCTSTR pIpc, PASYNCPIPES_CALLBACK pCallback);

	//BOOL FilterQuotes(std::string& strSymbol, MQLTick& tick);

	BOOL SendMsg(LPCTSTR  pIpc,
			PVOID   pMessage,
			DWORD   dwMessageLen,
			PVOID   pAns      = NULL,
			DWORD   dwAnsLen  = 0,
			DWORD   dwAnsTimeOut = 0);

	BOOL Destroy();
	void RemoveOverlapped(SOverlapped* pOlp, bool bDecreaseRef = false);

	static VOID WINAPI Callback(
	  LPCVOID	pMessage,
	  DWORD		dwMessageLen,
	  LPVOID	pAns,
	  DWORD*	pdwAnsLen,
	  BL_MDE*	pMDE,
	  CPipeServer *pServer);

	CRITICAL_SECTION m_csPipe;

	/*CRITICAL_SECTION m_csTicksList;
	std::map<std::string, MQLTick> m_mapSymbolTicks;*/
};


