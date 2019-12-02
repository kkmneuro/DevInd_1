using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class ParticipantJointDetailPS :IProtocolStruct
    {
        public ParticipantJointDetail _ParticipantJointDetail;
        public ParticipantJointDetailPS()
        {
            _ParticipantJointDetail = new ParticipantJointDetail();
        }
        public ParticipantJointDetailPS(ParticipantJointDetail deepCopy)
        {
            _ParticipantJointDetail._Address = deepCopy._Address;
            _ParticipantJointDetail._Address1 = deepCopy._Address1;
            _ParticipantJointDetail._City = deepCopy._City;
            _ParticipantJointDetail._Country = deepCopy._Country;
            _ParticipantJointDetail._CreationDate= deepCopy._CreationDate;
            _ParticipantJointDetail._DOB = deepCopy._DOB;
            _ParticipantJointDetail._EmpDetails = deepCopy._EmpDetails;
            _ParticipantJointDetail._EmployerName= deepCopy._EmployerName;
            _ParticipantJointDetail._EmpStatus = deepCopy._EmpStatus;
            _ParticipantJointDetail._FaxNumber = deepCopy._FaxNumber;
            _ParticipantJointDetail._Fname = deepCopy._Fname;
            _ParticipantJointDetail._Gender = deepCopy._Gender;
            _ParticipantJointDetail._JointId = deepCopy._JointId;
            _ParticipantJointDetail._LastModifiedDate= deepCopy._LastModifiedDate;
            _ParticipantJointDetail._Lname = deepCopy._Lname;
            _ParticipantJointDetail._Mobile = deepCopy._Mobile;
            _ParticipantJointDetail._ParticipantId = deepCopy._ParticipantId;
            _ParticipantJointDetail._PassportId = deepCopy._PassportId;
            _ParticipantJointDetail._Phone = deepCopy._Phone;
            _ParticipantJointDetail._PrimaryEmailAddress = deepCopy._PrimaryEmailAddress;
            _ParticipantJointDetail._SourceofFund = deepCopy._SourceofFund;
            _ParticipantJointDetail._SSN = deepCopy._SSN;
            _ParticipantJointDetail._State = deepCopy._State;
            _ParticipantJointDetail._TradeExpInEquity = deepCopy._TradeExpInEquity;
            _ParticipantJointDetail._TradeExpInStock = deepCopy._TradeExpInStock;
            _ParticipantJointDetail._TradeExpInTrade= deepCopy._TradeExpInTrade;
            _ParticipantJointDetail._Zip= deepCopy._Zip;
           
            
        }
        public override int ID
        {
            get { return ProtocolStructIDS.ParticipantJointDetail_ID ; }
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
            AppendStr(_ParticipantJointDetail._Address);
            AppendStr(_ParticipantJointDetail._Address1);
            AppendStr(_ParticipantJointDetail._City);
            AppendStr(_ParticipantJointDetail._Country);
            AppendStr(_ParticipantJointDetail._CreationDate);
            AppendStr(_ParticipantJointDetail._DOB);
            AppendStr(_ParticipantJointDetail._EmpDetails);
            AppendStr(_ParticipantJointDetail._EmployerName);
            AppendStr(_ParticipantJointDetail._EmpStatus);
            AppendStr(_ParticipantJointDetail._FaxNumber);
            AppendStr(_ParticipantJointDetail._Fname);
            AppendStr(_ParticipantJointDetail._Gender);
            AppendStr(_ParticipantJointDetail._JointId);
            AppendStr(_ParticipantJointDetail._LastModifiedDate);
            AppendStr(_ParticipantJointDetail._Lname);
            AppendStr(_ParticipantJointDetail._Mobile);
            AppendStr(_ParticipantJointDetail._ParticipantId);
            AppendStr(_ParticipantJointDetail._PassportId);
            AppendStr(_ParticipantJointDetail._Phone);
            AppendStr(_ParticipantJointDetail._PrimaryEmailAddress);
            AppendStr(_ParticipantJointDetail._SourceofFund);
            AppendStr(_ParticipantJointDetail._SSN);
            AppendStr(_ParticipantJointDetail._State);
            AppendStr(_ParticipantJointDetail._TradeExpInEquity);
            AppendStr(_ParticipantJointDetail._TradeExpInStock);
            AppendStr(_ParticipantJointDetail._TradeExpInTrade);
            AppendStr(_ParticipantJointDetail._Zip);
            AppendStr(_ParticipantJointDetail._SSN);
            
            
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
             _ParticipantJointDetail._Address =SpltString[0];
             _ParticipantJointDetail._Address1 = SpltString[1];
             _ParticipantJointDetail._City = SpltString[2];
             _ParticipantJointDetail._Country = SpltString[3];
             _ParticipantJointDetail._CreationDate = clsUtility.GetDate4ProtoStru(SpltString[4]);
             _ParticipantJointDetail._DOB = clsUtility.GetDate4ProtoStru(SpltString[5]);
             _ParticipantJointDetail._EmpDetails = SpltString[6];
             _ParticipantJointDetail._EmployerName= SpltString[7];
             _ParticipantJointDetail._EmpStatus = SpltString[8];
             _ParticipantJointDetail._FaxNumber = SpltString[9];
             _ParticipantJointDetail._Fname = SpltString[10];
             _ParticipantJointDetail._Gender = SpltString[11];
             _ParticipantJointDetail._JointId = clsUtility.GetLong(SpltString[12]);
             _ParticipantJointDetail._LastModifiedDate = clsUtility.GetDate4ProtoStru(SpltString[13]);
             _ParticipantJointDetail._Lname = SpltString[14];
             _ParticipantJointDetail._Mobile = SpltString[15];
             _ParticipantJointDetail._ParticipantId = clsUtility.GetLong(SpltString[16]);
             _ParticipantJointDetail._PassportId = SpltString[17];
             _ParticipantJointDetail._Phone =SpltString[18];
             _ParticipantJointDetail._PrimaryEmailAddress = SpltString[19];
             _ParticipantJointDetail._SourceofFund = SpltString[20];
             _ParticipantJointDetail._SSN = SpltString[21];
             _ParticipantJointDetail._State = SpltString[22];
             _ParticipantJointDetail._TradeExpInEquity = SpltString[23];
             _ParticipantJointDetail._TradeExpInStock = SpltString[24];
             _ParticipantJointDetail._TradeExpInTrade = SpltString[25];
             _ParticipantJointDetail._Zip = SpltString[26];
        
             
             

        }
        public override string ToString()
        {

            return _ParticipantJointDetail==null?base.ToString():_ParticipantJointDetail.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
