using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsSecurityType
    /// </summary>
    [DataContract]
    public class clsSecurityType
    {
        [DataMember]
        public int SecurityTypeID { get; set; }
        [DataMember]
        public string SecurityName { get; set; }
        [DataMember]
        public string SecurityDescription { get; set; }
        [DataMember]
        public string Symbols { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }

    }
}