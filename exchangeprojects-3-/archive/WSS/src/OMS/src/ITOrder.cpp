///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//08-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "ITOrder.h"
#include <string.h>
#include "Databaseinterface.h"
#include "errorDefs.h"
#include <stdlib.h>
#include "xlogger.h"
#include "IPosition.h"
#include <atlbase.h>
#include <ATLCOMTime.h>


ITOrder::ITOrder()
{
	// Initialize all values
	AvgPx = 0;
	CumQty = 0;						
	OrderStatus = ORDER_STATUS_PENDINGNEW;				
	LeavesQty = 0;					
	Text[0] = '\0';

	reqType = 0;;
	m_pDatabase = NULL;;

	QtyClose = 0;
	QtySettled = 0;
	QtyCancelled = 0;

	m_lfUsedMargin = 0;
	m_lfCommission = 0;
	m_lfTax = 0;
	m_lfExtraUsedMargin = 0;
	m_Order.OrderID = 0;
	m_lfProfit = 0;
	m_ulQtyClosed = 0;

	m_bLinkedOrder = false;

	memset(&m_Order, 0, sizeof(m_Order));
	memset(m_szIPAddress, 0, sizeof(m_szIPAddress));

}

int ITOrder::Init(Order& request, IDatabase *pDatabase, char requestType)
{
	int nSuccess = ERR_OK;

	reqType = requestType;
	m_pDatabase = pDatabase;
	// Copy Order 
	memcpy(&m_Order, &request, sizeof(Order));

	return nSuccess;
}

// Process the Order. Calls various other functions for processing various types of msg
int ITOrder::ProcessOrder(void*& pResponse, IContractManager *pContractManager)
{
	int nSuccess = ERR_OK;

	//return nSuccess;
	long success = 0;

	CComBSTR str(m_Order.Symbol.Product);
	CComBSTR strContract(m_Order.Symbol.Contract);
	CComBSTR strGateway(m_Order.Symbol.Gateway);

	HRESULT hr = pContractManager->ValidateOrder(m_Order.Symbol.ProductType,
												str.Detach(),
												strContract.Detach(),
												strGateway.Detach(),
												strGateway.Detach(),
												m_Order.Price,
												m_Order.StopPx,
												m_Order.OrderQty,
												m_Order.OrderType,
												m_Order.Side,
												&success);


	if (!FAILED(hr))
	{
		//if (/*success == ERR_LIMITPX_INVALID ||*/ success == INVALID_PRICE_BAND)
		//{
		//	success = ERR_OK;
		//}
		if (success == ERR_OK)
		{
			// Message is valid
			/*nSuccess = InsertOrder();

			if (nSuccess == ERR_OK)
			{
				nSuccess = GenerateExecutionReport(pResponse);
			}*/
		}
		//else if (success == ERR_
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::ProcessOrder, Validation failed = %ld", success);
			nSuccess = success;
		}
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;
		_com_error error(hr);
		LPCTSTR errorText = error.ErrorMessage();
		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::ProcessOrder, Validation function in ContractManager failed = %s", errorText);
	}

	return nSuccess;
}

