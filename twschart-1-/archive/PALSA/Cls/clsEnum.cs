///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//20/01/2012	VP		    1.Added members in CommandIDs enum related to Theming
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Runtime.Serialization;

namespace PALSA.Cls
{
    public enum CommandIDS
    {
        LOGIN = 0,
        LOGOFF,
        LOAD_WORKSPACE,
        SAVE_WORKSPACE,
        CHANGE_PASSWORD,
        EXIT,
        TICKER,
        TRADE,
        NET_POSITION,
        MESSAGE_LOG,
        CONTRACT_INFORMATION,
        TOOL_BAR,
        FILTER_BAR,
        MESSAGE_BAR,
        STATUS_BAR,
        TOP_STATUS_BAR,
        MIDDLE_STATUS_BAR,
        BOTTOM_STATUS_BAR,
        ADMIN_MESSAGE_BAR,
        INDICES_VIEW,
        FULL_SCREEN,
        MARKET_WATCH,
        MARKET_PICTURE,
        SNAP_QUOTE,
        MARKET_STATUS,
        TOP_GAINERS_LOSERS,
        PLACE_BUY_ORDER,
        PLACE_SELL_ORDER,
        PLACE_ORDER,
        ORDER_BOOK,
        TRADES,
        CUSTOMIZE,
        LOCK_WORKSTATION,
        PORTFOLIO,
        PREFERENCES,
        NEW_WINDOW,
        CLOSE,
        CLOSE_ALL,
        CASCADE,
        TILE_HORIZONTALLY,
        TILE_VERTICALLY,
        WINDOW,
        HELP,
        LANGUAGES,
        ONLINE_BACKUP,
        PRINT,
        MODIFY_ORDER,
        CANCEL_SELECTED_ORDER,
        CANCEL_ALL_ORDERS,
        ENGLISH,
        HINDI,
        MAC_OS,
        OFFICE_2007_BLACk,
        OFFICE_2007_BLUE,
        ORANGE,
        VISTA,
        VISTA_ROYAL,
        INSPIRANT,
        VISTA_SLATE,
        SIMPLE,
        OPUS_ALPHA,
        OFFICE_2007_AQUA,
        VISTA_PLUS,
        PARTICIPANT_LIST,
        INDEX_BAR,
        FILTER,
        MODIFY_TRDES,
        MOST_ACTIVE_PRODCUTS,
        NEW_CHART,
        MARKET_QUOTE,
        ACCOUNTS_TO_TRADE,
        ROYAL,
        AQUA,
        MOONLIGHT,
        WOOD,
        //===================Chart=============
        PERIODICITY_1_MINUTE,
        PERIODICITY_5_MINUTE,
        PERIODICITY_15_MINUTE,
        PERIODICITY_30_MINUTE,
        PERIODICITY_1_HOUR,
        PERIODICITY_4_HOUR,
        PERIODICITY_DAILY,
        PERIODICITY_WEEKLY,
        PERIODICITY_MONTHLY,
        CHARTTYPE_BAR_CHART,
        CHARTTYPE_CANDLE_CHART,
        CHARTTYPE_LINE_CHART,
        PRICETYPE_POINT_AND_FIGURE,
        PRICETYPE_RENKO,
        PRICETYPE_KAGI,
        PRICETYPE_THREE_LINE_BREAK,
        PRICETYPE_EQUI_VOLUME,
        PRICETYPE_EQUI_VOLUME_SHADOW,
        PRICETYPE_CANDLE_VOLUME,
        PRICETYPE_HEIKIN_ASHI,
        PRICETYPE_STANDARD_CHART,
        ZOOM_IN,
        ZOOM_OUT,
        TRACK_CURSOR,
        VOLUME,
        GRID,
        CHART_3D_STYLE,
        SNAPSHOT_PRINT,
        SNAPSHOT_SAVE,
        INDICATOR_LIST,
        HORIZONTAL_LINE,
        VERTICAL_LINE,
        TEXT,
        TREND_LINE,
        ELLIPSE,
        SPEED_LINES,
        GANN_FAN,
        FIBONACCI_ARC,
        FIBONACCI_RETRACEMENT,
        FIBONACCI_FAN,
        FIBONACCI_TIMEZONE,
        TIRONE_LEVEL,
        QUADRENT_LINES,
        RAFF_REGRESSION,
        ERROR_CHANNEL,
        RECTANGLE,
        FREE_HAND_DRAWING,
        //===================Chart=============
        SURVEILLANCE,
        ABOUTUS,
        MAIL,
        RELOAD_CONFIGURATION,
        RISK_MANAGER,
        RISK_MONITOR,
        SIMULATOR,
        SCANNER,
        PENDING_ORDERS,
        RADAR,
        GREEN,
        CREATE_DEMO_ACCOUNT
    }

