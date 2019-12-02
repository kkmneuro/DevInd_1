using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Account
    {
        public int _AccountId;
        public int _ClientId;
        public int _AccountGroupId;
        public decimal _Balence;
        public decimal _Equity;
        public bool _Deleted;
        public decimal _UsedMargin;
        public int _LeverageId;
        public bool _IsHedgingAllowed;
        public bool _IsTradeEnable;
        public int _CurrencyId;
        public decimal _BuySideTurnOver ;
        public decimal _SellSideTurnOver ;
        public int _RelatedBankId;
        public decimal _PaymentAmount;
        public string _PaymentType;
        public string _PaymentMode;
        public DateTime _PaymentDate;
        public string _LPName;
        public string _LPAccountID;
        public string _ChequeFDNo;
        public int _HedgeTypeID;
        public bool _IsLive;

        public Account()
        {
            _AccountId = 0;
            _ClientId = 0;
            _AccountGroupId = 0;
            _Balence = 0;
            _Equity = 0;
            _Deleted = false;
            _UsedMargin = 0;
            _LeverageId = 0;
            _IsHedgingAllowed = false;
            _IsTradeEnable = false;
            _CurrencyId = 0;
            _BuySideTurnOver = 0;
            _SellSideTurnOver = 0;
            _RelatedBankId = 0;
            _PaymentAmount = 0;
            _PaymentType = string.Empty;
            _PaymentMode = string.Empty;
            _PaymentDate = DateTime.Now;
            _LPName = string.Empty;
            _LPAccountID = string.Empty;
            _ChequeFDNo = string.Empty;
            _HedgeTypeID = 0;
            _IsLive = false;
        }

        public override string ToString()
        {
            return
             "_AccountId->" + _AccountId +
             "_ClientId->" + _ClientId +
             "_AccountGroupId->" + _AccountGroupId +
             "_Balence->" + _Balence +
             "_Equity->" + _Equity +
             "_Deleted->" + _Deleted +
             "_UsedMargin->" + _UsedMargin +
             "_LeverageId->" + _LeverageId +
             "_IsHedgingAllowed->" + _IsHedgingAllowed +
             "_IsTradeEnable->" + _IsTradeEnable +
             "_CurrencyId->" + _CurrencyId +
            "_BuySideTurnOver->" + _BuySideTurnOver +
            "_SellSideTurnOver->" + _SellSideTurnOver +
            "_RelatedBankId->" + _RelatedBankId +
            "_PaymentAmount->" + _PaymentAmount +
            "_PaymentType->" + _PaymentType +
            "_PaymentMode->" + _PaymentMode +
            "_PaymentDate->" + _PaymentDate +
            "_LPName->" + _LPName+
            "_LPAccountID->" + _LPAccountID+
            "_ChequeFDNo->" + _ChequeFDNo;
        }
    }
}
