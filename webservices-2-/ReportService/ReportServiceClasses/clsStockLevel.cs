using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsStockLevel
    {
        [DataMember]
        public string ProductType { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public Int32 BuyUnit { get; set; }
        [DataMember]
        public Int32 SellUnit { get; set; }
        [DataMember]
        public decimal Capital { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
