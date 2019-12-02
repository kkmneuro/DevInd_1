using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsAccount
    /// </summary>
    [DataContract]
    public class clsAccount
    {
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int AccountGroupId { get; set; }
        [DataMember]
        public decimal Balence { get; set; }
        [DataMember]
        public decimal Equity { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
        [DataMember]
        public decimal UsedMargin { get; set; }
        [DataMember]
        public int LeverageId { get; set; }
        [DataMember]
        public bool IsHedgingAllowed { get; set; }
        [DataMember]
        public bool IsTradeEnable { get; set; }
        [DataMember]
        public int CurrencyId { get; set; }
        [DataMember]
        public decimal BuySideTurnOver { get; set; }
        [DataMember]
        public decimal SellSideTurnOver { get; set; }
        [DataMember]
        public int RelatedBankId { get; set; }
        [DataMember]
        public decimal PaymentAmount { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public string LPName { get; set; }
        [DataMember]
        public string LPAccountID { get; set; }
        [DataMember]
        public string ChequeFdNo { get; set; }
        [DataMember]
        public bool IsLive { get; set; }
        [DataMember]
        public int HedgeTypeID { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int EditAccountTransactionID { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

    public enum AccountOpType
    {
        ACCOUNT,
        ACCOUNT_TRANSACTION
    }
}
