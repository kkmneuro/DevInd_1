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
#include "ServerInterface.h"
#include "xlogger.h"
#include "OME_BL.h"
#include "UtilitiesAPI.h"

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




GatewayClient::GatewayClient(OME_BL *route): 
_ptrIClientProtocol(NULL),
_strUserName(""),
_strPassword(""),
_sPort(0),
_strServer(""),
_strHost("")
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::GatewayClient, ServerIP=%s, Port=%d", _strServer, _sPort);

	_ptrRoute = route;
	_isLoginSend = false;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::GatewayClient, Exit");
}

GatewayClient::~GatewayClient()
{
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::~GatewayClient, Entered");

	_ptrIClientProtocol->Disconnect();
	ReleaseClientProtocol( _ptrIClientProtocol );
	_ptrIClientProtocol = NULL;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::~GatewayClient, Exit");
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
//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::login, Entered");

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

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::login, Exit");

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
				if (_ptrRoute && _ptrRoute->m_orderHandler)
				{
					_ptrRoute->m_orderHandler->RequestQuotes(this);

					SendSignal(SERVER_PME, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_EXTERNAL_CONNS_UP);

					// Start the KA Server
					StartKAthread(SERVER_PME);
				}
			}
			else
			{
				// Log here
			}
		}
	}
	else
	{
		_ptrRoute->m_connnetionMgr->ProcessNextRequest(0, msg, msgtype);
	}

	/*free(msg);
	msg = NULL;*/

}
void GatewayClient::OnConnectionStatus(int status, unsigned int clientid)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::OnConnectionStatus, Entered. Status = %d", status);

	//if (status == 0 || status == 3)
	//{
	//	Sleep(1000);
	//	_ptrRoute->m_pClient->login("system", "system", "127.0.0.1", "127.0.0.1", 9003);
	//}
	//else
	//{
	//	//_ptrRoute->m_orderHandler->InitializeMarket();
	//}

	_ClientID = clientid;

	if (status != 0 && status !=3)
	{
		if (_ptrRoute && _ptrRoute->m_orderHandler)
		{
			pLogonRequest req = (pLogonRequest)GetMessageObject(LOGON_REQUEST);
			req->HeartbeatInterval = 12;
			req->EncryptionMethod = 'B';
			req->Version = 1.15;
			
			int UserNameLength = _strUserName.length();

			if( _strUserName.length() > 8 )
				UserNameLength = 8;

			int PasswordLength = _strPassword.length();

			if( _strPassword.length() > 15 )
				PasswordLength = 15;

			memset(req->UserName,0,sizeof(char)*8);
			memset(req->Password,0,sizeof(char)*15);

			memcpy(req->UserName,_strUserName.c_str(),UserNameLength*sizeof(char));
			memcpy(req->Password,_strPassword.c_str(),PasswordLength*sizeof(char));
			strcpy(req->Header.SenderID, "2");
			_ptrIClientProtocol->Send(clientid, req, LOGON_REQUEST);			
		}
	}

	

	//_ptrRoute->InitializeSystem();
	//if( status == 1 && !_isLoginSend)
	//{
	//	_isLoginSend = true;
	//	pLogonRequest req = (pLogonRequest)GetMessageObject(LOGON_REQUEST);
	//	req->HeartbeatInterval = 12;
	//	req->EncryptionMethod = 'B';
	//	
	//	int UserNameLength = _strUserName.length();

	//	if( _strUserName.length() > 8 )
	//		UserNameLength = 8;

	//	int PasswordLength = _strPassword.length();

	//	if( _strPassword.length() > 15 )
	//		PasswordLength = 15;

	//	memset(req->UserName,0,sizeof(char)*8);
	//	memset(req->Password,0,sizeof(char)*15);

	//	memcpy(req->UserName,_strUserName.c_str(),UserNameLength*sizeof(char));
	//	memcpy(req->Password,_strPassword.c_str(),PasswordLength*sizeof(char));
	//	//_ptrIClientProtocol->Send( req, LOGON_REQUEST, req->Header.SeqNo);
	//}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "GatewayClient::OnConnectionStatus, Exit");
	
}

void GatewayClient::OnSendStatus(bool isSuccess,unsigned long long PacketID)
{
}

