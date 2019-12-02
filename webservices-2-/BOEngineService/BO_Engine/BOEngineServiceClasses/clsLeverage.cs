using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsLeverage
    /// </summary>
    [DataContract]
    public class clsLeverage
    {
        [DataMember]
        public int LeverageId { get; set; }
        [DataMember]
        public string Leverage { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}