﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CommonLibrary.Cls;
using System.ComponentModel;

namespace CommonLibrary.UserControls
{
    public partial class uctlQuickOrderContainer : UctlBase
    {

        #region "     EVENTS       "
        public event Action<string, string, double, double> OnSellMarketClick=delegate{};
        public event Action<string, string, double, double> OnSellClick=delegate{};
        public event Action OnCloseClick=delegate{};
        public event Action<string, string, double, double> OnBuyMarketClick=delegate{};
        public event Action<string, string, double, double> OnBuyClick=delegate{};

        public event Action<string> OnScriptPortfolioApplyClick = delegate { };
        public event Action<string> OnScriptPortfolioModifyClick = delegate { };
        public event Action<string> OnScriptPortfolioRemoveClick = delegate { };
        #endregion "     EVENTS       "

        #region "         MEMBERS        "

        private const int iColorCount_ = 19;
        private const int PairSpacing = 4;
        private static List<string> SupportedSymbols_;
        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        private readonly List<uctlQuickOrderButton> lstForexPair_ = new List<uctlQuickOrderButton>();
        private Dictionary<string, uctlQuickOrderButton> DDForexPair = new Dictionary<string, uctlQuickOrderButton>();
        //private readonly List<uctlQuickOrderButton> lstQuickOrder = new List<uctlQuickOrderButton>();
        private string _currentPortfolioName = string.Empty;
        private List<string> _lstSymbolArray = new List<string>();
        private Color[] arrForexPairColors = new Color[iColorCount_];
        //public bool isSubscriberConnected = false;
        //public bool isSubscriberLogin = false;
        private string _account = string.Empty;
        BackgroundWorker bgChart = new BackgroundWorker();
        private bool isAmountinLot_;
        private bool isAskInLeftSide_;
        public bool isLoadDefaultColor_ = true;

        #endregion "       MEMBERS      "

        #region    "       PROPERTY     "

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        /// <summary>
        /// Sets and gets the current portfolioName of the market watch 
        /// </summary>
        public string CurrentPortfolioName
        {
            get { return _currentPortfolioName; }
            set { _currentPortfolioName = value; }
        }

        public object Portfolios { get; set; }


        /// <summary>
        /// this property is true for default color
        /// </summary>
        public bool isLoadDefaultColor
        {
            get { return isLoadDefaultColor_; }
            set { isLoadDefaultColor_ = value; }
        }

        /// <summary>
        /// Properties indicating the positions of Buy and Sell in ForexPairs present on the Forex control
        /// </summary>
        public bool isAskInLeftSide
        {
            get { return isAskInLeftSide_; }
            set
            {
                isAskInLeftSide_ = value;
                SetAllPairsBuySellPosition(isAskInLeftSide_);
            }
        }

