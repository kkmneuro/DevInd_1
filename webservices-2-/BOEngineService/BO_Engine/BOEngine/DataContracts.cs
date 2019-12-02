using System;
using System.Runtime.Serialization;

namespace BOEngine
{

    [DataContract]
    public class clsLogin
    {
        [DataMember]
        public string LoginId { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int BrokerId { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public string BrokerName { get; set; }
        [DataMember]
        public int? BrokerNameID { get; set; }
        [DataMember]
        public string BrokerCompany { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public string ServerResponseMsg { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

    /// <summary>
    /// Summary description for clsTrades
    /// </summary>
    [DataContract]
    public class clsTrades
    {
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int TradeNo { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string SymbolID { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public string OrderPrice { get; set; }
        [DataMember]
        public string TriggerPrice { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime Validity { get; set; }
        [DataMember]
        public string BrokerName { get; set; }
        [DataMember]
        public int Volume { get; set; }
        [DataMember]
        public int FilledQuantity { get; set; }
        [DataMember]
        public int LeaveQuantity { get; set; }
        [DataMember]
        public int AvgFillPrice { get; set; }
        [DataMember]
        public int SettledQty { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

    /// <summary>
    /// Summary description for clsMapOrders
    /// </summary>
    [DataContract]
    public class clsMapOrders
    {
        [DataMember]
        public int MapOrderId { get; set; }
        [DataMember]
        public int BuyAccountID { get; set; }
        [DataMember]
        public int SellAccountID { get; set; }
        [DataMember]
        public Int64 BuySideOrderID { get; set; }
        [DataMember]
        public Int64 SellSideOrderID { get; set; }
        [DataMember]
        public int BuyFillID { get; set; }
        [DataMember]
        public int SellFillID { get; set; }
        [DataMember]
        public int FilledQty { get; set; }
        [DataMember]
        public DateTime LastUpdateTime { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

    /// <summary>
    /// Summary description for clsLoginToDataBase
    /// </summary>
    public class clsLoginToDataBase
    {
        public string LoginId;
        public string Password;
        public int? BrokerId;
        public string Role;
        public string BrokerName_;
        public int? BrokerNameID_;
        public string BrokerCompany;
        public bool? IsEnable;
    }
}