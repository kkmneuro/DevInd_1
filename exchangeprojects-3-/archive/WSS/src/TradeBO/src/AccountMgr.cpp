#include "AccountMgr.h"
#include "DatabaseInterface.h"
#include "RMSAPI.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "OMSAPI.h"
#include "ORSAPI.h"
#include "errordefs.h"
#include "IGlobalPosition.h"

AccountMgr::AccountMgr(IDatabase *pDatabase, IDatabase *pDatabaseOMS,DWORD dwCookie, IConnectionMgr *pConnMgr)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::AccountMgr, Entered");

	//InitializeCriticalSection(&CS_USER_ACC_LIST_MAP);
	//InitializeCriticalSection(&CS_USER_SESSION_LIST_MAP);
	//InitializeCriticalSection(&CS_SESSION_USER_MAP);
	//InitializeCriticalSection(&CS_ACC_USER_LIST_MAP);
	InitializeCriticalSection(&CS_ACC_IACCOUNT_MAP);
	InitializeCriticalSection(&m_csGroupSymbolList);
	InitializeCriticalSection(&CS_GRP_ENABLED_LIST);
	InitializeCriticalSection(&CS_CCP_SUBS);
	InitializeCriticalSection(&CS_ORDER_IACCOUNT);

	m_pRMSCalculatorFactory = CreateRMSCalculator();

	if (m_pRMSCalculatorFactory)
	{
		m_pDatabase = pDatabase;
		m_pDatabaseOMS = pDatabaseOMS;

		LoadAllGroupSymbolSpread();
		

		m_dwCode = dwCookie;
		m_pConnMgr = NULL;;
		m_pRoute = NULL;

		DWORD dwThreadID = 0;

    m_pGlobalPos = CreateGlobalPosition();

    if (m_pGlobalPos)
    {
      stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::AccountMgr, Unable to create object of IGlobalPosition");
    }

	LoadGlobalPositions();

		// Create thread to review all connections
		m_handleRMSMonitor = CreateThread(NULL,
											0,
											(LPTHREAD_START_ROUTINE)&AccountMgr::RMSMonitor,
											this,
											0,
											&dwThreadID);

		if (!m_handleRMSMonitor)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::AccountMgr, Unable to create thread for RMSMonitor");
		}
	}
	else
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::AccountMgr, Unable to Allocate memory for RMSCalculator");
	}
}
AccountMgr::~AccountMgr()
{
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::~AccountMgr, Entered");

	if (m_pRMSCalculatorFactory)
	{
		delete m_pRMSCalculatorFactory;
		m_pRMSCalculatorFactory = NULL;
	}

	//DeleteCriticalSection(&CS_USER_ACC_LIST_MAP);
	//DeleteCriticalSection(&CS_USER_SESSION_LIST_MAP);
	//DeleteCriticalSection(&CS_SESSION_USER_MAP);
	//DeleteCriticalSection(&CS_ACC_USER_LIST_MAP);
	DeleteCriticalSection(&CS_ACC_IACCOUNT_MAP);
	DeleteCriticalSection(&m_csGroupSymbolList);
}

void AccountMgr::Initialize()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::Initialize, Entered");
}