        /// <summary>
        /// True for order amount in lots and False for order amount in units
        /// </summary>
        public bool isAmountinLot
        {
            get { return isAmountinLot_; }
            set
            {
                isAmountinLot_ = value;
                lock (lstForexPair_)
                {
                    if (isAmountinLot_)
                    {
                        for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
                        {
                            //lstForexPair_[n].setAmountList(GetLotAmountArray());
                        }
                    }
                    else
                    {
                        for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
                        {
                            //lstForexPair_[n].setAmountList(GetDefaultAmountArray());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// True to send Sell order on single click false to send order on double click
        /// </summary>
        public bool isSellOnSingleClick { get; set; }

        /// <summary>
        /// True to send Buy order on single click false to send order on double click
        /// </summary>
        public bool isBuyOnSingleClick { get; set; }

        #endregion  "       PROPERTY     "

        public uctlQuickOrderContainer()
        {
            InitializeComponent();
            _currentPortfolioName = string.Empty;
        }

        public void ApplyForexPairSettings(ClsForexPair forexPair)
        {
            foreach (uctlQuickOrderButton item in lstForexPair_)
            {
                item.BackColor = forexPair.BackColor;
                //item.OrderFormSettings = forexPair.OrderFormSetting;
                //item.PositionSizeType = forexPair.PositionSizeType;
                //if (forexPair.PositionSizeType == 1)
                //{
                //    item.setAmountList(GetLotAmountArray());
                //}
                //else
                //{
                //    item.setAmountList(GetDefaultAmountArray());
                //}
            }
        }

        //Clears any existing pairs and initializes new pairs

        /// <summary>
        /// Adds the ForexPair control for all Symbols (called when the Forex control is to be loaded)
        /// </summary>
        /// <param name="ddKeySymbol"></param>
        public void InitializePairs(Dictionary<string, string> ddKeySymbol)
        {
          
            //_lstSymbolArray = Pairs;
            //Clear pairs
            int n;
            for (n = 0; n < lstForexPair_.Count; n++)
            {
                lstForexPair_.Remove(lstForexPair_[n]);
            }
            //Add new pairs        
            //for (n = 0; n < Pairs.Count; n++)
            //{
            //    AddForexPair(Pairs[n]);

            //}
            foreach (var item in ddKeySymbol)
            {
                AddForexPair(item.Key, item.Value);
            }
            Width = Width + 1;
        }

        /// <summary>
        /// Order Forexpair controls in rows and columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlQuickOrderContainer_Resize(object sender, EventArgs e)
        {
            //int x = 0;
            //int y = 0;
            //for (short n = 0; n < lstForexPair_.Count; n++)
            //{
            //    if ((x + lstForexPair_[n].Width) > Width)
            //    {
            //        y += (lstForexPair_[n].Height + PairSpacing);
            //        x = 0;
            //    }
            //    lstForexPair_[n].Left = x;
            //    lstForexPair_[n].Top = y;
            //    x += (lstForexPair_[n].Width + PairSpacing);
            //}
        }

        /// <summary>
        /// Returns the ForexPair Control object corresponding to give symbol "PairName"
        /// </summary>
        /// <param name="PairName">symbol name for the ForexPair control</param>
        /// <returns></returns>
        private uctlQuickOrderButton GetPair(string PairName)
        {
            for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
            {
                if (lstForexPair_[n].Symbol == PairName)
                {
                    return lstForexPair_[n];
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the ForexPair Control objects corresponding to give symbol "PairName"
        /// </summary>
        /// <param name="PairName">symbol name for the ForexPair controls</param>
        /// <returns></returns>
        private List<uctlQuickOrderButton> GetPairs(string PairName)
        {
            var lstForex = new List<uctlQuickOrderButton>();
            for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
            {
                if (lstForexPair_[n].Symbol == PairName)
                {
                    lstForex.Add(lstForexPair_[n]);
                }
            }
            return lstForex;
        }

        /// <summary>
        /// Adds the ForexPair control corresponding to symbol to the Forex control
        /// </summary>
        /// <param name="key"></param>
        /// <param name="symbol">symbol corresponding to which the ForexPair control is to be added</param>
        /// <returns></returns>
        public bool AddForexPair(string key, string symbol)
        {
            ////if(GetPair(symbol) != null)
            //// return false;            
            //var pair = new UctlForexPair(key, symbol) {Parent = this, Visible = true};
            var pair = new uctlQuickOrderButton(key, symbol) { Parent = this, Visible = true };
            //pair.CurrentAccount = _account;
            pair.OnBuyClick += new Action<string, string, double, double>(pair_OnBuyClick);
            pair.OnBuyMarketClick += new Action<string, string, double, double>(pair_OnBuyMarketClick);
            pair.OnCloseClick += new Action(pair_OnCloseClick);
            pair.OnSellClick += new Action<string, string, double, double>(pair_OnSellClick);
            pair.OnSellMarketClick += new Action<string, string, double, double>(pair_OnSellMarketClick);
           
                if (DDForexPair != null)
                { lock (DDForexPair)
                    {
                    if (!DDForexPair.Keys.Contains(key))
                    {
                        DDForexPair.Add(key, pair);
                    }
                    else
                    {
                        DDForexPair[key] = pair;
                    }
                    }
                 }
            //pair.OnOrderEntryDialogOpen += pair_OnOrderEntryDialogOpen;
            //pair.OnOrderSend += pair_OnOrderSend;
            //if (isLoadDefaultColor_)
            //pair.ResetToDefaultColorScheme();
            //else
            //{
            //}
            ////pair.setColorScheme(Initializer.GetReference().objSettingForm_.ColorSchemeArray_,Initializer.GetReference().objSettingForm_.BackColor_);
            ////if (isAskInLeftSide_)
            ////    pair.setAskInLeftSide();
            ////else
            ////    pair.setAskInRightSide();

            ////if (symbol.Substring(3).Contains("JPY"))
            ////{
            ////    pair.RoundOff = 2;
            ////    pair.MultipliedValue = 100;                
            ////}
            //if (isAmountinLot)
            //{
            //    pair.setAmountList(GetLotAmountArray());
            //}
            //else
            //    pair.setAmountList(GetDefaultAmountArray());

            ////pair.setSymbolList(_lstSymbolArray);

            lstForexPair_.Add(pair);
            Action A = () =>
            {
                flowLayoutPanel1.Controls.Add(pair);
                //Controls.Add(pair);
                //Refresh();
            };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
            return true;
        }

        void pair_OnSellMarketClick(string key, string account, double price, double qty)
        {
            //key,account,price,qty
            OnSellMarketClick(key, account, price, qty);
        }

        void pair_OnSellClick(string key, string account, double price, double qty)
        {
            OnSellClick(key, account, price, qty);
        }

        void pair_OnCloseClick()
        {
            OnCloseClick();
        }

        void pair_OnBuyMarketClick(string key, string account, double price, double qty)
        {
            OnBuyMarketClick(key, account, price, qty);
        }

        void pair_OnBuyClick(string key, string account, double price, double qty)
        {
            OnBuyClick(key, account, price, qty);
        }

        /// <summary>
        /// Displays dialog for adding and removing of ForexPair controls to Forex control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddRemoveForexPair(GetSymbolArray(), GetVisibleForexPairs());
            frm._isForMarketWatch = false;
            frm.ParentForex = this;
            frm.ShowDialog();
        }

        /// <summary>
        /// Sets the correct no of ForexPair controls to the Forex Control window
        /// </summary>
        /// <param name="SelectedSymbols">List of symbols to which ForexPair control is to be added to Forex control</param>
        public void ChangeSettings(object[] SelectedSymbols)
        {
            bool isAdd = false;
            bool isRemove = false;
            bool isUpdate = false;
            if (SelectedSymbols.Length == lstForexPair_.Count)
                isUpdate = true;
            if (SelectedSymbols.Length > lstForexPair_.Count)
                isAdd = true;
            if (SelectedSymbols.Length < lstForexPair_.Count)
                isRemove = true;

            if (isAdd || isUpdate)
            {
                lock (lstForexPair_)
                {
                    for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
                    {
                        lstForexPair_[n].Symbol = SelectedSymbols[n].ToString();
                    }
                    if (isAdd)
                    {
                        int ControlToBeAdded = SelectedSymbols.Length - lstForexPair_.Count;
                        int StartIndex = lstForexPair_.Count;
                        if (lstForexPair_.Count == 0)
                        {
                            StartIndex = 0;
                        }
                        bool flag = true;
                        int Counter = 1;
                        while (flag)
                        {
                            if (Counter > ControlToBeAdded)
                            {
                                flag = false;
                                continue;
                            }
                            AddForexPair(null, SelectedSymbols[StartIndex].ToString());
                            ++StartIndex;
                            Counter++;
                        }
                    }
                }
            }
            if (isRemove)
            {
                lock (lstForexPair_)
                {
                    for (int n = 0; n < SelectedSymbols.Length; n++)
                        lstForexPair_[n].Symbol = SelectedSymbols[n].ToString();
                    int ControlToBeRemoved = lstForexPair_.Count - SelectedSymbols.Length;
                    for (int n = 0; n < ControlToBeRemoved; n++)
                    {
                        //UctlForexPair pair = null;
                        uctlQuickOrderButton pair = null;
                        pair = lstForexPair_[lstForexPair_.Count - 1];
                        lstForexPair_.Remove(pair);
                        Controls.Remove(pair);
                        pair = null;
                    }
                }
            }
            //uctlQuickOrderContainer_Resize(null, null);
        }

        /// <summary>
        /// Contians functionality when control is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlQuickOrderContainer_Load(object sender, EventArgs e)
        {
            List<string> lst = GetSymbolArray();
            foreach (string item in lst)
            {
                //QuoteManager.getQuoteManager().AddQuoteWatchItem(item, this);
            }
        }

        /// <summary>
        /// Removes the ForexPair control corresponding to symbol to the Forex control
        /// </summary>
        /// <param name="symbol">symbol corresponding to which the ForexPair control is to be Removed</param>
        /// <returns></returns>
        public bool RemoveForexPair(string symbol)
        {
            //UctlForexPair forexpair = null;
            uctlQuickOrderButton forexpair = null;
            forexpair = GetPair(symbol);

            if (forexpair == null)
                return false;

            Controls.Remove(forexpair);
            lstForexPair_.Remove(forexpair);
            forexpair = null;

            return false;
        }

        /// <summary>
        /// Provides list of amounts corresponding to units (0.1 lot = 10,000 units) to which the order is to be send
        /// </summary>
        /// <returns>list of order availble amounts</returns>
        public string[] GetDefaultAmountArray()
        {
            //Later we will fill from XML or some setting file
            var strArray = new string[10];
            for (int i = 1; i <= 10; i++)
            {
                int num = 10000 * i;
                strArray[i - 1] = num.ToString();
            }
            return strArray;
        }

        /// <summary>
        /// Provides list of amounts corresponding to lot value to which the order is to be send
        /// </summary>
        /// <returns></returns>
        public string[] GetLotAmountArray()
        {
            var strArray = new string[10];
            for (int i = 1; i <= 10; i++)
            {
                int num = 10000 * i;
                double lot = num / 100000.0;
                strArray[i - 1] = lot.ToString();
            }
            return strArray;
        }

        /// <summary>
        /// Provides the list of symbols corresponding to visible ForexPair controls
        /// </summary>
        /// <returns>List of symbols</returns>
        public List<string> GetVisibleForexPairs()
        {
            var lstSymbols = new List<string>();
            for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
            {
                lstSymbols.Add(lstForexPair_[n].Symbol);
            }
            return lstSymbols;
        }

        /// <summary>
        /// Provides the list of symbols corresponding to object array
        /// </summary>
        /// <returns></returns>
        public static object[] GetSymbolObjectArray()
        {
            if (SupportedSymbols_ != null)
            {
                if (SupportedSymbols_.Count == 0)
                    LoadSupportedSymbols();
            }
            LoadSupportedSymbols();
            return SupportedSymbols_.ToArray();
        }

        /// <summary>
        /// Provides list of symbols
        /// </summary>
        /// <returns>List of symbols</returns>
        public static List<string> GetSymbolArray()
        {
            if (SupportedSymbols_ != null)
            {
                if (SupportedSymbols_.Count == 0)
                    LoadSupportedSymbols();

                return SupportedSymbols_.ToList();
            }
            LoadSupportedSymbols();

            return SupportedSymbols_.ToList();
        }

        /// <summary>
        /// Reads symbols from the text file and store them to SupportedSymbols_ list
        /// </summary>
        public static void LoadSupportedSymbols()
        {
            try
            {
                SupportedSymbols_ = null;
                SupportedSymbols_ = new List<string>();
                var sr = new StreamReader(Application.StartupPath + @"\Resources\symbols.txt");

                while (!sr.EndOfStream)
                {
                    string symbol = sr.ReadLine();
                    symbol = symbol.Trim();
                    if (symbol.Contains('/'))
                        symbol = symbol.Remove(symbol.IndexOf('/'), 1);
                    SupportedSymbols_.Add(symbol);
                }
                sr.Close();
                sr = null;
            }
            catch (Exception ex)
            {
                string threadID = Thread.CurrentThread.ManagedThreadId.ToString();
                string strException = "Module: " + "uctlForex" +
                                      "Method: " + "LoadSupportedSymbols()" +
                                      "Thread ID: " + threadID +
                                      "Message: " + ex.Message +
                                      "StackTrace:" + ex.StackTrace;
                //Logger.LogEx(ex, "uctlForex", " LoadSupportedSymbols()");
            }
        }

        /// <summary>
        /// This method sets the visibility of arrow
        /// </summary>
        /// <param name="isVisible"></param>
        public void SetArrowVisibility(bool isVisible)
        {
            lock (lstForexPair_)
            {
                for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
                {
                    //lstForexPair_[n].ShowArrowVisibility(isVisible);
                }
            }
        }

        /// <summary>
        /// Sets the Buy and Sell position in all ForexPair controls
        /// </summary>
        /// <param name="isAskInLeftSide"></param>
        private void SetAllPairsBuySellPosition(bool isAskInLeftSide)
        {
            lock (lstForexPair_)
            {
                for (short n = 0; n < lstForexPair_.Count; n = (short)(n + 1))
                {
                    //if (isAskInLeftSide)
                    //lstForexPair_[n].setAskInLeftSide();
                    //else
                    //lstForexPair_[n].setAskInRightSide();
                }
                isAskInLeftSide_ = isAskInLeftSide;
            }
        }

        private void ui_nmnuScriptPortfolio_Click(object sender, EventArgs e)
        {
            var objuctlSelectPortfolio = new UctlSelectPortfolio(Portfolios);

            objuctlSelectPortfolio.SelectedPortfolio = CurrentPortfolioName;
            objuctlSelectPortfolio.OnCancelClick -= objuctlSelectPortfolio_OnCancelClick;
            objuctlSelectPortfolio.OnApplyClick -= objuctlSelectPortfolio_OnApplyClick;
            objuctlSelectPortfolio.OnModifyClick -= objuctlSelectPortfolio_OnModifyClick;
            objuctlSelectPortfolio.OnRemoveClick -= objuctlSelectPortfolio_OnRemoveClick;
            objuctlSelectPortfolio.OnCancelClick += objuctlSelectPortfolio_OnCancelClick;
            objuctlSelectPortfolio.OnApplyClick += objuctlSelectPortfolio_OnApplyClick;
            objuctlSelectPortfolio.OnModifyClick += objuctlSelectPortfolio_OnModifyClick;
            objuctlSelectPortfolio.OnRemoveClick += objuctlSelectPortfolio_OnRemoveClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
            _objfrmDialogForm.Size = objSize;
            objuctlSelectPortfolio.Dock = DockStyle.Fill;
            _objfrmDialogForm.Controls.Add(objuctlSelectPortfolio);
            _objfrmDialogForm.Text = objuctlSelectPortfolio.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            //objfrmDialogForm.CancelButton= 
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
        }

        private void objuctlSelectPortfolio_OnRemoveClick(string portfolioName)
        {
            OnScriptPortfolioRemoveClick(portfolioName);
        }

        private void objuctlSelectPortfolio_OnModifyClick(string portfolioName)
        {
            OnScriptPortfolioModifyClick(portfolioName);
        }

        private void objuctlSelectPortfolio_OnApplyClick(string portfolioName)
        {
            _currentPortfolioName = portfolioName;

            bgChart = null;
            bgChart = new BackgroundWorker();
            bgChart.WorkerSupportsCancellation = true;
            bgChart.DoWork += new DoWorkEventHandler(bgChart_DoWork);
            bgChart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgChart_RunWorkerCompleted);
            bgChart.RunWorkerAsync();

            //_currentPortfolioName = portfolioName;
            //OnScriptPortfolioApplyClick(portfolioName);
            //_objfrmDialogForm.DialogResult = DialogResult.OK;
        }

        void bgChart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void bgChart_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = () =>
            {
                _objfrmDialogForm.DialogResult = DialogResult.OK;
                OnScriptPortfolioApplyClick(_currentPortfolioName);

            };
            if (this.InvokeRequired)
            {
                this.Invoke(a);
            }
            else
            {
                a();
            }
        }

        private void objuctlSelectPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }

        public void UpdateForexPairControl(clsQuotes priceQuote)
        {
            //uctlQuickOrderButton forexPair = lstForexPair_.Find(x => x.Key == updatePrice.ContractInfoKey);
            //if (forexPair != null)
            //{
            //    forexPair.UpdateForexPair(updatePrice);
            //}

            //foreach (uctlForexPair item in lstForexPair_)
            //{
            //    if (item.Key == updatePrice.ContractInfoKey)
            //    {
            //        item.UpdateForexPair(updatePrice);
            //    }
            //}

            //if (System.Threading.Monitor.TryEnter(DDForexPair))
            //{
            //    try
            //    {
                    //foreach (KeyValuePair<string, uctlQuickOrderButton> keyV in DDForexPair.Where(keyV => DDForexPair.Keys.Contains(priceQuote.Key)))
                    //{
            Action A = () =>
                {
                    uctlQuickOrderButton x = null;
                    if (DDForexPair.Count > 0)
                    {
                        //if (DDForexPair[priceQuote.Key].Key.Contains(priceQuote.Key))
                        //{
                        //    x = DDForexPair[priceQuote.Key];
                        //}
                        if (DDForexPair.Keys.Contains(priceQuote.Key))
                        {
                            x = DDForexPair[priceQuote.Key];
                        }
                        if (x != null)
                            x.UpdateValues(priceQuote);
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
                    //}
            //    }
            //    catch
            //    {

            //    }
            //    finally
            //    {
            //        System.Threading.Monitor.Exit(DDForexPair);
            //    }
            //}


            //if (lstForexPair_.Contains(lstForexPair_.Find(A => A.Key == priceQuote.Key)))
            //{
            //    lstForexPair_.Find(A => A.Key == priceQuote.Key).UpdateValues(priceQuote);
            //}
        }
    }
}