using System;

using System.Runtime.Serialization;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsContractSpecification
    /// </summary>
    [DataContract]
    public class clsContractSpecification
    {
        [DataMember]
        public Int32 Instruement_ID { get; set; }
        [DataMember]
        public string SymbolName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public Int32 Digits { get; set; }
        [DataMember]
        public string SettlingCurrency { get; set; }
        [DataMember]
        public string MarginCurrency { get; set; }
        [DataMember]
        public int MaximumLots { get; set; }
        [DataMember]
        public decimal BuySideTurnover { get; set; }
        [DataMember]
        public decimal SellSideTurnover { get; set; }
        [DataMember]
        public int MaximumAllowablePosition { get; set; }
        [DataMember]
        public int Hedged { get; set; }
        [DataMember]
        public Int32 LimitandStopLevel { get; set; }
        [DataMember]
        public decimal TickSize { get; set; }
        [DataMember]
        public decimal TickPrice { get; set; }
        [DataMember]
        public int ContractSize { get; set; }
        [DataMember]
        public string QuotationBaseValue { get; set; }
        [DataMember]
        public int Maintenance { get; set; }
        [DataMember]
        public string DeliveryType { get; set; }
        [DataMember]
        public string DeliveryUnit { get; set; }
        [DataMember]
        public int DeliveryQuantity { get; set; }
        [DataMember]
        public int MarketLot { get; set; }
        [DataMember]
        public string ExpiryDate { get; set; }
        [DataMember]
        public string StartDate { get; set; }
        [DataMember]
        public string EndDate { get; set; }
        [DataMember]
        public string TenderStartDate { get; set; }
        [DataMember]
        public string TenderEndDate { get; set; }
        [DataMember]
        public string DeliveryStartDate { get; set; }
        [DataMember]
        public string DeliveryEndDate { get; set; }
        [DataMember]
        public int DPRInitialPercentage { get; set; }
        [DataMember]
        public int DPRInterval { get; set; }
        [DataMember]
        public int InitialBuyMargin { get; set; }
        [DataMember]
        public int InitialSellMargin { get; set; }
        [DataMember]
        public int MaintenanceBuyMargin { get; set; }
        [DataMember]
        public int MaintenanceSellMargin { get; set; }
        [DataMember]
        public string ULAssest { get; set; }
        [DataMember]
        public string TradingCurrency { get; set; }
        [DataMember]
        public int Maximum_Order_Value { get; set; }
        [DataMember]
        public int DPR_Range_Higher { get; set; }
        [DataMember]
        public string FK_SecurityTypeID { get; set; }
        [DataMember]
        public List<clsSymbolSession> lstSession { get; set; }
        [DataMember]
        public int SessionCount { get; set; }
        [DataMember]
        public string MaximumLostUnit { get; set; }
        [DataMember]
        public string MarketLostUnit { get; set; }
        [DataMember]
        public string QuotationBaseValueUnit { get; set; }
        [DataMember]
        public Int32 Spread { get; set; }
        [DataMember]
        public clsInstrumentSwaps InstrumentSwaps { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
        [DataMember]
        public int QuoteOffTime { get; set; }
    }
}

[DataContract]
public class clsSymbolSession
{
    [DataMember]
    public string TradeSession { get; set; }
    [DataMember]
    public DAYS Day { get; set; }
    [DataMember]
    public string QuoteSession { get; set; }
    [DataMember]
    public bool IsUseTimelimits { get; set; }
    [DataMember]
    public DateTime StartDate { get; set; }
    [DataMember]
    public DateTime EndDate { get; set; }
    [DataMember]
    public string SessionEODMarketMaker { get; set; }
}

[DataContract]
public class clsSymbolSessionNew
{
    [DataMember]
    public List<clsSymbolSession> lstSession { get; set; }
    [DataMember]
    public int ServerResponseID { get; set; }
}

public class clsInstrumentSwaps
{
    [DataMember]
    public decimal LongPosition { get; set; }
    [DataMember]
    public decimal ShortPosition { get; set; }
    [DataMember]
    public bool IsEnable { get; set; }
}
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