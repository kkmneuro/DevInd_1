using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCommonSettings
    /// </summary>
    [DataContract]
    public class clsCommonSettings
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Property { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}