#include "AccountMgr.h"


AccountMgr::AccountMgr(IDataBaseManager* mgr)
{
	m_DatabaseMgr = mgr;
	InitializeCriticalSection(&CS_ACCOUNT_MAP);
}
AccountMgr::~AccountMgr()
{
	DeleteCriticalSection(&CS_ACCOUNT_MAP);
}

void AccountMgr::Initialize()
{
}

bool AccountMgr::Validate(logonRequest* logonReq,logonResponse* logonResp)
{
	bool returnflag = false;
	std::string InputUserName( logonReq->UserName );

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("LoginID",logonReq->UserName,sizeof(logonReq->UserName));
	param->AddParam("Password",logonReq->Password,sizeof(logonReq->Password));
	
	bool isSPExist = m_DatabaseMgr->getDatabase()->Execute("Exchange_IsUserAuthenticated",*tb,*param);//execute sp
	if( !isSPExist )
	{
		return false;
	}
	
	std::string resultData;

	while(!tb->IsEOF())//loop the table
	{
		tb->Get("LoginID",&resultData);
		tb->MoveNext();
		break;
	}

	if( resultData == InputUserName )
	{
		returnflag = true;
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return returnflag;
}
void AccountMgr::AddAccount(logonRequest* logonReq,IClientSession* clSession)
{
	
	//TO DO....after using please free it
	//Now I am freeing becoz there is no use of this object
	free(logonReq);
}
void AccountMgr::Remove(IClientSession* clientSession)
{
}



