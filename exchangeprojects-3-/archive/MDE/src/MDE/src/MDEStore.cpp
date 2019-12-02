/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "MDEStore.h"
#include <iostream>
#include <atlsafe.h>
#include "xlogger.h"


//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "MDEStore"




//*******************************************************************            
//  FUNCTION:   - MyQuoteItem::MyQuoteItem()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
MyQuoteItem::MyQuoteItem(pQuotesItem item,std::string& Key )
	:_strKey(Key),
	_ptrOHLC(NULL),
	_Digits(4)
{
	_ptrQuoteItem = new QuotesItem();
	memcpy(_ptrQuoteItem,item,sizeof(QuotesItem));

	int firsTokenIndex =  Key.find_first_of('_');
	int secondTokenIndex = Key.find_first_of('_',firsTokenIndex+1);
	int thirdTokenIndex = Key.find_first_of('_',secondTokenIndex+1);

	_strGateway = Key.substr(0,firsTokenIndex);
	_strProductType = Key.substr(firsTokenIndex+1,(secondTokenIndex-1) - firsTokenIndex);
	_strProduct = Key.substr(secondTokenIndex+1,(thirdTokenIndex-1)-secondTokenIndex);
	_strContract = Key.substr(thirdTokenIndex+1);
}

MyQuoteItem::MyQuoteItem(pQuotesItem item,std::string& Key, bool bSnapshot )
	:_strKey(Key),
	_ptrOHLC(NULL),
	_Digits(4)
{
	//_ptrQuoteItem = new QuotesItem();
	//memcpy(_ptrQuoteItem,item,sizeof(QuotesItem));

	int firsTokenIndex =  Key.find_first_of('_');
	int secondTokenIndex = Key.find_first_of('_',firsTokenIndex+1);
	int thirdTokenIndex = Key.find_first_of('_',secondTokenIndex+1);

	_strGateway = Key.substr(0,firsTokenIndex);
	_strProductType = Key.substr(firsTokenIndex+1,(secondTokenIndex-1) - firsTokenIndex);
	_strProduct = Key.substr(secondTokenIndex+1,(thirdTokenIndex-1)-secondTokenIndex);
	_strContract = Key.substr(thirdTokenIndex+1);

	_ptrOHLC = new OHLC();
	//memset(_ptrOHLC, 0, sizeof(OHLC));
	_ptrOHLC->Open = 0;
	_ptrOHLC->Low = 999999;
	_ptrOHLC->High = 0;
	memcpy(&_ptrOHLC->Symbol, &item->Symbol, sizeof(item->Symbol));
	_ptrOHLC->MarketDepthLevel = 0;

	this->UpdateItemforSnapshot(item);
}




//*******************************************************************            
//  FUNCTION:   - MyQuoteItem::MyQuoteItem()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
MyQuoteItem::MyQuoteItem(pOHLC item,std::string& Key )
	:_ptrQuoteItem(NULL),
	_strKey(Key),
	_Digits(4)
{
	_ptrOHLC = new OHLC();
	memcpy(_ptrOHLC,item,sizeof(OHLC));

	int firsTokenIndex =  Key.find_first_of('_');
	int secondTokenIndex = Key.find_first_of('_',firsTokenIndex+1);
	int thirdTokenIndex = Key.find_first_of('_',secondTokenIndex+1);

	_strGateway = Key.substr(0,firsTokenIndex);
	_strProductType = Key.substr(firsTokenIndex+1,(secondTokenIndex-1) - firsTokenIndex);
	_strProduct = Key.substr(secondTokenIndex+1,(thirdTokenIndex-1)-secondTokenIndex);
	_strContract = Key.substr(thirdTokenIndex+1);

}




