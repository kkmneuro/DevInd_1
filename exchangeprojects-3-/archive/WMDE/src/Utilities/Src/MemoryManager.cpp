#include "stdafx.h"
#include "MemoryManager.h"
#include "xconfigure.h"
#include "UtilitiesApi.h"

#define		CONFIG_FILE		"MemoryManager.ini"
using namespace std;

MemoryManager* MemoryManager::m_pObjectPool = NULL;

void MemoryManager::ReadConfig()
{
	xconfigure ConfigObj(CONFIG_FILE);
	std::string strCon; 

	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("LogonRequest_Size"), LogonRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("LogoutRequest_Size"), LogoutRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("NewOrderRequest_Size"), NewOrderRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderCancelRequest_Size"), OrderCancelRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderReplaceRequest_Size"), OrderReplaceRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderStatusRequest_Size"), OrderStatusRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("AccountRequest_Size"), AccountRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("PositionRequest_Size"), PositionRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderHistoryRequest_Size"), OrderHistoryRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("ParticipantListRequest_Size"), ParticipantListRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("QuoteSubscriptionRequest_Size"), QuoteSubscriptionRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("QuoteUnsubscriptionRequest_Size"), QuoteUnsubscriptionRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("QuoteRequest_Size"), QuoteRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("NewsRequest_Size"), NewsRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("TradeHistoryRequest_Size"), TradeHistoryRequest_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("LogonResponse_Size"),   LogonResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderStatusResponse_Size"),   OrderStatusResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("RejectMessageResponse_Size"),  RejectMessageResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderCancelRejectResponse_Size"),  OrderCancelRejectResponse_Size);
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("AccountResponse_Size"),   AccountResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("PositionResponse_Size"),  PositionResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("OrderHistoryResponse_Size"), OrderHistoryResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("BusinessLevelReject_Size"),  BusinessLevelReject_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("QuotesSnapshotResponse_Size"), QuotesSnapshotResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("QuotesStream_Size"),   QuotesStream_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("NewsSubscription_Size"), NewsSubscription_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("NewsStream_Size"),  NewsStream_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("TopGainersLosers_Size"),  TopGainersLosers_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("TradeHistoryResponse_Size"),   TradeHistoryResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("ParticipantListResponse_Size"),   ParticipantListResponse_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("Heartbeat_Size"),   HeartBeat_Size); 
	ConfigObj.GetParameterLong( "ObjectPoolStartUp", std::string("Buffer_Size"),   Buffer_Size); 
}

MemoryManager::MemoryManager()
{
	ReadConfig();

	m_poolLogonRequest =  new CObjectPool<LogonRequest>( LogonRequest_Size );
	m_poolLogoutRequest =  new CObjectPool<LogoutRequest>( LogoutRequest_Size );
	m_poolNewOrderRequest =  new CObjectPool<NewOrderRequest>( NewOrderRequest_Size );
	m_poolOrderCancelRequest =  new CObjectPool<OrderCancelRequest>( OrderCancelRequest_Size );
	m_poolOrderReplaceRequest =  new CObjectPool<OrderReplaceRequest>( OrderReplaceRequest_Size );
	m_poolOrderStatusRequest =  new CObjectPool<OrderStatusRequest>( OrderStatusRequest_Size );
	m_poolAccountRequest =  new CObjectPool<AccountRequest>( AccountRequest_Size );
	m_poolPositionRequest =  new CObjectPool<PositionRequest>( PositionRequest_Size );
	m_poolOrderHistoryRequest =  new CObjectPool<OrderHistoryRequest>( OrderHistoryRequest_Size );
	m_poolParticipantListRequest =  new CObjectPool<ParticipantListRequest>( ParticipantListRequest_Size );
	m_poolQuoteSubscriptionRequest =  new CObjectPool<QuoteSubscriptionRequest>( QuoteSubscriptionRequest_Size );
	m_poolParticipantListResponse =  new CObjectPool<ParticipantListResponse>( ParticipantListResponse_Size);
	m_poolQuoteUnsubscriptionRequest =  new CObjectPool<QuoteUnsubscriptionRequest>( QuoteUnsubscriptionRequest_Size );
	m_poolQuoteRequest =  new CObjectPool<QuoteRequest>( QuoteRequest_Size );
	m_poolNewsRequest =  new CObjectPool<NewsRequest>( NewsRequest_Size );
	m_poolTradeHistoryRequest =  new CObjectPool<TradeHistoryRequest>( TradeHistoryRequest_Size );
	m_poolLogonResponse =  new	CObjectPool<LogonResponse> (LogonResponse_Size );				
	m_poolOrderStatusResponse =  new CObjectPool<OrderStatusResponse> (OrderStatusResponse_Size );
	m_poolRejectMessageResponse =  new CObjectPool<RejectMessageResponse> (RejectMessageResponse_Size );
	m_poolOrderCancelRejectResponse =  new CObjectPool<OrderCancelRejectResponse> (OrderCancelRejectResponse_Size );
	m_poolAccountResponse =  new	CObjectPool<AccountResponse> (AccountResponse_Size );
    m_poolPositionResponse =  new CObjectPool<PositionResponse> (PositionResponse_Size );
	m_poolOrderHistoryResponse =  new CObjectPool<OrderHistoryResponse> (OrderHistoryResponse_Size );
	m_poolBusinessLevelReject =  new	 CObjectPool<BusinessLevelReject> (BusinessLevelReject_Size );
	m_poolQuotesSnapshotResponse =  new CObjectPool<QuotesSnapshotResponse> (QuotesSnapshotResponse_Size );
	m_poolQuotesStream =  new CObjectPool<QuotesStream> (QuotesStream_Size );
	m_poolNewsSubscription =  new CObjectPool<NewsSubscription> (NewsSubscription_Size );
	m_poolNewsStream =  new	CObjectPool<NewsStream> (NewsStream_Size );
	m_poolTopGainersLosers =  new CObjectPool<TopGainersLosers> (TopGainersLosers_Size );
	m_poolTradeHistoryResponse =  new CObjectPool<TradeHistoryResponse> (TradeHistoryResponse_Size );
	m_poolHeartbeat=  new CObjectPool<HeartbeatFromOMS> (HeartBeat_Size);
	m_poolBuffer =  new CObjectPool<CBuffer> (Buffer_Size);
}

