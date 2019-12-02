#include "IPosition.h"

#pragma once

class ITable;
class ITPosition: public IPosition
{
public:
	ITPosition();

	bool GetPositionResponse(void*& pResponse);
	std::string ToString();
	int UpdateNetPosition(IOrder *pOrder);
	int UpdateNetPosition(ExecutionReport *pReport);
	int UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long &CloseQty, double& lfProfit);
	int GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge);

	int Init(IDatabase* pDatabase, IAccount *pAcc, std::string strContract, ITable *pTable);
	//double CalculateOpenPnL(double bid, double ask, bool& SessionClosed, double& tradeMargin, unsigned long& Qty, char& side, int leverage);
	void ResetPosition(unsigned long pos, char side);
	//int  UpdateTempPos();

	int UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos);
	int CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin);

	int LoadOpenPosOrder(IOrder *pOrder);

	double GetOverAllUsedMargin();
	virtual double GetSellUsedMargin();
	virtual double GetBuyUsedMargin();

	int CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder1);
	int LoadAllNonSettledMapping(ITable *tb);
	bool GetPositionResponseEx(position *pResponse);
	int CancelPositionTags(IOrder *pOrder, ExecutionReport *pReport, void* lstOrdersToUpdate);
};