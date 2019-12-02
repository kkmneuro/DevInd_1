
#include "stdafx.h"
#include "JSONHandler.h"
#include "DataDef.h"
#include "ServerProtocolImpl.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "atltime.h"

#include <cpprest/http_client.h>
#include <cpprest/filestream.h>

using namespace utility;                    // Common utilities like string conversions
using namespace web;                        // Common features like URIs.
using namespace web::http;                  // Common HTTP functionality
using namespace web::http::client;          // HTTP client features
using namespace concurrency::streams;       // Asynchronous streams



JSONHandler::JSONHandler()
{
}


JSONHandler::~JSONHandler()
{
}

void* JSONHandler::GetObjectFromJSON(char *buff, unsigned int size1, int &msgtype)
{
	void *pObject = NULL;

	try
	{
		USES_CONVERSION;

		utility::stringstream_t ss1;
		wstring str = CA2W(buff);
		string strVal;
		ss1 << str;

		json::value v1 = json::value::parse(ss1);

		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON Enter. JSON = %s", buff);
		int size = v1.size();
		if (size < 0)
			return NULL;

		msgtype = v1.at(L"msgtype").as_integer();

		switch (msgtype)
		{
		case RELOAD_DPR:
		{
			ReloadDPR *pRequest = (ReloadDPR *)GetMessageObject(RELOAD_DPR);

			if (pRequest)
			{
				strVal = W2A(v1.at(L"ProductType").as_string().c_str());
				pRequest->sym1.ProductType = strVal[0];
				strcpy(pRequest->sym1.Product, W2A(v1.at(L"Product").as_string().c_str()));
				strcpy(pRequest->sym1.Contract, W2A(v1.at(L"Contract").as_string().c_str()));
				strcpy(pRequest->sym1.Gateway, W2A(v1.at(L"Gateway").as_string().c_str()));

				pObject = pRequest;
			}

			break;
		}
		case LOGON_REQUEST:
		{
			LogonRequest *pRequest = (LogonRequest *)GetMessageObject(msgtype);
			if (pRequest)
			{
				//memset(pRequest,0,sizeof(LogonRequest));
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON LogonRequest");

				strcpy(pRequest->UserName, W2A(v1.at(L"UserName").as_string().c_str()));
				strcpy(pRequest->Password, W2A(v1.at(L"Password").as_string().c_str()));
				pRequest->Version = v1.at(U("Version")).as_double();
				strcpy(pRequest->Header.SenderID, W2A(v1.at(L"SenderID").as_string().c_str()));
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON LogonRequest");
			}
			break;
		}

		case LOGOUT_REQUEST:
		{
			logoutRequest *pRequest = (logoutRequest *)GetMessageObject(msgtype);
					
			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON logoutRequest");

				strcpy(pRequest->UserName, W2A(v1.at(L"UserName").as_string().c_str()));
				strcpy(pRequest->Password, W2A(v1.at(L"Password").as_string().c_str()));
				strcpy(pRequest->ReasonForLogout, W2A(v1.at(L"ReasonForLogout").as_string().c_str()));
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON logoutRequest");
			}
			break;
		}

		case PARTICIPANT_LIST_REQUEST:
		{
			ParticipantListRequest *pRequest = (ParticipantListRequest *)GetMessageObject(msgtype);
			if (pRequest)
			{
				//memset(pRequest,0,sizeof(LogonRequest));
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON ParticipantListRequest");
				strcpy(pRequest->UserName, W2A(v1.at(L"UserName").as_string().c_str()));
				pObject = (void *)pRequest;
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON ParticipantListRequest");
			}
			break;
		}
		
		case NEW_ORDER_REQUEST:
		{
			NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(msgtype);
			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON NewOrderStart");

				pRequest->order.Account = v1.at(L"Account").as_integer();
				pRequest->order.OrderQty = v1.at(L"OrderQty").as_integer();
				strcpy(pRequest->order.ClOrdId, W2A(v1.at(L"ClOrdId").as_string().c_str()));
				strVal = W2A(v1.at(L"ProductType").as_string().c_str());
				pRequest->order.Symbol.ProductType = strVal[0];
				strcpy(pRequest->order.Symbol.Product, W2A(v1.at(L"Product").as_string().c_str()));
				strcpy(pRequest->order.Symbol.Contract, W2A(v1.at(L"Contract").as_string().c_str()));
				strcpy(pRequest->order.Symbol.Gateway, W2A(v1.at(L"Gateway").as_string().c_str()));

				strVal = W2A(v1.at(L"OrderType").as_string().c_str());
				pRequest->order.OrderType = strVal[0];
				pRequest->order.Price = v1.at(L"Price").as_integer();

				strVal = W2A(v1.at(L"Side").as_string().c_str());
				pRequest->order.Side = strVal[0];

				strVal = W2A(v1.at(L"TimeInForce").as_string().c_str());
				pRequest->order.TimeInForce = strVal[0];

				pRequest->order.StopPx = v1.at(L"StopPx").as_integer();
				//pRequest->order.Price = v1.at(L"Price").as_integer();
				pRequest->order.ExpireDate = 0;
				pRequest->order.TransactTime = 0;
				pRequest->order.OrderID = v1.at(L"OrderID").as_integer();
				strcpy(pRequest->order.origClOrdId, W2A(v1.at(L"origClOrdId").as_string().c_str()));

				strVal = W2A(v1.at(L"PositionEffect").as_string().c_str());
				pRequest->order.PositionEffect = strVal[0];

				strcpy(pRequest->order.LnkdOrdId, W2A(v1.at(L"LnkdOrdId").as_string().c_str()));
				pRequest->order.MinOrDisclosedQty = 0;
				pRequest->order.Slipage = 0;
				pRequest->order.OCOOrder = false;
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON NewOrderStop");
			}
			break;
		}

		case ORDER_CANCEL_REQUEST:
		{
			OrderCancelRequest *pRequest = (OrderCancelRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON OrderCancelRequest");

				pRequest->order.Account = v1.at(L"Account").as_integer();
				pRequest->order.OrderQty = v1.at(L"OrderQty").as_integer();
				strcpy(pRequest->order.ClOrdId, W2A(v1.at(L"ClOrdId").as_string().c_str()));
				strVal = W2A(v1.at(L"ProductType").as_string().c_str());
				pRequest->order.Symbol.ProductType = strVal[0];
				strcpy(pRequest->order.Symbol.Product, W2A(v1.at(L"Product").as_string().c_str()));
				strcpy(pRequest->order.Symbol.Contract, W2A(v1.at(L"Contract").as_string().c_str()));
				strcpy(pRequest->order.Symbol.Gateway, W2A(v1.at(L"Gateway").as_string().c_str()));

				strVal = W2A(v1.at(L"OrderType").as_string().c_str());
				pRequest->order.OrderType = strVal[0];
				pRequest->order.Price = v1.at(L"Price").as_integer();

				strVal = W2A(v1.at(L"Side").as_string().c_str());
				pRequest->order.Side = strVal[0];

				strVal = W2A(v1.at(L"TimeInForce").as_string().c_str());
				pRequest->order.TimeInForce = strVal[0];

				pRequest->order.StopPx = v1.at(L"StopPx").as_integer();
				//pRequest->order.Price = v1.at(L"Price").as_integer();
				pRequest->order.ExpireDate = 0;
				pRequest->order.TransactTime = 0;
				pRequest->order.OrderID = v1.at(L"OrderID").as_integer();
				strcpy(pRequest->order.origClOrdId, W2A(v1.at(L"origClOrdId").as_string().c_str()));

				strVal = W2A(v1.at(L"PositionEffect").as_string().c_str());
				pRequest->order.PositionEffect = strVal[0];

				strcpy(pRequest->order.LnkdOrdId, "");
				pRequest->order.MinOrDisclosedQty = 0;
				pRequest->order.Slipage = 0;
				pRequest->order.OCOOrder = false;
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON OrderCancelRequest");
			}
			break;
		}
			
		case ORDER_REPLACE_REQUEST:
		{
			OrderReplaceRequest *pRequest = (OrderReplaceRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON OrderReplaceRequest");

				pRequest->NewOrder.Account = v1.at(L"Account").as_integer();
				pRequest->NewOrder.OrderQty = v1.at(L"OrderQty").as_integer();
				strcpy(pRequest->NewOrder.ClOrdId, W2A(v1.at(L"ClOrdId").as_string().c_str()));
				strVal = W2A(v1.at(L"ProductType").as_string().c_str());
				pRequest->NewOrder.Symbol.ProductType = strVal[0];
				strcpy(pRequest->NewOrder.Symbol.Product, W2A(v1.at(L"Product").as_string().c_str()));
				strcpy(pRequest->NewOrder.Symbol.Contract, W2A(v1.at(L"Contract").as_string().c_str()));
				strcpy(pRequest->NewOrder.Symbol.Gateway, W2A(v1.at(L"Gateway").as_string().c_str()));

				strVal = W2A(v1.at(L"OrderType").as_string().c_str());
				pRequest->NewOrder.OrderType = strVal[0];
				pRequest->NewOrder.Price = v1.at(L"Price").as_integer();

				strVal = W2A(v1.at(L"Side").as_string().c_str());
				pRequest->NewOrder.Side = strVal[0];

				strVal = W2A(v1.at(L"TimeInForce").as_string().c_str());
				pRequest->NewOrder.TimeInForce = strVal[0];

				pRequest->NewOrder.StopPx = v1.at(L"StopPx").as_integer();
				//pRequest->order.Price = v1.at(L"Price").as_integer();
				pRequest->NewOrder.ExpireDate = 0;
				pRequest->NewOrder.TransactTime = 0;
				pRequest->NewOrder.OrderID = v1.at(L"OrderID").as_integer();
				strcpy(pRequest->NewOrder.origClOrdId, W2A(v1.at(L"origClOrdId").as_string().c_str()));

				strVal = W2A(v1.at(L"PositionEffect").as_string().c_str());
				pRequest->NewOrder.PositionEffect = strVal[0];

				strcpy(pRequest->NewOrder.LnkdOrdId, "");
				pRequest->NewOrder.MinOrDisclosedQty = 0;
				pRequest->NewOrder.Slipage = 0;
				pRequest->NewOrder.OCOOrder = false;

				pRequest->OldOrder.Account = v1.at(L"OldAccount").as_integer();
				pRequest->OldOrder.OrderQty = v1.at(L"OldOrderQty").as_integer();
				strcpy(pRequest->OldOrder.ClOrdId, W2A(v1.at(L"OldClOrdId").as_string().c_str()));
				strVal = W2A(v1.at(L"OldProductType").as_string().c_str());
				pRequest->OldOrder.Symbol.ProductType = strVal[0];
				strcpy(pRequest->OldOrder.Symbol.Product, W2A(v1.at(L"OldProduct").as_string().c_str()));
				strcpy(pRequest->OldOrder.Symbol.Contract, W2A(v1.at(L"OldContract").as_string().c_str()));
				strcpy(pRequest->OldOrder.Symbol.Gateway, W2A(v1.at(L"OldGateway").as_string().c_str()));

				strVal = W2A(v1.at(L"OldOrderType").as_string().c_str());
				pRequest->OldOrder.OrderType = strVal[0];
				pRequest->OldOrder.Price = v1.at(L"OldPrice").as_integer();

				strVal = W2A(v1.at(L"OldSide").as_string().c_str());
				pRequest->OldOrder.Side = strVal[0];

				strVal = W2A(v1.at(L"OldTimeInForce").as_string().c_str());
				pRequest->OldOrder.TimeInForce = strVal[0];

				pRequest->OldOrder.StopPx = v1.at(L"OldStopPx").as_integer();
				//pRequest->order.Price = v1.at(L"Price").as_integer();
				pRequest->OldOrder.ExpireDate = 0;
				pRequest->OldOrder.TransactTime = 0;
				pRequest->OldOrder.OrderID = v1.at(L"OldOrderID").as_integer();
				strcpy(pRequest->OldOrder.origClOrdId, W2A(v1.at(L"OldorigClOrdId").as_string().c_str()));

				strVal = W2A(v1.at(L"OldPositionEffect").as_string().c_str());
				pRequest->OldOrder.PositionEffect = strVal[0];

				strcpy(pRequest->OldOrder.LnkdOrdId, "");
				pRequest->OldOrder.MinOrDisclosedQty = 0;
				pRequest->OldOrder.Slipage = 0;
				pRequest->OldOrder.OCOOrder = false;
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON OrderReplaceRequest");
			}
			break;
		}
		
		case ACCOUNT_REQUEST:
		{
			AccountRequest *pRequest = (AccountRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON AccountRequest");

				pRequest->Account = v1.at(L"Account").as_integer();
				strVal = W2A(v1.at(L"Subscribe").as_string().c_str());
				pRequest->Subscribe = strVal[0];
				strcpy(pRequest->Header.SenderID, W2A(v1.at(L"SenderID").as_string().c_str()));
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON AccountRequest");
			}
			break;
		}
		
		case POSITION_REQUEST:
		{
			PositionRequest *pRequest = (PositionRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON PositionRequest");

				pRequest->Account = v1.at(L"Account").as_integer();
				strVal = W2A(v1.at(L"Subscribe").as_string().c_str());
				pRequest->Subscribe = strVal[0];
				strcpy(pRequest->Header.SenderID, W2A(v1.at(L"SenderID").as_string().c_str()));

				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON PositionRequest");
			}
			break;
		}

		case TRADE_HISTORY_REQUEST:
		{
			TradeHistoryRequest *pRequest = (TradeHistoryRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeHistoryRequest");

				pRequest->Account = v1.at(L"Account").as_integer();
				strVal = W2A(v1.at(L"Filter").as_string().c_str());
				pRequest->Filter = strVal[0];
				strcpy(pRequest->Header.SenderID, W2A(v1.at(L"SenderID").as_string().c_str()));

				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeHistoryRequest");
			}
			break;
		}

		case ORDER_HISTORY_REQUEST:
		{
			orderHistoryRequest *pRequest = (orderHistoryRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeHistoryRequest");

				pRequest->Account = v1.at(L"Account").as_integer();
				strVal = W2A(v1.at(L"Filter").as_string().c_str());
				pRequest->Filter = strVal[0];
				strcpy(pRequest->Header.SenderID, W2A(v1.at(L"SenderID").as_string().c_str()));

				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeHistoryRequest");
			}
			break;
		}

		case QUOTE_SUBSCRIPTION_REQUEST:
		{
			QuoteSubscriptionRequest *pRequest = (QuoteSubscriptionRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON QuoteSubscriptionRequest");
				pRequest->NoOfSymbols = v1.at(L"NoOfSymbols").as_integer();
				
				json::value v2 = v1.at(L"Symbol").array();

				for (int i = 0; pRequest->NoOfSymbols; i++)
				{
					strVal = W2A(v2[i].at(L"ProductType").as_string().c_str());
					pRequest->Symbol[i].ProductType = strVal[0];
					strcpy(pRequest->Symbol[i].Product, W2A(v2[i].at(L"Product").as_string().c_str()));
					strcpy(pRequest->Symbol[i].Contract, W2A(v2[i].at(L"Contract").as_string().c_str()));
					strcpy(pRequest->Symbol[i].Gateway, W2A(v2[i].at(L"Gateway").as_string().c_str()));
				}
										
				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON QuoteSubscriptionRequest");
			}
			break;
		}
		
		case QUOTE__REQUEST:
		{
			QuoteRequest *pRequest = (QuoteRequest *)GetMessageObject(msgtype);
			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON QuoteRequest");

				pRequest->NoOfSymbols = v1.at(L"NoOfSymbols").as_integer();
				pRequest->isForSubscribe = v1.at(L"isForSubscribe").as_integer();
				
				json::value v2 = v1.at(L"Symbol").array();

				for (int i = 0; pRequest->NoOfSymbols; i++)
				{
					strVal = W2A(v2[i].at(L"ProductType").as_string().c_str());
					pRequest->Symbol[i].ProductType = strVal[0];
					strcpy(pRequest->Symbol[i].Product, W2A(v2[i].at(L"Product").as_string().c_str()));
					strcpy(pRequest->Symbol[i].Contract, W2A(v2[i].at(L"Contract").as_string().c_str()));
					strcpy(pRequest->Symbol[i].Gateway, W2A(v2[i].at(L"Gateway").as_string().c_str()));
				}

				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON QuoteRequest");
			}
			break;
		}

		case TRADE_RECORDS_REQUEST:
		{
			TradeRecord *pRequest = (TradeRecord *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeRecord");

				pObject = (void *)pRequest;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON TradeRecord");
			}
			break;
		}
		
		default:
		{
			BusinessLevelReject  *pRequest = (BusinessLevelReject *)GetMessageObject(BUSINESS_LEVEL_REJECT);

			if (pRequest)
			{
				pRequest->BusinessRejectReason = BUSINESS_LEVEL_REJECT;
				pRequest->RefMsgType = BUSINESS_LEVEL_REJECT;
				strcpy(pRequest->Text, "Invalid Request");
				msgtype = BUSINESS_LEVEL_REJECT;
				pObject = (void *)pRequest;
			}
		}
			break;
		}
	}
	catch (json::json_exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetObjectFromJSON::Catch() Error = ", ex.what());

		BusinessLevelReject  *pRequest = (BusinessLevelReject *)GetMessageObject(BUSINESS_LEVEL_REJECT);

		if (pRequest)
		{
			pRequest->BusinessRejectReason = BUSINESS_LEVEL_REJECT;
			pRequest->RefMsgType = BUSINESS_LEVEL_REJECT;
			strcpy(pRequest->Text, "Invalid Request");
			msgtype = BUSINESS_LEVEL_REJECT;
			pObject = (void *)pRequest;
		}

	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetObjectFromJSON::Catch(...)");

		BusinessLevelReject  *pRequest = (BusinessLevelReject *)GetMessageObject(BUSINESS_LEVEL_REJECT);

		if (pRequest)
		{
			pRequest->BusinessRejectReason = BUSINESS_LEVEL_REJECT;
			pRequest->RefMsgType = BUSINESS_LEVEL_REJECT;
			strcpy(pRequest->Text, "Invalid Request");
			msgtype = BUSINESS_LEVEL_REJECT;
			pObject = (void *)pRequest;
		}
	}

	return pObject;
}

