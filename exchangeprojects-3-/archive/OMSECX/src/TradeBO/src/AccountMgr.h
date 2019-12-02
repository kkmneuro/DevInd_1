#include "ServerInterface.h"
#include <string>

class IDatabase;
class ITable;
class RMSCalculatorFactory;
class IGlobalPosition;

typedef std::map<std::string,SymbolSpread>						SYMBOL_SPREAD_MAP;				
typedef std::map<unsigned int,SYMBOL_SPREAD_MAP>			GROUP_SYMBOL_SPREAD_MAP;

struct Deductions
{
	double fees;
	double tax;
};

typedef std::map<std::string, Deductions>		MAP_SYMBOL_DEDUCTIONS;
typedef std::map<int, MAP_SYMBOL_DEDUCTIONS>	MAP_GRP_SYMBOL_DEDUCTIONS;

class AccountMgr : public IAccountMgr
{
private:
	RMSCalculatorFactory									*m_pRMSCalculatorFactory;
	typedef std::map<unsigned int, IAccount*>						ACC_IACCOUNT_MAP;
	ACC_IACCOUNT_MAP										m_AccIAccMap;

	CRITICAL_SECTION										CS_ACC_IACCOUNT_MAP;

	IDatabase*												m_pDatabase;
	IDatabase*												m_pDatabaseOMS;

	HANDLE													m_handleRMSMonitor;

	DWORD													m_dwCode;
	IConnectionMgr*											m_pConnMgr;		
	IRoute*													m_pRoute;

	CRITICAL_SECTION										m_csGroupSymbolList;
	GROUP_SYMBOL_SPREAD_MAP									m_mapGroupSymbol;

	typedef std::map<unsigned int, unsigned int>				GRP_ENABLED_LIST;
	CRITICAL_SECTION										CS_GRP_ENABLED_LIST;
	GRP_ENABLED_LIST										m_EnabledGroupList;

  CRITICAL_SECTION							CS_CCP_SUBS;
  std::map<unsigned int, unsigned int>		m_CCPSubscribers;

  CRITICAL_SECTION							CS_ORDER_IACCOUNT;
  std::map<std::string, IAccount *>			m_mapClOrdIDAccount;

protected:
	void AddAccount(char *ptrUserName, IClientSession *ptrSession, bool bIsCCP, ITable *ptrTable);
public:

  IGlobalPosition                     *m_pGlobalPos;
	AccountMgr(IDatabase *ptrDatabase, 
				IDatabase *ptrDatabaseOMS,
				DWORD dwCookie,
				IConnectionMgr *pConnMgr);

	~AccountMgr();

	IAccount *GetIAccountFromClOrderID(char *pszClOrdID);
	int AddToClOrderIDIAccountMap(char *pszClOrdID, IAccount *pAccount);
	int RemoveFromClOrderIDIAccountMap(char *pszClOrdID);

	void Initialize();
	void AddAccount(LogonRequest* logonReq,IClientSession* clSession);
	void Remove(IClientSession* clientSession);
	bool Validate(logonRequest* logonReq,LogonResponse* logonResp, IClientSession *pSession);

	IAccount *GetIAccount(unsigned int account);

	bool LoadPositions(unsigned long Account);

	int LoadWorkingOrders(IAccount *pAcc);
	int LoadOpenPosOrders(IAccount *pAcc);
	int LoadLinkedOrders(IAccount *pAcc);
	int                 LoadAllGroupSymbolSpread();
	int                 ReLoadAllGroupSymbolSpread();

	static DWORD RMSMonitor (LPVOID lpdwThreadParam );

	std::map<unsigned int, IAccount*>& GetAccountMap();
	void SetConnectionMgr(IConnectionMgr *pConnMgr);

	void LoadAllAccounts();

	void SetRoute(IRoute *pRoute);
	int GetMarkupPrice(symbol& sym, char side, bool bUp, unsigned long long price, unsigned long long& ulMarkedupPrice, int nGroupID, SymbolSpread& sp);
	int GetSpreadInfo(symbol& sym, SymbolSpread& symSpread, int nGroupID);
	void GetKey(symbol& sym, std::string& key);

	int EnableAccounts(unsigned long id, bool bEnable);

	int LoadAllEnabledGroups();

	bool IsGroupEnabled(unsigned int grpId);

  int UpdateGlobalPosition(symbol& sym, char side, unsigned long filledPrice, unsigned long filledQty, char PositionEffect);

  void GetGlobalPosition(symbol& sym, 
                            unsigned long& ulLongPos,
                            unsigned long& ultotalBuyVal,
                            unsigned long& ulshortPos,
                            unsigned long& ulTotalSellVal,
							double&		   lgRealizedPnL,
                            double&        lfLongAvgPrice,
                            double&        lfShortAvgPrice);

  void BroadcastToCCPs(PositionResponse *pResponse);

  bool IsCCPsSubscribed();

  void LoadGlobalPositions();

  int LoadAllNonSettledMapping(IAccount *pAccount);
};
