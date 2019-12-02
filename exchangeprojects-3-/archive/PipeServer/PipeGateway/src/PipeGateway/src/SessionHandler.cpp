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

	_MinVersion = 1.14;
	_MaxVersion = 1.14;
}

SessionHandler::~SessionHandler(void)
{
}

void SessionHandler::Run ()
{
	unsigned respType = LOGON_RESPONSE;
	LogonResponse *ptrResponse = NULL;
	bool isValid = false;

	if (_reqType == LOGON_REQUEST)
	{
		LogonRequest *ptrRequest = (LogonRequest *)_ptrRequest;
		ptrResponse = (LogonResponse*)GetMessageObject(LOGON_RESPONSE);
		
		if (ptrRequest)
		{
			if (ptrRequest->Version >= _MinVersion && ptrRequest->Version <= _MaxVersion)
			{
				isValid = Validate(ptrRequest, (LogonResponse *)ptrResponse, _ptrSession);
				respType = LOGON_RESPONSE;
				
				if (isValid == false)
				{
					strcpy(ptrResponse->Reason, "Invalid Username or Password");
				}
				else
				{
					isValid = true;
					strcpy(ptrResponse->Reason, "VALID");
				}
			}
		}
		else
		{
			strcpy(ptrResponse->Reason, "Invalid Client Version. Please Upgrade");
		}

	}
	else
	{
		// The control should not come here.
	}
	
	if (ptrResponse)
	{
		_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), ptrResponse, respType);

		if (!isValid)
		{
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
	//param->AddParam("AccountGroupID",logonReq->Header.SenderID,sizeof(logonReq->Header.SenderID));
	
	bool isSPExist = _ptrDatabase->Execute("Exchange_IsUserAuthenticated",*tb,*param);//execute sp
	if( !isSPExist )
	{
		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

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
		returnflag = true;
		_ptrSession->SetGroupID(accGroupID);
		//_ptrSession->SetAccountGroupID(accGroupID);		
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return returnflag;
}


bool SessionHandler::AutoDelete()
{
	return false;
}