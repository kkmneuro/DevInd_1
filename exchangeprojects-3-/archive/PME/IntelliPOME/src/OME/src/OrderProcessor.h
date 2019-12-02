#pragma once
#include "OME_Interface.h"

class OrderProcessor : public IOrderProcessor
{
private:
	IMarket* m_ptrMarket;
public:
	OrderProcessor();
	virtual ~OrderProcessor();
	virtual void ProcessOrder(IMarketOrderRequest*);
	virtual void ProcessOrder(ILimitOrderRequest*);
};