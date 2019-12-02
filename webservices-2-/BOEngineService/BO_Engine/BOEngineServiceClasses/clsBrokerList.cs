using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsBrokerList
    /// </summary>
    [DataContract]
    public class clsBrokerList
    {
        [DataMember]
        public int BrokerTypesID { get; set; }
        [DataMember]
        public string BrokerType { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}