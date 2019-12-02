////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date		Resource		Ticket No					Desc
//
//	9 Dec 23013	BR				TradingApplication/80		Added function ProcessModifyAccountNoRequest
//	10 Dec 2013	BR				TradingApplication/80		Modified fn ProcessModifyAccountNoRequest to add Account
//															No update in DB.
//	11 Dec 2013	BR				TradingApplication/5		Modified Function ProcessCancelReplaceOrder to add IP
//															address to DB from where the request came
//
//
////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "StdAfx.h"
#include "OrderHandler.h"
#include "ExecutionrptHandler.h"
#include "errorDefs.h"
#include "TradeBOAPI.h"
#include "OMSAPI.h"
#include "IRoute.h"
#include "xlogger.h"
#include <ATLCOMTime.h>
#include <Windows.h>
#include <exception>

OrderHandler::OrderHandler(int reqType, 
							void *ptrRequest, 
							IConnectionMgr *ptrConnectionMgr, 
							IDatabase *ptrDatabase, 
							IAccountMgr *pAccountMgr,
							IRoute *pRoute,
							DWORD dwCookie,
							unsigned int ClientID)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::OrderHandler, Entered");

	_ptrOrder = NULL;
	_ptrConnectionMgr = ptrConnectionMgr;
	
	_ptrDatabase = ptrDatabase;
	_ptrAccountMgr = pAccountMgr;
	_ptrRoute = pRoute;
	m_dwCookie = dwCookie;
	m_pRequest = ptrRequest;
	m_ReqType = reqType;
	m_ClientID = ClientID;

	switch (reqType)
	{
	case NEW_ORDER_REQUEST:
		_ptrOrder = CreateOrderObject();

		_ptrOrder->Init(((NewOrderRequest *)ptrRequest)->order, _ptrDatabase, NEW_ORDER_REQUEST);
		break;
	case LINKED_ORDER_REQUEST:
		_ptrOrder = CreateOrderObject();

		_ptrOrder->Init(((NewLinkedOrderRequest *)ptrRequest)->order[0], _ptrDatabase, NEW_ORDER_REQUEST);
		break;
	case MODIFY_ACCOUNT_OF_TRADE:
		_ptrOrder = CreateOrderObject();

		_ptrOrder->Init(((ModifyAccountNoOfTrade *)ptrRequest)->order, _ptrDatabase, NEW_ORDER_REQUEST);
	}
}

OrderHandler::~OrderHandler(void)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::~OrderHandler, Destructor");
	
	if (_ptrRoute)
		delete _ptrRoute;
}

void OrderHandler::Run ()
{
	if (m_ReqType == NEW_ORDER_REQUEST)
	{
		ProcessNewOrder();
	}
	else if (m_ReqType == ORDER_CANCEL_REQUEST)
	{
		ProcessCancelOrder();
	}
	else if (m_ReqType == ORDER_REPLACE_REQUEST)
	{
		ProcessCancelReplaceOrder();
	}
	else if (m_ReqType == LINKED_ORDER_REQUEST)
	{
		ProcessLinkedOrder();
	}
	else if (m_ReqType == MODIFY_ACCOUNT_OF_TRADE)
	{
		ProcessModifyAccountNoRequest();
	}
	else if (m_ReqType == POSITION_REQUEST)
	{
		ProcessPositionRequest();
	}
	else if (m_ReqType == RELOAD_DPR)
	{
		ProcessReloadDPR();
	}
}


bool OrderHandler::AutoDelete()
{
	return false;
}


void OrderHandler::ProcessPositionRequest()
{
	__try
	{
		PositionRequest *pRequest = (PositionRequest *)m_pRequest;

		if (pRequest)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,1");
			IAccount *pAcc = _ptrAccountMgr->GetIAccount(pRequest->Account);

			if (!pAcc)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,2");
				// User not logged in
				//nSuccess = USER_NOT_LOGGEDIN;
			}
			else
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,3");
				pAcc->AcquireLockAcc();
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,4");
				pAcc->ProcessPositionRequest(m_ClientID, _ptrConnectionMgr);
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,5");
				pAcc->ReleaseLockAcc();
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessPositionRequest, ,6");
			}
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessPositionRequest, Exception in Function,");
	}
}

