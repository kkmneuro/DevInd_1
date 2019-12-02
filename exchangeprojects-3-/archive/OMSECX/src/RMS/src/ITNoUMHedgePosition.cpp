#include "stdafx.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "Datadef.h"
#include "xlogger.h"
#include "ITNoUMHedgePosition.h"
#include "IOrder.h"
#include "RMSCalculator.h"

ITNoUMHedgePosition::ITNoUMHedgePosition(RMSCalculatorFactory* pCalcFactory)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNoUMHedgePosition::ITNoUMHedgePosition, Entered");

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


int ITNoUMHedgePosition::UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit)
{
	int nSuccess = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNoUMHedgePosition::UpdatePositionStats, Enter Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	if (positionEffect == POSITION_OPENING_TRADE)
	{
		// No profit to be calculated here
		if (side == SIDE_BUY)
		{
			m_ulLongPosition += Qty;
			m_ulTotalBuyVal += Qty * price;

			m_ulTempLongPos += (Qty - CloseQty);

			/*if (CloseQty > 0)
			{
				m_ulTempLongPos -= CloseQty;
				m_ulTempShortPos -= CloseQty;
			}*/
		}
		else if (side == SIDE_SELL)
		{
			m_ulShortPosition += Qty;
			m_ulTotalSellVal += Qty * price;
			m_ulTempShortPos += (Qty - CloseQty);

			/*if (CloseQty > 0)
			{
				m_ulTempLongPos -= CloseQty;
				m_ulTempShortPos -= CloseQty;
			}*/
		}
	}
	else if (positionEffect == POSITION_CLOSING_TRADE)
	{
		if (side == SIDE_SELL)
		{
			m_ulLongPosition -= Qty;
			m_ulTempLongPos -= Qty;
		}
		else if (side == SIDE_BUY)
		{
			m_ulShortPosition -= Qty;
			m_ulTempShortPos -= Qty;
		}
	}

	m_bPositionChanged = true;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNoUMHedgePosition::UpdatePositionStats, Exit Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	return nSuccess;
}

int ITNoUMHedgePosition::GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge)
{
	int nSuccess = 0;
	long position = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNoUMHedgePosition::GetQtyToCheckForMargin, Enter Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE && 
		pOrder->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER)
	{
		if (pOrder->m_Order.Side == SIDE_BUY)
		{
			position = m_ulTempShortPos - m_ulTempLongPos;

			if (position > 0)
			{
				if (position >= ulQty)
				{
					pOrder->QtyClose = ulQty;
					ulQty = 0;

				}
				else
				{
					pOrder->QtyClose = position;
					ulQty -= position;
				}

				m_ulTempLongPos += pOrder->QtyClose;
				
			}
		}
		else
		{
			position = m_ulTempLongPos - m_ulTempShortPos;
			if (position > 0)
			{
				if (position >= ulQty)
				{
					pOrder->QtyClose = ulQty;
					ulQty = 0;
				}
				else
				{
					ulQty -= position;
					pOrder->QtyClose = position;
				}

				m_ulTempShortPos += pOrder->QtyClose;
				
			}
		}

		//UpdateTempPos();
	}
	else if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
	{
		std::map <std::string, IOrder *> *pCurrentMap = NULL;

		if (pOrder->m_Order.Side == SIDE_BUY)
		{
			pCurrentMap = &m_lstShortPosList;
		}
		else if (pOrder->m_Order.Side == SIDE_SELL)
		{
			pCurrentMap = &m_lstLongPosList;
		}

		std::map <std::string, IOrder *>::iterator iter = pCurrentMap->find(pOrder->m_Order.LnkdOrdId);

		if (iter == pCurrentMap->end())
		{
			nSuccess = ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_UNKNOWN_ORDER;
		}

		ulQty = 0;
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNoUMHedgePosition::GetQtyToCheckForMargin, Exit Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	return nSuccess;
}

//double ITNoUMHedgePosition::CalculateOpenPnL(double bid, double ask, bool& SessionClosed, double& tradeMargin, unsigned long& Qty, char& side, int leverage)
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
void ITNoUMHedgePosition::ResetPosition(unsigned long pos, char side)
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

