#include "ServerController.h"
#include "DataBaseManagerImpl.h"
#include "xconfigure.h"
#include "xlogger.h"
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
	m_threadPool=new ThreadPool();
	m_connectionMgr=new ConnectionMgr(this, m_nPortTrades, m_nMaxConnectionsTrades, m_nMaxIOWorkersTrades, m_nHeartBeatSecTrades);
	m_connectionMgrMDE=new ConnectionMgr(this, m_nPortQuotes, m_nMaxConnectionsQuotes, m_nMaxIOWorkersQuotes, m_nHeartBeatSecQuotes);
#if OME
	m_ptrIServerBL = Create_OME_BL(m_connectionMgr,m_connectionMgrMDE);
	//m_ptrIServerBL->setConnectionMgr(m_connectionMgr);
#endif


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