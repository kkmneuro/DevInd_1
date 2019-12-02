#include "stdafx.h"
#include "ITFutRMsCalculator.h"



double ITFutRMSCalculator::CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
{
	double lfUsedMargin = 0;

	double ActualCost = Qty * price;

	lfUsedMargin = (ullInitialMargin * ActualCost/ (nLeverage * 100));	

	return lfUsedMargin;
}

//int ITFutRMSCalculator::CheckMargin(double price, unsigned long long Qty, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
//{
//}
//
//double	ITFutRMSCalculator::CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym)
//{
//}

double ITFutRMSCalculator::CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize)
{
	double lfProfit = 0;

	if (side == SIDE_SELL)
	{
		lfProfit = ((LastPx - AvgPx) * Qty);
	}
	else
	{
		lfProfit = ((AvgPx - LastPx) * Qty);
	}

	return lfProfit;
}
