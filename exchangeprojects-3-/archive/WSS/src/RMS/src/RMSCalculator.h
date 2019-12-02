#pragma once

#include "RMSCalculatorFactory.h"

class IRMSCalculator;

class RMSCalculator: public RMSCalculatorFactory
{
private:
	IRMSCalculator *GetCalculator(symbol& sym);
public:
	RMSCalculator(void);
	~RMSCalculator(void);

	double CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side);
	int CheckMargin(double price, unsigned long long Qty, double lfFees, double lfTax, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side);
	double	CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym);
	double CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize);	
};
