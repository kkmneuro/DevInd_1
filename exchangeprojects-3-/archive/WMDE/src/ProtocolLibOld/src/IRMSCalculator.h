#include <stdafx.h>
#include "DataDef.h"


#pragma once

class IRMSCalculator
{
public:
	virtual double CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side) = 0;
	//virtual int CheckMargin(double price, unsigned long long Qty, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side) = 0;
	//virtual double	CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym) = 0;
	virtual double CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize) = 0;	
};


