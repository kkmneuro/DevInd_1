#include "string.h"
#include "ITAccount.h"

class IDatabase;
//class IOrder;

class ITNonHedgeAccount:public ITAccount
{
public:
	~ITNonHedgeAccount();

public:
	ITNonHedgeAccount(){};

	ITNonHedgeAccount(unsigned int ulAccount,
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


	// Checks if the margin is available or not.
	int CheckMargin(IOrder *ord, unsigned long long Qty, double lfFees, double lfTax, IContractManager *pContractManager, IPosition *pPosition);

	int ProcessExecutionReport(ExecutionReport *pReport, 
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
                    IGlobalPosition *pGlobalPos);

	int CalculatePnLAndLiquidate(IContractManager *pContractManager, IConnectionMgr *pConnMgr);

	int LiquidateOrder(symbol& sym, IOrder *pOrder, IConnectionMgr *pConnMgr, unsigned long ulBid, unsigned long ulAsk);

	double CalculateUsedMargin(IOrder *ord, unsigned long long Qty, IContractManager *pContractManager);

	int ProcessCROrder(IOrder *ord, IOrder *pNewOrder, double fees, double tax, IContractManager *pContractManager);


};