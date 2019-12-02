/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "IRequestQuote.h"


//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "IRequestQuote"




IRequestQuote::IRequestQuote(QuoteRequest *pRequest, unsigned int clntID, unsigned int msgType, IClientSession *pSession, BL_MDE* ptrBLMDE)
:m_pRequest(pRequest),
_ClntID(clntID),
m_unMsgType(msgType),
m_pSession(pSession),
_ptrBL_MDE(ptrBLMDE)
{
}

IRequestQuote::~IRequestQuote()
{
	if (m_pRequest)
	{
		free(m_pRequest);
		m_pRequest = NULL;
	}
}

void IRequestQuote::Run()
{
	if (m_unMsgType == QUOTE__REQUEST)
	{
		_ptrBL_MDE->submitQuoteRequest(m_pRequest, _ClntID, m_unMsgType, m_pSession->GetGroupID(), m_pRequest->isForSubscribe);
	}
}

bool IRequestQuote::AutoDelete()
{
	return true;
}