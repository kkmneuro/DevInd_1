#include "stdafx.h"
#include "ServerInterface.h"
#include "Gatewayclient.h"
#include "ITroute.h"
#include "Datadef.h"
#include "IOrder.h"
#include "errordefs.h"
#include "xlogger.h"
#include "xconfigure.h"
#include "time.h"
#include <ATLCOMTime.h>
#include "UtilitiesAPI.h"


#define CONFIG_FILE	"MDEServerSetting.ini"

ITRoute::ITRoute(IDatabase *pDatabaseBO/*, IAccountMgr *pMgr*/)
{
	m_pConnManager = NULL;
	m_pDatabase = pDatabaseBO;
	m_pDefaultClient = NULL;

	LoadAllGateways();

	SendSignal(SERVER_OMS, SIGNAL_TYPE_STARTUP, SIGNAL_STATUS_EXTERNAL_CONNS_UP);

	// Start the KA Server
	StartKAthread(SERVER_OMS);
}

int	ITRoute::LoadAllGateways()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = m_pDatabase->Execute("Exchange_ListOfTradingGateways",*tb,*param);//execute sp
			if( !isSPExist )
			{
				nSuccess = ERR_INTERNAL_ERROR;

				ReleaseTable(tb);//release table object
				ReleaseParameter(param);//release parameter object

				return -1;
			}	

			char szLPName[20];
			char szIPAddress[20];
			char szLogin[100];
			char szPassword[100];
			int nPort = 0;
			int AuthReq = 0;

			GatewayClient *pPrevClient = NULL;

			while (!tb->IsEOF())
			{
				tb->Get("LPName", szLPName, sizeof(szLPName));
				tb->Get("OrderIPAddress", szIPAddress, sizeof(szIPAddress));
				tb->Get("Order_Port", nPort);
				tb->Get("Login", szLogin, sizeof(szLogin));
				tb->Get("Password", szPassword, sizeof(szPassword));
				tb->Get("AuthReq", AuthReq);

				GatewayClient *pClient = new GatewayClient(this, AuthReq);

				if (pClient)
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITRoute::LoadAllGateways, LP Name = %s, Login = %s, Password = %s, IPAddress = %s, Port = %d",
																	szLPName,
																	szLogin,
																	szPassword,
																	szIPAddress,
																	nPort);

					pClient->login(szLogin, szPassword, szIPAddress, szIPAddress, nPort);

					if (strcmp(szLPName, "ALL") == 0)
					{
						m_pDefaultClient = pClient;
					}
					else
					{
						_ptrGatewayClientList.insert(std::pair<std::string, GatewayClient*>(szLPName, pClient));
					}

					pPrevClient = pClient;
				}
				else
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::LoadAllGateways, Unable to allocate memory to MDFClient");
				}

				tb->MoveNext();
			}

			ReleaseParameter(param);//release parameter object
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::LoadAllGateways, Unable to create instance of Param");
		}
		ReleaseTable(tb);//release table object
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ITOrder::LoadAllGateways, Unable to create instance of Table");
	}

	return nSuccess;
}

int ITRoute::RouteOrder(IOrder *pOrder, std::string& strLPName, unsigned long long price, unsigned long long StopPx)
{
	int nSuccess = ERR_OK;

	NewOrderRequest *pRequest = (NewOrderRequest *)GetMessageObject(NEW_ORDER_REQUEST);

	if (pRequest)
	{
		pOrder->AvgPx = 0;
		pOrder->CumQty = 0;
		pOrder->LeavesQty = 0;

		
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::RouteOrder, Send Order ID to External system = %s. Order = %s", pOrder->m_Order.ClOrdId, pOrder->ToString());

		memcpy(&pRequest->order, &pOrder->m_Order, sizeof(pRequest->order));

		pRequest->order.Price = price;
		pRequest->order.StopPx = StopPx;

		GatewayClient *pClient = GetClientObject(strLPName);

		if (pClient)
		{
			if (pClient->_AccountNo != 0)
				pRequest->order.Account = pClient->_AccountNo;

			nSuccess = Send(pClient, pRequest, NEW_ORDER_REQUEST);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::RouteOrder, Send Order ID to External system = %s.. Sent %d", pOrder->m_Order.ClOrdId, nSuccess);
		}
		else
			nSuccess = ERR_INTERNAL_ERROR;

		free(pRequest);
	}
	else
		nSuccess = ERR_INTERNAL_ERROR;

	return nSuccess;
}

