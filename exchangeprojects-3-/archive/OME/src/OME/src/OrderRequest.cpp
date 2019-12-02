////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials	Desc
//
//	11 Dec 2013		BR			Ticket TradingApplication/88. Modified constructor and descturctor/AutoDelete functions
//
///////////////////////////////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "OrderRequest.h"
#include "xlogger.h"

SymbolWrapper::SymbolWrapper(void* symbol)
{
	m_ptrSymbol=(Symbol*)symbol;
}

SymbolWrapper::~SymbolWrapper()
{
}

Symbol* SymbolWrapper::GetSymbol()
{
	return m_ptrSymbol;
}

char SymbolWrapper::GetProductType()
{
	return m_ptrSymbol->ProductType;
}
char* SymbolWrapper::GetProduct(int& size)
{
	size=20;
	return m_ptrSymbol->Product;
}
	
char* SymbolWrapper::GetContract(int& size)
{
	size=20;
	return m_ptrSymbol->Contract;
}

char* SymbolWrapper::GetExchange(int& size)
{
	size=20;
	return m_ptrSymbol->Gateway;
}

//char* SymbolWrapper::GertProvider(int& size)
//{
//	size=20;
//	return m_ptrSymbol->Provider;
//}

//int SymbolWrapper::GetAuthor()
//{
//	return m_ptrSymbol->author;
//}
//
//int SymbolWrapper::GetIndustry()
//{
//	return m_ptrSymbol->industry;
//}
//
//int	SymbolWrapper::GetSector()
//{
//	return m_ptrSymbol->sector;
//}

OrderWrapper::OrderWrapper(void* order)
:SymbolWrapper( (void*) &(((Order*)order)->Symbol) )
{
	m_ptrOrder=(Order*)order;
}

OrderWrapper::~OrderWrapper()
{
}

unsigned long long OrderWrapper::GetOrderID()
{
	return m_ptrOrder->OrderID;
}

Order* OrderWrapper::GetOrder()
{
	return m_ptrOrder;
}

unsigned long long OrderWrapper::GetAccount()
{
	return m_ptrOrder->Account;
}

char* OrderWrapper::GetClOrdId(int& size)
{
	size=20;
	return m_ptrOrder->ClOrdId;
}

char OrderWrapper::GetOrderType()
{
	return m_ptrOrder->OrderType;
}

unsigned long long OrderWrapper::GetPrice()
{
	return m_ptrOrder->Price;
}

unsigned long long OrderWrapper::GetOrderQnty()
{
	return m_ptrOrder->OrderQty;
}

char OrderWrapper::GetSide()
{
	return m_ptrOrder->Side;
}

char OrderWrapper::GetTimeInForce()
{
	return m_ptrOrder->TimeInForce;
}

double OrderWrapper::GetTransactTime()
{
	return m_ptrOrder->TransactTime;
}

char OrderWrapper::GetPositionEffect()
{
	return m_ptrOrder->PositionEffect;
}

double OrderWrapper::GetExpireDate()
{
	return m_ptrOrder->ExpireDate;
}

unsigned long long OrderWrapper::GetMinOrDisclosedQty()
{
	return m_ptrOrder->MinOrDisclosedQty;
}

unsigned long long OrderWrapper::GetStopPx()
{
	return m_ptrOrder->StopPx;
}

HeaderWrapper::HeaderWrapper(void* header)
{
	m_ptrHeader=(StructureHeader*)header;
}

HeaderWrapper::~HeaderWrapper()
{
}

StructureHeader* HeaderWrapper::GetHeader()
{
	return m_ptrHeader;
}

unsigned int HeaderWrapper::GetStructSize()
{
	return m_ptrHeader->StructSize;

}

char* HeaderWrapper::GetBeginString(int& size)
{
	size=4;
	return m_ptrHeader->BeginString;
}

char* HeaderWrapper::GetSenderID(int& size)
{
	size=5;
	return m_ptrHeader->SenderID;
}

char* HeaderWrapper::GetTargetID(int& size)
{
	size=5;
	return m_ptrHeader->TargetID;
}

unsigned int HeaderWrapper::GetMessageType()
{
	return m_ptrHeader->MessageType;
}

double HeaderWrapper::GetSendingTime()
{
	return m_ptrHeader->SendingTime;
}

unsigned long long HeaderWrapper::GetSeqNo()
{
	return m_ptrHeader->SeqNo;
}

unsigned int HeaderWrapper::GetKeyDataCtrlBlk()
{
	return m_ptrHeader->KeyDataCtrlBlk;
}

MarketOrderRequest::MarketOrderRequest(void *msg,IOrderHandler* pOrderHandler)
	:IMarketOrderRequest(msg)
{
	m_ptrNewOrderReq = (pNewOrderRequest)msg;
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = m_ptrNewOrderReq->order.OrderQty;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrderRequest::MarketOrderRequest");
}

MarketOrderRequest::~MarketOrderRequest()
{
	delete m_ptrNewOrderReq;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrderRequest::~MarketOrderRequest");
}

