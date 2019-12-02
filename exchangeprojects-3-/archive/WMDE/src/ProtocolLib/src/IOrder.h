///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//13-01-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include <stdafx.h>
#include "DataDef.h"
#include <list>

class IDatabase;
class ITable;
class IPosition;
class IOrder;
struct OrderExecInfo;

struct OrderExecInfo
{
	IOrder				*pOrder;
	unsigned long long	Qty;
	unsigned long long  SettledQty;
	bool				bOpenPos;
};

class IOrder
{
public:
	Order					m_Order;
	// Execution Report
	double		AvgPx;
	unsigned long long		CumQty;						//Contains cumulated traded quantity throughout lifespan of an order. This value resets to zero if order is cancel/replaced.
	char					OrderStatus;				//Identifies order status as accepted, cancelled, or replaced. 
	unsigned long long		LeavesQty;					//Amount of contract units open for further execution. The format of this field is different from FIX protocol specifications. This field must be an integer. 
	char					Text[80];

	unsigned int			reqType;
	IDatabase*				m_pDatabase;

	unsigned long			m_ulQtyClosed;

	unsigned long			QtyClose;					// Stores the qty of the order that will be used for closing a position
	unsigned long			QtySettled;					// Stored the qty that has been settled.
	unsigned long			QtyCancelled;				// Qty that is either been rejected or cancelled

	double					m_lfUsedMargin;
	double					m_lfCommission;
	double					m_lfTax;
	double					m_lfProfit;

	double					m_lfExtraUsedMargin;

    double			              m_CounterAvgPx;
	unsigned long				  m_MMAccount;
    char                          m_CounterClOrdId[20];
	char						  m_szIPAddress[16];

	bool							m_bLinkedOrder;

	std::list<OrderExecInfo>	m_lstTaggedOrders;
public:
	virtual std::string ToString() = 0;

	// Initialize the object. Overloaded functions to i nitialize using various request structures
	virtual int Init(Order& request, IDatabase *pDatabase, char reqType) = 0;
	//virtual int Init(ExecutionReport& report) = 0;

	virtual int Init(ITable *tb, IDatabase *pDatabase) = 0;
	virtual int InitLinkedOrder(ITable *tb, IDatabase *pDatabase) = 0;

	virtual int AddOrderToTag(unsigned long long qty, unsigned long long SettledQty, IOrder *pOrder, bool bOpenPos, OrderExecInfo *pInfo = NULL) = 0;

	virtual std::list<OrderExecInfo>& GetTaggedOrderList() = 0;
public:

	// Process the Order. Calls various other functions for processing various types of msg
	virtual int ProcessOrder(void*& pResponse, IContractManager *pContractManager) = 0;
	virtual int ProcessCancelOrder(void*& pResponse) = 0;
	virtual int ProcessCancelReplaceOrder(void*& pResponse, IOrder *pOldOrder, IContractManager *pContractManager) = 0;

	virtual int ProcessExecutionReport(ExecutionReport *pReport) = 0;

	virtual int UpdateOrder() = 0;

	virtual int UpdateOrder(ExecutionReport *pReport,
							double lfBalance, 
							double lfUsedMargin, 
							double DayBuySideTurnOver, 
							double DaySellSideTurnOver, 
							double DayRealizedProfit, 
							unsigned long ulLongTempPos, 
							unsigned long ulShortTempPos,
							double lfSellSideUM,
							double lfBuySideUM,
							double lfOverAllUM) = 0;

	virtual NewOrderRequest *&GetNewOrderRequest() = 0;

	virtual int GenerateExecutionReport(void*& pResponse) = 0;
	virtual int InsertOrder(double lfBalance, 
					double lfUsedMargin, 
					double DayBuySideTurnOver, 
					double DaySellSideTurnOver, 
					double DayRealizedProfit, 
					unsigned long ulLongTempPos, 
					unsigned long ulShortTempPos) = 0;
	virtual void SetIPAddress(char *pszIPAddress) = 0;

	virtual int InsertLinkedOrder(char *pszLnkOrdID) = 0;

	virtual int UpdateOrderMapping(OrderExecInfo *info) = 0;
};