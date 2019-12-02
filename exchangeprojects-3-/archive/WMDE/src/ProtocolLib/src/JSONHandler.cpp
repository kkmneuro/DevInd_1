
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

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON Enter");
		int size = v1.size();
		if (size < 0)
			return NULL;

		msgtype = v1.at(L"msgtype").as_integer();

		switch (msgtype)
		{
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

		case QUOTE_SUBSCRIPTION_REQUEST:
		{
			QuoteSubscriptionRequest *pRequest = (QuoteSubscriptionRequest *)GetMessageObject(msgtype);

			if (pRequest)
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Get ObjectFromJSON QuoteSubscriptionRequest");
				pRequest->NoOfSymbols = v1.at(L"NoOfSymbols").as_integer();
				
				json::value v2 = v1.at(L"Symbol").array();

				if (pRequest->NoOfSymbols > 5)
					pRequest->NoOfSymbols = 5;

				for (int i = 0; i< pRequest->NoOfSymbols; i++)
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
				
				json::array v2 = v1.at(L"Symbol").as_array();

				if (pRequest->NoOfSymbols > 5)
					pRequest->NoOfSymbols = 5;

				for (int i = 0; i < pRequest->NoOfSymbols; i++)
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