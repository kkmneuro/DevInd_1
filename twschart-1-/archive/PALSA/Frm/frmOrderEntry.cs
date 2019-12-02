using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STOCKCHARTXLib;
using Nevron.UI.WinForm.Controls;
using CommonLibrary.UserControls;
using CommonLibrary.Cls;
using PALSA.Cls;


namespace PALSA.Frm
{
    public partial class frmOrderEntry : frmBase //, IQuoteSubscriber, IOrderSubscriber
    {
        /// <summary>
        /// All data Members specified.Review done.
        /// </summary>
        #region MEMBERS

        static frmOrderEntry _frmOrderEntry;

        public static bool IsinitialisedBefore = false;

        Color _color4Buy = Color.FromArgb(160, 192, 255);
        public Color Color4Buy
        {
            get { return _color4Buy; }
            set { _color4Buy = value; }
        }

        Color _color4Sell = Color.FromArgb(255, 128, 128);
        public Color Color4Sell
        {
            get { return _color4Sell; }
            set { _color4Sell = value; }
        }

        string _TitleBarText = "Order";

        public string TitleBarText
        {
            get { return _TitleBarText; }
            set
            {
                _frmOrderEntry.Text = _TitleBarText = value;
            }
        }
        public static frmOrderEntry INSTANCE
        {
            get
            {
                if (_frmOrderEntry == null)
                {
                    _frmOrderEntry = new frmOrderEntry();
                }
                return _frmOrderEntry;
            }
            set { _frmOrderEntry = value; }
        }
        double dChartYValue_ = 0.0;
        double _askPrice = 0.0;
        double _bidPrice = 0.0;
        string strSelectedSymbol_ = string.Empty;
        string selectedKey = string.Empty;
        bool isVolumeinLot_ = true;
        double dDefaultSL_ = 0.0;
        double dDefaultTP_ = 0.0;
        double dDefaultVolume_ = 0.0;
        //public Cls.clsOrderFunctions OrderUtility_ = new GTS.Cls.clsOrderFunctions();
        public OrderChildControl childControl = null;
        OrderChildControl previousChildControl = null;

        //For Stock chart
        private const int TPlineIndex = 1;
        private const int SLlineIndex = 0;
        private const int PriceLineIndex = 2;
        public CommonLibrary.Cls.ClsOrderEntryInfo CurrentOrder = null;
        public CommonLibrary.Cls.ClsGlobal.OrderMode mode = 0;
        uctlOrderExecutionStatus _orderExecutionStatus = new uctlOrderExecutionStatus();
        //public DS4Orders.OrdersRow ReferenceOrderRow = null;

        public bool IsReverse = false;
        bool isSetDefaultValues = false;

        const string cbTypeMarketExecution = "Market Execution";
        const string cbTypePending = "Pending Order";
        const string cbTypeModify = "Modify Order";
        private DataGridViewRow selectedRow;
        private CommonLibrary.Cls.ClsGlobal.OrderMode orderMode;


        #endregion
        /// <summary>
        /// Main entry Point.Review done.
        /// </summary>
        /// <param name="symbol"></param>
        #region EntryPoint
        public static void OpenOrderEntry(string symbol)
        {
            if (IsinitialisedBefore == false)
            {
                IsinitialisedBefore = true;
                _frmOrderEntry = new frmOrderEntry();
                _frmOrderEntry.CurrentOrder = new ClsOrderEntryInfo();
                _frmOrderEntry.childControl = new uctlMarketExecution();
                _frmOrderEntry.strSelectedSymbol_ = symbol;
                _frmOrderEntry.isSetDefaultValues = true;
                _frmOrderEntry.loadChildControl(5);
                _frmOrderEntry.SetSL_TPBehaviour();
                _frmOrderEntry.setControlsValue(); //side doesn't matter here
                _frmOrderEntry.cbType.SelectedIndex = 0;
                _frmOrderEntry.Show();
            }
        }
        //public static void OpenOrderEntry(string symbol,clsInterface4OME.OrderType type,Side side,decimal Price)
        //{
        //    if (IsinitialisedBefore == false)
        //    {
        //        IsinitialisedBefore = true;
        //        _frmOrderEntry = new frmOrderEntry();
        //        _frmOrderEntry.CurrentOrder = new ProtocolStructs.NewOrderRequest();
        //        _frmOrderEntry.childControl = new GTS.Ctrl.ucMarketExecution(_frmOrderEntry);
        //        _frmOrderEntry.strSelectedSymbol_ = symbol;
        //        _frmOrderEntry.isSetDefaultValues = true;
        //        _frmOrderEntry.setControlsValue(side);
        //        _frmOrderEntry.cbType.SelectedIndex = 1;
        //        _frmOrderEntry.loadChildControl(type,side,Price);                
        //        _frmOrderEntry.SetSL_TPBehaviour();               
        //        _frmOrderEntry.Show();
        //    }
        //}
        //public static void OpenOrderEntry(DS4Orders.OrdersRow OrderRow, OrderRequestType requestType)
        //{
        //    if (IsinitialisedBefore == false)
        //    {
        //        IsinitialisedBefore = true;
        //        _frmOrderEntry = new frmOrderEntry();
        //    }
        //    if (_frmOrderEntry.CurrentOrder == null)
        //    {
        //        _frmOrderEntry.CurrentOrder = new ProtocolStructs.NewOrderRequest();
        //    }
        //    _frmOrderEntry.isSetDefaultValues = false;
        //    _frmOrderEntry.isVolumeinLot_ = Initializer.GetReference().objSettingForm_.bisPositionSizeInLot_;
        //    _frmOrderEntry.strSelectedSymbol_ = OrderRow.Instrument;
        //    _frmOrderEntry.ReferenceOrderRow = OrderRow;
        //    Side side = (Side)Enum.Parse(typeof(Side), OrderRow.Side, true);
        //    switch (requestType)
        //    {
        //        case OrderRequestType.CANCELLED:
        //            break;
        //        case OrderRequestType.CLOSED:
        //            _frmOrderEntry.childControl = new GTS.Ctrl.ucMarketExecution(_frmOrderEntry);
        //            _frmOrderEntry.dDefaultVolume_ = _frmOrderEntry.getFormattedVolume(OrderRow.QuantityFilled);
        //            _frmOrderEntry.setControlsValue(side);
        //            _frmOrderEntry.cbType.SelectedIndex = 0;
        //            break;
        //        case OrderRequestType.MODIFIED:
        //            if (OrderRow.QuantityFilled > 0)
        //            {
        //                _frmOrderEntry.childControl = new GTS.Ctrl.ucModifyFill(_frmOrderEntry);
        //                _frmOrderEntry.dDefaultVolume_ = _frmOrderEntry.getFormattedVolume(OrderRow.QuantityFilled);                       
        //            }
        //            else
        //            {
        //                _frmOrderEntry.childControl = new GTS.Ctrl.ucModifyPending(_frmOrderEntry);
        //                _frmOrderEntry.dDefaultVolume_ = _frmOrderEntry.getFormattedVolume(OrderRow.Quantity);
        //            }
        //            _frmOrderEntry.dDefaultSL_ = OrderRow.StopLoss;
        //            _frmOrderEntry.dDefaultTP_ = OrderRow.TakeProfit;
        //            _frmOrderEntry.setControlsValue(side);
        //            _frmOrderEntry.cbType.SelectedIndex = 2;
        //            break;
        //        case OrderRequestType.NA:
        //            break;
        //        case OrderRequestType.NEW:
        //            _frmOrderEntry.childControl = new GTS.Ctrl.ucMarketExecution(_frmOrderEntry);
        //            _frmOrderEntry.setControlsValue(side);
        //            _frmOrderEntry.cbType.SelectedIndex = 0;
        //            break;
        //        case OrderRequestType.SLTP_URG_CLOSED:
        //            break;
        //        default:
        //            break;
        //    }
        //    _frmOrderEntry.loadChildControl();
        //    _frmOrderEntry.SetSL_TPBehaviour();

        //    _frmOrderEntry.Show();
        //}
        #endregion

        /// <summary>
        /// To prevent from making object.Review done.
        /// </summary>
        public frmOrderEntry()
        {
            InitializeComponent();
            StockChartX1.ScalePrecision = 5;//Kul
        }
        private int digits = 5;
        public frmOrderEntry(string Sym)//By Kuldeep
        {

            InitializeComponent();
            this.TopMost = true;

            CurrentOrder = new ClsOrderEntryInfo();
            string currentPortfolio = PALSA.Cls.ClsGlobal.CurrentPortfolio;
            cbSymbol.Items.Clear();
            if (currentPortfolio != string.Empty)
            {
                cbSymbol.Items.AddRange(FrmMain.INSTANCE.GetSymbolsOfPortfolio(currentPortfolio).ToArray());

                cbSymbol.SelectedIndex = cbSymbol.Items.IndexOf(Sym);
                this.orderMode = CommonLibrary.Cls.ClsGlobal.OrderMode.NEW;
            }
            
            Symbol sym;
            sym = Symbol.GetSymbol(selectedKey);
            CurrentOrder.GatewayName = sym.Gateway;
            CurrentOrder.ProductName = sym.Product;
            CurrentOrder.ProductType = sym.ProductType;
            CurrentOrder.Symbol = sym.Contract;
            //By Kuldeep
            CurrentOrder.StopLoss = (double)cmbSL.Value;
            CurrentOrder.TakeProfit = (double)cmbTP.Value;

            if (Properties.Settings.Default.MinOrderQty > 0)
            {
                dDefaultVolume_ = Properties.Settings.Default.MinOrderQty;
            }
            else
            {
                dDefaultVolume_ = 1;
            }
            //Namo 21 March
            //InstrumentSpec inst = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
            //Cls.ClsGlobal.StopLevel = inst.Limit_Stop_Level / Math.Pow(10, inst.Digits);
            childControl = new uctlMarketExecution();
            //Namo 21 March
            // loadChildControl(inst.Digits);
            setControlsValue();
            List<Symbol> lstSymbol = new List<Symbol>();
            List<string> SymbolsKeys = FrmMain.INSTANCE.GetKeysOfPortfolio(currentPortfolio);
            foreach (string key in SymbolsKeys)
            {
                Symbol sym1 = Symbol.GetSymbol(key);
                lstSymbol.Add(sym1);
            }
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.SubscribeMarket(true, ClientDLL_Model.Cls.eMarketRequest.MARKET_QUOTE_REQUEST, lstSymbol);
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            ////clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += new Action<ClientDLL_Model.Cls.Order.ExecutionReport>(INSTANCE_DoHandleExecutionReport);
            //clsTWSOrderManagerJSON.INSTANCE.SendMessage += new Action<string>(INSTANCE_SendMessage);
        }

        public frmOrderEntry(DataGridViewRow selectedRow, CommonLibrary.Cls.ClsGlobal.OrderMode orderMode)
        {
            InitializeComponent();
            this.TopMost = true;
            string currentPortfolio = PALSA.Cls.ClsGlobal.CurrentPortfolio;
            CurrentOrder = new ClsOrderEntryInfo();
            string contractName = string.Empty;
            if (orderMode != CommonLibrary.Cls.ClsGlobal.OrderMode.NEW)
            {
                contractName = selectedRow.Cells["clmContract"].Value.ToString();
            }
            else
            {
                contractName = selectedRow.Cells["ClmContractName"].Value.ToString();
            }           
                //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(contractName, selectedRow.Cells["clmProductType"].Value.ToString(), selectedRow.Cells["clmProductName"].Value.ToString());
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contractName];
            digits = instspec.Digits;
                Cls.ClsGlobal.StopLevel = instspec.Limit_Stop_Level / Math.Pow(10, instspec.Digits);
                this.strSelectedSymbol_ = contractName;

