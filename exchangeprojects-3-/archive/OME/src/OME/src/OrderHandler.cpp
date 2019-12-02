///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials	Desc
//
//	11 Dec 2013		BR			Ticket TradingApplication/88. Modified fn OrderHandler::HandleOrder(ICancelReplaceOrderRequest* pRequest)
//  07 Feb 2014		BR			Ticket TradingApplication/112. Added function InitializeOHLC to load OHLC values and LTP while loading up.
//	13 Jun 2014		BR			Modified function InitializeOHLC to use the correct database to call this SP OME_GetOHLCForCurrentDay	
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "OrderHandler.h"
#include "Market.h"
#include "OrderResponseHandler.h"
#include "DatabaseInterface.h"
#include "xlogger.h"
#include "OrderRequest.h"
//#include "GatewayClient.h"


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
	m_bMarketStatus = false;

	m_ptrOrderResponseHandler=new OrderResponseHandler(pServerBL,/*m_ptrMarket*/NULL,pIConnectionMgr,pIConnectionMgrMDE,m_ptrDatabase, m_ptrDatabaseOME, pClient);
	InitializeMarket();
	InitializeOHLC();
	LoadOrderBookFromDB();

	DWORD dwThreadID = 0;
	// Create thread to review all connections
	m_handleSessionMonitor = CreateThread(NULL,
										0,
										(LPTHREAD_START_ROUTINE)&OrderHandler::SessionMonitor,
										this,
										0,
										&dwThreadID);

	if (!m_handleSessionMonitor)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::OrderHandler, Unable to create thread for Session monitor");
	}

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
	NewOrderRequest *req = (pRequest->m_NewOrderRequest);

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

			if (order->m_remainingQnty > 0)
			{
				
				if (!pMarket->AddOrder(order))
				{
					// Send rejection message
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Limit Order Request Rejection ClOrdID = %s, OrderID = %lu",
						order->m_ptrOrder->ClOrdId,
						(unsigned long)order->m_ptrOrder->OrderID);

				}
			}
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

			pMarket->GetTradeMarketOrder()->ExecuteMarketOrder(order);

			//if (order->m_remainingQnty > 0)
			//{
			//	if (!pMarket->AddOrder(order))
			//	{
			//		// Send rejection message
			//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::HandleOrder, Limit Order Request Rejection ClOrdID = %s, OrderID = %lu",
			//			order->m_ptrOrder->ClOrdId,
			//			(unsigned long)order->m_ptrOrder->OrderID);

			//	}
			//}
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

void OrderHandler::InitializeOHLC()
{
	EnterCriticalSection(&CS_MARKET_MAP);

	unsigned int                  uOpen = 0; 
    unsigned int                  uHigh = 0;                   
    unsigned int                  uLow = 0;                    
    unsigned int                  uClose = 0;      
	unsigned int                  uLTP = 0;  
	unsigned int                  uVol = 0;  

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = m_ptrDatabaseOME->Execute("OME_GetOHLCForCurrentDay",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeOHLC, Unable to execute SP OME_GetOHLCForCurrentDay");
				return ;
			}

			char contract[20];

			char szVal[2];

			while (!tb->IsEOF())
			{
				tb->Get("FK_Symbol", contract, sizeof(contract));
				tb->Get("OPEN", uOpen);
				tb->Get("HIGH", uHigh);
				tb->Get("LOW", uLow);
				tb->Get("CLOSE", uClose);
				tb->Get("LTP", uLTP);
				tb->Get("VOL", uVol);

			/*	strcpy(contract, "CPF-B-RVE-BHA");
				uOpen = 1000;
				uHigh = 1200;
				uLow = 900;
				uClose = 1100;
				uLTP = 1100;
				uVol = 7000;*/

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeOHLC, Symbol Loaded=%s, O:H:L:C=%u:%u:%u:%u, LTP %u", contract, uOpen, uHigh, uLow, uClose,uLTP);

				KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(contract) ;

				if (iter != m_MktMap.end())
				{
					IMarket *pMkt = iter->second;

					if (pMkt)
					{
						pMkt->UpdateOHLC(uOpen, uHigh, uLow, uClose, uLTP, uVol);
					}
				}

				tb->MoveNext();
			}

			ReleaseParameter(param);
		}

		ReleaseTable(tb);//release table object
	}


	LeaveCriticalSection(&CS_MARKET_MAP);
}

