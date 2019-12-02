////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Date			Initials			Desc
//05 Feb 2014		BR					Tradingapplication/114.
//										Modify following
//										1. Modified Login and Logout responses to include username
//										2. Modify the QuotesStream and SnapshotResponse to include AccountNo
//										Modified accepted version to 1.15
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "StdAfx.h"
#include "OMSRequests.h"
#include "errorDefs.h"
#include "xlogger.h"
#include "time.h"


OMSRequestHandler::OMSRequestHandler(unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession, IDatabase *ptrDatabase)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::OMSRequestHandler, Entered");

	_ptrConnectionMgr = ptrConnectionMgr;
	_ptrAccountMgr = ptrAccountMgr;
	_ptrDatabaseOMS = ptrDatabase;
	
	_reqType = reqType;
	_ptrRequest = (void *) ptrRequest;
	_ptrSession = ptrSession;
}

OMSRequestHandler::~OMSRequestHandler(void)
{
}

void OMSRequestHandler::Run ()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::Run, Entered");
	unsigned respType;
	void *ptrResponse = NULL;
	bool isValid = false;

	if (_reqType == PARTICIPANT_LIST_REQUEST)
	{
		ParticipantListRequest *pRequest = (ParticipantListRequest *)_ptrRequest;

		if (pRequest)
		{
			std::list<IAccount *> lstAccList;

			std::string xx(pRequest->UserName);

			lstAccList = _ptrSession->GetAccountList();

			GenerateAndSendParticipantListResponse(lstAccList, xx);
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::Run, Unable to allocate memory for Participant List");
		}
	}
	else if (_reqType == TRADE_HISTORY_REQUEST)
	{
		TradeHistoryRequest *pRequest = (TradeHistoryRequest *)_ptrRequest;

		if (pRequest)
		{
			GenerateAndSendTradeHistoryResponse(pRequest);
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::Run, Unable to allocate memory for Trade history request");
		}
	}
	else if (_reqType == POSITION_REQUEST)
	{
		PositionRequest *pRequest = (PositionRequest *)_ptrRequest;

		if (pRequest)
		{
			GenerateAndSendPositionResponse(pRequest);
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::Run, Unable to allocate memory for Position Response");
		}
	}
	else if (_reqType == ORDER_HISTORY_REQUEST)
	{
		OrderHistoryRequest *pRequest = (OrderHistoryRequest *)_ptrRequest;

		if (pRequest)
		{
			GenerateAndSendOrderHistoryResponse(pRequest);
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::Run, Unable to allocate memory for OrderHistory Response");
		}
	}
	else if (_reqType == CHANGE_PASSWORD)
	{
		ChangePassword(_ptrRequest);
	}
	else if (_reqType == MAIL_DELIVERY)
	{
		DeliverMail(_ptrRequest);
	}
	else if (_reqType == ACCOUNT_UPDATE_REQUEST)
	{
		AccountUpdate(_ptrRequest);
	}
	else if (_reqType == TRADE_MGMT_REQUEST)
	{
		EnableAccounts(_ptrRequest);
	}
	else if (_reqType == RELOAD_CONFIG)
	{
		ReloadConfiguration *pRequest = (ReloadConfiguration *)_ptrRequest;

		if (pRequest)
		{
			ReloadConfig(pRequest->type);
		}
	}
	//else if (_reqType == ORDER_BOOK_REQUEST)
	//{
	//	OrderBookRequest *pRequest = (OrderBookRequest *)_ptrRequest;

	//	GenerateAndSendOrderBookResponse(pRequest);
	//}
	//else if (_reqType == STOP_ORDER_REQUEST)
	//{
	//	/*StopOrderRequest *pRequest = (StopOrderRequest *)_ptrRequest;

	//	GenerateAndSendStopOrdersResponse(pRequest);*/
	//}
	//else if (_reqType == MATCHED_ORDER_REQUEST)
	//{
	//	MatchedOrderRequest *pRequest = (MatchedOrderRequest *)_ptrRequest;
	//}

}


bool OMSRequestHandler::AutoDelete()
{
	return false;
}

