using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class CollateralTypes
    {
        public int _CollateralTypeID;
        public string _CollateralType;
        public CollateralTypes()
        {
            _CollateralTypeID = 0;
            _CollateralType = string.Empty;
        }
        public override string ToString()
        {
            return
             "_CollateralTypeID->" + _CollateralTypeID +
             "_CollateralType->" + _CollateralType;
        }
    }
}
