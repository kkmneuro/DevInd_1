#include "stdafx.h"
#include "ITFxRMsCalculator.h"


ITFxRMSCalculator::ITFxRMSCalculator()
{
	// This shd be loaded from DB, and proably in the contract manager
	std::pair<std::string, double> pr("AUDCAD", 1.01366);
	m_mapCurrencyFactor.insert(pr);

	std::pair<std::string, double> pr1("AUDCHF", 1.07849);
	m_mapCurrencyFactor.insert(pr1);

	std::pair<std::string, double> pr2("AUDJPY", 0.01137);
	m_mapCurrencyFactor.insert(pr2);

	std::pair<std::string, double> pr3("AUDNZD", .82287);
	m_mapCurrencyFactor.insert(pr3);

	std::pair<std::string, double> pr4("AUDUSD", 1);
	m_mapCurrencyFactor.insert(pr4);

	std::pair<std::string, double> pr5("CADCHF", 1.07849  );
	m_mapCurrencyFactor.insert(pr5);

	std::pair<std::string, double> pr6("CADJPY", 0.0113726);
	m_mapCurrencyFactor.insert(pr6);

	std::pair<std::string, double> pr7("CHFJPY", 0.0113726);
	m_mapCurrencyFactor.insert(pr7);

	std::pair<std::string, double> pr8("EURAUD", 1.04172);
	m_mapCurrencyFactor.insert(pr8);

	std::pair<std::string, double> pr9("EURCAD", 1.01366);
	m_mapCurrencyFactor.insert(pr9);

	std::pair<std::string, double> pr10("EURCHF", 1.07849);
	m_mapCurrencyFactor.insert(pr10);

	std::pair<std::string, double> pr11("EURGBP", 1.60189);
	m_mapCurrencyFactor.insert(pr11);

	std::pair<std::string, double> pr12("EURJPY", 0.01137);
	m_mapCurrencyFactor.insert(pr12);

	std::pair<std::string, double> pr13("EURNZD", .82338);
	m_mapCurrencyFactor.insert(pr13);

	std::pair<std::string, double> pr14("EURUSD", 1);
	m_mapCurrencyFactor.insert(pr14);

	std::pair<std::string, double> pr15("GBPAUD", 1.04185);
	m_mapCurrencyFactor.insert(pr15);

	std::pair<std::string, double> pr16("GBPCAD", 1.01366);
	m_mapCurrencyFactor.insert(pr16);

	std::pair<std::string, double> pr17("GBPCHF", 1.07849);
	m_mapCurrencyFactor.insert(pr17);

	std::pair<std::string, double> pr18("GBPJPY", 0.01137);
	m_mapCurrencyFactor.insert(pr18);

	std::pair<std::string, double> pr19("GBPUSD", 1);
	m_mapCurrencyFactor.insert(pr19);

	std::pair<std::string, double> pr20("NZDJPY", 0.01137);
	m_mapCurrencyFactor.insert(pr20);

	std::pair<std::string, double> pr21("NZDUSD", 1);
	m_mapCurrencyFactor.insert(pr21);

	std::pair<std::string, double> pr22("USDCAD", 1.01366);
	m_mapCurrencyFactor.insert(pr22);

	std::pair<std::string, double> pr23("USDCHF", 1.07849);
	m_mapCurrencyFactor.insert(pr23);

	std::pair<std::string, double> pr24("USDJPY", 0.01137);
	m_mapCurrencyFactor.insert(pr24);
}

double ITFxRMSCalculator::GetCurrencyFactor(std::string strSymbol)
{
	double lfFactor = 1;

	std::map<std::string, double>::iterator iter = m_mapCurrencyFactor.find(strSymbol);

	if (iter != m_mapCurrencyFactor.end())
	{
		lfFactor = iter->second;
	}

	return lfFactor;
}

double ITFxRMSCalculator::CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
{
	double lfUsedMargin = 0;

	double ActualCost = Qty * price;

	lfUsedMargin = (ActualCost/ (nLeverage)) * GetCurrencyFactor(sym.Contract);	

	return lfUsedMargin;
}

//int ITFxRMSCalculator::CheckMargin(double price, unsigned long long Qty, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
//{
//
//}

//double	ITFxRMSCalculator::CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym)
//{
//}

double ITFxRMSCalculator::CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize)
{
	double lfProfit = 0;

	if (side == SIDE_SELL)
	{
		lfProfit = ((LastPx - AvgPx) * Qty / ullContractSize) * GetCurrencyFactor(sym.Contract);
	}
	else
	{
		lfProfit = ((AvgPx - LastPx) * Qty / ullContractSize) * GetCurrencyFactor(sym.Contract);
	}

	return lfProfit;
}