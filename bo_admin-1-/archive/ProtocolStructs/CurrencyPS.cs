using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class CurrencyPS:IProtocolStruct
    {
        public Currency _Currency;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public CurrencyPS()
        {
            _Currency = new Currency();
        }
        public CurrencyPS(Currency deepCopy)
        {
            _Currency._Currency_ID = deepCopy._Currency_ID;
            _Currency._CurrencyDescription = deepCopy._CurrencyDescription;
            _Currency._CurrencyName = deepCopy._CurrencyName;
           
        }


        public override int ID
        {
            get { return ProtocolStructIDS.Currency_ID; }
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

            AppendStr(_Currency._Currency_ID);
            AppendStr(_Currency._CurrencyDescription);
            AppendStr(_Currency._CurrencyName);
            
           
            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Currency._Currency_ID = clsUtility.GetInt(SpltString[++ind]);
            _Currency._CurrencyDescription = SpltString[++ind];
            _Currency._CurrencyName = SpltString[++ind];
           
        }
        public override string ToString()
        {
            return _Currency == null ? base.ToString() : _Currency.ToString();
        }

        public override bool ValidateData()
        {
            throw new Exception();
        }
    }
}
