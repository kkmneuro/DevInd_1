#include "ServerController.h"
#include "DataBaseManagerImpl.h"
#include "xconfigure.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#define OME 1

//#define OMS
#ifdef OME
#include "OME_API.h"
#endif

#define		CONFIG_FILE		"OMEServerSetting.ini"

ServerController::ServerController()
:m_connectionMgr(NULL),
m_ptrIServerBL(NULL),
m_threadPool(NULL),
m_DatabaseMgr(NULL)
{
	m_connectionMgrMDE = NULL;
	m_hNotifyStopServer=CreateEvent(NULL,FALSE,FALSE,NULL);

	ReadConfig();
}
ServerController::~ServerController()
{
	CloseHandle(m_hNotifyStopServer);
	delete m_threadPool;
	delete m_connectionMgr;
	delete m_ptrIServerBL;
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

void ServerController::RunTS( char* UserName, char* Password, char* ConnString )
{
	SendSignal(SERVER_PME, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_STARTING);

	//m_threadPool=new ThreadPool();
	SetupthreadPools();
	m_connectionMgr=new ConnectionMgr(this, m_nPortTrades, m_nMaxConnectionsTrades, m_nMaxIOWorkersTrades, m_nHeartBeatSecTrades);
	m_connectionMgrMDE=new ConnectionMgr(this, m_nPortQuotes, m_nMaxConnectionsQuotes, m_nMaxIOWorkersQuotes, m_nHeartBeatSecQuotes);

	SendSignal(SERVER_PME, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_PORTS_READY);

#if OME
	m_ptrIServerBL = Create_OME_BL(m_connectionMgr,m_connectionMgrMDE);
	//m_ptrIServerBL->setConnectionMgr(m_connectionMgr);
#endif

	SendSignal(SERVER_PME, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_BO_UP);


#if MDE
	m_ptrIServerBL = CreateMDEBL();
	m_ptrIServerBL->setConnectionMgr(m_connectionMgr);
#endif
#if MDF
	m_ptrIServerBL = CreateMDFBL();
	m_ptrIServerBL->setConnectionMgr(m_connectionMgr);
#endif

#ifdef OMS
	m_ptrIServerBL = CreateTradeBOBL();
	m_ptrIServerBL->setConnectionMgr(m_connectionMgr);
#endif
#if DLGAPP

#else
	WaitForSingleObject(m_hNotifyStopServer,INFINITE);
#endif
}
void ServerController::RunTS()
{
	char strConnect[200] =  "Provider=sqloledb;Data Source= 192.168.1.87, 1433;Initial Catalog=BOExchange;" ;
	RunTS( "sa", "admin123@", strConnect );

}
void ServerController::StopTS()
{
	SetEvent(m_hNotifyStopServer);
}


IDataBaseManager*	ServerController::GetDatabaseManager()
{
	return m_DatabaseMgr;
}

void ServerController::ReadConfig()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ReadConfig, Entered");

	xconfigure ConfigObj(CONFIG_FILE);

	std::string strCon; 
	
	long port, maxConnections, maxIOWorkers, heartBeat;

	ConfigObj.GetParameterLong( "TRADESERVER", std::string("PORT"), port);
	ConfigObj.GetParameterLong( "TRADESERVER", std::string("MAXCONNS"), maxConnections);
	ConfigObj.GetParameterLong( "TRADESERVER", std::string("MAXIOWORKERS"), maxIOWorkers);
	ConfigObj.GetParameterLong( "TRADESERVER", std::string("HEARTBEAT"), heartBeat);

	m_nPortTrades = port;
	m_nMaxConnectionsTrades = maxConnections;
	m_nMaxIOWorkersTrades = maxIOWorkers;
	m_nHeartBeatSecTrades = heartBeat;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::ReadConfig, TRADESERVER:PORT = %d,MAXCONNS = %d, maxIOWorkers = %d, HEARTBEAT = %d",
													port,
													maxConnections,
													maxIOWorkers,
													heartBeat);


	ConfigObj.GetParameterLong( "QUOTESSERVER", std::string("PORT"), port);
	ConfigObj.GetParameterLong( "QUOTESSERVER", std::string("MAXCONNS"), maxConnections);
	ConfigObj.GetParameterLong( "QUOTESSERVER", std::string("MAXIOWORKERS"), maxIOWorkers);
	ConfigObj.GetParameterLong( "QUOTESSERVER", std::string("HEARTBEAT"), heartBeat);

	m_nPortQuotes = port;
	m_nMaxConnectionsQuotes = maxConnections;
	m_nMaxIOWorkersQuotes = maxIOWorkers;
	m_nHeartBeatSecQuotes = heartBeat;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::ReadConfig, QUOTESSERVER:PORT = %d,MAXCONNS = %d, maxIOWorkers = %d, HEARTBEAT = %d",
	//												port,
	//												maxConnections,
	//												maxIOWorkers,
	//												heartBeat);


	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ReadConfig, Exit");
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
