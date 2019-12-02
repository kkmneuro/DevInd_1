using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class ParticipantPS :IProtocolStruct
    {
        public Participant _Participant;
        public ParticipantPS()
        {
            _Participant = new Participant();
        }
        public ParticipantPS(Participant deepCopy)
        {
            _Participant._Active = deepCopy._Active;
            _Participant._Address1 = deepCopy._Address1;
            _Participant._Address2 = deepCopy._Address2;
            _Participant._AllowedToChangeTradeConfirmation = deepCopy._AllowedToChangeTradeConfirmation;
            _Participant._City= deepCopy._City;
            _Participant._Country = deepCopy._Country;
            _Participant._CreationDate = deepCopy._CreationDate;
            _Participant._Deleted = deepCopy._Deleted;
            _Participant._DOB = deepCopy._DOB;
            _Participant._Fax = deepCopy._Fax;
            _Participant._FaxNumber = deepCopy._FaxNumber;
            _Participant._FK_ParticipantType = deepCopy._FK_ParticipantType;
            _Participant._Fname = deepCopy._Fname;
            _Participant._Gender= deepCopy._Gender;
            _Participant._IndividualID = deepCopy._IndividualID;
            _Participant._LastModifiedDate = deepCopy._LastModifiedDate;
            _Participant._Lname = deepCopy._Lname;
            _Participant._LoginID = deepCopy._LoginID;
            _Participant._Mobile = deepCopy._Mobile;
            _Participant._OrganizationId = deepCopy._OrganizationId;
            _Participant._ParticipantType = deepCopy._ParticipantType;
            _Participant._PassportId = deepCopy._PassportId;
            _Participant._Phone = deepCopy._Phone;
            _Participant._PrimaryEmailAddress = deepCopy._PrimaryEmailAddress;
            _Participant._PrimaryPhone = deepCopy._PrimaryPhone;
            _Participant._SecondaryEmailAddress = deepCopy._SecondaryEmailAddress;
            _Participant._SecondaryPhone= deepCopy._SecondaryPhone;
            _Participant._SSN= deepCopy._SSN;
            _Participant._State = deepCopy._State;
            _Participant._Status = deepCopy._Status;
            _Participant._Zip = deepCopy._Zip;
            
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Participant_ID ; }
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
            AppendStr(_Participant._Active);
            AppendStr(_Participant._Address1);
            AppendStr(_Participant._Address2);
            AppendStr(_Participant._AllowedToChangeTradeConfirmation);
            AppendStr(_Participant._City);
            AppendStr(_Participant._Country);
            AppendStr(_Participant._CreationDate);
            AppendStr(_Participant._Deleted);
            AppendStr(_Participant._DOB);
            AppendStr(_Participant._Fax);
            AppendStr(_Participant._FaxNumber);
            AppendStr(_Participant._FK_ParticipantType);
            AppendStr(_Participant._Fname);
            AppendStr(_Participant._Gender);
            AppendStr(_Participant._IndividualID);
            AppendStr(_Participant._LastModifiedDate);
            AppendStr(_Participant._Lname);
            AppendStr(_Participant._LoginID);
            AppendStr(_Participant._Mobile);
            AppendStr(_Participant._OrganizationId);
            AppendStr(_Participant._ParticipantType);
            AppendStr(_Participant._PassportId);
            AppendStr(_Participant._Phone);
            AppendStr(_Participant._PrimaryEmailAddress);
            AppendStr(_Participant._PrimaryPhone);
            AppendStr(_Participant._SecondaryEmailAddress);
            AppendStr(_Participant._SecondaryPhone);
            AppendStr(_Participant._SSN);
            AppendStr(_Participant._State);
            AppendStr(_Participant._Status);
            AppendStr(_Participant._Zip);
            
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
             _Participant._Active =Convert.ToBoolean(SpltString[0]);
             _Participant._Address1 = SpltString[1];
             _Participant._Address2 = SpltString[2];
             _Participant._AllowedToChangeTradeConfirmation = Convert.ToBoolean(SpltString[3]);
             _Participant._City = SpltString[4];
             _Participant._Country = SpltString[5];
             _Participant._CreationDate = clsUtility.GetDate4ProtoStru(SpltString[6]);
             _Participant._Deleted = Convert.ToBoolean(SpltString[7]);
             _Participant._DOB = clsUtility.GetDate4ProtoStru(SpltString[8]);
             _Participant._Fax = SpltString[9];
             _Participant._FaxNumber = SpltString[10];
             _Participant._FK_ParticipantType = clsUtility.GetInt(SpltString[11]);
             _Participant._Fname = SpltString[12];
             _Participant._Gender = SpltString[13];
             _Participant._IndividualID = clsUtility.GetLong(SpltString[14]);
             _Participant._LastModifiedDate = clsUtility.GetDate4ProtoStru(SpltString[15]);
             _Participant._Lname = SpltString[16];
             _Participant._LoginID = clsUtility.GetLong(SpltString[17]);
             _Participant._Mobile =SpltString[18];
             _Participant._OrganizationId = SpltString[19];
             _Participant._ParticipantType = SpltString[20];
             _Participant._PassportId = SpltString[21];
             _Participant._Phone = SpltString[22];
             _Participant._PrimaryEmailAddress = SpltString[23];
             _Participant._PrimaryPhone = SpltString[24];
             _Participant._SecondaryEmailAddress = SpltString[25];
             _Participant._SecondaryPhone = SpltString[26];
             _Participant._SSN = SpltString[27];
             _Participant._State = SpltString[28];
             _Participant._Status =Convert.ToBoolean(SpltString[29]);
             _Participant._Zip = SpltString[30];
             

        }
        public override string ToString()
        {

            return _Participant==null?base.ToString():_Participant.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
