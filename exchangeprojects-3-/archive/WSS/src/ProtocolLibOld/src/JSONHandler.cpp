
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
	USES_CONVERSION;

	utility::stringstream_t ss1;
	wstring str = CA2W(buff);
	string strVal;
	ss1 << str;

	json::value v1 = json::value::parse(ss1);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON Enter");
	int size = v1.size();
	if (size<0)
		return NULL;

	msgtype = v1.at(L"msgtype").as_integer();

	switch (msgtype)
	{
		case LOGON_REQUEST:
				{
					LogonRequest *pRequest = (LogonRequest *)GetMessageObject(msgtype);
					if(pRequest)
					{
						//memset(pRequest,0,sizeof(LogonRequest));
						strcpy(pRequest->UserName,W2A(v1.at(L"UserName").as_string().c_str()));
						strcpy(pRequest->Password,W2A(v1.at(L"Password").as_string().c_str()));
						pRequest->Version  = v1.at(U("Version")).as_double();
						strcpy(pRequest->Header.SenderID,W2A(v1.at(L"SenderID").as_string().c_str()));
						pObject = (void *)pRequest;
					}
				}
				break;
		 case LOGOUT_REQUEST:
				break;
		 case PARTICIPANT_LIST_REQUEST:
			 {
				 ParticipantListRequest *pRequest = (ParticipantListRequest *)GetMessageObject(msgtype);
					if(pRequest)
					{
						//memset(pRequest,0,sizeof(LogonRequest));
						strcpy(pRequest->UserName,W2A(v1.at(L"UserName").as_string().c_str()));
						pObject = (void *)pRequest;
					}
			 }

				break;
		 case NEW_ORDER_REQUEST:
				 {
					 NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(msgtype);
					 if(pRequest)
						{

							
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON NewOrderStart");
							pRequest-> order.Account = v1.at(L"Account").as_integer();
							pRequest-> order.OrderQty = v1.at(L"OrderQty").as_integer();
							strcpy(pRequest-> order.ClOrdId,W2A(v1.at(L"ClOrdId").as_string().c_str()));
							strVal = W2A(v1.at(L"ProductType").as_string().c_str());
							pRequest->order.Symbol.ProductType = strVal[0];
							strcpy(pRequest-> order.Symbol.Product,W2A(v1.at(L"Product").as_string().c_str()));
							strcpy(pRequest-> order.Symbol.Contract,W2A(v1.at(L"Contract").as_string().c_str()));
							strcpy(pRequest-> order.Symbol.Gateway,W2A(v1.at(L"Gateway").as_string().c_str()));

							strVal = W2A(v1.at(L"OrderType").as_string().c_str());
							pRequest->order.OrderType = strVal[0];
							pRequest-> order.Price = v1.at(L"Price").as_integer();		

							strVal = W2A(v1.at(L"Side").as_string().c_str());
							pRequest->order.Side = strVal[0];

							strVal = W2A(v1.at(L"TimeInForce").as_string().c_str());
							pRequest->order.TimeInForce = strVal[0];

							pRequest-> order.StopPx = v1.at(L"StopPx").as_integer();
							pRequest-> order.ExpireDate = 0;
							pRequest-> order.TransactTime = 0;
							pRequest-> order.OrderID = v1.at(L"OrderID").as_integer();
							strcpy(pRequest-> order.origClOrdId,W2A(v1.at(L"origClOrdId").as_string().c_str()));

							strVal = W2A(v1.at(L"PositionEffect").as_string().c_str());
							pRequest->order.PositionEffect = strVal[0];

							strcpy(pRequest-> order.LnkdOrdId,"");
							pRequest->order.MinOrDisclosedQty = 0;
							pRequest->order.Slipage = 0;
							pRequest->order.OCOOrder = false;
							pObject = (void *)pRequest;

							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON NewOrderStop");
						}
				 }
				break;
		  default:
				 break;
	}

	return pObject;
}