bool JSONHandler::GetJSONFromObject(void *object, int MsgType, std::string& JSONString, unsigned int &size)
{
	if (MsgType == -1)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject:: Error MsgType = %d", MsgType);

		return false;
	}

	json::value objJSON;
	

	try
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject:: MsgType = %d", MsgType);
		USES_CONVERSION;
		switch (MsgType)
		{
		case BUSINESS_LEVEL_REJECT:
		{
			BusinessLevelReject *pResponse = (BusinessLevelReject *)object;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject BusinessLevelReject");

				objJSON[L"RefMsgType"] = pResponse->RefMsgType;

				utility::string_t strVal = CA2W(pResponse->BusinessRejectRefID);
				objJSON[L"BusinessRejectRefID"] = json::value::string(strVal);

				objJSON[L"BusinessRejectReason"] = pResponse->BusinessRejectReason;

				strVal = CA2W(pResponse->Text);
				objJSON[L"Text"] = json::value::string(strVal);
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject BusinessLevelReject");
			}
			break;
		}
		case LOGON_RESPONSE:
		{
			LogonResponse *pResponse = (LogonResponse *)object;
			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject LogonResponse");

				utility::string_t strVal = CA2W(pResponse->Reason);
				objJSON[L"Reason"] = json::value::string(strVal);
				strVal = CA2W(pResponse->BrokerName);
				objJSON[L"BrokerName"] = json::value::string(strVal);
				strVal = CA2W(pResponse->AccountType);
				objJSON[L"AccountType"] = json::value::string(strVal);
				objJSON[L"IsLive"] = pResponse->IsLive;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject LogonResponse");
			}
			break;
		}

		case PARTICIPANT_LIST_RESPONSE:
		{
			ParticipantListResponse *pResponse = (ParticipantListResponse *)object;
			
			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject ParticipantListResponse");
				
				objJSON[L"NoOfParticipants"] = pResponse->NoOfParticipants;

				utility::string_t strVal = CA2W(pResponse->UserName);
				objJSON[L"UserName"] = json::value::string(strVal);

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfParticipants; i++)
				{
					strVal = CA2W(pResponse->AccountInfo[i].AccountType);
					arrJSON[L"AccountType"] = json::value::string(strVal);
					arrJSON[L"Balance"] = pResponse->AccountInfo[i].Balance;
					arrJSON[L"Leverage"] = pResponse->AccountInfo[i].Leverage;
					arrJSON[L"Group"] = pResponse->AccountInfo[i].Group;
					arrJSON[L"FreeMargin"] = pResponse->AccountInfo[i].FreeMargin;
					arrJSON[L"Margin"] = pResponse->AccountInfo[i].Margin;
					arrJSON[L"UsedMargin"] = pResponse->AccountInfo[i].UsedMargin;
					arrJSON[L"HedgingType"] = pResponse->AccountInfo[i].HedgingType;
					arrJSON[L"Active"] = pResponse->AccountInfo[i].Active;
					arrJSON[L"ReservedMargin"] = pResponse->AccountInfo[i].ReservedMargin;
					arrJSON[L"BuySideTurnOver"] = pResponse->AccountInfo[i].BuySideTurnOver;
					arrJSON[L"SellSideturnOver"] = pResponse->AccountInfo[i].SellSideturnOver;
					arrJSON[L"MarginCall1"] = pResponse->AccountInfo[i].MarginCall1;
					arrJSON[L"MarginCall2"] = pResponse->AccountInfo[i].MarginCall2;
					arrJSON[L"MarginCall3"] = pResponse->AccountInfo[i].MarginCall3;
					strVal = CA2W(pResponse->AccountInfo[i].TraderName);
					arrJSON[L"TraderName"] = json::value::string(strVal);
					//strVal = CA2W(pRequest->AccountInfo[0].AccountType);
					arrJSON[L"AccountID"] = (unsigned int)pResponse->AccountInfo[i].Account;
					arrJSON[L"LotSize"] = pResponse->AccountInfo[i].LotSize;

					arr[i] = arrJSON;
				}
				objJSON[L"accountInfo"] = arr;
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject ParticipantListResponse");
			}
			break;
		}

		case ORDER_STATUS_RESPONSE:
		{
			OrderStatusResponse *pResponse = (OrderStatusResponse *)object;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse");

				objJSON[L"Account"] = (long)pResponse->ExecutionReport.Account;
				objJSON[L"OrderQty"] = pResponse->ExecutionReport.OrdQty;
				utility::string_t strVal = CA2W(pResponse->ExecutionReport.ClOrdId);
				objJSON[L"ClOrdId"] = json::value::string(strVal);

				char szVal[2];

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse pResponse->ExecutionReport.OrderStatus: %c", pResponse->ExecutionReport.OrderStatus);

				szVal[0] = pResponse->ExecutionReport.OrderStatus;
				szVal[1] = '\0';
				strVal = CA2W(szVal);
				
				objJSON[L"OrderStatus"] = json::value::string(strVal);
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse OrderStatus: %s",strVal.c_str());

				szVal[0] = pResponse->ExecutionReport.Symbol.ProductType;
				szVal[1] = '\0';
				strVal = CA2W(szVal);
				objJSON[L"ProductType"] = json::value::string(strVal);

				strVal = CA2W(pResponse->ExecutionReport.Symbol.Product);
				objJSON[L"Product"] = json::value::string(strVal);
				strVal = CA2W(pResponse->ExecutionReport.Symbol.Contract);
				objJSON[L"Contract"] = json::value::string(strVal);
				strVal = CA2W(pResponse->ExecutionReport.Symbol.Gateway);
				objJSON[L"Gateway"] = json::value::string(strVal);
				strVal = CA2W(pResponse->ExecutionReport.ClOrdId);

				szVal[0] = pResponse->ExecutionReport.OrderType;
				strVal = CA2W(szVal);
				objJSON[L"OrderType"] = json::value::string(strVal);

				objJSON[L"Price"] = pResponse->ExecutionReport.Price;

				szVal[0] = pResponse->ExecutionReport.Side;
				strVal = CA2W(szVal);
				objJSON[L"Side"] = json::value::string(strVal);

				szVal[0] = pResponse->ExecutionReport.TimeInForce;
				strVal = CA2W(szVal);
				objJSON[L"TimeInForce"] = json::value::string(strVal);

				objJSON[L"StopPx"] = pResponse->ExecutionReport.StopPx;
				//objJSON[L"ExpireDate"] = pResponse->ExecutionReport.ExpireDate;
				//objJSON[L"TransactTime"] = pResponse->ExecutionReport.TransactTime;
				objJSON[L"OrderID"] = pResponse->ExecutionReport.OrderID;
				strVal = CA2W(pResponse->ExecutionReport.OrigClOrdID);
				objJSON[L"OrigClOrdID"] = json::value::string(strVal);

				szVal[0] = pResponse->ExecutionReport.PositionEffect;
				strVal = CA2W(szVal);
				objJSON[L"PositionEffect"] = json::value::string(strVal);


				strVal = CA2W(pResponse->ExecutionReport.ExecID);
				objJSON[L"ExecID"] = json::value::string(strVal);

				szVal[0] = pResponse->ExecutionReport.ExecTransType;
				strVal = CA2W(szVal);
				objJSON[L"ExecTransType"] = json::value::string(strVal);

				szVal[0] = pResponse->ExecutionReport.ExecType;
				strVal = CA2W(szVal);
				objJSON[L"ExecType"] = json::value::string(strVal);
				
				objJSON[L"ExpireDate"] = pResponse->ExecutionReport.ExpireDate;

				objJSON[L"TransactTime"] = pResponse->ExecutionReport.TransactTime;
				
				strVal = CA2W(pResponse->ExecutionReport.LinkedOrdID);
				objJSON[L"LinkedOrdID"] = json::value::string(strVal);

			//	szVal[0] = pResponse->ExecutionReport.OrderInfoEnd;
			//	strVal = CA2W(szVal);
			//	objJSON[L"OrderInfoEnd"] = json::value::string(strVal);

				objJSON[L"AvgPx"] = pResponse->ExecutionReport.AvgPx;
				objJSON[L"CumQty"] = pResponse->ExecutionReport.CumQty;

				

				strVal = CA2W(pResponse->ExecutionReport.Text);
				objJSON[L"Text"] = json::value::string(L"");

				objJSON[L"QtyFilled"] = pResponse->ExecutionReport.QtyFilled;
				objJSON[L"LastPx"] = pResponse->ExecutionReport.LastPx;
				objJSON[L"Comm"] = pResponse->ExecutionReport.Commission;
				objJSON[L"Tax"] = pResponse->ExecutionReport.Tax;
				objJSON[L"LeavesQty"] = pResponse->ExecutionReport.LeavesQty;
				objJSON[L"ClosedQty"] = pResponse->ExecutionReport.ClosedQuantity;
				//objJSON[L"MMId"] = (long)pResponse->ExecutionReport.MMId;
				//objJSON[L"CounterAvgPx"] = (long)pResponse->ExecutionReport.CounterAvgPx;
				//strVal = CA2W(pResponse->ExecutionReport.CounterClOrdId);
				//objJSON[L"CounterClOrdId"] = json::value::string(strVal);
				objJSON[L"Profit"] = pResponse->ExecutionReport.Profit;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse");
			}
			break;
		}

		case LOGOUT_RESPONSE:
		{
			LogoutResponse *pResponse = (LogoutResponse *)object;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject LogoutResponse");

				utility::string_t strVal = CA2W(pResponse->UserName);
				objJSON[L"UserName"] = json::value::string(strVal);
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject LogoutResponse");
			}
			break;
		}

		case ACCOUNT_RESPONSE:
		{
			AccountResponse *pResponse = (AccountResponse *)object;
			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject AccountResponse");

				objJSON[L"NoOfAccounts"] = pResponse->NoOfAccounts;

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfAccounts; i++)
				{
					utility::string_t strVal = CA2W(pResponse->AccountInfo[i].AccountType);
					arrJSON[L"AccountType"] = json::value::string(strVal);
					arrJSON[L"Balance"] = pResponse->AccountInfo[i].Balance;
					arrJSON[L"Leverage"] = pResponse->AccountInfo[i].Leverage;
					arrJSON[L"Group"] = pResponse->AccountInfo[i].Group;
					arrJSON[L"FreeMargin"] = pResponse->AccountInfo[i].FreeMargin;
					arrJSON[L"Margin"] = pResponse->AccountInfo[i].Margin;
					arrJSON[L"UsedMargin"] = pResponse->AccountInfo[i].UsedMargin;
					arrJSON[L"HedgingType"] = pResponse->AccountInfo[i].HedgingType;
					arrJSON[L"Active"] = pResponse->AccountInfo[i].Active;
					arrJSON[L"ReservedMargin"] = pResponse->AccountInfo[i].ReservedMargin;
					arrJSON[L"BuySideTurnOver"] = pResponse->AccountInfo[i].BuySideTurnOver;
					arrJSON[L"SellSideturnOver"] = pResponse->AccountInfo->SellSideturnOver;
					arrJSON[L"MarginCall1"] = pResponse->AccountInfo[i].MarginCall1;
					arrJSON[L"MarginCall2"] = pResponse->AccountInfo[i].MarginCall2;
					arrJSON[L"MarginCall3"] = pResponse->AccountInfo[i].MarginCall3;
					strVal = CA2W(pResponse->AccountInfo[i].TraderName);
					arrJSON[L"TraderName"] = json::value::string(strVal);
					arrJSON[L"AccountID"] = (unsigned int)pResponse->AccountInfo[i].Account;
					arrJSON[L"LotSize"] = pResponse->AccountInfo[i].LotSize;

					arr[i] = arrJSON;
				}

				objJSON[L"AccountInfo"] = arr;
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject AccountResponse");
			}
			break;
		}
		
		case POSITION_RESPONSE:
		{
			PositionResponse *pResponse = (PositionResponse *)object;

			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject PositionResponse");

				objJSON[L"NoOfPosition"] = pResponse->NoOfPosition;

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfPosition; i++)
				{
					arrJSON[L"Account"] = (long)pResponse->Position[i].Account;
					utility::string_t strVal = CA2W(pResponse->Position[i].Symbol.Contract);
					arrJSON[L"Contract"] = json::value::string(strVal);
					strVal = CA2W(pResponse->Position[i].Symbol.Gateway);
					arrJSON[L"Gateway"] = json::value::string(strVal);
					strVal = CA2W(pResponse->Position[i].Symbol.Product);
					arrJSON[L"Product"] = json::value::string(strVal);
				
					char szVal[2];

					szVal[0] = pResponse->Position[i].Symbol.ProductType;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"ProductType"] = json::value::string(strVal);
				
					arrJSON[L"BuyAvg"] = pResponse->Position[i].BuyAvg;
					arrJSON[L"BuyQty"] = (long)pResponse->Position[i].BuyQty;
					arrJSON[L"BuyVal"] = (long)pResponse->Position[i].BuyVal;
					arrJSON[L"NetPrice"] = pResponse->Position[i].NetPrice;
					arrJSON[L"NetQty"] = pResponse->Position[i].NetQty;
					arrJSON[L"NetVal"] = pResponse->Position[i].NetVal;
					arrJSON[L"SellAvg"] = pResponse->Position[i].SellAvg;
					arrJSON[L"SellQty"] = (long)pResponse->Position[i].SellQty;
					arrJSON[L"SellVal"] = (long)pResponse->Position[i].SellVal;
										
					arr[i] = arrJSON;
				}
				objJSON[L"Position"] = arr;
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject PositionResponse");
			}
			break;
		}
					
		case TRADE_HISTORY_RESPONSE:
		{
			TradeHistoryResponse *pResponse = (TradeHistoryResponse *)object;

			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject TradeHistoryResponse");

				objJSON[L"NoOfOrders"] = pResponse->NoOfOrders;

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfOrders; i++)
				{
					arrJSON[L"Account"] = (long)pResponse->TradeHistory[i].Account;
					arrJSON[L"OrderQty"] = pResponse->TradeHistory[i].OrdQty;
					utility::string_t strVal = CA2W(pResponse->TradeHistory[i].ClOrdId);
					arrJSON[L"ClOrdId"] = json::value::string(strVal);

					char szVal[2];
					szVal[0] = pResponse->TradeHistory[i].Symbol.ProductType;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"ProductType"] = json::value::string(strVal);

					strVal = CA2W(pResponse->TradeHistory[i].Symbol.Product);
					arrJSON[L"Product"] = json::value::string(strVal);
					strVal = CA2W(pResponse->TradeHistory[i].Symbol.Contract);
					arrJSON[L"Contract"] = json::value::string(strVal);
					strVal = CA2W(pResponse->TradeHistory[i].Symbol.Gateway);
					arrJSON[L"Gateway"] = json::value::string(strVal);
					strVal = CA2W(pResponse->TradeHistory[i].ClOrdId);

					szVal[0] = pResponse->TradeHistory[i].OrderType;
					strVal = CA2W(szVal);
					arrJSON[L"OrderType"] = json::value::string(strVal);

					arrJSON[L"Price"] = pResponse->TradeHistory[i].Price;

					szVal[0] = pResponse->TradeHistory[i].Side;
					strVal = CA2W(szVal);
					arrJSON[L"Side"] = json::value::string(strVal);

					szVal[0] = pResponse->TradeHistory[i].TimeInForce;
					strVal = CA2W(szVal);
					arrJSON[L"TimeInForce"] = json::value::string(strVal);

					arrJSON[L"StopPx"] = pResponse->TradeHistory[i].StopPx;
					arrJSON[L"OrderID"] = pResponse->TradeHistory[i].OrderID;
					strVal = CA2W(pResponse->TradeHistory[i].OrigClOrdID);
					arrJSON[L"OrigClOrdID"] = json::value::string(strVal);

					szVal[0] = pResponse->TradeHistory[i].PositionEffect;
					strVal = CA2W(szVal);
					arrJSON[L"PositionEffect"] = json::value::string(strVal);

					strVal = CA2W(pResponse->TradeHistory[i].ExecID);
					arrJSON[L"ExecID"] = json::value::string(strVal);

					szVal[0] = pResponse->TradeHistory[i].ExecTransType;
					strVal = CA2W(szVal);
					arrJSON[L"ExecTransType"] = json::value::string(strVal);

					szVal[0] = pResponse->TradeHistory[i].ExecType;
					strVal = CA2W(szVal);
					arrJSON[L"ExecType"] = json::value::string(strVal);

					arrJSON[L"ExpireDate"] = pResponse->TradeHistory[i].ExpireDate;
					arrJSON[L"TransactTime"] = pResponse->TradeHistory[i].TransactTime;

					strVal = CA2W(pResponse->TradeHistory[i].LinkedOrdID);
					arrJSON[L"LinkedOrdID"] = json::value::string(strVal);

					szVal[0] = pResponse->TradeHistory[i].OrderInfoEnd;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"OrderInfoEnd"] = json::value::string(strVal);


					arrJSON[L"AvgPx"] = pResponse->TradeHistory[i].AvgPx;
					arrJSON[L"CumQty"] = pResponse->TradeHistory[i].CumQty;
					
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse pResponse->TradeHistory[i].OrderStatus: %c", pResponse->TradeHistory[i].OrderStatus);

					szVal[0] = pResponse->TradeHistory[i].OrderStatus;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"OrderStatus"] = json::value::string(strVal);

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderStatusResponse OrderStatus: %s", strVal.c_str());

					strVal = CA2W(pResponse->TradeHistory[i].Text);
					arrJSON[L"Text"] = json::value::string(L"");

					arrJSON[L"QtyFilled"] = pResponse->TradeHistory[i].QtyFilled;
					arrJSON[L"LastPx"] = pResponse->TradeHistory[i].LastPx;
					arrJSON[L"Comm"] = pResponse->TradeHistory[i].Commission;
					arrJSON[L"Tax"] = pResponse->TradeHistory[i].Tax;
					arrJSON[L"LeavesQty"] = pResponse->TradeHistory[i].LeavesQty;
					arrJSON[L"ClosedQty"] = pResponse->TradeHistory[i].ClosedQuantity;
					//arrJSON[L"MMId"] = (long)pResponse->TradeHistory[i].MMId;
					//arrJSON[L"CounterAvgPx"] = (long)pResponse->TradeHistory[i].CounterAvgPx;
					//strVal = CA2W(pResponse->TradeHistory[i].CounterClOrdId);
					//arrJSON[L"CounterClOrdId"] = json::value::string(strVal);
					arrJSON[L"Profit"] = pResponse->TradeHistory[i].Profit;

					arr[i] = arrJSON;
				}
				objJSON[L"executionReport"] = arr;
				
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject TradeHistoryResponse");
			}
			break;
		}
		
		case ORDER_HISTORY_RESPONSE:
		{
			OrderHistoryResponse *pResponse = (OrderHistoryResponse *)object;

			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderHistoryResponse");

				objJSON[L"NoOfOrders"] = pResponse->NoOfOrders;

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfOrders; i++)
				{
					char szVal[2];

					arrJSON[L"Account"] = (long)pResponse->OrderHistory[i].Account;
					utility::string_t strVal = CA2W(pResponse->OrderHistory[i].ClOrdId);
					arrJSON[L"ClOrdId"] = json::value::string(strVal);
					arrJSON[L"OrderID"] = pResponse->OrderHistory[i].OrderID;
					arrJSON[L"AvgPx"] = pResponse->OrderHistory[i].AvgPx;
					arrJSON[L"CumQty"] = pResponse->OrderHistory[i].CumQty;
					arrJSON[L"OrderQty"] = pResponse->OrderHistory[i].OrdQty;

					szVal[0] = pResponse->OrderHistory[i].Symbol.ProductType;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"ProductType"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OrderHistory[i].Symbol.Product);
					arrJSON[L"Product"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OrderHistory[i].Symbol.Contract);
					arrJSON[L"Contract"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OrderHistory[i].Symbol.Gateway);
					arrJSON[L"Gateway"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OrderHistory[i].ClOrdId);


					szVal[0] = pResponse->OrderHistory[i].OrderStatus;
					strVal = CA2W(szVal);
					arrJSON[L"OrderStatus"] = json::value::string(strVal);

					szVal[0] = pResponse->OrderHistory[i].OrderType;
					strVal = CA2W(szVal);
					arrJSON[L"OrderType"] = json::value::string(strVal);

					strVal = CA2W(pResponse->OrderHistory[i].OrigClOrdId);
					arrJSON[L"OrigClOrdID"] = json::value::string(strVal);

					strVal = CA2W(pResponse->OrderHistory[i].Text);
					arrJSON[L"Text"] = json::value::string(strVal);
					arrJSON[L"Profit"] = pResponse->OrderHistory[i].Profit;
					arrJSON[L"Price"] = pResponse->OrderHistory[i].Price;

					szVal[0] = pResponse->OrderHistory[i].Side;
					strVal = CA2W(szVal);
					arrJSON[L"Side"] = json::value::string(strVal);

				

					szVal[0] = pResponse->OrderHistory[i].TimeInForce;
					strVal = CA2W(szVal);
					arrJSON[L"TimeInForce"] = json::value::string(strVal);
					arrJSON[L"TransactTime"] = pResponse->OrderHistory[i].TransactTime;
					arrJSON[L"TradeDate"] = pResponse->OrderHistory[i].TradeDate;
					arrJSON[L"StopPx"] = pResponse->OrderHistory[i].StopPx;
					arrJSON[L"LeavesQty"] = pResponse->OrderHistory[i].LeavesQty;
					arrJSON[L"ExpireDate"] = pResponse->OrderHistory[i].ExpireDate;
					arrJSON[L"Comm"] = pResponse->OrderHistory[i].Commission;
					arrJSON[L"Tax"] = pResponse->OrderHistory[i].Tax;
					//arrJSON[L"CounterAvgPx"] = pResponse->OrderHistory[i].CounterAvgPx;

				//	strVal = CA2W(pResponse->OrderHistory[i].CounterClOrdId);
				//	arrJSON[L"CounterClOrdId"] = json::value::string(strVal);

					strVal = CA2W(pResponse->OrderHistory[i].LinkedOrdID);
					arrJSON[L"LinkedOrdID"] = json::value::string(strVal);

					szVal[0] = pResponse->OrderHistory[i].PositionEffect;
					strVal = CA2W(szVal);
					arrJSON[L"PositionEffect"] = json::value::string(strVal);
									
					arrJSON[L"ClosedQty"] = pResponse->OrderHistory[i].ClosedQuantity;
					
					arrJSON[L"StopLoss"] = pResponse->OrderHistory[i].StopLoss;

					arrJSON[L"TakeProfit"] = pResponse->OrderHistory[i].TakeProfit;
					arrJSON[L"ClosePrice"] = pResponse->OrderHistory[i].ClosePrice;
					strVal = CA2W(pResponse->OrderHistory[i].StopLossId);
					arrJSON[L"StopLossId"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OrderHistory[i].TakeProfitId);
					arrJSON[L"TakeProfitId"] = json::value::string(strVal);

					arr[i] = arrJSON;
				}
				objJSON[L"orderHistory"] = arr;

				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject OrderHistoryResponse");
			}
			break;
		}

		case QUOTE_SNAP_SHOT_RESPONSE:
		{
			QuotesSnapshotResponse *pResponse = (QuotesSnapshotResponse *)object;

			json::value arrJSON;

			json::value arrMARKETJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject QuotesSnapshotResponse");

				objJSON[L"NoOfSymbols"] = pResponse->NoOfSymbols;

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfSymbols; i++)
				{
				
					utility::string_t strVal = CA2W(pResponse->UserName);
					arrJSON[L"UserName"] = json::value::string(strVal);

					char szVal[2];
					szVal[0] = pResponse->OHLC[i].Symbol.ProductType;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"ProductType"] = json::value::string(strVal);
					
					strVal = CA2W(pResponse->OHLC[i].Symbol.Product);
					arrJSON[L"Product"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OHLC[i].Symbol.Contract);
					arrJSON[L"Contract"] = json::value::string(strVal);
					strVal = CA2W(pResponse->OHLC[i].Symbol.Gateway);
					arrJSON[L"Gateway"] = json::value::string(strVal);


					arrJSON[L"Close"] = pResponse->OHLC[i].Close;
					arrJSON[L"High"] = pResponse->OHLC[i].High;
					arrJSON[L"LastPrice"] = pResponse->OHLC[i].LastPrice;
					arrJSON[L"LastSize"] = pResponse->OHLC[i].LastSize;
					arrJSON[L"LastTime"] = pResponse->OHLC[i].LastTime;
					arrJSON[L"Low"] = pResponse->OHLC[i].Low;
					arrJSON[L"Open"] = pResponse->OHLC[i].Open;
					arrJSON[L"Volume"] = pResponse->OHLC[i].Volume;
					arrJSON[L"WeeksHigh52"] = pResponse->OHLC[i].WeeksHigh52;
					arrJSON[L"WeeksLow52"] = pResponse->OHLC[i].WeeksLow52;
					arrJSON[L"LastUpdatedTime"] = pResponse->OHLC[i].LastUpdatedTime;
					arrJSON[L"MarketDepthLevel"] = pResponse->OHLC[i].MarketDepthLevel;

					json::value arrMARKET = json::value::array();

					for (int j = 0; j < pResponse->OHLC[i].MarketDepthLevel; j++)
					{
						arrMARKETJSON[L"AskPrice"] = pResponse->OHLC[i].MarketDepth[j].AskPrice;
						arrMARKETJSON[L"AskSize"] = pResponse->OHLC[i].MarketDepth[j].AskSize;
						arrMARKETJSON[L"AskTime"] = pResponse->OHLC[i].MarketDepth[j].AskTime;
						arrMARKETJSON[L"BidPrice"] = pResponse->OHLC[i].MarketDepth[j].BidPrice;
						arrMARKETJSON[L"BidSize"] = pResponse->OHLC[i].MarketDepth[j].BidSize;
						arrMARKETJSON[L"BidTime"] = pResponse->OHLC[i].MarketDepth[j].BidTime;
						strVal = CA2W(pResponse->OHLC[i].MarketDepth[j].Gateway);
						arrJSON[L"Gateway"] = json::value::string(strVal);
						arrMARKETJSON[L"Level"] = pResponse->OHLC[i].MarketDepth[j].Level;
						
						arrMARKET[j] = arrMARKETJSON;
					}
					arrJSON[L"MarketDepth"] = arrMARKET;

					arr[i] = arrJSON;
				}
				objJSON[L"OHLC"] = arr;
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject QuotesSnapshotResponse");
			}
			break;
		}
					
		case QUOTES_STREAM:
		{
			QuotesStream *pResponse = (QuotesStream *)object;

			json::value arrJSON;

			if (pResponse)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject QuotesStream");

				objJSON[L"NoOfSymbols"] = pResponse->NoOfSymbols;

				utility::string_t strVal = CA2W(pResponse->UserName);
				arrJSON[L"UserName"] = json::value::string(strVal);

				json::value arr = json::value::array();

				for (int i = 0; i < pResponse->NoOfSymbols; i++)
				{
					arrJSON[L"MarketLevel"] = pResponse->QuotesItem[i].MarketLevel;
					arrJSON[L"Price"] = pResponse->QuotesItem[i].Price;
					arrJSON[L"Size"] = pResponse->QuotesItem[i].Size;
					arrJSON[L"Time"] = pResponse->QuotesItem[i].Time;
					
					char szVal[2];
				
					szVal[0] = pResponse->QuotesItem[i].QuotesStreamType;
					szVal[1] = '\0';
					strVal = CA2W(szVal);
					arrJSON[L"QuotesStreamType"] = json::value::string(strVal);

					szVal[0] = pResponse->QuotesItem[i].Symbol.ProductType;
					strVal = CA2W(szVal);
					arrJSON[L"ProductType"] = json::value::string(strVal);

					strVal = CA2W(pResponse->QuotesItem[i].Symbol.Product);
					arrJSON[L"Product"] = json::value::string(strVal);
					strVal = CA2W(pResponse->QuotesItem[i].Symbol.Contract);
					arrJSON[L"Contract"] = json::value::string(strVal);
					strVal = CA2W(pResponse->QuotesItem[i].Symbol.Gateway);
					arrJSON[L"Gateway"] = json::value::string(strVal);
				
					arr[i] = arrJSON;
				}
				objJSON[L"QuotesItem"] = arr;
				objJSON[L"islastPck"] = pResponse->Header.KeyDataCtrlBlk;
				objJSON[L"msgtype"] = MsgType;

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get GetJSONFromObject QuotesStream");
			}
			break;
		}

		case TRADE_NOTIFY_RESPONSE:
		{
			utility::string_t strVal;
			TradeRecord *pRequest = (TradeRecord *)object;

			if (pRequest)
			{
				objJSON[L"order"] = pRequest->order;
				objJSON[L"login"] = pRequest->login;
				strVal = CA2W(pRequest->broker);
				objJSON[L"broker"] = json::value::string(strVal);
				strVal = CA2W(pRequest->symbol);
				objJSON[L"symbol"] = json::value::string(strVal);
				objJSON[L"digits"] = pRequest->digits;
				strVal = CA2W(pRequest->cmd);
				objJSON[L"cmd"] = json::value::string(strVal);
				objJSON[L"volume"] = pRequest->volume;
				strVal = CA2W(pRequest->open_time);
				objJSON[L"open_time"] = json::value::string(strVal);
				objJSON[L"open_price"] = pRequest->open_price;
				objJSON[L"sl"] = pRequest->sl;
				objJSON[L"tp"] = pRequest->tp;
				strVal = CA2W(pRequest->close_time);
				objJSON[L"close_time"] = json::value::string(strVal);
				strVal = CA2W(pRequest->expiration);
				objJSON[L"expiration"] = json::value::string(strVal);
				strVal = CA2W(pRequest->orderstaus);
				objJSON[L"order_staus"] = json::value::string(strVal);
				objJSON[L"comm"] = pRequest->commission;
				objJSON[L"commission_agent"] = pRequest->commission_agent;
				objJSON[L"storage"] = pRequest->storage;
				objJSON[L"close_price"] = pRequest->close_price;
				objJSON[L"profit"] = pRequest->profit;
				objJSON[L"taxes"] = pRequest->taxes;
				objJSON[L"magic"] = pRequest->magic;
				strVal = CA2W(pRequest->comment);
				objJSON[L"comment"] = json::value::string(strVal);
				strVal = CA2W(pRequest->timestamp);
				objJSON[L"timestamp"] = json::value::string(strVal);
				objJSON[L"msgtype"] = TRADE_NOTIFY_RESPONSE;
			}
		}
		break;

		case INVALID_REQUEST:
		{

			InvalidRequest *pRequest = (InvalidRequest *)object;

			if (pRequest)
			{
				utility::string_t strVal = CA2W(pRequest->Reason);
				objJSON[L"Reason"] = json::value::string(strVal);
				objJSON[L"msgtype"] = pRequest->msgtype;
			}
		}
		break;
		
		default:
		{
			JSONString = "";
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject:: default  MsgType = %d", MsgType);
			return false;
		}
		break;
		}

		size = objJSON.to_string().length();

		if (size > 0)
		{
			std::wstring strXXX = objJSON.to_string().c_str();
			JSONString = W2A(strXXX.c_str());

			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject:: JSON String = %s", JSONString.c_str());
			//utf8_check_is_valid(JSONString);
			return true;
		}

	}
	catch (std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject::Catch (std::exception ex) Error = ", ex.what());
	}

	catch (json::json_exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject::Catch(json::json_exception ex) Error = ", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject::Catch(...)");
	}

	return false;
}


