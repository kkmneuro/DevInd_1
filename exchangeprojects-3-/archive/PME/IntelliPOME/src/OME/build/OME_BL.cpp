
#include "stdafx.h"
#include "OME_BL.h"
#include "OME_API.h"
#include "OrderRequest.h"
#include "SnapshotRequest.h"
#include "OrderHandler.h"
#include "xlogger.h"
#include "xconfigure.h"
#include "errordefs.h"
#include "GatewayClient.h"
#include "SessionManagement.h"

#define CONFIG_FILE "OME.ini"

OME_BL::OME_BL(IConnectionMgr* pIConnectionMgr,IConnectionMgr* pconnnetionMgrMDE)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::OME_BL, Entered");
	
	m_orderHandler = NULL;
	ReadConfig();

	m_connnetionMgr=pIConnectionMgr;
	m_connnetionMgrMDE=pconnnetionMgrMDE;

	// Create Databases
	m_databaseMgr = CreateDatabase(); 

	if (m_databaseMgr)
	{
		if( ! m_databaseMgr->Open( m_strUserNameBO.c_str() , m_strPasswordBO.c_str() , m_strConnStringBO.c_str()) )
		{
			ReleaseDatabase( m_databaseMgr );
			m_databaseMgr = NULL;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::OME_BL, Unable to connect to database BO");
		}
	}


	m_DatabaseOME = CreateDatabase(); 

	if (m_DatabaseOME)
	{
		if( ! m_DatabaseOME->Open( m_strUserNameOME.c_str() , m_strPasswordOME.c_str() , m_strConnStringOME.c_str()) )
		{
			ReleaseDatabase( m_DatabaseOME );
			m_DatabaseOME = NULL;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::OME_BL, Unable to connect to database OME");
		}
	}

	m_pClient = NULL;
	
	InitializeSystem();
	m_pClient = new GatewayClient(this);

	if (m_pClient)
	{
		m_pClient->login("system", "system", "127.0.0.1", "127.0.0.1", 9038);
		//m_pClient->login("system", "system", "127.0.0.1", "127.0.0.1", 9013);
		//m_pClient->login("system", "system", "103.9.103.19", "103.9.103.19", 9033);
	}

	m_pSessionMgmt = new SessionManagement(m_databaseMgr, this);

	if (m_pSessionMgmt)
	{
		m_pSessionMgmt->SetSessionEventHandler(SessionCallbackEvent);
		// Start the Reviewer thread.
		m_pSessionMgmt->CreateReviewerThread();
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::OME_BL, Unable to allocate memory to SessionManagement");
	}

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::OME_BL, Exit");
}

void				OME_BL::InitializeSystem()
{
	m_orderHandler=new OrderHandler(this,m_connnetionMgr,m_connnetionMgrMDE, m_databaseMgr, m_DatabaseOME, m_pClient);
}

OME_BL::~OME_BL()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::~OME_BL, Entered");
	delete m_orderHandler;
}


IRequest* OME_BL::getIRequestPointer(MESSAGE msg)
{
	IRequest* reqMsg=NULL;
	pstructureHeader ptrHeader=(pstructureHeader)msg.msg;

	if (ptrHeader->MessageType == QUOTES_STREAM)
	{
		QuotesStream *pStream = (QuotesStream *)msg.msg;

		if (pStream)
		{
			m_orderHandler->HandlePriceUpdate(pStream);
			free(pStream);
		}
	}
	else if(ptrHeader->MessageType==NEW_ORDER_REQUEST)
	{
		pNewOrderRequest ptrNewOrderReq=(pNewOrderRequest)msg.msg;

		switch(ptrNewOrderReq->order.OrderType)
		{
		case ORDER_TYPE_MARKET_ORDER:
			reqMsg=new MarketOrderRequest(msg.msg,m_orderHandler);
			break;
		case ORDER_TYPE_LIMIT_ORDER:
			reqMsg=new LimitOrderRequest(msg.msg,m_orderHandler);
			break;
		case ORDER_TYPE_STOP_ORDER:
			reqMsg=new StopOrderRequest(msg.msg,m_orderHandler);
			break;
		case ORDER_TYPE_STOP_LIMIT_ORDER:
			reqMsg=new StopOrderRequest(msg.msg,m_orderHandler);
			break;
		}
	}
	else if (ptrHeader->MessageType ==ORDER_CANCEL_REQUEST)
	{
		pOrderCancelRequest ptrOrderCancelReq=(pOrderCancelRequest)msg.msg;

		switch (ptrOrderCancelReq->order.OrderType)
		{
			case ORDER_TYPE_MARKET_ORDER:
				// Send business level rejection message
				SendBusinessReject(ORDER_CANCEL_REQUEST,
									INVALID_ORDER_TYPE_FOR_USER_MARKET_ORDER,
									ptrOrderCancelReq->order.ClOrdId,
									"Market order cannot be cancelled");
				break;
			case ORDER_TYPE_LIMIT_ORDER:
			case ORDER_TYPE_STOP_ORDER:
			case ORDER_TYPE_STOP_LIMIT_ORDER:
				reqMsg=new CancelOrderRequest(msg.msg,m_orderHandler);
				break;
		}
	}
	else if (ptrHeader->MessageType == ORDER_REPLACE_REQUEST)
	{
		pOrderReplaceRequest ptrOrderReplaceReq=(pOrderReplaceRequest)msg.msg;

		switch (ptrOrderReplaceReq->OldOrder.OrderType)
		{
			case ORDER_TYPE_MARKET_ORDER:
				SendBusinessReject(ORDER_REPLACE_REQUEST,
									INVALID_ORDER_TYPE_FOR_USER_MARKET_ORDER,
									ptrOrderReplaceReq->OldOrder.ClOrdId,
									"Market order cannot be Cancel Replaced");
				break;
			case ORDER_TYPE_LIMIT_ORDER:
			case ORDER_TYPE_STOP_ORDER:
			case ORDER_TYPE_STOP_LIMIT_ORDER:
				reqMsg=new CancelReplaceOrderRequest(msg.msg,m_orderHandler);
				break;
		}
	}
	else if (ptrHeader->MessageType == QUOTE__SNAPSHOT_REQUEST)
	{
		reqMsg=new SnapshotRequest(msg.msg,m_orderHandler);
	}
	else if (ptrHeader->MessageType == ORDER_STATUS_REQUEST)
	{
		reqMsg = new OrderStatusReq(msg.msg, m_orderHandler);
	}
	else if (ptrHeader->MessageType == OCO_ORDER_REQUEST)
	{
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::getIRequestPointer, Message Type = %u", msg.msgType);
	}

	return reqMsg;
}

