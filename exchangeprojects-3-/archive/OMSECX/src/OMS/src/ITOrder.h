///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//08-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "IOrder.h"
#include "stdafx.h"
#include <stdlib.h>
#include <malloc.h>
#include "ServerInterface.h"

class ITOrder: public IOrder
{
public:
	ITOrder();

	int Init(Order& request, IDatabase *pDatabase, char reqType);
	int Init(ITable *tb, IDatabase *pDatabase);
	int InitLinkedOrder(ITable *tb, IDatabase *pDatabase);

	virtual ~ITOrder();
public:
	//int Remove(IOrder *pOrder);
	std::string ToString();
	/*int AssociateOrders(std::list<IOrder *> *pOpenOrderList, unsigned long& MarginQty);

	int ManageAssociatedOrders(ExecutionReport *pReport, unsigned long& OpenQty, IPosition *pPosition);

	int TryClosingOpenOrders(IOrder* pOpenOrder, ExecutionReport *pReport, unsigned long& OpenQty, IPosition *pPosition);*/
	// Initialize the object. Overloaded functions to i nitialize using various request structures

	// Process the Order. Calls various other functions for processing various types of msg
	int ProcessOrder(void*& pResponse, IContractManager *pContractManager);
	int ProcessCancelOrder(void*& pResponse);
	int ProcessCancelReplaceOrder(void*& pResponse, IOrder *pOldOrder, IContractManager *pContractManager);

	int GenerateExecutionReport(void*& pResponse);
	int GenerateBusinessReject(int nErrorCode, void*& pResponse);

	int UpdateOrder();

	int UpdateOrder(ExecutionReport *pReport,
					double lfBalance, 
					double lfUsedMargin, 
					double DayBuySideTurnOver, 
					double DaySellSideTurnOver, 
					double DayRealizedProfit, 
					unsigned long ulLongTempPos, 
					unsigned long ulShortTempPos,
					double lfSellSideUM,
					double lfBuySideUM,
					double lfOverAllUM);

	int InsertOrder(double lfBalance, 
					double lfUsedMargin, 
					double DayBuySideTurnOver, 
					double DaySellSideTurnOver, 
					double DayRealizedProfit, 
					unsigned long ulLongTempPos, 
					unsigned long ulShortTempPos);

	NewOrderRequest *&GetNewOrderRequest();

	int ProcessExecutionReport(ExecutionReport *pReport);

	void SetIPAddress(char *pszIPAddress);
	int InsertLinkedOrder(char *pszLnkOrdID);

	int AddOrderToTag(unsigned long long qty, unsigned long long SettledQty, IOrder *pOrder, bool bOpenPos, OrderExecInfo *pInfo = NULL);

	std::list<OrderExecInfo>& GetTaggedOrderList();

	int InsertOrderMapping();

	int UpdateOrderMapping(OrderExecInfo *pInfo, int Cancelled1);
};