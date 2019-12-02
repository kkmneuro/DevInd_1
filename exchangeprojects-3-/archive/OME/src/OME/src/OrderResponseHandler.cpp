///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials	Desc
//	13 Jun 2014		BR			Ticket TradingApplication/149. Modified function OnEvent to add count++ while sending Quotes response	
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "OrderResponseHandler.h"
#include "xlogger.h"
//#include "AsyncPipes2.h"

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

OrderResponseHandler::OrderResponseHandler(IServerBL* pServerBL,IMarket* pMarket,IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE, IDatabase* pDatabase, IDatabase* pDatabaseBO, GatewayClient *pClient)
{
	m_ptrDatabaseMgr=pDatabase;
	m_ptrDatabaseBO = pDatabaseBO;
	m_ptrConnectionMgr = pIConnectionMgr;
	m_ptrConnectionMgrMDE = pIConnectionMgrMDE;
	m_ptrServerBL=pServerBL;

	LoadAutoHedgeSettings();
	LoadLiveAccounts();

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
				if (pRequest->GetPrice() != 0)
				{
					pRequest->m_ptrOrder->Price = pRequest->GetPrice();

					market->AddOrder((ILimitOrderRequest *)pRequest);
				}
				else
				{
					market->GetTradeMarketOrder()->ExecuteMarketOrder((IMarketOrderRequest *)pRequest);

					// delete the stop order
					delete pRequest;
				}
			}
		}

		//delete reqTriggerStop;
	}

	////////////////////////

	QuotesStreamResponse* reqQuotesStream=dynamic_cast<QuotesStreamResponse*>(evt);

	
	if (reqQuotesStream)
	{
		IMarket *market = reqQuotesStream->m_Market;

		QuotesStream* msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
		
		std::list<QuotesItem>::iterator iter;

		int nCount = 0;
		for (iter = reqQuotesStream->m_Quotes.begin(); iter != reqQuotesStream->m_Quotes.end(); iter++)
		{
			//memcpy(&msg->QuotesItem[nCount], (void *)*iter, sizeof(QuotesItem));
			msg->QuotesItem[nCount] = *iter;

			if (msg->QuotesItem[nCount].QuotesStreamType == QUOTES_STREAM_TYPE_LAST)
			{
				
				unsigned long long high, low, open, prcClose;
				int val = market->CalculateOHLC(&msg->QuotesItem[nCount], open, high, low, prcClose);

				nCount++;
				if (val & MASKOpen)
				{
					msg->QuotesItem[nCount].MarketLevel = 0;
					msg->QuotesItem[nCount].Price = open;
					msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
					msg->QuotesItem[nCount].Size = 0;
					memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
					//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
					
					msg->QuotesItem[nCount].Time = 0;

					nCount ++;

					if (nCount >= MAX_SYMBOL)
					{
						// Send and reset the object
						msg->NoOfSymbols = nCount;
						m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
						nCount = 0;
						msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
					}
				}

				if (val & MASKHigh)
				{
					msg->QuotesItem[nCount].MarketLevel = 0;
					msg->QuotesItem[nCount].Price = high;
					msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
					msg->QuotesItem[nCount].Size = 0;
					//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
					memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
					msg->QuotesItem[nCount].Time = 0;

					nCount ++;

					if (nCount >= MAX_SYMBOL)
					{
						// Send and reset the object
						msg->NoOfSymbols = nCount;
						m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
						free(msg);
						nCount = 0;
						msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
					}
				}

				if (val & MASKLow)
				{
					msg->QuotesItem[nCount].MarketLevel = 0;
					msg->QuotesItem[nCount].Price = low;
					msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
					msg->QuotesItem[nCount].Size = 0;
					//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
					memcpy(&msg->QuotesItem[nCount].Symbol, &market->GetSymbol(), sizeof(symbol));
					msg->QuotesItem[nCount].Time = 0;

					nCount ++;
				}

				if (nCount >= MAX_SYMBOL)
				{
					// Send and reset the object
					msg->NoOfSymbols = nCount;
					m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
					free(msg);
					nCount = 0;
					msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);
				}

				//market->TriggerStopOrders((*iter).Price);
			}
			else	
				nCount ++;

		}

		if (nCount > 0)
		{
			msg->NoOfSymbols = nCount;
			m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
		}
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////
	EventSnapshotResponse* reqOHLC=dynamic_cast<EventSnapshotResponse*>(evt);

	
	if (reqOHLC)
	{
		QuotesStream* msg = (QuotesStream*)GetMessageObject(QUOTES_STREAM);
		
		if (msg)
		{
			msg->NoOfSymbols = 0;

			int nCount = 0;
			msg->QuotesItem[nCount].Price = reqOHLC->report.Close;
			msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_CLOSE;
			msg->QuotesItem[nCount].Size = 0;
			memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
			msg->QuotesItem[nCount].MarketLevel = 0;
			msg->QuotesItem[nCount].Time = 0;
			nCount ++;

			msg->QuotesItem[nCount].Price = reqOHLC->report.High;
			msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
			msg->QuotesItem[nCount].Size = 0;
			memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
			msg->QuotesItem[nCount].MarketLevel = 0;
			msg->QuotesItem[nCount].Time = 0;
			nCount ++;

			msg->QuotesItem[nCount].Price = reqOHLC->report.Low;
			msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
			msg->QuotesItem[nCount].Size = 0;
			memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
			msg->QuotesItem[nCount].MarketLevel = 0;
			msg->QuotesItem[nCount].Time = 0;
			nCount ++;

			msg->QuotesItem[nCount].Price = reqOHLC->report.Open;
			msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
			msg->QuotesItem[nCount].Size = 0;
			memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
			msg->QuotesItem[nCount].MarketLevel = 0;
			msg->QuotesItem[nCount].Time = 0;
			nCount ++;

			msg->QuotesItem[nCount].Price = reqOHLC->report.LastPrice;
			msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_LAST;
			msg->QuotesItem[nCount].Size = reqOHLC->report.Volume;
			memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
			msg->QuotesItem[nCount].MarketLevel = 0;
			msg->QuotesItem[nCount].Time = reqOHLC->report.LastTime;
			nCount ++;

			msg->NoOfSymbols = nCount;

			m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);

			msg->NoOfSymbols = 0;
			nCount = 0;

			for (int k =0; k<reqOHLC->report.MarketDepthLevel; k ++)
			{
				//if (reqOHLC->report.MarketDepth[k].AskPrice != 0)
				{
					msg->QuotesItem[nCount].Price = reqOHLC->report.MarketDepth[k].AskPrice;
					msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_ASK;
					msg->QuotesItem[nCount].Size = reqOHLC->report.MarketDepth[k].AskSize;
					memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
					msg->QuotesItem[nCount].MarketLevel = k;
					msg->QuotesItem[nCount].Time = reqOHLC->report.MarketDepth[k].AskTime;

					nCount++;

					if (nCount >= MAX_SYMBOL)
					{
						msg->NoOfSymbols = nCount;

						m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);

						msg->NoOfSymbols = 0;
						nCount =0;
					}
				}

				//if (reqOHLC->report.MarketDepth[k].BidPrice != 0)
				{
					msg->QuotesItem[nCount].Price = reqOHLC->report.MarketDepth[k].BidPrice;
					msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_BID;
					msg->QuotesItem[nCount].Size = reqOHLC->report.MarketDepth[k].BidSize;
					memcpy(&msg->QuotesItem[nCount].Symbol, &reqOHLC->report.Symbol,sizeof(reqOHLC->report.Symbol));
					msg->QuotesItem[nCount].MarketLevel = k;
					msg->QuotesItem[nCount].Time = reqOHLC->report.MarketDepth[k].BidTime;

					nCount++;

					if (nCount >= MAX_SYMBOL)
					{
						msg->NoOfSymbols = nCount;

						m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);

						msg->NoOfSymbols = 0;
						nCount =0;
					}
				}
			}

			if (nCount >= 0)
			{
				msg->NoOfSymbols = nCount;

				m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);

				msg->NoOfSymbols = 0;
				nCount =0;

				free(msg);
			}

		}

		//QuotesSnapshotResponse* msg= (QuotesSnapshotResponse*)GetMessageObject(QUOTE_SNAP_SHOT_RESPONSE);

		//memcpy(&msg->OHLC, &reqOHLC->report, sizeof(reqOHLC->report));

		//msg->NoOfSymbols = 1;
		//m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTE_SNAP_SHOT_RESPONSE);
	}

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