void OrderHandler::ProcessModifyAccountNoRequest()
{
	// this won't work in case of markups in either of the accounts.
	int nSuccess = 0;
	void *pResponse = NULL;
	unsigned long long OrderID = 0;
	char szClOrdID[32];
	unsigned long long LastPx = 0;
	unsigned long OldAccountNo =0;

	__try
	{
		ModifyAccountNoOfTrade *pRequest = (ModifyAccountNoOfTrade *)m_pRequest;

		if (pRequest)
		{
			IAccount *pAcc = _ptrAccountMgr->GetIAccount(pRequest->NewAccount);

			if (!pAcc)
			{
				// User not logged in
				nSuccess = USER_NOT_LOGGEDIN;
			}
			else
			{
				if (pAcc->m_nEnableTrade && _ptrAccountMgr->IsGroupEnabled(pAcc->m_nGroup))
				{
					CoInitializeEx(NULL, COINIT_MULTITHREADED);
					CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

					IContractManager *pContractManager;
					pToGITTest.CopyTo(&pContractManager);

					pAcc->AcquireLockAcc();

					pAcc->m_pDatabase = _ptrDatabase;
					
					IClientSession *pSession = _ptrConnectionMgr->GetClientSession(m_ClientID);

					if (pSession)
					{
						_ptrOrder->SetIPAddress(pSession->GetClientIp());
					}

					SymbolSpread sp;
					memset(&sp, 0, sizeof(sp));
					
					_ptrAccountMgr->GetSpreadInfo(_ptrOrder->m_Order.Symbol, sp, pAcc->m_nGroup);

					LastPx = _ptrOrder->m_Order.Price;
					memcpy(szClOrdID, _ptrOrder->m_Order.ClOrdId, sizeof(szClOrdID));
					OrderID = _ptrOrder->m_Order.OrderID;
					OldAccountNo =_ptrOrder->m_Order.Account;
					_ptrOrder->m_Order.Account = pRequest->NewAccount;

					// Process RMS
					nSuccess = pAcc->ProcessNewOrder(_ptrOrder, sp.lfFees, sp.lfTax , pContractManager);

					// Process ORS
					if (nSuccess == ERR_OK)
					{
						// Create an Execution Report and pass the price that is filled
						OrderStatusResponse *msg = (OrderStatusResponse *)GetMessageObject(ORDER_STATUS_RESPONSE);

						if (msg)
						{
							memcpy(&msg->ExecutionReport, &_ptrOrder->m_Order, sizeof(Order));
							memcpy(&msg->ExecutionReport.Symbol, &_ptrOrder->m_Order.Symbol, sizeof(_ptrOrder->m_Order.Symbol));
							msg->ExecutionReport.ExecTransType = EXECUTION_TRANSTYPE_NEW;
							msg->ExecutionReport.ExecType = EXECUTION_TRANSTYPE_NEW;
							msg->ExecutionReport.OrderStatus = ORDER_STATUS_NEW;
							msg->ExecutionReport.QtyFilled = _ptrOrder->m_Order.OrderQty;
							msg->ExecutionReport.CumQty = _ptrOrder->m_Order.OrderQty;
							msg->ExecutionReport.LastPx = LastPx;
							msg->ExecutionReport.AvgPx = LastPx;
							msg->ExecutionReport.TransactTime = COleDateTime::GetCurrentTime();

							msg->ExecutionReport.OrderID = OrderID;

							IRequest* ptrIRequest = new ExecutionRptHandler(ORDER_STATUS_RESPONSE, msg, _ptrConnectionMgr, _ptrDatabase, _ptrAccountMgr, m_dwCookie);						

							if (ptrIRequest)
							{
								ptrIRequest->Run();

								// Update the DB with the order detail
								ITable* tb=CreateTable();

								if (tb)
								{
									IParameter* param=CreateParameter();

									if (param)
									{
										param->AddParam("OldAccountID", OldAccountNo);
										param->AddParam("NewAccountID", pRequest->NewAccount);
										param->AddParam("OldClOrderID", szClOrdID, sizeof(szClOrdID));
										param->AddParam("NewClOrderID", _ptrOrder->m_Order.ClOrdId, sizeof(_ptrOrder->m_Order.ClOrdId));

										bool isSPExist = _ptrDatabase->Execute("Exchange_UpdateClientCode",*tb,*param);//execute sp

										if( !isSPExist )
										{
											stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessModifyAccountNoRequest, Unable to execute SP Exchange_UpdateClientCode");
											nSuccess = ERR_INTERNAL_ERROR;
										}
									}

									ReleaseParameter(param);//release parameter object
								}

								delete ptrIRequest;
							}
						}
						else
						{
							// rejection Message Response
							nSuccess = ERR_INTERNAL_ERROR;
						}
					}

					pAcc->ReleaseLockAcc();
				}
				else
				{
					nSuccess = ERR_ACCOUNT_DISABLED;
				}

			}

			if (nSuccess != ERR_OK)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Generate business Reject");
				GenerateBusinessLevelReject(m_ReqType, _ptrOrder->m_Order.ClOrdId, nSuccess, sizeof(_ptrOrder->m_Order.ClOrdId));
			}
		}
		else
		{
		}
	}
	/*catch(std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Exception in Function, %s", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Exception in Function,");
	}*/
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
        stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessNewOrder, Exception in Function,");
    }
}

