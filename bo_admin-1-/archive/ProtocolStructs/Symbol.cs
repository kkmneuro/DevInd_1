using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public enum DAYS
    {
        SUN = 1,
        MON,
        TUE,
        WED,
        THU,
        FRI,
        SAT
    }
    public class SymbolSession
    {
        public string _TradeSession;
        public DAYS _Day;
        public string _QuoteSession;
        public bool _IsUseTimelimits;
        public DateTime _StartDate;
        public DateTime _EndDate;

    }
    public class Symbol
    {
        public Int32 _Instruement_ID;
        public string _SymbolName;
        public string _Description;
        public string _Source;
        public Int32 _Digits;
        public string _SettlingCurrency;
        public string _MarginCurrency;
        //public string _Orders;
        //public int _Spread;
        public int _MaximumLots;
        public decimal _BuySideTurnover;
        public decimal _SellSideTurnover;
        public int _MaximumAllowablePosition;
        public int _Hedged;
        //public Int32 _FreezeLevel;
        public Int32 _LimitandStopLevel;
        //public Int32 _SpreadBalance;
        public decimal _TickSize;
        public decimal _TickPrice;
        public int _ContractSize;
        public string _QuotationBaseValue;
        public int _Maintenance;
        public string _DeliveryType;
        public string _DeliveryUnit;
        public int _DeliveryQuantity;
        public int _MarketLot;
        public string _ExpiryDate;
        public string _StartDate;
        public string _EndDate;
        public string _TenderStartDate;
        public string _TenderEndDate;
        public string _DeliveryStartDate;
        public string _DeliveryEndDate;
        public int _DPRInitialPercentage;
        public int _DPRInterval;
        public int _InitialBuyMargin;
        public int _InitialSellMargin;
        public int _MaintenanceBuyMargin;
        public int _MaintenanceSellMargin;
        public string _ULAssest;
        public string _TradingCurrency;
        public int _Maximum_Order_Value;
        public int _DPR_Range_Higher;
        public string _FK_SecurityTypeID;
        public List<SymbolSession> _lstSession;
        public int _SessionCount;
        public string _MaximumLostUnit;
        public string _MarketLostUnit;
        public string _QuotationBaseValueUnit;

        public Symbol()
        {
            _Instruement_ID = 0;
            _SymbolName = string.Empty;
            _Description = string.Empty;
            _Source = string.Empty;
            _Digits = 0;
            _SettlingCurrency = string.Empty;
            _MarginCurrency = string.Empty;
            //_Orders = string.Empty;
            //_Spread = 0;
            _MaximumLots = 0;
            _BuySideTurnover = 0.0M;
            _SellSideTurnover = 0.0M;
            _MaximumAllowablePosition = 0;
            _Hedged = 0;
            //_FreezeLevel = 0;
            _LimitandStopLevel = 0;
            //_SpreadBalance = 0;
            _TickSize = 0;
            _TickPrice = 0;
            _ContractSize = 0;
            _QuotationBaseValue = string.Empty;
            _Maintenance = 0;
            _DeliveryType = string.Empty;
            _DeliveryUnit = string.Empty;
            _DeliveryQuantity = 0;
            _MarketLot = 0;
            _ExpiryDate = string.Empty;
            _StartDate = string.Empty;
            _EndDate = string.Empty;
            _TenderStartDate = string.Empty;
            _TenderEndDate = string.Empty;
            _DeliveryStartDate = string.Empty;
            _DeliveryEndDate = string.Empty;
            _DPRInitialPercentage = 0;
            _DPRInterval = 0;
            _InitialBuyMargin = 0;
            _InitialSellMargin = 0;
            _MaintenanceBuyMargin = 0;
            _MaintenanceSellMargin = 0;
            _ULAssest = string.Empty;
            _TradingCurrency = string.Empty;
            _Maximum_Order_Value = 0;
            _DPR_Range_Higher = 0;
            _FK_SecurityTypeID = string.Empty;
            _lstSession = new List<SymbolSession>();
            _SessionCount = 0;
            _MaximumLostUnit = string.Empty;
            _MarketLostUnit = string.Empty;
            _QuotationBaseValueUnit = string.Empty;

        }

        public override string ToString()
        {

            return "_Instruement_ID->" + _Instruement_ID +
         "_SymbolName->" + _SymbolName +
         "_Description->" + _Description +
         "_Source->" + _Source +
         "_Digits->" + _Digits +
         "_SettlingCurrency->" + _SettlingCurrency +
         "_MarginCurrency->" + _MarginCurrency +
         //"_Orders->" + _Orders +
         //"_Spread->" + _Spread +
         "_MaximumLots->" + _MaximumLots +
         "_BuySideTurnover->" + _BuySideTurnover +
         "_SellSideTurnover->" + _SellSideTurnover +
         "_MaximumAllowablePosition->" + _MaximumAllowablePosition +
         "_Hedged->" + _Hedged +
         //"_FreezeLevel->" + _FreezeLevel +
         "_LimitandStopLevel->" + _LimitandStopLevel +
         //"_SpreadBalance->" + _SpreadBalance +
         "_TickSize->" + _TickSize +
         "_TickPrice->" + _TickPrice +
         "_ContractSize->" + _ContractSize +
         "_QuotationBaseValue->" + _QuotationBaseValue +
         "_Maintenance->" + _Maintenance +
         "_DeliveryType->" + _DeliveryType +
         "_DeliveryUnit->" + _DeliveryUnit +
         "_DeliveryQuantity->" + _DeliveryQuantity +
         "_MarketLot->" + _MarketLot +
         "_ExpiryDate->" + _ExpiryDate +
         "_StartDate->" + _StartDate +
         "_EndDate->" + _EndDate +
         "_TenderStartDate->" + _TenderStartDate +
         "_TenderEndDate->" + _TenderEndDate +
         "_DeliveryStartDate->" + _DeliveryStartDate +
         "_DeliveryEndDate->" + _DeliveryEndDate +
         "_DPRInitialPercentage->" + _DPRInitialPercentage +
         "_DPRInterval->" + _DPRInterval +
         "_InitialBuyMargin->" + _InitialBuyMargin +
         "_InitialSellMargin->" + _InitialSellMargin +
         "_MaintenanceBuyMargin->" + _MaintenanceBuyMargin +
         "_MaintenanceSellMargin->" + _MaintenanceSellMargin +
         "_ULAssest->" + _ULAssest +
         "_TradingCurrency->" + _TradingCurrency +
         "_Maximum_Order_Value->" + _Maximum_Order_Value +
         "_DPR_Range_Higher->" + _DPR_Range_Higher +
         "_FK_SecurityTypeID->" + _FK_SecurityTypeID +
         //"_lstSession->"+_lstSession+
         "_SessionCount->" + _lstSession.Count +
         "_MaximumLostUnit->" + _MaximumLostUnit +
         "_MarketLostUnit->" + _MarketLostUnit +
         "_QuotationBaseValueUnit->" + _QuotationBaseValueUnit;

        }
    }
}
