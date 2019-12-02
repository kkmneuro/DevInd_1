using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class Bank
    {
        public Int32 _BankID;
        public string _AccountHolderName;
        public string _BankAccountID;
        public string _BankName;
        public int _BankCountryID;
        public string _BankCity;
        public string _BankZipCode;
        public string _BankAddress;
        public string _BankAddress2;
        public string _BankPhone;
        public string _BankFax;
        public string _BankSwiftCode;
        public Int32 _ClientID;
        public string _BankAccountType;
        public string _BankIFSCCode;
        public Bank()
        {
            _BankID = 0;
            _AccountHolderName = string.Empty;
            _BankAccountID = string.Empty;
            _BankName = string.Empty;
            _BankCountryID = 0;
            _BankCity = string.Empty;
            _BankZipCode = string.Empty;
            _BankAddress = string.Empty;
            _BankAddress2 = string.Empty;
            _BankPhone = string.Empty;
            _BankFax = string.Empty;
            _BankSwiftCode = string.Empty;
            _ClientID = 0;
            _BankAccountType = string.Empty;
            _BankIFSCCode = string.Empty;

        }
        public override string ToString()
        {
            return
              "_BankID->" + _BankID +
            "_AccountHolderName->" + _AccountHolderName +
            "_BankAccountID->" + _BankAccountID +
            "_BankName->" + _BankName +
            "_BankCountry->" + _BankCountryID +
            "_BankCity->" + _BankCity +
            "_BankZipCode->" + _BankZipCode +
           "_BankAddress->" + _BankAddress +
           "_BankAddress2->" + _BankAddress2 +
            "_BankPhone->" + _BankPhone +
           "_BankFax->" + _BankFax +
            "_BankSwiftCode->" + _BankSwiftCode +
            "_ParticipantID->" + _ClientID +
           "_P_Conuntry->" + _BankAccountType +
            "_P_State->" + _BankIFSCCode;

        }
    }
}