int ITNoUMHedgePosition::CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin)
{
	// Not used in this
	int nSuccess = 0;

	//lfProfit += (pReport->LastPx - pOpenOrder->AvgPx) * qty;

	//if ((pOpenOrder->m_Order.OrderQty == pOpenOrder->QtySettled) )
	//{
	//	lfUsedMargin += pOpenOrder->m_lfUsedMargin;
	//}
	//else
	//{
	//	lfUsedMargin += pOpenOrder->m_lfUsedMargin/(pOpenOrder->m_Order.OrderQty - pOpenOrder->QtyClose)  * qty;
	//}

	//if (pCloseOrder->m_Order.OrderType  != ORDER_TYPE_MARKET_ORDER)
	//{
	//	if ((pCloseOrder->m_Order.OrderQty == pCloseOrder->QtySettled) )
	//	{
	//		lfUsedMargin += pCloseOrder->m_lfUsedMargin;
	//	}
	//	else
	//	{
	//		lfUsedMargin += pCloseOrder->m_lfUsedMargin/(pCloseOrder->m_Order.OrderQty/* - pCloseOrder->QtySettled*/)  * qty;
	//	}
	//}

	return nSuccess;
}

int ITNoUMHedgePosition::UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos)
{
	int nSuccess = 0;

	if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
	{
		std::map <std::string, IOrder *> *pCurrentMap = NULL;
		int flag = 1;

		if (pOrder->m_Order.Side == SIDE_BUY)
		{
			pCurrentMap = &m_lstShortPosList;
			flag = -1;
		}
		else if (pOrder->m_Order.Side == SIDE_SELL)
		{
			pCurrentMap = &m_lstLongPosList;
		}

		std::map <std::string, IOrder *>::iterator iter = pCurrentMap->find(pOrder->m_Order.LnkdOrdId);

		if (iter != pCurrentMap->end())
		{
			IOrder *pOpenOrder = (*iter).second;

			if (pOpenOrder)
			{
				lfUsedMargin = pOpenOrder->m_lfUsedMargin;

				double lfProfit1 = m_pRMSCalc->CalculateProfit(pReport->LastPx, pOpenOrder->AvgPx, pReport->QtyFilled, pReport->Side, pReport->Symbol, ullContractSize);


				pOrder->m_lfProfit += lfProfit1;
				lfProfit += lfProfit1;

				//if (pReport->Side == SIDE_SELL)
				//{
				//	pOrder->m_lfProfit += (pReport->LastPx - pOpenOrder->AvgPx) * pReport->QtyFilled * flag;
				//	lfProfit += (pReport->LastPx - pOpenOrder->AvgPx) * pReport->QtyFilled * flag;
				//}
				//else
				//{
				//	pOrder->m_lfProfit += (pOpenOrder->AvgPx - pReport->LastPx) * pReport->QtyFilled * flag;
				//	lfProfit += (pOpenOrder->AvgPx - pReport->LastPx) * pReport->QtyFilled * flag;
				//}

				//pOrder->m_lfProfit /= 100000;
				//lfProfit /= 100000;

				pOpenOrder->m_ulQtyClosed += pReport->QtyFilled;
				pReport->ClosedQuantity = pOpenOrder->m_ulQtyClosed;

				if (pOpenOrder->m_ulQtyClosed == pOpenOrder->CumQty)
				{
					// Remove from the list
					iter = pCurrentMap->erase(iter);
				}
			}
		}
		else
		{
			nSuccess = -1;
		}
	}
	else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	{
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		if (pOrder->m_Order.Side == SIDE_BUY)
		{
			m_lstLongPosList.insert(pr);
		}
		else
		{
			m_lstShortPosList.insert(pr);
		}
	}

	return nSuccess;
}


