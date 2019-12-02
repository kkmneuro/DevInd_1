////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date		Resource		Ticket No					Desc
//
//	9 Dec 23013	BR				TradingApplication/80		Added function ProcessModifyAccountNoRequest
//
//
////////////////////////////////////////////////////////////////////////////////////////////////////////


#pragma once
#include "serverinterface.h"
#include "DataDef.h"

class IOrder;
class IDatabase;
class IRoute;

class OrderHandler :
	public IRequest
{
public:
	OrderHandler(int reqType, 
				 void *ptrRequest, 
				IConnectionMgr *ptrConnectionMgr, 
				IDatabase	*ptrDatabase, 
				IAccountMgr *pAccountMgr,
				IRoute *pRoute,
				DWORD dwCookie,
				unsigned int ClientID);

	~OrderHandler(void);

	virtual void Run();
	virtual bool AutoDelete();

	void GenerateBusinessLevelReject(unsigned int            RefMsgType,
									char*                   BusinessRejectRefID,
									int						BusinessRejectReason,
									int						size);

	void SendResponseToAllAssociatedClients(unsigned long Account, void *pResponse, int msgType);


private:
	IOrder				*_ptrOrder;
	IConnectionMgr		*_ptrConnectionMgr;
	IDatabase			*_ptrDatabase;
	IAccountMgr			*_ptrAccountMgr;
	IRoute				*_ptrRoute;
	DWORD				m_dwCookie;
	IContractManager    *m_pContractManager;
	void				*m_pRequest;
	char				m_ReqType;
	unsigned int		m_ClientID;

private:
	void ProcessNewOrder();
	void ProcessCancelOrder();
	void ProcessCancelReplaceOrder();
	void ProcessLinkedOrder();
	void ProcessModifyAccountNoRequest();
	void ProcessPositionRequest();
	void ProcessReloadDPR();

	int MarkupAllPrices(IOrder *pOrder, IAccount *pAcc, bool bUP, SymbolSpread& sp, unsigned long long& ulMarkedupPrice, unsigned long long& ulMarkedupStopPx);
};
