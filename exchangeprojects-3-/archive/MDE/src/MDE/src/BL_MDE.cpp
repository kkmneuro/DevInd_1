/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//16 Dec 2013	BR					Ticket TradingApplication/92. Modified function BL_MDE::PrepareBroadcastData
//									to send the packet in middle when the MAX_SYMBOL are inserted in QuotesStream pkt.
//05 Feb 2014	BR					Tradingapplication/114.
//									Modify following
//									1. Modified Login and Logout responses to include username
//									2. Modify the QuotesStream and SnapshotResponse to include AccountNo
//									Modified accepted version to 1.15
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "BL_MDE.h"
#include "API.h"
#include "MDEDataManager.h"
#include "IRequestQuote.h"
#include "IRequestNews.h"
#include <algorithm>
#include "xConfigure.h"
#include "SessionHandler.h"
#include "xlogger.h"
#include "time.h"
#include "ATLCOMTime.h"
#include "stdio.h"
#include "UtilitiesAPI.h"

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


BL_MDE* BL_MDE::m_instance = NULL;

BL_MDE* BL_MDE::GetInstance()
{
	if (!m_instance)
	{
		m_instance = new BL_MDE();
	}

	return m_instance;
}

BL_MDE::BL_MDE()
:_ptrIConnectionMgr(NULL)
{
	CoInitializeEx(NULL, COINIT_MULTITHREADED);
	_ptrContractManagerPtr.CreateInstance(CLSID_ContractManager);

	CComGITPtr<IContractManager> GITInterface(_ptrContractManagerPtr);
	m_dwGitCookie = GITInterface.Detach();

	/*if (_ptrContractManagerPtr)
	{
		_ptrContractManagerPtr->InitializeServer();
		_ptrContractManagerPtr->WriteContractsFile();
	}*/

	m_pMDEDataManager = new MDEDataManager(this, m_dwGitCookie);

	if (!m_pMDEDataManager)
	{
		// Error
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::BL_MDE, m_pMDEDataManager is NULL");
	}

	ReadConfig();
	InitializeDatabase();

	DWORD dwThreadID = 0;
	m_fpBulkQuotes = NULL;

	InitializeCriticalSection(&m_csGroupSymbolList);
	InitializeCriticalSection(&m_csSubscribers);
	InitializeCriticalSection(&m_csClientSymbolList);
	InitializeCriticalSection(&m_csLiveFeed);

	m_hLiveEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
	
	LoadAllGroupSymbolSpread();	
	//SetupthreadPools();

	CreateLoggerThread();
	CreateBulkInsertThread();

	LoadAllGateways();

	SendSignal(SERVER_MDE, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_EXTERNAL_CONNS_UP);

	// Start the KA Server
	StartKAthread(SERVER_MDE);
}

BL_MDE::~BL_MDE()
{
	std::map<std::string, MDFClient *>::iterator iter = _ptrMDFClientList.begin();

	if (!_ptrMDFClientList.empty())
	{
		while (true)
		{
			MDFClient *pClient = (*iter).second;

			if (pClient)
			{
				delete pClient;
			}

			if (iter == _ptrMDFClientList.end())
				break;

			iter++;
		}
	}

	_ptrMDFClientList.clear();

	// Disconnect all clients
	m_mapGroupSymbol.clear();

	if (_ptrDatabase)
	{
		_ptrDatabase->CloseDBConnection();
		ReleaseDatabase(_ptrDatabase);
		_ptrDatabase = NULL;
	}

	if (m_pMDEDataManager)
	{
		delete m_pMDEDataManager;
		m_pMDEDataManager = NULL;
	}

	DeleteCriticalSection(&m_csGroupSymbolList);
	DeleteCriticalSection(&m_csSubscribers);
	DeleteCriticalSection(&m_csClientSymbolList);
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

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::InitializeDatabase, Unable to open OMS DB");
		}
	}

	_ptrDatabaseMDE = CreateDatabase(); 

	if (_ptrDatabaseMDE)
	{
		if( ! _ptrDatabaseMDE->Open( _strDBUserNameMDE.c_str() , _strDBPasswordMDE.c_str() , _strConnStringMDE.c_str() ) )
		{
			ReleaseDatabase( _ptrDatabaseMDE );
			_ptrDatabaseMDE = NULL;
			nSuccess = -1;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::InitializeDatabase, Unable to open MDE DB");
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
	case LOGOUT_REQUEST:
		ptrIRequest = new SessionHandler(msg.msgType, msg.msg, _ptrIConnectionMgr, _ptrIConnectionMgr->GetClientSession(msg.clientId), _ptrDatabase);
		break;
	case QUOTE__DOM_REQUEST:
	case QUOTE__SNAPSHOT_REQUEST:
		break;
	case QUOTE__REQUEST:
		{
			QuoteRequest* ptrQuoteRequest = ( QuoteRequest* )msg.msg;

			if (ptrQuoteRequest)
			{
				ptrIRequest = new IRequestQuote(ptrQuoteRequest, msg.clientId, msg.msgType, _ptrIConnectionMgr->GetClientSession(msg.clientId), this);
			}
		}
		break;
	case RELOAD_CONFIG:
		{
			ReloadConfiguration *pConfig = (ReloadConfiguration *)msg.msg;

			if (pConfig && pConfig->type == RELOAD_MARKUP)
			{
				ReLoadAllGroupSymbolSpread();
			}
		}
		break;
	default:
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::getIRequestPointer, Unknown request Recv. Client ID: %d %d", msg.clientId, msg.msgType);
		}
	}

	//free(msg.msg);
	//msg.msg = NULL;

	return ptrIRequest;
}

void BL_MDE::onNewClientAdded(unsigned clientID, IConnectionMgr * mgr)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "BL_MDE::onNewClientAdded, Entered");
}

void BL_MDE::onClientDisconnected(unsigned clientID)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "BL_MDE::onClientDisconnected, Entered");

	removeQuoteSubscribers( clientID );
}

void BL_MDE::setConnectionMgr(IConnectionMgr* ptrIConnectionMgr)
{
	_ptrIConnectionMgr = ptrIConnectionMgr;
}

void BL_MDE::GetKey(symbol& sym, std::string& key)
{
	key.append(sym.Gateway);
	key.append("_");
	key.append(sym.Contract);
}

