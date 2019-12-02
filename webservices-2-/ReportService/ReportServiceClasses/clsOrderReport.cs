using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsOrderReport
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
        public Int32 ExecutionQty { get; set; }
        [DataMember]
        public string OrderStatus { get; set; }
        [DataMember]
        public decimal AverageFillPrice { get; set; }
        [DataMember]
        public decimal Commission { get; set; }
        [DataMember]
        public decimal Tax { get; set; }
        [DataMember]
        public string TIF { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
