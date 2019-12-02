#include "StdAfx.h"
#include "SessionManagement.h"
#include "DatabaseInterface.h"
#include "errordefs.h"
#include "xlogger.h"

SessionManagement::SessionManagement(IDatabase *pDatabase, OME_BL *pQuotes)
{
	m_pDatabase = pDatabase;
	m_pRefBL = pQuotes;
}

SessionManagement::~SessionManagement(void)
{
}


int SessionManagement::GetOpenMarketContracts(std::list<std::string>& lstContractsTrades, 
											  std::list<std::string>& lstContractsQuotes,
											  std::list<std::string>& lstContractsTradesSessionForMM, 
											  std::list<std::string>& lstContractsTradesSessionWithEOD)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	
	COleDateTime oleDateTime = COleDateTime::GetCurrentTime();
	
	param->AddDateTimeParam("CurrentTime", oleDateTime);

	bool isSPExist = m_pDatabase->Execute("Exchange_GetOpenMktContracts",*tb,*param);//execute sp

	if( !isSPExist )
	{
		// Initialized failed
		nSuccess = ERR_INTERNAL_ERROR_DB ;
	}
	else
	{
		while (!tb->IsEOF())
		{
			char szContract[20];
			int nTrade; // 0 for trade and 1 for quotes
			int nEODSession = 0;
			int nSessionForMM = 0;

			tb->Get("Symbol", szContract, sizeof(szContract));
			tb->Get("SessionType", nTrade);
			tb->Get("EODSession", nEODSession);
			tb->Get("MarketMaker", nSessionForMM);

			if (nTrade == 0) // Trades
			{
				if (nSessionForMM == 1)
				{
					lstContractsTradesSessionForMM.push_back(szContract);
				}

				if (nEODSession)
				{
					lstContractsTradesSessionWithEOD.push_back(szContract);
				}

				lstContractsTrades.push_back(szContract);
			}
			else if (nTrade == 1) // Quotes
			{
				lstContractsQuotes.push_back(szContract);
			}

			tb->MoveNext();
		}
	}

	ReleaseTable(tb);//release table object

	return nSuccess;
}

int SessionManagement::SetSessionEventHandler(int (*pSessionCallbackEvent)(std::list<std::string>&, std::list<std::string>&, std::list<std::string>&, std::list<std::string>&, OME_BL *, bool))
{
	int nSuccess = 0;

	m_pSessionCallback = pSessionCallbackEvent;

	return nSuccess;
}

int SessionManagement::CreateReviewerThread()
{
	int nSuccess = 0;

	m_hThread = (HANDLE)_beginthreadex(NULL, 0, SessionManagement::SessionReviewerThread, this,0, NULL);

	return nSuccess;
}

unsigned int __stdcall SessionManagement::SessionReviewerThread(void* arg)
{
	SessionManagement *pMgmt = (SessionManagement *)arg;

	if (pMgmt)
	{
		COleDateTime NextDateForEvent;

		while (1)
		{
			double dNextTime;
			
			if (pMgmt->GetNextTime(dNextTime) == 0)
			{
				std::list<std::string> lstContractTradesOpen;
				std::list<std::string> lstContractTradesOpenEODProcessing;
				std::list<std::string> lstContractTradesOpenSessionForMM;
				std::list<std::string> lstContractTradesClose;
				std::list<std::string> lstContractQuotesOpen;
				std::list<std::string> lstContractQuotesClose;

				pMgmt->GetListOfContractsForTime(dNextTime, 
												lstContractTradesOpen,
												lstContractTradesOpenEODProcessing,
												lstContractTradesOpenSessionForMM,
												lstContractTradesClose,
												lstContractQuotesOpen,
												lstContractQuotesClose);

				NextDateForEvent = dNextTime;

				while (1)
				{
					COleDateTimeSpan span = NextDateForEvent - COleDateTime::GetCurrentTime();

					double dtime = span.GetTotalSeconds() * 1000; // in ms

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SessionManagement::SessionReviewerThread, Current time = %d:%d, Time = %d:%d, Seconds=%lf", COleDateTime::GetCurrentTime().GetHour(), COleDateTime::GetCurrentTime().GetMinute(), NextDateForEvent.GetHour(), NextDateForEvent.GetMinute(), dtime);

					//TRACE("Hello");
					//cout<<"hello";
													
					if (dtime > 3600000)
					{
						Sleep(3600000);
						dtime -= 3600000;
					}
					else
					{
						Sleep(dtime);
					}

					if (COleDateTime::GetCurrentTime() >= NextDateForEvent)
					{
						break;
					}
				}

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "SessionManagement::SessionReviewerThread, Time Hit");

				// Came out of loop, it means the time reached for open/close. Call callback function with all list.
				pMgmt->m_pSessionCallback(lstContractTradesOpen, lstContractTradesClose, lstContractTradesOpenEODProcessing, lstContractTradesOpenSessionForMM,pMgmt->GetOMEBLHandler(), true);

				lstContractTradesOpen.clear();
				lstContractTradesOpenEODProcessing.clear();
				lstContractTradesOpenSessionForMM.clear();
				lstContractQuotesOpen.clear();
				lstContractTradesClose.clear();
				lstContractQuotesClose.clear();
			}
		}
	}

	return 0L;
}

