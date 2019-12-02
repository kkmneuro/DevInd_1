///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//07-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//#include "DataDef.h"
#include <string>
#include <list>
#include <map>
#include "Datadef.h"

#pragma once

class ITable;
class IOrder;
class IAccount;
class RMSCalculatorFactory;
class IGlobalPosition;

class IPosition
{
public:
	symbol			m_Symbol;
	unsigned long	m_Account;
	unsigned long	m_ulLongPosition;
	unsigned long	m_ulTotalBuyVal;
	unsigned long	m_ulShortPosition;
	unsigned long	m_ulTotalSellVal;
	double			m_lfLongAvgPrice;
	double			m_lfShortAvgPrice;

	unsigned long	m_ulTempLongPos;
	unsigned long	m_ulTempShortPos;

	bool			m_bPositionChanged;

	double   m_ulBuySideUsedMargin;
	double   m_ulSellSideUsedMargin;
	double	m_ulOverAllUsedMargin;

	double	m_ulLastBidPrice;
	double	m_ulLastAskPrice;

	double			m_lfOpenPnL;

	IDatabase *m_Database;
	IAccount *m_pAccount;

protected:
	std::map<std::string, IOrder *>			m_lstLongPosList;
	std::map<std::string, IOrder *>			m_lstShortPosList;

	//std::map<std::string, IOrder *>			m_lstReservedLongPosList;
	//std::map<std::string, IOrder *>			m_lstReservedShortPosList;

	RMSCalculatorFactory*					m_pRMSCalc;

public:
	virtual bool GetPositionResponse(void*& pResponse) = 0;
	virtual std::string ToString() = 0;
	virtual int UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit) = 0;
	virtual int GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge) = 0;
	
	virtual int Init(IDatabase* pDatabase, IAccount *pAcc, std::string strContract, ITable *pTable) = 0;

	virtual int CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder *&pOrder) = 0;
	virtual void ResetPosition(unsigned long pos, char side) = 0;

	virtual int UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos) = 0;
	virtual int CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin) = 0;

	virtual int LoadOpenPosOrder(IOrder *pOrder) = 0;;

	virtual int AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMArgin, double& lAdjustmentDone) = 0;
	virtual int UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment) = 0;
	virtual double GetOverAllUsedMargin() = 0;
	virtual double GetSellUsedMargin() = 0;
	virtual double GetBuyUsedMargin() = 0;
	virtual int LoadAllNonSettledMapping(ITable *tb) = 0;
};