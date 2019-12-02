// ITIOCP.cpp: implementation of the MyIOCP class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "socket.h"
#include "myIOCP.h"
#include "xlogger.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
//#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

ITIOCP::ITIOCP()
{
	m_bFlood=FALSE;
	m_sSendText="";
	m_iNumberOfMsg=0;
	m_bAutoReconnect=FALSE;
	m_sAutoReconnect="";
	m_iAutoReconnect=0;

	InitializeCriticalSection(&m_StatusLock);
}

ITIOCP::~ITIOCP()
{

}



void ITIOCP::NotifyReceivedPackage(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext)
{
	//m_pServerEvent->OnReceive(pContext->m_ID, (char *)pOverlapBuff->GetBuffer(), nSize);
	////////////////////////////////////////////////////////
	// SO you would process your data here
	// 
	// I'm just going to post message so we can see the data

	/*
	* 0 = text.
	* 1 = FileTransfer.
	* 2 = StartFileTransfer.
	*
	*/
	Packagetext(pOverlapBuff,nSize,pContext);
	//BYTE PackageType=pOverlapBuff->GetPackageType();

	//switch (PackageType)
	//{
	//case Job_SendText2Client :
	//	Packagetext(pOverlapBuff,nSize,pContext);
	//	break;
	//case Job_SendFileInfo :
	//	PackageFileTransfer(pOverlapBuff,nSize,pContext);
	//	break;	
	//case Job_StartFileTransfer: 
	//	PackageStartFileTransfer(pOverlapBuff,nSize,pContext);
	//	break;
	//case Job_AbortFileTransfer:
	//	//#ifdef TRANSFERFILEFUNCTIONALITY
	//	//DisableSendFile(pContext->m_Socket);
	//	//#endif
	//	break;
	//};
}

/*
 * This functions defines what should be done when A job from the work queue is arrived. 
 * (not used). 
 *
 */
void ITIOCP::ProcessJob(JobItem *pJob,IOCPS* pServer)
{

	switch (pJob->m_command)
	{
	case Job_SendText2Client :
	// do Some job here. 
		break;
	} 

}


void ITIOCP::AppendLog(std::string msg)
{
	/*TRACE("%s\r\n",msg);
	int nLen = msg.GetLength();
	char *pBuffer = new char[nLen+1]; 
	strcpy(pBuffer,(const char*)msg);
	pBuffer[nLen]='\0';
	BOOL bRet=::PostMessage(m_hWnd, WM_LOGG_APPEND, 0, (LPARAM) pBuffer);*/
}


void ITIOCP::NotifyNewConnection(ClientContext *pcontext)
{
	m_pServerEvent->OnConnect(pcontext->m_ID, true, (char *)GetHostAddress(pcontext->m_Socket).c_str(), 0);
}

void ITIOCP::NotifyDisconnectedClient(ClientContext *pContext)
{
	m_pServerEvent->OnConnect(pContext->m_ID, false, (char *)GetHostAddress(pContext->m_Socket).c_str(),0);
	EnterCriticalSection(&m_StatusLock);
	if(m_bAutoReconnect)
	{
	    // Wait A Litelbit
		//srand( (unsigned)time( NULL ) );
		Sleep(1000); // Prime number 79,59 ,61 ,67 71,89, 97, 101 generates a better uniform value. 
		Connect(m_sAutoReconnect,m_iAutoReconnect);
	}
	LeaveCriticalSection(&m_StatusLock);

}


void ITIOCP::NotifyNewClientContext(ClientContext *pContext)
{
	pContext->m_iNumberOfReceivedMsg=0;
	pContext->m_bUpdate=TRUE;
}