    public enum MessageLogType
    {
        ALL,
        DEBUG,
        INFO,
        CRITICAL
    }
    public enum Periodicity : byte
    {
        Secondly = 1,
        Minutely = 2,
        Hourly = 3,
        Daily = 4,
        Weekly = 5,
        Monthly = 6,
        Unspecified
    }
    public enum MessageType
    {
        ORDER,
        TRADE,
        MARKET,
        SYSTEM,
        MEMBER,
        ALERT,
        ADMIN,
        SURVEILANCE,
        NEWS,
        OTHER
    }


    public enum MessageTypes : int
    {
        LOGON_REQUEST = 1,
        LOGON_RESPONSE = 2,
        LOGOUT_REQUEST = 3,
        NEW_ORDER_REQUEST = 4,
        ORDER_CANCEL_REQUEST = 5,
        ORDER_REPLACE_REQUEST = 6,
        ORDER_STATUS_REQUEST = 7,
        ACCOUNT_REQUEST = 8,
        POSITION_REQUEST = 9,
        ORDER_HISTORY_REQUEST = 10,
        PARTICIPANT_LIST_REQUEST = 11,
        EXECUTION_REPORT_RESPONSE = 12,
        ORDER_STATUS_RESPONSE = 13,
        REJECT_MESSAGE_RESPONSE = 14,
        ORDER_CANCEL_REJECT_RESPONSE = 15,
        ACCOUNT_RESPONSE = 16,
        PARTICIPANT_LIST_RESPONSE = 17,
        POSITION_RESPONSE = 18,
        BUSINESS_LEVEL_REJECT = 19,
        QUOTE_SUBSCRIPTION_REQUEST = 20,
        QUOTES_UNSUBSCRIPTION_REQUEST = 21,
        QUOTE_SNAP_SHOT_RESPONSE = 22,
        QUOTES_STREAM = 23,
        NEWS_SUBSCRIPTION = 24,
        NEWS_STREAM = 25,
        TOP_GAINERS_LOSERS = 26,
        ORDER_HISTORY_RESPONSE = 27,
        QUOTE__REQUEST = 28,
        QUOTE__SNAPSHOT_REQUEST = 29,
        QUOTE__DOM_REQUEST = 30,
        NEWS__REQUEST = 31,
        LOGOUT_RESPONSE = 32,
        TRADE_HISTORY_REQUEST = 33,
        TRADE_HISTORY_RESPONSE = 34,
        HEARTBEAT = 35,
        BUFFER = 36,
        MATCHED_ORDER_REQUEST = 37,
        MATCHED_ORDER_RESPONSE = 38,
        ORDER_BOOK_REQUEST = 39,
        STOP_ORDER_REQUEST = 40,
        ORDER_BOOK_RESPONSE = 41,
        STOP_ORDER_RESPONSE = 42,
        MATCHING_ORDER_REQUEST = 43
    }

    public enum SubscribeRequestType : int
    {
        UNSUBSCRIBE = 0,
        SUBSCRIBE = 1

    }

