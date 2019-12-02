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
#include "RMSAPI.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "xlogger.h"
#include <math.h>
#include <atlbase.h>
#include "UtilitiesAPI.h"
#include "IOrder.h"
#include "serverinterface.h"
#include "time.h"
#include <ATLCOMTime.h>
#include "RMsCalculator.h"
//#include "ITNonHedgeAccount.h"
//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "ITAccount"

ITAccount::ITAccount(unsigned int ulAccount,
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

	m_lfEquity = 0;
	m_pRMSCalc = NULL;
}

ITAccount::~ITAccount()
{
	ORDID_IORDER_MAP::iterator iter = m_lstWorkingOrders.begin();

	for (; iter != m_lstWorkingOrders.end(); iter++)
	{
		IOrder *pOrder = (*iter).second;

		delete pOrder;
		pOrder = NULL;
	}

	m_lstWorkingOrders.clear();

	SYMBOL_IPOSITION_MAP::iterator iter1 = m_PositionMap.begin();

	for (;iter1 != m_PositionMap.end(); iter1++)
	{
		IPosition *pPosition = (*iter1).second;

		delete pPosition;
		pPosition = NULL;
	}

	m_PositionMap.clear();

	DeleteCriticalSection(&m_cs);
}

IPosition *ITAccount::GetPositionObject(char *symbol)
{
	IPosition *pPosition = NULL;

	SYMBOL_IPOSITION_MAP::iterator iter = m_PositionMap.find(symbol);

	if (iter != m_PositionMap.end())
	{
		pPosition = (*iter).second;
	}
	else
	{
		// Create position object
		pPosition = CreatePositionObject(m_nHedgingType, m_pRMSCalc);

		if (pPosition)
		{
			pPosition->m_Account = m_Account;
			pPosition->m_Database = m_pDatabase;
			pPosition->m_pAccount = this;

			memcpy(&pPosition->m_Symbol, symbol, sizeof(pPosition->m_Symbol));
			std::pair<std::string, IPosition *> pr(symbol, pPosition);

			m_PositionMap.insert(pr);
		}
	}

	return pPosition;
}

IPosition *ITAccount::GetPositionObject(IOrder *pOrder)
{
	IPosition *pPosition = NULL;

	SYMBOL_IPOSITION_MAP::iterator iter = m_PositionMap.find(pOrder->m_Order.Symbol.Contract);

	if (iter != m_PositionMap.end())
	{
		pPosition = (*iter).second;
	}
	else
	{
		// Create position object
		pPosition = CreatePositionObject(m_nHedgingType, m_pRMSCalc);

		if (pPosition)
		{
			pPosition->m_Account = m_Account;
			pPosition->m_Database = m_pDatabase;
			pPosition->m_pAccount = this;

			memcpy(&pPosition->m_Symbol, &pOrder->m_Order.Symbol, sizeof(pOrder->m_Order.Symbol));
			std::pair<std::string, IPosition *> pr(pOrder->m_Order.Symbol.Contract, pPosition);

			m_PositionMap.insert(pr);
		}
	}

	return pPosition;
}


// Process the new order request
// The following checks are required
// 1. Margin requirement
// 2. Buy/Sell side turnover (Contract Specs)
// 3. Maximum Allowable position (Contract Specs)
// 4. Maximum order value

// Position status
// =1, No positions
// =2, Position, and orderQty < Position
// =3, position, and orderqty > Position
int ITAccount::ProcessNewOrder(IOrder *ord, double fees, double tax, IContractManager *pContractManager)
{
	int nSuccess = 0;
	bool bSplit = false;

	unsigned long ulMarginQty = 0;
	IPosition *ptrPosition = NULL;

	unsigned long ulTempLongPos = 0;
	unsigned long ulTempShortPos = 0;

	if (m_bRMSEnable)
	{
		ptrPosition = GetPositionObject(ord);

		if (ptrPosition)
		{
			CComBSTR str(ord->m_Order.Symbol.Product);
			CComBSTR strContract(ord->m_Order.Symbol.Contract);
			CComBSTR strGateway(ord->m_Order.Symbol.Gateway);
			unsigned long long pos = 0;
			long success = 0;

			ulMarginQty = ord->m_Order.OrderQty;

			success = ptrPosition->GetQtyToCheckForMargin(ulMarginQty, ord, m_bHedge);

			if (success == ERR_OK)
			{
				nSuccess = CheckMargin(ord, ulMarginQty, fees, tax, pContractManager, ptrPosition);
			}
			else
				nSuccess = success;

			if (success == 99)
			{
				bSplit = true;
				ord->m_Order.OrderQty -= ulMarginQty;
				nSuccess = ERR_OK;
			}
			else if (success == 999)
			{
				nSuccess = 999;
			}
		}
		else
		{
			nSuccess = ERR_INTERNAL_ERROR;
		}
	}

	if (nSuccess != ERR_OK)
	{
		ord->OrderStatus = ORDER_STATUS_REJECTED;
	}

	if (ord->InsertOrder(m_Balance, 
						 m_lfUsedMargin,
						 m_lfBuyTurnover,
						 m_lfSellTurnover,
						 0,
						 ulTempLongPos,
						 ulTempShortPos) != ERR_OK)
	{
		// Rollback the order and do not proceed
		ord->OrderStatus = ORDER_STATUS_REJECTED;
		//m_Balance += ord->m_lfUsedMargin;
		m_lfUsedMargin -= ord->m_lfUsedMargin;
		nSuccess = ERR_INTERNAL_ERROR_DB;

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessNewOrder, Used Margin Rolled back.");
	}
	else
	{
		// Update the Order list in Position Table
	}

	if (ord->OrderStatus != ORDER_STATUS_REJECTED)
	{
		//insert into Working order list
		if (m_lstWorkingOrders.find(ord->m_Order.ClOrdId) == m_lstWorkingOrders.end())
		{
			m_lstWorkingOrders.insert(std::pair<std::string, IOrder*>(ord->m_Order.ClOrdId, ord));
		}

		// Add to the OCO orders
		if (ord->m_Order.LnkdOrdId[0] != '\0')
		{
			AddOCOOrders(ord->m_Order.LnkdOrdId, ord);
		}
	}

	if (bSplit)
		nSuccess = 99;

	return nSuccess;
}