void MarketOrderRequest::Run()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrderRequest::Run, Entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrder(this);

		if (m_remainingQnty == 0)
			delete this;
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrderRequest::Run, Exit");
}

bool MarketOrderRequest::AutoDelete()
{
	// The market order request can be deleted as it is not stored in any list and executed immediately
	return false;
}

bool MarketOrderRequest::operator == (IMarketOrderRequest& order)
{
	return (GetSendingTime() == order.GetSendingTime());
}

bool MarketOrderRequest::operator < (IMarketOrderRequest& order)
{
	return (GetSendingTime() < order.GetSendingTime());
}

LimitOrderRequest::LimitOrderRequest(void *msg,IOrderHandler* pOrderHandler)
	:ILimitOrderRequest(msg)
{
	m_ptrNewOrderReq = (pNewOrderRequest)msg;
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = m_ptrNewOrderReq->order.OrderQty;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "LimitOrderRequest::LimitOrderRequest");
}

LimitOrderRequest::LimitOrderRequest(void* Header, void *Order1,unsigned long remainingQty, IOrderHandler* pOrderHandler)
	:ILimitOrderRequest(Header, Order1)
{
	m_ptrNewOrderReq = (pNewOrderRequest)GetMessageObject(NEW_ORDER_REQUEST);
	memcpy(&m_ptrNewOrderReq->Header, Header, sizeof(m_ptrNewOrderReq->Header));
	memcpy(&m_ptrNewOrderReq->order, Order1, sizeof(m_ptrNewOrderReq->order));
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = remainingQty;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "LimitOrderRequest::LimitOrderRequest with Header and Order");
}

LimitOrderRequest::~LimitOrderRequest()
{
	delete m_ptrNewOrderReq;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "LimitOrderRequest::~LimitOrderRequest");
}

void LimitOrderRequest::Run()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "LimitOrderRequest::Run, entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrder(this);
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "LimitOrderRequest::Run, Exit");
}

bool LimitOrderRequest::AutoDelete()
{
	return false;
}

bool LimitOrderRequest::operator == (ILimitOrderRequest& order)
{
	return (GetSendingTime() == order.GetSendingTime());
}

bool LimitOrderRequest::operator < (ILimitOrderRequest& order)
{
	return (GetSendingTime() < order.GetSendingTime());
}

//////////////////////////////////////////////////////////////////////////////////////////////
// LimitOrderRequest Starts
StopOrderRequest::StopOrderRequest(void *msg,IOrderHandler* pOrderHandler)
	:IStopOrderRequest(msg)
{
	m_ptrNewOrderReq = (pNewOrderRequest)msg;
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = m_ptrNewOrderReq->order.OrderQty;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StopOrderRequest::StopOrderRequest");
}

StopOrderRequest::StopOrderRequest(void* Header, void *Order1,unsigned long remainingQty, IOrderHandler* pOrderHandler)
	:IStopOrderRequest(Header, Order1)
{
	m_ptrNewOrderReq = (pNewOrderRequest)GetMessageObject(NEW_ORDER_REQUEST);
	memcpy(&m_ptrNewOrderReq->Header, Header, sizeof(m_ptrNewOrderReq->Header));
	memcpy(&m_ptrNewOrderReq->order, Order1, sizeof(m_ptrNewOrderReq->order));
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = remainingQty;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StopOrderRequest::StopOrderRequest with Header and Order");
}

StopOrderRequest::~StopOrderRequest()
{
	delete m_ptrNewOrderReq;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StopOrderRequest::~StopOrderRequest");
}

void StopOrderRequest::Run()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StopOrderRequest::Run, entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrder(this);
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "StopOrderRequest::Run, Exit");
}

bool StopOrderRequest::AutoDelete()
{
	return false;
}

bool StopOrderRequest::operator == (IStopOrderRequest& order)
{
	return (GetSendingTime() == order.GetSendingTime());
}

bool StopOrderRequest::operator < (IStopOrderRequest& order)
{
	return (GetSendingTime() < order.GetSendingTime());
}

// LimitOrderRequest Ends
//////////////////////////////////////////////////////////////////////////////////////////////

CancelOrderRequest::CancelOrderRequest(void *msg,IOrderHandler* pOrderHandler)
	:ICancelOrderRequest(msg)
{
	m_ptrOrderCancelReq = (pOrderCancelRequest)msg;
	m_ptrOrderHandler = pOrderHandler;
	m_remainingQnty = m_ptrOrderCancelReq->order.OrderQty;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelOrderRequest::CancelOrderRequest");
}

CancelOrderRequest::~CancelOrderRequest()
{
	delete m_ptrOrderCancelReq;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelOrderRequest::~CancelOrderRequest");
}

void CancelOrderRequest::Run()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelOrderRequest::Run, Entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrder(this);
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelOrderRequest::Run, Exit");
}

bool CancelOrderRequest::AutoDelete()
{
	// This request can be deleted as soon as the order is canceled
	return true;
}

bool CancelOrderRequest::operator == (ICancelOrderRequest& order)
{
	return (GetSendingTime() == order.GetSendingTime());
}

