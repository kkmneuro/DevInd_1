///////////////////////////////////////Revision History/////////////////////////////////////////////////////
//	7 Nov 2013		BR				Modified Market::UpdatePrice to execute orders at LTP instead of Bid/Ask
//									Prices. Version upgraded to 2.0.0.3
////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Market.h"
#include "OrderResponseHandler.h"
#include "xconfigure.h"
#include "xlogger.h"
#include "datadef.h"
#include <ATLCOMTime.h>

#define MARKET_DEPTH 5
MarketOrder::MarketOrder(ILimitOrderRequest* order)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder::LimitOrderRequest, Entered");	

	InitializeCriticalSection(&CS_LIMIT_ORDER_LIST);

	EnterCriticalSection(&CS_LIMIT_ORDER_LIST);
	m_limitOrderList.push_back(order);
	m_price=order->GetPrice();
	//m_volumn=order->GetOrderQnty();
	m_volumn=order->m_remainingQnty;
	LeaveCriticalSection(&CS_LIMIT_ORDER_LIST);

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder, Exit");	
}

MarketOrder::MarketOrder(IStopOrderRequest* order)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder::StopOrderRequest, Entered");	

	InitializeCriticalSection(&CS_STOP_ORDER_LIST);

	EnterCriticalSection(&CS_STOP_ORDER_LIST);
	m_StopOrderList.push_back(order);
	m_price=order->GetStopPx();
	//m_volumn=order->GetOrderQnty();
	m_volumn=order->m_remainingQnty;
	LeaveCriticalSection(&CS_STOP_ORDER_LIST);

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder (StopOrderRequest), Exit");	
}

MarketOrder::MarketOrder(ICancelOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder::ICancelOrderRequest, Entered");	

	InitializeCriticalSection(&CS_LIMIT_ORDER_LIST);

	EnterCriticalSection(&CS_LIMIT_ORDER_LIST);

	if (order->GetOrderType() == ORDER_TYPE_STOP_ORDER ||order->GetOrderType() == ORDER_TYPE_STOP_LIMIT_ORDER)
	{
		m_price=order->GetStopPx();
	}
	else
	{
		m_price=order->GetPrice();
	}
	m_volumn=order->GetOrderQnty();
	LeaveCriticalSection(&CS_LIMIT_ORDER_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MarketOrder::ICancelOrderRequest, Exit");	
}



MarketOrder::~MarketOrder()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::~MarketOrder, Entered");	
	//EnterCriticalSection(&CS_LIMIT_ORDER_LIST);
	//for(LIMIT_ORDER_REQUEST_LIST_ITER iter=m_limitOrderList.begin();iter!=m_limitOrderList.end();iter++)
	//{
	//	//delete (*iter);
	//}
	//LeaveCriticalSection(&CS_LIMIT_ORDER_LIST);

	DeleteCriticalSection(&CS_LIMIT_ORDER_LIST);
}

bool MarketOrder::operator == (IMarketOrder& marketOrder)
{
	return GetPrice() == marketOrder.GetPrice();
}
bool MarketOrder::operator < (IMarketOrder& marketOrder)
{
	return GetPrice() < marketOrder.GetPrice();
}

void MarketOrder::AddLimitOrder(ILimitOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddLimitOrder, Entered");	

	EnterCriticalSection(&CS_LIMIT_ORDER_LIST);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddLimitOrder, Added ClOrdID = %s, OrderID = %lu",
		order->m_ptrOrder->ClOrdId,
		(unsigned long)order->m_ptrOrder->OrderID);	

	m_limitOrderList.push_back(order);
	//m_volumn+=order->GetOrderQnty();
	m_volumn += order->m_remainingQnty;
	LeaveCriticalSection(&CS_LIMIT_ORDER_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddLimitOrder, Exit");	
}

ILimitOrderRequest* MarketOrder::CancelLimitOrder(ICancelOrderRequest* ord)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelLimitOrder, Entered");	

	ILimitOrderRequest *ordRequest = NULL;
	bool bFound = false;

	EnterCriticalSection(&CS_LIMIT_ORDER_LIST);
	LIMIT_ORDER_REQUEST_LIST::iterator iter;

	iter = m_limitOrderList.begin();

	while (iter != m_limitOrderList.end())
	{
		if (ord->GetOrderID() == (*iter)->GetOrderID())
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelLimitOrder, Found the order Added ClOrdID = %s, OrderID = %lu",
				(*iter)->m_ptrOrder->ClOrdId,
				(unsigned long)(*iter)->m_ptrOrder->OrderID);	

			ordRequest = *iter;
			iter = m_limitOrderList.erase(iter);
			bFound = true;

			break;
		}

		iter++;
	}

	if (bFound)
	{
		m_volumn -= ordRequest->m_remainingQnty;
		ord->m_remainingQnty = 0;
	}

	LeaveCriticalSection(&CS_LIMIT_ORDER_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelLimitOrder, Exit");	

	return ordRequest;
}

void MarketOrder::AddStopOrder(IStopOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddStopOrder, Entered");	

	EnterCriticalSection(&CS_STOP_ORDER_LIST);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddStopOrder, Added ClOrdID = %s, OrderID = %lu",
		order->m_ptrOrder->ClOrdId,
		(unsigned long)order->m_ptrOrder->OrderID);	

	m_StopOrderList.push_back(order);
	m_volumn += order->m_remainingQnty;
	LeaveCriticalSection(&CS_STOP_ORDER_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddStopOrder, Exit");	
}

IStopOrderRequest* MarketOrder::CancelStopOrder(ICancelOrderRequest* ord)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelStopOrder, Entered");	

	IStopOrderRequest *ordRequest = NULL;
	bool bFound = false;

	EnterCriticalSection(&CS_STOP_ORDER_LIST);
	STOP_ORDER_REQUEST_LIST::iterator iter;

	iter = m_StopOrderList.begin();

	while (iter != m_StopOrderList.end())
	{
		if (ord->GetOrderID() == (*iter)->GetOrderID())
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelStopOrder, Found the order Added ClOrdID = %s, OrderID = %lu",
				(*iter)->m_ptrOrder->ClOrdId,
				(unsigned long)(*iter)->m_ptrOrder->OrderID);	

			ordRequest = *iter;
			iter = m_StopOrderList.erase(iter);
			bFound = true;

			break;
		}

		iter++;
	}

	if (bFound)
		m_volumn -= ordRequest->m_remainingQnty;

	LeaveCriticalSection(&CS_STOP_ORDER_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::CancelStopOrder, Exit");	

	return ordRequest;
}

unsigned long long MarketOrder::GetPrice()
{
	return m_price;
}
unsigned long long MarketOrder::GetVolumn()
{
	return m_volumn;
}

unsigned int _stdcall Market::RaiseMarketEvent(void *arg)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::RaiseMarketEvent, Entered");	

	Market* pThis=(Market*)arg;
	EVENT_OBJECT_QUEUE evtObjQ;
	while(pThis->m_dispatchMarketEvent)
	{
		WaitForSingleObject(pThis->m_hEventOjectQueue,INFINITE);
		EnterCriticalSection(&pThis->CS_EVENT_OBJECT_QUEUE);
		while(!pThis->m_eventOjectQueue.empty())
		{
			evtObjQ.push(pThis->m_eventOjectQueue.front());
			pThis->m_eventOjectQueue.pop();
		}
		LeaveCriticalSection(&pThis->CS_EVENT_OBJECT_QUEUE);
		while(!evtObjQ.empty())
		{
			EnterCriticalSection(&pThis->CS_MARKET_LISTINER);
			for(MARKET_LISTINER_ITER iter= pThis->m_marketlistiner.begin();iter!=pThis->m_marketlistiner.end();iter++)
			{
				(*iter)->OnEvent(evtObjQ.front());
			}
			LeaveCriticalSection(&pThis->CS_MARKET_LISTINER);
			evtObjQ.pop();
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::RaiseMarketEvent, Exit");	
	return 0;
}

Market::Market(IDatabase* pDatabase, IDatabase *pDatabaseBO, Symbol sym)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Market, Entered");	
	m_bMarketOpen = false;
	m_pDatabase = pDatabase;
	m_pDatabaseBO = pDatabaseBO;
	memcpy(&m_Symbol, &sym, sizeof(sym));
	xconfigure ConfigObj( "Setting.txt");
	std::string strCon; 
	ConfigObj.GetParameterString( "DATABASE", std::string("CON_STRING"), strCon); 

	InitializeCriticalSection(&CS_ASK_LIST);
	InitializeCriticalSection(&CS_BID_LIST);
	InitializeCriticalSection(&CS_LIMIT_ORDER_BOOK);
	InitializeCriticalSection(&CS_STOP_ASK_LIST);
	InitializeCriticalSection(&CS_STOP_BID_LIST);
	InitializeCriticalSection(&CS_STOP_ORDER_BOOK);

	InitializeCriticalSection(&CS_MARKET_LISTINER);
	InitializeCriticalSection(&CS_EVENT_OBJECT_QUEUE);
	InitializeCriticalSection(&CS_CurrentPrice);

	m_hEventOjectQueue=CreateEvent(NULL,FALSE,FALSE,NULL);

	m_dispatchMarketEvent=1;
	m_hRaiseMarketEventThread=(HANDLE)_beginthreadex(NULL,NULL,Market::RaiseMarketEvent,this,NULL,NULL);
	m_ptrTradeMarketOrder=new TradeMarketOrder(this);

	memset(&m_OHLCStats, 0, sizeof(m_OHLCStats));

	m_OrderDelay = 5;
	m_Slippage = 10000;
	m_OrderVolume = 100;

	m_ulAsk = 0;
	m_ulBid = 0;
	m_ulLTP = 0;

	//GetSessionList(pDatabaseBO, m_Symbol.Contract);
	
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Market, Exit");	
}

bool Market::CheckMarketStatus(int day, struct tm& tm1)
{
	bool bSuccess = true;

	

	return bSuccess;
}

void Market::GetSessionList(IDatabase *pDatabase, char *szSymbol)
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	param->AddParam("Symbol",szSymbol,20);

	bool isSPExist = pDatabase->Execute("Exchange_ListOfSessionForSymbol",*tb,*param);//execute sp
	if( !isSPExist )
	{
		// Initialized failed
		return ;
	}

	std::string str;
	str.append(szSymbol);
	
	int i = 0;

	char QuoteSession[200];
	char TradeSession[200];

	while (!tb->IsEOF())
	{
		tb->Get("Days",i);
		tb->Get("Quotes",QuoteSession,sizeof(QuoteSession));
		tb->Get("Trade",TradeSession,sizeof(TradeSession));

		TradeQuoteList SessionList;
		GetSession(QuoteSession,TradeSession, SessionList);

		m_mapTradeSession.insert(pair<int,TradeQuoteList>(i,SessionList));

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object
}

