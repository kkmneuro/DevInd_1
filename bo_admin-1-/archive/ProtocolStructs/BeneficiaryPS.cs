using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class BeneficiaryPS : IProtocolStruct
    {
        public Beneficiary _Beneficiary;
        public BeneficiaryPS()
        {
            _Beneficiary = new Beneficiary();
        }
        public BeneficiaryPS(Beneficiary deepCopy)
        {
            _Beneficiary._Address1 = deepCopy._Address1;
            _Beneficiary._Address2 = deepCopy._Address2;
            _Beneficiary._AddressProofImg = deepCopy._AddressProofImg;
            _Beneficiary._BenificiaryId = deepCopy._BenificiaryId;
            _Beneficiary._BirthCity = deepCopy._BirthCity;
            _Beneficiary._BirthCountry = deepCopy._BirthCountry;
            _Beneficiary._City= deepCopy._City;
            _Beneficiary._Country= deepCopy._Country;
            _Beneficiary._DateOfBirth = deepCopy._DateOfBirth;
            _Beneficiary._Email = deepCopy._Email;
            _Beneficiary._Fax = deepCopy._Fax;
            _Beneficiary._FirstName = deepCopy._FirstName;
            _Beneficiary._Gender = deepCopy._Gender;
            _Beneficiary._HomePh = deepCopy._HomePh;
            _Beneficiary._LastName = deepCopy._LastName;
            _Beneficiary._MemberId = deepCopy._MemberId;
            _Beneficiary._MiddleName = deepCopy._MiddleName;
            _Beneficiary._MobilePh = deepCopy._MobilePh;
            _Beneficiary._PassportId = deepCopy._PassportId;
            _Beneficiary._PassportImage = deepCopy._PassportImage;
            _Beneficiary._ResidentNationaltity = deepCopy._ResidentNationaltity;
            _Beneficiary._State = deepCopy._State;
            _Beneficiary._Zip = deepCopy._Zip;
          
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Beneficiary_ID; }
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
            AppendStr(_Beneficiary._Address1);
            AppendStr(_Beneficiary._Address2);
            AppendStr(_Beneficiary._AddressProofImg);
            AppendStr(_Beneficiary._BenificiaryId);
            AppendStr(_Beneficiary._BirthCity);
            AppendStr(_Beneficiary._BirthCountry);
            AppendStr(_Beneficiary._City);
            AppendStr(_Beneficiary._Country);
            AppendStr(_Beneficiary._DateOfBirth);
            AppendStr(_Beneficiary._Email);
            AppendStr(_Beneficiary._Fax);
            AppendStr(_Beneficiary._FirstName);
            AppendStr(_Beneficiary._Gender);
            AppendStr(_Beneficiary._HomePh);
            AppendStr(_Beneficiary._LastName);
            AppendStr(_Beneficiary._MemberId);
            AppendStr(_Beneficiary._MiddleName);
            AppendStr(_Beneficiary._MobilePh);
            AppendStr(_Beneficiary._PassportId);
            AppendStr(_Beneficiary._PassportImage);
            AppendStr(_Beneficiary._ResidentNationaltity);
            AppendStr(_Beneficiary._State);
            AppendStr(_Beneficiary._Zip);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            _Beneficiary._Address1 = SpltString[0];
            _Beneficiary._Address2 = SpltString[1];
            _Beneficiary._AddressProofImg = SpltString[2];
            _Beneficiary._BenificiaryId = clsUtility.GetLong(SpltString[3]);
            _Beneficiary._BirthCity = SpltString[4];
            _Beneficiary._BirthCountry = SpltString[5];
            _Beneficiary._City = SpltString[6];
            _Beneficiary._Country = SpltString[7];
            _Beneficiary._DateOfBirth = clsUtility.GetDate4ProtoStru(SpltString[8]);
            _Beneficiary._Email = SpltString[9];
            _Beneficiary._Fax = SpltString[10];
            _Beneficiary._FirstName = SpltString[11];
            _Beneficiary._Gender = SpltString[12];
            _Beneficiary._HomePh = SpltString[13];
            _Beneficiary._LastName = SpltString[14];
            _Beneficiary._MemberId = clsUtility.GetInt(SpltString[15]);
            _Beneficiary._MiddleName = SpltString[16];
            _Beneficiary._MobilePh = SpltString[17];
            _Beneficiary._PassportId = SpltString[18];
            _Beneficiary._PassportImage = SpltString[19];
            _Beneficiary._ResidentNationaltity = SpltString[20];
            _Beneficiary._State = SpltString[21];
            _Beneficiary._Zip = SpltString[22];

        }
        public override string ToString()
        {
            return _Beneficiary==null?base.ToString():_Beneficiary.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