    public enum BusinessRejectReason : int
    {
        ERR_OK = 0,
        INVALID_USERID_PWD = -50001,
        ALREADY_LOGGED = -50002,
        USER_NOT_FOUND = -50003,
        FLAGGED_FOR_DELETION = -50004,
        ACCOUNT_LOCKED = -50005,
        ACCOUNT_EXPIRED = -50006,
        MIN_PSWD_LEN = -50007,
        MAX_PSWD_LEN = -50008,
        NO_TIME_ZONE = -50009,
        USER_NOT_LOGGEDIN = -50010,
        INVALID_ORDER_SIZE_LT_EQ_ZERO = -50011,
        INVALID_ORDER_SIZE_LT_MINIMUM_SIZE = -50012,
        INVALID_ORDER_SIZE_NOT_MULTIPLE_OF_LOT_SIZE = -50013,
        INVALID_ORDER_SIZE_GT_MAXIMUM_SIZE = -50014,
        INVALID_ORDER_QUANTITY = -50015,
        INVALID_ORDER_SIZE_GT_MAXIMUM_ORDER_VALUE = -50016,
        MAX_GROSS_CONSIDERATION_REACHED = -50017,
        INVALID_DISPLAY_SIZE_LT_ZERO = -50018,
        INVALID_DISPLAY_QUANTITY_GREATER_THAN_ORDER_QUANTITY = -50019,
        INVALID_DISPLAY_SIZE_NOT_MULTIPLE_OF_LOT_SIZE = -50020,
        INVALID_DISPLAY_QUANTITY = -50021,
        INVALID_LIMIT_PRICE_LT_EQ_ZERO_OR_NO_LIMIT_PRICE = -50022,
        INVALID_LIMIT_PRICE_NOT_MULTIPLE_OF_TICK = -50023,
        INVALID_LIMIT_PRICE_PRICE_BAND_BREACHED = -50024,
        INVALID_LIMIT_PRICE_GT_MAXIMUM_PRICE = -50025,
        INVALID_LIMIT_PRICE_LT_MINIMUM_PRICE = -50026,
        INVALID_ORDER_TYPE_UNKNOWN = -50027,
        INVALID_TIF_UNKNOWN = -50028,
        INVALID_EXPIRE_TIME = -50029,
        INVALID_EXPIRE_TIME_TIME_IS_FOR_A_FUTURE_DATE = -50030,
        INVALID_EXPIRE_DATE_ELAPSED = -50031,
        INVALID_TIF_INVALID_DATE_FORMAT = -50032,
        NO_TIME_QUALIFIER_SPECIFIED = -50033,
        EXPIRED_END_OF_DAY = -50034,
        INVALID_ORDER_TYPE_FOR_USER_MARKET_ORDER = -50035,
        INVALID_SIDE = -50036,
        INVALID_ORDER_STATUS = -50037,
        RECEIVED_PRIOR_TO_FIRST_TRADING_DATE_OF_INSTRUMENT = -50038,
        LAST_TRADING_DATE_OF_INSTRUMENT_ELAPSED = -50039,
        INVALID_ORDER_CAPACITY = -50040,
        INVALID_INSTRUMENT_SET_UP_NO_TICK_STRUCTURE = -50041,
        MONITORING_USER_FROM_SPONSORING_FIRM_NOT_CONNECTED = -50042,
        ORDER_NOT_FOUND_TOO_LATE_TO_CANCEL_OR_UNKNOWN_ORDER = -50043,
        UNKNOWN_USER_SUBMITTING_TRADER_ID = -50044,
        UNKNOWN_INSTRUMENT = -50045,
        UNKNOWN_UNDERLYING = -50046,
        UNKNOWN_SEGMENT = -50047,
        UNKNOWN_USER_TARGET_OWNER_ID = -50048,
        UNKNOWN_USER_TARGET_TRADER_ID = -50049,
        NO_ORDERS_FOR_INSTRUMENT_UNDERLYING = -50050,
        INVALID_ORDER_QUANTITY_LESS_THAN_FILLED_QUANTITY = -50051,
        QUERY_EXECUTED_SUCCESSFULLY = -50052,
        INVALID_SIDE_DIFFERENT_FROM_ORIGINAL_ORDER = -50053,
        INVALID_BID_SIZE_GT_MAXIMUM_SIZE = -50054,
        INVALID_OFFER_SIZE_GT_MAXIMUM_SIZE = -50055,
        INVALID_DISPLAYED_BID_SIZE_GT_BID_SIZE = -50056,
        INVALID_DISPLAYED_OFFER_SIZE_GT_OFFER_SIZE = -50057,
        INVALID_BID_PRICE_LT_EQ_ZERO = -50058,
        INVALID_OFFER_PRICE_LT_EQ_ZERO = -50059,
        QUERY_DID_NOT_EXECUTED_SUCCESSFULLY = -50060,
        QUERY_INSERTION_FAIL = -50061,
        UNKNOWN_SECURITYID = -50062,
        INSTRUMENT_HALTED = -50063,
        INSTRUMENT_HALTED_OR_SUSPENDED = -50064,
        INSTRUMENT_HALTED_LAST_TRADING_DAY_REACHED = -50065,
        MARKET_IS_CLOSED = -50066,
        INSTRUMENT_HALTED_MARKET_SUSPENDED = -50067,
        INSTRUMENT_HALTED_INVALID_TRADING_SESSION = -50068,
        SESSION_IS_CLOSED = -50069,
        INSTRUMENT_HALTED_ORDER_BOOK_IN_INVALID_STATE = -50070,
        INSTRUMENT_HALTED_INVALID_SET_UP = -50071,
        INSTRUMENT_HALTED_INVALID_ORDER_BOOK_SET_UP = -50072,
        INVALID_TRADING_SESSION_UNKNOWN = -50073,
        INVALID_NEW_ORDER_MESSAGE = -50074,
        INVALID_CANCEL_ORDER_MESSAGE = -50075,
        INVALID_QTY_GT_MAX_ORDER_QTY = -50076,
        INVALID_DISPLAY_SIZE_GT_ORDER_SIZE = -50077,
        INVALID_ORDER_TYPE_NAMED_ORDERS_ARE_NOT_ALLOWED = -50078,
        INVALID_ORDER_TYPE_STOP_STOP_LIMIT_ORDERS_ARE_NOT_ALLOWED = -50079,
        INVALID_ORDER_TYPE_NOT_ALLOWED_IN_THE_SESSION = -50080,
        INVALID_EXPIRY_DATE_MAXIMUM_ORDER_DURATION_IS_VIOLATED = -50081,
        INVALID_TIF_NOT_ALLOWED_FOR_STOP_STOP_LIMIT_ORDERS = -50082,
        INVALID_SESSION_CANNOT_ENTER_ORDERS_QUOTES = -50083,
        INVALID_SESSION_ORDERS_ARE_NOT_ALLOWED = -50084,
        INVALID_SESSION_CANNOT_CANCEL_AMEND_ORDERS_QUOTES = -50085,
        INVALID_ACCOUNT_TYPE_UNKNOWN = -50086,
        INVALID_BID_SIZE_GT_MAX_QTY = -50087,
        INVALID_OFFER_SIZE_GT_MAX_QTY = -50088,
        INVALID_PRICE_BAND = -50089,
        INVALID_INSTRUMENT_WITH_NO_CLOSING_PRICE_MAINTAINED = -50090,
        INVALID_SETTLEMENT_DATE = -50091,
        TRADE_REPORTING_TIME_OVER = -50092,
        ORDER_VALUE_CANNOT_EXCEED_THE_MAXIMUM_VALUE = -50093,
        FAILED_PRICE_BAND_VALIDATION = -50094,
        ERR_NO_ERROR = -50095,
        ERR_ACCOUNT_DISABLED = -50096,
        ERR_OFF_QUOTES = -50097,
        ERR_CLIENTORDERID_BLANK = -50098,
        ERR_EXPIRE_DATE = -50099,
        ERR_EMPTY_ORDER_QUANTITY = -50100,
        ERR_ORDER_TYPE = -50101,
        ERR_EMPTY_PRICE = -50102,
        ERR_INVALID_SIDE = -50103,
        ERR_INVALID_SYMBOL = -50104,
        ERR_EMPTY_STOP_PRICE = -50105,
        ERR_INVALID_SECURITY_TYPE = -50106,
        ERR_INSUFFICIENT_MARGIN = -50107,
        INVALID_TIF = -50108,
        ERR_GTD_BLANK = -50109,
        ERR_FTD_EXPIRE_DATE_INVALID = -50110,
        ERR_MIN_QTY_NA = -50111,
        ERR_INVALID_PRICE_INTERVAL = -50112,
        ERR_LIMITPX_INVALID = -50113,
        ERR_STOPPX_INVALID = -50114,
        ERR_SEC_DESC_EXPIRED = -50115,
        ERR_INVALID_TIME = -50116,
        ERR_EMPTY_BEGIN_STRING = -50117,
        ERR_INCORRECT_BEGIN_STRING = -50118,
        ERR_NULL_OBJECT = -50119,
        ERR_EMPTY_MESSAGE_TYPE = -50120,
        ERR_INCORRECT_MESSAGE_TYPE = -50121,
        ERR_EMPTY_SENDING_TIME = -50122,
        INVALID_SENDING_TIME_TIME_IS_FOR_A_FUTURE_TIME = -50123,
        ERR_EMPTY_KEY_DATA_CONTROL_BLOCK = -50124,
        ERR_EMPTY_ENCRYPTION_METHOD = -50125,
        ERR_EMPTY_TRANSACTION_TIME = -50126,
        INVALID_TRANSACTION_TIME_TIME_IS_FOR_A_FUTURE_TIME = -50127,
        ERR_EMPTY_OHLC_LAST_TIME = -50128,
        ERR_EMPTY_OHLC_LAST_UPDATED_TIME = -50129,
        ERR_EMPTY_QUOTES_ITEM_TIME = -50130,
        ERR_EMPTY_NEWS_ITEM_TIME_STAMP = -50131,
        ERR_EMPTY_USER_NAME = -50132,
        ERR_EMPTY_PWD = -50133,
        ERR_EMPTY_SEQUENCE_NUMBER = -50134,
        ERR_EMPTY_HEART_BEAT_INTERVAL = -50135,
        ERR_EMPTY_REASON_FOR_LOGOUT = -50136,
        ERR_EMPTY_ACCOUNT_FIELD = -50137,
        ERR_EMPTY_REF_MSG_TYPE = -50138,
        ERR_EMPTY_BUSINESS_REJECT_REF_ID = -50139,
        ERR_EMPTY_BUSINESS_REJECT_REASON = -50140,
        ERR_EMPTY_ORDER_TYPE = -50141,
        ERR_EMPTY_SIDE = -50142,
        ERR_EMPTY_SYMBOL_CODE = -50143,
        ERR_EMPTY_SECURITY_TYPE = -50144,
        ERR_EMPTY_TIME_IN_FORCE = -50145,
        INVALID_TIME_IN_FORCE = -50146,
        ERR_EMPTY_POSITION_EFFECT = -50147,
        INVALID_POSITION_EFFECT = -50148,
        ERR_EMPTY_MINIMUM_DISCLOSE_QTY = -50149,
        ERR_EMPTY_ORDER_ID = -50150,
        ERR_EMPTY_ORIG_CL_ORD_ID = -50151,
        ERR_EMPTY_ORDER_QTY = -50152,
        ERR_EMPTY_EXPIRE_DATE = -50153,
        ERR_EMPTY_SUBSCRIBE_FIELD = -50154,
        ERR_INVALID_SUBSCRIBE_FIELD = -50155,
        ERR_EMPTY_FILTER_FIELD = -50156,
        ERR_INVALID_FILTER_FIELD = -50157,
        ERR_EMPTY_AVERAGE_PRICE_FIELD = -50158,
        ERR_EMPTY_CUMULATIVE_QTY_FIELD = -50159,
        ERR_EMPTY_EXECUTION_ID_FIELD = -50160,
        ERR_EMPTY_EXECUTION_TRANS_TYPE_FIELD = -50161,
        INVALID_EXECUTION_TRANS_TYPE = -50162,
        ERR_EMPTY_ORDER_STATUS_FIELD = -50163,
        INVALID_EXECUTION_TYPE = -50164,
        ERR_EMPTY_LEAVE_QUANTITY_FIELD = -50165,
        ERR_EMPTY_TRADE_DATE_FIELD = -50166,
        ERR_EMPTY_LAST_PRICE_FIELD = -50167,
        ERR_EMPTY_NUMBER_OF_ACCOUNT_FIELD = -50168,
        ERR_EMPTY_NUMBER_OF_PARTICIPANT_FIELD = -50169,
        ERR_EMPTY_NUMBER_OF_POSITION_FIELD = -50170,
        ERR_EMPTY_NUMBER_OF_SYMBOL_FIELD = -50171,
        ERR_EMPTY_EXECUTION_TYPE_FIELD = -50172,
        ERR_EMPTY_LAST_QUANTITY_FIELD = -50173,
        ERR_EMPTY_NUMBER_OF_ORDER_FIELD = -50174,
        ERR_INTERNAL_ERROR = -50175,
        ERR_INTERNAL_ERROR_DB = -50176
    }

