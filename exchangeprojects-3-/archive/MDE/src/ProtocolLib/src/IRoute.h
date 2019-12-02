#include <string>

class IOrder;
class IConnectionMgr;

class IRoute
{
protected:
public:
	virtual int RouteOrder(IOrder *order, std::string& strLPName) = 0;
	virtual int RouteCancelOrder(void *order, std::string& strLPName) = 0;
	virtual int RouteCROrder(IOrder *order, IOrder *pNewOrder, std::string& strLPName) = 0;
	virtual void SetConnectionMgr(IConnectionMgr *pConnMgr) = 0;
	virtual bool ProcessResponse(void* msg,unsigned int msgtype) = 0;
	virtual int RouteOrderStatusRequest(IOrder *order, std::string strLPName) = 0;
};