bool AccountMgr::Validate(logonRequest* logonReq,logonResponse* logonResp, IClientSession *pSession)
{
	bool returnflag = false;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::Validate, Entered");
	
	std::string InputUserName( logonReq->UserName );

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("LoginID",logonReq->UserName,sizeof(logonReq->UserName));
	param->AddParam("Password",logonReq->Password,sizeof(logonReq->Password));
	param->AddParam("AccountGroupID",logonReq->Header.SenderID,sizeof(logonReq->Header.SenderID));

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::Validate, Details. UserID=%s, Pass=%s, Group=%s",logonReq->UserName, logonReq->Password, logonReq->Header.SenderID );
	
	bool isSPExist = m_pDatabase->Execute("Exchange_IsUserAuthenticated",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::Validate, Unable to execute SP Exchange_IsUserAuthenticated");

		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		strcpy(logonResp->Reason, "Invalid Username or Password");

		return false;
	}
	
	int acc = 0;
	int GroupID = 0;

	tb->MoveFirst();
	while(!tb->IsEOF())//loop the table
	{
		tb->Get("PK_ParticipantId", acc);
		tb->Get("AccountGroupName",logonResp->BrokerName, sizeof(logonResp->BrokerName));
		tb->Get("AccountGroupID", GroupID);
		tb->Get("AccountTypeName", logonResp->AccountType, sizeof(logonResp->AccountType));
		tb->Get("IsLive", logonResp->IsLive);
		break;
	}

	if( acc > 0)
	{
		returnflag = true;
		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		if (m_pConnMgr->IsUserAlreadyLoggedIn(InputUserName.c_str(), pSession->GetClientId()))
		{
			strcpy(logonResp->Reason, "User already logged in from another location");	
			returnflag = false;
		}
		else
		{
			ITable* tb=CreateTable();
			IParameter* param=CreateParameter();
			param->AddParam("PartID",acc);
			
			bool isSPExist = m_pDatabase->Execute("Exchange_GetParticipantAccountInfo",*tb,*param);//execute sp
			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::Validate, Unable to execute SP Exchange_GetParticipantAccountInfo");

				ReleaseTable(tb);//release table object
				ReleaseParameter(param);//release parameter object

				return false;
			}

      bool bCCP = false;

      if (strcmp(logonResp->AccountType, "CCP") == 0)
        bCCP = true;

			AddAccount(logonReq->UserName, pSession, bCCP, tb);

			ReleaseTable(tb);//release table object
			ReleaseParameter(param);//release parameter object
		}
	}
	else
	{
		returnflag = false;
		strcpy(logonResp->Reason, "Invalid Username or Password");
	}

	return returnflag;
}
void AccountMgr::AddAccount(logonRequest* logonReq,IClientSession* clSession)
{
	
	//TO DO....after using please free it
	//Now I am freeing becoz there is no use of this object
	free(logonReq);
}
void AccountMgr::Remove(IClientSession* clientSession)
{
	AcquireLock(&CS_ACC_IACCOUNT_MAP);

	std::list<IAccount *>& AccList = clientSession->GetAccountList();

	std::list<IAccount *>::iterator iter = AccList.begin();

	int nSuccess = 0;

	while (iter != AccList.end())
	{
		nSuccess = 0;
		IAccount *pAcc = (*iter);

		if (pAcc)
		{
			nSuccess = pAcc->RemoveSession(clientSession);
			iter = clientSession->RemoveAccount(pAcc, iter);
		}

		if (AccList.empty())
			break;

		//if (nSuccess == -1)
		//{
		//	// Remove account from Account list
		//	//AccList.remove(pAcc);
		//	iter = AccList.erase(iter);
		//}

		//iter++;
	}

  EnterCriticalSection(&CS_CCP_SUBS);

  m_CCPSubscribers.erase(clientSession->GetClientId());

  LeaveCriticalSection(&CS_CCP_SUBS);


	ReleaseLock(&CS_ACC_IACCOUNT_MAP);
}

