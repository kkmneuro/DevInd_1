using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsClientHoldingStock
    {
        [DataMember]
        public DateTime TradeDate { get; set; }
        [DataMember]
        public string BrokerCompany { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public Int32 AccountID { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public Int32 BuyQty { get; set; }
        [DataMember]
        public Int32 SellQty { get; set; }
        [DataMember]
        public Int32 BrokerID { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
