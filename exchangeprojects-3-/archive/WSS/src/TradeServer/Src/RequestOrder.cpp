#include "RequestOrder.h"

RequestOrder::RequestOrder(IServerController* pServerController, IOrder* order)
{
	m_order=order;
	m_serverController=pServerController;
}

RequestOrder::~RequestOrder()
{
	//delete m_order;
}

void RequestOrder::Run()
{
	//Process with IOrder
}
bool RequestOrder::AutoDelete()
{
	return true;
}

