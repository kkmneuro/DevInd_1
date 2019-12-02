///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//                          2.Code to Disable All menuItems of Window menu items if no forms opened 
//20/02/2012	Namo        1.Code for Display only four instance of Market Watch
//                          2.Change the code for displaying the IndexView
//22/02/2012    Namo        1.Completed code of Ticker for Default Portfolio
//                          2.Completed code of Ticker for Selected portfolio in script Portfolio window
//24/02/2012    Namo        1.Select the Display for the ticker as Desc or Symbol. for Ticker 
//                          2.Code for closing of orderentry and modify orderentry form from prference order tab
//                          3.Code for All open windows should be added at runtime to Window Menu as sub items and checing of window active item in Window menu
//24 Jun 2014	Namo		1.Event(onMarketPriceUpdate) is implemented for pnl calculation
//                          2. PnL calculation on timer event is removed
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using CommonLibrary.Cls;
using CommonLibrary.UserControls;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using TWS.Cls;
using TWS.Frm;
using TWS.Properties;
using System.Data;
using System.ComponentModel;


namespace TWS
{
    /// <summary>
    /// Contains code for Mainform (TWS)
    /// </summary>
    public partial class FrmMain : NForm
    {
        private static FrmMain _instance;
        private readonly List<Form> _ChildFormList = new List<Form>();
        private readonly Hashtable _CommandBarHash = new Hashtable();
        private readonly UctlTickerTape _objTickerTape = new UctlTickerTape();
        private readonly UctlLogin _objuctlLogin = new UctlLogin();
        private frmProductInfo productInfo = null;
        private readonly Form objForm = new Form();
        public Hashtable _hotKeySettingsHashTable;
        private ConnectionIPs _objConnectionIPs = new ConnectionIPs();
        private object _portfolio;
        private object _profiles;
        private Hashtable _revercedHotKeySettingsHashTable;
        private string[] _loginData;
        public string username = string.Empty;
        private Keys _shortcutKeyBuyOrderEntry;
        private Keys _shortcutKeyCancelAllOrders;
        private static Keys _shortcutKeyFilter;
        private Keys _shortcutKeyMarketPicture = Keys.None;
        private Keys _shortcutKeyModifyTrades;
        private Keys _shortcutKeySellOrderEntry;
        bool _flagFirstParticipantListResponce = false;
        private FormState formState = new FormState();
        private TWSSettings objTWSSettings = new TWSSettings();
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        frmMails objMail;
        frmLoadInitialDetails objfrmLoadInitialDetails;
        frmTradeWindowFilter objfrmTradeWindow;
        bool _isSplashClosed = false;
        bool _isMarketWatchOpen = false;
        public event Action<string> onPnLUpdate = delegate { };
        System.Threading.Thread splash;
        /// <summary>
        /// Called when form componenets is initialized
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            Thread contract = new Thread(ContractThreadHandler);
            contract.IsBackground = true;
            contract.Start();
        }

        private void ContractThreadHandler()
        {
            try
            {
                ClsTWSContractManager.INSTANCE.LoadIntialData();
            }
            catch (Exception)
            {

            }
        }
        public static FrmMain INSTANCE
        {
            get { return _instance ?? (_instance = new FrmMain()); }
        }

        public object Profiles
        {
            get { return _profiles; }
            set { _profiles = value; }
        }
        public string StatusMessage
        {
            get { return tlstrplblStatusMsg.Text; }
            set { tlstrplblStatusMsg.Text = value; }
        }
        /// <summary>
        /// Set ticker values from preferences
        /// </summary>
        /// <param name="tickerSpeed"></param>
        public void SetTickerValues(int tickerSpeed)
        {
            _objTickerTape.SetTickerSpeed(tickerSpeed);
            if (_objTickerTape._currentTickerPortfolio != null &&
                _objTickerTape._currentTickerPortfolio != "---SELECT---")
            {
                AddDataToTicker(_objTickerTape._currentTickerPortfolio);
            }
        }


        private void LoadServerIps()
        {
            string strSetting = Application.StartupPath + "\\ServerHostIps.xml";
            var objStreamReader = new StreamReader(strSetting);
            try
            {
                XmlSerializer _objXmlSerializer = XmlSerializer.FromTypes(new[] { typeof(ConnectionIPs) })[0];
                _objConnectionIPs = (ConnectionIPs)_objXmlSerializer.Deserialize(objStreamReader);
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Sets the initial values for the form(Loads last workspace and theme)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {

            Properties.Settings.Default.UserName = Cls.ClsGlobal.ProductName;
            ClsCommonMethods.ProductName = Cls.ClsGlobal.ProductName; //To set title of pop up message box
            this.Icon = Cls.ClsGlobal.Icon;
            SetCommandsIDs();
            DisableCommandIDs();
            var obj = new CommandEventArgs(new NCommand());
            //Properties.Settings.Default.Theme = (int)CommandIDS.AQUA;
            obj.Command.Properties.ID = Properties.Settings.Default.Theme;
            ui_ncbmTWS_CommandClicked(null, obj);
            LoadImages();
            tableLayoutPanel2.Visible = false;
            objMail = new frmMails();

            clsTWSOrderManagerJSON.INSTANCE.OnLogonResponse -= new Action<string, string, bool>(INSTANCE_OnLogonResponce);
            clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse -= new Action<Dictionary<int, DataRow>>(INSTANCE_OnParticipantResponse);
            clsTWSOrderManagerJSON.INSTANCE.OnLogonResponse += new Action<string, string, bool>(INSTANCE_OnLogonResponce);
            clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse += new Action<Dictionary<int, DataRow>>(INSTANCE_OnParticipantResponse);
            clsTWSDataManagerJSON.INSTANCE.onMarketPriceUpdate -= new Action<string>(INSTANCE_onMarketPriceUpdate);
            clsTWSDataManagerJSON.INSTANCE.onMarketPriceUpdate += new Action<string>(INSTANCE_onMarketPriceUpdate);
            clsTWSOrderManagerJSON.INSTANCE.OnTradeHistoryLoaded -= new Action(INSTANCE_OnTradeHistoryLoaded);
            clsTWSOrderManagerJSON.INSTANCE.OnTradeHistoryLoaded += new Action(INSTANCE_OnTradeHistoryLoaded);
            //clsTWSDataManagerJSON.INSTANCE.OnQuotesStream -= INSTANCE_OnQuotesStream;
            //clsTWSDataManagerJSON.INSTANCE.OnQuotesStream += INSTANCE_OnQuotesStream;

            if (LoginMenuHandler() != DialogResult.Cancel)
                ui_nmnuBar.Enabled = true;

            ui_nmnuWindows.Select -= ui_nmnuWindows_Select;
            ui_nmnuWindows.Select += ui_nmnuWindows_Select;
            this.ui_ncmdViewMail.Properties.Visible = false;
            this.ui_ncmdMarketQuote.Properties.Visible = false;
            this.ui_ncmdToolsSimulator.Properties.Visible = false;

        }

        //private void INSTANCE_OnQuotesStream(QuotesStream obj)
        //{
        //    throw new NotImplementedException();
        //}

        void INSTANCE_OnTradeHistoryLoaded()
        {
            if (_profiles != null)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {

                        EnableCommandIDs();
                        try
                        {
                            if (objfrmLoadInitialDetails!=null && !objfrmLoadInitialDetails.IsDisposed)
                            {
                                objfrmLoadInitialDetails.Dispose();
                            }
                            splash.Suspend();
                        }
                        catch (Exception)
                        {

                        }
                        
                        _isSplashClosed = true;
                        if (!_isMarketWatchOpen)
                        {
                            MarketWatchMenuHandler();
                        }
                    });
                }
            }

            else
            {
                try
                {
                    EnableCommandIDs();
                  
                    if (!_isSplashClosed && splash != null)
                    {
                        try
                        {
                            if (objfrmLoadInitialDetails != null && !objfrmLoadInitialDetails.IsDisposed)
                            {
                                objfrmLoadInitialDetails.Dispose();
                            }
                            splash.Suspend();
                        }
                        catch (Exception)
                        {

                        }
                        
                        _isSplashClosed = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at INSTANCE_OnTradeHistoryLoaded" + ex.Message);
                }
            }

        }

        private bool LoggedInSuccess = false;