void Market::GetSession(char* QuoteSession,char* TradeSession, TradeQuoteList& o_TradeQuoteList)
{	
	std::string Quotestr[10];
	std::string Tradestr[10];

	char *QuoteSingleTerm = NULL;
	char *TradeSingleTerm = NULL;

	QuoteSingleTerm = strtok(QuoteSession,",");
	int i = 0;	
	while(QuoteSingleTerm)
	{
		Quotestr[i] = QuoteSingleTerm;
		i++;
		QuoteSingleTerm = strtok(NULL,",");
	}

	TradeSingleTerm = strtok(TradeSession,",");
	int k = 0;
	while(TradeSingleTerm)
	{
		Tradestr[k] = TradeSingleTerm;
		k++;
		TradeSingleTerm = strtok(NULL,",");
	}	

	for(int j=0;j<i;j++)
	{		
		if(!Quotestr[j].empty())
		{		
			std::string firststart;
			std::string secondstart;
			std::string firstend;
			std::string secondend;	

			int pos = Quotestr[j].find("-",0);
			int pos1 = Quotestr[j].find(":",0);
			int pos2 = Quotestr[j].find(":",pos);
			int pos3 = Quotestr[j].length();

			if(pos>0)
			{
				firststart.assign(Quotestr[j],0,pos1);
				secondstart.assign(Quotestr[j],(pos1+1),(pos-pos1-1));
				firstend.assign(Quotestr[j],(pos+1),(pos2-pos-1));
				secondend.assign(Quotestr[j],(pos2+1),(pos3-pos2-1));
			}

			Session Ses;
			Ses.FromHour = atoi(firststart.c_str());
			Ses.FromMin = atoi(secondstart.c_str());
			Ses.ToHour = atoi(firstend.c_str());
			Ses.ToMin = atoi(secondend.c_str());		
			o_TradeQuoteList.l_Quote.push_back(Ses);
		}	
	}

	for(int l=0;l<k;l++)
	{
		if(!Tradestr[l].empty())
		{	
			std::string firststart;
			std::string secondstart;
			std::string firstend;
			std::string secondend;	

			int pos = Tradestr[l].find("-",0);
			int pos1 = Tradestr[l].find(":",0);
			int pos2 = Tradestr[l].find(":",pos);
			int pos3 = Tradestr[l].length();

			if(pos>0)
			{
				firststart.assign(Tradestr[l],0,pos1);
				secondstart.assign(Tradestr[l],(pos1+1),(pos-pos1-1));
				firstend.assign(Tradestr[l],(pos+1),(pos2-pos-1));
				secondend.assign(Tradestr[l],(pos2+1),(pos3-pos2-1));
			}

			Session Ses;
			Ses.FromHour = atoi(firststart.c_str());
			Ses.FromMin = atoi(secondstart.c_str());
			Ses.ToHour = atoi(firstend.c_str());
			Ses.ToMin = atoi(secondend.c_str());		
			o_TradeQuoteList.l_Trade.push_back(Ses);
		}	
	}
}

bool Market::ValidateCurrentSession(std::string symbol, bool bTrade)
{
	bool flag = false;

	DAY_SESSION_MAP::iterator itt;

	list<Session>::iterator ittt;

	time_t now = time(0);
	tm *gmtm = localtime(&now);
	
	//it = m_ContractSessionMap.find(symbol);

	//if (it != m_ContractSessionMap.end())
	//{
	//	DAY_SESSION_MAP& mapDaySession = (*it).second;

	//	itt = mapDaySession.find(gmtm->tm_wday + 1);

	//	if (itt != mapDaySession.end())
	//	{
	//		TradeQuoteList& o_TQList = (*itt).second;

	//		if (bTrade)
	//			ittt = o_TQList.l_Trade.begin();
	//		else
	//			ittt = o_TQList.l_Quote.begin();

	//		while (ittt != o_TQList.l_Trade.end())
	//		{
	//			if( gmtm->tm_hour > ittt->FromHour &&  gmtm->tm_hour < ittt->ToHour)
	//			{
	//				flag = true;
	//			}
	//			else if(gmtm->tm_hour == ittt->FromHour && gmtm->tm_min > ittt->FromMin && gmtm->tm_hour < ittt->ToHour)
	//			{
	//				flag = true;
	//			}
	//			else if(gmtm->tm_hour == ittt->ToHour && gmtm->tm_min < ittt->ToMin && gmtm->tm_hour > ittt->FromHour)
	//			{
	//				flag = true;
	//			}
	//			else if(gmtm->tm_hour == ittt->ToHour && gmtm->tm_hour == ittt->FromHour && gmtm->tm_min > ittt->FromMin && gmtm->tm_min < ittt->ToMin)
	//			{
	//				flag = true;
	//			}

	//			if (flag == true)
	//				break;

	//			ittt++;
	//		}
	//	}
	//}

	return flag;
}




Market::~Market()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::~Market, Entered");	

	m_dispatchMarketEvent=0;
	SetEvent(m_hEventOjectQueue);
	CloseHandle(m_hEventOjectQueue);
	DWORD dwResult=WaitForSingleObject(m_hRaiseMarketEventThread,1000);
	if(dwResult==WAIT_TIMEOUT)
	{
		//Log: Event thread not closed properly.
	}
	CloseHandle(m_hRaiseMarketEventThread);

	/*EnterCriticalSection(&CS_ASK_LIST);
	for(KEY_MARKET_ORDER_MAP_ITER iter=m_askList.begin();iter!=m_askList.end();iter++)
	{
		for(MARKET_ORDER_LIST_ITER mIter= iter->second.begin();mIter!=iter->second.begin();mIter++)
		{
			delete (*mIter);
		}
	}
	LeaveCriticalSection(&CS_ASK_LIST);*/

	EnterCriticalSection(&CS_BID_LIST);
	/*for(KEY_MARKET_ORDER_MAP_ITER iter=m_bidList.begin();iter!=m_bidList.end();iter++)
	{
		for(MARKET_ORDER_LIST_ITER mIter= iter->second.begin();mIter!=iter->second.begin();mIter++)
		{
			delete (*mIter);
		}
	}*/
	LeaveCriticalSection(&CS_BID_LIST);


	EnterCriticalSection(&CS_LIMIT_ORDER_BOOK);
	for(LIMIT_ORDER_REQUEST_LIST_ITER orderBookIter=m_LimitOrderBook.begin();orderBookIter!=m_LimitOrderBook.end();orderBookIter++)
	{
		delete (*orderBookIter);
	}
	LeaveCriticalSection(&CS_LIMIT_ORDER_BOOK);

	delete m_ptrTradeMarketOrder;

	DeleteCriticalSection(&CS_ASK_LIST);
	DeleteCriticalSection(&CS_BID_LIST);
	DeleteCriticalSection(&CS_LIMIT_ORDER_BOOK);
	DeleteCriticalSection(&CS_MARKET_LISTINER);
	DeleteCriticalSection(&CS_EVENT_OBJECT_QUEUE);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::~Market, Exit");	
}

ITradeMarketOrder* Market::GetTradeMarketOrder()
{
	return m_ptrTradeMarketOrder;
}

void Market::SendOrderResponse(IEventObject* evtObj)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendOrderResponse, Entered");	

	EnterCriticalSection(&CS_EVENT_OBJECT_QUEUE);
	m_eventOjectQueue.push(evtObj);
	LeaveCriticalSection(&CS_EVENT_OBJECT_QUEUE);
	SetEvent(m_hEventOjectQueue);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendOrderResponse, Exit");	
}

void Market::AddOrderToSymbol(ILimitOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrderToSymbol, Entered");	

	IMarketOrder* marketOrder=new MarketOrder(order);
	int position = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddOrderToSymbol, ClOrdID = %s, OrderID = %lu",
		order->m_ptrOrder->ClOrdId,
		(unsigned long)order->m_ptrOrder->OrderID);	

	MARKET_ORDER_LIST_ITER listIterBegin= list.begin();
	MARKET_ORDER_LIST_ITER listIterEnd= list.end();
	MARKET_ORDER_LIST_ITER listIter=find_if(listIterBegin,listIterEnd,CompareRef<IMarketOrder*>(marketOrder));
	if(listIter==listIterEnd)
	{
	
		vector<IMarketOrder *>::iterator iter;

		if (type == QUOTES_STREAM_TYPE_BID)
			position = InsertItemRev<IMarketOrder*>(list,marketOrder);
		else
			position = InsertItem<IMarketOrder*>(list,marketOrder);
		//iter++;

		//SendQuotes(list, type, m_Symbol, position);
	}
	else
	{
		(*listIter)->AddLimitOrder(order);
		delete marketOrder;

		/*SendQuotes(list,
					listIter,
					type,
					m_Symbol,
					true);*/


		//int pos = 0;
		//bool bPosFound = false;
		//// Find the position
		//for (pos = 0; pos < 5 && pos < list.size();pos++)
		//{
		//	if ((*list[pos]).GetPrice() == order->GetPrice())
		//	{
		//		bPosFound = true;
		//		position = pos;
		//		break;
		//	}
		//}

		//if (bPosFound)
		//{
		//	SendQuotes((*listIter)->GetPrice(),
		//				(*listIter)->GetVolumn(),
		//				type,
		//				m_Symbol,
		//				position);
		//}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrderToSymbol, Exit");	
}

void Market::AddAsk(ILimitOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddAsk, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);
	EnterCriticalSection(&CS_ASK_LIST);

	
	AddOrderToSymbol(order,m_askList,&strKey,'A');

	LeaveCriticalSection(&CS_ASK_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddAsk, Exit");	
}

void Market::AddBid(ILimitOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddBid, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_BID_LIST);
	AddOrderToSymbol(order,m_bidList,&strKey,'B');

	LeaveCriticalSection(&CS_BID_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddBid, Exit");	
}

bool Market::AddOrder(ILimitOrderRequest* order)
{
	bool ret=true;
	try
	{
		if(order->GetSide()==SIDE_BUY)
		{
			AddBid(order);
		}
		else if(order->GetSide()==SIDE_SELL) 
		{
			AddAsk(order);
		}
	}
	catch(...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrder, In Exception");	
		ret=false;
	}

	return ret;
}

void Market::AddOrderToSymbol(IStopOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrderToSymbol (Stop Order), Entered");	

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::AddOrderToSymbol for Stop order, ClOrdID = %s, OrderID = %lu",
		order->m_ptrOrder->ClOrdId,
		(unsigned long)order->m_ptrOrder->OrderID);	

	IMarketOrder* marketOrder=new MarketOrder(order);
	int position = 0;

	MARKET_ORDER_LIST_ITER listIterBegin= list.begin();
	MARKET_ORDER_LIST_ITER listIterEnd= list.end();
	MARKET_ORDER_LIST_ITER listIter=find_if(listIterBegin,listIterEnd,CompareRef<IMarketOrder*>(marketOrder));
	if(listIter==listIterEnd)
	{
		vector<IMarketOrder *>::iterator iter;

		if (type == QUOTES_STREAM_TYPE_BID)
			position = InsertItemRev<IMarketOrder*>(list,marketOrder);
		else
			position = InsertItem<IMarketOrder*>(list,marketOrder);
		//iter++;
	}
	else
	{
		(*listIter)->AddStopOrder(order);
		//delete marketOrder;
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrderToSymbol, Exit");	
}

void Market::AddAsk(IStopOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddAsk (Stop Order), Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_STOP_ASK_LIST);
	
	// In stop order its in reverse than limit
	AddOrderToSymbol(order,m_StopAskList,&strKey,'B');

	LeaveCriticalSection(&CS_STOP_ASK_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddAsk (Stop Order), Exit");	
}