void OMSRequestHandler::ChangePassword(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::ChangePassword, Entered");

	ChangePasswordRequest *ptrRequest = (ChangePasswordRequest *)pRequest;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("LoginId",ptrRequest->UserName, sizeof(ptrRequest->UserName));
	param->AddParam("OldMasterPassword",ptrRequest->OldMasterPassword, sizeof(ptrRequest->OldMasterPassword));
	param->AddParam("NewMasterPassword",ptrRequest->NewMasterPassword, sizeof(ptrRequest->NewMasterPassword));
	param->AddParam("NewTradingPassword",ptrRequest->NewTradingPassword, sizeof(ptrRequest->NewTradingPassword));
	
	bool isSPExist = _ptrDatabaseOMS->Execute("Exchange_ChangePassword",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::ChangePassword, Could not execute SP BO_ChangePassword");
		return ;
	}	

	int acc = 0;
	while(!tb->IsEOF())//loop the table
	{
		tb->Get("PID", acc);
		break;
	}

	ChangePasswordResponse *pResponse = (ChangePasswordResponse *)GetMessageObject(CHANGE_PASSWORD_RESPONSE);

	if (pResponse)
	{
		memcpy(pResponse->UserName, ptrRequest->UserName, sizeof(ptrRequest->UserName));
		if (acc > 0)
		{
			pResponse->IsPasswordChanged = true;
		}
		else
		{
			pResponse->IsPasswordChanged = false;
			if (acc <= INVALID_USERID_PWD && acc > ERR_INTERNAL_ERROR_DB)
			{
				strcpy(pResponse->Reason, szError[INVALID_USERID_PWD - acc]);
			}
			else
				strcpy(pResponse->Reason, "Password Not changed");
		}

		_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, CHANGE_PASSWORD_RESPONSE);
		free (pResponse);
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void OMSRequestHandler::GenerateAndSendTradeHistoryResponse(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendTradeHistoryResponse, Entered");

	TradeHistoryRequest *ptrRequest = (TradeHistoryRequest *)pRequest;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("AccountID",(unsigned int)ptrRequest->Account);
	
	bool isSPExist = _ptrDatabaseOMS->Execute("OMS_GetTradeHistory",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendTradeHistoryResponse, Could not execute SP OMS_GetOrderHistory");
		return ;
	}	

	TradeHistoryResponse *pResponse;
	pResponse = (TradeHistoryResponse *)GetMessageObject(TRADE_HISTORY_RESPONSE);
	
	if (pResponse)
	{
		int count = 0;
		char szVal[2];

		while (!tb->IsEOF())
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendTradeHistoryResponse  IsEOF");
			tb->Get("FillId", pResponse->TradeHistory[count].ExecID, sizeof(pResponse->TradeHistory[count].ExecID));
			tb->Get("PK_OrderID", pResponse->TradeHistory[count].OrderID);
			tb->Get("ClOrdID", pResponse->TradeHistory[count].ClOrdId, sizeof(pResponse->TradeHistory[count].ClOrdId));
			tb->Get("AccountID", pResponse->TradeHistory[count].Account);
			tb->Get("OrderQty", pResponse->TradeHistory[count].OrdQty);
			tb->Get("Price", pResponse->TradeHistory[count].Price);
			
			tb->Get("OrderType", szVal, sizeof(szVal));
			pResponse->TradeHistory[count].OrderType = szVal[0];

			tb->Get("OrderStatus", szVal, sizeof(szVal));
			pResponse->TradeHistory[count].OrderStatus = szVal[0];

			tb->Get("Side", szVal, sizeof(szVal));
			pResponse->TradeHistory[count].Side = szVal[0];

			tb->Get("ProviderName", pResponse->TradeHistory[count].Symbol.Gateway, sizeof(pResponse->TradeHistory[count].Symbol.Gateway));
			//tb->Get("ExchangeName", pResponse->TradeHistory[count].Symbol.Exchange, sizeof(pResponse->TradeHistory[count].Symbol.Exchange));
			tb->Get("ContractName", pResponse->TradeHistory[count].Symbol.Contract, sizeof(pResponse->TradeHistory[count].Symbol.Contract));
			tb->Get("ProductName", pResponse->TradeHistory[count].Symbol.Product, sizeof(pResponse->TradeHistory[count].Symbol.Product));
			
			tb->Get("ProductType", szVal, sizeof(szVal));
			pResponse->TradeHistory[count].Symbol.ProductType = szVal[0];

			tb->Get("TIF", szVal, sizeof(szVal));
			pResponse->TradeHistory[count].TimeInForce = szVal[0];

			tb->GetDateTime("LastUpdateTime", pResponse->TradeHistory[count].TransactTime);
			
			tb->Get("FilledQty", pResponse->TradeHistory[count].CumQty);
			tb->Get("LeaveQty", pResponse->TradeHistory[count].LeavesQty);

			double Avgpxs = 0;
			tb->Get("AvgFillPrice", Avgpxs);
			pResponse->TradeHistory[count].AvgPx = Avgpxs;

			tb->Get("FillPrice", pResponse->TradeHistory[count].LastPx);

			tb->GetDateTime("FilledTime", pResponse->TradeHistory[count].TransactTime);
			tb->Get("Commission", pResponse->TradeHistory[count].Commission);
			tb->Get("Tax", pResponse->TradeHistory[count].Tax);
			tb->Get("SettledQty", pResponse->TradeHistory[count].ClosedQuantity);
      tb->Get("Profit", pResponse->TradeHistory[count].Profit);
			//tb->Get("CounterAvgPrice", pResponse->TradeHistory[count].);
			//tb->Get("Tax", pResponse->TradeHistory[count].Tax);
			//tb->GetDateTime("GTD", pResponse->TradeHistory[count].ExpireDate);

			//time_t tm = pResponse->TradeHistory[count].TransactTime;	
			pResponse->TradeHistory[count].ExpireDate =pResponse->TradeHistory[count].TransactTime;

			tb->MoveNext();

			count++;

			if (count >= MAX_TRADE_HISTORY)
			{
				pResponse->NoOfOrders = count;

				if (tb->IsEOF())
				{
					pResponse->Header.KeyDataCtrlBlk = 1;

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendTradeHistoryResponse, Last block");
				}
				
				_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, TRADE_HISTORY_RESPONSE);

				//memset(pResponse, 0, sizeof(TradeHistoryResponse));
				count =0;
			}
		}

		if (count > 0)
		{
			pResponse->NoOfOrders = count;
			pResponse->Header.KeyDataCtrlBlk = 1;
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, TRADE_HISTORY_RESPONSE);
			count =0;
		}

		free(pResponse);
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}


