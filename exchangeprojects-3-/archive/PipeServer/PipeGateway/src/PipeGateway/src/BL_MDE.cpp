/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "BL_MDE.h"
#include "API.h"
#include "IRequestQuote.h"
#include "IRequestNews.h"
#include <algorithm>
#include "xConfigure.h"
#include "SessionHandler.h"
#include "xlogger.h"
#include "time.h"
#include "pipeserver.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "BL_MDE"

#define		CONFIG_FILE		"MDEServerSetting.ini"

BL_MDE::BL_MDE()
:_ptrIConnectionMgr(NULL)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::BL_MDE, entered");

	m_nClientID = 0;
	ReadConfig();

	InitializeCriticalSection(&m_cs);
	InitializeCriticalSection(&m_csQuotes);

	if (InitializeDatabase() == 0)
	{
		LoadAllAssociatedConversions();

		m_pPipeServer = new CPipeServer();

		if (m_pPipeServer)
		{
			m_pPipeServer->Create(this, "MT5", CPipeServer::Callback); 
		}
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::BL_MDE, Unable to initialize DB");
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::BL_MDE, Exit");
}

BL_MDE::~BL_MDE()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::~BL_MDE, entered");

	// Disconnect all clients
	if (_ptrDatabase)
	{
		_ptrDatabase->CloseDBConnection();
		ReleaseDatabase(_ptrDatabase);
		_ptrDatabase = NULL;
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::!~BL_MDE, Exit");
}

int	BL_MDE::InitializeDatabase()
{
	int nSuccess = 0;

	_ptrDatabase = CreateDatabase(); 

	if (_ptrDatabase)
	{
		if( ! _ptrDatabase->Open( _strDBUserName.c_str() , _strDBPassword.c_str() , _strConnString.c_str() ) )
		{
			ReleaseDatabase( _ptrDatabase );
			_ptrDatabase = NULL;
			nSuccess = -1;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::InitializeDatabase, Unable to open OMS DB");
		}
	}

	return nSuccess;
}

IRequest* BL_MDE::getIRequestPointer(MESSAGE msg)
{
	IRequest* ptrIRequest = NULL;

	switch(msg.msgType)
	{
	case LOGON_REQUEST:
		//ptrIRequest = new SessionHandler(msg.msgType, msg.msg, _ptrIConnectionMgr, _ptrIConnectionMgr->GetClientSession(msg.clientId), _ptrDatabase);
		break;
	case QUOTE__DOM_REQUEST:
	case QUOTE__SNAPSHOT_REQUEST:
		break;
	case QUOTE__REQUEST:
		{
			/*QuoteRequest* ptrQuoteRequest = ( QuoteRequest* )msg.msg;

			ptrIRequest = new IRequestQuote(ptrQuoteRequest, msg.clientId, msg.msgType, _ptrIConnectionMgr->GetClientSession(msg.clientId), this);*/
		}
		break;
	//case NEWS__REQUEST:
	//	{
	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::getIRequestPointer, News request Recv. Client ID: %d", msg.clientId);
	//		pnewsRequest req =  ( pnewsRequest )GetMessageObject(msg.msgType);
	//		memcpy(req,msg.msg,sizeof(NewsRequest));
	//		ptrIRequest = new IRequestNews(req, msg.clientId , this );
	//	}
	//	break;
	/*case LOGON_RESPONSE:
		break;*/
	default:
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::getIRequestPointer, Unknown request Recv. Client ID: %d", msg.clientId);
		}
	}

	//free(msg.msg);
	//msg.msg = NULL;

	return ptrIRequest;
}

void BL_MDE::onNewClientAdded(unsigned clientID, IConnectionMgr * mgr)
{
	m_nClientID = clientID;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::onNewClientAdded, Entered");
}

void BL_MDE::onClientDisconnected(unsigned clientID)
{
	m_nClientID = 0;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "BL_MDE::onClientDisconnected, Entered");

}

void BL_MDE::setConnectionMgr(IConnectionMgr* ptrIConnectionMgr)
{
	_ptrIConnectionMgr = ptrIConnectionMgr;
}