void OrderHandler::ProcessNewOrder()
{
	int nSuccess = 0;
	void *pResponse = NULL;

	__try
	{
		IAccount *pAcc = _ptrAccountMgr->GetIAccount(_ptrOrder->m_Order.Account);

		if (!pAcc)
		{
			// User not logged in
			nSuccess = USER_NOT_LOGGEDIN;
		}
		else
		{
			if (pAcc->m_nEnableTrade && _ptrAccountMgr->IsGroupEnabled(pAcc->m_nGroup))
			{
				CoInitializeEx(NULL, COINIT_MULTITHREADED);
				CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

				IContractManager *pContractManager;
				pToGITTest.CopyTo(&pContractManager);

				pAcc->AcquireLockAcc();

				pAcc->m_pDatabase = _ptrDatabase;
				
				IClientSession *pSession = _ptrConnectionMgr->GetClientSession(m_ClientID);

				if (pSession)
				{
					_ptrOrder->SetIPAddress(pSession->GetClientIp());
				}

				nSuccess = _ptrOrder->ProcessOrder(pResponse, pContractManager);	
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, _ptrOrder->ToString().c_str());

				if (nSuccess == MM_PRE_SESSION)
				{
					if (pAcc->IsMMAccount())
					{
						nSuccess = ERR_OK;
					}
					else
					{
						nSuccess = SESSION_IS_CLOSED;
					}
				}
				
				if (nSuccess == ERR_OK)
				{
					// Put the execution report to the queue to send it to client
					//SendResponseToAllAssociatedClients(_ptrOrder->m_Order.Account, pResponse, ORDER_STATUS_RESPONSE);

					SymbolSpread sp;
					memset(&sp, 0, sizeof(sp));
					
					_ptrAccountMgr->GetSpreadInfo(_ptrOrder->m_Order.Symbol, sp, pAcc->m_nGroup);

					int success = 0;
					do
					{
						// Process RMS
						success = pAcc->ProcessNewOrder(_ptrOrder, sp.lfFees, sp.lfTax , pContractManager);

						// Process ORS
						if (success == ERR_OK || success == 99)
						{
							if (_ptrOrder->m_Order.LnkdOrdId[0] != '\0')
							{
								//pAcc->AddLinkedOrder(_ptrOrder->m_Order.LnkdOrdId, _ptrOrder);
								pAcc->AddOCOOrders(_ptrOrder->m_Order.LnkdOrdId, _ptrOrder);
							}

							if (_ptrOrder->OrderStatus != ORDER_STATUS_REJECTED)
							{
								_ptrAccountMgr->AddToClOrderIDIAccountMap(_ptrOrder->m_Order.ClOrdId, pAcc);
							}
							
							unsigned long long ulMarkupPrice = 0;
							unsigned long long ulMarkupStopPx = 0;

							// Manage the markup price
							nSuccess = MarkupAllPrices(_ptrOrder, pAcc, true, sp, ulMarkupPrice, ulMarkupStopPx);

							if (nSuccess == ERR_OK)
							{
								std::string LPName = _ptrOrder->m_Order.Symbol.Gateway;
								// Send order for further processing
								nSuccess = _ptrRoute->RouteOrder(_ptrOrder, LPName, ulMarkupPrice, ulMarkupStopPx);
							}

							if (success == 99)
							{/*
								if (_ptrOrder->m_Order.Side == SIDE_SELL)
								{
									success = 999;
									nSuccess = 999;
									break;
								}
								else
								{*/
									IOrder *pSplitOrder = CreateOrderObject();

									if (pSplitOrder)
									{
										pSplitOrder->SetIPAddress("127.0.0.1");
										pSplitOrder->m_pDatabase = _ptrDatabase;
										memcpy(&pSplitOrder->m_Order, &_ptrOrder->m_Order, sizeof(_ptrOrder->m_Order));
										pSplitOrder->m_Order.OrderQty = _ptrOrder->m_ulQtyClosed;
										pSplitOrder->GetTaggedOrderList().clear();
										pSplitOrder->QtyClose = 0;
										pSplitOrder->QtySettled = 0;
										pSplitOrder->m_Order.PositionEffect = POSITION_OPENING_TRADE;

										_ptrOrder = pSplitOrder;
									}
								//}
							}
							/*else if (success == 999)
							{
								nSuccess = 999;
								break;
							}*/

						}
						else
						{
							nSuccess = success;
						}
					}while (success == 99);
				}

				pAcc->ReleaseLockAcc();
			}
			else
			{
				nSuccess = ERR_ACCOUNT_DISABLED;
			}

		}

		if (nSuccess != ERR_OK)
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Generate business Reject");
			GenerateBusinessLevelReject(m_ReqType, _ptrOrder->m_Order.ClOrdId, nSuccess, sizeof(_ptrOrder->m_Order.ClOrdId));
		}
	}
	/*catch(std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Exception in Function, %s", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Exception in Function,");
	}*/
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
        stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessNewOrder, Exception in Function,");
    }
}

