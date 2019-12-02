using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class clsTGAccountConnectionSettingsPS:IProtocolStruct
    {
        public clsTGAccountConnectionSettings _accountConnectionSettings;
        public clsTGAccountConnectionSettingsPS()
        {
            _accountConnectionSettings = new clsTGAccountConnectionSettings();
        }

        public clsTGAccountConnectionSettingsPS(clsTGAccountConnectionSettings deepCopy)
        {
            _accountConnectionSettings._TGID = deepCopy._TGID;
            _accountConnectionSettings._AccountId = deepCopy._AccountId;
            _accountConnectionSettings._Password = deepCopy._Password;
            _accountConnectionSettings._IsEnable = deepCopy._IsEnable;
            _accountConnectionSettings._Mode = deepCopy._Mode;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.TGAccountConnectionSettings_ID; }
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
            AppendStr(_accountConnectionSettings._TGID);
            AppendStr(_accountConnectionSettings._AccountId);
            AppendStr(_accountConnectionSettings._Password);
            AppendStr(_accountConnectionSettings._IsEnable);
            AppendStr(_accountConnectionSettings._Mode);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;
            _accountConnectionSettings._TGID = clsUtility.GetInt(SpltString[++ind]);
            _accountConnectionSettings._AccountId = SpltString[++ind];
            _accountConnectionSettings._Password = SpltString[++ind];
            _accountConnectionSettings._IsEnable =Convert.ToBoolean(SpltString[++ind]);
            _accountConnectionSettings._Mode = clsUtility.GetInt(SpltString[++ind]);
        }
    }
}
