///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE                  INITIALS    DESCRIPTION
//13-01-2012      JS                1. Initial Structure Created.
//16-01-2012      BR                Comments-
//                                        1.    Need to break bigger structures in smaller ones.
//                                        2.    The Order status response, fill response, order elimination response all 
//                                              are Execution reports and we should have just one structure.
//                                        3.    We should have an option to send in multiple orders request like New order, cancel order.
//                                              Also, send back multiple execution reports.
//                                        4.    Unsigned long as well as unsigned int are 4 bytes, but the number of bits are different. 
//                                              Need to see how to make this compatible for both 32 bit and 64 bit.
//17-01-2012      BR                Comments-
//                                        1.    The symbol structure c an replace all places where the symbol is 
//                                              used like in new order replace order etc.
//                                        2.    Rename CommonOrderResponse to ExecutionReport
//                                        3.    NoOfRepeatingGroups not required in QuotesItem
//
//02-02-2012    ASG                 1) Introducing packet id in 'HeaderClientToOMS' structure and modifying data type of 'SeqNo' of 'HeaderOMSToClient'
//                                           from 'unsigned int' to 'unsigned long long'  
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
 
#if !defined _PROTOCOL_DATA_DEFINATION_H
#define _PROTOCOL_DATA_DEFINATION_H
 
#pragma once
 
#include <stdlib.h>
#include <exception>
#include <memory.h>
#include <string>

//#import "ContractServer.tlb" no_namespace, named_guids, raw_native_types, raw_interfaces_only

// BR -- Need to add more rejection reasons here.
#define     REJECTION_CODE_OTHER                                        '0' 
#define     REJECTION_CODE_UNKNOWN_ID                                   '1'
#define     REJECTION_CODE_UNKNOWN_SECURITY                             '2'
#define     REJECTION_CODE_UNSUPPORTED_MESSAGE_TYPE               '3'
#define     REJECTION_CODE_APPLICATION_NOT_AVAILABLE        '4'
#define     REJECTION_CODE_FIELD_MISSING                          '5'
#define     REJECTION_CODE_NOT_AUTHORIZED                         '6'
#define     REJECTION_CODE_NOT_AVAILABLE                          '7'
 
//AccountRequest
#define     SUBSCRIBE                                                         'Y'
#define     UNSUBSCRIBE                                                       'N'
 
//OrderHistoryRequest
#define     FILTER_ALL                                                        '0'
#define     FILTER_LIVE_ORDERS                                                '1'
#define     FILTER_FILLED_ORDERS                                        '2'
#define     FILTER_CANCEL_ORDERS                                        '3'
#define     FILTER_REJECTED_ORDERS                                      '4'
 
//BeginString
const char FIX[4] = {'1','.','0','0'};
 
//Position Request
#define     POSITION_OPENING_TRADE                                      'O'
#define     POSITION_CLOSING_TRADE                                      'C'
 
// Order Status
// Order status definitions as per the protocol specifications
#define     ORDER_STATUS_NEW                                            '0' 
#define     ORDER_STATUS_PARTIALLY_FILLED                         '1'
#define     ORDER_STATUS_FILLED                                               '2'
#define     ORDER_STATUS_CANCEL                                               '4'
#define     ORDER_STATUS_REPLACED                                       '5'
#define     ORDER_STATUS_PENDING_CANCEL                                 '6'
#define     ORDER_STATUS_REJECTED                                       '8'
#define     ORDER_STATUS_PENDINGNEW                                     'A'
#define     ORDER_STATUS_EXPIRED                                        'C'
#define     ORDER_STATUS_PENDINGREPLACE                                 'E'
#define     ORDER_STATUS_UNDEFINED                                      'U'
#define     ORDER_STATUS_ORDER_NOT_FOUND                          'Y'
 
// Execution Type
#define                 EXECUTION_TYPE_NEW                      '0'
#define                 EXECUTION_TYPE_PARTFILLED                       '1'
#define                 EXECUTION_TYPE_FILLED                           '2'
#define                 EXECUTION_TYPE_CANCELACK                        '4'
#define                 EXECUTION_TYPE_MODIFYACK                        '5'
#define                 EXECUTION_TYPE_REJECTACK                        '8'
#define                 EXECUTION_TYPE_ELIMINATIONACK             'C'
#define                 EXECUTION_TYPE_STATUS_REPORT              'I'
 
 
// ExecTransType
#define                 EXECUTION_TRANSTYPE_NEW                 '0'
#define                 EXECUTION_TRANSTYPE_STATUS                      '3'   
 
 
// Order Type
#define     ORDER_TYPE_MARKET_ORDER                                     '1'
#define     ORDER_TYPE_LIMIT_ORDER                                      '2'
#define     ORDER_TYPE_STOP_ORDER                                       '3'
#define     ORDER_TYPE_STOP_LIMIT_ORDER                                 '4'
 
// Side
#define     SIDE_BUY                                                          '1' 
#define     SIDE_SELL                                                         '2'         
 
//Time in Force
#define     TIF_DAY                                                                     '0'
#define     TIF_GOOD_TILL_CANCEL                                            '1'
#define     TIF_FOK                                                                     '3'
#define     TIF_GOOD_TILL_DATE                                                    '6'
 
//Security Type
#define     SECURITY_TYPE_FX                                            '0'
#define     SECURITY_TYPE_FUT                                           '1'
#define     SECURITY_TYPE_OPT                                           '2'
#define     SECURITY_TYPE_EQ                                            '3'
 
