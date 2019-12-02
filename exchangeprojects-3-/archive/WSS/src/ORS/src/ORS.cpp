// OMS.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ORSAPI.h"



ORSAPI IRoute* __stdcall CreateRouteObject (IDatabase *pDatabaseBO)
{
	return new ITRoute(pDatabaseBO);
}
