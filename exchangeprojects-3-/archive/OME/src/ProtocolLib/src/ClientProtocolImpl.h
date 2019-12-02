#pragma once


#include "stdafx.h"
#include "Protocol.h"
#include "Socket.h"
#include "atltime.h"

enum RECVSTATE
{
	READ_SIZE = 0,
	WAIT_FOR_SIZE_BLOCK,
	MSG_SIZE_READ,
	MSG_READ_COMPLETE,
	PART_MSG_RECVD
};

class ClientProtocol : public IClientProtocol,ISocketEvents
{
private:
	Socket*										m_clientSocket;
	IClientProtocolEvents*						m_clientEvent;
	ConnectStatus								m_connectStatus;
	bool										m_continueReceiving;
	char										m_recBuf[REC_BUF_SIZE];
	unsigned int								m_recBufSize;
	unsigned int								m_msgSize;
	RECVSTATE									m_nState;

	CRITICAL_SECTION							m_cs;
	bool										m_bShutDown;
	CTime										m_LastSendTime;
	CTime										m_LastRecvTime;

	char										m_ServerIP[20];
	long										m_ulPort;
	unsigned int								m_ulMaxIOWorkers;
	unsigned long								m_ulClientID;

	HANDLE										m_handleConnectionMonitor;
	unsigned int								m_ClientID;
	bool										m_bReconnect;
public:
	ClientProtocol();
	virtual ~ClientProtocol();
	virtual bool Connect(char* serverIp,unsigned short port, unsigned int maxIOWorker=2);
	virtual bool Send(unsigned int clientID, void* msg,unsigned int msgtype);
	virtual void RegisterClient(IClientProtocolEvents* ptrIClientProtocolEvents);
	virtual bool Disconnect();
	
	virtual void  OnConnect(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort);
	virtual void  OnReceive(unsigned int clientID, char * buff, unsigned int size);
	virtual void  OnSend (unsigned int ClientID, unsigned int noOfBytesSend, SocketError code);

	static DWORD ConnectionMonitor (LPVOID lpdwThreadParam );

	virtual bool IsShutdown();
	virtual bool CheckConnectionStatus();
	virtual bool Connect();
	virtual int HeartbeatToBeSent();
	virtual int GetConnectionStatus();
};
