#include "ConnectionMgr.h"

ClientSession::ClientSession(unsigned int clientID,char* clientIp,unsigned short clientPort)
{
	m_clientID=clientID; 
	m_clientIp=clientIp; 
	m_clientPort=clientPort;
}

ClientSession::~ClientSession()
{
	free(m_clientIp);
	m_clientIp = NULL;
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


ClientSessionMgr::ClientSessionMgr(IConnectionMgr* connectionMgr)
{
	m_connectionMgr=connectionMgr;
	InitializeCriticalSection(&CS_CLIENT_SESSION_MAP);
}

ClientSessionMgr::~ClientSessionMgr()
{
	map<unsigned int,IClientSession*>::iterator it;
	for( it = m_clientSessionMap.begin() ; it != m_clientSessionMap.end() ; it++ )
	{
		delete it->second;
		it->second = NULL;
	}
	m_clientSessionMap.clear();
	DeleteCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::Add(IClientSession* clientSession)
{
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
	pair<unsigned int,IClientSession*> pr(clientSession->GetClientId(),clientSession);
	m_clientSessionMap.insert(pr);
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::Remove(unsigned int clientId)
{
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		m_clientSessionMap.erase(iter);
	}
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
}

IClientSession* ClientSessionMgr::GetClientSession(unsigned int clientId)
{
	IClientSession* clientSession=NULL;
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		clientSession = m_clientSessionMap[clientId];
	}
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
	return clientSession;
}