//Execution Transaction type		Order Status		Execution Type				In Response to
//0 (new)					0 = New Order Ack	0 = New Order Ack			New Order						OMS
//0 (new)s					4 = Cancel Ack		4 = Cancel Ack				Cancel Order					OMS
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
int ITOrder::GenerateExecutionReport(void*& pResponse)
{
	int nSuccess = ERR_OK;
	
	OrderStatusResponse* exeRpt = (OrderStatusResponse*)GetMessageObject(ORDER_STATUS_RESPONSE);

	// Copy the whole order information in the execution report.
	memcpy(&exeRpt->ExecutionReport, &m_Order, sizeof(m_Order));
	exeRpt->ExecutionReport.OrderID = m_Order.OrderID;

	// Generate Execution ID. Keep exec id as int
	sprintf(exeRpt->ExecutionReport.ExecID,"%ul", m_Order.OrderID);
	// Transact Time
	exeRpt->ExecutionReport.TransactTime = COleDateTime::GetCurrentTime();

	switch (reqType)
	{
	case NEW_ORDER_REQUEST:
		// ExecTrans Type
		exeRpt->ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_NEW;
		// Order Status
		exeRpt->ExecutionReport.OrderStatus = ORDER_STATUS_PENDINGNEW;
		// Exec Type
		exeRpt->ExecutionReport.ExecType = EXECUTION_TYPE_NEW;
		break;
	case ORDER_CANCEL_REQUEST:
		// ExecTrans Type
		exeRpt->ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_NEW;
		// Order Status
		exeRpt->ExecutionReport.OrderStatus = ORDER_STATUS_PENDING_CANCEL;
		// Exec Type
		exeRpt->ExecutionReport.ExecType = EXECUTION_TYPE_CANCELACK;
		break;
	case ORDER_REPLACE_REQUEST:
		// ExecTrans Type
		exeRpt->ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_NEW;
		// Order Status
		exeRpt->ExecutionReport.OrderStatus = ORDER_STATUS_PENDINGREPLACE;
		// Exec Type
		exeRpt->ExecutionReport.ExecType = EXECUTION_TYPE_MODIFYACK;
		break;
	case ORDER_STATUS_REQUEST:
		// ExecTrans Type
		exeRpt->ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_STATUS;
		// Order Status
		exeRpt->ExecutionReport.OrderStatus = OrderStatus;
		// Exec Type
		exeRpt->ExecutionReport.ExecType = EXECUTION_TYPE_STATUS_REPORT;
		break;
	}

	pResponse = exeRpt;
	
	return nSuccess;
}

int ITOrder::UpdateOrder()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			char *end;
			unsigned long long OrderID =  _strtoui64(this->m_Order.ClOrdId, &end, 10);

			param->AddParam("OrderID", OrderID);
			param->AddParam("OrderStatus", OrderStatus);
			param->AddParam("LPOrdID", this->m_Order.OrderID);
			param->AddParam("CloseQty", QtyClose);
			param->AddParam("CancelQty", QtyCancelled);
			param->AddParam("SettledQty", QtySettled);
			param->AddParam("UsedMargin", m_lfUsedMargin);
			param->AddParam("Success", nSuccess);

			bool isSPExist = m_pDatabase->Execute("OMS_UpdateOrderStatus",*tb,*param);//execute sp
			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder1, Unable to execute SP");
				nSuccess = ERR_INTERNAL_ERROR_DB;

				ReleaseTable(tb);//release table object
				ReleaseParameter(param);//release parameter object

				return nSuccess;
			}

			ReleaseParameter(param);//release parameter object
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder, Unable to create instance of Param");
		}

		ReleaseTable(tb);//release table object
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder, Unable to create instance of Table");
	}


	return nSuccess;
}

int ITOrder::UpdateOrderMapping(OrderExecInfo *pInfo, int Cancelled1)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrderMapping, Account No = %ul, Open Order = %s, Close Order = %s, Qty = %lu, SettledQty = %lu", (unsigned long)pInfo->pOrder->m_Order.Account, pInfo->pOrder->m_Order.ClOrdId, m_Order.ClOrdId, (unsigned long)pInfo->Qty, (unsigned long)pInfo->SettledQty);
			param->AddParam("AccountID", pInfo->pOrder->m_Order.Account);
			param->AddParam("OpenOrderID", pInfo->pOrder->m_Order.ClOrdId, sizeof(pInfo->pOrder->m_Order.ClOrdId));
			param->AddParam("CloseOrderID", m_Order.ClOrdId, sizeof(m_Order.ClOrdId));
			param->AddParam("Qty", pInfo->Qty);
			param->AddParam("SettledQty", pInfo->SettledQty);
			param->AddParam("Cancelled1", Cancelled1);
			param->AddParam("Success", nSuccess);

			bool isSPExist = m_pDatabase->Execute("OMS_UpdateOnOpenCloseRelation",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrderMapping, Unable to execute SP OMS_UpdateOnOpenCloseRelation");
				nSuccess = ERR_INTERNAL_ERROR_DB;
				
				//ReleaseParameter(param);//release parameter object

				//break;
			}

			ReleaseParameter(param);//release parameter object
		}

		ReleaseTable(tb);//release table object
	}

	return nSuccess;
}