//Message Type
#define LOGON_REQUEST                                                   1
#define LOGON_RESPONSE                                                  2
#define LOGOUT_REQUEST                                                  3
#define NEW_ORDER_REQUEST                                               4
#define ORDER_CANCEL_REQUEST											5
#define ORDER_REPLACE_REQUEST											6
#define ORDER_STATUS_REQUEST											7
#define ACCOUNT_REQUEST                                                 8
#define POSITION_REQUEST                                                9
#define ORDER_HISTORY_REQUEST											10
#define PARTICIPANT_LIST_REQUEST										11
#define EXECUTION_REPORT_RESPONSE										12
#define ORDER_STATUS_RESPONSE											13
#define REJECT_MESSAGE_RESPONSE                                         14
#define ORDER_CANCEL_REJECT_RESPONSE									15
#define ACCOUNT_RESPONSE                                                16
#define PARTICIPANT_LIST_RESPONSE										17
#define POSITION_RESPONSE                                               18
#define BUSINESS_LEVEL_REJECT											19
#define QUOTE_SUBSCRIPTION_REQUEST										20
#define QUOTES_UNSUBSCRIPTION_REQUEST									21
#define QUOTE_SNAP_SHOT_RESPONSE										22
#define QUOTES_STREAM                                                   23
#define NEWS_SUBSCRIPTION                                               24
#define NEWS_STREAM                                                     25
#define TOP_GAINERS_LOSERS                                              26
#define ORDER_HISTORY_RESPONSE                                          27
#define QUOTE__REQUEST													28
#define QUOTE__SNAPSHOT_REQUEST											29
#define QUOTE__DOM_REQUEST												30
#define NEWS__REQUEST													31
#define LOGOUT_RESPONSE                                                 32
#define TRADE_HISTORY_REQUEST											33
#define TRADE_HISTORY_RESPONSE                                          34
#define HEARTBEAT														35
#define BUFFER															36 
 
 
// QUOTES_STREAM_TYPE
#define     QUOTES_STREAM_TYPE_ASK                                      'A'
#define     QUOTES_STREAM_TYPE_BID                                      'B'
#define     QUOTES_STREAM_TYPE_LAST                                     'L'
#define     QUOTES_STREAM_TYPE_VOLUME                                   'V'
#define     QUOTES_STREAM_TYPE_VOLUME_PERCENT                     'P'
#define     QUOTES_STREAM_TYPE_LOW                                      'M'
#define     QUOTES_STREAM_TYPE_HIGH                                     'H'
#define     QUOTES_STREAM_TYPE_OPEN                                     'O'
#define     QUOTES_STREAM_TYPE_CLOSE                                     'C'
 
#define MAX_KEY_DATA_CTRL_BLK                                     0xFFFFFFFF
 
#define MAX_ACCOUNT_INFO                                                40
#define MAX_POSITION                                                    10
#define MAX_ORDER_HISTORY                                               5
#define MAX_TRADE_HISTORY                                               5
#define MAX_SYMBOL                                                            10
#define MAX_OHLC                                                        1
#define MAX_MARKET_DEPTH                                                10
#define     MAX_QUOTES_ITEM                                                   20
#define MAX_NEWS                                                        5
#define MAX_TOP_GAINER_LOSERS                                     15
#define MAX_TCP_PACKET_SIZE                                             1400
 
 
#define MAX_CHAR_ARRAY_SIZE                                             150   
enum eCLIENTDLL
{
      AgentConnecting=0,
      AgentConnected,
      AgentDisconnecting,
      AgentDisconnected,
      AgentLoading,
      AgentLoaded,
      AgentBusy,
      AgentIdle,
      AgentHealthGood,
      AgentHealthBad,
      ManagerLoading, 
      ManagerLoaded,
      ManagerBusy,
      ManagerIdle,
      ManagerHealthGood,
      ManagerHealthBad
};
namespace classification
{
 
      struct author
      {
            static const int        iso = 1;
            static const int        ftse = 2;
            static const int        standardpoors = 3;
      };
 
      struct product
      {
            static const char       unknown = '4';
            static const char       equity = '3';
            static const char       futures = '1';
            static const char       options = '2';
            static const char       forex = '0';
            static const char       bond = '5';
      };
 
      struct industry
      {
            static const int        oilgas = 30;
            static const int        basicmaterials = 31;
            static const int        industrials = 32;
            static const int        consumergoods = 33;
            static const int        healthcare = 34;
            static const int        consumerservices = 35;
            static const int        telecommunications = 36;
            static const int        utilities = 37;
            static const int        financials = 38;
            static const int        technology = 39;
 
            static const int        commodity = 50;
            static const int        financialfutures = 51;
      };
 
      struct sector
      {
            static const int        metals = 61;
            static const int        energy = 62;
            static const int        grains = 63;
            static const int        livestock = 64;
            static const int        food = 65;
 
            static const int        credit = 70;
            static const int        stock = 71;
            static const int        forex = 72;
      };
};
 
#pragma pack(push)
#pragma pack(1) 
 
//typedef struct HeaderClientToOMS
//{
//    unsigned int                  StructSize;
//    char                          BeginString[4];                     //1.0 String (4)      Specifies the version of the protocol
//    unsigned int                  MessageType;      
//    double                              SendingTime;                        //Time in UTC in double. Number of seconds elapsed since Jan 1, 1970
//    unsigned long long      SeqNo;
//    unsigned int                  KeyDataCtrlBlk;                     //Page Number required for multiple request/response
//}headerClientToOMS, * pHeaderClientToOMS;
 
