#include "ServerProtocolImpl.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "atltime.h"

ClientSession::ClientSession(unsigned int clientID,char* clientIp,unsigned short clientPort)
{
	m_clientID=clientID; 
	//m_clientIp=clientIp; 
	strcpy(m_clientIp, clientIp);
	m_clientPort=clientPort;

	m_continueReceiving=false;

	m_nState = READ_SIZE;
	m_recBufSize = 0;
	m_msgSize = 0;

	m_LastRecvTime = CTime::GetCurrentTime();
	m_LastSendTime = CTime::GetCurrentTime();

	InitializeCriticalSection(&m_cs);
	InitializeCriticalSection(&m_csAccounts);
}

ClientSession::~ClientSession()
{
	DeleteCriticalSection(&m_cs);

	free(m_clientIp);
	//m_clientIp = NULL;
}

unsigned int ClientSession::GetClientId()
{
	return m_clientID;
}
char* ClientSession::GetClientIp()
{
	return m_clientIp;
}
unsigned short ClientSession::GetclientPort()
{
	return m_clientPort;
}

void ClientSession::HandleRecdBuffer( char * buff, unsigned int size, IServerProtocolEvents* pServerProtEvents )
{
	AcquireLock(&m_cs);
	unsigned int sizeRead = 0;

	while (sizeRead < size)
	{
		if (m_nState == READ_SIZE)
		{
			if (size - sizeRead < sizeof(unsigned int))
			{
				// Copy it to buffer and wait.
				memcpy(m_recBuf, buff + sizeRead, size - sizeRead);
				m_nState = WAIT_FOR_SIZE_BLOCK;

				m_recBufSize += (size - sizeRead);
				sizeRead += (size - sizeRead);
			}		
			else
			{
				memcpy(&m_msgSize, buff + sizeRead, sizeof(unsigned int));
				memcpy(m_recBuf, buff + sizeRead, sizeof(unsigned int));

				sizeRead += sizeof(unsigned int);
				m_recBufSize += sizeof(unsigned int);

				m_nState = MSG_SIZE_READ;
			}
		}
		else if (m_nState == WAIT_FOR_SIZE_BLOCK)
		{
			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, sizeof(unsigned int) - m_recBufSize);
			memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

			sizeRead += (sizeof(unsigned int) - m_recBufSize);
			m_recBufSize += (sizeof(unsigned int) - m_recBufSize);
			m_nState = MSG_SIZE_READ;
		}
		else if (m_nState == MSG_SIZE_READ)
		{
			if ((m_msgSize - sizeof(unsigned int)) > size - sizeRead)
			{
				memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
				m_recBufSize += (size - sizeRead);
				sizeRead += (size - sizeRead);

				m_nState = PART_MSG_RECVD;
			}
			else
			{
				memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - sizeof(unsigned int)));

				m_recBufSize += (m_msgSize - sizeof(unsigned int));
				sizeRead += (m_msgSize - sizeof(unsigned int));
				m_nState = MSG_READ_COMPLETE;
			}
		}
		else if (m_nState == PART_MSG_RECVD)
		{
			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - m_recBufSize));
			sizeRead += (m_msgSize - m_recBufSize);
			m_recBufSize += (m_msgSize - m_recBufSize);

			m_nState = MSG_READ_COMPLETE;
		}

		if (m_nState == MSG_READ_COMPLETE)
		{
			char buffer[4096];
			memcpy(buffer, m_recBuf, sizeof(StructureHeader));
			pstructureHeader pHeader= (pstructureHeader)buffer;

			void* msg=GetMessageObject(pHeader->MessageType);

			if (msg)
			{
				memcpy(msg, m_recBuf, m_msgSize);	

				m_LastRecvTime = CTime::GetCurrentTime();

				// No need to pass Heartbeat to application layer
				if (pHeader->MessageType != HEARTBEAT)
				{
					pServerProtEvents->OnMsgRecv( m_clientID, msg, pHeader->MessageType );
				}
			}
			else
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
			}

			m_recBufSize = 0;
			m_msgSize = 0;

			m_nState = READ_SIZE;
			
		}
	}

	ReleaseLock(&m_cs);
}

int ClientSession::CheckHeartbeat()
{
	int nSuccess = 0;

	EnterCriticalSection(&m_cs);

	CTime tm = CTime::GetCurrentTime();

	CTimeSpan ts = tm - m_LastRecvTime;

	if (ts.GetTotalSeconds() > 90)
	{
		// Disconnect
		nSuccess = -1;
	}

	ts = tm - m_LastSendTime;

	if (ts.GetTotalSeconds() > 5)
	{
		nSuccess = 1;
	}

	LeaveCriticalSection(&m_cs);

	return nSuccess;
}

void ClientSession::AddAccount(IAccount *pAcc)
{
	EnterCriticalSection(&m_csAccounts);

	m_lstAccounts.push_back(pAcc);

	LeaveCriticalSection(&m_csAccounts);
}