int ITAccount::GetWorkingOrder(IOrder *&pOrder, char *orderID)
{
	int nSuccess = ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_UNKNOWN_ORDER;

	if (orderID)
	{
		ORDID_IORDER_MAP::iterator iter = m_lstWorkingOrders.find(orderID);

		if (iter != m_lstWorkingOrders.end())
		{
			pOrder = (*iter).second;

			nSuccess = ERR_OK;
		}
	}

	return nSuccess;
}

// Process CR Order
// The following checks are required
// 1. Margin requirement
// 2. Buy/Sell side turnover (Contract Specs)
// 3. Maximum Allowable position (Contract Specs)
// 4. DPR Range
int ITAccount::ProcessCROrder(IOrder *ord, IOrder *pNewOrder, double fees, double tax, IContractManager *pContractManager)
{
	int nSuccess = 0;

	unsigned long ulMarginQty = 0;
	IPosition *ptrPosition = NULL;

	ptrPosition = GetPositionObject(pNewOrder);

	if (ptrPosition)
	{
		double lfUsedMarginForNewOrder = 0;

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

			pNewOrder->m_lfUsedMargin = lfUsedMarginForNewOrder;
			pNewOrder->m_lfUsedMargin -= ord->m_lfUsedMargin;
		}

		if (m_Balance > pNewOrder->m_lfUsedMargin)
		{
			if (pNewOrder->m_lfUsedMargin > 0)
			{
				m_lfUsedMargin += pNewOrder->m_lfUsedMargin;
				m_Balance -= pNewOrder->m_lfUsedMargin;
			}
		}
		else
		{
			nSuccess = ERR_INSUFFICIENT_MARGIN;
		}
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;
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
						   ptrPosition->m_ulTempLongPos,
						   ptrPosition->m_ulTempShortPos) != ERR_OK)
	{
		// Rollback the order and do not proceed
		pNewOrder->OrderStatus = ORDER_STATUS_REJECTED;
		m_Balance += pNewOrder->m_lfUsedMargin;
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

double ITAccount::CalculateUsedMargin(IOrder *ord, unsigned long long Qty, IContractManager *pContractManager)
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

		double ActualCost = Qty * currentPrice;

		lfUsedMargin = initialMargin * ActualCost/ (m_nLeverage * 100);
	}

	return lfUsedMargin;
}

