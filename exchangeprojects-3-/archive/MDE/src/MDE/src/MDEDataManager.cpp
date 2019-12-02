#include "StdAfx.h"
#include "MDEDataManager.h"
#include <iostream>
#include <atlsafe.h>
#include "xlogger.h"


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "MDEDataManager"

MDEQuotesItem::MDEQuotesItem()
{
	InitializeCriticalSection(&m_cs);
	memset(&m_stOHLC, 0, sizeof(m_stOHLC));
}

MDEQuotesItem::MDEQuotesItem(symbol& stSymbol)
{
	InitializeCriticalSection(&m_cs);

	memset(&m_stOHLC, 0, sizeof(m_stOHLC));
	memcpy(&m_stOHLC.Symbol, &stSymbol, sizeof(stSymbol));
}

MDEQuotesItem::~MDEQuotesItem()
{
	DeleteCriticalSection(&m_cs);
}

void MDEQuotesItem::UpdateItem(QuotesItem& item, unsigned long& ulOpen, unsigned long& ulHigh, unsigned long& ulLow)
{
	EnterCriticalSection(&m_cs);

	switch (item.QuotesStreamType)
	{
	case QUOTES_STREAM_TYPE_ASK:
		if (item.MarketLevel < MAX_MARKET_DEPTH)
		{
			m_stOHLC.MarketDepth[item.MarketLevel].AskPrice = item.Price;
			m_stOHLC.MarketDepth[item.MarketLevel].AskSize = item.Size;
			m_stOHLC.MarketDepth[item.MarketLevel].AskTime = item.Time;
			m_stOHLC.MarketDepth[item.MarketLevel].Level = item.MarketLevel;
			memcpy(&m_stOHLC.MarketDepth[item.MarketLevel].Gateway, item.Symbol.Gateway, sizeof(item.Symbol.Gateway));
		}

		if (m_stOHLC.MarketDepthLevel < item.MarketLevel + 1)
		{
			m_stOHLC.MarketDepthLevel = item.MarketLevel + 1;
		}
		break;
	case QUOTES_STREAM_TYPE_BID:
		if (item.MarketLevel < MAX_MARKET_DEPTH)
		{
			m_stOHLC.MarketDepth[item.MarketLevel].BidPrice = item.Price;
			m_stOHLC.MarketDepth[item.MarketLevel].BidSize = item.Size;
			m_stOHLC.MarketDepth[item.MarketLevel].BidTime = item.Time;
			m_stOHLC.MarketDepth[item.MarketLevel].Level = item.MarketLevel;
			memcpy(&m_stOHLC.MarketDepth[item.MarketLevel].Gateway, item.Symbol.Gateway, sizeof(item.Symbol.Gateway));

			// the OHLC only changes when the best price comes in
			/*if (item.MarketLevel == 0)
			{
				if (m_stOHLC.Open == 0)
				{
					ulOpen = ulHigh = ulLow = m_stOHLC.Open = m_stOHLC.High = m_stOHLC.Low =  item.Price;
				}
				else if (item.Price > m_stOHLC.High)
				{
					ulHigh = m_stOHLC.High = item.Price;
				}
				else if (item.Price < m_stOHLC.Low)
				{
					ulLow = m_stOHLC.Low = item.Price;
				}
			}*/
		}

		if (m_stOHLC.MarketDepthLevel < item.MarketLevel + 1)
		{
			m_stOHLC.MarketDepthLevel = item.MarketLevel + 1;
		}
		break;
	case QUOTES_STREAM_TYPE_CLOSE:
		m_stOHLC.Close = item.Price;
		break;
	case QUOTES_STREAM_TYPE_HIGH:
		m_stOHLC.High = item.Price;
		break;
	case QUOTES_STREAM_TYPE_LAST:
		m_stOHLC.LastPrice = item.Price;
		m_stOHLC.LastTime = item.Time;
		m_stOHLC.LastSize = item.Size;		
		break;
	case QUOTES_STREAM_TYPE_LOW:
		m_stOHLC.Low = item.Price;
		break;
	case QUOTES_STREAM_TYPE_OPEN:
		m_stOHLC.Open = item.Price;
		break;
	}

	m_stOHLC.LastUpdatedTime = item.Time;

	LeaveCriticalSection(&m_cs);
}

