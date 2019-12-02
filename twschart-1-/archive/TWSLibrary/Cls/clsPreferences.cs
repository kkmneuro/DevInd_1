using System.Drawing;

namespace CommonLibrary.Cls
{
    public class ClsPreferences
    {
        public ClsGeneral Gerneral { get; set; }
        public ClsOrder Order { get; set; }
        public ClsAlert Alert { get; set; }
        public ClsPreferencesPortfolio PreferencesPortfolio { get; set; }
        public ClsWorkSpace WorkSpace { get; set; }
        public clsHotKeySettings HotKeySettings { get; set; }
        public ClsForexPair ForexPair { get; set; }
        public ClsMarketWatchPreferanceSettings MarketWatchPreferanceSettings { get; set; }
        public ClsDocumentsSettings DocumentsSettings { get; set; }
    }

    public class ClsDocumentsSettings
    {
        public bool MarketWatchInDoc { get; set; }
        public bool MarketQuoteInDoc { get; set; }
        public bool Level2DataInDoc { get; set; }
        public bool ChartInDoc { get; set; }
        public bool RadarInDoc { get; set; }
        public bool ScannerInDoc { get; set; }
        public bool MatrixInDoc { get; set; }
        public bool OrderHistoryInDoc { get; set; }
        public bool TradeHistoryInDoc { get; set; }
        public bool NetPositionInDoc { get; set; }
        public bool MailInDoc { get; set; }

        public int MarketWatchIndex { get; set; }
        public int MarketQuoteIndex { get; set; }
        public int Level2DataIndex { get; set; }
        public int ChartIndex { get; set; }
        public int RadarIndex { get; set; }
        public int ScannerIndex { get; set; }
        public int MatrixIndex { get; set; }
        public int OrderHistoryIndex { get; set; }
        public int TradeHistoryIndex { get; set; }
        public int NetPositionIndex { get; set; }
        public int MailIndex { get; set; }

        public int MarketWatchZone { get; set; }
        public int MarketQuoteZone { get; set; }
        public int Level2DataZone { get; set; }
        public int ChartZone { get; set; }
        public int RadarZone { get; set; }
        public int ScannerZone { get; set; }
        public int MatrixZone { get; set; }
        public int OrderHistoryZone { get; set; }
        public int TradeHistoryZone { get; set; }
        public int NetPositionZone { get; set; }
        public int MailZone { get; set; }

        public bool AlertsInDoc { get; set; }

        public int AlertsZone { get; set; }

        public int AlertsIndex { get; set; }

        public bool AcountsInDoc { get; set; }

        public int AcountsZone { get; set; }

        public int AcountsIndex { get; set; }
    }

    public class ClsMarketWatchPreferanceSettings
    {
        public bool EnableTradingOnMarketWatch { get ; set ;}
        public bool DirectMarketExecution{get;set;}
        public bool SingleClickOrderSubmit{get;set;}
        public int MarketWatchTradingDefaultQuantity{get;set;}
    }

    public class ClsGeneral
    {
        public bool IsPrintOrderConfirm { get; set; }
        public bool IsPrintTradeConfirm { get; set; }
        public bool IsMTMonLineCalculation { get; set; }
        public string MessageBarMessageType { get; set; }
        public string Event { get; set; }
        public bool IsBeep { get; set; }
        public bool IsFlashMessageBar { get; set; }
        public bool IsMessageBox { get; set; }
        public string TimeFormat { get; set; }
        public string AlwaysOpenTheOrderBookWith { get; set; }
        public string DefaultInstrumentName { get; set; }
        public string MaxMessageInMessageBox { get; set; }
    }

