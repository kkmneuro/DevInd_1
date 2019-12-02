///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlHotKeysSettings : UctlBase
    {
        #region    "        MEMBERS           "

        public const string NONE_HOTEKEY = "[NONE]";
        private Hashtable _hotKeySettingsHashTable;
        private string _title = "Hot Keys Settings";

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// This property sets and gets the title of the uctlHotKeysSettings control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlHotKeysSettings 
        /// </summary>
        public UctlHotKeysSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlHotKeysSettings with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlHotKeysSettings(object customizeSettings)
        {
        }

        public Hashtable GetHashTable()
        {
            return _hotKeySettingsHashTable;
        }

        public void Init(Hashtable HotKeySettingsHashTable)
        {
            _hotKeySettingsHashTable = null;
            _hotKeySettingsHashTable = new Hashtable();
            foreach (string Key in HotKeySettingsHashTable.Keys)
            {
                _hotKeySettingsHashTable.Add(Key, HotKeySettingsHashTable[Key]);
            }
            SetHotKeyText();
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// Sets the text of the controls corresponding to their localized value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Hot + " " + ClsLocalizationHandler.Keys + " " +
                     ClsLocalizationHandler.Settings;

            ui_lblBuyOrderEntry.Text = ClsLocalizationHandler.Buy + " " + ClsLocalizationHandler.Order + " " +
                                       ClsLocalizationHandler.Entry;
            ui_lblCancelAllOrders.Text = ClsLocalizationHandler.Cancel + " " + ClsLocalizationHandler.All + " " +
                                         ClsLocalizationHandler.Order;
            ui_lblFilter.Text = ClsLocalizationHandler.Filter;
            ui_lblFilterBar.Text = ClsLocalizationHandler.Filter + " " + ClsLocalizationHandler.Bar;
            ui_lblLockWorkStation.Text = ClsLocalizationHandler.LockWorkStation;
            ui_lblLogIn.Text = ClsLocalizationHandler.Log + ClsLocalizationHandler.In;
            ui_lblLogOff.Text = ClsLocalizationHandler.Log + ClsLocalizationHandler.Off;
            ui_lblMarketPicture.Text = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Picture;
            ui_lblMarketWatch.Text = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Watch;
            ui_lblMessageLog.Text = ClsLocalizationHandler.Message + " " + ClsLocalizationHandler.Log;
            ui_lblModifiedtrades.Text = ClsLocalizationHandler.Modified + " " + ClsLocalizationHandler.Trade;
            ui_lblModifyOrder.Text = ClsLocalizationHandler.Modify + " " + ClsLocalizationHandler.Order;
            ui_lblNetPosition.Text = ClsLocalizationHandler.Net + " " + ClsLocalizationHandler.Position;
            ui_lblOrderBook.Text = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Book;
            ui_lblPortfolio.Text = ClsLocalizationHandler.Portfolio;
            ui_lblPreferences.Text = ClsLocalizationHandler.Preferences;
            ui_lblProductInformation.Text = ClsLocalizationHandler.Product + " " +
                                            ClsLocalizationHandler.Information;
            ui_lblSellOrderEntry.Text = ClsLocalizationHandler.Sell + " " + ClsLocalizationHandler.Order + " " +
                                        ClsLocalizationHandler.Entry;
            ui_lblSnapQuote.Text = ClsLocalizationHandler.Snap + " " + ClsLocalizationHandler.Quote;
            ui_lblStatusBar.Text = ClsLocalizationHandler.Status + " " + ClsLocalizationHandler.Bar;
            ui_lblTicker.Text = ClsLocalizationHandler.Ticker;
            ui_lblTopGainersLosers.Text = ClsLocalizationHandler.Top + " " + ClsLocalizationHandler.Gainers +
                                          " " + ClsLocalizationHandler.Losers;
            ui_lblTrades.Text = ClsLocalizationHandler.Trade;
            ui_lblCancelSelectedOrder.Text = ClsLocalizationHandler.Cancel+ " "+ ClsLocalizationHandler.Order;
        }

        /// <summary>
        /// Applys the hot key on textboxes
        /// </summary>
        public void SetHotkeys()
        {
            Action A = () =>
                           {
                               foreach (Control item in ui_npnlHotKeysSettings.Controls)
                               {
                                   if (item.GetType() == typeof (UctlHotKeyTextBox))
                                   {
                                       item.Text = _hotKeySettingsHashTable[item.Name].ToString();
                                   }
                               }
                           };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        /// <summary>
        /// This method load default hotkey
        /// </summary>
        private void SetHotKeyText()
        {
            foreach (Control ctrl in ui_npnlHotKeysSettings.Controls)
            {
                if (ctrl is UctlHotKeyTextBox && _hotKeySettingsHashTable.ContainsKey(ctrl.Name))
                {
                    ctrl.Text = _hotKeySettingsHashTable[ctrl.Name].ToString();
                    if (((UctlHotKeyTextBox) ctrl).IsCreated == false)
                    {
                        ((UctlHotKeyTextBox) ctrl).OnNewHotKey += txtbx_OnNewHotKey;
                    }
                    ((UctlHotKeyTextBox) ctrl).IsCreated = true;
                }
            }
        }

        #endregion   "        METHODS          "

        /// <summary>
        /// Provides hastable of hotkeys
        /// </summary>
        /// <returns></returns>
        public Hashtable GetHotKeysSetting()
        {
            Hashtable retunrhotKeySettingsHashTable = null;
            retunrhotKeySettingsHashTable = new Hashtable();
            foreach (Control ctrl in ui_npnlHotKeysSettings.Controls)
            {
                if (ctrl is UctlHotKeyTextBox)
                {
                    retunrhotKeySettingsHashTable.Add(ctrl.Name, ctrl.Text);
                }
            }
            //_hotKeySettingsHashTable = retunrhotKeySettingsHashTable;
            return _hotKeySettingsHashTable;
        }

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlHotKeysSettings_Load(object sender, EventArgs e)
        {
            //SetLocalization();
        }

        /// <summary>
        /// Handles new hot key entry in textboxes
        /// </summary>
        /// <param name="sender">TextBox name</param>
        /// <param name="key">HotKey name</param>
        private void txtbx_OnNewHotKey(UctlHotKeyTextBox sender, string key)
        {
            if (key == NONE_HOTEKEY)
            {
                _hotKeySettingsHashTable[sender.Name] = key;
                return;
            }
            if (_hotKeySettingsHashTable.ContainsValue(key))
            {
                sender.ShortCut = sender.PrevTextValue;
                MessageBox.Show("This hotkey is already defined", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _hotKeySettingsHashTable[sender.Name] = key;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_npnlHotKeysSettings_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>HotKey settings</returns>
        public clsHotKeySettings GetValues()
        {
            var objclsHotKeySettings = new clsHotKeySettings();

            objclsHotKeySettings.PlaceBuyOrderHotKey = PLACE_BUY_ORDER.Text;
            objclsHotKeySettings.PlaceSellOrderHotKey = PLACE_SELL_ORDER.Text;
            objclsHotKeySettings.OrderBookHotKey = ORDER_BOOK.Text;
            objclsHotKeySettings.MarketWatchHotKey = MARKET_WATCH.Text;
            objclsHotKeySettings.FilterHotKey = FILTER.Text;
            objclsHotKeySettings.MarketPictureHotKey = MARKET_PICTURE.Text;
            objclsHotKeySettings.TradesHotKey = TRADE.Text;
            objclsHotKeySettings.ModifiedTradesHotKey = MODIFIED_TRADES.Text;
            objclsHotKeySettings.MessageLogHotKey = MESSAGE_LOG.Text;
            objclsHotKeySettings.LoginHotKey = LOGIN.Text;
            objclsHotKeySettings.LogoffHotKey = LOGOFF.Text;
            objclsHotKeySettings.FilterBarHotKey = FILTER_BAR.Text;
            objclsHotKeySettings.PreferencesHotKey = PREFERENCES.Text;
            objclsHotKeySettings.LockWorkstationHotKey = LOCK_WORKSTATION.Text;
            objclsHotKeySettings.NetPositionHotKey = NET_POSITION.Text;
            objclsHotKeySettings.SnapQuoteHotKey = SNAP_QUOTE.Text;
            objclsHotKeySettings.PortfolioHotKey = PORTFOLIO.Text;
            objclsHotKeySettings.ModifyOrderHotKey = MODIFY_ORDER.Text;
            objclsHotKeySettings.CancelAllOrdersHotKey = CANCEL_ALL_ORDERS.Text;
            objclsHotKeySettings.ContractInformationHotKey = CONTRACT_INFORMATION.Text;
            objclsHotKeySettings.TickerHotKey = TICKER.Text;
            objclsHotKeySettings.TopGainersLosersHotKey = TOP_GAINERS_LOSERS.Text;
            objclsHotKeySettings.StatusBarHotKey = STATUS_BAR.Text;

            return objclsHotKeySettings;
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="HotKeysSettings">Sotred settings</param>
        public void SetValues(clsHotKeySettings HotKeysSettings)
        {
            PLACE_BUY_ORDER.Text = HotKeysSettings.PlaceBuyOrderHotKey;
            PLACE_SELL_ORDER.Text = HotKeysSettings.PlaceSellOrderHotKey;
            ORDER_BOOK.Text = HotKeysSettings.OrderBookHotKey;
            MARKET_WATCH.Text = HotKeysSettings.MarketWatchHotKey;
            FILTER.Text = HotKeysSettings.FilterHotKey;
            MARKET_PICTURE.Text = HotKeysSettings.MarketPictureHotKey;
            TRADE.Text = HotKeysSettings.TradesHotKey;
            MODIFIED_TRADES.Text = HotKeysSettings.ModifiedTradesHotKey;
            MESSAGE_LOG.Text = HotKeysSettings.MessageLogHotKey;
            LOGIN.Text = HotKeysSettings.LoginHotKey;
            LOGOFF.Text = HotKeysSettings.LogoffHotKey;
            FILTER_BAR.Text = HotKeysSettings.FilterBarHotKey;
            PREFERENCES.Text = HotKeysSettings.PreferencesHotKey;
            LOCK_WORKSTATION.Text = HotKeysSettings.LockWorkstationHotKey;
            NET_POSITION.Text = HotKeysSettings.NetPositionHotKey;
            SNAP_QUOTE.Text = HotKeysSettings.SnapQuoteHotKey;
            PORTFOLIO.Text = HotKeysSettings.PortfolioHotKey;
            MODIFY_ORDER.Text = HotKeysSettings.ModifyOrderHotKey;
            CANCEL_ALL_ORDERS.Text = HotKeysSettings.CancelAllOrdersHotKey;
            CONTRACT_INFORMATION.Text = HotKeysSettings.ContractInformationHotKey;
            TICKER.Text = HotKeysSettings.TickerHotKey;
            TOP_GAINERS_LOSERS.Text = HotKeysSettings.TopGainersLosersHotKey;
            STATUS_BAR.Text = HotKeysSettings.StatusBarHotKey;
        }


        //public void RestoreDefaultClick()
        //{
        //    string dirPath;
        //    dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "PALSA\\Setting\\Hotekey.palsa";
        //    string HotKeyFile = Path.GetDirectoryName(dirPath);
        //    if (System.IO.Directory.Exists(HotKeyFile))
        //    {
        //        System.IO.Stream streamWrite = System.IO.File.Open(dirPath, System.IO.FileMode.Truncate, System.IO.FileAccess.Write);

        //    }
        //    _hotKeySettingsHashTable = null;

        //    foreach (Control ctrl in this.ui_npnlHotKeysSettings.Controls)
        //    {
        //        if (ctrl.GetType() == typeof(uctlHotKeyTextBox))
        //        {
        //            ctrl.Text = "";

        //        }

        //    }
        //    _hotKeySettingsHashTable = Cls.clsDefaultHotKeySettings.GetDefaultHotKeySettings();
        //    SetHotKeyText();
        //}
    }
}