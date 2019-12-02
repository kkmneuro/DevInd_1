////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//21 April 2014		BR				Ticket Tradeworkstation/78. Modified function UpdatePosition to update the closedQty
//									in case the Position Effect is POSITION_CLOSING_TRADE
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "Datadef.h"
#include "xlogger.h"
#include "ITNonHedgePosition.h"
#include "IOrder.h"
#include "RMSCalculator.h"
#include "IGlobalPosition.h"
#include "xevent.h"
ITNonHedgePosition::ITNonHedgePosition(RMSCalculatorFactory* pCalcFactory)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::ITNonHedgePosition, Entered");

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

}


int ITNonHedgePosition::UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit)
{
	int nSuccess = 0;

	return 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePositionStats, Enter Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	if (side == SIDE_BUY)
	{
		m_lfLongAvgPrice = ((m_lfLongAvgPrice * m_ulLongPosition) + (Qty * price))/(m_ulLongPosition + Qty);

		m_ulLongPosition += Qty;
		m_ulTotalBuyVal += Qty * price;
	
		//if (CloseQty == 0)
			m_ulTempLongPos += (Qty - CloseQty);
		/*else*/ if (CloseQty > 0)
		{
			//lfProfit = CloseQty * (price - m_lfLongAvgPrice);
			m_ulTempLongPos -= CloseQty;
			m_ulTempShortPos -= CloseQty;

			CloseQty = 0;
		}
	}
	else
	{
		m_lfShortAvgPrice = ((m_lfShortAvgPrice * m_ulShortPosition) + (Qty * price))/(m_ulShortPosition + Qty);

		m_ulShortPosition += Qty;
		m_ulTotalSellVal += Qty * price;

		//if (CloseQty == 0)
			m_ulTempShortPos += (Qty - CloseQty);
		/*else*/ if (CloseQty > 0)
		{
			//lfProfit = CloseQty * (price - m_lfShortAvgPrice);
			m_ulTempLongPos -= CloseQty;
			m_ulTempShortPos -= CloseQty;

			CloseQty = 0;

		}
	}

	m_bPositionChanged = true;

	return nSuccess;
}

int ITNonHedgePosition::GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge)
{
	int nSuccess = 0;
	long position = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::GetQtyToCheckForMargin, Enter Position=%s, Qty=%lu", ToString().c_str(), ulQty);

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

	//if (pOrder->m_Order.Side == SIDE_SELL)
	//{
	//	if (pOppositeList->empty())
	//	{
	//		nSuccess = 999;

	//		return nSuccess;
	//	}
	//}

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
	else if (pOrder->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER || pOrder->m_Order.OrderType == ORDER_TYPE_LIMIT_ORDER)
	{
		// There are following conditions
		// The order is buy, and there are no orders in the sell list
		// The order is buy, and there are positions open in Sell list, and all the orders will get closed
		// The order is buy, and the order qty is > the no of position on the oppopsite side
		if (pOppositeList->empty())
		{
			// Do nothing. The ulQty remains same
		}
		else 
		{
			std::map<std::string, IOrder *>::iterator iter = pOppositeList->begin();

			for (;iter != pOppositeList->end();)
			{
				IOrder *pOppPosOrder = iter->second;

				if (pOppPosOrder)
				{
					unsigned long long ullAvailableQtyToClose = pOppPosOrder->CumQty - pOppPosOrder->QtyClose;
					unsigned long long ullTotalQtyToMap = pOrder->m_Order.OrderQty - pOrder->QtyClose;

					if (ullAvailableQtyToClose == 0)
					{
						// Remove from the list as there is no valid order qty to be closed
						//iter = pOppositeList->erase(iter);
						iter++;

						continue;
					}
					else
					{
						if (ullTotalQtyToMap > ullAvailableQtyToClose)
						{
							//iter = pOppositeList->erase(iter);

							//memcpy(&pOrder->m_Order.LnkdOrdId, &pOppPosOrder->m_Order.ClOrdId, sizeof(pOppPosOrder->m_Order.ClOrdId));
							// TBD BR Need to see if we really need to save the tagging in open position order?
							pOppPosOrder->AddOrderToTag(ullAvailableQtyToClose, 0, pOrder, false);
							pOrder->AddOrderToTag(ullAvailableQtyToClose, 0, pOppPosOrder, false);

							pOrder->m_Order.PositionEffect = POSITION_CLOSING_TRADE;
							ulQty -= ullAvailableQtyToClose;
							pOrder->QtyClose += ullAvailableQtyToClose;
							pOppPosOrder->QtyClose += ullAvailableQtyToClose;
							//pOppositeList->insert(pOrder);

							iter++;

						}
						else
						{
							//iter = pOppositeList->erase(iter);

							pOppPosOrder->AddOrderToTag(ullTotalQtyToMap, 0, pOrder, false);
							pOrder->AddOrderToTag(ullTotalQtyToMap, 0, pOppPosOrder, false);

							//memcpy(&pOrder->m_Order.LnkdOrdId, &pOppPosOrder->m_Order.ClOrdId, sizeof(pOppPosOrder->m_Order.ClOrdId));
							pOrder->m_Order.PositionEffect = POSITION_CLOSING_TRADE;
							ulQty -= ullTotalQtyToMap;
							pOrder->QtyClose += ullTotalQtyToMap;
							pOppPosOrder->QtyClose += ullTotalQtyToMap;
							//pOppositeList->insert(pOrder);

							break;
						}
					}
				}
			}

			if (pOrder->m_Order.OrderQty > pOrder->QtyClose && pOrder->QtyClose > 0)
			{
				// break and split the order
				//pOrder->AddOrderToTag(pOrder->m_Order.OrderQty - pOrder->QtyClose, NULL, true);
				// Need to split order here

				// code for splitting
				pOrder->m_ulQtyClosed = ulQty;
				nSuccess = 99;
			}

		}
	}

	//if (pOrder->m_Order.Side == SIDE_SELL && pOrder->m_Order.PositionEffect == 'O')
	//{
	//	nSuccess = 999;
	//}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::GetQtyToCheckForMargin, Exit Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	return nSuccess;
}

