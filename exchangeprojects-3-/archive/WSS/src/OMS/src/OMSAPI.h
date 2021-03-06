/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _OMSAPI_H_
#define _OMSAPI_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "ITOrder.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef OMS_EXPORTS
#define OMSAPI __declspec(dllexport)
#else
#define OMSAPI __declspec(dllimport)
#endif


OMSAPI IOrder* __stdcall CreateOrderObject ();



#endif //_OMSAPI_H_


