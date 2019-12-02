#include "IGlobalPosition.h"

#pragma once

class ITGlobalPosition : public IGlobalPosition
{
public:
  ITGlobalPosition();  
  virtual void UpdatePosition(symbol& sym, 
								char side, 
								unsigned long filledPrice, 
								unsigned long filledQty, 
								double lfRealizedPnL,
								char PositionEffect);
  virtual void GetPosition(symbol& sym, 
                            unsigned long& ulLongPos,
                            unsigned long& ultotalBuyVal,
                            unsigned long& ulshortPos,
                            unsigned long& ulTotalSellVal,
							double&		   lgRealizedPnL,
                            double&        lfLongAvgPrice,
                            double&        lfShortAvgPrice);
};