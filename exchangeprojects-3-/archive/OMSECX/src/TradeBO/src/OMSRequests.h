#pragma once
#include "serverinterface.h"
#include "DataDef.h"

class IAccount;
class OMSRequestHandler :
	public IRequest
{
public:
	OMSRequestHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession, IDatabase *ptrDatabase);
	~OMSRequestHandler(void);

	virtual void Run();
	virtual bool AutoDelete();

private:
	void GenerateAndSendParticipantListResponse(std::list<IAccount *>& lstAccount, std::string& strUserName);
	void GenerateAndSendOrderHistoryResponse(void *pRequest);
	void GenerateAndSendPositionResponse(void *pRequest);
	void GenerateAndSendTradeHistoryResponse(void *pRequest);
	void GenerateAndSendOrderBookResponse(void *pRequest);
	void GenerateAndSendStopOrdersResponse(void *pRequest);
	void GenerateAndSendMatchedOrdersResponse(void *pRequest);
	void ChangePassword(void *pRequest);
	void DeliverMail(void *pRequest);
	void AccountUpdate(void *pRequest);
	void EnableAccounts(void *pRequest);
	void ReloadConfig(char type);

private:
	IConnectionMgr		*_ptrConnectionMgr;
	IAccountMgr			*_ptrAccountMgr;
	IClientSession		*_ptrSession;
	IDatabase			*_ptrDatabaseOMS;
	IDatabase			*_ptrDatabaseBO;

	void *_ptrRequest;
	unsigned int _reqType;
};
