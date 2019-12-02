using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCollateralTransInfo
    /// </summary>
    [DataContract]
    public class clsCollateralTransInfo
    {
        [DataMember]
        public int AccountGroupId { get; set; }
        [DataMember]
        public int CollateralTypeId { get; set; }
        [DataMember]
        public string CollateralType { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public string TransactionDate { get; set; }
        [DataMember]
        public bool IsNewCollateralTrans { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

}