    public class ClsOrder
    {
        public bool IsAlwaysUseMinOrderQtyGiven { get; set; }
        public double MinOrderQty { get; set; }
        public string OrderValidity { get; set; }
        public bool IsDisableDQty { get; set; }
        public bool IsTriggerPriceSameAsLimitPrice { get; set; }
        public string AccountType { get; set; }
        public bool IsPrefixClientIDWith { get; set; }
        public bool IsRetainLastClientID { get; set; }
        public bool IsClientNameEnable { get; set; }
        public bool IsOTROrderAlert { get; set; }
        public bool IsPrefixOmniIdWith { get; set; }
        public bool IsRetainLastParticipaintCodeOmniId { get; set; }
        public bool IsUnregisteredClientAlert { get; set; }
        public string PrefixClientIDWith { get; set; }
        public string PrefixOmniIdWith { get; set; }
        public string OrderEntryOnce { get; set; }
        public string OrderEntryMultiple { get; set; }
        public bool IsDisableProductDetails { get; set; }
        public bool IsCloseOrderEntryAfterSubmission { get; set; }
        public bool IsPriceDecimalSelection { get; set; }
        public string SIOC { get; set; }
    }

    public class ClsAlert
    {
        public bool IsFrshOrder { get; set; }
        public bool IsOrderModification { get; set; }
        public bool IsMarketOrder { get; set; }
        public bool IsOrderCancellation { get; set; }
        public bool IsTradeModification { get; set; }
        public bool IsDifferentProductOrder { get; set; }
        public bool IsOutsideDPROrder { get; set; }
        public bool IsOpenPositionAlertOnLogoff { get; set; }
        public bool IsPendingOrdersAlertOnLogoff { get; set; }
        public int QuantityAlerts { get; set; }
        public int ValueAlerts { get; set; }
        public int PriceAlerts { get; set; }
        public int SpreadIOCPriceAlerts { get; set; }
        public string TradingCurrencyAlerts { get; set; }
    }

    public class ClsPreferencesPortfolio
    {
        public string MarketWatch { get; set; }
        public string TickerDisplay { get; set; }
        public string TickerPortfolio { get; set; }
        public string TickerComodityDisplay { get; set; }
        public int TickerSpeed { get; set; }
        public int TickerComoditySpeed { get; set; }
    }

    public class ClsWorkSpace
    {
        public string DefaultWorkSpace { get; set; }
        public bool IsLockWorkStation { get; set; }
        public int LockWorkStationTime { get; set; }
        public bool IsLockTimeInSeconds { get; set; }
        public bool IsShowDateTime { get; set; }
        public string OpenAllViewsWith { get; set; }
    }

    public class clsHotKeySettings
    {
        public string PlaceOrderHotKey { get; set; }
        //public string PlaceBuyOrderHotKey { get; set; }
        //public string PlaceSellOrderHotKey { get; set; }
        public string OrderBookHotKey { get; set; }
        public string MarketWatchHotKey { get; set; }
        public string FilterHotKey { get; set; }
        public string MarketPictureHotKey { get; set; }
        public string TradesHotKey { get; set; }
        public string ModifiedTradesHotKey { get; set; }
        public string MessageLogHotKey { get; set; }
        public string LoginHotKey { get; set; }
        public string LogoffHotKey { get; set; }
        public string FilterBarHotKey { get; set; }
        public string PreferencesHotKey { get; set; }
        public string LockWorkstationHotKey { get; set; }
        public string NetPositionHotKey { get; set; }
        public string SnapQuoteHotKey { get; set; }
        public string PortfolioHotKey { get; set; }
        public string ModifyOrderHotKey { get; set; }
        public string CancelAllOrdersHotKey { get; set; }
        public string ContractInformationHotKey { get; set; }
        public string TickerHotKey { get; set; }
        public string TopGainersLosersHotKey { get; set; }
        public string StatusBarHotKey { get; set; }
    }

    public class ClsForexPair
    {
        public int OrderFormSetting { get; set; }
        public int PositionSizeType { get; set; }
        public Color UpTrendColor { get; set; }
        public Color DownTrendColor { get; set; }
        public Color BackColor { get; set; }
    }
}