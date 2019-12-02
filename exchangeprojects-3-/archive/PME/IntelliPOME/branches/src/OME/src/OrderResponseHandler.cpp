#include "stdafx.h"
#include "OrderResponseHandler.h"
#include "xlogger.h"
#include "AsyncPipes2.h"

//#include "GatewayClient.h"

LimitOrderResponse::LimitOrderResponse(ILimitOrderRequest* order)
{
	m_ptrOrder=order;
}

ILimitOrderRequest* LimitOrderResponse::GetOrder()
{
	return m_ptrOrder;
}


MarketOrderResponse::MarketOrderResponse(IMarketOrderRequest* order)
{
	m_ptrOrder=order;
}

IMarketOrderRequest* MarketOrderResponse::GetOrder()
{
	return m_ptrOrder;
}

EventExecutionReport::EventExecutionReport()
{
	//m_ptrOrder=order;
}

EventTradeReport::EventTradeReport()
{
	//m_ptrOrder=order;
}

unsigned long long OrderResponseHandler::m_orderID=0;
unsigned long long OrderResponseHandler::m_execID=0;

OrderResponseHandler::OrderResponseHandler(IServerBL* pServerBL,IMarket* pMarket,IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE, IDatabase* pDatabase, GatewayClient *pClient)
{
	m_ptrDatabaseMgr=pDatabase;
	m_ptrConnectionMgr = pIConnectionMgr;
	m_ptrConnectionMgrMDE = pIConnectionMgrMDE;
	m_ptrServerBL=pServerBL;
	m_pClient = pClient;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::OrderResponseHandler");
}

OrderResponseHandler::~OrderResponseHandler()
{
}


int OrderResponseHandler::CalculateOHLC(QuotesItem *item)
{
	int nValChanged = 0;

	//if (

	return nValChanged;
}

