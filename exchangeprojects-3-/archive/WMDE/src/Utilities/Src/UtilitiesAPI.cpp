//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date				Initials			Desc
//
//24 Dec 2013	BR					Ticket TradingApplication/93. Added functions to send signals to monitor server.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "malloc.h"
#include "process.h"

#define SERVERNAME			"MonitorServer"
#define KA_TIME				5000

UTILITIESAPI void __stdcall AcquireLock (CRITICAL_SECTION *pCS)
{
	EnterCriticalSection(pCS);
}

UTILITIESAPI void __stdcall ReleaseLock (CRITICAL_SECTION *pCS)
{
	LeaveCriticalSection(pCS);
}

UTILITIESAPI void __stdcall SendSignal (int SERVER, int SignalType, int Status)
{
	HANDLE hPipe;

	std::string pipeName = "\\\\.\\pipe\\";
	pipeName.append(SERVERNAME);

	MonitorSignal ms;
	ms.SERVER = SERVER;
	ms.SignalType = SignalType;
	ms.Status = Status;

	DWORD dwWrittenBytes = 0;
	if ((hPipe = CreateFile(pipeName.c_str(),
							GENERIC_READ |
							GENERIC_WRITE,
							FILE_SHARE_READ | FILE_SHARE_WRITE,
							NULL,
							OPEN_EXISTING,
							FILE_FLAG_OVERLAPPED,
							NULL)) == INVALID_HANDLE_VALUE)
	{
		DWORD error = GetLastError();
	}

	bool success = WriteFile(hPipe,
		(void *)&ms,
		sizeof(ms),
		&dwWrittenBytes,
		NULL);

	if (success == true)
	{
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SendSignal, Autohedge order sent for OrderID = %s", exeReport->report.ClOrdId);
	}
	else
	{
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SendSignal, Signal not sent to server %s", pipeName.c_str());
	}
}

HANDLE KAThreadHandle;
bool bTerminateKAthread = false;

unsigned int _stdcall KAthread(void* arg)
{
	int *server = (int *)arg;

	int nServer = *server;
	delete server;

	while (!bTerminateKAthread)
	{
		SendSignal(nServer, SIGNAL_TYPE_KA, SIGNAL_STATUS_KA);

		Sleep(KA_TIME);
	}

	return 0L;
}


UTILITIESAPI void __stdcall StartKAthread(int Server)
{
	int *pnServer = new int;

	*pnServer = Server;
	// Start the thread that will send the KA packets to the Monitor Server.
	KAThreadHandle=(HANDLE)_beginthreadex(NULL, NULL, KAthread, pnServer, NULL, NULL);

	if(INVALID_HANDLE_VALUE == KAThreadHandle)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StartKAthread, Unable to create thread");
	}
}

UTILITIESAPI void __stdcall StopKAthread(int Server)
{
	// Stop the KA thread.
	bTerminateKAthread = true;
}


void * operator new (size_t size)
{
  void *pTemp = NULL;

//#ifdef TP_FEH_TEST  
//  if (!nInitCS)
//  {
//	TpeCriticalSectionInit(&g_memCs);
//    nInitCS++;
//  }
//
//
//  if (failCount != 0)
//  {
//    TpeCriticalSectionEnter(&g_memCs);
//
//    currentAllocated += size;
//    failCount--;
//#endif
    pTemp = malloc(size);
//#ifdef TP_FEH_TEST
//    if (pTemp)
//    {
//      g_stMemInfo[g_nCurrMemIndex].memPtr = pTemp ;
//      g_stMemInfo[g_nCurrMemIndex].memSize = size;
//      g_nCurrMemIndex++;
//    }
//    TpeCriticalSectionLeave(&g_memCs);
//  }
//#endif
  return pTemp;
}