void OMSRequestHandler::GenerateAndSendPositionResponse(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendPositionResponse, Entered");

	PositionRequest *ptrRequest = (PositionRequest *)pRequest;

	if (pRequest)
	{

	}

	//ITable* tb=CreateTable();
	//IParameter* param=CreateParameter();
	//param->AddParam("AccountID",(unsigned int)ptrRequest->Account);
	
	//bool isSPExist = _ptrDatabaseOMS->Execute("OMS_GetPositionInfoByAccountID",*tb,*param);//execute sp
	//if( !isSPExist )
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendPositionResponse, Could not execute SP OMS_GetPositionInfoByAccountID");
	//	return ;
	//}	

	//PositionResponse *pResponse;
	//pResponse = (PositionResponse *)GetMessageObject(POSITION_RESPONSE);
	//
	//if (pResponse)
	//{
	//	char productType[10];
	//	int count = 0;

	//	while (!tb->IsEOF())
	//	{
	//		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendPositionResponse  IsEOF");
	//		tb->Get("ContractName", pResponse->Position[count].Symbol.Contract, sizeof(pResponse->Position[count].Symbol.Contract));
	//		tb->Get("ProductName", pResponse->Position[count].Symbol.Product, sizeof(pResponse->Position[count].Symbol.Product));
	//		tb->Get("ProductType", productType, sizeof(productType));
	//		pResponse->Position[count].Symbol.ProductType = productType[0];
	//		tb->Get("ProviderName", pResponse->Position[count].Symbol.Gateway, sizeof(pResponse->Position[count].Symbol.Gateway));
	//		//tb->Get("ExchangeName", pResponse->Position[count].Symbol.Exchange, sizeof(pResponse->Position[count].Symbol.Exchange));
	//		tb->Get("BuyQty", pResponse->Position[count].BuyQty);
	//		tb->Get("SellQty", pResponse->Position[count].SellQty);
	//		tb->Get("BuyPrice", pResponse->Position[count].BuyAvg);
	//		tb->Get("SellPrice", pResponse->Position[count].SellAvg);
	//		tb->Get("Net_Position", pResponse->Position[count].NetQty);
	//		tb->Get("Net_PnL", pResponse->Position[count].NetPrice);
	//		tb->Get("BuyVal", pResponse->Position[count].BuyVal);
	//		tb->Get("SellVal", pResponse->Position[count].SellVal);

	//		pResponse->Position[count].Account = ptrRequest->Account;
	//		pResponse->Position[count].NetVal = ((double)pResponse->Position[count].BuyVal) - pResponse->Position[count].SellVal;

	//		tb->MoveNext();

	//		count++;

	//		if (count >= MAX_POSITION)
	//		{
	//			pResponse->NoOfPosition = count;

	//			if (tb->IsEOF())
	//			{
	//				pResponse->Header.KeyDataCtrlBlk = 1;
	//			}

	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendPositionResponse, Count = %d", count);
	//			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, POSITION_RESPONSE);
	//			count =0;
	//		}

	//	}

	//	if (count > 0)
	//	{
	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendPositionResponse, Count = %d", count);
	//		pResponse->Header.KeyDataCtrlBlk = 1;
	//		pResponse->NoOfPosition = count;
	//		_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, POSITION_RESPONSE);
	//		count =0;
	//	}

	//	free(pResponse);
	//}

	//ReleaseTable(tb);//release table object
	//ReleaseParameter(param);//release parameter object
}

