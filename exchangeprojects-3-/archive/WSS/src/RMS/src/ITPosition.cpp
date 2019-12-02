#include "stdafx.h"
#include "RMSAPI.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "Datadef.h"
#include "xlogger.h"
#include "IAccount.h"
#include "IOrder.h"

ITPosition::ITPosition()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::ITPosition, Entered");

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

	m_ulLastBidPrice = 0;
	m_ulLastAskPrice = 0;

	m_lfOpenPnL = 0;
}

bool ITPosition::GetPositionResponse(void*& pResponse)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Entered");

	bool bSuccess = false;

	//EnterCriticalSection(&m_cs);

	if (m_bPositionChanged)
	{
		PositionResponse *pPositionResponse = (PositionResponse *)GetMessageObject(POSITION_RESPONSE);

		if (pPositionResponse)
		{
			pPositionResponse->Header.KeyDataCtrlBlk = 1;
			pPositionResponse->NoOfPosition = 1;
			memcpy(&pPositionResponse->Position[0].Symbol, &m_Symbol, sizeof(m_Symbol));
			pPositionResponse->Position[0].Account = m_pAccount->m_Account;
			pPositionResponse->Position[0].BuyAvg = this->m_lfLongAvgPrice;
			pPositionResponse->Position[0].BuyQty = this->m_ulLongPosition;
			pPositionResponse->Position[0].BuyVal = this->m_ulTotalBuyVal;
			pPositionResponse->Position[0].SellAvg = this->m_lfShortAvgPrice;
			pPositionResponse->Position[0].SellQty = this->m_ulShortPosition;
			pPositionResponse->Position[0].SellVal = this->m_ulTotalSellVal;

			pPositionResponse->Position[0].NetVal =  0;// ((double)pPositionResponse->Position[0].BuyVal) - pPositionResponse->Position[0].SellVal;
			pPositionResponse->Position[0].NetPrice = 0;// ((double)pPositionResponse->Position[0].BuyAvg) - pPositionResponse->Position[0].SellAvg;
			pPositionResponse->Position[0].NetQty = 0;// ((double)pPositionResponse->Position[0].BuyQty) - pPositionResponse->Position[0].SellQty;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Long = %lu, Short=%lu", m_ulLongPosition, m_ulShortPosition);

			pResponse = (void *)pPositionResponse;
			bSuccess = true;
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Unable to allocate memory for PositionResponse");
		}
	}

	m_bPositionChanged = false;

	return bSuccess;
}

bool ITPosition::GetPositionResponseEx(position *pResponse)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Entered");

	bool bSuccess = false;

	//EnterCriticalSection(&m_cs);

	//if (m_bPositionChanged)
	{
		if (pResponse)
		{
			memcpy(&pResponse->Symbol, &m_Symbol, sizeof(m_Symbol));
			pResponse->Account = m_pAccount->m_Account;
			pResponse->BuyAvg = this->m_lfLongAvgPrice;
			pResponse->BuyQty = this->m_ulLongPosition;
			pResponse->BuyVal = this->m_ulTotalBuyVal;
			pResponse->SellAvg = this->m_lfShortAvgPrice;
			pResponse->SellQty = this->m_ulShortPosition;
			pResponse->SellVal = this->m_ulTotalSellVal;

			pResponse->NetVal = 0;// ((double)pPositionResponse->Position[0].BuyVal) - pPositionResponse->Position[0].SellVal;
			pResponse->NetPrice = 0;// ((double)pPositionResponse->Position[0].BuyAvg) - pPositionResponse->Position[0].SellAvg;
			pResponse->NetQty = 0;// ((double)pPositionResponse->Position[0].BuyQty) - pPositionResponse->Position[0].SellQty;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Long = %lu, Short=%lu", m_ulLongPosition, m_ulShortPosition);

			bSuccess = true;
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetPositionResponse, Unable to allocate memory for PositionResponse");
		}
	}

	m_bPositionChanged = false;

	return bSuccess;
}

std::string ITPosition::ToString()
{
	std::string strLog;

	char szVal[1000];

	//EnterCriticalSection(&m_cs);
	sprintf(szVal, "Account = %lu, LongAvgPrice=%lf, ShortAvgPrice=%lf, Long Pos=%lu, Short Pos=%lu, Temp Long Pos=%lu, Temp Short Pos=%lu, TotalbuyVal=%lu, TotalSellVal=%lu", 
						this->m_pAccount->m_Account,
						this->m_lfLongAvgPrice,
						this->m_lfShortAvgPrice,
						this->m_ulLongPosition,
						this->m_ulShortPosition,
						this->m_ulTempLongPos,
						this->m_ulTempShortPos,
						this->m_ulTotalBuyVal,
						this->m_ulTotalSellVal);

	//ReleaseLock(&m_cs);
	strLog = szVal;

	return strLog;
}