void OrderHandler::ProcessCancelOrder()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelOrder, Entered");

	int nSuccess = 0;
	void *pResponse = NULL;

	__try
	{
		OrderCancelRequest *pCancelRequest = (OrderCancelRequest *)m_pRequest;

		if (pCancelRequest)
		{
			IAccount *pAcc = _ptrAccountMgr->GetIAccount(pCancelRequest->order.Account);

			if (!pAcc)
			{
				// User not logged in
				nSuccess = USER_NOT_LOGGEDIN;
			}
			else
			{
				if (pAcc->m_nEnableTrade && _ptrAccountMgr->IsGroupEnabled(pAcc->m_nGroup))
				{
					CoInitializeEx(NULL, COINIT_MULTITHREADED);
					CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

					IContractManager *pContractManager;
					pToGITTest.CopyTo(&pContractManager);

					pAcc->AcquireLockAcc();

					pAcc->m_pDatabase = _ptrDatabase;

					nSuccess = pAcc->GetWorkingOrder(_ptrOrder, pCancelRequest->order.ClOrdId);
					
					if (nSuccess == ERR_OK && _ptrOrder)
					{
						nSuccess = _ptrOrder->ProcessCancelOrder(pResponse);
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, _ptrOrder->ToString().c_str());

						if (nSuccess == MM_PRE_SESSION)
						{
							if (pAcc->IsMMAccount())
							{
								nSuccess = ERR_OK;
							}
							else
							{
								nSuccess = SESSION_IS_CLOSED;
							}

						}


						if (nSuccess == ERR_OK)
						{
							/*std::string strAltSymbol1;
							std::string strAltProduct1;

							CComBSTR strContract(_ptrOrder->m_Order.Symbol.Contract);
							CComBSTR strGateway(_ptrOrder->m_Order.Symbol.Gateway);
							CComBSTR strAltSymbol(strAltSymbol1.c_str());
							CComBSTR strAltProductName(strAltProduct1.c_str());

							pContractManager->GetAltSymbol(strGateway.Detach(), strContract.Detach(), &strAltSymbol, &strAltProductName);
							
							std::string xx = _bstr_t(strAltSymbol);
							std::string xx1 = _bstr_t(strAltProductName);

							strcpy(_ptrOrder->m_Order.Symbol.Contract, xx.c_str());
							strcpy(_ptrOrder->m_Order.Symbol.Product, xx1.c_str());*/

							// Put the execution report to the queue to send it to client
							//SendResponseToAllAssociatedClients(_ptrOrder->m_Order.Account, pResponse, ORDER_STATUS_RESPONSE);
							// Send order for further processing
							
							OrderCancelRequest *pReq = (OrderCancelRequest *)m_pRequest;

							SymbolSpread sp;
							memset(&sp, 0, sizeof(sp));
							
							_ptrAccountMgr->GetSpreadInfo(_ptrOrder->m_Order.Symbol, sp, pAcc->m_nGroup);

							unsigned long long ulMarkupPrice = 0;
							unsigned long long ulMarkupStopPx = 0;

							// Manage the markup price
							nSuccess = MarkupAllPrices(_ptrOrder, pAcc, true, sp, ulMarkupPrice, ulMarkupStopPx);

							if (pReq)
							{
								pReq->order.OrderID = _ptrOrder->m_Order.OrderID;
								std::string strGateway = _ptrOrder->m_Order.Symbol.Gateway;
								nSuccess = _ptrRoute->RouteCancelOrder(m_pRequest,  strGateway, ulMarkupPrice, ulMarkupStopPx);
							}
						}
					}

					pAcc->ReleaseLockAcc();
				}
			}

			if (nSuccess != ERR_OK)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelOrder, Generate business Reject");
				GenerateBusinessLevelReject(m_ReqType, pCancelRequest->order.ClOrdId, nSuccess, sizeof(pCancelRequest->order.ClOrdId));			
			}
		}
	}
	/*catch(std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelOrder, Exception in Function, %s", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelOrder, Exception in Function,");
	}*/
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
        stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessCancelOrder, Exception in Function,");
    }
}

