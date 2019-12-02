using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsClientCommission
    {
        [DataMember]
        public int BrokerID { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public DateTime TradeDate { get; set; }
        [DataMember]
        public Int32 BuyQty { get; set; }
        [DataMember]
        public double BuyValue { get; set; }
        [DataMember]
        public double BuyAvg { get; set; }
        [DataMember]
        public Int32 SellQty { get; set; }
        [DataMember]
        public double SellValue { get; set; }
        [DataMember]
        public double SellAvg { get; set; }
        [DataMember]
        public Int32 SettledQty { get; set; }
        [DataMember]
        public Int32 NetQty { get; set; }
        [DataMember]
        public long ClosingPrice { get; set; }
        [DataMember]
        public decimal Commission { get; set; }
        [DataMember]
        public decimal VatOnCommission { get; set; }
        [DataMember]
        public decimal CommissionVatTotal { get; set; }
        [DataMember]
        public decimal GrossPL { get; set; }
        [DataMember]
        public decimal NetPL { get; set; }
        [DataMember]
        public double M2M { get; set; }
        [DataMember]
        public double GrossM2M { get; set; }
        [DataMember]
        public decimal UsedMargin { get; set; }
        [DataMember]
        public decimal NetValue { get; set; }
        [DataMember]
        public decimal NetAvgPrice { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }

    }
}
