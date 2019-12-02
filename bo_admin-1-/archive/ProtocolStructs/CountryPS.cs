using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class CountryPS:IProtocolStruct
    {
        public Country _Country;
        public CountryPS()
        {
            _Country = new Country();
        }
        public CountryPS(Country country)
        {
            _Country._CountryCode = country._CountryCode;
            _Country._CountryId = country._CountryId;
            _Country._CountryName = country._CountryName;
            _Country._Nationality = country._Nationality;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Country_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(_Country._CountryCode);
            AppendStr(_Country._CountryId);
            AppendStr(_Country._CountryName);
            AppendStr(_Country._Nationality);       
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Country._CountryCode = SpltString[++ind];
            _Country._CountryId = clsUtility.GetInt(SpltString[++ind]);
            _Country._CountryName = SpltString[++ind];
            _Country._Nationality = SpltString[++ind];
            

        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return _Country == null ? base.ToString() : _Country.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
