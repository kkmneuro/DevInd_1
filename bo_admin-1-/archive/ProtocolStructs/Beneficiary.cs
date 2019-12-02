using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class Beneficiary
    {
        public Int64 _BenificiaryId;
        public int _MemberId;
        public string _FirstName;
        public string _MiddleName;
        public string _LastName;
        public string _Gender;
        public string _Address1;
        public string _Address2;
        public string _City;
        public string _State;
        public string _Country;
        public string _Zip;
        public string _HomePh;
        public string _MobilePh;
        public string _Fax;
        public string _Email;
        public DateTime _DateOfBirth;
        public string _BirthCity;
        public string _BirthCountry;
        public string _ResidentNationaltity;
        public string _PassportId;
        public string _PassportImage;
        public string _AddressProofImg;
        public Beneficiary()
        {
            _BenificiaryId = 0;
            _MemberId = 0;
            _FirstName = string.Empty;
            _MiddleName = string.Empty;
            _LastName = string.Empty;
            _Gender = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Country = string.Empty;
            _Zip = string.Empty;
            _HomePh = string.Empty;
            _MobilePh = string.Empty;
            _Fax = string.Empty;
            _Email = string.Empty;
            _DateOfBirth =DateTime.Now;
            _BirthCity = string.Empty;
            _BirthCountry = string.Empty;
            _ResidentNationaltity = string.Empty;
            _PassportId = string.Empty;
            _PassportImage = string.Empty;
            _AddressProofImg = string.Empty;
        }
        public override string ToString()
        {
            return
              "_BenificiaryId->" + _BenificiaryId +
        "_MemberId->" + _MemberId +
        "_FirstName->" + _FirstName +
        "_MiddleName->" + _MiddleName +
        "_LastName->" + _LastName +
        "_Gender->" + _Gender +
        "_Address1->" + _Address1 +
        "_Address2->" + _Address2 +
        "_City->" + _City +
        "_State->" + _State +
        "_Country->" + _Country +
        "_Zip->" + _Zip +
        "_HomePh->" + _HomePh +
        "_MobilePh->" + _MobilePh +
        "_Fax->" + _Fax +
        "_Email->" + _Email +
        "_DateOfBirth->" + _DateOfBirth +
        "_BirthCity->" + _BirthCity +
        "_BirthCountry->" + _BirthCountry +
        "_ResidentNationaltity->" + _ResidentNationaltity +
        "_PassportId->" + _PassportId +
        "_PassportImage->" + _PassportImage +
        "_AddressProofImg->" + _AddressProofImg;

    }
    }
}
