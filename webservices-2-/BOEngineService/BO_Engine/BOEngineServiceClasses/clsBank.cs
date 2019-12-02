using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsBank
    /// </summary>
    [DataContract]
    public class clsBank
    {
        [DataMember]
        public Int32 BankID { get; set; }
        [DataMember]
        public string AccountHolderName { get; set; }
        [DataMember]
        public string BankAccountID { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public int BankCountryID { get; set; }
        [DataMember]
        public string BankCity { get; set; }
        [DataMember]
        public string BankZipCode { get; set; }
        [DataMember]
        public string BankAddress { get; set; }
        [DataMember]
        public string BankAddress2 { get; set; }
        [DataMember]
        public string BankPhone { get; set; }
        [DataMember]
        public string BankFax { get; set; }
        [DataMember]
        public string BankSwiftCode { get; set; }
        [DataMember]
        public Int32 ClientID { get; set; }
        [DataMember]
        public string BankAccountType { get; set; }
        [DataMember]
        public string BankIFSCCode { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

}