IDatabase *SessionManagement::GetDatabaseRef()
{
	return m_pDatabase;
}

int SessionManagement::GetNextTime(double& dDateTime)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	
	COleDateTime oleDateTime = COleDateTime::GetCurrentTime();
	
	param->AddDateTimeParam("CurrentTime", oleDateTime);

	bool isSPExist = m_pDatabase->Execute("Exchange_GetNextTime",*tb,*param);//execute sp

	if( !isSPExist )
	{
		// Initialized failed
		nSuccess = ERR_INTERNAL_ERROR_DB ;
	}
	else
	{
		while (!tb->IsEOF())
		{
			tb->GetDateTime("NextTime", dDateTime);

			break;
		}
	}

	ReleaseTable(tb);//release table object

	return nSuccess;
}

int SessionManagement::GetListOfContractsForTime(double dDateTime, 
								std::list<std::string>& lstContractTradesOpen, 
								std::list<std::string>& lstContractTradesOpenEODProcessing, 
								std::list<std::string>& lstContractTradesOpenSessionForMM, 
								std::list<std::string>& lstContractTradesClose,
								std::list<std::string>& lstContractQuotesOpen,
								std::list<std::string>& lstContractQuotesClose)
{
	int nSuccess = 0;

	ITable* tb=CreateTable();
	IParameter* param=CreateParameter();
	
	COleDateTime oleDateTime = COleDateTime::GetCurrentTime();
	
	param->AddDateTimeParam("CurrentTime", dDateTime);

	bool isSPExist = m_pDatabase->Execute("Exchange_GetNextTimeContractList",*tb,*param);//execute sp

	if( !isSPExist )
	{
		// Initialized failed
		nSuccess = ERR_INTERNAL_ERROR_DB ;
	}
	else
	{
		while (!tb->IsEOF())
		{
			char szContract[20];
			int nTrade; // 0 for trade, 1 for Quotes
			int nOpen; // 0 for open, 1 for close
			int nEODSession = 0;
			int nSessionForMM = 0;

			tb->Get("Contract", szContract, sizeof(szContract));
			tb->Get("SessionType", nTrade);
			tb->Get("SessionStatus", nOpen);
			tb->Get("EODSession", nEODSession);
			tb->Get("MarketMaker", nSessionForMM);

			if (nTrade == 0)
			{
				if (nOpen == 0)
				{
					lstContractTradesOpen.push_back(szContract);

					if (nSessionForMM)
						lstContractTradesOpenSessionForMM.push_back(szContract);
				}
				else if (nOpen == 1)
				{
					lstContractTradesClose.push_back(szContract);

					if (nEODSession)
						lstContractTradesOpenEODProcessing.push_back(szContract);
				}
			}
			else if (nTrade == 1)
			{
				if (nOpen == 0)
				{
					lstContractQuotesOpen.push_back(szContract);
				}
				else if (nOpen == 1)
				{
					lstContractQuotesClose.push_back(szContract);
				}
			}

			tb->MoveNext();
		}
	}

	ReleaseTable(tb);//release table object

	return nSuccess;
}