int ITOrder::InsertOrderMapping()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		std::list<OrderExecInfo>::iterator iter = m_lstTaggedOrders.begin();

		for (;iter != m_lstTaggedOrders.end(); iter++)
		{
			IParameter* param=CreateParameter();

			if (param)
			{
				OrderExecInfo& info = *iter;

				if (info.pOrder)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertOrderMapping, Account No = %ul, Open Order = %s, Close Order = %s, Qty = %lu, SettledQty = %lu", (unsigned long)info.pOrder->m_Order.Account, info.pOrder->m_Order.ClOrdId, m_Order.ClOrdId, (unsigned long)info.Qty, (unsigned long)info.SettledQty);
					param->AddParam("AccountID", info.pOrder->m_Order.Account);
					param->AddParam("OpenOrderID", info.pOrder->m_Order.ClOrdId, sizeof(info.pOrder->m_Order.ClOrdId));
					param->AddParam("CloseOrderID", m_Order.ClOrdId, sizeof(m_Order.ClOrdId));
					param->AddParam("Qty", info.Qty);
					param->AddParam("SettledQty", info.SettledQty);
					param->AddParam("Success", nSuccess);

					bool isSPExist = m_pDatabase->Execute("OMS_InsertOnOpenCloseRelation",*tb,*param);//execute sp

					if( !isSPExist )
					{
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertOrderMapping, Unable to execute SP OMS_InsertOnOpenCloseRelation");
						nSuccess = ERR_INTERNAL_ERROR_DB;
						ReleaseTable(tb);//release table object
						ReleaseParameter(param);//release parameter object

						break;
					}

					ReleaseParameter(param);//release parameter object
				}
			}
		}
	}

	return nSuccess;
}