//*******************************************************************            
//  FUNCTION:   - MyQuoteItem::~MyQuoteItem()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
MyQuoteItem::~MyQuoteItem()
{
	if( _ptrQuoteItem != NULL )
	{
		delete _ptrQuoteItem;
	}

	if( _ptrOHLC != NULL )
	{
		delete _ptrOHLC;
	}
	_ptrQuoteItem = NULL;
	_ptrOHLC = NULL;
}




//*******************************************************************            
//  FUNCTION:   - MyQuoteItem::MyQuoteItem()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
inline void MyQuoteItem::UpdateItem(pQuotesItem item)
{
	memcpy(_ptrQuoteItem,item,sizeof(QuotesItem));
}

void MyQuoteItem::UpdateItemforSnapshot(pQuotesItem item)
{
	switch (item->QuotesStreamType)
	{
	case QUOTES_STREAM_TYPE_ASK:
		_ptrOHLC->MarketDepth[item->MarketLevel].AskPrice = item->Price;
		_ptrOHLC->MarketDepth[item->MarketLevel].AskSize = item->Size;
		_ptrOHLC->MarketDepth[item->MarketLevel].AskTime = item->Time;
		_ptrOHLC->MarketDepth[item->MarketLevel].Level = item->MarketLevel;

		if (_ptrOHLC->MarketDepthLevel < item->MarketLevel)
			_ptrOHLC->MarketDepthLevel = item->MarketLevel;
		break;
	case QUOTES_STREAM_TYPE_BID:
		_ptrOHLC->MarketDepth[item->MarketLevel].BidPrice = item->Price;
		_ptrOHLC->MarketDepth[item->MarketLevel].BidSize = item->Size;
		_ptrOHLC->MarketDepth[item->MarketLevel].BidTime = item->Time;
		_ptrOHLC->MarketDepth[item->MarketLevel].Level = item->MarketLevel;

		if (_ptrOHLC->MarketDepthLevel < item->MarketLevel)
			_ptrOHLC->MarketDepthLevel = item->MarketLevel;

		break;
	//case QUOTES_STREAM_TYPE_CLOSE:
	//	break;
	//case QUOTES_STREAM_TYPE_HIGH:
	//	break;
	case QUOTES_STREAM_TYPE_LAST:
		_ptrOHLC->LastPrice = item->Price;
		_ptrOHLC->LastSize = item->Size;
		_ptrOHLC->LastTime = item->Time;

		if (_ptrOHLC->Open == 0)
			_ptrOHLC->Open = item->Price;

		if (_ptrOHLC->High < item->Price)
			_ptrOHLC->High = item->Price;

		if (_ptrOHLC->Low > item->Price)
			_ptrOHLC->Low = item->Price;

		break;
	//case QUOTES_STREAM_TYPE_LOW:
	//	break;
	case QUOTES_STREAM_TYPE_OPEN:
		break;
	}

	_ptrOHLC->LastUpdatedTime = item->Time;

}


//*******************************************************************            
//  FUNCTION:   - MyQuoteItem::MyQuoteItem()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
inline void MyQuoteItem::UpdateItem(pOHLC item)
{
	memcpy(_ptrOHLC,item,sizeof(OHLC));
}



MDEStore::MDEStore(BL_MDE* ptrMDE, DWORD dwCode)
:_ptrMDE(ptrMDE)
{
	_mapMarketDepth.clear();
	_mapSnaphot.clear();

	m_dwGITCode = dwCode;
}

MDEStore::~MDEStore()
{
	itMARKETDEPTH_MAP itDepth;

	for( itDepth = _mapMarketDepth.begin() ; itDepth != _mapMarketDepth.end() ; itDepth++ )
	{
		itMARKETLEVEL_MAP itLevel;
		for( itLevel = (*itDepth).second.begin() ; itLevel != (*itDepth).second.end() ; itLevel++ )
		{
			itQuoteItem_MAP itQuoteItem;
			for( itQuoteItem = (*itLevel).second.begin() ; itQuoteItem != (*itLevel).second.end() ; itQuoteItem++ )
			{
				delete (*itQuoteItem).second;
			}
		}
	}
	_mapMarketDepth.clear();

	itSNAPSHOT_MAP itSnap;
	for( itSnap = _mapSnaphot.begin() ; itSnap != _mapSnaphot.end() ; itSnap++ )
	{
		delete (*itSnap).second;
	}

	_mapSnaphot.clear();
	
}

