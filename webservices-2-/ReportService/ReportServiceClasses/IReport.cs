using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace ReportServiceClasses
{
    /// <summary>
    /// Summary description for IMasterInfo
    /// </summary>
    [ServiceContract]
    public interface IReport
    {
        [OperationContract]
        List<clsTradeReport> GetTradeReportData(string userIdPwd,TradeReportSearchValues searchValues,TradeReportSearchType searchType);
        [OperationContract]
        List<clsOrderReport> GetOrderReportData(string userIdPwd, TradeReportSearchValues searchValues, TradeReportSearchType searchType);
        [OperationContract]
        List<clsClientCommission> GetClientCommmissionReportData(string userIdPwd, ClientCommissionSearchValues searchValues, 
            ClientCommissionSearchType searchType);
        [OperationContract]
        List<clsStockLevel> GetStockLevelReportData(string userIdPwd, StockLevelSearchValues searchValues, StockLevelSearchType searchType);
        [OperationContract]
        List<clsClientHoldingStock> GetClientHoldingReportData(string userIdPwd, ClientHoldingSearchValues searchValues, ClientHoldingSearchType searchType);
        [OperationContract]
        List<clsMarginReports> GetMarginReportData(string userIdPwd, MarginSearchValues searchValues, MarginSearchType searchType);
        [OperationContract]
        List<clsAccountTrans> GetAccountTransReportData(string userIdPwd, AccountTransSearchValues searchValues);
        [OperationContract]
        List<clsTopTradedInstruments> GetTopTradedInstReportData(string userIdPwd);
        [OperationContract]
        List<clsNewClientInfo> GetNewClientInfoReportData(string userIdPwd);
        [OperationContract]
        clsReportsMasterInfo GetReportsMasterInfo(string userIdPwd);
        [OperationContract]
        List<clsDayClosing> GetDayClosingReportData(string userIdPwd, DayClosingSearchValues searchValues);
    }

    public enum TradeReportSearchType
    {
        BY_DATE,
        BY_SIDE,
        BY_ACCOUNT_NUMBER,
        BY_ORDER_TYPE,
        BY_ORDER_NUMBER,
        BY_TRADE_NUMBER,
        BY_DATE_SIDE,
        BY_DATE_ACCOUNT_NUMBER,
        BY_DATE_SIDE_ACCOUNT_NUMBER,
        BY_DATE_ORDER_TYPE,
        BY_DATE_SIDE_ORDER_TYPE,
        BY_DATE_SIDE_ACCOUNT_NUMBER_ORDER_TYPE,
        BY_OPEN_POSITION
    }

    public class TradeReportSearchValues
    {
        public DateTime DateValue { get; set; } // also used as FromDate
        public string Side { get; set; }
        public int AccountNumber { get; set; }
        public string OrderType { get; set; }
        public long OrderNumber { get; set; }
        public long TradeNumber { get; set; }
        public DateTime ToDate { get; set; }
        public int BrokerID { get; set; }
        public string Symbol { get; set; }
        public int BrokerParentID { get; set; }
        public int TIF_ID { get; set; }
    }

    public class ClientCommissionSearchValues
    {
        public DateTime FromDateValue { get; set; }
        public DateTime ToDateValue { get; set; }
        public int AccountNumber { get; set; }
        public string Symbol { get; set; }
        public int BrokerID { get; set; }
        public int BrokerParentID { get; set; }
    }

    public enum ClientCommissionSearchType
    {
        BY_DATE,
        BY_ACCOUNT_NUMBER,
        BY_SYMBOL,
        BY_DATE_ACCOUNT_NUMBER,
        BY_DATE_SYMBOL,
        BY_DATE_ACCOUNT_NUMBER_SYMBOL
    }

    public class StockLevelSearchValues
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ProductType { get; set; }
        public string Symbol { get; set; }
        public int BrokerID { get; set; }
        public int BrokerParentID { get; set; }
    }

    public enum StockLevelSearchType
    {
        BY_DATE,
        BY_PRODUCT_TYPE,
        BY_SYMBOL,
        BY_DATE_PRODUCT_TYPE,
        BY_DATE_SYMBOL,
        BY_DATE_PRODUCT_TYPE_SYMBOL
    }

    public class ClientHoldingSearchValues
    {
        public DateTime TradeDate { get; set; }
        public string ClientName { get; set; }
        public int AccountID { get; set; }
        public string Symbol { get; set; }
        public int BrokerID { get; set; }
        public int BrokerParentID { get; set; }
    }

    public enum ClientHoldingSearchType
    {
        BY_TRADE_DATE,
        BY_CLIENT_NAME,
        BY_SYMBOL,
        BY_ACCOUNT_ID,
        BY_TRADE_DATE_CLIENT_NAME,
        BY_TRADE_DATE_ACCOUNT_ID,
        BY_TRADE_DATE_SYMBOL,
        BY_TRADE_DATE_CLIENT_NAME_ACCOUNT_ID,
        BY_TRADE_DATE_CLIENT_NAME_SYMBOL,
        BY_TRADE_DATE_CLIENT_NAME_ACCOUNT_ID_SYMBOL,
        ALL
    }

    public class MarginSearchValues
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int AccountID { get; set; }
        public int BrokerID { get; set; }
    }

    public enum MarginSearchType
    {
        BY_DATE,
        BY_ACCOUNT_ID,
        BY_BROKER_ID,
        BY_DATE_ACCOUNT_ID,
        BY_DATE_BROKER_ID,
        BY_DATE_ACOUNT_ID_BROKER_ID
    }

    public class AccountTransSearchValues
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int AccountID { get; set; }
        public int BrokerID { get; set; }
        public int BrokerParentID { get; set; }
    }

    public class DayClosingSearchValues
    {
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public int BrokerID { get; set; }
        public int BrokerParentID { get; set; }
    }
}