// Update the order
int ITOrder::UpdateOrder(ExecutionReport *pReport,
						 double lfBalance, 
						double lfUsedMargin, 
						double DayBuySideTurnOver, 
						double DaySellSideTurnOver, 
						double DayRealizedProfit, 
						unsigned long ulLongTempPos, 
						unsigned long ulShortTempPos,
						double lfSellSideUM,
						double lfBuySideUM,
						double lfOverAllUM)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::UpdateOrder, Entered");

	int nSuccess = ERR_OK;

	OrderStatus = pReport->OrderStatus;

	char *end;
	unsigned long long OrderID =  _strtoui64(pReport->ClOrdId, &end, 10);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::UpdateOrder, Order ID = %s", pReport->ClOrdId);

	if (OrderStatus == ORDER_STATUS_FILLED || OrderStatus == ORDER_STATUS_PARTIALLY_FILLED)
	{
		AvgPx = ((CumQty * AvgPx) + (pReport->QtyFilled * pReport->LastPx))/(CumQty + pReport->QtyFilled);
		CumQty += pReport->QtyFilled;
		LeavesQty = m_Order.OrderQty - CumQty;

		pReport->LeavesQty = LeavesQty;
		pReport->AvgPx = AvgPx;
		pReport->CumQty = CumQty;

		char szVal[100];
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::UpdateOrder, AvgPx=%lf, CumQty=%s, QtyFilled=%s, LastPx=%s", 
											AvgPx, 
											_ui64toa(CumQty, szVal, 10),
											_ui64toa(pReport->QtyFilled, szVal, 10),
											_ui64toa(pReport->LastPx, szVal, 10)
											);

		ITable* tb=CreateTable();

		if (tb)
		{
			IParameter* param=CreateParameter();

			if (param)
			{
				//pReport->TransactTime = 0;
				//pReport->TransactTime = COleDateTime::GetCurrentTime();
				param->AddParam("OrderID", OrderID);
				param->AddDateTimeParam("LastUpdateTime", pReport->TransactTime);
				param->AddParam("FilledQty", pReport->QtyFilled);
				param->AddParam("CumQty", CumQty);
				param->AddParam("AvgFillPrice", AvgPx);
				param->AddParam("OrderstatusID", pReport->OrderStatus);
				param->AddParam("FillID", pReport->ExecID, sizeof(pReport->ExecID));
				param->AddParam("LastPrice", pReport->LastPx);
				param->AddParam("Side", pReport->Side);
				param->AddParam("LeaveQty", LeavesQty);
				param->AddParam("AccountID", pReport->Account);
				param->AddParam("Symbol", pReport->Symbol.Contract, sizeof(pReport->Symbol.Contract));
				param->AddParam("CloseQty", QtyClose);
				param->AddParam("CancelQty", QtyCancelled);
				param->AddParam("SettledQty", QtySettled);
				param->AddParam("AccountBalance", lfBalance);
				param->AddParam("AccountUsedMargin", lfUsedMargin);
				param->AddParam("DayBuySideTurnOver", DayBuySideTurnOver);
				param->AddParam("DaySellSideTurnOver", DaySellSideTurnOver);
				param->AddParam("DayRealizedProfit", DayRealizedProfit);
				param->AddParam("Temp_Long_Pos", ulLongTempPos);
				param->AddParam("Temp_Short_Pos", ulShortTempPos);
				param->AddParam("BuySideUsedMargin", lfBuySideUM);
				param->AddParam("SellSideUsedMargin", lfSellSideUM);
				param->AddParam("OverallUsedMargin", lfOverAllUM);
				param->AddParam("Profit", m_lfProfit);
				param->AddParam("Fees", m_lfCommission);
				param->AddParam("Tax", m_lfTax);
				param->AddParam("Success", nSuccess);

				bool isSPExist = m_pDatabase->Execute("OMS_UpdateOrderOnFilled_New",*tb,*param);//execute sp
				if( !isSPExist )
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder, Unable to execute SP OMS_UpdateOrderOnFilled_New");
					nSuccess = ERR_INTERNAL_ERROR_DB;
					ReleaseTable(tb);//release table object
					ReleaseParameter(param);//release parameter object

					return nSuccess;
				}

				ReleaseParameter(param);//release parameter object
			}
			else
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder - 1, Unable to create instance of Param");
			}

			ReleaseTable(tb);//release table object
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder - 1, Unable to create instance of Table");
		}
	}
	else
	{
		//pReport->Commission = 0;
		//pReport->Tax = 0;

		ITable* tb=CreateTable();

		if (tb)
		{
			IParameter* param=CreateParameter();

			if (param)
			{
				param->AddParam("OrderID", OrderID);
				param->AddParam("OrderStatus", pReport->OrderStatus);
				param->AddParam("LPOrdID", pReport->OrderID);
				param->AddParam("CloseQty", QtyClose);
				param->AddParam("CancelQty", QtyCancelled);
				param->AddParam("SettledQty", QtySettled);
				param->AddParam("OrderUsedMargin", m_lfUsedMargin);
				param->AddParam("AccountId", m_Order.Account);
				param->AddParam("Symbol", m_Order.Symbol.Contract, sizeof(m_Order.Symbol.Contract));
				param->AddParam("AccountBalance", lfBalance);
				param->AddParam("AccountUsedMargin", lfUsedMargin);
				param->AddParam("DayBuySideTurnOver", DayBuySideTurnOver);
				param->AddParam("DaySellSideTurnOver", DaySellSideTurnOver);
				param->AddParam("DayRealizedProfit", DayRealizedProfit);
				param->AddParam("Temp_Long_Pos", ulLongTempPos);
				param->AddParam("Temp_Short_Pos", ulShortTempPos);

				param->AddParam("Success", nSuccess);

				bool isSPExist = m_pDatabase->Execute("OMS_UpdateOrderStatus_New",*tb,*param);//execute sp
				if( !isSPExist )
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder, Unable to execute SP OMS_UpdateOrderStatus_New");
					nSuccess = ERR_INTERNAL_ERROR_DB;

					ReleaseTable(tb);//release table object
					ReleaseParameter(param);//release parameter object

					return nSuccess;
				}

				
				ReleaseParameter(param);//release parameter object
			}
			else
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder - 2, Unable to create instance of Param");
			}
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::UpdateOrder - 2, Unable to create instance of Table");
		}

		ReleaseTable(tb);//release table object
	}	

	pReport->OrderID = OrderID;

	return nSuccess;
}