MemoryManager* MemoryManager::getInstance()
{
	 if(m_pObjectPool == NULL)
	 {
		m_pObjectPool = new MemoryManager();

	 }

	 return m_pObjectPool;
}


MemoryManager::~MemoryManager()
{
	delete m_poolLogonRequest;
 	delete m_poolLogoutRequest;
	delete m_poolNewOrderRequest; 
	delete m_poolOrderCancelRequest; 
	delete m_poolOrderReplaceRequest; 
	delete m_poolOrderStatusRequest; 
	delete m_poolAccountRequest; 
	delete m_poolPositionRequest; 
	delete m_poolOrderHistoryRequest; 
	delete m_poolParticipantListRequest;
	delete m_poolQuoteSubscriptionRequest;
	delete m_poolQuoteUnsubscriptionRequest; 
	delete m_poolQuoteRequest;
	delete m_poolNewsRequest;
	delete m_poolTradeHistoryRequest; 
	delete m_poolLogonResponse; 
	delete m_poolOrderStatusResponse;
	delete m_poolRejectMessageResponse;
	delete m_poolOrderCancelRejectResponse; 
	delete m_poolAccountResponse; 
	delete m_poolPositionResponse; 
	delete m_poolOrderHistoryResponse;
	delete m_poolBusinessLevelReject;
	delete m_poolQuotesSnapshotResponse; 
	delete m_poolQuotesStream; 
	delete m_poolNewsSubscription; 
	delete m_poolNewsStream; 
	delete m_poolTopGainersLosers; 
	delete m_poolTradeHistoryResponse; 

	m_poolLogonRequest = NULL;
	m_poolLogoutRequest = NULL; 
	m_poolNewOrderRequest = NULL; 
	m_poolOrderCancelRequest = NULL; 
	m_poolOrderReplaceRequest = NULL; 
	m_poolOrderStatusRequest = NULL; 
	m_poolAccountRequest = NULL; 
	m_poolPositionRequest = NULL; 
	m_poolOrderHistoryRequest = NULL; 
	m_poolParticipantListRequest = NULL;
	m_poolQuoteSubscriptionRequest = NULL;
	m_poolQuoteUnsubscriptionRequest = NULL; 
	m_poolQuoteRequest = NULL;
	m_poolNewsRequest = NULL; 
	m_poolTradeHistoryRequest = NULL; 
	m_poolLogonResponse =  NULL; 
	m_poolOrderStatusResponse =  NULL;
	m_poolRejectMessageResponse =  NULL;
	m_poolOrderCancelRejectResponse =  NULL; 
	m_poolAccountResponse =  NULL; 
	m_poolPositionResponse =  NULL; 
	m_poolOrderHistoryResponse =  NULL;
	m_poolBusinessLevelReject =  NULL;
	m_poolQuotesSnapshotResponse =  NULL; 
	m_poolQuotesStream =  NULL; 
	m_poolNewsSubscription =  NULL; 
	m_poolNewsStream =  NULL; 
	m_poolTopGainersLosers =  NULL; 
	m_poolTradeHistoryResponse =  NULL; 
	m_poolParticipantListResponse = NULL;
	m_poolHeartbeat = NULL;
}

