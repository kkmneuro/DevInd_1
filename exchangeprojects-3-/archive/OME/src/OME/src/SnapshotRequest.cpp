#include "stdafx.h"
#include "SnapshotRequest.h"
#include "xlogger.h"

SnapshotRequest::SnapshotRequest(void *msg,IOrderHandler* pOrderHandler, int nMsgType)
{
	//m_pQuotesRequest = (pQuoteRequest)msg;
	m_pRequest = msg;
	m_nMsgType = nMsgType;
	m_ptrOrderHandler = pOrderHandler;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::SnapshotRequest");
}

SnapshotRequest::~SnapshotRequest()
{
	free(m_pRequest);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::~SnapshotRequest");
}

void SnapshotRequest::Run()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::Run, Entered");

	if(m_ptrOrderHandler)
	{
		if (m_nMsgType == RELOAD_DPR)
		{
			m_ptrOrderHandler->HandleReloadDPR((ReloadDPR *)m_pRequest);
		}
		else
		{
			m_ptrOrderHandler->HandleSnapshotRequest((pQuoteRequest)m_pRequest);
		}
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SnapshotRequest::Run, Exit");
}

bool SnapshotRequest::AutoDelete()
{
	return true;
}
