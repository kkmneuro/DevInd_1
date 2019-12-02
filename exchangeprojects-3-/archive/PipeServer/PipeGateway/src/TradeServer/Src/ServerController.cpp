#include "ServerController.h"
#include "xconfigure.h"
#include "API.h"
#include "xlogger.h"
#include "UTILITIESAPI.h"

#define		CONFIG_FILE		"MDEServerSetting.ini"

ServerController::ServerController()
:m_connectionMgr(NULL),
m_ptrIServerBL(NULL),
m_threadPool(NULL)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ServerController, Entered");

	m_hNotifyStopServer=CreateEvent(NULL,FALSE,FALSE,NULL);

	m_connectionMgrMDE = NULL;
	m_nPort = 9000;
	m_nMaxConnections = 20;
	m_nMaxIOWorkers = 5;
	m_nHeartBeatSec = 30;

	ReadConfig();

	CoInitializeEx(NULL, COINIT_MULTITHREADED);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ServerController, Exit");
}

ServerController::~ServerController()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::~ServerController, Entered");

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

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::~ServerController, Exit");
}

IConnectionMgr* ServerController::GetConnectionMgr()
{
	return m_connectionMgr;
}



IServerBL*	ServerController::GetServerBL()
{
	return m_ptrIServerBL;
}


void ServerController::RunTS()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::RunTS, Entered");

	SendSignal(SERVER_PIPEGATEWAY, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_STARTING);

	//m_threadPool=new ThreadPool();
	m_connectionMgr=new ConnectionMgr(this,m_nPort,m_nMaxConnections,m_nMaxIOWorkers,m_nHeartBeatSec);

	SendSignal(SERVER_PIPEGATEWAY, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_PORTS_READY);

	m_ptrIServerBL = CreateBusinessObject();

	m_ptrIServerBL->setConnectionMgr(m_connectionMgr);

	SendSignal(SERVER_PIPEGATEWAY, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_BO_UP);

#ifdef DLGAPP

#else
	WaitForSingleObject(m_hNotifyStopServer,INFINITE);
#endif

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::RunTS, Exit");
}
void ServerController::StopTS()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::StopTS, Entered");

	SetEvent(m_hNotifyStopServer);

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::StopTS, Exit");
}

void ServerController::ReadConfig()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ReadConfig, Entered");

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

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ServerController::ReadConfig, SERVER:PORT = %d,MAXCONNS = %d, maxIOWorkers = %d, HEARTBEAT = %d",
													port,
													maxConnections,
													maxIOWorkers,
													heartBeat);


	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ServerController::ReadConfig, Exit");
}