                cbSymbol.Items.Clear();
                if (currentPortfolio != string.Empty)
                {
                    cbSymbol.Items.AddRange(FrmMain.INSTANCE.GetSymbolsOfPortfolio(currentPortfolio).ToArray());
                }
                Symbol sym;
                if (selectedRow != null)
                {
                    //CurrentOrder.ExpiryDate = selectedRow.Cells["ClmExpiry"].Value.ToString();
                    cbSymbol.SelectedIndex = cbSymbol.Items.IndexOf(contractName);
                    this.selectedRow = selectedRow;
                    this.orderMode = orderMode;
                }
                else
                {
                    cbSymbol.SelectedIndex = 0;
                }
                setControlsValue();
                if (orderMode == CommonLibrary.Cls.ClsGlobal.OrderMode.NEW)
                {

                    sym = Symbol.GetSymbol(selectedKey);

                    CurrentOrder.GatewayName = sym.Gateway;
                    CurrentOrder.ProductName = sym.Product;
                    CurrentOrder.ProductType = sym.ProductType;
                    CurrentOrder.Symbol = sym.Contract;
                    //By Kuldeep
                    CurrentOrder.StopLoss = (double)cmbSL.Value;
                    CurrentOrder.TakeProfit = (double)cmbTP.Value;

                    //if (Properties.Settings.Default.MinOrderQty > 0)
                    //{
                    //    dDefaultVolume_ = Properties.Settings.Default.MinOrderQty;
                    //}
                    //else
                    //{
                    //    dDefaultVolume_ = 1;
                    //}
                    childControl = new uctlMarketExecution();
                    loadChildControl(instspec.Digits);
                    txtVolume.Enabled = true;
                }
                else
                {
                    txtVolume.Enabled = false;
                    cbType.SelectedIndex = cbType.Items.IndexOf(cbTypeModify.ToString());
                    txtSL.Enabled = false;
                    txtTP.Enabled = false;
                    cbType.Enabled = false;
                    if (selectedRow.Cells["clmStatus"].Value.ToString().ToUpper() == "FILLED")
                    {
                        childControl = new uctlModifyFill();
                        ((uctlModifyFill)childControl).updateSLTP(selectedRow.Cells["clmSLPrice"].Value.ToString() ?? "0", selectedRow.Cells["clmTPPrice"].Value.ToString() ?? "0");
                        loadChildControl(instspec.Digits);
                        int i = cbVolume.Items.IndexOf(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
                        if (i >= 0)
                            cbVolume.SelectedIndex = i;
                        txtVolume.Text = selectedRow.Cells["clmOrderQuantity"].Value.ToString();

                        if (selectedRow.Cells["clmSLPrice"].Value != null && !String.IsNullOrEmpty(selectedRow.Cells["clmSLPrice"].Value.ToString()))
                        {
                            //cmbSL.Value = Convert.ToDecimal(selectedRow.Cells["clmSLPrice"].Value.ToString());
                            txtSL.Text = selectedRow.Cells["clmSLPrice"].Value.ToString();
                        }
                        else
                        {
                            //cmbSL.Value = 0;
                            txtSL.Text = "0";
                        }
                        if (selectedRow.Cells["clmTPPrice"].Value != null && !String.IsNullOrEmpty(selectedRow.Cells["clmTPPrice"].Value.ToString()))
                        {
                            //cmbTP.Value = Convert.ToDecimal(selectedRow.Cells["clmTPPrice"].Value.ToString());
                            txtTP.Text = selectedRow.Cells["clmTPPrice"].Value.ToString();
                        }
                        else
                        {
                            //cmbTP.Value = 0;
                            txtTP.Text = "0";
                        }
                    }
                    else if (selectedRow.Cells["clmStatus"].Value.ToString().ToUpper() == "WORKING")
                    {
                        childControl = new uctlModifyPending(this);
                        string slPrice = "0.00";
                        string tpPrice = "0.00";
                        if (selectedRow.Cells["clmSLPrice"].Value.ToString() != string.Empty)
                            slPrice = selectedRow.Cells["clmSLPrice"].Value.ToString();
                        if (selectedRow.Cells["clmTPPrice"].Value.ToString() != string.Empty)
                            tpPrice = selectedRow.Cells["clmTPPrice"].Value.ToString();
                        ((uctlModifyPending)childControl).Price = selectedRow.Cells["clmPrice"].Value.ToString();
                        ((uctlModifyPending)childControl).SLPrice = slPrice;
                        ((uctlModifyPending)childControl).TPPrice = tpPrice;
                        loadChildControl(instspec.Digits);
                    }
                    AttachEventHandelers(childControl);
                }
                List<Symbol> lstSymbol = new List<Symbol>();
                List<string> SymbolsKeys = FrmMain.INSTANCE.GetKeysOfPortfolio(currentPortfolio);
                foreach (string key in SymbolsKeys)
                {
                    Symbol sym1 = Symbol.GetSymbol(key);
                    lstSymbol.Add(sym1);
                }
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.SubscribeMarket(true, ClientDLL_Model.Cls.eMarketRequest.MARKET_QUOTE_REQUEST, lstSymbol);
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            ////clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += new Action<ClientDLL_Model.Cls.Order.ExecutionReport>(INSTANCE_DoHandleExecutionReport);
            //clsTWSOrderManagerJSON.INSTANCE.SendMessage -= new Action<string>(INSTANCE_SendMessage);
            //clsTWSOrderManagerJSON.INSTANCE.SendMessage += new Action<string>(INSTANCE_SendMessage);
            this.Select();
        }

        void INSTANCE_SendMessage(string obj)
        {

            Action a = () =>
                        {
                            if (gbParent.Controls[0] is uctlOrderExecutionStatus)
                            {
                                _orderExecutionStatus.updateMessage(obj);
                            }
                            else
                            {
                                gbParent.Controls.Clear();
                                gbParent.Controls.Add(_orderExecutionStatus);
                                _orderExecutionStatus.updateMessage(obj);                          
                            }                         
                            //(obj as UserControl).Dock = DockStyle.Fill;
                        };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(a);
            }
            else
            {
                a.Invoke();
            }

            //ReturnToPreviousState();
            //if (childControl is uctlMarketExecution)
            //{
            //    ((uctlMarketExecution)this.childControl).lblInfo.Text = obj;
            //    Thread.Sleep(1000);
            //    ((uctlMarketExecution)this.childControl).lblInfo.Text = generalNotice;
            //}
        }

        //void INSTANCE_DoHandleExecutionReport(ClientDLL_Model.Cls.Order.ExecutionReport obj)
        //{

        //}

        void INSTANCE_onPriceUpdate(QuotesStream _QuotesStream)
        {
            //Namo 21 March
            //Action A = () =>
            //    {
            //        if (/*this.childControl is uctlMarketExecution && */quote.Keys.Contains(selectedKey))
            //        {
            //            List<QuoteItem> lst = quote[selectedKey]._lstItem;
            //            int lstCount = lst.Count;
            //            foreach (QuoteItem quoteItem in lst.Where(quoteItem => quoteItem._MarketLevel == 0))
            //            {
            //                UpdateQuote(quoteItem);
            //            }
            //        }

            //    };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
        }
        //Namo 21 March
        //private void UpdateQuote(QuoteItem quoteItem)
        //{
        //    ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into UpdateQuote Method");


        //    string[] strArr = quoteItem._Time.Split('-');

        //    switch (quoteItem._quoteType)
        //    {

        //        case QuoteStreamType.ASK:
        //            {
        //                if (childControl is uctlMarketExecution)
        //                {
        //                    ((uctlMarketExecution)this.childControl).AskValue = Convert.ToString(quoteItem._Price);
        //                }
        //                _askPrice = quoteItem._Price;

        //            }
        //            break;
        //        case QuoteStreamType.BID:
        //            {
        //                if (childControl is uctlMarketExecution)
        //                {
        //                    ((uctlMarketExecution)this.childControl).BidValue = Convert.ToString(quoteItem._Price);
        //                }
        //                _bidPrice = quoteItem._Price;

        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    double AskPrice, BidPrice;
        //    AskPrice = _askPrice;
        //    BidPrice = _bidPrice;
        //    if (AskPrice == 0)//Qea.Qdata.BestAskPrice == 0)
        //    {
        //        double tick = StockChartX1.GetValue(StockChartX1.Symbol + ".ask", StockChartX1.LastVisibleRecord);
        //        AskPrice = tick;
        //    }

        //    if (BidPrice == 0)//Qea.Qdata.BestBidPrice == 0)
        //    {
        //        double tick = StockChartX1.GetValue(StockChartX1.Symbol + ".bid", StockChartX1.LastVisibleRecord);
        //        BidPrice = tick;
        //    }

        //    DateTime dt = PALSA.Cls.ClsGlobal.GetDateTimeDT(quoteItem._Time);
        //    double jdate = StockChartX1.ToJulianDate(Convert.ToInt32(dt.Year), Convert.ToInt32(dt.Month),
        //                                         Convert.ToInt32(dt.Day), Convert.ToInt32(dt.Hour),
        //                                         Convert.ToInt32(dt.Minute), Convert.ToInt32(dt.Second));

        //    StockChartX1.AppendValue(StockChartX1.Symbol + ".bid", jdate, BidPrice);
        //    StockChartX1.AppendValue(StockChartX1.Symbol + ".ask", jdate, AskPrice);
        //    StockChartX1.ScalePrecision = digits;

        //    StockChartX1.Update();

        //    //if (strSelectedSymbol_.Contains("JPY"))
        //    //{
        //    //    StockChartX1.SetYScale(0, AskPrice + 0.20, BidPrice - 0.20);
        //    //    StockChartX1.ScalePrecision = 3;
        //    //}
        //    //else
        //    //{
        //    //    StockChartX1.SetYScale(0, AskPrice + 0.0020, BidPrice - 0.0020);
        //    //    StockChartX1.ScalePrecision = 5;
        //    //}

        //    ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from UpdateQuote Method");
        //    this.TopMost = true;
        //    this.Select();
        //}

        private decimal SetSLTP4mBid(string Symbol)
        {
            decimal value = 0.0M;
            //QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_);
            //if (QR != null)
            //{
            //value = (decimal)QR.BidPx_;
            //}
            value = (decimal)_bidPrice;
            return value;
        }

        private string generalNotice = "Notice! At order by market execution, the price will be quoted by dealer";

        public void closeForm()
        {
            _frmOrderEntry.Close();
        }
        public void SetControlsEnableOrDisable(bool flag)
        {
            cbSymbol.Enabled = flag;
            cmbSL.Enabled = flag;
            cmbTP.Enabled = flag;
            txtComment.Enabled = flag;
            cbVolume.Enabled = flag;
        }
        public void updateSLTP(decimal SL, decimal TP)
        {
            SetSLLine((double)SL);
            SetTPLine((double)TP);

            CurrentOrder.StopLoss = Convert.ToDouble(SL.ToString());
            CurrentOrder.TakeProfit = Convert.ToDouble(TP.ToString());
        }

        //public void UpdateOnQuote(QuoteResponse QR)
        //{
        //    #region CHART
        //    double BidPrice, AskPrice;
        //    BidPrice = AskPrice = 0.0;
        //    BidPrice = QR.BidPx_;
        //    AskPrice = QR.AskPx_;
        //    if (AskPrice == 0)//Qea.Qdata.BestAskPrice == 0)
        //    {
        //        double tick = StockChartX1.GetValue(StockChartX1.Symbol + ".ask", StockChartX1.LastVisibleRecord);
        //        AskPrice = tick;
        //    }

        //    if (BidPrice == 0)//Qea.Qdata.BestBidPrice == 0)
        //    {
        //        double tick = StockChartX1.GetValue(StockChartX1.Symbol + ".bid", StockChartX1.LastVisibleRecord);
        //        BidPrice = tick;
        //    }

        //    double jdate = StockChartX1.ToJulianDate(QR.TradeDate_.Year, QR.TradeDate_.Month,
        //                                             QR.TradeDate_.Day, QR.TradeDate_.Hour,
        //                                             QR.TradeDate_.Minute, QR.TradeDate_.Second);

        //    StockChartX1.AppendValue(StockChartX1.Symbol + ".bid", jdate, BidPrice);
        //    StockChartX1.AppendValue(StockChartX1.Symbol + ".ask", jdate, AskPrice);

        //    if (QR.Symbol_.Contains("JPY"))
        //    {
        //        StockChartX1.SetYScale(0, AskPrice + 0.20, BidPrice - 0.20);
        //    }
        //    else
        //    {
        //        StockChartX1.SetYScale(0, AskPrice + 0.0020, BidPrice - 0.0020);
        //    }
        //    StockChartX1.Update();
        //    #endregion
        //    childControl.updateOnQuoteChanged(QR);
        //}

        public void ResetOrderLines()
        {
            //StockChartX1.AddTPLine(0.00001);//Kul
            //StockChartX1.AddSLLine(0.00001);
            //StockChartX1.AddPriceLine(0.00001);
        }

        /// <summary>
        /// All event handlers are present here.Review done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region EventHandlers
        private void cmbSL_ValueChanged(object sender, EventArgs e)
        {
            if (cmbSL.Value <= 0.0M)
            {
                cmbSL.Value = SetSLTP4mBid(strSelectedSymbol_);
            }
            //Changed the chart SL line
            SetSLLine(double.Parse(cmbSL.Value.ToString()));
            CurrentOrder.StopLoss = Convert.ToDouble(cmbSL.Value);
        }

        //private void initializeSL()
        //{
        //    //QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_);
        //    //if (QR != null)
        //    //{
        //    //    cmbSL.Value = (decimal)QR.BidPx_;
        //    //}
        //}
        //private void initializeTP()
        //{
        //    //QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_);
        //    //if (QR != null)
        //    //{
        //    //    cmbTP.Value = (decimal)QR.BidPx_;
        //    //}
        //}

