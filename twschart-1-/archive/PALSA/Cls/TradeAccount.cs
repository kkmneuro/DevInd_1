using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PALSA.Cls
{
    public class TradeAccount
    {
        public Dictionary<int, string> dicCountryList;
        public Dictionary<int, string> dicLeverageList;
        public List<ClientBankInformationResult> lstClientBankInformationResult;
        public string output1;
        public string output2;
        public Dictionary<int, string> GetCountryList()
        {
            return new Dictionary<int, string>();
        }
        public Dictionary<int, string> GetLeverageList()
        {
            return new Dictionary<int, string>();
        }
        public List<ClientBankInformationResult> GetListBankInfo(int a)
        {
            return new List<ClientBankInformationResult>();
        }
        public int InsertBankInfo(string AccountHolderName, string BankAccountID, string BankName, int? BankCountryID, string BankCity, string BankZipCode, string BankAddress1, string BankAddress2, string BankPhone, string BankFax, string BankSwiftCode, int? ParticipantID, string BankAccountType, string BankIFSCode, ref int? BankId)
        {
            return 0;
        }
        public LoginCredent InsertPersonalInfo(PersonalInfo obj)
        {
            LoginCredent objLoginCredent = new LoginCredent();
            return objLoginCredent;
        }

        public class ClientBankInformationResult
        {
            public string _AccountHolderName;
            public string _BankAccountID;
            public string _BankAccountType;
            public string _BankAddress1;
            public string _BankAddress2;
            public string _BankCity;
            public string _BankFax;
            public string _BankIFSCCode;
            public string _BankName;
            public string _BankPhone;
            public string _BankSwiftCode;
            public string _BankZipCode;
            public int? _FK_BankCountryID;
            public int? _FK_ParticipantID;
            public int _PK_BankID;

            
        }
        public class LoginCredent
        {
            public string loginId;
            public string password;
                        
        }
        public class PersonalInfo
        {
            public string Address1;
            public string Address2;
            public string Age;
            public decimal? balanace;
            public int? bankID;
            public decimal? buySideTurnOver;
            public string City;
            public int? ClientId;
            public bool? deleted;
            public DateTime? DOB;
            public decimal? equity;
            public string FaxNumber;
            public string firstName;
            public int? FKAccountGroupID;
            public int? FKAccountTypeID;
            public int? FKCountryID;
            public int? fkleverage;
            public int? FKParticipantType;
            public int? FK_Currency;
            public int? FK_NationalityID;
            public string Gender;
            public int? hedgeTypeID;
            public string IPAccount_ID;
            public string IP_Name;
            public bool? isHeadgingAllowed;
            public bool? IsLive;
            public bool? isTradeEnable;
            public string lastName;
            public decimal? MarkUpValue;
            public string middleName;
            public string Mobile;
            public string PAN;
            public int? participantId;
            public string PassportID;
            public int? PKAccountID;
            public string primaryEmailAddress;
            public string PrimaryPhone;
            public DateTime? registrationDate;
            public string secondaryEmailAddress;
            public string secondaryPhone;
            public decimal? sellSideTurnOver;
            public string SSN;
            public string State;
            public bool? status;
            public decimal? usedMargin;
            public string WhiteLevelName;
            public string Zip;

           
        }
    }
}