void Market::AddBid(IStopOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddBid (Stop Order), Entered");	

	string strKey ;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_STOP_BID_LIST);
	// In stop order its in reverse than limit
	AddOrderToSymbol(order,m_StopBidList,&strKey,'A');

	LeaveCriticalSection(&CS_STOP_BID_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddBid (Stop Order), Exit");	
}

bool Market::AddOrder(IStopOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrder (Stop Order), Entered");	

	bool ret=true;
	try
	{
		if(order->GetSide()==SIDE_BUY)
		{
			AddBid(order);
		}
		else if(order->GetSide()==SIDE_SELL) 
		{
			AddAsk(order);
		}
	}
	catch(...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrder (Stop Order), In Exception");	
		ret=false;
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::AddOrder (Stop Order), Exit");	

	return ret;
}

bool Market::AddOrder(IMarketOrderRequest* order)
{
	bool ret=true;
	try
	{
	}
	catch(...)
	{
		ret=false;
	}
	return ret;
}

void Market::RegisterMarketEvents(IMarketEvents* marketEvent)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::RegisterMarketEvents, Entered");	

	EnterCriticalSection(&CS_MARKET_LISTINER);
	m_marketlistiner.push_back(marketEvent);
	LeaveCriticalSection(&CS_MARKET_LISTINER);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::RegisterMarketEvents, Exit");	
}

template<typename T> void InsertItem( list<T>& lst, T item)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItem, Entered");	

	int numItems = (int)lst.size();
	if (numItems == 0)
	{
		lst.push_back(item);
		return;
	}
	list<T>::iterator lstIter;
	int first, last, mid;
    first = 0;
	last = numItems - 1;
	while (first <= last)
	{
		mid = (first + last) / 2;
		lstIter=lst.begin();
		advance(lstIter,mid);
		if(**lstIter == *item)
		{
			if (mid < numItems)
				lst.insert(lstIter, item);
			return;
		}
		else if(**lstIter < *item)
		{
			first = mid + 1;
		}
		else
		{
			last = mid - 1;
		}
	}
	if (last < 0)
	{
		lstIter = lst.begin();
		if (**lstIter < *item )
			lstIter++;
		lst.insert(lstIter, item);
	}
	else
	{
		if (first > (numItems - 1))
		{
			lstIter=lst.end();
			lstIter--;
			if (**lstIter < *item )
			{
				lstIter++;
				lst.insert(lstIter, item);
			}
			else
			{
				lst.insert(lstIter, item);
				return;
			}
		}
		else
		{
			lstIter = lst.begin();
			advance(lstIter,first);
			lst.insert(lstIter, item);
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItem, Exit");	
}


template<typename T> int InsertItem( vector<T>& lst, T item)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItem, Entered");	

	int posInserted = 0;
	int numItems = (int)lst.size();
	if (numItems == 0)
	{
		lst.push_back(item);
		return 0;
	}
	vector<T>::iterator lstIter;
	int first, last, mid;
    first = 0;
	last = numItems - 1;
	while (first <= last)
	{
		mid = (first + last) / 2;
		//lstIter=lst.begin();
		//advance(lstIter,mid);
		//if(**lstIter == *item)
		if (*lst[mid] == *item)
		{
			if (mid < numItems)
			{
				advance(lstIter, mid);
				lst.insert(lstIter, item);
				posInserted = mid;
			}
			return posInserted;
		}
		else if(*lst[mid] < *item)
		{
			first = mid + 1;
		}
		else
		{
			last = mid - 1;
		}
	}
	if (last < 0)
	{
		lstIter = lst.begin();
		if (**lstIter < *item )
			lstIter++;
		lst.insert(lstIter, item);

		posInserted = 0;
	}
	else
	{
		if (first > (numItems - 1))
		{
			lstIter=lst.end();
			lstIter--;
			if (**lstIter < *item )
			{
				lstIter++;
				lst.insert(lstIter, item);
				posInserted = numItems;
			}
			else
			{
				lst.insert(lstIter, item);
				posInserted = numItems -1;
				return posInserted;
			}
		}
		else
		{
			lstIter = lst.begin();
			advance(lstIter,first);
			lst.insert(lstIter, item);
			posInserted = first;
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItem, Exit");	

	return posInserted;
}


template<typename T> int InsertItemRev( vector<T>& lst, T item)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItemRev, Entered");	

	int posInserted = 0;
	int numItems = (int)lst.size();
	if (numItems == 0)
	{
		lst.push_back(item);
		return 0;
	}
	vector<T>::iterator lstIter;
	int first, last, mid;
    first = 0;
	last = numItems - 1;
	while (first <= last)
	{
		mid = (first + last) / 2;
		//lstIter=lst.begin();
		//advance(lstIter,mid);
		//if(**lstIter == *item)
		if (*lst[mid] == *item)
		{
			if (mid < numItems)
			{
				advance(lstIter, mid);
				lst.insert(lstIter, item);
				posInserted = mid;
			}
			return posInserted;
		}
		else if(*item < *lst[mid])
		{
			first = mid + 1;
		}
		else
		{
			last = mid - 1;
		}
	}
	if (last < 0)
	{
		lstIter = lst.begin();
		//if (**lstIter > *item )
		if (*item < **lstIter )
			lstIter++;
		lst.insert(lstIter, item);

		posInserted = 0;
	}
	else
	{
		if (first > (numItems - 1))
		{
			lstIter=lst.end();
			lstIter--;
			//if (**lstIter > *item )
			if (*item <  **lstIter)
			{
				lstIter++;
				lst.insert(lstIter, item);
				posInserted = numItems;
			}
			else
			{
				lst.insert(lstIter, item);
				posInserted = numItems -1;
				return posInserted;
			}
		}
		else
		{
			lstIter = lst.begin();
			advance(lstIter,first);
			lst.insert(lstIter, item);
			posInserted = first;
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "InsertItemRev, Entered");	

	return posInserted;
}

template<class T> CompareRef<T>::CompareRef(const T& refObj)
{
	m_obj=refObj;
	
}

template<class T> bool CompareRef<T>::operator() (const T& refObj)
{
	return *m_obj == *refObj;
}

TradeMarketOrder::TradeMarketOrder(Market* pMarket)
{
	m_ptrMarket=pMarket;
}

TradeMarketOrder::~TradeMarketOrder()
{
}

void TradeMarketOrder::UpdateOrder(unsigned long long price,ILimitOrderRequest* existingOrder,unsigned long long& qntyExecuted)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::UpdateOrder, Entered");	

	qntyExecuted = existingOrder->m_remainingQnty;
	existingOrder->m_remainingQnty = 0;
	//

	////if(existingOrder->GetOrderQnty() >= mOrder->GetOrderQnty())
	//if(existingOrder->m_remainingQnty >= mOrder->m_remainingQnty)
	//{
	//	
	//	//existingOrder->GetOrder()->OrderQty -= mOrder->GetOrder()->OrderQty;
	//	existingOrder->m_remainingQnty -= mOrder->m_remainingQnty;
	//	//qntyExecuted=mOrder->GetOrder()->OrderQty;
	//	qntyExecuted=mOrder->m_remainingQnty;
	//	//mOrder->GetOrder()->OrderQty=0;
	//	mOrder->m_remainingQnty=0;
	//}
	//else
	//{
	//	//mOrder->GetOrder()->OrderQty -= existingOrder->GetOrder()->OrderQty;
	//	//existingOrder->GetOrder()->OrderQty=0;
	//	//qntyExecuted=existingOrder->GetOrder()->OrderQty;

	//	mOrder->m_remainingQnty -= existingOrder->m_remainingQnty;
	//	qntyExecuted = existingOrder->m_remainingQnty;
	//	existingOrder->m_remainingQnty=0;
	//	existingOrder->m_remainingQnty;
	//}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::UpdateOrder, Exit");	
}

void TradeMarketOrder::MatchOrder(LIMIT_ORDER_REQUEST_LIST& limitOrderList,unsigned long long price, unsigned long long& qntyExecuted)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::MatchOrder, Entered");	

	LIMIT_ORDER_REQUEST_LIST_ITER templimitOrderIter;
	LIMIT_ORDER_REQUEST_LIST_ITER limitOrderIter=limitOrderList.begin();
	while(!limitOrderList.empty() && limitOrderIter!=limitOrderList.end())
	{
		ILimitOrderRequest* existingOrder=(ILimitOrderRequest*) (*limitOrderIter);
		unsigned long long executedQ=0;

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MarketOrder::MatchOrder, ClOrdID = %s, OrderID = %lu",
			existingOrder->m_ptrOrder->ClOrdId,
			(unsigned long)existingOrder->m_ptrOrder->OrderID);	


		UpdateOrder(price,existingOrder,executedQ);

		m_ptrMarket->SendTradeReport(existingOrder,
										NULL,
										executedQ,
										price,
										false);


		qntyExecuted+=executedQ;
		

		if(existingOrder->m_remainingQnty==0)
		{
			templimitOrderIter = limitOrderIter;
			//limitOrderIter++;
			limitOrderIter = limitOrderList.erase(templimitOrderIter);

			delete existingOrder;
		}
		else
			limitOrderIter++;
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::MatchOrder, Exit");	
}


void TradeMarketOrder::ExecuteBuyOrder(IMarketOrderRequest* mOrder)
{
	if (m_ptrMarket)
	{
		unsigned long tradePrice = 0;
		bool bRequote = false;

		tradePrice  = m_ptrMarket->GetPrice(QUOTES_STREAM_TYPE_ASK);

		if (tradePrice == 0)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteBuyOrder, Price got is 0, taking MP");	
			tradePrice = mOrder->m_ptrOrder->Price;
		}

		mOrder->m_remainingQnty = 0;

		m_ptrMarket->SendTradeReport(NULL,
									 mOrder,
									 mOrder->GetOrderQnty(),
									 tradePrice,
									 bRequote);
	}
}

void TradeMarketOrder::ExecuteMarketOrder(unsigned long long price, char side)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder Price, Entered");	

	if(side == SIDE_BUY)
	{
		EnterCriticalSection(&m_ptrMarket->CS_ASK_LIST);
		ExecuteBuyOrder(price);
		LeaveCriticalSection(&m_ptrMarket->CS_ASK_LIST);
	}
	else if(side == SIDE_SELL)
	{
		EnterCriticalSection(&m_ptrMarket->CS_BID_LIST);
		ExecuteSellOrder(price);
		LeaveCriticalSection(&m_ptrMarket->CS_BID_LIST);
	}

	//if (mOrder->m_remainingQnty > 0)
	//{
	//	if (mOrder->GetTimeInForce()  != TIF_FOK)
	//	{
	//		//// Put this order as limit order with price as LTP
	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder, Order ID %s changed to Limit", mOrder->m_ptrOrder->ClOrdId);	
	//		ILimitOrderRequest *pRequest = (ILimitOrderRequest *)mOrder;
	//		mOrder->m_ptrOrder->Price = m_ptrMarket->m_OHLCStats.LastPrice;
	//		mOrder->m_ptrOrder->OrderType = ORDER_TYPE_LIMIT_ORDER;

	//		m_ptrMarket->UpdateLimitPrice(pRequest);
	//		m_ptrMarket->AddOrder(pRequest);
	//	}
	//	else
	//	{
	//		// Send Canceled response for rest of the stuff
	//		m_ptrMarket->SendExecutionReport(mOrder, 
	//											mOrder->GetOrderID(),
	//											EXECUTION_TRANSTYPE_NEW,
	//											ORDER_STATUS_CANCEL,
	//											EXECUTION_TYPE_CANCELACK,
	//											mOrder->m_remainingQnty,
	//											0,
	//											0,
	//											0);

	//	}
	//}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder, Exit");	

}