int	BL_MDE::SendSnapshotResponse(unsigned int nClientID, std::list<OHLC *>& lstMDEQuotesItem)
{
	int nSuccess = 0;
	int nSymbolsCount = 0;

	std::list<OHLC *>::iterator iter = lstMDEQuotesItem.begin();

	if (!lstMDEQuotesItem.empty())
	{
		QuotesSnapshotResponse *pResponse = (QuotesSnapshotResponse *)GetMessageObject(QUOTE_SNAP_SHOT_RESPONSE);

		while(iter != lstMDEQuotesItem.end())
		{
			OHLC *item = (*iter);

			if (item)
			{
				if (pResponse)
				{
					//item.GetOHLC(pResponse->OHLC[nSymbolsCount]);
					memcpy(&pResponse->OHLC[nSymbolsCount], item, sizeof(OHLC));

					nSymbolsCount++;

					if (nSymbolsCount >= MAX_OHLC)
					{
						pResponse->NoOfSymbols = nSymbolsCount;
						IClientSession *pSession = _ptrIConnectionMgr->GetClientSession(nClientID);

						if (pSession)
						{
							memcpy(pResponse->UserName, pSession->GetUserNameA(), sizeof(pResponse->UserName));
						}
						else
						{
							memset(pResponse->UserName, 0, sizeof(pResponse->UserName));
						}

						_ptrIConnectionMgr->SendResponseToQueue(nClientID, pResponse, QUOTE_SNAP_SHOT_RESPONSE);

						//free(pResponse);
						nSymbolsCount = 0;
					}
				}

				free(item);
			}

			iter++;
		}

		if (nSymbolsCount > 0)
		{
			pResponse->NoOfSymbols = nSymbolsCount;
			_ptrIConnectionMgr->SendResponseToQueue(nClientID, pResponse, QUOTE_SNAP_SHOT_RESPONSE);
			//free(pResponse);
			nSymbolsCount = 0;
		}

		free(pResponse);
	}

	return nSuccess;
}

int	BL_MDE::SubscribeQuotes(std::map<std::string, std::list<symbol>>& mapGatewaySymList)
{
	int nSuccess = 0;
	int nSymbolCount = 0;

	std::map<std::string, std::list<symbol>>::iterator iter = mapGatewaySymList.begin();

	QuoteRequest *pRequest = (QuoteRequest *)GetMessageObject(QUOTE__REQUEST);

	if (pRequest)
	{
		if (!mapGatewaySymList.empty())
		{
			while (iter != mapGatewaySymList.end())
			{
				std::string strGateway = iter->first;

				std::map<std::string, MDFClient *>::iterator iter1 = _ptrMDFClientList.find(strGateway);

				if (iter1 != _ptrMDFClientList.end())
				{
					// Prapare the Quote Request and send to the Gateway
					std::list<symbol>& symList = iter->second;
					MDFClient *pClient = iter1->second;

					if (pClient)
					{
						std::list<symbol>::iterator iter2 = symList.begin();

						if (!symList.empty())
						{
							while (iter2 != symList.end())
							{
								symbol& sym = *iter2;

								memcpy(&pRequest->Symbol[nSymbolCount], &sym, sizeof(sym));
								iter2++;
								nSymbolCount++;

								// Boundary Condition
								if (nSymbolCount >= MAX_SYMBOL)
								{
									pRequest->isForSubscribe = true;
									pRequest->NoOfSymbols = nSymbolCount;
									// Send to Gateway and reset
									Send(pClient, pRequest, QUOTE__REQUEST);

									nSymbolCount = 0;
								}
							}

							if (nSymbolCount > 0)
							{
								pRequest->isForSubscribe = true;
								pRequest->NoOfSymbols = nSymbolCount;
								Send(pClient, pRequest, QUOTE__REQUEST);
							}
						}
					}
				}

				iter++;
			}
		}
	}

	return nSuccess;
}


void BL_MDE::submitQuoteRequest(QuoteRequest *pRequest, unsigned clientID, unsigned int msgType, int nGroupID, bool isForSubscribe /*= true*/ )
{
	// the mapping is for Gateway, symbol list
	std::map<std::string, std::list<symbol>> mapSubscriptionList;

	// OHLC that are already stored for snapshot response
	std::list<OHLC *> lstQuotes;


	QuoteRequest req;

	memset(&req, 0, sizeof(req));
	int nSymbolsCount = 0;

	EnterCriticalSection(&m_csSubscribers);

	for (int nCount = 0; nCount < pRequest->NoOfSymbols; nCount++)
	{
		std::string key;
		GetKey(pRequest->Symbol[nCount], key);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::submitQuoteRequest, Symbol = %s, client id = %u", key.c_str(), clientID);

		// Add the symbol to the Client -> symbol map
		EnterCriticalSection(&m_csClientSymbolList);

		MAP_CLIENT_SYMBOL_LIST::iterator iterClientSymList = m_mapClientSymbolList.find(clientID);

		// found client
		if (iterClientSymList != m_mapClientSymbolList.end())
		{
			SYMBOL_LIST& symList = iterClientSymList->second;

			// check if the symbol is already present
			SYMBOL_LIST::iterator symListIter = std::find(symList.begin(), symList.end(), key);

			if (symListIter == symList.end())
			{
				// symbol is not present
				// Search for the Gateway in the mapSubscriptionList. 
				std::map<std::string, std::list<symbol>>::iterator iterRequestList = mapSubscriptionList.find(pRequest->Symbol[nCount].Gateway);

				if (iterRequestList != mapSubscriptionList.end())
				{
					// Gateway found. Add the symbol to the list
					std::list<symbol>& lstSymbols = iterRequestList->second;

					lstSymbols.push_back(pRequest->Symbol[nCount]);
				}
				else
				{
					// Gateway not found, insert the gateway, symbol list pair in the map
					std::list<symbol> lstSymbols;
					lstSymbols.push_back(pRequest->Symbol[nCount]);

					std::pair<std::string, std::list<symbol>> pr(pRequest->Symbol[nCount].Gateway, lstSymbols);
					mapSubscriptionList.insert(pr);
				}

				// symbol not found. Add it to the m_mapClientSymbolList
				symList.push_back(key);
			}
			else
			{
				LeaveCriticalSection(&m_csClientSymbolList);
				// symbol is already subscribed.
				continue;
			}
		}
		else
		{
			// client is not added. Add it here
			SYMBOL_LIST lstSymbols;

			lstSymbols.push_back(key);
			std::pair<unsigned int, SYMBOL_LIST> pr(clientID, lstSymbols);

			m_mapClientSymbolList.insert(pr);

			std::list<symbol> lstSymbols1;
			lstSymbols1.push_back(pRequest->Symbol[nCount]);

			std::pair<std::string, std::list<symbol>> pr1(pRequest->Symbol[nCount].Gateway, lstSymbols1);
			mapSubscriptionList.insert(pr1);
		}

		LeaveCriticalSection(&m_csClientSymbolList);

		MAP_SYMBOL_SUBSLIST::iterator iter = m_mapSubscribers.find(key);

		if (iter != m_mapSubscribers.end())
		{
			// Found the symbol
			SUBSCRIBED_LIST& list = iter->second;

			SUBSCRIBED_LIST::iterator it = list.find(clientID);

			if (it != list.end())
			{
				// Found the client. Do nothing
				SubscribedClient& stSubsClient = it->second;

				if (msgType == QUOTE__REQUEST)
				{
					stSubsClient.bSubscribedQuotes = true;
				}
				else if (msgType == QUOTE__DOM_REQUEST)
				{
					stSubsClient.bSubscribeDOM = true;
				}
			}
			else
			{
				SubscribedClient stSubsClient;
				
				if (msgType == QUOTE__REQUEST)
				{
					stSubsClient.bSubscribedQuotes = true;
				}
				else if (msgType == QUOTE__DOM_REQUEST)
				{
					stSubsClient.bSubscribeDOM = true;
				}

				std::pair<unsigned int, SubscribedClient> pr(clientID, stSubsClient);
				list.insert(pr);
			}
		}
		else
		{
			// Not found symbol. Need to send subscription request to the server
			
			memcpy(&req.Symbol[nSymbolsCount], &pRequest->Symbol[nCount], sizeof(req.Symbol[nCount]));
			nSymbolsCount++;

			// Add to the list
			SubscribedClient stSubsClient;
			
			if (msgType == QUOTE__REQUEST)
			{
				stSubsClient.bSubscribedQuotes = true;
			}
			else if (msgType == QUOTE__DOM_REQUEST)
			{
				stSubsClient.bSubscribeDOM = true;
			}

			std::pair<unsigned int, SubscribedClient> pr(clientID, stSubsClient);

			SUBSCRIBED_LIST list;
			list.insert(pr);

			std::pair<std::string, SUBSCRIBED_LIST> pr2(key, list);
			m_mapSubscribers.insert(pr2);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::submitQuoteRequest, Added symbol in subs list Symbol = %s, client id = %u", key.c_str(), clientID);
		}

		OHLC *pQuotes = (OHLC *)malloc(sizeof(OHLC));

		if (pQuotes)
		{
			memset(pQuotes, 0, sizeof(OHLC));
			if (m_pMDEDataManager->GetLatestQuote(pRequest->Symbol[nCount],*pQuotes) != -1)
			{

				//// Send Quotes to client
				lstQuotes.push_back(pQuotes);
			}
		}

	}

	LeaveCriticalSection(&m_csSubscribers);

	if (!lstQuotes.empty())
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::submitQuoteRequest, Snapshot Response client id = %u", clientID);
		SendSnapshotResponse(clientID, lstQuotes);
	}

	if (!mapSubscriptionList.empty())
	{
		SubscribeQuotes(mapSubscriptionList);
	}

	mapSubscriptionList.clear();
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