std::vector<MyQuoteItem*>* MDEStore::GetLatestQuote( symbol* ptrSymbol)  
{
	std::string* keyName = getKey( ptrSymbol);

	return GetLatestQuote( keyName );
	
}

pOHLC MDEStore::GetLatestSnapShot( symbol* ptrSymbol)  
{
	std::string* keyName = getKey( ptrSymbol );

	return GetLatestSnapShot(keyName);
	
}

DOM_MAP* MDEStore::GetLatestDOM( symbol* ptrSymbol)  
{
	std::string* keyName = getKey( ptrSymbol );
	return GetLatestDOM(keyName);
}

std::vector<MyQuoteItem*>*	MDEStore::GetLatestQuote( std::string* keyName )
{
	////MAP[string][level][stream type] = MyQuoteItem
	if( _mapMarketDepth.find( *keyName ) == _mapMarketDepth.end() )
	{
		return NULL;
	}

	std::vector<MyQuoteItem*>* returnMap = new std::vector<MyQuoteItem*>();
	itMARKETLEVEL_MAP itLevel;
	
	bool isDataContain = false;
	
	for( itLevel = _mapMarketDepth[ *keyName ].begin() ; itLevel != _mapMarketDepth[ *keyName ].end() ; itLevel++ )
	{
		itQuoteItem_MAP itQuote;
		for( itQuote = (*itLevel).second.begin() ; itQuote != (*itLevel).second.end() ; itQuote++ )
		{
			if( (*itLevel).first == 0  )
			{
				isDataContain = true;
				returnMap->push_back(  (*itQuote).second );
			}//if
		}//for
	}

	if(isDataContain)
	{
		return returnMap;
	}//if
	else
	{
		delete returnMap;
		return NULL;
	}
}

pOHLC MDEStore::GetLatestSnapShot( std::string* keyName )
{
	if( _mapSnaphot.find( *keyName ) == _mapSnaphot.end() )
	{
		return NULL;
	}//if

	return _mapSnaphot[ *keyName ]->_ptrOHLC;
}

DOM_MAP* MDEStore::GetLatestDOM( std::string* keyName )
{
	////MAP[string][level][stream type] = MyQuoteItem
	if( _mapMarketDepth.find( *keyName ) == _mapMarketDepth.end() )
	{
		return NULL;
	}

	DOM_MAP* returnMap = new DOM_MAP();//typedef std::map<unsigned int,std::vector<MyQuoteItem*>> DOM_MAP;
	itMARKETLEVEL_MAP itLevel;
	
	bool isDataContain = false;
	
	for( itLevel = _mapMarketDepth[ *keyName ].begin() ; itLevel != _mapMarketDepth[ *keyName ].end() ; itLevel++ )
	{
		itQuoteItem_MAP itQuote;
		for( itQuote = (*itLevel).second.begin() ; itQuote != (*itLevel).second.end() ; itQuote++ )
		{
			if( (*itLevel).first == 0  )
				continue;
			if( (*itQuote).first == QUOTES_STREAM_TYPE_ASK || (*itQuote).first == QUOTES_STREAM_TYPE_BID )
			{
				isDataContain = true;
				if( returnMap->find( (*itLevel).first ) == returnMap->end() )
				{
					std::vector<MyQuoteItem*> vec;
					vec.push_back(  (*itQuote).second );
					returnMap->insert( std::pair<unsigned int,std::vector<MyQuoteItem*>>( (*itLevel).first ,vec ) );
				}
				else
				{
					(*returnMap)[ (*itLevel).first ].push_back(  (*itQuote).second );
				}
				
			}//if
		}//for
	}

	if(isDataContain)
	{
		return returnMap;
	}//if
	else
	{
		delete returnMap;
		return NULL;
	}
}

