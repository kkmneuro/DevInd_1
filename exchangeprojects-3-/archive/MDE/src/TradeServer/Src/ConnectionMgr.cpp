#include "ConnectionMgr.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"

unsigned long long ConnectionMgr::m_pkID=0;

ConnectionMgr::ConnectionMgr(IServerController* pServerController, unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker, unsigned int heartBeatSec)
{	
	m_serverController=pServerController;
	m_port = port;
	m_MaxConns = maxConnection;
	m_maxIOWorker = maxIOWorker;

	InitializeCriticalSection(&CS_QUEUE_REQUEST_MSG);

	m_hQueueRequestMsg=CreateEvent(NULL,FALSE,FALSE,NULL);
	m_hQueueResponseMsg=CreateEvent(NULL,FALSE,FALSE,NULL);
	m_dispatchData=1;

	m_hProcessRequest=(HANDLE)_beginthreadex(NULL,NULL,ConnectionMgr::ProcessRequest,this,NULL,NULL);
	if(INVALID_HANDLE_VALUE == m_hProcessRequest)
	{
		//Log:
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ConnectionMgr::ConnectionMgr, Unable to create thread");
		//throw
	}
	
	m_serverProtocol=CreateServerProtocol();
	m_serverProtocol->RegisterServerEvents(this);

	if(!m_serverProtocol->Start(m_port, m_MaxConns, m_maxIOWorker))
	{
		ReleaseServerProtocol(m_serverProtocol);
		m_serverProtocol=NULL;
	}
}

bool ConnectionMgr::StartListen()
{
	

	return true;
}

ConnectionMgr::~ConnectionMgr()
{
	if(m_serverProtocol)
	{
		m_serverProtocol->Shutdown();
		ReleaseServerProtocol(m_serverProtocol);
	}

	if(m_heartBeat!=NULL)
	{
		m_heartBeat->Stop();
		delete m_heartBeat;
		m_heartBeat = NULL;
	}

	m_dispatchData=0;
	
	SetEvent(m_hQueueRequestMsg);
	SetEvent(m_hQueueResponseMsg);

	HANDLE handle[]={m_hProcessRequest};
	DWORD i=WaitForMultipleObjects(1,handle,TRUE,5000);
	switch ( i )
	{
	case WAIT_TIMEOUT:
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ConnectionMgr::~ConnectionMgr, Not all threads died in time");
		break;
	case WAIT_FAILED:
		//Log: WaitForMultipleObjects failed 
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ConnectionMgr::~ConnectionMgr, WaitForMultipleObjects failed");
		//throw
		break;
	default:
		break;
	}
	CloseHandle(m_hProcessRequest);
	CloseHandle(m_hQueueRequestMsg);
	CloseHandle(m_hQueueResponseMsg);

	DeleteCriticalSection(&CS_QUEUE_REQUEST_MSG);

	//Clearing All Queues data
	while( !m_queueRequestMsg.empty() )
	{
		free( m_queueRequestMsg.front().msg );

		m_queueRequestMsg.pop();

	}
}

void ConnectionMgr::OnMsgRecv(unsigned int clientId,void* msg,unsigned int msgtype)
{
	MESSAGE pkt;
	pkt.clientId=clientId;
	pkt.msgType=msgtype;
	pkt.msg=msg;
	AcquireLock(&CS_QUEUE_REQUEST_MSG);
	m_queueRequestMsg.push(pkt);
	ReleaseLock(&CS_QUEUE_REQUEST_MSG);
	SetEvent(m_hQueueRequestMsg);
}
void ConnectionMgr::ProcessNextRequest(unsigned int clientId,void* msg,unsigned int msgtype)
{
	OnMsgRecv(clientId, msg, msgtype);
}


unsigned int _stdcall ConnectionMgr::ProcessRequest(void* arg)
{
	ConnectionMgr* pThis=(ConnectionMgr*)arg;
	while(pThis->m_dispatchData)
	{
		QUEUE_REQUEST_MSG msgQ;
		WaitForSingleObject(pThis->m_hQueueRequestMsg,INFINITE);
		AcquireLock(&pThis->CS_QUEUE_REQUEST_MSG);

		while(!pThis->m_queueRequestMsg.empty())
		{
			msgQ.push(pThis->m_queueRequestMsg.front());
			//Sleep(1);
			pThis->m_queueRequestMsg.pop();//@Scorpio
		}
		ReleaseLock(&pThis->CS_QUEUE_REQUEST_MSG);
		while(!msgQ.empty())
		{
			pThis->ProcessRequest(msgQ.front());
			msgQ.pop();

			//Sleep(1);
		}
	}
	return 0;
}

