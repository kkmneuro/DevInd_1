///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//07-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//#include "DataDef.h"
#include <string>
#include <list>
#include <map>
#include "Datadef.h"


#pragma once


struct GlobalPosition
{
	unsigned long	m_ulLongPosition;
	unsigned long	m_ulTotalBuyVal;
	unsigned long	m_ulShortPosition;
	unsigned long	m_ulTotalSellVal;
	double			  m_lfLongAvgPrice;
	double			  m_lfShortAvgPrice;
	double			  m_lfRealizedProfit;
};

class IGlobalPosition
{
protected:
  std::map<std::string, GlobalPosition>         m_mapSymbolGlobalPos;

  CRITICAL_SECTION                              CS_GLOBALPOS;

public:
  virtual void UpdatePosition(symbol& sym, 
							char side, 
							unsigned long filledPrice, 
							unsigned long filledQty, 
							double lfRealizedPnL,
							char PositionEffect) = 0;
  virtual void GetPosition(symbol& sym, 
                            unsigned long& ulLongPos,
                            unsigned long& ultotalBuyVal,
                            unsigned long& ulshortPos,
                            unsigned long& ulTotalSellVal,
							double&		   lgRealizedPnL,
                            double&        lfLongAvgPrice,
                            double&        lfShortAvgPrice) = 0;

};