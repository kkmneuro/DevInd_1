#include "IRoute.h"
#include <string>
#include <map>
//#include "ServerInterface.h"

class GatewayClient;
class IConnectionMgr;
class IDatabase;
//class IAccountMgr;

class ITRoute: public IRoute
{
private:
	std::map<std::string, GatewayClient *>	_ptrGatewayClientList;

	IConnectionMgr	*m_pConnManager;

	std::string		m_strUserName;
	std::string		m_strPassword;

	IDatabase		*m_pDatabase;

	GatewayClient	*m_pDefaultClient; 

	//IAccountMgr		*m_pAcctMgr;
public:
	ITRoute(IDatabase *pDatabaseBO);
	int RouteOrder(IOrder *pOrder, std::string& strLPName, unsigned long long price, unsigned long long StopPx);
	bool ProcessResponse(void* msg,unsigned int msgtype);
	void SetConnectionMgr(IConnectionMgr *pConnMgr);
	int RouteCancelOrder(void *order, std::string& strLPName, unsigned long long price, unsigned long long StopPx);
	int RouteCROrder(IOrder *order, IOrder *pNewOrder, std::string& strLPName, unsigned long long price, unsigned long long StopPx, unsigned long long priceOld, unsigned long long StopPxOld);
	int	LoadAllGateways();
	int RouteOrderStatusRequest(IOrder *order, std::string strLPName);
	int RouteReloadDPRRequest(void *pRequest);

	int Send(GatewayClient *pClient,void* msg,unsigned int msgtype);

	GatewayClient *GetClientObject(std::string& strLPName);
};