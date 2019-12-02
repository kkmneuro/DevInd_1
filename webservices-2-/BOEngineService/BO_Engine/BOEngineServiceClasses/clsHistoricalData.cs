using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    [DataContract]
    public class clsHistoricalData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string SymbolName { get; set; }
        [DataMember]
        public DateTime FeedTime { get; set; }
        [DataMember]
        public double Open { get; set; }
        [DataMember]
        public double High { get; set; }
        [DataMember]
        public double Low { get; set; }
        [DataMember]
        public double Close { get; set; }
        [DataMember]
        public long Volume { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
