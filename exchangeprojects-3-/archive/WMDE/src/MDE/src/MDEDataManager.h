#if !defined _MDEDataManager_H_
#define _MDEDataManager_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "DataDef.h"
#include "BL_MDE.h"
#include <map>
#include <vector>
#include <string>

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================

// Contract -> Gateway -> MarketLevel
class MDEQuotesItem;
typedef std::map<std::string, MDEQuotesItem *>				GATEWAY_MDEQUOTES_MAP;
typedef std::map<std::string, GATEWAY_MDEQUOTES_MAP>		CONTRACT_GATEWAY_MDEQUOTES_MAP; 

struct ProcessData
{
	CRITICAL_SECTION					CS_STREAM;
	HANDLE								m_hThread;
	HANDLE								m_hQueueResponses;
	symbol								MainSymbol;
	symbol								AltSymbol;	
	MDEDataManager*						pRef;	
	MDEQuotesItem*						pMDEQuotesItem;
	std::list<pQuotesStream>*			m_lstQuotesToProcess;
};

typedef std::map<std::string, ProcessData *>				SYMBOL_QUOTES_STREAM_MAP;

class MDEQuotesItem
{
private:
	OHLC				m_stOHLC;
	CRITICAL_SECTION	m_cs;
public:
	MDEQuotesItem();
	MDEQuotesItem(symbol& stSymbol);
	~MDEQuotesItem();

    void UpdateItem(QuotesItem& item, unsigned long& ulOpen, unsigned long& ulHigh, unsigned long& ulLow);
	void UpdateItem(OHLC& item);
	int GetOHLC(OHLC& ohlc);
};

class MDEDataManager
{
private:
	BL_MDE*								m_pMDE;
	CONTRACT_GATEWAY_MDEQUOTES_MAP		m_mapQuotesData;
	CRITICAL_SECTION					m_csQuotesDataMap;
	DWORD								m_dwGITCode;
	SYMBOL_QUOTES_STREAM_MAP			m_mapSymbolStream;
	CRITICAL_SECTION					m_csMapSymbolStream;

	std::list<pQuotesStream>			m_lstMainQueueList;
	CRITICAL_SECTION					m_csMainQueueList;

	HANDLE								m_hMainListThread;
	HANDLE								m_hMainListEvent;
public:
	MDEDataManager(BL_MDE* ptrMDE, DWORD dwCode);
	~MDEDataManager();
	int		GetLatestQuote(symbol& stSymbol, OHLC& quotes);
	int		updateQuoteItem(pQuotesStream ptrQuotesStream);
	MDEQuotesItem*		CreateQuoteItem(symbol& sym);
	int		updateSnapItem(QuotesSnapshotResponse& ptrQuotesSnapshotResponse);
	int		UpdateContractManager(QuotesItem& item, IContractManager *pContractManager);
	HANDLE		CreateMainListProcessor();
	static unsigned int __stdcall MainListProcessor(void* arg);
	HANDLE		CreateBroadcasterThread(ProcessData *pData);
	static unsigned int __stdcall BroadcasterThread(void* arg);
	inline DWORD	GetGITCode();
	int		AddQuotesResponseToQueue(pQuotesStream ptrQuotesStream);
	inline void AcquireCSForQueue();
	inline void ReleaseCSForQueue();
	inline BL_MDE* GetMDERef();

	HANDLE GetMainListEvent(){return m_hMainListEvent;};
	std::list<pQuotesStream>& GetMainListQueue(){return m_lstMainQueueList;};
	void AcquireMainQueueCS(){EnterCriticalSection(&m_csMainQueueList);};
	void ReleaseMainQueueCS(){LeaveCriticalSection(&m_csMainQueueList);};

	int CreateThreadForProcessing(std::string& key, symbol& MainSymbol, std::string& AltSymbol, std::string& AltProduct);
	int AddToSymbolProcessDataMap(ProcessData *pData);

	int AddQuotesToProcessData(QuotesStream* pStream);
};


#endif