int ITOrder::InsertOrder(double lfBalance, 
					double lfUsedMargin, 
					double DayBuySideTurnOver, 
					double DaySellSideTurnOver, 
					double DayRealizedProfit, 
					unsigned long ulLongTempPos, 
					unsigned long ulShortTempPos)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertOrder, Entered");

	int nSuccess = ERR_OK;

	//// Insert order in DB and generate ID.	
	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			m_Order.TransactTime = COleDateTime::GetCurrentTime();
			param->AddParam("ClOrdID", m_Order.ClOrdId, sizeof (m_Order.ClOrdId));
			param->AddParam("AccountID", (UINT)m_Order.Account);
			param->AddParam("PositionSize", m_Order.OrderQty);
			param->AddParam("Price", m_Order.Price);
			param->AddParam("StopPx", m_Order.StopPx);
			param->AddParam("OrderType", m_Order.OrderType);
			param->AddParam("OrderStatusID", OrderStatus);
			param->AddParam("Side", m_Order.Side);
			param->AddDateTimeParam("TransactTime", m_Order.TransactTime);
			param->AddParam("Symbol", m_Order.Symbol.Contract, sizeof(m_Order.Symbol.Contract));
			param->AddParam("TIF", m_Order.TimeInForce);
			param->AddParam("IPAddress", m_szIPAddress, sizeof(m_szIPAddress));
			param->AddParam("DisclosedQty", m_Order.MinOrDisclosedQty);
			param->AddDateTimeParam("ExpireDate", m_Order.ExpireDate);
			param->AddParam("OrigOrdID", m_Order.origClOrdId, sizeof(m_Order.origClOrdId));
			param->AddParam("OrderUsedMargin", m_lfUsedMargin);
			param->AddParam("CloseQty", QtyClose);
			param->AddParam("CancelQty", QtyCancelled);
			param->AddParam("SettledQty", QtySettled);
			param->AddParam("AccountBalance", lfBalance);
			param->AddParam("AccountUsedMargin", lfUsedMargin);
			param->AddParam("DayBuySideTurnOver", DayBuySideTurnOver);
			param->AddParam("DaySellSideTurnOver", DaySellSideTurnOver);
			param->AddParam("DayRealizedProfit", DayRealizedProfit);
			param->AddParam("Temp_Long_Pos", ulLongTempPos);
			param->AddParam("Temp_Short_Pos", ulShortTempPos);
			param->AddParam("PositionEffect", m_Order.PositionEffect);
			param->AddParam("LinkedOrdID", m_Order.LnkdOrdId, sizeof(m_Order.LnkdOrdId));
			param->AddParam("Fees", m_lfCommission);
			param->AddParam("Tax", m_lfTax);

			m_CounterAvgPx = 0.0;
			strcpy(m_CounterClOrdId, "");
			m_MMAccount = 0;
			param->AddParam("Success", nSuccess, 2);
			bool isSPExist = m_pDatabase->Execute("OMS_InsertNewOrder_New",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertOrder, Unable to execute SP OMS_InsertNewOrder");
				nSuccess = ERR_INTERNAL_ERROR;
			}

			if (nSuccess == ERR_OK)
			{
				int returnVal = 0;	
				while(!tb->IsEOF())//loop the table
				{
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in ITOrder::InsertOrder");
					tb->Get("OrderID", m_Order.OrderID);
					tb->MoveNext();
					break;
				}
			
				_ui64toa(m_Order.OrderID, m_Order.ClOrdId, 10);
			}

			ReleaseParameter(param);//release parameter object
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertOrder, Unable to create instance of Param");
		}

		ReleaseTable(tb);//release table object
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertOrder, Unable to create instance of Table");
	}

	InsertOrderMapping();

	return nSuccess;
}