void OMSRequestHandler::GenerateAndSendOrderBookResponse(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderBookResponse, Entered");

	OrderBookRequest *ptrRequest = (OrderBookRequest *)pRequest;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("Price", ptrRequest->Price);
	
	bool isSPExist = _ptrDatabaseOMS->Execute("OMS_GetListOfOrdersForMarketPictureLevel",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderBookResponse, Could not execute SP OMS_GetListOfOrdersForMarketPictureLevel");
		return ;
	}	

	OrderBookResponse *pResponse;
	pResponse = (OrderBookResponse *)GetMessageObject(ORDER_BOOK_RESPONSE);

	if (pResponse)
	{
		int count = 0;

		char szVal[2];
		while (!tb->IsEOF())
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendOrderBookResponse  IsEOF");
			//memset(&pResponse->OrderHistory[count], 0, sizeof(pResponse->OrderHistory[count]));
			tb->Get("PK_OrderID", pResponse->OrderHistory[count].OrderID);
			tb->Get("ClOrdID", pResponse->OrderHistory[count].ClOrdId, sizeof(pResponse->OrderHistory[count].ClOrdId));
			tb->Get("OrigOrdID", pResponse->OrderHistory[count].OrigClOrdId, sizeof(pResponse->OrderHistory[count].OrigClOrdId));
			tb->Get("AccountID", pResponse->OrderHistory[count].Account);
			tb->Get("PositionSize", pResponse->OrderHistory[count].OrdQty);
			tb->Get("Price", pResponse->OrderHistory[count].Price);
			tb->Get("StopPx", pResponse->OrderHistory[count].StopPx);

			tb->Get("OrderType", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].OrderType = szVal[0];

			tb->Get("Side", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].Side = szVal[0];

			tb->Get("OrderStatus", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].OrderStatus = szVal[0];
			
			tb->GetDateTime("OrderDateTimeRequested", pResponse->OrderHistory[count].TransactTime);
			//tb->Get("ProviderName", pResponse->OrderHistory[count].Symbol.Provider, sizeof(pResponse->OrderHistory[count].Symbol.Provider));
			//tb->Get("ExchangeName", pResponse->OrderHistory[count].Symbol.Exchange, sizeof(pResponse->OrderHistory[count].Symbol.Exchange));
			tb->Get("ContractName", pResponse->OrderHistory[count].Symbol.Contract, sizeof(pResponse->OrderHistory[count].Symbol.Contract));
			tb->Get("ProductName", pResponse->OrderHistory[count].Symbol.Product, sizeof(pResponse->OrderHistory[count].Symbol.Product));
			
			tb->Get("ProductType", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].Symbol.ProductType= szVal[0];

			tb->Get("TIF", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].TimeInForce = szVal[0];

			tb->Get("FilledQty", pResponse->OrderHistory[count].CumQty);
			tb->Get("LeaveQty", pResponse->OrderHistory[count].LeavesQty);
			double AvgPx = 0;
			tb->Get("AvgFillPrice", AvgPx);
			pResponse->OrderHistory[count].AvgPx = AvgPx;
			tb->GetDateTime("GTD", pResponse->OrderHistory[count].ExpireDate);

			//tb->Get("CancelQty", pResponse->OrderHistory[count].);

			tb->MoveNext();

			count++;

			if (count >= MAX_ORDER_HISTORY)
			{
				pResponse->NoOfOrders = count;

				if (tb->IsEOF())
				{
					pResponse->Header.KeyDataCtrlBlk = 1;
				}

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderBookResponse, Count = %d", count);
				_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, ORDER_BOOK_RESPONSE);
				count =0;
			}

		}

		if (count > 0)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderBookResponse, Count = %d", count);
			pResponse->Header.KeyDataCtrlBlk = 1;
			pResponse->NoOfOrders = count;
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, ORDER_HISTORY_RESPONSE);
			count =0;
		}

		free (pResponse);
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object
}

