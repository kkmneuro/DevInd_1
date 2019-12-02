#pragma once


#ifdef OME_EXPORTS
#define OMEAPI __declspec(dllexport)
#else
#define OMEAPI __declspec(dllimport)
#endif

OMEAPI IServerBL* __stdcall Create_OME_BL (IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE);
