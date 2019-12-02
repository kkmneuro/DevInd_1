using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsTGAccountConnectionSettings
    /// </summary>
    [DataContract]
    public class clsTGAccountConnectionSettings
    {
        [DataMember]
        public int TGID { get; set; }
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public int Mode { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

}