void AccountMgr::AddAccount(char *ptrUserName, IClientSession *ptrSession, bool bIsCCP, ITable *ptrTable)
{
	AcquireLock(&CS_ACC_IACCOUNT_MAP);
	
	double				lfBalance;
	int					nLeverage;
	int					nGroup;
	double				lfFreeMargin;
	double				lfMargin;
	double				lfUsedMargin;
	bool				bHedge;
	bool				bEnableTrade;
	bool				bRMSEnable;
	double				lfDayRealizedProfit;
	
	double				lfBuyTurnover;
	double				lfSellTurnover;

	int					nMarginCall1;
	int					nMarginCall2;
	int					nMarginCall3;

	char				szTraderName[100];
	char				szAccountType[20];
	int					nHedgingtype = 0;

	double				LotSize = 0;

	char szLPName[20];

	ptrSession->SetUserName(ptrUserName);

  if (bIsCCP)
  {
    EnterCriticalSection(&CS_CCP_SUBS);

    std::map<unsigned int, unsigned int>::iterator iter = m_CCPSubscribers.find(ptrSession->GetClientId());

    if (iter == m_CCPSubscribers.end())
    {
      std::pair<unsigned int, unsigned int> pr(ptrSession->GetClientId(),ptrSession->GetClientId());
      m_CCPSubscribers.insert(pr);
    }

    LeaveCriticalSection(&CS_CCP_SUBS);
  }

	unsigned long ulAccount = 0;

	ptrTable->MoveFirst();
	while(!ptrTable->IsEOF())//loop the table
	{
		ptrTable->Get("Account", ulAccount);

		// the Account is not in memory, so load it in memory and initialize IAccount Object
		ptrTable->Get("Balance", lfBalance);
		ptrTable->Get("Leverage", nLeverage);
		ptrTable->Get("AccountGroupID", nGroup);
		ptrTable->Get("UsedMargin", lfUsedMargin);
		ptrTable->Get("HedgingAllowed", bHedge);
		ptrTable->Get("EnableTrade", bEnableTrade);
		ptrTable->Get("BuySideTurnover", lfBuyTurnover);
		ptrTable->Get("SellSideTurnover", lfSellTurnover);
		ptrTable->Get("DayRealizedProfit", lfDayRealizedProfit);
		ptrTable->Get("LP_Name", szLPName, sizeof(szLPName));
		ptrTable->Get("RMS_Enable", bRMSEnable);
		ptrTable->Get("MarginCallLevel1", nMarginCall1);
		ptrTable->Get("MarginCallLevel2", nMarginCall2);
		ptrTable->Get("MarginCallLevel3", nMarginCall3);
		ptrTable->Get("TraderName", szTraderName, sizeof(szTraderName));
		ptrTable->Get("AccountType", szAccountType, sizeof(szAccountType));
		ptrTable->Get("HedgeType", nHedgingtype);
		ptrTable->Get("AccountMode", LotSize);

		ACC_IACCOUNT_MAP::iterator iter = m_AccIAccMap.find(ulAccount);

		if (iter != m_AccIAccMap.end())
		{
			IAccount *pAcc = (*iter).second;

			if (pAcc)
			{
				pAcc->AddSession(ptrSession);
				ptrSession->AddAccount(pAcc);

				pAcc->UpdateAccount(ulAccount, 
								bRMSEnable,
								szLPName,
								lfBalance,
								0,
								nLeverage,
								nGroup,
								0,
								0,
								lfUsedMargin,
								bHedge,
								bEnableTrade,
								lfDayRealizedProfit,
								lfBuyTurnover,
								lfSellTurnover,
								nMarginCall1,
								nMarginCall2,
								nMarginCall3,
								szTraderName,
								szAccountType,
								m_pDatabase,
								m_pDatabaseOMS);

			}
		}
		else
		{
			IAccount *pAccount = CreateAccountObject(nHedgingtype);

			if (pAccount)
			{
				pAccount->Init(ulAccount, 
								bRMSEnable,
								szLPName,
								lfBalance,
								0,
								nLeverage,
								nGroup,
								0,
								0,
								lfUsedMargin,
								bHedge,
								bEnableTrade,
								lfDayRealizedProfit,
								lfBuyTurnover,
								lfSellTurnover,
								nMarginCall1,
								nMarginCall2,
								nMarginCall3,
								szTraderName,
								szAccountType,
								nHedgingtype,
								LotSize,
								m_pDatabase,
								m_pDatabaseOMS,
								m_pRMSCalculatorFactory);

				pAccount->AddSession(ptrSession);
				ptrSession->AddAccount(pAccount);

				LoadWorkingOrders(pAccount);
				LoadOpenPosOrders(pAccount);
				LoadLinkedOrders(pAccount);

				std::pair<unsigned int, IAccount *> pr(ulAccount, pAccount);
				m_AccIAccMap.insert(pr);
			}
		}

		ptrTable->MoveNext();
	}

	ReleaseLock(&CS_ACC_IACCOUNT_MAP);
}


//bool AccountMgr::GetAccountList(std::string userName, list<IAccount *>& lstIAccount)
//{
//	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::GetAccountList, Entered");
//
//	AcquireLock(&CS_USER_ACC_LIST_MAP);
//	AcquireLock(&CS_ACC_IACCOUNT_MAP);
//
//	USER_ACC_LIST_MAP::iterator iter = m_UserAccListMap.find(userName);
//
//	if (iter != m_UserAccListMap.end())
//	{
//		// Account is available
//		pair<std::string, map<unsigned int, unsigned int>> pr = *iter;
//		map<unsigned int, unsigned int>& accountList = pr.second;
//		map<unsigned int, unsigned int>::iterator itr;
//
//		for (itr = accountList.begin(); itr != accountList.end(); itr++)
//		{
//			pair<unsigned int, unsigned int> pr = *itr;
//
//			ACC_IACCOUNT_MAP::iterator iACIter = m_AccIAccMap.find(pr.first);
//
//			if (iACIter != m_AccIAccMap.end())
//			{
//				IAccount *pAccount = (*iACIter).second;
//
//				lstIAccount.push_back(pAccount);
//			}
//		}
//	}
//
//	ReleaseLock(&CS_ACC_IACCOUNT_MAP);
//	ReleaseLock(&CS_USER_ACC_LIST_MAP);
//
//	
//	return !lstIAccount.empty();
//}
//
//
IAccount *AccountMgr::GetIAccount(unsigned int account)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::GetIAccount, Entered");

	IAccount *pAcc = NULL;

	AcquireLock(&CS_ACC_IACCOUNT_MAP);

	ACC_IACCOUNT_MAP::iterator iACIter = m_AccIAccMap.find(account);

	if (iACIter != m_AccIAccMap.end())
	{
		IAccount *pAccount = (*iACIter).second;
		pAcc = pAccount;
	}

	ReleaseLock(&CS_ACC_IACCOUNT_MAP);

	return pAcc;
}

