#include "ServerInterface.h"

class RequestOrder : public IRequest
{
private:
	IOrder*					m_order;
	IServerController*		m_serverController;

public:
	RequestOrder(IServerController*	pServerController, IOrder* order);
	virtual ~RequestOrder();
	virtual void Run();
	virtual bool AutoDelete();
};