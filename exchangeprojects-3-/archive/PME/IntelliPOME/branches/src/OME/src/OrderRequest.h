#pragma once
#include "OME_Interface.h"

class MarketOrderRequest : public IRequest, public IMarketOrderRequest
{
private:
	pNewOrderRequest m_ptrNewOrderReq;
	IOrderHandler* m_ptrOrderHandler;
public:
	MarketOrderRequest(void* msg,IOrderHandler*);
	virtual ~MarketOrderRequest();
	virtual void Run();
	virtual bool AutoDelete();
	virtual bool operator == (IMarketOrderRequest& order);
	virtual bool operator < (IMarketOrderRequest& order);
};

class LimitOrderRequest : public IRequest, public ILimitOrderRequest
{
private:
	pNewOrderRequest m_ptrNewOrderReq;
	IOrderHandler* m_ptrOrderHandler;
public:
	LimitOrderRequest(void* msg,IOrderHandler* pOrderHandler);
	LimitOrderRequest(void* Header, void *Order,unsigned long remainingQty,IOrderHandler* pOrderHandler);
	virtual ~LimitOrderRequest();
	virtual void Run();
	virtual bool AutoDelete();
	virtual bool operator == (ILimitOrderRequest& order);
	virtual bool operator < (ILimitOrderRequest& order);
};

class StopOrderRequest : public IRequest, public IStopOrderRequest
{
private:
	pNewOrderRequest m_ptrNewOrderReq;
	IOrderHandler* m_ptrOrderHandler;
public:
	StopOrderRequest(void* msg,IOrderHandler* pOrderHandler);
	StopOrderRequest(void* Header, void *Order,unsigned long remainingQty,IOrderHandler* pOrderHandler);
	virtual ~StopOrderRequest();
	virtual void Run();
	virtual bool AutoDelete();
	virtual bool operator == (IStopOrderRequest& order);
	virtual bool operator < (IStopOrderRequest& order);
};

class CancelOrderRequest : public IRequest, public ICancelOrderRequest
{
private:
	pOrderCancelRequest m_ptrOrderCancelReq;
	IOrderHandler* m_ptrOrderHandler;
public:
	CancelOrderRequest(void* msg,IOrderHandler* pOrderHandler);
	virtual ~CancelOrderRequest();
	virtual void Run();
	virtual bool AutoDelete();
	virtual bool operator == (ICancelOrderRequest& order);
	virtual bool operator < (ICancelOrderRequest& order);
};

class CancelReplaceOrderRequest : public IRequest, public ICancelReplaceOrderRequest
{
private:
	pOrderReplaceRequest m_ptrOrderReplaceReq;
	IOrderHandler* m_ptrOrderHandler;
public:
	CancelReplaceOrderRequest(void* msg,IOrderHandler* pOrderHandler);
	virtual ~CancelReplaceOrderRequest();
	virtual void Run();
	virtual bool AutoDelete();
	virtual bool operator == (ICancelReplaceOrderRequest& order);
	virtual bool operator < (ICancelReplaceOrderRequest& order);
};