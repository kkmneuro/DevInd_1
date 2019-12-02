#pragma once
#include "datadef.h"
#include <windows.h>
#include <process.h>
#include <map>
#include <queue>
#include <list>
#include <vector>


#include "DatabaseInterface.h"

using namespace std;
#include "IAccount.h"

#ifdef _DEBUG
//Debug mode - TRACE causes printf output
#include <stdio.h>
#define MYTRACE(params) printf params;
#else
//Release mode - TRACE expands to nothing!
#define MYTRACE(params) printf params;
#endif // DEBUG

class ThreadPool;
class ClientSession;
class ConnectionMgr;
class IServerProtocolEvents;
class IRoute;

typedef struct
{
	void*										msg;
	unsigned int								msgType;
	unsigned int								clientId;
}MESSAGE;

class IRequest
{
public:
	virtual void Run() = 0;
	virtual bool AutoDelete() = 0;
	virtual ~IRequest(){};
	ThreadPool* pThreadPool;
};

class IClientSession
{
public:
	virtual unsigned int GetClientId()=0;
	virtual char* GetClientIp()=0;
	virtual unsigned short	GetclientPort()=0;
	virtual void HandleRecdBuffer( char * buff
									, unsigned int size
									, IServerProtocolEvents* pServerProtEvents )=0;
	virtual void SetUserName(char *pszUserName) = 0;
	virtual const char *GetUserName() = 0;
	virtual void SetGroupID(int nGroup) = 0;
	virtual int GetGroupID() = 0;
	virtual void AddAccount(IAccount *pAcc) = 0;
	virtual std::list<IAccount *>::iterator RemoveAccount(IAccount *pAcc, std::list<IAccount *>::iterator& iter) = 0;
	virtual std::list<IAccount *>& GetAccountList() = 0;
	virtual ~IClientSession(){};
};


class IClientSessionMgr
{
public:
	virtual ~IClientSessionMgr(){};
	virtual void Add(unsigned int clientId, char* clientIp, unsigned short clientPort)=0;
	virtual void AddUserName(unsigned int clientId, std::string strUserName) = 0;
	virtual void Remove(unsigned int clientId)=0;
	virtual IClientSession* GetClientSession(unsigned int clientId)=0;
	virtual std::list<unsigned int>* GetClientSessionList(std::string strUserName) = 0;
	virtual void DisconnectClient(unsigned int clientID) = 0;
	virtual bool IsShutdown() = 0;
	virtual bool UpdateSendTime(unsigned int clientID) = 0;
	virtual void AcquireSessionLock() = 0;
	virtual void ReleaseSessionLock() = 0;
};

class IAccountMgr
{
public:
	virtual ~IAccountMgr(){};
	virtual void Initialize()=0;
	virtual void AddAccount(LogonRequest* logonReq,IClientSession* clSession)=0;
	virtual void Remove(IClientSession* clientSession)=0;
	virtual bool Validate(logonRequest* logonReq,LogonResponse* logonResp, IClientSession *pSession)=0;
	virtual IAccount *GetIAccount(unsigned int account) = 0;
	virtual void SetConnectionMgr(IConnectionMgr *pConnMgr) = 0;
	virtual void LoadAllAccounts() = 0;
	virtual void SetRoute(IRoute *pRoute) = 0;
	virtual int ReLoadAllGroupSymbolSpread() = 0;
	virtual int EnableAccounts(unsigned long id, bool bEnable) = 0;
	virtual int LoadAllEnabledGroups() = 0;
	virtual bool IsGroupEnabled(unsigned int grpId) = 0;
	virtual int GetMarkupPrice(symbol& sym, char side, bool bUp, unsigned long long price, unsigned long long& ulMarkedupPrice, int nGroupID) = 0;

protected:
	virtual void AddAccount(char *ptrUserName, IClientSession *ptrSession
		, ITable *ptrTable) =0;
};

enum ThreadPriority
{
	High,
	Low
};
enum PoolState
{
	Ready, 
	Destroying, 
	Destroyed 
};

class IThreadPool
{
public:
	virtual ~IThreadPool(){};
	virtual bool	Create()=0;	
	virtual void	Destroy()=0;	
	virtual int		GetPoolSize()=0;
	virtual void	SetPoolSize(int)=0;
	virtual bool	Run(IRequest*, ThreadPriority priority = Low)=0;
	virtual bool	CheckThreadStop()=0;
	virtual int		GetWorkingThreadCount()=0;
	virtual PoolState GetState()=0;
};


class IConnectionMgr
{
public: 
	virtual ~IConnectionMgr(){};
	virtual void SendResponseToQueue(unsigned int clientId,void* msg,unsigned int msgtype)=0;
	virtual void SendResponseToQueue(char *pszUserName,void* msg,unsigned int msgtype)=0;
	virtual void ProcessNextRequest(unsigned int clientId,void* msg,unsigned int msgtype)=0;
	virtual IClientSession* GetClientSession(unsigned clientID) = 0;
	virtual void RemoveConnection(unsigned int clientID) = 0;
	virtual bool IsUserAlreadyLoggedIn(const char *pszUserName) = 0;
	virtual bool StartListen() = 0;
};

class IServerBL
{
public:
	virtual		~IServerBL(){} ;
	virtual		IRequest*			getIRequestPointer(MESSAGE msg) = 0 ;
	virtual		void				onNewClientAdded(unsigned clientID, IConnectionMgr *ptrMgr = NULL) = 0 ;
	virtual		void				onNewClientAdded(IClientSession *clientID) = 0 ;
	virtual		void				onClientDisconnected(unsigned clientID) = 0;	
	virtual		void				setConnectionMgr(IConnectionMgr* ptrIConnectionMgr) = 0 ;
	virtual		unsigned int		GetClientID() = 0;
	virtual		unsigned int		GetClientIDMDE() = 0;
	virtual     void				InitializeSystem(){};
};

//class IBusinessObjectFactory
//{
//public:
//	virtual		~IBusinessObject(){} ;
//	virtual		IBusinessObjectFactory*				getBusinessObject() = 0;
//	virtual		IOrder*								getOrderObject() = 0;
//	virtual		IAccount*							getAccountObject() = 0;
//};

class IDataBaseManager
{
public:
	virtual ~IDataBaseManager() {};
	virtual  IDatabase* getDatabase() = 0;
};

class IServerController
{
public:
	virtual ~IServerController(){};
	virtual IThreadPool*		GetThreadPool()	= 0 ;
	virtual IConnectionMgr*		GetConnectionMgr() = 0 ;
	virtual IServerBL*			GetServerBL() = 0 ;
	virtual void				ReadConfig() = 0;
	virtual int	SendToRun(IRequest *Parameter) = 0;
};