typedef struct StructureHeader
{
      unsigned int                  StructSize;
      char                          BeginString[4];                     //1.0 String (4)      Specifies the version of the protocol
      char                          SenderID[5];
      char                          TargetID[5];
      unsigned int                  MessageType;      
      double                              SendingTime;                        //Time in UTC in double. Number of seconds elapsed since Jan 1, 1970
      unsigned long long            SeqNo;                                    // BR-- This is reserved for later use.             
      unsigned int                  KeyDataCtrlBlk;                     //Page Number required for multiple request/response
} structureHeader, *pstructureHeader;
 
typedef struct LogonRequest 
{
      structureHeader               Header;
      char                          EncryptionMethod;             // BR-- This is part of the handshaking.
      char                          UserName[8];                        
      char                          Password[15];                       //Password for the account     TRDBO.Account. MasterPassword
      unsigned int                  HeartbeatInterval;                  //Interval for sending heartbeat 
} logonRequest, *pLogonRequest;
 
typedef struct LogonResponse
{
      structureHeader         Header;
      char                    EncryptionMethod;             // BR-- This is part of the handshaking. The response specifies the encryption method that
      char                    Reason[50];
      // server is ready to use.
      unsigned int            HeartbeatInterval;                  //Interval for sending heartbeat
} logonResponse,*pLogonResponse;
 
typedef struct LogoutResponse
{
      structureHeader         Header;
} logoutResponse,*pLogoutResponse;
 
typedef struct SessionLevelReject 
{
      structureHeader         Header;
      char                    Text[150];                          //Reason for rejection
}sessionLevelReject,*pSessionLevelReject;
 
typedef struct LogoutRequest
{
      structureHeader         Header;
      char                    ReasonForLogout[150];         //Reason for logout
}logoutRequest,*pLogoutRequest;
 
typedef struct HeartbeatFromOMS
{
      structureHeader         Header;
}heartbeatFromOMS,*pHeartbeatFromOMS;
 
typedef struct HeartbeatFromClient
{
      structureHeader         Header;
}heartbeatFromClient,*pHeartbeatFromClient;
 
typedef struct BusinessLevelReject
{
      structureHeader         Header;
      unsigned int            RefMsgType;                         //Tag 35 of the rejected message
      char                    BusinessRejectRefID[32];      //Order ID and/or Quote ID
      int	                  BusinessRejectReason;         //Code identifying reject reason
      char                    Text[80];                           //Additional info on reject reason
}businessLevelReject,*pBusinessLevelReject;
 
typedef struct Symbol
{
      char  ProductType;
      char  Product[20];
      char  Contract[20]; 
      char  Exchange[20];
      char  Provider[20];
      int         author;
      int         industry;
      int         sector;
}symbol,*pSymbol;
 
struct Order
{
      unsigned long           Account;                      //Unique Account identifier   
      unsigned long long            OrderQty;                           //Order quantity. Must be a positive integer. 
      char                          ClOrdId[20];                        //Unique order identifier assigned by client system. Client system must maintain uniqueness of this value for the life of the order.    OMS.ParticipantOrderRequest.UI_ID
      symbol                        Symbol;
      //New Orders submitted with quantity greater than the Max Quantity and less than 99999 will be rejected with 35=8. 
      //New Orders submitted with quantity greater than 99999 will be rejected with 35=3. 
      //Maximum Quantity is defined in the market data Security Definition (MsgType-tag 35-d) message in tag 1140-MaxThreshold.   TRDBO.instrument.Maximum Lots
      char                          OrderType;                          //The state of an order type can change over the life of the order. For example, a submitted stop order (3) can turn into a market order (1) when the stop price level has been crossed. TRDBO.instrument.OrderTypeID
      unsigned long long            Price;                                    //Required for limit and Stop-limit orders. Designates the price per unit contract.    
      char                          Side;                               //1=Buy 2=Sell          Side of the order 
      char                          TimeInForce;                        //0=Day 1=Good till Cancel (GTC)3=FOK 6=Good Till Date (FTD) For GTD, expire date is also required.For FAK and FOK (tag 59=3), tag 110-MinQty is also required. 
      unsigned long long            StopPx;                                   //Required for stop and stop-limit orders. Designates stop trigger price specified by the individual entering the order or cancel/replace.     
      double                              ExpireDate;//char                         ExpireDate[21];                     //Required only if TimeInForce (Tag 59) = Good Till Date (GTD). We do not support ExpireTime (Tag 126). Only the expiration date can be set. Orders expire at the end of the trading session of the specified date. 
 
 
      double                              TransactTime;//char                             TransactTime[21];             //Timestamp of the business event of submitting the order (e.g. click of the submission button) 
      unsigned long long            MinOrDisclosedQty;                  //Minimum quantity of an order to be executed. Used with and required for FAK and FOK order types with tag 59-TimeInForce=3. 
      //This is also used as disclosed qty. The value of MinQty must be between 1 and the value in tag 38-OrderQty. 
      //This is also used in case of other TIFs, as a disclosed quantity.     
      char                          PositionEffect;                     //O = Position opening trade C = Position closing Trade  . Only for options and where we provide hedging 
	  unsigned long long			OrderID;
	  char                          origClOrdId[20];
};
/////////Request From Client
typedef struct NewOrderRequest
{
      structureHeader         Header;
      Order                   order;
}newOrderRequest,*pNewOrderRequest;
 
typedef struct OrderCancelRequest
{
      structureHeader         Header;
	  Order					  order;
}orderCancelRequest,*pOrderCancelRequest;
 
