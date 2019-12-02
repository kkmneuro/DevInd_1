/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _MDEStore_H_
#define _MDEStore_H_

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
class MyQuoteItem;
typedef std::map<char,MyQuoteItem*>							QuoteItem_MAP;
typedef std::map<unsigned int,QuoteItem_MAP>				MARKETLEVEL_MAP;
typedef std::map<std::string,MARKETLEVEL_MAP>				MARKETDEPTH_MAP;//MAP[string][level][stream type] = MyQuoteItem
typedef std::map<std::string,MyQuoteItem*>					SNAPSHOT_MAP;
typedef std::map<unsigned int,std::vector<MyQuoteItem*>>	DOM_MAP;

typedef QuoteItem_MAP::iterator								itQuoteItem_MAP;
typedef MARKETLEVEL_MAP::iterator							itMARKETLEVEL_MAP;
typedef MARKETDEPTH_MAP::iterator							itMARKETDEPTH_MAP;
typedef SNAPSHOT_MAP::iterator								itSNAPSHOT_MAP;




//*************************************************************************************************
// class MyQuoteItem
//
//*************************************************************************************************
class MyQuoteItem
{
public:
	MyQuoteItem( pQuotesItem item, std::string& key );
	MyQuoteItem( pQuotesItem item, std::string& key, bool forSnapShot);
	MyQuoteItem( pOHLC item, std::string& key);
	~MyQuoteItem();

    void UpdateItem(pQuotesItem item);
	void UpdateItem(pOHLC item);
	void UpdateItemforSnapshot(pQuotesItem item);
	
	pQuotesItem			_ptrQuoteItem;
	pOHLC				_ptrOHLC;
	
	int					_Digits;
	std::string			_strKey;
	std::string			_strGateway;
	std::string         _strProductType;
	std::string         _strProduct;
	std::string         _strContract;
};




//*************************************************************************************************
// class MDEStore
//
//*************************************************************************************************
class MDEStore	
{

//METHODS-------
public:
	MDEStore(BL_MDE* ptrMDE, DWORD dwCode);
	~MDEStore();
	std::vector<MyQuoteItem*>*			GetLatestQuote( symbol* ptrSymbol )  ;

	pOHLC								GetLatestSnapShot( symbol* ptrSymbol )  ;

	DOM_MAP*							GetLatestDOM( symbol* ptrSymbol )  ;

	std::vector<MyQuoteItem*>*			GetLatestQuote( std::string* key )  ;

	pOHLC								GetLatestSnapShot( std::string* key )  ;

	DOM_MAP*							GetLatestDOM( std::string* key )  ;

	void								updateQuoteItem(pQuotesStream ptrQuotesStream);

	void								updateSnapItem(pQuotesSnapshotResponse ptrQuotesSnapshotResponse);

	void								updateSnapItem(pQuotesStream ptrQuotesStream);

	bool								removeEntryInMarketDepthBook(std::string key);

	bool								addEntryInMarketDepthBook(std::string key);

private:
	std::string*						getKey(symbol* PtrSymbol_);

//MEMBERS-------
private:
	SNAPSHOT_MAP						_mapSnaphot;
	MARKETDEPTH_MAP						_mapMarketDepth;
	BL_MDE*								_ptrMDE;

	DWORD							m_dwGITCode;
};//class MDEStore


#endif //_MDEStore_H_