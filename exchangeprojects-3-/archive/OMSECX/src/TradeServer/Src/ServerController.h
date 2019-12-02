#pragma once
#include "ConnectionMgr.h"
#include "ServerInterface.h"
//#include "ThreadPool.h"


//#define OMS
////#define MDF 1
//#ifdef MDE
//#if _DEBUG
//#pragma comment(lib,"MDED.lib")
//#else
//#pragma comment(lib,"MDE.lib")
//#endif
//#endif
//#ifdef MDF
//#if _DEBUG
//#pragma comment(lib,"OECD.lib")
//#else
//#pragma comment(lib,"OEC.lib")
//#endif
//#endif
//#ifdef OMS
//#if _DEBUG
////#pragma comment(lib,"TradeBOD.lib")
//#else
//#pragma comment(lib,"OMS.lib")
//#endif
//#endif

class ServerController : IServerController
{
private:
	IConnectionMgr*					m_connectionMgr;
	IConnectionMgr*					m_connectionMgrMDE;
	//IThreadPool*					m_threadPool;
	IServerBL*						m_ptrIServerBL;
	HANDLE							m_hNotifyStopServer;

	// Config settings
	unsigned short					m_nPort;
	unsigned int					m_nMaxConnections;
	unsigned int					m_nMaxIOWorkers;
	unsigned int					m_nHeartBeatSec;

public:
	ServerController();
	virtual ~ServerController();

	virtual IConnectionMgr*		GetConnectionMgr();
	//virtual IThreadPool*		GetThreadPool();
	virtual IServerBL*			GetServerBL()  ;
	virtual void				ReadConfig();

	virtual int					SendToRun(IRequest *pRequest);

	TP_CALLBACK_ENVIRON					m_CallBackEnviron;
	PTP_POOL							m_pool;

	int SetupthreadPools();
	static VOID CALLBACK MyWorkCallback(PTP_CALLBACK_INSTANCE Instance,
		PVOID                 Parameter,
		PTP_WORK              Work);


	void RunTS();
	void StopTS();

//	int	SendToRun(IRequest *Parameter);
};