void TradeMarketOrder::ExecuteSellOrder(IMarketOrderRequest* mOrder)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteSellOrder, Entered");	

	if (m_ptrMarket)
	{
		unsigned long tradePrice = 0;
		tradePrice  = m_ptrMarket->GetPrice(QUOTES_STREAM_TYPE_BID);
		
		//mOrder->m_ptrOrder->Price;

		if (tradePrice == 0)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteSellOrder, Price got is 0, taking MP");	
			tradePrice = mOrder->m_ptrOrder->Price;
		}

		mOrder->m_remainingQnty = 0;

		m_ptrMarket->SendTradeReport(NULL,
									 mOrder,
									 mOrder->GetOrderQnty(),
									 tradePrice,
									 false);

		//delete mOrder;

	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteSellOrder, Exit");	
}

void TradeMarketOrder::ExecuteBuyOrder(unsigned long long price)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteBuyOrder Price, Entered");	

	if(m_ptrMarket)
	{
		//string* key = getSymbolKey(mOrder->GetSymbol());
		MARKET_ORDER_LIST& marketOrderList = m_ptrMarket->m_askList;
		
		MARKET_ORDER_LIST_ITER marketOrderIter = marketOrderList.begin();
		bool isErased = false;

		while(marketOrderIter!=marketOrderList.end())
		{
			isErased = false;
			MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
			if(limitOrder)
			{
				unsigned long long executedQ=0;

				if (price >= limitOrder->GetPrice())
				{
					MatchOrder(limitOrder->m_limitOrderList,limitOrder->GetPrice(),executedQ);

					limitOrder->m_volumn -= executedQ;

					if(limitOrder->m_volumn==0)
					{
						marketOrderIter = marketOrderList.erase(marketOrderIter);
						isErased = true;
					}
						

					//	m_ptrMarket->SendQuotes(marketOrderList, 
					//							QUOTES_STREAM_TYPE_ASK,
					//							m_ptrMarket->GetSymbol(),
					//							0);
					//}
					/*else
					{
						unsigned long long Price = 0;
						unsigned long long Qty = 0;

						if (m_ptrMarket->m_askList.size() > 0)
						{
							Price = m_ptrMarket->m_askList[0]->GetPrice();
							Qty = m_ptrMarket->m_askList[0]->GetVolumn();
						}
						else
						{
							Price = 0;
							Qty = 0;
						}

						m_ptrMarket->SendQuotes(Price,
												Qty,
												QUOTES_STREAM_TYPE_ASK,
												m_ptrMarket->m_Symbol,
												0);
					}*/

					//if(mOrder->GetOrderQnty()==0)
					/*if(mOrder->m_remainingQnty==0)
					{
						break;
					}*/
				}
				else
					break;
			}

			if (!isErased)
				marketOrderIter++;
		}


	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteBuyOrder, Exit");	
}

void TradeMarketOrder::ExecuteSellOrder(unsigned long long price)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteSellOrder, Entered");	

	if(m_ptrMarket)
	{
		//string* key = getSymbolKey(mOrder->GetSymbol());
		MARKET_ORDER_LIST& marketOrderList = m_ptrMarket->m_bidList;
		MARKET_ORDER_LIST_ITER marketOrderIter = marketOrderList.begin();
		MARKET_ORDER_LIST_ITER tempIter;
		unsigned int rIdx=0;

		bool isErased = false;
		while(marketOrderIter!=marketOrderList.end())
		{
			isErased = false;
			MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
			if(limitOrder)
			{
				unsigned long long executedQ=0;
				if (price <= limitOrder->GetPrice())
				{
					MatchOrder(limitOrder->m_limitOrderList,limitOrder->GetPrice(),executedQ);
					
					limitOrder->m_volumn -= executedQ;
					if(limitOrder->m_volumn==0)
					{
						tempIter = marketOrderIter;
						marketOrderIter = marketOrderList.erase(tempIter);
						isErased = true;
					}
					//else
					//{
					//	unsigned long long Price = 0;
					//	unsigned long long Qty = 0;

					//	if (m_ptrMarket->m_bidList.size() > 0)
					//	{
					//		Price = m_ptrMarket->m_bidList[0]->GetPrice();
					//		Qty = m_ptrMarket->m_bidList[0]->GetVolumn();
					//	}
					//	else
					//	{
					//		Price = 0;
					//		Qty = 0;
					//	}

					//	m_ptrMarket->SendQuotes(Price,
					//							Qty,
					//							QUOTES_STREAM_TYPE_BID,
					//							m_ptrMarket->m_Symbol,
					//							0);

					//}

					//if(mOrder->GetOrderQnty()==0)
					/*if(mOrder->m_remainingQnty==0)
					{
						break;
					}*/
				}
				else
					break;
			}
			if (!isErased)
				marketOrderIter++;
		}

	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteSellOrder, Exit");	
}

void TradeMarketOrder::ExecuteMarketOrder(IMarketOrderRequest* mOrder)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder, Entered");	

	if(mOrder->GetOrder()->Side==SIDE_BUY)
	{
		EnterCriticalSection(&m_ptrMarket->CS_ASK_LIST);
		ExecuteBuyOrder(mOrder);
		LeaveCriticalSection(&m_ptrMarket->CS_ASK_LIST);
	}
	else if(mOrder->GetOrder()->Side==SIDE_SELL)
	{
		EnterCriticalSection(&m_ptrMarket->CS_BID_LIST);
		ExecuteSellOrder(mOrder);
		LeaveCriticalSection(&m_ptrMarket->CS_BID_LIST);
	}

	if (mOrder->m_remainingQnty > 0)
	{
		if (mOrder->GetTimeInForce()  != TIF_FOK)
		{
			//// Put this order as limit order with price as LTP
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder, Order ID %s changed to Limit", mOrder->m_ptrOrder->ClOrdId);	
			ILimitOrderRequest *pRequest = (ILimitOrderRequest *)mOrder;
			mOrder->m_ptrOrder->Price = m_ptrMarket->m_OHLCStats.LastPrice;
			mOrder->m_ptrOrder->OrderType = ORDER_TYPE_LIMIT_ORDER;

			m_ptrMarket->UpdateLimitPrice(pRequest);
			m_ptrMarket->AddOrder(pRequest);
		}
		else
		{
			// Send Canceled response for rest of the stuff
			m_ptrMarket->SendExecutionReport(mOrder, 
												mOrder->GetOrderID(),
												EXECUTION_TRANSTYPE_NEW,
												ORDER_STATUS_CANCEL,
												EXECUTION_TYPE_CANCELACK,
												mOrder->m_remainingQnty,
												0,
												0,
												0);

		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeMarketOrder::ExecuteMarketOrder, Exit");	
}


symbol &Market::GetSymbol()
{
	return m_Symbol;
}

void Market::SetSymbol(symbol& Symbol)
{
	memcpy(&m_Symbol, &Symbol, sizeof(symbol));
}

// this function is not currently being used
int Market::SendTradeReport(ILimitOrderRequest* order,
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
									unsigned long long Qty)
{
	int nSuccess = 0;

	EventTradeReport *evtObj = new EventTradeReport();

	if (evtObj)
	{
		memcpy(&evtObj->report1, order->m_ptrOrder, sizeof(Order));

		memcpy(&evtObj->report1.Symbol, &m_Symbol, sizeof(m_Symbol));
		evtObj->report1.ExecTransType = execTransType;
		evtObj->report1.ExecType = execType;
		evtObj->report1.OrderStatus = orderStatus;
		evtObj->report1.QtyFilled = Qty;
		evtObj->report1.CumQty = Qty;
		evtObj->report1.LastPx = LastPx;
		evtObj->report1.AvgPx = LastPx;

		evtObj->report1.OrderID = order->m_ptrOrder->OrderID;

		memcpy(&evtObj->report2, order1->m_ptrOrder, sizeof(Order));

		memcpy(&evtObj->report2.Symbol, &m_Symbol, sizeof(m_Symbol));
		evtObj->report2.ExecTransType = execTransType1;
		evtObj->report2.ExecType = execType1;
		evtObj->report2.OrderStatus = orderStatus1;
		evtObj->report2.QtyFilled = Qty;
		evtObj->report2.CumQty = Qty;
		evtObj->report2.LastPx = LastPx;
		evtObj->report2.AvgPx = LastPx;

		evtObj->report2.OrderID = order->m_ptrOrder->OrderID;

		SendOrderResponse(evtObj);
	}

	return nSuccess;
}

int Market::SendTradeReport(ILimitOrderRequest* LimitOrder,
						IMarketOrderRequest *MarketOrder,
						unsigned long long Qty,
						unsigned long long LastPx,
						bool bRequote)
{
	int nSuccess = 0;

	char exectype;
	char Ordstatus;
	char Ordstatus1;

	char temp1[100];
	char temp2[100];

	if (LimitOrder)
	{
		if(LimitOrder->m_remainingQnty==0)
		{
			Ordstatus=ORDER_STATUS_FILLED;
			exectype=EXECUTION_TYPE_FILLED;
		}
		else
		{
			Ordstatus=ORDER_STATUS_PARTIALLY_FILLED;
			exectype=EXECUTION_TYPE_PARTFILLED;
		}		

		
		_ui64toa_s(Qty,temp1,sizeof(temp1),10);
		_ui64toa_s(LastPx,temp2,sizeof(temp2),10);
		

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendTradeReport, Limit Order Executed ClOrderID=%s, Order ID=%lu, Order Status=%c, Qty=%s, Price=%s",
												LimitOrder->m_ptrOrder->ClOrdId,				
												(unsigned long)LimitOrder->m_ptrOrder->OrderID,
												Ordstatus,
												temp1,
												temp2);
		
		SendExecutionReport(LimitOrder,
							LimitOrder->m_ptrOrder->OrderID,
							EXECUTION_TRANSTYPE_NEW,
							Ordstatus,
							exectype,
							Qty,
							Qty,
							LastPx,
							LastPx);

		UpdateOrderOnFill(LimitOrder->m_ptrOrder->OrderID,
							Ordstatus,
							LastPx,
							Qty);
						
	}

	if (MarketOrder)
	{
		if (bRequote)
		{
			Ordstatus1 = ORDER_STATUS_REJECTED;
			exectype = EXECUTION_TYPE_REJECTACK;
		}
		else
		{
			Ordstatus1=ORDER_STATUS_FILLED;
			exectype=EXECUTION_TYPE_FILLED;
		}
		//else
		//{
		//	Ordstatus1=ORDER_STATUS_PARTIALLY_FILLED;
		//	exectype=EXECUTION_TYPE_PARTFILLED;
		//}		
		_ui64toa_s(Qty,temp1,sizeof(temp1),10);
		_ui64toa_s(LastPx,temp2,sizeof(temp2),10);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendTradeReport, Market Order Executed ClOrderID=%s, Order ID=%lu, Order Status=%c, Qty=%s, Price=%s",
												MarketOrder->m_ptrOrder->ClOrdId,				
												(unsigned long)MarketOrder->m_ptrOrder->OrderID,
												Ordstatus1,
												temp1,
												temp2);

		
		SendExecutionReport(MarketOrder,
							MarketOrder->m_ptrOrder->OrderID,
							EXECUTION_TRANSTYPE_NEW,
							Ordstatus1,
							exectype,
							Qty,
							Qty,
							LastPx,
							LastPx,
							"Requote");

		UpdateOrderOnFill(MarketOrder->m_ptrOrder->OrderID,
					Ordstatus1,
					LastPx,
					Qty);

	}


	// Send LTP update to cleint
	/*SendQuotes(LimitOrder->GetPrice(),
				Qty,
				QUOTES_STREAM_TYPE_LAST,
				m_Symbol,
				0);*/

	/*UpdateFillReportinDB(LimitOrder,
							MarketOrder,
							Ordstatus,
							Ordstatus1,
							Qty,
							LastPx);*/

	return nSuccess;
}

