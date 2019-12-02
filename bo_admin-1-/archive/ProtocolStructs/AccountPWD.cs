using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class AccountPWD
    {
        public string _Pwd;

        public long _AccID;

        public bool _Check;
        public AccountPWD()
        {

            _Pwd = string.Empty;
            _AccID = 0;
            _Check = true;

        }
        public override string ToString()
        {
            return

                "_Pwd->" + _Pwd +
                "_AccID->" + _AccID
               + "_Check->" + _Check;
        }

    }
}
