using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsModifyTrades
    /// </summary>
    [DataContract]
    public class clsModifyTrades
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public decimal LastPrice { get; set; }
        [DataMember]
        public int ServerResponseMsg { get; set; }
    }
}
