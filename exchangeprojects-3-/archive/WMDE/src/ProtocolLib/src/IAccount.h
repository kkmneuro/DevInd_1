///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//07-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#include <stdafx.h>
#include "DataDef.h"
#include <map>
#include <list>

#pragma once

class IOrder;
class IPosition;
class IDatabase;
class IConnectionMgr;
class IClientSession;
class RMSCalculatorFactory;
class IGlobalPosition;
class ITable;

typedef std::map<std::string, IOrder *>			ORDERID_OCO_ORDER_MAP;

class IAccount
{
public:
	unsigned long		m_Account;
	bool				m_bRMSEnable;
	double				m_Balance;
	int					m_nLeverage;
	int					m_nGroup;
	double				m_lfUsedMargin;
	
	bool				m_bHedge;
	bool				m_nEnableTrade;

	double				m_lfBuyTurnover;
	double				m_lfSellTurnover;
	
	std::string			m_strLPName;
	double				m_OpenPnL;
	double				m_lfEquity;
	double				m_StopOut;

	int					m_nMarginCall1;
	int					m_nMarginCall2;
	int					m_nMarginCall3;
	
	std::string			m_strTraderName;
	std::string			m_strAccountType;
	int					m_nHedgingType;
	double				m_lfLotSize;

	IDatabase *m_pDatabase;
	IDatabase *m_pDatabaseBO;
	bool				m_bAccountChanged;
	typedef std::map<std::string, IOrder *>		ORDID_IORDER_MAP;
	typedef std::map<std::string, IPosition *>  SYMBOL_IPOSITION_MAP;
	ORDID_IORDER_MAP	m_lstWorkingOrders;
	SYMBOL_IPOSITION_MAP m_PositionMap;

	typedef std::list<IClientSession *>		SESSION_LIST;

	SESSION_LIST		m_lstSession;
	
	CRITICAL_SECTION			m_cs;
	CRITICAL_SECTION			m_csSession;

	std::map<std::string, std::list<IOrder *>>		m_mapLinkedOrders;

	
	std::map<std::string, ORDERID_OCO_ORDER_MAP>	m_mapOCOOrders;
public:
	virtual std::list<IClientSession *>& GetSessionList() = 0;
	virtual void AcquireSessionCS() = 0;
	virtual void ReleaseSessionCS() = 0;
	virtual int AddSession(IClientSession *pSession) = 0;
	virtual int RemoveSession(IClientSession *pSession) = 0;
	// Process the new order request
	// The following checks are required
	// 1. Margin requirement
	// 2. Buy/Sell side turnover (Contract Specs)
	// 3. Maximum Allowable position (Contract Specs)
	// 4. DPR Range
	virtual int ProcessNewOrder(IOrder *ord, double fees, double tax, IContractManager *pContractManager) = 0;

	virtual bool IsMMAccount() = 0;

	// Process Cancel order request
	// No checks required
	//virtual int ProcessCancelOrder(IOrder *ord) = 0;

	// Process CR Order
	// The following checks are required
	// 1. Margin requirement
	// 2. Buy/Sell side turnover (Contract Specs)
	// 3. Maximum Allowable position (Contract Specs)
	// 4. DPR Range
	virtual int ProcessCROrder(IOrder *ord, IOrder *pNewOrder, double fees, double tax, IContractManager *pContractManager) = 0;

	//virtual int LoadPositions() = 0;

public:
	virtual void Init(unsigned int ulAccount,
						bool bRMSEnable,
						char *pLPName,
						double lfBalance,
						double lfOpenPnL,
						int nLeverage,
						int nGroup,
						double lfFreeMargin,
						double lfMargin,
						double lfUsedMargin,
						bool bHedge,
						bool bEnabletrade,
						double lfReservedMargin,
						double lfBuyTurnOver,
						double lfSellturnOver,
						int nMarginCall1,
						int nMarginCall2,
						int nMarginCall3,
						char *pszTraderName,
						char *pszAccountType,
						int nHedgeType,
						double lfLotSize,
						IDatabase *pDatabase,
						IDatabase *pDatabaseOMS,
						RMSCalculatorFactory *pCalcFactory) = 0;

