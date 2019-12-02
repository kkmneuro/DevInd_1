using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class SecurityPS : IProtocolStruct
    {
        public Security _Security;
        public SecurityPS()
        {
            _Security = new Security();
        }
        public SecurityPS(Security deepCopy)
        {
            _Security._SecurityDescription = deepCopy._SecurityDescription;
            _Security._SecurityName = deepCopy._SecurityName;
            _Security._SecurityTypeID = deepCopy._SecurityTypeID;
            _Security._Symbols = deepCopy._Symbols;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Security_ID; }
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
            AppendStr(_Security._SecurityDescription);
            AppendStr(_Security._SecurityName);
            AppendStr(_Security._SecurityTypeID);
            AppendStr(_Security._Symbols);
           
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            _Security._SecurityDescription = SpltString[0];
            _Security._SecurityName= SpltString[1];
            _Security._SecurityTypeID= clsUtility.GetInt(SpltString[2]);
            _Security._Symbols = SpltString[3];
            
        }
        public override string ToString()
        {

            return _Security==null?base.ToString():_Security.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
