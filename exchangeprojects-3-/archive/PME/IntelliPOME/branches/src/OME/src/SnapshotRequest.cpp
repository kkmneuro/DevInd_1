#include "stdafx.h"
#include "SnapshotRequest.h"
#include "xlogger.h"

SnapshotRequest::SnapshotRequest(void *msg,IOrderHandler* pOrderHandler)
{
	m_pQuotesRequest = (pQuoteRequest)msg;
	m_ptrOrderHandler = pOrderHandler;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::SnapshotRequest");
}

SnapshotRequest::~SnapshotRequest()
{
	delete m_pQuotesRequest;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::~SnapshotRequest");
}

void SnapshotRequest::Run()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::Run, Entered");

	if(m_ptrOrderHandler)
	{
		m_ptrOrderHandler->HandleSnapshotRequest(m_pQuotesRequest);
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::Run, Exit");
}

bool SnapshotRequest::AutoDelete()
{
	return false;
}