void MDEStore::updateQuoteItem(pQuotesStream ptrQuotesStream)
{
	try
	{
		// Call the UpdateSnapshot to update the snapshot
		updateSnapItem(ptrQuotesStream);

		std::map<std::string,std::vector<pQuotesItem>*>* mapupdateQuote = new std::map<std::string,std::vector<pQuotesItem>*>();
		std::map<std::string,std::vector<pQuotesItem>*>* mapUpdateDOM = new std::map<std::string,std::vector<pQuotesItem>*>();
		
		//MAP[string][level][stream type] = MyQuoteItem
		for( int iStreamLoop = 0 ; iStreamLoop < ptrQuotesStream->NoOfSymbols ; iStreamLoop++ )
		{
			//std::string altSymbol = "";
			//std::string altProduct = "";
			//_ptrMDE->GetAltSymbol(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Gateway, ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Contract, altSymbol, altProduct);
			//strcpy(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Contract, altSymbol.c_str());
			//strcpy(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Product, altProduct.c_str());

			std::string* strKey = getKey(&ptrQuotesStream->QuotesItem[iStreamLoop].Symbol);

			if( _mapMarketDepth.find(*strKey) == _mapMarketDepth.end() )
			{
				delete strKey;
				break;
			}//if

			if (ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel == 0)
			{
				CComBSTR str(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Product);
				CComBSTR strContract(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Contract);
				CComBSTR strGateway(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.Gateway);

				CoInitializeEx(NULL, COINIT_MULTITHREADED);
				CComGITPtr<IContractManager>pToGITTest(m_dwGITCode);

				IContractManager *pContractManager;
				pToGITTest.CopyTo(&pContractManager);

				// Update the price in the contracts manager
				pContractManager->SetPrice(ptrQuotesStream->QuotesItem[iStreamLoop].Symbol.ProductType, 
													str,
													strContract,
													strGateway,
													strGateway,
													ptrQuotesStream->QuotesItem[iStreamLoop].Price,
													ptrQuotesStream->QuotesItem[iStreamLoop].Size,
													ptrQuotesStream->QuotesItem[iStreamLoop].Time,
													ptrQuotesStream->QuotesItem[iStreamLoop].QuotesStreamType/*,
													ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel*/);

				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDEStore::UpdateQuoteItem, Symbol Key = %s,type=%c, Price=%lu, Size=%lu" ,
				//									(*strKey).c_str(),
				//									ptrQuotesStream->QuotesItem[iStreamLoop].QuotesStreamType	,
				//									(unsigned long)ptrQuotesStream->QuotesItem[iStreamLoop].Price,
				//									(unsigned long)ptrQuotesStream->QuotesItem[iStreamLoop].Size);

			}

			if( _mapMarketDepth[*strKey].find( ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel ) == _mapMarketDepth[*strKey].end() )
			{
				QuoteItem_MAP mp;
				_mapMarketDepth[*strKey].insert( std::pair<unsigned int,QuoteItem_MAP>(  ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel , mp ) );
			}//if
			if(  _mapMarketDepth[*strKey][ ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel].find( ptrQuotesStream->QuotesItem[iStreamLoop].QuotesStreamType ) == _mapMarketDepth[*strKey][ ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel].end() )
			{
				MyQuoteItem* ptrQuoteItem =  new MyQuoteItem( &ptrQuotesStream->QuotesItem[iStreamLoop] , *strKey  ) ;
				ptrQuoteItem->_Digits = 4;
				//std::cout<<"Inserting Market Item Book "<<"  "<<*strKey<<" Level: "<<ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel<<std::endl;
				_mapMarketDepth[*strKey][ ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel].insert( std::pair<char,MyQuoteItem*>(  ptrQuotesStream->QuotesItem[iStreamLoop].QuotesStreamType , ptrQuoteItem ) );


			}//if
			else
			{
				//std::cout<<"Updating Market Item  Book"<<"  "<<*strKey<<" Level: "<<ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel<<std::endl;
				
				_mapMarketDepth[*strKey][ ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel][ ptrQuotesStream->QuotesItem[iStreamLoop].QuotesStreamType]->UpdateItem(&ptrQuotesStream->QuotesItem[iStreamLoop]);

			}//else

			if( ptrQuotesStream->QuotesItem[iStreamLoop].MarketLevel == 0 )
			{
				if( mapupdateQuote->find(*strKey) == mapupdateQuote->end() )
				{
					std::vector<pQuotesItem>* vec = new std::vector<pQuotesItem>();
					vec->push_back( &ptrQuotesStream->QuotesItem[iStreamLoop] );
					//std::cout<<"Inserting Quote Item "<<"  "<<*strKey<<std::endl;
					mapupdateQuote->insert( std::pair<std::string,std::vector<pQuotesItem>*>( (*strKey), vec ) );
				}
				else
				{
					//std::cout<<"Appending Quote Item "<<"  "<<*strKey<<std::endl;
					(*mapupdateQuote)[ *strKey ]->push_back( &ptrQuotesStream->QuotesItem[iStreamLoop] );
				}
			}
			else
			{
				if( mapUpdateDOM->find(*strKey) == mapUpdateDOM->end() )
				{
					std::vector<pQuotesItem>* vec = new std::vector<pQuotesItem>();
					vec->push_back( &ptrQuotesStream->QuotesItem[iStreamLoop] );
					//std::cout<<"Inserting DOM Item "<<"  "<<*strKey<<std::endl;
					mapUpdateDOM->insert( std::pair<std::string,std::vector<pQuotesItem>*>( (*strKey), vec ) );
				}
				else
				{
					//std::cout<<"Appending DOm Item "<<"  "<<*strKey<<std::endl;
					(*mapUpdateDOM)[ *strKey ]->push_back( &ptrQuotesStream->QuotesItem[iStreamLoop] );
				}
			}

			delete strKey;

		}//for

		if( mapupdateQuote->size() > 0 || mapUpdateDOM->size() > 0 )
		{
			_ptrMDE->BroadcastQuoteItem(mapupdateQuote , mapUpdateDOM );
			//_ptrMDE->Broadcast_Alert_Item(mapupdateQuote); //By Deepak 10 Sept 2012 for Alert
		}
		std::map<std::string,std::vector<pQuotesItem>*>::iterator it;
		for( it = mapupdateQuote->begin() ; it != mapupdateQuote->end() ; it++ )
		{
			delete it->second;
			it->second = NULL;
		}
		for( it = mapUpdateDOM->begin() ; it != mapUpdateDOM->end() ; it++ )
		{
			delete it->second;
			it->second = NULL;
		}
		mapupdateQuote->clear();
		mapUpdateDOM->clear();
		delete mapupdateQuote;
		delete mapUpdateDOM;
		mapupdateQuote = NULL;
		mapUpdateDOM = NULL;
	}
	catch (...)
	{
	}
}