// Checks if the margin is available or not.
int ITAccount::CheckMargin(IOrder *ord, unsigned long long Qty, double lfFees, double lfTax, IContractManager *pContractManager, IPosition *pPosition)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CheckMargin, Entered");
	
	int nSuccess = 0;

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

		/*	if (ord->m_Order.Side == SIDE_BUY)
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
				currentPrice = ulCurrentPrice / pow(10.0, (int)digits);

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CheckMargin, Initial MArgin = %lu, CurrentPrice = %lf", (ULONG)initialMargin, currentPrice);
			}
			else
			{
				nSuccess = ERR_INTERNAL_ERROR;
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
			double ActualCost = Qty * currentPrice;
			double lfInitialMargin = initialMargin; 

			double CostRequired = initialMargin * ActualCost/ (m_nLeverage * 100);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CheckMargin, Before Cost Required = %lf, Leverage=%d, Balance=%lf, used Margin=%lf", CostRequired, m_nLeverage, m_Balance, m_lfUsedMargin);

			ord->m_lfUsedMargin = CostRequired;

			if (m_bHedge)
			{
				// Hedging is enabled
				if (ord->m_Order.PositionEffect == POSITION_OPENING_TRADE)
				{
					
				}
				else
				{
					CostRequired = 0;
				}
			}

			if (m_Balance  > CostRequired)
			{
				// Update Reserved Margin
				m_lfUsedMargin += CostRequired;
				m_Balance -= CostRequired;

				m_bAccountChanged = true;
			}
			else
			{
				// Insufficient fund
				nSuccess = ERR_INSUFFICIENT_MARGIN;
			}

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CheckMargin, After Cost Required = %lf, Leverage=%d, Balance=%lf, used Margin=%lf", CostRequired, m_nLeverage, m_Balance, m_lfUsedMargin);
		}
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;	
		_com_error error(hr);
		LPCTSTR errorText = error.ErrorMessage();

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CheckMargin, Error in Contract Manager. %s", errorText);
	}

	return nSuccess;
}


//Execution Transaction type		Order Status		Execution Type				In Response to
//0 (new)					0 = New Order Ack	0 = New Order Ack			New Order						OMS
//0 (new)					4 = Cancel Ack		4 = Cancel Ack				Cancel Order					OMS
//0 (new)					5 = Modify Ack		5 = Modify Ack				CR order						OMS
//3 = Status				0 = New				I = Status Report			Order Status Request			OMS
//3 = Status				1 = Part Filled		I = Status Report			Order Status Request			OMS
//3 = Status				2 = Filled			I = Status Report			Order Status Request			OMS
//3 = Status				4 = Canceled		I = Status Report			Order Status Request			OMS
//3 = Status				5 = Replaced		I = Status Report			Order Status Request			OMS
//3 = Status				6 = Pending Cancel	I = Status Report			Order Status Request			OMS
//3 = Status				8 = Rejected		I = Status Report			Order Status Request			OMS
//3 = Status				A = Pending New		I = Status Report			Order Status Request			OMS
//3 = Status				C = Expired			I = Status Report			Order Status Request			OMS
//3 = Status				E = Pending Replace	I = Status Report			Order Status Request			OMS
//0 (new)					1= Part Filled		1 = Part Filled				Fill Response					LP
//0 (new)					2 = Filled			2 = Filled					Fill Response					LP
//0 (new)					4 = Canceled		4 = Cancel Ack				Cancel Response					LP
//0 (new)					C = Expired			C = Elimination Ack			Expired Response				LP
//0 (new)					8 = Rejected		8 = Reject Ack				Rejected Order for Cancel, new and CR	LP
//0 (new)					U = Undefined		8 = Reject Ack				Rejected Order for Cancel, new and CR	LP
//0 (new)					Y = Order Not found	8 = Reject Ack				Rejected Order for Cancel, new and CR	LP
// We will process this in different class
// the function is to generate Execution Report 
// Process Execution Report
// Following tasks to be performed in case of a Order fill
// 1. Manage balance
// In case of cancel order as well as Reject
// 1. Release Reserved margin
//int ITAccount::ProcessExecutionReport(ExecutionReport *pReport, 
//										IOrder *&pOrder, 
//										bool& bAccountChanged, 
//										bool& bPositionChanged,
//										void *&pResponseAccount,
//										void *&pResponsePosition,
//										unsigned long& ulTempLongPos,
//										unsigned long& ulTempShortPos,
//										void* lstOrdersToUpdate,
//										double& lfSellSideUM,
//										double& lfBuySideUM,
//										double& lfOverAllUM,
//										IDatabase *pDatabase, 
//										IContractManager *pContractManager,
//										IConnectionMgr *pConnMgr)
//{
//	int nSuccess = 0;
//
//	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Entered");
//
//	ORDID_IORDER_MAP::iterator iter = m_lstWorkingOrders.find(pReport->ClOrdId);
//
//	if (iter != m_lstWorkingOrders.end())
//	{
//		pOrder = (*iter).second;
//		pOrder->m_Order.OrderID = pReport->OrderID;
//	}
//	else
//	{
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Order Not found. FATAL");
//		nSuccess = ERR_INTERNAL_ERROR;
//	}
//
//	unsigned long OpenQty = 0;
//	IPosition *pPosition =NULL;
//
//	if (nSuccess == ERR_OK)
//	{
//		if (m_bRMSEnable)
//		{
//
//			//AcquireLock(&m_csPositionMap);
//			SYMBOL_IPOSITION_MAP::iterator Iter = m_PositionMap.find(pReport->Symbol.Contract);
//
//			if (Iter != m_PositionMap.end())
//			{
//				// found position
//				pPosition = (*Iter).second;
//			}
//			else
//			{
//				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Position is not created yet. FATAL Error.");
//			}
//
//			if (pPosition)
//			{
//				if (pReport->OrderStatus == ORDER_STATUS_FILLED || pReport->OrderStatus == ORDER_STATUS_PARTIALLY_FILLED)
//				{
//					double lfProfit = 0;
//					double lfUsedMargin = 0;
//
//					//if (pOrder->m_bLinkedOrder)
//					{
//						TriggerLinkedOrders(pReport->ClOrdId, pConnMgr);
//					}
//					//else if (pOrder->m_Order.OCOOrder)
//					{
//						HandleOCOOrder(pReport->ClOrdId, pOrder->m_Order.LnkdOrdId, pConnMgr);
//					}
//
//					pPosition->UpdatePositionStats(pReport->Side, pReport->QtyFilled, 'C', pReport->LastPx, pOrder->QtyClose, lfProfit);
//
//					nSuccess = pPosition->UpdatePosition(pOrder, pReport, lfProfit, lfUsedMargin, lstOrdersToUpdate);
//
//					if (nSuccess == 0)
//					{
//						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::ProcessExecutionReport, Account Used Margin = %lf, Order Used Margin = %lf, Profit = %lf, Balance = %lf, Order ID = %s", m_lfUsedMargin, lfUsedMargin, m_Balance, lfProfit, pOrder->m_Order.ClOrdId);
//
//						m_Balance += lfProfit + lfUsedMargin;
//						m_lfUsedMargin -= lfUsedMargin;
//
//						// Add to turnovers
//						if (pReport->Side == SIDE_BUY)
//							m_lfBuyTurnover += pReport->LastPx * pReport->QtyFilled;
//						else
//							m_lfSellTurnover += pReport->LastPx * pReport->QtyFilled;
//
//						m_bAccountChanged = true;
//					}
//
//					// If the position has changed the position is sent back.
//					bPositionChanged = pPosition->GetPositionResponse(pResponsePosition);
//				}
//			}
//		}
//
//		// Revert the used margin and remove the order from the working list
//		if (pReport->OrderStatus == ORDER_STATUS_CANCEL ||
//			pReport->OrderStatus == ORDER_STATUS_REJECTED ||
//			pReport->OrderStatus == ORDER_STATUS_EXPIRED ||
//			pReport->OrderStatus == ORDER_STATUS_FILLED)
//		{
//			if (pReport->OrderStatus != ORDER_STATUS_FILLED)
//			{
//				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::ProcessExecutionReport 1, Account Used Margin = %lf, Order Used Margin = %lf, Balance = %lf, Order ID = %s", m_lfUsedMargin, pOrder->m_lfUsedMargin, m_Balance, pOrder->m_Order.ClOrdId);
//				
//				m_Balance += pOrder->m_lfUsedMargin;
//				m_lfUsedMargin -= pOrder->m_lfUsedMargin;
//
//				if (pOrder->QtyClose > 0)
//					pPosition->ResetPosition(pOrder->QtyClose, pOrder->m_Order.Side);
//
//				m_bAccountChanged = true;
//			}
//
//			m_lstWorkingOrders.erase(iter);
//		}
//		else if (pReport->OrderStatus == ORDER_STATUS_NEW)
//		{
//			if (pOrder->m_Order.origClOrdId[0] != '\0')
//			{
//				ORDID_IORDER_MAP::iterator iter1 = m_lstWorkingOrders.find(pOrder->m_Order.origClOrdId);
//
//				if (iter1 != m_lstWorkingOrders.end())
//				{
//					IOrder *pOrder1 = (*iter1).second;
//
//					if (pOrder1)
//					{
//						if (pOrder->m_lfUsedMargin < 0)
//						{
//							m_lfUsedMargin += pOrder->m_lfUsedMargin;
//							m_Balance -= pOrder->m_lfUsedMargin;
//							pOrder->m_lfUsedMargin += pOrder1->m_lfUsedMargin;
//						}
//						else
//						{
//							pOrder->m_lfUsedMargin += pOrder1->m_lfUsedMargin;
//						}
//
//						m_bAccountChanged = true;
//					}
//				}
//				else
//				{
//					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::ProcessExecutionReport, Order Not found. FATAL");
//					nSuccess = ERR_INTERNAL_ERROR;
//				}
//			}
//		}
//		else if (pReport->OrderStatus == ORDER_STATUS_REPLACED)
//			pReport->OrderStatus = ORDER_STATUS_CANCEL;
//		
//		if (m_bAccountChanged)
//		{
//			GetAccountUpdateMessage(pResponseAccount);
//			bAccountChanged = true;
//			m_bAccountChanged = false;
//		}
//
//		if (pPosition)
//		{
//			ulTempLongPos = pPosition->m_ulTempLongPos;
//			ulTempShortPos = pPosition->m_ulTempShortPos;
//		}
//	}
//
//
//	return nSuccess;
//}

void ITAccount::UpdateAccount(unsigned int ulAccount,
					bool bRMSEnable,
					char *pLPName,
					double lfBalance,
					double lfOpenPnL,
					int nLeverage,
					int nGroup,
					double lfFreeMargin,
					double lfMargin,
					double lfUsedMargin,
					bool bHedge,
					bool bEnabletrade,
					double lfReservedMargin,
					double lfBuyTurnOver,
					double lfSellturnOver,
					int nMarginCall1,
					int nMarginCall2,
					int nMarginCall3,
					char *pszTraderName,
					char *pszAccountType,
					IDatabase *pDatabase,
					IDatabase *pDatabaseOMS)
{
	AcquireLockAcc();

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::UpdateAccount, Before Updating %s", ToString());

	m_bRMSEnable = bRMSEnable;
	m_strLPName = pLPName;
	m_Balance = lfBalance;
	m_OpenPnL = lfOpenPnL;
	m_nLeverage = nLeverage;
	m_lfUsedMargin = lfUsedMargin;
	m_bHedge = bHedge;
	m_nEnableTrade = bEnabletrade;
	m_lfBuyTurnover = lfBuyTurnOver;
	m_lfSellTurnover = lfSellturnOver;

	m_nMarginCall1 = nMarginCall1;
	m_nMarginCall2 = nMarginCall2;
	m_nMarginCall3 = nMarginCall3;

	m_StopOut = m_nMarginCall3;

	if (m_strAccountType.compare("MM") == 0)
	{
		m_bMMAccount = true;
	}
	else
		m_bMMAccount = false;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITAccount::UpdateAccount, After Updating %s", ToString());

	ReleaseLockAcc();
}


void ITAccount::Init(unsigned int ulAccount,
						bool bRMSEnable,
						char *pLPName,
						double lfBalance,
						double lfOpenPnL,
						int nLeverage,
						int nGroup,
						double lfFreeMargin,
						double lfMargin,
						double lfUsedMargin,
						bool bHedge,
						bool bEnabletrade,
						double lfDayRealizedProfit,
						double lfBuyTurnOver,
						double lfSellturnOver,
						int nMarginCall1,
						int nMarginCall2,
						int nMarginCall3,
						char *pszTraderName,
						char *pszAccountType,
						int nHedgeType,
						double lfLotSize,
						IDatabase *pDatabase,
						IDatabase *pDatabaseOMS,
						RMSCalculatorFactory *pCalcFactory)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::Init, Entered");

	m_Account = ulAccount;
	m_bRMSEnable = bRMSEnable;
	m_strLPName = pLPName;
	m_Balance = lfBalance;
	m_OpenPnL = lfOpenPnL;
	m_nLeverage = nLeverage;
	m_nGroup = nGroup;
	m_lfUsedMargin = lfUsedMargin;
	m_bHedge = bHedge;
	m_nEnableTrade = bEnabletrade;
	m_lfBuyTurnover = lfBuyTurnOver;
	m_lfSellTurnover = lfSellturnOver;
	m_bAccountChanged = false;
	m_pDatabaseBO = pDatabase;
	m_pDatabase = pDatabaseOMS;
	m_nMarginCall1 = nMarginCall1;
	m_nMarginCall2 = nMarginCall2;
	m_nMarginCall3 = nMarginCall3;

	m_StopOut = m_nMarginCall3;

	m_strTraderName = pszTraderName;
	m_strAccountType = pszAccountType;

	m_nHedgingType = nHedgeType;
	m_lfLotSize = lfLotSize;
	m_OpenPnL = 0;
	
	m_pRMSCalc = pCalcFactory;

	if (m_strAccountType.compare("MM") == 0)
	{
		m_bMMAccount = true;
	}
	else
		m_bMMAccount = false;

	InitializeCriticalSection(&m_cs);
	InitializeCriticalSection(&m_csSession);

	LoadPositions();
}

std::string ITAccount::ToString()
{
	std::string strLogMsg = "";

	//EnterCriticalSection(&m_cs);

	char szMsg[4000];
	sprintf(szMsg, "Account=%lu, Balance=%lf, Levearage=%d, UsedMargin=%lf, EnableTrade=%d, BuyTurnOver=%lf, SellTurnOver=%lf",
						this->m_Account,
						this->m_Balance,
						this->m_lfUsedMargin,
						this->m_nEnableTrade,
						this->m_lfBuyTurnover,
						this->m_lfSellTurnover);		


	strLogMsg = szMsg;		 

	//ReleaseLock(&m_cs);

	return strLogMsg;
}

int ITAccount::GetAccountUpdateMessage(void*& pResponse)
{
	int nSuccess = 0;

	//EnterCriticalSection(&m_cs);

	ParticipantListResponse *pAccountResponse = (ParticipantListResponse *)GetMessageObject(PARTICIPANT_LIST_RESPONSE);

	if (pAccountResponse)
	{
		pAccountResponse->NoOfParticipants = 1;

		pAccountResponse->Header.KeyDataCtrlBlk = 1;
		pAccountResponse->AccountInfo[0].Account = m_Account;
		pAccountResponse->AccountInfo[0].Leverage = m_nLeverage;
		pAccountResponse->AccountInfo[0].Balance = m_Balance;
		pAccountResponse->AccountInfo[0].BuySideTurnOver = m_lfBuyTurnover;
		pAccountResponse->AccountInfo[0].SellSideturnOver = m_lfSellTurnover;
		pAccountResponse->AccountInfo[0].UsedMargin = m_lfUsedMargin;
		strcpy(pAccountResponse->AccountInfo[0].AccountType, m_strAccountType.c_str());
		strcpy(pAccountResponse->AccountInfo[0].TraderName, m_strTraderName.c_str());
		pAccountResponse->AccountInfo[0].MarginCall1 = m_nMarginCall1;
		pAccountResponse->AccountInfo[0].MarginCall2 = m_nMarginCall2;
		pAccountResponse->AccountInfo[0].MarginCall3 = m_nMarginCall3;
		pAccountResponse->AccountInfo[0].FreeMargin = 0;
		pAccountResponse->AccountInfo[0].ReservedMargin = 0;
		pAccountResponse->AccountInfo[0].Active = m_nEnableTrade;
		pAccountResponse->AccountInfo[0].Group = 0;
		pAccountResponse->AccountInfo[0].HedgingType = m_nHedgingType;
		pAccountResponse->AccountInfo[0].Margin = 0;
		pAccountResponse->AccountInfo[0].LotSize = m_lfLotSize;

		pResponse = (void *)pAccountResponse;
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::GetAccountUpdateMessage, Not able to allocate memory for AccountResponse");
	}

	//ReleaseLock(&m_cs);

	return nSuccess;
}


void ITAccount::AcquireLockAcc()
{
	AcquireLock(&m_cs);
}

void ITAccount::ReleaseLockAcc()
{
	ReleaseLock(&m_cs);
}

//int ITAccount::UpdateAccount()
//{
//	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::UpdateAccount, Entered");
//
//	int nSuccess = 0;
//
//	ITable* tb=CreateTable();
//	IParameter* param=CreateParameter();
//
//	param->AddParam("AccountID", m_Account);
//	param->AddParam("Balance", m_Balance);
//	param->AddParam("UsedMargin", m_lfUsedMargin);
//	param->AddParam("DayBuySideTurnOver", m_lfBuyTurnover);
//	param->AddParam("DaySellSideTurnOver", m_lfSellTurnover);
//	param->AddParam("DayRealizedProfit", m_lfDayRealizedProfit);
//	//param->AddParam("Success", nSuccess, 2);
//	
//	bool isSPExist = m_pDatabaseBO->Execute("RMS_UpdateAccountDetails",*tb,*param);//execute sp
//	if( !isSPExist )
//	{
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::UpdateAccount, Unable to execute SP RMS_UpdateAccountDetails");
//		//ReleaseLock(&m_cs);
//		nSuccess = ERR_INTERNAL_ERROR_DB;
//	}
//
//	ReleaseTable(tb);//release table object
//	ReleaseParameter(param);//release parameter object
//
//
//	return nSuccess;
//}

int ITAccount::LoadPositions()
{
	int nSuccess = 0;

	//ITable* tb=CreateTable();
	//IParameter* param=CreateParameter();
	//param->AddParam("AccountID",(unsigned int)this->m_Account);
	//
	//bool isSPExist = m_pDatabase->Execute("OMS_GetPositionInfoByAccountID",*tb,*param);//execute sp
	//if( !isSPExist )
	//{
	//	nSuccess = ERR_INTERNAL_ERROR_DB;
	//}	

	//if (nSuccess == ERR_OK)
	//{
	//	char productType[10];
	//	int count = 0;

	//	char contractName[20];
	//	IPosition *pPosition = NULL;

	//	while (!tb->IsEOF())
	//	{
	//		pPosition = CreatePositionObject(m_nHedgingType, m_pRMSCalc);

	//		if (pPosition)
	//		{
	//			pPosition->Init(m_pDatabase, this, "", tb);
	//			tb->Get("ContractName", contractName, sizeof(contractName));

	//			if (m_PositionMap.find(contractName) == m_PositionMap.end())
	//			{
	//				
	//				m_PositionMap.insert(std::pair<std::string, IPosition*>(contractName,pPosition));
	//			}

	//			tb->MoveNext();
	//		}
	//	}
	//}
	//ReleaseTable(tb);//release table object
	//ReleaseParameter(param);release parameter object

	return nSuccess;
}

int ITAccount::LoadOpenPosOrder(IOrder *pOrder)
{
	int nSuccess = 0;

	IPosition *ptrPosition = NULL;

	ptrPosition = GetPositionObject(pOrder);

	if (ptrPosition)
	{
		ptrPosition->LoadOpenPosOrder(pOrder);
	}

	return nSuccess;
}

int ITAccount::LoadWorkingOrder(IOrder *pOrder)
{
	int nSuccess = 0;

	if (m_lstWorkingOrders.find(pOrder->m_Order.ClOrdId) == m_lstWorkingOrders.end())
	{
		m_lstWorkingOrders.insert(std::pair<std::string, IOrder*>(pOrder->m_Order.ClOrdId, pOrder));

		if (pOrder->m_Order.LnkdOrdId[0] != '\0')
			AddOCOOrders(pOrder->m_Order.LnkdOrdId, pOrder);
	}

	if (pOrder->m_Order.LnkdOrdId[0] != '\0')
	{
		AddOCOOrders(pOrder->m_Order.LnkdOrdId, pOrder);
	}

	return nSuccess;
}

std::string& ITAccount::GetAssociatedLPName()
{
	return m_strLPName;
}

bool ITAccount::IsRMSEnabled()
{
	return m_bRMSEnable;
}

int ITAccount::CalculatePnLAndLiquidate(IContractManager *pContractManager, IConnectionMgr *pConnMgr)
{
	int nSuccess = 0;

	//AcquireLockAcc();

	////m_StopOut = 100;

	//SYMBOL_IPOSITION_MAP::iterator iter;
	//double KeptMargin = 0;
	//double TradeMargin = 0;
	//double OpenPnL = 0;
	//double currentPriceBID = 0;
	//double currentPriceASK = 0;


	//for (iter = m_PositionMap.begin();iter != m_PositionMap.end(); iter++)
	//{
	//	IPosition *pPosition = (*iter).second;
	//	
	//	if (pPosition)
	//	{
	//		//std::string symbol1 = pPosition->m_Symbol.Contract;

	//		unsigned long long ulCurrentPrice = 0;
	//		unsigned long long ulSize = 0;
	//		unsigned long digits = 2;
	//		unsigned long initialMargin = 5;

	//		std::string strProduct1 = "GSIU2";
	//		std::string strGateway1 = "OEC";
	//		std::string strProduct = "GSI";

	//		CComBSTR str(strProduct1.c_str());
	//		CComBSTR strContract(pPosition->m_Symbol.Contract);
	//		CComBSTR strGateway(strGateway1.c_str());

	//		BSTR bstrProduct, bstrContract, bstrGateway;

	//		bstrProduct = str.Detach();
	//		bstrContract = strContract.Detach();
	//		bstrGateway = strGateway.Detach();
	//		
	//		HRESULT hr = pContractManager->GetInitialMargin('0',
	//														bstrProduct,	
	//														bstrContract,
	//														strGateway,
	//														strGateway,
	//														SIDE_BUY,
	//														&initialMargin,
	//														&digits);


	//		if (!FAILED(hr))
	//		{
	//				hr = pContractManager->GetLatestPrice(QUOTES_STREAM_TYPE_BID,
	//														bstrProduct,
	//														bstrContract,
	//														strGateway,
	//														strGateway,
	//														&ulSize,
	//														&ulCurrentPrice);

	//				if (!FAILED(hr) /*&& ulCurrentPrice != 0*/)
	//				{
	//					currentPriceBID = ulCurrentPrice/* / pow(10.0, (int)digits)*/;

	//					hr = pContractManager->GetLatestPrice(QUOTES_STREAM_TYPE_ASK,
	//															bstrProduct,
	//															bstrContract,
	//															strGateway,
	//															strGateway,
	//															&ulSize,
	//															&ulCurrentPrice);

	//					if (!FAILED(hr) /*&& ulCurrentPrice != 0*/)
	//					{
	//						currentPriceASK = ulCurrentPrice/* / pow(10.0, (int)digits)*/;

	//						bool bSessionClosed = false;
	//						double tMargin = 0;
	//						unsigned long xx  = 0;
	//						char side;

	//						double pnl = pPosition->CalculateOpenPnL(currentPriceBID, currentPriceASK, bSessionClosed, tMargin, xx, side, m_nLeverage);
	//						pnl /= pow(10.0, (int)digits);
	//						tMargin /= pow(10.0, (int)digits);
	//						
	//						if (!bSessionClosed)
	//						{
	//							TradeMargin += tMargin;
	//						}
	//						
	//						OpenPnL += pnl;
	//					}
	//				}
	//				else
	//				{
	//					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CalculatePnLAndLiquidate, Not able to get latest price");
	//				}
	//		}

	//	}
	//}

	//KeptMargin = m_lfUsedMargin - TradeMargin;

	//double StopOutInVal = KeptMargin + (m_StopOut * TradeMargin /100);

	//double equity = m_Balance + m_lfUsedMargin + OpenPnL;

	//if (equity <= StopOutInVal)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CalculatePnLAndLiquidate, equity <= StopOutInVal Liquidate");
	//	// Liquidate
	//	for (iter = m_PositionMap.begin();iter != m_PositionMap.end(); iter++)
	//	{
	//		IPosition *pPosition = (*iter).second;
	//		
	//		if (pPosition)		
	//		{
	//			double tMargin = 0;
	//			bool bSessionClosed = false;
	//			unsigned long xx  = 0;
	//			char side;
	//			double pnl = pPosition->CalculateOpenPnL(currentPriceBID, currentPriceASK, bSessionClosed, tMargin, xx,side, m_nLeverage);

	//			if (!bSessionClosed && pnl)
	//			{
	//				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::CalculatePnLAndLiquidate, Liquidate order for contract %s", pPosition->m_Symbol.Contract);
	//				LiquidateOrder(pPosition->m_Symbol, 0, xx, side, pConnMgr);
	//				equity += pnl;

	//				if (equity > StopOutInVal)
	//					break;
	//			}
	//		}
	//	}
	//}

	//ReleaseLockAcc();

	return nSuccess;
}

