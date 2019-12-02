///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//17/01/2012	NAMO         1.Designing and Coding of form	
//18/01/2012	NAMO	    1.Commenting of Code
//30/01/2012	NAMO	    1.Added code for persisting values of WorkSpace tab in Preferences 
//31/01/2012	NAMO	    1.Added methods for persisting values of General tab in Preferences
//               		    2.Added methods for persisting values of Alert tab in Preferences
//                          3.Added methods for persisting values of Portfolio tab in Preferences
//                          4.Added methods for persisting values of Order tab in Preferences
//02/02/2012	NAMO	    1.Commenting of the code
//16/02/2012	NAMO	    1.Code for closing of form on Escape key
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using PALSA.Cls;

namespace PALSA.Frm
{
    /// <summary>
    /// Code for Preferences dialog
    /// </summary>
    public partial class frmPreferences : frmBase
    {
        #region    "      MEMBERS      "

        private static frmPreferences _Instance;
        public static Hashtable _hotKeySettingsHashTable;
        //string _hotKeyFile;
        private static object _preferencesPortfolio;

        #endregion "      MEMBERS      "

        #region    "      METHODS      "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HotKeySettingsHashTable">Hastable object  value</param>
        private frmPreferences(Hashtable HotKeySettingsHashTable)
        {
            InitializeComponent();
            Text = ui_uctlPreferences.Title;
            _hotKeySettingsHashTable = HotKeySettingsHashTable;
        }

        /// <summary>
        /// Provides the instance of the frmPreferences
        /// </summary>
        /// <param name="HotKeySettingsHashTable"></param>
        /// <returns></returns>
        public static frmPreferences GetInstance(Hashtable HotKeySettingsHashTable, object _portfolio)
        {
            _preferencesPortfolio = _portfolio;

            //if (_Instance == null)
            {
                _Instance = new frmPreferences(HotKeySettingsHashTable);
                _Instance.Init();
            }
            //else
            {
                // _hotKeySettingsHashTable = HotKeySettingsHashTable;
            }
            return _Instance;
        }

        /// <summary>
        /// Registered the events related to the form
        /// </summary>
        public void Init()
        {
            ui_uctlPreferences.ui_uctlPreferencesPortfolio.PortfolioList = _preferencesPortfolio;
            ui_uctlPreferences.HotKeySettingsHashTable = _hotKeySettingsHashTable;
            ui_uctlPreferences.OnOkClick += ui_uctlPreferences_OnOkClick;
            ui_uctlPreferences.OnCancelClick += ui_uctlPreferences_OnCancelClick;
            ui_uctlPreferences.OnApplyClick +=ui_uctlPreferences_OnApplyClick;
        }

        /// <summary>
        /// Applys the user preference settings
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3">Settings to be applied</param>
        private void ui_uctlPreferences_OnApplyClick(object arg1, EventArgs arg2, ClsPreferences arg3)
        {
            SetWorkSpaceValues(arg3.WorkSpace);
            SetAlertValues(arg3.Alert);
            SetGerneralValues(arg3.Gerneral);
            SetPortfolioValues(arg3.PreferencesPortfolio);
            SetOrderValues(arg3.Order);
            SetForexPairValues(arg3.ForexPair);
            SetMarketWatchValues(arg3.MarketWatchPreferanceSettings);
            SetDocumentSettings(arg3.DocumentsSettings);
            SaveHotKeys();
            Properties.Settings.Default.Save();
            _hotKeySettingsHashTable = ui_uctlPreferences.GetHashTable();
            OnHotKeyChanged(_hotKeySettingsHashTable);
            OnDocumentSettingsChanged();
        }

