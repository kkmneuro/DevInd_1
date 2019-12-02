#include "ConnectionMgr.h"
#include "xlogger.h"


unsigned long long ConnectionMgr::m_pkID=0;

ConnectionMgr::ConnectionMgr(IServerController* pServerController, unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker, unsigned int heartBeatSec)
{	
	m_serverController=pServerController;

	InitializeCriticalSection(&CS_QUEUE_REQUEST_MSG);
	InitializeCriticalSection(&CS_QUEUE_RESPONSE_MSG);
	InitializeCriticalSection(&CS_MAP_RESPONSE_MSG);

	m_hQueueRequestMsg=CreateEvent(NULL,FALSE,FALSE,NULL);
	m_hQueueResponseMsg=CreateEvent(NULL,FALSE,FALSE,NULL);
	m_dispatchData=1;

	//m_hSendResponse=(HANDLE)_beginthreadex(NULL,NULL,ConnectionMgr::SendResponse,this,NULL,NULL);
	//if(INVALID_HANDLE_VALUE == m_hSendResponse)
	//{
	//	//Log:
	//	//throw
	//}
	m_hProcessRequest=(HANDLE)_beginthreadex(NULL,NULL,ConnectionMgr::ProcessRequest,this,NULL,NULL);
	if(INVALID_HANDLE_VALUE == m_hProcessRequest)
	{
		//Log:
		//throw
	}


	
	m_serverProtocol=CreateServerProtocol();
	m_serverProtocol->RegisterServerEvents(this);
	if(!m_serverProtocol->Start(port, maxConnection, maxIOWorker))
	{
		ReleaseServerProtocol(m_serverProtocol);
		m_serverProtocol=NULL;
	}
	if(m_serverProtocol)
	{
		m_heartBeat=new HeartBeat(this,heartBeatSec);
		m_heartBeat->Start();
	}
	
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
	HANDLE handle[]={m_hSendResponse,m_hProcessRequest};
	DWORD i=WaitForMultipleObjects(2,handle,TRUE,5000);
	switch ( i )
	{
	case WAIT_TIMEOUT:
		//Log: "Not all threads died in time." 
		//throw
		break;
	case WAIT_FAILED:
		//Log: WaitForMultipleObjects failed 
		//throw
		break;
	default:
		break;
	}
	CloseHandle(m_hSendResponse);
	CloseHandle(m_hProcessRequest);
	CloseHandle(m_hQueueRequestMsg);
	CloseHandle(m_hQueueResponseMsg);

	DeleteCriticalSection(&CS_MAP_RESPONSE_MSG);
	DeleteCriticalSection(&CS_QUEUE_REQUEST_MSG);
	DeleteCriticalSection(&CS_QUEUE_RESPONSE_MSG);

	//Clearing All Queues data

	while( !m_queueRequestMsg.empty() )
	{
		free( m_queueRequestMsg.front().msg );

		m_queueRequestMsg.pop();

	}

	//while( !m_queueResponseMsg.empty() )
	//{
	//	free( m_queueResponseMsg.front().msg );

	//	m_queueResponseMsg.pop();

	//}

	m_mapResponseMsg.clear();
}

void ConnectionMgr::OnMsgRecv(unsigned int clientId,void* msg,unsigned int msgtype)
{
	MESSAGE pkt;
	pkt.clientId=clientId;
	pkt.msgType=msgtype;
	pkt.msg=msg;
	EnterCriticalSection(&CS_QUEUE_REQUEST_MSG);
	m_queueRequestMsg.push(pkt);
	LeaveCriticalSection(&CS_QUEUE_REQUEST_MSG);
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
		EnterCriticalSection(&pThis->CS_QUEUE_REQUEST_MSG);

		while(!pThis->m_queueRequestMsg.empty())
		{
			msgQ.push(pThis->m_queueRequestMsg.front());
			pThis->m_queueRequestMsg.pop();//@Scorpio
		}
		LeaveCriticalSection(&pThis->CS_QUEUE_REQUEST_MSG);
		while(!msgQ.empty())
		{
			pThis->ProcessRequest(msgQ.front());
			msgQ.pop();
		}
	}
	return 0;
}

void ConnectionMgr::ProcessRequest(MESSAGE msg)
{
	/*switch(msg.msgType)
	{*/
	/*case LOGON_REQUEST:
		ValidateLogonRequest(msg.clientId,msg.msg);
		break;
	default:*/
		ProcessBLRequest(msg);
		//break;
	//}
}