//int ITAccount::LiquidateOrder(symbol& sym, unsigned long long price, unsigned long long Qty, char side, IConnectionMgr *pConnMgr)
//{
//	int nSuccess = 0;
//
//	NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);
//
//	if (pRequest)
//	{
//		pRequest->order.Account = m_Account;
//		strcpy(pRequest->order.ClOrdId, "1");
//		pRequest->order.OrderID = 1;
//		pRequest->order.OrderQty = Qty;
//		pRequest->order.OrderType = ORDER_TYPE_MARKET_ORDER;
//		pRequest->order.Price = price;
//		pRequest->order.Side = side;
//		pRequest->order.StopPx = 0;
//		pRequest->order.TransactTime = COleDateTime::GetCurrentTime();
//		pRequest->order.MinOrDisclosedQty = 0;
//		pRequest->order.ExpireDate = 41114.851059027780;
//		strcpy(pRequest->order.origClOrdId, "");
//
//		memcpy((void *)&pRequest->order.Symbol, (void *)&sym, sizeof(symbol));
//		
//		pRequest->order.TimeInForce = TIF_DAY;
//
//		pConnMgr->ProcessNextRequest(0, (void *)pRequest, NEW_ORDER_REQUEST);
//	}
//
//	return nSuccess;
//}
//
void ITAccount::SetConnectionMgr(IConnectionMgr *pConnMgr)
{
	m_ConnMgr = pConnMgr;
}