typedef struct OrderReplaceRequest 
{
      structureHeader         Header;
	  Order					  OldOrder;
	  Order					  NewOrder;
}orderReplaceRequest,*pOrderReplaceRequest;
 
typedef struct OrderStatusRequest
{
      structureHeader         Header;
      unsigned long           Account;
      char                    ClOrdId[20];
      unsigned long long      OrderId;                            //Unique ID assigned by CME Globex to identify orders. Unique per instrument per trading session. 
      double                        TransactTime;//char                             TransactTime[21];             //UTC format HH:MM:SS.sss e.g. 10:00:29.714 
      symbol                        Symbol;
}orderStatusRequest,*pOrderStatusRequest;
 
typedef struct AccountRequest
{
      structureHeader         Header;
      unsigned long           Account;
      char                    Subscribe;                          //Y/N By default it is Y. The yes means, the account is subscribed and any change the account information will be pushed to client
}accountRequest,*pAccountRequest;
 
typedef struct PositionRequest
{
      structureHeader         Header;
      unsigned long           Account;
      char                    Subscribe;                          
}positionRequest,*pPositionRequest;
 
typedef struct OrderHistoryRequest
{
      structureHeader         Header;
      unsigned long           Account;
      char                    Filter;
}orderHistoryRequest,*pOrderHistoryRequest;
 
typedef struct TradeHistoryRequest
{
      structureHeader         Header;
      unsigned long           Account;
      char                    Filter;
}tradeHistoryRequest,*pTradeHistoryRequest;
 
typedef struct ParticipantListRequest
{
      structureHeader         Header;
      char                    UserName[8];
}participantListRequest,*pParticipantListRequest;
 
///Reponse From OMS
// bhaskar Roy. DO NOT CHANGE THE SEQUENCE OF THE FIELDS.
typedef struct ExecutionReport
{
      unsigned long           Account;                      //Unique Account identifier   
      unsigned long long            OrdQty;                           //Order quantity. Must be a positive integer. 
      char                          ClOrdId[20];                        //Unique order identifier assigned by client system. Client system must maintain uniqueness of this value for the life of the order.    OMS.ParticipantOrderRequest.UI_ID
      symbol                        Symbol;
      char                          OrderType;                          //The state of an order type can change over the life of the order. For example, a submitted stop order (3) can turn into a market order (1) when the stop price level has been crossed. 
      unsigned long long            Price;                                    //Required for limit or stop-limit orders. Designates the price per single contract unit. The decimal, and if applicable the negative sign of the price, are each one character. Client systems should not supply more than 7 characters to the right of the decimal. 
      char                          Side;                               //Side of Order
      char                          TimeInForce;                        //Specifies how long the order remains in effect. If not present, DAY order is the default. For GTD, ExpireDate is also required. For FAK, MinQty is also required. 
      unsigned long long            StopPx;                                   //Designates stop trigger price specified by the individual entering the order or cancel/replace. 
      double                              ExpireDate;//char                         ExpireDate[8];                      //Required only if TimeInForce (Tag 59) = Good Till Date (GTD).Exchange does not support ExpireTime (Tag 126). Only the expiration date can be set. Orders expire at the end of the trading session of the specified date. 
      char                          OrderInfoEnd;                       // MArks the end of the Order information. This is something that remains same for the order thru out the life of order
 
      double                              TransactTime;//char                             TransactTime[21];             //UTC format HH:MM:SS.sss ,e.g. 10:00:29.714 
      unsigned long long            OrderID;                            //Exchange assigned order identifier; unique per instrument per trading session. 
      char                          OrigClOrdID[20];
      char                          ExecTransType;                      //0=new,Identifies transaction type as new(i.e. new order, order cancel, or cancel/replace accepted) 
      char                          ExecID[40];                         //Exchange assigned execution report message identifier; unique per instrument per trading session. 
      //An execution report message sent by Exch can be identified by the unique value of tag 56-TargetCompID+tag 107-SecurityDesc+tag17-ExecID. 
      unsigned long long            AvgPx;
      unsigned long long            CumQty;                                   //Contains cumulated traded quantity throughout lifespan of an order. This value resets to zero if order is cancel/replaced.
      char                          OrderStatus;                        //Identifies order status as accepted, cancelled, or replaced. 
      char                          Text[50];                           //Free form text
      char                          ExecType;                           //Indicates type of execution report. 
      unsigned long long            LeavesQty;                          //Amount of contract units open for further execution. The format of this field is different from FIX protocol specifications. This field must be an integer. 
	  unsigned long long			QtyFilled;
	  unsigned long long			LastPx;
 
}executionReport,*pExecutionReport;
 
//typedef struct OrderAckResponse 
//{
//    structureHeader         Header;
//    executionReport         ExecutionReport;
//    char                    OrigClOrdID[20];              //The last accepted ClOrdID in an order chain.If a value is included in tag 41-OrigCIOrdID, the same value is returned; however, if no value is sent, a value of “0” is returned in the Execution Report tag 35-MsgType=8 Cancellation Message, else tag 41-OrigCIOrdID is not sent. 
//
//}orderAckResponse,*pOrderAckResponse;
 
//OrderStatusResponse also used for FillNoticeResponse and OrderEliminationResponse
typedef struct OrderStatusResponse 
{
      structureHeader               Header;
      executionReport               ExecutionReport;
}orderStatusResponse,*pOrderStatusResponse;
 
typedef struct RejectMessageResponse
{
      structureHeader               Header;
      executionReport               ExecutionReport;
      unsigned long long            OrderRejectReason;                  //Designates order reject reason
}rejectMessageResponse,*pRejectMessageResponse;
 