void ConnectionMgr::ProcessRequest(MESSAGE msg)
{
	ProcessBLRequest(msg);
}

void ConnectionMgr::ProcessBLRequest(MESSAGE msg)
{
	IServerBL *pServerBL = m_serverController->GetServerBL();

	if (pServerBL)
	{
		IRequest* reqObject = pServerBL->getIRequestPointer(msg);

		if (reqObject)
			m_serverController->SendToRun(reqObject);
			//m_serverController->GetThreadPool()->Run(reqObject);
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, Server BL is NULL");
}

void ConnectionMgr::SendResponseToProtocol(MESSAGE msg)
{
	if (m_serverProtocol)
	{
		m_serverProtocol->Send(msg.clientId,msg.msg,msg.msgType,ConnectionMgr::m_pkID);
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToProtocol, m_serverProtocol is NULL");
	}
}

void ConnectionMgr::SendResponseToQueue(unsigned int clientId,void* msg,unsigned int msgtype)
{
	MESSAGE pkt;

	pkt.clientId=clientId;
	pkt.msgType=msgtype;
	pkt.msg=msg;

	SendResponseToProtocol(pkt);
}

void ConnectionMgr::AddConnection(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();
	IServerBL *pServerBL = NULL;

	if (mgr)
	{
		mgr->Add(clientId,clientIp,clientPort);

		pServerBL = m_serverController->GetServerBL();

		if (pServerBL)
		{
			pServerBL->onNewClientAdded(clientId);
		}
		else
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, ServerBL is NULL");
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, SessionManager is NULL");
}

void ConnectionMgr::RemoveConnection(unsigned int clientId)
{
	IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();
	IServerBL *pServerBL = NULL;

	if (mgr)
	{
		pServerBL = m_serverController->GetServerBL();

		if (pServerBL)
		{
			pServerBL->onClientDisconnected(clientId);
		}
		else
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::RemoveConnection, ServerBL is NULL");

		mgr->Remove(clientId);
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::RemoveConnection, SessionManager is NULL");
}

void ConnectionMgr::OnConnectionStatus(unsigned int clientId, bool connect, char* clientIp, unsigned short clientPort)
{
	if(connect)
	{
		AddConnection(clientId, clientIp, clientPort);
	}
	else
	{
		RemoveConnection(clientId);
	}
}
void ConnectionMgr::OnSendStatus(unsigned int clientId,bool isSuccess,unsigned long long PacketID)
{
}


IClientSession* ConnectionMgr::GetClientSession(unsigned clientID)
{
	IClientSession *pSession = NULL;
	IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();

	if (mgr)
	{
		pSession = mgr->GetClientSession(clientID);
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::GetClientSession, Mgr is NULL");

	return pSession;
}

void ConnectionMgr::SendResponseToQueue(char *pszUserName,void* msg,unsigned int msgtype)
{
	IClientSession *pSession = NULL;
	IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();

	if (mgr)
	{
		MESSAGE pkt;

		pkt.msgType=msgtype;
		pkt.msg=msg;

		mgr->AcquireSessionLock();

		std::list<unsigned int>* pList = mgr->GetClientSessionList(pszUserName);

		if (pList)
		{
			std::list<unsigned int>::iterator iter = pList->begin();

			while(!pList->empty() && iter != pList->end())
			{
				unsigned int clientId = (*iter);

				pkt.clientId=clientId;
				SendResponseToProtocol(pkt);
			}
		}

		mgr->ReleaseSessionLock();
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToQueue, Mgr is NULL");
}


bool ConnectionMgr::IsUserAlreadyLoggedIn(const char *pszUserName)
{
	bool bSuccess = false;

	/*IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();

	if (mgr)
	{
		mgr->AcquireSessionLock();

		std::list<unsigned int>* pList = mgr->GetClientSessionList(pszUserName);

		if (pList && !pList->empty())
		{
			bSuccess = true;
		}

		mgr->ReleaseSessionLock();
	}*/

	return bSuccess;
}