int ITAccount::AddSession(IClientSession *pSession)
{
	int nSuccess = 0;
	
	EnterCriticalSection(&m_csSession);

	m_lstSession.push_back(pSession);

	LeaveCriticalSection(&m_csSession);

	return nSuccess;
}

int ITAccount::RemoveSession(IClientSession *pSession)
{
	int nSuccess = 0;
	
	EnterCriticalSection(&m_csSession);

	m_lstSession.remove(pSession);

	if (m_lstSession.empty() && m_lstWorkingOrders.empty())
	{
		// this means this account can be unloaded. When we do liquidation logic,
		// we may need to consider the accounts with open position too.
		nSuccess = -1;
	}

	LeaveCriticalSection(&m_csSession);

	return nSuccess;
}


std::list<IClientSession *>& ITAccount::GetSessionList()
{
	return m_lstSession;
}

void ITAccount::AcquireSessionCS()
{
	EnterCriticalSection(&m_csSession);
}

void ITAccount::ReleaseSessionCS()
{
	LeaveCriticalSection(&m_csSession);
}
int ITAccount::AddLinkedOrder(char *pszClOrdID, IOrder *pOrder)
{
	int nSuccess = ERR_OK;

	std::map<std::string, std::list<IOrder *>>::iterator iter = m_mapLinkedOrders.find(pszClOrdID);
	memcpy(pOrder->m_Order.LnkdOrdId, pszClOrdID, sizeof(pOrder->m_Order.ClOrdId));

	pOrder->InsertLinkedOrder(pszClOrdID);

	if (iter != m_mapLinkedOrders.end())
	{
		std::list<IOrder *>& lstOrders = iter->second;

		lstOrders.push_back(pOrder);
	}
	else
	{
		std::list<IOrder *> lstOrders;
		lstOrders.push_back(pOrder);

		std::pair<std::string, std::list<IOrder *>> pr(pszClOrdID, lstOrders);
		m_mapLinkedOrders.insert(pr);
	}

	return nSuccess;
}



