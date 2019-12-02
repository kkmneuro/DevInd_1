using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class BrokerCollateralInfo
    {
        public int _AccountGroupID;
        public string _AccountGroupName;
        public string _Owner;
        public string _Leverage;
        public int _ParentAccountGroupID;
        public string _ParentOwner;
        public decimal _TotalCollateral;
        public decimal _Unallocated;
        public decimal _Utilized;
        public decimal _PayInShortage;
        public decimal _PayOutShortage;
        public decimal _CollateralforTrading;
        public bool _IsEnable;
        public string _BrokerType;
        public int _BrokerTypeID;
        public BrokerCollateralInfo()
        {
            _AccountGroupID = 0;
            _AccountGroupName = string.Empty;
            _Owner = string.Empty;
            _Leverage = string.Empty;
            _ParentAccountGroupID = 0;
            _ParentOwner = string.Empty;
            _TotalCollateral = 0;
            _Unallocated = 0;
            _Utilized = 0;
            _PayInShortage = 0;
            _PayOutShortage = 0;
            _CollateralforTrading = 0;
            _IsEnable = false;
            _BrokerType = string.Empty;
            _BrokerTypeID = 0;
        }
        public override string ToString()
        {
            return
             "_AccountGroupID->" + _AccountGroupID +
             "_AccountGroupName->" + _AccountGroupName +
             "_Owner->" + _Owner +
             "_Leverage->" + _Leverage +
             "_ParentAccountGroupID->" + _ParentAccountGroupID +
             "_ParentOwner->" + _ParentOwner +
             "_TotalCollateral->" + _TotalCollateral +
             "_Unallocated->" + _Unallocated +
             "_Utilized->" + _Utilized +
             "_PayInShortage->" + _PayInShortage +
            "_PayOutShortage->" + _PayOutShortage +
            "_CollateralforTrading->" + _CollateralforTrading +
            "_IsEnable->" + _IsEnable +
            "_BrokerType->" + _BrokerType +
            "_BrokerTypeID->" + _BrokerTypeID;
        }
    }
}
