#pragma once
#include "OME_Interface.h"
#include <list>
#include <vector>
#include <map>
#include <string>
using namespace std;


typedef list<ILimitOrderRequest*>						LIMIT_ORDER_REQUEST_LIST;
typedef list<ILimitOrderRequest*>::iterator				LIMIT_ORDER_REQUEST_LIST_ITER;
typedef vector<IMarketOrder*>::iterator					MARKET_ORDER_LIST_ITER;
typedef list<IStopOrderRequest*>						STOP_ORDER_REQUEST_LIST;
typedef list<IStopOrderRequest*>::iterator				STOP_ORDER_REQUEST_LIST_ITER;
typedef vector<IMarketOrder*>::reverse_iterator			MARKET_ORDER_LIST_REVERSE_ITER;
typedef queue<IEventObject*>							EVENT_OBJECT_QUEUE;
template<typename T> void								InsertItem( list<T>& , T );
template<typename T> int 								InsertItem( vector<T>& , T);
template<typename T> int 								InsertItemRev( vector<T>& , T);

class IDatabase;

template<class T>
class CompareRef
{
private:
	T m_obj;
public:
	CompareRef(const T& refObj);
	bool operator() (const T& refObj);
};
class TradeMarketOrder;

class MarketOrder : public IMarketOrder
{
private:
	LIMIT_ORDER_REQUEST_LIST		m_limitOrderList;
	STOP_ORDER_REQUEST_LIST			m_StopOrderList;
	//CRITICAL_SECTION				CS_LIMIT_ORDER_LIST;
	unsigned long long				m_price;
	unsigned long long				m_volumn;
public:
	CRITICAL_SECTION				CS_LIMIT_ORDER_LIST;
	CRITICAL_SECTION				CS_STOP_ORDER_LIST;
	friend class TradeMarketOrder;
	MarketOrder(ILimitOrderRequest* order);
	MarketOrder(IStopOrderRequest* order);
	MarketOrder(ICancelOrderRequest* order);
	virtual ~MarketOrder();
	virtual ILimitOrderRequest* CancelLimitOrder(ICancelOrderRequest*);
	virtual IStopOrderRequest* CancelStopOrder(ICancelOrderRequest*);
	virtual bool operator == (IMarketOrder& marketOrder);
	virtual bool operator < (IMarketOrder& marketOrder);
	virtual void AddLimitOrder(ILimitOrderRequest* order);
	virtual void AddStopOrder(IStopOrderRequest* order);
	virtual unsigned long long GetPrice();
	virtual unsigned long long GetVolumn();
	LIMIT_ORDER_REQUEST_LIST& GetLimitOrderList()
	{
		return m_limitOrderList;
	}

	STOP_ORDER_REQUEST_LIST& GetStopOrderList()
	{
		return m_StopOrderList;
	}

};

typedef struct
{
	int FromHour;
	int FromMin;
	int ToHour;
	int ToMin;
}Session;

typedef list<Session>										SESSION_LIST;

typedef struct
{
	SESSION_LIST l_Quote;
	SESSION_LIST l_Trade;
}TradeQuoteList;

typedef map<int,TradeQuoteList>								DAY_SESSION_MAP;

class Market : public IMarket
{
private:

	MARKET_ORDER_LIST										m_askList;
	MARKET_ORDER_LIST										m_bidList;
	LIMIT_ORDER_REQUEST_LIST								m_LimitOrderBook;

	// For Stop Order
	MARKET_ORDER_LIST										m_StopAskList;
	MARKET_ORDER_LIST										m_StopBidList;
	STOP_ORDER_REQUEST_LIST									m_StopOrderBook;

	typedef vector<IMarketEvents*>							MARKET_LISTINER;
	typedef vector<IMarketEvents*>::iterator				MARKET_LISTINER_ITER;
	MARKET_LISTINER											m_marketlistiner;
	
	CRITICAL_SECTION										CS_ASK_LIST;
	CRITICAL_SECTION										CS_BID_LIST;
	CRITICAL_SECTION										CS_LIMIT_ORDER_BOOK;

	CRITICAL_SECTION										CS_STOP_ASK_LIST;
	CRITICAL_SECTION										CS_STOP_BID_LIST;
	CRITICAL_SECTION										CS_STOP_ORDER_BOOK;

	CRITICAL_SECTION										CS_MARKET_LISTINER;
	CRITICAL_SECTION										CS_OHLC;

	OHLC													m_OHLCStats;
	//std::string												m_contractName;
	symbol													m_Symbol;
	IDatabase*												m_pDatabase;
	IDatabase*												m_pDatabaseBO;

	bool													m_bMarketOpen;

	CRITICAL_SECTION										CS_CurrentPrice;
	unsigned long											m_ulLTP;
	unsigned long											m_ulBid;
	unsigned long											m_ulAsk;

	double													m_OrderDelay;
	double													m_Slippage;
	double													m_OrderVolume;

	DAY_SESSION_MAP											m_mapTradeSession;

	void AddAsk(ILimitOrderRequest* order);
	void AddBid(ILimitOrderRequest* order);
	void AddOrderToSymbol(ILimitOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type);

	void AddAsk(IStopOrderRequest* order);
	void AddBid(IStopOrderRequest* order);
	void AddOrderToSymbol(IStopOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type);

	bool CancelAsk(ICancelOrderRequest* order, bool bReplace = false);
	bool CancelBid(ICancelOrderRequest* order, bool bReplace = false);
	bool CancelOrderToSymbol(ICancelOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type, bool bReplace = false);

	bool CancelStopAsk(ICancelOrderRequest* order, bool bReplace = false);
	bool CancelStopBid(ICancelOrderRequest* order, bool bReplace = false);
	bool CancelStopOrderToSymbol(ICancelOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type, bool bReplace = false);