        private void SetDocumentSettings(ClsDocumentsSettings objclsDocuments)
        {
            Properties.Settings.Default.MarketWatchInDoc=objclsDocuments.MarketWatchInDoc;
            Properties.Settings.Default.MarketQuoteInDoc=objclsDocuments.MarketQuoteInDoc;
            Properties.Settings.Default.Level2DataInDoc=objclsDocuments.Level2DataInDoc ;
            Properties.Settings.Default.ChartInDoc=objclsDocuments.ChartInDoc;
            Properties.Settings.Default.RadarInDoc=objclsDocuments.RadarInDoc ;
            Properties.Settings.Default.ScannerInDoc=objclsDocuments.ScannerInDoc;
            Properties.Settings.Default.MatrixInDoc=objclsDocuments.MatrixInDoc;
            Properties.Settings.Default.OrderHistoryInDoc=objclsDocuments.OrderHistoryInDoc ;
            Properties.Settings.Default.TradeHistoryInDoc=objclsDocuments.TradeHistoryInDoc ;
            Properties.Settings.Default.NetPositionInDoc=objclsDocuments.NetPositionInDoc;
            Properties.Settings.Default.MailInDoc=objclsDocuments.MailInDoc;
            Properties.Settings.Default.AlertsInDoc=objclsDocuments.AlertsInDoc;
            Properties.Settings.Default.AccountsInDoc=objclsDocuments.AcountsInDoc;

            Properties.Settings.Default.MarketWatchIndex=objclsDocuments.MarketWatchIndex ;
            Properties.Settings.Default.MarketQuoteIndex=objclsDocuments.MarketQuoteIndex;
            Properties.Settings.Default.Level2DataIndex=objclsDocuments.Level2DataIndex;
            Properties.Settings.Default.ChartIndex=objclsDocuments.ChartIndex;
            Properties.Settings.Default.RadarIndex=objclsDocuments.RadarIndex;
            Properties.Settings.Default.ScannerIndex=objclsDocuments.ScannerIndex;
            Properties.Settings.Default.MatrixIndex=objclsDocuments.MatrixIndex;
            Properties.Settings.Default.OrderHistoryIndex=objclsDocuments.OrderHistoryIndex;
            Properties.Settings.Default.TradeHistoryIndex=objclsDocuments.TradeHistoryIndex;
            Properties.Settings.Default.NetPositionIndex=objclsDocuments.NetPositionIndex ;
            Properties.Settings.Default.MailIndex=objclsDocuments.MailIndex ;
            Properties.Settings.Default.AlertsIndex=objclsDocuments.AlertsIndex;
            Properties.Settings.Default.AccountsIndex=objclsDocuments.AcountsIndex;

            Properties.Settings.Default.MarketWatchZone=objclsDocuments.MarketWatchZone;
            Properties.Settings.Default.MarketQuoteZone=objclsDocuments.MarketQuoteZone;
            Properties.Settings.Default.Level2DataZone=objclsDocuments.Level2DataZone;
            Properties.Settings.Default.ChartZone=objclsDocuments.ChartZone;
            Properties.Settings.Default.RadarZone = objclsDocuments.RadarZone;
            Properties.Settings.Default.ScannerZone=objclsDocuments.ScannerZone;
            Properties.Settings.Default.MatrixZone=objclsDocuments.MatrixZone;
            Properties.Settings.Default.OrderHistoryZone=objclsDocuments.OrderHistoryZone;
            Properties.Settings.Default.TradeHistoryZone=objclsDocuments.TradeHistoryZone;
            Properties.Settings.Default.NetPositionZone=objclsDocuments.NetPositionZone;
            Properties.Settings.Default.MailZone = objclsDocuments.MailZone;
            Properties.Settings.Default.AlertsZone=objclsDocuments.AlertsZone ;
            Properties.Settings.Default.AccountsZone=objclsDocuments.AcountsZone;

        }

