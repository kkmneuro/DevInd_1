using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
     public class FeeMaster
    {
        public int    _PK_FeeID;
        public string _FeeName;
        public int    _MinimumFeeValue;
        public int    _MaximumFeeValue;
        public string _Interval;
        public bool   _IsTaxable;
        public string _Description;

        public FeeMaster()
        {
            _PK_FeeID = 0;
            _FeeName = string.Empty;
            _MinimumFeeValue = 0;
            _MaximumFeeValue = 0;
            _Interval = string.Empty;
            _IsTaxable = false;
            _Description = string.Empty;
        }

        public override string ToString()
        {
            return
            "_PK_FeeID->" + _PK_FeeID +
            "_FeeName->" + _FeeName +
            "_MinimumFeeValue->" + _MinimumFeeValue +
            "_MaximumFeeValue->" + _MaximumFeeValue +
            "_Interval->" + _Interval +
            "_IsTaxable->" + _IsTaxable+
            "_Description ->" +_Description;

         }
    }
}
