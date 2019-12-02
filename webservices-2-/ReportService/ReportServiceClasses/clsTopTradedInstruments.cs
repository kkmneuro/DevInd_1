using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsTopTradedInstruments
    {
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public long CMP { get; set; }
        [DataMember]
        public long Change { get; set; }
        [DataMember]
        public long PercentageChange { get; set; }
        [DataMember]
        public long Volume { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
