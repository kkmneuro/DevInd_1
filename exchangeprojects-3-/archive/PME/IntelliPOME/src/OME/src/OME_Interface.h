////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials			Desc
//	11 Dec 2013		BR					Ticket TradingApplication/88. Modified class CancelReplaceRequest.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////


#pragma once
#include "ServerInterface.h"
#include "datadef.h"
#include "Logger.h"

using namespace std;



class SymbolWrapper
{
private:
	Symbol* m_ptrSymbol;

public:
	SymbolWrapper(void* symbol);
	virtual ~SymbolWrapper();
	virtual Symbol* GetSymbol();
	virtual char GetProductType();
	virtual char* GetProduct(int& size);
	virtual char* GetContract(int& size); 
	virtual char* GetExchange(int& size);
	//virtual char* GertProvider(int& size);
	//virtual int GetAuthor();
	//virtual int GetIndustry();
	//virtual int	GetSector();
};

class OrderWrapper : public SymbolWrapper
{
public:
	Order* m_ptrOrder;

public:
	unsigned long long m_remainingQnty;
	OrderWrapper(void* order);
	virtual ~OrderWrapper();
	virtual Order* GetOrder();
	virtual unsigned long long GetAccount();
	virtual char* GetClOrdId(int& size);
	virtual char GetOrderType();
	virtual unsigned long long GetPrice();
	virtual unsigned long long GetOrderQnty();
	virtual char GetSide();
	virtual char GetTimeInForce();
	virtual double GetTransactTime();
	virtual char GetPositionEffect();
	virtual double GetExpireDate();
	virtual unsigned long long GetMinOrDisclosedQty();
	virtual unsigned long long GetStopPx();
	virtual unsigned long long GetOrderID();
};

class HeaderWrapper
{
private:
	StructureHeader* m_ptrHeader;
public:
	HeaderWrapper(void* header);
	virtual ~HeaderWrapper();
	virtual StructureHeader* GetHeader();
	unsigned int GetStructSize();
	char* GetBeginString(int& size);
	char* GetSenderID(int& size);
	char* GetTargetID(int& size);
	unsigned int GetMessageType();	
	double GetSendingTime();
	unsigned long long GetSeqNo();
	unsigned int GetKeyDataCtrlBlk();
};

class IMarketOrderRequest : public OrderWrapper,public HeaderWrapper
{
public:
	IMarketOrderRequest(void *msg)
		:OrderWrapper(  (void*)&(((pNewOrderRequest)msg)->order) ),
		HeaderWrapper( (void*) &(((pNewOrderRequest)msg)->Header) )

	{
	}
	virtual ~IMarketOrderRequest(){};
	virtual bool operator == (IMarketOrderRequest&)=0;
	virtual bool operator < (IMarketOrderRequest&)=0;
};

class ILimitOrderRequest : public OrderWrapper ,public HeaderWrapper
{
public:
	ILimitOrderRequest(void *msg)
		:OrderWrapper(  (void*)&(((pNewOrderRequest)msg)->order) ),
		HeaderWrapper( (void*) &(((pNewOrderRequest)msg)->Header) )
	{
	}

	ILimitOrderRequest(void *Header, void *Order)
		:OrderWrapper(  Order),
		HeaderWrapper(Header)
	{
	}
	virtual ~ILimitOrderRequest(){};
	virtual bool operator == (ILimitOrderRequest&)=0;
	virtual bool operator < (ILimitOrderRequest&)=0;
};


class IStopOrderRequest : public OrderWrapper ,public HeaderWrapper
{
public:
	IStopOrderRequest(void *msg)
		:OrderWrapper(  (void*)&(((pNewOrderRequest)msg)->order) ),
		HeaderWrapper( (void*) &(((pNewOrderRequest)msg)->Header) )
	{
	}

	IStopOrderRequest(void *Header, void *Order)
		:OrderWrapper(  Order),
		HeaderWrapper(Header)
	{
	}
	virtual ~IStopOrderRequest(){};
	virtual bool operator == (IStopOrderRequest&)=0;
	virtual bool operator < (IStopOrderRequest&)=0;
};