void OrderResponseHandler::OnEvent(IEventObject* evt)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::OnEvent, Entered");

	///////TriggerStopEvent
	TriggerStopOrderEvent *reqTriggerStop = dynamic_cast<TriggerStopOrderEvent*>(evt);

	if (reqTriggerStop)
	{
		IMarket *market = reqTriggerStop->m_pMarket;

		if (market)
		{
			IStopOrderRequest *pRequest = reqTriggerStop->GetOrder();

			if (pRequest)
			{
				market->UpdateStopOrderAsTriggered(pRequest);
				// Update order as triggered order
				if (pRequest->GetStopPx() != 0)
				{
					pRequest->m_ptrOrder->Price = pRequest->GetStopPx();

					market->AddOrder((ILimitOrderRequest *)pRequest);
				}
				else
					market->GetTradeMarketOrder()->ExecuteMarketOrder((IMarketOrderRequest *)pRequest);
			}
		}

		//delete reqTriggerStop;
	}

	////////////////////////

	//QuotesStreamResponse* reqQuotesStream=dynamic_cast<QuotesStreamResponse*>(evt);

	//
	//if (reqQuotesStream)
	//{
	//	IMarket *market = reqQuotesStream->m_Market;

	//	QuotesStream* msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
	//	
	//	std::list<QuotesItem>::iterator iter;

	//	int nCount = 0;
	//	for (iter = reqQuotesStream->m_Quotes.begin(); iter != reqQuotesStream->m_Quotes.end(); iter++)
	//	{
	//		//memcpy(&msg->QuotesItem[nCount], (void *)*iter, sizeof(QuotesItem));
	//		msg->QuotesItem[nCount] = *iter;

	//		if (msg->QuotesItem[nCount].QuotesStreamType == QUOTES_STREAM_TYPE_LAST)
	//		{
	//			
	//			unsigned long long high, low, open, prcClose;
	//			int val = market->CalculateOHLC(&msg->QuotesItem[nCount], open, high, low, prcClose);

	//			nCount++;
	//			if (val & MASKOpen)
	//			{
	//				msg->QuotesItem[nCount].MarketLevel = 0;
	//				msg->QuotesItem[nCount].Price = open;
	//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
	//				msg->QuotesItem[nCount].Size = 0;
	//				memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
	//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
	//				
	//				msg->QuotesItem[nCount].Time = 0;

	//				nCount ++;

	//				if (nCount >= MAX_QUOTES_ITEM)
	//				{
	//					// Send and reset the object
	//					msg->NoOfSymbols = nCount;
	//					m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
	//					nCount = 0;
	//					msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
	//				}
	//			}

	//			if (val & MASKHigh)
	//			{
	//				msg->QuotesItem[nCount].MarketLevel = 0;
	//				msg->QuotesItem[nCount].Price = high;
	//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
	//				msg->QuotesItem[nCount].Size = 0;
	//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
	//				memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
	//				msg->QuotesItem[nCount].Time = 0;

	//				nCount ++;

	//				if (nCount >= MAX_QUOTES_ITEM)
	//				{
	//					// Send and reset the object
	//					msg->NoOfSymbols = nCount;
	//					m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
	//					free(msg);
	//					nCount = 0;
	//					msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
	//				}
	//			}

	//			if (val & MASKLow)
	//			{
	//				msg->QuotesItem[nCount].MarketLevel = 0;
	//				msg->QuotesItem[nCount].Price = low;
	//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
	//				msg->QuotesItem[nCount].Size = 0;
	//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
	//				memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
	//				msg->QuotesItem[nCount].Time = 0;

	//				nCount ++;
	//			}

	//			if (nCount >= MAX_QUOTES_ITEM)
	//			{
	//				// Send and reset the object
	//				msg->NoOfSymbols = nCount;
	//				m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
	//				free(msg);
	//				nCount = 0;
	//				msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
	//			}

	//			market->TriggerStopOrders((*iter).Price);
	//		}

	//		nCount ++;

	//	}

	//	if (nCount > 0)
	//	{
	//		msg->NoOfSymbols = nCount;
	//		m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
	//	}
	//}

	////////////////////////////////////////////////////////////////////////////////////////////////////
	/*EventSnapshotResponse* reqOHLC=dynamic_cast<EventSnapshotResponse*>(evt);

	
	if (reqOHLC)
	{
		QuotesSnapshotResponse* msg= (QuotesSnapshotResponse*)GetMessageObject(QUOTE_SNAP_SHOT_RESPONSE);

		memcpy(&msg->OHLC, &reqOHLC->report, sizeof(reqOHLC->report));

		msg->NoOfSymbols = 1;
		m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTE_SNAP_SHOT_RESPONSE);
	}*/

	///////////////////////////////////////////////////////////////////////////////////////////////////

	EventExecutionReport* reqExecutionReport=dynamic_cast<EventExecutionReport*>(evt);
	if(reqExecutionReport)
	{
		//EventExecutionReport evtRpt(reqExecutionReport->m_ptrOrder);
		SendExecutionReport(reqExecutionReport);
	}

	//EventTradeReport* reqTradeReport = dynamic_cast<EventTradeReport*>(evt);
	//if (reqTradeReport)
	//{
	//	SendExecutionReport(&reqTradeReport->report1);
	//	SendExecutionReport(&reqTradeReport->report2);

	//	TradeReport *pReport = (TradeReport*)GetMessageObject(TRADEREPORT_REQUEST);

	//	if (pReport)
	//	{
	//		memcpy(&pReport->FirstOrder, &reqTradeReport->report1, sizeof(ExecutionReport));
	//		memcpy(&pReport->SecondOrder, &reqTradeReport->report2, sizeof(ExecutionReport));

	//		//m_pClient->_ptrIClientProtocol->Send(m_pClient->_ClientID, pReport, TRADEREPORT_REQUEST);

	//		free (pReport);
	//	}
	//}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::OnEvent, Exit");	

	delete evt;
}

OVERLAPPED olp;
CXEvent eventTransact;

struct MQLOrder
{
	int symbol;
	float qty;
	char side;
};

