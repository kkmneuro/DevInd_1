///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//29-01-2012	BR			1. Class declaration and definitions. The class manages the business logic for the OMS.
//9 Dec 23013	BR			Ticket: TradingApplication/80: Added Message MODIFY_ACCOUNT_OF_TRADE
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "TradeBOBL.h"
#include "AccountMgr.h"
#include "TradeBOAPI.h"
#include "OrderHandler.h"
#include "LogonRequest.h"
#include "OMsRequests.h"
#include "ExecutionRptHandler.h"
#include "ORSAPI.h"
#include "xlogger.h"
#include "xconfigure.h"


#define CONFIG_FILE "OMS.ini"
TradeBOBL::TradeBOBL()
{
	ReadConfig();

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Entered");

	// Create Databases
	m_DatabaseOMS = CreateDatabase(); 

	if (m_DatabaseOMS)
	{
		if( ! m_DatabaseOMS->Open( m_strUserNameOMS.c_str() , m_strPasswordOMS.c_str() , m_strConnStringOMS.c_str() ) )
		{
			ReleaseDatabase( m_DatabaseOMS );
			m_DatabaseOMS = NULL;

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Unable to open OMS DB");
		}
	}

	// Create Databases
	m_DatabaseBO = CreateDatabase(); 

	if (m_DatabaseBO)
	{
		if( ! m_DatabaseBO->Open( m_strUserNameBO.c_str() , m_strPasswordBO.c_str() , m_strConnStringBO.c_str()) )
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Unable to open BO DB");
			ReleaseDatabase( m_DatabaseBO );
			m_DatabaseBO = NULL;
			//throw std::exception("Unable to connect database BO");
		}
	}
	
	// Initialize COM
	CoInitializeEx(NULL, COINIT_MULTITHREADED);
	HRESULT hr = m_pContractManager.CreateInstance(CLSID_ContractManager);

	if (FAILED(hr))
	{
		_com_error error(hr);
		LPCTSTR errorText = error.ErrorMessage();

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Initialization of Contract Manager Failed. Error = %s", errorText);
	}
	else
	{
		CComGITPtr<IContractManager> GITInterface(m_pContractManager);
		m_dwGitCookie = GITInterface.Detach();
		m_pContractManager->InitializeServer();
	}

	_ptrAccountMgr = new AccountMgr(m_DatabaseBO, m_DatabaseOMS, m_dwGitCookie, _ptrConnectionMgr);

	if (!_ptrAccountMgr)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Unable to allocate memory for AccountMgr");
	}

	m_pRoute = CreateRouteObject(m_DatabaseBO);

	if (!m_pRoute)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::TradeBOBL, Unable to allocate memory for IRoute");
	}

	_ptrAccountMgr->SetRoute(m_pRoute);
	_ptrAccountMgr->LoadAllEnabledGroups();
	_ptrAccountMgr->LoadAllAccounts();
}



