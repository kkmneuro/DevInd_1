#pragma once

#include <list>
#include <atlcomtime.h>
using namespace std;
class IDatabase;
class OME_BL;


class SessionManagement
{
public:
	SessionManagement(IDatabase *pDatabase = NULL, OME_BL *pOmeBl = NULL);
	~SessionManagement(void);
	
	int GetOpenMarketContracts(std::list<std::string>& lstContractsTrades, 
								std::list<std::string>& lstContractsQuotes,
								std::list<std::string>& lstContractsTradesSessionForMM, 
								std::list<std::string>& lstContractsTradesSessionWithEOD);

	typedef int (*SessionCallbackEvent)(std::list<std::string>&, 
										std::list<std::string>&, 
										std::list<std::string>&, 
										std::list<std::string>&, 
										OME_BL *, 
										bool bTrade) ;

	int SetSessionEventHandler(int (*pSessionCallbackEvent)(std::list<std::string>&, 
															std::list<std::string>&, 
															std::list<std::string>&, 
															std::list<std::string>&, 
															OME_BL *, 
															bool bTrade));

	IDatabase *GetDatabaseRef();
	int GetNextTime(double& oleDateTime);

	int GetListOfContractsForTime(double dDateTime, 
									std::list<std::string>& lstContractTradesOpen, 
									std::list<std::string>& lstContractTradesOpenEODProcessing, 
									std::list<std::string>& lstContractTradesOpenSessionForMM, 
									std::list<std::string>& lstContractTradesClose,
									std::list<std::string>& lstContractQuotesOpen,
									std::list<std::string>& lstContractQuotesClose);

	SessionCallbackEvent m_pSessionCallback;

	OME_BL *GetOMEBLHandler(){return m_pRefBL;};

	int CreateReviewerThread();
private:
	IDatabase *m_pDatabase;
	HANDLE m_hThread;

	OME_BL *m_pRefBL;
	
	static unsigned int __stdcall SessionReviewerThread(void* arg);
};