void *MemoryManager::GetMessageObject(char msgType)
{
	void* pMessage = NULL;
	size_t MsgLenInBytes = 0;

	switch(msgType)
	{
	case LOGON_REQUEST:
		  MsgLenInBytes = sizeof(LogonRequest);
		  pMessage = m_poolLogonRequest->NewInstance();
		  break;            
	case LOGON_RESPONSE:
		  MsgLenInBytes = sizeof(LogonResponse);
		  pMessage = m_poolLogonResponse->NewInstance();
		  break;
	case LOGOUT_REQUEST:
		  MsgLenInBytes = sizeof(LogoutRequest);
		  pMessage = m_poolLogoutRequest->NewInstance();
		  break;
	case NEW_ORDER_REQUEST:
		  MsgLenInBytes = sizeof(NewOrderRequest);
		  pMessage = m_poolNewOrderRequest->NewInstance();
		  break;
	case ORDER_CANCEL_REQUEST:
		  MsgLenInBytes = (sizeof(OrderCancelRequest));
		  pMessage = m_poolOrderCancelRequest->NewInstance();
		  break;
	case ORDER_REPLACE_REQUEST:
		  MsgLenInBytes = (sizeof(OrderReplaceRequest));
		  pMessage = m_poolOrderReplaceRequest->NewInstance();
		  break;
	case ORDER_STATUS_REQUEST:
		  MsgLenInBytes = (sizeof(OrderStatusRequest));
		  pMessage = m_poolOrderStatusRequest->NewInstance();
		  break;
	case ACCOUNT_REQUEST:
		  MsgLenInBytes = (sizeof(AccountRequest));
		  pMessage = m_poolAccountRequest->NewInstance();
		  break;
	case POSITION_REQUEST:
		  MsgLenInBytes = (sizeof(PositionRequest));
		  pMessage = m_poolPositionRequest->NewInstance();
		  break;
	case ORDER_HISTORY_REQUEST:
		  MsgLenInBytes = (sizeof(OrderHistoryRequest));
		  pMessage = m_poolOrderHistoryRequest->NewInstance();
		  break;
	case PARTICIPANT_LIST_REQUEST:
		  MsgLenInBytes = (sizeof(ParticipantListRequest));
		  pMessage = m_poolParticipantListRequest->NewInstance();
		  break;
	case ORDER_STATUS_RESPONSE:
		  MsgLenInBytes = (sizeof(OrderStatusResponse));
		  pMessage = m_poolOrderStatusResponse->NewInstance();
		  break;
	case REJECT_MESSAGE_RESPONSE:
		  MsgLenInBytes = (sizeof(RejectMessageResponse));
		  pMessage = m_poolRejectMessageResponse->NewInstance();
		  break;
	case ORDER_CANCEL_REJECT_RESPONSE:
		  MsgLenInBytes = (sizeof(OrderCancelRejectResponse));
		  pMessage = m_poolOrderCancelRejectResponse->NewInstance();
		  break;
	case PARTICIPANT_LIST_RESPONSE:
		  MsgLenInBytes = (sizeof(ParticipantListResponse));
		  pMessage = m_poolParticipantListResponse->NewInstance();
		  break;
	case POSITION_RESPONSE:
		  MsgLenInBytes = (sizeof(PositionResponse));
		  pMessage = m_poolPositionResponse->NewInstance();
		  break;
	case ORDER_HISTORY_RESPONSE:
		  MsgLenInBytes = (sizeof(OrderHistoryResponse));
		  pMessage = m_poolOrderHistoryResponse->NewInstance();
		  break;
	case BUSINESS_LEVEL_REJECT:
		  MsgLenInBytes = (sizeof(BusinessLevelReject));
		  pMessage = m_poolBusinessLevelReject->NewInstance();
		  break;
	case QUOTE_SUBSCRIPTION_REQUEST:
		  MsgLenInBytes = (sizeof(QuoteSubscriptionRequest));
		  pMessage = m_poolQuoteSubscriptionRequest->NewInstance();
		  break;
	case QUOTES_UNSUBSCRIPTION_REQUEST:
		  MsgLenInBytes = (sizeof(QuoteUnsubscriptionRequest));
		  pMessage = m_poolQuoteUnsubscriptionRequest->NewInstance();
		  break;
	case QUOTE_SNAP_SHOT_RESPONSE:
		  MsgLenInBytes = (sizeof(QuotesSnapshotResponse));
		  pMessage = m_poolQuotesSnapshotResponse->NewInstance();
		  break;
	case QUOTES_STREAM:     
		  MsgLenInBytes = (sizeof(QuotesStream));
		  pMessage = m_poolQuotesStream->NewInstance();
		  break;
	case NEWS_SUBSCRIPTION:
		  MsgLenInBytes = (sizeof(NewsSubscription));
		  pMessage = m_poolNewsSubscription->NewInstance();
		  break;
	case NEWS_STREAM:
		  MsgLenInBytes = (sizeof(NewsStream));
		  pMessage = m_poolNewsStream->NewInstance();
		  break;
	case TOP_GAINERS_LOSERS:
		  MsgLenInBytes = (sizeof(TopGainersLosers));
		  pMessage = m_poolTopGainersLosers->NewInstance();
		  break;
	case QUOTE__REQUEST:
	case QUOTE__SNAPSHOT_REQUEST:
	case QUOTE__DOM_REQUEST :
		  MsgLenInBytes = (sizeof(QuoteRequest));
		  pMessage = m_poolQuoteRequest->NewInstance();
		  break;
	case NEWS__REQUEST:
		  MsgLenInBytes = (sizeof(NewsRequest));
		  pMessage = m_poolNewsRequest->NewInstance();
		  break;
	case TRADE_HISTORY_REQUEST:
		  MsgLenInBytes = (sizeof(TradeHistoryRequest));
		  pMessage = m_poolTradeHistoryRequest->NewInstance();
		  break;
	case TRADE_HISTORY_RESPONSE:
		  MsgLenInBytes = (sizeof(TradeHistoryResponse));
		  pMessage = m_poolTradeHistoryResponse->NewInstance();
		  break;
	case HEARTBEAT:
		  MsgLenInBytes = (sizeof(HeartbeatFromClient));
		  pMessage = m_poolHeartbeat->NewInstance();
		  break;
	case BUFFER:
		  MsgLenInBytes = 4096;
		  pMessage = m_poolBuffer->NewInstance();
		  break;
	}

	//if (pMessage)
	{
		memset(pMessage, 0, MsgLenInBytes);

		if (msgType <= HEARTBEAT)
		{
			pstructureHeader header = ( pstructureHeader )pMessage;
			header->StructSize = MsgLenInBytes;

			header->MessageType = msgType;
		}
	}

	return pMessage;
}

