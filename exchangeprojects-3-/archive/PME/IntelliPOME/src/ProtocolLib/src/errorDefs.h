﻿///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//29-01-2012	BR			define all error codes here
//30-01-2012	Rohit		Master copy of Error defined
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#define			ERR_OK															0
#define			INVALID_USERID_PWD												-50001	
#define 		ALREADY_LOGGED													-50002	
#define 		USER_NOT_FOUND													-50003	
#define 		FLAGGED_FOR_DELETION											-50004	
#define 		ACCOUNT_LOCKED													-50005	
#define 		ACCOUNT_EXPIRED													-50006	
#define 		MIN_PSWD_LEN													-50007	
#define 		MAX_PSWD_LEN													-50008	
#define 		NO_TIME_ZONE													-50009	
#define 		USER_NOT_LOGGEDIN												-50010	
#define 		INVALID_ORDER_SIZE_LT_EQ_ZERO									-50011	
#define 		INVALID_ORDER_SIZE_LT_MINIMUM_SIZE								-50012	
#define 		INVALID_ORDER_SIZE_NOT_MULTIPLE_OF_LOT_SIZE						-50013	
#define 		INVALID_ORDER_SIZE_GT_MAXIMUM_SIZE								-50014	
#define 		INVALID_ORDER_QUANTITY											-50015	
#define 		INVALID_ORDER_SIZE_GT_MAXIMUM_ORDER_VALUE						-50016	
#define 		MAX_GROSS_CONSIDERATION_REACHED									-50017	
#define 		INVALID_DISPLAY_SIZE_LT_ZERO									-50018	
#define 		INVALID_DISPLAY_QUANTITY_GREATER_THAN_ORDER_QUANTITY			-50019	
#define 		INVALID_DISPLAY_SIZE_NOT_MULTIPLE_OF_LOT_SIZE					-50020	
#define 		INVALID_DISPLAY_QUANTITY										-50021	
#define 		INVALID_LIMIT_PRICE_LT_EQ_ZERO_OR_NO_LIMIT_PRICE				-50022	
#define 		INVALID_LIMIT_PRICE_NOT_MULTIPLE_OF_TICK						-50023	
#define 		INVALID_LIMIT_PRICE_PRICE_BAND_BREACHED							-50024	
#define 		INVALID_LIMIT_PRICE_GT_MAXIMUM_PRICE							-50025	
#define 		INVALID_LIMIT_PRICE_LT_MINIMUM_PRICE							-50026	
#define 		INVALID_ORDER_TYPE_UNKNOWN										-50027	
#define 		INVALID_TIF_UNKNOWN												-50028	
#define 		INVALID_EXPIRE_TIME												-50029	
#define 		INVALID_EXPIRE_TIME_TIME_IS_FOR_A_FUTURE_DATE					-50030	
#define 		INVALID_EXPIRE_DATE_ELAPSED										-50031	
#define 		INVALID_TIF_INVALID_DATE_FORMAT									-50032	
#define 		NO_TIME_QUALIFIER_SPECIFIED										-50033	
#define 		EXPIRED_END_OF_DAY												-50034	
#define 		INVALID_ORDER_TYPE_FOR_USER_MARKET_ORDER						-50035	
#define 		INVALID_SIDE													-50036	
#define 		INVALID_ORDER_STATUS											-50037	
#define 		RECEIVED_PRIOR_TO_FIRST_TRADING_DATE_OF_INSTRUMENT				-50038	
#define 		LAST_TRADING_DATE_OF_INSTRUMENT_ELAPSED							-50039	
#define 		INVALID_ORDER_CAPACITY											-50040	
#define 		INVALID_INSTRUMENT_SET_UP_NO_TICK_STRUCTURE						-50041	
#define 		MONITORING_USER_FROM_SPONSORING_FIRM_NOT_CONNECTED				-50042	
#define 		ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_UNKNOWN_ORDER				-50043	
#define 		UNKNOWN_USER_SUBMITTING_TRADER_ID								-50044	
#define 		UNKNOWN_INSTRUMENT												-50045	
#define 		UNKNOWN_UNDERLYING												-50046	
#define 		UNKNOWN_SEGMENT													-50047	
#define 		UNKNOWN_USER_TARGET_OWNER_ID									-50048	
#define 		UNKNOWN_USER_TARGET_TRADER_ID									-50049	
#define 		NO_ORDERS_FOR_INSTRUMENT_UNDERLYING								-50050	
#define 		INVALID_ORDER_QUANTITY_LESS_THAN_FILLED_QUANTITY				-50051	
#define 		QUERY_EXECUTED_SUCCESSFULLY										-50052	
#define 		INVALID_SIDE_DIFFERENT_FROM_ORIGINAL_ORDER						-50053	
#define 		INVALID_BID_SIZE_GT_MAXIMUM_SIZE								-50054	
#define 		INVALID_OFFER_SIZE_GT_MAXIMUM_SIZE								-50055	
#define 		INVALID_DISPLAYED_BID_SIZE_GT_BID_SIZE							-50056	
#define 		INVALID_DISPLAYED_OFFER_SIZE_GT_OFFER_SIZE						-50057	
#define 		INVALID_BID_PRICE_LT_EQ_ZERO									-50058	
#define 		INVALID_OFFER_PRICE_LT_EQ_ZERO									-50059	
#define 		QUERY_DID_NOT_EXECUTED_SUCCESSFULLY								-50060	
#define 		QUERY_INSERTION_FAIL											-50061	
#define 		UNKNOWN_SECURITYID												-50062	
#define 		INSTRUMENT_HALTED												-50063	
#define 		INSTRUMENT_HALTED_OR_SUSPENDED									-50064	
#define 		INSTRUMENT_HALTED_LAST_TRADING_DAY_REACHED						-50065	
#define 		MARKET_IS_CLOSED												-50066	
#define 		INSTRUMENT_HALTED_MARKET_SUSPENDED								-50067	
#define 		INSTRUMENT_HALTED_INVALID_TRADING_SESSION						-50068	
#define 		SESSION_IS_CLOSED												-50069	
#define 		INSTRUMENT_HALTED_ORDER_BOOK_IN_INVALID_STATE					-50070	
#define 		INSTRUMENT_HALTED_INVALID_SET_UP								-50071	
#define 		INSTRUMENT_HALTED_INVALID_ORDER_BOOK_SET_UP						-50072	
#define 		INVALID_TRADING_SESSION_UNKNOWN									-50073	
#define 		INVALID_NEW_ORDER_MESSAGE										-50074	
#define 		INVALID_CANCEL_ORDER_MESSAGE									-50075	
#define 		INVALID_QTY_GT_MAX_ORDER_QTY									-50076	
#define 		INVALID_DISPLAY_SIZE_GT_ORDER_SIZE								-50077	
#define 		INVALID_ORDER_TYPE_NAMED_ORDERS_ARE_NOT_ALLOWED					-50078	
#define 		INVALID_ORDER_TYPE_STOP_STOP_LIMIT_ORDERS_ARE_NOT_ALLOWED		-50079	
#define 		INVALID_ORDER_TYPE_NOT_ALLOWED_IN_THE_SESSION					-50080	
#define 		INVALID_EXPIRY_DATE_MAXIMUM_ORDER_DURATION_IS_VIOLATED			-50081	
#define 		INVALID_TIF_NOT_ALLOWED_FOR_STOP_STOP_LIMIT_ORDERS				-50082	
#define 		INVALID_SESSION_CANNOT_ENTER_ORDERS_QUOTES						-50083	
#define 		INVALID_SESSION_ORDERS_ARE_NOT_ALLOWED							-50084	
#define 		INVALID_SESSION_CANNOT_CANCEL_AMEND_ORDERS_QUOTES				-50085	
#define 		INVALID_ACCOUNT_TYPE_UNKNOWN									-50086	
#define 		INVALID_BID_SIZE_GT_MAX_QTY										-50087	
#define 		INVALID_OFFER_SIZE_GT_MAX_QTY									-50088	
#define 		INVALID_PRICE_BAND												-50089	
#define 		INVALID_INSTRUMENT_WITH_NO_CLOSING_PRICE_MAINTAINED				-50090	
#define 		INVALID_SETTLEMENT_DATE											-50091	
#define 		TRADE_REPORTING_TIME_OVER										-50092	
#define 		ORDER_VALUE_CANNOT_EXCEED_THE_MAXIMUM_VALUE						-50093	
#define 		FAILED_PRICE_BAND_VALIDATION									-50094	
#define 		ERR_NO_ERROR													-50095	
#define 		ERR_ACCOUNT_DISABLED											-50096	
#define 		ERR_OFF_QUOTES													-50097	
#define 		ERR_CLIENTORDERID_BLANK											-50098	
#define 		ERR_EXPIRE_DATE													-50099	
#define 		ERR_EMPTY_ORDER_QUANTITY										-50100	
#define 		ERR_ORDER_TYPE													-50101	
#define 		ERR_EMPTY_PRICE													-50102	
#define 		ERR_INVALID_SIDE												-50103	
#define 		ERR_INVALID_SYMBOL												-50104	
#define 		ERR_EMPTY_STOP_PRICE											-50105	
#define 		ERR_INVALID_SECURITY_TYPE										-50106	
#define 		ERR_INSUFFICIENT_MARGIN											-50107	
#define 		INVALID_TIF														-50108
#define 		ERR_GTD_BLANK													-50109
#define 		ERR_FTD_EXPIRE_DATE_INVALID										-50110
#define 		ERR_MIN_QTY_NA													-50111
#define 		ERR_INVALID_PRICE_INTERVAL										-50112
#define 		ERR_LIMITPX_INVALID												-50113
#define 		ERR_STOPPX_INVALID												-50114
#define 		ERR_SEC_DESC_EXPIRED											-50115
#define 		ERR_INVALID_TIME												-50116
#define			ERR_EMPTY_BEGIN_STRING											-50117
#define			ERR_INCORRECT_BEGIN_STRING										-50118
#define			ERR_NULL_OBJECT													-50119									
#define			ERR_EMPTY_MESSAGE_TYPE											-50120
#define			ERR_INCORRECT_MESSAGE_TYPE										-50121
#define			ERR_EMPTY_SENDING_TIME											-50122
#define			INVALID_SENDING_TIME_TIME_IS_FOR_A_FUTURE_TIME					-50123
#define			ERR_EMPTY_KEY_DATA_CONTROL_BLOCK								-50124	
#define			ERR_EMPTY_ENCRYPTION_METHOD										-50125
#define			ERR_EMPTY_TRANSACTION_TIME										-50126	
#define			INVALID_TRANSACTION_TIME_TIME_IS_FOR_A_FUTURE_TIME				-50127
#define			ERR_EMPTY_OHLC_LAST_TIME										-50128
#define			ERR_EMPTY_OHLC_LAST_UPDATED_TIME								-50129
#define			ERR_EMPTY_QUOTES_ITEM_TIME										-50130
#define			ERR_EMPTY_NEWS_ITEM_TIME_STAMP									-50131
#define			ERR_EMPTY_USER_NAME												-50132	
#define			ERR_EMPTY_PWD													-50133
#define			ERR_EMPTY_SEQUENCE_NUMBER										-50134	
#define			ERR_EMPTY_HEART_BEAT_INTERVAL									-50135
#define			ERR_EMPTY_REASON_FOR_LOGOUT										-50136
#define			ERR_EMPTY_ACCOUNT_FIELD											-50137
#define			ERR_EMPTY_REF_MSG_TYPE											-50138
#define			ERR_EMPTY_BUSINESS_REJECT_REF_ID								-50139
#define			ERR_EMPTY_BUSINESS_REJECT_REASON								-50140
#define			ERR_EMPTY_ORDER_TYPE											-50141
#define			ERR_EMPTY_SIDE													-50142
#define			ERR_EMPTY_SYMBOL_CODE											-50143
#define			ERR_EMPTY_SECURITY_TYPE											-50144
#define			ERR_EMPTY_TIME_IN_FORCE											-50145
#define			INVALID_TIME_IN_FORCE											-50146
#define			ERR_EMPTY_POSITION_EFFECT										-50147
#define			INVALID_POSITION_EFFECT											-50148
#define			ERR_EMPTY_MINIMUM_DISCLOSE_QTY									-50149
#define			ERR_EMPTY_ORDER_ID												-50150
#define			ERR_EMPTY_ORIG_CL_ORD_ID										-50151
#define			ERR_EMPTY_ORDER_QTY												-50152
#define			ERR_EMPTY_EXPIRE_DATE											-50153
#define			ERR_EMPTY_SUBSCRIBE_FIELD										-50154					
#define			ERR_INVALID_SUBSCRIBE_FIELD										-50155
#define			ERR_EMPTY_FILTER_FIELD											-50156	
#define			ERR_INVALID_FILTER_FIELD										-50157
#define			ERR_EMPTY_AVERAGE_PRICE_FIELD									-50158
#define			ERR_EMPTY_CUMULATIVE_QTY_FIELD									-50159
#define			ERR_EMPTY_EXECUTION_ID_FIELD									-50160
#define			ERR_EMPTY_EXECUTION_TRANS_TYPE_FIELD							-50161
#define			INVALID_EXECUTION_TRANS_TYPE									-50162
#define			ERR_EMPTY_ORDER_STATUS_FIELD									-50163
#define			INVALID_EXECUTION_TYPE											-50164
#define			ERR_EMPTY_LEAVE_QUANTITY_FIELD									-50165
#define			ERR_EMPTY_TRADE_DATE_FIELD										-50166
#define			ERR_EMPTY_LAST_PRICE_FIELD										-50167
#define			ERR_EMPTY_NUMBER_OF_ACCOUNT_FIELD								-50168
#define			ERR_EMPTY_NUMBER_OF_PARTICIPANT_FIELD							-50169
#define			ERR_EMPTY_NUMBER_OF_POSITION_FIELD								-50170
#define			ERR_EMPTY_NUMBER_OF_SYMBOL_FIELD								-50171
#define			ERR_EMPTY_EXECUTION_TYPE_FIELD									-50172
#define			ERR_EMPTY_LAST_QUANTITY_FIELD									-50173
#define			ERR_EMPTY_NUMBER_OF_ORDER_FIELD									-50174
#define			ERR_INTERNAL_ERROR												-50175
#define			ERR_INTERNAL_ERROR_DB											-50176
#define			ERR_TURNOVER_EXCEED												-50177
#define			ERR_QTY_GT_MAX_LOT_ALLOWED										-50178
#define			ERR_MAX_ALLOWABLE_POS_EXCEED									-50180
#define			ERR_INSUFFICIENT_FUNDS											-50181



