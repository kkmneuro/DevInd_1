/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include "GatewayClient.h"
#include "ITroute.h"
#include "ServerInterface.h"
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
#define _this "GATEWAYClient"




GatewayClient::GatewayClient(IRoute *route, bool bAuthReq): 
_ptrIClientProtocol(NULL),
_strUserName(""),
_strPassword(""),
_sPort(0),
_strServer(""),
_strHost("")
{
	_ptrRoute = route;
	_isLoginSend = false;
	_AccountNo = 0;
	_bAuthReq = bAuthReq;
}

GatewayClient::~GatewayClient()
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
bool GatewayClient::login(const std::string& user, const std::string& pwd, const std::string& server/* = ""*/, const std::string& host /*= ""*/, long port/* = 0*/)
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
void GatewayClient::OnMsgRecv(void* msg,unsigned int msgtype)
{
	if (msgtype == LOGON_RESPONSE)
	{
		LogonResponse *pResponse = (LogonResponse *)msg;

		if (pResponse)
		{
			if (strcmp(pResponse->Reason, "VALID") == 0)
			{
				// Login Successfull
				// Send Participant Request
				ParticipantListRequest *pRequest = (ParticipantListRequest *)GetMessageObject(PARTICIPANT_LIST_REQUEST);

				if (pRequest)
				{
					strcpy(pRequest->UserName, _strUserName.c_str());

					_ptrIClientProtocol->Send(_ClientID, pRequest, PARTICIPANT_LIST_REQUEST);

					free(pRequest);
				}
			}
			else
			{
				// Disconnect connection
			}

			free(pResponse);
		}
	}
	else if (msgtype == PARTICIPANT_LIST_RESPONSE)
	{
		ParticipantListResponse *pResponse = (ParticipantListResponse *)msg;

		if (pResponse)
		{
			if (pResponse->NoOfParticipants > 0)
			{
				_AccountNo = pResponse->AccountInfo[0].Account;
			}

			free(pResponse);
		}
	}
	else
		if (_ptrRoute)
			_ptrRoute->ProcessResponse(msg, msgtype);
}
void GatewayClient::OnConnectionStatus(int status, unsigned clientID)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::OnConnectionStatus, Status = %d", status);

	_ClientID = clientID;

	// Got connected, send login request
	if (status == 1 && _bAuthReq == true)
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
}

void GatewayClient::OnSendStatus(bool isSuccess,unsigned long long PacketID)
{
}