    //public enum QuoteStreamType : int
    //{
    //    ASK = 'A',
    //    BID = 'B',
    //    LAST = 'L',
    //    VOLUME = 'V',
    //    VOLUME_PER = 'P',
    //    LOW = 'M',
    //    HIGH = 'H',
    //    OPEN = 'O',
    //    CLOSE = 'C',
    //}

    //public enum QuoteItemStatus : int
    //{
    //    UP = 0,
    //    DOWN = 1,
    //    SAME = -1,
    //}

    public static class clsHashDefine
    {
        public static readonly char SIDE_BUY = '1';
        public static readonly char SIDE_SELL = '2';

        public static readonly char POSITION_OPENING_TRADE = 'O';
        public static readonly char POSITION_CLOSING_TRADE = 'C';

        public static readonly char TIF_DAY = '0';
        //public static readonly char TIF_GOOD_TILL_CANCEL = '1';  
        public static readonly char TIF_GTC = '1';
        //public static readonly char TIF_FOK = '3';                            
        //public static readonly char TIF_GOOD_TILL_DATE = '6';
        //public static readonly char TIF_GTD = '6';

        public static readonly char ORDER_TYPE_MARKET_ORDER = '1';
        public static readonly char ORDER_TYPE_LIMIT_ORDER = '2';
        public static readonly char ORDER_TYPE_STOP_ORDER = '3';
        public static readonly char ORDER_TYPE_STOP_LIMIT_ORDER = '4';