int ITPosition::UpdatePositionStats(char side, unsigned long Qty, char positionEffect, unsigned long long price, unsigned long& CloseQty, double& lfProfit)
{
	int nSuccess = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::UpdatePositionStats, Enter Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	if (side == SIDE_BUY)
	{
		m_lfLongAvgPrice = ((m_lfLongAvgPrice * m_ulLongPosition) + (Qty * price))/(m_ulLongPosition + Qty);

		m_ulLongPosition += Qty;
		m_ulTotalBuyVal += Qty * price;
	
		//if (CloseQty == 0)
			m_ulTempLongPos += (Qty - CloseQty);
		/*else*/ if (CloseQty > 0)
		{
			lfProfit = CloseQty * (price - m_lfLongAvgPrice);
			m_ulTempLongPos -= CloseQty;
			m_ulTempShortPos -= CloseQty;
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
			lfProfit = CloseQty * (price - m_lfShortAvgPrice);
			m_ulTempLongPos -= CloseQty;
			m_ulTempShortPos -= CloseQty;
		}
	}

	m_bPositionChanged = true;
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::UpdatePositionStats, Exit Position=%s, CloseQty=%lu", ToString().c_str(), CloseQty);

	return nSuccess;
}

int ITPosition::GetQtyToCheckForMargin(unsigned long& ulQty, IOrder *pOrder, bool bHedge)
{
	int nSuccess = 0;
	long position = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetQtyToCheckForMargin, Enter Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	/*if (!bHedge)
	{*/
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
	//}
	//else
	//{
	//	// Hedging is enabled
	//	if (pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	//	{
	//		if (pOrder->m_Order.Side == SIDE_BUY)
	//		{
	//			position = m_ulTempShortPos - m_ulTempLongPos;

	//			if (position > 0)
	//			{
	//				if (position >= ulQty)
	//				{
	//					pOrder->QtyClose = ulQty;
	//					ulQty = 0;
	//				}
	//				else
	//				{
	//					pOrder->QtyClose = position;
	//					ulQty -= position;
	//				}

	//				m_ulTempLongPos += pOrder->QtyClose;
	//			}
	//		}
	//		else if (pOrder->m_Order.Side == SIDE_SELL)
	//		{
	//			position = m_ulTempLongPos - m_ulTempShortPos;
	//			if (position > 0)
	//			{
	//				if (position >= ulQty)
	//				{
	//					pOrder->QtyClose = ulQty;
	//					ulQty = 0;
	//				}
	//				else
	//				{
	//					ulQty -= position;
	//					pOrder->QtyClose = position;
	//				}

	//				m_ulTempShortPos += pOrder->QtyClose;
	//			}
	//		}
	//	}
		
		
	/*	if (pOrder->m_Order.PositionEffect == POSITION_CLOSING_TRADE)
		{
			ulQty = 0;
		}*/
	//}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::GetQtyToCheckForMargin, Exit Position=%s, Qty=%lu", ToString().c_str(), ulQty);

	return nSuccess;
}

int ITPosition::Init(IDatabase* pDatabase, IAccount *pAcc, std::string strContract, ITable *pTable)
{
	int nSuccess = 0;
	char productType[10];

	pTable->Get("ContractName", m_Symbol.Contract, sizeof(m_Symbol.Contract));
	pTable->Get("ProductName", m_Symbol.Product, sizeof(m_Symbol.Product));
	pTable->Get("ProductType", productType, sizeof(productType));
	m_Symbol.ProductType = productType[0];
	pTable->Get("ProviderName", m_Symbol.Gateway, sizeof(m_Symbol.Gateway));
	//pTable->Get("ExchangeName", m_Symbol.Exchange, sizeof(m_Symbol.Exchange));
	pTable->Get("BuyQty", m_ulLongPosition);
	pTable->Get("SellQty", m_ulShortPosition);
	pTable->Get("BuyPrice", m_lfLongAvgPrice);
	pTable->Get("SellPrice", m_lfShortAvgPrice);
	pTable->Get("BuyVal", m_ulTotalBuyVal);
	pTable->Get("SellVal", m_ulTotalSellVal);
	pTable->Get("TempLongPos", m_ulTempLongPos);
	pTable->Get("TempShortPos", m_ulTempShortPos);
	pTable->Get("BuySideUsedMargin", m_ulBuySideUsedMargin);
	pTable->Get("SellSideUsedMargin", m_ulSellSideUsedMargin);
	pTable->Get("OverallUsedMargin", m_ulOverAllUsedMargin);

	m_Database = pDatabase;
	m_pAccount = pAcc;
	m_Account = pAcc->m_Account;

	return nSuccess;
}

