using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class SymbolPS : IProtocolStruct
    {
        public Symbol _Symbol;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public SymbolPS()
        {
            _Symbol = new Symbol();
        }
        public SymbolPS(Symbol deepCopy)
        {

            _Symbol._Instruement_ID = deepCopy._Instruement_ID;
            _Symbol._SymbolName = deepCopy._SymbolName;
            _Symbol._Description = deepCopy._Description;
            _Symbol._Source = deepCopy._Source;
            _Symbol._Digits = deepCopy._Digits;
            //_Symbol._FreezeLevel = deepCopy._FreezeLevel;
            _Symbol._SettlingCurrency = deepCopy._SettlingCurrency;
            _Symbol._MarginCurrency = deepCopy._MarginCurrency;
            //_Symbol._Orders = deepCopy._Orders;
            //_Symbol._Spread = deepCopy._Spread;
            _Symbol._MaximumLots = deepCopy._MaximumLots;
            _Symbol._BuySideTurnover = deepCopy._BuySideTurnover;
            _Symbol._SellSideTurnover = deepCopy._SellSideTurnover;
            _Symbol._MaximumAllowablePosition = deepCopy._MaximumAllowablePosition;
            _Symbol._Hedged = deepCopy._Hedged;
            _Symbol._LimitandStopLevel = deepCopy._LimitandStopLevel;
            //_Symbol._SpreadBalance = deepCopy._SpreadBalance;
            _Symbol._TickPrice = deepCopy._TickPrice;
            _Symbol._TickSize = deepCopy._TickSize;
            _Symbol._ContractSize = deepCopy._ContractSize;
            _Symbol._QuotationBaseValue = deepCopy._QuotationBaseValue;
            _Symbol._Maintenance = deepCopy._Maintenance;
            _Symbol._DeliveryType = deepCopy._DeliveryType;
            _Symbol._DeliveryUnit = deepCopy._DeliveryUnit;
            _Symbol._DeliveryQuantity = deepCopy._DeliveryQuantity;
            _Symbol._MarketLot = deepCopy._MarketLot;
            _Symbol._ExpiryDate = deepCopy._ExpiryDate;
            _Symbol._StartDate = deepCopy._StartDate;
            _Symbol._EndDate = deepCopy._EndDate;
            _Symbol._TenderStartDate = deepCopy._TenderStartDate;
            _Symbol._TenderEndDate = deepCopy._TenderEndDate;
            _Symbol._DeliveryStartDate = deepCopy._DeliveryStartDate;
            _Symbol._DeliveryEndDate = deepCopy._DeliveryEndDate;
            _Symbol._DPRInitialPercentage = deepCopy._DPRInitialPercentage;
            _Symbol._DPRInterval = deepCopy._DPRInterval;
            _Symbol._InitialBuyMargin = deepCopy._InitialBuyMargin;
            _Symbol._InitialSellMargin = deepCopy._InitialSellMargin;
            _Symbol._MaintenanceBuyMargin = deepCopy._MaintenanceBuyMargin;
            _Symbol._MaintenanceSellMargin = deepCopy._MaintenanceSellMargin;
            _Symbol._ULAssest = deepCopy._ULAssest;
            _Symbol._TradingCurrency = deepCopy._TradingCurrency;
            _Symbol._Maximum_Order_Value = deepCopy._Maximum_Order_Value;
            _Symbol._DPR_Range_Higher = deepCopy._DPR_Range_Higher;
            _Symbol._FK_SecurityTypeID = deepCopy._FK_SecurityTypeID;
            _Symbol._lstSession = deepCopy._lstSession;
            _Symbol._SessionCount = deepCopy._SessionCount;
            _Symbol._MaximumLostUnit = deepCopy._MaximumLostUnit;
            _Symbol._MarketLostUnit = deepCopy._MarketLostUnit;
            _Symbol._QuotationBaseValueUnit = deepCopy._QuotationBaseValueUnit;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Symbol_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        public override void WriteString()
        {
            StartStrW();

            AppendStr(_Symbol._Instruement_ID);
            AppendStr(_Symbol._SymbolName);
            AppendStr(_Symbol._Description);
            AppendStr(_Symbol._Source);
            AppendStr(_Symbol._Digits);
            //AppendStr(_Symbol._FreezeLevel);
            AppendStr(_Symbol._SettlingCurrency);
            AppendStr(_Symbol._MarginCurrency);
            //AppendStr(_Symbol._Orders);
            //AppendStr(_Symbol._Spread);
            AppendStr(_Symbol._MaximumLots);
            AppendStr(_Symbol._BuySideTurnover);
            AppendStr(_Symbol._SellSideTurnover);
            AppendStr(_Symbol._MaximumAllowablePosition);
            AppendStr(_Symbol._Hedged);
            AppendStr(_Symbol._LimitandStopLevel);
            //AppendStr(_Symbol._SpreadBalance);
            AppendStr(_Symbol._TickPrice);
            AppendStr(_Symbol._TickSize);
            AppendStr(_Symbol._ContractSize);
            AppendStr(_Symbol._QuotationBaseValue);
            AppendStr(_Symbol._Maintenance);
            AppendStr(_Symbol._DeliveryType);
            AppendStr(_Symbol._DeliveryUnit);
            AppendStr(_Symbol._DeliveryQuantity);
            AppendStr(_Symbol._MarketLot);
            AppendStr(_Symbol._ExpiryDate);
            AppendStr(_Symbol._StartDate);
            AppendStr(_Symbol._EndDate);
            AppendStr(_Symbol._TenderStartDate);
            AppendStr(_Symbol._TenderEndDate);
            AppendStr(_Symbol._DeliveryStartDate);
            AppendStr(_Symbol._DeliveryEndDate);
            AppendStr(_Symbol._DPRInitialPercentage);
            AppendStr(_Symbol._DPRInterval);
            AppendStr(_Symbol._InitialBuyMargin);
            AppendStr(_Symbol._InitialSellMargin);
            AppendStr(_Symbol._MaintenanceBuyMargin);
            AppendStr(_Symbol._MaintenanceSellMargin);
            AppendStr(_Symbol._ULAssest);
            AppendStr(_Symbol._TradingCurrency);
            AppendStr(_Symbol._Maximum_Order_Value);
            AppendStr(_Symbol._DPR_Range_Higher);
            AppendStr(_Symbol._FK_SecurityTypeID);
            AppendStr(_Symbol._lstSession.Count);

            for (int iSessionLoop = 0; iSessionLoop < _Symbol._lstSession.Count; iSessionLoop++)
            {
                AppendStr(_Symbol._lstSession[iSessionLoop]._TradeSession);
                AppendStr(_Symbol._lstSession[iSessionLoop]._Day.ToString());
                AppendStr(_Symbol._lstSession[iSessionLoop]._QuoteSession);
                AppendStr(_Symbol._lstSession[iSessionLoop]._IsUseTimelimits);
                AppendStr(_Symbol._lstSession[iSessionLoop]._StartDate);
                AppendStr(_Symbol._lstSession[iSessionLoop]._EndDate);
            }
            AppendStr(_Symbol._MaximumLostUnit);
            AppendStr(_Symbol._MarketLostUnit);
            AppendStr(_Symbol._QuotationBaseValueUnit);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;

            _Symbol._Instruement_ID = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._SymbolName = SpltString[++ind];
            _Symbol._Description = SpltString[++ind];
            _Symbol._Source = SpltString[++ind];
            _Symbol._Digits = clsUtility.GetInt(SpltString[++ind]);
            //_Symbol._FreezeLevel = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._SettlingCurrency = SpltString[++ind];
            _Symbol._MarginCurrency = SpltString[++ind];
            //_Symbol._Orders = SpltString[++ind];
            //_Symbol._Spread = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._MaximumLots = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._BuySideTurnover = clsUtility.GetDecimal(SpltString[++ind]);
            _Symbol._SellSideTurnover = clsUtility.GetDecimal(SpltString[++ind]);
            _Symbol._MaximumAllowablePosition = clsUtility.GetInt(SpltString[++ind]); ;
            _Symbol._Hedged = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._LimitandStopLevel = clsUtility.GetInt(SpltString[++ind]);
            //_Symbol._SpreadBalance = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._TickPrice = clsUtility.GetDecimal(SpltString[++ind]);
            _Symbol._TickSize = clsUtility.GetDecimal(SpltString[++ind]);
            _Symbol._ContractSize = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._QuotationBaseValue = SpltString[++ind];
            _Symbol._Maintenance = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._DeliveryType = SpltString[++ind];
            _Symbol._DeliveryUnit = SpltString[++ind];
            _Symbol._DeliveryQuantity = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._MarketLot = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._ExpiryDate = SpltString[++ind];
            _Symbol._StartDate = SpltString[++ind];
            _Symbol._EndDate = SpltString[++ind];
            _Symbol._TenderStartDate = SpltString[++ind];
            _Symbol._TenderEndDate = SpltString[++ind];
            _Symbol._DeliveryStartDate = SpltString[++ind];
            _Symbol._DeliveryEndDate = SpltString[++ind];
            _Symbol._DPRInitialPercentage = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._DPRInterval = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._InitialBuyMargin = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._InitialSellMargin = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._MaintenanceBuyMargin = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._MaintenanceSellMargin = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._ULAssest = SpltString[++ind];
            _Symbol._TradingCurrency = SpltString[++ind];
            _Symbol._Maximum_Order_Value = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._DPR_Range_Higher = clsUtility.GetInt(SpltString[++ind]);
            _Symbol._FK_SecurityTypeID = SpltString[++ind];
            _Symbol._SessionCount = clsUtility.GetInt(SpltString[++ind]);

            //int ind = 43;
            for (int iSessionLoop = 0; iSessionLoop < _Symbol._SessionCount; iSessionLoop++)
            {
                SymbolSession symSession = new SymbolSession();
                symSession._TradeSession = SpltString[++ind];
                symSession._Day = (DAYS)Enum.Parse(typeof(DAYS), SpltString[++ind], true);
                symSession._QuoteSession = SpltString[++ind];
                bool result = false;
                if (Boolean.TryParse(SpltString[++ind], out result))
                {
                    symSession._IsUseTimelimits = result;
                }
                symSession._StartDate = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
                symSession._EndDate = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
                _Symbol._lstSession.Add(symSession);

            }
            _Symbol._MaximumLostUnit = SpltString[++ind];
            _Symbol._MarketLostUnit = SpltString[++ind];
            _Symbol._QuotationBaseValueUnit = SpltString[++ind];

        }
        public override string ToString()
        {
            return _Symbol == null ? base.ToString() : _Symbol.ToString();
        }


        public override bool ValidateData()
        {
            base.ValidateData();


            Add2Vld("Symbol", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Symbol._SymbolName.ToString()));

            return IsValidlist();
        }
    }
}