void MDEQuotesItem::UpdateItem(OHLC& item)
{
	EnterCriticalSection(&m_cs);

	memcpy(&m_stOHLC, &item, sizeof(m_stOHLC));

	LeaveCriticalSection(&m_cs);
}

int MDEQuotesItem::GetOHLC(OHLC& ohlc)
{
	int nSuccess = 0;

	EnterCriticalSection(&m_cs);

	memcpy(&ohlc, &m_stOHLC, sizeof(m_stOHLC));

	LeaveCriticalSection(&m_cs);

	return nSuccess;
}


MDEDataManager::MDEDataManager(BL_MDE* ptrMDE, DWORD dwCode)
{
	m_pMDE = ptrMDE;
	m_dwGITCode = dwCode;

	InitializeCriticalSection(&m_csQuotesDataMap);
	InitializeCriticalSection(&m_csMainQueueList);
	InitializeCriticalSection(&m_csMapSymbolStream);

	m_hMainListEvent = CreateEvent(NULL, FALSE, FALSE, NULL);

	m_hMainListThread = CreateMainListProcessor();
}

MDEDataManager::~MDEDataManager()
{
	DeleteCriticalSection(&m_csQuotesDataMap);
	DeleteCriticalSection(&m_csMainQueueList);

//	SetEvent(m_hQueueResponses);

	//CloseHandle(m_hQueueResponses);
}

int		MDEDataManager::GetLatestQuote(symbol& stSymbol, OHLC& quotes)
{
	int nSuccess = -1;

	EnterCriticalSection(&m_csQuotesDataMap);

	CONTRACT_GATEWAY_MDEQUOTES_MAP::iterator iter = m_mapQuotesData.find(stSymbol.Contract);

	if (iter != m_mapQuotesData.end())
	{
		// Found the contract
		GATEWAY_MDEQUOTES_MAP& mapGatewayQuotes = iter->second;

		GATEWAY_MDEQUOTES_MAP::iterator iter1 = mapGatewayQuotes.find(stSymbol.Gateway);

		if (iter1 != mapGatewayQuotes.end())
		{
			MDEQuotesItem* item = iter1->second;

			if (item)
			{
				nSuccess = item->GetOHLC(quotes);
			}
		}
	}

	LeaveCriticalSection(&m_csQuotesDataMap);

	return nSuccess;
}

int		MDEDataManager::UpdateContractManager(QuotesItem& item, IContractManager *pContractManager)
{
	int nSuccess = 0;

	if (item.MarketLevel == 0)
	{
		CComBSTR str(item.Symbol.Product);
		CComBSTR strContract(item.Symbol.Contract);
		CComBSTR strGateway(item.Symbol.Gateway);

		BSTR bstr = str.Detach();
		BSTR bstrContract = strContract.Detach();
		BSTR bstrGateway = strGateway.Detach();

		long retVal = 0;
		// Update the price in the contracts manager
		HRESULT hr = pContractManager->SetPrice(item.Symbol.ProductType, 
											bstr,
											bstrContract,
											bstrGateway,
											bstrGateway,
											item.Price,
											item.Size,
											item.Time,
											item.QuotesStreamType,
											&retVal);

		if (hr == S_FALSE)
		{
			nSuccess = retVal;

			if (retVal == -999)
			{
				// Just denotes to ignore it
				item.QuotesStreamType = 'X';
			}
		}
		
		SysFreeString(bstr);
		SysFreeString(bstrContract);
		SysFreeString(bstrGateway);
	}

	return nSuccess;
}

