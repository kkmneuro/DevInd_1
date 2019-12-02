// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>
#include <atlbase.h>


#import "ContractServer.tlb" no_namespace, named_guids, raw_native_types, raw_interfaces_only

//#import "D:\\LTech Codebase\\WSS\WSS\\src\\MT4ManagerInterface\\MT4ManagerInterface\\Debug\\MT4ManagerInterface.dll"
// TODO: reference additional headers your program requires here
enum
{
	//---
	TT_PRICES_GET,                      // prices requets
	TT_PRICES_REQUOTE,                  // requote
	//--- client trade transaction
	TT_ORDER_IE_OPEN = 64,                // open order (Instant Execution)
	TT_ORDER_REQ_OPEN,                  // open order (Request Execution)
	TT_ORDER_MK_OPEN,                   // open order (Market Execution)
	TT_ORDER_PENDING_OPEN,              // open pending order
	//---
	TT_ORDER_IE_CLOSE,                  // close order (Instant Execution)
	TT_ORDER_REQ_CLOSE,                 // close order (Request Execution)
	TT_ORDER_MK_CLOSE,                  // close order (Market Execution)
	//---
	TT_ORDER_MODIFY,                    // modify pending order
	TT_ORDER_DELETE,                    // delete pending order
	TT_ORDER_CLOSE_BY,                  // close order by order
	TT_ORDER_CLOSE_ALL,                 // close all orders by symbol
	//--- broker trade transactions
	TT_BR_ORDER_OPEN,                   // open order
	TT_BR_ORDER_CLOSE,                  // close order
	TT_BR_ORDER_DELETE,                 // delete order (ANY OPEN ORDER!!!)
	TT_BR_ORDER_CLOSE_BY,               // close order by order
	TT_BR_ORDER_CLOSE_ALL,              // close all orders by symbol
	TT_BR_ORDER_MODIFY,                 // modify open price, stoploss, takeprofit etc. of order
	TT_BR_ORDER_ACTIVATE,               // activate pending order
	TT_BR_ORDER_COMMENT,                // modify comment of order
	TT_BR_BALANCE                       // balance/credit
};

enum { OP_BUY = 0, OP_SELL, OP_BUY_LIMIT, OP_SELL_LIMIT, OP_BUY_STOP, OP_SELL_STOP, OP_BALANCE, OP_CREDIT };
