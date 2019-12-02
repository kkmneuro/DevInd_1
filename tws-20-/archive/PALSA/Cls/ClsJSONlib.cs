

using System.Collections.Generic;

namespace TWS.Cls
{

    public struct OrderRequest
    {
        public long Account;
        public string SenderID;
        public string Filter;
        public int msgtype;
    };

    public struct DOM
    {
        public int MarketLevel;
        public double BID;
        public double ASK;
        public double BID_SIZE;
        public double ASK_SIZE;
    };

    public struct positionRequest
    {
        public long Account;
        public string Subscribe;
        public string SenderID;
        public int msgtype;
    };

    public struct userDetails
    {
        public string UserName;
        public string Password;
        public double Version;
        public string SenderID;
        public int msgtype;
    };

    public struct LogoutRequest
    {
        public string UserName;
        public int msgtype;
    };

    public struct participantRequest
    {
        public string UserName;
        public int msgtype;
    };


    public struct logonResponce
    {
        public string AccountType;
        public string BrokerName;
        public int IsLive;
        public string Reason;
        public int msgtype;
    };

    public struct SocketResponce
    {
        public int msgtype;
    };

    class ParticipantCollection
    {
        public int NoOfParticipants { get; set; }
        public string UserName { get; set; }
        public int islastPck;
        public List<AccountDetails> accountInfo { get; set; }
    }

    class PositionCollection
    {
        public int NoOfPosition { get; set; }
        public int islastPck;
        public List<Position> Position { get; set; }
    }

    class AccountCollection
    {
        public int NoOfAccounts { get; set; }
        public int msgtype { get; set; }
        public int islastPck;
        public List<AccountDetails> AccountInfo { get; set; }
    }

    class OrdersCollection
    {
        public int NoOfOrders { get; set; }
        public int islastPck;
        public List<OrderHistory> orderHistory { get; set; }
    }

    class TradeCollection
    {
        public int NoOfOrders { get; set; }
        public int islastPck;
        public List<Cls.ExecutionReport> executionReport { get; set; }
    }

    public struct OrderHistory
    {
        public long Account;
        public decimal AvgPx;
        public string ClOrdId;
        public decimal ClosedQty;
        public decimal ClosePrice;
        public double Commission;
        public string Contract;
        public long CounterAvgPx;
        public string CounterClOrdId;
        public decimal CumQty;
        public string ExpireDate;
        public string Gateway;
        public int industry;
        public decimal LeavesQty;
        public string LinkedOrdID;
        public long OrderID;
        public char OrderStatus;
        public char OrderType;
        public decimal OrderQty;
        public string OrigClOrdId;
        public char PositionEffect;
        public decimal Price;
        public string Product;
        public char ProductType;
        public double Profit;
        public int sector;
        public char Side;
        public decimal StopLoss;
        public string StopLossId;
        public decimal StopPx;
        public decimal TakeProfit;
        public string TakeProfitId;
        public double Tax;
        public string Text;
        public char TimeInForce;
        public string TradeDate;
        public string TransactTime;
    }

    public struct AccountDetails
    {
        public long AccountID;
        public string AccountType;
        public int Active;
        public double Balance;
        public double BuySideTurnOver;
        public double FreeMargin;
        public int Group;
        public int HedgingType;
        public int Leverage;
        public double LotSize;
        public double Margin;
        public int MarginCall1;
        public int MarginCall2;
        public int MarginCall3;
        public int NoOfParticipants;
        public double ReservedMargin;
        public double SellSideturnOver;
        public string TraderName;
        public double UsedMargin;
        // public string UserName;
        public int msgtype;
    }

    public class ClsOrderWebSocket
    {
        public int msgtype;
        public int Account;
        public string ClOrdId;
        public string origClOrdId;
        public string Contract;
        public long ExpireDate;
        public string Gateway;
        public int OrderID;
        public double OrderQty;
        public string OrderType;
        public string PositionEffect;
        public double Price;
        public string Product;
        public string ProductType;
        public string Side;
        public double StopPx;
        public string TimeInForce;
        public long TransactTime;
    }

    public class TradeHistoryRequest
    {
        public int msgtype;
        public int Account;
        public string SenderID;
        public string Filter;
    }

    public struct Position
    {
        public long Account;
        public double BuyAvg;
        public double BuyQty;
        public double BuyVal;
        public string Contract;
        public string Gateway;
        public double NetPrice;
        public double NetQty;
        public double NetVal;
        public string Product;
        public char ProductType;
        public double SellAvg;
        public double SellQty;
        public double SellVal;

    }

    public class ClsNewOrder
    {
        public int msgtype;
        public int Account;
        public string ClOrdId;
        public string origClOrdId;
        public string Contract;
        public double ExpireDate;
        public string Gateway;
        public int OrderID;
        public double OrderQty;
        public char OrderType;
        public char PositionEffect;
        public double Price;
        public string Product;
        public char ProductType;
        public char Side;
        public double StopPx;
        public char TimeInForce;
        public double TransactTime;
        public string LnkdOrdId;
    }