int ITAccount::AddLinkedOrders(char *pszClOrdID, IOrder *pOrder1, IOrder *pOrder2)
{
	int nSuccess = ERR_OK;

	std::list<IOrder *> lstOrders;

	pOrder1->InsertLinkedOrder(pszClOrdID);
	pOrder2->InsertLinkedOrder(pszClOrdID);

	memcpy(pOrder1->m_Order.LnkdOrdId, pszClOrdID, sizeof(pOrder1->m_Order.ClOrdId));
	memcpy(pOrder2->m_Order.LnkdOrdId, pszClOrdID, sizeof(pOrder1->m_Order.ClOrdId));

	lstOrders.push_back(pOrder1);
	lstOrders.push_back(pOrder2);

	std::pair<std::string, std::list<IOrder *>> pr(pszClOrdID, lstOrders);
	m_mapLinkedOrders.insert(pr);

	return nSuccess;
}

int ITAccount::AddOCOOrders(char *pszClOrdID, IOrder *pOrder)
{
	int nSuccess = ERR_OK;

	std::map<std::string, ORDERID_OCO_ORDER_MAP>::iterator iter = m_mapOCOOrders.find(pszClOrdID);

	if (iter != m_mapOCOOrders.end())
	{
		ORDERID_OCO_ORDER_MAP& mapOCO = (*iter).second;

		ORDERID_OCO_ORDER_MAP::iterator iter1 = mapOCO.find(pOrder->m_Order.ClOrdId);

		if (iter1 == mapOCO.end())
		{
			std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
			mapOCO.insert(pr);
		}
	}
	else
	{
		// If the primary order is nopt found
		std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
		ORDERID_OCO_ORDER_MAP mapOCO;

		mapOCO.insert(pr);

		std::pair<std::string, ORDERID_OCO_ORDER_MAP> pr1(pszClOrdID, mapOCO);
		m_mapOCOOrders.insert(pr1);
	}

	return nSuccess;
}