IRequest* TradeBOBL::getIRequestPointer(MESSAGE msg)
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Msg Type = %d", msg.msgType);

	IRequest* ptrIRequest = NULL;

	switch (msg.msgType)
	{
	case RELOAD_DPR:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	case CHANGE_PASSWORD:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, CHANGE_PASSWORD request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		//unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession)
		break;
	case LOGON_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Session handler request");
		ptrIRequest = new SessionHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		//unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession)
		break;
	case PARTICIPANT_LIST_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Participant list request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		//unsigned int reqType, void *ptrRequest, IConnectionMgr *ptrConnectionMgr, IAccountMgr *ptrAccountMgr, IClientSession *ptrSession)
		break;
	case NEW_ORDER_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, New Order request");
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	case ORDER_HISTORY_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		break;
	case TRADE_HISTORY_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		break;
	case POSITION_REQUEST:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, POSITION_REQUEST request");
		//ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		break;
	case ORDER_STATUS_RESPONSE:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order status request");
		ptrIRequest = new ExecutionRptHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_dwGitCookie);
		break;
	case POSITION_RESPONSE:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Position Response");
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	case ACCOUNT_RESPONSE:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Position Response");
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	case ORDER_CANCEL_REQUEST:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order Cancel request");
		break;
	case ORDER_REPLACE_REQUEST:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order Replace request");
		break;
	case ORDER_BOOK_REQUEST:
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order Book request");
		break;
	case STOP_ORDER_REQUEST:
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Stop Order request");
		break;
	case MATCHED_ORDER_REQUEST:		
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseOMS);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Matched Order request");
		break;
	case LINKED_ORDER_REQUEST:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	case MAIL_DELIVERY:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		break;
	case ACCOUNT_UPDATE_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		break;
	case RELOAD_CONFIG:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		break;
	case TRADE_MGMT_REQUEST:
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::getIRequestPointer, Order history request");
		ptrIRequest = new OMSRequestHandler(msg.msgType, msg.msg, _ptrConnectionMgr, _ptrAccountMgr, _ptrConnectionMgr->GetClientSession(msg.clientId) ,m_DatabaseBO);
		break;
	case MODIFY_ACCOUNT_OF_TRADE:
		ptrIRequest = new OrderHandler(msg.msgType, msg.msg, _ptrConnectionMgr, m_DatabaseOMS, _ptrAccountMgr, m_pRoute, m_dwGitCookie, msg.clientId);
		break;
	// Connection from Gateway.
	case LOGON_RESPONSE:
		break;

	}

	return ptrIRequest;
}

void TradeBOBL::onNewClientAdded(unsigned clientID,IConnectionMgr * mgr)
{
}

void TradeBOBL::onNewClientAdded(IClientSession *clientID)
{

}

void TradeBOBL::onClientDisconnected(unsigned clientID)
{
	IClientSession *pSession = _ptrConnectionMgr->GetClientSession(clientID);

	if (pSession)
	{
		_ptrAccountMgr->Remove(pSession);
	}
}

void TradeBOBL::setConnectionMgr(IConnectionMgr* ptrIConnectionMgr)
{
	if (ptrIConnectionMgr)
	{
		_ptrConnectionMgr = ptrIConnectionMgr;
		m_pRoute->SetConnectionMgr(_ptrConnectionMgr);
		_ptrAccountMgr->SetConnectionMgr(ptrIConnectionMgr);
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "TradeBOBL::setConnectionMgr, setConnectionMgr is NULL");
	}
}

IServerBL* __stdcall CreateBusinessObject(IConnectionMgr *pMgr)
{
	TradeBOBL *pTradeBOBL = NULL;

	pTradeBOBL = new TradeBOBL();

	/*if (pTradeBOBL)
	{
		pTradeBOBL->setConnectionMgr(pMgr);
	}
*/
	return pTradeBOBL;
}

unsigned int TradeBOBL::GetClientID()
{
	return 0;
}

unsigned int TradeBOBL::GetClientIDMDE()
{
	return 0;
}

void TradeBOBL::ReadConfig()
{
	long port = 0;
	xconfigure ConfigObj( CONFIG_FILE);
	ConfigObj.GetParameterString( "DATABASEBO", std::string("CONN_STRING"), m_strConnStringBO); 
	ConfigObj.GetParameterString( "DATABASEBO", std::string("USERNAME"), m_strUserNameBO); 
	ConfigObj.GetParameterString( "DATABASEBO", std::string("PASSWORD"), m_strPasswordBO); 

	ConfigObj.GetParameterString( "DATABASEOMS", std::string("CONN_STRING"), m_strConnStringOMS); 
	ConfigObj.GetParameterString( "DATABASEOMS", std::string("USERNAME"), m_strUserNameOMS); 
	ConfigObj.GetParameterString( "DATABASEOMS", std::string("PASSWORD"), m_strPasswordOMS); 

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "TradeBOBL::ReadConfig, DATABASEBO:ConnString = %s,Username = %s, Password = %s, DATABASEOMS:ConnString = %s,Username = %s, Password = %s",
		m_strConnStringBO.c_str(),
													m_strUserNameBO.c_str(),
													m_strPasswordBO.c_str(),
													m_strConnStringOMS.c_str(),
													m_strUserNameOMS.c_str(),
													m_strPasswordOMS.c_str());
}

