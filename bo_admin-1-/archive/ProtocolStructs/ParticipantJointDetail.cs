using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class ParticipantJointDetail
    {
        public Int64 _JointId;
        public Int64 _ParticipantId;
        public string _Fname;
        public string _Lname;
        public DateTime _CreationDate;
        public DateTime _LastModifiedDate;
        public string _FaxNumber;
        public string _PrimaryEmailAddress;
        public string _Address1;
        public string _Address;
        public string _Country;
        public string _City;
        public string _State;
        public string _Zip;
        public string _Phone;
        public string _Mobile;
        public string _PassportId;
        public string _SSN;
        public DateTime _DOB;
        public string _Gender;
        public string _EmpStatus;
        public string _EmployerName;
        public string _EmpDetails;
        public string _TradeExpInTrade;
        public string _TradeExpInEquity;
        public string _TradeExpInStock;
        public string _SourceofFund;

        public ParticipantJointDetail()
        {
            _JointId = 0;
            _ParticipantId = 0;
            _Fname = string.Empty;
            _Lname = string.Empty;
            _CreationDate = DateTime.Now;
            _LastModifiedDate = DateTime.Now;
            _FaxNumber = string.Empty;
            _PrimaryEmailAddress = string.Empty;
            _Address1 = string.Empty;
            _Address = string.Empty;
            _Country = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Zip = string.Empty;
            _Phone = string.Empty;
            _Mobile = string.Empty;
            _PassportId = string.Empty;
            _SSN = string.Empty;
            _DOB = DateTime.Now;
            _Gender = string.Empty;
            _EmpStatus = string.Empty;
            _EmployerName = string.Empty;
            _EmpDetails = string.Empty;
            _TradeExpInTrade = string.Empty;
            _TradeExpInEquity = string.Empty;
            _TradeExpInStock = string.Empty;
            _SourceofFund = string.Empty;
        }
        public override string ToString()
        {
            return
                "_Address->" + _Address +
                "_Address1->" + _Address1 +
                "_City->" + _City +
                "_Country->" + _Country +
                "_CreationDate->" + _CreationDate +
                "_DOB->" + _DOB +
                "_EmpDetails->" + _EmpDetails +
                "_EmployerName->" + _EmployerName +
                "_EmpStatus->" + _EmpStatus +
                "_FaxNumber->" + _FaxNumber +
                "_Fname->" + _Fname +
                "_Gender->" + _Gender +
                 "_JointId->" + _JointId +
                "_LastModifiedDate->" + _LastModifiedDate +
                "_Lname->" + _Lname +
                "_Mobile->" + _Mobile +
                "_ParticipantId->" + _ParticipantId +
                "_PassportId->" + _PassportId +
                "_Phone->" + _Phone +
                "_PrimaryEmailAddress->" + _PrimaryEmailAddress +
                "_SourceofFund->" + _SourceofFund +
                "_SSN->" + _SSN +
                "_State->" + _State +
                "_TradeExpInEquity->" + _TradeExpInEquity +
                "_TradeExpInStock->" + _TradeExpInStock +
                "_TradeExpInTrade->" + _TradeExpInTrade +
                "_Zip->" + _Zip;

        }

    }
}
