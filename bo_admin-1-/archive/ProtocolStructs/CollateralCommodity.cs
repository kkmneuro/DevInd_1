using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class CollateralCommodity
    {
        public int _SecurityTypeID;
        public int _InstruementID;
        public string _Symbol;
        public decimal _LastPrice;
        public DateTime _LastUpdateDate;
        public decimal _Haircut;
        public decimal _MaximunPercent;
        public decimal _UpperValueLimit;

        public CollateralCommodity()
        {
            _SecurityTypeID=0;
            _InstruementID=0;
            _Symbol=string.Empty;
            _LastPrice=0;
            _LastUpdateDate =DateTime.MinValue;
            _Haircut=0;
            _MaximunPercent=0;
            _UpperValueLimit=0;
        
        }

        public override string ToString()
        {
            return
             "_SecurityTypeID->" + _SecurityTypeID +
             "_InstruementID->" + _InstruementID +
             "_Symbol->" + _Symbol +
             "_LastPrice->" + _LastPrice +
             "_LastUpdateDate->" + _LastUpdateDate +
             "_Haircut->" + _Haircut +
             "_MaximunPercent->" + _MaximunPercent +
             "_UpperValueLimit->" + _UpperValueLimit;   
        }
    }
}