class ICancelOrderRequest : public OrderWrapper ,public HeaderWrapper
{
public:

	ICancelOrderRequest(void *msg)
		:OrderWrapper(  (void*)&(((pOrderCancelRequest)msg)->order) ),
		HeaderWrapper( (void*) &(((pOrderCancelRequest)msg)->Header) )
	{
	}
	virtual ~ICancelOrderRequest(){};
	virtual bool operator == (ICancelOrderRequest&)=0;
	virtual bool operator < (ICancelOrderRequest&)=0;
};

class ICancelReplaceOrderRequest : public OrderWrapper ,public HeaderWrapper
{
public:
	Order m_NewOrder;

	OrderCancelRequest *m_OrderCancelRequest;
	NewOrderRequest *m_NewOrderRequest;

	ICancelOrderRequest *m_pCancelOrderRequest;
	ILimitOrderRequest *m_pLimitOrderRequest;
	IStopOrderRequest *m_pStopOrderRequest;
	IMarketOrderRequest *m_pMarketOrderRequest;

	ICancelReplaceOrderRequest(void *msg)
		:OrderWrapper(  (void*)&(((pOrderReplaceRequest)msg)->OldOrder) ),
		HeaderWrapper( (void*) &(((pOrderReplaceRequest)msg)->Header) )
	{
		memcpy(&m_NewOrder, &((pOrderReplaceRequest)msg)->NewOrder, sizeof(m_NewOrder));
	}
	virtual ~ICancelReplaceOrderRequest(){};
	virtual bool operator == (ICancelReplaceOrderRequest&)=0;
	virtual bool operator < (ICancelReplaceOrderRequest&)=0;
};

class IMarketOrder
{
public:
	virtual ~IMarketOrder(){};
	virtual bool operator == (IMarketOrder&)=0;
	virtual bool operator < (IMarketOrder&)=0;
	virtual void AddLimitOrder(ILimitOrderRequest*)=0;
	virtual ILimitOrderRequest* CancelLimitOrder(ICancelOrderRequest*)=0;
	virtual void AddStopOrder(IStopOrderRequest*)=0;
	virtual IStopOrderRequest* CancelStopOrder(ICancelOrderRequest*)=0;
	virtual unsigned long long GetPrice()=0;
	virtual unsigned long long GetVolumn()=0;
};

typedef vector<IMarketOrder*>								MARKET_ORDER_LIST;

class IEventObject
{
public:
	virtual ~IEventObject(){};
};

class IMarketEvents
{
public:
	virtual ~IMarketEvents(){};
	//virtual void OnAddNewOrder(ILimitOrderRequest* order)=0;
	virtual void OnEvent(IEventObject* evt)=0;
};
class ITradeMarketOrder
{
public:
	virtual ~ITradeMarketOrder(){};
	virtual void ExecuteMarketOrder(IMarketOrderRequest* mOrder)=0;
	virtual void ExecuteMarketOrder(unsigned long long price, char side)=0;
};

class IMarket
{
public :
	virtual ~IMarket(){};
	virtual bool AddOrder(ILimitOrderRequest*)=0;
	virtual bool AddOrder(IStopOrderRequest*)=0;
	virtual bool CancelOrder(ICancelOrderRequest*, bool bReplace = false)=0;
	virtual void CancelReplaceOrder(ICancelReplaceOrderRequest* order) = 0;
	virtual bool AddOrder(IMarketOrderRequest*)=0;
	virtual void RegisterMarketEvents(IMarketEvents* marketEvent)=0;
	virtual ITradeMarketOrder* GetTradeMarketOrder()=0;
	virtual void SendOrderResponse(IEventObject* evtObj)=0;
	virtual virtual symbol &GetSymbol() = 0;
	virtual void SetSymbol(symbol& Symbol) = 0;
	virtual int CalculateOHLC(QuotesItem *pItem, unsigned long long& open, unsigned long long& high, unsigned long long& low, unsigned long long& prcClose)=0;
	virtual void HandleEODProcessing() = 0;
	virtual bool CheckMarketStatus(int day, struct tm& tm1) = 0;

