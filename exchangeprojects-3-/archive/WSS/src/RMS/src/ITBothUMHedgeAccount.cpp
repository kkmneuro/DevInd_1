////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//08-02-2012	BR					1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "StdAfx.h"
#include <list>
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "xlogger.h"
#include <math.h>
#include <atlbase.h>
#include "UtilitiesAPI.h"
#include "IOrder.h"
#include "serverinterface.h"
#include "time.h"
#include "ITbothUMHedgeAccount.h"
#include "ITBothUMHedgePosition.h"
#include "RMSCalculator.h"
//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "ITBothUMHedgeAccount"

ITBothUMHedgeAccount::ITBothUMHedgeAccount(unsigned int ulAccount,
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
				IDatabase *pDatabase)
{
	//unsigned long		m_Account = 0;
	//bool				m_bRMSEnable = false;
	//double				m_Balance = 0;
	//int					m_nLeverage = 0;
	//int					m_nGroup = 0;
	//double				m_lfUsedMargin = 0;
	//bool				m_bHedge = false;
	//bool				m_nEnableTrade = false;
	//double				m_lfBuyTurnover = 0 ;
	//double				m_lfSellTurnover = 0;
	//double				m_lfDayRealizedProfit = 0;
	//double				m_lfDayOpenProfit = 0;
	//std::string			m_strLPName = "";
	//double				m_OpenPnL = 0;
	//double				m_StopOut = 0;

	//int					m_nMarginCall1 = 0;
	//int					m_nMarginCall2 = 0;
	//int					m_nMarginCall3 = 0;
	//std::string			m_strTraderName = "";
	//std::string			m_strAccountType = "";

	//IDatabase *m_pDatabase = NULL;
	//IDatabase *m_pDatabaseBO = NULL;
	//bool				m_bAccountChanged = false;
	




	m_Account = ulAccount;
	m_Balance = lfBalance;
	m_nLeverage = nLeverage;
	m_nGroup = nGroup;
	m_lfUsedMargin = lfUsedMArgin;
	m_bHedge = bHedge;
	m_nEnableTrade = bEnableTrade;
	m_lfBuyTurnover = lfBuyTurnOver;
	m_lfSellTurnover = lfSellTurnOver;
	m_bAccountChanged = false;
	m_lfBuySideUsedMargin = 0;
	m_lfSellSideUsedMargin = 0;
}

ITBothUMHedgeAccount::~ITBothUMHedgeAccount()
{

}

