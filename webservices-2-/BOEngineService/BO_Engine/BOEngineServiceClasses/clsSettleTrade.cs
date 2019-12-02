using System;
using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsModifyTrades
    /// </summary>
    [DataContract]
    public class clsSettleTrade
    {
        [DataMember]
        public long SettledOrderID { get; set; }       
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public long PositionSize { get; set; }
        [DataMember]
        public long Price { get; set; }
        [DataMember]
        public char OrderType { get; set; }
        [DataMember]
        public char OrderStatusID { get; set; }
        [DataMember]
        public char Side { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public char TIF { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public float UsedMargin { get; set; }
        [DataMember]
        public int CloseQty { get; set; }
        [DataMember]
        public int SettledQty { get; set; }
        [DataMember]
        public int ServerResponseMsg { get; set; }
    }
}
