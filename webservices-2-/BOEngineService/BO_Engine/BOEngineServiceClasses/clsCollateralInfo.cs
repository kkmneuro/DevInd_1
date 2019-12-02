using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCollateralInfo
    /// </summary>
    [DataContract]
    public class clsCollateralInfo
    {
        [DataMember]
        public int AccountGroupID { get; set; }
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string Leverage { get; set; }
        [DataMember]
        public int ParentAccountGroupID { get; set; }
        [DataMember]
        public string ParentOwner { get; set; }
        [DataMember]
        public decimal TotalCollateral { get; set; }
        [DataMember]
        public decimal Unallocated { get; set; }
        [DataMember]
        public decimal Utilized { get; set; }
        [DataMember]
        public decimal PayInShortage { get; set; }
        [DataMember]
        public decimal PayOutShortage { get; set; }
        [DataMember]
        public decimal CollateralforTrading { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public string BrokerType { get; set; }
        [DataMember]
        public int BrokerTypeID { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
