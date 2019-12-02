using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsVirtualDealer
    /// </summary>
    [DataContract]
    public class clsVirtualDealerInfo
    {
        [DataMember]
        public int VirtualDealerID { get; set; }
        [DataMember]
        public int Delay { get; set; }
        [DataMember]
        public string VirtualManagerAccount { get; set; }
        [DataMember]
        public string Groups { get; set; }
        [DataMember]
        public string Symbols { get; set; }
        [DataMember]
        public decimal MaximumVolume { get; set; }
        [DataMember]
        public int MaximumLosingSlippage { get; set; }
        [DataMember]
        public int MaximumProfitSlippage { get; set; }
        [DataMember]
        public int MaximumProfitSlippageVolume { get; set; }
        [DataMember]
        public int GapLevel { get; set; }
        [DataMember]
        public int GapSafeLevel { get; set; }
        [DataMember]
        public int GapTickCounter { get; set; }
        [DataMember]
        public int GapPendingCancel { get; set; }
        [DataMember]
        public int GapTakeProfitSlide { get; set; }
        [DataMember]
        public int GapStopLossSlide { get; set; }
        [DataMember]
        public int NewsStopsFreezes { get; set; }
        [DataMember]
        public int AllowPendingsOnNews { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

}