void MDEStore::updateSnapItem(pQuotesSnapshotResponse ptrQuotesSnapshotResponse)
{
	
	for( int iSnapShotLoop = 0 ; iSnapShotLoop < ptrQuotesSnapshotResponse->NoOfSymbols ; iSnapShotLoop++ )
	{
		std::string altSymbol = "";
		std::string altProduct = "";
		if (_ptrMDE->GetAltSymbol(ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop].Symbol.Gateway, ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop].Symbol.Contract, altSymbol, altProduct) == -1)
			continue;

		strcpy(ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop].Symbol.Contract, altSymbol.c_str());
		strcpy(ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop].Symbol.Product, altProduct.c_str());

		std::string* strKey = getKey(&ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop].Symbol);

		if( _mapSnaphot.find(*strKey) == _mapSnaphot.end() )
		{
			MyQuoteItem* ptrOHLC = new MyQuoteItem( &ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop] , *strKey );
			ptrOHLC->_Digits = 4;
			_mapSnaphot.insert( std::pair<std::string,MyQuoteItem*>( *strKey,ptrOHLC ) );
		}//if
		else
		{
			_mapSnaphot[*strKey]->UpdateItem(&ptrQuotesSnapshotResponse->OHLC[iSnapShotLoop]);
		}//else

		delete strKey;
	}//for
}

