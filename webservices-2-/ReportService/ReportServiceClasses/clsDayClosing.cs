using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsDayClosing
    {
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public DateTime TradeDate { get; set; }
        [DataMember]
        public long Open { get; set; }
        [DataMember]
        public long High { get; set; }
        [DataMember]
        public long Low { get; set; }
        [DataMember]
        public long Close { get; set; }
        [DataMember]
        public long PrevDayClose { get; set; }
        [DataMember]
        public long BuyQty { get; set; }
        [DataMember]
        public long SellQty { get; set; }
        [DataMember]
        public long BuyValue { get; set; }
        [DataMember]
        public long SellValue { get; set; }
        [DataMember]
        public long Buy { get; set; }
        [DataMember]
        public long Sell { get; set; }
        [DataMember]
        public int BrokerId { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
