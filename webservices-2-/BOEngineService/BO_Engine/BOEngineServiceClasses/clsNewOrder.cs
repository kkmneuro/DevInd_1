using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{

    [DataContract]
    public class clsNewOrder
    {
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public long PositionSize { get; set; }
        [DataMember]
        public long Price { get; set; }
        [DataMember]
        public char OrderType { get; set; }
        [DataMember]
        public char OrderStatus { get; set; }
        [DataMember]
        public char Side { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public char TIF { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public DateTime ExpireDate { get; set; }
        [DataMember]
        public long OrderID { get; set; }
    }
}