void OrderResponseHandler::SendExecutionReport(EventExecutionReport* exeReport)
{
	OrderStatusResponse* msg= (OrderStatusResponse*)GetMessageObject(ORDER_STATUS_RESPONSE);
	memcpy(&msg->ExecutionReport,&exeReport->report,sizeof(ExecutionReport));
	
	_ui64toa(msg->ExecutionReport.OrderID, msg->ExecutionReport.ExecID, 10);
	msg->ExecutionReport.ClosedQuantity =0;

	// Send order to PIPE for sending order for hedging

	m_ptrConnectionMgr->SendResponseToQueue(m_ptrServerBL->GetClientID(),msg,ORDER_STATUS_RESPONSE);

	free(msg);
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

	free(msg);

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

int OrderResponseHandler::LoadAutoHedgeSettings()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = m_ptrDatabaseBO->Execute("OME_GetAutoHedgeList",*tb,*param);//execute sp

	if( !isSPExist )
	{
		nSuccess = -1;
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::LoadAutoHedgeSettings, Unable to execute SP OME_GetAutoHedgeList");
		return nSuccess;
	}

	AutoHedgeSettings autoHedge;

	while (!tb->IsEOF())
	{
		tb->Get("Contract", autoHedge.szContract, sizeof(autoHedge.szContract));
		tb->Get("Symbol", autoHedge.nSymbol);
		tb->Get("AccountNo", autoHedge.Account);
		tb->Get("ConversionRatio", autoHedge.Conversion);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, 
			"OrderResponseHandler::LoadAutoHedgeSettings, Symbol Loaded=%s, Symbol Hedge = %d, AccountNo = %d, Conv = %lf", 
			autoHedge.szContract,
			autoHedge.nSymbol,
			autoHedge.Account,
			autoHedge.Conversion);

		if (m_mapAutoHedgeSettings.find(autoHedge.szContract) == m_mapAutoHedgeSettings.end())
		{
			// Add to map
			std::pair<std::string, AutoHedgeSettings> pr(autoHedge.szContract, autoHedge);
			m_mapAutoHedgeSettings.insert(pr);
		}

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object
	
	return nSuccess;
}

int OrderResponseHandler::LoadLiveAccounts()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = m_ptrDatabaseMgr->Execute("Exchange_GetLiveAccountList",*tb,*param);//execute sp

	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::LoadLiveAccounts, Unable to execute SP Exchange_GetLiveAccountList");
		return -1;
	}

	int AccNo = 0;

	while (!tb->IsEOF())
	{
		tb->Get("AccountID", AccNo);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::LoadAutoHedgeSettings, Symbol Loaded=%d", AccNo);

		std::pair<unsigned long, unsigned long> pr(AccNo, AccNo);
		m_mapLiveAccounts.insert(pr);

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object
	
	return nSuccess;
}
