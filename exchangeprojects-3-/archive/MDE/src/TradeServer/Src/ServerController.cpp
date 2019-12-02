#include "ServerController.h"
#include "xconfigure.h"
#include "API.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"

#define		CONFIG_FILE		"MDEServerSetting.ini"

ServerController::ServerController()
:m_connectionMgr(NULL),
m_ptrIServerBL(NULL),
m_threadPool(NULL)
{
	m_hNotifyStopServer=CreateEvent(NULL,FALSE,FALSE,NULL);

	m_connectionMgrMDE = NULL;
	m_nPort = 9000;
	m_nMaxConnections = 20;
	m_nMaxIOWorkers = 5;
	m_nHeartBeatSec = 30;

	ReadConfig();

	CoInitializeEx(NULL, COINIT_MULTITHREADED);
}

ServerController::~ServerController()
{
	CloseHandle(m_hNotifyStopServer);

	if (m_connectionMgr)
	{
		delete m_connectionMgr;
		m_connectionMgr = NULL;
	}

	if (m_connectionMgrMDE)
	{
		delete m_connectionMgrMDE;
		m_connectionMgrMDE = NULL;
	}

	if (m_ptrIServerBL)
	{
		delete m_ptrIServerBL;
		m_ptrIServerBL = NULL;
	}

	if (m_threadPool)
	{
		delete m_threadPool;
		m_threadPool = NULL;
	}

	// Uninitialize COM
	CoUninitialize();
}

IConnectionMgr* ServerController::GetConnectionMgr()
{
	return m_connectionMgr;
}

IThreadPool* ServerController::GetThreadPool()
{
	return m_threadPool;
}

IServerBL*	ServerController::GetServerBL()
{
	return m_ptrIServerBL;
}


void ServerController::RunTS()
{
	SendSignal(SERVER_MDE, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_STARTING);

	//m_threadPool=new ThreadPool();

	SetupthreadPools();

	m_ptrIServerBL = CreateBusinessObject();

	SendSignal(SERVER_MDE, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_BO_UP);

	m_connectionMgr=new ConnectionMgr(this,m_nPort,m_nMaxConnections,m_nMaxIOWorkers,m_nHeartBeatSec);

	SendSignal(SERVER_MDE, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_PORTS_READY);
	
	m_ptrIServerBL->setConnectionMgr(m_connectionMgr);

	m_connectionMgr->StartListen();

#ifdef DLGAPP

#else
	WaitForSingleObject(m_hNotifyStopServer,INFINITE);
#endif
}
void ServerController::StopTS()
{
	SetEvent(m_hNotifyStopServer);
}

void ServerController::ReadConfig()
{
	xconfigure ConfigObj(CONFIG_FILE);

	std::string strCon; 
	
	long port, maxConnections, maxIOWorkers, heartBeat;

	ConfigObj.GetParameterLong( "SERVER", std::string("PORT"), port);
	ConfigObj.GetParameterLong( "SERVER", std::string("MAXCONNS"), maxConnections);
	ConfigObj.GetParameterLong( "SERVER", std::string("MAXIOWORKERS"), maxIOWorkers);
	ConfigObj.GetParameterLong( "SERVER", std::string("HEARTBEAT"), heartBeat);

	m_nPort = port;
	m_nMaxConnections = maxConnections;
	m_nMaxIOWorkers = maxIOWorkers;
	m_nHeartBeatSec = heartBeat;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "ServerController::ReadConfig, SERVER:PORT = %d,MAXCONNS = %d, maxIOWorkers = %d, HEARTBEAT = %d",
													port,
													maxConnections,
													maxIOWorkers,
													heartBeat);

}

int ServerController::SetupthreadPools()
{
	int nSuccess = 0;

	PTP_WORK work = NULL;
	PTP_WORK_CALLBACK workcallback = MyWorkCallback;
	FILETIME FileDueTime;
	ULARGE_INTEGER ulDueTime;

	//printf("Setupthreadpools 1 \n");
	InitializeThreadpoolEnvironment(&m_CallBackEnviron);

	//printf("Setupthreadpools 2 \n");
	m_pool = CreateThreadpool(NULL);

	//printf("Setupthreadpools 3 \n");

	if (m_pool)
	{
		//printf("Setupthreadpools 4 \n");
		//SetThreadpoolThreadMaximum(m_pool, 1);

		SetThreadpoolThreadMaximum(m_pool, 30);

		//printf("Setupthreadpools 5 \n");
		if (SetThreadpoolThreadMinimum(m_pool, 1))
		{
			//
			// Associate the callback environment with our thread pool.
			//
			//printf("Setupthreadpools 6 \n");
			SetThreadpoolCallbackPool(&m_CallBackEnviron, m_pool);
			//printf("Setupthreadpools 7 \n");
		}
	}

	//printf("Setupthreadpools 8 \n");

	return nSuccess;

}


int		ServerController::SendToRun(IRequest *pRequest)
{
	int nSuccess = 0;

	PTP_WORK work = CreateThreadpoolWork(ServerController::MyWorkCallback, pRequest, &m_CallBackEnviron);

	if (work)
	{
		SubmitThreadpoolWork(work);
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::SendToRun, Work creation for thread pool failed");
	}

	return nSuccess;
}


VOID CALLBACK ServerController::MyWorkCallback(PTP_CALLBACK_INSTANCE Instance,
	PVOID                 Parameter,
	PTP_WORK              Work)
{
	IRequest* pRequest = (IRequest *)Parameter;
	//BL_MDE *pMDE = BL_MDE::GetInstance();

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::MyWorkCallback, Start");
	if (pRequest)
	{
		pRequest->Run();
	}
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::MyWorkCallback, Stop");

	//free(pRequest);
	//delete pRequest;
	CloseThreadpoolWork(Work);

}
