using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class Security
    {
        public int _SecurityTypeID;
        public string _SecurityName;
        public string _SecurityDescription;
        public string _Symbols;

        public Security()
        {
            _SecurityTypeID = 0;
            _SecurityName = string.Empty;
            _SecurityDescription = string.Empty;
            _Symbols = string.Empty;
        }
        public override string ToString()
        {
            return
            "_SecurityTypeID->" + _SecurityTypeID +
            "_SecurityName->" + _SecurityName +
            "_SecurityDescription->" + _SecurityDescription +
            "_Symbols->" + _Symbols;
        }

    }
}