int	BL_MDE::UnSubscribeQuotes(unsigned int nClientID, std::list<symbol>& symList)
{
	int nSuccess = 0;

	//EnterCriticalSection(&m_csClientSymbolList);
	//EnterCriticalSection(&m_csSubscribers);

	//IClientSession *pSession = _ptrIConnectionMgr->GetClientSession(nClientID);

	//int nGroupID = 0;

	//if (pSession)
	//{
	//	nGroupID = pSession->GetGroupID();
	//}
	//
	//MAP_CLIENT_SYMBOL_LIST::iterator iterClientSymList = m_mapClientSymbolList.find(nClientID);

	//if (iterClientSymList != m_mapClientSymbolList.end())
	//{
	//	SYMBOL_LIST& symClientList = iterClientSymList->second;

	//	SYMBOL_LIST::iterator iterSymList = symList.begin();

	//	while (!symList.empty() && iterSymList != symList.end())
	//	{
	//		std::string& strSymbol = *(iterSymList);

	//		MAP_CONTRACT_GROUP_MAP::iterator iter = m_mapSubscribers.find(strSymbol);

	//		if (iter != m_mapSubscribers.end())
	//		{
	//			MAP_GROUP_CLIENTLIST& groupClientList = iter->second;

	//			if (!groupClientList.empty())
	//			{
	//				MAP_GROUP_CLIENTLIST::iterator iterSubsList = groupClientList.find(nGroupID);

	//				if (iterSubsList != groupClientList.end())
	//				{
	//					SUBSCRIBED_LIST& subsList = iterSubsList->second;

	//					if (!subsList.empty())
	//					{
	//						SUBSCRIBED_LIST::iterator iterSubsList1 = subsList.find(clientID);

	//						if (iterSubsList1 != subsList.end())
	//						{
	//							iterSubsList1 = subsList.erase(iterSubsList1);

	//							if (subsList.empty())
	//							{
	//								iterSubsList = groupClientList.erase(iterSubsList);
	//							}
	//						}
	//					}

	//					if (groupClientList.empty())
	//					{
	//						iter = m_mapSubscribers.erase(iter);
	//					}
	//				}
	//			}
	//		}

	//		iterSymList++;
	//	}

	//	//iterClientSymList = m_mapClientSymbolList.erase(iterClientSymList);
	//}

	//LeaveCriticalSection(&m_csSubscribers);
	//LeaveCriticalSection(&m_csClientSymbolList);

	return nSuccess;
}

void BL_MDE::removeQuoteSubscribers(unsigned int clientID)
{
	EnterCriticalSection(&m_csClientSymbolList);
	EnterCriticalSection(&m_csSubscribers);

	//IClientSession *pSession = _ptrIConnectionMgr->GetClientSession(clientID);

	//int nGroupID = 0;

	//if (pSession)
	//{
	//	nGroupID = pSession->GetGroupID();
	//}
	
	// Find in client id -> Symbol list map
	MAP_CLIENT_SYMBOL_LIST::iterator iterClientSymList = m_mapClientSymbolList.find(clientID);

	if (iterClientSymList != m_mapClientSymbolList.end())
	{
		// found client
		SYMBOL_LIST& symList = iterClientSymList->second;

		SYMBOL_LIST::iterator iterSymList = symList.begin();

		while (!symList.empty() && iterSymList != symList.end())
		{
			std::string& strSymbol = *(iterSymList);

			// Find the symbol in the m_mapSubscribers
			MAP_SYMBOL_SUBSLIST::iterator iter = m_mapSubscribers.find(strSymbol);

			if (iter != m_mapSubscribers.end())
			{
				SUBSCRIBED_LIST& subsList = iter->second;

				if (!subsList.empty())
				{
					SUBSCRIBED_LIST::iterator iterSubsList1 = subsList.find(clientID);

					if (iterSubsList1 != subsList.end())
					{
						iterSubsList1 = subsList.erase(iterSubsList1);
					}
				}

				if (subsList.empty())
				{
					iter = m_mapSubscribers.erase(iter);
				}
			}

			iterSymList++;
		}

		iterClientSymList = m_mapClientSymbolList.erase(iterClientSymList);
	}

	LeaveCriticalSection(&m_csSubscribers);
	LeaveCriticalSection(&m_csClientSymbolList);
}

