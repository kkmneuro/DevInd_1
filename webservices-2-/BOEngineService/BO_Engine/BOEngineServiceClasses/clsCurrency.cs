using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCurrency
    /// </summary>
    [DataContract]
    public class clsCurrency
    {
        [DataMember]
        public int Currency_ID { get; set; }
        [DataMember]
        public string CurrencyName { get; set; }
        [DataMember]
        public string CurrencyDescription { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}