ITOrder::~ITOrder()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertOrder, Destructor");
}

NewOrderRequest *&ITOrder::GetNewOrderRequest()
{
	NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

	if (pRequest)
	{
		memcpy(&pRequest->order, &m_Order, sizeof(NewOrderRequest));
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::GetNewOrderRequest, Unable to allocate memory for NewOrderRequest");
	}
	// Prepare object and return.
	return pRequest;
}

int ITOrder::ProcessExecutionReport(ExecutionReport *pReport)
{
	int nSuccess = ERR_OK;

	if (pReport)
	{
		memcpy(&m_Order, pReport, ((char *)&pReport->OrderInfoEnd - (char *)pReport));
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;
	}

	return nSuccess;
}

int ITOrder::Init(ITable *tb, IDatabase *pDatabase)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::Init, Entered");

	int nSuccess = 0;
	unsigned long long ordid = 0;

	m_pDatabase = pDatabase;
	char szVal[5];

	tb->Get("PK_OrderID", ordid);
	tb->Get("ClOrdID", m_Order.ClOrdId, sizeof(m_Order.ClOrdId));
	tb->Get("LPOrdID", m_Order.OrderID);
	tb->Get("OrigOrdID", m_Order.origClOrdId, sizeof(m_Order.origClOrdId));
	tb->Get("PositionSize", m_Order.OrderQty);
	tb->Get("Price", m_Order.Price);
	tb->Get("StopPx", m_Order.StopPx);

	tb->Get("OrderType", szVal, sizeof(szVal));
	m_Order.OrderType = szVal[0];

	tb->Get("OrderStatus", szVal, sizeof(szVal));
	OrderStatus = szVal[0];

	tb->Get("Side", szVal, sizeof(szVal));
	m_Order.Side = szVal[0];

	tb->GetDateTime("OrderDateTimeRequested", m_Order.TransactTime);
	//tb->Get("ProviderName", m_Order.Symbol.Provider, sizeof(m_Order.Symbol.Provider));
	tb->Get("ExchangeName", m_Order.Symbol.Gateway, sizeof(m_Order.Symbol.Gateway));
	tb->Get("ContractName", m_Order.Symbol.Contract, sizeof(m_Order.Symbol.Contract));
	tb->Get("ProductName", m_Order.Symbol.Product, sizeof(m_Order.Symbol.Product));
	
	tb->Get("PositionEffect", szVal, sizeof(szVal));
	m_Order.PositionEffect= szVal[0];

	tb->Get("ProductType", szVal, sizeof(szVal));
	m_Order.Symbol.ProductType= szVal[0];

	tb->Get("TIF", szVal, sizeof(szVal));
	m_Order.TimeInForce = szVal[0];

	tb->Get("FilledQty", CumQty);
	tb->Get("LeaveQty", LeavesQty);

	tb->Get("AvgFillPrice", AvgPx);
	tb->GetDateTime("GTD", m_Order.ExpireDate);
	tb->Get("UsedMargin", m_lfUsedMargin);
	tb->Get("CloseQty", QtyClose);
	tb->Get("SettledQty", QtySettled);
	tb->Get("CancelQty", QtyCancelled);
	tb->Get("LinkedOrderID", m_Order.LnkdOrdId, sizeof(m_Order.LnkdOrdId));

	return nSuccess;
}