int BL_MDE::GetSpreadInfo(std::string& key, SymbolSpread& symSpread, int nGroupID)
{
	int nSuccess = -1;

	EnterCriticalSection(&m_csGroupSymbolList);

	GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(nGroupID);

	if (iter != m_mapGroupSymbol.end())
	{
		SYMBOL_SPREAD_MAP& symSpreadMap = iter->second;

		if (!symSpreadMap.empty())
		{
			SYMBOL_SPREAD_MAP::iterator iter1 = symSpreadMap.find(key);

			if (iter1 != symSpreadMap.end())
			{
				symSpread = iter1->second;
				nSuccess = 0;
			}
		}
	}

	LeaveCriticalSection(&m_csGroupSymbolList);

	return nSuccess;
}

int BL_MDE::AddToSendList(std::list<QuotesItem>& lstQuotes, QuotesStream& stream)
{
	int nSuccess = 0;

	for (int nCount  = 0; nCount < stream.NoOfSymbols; nCount++)
	{
		lstQuotes.push_back(stream.QuotesItem[nCount]);
	}

	return nSuccess;
}

int BL_MDE::BuildPackageToBroadcast(QuotesItem& item, QuotesStream* pDestStream, SymbolSpread& spread)
{
	int nSuccess = 0;

	int nCount  = pDestStream->NoOfSymbols;

	if (spread.Fixed == true)
	{
		if (item.QuotesStreamType == QUOTES_STREAM_TYPE_BID)
		{
			memcpy(&pDestStream->QuotesItem[nCount], &item, sizeof(item));

			pDestStream->QuotesItem[nCount].Price -= spread.BidMarkUp;

			memcpy(&pDestStream->QuotesItem[nCount+1], &pDestStream->QuotesItem[nCount], sizeof(pDestStream->QuotesItem[nCount]));

			pDestStream->QuotesItem[1].Price += spread.lfSpread;
			pDestStream->QuotesItem[1].QuotesStreamType = QUOTES_STREAM_TYPE_ASK;

			pDestStream->NoOfSymbols += 2;
		}
		else if (item.QuotesStreamType == QUOTES_STREAM_TYPE_ASK)
		{
			nSuccess = -1;
		}
		else
		{
			memcpy(&pDestStream->QuotesItem[nCount], &item, sizeof(item));

			pDestStream->QuotesItem[nCount].Price -= spread.BidMarkUp;

			pDestStream->NoOfSymbols += 1; 
		}
	}
	else
	{
		if (item.QuotesStreamType == QUOTES_STREAM_TYPE_BID)
		{
			memcpy(&pDestStream->QuotesItem[nCount], &item, sizeof(item));

			pDestStream->QuotesItem[nCount].Price -= spread.BidMarkUp;

			pDestStream->NoOfSymbols += 1; 
		}
		else if (item.QuotesStreamType == QUOTES_STREAM_TYPE_ASK)
		{
			memcpy(&pDestStream->QuotesItem[nCount], &item, sizeof(item));

			pDestStream->QuotesItem[nCount].Price += spread.AskMarkUp;

			pDestStream->NoOfSymbols += 1; 
		}
		else
		{
			memcpy(&pDestStream->QuotesItem[nCount], &item, sizeof(item));

			pDestStream->QuotesItem[nCount].Price -= spread.BidMarkUp;

			pDestStream->NoOfSymbols += 1; 
		}
	}

	return nSuccess;
}

int	BL_MDE::PrepareBroadcastData(QuotesStream *pStream, unsigned int clnt)
{
	int nSuccess = 0;

	SymbolSpread spread;
	memset(&spread, 0, sizeof(spread));

	std::string key;
	GetKey(pStream->QuotesItem[0].Symbol, key);

	std::map<int, QuotesStream> mapGroupQuotes;

	// Updates quotes 
	//m_pMDEDataManager->updateQuoteItem(pStream);
	

	EnterCriticalSection(&m_csSubscribers);
	
	MAP_SYMBOL_SUBSLIST::iterator iter = m_mapSubscribers.find(key);

	if (iter != m_mapSubscribers.end())
	{
		SUBSCRIBED_LIST& subsList = iter->second;

		SUBSCRIBED_LIST::iterator subsIter = subsList.begin();

		for (;subsIter != subsList.end(); subsIter++)
		{
			unsigned int ClientID = subsIter->first;

			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::PrepareBroadcastData, Client ID = %u", ClientID);

			IClientSession *pSession = _ptrIConnectionMgr->GetClientSession(ClientID);

			if (pSession)
			{
				int GroupID = pSession->GetGroupID();

				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::PrepareBroadcastData, Group ID = %d", GroupID);

				// One quotesStream would have prices for only one symbol, and we keep it this way only.
				

				//if (nSuccess == 0)
				{
					std::map<int, QuotesStream>::iterator iter5 = mapGroupQuotes.find(GroupID);

					if (iter5 != mapGroupQuotes.end())
					{
						// Found the group. No need to build package, just pull from map and send
						QuotesStream& stream = iter5->second;

						_ptrIConnectionMgr->SendResponseToQueue(ClientID, &stream, QUOTES_STREAM);
					}
					else
					{
						QuotesStream stream;
						memcpy(&stream.Header, &pStream->Header, sizeof(stream.Header));
						stream.NoOfSymbols = 0;

						nSuccess = GetSpreadInfo(key, spread, GroupID);

						if (nSuccess == 0)
						{
							nSuccess = -1;

							for (int nCount = 0; nCount < pStream->NoOfSymbols; nCount++)
							{
								if (pStream->QuotesItem[nCount].QuotesStreamType != 'X')
								{
									nSuccess = BuildPackageToBroadcast(pStream->QuotesItem[nCount], &stream, spread);
									
									if (nSuccess == 0 && stream.NoOfSymbols >= MAX_SYMBOL)
									{
										memcpy(stream.UserName, pSession->GetUserNameA(), sizeof(stream.UserName));
										_ptrIConnectionMgr->SendResponseToQueue(ClientID, &stream, QUOTES_STREAM);

										std::pair<int, QuotesStream> pr(GroupID, stream);
										mapGroupQuotes.insert(pr);

										stream.NoOfSymbols = 0;
									}
								}
							}

							if (nSuccess == 0)
							{
								_ptrIConnectionMgr->SendResponseToQueue(ClientID, &stream, QUOTES_STREAM);

								std::pair<int, QuotesStream> pr(GroupID, stream);
								mapGroupQuotes.insert(pr);
							}
						}
						else
						{
							// Send the stream without any manipulation
							_ptrIConnectionMgr->SendResponseToQueue(ClientID, pStream, QUOTES_STREAM);

						}
					}
				}
			}
		}
	}
	else
	{
		// Do nothing
	}

	LeaveCriticalSection(&m_csSubscribers);

	// Clear the map
	mapGroupQuotes.clear();

	//try
	//{
	//	for (int nCount = 0; nCount < pStream->NoOfSymbols; nCount++)
	//	{
	//		std::string key;
	//		GetKey(pStream->QuotesItem[nCount].Symbol, key);

	//		MAP_CONTRACT_GROUP_MAP::iterator iter = m_mapSubscribers.find(key);

	//		if (iter != m_mapSubscribers.end())
	//		{
	//			MAP_GROUP_CLIENTLIST& mapGroupClient = iter->second;

	//			MAP_GROUP_CLIENTLIST::iterator iter1 = mapGroupClient.begin();

	//			while (!mapGroupClient.empty() && iter1 != mapGroupClient.end())
	//			{
	//				unsigned int nGroupID = iter1->first;

	//				SUBSCRIBED_LIST& list = iter1->second;
	//				
	//				QuotesStream stream;
	//				memcpy(&stream.Header, &pStream->Header, sizeof(stream.Header));

	//				nSuccess = BuildPackageToBroadcast(pStream->QuotesItem[nCount], &stream, nGroupID);

	//				if (nSuccess ==0)
	//				{
	//					SUBSCRIBED_LIST::iterator iter2 = list.begin();

	//					while (!list.empty() && iter2 != list.end())
	//					{
	//						SubscribedClient& stSubsClient = iter2->second;

	//						std::map<unsigned int, std::list<QuotesItem>>::iterator clntIter = mapClientQuotes.find(iter2->first);

	//						if (clntIter != mapClientQuotes.end())
	//						{
	//							std::list<QuotesItem>& lstQuotes = clntIter->second;

	//							AddToSendList(lstQuotes, stream);
	//						}
	//						else
	//						{
	//							std::list<QuotesItem> lstQuotes; 

	//							AddToSendList(lstQuotes, stream);

	//							std::pair<unsigned int, std::list<QuotesItem>> pr(iter2->first, lstQuotes);
	//							mapClientQuotes.insert(pr);
	//						}

	//						iter2++;
	//					}
	//				}
	//				else
	//				{
	//					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::PrepareBroadcastData, BuildPackageToBroadcast failed");
	//				}

	//				if (iter1 == mapGroupClient.end())
	//					break;

	//				iter1++;
	//			}
	//		}
	//		else
	//		{
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::PrepareBroadcastData, Key not found %s, Subs List = %d", key.c_str(), m_mapSubscribers.size());
	//		}
	//	}
	//}
	//catch (std::exception ex)
	//{
	//}

	

	return nSuccess;
}