int ITNoUMHedgePosition::AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMargin, double& lAdjustmentDone)
{
	int nSuccess = 0;
	int qty = 0;

	if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
	{
		if (pOrder->m_Order.Side == SIDE_BUY)
		{
			//m_ulShortPosition -= pReport->QtyFilled;
			//m_ulTempShortPos -= pReport->QtyFilled;

			m_ulSellSideUsedMargin -= lfUsedMargin;
		}
		else if (pOrder->m_Order.Side == SIDE_SELL)
		{
			//m_ulLongPosition -= pReport->QtyFilled;
			//m_ulTempLongPos -= pReport->QtyFilled;

			m_ulBuySideUsedMargin -= lfUsedMargin;
		}

		unsigned long overallMargin = 0;

		if (m_ulBuySideUsedMargin > m_ulSellSideUsedMargin)
			overallMargin = m_ulBuySideUsedMargin - m_ulSellSideUsedMargin;
		else
			overallMargin = m_ulSellSideUsedMargin - m_ulBuySideUsedMargin;

		lAdjustmentDone = (double)overallMargin - (double)m_ulOverAllUsedMargin;
		
		m_ulOverAllUsedMargin = overallMargin;
	}
	else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE && 
		pReport->OrderStatus == ORDER_STATUS_CANCEL)
	{
		if (pOrder->m_Order.Side == SIDE_SELL)
		{
			//m_ulShortPosition -= pReport->QtyFilled;
			//m_ulTempShortPos -= pReport->QtyFilled;

			m_ulSellSideUsedMargin -= lfUsedMargin;
		}
		else if (pOrder->m_Order.Side == SIDE_BUY)
		{
			//m_ulLongPosition -= pReport->QtyFilled;
			//m_ulTempLongPos -= pReport->QtyFilled;

			m_ulBuySideUsedMargin -= lfUsedMargin;
		}

		unsigned long overallMargin = 0;

		if (m_ulBuySideUsedMargin > m_ulSellSideUsedMargin)
			overallMargin = m_ulBuySideUsedMargin - m_ulSellSideUsedMargin;
		else
			overallMargin = m_ulSellSideUsedMargin - m_ulBuySideUsedMargin;

		lAdjustmentDone = (double)overallMargin - (double)m_ulOverAllUsedMargin;
		
		m_ulOverAllUsedMargin = overallMargin;
	}
	/*else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	{
		if (pOrder->m_Order.Side == SIDE_SELL)
		{
			m_ulSellSideUsedMargin += lfUsedMargin;
		}
		else if (pOrder->m_Order.Side == SIDE_BUY)
		{
			m_ulBuySideUsedMargin += lfUsedMargin;
		}

		unsigned long overallMargin = 0;

		if (m_ulTempLongPos == m_ulTempShortPos)
			overallMargin = 0;
		else if (m_ulBuySideUsedMargin > m_ulSellSideUsedMargin)
			overallMargin = m_ulBuySideUsedMargin - m_ulSellSideUsedMargin;
		else if (m_ulBuySideUsedMargin < m_ulSellSideUsedMargin)
			overallMargin = m_ulSellSideUsedMargin - m_ulBuySideUsedMargin;

		lAdjustmentDone = (double)overallMargin - (double)m_ulOverAllUsedMargin;
		
		m_ulOverAllUsedMargin = overallMargin;
	}*/

	return nSuccess;
}

int ITNoUMHedgePosition::UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment)
{
	int nSuccess = 0;
	double lfOverAllUsedMargin = 0;

	if (side == SIDE_BUY)
	{
		m_ulBuySideUsedMargin += ulUM;
	}
	else if (side == SIDE_SELL)
	{
		m_ulSellSideUsedMargin += ulUM;
	}

	if (m_ulBuySideUsedMargin > m_ulSellSideUsedMargin)
		lfOverAllUsedMargin = m_ulBuySideUsedMargin - m_ulSellSideUsedMargin;
	else 
		lfOverAllUsedMargin = m_ulSellSideUsedMargin - m_ulBuySideUsedMargin;

	adjustment = lfOverAllUsedMargin - m_ulOverAllUsedMargin;

	m_ulOverAllUsedMargin = lfOverAllUsedMargin;

	return nSuccess;
}

int ITNoUMHedgePosition::CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder1)
{
	int nSuccess = -1;

	lfMaxLoss = 9999999999;
	double lfpnl = 0;
	int nSideNonHedged = 0;

	if (m_lstLongPosList.size() > m_lstShortPosList.size())
	{
		nSideNonHedged = 1;
	}
	else if (m_lstLongPosList.size() < m_lstShortPosList.size())
	{
		nSideNonHedged = 2;
	}

	std::map<std::string, IOrder *>::iterator iter = m_lstLongPosList.begin();

	if (!m_lstLongPosList.empty())
	{
		while (iter != m_lstLongPosList.end())
		{
			IOrder *pOrder = (*iter).second;

			if (pOrder)
			{
				lfpnl = m_pRMSCalc->CalculateProfit(bid, pOrder->AvgPx, pOrder->CumQty, SIDE_SELL, pOrder->m_Order.Symbol, ullContractSize);
				//lfpnl = (bid - pOrder->AvgPx) * pOrder->CumQty;

				if (nSideNonHedged < 2 && lfpnl < lfMaxLoss)
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
				//lfpnl = (pOrder->AvgPx - ask) * pOrder->CumQty;
				lfpnl = m_pRMSCalc->CalculateProfit(ask, pOrder->AvgPx, SIDE_BUY, pOrder->CumQty, pOrder->m_Order.Symbol, ullContractSize);

				if ((nSideNonHedged == 0 || nSideNonHedged == 2) && lfpnl < lfMaxLoss)
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

	m_ulLastBidPrice = bid;
	m_ulLastAskPrice = ask;

	return nSuccess;
}

