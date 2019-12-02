#include "stdafx.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "Datadef.h"
#include "xlogger.h"
#include "ITBothUMHedgePosition.h"
#include "IOrder.h"
#include "RMSCalculator.h"
#include "IGlobalPosition.h"

ITBothUMHedgePosition::ITBothUMHedgePosition(RMSCalculatorFactory* pCalcFactory)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgePosition::ITBothUMHedgePosition, Entered");

	m_pRMSCalc = pCalcFactory;
	memset(&m_Symbol, 0, sizeof(symbol));
	m_ulLongPosition = 0;
	m_ulTotalBuyVal = 0;
	m_ulShortPosition = 0;
	m_ulTotalSellVal = 0;
	m_lfLongAvgPrice = 0;
	m_lfShortAvgPrice = 0;

	m_ulTempShortPos = 0;
	m_ulTempLongPos = 0;

	m_bPositionChanged = false;
	m_Account = 0;

	m_ulBuySideUsedMargin = 0;
	m_ulSellSideUsedMargin = 0;
	m_ulOverAllUsedMargin = 0;

}


// this function is not used anywhere. Commenting it
int ITBothUMHedgePosition::UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit)
{
	int nSuccess = 0;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgePosition::UpdatePositionStats, Enter Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	//if (positionEffect == POSITION_OPENING_TRADE)
	//{
	//	// No profit to be calculated here
	//	if (side == SIDE_BUY)
	//	{
	//		m_ulLongPosition += Qty;
	//		m_ulTotalBuyVal += Qty * price;

	//		m_ulTempLongPos += (Qty - CloseQty);

	//		/*if (CloseQty > 0)
	//		{
	//			m_ulTempLongPos -= CloseQty;
	//			m_ulTempShortPos -= CloseQty;
	//		}*/
	//	}
	//	else if (side == SIDE_SELL)
	//	{
	//		m_ulShortPosition += Qty;
	//		m_ulTotalSellVal += Qty * price;
	//		m_ulTempShortPos += (Qty - CloseQty);

	//		/*if (CloseQty > 0)
	//		{
	//			m_ulTempLongPos -= CloseQty;
	//			m_ulTempShortPos -= CloseQty;
	//		}*/
	//	}
	//}
	//else if (positionEffect == POSITION_CLOSING_TRADE)
	//{
	//	if (side == SIDE_SELL)
	//	{
	//		m_ulLongPosition -= Qty;
	//		m_ulTempLongPos -= Qty;
	//	}
	//	else if (side == SIDE_BUY)
	//	{
	//		m_ulShortPosition -= Qty;
	//		m_ulTempShortPos -= Qty;
	//	}
	//}

	//m_bPositionChanged = true;
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgePosition::UpdatePositionStats, Exit Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	return nSuccess;
}

