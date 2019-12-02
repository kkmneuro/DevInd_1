using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class clsCommonSettingsNew
    {
        public int _ID;
        public string _Property;
        public string _Value;

        public clsCommonSettingsNew()
        {
            _ID = 0;
            _Property = string.Empty;
            _Value = string.Empty;
        }

        public override string ToString()
        {
            return
                 "_ID->" + _ID +
            "_Property->" + _Property +
            "_Value->" + _Value;
        }
    }
}