void MemoryManager::ReleaseObject(void *pObject, char msgType)
{
	switch(msgType)
	{
	case LOGON_REQUEST:
 		m_poolLogonRequest->FreeInstance((LogonRequest*)pObject);
		break;            
	case LOGON_RESPONSE:
		m_poolLogonResponse->FreeInstance((LogonResponse*)pObject);
		break;
	case LOGOUT_REQUEST:
		m_poolLogoutRequest->FreeInstance((LogoutRequest *)pObject);
		break;
	case NEW_ORDER_REQUEST:
		m_poolNewOrderRequest->FreeInstance((NewOrderRequest *)pObject);
		break;
	case ORDER_CANCEL_REQUEST:
		m_poolOrderCancelRequest->FreeInstance((OrderCancelRequest *)pObject);
		break;
	case ORDER_REPLACE_REQUEST:
		m_poolOrderReplaceRequest->FreeInstance((OrderReplaceRequest *)pObject);
		break;
	case ORDER_STATUS_REQUEST:
		m_poolOrderStatusRequest->FreeInstance((OrderStatusRequest *)pObject);
		break;
	case ACCOUNT_REQUEST:
		m_poolAccountRequest->FreeInstance((AccountRequest *)pObject);
		break;
	case POSITION_REQUEST:
		m_poolPositionRequest->FreeInstance((PositionRequest *)pObject);
		break;
	case ORDER_HISTORY_REQUEST:
		m_poolOrderHistoryRequest->FreeInstance((OrderHistoryRequest *)pObject);
		break;
	case PARTICIPANT_LIST_REQUEST:
		m_poolParticipantListRequest->FreeInstance((ParticipantListRequest *)pObject);
		break;
	case ORDER_STATUS_RESPONSE:
		m_poolOrderStatusResponse->FreeInstance((OrderStatusResponse *)pObject);
		break;
	case REJECT_MESSAGE_RESPONSE:
		m_poolRejectMessageResponse->FreeInstance((RejectMessageResponse *)pObject);
		break;
	case ORDER_CANCEL_REJECT_RESPONSE:
		m_poolOrderCancelRejectResponse->FreeInstance((OrderCancelRejectResponse *)pObject );
		break;
	case PARTICIPANT_LIST_RESPONSE:
		m_poolParticipantListResponse->FreeInstance((ParticipantListResponse *)pObject);
		break;
	case POSITION_RESPONSE:
		m_poolPositionResponse->FreeInstance((PositionResponse*)pObject);
		break;
	case ORDER_HISTORY_RESPONSE:
		m_poolOrderHistoryResponse->FreeInstance((OrderHistoryResponse *)pObject);
		break;
	case BUSINESS_LEVEL_REJECT:
		m_poolBusinessLevelReject->FreeInstance((BusinessLevelReject *)pObject);
		break;
	case QUOTE_SUBSCRIPTION_REQUEST:
		m_poolQuoteSubscriptionRequest->FreeInstance((QuoteSubscriptionRequest *)pObject);
		break;
	case QUOTES_UNSUBSCRIPTION_REQUEST:
		m_poolQuoteUnsubscriptionRequest->FreeInstance((QuoteUnsubscriptionRequest *)pObject);
		break;
	case QUOTE_SNAP_SHOT_RESPONSE:
		m_poolQuotesSnapshotResponse->FreeInstance((QuotesSnapshotResponse *)pObject);
		break;
	case QUOTES_STREAM:     
		m_poolQuotesStream->FreeInstance((QuotesStream *)pObject);
		break;
	case NEWS_SUBSCRIPTION:
		m_poolNewsSubscription->FreeInstance((NewsSubscription *)pObject);
		break;
	case NEWS_STREAM:
		m_poolNewsStream->FreeInstance((NewsStream *)pObject);
		break;
	case TOP_GAINERS_LOSERS:
		m_poolTopGainersLosers->FreeInstance((TopGainersLosers *)pObject);
		break;
	case QUOTE__REQUEST:
	case QUOTE__SNAPSHOT_REQUEST:
	case QUOTE__DOM_REQUEST :
		m_poolQuoteRequest->FreeInstance((QuoteRequest *)pObject);
		break;
	case NEWS__REQUEST:
		m_poolNewsRequest->FreeInstance((NewsRequest *)pObject);
		break;
	case TRADE_HISTORY_REQUEST:
		m_poolTradeHistoryRequest->FreeInstance((TradeHistoryRequest *)pObject);
		break;
	case TRADE_HISTORY_RESPONSE:
		m_poolTradeHistoryResponse->FreeInstance((TradeHistoryResponse *)pObject);
		break;
	case HEARTBEAT:
		m_poolHeartbeat->FreeInstance((HeartbeatFromOMS *)pObject);
		break;
	case BUFFER:
		m_poolBuffer->FreeInstance((CBuffer *)pObject);
		break;
	}
}