        private void cmbTP_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTP.Value <= 0.0M)
            {
                cmbTP.Value = SetSLTP4mBid(strSelectedSymbol_);
            }

            //Changed the chart TP line
            SetTPLine(double.Parse(cmbTP.Value.ToString()));
            CurrentOrder.TakeProfit = Convert.ToDouble(cmbTP.Value);
        }
        private void cmbSL_MouseDown(object sender, MouseEventArgs e)
        {
            //decimal value = SetSLTP4mBid(strSelectedSymbol_);
            //if (cmbSL.Maximum < value)
            //    cmbSL.Maximum = value + 10;
            //if (cmbSL.Value <= 0.0M)
            //{
            //    cmbSL.Value = value;
            //}
        }
        private void cmbTP_MouseDown(object sender, MouseEventArgs e)
        {
            decimal value = SetSLTP4mBid(strSelectedSymbol_);
            if (cmbTP.Maximum < value)
                cmbTP.Maximum = value + 10;
            if (cmbTP.Value <= 0.0M)
            {
                cmbTP.Value = SetSLTP4mBid(strSelectedSymbol_);
            }
        }
        void insertStopLoss_Click(object sender, CommandEventArgs e)
        {
            insertStopLoss.Enabled = false;
            SetSLLine(dChartYValue_);
        }
        void insertTakeProfit_Click(object sender, CommandEventArgs e)
        {
            insertTakeProfit.Enabled = false;
            SetTPLine(dChartYValue_);
        }
        void insertEntryPrice_Click(object sender, CommandEventArgs e)
        {
            insertEntryPrice.Enabled = false;
            SetPriceLine(dChartYValue_);
        }
        private void cbVolumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVolume.Text = cbVolume.Text;
            double selVol = Convert.ToDouble(txtVolume.Text);

            //if (isVolumeinLot_)
            //{
            //    selVol = OrderUtility_.GetAmountinQuantity(selVol);
            //}
            CurrentOrder.Quantity = selVol;
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedItem == null)
                return;
            insertStopLoss.Enabled = insertTakeProfit.Enabled = insertEntryPrice.Enabled = false;
            //SetSLLine(0.00001);
            //SetTPLine(0.00001);
            //SetPriceLine(0.00001);
            ResetOrderLines();
            gbParent.Controls.Clear();
            //if(gbParent.Controls.Count>1)
            //gbParent.Controls.RemoveAt(1);
            switch (cbType.SelectedItem.ToString())
            {
                case cbTypeMarketExecution:
                    insertStopLoss.Enabled = true;
                    insertTakeProfit.Enabled = true;
                    insertEntryPrice.Enabled = false;
                    SetControlsEnableOrDisable(true);


                    childControl = new uctlMarketExecution();

                    gbParent.Controls.Add(childControl as uctlMarketExecution);
                    ((uctlMarketExecution)childControl).Digits = digits;
                    ((uctlMarketExecution)childControl).BidValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(strSelectedSymbol_));
                    ((uctlMarketExecution)childControl).AskValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(strSelectedSymbol_));

                    //((uctlMarketExecution)childControl).SellColor = Properties.Settings.Default.SellOrderColor;
                    //((uctlMarketExecution)childControl).BuyColor = Properties.Settings.Default.BuyOrderColor;
                    ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick -= new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick -= new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick -= new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionSellClick -= new Action(frmOrderEntry_OnMarketExecutionSellClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick += new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick += new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick += new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionSellClick += new Action(frmOrderEntry_OnMarketExecutionSellClick);
                    //((uctlMarketExecution)childControl).Dock = DockStyle.None;
                    //((uctlMarketExecution)childControl).Anchor =AnchorStyles.None; //((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));;
                    //((uctlMarketExecution)childControl).SellColor = Properties.Settings.Default.SellOrderColor;
                    //((uctlMarketExecution)childControl).BuyColor = Properties.Settings.Default.SellOrderColor;
                    //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
                    //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
                    //gbParent.HeaderItem.Text =  cbTypeMarketExecution;
                    break;
                case cbTypePending:
                    insertStopLoss.Enabled = true;
                    insertTakeProfit.Enabled = true;
                    insertEntryPrice.Enabled = true;
                    SetControlsEnableOrDisable(true);
                    //gbParent.Controls.Clear();
                    childControl = new uctlPendingNew();
                    gbParent.Controls.Add(childControl as uctlPendingNew);
                    ((uctlPendingNew)childControl).OnPriceMouseDown -= new Action<string>(frmOrderEntry_OnPriceMouseDown);
                    ((uctlPendingNew)childControl).OnPriceChanged -= new Action<string>(frmOrderEntry_OnPriceChanged);
                    ((uctlPendingNew)childControl).OnPriceMouseDown += new Action<string>(frmOrderEntry_OnPriceMouseDown);
                    ((uctlPendingNew)childControl).OnPriceChanged += new Action<string>(frmOrderEntry_OnPriceChanged);
                    ((uctlPendingNew)childControl).OnPendingNewPlaceClick -= new Action<double, string, string>(frmOrderEntry_OnPendingNewPlaceClick);
                    ((uctlPendingNew)childControl).OnPendingNewPlaceClick += new Action<double, string, string>(frmOrderEntry_OnPendingNewPlaceClick);
                    //gbParent.HeaderItem.Text = cbTypePending;
                    break;
                case cbTypeModify:
                    insertStopLoss.Enabled = true;
                    insertTakeProfit.Enabled = true;
                    SetControlsEnableOrDisable(false);

                    //if (ReferenceOrderRow.QuantityFilled > 0)
                    //{
                    //    insertEntryPrice.Enabled = false;
                    //    gbParent.Controls.Clear();
                    //    childControl = new uctlModifyFill();
                    //    gbParent.Controls.Add(childControl as uctlModifyFill);
                    //}
                    //else
                    //{
                    insertEntryPrice.Enabled = true;
                    //gbParent.Controls.Clear();
                    childControl = new uctlModifyPending(this);
                    gbParent.Controls.Add(childControl as uctlModifyPending);
                    //}
                    //gbParent.HeaderItem.Text = cbTypeModify;
                    break;
                default:
                    break;
            }
            childControl.TabIndex = 0;
            //gbParent.Controls.SetChildIndex(childControl, 1);
            AttachEventHandelers(childControl);
            //HandleQuoteResponse(QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_));
        }

        private void frmOrderEntry_OnPriceMouseDown(string obj)
        {
            //InstrumentSpec spec = ClsTWSContractManager.INSTANCE.GetContractSpec(CurrentOrder.Symbol, CurrentOrder.ProductType, CurrentOrder.ProductName);
            InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[CurrentOrder.Symbol];
            if (spec.Digits == 3 || spec.Digits == 5)
            {
                digits = spec.Digits - 1;
            }
            Cls.ClsGlobal.StopLevel = spec.Limit_Stop_Level / Math.Pow(10, digits);
            double mindiff = spec.Limit_Stop_Level / Math.Pow(10, digits);
            ((uctlPendingNew)childControl).UpdatePrice(_askPrice, _bidPrice, mindiff, digits);
        }
        private void frmOrderEntry_OnPriceChanged(string obj)
        {
            if (obj != string.Empty)
                CurrentOrder.Price = Convert.ToDouble(obj);
        }

        private void AttachEventHandelers(OrderChildControl childControl)
        {
            switch (cbType.SelectedItem.ToString())
            {
                case cbTypeMarketExecution:
                    ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick -= new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick -= new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick -= new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionSellClick -= new Action(frmOrderEntry_OnMarketExecutionSellClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick += new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick += new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick += new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                    ((uctlMarketExecution)childControl).OnMarketExecutionSellClick += new Action(frmOrderEntry_OnMarketExecutionSellClick);
                    break;
                case cbTypePending:
                    ((uctlPendingNew)childControl).OnPriceMouseDown -= new Action<string>(frmOrderEntry_OnPriceMouseDown);
                    ((uctlPendingNew)childControl).OnPriceChanged -= new Action<string>(frmOrderEntry_OnPriceChanged);
                    ((uctlPendingNew)childControl).OnPriceMouseDown += new Action<string>(frmOrderEntry_OnPriceMouseDown);
                    ((uctlPendingNew)childControl).OnPriceChanged += new Action<string>(frmOrderEntry_OnPriceChanged);
                    ((uctlPendingNew)childControl).OnPendingNewPlaceClick -= new Action<double, string, string>(frmOrderEntry_OnPendingNewPlaceClick);
                    ((uctlPendingNew)childControl).OnPendingNewPlaceClick += new Action<double, string, string>(frmOrderEntry_OnPendingNewPlaceClick);
                    break;
                case cbTypeModify:
                    if (childControl is uctlModifyPending)
                    {
                        ((uctlModifyPending)childControl).OnModifyPending -= new Action<string, string, string>(frmOrderEntry_OnModifyPendingClick);
                        ((uctlModifyPending)childControl).OnModifyPending += new Action<string, string, string>(frmOrderEntry_OnModifyPendingClick);
                        ((uctlModifyPending)childControl).OnCancelPending -= new Action(frmOrderEntry_OnCancelPendingClick);
                        ((uctlModifyPending)childControl).OnCancelPending += new Action(frmOrderEntry_OnCancelPendingClick);
                        ((uctlModifyPending)childControl).OnSLMouseDown -= new Action<string>(frmOrderEntry_OnModifyPendingSLMouseDown);
                        ((uctlModifyPending)childControl).OnSLMouseDown += new Action<string>(frmOrderEntry_OnModifyPendingSLMouseDown);
                        ((uctlModifyPending)childControl).OnTPMouseDown -= new Action<string>(frmOrderEntry_OnModifyPendingTPMouseDown);
                        ((uctlModifyPending)childControl).OnTPMouseDown += new Action<string>(frmOrderEntry_OnModifyPendingTPMouseDown);
                    }
                    else if (childControl is uctlModifyFill)
                    {
                        ((uctlModifyFill)childControl).OnModifyFill -= new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);
                        ((uctlModifyFill)childControl).OnModifyFill += new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);
                        ((uctlModifyFill)childControl).OnSLMouseDown -= new Action<string>(frmOrderEntry_OnModifyFillSLMouseDown);
                        ((uctlModifyFill)childControl).OnSLMouseDown += new Action<string>(frmOrderEntry_OnModifyFillSLMouseDown);
                        ((uctlModifyFill)childControl).OnTPMouseDown -= new Action<string>(frmOrderEntry_OnModifyFillTPMouseDown);
                        ((uctlModifyFill)childControl).OnTPMouseDown += new Action<string>(frmOrderEntry_OnModifyFillTPMouseDown);
                    }
                    break;
                default:
                    break;
            }

        }

        void frmOrderEntry_OnModifyFillSLMouseDown(string value)
        {
            if (value != string.Empty && value != selectedRow.Cells["clmSLPrice"].Value.ToString())
            {
                if (value == string.Empty)
                    value = "0";
                //InstrumentSpec spec = ClsTWSContractManager.INSTANCE.GetContractSpec(CurrentOrder.Symbol, CurrentOrder.ProductType, CurrentOrder.ProductName);
                InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[CurrentOrder.Symbol];

                if (spec.Digits == 3 || spec.Digits == 5)
                {
                    digits = spec.Digits - 1;
                }
                Cls.ClsGlobal.StopLevel = spec.Limit_Stop_Level / Math.Pow(10, digits);
                double mindiff = spec.Limit_Stop_Level / Math.Pow(10, digits);
                double stoploss = 0;
                if (selectedRow.Cells["clmBS"].Value.ToString().ToUpper() == "BUY")
                {
                    stoploss = _askPrice - mindiff;
                    //takeprofit = _askPrice + mindiff;
                }
                else
                {
                    stoploss = _bidPrice + mindiff;
                    //takeprofit = _bidPrice - mindiff;
                }

                string format = "0.";
                for (int i = 0; i < digits; i++)
                {
                    format += "0";
                }
                ((uctlModifyFill)childControl).SLPrice = stoploss.ToString(format);
            }
        }
        void frmOrderEntry_OnModifyFillTPMouseDown(string value)
        {
            if (value == string.Empty)
                value = "0";
            if (value != selectedRow.Cells["clmTPPrice"].Value.ToString() || value == "0")
            {
                //InstrumentSpec spec = ClsTWSContractManager.INSTANCE.GetContractSpec(selectedRow.Cells["clmContract"].Value.ToString(), selectedRow.Cells["clmProductType"].Value.ToString(), selectedRow.Cells["clmProductName"].Value.ToString());
                InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[selectedRow.Cells["clmContract"].Value.ToString()];
                if (spec.Digits == 3 || spec.Digits == 5)
                {
                    digits = spec.Digits - 1;
                }
                Cls.ClsGlobal.StopLevel = spec.Limit_Stop_Level / Math.Pow(10, digits);
                double mindiff = spec.Limit_Stop_Level / Math.Pow(10, digits);
                double takeprofit = 0;
                if (selectedRow.Cells["clmBS"].Value.ToString().ToUpper() == "BUY")
                {
                    //stoploss = _askPrice- mindiff;
                    takeprofit = _askPrice + mindiff;
                }
                else
                {
                    //stoploss = _bidPrice + mindiff;
                    takeprofit = _bidPrice - mindiff;
                }
                string format = "0.";
                for (int i = 0; i < digits; i++)
                {
                    format += "0";
                }
                if (Convert.ToDecimal(value) <= 0.0M)
                {
                    ((uctlModifyFill)childControl).TPPrice = takeprofit.ToString(format);
                }
            }

        }
        void frmOrderEntry_OnModifyPendingSLMouseDown(string value)
        {
            if (value != string.Empty && value != selectedRow.Cells["clmSLPrice"].Value.ToString())
            {
                if (value == string.Empty)
                    value = "0";
                decimal slp = SetSLTP4mBid(strSelectedSymbol_);

                string format = "0.";
                for (int i = 0; i < digits; i++)
                {
                    format += "0";
                }
                if (Convert.ToDecimal(value) <= 0.0M)
                {
                    ((uctlModifyPending)childControl).SLPrice = slp.ToString(format);
                }
            }
        }
        void frmOrderEntry_OnModifyPendingTPMouseDown(string value)
        {
            if (value != string.Empty && value != selectedRow.Cells["clmTPPrice"].Value.ToString())
            {
                if (value == string.Empty)
                    value = "0";
                decimal tpp = SetSLTP4mBid(strSelectedSymbol_);

                string format = "0.";
                for (int i = 0; i < digits; i++)
                {
                    format += "0";
                }
                if (Convert.ToDecimal(value) <= 0.0M)
                {
                    ((uctlModifyPending)childControl).TPPrice = tpp.ToString(format);
                }
            }
        }
        void frmOrderEntry_OnCancelPendingClick()
        {
            OnPendingState();
            DateTime expiryDateTime = DateTime.UtcNow;
            DateTime transactTime = DateTime.UtcNow;
            DateTime.TryParse(selectedRow.Cells["clmTransactionTime"].Value.ToString(), out transactTime);
            double transTime = transactTime.ToOADate();
            DateTime.TryParse(selectedRow.Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
            string pType = selectedRow.Cells["clmProductType"].Value.ToString();
            switch (pType)
            {
                case "Equity":
                    pType = "EQ";
                    break;
                case "FUTURE":
                    pType = "FUT";
                    break;
                case "FOREX":
                    pType = "FX";
                    break;
                case "OPTION":
                    pType = "OPT";
                    break;
                case "SPOT":
                    pType = "SP";
                    break;
                case "PHYSICAL":
                    pType = "PH";
                    break;
                case "AUCTION":
                    pType = "AU";
                    break;
                case "BOND":
                    pType = "BON";
                    break;
                default:
                    break;
            }
            ;
            sbyte ordType = PALSA.Cls.ClsGlobal.DDOrderTypes[selectedRow.Cells["clmOrderType"].Value.ToString()];
            sbyte side = PALSA.Cls.ClsGlobal.DDSide[selectedRow.Cells["clmBS"].Value.ToString()];
            uint Account = Convert.ToUInt32(selectedRow.Cells["clmClient"].Value.ToString());
            string clOrdId = selectedRow.Cells["clmOrderNumber"].Value.ToString();
            string ContractName = selectedRow.Cells["clmContract"].Value.ToString();
            string ProductType = selectedRow.Cells["clmProductType"].Value.ToString();
            sbyte Producttype = PALSA.Cls.ClsGlobal.DDProductTypes[pType];
            double ordQty = Convert.ToDouble(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
            double price = 0;
            if (!string.IsNullOrEmpty(selectedRow.Cells["clmPrice"].Value.ToString()))
                price = Convert.ToDouble(selectedRow.Cells["clmPrice"].Value.ToString());
            double stopPx = Convert.ToDouble(selectedRow.Cells["clmTriggerPrice"].Value.ToString());
            sbyte tif = PALSA.Cls.ClsGlobal.DDValidity[selectedRow.Cells["clmValidity"].Value.ToString()];
            //Namo 21 March
            //clsTWSOrderManagerJSON.INSTANCE.CancelOrder(Account, clOrdId, ContractName, ProductType, Producttype,
            //                                        selectedRow.Cells["clmProductName"].Value.ToString(), expiryDateTime,
            //                                        selectedRow.Cells["clmGateway"].Value.ToString(),
            //                                        Convert.ToUInt32(selectedRow.Cells["clmOrderNumber"].Value.ToString()), side,
            //                                        ordQty, ordType, price, stopPx, tif, 0, 0, transTime, 0);
        }

        void frmOrderEntry_OnModifyFillClick(double newsl, double newtp, double oldsl, double oldtp)
        {
            
            if (newsl != oldsl || newtp != oldtp)
            {
                //Namo 21 March
                ////string orderStatus = this.selectedRow.Cells["clmStatus"].Value.ToString().ToUpper();

                //DateTime expiryDateTime = DateTime.UtcNow;
                //DateTime transactTime = DateTime.UtcNow;
                ////DateTime.TryParse(this.selectedRow.Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                //double transTime = transactTime.ToOADate();
                //DateTime.TryParse(this.selectedRow.Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                //string pType = this.selectedRow.Cells["clmProductType"].Value.ToString();
                //switch (pType)
                //{
                //    case "Equity":
                //        pType = "EQ";
                //        break;
                //    case "FUTURE":
                //        pType = "FUT";
                //        break;
                //    case "FOREX":
                //        pType = "FX";
                //        break;
                //    case "OPTION":
                //        pType = "OPT";
                //        break;
                //    case "SPOT":
                //        pType = "SP";
                //        break;
                //    case "PHYSICAL":
                //        pType = "PH";
                //        break;
                //    case "AUCTION":
                //        pType = "AU";
                //        break;
                //    case "BOND":
                //        pType = "BON";
                //        break;
                //    default:
                //        break;
                //}
                //;


                //sbyte ordType = PALSA.Cls.ClsGlobal.DDOrderTypes[this.selectedRow.Cells["clmOrderType"].Value.ToString()];
                //string Side = string.Empty;
                //if (this.selectedRow.Cells["clmBS"].Value.ToString().ToLower() == "buy")
                //    Side = "SELL";
                //else
                //    Side = "BUY";
                //sbyte side = PALSA.Cls.ClsGlobal.DDSide[Side];

                //uint Account = Convert.ToUInt32(this.selectedRow.Cells["clmClient"].Value.ToString());
                //string clOrdId = this.selectedRow.Cells["clmOrderNumber"].Value.ToString();
                //string CloseClOrdID = this.selectedRow.Cells["clmOrderNumber"].Value.ToString();
                //string CloseOrderID = this.selectedRow.Cells["clmOrderNumber"].Value.ToString();
                //string ContractName = this.selectedRow.Cells["clmContract"].Value.ToString();
                //string ProductType = this.selectedRow.Cells["clmProductType"].Value.ToString();
                //string ProductName = this.selectedRow.Cells["clmProductName"].Value.ToString();
                //sbyte Producttype = PALSA.Cls.ClsGlobal.DDProductTypes[pType];
                //double ordQty = Convert.ToDouble(this.selectedRow.Cells["clmOrderQuantity"].Value.ToString());
                //double price = 0;
                //InstrumentSpec instSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(ContractName, ProductType, ProductName);
                //Cls.ClsGlobal.StopLevel = instSpec.Limit_Stop_Level / Math.Pow(10, instSpec.Digits);
                //if (!string.IsNullOrEmpty(this.selectedRow.Cells["clmAvgPrice"].Value.ToString()))
                //    price = Convert.ToDouble(this.selectedRow.Cells["clmAvgPrice"].Value.ToString());

                //double stopPx = Convert.ToDouble(this.selectedRow.Cells["clmTriggerPrice"].Value.ToString());
                //sbyte tif = PALSA.Cls.ClsGlobal.DDValidity[this.selectedRow.Cells["clmValidity"].Value.ToString()];
                //bool OCOrder = false;
                //decimal slprice = 0;
                //decimal tpPrice = 0;
                //string OriginalSLClorderid = this.selectedRow.Cells["clmSLClOrdID"].Value.ToString();
                //string OriginalTPClorderid = this.selectedRow.Cells["clmTPClOrdID"].Value.ToString();
                //if (this.selectedRow.Cells["clmSLPrice"].Value != null && !String.IsNullOrEmpty(this.selectedRow.Cells["clmSLPrice"].Value.ToString()))
                //    slprice = Convert.ToDecimal(this.selectedRow.Cells["clmSLPrice"].Value.ToString());
                //if (this.selectedRow.Cells["clmTPPrice"].Value != null && !String.IsNullOrEmpty(this.selectedRow.Cells["clmTPPrice"].Value.ToString()))
                //    tpPrice = Convert.ToDecimal(this.selectedRow.Cells["clmTPPrice"].Value.ToString());
                //if (newsl != oldsl)
                //{
                //    clsTWSOrderManagerJSON.INSTANCE.ModifySL(Account, OriginalSLClorderid, ContractName, ProductType, Producttype, ProductName, expiryDateTime, instSpec.Gateway, ordQty, ordType, price, stopPx, side, Convert.ToUInt32(clOrdId), tif, 0,
                //        (sbyte)clsHashDefine.POSITION_CLOSING_TRADE, transTime, 0, clOrdId, ContractName, ProductType, Producttype, ProductName, expiryDateTime, instSpec.Gateway, ordQty, ordType, price, stopPx, side, tif, 0,
                //        (sbyte)clsHashDefine.POSITION_CLOSING_TRADE, transTime, 0, oldsl, newsl, OriginalSLClorderid, clOrdId);
                //}
                //if (newtp != oldtp)
                //{
                //    clsTWSOrderManagerJSON.INSTANCE.ModifyTP(Account, OriginalTPClorderid, ContractName, ProductType, Producttype, ProductName, expiryDateTime, instSpec.Gateway, ordQty, ordType, price, stopPx, side, Convert.ToUInt32(clOrdId), tif, 0,
                //        (sbyte)clsHashDefine.POSITION_CLOSING_TRADE, transTime, 0, clOrdId, ContractName, ProductType, Producttype, ProductName, expiryDateTime, instSpec.Gateway, ordQty, ordType, price, stopPx, side, tif, 0,
                //        (sbyte)clsHashDefine.POSITION_CLOSING_TRADE, transTime, 0, oldtp, newtp, OriginalTPClorderid, clOrdId);
                //}

            }

        }

        void frmOrderEntry_OnModifyPendingClick(string price, string newsl, string newtp)
        {
            //Namo 21 march
            //OnPendingState();
            //ClsNewOrder oldorder = new ClsNewOrder();
            //string productType = selectedRow.Cells["clmProductType"].Value.ToString();
            //string pType = string.Empty;
            //switch (productType)
            //{
            //    case "EQUITY":
            //        pType = "EQ";
            //        break;
            //    case "FUTURE":
            //        pType = "FUT";
            //        break;
            //    case "FOREX":
            //        pType = "FX";
            //        break;
            //    case "OPTION":
            //        pType = "OPT";
            //        break;
            //    case "SPOT":
            //        pType = "SP";
            //        break;
            //    case "PHYSICAL":
            //        pType = "PH";
            //        break;
            //    case "AUCTION":
            //        pType = "AU";
            //        break;
            //    case "BOND":
            //        pType = "BON";
            //        break;
            //}
            //;
            //oldorder.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
            //oldorder.ClOrderID = selectedRow.Cells["clmReferenceNo"].Value.ToString(); ;
            //oldorder.ContractName = selectedRow.Cells["clmContract"].Value.ToString();
            //DateTime dtEX;
            //if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
            //{
            //    if (dtEX != null)
            //        oldorder.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
            //}
            //oldorder.GatewayName = selectedRow.Cells["clmGateway"].Value.ToString();
            //oldorder.MinorDisclosedQty = 0;
            //oldorder.OrderID = Convert.ToUInt32(selectedRow.Cells["clmReferenceNo"].Value.ToString()); ;
            //oldorder.OrderType = Cls.ClsGlobal.DDOrderTypes[selectedRow.Cells["clmOrderType"].Value.ToString().ToUpper()];
            //oldorder.PositionEffect = (sbyte)Convert.ToChar(selectedRow.Cells["clmPositionEffect"].Value.ToString());
            //oldorder.Price = Convert.ToDouble(selectedRow.Cells["clmPrice"].Value.ToString());
            //oldorder.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
            //oldorder.Qty = Convert.ToDouble(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
            //oldorder.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
            //if (selectedRow.Cells["clmBs"].Value.ToString().ToUpper() == "BUY")
            //{
            //    oldorder.Side = (sbyte)clsHashDefine.SIDE_BUY;
            //}
            //else
            //{
            //    oldorder.Side = (sbyte)clsHashDefine.SIDE_SELL;
            //}
            //oldorder.StopPX = Convert.ToDouble(selectedRow.Cells["clmTriggerPrice"].Value.ToString());
            //oldorder.StrProductType = productType;
            //oldorder.Tif = Cls.ClsGlobal.DDValidity[selectedRow.Cells["clmValidity"].Value.ToString().ToUpper()];
            //oldorder.Slipage = 0;
            //ClsNewOrder neworder = new ClsNewOrder();
            //neworder.ClOrderID = selectedRow.Cells["clmReferenceNo"].Value.ToString();
            //neworder.ContractName = CurrentOrder.Symbol;
            //DateTime dtEX1;
            //if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX1))
            //{
            //    if (dtEX1 != null)
            //        neworder.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
            //}
            //neworder.GatewayName = selectedRow.Cells["clmGateway"].Value.ToString();
            //neworder.MinorDisclosedQty = 0;
            //neworder.OrderID = Convert.ToUInt32(selectedRow.Cells["clmReferenceNo"].Value.ToString()); ;
            //neworder.OrderType = Cls.ClsGlobal.DDOrderTypes[selectedRow.Cells["clmOrderType"].Value.ToString().ToUpper()];
            //neworder.PositionEffect = (sbyte)Convert.ToChar(selectedRow.Cells["clmPositionEffect"].Value.ToString());
            //neworder.Price = Convert.ToDouble(price);
            //neworder.ProductName = selectedRow.Cells["clmProductName"].Value.ToString();
            //neworder.Qty = Convert.ToDouble(selectedRow.Cells["clmOrderQuantity"].Value.ToString());
            //neworder.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
            //if (selectedRow.Cells["clmBs"].Value.ToString().ToUpper() == "BUY")
            //{
            //    neworder.Side = (sbyte)clsHashDefine.SIDE_BUY;
            //}
            //else
            //{
            //    neworder.Side = (sbyte)clsHashDefine.SIDE_SELL;
            //}
            //neworder.StopPX = Convert.ToDouble(selectedRow.Cells["clmTriggerPrice"].Value.ToString());
            //neworder.StrProductType = productType;
            //neworder.Tif = Cls.ClsGlobal.DDValidity[selectedRow.Cells["clmValidity"].Value.ToString().ToUpper()];
            //neworder.Slipage = 0;
            //# region "Commented"
            ////objclsOldOrder.Account, 
            ////objclsOldOrder.ClOrderID,
            ////objclsOldOrder.ContractName, 
            ////objclsOldOrder.StrProductType,
            ////objclsOldOrder.SbProductType, 
            ////objclsOldOrder.ProductName,
            ////objclsOldOrder.ExpiryDate,
            ////objclsOldOrder.GatewayName,
            ////objclsOldOrder.Qty,
            ////objclsOldOrder.OrderType, 
            ////objclsOldOrder.Price, 
            ////objclsOldOrder.StopPX,
            ////objclsOldOrder.Side, 
            ////objclsOldOrder.OrderID,
            ////objclsOldOrder.Tif, 
            ////objclsOldOrder.MinorDisclosedQty,
            ////objclsOldOrder.PositionEffect, 
            ////objclsOldOrder.Slipage,

            ////objclsNewOrder.ClOrderID, 
            ////objclsNewOrder.ContractName,
            ////objclsNewOrder.StrProductType,
            ////objclsNewOrder.SbProductType,
            ////objclsNewOrder.ProductName, 
            ////objclsNewOrder.ExpiryDate,
            ////objclsNewOrder.GatewayName,
            ////objclsNewOrder.Qty, 
            ////objclsNewOrder.OrderType, 
            ////objclsNewOrder.Price,
            ////objclsNewOrder.StopPX, 
            ////objclsNewOrder.Side,
            ////objclsNewOrder.Tif, 
            ////objclsNewOrder.MinorDisclosedQty,
            ////objclsNewOrder.PositionEffect, 
            ////objclsNewOrder.Slipage
            //#endregion
            //double slprice = 0;
            //double tpPrice = 0;
            //double newSlPrice = 0;
            //double newTpPrice = 0;
            //if (newsl != string.Empty)
            //    newSlPrice = Convert.ToDouble(newsl);
            //if (newsl != string.Empty)
            //    newTpPrice = Convert.ToDouble(newtp);
            //if (this.selectedRow.Cells["clmSLPrice"].Value != null && !String.IsNullOrEmpty(this.selectedRow.Cells["clmSLPrice"].Value.ToString()))
            //    slprice = Convert.ToDouble(this.selectedRow.Cells["clmSLPrice"].Value.ToString());
            //if (this.selectedRow.Cells["clmTPPrice"].Value != null && !String.IsNullOrEmpty(this.selectedRow.Cells["clmTPPrice"].Value.ToString()))
            //    tpPrice = Convert.ToDouble(this.selectedRow.Cells["clmTPPrice"].Value.ToString());
            //clsTWSOrderManagerJSON.INSTANCE.ModifyOrder(neworder, oldorder);
            
        }

        void frmOrderEntry_OnPendingNewPlaceClick(double price, string tif, string type)
        {
            //Namo 21 march

            //string[] strArr = type.Split(' ');
            //string msg = ValidateOrderEntry(CurrentOrder.ProductType, CurrentOrder.ProductName, CurrentOrder.Symbol, CurrentOrder.Price, _askPrice, _bidPrice,
            //                            CurrentOrder.Quantity, strArr[1].ToUpper(), CurrentOrder.StopLoss, CurrentOrder.TakeProfit, strArr[0].ToUpper());

            //if (msg == string.Empty)
            //{
            //    OnPendingState();
            //    ClsNewOrder order = new ClsNewOrder();
            //    string productType = CurrentOrder.ProductType;
            //    string pType = string.Empty;
            //    switch (productType)
            //    {
            //        case "EQUITY":
            //            pType = "EQ";
            //            break;
            //        case "FUTURE":
            //            pType = "FUT";
            //            break;
            //        case "FOREX":
            //            pType = "FX";
            //            break;
            //        case "OPTION":
            //            pType = "OPT";
            //            break;
            //        case "SPOT":
            //            pType = "SP";
            //            break;
            //        case "PHYSICAL":
            //            pType = "PH";
            //            break;
            //        case "AUCTION":
            //            pType = "AU";
            //            break;
            //        case "BOND":
            //            pType = "BON";
            //            break;
            //    }
            //    ;
            //    order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
            //    order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //    order.ContractName = CurrentOrder.Symbol;
            //    DateTime dtEX;
            //    if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
            //    {
            //        if (dtEX != null)
            //            order.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
            //    }
            //    order.GatewayName = CurrentOrder.GatewayName;
            //    order.MinorDisclosedQty = 0;
            //    order.OrderID = 0;
            //    order.OrderType = Cls.ClsGlobal.DDOrderTypes[strArr[1].ToUpper()];
            //    order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
            //    order.Price = price;
            //    order.ProductName = CurrentOrder.ProductName;
            //    order.Qty = CurrentOrder.Quantity;//Convert.ToUInt32(cbVolume.SelectedItem.ToString());
            //    order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
            //    if (strArr[0].ToUpper() == "BUY")
            //    {
            //        order.Side = (sbyte)clsHashDefine.SIDE_BUY;
            //    }
            //    else if (strArr[0].ToUpper() == "SELL")
            //    {
            //        order.Side = (sbyte)clsHashDefine.SIDE_SELL;
            //    }
            //    order.StopPX = 0;
            //    order.StrProductType = CurrentOrder.ProductType;
            //    order.Tif = Cls.ClsGlobal.DDValidity[tif];
            //    order.StopLoss = CurrentOrder.StopLoss;
            //    order.TakeProfit = CurrentOrder.TakeProfit;

            //    clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            //}
            //else
            //{
            //    MessageBox.Show(msg);
            //}
        }

        void frmOrderEntry_OnMarketExecutionSellClick()
        {
            //gbParent.Controls.Clear();
            //var childControl = new uctlWaitPending();
            //gbParent.Controls.Add(childControl as uctlWaitPending);
            string msg = ValidateOrderEntry(CurrentOrder.ProductType, CurrentOrder.ProductName, CurrentOrder.Symbol, CurrentOrder.Price, _askPrice, _bidPrice,
                                        CurrentOrder.Quantity, "MARKET", CurrentOrder.StopLoss, CurrentOrder.TakeProfit, "SELL");
            if (msg == string.Empty)
            {
                //Namo 21 March
                //OnPendingState();
                //ClsNewOrder order = new ClsNewOrder();
                //string productType = CurrentOrder.ProductType;
                //string pType = string.Empty;
                //switch (productType)
                //{
                //    case "EQUITY":
                //        pType = "EQ";
                //        break;
                //    case "FUTURE":
                //        pType = "FUT";
                //        break;
                //    case "FOREX":
                //        pType = "FX";
                //        break;
                //    case "OPTION":
                //        pType = "OPT";
                //        break;
                //    case "SPOT":
                //        pType = "SP";
                //        break;
                //    case "PHYSICAL":
                //        pType = "PH";
                //        break;
                //    case "AUCTION":
                //        pType = "AU";
                //        break;
                //    case "BOND":
                //        pType = "BON";
                //        break;
                //}
                //;
                //order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
                //order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
                //order.ContractName = CurrentOrder.Symbol;
                //DateTime dtEX;
                //if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
                //{
                //    if (dtEX != null)
                //        order.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
                //}
                //order.GatewayName = CurrentOrder.GatewayName;
                //order.MinorDisclosedQty = 0;
                //order.OrderID = 0;
                //order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
                //order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
                //order.Price = _bidPrice;
                //order.ProductName = CurrentOrder.ProductName;
                //order.Qty = CurrentOrder.Quantity;//Convert.ToUInt32(cbVolume.SelectedItem.ToString());
                //order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
                //order.Side = (sbyte)clsHashDefine.SIDE_SELL;
                //order.StopPX = 0;
                //order.StopLoss = CurrentOrder.StopLoss;
                //order.TakeProfit = CurrentOrder.TakeProfit;
                //order.StrProductType = CurrentOrder.ProductType;
                //order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
                //clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
                
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        void frmOrderEntry_OnMarketExecutionReverseClick()
        {
            //throw new NotImplementedException();
        }

        void frmOrderEntry_OnMarketExecutionCloseClick()
        {
            //throw new NotImplementedException();
        }

        void frmOrderEntry_OnMarketExecutionBuyClick()
        {
            CurrentOrder.Price = _askPrice;
            string msg = ValidateOrderEntry(CurrentOrder.ProductType, CurrentOrder.ProductName, CurrentOrder.Symbol, CurrentOrder.Price, _askPrice, _bidPrice,
                                         CurrentOrder.Quantity, "MARKET", CurrentOrder.StopLoss, CurrentOrder.TakeProfit, "BUY");
            if (msg == string.Empty)
            {
                //Namo 21 March
                //OnPendingState();
                //ClsNewOrder order = new ClsNewOrder();
                //string productType = CurrentOrder.ProductType;
                //string pType = string.Empty;
                //switch (productType)
                //{
                //    case "EQUITY":
                //        pType = "EQ";
                //        break;
                //    case "FUTURE":
                //        pType = "FUT";
                //        break;
                //    case "FOREX":
                //        pType = "FX";
                //        break;
                //    case "OPTION":
                //        pType = "OPT";
                //        break;
                //    case "SPOT":
                //        pType = "SP";
                //        break;
                //    case "PHYSICAL":
                //        pType = "PH";
                //        break;
                //    case "AUCTION":
                //        pType = "AU";
                //        break;
                //    case "BOND":
                //        pType = "BON";
                //        break;
                //}
                //;
                //order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
                //order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
                //order.ContractName = CurrentOrder.Symbol;
                //DateTime dtEX;
                //if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
                //{
                //    if (dtEX != null)
                //        order.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
                //}
                //order.GatewayName = CurrentOrder.GatewayName;
                //order.MinorDisclosedQty = 0;
                //order.OrderID = 0;
                //order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
                //order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
                //order.Price = _askPrice;
                //order.ProductName = CurrentOrder.ProductName;
                //order.Qty = CurrentOrder.Quantity; //Convert.ToUInt32(cbVolume.SelectedItem.ToString());
                //order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
                //order.Side = (sbyte)clsHashDefine.SIDE_BUY;
                //order.StopPX = 0;
                //order.StopLoss = CurrentOrder.StopLoss;
                //order.TakeProfit = CurrentOrder.TakeProfit;
                //order.StrProductType = CurrentOrder.ProductType;
                //order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
                //clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        //private bool ValidSLTP()
        //{
        //    InstrumentSpec spec = ClsTWSContractManager.INSTANCE.GetContractSpec(CurrentOrder.Symbol, CurrentOrder.ProductType, CurrentOrder.ProductName);

        //    if (CurrentOrder.StopLoss > 0)
        //    {
        //        double mindiff=spec.Limit_Stop_Level/Math.Pow(10,spec.Digits);
        //        if(CurrentOrder.Price+mindiff>=)
        //    }
        //    if (CurrentOrder.TakeProfit > 0)
        //    {

        //    }
        //}

        private string ValidateOrderEntry(string productType, string ProductName, string ContractName, double Price, double askprice, double bidprice,
                                         double qty, string OrderType, double stoploss, double takeprofit, string Side)
        {

            string message = string.Empty;
            //Namo 21 March
            //InstrumentSpec spec = ClsTWSContractManager.INSTANCE.GetContractSpec(ContractName, productType, ProductName);
            //int digits = spec.Digits;
            //if (spec.Digits == 3 || spec.Digits == 5)
            //{

            //    digits = spec.Digits - 1;
            //}
            //double mindiff = spec.Limit_Stop_Level / Math.Pow(10, digits);

            //if (qty == 0 || qty < clsTWSOrderManagerJSON.INSTANCE.Lotsize)
            //{
            //    message = "# Invalid Volume!" + Environment.NewLine;
            //}

            //if (Side == "BUY")
            //{
            //    switch (OrderType.ToUpper().Trim())
            //    {
            //        //case "MMO":
            //        case "LIMIT":
            //            if (Price == 0)
            //            {
            //                message = "# Price should be greater than 0 ." + Environment.NewLine;
            //            }
            //            else if (askprice != 0 && Price >= askprice)
            //            {
            //                message = "# Price should be less than " + Convert.ToString(askprice) + " ." +
            //                          Environment.NewLine;
            //            }
            //            if (stoploss > 0)
            //            {
            //                if (stoploss > Price - mindiff)
            //                {
            //                    message = "# StopPrice should be less or equal to " + Convert.ToString(Price - mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit < Price + mindiff)
            //                {
            //                    message = "# TakeProfit Price should be greater or equal to " + Convert.ToString(Price + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        case "STOP":
            //            if (Price == 0)
            //            {
            //                message = "# Price should be greater than 0 ." + Environment.NewLine;
            //            }
            //            if (askprice != 0 && Price <= askprice)
            //            {
            //                message = "# Price should be greater than " + Convert.ToString(askprice) + " ." +
            //                          Environment.NewLine;
            //            }
            //            if (stoploss > Price - mindiff)
            //            {
            //                message = "# StopPrice should be less or equal to " + Convert.ToString(Price - mindiff) + " ." +
            //                          Environment.NewLine;
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit < Price + mindiff)
            //                {
            //                    message = "# TakeProfit Price should be greater or equal to " + Convert.ToString(Price + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        case "MARKET":
            //            if (askprice == 0)
            //            {
            //                //    if (ProductName != string.Empty)
            //                //    {
            //                if (Cls.ClsGlobal.DDRightZLevel.Keys.Contains(ContractName))
            //                {
            //                    if (!(Convert.ToDouble(Cls.ClsGlobal.DDRightZLevel[ContractName]) > 0))
            //                        message = "# Order is not allowed." + Environment.NewLine;
            //                }
            //                else
            //                {
            //                    message = "# Order is not allowed." + Environment.NewLine;
            //                }
            //                //    }
            //            }
            //            if (stoploss > 0)
            //            {
            //                if (stoploss > askprice - mindiff)
            //                {
            //                    message = "# StopPrice should be less or equal to " + Convert.ToString(askprice - mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit < askprice + mindiff)
            //                {
            //                    message = "# TakeProfit Price should be greater or equal to " + Convert.ToString(askprice + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //    ;
            //}
            //else
            //{
            //    switch (OrderType.ToUpper().Trim())
            //    {
            //        //case "MMO":
            //        case "LIMIT":
            //            if (Price == 0)
            //            {
            //                message = "# Price should be greater than 0 ." + Environment.NewLine;
            //            }
            //            else if (bidprice != 0 && Price <= bidprice)
            //            {
            //                message = "# Price should be greater than " + Convert.ToString(bidprice) + " ." +
            //                          Environment.NewLine;
            //            }
            //            if (stoploss > 0)
            //            {
            //                if (stoploss < Price + mindiff)
            //                {
            //                    message = "# StopPrice should be greater or equal to " + Convert.ToString(Price + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit > Price - mindiff)
            //                {
            //                    message = "# TakeProfit Price should be less or equal to " + Convert.ToString(Price + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        case "STOP":
            //            if (Price == 0)
            //            {
            //                message = "# Price should be greater than 0 ." + Environment.NewLine;
            //            }
            //            if (bidprice != 0 && Price >= bidprice)
            //            {
            //                message = "# Price should be less than " + Convert.ToString(bidprice) + " ." +
            //                          Environment.NewLine;
            //            }
            //            if (stoploss > 0)
            //            {
            //                if (stoploss < Price + mindiff)
            //                {
            //                    message = "# StopPrice should be greater or equal to " + Convert.ToString(Price + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit > Price - mindiff)
            //                {
            //                    message = "# TakeProfit Price should be less or equal to " + Convert.ToString(Price - mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        case "MARKET":
            //            if (bidprice == 0)
            //            {
            //                //if (ProductName != string.Empty)
            //                //{
            //                if (Cls.ClsGlobal.DDLeftZLevel.Keys.Contains(ContractName))
            //                {
            //                    if (!(Convert.ToDouble(Cls.ClsGlobal.DDLeftZLevel[ContractName]) > 0))
            //                        message = "# Order is not allowd." + Environment.NewLine;
            //                }
            //                else
            //                {
            //                    message = "# Order is not allowd." + Environment.NewLine;
            //                }
            //                //}
            //            }
            //            if (stoploss > 0)
            //            {
            //                if (stoploss < bidprice + mindiff)
            //                {
            //                    message = "# StopPrice should be greater or equal to " + Convert.ToString(bidprice + mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            if (takeprofit > 0)
            //            {
            //                if (takeprofit > bidprice - mindiff)
            //                {
            //                    message = "# TakeProfit Price should be less or equal to " + Convert.ToString(bidprice - mindiff) + " ." +
            //                              Environment.NewLine;
            //                }
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //    ;
            //}


            return message;
        }
        #endregion

        /// <summary>
        /// Methods releted to order sending.Review done.
        /// </summary>
        #region Order Sending

        //public void SendMarketOrPendingOrder()
        //{
        //    //OnPendingState();
        //    sendOrder(CurrentOrder);
        //}
        //public void closeOrder(string clOrderID)
        //{
        //    //OnPendingState();
        //    //CurrentOrder.ClientOrderID = Convert.ToInt64(clOrderID);
        //    //OrderUtility_.CloseFilledOrder(clOrderID);
        //}
        //public void reverseOrder(string clOrderID)
        //{
        //    //OnPendingState();
        //    //CurrentOrder.ClientOrderID = Convert.ToInt64(clOrderID);
        //    //OrderUtility_.ReverseFilledOrder(clOrderID);
        //}

        //private string ValidateOrderEntry(string productType, string ContractName, double Price, double trigerPrice,
        //                                 int qty, string OrderType, string Side)
        //{
        //    string message = string.Empty;
        //    string ProductName = ClsTWSContractManager.INSTANCE.GetProductNameForContract(productType, ContractName);
        //    InstrumentSpec instSpec = null;


        //    if (ProductName == string.Empty)
        //    {
        //        message = "# Contract name not found." + Environment.NewLine;
        //        return message;
        //    }
        //    else
        //    {
        //        instSpec = ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(productType, ContractName, ProductName);
        //    }
        //    if (qty == 0)
        //    {
        //        message = "# Quantity should be greater than 0." + Environment.NewLine;
        //    }

        //    if (Side == "BUY")
        //    {
        //        double submitPrice = Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName) - instSpec.Limit_Stop_Level;
        //        switch (OrderType.ToUpper().Trim())
        //        {
        //            case "MMO":
        //            case "LIMIT":
        //                if (Price == 0)
        //                {
        //                    message = "# Price should be greater than 0 ." + Environment.NewLine;
        //                }
        //                else if (submitPrice != 0 && Price >= submitPrice)
        //                {
        //                    message = "# Price should be less than " + Convert.ToString(submitPrice) + " ." +
        //                              Environment.NewLine;
        //                }
        //                break;
        //            case "STOP":
        //                if (Price == 0)
        //                {
        //                    message = "# Price should be greater than 0 ." + Environment.NewLine;
        //                }
        //                if (submitPrice != 0 && Price <= submitPrice)
        //                {
        //                    message = "# Price should be greater than " + Convert.ToString(submitPrice) + " ." +
        //                              Environment.NewLine;
        //                }
        //                break;
        //            case "MARKET":
        //                //if (LTP == 0)
        //                //{
        //                if (ProductName != string.Empty)
        //                {
        //                    if (Cls.ClsGlobal.DDRightZLevel.Keys.Contains(ContractName))
        //                    {
        //                        if (!(Convert.ToDouble(Cls.ClsGlobal.DDRightZLevel[ContractName]) > 0))
        //                            message = "# Order is not allowed." + Environment.NewLine;
        //                    }
        //                    else
        //                    {
        //                        message = "# Order is not allowed." + Environment.NewLine;
        //                    }
        //                }
        //                //}
        //                break;
        //            default:
        //                break;
        //        }
        //        ;
        //    }
        //    else
        //    {
        //        double submitPrice = Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName) + instSpec.Limit_Stop_Level;
        //        switch (OrderType.ToUpper().Trim())
        //        {
        //            case "MMO":
        //            case "LIMIT":
        //                if (Price == 0)
        //                {
        //                    message = "# Price should be greater than 0 ." + Environment.NewLine;
        //                }
        //                else if (submitPrice != 0 && Price <= submitPrice)
        //                {
        //                    message = "# Price should be greater than " + Convert.ToString(submitPrice) + " ." +
        //                              Environment.NewLine;
        //                }
        //                break;
        //            case "STOP":
        //                if (Price == 0)
        //                {
        //                    message = "# Price should be greater than 0 ." + Environment.NewLine;
        //                }
        //                if (submitPrice != 0 && Price >= submitPrice)
        //                {
        //                    message = "# Price should be less than " + Convert.ToString(submitPrice) + " ." +
        //                              Environment.NewLine;
        //                }
        //                break;
        //            case "MARKET":
        //                //if (LTP == 0)
        //                //{
        //                if (ProductName != string.Empty)
        //                {
        //                    if (Cls.ClsGlobal.DDLeftZLevel.Keys.Contains(ContractName))
        //                    {
        //                        if (!(Convert.ToDouble(Cls.ClsGlobal.DDLeftZLevel[ContractName]) > 0))
        //                            message = "# Order is not allowd." + Environment.NewLine;
        //                    }
        //                    else
        //                    {
        //                        message = "# Order is not allowd." + Environment.NewLine;
        //                    }
        //                }
        //                //}
        //                break;
        //            default:
        //                break;
        //        }
        //        ;
        //    }

        //    if (OrderType.ToUpper().Trim() == "STOP_LIMIT")
        //    {
        //        if (Price == 0 || trigerPrice == 0)
        //        {
        //            message = "# Price and TrigerPrice both should be greater than 0 ." + Environment.NewLine;
        //        }
        //    }

        //    return message;
        //}


        //public void sendOrder(ClsOrderEntryInfo order)
        //{
        //    //string reason = string.Empty;
        //    //if (validateNewOrder(order, out reason) == true)
        //    //{
        //    //    OnPendingState();
        //    //    reason = OrderUtility_.SendNewOrder(order.BuySell, order.Price, order.Instrument, order.Quantity,
        //    //             order.SL, order.TP, order.OrderType, order.TimeInForce, order.orderStatus, order.RequestType, order.ServerOrderID);
        //    //    if (!string.IsNullOrEmpty(reason))
        //    //    {
        //    //        showErrorMessage(reason);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    showErrorMessage(reason);
        //    //}
        //}
        //public void ModifyOrder()
        //{
        //    //string reason = string.Empty;
        //    //OnPendingState();
        //    //OrderUtility_.SendModifyOrder(ReferenceOrderRow.ClientOrderID, CurrentOrder.SL, CurrentOrder.TP, CurrentOrder.Price, out reason);

        //}
        //public void CancelOrder()
        //{
        //    //OnPendingState();
        //    //OrderUtility_.CancelPendingOrder(ReferenceOrderRow.ClientOrderID);
        //}


        #endregion

        /// <summary>
        /// All Child controls related methos.Code Review done.
        /// </summary>
        #region ChildControl

        public void loadChildControl(int digits)
        {
            gbParent.Controls.Clear();

            //gbParent.HeaderItem.Text = cbTypeMarketExecution;
            if (childControl is uctlMarketExecution)
            {
                gbParent.Controls.Add(childControl as uctlMarketExecution);
                //gbParent.HeaderItem.Text = cbTypeMarketExecution;
                ((uctlMarketExecution)childControl).Digits = digits;
                ((uctlMarketExecution)childControl).BidValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(strSelectedSymbol_));
                ((uctlMarketExecution)childControl).AskValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(strSelectedSymbol_));

                //((uctlMarketExecution)childControl).SellColor = Properties.Settings.Default.SellOrderColor;
                //((uctlMarketExecution)childControl).BuyColor = Properties.Settings.Default.BuyOrderColor;
                ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick -= new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick -= new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick -= new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionSellClick -= new Action(frmOrderEntry_OnMarketExecutionSellClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick += new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick += new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick += new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionSellClick += new Action(frmOrderEntry_OnMarketExecutionSellClick);
                //QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_);
                //childControl.updateOnQuoteChanged(QR);
            }
            else if (typeof(uctlModifyFill) == childControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlModifyFill);
                //gbParent.HeaderItem.Text = cbTypeModify;
                ((uctlModifyFill)childControl).Digits = digits;
                ((uctlModifyFill)childControl).OnModifyFill -= new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);
                ((uctlModifyFill)childControl).OnModifyFill += new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);

                //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            }
            else if (typeof(uctlModifyPending) == childControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlModifyPending);
                //gbParent.HeaderItem.Text = cbTypeModify;
                ((uctlModifyPending)childControl).Digits = digits;
                //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            }
        }


        //void loadChildControl(clsInterface4OME.OrderType type,Side side,decimal Price)
        //{
        //gbParent.Controls.Clear();
        //childControl = new GTS.Ctrl.ucPendingNew(_frmOrderEntry,type,side,Price);
        //gbParent.Controls.Add(childControl as GTS.Ctrl.ucPendingNew);
        //gbParent.HeaderItem.Text = cbTypePending;
        //}
        public void ReturnToPreviousState()
        {
            gbParent.Controls.Clear();
            childControl = previousChildControl;
            if (typeof(uctlMarketExecution) == previousChildControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlMarketExecution);
                ((uctlMarketExecution)childControl).Digits = digits;
                ((uctlMarketExecution)childControl).BidValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(strSelectedSymbol_));
                ((uctlMarketExecution)childControl).AskValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(strSelectedSymbol_));

                ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick -= new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick -= new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick -= new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionSellClick -= new Action(frmOrderEntry_OnMarketExecutionSellClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionBuyClick += new Action(frmOrderEntry_OnMarketExecutionBuyClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionCloseClick += new Action(frmOrderEntry_OnMarketExecutionCloseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionReverseClick += new Action(frmOrderEntry_OnMarketExecutionReverseClick);
                ((uctlMarketExecution)childControl).OnMarketExecutionSellClick += new Action(frmOrderEntry_OnMarketExecutionSellClick);
            }
            else if (typeof(uctlPendingNew) == previousChildControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlPendingNew);
            }
            else if (typeof(uctlModifyFill) == previousChildControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlModifyFill);
                ((uctlModifyFill)childControl).Digits = digits;
                ((uctlModifyFill)childControl).OnModifyFill -= new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);
                ((uctlModifyFill)childControl).OnModifyFill += new Action<double, double, double, double>(frmOrderEntry_OnModifyFillClick);
            }
            else if (typeof(uctlModifyPending) == previousChildControl.GetType())
            {
                gbParent.Controls.Add(childControl as uctlModifyPending);
                ((uctlModifyPending)childControl).Digits = digits;
            }

        }

        private void OnPendingState()
        {
            previousChildControl = childControl;
            gbParent.Controls.Clear();
            uctlWaitPending child = new uctlWaitPending();
            gbParent.Controls.Add(child);
        }

        #endregion

        /// <summary>
        /// All Stockchart related events are handled.Review done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Stockchart EVENTS

        private void StockChartX1_MouseMoveEvent(object sender, AxSTOCKCHARTXLib._DStockChartXEvents_MouseMoveEvent e)
        {
            dChartYValue_ = StockChartX1.GetYValueByPixel(e.y);
        }
        private void StockChartX1_OnRButtonDown(object sender, EventArgs e)
        {
        }
        private void StockChartX1_OnRButtonUp(object sender, EventArgs e)
        {
            try
            {
                //if (m_Menu) return; //Another context menu is shown        
                if (StockChartX1.SelectedKey != "") return;
                Point p = new Point { X = (Cursor.Position.X), Y = (Cursor.Position.Y) };
                ChartContextMenu.Show(this, p);
                Application.DoEvents();

            }
            catch (Exception ex)
            {
                //ServerLog.Write("frmOrderEntry::StockChartX1_OnRButtonUp" + ex.ToString() + ex.StackTrace, true);
                //Logger.LogEx(ex, "frmOrderEntry", "StockChartX1_OnRButtonUp(object sender, EventArgs e)");
            }

        }
        private void StockChartX1_PaintEvent(object sender, AxSTOCKCHARTXLib._DStockChartXEvents_PaintEvent e)
        {
            double tick = 0;
            int p = 0;
            string Symbol = StockChartX1.Symbol;
            // See if this Panel is the one with the OHLC bar chart
            p = StockChartX1.GetPanelBySeriesName(Symbol + ".bid");
            try
            {
                if (p != e.panel) return;

                // Show the real-time tick box
                if (StockChartX1.RealTimeXLabels)
                {
                    tick = StockChartX1.GetValue(Symbol + ".bid", StockChartX1.LastVisibleRecord);
                    StockChartX1.ShowLastTick(Symbol + ".bid", tick);
                }

                p = StockChartX1.GetPanelBySeriesName(Symbol + ".ask");
                if (p != e.panel) return;
                // Show the real-time tick box
                if (StockChartX1.RealTimeXLabels)
                {
                    tick = StockChartX1.GetValue(Symbol + ".ask", StockChartX1.LastVisibleRecord);
                    StockChartX1.ShowLastTick(Symbol + ".ask", tick);
                }
                StockChartX1.Update();
            }
            catch (Exception ex)
            {
                //ServerLog.Write("OrderEntry::StockChartX1_PaintEvent" + ex.ToString() + ex.StackTrace, true);
                //Logger.LogEx(ex, "NewOrderEntry", "StockChartX1_PaintEvent(object sender, AxSTOCKCHARTXLib._DStockChartXEvents_PaintEvent e)");
            }

        }
        //private void StockChartX1_ValueChanged(object sender, AxSTOCKCHARTXLib._DStockChartXEvents_ValueChangedEvent e)
        //{
        //Kul
        //double SelectedValue = 0.0;
        //if (strSelectedSymbol_.Contains("JPY"))
        //{
        //    SelectedValue = Math.Round(e.value, 3);
        //}
        //else
        //{
        //    SelectedValue = Math.Round(e.value, 5);
        //}

        //if (e.index == SLlineIndex)
        //{
        //    SetSL4mStockchart((decimal)SelectedValue);
        //}
        //else if (e.index == TPlineIndex)
        //{
        //    setTP4mStockchart((decimal)SelectedValue);
        //}
        //else if (e.index == PriceLineIndex)
        //{
        //    SetEnteredPrice((decimal)SelectedValue);
        //}
        //}
        private void SetSL4mStockchart(decimal SL)
        {
            if (cmbSL.Enabled == true)
            {
                cmbSL.Value = SL;
            }
            //childControl.updateOnSLChanged(SL);
        }
        private void setTP4mStockchart(decimal TP)
        {
            if (cmbTP.Enabled == true) //abhi attack point
            {
                cmbTP.Value = TP;
            }
            //childControl.updateOnTPChanged(TP);
        }


        public void SetEnteredPrice(decimal Value)
        {
            //childControl.updateOnPriceChaged(Value);
        }
        public void SetPriceLine(double Val)
        {
            if (insertEntryPrice.Enabled)
                return;

            if (strSelectedSymbol_.Contains("JPY"))
            {
                //Kul
                //StockChartX1.AddPriceLine(Math.Round(Val, 3));
            }
            else
            {
                //Kul
                //StockChartX1.AddPriceLine(Math.Round(Val, 5));
            }
            StockChartX1.Update();

        }
        public void SetSLLine(double val)
        {
            if (insertStopLoss.Enabled)
                return;

            if (strSelectedSymbol_.Contains("JPY"))
            {
                //Kul
                //StockChartX1.AddSLLine(Math.Round(val, 3));
            }
            else
            {
                //StockChartX1.AddSLLine(Math.Round(val, 5));
            }
            if (cmbSL.Enabled == true)//&& cmbSL.Value <= 0.0M)
            {
                cmbSL.Value = (decimal)val;
            }
            CurrentOrder.StopLoss = val;
            //childControl.updateOnSLChanged((decimal)val);
            StockChartX1.Update();
        }
        public void SetTPLine(double val)
        {
            if (insertTakeProfit.Enabled)
                return;

            if (strSelectedSymbol_.Contains("JPY"))
            {
                //Kul
                //StockChartX1.AddTPLine(Math.Round(val, 3));
            }
            else
            {
                //Kul
                // StockChartX1.AddTPLine(Math.Round(val, 5));
            }
            if (cmbTP.Enabled == true)//&& cmbTP.Value <= 0.0M)
            {
                cmbTP.Value = (decimal)val;
            }
            CurrentOrder.TakeProfit = val;
            //childControl.updateOnTPChanged((decimal)val);
            StockChartX1.Update();
        }

        #endregion

        /// <summary>
        /// This region is responsibel to load values.Review done.
        /// </summary>
        /// <param name="side"></param>
        #region LOADING ZONE

        public void setControlsValue()
        {
            string[] args = new string[] { cbTypeMarketExecution, cbTypePending, cbTypeModify };
            loadTypeValues(args);

            cbType.SelectedIndex = 0;            
            loadChart(strSelectedSymbol_);
            loadContextMenuEvents();
            loadChartEvents();
            loadVolumes();
            //---Selecting
            cbSymbol.SelectedItem = strSelectedSymbol_;
            if (Properties.Settings.Default.IsAlwaysUseMinOrderQtyGiven)
                dDefaultVolume_ = Convert.ToDouble(Properties.Settings.Default.MinOrderQty);
            //Namo 21 March
            //else
            //    dDefaultVolume_ = clsTWSOrderManagerJSON.INSTANCE.Lotsize;
            cbVolume.SelectedIndex = 0;
            int index = Array.IndexOf(VolumnList.ToArray(), dDefaultVolume_.ToString("0.00"));
            if (index != -1)
                cbVolume.SelectedIndex = index;            
            cmbSL.Value = (decimal)dDefaultSL_;
            cmbTP.Value = (decimal)dDefaultTP_;
        }
        /// <summary>
        /// This function is responsible to load the value of comboBox cbType.
        /// </summary>
        /// <param name="args"></param>
        void loadTypeValues(string[] args)
        {
            cbType.Items.Clear();
            foreach (string temp in args)
            {
                cbType.Items.Add(temp);
            }
            int count = cbType.Items.Count;
        }
        /// <summary>
        /// This function loads all symbols
        /// </summary>
        void loadSymbols()
        {
            //cbSymbol.Items.AddRange(uctlForex.GetSymbolArray().ToArray());
            if (FrmMain.INSTANCE._ctlMW != null)
            {
                string portfolio = FrmMain.INSTANCE._ctlMW.uctlMarketWatch1.CurrentPortfolioName;
                if (!string.IsNullOrEmpty(portfolio))
                {
                    cbSymbol.Items.AddRange(FrmMain.INSTANCE.GetSymbolsOfPortfolio(portfolio).ToArray());
                    cbSymbol.SelectedIndex = cbSymbol.Items.IndexOf(CurrentOrder.Symbol);
                }
            }
            else
            {
                cbSymbol.Items.Add(CurrentOrder.Symbol);
                cbSymbol.SelectedIndex = 0;
            }

        }
        /// <summary>
        /// Load Voulmes in LOT
        /// </summary>
        void loadVolumesInLot()
        {
            //cbVolume.Items.AddRange(frmMainGTS.GetReference().uctlForex_.GetLotAmountArray());
            if (Properties.Settings.Default.MinOrderQty != 0)
                cbVolume.Text = Convert.ToString(Properties.Settings.Default.MinOrderQty);
            else
                cbVolume.Text = "1";
        }
        /// <summary>
        /// Load volumes in amount
        /// </summary>
        void loadVolumesInAmount()
        {
            //cbVolume.Items.AddRange(frmMainGTS.GetReference().uctlForex_.GetDefaultAmountArray());
        }
        private List<string> VolumnList = new List<string>();
        /// <summary>
        /// Load Volumes
        /// </summary>
        void loadVolumes()
        {
            //_frmOrderEntry.isVolumeinLot_ = Initializer.GetReference().objSettingForm_.bisPositionSizeInLot_;
            //if (_frmOrderEntry.isVolumeinLot_)
            //    loadVolumesInLot();
            //else
            //    loadVolumesInAmount();
            cbVolume.Items.Clear();
            VolumnList.Clear();
            List<string> volums = new List<string>();
            double x = clsTWSOrderManagerJSON.INSTANCE.Lotsize;
            for (int i = 1; i < 6; i++)
            {
                volums.Add((x * i).ToString("0.00"));
            }
            for (int i = 1; i < 6; i++)
            {
                volums.Add((x * i * 10).ToString("0.00"));
            }
            for (int i = 1; i < 6; i++)
            {
                volums.Add((x * i * 100).ToString("0.00"));
            }
            VolumnList = volums;
            cbVolume.Items.AddRange(volums.ToArray());
        }
        /// <summary>
        /// This function load charts
        /// </summary>
        /// <param name="symbol"></param>
        void loadChart(string symbol)
        {
            try
            {
                StockChartX1.RemoveAllSeries();
                StockChartX1.Symbol = symbol;

                //StockChartX1.ScalePrecision = Initializer.getChartYAxisPrecision(symbol);
                StockChartX1.RealTimeXLabels = true;
                StockChartX1.MaxDisplayRecords = StockChartX1.Width / 5;
                StockChartX1.ChartBackColor = Color.White;
                StockChartX1.ChartForeColor = Color.Black;
                StockChartX1.Gridcolor = Color.Gray;
                //First add a panel (chart area) for the OHLC data:
                long panel = StockChartX1.AddChartPanel();
                long panel1 = panel;
                //Now add the open, high, low and close series to that panel:
                StockChartX1.AddSeries(symbol + ".bid", SeriesType.stLineChart, (int)panel);
                StockChartX1.AddSeries(symbol + ".ask", SeriesType.stLineChart, (int)panel);
                //Change the color:
                StockChartX1.set_SeriesColor(symbol + ".bid", ColorTranslator.ToOle(_color4Sell));
                //Change the color:
                StockChartX1.set_SeriesColor(symbol + ".ask", ColorTranslator.ToOle(_color4Buy));
                try
                {
                    string BidTemp, AskTemp;
                    BidTemp = AskTemp = "0.0";
                    //ProtocolStructs.QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(strSelectedSymbol_);
                    //if (QR != null)
                    //{
                    //    StockChartX1.RealTimeXLabels = true;
                    //    StockChartX1.ThreeDStyle = true;
                    //    StockChartX1.Update();
                    //    StockChartX1.Visible = true;
                    //    HandleQuoteResponse(QR);
                    //}
                }
                catch (Exception ex)
                {
                    //ServerLog.Write("LoadChart1:: " + ex.ToString(), true);
                    //ServerLog.Write("NewOrderEntry::LoadChart1" + ex.ToString() + ex.StackTrace, true);
                    //Logger.LogEx(ex, "NewOrderEntry", "LoadChart(string symbol) Region1");
                }
            }
            catch (Exception ex)
            {
                //ServerLog.Write("Loadchart2:: " + ex.ToString(), true);
                //ServerLog.Write("NewOrderEntry::LoadChart2" + ex.ToString() + ex.StackTrace, true);
                //Logger.LogEx(ex, "NewOrderEntry", "LoadChart(string symbol) Region2");
            }

        }
        /// <summary>
        /// This method set events for chart context menu 
        /// Insert Stop Loss
        /// Insert Take Profit
        /// </summary>
        void loadContextMenuEvents()
        {
            insertStopLoss.Click += new CommandEventHandler(insertStopLoss_Click);
            insertTakeProfit.Click += new CommandEventHandler(insertTakeProfit_Click);
            insertEntryPrice.Click += new CommandEventHandler(insertEntryPrice_Click);
        }
        /// <summary>
        /// To load chart events
        /// </summary>
        void loadChartEvents()
        {
            this.StockChartX1.MouseMoveEvent += new AxSTOCKCHARTXLib._DStockChartXEvents_MouseMoveEventHandler(this.StockChartX1_MouseMoveEvent);
            this.StockChartX1.OnRButtonDown += new System.EventHandler(this.StockChartX1_OnRButtonDown);
            this.StockChartX1.OnRButtonUp += new System.EventHandler(this.StockChartX1_OnRButtonUp);
            //Kul
            //this.StockChartX1.ValueChanged += new AxSTOCKCHARTXLib._DStockChartXEvents_ValueChangedEventHandler(this.StockChartX1_ValueChanged);
            this.StockChartX1.PaintEvent += new AxSTOCKCHARTXLib._DStockChartXEvents_PaintEventHandler(this.StockChartX1_PaintEvent);
        }
        /// <summary>
        /// TO subscribe Quote Manager and OrderManager
        /// </summary>
        void loadAllSubscription()
        {
            //foreach (string str in uctlForex.GetSymbolArray())
            //{
            //    QuoteManager.getQuoteManager().AddQuoteWatchItem(str, this);
            //}
            //OrderManager.getOrderManager().AddOrderWatchItem(this, OrderManagerSubscriptionType.TRADE);
        }
        private void frmOrderEntry_Load(object sender, EventArgs e)
        {
            _orderExecutionStatus.OnOrderExecutionFinal_OkClick -= new Action<object, EventArgs>(_orderExecutionStatus_OnOrderExecutionFinal_OkClick);
            _orderExecutionStatus.OnOrderExecutionFinal_PrintClick -= new Action<object, EventArgs>(_orderExecutionStatus_OnOrderExecutionFinal_PrintClick);
            _orderExecutionStatus.OnOrderExecutionFinal_OkClick += new Action<object, EventArgs>(_orderExecutionStatus_OnOrderExecutionFinal_OkClick);
            _orderExecutionStatus.OnOrderExecutionFinal_PrintClick += new Action<object, EventArgs>(_orderExecutionStatus_OnOrderExecutionFinal_PrintClick);
        }

        void _orderExecutionStatus_OnOrderExecutionFinal_PrintClick(object arg1, EventArgs arg2)
        {

        }

        void _orderExecutionStatus_OnOrderExecutionFinal_OkClick(object arg1, EventArgs arg2)
        {
            this.Close();
        }
        /// <summary>
        /// Default values means setting form values
        /// Sl, TP, Qunatity, 
        /// </summary>
        //void SetOrderDefaultTypeValues(clsInterface4OME.Side side)
        //{
        //if (!isSetDefaultValues)
        //    return;

        //string strVolume = string.Empty;
        //if (side == clsInterface4OME.Side.NA)
        //{
        //    OrderUtility_.GetOrderDefaultType(strSelectedSymbol_, out strVolume,
        //                                      out dDefaultSL_, out dDefaultTP_,
        //                                      out isVolumeinLot_, clsInterface4OME.Side.BUY);
        //}
        //else
        //{
        //    OrderUtility_.GetOrderDefaultType(strSelectedSymbol_, out strVolume,
        //                                      out dDefaultSL_, out dDefaultTP_,
        //                                      out isVolumeinLot_, side);
        //}
        //dDefaultVolume_ = Convert.ToDouble(strVolume);
        //}
        void SetSL_TPBehaviour()
        {
            if (strSelectedSymbol_.Contains("JPY"))
            {
                cmbSL.DecimalPlaces = cmbTP.DecimalPlaces = 2;
                cmbSL.Increment = cmbTP.Increment = 0.01M;
            }
            else
            {
                cmbSL.DecimalPlaces = cmbTP.DecimalPlaces = 4;
                cmbSL.Increment = cmbTP.Increment = 0.0001M;
            }
        }


        public double getFormattedVolume(int Volume)
        {
            double Vol = 0.0;
            if (isVolumeinLot_)
            {
                //Vol = OrderUtility_.GetAmountinLot(Volume);

            }
            else
            {
                Vol = Volume;
            }
            return Vol;

        }

        #endregion

        /// <summary>
        /// This region handles data comming 4m server.
        /// </summary>
        /// <param name="QR"></param>
        /// 
        //#region HANDLE PROTOCOLSTRUCTS
        //void HandleQuoteResponse(QuoteResponse QR)
        //{
        //    if (!QR.Symbol_.Equals(strSelectedSymbol_, StringComparison.CurrentCultureIgnoreCase))
        //        return;
        //    Action a = () =>
        //        {
        //            UpdateOnQuote(QR);
        //        };
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(a);
        //    }
        //    else
        //    {
        //        a.Invoke();
        //    }
        //}
        //void HandleOrderResponse(ExecutionReport ER)
        //{
        //    switch (ER.Status4UIDbg)
        //    {
        //        case clsInterface4OME.OrderStatus.ACKNOWLEDGE:
        //            if (CurrentOrder.RequestType == ER.RequestType)
        //            {
        //                CurrentOrder.ClientOrderID = ER.ClientOrderID;
        //                if (ER.OrderType == clsInterface4OME.OrderType.LIMIT
        //                    || ER.OrderType == clsInterface4OME.OrderType.STP)
        //                {
        //                    HandleResponse(ER);
        //                }
        //            }
        //            break;
        //        case clsInterface4OME.OrderStatus.CANCELED:
        //            HandleResponse(ER);
        //            break;
        //        case clsInterface4OME.OrderStatus.CANCEL_PENDING:
        //            break;
        //        case clsInterface4OME.OrderStatus.CLOSE_PROCESS:
        //            break;
        //        case clsInterface4OME.OrderStatus.CNCIP:
        //            break;
        //        case clsInterface4OME.OrderStatus.EXPIRED:
        //            break;
        //        case clsInterface4OME.OrderStatus.MODIFIED:
        //            HandleResponse(ER);
        //            break;
        //        case clsInterface4OME.OrderStatus.MODIFY_PENDING:
        //            break;
        //        case clsInterface4OME.OrderStatus.MULTIPLE:
        //            break;
        //        case clsInterface4OME.OrderStatus.NEW:
        //            break;
        //        case clsInterface4OME.OrderStatus.NOTVALID:
        //            break;
        //        case clsInterface4OME.OrderStatus.FILLED:
        //        case clsInterface4OME.OrderStatus.PARTIAL_FILLED:
        //            if (ER.OrderType == clsInterface4OME.OrderType.MARKET)
        //            {
        //                HandleResponse(ER);
        //            }
        //            break;
        //        case clsInterface4OME.OrderStatus.PARTIAL_REJECTED:
        //            break;
        //        case clsInterface4OME.OrderStatus.PARTIAL_CANCELLED:
        //            break;
        //        case clsInterface4OME.OrderStatus.CLOSED:
        //        case clsInterface4OME.OrderStatus.PARTIAL_CLOSED:
        //            HandleResponse(ER);
        //            break;
        //        case clsInterface4OME.OrderStatus.PENDING:
        //            break;
        //        case clsInterface4OME.OrderStatus.REJECTED:
        //            break;
        //        case clsInterface4OME.OrderStatus.SENT:
        //            break;
        //        case clsInterface4OME.OrderStatus.SLTP_URG_CLOSED_IN_PROCESS:
        //            break;
        //        case clsInterface4OME.OrderStatus.WORKING:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //void HandleResponse(ExecutionReport ER)
        //{
        //    if (CurrentOrder.ClientOrderID == ER.ClientOrderID)
        //    {
        //        Action a = () =>
        //        {
        //            gbParent.Controls.Clear();
        //            GTS.Ctrl.ucOrderExecutionStatus obj = new GTS.Ctrl.ucOrderExecutionStatus(this, ER);
        //            //(obj as UserControl).Dock = DockStyle.Fill;
        //            gbParent.Controls.Add(obj);
        //        };
        //        if (this.InvokeRequired)
        //        {
        //            this.BeginInvoke(a);
        //        }
        //        else
        //        {
        //            a.Invoke();
        //        }
        //    }
        //}
        //#endregion

        #region Subscribers
        //#region IQuoteSubscriber Members

        //public IntPtr QuoteGetHandle()
        //{
        //    try
        //    {
        //        IntPtr checkHandle = new IntPtr();
        //        if (this.InvokeRequired)
        //        {
        //            Action a = () => { checkHandle = Handle; };
        //            this.Invoke(a);
        //        }
        //        else
        //        {
        //            return IsHandleCreated ? Handle : IntPtr.Zero;
        //        }
        //        return IsHandleCreated ? checkHandle : IntPtr.Zero;

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogEx(ex, "frmOrderEntry", "QuoteGetHandle()");
        //        return IntPtr.Zero;
        //    }
        //}

        //public void QuoteSubscriberData(ProtocolStructs.IProtocolStruct PS)
        //{
        //    switch (PS.ID)
        //    {
        //        case ProtocolStructIDS.Quote_ResponseID:
        //            {
        //                switch (PS.ID)
        //                {
        //                    case ProtocolStructs.ProtocolStructIDS.Quote_ResponseID:
        //                        {
        //                            QuoteResponse QR = (PS as QuoteResponsePS).QuoteResponse_;

        //                            HandleQuoteResponse(QR);

        //                        }
        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }
        //            break;

        //        default:
        //            break;
        //    }
        //}

        //public void QuoteSubscriberExceptionInfo(Exception ex) { }
        //#endregion

        //#region IOrderSubscriber Members

        //public IntPtr OrderGetHandle()
        //{
        //    IntPtr checkHandle = new IntPtr();
        //    if (this.InvokeRequired)
        //    {
        //        Action a = () => { checkHandle = Handle; };
        //        this.Invoke(a);
        //    }
        //    else
        //        return IsHandleCreated ? Handle : IntPtr.Zero;

        //    return IsHandleCreated ? checkHandle : IntPtr.Zero;
        //}

        //public void OrderSubscriberData(ProtocolStructs.IProtocolStruct PS)
        //{
        //    switch (PS.ID)
        //    {
        //        case ProtocolStructs.ProtocolStructIDS.ExecutionReport_ID:
        //            {
        //                ExecutionReportPS ERPS = PS as ExecutionReportPS;
        //                HandleOrderResponse(ERPS.Request);

        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public void OrderSubscriberExceptionInfo(Exception ex) { }
        //public void OrderStatus(string OrderID, string Status) { }
        //#endregion

        private void cbSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSelectedSymbol_ = CurrentOrder.Symbol = cbSymbol.SelectedItem.ToString();
            
            string currentPortfolio = PALSA.Cls.ClsGlobal.CurrentPortfolio;
            if (currentPortfolio != string.Empty)
            {
                //Namo 22 March
                //ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)PALSA.Cls.ClsGlobal.LatestPortfolio)[currentPortfolio];
                //foreach (string key in from key in objPortfolio.Products.Keys let symbol = Symbol.GetSymbol(key) where symbol.Contract == cbSymbol.SelectedItem.ToString() select key)
                //{
                //    selectedKey = key;
                //    break;
                //}
            }
            if (childControl is uctlMarketExecution)
            {
                ((uctlMarketExecution)this.childControl).AskValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(strSelectedSymbol_));
                ((uctlMarketExecution)this.childControl).BidValue = Convert.ToString(PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(strSelectedSymbol_));
                _askPrice = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(strSelectedSymbol_);
                _bidPrice = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(strSelectedSymbol_);
            }
            
            cbVolume.SelectedIndex = 0;
            loadChart(strSelectedSymbol_);
        }


        #endregion

        /// <summary>
        /// Validation related methods.REview done.
        /// </summary>
        /// <param name="result"></param>
        //#region Validation
        //public void setLockOnChildControl(bool result)
        //{
        //    if (childControl != null)
        //    {
        //        if (typeof(GTS.Ctrl.ucModifyFill) == childControl.GetType())
        //        {
        //            (childControl as GTS.Ctrl.ucModifyFill).setLock(result);
        //        }
        //        else if (typeof(GTS.Ctrl.ucModifyPending) == childControl.GetType())
        //        {
        //            (childControl as GTS.Ctrl.ucModifyPending).setLock(result);
        //        }
        //    }
        //}

        //public bool validateNewOrder(clsInterface4OME.Order order, out string reason)
        //{
        //    bool result = OrderValidation.ValidateOrder(order, out reason);
        //    return result;
        //}

        //public void validateOrderOnModify(clsInterface4OME.Order order)
        //{
        //    string reason = string.Empty;
        //    bool result = OrderValidation.ValidateOrder(order, out reason);
        //    setLockOnChildControl(result);
        //}

        private void showErrorMessage(string reason)
        {
            //gbParent.Controls.Clear();
            //childControl = new ucOrderExecutionStatus(_frmOrderEntry, reason);
            //UserControl UC = childControl as UserControl;
            //gbParent.Controls.Add(UC);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void gbParent_Click(object sender, EventArgs e)
        {

        }

        private void txtSL_MouseDown(object sender, MouseEventArgs e)
        {
            decimal value = SetSLTP4mBid(strSelectedSymbol_);
            //if (cmbSL.Maximum < value)
            //    cmbSL.Maximum = value + 10;
            if (Convert.ToDecimal(txtSL.Text) <= 0.0M)
            {
                txtSL.Text = Convert.ToString(value);
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            double sl = 0;
            Double.TryParse(txtSL.Text, out sl);
            CurrentOrder.StopLoss = sl;
        }

        private void txtTP_TextChanged(object sender, EventArgs e)
        {
            double tp = 0;
            Double.TryParse(txtTP.Text, out tp);
            CurrentOrder.TakeProfit = tp;
        }

        private void txtTP_MouseDown(object sender, MouseEventArgs e)
        {
            decimal value = SetSLTP4mBid(strSelectedSymbol_);
            //if (cmbTP.Maximum < value)
            //    cmbTP.Maximum = value + 10;
            if (Convert.ToDecimal(txtTP.Text) <= 0.0M)
            {
                txtTP.Text = Convert.ToString(value);
            }
        }

        private void cbVolume_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (cbVolume.Text != string.Empty)
            //{
            //    double x = Convert.ToDouble(cbVolume.Text) / clsTWSOrderManagerJSON.INSTANCE.Lotsize;
            //    if (x != 0 && x == Convert.ToDouble(Convert.ToInt32(x)))
            //    {
            //        childControl.Enabled = true;
            //    }
            //    else
            //    {
            //        childControl.Enabled = false;
            //    }
            //}
            //else
            //{
            //    childControl.Enabled = false;
            //}
        }

        private void cbVolume_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtVolume_TextChanged(object sender, EventArgs e)
        {
            double volume = 0;
            if (txtVolume.Text != string.Empty && txtVolume.Text != ".")
            {
                volume = Convert.ToDouble(txtVolume.Text);
            }
            if (volume != 0)
            {
                double x = volume / clsTWSOrderManagerJSON.INSTANCE.Lotsize;
                if (x != 0 && x == Convert.ToDouble(Convert.ToInt32(x)))
                {
                    childControl.Enabled = true;
                    //cbVolume.Text=txtVolume.Text ;
                    double selVol = volume;
                    CurrentOrder.Quantity = selVol;
                }
                else
                {
                    childControl.Enabled = false;
                }
            }
            else
            {
                childControl.Enabled = false;
            }
        }

        private void frmOrderEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
        }

        //#endregion
    }
}