void BL_MDE::BroadcastQuoteItem( QuotesStream *pStream)
{
	int nSuccess = 0;
	//EnterCriticalSection(&m_csSubscribers);

	//try
	//{
	//	for (int nCount = 0; nCount < pStream->NoOfSymbols; nCount++)
	//	{
	//		std::string key;
	//		GetKey(pStream->QuotesItem[nCount].Symbol, key);

	//		MAP_CONTRACT_GROUP_MAP::iterator iter = m_mapSubscribers.find(key);

	//		if (iter != m_mapSubscribers.end())
	//		{
	//			MAP_GROUP_CLIENTLIST& mapGroupClient = iter->second;

	//			MAP_GROUP_CLIENTLIST::iterator iter1 = mapGroupClient.begin();

	//			while (!mapGroupClient.empty() && iter1 != mapGroupClient.end())
	//			{
	//				unsigned int nGroupID = iter1->first;

	//				SUBSCRIBED_LIST& list = iter1->second;
	//				
	//				QuotesStream stream;
	//				memcpy(&stream.Header, &pStream->Header, sizeof(stream.Header));
	//				
	//				nSuccess = BuildPackageToBroadcast(pStream->QuotesItem[nCount], &stream, nGroupID);

	//				if (nSuccess ==0)
	//				{
	//					SUBSCRIBED_LIST::iterator iter2 = list.begin();

	//					while (!list.empty() && iter2 != list.end())
	//					{
	//						SubscribedClient& stSubsClient = iter2->second;

	//						// Send quotes stream
	//						_ptrIConnectionMgr->SendResponseToQueue( iter2->first , &stream , QUOTES_STREAM);

	//						iter2++;
	//					}
	//				}

	//				if (iter1 == mapGroupClient.end())
	//					break;

	//				iter1++;
	//			}
	//		}
	//	}
	//}
	//catch (std::exception ex)
	//{
	//}

	//LeaveCriticalSection(&m_csSubscribers);
}


API IServerBL* __stdcall CreateBusinessObject ()
{
	return BL_MDE::GetInstance();
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

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "BL_MDE::ReadConfig, DATABASE:ConnString = %s,Username = %s, Password = %s",
													_strConnString.c_str(),
													_strDBUserName.c_str(),
													_strDBPassword.c_str());

	ConfigObj.GetParameterString( "DATABASEMDE", std::string("CONN_STRING"), _strConnStringMDE); 
	ConfigObj.GetParameterString( "DATABASEMDE", std::string("USERNAME"), _strDBUserNameMDE); 
	ConfigObj.GetParameterString( "DATABASEMDE", std::string("PASSWORD"), _strDBPasswordMDE); 

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "BL_MDE::ReadConfig, DATABASE:ConnString = %s,Username = %s, Password = %s",
													_strConnStringMDE.c_str(),
													_strDBUserNameMDE.c_str(),
													_strDBPasswordMDE.c_str());

	ConfigObj.GetParameterString( "DATAMANAGER", std::string("FILENAME"), _strBulkFileName); 
}

// Reads from the DB
int	BL_MDE::LoadAllGateways()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	bool isSPExist = _ptrDatabase->Execute("Exchange_ListOfTradingGateways",*tb,*param);//execute sp
	if( !isSPExist )
	{
		return -1;
	}	

	char szLPName[20];
	char szIPAddress[20];
	char szLogin[100];
	char szPassword[100];
	int nPort = 0;
	bool AuthReq = false;

	while (!tb->IsEOF())
	{
		tb->Get("LPName", szLPName, sizeof(szLPName));
		tb->Get("IPAddress", szIPAddress, sizeof(szIPAddress));
		tb->Get("Port", nPort);
		tb->Get("Login", szLogin, sizeof(szLogin));
		tb->Get("Password", szPassword, sizeof(szPassword));
		tb->Get("AuthReq", AuthReq);

		MDFClient *pClient = new MDFClient(this, AuthReq);

		if (pClient)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "BL_MDE::LoadAllGateways, LP Name = %s, Login = %s, Password = %s, IPAddress = %s, Port = %d",
															szLPName,
															szLogin,
															szPassword,
															szIPAddress,
															nPort);

			pClient->login(szLogin, szPassword, szIPAddress, szIPAddress, nPort);
			_ptrMDFClientList.insert(std::pair<std::string, MDFClient*>(szLPName, pClient));
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::LoadAllGateways, Unable to allocate memory to MDFClient");
		}

		tb->MoveNext();
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}

