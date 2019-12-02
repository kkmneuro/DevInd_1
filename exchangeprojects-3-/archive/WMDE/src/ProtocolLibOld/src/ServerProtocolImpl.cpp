#include "stdafx.h"
#include "socket.h"
#include "ServerProtocolImpl.h"
#include "JSONHandler.h"


ServerProtocol::ServerProtocol()
{
	//std::string buff;
	//int msgtype = 4;
	//buff = "{\"msgtype\":4, \"Account\" : 327, \"OrderQty\" : 1, \"ClOrdId\" : \"701\", \"ProductType\" : \"1\", \"Product\" : \"GOLD\", \"Contract\" : \"GOLDAPR2015\", \"Gateway\" : \"ECX\", \"OrderType\" : \"1\", \"Price\" : 26445, \"Side\" : \"1\", \"TimeInForce\" : \"0\", \"StopPx\" : 0, \"ExpireDate\" : 0, \"TransactTime\" : 0, \"OrderID\" : 701, \"origClOrdId\" : \"\", \"PositionEffect\" : \"O\", \"LnkdOrdId\" : \"\", \"MinOrDisclosedQty\" : 0, \"Slipage\" : 0, \"OCOOrder\" : \"false\"}";
	//JSONHandler::GetObjectFromJSON((char *)buff.c_str(), buff.length(), msgtype);
	m_serverSocket = CreateServerSocket();
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

bool ServerProtocol::WebSocketSend(unsigned int clientId, void* msg, unsigned int msgtype, unsigned long long PacketID)
{
	IClientSession *pSession = GetClientSession(clientId);

	if (pSession)
	{
		pSession->WebsocketSend(msg, msgtype, m_serverSocket);
	}

	return true;
}
bool ServerProtocol::Send(unsigned int clientId,void* msg,unsigned int msgtype,unsigned long long PacketID)
{
	bool retVal=false;
	
	// 
	if(m_serverSocket->Send(clientId,(char*)msg,msgtype))
	{
		//m_clientSessionMgr->UpdateSendTime(clientId);
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
		char httpResponse[4096];
		int responseLen = 0;
		clientSession->HandleRecdBuffer(buff, size, m_pServerProtEvent, httpResponse, responseLen);

		if (responseLen != 0)
			Send(clientSession->GetClientId(), httpResponse, responseLen, 0);
		else
		{

		}
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