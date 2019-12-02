#include <stdafx.h>
#include "DataDef.h"
#include "ObjectPool.h"
#include "buffer.h"

class MemoryManager
{
// Public methods
public: 
	static MemoryManager* getInstance();
	~MemoryManager();
	void *GetMessageObject(char msgType);
	void ReleaseObject(void *pObject, char msgType);

// Private methods
private:
	MemoryManager();			
	void ReadConfig();	

	// Private members
private:
	static MemoryManager* m_pObjectPool;

	CObjectPool<LogonRequest> *m_poolLogonRequest;
	CObjectPool<LogoutRequest> *m_poolLogoutRequest;
	CObjectPool<NewOrderRequest> *m_poolNewOrderRequest;
	CObjectPool<OrderCancelRequest> *m_poolOrderCancelRequest;
	CObjectPool<OrderReplaceRequest> *m_poolOrderReplaceRequest;
	CObjectPool<OrderStatusRequest> *m_poolOrderStatusRequest;
	CObjectPool<AccountRequest> *m_poolAccountRequest;
	CObjectPool<PositionRequest> *m_poolPositionRequest;
	CObjectPool<OrderHistoryRequest> *m_poolOrderHistoryRequest;
	CObjectPool<ParticipantListRequest> *m_poolParticipantListRequest;
	CObjectPool<ParticipantListResponse> *m_poolParticipantListResponse;
	CObjectPool<QuoteSubscriptionRequest> *m_poolQuoteSubscriptionRequest;
	CObjectPool<QuoteUnsubscriptionRequest> *m_poolQuoteUnsubscriptionRequest;
	CObjectPool<QuoteRequest> *m_poolQuoteRequest;
	CObjectPool<NewsRequest> *m_poolNewsRequest;
	CObjectPool<TradeHistoryRequest> *m_poolTradeHistoryRequest;
	CObjectPool<LogonResponse> *m_poolLogonResponse;
	CObjectPool<OrderStatusResponse> *m_poolOrderStatusResponse;
	CObjectPool<RejectMessageResponse> *m_poolRejectMessageResponse;
	CObjectPool<OrderCancelRejectResponse> *m_poolOrderCancelRejectResponse;
	CObjectPool<AccountResponse> *m_poolAccountResponse;
	CObjectPool<PositionResponse> *m_poolPositionResponse;
	CObjectPool<OrderHistoryResponse> *m_poolOrderHistoryResponse;
	CObjectPool<BusinessLevelReject> *m_poolBusinessLevelReject;
	CObjectPool<QuotesSnapshotResponse> *m_poolQuotesSnapshotResponse;
	CObjectPool<QuotesStream> *m_poolQuotesStream;
	CObjectPool<NewsSubscription> *m_poolNewsSubscription;
	CObjectPool<NewsStream> *m_poolNewsStream;
	CObjectPool<TopGainersLosers> *m_poolTopGainersLosers;
	CObjectPool<TradeHistoryResponse> *m_poolTradeHistoryResponse;
	CObjectPool<HeartbeatFromOMS> *m_poolHeartbeat;
	CObjectPool<CBuffer> *m_poolBuffer;

	long LogonRequest_Size;
	long LogoutRequest_Size;
	long NewOrderRequest_Size; 
	long OrderCancelRequest_Size; 
	long OrderReplaceRequest_Size; 
	long OrderStatusRequest_Size; 
	long AccountRequest_Size; 
	long PositionRequest_Size; 
	long OrderHistoryRequest_Size; 
	long ParticipantListRequest_Size;
	long QuoteSubscriptionRequest_Size;
	long QuoteUnsubscriptionRequest_Size; 
	long QuoteRequest_Size;
	long NewsRequest_Size;
	long TradeHistoryRequest_Size;
	long LogonResponse_Size; 
	long OrderStatusResponse_Size; 
	long RejectMessageResponse_Size; 
	long OrderCancelRejectResponse_Size;
	long AccountResponse_Size; 
	long PositionResponse_Size; 
	long OrderHistoryResponse_Size; 
	long BusinessLevelReject_Size; 
	long QuotesSnapshotResponse_Size; 
	long QuotesStream_Size; 
	long NewsSubscription_Size; 
	long NewsStream_Size; 
	long TopGainersLosers_Size; 
	long TradeHistoryResponse_Size; 
	long ParticipantListResponse_Size;
	long HeartBeat_Size;
	long Buffer_Size;
};