void OrderResponseHandler::SendExecutionReport(EventExecutionReport* exeReport)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Entered");	

	OrderStatusResponse* msg= (OrderStatusResponse*)GetMessageObject(ORDER_STATUS_RESPONSE);
	memcpy(&msg->ExecutionReport,&exeReport->report,sizeof(ExecutionReport));
	
	//msg->ExecutionReport.OrderID=OrderResponseHandler::m_orderID++;
	//sprintf_s( msg->ExecutionReport.ExecID,40,"%I64u",msg->ExecutionReport.OrderID);
	_ui64toa(msg->ExecutionReport.OrderID, msg->ExecutionReport.ExecID, 10);

	// Send order to PIPE for sending order for hedging
	if (exeReport->report.OrderStatus == ORDER_STATUS_FILLED)/* && 
		(exeReport->report.Account ==   79 ||
		exeReport->report.Account ==   86 ||
		exeReport->report.Account ==   97 ||
		exeReport->report.Account ==   96 ||
		exeReport->report.Account ==   98))*/
	{
		MQLOrder mqlOrder;
		int AccountNo = 0;

		if (strcmp(exeReport->report.Symbol.Contract, "GOLDOCT12") == 0)
		{
			mqlOrder.symbol = 1;
			AccountNo = 133688;
			//AccountNo = 5188;
			mqlOrder.qty = exeReport->report.QtyFilled * 0.30;
			//mqlOrder.qty = exeReport->report.QtyFilled * 0.33;
		}
		else if (strcmp(exeReport->report.Symbol.Contract, "SILVEROCT12") == 0)
		{
			mqlOrder.symbol = 2;
			AccountNo = 133687;
			//AccountNo = 5214;
			mqlOrder.qty = exeReport->report.QtyFilled * 0.20;
			//mqlOrder.qty = exeReport->report.QtyFilled * 0.19;
		}
		else if (strcmp(exeReport->report.Symbol.Contract, "CRUDEOILOCT12") == 0)
		{
			mqlOrder.symbol = 3;
			AccountNo = 133689;
			//AccountNo = 5217;
			mqlOrder.qty = exeReport->report.QtyFilled * 0.10;
			//mqlOrder.qty = exeReport->report.QtyFilled * 0.10;
		}

		if (exeReport->report.Side == SIDE_BUY)
		{
			mqlOrder.side = 'B';
		}
		else
			mqlOrder.side = 'S';

		HANDLE hPipe;

		memset(&olp, 0, sizeof(olp));
		olp.hEvent = eventTransact.GetEvent();

		std::string pipeName = "\\\\.\\pipe\\";

		TCHAR szPipeName[100];
		wsprintf(szPipeName, _T("MT5%d"), AccountNo);
		pipeName.append(szPipeName);

		DWORD dwWrittenBytes = 0;
		if ((hPipe = CreateFile(pipeName.c_str(),
					GENERIC_READ |
					GENERIC_WRITE,
					FILE_SHARE_READ | FILE_SHARE_WRITE,
					NULL,
					OPEN_EXISTING,
					FILE_FLAG_OVERLAPPED,
					NULL)) == INVALID_HANDLE_VALUE)
		{
			DWORD error = GetLastError();
		}

		bool success = WriteFile(hPipe,
			(void *)&mqlOrder,
			sizeof(mqlOrder),
			&dwWrittenBytes,
			&olp);

		if (success == true)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Autohedge order sent for OrderID = %s", exeReport->report.ClOrdId);
		}
	}

	m_ptrConnectionMgr->SendResponseToQueue(m_ptrServerBL->GetClientID(),msg,ORDER_STATUS_RESPONSE);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Exit");	
}



void OrderResponseHandler::SendExecutionReport(ExecutionReport* exeReport)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Entered");	

	OrderStatusResponse* msg= (OrderStatusResponse*)GetMessageObject(ORDER_STATUS_RESPONSE);
	memcpy(&msg->ExecutionReport,exeReport,sizeof(ExecutionReport));


	
	//msg->ExecutionReport.OrderID=OrderResponseHandler::m_orderID++;
	//sprintf_s( msg->ExecutionReport.ExecID,40,"%I64u",msg->ExecutionReport.OrderID);
	_ui64toa(msg->ExecutionReport.OrderID, msg->ExecutionReport.ExecID, 10);
	m_ptrConnectionMgr->SendResponseToQueue(m_ptrServerBL->GetClientID(),msg,ORDER_STATUS_RESPONSE);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Exit");	
}


TriggerStopOrderEvent::TriggerStopOrderEvent(IStopOrderRequest* order)
{
	m_ptrOrder=order;
}

IStopOrderRequest* TriggerStopOrderEvent::GetOrder()
{
	return m_ptrOrder;
}