int ITBothUMHedgePosition::GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge)
{
	int nSuccess = 0;
	long position = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgePosition::GetQtyToCheckForMargin, Enter Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	//std::list<IOrder*> *pListOrdersToUpdate = (std::list<IOrder*> *)lstOrdersToUpdate;

	std::map<std::string, IOrder *> *pCurrentList = NULL;
	std::map<std::string, IOrder *> *pOppositeList = NULL;

	std::list<IOrder *> lstCurrentOrderList;

	if (pOrder->m_Order.Side == SIDE_BUY)
	{
		// Try tagging it with the Short List
		pCurrentList = &m_lstLongPosList;
		pOppositeList = &m_lstShortPosList;
	}
	else
	{
		// Tag with the long list
		pCurrentList = &m_lstShortPosList;
		pOppositeList = &m_lstLongPosList;
	}

	if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
	{
		std::map<std::string, IOrder *>::iterator iter = pOppositeList->find(pOrder->m_Order.LnkdOrdId);

		if (iter != pOppositeList->end())
		{
			// Found
			IOrder *pOppPosOrder = iter->second;

			if (pOppPosOrder)
			{
				if (ulQty > pOppPosOrder->CumQty - pOppPosOrder->QtyClose)
				{
					nSuccess = INVALID_ORDER_CAPACITY;
				}
				else
				{
					pOppPosOrder->AddOrderToTag(ulQty, 0, pOrder, false);
					pOrder->AddOrderToTag(ulQty, 0, pOppPosOrder, false);

					pOrder->QtyClose += ulQty;
					pOppPosOrder->QtyClose += ulQty;


					ulQty = 0;
				}
			}
		}
		else
		{
			nSuccess = ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_UNKNOWN_ORDER;
		}
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgePosition::GetQtyToCheckForMargin, Exit Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	return nSuccess;
}

//double ITBothUMHedgePosition::CalculateOpenPnL(double bid, double ask, bool& SessionClosed, double& tradeMargin, unsigned long& Qty, char& side, int leverage)
//{
//	double OpenPnL = 0;
//
//	if (!SessionClosed)
//	{
//		if (m_ulLongPosition > m_ulShortPosition)
//		{
//			OpenPnL = ((m_ulLongPosition - m_ulShortPosition) * ask) - ((m_ulLongPosition - m_ulShortPosition) * m_lfLongAvgPrice);
//			tradeMargin = (m_ulLongPosition - m_ulShortPosition) * m_lfLongAvgPrice/(leverage * 10);
//			Qty = m_ulLongPosition - m_ulShortPosition;
//			side = SIDE_SELL;
//		}
//		else if (m_ulShortPosition > m_ulLongPosition)
//		{
//			OpenPnL = ((m_ulShortPosition - m_ulLongPosition) * bid) - ((m_ulShortPosition - m_ulLongPosition) * m_lfShortAvgPrice);
//			tradeMargin = (m_ulShortPosition - m_ulLongPosition) * m_lfShortAvgPrice/(leverage * 10);
//			Qty = m_ulShortPosition - m_ulLongPosition;
//			side = SIDE_BUY;
//		}
//	}
//
//	return OpenPnL;
//}
//
void ITBothUMHedgePosition::ResetPosition(unsigned long pos, char side)
{
	if (side == SIDE_BUY)
	{
		m_ulTempLongPos -= pos;
	}
	else
	{
		m_ulTempShortPos -= pos;
	}
}

int ITBothUMHedgePosition::CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin, unsigned long& ullcontractSize)
{
	int nSuccess = 0;

	lfProfit += m_pRMSCalc->CalculateProfit(pReport->LastPx, pOpenOrder->AvgPx, qty, pCloseOrder->m_Order.Side, pReport->Symbol, ullcontractSize); 

	return nSuccess;
}

int ITBothUMHedgePosition::UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos)
{
	int nSuccess = 0;

	bool bErased = false;

	std::list<IOrder*> *pListOrdersToUpdate = (std::list<IOrder*> *)lstOrdersToUpdate;

	std::list<OrderExecInfo>& lstTaggedList = pOrder->GetTaggedOrderList();

	std::map<std::string, IOrder *> *pCurrentList = NULL;
	std::map<std::string, IOrder *> *pOppositeList = NULL;

	if (pOrder->m_Order.Side == SIDE_BUY)
	{
		// Try tagging it with the Short List
		pCurrentList = &m_lstLongPosList;
		pOppositeList = &m_lstShortPosList;
	}
	else
	{
		// Tag with the long list
		pCurrentList = &m_lstShortPosList;
		pOppositeList = &m_lstLongPosList;
	}

	if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
	{
		std::list<OrderExecInfo>::iterator iter = lstTaggedList.begin();

		unsigned long long ullQtyFilled = 0;
		unsigned long long ullQtyFilledLeft = pReport->QtyFilled;
 
		while (iter != lstTaggedList.end())
		{
			OrderExecInfo& info = *iter;

			if (info.bOpenPos == false)
			{
				IOrder *pOrder1 = info.pOrder;

				if (pOrder1)
				{
					if (ullQtyFilledLeft > info.Qty)
					{
						ullQtyFilled = info.Qty;
					}
					else
					{
						ullQtyFilled = ullQtyFilledLeft;
					}

					double lfLocalProfit = 0;
					// Calculate profit and store it in map table
					nSuccess = CalculateProfit(pOrder1, pOrder, pReport, pReport->QtyFilled, lfLocalProfit, lfUsedMargin, ullContractSize);

					lfUsedMargin += (pOrder1->m_lfUsedMargin/(pOrder1->m_Order.OrderQty)) * ullQtyFilled;

					lfProfit += lfLocalProfit;
					pOrder1->QtySettled += ullQtyFilled;
					pOrder->QtySettled += ullQtyFilled;
					info.SettledQty += ullQtyFilled;

					pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
												pOrder1->m_Order.Side,
												pOrder1->AvgPx,
												pOrder->m_Order.OrderQty,
												lfLocalProfit,
												POSITION_CLOSING_TRADE);

					pReport->ClosedQuantity = pOrder->QtySettled;

					ullQtyFilledLeft -= ullQtyFilled;

					pListOrdersToUpdate->push_back(pOrder1);

					pOrder->UpdateOrderMapping(&info,0);
				}
			}
			else
			{
				// this is part of open order
				std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
				pCurrentList->insert(pr);

				pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
											pOrder->m_Order.Side,
											pReport->LastPx,
											pOrder->CumQty + pReport->QtyFilled - pOrder->QtyClose,
											0,
											POSITION_OPENING_TRADE);
			}

			if (info.Qty == info.SettledQty && info.bOpenPos == false)
			{
				bErased = true;
			}

			if (bErased)
			{
				std::map<std::string, IOrder *>::iterator iter1 = pOppositeList->find(info.pOrder->m_Order.ClOrdId);

				if (iter1 != pOppositeList->end())
				{
					IOrder *pOrd = iter1->second;

					if (pOrd)
					{
						if (pOrd->CumQty == pOrd->QtyClose && pOrd->CumQty == pOrd->m_Order.OrderQty)
						{
							pOppositeList->erase(iter1);
						}
					}
				}

				iter = lstTaggedList.erase(iter);
				
				bErased = false;
			}
			else
				iter++;

		}
	}
	else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	{
		// May be we should check and tag some of the orders here
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		pCurrentList->insert(pr);

		pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
									pOrder->m_Order.Side,
									pReport->LastPx,
									pOrder->CumQty + pReport->QtyFilled,
									0,
									POSITION_OPENING_TRADE);
	}

	return nSuccess;
}


