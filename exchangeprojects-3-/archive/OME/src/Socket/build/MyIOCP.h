// ITIOCP.h: interface for the MyIOCP class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ITIOCP_H__4093193A_D0A0_4E6A_82FA_65B17A1FEB71__INCLUDED_)
#define AFX_ITIOCP_H__4093193A_D0A0_4E6A_82FA_65B17A1FEB71__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "IOCPS.h"
//
//#define WM_NEW_CONNECTION	WM_APP + 0x1001
//#define WM_LOGG_APPEND	WM_NEW_CONNECTION+1
//#define WM_CLIENTDISCONNECTED  WM_NEW_CONNECTION+2


class ITIOCP : public IOCPS  
{
public:
	virtual void NotifyNewClientContext(ClientContext *pContext);
	CRITICAL_SECTION m_StatusLock;
	// Used to Flood.. 
	volatile BOOL m_bFlood;
	std::string m_sSendText;

	HWND m_hWnd;
	ITIOCP();
	virtual ~ITIOCP();
	// A client have Disconnected. 
	virtual void NotifyDisconnectedClient(ClientContext *pContext);
	
    virtual void NotifyNewConnection(ClientContext *pcontext);

	// A Package have arrived. 
	virtual void NotifyReceivedPackage(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext);
	
	// Called to do some work. 
	virtual inline void ProcessJob(JobItem *pJob,IOCPS* pServer);

	virtual void AppendLog(std::string msg);
	int m_iNumberOfMsg;

	bool Send (unsigned int ClientID, char * buff, unsigned int size);

	// Text in a Package is arrived. 
	void Packagetext(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext);
	// A File transfer info package is arrived
	void PackageFileTransfer(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext);
	// A start transfering package is arrived. 
	void PackageStartFileTransfer(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext);
	// Build the a text message message and send it.. 
	BOOL BuildPackageAndSend(ClientContext *pContext,std::string sText);
	BOOL BuildPackageAndSend(int ClientID,std::string sText);
	BOOL BuildPackageAndSendToAll(std::string sText);


	// Builds a Package containing info about a filetranser and send it to the Remote Computer
	BOOL BuildFilePackageAndSend(ClientContext *pContext,std::string sFile);
	BOOL BuildFilePackageAndSend(int ClientID,std::string sFile);

	// Build StartFilsTransfer 
	BOOL BuildStartFileTransferPackageAndSend(ClientContext *pContext);
	BOOL BuildStartFileTransferPackageAndSend(int ClientID);
	// Auoreconnect stuff. 
	BOOL m_bAutoReconnect;
	std::string m_sAutoReconnect;
	int m_iAutoReconnect;
	
};

#endif // !defined(AFX_ITIOCP_H__4093193A_D0A0_4E6A_82FA_65B17A1FEB71__INCLUDED_)
