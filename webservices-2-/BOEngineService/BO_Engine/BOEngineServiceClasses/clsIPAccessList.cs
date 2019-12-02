using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsIPAccessList
    /// </summary>
    [DataContract]
    public class clsIPAccessList
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FromIP { get; set; }
        [DataMember]
        public string ToIp { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int ServerResponseMsg { get; set; }
    }
}
