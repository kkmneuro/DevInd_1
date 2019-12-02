// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>
#include <atlbase.h>				// CComPtr
//#include <afxctl.h>					// Connection Points
#include <atlcom.h>
#include <atlhost.h>
#include <atlctl.h>

#ifdef _DEBUG
//Debug mode - TRACE causes printf output
#include <stdio.h>
#define MYTRACE(params) printf params;
#else
//Release mode - TRACE expands to nothing!
#define MYTRACE(params)printf params;
#endif // DEBUG

////#import "D:\Development Work\OME_Exchange\branches\Ver_1_0_0\src\ComContractManager\bin\Debug\ContractManager.tlb" no_namespace, named_guids, raw_native_types, raw_interfaces_only


// TODO: reference additional headers your program requires here