typedef struct OrderCancelRejectResponse 
{
      structureHeader               Header;
      executionReport               ExecutionReport;
      unsigned long long            OrderRejectReason;
}orderCancelRejectResponse,*pOrderCancelRejectResponse;
 
 
typedef struct AccountInfo
{
      unsigned long             Account;                      //Unique Account identifier      
      double                              Balance;
      int                                 Leverage;
      int                                 Group;
      double                              FreeMargin;
      double                              Margin;
      double                              UsedMargin;
      bool                          HedgeAllowed;
      bool                          Active;
      double                              ReservedMargin;
      double                              BuySideTurnOver;
      double                              SellSideturnOver;
}accountInfo,*pAccountInfo;
 
typedef struct AccountResponse
{
      structureHeader         Header;
      unsigned int            NoOfAccounts;
      accountInfo             AccountInfo[MAX_ACCOUNT_INFO];
}accountResponse,*pAccountResponse;
 
typedef struct ParticipantListResponse
{
      structureHeader         Header;
      unsigned int            NoOfParticipants;
      accountInfo             AccountInfo[MAX_ACCOUNT_INFO];
}participantListResponse,*pParticipantListResponse;
 
 
typedef struct Position
{
      unsigned long             Account;
      symbol                    Symbol;
      unsigned long             BuyQty;                                   //Buy Quantity
      unsigned long             BuyVal;                                   //Actual price of all the quantity
      double		            BuyAvg;                                   //Average price of the quantity
      unsigned long             SellQty;								//Number of Sell quantity
      unsigned long             SellVal;                            //Actual price of all the quantity
      double		            SellAvg;                            //Average price of the quantity
      int                       NetQty;                                   //Buy Qty – Sell Qty.
      double		            NetVal;                                   //Sell Val. – Buy Val
      double                    NetPrice;                     
}position,*pPosition;
 
typedef struct PositionResponse 
{
      structureHeader         Header;
      unsigned int            NoOfPosition;
      position                Position[MAX_POSITION];
}positionResponse,*pPositionResponse;
 
 
typedef struct OrderHistory
{
      unsigned long           Account;
      char                          ClOrdId[20];                        //Unique order identifier assigned by client system. Client system must maintain uniqueness of this value for the life of the order
      unsigned long long            OrderID;                            //Exchange assigned order identifier; unique per instrument per trading session. 
      unsigned long long            AvgPx;
      unsigned long long            CumQty;                                   //Contains cumulated traded quantity throughout lifespan of an order. This value resets to zero if order is cancel/replaced.
      unsigned long long            OrdQty;                                   //Order quantity submitted by client. 
      char                          OrderStatus;
      char                          OrigClOrdId[20];              //Last accepted ClOrdID in the order chain. If a value is included in tag 41 on order entry, the same value is returned. If not, the tag will contain „0?. 
      char                          OrderType;                          //The state of an order type can change over the life of the order. For example, a submitted stop order (3) can turn into a market order (1) when the stop price level has been crossed. 
      char                          Text[50];                           //Free form text
      unsigned long long            Price;                                    //Required for limit or stop-limit orders. Designates the price per single contract unit. The decimal, and if applicable the negative sign of the price, are each one character. Client systems should not supply more than 7 characters to the right of the decimal. 
      char                          Side;
      symbol                              Symbol;
      char                          TimeInForce;
      double                              TransactTime;//char                             TransactTime[21];
      double                              TradeDate;// char                         TradeDate[8];
      unsigned long long            StopPx;                                   //Designates stop trigger price specified by the individual entering the order or cancel/replace. 
      unsigned long long            LeavesQty;                          //Amount of contract units open for further execution.The format of this field is different from FIX protocol specifications. This field must be an integer. 
      double                              ExpireDate;//char                         ExpireDate[8];                      //Required only if TimeInForce (Tag 59) = Good Till Date (GTD). Exchange does not support ExpireTime (Tag 126). Only the expiration date can be set. Orders expire at the end of the trading session of the specified date. 
}orderHistory,pOrderHistory;
 
typedef struct OrderHistoryResponse 
{
      structureHeader         Header;
      unsigned int            NoOfOrders;                         //Specifies number of orders. The following fields are repeated
      orderHistory            OrderHistory[MAX_ORDER_HISTORY];
}orderHistoryResponse,*pOrderHistoryResponse;
 
typedef struct TradeHistoryResponse 
{
      structureHeader         Header;
      unsigned int            NoOfOrders;                         //Specifies number of orders. The following fields are repeated
      executionReport         TradeHistory[MAX_ORDER_HISTORY];
}tradeHistoryResponse,*pTradeHistoryResponse;
 
//Market Engine
 
typedef struct QuoteSubscriptionRequest
{
      structureHeader         Header;
      unsigned int            NoOfSymbols;
      symbol                        Symbol[MAX_SYMBOL];
}quoteSubscriptionRequest,*pQuoteSubscriptionRequest;
 
/*
isForSubscribe :
                              1 = Subscribe
                              0 = UnSubscribe
                           -1 = One time Request [ For Latest Data ]
*/
typedef struct QuoteRequest
{
      structureHeader         Header;
      unsigned int            NoOfSymbols;
      int					  isForSubscribe;
      symbol                  Symbol[MAX_SYMBOL];
}quoteRequest,*pQuoteRequest;
 
 
typedef struct MarketDepth
{
      unsigned int                  Level;
      unsigned int                  BidPrice;                     
      unsigned int                  AskPrice;                     
      unsigned int                  BidSize;                      
      unsigned int                  AskSize;                      
      double                              BidTime;//char                            BidTime[21];                        
      double                              AskTime;//char                            AskTime[21];
      char                          Exchange[20];
 
}marketDepth,*pMarketDepth;
 