int ITBothUMHedgePosition::AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMargin, double& lAdjustmentDone)
{
	int nSuccess = 0;

	return nSuccess;
}

int ITBothUMHedgePosition::UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment)
{
	int nSuccess = 0;

	return nSuccess;

}

int ITBothUMHedgePosition::CalculateOpenPnL(double ltp, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder1)
{
	int nSuccess = -1;

	lfMaxLoss = 9999999999;
	double lfpnl = 0;

	std::map<std::string, IOrder *>::iterator iter = m_lstLongPosList.begin();

	if (!m_lstLongPosList.empty())
	{
		while (iter != m_lstLongPosList.end())
		{
			IOrder *pOrder = (*iter).second;

			if (pOrder)
			{
				//lfpnl = (bid - pOrder->AvgPx) * pOrder->CumQty * 100;
				lfpnl = m_pRMSCalc->CalculateProfit(ltp, pOrder->AvgPx, pOrder->CumQty, SIDE_SELL, pOrder->m_Order.Symbol, ullContractSize);

				if (lfpnl < lfMaxLoss)
				{
					lfMaxLoss = lfpnl;
					strcpy(pclOrdID, pOrder->m_Order.ClOrdId);
					pOrder1 = pOrder;
				}

				lfOpenPnL += lfpnl;
				nSuccess=0;
			}

			iter++;
		}
	}

	if (!m_lstShortPosList.empty())
	{
		iter = m_lstShortPosList.begin();
		while (iter != m_lstShortPosList.end())
		{
			IOrder *pOrder = (*iter).second;

			if (pOrder)
			{
				lfpnl = m_pRMSCalc->CalculateProfit(ltp, pOrder->AvgPx, pOrder->CumQty, SIDE_BUY, pOrder->m_Order.Symbol, ullContractSize);
				//lfpnl = (pOrder->AvgPx - ask) * pOrder->CumQty;

				if (lfpnl < lfMaxLoss)
				{
					lfMaxLoss = lfpnl;
					strcpy(pclOrdID, pOrder->m_Order.ClOrdId);
					pOrder1 = pOrder;
				}

				lfOpenPnL += lfpnl;
				nSuccess=0;
			}

			iter++;
		}
	}

	m_ulLastBidPrice = ltp;
	m_ulLastAskPrice = ask;

	return nSuccess;
}