int Market::UpdateOrderStatus(unsigned long OrderID,
								char OrderStatus)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	param->AddParam("OrderID", OrderID);
	param->AddParam("OrderStatus", OrderStatus);
	param->AddParam("LPOrdID", 0);
	param->AddParam("Success", nSuccess);

	bool isSPExist = m_pDatabase->Execute("OME_UpdateOrderStatus",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Market::UpdateOrderStatus, Unable to execute SP OME_UpdateOrderOnFilled");
		return -1 ;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}

int Market::UpdateOrderOnFill(unsigned long OrderID,
								char OrderStatus,
								double FillPrice,
								unsigned long long qty)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	param->AddParam("OrderID", OrderID);
	param->AddDateTimeParam("LastUpdateTime", COleDateTime::GetCurrentTime());
	param->AddParam("OrderStatusID", OrderStatus);
	param->AddParam("AvgFillPRice", FillPrice);
	param->AddParam("FilledQty", qty);

	bool isSPExist = m_pDatabase->Execute("OME_UpdateOMEOrders",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Market::UpdateOrderOnFill, Unable to execute SP OME_UpdateOMEOrders");
		return -1 ;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}


int Market::UpdateFillReportinDB(ILimitOrderRequest* LimitOrder,
							IMarketOrderRequest *MarketOrder,
							char OrdStatus,
							char OrdStatus1,
							unsigned long long Qty,
							unsigned long long LastPx)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	if (LimitOrder->GetSide() == SIDE_BUY)
	{
		param->AddParam("BuySideOrderID", LimitOrder->GetOrderID());
		param->AddParam("SellSideOrderID", MarketOrder->GetOrderID());
	}
	else
	{
		param->AddParam("BuySideOrderID", MarketOrder->GetOrderID());
		param->AddParam("SellSideOrderID", LimitOrder->GetOrderID());
	}

	param->AddDateTimeParam("LastUpdateTime", 0);
	param->AddParam("FilledQty", Qty);

	if (LimitOrder->GetSide() == SIDE_BUY)
	{
		param->AddParam("BuyOrderStatusID", OrdStatus );
		param->AddParam("SellOrderStatusID", OrdStatus1);
	}
	else
	{
		param->AddParam("BuyOrderStatusID", OrdStatus1);
		param->AddParam("SellOrderStatusID", OrdStatus);
	}

	param->AddParam("LastPrice", LastPx);

	if (LimitOrder->GetSide() == SIDE_BUY)
	{
		param->AddParam("BuySide", LimitOrder->GetSide() );
		param->AddParam("SellSide", MarketOrder->GetSide());
	}
	else
	{
		param->AddParam("BuySide", MarketOrder->GetSide());
		param->AddParam("SellSide", LimitOrder->GetSide());
	}

	int size = sizeof(LimitOrder->m_ptrOrder->Symbol.Contract);
	param->AddParam("Symbol", LimitOrder->GetContract(size), size);

	if (LimitOrder->GetSide() == SIDE_BUY)
	{
		param->AddParam("BuySideAccountID", LimitOrder->GetAccount() );
		param->AddParam("SellSideAccountID", MarketOrder->GetAccount());
	}
	else
	{
		param->AddParam("BuySideAccountID", MarketOrder->GetAccount());
		param->AddParam("SellSideAccountID", LimitOrder->GetAccount());
	}

	param->AddParam("Success", nSuccess, 2);

	bool isSPExist = m_pDatabase->Execute("OME_UpdateOrderOnFilled",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Market::UpdateFillReportinDB, Unable to execute SP OME_UpdateOrderOnFilled");
		return -1 ;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}


int Market::SendQuotes(unsigned long long Price,
							unsigned long long Qty,
							char type,
							symbol& Symbol,
							int marketLevel)
{
	int nSuccess = 0;

	//__time64_t currentTime;
	//_time64(&currentTime);

	QuotesStreamResponse * evtObj1=new QuotesStreamResponse();
	evtObj1->m_Market = this;

	//if (Price != 0 && Qty != 0)
	{
		QuotesItem q;
		q.Price = Price;
		q.QuotesStreamType = type;
		q.Size = Qty;

		memcpy(&q.Symbol, &Symbol, sizeof(symbol));
		q.Time = 0;
		q.MarketLevel = marketLevel;

		evtObj1->m_Quotes.insert(evtObj1->m_Quotes.end(),q);
	}

	SendOrderResponse(evtObj1);

	return nSuccess;
}


void Market::SendExecutionReport(ILimitOrderRequest* order,
								unsigned long OrderID,
								char execTransType,
								char orderStatus,
								char execType,
								unsigned long long Qty,
								unsigned long long CumQty,
								unsigned long long LastPx,
								unsigned long long AvgPx,
								char *reason)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport, Entered");	

	EventExecutionReport *evtObj = new EventExecutionReport();

	memcpy(&evtObj->report, order->m_ptrOrder, sizeof(Order));

	memcpy(&evtObj->report.Symbol, &m_Symbol, sizeof(m_Symbol));
	evtObj->report.ExecTransType = execTransType;
	evtObj->report.ExecType = execType;
	evtObj->report.OrderStatus = orderStatus;
	evtObj->report.QtyFilled = Qty;
	evtObj->report.CumQty = Qty;
	evtObj->report.LastPx = LastPx;
	evtObj->report.AvgPx = LastPx;
	evtObj->report.TransactTime = COleDateTime::GetCurrentTime();

	evtObj->report.OrderID = order->m_ptrOrder->OrderID;

	if (reason)
	{
		strcpy(evtObj->report.Text, reason);
	}

	SendOrderResponse(evtObj);

	UpdateOrderStatus(OrderID, orderStatus);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport, Exit");	
}

void Market::SendExecutionReport(IStopOrderRequest* order,
								unsigned long OrderID,
								char execTransType,
								char orderStatus,
								char execType,
								unsigned long long Qty,
								unsigned long long CumQty,
								unsigned long long LastPx,
								unsigned long long AvgPx,
								char *reason)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport, Entered");	

	EventExecutionReport *evtObj = new EventExecutionReport();

	memcpy(&evtObj->report, order->m_ptrOrder, sizeof(Order));

	memcpy(&evtObj->report.Symbol, &m_Symbol, sizeof(m_Symbol));
	evtObj->report.ExecTransType = execTransType;
	evtObj->report.ExecType = execType;
	evtObj->report.OrderStatus = orderStatus;
	evtObj->report.QtyFilled = Qty;
	evtObj->report.CumQty = Qty;
	evtObj->report.LastPx = LastPx;
	evtObj->report.AvgPx = LastPx;
	evtObj->report.TransactTime = COleDateTime::GetCurrentTime();

	evtObj->report.OrderID = order->m_ptrOrder->OrderID;

	if (reason)
	{
		strcpy(evtObj->report.Text, reason);
	}

	SendOrderResponse(evtObj);

	UpdateOrderStatus(OrderID, orderStatus);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport, Exit");	
}

void Market::SendExecutionReport(ICancelOrderRequest* order,
								unsigned long OrderID,
								char execTransType,
								char orderStatus,
								char execType,
								unsigned long long Qty,
								unsigned long long CumQty,
								unsigned long long LastPx,
								unsigned long long AvgPx,
								char *reason)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport - 1, Entered");	

	EventExecutionReport *evtObj = new EventExecutionReport();

	memcpy(&evtObj->report, order->m_ptrOrder, sizeof(Order));
	memcpy(&evtObj->report.Symbol, &m_Symbol, sizeof(m_Symbol));

	evtObj->report.ExecTransType = execTransType;
	evtObj->report.ExecType = execType;
	evtObj->report.OrderStatus = orderStatus;
	evtObj->report.QtyFilled = Qty;
	evtObj->report.CumQty = CumQty;
	evtObj->report.LastPx = LastPx;
	evtObj->report.AvgPx = AvgPx;
	evtObj->report.TransactTime = COleDateTime::GetCurrentTime();

	evtObj->report.OrderID = order->m_ptrOrder->OrderID;

	if (reason)
	{
		strcpy(evtObj->report.Text, reason);
	}

	SendOrderResponse(evtObj);

	// Update order status as canceled
	UpdateOrderStatus(OrderID, orderStatus);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport - 1, Exit");	
}


void Market::SendExecutionReport(IMarketOrderRequest* order,
								unsigned long OrderID,
								char execTransType,
								char orderStatus,
								char execType,
								unsigned long long Qty,
								unsigned long long CumQty,
								unsigned long long LastPx,
								unsigned long long AvgPx,
								char *reason)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport - 2, Entered");	

	EventExecutionReport *evtObj = new EventExecutionReport();

	memcpy(&evtObj->report, order->m_ptrOrder, sizeof(Order));
	memcpy(&evtObj->report.Symbol, &m_Symbol, sizeof(m_Symbol));

	evtObj->report.ExecTransType = execTransType;
	evtObj->report.ExecType = execType;
	evtObj->report.OrderStatus = orderStatus;
	evtObj->report.QtyFilled = Qty;
	evtObj->report.CumQty = Qty;
	evtObj->report.LastPx = LastPx;
	evtObj->report.AvgPx = LastPx;
	evtObj->report.TransactTime = COleDateTime::GetCurrentTime();

	if (reason)
	{
		strcpy(evtObj->report.Text, reason);
	}

	evtObj->report.OrderID = order->m_ptrOrder->OrderID;

	SendOrderResponse(evtObj);

	UpdateOrderStatus(OrderID, orderStatus);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::SendExecutionReport - 2, Exit");	
}

int Market::CalculateOHLC(QuotesItem *item, unsigned long long& open, unsigned long long& high, unsigned long long& low, unsigned long long& prcClose)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CalculateOHLC, Entered");	

	int nValChanged = 0;

	m_OHLCStats.LastPrice = item->Price;
	m_OHLCStats.LastSize = item->Size;
	m_OHLCStats.LastTime = item->Time;

	if (m_OHLCStats.Open == 0)
	{
		// this is the first price, so update all
		m_OHLCStats.Open = item->Price;
		open = item->Price;
		nValChanged |= MASKOpen;

		m_OHLCStats.Low = item->Price;
		low = item->Price;
		nValChanged |= MASKLow;
	}

	// Check High 
	if (item->Price > m_OHLCStats.High)
	{
		m_OHLCStats.High = item->Price;
		high = item->Price;
		nValChanged |= MASKHigh;
	}

	if (item->Price < m_OHLCStats.Low)
	{
		m_OHLCStats.Low = item->Price;
		low = item->Price;
		nValChanged |= MASKLow;
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CalculateOHLC, Exit");	

	return nValChanged;
}