void OMSRequestHandler::GenerateAndSendStopOrdersResponse(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendStopOrdersResponse, Entered");

	//StopOrderRequest *ptrRequest = (StopOrderRequest *)pRequest;

	//ITable* tb=CreateTable();
	//IParameter* param=CreateParameter();
	////param->AddParam("Price", ptrRequest->Price);
	//
	//bool isSPExist = _ptrDatabaseOMS->Execute("OMS_GetListOfStopOrders",*tb,*param);//execute sp
	//if( !isSPExist )
	//{
	//	return ;
	//}	

	//StopOrderResponse *pResponse;
	//pResponse = (StopOrderResponse *)GetMessageObject(STOP_ORDER_RESPONSE);
	//
	//int count = 0;

	//char szVal[2];
	//while (!tb->IsEOF())
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendStopOrdersResponse  IsEOF");
	//	//memset(&pResponse->OrderHistory[count], 0, sizeof(pResponse->OrderHistory[count]));
	//	tb->Get("PK_OrderID", pResponse->OrderHistory[count].OrderID);
	//	tb->Get("ClOrdID", pResponse->OrderHistory[count].ClOrdId, sizeof(pResponse->OrderHistory[count].ClOrdId));
	//	tb->Get("OrigOrdID", pResponse->OrderHistory[count].OrigClOrdId, sizeof(pResponse->OrderHistory[count].OrigClOrdId));
	//	tb->Get("AccountID", pResponse->OrderHistory[count].Account);
	//	tb->Get("PositionSize", pResponse->OrderHistory[count].OrdQty);
	//	tb->Get("Price", pResponse->OrderHistory[count].Price);
	//	tb->Get("StopPx", pResponse->OrderHistory[count].StopPx);

	//	tb->Get("OrderType", szVal, sizeof(szVal));
	//	pResponse->OrderHistory[count].OrderType = szVal[0];

	//	tb->Get("Side", szVal, sizeof(szVal));
	//	pResponse->OrderHistory[count].Side = szVal[0];

	//	/*tb->Get("OrderStatus", szVal, sizeof(szVal));
	//	pResponse->OrderHistory[count].OrderStatus = szVal[0];*/
	//	
	//	tb->GetDateTime("OrderDateTimeRequested", pResponse->OrderHistory[count].TransactTime);
	//	//tb->Get("ProviderName", pResponse->OrderHistory[count].Symbol.Provider, sizeof(pResponse->OrderHistory[count].Symbol.Provider));
	//	//tb->Get("ExchangeName", pResponse->OrderHistory[count].Symbol.Exchange, sizeof(pResponse->OrderHistory[count].Symbol.Exchange));
	//	tb->Get("ContractName", pResponse->OrderHistory[count].Symbol.Contract, sizeof(pResponse->OrderHistory[count].Symbol.Contract));
	//	tb->Get("ProductName", pResponse->OrderHistory[count].Symbol.Product, sizeof(pResponse->OrderHistory[count].Symbol.Product));
	//	
	//	tb->Get("ProductType", szVal, sizeof(szVal));
	//	pResponse->OrderHistory[count].Symbol.ProductType= szVal[0];

	//	tb->Get("TIF", szVal, sizeof(szVal));
	//	pResponse->OrderHistory[count].TimeInForce = szVal[0];

	//	tb->Get("FilledQty", pResponse->OrderHistory[count].CumQty);
	//	tb->Get("LeaveQty", pResponse->OrderHistory[count].LeavesQty);
	//	double AvgPx = 0;
	//	tb->Get("AvgFillPrice", AvgPx);
	//	pResponse->OrderHistory[count].AvgPx = AvgPx;
	//	tb->GetDateTime("GTD", pResponse->OrderHistory[count].ExpireDate);
	//	//tb->Get("CancelQty", pResponse->OrderHistory[count].);

	//	tb->MoveNext();

	//	count++;

	//	if (count >= MAX_ORDER_HISTORY)
	//	{
	//		pResponse->NoOfOrders = count;
	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendStopOrdersResponse, Count = %d", count);
	//		_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, STOP_ORDER_RESPONSE);
	//		count =0;
	//	}

	//}

	//if (count > 0)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendStopOrdersResponse, Count = %d", count);
	//	pResponse->NoOfOrders = count;
	//	_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, STOP_ORDER_RESPONSE);
	//	count =0;
	//}
}

