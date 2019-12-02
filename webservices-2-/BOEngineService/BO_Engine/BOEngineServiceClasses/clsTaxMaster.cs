using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsTaxMaster
    /// </summary>
    [DataContract]
    public class clsTaxMaster
    {
        [DataMember]
        public int TaxID { get; set; }
        [DataMember]
        public string TaxName { get; set; }
        [DataMember]
        public decimal TaxPercent { get; set; }
        [DataMember]
        public string Amount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}