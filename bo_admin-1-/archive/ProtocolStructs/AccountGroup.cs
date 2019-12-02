using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class AccountGroup
    {
        public int _AccountGroupID;
        public string _AccountGroupName;
        public string _Owner;
        public int _LeverageId;
        public decimal _Charges;
        public bool _IsEnable;
        public int _BrokerTypeID;
        public string _BrokerAddress;
        public string _BrokerCity;
        public string _BrokerState;
        public string _BrokerPhone1;
        public string _BrokerPhone2;
        public string _BrokerFax;
        public string _BrokerEmail;
        public AccountGroup()
        {
            _AccountGroupID = 0;
            _AccountGroupName = string.Empty;
            _Owner = string.Empty;
            _LeverageId = 0;
            _Charges = 0;
            _IsEnable = false;
            _BrokerTypeID = 0;
            _BrokerAddress = string.Empty;
            _BrokerCity = string.Empty;
            _BrokerState = string.Empty;
            _BrokerPhone1 = string.Empty;
            _BrokerPhone2 = string.Empty;
            _BrokerFax = string.Empty;
            _BrokerEmail = string.Empty;

        }
        public override string ToString()
        {
            return
             "_AccountGroupID->" + _AccountGroupID +
             "_AccountGroupName->" + _AccountGroupName +
             "_Owner->" + _Owner +
             "_LeverageId->" + _LeverageId +
             "_Charges->" + _Charges +
             "_IsEnable->" + _IsEnable +
             "_BrokerTypeID->" + _BrokerTypeID +
             "_BrokerAddress->" + _BrokerAddress +
             "_BrokerCity->" + _BrokerCity +
             "_BrokerState->" + _BrokerState +
             "_BrokerPhone1->" + _BrokerPhone1 +
             "_BrokerPhone2->" + _BrokerPhone2 +
             "_BrokerFax->" + _BrokerFax +
             "_BrokerEmail->" + _BrokerEmail;
        }


    }
}