MDEQuotesItem*		MDEDataManager::CreateQuoteItem(symbol& sym)
{
	MDEQuotesItem *pItem = NULL;

	EnterCriticalSection(&m_csQuotesDataMap);

	CONTRACT_GATEWAY_MDEQUOTES_MAP::iterator iter = m_mapQuotesData.find(sym.Contract);

	if (iter != m_mapQuotesData.end())
	{
		// Found the contract
		GATEWAY_MDEQUOTES_MAP& mapGatewayQuotes = iter->second;

		GATEWAY_MDEQUOTES_MAP::iterator iter1 = mapGatewayQuotes.find(sym.Gateway);

		if (iter1 != mapGatewayQuotes.end())
		{
			// Should not come here
		}
		else
		{
			MDEQuotesItem* item = new MDEQuotesItem(sym);
			
			if (item)
			{
				pItem = item;

				std::pair<std::string, MDEQuotesItem *> pr(sym.Gateway, item);
				
				mapGatewayQuotes.insert(pr);
			}
		}
	}
	else
	{
		// the symbol is not there
		MDEQuotesItem* item = new MDEQuotesItem(sym);
		
		if (item)
		{
			pItem = item;

			GATEWAY_MDEQUOTES_MAP mapGatewayQuotes;
			std::pair<std::string, MDEQuotesItem *> pr(sym.Gateway, item);
			
			mapGatewayQuotes.insert(pr);

			std::pair<std::string, GATEWAY_MDEQUOTES_MAP> pr1(sym.Contract, mapGatewayQuotes);
			m_mapQuotesData.insert(pr1);
		}
	}

	LeaveCriticalSection(&m_csQuotesDataMap);

	return pItem;
}

