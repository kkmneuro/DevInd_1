/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			     INITIALS			      DESCRIPTION
//
//05 Feb 2014		BR					Tradingapplication/114.
//										Modify following
//										1. Modified Login and Logout responses to include username
//										2. Modify the QuotesStream and SnapshotResponse to include AccountNo
//										Modified accepted version to 1.15
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "StdAfx.h"
#include "SessionHandler.h"
//#include "errorDefs.h"

SessionHandler::SessionHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IClientSession *ptrSession, IDatabase *pDatabase)
{
	_ptrConnectionMgr = ptrConnectionMgr;
	
	_reqType = reqType;
	_ptrRequest = (void *) ptrRequest;
	_ptrSession = ptrSession;
	_ptrDatabase = pDatabase;

	_MinVersion = 1.15;
	_MaxVersion = 1.15;
}

SessionHandler::~SessionHandler(void)
{
}

void SessionHandler::Run ()
{
	if (_reqType == LOGON_REQUEST)
	{
		unsigned respType = LOGON_RESPONSE;
		LogonResponse *ptrResponse = NULL;
		bool isValid = false;

		LogonRequest *ptrRequest = (LogonRequest *)_ptrRequest;
		ptrResponse = (LogonResponse*)GetMessageObject(LOGON_RESPONSE);
		
		if (ptrRequest)
		{
			if (ptrRequest->Version >= _MinVersion && ptrRequest->Version <= _MaxVersion)
			{
				isValid = Validate(ptrRequest, (LogonResponse *)ptrResponse, _ptrSession);
				respType = LOGON_RESPONSE;
				
				if (isValid == true)
				{
					isValid = true;
					strcpy(ptrResponse->UserName, ptrRequest->UserName);
					strcpy(ptrResponse->Reason, "VALID");
				}
			}
		}
		else
		{
			strcpy(ptrResponse->UserName, ptrRequest->UserName);
			strcpy(ptrResponse->Reason, "Invalid Client Version. Please Upgrade");
		}

		if (ptrResponse)
		{
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), ptrResponse, respType);
			free(ptrResponse);

			if (!isValid)
			{
				_ptrConnectionMgr->RemoveConnection(_ptrSession->GetClientId());
			}

		}
	}
	else if (_reqType == LOGOUT_REQUEST)
	{
		// The control should not come here.
		unsigned respType = LOGOUT_RESPONSE;
		LogoutResponse *ptrResponse = NULL;

		LogoutRequest *ptrRequest = (LogoutRequest *)_ptrRequest;
		ptrResponse = (LogoutResponse*)GetMessageObject(LOGOUT_RESPONSE);

		if (ptrResponse)
		{
			strcpy(ptrResponse->UserName, ptrRequest->UserName);
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), ptrResponse, respType);
			_ptrConnectionMgr->RemoveConnection(_ptrSession->GetClientId());
		}
	}
}

bool SessionHandler::Validate(logonRequest* logonReq,logonResponse* logonResp, IClientSession *pSession)
{
	bool returnflag = true;
	std::string InputUserName( logonReq->UserName );

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("LoginID",logonReq->UserName,sizeof(logonReq->UserName));
	param->AddParam("Password",logonReq->Password,sizeof(logonReq->Password));
	param->AddParam("AccountGroupID",logonReq->Header.SenderID,sizeof(logonReq->Header.SenderID));
	
	bool isSPExist = _ptrDatabase->Execute("Exchange_IsUserAuthenticated",*tb,*param);//execute sp
	if( !isSPExist )
	{
		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		returnflag = false;
		strcpy(logonResp->Reason, "Invalid Username/Password");
		return false;
	}
	
	int acc = 0;
    int accGroupID = 0;

	while(!tb->IsEOF())//loop the table
	{
		tb->Get("PK_ParticipantId",acc);
		tb->Get("AccountGroupID",accGroupID);
		break;
	}

	if( acc > 0)
	{
		if (_ptrConnectionMgr->IsUserAlreadyLoggedIn(InputUserName.c_str()))
		{
			strcpy(logonResp->Reason, "User Already logged from another location");
			returnflag = false;
		}
		else
		{
			returnflag = true;

			// Found that this session was null. this can happen only when a user closes the platform
			// as soon as he sends a login request
			if (_ptrSession)
				_ptrSession->SetGroupID(accGroupID);
			else
			{
				strcpy(logonResp->Reason, "Session Closed before Authentication completes");
				returnflag = false;
			}
		}
		//_ptrSession->SetAccountGroupID(accGroupID);		
	}
	else
	{
		returnflag = false;
		strcpy(logonResp->Reason, "Invalid Username/Password");
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return returnflag;
}


bool SessionHandler::AutoDelete()
{
	return true;
}