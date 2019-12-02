using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsAccountGroup
    /// </summary>
    [DataContract]
    public class clsAccountGroup
    {
        [DataMember]
        public int AccountGroupID { get; set; }
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public int LeverageId { get; set; }
        [DataMember]
        public decimal Charges { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public int BrokerTypeID { get; set; }
        [DataMember]
        public string BrokerAddress { get; set; }
        [DataMember]
        public string BrokerCity { get; set; }
        [DataMember]
        public string BrokerState { get; set; }
        [DataMember]
        public string BrokerPhone1 { get; set; }
        [DataMember]
        public string BrokerPhone2 { get; set; }
        [DataMember]
        public string BrokerFax { get; set; }
        [DataMember]
        public string BrokerEmail { get; set; }
        [DataMember]
        public int ParentBrokerId { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
