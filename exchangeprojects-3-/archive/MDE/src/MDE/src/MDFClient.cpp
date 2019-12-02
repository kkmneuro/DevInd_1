/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "MDFClient.h"
#include "MDEDataManager.h"
#include "BL_MDE.h"
#include "xlogger.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "MDFClient"




MDFClient::MDFClient(BL_MDE* ptr, bool bAuth)
: _ptrIClientProtocol(NULL),
_ptrMDE(ptr),
_strUserName(""),
_strPassword(""),
_sPort(0),
_strServer(""),
_strHost("")
{
	_isLoginSend = false;
	_bAuth = bAuth;
}

MDFClient::~MDFClient()
{
	_ptrIClientProtocol->Disconnect();
	ReleaseClientProtocol( _ptrIClientProtocol );
	_ptrIClientProtocol = NULL;
}

//*******************************************************************            
//  FUNCTION:   - login()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
bool MDFClient::login(const std::string& user, const std::string& pwd, const std::string& server/* = ""*/, const std::string& host /*= ""*/, long port/* = 0*/)
{
	_strUserName = user;
	_strPassword = pwd;
	_strServer = server;
	_strHost = host;
	_sPort = (short)port;
	char *IP;
	IP = new char[server.length() + 1];
	strcpy(IP, server.c_str());
	IP[server.length()] = '\0';
	if( _ptrIClientProtocol == NULL )
	{
		_ptrIClientProtocol = CreateClientProtocol(); 
		_ptrIClientProtocol->RegisterClient(this);
	}

	bool flag =  _ptrIClientProtocol->Connect( IP, _sPort );
	delete IP;
	IP = NULL;
	return flag;
	
}
//*******************************************************************            
//  FUNCTION:   - OnMsgRecv()
//              
//  RETURNS:    -
//              
//  PARAMETERS: -
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
void MDFClient::OnMsgRecv(void* msg,unsigned int msgtype)
{
	switch(msgtype)
	{
	case QUOTE_SNAP_SHOT_RESPONSE:
		{
			QuotesSnapshotResponse* ptrQuotesSnapshotResponse = ( QuotesSnapshotResponse* )msg;

			if (_ptrMDE && _ptrMDE->m_pMDEDataManager)
				_ptrMDE->m_pMDEDataManager->updateSnapItem(*ptrQuotesSnapshotResponse);
		}
		break;
	case QUOTES_STREAM:
		{
			QuotesStream* ptrQuotesStream = ( QuotesStream* )msg;

			if (_ptrMDE && _ptrMDE->m_pMDEDataManager)
			{
				for (int nCount=0;nCount<ptrQuotesStream->NoOfSymbols;nCount++)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "MDFClient::OnMsgRecv, Count=%d, Contract=%s, Type=%c, Value = %lu, Size = %lu", nCount, ptrQuotesStream->QuotesItem[nCount].Symbol.Contract, ptrQuotesStream->QuotesItem[nCount].QuotesStreamType, (unsigned long)ptrQuotesStream->QuotesItem[nCount].Price, (unsigned long)ptrQuotesStream->QuotesItem[nCount].Size);
				}
				_ptrMDE->m_pMDEDataManager->AddQuotesResponseToQueue(ptrQuotesStream);
			}
		}
		break;
	case NEWS_STREAM:
		{
			NewsStream* ptrNewsStream = ( NewsStream* )msg;
			_ptrMDE->onNewsStream(ptrNewsStream);
		}
		break;
	case LOGON_RESPONSE:
		LogonResponse *pResponse = (LogonResponse *)msg;

		if (pResponse)
		{
			if (strcmp(pResponse->Reason, "VALID") == 0)
			{
				// Login Successfull
				// Send Participant Request
			}
			else
			{
				// Disconnect connection
			}

			free(pResponse);
		}
		break;

	}
	/*free(msg);
	msg = NULL;*/

}
void MDFClient::OnConnectionStatus(int status,unsigned int ClientID)
{
	_ClientID = ClientID;

	if (status != 0 && status != 3)
	{
		// Request for subscriptions
		if (_ptrMDE)
			_ptrMDE->SubmitAllQuotes();
	}
	if( status == 1 && _bAuth)
	{
		LogonRequest *pRequest = (LogonRequest *)GetMessageObject(LOGON_REQUEST);

		if (pRequest)
		{
			strcpy(pRequest->UserName, _strUserName.c_str());
			strcpy(pRequest->Password, _strPassword.c_str());
			pRequest->Version = 1.15;
			strcpy(pRequest->Header.SenderID, "5");

			_ptrIClientProtocol->Send(_ClientID, pRequest, LOGON_REQUEST);

			free (pRequest);
		}
	}
	MYTRACE( ("Client Status: %d",status) );
	
}

void MDFClient::OnSendStatus(bool isSuccess,unsigned long long PacketID)
{
}