bool Market::CancelOrder(ICancelOrderRequest* mOrder, bool bReplace)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelOrder, Entered");	

	bool bSuccess = true;
	bool bSendReject = false;

	if (mOrder->GetOrderType() == ORDER_TYPE_STOP_LIMIT_ORDER ||
		mOrder->GetOrderType() == ORDER_TYPE_STOP_ORDER)
	{
		if(mOrder->GetOrder()->Side==SIDE_BUY)
		{
			EnterCriticalSection(&CS_STOP_BID_LIST);
			bSuccess = CancelStopBid(mOrder, bReplace);
			LeaveCriticalSection(&CS_STOP_BID_LIST);
		}
		else if(mOrder->GetOrder()->Side==SIDE_SELL)
		{
			EnterCriticalSection(&CS_STOP_ASK_LIST);
			bSuccess = CancelStopAsk(mOrder, bReplace);
			LeaveCriticalSection(&CS_STOP_ASK_LIST);
		}
	}

	if (bSuccess == false)
	{
		if (mOrder->GetOrderType() == ORDER_TYPE_STOP_LIMIT_ORDER)
		{
			mOrder->m_ptrOrder->Price = mOrder->m_ptrOrder->StopPx;
		}
		else
			bSendReject = true;
	}

	if (!bSendReject && (!bSuccess  || mOrder->GetOrderType() == ORDER_TYPE_LIMIT_ORDER))
	{
		if(mOrder->GetOrder()->Side==SIDE_BUY)
		{
			EnterCriticalSection(&CS_BID_LIST);
			bSuccess = CancelBid(mOrder, bReplace);
			LeaveCriticalSection(&CS_BID_LIST);
		}
		else if(mOrder->GetOrder()->Side==SIDE_SELL)
		{
			EnterCriticalSection(&CS_ASK_LIST);
			bSuccess = CancelAsk(mOrder, bReplace);
			LeaveCriticalSection(&CS_ASK_LIST);
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelOrder, Exit");	

	return bSuccess;
}

void Market::CancelReplaceOrder(ICancelReplaceOrderRequest* order)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelReplaceOrder, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);
	bool bSuccess = false;

	bSuccess = CancelOrder(order->m_pCancelOrderRequest);

	if (bSuccess)
	{
		// Place a new order
		if (order->m_NewOrder.OrderType == ORDER_TYPE_LIMIT_ORDER)
		{
			AddOrder(order->m_pLimitOrderRequest);
		}
		else if (order->m_NewOrder.OrderType == ORDER_TYPE_MARKET_ORDER)
		{
			GetTradeMarketOrder()->ExecuteMarketOrder(order->m_pMarketOrderRequest);
		}
		else if (order->m_NewOrder.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER ||
				order->m_NewOrder.OrderType == ORDER_TYPE_STOP_ORDER)
		{
			AddOrder((IStopOrderRequest *)order->m_pLimitOrderRequest);
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelReplaceOrder, Exit");	
}

bool Market::CancelAsk(ICancelOrderRequest* order, bool bReplace)
{
	bool bSuccess = false;
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelAsk, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_ASK_LIST);
	bSuccess = CancelOrderToSymbol(order,m_askList,&strKey,'A', bReplace);

	LeaveCriticalSection(&CS_ASK_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelAsk, Exit");	

	return bSuccess;
}


bool Market::CancelBid(ICancelOrderRequest* order, bool bReplace)
{
	bool bSuccess = false;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Cancel Bid, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_BID_LIST);
	bSuccess = CancelOrderToSymbol(order,m_bidList,&strKey,'B', bReplace);

	LeaveCriticalSection(&CS_BID_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Cancel Bid, Exit");	

	return bSuccess;
}

bool Market::CancelOrderToSymbol(ICancelOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type, bool bReplace)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelOrderToSymbol, Entered");	

	bool bSuccess = false;

	IMarketOrder* marketOrder=new MarketOrder(order);
	int position = 0;

	MARKET_ORDER_LIST_ITER listIterBegin= list.begin();
	MARKET_ORDER_LIST_ITER listIterEnd= list.end();
	MARKET_ORDER_LIST_ITER listIter=find_if(listIterBegin,listIterEnd,CompareRef<IMarketOrder*>(marketOrder));

	if (listIter != listIterEnd)
	{
		ILimitOrderRequest *req = (*listIter)->CancelLimitOrder(order);			

		if (req)
		{
			if (bReplace)
			{
				//req->m_ptrOrder->Account = order->m_ptrOrder->Account;
				SendExecutionReport(req,
									req->GetOrderID(),
									EXECUTION_TRANSTYPE_NEW,
									ORDER_STATUS_REPLACED,
									EXECUTION_TYPE_MODIFYACK,
									req->m_remainingQnty,
									0,
									0,
									0);
			}
			else
			{
				//req->m_ptrOrder->Account = order->m_ptrOrder->Account;
				// Send Cancel confirm execution report
				SendExecutionReport(req,
									req->GetOrderID(),
									EXECUTION_TRANSTYPE_NEW,
									ORDER_STATUS_CANCEL,
									EXECUTION_TYPE_CANCELACK,
									req->m_remainingQnty,
									0,
									0,
									0);
			}

			bSuccess = true;
			bool bErased = false;
			

			if ((*listIter)->GetVolumn() == 0)
			{
				// Erase the node
				listIter = list.erase(listIter);
				bErased = true;
			}
			// Send quotes update if needed
			// Find the position
			/*int pos = 0;
			bool posfound = false;*/

			/*if (list.empty())
			{
				SendQuotes(0,
							0,
							type,
							m_Symbol,
							position);
			}
			else
			{*/
			/*	SendQuotes(list,
							listIter,
							type,
							m_Symbol,
							bErased);*/
				/*for (pos = 0; pos < 5 && pos < list.size();pos++)
				{
					if ((*list[pos]).GetPrice() == (*listIter)->GetPrice())
					{
						position = pos;
						posfound = true;
						break;
					}
				}*/
			//}

			/*if (posfound)
			{
				if (bErased)
				{
					SendQuotes(list,
								type,
								m_Symbol,
								position);
				}
				else
				{
					SendQuotes((*listIter)->GetPrice(),
								(*listIter)->GetVolumn(),
								type,
								m_Symbol,
								position);
				}
			}*/
		}
		else
		{
			// Send Cancel reject
			SendExecutionReport(order,
				order->GetOrderID(),
				EXECUTION_TRANSTYPE_NEW,
				ORDER_STATUS_ORDER_NOT_FOUND,
				EXECUTION_TYPE_REJECTACK,
				0,
				0,
				0,
				0,
				"Order Not found");
		}
	}

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelOrderToSymbol, Exit");	

	return bSuccess;
}


bool Market::CancelStopAsk(ICancelOrderRequest* order, bool bReplace)
{
	bool bSuccess = false;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelStopAsk, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_STOP_ASK_LIST);
	
	bSuccess = CancelStopOrderToSymbol(order,m_StopAskList,&strKey,'B', bReplace);

	LeaveCriticalSection(&CS_STOP_ASK_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelAsk, Exit");	

	return bSuccess;
}


bool Market::CancelStopBid(ICancelOrderRequest* order, bool bReplace)
{
	bool bSuccess = false;

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Cancel Bid, Entered");	

	string strKey;
	getSymbolKey(order->GetSymbol(), strKey);

	EnterCriticalSection(&CS_STOP_BID_LIST);
	bSuccess = CancelStopOrderToSymbol(order,m_StopBidList,&strKey,'A', bReplace);

	LeaveCriticalSection(&CS_STOP_BID_LIST);

//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::Cancel Bid, Exit");	

	return bSuccess;
}

bool Market::CancelStopOrderToSymbol(ICancelOrderRequest* order,MARKET_ORDER_LIST& list,string* strKey, char type, bool bReplace)
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::CancelStopOrderToSymbol, Entered");	

	bool bSuccess = false;

	IMarketOrder* marketOrder=new MarketOrder(order);
	int position = 0;

	MARKET_ORDER_LIST_ITER listIterBegin= list.begin();
	MARKET_ORDER_LIST_ITER listIterEnd= list.end();
	MARKET_ORDER_LIST_ITER listIter=find_if(listIterBegin,listIterEnd,CompareRef<IMarketOrder*>(marketOrder));

	if (listIter != listIterEnd)
	{
		IStopOrderRequest *req = (*listIter)->CancelStopOrder(order);			

		if (req)
		{
			if (bReplace)
			{
				// Send Cancel confirm execution report
				SendExecutionReport(req,
									req->GetOrderID(),
									EXECUTION_TRANSTYPE_NEW,
									ORDER_STATUS_REPLACED,
									EXECUTION_TYPE_MODIFYACK,
									req->m_remainingQnty,
									0,
									0,
									0);
			}
			else
			{
				// Send Cancel confirm execution report
				SendExecutionReport(req,
									req->GetOrderID(),
									EXECUTION_TRANSTYPE_NEW,
									ORDER_STATUS_CANCEL,
									EXECUTION_TYPE_CANCELACK,
									req->m_remainingQnty,
									0,
									0,
									0);
			}

			bSuccess = true;
			bool bIsErased = false;

			if ((*listIter)->GetVolumn() == 0)
			{
				// Erase the node
				listIter = list.erase(listIter);
				bIsErased = true;
			}
		}
		else
		{
			// Send Cancel reject
			SendExecutionReport(order,
				order->GetOrderID(),
				EXECUTION_TRANSTYPE_NEW,
				ORDER_STATUS_ORDER_NOT_FOUND,
				EXECUTION_TYPE_REJECTACK,
				0,
				0,
				0,
				0,
				"Order Not found");
		}
	}

	return bSuccess;
}

int Market::SendQuotes( MARKET_ORDER_LIST& pList,
						MARKET_ORDER_LIST::iterator& listIterator,
						char type,
						symbol& Symbol,
						bool bIsDepthChanged)
{
	int nSuccess = 0;

	if (pList.empty())
	{
			nSuccess = SendQuotes(0,
								0,
								type,
								m_Symbol,
								0);
	}
	else
	{
		int index = (listIterator) - (pList.begin());

		if (bIsDepthChanged)
		{
			nSuccess = SendQuotes(pList,
									type,
									m_Symbol,
									index);
		}
		else
		{
			nSuccess = SendQuotes((*listIterator)->GetPrice(),
								(*listIterator)->GetVolumn(),
								type,
								m_Symbol,
								index);
		}
	}

	return nSuccess;
}