int		MDEDataManager::updateQuoteItem(pQuotesStream ptrQuotesStream)
{
	int nSuccess = 0;

	EnterCriticalSection(&m_csQuotesDataMap);

	unsigned long ulOpen = 0;
	unsigned long ulHigh = 0;
	unsigned long ulLow = 0;


	for (int nCount = 0; nCount < ptrQuotesStream->NoOfSymbols; nCount++)
	{
		if (ptrQuotesStream->QuotesItem[nCount].QuotesStreamType == 'X')
			continue;

		CONTRACT_GATEWAY_MDEQUOTES_MAP::iterator iter = m_mapQuotesData.find(ptrQuotesStream->QuotesItem[nCount].Symbol.Contract);

		if (iter != m_mapQuotesData.end())
		{
			// Found the contract
			GATEWAY_MDEQUOTES_MAP& mapGatewayQuotes = iter->second;

			GATEWAY_MDEQUOTES_MAP::iterator iter1 = mapGatewayQuotes.find(ptrQuotesStream->QuotesItem[nCount].Symbol.Gateway);

			if (iter1 != mapGatewayQuotes.end())
			{
				MDEQuotesItem* item = iter1->second;

				if (item)
				{
					item->UpdateItem(ptrQuotesStream->QuotesItem[nCount], ulOpen, ulHigh, ulLow);
				}
			}
			else
			{
				MDEQuotesItem* item = new MDEQuotesItem(ptrQuotesStream->QuotesItem[nCount].Symbol);
				
				if (item)
				{
					item->UpdateItem(ptrQuotesStream->QuotesItem[nCount], ulOpen, ulHigh, ulLow);
					std::pair<std::string, MDEQuotesItem *> pr(ptrQuotesStream->QuotesItem[nCount].Symbol.Gateway, item);
					
					mapGatewayQuotes.insert(pr);
				}
			}
		}
		else
		{
			// the symbol is not there
			MDEQuotesItem* item = new MDEQuotesItem(ptrQuotesStream->QuotesItem[nCount].Symbol);
			
			if (item)
			{
				GATEWAY_MDEQUOTES_MAP mapGatewayQuotes;

				item->UpdateItem(ptrQuotesStream->QuotesItem[nCount], ulOpen, ulHigh, ulLow);
				std::pair<std::string, MDEQuotesItem *> pr(ptrQuotesStream->QuotesItem[nCount].Symbol.Gateway, item);
				
				mapGatewayQuotes.insert(pr);

				std::pair<std::string, GATEWAY_MDEQUOTES_MAP> pr1(ptrQuotesStream->QuotesItem[nCount].Symbol.Contract, mapGatewayQuotes);
				m_mapQuotesData.insert(pr1);
			}
		}
	}

	int nSymCount = ptrQuotesStream->NoOfSymbols;

	if (ulOpen != 0)
	{
		ptrQuotesStream->QuotesItem[nSymCount].MarketLevel = 0;	
		ptrQuotesStream->QuotesItem[nSymCount].Price = ulOpen;
		ptrQuotesStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
		ptrQuotesStream->QuotesItem[nSymCount].Size = 0;
		memcpy(&ptrQuotesStream->QuotesItem[nSymCount].Symbol, &ptrQuotesStream->QuotesItem[0].Symbol, sizeof (ptrQuotesStream->QuotesItem[nSymCount].Symbol));
		ptrQuotesStream->QuotesItem[nSymCount].Time = ptrQuotesStream->QuotesItem[0].Time;

		nSymCount++;
	}

	if (ulHigh != 0)
	{
		ptrQuotesStream->QuotesItem[nSymCount].MarketLevel = 0;	
		ptrQuotesStream->QuotesItem[nSymCount].Price = ulHigh;
		ptrQuotesStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
		ptrQuotesStream->QuotesItem[nSymCount].Size = 0;
		memcpy(&ptrQuotesStream->QuotesItem[nSymCount].Symbol, &ptrQuotesStream->QuotesItem[0].Symbol, sizeof (ptrQuotesStream->QuotesItem[nSymCount].Symbol));
		ptrQuotesStream->QuotesItem[nSymCount].Time = ptrQuotesStream->QuotesItem[0].Time;

		nSymCount++;
	}

	if (ulLow != 0)
	{
		ptrQuotesStream->QuotesItem[nSymCount].MarketLevel = 0;	
		ptrQuotesStream->QuotesItem[nSymCount].Price = ulLow;
		ptrQuotesStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
		ptrQuotesStream->QuotesItem[nSymCount].Size = 0;
		memcpy(&ptrQuotesStream->QuotesItem[nSymCount].Symbol, &ptrQuotesStream->QuotesItem[0].Symbol, sizeof (ptrQuotesStream->QuotesItem[nSymCount].Symbol));
		ptrQuotesStream->QuotesItem[nSymCount].Time = ptrQuotesStream->QuotesItem[0].Time;

		nSymCount++;
	}

	ptrQuotesStream->NoOfSymbols = nSymCount;
	
	LeaveCriticalSection(&m_csQuotesDataMap);

	return nSuccess;
}

BL_MDE* MDEDataManager::GetMDERef()
{
	return m_pMDE;
}

