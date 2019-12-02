using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsInterface4OME
{
    public enum OrderType
    {
        MARKET = 1,
        LIMIT,
        STP,
        STL,
        SLTP,
        NA
    }
    public enum Side
    {
        BUY = 1,
        SELL,
        NA

    }
    public enum OrderRequestType
    {
        NA = 1,
        NEW,
        MODIFIED,
        CANCELLED,
        CLOSED,
        SLTP_URG_CLOSED,
        OPEN

    }

    public enum UserType
    {
        Client,
        Accountant,
        Programmer,
        Administrator,
        Boss,
        HouseAccount,
        NA
    }

    //Closed added in  OrderRequestType
    //public enum enm4OMS
    //{
    //    NA,
    //    CLOSED,
    //    SLTP

    //}
    public enum TIF
    {
        DAY = 1,
        DATE = 2,
        GTC = 3,
        NA = 4,
        NOT_DEFINED

    }

    public enum Reason
    {
        NA = 1,
        ACCEPTED,
        ORDER_NOT_FOUND,
        CANCELLED,
        MODIFIED,
        EXCHANGE_EMPTY,
        BALANCE_ZERO,
        NOT_ENOUGH_MONEY,
        MARGIN_DATA_UNAVAILABLE,
        SL_TP_QTY_SHOULD_BE_GREATER_THAN_ZERO,
        PRICE_QTY_SHOULD_BE_GREATER_THAN_ZERO,
        OME_INTERNAL_ERROR,
        EXPIRED,
        SESSION_CLOSED,
        SYMBOL_NOT_AVAILABLE,
        SERVICCE_UNAVAILABLE,
        SYMBOL_EXPIRED,
        VALIDATION_FAILED,
        MARKET_PRICE_NOT_AVAILABLE,
        EXCEPTION,
        CLOSEORDERID_NOT_SENT,
        INVALID_QTY
    }

    public enum OrderStatus
    {
        NEW = 1,
        WORKING = 2,
        FILLED = 3,
        PARTIAL_FILLED = 4,//PARTIALLY_FILLED = 4,
        CANCELED = 5,
        REJECTED = 6,
        EXPIRED = 7,
        CANCEL_PENDING = 8,
        PENDING = 9,
        CLOSE_PROCESS = 10,
        PARTIAL_CLOSED = 11,
        CLOSED = 12,
        MULTIPLE = 13,
        NOTVALID = 15,

        CNCIP = 17,
        MODIFY_PENDING = 18,
        MODIFIED = 19,
        ACKNOWLEDGE = 20,
        PARTIAL_REJECTED = 21,//PARTIALLY_REJECTED = 21,
        SLTP_URG_CLOSED_IN_PROCESS = 23,
        PARTIAL_CANCELLED = 24,
        SENT = 25
    }

    public enum TradeStatus
    {
        NA = 1,
        FILLED,
        PARTIAL_FILLED//PARTIALLY_FILLED

    }
    public enum MarketStatus
    {
        Open = 1,
        Closed,
        Suspend,
        CompMode,
        NA
    }
    public enum SvrlMSG
    {
        Duplicate_Client,
        SLTP_Urg_Already_Sent,
        Exchange_Opened,
        Exchange_Closed,
        Older_Version,
        LogOut,
        NA
    }

    public enum DataType
    {
        BinaryType,
        StringType
    }

    public enum Mode4Patrick
    {
        Add,
        Edit,
        Delete,
        NA
    }
    public enum Reason4LoginFailure
    {

        OldVersion=1,
        InValid_Password=2,
        IsNotAdmin=3,
        NA=4
    }
}
