#include "stdafx.h"
#include "OrderHandler.h"
#include "Market.h"
#include "OrderResponseHandler.h"
#include "DatabaseInterface.h"
#include "xlogger.h"
#include "OrderRequest.h"
#include "GatewayClient.h"


OrderHandler::OrderHandler(IServerBL* pServerBL,IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE,IDatabase* pDatabase, IDatabase* pDatabaseOME, GatewayClient *pClient)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::OrderHandler, Entered");

	InitializeCriticalSection(&CS_MARKET_MAP);

	m_ptrDatabase=pDatabase;
	m_ptrDatabaseOME = pDatabaseOME;
	m_ptrConnectionMgr= pIConnectionMgr;
	m_ptrConnectionMgrMDE=pIConnectionMgrMDE;
	m_ptrServerBL=pServerBL;
	m_ptrClient = pClient;

	m_ptrOrderResponseHandler=new OrderResponseHandler(pServerBL,/*m_ptrMarket*/NULL,pIConnectionMgr,pIConnectionMgrMDE,m_ptrDatabase, pClient);
	InitializeMarket();
	LoadOrderBookFromDB();

	//DWORD dwThreadID = 0;
	//// Create thread to review all connections
	//m_handleSessionMonitor = CreateThread(NULL,
	//									0,
	//									(LPTHREAD_START_ROUTINE)&OrderHandler::SessionMonitor,
	//									this,
	//									0,
	//									&dwThreadID);

	//if (!m_handleRMSMonitor)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::AccountMgr, Unable to create thread for RMSMonitor");
	//}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::OrderHandler, Exit");
}

OrderHandler::~OrderHandler()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::~OrderHandler, Entered");
}