void BL_MDE::submitQuoteRequest(QuoteRequest *pRequest, unsigned clientID, unsigned int msgType, bool isForSubscribe /*= true*/ )
{
	//std::map<std::string, std::list<symbol>> mapSubscriptionList;
	//std::list<OHLC> lstQuotes;

	//QuoteRequest req;

	//memset(&req, 0, sizeof(req));
	//int nSymbolsCount = 0;

	//EnterCriticalSection(&m_csSubscribers);

	//for (int nCount = 0; nCount < pRequest->NoOfSymbols; nCount++)
	//{
	//	std::string key;
	//	GetKey(pRequest->Symbol[nCount], key);

	//	// Add the symbol to the Client -> symbol map
	//	EnterCriticalSection(&m_csClientSymbolList);

	//	MAP_CLIENT_SYMBOL_LIST::iterator iterClientSymList = m_mapClientSymbolList.find(clientID);

	//	if (iterClientSymList != m_mapClientSymbolList.end())
	//	{
	//		SYMBOL_LIST& symList = iterClientSymList->second;

	//		SYMBOL_LIST::iterator symListIter = std::find(symList.begin(), symList.end(), key);

	//		if (symListIter == symList.end())
	//		{
	//			std::map<std::string, std::list<symbol>>::iterator iterRequestList = mapSubscriptionList.find(pRequest->Symbol[nCount].Gateway);

	//			if (iterRequestList != mapSubscriptionList.end())
	//			{
	//				std::list<symbol>& lstSymbols = iterRequestList->second;

	//				lstSymbols.push_back(pRequest->Symbol[nCount]);
	//			}
	//			else
	//			{
	//				std::list<symbol> lstSymbols;
	//				lstSymbols.push_back(pRequest->Symbol[nCount]);

	//				std::pair<std::string, std::list<symbol>> pr(pRequest->Symbol[nCount].Gateway, lstSymbols);
	//				mapSubscriptionList.insert(pr);
	//			}

	//			// symbol not found. Add it here
	//			symList.push_back(key);
	//		}
	//		else
	//		{
	//			LeaveCriticalSection(&m_csClientSymbolList);
	//			// symbol is already subscribed.
	//			continue;
	//		}
	//	}
	//	else
	//	{
	//		// client is not added. Add it here
	//		SYMBOL_LIST lstSymbols;

	//		lstSymbols.push_back(key);
	//		std::pair<unsigned int, SYMBOL_LIST> pr(clientID, lstSymbols);

	//		m_mapClientSymbolList.insert(pr);

	//		std::list<symbol> lstSymbols1;
	//		lstSymbols1.push_back(pRequest->Symbol[nCount]);

	//		std::pair<std::string, std::list<symbol>> pr1(pRequest->Symbol[nCount].Gateway, lstSymbols1);
	//		mapSubscriptionList.insert(pr1);
	//	}

	//	LeaveCriticalSection(&m_csClientSymbolList);

	//	MAP_CONTRACT_GROUP_MAP::iterator iter = m_mapSubscribers.find(key);

	//	if (iter != m_mapSubscribers.end())
	//	{
	//		// Found the symbol
	//		MAP_GROUP_CLIENTLIST& groupClientList = iter->second;

	//		MAP_GROUP_CLIENTLIST::iterator iter1 = groupClientList.find(nGroupID);

	//		if (iter1 != groupClientList.end())
	//		{
	//			SUBSCRIBED_LIST& list = iter1->second;

	//			SUBSCRIBED_LIST::iterator it = list.find(clientID);

	//			if (it != list.end())
	//			{
	//				// Found the client. Do nothing
	//				SubscribedClient& stSubsClient = it->second;

	//				if (msgType == QUOTE__REQUEST)
	//				{
	//					stSubsClient.bSubscribedQuotes = true;
	//				}
	//				else if (msgType == QUOTE__DOM_REQUEST)
	//				{
	//					stSubsClient.bSubscribeDOM = true;
	//				}
	//			}
	//			else
	//			{
	//				SubscribedClient stSubsClient;
	//				
	//				if (msgType == QUOTE__REQUEST)
	//				{
	//					stSubsClient.bSubscribedQuotes = true;
	//				}
	//				else if (msgType == QUOTE__DOM_REQUEST)
	//				{
	//					stSubsClient.bSubscribeDOM = true;
	//				}

	//				std::pair<unsigned int, SubscribedClient> pr(clientID, stSubsClient);
	//				list.insert(pr);
	//			}
	//		}
	//		else
	//		{
	//			// Group not found
	//			SubscribedClient stSubsClient;
	//			
	//			if (msgType == QUOTE__REQUEST)
	//			{
	//				stSubsClient.bSubscribedQuotes = true;
	//			}
	//			else if (msgType == QUOTE__DOM_REQUEST)
	//			{
	//				stSubsClient.bSubscribeDOM = true;
	//			}

	//			std::pair<unsigned int, SubscribedClient> pr(clientID, stSubsClient);

	//			SUBSCRIBED_LIST list;
	//			list.insert(pr);

	//			std::pair<unsigned int, SUBSCRIBED_LIST> pr1(nGroupID, list);
	//			groupClientList.insert(pr1);
	//		}
	//	}
	//	else
	//	{
	//		// Not found symbol. Need to send subscription request to the server
	//		memcpy(&req.Symbol[nSymbolsCount], &pRequest->Symbol[nCount], sizeof(req.Symbol[nCount]));
	//		nSymbolsCount++;

	//		// Add to the list
	//		SubscribedClient stSubsClient;
	//		
	//		if (msgType == QUOTE__REQUEST)
	//		{
	//			stSubsClient.bSubscribedQuotes = true;
	//		}
	//		else if (msgType == QUOTE__DOM_REQUEST)
	//		{
	//			stSubsClient.bSubscribeDOM = true;
	//		}

	//		std::pair<unsigned int, SubscribedClient> pr(clientID, stSubsClient);

	//		SUBSCRIBED_LIST list;
	//		list.insert(pr);

	//		MAP_GROUP_CLIENTLIST mapGroupClientList;
	//		std::pair<unsigned int, SUBSCRIBED_LIST> pr1(nGroupID, list);

	//		mapGroupClientList.insert(pr1);

	//		std::pair<std::string, MAP_GROUP_CLIENTLIST> pr2(key, mapGroupClientList);
	//		m_mapSubscribers.insert(pr2);
	//	}
	//}

	//LeaveCriticalSection(&m_csSubscribers);

	///*if (!lstQuotes.empty())
	//{
	//	SendSnapshotResponse(clientID, lstQuotes);
	//}*/

	////lstQuotes.clear();
	//if (!mapSubscriptionList.empty())
	//{
	//	SubscribeQuotes(mapSubscriptionList);
	//}

	//mapSubscriptionList.clear();
}


