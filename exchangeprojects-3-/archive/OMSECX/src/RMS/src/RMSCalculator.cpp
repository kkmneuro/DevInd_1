#include "StdAfx.h"
#include "datadef.h"
#include "RMSCalculator.h"
#include "ITFxRMSCalculator.h"
#include "ITFutRMSCalculator.h"

RMSCalculator::RMSCalculator(void)
{
	m_pFXCalculator = new ITFxRMSCalculator();
	m_pFUTCalculator = new ITFutRMSCalculator();
}

RMSCalculator::~RMSCalculator(void)
{
	if (m_pFXCalculator)
	{
		delete m_pFXCalculator;
		m_pFXCalculator = NULL;
	}

	if (m_pFUTCalculator)
	{
		delete m_pFUTCalculator;
		m_pFUTCalculator = NULL;
	}
}

IRMSCalculator *RMSCalculator::GetCalculator(symbol& sym)
{
	IRMSCalculator *pCalc = NULL;

	switch (sym.ProductType)
	{
	case SECURITY_TYPE_FX:
		pCalc = m_pFXCalculator;
		break;
	case SECURITY_TYPE_FUT:
		pCalc = m_pFUTCalculator;
		break;
	}

	return pCalc;
}


double RMSCalculator::CalculateUsedMargin(unsigned long long Qty, double price, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
{
	double lfUsedMargin = 0;

	IRMSCalculator *pCalc = NULL;

	pCalc = GetCalculator(sym);

	if (pCalc)
	{
		lfUsedMargin = pCalc->CalculateUsedMargin(Qty, price, nLeverage, ullInitialMargin,sym, side);
	}

	return lfUsedMargin;
}

//int RMSCalculator::CheckMargin(double price, unsigned long long Qty, int nLeverage, unsigned long long ullInitialMargin, symbol& sym, char side)
//{
//}
//
//double	RMSCalculator::CalculateOpenPnL(double bid, double ask, double AvgPx, unsigned long long CumQty, char side, symbol& sym)
//{
//}

double RMSCalculator::CalculateProfit(unsigned long long LastPx, double AvgPx,	unsigned long long Qty, char side, symbol& sym, unsigned long ullContractSize)
{
	double lfProfit = 0;

	IRMSCalculator *pCalc = NULL;

	pCalc = GetCalculator(sym);

	if (pCalc)
	{
		lfProfit = pCalc->CalculateProfit(LastPx, AvgPx, Qty, side, sym, ullContractSize);
	}

	return lfProfit;
}