void OrderHandler::InsertOrder(Order *order)
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	char OrderStatus = '0';
	int nSuccess = 0;

	param->AddParam("ClOrdID", order->ClOrdId, sizeof (order->ClOrdId));
	param->AddParam("AccountID", order->Account);
	param->AddParam("PositionSize", order->OrderQty);
	param->AddParam("Price", order->Price);
	param->AddParam("StopPx", order->StopPx);
	param->AddParam("OrderType", order->OrderType);
	param->AddParam("OrderStatusID", OrderStatus);
	param->AddParam("Side", order->Side);
	param->AddDateTimeParam("TransactTime", order->TransactTime);
	// Need to add other options also like product type, productname etc
	param->AddParam("Symbol", order->Symbol.Contract, sizeof(order->Symbol.Contract));
	param->AddParam("TIF", order->TimeInForce);
	param->AddParam("IPAddress", "192.168.1.1", 15);
	param->AddParam("DisclosedQty", order->MinOrDisclosedQty);
	param->AddDateTimeParam("ExpireDate", order->ExpireDate);
	param->AddParam("Success", nSuccess, 2);

	bool isSPExist = m_ptrDatabaseOME->Execute("OME_InsertNewOrder",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertOrder, Unable to execute SP OMS_InsertNewOrder");
		return ;
	}

	int returnVal = 0;

	tb->MoveFirst();

	while(!tb->IsEOF())//loop the table
	{
		{
			tb->Get("OrderID", order->OrderID);
		}
		tb->MoveNext();
		break;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void OrderHandler::SendAckToClient(IMarket* pMarket, ICancelReplaceOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Entered");

	if (order->GetOrderType() == ORDER_TYPE_LIMIT_ORDER)
	{
		pMarket->SendExecutionReport(order->m_pLimitOrderRequest,
									-1,
									EXECUTION_TRANSTYPE_NEW,
									ORDER_STATUS_PENDINGREPLACE,
									EXECUTION_TYPE_MODIFYACK,
									0,
									0,
									0,
									0);
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Exit");
}


void OrderHandler::SendAckToClient(IMarket* pMarket, ILimitOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Entered");

	InsertOrder(order->m_ptrOrder);

	pMarket->SendExecutionReport(order,
								-1,
								EXECUTION_TRANSTYPE_NEW,
								ORDER_STATUS_NEW,
								EXECUTION_TYPE_NEW,
								0,
								0,
								0,
								0);


//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Exit");
}

void OrderHandler::SendAckToClient(IMarket* pMarket, IStopOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Entered");

	InsertOrder(order->m_ptrOrder);

	pMarket->SendExecutionReport(order,
								-1,
								EXECUTION_TRANSTYPE_NEW,
								ORDER_STATUS_NEW,
								EXECUTION_TYPE_NEW,
								0,
								0,
								0,
								0);


//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Exit");
}

void OrderHandler::SendAckToClient(IMarket* pMarket, IMarketOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Entered");

	InsertOrder(order->m_ptrOrder);

	pMarket->SendExecutionReport(order,
								-1,
								EXECUTION_TRANSTYPE_NEW,
								ORDER_STATUS_NEW,
								EXECUTION_TYPE_NEW,
								0,
								0,
								0,
								0);


//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::SendAckToClient, Exit");
}

void OrderHandler::HandleOrder(ICancelReplaceOrderRequest* pRequest)
{
	int size = 20;

	ICancelOrderRequest* order = pRequest->m_pCancelOrderRequest;
	NewOrderRequest *req = &(pRequest->m_NewOrderRequest);

	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(order->GetContract(size));

	IMarket *pMarket = NULL;

	if (iter != m_MktMap.end())
	{
		pMarket = iter->second;
		
		if(pMarket)
		{
			pMarket->SendExecutionReport(order,
										order->GetOrderID(),
										EXECUTION_TRANSTYPE_NEW,
										ORDER_STATUS_PENDINGREPLACE,
										EXECUTION_TYPE_MODIFYACK,
										0,
										0,
										0,
										0);

			if(!pMarket->CancelOrder(order, true))
			{
				// Send rejection message
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Cancel Order Request Rejection ClOrdID = %s, OrderID = %lu",
					order->m_ptrOrder->ClOrdId,
					(unsigned long)order->m_ptrOrder->OrderID);	

				pMarket->SendExecutionReport(order,
											order->GetOrderID(),
											EXECUTION_TRANSTYPE_NEW,
											ORDER_STATUS_REJECTED,
											EXECUTION_TYPE_REJECTACK,
											0,
											0,
											0,
											0);

				if (req->order.OrderType == ORDER_TYPE_LIMIT_ORDER)
				{
					pMarket->SendExecutionReport(pRequest->m_pLimitOrderRequest,
												pRequest->m_pLimitOrderRequest->GetOrderID(),
												EXECUTION_TRANSTYPE_NEW,
												ORDER_STATUS_REJECTED,
												EXECUTION_TYPE_REJECTACK,
												0,
												0,
												0,
												0);
				}
				else if (req->order.OrderType == ORDER_TYPE_MARKET_ORDER)
				{
					pMarket->SendExecutionReport(pRequest->m_pMarketOrderRequest,
												pRequest->m_pMarketOrderRequest->GetOrderID(),
												EXECUTION_TRANSTYPE_NEW,
												ORDER_STATUS_REJECTED,
												EXECUTION_TYPE_REJECTACK,
												0,
												0,
												0,
												0);
				}
				else if (req->order.OrderType == ORDER_TYPE_STOP_ORDER ||
					req->order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
				{
					pMarket->SendExecutionReport(pRequest->m_pStopOrderRequest,
												pRequest->m_pStopOrderRequest->GetOrderID(),
												EXECUTION_TRANSTYPE_NEW,
												ORDER_STATUS_REJECTED,
												EXECUTION_TYPE_REJECTACK,
												0,
												0,
												0,
												0);
				}
			}
			else
			{
				// Place other order
				if (req->order.OrderType == ORDER_TYPE_LIMIT_ORDER)
				{
					HandleOrder(pRequest->m_pLimitOrderRequest);
				}
				else if (req->order.OrderType == ORDER_TYPE_MARKET_ORDER)
				{
					HandleOrder(pRequest->m_pMarketOrderRequest);
				}
				else if (req->order.OrderType == ORDER_TYPE_STOP_ORDER ||
					req->order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
				{
					HandleOrder(pRequest->m_pStopOrderRequest);
				}
			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Cancel Order Request: Market is NULL");
		}
	}
}

void OrderHandler::HandleOrder(IMarketOrderRequest* order, bool bAtStartup)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Market Order Request Entered");

	int size = 20;
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(order->GetContract(size));

	IMarket *pMarket = NULL;
	if (iter != m_MktMap.end())
	{
		pMarket = iter->second;

		if(!bAtStartup && pMarket)
		{
//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Send execution response with EXECUTION_TRANSTYPE_NEW");

			SendAckToClient(pMarket, order);

			pMarket->GetTradeMarketOrder()->ExecuteMarketOrder(order);
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Exit");
}




void OrderHandler::HandleOrder(ILimitOrderRequest* order, bool bAtStartup)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Limit Order Request Entered");

	int size = 20;
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(order->GetContract(size));

	IMarket *pMarket = NULL;

	if (iter != m_MktMap.end())
	{
		pMarket = iter->second;
		
		if(pMarket)
		{
			if (!bAtStartup)
				SendAckToClient(pMarket, order);

			if(!pMarket->AddOrder(order))
			{
				// Send rejection message
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Limit Order Request Rejection ClOrdID = %s, OrderID = %lu",
					order->m_ptrOrder->ClOrdId,
					(unsigned long)order->m_ptrOrder->OrderID);	

			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Limit Order Request:: Market is NULL");
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Limit Order Request Exit");
}

void OrderHandler::HandleOrder(IStopOrderRequest* order, bool bAtStartup)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Stop Order Request Entered");

	int size = 20;
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(order->GetContract(size));

	IMarket *pMarket = NULL;

	if (iter != m_MktMap.end())
	{
		pMarket = iter->second;
		
		if(pMarket)
		{
			if (!bAtStartup)
				SendAckToClient(pMarket, order);

			if(!pMarket->AddOrder(order))
			{
				// Send rejection message
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Stop Order Request Rejection ClOrdID = %s, OrderID = %lu",
					order->m_ptrOrder->ClOrdId,
					(unsigned long)order->m_ptrOrder->OrderID);	
			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Stop Order Request:: Market is NULL");
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Stop Order Request Exit");
}

void OrderHandler::HandleOrder(ICancelOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Cancel Order Request Entered");

	int size = 20;
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(order->GetContract(size));

	IMarket *pMarket = NULL;

	if (iter != m_MktMap.end())
	{
		pMarket = iter->second;
		
		if(pMarket)
		{
			pMarket->SendExecutionReport(order,
										order->GetOrderID(),
										EXECUTION_TRANSTYPE_NEW,
										ORDER_STATUS_PENDING_CANCEL,
										EXECUTION_TYPE_CANCELACK,
										0,
										0,
										0,
										0);

			if(!pMarket->CancelOrder(order))
			{
				// Send rejection message
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Cancel Order Request Rejection ClOrdID = %s, OrderID = %lu",
					order->m_ptrOrder->ClOrdId,
					(unsigned long)order->m_ptrOrder->OrderID);	

			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Cancel Order Request: Market is NULL");
		}
	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleOrder, Cancel Order Request Exit");
}



void OrderHandler::InitializeMarket()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Entered");

	EnterCriticalSection(&CS_MARKET_MAP);

	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Unable to execute SP Exchange_GetInstrumentInfo");
		return ;
	}

	symbol tempSymbol;

	strcpy(tempSymbol.Gateway, "OEC");

	char szVal[2];

	while (!tb->IsEOF())
	{
		tb->Get("Symbol", tempSymbol.Contract, sizeof(tempSymbol.Contract));
		tb->Get("Source", tempSymbol.Product, sizeof(tempSymbol.Product));

		tb->Get("SecurityTypeChar", szVal, sizeof(szVal));
		tempSymbol.ProductType = szVal[0];
		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Symbol Loaded=%s", tempSymbol.Contract);

		if (m_MktMap.find(tempSymbol.Contract) == m_MktMap.end())
		{
			IMarket *mkt = new Market(m_ptrDatabaseOME);
			mkt->SetSymbol(tempSymbol);

			// register for events
			mkt->RegisterMarketEvents(m_ptrOrderResponseHandler);

			std::pair<std::string, IMarket*> pr(tempSymbol.Contract, mkt);
			m_MktMap.insert(pr);
			}

		//QuoteRequest *pRequest = (QuoteRequest *)GetMessageObject(QUOTE__REQUEST);

		//if (pRequest)
		//{
		//	pRequest->NoOfSymbols = 1;
		//	strcpy(pRequest->Symbol[0].Contract, tempSymbol.Contract);
		//	strcpy(pRequest->Symbol[0].Gateway, "OEC");
		//	strcpy(pRequest->Symbol[0].Product, tempSymbol.Product);
		//	pRequest->Symbol[0].ProductType = tempSymbol.ProductType;

		//	//m_ptrClient->_ptrIClientProtocol->Send(m_ptrClient->_ClientID, pRequest, QUOTE__SNAPSHOT_REQUEST);

		//	if (m_ptrClient && m_ptrClient->_ptrIClientProtocol)
		//		m_ptrClient->_ptrIClientProtocol->Send(m_ptrClient->_ClientID, pRequest, QUOTE__REQUEST);
		//}

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object

	LeaveCriticalSection(&CS_MARKET_MAP);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Exit");
}

void OrderHandler::LoadOrderBookFromDB()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::LoadOrderBookFromDB, Entered");

	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = m_ptrDatabaseOME->Execute("OME_GetListOfWorkingOrders",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::LoadOrderBookFromDB, Unable to execute SP Exchange_GetInstrumentInfo");
		return ;
	}

	char szVal[2];
	bool bIsTriggered = false;

	while (!tb->IsEOF())
	{
		bIsTriggered = false;
		NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);
		
		if (pRequest)
		{
			tb->Get("ContractName", pRequest->order.Symbol.Contract, sizeof(pRequest->order.Symbol.Contract));
			tb->Get("ProductName", pRequest->order.Symbol.Product, sizeof(pRequest->order.Symbol.Product));
			tb->Get("ProductType", szVal, sizeof(szVal));
			pRequest->order.Symbol.ProductType = szVal[0];
			tb->Get("ProviderName", pRequest->order.Symbol.Gateway, sizeof(pRequest->order.Symbol.Gateway));

			tb->Get("ClOrdID", pRequest->order.ClOrdId, sizeof(pRequest->order.ClOrdId));
			tb->Get("PK_OrderID", pRequest->order.OrderID);
			tb->Get("AccountID", pRequest->order.Account);
			tb->Get("PositionSize", pRequest->order.OrderQty);
			
			tb->Get("OrderType", szVal, sizeof(szVal));
			pRequest->order.OrderType = szVal[0];

			tb->Get("Price", pRequest->order.Price);
			
			tb->Get("Side", szVal, sizeof(szVal));
			pRequest->order.Side = szVal[0];
			
			tb->Get("StopPx", pRequest->order.StopPx);
			
			tb->Get("TIF", szVal, sizeof(szVal));
			pRequest->order.TimeInForce = szVal[0];
			
			unsigned long LeavesQty = 0;;
			tb->Get("LeaveQty", LeavesQty);

			tb->Get("IsTriggered", bIsTriggered);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::LoadOrderBookFromDB, OrderID=%s", pRequest->order.ClOrdId);

			if (pRequest->order.OrderType == ORDER_TYPE_LIMIT_ORDER || pRequest->order.OrderType == ORDER_TYPE_MARKET_ORDER)
			{
				ILimitOrderRequest *OrderReq = new LimitOrderRequest((void *)&pRequest->Header,(void *)&pRequest->order, LeavesQty,  this);
				OrderReq->m_remainingQnty = LeavesQty;

				HandleOrder(OrderReq, true);
			}
			else 
			{
				IStopOrderRequest *OrderReq = new StopOrderRequest((void *)&pRequest->Header,(void *)&pRequest->order, LeavesQty,  this);
				OrderReq->m_remainingQnty = LeavesQty;

				if (bIsTriggered)
				{
					HandleOrder((ILimitOrderRequest *)OrderReq, true);
				}
				else
				{
					HandleOrder(OrderReq, true);
				}
			}

			tb->MoveNext();
		}
	}

	ReleaseTable(tb);//release table object

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::LoadOrderBookFromDB, Exit");
}

void OrderHandler::HandleSnapshotRequest(pQuoteRequest pRequest)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleSnapshotRequest, Entered");

	for (int nCount = 0;nCount < pRequest->NoOfSymbols; nCount++)
	{
		KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(pRequest->Symbol[nCount].Contract);

		IMarket *pMarket = NULL;

		if (iter != m_MktMap.end())
		{
			pMarket = iter->second;

			if (pMarket)
			{
				// Send snapshot request for the symbol
				pMarket->SendSnapshotResponse();
			}
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleSnapshotRequest, Exit");
}

void OrderHandler::HandleEODProcessing()
{
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.begin();

	for (;iter != m_MktMap.end(); iter++)
	{
		IMarket *pMarket = (*iter).second;

		if (pMarket)
		{
			pMarket->HandleEODProcessing();
		}
	}
}

void OrderHandler::HandlePriceUpdate(QuotesStream *pStream)
{
	//KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.begin();
	for (int count = 0; count < pStream->NoOfSymbols; count++)
	{
		KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(pStream->QuotesItem[count].Symbol.Contract);

		if (iter != m_MktMap.end())
		{
			IMarket *pMarket = (*iter).second;

			if (pMarket)
			{
				pMarket->UpdatePrice(&pStream->QuotesItem[count]);
			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandlePriceUpdate, unable to locate symbol = %s", pStream->QuotesItem[count].Symbol.Contract);
		}
	}
}

//DWORD OrderHandler::SessionMonitor (LPVOID lpdwThreadParam )
//{
//	OrderHandler *pOrderHandler = (OrderHandler *)lpdwThreadParam;
//
//	if (pOrderHandler)
//	{
//		while (1)
//		{
//			time_t currentTime = time(0);
//			// Sleep for 30 minutes
//			Sleep(1800000);
//		}
//	}
//
//	return 0L;
//}


void				OrderHandler::RequestQuotes(GatewayClient *pClient)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Entered");

	m_ptrClient = pClient;
	EnterCriticalSection(&CS_MARKET_MAP);

	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Unable to execute SP Exchange_GetInstrumentInfo");
		return ;
	}

	symbol tempSymbol;

	strcpy(tempSymbol.Gateway, "OEC");

	char szVal[2];

	while (!tb->IsEOF())
	{
		tb->Get("Symbol", tempSymbol.Contract, sizeof(tempSymbol.Contract));
		tb->Get("Source", tempSymbol.Product, sizeof(tempSymbol.Product));

		tb->Get("SecurityTypeChar", szVal, sizeof(szVal));
		tempSymbol.ProductType = szVal[0];
		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Symbol Loaded=%s", tempSymbol.Contract);

		QuoteRequest *pRequest = (QuoteRequest *)GetMessageObject(QUOTE__REQUEST);

		if (pRequest)
		{
			pRequest->NoOfSymbols = 1;
			strcpy(pRequest->Symbol[0].Contract, tempSymbol.Contract);
			strcpy(pRequest->Symbol[0].Gateway, "OEC");
			strcpy(pRequest->Symbol[0].Product, tempSymbol.Product);
			pRequest->Symbol[0].ProductType = tempSymbol.ProductType;
			pRequest->isForSubscribe = true;

			m_ptrClient->_ptrIClientProtocol->Send(m_ptrClient->_ClientID, pRequest, QUOTE__REQUEST);
			free(pRequest);
		}

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object

	LeaveCriticalSection(&CS_MARKET_MAP);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Exit");
}