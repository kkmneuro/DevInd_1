/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
//24 Dec 2013	BR					Ticket TradingApplication/93. Added functions to send signals to monitor server.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _UTILITIESAPI_H_
#define _UTILITIESAPI_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef UTILITIES_EXPORTS
#define UTILITIESAPI __declspec(dllexport)
#else
#define UTILITIESAPI __declspec(dllimport)
#endif

#define SIGNAL_TYPE_STARTUP			1
#define SIGNAL_TYPE_KA				2

#define	SIGNAL_STATUS_STARTING						1
#define	SIGNAL_STATUS_PORTS_READY					2
#define	SIGNAL_STATUS_BO_UP							3
#define	SIGNAL_STATUS_EXTERNAL_CONNS_UP				4
#define	SIGNAL_STATUS_KA							5

#define	SERVER_CM									1
#define SERVER_PIPEGATEWAY							2
#define	SERVER_OME									3
#define	SERVER_MDE									4
#define	SERVER_PME									5
#define SERVER_OMS									6
#define SERVER_FEED									7
struct MonitorSignal
{
	int SERVER;
	int SignalType;
	int Status;
};

UTILITIESAPI void __stdcall AcquireLock (CRITICAL_SECTION *pCS);
UTILITIESAPI void __stdcall ReleaseLock (CRITICAL_SECTION *pCS);
UTILITIESAPI void __stdcall SendSignal (int Server, int SignalType, int Status);
UTILITIESAPI void __stdcall StartKAthread(int Server);
UTILITIESAPI void __stdcall StopKAthread(int Server);



#endif //_UTILITIESAPI_H_