//double ITPosition::CalculateOpenPnL(double bid, double ask, bool& SessionClosed, double& tradeMargin, unsigned long& Qty, char& side, int leverage)
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
void ITPosition::ResetPosition(unsigned long pos, char side)
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

//int ITPosition::UpdateTempPos()
//{
//	int nSuccess = 0;
//
//	ITable* tb=CreateTable();
//	IParameter* param=CreateParameter();
//
//	param->AddParam("AccountID", m_pAccount->m_Account);
//	param->AddParam("Symbol", m_Symbol.Contract, sizeof(m_Symbol.Contract));
//	param->AddParam("Temp_Long_Pos", m_ulTempLongPos);
//	param->AddParam("Temp_Short_Pos", m_ulTempShortPos);
//
//	bool isSPExist = m_Database->Execute("Exchange_UpdateTempPos",*tb,*param);//execute sp
//	if( !isSPExist )
//	{
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateTempPos, Unable to execute SP");
//		nSuccess = ERR_INTERNAL_ERROR_DB;
//		ReleaseTable(tb);//release table object
//		ReleaseParameter(param);//release parameter object
//
//		return nSuccess;
//	}
//
//	ReleaseTable(tb);//release table object
//	ReleaseParameter(param);//release parameter object
//
//	return nSuccess;
//}

int ITPosition::CalculateProfit(IOrder *pOpenOrder, IOrder *pCloseOrder, ExecutionReport *pReport, unsigned long qty, double& lfProfit, double& lfUsedMargin)
{
	int nSuccess = 0;

	lfProfit += (pReport->LastPx - pOpenOrder->AvgPx) * qty;

	if ((pOpenOrder->m_Order.OrderQty == pOpenOrder->QtySettled) )
	{
		lfUsedMargin += pOpenOrder->m_lfUsedMargin;
	}
	else
	{
		lfUsedMargin += pOpenOrder->m_lfUsedMargin/(pOpenOrder->m_Order.OrderQty - pOpenOrder->QtyClose)  * qty;
	}

	if (pCloseOrder->m_Order.OrderType  != ORDER_TYPE_MARKET_ORDER)
	{
		if ((pCloseOrder->m_Order.OrderQty == pCloseOrder->QtySettled) )
		{
			lfUsedMargin += pCloseOrder->m_lfUsedMargin;
		}
		else
		{
			lfUsedMargin += pCloseOrder->m_lfUsedMargin/(pCloseOrder->m_Order.OrderQty/* - pCloseOrder->QtySettled*/)  * qty;
		}
	}

	return nSuccess;
}

int ITPosition::UpdatePosition(IOrder *pOrder, ExecutionReport *pReport, double& lfProfit, double& lfUsedMargin, unsigned long long& ullContractSize, void* lstOrdersToUpdate, IGlobalPosition *pGlobalPos)
{
	int nSuccess = 0;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITPosition::UpdatePosition, lfProfit=%lf ,lfUsedMargin=%lf ,ullContractSize=%lu",lfProfit,lfUsedMargin,ullContractSize);


	std::list<IOrder*> *pListOrdersToUpdate = (std::list<IOrder*> *)lstOrdersToUpdate;

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

	// Check if there is any order that can be closed. 
	std::map<std::string, IOrder *>::iterator iter = pOppositeList->begin();

	unsigned long QtyAvailable = pReport->QtyFilled;

	bool bErased = false;

	for (;QtyAvailable > 0 && iter != pOppositeList->end() ; )
	{
		bErased = false;
		IOrder *pOrder1 = (*iter).second;

		if (pOrder1)
		{
			if (pOrder1->CumQty > pOrder1->QtySettled)
			{
				unsigned long QtyAvblToBeClosed = pOrder1->CumQty - pOrder1->QtySettled;

				unsigned long qty = 0;
				// Settle both the orders
				if (QtyAvblToBeClosed >= QtyAvailable)
				{
					qty = QtyAvailable;
					QtyAvblToBeClosed -= QtyAvailable;

					QtyAvailable = 0;
				}
				else
				{
					qty = QtyAvblToBeClosed;

					QtyAvailable -= QtyAvblToBeClosed;
					QtyAvblToBeClosed = 0;
				}

				// Calculate profit and store it in map table
				nSuccess = CalculateProfit(pOrder1, pOrder, pReport, qty, lfProfit, lfUsedMargin);
				pOrder1->QtySettled += qty;
				pOrder->QtySettled += qty;
			}
			else
			{
				// At wrong place)
			}

			// Remove the order from the opposite list, if the order is completely settled
			if (pOrder1->CumQty == pOrder1->QtySettled)
			{
				iter = pOppositeList->erase(iter);

				//pOrder1->UpdateOrder();
				pListOrdersToUpdate->push_back(pOrder1);

				bErased = true;

				if (pOppositeList->empty())
					break;
			}
		}

		if (!bErased)
			iter++;

	}

	if (pOrder->QtySettled < pOrder->CumQty + pReport->QtyFilled)
	{
		// Insert it in the open position list
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		pCurrentList->insert(pr);
	}

	return nSuccess;
}

