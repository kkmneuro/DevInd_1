///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//08-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "string.h"
#include "IAccount.h"
//#include "IOrder.h"

#pragma once

class IDatabase;
class IOrder;
class RMSCalculatorFactory;


class ITAccount:public IAccount
{
protected:
	bool	m_bMMAccount;
	
	//CRITICAL_SECTION	m_ExecReportProcessing;

	//int UpdateOrderAndPosition(ExecutionReport *report, IOrder*& pOrder);
	//int UpdatePosition(ExecutionReport *report);
	//int UpdateOrder(ExecutionReport *report, IOrder*& pOrder);
	//int LoadOpenPositionOrders();

	IConnectionMgr *m_ConnMgr;
	RMSCalculatorFactory *m_pRMSCalc;
	IPosition *GetPositionObject(IOrder *pOrder);
	IPosition *GetPositionObject(char *symbol);

	double CalculateUsedMargin(IOrder *ord, unsigned long long Qty, IContractManager *pContractManager);
	//int AddToPlaceOrderList(IOrder *pOrder, IPosition *pPosition, unsigned long& MarginForQty);
public:
	~ITAccount();

	std::list<IClientSession *>& GetSessionList();
	void AcquireSessionCS();
	void ReleaseSessionCS();

	// Process the new order request
	// The following checks are required
	// 1. Margin requirement
	// 2. Buy/Sell side turnover (Contract Specs)
	// 3. Maximum Allowable position (Contract Specs)
	// 4. DPR Range
	int ProcessNewOrder(IOrder *ord, double fees, double tax, IContractManager *pContractManager);

	bool IsMMAccount(){return m_bMMAccount;};

	// Process Cancel order request
	// No checks required
	//int ProcessCancelOrder(IOrder *ord);

	// Process CR Order
	// The following checks are required
	// 1. Margin requirement
	// 2. Buy/Sell side turnover (Contract Specs)
	// 3. Maximum Allowable position (Contract Specs)
	// 4. DPR Range
	int ProcessCROrder(IOrder *ord, IOrder *pNewOrder, double fees, double tax, IContractManager *pContractManager);

	virtual int LiquidateOrder(symbol& sym, IOrder *pOrder, IConnectionMgr *pConnMgr, unsigned long ulBid, unsigned long ulAsk);

	void CalculateCommAndTax(double lfFees, double lfTax, double& lfCalcComm, double& lfCalcTax, double lfCurrentPrice);
	//int LoadPositions();

public:
//unsigned int		ulAccount;
//	double				lfBalance;
//	int					nLeverage;
//	int					nGroup;
//	double				lfFreeMargin;
//	double				lfMargin;
//	double				lfUsedMargin;
//	bool				bHedge;
//	bool				nEnableTrade;
//	double				lfReservedMargin;
//	
//	double				lfBuyTurnover;
//	double				lfSellTurnover;
	ITAccount(){};
	std::string ToString();
	ITAccount(unsigned int ulAccount,
				double lfBalance,
				int nLeverage,
				int nGroup,
				double lfFreeMargin,
				double lfMargin,
				double lfUsedMArgin,
				bool bHedge,
				bool bEnableTrade,
				double lfReservedMargin,
				double lfBuyTurnOver,
				double lfSellTurnOver,
				IDatabase *pDatabase);

	void Init(unsigned int ulAccount,
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
						RMSCalculatorFactory *pCalcFactory);

	void UpdateAccount(unsigned int ulAccount,
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
						IDatabase *pDatabaseOMS);


	// Checks if the margin is available or not.
	int CheckMargin(IOrder *ord, unsigned long long Qty, double lfFees, double lfTax, IContractManager *pContractManager, IPosition *pPosition);

	// Process the Order
	int ProcessOrder(IOrder *ord);

	// Process Execution Report
	// Following tasks to be performed in case of a Order fill
	// 1. Manage balance
	// In case of cancel order as well as Reject
	// 1. Release Reserved margin


	//int UpdateProfit(IOrder *pOrder, unsigned long QtyClosed, double profit, unsigned long long filledPrice);

	/*int ProcessExecutionReport(ExecutionReport *pReport, 
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
										IDatabase *pDatabase, 
										IContractManager *pContractManager,
										IConnectionMgr *pConnMgr);*/

	int GetAccountUpdateMessage(void*& pResponse);

	void AcquireLockAcc();
	void ReleaseLockAcc();

	//int UpdateAccount();
	int LoadPositions();

	int LoadWorkingOrder(IOrder *pOrder);
	int LoadOpenPosOrder(IOrder *pOrder);

	int GetWorkingOrder(IOrder *&pOrder, char *orderID);

	std::string& GetAssociatedLPName();

	bool IsRMSEnabled();

	int CalculatePnLAndLiquidate(IContractManager *pContractManager, IConnectionMgr *pConnMgr);
	void SetConnectionMgr(IConnectionMgr *pConnMgr);

	int AddSession(IClientSession *pSession);
	int RemoveSession(IClientSession *pSession);

	int AddLinkedOrders(char *pszClOrdID, IOrder *pOrder1, IOrder *pOrder2);
	int AddLinkedOrder(char *pszClOrdID, IOrder *pOrder);
	int AddOCOOrders(char *pszClOrdID, IOrder *pOrder);

	int TriggerLinkedOrders(char *pszClOrdID, IConnectionMgr *pConnMgr);
	int HandleOCOOrder(char *pszClOrdID, char *pszLnkOrdID, IConnectionMgr *pConnMgr);

	int DeleteLinkedOrders(char *pszClOrdID);

	int ReplaceOCOOrder(char *pszOrigOrdID, char *pszLnkOrdId, IOrder *pOrder);

	int UpdateBalance(double Amount);

	int EnableAccount(bool bEnable);

	int LoadAllNonSettledMapping(ITable *tb);

	virtual int ProcessPositionRequest(unsigned int clientID, IConnectionMgr *pMgr);

	//int GetSymbolParameters
};