void BL_MDE::submitNewsRequest( unsigned long ulAccount, unsigned clientID, bool isForSubscribe /*= true*/ )
{
	pnewsRequest ptrNewsRequest = (pnewsRequest )GetMessageObject( NEWS__REQUEST );
	ptrNewsRequest->isForSubscribe = isForSubscribe;

	ptrNewsRequest->Account = ulAccount;
}

void BL_MDE::onNewsStream(NewsStream* ptrNewsStream)
{
}

void BL_MDE::removeNewsSubscribers(unsigned int clientID)
{
}





void BL_MDE::BroadcastQuoteItem( QuotesStream *pStream)
{
	//IClientSessionMgr *mgr = m_serverProtocol->GetClientSessionManager();


	//_ptrIConnectionMgr->GetClientSession()
	if (_ptrIConnectionMgr && m_nClientID != 0)
		_ptrIConnectionMgr->SendResponseToQueue(m_nClientID, pStream, QUOTES_STREAM);
}


API IServerBL* __stdcall CreateBusinessObject ()
{
	return new BL_MDE();
}

void BL_MDE::onNewClientAdded(IClientSession *clientID)
{
}

unsigned int BL_MDE::GetClientID()
{
	return 0;
}


unsigned int BL_MDE::GetClientIDMDE()
{
	return 0;
}

void BL_MDE::ReadConfig()
{
	long port = 0;
	xconfigure ConfigObj( CONFIG_FILE);
	ConfigObj.GetParameterString( "DATABASE", std::string("CONN_STRING"), _strConnString); 
	ConfigObj.GetParameterString( "DATABASE", std::string("USERNAME"), _strDBUserName); 
	ConfigObj.GetParameterString( "DATABASE", std::string("PASSWORD"), _strDBPassword); 

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::ReadConfig, DATABASE:ConnString = %s,Username = %s, Password = %s",
													_strConnString.c_str(),
													_strDBUserName.c_str(),
													_strDBPassword.c_str());

}




void BL_MDE::SubmitAllQuotes()
{
	//itSUBSCRIBER_MAP itSubscribers = _QuoteSubscribers.begin();

	//for (;itSubscribers != _QuoteSubscribers.end(); itSubscribers++)
	//{
	//	std::string symbolKey = (*itSubscribers).first;

	//	pSymbol sym = getSymbolStruct(symbolKey);
	//	std::string xx;
	//	std::string xx1 = sym->Product;
	//	std::string xx2 = sym->Contract;
	//	std::string xx3= sym->Gateway;
	//	
	//	xx.append(1, sym->ProductType);
	//	MDE_Symbol sym1(xx, xx1, xx2, xx3);

	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "Quote Request sent after disconnection. Contract %s",sym->Contract) ;

	//	pQuoteRequest req =  getQuoteRequestPacket(&sym1,true,QUOTE__REQUEST);
	//	Send(sym1, req, QUOTE__REQUEST);

	//	delete sym;
	//}
}


double BL_MDE::GetConversionFormula(std::string symbol)
{
	double lfConversionFormula = 1;

	EnterCriticalSection(&m_cs);

	std::map<std::string, double>::iterator iter = m_mapConversionFormula.find(symbol);

	if (iter != m_mapConversionFormula.end())
	{
		lfConversionFormula = (*iter).second;
	}

	LeaveCriticalSection(&m_cs);

	return lfConversionFormula;
}