std::list<IAccount *>::iterator ClientSession::RemoveAccount(IAccount *pAcc, std::list<IAccount *>::iterator& iter)
{
	EnterCriticalSection(&m_csAccounts);

	iter = m_lstAccounts.erase(iter);

	LeaveCriticalSection(&m_csAccounts);

	return iter;
}
void ClientSession::SetUserName(char *pszUserName)
{
	m_strUserName = pszUserName;
}

const char *ClientSession::GetUserName()
{
	return m_strUserName.c_str();
}


	
ClientSessionMgr::ClientSessionMgr(IServerProtocol *pProtocol)
{
	///m_connectionMgr=connectionMgr;
	m_pServerProtocol = pProtocol;
	InitializeCriticalSection(&CS_CLIENT_SESSION_MAP);
	InitializeCriticalSection(&CS_UNAME_SESSION_MAP);
	m_bShutdown = false;

	DWORD dwThreadID = 0;
	// Create thread to review all connections
	m_HandleReviewThread = CreateThread(NULL,
										0,
										(LPTHREAD_START_ROUTINE)&ClientSessionMgr::ConnectionReviewer,
										this,
										0,
										&dwThreadID);
}

ClientSessionMgr::~ClientSessionMgr()
{
	m_bShutdown = true;

	// Wait for connectionReviewer thread to close
	WaitForSingleObject(m_HandleReviewThread, 5000);

	map<unsigned int,IClientSession*>::iterator it;
	for( it = m_clientSessionMap.begin() ; it != m_clientSessionMap.end() ; it++ )
	{
		delete it->second;
		it->second = NULL;
	}
	m_clientSessionMap.clear();
	DeleteCriticalSection(&CS_CLIENT_SESSION_MAP);
}

bool ClientSessionMgr::UpdateSendTime(unsigned int clientID)
{
	bool bSuccess = false;

	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);

	map<unsigned int,IClientSession*>::iterator iter = m_clientSessionMap.find(clientID);

	if (iter != m_clientSessionMap.end())
	{
		// Update the send time
		ClientSession *pSession = (ClientSession *)(*iter).second;

		if (pSession)
		{
			pSession->m_LastSendTime = CTime::GetCurrentTime();
		}
	}

	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);

	return bSuccess;
}

void ClientSessionMgr::Add(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	IClientSession* clientSession = new ClientSession(clientId,clientIp,clientPort);
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	pair<unsigned int,IClientSession*> pr(clientSession->GetClientId(),clientSession);
	m_clientSessionMap.insert(pr);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::AcquireSessionLock()
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);
}

void ClientSessionMgr::ReleaseSessionLock()
{
	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}


void ClientSessionMgr::AddUserName(unsigned int clientId, std::string strUserName)
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::map<unsigned int,IClientSession*>::iterator iter = m_clientSessionMap.find(clientId);

	if (iter != m_clientSessionMap.end())
	{
		IClientSession *pSession = (*iter).second;;

		if (pSession)
		{
			std::map<std::string,std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSessions = (*iter1).second;

				lstSessions.push_back(pSession->GetClientId());
			}
			else
			{
				std::list<unsigned int> lstSession;

				lstSession.push_back(pSession->GetClientId());
				std::pair<std::string,std::list<unsigned int>> pr(strUserName, lstSession);
				m_mapUserNameClientSession.insert(pr);
			}
		}
	}

	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::Remove(unsigned int clientId)
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::string strUserName;

	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		IClientSession* pSession = (*iter).second;

		if (pSession)
		{
			strUserName = pSession->GetUserName();

			map<std::string,std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSession = (*iter1).second;

				lstSession.remove(clientId);

				if (lstSession.empty())
				{
					m_mapUserNameClientSession.erase(iter1);
				}
			}
		}

		m_clientSessionMap.erase(iter);
	}

	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

std::list<unsigned int>* ClientSessionMgr::GetClientSessionList(std::string strUserName)
{
	map<std::string,std::list<unsigned int>>::iterator iter = m_mapUserNameClientSession.find(strUserName);

	std::list<unsigned int> *pList = NULL;

	if (iter != m_mapUserNameClientSession.end())
	{
		pList = &(*iter).second;
	}

	return pList;
}

IClientSession* ClientSessionMgr::GetClientSession(unsigned int clientId)
{
	IClientSession* clientSession=NULL;
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		clientSession = m_clientSessionMap[clientId];
	}
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	return clientSession;
}

void ClientSessionMgr::DisconnectClient(unsigned int clientID)
{
	m_pServerProtocol->DisconnectClient(clientID);
}

bool ClientSessionMgr::IsShutdown()
{
	return m_bShutdown;
}

DWORD ClientSessionMgr::ConnectionReviewer (LPVOID lpdwThreadParam )
{
	ClientSessionMgr *pMgr = (ClientSessionMgr *)lpdwThreadParam;


	return 0L;
}

map<unsigned int,IClientSession*>& ClientSessionMgr::GetClientSessionMap()
{
	return m_clientSessionMap;
}

void ClientSessionMgr::AcquireCS()
{
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::ReleaseCS()
{
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSession::SetGroupID(int nGroup)
{
	m_nGroupID = nGroup;
}

int ClientSession::GetGroupID()
{
	return m_nGroupID;
}