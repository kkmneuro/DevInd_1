using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsTimeSettings
    /// </summary>
    [DataContract]
    public class clsTimeSettings
    {
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string TimeSpan { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}