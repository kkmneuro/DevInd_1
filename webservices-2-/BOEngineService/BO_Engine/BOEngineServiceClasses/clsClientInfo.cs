using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsClientInfo
    /// </summary>
    [DataContract]
    public class clsClientInfo
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MidleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string FaxNumber { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string PassportId { get; set; }
        [DataMember]
        public string SSN { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int FKCountryID { get; set; }
        [DataMember]
        public int FKNationalityID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public int AccountGroupID { get; set; }
        [DataMember]
        public int FKParticipantType { get; set; }
        [DataMember]
        public string AccountType { get; set; }
        [DataMember]
        public int FKAccountTypeID { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public decimal Equity { get; set; }
        [DataMember]
        public string MasterPassword { get; set; }
        [DataMember]
        public string TradingPassword { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; }
        [DataMember]
        public string SecondaryPhone { get; set; }
        [DataMember]
        public DateTime RegistrationDate { get; set; }
        [DataMember]
        public string PrimaryEmailAddress { get; set; }
        [DataMember]
        public string SecondaryEmailAddress { get; set; }
        [DataMember]
        public string PAN { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public bool IsExists { get; set; }
        [DataMember]
        public decimal MarkupValue { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