// Checks if the margin is available or not.
int ITBothUMHedgeAccount::CheckMargin(IOrder *ord, unsigned long long Qty, double lfFees, double lfTax, IContractManager *pContractManager, IPosition *pPosition)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Entered");
	
	int nSuccess = 0;

	double currentPrice = 0;
	unsigned long long ulCurrentPrice = 0;
	unsigned long long ulSize = 0;
	unsigned long digits = 2;
	unsigned long initialMargin = 5;

	if (ord->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	{
		CComBSTR str(ord->m_Order.Symbol.Product);
		CComBSTR strContract(ord->m_Order.Symbol.Contract);
		CComBSTR strGateway(ord->m_Order.Symbol.Gateway);

		BSTR bstrProduct, bstrContract, bstrGateway;

		bstrProduct = str.Detach();
		bstrContract = strContract.Detach();
		bstrGateway = strGateway.Detach();
		
		HRESULT hr = pContractManager->GetInitialMargin(ord->m_Order.Symbol.ProductType,
														bstrProduct,	
														bstrContract,
														bstrGateway,
														bstrGateway,
														ord->m_Order.Side,
														&initialMargin,
														&digits);


		if (!FAILED(hr))
		{
			if (ord->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER)
			{
				char type;

				/*if (ord->m_Order.Side == SIDE_BUY)
					type = QUOTES_STREAM_TYPE_ASK;
				else if (ord->m_Order.Side == SIDE_SELL)
					type = QUOTES_STREAM_TYPE_BID;*/

				type = QUOTES_STREAM_TYPE_LAST;

				hr = pContractManager->GetLatestPrice(type,
														bstrProduct,
														bstrContract,
														strGateway,
														strGateway,
														&ulSize,
														&ulCurrentPrice);

				if (!FAILED(hr) && ulCurrentPrice != 0)
				{
					//ulCurrentPrice = ord->m_Order.Price;
					currentPrice = ulCurrentPrice / pow(10.0, (int)digits);

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Initial MArgin = %lu, CurrentPrice = %lf", (ULONG)initialMargin, currentPrice);
				}
				else
				{
					nSuccess = ERR_INTERNAL_ERROR;
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Not able to get latest price");
				}
			}
			else if (ord->m_Order.OrderType == ORDER_TYPE_LIMIT_ORDER || ord->m_Order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
			{
				currentPrice = ord->m_Order.Price / pow(10.0, (int)digits);
			}
			else if (ord->m_Order.OrderType == ORDER_TYPE_STOP_ORDER)
			{
				currentPrice = ord->m_Order.StopPx / pow(10.0, (int)digits);
			}

			if (nSuccess == 0)
			{
				double lfInitialMargin = initialMargin; 

				double CostRequired = m_pRMSCalc->CalculateUsedMargin(Qty, currentPrice, m_nLeverage,initialMargin, ord->m_Order.Symbol, ord->m_Order.Side);

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Before Cost Required = %lf, Leverage=%d, Balance=%lf, used Margin=%lf", CostRequired, m_nLeverage, m_Balance, m_lfUsedMargin);

				double lfCalcTax = 0;
				double lfCalcFees = 0;

				CalculateCommAndTax(lfFees, lfTax, lfCalcFees, lfCalcTax, currentPrice);
				ord->m_lfUsedMargin = CostRequired;

				lfCalcFees *= ord->m_Order.OrderQty;
				lfCalcTax *= ord->m_Order.OrderQty;

				ord->m_lfCommission = lfCalcFees;
				ord->m_lfTax = lfCalcTax;

				double lfEquity = m_Balance + m_OpenPnL;
				double lfFreeMargin = lfEquity - m_lfUsedMargin;

				if (CostRequired != 0)
				{
					if (CostRequired + lfCalcTax + lfCalcFees <= lfFreeMargin)
					{
						// Update Reserved Margin
						m_lfUsedMargin += CostRequired;
						//m_Balance -= CostRequired;

						m_bAccountChanged = true;
					}
					else
					{
						// Insufficient fund
						nSuccess = ERR_INSUFFICIENT_MARGIN;
					}
				}
				//double CostRequired = m_pRMSCalc->CalculateUsedMargin(Qty, currentPrice, m_nLeverage, initialMargin, ord->m_Order.Symbol, ord->m_Order.Side);
				//double FullUsedMargin = m_pRMSCalc->CalculateUsedMargin(ord->m_Order.OrderQty, currentPrice, m_nLeverage, initialMargin, ord->m_Order.Symbol, ord->m_Order.Side);
				//
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Before Cost Required = %lf, Leverage=%d, Balance=%lf, used Margin=%lf", CostRequired, m_nLeverage, m_Balance, m_lfUsedMargin);

				//ord->m_lfUsedMargin = FullUsedMargin;

				//double lfUsedMargin = m_lfUsedMargin;
				//double lfOpenPnL = 0;
				//double lfEquity = m_Balance + m_OpenPnL;

				///*ord->QtyClose;
				//Qty;*/

				//double ulOverAllUsedMarginForPosition = pPosition->GetOverAllUsedMargin();
				//double ulSellUsedMarginForPosition = pPosition->GetSellUsedMargin();
				//double ulBuyUsedMarginForPosition = pPosition->GetBuyUsedMargin();

				//double overallMargin = 0;
				//unsigned long qtyOpen = 0;

				//qtyOpen = ord->m_Order.OrderQty - ord->QtyClose;

				//if (ord->QtyClose != 0)
				//{
				//	lfUsedMargin = m_lfUsedMargin - (ulOverAllUsedMarginForPosition);
				//	//CostRequired = 0;
				//}

				//if (qtyOpen != 0)
				//{
				//}

				//double lfFreeMargin = lfEquity - lfUsedMargin;

				//if (CostRequired <= lfFreeMargin)
				//{
				//	//lfUsedMargin += CostRequired;
				//	//m_lfUsedMargin = lfUsedMargin + CostRequired;

				//	double adjustment = 0;
				//	// Update the used margins in the position
				//	pPosition->UpdateUsedMargins(ord->m_Order.Side, FullUsedMargin, overallMargin, adjustment);
				//	m_lfUsedMargin += adjustment;

				//	m_bAccountChanged = true;
				//}
				//else
				//{
				//	// Insufficient fund
				//	nSuccess = ERR_INSUFFICIENT_MARGIN;
				//}

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, After Cost Required = %lf, Leverage=%d, Balance=%lf, used Margin=%lf", CostRequired, m_nLeverage, m_Balance, m_lfUsedMargin);
			}
		}
		else
		{
			nSuccess = ERR_INTERNAL_ERROR;	
			_com_error error(hr);
			LPCTSTR errorText = error.ErrorMessage();

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CheckMargin, Error in Contract Manager. %s", errorText);
		}
	}

	return nSuccess;
}

int ITBothUMHedgeAccount::ProcessExecutionReport(ExecutionReport *pReport, 
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
                    IGlobalPosition *pGlobalPos)
{
	int nSuccess = 0;

	ORDID_IORDER_MAP::iterator iter = m_lstWorkingOrders.find(pReport->ClOrdId);

	if (iter != m_lstWorkingOrders.end())
	{
		pOrder = (*iter).second;
		pOrder->m_Order.OrderID = pReport->OrderID;
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Order Not found. FATAL");
		nSuccess = ERR_INTERNAL_ERROR;
	}

	unsigned long OpenQty = 0;
	IPosition *pPosition =NULL;

	if (nSuccess == ERR_OK)
	{
		if (m_bRMSEnable)
		{
			pPosition = GetPositionObject(pOrder);

			if (pPosition)
			{
				memcpy(pReport->LinkedOrdID, pOrder->m_Order.LnkdOrdId, sizeof(pOrder->m_Order.LnkdOrdId));
				pReport->PositionEffect = pOrder->m_Order.PositionEffect;

				if (pReport->OrderStatus == ORDER_STATUS_FILLED || pReport->OrderStatus == ORDER_STATUS_PARTIALLY_FILLED)
				{
					double lfProfit = 0;
					double lfUsedMargin = 0;

					TriggerLinkedOrders(pReport->ClOrdId, pConnMgr);
					HandleOCOOrder(pReport->ClOrdId, pOrder->m_Order.LnkdOrdId, pConnMgr);

					unsigned long initialSellMargin = 0;
					unsigned long initialBuyMargin = 0;
					unsigned long ulContractSize = 0;
					unsigned long digits = 0;

					CComBSTR str(pPosition->m_Symbol.Product);
					CComBSTR strContract(pPosition->m_Symbol.Contract);
					CComBSTR strGateway(pPosition->m_Symbol.Gateway);

					BSTR bstrProduct, bstrContract, bstrGateway;

					bstrProduct = str.Detach();
					bstrContract = strContract.Detach();
					bstrGateway = strGateway.Detach();
					
					HRESULT hr = pContractManager->GetSymbolParameters(pPosition->m_Symbol.ProductType,
																		bstrProduct,
																		bstrContract,
																		bstrGateway,
																		&initialSellMargin,
																		&initialBuyMargin,
																		&ulContractSize,
																		&digits);


					if (!FAILED(hr))
					{
						//pPosition->UpdatePositionStats(pReport->Side, pReport->QtyFilled, pOrder->m_Order.PositionEffect, pReport->LastPx, pOrder->QtyClose, lfProfit);

						nSuccess = pPosition->UpdatePosition(pOrder, pReport, lfProfit, lfUsedMargin, ulContractSize, lstOrdersToUpdate, pGlobalPos);

						if (nSuccess == 0)
						{
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::ProcessExecutionReport, Account Used Margin = %lf, Order Used Margin = %lf, Profit = %lf, Balance = %lf, Order ID = %s", m_lfUsedMargin, lfUsedMargin, m_Balance, lfProfit, pOrder->m_Order.ClOrdId);

							double lfCalcFees = 0;
							double lfCalcTax = 0;
							double lfCurrentPrice = pReport->LastPx / pow(10.0, (int)digits);

							CalculateCommAndTax(lfFees, lfTax, lfCalcFees, lfCalcTax, lfCurrentPrice);

							// See if the previous charges were more or less and adjust accordingly
							double lfTotalCharges = (lfCalcFees + lfCalcTax) * pReport->QtyFilled;
							double lfPrevCharges = pOrder->m_lfCommission + pOrder->m_lfTax;

							m_Balance -= lfTotalCharges;

							pReport->Commission =  pOrder->m_lfCommission = lfCalcFees * pReport->QtyFilled;
							pReport->Tax = pOrder->m_lfTax = lfCalcTax * pReport->QtyFilled;

							// We may need tiply with the contract size here.
							lfProfit /= pow(10.0, (int)digits);
							m_Balance += lfProfit;
							pReport->Profit = lfProfit;
							pOrder->m_lfProfit += lfProfit;

							m_lfUsedMargin -= lfUsedMargin;

							// Add to turnovers
							if (pReport->Side == SIDE_BUY)
								m_lfBuyTurnover += pReport->LastPx * pReport->QtyFilled;
							else
								m_lfSellTurnover += pReport->LastPx * pReport->QtyFilled;

							m_bAccountChanged = true;
						}

						// If the position has changed the position is sent back.
						bPositionChanged = pPosition->GetPositionResponse(pResponsePosition);
					}
				}
			}
		}

		// Revert the used margin and remove the order from the working list
		if (pReport->OrderStatus == ORDER_STATUS_CANCEL ||
			pReport->OrderStatus == ORDER_STATUS_REJECTED ||
			pReport->OrderStatus == ORDER_STATUS_EXPIRED ||
			pReport->OrderStatus == ORDER_STATUS_FILLED || 
			pReport->OrderStatus == ORDER_STATUS_PARTIALLY_FILLED)
		{
			if (pReport->OrderStatus != ORDER_STATUS_FILLED && pReport->OrderStatus != ORDER_STATUS_PARTIALLY_FILLED)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::ProcessExecutionReport 1, Account Used Margin = %lf, Order Used Margin = %lf, Balance = %lf, Order ID = %s", m_lfUsedMargin, pOrder->m_lfUsedMargin, m_Balance, pOrder->m_Order.ClOrdId);
				
				double lfPrevCharges = pOrder->m_lfCommission + pOrder->m_lfTax;

				m_lfUsedMargin -= (pOrder->m_lfUsedMargin /(double) (pOrder->m_Order.OrderQty - pOrder->QtyClose)) * (pOrder->m_Order.OrderQty - pOrder->CumQty);
				//m_lfUsedMargin -= pOrder->m_lfUsedMargin;

				if (pOrder->QtyClose > 0)
					pPosition->ResetPosition(pOrder->QtyClose, pOrder->m_Order.Side);

				m_bAccountChanged = true;
			}

			if (pOrder->CumQty + pReport->QtyFilled == pOrder->m_Order.OrderQty)
			{
				m_lstWorkingOrders.erase(iter);
			}
		}
		else if (pReport->OrderStatus == ORDER_STATUS_NEW)
		{
			if (pOrder->m_Order.origClOrdId[0] != '\0')
			{
				ORDID_IORDER_MAP::iterator iter1 = m_lstWorkingOrders.find(pOrder->m_Order.origClOrdId);

				if (iter1 != m_lstWorkingOrders.end())
				{
					IOrder *pOrder1 = (*iter1).second;

					if (pOrder1)
					{
						ReplaceOCOOrder(pOrder->m_Order.origClOrdId, pOrder->m_Order.LnkdOrdId, pOrder);

						if (pOrder->m_lfUsedMargin < 0)
						{
							m_lfUsedMargin += pOrder->m_lfUsedMargin;

							pOrder->m_lfUsedMargin += pOrder1->m_lfUsedMargin;
							//pOrder->m_lfCommission += pOrder1->m_lfCommission;
							//pOrder->m_lfTax += pOrder1->m_lfTax;
						}
						else
						{
							pOrder->m_lfUsedMargin += pOrder1->m_lfUsedMargin;

							//pOrder->m_lfCommission += pOrder1->m_lfCommission;
							//pOrder->m_lfTax += pOrder1->m_lfTax;
						}

						m_bAccountChanged = true;
					}
				}
				else
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Order Not found. FATAL");
					nSuccess = ERR_INTERNAL_ERROR;
				}
			}
		}
		else if (pReport->OrderStatus == ORDER_STATUS_REPLACED)
			pReport->OrderStatus = ORDER_STATUS_CANCEL;
		
		if (m_bAccountChanged)
		{
			GetAccountUpdateMessage(pResponseAccount);
			bAccountChanged = true;
			m_bAccountChanged = false;
		}

		if (pPosition)
		{
			ulTempLongPos = pPosition->m_ulTempLongPos;
			ulTempShortPos = pPosition->m_ulTempShortPos;
		}
	}

	return nSuccess;
}

