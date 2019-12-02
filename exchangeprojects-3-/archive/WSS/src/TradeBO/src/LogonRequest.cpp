////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials			Desc
//	16 Dec 2013		BR					Ticket Trading Application/92. Modified the MinVersion/MaxVersion to 1.14
//05 Feb 2014		BR					Tradingapplication/114.
//										Modify following
//										1. Modified Login and Logout responses to include username
//										2. Modify the QuotesStream and SnapshotResponse to include AccountNo
//										Modified accepted version to 1.15
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "StdAfx.h"
#include "LogonRequest.h"
#include "errorDefs.h"
#include "xlogger.h"
#include "datadef.h"

SessionHandler::SessionHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession, IDatabase *ptrDatabase)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "SessionHandler::SessionHandler, Entered");

	_ptrConnectionMgr = ptrConnectionMgr;
	_ptrAccountMgr = ptrAccountMgr;
	_ptrDatabaseBO = ptrDatabase;
	
	_reqType = reqType;
	_ptrRequest = (void *) ptrRequest;
	_ptrSession = ptrSession;

	_MinVersion = 1.15;
	_MaxVersion = 1.15;
}

SessionHandler::~SessionHandler(void)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "SessionHandler::SessionHandler, Destructor");
}

void SessionHandler::Run ()
{
	bool isValid = false;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "SessionHandler::Run, Entered");

	if (_reqType == LOGON_REQUEST)
	{
		unsigned respType;
		LogonResponse *ptrResponse = NULL;

		LogonRequest *ptrRequest = (LogonRequest *)_ptrRequest;
		ptrResponse = (LogonResponse*)GetMessageObject(LOGON_RESPONSE);
		
		if (ptrRequest)
		{
			respType = LOGON_RESPONSE;

			if (ptrRequest->Version >= _MinVersion && ptrRequest->Version <= _MaxVersion)
			{
				isValid = _ptrAccountMgr->Validate(ptrRequest, (LogonResponse *)ptrResponse, _ptrSession);
				
				if (isValid == false)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "SessionHandler::Run, Invaliod username and password");
					//strcpy(ptrResponse->Reason, "Invalid Username or Password");
				}
				else
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "SessionHandler::Run, Validation successfull");
					strcpy(ptrResponse->UserName, ptrRequest->UserName);
					strcpy(ptrResponse->Reason, "VALID");

					//strcpy(ptrResponse->BrokerName, "ECX");
				}
			}
			else
			{
				strcpy(ptrResponse->UserName, ptrRequest->UserName);
				strcpy(ptrResponse->Reason, "Invalid Client Version. Please Upgrade");
			}
		}

		if (ptrResponse)
		{
			
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), ptrResponse, respType);

			free(ptrResponse);
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
			_ptrAccountMgr->Remove(_ptrSession);
		}
	}
	else
	{
		// The control should not come here.
	}
}


bool SessionHandler::AutoDelete()
{
	return false;
}