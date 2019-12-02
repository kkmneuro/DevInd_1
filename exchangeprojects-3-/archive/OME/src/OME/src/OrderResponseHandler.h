#pragma once
#include "OME_Interface.h"

class GatewayClient;
class LimitOrderResponse : public IEventObject
{
private:
	ILimitOrderRequest* m_ptrOrder;
public:
	unsigned long long m_qnty;
	unsigned long long m_price;
	LimitOrderResponse(ILimitOrderRequest* order);
	ILimitOrderRequest* GetOrder();
};

class TriggerStopOrderEvent : public IEventObject
{
private:
	IStopOrderRequest* m_ptrOrder;
public:
	IMarket *m_pMarket;
	TriggerStopOrderEvent(IStopOrderRequest* order);
	IStopOrderRequest* GetOrder();
};

class QuotesStreamResponse: public IEventObject
{
public:
	std::list<QuotesItem>	m_Quotes;
	IMarket *m_Market;
};

class MarketOrderResponse : public IEventObject
{
private:
	IMarketOrderRequest* m_ptrOrder;
public:
	unsigned long long m_qnty;
	unsigned long long m_price;
	MarketOrderResponse(IMarketOrderRequest* order);
	IMarketOrderRequest* GetOrder();
};

class EventExecutionReport : public IEventObject
{
public:
	ExecutionReport report;
	EventExecutionReport();
};

class EventTradeReport : public IEventObject
{
public:
	ExecutionReport report1;
	ExecutionReport report2;

	EventTradeReport();
};

class EventSnapshotResponse : public IEventObject
{
public:
	OHLC report;
};


struct AutoHedgeSettings
{
	char szContract[20];
	int nSymbol;
	unsigned long Account;
	double Conversion;
};


class OrderResponseHandler : public IMarketEvents
{
private:
	IMarket* m_ptrMarket;
	IServerBL* m_ptrServerBL;
	IConnectionMgr* m_ptrConnectionMgr;
	IConnectionMgr* m_ptrConnectionMgrMDE;
	IDatabase* m_ptrDatabaseMgr;
	IDatabase* m_ptrDatabaseBO;
	void SendExecutionReport(EventExecutionReport* exeReport);
	void SendExecutionReport(ExecutionReport* exeReport);

	std::map<std::string, AutoHedgeSettings> m_mapAutoHedgeSettings;
	std::map<unsigned long, unsigned long> m_mapLiveAccounts;

	static unsigned long long m_orderID;
	static unsigned long long m_execID;
	static const int MASKAll = 15;
	static const int MASKOpen = 1;
	static const int MASKHigh = 2;
	static const int MASKLow = 4;
	static const int MASKClose = 8;



public:
	OrderResponseHandler(IServerBL* pServerBL,
						IMarket* pMarket,
						IConnectionMgr* pIConnectionMgr,
						IConnectionMgr* pIConnectionMgrMDE, 
						IDatabase* pDatabase,
						IDatabase* pDatabaseBO,
						GatewayClient *pClient);
	virtual ~OrderResponseHandler();
	virtual void OnEvent(IEventObject* evt);
	int CalculateOHLC(QuotesItem *item);
	int LoadAutoHedgeSettings();
	int LoadLiveAccounts();
};
