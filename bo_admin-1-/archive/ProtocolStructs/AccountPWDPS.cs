using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class AccountPWDPS : IProtocolStruct
    {
        public AccountPWD _AccountPWD;
        public AccountPWDPS()
        {
            _AccountPWD = new AccountPWD();
        }
        public AccountPWDPS(AccountPWD deepCopy)
        {
            _AccountPWD._Pwd = deepCopy._Pwd;
            _AccountPWD._AccID = deepCopy._AccID;
            _AccountPWD._Check = deepCopy._Check;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.AccountPWD_ID; }
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
            AppendStr(_AccountPWD._Pwd);
            AppendStr(_AccountPWD._AccID);
            AppendStr(_AccountPWD._Check);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _AccountPWD._Pwd = SpltString[0];
            _AccountPWD._AccID = clsUtility.GetLong(SpltString[1]);
            _AccountPWD._Check = Convert.ToBoolean(SpltString[2]);
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            Add2Vld("Password", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_AccountPWD._Pwd.ToString()));
            return IsValidlist();
        }
    }
}