bool JSONHandler::GetJSONFromObject(void *object, int MsgType, std::string& JSONString, unsigned int &size)
{
	json::value objJSON;

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "JSONHandler::GetJSONFromObject:: MsgType = %d", MsgType);
	USES_CONVERSION;
	switch(MsgType)
			 {
	case BUSINESS_LEVEL_REJECT:
	{
		BusinessLevelReject *pReject = (BusinessLevelReject *)object;

		if (pReject)
		{
			objJSON[L"RefMsgType"] = pReject->RefMsgType;

			utility::string_t strVal = CA2W(pReject->BusinessRejectRefID);
			objJSON[L"BusinessRejectRefID"] = json::value::string(strVal);

			objJSON[L"BusinessRejectReason"] = pReject->BusinessRejectReason;

			strVal = CA2W(pReject->Text);
			objJSON[L"Text"] = json::value::string(strVal);
			objJSON[L"msgtype"] = MsgType;
		}
		break;
	}
			 case LOGON_RESPONSE:
				 {
					LogonResponse *pRequest = (LogonResponse *)object;
					utility::string_t strVal = CA2W(pRequest->Reason);
					objJSON[L"Reason"] = json::value::string(strVal); 
					strVal = CA2W(pRequest->BrokerName);
					objJSON[L"BrokerName"] = json::value::string(strVal); 
					strVal = CA2W(pRequest->AccountType);
					objJSON[L"AccountType"] = json::value::string(strVal); 
					objJSON[L"IsLive"] = pRequest->IsLive;
					objJSON[L"msgtype"] = LOGON_RESPONSE;
				 }
				break;
			 case PARTICIPANT_LIST_RESPONSE:
				 {
					ParticipantListResponse *pRequest = (ParticipantListResponse *)object;
					utility::string_t strVal = CA2W(pRequest->UserName);
					objJSON[L"UserName"] = json::value::string(strVal); 
					objJSON[L"NoOfParticipants"] = pRequest->NoOfParticipants;
					strVal = CA2W(pRequest->AccountInfo[0].AccountType);
					objJSON[L"AccountType"] = json::value::string(strVal); 
					objJSON[L"Balance"] = pRequest->AccountInfo[0].Balance;
					objJSON[L"Leverage"] = pRequest->AccountInfo[0].Leverage;
					objJSON[L"Group"] = pRequest->AccountInfo[0].Group;
					objJSON[L"FreeMargin"] = pRequest->AccountInfo[0].FreeMargin;
					objJSON[L"Margin"] = pRequest->AccountInfo[0].Margin;
					objJSON[L"UsedMargin"] = pRequest->AccountInfo[0].UsedMargin;
					objJSON[L"HedgingType"] = pRequest->AccountInfo[0].HedgingType;
					objJSON[L"Active"] = pRequest->AccountInfo[0].Active;
					objJSON[L"ReservedMargin"] = pRequest->AccountInfo[0].ReservedMargin;
					objJSON[L"BuySideTurnOver"] = pRequest->AccountInfo[0].BuySideTurnOver;
					objJSON[L"SellSideturnOver"] = pRequest->AccountInfo->SellSideturnOver;
					objJSON[L"MarginCall1"] = pRequest->AccountInfo[0].MarginCall1;
					objJSON[L"MarginCall2"] = pRequest->AccountInfo[0].MarginCall2;
					objJSON[L"MarginCall3"] = pRequest->AccountInfo[0].MarginCall3;
					strVal = CA2W(pRequest->AccountInfo[0].TraderName);
					objJSON[L"TraderName"] = json::value::string(strVal); 
					strVal = CA2W(pRequest->AccountInfo[0].AccountType);
					objJSON[L"AccountType"] =json::value::string(strVal); 
					objJSON[L"LotSize"] = pRequest->AccountInfo[0].LotSize;
					objJSON[L"msgtype"] = PARTICIPANT_LIST_RESPONSE;
				 }
			  break;
			 case ORDER_STATUS_RESPONSE:
				{
					OrderStatusResponse *pResponse = (OrderStatusResponse *)object;

					if (pResponse)
					{
						objJSON[L"Account"] = (long)pResponse->ExecutionReport.Account;
						objJSON[L"OrderQty"] = pResponse->ExecutionReport.OrdQty;
						utility::string_t strVal = CA2W(pResponse->ExecutionReport.ClOrdId);
						objJSON[L"ClOrdId"] = json::value::string(strVal);
						objJSON[L"ProductType"] = pResponse->ExecutionReport.Symbol.ProductType;
						strVal = CA2W(pResponse->ExecutionReport.Symbol.Product);
						objJSON[L"Product"] = json::value::string(strVal);
						strVal = CA2W(pResponse->ExecutionReport.Symbol.Contract);
						objJSON[L"Contract"] = json::value::string(strVal);
						strVal = CA2W(pResponse->ExecutionReport.Symbol.Gateway);
						objJSON[L"Gateway"] = json::value::string(strVal);
						strVal = CA2W(pResponse->ExecutionReport.ClOrdId);
						objJSON[L"OrderType"] = json::value::string(strVal);
						objJSON[L"Price"] = pResponse->ExecutionReport.Price;
						objJSON[L"Side"] = pResponse->ExecutionReport.Side;
						objJSON[L"TimeInForce"] = pResponse->ExecutionReport.TimeInForce;
						objJSON[L"StopPx"] = pResponse->ExecutionReport.StopPx;
						//objJSON[L"ExpireDate"] = pResponse->ExecutionReport.ExpireDate;
						//objJSON[L"TransactTime"] = pResponse->ExecutionReport.TransactTime;
						objJSON[L"OrderID"] = pResponse->ExecutionReport.OrderID;
						strVal = CA2W(pResponse->ExecutionReport.OrigClOrdID);
						objJSON[L"OrigClOrdID"] = json::value::string(strVal);
						objJSON[L"PositionEffect"] = pResponse->ExecutionReport.PositionEffect;
						strVal = CA2W(pResponse->ExecutionReport.LinkedOrdID);
						objJSON[L"LinkedOrdID"] = json::value::string(strVal);
						objJSON[L"Profit"] = pResponse->ExecutionReport.Profit;
						objJSON[L"msgtype"] = ORDER_STATUS_RESPONSE;
					}
				}
			  break;
			  
			 default:
			 break;
			}

	size = objJSON.to_string().length();
	JSONString = W2A(objJSON.to_string().c_str());

	return true;
}