int ITRoute::RouteCROrder(IOrder *order, IOrder *pNewOrder, std::string& strLPName, unsigned long long price, unsigned long long StopPx, unsigned long long oldprice, unsigned long long oldStopPx)
{
	int nSuccess = ERR_OK;

	OrderReplaceRequest *pRequest = (OrderReplaceRequest *)GetMessageObject(ORDER_REPLACE_REQUEST);

	if (pRequest)
	{
		pNewOrder->AvgPx = 0;
		pNewOrder->CumQty = 0;
		pNewOrder->LeavesQty = 0;

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::RouteOrder, Send Order ID to External system = %s", pNewOrder->m_Order.ClOrdId);

		memcpy(&pRequest->NewOrder, &pNewOrder->m_Order, sizeof(pRequest->NewOrder));
		memcpy(&pRequest->OldOrder, &order->m_Order, sizeof(pRequest->OldOrder));

		pRequest->NewOrder.Price = price;
		pRequest->NewOrder.StopPx = StopPx;

		pRequest->OldOrder.Price = oldprice;
		pRequest->OldOrder.StopPx = oldStopPx;

		GatewayClient *pClient = GetClientObject(strLPName);

		if (pClient)
		{
			if (pClient->_AccountNo != 0)
			{
				pRequest->NewOrder.Account = pClient->_AccountNo;
				pRequest->OldOrder.Account = pClient->_AccountNo;
			}

			nSuccess = Send(pClient, pRequest, ORDER_REPLACE_REQUEST);
		}
		else
			nSuccess = ERR_INTERNAL_ERROR;

		free(pRequest);
	}
	else
		nSuccess = ERR_INTERNAL_ERROR;

	return nSuccess;
}

int ITRoute::RouteCancelOrder(void *order, std::string& strLPName, unsigned long long price, unsigned long long StopPx)
{
	int nSuccess = ERR_OK;

	if (order)
	{
		OrderCancelRequest *pRequest = (OrderCancelRequest *)order;

		if (pRequest)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::RouteCancelOrder, Send Order ID to External system = %s", pRequest->order.ClOrdId);

			pRequest->order.Price = price;
			pRequest->order.StopPx = StopPx;

			GatewayClient *pClient = GetClientObject(strLPName);

			if (pClient)
			{
				if (pClient->_AccountNo != 0)
				{
					pRequest->order.Account = pClient->_AccountNo;
				}

				nSuccess = Send(pClient, pRequest, ORDER_CANCEL_REQUEST);
			}
			else
				nSuccess = ERR_INTERNAL_ERROR;

			free(pRequest);
		}
	}
	else
	{
		nSuccess = ERR_INTERNAL_ERROR;
	}

	return nSuccess;
}

int ITRoute::Send(GatewayClient *pClient,void* msg,unsigned int msgtype)
{
	int nSuccess = 0;

	pClient->_ptrIClientProtocol->Send(pClient->_ClientID, msg, msgtype);

	return nSuccess;
}

bool ITRoute::ProcessResponse(void* msg,unsigned int msgtype)
{
	bool bSuccess = false;

	if (m_pConnManager)
		m_pConnManager->ProcessNextRequest(0, msg, msgtype);

	return bSuccess;
}

void ITRoute::SetConnectionMgr(IConnectionMgr *pConnMgr)
{
	m_pConnManager = pConnMgr;
}

int ITRoute::RouteOrderStatusRequest(IOrder *order, std::string strLPName)
{
	int nSuccess = ERR_OK;

	//return nSuccess;

	OrderStatusRequest *pRequest = (OrderStatusRequest *)GetMessageObject(ORDER_STATUS_REQUEST);

	if (pRequest)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITRoute::RouteOrderStatusRequest, Send Order ID to External system = %s", order->m_Order.ClOrdId);

		pRequest->Account = order->m_Order.Account;
		strcpy(pRequest->ClOrdId, order->m_Order.ClOrdId);
		pRequest->OrderId = order->m_Order.OrderID;
		memcpy(&pRequest->Symbol, &order->m_Order.Symbol, sizeof(order->m_Order.Symbol));
		pRequest->TransactTime = COleDateTime::GetCurrentTime();

		GatewayClient *pClient = GetClientObject(strLPName);

		if (pClient)
		{
			if (pClient->_AccountNo != 0)
			{
				pRequest->Account = pClient->_AccountNo;
			}

			nSuccess = Send(pClient, pRequest, ORDER_STATUS_REQUEST);
		}
		else
			nSuccess = ERR_INTERNAL_ERROR;

		free(pRequest);
	}
	else
		nSuccess = ERR_INTERNAL_ERROR;

	return nSuccess;
}

GatewayClient *ITRoute::GetClientObject(std::string& strLPName)
{
	std::map<std::string, GatewayClient *>::iterator iter = _ptrGatewayClientList.find(strLPName);
	
	GatewayClient *pClient = NULL;

	if (iter != _ptrGatewayClientList.end())
	{
		pClient = (*iter).second;
	}
	else
	{
		pClient = m_pDefaultClient;
	}

	return pClient;
}

int ITRoute::RouteReloadDPRRequest(void *pRequest1)
{
	int nSuccess = 0;

	ReloadDPR *pRequest = (ReloadDPR *)pRequest1;

	if (pRequest)
	{
		std::string strLPName = pRequest->sym1.Gateway;

		GatewayClient *pClient = GetClientObject(strLPName);

		if (pClient)
		{
			nSuccess = Send(pClient, pRequest, RELOAD_DPR);
		}

		free(pRequest);
	}

	return nSuccess;
}