int		MDEDataManager::updateSnapItem(QuotesSnapshotResponse& quotesSnapshotResponse)
{
	int nSuccess = 0;

	EnterCriticalSection(&m_csQuotesDataMap);

	for (int nCount = 0; nCount < quotesSnapshotResponse.NoOfSymbols; nCount++)
	{
		CONTRACT_GATEWAY_MDEQUOTES_MAP::iterator iter = m_mapQuotesData.find(quotesSnapshotResponse.OHLC[nCount].Symbol.Contract);

		if (iter != m_mapQuotesData.end())
		{
			// Found the contract
			GATEWAY_MDEQUOTES_MAP& mapGatewayQuotes = iter->second;

			GATEWAY_MDEQUOTES_MAP::iterator iter1 = mapGatewayQuotes.find(quotesSnapshotResponse.OHLC[nCount].Symbol.Gateway);

			if (iter1 != mapGatewayQuotes.end())
			{
				MDEQuotesItem* item = iter1->second;

				if (item)
				{
					item->UpdateItem(quotesSnapshotResponse.OHLC[nCount]);
				}
			}
			else
			{
				MDEQuotesItem* item = new MDEQuotesItem();
				
				if (item)
				{
					item->UpdateItem(quotesSnapshotResponse.OHLC[nCount]);
					std::pair<std::string, MDEQuotesItem *> pr(quotesSnapshotResponse.OHLC[nCount].Symbol.Gateway, item);
					
					mapGatewayQuotes.insert(pr);
				}
			}
		}
		else
		{
			// the symbol is not there
			MDEQuotesItem* item = new MDEQuotesItem(quotesSnapshotResponse.OHLC[nCount].Symbol);
			
			if (item)
			{
				GATEWAY_MDEQUOTES_MAP mapGatewayQuotes;

				item->UpdateItem(quotesSnapshotResponse.OHLC[nCount]);
				std::pair<std::string, MDEQuotesItem *> pr(quotesSnapshotResponse.OHLC[nCount].Symbol.Gateway, item);
				
				mapGatewayQuotes.insert(pr);

				std::pair<std::string, GATEWAY_MDEQUOTES_MAP> pr1(quotesSnapshotResponse.OHLC[nCount].Symbol.Contract, mapGatewayQuotes);
				m_mapQuotesData.insert(pr1);
			}
		}
	}

	LeaveCriticalSection(&m_csQuotesDataMap);

	

	return nSuccess;
}

int MDEDataManager::AddToSymbolProcessDataMap(ProcessData *pData)
{
	int nSuccess = 0;

	AcquireCSForQueue();

	std::string key;
	m_pMDE->GetKey(pData->MainSymbol, key);

	SYMBOL_QUOTES_STREAM_MAP::iterator iter = m_mapSymbolStream.find(key);

	if (iter == m_mapSymbolStream.end())
	{
		std::pair<std::string, ProcessData*> pr(key, pData);
		m_mapSymbolStream.insert(pr);
	}

	ReleaseCSForQueue();

	return nSuccess;
}

int MDEDataManager::CreateThreadForProcessing(std::string& key, symbol& MainSymbol, std::string& AltSymbol, std::string& AltProduct)
{
	int nSuccess = 0;

	AcquireCSForQueue();

	SYMBOL_QUOTES_STREAM_MAP::iterator iter = m_mapSymbolStream.find(key);

	if (iter == m_mapSymbolStream.end())
	{
		// Create the thread.
		ProcessData *data = (ProcessData *)malloc(sizeof(ProcessData));

		if (data)
		{
			InitializeCriticalSection(&data->CS_STREAM);
			memcpy(&data->MainSymbol, &MainSymbol, sizeof(symbol));
			memcpy(&data->AltSymbol, &MainSymbol, sizeof(symbol));	
			strcpy(data->AltSymbol.Contract, AltSymbol.c_str());
			strcpy(data->AltSymbol.Product, AltProduct.c_str());
			data->pRef = this;
			data->m_lstQuotesToProcess = new std::list<pQuotesStream>();
			data->m_hQueueResponses = CreateEvent(NULL, FALSE, FALSE, NULL);

			data->pMDEQuotesItem = CreateQuoteItem(data->AltSymbol);
			data->m_hThread = CreateBroadcasterThread(data);

			AddToSymbolProcessDataMap(data);
		}
	}
	else
	{
		nSuccess = -1;

	}

	ReleaseCSForQueue();

	return nSuccess;
}


HANDLE		MDEDataManager::CreateMainListProcessor()
{
	HANDLE hthread = (HANDLE)_beginthreadex(NULL, 0, MDEDataManager::MainListProcessor, this,0, NULL);

	return hthread;
}

