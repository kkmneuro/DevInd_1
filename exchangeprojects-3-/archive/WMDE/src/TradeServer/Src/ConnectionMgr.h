#pragma once
#include "Protocol.h"
#include "ServerInterface.h"
#include "RequestOrder.h"
//#include "Socket.h"

//#import "ContractServer.tlb" no_namespace, named_guids, raw_native_types, raw_interfaces_only
class HeartBeat;

class ConnectionMgr 
	: public IServerProtocolEvents
	, public IConnectionMgr
	
{
private:

	typedef queue<MESSAGE>							QUEUE_REQUEST_MSG;
	typedef queue<MESSAGE>							QUEUE_RESPONSE_MSG;
	typedef map<unsigned long long ,MESSAGE>		MAP_RESPONSE_MSG;
	
	CRITICAL_SECTION								CS_QUEUE_REQUEST_MSG;

	HANDLE											m_hQueueRequestMsg;
	HANDLE											m_hQueueResponseMsg;
	QUEUE_REQUEST_MSG								m_queueRequestMsg;
	volatile int									m_dispatchData;

	IServerProtocol*								m_serverProtocol;
	HeartBeat*										m_heartBeat;
	IServerController*								m_serverController;
	static unsigned long long						m_pkID;
	HANDLE											m_hProcessRequest;

	unsigned short m_port;
	unsigned int m_MaxConns;
	unsigned int m_maxIOWorker;

	static unsigned int _stdcall ProcessRequest(void* arg);
	void ProcessRequest(MESSAGE msg);
	void SendResponseToProtocol(MESSAGE msg);

	void AddConnection(unsigned int clientID, char* clientIp, unsigned short clientPort);
	void RemoveConnection(unsigned int clientID);
	void ProcessBLRequest(MESSAGE msg);

	bool StartListen();


public:
	ConnectionMgr(IServerController* pServerController, unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker, unsigned int heartBeatSec);
	virtual ~ConnectionMgr();

	virtual void SendResponseToQueue(unsigned int clientId,void* msg,unsigned int msgtype);
	virtual void ProcessNextRequest(unsigned int clientId,void* msg,unsigned int msgtype);
	virtual IClientSession* GetClientSession(unsigned clientID);
	virtual void OnMsgRecv(unsigned int clientId,void* msg,unsigned int msgtype);
	virtual void OnConnectionStatus(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort);
	virtual void OnSendStatus(unsigned int clientId,bool isSuccess,unsigned long long PacketID);
	virtual bool IsUserAlreadyLoggedIn(const char *pszUserName, unsigned int ClientID);
	virtual void SendResponseToQueue(char *pszUserName,void* msg,unsigned int msgtype);

};

class HeartBeat
{
private:
	ConnectionMgr*	m_connectionMgr;
	unsigned int	m_intervalSec;
	volatile int	m_start;
	static unsigned int _stdcall SendHeartBeat(void* arg);
public:
	HeartBeat(ConnectionMgr* connectionMgr, unsigned int intervalSec);
	virtual ~HeartBeat();
	unsigned int GetInterval();
	bool Start();
	void Stop();
};



