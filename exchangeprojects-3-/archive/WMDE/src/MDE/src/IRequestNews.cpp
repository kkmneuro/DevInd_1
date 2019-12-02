/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "IRequestNews.h"


//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "IRequestNews"




IRequestNews::IRequestNews(pnewsRequest nr,unsigned int clntID,BL_MDE* ptrBLMDE)
:_ptrnewsRequest(nr),
 _ClntID(clntID),
 _ptrBL_MDE(ptrBLMDE)
{
	_isForSubscribe = _ptrnewsRequest->isForSubscribe;
}

IRequestNews::~IRequestNews()
{
	delete _ptrnewsRequest;
}

void IRequestNews::Run()
{
	_ptrBL_MDE->submitNewsRequest( _ptrnewsRequest->Account, _ClntID , _isForSubscribe );
}

bool IRequestNews::AutoDelete()
{
	return true;

}