void OMSRequestHandler::GenerateAndSendMatchedOrdersResponse(void *pRequest)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendMatchedOrdersResponse, Entered");

	//MatchedOrderRequest *ptrRequest = (MatchedOrderRequest *)pRequest;

	//ITable* tb=CreateTable();
	//IParameter* param=CreateParameter();
	////param->AddParam("Price", ptrRequest->Price);

	//IDatabase * pDatabase = CreateDatabase(); 

	//if (pDatabase)
	//{
	//	if( ! pDatabase->Open( "sa" , "admin123@" , "Provider=sqloledb;Data Source= 192.168.1.152, 1433;Initial Catalog=OME;" ) )
	//	{
	//		ReleaseDatabase( pDatabase );
	//		pDatabase = NULL;

	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Unable to open OME DB");
	//	}
	//}
	//
	//bool isSPExist = pDatabase->Execute("OME_GetMapOrderForAccountID",*tb,*param);//execute sp
	//if( !isSPExist )
	//{
	//	return ;
	//}	

	//MatchedOrderResponse *pResponse;
	//pResponse = (MatchedOrderResponse *)GetMessageObject(MATCHED_ORDER_RESPONSE);
	//
	//int count = 0;

	//char szVal[2];
	//while (!tb->IsEOF())
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendMatchedOrdersResponse  IsEOF");
	//	//memset(&pResponse->OrderHistory[count], 0, sizeof(pResponse->OrderHistory[count]));
	//	//tb->Get("PK_OrderID", pResponse->OrderHistory[count].OrderID);
	//	//tb->Get("ClOrdID", pResponse->OrderHistory[count].ClOrdId, sizeof(pResponse->OrderHistory[count].ClOrdId));
	//	//tb->Get("OrigOrdID", pResponse->OrderHistory[count].OrigClOrdId, sizeof(pResponse->OrderHistory[count].OrigClOrdId));
	//	//tb->Get("AccountID", pResponse->OrderHistory[count].Account);
	//	//tb->Get("PositionSize", pResponse->OrderHistory[count].OrdQty);
	//	//tb->Get("Price", pResponse->OrderHistory[count].Price);
	//	//tb->Get("StopPx", pResponse->OrderHistory[count].StopPx);

	//	//tb->Get("OrderType", szVal, sizeof(szVal));
	//	//pResponse->OrderHistory[count].OrderType = szVal[0];

	//	//tb->Get("Side", szVal, sizeof(szVal));
	//	//pResponse->OrderHistory[count].Side = szVal[0];

	//	///*tb->Get("OrderStatus", szVal, sizeof(szVal));
	//	//pResponse->OrderHistory[count].OrderStatus = szVal[0];*/
	//	//
	//	//tb->GetDateTime("OrderDateTimeRequested", pResponse->OrderHistory[count].TransactTime);
	//	////tb->Get("ProviderName", pResponse->OrderHistory[count].Symbol.Provider, sizeof(pResponse->OrderHistory[count].Symbol.Provider));
	//	////tb->Get("ExchangeName", pResponse->OrderHistory[count].Symbol.Exchange, sizeof(pResponse->OrderHistory[count].Symbol.Exchange));
	//	//tb->Get("ContractName", pResponse->OrderHistory[count].Symbol.Contract, sizeof(pResponse->OrderHistory[count].Symbol.Contract));
	//	//tb->Get("ProductName", pResponse->OrderHistory[count].Symbol.Product, sizeof(pResponse->OrderHistory[count].Symbol.Product));
	//	//
	//	//tb->Get("ProductType", szVal, sizeof(szVal));
	//	//pResponse->OrderHistory[count].Symbol.ProductType= szVal[0];

	//	//tb->Get("TIF", szVal, sizeof(szVal));
	//	//pResponse->OrderHistory[count].TimeInForce = szVal[0];

	//	//tb->Get("FilledQty", pResponse->OrderHistory[count].CumQty);
	//	//tb->Get("LeaveQty", pResponse->OrderHistory[count].LeavesQty);
	//	//double AvgPx = 0;
	//	//tb->Get("AvgFillPrice", AvgPx);
	//	//pResponse->OrderHistory[count].AvgPx = AvgPx;
	//	//tb->GetDateTime("GTD", pResponse->OrderHistory[count].ExpireDate);
	//	//tb->Get("CancelQty", pResponse->OrderHistory[count].);

	//	tb->MoveNext();

	//	count++;

	//	if (count >= MAX_MATCHED_ORDER)
	//	{
	//		pResponse->NoOfMatchedOrder = count;
	//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendMatchedOrdersResponse, Count = %d", count);
	//		_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, MATCHED_ORDER_RESPONSE);
	//		count =0;
	//	}

	//}

	//if (count > 0)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendMatchedOrdersResponse, Count = %d", count);
	//	pResponse->NoOfMatchedOrder = count;
	//	_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, MATCHED_ORDER_RESPONSE);
	//	count =0;
	//}

	//ReleaseTable(tb);
	//ReleaseDatabase(pDatabase);

}


