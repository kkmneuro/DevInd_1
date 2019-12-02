using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class BrokerLastCollateralTransaction
    {
        public int _AccountGroupId;
        public int _CollateralTypeId;
        public string _CollateralType;
        public decimal _Amount;
        public decimal _TotalAmount;
        public string _TransactionType;
        public string _TransactionDate;
        public bool _IsNewCollateralTrans;
        public BrokerLastCollateralTransaction()
        {
            _AccountGroupId = 0;
            _CollateralTypeId = 0;
            _CollateralType = string.Empty;
            _Amount = 0;
            _TotalAmount = 0;
            _TransactionType = string.Empty;
            _TransactionDate = string.Empty;
            _IsNewCollateralTrans = false;
        }
        public override string ToString()
        {
            return
             "_AccountGroupId->" + _AccountGroupId +
             "_CollateralTypeId->" + _CollateralTypeId +
             "_CollateralType->" + _CollateralType +
             "_Amount->" + _Amount +
             "_TotalAmount->" + _TotalAmount +
             "_TransactionType->" + _TransactionType +
             "_TransactionDate->" + _TransactionDate+
             "_IsNewCollateralTrans->" + _IsNewCollateralTrans;
        }
    }
}
