#pragma once
#include "serverinterface.h"
#include "DataDef.h"

class SessionHandler :
	public IRequest
{
public:
	SessionHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IClientSession *ptrSession, IDatabase *pDatabase);
	~SessionHandler(void);

	bool Validate(logonRequest* logonReq,logonResponse* logonResp, IClientSession *pSession);


	virtual void Run();
	virtual bool AutoDelete();

private:
	IConnectionMgr		*_ptrConnectionMgr;
	IClientSession		*_ptrSession;
	IDatabase			*_ptrDatabase;

	void *_ptrRequest;
	unsigned int _reqType;

	float _MinVersion;
	float _MaxVersion;

};
