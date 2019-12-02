#pragma once


#include "stdafx.h"
#include "Protocol.h"
#include "socket.h"
#include "ServerInterface.h"
#include "atltime.h"


class ClientSessionMgr;
class IClientSession;

class ServerProtocol 
	: public IServerProtocol
	, public ISocketEvents
{
private:
	Socket*										m_serverSocket;
	IServerProtocolEvents *						m_pServerProtEvent;
	ClientSessionMgr*							m_clientSessionMgr;
	
public:// own methods
	IClientSession* GetClientSession(unsigned clientID);
	
public:
	//static ServerProtocol* CreateServerProtocol();
	ServerProtocol();

	virtual ~ServerProtocol();
	virtual bool Start(unsigned short port, unsigned int maxConnection, unsigned int maxIOWorker);
	virtual void Shutdown();
	virtual bool Send(unsigned int clientId,void* msg,unsigned int msgtype,unsigned long long PacketID);
	virtual void RegisterServerEvents( IServerProtocolEvents * pServerProtEvent );
	virtual IClientSessionMgr* GetClientSessionManager();
	virtual void DisconnectClient(unsigned int clientID);

public: // ISocketEvents
	virtual void OnReceive(unsigned int clientId,char * buff, unsigned int size);
	virtual void OnConnect(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort);
	virtual void OnSend(unsigned int clientId, unsigned int noOfBytesSend, SocketError code);

};

class ClientSession : public IClientSession
{
private: // own defs
	enum RECVSTATE
	{
		READ_SIZE = 0,
		WAIT_FOR_SIZE_BLOCK,
		MSG_SIZE_READ,
		MSG_READ_COMPLETE,
		PART_MSG_RECVD
	};


public:
	unsigned int					m_clientID; 
	char							m_clientIp[17]; 
	unsigned short					m_clientPort;
	CTime							m_LastRecvTime;
	CTime							m_LastSendTime;

	// trasmission data related members
	bool										m_continueReceiving;
	char										m_recBuf[REC_BUF_SIZE];
	unsigned int								m_recBufSize;
	unsigned int								m_msgSize;
	//static ServerProtocol*						m_instanceServerProtocol;

	RECVSTATE									m_nState;

	CRITICAL_SECTION							m_cs;
	CRITICAL_SECTION							m_csAccounts;
	std::string									m_strUserName;
	std::list<IAccount *>					m_lstAccounts;

	int											m_nGroupID;
public:
	ClientSession(unsigned int clientID,char* clientIp,unsigned short clientPort);
	unsigned int GetClientId();
	char* GetClientIp();
	unsigned short	GetclientPort();
	virtual ~ClientSession();
	int CheckHeartbeat();
	void HandleRecdBuffer( char * buff, unsigned int size, IServerProtocolEvents* pServerProtEvents );
	void SetUserName(char *pszUserName);
	const char *GetUserName();
	void AddAccount(IAccount *pAcc);
	std::list<IAccount *>::iterator RemoveAccount(IAccount *pAcc, std::list<IAccount *>::iterator& iter);
	std::list<IAccount *>& GetAccountList(){return m_lstAccounts;};
	void SetGroupID(int nGroup);
	int GetGroupID();
};

class ClientSessionMgr 
	: public IClientSessionMgr 
{
private:
	///IConnectionMgr*						m_connectionMgr;
	map<unsigned int,IClientSession*>	m_clientSessionMap;
	CRITICAL_SECTION					CS_CLIENT_SESSION_MAP;
	IServerProtocol						*m_pServerProtocol;
	bool								m_bShutdown;
	HANDLE								m_HandleReviewThread;
	map<std::string,std::list<unsigned int>>	m_mapUserNameClientSession;
	CRITICAL_SECTION					CS_UNAME_SESSION_MAP;

public:
	ClientSessionMgr(IServerProtocol *pProtocol);
	virtual ~ClientSessionMgr();
	virtual void Add(unsigned int clientId, char* clientIp, unsigned short clientPort);
	virtual void AddUserName(unsigned int clientId, std::string strUserName);
	virtual void Remove(unsigned int clientId);
	static DWORD ConnectionReviewer (LPVOID lpdwThreadParam );
	bool UpdateSendTime(unsigned int clientID);

	void AcquireCS();
	void ReleaseCS();

	map<unsigned int,IClientSession*>& GetClientSessionMap();

	virtual IClientSession* GetClientSession(unsigned int clientId);
	virtual std::list<unsigned int>* GetClientSessionList(std::string strUserName);
	virtual void DisconnectClient(unsigned int clientID);
	virtual bool IsShutdown();

	virtual void AcquireSessionLock();
	virtual void ReleaseSessionLock();

};
