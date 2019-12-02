using System;
using System.Collections.Generic;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsTradeReport
    {
        [DataMember]
        public int BrokerID { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public Int64 OrderNumber { get; set; }
        [DataMember]
        public DateTime OrderDateTime { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public string Side { get; set; }
        [DataMember]
        public Int64 Lot { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public Int64 Price { get; set; }
        [DataMember]
        public DateTime TradeTime { get; set; }
        [DataMember]
        public decimal TradePrice { get; set; }
        [DataMember]
        public Int64 TradeNumber { get; set; }
        [DataMember]
        public string BrokerType { get; set; }
        [DataMember]
        public string ITCM { get; set; }
        [DataMember]
        public string TCM { get; set; }
        [DataMember]
        public string TM { get; set; }
        [DataMember]
        public string STM { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
        [DataMember]
        public decimal profitValue { get; set; }
        [DataMember]
        public decimal commission { get; set; }
        
    }
}