        public void ShowSplash()
        {
            try
            {
                objfrmLoadInitialDetails = new frmLoadInitialDetails();
                objfrmLoadInitialDetails.TopMost = true;
                objfrmLoadInitialDetails.StartPosition = FormStartPosition.CenterParent;

                objfrmLoadInitialDetails.ShowDialog();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
         
        }
        

        private void INSTANCE_OnLogonResponce(string reason, string brokerName, bool isRelogin)
        {
            if (reason == "VALID")
            {

                splash = new Thread(new ThreadStart(ShowSplash));
                splash.IsBackground = true;
                splash.Start();
                ui_ncmdDataServerStatus.Properties.Visible = true;
                ui_ncmdOrderServerStatus.Properties.Visible = true;
                if (File.Exists(Application.StartupPath + "\\" + _objuctlLogin.UserCode + ".xml"))
                {
                    FileInfo finfo = new FileInfo(Application.StartupPath + "\\" + _objuctlLogin.UserCode + ".xml");
                    if (finfo.Length > 5000)
                    {
                        File.Delete(Application.StartupPath + "\\" + _objuctlLogin.UserCode + ".xml");
                    }
                    else
                    {
                        clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.ReadXml(Application.StartupPath + "\\" + _objuctlLogin.UserCode + ".xml");
                    }
                }
                LoggedInSuccess = true;
                clsTWSOrderManagerJSON.INSTANCE.Refresh();
                clsTWSDataManagerJSON.INSTANCE.Refresh();
                _portfolio = GetPortfolios(_objuctlLogin.UserCode);
                GetProfiles();
                LoadDefaultWorkSpace();
                ClsLocalizationHandler.INSTANCE.Init();
                SetFilterBarValues();
                SetContextMenuItemHotKeys();
                _objTickerTape.PortfolioList = _portfolio;
                clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport -= INSTANCE_DoHandleExecutionReport;
                clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject -= INSTANCE_OnBusinessLevelReject;
                clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_DoHandleExecutionReport;
                clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject += INSTANCE_OnBusinessLevelReject;
                clsTWSOrderManagerJSON.INSTANCE.OnShortOrderUpdate += INSTANCE_OnShortOrderUpdate;
                tlstrplblStatusMsg.Text = "Successfully logged in.";
            }

            else
            {
                ui_ncmdFileLogin.Properties.ID = (int)CommandIDS.LOGIN;
                SetHotkeyHashTable(CommandIDS.LOGIN, ui_ncmdFileLogin);
                ui_ncmdFileLogin.Enabled = true;
                MessageBox.Show(reason, TWS.Cls.ClsGlobal.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (LoginMenuHandler() != DialogResult.Cancel)
                    ui_nmnuBar.Enabled = true;
            }
            objForm.KeyDown -= objForm_KeyDown;
            _objuctlLogin.OnOkClick -= objuctlLogin_OnOkClick;
            _objuctlLogin.OnCancelClick -= objuctlLogin_OnCancelClick;


        }


        private void INSTANCE_OnShortOrderUpdate(string obj)
        {
            Action A = () =>
            {
                tlstrplblStatusMsg.Text = obj;
                tlstrplblStatusMsg.BackColor = Color.Yellow;
                tlstrplblStatusMsg.ForeColor = Color.Red;
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
        private void INSTANCE_OnBusinessLevelReject(DataRow obj, BusinessReject objBusinessReject)
        {
            Action A = () =>
            {
                if (obj != null)
                {
                    string orderStatus = "Rejected";//obj["OrderStatus"].ToString(); //TWS.Cls.ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(obj["OrderStatus"].ToString())];
                    string side = obj["Side"].ToString();// TWS.Cls.ClsGlobal.DDReverseSide[Convert.ToSByte(obj["Side"].ToString())];
                    string orderid = obj["OrderId"].ToString();
                    string contract = obj["Contract"].ToString();
                    string ordQty = obj["orderQty"].ToString();
                    string price = obj["price"].ToString();
                    string Reason = obj["Text"].ToString();
                    string date = obj["TransactTime"].ToString();
                    tlstrplblStatusMsg.Text = "Your request for " + side + " Order with OrderID > " + orderid + " for Symbol > " + contract + " Qty > " + ordQty + " Price > " + price + " is " + orderStatus + " due to reason > " + Reason + " on Date > " + date + " .";

                }
                else
                {
                    DateTime date = DateTime.Now;
                    string str = string.Empty;
                    if (Properties.Settings.Default.TimeFormat.Contains("24"))
                    {
                        str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", date);
                    }
                    else
                    {
                        str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", date);
                    }

                    string reason = Enum.GetName(typeof(BusinessRejectReason), objBusinessReject.BusinessRejectReason);
                    string text = objBusinessReject.Text;

                    tlstrplblStatusMsg.Text = "Your New Order with OrderID > " + objBusinessReject.BusinessRejectRefID + " is REJECTED due to reason > " + reason + " on Date > " + str + " .";
                }
                tlstrplblStatusMsg.BackColor = Color.Yellow;
                tlstrplblStatusMsg.ForeColor = Color.Red;
                //tlstrplblStatusMsg.Text = "Your " + side + " Order OrderID " + orderid + " for Symbol " + contract + " Qty @ Price " + ordQty + " @ " + price + " is " + orderStatus + " Reason " + Reason+ " .";
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

        void INSTANCE_DoHandleExecutionReport(Cls.ExecutionReport executionReport)
        {
            Action A = () =>
            {
                if (Cls.ClsGlobal.DDReverseOrderStatus.ContainsKey(Convert.ToSByte(executionReport.OrderStatus)) && Cls.ClsGlobal.DDReverseSide.ContainsKey(Convert.ToSByte(executionReport.Side))
                    && Cls.ClsGlobal.DDReverseOrderType.ContainsKey(Convert.ToSByte(executionReport.OrderType)))
                {
                    string orderStatus = Cls.ClsGlobal.DDReverseOrderStatus[Convert.ToSByte(executionReport.OrderStatus)];
                    string side = Cls.ClsGlobal.DDReverseSide[Convert.ToSByte(executionReport.Side)];
                    string orderType = Cls.ClsGlobal.DDReverseOrderType[Convert.ToSByte(executionReport.OrderType)];
                    double _TransactTime = 0;
                    double.TryParse(executionReport.TransactTime.Trim(), out _TransactTime);
                    DateTime TransactTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromOAdate(_TransactTime);
                    int contractSize = 1;
                    double digit = 0;
                    if (Cls.ClsGlobal.DDContractSize.ContainsKey(executionReport.Contract.Trim()))
                    {
                        contractSize = Cls.ClsGlobal.DDContractSize[executionReport.Contract.Trim()];
                    }
                    if (Cls.ClsGlobal.DDContractDigit.ContainsKey(executionReport.Contract.Trim()))
                    {
                        digit = Cls.ClsGlobal.DDContractDigit[executionReport.Contract.Trim()];
                    }

                    if (orderStatus.ToUpper() != "FILLED")
                    {
                        tlstrplblStatusMsg.ForeColor = Color.Black;
                        if (orderType.ToUpper() == "STOP")
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(executionReport.Account) +
                                " with OrderID > " + executionReport.OrderID + " for Symbol > " + executionReport.Contract +
                                " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Triger Price > " + (executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus +
                                " on Date > " + TransactTime.ToString() + " .";
                        }
                        else if (orderType.ToUpper() == "STOP_LIMIT")
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(executionReport.Account) +
                                " with OrderID > " + executionReport.OrderID + " for Symbol > " + executionReport.Contract +
                                " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Price > " + (executionReport.Price / Convert.ToDecimal(Math.Pow(10, digit))).ToString()
                                + " Trigger Price >" + (executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus +
                                " on Date > " + TransactTime.ToString() + " .";
                        }
                        else
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" + Convert.ToString(executionReport.Account) +
                                " with OrderID > " + executionReport.OrderID + " for Symbol > " + executionReport.Contract +
                                " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Price > " + (executionReport.Price / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus +
                                " on Date > " + TransactTime.ToString() + " .";
                        }
                        if (orderType.ToUpper() == "LIMIT")
                        {
                            tlstrplblStatusMsg.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (side.ToUpper() == "BUY")
                            {
                                tlstrplblStatusMsg.BackColor = Properties.Settings.Default.BuyOrderColor;
                            }
                            else if (side.ToUpper() == "SELL")
                            {
                                tlstrplblStatusMsg.BackColor = Properties.Settings.Default.SellOrderColor;
                            }
                        }
                    }
                    else
                    {
                        if (orderStatus.ToUpper() == "FILLED" && orderType.ToUpper() == "LIMIT")
                        {
                            tlstrplblStatusMsg.ForeColor = Color.White;
                            if (side.ToUpper() == "BUY")
                            {
                                tlstrplblStatusMsg.BackColor = Color.Green;
                            }
                            else if (side.ToUpper() == "SELL")
                            {
                                tlstrplblStatusMsg.BackColor = Color.Red;
                            }
                        }
                        if (orderType.ToUpper() == "STOP")
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" +
                            Convert.ToString(executionReport.Account) + " with OrderID > " + executionReport.OrderID +
                            " for Symbol > " + executionReport.Contract + " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Trigger Price > " +
                            (executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus + " at " + (executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " with Trade No. > " +
                            executionReport.ExecID + " on Date > " + TransactTime.ToString() + " .";
                        }
                        else if (orderType.ToUpper() == "STOP_LIMIT")
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" +
                            Convert.ToString(executionReport.Account) + " with OrderID > " + executionReport.OrderID +
                            " for Symbol > " + executionReport.Contract + " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Price > " +
                            (executionReport.Price / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " Trigger Price > " +
                            (executionReport.StopPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus + " at " + (executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " with Trade No. > " +
                            executionReport.ExecID + " on Date > " + TransactTime.ToString() + " .";
                        }
                        else
                        {
                            tlstrplblStatusMsg.Text = "Your " + side + " " + orderType + " Order From Account >" +
                            Convert.ToString(executionReport.Account) + " with OrderID > " + executionReport.OrderID +
                            " for Symbol > " + executionReport.Contract + " Qty > " + (executionReport.OrderQty / contractSize).ToString() + " Price > " +
                            (executionReport.Price / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " is " + orderStatus + " at " + (executionReport.LastPx / Convert.ToDecimal(Math.Pow(10, digit))).ToString() + " with Trade No. > " +
                            executionReport.ExecID + " on Date > " + TransactTime.ToString() + " .";
                        }

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
        double UrPnl = 0;
        void INSTANCE_OnParticipantResponse(Dictionary<int, DataRow> obj)
        {
            if (!_flagFirstParticipantListResponce)
            {
                ui_ncmbInstrumentType.Items.Clear();
                ui_ncmbInstrumentType.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys.ToArray());
                foreach (string PrdctType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                {
                    try
                    {
                        if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(PrdctType))
                        {
                            foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType].Keys)
                            {
                                try
                                {
                                    foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType][prdct])
                                    {
                                        try
                                        {
                                            if (!TWS.Cls.ClsGlobal.FutureSymbolList.Contains(symbl))
                                                TWS.Cls.ClsGlobal.FutureSymbolList.Add(symbl);
                                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                            {
                                                InstrumentSpec insSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                if (!TWS.Cls.ClsGlobal.DDContractSize.ContainsKey(symbl))
                                                {
                                                    TWS.Cls.ClsGlobal.DDContractSize.Add(symbl, insSpec.ContractSize);
                                                    TWS.Cls.ClsGlobal.DDContractDigit.Add(symbl, insSpec.Digits);
                                                }
                                            }

                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                }
                                catch (Exception)
                                {

                                }

                            }
                        }
                    }
                    catch (Exception)
                    {

                    }


                }

                if (TWS.Cls.ClsGlobal.BrokerAccountId > 0)
                {
                    ui_ncmdViewNetPosition.Enabled = false;
                    ui_nmnuSurveillanceSurveillance.Enabled = true;
                }
                else
                {
                    ui_ncmdViewNetPosition.Enabled = true;
                    ui_nmnuSurveillanceSurveillance.Enabled = false;
                }

                if (Properties.Settings.Default.AccountType.ToUpper() == "BROKER")
                {
                    tableLayoutPanel2.Visible = false;
                    ui_nmnuBroker.Properties.Visible = true;
                    ui_nmnuRiskManager.Properties.Visible = true;
                }
                else
                {
                    tableLayoutPanel2.Visible = true;
                    ui_nmnuBroker.Properties.Visible = false;
                    ui_nmnuRiskManager.Properties.Visible = false;
                }
                _flagFirstParticipantListResponce = true;
            }
            if (objMail != null)
            {
                DateTime toDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(7));
                DateTime fromDate = DateTime.UtcNow;

                List<MailData> lstMail = new List<MailData>();

            }
            Action A = () =>
            {
                //timer1.Enabled = true;
                DataRow dr = obj[obj.Keys.ToArray()[0]];
                double margin = 0;
                double balance = 0;
                double equity = 0;
                if (dr["Balance"].ToString() != string.Empty)
                    balance = Convert.ToDouble(dr["Balance"].ToString());
                if (dr["UsedMargin"].ToString() != string.Empty)
                {
                    if (!double.IsNaN(Convert.ToDouble(dr["UsedMargin"].ToString().Trim())))
                    {
                        margin = Convert.ToDouble(dr["UsedMargin"].ToString().Trim());
                    }

                    lblUsedMargin.Visible = true;
                    lblMarginLevel.Visible = true;
                    tlsMarginValue.Visible = true;
                    tlsMarginLevelValue.Visible = true;
                }
                else
                {
                    lblUsedMargin.Visible = false;
                    lblMarginLevel.Visible = false;
                    tlsMarginValue.Visible = false;
                    tlsMarginLevelValue.Visible = false;
                }
                if (tlsEquityValue.Text != string.Empty && !double.IsNaN(Convert.ToDouble(tlsEquityValue.Text.Trim())))
                    equity = Convert.ToDouble(tlsEquityValue.Text);
                tlsMarginValue.Text = Convert.ToString(Math.Round(margin, 2));
                tlsBalanceValue.Text = Convert.ToString(Math.Round(balance, 2));
                tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text.Trim()) - margin, 2));

                if (margin == 0)
                {
                    tlsMarginLevelValue.Text = "";
                }
                else
                {
                    tlsMarginLevelValue.Text = Convert.ToString(Math.Round(equity / margin * 100, 2));
                }
                timer1.Enabled = true;
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

        private void DisableAll()
        {
            ui_nmnuBar.Enabled = false;
            timer1.Enabled = false;
            ui_ncmdFileLogin.Enabled = true;
            ui_ncmdFileLogOff.Enabled = true;
            ui_ncmdFileExit.Enabled = true;
        }

        private void EnableAll()
        {
            ui_nmnuBar.Enabled = true;

            //ui_ncmdFileLogin.Enabled = true;
            //ui_ncmdFileLogOff.Enabled = true;
            //ui_ncmdFileExit.Enabled = true;

        }

        public void TimeSpanHandler()
        {

        }

        private void INSTANCE_OnNews(List<News> obj)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into INSTANCE_OnNews Method");

            if (Properties.Settings.Default.MessageBarMessageType.Contains("News") &&
                clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
            {
                lblMessages.Text = "|";
                int count = 0;
                foreach (News news in obj)
                {
                    lblMessages.Text = count < 25
                                           ? "News : " + news._TimeStamp + " ->" + news._NewsTopic + " ->" +
                                             news._BodyText + " ->" + news._URL + Environment.NewLine + lblMessages.Text
                                           : lblMessages.Text.Remove(lblMessages.Text.LastIndexOf(Environment.NewLine),
                                                                     lblMessages.Text.LastIndexOf("|"));
                    count += 1;
                }
            }
            else if (Properties.Settings.Default.MessageBarMessageType.Contains("News") &&
                     !clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
            {
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from INSTANCE_OnNews Method");
        }

        private void SetTickerComponents()
        {
            _objTickerTape.OnPortFolioApplyClick += objTickerTape_OnPortFolioApplyClick;
            _objTickerTape.SetTickerSpeed(Properties.Settings.Default.TickerSpeed);
            _objTickerTape.PortfolioList = _portfolio;
            _objTickerTape.BackColor = Color.Transparent;
            NControlHostCommand positionTickerCommand = new NControlHostCommand();
            positionTickerCommand.SetControl(_objTickerTape);
            positionTickerCommand.PrefferedHeight = 30;
            positionTickerCommand.PrefferedWidth = ClientSize.Width - 15;
            ui_ndtTicker.Commands.Add(positionTickerCommand);

            ui_ndtTicker.CommandSize = new Size(ClientSize.Width, 30);
            ui_ndtTicker.MaximumSize = new Size(ClientSize.Width, 30);
            _objTickerTape.Dock = DockStyle.Fill;
            _objTickerTape.Height = ui_ndtTicker.Height;
            _objTickerTape.Width = ClientSize.Width;
            _objTickerTape.SetStartX(ClientSize.Width);


        }


        private void objTickerTape_OnPortFolioApplyClick(string portfolioName)
        {
            AddDataToTicker(portfolioName);
        }

        private void AddDataToTicker(string portFolioName)
        {
            try
            {
                _objTickerTape._currentTickerPortfolio = portFolioName;
                var lstSymbols = new List<Symbol>(); //new line of code
                                                     //ThreadPool.QueueUserWorkItem(delegate
                                                     //{
                var lstTickerInfo = new List<ClsTickerInfo>();

                if (_portfolio != null && portFolioName != null && ((Dictionary<string, ClsPortfolio>)_portfolio).ContainsKey(portFolioName))
                {
                    foreach (Symbol objSymbol in ((Dictionary<string, ClsPortfolio>)_portfolio)[portFolioName].Products.Select(item => Symbol.GetSymbol(item.Key)))
                    {
                        lstSymbols.Add(objSymbol);

                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(objSymbol.Contract))
                        {
                            InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[objSymbol.Contract];

                            var objclsTickerInfo = new ClsTickerInfo();
                            string tickerDisplayType = Properties.Settings.Default.TickerDisplay;
                            objclsTickerInfo.ID = objSymbol.KEY;
                            if (tickerDisplayType != null &&
                                tickerDisplayType == "Symbol")
                            {
                                objclsTickerInfo.Symbol =
                                    objInstrumentSpec.Contract;
                            }
                            else if (tickerDisplayType != null &&
                                     tickerDisplayType == "Description")
                            {
                                objclsTickerInfo.Symbol = objInstrumentSpec.Information;
                            }
                            else
                            {
                                objclsTickerInfo.Symbol = objInstrumentSpec.Contract;
                            }
                            DateTime exp = DateTime.Now;
                            DateTime.TryParse(objInstrumentSpec.ExpiryDate, out exp);
                            objclsTickerInfo.ExpiryDate = exp.ToString("dd/MM/yyyy");
                            //objclsTickerInfo.ExpiryDate = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(objInstrumentSpec.ExpiryDate);
                            objclsTickerInfo.LastTradedQuantity =
                                objInstrumentSpec.PriceQuantity.ToString("000000");
                            objclsTickerInfo.LastTradedPrice =
                                objInstrumentSpec.PriceTick;
                            lstTickerInfo.Add(objclsTickerInfo);

                        }
                    }

                    clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lstSymbols);
                }
                _objTickerTape.AddSensArticles(lstTickerInfo);
                _objTickerTape.Refresh();
                _objTickerTape.PortfolioList = _portfolio;
                //});
            }
            catch (Exception)
            {


            }

        }



        private void ui_nmnuWindows_Select(object sender, CommandEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ui_nmnuWindows_Select Method");

            switch (MdiChildren.Count())
            {
                case 0:
                    foreach (NCommand item in ui_nmnuWindows.Commands)
                    {
                        item.Enabled = false;
                    }
                    break;
                default:
                    foreach (NCommand item in ui_nmnuWindows.Commands)
                    {
                        item.Enabled = true;
                    }
                    break;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ui_nmnuWindows_Select Method");
        }

        private void SetFilterBarValues()
        {
            ui_ncmbInstrumentType.Items.Clear();
            ui_ncmbInstrumentType.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys.ToArray());
            ui_ncmbInstrumentType.Click += ui_ncmbInstrumentType_Click;
            ui_ncmbProduct.Click += ui_ncmbProduct_Click;
        }

        private void ui_ncmbProduct_Click(object sender, CommandEventArgs e)
        {
            try
            {

                Action A = () =>
                {
                    ui_ncmbContract.Items.Clear();
                    if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(ui_ncmbInstrumentType.ControlText)
                        && ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_ncmbInstrumentType.ControlText].ContainsKey(ui_ncmbProduct.ControlText))
                    {
                        ui_ncmbContract.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_ncmbInstrumentType.ControlText][ui_ncmbProduct.ControlText].ToArray());
                    }
                    ui_ncmbContract.ListProperties.Sorted = true;
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
            catch (Exception)
            {
            }


        }

        private void ui_ncmbInstrumentType_Click(object sender, CommandEventArgs e)
        {
            try
            {

                Action A = () =>
                {
                    if (!string.IsNullOrEmpty(ui_ncmbInstrumentType.ControlText) &&
                    ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(ui_ncmbInstrumentType.ControlText))
                    {
                        ui_ncmbProduct.Items.Clear();
                        ui_ncmbProduct.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_ncmbInstrumentType.ControlText].Keys.ToArray());
                    }
                    ui_ncmbProduct.ListProperties.Sorted = true;
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
            catch (Exception)
            {
            }
        }

        public void LoadDefaultWorkSpace()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadDefaultWorkSpace Method");

            if (Properties.Settings.Default.DefaultWorkSpace != "")
            {
                try
                {
                    LoadWorkSpace(Properties.Settings.Default.DefaultWorkSpace);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error at LoadDefaultWorkSpace >> " + ex.Message);
                }

            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadDefaultWorkSpace Method");
        }

        private void PopulateReverceHotKeySettingsHashTable()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into PopulateReverceHotKeySettingsHashTable Method");

            _revercedHotKeySettingsHashTable = new Hashtable();
            foreach (string s in _hotKeySettingsHashTable.Keys)
            {
                if (_hotKeySettingsHashTable[s].ToString() != "[NONE]" &&
                    !_hotKeySettingsHashTable[s].ToString().Contains("+"))
                    _revercedHotKeySettingsHashTable.Add((_hotKeySettingsHashTable[s]).ToString(), s);
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from PopulateReverceHotKeySettingsHashTable Method");
        }

        private void SetContextMenuItemHotKeys()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetContextMenuItemHotKeys Method");

            foreach (DictionaryEntry deEntry in _hotKeySettingsHashTable)
            {
                string Hotkey = deEntry.Key.ToString();
                var commandID =
                    (CommandIDS)Enum.Parse(typeof(CommandIDS), Hotkey);
                switch (commandID)
                {
                    case CommandIDS.CANCEL_ALL_ORDERS:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(),
                                      out _shortcutKeyCancelAllOrders);
                        break;
                    case CommandIDS.MODIFY_TRDES:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(), out _shortcutKeyModifyTrades);
                        break;
                    case CommandIDS.FILTER:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(), out _shortcutKeyFilter);
                        break;
                    case CommandIDS.PLACE_BUY_ORDER:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(),
                                      out _shortcutKeyBuyOrderEntry);
                        break;
                    case CommandIDS.PLACE_SELL_ORDER:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(),
                                      out _shortcutKeySellOrderEntry);
                        break;
                    case CommandIDS.MARKET_PICTURE:
                        Enum.TryParse(_hotKeySettingsHashTable[deEntry.Key].ToString(),
                                      out _shortcutKeyMarketPicture);
                        break;
                }
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetContextMenuItemHotKeys Method");
        }

        private void CallShortcut(CommandIDS ID)
        {
            switch (ID)
            {
                case CommandIDS.LOGIN:
                    LoginMenuHandler();
                    break;
                case CommandIDS.LOGOFF:
                    LogoffMenuHandler();
                    break;
                case CommandIDS.LOAD_WORKSPACE:
                    LoadWorkSpaceMenuHandler();
                    break;
                case CommandIDS.SAVE_WORKSPACE:
                    SaveWorkSpaceMenuHandler();
                    break;
                case CommandIDS.EXIT:
                    //this.Close();
                    break;
                case CommandIDS.LANGUAGES:
                    LanguagesMenuHandeler();
                    break;
                case CommandIDS.CHANGE_PASSWORD:
                    ChangePasswordMenuHandeler();
                    break;
                case CommandIDS.TICKER:
                    TickerMenuHandeler();
                    break;
                case CommandIDS.TRADE:
                    TradeMenuHandler();
                    break;
                case CommandIDS.NET_POSITION:
                    NetPositionMenuHandler();
                    break;
                case CommandIDS.MESSAGE_LOG:
                    MessageLogMenuHandler();
                    break;
                case CommandIDS.CONTRACT_INFORMATION:
                    ContractInformationMenuHandler();
                    break;
                case CommandIDS.TOOL_BAR:
                    ToolBarMenuHandler();
                    break;
                case CommandIDS.FILTER_BAR:
                    FilterBarMenuHandler();
                    break;
                case CommandIDS.MESSAGE_BAR:
                    MessageBarMenuHandler();
                    break;
                case CommandIDS.STATUS_BAR:
                    StatusBarMenuHandler();
                    break;
                case CommandIDS.TOP_STATUS_BAR:
                    TopStatusBarMenuHandler();
                    break;
                case CommandIDS.MIDDLE_STATUS_BAR:
                    MiddleStatusBarMenuHandler();
                    break;
                case CommandIDS.BOTTOM_STATUS_BAR:
                    BottomStatusBarMenuHandler();
                    break;
                case CommandIDS.ADMIN_MESSAGE_BAR:
                    AdminMessageBarMenuHandler();
                    break;
                case CommandIDS.INDICES_VIEW:
                    IndicesViewMenuHandler();
                    break;
                case CommandIDS.FULL_SCREEN:
                    FullScreenMenuHandler();
                    break;
                case CommandIDS.MARKET_WATCH:
                    MarketWatchMenuHandler();
                    break;
                case CommandIDS.RISK_MONITOR:
                    RiskMonitorMenuHandler();
                    break;
                case CommandIDS.MARKET_PICTURE:
                    MarketPictureMenuHandler();
                    break;
                case CommandIDS.SNAP_QUOTE:
                    QuoteSnapMenuHandler();
                    break;
                case CommandIDS.MARKET_STATUS:
                    MarketStatusMenuHandler();
                    break;
                case CommandIDS.TOP_GAINERS_LOSERS:
                    TopGainersLosersMenuHandler();
                    break;
                case CommandIDS.PLACE_BUY_ORDER:
                    PlaceBuyOrderMenuHandler();
                    break;
                case CommandIDS.PLACE_SELL_ORDER:
                    PlaceSellOrderMenuHandler();
                    break;
                case CommandIDS.ORDER_BOOK:
                    OrderBookMenuHandler();
                    break;
                case CommandIDS.TRADES:
                    TradesMenuHandler();
                    break;
                case CommandIDS.CUSTOMIZE:
                    CustomizeMenuHandler();
                    break;
                case CommandIDS.LOCK_WORKSTATION:
                    LockWorkStationMenuHandler();
                    break;
                case CommandIDS.PORTFOLIO:
                    PortfolioMenuHandler();
                    break;
                case CommandIDS.PREFERENCES:
                    PreferencesMenuHandler();
                    break;
                case CommandIDS.SIMULATOR:
                    SimulatorMenuHandler();
                    break;
                case CommandIDS.NEW_WINDOW:
                    NewWindowMenuHandler();
                    break;
                case CommandIDS.CLOSE:
                    CloseMenuHandler();
                    break;
                case CommandIDS.CLOSE_ALL:
                    CloseAllMenuHandler();
                    break;
                case CommandIDS.CASCADE:
                    CascadeMenuHandler();
                    break;
                case CommandIDS.TILE_HORIZONTALLY:
                    TileHorizontallyMenuHandler();
                    break;
                case CommandIDS.TILE_VERTICALLY:
                    TileVerticallyMenuHandler();
                    break;
                case CommandIDS.WINDOW:
                    WindowMenuHandler();
                    break;
                case CommandIDS.HELP:
                    HelpMenuHandler();
                    break;
                case CommandIDS.ONLINE_BACKUP:
                    OnlineBackToolBarHandler();
                    break;
                case CommandIDS.PRINT:
                    PrintToolBarHandler();
                    break;
                case CommandIDS.MODIFY_ORDER:
                    ModifyOrderToolBarHandler();
                    break;
                case CommandIDS.CANCEL_SELECTED_ORDER:
                    CancelOrderToolBarHandler();
                    break;
                case CommandIDS.CANCEL_ALL_ORDERS:
                    CancelAllOrdersToolBarHandler();
                    break;
                case CommandIDS.ENGLISH:
                    EnglishMenuHandler();
                    break;
                case CommandIDS.HINDI:
                    HindiMenuHandler();
                    break;
                case CommandIDS.MAC_OS:
                    MacOSMenuHandler(ui_ncmbThemeMacOS);
                    Properties.Settings.Default.Theme = (int)CommandIDS.MAC_OS;
                    break;
                case CommandIDS.OFFICE_2007_BLACk:
                    OfficeBlackMenuHandler(ui_ncmbThemeOffice2007Black);
                    Properties.Settings.Default.Theme = (int)CommandIDS.OFFICE_2007_BLACk;
                    break;
                case CommandIDS.OFFICE_2007_BLUE:
                    OfficeBlueMenuHandler(ui_ncmbThemeOffice2007Blue);
                    Properties.Settings.Default.Theme = (int)CommandIDS.OFFICE_2007_BLUE;
                    break;
                case CommandIDS.ORANGE:
                    OrangeMenuHandler(ui_ncmbThemeOrange);
                    Properties.Settings.Default.Theme = (int)CommandIDS.ORANGE;
                    break;
                case CommandIDS.VISTA:
                    VistaMenuHandler(ui_ncmbThemeVista);
                    Properties.Settings.Default.Theme = (int)CommandIDS.VISTA;
                    break;
                case CommandIDS.VISTA_ROYAL:
                    VistaRoyalMenuHandler(ui_ncmdThemeVistaRoyal);
                    Properties.Settings.Default.Theme = (int)CommandIDS.VISTA_ROYAL;
                    break;
                case CommandIDS.OFFICE_2007_AQUA:
                    Office2007AquaMenuHandler(ui_ncmdThemeOffice2007Aqua);
                    Properties.Settings.Default.Theme = (int)CommandIDS.OFFICE_2007_AQUA;
                    break;
                case CommandIDS.OPUS_ALPHA:
                    OpusAlphaMenuHandler(ui_ncmdThemeOpusAlpha);
                    Properties.Settings.Default.Theme = (int)CommandIDS.OPUS_ALPHA;
                    break;
                case CommandIDS.VISTA_PLUS:
                    VistaPlusMenuHandler(ui_ncmdThemeVistaPlus);
                    Properties.Settings.Default.Theme = (int)CommandIDS.VISTA_PLUS;
                    break;
                case CommandIDS.VISTA_SLATE:
                    VistaSlateMenuHandler(ui_ncmdThemeVistaSlate);
                    Properties.Settings.Default.Theme = (int)CommandIDS.VISTA_SLATE;
                    break;
                case CommandIDS.INSPIRANT:
                    InspirantMenuHandler(ui_ncmdThemeInspirant);
                    Properties.Settings.Default.Theme = (int)CommandIDS.INSPIRANT;
                    break;
                case CommandIDS.SIMPLE:
                    SimpleMenuHandler(ui_ncmdThemeSimple);
                    Properties.Settings.Default.Theme = (int)CommandIDS.SIMPLE;
                    break;
                case CommandIDS.PARTICIPANT_LIST:
                    ParticipaintListMenuHandler();
                    break;
                case CommandIDS.MAIL:
                    MailMenuHandler();
                    break;
                case CommandIDS.INDEX_BAR:
                    IndexBarToolBarHandler();
                    break;
                case CommandIDS.NEW_CHART:
                    NewChartMenuHandler();
                    break;
                case CommandIDS.MARKET_QUOTE:
                    MarketQuoteMenuHandler();
                    break;
                case CommandIDS.ACCOUNTS_TO_TRADE:
                    AccountsInfoMenuHandler();
                    break;
                case CommandIDS.ROYAL:
                    RoyalThemeMenuHandler(ui_ncmdThemeRoyal);
                    Properties.Settings.Default.Theme = (int)CommandIDS.ROYAL;
                    break;
                case CommandIDS.AQUA:
                    AquaThemeMenuHandler(ui_ncmdThemeAqua);
                    Properties.Settings.Default.Theme = (int)CommandIDS.AQUA;
                    break;
                case CommandIDS.MOONLIGHT:
                    MoonLightThemeMenuHandler(ui_ncmdThemeMoonlight);
                    Properties.Settings.Default.Theme = (int)CommandIDS.MOONLIGHT;
                    break;
                case CommandIDS.WOOD:
                    WoodThemeMenuHandler(ui_ncmdThemeWood);
                    Properties.Settings.Default.Theme = (int)CommandIDS.WOOD;
                    break;

                case CommandIDS.SURVEILLANCE:
                    //SurveillanceMenuHandler();
                    break;
                case CommandIDS.ABOUTUS:
                    AboutUsMenuHandler();
                    break;
                case CommandIDS.RELOAD_CONFIGURATION:
                    ReloadConfigurationMenuHandler();
                    break;

                    #region "    Technical Analysis Add Submenu Handlers    "
                    //Commented by Namo
                    //case CommandIDS.HORIZONTAL_LINE:
                    //    HorizontalMenuHandler();
                    //    break;
                    //case CommandIDS.VERTICAL_LINE:
                    //    VerticalMenuHandler();
                    //    break;
                    //case CommandIDS.TEXT:
                    //    TextMenuHandler();
                    //    break;
                    //case CommandIDS.TREND_LINE:
                    //    TrednLineMenuHandler();
                    //    break;
                    //case CommandIDS.ELLIPSE:
                    //    EllipseMenuHandler();
                    //    break;
                    //case CommandIDS.SPEED_LINES:
                    //    SpeedLineMenuHandler();
                    //    break;
                    //case CommandIDS.GANN_FAN:
                    //    GannFanMenuHandler();
                    //    break;
                    //case CommandIDS.FIBONACCI_ARC:
                    //    FibonacciArcMenuHandler();
                    //    break;
                    //case CommandIDS.FIBONACCI_RETRACEMENT:
                    //    FibonacciRetracementMenuHandler();
                    //    break;
                    //case CommandIDS.FIBONACCI_FAN:
                    //    FibonacciFanMenuHandler();
                    //    break;
                    //case CommandIDS.FIBONACCI_TIMEZONE:
                    //    FibonacciTimeZoneMenuHandler();
                    //    break;
                    //case CommandIDS.TIRONE_LEVEL:
                    //    TironeLevelMenuHandler();
                    //    break;
                    //case CommandIDS.QUADRENT_LINES:
                    //    QuadrentLinesMenuHandler();
                    //    break;
                    //case CommandIDS.RAFF_REGRESSION:
                    //    RaffRegressionMenuHandler();
                    //    break;
                    //case CommandIDS.ERROR_CHANNEL:
                    //    ErrorChannelMenuHandler();
                    //    break;
                    //case CommandIDS.RECTANGLE:
                    //    RectangleMenuHandler();
                    //    break;
                    //case CommandIDS.FREE_HAND_DRAWING:
                    //    FreeHandDrawingMenuHandler();
                    //    break;

                    #endregion "  Technical Analysis Add Submenu Handlers    "
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CallShortcut Method");
        }

        private void ReloadConfigurationMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ReloadConfigurationMenuHandler Method");

            var objfrmReloadConfig = new frmReloadConfig();
            //objfrmAboutUs.MdiParent = this;
            objfrmReloadConfig.StartPosition = FormStartPosition.CenterScreen;
            objfrmReloadConfig.ShowDialog();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ReloadConfigurationMenuHandler Method");
        }

        private void AboutUsMenuHandler()
        {

            var objfrmAboutUs = new FrmAboutUs();
            //objfrmAboutUs.MdiParent = this;
            objfrmAboutUs.StartPosition = FormStartPosition.CenterScreen;
            objfrmAboutUs.ShowDialog();
        }

        private void SurveillanceMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SurveillanceMenuHandler Method");
            if (frmSurveillance.Count < 1)
            {
                var objfrmSurveillance = new frmSurveillance();
                objfrmSurveillance.MdiParent = this;
                objfrmSurveillance.Show();
            }
            else
            {
                //this.MdiChildren.Contains(frmSurveillance)
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SurveillanceMenuHandler Method");
        }

        private void RoyalThemeMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into RoyalThemeMenuHandler Method");
            cmd.Checked = true;
            SetTheme("LtechRoyal", cmd);
            //ThreadPool.QueueUserWorkItem(() => SetTheme("LtechRoyal")); 


            //FileHandling.WriteDevelopmentLog("Main Form : Exit from RoyalThemeMenuHandler Method");
        }

        private void AquaThemeMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into AquaThemeMenuHandler Method");

            cmd.Checked = true;
            SetTheme("Aqua", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from AquaThemeMenuHandler Method");
        }

        private void MoonLightThemeMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MoonLightThemeMenuHandler Method");

            cmd.Checked = true;
            SetTheme("LtechMoonLight", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MoonLightThemeMenuHandler Method");
        }

        private void WoodThemeMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into WoodThemeMenuHandler Method");

            cmd.Checked = true;
            SetTheme("Wood", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from WoodThemeMenuHandler Method");
        }

        private void AccountsInfoMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into AccountsInfoMenuHandler Method");

            frmAccountsToTrade objfrmAccountsToTrade = new frmAccountsToTrade();
            objfrmAccountsToTrade.MdiParent = this;
            objfrmAccountsToTrade.Show();
            //objfrmAccountsToTrade.Show(this);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from AccountsInfoMenuHandler Method");
        }

        private void MarketQuoteMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MarketQuoteMenuHandler Method");

            if (frmMarketQuote.Count < 4)
            {
                var objfrmMarketQuote = new frmMarketQuote();
                objfrmMarketQuote.MdiParent = this;
                objfrmMarketQuote.PortFolios = _portfolio;
                objfrmMarketQuote.Show();
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MarketQuoteMenuHandler Method");
        }

        private void NewChartMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into NewChartMenuHandler Method");

