/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _RMSAPI_H_
#define _RMSAPI_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "ITNonHedgeAccount.h"
#include "ITNonHedgePosition.h"
#include "ITNoUMHedgeAccount.h"
#include "ITNoUMHedgePosition.h"
#include "ITOneUMHedgeAccount.h"
#include "ITOneUMHedgePosition.h"
#include "ITBothUMHedgeAccount.h"
#include "ITBothUMHedgePosition.h"
#include "ITGlobalPosition.h"
#include "RMSCalculator.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef RMS_EXPORTS
#define RMSAPI __declspec(dllexport)
#else
#define RMSAPI __declspec(dllimport)
#endif


RMSAPI IAccount* __stdcall CreateAccountObject (int xAccountType);
RMSAPI IPosition* __stdcall CreatePositionObject (int cAccountType, RMSCalculatorFactory* pCalcFactory);
RMSAPI RMSCalculatorFactory* __stdcall CreateRMSCalculator();
RMSAPI IGlobalPosition * __stdcall CreateGlobalPosition();



#endif //_OMSAPI_H_


