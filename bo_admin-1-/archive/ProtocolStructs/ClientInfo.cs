using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class ClientInfo
    {
        #region "     OBSOLETE      "
        //public Int64 _IndividualId;
        //public Int64 _AccountId;
        //public string _GroupName;
        //public int _FK_AccountType;
        //public decimal _UsableUSDollarCredit;
        //public int _FK_PriceGroupType;
        //public bool _Deleted;
        //public decimal _Balance;
        //public decimal _Equity;
        //public decimal _UsedMargin;
        //public decimal _UsableCredit;
        //public string _Levarage;
        //public int _UsableCapital;
        //public long _AccountGroupID;
        //public string _Comment;
        //public bool _IsEnable;
        //public decimal _TaxRate;
        //public int _IBManagerID;
        //public DateTime _CreateDate;
        //public DateTime _ModifiedDate;
        //public string _MasterPassword;
        //public string _InvestorPassword;
        //public bool _Ismaster;
        //public string _PhonePassword;
        //public string _Color;
        //public string _Group;
        //public string _Currency;
        //public bool _IsAllowToChangePassword;
        //public bool _IsReadOnly;
        //public bool _IsSendReport;
        //public string _PrimaryPhone;
        //public string _SecondaryPhone;
        //public DateTime _CreationDate;
        //public DateTime _LastModifiedDate;
        //public int _FK_ParticipantType;
        //public string _FaxNumber;
        //public string _PrimaryEmailAddress;
        //public string _SecondaryEmailAddress;
        //public bool _Active;
        //public bool _AllowedToChangeTradeConfirmation;
        //public Int64 _LoginID;
        //public string _ParticipantType;
        //public string _Fname;
        //public string _Lname;
        //public string _Address1;
        //public string _Address2;
        //public string _Country;
        //public string _City;
        //public string _State;
        //public string _Zip;
        //public string _Fax;
        //public string _Phone;
        //public string _Mobile;
        //public string _PassportId;
        //public string _SSN;
        //public string _OrganizationId;
        //public DateTime _DOB;
        //public string _Gender;
        //public bool _Status;
        //public Int64 _AgentAccount;
        #endregion

        public int _ClientId;
        public string _FirstName;
        public string _MidleName;
        public string _LastName;
        public string _Address1;
        public string _Address2;
        public string _City;
        public string _State;
        public string _Zip;
        public string _FaxNumber;
        public string _Mobile;
        public string _PassportId;
        public string _SSN;
        public DateTime _DOB;
        public string _Gender;
        public bool _Status;
        public string _Country;
        public int _FK_CountryID;
        public int _FK_NationalityID;
        public string _GroupName;
        public int _AccountGroupID;
        public int _FK_ParticipantType;
        public string _AccountType;
        public int _FK_AccountTypeID;
        public bool _Deleted;
        public decimal _Balance;
        public decimal _Equity;
        public string _MasterPassword;
        public string _TradingPassword;
        public string _PrimaryPhone;
        public string _SecondaryPhone;
        public DateTime _RegistrationDate;
        public string _PrimaryEmailAddress;
        public string _SecondaryEmailAddress;
        public string _PAN;
        public string _Age;
        public string _LoginID;
        public bool _isExists;
        public decimal _MarkupValue; 

        public ClientInfo()
        {
            _ClientId = 0;
            _FirstName = string.Empty;
            _MidleName = string.Empty;
            _LastName = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Zip = string.Empty;
            _FaxNumber = string.Empty;
            _Mobile = string.Empty;
            _PassportId = string.Empty;
            _SSN = string.Empty;
            _DOB = DateTime.Today;
            _Gender = string.Empty;
            _Status = false;
            _Country = string.Empty;
            _FK_CountryID = 0;
            _FK_NationalityID = 0;
            _GroupName = string.Empty;
            _AccountGroupID = 0;
            _FK_ParticipantType = 0;
            _AccountType = string.Empty;
            _FK_AccountTypeID = 0;
            _Deleted = false;
            _Balance = 0;
            _Equity = 0;
            _MasterPassword = string.Empty;
            _PrimaryPhone = string.Empty;
            _SecondaryPhone = string.Empty;
            _RegistrationDate = DateTime.Today;
            _PrimaryEmailAddress = string.Empty;
            _SecondaryEmailAddress = string.Empty;
            _PAN = string.Empty;
            _Age = string.Empty;
            _LoginID = string.Empty;
            _isExists = false;
            _MarkupValue = 0;
        }
        public override string ToString()
        {
            return

             "_ClientId->" + _ClientId +
             "_FirstName->" + _FirstName +
             "_MidleName->" + _MidleName +
             "_LastName->" + _LastName +
             "_Address1->" + _Address1 +
             "_Address2->" + _Address2 +
             "_City->" + _City +
             "_State->" + _State +
             "_Zip->" + _Zip +
             "_FaxNumber->" + _FaxNumber +
             "_Mobile->" + _Mobile +
             "_PassportId->" + _PassportId +
             "_SSN->" + _SSN +
             "_DOB->" + _DOB +
             "_Gender->" + _Gender +
             "_Status->" + _Status +
             "_Country->" + _Country +
             "_FK_CountryID->" + _FK_CountryID +
             "_FK_NationalityID->" + _FK_NationalityID +
             "_GroupName->" + _GroupName +
             "_AccountGroupID->" + _AccountGroupID +
             "_FK_ParticipantType->" + _FK_ParticipantType +
             "_AccountType->" + _AccountType +
             "_FK_AccountTypeID->" + _FK_AccountTypeID +
             "_Deleted->" + _Deleted +
             "_Balance->" + _Balance +
             "_Equity->" + _Equity +
             "_MasterPassword->" + _MasterPassword +
             "_PrimaryPhone->" + _PrimaryPhone +
             "_SecondaryPhone->" + _SecondaryPhone +
             "_RegistrationDate->" + _RegistrationDate +
             "_PrimaryEmailAddress->" + _PrimaryEmailAddress +
             "_SecondaryEmailAddress->" + _SecondaryEmailAddress +
             "_PAN->" + _PAN +
             "_Age->" + _Age +
             "_LoginID->" + _LoginID +
            "_isExists->" + _isExists+
            "_MarkupValue->" + _MarkupValue;
        }
    }
}