int ITOrder::InitLinkedOrder(ITable *tb, IDatabase *pDatabase)
{
	int nSuccess = 0;

	unsigned long long ordid = 0;
	m_pDatabase = pDatabase;
	char szVal[2];

	tb->Get("ClOrdID", m_Order.ClOrdId, sizeof(m_Order.ClOrdId));
	tb->Get("PositionSize", m_Order.OrderQty);
	tb->Get("Price", m_Order.Price);
	tb->Get("StopPx", m_Order.StopPx);

	tb->Get("OrderType", szVal, sizeof(szVal));
	m_Order.OrderType = szVal[0];

	tb->Get("OrderStatus", szVal, sizeof(szVal));
	OrderStatus = szVal[0];

	tb->Get("Side", szVal, sizeof(szVal));
	m_Order.Side = szVal[0];

	tb->GetDateTime("OrderDateTimeRequested", m_Order.TransactTime);

	tb->Get("ContractName", m_Order.Symbol.Contract, sizeof(m_Order.Symbol.Contract));
	tb->Get("ProductName", m_Order.Symbol.Product, sizeof(m_Order.Symbol.Product));
	
	tb->Get("ProductType", szVal, sizeof(szVal));
	m_Order.Symbol.ProductType= szVal[0];

	tb->Get("TIF", szVal, sizeof(szVal));
	m_Order.TimeInForce = szVal[0];

	tb->Get("PositionEffect", m_Order.PositionEffect);

	tb->Get("LinkedOrderID", m_Order.LnkdOrdId, sizeof(m_Order.LnkdOrdId));

	return nSuccess;
}


std::string ITOrder::ToString()
{
	std::string strLogMsg = "";

	char szMsg[1000];
	char s1[100],s2[100],s3[100],s4[100],s5[100],s6[100],s7[100];
	_ui64toa(m_Order.MinOrDisclosedQty,s1,10);
	_ui64toa(m_Order.OrderID,s2,10);
	_ui64toa(m_Order.OrderQty,s3,10);
	_ui64toa(m_Order.Price,s4,10);
	_ui64toa(m_Order.StopPx,s5,10);
	_ui64toa(this->CumQty,s6,10);
	_ui64toa(this->LeavesQty,s7,10);
    sprintf(szMsg, "Account=%lu, ClOrdID=%s, MinOrDisclosedQty=%s, OrderID=%s, OrderQty=%s, OrderType=%c, PositionEffect=%c,Price=%s, StopPx=%s, Side=%c, Symbol=%s, TIF=%c, AvgPx=%lf,CumQty=%s, LeavexQty=%s, OrderStatus=%c, Profit=%lf, QtyCloseFilled=%lu,QtyClosePlaced=%lu, QtyForClosePos=%lu, QtyForOpenPos=%lu, QtyNotUsed=%lu, reqType=%lu",
					m_Order.Account, 
					m_Order.ClOrdId,                        
					s1,
					s2,
					s3,
					m_Order.OrderType,
					m_Order.PositionEffect,
					s4,
					s5,
					m_Order.Side,
					m_Order.Symbol.Contract,
					m_Order.TimeInForce,
					this->AvgPx,
					s6,
					s7,
					this->OrderStatus,
					0,
					0,
					0,
					0,
					0,
					0,
					this->reqType);

	strLogMsg = szMsg;

	return strLogMsg;


}

int ITOrder::ProcessCancelOrder(void*& pResponse)
{
	int nSuccess = ERR_OK;

	// Get LP OrderID for cancelling the order
	nSuccess = GenerateExecutionReport(pResponse);

	return nSuccess;
}