static char szError[][100] = {		"INVALID_USERID_PWD",											
								"ALREADY_LOGGED",													
								"USER_NOT_FOUND",													
								"FLAGGED_FOR_DELETION",											
								"ACCOUNT_LOCKED",													
								"ACCOUNT_EXPIRED",													
								"MIN_PSWD_LEN",													
								"MAX_PSWD_LEN",													
								"NO_TIME_ZONE",													
								"USER_NOT_LOGGEDIN",												
								"INVALID_ORDER_SIZE_LT_EQ_ZERO",									
								"INVALID_ORDER_SIZE_LT_MINIMUM_SIZE",								
								"INVALID_ORDER_SIZE_NOT_MULTIPLE_OF_LOT_SIZE",						
								"INVALID_ORDER_SIZE_GT_MAXIMUM_SIZE",								
								"INVALID_ORDER_QUANTITY",											
								"INVALID_ORDER_SIZE_GT_MAXIMUM_ORDER_VALUE",						
								"MAX_GROSS_CONSIDERATION_REACHED",									
								"INVALID_DISPLAY_SIZE_LT_ZERO",									
								"INVALID_DISPLAY_QUANTITY_GREATER_THAN_ORDER_QUANTITY",			
								"INVALID_DISPLAY_SIZE_NOT_MULTIPLE_OF_LOT_SIZE",					
								"INVALID_DISPLAY_QUANTITY",										
								"INVALID_LIMIT_PRICE_LT_EQ_ZERO_OR_NO_LIMIT_PRICE",				
								"INVALID_LIMIT_PRICE_NOT_MULTIPLE_OF_TICK",						
								"INVALID_LIMIT_PRICE_PRICE_BAND_BREACHED",							
								"INVALID_LIMIT_PRICE_GT_MAXIMUM_PRICE",							
								"INVALID_LIMIT_PRICE_LT_MINIMUM_PRICE",							
								"INVALID_ORDER_TYPE_UNKNOWN",										
								"INVALID_TIF_UNKNOWN",												
								"INVALID_EXPIRE_TIME",												
								"INVALID_EXPIRE_TIME_TIME_IS_FOR_A_FUTURE_DATE",					
								"INVALID_EXPIRE_DATE_ELAPSED",										
								"INVALID_TIF_INVALID_DATE_FORMAT",									
								"NO_TIME_QUALIFIER_SPECIFIED",										
								"EXPIRED_END_OF_DAY",												
								"INVALID_ORDER_TYPE_FOR_USER_MARKET_ORDER",						
								"INVALID_SIDE",													
								"INVALID_ORDER_STATUS",											
								"RECEIVED_PRIOR_TO_FIRST_TRADING_DATE_OF_INSTRUMENT",				
								"LAST_TRADING_DATE_OF_INSTRUMENT_ELAPSED",							
								"INVALID_ORDER_CAPACITY",											
								"INVALID_INSTRUMENT_SET_UP_NO_TICK_STRUCTURE",						
								"MONITORING_USER_FROM_SPONSORING_FIRM_NOT_CONNECTED",				
								"ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_CLOSE_UNKNOWN_ORDER",				
								"UNKNOWN_USER_SUBMITTING_TRADER_ID",								
								"UNKNOWN_INSTRUMENT",												
								"UNKNOWN_UNDERLYING",												
								"UNKNOWN_SEGMENT",													
								"UNKNOWN_USER_TARGET_OWNER_ID",									
								"UNKNOWN_USER_TARGET_TRADER_ID",									
								"NO_ORDERS_FOR_INSTRUMENT_UNDERLYING",								
								"INVALID_ORDER_QUANTITY_LESS_THAN_FILLED_QUANTITY",				
								"QUERY_EXECUTED_SUCCESSFULLY",										
								"INVALID_SIDE_DIFFERENT_FROM_ORIGINAL_ORDER",						
								"INVALID_BID_SIZE_GT_MAXIMUM_SIZE",								
								"INVALID_OFFER_SIZE_GT_MAXIMUM_SIZE",								
								"INVALID_DISPLAYED_BID_SIZE_GT_BID_SIZE",							
								"INVALID_DISPLAYED_OFFER_SIZE_GT_OFFER_SIZE",						
								"INVALID_BID_PRICE_LT_EQ_ZERO",									
								"INVALID_OFFER_PRICE_LT_EQ_ZERO",									
								"QUERY_DID_NOT_EXECUTED_SUCCESSFULLY",								
								"QUERY_INSERTION_FAIL",											
								"UNKNOWN_SECURITYID",												
								"INSTRUMENT_HALTED",												
								"INSTRUMENT_HALTED_OR_SUSPENDED",									
								"INSTRUMENT_HALTED_LAST_TRADING_DAY_REACHED",						
								"MARKET_IS_CLOSED",												
								"INSTRUMENT_HALTED_MARKET_SUSPENDED",								
								"INSTRUMENT_HALTED_INVALID_TRADING_SESSION",						
								"SESSION_IS_CLOSED",												
								"INSTRUMENT_HALTED_ORDER_BOOK_IN_INVALID_STATE",					
								"INSTRUMENT_HALTED_INVALID_SET_UP",								
								"INSTRUMENT_HALTED_INVALID_ORDER_BOOK_SET_UP",						
								"INVALID_TRADING_SESSION_UNKNOWN",									
								"INVALID_NEW_ORDER_MESSAGE",										
								"INVALID_CANCEL_ORDER_MESSAGE",									
								"INVALID_QTY_GT_MAX_ORDER_QTY",									
								"INVALID_DISPLAY_SIZE_GT_ORDER_SIZE",								
								"INVALID_ORDER_TYPE_NAMED_ORDERS_ARE_NOT_ALLOWED",					
								"INVALID_ORDER_TYPE_STOP_STOP_LIMIT_ORDERS_ARE_NOT_ALLOWED",		
								"INVALID_ORDER_TYPE_NOT_ALLOWED_IN_THE_SESSION",					
								"INVALID_EXPIRY_DATE_MAXIMUM_ORDER_DURATION_IS_VIOLATED",			
								"INVALID_TIF_NOT_ALLOWED_FOR_STOP_STOP_LIMIT_ORDERS",				
								"INVALID_SESSION_CANNOT_ENTER_ORDERS_QUOTES",						
								"INVALID_SESSION_ORDERS_ARE_NOT_ALLOWED",							
								"INVALID_SESSION_CANNOT_CANCEL_AMEND_ORDERS_QUOTES",				
								"INVALID_ACCOUNT_TYPE_UNKNOWN",									
								"INVALID_BID_SIZE_GT_MAX_QTY",										
								"INVALID_OFFER_SIZE_GT_MAX_QTY",									
								"INVALID_PRICE_BAND",												
								"INVALID_INSTRUMENT_WITH_NO_CLOSING_PRICE_MAINTAINED",				
								"INVALID_SETTLEMENT_DATE",											
								"TRADE_REPORTING_TIME_OVER",										
								"ORDER_VALUE_CANNOT_EXCEED_THE_MAXIMUM_VALUE",						
								"FAILED_PRICE_BAND_VALIDATION",									
								"ERR_NO_ERROR",													
								"ERR_ACCOUNT_DISABLED",											
								"ERR_OFF_QUOTES",													
								"ERR_CLIENTORDERID_BLANK",											
								"ERR_EXPIRE_DATE",													
								"ERR_EMPTY_ORDER_QUANTITY",										
								"ERR_ORDER_TYPE",													
								"ERR_EMPTY_PRICE",													
								"ERR_INVALID_SIDE",												
								"ERR_INVALID_SYMBOL",												
								"ERR_EMPTY_STOP_PRICE",											
								"ERR_INVALID_SECURITY_TYPE",										
								"ERR_INSUFFICIENT_MARGIN",										
								"INVALID_TIF",														
								"ERR_GTD_BLANK",													
								"ERR_FTD_EXPIRE_DATE_INVALID",										
								"ERR_MIN_QTY_NA",													
								"ERR_INVALID_PRICE_INTERVAL",										
								"ERR_LIMITPX_INVALID",												
								"ERR_STOPPX_INVALID",												
								"ERR_SEC_DESC_EXPIRED",											
								"ERR_INVALID_TIME",												
								"ERR_EMPTY_BEGIN_STRING",											
								"ERR_INCORRECT_BEGIN_STRING",										
								"ERR_NULL_OBJECT",																		
								"ERR_EMPTY_MESSAGE_TYPE",											
								"ERR_INCORRECT_MESSAGE_TYPE",										
								"ERR_EMPTY_SENDING_TIME",											
								"INVALID_SENDING_TIME_TIME_IS_FOR_A_FUTURE_TIME",					
								"ERR_EMPTY_KEY_DATA_CONTROL_BLOCK",								
								"ERR_EMPTY_ENCRYPTION_METHOD",										
								"ERR_EMPTY_TRANSACTION_TIME",										
								"INVALID_TRANSACTION_TIME_TIME_IS_FOR_A_FUTURE_TIME",				
								"ERR_EMPTY_OHLC_LAST_TIME",										
								"ERR_EMPTY_OHLC_LAST_UPDATED_TIME",								
								"ERR_EMPTY_QUOTES_ITEM_TIME",										
								"ERR_EMPTY_NEWS_ITEM_TIME_STAMP",									
								"ERR_EMPTY_USER_NAME",												
								"ERR_EMPTY_PWD",													
								"ERR_EMPTY_SEQUENCE_NUMBER",										
								"ERR_EMPTY_HEART_BEAT_INTERVAL",									
								"ERR_EMPTY_REASON_FOR_LOGOUT",										
								"ERR_EMPTY_ACCOUNT_FIELD",											
								"ERR_EMPTY_REF_MSG_TYPE",											
								"ERR_EMPTY_BUSINESS_REJECT_REF_ID",								
								"ERR_EMPTY_BUSINESS_REJECT_REASON",								
								"ERR_EMPTY_ORDER_TYPE",											
								"ERR_EMPTY_SIDE",													
								"ERR_EMPTY_SYMBOL_CODE",											
								"ERR_EMPTY_SECURITY_TYPE",											
								"ERR_EMPTY_TIME_IN_FORCE",											
								"INVALID_TIME_IN_FORCE",											
								"ERR_EMPTY_POSITION_EFFECT",										
								"INVALID_POSITION_EFFECT",											
								"ERR_EMPTY_MINIMUM_DISCLOSE_QTY",									
								"ERR_EMPTY_ORDER_ID",												
								"ERR_EMPTY_ORIG_CL_ORD_ID",										
								"ERR_EMPTY_ORDER_QTY",												
								"ERR_EMPTY_EXPIRE_DATE",											
								"ERR_EMPTY_SUBSCRIBE_FIELD",											
								"ERR_INVALID_SUBSCRIBE_FIELD",										
								"ERR_EMPTY_FILTER_FIELD",										    
								"ERR_INVALID_FILTER_FIELD",										
								"ERR_EMPTY_AVERAGE_PRICE_FIELD",									
								"ERR_EMPTY_CUMULATIVE_QTY_FIELD",								
								"ERR_EMPTY_EXECUTION_ID_FIELD",									
								"ERR_EMPTY_EXECUTION_TRANS_TYPE_FIELD",							
								"INVALID_EXECUTION_TRANS_TYPE",									
								"ERR_EMPTY_ORDER_STATUS_FIELD",									
								"INVALID_EXECUTION_TYPE",											
								"ERR_EMPTY_LEAVE_QUANTITY_FIELD",									
								"ERR_EMPTY_TRADE_DATE_FIELD",										
								"ERR_EMPTY_LAST_PRICE_FIELD",										
								"ERR_EMPTY_NUMBER_OF_ACCOUNT_FIELD",								
								"ERR_EMPTY_NUMBER_OF_PARTICIPANT_FIELD",							
								"ERR_EMPTY_NUMBER_OF_POSITION_FIELD",								
								"ERR_EMPTY_NUMBER_OF_SYMBOL_FIELD",								
								"ERR_EMPTY_EXECUTION_TYPE_FIELD",									
								"ERR_EMPTY_LAST_QUANTITY_FIELD",									
								"ERR_EMPTY_NUMBER_OF_ORDER_FIELD",									
								"ERR_INTERNAL_ERROR",
								"ERR_INTERNAL_ERROR_DB",
								"ERR_TURNOVER_EXCEEDED",
								"Qty greater than Max LotSize",
								"Max Allowable position reached",
								"Insufficient Funds"
								};








