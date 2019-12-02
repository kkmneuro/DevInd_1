using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsFeeMaster
    /// </summary>
    [DataContract]
    public class clsFeeMaster
    {
        [DataMember]
        public int FeeId { get; set; }
        [DataMember]
        public string FeeName { get; set; }
        [DataMember]
        public decimal MinimumFeeValue { get; set; }
        [DataMember]
        public decimal MaximumFeevalue { get; set; }
        [DataMember]
        public string Interval { get; set; }
        [DataMember]
        public bool IsTaxable { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string FeesMode { get; set; }
        [DataMember]
        public string LevyOn { get; set; }
        [DataMember]
        public string Days { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
