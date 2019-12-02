#include "ITPosition.h"

class ITable;
class ITOneUMHedgePosition: public ITPosition
{
public:
	ITOneUMHedgePosition(RMSCalculatorFactory* pCalcFactory);

	int UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit);
	int GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge);

	//double CalculateOpenPnL(double bid, double ask, bool& SessionClosed, double& tradeMargin, unsigned long& Qty, char& side, int leverage);
	//double CalculateOpenPnL(double bid, double ask);
	void ResetPosition(unsigned long pos, char side);

	int CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder);
	//int  UpdateTempPos();

	int UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos);
	int CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin);

	int AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMArgin, double& lAdjustmentDone);
	int UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment);
};