#include "stdafx.h"
#include "OrderProcessor.h"
#include "Market.h"

OrderProcessor::OrderProcessor()
{
	m_ptrMarket=new Market();
}

OrderProcessor::~OrderProcessor()
{
	delete m_ptrMarket;
}

void OrderProcessor::ProcessOrder(IMarketOrderRequest* order)
{
}

void OrderProcessor::ProcessOrder(ILimitOrderRequest* order)
{
	if(m_ptrMarket)
	{
		m_ptrMarket->AddOrder(order);
	}
}