int ITAccount::DeleteLinkedOrders(char *pszClOrdID)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			param->AddParam("OrderID", pszClOrdID, 20);

			bool isSPExist = m_pDatabase->Execute("OMS_DeleteLinkedOrders",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::DeleteLinkedOrders, Unable to execute SP OMS_DeleteLinkedOrders");
				nSuccess = ERR_INTERNAL_ERROR;
			}
		}

		ReleaseParameter(param);//release parameter object
	}

	return nSuccess;
}

int ITAccount::TriggerLinkedOrders(char *pszClOrdID, IConnectionMgr *pConnMgr)
{
	int nSuccess = ERR_OK;

	std::map<std::string, std::list<IOrder *>>::iterator iter = m_mapLinkedOrders.find(pszClOrdID);

	if (iter != m_mapLinkedOrders.end())
	{
		std::list<IOrder *>& lstOrders = (*iter).second;

		if (!lstOrders.empty())
		{
			std::list<IOrder *>::iterator iter1  = lstOrders.begin();

			while (iter1 != lstOrders.end())
			{
				IOrder *pOrder = (*iter1);

				if (pOrder)
				{
					NewOrderRequest *pNewOrderReq = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

					if (pNewOrderReq)
					{
						memcpy(&pNewOrderReq->order, &pOrder->m_Order, sizeof(pOrder->m_Order));

						// Reset could of fields
						pNewOrderReq->order.Account = m_Account;
						memset(pNewOrderReq->order.ClOrdId, 0, sizeof(pNewOrderReq->order.ClOrdId));
						pConnMgr->ProcessNextRequest(0, pNewOrderReq, NEW_ORDER_REQUEST);
					}
				}

				iter1++;
			}

			iter = m_mapLinkedOrders.erase(iter);
			DeleteLinkedOrders(pszClOrdID);
		}
	}

	return nSuccess;
}