	void CancelReplaceOrder(ICancelReplaceOrderRequest* order);
	void ExpireOrders(MARKET_ORDER_LIST& list);
	void ExpireStopOrders(MARKET_ORDER_LIST& list);

	void GetSession(char* Sessiontime,char* TradeSession, TradeQuoteList& o_TradeQuoteList);
	void GetSessionList(IDatabase *pDatabase, char *szSymbol);
	bool ValidateCurrentSession(std::string symbol, bool bTrade);

	virtual bool CheckMarketStatus(int day, struct tm& tm1);

	virtual void HandleEODProcessing();
	void ResetOHLCStats();
	void SendNULLMarketData();

	
	EVENT_OBJECT_QUEUE				m_eventOjectQueue;
	CRITICAL_SECTION				CS_EVENT_OBJECT_QUEUE;
	HANDLE							m_hEventOjectQueue;
	HANDLE							m_hRaiseMarketEventThread;
	volatile int					m_dispatchMarketEvent;
	static unsigned int _stdcall RaiseMarketEvent(void* arg);

	ITradeMarketOrder* m_ptrTradeMarketOrder;

public:
	friend class TradeMarketOrder;
	Market(IDatabase* pDatabase, IDatabase *pDatabaseBO, Symbol sym);
	virtual ~Market();
	virtual bool AddOrder(ILimitOrderRequest*);
	virtual bool AddOrder(IStopOrderRequest*);
	virtual bool AddOrder(IMarketOrderRequest*);
	virtual bool CancelOrder(ICancelOrderRequest*, bool bReplace = false);
	virtual void RegisterMarketEvents(IMarketEvents* marketEvent);
	virtual ITradeMarketOrder* GetTradeMarketOrder();
	virtual void SendOrderResponse(IEventObject* evtObj);
	virtual symbol &GetSymbol();
	virtual void SetSymbol(symbol& Symbol);
	virtual void UpdateStopOrderAsTriggered(IStopOrderRequest *pRequest);
	virtual void UpdateLimitPrice(ILimitOrderRequest *pRequest);

	int TriggerStopOrders(unsigned long price, char side);
	int ExecuteLimitOrders(unsigned long Bid, unsigned long Ask);

	virtual int CalculateOHLC(QuotesItem *pItem, 
								unsigned long long& open, 
								unsigned long long& high, 
								unsigned long long& low, 
								unsigned long long& prcClose);

	virtual int SendQuotes( MARKET_ORDER_LIST& pList,
							char type,
							symbol& Symbol,
							int currentPosition);

	virtual int SendQuotes(unsigned long long Price,
							unsigned long long Qty,
							char type,
							symbol& Symbol,
							int marketLevel);

	virtual int SendQuotes( MARKET_ORDER_LIST& pList,
							MARKET_ORDER_LIST::iterator& listIterator,
							char type,
							symbol& Symbol,
							bool bIsDepthChanged);


	virtual int SendTradeReport(ILimitOrderRequest* LimitOrder,
							IMarketOrderRequest *MarketOrder,
							unsigned long long Qty,
							unsigned long long LastPx,
							bool bRequote);

	virtual int UpdateFillReportinDB(ILimitOrderRequest* LimitOrder,
								IMarketOrderRequest *MarketOrder,
								char OrderStatus,
								char OrderStatus1,
								unsigned long long Qty,
								unsigned long long LastPx);

	virtual int UpdateOrderOnFill(unsigned long OrderID,
									char OrderStatus,
									double FillPrice,
									unsigned long long qty);
					

	virtual int UpdateOrderStatus(unsigned long OrderID,
									char OrderStatus);


	virtual void SendExecutionReport(ILimitOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL);

	virtual void SendExecutionReport(IStopOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL);

	virtual void SendExecutionReport(ICancelOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL);

	virtual void SendExecutionReport(IMarketOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL);

	virtual int SendTradeReport(ILimitOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									IMarketOrderRequest* order1,
									unsigned long OrderID1,
									char execTransType1,
									char orderStatus1,
									char execType1,
									unsigned long long LastPx,
									unsigned long long AvgPx);									


	virtual void SendSnapshotResponse();

	virtual void UpdatePrice(QuotesItem *pItem);

	virtual unsigned long GetPrice(char type);
	virtual double GetOrderDelay();
	virtual double GetSlippage();
	virtual double GetOrderVolume();


	static const int MASKAll = 15;
	static const int MASKOpen = 1;
	static const int MASKHigh = 2;
	static const int MASKLow = 4;
	static const int MASKClose = 8;


	void UpdateOHLC(unsigned int uOpen, unsigned int uHigh, unsigned int uLow, unsigned int uClose);
};

class TradeMarketOrder : public ITradeMarketOrder
{
private:
	Market* m_ptrMarket;
	void UpdateOrder(unsigned long long price,ILimitOrderRequest* existingOrder,unsigned long long& qntyExecuted);
	void MatchOrder(LIMIT_ORDER_REQUEST_LIST& limitOrderList,unsigned long long price, unsigned long long& qntyExecuted);
	void ExecuteBuyOrder(IMarketOrderRequest* mOrder);
	void ExecuteSellOrder(IMarketOrderRequest* mOrder);
	void ExecuteBuyOrder(unsigned long long price);
	void ExecuteSellOrder(unsigned long long price);
	void ExecuteMarketOrder(unsigned long long price, char side);

public:
	TradeMarketOrder(Market* pMarket);
	~TradeMarketOrder();
	virtual void ExecuteMarketOrder(IMarketOrderRequest* mOrder);

};


