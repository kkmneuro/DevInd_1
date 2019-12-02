// RMS.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "RMSAPI.h"



RMSAPI IAccount* __stdcall CreateAccountObject (int nHedgeType)
{
	if (nHedgeType == HEDGING_NOT_SUPPORT)
		return new ITNonHedgeAccount();
	else if (nHedgeType == HEDGING_NIL_MARGIN)
		return new ITNoUMHedgeAccount();
	else if (nHedgeType == HEDGING_ONE_SIDE_MARGIN)
		return new ITOneUMHedgeAccount();
	else if (nHedgeType == HEDGING_BOTH_SIDE_MARGIN)
		return new ITBothUMHedgeAccount();

	return NULL;
}

RMSAPI IPosition* __stdcall CreatePositionObject (int nHedgeType, RMSCalculatorFactory* pCalcFactory)
{
	if (nHedgeType == HEDGING_NOT_SUPPORT)
		return new ITNonHedgePosition(pCalcFactory);
	else if (nHedgeType == HEDGING_NIL_MARGIN)
		return new ITNoUMHedgePosition(pCalcFactory);
	else if (nHedgeType == HEDGING_ONE_SIDE_MARGIN)
		return new ITOneUMHedgePosition(pCalcFactory);
	else if (nHedgeType == HEDGING_BOTH_SIDE_MARGIN)
		return new ITBothUMHedgePosition(pCalcFactory);

	return NULL;
}

RMSAPI RMSCalculatorFactory* __stdcall CreateRMSCalculator()
{
	return new RMSCalculator();
}

RMSAPI IGlobalPosition * __stdcall CreateGlobalPosition()
{
  return new ITGlobalPosition();
}