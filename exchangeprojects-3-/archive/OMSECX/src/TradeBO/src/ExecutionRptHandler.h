#pragma once
#include "serverinterface.h"
#include "DataDef.h"

class IOrder;
class IDatabase;
class IAccountMgr;

class ExecutionRptHandler :
	public IRequest
{
public:
	ExecutionRptHandler(int reqType, 
						void *ptrRequest, 
						IConnectionMgr *ptrConnectionMgr, 
						IDatabase *ptrDatabase, 
						IAccountMgr *pAccountMgr,
						DWORD dwCookie);

	~ExecutionRptHandler(void);

	virtual void Run();
	virtual bool AutoDelete();

private:
	ExecutionReport     *_ptrReport;
	IOrder				*_ptrOrder;
	IConnectionMgr		*_ptrConnectionMgr;
	IDatabase			*_ptrDatabase;
	IAccountMgr			*_ptrAccountMgr;
	DWORD				m_dwCookie;
	IContractManager    *m_pContractManager;

	int MarkupAllPrices(ExecutionReport *pReport, IAccount *pAcc, bool bUP, SymbolSpread& sp);
};
