using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Country
    {
        public Int32 _CountryId;
        public string _CountryName;
        public string _Nationality;
        public string _CountryCode;
        public Country()
        {
            _CountryId = 0;
            _CountryName = string.Empty;
            _Nationality = string.Empty;
            _CountryCode = string.Empty;

        }
        public override string ToString()
        {
            return

             "_CountryCode->" + _CountryCode +
             "_CountryId->" + _CountryId +
             "_CountryName->" + _CountryName +
             "_Nationality->" + _Nationality;
        }   
    }
}
