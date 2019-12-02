/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _IRequestQuote_H_
#define _IRequestQuote_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "BL_MDE.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
enum eRequestType
{
	eQuote = 0,
	eSnap = 1,
	eDOM  = 2,
};




//*************************************************************************************************
// class IRequestQuote
//
//*************************************************************************************************
class IRequestQuote	: public IRequest
{

//METHODS-------
public:
	IRequestQuote(QuoteRequest *pRequest, unsigned int clntID, unsigned int msgType, IClientSession *pSession, BL_MDE* ptrBLMDE);
	~IRequestQuote();
	virtual void Run();
	virtual bool AutoDelete();

private:
	QuoteRequest*						m_pRequest;
	BL_MDE*								_ptrBL_MDE;	
	unsigned int						_ClntID;
	IClientSession*						m_pSession;
	unsigned int						m_unMsgType;
};//class IRequestQuote


#endif //_IRequestQuote_H_