void ITNonHedgePosition::ResetPosition(unsigned long pos, char side)
{
	if (side == SIDE_BUY)
	{
		if (m_ulTempLongPos >= pos)
			m_ulTempLongPos -= pos;
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::ResetPosition, m_ulTempLongPos >= pos FALSE");
		}
	}
	else
	{
		if (m_ulTempShortPos >= pos)
			m_ulTempShortPos -= pos;
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::ResetPosition, m_ulTempShortPos >= pos FALSE");
		}
	}
}

int ITNonHedgePosition::CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin, unsigned long& ullcontractSize)
{
	int nSuccess = 0;

	lfProfit += m_pRMSCalc->CalculateProfit(pReport->LastPx, pOpenOrder->AvgPx, qty, pCloseOrder->m_Order.Side, pReport->Symbol, ullcontractSize); 

	return nSuccess;
}

int ITNonHedgePosition::UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos)
{
	int nSuccess = 0;

	bool bErased = false;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition, lfProfit=%lf ,lfUsedMargin=%lf ,ullContractSize=%lu",lfProfit,lfUsedMargin,ullContractSize);


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
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)");
		
		std::list<OrderExecInfo>::iterator iter = lstTaggedList.begin();

		unsigned long long ullQtyFilled = 0;
		unsigned long long ullQtyFilledLeft = pReport->QtyFilled;
 
		while (iter != lstTaggedList.end())
		{
			OrderExecInfo& info = *iter;

			if (info.bOpenPos == false)
			{

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : if (info.bOpenPos == false)");

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
					nSuccess = CalculateProfit(pOrder1, pOrder, pReport, ullQtyFilled, lfLocalProfit, lfUsedMargin, ullContractSize);

					lfUsedMargin += (pOrder1->m_lfUsedMargin/(pOrder1->m_Order.OrderQty)) * ullQtyFilled;

					lfProfit += lfLocalProfit;
					pOrder1->QtySettled += ullQtyFilled;
					pOrder->QtySettled += ullQtyFilled;
					info.SettledQty += ullQtyFilled;
					
					std::list<OrderExecInfo>& lstTaggedOrderList1 = pOrder1->GetTaggedOrderList();

					std::list<OrderExecInfo>::iterator iter1 = lstTaggedOrderList1.begin();

					for (; iter1 != lstTaggedOrderList1.end();)
					{
						OrderExecInfo& ExecInfo = *iter1;

						if (ExecInfo.pOrder->m_Order.OrderID == pOrder->m_Order.OrderID)
						{
							if (ullQtyFilled > ExecInfo.Qty - ExecInfo.SettledQty)
							{
								ExecInfo.SettledQty += ExecInfo.Qty - ExecInfo.SettledQty;
							}
							else
							{
								ExecInfo.SettledQty += ullQtyFilled;
							}

							if (ExecInfo.Qty == ExecInfo.SettledQty)
							{
								iter1 = lstTaggedOrderList1.erase(iter1);
							}
							else
							{
								iter1++;
							}
						}
						else
							iter1++;
					}

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
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : bErased = true");

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
	else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE &&
		pOrder->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER)
	{
		// May be we should check and tag some of the orders here

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE &&pOrder->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER)");


		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		pCurrentList->insert(pr);

		pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
									pOrder->m_Order.Side,
									pReport->LastPx,
									pOrder->CumQty + pReport->QtyFilled,
									0,
									POSITION_OPENING_TRADE);
	}
	else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE &&
		pOrder->m_Order.OrderType != ORDER_TYPE_MARKET_ORDER)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : else if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE &&pOrder->m_Order.OrderType != ORDER_TYPE_MARKET_ORDER)");
		//{
			// There are following conditions
			// The order is buy, and there are no orders in the sell list
			// The order is buy, and there are positions open in Sell list, and all the orders will get closed
			// The order is buy, and the order qty is > the no of position on the oppopsite side
			if (pOppositeList->empty())
			{
				// Do nothing. The ulQty remains same
				//if (pOrder->m_Order.OrderQty > pOrder->QtyClose)
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : if (pOppositeList->empty())");
				{
					std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
					pCurrentList->insert(pr);

					// For Openning Position On Limit Order

					if (strcmp(pReport->Symbol.Product, "GOLD") == 0)
								{
								// Send message for AutoHedge
								MQLOrder ord;
								ord.sym = 1;
								ord.qty = (pOrder->m_Order.OrderQty);

								stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition, Qty = %lu, Final Qty = %lf", (unsigned long)pOrder->m_Order.OrderQty, ord.qty);
								ord.qty = (pOrder->m_Order.OrderQty /** 0.16 */ / 50);
								//ord.price = pReport->LastPx;

								if (pReport->Side == SIDE_BUY)
								{
									ord.side = '1';
								}
								else if (pReport->Side == SIDE_SELL)
								{
									ord.side = '3';
								}

								SendMessageForAutoHedge(ord);
								}
				}
			}
			else 
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition : else (!pOppositeList->empty())");

				std::map<std::string, IOrder *>::iterator iter = pOppositeList->begin();
				unsigned long long ullQtyFilledLeft = pReport->QtyFilled;
				unsigned long long ullQtyFilled = 0;

				for (;iter != pOppositeList->end();)
				{
					IOrder *pOppPosOrder = iter->second;

					if (pOppPosOrder)
					{
						unsigned long long ullAvailableQtyToClose = pOppPosOrder->CumQty - pOppPosOrder->QtyClose;
						unsigned long long ullTotalQtyToMap = pOrder->CumQty + pReport->QtyFilled - pOrder->QtyClose;

						if (ullAvailableQtyToClose == 0)
						{
							// Remove from the list as there is no valid order qty to be closed
							iter = pOppositeList->erase(iter);

							continue;

							//std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
							//pCurrentList->insert(pr);

						}
						else
						{
							if (ullTotalQtyToMap > ullAvailableQtyToClose)
							{
								//iter = pOppositeList->erase(iter);

								//memcpy(&pOrder->m_Order.LnkdOrdId, &pOppPosOrder->m_Order.ClOrdId, sizeof(pOppPosOrder->m_Order.ClOrdId));
								// TBD BR Need to see if we really need to save the tagging in open position order?
								OrderExecInfo info;
								pOppPosOrder->AddOrderToTag(ullAvailableQtyToClose, 0, pOrder, false, &info);
								pOrder->AddOrderToTag(ullAvailableQtyToClose, 0, pOppPosOrder, false);

								//pOrder->m_Order.PositionEffect = POSITION_CLOSING_TRADE;
								//ulQty -= ullAvailableQtyToClose;
								pOrder->QtyClose += ullAvailableQtyToClose;
								pOppPosOrder->QtyClose += ullAvailableQtyToClose;
								//pOppositeList->insert(pOrder);

								double lfLocalProfit = 0;
								// Calculate profit and store it in map table
								nSuccess = CalculateProfit(pOppPosOrder, pOrder, pReport, ullAvailableQtyToClose, lfLocalProfit, lfUsedMargin, ullContractSize);

								lfUsedMargin += (pOppPosOrder->m_lfUsedMargin/(pOppPosOrder->m_Order.OrderQty)) * ullAvailableQtyToClose;
								lfUsedMargin += (pOrder->m_lfUsedMargin/(pOrder->m_Order.OrderQty)) * ullAvailableQtyToClose;

								lfProfit += lfLocalProfit;
								pOppPosOrder->QtySettled += ullAvailableQtyToClose;
								pOrder->QtySettled += ullAvailableQtyToClose;
								//info.SettledQty += ullAvailableQtyToClose;

								pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
															pOppPosOrder->m_Order.Side,
															pOppPosOrder->AvgPx,
															ullAvailableQtyToClose,
															lfLocalProfit,
															POSITION_CLOSING_TRADE);

								if (strcmp(pReport->Symbol.Product, "GOLD") == 0)
								{
								// Send message for AutoHedge
								MQLOrder ord;
								ord.sym = 1;
								ord.qty = (ullAvailableQtyToClose)/ 50;

								stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition, Qty = %lu, Final Qty = %lf", (unsigned long)pOrder->m_Order.OrderQty, ord.qty);
								//ord.qty = (pOrder->m_Order.OrderQty /** 0.16*/  / 50);
								//ord.price = pReport->LastPx;

								if (pReport->Side == SIDE_BUY)
								{
									ord.side = '2';
								}
								else if (pReport->Side == SIDE_SELL)
								{
									ord.side = '4';
								}

								SendMessageForAutoHedge(ord);
								}

								pReport->ClosedQuantity = pOrder->QtySettled;

								ullQtyFilledLeft -= ullAvailableQtyToClose;

								pListOrdersToUpdate->push_back(pOppPosOrder);

								pOrder->UpdateOrderMapping(&info,0);


								iter++;

							}
							else
							{
								//iter = pOppositeList->erase(iter);

								OrderExecInfo info;
								pOppPosOrder->AddOrderToTag(ullTotalQtyToMap, 0, pOrder, false, &info);
								pOrder->AddOrderToTag(ullTotalQtyToMap, 0, pOppPosOrder, false);

								//memcpy(&pOrder->m_Order.LnkdOrdId, &pOppPosOrder->m_Order.ClOrdId, sizeof(pOppPosOrder->m_Order.ClOrdId));
	//							pOrder->m_Order.PositionEffect = POSITION_CLOSING_TRADE;
								//ulQty -= ullTotalQtyToMap;
								pOrder->QtyClose += ullTotalQtyToMap;
								pOppPosOrder->QtyClose += ullTotalQtyToMap;
								//pOppositeList->insert(pOrder);

								double lfLocalProfit = 0;
								// Calculate profit and store it in map table
								nSuccess = CalculateProfit(pOppPosOrder, pOrder, pReport, ullTotalQtyToMap, lfLocalProfit, lfUsedMargin, ullContractSize);

								lfUsedMargin += (pOppPosOrder->m_lfUsedMargin/(pOppPosOrder->m_Order.OrderQty)) * ullTotalQtyToMap;
								lfUsedMargin += (pOrder->m_lfUsedMargin/(pOrder->m_Order.OrderQty)) * ullTotalQtyToMap;

								lfProfit += lfLocalProfit;
								pOppPosOrder->QtySettled += ullTotalQtyToMap;
								pOrder->QtySettled += ullTotalQtyToMap;
								//info.SettledQty += ullTotalQtyToMap;

								pGlobalPos->UpdatePosition(pOrder->m_Order.Symbol,
															pOppPosOrder->m_Order.Side,
															pOppPosOrder->AvgPx,
															ullTotalQtyToMap,
															lfLocalProfit,
															POSITION_CLOSING_TRADE);

								if (strcmp(pReport->Symbol.Product, "GOLD") == 0)
								{
								// Send message for AutoHedge
								MQLOrder ord;
								ord.sym = 1;
								ord.qty = (ullTotalQtyToMap /** 0.16*/ /50 );
								//ord.qty = (pOrder->m_Order.OrderQty);
								ord.price = pOppPosOrder->AvgPx;

								stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition, Qty = %lu, Final Qty = %lf", (unsigned long)pOrder->m_Order.OrderQty, ord.qty);

								if (pReport->Side == SIDE_BUY)
								{
									ord.side = '2';
								}
								else if (pReport->Side == SIDE_SELL)
								{
									ord.side = '4';
								}

								SendMessageForAutoHedge(ord);
								}


								pReport->ClosedQuantity = pOrder->QtySettled;

								//ullQtyFilledLeft -= ullTotalQtyToMap;

								pListOrdersToUpdate->push_back(pOppPosOrder);

								pOrder->UpdateOrderMapping(&info,0);


								break;
							}
						}
					}
				}

				if (pOrder->m_Order.OrderQty > pOrder->QtyClose)
				{
					std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
					pCurrentList->insert(pr);
					if (strcmp(pReport->Symbol.Product, "GOLD") == 0)
					{
					// Send message for AutoHedge
					MQLOrder ord;
					ord.sym = 1;
					/*ord.qty = ((pOrder->m_Order.OrderQty - pOrder->QtyClose) * 28.3 /100 ) ;*/
					ord.qty = (((pOrder->m_Order.OrderQty - pOrder->QtyClose) /50)/* * 0.16*/) ;
					ord.price = pReport->LastPx;

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::UpdatePosition, Qty = %lu, Final Qty = %lf", (unsigned long)pOrder->m_Order.OrderQty - pOrder->QtyClose, ord.qty);

					if (pReport->Side == SIDE_BUY)
					{
						ord.side = '1';
					}
					else if (pReport->Side == SIDE_SELL)
					{
						ord.side = '3';
					}

					SendMessageForAutoHedge(ord);
					}
				}

				//if (pOrder->m_Order.OrderQty > pOrder->QtyClose && pOrder->QtyClose > 0)
				//{
				//	// break and split the order
				//	//pOrder->AddOrderToTag(pOrder->m_Order.OrderQty - pOrder->QtyClose, NULL, true);
				//	// Need to split order here

				//	// code for splitting
				//	pOrder->m_ulQtyClosed = ulQty;
				//	nSuccess = 99;
				//}

			}
		}
	//}

	return nSuccess;
}


