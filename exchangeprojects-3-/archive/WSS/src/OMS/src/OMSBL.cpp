///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//29-01-2012	BR			1. Class declaration and definitions. The class manages the business logic for the OMS.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "OMSBL.h"
#include "OMSAPI.h"

OMSBL::OMSBL()
{

}

OMSBL::OMSBL()
{
}


OMSAPI IServerBL* __stdcall CreateOMSBL ()
{
	return new OMSBL();
}