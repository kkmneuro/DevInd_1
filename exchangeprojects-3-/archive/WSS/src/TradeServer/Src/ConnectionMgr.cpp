#include "ConnectionMgr.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "JSONHandler.h"

unsigned long long ConnectionMgr::m_pkID=0;

ConnectionMgr::ConnectionMgr(IServerController* pServerController, unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker, unsigned int heartBeatSec)
{	
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ConnectionMgr, Entered");

	m_serverController=pServerController;

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
	/*m_serverProtocol = CreateServerProtocol();
	m_serverProtocol->RegisterServerEvents(this);*/
	/*if(!m_serverProtocol->Start(port, maxConnection, maxIOWorker))
	{
		ReleaseServerProtocol(m_serverProtocol);
		m_serverProtocol=NULL;
	}*/
	/*if(m_serverProtocol)
	{
		m_heartBeat=new HeartBeat(this,heartBeatSec);
		m_heartBeat->Start();
	}*/
}

bool ConnectionMgr::Start()
{
	if(!m_serverProtocol->Start(9022, 1000, 100))
	{
		ReleaseServerProtocol(m_serverProtocol);
		m_serverProtocol=NULL;
	}


//}
	return true;
}

ConnectionMgr::~ConnectionMgr()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::~ConnectionMgr, Entered");

	if(m_serverProtocol)
	{
		m_serverProtocol->Shutdown();
		ReleaseServerProtocol(m_serverProtocol);
	}
	/*if(m_heartBeat!=NULL)
	{
		m_heartBeat->Stop();
		delete m_heartBeat;
		m_heartBeat = NULL;
	}*/

	m_dispatchData=0;
	SetEvent(m_hQueueRequestMsg);
	SetEvent(m_hQueueResponseMsg);
	HANDLE handle[]={m_hProcessRequest};
	DWORD i=WaitForMultipleObjects(1,handle,TRUE,5000);
	switch ( i )
	{
	case WAIT_TIMEOUT:
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::~ConnectionMgr, Not all threads died in time");
		break;
	case WAIT_FAILED:
		//Log: WaitForMultipleObjects failed 
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::~ConnectionMgr, WaitForMultipleObjects failed");
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
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in ConnectionMgr::~ConnectionMgr  m_queueRequestMsg");
		free( m_queueRequestMsg.front().msg );

		m_queueRequestMsg.pop();

	}
}

void ConnectionMgr::OnMsgRecv(unsigned int clientId,void* msg,unsigned int msgtype)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::OnMsgRecv, Entered");

	if (msg == NULL)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::OnMsgRecv, Remove Connection");
		RemoveConnection(clientId);
		m_serverProtocol->DisconnectClient(clientId);
	}
	else
	{
		MESSAGE pkt;
		pkt.clientId = clientId;
		pkt.msgType = msgtype;
		pkt.msg = msg;
		AcquireLock(&CS_QUEUE_REQUEST_MSG);
		m_queueRequestMsg.push(pkt);
		ReleaseLock(&CS_QUEUE_REQUEST_MSG);
		SetEvent(m_hQueueRequestMsg);
	}
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
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in ConnectionMgr::ProcessRequest  m_dispatchData");
		QUEUE_REQUEST_MSG msgQ;
		WaitForSingleObject(pThis->m_hQueueRequestMsg,INFINITE);
		AcquireLock(&pThis->CS_QUEUE_REQUEST_MSG);

		while(!pThis->m_queueRequestMsg.empty())
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in ConnectionMgr::ProcessRequest  m_queueRequestMsg");
			msgQ.push(pThis->m_queueRequestMsg.front());
			pThis->m_queueRequestMsg.pop();//@Scorpio
		}
		ReleaseLock(&pThis->CS_QUEUE_REQUEST_MSG);
		while(!msgQ.empty())
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in ConnectionMgr::ProcessRequest  msgQ");
			pThis->ProcessRequest(msgQ.front());
			msgQ.pop();
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
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, Entered");

	IServerBL *pServerBL = m_serverController->GetServerBL();

	if (pServerBL)
	{
		IRequest* reqObject = pServerBL->getIRequestPointer(msg);

		if (reqObject)
			//m_serverController->GetThreadPool()->Run(reqObject);
			m_serverController->SendToRun(reqObject);
			//m_serverController->
		else
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, ReqObject is NULL");
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, Server BL is NULL");
}

void ConnectionMgr::SendResponseToProtocol(MESSAGE msg)
{
		//ConnectionMgr::m_pkID++;

	/*IClientSession *pSession =  GetClientSession(msg.clientId);

	if (pSession)
	{
		pSession->WebsocketSend(msg.msg, msg.msgType, m_serverProtocol);
	}*/
	if (m_serverProtocol)
	{
		bool RetVal = m_serverProtocol->WebSocketSend(msg.clientId, msg.msg, msg.msgType, ConnectionMgr::m_pkID);
		if (!RetVal)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToProtocol, Error while sending Client : %d, Disconnect Client : %d", msg.clientId, msg.clientId); //By Deepak

			m_serverProtocol->DisconnectClient(msg.clientId);
		}
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

				iter++;
			}
		}

		mgr->ReleaseSessionLock();
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToQueue, Mgr is NULL");
}

void ConnectionMgr::AddConnection(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, Client ID=%u, Client IP=%s, Port=%d", clientId, clientIp, clientPort);

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

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, Client ID=%u, Client IP=%s, Port=%d Exit", clientId, clientIp, clientPort);
}

void ConnectionMgr::RemoveConnection(unsigned int clientId)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::RemoveConnection, Entered");

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::RemoveConnection, Client ID=%u", clientId);

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
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::OnConnectionStatus, Entered");

	if(connect)
	{
		AddConnection(clientId, clientIp, clientPort);
	}
	else
	{
		RemoveConnection(clientId);
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ConnectionMgr::OnConnectionStatus Enter");
}
void ConnectionMgr::OnSendStatus(unsigned int clientId,bool isSuccess,unsigned long long PacketID)
{
}


IClientSession* ConnectionMgr::GetClientSession(unsigned clientID)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::GetClientSession, Entered");

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

bool ConnectionMgr::IsUserAlreadyLoggedIn(const char *pszUserName, unsigned int clientID)
{
	return false;
	bool bSuccess = false;

	IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();

	if (mgr)
	{
		mgr->AcquireSessionLock();

		std::list<unsigned int>* pList = mgr->GetClientSessionList(pszUserName);

		if (pList && !pList->empty())
		{
			bSuccess = true;
		}
		else
		{
			mgr->AddUserName(clientID, pszUserName);
		}

		mgr->ReleaseSessionLock();
	}

	return bSuccess;
}