int BL_MDE::ReLoadAllGroupSymbolSpread()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = _ptrDatabase->Execute("Exchange_ListOfGroupSymbolSpread",*tb,*param);//execute sp
			if( !isSPExist )
			{
				return -1;
			}	
			
			int AccountGroupID;
			symbol sym;
			SymbolSpread _ObjSymbolSpread;

			EnterCriticalSection(&m_csGroupSymbolList);

			while (!tb->IsEOF())
			{
				tb->Get("FK_AccountGroupId", AccountGroupID);
				tb->Get("Contract",sym.Contract ,sizeof(sym.Contract));
				tb->Get("ProductName",sym.Product,sizeof(sym.Product));
				tb->Get("Gateway",sym.Gateway ,sizeof(sym.Gateway));
				tb->Get("ProductType",sym.ProductType);
				tb->Get("BidSpread",_ObjSymbolSpread.BidMarkUp);
				tb->Get("AskSpread",_ObjSymbolSpread.AskMarkUp);		
				tb->Get("Spread",_ObjSymbolSpread.lfSpread);		
				tb->Get("Fixed",_ObjSymbolSpread.Fixed);

				GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(AccountGroupID);
				
				std::string key;
				GetKey(sym, key);

				if(iter == m_mapGroupSymbol.end())
				{
					if (_ObjSymbolSpread.AskMarkUp != 0 &&
						_ObjSymbolSpread.BidMarkUp != 0 &&
						_ObjSymbolSpread.lfSpread != 0)
					{
						// Group is not present in the map
						// insert GroupID along with SymbolSpreadMap
						std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
						SYMBOL_SPREAD_MAP mapSymbolSpread;

						mapSymbolSpread.insert(pr);
						
						std::pair<unsigned int,SYMBOL_SPREAD_MAP> pr1(AccountGroupID,mapSymbolSpread);

						m_mapGroupSymbol.insert(pr1);
					}
				} 
				else
				{
					SYMBOL_SPREAD_MAP& mapSymbolSpread = iter->second;

					SYMBOL_SPREAD_MAP::iterator iter = mapSymbolSpread.find(key);

					if (iter != mapSymbolSpread.end())
					{
						mapSymbolSpread.erase(iter);
					}

					if (_ObjSymbolSpread.AskMarkUp != 0 &&
						_ObjSymbolSpread.BidMarkUp != 0 &&
						_ObjSymbolSpread.lfSpread != 0)
					{
						std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
						mapSymbolSpread.insert(pr);
					}
				}

				tb->MoveNext();
			}

			LeaveCriticalSection(&m_csGroupSymbolList);
			
			ReleaseParameter(param);//release parameter object
		}

		ReleaseTable(tb);//release table object
	}

	return nSuccess;

}


int BL_MDE::LoadAllGroupSymbolSpread()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = _ptrDatabase->Execute("Exchange_ListOfGroupSymbolSpread",*tb,*param);//execute sp
			if( !isSPExist )
			{
				return -1;
			}	
			
			int AccountGroupID;
			symbol sym;
			SymbolSpread _ObjSymbolSpread;

			EnterCriticalSection(&m_csGroupSymbolList);

			while (!tb->IsEOF())
			{
				tb->Get("FK_AccountGroupId", AccountGroupID);
				tb->Get("Contract",sym.Contract ,sizeof(sym.Contract));
				tb->Get("ProductName",sym.Product,sizeof(sym.Product));
				tb->Get("Gateway",sym.Gateway ,sizeof(sym.Gateway));
				tb->Get("ProductType",sym.ProductType);
				tb->Get("BidSpread",_ObjSymbolSpread.BidMarkUp);
				tb->Get("AskSpread",_ObjSymbolSpread.AskMarkUp);		
				tb->Get("Spread",_ObjSymbolSpread.lfSpread);		
				tb->Get("Fixed",_ObjSymbolSpread.Fixed);


				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::LoadAllGroupSymbolSpread, Group=%d, Contract=%s, Gateway = %s, BidSpread=%lf, AskSpread = %lf, Spread = %lf",
														AccountGroupID,
														sym.Contract,
														sym.Gateway,
														_ObjSymbolSpread.BidMarkUp,
														_ObjSymbolSpread.AskMarkUp,
														_ObjSymbolSpread.lfSpread);


				GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(AccountGroupID);
				
				std::string key;
				GetKey(sym, key);

				if(iter == m_mapGroupSymbol.end())
				{
					// Group is not present in the map
					// insert GroupID along with SymbolSpreadMap
					std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
					SYMBOL_SPREAD_MAP mapSymbolSpread;

					mapSymbolSpread.insert(pr);
					
					std::pair<unsigned int,SYMBOL_SPREAD_MAP> pr1(AccountGroupID,mapSymbolSpread);

					m_mapGroupSymbol.insert(pr1);
				} 
				else
				{
					if (_ObjSymbolSpread.AskMarkUp != 0 &&
						_ObjSymbolSpread.BidMarkUp != 0 &&
						_ObjSymbolSpread.lfSpread != 0)
					{
						SYMBOL_SPREAD_MAP& mapSymbolSpread = iter->second;
						
						std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
						mapSymbolSpread.insert(pr);
					}
				}

				tb->MoveNext();
			}

			LeaveCriticalSection(&m_csGroupSymbolList);
			
			ReleaseParameter(param);//release parameter object
		}

		ReleaseTable(tb);//release table object
	}

	return nSuccess;

}