unsigned int __stdcall MDEDataManager::MainListProcessor(void* arg)
{
	MDEDataManager *pDataManager = (MDEDataManager *)arg;

	if (pDataManager)
	{
		HANDLE handleEvent = pDataManager->GetMainListEvent();
		std::list<pQuotesStream>& lstProcessQueue =  pDataManager->GetMainListQueue();

		while (true)
		{
			WaitForSingleObject(handleEvent,INFINITE);

			while (1)
			{
				QuotesStream *pStream = NULL;

				pDataManager->AcquireMainQueueCS();

				if (lstProcessQueue.empty())
				{
					pDataManager->ReleaseMainQueueCS();
					break;
				}

				pStream = lstProcessQueue.front();
				lstProcessQueue.pop_front();

				pDataManager->ReleaseMainQueueCS();

				if (pStream)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEDataManager::MainListProcessor, Contract=%s, Count = %d",pStream->QuotesItem[0].Symbol.Contract, lstProcessQueue.size());
					pDataManager->AddQuotesToProcessData(pStream);
				}
			}
		}
	}

	return 0L;
}


HANDLE	MDEDataManager::CreateBroadcasterThread(ProcessData *pData)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEDataManager::CreateBroadcasterThread for Key %d", pData->MainSymbol.Contract);

	HANDLE hthread = (HANDLE)_beginthreadex(NULL, 0, MDEDataManager::BroadcasterThread, pData,0, NULL);

	return hthread;
}

unsigned int __stdcall MDEDataManager::BroadcasterThread(void* arg)
{
	ProcessData *pData = (ProcessData *)arg;

	if (pData)
	{
		MDEDataManager *pDataManager = pData->pRef;

		if (pDataManager)
		{
			pDataManager->AddToSymbolProcessDataMap(pData);

			HANDLE handleEvent = pData->m_hQueueResponses;
			DWORD dwGITCode = pDataManager->GetGITCode();

			CoInitializeEx(NULL, COINIT_MULTITHREADED);
			CComGITPtr<IContractManager>pToGITTest(dwGITCode);

			IContractManager *pContractManager;
			pToGITTest.CopyTo(&pContractManager);

			std::map<unsigned int, std::list<QuotesItem>> mapClientQuotes;

			BL_MDE* pMDE = pDataManager->GetMDERef();

			if (pMDE && pContractManager)
			{
				std::list<pQuotesStream>* lstProcessQueue = pData->m_lstQuotesToProcess;

				// Run always
				while (true)
				{
					WaitForSingleObject(handleEvent,INFINITE);
					

					//int nCount = 0;
					while (1)
					{
						QuotesStream *pStream = NULL;

						EnterCriticalSection(&pData->CS_STREAM);

						if (lstProcessQueue->empty())
						{
							LeaveCriticalSection(&pData->CS_STREAM);
							break;
						}

						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEDataManager::BroadcasterThread, Contract=%s, Count = %d", pData->AltSymbol.Contract, pData->m_lstQuotesToProcess->size());

						pStream = lstProcessQueue->front();
						lstProcessQueue->pop_front();

						LeaveCriticalSection(&pData->CS_STREAM);

						if (pStream)
						{
							int nCount  = 0;

							bool bError = false;
							unsigned long ulOpen = 0;
							unsigned long ulHigh = 0;
							unsigned long ulLow = 0;

							//for (;nCount < pStream->NoOfSymbols; nCount++)
							//{
							//	strcpy(pStream->QuotesItem[nCount].Symbol.Contract, pData->AltSymbol.Contract);
							//	strcpy(pStream->QuotesItem[nCount].Symbol.Product, pData->AltSymbol.Product);

							//	/*if (pMDE->m_pMDEDataManager->UpdateContractManager(pStream->QuotesItem[nCount], pContractManager) == 0)
							//	{
							//		
							//	}
							//	else
							//	{
							//		bError = true;
							//		break;
							//	}*/

							//	pData->pMDEQuotesItem->UpdateItem(pStream->QuotesItem[nCount], ulOpen, ulHigh, ulLow);
							//}

							/*int nSymCount = pStream->NoOfSymbols;

							if (ulOpen != 0)
							{
								pStream->QuotesItem[nSymCount].MarketLevel = 0;	
								pStream->QuotesItem[nSymCount].Price = ulOpen;
								pStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_OPEN;
								pStream->QuotesItem[nSymCount].Size = 0;
								memcpy(&pStream->QuotesItem[nSymCount].Symbol, &pStream->QuotesItem[0].Symbol, sizeof (pStream->QuotesItem[nSymCount].Symbol));
								pStream->QuotesItem[nSymCount].Time = pStream->QuotesItem[0].Time;

								nSymCount++;
							}

							if (ulHigh != 0)
							{
								pStream->QuotesItem[nSymCount].MarketLevel = 0;	
								pStream->QuotesItem[nSymCount].Price = ulHigh;
								pStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_HIGH;
								pStream->QuotesItem[nSymCount].Size = 0;
								memcpy(&pStream->QuotesItem[nSymCount].Symbol, &pStream->QuotesItem[0].Symbol, sizeof (pStream->QuotesItem[nSymCount].Symbol));
								pStream->QuotesItem[nSymCount].Time = pStream->QuotesItem[0].Time;

								nSymCount++;
							}

							if (ulLow != 0)
							{
								pStream->QuotesItem[nSymCount].MarketLevel = 0;	
								pStream->QuotesItem[nSymCount].Price = ulLow;
								pStream->QuotesItem[nSymCount].QuotesStreamType = QUOTES_STREAM_TYPE_LOW;
								pStream->QuotesItem[nSymCount].Size = 0;
								memcpy(&pStream->QuotesItem[nSymCount].Symbol, &pStream->QuotesItem[0].Symbol, sizeof (pStream->QuotesItem[nSymCount].Symbol));
								pStream->QuotesItem[nSymCount].Time = pStream->QuotesItem[0].Time;

								nSymCount++;
							}*/

							//pStream->NoOfSymbols = nSymCount;

							//if (!bError)
							{
								// Send the stuff for market
								//pMDE->DispatchWorkForthreadPools(pStream);
								pMDE->AddQuotesToLogQueue(pStream);
								pMDE->PrepareBroadcastData(pStream, 0);

								free(pStream);
							}
						}
					}

					//LeaveCriticalSection(&pData->CS_STREAM);
				}
			}

			CoUninitialize();

			
		}
	}

	return 0L;
}