int ITAccount::HandleOCOOrder(char *pszClOrdID, char *pszLnkOrdID, IConnectionMgr *pConnMgr)
{
	int nSuccess = ERR_OK;

	std::map<std::string, ORDERID_OCO_ORDER_MAP>::iterator iter = m_mapOCOOrders.find(pszLnkOrdID);

	if (iter != m_mapOCOOrders.end())
	{
		ORDERID_OCO_ORDER_MAP& mapOCO = (*iter).second;

		ORDERID_OCO_ORDER_MAP::iterator iter1 = mapOCO.begin();

		while (!mapOCO.empty() && iter1 != mapOCO.end())
		{
			IOrder *pOrder = (*iter1).second;

			if (pOrder)
			{
				if (memcmp(pszClOrdID, pOrder->m_Order.ClOrdId, sizeof(pOrder->m_Order.ClOrdId)) == 0)
				{
					// delete this from the map
					iter1 = mapOCO.erase(iter1);
				}
				else
				{
					// Send Cancel order request
					OrderCancelRequest *pCancelRequest = (OrderCancelRequest *)GetMessageObject(ORDER_CANCEL_REQUEST);

					if (pCancelRequest)
					{
						memcpy(&pCancelRequest->order, &pOrder->m_Order, sizeof(pOrder->m_Order));

						// Reset could of fields
						pCancelRequest->order.Account = m_Account;
						pConnMgr->ProcessNextRequest(0, pCancelRequest, ORDER_CANCEL_REQUEST);

						iter1 = mapOCO.erase(iter1);

						if (mapOCO.empty())
							break;
					}
				}
			}
		}

		m_mapOCOOrders.erase(iter);
	}

	return nSuccess;
}

int ITAccount::ProcessPositionRequest(unsigned int clientID, IConnectionMgr *pMgr)
{
	int nSuccess = 0;

	IPosition *pPosition = NULL;
	PositionResponse *pResponse = (PositionResponse *)GetMessageObject(POSITION_RESPONSE);

	int nCount = 0;
	if (pResponse)
	{
		SYMBOL_IPOSITION_MAP::iterator iter = m_PositionMap.begin();

		for (; iter != m_PositionMap.end(); iter++)
		{
			pPosition = (*iter).second;
			PositionResponse *pResponse1;

			pPosition->GetPositionResponseEx(&pResponse->Position[nCount]);
			nCount++;

			if (nCount >= MAX_POSITION)
			{
				pResponse->Header.KeyDataCtrlBlk = 0;
				pResponse->NoOfPosition = MAX_POSITION;
				pMgr->SendResponseToQueue(clientID, pResponse, POSITION_RESPONSE);

				nCount = 0;
			}
		}

		pResponse->Header.KeyDataCtrlBlk = 1;
		pResponse->NoOfPosition = nCount;
		pMgr->SendResponseToQueue(clientID, pResponse, POSITION_RESPONSE);

		free(pResponse);
	}

	return nSuccess;
}


int ITAccount::ReplaceOCOOrder(char *pszOrigOrdID, char *pszLnkOrdId, IOrder *pOrder)
{
	int nSuccess = 0;

	std::map<std::string, ORDERID_OCO_ORDER_MAP>::iterator iter = m_mapOCOOrders.find(pszLnkOrdId);

	if (iter != m_mapOCOOrders.end())
	{
		ORDERID_OCO_ORDER_MAP& mapOCO = (*iter).second;

		ORDERID_OCO_ORDER_MAP::iterator iter1 = mapOCO.find(pszOrigOrdID);

		if (iter1 != mapOCO.end())
		{
			iter1 = mapOCO.erase(iter1);

			std::pair<std::string, IOrder *> pr(pOrder->m_Order.ClOrdId, pOrder);
			mapOCO.insert(pr);
		}

		//m_mapOCOOrders.erase(iter);
	}

	return nSuccess;
}


int ITAccount::LiquidateOrder(symbol& sym, IOrder *pOrder, IConnectionMgr *pConnMgr, unsigned long ulBid, unsigned long ulAsk)
{
	return 0;
}


int ITAccount::UpdateBalance(double Amount)
{
	int nSuccess = ERR_OK;

	bool bChanged = false;

	AcquireLockAcc();

	if (Amount > 0)
	{
		m_Balance += Amount;

		bChanged = true;
	}
	else if (Amount < 0)
	{
		double lfTempAmount = -1 * Amount;

		if (lfTempAmount < m_Balance && lfTempAmount < m_lfEquity)
		{
			m_Balance += Amount;
			bChanged = true;
		}
		else
		{
			nSuccess = ERR_INSUFFICIENT_FUNDS;
		}
	}

	if (bChanged)
	{
		ITable* tb=CreateTable();

		if (tb)
		{
			IParameter* param=CreateParameter();

			if (param)
			{
				param->AddParam("Amount", m_Balance);
				param->AddParam("AccountID", m_Account);

				bool isSPExist = m_pDatabase->Execute("Exchange_BalanceUpdate",*tb,*param);//execute sp

				if( !isSPExist )
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITAccount::UpdateBalance, Unable to execute SP Exchange_UpdateBalance");
					nSuccess = ERR_INTERNAL_ERROR;
				}
			}

			ReleaseParameter(param);//release parameter object
		}
	}

	ReleaseLockAcc();

	return nSuccess;
}

int ITAccount::EnableAccount(bool bEnable)
{
	int nSuccess = ERR_OK;

	m_nEnableTrade = bEnable;

	return nSuccess;
}


void ITAccount::CalculateCommAndTax(double lfFees, 
									double lfTax, 
									double& lfCalcComm, 
									double& lfCalcTax, 
									double lfCurrentPrice)
{
	lfCalcComm = lfCurrentPrice * lfFees/100.0;
	lfCalcTax = lfCalcComm * lfTax/100.0;
}


int ITAccount::LoadAllNonSettledMapping(ITable *tb)
{
	int nSuccess = 0;
	char szSymbol[20];

	while (!tb->IsEOF())
	{
		tb->Get("Symbol", szSymbol, sizeof(	szSymbol));

		IPosition *pPosition = GetPositionObject(szSymbol);

		if (pPosition)
		{
			pPosition->LoadAllNonSettledMapping(tb);
		}

		tb->MoveNext();
	}

	return nSuccess;
}