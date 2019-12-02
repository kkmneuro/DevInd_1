#include "StdAfx.h"
#include "ExecutionRptHandler.h"
#include "errorDefs.h"
#include "TradeBOAPI.h"
#include "OMSAPI.h"
#include "IAccount.h"
#include "xlogger.h"
#include "AccountMgr.h"
#include <Windows.h>
#include <exception>

ExecutionRptHandler::ExecutionRptHandler(int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IDatabase *ptrDatabase, IAccountMgr *pAccountMgr, DWORD dwCookie)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, entered");

	_ptrConnectionMgr = ptrConnectionMgr;
	_ptrDatabase = ptrDatabase;
	_ptrAccountMgr = pAccountMgr;
	m_dwCookie = dwCookie;

	OrderStatusResponse *pResponse = (OrderStatusResponse *)ptrRequest;
	
	_ptrReport = &pResponse->ExecutionReport;
}

ExecutionRptHandler::~ExecutionRptHandler(void)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, Destructor");
}

void ExecutionRptHandler::Run ()
{
	int nSuccess = 0;
	OrderStatusResponse *pResponse = NULL;
	IOrder *pOrder = NULL;
	bool bAccountChanged = false;
	bool bPositionChanged = false;
	void *pResponseAccount = NULL;
	void *pResponsePosition = NULL;
	unsigned long ulTempLongPos = 0;
	unsigned long ulTempShortPos = 0;
	std::list<IOrder*> lstOrdersToUpdate;
	double lfBuyUM = 0;
	double lfSellUM = 0;
	double lfOverallUM = 0;
  bool bGlobalPosModified = false;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, Run");

	__try
	{
		IAccount *pAccount = _ptrAccountMgr->GetIAccountFromClOrderID(_ptrReport->ClOrdId);

		if (pAccount)
		{
			CoInitializeEx(NULL, COINIT_MULTITHREADED);
			CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

			IContractManager *pContractManager;
			pToGITTest.CopyTo(&pContractManager);

			pAccount->AcquireLockAcc();

			_ptrReport->Account = pAccount->m_Account;

			SymbolSpread sp;
			memset(&sp, 0, sizeof(sp));
			
			_ptrAccountMgr->GetSpreadInfo(_ptrReport->Symbol, sp, pAccount->m_nGroup);

			// MArkup prices
			nSuccess = MarkupAllPrices(_ptrReport, pAccount, false, sp);

			nSuccess = pAccount->ProcessExecutionReport(_ptrReport, 
														pOrder, 
														bAccountChanged, 
														bPositionChanged,
														pResponseAccount,
														pResponsePosition,
														ulTempLongPos,
														ulTempShortPos,
														(void *)&lstOrdersToUpdate,
														lfBuyUM,
														lfSellUM,
														lfOverallUM,
														sp.lfFees,
														sp.lfTax,
														_ptrDatabase,
														pContractManager,
														_ptrConnectionMgr,
                            ((AccountMgr *)_ptrAccountMgr)->m_pGlobalPos );

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 1");
			if (nSuccess == ERR_OK)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 2");
				//if (!pAccount->IsMMAccount())
				//{
				//	// Generate a new order for hedging
				//	NewOrderRequest *pNewOrderReq = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

				//	if (pNewOrderReq)
				//	{
				//		memcpy(&pNewOrderReq->order, &pOrder->m_Order, sizeof(pOrder->m_Order));

				//		// Reset could of fields
				//		pNewOrderReq->order.Account = _ptrReport->MMId;
				//		memset(pNewOrderReq->order.ClOrdId, 0, sizeof(pNewOrderReq->order.ClOrdId));
				//		pNewOrderReq->order.OrderType = ORDER_TYPE_MARKET_ORDER;
				//		pNewOrderReq->order.OrderQty = _ptrReport->QtyFilled;
				//		
				//		_ptrConnectionMgr->ProcessNextRequest(0, pNewOrderReq, NEW_ORDER_REQUEST);
				//	}
				//}
				// Updates table with current status
				pOrder->UpdateOrder(_ptrReport, 
									pAccount->m_Balance,
									pAccount->m_lfUsedMargin,
									pAccount->m_lfBuyTurnover,
									pAccount->m_lfSellTurnover,
									0,
									ulTempLongPos,
									ulTempShortPos,
									lfBuyUM,
									lfSellUM,
									lfOverallUM);

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 3");

				std::list<OrderStatusResponse> lstOrderStatusReport;

				// Update rest of the orders that are settled
				if (!lstOrdersToUpdate.empty())
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 4");
					std::list<IOrder*>::iterator iter = lstOrdersToUpdate.begin();

					while(iter != lstOrdersToUpdate.end())
					{
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 5");
						IOrder *pOrder = (*iter);

						if (pOrder)
						{
							pOrder->UpdateOrder();
		
							OrderStatusResponse status;
							memset(&status, 0, sizeof(status));
							status.Header.StructSize = sizeof(status);
							status.Header.MessageType = ORDER_STATUS_RESPONSE;

							memcpy(&status.ExecutionReport, &pOrder->m_Order, sizeof(pOrder->m_Order));
							status.ExecutionReport.ClosedQuantity = pOrder->QtySettled;
              status.ExecutionReport.OrderStatus = pOrder->OrderStatus;
							status.ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_STATUS;
							status.ExecutionReport.ExecType = EXECUTION_TYPE_STATUS_REPORT;

              status.ExecutionReport.CounterClOrdId[0] = '\0';
              strcpy(status.ExecutionReport.ExecID, "11111");
              status.ExecutionReport.AvgPx = 0;
              status.ExecutionReport.CumQty = 0;
              status.ExecutionReport.Text[0] = '\0';
              //status.ExecutionReport.

							lstOrderStatusReport.push_back(status);
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 6");
						}

						iter++;
					}

					lstOrdersToUpdate.clear();
				}

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 7");
		if (_ptrReport->OrderStatus == ORDER_STATUS_CANCEL ||
			_ptrReport->OrderStatus == ORDER_STATUS_EXPIRED ||
			_ptrReport->OrderStatus == ORDER_STATUS_REJECTED || 
			_ptrReport->OrderStatus == ORDER_STATUS_REPLACED || 
			_ptrReport->OrderStatus == ORDER_STATUS_UNDEFINED || 
			_ptrReport->OrderStatus == ORDER_STATUS_ORDER_NOT_FOUND)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 8");
			_ptrAccountMgr->RemoveFromClOrderIDIAccountMap(_ptrReport->ClOrdId);
		}
		else if ((_ptrReport->OrderStatus == ORDER_STATUS_FILLED || 
			_ptrReport->OrderStatus == ORDER_STATUS_PARTIALLY_FILLED) &&
			pOrder->CumQty /*+ _ptrReport->QtyFilled*/ == pOrder->m_Order.OrderQty)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 9");
			_ptrAccountMgr->RemoveFromClOrderIDIAccountMap(_ptrReport->ClOrdId);
		}

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 10");
        // Create a response and send it to all CCPs
        if ((_ptrReport->OrderStatus == ORDER_STATUS_FILLED || _ptrReport->OrderStatus == ORDER_STATUS_PARTIALLY_FILLED) && _ptrAccountMgr->IsCCPsSubscribed())
        {
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 11");
          PositionResponse *pGlobalPosResponse = (PositionResponse *)GetMessageObject(POSITION_RESPONSE);

          if (pGlobalPosResponse)
          {
            _ptrAccountMgr->GetGlobalPosition(_ptrReport->Symbol,
              pGlobalPosResponse->Position[0].BuyQty,
              pGlobalPosResponse->Position[0].BuyVal,
              pGlobalPosResponse->Position[0].SellQty,
			  pGlobalPosResponse->Position[0].SellVal,
			  pGlobalPosResponse->Position[0].NetPrice,
              pGlobalPosResponse->Position[0].BuyAvg,
              pGlobalPosResponse->Position[0].SellAvg);

			pGlobalPosResponse->Position[0].NetQty = pGlobalPosResponse->Position[0].SellQty - pGlobalPosResponse->Position[0].BuyQty;
			pGlobalPosResponse->Position[0].NetVal = pGlobalPosResponse->Position[0].SellVal - pGlobalPosResponse->Position[0].BuyVal;
			//pGlobalPosResponse->Position[0].NetPrice = pGlobalPosResponse->Position[0].NetVal / pGlobalPosResponse->Position[0].NetQty;

            memcpy(&pGlobalPosResponse->Position[0].Symbol, &_ptrReport->Symbol, sizeof(_ptrReport->Symbol));
            pGlobalPosResponse->NoOfPosition = 1;

            // Broadcast to all CCPs
            _ptrAccountMgr->BroadcastToCCPs(pGlobalPosResponse);

            free(pGlobalPosResponse);
          }
        }

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 12");
				pResponse = (OrderStatusResponse *)GetMessageObject(ORDER_STATUS_RESPONSE);

				if (pResponse && nSuccess == ERR_OK)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 13");
					memcpy(&pResponse->ExecutionReport, _ptrReport, sizeof(ExecutionReport));

					pAccount->AcquireSessionCS();
					std::list<IClientSession *> lstSession = pAccount->GetSessionList();

					std::list<IClientSession *>::iterator iter = lstSession.begin();

					for (;iter != lstSession.end(); iter++)
					{
						IClientSession *pSession = (*iter);

						//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::run, Send response to Client=%u", pSession->GetClientId());
            stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::run, OrderID=%s, SettledQty=%lu, Status=%c", pResponse->ExecutionReport.ClOrdId, (unsigned int)pResponse->ExecutionReport.ClosedQuantity, pResponse->ExecutionReport.OrderStatus);

						_ptrConnectionMgr->SendResponseToQueue(pSession->GetClientId() , (void *)pResponse, ORDER_STATUS_RESPONSE);

						if (!lstOrderStatusReport.empty())
						{
							std::list<OrderStatusResponse>::iterator iter = lstOrderStatusReport.begin();

							for (;iter != lstOrderStatusReport.end();iter++)
							{
								OrderStatusResponse& st = *iter;

                stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::run 1, OrderID=%s, SettledQty=%lu, Status=%c", st.ExecutionReport.ClOrdId, (unsigned int)st.ExecutionReport.ClosedQuantity, st.ExecutionReport.OrderStatus);

								_ptrConnectionMgr->SendResponseToQueue(pSession->GetClientId() , &st, ORDER_STATUS_RESPONSE);		
							}

							lstOrderStatusReport.clear();
						}
						
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 14");
						if (bAccountChanged && pResponseAccount)
						{
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 15");
							ParticipantListResponse *pAccountResponse1 = (ParticipantListResponse *)pResponseAccount;
							pAccountResponse1->AccountInfo[0].Balance= pAccount->m_Balance;
							_ptrConnectionMgr->SendResponseToQueue(pSession->GetClientId() , (void *)pAccountResponse1, PARTICIPANT_LIST_RESPONSE);
							
						}

						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 16");

						if (bPositionChanged && pResponsePosition)
						{
							_ptrConnectionMgr->SendResponseToQueue(pSession->GetClientId() , (void *)pResponsePosition, POSITION_RESPONSE);
						}
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 17");
					}

					if (pResponse)
						free(pResponse);

					if (pResponseAccount)
						free(pResponseAccount);

					if (pResponsePosition)
						free(pResponsePosition);

					pAccount->ReleaseSessionCS();

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::ExecutionRptHandler, 18");
				}
				else
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::run, Response is NULL");
			}

			pAccount->ReleaseLockAcc();
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::run, OrderID/Account Not Found/loaded, Order ID is::%s", _ptrReport->ClOrdId);
		}
	}
	//catch(std::exception ex)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::Run, Exception in Function, %s", ex.what());
	//}
	//catch (...)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ExecutionRptHandler::Run, Exception in Function,");
	//}
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : ExecutionRptHandler::Run, Exception in Function,");
    }
}


bool ExecutionRptHandler::AutoDelete()
{
	return true;
}

int ExecutionRptHandler::MarkupAllPrices(ExecutionReport *pReport, IAccount *pAcc, bool bUP, SymbolSpread& sp)
{
	int nSuccess = ERR_OK;

	nSuccess = _ptrAccountMgr->GetMarkupPrice(pReport->Symbol,
												pReport->Side,
												bUP,
												pReport->LastPx,
												pReport->LastPx,
												pAcc->m_nGroup,
												sp);

	if (nSuccess == ERR_OK)
	{
		pReport->AvgPx = pReport->LastPx;
	}

	nSuccess = _ptrAccountMgr->GetMarkupPrice(pReport->Symbol,
												pReport->Side,
												bUP,
												pReport->Price,
												pReport->Price,
												pAcc->m_nGroup,
												sp);

	nSuccess = _ptrAccountMgr->GetMarkupPrice(pReport->Symbol,
												pReport->Side,
												bUP,
												pReport->StopPx,
												pReport->StopPx,
												pAcc->m_nGroup,
												sp);


	return nSuccess;
}
