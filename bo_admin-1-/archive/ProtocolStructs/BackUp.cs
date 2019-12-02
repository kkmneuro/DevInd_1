using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{

    public class BackUp
    {
        public int _BackUpId;
        public string _Property;
        public string _Value;
        public BackUp()
        {
            _BackUpId = 0;
            _Property = string.Empty;
            _Property = string.Empty;
        }
        public override string ToString()
        {
            return
                "_BackUpId->" + _BackUpId +
         "_Property->" + _Property +
         "_Value->" + _Value;
        }


    }


}