void OrderHandler::InitializeMarket()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Entered");

	EnterCriticalSection(&CS_MARKET_MAP);

	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	char szGateway[20] = "ECXS";
	param->AddParam("GatewayName",szGateway, sizeof(szGateway));

	bool isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Unable to execute SP Exchange_GetInstrumentInfo");
		return ;
	}

	symbol tempSymbol;
	double lfDPR = 0;

	char szVal[5];

	while (!tb->IsEOF())
	{
		tb->Get("Symbol", tempSymbol.Contract, sizeof(tempSymbol.Contract));
		tb->Get("Source", tempSymbol.Product, sizeof(tempSymbol.Product));

		tb->Get("SecurityTypeChar", szVal, sizeof(szVal));
		tempSymbol.ProductType = szVal[0];

		tb->Get("GatewayName", tempSymbol.Gateway, sizeof(tempSymbol.Gateway));
		tb->Get("DPR_Range_Higher", lfDPR);

		/*if (tempSymbol.ProductType == SECURITY_TYPE_FUT)
			strcpy(tempSymbol.Gateway, "OEC");
		else*/
			//strcpy(tempSymbol.Gateway, "DAW");
		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::InitializeMarket, Symbol Loaded=%s, Gateway = %s", tempSymbol.Contract, tempSymbol.Gateway);

		if (m_MktMap.find(tempSymbol.Contract) == m_MktMap.end())
		{
			IMarket *mkt = new Market(m_ptrDatabaseOME, m_ptrDatabase, tempSymbol, lfDPR);
			mkt->SetSymbol(tempSymbol);

			// register for events
			mkt->RegisterMarketEvents(m_ptrOrderResponseHandler);

			std::pair<std::string, IMarket*> pr(tempSymbol.Contract, mkt);
			m_MktMap.insert(pr);
		}

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

void OrderHandler::HandleEODProcessing(std::string strSymbol)
{
	KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(strSymbol);

	if (iter != m_MktMap.end())
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

DWORD OrderHandler::SessionMonitor (LPVOID lpdwThreadParam )
{
	OrderHandler *pOrderHandler = (OrderHandler *)lpdwThreadParam;

	//if (pOrderHandler)
	//{
	//	while (1)
	//	{
	//		time_t currentTime = time(0);

	//		struct tm * ptm;
	//		ptm = localtime(&currentTime);

	//		if (ptm)
	//		{
	//			if (pOrderHandler->IsMarketOpen() && ptm->tm_hour >= 19 && ptm->tm_min >= 45)
	//			{
	//				//pOrderHandler->HandleEODProcessing();
	//				pOrderHandler->SetMarketStatus(false);
	//			}

	//			if (!pOrderHandler->IsMarketOpen() && ptm->tm_hour >= 10 && ptm->tm_min >= 0)
	//			{
	//				pOrderHandler->SetMarketStatus(true);
	//			}

	//		}

	//		// Sleep for 1 minute
	//		Sleep(60000);
	//	}
	//}

	return 0L;
}


void				OrderHandler::RequestQuotes(GatewayClient *pClient)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Entered");

	m_ptrClient = pClient;
	EnterCriticalSection(&CS_MARKET_MAP);

	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	char szGateway[20] = "ECXS";
	param->AddParam("GatewayName",szGateway, sizeof(szGateway));

	bool isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Unable to execute SP Exchange_GetInstrumentInfo");
		return ;
	}

	symbol tempSymbol;

	char szVal[2];

	QuoteRequest *pRequest = (QuoteRequest *)GetMessageObject(QUOTE__REQUEST);
	int nSymbolsCount = 0;

	if (pRequest)
	{
		pRequest->isForSubscribe = true;

		while (!tb->IsEOF())
		{
			tb->Get("Symbol", tempSymbol.Contract, sizeof(tempSymbol.Contract));
			tb->Get("Source", tempSymbol.Product, sizeof(tempSymbol.Product));

			tb->Get("SecurityTypeChar", szVal, sizeof(szVal));
			tempSymbol.ProductType = szVal[0];

			/*if (tempSymbol.ProductType == SECURITY_TYPE_FUT)
				strcpy(tempSymbol.Gateway, "OEC");
			else*/
				//strcpy(tempSymbol.Gateway, "DAW");
			tb->Get("GatewayName", tempSymbol.Gateway, sizeof(tempSymbol.Gateway));
			
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Symbol Loaded=%s, Gateway = %s", tempSymbol.Contract, tempSymbol.Gateway);

			strcpy(pRequest->Symbol[nSymbolsCount].Contract, tempSymbol.Contract);
			strcpy(pRequest->Symbol[nSymbolsCount].Gateway, tempSymbol.Gateway);
			strcpy(pRequest->Symbol[nSymbolsCount].Product, tempSymbol.Product);
			pRequest->Symbol[nSymbolsCount].ProductType = tempSymbol.ProductType;

			nSymbolsCount++;

			/*if (nSymbolsCount >= MAX_SYMBOL)
			{
				pRequest->NoOfSymbols = nSymbolsCount;
				m_ptrClient->_ptrIClientProtocol->Send(m_ptrClient->_ClientID, pRequest, QUOTE__REQUEST);

				nSymbolsCount = 0;
			}*/

			tb->MoveNext();
		}

		//if (nSymbolsCount > 0)
		//{
		//	pRequest->NoOfSymbols = nSymbolsCount;
		//	m_ptrClient->_ptrIClientProtocol->Send(m_ptrClient->_ClientID, pRequest, QUOTE__REQUEST);
		//}

		free(pRequest);
	}

	ReleaseTable(tb);//release table object

	LeaveCriticalSection(&CS_MARKET_MAP);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::RequestQuotes, Exit");
}