void OrderHandler::ProcessLinkedOrder()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Entered");

	int nSuccess = 0;
	void *pResponse = NULL;

	__try
	{
		IAccount *pAcc = _ptrAccountMgr->GetIAccount(_ptrOrder->m_Order.Account);

		if (!pAcc)
		{
			// User not logged in
			nSuccess = USER_NOT_LOGGEDIN;
		}
		else
		{
			if (pAcc->m_nEnableTrade && _ptrAccountMgr->IsGroupEnabled(pAcc->m_nGroup))
			{
				CoInitializeEx(NULL, COINIT_MULTITHREADED);
				CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

				IContractManager *pContractManager;
				pToGITTest.CopyTo(&pContractManager);

				pAcc->AcquireLockAcc();

				pAcc->m_pDatabase = _ptrDatabase;
				
				IClientSession *pSession = _ptrConnectionMgr->GetClientSession(m_ClientID);

				if (pSession)
				{
					_ptrOrder->SetIPAddress(pSession->GetClientIp());
				}

				nSuccess = _ptrOrder->ProcessOrder(pResponse, pContractManager);	
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, _ptrOrder->ToString().c_str());

				if (nSuccess == ERR_OK)
				{
					// Put the execution report to the queue to send it to client
					//SendResponseToAllAssociatedClients(_ptrOrder->m_Order.Account, pResponse, ORDER_STATUS_RESPONSE);

					SymbolSpread sp;
					memset(&sp, 0, sizeof(sp));
					
					_ptrAccountMgr->GetSpreadInfo(_ptrOrder->m_Order.Symbol, sp, pAcc->m_nGroup);

					// Process RMS
					nSuccess = pAcc->ProcessNewOrder(_ptrOrder, sp.lfFees, sp.lfTax , pContractManager);

					// Process ORS
					if (nSuccess == ERR_OK)
					{
						NewLinkedOrderRequest * pLinkedRequest = (NewLinkedOrderRequest *)m_pRequest;

						if (pLinkedRequest)
						{
							for (int nCount = 1; nCount < pLinkedRequest->nNoOfOrders; nCount ++)
							{
								IOrder *pOrder1 = CreateOrderObject();

								if (pOrder1)
								{
									pOrder1->Init(((NewLinkedOrderRequest *)m_pRequest)->order[nCount], _ptrDatabase, NEW_ORDER_REQUEST);

									pAcc->AddLinkedOrder(_ptrOrder->m_Order.ClOrdId, pOrder1);
								}
							}
						}

						if (nSuccess == ERR_OK)
						{
							// We will do it later
							// Send order for further processing
							//nSuccess = _ptrRoute->RouteOrder(_ptrOrder, pAcc->GetAssociatedLPName());
						}
					}
				}

				pAcc->ReleaseLockAcc();
			}
			else
			{
				nSuccess = ERR_ACCOUNT_DISABLED;
			}

		}

		if (nSuccess != ERR_OK)
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessNewOrder, Generate business Reject");
			GenerateBusinessLevelReject(m_ReqType, _ptrOrder->m_Order.ClOrdId, nSuccess, sizeof(_ptrOrder->m_Order.ClOrdId));
		}
	}
	/*catch(std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessLinkedOrder, Exception in Function, %s", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessLinkedOrder, Exception in Function,");
	}*/
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
        stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessLinkedOrder, Exception in Function,");
    }
}