void* __stdcall GetObject(char msgType)
{
	void *pMessage = NULL;
	MemoryManager *pManager = MemoryManager::getInstance();

	if (pManager)
	{
		pMessage = pManager->GetMessageObject(msgType);
	}

	return pMessage;
}

void __stdcall ReleaseObject(void *pObject, char msgType)
{
	MemoryManager *pManager = MemoryManager::getInstance();

	if (pManager)
	{
		pManager->ReleaseObject(pObject, msgType);	
	}
}

char* __stdcall GetBuffer(int& size)
{
	char *pMsg = NULL;

	MemoryManager *pManager = MemoryManager::getInstance();

	if (pManager)
	{
		CBuffer *pBuffer = (CBuffer *)pManager->GetMessageObject(BUFFER);

		if (pBuffer)
		{
			pMsg = pBuffer->GetBuffer(size);
		}
	}

	return pMsg;
}

bool __stdcall InitializeMemoryManager()
{
	bool bSuccess = false;

	MemoryManager *pManager = MemoryManager::getInstance();

	if (pManager)
	{
		bSuccess = true;
	}

	return bSuccess;
}

bool __stdcall FreeAll()
{
	bool bSuccess = false;

	MemoryManager *pManager = MemoryManager::getInstance();

	if (pManager)
	{
		delete pManager;
	}

	return bSuccess;
}