int Market::SendQuotes( MARKET_ORDER_LIST& list,
						char type,
						symbol& Symbol,
						int currentPosition)
{
	int nSuccess = 0;
	int position = currentPosition;
	//__time64_t currentTime;
	//_time64(&currentTime);

	if (position < MARKET_DEPTH)
	{
		// Send DOM update for all below this price
		QuotesStreamResponse * evtObj=new QuotesStreamResponse();
		evtObj->m_Market = this;

		int nCount = 0;
		for (;position < MARKET_DEPTH && position < list.size(); position++)
		{
			QuotesItem q;
			q.Price = list[position]->GetPrice();
			q.QuotesStreamType = type;
			//q.Size = list[position]->GetVolumn();
			q.Size = list[position]->GetVolumn();
			//memcpy(q.Symbol.Contract, m_contractName.c_str(), sizeof(q.Symbol.Contract));
			memcpy(&q.Symbol, &Symbol, sizeof(symbol));
			q.Time = 0; // Need to change to correct date

			q.MarketLevel = position;

			evtObj->m_Quotes.insert(evtObj->m_Quotes.end(),q);
			nCount ++;
		}

		if (position < MARKET_DEPTH)
		{
			for (;position < MARKET_DEPTH; position++)
			{
				QuotesItem q;
				q.Price = 0;
				q.QuotesStreamType = type;
				q.Size = 0;
				//memcpy(q.Symbol.Contract, m_contractName.c_str(), sizeof(q.Symbol.Contract));
				memcpy(&q.Symbol, &Symbol, sizeof(symbol));
				q.Time = 0; 

				q.MarketLevel = position;

				evtObj->m_Quotes.insert(evtObj->m_Quotes.end(),q);
				nCount ++;
			}
		}

		SendOrderResponse(evtObj);
	}

	return nSuccess;
}

void Market::SendSnapshotResponse()
{
	EventSnapshotResponse *pEvent = new EventSnapshotResponse();

	memcpy(&m_OHLCStats.Symbol, &m_Symbol, sizeof(m_Symbol));
	
	int nCount = 0;
	int TotalCount = m_bidList.size() > m_askList.size()? m_bidList.size():m_askList.size();

	for (nCount =0; nCount < TotalCount && nCount < MARKET_DEPTH; nCount++)
	{
		if (nCount < m_askList.size())
		{
			m_OHLCStats.MarketDepth[nCount].AskPrice = m_askList[nCount]->GetPrice();
			m_OHLCStats.MarketDepth[nCount].AskSize = m_askList[nCount]->GetVolumn();
			m_OHLCStats.MarketDepth[nCount].AskTime = 0;
		}
		else
		{
			m_OHLCStats.MarketDepth[nCount].AskPrice = 0;
			m_OHLCStats.MarketDepth[nCount].AskSize = 0;
			m_OHLCStats.MarketDepth[nCount].AskTime = 0;
		}

		if (nCount < m_bidList.size())
		{
			m_OHLCStats.MarketDepth[nCount].BidPrice = m_bidList[nCount]->GetPrice();
			m_OHLCStats.MarketDepth[nCount].BidSize = m_bidList[nCount]->GetVolumn();
			m_OHLCStats.MarketDepth[nCount].BidTime = 0;
		}
		else
		{
			m_OHLCStats.MarketDepth[nCount].BidPrice = 0;
			m_OHLCStats.MarketDepth[nCount].BidSize = 0;
			m_OHLCStats.MarketDepth[nCount].BidTime = 0;
		}

		strcpy(m_OHLCStats.MarketDepth[nCount].Gateway,"ECX");
		m_OHLCStats.MarketDepth[nCount].Level = nCount;
	}

	m_OHLCStats.MarketDepthLevel = TotalCount;

	memcpy(&pEvent->report, &m_OHLCStats, sizeof(pEvent->report));

	SendOrderResponse(pEvent);
}

void Market::ExpireStopOrders(MARKET_ORDER_LIST& list1)
{
	MARKET_ORDER_LIST::iterator iter = list1.begin();
	
	for (;iter != list1.end();iter++)
	{
		MarketOrder* pMarketOrder=dynamic_cast<MarketOrder*>(*iter);

		EnterCriticalSection(&pMarketOrder->CS_LIMIT_ORDER_LIST);
		STOP_ORDER_REQUEST_LIST& list = pMarketOrder->GetStopOrderList();

		STOP_ORDER_REQUEST_LIST::iterator orderIter = list.begin();

		for (;!list.empty() && orderIter != list.end(); orderIter++)
		{
			IStopOrderRequest *pRequest = (*orderIter);

			if (pRequest)
			{
				if (pRequest->GetTimeInForce() == TIF_DAY)
				{
					// Expire Orders
					SendExecutionReport(pRequest,
										pRequest->GetOrderID(),
										EXECUTION_TRANSTYPE_NEW,
										ORDER_STATUS_EXPIRED,
										EXECUTION_TYPE_ELIMINATIONACK,
										0, 0, 0, 0);

					orderIter = list.erase(orderIter);

					if (pRequest)
						delete pRequest;

					if (list.empty())
						break;
				}
				else if (pRequest->GetTimeInForce() == TIF_GOOD_TILL_DATE)
				{
					//if (pRequest->GetExpireDate() > currentTime)
					//{
					//	// Check the expiry date and if expired, expire orders
					//	orderIter = list.erase(orderIter);

					//	SendExecutionReport(pRequest,
					//						pRequest->GetOrderID(),
					//						EXECUTION_TRANSTYPE_NEW,
					//						ORDER_STATUS_EXPIRED,
					//						EXECUTION_TYPE_ELIMINATIONACK,
					//						0, 0, 0, 0);
					//}
				}
			}
		}

		if (list.empty())
		{
			iter = list1.erase(iter);
		}

		LeaveCriticalSection(&pMarketOrder->CS_LIMIT_ORDER_LIST);

		if (list1.empty())
			break;
	}
}



void Market::ExpireOrders(MARKET_ORDER_LIST& list1)
{
	MARKET_ORDER_LIST::iterator iter = list1.begin();
	
	for (;iter != list1.end();)
	{
		MarketOrder* pMarketOrder=dynamic_cast<MarketOrder*>(*iter);

		EnterCriticalSection(&pMarketOrder->CS_LIMIT_ORDER_LIST);
		LIMIT_ORDER_REQUEST_LIST& list = pMarketOrder->GetLimitOrderList();

		LIMIT_ORDER_REQUEST_LIST::iterator orderIter = list.begin();

		for (;!list.empty() && orderIter != list.end(); )
		{
			ILimitOrderRequest *pRequest = (*orderIter);

			if (pRequest)
			{
				if (pRequest->GetTimeInForce() == TIF_DAY)
				{
					// Expire Orders
					SendExecutionReport(pRequest,
										pRequest->GetOrderID(),
										EXECUTION_TRANSTYPE_NEW,
										ORDER_STATUS_EXPIRED,
										EXECUTION_TYPE_ELIMINATIONACK,
										0, 0, 0, 0);

					orderIter = list.erase(orderIter);

					if (pRequest)
						delete pRequest;

					if (list.empty())
						break;
				}
				else if (pRequest->GetTimeInForce() == TIF_GOOD_TILL_DATE)
				{
					orderIter++;
					//if (pRequest->GetExpireDate() > currentTime)
					//{
					//	// Check the expiry date and if expired, expire orders
					//	orderIter = list.erase(orderIter);

					//	SendExecutionReport(pRequest,
					//						pRequest->GetOrderID(),
					//						EXECUTION_TRANSTYPE_NEW,
					//						ORDER_STATUS_EXPIRED,
					//						EXECUTION_TYPE_ELIMINATIONACK,
					//						0, 0, 0, 0);
					//}
				}
				else
					orderIter++;
			}
		}

		if (list.empty())
		{
			iter = list1.erase(iter);
		}
		else
			iter++;

		LeaveCriticalSection(&pMarketOrder->CS_LIMIT_ORDER_LIST);

		if (list1.empty())
			break;
	}
}

void Market::HandleEODProcessing()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::HandleEODProcessing, Entered");	

	EnterCriticalSection(&CS_ASK_LIST);
	ExpireOrders(m_askList);
	LeaveCriticalSection(&CS_ASK_LIST);

	EnterCriticalSection(&CS_BID_LIST);
	ExpireOrders(m_bidList);
	LeaveCriticalSection(&CS_BID_LIST);

	EnterCriticalSection(&CS_STOP_BID_LIST);
	ExpireStopOrders(m_StopBidList);
	LeaveCriticalSection(&CS_STOP_BID_LIST);

	EnterCriticalSection(&CS_STOP_ASK_LIST);
	ExpireStopOrders(m_StopAskList);
	LeaveCriticalSection(&CS_STOP_ASK_LIST);

	ResetOHLCStats();
	SendNULLMarketData();
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Market::HandleEODProcessing, Exit");	
}


int Market::TriggerStopOrders(unsigned long price, char side)
{
	int nSuccess = 0;

	// Traverse thru all Stop orders and put them as either Limit or Market order using existing functions
	MARKET_ORDER_LIST_ITER marketOrderIter;

	if (side == SIDE_SELL)
	{
		EnterCriticalSection(&CS_STOP_ASK_LIST);
		MARKET_ORDER_LIST& marketOrderList = m_StopAskList;
		
		marketOrderIter = marketOrderList.begin();

		while(marketOrderIter!=marketOrderList.end())
		{
			MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
			if(limitOrder)
			{
				if (limitOrder->GetPrice() >= price)
				{
					EnterCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
					//. Traverse thru all orders and put it in limit queue
					STOP_ORDER_REQUEST_LIST StopList = limitOrder->GetStopOrderList();
					STOP_ORDER_REQUEST_LIST::iterator SORL = StopList.begin();

					for (;!StopList.empty() && SORL != StopList.end();)
					{
						IStopOrderRequest *pStopOrder = (*SORL);

						if (pStopOrder)
						{
							// Add it as limit Order
							SORL = StopList.erase(SORL);
							TriggerStopOrderEvent *tsEvent = new TriggerStopOrderEvent(pStopOrder);
							tsEvent->m_pMarket = this;
							SendOrderResponse(tsEvent);

							continue;
						}

						if (StopList.empty())
							break;

						SORL++;
					}

					marketOrderIter = marketOrderList.erase(marketOrderIter);

					LeaveCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
				}
				else
					break;
			}
		}	

		LeaveCriticalSection(&CS_STOP_ASK_LIST);
	}
	else if (side == SIDE_BUY)
	{
		EnterCriticalSection(&CS_STOP_BID_LIST);
		MARKET_ORDER_LIST& marketOrderList1 = m_StopBidList;
		
		marketOrderIter = marketOrderList1.begin();

		while(marketOrderIter!=marketOrderList1.end())
		{
			MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
			if(limitOrder)
			{
				if (limitOrder->GetPrice() <= price)
				{
					EnterCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
					//. Traverse thru all orders and put it in limit queue
					STOP_ORDER_REQUEST_LIST StopList = limitOrder->GetStopOrderList();
					STOP_ORDER_REQUEST_LIST::iterator SORL = StopList.begin();

					for (;!StopList.empty() && SORL != StopList.end(); )
					{
						IStopOrderRequest *pStopOrder = (*SORL);

						if (pStopOrder)
						{
							// Add it as limit Order
							SORL = StopList.erase(SORL);
							TriggerStopOrderEvent *tsEvent = new TriggerStopOrderEvent(pStopOrder);
							tsEvent->m_pMarket = this;
							SendOrderResponse(tsEvent);

							continue;
						}

						if (StopList.empty())
							break;

						SORL++;
					}

					marketOrderIter = marketOrderList1.erase(marketOrderIter);

					LeaveCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
				}
				else
					break;
			}
		}	

	LeaveCriticalSection(&CS_STOP_BID_LIST);
	}

	return nSuccess;
}