void MDEDataManager::AcquireCSForQueue()
{
	EnterCriticalSection(&m_csMapSymbolStream);
}

void MDEDataManager::ReleaseCSForQueue()
{
	LeaveCriticalSection(&m_csMapSymbolStream);
}


DWORD	MDEDataManager::GetGITCode()
{
	return m_dwGITCode;
}


int MDEDataManager::AddQuotesToProcessData(QuotesStream* ptrQuotesStream)
{
	int nSuccess = 0;

	AcquireCSForQueue();

	std::string key;

	ProcessData* data = NULL;
	m_pMDE->GetKey(ptrQuotesStream->QuotesItem[0].Symbol, key);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEDataManager::AddQuotesResponseToQueue, Key =%s", key.c_str());

	SYMBOL_QUOTES_STREAM_MAP::iterator iter = m_mapSymbolStream.find(key);

	if (iter != m_mapSymbolStream.end())
	{
		// Symbol found
		data = iter->second;

	}

	ReleaseCSForQueue();

	if (data)
	{
		EnterCriticalSection(&data->CS_STREAM);

		data->m_lstQuotesToProcess->push_back(ptrQuotesStream);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEDataManager::AddQuotesResponseToQueue, Contract=%s, Count = %d", data->AltSymbol.Contract, data->m_lstQuotesToProcess->size());

		SetEvent(data->m_hQueueResponses);

		LeaveCriticalSection(&data->CS_STREAM);
	}

	return nSuccess;
}

int		MDEDataManager::AddQuotesResponseToQueue(pQuotesStream ptrQuotesStream)
{
	int nSuccess = 0;

	AcquireMainQueueCS();

	m_lstMainQueueList.push_back(ptrQuotesStream);

	ReleaseMainQueueCS();

	SetEvent(m_hMainListEvent);

	return nSuccess;
}

