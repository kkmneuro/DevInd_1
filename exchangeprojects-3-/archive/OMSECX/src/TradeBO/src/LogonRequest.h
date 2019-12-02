#pragma once
#include "serverinterface.h"
#include "DataDef.h"

class SessionHandler :
	public IRequest
{
public:
	SessionHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession, IDatabase *ptrDatabase);
	~SessionHandler(void);

	virtual void Run();
	virtual bool AutoDelete();

private:
	IConnectionMgr		*_ptrConnectionMgr;
	IAccountMgr			*_ptrAccountMgr;
	IClientSession		*_ptrSession;
	IDatabase			*_ptrDatabaseBO;

	void *_ptrRequest;
	unsigned int _reqType;

	float _MinVersion;
	float _MaxVersion;
};
