/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _ORSAPI_H_
#define _ORSAPI_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "ITRoute.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef ORS_EXPORTS
#define ORSAPI __declspec(dllexport)
#else
#define ORSAPI __declspec(dllimport)
#endif


ORSAPI IRoute* __stdcall CreateRouteObject (IDatabase *pDatabaseBO);



#endif //_OMSAPI_H_


