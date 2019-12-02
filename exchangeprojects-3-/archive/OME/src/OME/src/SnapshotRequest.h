#pragma once
#include "OME_Interface.h"


class SnapshotRequest : public IRequest
{
private:
	void *m_pRequest;
	int m_nMsgType;
	//pQuoteRequest m_pQuotesRequest;
	IOrderHandler* m_ptrOrderHandler;
public:
	SnapshotRequest(void* msg,IOrderHandler*, int nMsgType);
	virtual ~SnapshotRequest();
	virtual void Run();
	virtual bool AutoDelete();
};