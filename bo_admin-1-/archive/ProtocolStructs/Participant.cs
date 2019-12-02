using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Participant
    {
        public Int64 _IndividualID;
        public string _PrimaryPhone;
        public string _SecondaryPhone;
        public DateTime _CreationDate;
        public DateTime _LastModifiedDate;
        public bool _Deleted;
        public int _FK_ParticipantType;
        public string _FaxNumber;
        public string _PrimaryEmailAddress;
        public string _SecondaryEmailAddress;
        public bool _Active;
        public bool _AllowedToChangeTradeConfirmation;
        public Int64 _LoginID;
        public string _ParticipantType;
        public string _Fname;
        public string _Lname;
        public string _Address1;
        public string _Address2;
        public string _Country;
        public string _City;
        public string _State;
        public string _Zip;
        public string _Fax;
        public string _Phone;
        public string _Mobile;
        public string _PassportId;
        public string _SSN;
        public string _OrganizationId;
        public DateTime _DOB;
        public string _Gender;
        public bool _Status;

        public Participant()
        {
            _IndividualID = 0;
            _PrimaryPhone = string.Empty;
            _SecondaryPhone = string.Empty;
            _CreationDate = DateTime.Now;
            _LastModifiedDate = DateTime.Now;
            _Deleted =true;
            _FK_ParticipantType = 0;
            _FaxNumber = string.Empty;
            _PrimaryEmailAddress = string.Empty;
            _SecondaryEmailAddress = string.Empty;
            _Active = true;
            _AllowedToChangeTradeConfirmation = true;
            _LoginID =0;
            _ParticipantType = string.Empty;
            _Fname = string.Empty;
            _Lname = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _Country = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Zip = string.Empty;
            _Fax = string.Empty;
            _Phone = string.Empty;
            _Mobile = string.Empty;
            _PassportId = string.Empty;
            _SSN = string.Empty;
            _OrganizationId = string.Empty;
            _DOB = DateTime.Now;
            _Gender = string.Empty;
            _Status = true;
        }
        public override string ToString()
        {
            return
                "_Active->" + _Active +
                "_Address1->" + _Address1 +
                "_Address2->" + _Address2 +
                "_AllowedToChangeTradeConfirmation->" + _AllowedToChangeTradeConfirmation +
                "_City->" + _City +
                "_Country->" + _Country +
                "_CreationDate->" + _CreationDate +
                "_Deleted->" + _Deleted +
                "_DOB->" + _DOB +
                "_Fax->" + _Fax +
                "_FaxNumber->" + _FaxNumber +
                "_FK_ParticipantType->" + _FK_ParticipantType +
                "_Fname->" + _Fname +
                 "_Gender->" + _Gender +
                "_IndividualID->" + _IndividualID +
                "_LastModifiedDate->" + _LastModifiedDate +
                "_Lname->" + _Lname +
                "_LoginID->" + _LoginID +
                "_Mobile->" + _Mobile +
                "_OrganizationId->" + _OrganizationId +
                "_ParticipantType->" + _ParticipantType +
                "_PassportId->" + _PassportId +
                "_Phone->" + _Phone +
                "_PrimaryEmailAddress->" + _PrimaryEmailAddress +
                "_PrimaryPhone->" + _PrimaryPhone +
                "_SecondaryEmailAddress->" + _SecondaryEmailAddress +
                "_SecondaryPhone->" + _SecondaryPhone +
                "_SSN->" + _SSN +
                "_State->" + _State +
                 "_Status->" + _Status +
                "_Zip->" + _Zip;
                
        }

    }
}