void OMSRequestHandler::GenerateAndSendOrderHistoryResponse(void *pRequest)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderHistoryResponse, Entered");
	OrderHistoryRequest *ptrRequest = (OrderHistoryRequest *)pRequest;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("AccountID", (unsigned int)ptrRequest->Account);
	
	bool isSPExist = _ptrDatabaseOMS->Execute("OMS_GetOrderHistory_New",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderHistoryResponse, Could not execute SP OMS_GetListOfOrdersForMarketPictureLevel");
		return ;
	}	

	OrderHistoryResponse *pResponse;
	pResponse = (OrderHistoryResponse *)GetMessageObject(ORDER_HISTORY_RESPONSE);

	if (pResponse)
	{
		//memset(pResponse, 0, sizeof(OrderHistoryResponse));
		int count = 0;

		char szVal[2];
		while (!tb->IsEOF())
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in OMSRequestHandler::GenerateAndSendOrderHistoryResponse  IsEOF");
			//memset(&pResponse->OrderHistory[count], 0, sizeof(pResponse->OrderHistory[count]));
			tb->Get("PK_OrderID", pResponse->OrderHistory[count].OrderID);
			tb->Get("ClOrdID", pResponse->OrderHistory[count].ClOrdId, sizeof(pResponse->OrderHistory[count].ClOrdId));
			tb->Get("OrigOrdID", pResponse->OrderHistory[count].OrigClOrdId, sizeof(pResponse->OrderHistory[count].OrigClOrdId));
			tb->Get("AccountID", pResponse->OrderHistory[count].Account);
			tb->Get("PositionSize", pResponse->OrderHistory[count].OrdQty);
			tb->Get("Price", pResponse->OrderHistory[count].Price);
			tb->Get("StopPx", pResponse->OrderHistory[count].StopPx);

			tb->Get("OrderType", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].OrderType = szVal[0];

			tb->Get("OrderStatus", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].OrderStatus = szVal[0];
			
			tb->Get("Side", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].Side = szVal[0];

			tb->GetDateTime("OrderDateTimeRequested", pResponse->OrderHistory[count].TransactTime);
			tb->Get("ProviderName", pResponse->OrderHistory[count].Symbol.Gateway, sizeof(pResponse->OrderHistory[count].Symbol.Gateway));
			//tb->Get("ExchangeName", pResponse->OrderHistory[count].Symbol.Exchange, sizeof(pResponse->OrderHistory[count].Symbol.Exchange));
			tb->Get("ContractName", pResponse->OrderHistory[count].Symbol.Contract, sizeof(pResponse->OrderHistory[count].Symbol.Contract));
			tb->Get("ProductName", pResponse->OrderHistory[count].Symbol.Product, sizeof(pResponse->OrderHistory[count].Symbol.Product));
			
			tb->Get("ProductType", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].Symbol.ProductType= szVal[0];

			tb->Get("TIF", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].TimeInForce = szVal[0];

			tb->Get("FilledQty", pResponse->OrderHistory[count].CumQty);
			tb->Get("LeaveQty", pResponse->OrderHistory[count].LeavesQty);
			double AvgPx = 0;
			tb->Get("AvgFillPrice", AvgPx);
			pResponse->OrderHistory[count].AvgPx = AvgPx;
			tb->GetDateTime("GTD", pResponse->OrderHistory[count].ExpireDate);
			tb->Get("Commission", pResponse->OrderHistory[count].Commission);
			//pResponse->OrderHistory[count].TradeDate
			tb->Get("Tax", pResponse->OrderHistory[count].Tax);
			tb->Get("PositionEffect", szVal, sizeof(szVal));
			pResponse->OrderHistory[count].PositionEffect = szVal[0];

			tb->Get("QtyClosed", pResponse->OrderHistory[count].ClosedQuantity);
			tb->Get("StopLoss", pResponse->OrderHistory[count].StopLoss);
			tb->Get("TakeProfit", pResponse->OrderHistory[count].TakeProfit);
			tb->Get("ClosePrice", pResponse->OrderHistory[count].ClosePrice);
			tb->Get("SLOrdID", pResponse->OrderHistory[count].StopLossId, sizeof(pResponse->OrderHistory[count].StopLossId));
			tb->Get("TPOrdID", pResponse->OrderHistory[count].TakeProfitId, sizeof(pResponse->OrderHistory[count].TakeProfitId));
			tb->Get("Profit", pResponse->OrderHistory[count].Profit);

			//pResponse->OrderHistory[count].TransactTime = 0;
			//tb->Get("CancelQty", pResponse->OrderHistory[count].);

			pResponse->OrderHistory[count].TradeDate = pResponse->OrderHistory[count].TransactTime;		

			tb->MoveNext();

			count++;

			if (count >= MAX_ORDER_HISTORY)
			{
				pResponse->NoOfOrders = count;

				if (tb->IsEOF())
				{
					pResponse->Header.KeyDataCtrlBlk = 1;
				}

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderHistoryResponse, Count = %d", count);
				_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, ORDER_HISTORY_RESPONSE);

				//memset(pResponse, 0, sizeof(OrderHistoryResponse));
				count =0;
			}

		}

		if (count > 0)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendOrderHistoryResponse, Count = %d", count);
			pResponse->Header.KeyDataCtrlBlk = 1;
			pResponse->NoOfOrders = count;
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), (void *)pResponse, ORDER_HISTORY_RESPONSE);
			count =0;
		}

		free(pResponse);
	}

	ReleaseTable(tb);
}