bool CancelOrderRequest::operator < (ICancelOrderRequest& order)
{
	return (GetSendingTime() < order.GetSendingTime());
}


CancelReplaceOrderRequest::CancelReplaceOrderRequest(void *msg,IOrderHandler* pOrderHandler)
	:ICancelReplaceOrderRequest(msg)
{
	m_ptrOrderReplaceReq = (pOrderReplaceRequest)msg;
	m_ptrOrderHandler = pOrderHandler;
	m_pLimitOrderRequest = NULL;
	m_pMarketOrderRequest = NULL;

	m_OrderCancelRequest = (OrderCancelRequest *)GetMessageObject(ORDER_CANCEL_REQUEST);
	m_NewOrderRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

	if (m_OrderCancelRequest && m_NewOrderRequest)
	{
		memcpy(&m_OrderCancelRequest->Header, &m_ptrOrderReplaceReq->Header, sizeof(m_ptrOrderReplaceReq->Header));
		memcpy(&m_NewOrderRequest->Header, &m_ptrOrderReplaceReq->Header, sizeof(m_ptrOrderReplaceReq->Header));

		memcpy(&m_OrderCancelRequest->order, &m_ptrOrderReplaceReq->OldOrder, sizeof(m_ptrOrderReplaceReq->OldOrder));
		memcpy(&m_NewOrderRequest->order, &m_ptrOrderReplaceReq->NewOrder, sizeof(m_ptrOrderReplaceReq->NewOrder));

		m_pCancelOrderRequest = new CancelOrderRequest(m_OrderCancelRequest, m_ptrOrderHandler);
		
		if (m_NewOrderRequest->order.OrderType == ORDER_TYPE_LIMIT_ORDER)
		{
			m_pLimitOrderRequest = new LimitOrderRequest(m_NewOrderRequest, m_ptrOrderHandler);
		}
		else if (m_NewOrderRequest->order.OrderType == ORDER_TYPE_MARKET_ORDER)
		{
			m_pMarketOrderRequest = new MarketOrderRequest(m_NewOrderRequest, m_ptrOrderHandler);
		}
		else if (m_NewOrderRequest->order.OrderType == ORDER_TYPE_STOP_ORDER ||
			m_NewOrderRequest->order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
		{
			m_pStopOrderRequest = new StopOrderRequest(m_NewOrderRequest, m_ptrOrderHandler);
		}
	}
	else
	{
		// Memory Error
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelReplaceOrderRequest::CancelReplaceOrderRequest");
}

CancelReplaceOrderRequest::~CancelReplaceOrderRequest()
{
	free( m_ptrOrderReplaceReq);
	//delete m_pCancelOrderRequest;
	
	/*if (m_pLimitOrderRequest)
		delete m_pLimitOrderRequest;*/

	if (m_pMarketOrderRequest)
		delete m_pMarketOrderRequest;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelReplaceOrderRequest::~CancelReplaceOrderRequest");
}

void CancelReplaceOrderRequest::Run()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelReplaceOrderRequest::Run, Entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrder(this);
		//m_ptrOrderHandler->HandleOrder(m_pCancelOrderRequest);

		//if (m_NewOrderRequest.order.OrderType == ORDER_TYPE_LIMIT_ORDER)
		//{
		//	m_ptrOrderHandler->HandleOrder(m_pLimitOrderRequest);
		//}
		//else if (m_NewOrderRequest.order.OrderType == ORDER_TYPE_MARKET_ORDER)
		//{
		//	m_ptrOrderHandler->HandleOrder(m_pMarketOrderRequest);
		//}
		//else if (m_NewOrderRequest.order.OrderType == ORDER_TYPE_STOP_ORDER ||
		//	m_NewOrderRequest.order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
		//{
		//	m_ptrOrderHandler->HandleOrder(m_pStopOrderRequest);
		//}

	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "CancelReplaceOrderRequest::Run, Exit");
}

bool CancelReplaceOrderRequest::AutoDelete()
{
	return true;
}

bool CancelReplaceOrderRequest::operator == (ICancelReplaceOrderRequest& order)
{
	return (GetSendingTime() == order.GetSendingTime());
}

bool CancelReplaceOrderRequest::operator < (ICancelReplaceOrderRequest& order)
{
	return (GetSendingTime() < order.GetSendingTime());
}



OrderStatusReq::OrderStatusReq(void *msg,IOrderHandler* pOrderHandler)
{
	m_pOrderStatusRequest = (OrderStatusRequest *)msg;
	m_ptrOrderHandler = pOrderHandler;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderStatusReq::SnapshotRequest");
}

OrderStatusReq::~OrderStatusReq()
{
	delete m_pOrderStatusRequest;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderStatusReq::~SnapshotRequest");
}

void OrderStatusReq::Run()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderStatusReq::Run, Entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleOrderStatusRequest(m_pOrderStatusRequest);
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderStatusReq::Run, Exit");
}

bool OrderStatusReq::AutoDelete()
{
	return true;
}
