using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsModule
    /// </summary>
    [DataContract]
    public class clsModule
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public string ModName { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}