	virtual int TriggerStopOrders(unsigned long price, char side) = 0;

	virtual int SendQuotes( unsigned long long Price,
							unsigned long long Qty,
							char type,
							symbol& Symbol,
							int marketLevel) = 0;

	virtual int SendQuotes( MARKET_ORDER_LIST& pList,
							char type,
							symbol& Symbol,
							int currentPosition) = 0;

	virtual int SendQuotes( MARKET_ORDER_LIST& pList,
							MARKET_ORDER_LIST::iterator& listIterator,
							char type,
							symbol& Symbol,
							bool bIsDepthChanged) = 0;

	virtual int SendTradeReport(ILimitOrderRequest* LimitOrder,
								IMarketOrderRequest *MarketOrder,
								unsigned long long Qty,
								unsigned long long LastPx,
								bool bRequote) = 0;

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
									unsigned long long AvgPx) = 0;


	virtual int UpdateFillReportinDB(ILimitOrderRequest* LimitOrder,
								IMarketOrderRequest *MarketOrder,
								char OrderStatus,
								char OrderStatus1,
								unsigned long long Qty,
								unsigned long long LastPx) = 0;

	virtual int UpdateOrderOnFill(unsigned long OrderID,
								char OrderStatus,
								double FillPrice,
								unsigned long long qty) = 0;


	virtual int UpdateOrderStatus(unsigned long OrderID,
								char OrderStatus) = 0;

	virtual void SendExecutionReport(ILimitOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL) = 0;

	virtual void SendExecutionReport(IStopOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL) = 0;

	virtual void SendExecutionReport(ICancelOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL) = 0;


	virtual void SendExecutionReport(IMarketOrderRequest* order,
									unsigned long OrderID,
									char execTransType,
									char orderStatus,
									char execType,
									unsigned long long Qty,
									unsigned long long CumQty,
									unsigned long long LastPx,
									unsigned long long AvgPx,
									char *reason = NULL) = 0;

	virtual int ExecuteLimitOrders(unsigned long Bid, unsigned long Ask) = 0;

	virtual void SendSnapshotResponse() = 0;

	virtual void UpdateStopOrderAsTriggered(IStopOrderRequest *pRequest) = 0;

	virtual void UpdateLimitPrice(ILimitOrderRequest *pRequest) = 0;

	virtual void UpdatePrice(QuotesItem *pItem) = 0;

	virtual unsigned long GetPrice(char type) = 0;
	virtual double GetOrderDelay() = 0;
	virtual double GetSlippage() = 0;
	virtual double GetOrderVolume() = 0;

	virtual void UpdateOHLC(unsigned int uOpen, unsigned int uHigh, unsigned int uLow, unsigned int uClose) = 0;
};
class GatewayClient;
class IOrderHandler
{
public:
	virtual ~IOrderHandler() {};
	virtual void HandleOrder(IMarketOrderRequest*, bool bAtStartup = false)=0;
	virtual void HandleOrder(ILimitOrderRequest*, bool bAtStartup = false)=0;
	virtual void HandleOrder(IStopOrderRequest*, bool bAtStartup = false)=0;
	virtual void HandleOrder(ICancelOrderRequest*)=0;
	virtual void HandleOrder(ICancelReplaceOrderRequest*)=0;
	virtual void InitializeMarket() = 0;
	virtual void RequestQuotes(GatewayClient *pClient) = 0;
	virtual void HandleSnapshotRequest(pQuoteRequest ) = 0;
	virtual void HandleEODProcessing(std::string strSymbol) = 0;
	virtual void HandlePriceUpdate(QuotesStream *pStream) = 0;
	virtual void SetMarketStatus(bool bStatus) = 0;
	virtual bool IsMarketOpen() = 0;
	virtual void HandleOrderStatusRequest(OrderStatusRequest *pRequest ) = 0;
};

