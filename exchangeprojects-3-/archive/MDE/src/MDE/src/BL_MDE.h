/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _BL_MDE_H_
#define _BL_MDE_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>

#include "ServerInterface.h"
#include "DataDef.h"
#include "MDFClient.h"
#include <vector>
#include <string>

#define MAX_DISPATCH_MSGS	10000

struct SubscribedClient
{
	unsigned int ClientID;
	bool bSubscribeDOM;
	bool bSubscribedQuotes;
};

typedef std::map<unsigned int, SubscribedClient>			SUBSCRIBED_LIST;
typedef std::map<std::string, SUBSCRIBED_LIST>				MAP_SYMBOL_SUBSLIST;
// The key would be CONTRACT_GATEWAY
//typedef std::map<std::string, MAP_GROUP_CLIENTLIST>			MAP_CONTRACT_GROUP_MAP;

//struct SymbolSpread
//{
//	bool Fixed;
//	double AskMarkUp;
//	double BidMarkUp;
//	double	lfSpread;
//};

typedef std::map<std::string,SymbolSpread>						SYMBOL_SPREAD_MAP;				
typedef std::map<unsigned int,SYMBOL_SPREAD_MAP>			GROUP_SYMBOL_SPREAD_MAP;

// Store the ClientID and list fo symbols that are subscribed to
typedef std::list<std::string>								SYMBOL_LIST;
typedef std::map<unsigned int, SYMBOL_LIST>					MAP_CLIENT_SYMBOL_LIST;

struct DispatchMsg
{
	QuotesStream *pStream;
	BL_MDE *pMDE;
};

//*************************************************************************************************
// class BL_MDE
//
//*************************************************************************************************
class MDEDataManager;
class MDEQuotesItem;
class BL_MDE	: public IServerBL
{

//METHODS-------
public:
	BL_MDE();
	~BL_MDE();
	static BL_MDE*											m_instance;

	static BL_MDE* GetInstance();
	IRequest*			getIRequestPointer(MESSAGE msg);
	void				onNewClientAdded(unsigned clientID, IConnectionMgr *mgr = NULL) ;
	void				onClientDisconnected(unsigned clientID) ;	
	void				onNewClientAdded(IClientSession *clientID);
	void				setConnectionMgr(IConnectionMgr* ptrIConnectionMgr) ;
	unsigned int		GetClientID();
	unsigned int		GetClientIDMDE();

	void				submitQuoteRequest( QuoteRequest *pRequest, unsigned clientID, unsigned int msgType, int nGroupID, bool isForSubscribe = true );
	void				submitNewsRequest( unsigned long ulAccount, unsigned clientID, bool isForSubscribe = true );

	void				onNewsStream(NewsStream* ptrNewsStream);

	void				BroadcastQuoteItem(QuotesStream *pStream);
	void				BroadcastQuotes(std::map<unsigned int, std::list<QuotesItem>>& quoteList);

	void				removeNewsSubscribers(unsigned int clientID);
	void				removeQuoteSubscribers(unsigned int clientID);

	int					LoadAllGateways();
	int                 LoadAllGroupSymbolSpread();
	int					ReLoadAllGroupSymbolSpread();
	int					InitializeDatabase();
	bool				Send(MDFClient *pClient, pQuoteRequest msg,unsigned int msgtype);

	int					GetAltSymbol(const char *pszGateway, const char *pszSymbol, std::string& altSymbol, std::string& altProductName);
	int					GetAltSymbol(const char *pszGateway, const char *pszSymbol, std::string& altSymbol, std::string& altProductName, IContractManager *pContractManager);
	void				SubmitAllQuotes();

	void				GetKey(symbol& sym, std::string& key);

	int					SendSnapshotResponse(unsigned int nClientID, std::list<OHLC *>& lstMDEQuotesItem);
	int					SubscribeQuotes(std::map<std::string, std::list<symbol>>& mapGatewaySymList);
	int					UnSubscribeQuotes(unsigned int nClientID, std::list<symbol>& symList);

	int					PrepareBroadcastData(QuotesStream *pStream, unsigned int ClientID);
	int					InsertLiveData();

	void ErrorHandler(_com_error &e, char* errStr);

	int		DispatchWorkForthreadPools(QuotesStream *pStream);
	static VOID CALLBACK MyWorkCallback(PTP_CALLBACK_INSTANCE Instance, 
									PVOID                 Parameter,
									PTP_WORK              Work);
	int SetupthreadPools();

	void AddQuotesToLogQueue(QuotesStream *pStream);

	int		CreateLoggerThread();
	static unsigned int __stdcall LoggerThread(void* arg);

	int		CreateBulkInsertThread();
	static unsigned int __stdcall BulkInsertThread(void* arg);

	HANDLE GetEventHandle(){return m_hLiveEvent;};

	void LogToFile();

private:
	void ReadConfig();

	int GetSpreadInfo(std::string& key, SymbolSpread& symSpread, int nGroupID);

	int BuildPackageToBroadcast(QuotesItem& item, QuotesStream* destStream, SymbolSpread& spread);

	int AddToSendList(std::list<QuotesItem>& lstQuotes, QuotesStream& stream);
public:
	MDEDataManager*		m_pMDEDataManager;

	DWORD				m_dwGitCookie;
	IContractManagerPtr	_ptrContractManagerPtr;
private:
	IConnectionMgr*		_ptrIConnectionMgr;
	std::map<std::string, MDFClient *>	_ptrMDFClientList;

    GROUP_SYMBOL_SPREAD_MAP		m_mapGroupSymbol;
	MAP_CLIENT_SYMBOL_LIST		m_mapClientSymbolList;

	MAP_SYMBOL_SUBSLIST			m_mapSubscribers; 
	std::list<unsigned int>		_NewsSubscribers;

	std::string			_strConnString;
	std::string			_strDBUserName;
	std::string			_strDBPassword;

	IDatabase*			_ptrDatabase;

	std::string			_strConnStringMDE;
	std::string			_strDBUserNameMDE;
	std::string			_strDBPasswordMDE;

	IDatabase*			_ptrDatabaseMDE;

	std::string			_strBulkFileName;
	CRITICAL_SECTION	m_csGroupSymbolList;
	CRITICAL_SECTION	m_csSubscribers;
	CRITICAL_SECTION	m_csClientSymbolList;

	TP_CALLBACK_ENVIRON					m_CallBackEnviron;
	PTP_POOL							m_pool;

	std::list<QuotesStream>			m_lstLiveFeed;
	HANDLE								m_hLiveEvent;
	HANDLE								m_hLivefeedThread;

	CRITICAL_SECTION					m_csLiveFeed;

	FILE*								m_fpBulkQuotes;
};//class BL_MDE

#endif //_BL_MDE_H_


