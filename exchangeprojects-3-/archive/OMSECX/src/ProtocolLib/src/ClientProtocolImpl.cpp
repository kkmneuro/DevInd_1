#include "stdafx.h"
#include "ClientProtocolImpl.h"
#include "UtilitiesAPI.h"
#include "errordefs.h"
#include "datadef.h"
//#include "xlogger.h"
ClientProtocol::ClientProtocol()
{
	m_bShutDown = false;
	m_clientSocket=CreateClientSocket();
	m_clientSocket->RegisterEvents(this);
	m_clientEvent=NULL;
	m_continueReceiving=false;

	m_nState = READ_SIZE;
	m_recBufSize = 0;
	m_msgSize = 0;
	m_connectStatus = CONNECTING;

	InitializeCriticalSection(&m_cs);

	DWORD dwThreadID = 0;

	m_bReconnect = false;
	// Create thread to review all connections
	m_handleConnectionMonitor = CreateThread(NULL,
										0,
										(LPTHREAD_START_ROUTINE)&ClientProtocol::ConnectionMonitor,
										this,
										0,
										&dwThreadID);

}

ClientProtocol::~ClientProtocol()
{
	m_bShutDown = true;

	WaitForSingleObject(m_handleConnectionMonitor, 5000);

	ReleaseClientSocket(m_clientSocket);
	DeleteCriticalSection(&m_cs);
}

bool ClientProtocol::Connect(char* serverIp,unsigned short port, unsigned int maxIOWorker)
{
	m_connectStatus=CONNECTING;

	strcpy(m_ServerIP,serverIp);
	m_ulPort = port;
	m_ulMaxIOWorkers = maxIOWorker;

	//if( m_clientSocket->Connect(serverIp,port,maxIOWorker))
	if( m_clientSocket->Connect(serverIp,port))
	{
		if(m_clientEvent)
		{
			//m_clientEvent->OnConnectionStatus(m_connectStatus);//@Scorpio
		}
		return true;
	}
	else
	{
		m_connectStatus=DISCONNECTED;
		if(m_clientEvent)
		{
			m_clientEvent->OnConnectionStatus(m_connectStatus, m_ClientID);
		}
		return false;
	}
}

bool ClientProtocol::Send(unsigned int ClientID, void* msg,unsigned int msgtype)
{
	int suc = ERR_OK;
	bool retVal=false;
	
	if(m_clientSocket->Send(ClientID,(char*)msg,*((unsigned int*) msg)))
	{
		m_LastSendTime = CTime::GetCurrentTime();
		retVal=true;
	}
	else
	{
		if (m_clientEvent )
			m_clientEvent->OnSendStatus(false, 0);
		//	m_clientEvent->OnConnectionStatus(DISCONNECTED, ClientID);
	}	
	/*if(msg != NULL)
	{
		free(msg);
	}*/
	return retVal;
}

int ClientProtocol::HeartbeatToBeSent()
{
	int nSuccess = 0;

	CTime tm = CTime::GetCurrentTime();

	CTimeSpan ts = tm - m_LastSendTime;

	if (ts.GetTotalSeconds() > 20)
	{
		// Disconnect
		nSuccess |= 1;
	}

	/*ts = tm - m_LastRecvTime;

	if (ts.GetTotalSeconds() > 15)
	{
		nSuccess |= 2;
	}*/


	return nSuccess;
}

void ClientProtocol::RegisterClient(IClientProtocolEvents* ptrIClientProtocolEvents)
{
	m_clientEvent=ptrIClientProtocolEvents;
}

bool ClientProtocol::Disconnect()
{
	m_connectStatus=DISCONNECTING;
	m_clientSocket->ShutDown();
	if(m_clientEvent!=NULL)
	{
		m_clientEvent->OnConnectionStatus(m_connectStatus);
	}
	return true;
}

void ClientProtocol::OnConnect(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort)
{
	if(connect)
	{
		m_connectStatus=CONNECTED;
		if(m_clientEvent!=NULL)
		{
			m_ulClientID = clientID;
			m_clientEvent->OnConnectionStatus(connect, clientID);
		}
	}
	else
	{
		m_connectStatus=DISCONNECTED;
		if(m_clientEvent!=NULL)
		{
			m_clientEvent->OnConnectionStatus(DISCONNECTED);

			//Connect();
		}
	}
}

