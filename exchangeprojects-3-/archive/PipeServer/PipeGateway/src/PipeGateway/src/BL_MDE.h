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
#include <vector>
#include <string>

struct MQLTick
{
	double Ask;
	double Bid;
	double LTP;
	double dOpen;
	double dHigh;
	double dLow;
	double dClose;
	double dBidSize;
	double dAskSize;
	double dLastSize;
	double date;
	char productType;
	char contract[20];
};
//*************************************************************************************************
// class BL_MDE
//
//*************************************************************************************************
class CPipeServer;
class BL_MDE	: public IServerBL
{

//METHODS-------
public:
	BL_MDE();
	~BL_MDE();
	IRequest*			getIRequestPointer(MESSAGE msg);
	void				onNewClientAdded(unsigned clientID, IConnectionMgr *mgr = NULL) ;
	void				onClientDisconnected(unsigned clientID) ;	
	void				onNewClientAdded(IClientSession *clientID);
	void				setConnectionMgr(IConnectionMgr* ptrIConnectionMgr) ;
	unsigned int		GetClientID();
	unsigned int		GetClientIDMDE();

	void				submitQuoteRequest( QuoteRequest *pRequest, unsigned clientID, unsigned int msgType, bool isForSubscribe = true );
	void				submitNewsRequest( unsigned long ulAccount, unsigned clientID, bool isForSubscribe = true );

	void				onNewsStream(NewsStream* ptrNewsStream);

	void				BroadcastQuoteItem(QuotesStream *pStream);

	void				removeNewsSubscribers(unsigned int clientID);
	int					InitializeDatabase();

	void				SubmitAllQuotes();

	double GetConversionFormula(std::string symbol);

	void PrepareQuotesStream(MQLTick& tick, 
								 char type, 
								 QuotesStream& stream, 
								 double valMult, 
								 COleDateTime& oleDate, 
								 int MarketLevel, 
								 std::string Gateway,
								 double Price);

	void ManipulateMQLTick(MQLTick& tick, MQLTick& dest);

private:
	void ReadConfig();
private:
	IConnectionMgr*		_ptrIConnectionMgr;

	std::list<unsigned int>		_NewsSubscribers;

	std::string			_strConnString;
	std::string			_strDBUserName;
	std::string			_strDBPassword;

	IDatabase*			_ptrDatabase;

	void LoadAllAssociatedConversions();
	std::map<std::string, double>			m_mapConversionFormula;

	CPipeServer			*m_pPipeServer;

	unsigned m_nClientID;

	CRITICAL_SECTION	m_cs;

	CRITICAL_SECTION	m_csQuotes;
	std::map<std::string, MQLTick>	m_mapQuotes;



};//class BL_MDE

#endif //_BL_MDE_H_


