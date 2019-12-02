///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//07-02-2012	BR			1. Initial Structure Created.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class IOrder;

class ICancelOrder
{
protected:
	IOrder*					m_Order;
protected:
	// Validates the order. Based on request type/msg type, different functions are called.
	virtual int Validate() = 0;

	// Initialize the object. Overloaded functions to i nitialize using various request structures
	virtual int Init(CancelOrderRequest& request) = 0;
	virtual int Init(ExecutionReport& report) = 0;
public:

	// Process the Order. Calls various other functions for processing various types of msg
	virtual int ProcessOrder(CancelOrderRequest& request, void *pResponse) = 0;
	virtual int ProcessOrder(ExecutionReport& report, void *pResponse) = 0;

	// Process the Order. Calls various other functions for processing various types of msg
	virtual int GenerateExecutionReport() = 0;
	virtual int GenerateBusinessReject() = 0;

	// Database
	virtual int FetchRecordsUsingOrderId() = 0;
	virtual int FetchRecordsUsingClOrderId() = 0;

	virtual int UpdateOrder() = 0;
}