typedef struct OHLC
{
      symbol                              Symbol;
      unsigned int                  Open; 
      unsigned int                  High;                   
      unsigned int                  Low;                    
      unsigned int                  Close;                        
      unsigned int                  LastPrice;                    
      unsigned int                  LastSize;                     
      double                              LastTime;//char                           LastTime[21];                       
      unsigned int                  MarketDepthLevel;
      marketDepth                   MarketDepth[MAX_MARKET_DEPTH];
      unsigned int                  Volume;                       
      char                          VolumePercent;                      
      unsigned int                  WeeksHigh52;                        
      unsigned int                  WeeksLow52;             
      double                              LastUpdatedTime;//char                          LastUpdatedTime[21];
}oHLC,*pOHLC;
 
typedef struct QuotesSnapshotResponse
{
      structureHeader               Header;
      unsigned int                  NoOfSymbols;                        //The snapshot response can send response for multiple symbols at a time
      oHLC                          OHLC[MAX_OHLC];
}quotesSnapshotResponse,*pQuotesSnapshotResponse;
 
typedef struct QuotesItem
{
      symbol                              Symbol;
      char                          QuotesStreamType;       
      unsigned long long            Price;
      unsigned long long            Size;
      double                              Time;//char                         Time[21];
      unsigned int                  MarketLevel;
      //char                              Exchange[8]; //Note needed here becoz it is in symbol struct
}quotesItem,*pQuotesItem;
 
typedef struct QuotesStream
{
      structureHeader               Header;
      unsigned int                  NoOfSymbols;                        //The snapshot response can send response for multiple symbols at a time
      quotesItem                    QuotesItem[MAX_QUOTES_ITEM];
}quotesStream,*pQuotesStream;
 
typedef struct QuoteUnsubscriptionRequest
{
      structureHeader               Header;
      unsigned int                  NoOfSymbols;
      symbol                              Symbol[MAX_SYMBOL];
}quoteUnsubscriptionRequest,*pQuoteUnsubscriptionRequest;
 
typedef struct NewsSubscription
{
      structureHeader               Header;
      unsigned long           Account;
}newsSubscription,*pNewsSubscription;
 
typedef struct NewsRequest
{
      structureHeader               Header;
      bool                    isForSubscribe;                     
      unsigned long           Account;    
}newsRequest,*pnewsRequest;
 
typedef struct NewsItem
{
      char                          NewsTopic[10];                      
      char                          URL[50];                      
      char                          BodyText[50];                       
      double                              Timestamp;//char                          Timestamp[21];
}newsItem,*pNewsItem;
 
typedef struct NewsStream
{
      structureHeader               Header;
      unsigned int                  NoOfNews;
      newsItem                      NewsItem[MAX_NEWS];
}newsStream,*pNewsStream;
 
//Mails
//{
//    Subject                       
//    From                    
//    To                      
//    Timestamp                     
//    Body                    
//}
 
typedef struct TopGainersLosersItem
{
      symbol                              Symbol;
      unsigned long long            Volume;                       
      unsigned long long            Value;                        
      unsigned long long            LTP;                    
      unsigned long long            Rank;                   
}topGainersLosersItem,*pTopGainersLosersItem;
 
typedef struct TopGainersLosers
{
      structureHeader               Header;
      unsigned int                  NoOfSymbols;                              //The snapshot response can send response for multiple symbols at a time
      topGainersLosersItem    TopGainersLosersItem[MAX_TOP_GAINER_LOSERS];
}topGainersLosers,*pTopGainersLosers;
 
 
typedef struct HistoricalData
{
      double Open;
      double High;
      double Low;
      double Close;
      double OHLCTime;
      unsigned int Volume;
}historicalData,*pHistoricalData;
 
typedef struct InstrumentSpecs
{
      char ProductType[10];
      char Product[20];
      char Contract[20]; 
      char Exchange[20];
      char Provider[20];
      char FutureUse[100];
 
      char Information[25]; // GOLD.995 EX-AHMEDABAD
      char UL_Asset[20]; //GOLD
      double ExpiryDate;//char ExpiryDate[21];
      char TradingCurrency[10];
      char SettlingCurrency[10];
      char DeliveryUnit[10];
      char DeliveryQuantity[10];
      unsigned int MarketLot;
      unsigned int PriceTick;
      unsigned int PriceNumerator;
      unsigned int PriceDenominator;
      unsigned int GeneralNumerator;
      unsigned int GeneralDenominator;
      unsigned int PriceQuantity;
      unsigned int InitialBuyMargin;
      unsigned int InitialSellMargin;
      unsigned int OtherBuyMargin;
      unsigned int OtherSellMargin;
      unsigned int MaxOrderSize;// (In Lots)
      unsigned int MaxOrderValue;
      unsigned int MinDPR;
      unsigned int MaxDPR;
      char Specification[40];
      unsigned int Digits;
      unsigned int MarginCurrency;
      unsigned int MaximumLotsForIE;
      unsigned int Orders;
      unsigned int SpreadByDefault;
      unsigned int BuySideTurnover;
      unsigned int SellSideTurnover;
      unsigned int MaximumAllowablePosition;
      unsigned int QuotationBaseValue;
      char DeliveryType[15];
      double  StartDate;
      double EndDate;
      double TenderStartDate;
      double TenderEndDate;
      double DeliveryStartDate;
      double DeliveryEndDate;
      unsigned int Charges;
      float DPRInitialPercentage;
      unsigned int DPRIntervalSecs;
      unsigned int Limit_Stop_Level; 
      unsigned int SpreadBalance; 
      unsigned int FreezeLevel; 
      unsigned int ContractSize;
      unsigned int Hedged;
      unsigned int TickSize;
      char Percentage[11];
      unsigned int MarginCall1;
      unsigned int MarginCall2;
      unsigned int MarginCall3;
      unsigned int LongPositions;
      unsigned int ShortPositions;
}instrumentSpecs,*pInstrumentSpecs;
 
