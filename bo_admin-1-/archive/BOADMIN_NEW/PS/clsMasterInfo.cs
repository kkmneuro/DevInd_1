using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class clsMasterInfo
    {
        public List<String> _lstSecurityType;
        public List<String> _lstSettlingCurrency;
        public List<String> _lstMarginCurrency;
        public List<String> _lstDeliveryType;
        public List<String> _lstDeliveryUnit;
        public int _SecurityCount;
        public int _SettlingCurrencyCount;
        public int _MarginCurrecnyCount;
        public int _DeliveryTypeCount;
        public int _DeliveryUnitCount;

        public clsMasterInfo()
        {
            _lstSecurityType = new List<string>();
            _lstSettlingCurrency = new List<string>();
            _lstMarginCurrency = new List<string>();
            _lstDeliveryType = new List<string>();
            _lstDeliveryUnit = new List<string>();
            _SecurityCount = 0;
            _SettlingCurrencyCount = 0;
            _MarginCurrecnyCount = 0;
            _DeliveryTypeCount = 0;
            _DeliveryUnitCount= 0;
        }

        public override string ToString()
        {
            return "_lstSecurityType->" + _lstSecurityType +
                "_lstSettlingCurrency->" + _lstSettlingCurrency +
                "_lstMarginCurrency->" + _lstMarginCurrency +
                "_lstDeliveryType->" + _lstDeliveryType +
                "_lstDeliveryUnit->" + _lstDeliveryUnit+
                "_SecurityCount->" + _lstSecurityType.Count +
                "_SettlingCurrencyCount->" + _lstSettlingCurrency.Count +
                "_MarginCurrecnyCount->" + _lstMarginCurrency.Count +
                "_DeliveryTypeCount->" + _lstDeliveryType.Count +
                "_DeliveryUnitCount->" + _lstDeliveryUnit.Count;
        }
    }
}