void ConnectionMgr::ProcessBLRequest(MESSAGE msg)
{
	IServerBL *pServerBL = m_serverController->GetServerBL();

	if (pServerBL)
	{
		IRequest* reqObject = pServerBL->getIRequestPointer(msg);

		if (reqObject)
			m_serverController->SendToRun(reqObject);
		//	//m_serverController->GetThreadPool()->Run(reqObject);
		//	m_serverController->
		////else
		//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, ReqObject is NULL");
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::ProcessBLRequest, Server BL is NULL");
}


//unsigned int _stdcall ConnectionMgr::SendResponse(void *arg)
//{
//	ConnectionMgr* pThis=(ConnectionMgr*)arg;
//	while(pThis->m_dispatchData)
//	{
//		QUEUE_RESPONSE_MSG respQ;
//		WaitForSingleObject(pThis->m_hQueueResponseMsg,INFINITE);
//		EnterCriticalSection(&pThis->CS_QUEUE_RESPONSE_MSG);
//		while(!pThis->m_queueResponseMsg.empty())
//		{
//			respQ.push(pThis->m_queueResponseMsg.front());
//			pThis->m_queueResponseMsg.pop();
//		}
//		LeaveCriticalSection(&pThis->CS_QUEUE_RESPONSE_MSG);
//		while(!respQ.empty() && pThis->m_dispatchData)
//		{
//			pThis->SendResponseToProtocol(respQ.front());
//			respQ.pop();
//		}
//	}
//	return 0;
//}

void ConnectionMgr::SendResponseToProtocol(MESSAGE msg)
{
	//ConnectionMgr::m_pkID++;

	if (m_serverProtocol)
	{
		m_serverProtocol->Send(msg.clientId,msg.msg,msg.msgType,ConnectionMgr::m_pkID);
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToProtocol, m_serverProtocol is NULL");
	}
	//pair<unsigned long long, MESSAGE> pr(ConnectionMgr::m_pkID,msg);
	//EnterCriticalSection(&CS_MAP_RESPONSE_MSG);
	//m_mapResponseMsg.insert(pr);
	//LeaveCriticalSection(&CS_MAP_RESPONSE_MSG);
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
			}
		}

		mgr->ReleaseSessionLock();
	}
	else
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::SendResponseToQueue, Mgr is NULL");
}

void ConnectionMgr::ValidateLogonRequest(unsigned int clientId, void* msg)
{
	//logonResponse* logonResp =(logonResponse*) malloc(sizeof(logonResponse)) ;
	logonResponse *logonResp = (logonResponse *)GetMessageObject(LOGON_RESPONSE);
	logonResp->EncryptionMethod = 'B';
	
	//if(m_serverController->GetAccountMgr()->Validate((logonRequest*) msg,logonResp))
	//{
	//	m_serverController->GetAccountMgr()->AddAccount((logonRequest*) msg, m_clientSessionMgr->GetClientSession(clientId));
	//	logonResp->HeartbeatInterval=m_heartBeat->GetInterval();
	//	m_serverController->GetServerBL()->onNewClientAdded(clientId);
	//	SendResponseToQueue(clientId,logonResp,logonResp->Header.MessageType);
	//}
	//else
	//{
	//	//Session level reject
	//	//Close conection
	//	//remove from sessionmanager
	//}
}

void ConnectionMgr::AddConnection(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	///ClientSession* clientSession=new ClientSession(clientId,clientIp,clientPort);
	m_serverProtocol->GetClientSessionManager()->Add(clientId,clientIp,clientPort);
	m_serverController->GetServerBL()->onNewClientAdded(clientId, this);
}

void ConnectionMgr::RemoveConnection(unsigned int clientId)
{
	m_serverProtocol->GetClientSessionManager()->Remove(clientId);

	m_serverController->GetServerBL()->onClientDisconnected(clientId);
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
	if(isSuccess)
	{
		//remove from map and acknowledge
		EnterCriticalSection(&CS_MAP_RESPONSE_MSG);
		m_mapResponseMsg.erase(PacketID);
		LeaveCriticalSection(&CS_MAP_RESPONSE_MSG);
	}
	else
	{
		//send failed
	}
}


IClientSession* ConnectionMgr::GetClientSession(unsigned clientID)
{
	
	return m_serverProtocol->GetClientSessionManager()->GetClientSession(clientID);
}

bool ConnectionMgr::IsUserAlreadyLoggedIn(const char *pszUserName, unsigned int clientID)
{
	return true;
}

bool ConnectionMgr::Start()
{
	return true;
}