            //var objfrmChart = new frmNewChart { MdiParent = this, Text = "New Chart" };
            //objfrmChart.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from NewChartMenuHandler Method");
        }

        public object GetPortfolios(string UserCode)
        {
            object objportfolio = null;
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into GetPortfolios Method");

            if (File.Exists(ClsTWSUtility.GetPortfolioFileName(UserCode)))
            {
                FileStream streamRead = File.OpenRead(ClsTWSUtility.GetPortfolioFileName(UserCode));

                var binaryRead = new BinaryFormatter();
                objportfolio = binaryRead.Deserialize(streamRead);
                streamRead.Close();
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from GetPortfolios Method");
            return objportfolio;
        }

        private void GetProfiles()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into GetProfiles Method");

            if (File.Exists(ClsTWSUtility.GetProfileFileName()))
            {
                FileStream streamRead = File.OpenRead(ClsTWSUtility.GetProfileFileName());

                var binaryRead = new BinaryFormatter();
                _profiles = binaryRead.Deserialize(streamRead);
                streamRead.Close();
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from GetProfiles Method");
        }

        private void LoadImages()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadImages Method");

            Image imgFile = new Bitmap(Resources.file_strip);
            Image imgView = new Bitmap(Resources.viewstrip_png);
            Image imgMarket = new Bitmap(Resources.marketstip);
            Image imgWindow = new Bitmap(Resources.windowstrip);
            Image imgOrder = new Bitmap(Resources.order_strip);
            Image imgTool = new Bitmap(Resources.tool_strip);

            Image imgToolbar = new Bitmap(Resources.toolbarstrip20);


            var imList = new ImageList();
            var toolImgList = new ImageList();

            toolImgList.ImageSize = new Size(20, 20);

            toolImgList.Images.AddStrip(imgToolbar);

            imList.Images.AddStrip(imgFile);
            imList.Images.AddStrip(imgView);
            imList.Images.AddStrip(imgMarket);
            imList.Images.AddStrip(imgWindow);
            imList.Images.AddStrip(imgOrder);
            imList.Images.AddStrip(imgTool);

            ui_nmnuBar.ImageList = imList;
            ui_ndtToolBar.ImageList = toolImgList;

            ui_ncmdFileLogin.Properties.ImageIndex = 0;
            ui_ncmdFileLogOff.Properties.ImageIndex = 1;
            ui_ncmdFileSaveWorkSpace.Properties.ImageIndex = 2;
            ui_ncmdFileLoadWorkSpace.Properties.ImageIndex = 3;
            ui_ncmdFileExit.Properties.ImageIndex = 4;

            ui_ncmdViewLanguages.Properties.ImageIndex = 5;
            ui_ncmdViewThemes.Properties.ImageIndex = 6;
            ui_ncmdViewTrade.Properties.ImageIndex = 7;
            ui_ncmdViewNetPosition.Properties.ImageIndex = 8;
            ui_ncmdViewMsgLog.Properties.ImageIndex = 9;
            ui_ncmdViewParticipantList.Properties.ImageIndex = 13;
            ui_ncmdViewAccountsInfo.Properties.ImageIndex = 12;
            ui_ncmdViewIndicesView.Properties.ImageIndex = 11;
            ui_ncmdViewContractInfo.Properties.ImageIndex = 10;


            ui_ncmdMarketMarketWatch.Properties.ImageIndex = 14;
            ui_ncmdMarketQuote.Properties.ImageIndex = 19;
            ui_ncmdMarketMarketPicture.Properties.ImageIndex = 15;
            ui_ncmdMarketSnapQuote.Properties.ImageIndex = 16;
            ui_ncmdMarketMarketStatus.Properties.ImageIndex = 17;
            ui_ncmdMarketTopGainerLosers.Properties.ImageIndex = 18;

            ui_ncmdWindowCascade.Properties.ImageIndex = 23;
            ui_ncmdWindowClose.Properties.ImageIndex = 21;
            ui_ncmdWindowCloseAll.Properties.ImageIndex = 22;
            ui_ncmdWindowNewWindow.Properties.ImageIndex = 20;
            ui_ncmdWindowTileHorizontally.Properties.ImageIndex = 25;
            ui_ncmdWindowTileVertically.Properties.ImageIndex = 24;

            ui_ncmdOrdersOrderBook.Properties.ImageIndex = 26;
            ui_ncmdOrdersPlaceBuyOrders.Properties.ImageIndex = 27;
            ui_ncmdOrdersPlaceSellOrders.Properties.ImageIndex = 28;

            ui_ncmdTradesTrades.Properties.ImageIndex = 7;

            ui_ncmdToolsCustomize.Properties.ImageIndex = 29;
            ui_ncmdToolsLockWorkStation.Properties.ImageIndex = 30;
            ui_ncmdToolsPortfolio.Properties.ImageIndex = 31;
            ui_ncmdToolsPreferences.Properties.ImageIndex = 32;

            ui_ntbLogin.Properties.ImageIndex = 0;
            ui_ntbLogoff.Properties.ImageIndex = 1;
            ui_ntbBackup.Properties.ImageIndex = 2;
            ui_ntbPrint.Properties.ImageIndex = 3;
            ui_ntbMessageLog.Properties.ImageIndex = 4;
            ui_ntbOrderEntry.Properties.ImageIndex = 5;
            ui_ntbOrderBook.Properties.ImageIndex = 6;
            ui_ntbTrades.Properties.ImageIndex = 7;
            ui_ntbNetPosition.Properties.ImageIndex = 8;
            ui_ntbMarketWatch.Properties.ImageIndex = 9;
            ui_ntbMarketPicture.Properties.ImageIndex = 10;
            ui_ntbContractInfo.Properties.ImageIndex = 11;
            ui_ntbModifyOrder.Properties.ImageIndex = 12;
            ui_ntbCancelOrder.Properties.ImageIndex = 13;
            ui_ntbCancelAllOrders.Properties.ImageIndex = 14;

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadImages Method");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="str"></param>
        /// <param name="ncmd"></param>
        public void SetHotKey(string name, string str, NCommand ncmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetHotKey Method");

            if (ncmd != null)
            {
                ncmd.Properties.Shortcut.Modifiers = Keys.None;


                if ((str.Equals("[NONE]", StringComparison.InvariantCultureIgnoreCase)) || (!str.Contains("+")))
                {
                    if (!str.Contains("[NONE]"))
                    {
                        var key = (Keys)Enum.Parse(typeof(Keys), str);
                        ncmd.Properties.Shortcut = new NShortcut(key, 0);
                    }
                    else
                        return;
                }
                string[] strArray = str.Split('+'); //strArray[1].Split('+');
                for (int strLoop = 0; strLoop < strArray.Length; strLoop++)
                {
                    string item = strArray[strLoop];
                    item = item.Trim();

                    if (item.Equals("Alt", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Alt;
                    }
                    else if (item.Equals("Shift", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Shift;
                    }
                    else if (item.Equals("Ctrl", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Control;
                    }
                    else
                    {
                        switch (item)
                        {
                            case "0":
                                item = "D0";
                                break;
                            case "1":
                                item = "D1";
                                break;
                            case "2":
                                item = "D2";
                                break;
                            case "3":
                                item = "D3";
                                break;
                            case "4":
                                item = "D4";
                                break;
                            case "5":
                                item = "D5";
                                break;
                            case "6":
                                item = "D6";
                                break;
                            case "7":
                                item = "D7";
                                break;
                            case "8":
                                item = "D8";
                                break;
                            case "9":
                                item = "D9";
                                break;
                            default:
                                break;
                        }
                        ncmd.Properties.Shortcut.Key = (Keys)Enum.Parse(typeof(Keys), item);
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetHotKey Method");
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nmnuCmdExit_Click(object sender, CommandEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into nmnuCmdExit_Click Method");

            Close();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from nmnuCmdExit_Click Method");
        }


        /// <summary>
        /// Close the form on Escape keyboad key 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FrmMain_KeyDown Method");
            if (e.KeyCode == Keys.Enter)
            {
                AddFilterDataToMarketWatch();
            }
            PopulateReverceHotKeySettingsHashTable();

            if (_revercedHotKeySettingsHashTable.ContainsKey(e.KeyCode.ToString()) && e.Modifiers == Keys.None)
            {
                var x = e.KeyCode + "";
                var commandID =
                    (CommandIDS)Enum.Parse(typeof(CommandIDS), _revercedHotKeySettingsHashTable[x].ToString());
                CallShortcut(commandID);
            }
            if (e.KeyCode == Keys.Add)
                CallShortcut((CommandIDS)Enum.Parse(typeof(CommandIDS), "PLACE_BUY_ORDER"));
            if (e.KeyCode == Keys.Subtract)
                CallShortcut((CommandIDS)Enum.Parse(typeof(CommandIDS), "PLACE_SELL_ORDER"));

            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.W)
            {
                ui_nmnuWindows_Select(null, null);
            }


            if (e.KeyCode == Keys.Escape)
            {
                if (ActiveMdiChild != null && ActiveMdiChild as frmMarketWatchNew == null)
                {
                    ActiveMdiChild.Close();
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FrmMain_KeyDown Method");
        }

        private void AddFilterDataToMarketWatch()
        {
            try
            {
                if (ActiveMdiChild != null)
                {
                    if (((frmBase)ActiveMdiChild).Formkey.Contains("MARKET_WATCH"))
                    {
                        var formKey =
                            (((frmMarketWatchNew)ActiveMdiChild).Formkey.Split(new[] { '/' },
                                                                             StringSplitOptions.RemoveEmptyEntries))[0];

                        //InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(ui_ncmbExpiryDate.ControlText, ui_ncmbInstrumentType.ControlText, ui_ncmbSymbol.ControlText);
                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(ui_ncmbContract.ControlText))
                        {
                            InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[ui_ncmbContract.ControlText];
                            string keyText = Symbol.getKey(objInstrumentSpec)[0];
                            ((frmMarketWatchNew)ActiveMdiChild).AddRowToMarketWatch(keyText, objInstrumentSpec);

                        }

                    }
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Opens login dialog
        /// </summary>
        public DialogResult LoginMenuHandler()
        {
            DialogResult objDialogResult = DialogResult.Cancel;

            if (MdiChildren.Count() == 0)
            {
                try
                {
                    _objuctlLogin.OnOkClick -= objuctlLogin_OnOkClick;
                    _objuctlLogin.OnCancelClick -= objuctlLogin_OnCancelClick;
                    _objuctlLogin.OnOkClick += objuctlLogin_OnOkClick;
                    _objuctlLogin.OnCancelClick += objuctlLogin_OnCancelClick;
                    objForm.KeyDown -= objForm_KeyDown;
                    objForm.KeyDown += objForm_KeyDown;
                    _loginData = null;
                    _loginData = clsCryptorEngine.getLoginData();
                    if (_loginData[0] == "1")
                    {
                        _objuctlLogin.nchkSavePassword.Checked = true;
                        _objuctlLogin.ui_ntxtUserCode.Text = _loginData[1];
                        _objuctlLogin.ui_ntxtPassword.Text = _loginData[2];
                    }
                    else
                    {
                        _objuctlLogin.nchkSavePassword.Checked = false;
                        _objuctlLogin.ui_ntxtUserCode.Text = "";
                        _objuctlLogin.ui_ntxtPassword.Text = "";
                    }
                    objForm.Controls.Clear();
                    objForm.Controls.Add(_objuctlLogin);
                    objForm.Size = _objuctlLogin.Size;
                    objForm.FormBorderStyle = FormBorderStyle.None;
                    objForm.StartPosition = FormStartPosition.CenterScreen;
                    objForm.ShowInTaskbar = false;
                    objForm.KeyPreview = true;
                    if (objForm.Visible)
                    {
                        objForm.Visible = false;
                        objDialogResult = objForm.ShowDialog();

                    }
                    else
                    {
                        objDialogResult = objForm.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                if (ClsCommonMethods.ShowMessageBox("All opened windows will be closed are you sure to relogin.") == DialogResult.Yes)
                {
                    foreach (frmBase frm in MdiChildren)
                    {
                        frm.Close();
                    }
                    clsTWSOrderManagerJSON.INSTANCE.Refresh();
                    clsTWSDataManagerJSON.INSTANCE.Refresh();
                    LoginMenuHandler();
                }
            }


            if (objDialogResult == DialogResult.Cancel)
            {
                ui_ncmdFileLogin.Enabled = true;
            }
            return objDialogResult;
        }

        public void LogoffMenuHandler()
        {


            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure want to Logoff?");
            if (result == DialogResult.Yes)
            {
                foreach (frmBase frm in MdiChildren)
                {
                    frm.Close();
                }
                logoutSettings();
                tlstrplblStatusMsg.Text = "Successfully logged out.";
                LoggedInSuccess = false;
            }

        }

        private void logoutSettings()
        {

            tlsMarginLevelValue.Text = "";
            tlsBalanceValue.Text = "";
            tlsFreeMarginValue.Text = "";
            tlsEquityValue.Text = "";
            tlsMarginValue.Text = "";

            tableLayoutPanel2.Visible = false;
            if (LoggedInSuccess)
            {
                ui_ncmbInstrumentType.Items.Clear();
                ui_ncmbProduct.Items.Clear();
                ui_ncmbContract.Items.Clear();

            }

            ui_ncmbInstrumentType.ControlText = "";
            ui_ncmbProduct.ControlText = "";
            ui_ncmbContract.ControlText = "";
            DisableCommandIDs();

        }

        private void objForm_KeyDown(object sender, KeyEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objForm_KeyDown Method");

            if (e.KeyCode == Keys.Enter)
            {
                objuctlLogin_OnOkClick(null, null);
            }
            if (e.KeyData == Keys.Escape)
            {
                objuctlLogin_OnCancelClick(null, null);
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objForm_KeyDown Method");
        }

        /// <summary>
        /// Closes login form
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void objuctlLogin_OnCancelClick(object arg1, EventArgs arg2)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objuctlLogin_OnCancelClick Method");

            objForm.Close();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objuctlLogin_OnCancelClick Method");
        }

        string getOSInfo()
        {
            //Get Operating system information.    
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.    
            Version vs = os.Version;
            //Variable to hold our return value    
            string operatingSystem = "";
            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows        
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check    
            //We don't want to just return " Service Pack 2" or " 32-bit"    
            //That information is useless without the OS version.    
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.        
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.       
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"            
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"        
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";    
            }
            //Return the information we've gathered.    
            return operatingSystem;
        }
        /// <summary>
        /// Perform authentication of user 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void objuctlLogin_OnOkClick(object arg1, EventArgs arg2)
        {
            if (!Cls.ClsGlobal.CheckNetConnectivity())
            {
                ClsCommonMethods.ShowErrorBox("No Internet Connection, Please check your Internet connection.");
            }
            else
            {
                if (_objuctlLogin.ui_ntxtUserCode.Text == string.Empty)
                {
                    ClsCommonMethods.ShowErrorBox("Please enter user code");
                    _objuctlLogin.ui_ntxtUserCode.Focus();
                    return;
                }
                if (_objuctlLogin.ui_ntxtPassword.Text == string.Empty)
                {
                    ClsCommonMethods.ShowErrorBox("Please enter user password");
                    _objuctlLogin.ui_ntxtPassword.Focus();
                    return;
                }
                ui_lblTopStatus1.Text = _objuctlLogin.UserCode;
                username = _objuctlLogin.UserCode; //string.Empty; 
                string pwd = _objuctlLogin.Password; // string.Empty;

                LoadServerIps();

                clsTWSOrderManagerJSON.INSTANCE.OnOrderServerConnectionEvnt -= INSTANCE_OnOrderServerConnectionEvnt;
                clsTWSOrderManagerJSON.INSTANCE.OnOrderServerConnectionEvnt += INSTANCE_OnOrderServerConnectionEvnt;
                clsTWSOrderManagerJSON.INSTANCE.OnBothServerConnectionEvnt += new Action<string>(INSTANCE_OnBothServerConnectionEvnt);
                clsTWSDataManagerJSON.INSTANCE.OnDataServerConnectionEvnt -= INSTANCE_OnDataServerConnectionEvnt;
                clsTWSDataManagerJSON.INSTANCE.OnDataServerConnectionEvnt += INSTANCE_OnDataServerConnectionEvnt;
                clsTWSDataManagerJSON.INSTANCE.Init(username, pwd, _objConnectionIPs.QuotesIP.WebSocketHostUrl);
                clsTWSOrderManagerJSON.INSTANCE.Init(username, pwd, _objConnectionIPs.OrderIP.WebSocketHostUrl);

                Action A = () =>
                {
                    SetTickerComponents();
                    logoutSettings();
                    Properties.Settings.Default.LoginPassword = _objuctlLogin.Password;
                    Properties.Settings.Default.Save();
                    bool ch = _objuctlLogin.nchkSavePassword.Checked;
                    objForm.Close();
                    if (ch)
                    {
                        clsCryptorEngine.SaveLoginData("1~" + username + "~" + pwd);
                    }
                    else
                        clsCryptorEngine.SaveLoginData("0~ ~ ");

                    this.Refresh();
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
                //ShowCurrentServerStatus();
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objuctlLogin_OnOkClick Method");
        }

        void INSTANCE_OnBothServerConnectionEvnt(string str)
        {
            if (str.ToUpper() == "DISCONNECTED")
            {
                ui_ncmdDataServerStatus.Properties.ImageInfo.Image = Resources.Circle_Red;
                ui_ncmdOrderServerStatus.Properties.ImageInfo.Image = Resources.Circle_Red;
            }
            ui_nServerStatus.Refresh();
        }
        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            ////ClsTWSContractManager.INSTANCE.GetSymbolsFromWebService(ClsTWSUtility.GetSymbolsFilePath(), Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo.Rows[0]["Group"].ToString()));
            ////ui_ncmbInstrumentType.Items.Clear();
            ////ui_ncmbInstrumentType.Items.AddRange(ClsTWSContractManager.INSTANCE.GetAllProductTypes().ToArray());
            ////foreach (string PrdctType in ClsTWSContractManager.INSTANCE.GetAllProductTypes().ToArray())
            ////{
            ////    foreach (string prdct in ClsTWSContractManager.INSTANCE.GetAllProducts(PrdctType).ToArray())
            ////    {
            ////        foreach (string symbl in ClsTWSContractManager.INSTANCE.GetAllContracts(PrdctType, prdct))
            ////        {
            ////            if (!TWS.Cls.ClsGlobal.FutureSymbolList.Contains(symbl))
            ////                TWS.Cls.ClsGlobal.FutureSymbolList.Add(symbl);
            ////            InstrumentSpec insSpec = ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(PrdctType, symbl, prdct);
            ////            if (!TWS.Cls.ClsGlobal.DDContractSize.ContainsKey(symbl))
            ////            {
            ////                TWS.Cls.ClsGlobal.DDContractSize.Add(symbl, insSpec.ContractSize);
            ////            }
            ////            //TWS.Cls.ClsGlobal.FutureSymbolList.DDContractSize
            ////        }
            ////    }
            ////}
            //Action A = () => ClsTWSContractManager.INSTANCE.GetSymbolsFromWebService(ClsTWSUtility.GetSymbolsFilePath(), Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo.Rows[0]["Group"].ToString()));
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}

        }

        private void INSTANCE_OnOrderServerConnectionEvnt(string str)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into INSTANCE_OnOrderServerConnectionEvnt Method");

            //Action A = () =>
            //               {
            if (System.Threading.Monitor.TryEnter(ui_ncmdOrderServerStatus, 1000))
            {
                try
                {
                    if (str.ToUpper() == "CONNECTED")
                    {
                        //DisplayPopUp("Order Server", "OrderServer " + str, "green", str);
                        ui_ncmdOrderServerStatus.Properties.ImageInfo.Image = Resources.Circle_Green;
                        tlstrplblStatusMsg.Text = "Order server connected...";
                    }
                    else
                    {
                        //DisplayPopUp("Order Server", "OrderServer " + str, "Red", str);
                        ui_ncmdOrderServerStatus.Properties.ImageInfo.Image = Resources.Circle_Red;
                        if (tlstrplblStatusMsg.Text == "Data server disconnected...")
                        {
                            tlstrplblStatusMsg.Text = "Servers disconnected...";
                        }
                        else
                            tlstrplblStatusMsg.Text = "Order server disconnected...";
                        _isSplashClosed = false;
                    }
                    _flagFirstParticipantListResponce = false;
                    ui_nServerStatus.Refresh();
                }
                finally
                {
                    System.Threading.Monitor.Exit(ui_ncmdOrderServerStatus);
                }
            }

        }

        public void ShowCurrentServerStatus()
        {
            //Logging.FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Enter into AddDataToGrid Method");

            //Action A = () =>
            //               {
            if (System.Threading.Monitor.TryEnter(ui_ncmdDataServerStatus, 1000))
            {
                try
                {
                    if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected == true)
                        ui_ncmdDataServerStatus.Properties.ImageInfo.Image =
                            Resources.Circle_Green;
                    else
                        ui_ncmdDataServerStatus.Properties.ImageInfo.Image =
                            Resources.Circle_Red;
                    ui_nServerStatus.Refresh();
                }
                finally
                {
                    System.Threading.Monitor.Exit(ui_ncmdDataServerStatus);
                }
            }

            if (System.Threading.Monitor.TryEnter(ui_ncmdOrderServerStatus, 1000))
            {
                try
                {
                    if (clsTWSOrderManagerJSON.INSTANCE.IsOrderMgrLoaded == true)
                        ui_ncmdOrderServerStatus.Properties.ImageInfo.Image =
                            Resources.Circle_Green;
                    else
                        ui_ncmdOrderServerStatus.Properties.ImageInfo.Image =
                            Resources.Circle_Red;

                    ui_nServerStatus.Refresh();
                }
                finally
                {
                    System.Threading.Monitor.Exit(ui_ncmdOrderServerStatus);
                }
            }
            //               };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}

            //Logging.FileHandling.WriteDevelopmentLog("MarketStatus" + count + " : Exit from AddDataToGrid Method");
        }

        private void INSTANCE_OnDataServerConnectionEvnt(string str)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into INSTANCE_OnDataServerConnectionEvnt Method");

            //Action A = () =>
            //               {
            if (System.Threading.Monitor.TryEnter(ui_ncmdDataServerStatus, 1000))
            {
                try
                {
                    if (str.ToUpper() == "CONNECTED")
                    {
                        if (TWS.Cls.ClsGlobal.SubscibedSymbolList.Count > 0)
                        {
                            List<Symbol> sl = new List<Symbol>();
                            foreach (Symbol item in TWS.Cls.ClsGlobal.SubscibedSymbolList.Values)
                            {
                                sl.Add(item);
                            }

                            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, sl);
                        }
                        ui_ncmdDataServerStatus.Properties.ImageInfo.Image = Resources.Circle_Green;
                        tlstrplblStatusMsg.Text = "Data server connected...";
                    }
                    else
                    {
                        //DisplayPopUp("DataServer", "DataServer" + str, "Red", str);
                        //Cls.ClsGlobal.OrderEnable = false;
                        clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected = false;
                        ui_ncmdDataServerStatus.Properties.ImageInfo.Image = Resources.Circle_Red;
                        tlstrplblStatusMsg.Text = "Data server disconnected...";
                    }
                    ui_nServerStatus.Refresh();
                }
                finally
                {
                    System.Threading.Monitor.Exit(ui_ncmdDataServerStatus);
                }
            }
            //                   if (str.ToUpper() == "CONNECTED")
            //                   {
            //                       //DisplayPopUp("DataServer", "DataServer " + str, "green", str);
            //                       ui_ncmdDataServerStatus.Properties.ImageInfo.Image = Resources.Circle_Green;
            //                   }
            //                   else
            //                   {
            //                       //DisplayPopUp("DataServer", "DataServer" + str, "Red", str);
            //                       ui_ncmdDataServerStatus.Properties.ImageInfo.Image = Resources.Circle_Red;
            //                   }
            //                   //ui_nServerStatus.Refresh();
            //               };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from INSTANCE_OnDataServerConnectionEvnt Method");
        }

        /// <summary>
        /// Performs action on click of menus and commands of command bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncbmTWS_CommandClicked(object sender, CommandEventArgs e)
        {

            if (e.Command.ParentCommand == ui_ncmdWindowWindow)
            {
                windowCommandHandler(e.Command.Properties.Text);
                return;
            }
            int commandID = -1;
            if (e.Command.Properties.Text.ToUpper() == ui_ncmdViewTicker.Properties.Text.ToUpper())
            {
                commandID = ui_ncmdViewTicker.Properties.ID;
            }
            else
            {
                commandID = e.Command.Properties.ID;
            }
            CallShortcut((CommandIDS)commandID);
            Properties.Settings.Default.Save();
        }

        private void windowCommandHandler(string title)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into windowCommandHandler Method");

            foreach (Form item in _ChildFormList.Where(item => item.Text == title))
            {
                item.Activate();
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from windowCommandHandler Method");
        }

        /// <summary>
        /// Displays indexbar window
        /// </summary>
        private void IndexBarToolBarHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into IndexBarToolBarHandler Method");

            if (ui_ncmdViewIndexBar.Checked)
            {
                ui_ncmdViewIndexBar.Checked = false;
                //ui_ndtIndexBar.Visible = false;
            }
            else
            {
                ui_ncmdViewIndexBar.Checked = true;
                //ui_ndtIndexBar.Visible = true;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from IndexBarToolBarHandler Method");
        }

        /// <summary>
        /// Displays ParticipaintList window
        /// </summary>
        private void ParticipaintListMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ParticipaintListMenuHandler Method");

            var objfrmParticipaintList = new frmParticipaintList();
            objfrmParticipaintList.MdiParent = this;
            objfrmParticipaintList.StartPosition = FormStartPosition.CenterScreen;
            objfrmParticipaintList.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ParticipaintListMenuHandler Method");
        }
        /// <summary>
        /// Displays Mail window
        /// </summary>
        private void MailMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ParticipaintListMenuHandler Method");
            if (objMail.IsDisposed)
            {
                objMail = new frmMails();
            }
            //objMail.Parent = this;
            objMail.Text = "Mail History";
            objMail.MdiParent = this;
            objMail.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ParticipaintListMenuHandler Method");
        }
        /// <summary>
        /// Applys simple theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void SimpleMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SimpleMenuHandler Method");

            SetTheme(PredefinedFrame.Simple, ColorScheme.Longhorn, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SimpleMenuHandler Method");
        }

        /// <summary>
        /// Applys Inspirant theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void InspirantMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into InspirantMenuHandler Method");

            SetTheme(PredefinedFrame.Inspirat, ColorScheme.LunaBlue, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from InspirantMenuHandler Method");
        }

        /// <summary>
        /// Applys VistaSlate theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void VistaSlateMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into VistaSlateMenuHandler Method");

            SetTheme(PredefinedFrame.VistaSlate, ColorScheme.Gnome, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from VistaSlateMenuHandler Method");
        }

        /// <summary>
        /// Applys VistaPlus theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void VistaPlusMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into VistaPlusMenuHandler Method");

            SetTheme(PredefinedFrame.VistaPlus, ColorScheme.VistaPlus, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from VistaPlusMenuHandler Method");
        }

        /// <summary>
        /// Applys OpusAlpha theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void OpusAlphaMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into OpusAlphaMenuHandler Method");

            SetTheme(PredefinedFrame.OpusAlpha, ColorScheme.Arctic, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from OpusAlphaMenuHandler Method");
        }

        /// <summary>
        /// Applys Office2007Aqua theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void Office2007AquaMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into Office2007AquaMenuHandler Method");

            SetTheme(PredefinedFrame.Office2007Aqua, ColorScheme.Office2007Aqua, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from Office2007AquaMenuHandler Method");
        }

        /// <summary>
        /// Applys VistaRoyal theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void VistaRoyalMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into VistaRoyalMenuHandler Method");

            SetTheme(PredefinedFrame.VistaRoyal, ColorScheme.Longhorn, cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from VistaRoyalMenuHandler Method");
        }

        /// <summary>
        /// Applys the given theme to the form
        /// </summary>
        /// <param name="frameName">Name of Theme to be applied</param>
        /// <param name="scheme">Name of colorscheme to be applied</param>
        /// <param name="cmd">command information</param>
        private void SetTheme(PredefinedFrame frameName, ColorScheme scheme, NCommand cmd)
        {
            Action A = () =>
                          {
                              //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetTheme Method");

                              foreach (NCommand item in ui_ncmdViewThemes.Commands)
                              {
                                  item.Checked = false;
                              }
                              cmd.Checked = true;
                              NSkinManager.Instance.Enabled = false;
                              NUIManager.SetPredefinedFrame(frameName);
                              ClsTWSUtility.SetFormProperties(this, scheme);
                              UpdateFrame();

                              //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetTheme Method");
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
        /// Applys Vista theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void VistaMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into VistaMenuHandler Method");

            SetTheme("Vista", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from VistaMenuHandler Method");
        }

        /// <summary>
        /// Applys Orange theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void OrangeMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into OrangeMenuHandler Method");

            SetTheme("Orange", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from OrangeMenuHandler Method");
        }

        /// <summary>
        /// Applys OfficeBlue theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void OfficeBlueMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into OfficeBlueMenuHandler Method");

            SetTheme("Office 2007 Blue", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from OfficeBlueMenuHandler Method");
        }

        /// <summary>
        /// Applys OfficeBalck theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void OfficeBlackMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into OfficeBlackMenuHandler Method");

            SetTheme("Office 2007 Black", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from OfficeBlackMenuHandler Method");
        }

        /// <summary>
        /// Applys MacOS theme to the form and its components
        /// </summary>
        /// <param name="cmd">command information</param>
        private void MacOSMenuHandler(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MacOSMenuHandler Method");

            SetTheme("MacOS", cmd);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MacOSMenuHandler Method");
        }


        /// <summary>
        /// Applys the given theme to the form from XML file
        /// </summary>
        /// <param name="themeName">Name of the theme</param>
        /// <param name="cmd">Command information</param>

        private void SetTheme(string themeName, NCommand cmd)
        {
            try
            {
                foreach (NCommand item in ui_ncmdViewThemes.Commands)
                {
                    item.Checked = false;
                }
                cmd.Checked = true;
                var objNSkin = new NSkin();

                objNSkin.Load(Application.StartupPath + "\\Skins\\" + themeName + ".xml");
                if (objNSkin != null)
                {
                    NSkinManager.Instance.Skin = objNSkin;
                    NSkinManager.Instance.Enabled = true;
                }

            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Manages the checking and unchecking of theme submenus
        /// </summary>
        /// <param name="cmd">Command information</param>
        public void UncheckAllThemeMenus()
        {
            foreach (NCommand item in ui_ncmdViewThemes.Commands)
            {
                //if (item != cmd)
                item.Checked = false;
            }
        }

        /// <summary>
        /// Sets the form language to hindi
        /// </summary>
        private void HindiMenuHandler()
        {
            ui_ncmdLanguagesHindi.Checked = true;
            ManageCheckingOfLanguages(ui_ncmdLanguagesHindi);
            SetLanguage("hi");
        }

        /// <summary>
        /// Sets the form language to English
        /// </summary>
        private void EnglishMenuHandler()
        {
            ui_ncmdLanguagesEnglish.Checked = true;
            ManageCheckingOfLanguages(ui_ncmdLanguagesEnglish);
            SetLanguage("en");
        }

        /// <summary>
        /// Manages the checking and unchecking of Languages submenus
        /// </summary>
        /// <param name="cmd"></param>
        public void ManageCheckingOfLanguages(NCommand cmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ManageCheckingOfLanguages Method");

            foreach (NCommand item in ui_ncmdViewLanguages.Commands)
            {
                if (item != cmd)
                    item.Checked = false;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ManageCheckingOfLanguages Method");
        }

        /// <summary>
        /// 
        /// </summary>
        private void CancelAllOrdersToolBarHandler()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private void CancelOrderToolBarHandler()
        {
            var objfrmOrderBook = ActiveMdiChild as frmOrderBook;
            if (objfrmOrderBook != null)
            {
                if (MessageBox.Show("Are you sure to cancel the selected order?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    objfrmOrderBook.uctlOrderBookNew1_HandleCancelOrder(null, null);
            }
            else
            {
                ClsCommonMethods.ShowInformation("Please Open OrderBook and select the Order which you want to cancel.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ModifyOrderToolBarHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ModifyOrderToolBarHandler Method");
            var objfrmOrderBook = ActiveMdiChild as frmOrderBook;
            if (objfrmOrderBook != null)
            {
                objfrmOrderBook.uctlOrderBookNew1_HandleModifyOrderClick(null, null);
            }
            else
            {
                MessageBox.Show("Please Open OrderBook and select the Order which you want to modify.");
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ModifyOrderToolBarHandler Method");
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrintToolBarHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into PrintToolBarHandler Method");
            //Market Watch, Order Book, Net Position, TradeWindow, Logs
            var objfrmMarketWatch = ActiveMdiChild as frmMarketWatchNew;
            var objfrmOrderBook = ActiveMdiChild as frmOrderBook;
            var objfrmNetPosition = ActiveMdiChild as frmNetPosition;
            var objfrmTradeWindow = ActiveMdiChild as frmTradeWindow;
            var objfrmMessageLog = ActiveMdiChild as frmMessageLog;
            if (objfrmMarketWatch != null)
            {
                var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
                DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
                if (objDialogResult == DialogResult.OK)
                {
                    string filePath = objSaveFileDialog.FileName;
                    // ClsCommonMethods.SaveGridDataInExcel(filePath, ((frmMarketWatchNew)objfrmMarketWatch).uctlMarketWatch1.ui_ndgvMarketWatch); //Namo
                }
            }
            else if (objfrmOrderBook != null)
            {
                var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
                DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
                if (objDialogResult == DialogResult.OK)
                {
                    string filePath = objSaveFileDialog.FileName;
                    ClsCommonMethods.SaveGridDataInExcel(filePath, ((frmOrderBook)objfrmOrderBook).uctlOrderBookNew1.ui_uctlGridOrderBook);
                }
            }
            else if (objfrmNetPosition != null)
            {
                var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
                DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
                if (objDialogResult == DialogResult.OK)
                {
                    string filePath = objSaveFileDialog.FileName;
                    ClsCommonMethods.SaveGridDataInExcel(filePath, ((frmNetPosition)objfrmNetPosition).uctlNetPosition1.ui_uctlGridNetPosition);
                }
            }
            else if (objfrmTradeWindow != null)
            {
                var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
                DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
                if (objDialogResult == DialogResult.OK)
                {
                    string filePath = objSaveFileDialog.FileName;
                    ClsCommonMethods.SaveGridDataInExcel(filePath, ((frmTradeWindow)objfrmTradeWindow).uctlTradeWindow1.ui_uctlGridTradeWindow);
                }
            }
            else if (objfrmMessageLog != null)
            {
                var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
                DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
                if (objDialogResult == DialogResult.OK)
                {
                    string filePath = objSaveFileDialog.FileName;
                    ClsCommonMethods.SaveGridDataInExcel(filePath, ((frmMessageLog)objfrmMessageLog).uctlMessagLog1.ui_uctlGridMessageLog);
                }
            }
            else
            {
                ClsCommonMethods.ShowInformation("There is no printable windows open.");
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from PrintToolBarHandler Method");
        }

        /// <summary>
        /// Display dialog for taking online backup 
        /// </summary>
        private void OnlineBackToolBarHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into OnlineBackToolBarHandler Method");

            var objSaveFileDialog = new SaveFileDialog();

            objSaveFileDialog.DefaultExt = ".txt";
            objSaveFileDialog.Filter = "(*.txt)|*.txt";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                string filePath = objSaveFileDialog.FileName;
                var objFileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

                var objStreamWriter = new StreamWriter(objFileStream);
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from OnlineBackToolBarHandler Method");
        }

        /// <summary>
        /// 
        /// </summary>
        private void LanguagesMenuHandeler()
        {
        }

        private void ChangePasswordMenuHandeler()
        {
            frmChangePassword frmPassword = new frmChangePassword(username);
            frmPassword.Show();
        }
        /// <summary>
        /// Called when Ticker menu clicked
        /// </summary>
        private void TickerMenuHandeler()
        {
            if (ui_ncmdViewTicker.Checked == false)
            {
                ui_ndtTicker.Visible = true;
                ui_ncmdViewTicker.Checked = true;
                if (Properties.Settings.Default.TickerPortfolio == null ||
                    Properties.Settings.Default.TickerPortfolio == "---SELECT---")
                {
                    string str = Properties.Settings.Default.LastTickerPortfolio;
                    AddDataToTicker(Properties.Settings.Default.LastTickerPortfolio);
                }
                else
                {
                    string str = Properties.Settings.Default.LastTickerPortfolio;
                    string str1 = Properties.Settings.Default.TickerPortfolio;
                    if (Properties.Settings.Default.TickerPortfolio == "0" ||
                        Properties.Settings.Default.TickerPortfolio == null ||
                        Properties.Settings.Default.TickerPortfolio == "---SELECT---")
                    {
                        AddDataToTicker(Properties.Settings.Default.LastTickerPortfolio);
                    }
                    else
                    {
                        AddDataToTicker(Properties.Settings.Default.TickerPortfolio);
                    }
                    //AddDataToTicker(Properties.Settings.Default.TickerPortfolio);
                }
            }
            else
            {
                ui_ndtTicker.Visible = false;
                ui_ncmdViewTicker.Checked = false;
            }
        }

        /// <summary>
        /// Called when Help menu clicked
        /// </summary>
        private void HelpMenuHandler()
        {
        }

        /// <summary>
        /// Called when Window menu clicked
        /// </summary>
        private void WindowMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into WindowMenuHandler Method");

            if (MdiChildren.Count() == 0)
            {
                foreach (NCommand item in ui_nmnuWindows.Commands)
                {
                    item.Enabled = false;
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from WindowMenuHandler Method");
        }

        /// <summary>
        /// Called when TileVertically menu clicked
        /// </summary>
        private void TileVerticallyMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TileVerticallyMenuHandler Method");

            LayoutMdi(MdiLayout.TileVertical);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TileVerticallyMenuHandler Method");
        }

        /// <summary>
        /// Called when TileHorizontally menu clicked
        /// </summary>
        private void TileHorizontallyMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TileHorizontallyMenuHandler Method");

            LayoutMdi(MdiLayout.TileHorizontal);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TileHorizontallyMenuHandler Method");
        }

        /// <summary>
        /// Called when Cascade menu clicked
        /// </summary>
        private void CascadeMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CascadeMenuHandler Method");

            LayoutMdi(MdiLayout.Cascade);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CascadeMenuHandler Method");
        }

        /// <summary>
        /// Called when CloseAll menu clicked
        /// </summary>
        private void CloseAllMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CloseAllMenuHandler Method");

            foreach (frmBase frm in MdiChildren)
            {
                frm.Close();
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CloseAllMenuHandler Method");
        }

        /// <summary>
        /// Called when Close menu clicked
        /// </summary>
        private void CloseMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CloseMenuHandler Method");

            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CloseMenuHandler Method");
        }

        /// <summary>
        /// Called when NewWindow menu clicked
        /// </summary>
        private void NewWindowMenuHandler()
        {
            var objAlertTestForm = new AlertTestForm();
            objAlertTestForm.MdiParent = this;
            objAlertTestForm.Show();
        }

        /// <summary>
        /// Called when Preferences menu clicked
        /// </summary>
        private void PreferencesMenuHandler()
        {
            try
            {
                frmPreferences.GetInstance(_hotKeySettingsHashTable, _portfolio).OnHotKeyChanged += new Action<Hashtable>(FrmMain_OnHotKeyChanged);
                if (frmPreferences.GetInstance(_hotKeySettingsHashTable, _portfolio).ShowDialog() == DialogResult.Yes)
                {
                    _hotKeySettingsHashTable = frmPreferences._hotKeySettingsHashTable;
                    ApplyHotkeys();
                    SetContextMenuItemHotKeys();
                    SetTickerValues(Properties.Settings.Default.TickerSpeed);
                }
            }
            catch (Exception)
            {
            }

        }

        private void SimulatorMenuHandler()
        {
            try
            {
                frmOrderSimulator objSim = new frmOrderSimulator();
                objSim.MdiParent = this;
                objSim.Show();
            }
            catch (Exception)
            {


            }
        }

        void FrmMain_OnHotKeyChanged(Hashtable obj)
        {
            _hotKeySettingsHashTable = obj;
        }

        /// <summary>
        /// Called when PortFolio menu clicked
        /// </summary>
        private void PortfolioMenuHandler()
        {
            try
            {
                using (var objfrmPortfolio = new frmPortfolio(_portfolio, string.Empty, _objuctlLogin.UserCode))
                {
                    objfrmPortfolio.OnSavePortfolio -= objfrmPortfolio_OnSavePortfolio;
                    objfrmPortfolio.OnSavePortfolio += objfrmPortfolio_OnSavePortfolio;
                    DialogResult dgR = objfrmPortfolio.ShowDialog();
                }

            }
            catch (Exception)
            {

            }

        }

        private void objfrmPortfolio_OnSavePortfolio(string potfolioName)
        {
            _portfolio = GetPortfolios(_objuctlLogin.UserCode);
            _objTickerTape.PortfolioList = _portfolio;
            foreach (Form frm in MdiChildren)
            {
                if (frm is frmMarketWatchNew)
                {
                    ((frmMarketWatchNew)frm).ObjPortfolio = INSTANCE.GetPortfolios(_objuctlLogin.UserCode);
                    ((frmMarketWatchNew)frm).uctlMarketWatch1.Portfolios = ((frmMarketWatchNew)frm).ObjPortfolio;
                }
            }
            ClsCommonMethods.ShowInformation("Porfolio Saved successfully.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void objuctlPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            //ui_ndmTWS.DocumentManager.RemoveDocument(ui_ndmTWS.DocumentManager.ActiveDocument);
        }


        /// <summary>
        /// Called when LockWorkStation menu clicked
        /// </summary>
        private void LockWorkStationMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LockWorkStationMenuHandler Method");
            if (LoggedInSuccess)
            {
                int padding = 10;

                frmLockWorkStation.INSTANCE.StartPosition = FormStartPosition.Manual;
                int yLocation = Screen.PrimaryScreen.WorkingArea.Height -
                                frmLockWorkStation.INSTANCE.Size.Height;
                int xLocation = Screen.PrimaryScreen.WorkingArea.Width -
                                frmLockWorkStation.INSTANCE.Size.Width;
                frmLockWorkStation.INSTANCE.Location = new Point(Screen.PrimaryScreen.WorkingArea.X,
                                                                 yLocation +
                                                                 Screen.PrimaryScreen.WorkingArea.Y -
                                                                 padding);
                frmLockWorkStation.INSTANCE.Width = Screen.PrimaryScreen.WorkingArea.Width;
                frmLockWorkStation.INSTANCE.ui_ntxtPassword.Text = null;

                if (frmLockWorkStation.INSTANCE.Visible != true)
                {
                    frmLockWorkStation.INSTANCE.ShowDialog();
                }
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LockWorkStationMenuHandler Method");
        }

        /// <summary>
        /// Called when Trades menu clicked
        /// </summary>
        private void TradesMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TradesMenuHandler Method");

            //objfrmTradeWindow = new frmTradeWindow(_profiles, string.Empty, _shortcutKeyFilter);
            objfrmTradeWindow = new frmTradeWindowFilter(_profiles, string.Empty, _shortcutKeyFilter, this);
            objfrmTradeWindow.MdiParent = this;
            objfrmTradeWindow.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TradesMenuHandler Method");
        }

        /// <summary>
        /// Called when OrderBook menu clicked
        /// </summary>
        private void OrderBookMenuHandler()
        {
            var objfrmOrderBook = new frmOrderBook(_profiles, string.Empty, _shortcutKeyFilter);
            var orderStatus = new List<string>();
            orderStatus.Clear();
            orderStatus.Add("All");
            foreach (string x in TWS.Cls.ClsGlobal.DDOrderStatus.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                orderStatus.Add(c);
            }
            objfrmOrderBook.uctlOrderBookNew1.CreateContextMenu(orderStatus.ToArray());
            SetHotkeyHashTable(CommandIDS.CANCEL_SELECTED_ORDER, objfrmOrderBook.uctlOrderBookNew1.ContextMenuItems[3]);

            objfrmOrderBook.MdiParent = this;
            objfrmOrderBook.Show();

        }

        /// <summary>
        /// Called when PlaceSell menu clicked
        /// </summary>
        private void PlaceSellOrderMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into PlaceSellOrderMenuHandler Method");

            //DisplayOrderEntryDialog("SELL", Properties.Settings.Default.SellOrderColor, "Sell Order Entry");
            //frmOrderEntry.INSTANCE.Formkey = CommandIDS.PLACE_SELL_ORDER.ToString();
            var objfrmMarketWatch = ActiveMdiChild as frmMarketWatchNew;
            if (objfrmMarketWatch != null)
            {
                objfrmMarketWatch.OnSellOrderClick(null, null);
            }
            else
            {
                DisplayOrderEntryDialog("SELL", Properties.Settings.Default.SellOrderColor, "Sell Order Entry");
                frmOrderEntry.INSTANCE.Formkey = CommandIDS.PLACE_SELL_ORDER.ToString();
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from PlaceSellOrderMenuHandler Method");
        }

        /// <summary>
        /// Called when PlaceBuy menu clicked
        /// </summary>
        private void PlaceBuyOrderMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into PlaceBuyOrderMenuHandler Method");

            //DisplayOrderEntryDialog("BUY", Properties.Settings.Default.BuyOrderColor, "Buy Order Entry");
            //frmOrderEntry.INSTANCE.Formkey = CommandIDS.PLACE_BUY_ORDER.ToString();
            //frmOrderEntry.INSTANCE.ConfirmationMessage = "Submit Market Order?";
            var objfrmMarketWatch = ActiveMdiChild as frmMarketWatchNew;
            if (objfrmMarketWatch != null)
            {
                objfrmMarketWatch.OnBuyOrderClick(null, null);
            }
            else
            {
                DisplayOrderEntryDialog("BUY", Properties.Settings.Default.BuyOrderColor, "Buy Order Entry");
                frmOrderEntry.INSTANCE.Formkey = CommandIDS.PLACE_BUY_ORDER.ToString();
                frmOrderEntry.INSTANCE.ConfirmationMessage = "Submit Market Order?";
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from PlaceBuyOrderMenuHandler Method");
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into DisplayOrderEntryDialog Method");

            if (frmOrderEntry.INSTANCE.Visible)
            {
                frmOrderEntry.INSTANCE.Close();
            }
            frmOrderEntry.INSTANCE = new frmOrderEntry();
            frmOrderEntry.INSTANCE.FormText = formTitle;
            frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            frmOrderEntry.INSTANCE.MdiParent = this;
            frmOrderEntry.INSTANCE.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from DisplayOrderEntryDialog Method");
        }

        /// <summary>
        /// Called when TopGainersLosers menu clicked
        /// </summary>
        private void TopGainersLosersMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TopGainersLosersMenuHandler Method");

            var objfrmTopGainersLosers = new frmTopGainersLosers();
            objfrmTopGainersLosers.MdiParent = this;
            objfrmTopGainersLosers.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TopGainersLosersMenuHandler Method");
        }

        /// <summary>
        /// Called when MarketStatus menu clicked
        /// </summary>
        private void MarketStatusMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MarketStatusMenuHandler Method");

            var objfrmMarketStatus = new frmMarketStatus();
            objfrmMarketStatus.MdiParent = this;
            objfrmMarketStatus.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MarketStatusMenuHandler Method");
        }

        /// <summary>
        /// Called when QuoteSnap menu clicked
        /// </summary>
        private void QuoteSnapMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into QuoteSnapMenuHandler Method");

            if (frmSnapQuote.INSTANCE.IsDisposed)
            {
                frmSnapQuote.INSTANCE = new frmSnapQuote();
            }
            var objfrmBase = ((frmBase)ActiveMdiChild);

            frmSnapQuote.INSTANCE.ShowInTaskbar = false;
            frmSnapQuote.INSTANCE.MdiParent = this;
            frmSnapQuote.INSTANCE.Show();
            if (objfrmBase != null && objfrmBase.Formkey.Contains("MARKET_WATCH"))
            {
                if (((frmMarketWatchNew)objfrmBase).uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count != 0)
                {
                    DataGridViewRow row =
                        ((frmMarketWatchNew)objfrmBase).uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0];
                    frmSnapQuote.INSTANCE.SetMarketWatchValues(row);
                }
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from QuoteSnapMenuHandler Method");
        }

        /// <summary>
        /// Called when MarketPicture menu clicked
        /// </summary>
        private void MarketPictureMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MarketPictureMenuHandler Method");
            if (frmMarketWatchNew.Count < 4)
            {
                var objfrmMarketWatch = ActiveMdiChild as frmMarketWatchNew;
                if (objfrmMarketWatch != null)
                {
                    objfrmMarketWatch.OnMarketPictureClick(null, null);
                }
                else
                {
                    bool isMarketWatchFound = false;
                    foreach (Form x in MdiChildren)
                    {
                        if (x is frmMarketWatchNew)
                        {
                            ((frmMarketWatchNew)x).OnMarketPictureClick(null, null);
                            isMarketWatchFound = true;
                            break;
                        }
                    }
                    if (isMarketWatchFound == false)
                    {
                        ClsCommonMethods.ShowInformation("Please open the MarketWatch and select the symbol for which you want MarketPicture.");
                        //var objMarketPicture = new frmMarketPicture { MdiParent = this };
                        //objMarketPicture.Show();
                    }
                }
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MarketPictureMenuHandler Method");
        }

        /// <summary>
        /// Called when MarketWatch menu clicked
        /// </summary>
        //private void MarketWatchMenuHandler()
        //{
        //    //FileHandling.WriteDevelopmentLog("Main Form : Enter into MarketWatchMenuHandler Method");

        //    if (frmMarketWatch.Count<4)
        //    {
        //       
        //            var objMarketWatch = new frmMarketWatch(_portfolio, _profiles, string.Empty, string.Empty, _objuctlLogin.UserCode);
        //            objMarketWatch.ShortcutKeyBOE = _shortcutKeyBuyOrderEntry;
        //            objMarketWatch.ShortcutKeySOE = _shortcutKeySellOrderEntry;
        //            objMarketWatch.ShortcutKeyMarketPicture = _shortcutKeyMarketPicture;
        //            objMarketWatch.MdiParent = this;
        //            //objMarketWatch.OnNewChart += new Action(objMarketWatch_OnNewChart);
        //            objMarketWatch.Show();
        //        }
        //        
        //    }

        private void MarketWatchMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MarketWatchMenuHandler Method");

            if (frmMarketWatchNew.Count < 4)
            {


                //var objMarketWatch = new frmMarketWatch(_portfolio, _profiles, string.Empty, string.Empty, _objuctlLogin.UserCode);
                var objMarketWatch = new frmMarketWatchNew(_portfolio, _profiles, string.Empty, string.Empty, _objuctlLogin.UserCode);
                objMarketWatch.ShortcutKeyBOE = _shortcutKeyBuyOrderEntry;
                objMarketWatch.ShortcutKeySOE = _shortcutKeySellOrderEntry;
                objMarketWatch.ShortcutKeyMarketPicture = _shortcutKeyMarketPicture;
                objMarketWatch.MdiParent = this;
                //objMarketWatch.OnNewChart += new Action(objMarketWatch_OnNewChart);
                objMarketWatch.Show();
                _isMarketWatchOpen = true;

                //clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog.Clear();
                //}
                //if (frmMarketWatch.Count < 4 && clsTWSOrderManagerJSON.INSTANCE._isTradeHistoryLoade == null)
                //{
                //    var objMarketWatch = new frmMarketWatch(_portfolio, _profiles, string.Empty, string.Empty, _objuctlLogin.UserCode);
                //    objMarketWatch.ShortcutKeyBOE = _shortcutKeyBuyOrderEntry;
                //    objMarketWatch.ShortcutKeySOE = _shortcutKeySellOrderEntry;
                //    objMarketWatch.ShortcutKeyMarketPicture = _shortcutKeyMarketPicture;
                //    objMarketWatch.MdiParent = this;
                //    //objMarketWatch.OnNewChart += new Action(objMarketWatch_OnNewChart);
                //    objMarketWatch.Show();
                //}
                //FileHandling.WriteDevelopmentLog("Main Form : Exit from MarketWatchMenuHandler Method");
            }
        }

        private void RiskMonitorMenuHandler()
        {
            var objRiskMonitor = new frmRiskMonitor(_profiles);
            objRiskMonitor.MdiParent = this;
            objRiskMonitor.Show();


        }

        private void objMarketWatch_OnNewChart()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objMarketWatch_OnNewChart Method");

            ui_mnuChart3DStyle.Checked = false;
            ui_mnuChartsTrackCursor.Checked = false;
            ui_mnuChartsVolume.Checked = false;
            ui_mnuChartsGrid.Checked = true;

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objMarketWatch_OnNewChart Method");
        }

        /// <summary>
        /// Create new documents with specfied control and key name
        /// </summary>
        /// <param name="uctl">The client value of the document</param>
        /// <param name="keyValue">Key value of the document</param>
        private void CreateNuiDocument(UctlBase uctl, string keyValue)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CreateNuiDocument Method");

            uctl.Dock = DockStyle.Fill;
            var doc = new NUIDocument(uctl.Title); //, 0, objuctlMarketWatch);           
            doc.Key = keyValue;
            doc.PrefferedBounds = new Rectangle(uctl.Location.X, uctl.Location.Y, uctl.Width + 10, uctl.Height + 35);
            doc.Client = uctl;
            //ui_ndmTWS.DocumentManager.AddDocument(doc);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CreateNuiDocument Method");
        }

        /// <summary>
        /// Called when FullScreen menu clicked
        /// </summary>
        private void FullScreenMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FullScreenMenuHandler Method");

            if (ui_ncmdViewFullScreen.Checked == false)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                Bounds = Screen.PrimaryScreen.Bounds;
                Movable = false;
                Sizable = false;
                MaximizeBox = false;
                MinimizeBox = false;
                ui_ncmdViewFullScreen.Checked = true;
                BringToFront();
                TopMost = true;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.Sizable;
                Movable = true;
                Sizable = true;
                MaximizeBox = true;
                MinimizeBox = true;
                ui_ncmdViewFullScreen.Checked = false;
                TopMost = false;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FullScreenMenuHandler Method");
        }

        /// <summary>
        /// Called when IndicesView menu clicked
        /// </summary>
        private void IndicesViewMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into IndicesViewMenuHandler Method");

            if (frmIndexView.INSTANCE.IsDisposed)
            {
                frmIndexView.INSTANCE = new frmIndexView();
            }
            int xLocation = Screen.PrimaryScreen.WorkingArea.Width -
                            frmIndexView.INSTANCE.Width;
            frmIndexView.INSTANCE.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.X + xLocation, Screen.PrimaryScreen.WorkingArea.Y + 21);
            frmIndexView.INSTANCE.ShowInTaskbar = false;
            frmIndexView.INSTANCE.TopMost = true;
            frmIndexView.INSTANCE.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from IndicesViewMenuHandler Method");
        }


        /// <summary>
        /// Called when AdminMessage menu clicked
        /// </summary>
        private void AdminMessageBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into AdminMessageBarMenuHandler Method");

            if (frmAdminMessageLog.INSTANCE.IsDisposed)
            {
                frmAdminMessageLog.INSTANCE = new frmAdminMessageLog();
            }
            frmAdminMessageLog.INSTANCE.ShowInTaskbar = false;
            frmAdminMessageLog.INSTANCE.MdiParent = this;
            frmAdminMessageLog.INSTANCE.Show();
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from AdminMessageBarMenuHandler Method");
        }

        /// <summary>
        /// Called when BottomStatus menu clicked
        /// </summary>
        private void BottomStatusBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into BottomStatusBarMenuHandler Method");

            if (nmnuCmdViewBottomStatusBar.Checked)
            {
                nmnuCmdViewBottomStatusBar.Checked = false;
                nuiPanel4.Visible = false;
                nuiPnlStatusBars.Height -= nuiPanel4.Size.Height;
            }
            else
            {
                nmnuCmdViewBottomStatusBar.Checked = true;
                nuiPanel4.Visible = true;
                nuiPnlStatusBars.Height += nuiPanel4.Size.Height;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from BottomStatusBarMenuHandler Method");
        }

        /// <summary>
        /// Called when MiddleStatus menu clicked
        /// </summary>
        private void MiddleStatusBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MiddleStatusBarMenuHandler Method");

            if (nmnuCmdViewMiddleStatusBar.Checked)
            {
                nmnuCmdViewMiddleStatusBar.Checked = false;
                nuiPanel3.Visible = false;
                nuiPnlStatusBars.Height -= nuiPanel3.Size.Height;
            }
            else
            {
                nmnuCmdViewMiddleStatusBar.Checked = true;
                nuiPanel3.Visible = true;
                nuiPnlStatusBars.Height += nuiPanel3.Size.Height;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MiddleStatusBarMenuHandler Method");
        }

        /// <summary>
        /// Called when TopStatusBar menu clicked
        /// </summary>
        private void TopStatusBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TopStatusBarMenuHandler Method");

            if (nmnuCmdViewTopStatusBar.Checked)
            {
                nmnuCmdViewTopStatusBar.Checked = false;
                nuiPanel2.Visible = false;
                nuiPnlStatusBars.Height -= nuiPanel2.Size.Height;
            }
            else
            {
                nmnuCmdViewTopStatusBar.Checked = true;
                nuiPanel2.Visible = true;
                nuiPnlStatusBars.Height += nuiPanel2.Size.Height;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TopStatusBarMenuHandler Method");
        }

        /// <summary>
        /// Called when StatusBar menu clicked
        /// </summary>
        private void StatusBarMenuHandler()
        {
        }

        /// <summary>
        /// Called when MessageBar menu clicked
        /// </summary>
        private void MessageBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MessageBarMenuHandler Method");

            if (ui_ncmdViewMessageBar.Checked)
            {
                //nuiPanel5.Visible = false;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Height = tableLayoutPanel1.Height - 21;
                //nuiPnlMessageBar.Visible = false;
                ui_ncmdViewMessageBar.Checked = false;
            }
            else
            {
                tableLayoutPanel2.Visible = true;
                tableLayoutPanel1.Height = tableLayoutPanel1.Height + 21;
                //nuiPanel5.Visible = true;
                //nuiPnlMessageBar.Visible = true;
                ui_ncmdViewMessageBar.Checked = true;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MessageBarMenuHandler Method");
        }

        /// <summary>
        /// Called when FilterBar menu clicked
        /// </summary>
        private void FilterBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FilterBarMenuHandler Method");

            if (ui_ncmdViewFilterBar.Checked == false)
            {
                ui_ndtFilter.Visible = true;
                ui_ncmdViewFilterBar.Checked = true;
            }
            else
            {
                ui_ndtFilter.Visible = false;
                ui_ncmdViewFilterBar.Checked = false;
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FilterBarMenuHandler Method");
        }

        /// <summary>
        /// Called when ToolBar menu clicked
        /// </summary>
        private void ToolBarMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ToolBarMenuHandler Method");

            if (ui_ncmdViewToolBar.Checked == false)
            {
                ui_ndtToolBar.Visible = true;
                ui_ncmdViewToolBar.Checked = true;
            }
            else
            {
                ui_ndtToolBar.Visible = false;
                ui_ncmdViewToolBar.Checked = false;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ToolBarMenuHandler Method");
        }

        /// <summary>
        /// Called when ContractInformation menu clicked
        /// </summary>
        private void ContractInformationMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ContractInformationMenuHandler Method");

            var objfrm = ActiveMdiChild as frmMarketWatchNew;
            string selectedInstrument = string.Empty;
            if (objfrm != null &&
                (objfrm).uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count > 0)
            {
                selectedInstrument =
                    (objfrm).uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Cells[0].Value.
                        ToString();
            }

            //frmProductInfo.GetInstance(selectedInstrument).TopMost=true;
            productInfo = new frmProductInfo();
            productInfo.MdiParent = this;
            productInfo.SelectedInstrument = selectedInstrument;
            productInfo.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ContractInformationMenuHandler Method");
        }

        /// <summary>
        /// Called when MessageLog menu clicked
        /// </summary>
        private void MessageLogMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into MessageLogMenuHandler Method");
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from MessageLogMenuHandler Method");
        }

        /// <summary>
        /// Called when NetPosition menu clicked
        /// </summary>
        private void NetPositionMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into NetPositionMenuHandler Method");

            var objfrmNetPosition = new frmNetPosition(_profiles, string.Empty);
            objfrmNetPosition.MdiParent = this;
            objfrmNetPosition.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from NetPositionMenuHandler Method");
        }

        /// <summary>
        /// Called when Trade menu clicked
        /// </summary>
        private void TradeMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into TradeMenuHandler Method");

            objfrmTradeWindow = new frmTradeWindowFilter(_profiles, string.Empty, _shortcutKeyFilter, this);
            objfrmTradeWindow.MdiParent = this;
            objfrmTradeWindow.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from TradeMenuHandler Method");
        }

        /// <summary>
        /// Loads the workspace settings
        /// </summary>
        private void LoadWorkSpaceMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadWorkSpaceMenuHandler Method");

            string dir = Application.StartupPath;
            var objOpenFileDialog = new OpenFileDialog
            {
                InitialDirectory = ClsTWSUtility.DeafultWorkSpacePath(),
                DefaultExt = ".dat",
                Filter = "(*.dat)|*.dat"
            };
            DialogResult objDialogResult = objOpenFileDialog.ShowDialog();
            Environment.CurrentDirectory = dir;
            if (objDialogResult == DialogResult.OK)
            {
                CloseAllMenuHandler();
                LoadWorkSpace(objOpenFileDialog.FileName);
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadWorkSpaceMenuHandler Method");
        }

        private void CustomizeMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CustomizeMenuHandler Method");

            var objfrmcommoncustomizeWindow = new frmCommonCustomize();
            objfrmcommoncustomizeWindow.Sizable = false;
            objfrmcommoncustomizeWindow.StartPosition = FormStartPosition.CenterScreen;
            objfrmcommoncustomizeWindow.ShowDialog(this);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CustomizeMenuHandler Method");
        }

        private void LoadWorkSpace(string filepath)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadWorkSpace Method");

            try
            {
                if (File.Exists(filepath))
                {
                    using (Stream streamRead = File.OpenRead(filepath))
                    {
                        var sf = new BinaryFormatter();
                        objTWSSettings = (TWSSettings)sf.Deserialize(streamRead);
                    }
                }

                LoadFormsSettings();
                LoadMenuBarSettings();
                LoadCommandBarSettings();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at LoadWorkSpace >> " + ex.Message);
            }


            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadWorkSpace Method");
        }

        private void LoadCommandBarSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadCommandBarSettings Method");

            foreach (int s in objTWSSettings.DDCommandBarSetting.Keys)
            {
                CommandBarSetting cmdSetting = objTWSSettings.DDCommandBarSetting[s];
                ui_ncbmTWS.Toolbars[s].RowIndex = cmdSetting.RowIndex;
                ui_ncbmTWS.Toolbars[s].Visible = cmdSetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadCommandBarSettings Method");
        }

        private void LoadMenuBarSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadMenuBarSettings Method");

            foreach (int s in objTWSSettings.DDmenuItemsSetting.Keys)
            {
                NCommand nCommand = FindCommand(s);
                MenuSetting mnuSetting = objTWSSettings.DDmenuItemsSetting[s];
                nCommand.Checked = mnuSetting.Checked;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadMenuBarSettings Method");
        }

        public void LoadFormsSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into LoadFormsSettings Method");
            try
            {
                Action A = () =>
                {

                    foreach (string s in objTWSSettings.DDformSetting.Keys)
                    {
                        frmBase objfrmBase = null;
                        var commandID =
                            (CommandIDS)
                            Enum.Parse(typeof(CommandIDS), (s.Split('/')[0].ToUpper().Trim().Replace(" ", "_")));
                        switch (commandID)
                        {
                            case CommandIDS.TICKER:
                                break;
                            case CommandIDS.TRADE:
                                string TradeProfileName = s.Split('/')[2];
                                objfrmBase = new frmTradeWindowFilter(_profiles, TradeProfileName, _shortcutKeyFilter, this);
                                break;
                            case CommandIDS.NET_POSITION:
                                string NetProfileName = s.Split('/')[2];
                                objfrmBase = new frmNetPosition(_profiles, NetProfileName);
                                break;
                            case CommandIDS.MESSAGE_LOG:
                                objfrmBase = new frmMessageLog(_shortcutKeyFilter);
                                //((frmMessageLog)objfrmBase).MessageLogFilterKey = shortcutKeyFilter;
                                break;
                            case CommandIDS.CONTRACT_INFORMATION:
                                break;
                            case CommandIDS.INDICES_VIEW:
                                break;
                            case CommandIDS.MARKET_WATCH:
                                string portfolioName = s.Split('/')[2];
                                string profileName = s.Split('/')[3];
                                objfrmBase = new frmMarketWatchNew(_portfolio, _profiles, portfolioName, profileName, _objuctlLogin.UserCode);
                                break;
                            case CommandIDS.MARKET_PICTURE:
                                {
                                    objfrmBase = new frmMarketPictureNew();
                                }
                                break;
                            case CommandIDS.SNAP_QUOTE:
                                objfrmBase = new frmSnapQuote();
                                break;
                            case CommandIDS.MARKET_STATUS:
                                objfrmBase = new frmMarketStatus();
                                break;
                            case CommandIDS.TOP_GAINERS_LOSERS:
                                objfrmBase = new frmTopGainersLosers();
                                break;
                            case CommandIDS.PLACE_BUY_ORDER:
                                DisplayOrderEntryDialog("BUY", Color.Green, "Buy Order Entry");
                                objfrmBase = frmOrderEntry.INSTANCE;
                                break;
                            case CommandIDS.PLACE_SELL_ORDER:
                                DisplayOrderEntryDialog("SELL", Color.Blue, "Sell Order Entry");
                                objfrmBase = frmOrderEntry.INSTANCE;
                                break;
                            case CommandIDS.ORDER_BOOK:
                                string OrderProfileName = s.Split('/')[2];
                                objfrmBase = new frmOrderBook(_profiles, OrderProfileName, _shortcutKeyFilter);
                                break;
                            case CommandIDS.TRADES:
                                string TradesProfileName = s.Split('/')[2];
                                objfrmBase = new frmTradeWindowFilter(_profiles, TradesProfileName, _shortcutKeyFilter, this);
                                break;
                            case CommandIDS.MODIFY_ORDER:
                                break;
                            case CommandIDS.CANCEL_SELECTED_ORDER:
                                break;
                            case CommandIDS.CANCEL_ALL_ORDERS:
                                break;
                            case CommandIDS.PARTICIPANT_LIST:
                                objfrmBase = new frmParticipaintList();
                                break;
                            case CommandIDS.MAIL:
                                objfrmBase = new frmMails();
                                break;
                            case CommandIDS.INDEX_BAR:
                                break;
                            case CommandIDS.MOST_ACTIVE_PRODCUTS:
                                objfrmBase = new frmMostActiveProducts();
                                break;
                            case CommandIDS.MARKET_QUOTE:
                                try
                                {
                                    string portfolio = s.Split('/')[2];
                                    objfrmBase = new frmMarketQuote { _objPortfolio = _portfolio };
                                    ((frmMarketQuote)objfrmBase).SetValuesFromWorkSpace(portfolio);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error at LoadFormsSettings >> Check Point 1 >> " + ex.Message);
                                }
                                break;
                            case CommandIDS.NEW_CHART://Commented by Namo
                                //{
                                //    string[] charts = s.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                                //    objfrmBase = new frmNewChart();
                                //    ((frmNewChart)objfrmBase).ChartSymbol = charts[2];
                                //    (objfrmBase).Formkey = s;
                                //    if (File.Exists(ClsTWSUtility.GetChartsPath() + "\\" + charts[2] + "_" + charts[1]))
                                //    {
                                //        ((frmNewChart)objfrmBase).ui_ocxStockChart.LoadFile(ClsTWSUtility.GetChartsPath() +
                                //                                                             "\\" + charts[2] + "_" + charts[1]);
                                //    }
                                //    else
                                //    {
                                //        ((frmNewChart)objfrmBase).InitChartData(charts[2],
                                //                                                 (ePeriodicity)
                                //                                                 Enum.Parse(typeof(ePeriodicity), charts[1]));
                                //    }
                                //}
                                break;
                            case CommandIDS.SURVEILLANCE:
                                objfrmBase = new frmSurveillance();
                                break;
                            default:
                                break;
                        }
                        FormSettings frmSettings;
                        if (null != objfrmBase)
                        {
                            if (objTWSSettings.DDformSetting.TryGetValue(s, out frmSettings))
                            {
                                objfrmBase.Location = frmSettings.FormLocation;

                                if (frmSettings.WindowState == FormWindowState.Maximized)
                                {
                                    objfrmBase.WindowState = FormWindowState.Maximized;
                                }
                                else
                                {
                                    objfrmBase.Text = frmSettings.Title;
                                    objfrmBase.Width = frmSettings.Width;
                                    objfrmBase.Height = frmSettings.Height;
                                }
                            }
                            objfrmBase.MaximizeBox = false;
                            objfrmBase.MdiParent = this;
                            objfrmBase.Show();
                            string[] sArr = s.Split('/');
                            if (commandID == CommandIDS.MARKET_PICTURE)
                            {
                                //string marketWatchKey = string.Empty;
                                //string expiryDate = string.Empty;
                                //if (sArr.Length > 2)
                                //    marketWatchKey = sArr[2];
                                //if (sArr.Length > 3)
                                //    expiryDate = sArr[3] + "/" + sArr[4];
                                //((frmMarketPictureNew)objfrmBase).SetValuesFromWorkSpace(marketWatchKey, expiryDate);
                            }
                            else if (commandID == CommandIDS.SNAP_QUOTE)
                            {
                                string expiryDate = string.Empty;
                                string snapMarketKey = string.Empty;
                                if (sArr.Length > 1)
                                    snapMarketKey = sArr[1];
                                if (sArr.Length > 2)
                                    expiryDate = sArr[2] + "/" + sArr[3];

                                ((frmSnapQuote)objfrmBase).SetValuesFromWorkSpace(snapMarketKey, expiryDate);
                            }
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
            catch (Exception ex)
            {
                MessageBox.Show("Error at LoadFormsSettings >> " + ex.Message);
            }


            //FileHandling.WriteDevelopmentLog("Main Form : Exit from LoadFormsSettings Method");
        }

        /// <summary>
        /// Saves workspace settings
        /// </summary>
        private void SaveWorkSpaceMenuHandler()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SaveWorkSpaceMenuHandler Method");

            SaveWorkSpace();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SaveWorkSpaceMenuHandler Method");
        }

        private void SaveWorkSpace()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SaveWorkSpace Method");

            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.DefaultExt = ".dat";
            objSaveFileDialog.Filter = "(*.dat)|*.dat";
            objSaveFileDialog.InitialDirectory = ClsTWSUtility.DeafultWorkSpacePath();
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                SaveFormsSettings();
                SaveMenuBarSettings();
                SaveCommandBarSettings();
                using (
                    var stream = new FileStream(objSaveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite,
                                                FileShare.None))
                {
                    var sf = new BinaryFormatter();
                    sf.Serialize(stream, objTWSSettings);
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SaveWorkSpace Method");
        }

        private void SaveCommandBarSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SaveCommandBarSettings Method");

            foreach (NDockingToolbar ntoolBar in ui_ncbmTWS.Toolbars)
            {
                int floatingX = ntoolBar.FloatingLocation.X;
                int floatingY = ntoolBar.FloatingLocation.Y;
                int floatingWeight = ntoolBar.FloatingSize.Width;
                int floatingHeight = ntoolBar.FloatingSize.Height;
                int locationX = ntoolBar.Location.X;
                int locationY = ntoolBar.Location.Y;
                int Height = ntoolBar.Height;
                int Width = ntoolBar.Width;
                int rowIndex = ntoolBar.RowIndex;
                int index = ui_ncbmTWS.Toolbars.IndexOf(ntoolBar);
                bool visible = ntoolBar.Visible;
                string parent = ntoolBar.Parent.GetType().Name;
                bool canFloat = ntoolBar.CanFloat;
                var objCommandBarSetting = new CommandBarSetting(floatingX, floatingY, floatingWeight,
                                                                 floatingHeight, locationX, locationY,
                                                                 Height, Width, rowIndex, index, visible,
                                                                 parent, canFloat);
                //if (index!=0 && objTWSSettings.DDCommandBarSetting.Count != null)
                //    objTWSSettings.DDCommandBarSetting[index] = objCommandBarSetting;
                //else
                if (objTWSSettings.DDCommandBarSetting.ContainsKey(index))
                    objTWSSettings.DDCommandBarSetting[index] = objCommandBarSetting;
                else
                    objTWSSettings.DDCommandBarSetting.Add(index, objCommandBarSetting);
                //MessageBox.Show(ntoolBar.Parent.GetType().Name + ":" + ntoolBar.CanFloat.ToString() + ":" + Convert.ToString(ntoolBar.FloatingLocation.X) + "," + Convert.ToString(ntoolBar.FloatingLocation.Y) + ":" + Convert.ToString(ntoolBar.RowIndex));
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SaveCommandBarSettings Method");
        }

        /// <summary>
        /// Saves the settings of Forms
        /// </summary>
        /// <param name="filePath">Path with file name of the file</param>
        public void SaveFormsSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SaveFormsSettings Method");

            objTWSSettings.DDformSetting.Clear();
            foreach (frmBase frm in MdiChildren)
            {
                var settings = new FormSettings(frm.Location, frm.WindowState, frm.Height, frm.Width, frm.Title);
                objTWSSettings.DDformSetting.Add(frm.Formkey, settings);
                if (frm.Formkey != null)
                {
                    if (frm.Formkey.Contains("NEW_CHART"))
                    {
                        //Commented by Namo
                        //((frmNewChart)frm).ui_ocxStockChart.SaveFile(ClsTWSUtility.GetChartsPath() + "\\" + ((frmNewChart)frm).ChartSymbol +
                        //                                              "_" + frm.Formkey.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SaveFormsSettings Method");
        }

        /// <summary>
        /// Saves the settings of command bar
        /// </summary>
        /// <param name="filePath">Path with file name of the file</param>
        public void SaveMenuBarSettings()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SaveMenuBarSettings Method");

            objTWSSettings.DDmenuItemsSetting.Clear();
            MenuSetting menusetting = null;
            foreach (NCommand cmd in ui_nmnuBar.Commands)
            {
                menusetting = new MenuSetting(cmd.Properties.ID, cmd.Properties.Text, cmd.Checked);
                if (cmd.Properties.ID != -1)
                    objTWSSettings.DDmenuItemsSetting.Add(cmd.Properties.ID, menusetting);
                if (cmd.Commands.Count > 0)
                {
                    foreach (NCommand cmd1 in cmd.Commands)
                    {
                        menusetting = new MenuSetting(cmd1.Properties.ID, cmd1.Properties.Text, cmd1.Checked);
                        if (cmd1.Properties.ID != -1)
                        {
                            if (!objTWSSettings.DDmenuItemsSetting.Keys.Contains(cmd1.Properties.ID))
                                objTWSSettings.DDmenuItemsSetting.Add(cmd1.Properties.ID, menusetting);
                            else
                                objTWSSettings.DDmenuItemsSetting[cmd1.Properties.ID] = menusetting;
                        }
                        if (cmd1.Commands.Count > 0)
                        {
                            foreach (NCommand cmd2 in cmd1.Commands)
                            {
                                menusetting = new MenuSetting(cmd2.Properties.ID, cmd2.Properties.Text, cmd2.Checked);
                                if (cmd2.Properties.ID != -1)
                                    objTWSSettings.DDmenuItemsSetting.Add(cmd2.Properties.ID, menusetting);
                            }
                        }
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SaveMenuBarSettings Method");
        }

        //private void SaveCommonBarSettings(string filePath)
        //{  
        //    objNCommandBarsState.PersistencyFlags = NCommandBarsStateFlags.All;
        //    objNCommandBarsState.Save(filePath);
        //}

        /// <summary>
        /// Desiarilizes the documents and workspace settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objNDockingFrameworkState_ResolveDocumentClient(object sender, DocumentEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objNDockingFrameworkState_ResolveDocumentClient Method");

            string keyValue = e.Document.Key;
            switch ((CommandIDS)Enum.Parse(typeof(CommandIDS), keyValue))
            {
                case CommandIDS.LOGIN:
                    break;
                case CommandIDS.LOGOFF:
                    break;
                case CommandIDS.LOAD_WORKSPACE:
                    break;
                case CommandIDS.SAVE_WORKSPACE:
                    break;
                case CommandIDS.EXIT:
                    break;
                case CommandIDS.LANGUAGES:
                    break;
                case CommandIDS.TICKER:
                    break;
                case CommandIDS.TRADE:
                    var objuctlTrade = new uctlTradeWindow();
                    objuctlTrade.Dock = DockStyle.Fill;
                    e.Document.Client = objuctlTrade;
                    break;
                case CommandIDS.NET_POSITION:
                    var objnetPosition = new UctlNetPosition();
                    objnetPosition.Dock = DockStyle.Fill;
                    e.Document.Client = objnetPosition;
                    break;
                case CommandIDS.MESSAGE_LOG:
                    var objmessageLog = new UctlMessagLog();
                    objmessageLog.ShortcutKeyFilter = _shortcutKeyFilter;
                    objmessageLog.Dock = DockStyle.Fill;
                    e.Document.Client = objmessageLog;
                    break;
                case CommandIDS.CONTRACT_INFORMATION:
                    var objContractInfo = new UctlContractInformation();
                    objContractInfo.Dock = DockStyle.Fill;
                    e.Document.Client = objContractInfo;
                    break;
                case CommandIDS.TOOL_BAR:
                    break;
                case CommandIDS.FILTER_BAR:
                    break;
                case CommandIDS.MESSAGE_BAR:
                    break;
                case CommandIDS.STATUS_BAR:
                    break;
                case CommandIDS.TOP_STATUS_BAR:
                    break;
                case CommandIDS.MIDDLE_STATUS_BAR:
                    break;
                case CommandIDS.BOTTOM_STATUS_BAR:
                    break;
                case CommandIDS.ADMIN_MESSAGE_BAR:
                    break;
                case CommandIDS.INDICES_VIEW:
                    break;
                case CommandIDS.FULL_SCREEN:
                    break;
                case CommandIDS.MARKET_WATCH:
                    var objmarketWatch = new UctlMarketWatch();
                    objmarketWatch.Dock = DockStyle.Fill;
                    e.Document.Client = objmarketWatch;
                    break;
                case CommandIDS.MARKET_PICTURE:
                    var objmarketPicture = new UctlMarketPicture();
                    objmarketPicture.Dock = DockStyle.Fill;
                    e.Document.Client = objmarketPicture;
                    break;
                case CommandIDS.SNAP_QUOTE:
                    var objsnapQuote = new UctlSnapQuote();
                    objsnapQuote.Dock = DockStyle.Fill;
                    e.Document.Client = objsnapQuote;
                    break;
                case CommandIDS.MARKET_STATUS:
                    var objmarketStatus = new UctlMarketStatus();
                    objmarketStatus.Dock = DockStyle.Fill;
                    e.Document.Client = objmarketStatus;
                    break;
                case CommandIDS.TOP_GAINERS_LOSERS:
                    var objtopGainerLosers = new UctlTopGainerLoser { Dock = DockStyle.Fill };
                    e.Document.Client = objtopGainerLosers;
                    break;
                case CommandIDS.PLACE_BUY_ORDER:
                    var objorderEntry = new UctlOrderEntry
                    {
                        Dock = DockStyle.Fill,
                        ui_lblOrderEntryType = { Text = "BUY" },
                        ui_npnlOrderEntry = { BackColor = Color.Green }

                    };
                    e.Document.Client = objorderEntry;
                    break;
                case CommandIDS.PLACE_SELL_ORDER:
                    var objorderEntry1 = new UctlOrderEntry
                    {
                        Dock = DockStyle.Fill,
                        ui_lblOrderEntryType = { Text = "SELL" },
                        ui_npnlOrderEntry = { BackColor = Color.Blue }
                    };
                    e.Document.Client = objorderEntry1;
                    break;
                case CommandIDS.ORDER_BOOK:
                    var objorderBook = new UctlOrderBook { ShortcutKeyFilter = _shortcutKeyFilter, Dock = DockStyle.Fill };
                    e.Document.Client = objorderBook;
                    break;
                case CommandIDS.TRADES:
                    var objtradeWindow = new uctlTradeWindow { Dock = DockStyle.Fill };
                    e.Document.Client = objtradeWindow;
                    break;
                case CommandIDS.CUSTOMIZE:
                    break;
                case CommandIDS.LOCK_WORKSTATION:
                    break;
                case CommandIDS.PORTFOLIO:
                    var objportfolio = new UctlPortfolio { Dock = DockStyle.Fill };
                    e.Document.Client = objportfolio;
                    break;
                case CommandIDS.PREFERENCES:
                    break;
                case CommandIDS.NEW_WINDOW:
                    break;
                case CommandIDS.CLOSE:
                    break;
                case CommandIDS.CLOSE_ALL:
                    break;
                case CommandIDS.CASCADE:
                    break;
                case CommandIDS.TILE_HORIZONTALLY:
                    break;
                case CommandIDS.TILE_VERTICALLY:
                    break;
                case CommandIDS.WINDOW:
                    break;
                case CommandIDS.HELP:
                    break;
                case CommandIDS.ONLINE_BACKUP:
                    OnlineBackToolBarHandler();
                    break;
                case CommandIDS.PRINT:
                    break;
                case CommandIDS.MODIFY_ORDER:
                    break;

                case CommandIDS.CANCEL_SELECTED_ORDER:
                    break;
                case CommandIDS.CANCEL_ALL_ORDERS:
                    break;
                case CommandIDS.ENGLISH:
                    break;
                case CommandIDS.HINDI:
                    break;
                case CommandIDS.MAC_OS:
                    break;
                case CommandIDS.OFFICE_2007_BLACk:
                    break;
                case CommandIDS.OFFICE_2007_BLUE:
                    break;
                case CommandIDS.ORANGE:
                    break;
                case CommandIDS.VISTA:
                    break;
                case CommandIDS.VISTA_ROYAL:
                    break;
                case CommandIDS.OFFICE_2007_AQUA:
                    break;
                case CommandIDS.OPUS_ALPHA:
                    break;
                case CommandIDS.VISTA_PLUS:
                    break;
                case CommandIDS.VISTA_SLATE:
                    break;
                case CommandIDS.INSPIRANT:
                    break;
                case CommandIDS.SIMPLE:
                    break;
                case CommandIDS.FILTER:
                    break;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objNDockingFrameworkState_ResolveDocumentClient Method");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsTWSOrderManagerJSON.INSTANCE.OnLogonResponse -= new Action<string, string, bool>(INSTANCE_OnLogonResponce);
        }

        private void DisableCommandIDs()
        {
            ui_ncmdFileLogin.Properties.ID = (int)CommandIDS.LOGIN;
            SetHotkeyHashTable(CommandIDS.LOGIN, ui_ncmdFileLogin);

            //ui_ncmdFileExit.Properties.ID = (int)CommandIDS.EXIT;
            //SetHotkeyHashTable(CommandIDS.EXIT, ui_ncmdFileExit);
            //ui_ncmdFileLogin.Enabled = false;
            ui_ncmdFileLogOff.Enabled = false;
            ui_ncmdFileLoadWorkSpace.Enabled = false;
            ui_ncmdFileSaveWorkSpace.Enabled = false;
            ui_ncmdFileChangePassword.Enabled = false;
            ui_ncmdViewLanguages.Enabled = false;
            ui_ncmdViewTicker.Enabled = false;
            ui_ncmdViewTrade.Enabled = false;
            ui_ncmdViewNetPosition.Enabled = false;
            ui_ncmdViewMsgLog.Enabled = false;
            ui_ncmdViewContractInfo.Enabled = false;
            ui_ncmdViewToolBar.Enabled = false;
            ui_ncmdViewMail.Enabled = false;
            ui_ncmdViewFilterBar.Enabled = false;
            ui_ncmdViewMessageBar.Enabled = false;
            ui_ncmdViewStatusBar.Enabled = false;

            nmnuCmdViewTopStatusBar.Enabled = false;
            nmnuCmdViewMiddleStatusBar.Enabled = false;
            nmnuCmdViewBottomStatusBar.Enabled = false;
            ui_ncmdViewAdminMsgBar.Enabled = false;
            ui_ncmdViewIndicesView.Enabled = false;

            ui_ncmdViewFullScreen.Enabled = false;
            ui_ncmdMarketMarketWatch.Enabled = false;
            ui_ncmdMarketMarketPicture.Enabled = false;

            ui_ncmdMarketSnapQuote.Enabled = false;

            ui_ncmdMarketMarketStatus.Enabled = false;
            ui_ncmdMarketTopGainerLosers.Enabled = false;
            ui_ncmdOrdersPlaceBuyOrders.Enabled = false;
            ui_ncmdOrdersPlaceSellOrders.Enabled = false;
            ui_ncmdOrdersOrderBook.Enabled = false;
            ui_ncmdTradesTrades.Enabled = false;
            ui_ncmdReloadConfig.Enabled = false;
            ui_ncmdToolsCustomize.Enabled = false;
            ui_ncmdToolsLockWorkStation.Enabled = false;
            ui_ncmdToolsPortfolio.Enabled = false;
            ui_ncmdToolsPreferences.Enabled = false;
            ui_ncmdToolsSimulator.Enabled = false;
            ui_ncmdWindowNewWindow.Enabled = false;
            ui_ncmdWindowClose.Enabled = false;
            ui_ncmdWindowCloseAll.Enabled = false;
            ui_ncmdWindowCascade.Enabled = false;
            ui_ncmdWindowTileHorizontally.Enabled = false;
            ui_ncmdWindowTileVertically.Enabled = false;
            ui_ncmdWindowWindow.Enabled = false;
            ui_ncmdLanguagesEnglish.Enabled = false;
            ui_ncmdLanguagesHindi.Enabled = false;
            ui_ncmbThemeMacOS.Enabled = false;
            ui_ncmbThemeOffice2007Black.Enabled = false;
            ui_ncmbThemeOffice2007Blue.Enabled = false;
            ui_ncmbThemeOrange.Enabled = false;
            ui_ncmbThemeVista.Enabled = false;
            ui_ncmdThemeVistaRoyal.Enabled = false;
            ui_ncmdThemeInspirant.Enabled = false;
            ui_ncmdThemeVistaPlus.Enabled = false;
            ui_ncmdThemeVistaSlate.Enabled = false;
            ui_ncmdThemeOpusAlpha.Enabled = false;
            ui_ncmdThemeOffice2007Aqua.Enabled = false;
            ui_ncmdThemeSimple.Enabled = false;
            ui_ntbBackup.Enabled = false;
            ui_ntbPrint.Enabled = false;
            ui_ntbModifyOrder.Enabled = false;
            ui_ntbCancelOrder.Enabled = false;
            ui_ntbCancelAllOrders.Enabled = false;
            ui_ncmdViewParticipantList.Enabled = false;
            ui_ncmdViewIndexBar.Enabled = false;
            ui_ntbFilter.Enabled = false;
            ui_mnuChartsNewChart.Enabled = false;
            ui_ntbLogin.Properties.ID = (int)CommandIDS.LOGIN;
            ui_ntbLogoff.Enabled = false;
            ui_ntbChangePassword.Enabled = false;
            ui_ntbMessageLog.Enabled = false;
            ui_ntbOrderEntry.Enabled = false;
            ui_ntbOrderBook.Enabled = false;
            ui_ntbNetPosition.Enabled = false;
            ui_ntbTrades.Enabled = false;
            ui_ntbMarketWatch.Enabled = false;
            ui_ntbMarketPicture.Enabled = false;
            ui_ntbContractInfo.Enabled = false;
            ui_nmnuWindows.Properties.ID = (int)CommandIDS.WINDOW;
            ui_ncmdMarketQuote.Enabled = false;
            ui_ncmdViewAccountsInfo.Enabled = false;
            ui_ncmdThemeRoyal.Enabled = false;
            ui_ncmdThemeAqua.Enabled = false;
            ui_ncmdThemeMoonlight.Enabled = false;
            ui_ncmdThemeWood.Enabled = false;
            ui_ncmdFileChangePassword.Enabled = false;
            ui_mnuPeriodicity1Minute.Enabled = false;
            ui_mnuPeriodicity5Minute.Enabled = false;
            ui_mnuPeriodicity15Minute.Enabled = false;
            ui_mnuPeriodicity30Minute.Enabled = false;
            ui_mnuPeriodicity1Hour.Enabled = false;
            ui_mnuPeriodicity4Hour.Enabled = false;
            ui_mnuPeriodicityDaily.Enabled = false;
            ui_mnuPeriodicityWeekly.Enabled = false;
            ui_mnuPeriodicityMonthly.Enabled = false;
            ui_mnuChartTypeBarChart.Enabled = false;
            ui_mnuChartTypeCandleChart.Enabled = false;
            ui_mnuChartTypeLineChart.Enabled = false;
            ui_nmunPriceTypePointandFigure.Enabled = false;
            ui_nmunPriceTypeRenko.Enabled = false;
            ui_nmunPriceTypeKagi.Enabled = false;
            ui_nmunPriceTypeThreeLineBreak.Enabled = false;
            ui_nmunPriceTypeEquiVolume.Enabled = false;
            ui_nmunPriceTypeEquiVolumeShadow.Enabled = false;
            ui_nmunPriceTypeCandleVolume.Enabled = false;
            ui_nmunPriceTypeHeikinAshi.Enabled = false;
            ui_nmunPriceTypeStandardChart.Enabled = false;
            ui_mnuChartsZoomIn.Enabled = false;
            ui_mnuChartsZoomOut.Enabled = false;
            ui_mnuChartsTrackCursor.Enabled = false;
            ui_mnuChartsVolume.Enabled = false;
            ui_mnuChartsGrid.Enabled = false;
            ui_mnuChart3DStyle.Enabled = false;
            ui_mnuSnapshotPrint.Enabled = false;
            ui_mnuSnapshotSave.Enabled = false;
            ui_nmnuTechnicalAnalysisIndicatorList.Enabled = false;
            ui_mnuAddHorizontalLine.Enabled = false;
            ui_mnuAddVerticalLine.Enabled = false;
            ui_mnuAddText.Enabled = false;
            ui_mnuAddTrendLine.Enabled = false;
            ui_mnuAddEllipse.Enabled = false;
            ui_mnuAddSpeedLines.Enabled = false;
            ui_mnuAddGannFan.Enabled = false;
            ui_mnuAddFibonacciArcs.Enabled = false;
            ui_mnuAddFibonacciRetracement.Enabled = false;
            ui_mnuAddFibonacciFan.Enabled = false;
            ui_mnuAddFibonacciTimezone.Enabled = false;
            ui_mnuAddTironeLevel.Enabled = false;
            ui_mnuAddRafRegression.Enabled = false;
            ui_mnuAddErrorChannel.Enabled = false;
            ui_mnuAddRectangle.Enabled = false;
            ui_mnuAddFreeHandDrawing.Enabled = false;
            ui_nmnuSurveillanceSurveillance.Enabled = false;

            //ui_ncmdDataServerStatus.Properties.Visible = false;
            //ui_ncmdOrderServerStatus.Properties.Visible = false;
            ui_nServerStatus.Visible = false;

        }

        private void EnableCommandIDs()
        {
            ui_ncmdFileLogin.Properties.ID = (int)CommandIDS.LOGIN;
            SetHotkeyHashTable(CommandIDS.LOGIN, ui_ncmdFileLogin);

            ui_ncmdFileExit.Properties.ID = (int)CommandIDS.EXIT;
            SetHotkeyHashTable(CommandIDS.EXIT, ui_ncmdFileExit);
            ui_ntbLogin.Properties.ID = (int)CommandIDS.LOGIN;

            //ui_ncmdFileLogin.Enabled = true;
            ui_ncmdFileLogOff.Enabled = true;
            ui_ncmdFileLoadWorkSpace.Enabled = true;
            ui_ncmdFileSaveWorkSpace.Enabled = true;
            ui_ncmdFileChangePassword.Enabled = true;
            ui_ncmdViewLanguages.Enabled = true;
            ui_ncmdViewTicker.Enabled = true;
            ui_ncmdViewTrade.Enabled = true;
            ui_ncmdViewNetPosition.Enabled = true;
            ui_ncmdViewMsgLog.Enabled = true;
            ui_ncmdViewContractInfo.Enabled = true;
            ui_ncmdViewToolBar.Enabled = true;
            ui_ncmdViewMail.Enabled = true;
            ui_ncmdViewFilterBar.Enabled = true;
            ui_ncmdViewMessageBar.Enabled = true;
            ui_ncmdViewStatusBar.Enabled = true;

            nmnuCmdViewTopStatusBar.Enabled = true;
            nmnuCmdViewMiddleStatusBar.Enabled = true;
            nmnuCmdViewBottomStatusBar.Enabled = true;
            ui_ncmdViewAdminMsgBar.Enabled = true;
            ui_ncmdViewIndicesView.Enabled = true;

            ui_ncmdViewFullScreen.Enabled = true;
            ui_ncmdMarketMarketWatch.Enabled = true;
            ui_ncmdMarketMarketPicture.Enabled = true;

            ui_ncmdMarketSnapQuote.Enabled = true;

            ui_ncmdMarketMarketStatus.Enabled = true;
            ui_ncmdMarketTopGainerLosers.Enabled = true;
            ui_ncmdOrdersPlaceBuyOrders.Enabled = true;
            ui_ncmdOrdersPlaceSellOrders.Enabled = true;
            ui_ncmdOrdersOrderBook.Enabled = true;
            ui_ncmdTradesTrades.Enabled = true;
            ui_ncmdReloadConfig.Enabled = true;
            ui_ncmdToolsCustomize.Enabled = true;
            ui_ncmdToolsLockWorkStation.Enabled = true;
            ui_ncmdToolsPortfolio.Enabled = true;
            ui_ncmdToolsSimulator.Enabled = true;
            ui_ncmdToolsPreferences.Enabled = true;
            ui_ncmdWindowNewWindow.Enabled = true;
            ui_ncmdWindowClose.Enabled = true;
            ui_ncmdWindowCloseAll.Enabled = true;
            ui_ncmdWindowCascade.Enabled = true;
            ui_ncmdWindowTileHorizontally.Enabled = true;
            ui_ncmdWindowTileVertically.Enabled = true;
            ui_ncmdWindowWindow.Enabled = true;
            ui_ncmdLanguagesEnglish.Enabled = true;
            ui_ncmdLanguagesHindi.Enabled = true;
            ui_ncmbThemeMacOS.Enabled = true;
            ui_ncmbThemeOffice2007Black.Enabled = true;
            ui_ncmbThemeOffice2007Blue.Enabled = true;
            ui_ncmbThemeOrange.Enabled = true;
            ui_ncmbThemeVista.Enabled = true;
            ui_ncmdThemeVistaRoyal.Enabled = true;
            ui_ncmdThemeInspirant.Enabled = true;
            ui_ncmdThemeVistaPlus.Enabled = true;
            ui_ncmdThemeVistaSlate.Enabled = true;
            ui_ncmdThemeOpusAlpha.Enabled = true;
            ui_ncmdThemeOffice2007Aqua.Enabled = true;
            ui_ncmdThemeSimple.Enabled = true;
            ui_ntbBackup.Enabled = true;
            ui_ntbPrint.Enabled = true;
            ui_ntbModifyOrder.Enabled = true;
            ui_ntbCancelOrder.Enabled = true;
            ui_ntbCancelAllOrders.Enabled = true;
            ui_ncmdViewParticipantList.Enabled = true;
            ui_ncmdViewIndexBar.Enabled = true;
            ui_ntbFilter.Enabled = true;
            ui_mnuChartsNewChart.Enabled = true;

            ui_ntbLogoff.Enabled = true;
            ui_ntbChangePassword.Enabled = true;
            ui_ntbMessageLog.Enabled = true;
            ui_ntbOrderEntry.Enabled = true;
            ui_ntbOrderBook.Enabled = true;
            ui_ntbNetPosition.Enabled = true;
            ui_ntbTrades.Enabled = true;
            ui_ntbMarketWatch.Enabled = true;
            ui_ntbMarketPicture.Enabled = true;
            ui_ntbContractInfo.Enabled = true;
            ui_nmnuWindows.Enabled = true;
            ui_ncmdMarketQuote.Enabled = true;
            ui_ncmdViewAccountsInfo.Enabled = true;
            ui_ncmdThemeRoyal.Enabled = true;
            ui_ncmdThemeAqua.Enabled = true;
            ui_ncmdThemeMoonlight.Enabled = true;
            ui_ncmdThemeWood.Enabled = true;
            ui_ncmdFileChangePassword.Enabled = true;

            //ui_mnuPeriodicity1Minute.Enabled = true;
            //ui_mnuPeriodicity5Minute.Enabled = true;
            //ui_mnuPeriodicity15Minute.Enabled = true;
            //ui_mnuPeriodicity30Minute.Enabled = true;
            //ui_mnuPeriodicity1Hour.Enabled = true;
            //ui_mnuPeriodicity4Hour.Enabled = true;
            //ui_mnuPeriodicityDaily.Enabled = true;
            //ui_mnuPeriodicityWeekly.Enabled = true;
            //ui_mnuPeriodicityMonthly.Enabled = true;
            //ui_mnuChartTypeBarChart.Enabled = true;
            //ui_mnuChartTypeCandleChart.Enabled = true;
            //ui_mnuChartTypeLineChart.Enabled = true;
            //ui_nmunPriceTypePointandFigure.Enabled = true;
            //ui_nmunPriceTypeRenko.Enabled = true;
            //ui_nmunPriceTypeKagi.Enabled = true;
            //ui_nmunPriceTypeThreeLineBreak.Enabled = true;
            //ui_nmunPriceTypeEquiVolume.Enabled = true;
            //ui_nmunPriceTypeEquiVolumeShadow.Enabled = true;
            //ui_nmunPriceTypeCandleVolume.Enabled = true;
            //ui_nmunPriceTypeHeikinAshi.Enabled = true;
            //ui_nmunPriceTypeStandardChart.Enabled = true;
            //ui_mnuChartsZoomIn.Enabled = true;
            //ui_mnuChartsZoomOut.Enabled = true;
            //ui_mnuChartsTrackCursor.Enabled = true;
            //ui_mnuChartsVolume.Enabled = true;
            //ui_mnuChartsGrid.Enabled = true;
            //ui_mnuChart3DStyle.Enabled = true;

            ui_nmnuTechnicalAnalysisIndicatorList.Enabled = true;

            //ui_mnuSnapshotPrint.Enabled = true;
            //ui_mnuSnapshotSave.Enabled = true;

            //ui_mnuAddHorizontalLine.Enabled = true;
            //ui_mnuAddVerticalLine.Enabled = true;
            //ui_mnuAddText.Enabled = true;
            //ui_mnuAddTrendLine.Enabled = true;
            //ui_mnuAddEllipse.Enabled = true;
            //ui_mnuAddSpeedLines.Enabled = true;
            //ui_mnuAddGannFan.Enabled = true;
            //ui_mnuAddFibonacciArcs.Enabled = true;
            //ui_mnuAddFibonacciRetracement.Enabled = true;
            //ui_mnuAddFibonacciFan.Enabled = true;
            //ui_mnuAddFibonacciTimezone.Enabled = true;
            //ui_mnuAddTironeLevel.Enabled = true;
            //ui_mnuAddRafRegression.Enabled = true;
            //ui_mnuAddErrorChannel.Enabled = true;
            //ui_mnuAddRectangle.Enabled = true;
            //ui_mnuAddFreeHandDrawing.Enabled = true;

            ui_nmnuSurveillanceSurveillance.Enabled = true;

            //ui_ncmdDataServerStatus.Properties.Visible = true;
            //ui_ncmdOrderServerStatus.Properties.Visible = true;
            ui_nServerStatus.Visible = true;

        }
        /// <summary>
        /// Sets the ID value of the commands
        /// </summary>
        private void SetCommandsIDs()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetCommandsIDs Method");

            if (File.Exists(ClsTWSUtility.GetHotKeysFileName()))
            {
                try
                {
                    Stream streamRead = File.OpenRead(ClsTWSUtility.GetHotKeysFileName());
                    var binaryRead = new BinaryFormatter();
                    _hotKeySettingsHashTable = (Hashtable)binaryRead.Deserialize(streamRead);
                    streamRead.Close();
                }
                catch
                {
                    _hotKeySettingsHashTable = null;
                }
            }
            ui_ncmdFileLogin.Properties.ID = (int)CommandIDS.LOGIN;
            SetHotkeyHashTable(CommandIDS.LOGIN, ui_ncmdFileLogin);

            ui_ncmdFileLogOff.Properties.ID = (int)CommandIDS.LOGOFF;
            SetHotkeyHashTable(CommandIDS.LOGOFF, ui_ncmdFileLogOff);

            ui_ncmdFileLoadWorkSpace.Properties.ID = (int)CommandIDS.LOAD_WORKSPACE;
            SetHotkeyHashTable(CommandIDS.LOAD_WORKSPACE, ui_ncmdFileLoadWorkSpace);

            ui_ncmdFileSaveWorkSpace.Properties.ID = (int)CommandIDS.SAVE_WORKSPACE;
            SetHotkeyHashTable(CommandIDS.SAVE_WORKSPACE, ui_ncmdFileSaveWorkSpace);

            ui_ncmdFileChangePassword.Properties.ID = (int)CommandIDS.CHANGE_PASSWORD;
            SetHotkeyHashTable(CommandIDS.CHANGE_PASSWORD, ui_ncmdFileChangePassword);

            ui_ncmdFileExit.Properties.ID = (int)CommandIDS.EXIT;
            SetHotkeyHashTable(CommandIDS.EXIT, ui_ncmdFileExit);

            ui_ncmdViewLanguages.Properties.ID = (int)CommandIDS.LANGUAGES;
            SetHotkeyHashTable(CommandIDS.LANGUAGES, ui_ncmdViewLanguages);

            ui_ncmdViewTicker.Properties.ID = (int)CommandIDS.TICKER;
            SetHotkeyHashTable(CommandIDS.TICKER, ui_ncmdViewTicker);

            ui_ncmdViewTrade.Properties.ID = (int)CommandIDS.TRADE;
            SetHotkeyHashTable(CommandIDS.TRADE, ui_ncmdViewTrade);

            ui_ncmdViewNetPosition.Properties.ID = (int)CommandIDS.NET_POSITION;
            SetHotkeyHashTable(CommandIDS.NET_POSITION, ui_ncmdViewNetPosition);

            ui_ncmdRiskMonitor.Properties.ID = (int)CommandIDS.RISK_MONITOR;
            SetHotkeyHashTable(CommandIDS.RISK_MONITOR, ui_ncmdRiskMonitor);

            ui_ncmdViewMsgLog.Properties.ID = (int)CommandIDS.MESSAGE_LOG;
            SetHotkeyHashTable(CommandIDS.MESSAGE_LOG, ui_ncmdViewMsgLog);

            ui_ncmdViewContractInfo.Properties.ID = (int)CommandIDS.CONTRACT_INFORMATION;
            SetHotkeyHashTable(CommandIDS.CONTRACT_INFORMATION, ui_ncmdViewContractInfo);

            ui_ncmdViewToolBar.Properties.ID = (int)CommandIDS.TOOL_BAR;
            SetHotkeyHashTable(CommandIDS.TOOL_BAR, ui_ncmdViewToolBar);

            ui_ncmdViewFilterBar.Properties.ID = (int)CommandIDS.FILTER_BAR;
            SetHotkeyHashTable(CommandIDS.FILTER_BAR, ui_ncmdViewFilterBar);

            ui_ncmdViewMessageBar.Properties.ID = (int)CommandIDS.MESSAGE_BAR;
            SetHotkeyHashTable(CommandIDS.MESSAGE_BAR, ui_ncmdViewMessageBar);

            ui_ncmdViewStatusBar.Properties.ID = (int)CommandIDS.STATUS_BAR;
            SetHotkeyHashTable(CommandIDS.STATUS_BAR, ui_ncmdViewStatusBar);

            nmnuCmdViewTopStatusBar.Properties.ID = (int)CommandIDS.TOP_STATUS_BAR;
            SetHotkeyHashTable(CommandIDS.TOP_STATUS_BAR, nmnuCmdViewTopStatusBar);

            nmnuCmdViewMiddleStatusBar.Properties.ID = (int)CommandIDS.MIDDLE_STATUS_BAR;
            SetHotkeyHashTable(CommandIDS.MIDDLE_STATUS_BAR, nmnuCmdViewMiddleStatusBar);

            nmnuCmdViewBottomStatusBar.Properties.ID = (int)CommandIDS.BOTTOM_STATUS_BAR;
            SetHotkeyHashTable(CommandIDS.BOTTOM_STATUS_BAR, nmnuCmdViewBottomStatusBar);

            ui_ncmdViewAdminMsgBar.Properties.ID = (int)CommandIDS.ADMIN_MESSAGE_BAR;
            SetHotkeyHashTable(CommandIDS.ADMIN_MESSAGE_BAR, ui_ncmdViewAdminMsgBar);

            ui_ncmdViewIndicesView.Properties.ID = (int)CommandIDS.INDICES_VIEW;
            SetHotkeyHashTable(CommandIDS.INDICES_VIEW, ui_ncmdViewIndicesView);

            ui_ncmdViewFullScreen.Properties.ID = (int)CommandIDS.FULL_SCREEN;
            SetHotkeyHashTable(CommandIDS.FULL_SCREEN, ui_ncmdViewFullScreen);

            ui_ncmdMarketMarketWatch.Properties.ID = (int)CommandIDS.MARKET_WATCH;
            SetHotkeyHashTable(CommandIDS.MARKET_WATCH, ui_ncmdMarketMarketWatch);

            ui_ncmdMarketMarketPicture.Properties.ID = (int)CommandIDS.MARKET_PICTURE;
            SetHotkeyHashTable(CommandIDS.MARKET_PICTURE, ui_ncmdMarketMarketPicture);

            ui_ncmdMarketSnapQuote.Properties.ID = (int)CommandIDS.SNAP_QUOTE;
            SetHotkeyHashTable(CommandIDS.SNAP_QUOTE, ui_ncmdMarketSnapQuote);

            ui_ncmdMarketMarketStatus.Properties.ID = (int)CommandIDS.MARKET_STATUS;
            SetHotkeyHashTable(CommandIDS.MARKET_STATUS, ui_ncmdMarketMarketStatus);

            ui_ncmdMarketTopGainerLosers.Properties.ID = (int)CommandIDS.TOP_GAINERS_LOSERS;
            SetHotkeyHashTable(CommandIDS.TOP_GAINERS_LOSERS, ui_ncmdMarketTopGainerLosers);

            ui_ncmdOrdersPlaceBuyOrders.Properties.ID = (int)CommandIDS.PLACE_BUY_ORDER;
            SetHotkeyHashTable(CommandIDS.PLACE_BUY_ORDER, ui_ncmdOrdersPlaceBuyOrders);

            ui_ncmdOrdersPlaceSellOrders.Properties.ID = (int)CommandIDS.PLACE_SELL_ORDER;
            SetHotkeyHashTable(CommandIDS.PLACE_SELL_ORDER, ui_ncmdOrdersPlaceSellOrders);

            ui_ncmdOrdersOrderBook.Properties.ID = (int)CommandIDS.ORDER_BOOK;
            SetHotkeyHashTable(CommandIDS.ORDER_BOOK, ui_ncmdOrdersOrderBook);

            ui_ncmdTradesTrades.Properties.ID = (int)CommandIDS.TRADES;
            SetHotkeyHashTable(CommandIDS.TRADES, ui_ncmdTradesTrades);

            ui_ncmdReloadConfig.Properties.ID = (int)CommandIDS.RELOAD_CONFIGURATION;
            SetHotkeyHashTable(CommandIDS.RELOAD_CONFIGURATION, ui_ncmdReloadConfig);

            ui_ncmdToolsCustomize.Properties.ID = (int)CommandIDS.CUSTOMIZE;
            SetHotkeyHashTable(CommandIDS.CUSTOMIZE, ui_ncmdToolsCustomize);

            ui_ncmdToolsLockWorkStation.Properties.ID = (int)CommandIDS.LOCK_WORKSTATION;
            SetHotkeyHashTable(CommandIDS.LOCK_WORKSTATION, ui_ncmdToolsLockWorkStation);

            ui_ncmdToolsPortfolio.Properties.ID = (int)CommandIDS.PORTFOLIO;
            SetHotkeyHashTable(CommandIDS.PORTFOLIO, ui_ncmdToolsPortfolio);

            ui_ncmdToolsPreferences.Properties.ID = (int)CommandIDS.PREFERENCES;
            SetHotkeyHashTable(CommandIDS.PREFERENCES, ui_ncmdToolsPreferences);

            ui_ncmdToolsSimulator.Properties.ID = (int)CommandIDS.SIMULATOR;

            ui_ncmdWindowNewWindow.Properties.ID = (int)CommandIDS.NEW_WINDOW;
            SetHotkeyHashTable(CommandIDS.NEW_WINDOW, ui_ncmdWindowNewWindow);

            ui_ncmdWindowClose.Properties.ID = (int)CommandIDS.CLOSE;
            SetHotkeyHashTable(CommandIDS.CLOSE, ui_ncmdWindowClose);

            ui_ncmdWindowCloseAll.Properties.ID = (int)CommandIDS.CLOSE_ALL;
            SetHotkeyHashTable(CommandIDS.CLOSE_ALL, ui_ncmdWindowCloseAll);

            ui_ncmdWindowCascade.Properties.ID = (int)CommandIDS.CASCADE;
            SetHotkeyHashTable(CommandIDS.CASCADE, ui_ncmdWindowCascade);

            ui_ncmdWindowTileHorizontally.Properties.ID = (int)CommandIDS.TILE_HORIZONTALLY;
            SetHotkeyHashTable(CommandIDS.TILE_HORIZONTALLY, ui_ncmdWindowTileHorizontally);

            ui_ncmdWindowTileVertically.Properties.ID = (int)CommandIDS.TILE_VERTICALLY;
            SetHotkeyHashTable(CommandIDS.TILE_VERTICALLY, ui_ncmdWindowTileVertically);

            ui_ncmdWindowWindow.Properties.ID = (int)CommandIDS.WINDOW;
            SetHotkeyHashTable(CommandIDS.WINDOW, ui_ncmdWindowWindow);

            ui_ncmdLanguagesEnglish.Properties.ID = (int)CommandIDS.ENGLISH;
            SetHotkeyHashTable(CommandIDS.ENGLISH, ui_ncmdLanguagesEnglish);

            ui_ncmdLanguagesHindi.Properties.ID = (int)CommandIDS.HINDI;
            SetHotkeyHashTable(CommandIDS.HINDI, ui_ncmdLanguagesHindi);

            ui_ncmbThemeMacOS.Properties.ID = (int)CommandIDS.MAC_OS;
            SetHotkeyHashTable(CommandIDS.MAC_OS, ui_ncmbThemeMacOS);

            ui_ncmbThemeOffice2007Black.Properties.ID = (int)CommandIDS.OFFICE_2007_BLACk;
            SetHotkeyHashTable(CommandIDS.OFFICE_2007_BLACk, ui_ncmbThemeOffice2007Black);

            ui_ncmbThemeOffice2007Blue.Properties.ID = (int)CommandIDS.OFFICE_2007_BLUE;
            SetHotkeyHashTable(CommandIDS.OFFICE_2007_BLUE, ui_ncmbThemeOffice2007Blue);

            ui_ncmbThemeOrange.Properties.ID = (int)CommandIDS.ORANGE;
            SetHotkeyHashTable(CommandIDS.ORANGE, ui_ncmbThemeOrange);

            ui_ncmbThemeVista.Properties.ID = (int)CommandIDS.VISTA;
            SetHotkeyHashTable(CommandIDS.VISTA, ui_ncmbThemeVista);

            ui_ncmdThemeVistaRoyal.Properties.ID = (int)CommandIDS.VISTA_ROYAL;
            SetHotkeyHashTable(CommandIDS.VISTA_ROYAL, ui_ncmdThemeVistaRoyal);

            ui_ncmdThemeInspirant.Properties.ID = (int)CommandIDS.INSPIRANT;
            SetHotkeyHashTable(CommandIDS.INSPIRANT, ui_ncmdThemeInspirant);

            ui_ncmdThemeVistaPlus.Properties.ID = (int)CommandIDS.VISTA_PLUS;
            SetHotkeyHashTable(CommandIDS.VISTA_PLUS, ui_ncmdThemeVistaPlus);

            ui_ncmdThemeVistaSlate.Properties.ID = (int)CommandIDS.VISTA_SLATE;
            SetHotkeyHashTable(CommandIDS.VISTA_SLATE, ui_ncmdThemeVistaSlate);

            ui_ncmdThemeOpusAlpha.Properties.ID = (int)CommandIDS.OPUS_ALPHA;
            SetHotkeyHashTable(CommandIDS.OPUS_ALPHA, ui_ncmdThemeOpusAlpha);

            ui_ncmdThemeOffice2007Aqua.Properties.ID = (int)CommandIDS.OFFICE_2007_AQUA;
            SetHotkeyHashTable(CommandIDS.OFFICE_2007_AQUA, ui_ncmdThemeOffice2007Aqua);

            ui_ncmdThemeSimple.Properties.ID = (int)CommandIDS.SIMPLE;
            SetHotkeyHashTable(CommandIDS.SIMPLE, ui_ncmdThemeSimple);

            ui_ntbBackup.Properties.ID = (int)CommandIDS.ONLINE_BACKUP;
            SetHotkeyHashTable(CommandIDS.ONLINE_BACKUP, ui_ntbBackup);

            ui_ntbPrint.Properties.ID = (int)CommandIDS.PRINT;
            SetHotkeyHashTable(CommandIDS.PRINT, ui_ntbPrint);

            ui_ntbModifyOrder.Properties.ID = (int)CommandIDS.MODIFY_ORDER;
            SetHotkeyHashTable(CommandIDS.MODIFY_ORDER, ui_ntbModifyOrder);

            ui_ntbCancelOrder.Properties.ID = (int)CommandIDS.CANCEL_SELECTED_ORDER;
            SetHotkeyHashTable(CommandIDS.CANCEL_SELECTED_ORDER, ui_ntbCancelOrder);

            ui_ntbCancelAllOrders.Properties.ID = (int)CommandIDS.CANCEL_ALL_ORDERS;
            SetHotkeyHashTable(CommandIDS.CANCEL_ALL_ORDERS, ui_ntbCancelAllOrders);

            ui_ncmdViewParticipantList.Properties.ID = (int)CommandIDS.PARTICIPANT_LIST;
            ui_ncmdViewMail.Properties.ID = (int)CommandIDS.MAIL;
            ui_ncmdViewIndexBar.Properties.ID = (int)CommandIDS.INDEX_BAR;

            ui_ntbFilter.Properties.ID = (int)CommandIDS.FILTER;
            SetHotkeyHashTable(CommandIDS.FILTER, ui_ntbFilter);

            ui_mnuChartsNewChart.Properties.ID = (int)CommandIDS.NEW_CHART;
            ui_ntbLogin.Properties.ID = (int)CommandIDS.LOGIN;
            ui_ntbLogoff.Properties.ID = (int)CommandIDS.LOGOFF;
            ui_ntbChangePassword.Properties.ID = (int)CommandIDS.CHANGE_PASSWORD;
            ui_ntbMessageLog.Properties.ID = (int)CommandIDS.MESSAGE_LOG;
            ui_ntbOrderEntry.Properties.ID = (int)CommandIDS.PLACE_BUY_ORDER;
            ui_ntbOrderBook.Properties.ID = (int)CommandIDS.ORDER_BOOK;
            ui_ntbNetPosition.Properties.ID = (int)CommandIDS.NET_POSITION;
            ui_ntbTrades.Properties.ID = (int)CommandIDS.TRADES;
            ui_ntbMarketWatch.Properties.ID = (int)CommandIDS.MARKET_WATCH;
            ui_ntbMarketPicture.Properties.ID = (int)CommandIDS.MARKET_PICTURE;
            ui_ntbContractInfo.Properties.ID = (int)CommandIDS.CONTRACT_INFORMATION;
            ui_nmnuWindows.Properties.ID = (int)CommandIDS.WINDOW;
            ui_ncmdMarketQuote.Properties.ID = (int)CommandIDS.MARKET_QUOTE;
            ui_ncmdViewAccountsInfo.Properties.ID = (int)CommandIDS.ACCOUNTS_TO_TRADE;
            ui_ncmdThemeRoyal.Properties.ID = (int)CommandIDS.ROYAL;
            ui_ncmdThemeAqua.Properties.ID = (int)CommandIDS.AQUA;
            ui_ncmdThemeMoonlight.Properties.ID = (int)CommandIDS.MOONLIGHT;
            ui_ncmdThemeWood.Properties.ID = (int)CommandIDS.WOOD;
            ui_ncmdFileChangePassword.Properties.ID = (int)CommandIDS.CHANGE_PASSWORD;
            ui_mnuPeriodicity1Minute.Properties.ID = (int)CommandIDS.PERIODICITY_1_MINUTE;
            ui_mnuPeriodicity5Minute.Properties.ID = (int)CommandIDS.PERIODICITY_5_MINUTE;
            ui_mnuPeriodicity15Minute.Properties.ID = (int)CommandIDS.PERIODICITY_15_MINUTE;
            ui_mnuPeriodicity30Minute.Properties.ID = (int)CommandIDS.PERIODICITY_30_MINUTE;
            ui_mnuPeriodicity1Hour.Properties.ID = (int)CommandIDS.PERIODICITY_1_HOUR;
            ui_mnuPeriodicity4Hour.Properties.ID = (int)CommandIDS.PERIODICITY_4_HOUR;
            ui_mnuPeriodicityDaily.Properties.ID = (int)CommandIDS.PERIODICITY_DAILY;
            ui_mnuPeriodicityWeekly.Properties.ID = (int)CommandIDS.PERIODICITY_WEEKLY;
            ui_mnuPeriodicityMonthly.Properties.ID = (int)CommandIDS.PERIODICITY_MONTHLY;
            ui_mnuChartTypeBarChart.Properties.ID = (int)CommandIDS.CHARTTYPE_BAR_CHART;
            ui_mnuChartTypeCandleChart.Properties.ID = (int)CommandIDS.CHARTTYPE_CANDLE_CHART;
            ui_mnuChartTypeLineChart.Properties.ID = (int)CommandIDS.CHARTTYPE_LINE_CHART;
            ui_nmunPriceTypePointandFigure.Properties.ID = (int)CommandIDS.PRICETYPE_POINT_AND_FIGURE;
            ui_nmunPriceTypeRenko.Properties.ID = (int)CommandIDS.PRICETYPE_RENKO;
            ui_nmunPriceTypeKagi.Properties.ID = (int)CommandIDS.PRICETYPE_KAGI;
            ui_nmunPriceTypeThreeLineBreak.Properties.ID = (int)CommandIDS.PRICETYPE_THREE_LINE_BREAK;
            ui_nmunPriceTypeEquiVolume.Properties.ID = (int)CommandIDS.PRICETYPE_EQUI_VOLUME;
            ui_nmunPriceTypeEquiVolumeShadow.Properties.ID = (int)CommandIDS.PRICETYPE_EQUI_VOLUME_SHADOW;
            ui_nmunPriceTypeCandleVolume.Properties.ID = (int)CommandIDS.PRICETYPE_CANDLE_VOLUME;
            ui_nmunPriceTypeHeikinAshi.Properties.ID = (int)CommandIDS.PRICETYPE_HEIKIN_ASHI;
            ui_nmunPriceTypeStandardChart.Properties.ID = (int)CommandIDS.PRICETYPE_STANDARD_CHART;
            ui_mnuChartsZoomIn.Properties.ID = (int)CommandIDS.ZOOM_IN;
            ui_mnuChartsZoomOut.Properties.ID = (int)CommandIDS.ZOOM_OUT;
            ui_mnuChartsTrackCursor.Properties.ID = (int)CommandIDS.TRACK_CURSOR;
            ui_mnuChartsVolume.Properties.ID = (int)CommandIDS.VOLUME;
            ui_mnuChartsGrid.Properties.ID = (int)CommandIDS.GRID;
            ui_mnuChart3DStyle.Properties.ID = (int)CommandIDS.CHART_3D_STYLE;
            ui_mnuSnapshotPrint.Properties.ID = (int)CommandIDS.SNAPSHOT_PRINT;
            ui_mnuSnapshotSave.Properties.ID = (int)CommandIDS.SNAPSHOT_SAVE;
            ui_nmnuTechnicalAnalysisIndicatorList.Properties.ID = (int)CommandIDS.INDICATOR_LIST;
            ui_mnuAddHorizontalLine.Properties.ID = (int)CommandIDS.HORIZONTAL_LINE;
            ui_mnuAddVerticalLine.Properties.ID = (int)CommandIDS.VERTICAL_LINE;
            ui_mnuAddText.Properties.ID = (int)CommandIDS.TEXT;
            ui_mnuAddTrendLine.Properties.ID = (int)CommandIDS.TREND_LINE;
            ui_mnuAddEllipse.Properties.ID = (int)CommandIDS.ELLIPSE;
            ui_mnuAddSpeedLines.Properties.ID = (int)CommandIDS.SPEED_LINES;
            ui_mnuAddGannFan.Properties.ID = (int)CommandIDS.GANN_FAN;
            ui_mnuAddFibonacciArcs.Properties.ID = (int)CommandIDS.FIBONACCI_ARC;
            ui_mnuAddFibonacciRetracement.Properties.ID = (int)CommandIDS.FIBONACCI_RETRACEMENT;
            ui_mnuAddFibonacciFan.Properties.ID = (int)CommandIDS.FIBONACCI_FAN;
            ui_mnuAddFibonacciTimezone.Properties.ID = (int)CommandIDS.FIBONACCI_TIMEZONE;
            ui_mnuAddTironeLevel.Properties.ID = (int)CommandIDS.TIRONE_LEVEL;
            ui_mnuAddRafRegression.Properties.ID = (int)CommandIDS.RAFF_REGRESSION;
            ui_mnuAddErrorChannel.Properties.ID = (int)CommandIDS.ERROR_CHANNEL;
            ui_mnuAddRectangle.Properties.ID = (int)CommandIDS.RECTANGLE;
            ui_mnuAddFreeHandDrawing.Properties.ID = (int)CommandIDS.FREE_HAND_DRAWING;
            ui_nmnuSurveillanceSurveillance.Properties.ID = (int)CommandIDS.SURVEILLANCE;
            ui_nmnuHelpAboutUs.Properties.ID = (int)CommandIDS.ABOUTUS;
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetCommandsIDs Method");
        }

        private void SetHotkeyHashTable(CommandIDS cmd, ToolStripMenuItem ntlsMnuItem)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetHotkeyHashTable Method");
            if (!_CommandBarHash.ContainsKey(cmd.ToString()))
                _CommandBarHash.Add(cmd.ToString(), ntlsMnuItem);
            string shortcut = ntlsMnuItem.ShortcutKeys.ToString();
            if (_hotKeySettingsHashTable == null)
            {
                _hotKeySettingsHashTable = new Hashtable();
            }

            if (shortcut.ToLower() == "none")
            {
                shortcut = UctlHotKeysSettings.NONE_HOTEKEY;
            }
            //else
            //{
            if (_hotKeySettingsHashTable.ContainsKey(cmd.ToString()))
            {
                ntlsMnuItem.ShortcutKeyDisplayString = _hotKeySettingsHashTable[cmd.ToString()].ToString();
                ntlsMnuItem.ShowShortcutKeys = true;
                string[] x = _hotKeySettingsHashTable[cmd.ToString()].ToString().Split('+');
                if (x.Count() == 1)
                {
                    if (x[0].ToUpper() != "[NONE]")
                    {
                        ntlsMnuItem.ShortcutKeys = (Keys)Enum.Parse(typeof(Keys), _hotKeySettingsHashTable[cmd.ToString()].ToString());
                    }
                    else
                    {
                        ntlsMnuItem.ShortcutKeyDisplayString = string.Empty;
                    }
                }
                else
                {
                    ntlsMnuItem.ShortcutKeys = (Keys)Enum.Parse(typeof(Keys), x[0].ToString()) | (Keys)Enum.Parse(typeof(Keys), x[1].ToString());
                }
            }
            else
            {
                _hotKeySettingsHashTable.Add(cmd.ToString(), shortcut);
            }
            //}


            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetHotkeyHashTable Method");
        }

        /// <summary>
        /// Saves the hot key settings
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="ncmd"></param>
        private void SetHotkeyHashTable(CommandIDS cmd, NCommand ncmd)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetHotkeyHashTable Method");
            if (!_CommandBarHash.ContainsKey(cmd.ToString()))
                _CommandBarHash.Add(cmd.ToString(), ncmd);
            string shortcut = ncmd.Properties.Shortcut.ToString();
            if (shortcut.ToLower() == "none")
            {
                shortcut = UctlHotKeysSettings.NONE_HOTEKEY;
            }
            if (_hotKeySettingsHashTable == null)
            {
                _hotKeySettingsHashTable = new Hashtable();
            }
            //  else
            {
                if (_hotKeySettingsHashTable.ContainsKey(cmd.ToString()))
                {
                    SetHotKey("", _hotKeySettingsHashTable[cmd.ToString()].ToString(), ncmd);
                }
                else
                {
                    _hotKeySettingsHashTable.Add(cmd.ToString(), shortcut);
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetHotkeyHashTable Method");
        }

        /// <summary>
        /// Applys the specified hot keys to windows
        /// </summary>
        private void ApplyHotkeys()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ApplyHotkeys Method");

            foreach (string Key in _hotKeySettingsHashTable.Keys)
            {
                var ncmd = ((NCommand)_CommandBarHash[Key]);
                ncmd.Properties.Shortcut.Modifiers = Keys.None;
                if (ncmd != null)
                {
                    string[] strArray = _hotKeySettingsHashTable[Key].ToString().Split('+');
                    if (
                        (strArray[0].Equals(UctlHotKeysSettings.NONE_HOTEKEY,
                                            StringComparison.InvariantCultureIgnoreCase)) || (strArray.Contains("+")))
                    {
                        continue;
                    }
                    for (int strLoop = 0; strLoop < strArray.Length; strLoop++)
                    {
                        string item = strArray[strLoop];
                        item = item.Trim();

                        if (item.Equals("Alt", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Alt;
                        }
                        else if (item.Equals("Shift", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Shift;
                        }
                        else if (item.Equals("Ctrl", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ncmd.Properties.Shortcut.Modifiers = ncmd.Properties.Shortcut.Modifiers | Keys.Control;
                        }
                        else
                        {
                            switch (item)
                            {
                                case "0":
                                    item = "D0";
                                    break;
                                case "1":
                                    item = "D1";
                                    break;
                                case "2":
                                    item = "D2";
                                    break;
                                case "3":
                                    item = "D3";
                                    break;
                                case "4":
                                    item = "D4";
                                    break;
                                case "5":
                                    item = "D5";
                                    break;
                                case "6":
                                    item = "D6";
                                    break;
                                case "7":
                                    item = "D7";
                                    break;
                                case "8":
                                    item = "D8";
                                    break;
                                case "9":
                                    item = "D9";
                                    break;
                                default:
                                    break;
                            }
                            ncmd.Properties.Shortcut.Key = (Keys)Enum.Parse(typeof(Keys), item);
                        }
                    }
                }
            }
            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ApplyHotkeys Method");
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //this.ui_ndmTWS.DocumentManager.LayoutMdi(_currentlayOut);
        }

        /// <summary>
        /// Sets the specified language to the form and its components
        /// </summary>
        /// <param name="languageCode">Language code</param>
        public void SetLanguage(string languageCode)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetLanguage Method");

            ClsLocalizationHandler.LangaugeCode = languageCode;
            ClsLocalizationHandler.INSTANCE.Init();
            SetMenuLanguage();
            //foreach (NUIDocument item in ui_ndmTWS.DocumentManager.Documents)
            //{
            //    if (item.Client is uctlBase)
            //    {
            //        (item.Client as uctlBase).SetLocalization();
            //    }
            //}

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetLanguage Method");
        }

        /// <summary>
        /// Sets the values of the menus corresponding to respective value
        /// </summary>
        private void SetMenuLanguage()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetMenuLanguage Method");

            ui_nmnuFile.Properties.Text = ClsLocalizationHandler.File;
            ui_nmnuView.Properties.Text = ClsLocalizationHandler.View;
            ui_nmnuMarket.Properties.Text = ClsLocalizationHandler.Market;
            ui_nmnuOrders.Properties.Text = ClsLocalizationHandler.Order;
            ui_nmnuTrades.Properties.Text = ClsLocalizationHandler.Trades;
            ui_nmnuTools.Properties.Text = ClsLocalizationHandler.Tools;
            ui_nmnuWindows.Properties.Text = ClsLocalizationHandler.Window;
            ui_nmnuHelp.Properties.Text = ClsLocalizationHandler.Help;
            ui_ncmdFileLogin.Properties.Text = ClsLocalizationHandler.Login;
            ui_ncmdFileLogOff.Properties.Text = ClsLocalizationHandler.LogOff;
            ui_ncmdFileLoadWorkSpace.Properties.Text = ClsLocalizationHandler.Load + " " +
                                                       ClsLocalizationHandler.WorkSpace;
            ui_ncmdFileSaveWorkSpace.Properties.Text = ClsLocalizationHandler.Save + " " +
                                                       ClsLocalizationHandler.WorkSpace;
            ui_ncmdFileExit.Properties.Text = ClsLocalizationHandler.Exit;
            ui_ncmdViewTicker.Properties.Text = ClsLocalizationHandler.Ticker;
            ui_ncmdViewTrade.Properties.Text = ClsLocalizationHandler.Trade;
            ui_ncmdViewNetPosition.Properties.Text = ClsLocalizationHandler.Net + " " +
                                                     ClsLocalizationHandler.Position;
            ui_ncmdViewMsgLog.Properties.Text = ClsLocalizationHandler.Message + " " +
                                                ClsLocalizationHandler.Log;
            ui_ncmdViewContractInfo.Properties.Text = ClsLocalizationHandler.Contract + " " +
                                                      ClsLocalizationHandler.Information;
            ui_ncmdViewToolBar.Properties.Text = ClsLocalizationHandler.ToolBar;
            ui_ncmdViewFilterBar.Properties.Text = ClsLocalizationHandler.FilterBar;
            ui_ncmdViewMessageBar.Properties.Text = ClsLocalizationHandler.MessageBar;
            ui_ncmdViewStatusBar.Properties.Text = ClsLocalizationHandler.StatusBar;
            nmnuCmdViewTopStatusBar.Properties.Text = ClsLocalizationHandler.Top + " " +
                                                      ClsLocalizationHandler.StatusBar;
            nmnuCmdViewMiddleStatusBar.Properties.Text = ClsLocalizationHandler.Middle + " " +
                                                         ClsLocalizationHandler.StatusBar;
            nmnuCmdViewBottomStatusBar.Properties.Text = ClsLocalizationHandler.Bottom + " " +
                                                         ClsLocalizationHandler.StatusBar;
            ui_ncmdViewAdminMsgBar.Properties.Text = ClsLocalizationHandler.Admin + " " +
                                                     ClsLocalizationHandler.MessageBar;
            ui_ncmdViewIndicesView.Properties.Text = ClsLocalizationHandler.IndiciesView;
            ui_ncmdViewFullScreen.Properties.Text = ClsLocalizationHandler.FullScreen;
            ui_ncmdMarketMarketWatch.Properties.Text = ClsLocalizationHandler.Market + " " +
                                                       ClsLocalizationHandler.Watch;
            ui_ncmdMarketMarketPicture.Properties.Text = ClsLocalizationHandler.Market + " " +
                                                         ClsLocalizationHandler.Picture;
            ui_ncmdMarketSnapQuote.Properties.Text = ClsLocalizationHandler.Snap + " " +
                                                     ClsLocalizationHandler.Quote;
            ui_ncmdMarketMarketStatus.Properties.Text = ClsLocalizationHandler.Market + " " +
                                                        ClsLocalizationHandler.Status;
            ui_ncmdMarketTopGainerLosers.Properties.Text = ClsLocalizationHandler.Top + " " +
                                                           ClsLocalizationHandler.Gainers + "/" +
                                                           ClsLocalizationHandler.Losers;
            ui_ncmdOrdersPlaceBuyOrders.Properties.Text = ClsLocalizationHandler.PlaceBuyOrder;
            ui_ncmdOrdersPlaceSellOrders.Properties.Text = ClsLocalizationHandler.PlaceSellOrder;
            ui_ncmdOrdersOrderBook.Properties.Text = ClsLocalizationHandler.Order + " " +
                                                     ClsLocalizationHandler.Book;
            ui_ncmdTradesTrades.Properties.Text = ClsLocalizationHandler.Trades;
            ui_ncmdToolsCustomize.Properties.Text = ClsLocalizationHandler.Customize;
            ui_ncmdToolsLockWorkStation.Properties.Text = ClsLocalizationHandler.LockWorkStation;
            ui_ncmdToolsPortfolio.Properties.Text = ClsLocalizationHandler.Portfolio;
            ui_ncmdToolsPreferences.Properties.Text = ClsLocalizationHandler.Preferences;
            ui_ncmdWindowNewWindow.Properties.Text = ClsLocalizationHandler.New + " " +
                                                     ClsLocalizationHandler.Window;
            ui_ncmdWindowClose.Properties.Text = ClsLocalizationHandler.Close;
            ui_ncmdWindowCloseAll.Properties.Text = ClsLocalizationHandler.Close + " " +
                                                    ClsLocalizationHandler.All;
            ui_ncmdWindowCascade.Properties.Text = ClsLocalizationHandler.Cascade;
            ui_ncmdWindowTileHorizontally.Properties.Text = ClsLocalizationHandler.TileHorizontally;
            ui_ncmdWindowTileVertically.Properties.Text = ClsLocalizationHandler.TileVertically;
            ui_ncmdWindowWindow.Properties.Text = ClsLocalizationHandler.Window;
            ui_ncmdViewThemes.Properties.Text = ClsLocalizationHandler.Themes;

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetMenuLanguage Method");
        }

        /// <summary>
        /// Disactivates the timer for workspace locking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Activated(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FrmMain_Activated Method");

            //Action A = () =>
            //{
            ui_tmrLockWorkstation.Enabled = false;
            //};
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FrmMain_Activated Method");
        }

        public int CalClientSize()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into CalClientSize Method");


            //FileHandling.WriteDevelopmentLog("Main Form : Exit from CalClientSize Method");
            return ui_ncbmTWS.CommandManager.GetAllCommands(true).Count;
        }

        /// <summary>
        /// Activates the timer for workspace locking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Deactivate(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FrmMain_Deactivate Method");

            if (Application.OpenForms.Count > 1)
            {
                Application.OpenForms[Application.OpenForms.Count - 1].TopMost = false;
            }

            if (Properties.Settings.Default.IsLockWorkStation)
            {
                ui_tmrLockWorkstation.Enabled = true;
                ui_tmrLockWorkstation.Interval = Properties.Settings.Default.LockWorkStationTime;
            }
            else
            {
                ui_tmrLockWorkstation.Enabled = false;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FrmMain_Deactivate Method");
        }

        /// <summary>
        /// Performs workspace locking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_tmrLockWorkstation_Tick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ui_tmrLockWorkstation_Tick Method");

            LockWorkStationMenuHandler();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ui_tmrLockWorkstation_Tick Method");
        }

        /// <summary>
        /// Displalys dialog for modifying the order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntbModifyOrder_Click(object sender, CommandEventArgs e)
        {
            //uctlOrderEntry objuctlOrderEntry = new uctlOrderEntry();
            //frmDialogForm objfrmDialogForm = new frmDialogForm();
            //objfrmDialogForm.Controls.Clear();
            //Size objSize = new System.Drawing.Size(objuctlOrderEntry.Width + 30, objuctlOrderEntry.Height + 45);
            //objfrmDialogForm.Size = objSize;
            //objfrmDialogForm.Controls.Add(objuctlOrderEntry);
            //objuctlOrderEntry.Dock = DockStyle.Fill;
            //objfrmDialogForm.Text = "Modify Order ";
            //objfrmDialogForm.ShowDialog();
        }

        private void ui_tmrTicker_Tick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into ui_tmrTicker_Tick Method");

            var objSens = new ClsTickerInfo();

            objSens.ID = "OEC_OEC_1_ES_ESH2";

            _objTickerTape.UpdateControl(objSens, ImageType.NO_CHANGE);

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from ui_tmrTicker_Tick Method");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure want to Exit?");
            if (result == DialogResult.Yes)
            {
                clsTWSOrderManagerJSON.INSTANCE.DisconnectOrderServer();
                Process.GetCurrentProcess().Kill();
                Environment.Exit(1);
            }
            else
            {
                if (TWS.Cls.ClsGlobal.SubscibedSymbolList.Count > 0)
                {
                    List<Symbol> sl = new List<Symbol>();
                    foreach (Symbol item in TWS.Cls.ClsGlobal.SubscibedSymbolList.Values)
                    {
                        sl.Add(item);
                    }
                    if (ActiveMdiChild != null)
                    {
                        if (((frmBase)ActiveMdiChild).Formkey.Contains("MARKET_WATCH"))
                        {
                            ((frmMarketWatchNew)ActiveMdiChild).ReactivateMarketWatch(sl);
                        }
                    }
                }
                e.Cancel = true;
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FrmMain_FormClosing Method");
        }

        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into FrmMain_MdiChildActivate Method");

            var objfrmBase = ((frmBase)ActiveMdiChild);
            if (objfrmBase == null)
            {
                return;
            }
            //if (objfrmBase.Text.Contains("Chart") ||
            //    (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART")))
            //{
            //    CheckFormAsChart(objfrmBase);
            //}
            if (objfrmBase != null)
            {
                if (!_ChildFormList.Contains(ActiveMdiChild))
                    _ChildFormList.Add(ActiveMdiChild);
                //else
                //    _ChildFormList[_ChildFormList.IndexOf(this.ActiveMdiChild)].Text = this.ActiveMdiChild.Text;
                objfrmBase.FormClosed += objfrmBase_FormClosed;
                objfrmBase.TextChanged += objfrmBase_TextChanged;
            }

            AddItemsToWindow();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from FrmMain_MdiChildActivate Method");
        }
        //Commented by Namo
        //private void CheckFormAsChart(frmBase objfrmBase)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into CheckFormAsChart Method");

        //    ui_mnuChartsVolume.Checked = ((frmNewChart)objfrmBase).ui_ocxStockChart.ShowVolumes;
        //    ui_mnuChartsTrackCursor.Checked = ((frmNewChart)objfrmBase).ui_ocxStockChart.CrossHairs;
        //    ui_mnuChartsGrid.Checked = ((frmNewChart)objfrmBase).ui_ocxStockChart.XGrid;
        //    ui_mnuChart3DStyle.Checked = ((frmNewChart)objfrmBase).ui_ocxStockChart.ThreeDStyle;

        //    ManageChartTypeMenuChecking(null);
        //    switch (((frmNewChart)objfrmBase).crtChartType)
        //    {
        //        case ChartType.BAR:
        //            ui_mnuChartTypeBarChart.Checked = true;
        //            break;
        //        case ChartType.CANDLE:
        //            ui_mnuChartTypeCandleChart.Checked = true;
        //            break;
        //        case ChartType.LINE:
        //            ui_mnuChartTypeLineChart.Checked = true;
        //            break;
        //    }
        //    ManagePriceTypeMenuChecking(null);
        //    switch (((frmNewChart)objfrmBase).crtPriceType)
        //    {
        //        case PriceType.POINT_AND_FIGURE:
        //            ui_nmunPriceTypePointandFigure.Checked = true;
        //            break;
        //        case PriceType.RENKO:
        //            ui_nmunPriceTypeRenko.Checked = true;
        //            break;
        //        case PriceType.KAGI:
        //            ui_nmunPriceTypeKagi.Checked = true;
        //            break;
        //        case PriceType.THREE_LINE_BREAK:
        //            ui_nmunPriceTypeThreeLineBreak.Checked = true;
        //            break;
        //        case PriceType.EQUI_VOLUME:
        //            ui_nmunPriceTypeEquiVolume.Checked = true;
        //            break;
        //        case PriceType.EQUI_VOLUME_SHADOW:
        //            ui_nmunPriceTypeEquiVolumeShadow.Checked = true;
        //            break;
        //        case PriceType.CANDLE_VOLUME:
        //            ui_nmunPriceTypeCandleVolume.Checked = true;
        //            break;
        //        case PriceType.HEIKIN_ASHI:
        //            ui_nmunPriceTypeHeikinAshi.Checked = true;
        //            break;
        //        case PriceType.STANDARD_CHART:
        //            ui_nmunPriceTypeStandardChart.Checked = true;
        //            break;
        //    }
        //    ManagePeriodicityMenuChecking(null);
        //    switch (((frmNewChart)objfrmBase)._chartBarType)
        //    {
        //        case ePeriodicity.Minutely_1:
        //            {
        //                switch (((frmNewChart)objfrmBase).BarInterval)
        //                {
        //                    case 1:
        //                        ui_mnuPeriodicity1Minute.Checked = true;
        //                        break;
        //                    case 5:
        //                        ui_mnuPeriodicity5Minute.Checked = true;
        //                        break;
        //                    case 15:
        //                        ui_mnuPeriodicity15Minute.Checked = true;
        //                        break;
        //                    case 30:
        //                        ui_mnuPeriodicity30Minute.Checked = true;
        //                        break;
        //                }
        //            }
        //            break;
        //        case ePeriodicity.Hourly_1:
        //            {
        //                switch (((frmNewChart)objfrmBase).BarInterval)
        //                {
        //                    case 1:
        //                        ui_mnuPeriodicity1Hour.Checked = true;
        //                        break;
        //                    case 4:
        //                        ui_mnuPeriodicity4Hour.Checked = true;
        //                        break;
        //                }
        //            }
        //            break;
        //        //case ePeriodicity.Hourly_4:
        //        //    ui_mnuPeriodicity4Hour.Checked = true;
        //        //    break;
        //        case ePeriodicity.Daily:
        //            ui_mnuPeriodicityDaily.Checked = true;
        //            break;
        //        case ePeriodicity.Weekly:
        //            ui_mnuPeriodicityWeekly.Checked = true;
        //            break;
        //        case ePeriodicity.Monthly:
        //            ui_mnuPeriodicityMonthly.Checked = true;
        //            break;
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from CheckFormAsChart Method");
        //}

        private void objfrmBase_TextChanged(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objfrmBase_TextChanged Method");

            var f = (Form)sender;
            int index = _ChildFormList.IndexOf(f);
            if (index >= 0)
                _ChildFormList[_ChildFormList.IndexOf(f)].Text = f.Text;
            AddItemsToWindow();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objfrmBase_TextChanged Method");
        }

        private void AddItemsToWindow()
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into AddItemsToWindow Method");

            ui_ncmdWindowWindow.Commands.Clear();
            foreach (frmBase item in _ChildFormList)
            {
                var objNCommand = new NCommand();
                objNCommand.Properties.Text = item.Text;
                //objNCommand.Properties.ID = (int)(CommandIDS)Enum.Parse(typeof(CommandIDS), item.Formkey.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                if (item != null)
                {
                    if (item.IsActive)
                        objNCommand.Checked = true;
                    ui_ncmdWindowWindow.Commands.Add(objNCommand);
                }
            }

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from AddItemsToWindow Method");
        }

        private void objfrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into objfrmBase_FormClosed Method");

            var f = (Form)sender;
            _ChildFormList.Remove(f);
            AddItemsToWindow();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from objfrmBase_FormClosed Method");
        }

        public void DisplayPopUp(string popTitle, string msg, string msgColor, string imgType)
        {
            //FileHandling.WriteDevelopmentLog("Main Form : Enter into DisplayPopUp Method");

            #region "  OLD CODE "

            //InitPopup(msg, msgColor, imgType);
            //_popupNotify.Caption.Content.Text = "<b><font size='10' color='black'>" + popTitle + "</font></b>";
            //PopupAnimation animation = PopupAnimation.None;
            //animation |= PopupAnimation.Slide;
            //_popupNotify.AutoHide = true;
            //_popupNotify.Animation = animation;
            //_popupNotify.AnimationDirection = PopupAnimationDirection.BottomToTop;
            //_popupNotify.Palette.Copy(NUIManager.Palette);
            //_popupNotify.Show();

            #endregion "  OLD CODE "

            var skinPopup = new NPopupNotify();
            skinPopup.PredefinedStyle = PredefinedPopupStyle.Skinned;
            skinPopup.PreferredBounds = new Rectangle(skinPopup.PreferredBounds.Left, skinPopup.PreferredBounds.Right,
                                                      110, 50);
            skinPopup.Font = new Font("Verdana", 8.0f);
            skinPopup.Caption.Visible = false;
            NImageAndTextItem content = skinPopup.Content;
            content.Image = imgType == "Connected"
                                ? Image.FromFile(Application.StartupPath + "\\Resx\\thumb-up-20.png")
                                : Image.FromFile(Application.StartupPath + "\\Resx\\red-thumb-20.png");
            content.ImageSize = new NSize(23, 23);

            content.TextMargins = new NPadding(0, 4, 0, 0);
            content.Text = msg;

            PopupAnimation animation = PopupAnimation.None;
            animation |= PopupAnimation.Fade;
            animation |= PopupAnimation.Slide;

            skinPopup.AutoHide = true;
            skinPopup.VisibleSpan = 4000;
            skinPopup.Opacity = 255;
            skinPopup.Animation = animation;
            skinPopup.AnimationDirection = PopupAnimationDirection.BottomToTop;
            skinPopup.VisibleOnMouseOver = false;
            skinPopup.FullOpacityOnMouseOver = false;
            skinPopup.AnimationInterval = 20;
            skinPopup.AnimationSteps = 19;
            skinPopup.Palette.Copy(NUIManager.Palette);
            skinPopup.Show();

            //FileHandling.WriteDevelopmentLog("Main Form : Exit from DisplayPopUp Method");
        }

        #region " Vinod have commited this lines as CommandBarSetting saving in different way  "

        //private void ui_ndtIndexBar_LocationChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void nDockFilter_LocationChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void nDockTicker_VisibleChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void nDockTicker_LocationChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void nDockFilter_VisibleChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void ui_ndtIndexBar_VisibleChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void ui_ndtToolBar_VisibleChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        //private void SetCommandBarSettingsDD(object sender, EventArgs e)
        //{
        //    int floatingX = ((NDockingToolbar)(sender)).FloatingLocation.X;
        //    int floatingY = ((NDockingToolbar)(sender)).FloatingLocation.X;
        //    int floatingHeight = ((NDockingToolbar)(sender)).FloatingSize.Height;
        //    int floatingWidth = ((NDockingToolbar)(sender)).FloatingSize.Width;
        //    int rowIndex = ((NDockingToolbar)(sender)).RowIndex;
        //    int index = ui_ncbmTWS.Toolbars.IndexOf(((NDockingToolbar)(sender)));
        //    bool visible = ((NDockingToolbar)(sender)).Visible;
        //    CommandBarSetting objCommandBarSetting = new CommandBarSetting(floatingX, floatingY, floatingHeight, floatingWidth, rowIndex, index,visible);
        //    if (objTWSSettings.DDCommandBarSetting[index] != null)
        //        objTWSSettings.DDCommandBarSetting[index] = objCommandBarSetting;
        //    else
        //        objTWSSettings.DDCommandBarSetting.Add(index, objCommandBarSetting);
        //}


        //private void ui_ndtToolBar_LocationChanged(object sender, EventArgs e)
        //{
        //    SetCommandBarSettingsDD(sender, e);
        //}

        #endregion  " Vinod have commited this lines as it has been handeled in different way  "
        //Commented by Namo
        //#region "     Chart Menu Handlers  "

        //private void PeriodicityWeeklyMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into PeriodicityWeeklyMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Weekly, 1, NewHistoryType.WEEK, ui_mnuPeriodicityWeekly);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from PeriodicityWeeklyMenuHandler Method");
        //}

        //private void PeriodicityMonthlyMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into PeriodicityMonthlyMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Monthly, 1, NewHistoryType.MONTH, ui_mnuPeriodicityMonthly);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from PeriodicityMonthlyMenuHandler Method");
        //}

        //private void PeriodicityDailyMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into PeriodicityDailyMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Daily, 1, NewHistoryType.DAY, ui_mnuPeriodicityDaily);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from PeriodicityDailyMenuHandler Method");
        //}

        //private void Periodicity4HourMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity4HourMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Hourly_1, 4, NewHistoryType.HOUR, ui_mnuPeriodicity4Hour);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity4HourMenuHandler Method");
        //}

        //private void Periodicity1HourMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity1HourMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Hourly_1, 1, NewHistoryType.HOUR, ui_mnuPeriodicity1Hour);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity1HourMenuHandler Method");
        //}

        //private void Periodicity30MinuteMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity30MinuteMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Minutely_1, 30, NewHistoryType.MINUTE, ui_mnuPeriodicity30Minute);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity30MinuteMenuHandler Method");
        //}

        //private void Periodicity15MinuteMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity15MinuteMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Minutely_1, 15, NewHistoryType.MINUTE, ui_mnuPeriodicity15Minute);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity15MinuteMenuHandler Method");
        //}

        //private void Periodicity5MinuteMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity5MinuteMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Minutely_1, 5, NewHistoryType.MINUTE, ui_mnuPeriodicity5Minute);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity5MinuteMenuHandler Method");
        //}

        //private void Periodicity1MinuteMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Periodicity1MinuteMenuHandler Method");

        //    SetPeriodicity(ePeriodicity.Minutely_1, 1, NewHistoryType.MINUTE, ui_mnuPeriodicity1Minute);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Periodicity1MinuteMenuHandler Method");
        //}

        //public void SetPeriodicity(ePeriodicity periodicity, int interval, NewHistoryType historyType, NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetPeriodicity Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    ManagePeriodicityMenuChecking(cmd);
        //    if (objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ChangePeriodicity(periodicity, interval, historyType);
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetPeriodicity Method");
        //}

        //private void ManagePeriodicityMenuChecking(NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ManagePeriodicityMenuChecking Method");

        //    foreach (NCommand item in ui_mnuChartsPeriodicity.Commands)
        //    {
        //        item.Checked = false;
        //    }
        //    if (cmd != null)
        //        cmd.Checked = true;

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ManagePeriodicityMenuChecking Method");
        //}

        //private void LineChartTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into LineChartTypeMenuHandler Method");

        //    SetChartType(ChartType.LINE, ui_mnuChartTypeLineChart);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from LineChartTypeMenuHandler Method");
        //}

        //private void CandleChartTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into CandleChartTypeMenuHandler Method");

        //    SetChartType(ChartType.CANDLE, ui_mnuChartTypeCandleChart);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from CandleChartTypeMenuHandler Method");
        //}

        //private void BarChartTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into BarChartTypeMenuHandler Method");

        //    SetChartType(ChartType.BAR, ui_mnuChartTypeBarChart);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from BarChartTypeMenuHandler Method");
        //}

        //public void SetChartType(ChartType chartType, NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetChartType Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    ManageChartTypeMenuChecking(cmd);
        //    if (objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ChangeChartType(chartType);
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetChartType Method");
        //}

        //private void ManageChartTypeMenuChecking(NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ManageChartTypeMenuChecking Method");

        //    foreach (NCommand item in ui_mnuChartsChartType.Commands)
        //    {
        //        item.Checked = false;
        //    }

        //    if (cmd != null)
        //        cmd.Checked = true;

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ManageChartTypeMenuChecking Method");
        //}

        //private void StandardChartPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into StandardChartPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.STANDARD_CHART, ui_nmunPriceTypeStandardChart);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from StandardChartPriceTypeMenuHandler Method");
        //}

        //private void HeikinAshiPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into HeikinAshiPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.HEIKIN_ASHI, ui_nmunPriceTypeHeikinAshi);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from HeikinAshiPriceTypeMenuHandler Method");
        //}

        //private void CandleVolumePriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into CandleVolumePriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.CANDLE_VOLUME, ui_nmunPriceTypeCandleVolume);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from CandleVolumePriceTypeMenuHandler Method");
        //}

        //private void EquiVolumeShadowPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into EquiVolumeShadowPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.EQUI_VOLUME_SHADOW, ui_nmunPriceTypeEquiVolumeShadow);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from EquiVolumeShadowPriceTypeMenuHandler Method");
        //}

        //private void EquiVolumePriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into EquiVolumePriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.EQUI_VOLUME, ui_nmunPriceTypeEquiVolume);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from EquiVolumePriceTypeMenuHandler Method");
        //}

        //private void ThreeLineBreakPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ThreeLineBreakPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.THREE_LINE_BREAK, ui_nmunPriceTypeThreeLineBreak);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ThreeLineBreakPriceTypeMenuHandler Method");
        //}

        //private void KagiPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into KagiPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.KAGI, ui_nmunPriceTypeKagi);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from KagiPriceTypeMenuHandler Method");
        //}

        //private void RenkoPriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into RenkoPriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.RENKO, ui_nmunPriceTypeRenko);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from RenkoPriceTypeMenuHandler Method");
        //}

        //private void PointandFigurePriceTypeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into PointandFigurePriceTypeMenuHandler Method");

        //    SetPriceType(PriceType.POINT_AND_FIGURE, ui_nmunPriceTypePointandFigure);

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from PointandFigurePriceTypeMenuHandler Method");
        //}

        //public void SetPriceType(PriceType priceType, NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SetPriceType Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    ManagePriceTypeMenuChecking(cmd);
        //    if (objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ChangePriceStyle(priceType);
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SetPriceType Method");
        //}

        //private void ManagePriceTypeMenuChecking(NCommand cmd)
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ManagePriceTypeMenuChecking Method");

        //    foreach (NCommand item in ui_mnuChartsPriceType.Commands)
        //    {
        //        item.Checked = false;
        //    }
        //    if (cmd != null)
        //        cmd.Checked = true;

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ManagePriceTypeMenuChecking Method");
        //}

        //private void Chart3DStyleMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into Chart3DStyleMenuHandler Method");

        //    //frmBase objfrmBase = ((frmBase)this.ActiveMdiChild);

        //    //if (objfrmBase == null)
        //    //return;

        //    ui_mnuChart3DStyle.Checked = !ui_mnuChart3DStyle.Checked;
        //    foreach (Form item in MdiChildren)
        //    {
        //        var objfrmBase = (frmBase)item;
        //        if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //        {
        //            ((frmNewChart)objfrmBase).Set3DStyle();
        //        }
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from Chart3DStyleMenuHandler Method");
        //}

        //private void GridMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into GridMenuHandler Method");

        //    //frmBase objfrmBase = ((frmBase)this.ActiveMdiChild);

        //    //if (objfrmBase == null)
        //    //    return;

        //    ui_mnuChartsGrid.Checked = !ui_mnuChartsGrid.Checked;

        //    foreach (Form item in MdiChildren)
        //    {
        //        var objfrmBase = (frmBase)item;
        //        if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //        {
        //            ((frmNewChart)objfrmBase).SetGridDisplay(ui_mnuChartsGrid.Checked);
        //        }
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from GridMenuHandler Method");
        //}

        //private void VolumeMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into VolumeMenuHandler Method");

        //    //frmBase objfrmBase = ((frmBase)this.ActiveMdiChild);

        //    //if (objfrmBase == null)
        //    //    return;

        //    ui_mnuChartsVolume.Checked = !ui_mnuChartsVolume.Checked;

        //    foreach (Form item in MdiChildren)
        //    {
        //        var objfrmBase = (frmBase)item;
        //        if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //        {
        //            ((frmNewChart)objfrmBase).SetVolumeDisplay();
        //        }
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from VolumeMenuHandler Method");
        //}

        //private void TrackCursorMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into TrackCursorMenuHandler Method");

        //    //frmBase objfrmBase = ((frmBase)this.ActiveMdiChild);

        //    //if (objfrmBase == null)
        //    //    return;

        //    ui_mnuChartsTrackCursor.Checked = !ui_mnuChartsTrackCursor.Checked;

        //    foreach (Form item in MdiChildren)
        //    {
        //        var objfrmBase = (frmBase)item;
        //        if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //        {
        //            ((frmNewChart)objfrmBase).TrackCursor();
        //        }
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from TrackCursorMenuHandler Method");
        //}

        //private void ZoomOutMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ZoomOutMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ZoomOut();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ZoomOutMenuHandler Method");
        //}

        //private void ZoomInMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ZoomInMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ZoomIn();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ZoomInMenuHandler Method");
        //}

        //private void SnapshotSaveMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SnapshotSaveMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).SaveChart();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SnapshotSaveMenuHandler Method");
        //}

        //private void SnapshotPrintMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SnapshotPrintMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).PrintChart();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SnapshotPrintMenuHandler Method");
        //}


        //private void IndicatorListMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into IndicatorListMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).AddIndicatorList();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from IndicatorListMenuHandler Method");
        //}


        //private void FreeHandDrawingMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into FreeHandDrawingMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).FreeHandDrawingDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from FreeHandDrawingMenuHandler Method");
        //}

        //private void RectangleMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into RectangleMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).RectangleDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from RectangleMenuHandler Method");
        //}

        //private void ErrorChannelMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into ErrorChannelMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).ErrorChannelDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from ErrorChannelMenuHandler Method");
        //}

        //private void RaffRegressionMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into RaffRegressionMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).RafRegressionDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from RaffRegressionMenuHandler Method");
        //}

        //private void QuadrentLinesMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into QuadrentLinesMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).QuadrentLinesDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from QuadrentLinesMenuHandler Method");
        //}

        //private void TironeLevelMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into TironeLevelMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).TironeLevelDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from TironeLevelMenuHandler Method");
        //}

        //private void FibonacciTimeZoneMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into FibonacciTimeZoneMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).FibonacciTimezoneDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from FibonacciTimeZoneMenuHandler Method");
        //}

        //private void FibonacciFanMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into FibonacciFanMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).FibonacciFanDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from FibonacciFanMenuHandler Method");
        //}

        //private void FibonacciRetracementMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into FibonacciRetracementMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).FibonacciRetracementDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from FibonacciRetracementMenuHandler Method");
        //}

        //private void FibonacciArcMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into FibonacciArcMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).FibonacciArcsDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from FibonacciArcMenuHandler Method");
        //}

        //private void GannFanMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into GannFanMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).GannFanDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from GannFanMenuHandler Method");
        //}

        //private void SpeedLineMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into SpeedLineMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).SpeedLineDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from SpeedLineMenuHandler Method");
        //}

        //private void EllipseMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into EllipseMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).EllipseDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from EllipseMenuHandler Method");
        //}

        //private void TrednLineMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into TrednLineMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).TrendLineDisplay();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from TrednLineMenuHandler Method");
        //}

        //private void TextMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into TextMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).AddText();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from TextMenuHandler Method");
        //}

        //private void VerticalMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into VerticalMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).AddVerticalLine();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from VerticalMenuHandler Method");
        //}

        //private void HorizontalMenuHandler()
        //{
        //   //FileHandling.WriteDevelopmentLog("Main Form : Enter into HorizontalMenuHandler Method");

        //    var objfrmBase = ((frmBase)ActiveMdiChild);

        //    if (objfrmBase == null)
        //        return;

        //    if (objfrmBase.Formkey != null && objfrmBase.Formkey.Contains("NEW_CHART"))
        //    {
        //        ((frmNewChart)objfrmBase).AddHorizontalLine();
        //    }

        //   //FileHandling.WriteDevelopmentLog("Main Form : Exit from HorizontalMenuHandler Method");
        //}

        //#endregion "  Chart Menu Handlers  "

        #region "      OBSOLETE       "

        // Obsolete
        private void ApplyHotKeySettings()
        {
            string HotKeyFile = ClsTWSUtility.GetHotKeysFileName();

            if (File.Exists(HotKeyFile))
            {
                Stream streamRead = File.OpenRead(HotKeyFile);
                var binaryRead = new BinaryFormatter();
                _hotKeySettingsHashTable = (Hashtable)binaryRead.Deserialize(streamRead);
                streamRead.Close();
                foreach (string key in _hotKeySettingsHashTable.Keys)
                {
                    int y = ui_nmnuBar.Commands.Count;
                    foreach (string x in Enum.GetNames(typeof(CommandIDS)))
                    {
                        if (key.ToLower() == x.ToLower())
                        {
                            var cid = (int)(CommandIDS)Enum.Parse(typeof(CommandIDS), key);
                            SetHotKey(key, _hotKeySettingsHashTable[key].ToString(), FindCommand(cid));
                            break;
                        }
                    }
                }
            }
            else //Prepare Hash table for Default Hot key settings 
            {
                _hotKeySettingsHashTable = new Hashtable();
                foreach (NCommand cmd in ui_nmnuBar.Commands)
                {
                    if (cmd.Commands.Count > 0)
                    {
                        foreach (NCommand cmd1 in cmd.Commands)
                        {
                            string Keyvalue = "";
                            if (cmd1.Properties.Shortcut.ToString().ToLower() == "none")
                            {
                                Keyvalue = "[NONE]";
                            }
                            else
                            {
                                Keyvalue = cmd1.Properties.Shortcut.ToString();
                            }
                            _hotKeySettingsHashTable.Add(
                                cmd1.Properties.Text.ToUpper().Trim().Replace(" ", "_"), Keyvalue);
                            if (cmd1.Commands.Count > 0)
                            {
                                foreach (NCommand cmd2 in cmd1.Commands)
                                {
                                    string Keyvalue1 = "";
                                    if (cmd2.Properties.Shortcut.ToString().ToLower() == "none")
                                    {
                                        Keyvalue1 = "[NONE]";
                                    }
                                    else
                                    {
                                        Keyvalue1 = cmd2.Properties.Shortcut.ToString();
                                    }
                                    _hotKeySettingsHashTable.Add(
                                        cmd2.Properties.Text.ToUpper().Trim().Replace(" ", "_"), Keyvalue1);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Obsolete
        private NCommand FindCommand(int cid)
        {
            NCommand c = null;
            foreach (NCommand cmd in ui_nmnuBar.Commands)
            {
                if (cmd.Properties.ID == cid)
                {
                    c = cmd;
                    break;
                }
                else if (cmd.Commands.Count > 0)
                {
                    foreach (NCommand cmd1 in cmd.Commands)
                    {
                        if (cmd1.Properties.ID == cid)
                        {
                            c = cmd1;
                            break;
                        }
                        else if (cmd1.Commands.Count > 0)
                        {
                            foreach (NCommand cmd2 in cmd1.Commands)
                            {
                                if (cmd2.Properties.ID == cid)
                                {
                                    c = cmd2;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return c;
        }

        /// <summary>
        /// Displays dialogs for user controls
        /// </summary>
        public void DisplayDialog(UctlBase uctlBase)
        {
            var objfrmCommonForm = new frmCommonForm();
            objfrmCommonForm.MdiParent = this;
            objfrmCommonForm.Controls.Clear();
            objfrmCommonForm.Controls.Add(uctlBase);
            objfrmCommonForm.Size = new Size(uctlBase.Width + 25, uctlBase.Height + 45);
            uctlBase.Dock = DockStyle.Fill;
            objfrmCommonForm.Text = uctlBase.Title;
            objfrmCommonForm.Show();
        }

        #endregion "      OBSOLETE       "

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Action A = () =>
            {
                if (frmMessageLog.count == 0)
                {
                    frmMessageLog objfrmMessageLog = new frmMessageLog(_shortcutKeyFilter);
                    objfrmMessageLog.MdiParent = this;
                    objfrmMessageLog.Show();
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


        private void INSTANCE_onMarketPriceUpdate(string ContractName)
        {
            if (clsTWSOrderManagerJSON.INSTANCE._isTradeHistoryLoaded && Properties.Settings.Default.AccountType.ToUpper().Trim() != "BROKER" && !Cls.ClsGlobal.IsTradeBookOpen)
            {
                Action A = () =>
                {
                    try
                    {
                        UrPnl = 0;
                        if (Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory, 1000))
                        {
                            try
                            {
                                DataRow[] rws = null;
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                    rws = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select("Contract = '" + ContractName + "' AND Quantity -SettledQty >0");
                                if (rws.Length > 0)
                                {
                                    foreach (DataRow rw in rws)
                                    {
                                        int qty = (Convert.ToInt32(rw["Quantity"].ToString()) - Convert.ToInt32(rw["SettledQty"].ToString()));

                                        if (qty > 0)
                                        {
                                            int index = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.IndexOf(rw);
                                            if (rw["BS"].ToString().ToUpper() == "BUY")
                                            {
                                                if (Convert.ToDouble(Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString())) > 0)
                                                {
                                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                    {
                                                        double _pnl = 0.0;
                                                        if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        else
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        rw["PnL"] = _pnl;
                                                    }
                                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                    {
                                                        double _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                        rw["PnL"] = _pnl;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString())) > 0)
                                                {
                                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                    {
                                                        double _pnl = 0.0;
                                                        if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);

                                                        }
                                                        else
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        rw["PnL"] = _pnl;
                                                    }
                                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                    {
                                                        double _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                        rw["PnL"] = _pnl;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (rw["PnL"].ToString() != "0")
                                                rw["PnL"] = 0;
                                        }
                                        rw.AcceptChanges();
                                    }
                                }

                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count > 0)
                                {
                                    if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                        UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                    else
                                    {
                                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS.DS4TradeHistory();
                                        UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                    }
                                }
                            }

                            finally
                            {
                                Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                            }

                            double balance = 0;
                            double margin = 0;
                            if (tlsBalanceValue.Text != string.Empty)
                                balance = Convert.ToDouble(tlsBalanceValue.Text);
                            if (tlsMarginValue.Text != string.Empty)
                            {
                                margin = Convert.ToDouble(tlsMarginValue.Text);
                                lblUsedMargin.Visible = true;
                                lblMarginLevel.Visible = true;
                                tlsMarginValue.Visible = true;
                                tlsMarginLevelValue.Visible = true;
                            }
                            else
                            {
                                lblUsedMargin.Visible = false;
                                lblMarginLevel.Visible = false;
                                tlsMarginValue.Visible = false;
                                tlsMarginLevelValue.Visible = false;
                            }
                            lblPL.Text = Math.Round(UrPnl, 2).ToString("0.00");
                            tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                            tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) - margin, 2));
                            if (margin == 0)
                            {
                                tlsMarginLevelValue.Text = "";
                            }
                            else
                            {
                                tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) / margin * 100, 2));
                            }

                        }
                    }
                    catch
                    {
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

        }

    }
}