void ClientProtocol::OnReceive(unsigned int ClientID, char * buff, unsigned int size)
{
	AcquireLock(&m_cs);
	//unsigned int sizeRead = 0;

	//while (sizeRead < size)
	//{
	//	if (m_nState == READ_SIZE)
	//	{
	//		if (size - sizeRead < sizeof(unsigned int))
	//		{
	//			// Copy it to buffer and wait.
	//			memcpy(m_recBuf, buff + sizeRead, size - sizeRead);
	//			m_nState = WAIT_FOR_SIZE_BLOCK;

	//			m_recBufSize += (size - sizeRead);
	//			sizeRead += (size - sizeRead);
	//		}		
	//		else
	//		{
	//			memcpy(&m_msgSize, buff + sizeRead, sizeof(unsigned int));
	//			memcpy(m_recBuf, buff + sizeRead, sizeof(unsigned int));

	//			sizeRead += sizeof(unsigned int);
	//			m_recBufSize += sizeof(unsigned int);

	//			m_nState = MSG_SIZE_READ;
	//		}
	//	}
	//	else if (m_nState == WAIT_FOR_SIZE_BLOCK)
	//	{
	//		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, sizeof(unsigned int) - m_recBufSize);
	//		memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

	//		sizeRead += (sizeof(unsigned int) - m_recBufSize);
	//		m_recBufSize += (sizeof(unsigned int) - m_recBufSize);
	//		m_nState = MSG_SIZE_READ;
	//	}
	//	else if (m_nState == MSG_SIZE_READ)
	//	{
	//		if ((m_msgSize - sizeof(unsigned int)) > size - sizeRead)
	//		{
	//			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
	//			m_recBufSize += (size - sizeRead);
	//			sizeRead += (size - sizeRead);

	//			m_nState = PART_MSG_RECVD;
	//		}
	//		else
	//		{
	//			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - sizeof(unsigned int)));

	//			m_recBufSize += (m_msgSize - sizeof(unsigned int));
	//			sizeRead += (m_msgSize - sizeof(unsigned int));
	//			m_nState = MSG_READ_COMPLETE;
	//		}
	//	}
	//	else if (m_nState == PART_MSG_RECVD)
	//	{
	//		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - m_recBufSize));
	//		sizeRead += (m_msgSize - m_recBufSize);
	//		m_recBufSize += (m_msgSize - m_recBufSize);

	//		m_nState = MSG_READ_COMPLETE;
	//	}

	//	if (m_nState == MSG_READ_COMPLETE)
	//	{
	//		char buffer[4096];
	//		memcpy(buffer, m_recBuf, sizeof(StructureHeader));
	//		pstructureHeader pHeader= (pstructureHeader)buffer;

	//		void* msg=GetMessageObject(pHeader->MessageType);

	//		//void *msg = GetObject(pHeader->MessageType);

	//		if (msg)
	//		{
	//			memcpy(msg, m_recBuf, m_msgSize);	

	//			m_LastRecvTime = CTime::GetCurrentTime();
	//			m_clientEvent->OnMsgRecv(  msg, pHeader->MessageType );
	//		}
	//		else
	//		{
	//			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
	//		}

	//		m_recBufSize = 0;
	//		m_msgSize = 0;

	//		m_nState = READ_SIZE;
	//		
	//	}
	//}

	ReleaseLock(&m_cs);
}

void ClientProtocol::OnSend ( unsigned int ClientID, unsigned int noOfBytesSend, SocketError code)
{
	if(m_clientEvent!=NULL)
	{
		if(code==SOCKET_SUCCESS)
		{
			m_clientEvent->OnSendStatus(true,0);
		}
		else
		{
			m_clientEvent->OnSendStatus(false,0);
		}
	}
}


PROTOCOLAPI IClientProtocol* __stdcall CreateClientProtocol ()
{
	return new ClientProtocol();
}

PROTOCOLAPI void __stdcall ReleaseClientProtocol(IClientProtocol* clientProtocol)
{
	delete clientProtocol;
}

bool ClientProtocol::IsShutdown()
{
	return m_bShutDown;
}

bool ClientProtocol::CheckConnectionStatus()
{
	return (m_connectStatus == CONNECTED || m_connectStatus == CONNECTING);
}

bool ClientProtocol::Connect()
{
	return Connect(m_ServerIP, m_ulPort, m_ulMaxIOWorkers);
}

int ClientProtocol::GetConnectionStatus()
{
	return m_connectStatus;
}

DWORD ClientProtocol::ConnectionMonitor (LPVOID lpdwThreadParam )
{
	IClientProtocol *pClientProtocol = (IClientProtocol *)lpdwThreadParam;

	pHeartbeatFromClient hbt = (pHeartbeatFromClient)GetMessageObject(HEARTBEAT);

	if (hbt)
	{
		if (pClientProtocol)
		{
			while(!pClientProtocol->IsShutdown())
			{
				if (!pClientProtocol->CheckConnectionStatus())
				{
					
					// disconnected. Try to connect
					pClientProtocol->Connect();
				}
				else
				{
					//if (pClientProtocol->GetConnectionStatus() == CONNECTED)
					//{
					//	// Check the time and send the heartbeat message
					//	int nSuccess = pClientProtocol->HeartbeatToBeSent();

					//	if (nSuccess & 1)
					//	{
					//		//if (((ClientProtocol *)pClientProtocol)->m_connectStatus != 3)
					//			pClientProtocol->Send(((ClientProtocol *)pClientProtocol)->m_ulClientID, hbt, HEARTBEAT);
					//	}

					//	/*if(nSuccess & 2)
					//	{
					//		pClientProtocol->Disconnect();
					//		continue;
					//	}*/
					//}
				}

				Sleep(200);
			}
		}
	}

	if (hbt)
	{
		free(hbt);
	}

	return 0L;
}
