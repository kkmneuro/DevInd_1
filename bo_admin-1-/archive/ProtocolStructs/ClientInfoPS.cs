using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class ClientInfoPS : IProtocolStruct
    {

        public ClientInfo _Client;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public ClientInfoPS()
        {
            _Client = new ClientInfo();
        }
        public ClientInfoPS(ClientInfo deepCopy)
        {
            _Client._ClientId = deepCopy._ClientId;
            _Client._FirstName = deepCopy._FirstName;
            _Client._MidleName = deepCopy._MidleName;
            _Client._LastName = deepCopy._LastName;
            _Client._Address1 = deepCopy._Address1;
            _Client._Address2 = deepCopy._Address2;
            _Client._City = deepCopy._City;
            _Client._State = deepCopy._State;
            _Client._Zip = deepCopy._Zip;
            _Client._FaxNumber = deepCopy._FaxNumber;
            _Client._Mobile = deepCopy._Mobile;
            _Client._PassportId = deepCopy._PassportId;
            _Client._SSN = deepCopy._SSN;
            _Client._DOB = deepCopy._DOB;
            _Client._Gender = deepCopy._Gender;
            _Client._Status = deepCopy._Status;
            _Client._Country = deepCopy._Country;
            _Client._FK_CountryID = deepCopy._FK_CountryID;
            _Client._FK_NationalityID = deepCopy._FK_NationalityID;
            _Client._GroupName = deepCopy._GroupName;
            _Client._AccountGroupID = deepCopy._AccountGroupID;
            _Client._FK_ParticipantType = deepCopy._FK_ParticipantType;
            _Client._AccountType = deepCopy._AccountType;
            _Client._FK_AccountTypeID = deepCopy._FK_AccountTypeID;
            _Client._Deleted = deepCopy._Deleted;
            _Client._Balance = deepCopy._Balance;
            _Client._Equity = deepCopy._Equity;
            _Client._MasterPassword = deepCopy._MasterPassword;
            _Client._PrimaryPhone = deepCopy._PrimaryPhone;
            _Client._SecondaryPhone = deepCopy._SecondaryPhone;
            _Client._RegistrationDate = deepCopy._RegistrationDate;
            _Client._PrimaryEmailAddress = deepCopy._PrimaryEmailAddress;
            _Client._SecondaryEmailAddress = deepCopy._SecondaryEmailAddress;
            _Client._PAN = deepCopy._PAN;
            _Client._Age = deepCopy._Age;
            _Client._LoginID = deepCopy._LoginID;
            _Client._TradingPassword = deepCopy._TradingPassword;
            _Client._isExists = deepCopy._isExists;
            _Client._MarkupValue = deepCopy._MarkupValue;
        }


        public override int ID
        {
            get { return ProtocolStructIDS.Client_ID; }

        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void WriteString()
        {
            StartStrW();

            AppendStr(_Client._ClientId);
            AppendStr(_Client._FirstName);
            AppendStr(_Client._MidleName);
            AppendStr(_Client._LastName);
            AppendStr(_Client._Address1);
            AppendStr(_Client._Address2);
            AppendStr(_Client._City);
            AppendStr(_Client._State);
            AppendStr(_Client._Zip);
            AppendStr(_Client._FaxNumber);
            AppendStr(_Client._Mobile);
            AppendStr(_Client._PassportId);
            AppendStr(_Client._SSN);
            AppendStr(_Client._DOB);
            AppendStr(_Client._Gender);
            AppendStr(_Client._Status);
            AppendStr(_Client._Country);
            AppendStr(_Client._FK_CountryID);
            AppendStr(_Client._FK_NationalityID);
            AppendStr(_Client._GroupName);
            AppendStr(_Client._AccountGroupID);
            AppendStr(_Client._FK_ParticipantType);
            AppendStr(_Client._AccountType);
            AppendStr(_Client._FK_AccountTypeID);
            AppendStr(_Client._Deleted);
            AppendStr(_Client._Balance);
            AppendStr(_Client._Equity);
            AppendStr(_Client._MasterPassword);
            AppendStr(_Client._PrimaryPhone);
            AppendStr(_Client._SecondaryPhone);
            AppendStr(_Client._RegistrationDate);
            AppendStr(_Client._PrimaryEmailAddress);
            AppendStr(_Client._SecondaryEmailAddress);
            AppendStr(_Client._PAN);
            AppendStr(_Client._Age);
            AppendStr(_Client._LoginID);
            AppendStr(_Client._TradingPassword);
            AppendStr(_Client._isExists);
            AppendStr(_Client._MarkupValue);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Client._ClientId = clsUtility.GetInt(SpltString[++ind]);
            _Client._FirstName = SpltString[++ind];
            _Client._MidleName = SpltString[++ind];
            _Client._LastName = SpltString[++ind];
            _Client._Address1 = SpltString[++ind];
            _Client._Address2 = SpltString[++ind];
            _Client._City = SpltString[++ind];
            _Client._State = SpltString[++ind];
            _Client._Zip = SpltString[++ind];
            _Client._FaxNumber = SpltString[++ind];
            _Client._Mobile = SpltString[++ind];
            _Client._PassportId = SpltString[++ind];
            _Client._SSN = SpltString[++ind];
            _Client._DOB = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Client._Gender = SpltString[++ind];
            _Client._Status = Convert.ToBoolean(SpltString[++ind]);
            _Client._Country = SpltString[++ind];
            _Client._FK_CountryID = clsUtility.GetInt(SpltString[++ind]);
            _Client._FK_NationalityID = clsUtility.GetInt(SpltString[++ind]);
            _Client._GroupName = SpltString[++ind];
            _Client._AccountGroupID = clsUtility.GetInt(SpltString[++ind]);
            _Client._FK_ParticipantType = clsUtility.GetInt(SpltString[++ind]);
            _Client._AccountType = SpltString[++ind];
            _Client._FK_AccountTypeID = clsUtility.GetInt(SpltString[++ind]);
            _Client._Deleted = Convert.ToBoolean(SpltString[++ind]);
            _Client._Balance = clsUtility.GetDecimal(SpltString[++ind]);
            _Client._Equity = clsUtility.GetDecimal(SpltString[++ind]);
            _Client._MasterPassword = SpltString[++ind];
            _Client._PrimaryPhone = SpltString[++ind];
            _Client._SecondaryPhone = SpltString[++ind];
            _Client._RegistrationDate = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Client._PrimaryEmailAddress = SpltString[++ind];
            _Client._SecondaryEmailAddress = SpltString[++ind];
            _Client._PAN = SpltString[++ind];
            _Client._Age = SpltString[++ind];
            _Client._LoginID = SpltString[++ind];
            _Client._TradingPassword = SpltString[++ind];
            _Client._isExists = Convert.ToBoolean(SpltString[++ind]);
            _Client._MarkupValue = clsUtility.GetDecimal(SpltString[++ind]);

        }
        public override string ToString()
        {

            return _Client == null ? base.ToString() : _Client.ToString();
        }

        public override bool ValidateData()
        {
            //base.ValidateData();


            //Add2Vld("Name", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Client._FirstName.ToString()));
            ////if (_Acc._IndividualId == ProtocolStructIDS.DBInsert)
            ////{
            ////    Add2Vld("Password", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Acc._MasterPassword.ToString()));
            ////    Add2Vld("Password", clsInterface4OME.clsUtil4ProtoVali.ValidateNumberAndCharacter(_Acc._MasterPassword.ToString()));
            ////}
            //Add2Vld("Country", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Client._Country.ToString()));
            //Add2Vld("Status", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Client._Status.ToString()));
            //Add2Vld("Group", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Client._AccountGroupID));

            ////Add2Vld("Color", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(clsUtility.GetStr(_Acc._Color)));
            ////Add2Vld("Leverage", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(clsUtility.GetStr(_Acc._Levarage)));
            //Add2Vld("Email", clsInterface4OME.clsUtil4ProtoVali.ValidateEmail(_Client._PrimaryEmailAddress.ToString()));

            //return IsValidlist();
            return true;
        }
    }
}