void OMSRequestHandler::GenerateAndSendParticipantListResponse(std::list<IAccount *>& lstAccount, std::string& strUserName)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendParticipantListResponse, Entered");

	int nCount = lstAccount.size();
	int count  = 0;
	int nTotalcount = 0;
	std::list<IAccount *>::iterator iter;

	ParticipantListResponse *pResponse;
	pResponse = (ParticipantListResponse *)GetMessageObject(PARTICIPANT_LIST_RESPONSE);

	if (pResponse)
	{
		
		for (iter = lstAccount.begin();iter != lstAccount.end();iter++)
		{
			IAccount *pAccount = *iter;

			pAccount->AcquireLockAcc();
			//memcpy((void *)&pResponse->AccountInfo[count],(void *) &pAccount->m_Account, sizeof(AccountInfo));

			pResponse->AccountInfo[count].Account = pAccount->m_Account;
			pResponse->AccountInfo[count].Active = pAccount->m_nEnableTrade;
			pResponse->AccountInfo[count].Balance = pAccount->m_Balance;
			pResponse->AccountInfo[count].BuySideTurnOver = pAccount->m_lfBuyTurnover;
			//pResponse->AccountInfo[count].FreeMargin = pAccount->m_lfFreeMargin;
			pResponse->AccountInfo[count].Group = pAccount->m_nGroup;
			pResponse->AccountInfo[count].HedgingType= pAccount->m_nHedgingType;
			pResponse->AccountInfo[count].Leverage = pAccount->m_nLeverage;
			//pResponse->AccountInfo[count].Margin= pAccount->m_lfMargin;
			//pResponse->AccountInfo[count].ReservedMargin = pAccount->m_lfReservedMargin;
			pResponse->AccountInfo[count].SellSideturnOver = pAccount->m_lfSellTurnover;
			pResponse->AccountInfo[count].UsedMargin = pAccount->m_lfUsedMargin;
			pResponse->AccountInfo[count].MarginCall1 = pAccount->m_nMarginCall1;
			pResponse->AccountInfo[count].MarginCall2 = pAccount->m_nMarginCall2;
			pResponse->AccountInfo[count].MarginCall3 = pAccount->m_nMarginCall3;
			pResponse->AccountInfo[count].LotSize = pAccount->m_lfLotSize;

			strcpy(pResponse->AccountInfo[count].TraderName, pAccount->m_strTraderName.c_str());
			strcpy(pResponse->AccountInfo[count].AccountType, pAccount->m_strAccountType.c_str());

			count++;
			nTotalcount++;

			if (count >= MAX_ACCOUNT_INFO)
			{
				pResponse->NoOfParticipants = count;

				
				//std::list<IAccount *>::iterator iter1=iter;

				if (nCount == nTotalcount )
				{
					
					// The pkt is last one to be sent.
					pResponse->Header.KeyDataCtrlBlk = 1;
				}

				memcpy(pResponse->UserName, strUserName.c_str(), sizeof(pResponse->UserName));
				_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(),(void *)pResponse, PARTICIPANT_LIST_RESPONSE);
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendParticipantListResponse, inner Participants=%d", count);
				count = 0;
			}
			pAccount->ReleaseLockAcc();
		}

		if (count > 0)
		{
			pResponse->NoOfParticipants = count;
			pResponse->Header.KeyDataCtrlBlk = 1;
			memcpy(pResponse->UserName, strUserName.c_str(), sizeof(pResponse->UserName));
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendParticipantListResponse, Participants=%d", count);
			_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(),(void *)pResponse, PARTICIPANT_LIST_RESPONSE);
		}

		free (pResponse);
	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::GenerateAndSendParticipantListResponse, Entered");
}

void OMSRequestHandler::DeliverMail(void *pRequest)
{
	 //Store it in DB
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	MailDelivery *pMail = (MailDelivery *)pRequest;

	if (pMail)
	{
		param->AddParam("userID", pMail->MailContent.UserName, sizeof(pMail->MailContent.UserName));
		param->AddParam("Recipient", pMail->MailContent.To, sizeof(pMail->MailContent.To));
		param->AddParam("Subject", pMail->MailContent.subject, sizeof(pMail->MailContent.subject));
		param->AddParam("Description", pMail->MailContent.Body, sizeof(pMail->MailContent.Body));
		
		bool isSPExist = _ptrDatabaseOMS->Execute("Exchange_InsertMailInfo",*tb,*param);//execute sp
		if( !isSPExist )
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "OMSRequestHandler::DeliverMail, Could not execute SP WS_Exchange_InsertMailInfo");
			return ;
		}	

		while (!tb->IsEOF())
		{
			char logId[8];
			tb->Get("LoginId", logId, sizeof(logId));

			if (pMail)
			{
				_ptrConnectionMgr->SendResponseToQueue(logId, pRequest, MAIL_DELIVERY);
			}

			tb->MoveNext();
		}	

		ReleaseTable(tb);
	}

}

void OMSRequestHandler::AccountUpdate(void *pRequest)
{
	int nSuccess = ERR_OK;

	AccountUpdateRequest *pAccountUpdate = (AccountUpdateRequest *)pRequest;

	if (pAccountUpdate)
	{
		IAccount *pAccount = _ptrAccountMgr->GetIAccount(pAccountUpdate->AccountNo);

		if (pAccount)
		{
			// The account is in memory, so update the balance.
			nSuccess = pAccount->UpdateBalance(pAccountUpdate->Amount);

			AccountUpdateResponse *pResponse = (AccountUpdateResponse *)GetMessageObject(ACCOUNT_UPDATE_RESPONSE);

			if (pResponse)
			{
				pResponse->AccountNo = pAccountUpdate->AccountNo;
				pResponse->ErrNo = nSuccess;

				_ptrConnectionMgr->SendResponseToQueue(_ptrSession->GetClientId(), pResponse, ACCOUNT_UPDATE_RESPONSE);

				free(pResponse);
			}
		}
	}
}

void OMSRequestHandler::EnableAccounts(void *pRequest)
{
	TradeMgmtRequest *ptrRequest = (TradeMgmtRequest *)pRequest;

	if (ptrRequest)
	{
		_ptrAccountMgr->EnableAccounts(ptrRequest->Id, ptrRequest->bEnable);
	}
}

void OMSRequestHandler::ReloadConfig(char type)
{
	if (type == RELOAD_MARKUP)
	{
		_ptrAccountMgr->ReLoadAllGroupSymbolSpread();
	}
	else if (type == RELOAD_GRP_ENABLED_LIST)
	{
		_ptrAccountMgr->LoadAllEnabledGroups();
	}
}
