#pragma once

#ifdef PROTOCOL_EXPORTS
#define PROTOCOLAPI __declspec(dllexport)
#else
#define PROTOCOLAPI __declspec(dllimport)
#endif

//#include "stdafx.h"
//#include "Datadef.h"

#define REC_BUF_SIZE 4096

typedef enum ProtocolError
{
	PROTOCOL_SUCCESS,
	PROTOCOL_FAILED
};
typedef enum ConnectStatus
{
	CONNECTING=0,
	CONNECTED,
	DISCONNECTING,
	DISCONNECTED
};

class ISocketEvents;
class IClientSessionMgr;

class IClientProtocolEvents
{
public:
	virtual void OnMsgRecv(void* msg,unsigned int msgtype) = 0;
	virtual void OnConnectionStatus(int status, unsigned int ClientID = 0) = 0;
	virtual void OnSendStatus(bool isSuccess,unsigned long long PacketID) = 0;
};

class IClientProtocol
{
public:
	virtual bool Connect(char* serverIp,unsigned short port, unsigned int maxIOWorker=2)=0;
	virtual bool Connect() = 0;
	virtual bool Send(unsigned int ClientID, void* msg,unsigned int msgtype) = 0;
	virtual void RegisterClient(IClientProtocolEvents* ptrIClientProtocolEvents) = 0;
	virtual bool Disconnect() = 0;
	virtual bool IsShutdown() = 0;
	virtual bool CheckConnectionStatus() = 0;
	virtual int HeartbeatToBeSent() = 0;
	virtual int GetConnectionStatus() = 0;
	virtual ~IClientProtocol() {};
};

class IServerProtocolEvents
{
public:
	virtual void OnMsgRecv(unsigned int clientId,void* msg,unsigned int msgtype) = 0;
	virtual void OnConnectionStatus(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort) = 0;
	virtual void OnSendStatus(unsigned int clientId,bool isSuccess,unsigned long long PacketID) = 0;
};

class IServerProtocol
{
public:
	virtual ~IServerProtocol(){};
	virtual bool Start(unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker) = 0;
	virtual void Shutdown() = 0;
	virtual bool Send(unsigned int clientId,void* msg,unsigned int msgtype,unsigned long long PacketID) = 0;
	virtual void RegisterServerEvents( IServerProtocolEvents * pServerEvent)= 0;
	virtual IClientSessionMgr* GetClientSessionManager() = 0; 
	virtual void DisconnectClient(unsigned int clientID) = 0;
};


// Factory function that creates instances of the Server Protocol object.
PROTOCOLAPI IServerProtocol* __stdcall CreateServerProtocol ();

//Function for releasing the Server Protocol object.
PROTOCOLAPI void __stdcall ReleaseServerProtocol(IServerProtocol* serverProtocol);

// Factory function that creates instances of the client Protocol object.
PROTOCOLAPI IClientProtocol* __stdcall CreateClientProtocol ();

//Function for releasing the client protocol object.
PROTOCOLAPI void __stdcall ReleaseClientProtocol(IClientProtocol* clientProtocol);