int ITNonHedgePosition::AdjustUsedMargin(IOrder *pOrder, ExecutionReport *pReport, double lfUsedMArgin, double& lAdjustmentDone)
{
	int nSuccess = 0;

	return nSuccess;
}

int ITNonHedgePosition::UpdateUsedMargins(char side, double ulUM, double overAll, double& adjustment)
{
	int nSuccess = 0;

	return nSuccess;
}

int ITNonHedgePosition::CalculateOpenPnL(double ltp, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder1)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgePosition::CalculateOpenPnL, ltp=%lf, ask=%lf , MaxLOss = %lf, lfMaxLoss=%lf,ullContractSize=%lu",ltp,ask,lfMaxLoss,lfOpenPnL,ullContractSize);

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
				if (pOrder->CumQty == pOrder->QtySettled)
				{
					iter++;
					continue;
				}
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

int ITNonHedgePosition::SendMessageForAutoHedge(MQLOrder& order)
{
	int nSuccess = 0;

	return nSuccess;

	HANDLE hPipe;
	OVERLAPPED olp;
	CXEvent eventTransact;

	memset(&olp, 0, sizeof(olp));
	olp.hEvent = eventTransact.GetEvent();

	//std::string pipeName = "\\\\.\\pipe\\MT5300039439";
	std::string pipeName = "\\\\.\\pipe\\MT55153373";
	//std::string pipeName = "\\\\.\\pipe\\MT55150576";

	/*TCHAR szPipeName[100];
	wsprintf(szPipeName, _T("MT5%d"), AccountNo);
	pipeName.append(szPipeName);*/

	DWORD dwWrittenBytes = 0;
	if ((hPipe = CreateFile(pipeName.c_str(),
							GENERIC_READ |
							GENERIC_WRITE,
							FILE_SHARE_READ | FILE_SHARE_WRITE,
							NULL,
							OPEN_EXISTING,
							FILE_FLAG_OVERLAPPED,
							NULL)) == INVALID_HANDLE_VALUE)
	{
		DWORD error = GetLastError();
	}

	bool success = WriteFile(hPipe,
		(void *)&order,
		sizeof(order),
		&dwWrittenBytes,
		&olp);

	if (success == true)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Autohedge order sent for Qty = %lf", order.qty);
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OrderResponseHandler::SendExecutionReport, Autohedge order Not sent for Qty = %lf", order.qty);
	}


	return nSuccess;
}