int ITBothUMHedgeAccount::ProcessCROrder(IOrder *ord, IOrder *pNewOrder, double fees, double tax, IContractManager *pContractManager)
{
	int nSuccess = 0;

	unsigned long ulMarginQty = 0;
	IPosition *ptrPosition = NULL;

	unsigned long ulTempLongPos = 0;
	unsigned long ulTempShortPos = 0;

	if (pNewOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
	{
		ptrPosition = GetPositionObject(pNewOrder);

		if (ptrPosition)
		{
			double lfUsedMarginForNewOrder = 0;
			double lfFeesForNewOrder = 0;
			double lfTaxForNewOrder = 0;

			unsigned long long ulCurrentPrice = 0;
			unsigned long long ulSize = 0;
			unsigned long digits = 2;
			unsigned long initialMargin = 5;

			CComBSTR str(ord->m_Order.Symbol.Product);
			CComBSTR strContract(ord->m_Order.Symbol.Contract);
			CComBSTR strGateway(ord->m_Order.Symbol.Gateway);

			BSTR bstrProduct, bstrContract, bstrGateway;

			bstrProduct = str.Detach();
			bstrContract = strContract.Detach();
			bstrGateway = strGateway.Detach();
			
			HRESULT hr = pContractManager->GetInitialMargin(pNewOrder->m_Order.Symbol.ProductType,
															bstrProduct,	
															bstrContract,
															bstrGateway,
															bstrGateway,
															pNewOrder->m_Order.Side,
															&initialMargin,
															&digits);


			if (!FAILED(hr))
			{
				lfUsedMarginForNewOrder = CalculateUsedMargin(pNewOrder, pNewOrder->m_Order.OrderQty, pContractManager);
				double lfCurrentPrice = pNewOrder->m_Order.Price / pow(10.0, (double)digits);
				CalculateCommAndTax(fees, tax, lfFeesForNewOrder, lfTaxForNewOrder, lfCurrentPrice); 

				pNewOrder->m_lfUsedMargin = lfUsedMarginForNewOrder;
				pNewOrder->m_lfUsedMargin -= ord->m_lfUsedMargin;

				pNewOrder->m_lfCommission = lfFeesForNewOrder * pNewOrder->m_Order.OrderQty;
				pNewOrder->m_lfTax = lfTaxForNewOrder * pNewOrder->m_Order.OrderQty;
			}


			double lfEquity = m_Balance + m_OpenPnL;
			double lfFreeMargin = lfEquity - m_lfUsedMargin;

			if (lfFreeMargin > pNewOrder->m_lfUsedMargin + pNewOrder->m_lfCommission + pNewOrder->m_lfTax - (ord->m_lfCommission + ord->m_lfTax))
			{
				if (pNewOrder->m_lfUsedMargin > 0)
				{
					m_lfUsedMargin += pNewOrder->m_lfUsedMargin;
				}
			}
			else
			{
				nSuccess = ERR_INSUFFICIENT_MARGIN;
			}

			ulTempLongPos = ptrPosition->m_ulTempLongPos;
			ulTempShortPos = ptrPosition->m_ulTempShortPos;
		}
		else
		{
			nSuccess = ERR_INTERNAL_ERROR;
		}
	}


	if (nSuccess != ERR_OK)
	{
		pNewOrder->OrderStatus = ORDER_STATUS_REJECTED;
	}

	if (pNewOrder->InsertOrder(m_Balance,
						   m_lfUsedMargin,
						   m_lfBuyTurnover,
						   m_lfSellTurnover,
						   0,
						   ulTempLongPos,
						   ulTempShortPos) != ERR_OK)
	{
		// Rollback the order and do not proceed
		pNewOrder->OrderStatus = ORDER_STATUS_REJECTED;
		//m_Balance += pNewOrder->m_lfUsedMargin;
		m_lfUsedMargin -= pNewOrder->m_lfUsedMargin;

		nSuccess = ERR_INTERNAL_ERROR_DB;

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessCROrder, Used Margin Rolled back.");
	}

	if (pNewOrder->OrderStatus != ORDER_STATUS_REJECTED)
	{
		//insert into Working order list
		if (m_lstWorkingOrders.find(pNewOrder->m_Order.ClOrdId) == m_lstWorkingOrders.end())
		{
			m_lstWorkingOrders.insert(std::pair<std::string, IOrder*>(pNewOrder->m_Order.ClOrdId, pNewOrder));
		}
	}

	return nSuccess;
}


double ITBothUMHedgeAccount::CalculateUsedMargin(IOrder *ord, unsigned long long Qty, IContractManager *pContractManager)
{
	double lfUsedMargin = 0;

	double currentPrice = 0;
	unsigned long long ulCurrentPrice = 0;
	unsigned long long ulSize = 0;
	unsigned long digits = 2;
	unsigned long initialMargin = 5;

	CComBSTR str(ord->m_Order.Symbol.Product);
	CComBSTR strContract(ord->m_Order.Symbol.Contract);
	CComBSTR strGateway(ord->m_Order.Symbol.Gateway);

	BSTR bstrProduct, bstrContract, bstrGateway;

	bstrProduct = str.Detach();
	bstrContract = strContract.Detach();
	bstrGateway = strGateway.Detach();
	
	HRESULT hr = pContractManager->GetInitialMargin(ord->m_Order.Symbol.ProductType,
													bstrProduct,	
													bstrContract,
													bstrGateway,
													bstrGateway,
													ord->m_Order.Side,
													&initialMargin,
													&digits);


	if (!FAILED(hr))
	{
		if (ord->m_Order.OrderType == ORDER_TYPE_MARKET_ORDER)
		{
			char type;

			/*if (ord->m_Order.Side == SIDE_BUY)
				type = QUOTES_STREAM_TYPE_ASK;
			else if (ord->m_Order.Side == SIDE_SELL)
				type = QUOTES_STREAM_TYPE_BID;*/

			type = QUOTES_STREAM_TYPE_LAST;

			hr = pContractManager->GetLatestPrice(type,
													bstrProduct,
													bstrContract,
													strGateway,
													strGateway,
													&ulSize,
													&ulCurrentPrice);

			if (!FAILED(hr) && ulCurrentPrice != 0)
			{
				//ulCurrentPrice = ord->m_Order.Price;
				currentPrice = ulCurrentPrice / pow(10.0, (int)digits);
			}
		}
		else if (ord->m_Order.OrderType == ORDER_TYPE_LIMIT_ORDER || ord->m_Order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER)
		{
			currentPrice = ord->m_Order.Price / pow(10.0, (int)digits);
		}
		else if (ord->m_Order.OrderType == ORDER_TYPE_STOP_ORDER)
		{
			currentPrice = ord->m_Order.StopPx / pow(10.0, (int)digits);
		}

		lfUsedMargin = m_pRMSCalc->CalculateUsedMargin(Qty, currentPrice, m_nLeverage, initialMargin, ord->m_Order.Symbol,ord->m_Order.Side);

		//initialMargin = 1;
		//lfUsedMargin = (initialMargin * ActualCost/ (m_nLeverage)) * GetCurrencyFactor(ord->m_Order.Symbol.Contract);
	}

	return lfUsedMargin;
}

int ITBothUMHedgeAccount::CalculatePnLAndLiquidate(IContractManager *pContractManager, IConnectionMgr *pConnMgr)
{
	int nSuccess = 0;
	unsigned long long ulBidPrice = 0;
	unsigned long long ulAskPrice = 0;
	//unsigned long long ulBidPrice = 0;
	//unsigned long long ulAskPrice = 0;
	unsigned long long ulLastPrice = 0;
	unsigned long initialBuyMargin = 0;
	unsigned long initialSellMargin = 0;
	unsigned long digits = 0;
	unsigned long long ulBidSize = 0;
	unsigned long long ulAskSize = 0;
	unsigned long long ulLastSize = 0;
	double lfBid = 0;
	double lfAsk = 0;
	char clOrdID[20];
	char clOrdIDFinal[20];
	double lfOpenPnL = 0;
	double lfAccountMaxLoss = 9999999;
	double lfMaxLoss = 0;
	symbol sym;
	IOrder *pOrder = NULL;
	IOrder *pOrder1 = NULL;
	double lfOpenPnl = 0;
	unsigned long ulBidPrice1 = 0;
	unsigned long ulAskPrice1 = 0;
	unsigned long ulContractSize = 0;


	AcquireLockAcc();

	m_OpenPnL = 0;

	SYMBOL_IPOSITION_MAP::iterator iter = m_PositionMap.begin();

	while (iter != m_PositionMap.end())
	{
		IPosition *pPosition = iter->second;

		if (pPosition)
		{
			CComBSTR str(pPosition->m_Symbol.Product);
			CComBSTR strContract(pPosition->m_Symbol.Contract);
			CComBSTR strGateway(pPosition->m_Symbol.Gateway);

			BSTR bstrProduct, bstrContract, bstrGateway;

			bstrProduct = str.Detach();
			bstrContract = strContract.Detach();
			bstrGateway = strGateway.Detach();

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgeAccount::CalculatePnLAndLiquidate, Account No = %lu",pPosition->m_Account);
			
			//char type;

			//HRESULT hr = pContractManager->GetInitialMargin(pPosition->m_Symbol.ProductType,
			//												bstrProduct,	
			//												bstrContract,
			//												bstrGateway,
			//												bstrGateway,
			//												SIDE_BUY,
			//												&initialMargin,
			//												&digits);

			HRESULT hr = pContractManager->GetSymbolParameters(pPosition->m_Symbol.ProductType,
																bstrProduct,
																bstrContract,
																bstrGateway,
																&initialSellMargin,
																&initialBuyMargin,
																&ulContractSize,
																&digits);
			if (!FAILED(hr))
			{
				//type = QUOTES_STREAM_TYPE_ASK;

				//hr = pContractManager->GetLatestPrice(type,
				//										bstrProduct,
				//										bstrContract,
				//										strGateway,
				//										strGateway,
				//										&ulSize,
				//										&ulAskPrice);

				hr = pContractManager->GetAllLatestPrice(pPosition->m_Symbol.ProductType,
														bstrProduct,
														bstrContract,
														strGateway,
														&ulBidSize,
														&ulBidPrice,
														&ulAskSize,
														&ulAskPrice,
														&ulLastSize,
														&ulLastPrice);
				if (!FAILED(hr))
				{
					/*type = QUOTES_STREAM_TYPE_BID;

					hr = pContractManager->GetLatestPrice(type,
															bstrProduct,
															bstrContract,
															strGateway,
															strGateway,
															&ulSize,
															&ulBidPrice);*/
					
					//if (!FAILED(hr))
					{
						// Got both bid and ask price
						lfBid = (double)ulBidPrice;
						lfAsk = (double)ulAskPrice;
						lfBid = (double)ulLastPrice;

						pOrder = NULL;

						if (ulBidPrice != 0 && ulAskPrice != 0)
						{
							 
							if (pPosition->CalculateOpenPnL(lfBid, lfAsk, clOrdID, lfMaxLoss, lfOpenPnl, ulContractSize, pOrder) == 0)
							{
								lfMaxLoss = (lfMaxLoss/ pow(10.0, (int)digits));
								lfOpenPnl = (lfOpenPnl/ pow(10.0, (int)digits));

								if (lfAccountMaxLoss > lfMaxLoss)
								{
									lfAccountMaxLoss = lfMaxLoss;
									memcpy(&sym, &pPosition->m_Symbol, sizeof(sym));
									strcpy(clOrdIDFinal, clOrdID);

									pOrder1 = pOrder;

									ulBidPrice1 = (unsigned long)ulBidPrice;
									ulAskPrice1 = (unsigned long)ulAskPrice;
								}

								m_OpenPnL += lfOpenPnl;

								// Print bid, ask, ltp,lfMaxLoss, lfOpenPnl, lfAccountMaxLoss, clOrdID, m_OpenPnL
								stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgeAccount::CalculatePnLAndLiquidate, bid = %lf, ask = %lf, ltp = %lf,lfMaxLoss = %lf, lfOpenPnl = %lf, lfAccountMaxLoss = %lf, clOrdID = %s, m_OpenPnL = %lf",
																							lfBid,
																							lfAsk,
																							lfBid,
																							lfMaxLoss,
																							lfOpenPnL,
																							lfAccountMaxLoss,
																							clOrdID,
																							m_OpenPnL);
							}
						}
						else
						{
							// Print CalculateOpenPnL returned non zero.
						}
					}
				}
			}
		}

		iter++;
	}

	// check liquidation logic
	double lfEquity = m_Balance + m_OpenPnL;
	if(m_lfUsedMargin!=0)
	{
		double lfMarginLevel = lfEquity / m_lfUsedMargin* 100;

		// Print m_Balance, m_OpenPnL, m_lfUsedMargin, lfEquity, lfMarginLevel, m_nMarginCall3
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CalculatePnLAndLiquidate, Balance = %lf, OpenPnL = %lf, UM = %lf,Equity = %lf, MArgin Level = %lf",
																	m_Balance,
																	m_OpenPnL,
																	m_lfUsedMargin,
																	lfEquity,
																	lfMarginLevel);


		if (lfMarginLevel < m_nMarginCall3)
		{
			// Liquidate
			
			LiquidateOrder(sym, pOrder1, pConnMgr, ulBidPrice1, ulAskPrice1);
		}
	}
	else stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITBothUMHedgeAccount::CalculatePnLAndLiquidate m_lfUsedMargin =0.000000");


	ReleaseLockAcc();

	return nSuccess;
}