    public class ClsCancelOrder
    {
        public int msgtype;
        public uint Account;
        public double OrderQty;
        public string ClOrdId;
        public char ProductType;
        public string Product;
        public string Contract;
        public string Gateway;
        public char OrderType;
        public double Price;
        public char Side;
        public char TimeInForce;
        public double StopPx;
        public int OrderID;
        public string origClOrdId;
        public char PositionEffect;
    }


    public class ClsModifyOrder
    {
        public int msgtype;
        public int Account;
        public double OrderQty;
        public string ClOrdId;
        public char ProductType;
        public string Product;
        public string Contract;
        public string Gateway;
        public char OrderType;
        public double Price;
        public char Side;
        public char TimeInForce;
        public double StopPx;
        public int OrderID;
        public string origClOrdId;
        public char PositionEffect;
        public int OldAccount;
        public double OldOrderQty;
        public string OldClOrdId;
        public char OldProductType;
        public string OldProduct;
        public string OldContract;
        public string OldGateway;
        public char OldOrderType;
        public double OldPrice;
        public char OldSide;
        public char OldTimeInForce;
        public double OldStopPx;
        public int OldOrderID;
        public string OldorigClOrdId;
        public char OldPositionEffect;

    }
    public class ExecutionReport
    {
        public long Account;
        public int author;
        public decimal AvgPx;
        public string ClOrdId;
        public decimal ClosedQty;
        public double Comm;
        public string Contract;
        public long CounterAvgPx;
        public string CounterClOrdId;
        public long CumQty;
        public string ExecID;
        public char ExecTransType;
        public char ExecType;
        public string ExpireDate;
        public string Gateway;
        public int industry;
        public decimal LastPx;
        public decimal LeavesQty;
        public string LinkedOrdID;
        public long MMId;
        public long OrderID;
        public char OrderInfoEnd;
        public char OrderStatus;
        public char OrderType;
        public decimal OrderQty;
        public string OrigClOrdID;
        public char PositionEffect;
        public decimal Price;
        public string Product;
        public char ProductType;
        public double Profit;
        public decimal QtyFilled;
        public int sector;
        public char Side;
        public decimal StopPx;
        public double Tax;
        public string Text;
        public char TimeInForce;
        public string TransactTime;

    }

    public class SymbolSubscribeRequest
    {
        public int NoOfSymbols;
        public SubscribeRequestType isForSubscribe;
        public List<SymbolInfo> Symbol;
        public int msgtype;


    }


    /* {"NoOfSymbols":1,Subscribe:1,"Symbols":[{"Contract":”EURUSD”,"ProductType":”0”,"Product":”EURUSD”, "Gateway":"ECXS"}]"msgtype":28} */


    //public class InstrumentSpec
    //{
    //    public int BuySideTurnover;
    //    public int Charges;
    //    public string Contract;
    //    public int ContractSize;
    //    public string DeliveryEndDate;
    //    public string DeliveryQuantity;
    //    public string DeliveryStartDate;
    //    public string DeliveryType;
    //    public string DeliveryUnit;
    //    public int Digits;
    //    public float DPRInitialPercentage;
    //    public int DPRIntervalSecs;
    //    public string EndDate;
    //    public string ExpiryDate;
    //    public int FreezeLevel;
    //    public string Gateway;
    //    public int GeneralDenominator;
    //    public int GeneralNumerator;
    //    public int Hedged;
    //    public string Information;
    //    public int InitialBuyMargin;
    //    public int InitialSellMargin;
    //    public int Limit_Stop_Level;
    //    public int LongPositions;
    //    public int MarginCall1;
    //    public int MarginCall2;
    //    public int MarginCall3;
    //    public int MarginCurrency;
    //    public int MarketLot;
    //    public int MaxDPR;
    //    public int MaximumAllowablePosition;
    //    public int MaximumLotsForIE;
    //    public int MaxOrderSize;
    //    public int MaxOrderValue;
    //    public int MinDPR;
    //    public int Orders;
    //    public int OtherBuyMargin;
    //    public int OtherSellMargin;
    //    public string Percentage;
    //    public int PriceDenominator;
    //    public int PriceNumerator;
    //    public int PriceQuantity;
    //    public int PriceTick;
    //    public string Product;
    //    public string ProductType;
    //    public int QuotationBaseValue;
    //    public string reserved;
    //    public int SellSideTurnover;
    //    public string SettlingCurrency;
    //    public int ShortPositions;
    //    public string Specification;
    //    public int SpreadBalance;
    //    public int SpreadByDefault;
    //    public string StartDate;
    //    public string TenderEndDate;
    //    public string TenderStartDate;
    //    public int TickSize;
    //    public string TradingCurrency;
    //    public string UL_Asset;

    //    public InstrumentSpec();
    //}

    //public enum eMarketRequest
    //{
    //    MARKET_QUOTE_REQUEST = 0,
    //    MARKET_QUOTE_SNAP = 1,
    //    MARKET_DEPTH = 2,
    //}

    //[Serializable]
    //public class Symbol
    //{
    //    public const string _Seperator = "_";

    //    public string _ContractName;
    //    public string _Gateway;
    //    public string _ProductName;
    //    public string _ProductType;

    //    public Symbol();

    //    public string KEY { get; }

    //    public static List<string> getKey(InstrumentSpec spec);
    //    public static Symbol GetSymbol(string key);
    //}
}