bool OrderHandler::IsMarketOpen()
{
	return m_bMarketStatus;
}

void OrderHandler::HandleOrderStatusRequest(OrderStatusRequest *pRequest )
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	param->AddParam("ClOrdId", pRequest->ClOrdId, sizeof(pRequest->ClOrdId));
	param->AddParam("OrderId", pRequest->OrderId);

	bool isSPExist = m_ptrDatabaseOME->Execute("OME_GetOrderStatus_New",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertOrder, Unable to execute SP OMS_InsertNewOrder");
		return ;
	}

	tb->MoveFirst();
	double AvgPrice = 0;

	OrderStatusResponse* msg= (OrderStatusResponse*)GetMessageObject(ORDER_STATUS_RESPONSE);
	char szVal[100];

	if (msg)
	{
		memset(&msg->ExecutionReport, 0, sizeof(msg->ExecutionReport));

		if (tb->IsEOF())
		{
			// Order Not found
			msg->ExecutionReport.Commission = 0;
			msg->ExecutionReport.CounterAvgPx = 0;
			msg->ExecutionReport.LeavesQty = 0;

			strcpy(msg->ExecutionReport.ClOrdId, pRequest->ClOrdId);
			msg->ExecutionReport.OrderID = 0;
			msg->ExecutionReport.Account = pRequest->Account;
			msg->ExecutionReport.OrdQty = 0;
			msg->ExecutionReport.Price = 0;
			msg->ExecutionReport.StopPx = 0;
			msg->ExecutionReport.OrderStatus = ORDER_STATUS_REJECTED;
		}
		else
		{
			msg->ExecutionReport.Commission = 0;
			msg->ExecutionReport.CounterAvgPx = 0;
			msg->ExecutionReport.LeavesQty = 0;


			strcpy(msg->ExecutionReport.ClOrdId, pRequest->ClOrdId);
			tb->Get("OrderID", msg->ExecutionReport.OrderID);
			tb->Get("AccountID", msg->ExecutionReport.Account);
			tb->Get("PositionSize", msg->ExecutionReport.OrdQty);
			tb->Get("Price", msg->ExecutionReport.Price);
			tb->Get("StopPx", msg->ExecutionReport.StopPx);

			tb->Get("OrderType", szVal, sizeof(szVal));
			msg->ExecutionReport.OrderType = szVal[0];

			tb->Get("OrderStatus", szVal, sizeof(szVal));
			msg->ExecutionReport.OrderStatus = szVal[0];

			tb->Get("Side", szVal, sizeof(szVal));
			msg->ExecutionReport.Side = szVal[0];

			tb->Get("ContractName", msg->ExecutionReport.Symbol.Contract, sizeof(msg->ExecutionReport.Symbol.Contract));
			tb->Get("ProductName", msg->ExecutionReport.Symbol.Product, sizeof (msg->ExecutionReport.Symbol.Product));
			strcpy(msg->ExecutionReport.Symbol.Gateway, pRequest->Symbol.Gateway);

			tb->Get("ProductType", szVal, sizeof(szVal));
			msg->ExecutionReport.Symbol.ProductType = szVal[0];

			tb->Get("TIF", szVal, sizeof(szVal));
			msg->ExecutionReport.TimeInForce = szVal[0];

			tb->Get("FilledQty", msg->ExecutionReport.QtyFilled);
			tb->Get("AvgFillPRice", AvgPrice);
			msg->ExecutionReport.LastPx = AvgPrice;
			msg->ExecutionReport.AvgPx = msg->ExecutionReport.LastPx;
			strcpy(msg->ExecutionReport.ClOrdId, pRequest->ClOrdId);
			msg->ExecutionReport.OrderID = pRequest->OrderId;
			_ui64toa(msg->ExecutionReport.OrderID, msg->ExecutionReport.ExecID, 10);
		}

		m_ptrConnectionMgr->SendResponseToQueue(m_ptrServerBL->GetClientID(),msg,ORDER_STATUS_RESPONSE);		

		free(msg);
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void OrderHandler::SetMarketStatus(bool bStatus)
{
	m_bMarketStatus = bStatus;
}

void OrderHandler::HandleReloadDPR(ReloadDPR *pRequest)
{
	if (pRequest)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleReloadDPR, Entered");

		EnterCriticalSection(&CS_MARKET_MAP);

		// Initialize the Markets by reading all the symbols from the DB
		ITable* tb = CreateTable();
		IParameter* param = CreateParameter();

		char szGateway[20] = "ECXS";

		bool isSPExist;
		param->AddParam("GatewayName", szGateway, sizeof(szGateway));

		if (strcmp(pRequest->sym1.Contract, "*") != 0)
		{
			param->AddParam("SymbolName", pRequest->sym1.Contract, sizeof(pRequest->sym1.Contract));
			isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo_For_Symbol", *tb, *param);//execute sp
		}
		else
		{
			isSPExist = m_ptrDatabase->Execute("Exchange_GetInstrumentInfo", *tb, *param);//execute sp
		}

		if (!isSPExist)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleReloadDPR, Unable to execute SP Exchange_GetInstrumentInfo");
			return;
		}

		symbol tempSymbol;
		double lfDPR = 0;

		char szVal[5];

		while (!tb->IsEOF())
		{
			tb->Get("Symbol", tempSymbol.Contract, sizeof(tempSymbol.Contract));
			tb->Get("Source", tempSymbol.Product, sizeof(tempSymbol.Product));
			tb->Get("DPR_Range_Higher", lfDPR);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleReloadDPR, Symbol Loaded=%s, Gateway = %s", tempSymbol.Contract, tempSymbol.Gateway);

			KEY_MARKET_ORDER_MAP::iterator iter = m_MktMap.find(tempSymbol.Contract);
			if (iter != m_MktMap.end())
			{
				IMarket*& mkt = iter->second;

				if (mkt)
				{
					
					if (mkt->SetDPR(lfDPR))
					{
						mkt->GetTradeMarketOrder()->ExecuteOrders();
					}
				}
			}

			tb->MoveNext();
		}

		ReleaseTable(tb);//release table object

		LeaveCriticalSection(&CS_MARKET_MAP);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderHandler::HandleReloadDPR, Exit");

		

	}
}