        public static readonly char ORDER_STATUS_NEW = '0';
        public static readonly char ORDER_STATUS_PARTIALLY_FILLED = '1';
        public static readonly char ORDER_STATUS_FILLED = '2';
        public static readonly char ORDER_STATUS_CANCELED = '4';
        public static readonly char ORDER_STATUS_REPLACED = '5';
        public static readonly char ORDER_STATUS_PENDING_CANCEL = '6';
        public static readonly char ORDER_STATUS_REJECTED = '8';
        public static readonly char ORDER_STATUS_PENDING_NEW = 'A';
        public static readonly char ORDER_STATUS_EXPIRED = 'C';
        public static readonly char ORDER_STATUS_PENDING_REPLACE = 'E';
        public static readonly char ORDER_STATUS_UNDEFINED = 'U';
        public static readonly char ORDER_STATUS_ORDER_NOT_FOUND = 'Y';


        public static readonly char EXECUTION_TYPE_NEW = '0';
        public static readonly char EXECUTION_TYPE_PARTFILLED = '1';
        public static readonly char EXECUTION_TYPE_FILLED = '2';
        public static readonly char EXECUTION_TYPE_CANCELACK = '4';
        public static readonly char EXECUTION_TYPE_MODIFYACK = '5';
        public static readonly char EXECUTION_TYPE_REJECTACK = '8';
        public static readonly char EXECUTION_TYPE_ELIMINATIONACK = 'C';
        public static readonly char EXECUTION_TYPE_STATUS_REPORT = 'I';
        public static readonly char EXECUTION_TRANSTYPE_NEW = '0';
        public static readonly char EXECUTION_TRANSTYPE_STATUS = '3';
        public static readonly char QUOTES_STREAM_TYPE_ASK = 'A';
        public static readonly char QUOTES_STREAM_TYPE_BID = 'B';
        public static readonly char QUOTES_STREAM_TYPE_LAST = 'L';
        public static readonly char QUOTES_STREAM_TYPE_VOLUME = 'V';
        public static readonly char QUOTES_STREAM_TYPE_VOLUME_PERCENT = 'P';
        public static readonly char QUOTES_STREAM_TYPE_LOW = 'M';
        public static readonly char QUOTES_STREAM_TYPE_HIGH = 'H';
        public static readonly char QUOTES_STREAM_TYPE_OPEN = 'O';
        public static readonly char QUOTES_STREAM_TYPE_CLOSE = 'C';
        public static readonly char SECURITY_TYPE_FX = '0';
        public static readonly char SECURITY_TYPE_FUT = '1';
        public static readonly char SECURITY_TYPE_OPT = '2';
        public static readonly char SECURITY_TYPE_EQ = '3';
        public static readonly char SECURITY_TYPE_SP = '4';
        public static readonly char SECURITY_TYPE_BON = '5';
        public static readonly char SECURITY_TYPE_PH = '6';
        public static readonly char SECURITY_TYPE_AU = '7';
        public static readonly char FILTER_ALL = '0';
        public static readonly char FILTER_LIVE_ORDERS = '1';
        public static readonly char FILTER_FILLED_ORDERS = '2';
        public static readonly char FILTER_CANCEL_ORDERS = '3';
        public static readonly char FILTER_REJECTED_ORDERS = '4';
        public static readonly char SUBSCRIBE = 'Y';
        public static readonly char UNSUBSCRIBE = 'N';
        public static readonly char REJECTION_CODE_OTHER = '0';
        public static readonly char REJECTION_CODE_UNKNOWN_ID = '1';
        public static readonly char REJECTION_CODE_UNKNOWN_SECURITY = '2';
        public static readonly char REJECTION_CODE_UNSUPPORTED_MESSAGE_TYPE = '3';
        public static readonly char REJECTION_CODE_APPLICATION_NOT_AVAILABLE = '4';
        public static readonly char REJECTION_CODE_FIELD_MISSING = '5';
        public static readonly char REJECTION_CODE_NOT_AUTHORIZED = '6';
        public static readonly char REJECTION_CODE_NOT_AVAILABLE = '7';

        //MessageTypes


    }

    public enum eMarketRequest : int
    {
        MARKET_QUOTE_REQUEST = 0,
        MARKET_QUOTE_SNAP = 1,
        MARKET_DEPTH = 2,
    }

    public enum PeriodEnum : int
    {[EnumMember] Minute = 1, [EnumMember] Hour = 60, [EnumMember] Day = 480, [EnumMember] Week = 2400, [EnumMember] Month = 9600, [EnumMember] Year = 115200 };
}