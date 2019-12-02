#pragma once
#include "OME_Interface.h"

typedef map<string,IMarket *>					KEY_MARKET_ORDER_MAP;
typedef map<string,IMarket *>::iterator			KEY_MARKET_ORDER_MAP_ITER;

class IDatabase;
class GatewayClient;

class OrderHandler : public IOrderHandler
{
private:
	KEY_MARKET_ORDER_MAP				m_MktMap;
	//IMarket* m_ptrMarket;
	IServerBL*							m_ptrServerBL;
	IConnectionMgr*						m_ptrConnectionMgr;
	IConnectionMgr*						m_ptrConnectionMgrMDE;
	IMarketEvents*						m_ptrOrderResponseHandler;
	IDatabase*							m_ptrDatabase;
	IDatabase*							m_ptrDatabaseOME;
	GatewayClient*						m_ptrClient;
	bool								m_bMarketStatus;

	CRITICAL_SECTION					CS_MARKET_MAP;
	HANDLE								m_handleSessionMonitor;

	void SendAckToClient(IMarket* pMarket, ILimitOrderRequest* order);
	void SendAckToClient(IMarket* pMarket, IStopOrderRequest* order);
	void SendAckToClient(IMarket* pMarket, IMarketOrderRequest* order);
	void SendAckToClient(IMarket* pMarket, ICancelReplaceOrderRequest* order);
	void InsertOrder(Order *order);
	static DWORD SessionMonitor (LPVOID lpdwThreadParam );

	void LoadOrderBookFromDB();

	void InitializeOHLC();

public:
	OrderHandler(IServerBL* pServerBL,
					IConnectionMgr* pIConnectionMgr,
					IConnectionMgr* pIConnectionMgrMDE,
					IDatabase* pDatabase, 
					IDatabase* pDatabaseOME,
					GatewayClient *pClient);
	virtual ~OrderHandler();
	virtual void HandleOrder(IMarketOrderRequest*, bool bAtStartup = false);
	virtual void HandleOrder(ILimitOrderRequest*, bool bAtStartup = false);
	virtual void HandleOrder(IStopOrderRequest*, bool bAtStartup = false);
	virtual void HandleOrder(ICancelOrderRequest*);
	virtual void HandleOrder(ICancelReplaceOrderRequest*);
	virtual void InitializeMarket();
	virtual void HandleSnapshotRequest(pQuoteRequest pRequest);
	virtual void HandleEODProcessing(std::string strSymbol);
	virtual void HandlePriceUpdate(QuotesStream *pStream);
	virtual void SetMarketStatus(bool bStatus);
	virtual bool IsMarketOpen();

	void				RequestQuotes(GatewayClient *pClient);
	virtual void HandleOrderStatusRequest(OrderStatusRequest *pRequest );
	void HandleReloadDPR(ReloadDPR *pRequest);
};