void OME_BL::onNewClientAdded(unsigned int clientID, IConnectionMgr *ptrMgr)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::onNewClientAdded, Client ID=%ul", clientID);

	if (ptrMgr == m_connnetionMgr)
	{
		m_clientID=clientID;
	}
	else if (ptrMgr == m_connnetionMgrMDE)
	{
		m_clientIDMDE = clientID;
	}
}

void OME_BL::onClientDisconnected(unsigned int clientID)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::onClientDisconnected, clientID = %ul", clientID);
	m_clientID=0;
}
void OME_BL::setConnectionMgr(IConnectionMgr* ptrIConnectionMgr)
{
	//m_connnetionMgr=ptrIConnectionMgr;
}

unsigned int OME_BL::GetClientID()
{
	return m_clientID;
}

unsigned int OME_BL::GetClientIDMDE()
{
	return m_clientIDMDE;
}

OMEAPI IServerBL* __stdcall Create_OME_BL (IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE)
{
	return new OME_BL(pIConnectionMgr,pIConnectionMgrMDE);
}

void OME_BL::ReadConfig()
{
	long port = 0;
	xconfigure ConfigObj( CONFIG_FILE);
	ConfigObj.GetParameterString( "DATABASEBO", std::string("CONN_STRING"), m_strConnStringBO); 
	ConfigObj.GetParameterString( "DATABASEBO", std::string("USERNAME"), m_strUserNameBO); 
	ConfigObj.GetParameterString( "DATABASEBO", std::string("PASSWORD"), m_strPasswordBO); 

	ConfigObj.GetParameterString( "DATABASEOME", std::string("CONN_STRING"), m_strConnStringOME); 
	ConfigObj.GetParameterString( "DATABASEOME", std::string("USERNAME"), m_strUserNameOME); 
	ConfigObj.GetParameterString( "DATABASEOME", std::string("PASSWORD"), m_strPasswordOME); 

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::ReadConfig, DATABASEBO:ConnString = %s,Username = %s, Password = %s, DATABASEOME:ConnString = %s,Username = %s, Password = %s",
													m_strConnStringBO.c_str(),
													m_strUserNameBO.c_str(),
													m_strPasswordBO.c_str(),
													m_strConnStringOME.c_str(),
													m_strUserNameOME.c_str(),
													m_strPasswordOME.c_str());

}

void OME_BL::SendBusinessReject(char reqType,
								int BusinessRejectReason,
								char *BusinessRejectRefID,
								char *reason)
{
	BusinessLevelReject *pReject = (BusinessLevelReject *)GetMessageObject(BUSINESS_LEVEL_REJECT);

	if (pReject)
	{
		pReject->RefMsgType = reqType;
		pReject->BusinessRejectReason = BusinessRejectReason;
		strcpy(pReject->BusinessRejectRefID, BusinessRejectRefID);
		strcpy(pReject->Text, reason);

		m_connnetionMgr->SendResponseToQueue((unsigned int)0, (void *)pReject, BUSINESS_LEVEL_REJECT);

		free(pReject);
	}
}



int OME_BL::SessionCallbackEvent(std::list<std::string>& lstOpen, 
								std::list<std::string>& lstClose, 
								std::list<std::string>& lstEOD, 
								std::list<std::string>& lstForMM, 
								OME_BL *pOMEBL, 
								bool bTrade)
{
	int nSuccess = ERR_OK;

	pOMEBL->ManageCurrentMarketSessions(lstOpen, lstClose, lstEOD, lstForMM, bTrade);

	return nSuccess;
}

void OME_BL::ManageCurrentMarketSessions(std::list<std::string>& lstOpenList, 
										 std::list<std::string>& lstCloseList, 
										 std::list<std::string>& lstEODList, 
										 std::list<std::string>& lstForMMList, 
										 bool bTrade)
{
	// Call EOD processing for each of the session

	if (!lstEODList.empty())
	{
		// Wait for 30 seconds to expire all orders to make sure there wont be
		// any new orders coming in and there wont be any synshronization issue
		Sleep(30000);
		std::list<std::string>::iterator iter = lstEODList.begin();

		for (;iter != lstEODList.end();iter++)
		{
			std::string& strSymbol = *iter;

			m_orderHandler->HandleEODProcessing(strSymbol);
		}
	}

	// Execute a SP to close positions for the day
	PositionHoldingAtEOD();
}


void OME_BL::PositionHoldingAtEOD()
{
	// Initialize the Markets by reading all the symbols from the DB
	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = m_databaseMgr->Execute("PME_PositionsHoldings",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "OME_BL::PositionHoldingAtEOD, Unable to execute SP PositionsHoldings");
				return ;
			}

			ReleaseParameter(param);
		}
	}

	ReleaseTable(tb);//release table object	
}