int AccountMgr::LoadLinkedOrders(IAccount *pAcc)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			param->AddParam("AccID", (unsigned int)pAcc->m_Account);

			bool isSPExist = m_pDatabaseOMS->Execute("OMS_LoadLinkedOrders",*tb,*param);//execute sp

			if( !isSPExist )
			{
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ITOrder::DeleteLinkedOrders, Unable to execute SP OMS_DeleteLinkedOrders");
				nSuccess = ERR_INTERNAL_ERROR;
			}

			while (!tb->IsEOF())
			{
				IOrder *pOrder = CreateOrderObject();

				if (pOrder)
				{
					pOrder->InitLinkedOrder(tb, m_pDatabaseOMS);
					
					pAcc->AddLinkedOrder(pOrder->m_Order.LnkdOrdId, pOrder);	
				}

				tb->MoveNext();
			}
		}

		ReleaseParameter(param);//release parameter object
	}

	return nSuccess;
}

int AccountMgr::LoadWorkingOrders(IAccount *pAccount)
{
	int nSuccess = 0;
	int Success = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("AccountID",(unsigned int)pAccount->m_Account);
	param->AddParam("Success",Success);
	
	bool isSPExist = m_pDatabaseOMS->Execute("OMS_GetListOfWorkingOrderByAccountID",*tb,*param);//execute sp
	if( !isSPExist )
	{
		nSuccess = ERR_INTERNAL_ERROR_DB;
		return nSuccess;
	}	

	char productType[10];
	int count = 0;

	char contractName[20];
	IOrder *pOrder = NULL;

	while (!tb->IsEOF())
	{
		pOrder = CreateOrderObject();

		if (pOrder)
		{
			pOrder->Init(tb, m_pDatabaseOMS);

			pAccount->LoadWorkingOrder(pOrder);
			pOrder->m_Order.Account = pAccount->m_Account;
			AddToClOrderIDIAccountMap(pOrder->m_Order.ClOrdId, pAccount);

			// Send Order status request to exchange
			if (m_pRoute)
			{
				//m_pRoute->RouteOrderStatusRequest(pOrder, pAccount->GetAssociatedLPName());
				m_pRoute->RouteOrderStatusRequest(pOrder, pOrder->m_Order.Symbol.Gateway);
			}

			tb->MoveNext();
		}
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}


int AccountMgr::LoadOpenPosOrders(IAccount *pAccount)
{
	int nSuccess = 0;
	int Success = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	param->AddParam("AccountID",(unsigned int)pAccount->m_Account);
	param->AddParam("Success",Success);
	
	bool isSPExist = m_pDatabaseOMS->Execute("OMS_GetListOfNonSettledOrderByAccountID",*tb,*param);//execute sp
	if( !isSPExist )
	{
		nSuccess = ERR_INTERNAL_ERROR_DB;
		return nSuccess;
	}	

	char productType[10];
	int count = 0;

	char contractName[20];
	IOrder *pOrder = NULL;

	while (!tb->IsEOF())
	{
		pOrder = CreateOrderObject();

		if (pOrder)
		{
			pOrder->Init(tb, m_pDatabaseOMS);
			pOrder->m_Order.Account = pAccount->m_Account;

			pAccount->LoadOpenPosOrder(pOrder);
			
			tb->MoveNext();
		}
	}

	LoadAllNonSettledMapping(pAccount);

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	return nSuccess;
}

std::map<unsigned int, IAccount*>& AccountMgr::GetAccountMap()
{
	return m_AccIAccMap;
}

DWORD AccountMgr::RMSMonitor (LPVOID lpdwThreadParam )
{
	AccountMgr *pMgr = (AccountMgr *)lpdwThreadParam;

	if (pMgr)
	{
		CoInitializeEx(NULL, COINIT_MULTITHREADED);
		CComGITPtr<IContractManager>pToGITTest(pMgr->m_dwCode);

		IContractManager *pContractManager;
		pToGITTest.CopyTo(&pContractManager);

		while (1)
		{
			ACC_IACCOUNT_MAP& mapAccounts = pMgr->GetAccountMap();

			ACC_IACCOUNT_MAP::iterator iter = mapAccounts.begin();

			for (;iter != mapAccounts.end(); iter++)
			{
				IAccount *pAcc = (*iter).second;

				if (pAcc)
				{
					pAcc->CalculatePnLAndLiquidate(pContractManager, pMgr->m_pConnMgr);
				}
			}

			// Sleep for 5 seconds
			Sleep(30000);
		}
	}

	return 0L;
}

void AccountMgr::SetConnectionMgr(IConnectionMgr *pConnMgr)
{
	m_pConnMgr = pConnMgr;
}

void AccountMgr::LoadAllAccounts()
{
	AcquireLock(&CS_ACC_IACCOUNT_MAP);

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	// This only loads all the accounts that has working order.
	bool isSPExist = m_pDatabase->Execute("Exchange_LoadAllAccountInformation_New",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::LoadAllAccounts, Unable to execute SP Exchange_GetParticipantAccountInfo");

		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		ReleaseLock(&CS_ACC_IACCOUNT_MAP);

		return;
	}

	unsigned int		ulAccount;
	double				lfBalance;
	int					nLeverage;
	int					nGroup;
	double				lfFreeMargin;
	double				lfMargin;
	double				lfUsedMargin;
	bool				bHedge;
	bool				bEnableTrade;
	bool				bRMSEnable;
	double				lfDayRealizedProfit;
	
	double				lfBuyTurnover;
	double				lfSellTurnover;

	int					nMarginCall1;
	int					nMarginCall2;
	int					nMarginCall3;

	char				szTraderName[100];
	char				szAccountType[20];

	int					nHedgingtype;
	double				lfLotSize;

	char szLPName[20];

	while(!tb->IsEOF())//loop the table
	{
		tb->Get("Account", ulAccount);
		tb->Get("Balance", lfBalance);
		tb->Get("Leverage", nLeverage);
		tb->Get("AccountGroupID", nGroup);
		tb->Get("UsedMargin", lfUsedMargin);
		tb->Get("HedgingAllowed", bHedge);
		tb->Get("EnableTrade", bEnableTrade);
		tb->Get("BuySideTurnover", lfBuyTurnover);
		tb->Get("SellSideTurnover", lfSellTurnover);
		tb->Get("DayRealizedProfit", lfDayRealizedProfit);
		tb->Get("LP_Name", szLPName, sizeof(szLPName));
		tb->Get("RMS_Enable", bRMSEnable);
		tb->Get("MarginCallLevel1", nMarginCall1);
		tb->Get("MarginCallLevel2", nMarginCall2);
		tb->Get("MarginCallLevel3", nMarginCall3);
		tb->Get("TraderName", szTraderName, sizeof(szTraderName));
		tb->Get("AccountType", szAccountType, sizeof(szAccountType));
		tb->Get("HedgeType", nHedgingtype);
		tb->Get("AccountMode", lfLotSize);
		
		tb->MoveNext();

		IAccount *pAccount = CreateAccountObject(nHedgingtype);
		pAccount->Init(ulAccount, 
						bRMSEnable,
						szLPName,
						lfBalance,
						0,
						nLeverage,
						nGroup,
						0,
						0,
						lfUsedMargin,
						bHedge,
						bEnableTrade,
						lfDayRealizedProfit,
						lfBuyTurnover,
						lfSellTurnover,
						nMarginCall1,
						nMarginCall2,
						nMarginCall3,
						szTraderName,
						szAccountType,
						nHedgingtype,
						lfLotSize,
						m_pDatabase,
						m_pDatabaseOMS,
						m_pRMSCalculatorFactory);

		LoadWorkingOrders(pAccount);
		LoadOpenPosOrders(pAccount);
		LoadLinkedOrders(pAccount);

		std::pair<unsigned int, IAccount *> pr(ulAccount, pAccount);
		m_AccIAccMap.insert(pr);
	}

	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter object

	ReleaseLock(&CS_ACC_IACCOUNT_MAP);
}

void AccountMgr::SetRoute(IRoute *pRoute)
{
	m_pRoute = pRoute;
}

int AccountMgr::ReLoadAllGroupSymbolSpread()
{
	int nSuccess = 0;

	ITable* tb=CreateTable();

	if (tb)
	{
		IParameter* param=CreateParameter();

		if (param)
		{
			bool isSPExist = m_pDatabase->Execute("Exchange_ListOfGroupSymbolSpread",*tb,*param);//execute sp
			if( !isSPExist )
			{
				return -1;
			}	
			
			int AccountGroupID;
			symbol sym;
			SymbolSpread _ObjSymbolSpread;

			EnterCriticalSection(&m_csGroupSymbolList);

			while (!tb->IsEOF())
			{
				tb->Get("FK_AccountGroupId", AccountGroupID);
				tb->Get("Contract",sym.Contract ,sizeof(sym.Contract));
				tb->Get("ProductName",sym.Product,sizeof(sym.Product));
				tb->Get("Gateway",sym.Gateway ,sizeof(sym.Gateway));
				tb->Get("ProductType",sym.ProductType);
				tb->Get("BidSpread",_ObjSymbolSpread.BidMarkUp);
				tb->Get("AskSpread",_ObjSymbolSpread.AskMarkUp);		
				tb->Get("Spread",_ObjSymbolSpread.lfSpread);		
				tb->Get("Fixed",_ObjSymbolSpread.Fixed);
				tb->Get("FeeValue",_ObjSymbolSpread.lfFees);
				tb->Get("TaxPercent",_ObjSymbolSpread.lfTax);


				GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(AccountGroupID);
				
				std::string key;
				GetKey(sym, key);

				if(iter == m_mapGroupSymbol.end())
				{
					// Group is not present in the map
					// insert GroupID along with SymbolSpreadMap
					std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
					SYMBOL_SPREAD_MAP mapSymbolSpread;

					mapSymbolSpread.insert(pr);
					
					std::pair<unsigned int,SYMBOL_SPREAD_MAP> pr1(AccountGroupID,mapSymbolSpread);

					m_mapGroupSymbol.insert(pr1);
				} 
				else
				{
					SYMBOL_SPREAD_MAP& mapSymbolSpread = iter->second;

					SYMBOL_SPREAD_MAP::iterator iter = mapSymbolSpread.find(key);

					if (iter != mapSymbolSpread.end())
					{
						mapSymbolSpread.erase(iter);
					}

					std::pair<std::string,SymbolSpread> pr(key, _ObjSymbolSpread);
					mapSymbolSpread.insert(pr);
				}

				tb->MoveNext();
			}

			LeaveCriticalSection(&m_csGroupSymbolList);
			
			ReleaseParameter(param);//release parameter object
		}

		ReleaseTable(tb);//release table object
	}

	return nSuccess;

}



int AccountMgr::LoadAllGroupSymbolSpread()
{
	int nSuccess = 0;

	if (m_pDatabase)
	{
		ITable* tb = CreateTable();

		if (tb)
		{
			IParameter* param = CreateParameter();

			if (param)
			{
				bool isSPExist = m_pDatabase->Execute("Exchange_ListOfGroupSymbolSpread_New", *tb, *param);//execute sp
				if (!isSPExist)
				{
					return -1;
				}

				int AccountGroupID;
				symbol sym;
				SymbolSpread _ObjSymbolSpread;

				EnterCriticalSection(&m_csGroupSymbolList);
				char szVal[5];
				int kk = 0;
				while (!tb->IsEOF())
				{
					kk++;
					tb->Get("FK_AccountGroupId", AccountGroupID);
					tb->Get("Contract", sym.Contract, sizeof(sym.Contract));
					tb->Get("ProductName", sym.Product, sizeof(sym.Product));
					tb->Get("Gateway", sym.Gateway, sizeof(sym.Gateway));
					tb->Get("ProductType", szVal, sizeof(szVal));
					sym.ProductType = szVal[0];
					tb->Get("BidSpread", _ObjSymbolSpread.BidMarkUp);
					tb->Get("AskSpread", _ObjSymbolSpread.AskMarkUp);
					tb->Get("Spread", _ObjSymbolSpread.lfSpread);
					tb->Get("Fixed", _ObjSymbolSpread.Fixed);
					tb->Get("FeeValue", _ObjSymbolSpread.lfFees);
					tb->Get("TaxPercent", _ObjSymbolSpread.lfTax);

					GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(AccountGroupID);

					std::string key;
					GetKey(sym, key);

					if (iter == m_mapGroupSymbol.end())
					{
						// Group is not present in the map
						// insert GroupID along with SymbolSpreadMap
						std::pair<std::string, SymbolSpread> pr(key, _ObjSymbolSpread);
						SYMBOL_SPREAD_MAP mapSymbolSpread;

						mapSymbolSpread.insert(pr);

						std::pair<unsigned int, SYMBOL_SPREAD_MAP> pr1(AccountGroupID, mapSymbolSpread);

						m_mapGroupSymbol.insert(pr1);
					}
					else
					{
						SYMBOL_SPREAD_MAP& mapSymbolSpread = iter->second;

						std::pair<std::string, SymbolSpread> pr(key, _ObjSymbolSpread);
						mapSymbolSpread.insert(pr);
					}

					tb->MoveNext();
				}

				LeaveCriticalSection(&m_csGroupSymbolList);

				ReleaseParameter(param);//release parameter object
			}

			ReleaseTable(tb);//release table object
		}
	}
	else
		nSuccess = -1;

	return nSuccess;

}

void AccountMgr::GetKey(symbol& sym, std::string& key)
{
	key.append(sym.Gateway);
	key.append("_");
	key.append(sym.Contract);
}

int AccountMgr::GetMarkupPrice(symbol& sym, char side, bool bUp, unsigned long long price, unsigned long long& ulMarkedupPrice, int nGroupID, SymbolSpread& sp)
{
	int nSuccess = 0;

	if (price == 0)
	{
		ulMarkedupPrice = 0;
	}
	else
	{
		if (side == SIDE_BUY)
		{
			if (bUp)
			{
				if (sp.Fixed)
				{
					ulMarkedupPrice = price;
				}
				else
				{
					ulMarkedupPrice = price - sp.AskMarkUp;
				}
			}
			else
			{
				if (sp.Fixed)
				{
					ulMarkedupPrice = price;
				}
				else
				{
					ulMarkedupPrice = price + sp.AskMarkUp;
				}
			}
		}
		else if (side == SIDE_SELL)
		{
			if (bUp)
			{
				ulMarkedupPrice = price + sp.BidMarkUp;
			}
			else
			{
				ulMarkedupPrice = price - sp.BidMarkUp;
			}
		}

		LeaveCriticalSection(&m_csGroupSymbolList);
	}

	return nSuccess;
}

int AccountMgr::GetSpreadInfo(symbol& sym, SymbolSpread& symSpread, int nGroupID)
{
	int nSuccess = -1;

	EnterCriticalSection(&m_csGroupSymbolList);

	std::string key;
	GetKey(sym, key);

	GROUP_SYMBOL_SPREAD_MAP::iterator iter = m_mapGroupSymbol.find(nGroupID);

	if (iter != m_mapGroupSymbol.end())
	{
		SYMBOL_SPREAD_MAP& symSpreadMap = iter->second;

		if (!symSpreadMap.empty())
		{
			SYMBOL_SPREAD_MAP::iterator iter1 = symSpreadMap.find(key);

			if (iter1 != symSpreadMap.end())
			{
				symSpread = iter1->second;
				nSuccess = 0;
			}
		}
	}

	LeaveCriticalSection(&m_csGroupSymbolList);

	return nSuccess;
}


int AccountMgr::EnableAccounts(unsigned long id, bool bEnable)
{
	int nSuccess = ERR_OK;

	// Synchronize in memory
	IAccount *pAccount = GetIAccount(id);

	if (pAccount)
	{
		pAccount->EnableAccount(bEnable);
	}

	return nSuccess;
}

int AccountMgr::LoadAllEnabledGroups()
{
	int nSuccess = ERR_OK;

	EnterCriticalSection(&CS_GRP_ENABLED_LIST);

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	// This only loads all the accounts that has working order.
	bool isSPExist = m_pDatabase->Execute("Exchange_EnableGroupList",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::LoadAllEnabledGroups, Unable to execute SP Exchange_EnableGroupList");

		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		LeaveCriticalSection(&CS_GRP_ENABLED_LIST);
		nSuccess = ERR_INTERNAL_ERROR_DB;

		return nSuccess;
	}

	tb->MoveFirst();
	unsigned int GrpID = 0;
	while(!tb->IsEOF())//loop the table
	{
		tb->Get("AccountGroupID", GrpID);

		std::pair<unsigned int, unsigned int> pr(GrpID, GrpID);
		m_EnabledGroupList.insert(pr);

		tb->MoveNext();
	}

	LeaveCriticalSection(&CS_GRP_ENABLED_LIST);

	return nSuccess;
}

bool AccountMgr::IsGroupEnabled(unsigned int grpId)
{
	bool bSuccess = false;

	EnterCriticalSection(&CS_GRP_ENABLED_LIST);

	GRP_ENABLED_LIST::iterator iter = m_EnabledGroupList.find(grpId);

	if (iter != m_EnabledGroupList.end())
	{
		bSuccess = true;
	}

	LeaveCriticalSection(&CS_GRP_ENABLED_LIST);

	return bSuccess;
}


int AccountMgr::UpdateGlobalPosition(symbol& sym, char side, unsigned long filledPrice, unsigned long filledQty, char PositionEffect)
{
  int bSuccess = 0;

  if (m_pGlobalPos)
  {
    //m_pGlobalPos->UpdatePosition(sym, side, filledPrice, filledQty, PositionEffect);
  }

  return bSuccess;
}

void AccountMgr::GetGlobalPosition(symbol& sym, 
                            unsigned long& ulLongPos,
                            unsigned long& ultotalBuyVal,
                            unsigned long& ulshortPos,
                            unsigned long& ulTotalSellVal,
							double&		   lgRealizedPnL,
                            double&        lfLongAvgPrice,
                            double&        lfShortAvgPrice)
{
  if (m_pGlobalPos)
  {
    m_pGlobalPos->GetPosition(sym,ulLongPos, ultotalBuyVal, ulshortPos, ulTotalSellVal, lgRealizedPnL, lfLongAvgPrice, lfShortAvgPrice);
  }
}


void AccountMgr::BroadcastToCCPs(PositionResponse *pResponse)
{
  EnterCriticalSection(&CS_CCP_SUBS);

  std::map<unsigned int, unsigned int>::iterator iter = m_CCPSubscribers.begin();

  for (; iter != m_CCPSubscribers.end(); iter++)
  {
    unsigned int clientID = iter->second;

    m_pConnMgr->SendResponseToQueue(clientID, pResponse, POSITION_RESPONSE);
  }

  LeaveCriticalSection(&CS_CCP_SUBS);
}

bool AccountMgr::IsCCPsSubscribed()
{
  return !m_CCPSubscribers.empty();
}

void AccountMgr::LoadGlobalPositions()
{
	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	GlobalPosition ps;
	char symbol1[20];
	
	bool isSPExist = m_pDatabaseOMS->Execute("Exchange_LoadPositionForCCP",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::LoadGlobalPositions, Unable to execute SP Exchange_LoadPositionForCCP");

		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		return;
	}
	
	tb->MoveFirst();
	while(!tb->IsEOF())//loop the table
	{
		symbol sym;

		tb->Get("Symbol", sym.Contract, sizeof(sym.Contract));
		tb->Get("OpenBuyUnit", ps.m_ulLongPosition);
		tb->Get("OpenSellUnit", ps.m_ulShortPosition);
		tb->Get("BuyCapital", ps.m_ulTotalBuyVal);
		tb->Get("SellCapital", ps.m_ulTotalSellVal);
		tb->Get("RealizedProfit", ps.m_lfRealizedProfit);

		m_pGlobalPos->UpdatePosition(sym, SIDE_BUY, ps.m_ulTotalBuyVal, ps.m_ulLongPosition, ps.m_lfRealizedProfit, POSITION_OPENING_TRADE);
		m_pGlobalPos->UpdatePosition(sym, SIDE_SELL, ps.m_ulTotalSellVal, ps.m_ulShortPosition, 0, POSITION_OPENING_TRADE);

		break;
	}

	ReleaseParameter(param);

	ReleaseTable(tb);
}


IAccount *AccountMgr::GetIAccountFromClOrderID(char *pszClOrdID)
{
	IAccount *pAccount = NULL;

	EnterCriticalSection(&CS_ORDER_IACCOUNT);

	std::map<std::string, IAccount *>::iterator iter = m_mapClOrdIDAccount.find(pszClOrdID);

	if (iter != m_mapClOrdIDAccount.end())
	{
		pAccount = iter->second;
	}

	LeaveCriticalSection(&CS_ORDER_IACCOUNT);

	return pAccount;
}

int AccountMgr::AddToClOrderIDIAccountMap(char *pszClOrdID, IAccount *pAccount)
{
	int nSuccess = 0;

	EnterCriticalSection(&CS_ORDER_IACCOUNT);

	std::map<std::string, IAccount *>::iterator iter = m_mapClOrdIDAccount.find(pszClOrdID);

	if (iter == m_mapClOrdIDAccount.end())
	{
		std::pair<std::string, IAccount *> pr(pszClOrdID, pAccount);

		m_mapClOrdIDAccount.insert(pr);
	}
	else
		nSuccess = ERR_INTERNAL_ERROR;

	LeaveCriticalSection(&CS_ORDER_IACCOUNT);

	return nSuccess;
}

int AccountMgr::RemoveFromClOrderIDIAccountMap(char *pszClOrdID)
{
	int nSuccess = 0;

	EnterCriticalSection(&CS_ORDER_IACCOUNT);

	std::map<std::string, IAccount *>::iterator iter = m_mapClOrdIDAccount.find(pszClOrdID);

	if (iter != m_mapClOrdIDAccount.end())
	{
		m_mapClOrdIDAccount.erase(iter);
	}
	else
		nSuccess = ERR_INTERNAL_ERROR;

	LeaveCriticalSection(&CS_ORDER_IACCOUNT);

	return nSuccess;
}


int AccountMgr::LoadAllNonSettledMapping(IAccount *pAccount)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();

	param->AddParam("AccountID",(unsigned int)pAccount->m_Account);

	bool isSPExist = m_pDatabaseOMS->Execute("OMS_LoadAllNonSettledMapping",*tb,*param);//execute sp
	if( !isSPExist )
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "AccountMgr::LoadAllNonSettledMapping, Unable to execute SP OMS_LoadAllNonSettledMapping");

		ReleaseTable(tb);//release table object
		ReleaseParameter(param);//release parameter object

		return ERR_INTERNAL_ERROR_DB;
	}

	pAccount->LoadAllNonSettledMapping(tb);
	
	ReleaseParameter(param);

	ReleaseTable(tb);

	return nSuccess;
}