typedef struct InstrumentHeader
{
 
}instrumentHeader,*pinstrumentHeader;
 
#pragma pack(pop)
 
//*******************************************************************            
//  FUNCTION:   -GetMessageObject()
//              
//  RETURNS:    -void*
//              
//  PARAMETERS: -unsigned int
//              
//  REMARKS:    -
//
//  NOTE:       -                           
//*******************************************************************
static void* GetMessageObject(unsigned int msgType)
{
      void* mallocMsg = NULL;
      size_t MsgLenInBytes = 0;
      switch(msgType)
            {
            case LOGON_REQUEST:
                  MsgLenInBytes = sizeof(LogonRequest);
                  break;            
 
            case LOGON_RESPONSE:
                  MsgLenInBytes = sizeof(LogonResponse);
                  break;
 
            case LOGOUT_REQUEST:
                  MsgLenInBytes = sizeof(LogoutRequest);
                  break;
 
            case NEW_ORDER_REQUEST:
                  MsgLenInBytes = sizeof(NewOrderRequest);
                  break;
 
            case ORDER_CANCEL_REQUEST:
                  MsgLenInBytes = (sizeof(OrderCancelRequest));
                  break;
 
            case ORDER_REPLACE_REQUEST:
                  MsgLenInBytes = (sizeof(OrderReplaceRequest));
                  break;
 
            case ORDER_STATUS_REQUEST:
                  MsgLenInBytes = (sizeof(OrderStatusRequest));
                  break;
 
            case ACCOUNT_REQUEST:
                  MsgLenInBytes = (sizeof(AccountRequest));
                  break;
 
            case POSITION_REQUEST:
                  MsgLenInBytes = (sizeof(PositionRequest));
                  break;
 
            case ORDER_HISTORY_REQUEST:
                  MsgLenInBytes = (sizeof(OrderHistoryRequest));
                  break;

			
            case PARTICIPANT_LIST_REQUEST:
                  MsgLenInBytes = (sizeof(ParticipantListRequest));
                  break;
 
      /*    case ORDER_ACKNOWLEDGMENT_RESPONSE:
                  MsgLenInBytes = (sizeof(OrderAckResponse));
                  break;*/
 
            case ORDER_STATUS_RESPONSE:
                  MsgLenInBytes = (sizeof(OrderStatusResponse));
                  break;
 
            case REJECT_MESSAGE_RESPONSE:
                  MsgLenInBytes = (sizeof(RejectMessageResponse));
                  break;
 
            case ORDER_CANCEL_REJECT_RESPONSE:
                  MsgLenInBytes = (sizeof(OrderCancelRejectResponse));
                  break;
 
           /* case ACCOUNT_RESPONSE:
                  MsgLenInBytes = (sizeof(AccountResponse));
                  break;*/
 
            case PARTICIPANT_LIST_RESPONSE:
                  MsgLenInBytes = (sizeof(ParticipantListResponse));
                  break;
 
            case POSITION_RESPONSE:
                  MsgLenInBytes = (sizeof(PositionResponse));
                  break;
 
            case ORDER_HISTORY_RESPONSE:
                  MsgLenInBytes = (sizeof(OrderHistoryResponse));
                  break;
 
 
            case BUSINESS_LEVEL_REJECT:
                  MsgLenInBytes = (sizeof(BusinessLevelReject));
                  break;
 
            case QUOTE_SUBSCRIPTION_REQUEST:
                  MsgLenInBytes = (sizeof(QuoteSubscriptionRequest));
                  break;
 
            case QUOTES_UNSUBSCRIPTION_REQUEST:
                  MsgLenInBytes = (sizeof(QuoteUnsubscriptionRequest));
                  break;
 
            case QUOTE_SNAP_SHOT_RESPONSE:
                  MsgLenInBytes = (sizeof(QuotesSnapshotResponse));
                  break;
 
            case QUOTES_STREAM:     
                  MsgLenInBytes = (sizeof(QuotesStream));
                  break;
 
            case NEWS_SUBSCRIPTION:
                  MsgLenInBytes = (sizeof(NewsSubscription));
                  break;
 
            case NEWS_STREAM:
                  MsgLenInBytes = (sizeof(NewsStream));
                  break;
 
            case TOP_GAINERS_LOSERS:
                  MsgLenInBytes = (sizeof(TopGainersLosers));
                  break;
            case QUOTE__REQUEST:
            case QUOTE__SNAPSHOT_REQUEST:
            case QUOTE__DOM_REQUEST :
                  MsgLenInBytes = (sizeof(QuoteRequest));
                  break;
            case NEWS__REQUEST:
                  MsgLenInBytes = (sizeof(NewsRequest));
                  break;

			case TRADE_HISTORY_REQUEST:
				MsgLenInBytes = (sizeof(TradeHistoryRequest));
                  break;

			case TRADE_HISTORY_RESPONSE:
				MsgLenInBytes = (sizeof(TradeHistoryResponse));
                  break;
				  
			case HEARTBEAT:
				MsgLenInBytes = (sizeof(HeartbeatFromClient));
				break;
            default :
                  return NULL;
      }
 
      if( MsgLenInBytes == 0 )
      {
            throw std::exception("Msg Type Not Found");
            return NULL;
      }
 
      mallocMsg = malloc(MsgLenInBytes);
      if( mallocMsg == NULL )
      {
            throw std::exception("Unable to locate memory");
            return NULL;
      }
 
      pstructureHeader header = ( pstructureHeader )mallocMsg;
      memset( mallocMsg, 0xFF, sizeof( MsgLenInBytes ) );
      
      header->StructSize = MsgLenInBytes;
 
      memset(header->BeginString,0,sizeof(char)*4);
      memcpy(header->BeginString,"1.00",sizeof(char)*4);
 
      memset(header->SenderID,0,sizeof(char)*5);
      memcpy(header->SenderID,"UNKN",sizeof(char)*4);
 
      memset(header->TargetID,0,sizeof(char)*5);
      memcpy(header->TargetID,"UNKN",sizeof(char)*4);
      
 
      header->MessageType = msgType;
      header->SendingTime = 0.0;
      header->SeqNo = 0;
      header->KeyDataCtrlBlk = 0;
      
      return mallocMsg;
}
 
