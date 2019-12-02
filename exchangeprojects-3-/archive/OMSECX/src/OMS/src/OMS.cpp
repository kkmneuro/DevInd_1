// OMS.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "OMSAPI.h"



OMSAPI IOrder* __stdcall CreateOrderObject ()
{
	return new ITOrder();
}