int ITNonHedgePosition::UpdateNetPosition(IOrder *pOrder)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITNonHedgePosition::UpdateNetPosition, Enter, AccNo = %lu Contract = %s",
		pOrder->m_Order.Account,
		pOrder->m_Order.Symbol.Contract);

	if (pOrder->m_Order.Side == SIDE_BUY)
	{

		m_lfLongAvgPrice = ((m_lfLongAvgPrice * m_ulLongPosition) + (pOrder->AvgPx * pOrder->CumQty)) / (m_ulLongPosition + pOrder->CumQty);

		m_ulLongPosition += pOrder->CumQty;
		m_ulTotalBuyVal += pOrder->CumQty * pOrder->AvgPx;
	}
	else
	{
		m_lfShortAvgPrice = ((m_lfShortAvgPrice * m_ulShortPosition) + (pOrder->AvgPx * pOrder->CumQty)) / (m_ulShortPosition + pOrder->CumQty);

		m_ulShortPosition += pOrder->CumQty;
		m_ulTotalSellVal += pOrder->CumQty * pOrder->AvgPx;
	}

	m_bPositionChanged = true;

	return 0;
}

int ITNonHedgePosition::UpdateNetPosition(ExecutionReport *pReport)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITNonHedgePosition::UpdateNetPosition, Enter, AccNo = %lu Position Effect = %c, Short = %lu, Long = %lu, Short Avg = %lf, Long Avg = %lf, Qty Filled = %lu, Last Px = %lf, Profit = %lf, Side = %c, Contract = %s", 
	//																																			pReport->Account,
	//																																			pReport->PositionEffect,
	//																																			m_ulShortPosition, 
	//																																			m_ulLongPosition, 
	//																																			
	//																																			m_lfShortAvgPrice,
	//																																			m_lfLongAvgPrice,
	//																																			pReport->QtyFilled,
	//																																			pReport->LastPx,
	//																																			pReport->Profit,
	//																																			pReport->Side,
	//																																			pReport->Symbol.Contract);

	if (pReport->Side == SIDE_BUY)
	{
		unsigned long ulLeftPos = 0;

		if (m_ulShortPosition > 0)
		{
			// If there is short position, we need to first adjust the short position 
			if (pReport->QtyFilled >= m_ulShortPosition)
			{
				ulLeftPos = pReport->QtyFilled - m_ulShortPosition;
				m_ulShortPosition = 0;
				m_lfShortAvgPrice = 0;
			}
			else
			{
				m_lfShortAvgPrice = ((m_lfShortAvgPrice * m_ulShortPosition) - ((pReport->LastPx + pReport->Profit)) * pReport->QtyFilled) / (m_ulShortPosition - pReport->QtyFilled);
				m_ulShortPosition = m_ulShortPosition - pReport->QtyFilled;
			}
		}
		else
		{
			ulLeftPos = pReport->QtyFilled;
		}

		if (ulLeftPos > 0)
		{
			// Now adjust the long position
			m_lfLongAvgPrice = ((m_lfLongAvgPrice * m_ulLongPosition) + (pReport->LastPx * ulLeftPos)) / (m_ulLongPosition + ulLeftPos);

			m_ulLongPosition += ulLeftPos;
			m_ulTotalBuyVal += pReport->QtyFilled * pReport->LastPx;
		}
	}
	else if (pReport->Side == SIDE_SELL)
	{
		unsigned long ulLeftPos = 0;

		if (m_ulLongPosition > 0)
		{
			// If there is short position, we need to first adjust the short position 
			if (pReport->QtyFilled >= m_ulLongPosition)
			{
				ulLeftPos = pReport->QtyFilled - m_ulLongPosition;
				m_ulLongPosition = 0;
				m_lfLongAvgPrice = 0;
			}
			else
			{
				m_lfLongAvgPrice = ((m_lfLongAvgPrice * m_ulLongPosition) - ((pReport->LastPx - pReport->Profit)*pReport->QtyFilled)) / (m_ulLongPosition - pReport->QtyFilled);
				m_ulLongPosition = m_ulLongPosition - pReport->QtyFilled;
			}
		}
		else
		{
			ulLeftPos = pReport->QtyFilled;
		}

		if (ulLeftPos > 0)
		{
			// Now adjust the long position
			m_lfShortAvgPrice = ((m_lfShortAvgPrice * m_ulShortPosition) + (pReport->LastPx * ulLeftPos)) / (m_ulShortPosition + ulLeftPos);

			m_ulShortPosition += ulLeftPos;
			m_ulTotalSellVal += pReport->QtyFilled * pReport->LastPx;
		}
	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITNonHedgePosition::UpdateNetPosition, Exit, AccNo = %lu Position Effect = %c, Short = %lu, Long = %lu, Short Avg = %lf, Long Avg = %lf, Qty Filled = %lu, Last Px = %lf, Profit = %lf, Side = %c, Contract = %s",
	//	pReport->Account,
	//	pReport->PositionEffect,
	//	m_ulShortPosition,
	//	m_ulLongPosition,
	//	//pReport->PositionEffect,
	//	m_lfShortAvgPrice,
	//	m_lfLongAvgPrice,
	//	pReport->QtyFilled,
	//	pReport->LastPx,
	//	pReport->Profit,
	//	pReport->Side,
	//	pReport->Symbol.Contract);

	m_bPositionChanged = true;
	return 0;
}


