#include "stdafx.h"
#include "socket.h"
#include "ServerProtocolImpl.h"


ServerProtocol::ServerProtocol()
{
	m_serverSocket=CreateServerSocket();
	m_serverSocket->RegisterEvents(this);

	m_clientSessionMgr=new ClientSessionMgr(this);

}



ServerProtocol::~ServerProtocol()
{
	delete m_clientSessionMgr;
	m_clientSessionMgr = NULL;

	ReleaseServerSocket(m_serverSocket);
}

bool ServerProtocol::Start(unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker)
{
	 
	 return m_serverSocket->Start(port, maxConnection, maxIOWorker);
}

bool ServerProtocol::Send(unsigned int clientId,void* msg,unsigned int msgtype,unsigned long long PacketID)
{
	bool retVal=false;
	
	if(m_serverSocket->Send(clientId,(char*)msg,*((unsigned int*) msg)))
	{
		m_clientSessionMgr->UpdateSendTime(clientId);
		retVal=true;
	}

	return retVal;
}

void ServerProtocol::RegisterServerEvents( IServerProtocolEvents * pServerProtEvent )
{
	m_pServerProtEvent = pServerProtEvent;
	
}

IClientSessionMgr* ServerProtocol::GetClientSessionManager()
{
	return m_clientSessionMgr;
}


void ServerProtocol::Shutdown()
{
	m_serverSocket->ShutDown();
}

PROTOCOLAPI IServerProtocol* __stdcall CreateServerProtocol ()
{
	return new ServerProtocol();
}

PROTOCOLAPI void __stdcall ReleaseServerProtocol(IServerProtocol* serverProtocol)
{
	delete serverProtocol;
}

void ServerProtocol::OnConnect( unsigned int clientID
							  , bool connect
							  , char* clientIp
							  , unsigned short clientPort )
{	
	m_pServerProtEvent->OnConnectionStatus( clientID, connect, clientIp, clientPort );
}

void ServerProtocol::OnReceive( unsigned int clientId
							  , char * buff
							  , unsigned int size )
{
	IClientSession* clientSession = GetClientSession( clientId );
	if( clientSession )
	{
		clientSession->HandleRecdBuffer( buff, size, m_pServerProtEvent );
	}

}

void ServerProtocol::OnSend ( unsigned int clientId
							, unsigned int noOfBytesSend
							, SocketError code)
{
	if(code==SOCKET_SUCCESS)
	{
		m_pServerProtEvent->OnSendStatus(clientId,true,0);
	}
	else
	{
		m_pServerProtEvent->OnSendStatus(clientId,false,0);
	}
}

IClientSession* ServerProtocol::GetClientSession(unsigned clientID)
{
	return m_clientSessionMgr->GetClientSession(clientID);
}


void ServerProtocol::DisconnectClient(unsigned int clientID)
{
	m_serverSocket->DisconnectClient(clientID);
}