bool JSONHandler::utf8_check_is_valid(const string& string)
{
	int c, i, ix, n, j;
	for (i = 0, ix = string.length(); i < ix; i++)
	{
		c = (unsigned char)string[i];
		//if (c==0x09 || c==0x0a || c==0x0d || (0x20 <= c && c <= 0x7e) ) n = 0; // is_printable_ascii
		if (0x00 <= c && c <= 0x7f) n = 0; // 0bbbbbbb
		else if ((c & 0xE0) == 0xC0) n = 1; // 110bbbbb
		else if (c == 0xed && i<(ix - 1) && ((unsigned char)string[i + 1] & 0xa0) == 0xa0) return false; //U+d800 to U+dfff
		else if ((c & 0xF0) == 0xE0) n = 2; // 1110bbbb
		else if ((c & 0xF8) == 0xF0) n = 3; // 11110bbb
		//else if (($c & 0xFC) == 0xF8) n=4; // 111110bb //byte 5, unnecessary in 4 byte UTF-8
		//else if (($c & 0xFE) == 0xFC) n=5; // 1111110b //byte 6, unnecessary in 4 byte UTF-8
		else return false;
		for (j = 0; j<n && i<ix; j++) { // n bytes matching 10bbbbbb follow ?
			if ((++i == ix) || (((unsigned char)string[i] & 0xC0) != 0x80))
				return false;
		}
	}
	return true;
}