int Market::ExecuteLimitOrders(unsigned long Bid, unsigned long Ask)
{
	int nSuccess = 0;

	// Traverse thru all Stop orders and put them as either Limit or Market order using existing functions

	//EnterCriticalSection(&CS_STOP_ASK_LIST);
	//MARKET_ORDER_LIST& marketOrderList = m_StopAskList;
	//
	//MARKET_ORDER_LIST_ITER marketOrderIter = marketOrderList.begin();

	//while(marketOrderIter!=marketOrderList.end())
	//{
	//	MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
	//	if(limitOrder)
	//	{
	//		if (limitOrder->GetPrice() >= LTP)
	//		{
	//			EnterCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
	//			//. Traverse thru all orders and put it in limit queue
	//			STOP_ORDER_REQUEST_LIST StopList = limitOrder->GetStopOrderList();
	//			STOP_ORDER_REQUEST_LIST::iterator SORL = StopList.begin();

	//			for (;!StopList.empty() && SORL != StopList.end();)
	//			{
	//				IStopOrderRequest *pStopOrder = (*SORL);

	//				if (pStopOrder)
	//				{
	//					// Add it as limit Order
	//					SORL = StopList.erase(SORL);
	//					TriggerStopOrderEvent *tsEvent = new TriggerStopOrderEvent(pStopOrder);
	//					tsEvent->m_pMarket = this;
	//					SendOrderResponse(tsEvent);

	//					continue;
	//				}

	//				if (StopList.empty())
	//					break;

	//				SORL++;
	//			}

	//			marketOrderIter = marketOrderList.erase(marketOrderIter);

	//			LeaveCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
	//		}
	//		else
	//			break;
	//	}
	//}	

	//LeaveCriticalSection(&CS_STOP_ASK_LIST);


	//EnterCriticalSection(&CS_STOP_BID_LIST);
	//MARKET_ORDER_LIST& marketOrderList1 = m_StopBidList;
	//
	//marketOrderIter = marketOrderList1.begin();

	//while(marketOrderIter!=marketOrderList1.end())
	//{
	//	MarketOrder* limitOrder=dynamic_cast<MarketOrder*>(*marketOrderIter);
	//	if(limitOrder)
	//	{
	//		if (limitOrder->GetPrice() <= LTP)
	//		{
	//			EnterCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
	//			//. Traverse thru all orders and put it in limit queue
	//			STOP_ORDER_REQUEST_LIST StopList = limitOrder->GetStopOrderList();
	//			STOP_ORDER_REQUEST_LIST::iterator SORL = StopList.begin();

	//			for (;!StopList.empty() && SORL != StopList.end(); )
	//			{
	//				IStopOrderRequest *pStopOrder = (*SORL);

	//				if (pStopOrder)
	//				{
	//					// Add it as limit Order
	//					SORL = StopList.erase(SORL);
	//					TriggerStopOrderEvent *tsEvent = new TriggerStopOrderEvent(pStopOrder);
	//					tsEvent->m_pMarket = this;
	//					SendOrderResponse(tsEvent);

	//					continue;
	//				}

	//				if (StopList.empty())
	//					break;

	//				SORL++;
	//			}

	//			marketOrderIter = marketOrderList1.erase(marketOrderIter);

	//			LeaveCriticalSection(&limitOrder->CS_STOP_ORDER_LIST);
	//		}
	//		else
	//			break;
	//	}
	//}	

	//LeaveCriticalSection(&CS_STOP_BID_LIST);

	return nSuccess;
}

void Market::UpdateStopOrderAsTriggered(IStopOrderRequest *pRequest)
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool bTriggered = true;
	int nSuccess = false;

	param->AddParam("OrderID", pRequest->GetOrderID());
	param->AddParam("IsTriggered", bTriggered);
	param->AddParam("Success", nSuccess);

	bool isSPExist = m_pDatabase->Execute("OME_UpdateIsTriggered",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Market::OME_UpdateIsTriggered, Unable to execute SP OME_UpdateOrderOnFilled");
		return ;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void Market::UpdateLimitPrice(ILimitOrderRequest *pRequest)
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool bTriggered = true;
	int nSuccess = false;

	param->AddParam("OrderID", pRequest->GetOrderID());
	param->AddParam("LimitPrice", bTriggered);
	param->AddParam("Success", nSuccess);

	bool isSPExist = m_pDatabase->Execute("OME_UpdateLimitPrice",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Market::OME_UpdateLimitPrice, Unable to execute SP OME_UpdateOrderOnFilled");
		return  ;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void Market::UpdatePrice(QuotesItem *pItem)
{
	if (pItem->MarketLevel == 0)
	{
		if (pItem->QuotesStreamType == QUOTES_STREAM_TYPE_ASK)
		{
			m_ulAsk = pItem->Price;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, 
							stl::log::LOG_LEVEL_NORMAL,
							"Market::UpdatePrice, ASK Symbol= %s, Price = %lu",
							pItem->Symbol.Contract,
							pItem->Price);
			printf("Market::UpdatePrice, ASK Symbol= %s, Price = %lu",
				pItem->Symbol.Contract,
				pItem->Price);
			
			/*GetTradeMarketOrder()->ExecuteMarketOrder(m_ulAsk, SIDE_SELL);
			TriggerStopOrders(m_ulAsk, SIDE_BUY);*/
		}
		else if (pItem->QuotesStreamType == QUOTES_STREAM_TYPE_BID)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, 
							stl::log::LOG_LEVEL_NORMAL,
							"Market::UpdatePrice, BID Symbol= %s, Price = %lu",
							pItem->Symbol.Contract,
							pItem->Price);

			printf("Market::UpdatePrice, BID Symbol= %s, Price = %lu",
				pItem->Symbol.Contract,
				pItem->Price);

			m_ulBid = pItem->Price;
			/*GetTradeMarketOrder()->ExecuteMarketOrder(m_ulBid, SIDE_BUY);
			TriggerStopOrders(m_ulBid, SIDE_SELL);*/
		}
		else if (pItem->QuotesStreamType == QUOTES_STREAM_TYPE_LAST)
		{
			printf("Market::UpdatePrice, LAST Symbol= %s, Price = %lu",
				pItem->Symbol.Contract,
				pItem->Price);

			m_ulLTP = pItem->Price;
			GetTradeMarketOrder()->ExecuteMarketOrder(m_ulLTP, SIDE_SELL);
			GetTradeMarketOrder()->ExecuteMarketOrder(m_ulLTP, SIDE_BUY);
			TriggerStopOrders(m_ulLTP, SIDE_BUY);
			TriggerStopOrders(m_ulLTP, SIDE_SELL);

			
		//	unsigned long open, high, low, close;

		//	QuotesStream* msg= (QuotesStream*)GetMessageObject(QUOTES_STREAM);

		//	if (msg)
		//	{
		//		int val = CalculateOHLC(pItem, open, high, low, close);

		//		if (val != 0)
		//		{
		//			int nCount = 0;

		//			if (val & MASKOpen)
		//			{
		//				msg->QuotesItem[nCount].MarketLevel = 0;
		//				msg->QuotesItem[nCount].Price = open;
		//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
		//				msg->QuotesItem[nCount].Size = 0;
		//				memcpy(&msg->QuotesItem[nCount].Symbol, &GetSymbol(), sizeof(symbol));
		//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
		//				
		//				msg->QuotesItem[nCount].Time = time(0);

		//				nCount ++;
		//			}

		//			if (val & MASKHigh)
		//			{
		//				msg->QuotesItem[nCount].MarketLevel = 0;
		//				msg->QuotesItem[nCount].Price = high;
		//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
		//				msg->QuotesItem[nCount].Size = 0;
		//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
		//				memcpy(&msg->QuotesItem[nCount].Symbol, &GetSymbol(), sizeof(symbol));
		//				msg->QuotesItem[nCount].Time = 0;

		//				nCount ++;
		//			}

		//			if (val & MASKLow)
		//			{
		//				msg->QuotesItem[nCount].MarketLevel = 0;
		//				msg->QuotesItem[nCount].Price = low;
		//				msg->QuotesItem[nCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
		//				msg->QuotesItem[nCount].Size = 0;
		//				//memcpy(msg->QuotesItem[nCount].Symbol.Contract, market->GetContractName(), sizeof(msg->QuotesItem[nCount].Symbol.Contract));
		//				memcpy(&msg->QuotesItem[nCount].Symbol, &GetSymbol(), sizeof(symbol));
		//				msg->QuotesItem[nCount].Time = 0;

		//				nCount ++;
		//			}

		//			// Send and reset the object
		//			msg->NoOfSymbols = nCount;
		//			m_ptrConnectionMgrMDE->SendResponseToQueue(m_ptrServerBL->GetClientIDMDE(), msg, QUOTES_STREAM);
		//			free(msg);
		//		}
		//	}

		}

		//free(pItem);
	}
}


unsigned long Market::GetPrice(char type)
{
	unsigned long price = 0;

	if (type == QUOTES_STREAM_TYPE_ASK)
	{
		price = m_ulAsk;
	}
	else if (type == QUOTES_STREAM_TYPE_BID)
	{
		price = m_ulBid;
	}
	else if (type == QUOTES_STREAM_TYPE_LAST)
	{
		price = m_ulLTP;
	}

	/*unsigned long pp = (unsigned long)price;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG,"Market::GetPrice, Symbol=%s, Type=%c, Price=%lu",
		m_Symbol.Contract,
		type,
		pp);*/


	return price;
}

double Market::GetOrderDelay()
{
	return m_OrderDelay;
}

double Market::GetSlippage()
{
	return m_Slippage;
}

double Market::GetOrderVolume()
{
	return m_OrderVolume;
}

void Market::ResetOHLCStats()
{
	memset(&m_OHLCStats.MarketDepth, 0, sizeof(m_OHLCStats.MarketDepth));
	m_OHLCStats.Close = m_OHLCStats.LastPrice;
}

void Market::SendNULLMarketData()
{
	EventSnapshotResponse *pEvent = new EventSnapshotResponse();

	memcpy(&m_OHLCStats.Symbol, &m_Symbol, sizeof(m_Symbol));
	
	int nCount = 0;
	int TotalCount = MARKET_DEPTH;

	for (nCount =0; nCount < MARKET_DEPTH; nCount++)
	{
		strcpy(m_OHLCStats.MarketDepth[nCount].Gateway,"ECX");
		m_OHLCStats.MarketDepth[nCount].Level = nCount;
	}

	m_OHLCStats.MarketDepthLevel = TotalCount;

	memcpy(&pEvent->report, &m_OHLCStats, sizeof(pEvent->report));

	SendOrderResponse(pEvent);
}

void Market::UpdateOHLC(unsigned int uOpen, unsigned int uHigh, unsigned int uLow, unsigned int uClose)
{
	EnterCriticalSection(&CS_OHLC);

	m_OHLCStats.Open = uOpen;
	m_OHLCStats.High = uHigh;
	m_OHLCStats.Low = uLow;
	m_OHLCStats.Close = uClose;

	LeaveCriticalSection(&CS_OHLC);
}