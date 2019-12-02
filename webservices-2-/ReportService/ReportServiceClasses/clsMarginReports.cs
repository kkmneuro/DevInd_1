using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsMarginReports
    {
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public string CACode { get; set; }
        [DataMember]
        public string TCM { get; set; }
        [DataMember]
        public string TM { get; set; }
        [DataMember]
        public string STM { get; set; }
        [DataMember]
        public string ClientCode { get; set; }
        [DataMember]
        public long OpeningBalance { get; set; }
        [DataMember]
        public decimal UsedMargin { get; set; }
        [DataMember]
        public decimal FreeMargin { get; set; }
        [DataMember]
        public double SettledProfitLoss { get; set; }
        [DataMember]
        public double FloatingProfitLoss { get; set; }
        [DataMember]
        public double CommVatTotal { get; set; }
        [DataMember]
        public decimal NetMtm { get; set; }
        [DataMember]
        public Int64 Equity { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
