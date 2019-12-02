using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Common
    {
        public int _CommonId;
        public string _Property;
        public string _Value;
        public Common()
        {
            _CommonId = 0;
            _Property = string.Empty;
            _Value = string.Empty;

        }
        public override string ToString()
        {
            return
                "_CommonId->" + _CommonId +
                "_Property->" + _Property +
                "_Value->" + _Value;
        }
    }
}