void OrderHandler::ProcessCancelReplaceOrder()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelReplaceOrder, Entered");

	int nSuccess = 0;
	void *pResponse = NULL;

	__try
	{
		OrderReplaceRequest *pReplaceRequest = (OrderReplaceRequest *)m_pRequest;

		if (pReplaceRequest)
		{
			IAccount *pAcc = _ptrAccountMgr->GetIAccount(pReplaceRequest->OldOrder.Account);

			if (!pAcc)
			{
				// User not logged in
				nSuccess = USER_NOT_LOGGEDIN;
			}
			else
			{
				if (pAcc->m_nEnableTrade && _ptrAccountMgr->IsGroupEnabled(pAcc->m_nGroup))
				{
					CoInitializeEx(NULL, COINIT_MULTITHREADED);
					CComGITPtr<IContractManager>pToGITTest(m_dwCookie);

					IContractManager *pContractManager;
					pToGITTest.CopyTo(&pContractManager);

					pAcc->AcquireLockAcc();

					pAcc->m_pDatabase = _ptrDatabase;

					nSuccess = pAcc->GetWorkingOrder(_ptrOrder, pReplaceRequest->OldOrder.ClOrdId);
					
					if (nSuccess == ERR_OK && _ptrOrder)
					{
						// Create new IOrder
						IOrder *pNewOrder = CreateOrderObject();

						if (pNewOrder)
						{
							nSuccess = pNewOrder->Init(pReplaceRequest->NewOrder, _ptrDatabase, m_ReqType);

							if (nSuccess == ERR_OK)
							{
								IClientSession *pSession = _ptrConnectionMgr->GetClientSession(m_ClientID);

								if (pSession)
								{
									pNewOrder->SetIPAddress(pSession->GetClientIp());
								}

								nSuccess = pNewOrder->ProcessCancelReplaceOrder(pResponse, _ptrOrder, pContractManager);
								stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, _ptrOrder->ToString().c_str());

								if (nSuccess == MM_PRE_SESSION)
								{
									if (pAcc->IsMMAccount())
									{
										nSuccess = ERR_OK;
									}
									else
									{
										nSuccess = SESSION_IS_CLOSED;
									}

								}


								if (nSuccess == ERR_OK)
								{
									// Put the execution report to the queue to send it to client
									//SendResponseToAllAssociatedClients(_ptrOrder->m_Order.Account, pResponse, ORDER_STATUS_RESPONSE);
									SymbolSpread sp;
									memset(&sp, 0, sizeof(sp));
									
									_ptrAccountMgr->GetSpreadInfo(_ptrOrder->m_Order.Symbol, sp, pAcc->m_nGroup);

									nSuccess = pAcc->ProcessCROrder(_ptrOrder, pNewOrder, sp.lfFees, sp.lfTax, pContractManager);

									if (nSuccess == ERR_OK)
									{
										unsigned long long ulMarkupPrice = 0;
										unsigned long long ulMarkupStopPx = 0;

										if (pNewOrder->OrderStatus != ORDER_STATUS_REJECTED)
										{
											_ptrAccountMgr->AddToClOrderIDIAccountMap(pNewOrder->m_Order.ClOrdId, pAcc);
										}

										// Manage the markup price
										nSuccess = MarkupAllPrices(pNewOrder, pAcc, true, sp, ulMarkupPrice, ulMarkupStopPx);

										unsigned long long ulOldMarkupPrice = 0;
										unsigned long long ulOldMarkupStopPx = 0;

										// Manage the markup price
										nSuccess = MarkupAllPrices(_ptrOrder, pAcc, true, sp, ulOldMarkupPrice,ulOldMarkupStopPx );

										if (nSuccess == ERR_OK)
										{
											std::string strGateway = _ptrOrder->m_Order.Symbol.Gateway;
											// Send order for further processing
											nSuccess = _ptrRoute->RouteCROrder(_ptrOrder, pNewOrder, strGateway, ulMarkupPrice, ulMarkupStopPx, ulOldMarkupPrice, ulOldMarkupStopPx);
										}
									}
								}
							}
						}
						else
						{
							nSuccess = ERR_INTERNAL_ERROR;
						}
					}

					pAcc->ReleaseLockAcc();
				}
			}

			if (nSuccess != ERR_OK)
			{
				GenerateBusinessLevelReject(m_ReqType, pReplaceRequest->OldOrder.ClOrdId, nSuccess, sizeof(pReplaceRequest->OldOrder.ClOrdId));
			}
		}
	}
	/*catch(std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelReplaceOrder, Exception in Function, %s", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::ProcessCancelReplaceOrder, Exception in Function,");
	}*/
	 __except(EXCEPTION_EXECUTE_HANDLER)
    {
        stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "FATAL ERROR : OrderHandler::ProcessLinkedOrder, Exception in Function,");
    }
}


