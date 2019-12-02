#pragma once
#include "ConnectionMgr.h"
#include "ServerInterface.h"
#include "ThreadPool.h"
//#include "AccountMgr.h"
#define OME 1

//#define OMS
//#define MDF 1
#if OME
#if _DEBUG
#pragma comment(lib,"OMED.lib")
#else
#pragma comment(lib,"OME.lib")
#endif
#endif


#if MDE
#if _DEBUG
#pragma comment(lib,"MDED.lib")
#else
#pragma comment(lib,"MDE.lib")
#endif
#endif
#if MDF
#if _DEBUG
#pragma comment(lib,"OECD.lib")
#else
#pragma comment(lib,"OEC.lib")
#endif
#endif
#ifdef OMS
#if _DEBUG
#pragma comment(lib,"OMSD.lib")
#else
#pragma comment(lib,"OMS.lib")
#endif
#endif

class ServerController : IServerController
{
private:
	IDataBaseManager*				m_DatabaseMgr;
	IConnectionMgr*					m_connectionMgr;
	IConnectionMgr*					m_connectionMgrMDE;
	IThreadPool*					m_threadPool;
	IServerBL*						m_ptrIServerBL;
	HANDLE							m_hNotifyStopServer;

	unsigned short					m_nPortTrades;
	unsigned int					m_nMaxConnectionsTrades;
	unsigned int					m_nMaxIOWorkersTrades;
	unsigned int					m_nHeartBeatSecTrades;

	unsigned short					m_nPortQuotes;
	unsigned int					m_nMaxConnectionsQuotes;
	unsigned int					m_nMaxIOWorkersQuotes;
	unsigned int					m_nHeartBeatSecQuotes;

public:
	ServerController();
	virtual ~ServerController();

	virtual IConnectionMgr*		GetConnectionMgr();
	virtual IThreadPool*		GetThreadPool();
	virtual IServerBL*			GetServerBL()  ;
	virtual IDataBaseManager*	GetDatabaseManager();

	void RunTS();
	void RunTS( char* UserName, char* Password, char* ConnString );
	void StopTS();
	void				ReadConfig();
};