int ITOrder::ProcessCancelReplaceOrder(void*& pResponse, IOrder *pOldOrder, IContractManager *pContractManager)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::ProcessOrder, Entered");

	int nSuccess = ERR_OK;

	long success = 0;

	CComBSTR str(m_Order.Symbol.Product);
	CComBSTR strContract(m_Order.Symbol.Contract);
	CComBSTR strGateway(m_Order.Symbol.Gateway);

	HRESULT hr = pContractManager->ValidateOrder(m_Order.Symbol.ProductType,
												str.Detach(),
												strContract.Detach(),
												strGateway.Detach(),
												strGateway.Detach(),
												m_Order.Price,
												m_Order.StopPx,
												m_Order.OrderQty,
												m_Order.OrderType,
												m_Order.Side,
												&success);


	if (!FAILED(hr))
	{
		if (success == ERR_OK)
		{
			// Message is valid
			/*nSuccess = InsertOrder();

			if (nSuccess == ERR_OK)
			{
				nSuccess = GenerateExecutionReport(pResponse);
			}*/
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::ProcessOrder, Validation failed = %ld", success);
			nSuccess = success;
		}
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;
		_com_error error(hr);
		LPCTSTR errorText = error.ErrorMessage();
		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::ProcessOrder, Validation function in ContractManager failed = %s", errorText);
	}

	return nSuccess;
}

void ITOrder::SetIPAddress(char *pszIPAddress)
{
	strcpy(m_szIPAddress, pszIPAddress);
}

int ITOrder::InsertLinkedOrder(char *pszLnkOrdID)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			m_Order.TransactTime = COleDateTime::GetCurrentTime();
			param->AddParam("ClOrdID", m_Order.ClOrdId, sizeof (m_Order.ClOrdId));
			param->AddParam("AccountID", (UINT)m_Order.Account);
			param->AddParam("PositionSize", m_Order.OrderQty);
			param->AddParam("Price", m_Order.Price);
			param->AddParam("StopPx", m_Order.StopPx);
			param->AddParam("OrderType", m_Order.OrderType);
			param->AddParam("OrderStatusID", OrderStatus);
			param->AddParam("Side", m_Order.Side);
			param->AddDateTimeParam("TransactTime", m_Order.TransactTime);
			param->AddParam("Symbol", m_Order.Symbol.Contract, sizeof(m_Order.Symbol.Contract));
			param->AddParam("TIF", m_Order.TimeInForce);
			param->AddDateTimeParam("ExpireDate", m_Order.ExpireDate);
			param->AddParam("PositionEffect", m_Order.PositionEffect);
			param->AddParam("LinkedOrdID", pszLnkOrdID, sizeof(m_Order.LnkdOrdId));
			param->AddParam("Success", nSuccess, 2);

			bool isSPExist = m_pDatabase->Execute("OMS_InsertLinkedOrders",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::InsertLinkedOrder, Unable to execute SP OMS_InsertLinkedOrders");
				nSuccess = ERR_INTERNAL_ERROR;
			}

			ReleaseParameter(param);//release parameter object
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertLinkedOrder, Unable to create instance of Param");
		}

		ReleaseTable(tb);//release table object
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::InsertLinkedOrder, Unable to create instance of Table");
	}

	return nSuccess;
}

int ITOrder::AddOrderToTag(unsigned long long qty, unsigned long long SettledQty, IOrder *pOrder, bool bOpenPos, OrderExecInfo *pInfo)
{
	int nSuccess = 0;

	OrderExecInfo info;

	info.Qty = qty;
	info.pOrder = pOrder;
	info.SettledQty = 0;
	info.bOpenPos = bOpenPos;

	m_lstTaggedOrders.push_back(info);

	if (pInfo)
		memcpy(pInfo, &info, sizeof(info));

	return nSuccess;
}

std::list<OrderExecInfo>& ITOrder::GetTaggedOrderList()
{
	return m_lstTaggedOrders;
}