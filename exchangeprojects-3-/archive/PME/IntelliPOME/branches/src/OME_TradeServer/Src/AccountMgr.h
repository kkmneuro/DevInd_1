#include "ServerInterface.h"


class AccountMgr : public IAccountMgr
{
private:
	typedef map<IAccount*,list<IClientSession*>>	ACCOUNT_MAP;
	typedef map<IClientSession*,IAccount*>			CLIENT_ACC_MAP;
	ACCOUNT_MAP										m_accountMap;
	CLIENT_ACC_MAP									m_clientAccMap;
	CRITICAL_SECTION								CS_ACCOUNT_MAP;
	IDataBaseManager*								m_DatabaseMgr;
public:
	AccountMgr(IDataBaseManager* mgr);
	~AccountMgr();
	void Initialize();
	void AddAccount(LogonRequest* logonReq,IClientSession* clSession);
	void Remove(IClientSession* clientSession);
	bool Validate(logonRequest* logonReq,LogonResponse* logonResp);
};