int ITBothUMHedgeAccount::LiquidateOrder(symbol& sym, IOrder *pOrder, IConnectionMgr *pConnMgr, unsigned long ulBid, unsigned long ulAsk)
{
	int nSuccess = 0;

	if (!m_lstWorkingOrders.empty())
	{
		// Cancel a working order.
		ORDID_IORDER_MAP::iterator iter = m_lstWorkingOrders.begin();

		if (iter != m_lstWorkingOrders.end())
		{
			IOrder *pOrder = iter->second;

			if (pOrder && pOrder->m_Order.PositionEffect == POSITION_OPENING_TRADE)
			{
				// generate a cancel order
				OrderCancelRequest *pRequest = (OrderCancelRequest *)GetMessageObject(ORDER_CANCEL_REQUEST);

				if (pRequest)
				{
					// Sending cancel request for order no 
					memcpy(&pRequest->order, &pOrder->m_Order, sizeof(pRequest->order));

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgeAccount::LiquidateOrder, Sending Cacnel order request for Order ID = %s",pOrder->m_Order.ClOrdId);

					if (pConnMgr)
						pConnMgr->ProcessNextRequest(0, pRequest, ORDER_CANCEL_REQUEST);
				}
			}
		}
	}
	else
	{
		if (pOrder)
		{
			// Need to liquidate a position
			NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

			if (pRequest)
			{
				memcpy(&pRequest->order, &pOrder->m_Order, sizeof(pRequest->order));
				pRequest->order.Account = pOrder->m_Order.Account;
				strcpy(pRequest->order.LnkdOrdId, pOrder->m_Order.ClOrdId);
				pRequest->order.PositionEffect = POSITION_CLOSING_TRADE;
				pRequest->order.Side = (pOrder->m_Order.Side == SIDE_BUY) ? SIDE_SELL:SIDE_BUY;
				pRequest->order.OrderType = ORDER_TYPE_MARKET_ORDER;

				if (pRequest->order.Side == SIDE_BUY)
					pRequest->order.Price = ulAsk;
				else if (pRequest->order.Side == SIDE_SELL)
					pRequest->order.Price = ulBid;

				// Sending Close order request for order no
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITNonHedgeAccount::LiquidateOrder, Sending Close order request for Order ID = %s",pOrder->m_Order.ClOrdId);



				if (pConnMgr)
					pConnMgr->ProcessNextRequest(0, pRequest, NEW_ORDER_REQUEST);
			}
		}
	}


	return nSuccess;
}