/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _GATEWAYClient_H_
#define _GATEWAYClient_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "Protocol.h"
#include "DataDef.h"
#include <string>
//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================




class OME_BL;
//*************************************************************************************************
// class MDFClient
//
//*************************************************************************************************
class GatewayClient	: public IClientProtocolEvents	
{

//METHODS-------
public:
	GatewayClient(OME_BL *route);
	~GatewayClient();
	
	virtual		bool		login(const std::string& user, const std::string& pwd, const std::string& server = "", const std::string& host = "", long port = 0)  ;
	

	virtual		void		OnMsgRecv(void* msg,unsigned int msgtype);
	virtual		void		OnConnectionStatus(int status, unsigned int ClientID);
	virtual		void		OnSendStatus(bool isSuccess,unsigned long long PacketID);



protected:

	

private:
	/*void HandleLoginResponse(LogonResponse* ptrLogonResponse);
	void HandleQuotesSnapshotResponse(QuotesSnapshotResponse* ptrQuotesSnapshotResponse);
	void HandleQuotesStream(QuotesStream* ptrQuotesStream);
	void HandleNewsStream(NewsStream* ptrNewsStream);*/



//MEMBERS-------
public:
	IClientProtocol*								_ptrIClientProtocol;
	unsigned int									_ClientID;


protected:

	

private:
	std::string										_strUserName;
	std::string										_strPassword;
	std::string										_strServer;
	short											_sPort;
	std::string										_strHost;
	bool											_isLoginSend;
	OME_BL*											_ptrRoute;
};//class MDFClient


#endif //_MDFClient_H_


