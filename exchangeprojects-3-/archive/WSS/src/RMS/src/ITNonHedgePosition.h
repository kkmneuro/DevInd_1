#include "ITPosition.h"


struct MQLOrder
{
	int sym;
	float qty;
	wchar_t side;
	double price;
};

class ITable;
class ITNonHedgePosition: public ITPosition
{
public:
	ITNonHedgePosition(RMSCalculatorFactory* pCalcFactory);

	int UpdateNetPosition(IOrder *pOrder);
	int UpdateNetPosition(ExecutionReport *pReport);


	int UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit);
	int GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge);

	int CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder);
	void ResetPosition(unsigned long pos, char side);
	//int  UpdateTempPos();

	int UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos);
	int CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin, unsigned long& ullcontractSize);

	int AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMArgin, double& lAdjustmentDone);
	int UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment);

	int SendMessageForAutoHedge(MQLOrder& order);

	int CancelPositionTags(IOrder *pOrder, ExecutionReport *pReport, void* lstOrdersToUpdate);

};