void OrderHandler::GenerateBusinessLevelReject(unsigned int            RefMsgType,
											char*                   BusinessRejectRefID,
											int						BusinessRejectReason,
											int						size)
{
	// Generate business reject message
	BusinessLevelReject *pReject = (BusinessLevelReject *)GetMessageObject(BUSINESS_LEVEL_REJECT);

	if (pReject)
	{
		pReject->RefMsgType = RefMsgType;

		if (BusinessRejectReason <= INVALID_USERID_PWD && BusinessRejectReason > ERR_INTERNAL_ERROR_DB)
		{
			strcpy(pReject->Text, szError[INVALID_USERID_PWD - BusinessRejectReason]);
		}

		if (BusinessRejectReason == 999)
		{
			strcpy(pReject->Text, "Not enough Positions to Sell");
		}

		pReject->BusinessRejectReason = BusinessRejectReason;
		memcpy(pReject->BusinessRejectRefID, BusinessRejectRefID, size);
		_ptrConnectionMgr->SendResponseToQueue(m_ClientID, (void *)pReject, BUSINESS_LEVEL_REJECT);

		free(pReject);
	}
}

void OrderHandler::SendResponseToAllAssociatedClients(unsigned long Account, void *pResponse, int msgType)
{
	//std::list<IClientSession *> lstSession;


	//if (_ptrAccountMgr->GetClientSessions(Account, lstSession))
	//{
	//	std::list<IClientSession *>::iterator iter = lstSession.begin();

	//	for (;iter != lstSession.end(); iter++)
	//	{
	//		IClientSession *pSession = (*iter);

	//		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::SendResponseToAllAssociatedClients, Send response to Client=%u", pSession->GetClientId());
	//		_ptrConnectionMgr->SendResponseToQueue(pSession->GetClientId() , pResponse, msgType);
	//	}
	//}
	//else
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OrderHandler::SendResponseToAllAssociatedClients, Not able to get clientsessions list");

	//_ptrAccountMgr->ReleaseCS_ACC_USER_LIST_MAP();
	//_ptrAccountMgr->ReleaseUSER_SESSION_LIST_MAP();
}

int OrderHandler::MarkupAllPrices(IOrder *pOrder, IAccount *pAcc, bool bUP, SymbolSpread& sp, unsigned long long& ulMarkedupPrice, unsigned long long& ulMarkedupStopPx)
{
	int nSuccess = ERR_OK;

	nSuccess = _ptrAccountMgr->GetMarkupPrice(pOrder->m_Order.Symbol,
												pOrder->m_Order.Side,
												bUP,
												pOrder->m_Order.Price,
												ulMarkedupPrice,
												pAcc->m_nGroup,
												sp);

	if (nSuccess == ERR_OK && (_ptrOrder->m_Order.OrderType == ORDER_TYPE_STOP_LIMIT_ORDER || _ptrOrder->m_Order.OrderType == ORDER_TYPE_STOP_ORDER))
	{
		nSuccess = _ptrAccountMgr->GetMarkupPrice(pOrder->m_Order.Symbol,
													pOrder->m_Order.Side,
													bUP,
													pOrder->m_Order.StopPx,
													ulMarkedupStopPx,
													pAcc->m_nGroup,
													sp);
	}

	return nSuccess;
}

void OrderHandler::ProcessReloadDPR()
{
	_ptrRoute->RouteReloadDPRRequest(m_pRequest);
}