int ITNonHedgePosition::CancelPositionTags(IOrder *pOrder, ExecutionReport *pReport, void* lstOrdersToUpdate)
{
	std::list<OrderExecInfo>& TaggedList = pOrder->GetTaggedOrderList();

	std::list<IOrder*> *pListOrdersToUpdate = (std::list<IOrder*> *)lstOrdersToUpdate;

	std::list<OrderExecInfo>::iterator iter = TaggedList.begin();

	for (; iter != TaggedList.end();)
	{
		OrderExecInfo& order = *iter;

		IOrder *ppOrder = order.pOrder;

		if (ppOrder)
		{
			std::list<OrderExecInfo>& SlaveTaggedList = ppOrder->GetTaggedOrderList();

			std::list<OrderExecInfo>::iterator iter1 = SlaveTaggedList.begin();

			for (; iter1 != SlaveTaggedList.end();)
			{
				OrderExecInfo& order1 = *iter1;

				if (order1.pOrder->m_Order.OrderID == pOrder->m_Order.OrderID)
				{
					unsigned long long ullCanceledQty = pReport->QtyFilled;

					if (ullCanceledQty > order1.Qty - order1.SettledQty)
					{
						ppOrder->QtyClose -= order1.Qty - order1.SettledQty;
						pOrder->UpdateOrderMapping(&order, order1.Qty - order1.SettledQty);
					}
					else
					{
						ppOrder->QtyClose -= ullCanceledQty;
						pOrder->UpdateOrderMapping(&order, ullCanceledQty);
					}

					pListOrdersToUpdate->push_back(ppOrder);
					iter1 = SlaveTaggedList.erase(iter1);
				}
				else
					iter1++;
			}
		}

		iter++;
	}

	//TaggedList.clear();

	return 0;
}