int ITPosition::UpdateNetPosition(IOrder *pOrder)
{
	// this should be defined in the derived functions
	return 0;
}

int ITPosition::UpdateNetPosition(ExecutionReport *pReport)
{
	// this should be defined in the derived functions
	return 0;
}

int ITPosition::LoadOpenPosOrder(IOrder *pOrder)
{
	int nSuccess = 0;

	if (pOrder->m_Order.Side == SIDE_BUY)
	{
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		m_lstLongPosList.insert(pr);

		
		//UpdatePositionStats(pOrder->m_Order.Side, )
	}
	else
	{
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		m_lstShortPosList.insert(pr);
	}

	UpdateNetPosition(pOrder);

	return nSuccess;
}


double ITPosition::GetOverAllUsedMargin()
{
	return m_ulOverAllUsedMargin;
}

double ITPosition::GetBuyUsedMargin()
{
	return m_ulBuySideUsedMargin;
}

double ITPosition::GetSellUsedMargin()
{
	return m_ulSellSideUsedMargin;
}


int ITPosition::CalculateOpenPnL(double bid, double ask, char *pclOrdID, double& lfMaxLoss, double& lfOpenPnL, unsigned long& ullContractSize, IOrder*& pOrder1)
{
	int nSuccess = 0;


	return nSuccess;
}

int ITPosition::LoadAllNonSettledMapping(ITable *tb)
{
	int nSuccess = 0;

	char szOpenOrderID[20];
	char szCloseOrderID[20];
	char szSymbol[20];
	unsigned long long Qty = 0;
	unsigned long long SettledQty = 0;
	char side;
	char szVal[5];

	//while (!tb->IsEOF())
	{
		tb->Get("Symbol", szSymbol, sizeof(	szSymbol));
		tb->Get("OpenOrderID", szOpenOrderID, sizeof(	szOpenOrderID));
		tb->Get("CloseOrderID", szCloseOrderID, sizeof(	szCloseOrderID));
		tb->Get("Qty", Qty);
		tb->Get("SettledQty", SettledQty);
		//tb->Get("OpenOrderSide", szVal, sizeof(szVal));
		//side = szVal[0];
		tb->Get("OpenOrderSide", side);


		std::map<std::string, IOrder *> *pCurrentList = NULL;
		std::map<std::string, IOrder *> *pOppositeList = NULL;

		if (side == SIDE_BUY)
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

		std::map<std::string, IOrder *>::iterator iter = pCurrentList->find(szOpenOrderID);

		if (iter != pCurrentList->end())
		{
			IOrder *pOpenOrder = iter->second;

			if (pOpenOrder)
			{
				std::map<std::string, IOrder *>::iterator iter1 = pOppositeList->find(szCloseOrderID);

				if (iter1 != pOppositeList->end())
				{
					IOrder *pCloseOrder = iter1->second;

					if (pCloseOrder)
					{
						pOpenOrder->AddOrderToTag(Qty, SettledQty, pCloseOrder, false);
						pCloseOrder->AddOrderToTag(Qty, SettledQty, pOpenOrder, false);
					}
				}
			}
		}

		//tb->MoveNext();
	}

	return nSuccess;
}

int ITPosition::CancelPositionTags(IOrder *pOrder, ExecutionReport *pReport, void* lstOrdersToUpdate)
{
	return 0;
}