// Text in a Package is arrived. 
void ITIOCP::Packagetext(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext)
{
	char txt[8193];
	BYTE type;
	UINT nData = 0;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITIOCP::Packagetext:: Before Calling GetPAckageInfo");
	if(pOverlapBuff->GetPackageInfo(type,nData, txt))
	{

		txt[nSize] = '\0';
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITIOCP::Packagetext:: After Calling GetPAckageInfo %d", nSize);
		m_pServerEvent->OnReceive(pContext->m_ID, txt, nSize);
		// to be sure that pcontext Suddenly does not dissapear by disconnection... 
		EnterCriticalSection(&m_ContextMapLock);
		EnterCriticalSection(&pContext->m_ContextLock);
		pContext->m_sReceived=txt;
		// Update that we have data
		pContext->m_iNumberOfReceivedMsg++;
		LeaveCriticalSection(&pContext->m_ContextLock);
		LeaveCriticalSection(&m_ContextMapLock);

		// Update Statistics. 
		EnterCriticalSection(&m_StatusLock);
		m_iNumberOfMsg++;
		LeaveCriticalSection(&m_StatusLock);
		// Send back the message if we are echoing. 
		// Send Flood if needed. 
		//BOOL bRet=FALSE;
		//if(m_bFlood)
		//	bRet=BuildPackageAndSend(pContext,m_sSendText);
		

	}
}


/*
 * This function is called when the remote connection, whant to send a file.  
 *
 */  
void ITIOCP::PackageFileTransfer(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext)
{
//#ifdef TRANSFERFILEFUNCTIONALITY
//	
//	std::string sFileName="";
//	UINT	iMaxFileSize=0;
//	BYTE dummy=0;
//	if(pOverlapBuff->GetPackageInfo(dummy,iMaxFileSize,sFileName))
//	{
//		// Get The Current Path name and application name.
//		std::string sFilePath="";		
//		char drive[_MAX_DRIVE];
//		char dir[_MAX_DIR];
//		char fname[_MAX_FNAME];
//		char ext[_MAX_EXT];
//		std::string strTemp;
//		GetModuleFileName(NULL,strTemp.GetBuffer(MAX_PATH),MAX_PATH);
//		strTemp.ReleaseBuffer();
//		_splitpath( strTemp, drive, dir, fname, ext );
//		sFilePath=drive; //Drive
//		sFilePath+=dir; //dir
//		sFilePath+=sFileName; //name.. 
//		TRACE("Incoming File >%s.\r\n",sFilePath);
//		// Perpare for Receive
//	
//		if(PrepareReceiveFile(pContext->m_Socket,sFilePath,iMaxFileSize))
//		{
//			// Send start file transfer.. 
//			CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);
//			if(pOverlapBuff)
//			{
//				if(pOverlapBuff->CreatePackage(Job_StartFileTransfer))
//			     ASend(pContext,pOverlapBuff);
//
//			}
//		}else
//		{
//		   // Abort Transfer. 
//			CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);
//			if(pOverlapBuff)
//			{
//				if(pOverlapBuff->CreatePackage(Job_AbortFileTransfer))
//			     ASend(pContext,pOverlapBuff);
//
//			}
//		}
//		
//		// to be sure that pcontext Suddenly does not dissapear.. 
//		m_ContextMapLock.Lock();
//		pContext->m_ContextLock.Lock();
//		pContext->m_sReceived=sFilePath;
//		// Update that we have data
//		pContext->m_iNumberOfReceivedMsg++;
//		pContext->m_ContextLock.Unlock();
//		m_ContextMapLock.Unlock();
//
//		// Update Statistics. 
//		EnterCriticalSection(&m_StatusLock);
//		m_iNumberOfMsg++;
//		LeaveCriticalSection(&m_StatusLock);
//	}
//#endif
}

// The remote Connections whant to start the transfer. 
void ITIOCP::PackageStartFileTransfer(CIOCPBuffer *pOverlapBuff,int nSize,ClientContext *pContext)
{
	//#ifdef TRANSFERFILEFUNCTIONALITY
	//StartSendFile(pContext->m_Socket);
	//#endif 
}

BOOL ITIOCP::BuildPackageAndSend(int ClientID, std::string sText)
{
	BOOL bRet=FALSE;
	EnterCriticalSection(&m_ContextMapLock);
	ClientContext* pContext = FindClient(ClientID);

	if (pContext == NULL)
		return FALSE;
	bRet=BuildPackageAndSend(pContext,sText);
	LeaveCriticalSection(&m_ContextMapLock);
	return bRet;
}