bool BL_MDE::Send(MDFClient *pClient ,pQuoteRequest msg,unsigned int msgtype)
{
	bool bSuccess = false;

	if (pClient)
	{
		std::string altSymbol = "";
		std::string altProduct = "";

		for (int i = 0; i < msg->NoOfSymbols; i++)
		{
			altSymbol = msg->Symbol[i].Contract;
			altProduct = msg->Symbol[i].Product;
			//if (GetAltSymbol(msg->Symbol[i].Gateway, msg->Symbol[i].Contract, altSymbol, altProduct) == 0)
			{
				std::string mainSymbol = msg->Symbol[i].Contract;
				std::string mainProduct = msg->Symbol[i].Product;

				strcpy(msg->Symbol[i].Contract, altSymbol.c_str());	
				strcpy(msg->Symbol[i].Product, altProduct.c_str());	

				std::string key;
				GetKey(msg->Symbol[i], key);

				if (m_pMDEDataManager->CreateThreadForProcessing(key, msg->Symbol[i], mainSymbol, mainProduct) != -1)
				{
					pClient->_ptrIClientProtocol->Send(pClient->_ClientID, msg, msgtype);
				}
			}
		}
	}

	return bSuccess;
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
int	BL_MDE::GetAltSymbol(const char *pszGateway, const char *pszSymbol, std::string& altSymbol, std::string& altProductName, IContractManager *pContractManager)
{
	int nSuccess = 0;

	try
	{
		altSymbol = pszSymbol;
		altProductName = pszSymbol;

		std::string strAltSymbol1;
		std::string strAltProduct1;

		CComBSTR strContract(pszSymbol);
		CComBSTR strGateway(pszGateway);
		//CComBSTR strAltSymbol(strAltSymbol1.c_str());
		//CComBSTR strAltProductName(strAltProduct1.c_str());

		BSTR bstrAltSymbol;
		BSTR bstrAltProductName;
		BSTR bstrGateway = strGateway.Detach();
		BSTR bstrContract = strContract.Detach();

		HRESULT hr = pContractManager->GetAltSymbol(bstrGateway, bstrContract, &bstrAltSymbol, &bstrAltProductName);
		
		if (hr != S_OK)
		{
			nSuccess = -1;
		}
		else
		{
			if(bstrAltSymbol!=NULL){altSymbol = _bstr_t(bstrAltSymbol);}
			else nSuccess = -1;

			if(bstrAltProductName!=NULL){altProductName = _bstr_t(bstrAltProductName);}
			else nSuccess = -1;
		}

		
		SysFreeString(bstrAltSymbol);
		SysFreeString(bstrAltProductName);
		SysFreeString(bstrGateway);
		SysFreeString(bstrContract);
	}
	catch (_com_error &e)
	{
		char szError[8000];

		ErrorHandler(e,szError);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::GetAltSymbol1, Exception::%s", szError);
	}

	return nSuccess;
}

void BL_MDE::ErrorHandler(_com_error &e, char* errStr)
{
	int iError;
	const int BUFF_SIZE = 8000;

	iError = _snprintf(errStr,BUFF_SIZE,"Error:\n");
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error:\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sCode = %08lx\n",errStr ,e.Error());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sCode meaning = %s\n", errStr, (char*) e.ErrorMessage());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sSource = %s\n", errStr, (char*) e.Source());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sDescription = %s",errStr, (char*) e.Description());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
}


int	BL_MDE::GetAltSymbol(const char *pszGateway, const char *pszSymbol, std::string& altSymbol, std::string& altProductName)
{
	int nSuccess = 0;

	altSymbol = *pszSymbol;

	return nSuccess;

	//try
	//{
	//	altSymbol = pszSymbol;
	//	altProductName = pszSymbol;

	//	CoInitializeEx(NULL, COINIT_MULTITHREADED);
	//	CComGITPtr<IContractManager>pToGITTest(m_dwGitCookie);

	//	IContractManager *pContractManager;
	//	pToGITTest.CopyTo(&pContractManager);

	//	std::string strAltSymbol1;
	//	std::string strAltProduct1;

	//	CComBSTR strContract(pszSymbol);
	//	CComBSTR strGateway(pszGateway);
	//	//CComBSTR strAltSymbol(strAltSymbol1.c_str());
	//	//CComBSTR strAltProductName(strAltProduct1.c_str());

	//	BSTR bstrAltSymbol;// = strAltSymbol.Detach();
	//	BSTR bstrAltProductName;// = strAltProductName.Detach();
	//	BSTR bstrGateway = strGateway.Detach();
	//	BSTR bstrContract = strContract.Detach();

	//	HRESULT hr = pContractManager->GetAltSymbol(bstrGateway, bstrContract, &bstrAltSymbol, &bstrAltProductName);
	//	
	//	if (hr != S_OK)
	//	{
	//		nSuccess = -1;
	//	}
	//	else
	//	{
	//		if(bstrAltSymbol!=NULL){altSymbol = _bstr_t(bstrAltSymbol);}
	//		else
	//		{
	//			bstrAltSymbol = 
	//			nSuccess = 0;
	//		}

	//		if(bstrAltProductName!=NULL){altProductName = _bstr_t(bstrAltProductName);}
	//		else nSuccess = -1;
	//	}

	//	SysFreeString(bstrAltSymbol);
	//	SysFreeString(bstrAltProductName);
	//	SysFreeString(bstrGateway);
	//	SysFreeString(bstrContract);
	//}
	//catch (_com_error &e)
	//{
	//	char szError[8000];

	//	ErrorHandler(e,szError);

	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::GetAltSymbol2, Exception::%s", szError);
	//}


	return nSuccess;
}


void BL_MDE::BroadcastQuotes(std::map<unsigned int, std::list<QuotesItem>>& quoteList)
{
	std::map<unsigned int, std::list<QuotesItem>>::iterator iter = quoteList.begin();

	int nSymbolsCount = 0;

	QuotesStream stream;
	stream.Header.KeyDataCtrlBlk = 0;
	stream.Header.MessageType = QUOTES_STREAM;
	stream.Header.StructSize = sizeof(QuotesStream);

	while (iter != quoteList.end())
	{
		unsigned int nClientID = iter->first;
		std::list<QuotesItem>& lstQuotesItem = iter->second;

		std::list<QuotesItem>::iterator iter1 = lstQuotesItem.begin();

		while (iter1 != lstQuotesItem.end())
		{
			QuotesItem& item = *iter1;

			memcpy(&stream.QuotesItem[nSymbolsCount], &item, sizeof(item));

			nSymbolsCount++;

			if (nSymbolsCount >= MAX_SYMBOL)
			{
				stream.NoOfSymbols = nSymbolsCount;

				for (int nCount = 0; nCount<stream.NoOfSymbols; nCount++)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::BroadcastQuotes, Count=%d, Contract=%s, Type=%c, Value = %lu", nCount, stream.QuotesItem[nCount].Symbol.Contract, stream.QuotesItem[nCount].QuotesStreamType, (unsigned long)stream.QuotesItem[nCount].Price);
				}

				_ptrIConnectionMgr->SendResponseToQueue(nClientID, &stream, QUOTES_STREAM);

				nSymbolsCount = 0;
			}

			iter1++;
		}

		if (nSymbolsCount >= 0)
		{
			stream.NoOfSymbols = nSymbolsCount;
			for (int nCount = 0; nCount<stream.NoOfSymbols; nCount++)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::BroadcastQuotes, Count=%d, Contract=%s, Type=%c, Value = %lu", nCount, stream.QuotesItem[nCount].Symbol.Contract, stream.QuotesItem[nCount].QuotesStreamType, (unsigned long)stream.QuotesItem[nCount].Price);
			}
			_ptrIConnectionMgr->SendResponseToQueue(nClientID, &stream, QUOTES_STREAM);

			nSymbolsCount = 0;
		}

		iter++;
	}

	quoteList.clear();
}


