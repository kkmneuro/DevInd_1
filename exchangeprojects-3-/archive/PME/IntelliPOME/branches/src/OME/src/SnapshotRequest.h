#pragma once
#include "OME_Interface.h"


class SnapshotRequest : public IRequest
{
private:
	pQuoteRequest m_pQuotesRequest;
	IOrderHandler* m_ptrOrderHandler;
public:
	SnapshotRequest(void* msg,IOrderHandler*);
	virtual ~SnapshotRequest();
	virtual void Run();
	virtual bool AutoDelete();
};