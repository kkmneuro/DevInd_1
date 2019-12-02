#include "IRMSCalculator.h"
#include <map>


class ITFxRMSCalculator: public IRMSCalculator
{
private:
	std::map<std::string, double>	m_mapCurrencyFactor;
public:
	ITFxRMSCalculator();
	double GetCurrencyFactor(std::string strSymbol);
	double CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side);
	//int CheckMargin(double price, unsigned long long Qty, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side);
	//double	CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym);
	double CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize);	
};