int BL_MDE::SetupthreadPools()
{
	int nSuccess = 0;

    PTP_WORK work = NULL;
    PTP_WORK_CALLBACK workcallback = MyWorkCallback;
    FILETIME FileDueTime;
    ULARGE_INTEGER ulDueTime;

	InitializeThreadpoolEnvironment(&m_CallBackEnviron);

	m_pool = CreateThreadpool(NULL);

	if (m_pool)
	{
		SetThreadpoolThreadMaximum(m_pool, 4);

		if (SetThreadpoolThreadMinimum(m_pool, 1))
		{
			//
		    // Associate the callback environment with our thread pool.
			//
			SetThreadpoolCallbackPool(&m_CallBackEnviron, m_pool);
		}

		//m_CallBackEnviron.ActivationContext
		
		
		
	}

	return nSuccess;
}


VOID CALLBACK BL_MDE::MyWorkCallback(PTP_CALLBACK_INSTANCE Instance, 
									PVOID                 Parameter,
									PTP_WORK              Work)
{
	QuotesStream* pStream = (QuotesStream *)Parameter;
	BL_MDE *pMDE = BL_MDE::GetInstance();

	if (pMDE)
	{
		pMDE->AddQuotesToLogQueue(pStream);
		pMDE->PrepareBroadcastData(pStream, 0);
	}

	free(pStream);
	CloseThreadpoolWork(Work);
	
}

int		BL_MDE::DispatchWorkForthreadPools(QuotesStream *pStream)
{
	int nSuccess = 0;

	PTP_WORK work = CreateThreadpoolWork(BL_MDE::MyWorkCallback, pStream, &m_CallBackEnviron);

	if (work)
	{
		SubmitThreadpoolWork(work);	
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::DispatchWorkForthreadPools, Work creation for thread pool failed");
	}

	return nSuccess;
}



int	BL_MDE::InsertLiveData()
{
	//int nSuccess = 0;

	//EnterCriticalSection(&m_csLiveFeed);

	//fclose(m_fpBulkQuotes);

	//ITable* tb=CreateTable();

	//if (tb)
	//{
	//	IParameter* param=CreateParameter();

	//	if (param)
	//	{
	//		char szFileName[300];
	//		strcpy(szFileName, _strBulkFileName.c_str());
	//		//strcpy(szFileName, "d:bulkQuotesFileName.txt");
	//		param->AddParam("path", szFileName,sizeof(szFileName));

	//		bool isSPExist = _ptrDatabaseMDE->Execute("MDE_InsertTickData",*tb,*param);//execute sp

	//		if( !isSPExist )
	//		{
	//			nSuccess = -1;
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "BL_MDE::InsertLiveData, Unable to execute SP Exchange_ListOfTradingGateways");				
	//		}

	//		ReleaseParameter(param);
	//	}

	//	ReleaseTable(tb);
	//}

	//m_fpBulkQuotes = fopen(_strBulkFileName.c_str(), "w");

	//LeaveCriticalSection(&m_csLiveFeed);

	return 0;
}

void BL_MDE::AddQuotesToLogQueue(QuotesStream *pStream)
{
	EnterCriticalSection(&m_csLiveFeed);

	m_lstLiveFeed.push_back(*pStream);

	SetEvent(m_hLiveEvent);

	LeaveCriticalSection(&m_csLiveFeed);
}

int		BL_MDE::CreateLoggerThread()
{
	int nSuccess = 0;

	m_fpBulkQuotes = fopen(_strBulkFileName.c_str(), "w");

	m_hLivefeedThread = (HANDLE)_beginthreadex(NULL, 0, BL_MDE::LoggerThread, this,0, NULL);

	return nSuccess;
}

unsigned int __stdcall BL_MDE::LoggerThread(void* arg)
{
	//BL_MDE *pMDE = (BL_MDE *)arg;

	//if (pMDE)
	//{
	//	HANDLE handleEvent = pMDE->GetEventHandle();

	//	// Run always
	//	while (true)
	//	{
	//		WaitForSingleObject(handleEvent,INFINITE);

	//		pMDE->LogToFile();
	//	}
	//}

	return 0L;
}

void BL_MDE::LogToFile()
{
	EnterCriticalSection(&m_csLiveFeed);

	std::list<QuotesStream>::iterator iter = m_lstLiveFeed.begin();

	while (iter != m_lstLiveFeed.end())
	{
		QuotesStream& pStream = *iter;

		for (int nCount = 0; nCount < pStream.NoOfSymbols; nCount++)
		{
			// ignore these, as these are duplicate records.
			if (pStream.QuotesItem[nCount].QuotesStreamType == 'X')
				continue;

			COleDateTime oleDtTime(pStream.QuotesItem[nCount].Time);

			int day = oleDtTime.GetDay();
			int mnth = oleDtTime.GetMonth();
			int yr = oleDtTime.GetYear();
			int hr = oleDtTime.GetHour();
			int minu = oleDtTime.GetMinute();
			int sec = oleDtTime.GetSecond();

			fprintf(m_fpBulkQuotes, ",%s,%s,%c,%lu,%lu,%d-%d-%d %d:%d:%d\n", 
										pStream.QuotesItem[nCount].Symbol.Gateway,
										pStream.QuotesItem[nCount].Symbol.Contract,
										pStream.QuotesItem[nCount].QuotesStreamType,
										(unsigned long)pStream.QuotesItem[nCount].Price,
										(unsigned long)pStream.QuotesItem[nCount].Size,
										yr,
										mnth,
										day,
										hr,
										minu,
										sec);
											
		}

		iter++;
	}

	m_lstLiveFeed.clear();

	LeaveCriticalSection(&m_csLiveFeed);
}


int		BL_MDE::CreateBulkInsertThread()
{
	int nSuccess = 0;

	HANDLE m_hThread = (HANDLE)_beginthreadex(NULL, 0, BL_MDE::BulkInsertThread, this,0, NULL);

	return nSuccess;
}

unsigned int __stdcall BL_MDE::BulkInsertThread(void* arg)
{
	BL_MDE *pMDE = (BL_MDE *)arg;

	if (pMDE)
	{
		while (1)
		{
			Sleep(1*60*1000);

			pMDE->InsertLiveData();
		}
	}

	return 0L;
}