        private void SetMarketWatchValues(ClsMarketWatchPreferanceSettings clsMarketWatch)
        {
            
            Properties.Settings.Default.DirectMarketExecution = clsMarketWatch.DirectMarketExecution;
            Properties.Settings.Default.EnableTradingOnMarketWatch = clsMarketWatch.EnableTradingOnMarketWatch;
            Properties.Settings.Default.SingleClickOrderSubmit = clsMarketWatch.SingleClickOrderSubmit;
            Properties.Settings.Default.MarketWatchTradingDefaultQuantity = clsMarketWatch.MarketWatchTradingDefaultQuantity;
           
        }
        public event Action OnDocumentSettingsChanged = delegate { };
        public event Action<Hashtable> OnHotKeyChanged=delegate{};
        private void SetForexPairValues(ClsForexPair clsForexPair)
        {
            Properties.Settings.Default.OrderFormSetting = clsForexPair.OrderFormSetting;
            Properties.Settings.Default.PositionSizeType = clsForexPair.PositionSizeType;
            Properties.Settings.Default.MarketQuoteUpColor = clsForexPair.UpTrendColor;
            Properties.Settings.Default.MarketQuoteDownColor = clsForexPair.DownTrendColor;
            Properties.Settings.Default.MarketQuoteBackColor = clsForexPair.BackColor;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Provides the stored preference values to Prferences control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPreferences_Load(object sender, EventArgs e)
        {
            SetValuesToWorksace();
            SetValuesToAlert();
            SetValuesToGeneral();
            SetValuesToPortfolio();
            SetValuesToOrder();
            SetValuesToForexPair();
            SetValuesToMarketWatch();
            SetValuesToDocumentSettings();
            ui_uctlPreferences.PopulateHotKeySettings();
            TopMost = true;
        }

        private void SetValuesToDocumentSettings()
        {
            var objclsDocuments = new ClsDocumentsSettings();
            //objclsDocuments.
            objclsDocuments.MarketWatchInDoc = Properties.Settings.Default.MarketWatchInDoc;
            objclsDocuments.MarketQuoteInDoc= Properties.Settings.Default.MarketQuoteInDoc;
            objclsDocuments.Level2DataInDoc= Properties.Settings.Default.Level2DataInDoc;
            objclsDocuments.ChartInDoc= Properties.Settings.Default.ChartInDoc;
            objclsDocuments.RadarInDoc= Properties.Settings.Default.RadarInDoc;
            objclsDocuments.ScannerInDoc= Properties.Settings.Default.ScannerInDoc;
            objclsDocuments.MatrixInDoc= Properties.Settings.Default.MatrixInDoc;
            objclsDocuments.OrderHistoryInDoc= Properties.Settings.Default.OrderHistoryInDoc;
            objclsDocuments.TradeHistoryInDoc= Properties.Settings.Default.TradeHistoryInDoc;
            objclsDocuments.NetPositionInDoc= Properties.Settings.Default.NetPositionInDoc;
            objclsDocuments.MailInDoc= Properties.Settings.Default.MailInDoc;
            objclsDocuments.AlertsInDoc = Properties.Settings.Default.AlertsInDoc;
            objclsDocuments.AcountsInDoc = Properties.Settings.Default.AccountsInDoc;

            objclsDocuments.MarketWatchIndex= Properties.Settings.Default.MarketWatchIndex;
            objclsDocuments.MarketQuoteIndex= Properties.Settings.Default.MarketQuoteIndex;
            objclsDocuments.Level2DataIndex= Properties.Settings.Default.Level2DataIndex;
            objclsDocuments.ChartIndex= Properties.Settings.Default.ChartIndex;
            objclsDocuments.RadarIndex= Properties.Settings.Default.RadarIndex;
            objclsDocuments.ScannerIndex= Properties.Settings.Default.ScannerIndex;
            objclsDocuments.MatrixIndex= Properties.Settings.Default.MatrixIndex;
            objclsDocuments.OrderHistoryIndex= Properties.Settings.Default.OrderHistoryIndex;
            objclsDocuments.TradeHistoryIndex= Properties.Settings.Default.TradeHistoryIndex;
            objclsDocuments.NetPositionIndex= Properties.Settings.Default.NetPositionIndex;
            objclsDocuments.MailIndex= Properties.Settings.Default.MailIndex;
            objclsDocuments.AlertsIndex = Properties.Settings.Default.AlertsIndex;
            objclsDocuments.AcountsIndex = Properties.Settings.Default.AccountsIndex;

            objclsDocuments.MarketWatchZone= Properties.Settings.Default.MarketWatchZone;
            objclsDocuments.MarketQuoteZone= Properties.Settings.Default.MarketQuoteZone;
            objclsDocuments.Level2DataZone= Properties.Settings.Default.Level2DataZone;
            objclsDocuments.ChartZone= Properties.Settings.Default.ChartZone;
            objclsDocuments.RadarZone= Properties.Settings.Default.RadarZone;
            objclsDocuments.ScannerZone= Properties.Settings.Default.ScannerZone;
            objclsDocuments.MatrixZone= Properties.Settings.Default.MatrixZone;
            objclsDocuments.OrderHistoryZone= Properties.Settings.Default.OrderHistoryZone;
            objclsDocuments.TradeHistoryZone= Properties.Settings.Default.TradeHistoryZone;
            objclsDocuments.NetPositionZone= Properties.Settings.Default.NetPositionZone;
            objclsDocuments.MailZone= Properties.Settings.Default.MailZone;
            objclsDocuments.AlertsZone = Properties.Settings.Default.AlertsZone;
            objclsDocuments.AcountsZone = Properties.Settings.Default.AccountsZone;
            ui_uctlPreferences.uctlDocumentsSetting1.SetValues(objclsDocuments);
        }

        private void SetValuesToMarketWatch()
        {
            var objclsMarketWatch = new ClsMarketWatchPreferanceSettings();

            objclsMarketWatch.EnableTradingOnMarketWatch = Properties.Settings.Default.EnableTradingOnMarketWatch;
            objclsMarketWatch.DirectMarketExecution = Properties.Settings.Default.DirectMarketExecution;
            objclsMarketWatch.SingleClickOrderSubmit = Properties.Settings.Default.SingleClickOrderSubmit;
            objclsMarketWatch.MarketWatchTradingDefaultQuantity = Properties.Settings.Default.MarketWatchTradingDefaultQuantity;        
            ui_uctlPreferences.uctlPreferencesMarketWatch1.SetValues(objclsMarketWatch);
        }

        private void SetValuesToForexPair()
        {
            var objclsForexPair = new ClsForexPair();

            objclsForexPair.OrderFormSetting = Properties.Settings.Default.OrderFormSetting;
            objclsForexPair.PositionSizeType = Properties.Settings.Default.PositionSizeType;
            objclsForexPair.UpTrendColor = Properties.Settings.Default.MarketQuoteUpColor;
            objclsForexPair.DownTrendColor = Properties.Settings.Default.MarketQuoteDownColor;
            objclsForexPair.BackColor = Properties.Settings.Default.MarketQuoteBackColor;

            ui_uctlPreferences.ui_uctlPreferencesForexPair.SetValues(objclsForexPair);
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void ui_uctlPreferences_OnCancelClick(object arg1, EventArgs arg2)
        {
            Close();
        }

        /// <summary>
        /// Applys changes and closes the form
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void ui_uctlPreferences_OnOkClick(object arg1, EventArgs arg2)
        {

            DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// Saves the given hot key values
        /// </summary>
        public void SaveHotKeys()
        {
            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetHotKeysFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetHotKeysFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, ui_uctlPreferences.GetHashTable());
            streamWrite.Close();
        }

        private void ui_uctlPreferences_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Stores workspace settings
        /// </summary>
        /// <param name="workspaceSettings">Workspaces settings</param>
        public void SetWorkSpaceValues(ClsWorkSpace workspaceSettings)
        {
            Properties.Settings.Default.IsLockWorkStation = workspaceSettings.IsLockWorkStation;
            Properties.Settings.Default.LockWorkStationTime = (60*1000*workspaceSettings.LockWorkStationTime);
            Properties.Settings.Default.DefaultWorkSpace = workspaceSettings.DefaultWorkSpace;
            if (Properties.Settings.Default.IsLockTimeInSeconds = workspaceSettings.IsLockTimeInSeconds)
            {
                Properties.Settings.Default.LockWorkStationTime = (1000*workspaceSettings.LockWorkStationTime);
            }
            Properties.Settings.Default.IsShowDateTime = workspaceSettings.IsShowDateTime;
            Properties.Settings.Default.OpenAllViewsWith = workspaceSettings.OpenAllViewsWith;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Retrieved workspace saved settings
        /// </summary>
        public void SetValuesToWorksace()
        {
            var objclsWorkSpace = new ClsWorkSpace();

            objclsWorkSpace.IsLockWorkStation = Properties.Settings.Default.IsLockWorkStation;
            objclsWorkSpace.LockWorkStationTime = (Properties.Settings.Default.LockWorkStationTime/(60*1000));
            objclsWorkSpace.IsLockTimeInSeconds = Properties.Settings.Default.IsLockTimeInSeconds;
            if (Properties.Settings.Default.IsLockTimeInSeconds)
            {
                objclsWorkSpace.LockWorkStationTime = (Properties.Settings.Default.LockWorkStationTime/1000);
            }
            objclsWorkSpace.DefaultWorkSpace = Properties.Settings.Default.DefaultWorkSpace;
            objclsWorkSpace.IsShowDateTime = Properties.Settings.Default.IsShowDateTime;
            objclsWorkSpace.OpenAllViewsWith = Properties.Settings.Default.OpenAllViewsWith;

            ui_uctlPreferences.ui_uctlPreferencesWorkSpace.SetValues(objclsWorkSpace);
        }

        /// <summary>
        /// Stores Alert settings
        /// </summary>
        /// <param name="clsAlert">Alert settings</param>
        private void SetAlertValues(ClsAlert clsAlert)
        {
            Properties.Settings.Default.IsFrshOrder = clsAlert.IsFrshOrder;
            Properties.Settings.Default.IsOrderModification = clsAlert.IsOrderModification;
            Properties.Settings.Default.IsMarketOrder = clsAlert.IsMarketOrder;
            Properties.Settings.Default.IsOrderCancellation = clsAlert.IsOrderCancellation;
            Properties.Settings.Default.IsTradeModification = clsAlert.IsTradeModification;
            Properties.Settings.Default.IsDifferentProductOrder = clsAlert.IsDifferentProductOrder;
            Properties.Settings.Default.IsOutsideDPROrder = clsAlert.IsOutsideDPROrder;
            Properties.Settings.Default.IsOpenPositionAlertOnLogoff = clsAlert.IsOpenPositionAlertOnLogoff;
            Properties.Settings.Default.IsPendingOrdersAlertOnLogoff = clsAlert.IsPendingOrdersAlertOnLogoff;
            Properties.Settings.Default.QuantityAlerts = clsAlert.QuantityAlerts;
            Properties.Settings.Default.ValueAlerts = clsAlert.ValueAlerts;
            Properties.Settings.Default.PriceAlerts = clsAlert.PriceAlerts;
            Properties.Settings.Default.SpreadIOCPriceAlerts = clsAlert.SpreadIOCPriceAlerts;
            Properties.Settings.Default.TradingCurrencyAlerts = clsAlert.TradingCurrencyAlerts;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Retrieved Alert saved settings
        /// </summary>
        public void SetValuesToAlert()
        {
            var objclsAlert = new ClsAlert();

            objclsAlert.IsFrshOrder = Properties.Settings.Default.IsFrshOrder;
            objclsAlert.IsOrderModification = Properties.Settings.Default.IsOrderModification;
            objclsAlert.IsMarketOrder = Properties.Settings.Default.IsMarketOrder;
            objclsAlert.IsOrderCancellation = Properties.Settings.Default.IsOrderCancellation;
            objclsAlert.IsTradeModification = Properties.Settings.Default.IsTradeModification;
            objclsAlert.IsDifferentProductOrder = Properties.Settings.Default.IsDifferentProductOrder;
            objclsAlert.IsOutsideDPROrder = Properties.Settings.Default.IsOutsideDPROrder;
            objclsAlert.IsOpenPositionAlertOnLogoff = Properties.Settings.Default.IsOpenPositionAlertOnLogoff;
            objclsAlert.IsPendingOrdersAlertOnLogoff = Properties.Settings.Default.IsPendingOrdersAlertOnLogoff;
            objclsAlert.QuantityAlerts = Properties.Settings.Default.QuantityAlerts;
            objclsAlert.ValueAlerts = Properties.Settings.Default.ValueAlerts;
            objclsAlert.PriceAlerts = Properties.Settings.Default.PriceAlerts;
            objclsAlert.SpreadIOCPriceAlerts = Properties.Settings.Default.SpreadIOCPriceAlerts;
            objclsAlert.TradingCurrencyAlerts = Properties.Settings.Default.TradingCurrencyAlerts;

            ui_uctlPreferences.ui_uctlPreferencesAlerts.SetValues(objclsAlert);
        }

        /// <summary>
        /// Stores General settings
        /// </summary>
        /// <param name="General">General settings</param>
        public void SetGerneralValues(ClsGeneral General)
        {
            Properties.Settings.Default.IsPrintOrderConfirm = General.IsPrintOrderConfirm;
            Properties.Settings.Default.IsPrintTradeConfirm = General.IsPrintTradeConfirm;
            Properties.Settings.Default.IsMTMonLineCalculation = General.IsMTMonLineCalculation;
            Properties.Settings.Default.MessageBarMessageType = General.MessageBarMessageType;
            Properties.Settings.Default.Event = General.Event;
            Properties.Settings.Default.IsBeep = General.IsBeep;
            Properties.Settings.Default.IsFlashMessageBar = General.IsFlashMessageBar;
            Properties.Settings.Default.IsMessageBox = General.IsMessageBox;
            Properties.Settings.Default.TimeFormat = General.TimeFormat;
            Properties.Settings.Default.AlwaysOpenTheOrderBookWith = General.AlwaysOpenTheOrderBookWith;
            Properties.Settings.Default.DefaultInstrumentName = General.DefaultInstrumentName;
            if (General.MaxMessageInMessageBox == "---SELECT---")
            {
                Properties.Settings.Default.MaxMessageInMessageBox = 50;
            }
            else
            {
                Properties.Settings.Default.MaxMessageInMessageBox = Convert.ToInt32(General.MaxMessageInMessageBox);
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Retrieved General saved settings
        /// </summary>
        public void SetValuesToGeneral()
        {
            var objclsGeneral = new ClsGeneral();

            objclsGeneral.IsPrintOrderConfirm = Properties.Settings.Default.IsPrintOrderConfirm;
            objclsGeneral.IsPrintTradeConfirm = Properties.Settings.Default.IsPrintTradeConfirm;
            objclsGeneral.IsMTMonLineCalculation = Properties.Settings.Default.IsMTMonLineCalculation;
            objclsGeneral.MessageBarMessageType = Properties.Settings.Default.MessageBarMessageType;
            objclsGeneral.Event = Properties.Settings.Default.Event;
            objclsGeneral.IsBeep = Properties.Settings.Default.IsBeep;
            objclsGeneral.IsFlashMessageBar = Properties.Settings.Default.IsFlashMessageBar;
            objclsGeneral.IsMessageBox = Properties.Settings.Default.IsMessageBox;
            objclsGeneral.TimeFormat = Properties.Settings.Default.TimeFormat;
            objclsGeneral.AlwaysOpenTheOrderBookWith = Properties.Settings.Default.AlwaysOpenTheOrderBookWith;
            objclsGeneral.DefaultInstrumentName = Properties.Settings.Default.DefaultInstrumentName;
            objclsGeneral.MaxMessageInMessageBox = Properties.Settings.Default.MaxMessageInMessageBox.ToString();

            ui_uctlPreferences.ui_uctlPreferencesGeneral.SetInstruments(Properties.Settings.Default.LstInstruments);
            ui_uctlPreferences.ui_uctlPreferencesGeneral.SetValues(objclsGeneral);
        }

        /// <summary>
        /// Stores Portfolio settings
        /// </summary>
        /// <param name="preferencePortfolio">Portfolio settings</param>
        public void SetPortfolioValues(ClsPreferencesPortfolio preferencePortfolio)
        {
            Properties.Settings.Default.MarketWatchPortfolio = preferencePortfolio.MarketWatch;
            Properties.Settings.Default.TickerDisplay = preferencePortfolio.TickerDisplay;
            Properties.Settings.Default.TickerPortfolio = preferencePortfolio.TickerPortfolio;
            Properties.Settings.Default.TickerComodityDisplay = preferencePortfolio.TickerComodityDisplay;
            Properties.Settings.Default.TickerSpeed = preferencePortfolio.TickerSpeed;
            Properties.Settings.Default.TickerComoditySpeed = preferencePortfolio.TickerComoditySpeed;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Retrieved Portfolio saved settings
        /// </summary>
        public void SetValuesToPortfolio()
        {
            var objclsPreferencesPortfolio =
                new ClsPreferencesPortfolio();

            objclsPreferencesPortfolio.MarketWatch = Properties.Settings.Default.MarketWatchPortfolio;
            objclsPreferencesPortfolio.TickerDisplay = Properties.Settings.Default.TickerDisplay;
            objclsPreferencesPortfolio.TickerPortfolio = Properties.Settings.Default.TickerPortfolio;
            objclsPreferencesPortfolio.TickerComodityDisplay = Properties.Settings.Default.TickerComodityDisplay;
            objclsPreferencesPortfolio.TickerSpeed = Properties.Settings.Default.TickerSpeed;
            objclsPreferencesPortfolio.TickerComoditySpeed = Properties.Settings.Default.TickerComoditySpeed;

            ui_uctlPreferences.ui_uctlPreferencesPortfolio.SetValues(objclsPreferencesPortfolio);
        }

        /// <summary>
        /// Stores Order settings
        /// </summary>
        /// <param name="order">Order settings</param>
        public void SetOrderValues(ClsOrder order)
        {
            if (order.MinOrderQty < clsTWSOrderManagerJSON.INSTANCE.Lotsize)
            {
                MessageBox.Show("Invalid Minimum Order Quantity.Please change and retry.");
            }
            else
            {
                Properties.Settings.Default.IsAlwaysUseMinOrderQtyGiven = order.IsAlwaysUseMinOrderQtyGiven;
                Properties.Settings.Default.MinOrderQty = order.MinOrderQty;
                Properties.Settings.Default.OrderValidity = order.OrderValidity;
                Properties.Settings.Default.IsDisableDQty = order.IsDisableDQty;
                Properties.Settings.Default.IsTriggerPriceSameAsLimitPrice = order.IsTriggerPriceSameAsLimitPrice;
                Properties.Settings.Default.AccountType = order.AccountType;
                Properties.Settings.Default.IsPrefixClientIDWith = order.IsPrefixClientIDWith;
                Properties.Settings.Default.IsRetainLastClientID = order.IsRetainLastClientID;
                Properties.Settings.Default.IsClientNameEnable = order.IsClientNameEnable;
                Properties.Settings.Default.IsOTROrderAlert = order.IsOTROrderAlert;
                Properties.Settings.Default.IsPrefixOmniIdWith = order.IsPrefixOmniIdWith;
                Properties.Settings.Default.IsRetainLastParticipaintCodeOmniId = order.IsRetainLastParticipaintCodeOmniId;
                Properties.Settings.Default.IsUnregisteredClientAlert = order.IsUnregisteredClientAlert;
                Properties.Settings.Default.PrefixClientIDWith = order.PrefixClientIDWith;
                Properties.Settings.Default.PrefixOmniIdWith = order.PrefixOmniIdWith;
                Properties.Settings.Default.OrderEntryOnce = order.OrderEntryOnce;
                Properties.Settings.Default.OrderEntryMultiple = order.OrderEntryMultiple;
                Properties.Settings.Default.IsDisableProductDetails = order.IsDisableProductDetails;
                Properties.Settings.Default.IsCloseOrderEntryAfterSubmission = order.IsCloseOrderEntryAfterSubmission;
                Properties.Settings.Default.IsPriceDecimalSelection = order.IsPriceDecimalSelection;
                Properties.Settings.Default.SIOC = order.SIOC;

                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Retrieved Order saved settings
        /// </summary>
        public void SetValuesToOrder()
        {
            var objclsOrder = new ClsOrder();

            objclsOrder.IsAlwaysUseMinOrderQtyGiven = Properties.Settings.Default.IsAlwaysUseMinOrderQtyGiven;
            objclsOrder.MinOrderQty = Properties.Settings.Default.MinOrderQty;
            objclsOrder.OrderValidity = Properties.Settings.Default.OrderValidity;
            objclsOrder.IsDisableDQty = Properties.Settings.Default.IsDisableDQty;
            objclsOrder.IsTriggerPriceSameAsLimitPrice = Properties.Settings.Default.IsTriggerPriceSameAsLimitPrice;
            objclsOrder.AccountType = Properties.Settings.Default.AccountType;
            objclsOrder.IsPrefixClientIDWith = Properties.Settings.Default.IsPrefixClientIDWith;
            objclsOrder.IsRetainLastClientID = Properties.Settings.Default.IsRetainLastClientID;
            objclsOrder.IsClientNameEnable = Properties.Settings.Default.IsClientNameEnable;
            objclsOrder.IsOTROrderAlert = Properties.Settings.Default.IsOTROrderAlert;
            objclsOrder.IsPrefixOmniIdWith = Properties.Settings.Default.IsPrefixOmniIdWith;
            objclsOrder.IsRetainLastParticipaintCodeOmniId =
                Properties.Settings.Default.IsRetainLastParticipaintCodeOmniId;
            objclsOrder.IsUnregisteredClientAlert = Properties.Settings.Default.IsUnregisteredClientAlert;
            objclsOrder.PrefixClientIDWith = Properties.Settings.Default.PrefixClientIDWith;
            objclsOrder.PrefixOmniIdWith = Properties.Settings.Default.PrefixOmniIdWith;
            objclsOrder.OrderEntryOnce = Properties.Settings.Default.OrderEntryOnce;
            objclsOrder.OrderEntryMultiple = Properties.Settings.Default.OrderEntryMultiple;
            objclsOrder.IsDisableProductDetails = Properties.Settings.Default.IsDisableProductDetails;
            objclsOrder.IsCloseOrderEntryAfterSubmission = Properties.Settings.Default.IsCloseOrderEntryAfterSubmission;
            objclsOrder.IsPriceDecimalSelection = Properties.Settings.Default.IsPriceDecimalSelection;
            objclsOrder.SIOC = Properties.Settings.Default.SIOC;

            ui_uctlPreferences.ui_uctlPreferencesOrder.SetValues(objclsOrder);
        }

        #endregion  "      METHODS      "

        private void frmPreferences_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

      
    }
}