static pSymbol getSymbolStruct()
{
      pSymbol sym = new symbol();
      memset(sym->Product,0,sizeof(char)*sizeof(sym->Product));
      memset(sym->Contract,0,sizeof(char)*sizeof(sym->Contract));
      memset(sym->Exchange,0,sizeof(char)*sizeof(sym->Exchange));
      memset(sym->Provider,0,sizeof(char)*sizeof(sym->Provider));
      sym->author = -1;
      sym->industry = -1;
      sym->sector = -1;
      sym->ProductType =  '4';
 
      return sym;
}
 
static void clearSymbolStruct(pSymbol sym)
{
      memset(sym->Product,0,sizeof(char)*sizeof(sym->Product));
      memset(sym->Contract,0,sizeof(char)*sizeof(sym->Contract));
      memset(sym->Exchange,0,sizeof(char)*sizeof(sym->Exchange));
      memset(sym->Provider,0,sizeof(char)*sizeof(sym->Provider));
      sym->author = -1;
      sym->industry = -1;
      sym->sector = -1;
      sym->ProductType =  '4';
}
 
static void setKeyAttributes(std::string& Provider,std::string& Exchange,std::string& ProductType,std::string& Product,std::string& Contract,std::string& Key)
{
      int firsTokenIndex =  Key.find_first_of('_');
      int secondTokenIndex = Key.find_first_of('_',firsTokenIndex+1);
      int thirdTokenIndex = Key.find_first_of('_',secondTokenIndex+1);
      int fourthTokenIndex = Key.find_first_of('_',thirdTokenIndex+1);
 
      Provider = Key.substr(0,firsTokenIndex);
      Exchange = Key.substr(firsTokenIndex+1,(secondTokenIndex-1) - firsTokenIndex);
      ProductType = Key.substr(secondTokenIndex+1,(thirdTokenIndex-1)-secondTokenIndex);
      Product = Key.substr(thirdTokenIndex+1,(fourthTokenIndex-1)-thirdTokenIndex);
      Contract = Key.substr(fourthTokenIndex+1);
}
 
static pSymbol getSymbolStruct(std::string& Key)
{
      pSymbol sym = getSymbolStruct();
      int firsTokenIndex =  Key.find_first_of('_');
      int secondTokenIndex = Key.find_first_of('_',firsTokenIndex+1);
      int thirdTokenIndex = Key.find_first_of('_',secondTokenIndex+1);
      int fourthTokenIndex = Key.find_first_of('_',thirdTokenIndex+1);
 
      std::string Provider = Key.substr(0,firsTokenIndex);
      std::string Exchange = Key.substr(firsTokenIndex+1,(secondTokenIndex-1) - firsTokenIndex);
      std::string ProductType = Key.substr(secondTokenIndex+1,(thirdTokenIndex-1)-secondTokenIndex);
      std::string Product = Key.substr(thirdTokenIndex+1,(fourthTokenIndex-1)-thirdTokenIndex);
      std::string Contract = Key.substr(fourthTokenIndex+1);
 
      sym->ProductType = ProductType.at(0);
      memcpy(sym->Product,Product.c_str(),sizeof(char)*Product.length());
      memcpy(sym->Contract,Contract.c_str(),sizeof(char)*Contract.length());
      memcpy(sym->Exchange,Exchange.c_str(),sizeof(char)*Exchange.length());
      memcpy(sym->Provider,Provider.c_str(),sizeof(char)*Provider.length());
 
      sym->author = -1;
      sym->industry = -1;
      sym->sector = -1;
 
      return sym;
}
 
static std::string* getSymbolKey(pSymbol PtrSymbol_)
{
      std::string* key = new std::string(PtrSymbol_->Provider);
      key->append("_");
      key->append(PtrSymbol_->Exchange);
      key->append("_");
      key->append(1,PtrSymbol_->ProductType);
      key->append("_");
      key->append(PtrSymbol_->Product);
      key->append("_");
      key->append(PtrSymbol_->Contract);
      return key;
}
 
 
 
 
 
 
#endif //_PROTOCOL_DATA_DEFINATION_H




