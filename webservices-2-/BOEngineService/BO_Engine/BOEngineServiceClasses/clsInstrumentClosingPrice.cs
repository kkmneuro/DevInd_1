using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    [DataContract]
    public class clsInstrumentClosingPrice
    {
        [DataMember]
        public Int64 PK_InstrumentClosingPrice { get; set; }
        [DataMember]
        public int FK_InstrumentID { get; set; }
        [DataMember]
        public decimal ClosingPrice { get; set; }
        [DataMember]
        public DateTime ClosingDate { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
