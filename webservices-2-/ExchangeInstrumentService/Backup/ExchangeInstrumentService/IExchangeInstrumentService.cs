using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ExchangeInstrumentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExchangeInstrumentService" in both code and config file together.
    [ServiceContract]
    public interface IExchangeInstrumentService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<InstrumentData> GetInstrumentSpec(int participantsId);
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<InstrumentInfo> GetInstrumentInfo(int participantsId);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetAsyncInstrumentSpec(int participantsId, AsyncCallback callback, object asyncState);

        List<InstrumentData> EndGetAsyncInstrumentSpec(IAsyncResult result);
    }

    [DataContract]
    public class InstrumentInfo
    {
        [DataMember]
        public string Data;
    }

    [DataContract]
    public class InstrumentData
    {
        private string _instruementId;
        private string _symbol;
        private string _descriptions;
        private string _source;
        private string _digits;
        private string _ulAssest;
        private string _tradingCurrency;
        private string _settlingCurrency;
        private string _marginCurrency;
        private string _orders;
        private string _spread;
        private string _maximumLots;
        private string _maximumOrderValue;
        private string _buySideTurnover;
        private string _sellSideTurnover;
        private string _maximumAllowablePosition;
        private string _quotationBaseValue;
        private string _deliveryType;
        private string _deliveryUnit;
        private string _deliveryQuantity;
        private string _marketLot;
        private string _expiryDate;
        private string _startDate;
        private string _endDate;
        private string _tenderStartDate;
        private string _tenderEndDate;
        private string _deliveryStartDate;
        private string _deliveryEndDate;
        private string _dprInitialPercentage;
        private string _dprRangeHigher;
        private string _dprInterval;
        private string _limitAndStopLevel;
        private string _spreadBalance;
        private string _freezeLevel;
        private string _securityTypeId;
        private string _securityTypeChar;
        private string _isActive;
        private string _lpid;
        private string _contractSize;
        private string _initialBuyMargin;
        private string _initialSellMargin;
        private string _maintenanceBuyMargin;
        private string _maintenanceSellMargin;
        private string _hedged;
        private string _tickSize;
        private string _tickPrice;
        private string _tradingGateway;

        [DataMember]
        public string InstruementID
        {
            get { return _instruementId; }
            set { _instruementId = value; }
        }
        [DataMember]
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        [DataMember]
        public string Descriptions
        {
            get { return _descriptions; }
            set { _descriptions = value; }
        }
        [DataMember]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        [DataMember]
        public string Digits
        {
            get { return _digits; }
            set { _digits = value; }
        }
        [DataMember]
        public string ULAssest
        {
            get { return _ulAssest; }
            set { _ulAssest = value; }
        }
        [DataMember]
        public string TradingCurrency
        {
            get { return _tradingCurrency; }
            set { _tradingCurrency = value; }
        }
        [DataMember]
        public string SettlingCurrency
        {
            get { return _settlingCurrency; }
            set { _settlingCurrency = value; }
        }
        [DataMember]
        public string MarginCurrency
        {
            get { return _marginCurrency; }
            set { _marginCurrency = value; }
        }
        [DataMember]
        public string Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        [DataMember]
        public string Spread
        {
            get { return _spread; }
            set { _spread = value; }
        }
        [DataMember]
        public string MaximumLots
        {
            get { return _maximumLots; }
            set { _maximumLots = value; }
        }
        [DataMember]
        public string MaximumOrderValue
        {
            get { return _maximumOrderValue; }
            set { _maximumOrderValue = value; }
        }
        [DataMember]
        public string BuySideTurnover
        {
            get { return _buySideTurnover; }
            set { _buySideTurnover = value; }
        }
        [DataMember]
        public string SellSideTurnover
        {
            get { return _sellSideTurnover; }
            set { _sellSideTurnover = value; }
        }
        [DataMember]
        public string MaximumAllowablePosition
        {
            get { return _maximumAllowablePosition; }
            set { _maximumAllowablePosition = value; }
        }
        [DataMember]
        public string QuotationBaseValue
        {
            get { return _quotationBaseValue; }
            set { _quotationBaseValue = value; }
        }
        [DataMember]
        public string DeliveryType
        {
            get { return _deliveryType; }
            set { _deliveryType = value; }
        }
        [DataMember]
        public string DeliveryUnit
        {
            get { return _deliveryUnit; }
            set { _deliveryUnit = value; }
        }
        [DataMember]
        public string DeliveryQuantity
        {
            get { return _deliveryQuantity; }
            set { _deliveryQuantity = value; }
        }
        [DataMember]
        public string MarketLot
        {
            get { return _marketLot; }
            set { _marketLot = value; }
        }
        [DataMember]
        public string ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }
        [DataMember]
        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        [DataMember]
        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        [DataMember]
        public string TenderStartDate
        {
            get { return _tenderStartDate; }
            set { _tenderStartDate = value; }
        }
        [DataMember]
        public string TenderEndDate
        {
            get { return _tenderEndDate; }
            set { _tenderEndDate = value; }
        }
        [DataMember]
        public string DeliveryStartDate
        {
            get { return _deliveryStartDate; }
            set { _deliveryStartDate = value; }
        }
        [DataMember]
        public string DeliveryEndDate
        {
            get { return _deliveryEndDate; }
            set { _deliveryEndDate = value; }
        }
        [DataMember]
        public string DPRInitialPercentage
        {
            get { return _dprInitialPercentage; }
            set { _dprInitialPercentage = value; }
        }
        [DataMember]
        public string DPRRangeHigher
        {
            get { return _dprRangeHigher; }
            set { _dprRangeHigher = value; }
        }
        [DataMember]
        public string DPRInterval
        {
            get { return _dprInterval; }
            set { _dprInterval = value; }
        }
        [DataMember]
        public string LimitAndStopLevel
        {
            get { return _limitAndStopLevel; }
            set { _limitAndStopLevel = value; }
        }
        [DataMember]
        public string SpreadBalance
        {
            get { return _spreadBalance; }
            set { _spreadBalance = value; }
        }
        [DataMember]
        public string FreezeLevel
        {
            get { return _freezeLevel; }
            set { _freezeLevel = value; }
        }
        [DataMember]
        public string SecurityTypeID
        {
            get { return _securityTypeId; }
            set { _securityTypeId = value; }
        }
        [DataMember]
        public string SecurityTypeChar
        {
            get { return _securityTypeChar; }
            set { _securityTypeChar = value; }
        }
        [DataMember]
        public string IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        [DataMember]
        public string LPID
        {
            get { return _lpid; }
            set { _lpid = value; }
        }
        [DataMember]
        public string ContractSize
        {
            get { return _contractSize; }
            set { _contractSize = value; }
        }
        [DataMember]
        public string InitialBuyMargin
        {
            get { return _initialBuyMargin; }
            set { _initialBuyMargin = value; }
        }
        [DataMember]
        public string InitialSellMargin
        {
            get { return _initialSellMargin; }
            set { _initialSellMargin = value; }
        }
        [DataMember]
        public string MaintenanceBuyMargin
        {
            get { return _maintenanceBuyMargin; }
            set { _maintenanceBuyMargin = value; }
        }
        [DataMember]
        public string MaintenanceSellMargin
        {
            get { return _maintenanceSellMargin; }
            set { _maintenanceSellMargin = value; }
        }
        [DataMember]
        public string Hedged
        {
            get { return _hedged; }
            set { _hedged = value; }
        }
        [DataMember]
        public string TickSize
        {
            get { return _tickSize; }
            set { _tickSize = value; }
        }
        [DataMember]
        public string TickPrice
        {
            get { return _tickPrice; }
            set { _tickPrice = value; }
        }
        [DataMember]
        public string TradingGateway
        {
            get { return _tradingGateway; }
            set { _tradingGateway = value; }
        }
    }
}