// Build the a text message message and send it.. 
BOOL ITIOCP::BuildPackageAndSend(ClientContext *pContext, std::string sText)
{
		CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);
		if(pOverlapBuff)
		{
			if(pOverlapBuff->CreatePackage(Job_SendText2Client,sText))
			return ASend(pContext,pOverlapBuff);
			else
			{
				AppendLog("CreatePackage(0,sText) Failed in BuildPackageAndSend");
				ReleaseBuffer(pOverlapBuff);
				return FALSE;
			}
		
		}else
		{
			//std::string msg;
			//msg.Format("Could not allocate memory ASend: %s",ErrorCode2Text(WSAGetLastError()));
			//AppendLog(msg);
			DisconnectClient(pContext->m_Socket);
			return FALSE;
		}
	return FALSE;	
}

BOOL ITIOCP::BuildFilePackageAndSend(int ClientID,std::string sFile)
{
	BOOL bRet=FALSE;
	EnterCriticalSection(&m_ContextMapLock);
	ClientContext* pContext = FindClient(ClientID);
	if (pContext == NULL)
		return FALSE;
	bRet=BuildFilePackageAndSend(pContext,sFile);
	LeaveCriticalSection(&m_ContextMapLock);
	return bRet;
}

BOOL ITIOCP::BuildPackageAndSendToAll(std::string sText)
{
    	CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);
		if(pOverlapBuff)
		{
			if(pOverlapBuff->CreatePackage(0,sText))
			return ASendToAll(pOverlapBuff);
			else
			{
				AppendLog("CreatePackage(0,sText) Failed in BuildPackageAndSendToAll");
				ReleaseBuffer(pOverlapBuff);
				return FALSE;
			}
		
		}else
		{
			//std::string msg;
			//msg.Format("Could not allocate memory ASend: %s",ErrorCode2Text(WSAGetLastError()));
			//AppendLog(msg);
			return FALSE;
		}
	return FALSE;	
}

/*
 * Perpares for file transfer and sends a package containing information about the file. 
 *
 */
BOOL ITIOCP::BuildFilePackageAndSend(ClientContext *pContext,std::string sFile)
{
	//#ifdef TRANSFERFILEFUNCTIONALITY
	//return PrepareSendFile(pContext->m_Socket,(LPCTSTR)sFile);
	//#else
	return FALSE;
	//#endif
}

BOOL ITIOCP::BuildStartFileTransferPackageAndSend(int ClientID)
{
	BOOL bRet=FALSE;
	EnterCriticalSection(&m_ContextMapLock);
	ClientContext* pContext = FindClient(ClientID);
	if (pContext == NULL)
		return FALSE;
	bRet= BuildStartFileTransferPackageAndSend(pContext);
	LeaveCriticalSection(&m_ContextMapLock);
	return bRet;
}


/*
 * Send a "Start the file transfer package" to the remote connection. 
 *
 *
 */
BOOL ITIOCP::BuildStartFileTransferPackageAndSend(ClientContext *pContext)
{
	CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);
	if(pOverlapBuff)
	{
		if(pOverlapBuff->CreatePackage(Job_StartFileTransfer))
		return ASend(pContext,pOverlapBuff);
		
	}else
	{
		//std::string msg;
		//msg.Format("Could not allocate memory ASend: %s",ErrorCode2Text(WSAGetLastError()));
		//AppendLog(msg);
		DisconnectClient(pContext->m_Socket);
		return FALSE;
	}
	return TRUE;	
}

bool ITIOCP::Send (unsigned int ClientID, char * buff, unsigned int size)
{
	bool bSuccess = false;

	CIOCPBuffer *pOverlapBuff=AllocateBuffer(IOWrite);

	if (pOverlapBuff)
	{
		if(pOverlapBuff->CreatePackage(Job_SendText2Client, size, buff))
		{
			bSuccess = ASend(ClientID, pOverlapBuff);
		}
	}

	return bSuccess;
}

SOCKETAPI Socket* __stdcall CreateServerSocket ()
{
	return new ITIOCP();
}

SOCKETAPI void __stdcall ReleaseServerSocket(Socket* serverSocket)
{
	delete serverSocket;
}

SOCKETAPI Socket* __stdcall CreateClientSocket ()
{
	Socket *pSocket = new ITIOCP();

	

	return pSocket;
}

SOCKETAPI void __stdcall ReleaseClientSocket(Socket* clientSocket)
{
	delete clientSocket;
}
