using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class RegisterNewUser
    {
        public string _P_PrimaryPhone;
        public string _P_SecondaryPhone;
        public bool _Deleted;
        public int _P_FK_ParticipantType;
        public string _P_FaxNumber;
        public string _P_PrimaryEmailAddress;
        public string _P_SecondaryEmailAddress;
        public bool _P_Active;
        public string _P_ParticipantType;
        public string _P_Fname;
        public string _P_Lname;
        public string _P_Address1;
        public string _P_Address2;
        public string _P_Country;
        public string _P_City;
        public string _P_State;
        public string _P_Zip;
        public string _P_Fax;
        public string _P_Phone;
        public string _P_Mobile;
        public string _P_PassportId;
        public string _P_SSN;
        public string _P_OrganizationId;
        public DateTime _P_DOB;
        public string _P_Gender;
        public bool _P_Status;
        public int _P_AccountTypeId;
        public string _P_Nationality;
        public string _Joint_P_PrimaryPhone;
        public string _Joint_P_SecondaryPhone;
        public bool _Joint_P_Deleted;
        public int _Joint_P_FK_ParticipantType;
        public string _Joint_P_FaxNumber;
        public string _Joint_P_PrimaryEmailAddress;
        public string _Joint_P_SecondaryEmailAddress;
        public bool _Joint_P_Active;
        public string _Joint_P_ParticipantType;
        public string _Joint_P_Fname;
        public string _Joint_P_Lname;
        public string _Joint_P_Address1;
        public string _Joint_P_Address2;
        public string _Joint_P_Country;
        public string _Joint_P_City;
        public string _Joint_P_State;
        public string _Joint_P_Zip;
        public string _Joint_P_Fax;
        public string _Joint_P_Phone;
        public string _Joint_P_Mobile;
        public string _Joint_P_PassportId;
        public string _Joint_P_SSN;
        public string _Joint_P_OrganizationId;
        public DateTime _Joint_P_DOB;
        public string _Joint_P_Gender;
        public bool _Joint_P_Status;
        public int _Joint_P_AccountTypeId;
        public string _Joint_P_Nationality;
        public Int64? _A_AccountId;
        public int _A_FK_AccountType;
        public int _A_AccountGroupId;
        public bool _A_IsEnable;
        public decimal _A_TaxRate;
        public int _A_IBManagerId;
        public string _A_Leverage;
        public string _A_MasterPassword;
        public string _A_InvestorPassword;
        public string _A_PhonePassword;
        public string _E_EmployerName;
        public string _E_CompanyAddress;
        public string _E_Country;
        public string _E_City;
        public string _E_State;
        public string _E_Zip;
        public string _E_Phone;
        public string _E_Fax;
        public string _E_EmployerEmail;
        public string _E_Designation;
        public string _E_Duration;
        public string _E_EmployementType;
        public string _E_RetiredYear;
        public string _E_WorkPhone;
        public string _Joint_E_EmployerName;
        public string _Joint_E_CompanyAddress;
        public string _Joint_E_Country;
        public string _Joint_E_City;
        public string _Joint_E_State;
        public string _Joint_E_Zip;
        public string _Joint_E_Phone;
        public string _Joint_E_Fax;
        public string _Joint_E_EmployerEmail;
        public string _Joint_E_Designation;
        public string _Joint_E_Duration;
        public string _Joint_E_EmployementType;
        public string _Joint_E_RetiredYear;
        public string _Joint_E_WorkPhone;
        public string _F_EstimatedAnnualIncome;
        public string _F_NetWorth;
        public string _F_LiquidNetWorth;
        public string _F_OtherFinancialInfo;
        public string _Joint_F_EstimatedAnnualIncome;
        public string _Joint_F_NetWorth;
        public string _Joint_F_LiquidNetWorth;
        public string _Joint_F_OtherFinancialInfo;
        public string _I_Equities;
        public string _I_Commodities;
        public string _I_Bonds;
        public string _I_ForeignExchange;
        public string _I_RealEstate;
        public string _I_Others;
        public string _Joint_I_Equities;
        public string _Joint_I_Commodities;
        public string _Joint_I_Bonds;
        public string _Joint_I_ForeignExchange;
        public string _Joint_I_RealEstate;
        public string _Joint_I_Others;
        public string _B_AccountHolderName;
        public string _B_BankAccountID;
        public string _B_BankName;
        public string _B_BankCountry;
        public string _B_BankCity;
        public string _B_BankZipCode;
        public string _B_BankAddress;
        public string _B_BankAddress2;
        public string _B_BankPhone;
        public string _B_BankFax;
        public string _B_BankSwiftCode;
        public int _B_ParticipantID;
        public string _B_P_Conuntry;
        public string _B_P_State;
        public string _B_P_City;
        public string _B_P_Zip;
        public string _B_p_Address1;
        public string _B_P_Address2;
        public string _B_ABACode;
        public string _OrganizationId;
        public string _Organization;
        public string _ORCountry;
        public string _ORDate;
        public string _ORAddress1;
        public string _ORAddress2;
        public string _ORCity;
        public string _ORState;
        public string _ORPhone1;
        public string _ORPhone2;
        public string _ORFax;
        public string _OREmail;
        public string _IdentificationID;
        public string _Ben_FirstName;
        public string _Ben_MiddleName;
        public string _Ben_LastName;
        public string _Ben_Gender;
        public string _Ben_Address1;
        public string _Ben_Address2;
        public string _Ben_City;
        public string _Ben_State;
        public int _Ben_Country;
        public string _Ben_Zip;
        public string _Ben_HomePh;
        public string _Ben_MobilePh;
        public string _Ben_Fax;
        public string _Ben_Email;
        public DateTime _Ben_DateOfBirth;
        public string _Ben_BirthCity;
        public string _Ben_BirthCountry;
        public string _Ben_ResidentNationaltity;
        public string _Ben_PassportId;
        public string _Ben_PassportImage;
        public string _Ben_AddressProofImg;
        public string _P_ImgAddress;
        public string _P_ImgPassport;
        public string _Joint_P_ImgAddress;
        public string _Joint_P_ImgPassport;
        public string _A_MarketType;

        public RegisterNewUser()
        {
            _P_PrimaryPhone = string.Empty;
            _P_SecondaryPhone = string.Empty;
            _Deleted = true;
            _P_FK_ParticipantType = 0;
            _P_FaxNumber = string.Empty;
            _P_PrimaryEmailAddress = string.Empty;
            _P_SecondaryEmailAddress = string.Empty;
            _P_Active = true;
            _P_ParticipantType = string.Empty;
            _P_Fname = string.Empty;
            _P_Lname = string.Empty;
            _P_Address1 = string.Empty;
            _P_Address2 = string.Empty;
            _P_Country = string.Empty;
            _P_City = string.Empty;
            _P_State = string.Empty;
            _P_Zip = string.Empty;
            _P_Fax = string.Empty;
            _P_Phone = string.Empty;
            _P_Mobile = string.Empty;
            _P_PassportId = string.Empty;
            _P_SSN = string.Empty;
            _P_OrganizationId = string.Empty;
            _P_DOB = DateTime.Now;
            _P_Gender = string.Empty;
            _P_Status = true;
            _P_AccountTypeId = 0;
            _P_Nationality = string.Empty;
            _Joint_P_PrimaryPhone = string.Empty;
            _Joint_P_SecondaryPhone = string.Empty;
            _Joint_P_Deleted = true;
            _Joint_P_FK_ParticipantType = 0;
            _Joint_P_FaxNumber = string.Empty;
            _Joint_P_PrimaryEmailAddress = string.Empty;
            _Joint_P_SecondaryEmailAddress = string.Empty;
            _Joint_P_Active = true;
            _Joint_P_ParticipantType = string.Empty;
            _Joint_P_Fname = string.Empty;
            _Joint_P_Lname = string.Empty;
            _Joint_P_Address1 = string.Empty;
            _Joint_P_Address2 = string.Empty;
            _Joint_P_Country = string.Empty;
            _Joint_P_City = string.Empty;
            _Joint_P_State = string.Empty;
            _Joint_P_Zip = string.Empty;
            _Joint_P_Fax = string.Empty;
            _Joint_P_Phone = string.Empty;
            _Joint_P_Mobile = string.Empty;
            _Joint_P_PassportId = string.Empty;
            _Joint_P_SSN = string.Empty;
            _Joint_P_OrganizationId = string.Empty;
            _Joint_P_DOB = DateTime.Now;
            _Joint_P_Gender = string.Empty;
            _Joint_P_Status = true;
            _Joint_P_AccountTypeId = 0;
            _Joint_P_Nationality = string.Empty;
            _A_AccountId = 0;
            _A_FK_AccountType = 0;
            _A_AccountGroupId = 0;
            _A_IsEnable = true;
            _A_TaxRate = 0;
            _A_IBManagerId = 0;
            _A_Leverage = string.Empty;
            _A_MasterPassword = string.Empty;
            _A_InvestorPassword = string.Empty;
            _A_PhonePassword = string.Empty;
            _E_EmployerName = string.Empty;
            _E_CompanyAddress = string.Empty;
            _E_Country = string.Empty;
            _E_City = string.Empty;
            _E_State = string.Empty;
            _E_Zip = string.Empty;
            _E_Phone = string.Empty;
            _E_Fax = string.Empty;
            _E_EmployerEmail = string.Empty;
            _E_Designation = string.Empty;
            _E_Duration = string.Empty;
            _E_EmployementType = string.Empty;
            _E_RetiredYear = string.Empty;
            _E_WorkPhone = string.Empty;
            _Joint_E_EmployerName = string.Empty;
            _Joint_E_CompanyAddress = string.Empty;
            _Joint_E_Country = string.Empty;
            _Joint_E_City = string.Empty;
            _Joint_E_State = string.Empty;
            _Joint_E_Zip = string.Empty;
            _Joint_E_Phone = string.Empty;
            _Joint_E_Fax = string.Empty;
            _Joint_E_EmployerEmail = string.Empty;
            _Joint_E_Designation = string.Empty;
            _Joint_E_Duration = string.Empty;
            _Joint_E_EmployementType = string.Empty;
            _Joint_E_RetiredYear = string.Empty;
            _Joint_E_WorkPhone = string.Empty;
            _F_EstimatedAnnualIncome = string.Empty;
            _F_NetWorth = string.Empty;
            _F_LiquidNetWorth = string.Empty;
            _F_OtherFinancialInfo = string.Empty;
            _Joint_F_EstimatedAnnualIncome = string.Empty;
            _Joint_F_NetWorth = string.Empty;
            _Joint_F_LiquidNetWorth = string.Empty;
            _Joint_F_OtherFinancialInfo = string.Empty;
            _I_Equities = string.Empty;
            _I_Commodities = string.Empty;
            _I_Bonds = string.Empty;
            _I_ForeignExchange = string.Empty;
            _I_RealEstate = string.Empty;
            _I_Others = string.Empty;
            _Joint_I_Equities = string.Empty;
            _Joint_I_Commodities = string.Empty;
            _Joint_I_Bonds = string.Empty;
            _Joint_I_ForeignExchange = string.Empty;
            _Joint_I_RealEstate = string.Empty;
            _Joint_I_Others = string.Empty;
            _B_AccountHolderName = string.Empty;
            _B_BankAccountID = string.Empty;
            _B_BankName = string.Empty;
            _B_BankCountry = string.Empty;
            _B_BankCity = string.Empty;
            _B_BankZipCode = string.Empty;
            _B_BankAddress = string.Empty;
            _B_BankAddress2 = string.Empty;
            _B_BankPhone = string.Empty;
            _B_BankFax = string.Empty;
            _B_BankSwiftCode = string.Empty;
            _B_ParticipantID = 0;
            _B_P_Conuntry = string.Empty;
            _B_P_State = string.Empty;
            _B_P_City = string.Empty;
            _B_P_Zip = string.Empty;
            _B_p_Address1 = string.Empty;
            _B_P_Address2 = string.Empty;
            _B_ABACode = string.Empty;
            _OrganizationId = string.Empty;
            _Organization = string.Empty;
            _ORCountry = string.Empty;
            _ORDate = string.Empty;
            _ORAddress1 = string.Empty;
            _ORAddress2 = string.Empty;
            _ORCity = string.Empty;
            _ORState = string.Empty;
            _ORPhone1 = string.Empty;
            _ORPhone2 = string.Empty;
            _ORFax = string.Empty;
            _OREmail = string.Empty;
            _IdentificationID = string.Empty;
            _Ben_FirstName = string.Empty;
            _Ben_MiddleName = string.Empty;
            _Ben_LastName = string.Empty;
            _Ben_Gender = string.Empty;
            _Ben_Address1 = string.Empty;
            _Ben_Address2 = string.Empty;
            _Ben_City = string.Empty;
            _Ben_State = string.Empty;
            _Ben_Country = 0;
            _Ben_Zip = string.Empty;
            _Ben_HomePh = string.Empty;
            _Ben_MobilePh = string.Empty;
            _Ben_Fax = string.Empty;
            _Ben_Email = string.Empty;
            _Ben_DateOfBirth = DateTime.Now;
            _Ben_BirthCity = string.Empty;
            _Ben_BirthCountry = string.Empty;
            _Ben_ResidentNationaltity = string.Empty;
            _Ben_PassportId = string.Empty;
            _Ben_PassportImage = string.Empty;
            _Ben_AddressProofImg = string.Empty;
            _P_ImgAddress = string.Empty;
            _P_ImgPassport = string.Empty;
            _Joint_P_ImgAddress = string.Empty;
            _Joint_P_ImgPassport = string.Empty;
            _A_MarketType = string.Empty;
        }

        public override string ToString()
        {
            return
                "_A_AccountGroupId->" + _A_AccountGroupId +
                "_A_AccountId->" + _A_AccountId +
                "_A_FK_AccountType->" + _A_FK_AccountType +
                "_A_IBManagerId->" + _A_IBManagerId +
                "_A_InvestorPassword->" + _A_InvestorPassword +
                "_A_IsEnable->" + _A_IsEnable +
                "_A_Leverage->" + _A_Leverage +
                "_A_MarketType->" + _A_MarketType +
                "_A_MasterPassword->" + _A_MasterPassword +
                "_A_PhonePassword->" + _A_PhonePassword +
                "_A_TaxRate->" + _A_TaxRate +
                "_B_ABACode->" + _B_ABACode +
                "_B_AccountHolderName->" + _B_AccountHolderName +
                "_B_BankAccountID->" + _B_BankAccountID +
                "_B_BankAddress->" + _B_BankAddress +
                "_B_BankAddress2->" + _B_BankAddress2 +
                "_B_BankCity->" + _B_BankCity +
                "_B_BankCountry->" + _B_BankCountry +
                "_B_BankFax->" + _B_BankFax +
                "_B_BankName->" + _B_BankName +
                "_B_BankPhone->" + _B_BankPhone +
                "_B_BankSwiftCode->" + _B_BankSwiftCode +
                "_B_BankZipCode->" + _B_BankZipCode +
                "_B_p_Address1->" + _B_p_Address1 +
                "_B_P_Address2->" + _B_P_Address2 +
                "_B_P_City->" + _B_P_City +
                "_B_P_Conuntry->" + _B_P_Conuntry +
                "_B_P_State->" + _B_P_State +
                "_B_P_Zip->" + _B_P_Zip +
                "_B_ParticipantID->" + _B_ParticipantID +
                "_Ben_Address1->" + _Ben_Address1 +
                "_Ben_Address2->" + _Ben_Address2 +
                "_Ben_AddressProofImg->" + _Ben_AddressProofImg +
                "_Ben_BirthCity->" + _Ben_BirthCity +
                "_Ben_BirthCountry->" + _Ben_BirthCountry +
                "_Ben_City->" + _Ben_City +
                "_Ben_Country->" + _Ben_Country +
                "_Ben_DateOfBirth->" + _Ben_DateOfBirth +
                "_Ben_Email->" + _Ben_Email +
                "_Ben_Fax->" + _Ben_Fax +
                "_Ben_FirstName->" + _Ben_FirstName +
                "_Ben_Gender->" + _Ben_Gender +
                "_Ben_HomePh->" + _Ben_HomePh +
                "_Ben_LastName->" + _Ben_LastName +
                "_Ben_MiddleName->" + _Ben_MiddleName +
                "_Ben_MobilePh->" + _Ben_MobilePh +
                "_Ben_PassportId->" + _Ben_PassportId +
                "_Ben_PassportImage->" + _Ben_PassportImage +
                "_Ben_ResidentNationaltity->" + _Ben_ResidentNationaltity +
                "_Ben_State->" + _Ben_State +
                "_Ben_Zip->" + _Ben_Zip +
                "_Deleted->" + _Deleted +
                "_E_City->" + _E_City +
                "_E_CompanyAddress->" + _E_CompanyAddress +
                "_E_Country->" + _E_Country +
                "_E_Designation->" + _E_Designation +
                "_E_Duration->" + _E_Duration +
                "_E_EmployementType->" + _E_EmployementType +
                "_E_EmployerEmail->" + _E_EmployerEmail +
                "_E_EmployerName->" + _E_EmployerName +
                "_E_Fax->" + _E_Fax +
                "_E_Phone->" + _E_Phone +
                "_E_RetiredYear->" + _E_RetiredYear +
                "_E_State->" + _E_State +
                "_E_WorkPhone->" + _E_WorkPhone +
                "_E_Zip->" + _E_Zip +
                "_F_EstimatedAnnualIncome->" + _F_EstimatedAnnualIncome +
                "_F_LiquidNetWorth->" + _F_LiquidNetWorth +
                "_F_NetWorth->" + _F_NetWorth +
                "_F_OtherFinancialInfo->" + _F_OtherFinancialInfo +
                "_I_Bonds->" + _I_Bonds +
                "_I_Commodities->" + _I_Commodities +
                "_I_Equities->" + _I_Equities +
                "_I_ForeignExchange->" + _I_ForeignExchange +
                "_I_Others->" + _I_Others +
                "_I_RealEstate->" + _I_RealEstate +
                "_IdentificationID->" + _IdentificationID +
                "_Joint_E_City->" + _Joint_E_City +
                "_Joint_E_CompanyAddress->" + _Joint_E_CompanyAddress +
                "_Joint_E_Country->" + _Joint_E_Country +
                "_Joint_E_Designation->" + _Joint_E_Designation +
                "_Joint_E_Duration->" + _Joint_E_Duration +
                "_Joint_E_EmployementType->" + _Joint_E_EmployementType +
                "_Joint_E_EmployerEmail->" + _Joint_E_EmployerEmail +
                "_Joint_E_EmployerName->" + _Joint_E_EmployerName +
                "_Joint_E_Fax->" + _Joint_E_Fax +
                "_Joint_E_Phone->" + _Joint_E_Phone +
                "_Joint_E_RetiredYear->" + _Joint_E_RetiredYear +
                "_Joint_E_State->" + _Joint_E_State +
                "_Joint_E_WorkPhone->" + _Joint_E_WorkPhone +
                "_Joint_E_Zip->" + _Joint_E_Zip +
                "_Joint_F_EstimatedAnnualIncome->" + _Joint_F_EstimatedAnnualIncome +
                "_Joint_F_LiquidNetWorth->" + _Joint_F_LiquidNetWorth +
                "_Joint_F_NetWorth->" + _Joint_F_NetWorth +
                "_Joint_F_OtherFinancialInfo->" + _Joint_F_OtherFinancialInfo +
                "_Joint_I_Bonds->" + _Joint_I_Bonds +
                "_Joint_I_Commodities->" + _Joint_I_Commodities +
                "_Joint_I_Equities->" + _Joint_I_Equities +
                "_Joint_I_ForeignExchange->" + _Joint_I_ForeignExchange +
                "_Joint_I_Others->" + _Joint_I_Others +
                "_Joint_I_RealEstate->" + _Joint_I_RealEstate +
                "_Joint_P_AccountTypeId->" + _Joint_P_AccountTypeId +
                "_Joint_P_Active->" + _Joint_P_Active +
                "_Joint_P_Address1->" + _Joint_P_Address1 +
                "_Joint_P_Address2->" + _Joint_P_Address2 +
                "_Joint_P_City->" + _Joint_P_City +
                "_Joint_P_Country->" + _Joint_P_Country +
                "_Joint_P_Deleted->" + _Joint_P_Deleted +
                "_Joint_P_DOB->" + _Joint_P_DOB +
                "_Joint_P_Fax->" + _Joint_P_Fax +
                "_Joint_P_FaxNumber->" + _Joint_P_FaxNumber +
                "_Joint_P_FK_ParticipantType->" + _Joint_P_FK_ParticipantType +
                "_Joint_P_Fname->" + _Joint_P_Fname +
                "_Joint_P_Gender->" + _Joint_P_Gender +
                "_Joint_P_ImgAddress->" + _Joint_P_ImgAddress +
                "_Joint_P_ImgPassport->" + _Joint_P_ImgPassport +
                "_Joint_P_Lname->" + _Joint_P_Lname +
                "_Joint_P_Mobile->" + _Joint_P_Mobile +
                "_Joint_P_Nationality->" + _Joint_P_Nationality +
                "_Joint_P_OrganizationId->" + _Joint_P_OrganizationId +
                "_Joint_P_ParticipantType->" + _Joint_P_ParticipantType +
                "_Joint_P_PassportId->" + _Joint_P_PassportId +
                "_Joint_P_Phone->" + _Joint_P_Phone +
                "_Joint_P_PrimaryEmailAddress->" + _Joint_P_PrimaryEmailAddress +
                "_Joint_P_PrimaryPhone->" + _Joint_P_PrimaryPhone +
                "_Joint_P_SecondaryEmailAddress->" + _Joint_P_SecondaryEmailAddress +
                "_Joint_P_SecondaryPhone->" + _Joint_P_SecondaryPhone +
                "_Joint_P_SSN->" + _Joint_P_SSN +
                "_Joint_P_State->" + _Joint_P_State +
                "_Joint_P_Status->" + _Joint_P_Status +
                "_Joint_P_Zip->" + _Joint_P_Zip +
                "_ORAddress1->" + _ORAddress1 +
                "_ORAddress2->" + _ORAddress2 +
                "_ORCity->" + _ORCity +
                "_ORCountry->" + _ORCountry +
                "_ORDate->" + _ORDate +
                "_OREmail->" + _OREmail +
                "_ORFax->" + _ORFax +
                "_Organization->" + _Organization +
                "_OrganizationId->" + _OrganizationId +
                "_ORPhone1->" + _ORPhone1 +
                "_ORPhone2->" + _ORPhone2 +
                "_ORState->" + _ORState +
                "_P_AccountTypeId->" + _P_AccountTypeId +
                "_P_Active->" + _P_Active +
                "_P_Address1->" + _P_Address1 +
                "_P_Address2->" + _P_Address2 +
                "_P_City->" + _P_City +
                "_P_Country->" + _P_Country +
                "_P_DOB->" + _P_DOB +
                "_P_Fax->" + _P_Fax +
                "_P_FaxNumber->" + _P_FaxNumber +
                "_P_FK_ParticipantType->" + _P_FK_ParticipantType +
                "_P_Fname->" + _P_Fname +
                "_P_Gender->" + _P_Gender +
                "_P_ImgAddress->" + _P_ImgAddress +
                "_P_ImgPassport->" + _P_ImgPassport +
                "_P_Lname->" + _P_Lname +
                "_P_Mobile->" + _P_Mobile +
                "_P_Nationality->" + _P_Nationality +
                "_P_OrganizationId->" + _P_OrganizationId +
                "_P_ParticipantType->" + _P_ParticipantType +
                "_P_PassportId->" + _P_PassportId +
                "_P_Phone->" + _P_Phone +
                "_P_PrimaryEmailAddress->" + _P_PrimaryEmailAddress +
                "_P_PrimaryPhone->" + _P_PrimaryPhone +
                "_P_SecondaryEmailAddress->" + _P_SecondaryEmailAddress +
                "_P_SecondaryPhone->" + _P_SecondaryPhone +
                "_P_SSN->" + _P_SSN +
                "_P_State->" + _P_State +
                "_P_Status->" + _P_Status +
                "_P_Zip->" + _P_Zip;
                
        
    }
    }
}