	virtual void UpdateAccount(unsigned int ulAccount,
						bool bRMSEnable,
						char *pLPName,
						double lfBalance,
						double lfOpenPnL,
						int nLeverage,
						int nGroup,
						double lfFreeMargin,
						double lfMargin,
						double lfUsedMargin,
						bool bHedge,
						bool bEnabletrade,
						double lfReservedMargin,
						double lfBuyTurnOver,
						double lfSellturnOver,
						int nMarginCall1,
						int nMarginCall2,
						int nMarginCall3,
						char *pszTraderName,
						char *pszAccountType,
						IDatabase *pDatabase,
						IDatabase *pDatabaseOMS) = 0;

	// Checks if the margin is available or not.
	virtual int CheckMargin(IOrder *ord, unsigned long long Qty, double lfFees, double lfTax, IContractManager *pContractManager, IPosition *pPosition) = 0;

	//virtual int UpdateProfit(IOrder *pOrder, unsigned long QtyClosed, double profit, unsigned long long filledPrice) = 0;
	// Process Execution Report
	// Following tasks to be performed in case of a Order fill
	// 1. Manage balance
	// In case of cancel order as well as Reject
	// 1. Release Reserved margin
	virtual int ProcessExecutionReport(ExecutionReport *pReport, 
										IOrder *&pOrder, 
										bool& bAccountChanged, 
										bool& bPositionChanged,
										void *&pResponseAccount,
										void *&pResponsePosition,
										unsigned long& ulTempLongPos,
										unsigned long& ulTempShortPos,
										void* lstOrdersToUpdate,
										double& lfSellSideUM,
										double& lfBuySideUM,
										double& lfOverAllUM,
										double lfFees,
										double lfTax,
										IDatabase *pDatabase, 
										IContractManager *pContractManager,
										IConnectionMgr *pConnMgr,
                    IGlobalPosition *pGlobalPos) = 0;

	virtual int GetAccountUpdateMessage(void*& pResponse) = 0;

	virtual void AcquireLockAcc() = 0;
	virtual void ReleaseLockAcc() = 0;

	//virtual int UpdateAccount() = 0;

	virtual int LoadPositions() = 0;
	virtual int LoadWorkingOrder(IOrder *pOrder) = 0;
	virtual int LoadOpenPosOrder(IOrder *pOrder) = 0;
	
	virtual int GetWorkingOrder(IOrder *&pOrder, char *orderID) = 0;

	virtual std::string& GetAssociatedLPName() = 0;
	
	virtual bool IsRMSEnabled() = 0;

	virtual int CalculatePnLAndLiquidate(IContractManager *pContractManager, IConnectionMgr *pConnMgr) = 0;
	virtual void SetConnectionMgr(IConnectionMgr *pConnMgr) = 0;

	virtual int AddLinkedOrders(char *pszClOrdID, IOrder *pOrder1, IOrder *pOrder2) = 0;
	virtual int AddLinkedOrder(char *pszClOrdID, IOrder *pOrder) = 0;

	virtual int AddOCOOrders(char *pszClOrdID, IOrder *pOrder) = 0;

	virtual int TriggerLinkedOrders(char *pszClOrdID, IConnectionMgr *pConnMgr) = 0;
	virtual int HandleOCOOrder(char *pszClOrdID, char *pszLnkOrdID, IConnectionMgr *pConnMgr) = 0;

	virtual int ReplaceOCOOrder(char *pszOrigOrdID, char *pszLnkOrdId, IOrder *pOrder) = 0; 

	virtual int UpdateBalance(double Amount) = 0;

	virtual int EnableAccount(bool bEnable) = 0;

	virtual int LoadAllNonSettledMapping(ITable *tb) = 0;

	virtual int ProcessPositionRequest(unsigned int clientID, IConnectionMgr *pMgr) = 0;
};