void MDEStore::updateSnapItem(pQuotesStream ptrQuotesStream)
{
	
	for( int iSnapShotLoop = 0 ; iSnapShotLoop < ptrQuotesStream->NoOfSymbols ; iSnapShotLoop++ )
	{
		std::string altSymbol = "";
		std::string altProduct = "";

		if (_ptrMDE->GetAltSymbol(ptrQuotesStream->QuotesItem[iSnapShotLoop].Symbol.Gateway, ptrQuotesStream->QuotesItem[iSnapShotLoop].Symbol.Contract, altSymbol, altProduct) == -1)
			continue;

		strcpy(ptrQuotesStream->QuotesItem[iSnapShotLoop].Symbol.Contract, altSymbol.c_str());
		strcpy(ptrQuotesStream->QuotesItem[iSnapShotLoop].Symbol.Product, altProduct.c_str());

		std::string* strKey = getKey(&ptrQuotesStream->QuotesItem[iSnapShotLoop].Symbol);

		if( _mapSnaphot.find(*strKey) == _mapSnaphot.end() )
		{
			MyQuoteItem* ptrOHLC = new MyQuoteItem( &ptrQuotesStream->QuotesItem[iSnapShotLoop] , *strKey , true);
			ptrOHLC->_Digits = 4;
			_mapSnaphot.insert( std::pair<std::string,MyQuoteItem*>( *strKey,ptrOHLC ) );
		}//if
		else
		{
			_mapSnaphot[*strKey]->UpdateItemforSnapshot(&ptrQuotesStream->QuotesItem[iSnapShotLoop]);
		}//else

		delete strKey;
	}//for
}

std::string* MDEStore::getKey(symbol* PtrSymbol_)
{
	std::string* key = new std::string(PtrSymbol_->Gateway);
	key->append("_");
	key->append(1,PtrSymbol_->ProductType);
	key->append("_");
	key->append(PtrSymbol_->Product);
	key->append("_");
	key->append(PtrSymbol_->Contract);
	return key;

}

bool MDEStore::removeEntryInMarketDepthBook(std::string key)
{
	
	itMARKETDEPTH_MAP itDepth;
	itDepth = _mapMarketDepth.find(key);

	if( itDepth == _mapMarketDepth.end() )
		return false;
	
	itMARKETLEVEL_MAP itLevel;
	for( itLevel = (*itDepth).second.begin() ; itLevel != (*itDepth).second.end() ; itLevel++ )
	{
		itQuoteItem_MAP itQuoteItem;
		for( itQuoteItem = (*itLevel).second.begin() ; itQuoteItem != (*itLevel).second.end() ; itQuoteItem++ )
		{
			delete (*itQuoteItem).second;
			(*itQuoteItem).second = NULL;
		}
	}
	_mapMarketDepth.erase(key);
	return true;
}

bool MDEStore::addEntryInMarketDepthBook(std::string key)
{
	itMARKETDEPTH_MAP itDepth;
	itDepth = _mapMarketDepth.find(key);

	if( itDepth == _mapMarketDepth.end() )
	{
		MARKETLEVEL_MAP mp;
		_mapMarketDepth.insert( std::pair<std::string,MARKETLEVEL_MAP>( key, mp ) );
		return true;
	}
	return false;

}