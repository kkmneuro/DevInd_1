using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class clsTGAccountConnectionSettings
    {
        public int _TGID;
        public string _AccountId;
        public string _Password;
        public bool _IsEnable;
        public int _Mode;

        public clsTGAccountConnectionSettings()
        {
            _TGID = 0;
            _AccountId = string.Empty;
            _Password = string.Empty;
            _IsEnable = false;
            _Mode = 0;
        }

        public override string ToString()
        {
            return "_TGID->" + _TGID + 
            "_AccountId->" + _AccountId +
            "_Password->" + _Password +
            "_IsEnable->" + _IsEnable+
            "_Mode->" + _Mode;
        }
    }
}