void BL_MDE::LoadAllAssociatedConversions()
{
	
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	char szTradingGateway[] = "ECX";
	param->AddParam("TradingGateway", szTradingGateway, sizeof(szTradingGateway));

	bool isSPExist = _ptrDatabase->Execute("Exchange_GetListOfConversionFormula",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDF::LoadAllAssociatedAccounts, Unable to execute SP Exchange_ListOfTradingAccountWithLPAccountID");
		//nSuccess = ERR_INTERNAL_ERROR_DB;
		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		return;
	}

	EnterCriticalSection(&m_cs);

	tb->MoveFirst();
	char szSymbol[20];
	while(!tb->IsEOF())//loop the table
	{
		double lfConversionFormula = 0;
		tb->Get("Symbol", szSymbol, sizeof(szSymbol));
		tb->Get("Conversion_Formula", lfConversionFormula);

		std::map<std::string, double>::iterator iter = m_mapConversionFormula.find(	szSymbol);		

		if (iter == m_mapConversionFormula.end())
		{
			// insert the account details here
			m_mapConversionFormula.insert(std::pair<std::string, double>(szSymbol, lfConversionFormula));
		}

		tb->MoveNext();
	}

	LeaveCriticalSection(&m_cs);

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}


void BL_MDE::PrepareQuotesStream(MQLTick& tick, 
								 char type, 
								 QuotesStream& stream, 
								 double valMult, 
								 COleDateTime& oleDate, 
								 int MarketLevel, 
								 std::string Gateway,
								 double Price
								 )
{
	memcpy(stream.QuotesItem[stream.NoOfSymbols].Symbol.Product,tick.contract,sizeof(char)*20);
	memcpy(stream.QuotesItem[stream.NoOfSymbols].Symbol.Contract,tick.contract,sizeof(char)*20);
	memcpy(stream.QuotesItem[stream.NoOfSymbols].Symbol.Gateway,Gateway.c_str(),sizeof(char)*20);
	stream.QuotesItem[stream.NoOfSymbols].Symbol.ProductType = tick.productType;

	double tempPrice = Price * valMult;

	char szPrice[100];
	sprintf(szPrice, "%lf", tempPrice);


	stream.QuotesItem[stream.NoOfSymbols].MarketLevel = MarketLevel;
	stream.QuotesItem[stream.NoOfSymbols].Time = oleDate.m_dt;
	stream.QuotesItem[stream.NoOfSymbols].QuotesStreamType = type;
	stream.QuotesItem[stream.NoOfSymbols].Price = _atoi64(szPrice);

	if (type == QUOTES_STREAM_TYPE_ASK)
	{
		stream.QuotesItem[stream.NoOfSymbols].Size = (unsigned long long)tick.dAskSize * 100.0;
	}
	else if (type == QUOTES_STREAM_TYPE_BID)
	{
		stream.QuotesItem[stream.NoOfSymbols].Size = (unsigned long long)tick.dBidSize* 100.0;
	}
	else if (type == QUOTES_STREAM_TYPE_LAST)
	{
		stream.QuotesItem[stream.NoOfSymbols].Size = (unsigned long long)tick.dLastSize* 100.0;
	}
	
	stream.NoOfSymbols++;

	if (stream.NoOfSymbols >= MAX_SYMBOL)
	{
		BroadcastQuoteItem(&stream);
		stream.NoOfSymbols = 0;
	}
}


void BL_MDE::ManipulateMQLTick(MQLTick& tick, MQLTick& dest)
{
	//EnterCriticalSection(&m_csQuotes);

	std::map<std::string, MQLTick>::iterator iter = m_mapQuotes.find(tick.contract);

	if (iter != m_mapQuotes.end())
	{
		MQLTick& tick1 = iter->second;

		if (tick1.Ask == tick.Ask)
			dest.Ask = 0;

		if (tick1.Bid == tick.Bid)
			dest.Bid = 0;

		if (tick1.dClose == tick.dClose)
			dest.dClose = 0;

		if (tick1.dHigh == tick.dHigh)
			dest.dHigh = 0;

		if (tick1.dLow == tick.dLow)
			dest.dLow = 0;

		if (tick1.dOpen == tick.dOpen)
			dest.dOpen = 0;

		if (tick.LTP == 0)
		{
			tick.LTP = (tick.Ask + tick.Bid) /2.0;
			dest.LTP = tick.LTP;
		}

		if (tick1.LTP == tick.LTP)
			dest.LTP = 0;

		memcpy(&tick1, &tick, sizeof(tick));
	}
	else
	{
		std::pair<std::string, MQLTick> pr(tick.contract, tick);
		m_mapQuotes.insert(pr);
	}

	//LeaveCriticalSection(&m_csQuotes);
}