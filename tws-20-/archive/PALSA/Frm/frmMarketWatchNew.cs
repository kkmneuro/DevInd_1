///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//13/02/2012	VP		    1.Code for displaying buy and sell OrderEntry dialog from frmMarketWatch
//                          2.code Pull data in order entry (buy/sell) from selected record of order entry while it opens from market watch
//17/02/2012    VP          1.code to add a Product to active Market Watch correcsponding to Selected products from FilterBar
//05/03/2012	VP          1.Code for Setting Default column profile
//1 July 2014	Namo		sorting of grid data on expiry date is removed
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;
using TWS.DS;
using ClsGlobal = TWS.Cls.ClsGlobal;

namespace TWS.Frm
{
    public partial class frmMarketWatchNew : frmBase
    {
        #region "         MEMBERS         "

        private static int count;
        private readonly DS4MarketWatch marketDS = new DS4MarketWatch();
        //private readonly frmOrderEntry objfrmOrderEntry = new frmOrderEntry();
        private string _formkey;
        private object _objPortfolio;
        private object _objProfiles;
        private string _userCode = string.Empty;
        private Keys _shortcutKeyMarketPicture = Keys.None;
        private Timer tm;
        private string currentPortfolio = string.Empty;

        #endregion "     MEMBERS         "

        #region "       PROPERTIES       "

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public static int Count
        {
            get { return count; }
        }

        public Keys ShortcutKeyBOE { get; set; }

        public Keys ShortcutKeySOE { get; set; }

        public Keys ShortcutKeyMarketPicture
        {
            get { return _shortcutKeyMarketPicture; }
            set { _shortcutKeyMarketPicture = value; }
        }

        public object ObjPortfolio
        {
            get { return _objPortfolio; }
            set { _objPortfolio = value; }
        }

        #endregion "      PROPERTIES       "

        private Dictionary<string, clsSavedMW> ddSavedMW;

        // private object _SavedMY;

        #region "        CONSTRUCTOR         "

        public frmMarketWatchNew(object objPortfolio, object objProfiles, string portfolioName, string profileName, string userCode)
        {
            count += 1;
            _userCode = userCode;

            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(tm_Tick);
            _objPortfolio = objPortfolio;
            _objProfiles = objProfiles;
            InitializeComponent();
            uctlMarketWatch1.Portfolios = _objPortfolio;
            uctlMarketWatch1.Profiles = objProfiles;
            uctlMarketWatch1.CurrentPortfolioName = portfolioName;
            uctlMarketWatch1.CurrentProfileName = profileName;
            uctlMarketWatch1.ui_ndgvMarketWatch.EnableCellCustomDraw = false;
            _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlMarketWatch1.CurrentPortfolioName + "/" + uctlMarketWatch1.CurrentProfileName;

            if (uctlMarketWatch1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlMarketWatch1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.MarketWatchProfile + "_" + ProfileTypes.MarketWatch.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.MarketWatchProfile + "_" + ProfileTypes.MarketWatch.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
                }
            }

            object _SavedMY = GetSavedMarketWatch(_userCode);
            if (_SavedMY != null && ((Dictionary<string, clsSavedMW>)_SavedMY).Keys.Count > 0)
            {
                try
                {
                    uctlMarketWatch1.SavedWorkSpace = ((Dictionary<string, clsSavedMW>)_SavedMY).Keys.ToList();
                    ddSavedMW = (Dictionary<string, clsSavedMW>)_SavedMY;
                }
                catch (Exception)
                {

                }
            }
        }

        public object GetSavedMarketWatch(string UserCode)
        {
            object objSavedMArketWatch = null;

            if (File.Exists(ClsTWSUtility.GetMarketWatchFileName(UserCode)))
            {
                FileStream streamRead = File.OpenRead(ClsTWSUtility.GetMarketWatchFileName(UserCode));

                var binaryRead = new BinaryFormatter();
                objSavedMArketWatch = binaryRead.Deserialize(streamRead);
                streamRead.Close();
            }

            return objSavedMArketWatch;
        }

        private void frmMarketWatchNew_Load(object sender, EventArgs e)
        {

            var ContextMenuItems = new ToolStripMenuItem[6];
            ResizeRedraw = false;
            Width = MdiParent.Width - 20;
            MainMenuStrip = MdiParent.MainMenuStrip;
            ContextMenuItems[0] = new ToolStripMenuItem("Save MarketWatch");
            ContextMenuItems[0].Name = "SaveMarketWatch";
            ContextMenuItems[0].ToolTipText = "Save MarketWatch";
            ContextMenuItems[0].Enabled = false;
            ContextMenuItems[0].ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            ContextMenuItems[0].Click += OnMarketWatchSaveClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Buy Order");
            ContextMenuItems[1].Name = "BuyOrder";
            ContextMenuItems[1].Enabled = false;
            ContextMenuItems[1].ShortcutKeys = ShortcutKeyBOE;
            ContextMenuItems[1].Click += OnBuyOrderClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Sell Order");
            ContextMenuItems[2].Name = "SellOrder";
            ContextMenuItems[2].Enabled = false;
            ContextMenuItems[2].ShortcutKeys = ShortcutKeySOE;
            ContextMenuItems[2].Click += OnSellOrderClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Market Picture");
            ContextMenuItems[3].Name = "MarketPicture";
            ContextMenuItems[3].Enabled = false;
            ContextMenuItems[3].Click += OnMarketPictureClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Delete Row");
            ContextMenuItems[4].Name = "RemoveSymbol";
            ContextMenuItems[4].Enabled = false;
            ContextMenuItems[4].ShortcutKeys = Keys.Delete;
            ContextMenuItems[4].ShortcutKeyDisplayString = "Delete";
            ContextMenuItems[4].Click += OnRemoveSymbolClick;
            ContextMenuItems[5] = new ToolStripMenuItem("Insert Row");
            ContextMenuItems[5].Name = "InsertRow";
            ContextMenuItems[5].ToolTipText = "Insert a blank row";
            ContextMenuItems[5].Enabled = false;
            ContextMenuItems[5].ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter)));
            ContextMenuItems[5].Click += OnInsertRowClick;

            Title = uctlMarketWatch1.Title + " - " + uctlMarketWatch1.CurrentPortfolioName;

            DoubleBuffered(uctlMarketWatch1.ui_ndgvMarketWatch, true);
            if (uctlMarketWatch1.CurrentPortfolioName != string.Empty)
            {
                uctlMarketWatch1_OnScriptPortfolioApplyClick(uctlMarketWatch1.CurrentPortfolioName);
            }
            else if (_objPortfolio != null && ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().Contains(Properties.Settings.Default.MarketWatchPortfolio))
                {
                    int index =
                        ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().IndexOf(Properties.Settings.Default.MarketWatchPortfolio);
                    uctlMarketWatch1_OnScriptPortfolioApplyClick(((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList()[index]);
                }
            }
            uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items.AddRange(ContextMenuItems);
            uctlMarketWatch1.ui_ndgvMarketWatch.MouseMove += new MouseEventHandler(grdCons_MouseMove);
            uctlMarketWatch1.ui_ndgvMarketWatch.MouseDown += new MouseEventHandler(grdCons_MouseDown);
            uctlMarketWatch1.ui_ndgvMarketWatch.DragOver += new DragEventHandler(grdCons_DragOver);

            uctlMarketWatch1.ui_ndgvMarketWatch.DataSource = marketDS.dtMarketWatch;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += marketWatch_onSnapShotUpdate;
            tm.Enabled = true;
        }

        #endregion "        CONSTRUCTOR         "

        private void frmMarketWatchNew_Resize(object sender, EventArgs e)
        {
            uctlMarketWatch1.Width = Size.Width;
            uctlMarketWatch1.Height = Size.Height;
        }

        private void frmMarketWatchNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uctlMarketWatch1.ui_ndgvMarketWatch.RowCount > 0)
            {

                DialogResult result = ClsCommonMethods.ShowMessageBox("Do you want to save market watch?");
                if (result == DialogResult.Yes)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = marketDS.dtMarketWatch.Copy();
                    frmMarketWatchSave objFrmSave = new frmMarketWatchSave(ddSavedMW, _userCode, dtTemp, Properties.Settings.Default.DefaultFontSize);
                    objFrmSave.OnMarketWatchSaveClick -= new Action<Dictionary<string, clsSavedMW>>(objFrmSave_OnMarketWatchSaveClick);
                    objFrmSave.OnMarketWatchSaveClick += new Action<Dictionary<string, clsSavedMW>>(objFrmSave_OnMarketWatchSaveClick);
                    objFrmSave.StartPosition = FormStartPosition.CenterScreen;
                    objFrmSave.ShowDialog();
                }
            }
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
        }

        private void frmMarketWatchNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlMarketWatch1.CurrentPortfolioName + "/" + uctlMarketWatch1.CurrentProfileName;
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void ApplySnapShot(List<Symbol> lst)
        {

            foreach (var item in lst)
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;

                DataRow row = null;
                if (uctlMarketWatch1._DDRows.TryGetValue(item.Contract, out row))
                {
                    string contract = item.KEY.Substring(item.KEY.LastIndexOf('_') + 1);
                    if (ClsGlobal.DDRightZLevel.Keys.Contains(contract))
                    {
                        row["SellPrice"] = ClsGlobal.DDRightZLevel[contract].ToString();
                        if (ClsGlobal.DDRightZLevelQty.Keys.Contains(contract))
                        {
                            row["SellQty"] = ClsGlobal.DDRightZLevelQty[contract].ToString("0.00");
                        }
                    }
                    else
                    {
                        row["SellPrice"] = "0.00";
                        row["SellQty"] = "0.00";
                    }
                    if (ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
                    {
                        row["BuyPrice"] = ClsGlobal.DDLeftZLevel[contract].ToString();
                        if (ClsGlobal.DDLeftZLevelQty.Keys.Contains(contract))
                        {
                            row["BuyQty"] = ClsGlobal.DDLeftZLevelQty[contract].ToString("0.00");
                        }
                    }
                    else
                    {
                        row["BuyPrice"] = "0.00";
                        row["BuyQty"] = "0.00";
                    }
                    if (ClsGlobal.DDClose.Keys.Contains(contract))
                    {
                        row["ClosePrice"] = ClsGlobal.DDClose[contract].ToString();
                    }
                    else
                    {
                        row["ClosePrice"] = "0.00";
                    }
                    if (ClsGlobal.DDHigh.Keys.Contains(contract))
                    {
                        row["High"] = ClsGlobal.DDHigh[contract].ToString();
                        row["PrevHigh"] = ClsGlobal.DDHigh[contract].ToString();
                    }
                    else
                    {
                        row["High"] = "0.00";
                        row["PrevHigh"] = "0.00";
                    }
                    if (ClsGlobal.DDLTP.Keys.Contains(contract))
                    {
                        row["LTP"] = ClsGlobal.DDLTP[contract].ToString();
                    }
                    else
                    {
                        row["LTP"] = "0.00";
                    }
                    if (ClsGlobal.DDLTP.Keys.Contains(contract) && ClsGlobal.DDClose.Keys.Contains(contract))
                    {
                        row["NetChange"] = (ClsGlobal.DDLTP[contract] - ClsGlobal.DDClose[contract]).ToString();
                    }
                    else
                    {
                        row["NetChange"] = "0.00";
                    }
                    DateTime dtx = DateTime.Now;
                    row["LastUpdatedTime"] = dtx;
                    if (ClsGlobal.DDLow.Keys.Contains(contract))
                    {
                        row["Low"] = ClsGlobal.DDLow[contract].ToString();
                        row["PrevLow"] = ClsGlobal.DDLow[contract].ToString();
                    }
                    else
                    {
                        row["Low"] = "0.00";
                    }
                    if (ClsGlobal.DDOpen.Keys.Contains(contract))
                    {
                        row["OpenPrice"] = ClsGlobal.DDOpen[contract].ToString();
                    }
                    else
                    {
                        row["OpenPrice"] = "0.00";
                    }
                    if (ClsGlobal.DDVolume.Keys.Contains(contract))
                    {
                        row["Volume"] = ClsGlobal.DDVolume[contract];
                    }
                    else
                    {
                        row["Volume"] = 0;
                    }
                }

            }

        }


        public void marketWatch_onSnapShotUpdate(SnapShot _QuoteSnapshot)
        {

            foreach (var item in _QuoteSnapshot.OHLC)
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;

                Action A = () =>
                {
                    DataRow row = null;
                    //item.BidPrice / Math.Pow(10, spec.Digits)
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item.Contract))
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[item.Contract];
                        if (uctlMarketWatch1._DDRows.TryGetValue(item.Contract, out row))
                        {
                            if (ClsGlobal.DDRightZLevel.Keys.Contains(item.Contract))
                            {
                                row["SellPrice"] = ClsGlobal.DDRightZLevel[item.Contract].ToString();
                                if (ClsGlobal.DDRightZLevelQty.Keys.Contains(item.Contract))
                                {
                                    row["SellQty"] = ClsGlobal.DDRightZLevelQty[item.Contract].ToString("0.00");
                                }
                            }
                            if (ClsGlobal.DDLeftZLevel.Keys.Contains(item.Contract))
                            {
                                row["BuyPrice"] = ClsGlobal.DDLeftZLevel[item.Contract].ToString();
                                if (ClsGlobal.DDLeftZLevelQty.Keys.Contains(item.Contract))
                                {
                                    row["BuyQty"] = ClsGlobal.DDLeftZLevelQty[item.Contract].ToString("0.00");
                                }
                            }
                            row["ClosePrice"] = (item.Close / Math.Pow(10, spec.Digits)).ToString();// item.Close.ToString("0.00");
                            row["PrevHigh"] = (item.High / Math.Pow(10, spec.Digits)).ToString();// item.High.ToString("0.00");
                            row["High"] = (item.High / Math.Pow(10, spec.Digits)).ToString();// item.High.ToString("0.00");
                            row["LTP"] = (item.LastPrice / Math.Pow(10, spec.Digits)).ToString();//  item.LastPrice.ToString("0.00");

                            DateTime dtx = DateTime.Now;
                            string date = string.Empty;

                            //DateTime.TryParse(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(Convert.ToString(item.LastUpdatedTime)), out dtx);


                            dtx = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromOAdate(item.LastUpdatedTime);
                            // DateTime.TryParse(date, out dtx);
                            row["LastUpdatedTime"] = dtx;
                            row["PrevLow"] = (item.Low / Math.Pow(10, spec.Digits)).ToString();//  item.Low.ToString("0.00");
                            row["Low"] = (item.Low / Math.Pow(10, spec.Digits)).ToString();// item.Low.ToString("0.00");
                            row["OpenPrice"] = (item.Open / Math.Pow(10, spec.Digits)).ToString();//  item.Open.ToString("0.00");
                            row["Volume"] = item.Volume;

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
        }

        public void marketWatch_onPriceUpdate(QuotesStream _QuotesStream)
        {
            if (uctlMarketWatch1._DDRows.Count == 0)
                return;
            foreach (var quotes in _QuotesStream.QuotesItem)
            {
                try
                {
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(quotes.Contract) && quotes.MarketLevel == 0)
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[quotes.Contract];
                        DataRow row = null;
                        SuspendLayout();
                        if (uctlMarketWatch1._DDRows.TryGetValue(quotes.Contract, out row))
                        {
                            int index = marketDS.dtMarketWatch.Rows.IndexOf(row);

                            double _time = 0;
                            double.TryParse(quotes.Time, out _time);
                            marketDS.dtMarketWatch.Rows[index]["LastUpdatedTime"] = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromOAdate(_time);

                            long _size = quotes.Size;
                            if (spec != null && spec.ContractSize > 0)
                            {
                                _size = (long)(quotes.Size / spec.ContractSize);
                            }
                            double _Price = quotes.Price / Math.Pow(10, spec.Digits);
                            switch (quotes.QuotesStreamType)
                            {
                                case "C":
                                    {
                                        //marketDS.dtMarketWatch.Rows[index]["ClosePrice"] = Convert.ToDecimal(_Price).ToString("0.00");
                                        marketDS.dtMarketWatch.Rows[index]["ClosePrice"] = Convert.ToDecimal(_Price).ToString();
                                    }
                                    break;
                                case "O":
                                    {
                                        marketDS.dtMarketWatch.Rows[index]["OpenPrice"] = Convert.ToDecimal(_Price).ToString();
                                    }
                                    break;
                                case "A":
                                    {
                                        long prevSize = 0;
                                        double prevPrice = 0;
                                        double.TryParse(marketDS.dtMarketWatch.Rows[index]["SellPrice"].ToString().Trim(), out prevPrice);
                                        long.TryParse(marketDS.dtMarketWatch.Rows[index]["SellQty"].ToString().Trim(), out prevSize);
                                        //marketDS.dtMarketWatch.Rows[index]["SellPrice"] = Convert.ToDecimal(_Price).ToString("0.00");
                                        marketDS.dtMarketWatch.Rows[index]["SellPrice"] = Convert.ToDecimal(_Price).ToString();
                                        marketDS.dtMarketWatch.Rows[index]["SellQty"] = _size.ToString("0.00");
                                        if (_size > prevSize)
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.UpTrendColor;

                                        }
                                        else if (_size < prevSize)
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                        }

                                        if (prevPrice > _Price) //Down
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                        }
                                        else if (prevPrice < _Price) //UP
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                        }

                                    }
                                    break;
                                case "B":
                                    {

                                        long prevSize = 0;
                                        double prevPrice = 0;
                                        double.TryParse(marketDS.dtMarketWatch.Rows[index]["BuyPrice"].ToString().Trim(), out prevPrice);
                                        long.TryParse(marketDS.dtMarketWatch.Rows[index]["BuyQty"].ToString().Trim(), out prevSize);
                                        //marketDS.dtMarketWatch.Rows[index]["BuyPrice"] = Convert.ToDecimal(_Price).ToString("0.00");
                                        marketDS.dtMarketWatch.Rows[index]["BuyPrice"] = Convert.ToDecimal(_Price).ToString();
                                        marketDS.dtMarketWatch.Rows[index]["BuyQty"] = _size.ToString("0.00");

                                        if (_size > prevSize)
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                        }
                                        else if (_size < prevSize)
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                        }
                                        if (prevPrice > _Price) //Down
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                        }
                                        else if (prevPrice < _Price) //UP
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                        }

                                    }
                                    break;
                                case "H":
                                    {
                                        marketDS.dtMarketWatch.Rows[index]["High"] = Convert.ToDecimal(_Price).ToString();
                                    }
                                    break;
                                case "L":
                                    {
                                        double prevPrice = 0;
                                        double.TryParse(marketDS.dtMarketWatch.Rows[index]["LTP"].ToString().Trim(), out prevPrice);
                                        //marketDS.dtMarketWatch.Rows[index]["LTP"] = Convert.ToDecimal(_Price).ToString("0.00");
                                        marketDS.dtMarketWatch.Rows[index]["LTP"] = Convert.ToDecimal(_Price).ToString();

                                        if (prevPrice > _Price) //Down
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                                Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                                        }
                                        else if (prevPrice < _Price) //UP
                                        {
                                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                                Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                                        }

                                        if (marketDS.dtMarketWatch.Rows[index]["LTP"] != null && marketDS.dtMarketWatch.Rows[index]["ClosePrice"] != null)
                                        {
                                            decimal ltp = Convert.ToDecimal(_Price) - Convert.ToDecimal(marketDS.dtMarketWatch.Rows[index]["ClosePrice"]);
                                            //marketDS.dtMarketWatch.Rows[index]["NetChange"] = ltp.ToString("0.00");
                                            marketDS.dtMarketWatch.Rows[index]["NetChange"] = ltp.ToString();
                                            if (ltp < 0)
                                            {

                                                uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmNetChange"].Style.BackColor
                                                   = uctlMarketWatch1.DownTrendColor;
                                            }
                                            else
                                            {

                                                uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Cells["ClmNetChange"].Style.BackColor
                                                   = uctlMarketWatch1.UpTrendColor;
                                            }
                                        }
                                        else
                                            marketDS.dtMarketWatch.Rows[index]["NetChange"] = "0.00";
                                    }
                                    break;
                                case "M":
                                    {
                                        marketDS.dtMarketWatch.Rows[index]["Low"] = Convert.ToDecimal(_Price).ToString();
                                    }
                                    break;
                                case "V":
                                    {
                                        marketDS.dtMarketWatch.Rows[index]["Volume"] = _size;
                                    }
                                    break;
                                case "P":
                                    {
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }
                catch (Exception)
                {

                }
            }

        }

        void tm_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count; i++)
            {
                try
                {
                    string lut = uctlMarketWatch1.ui_ndgvMarketWatch.Rows[i].Cells["ClmLastUpdatedTime"].Value.ToString();
                    if (lut != null && lut.Trim() != "")
                    {
                        DateTime _lut = DateTime.Now;
                        DateTime.TryParse(lut, out _lut);
                        TimeSpan tmpTime = DateTime.Now - _lut;
                        if (tmpTime.TotalSeconds >= 7)
                        {
                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[i].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.ui_ndgvMarketWatch.DefaultCellStyle.BackColor;
                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[i].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.ui_ndgvMarketWatch.DefaultCellStyle.BackColor;
                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[i].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.ui_ndgvMarketWatch.DefaultCellStyle.BackColor;
                            uctlMarketWatch1.ui_ndgvMarketWatch.Rows[i].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.ui_ndgvMarketWatch.DefaultCellStyle.BackColor;
                        }
                    }

                }
                catch (Exception)
                {
                }
            }

        }

        private void ApplyDefaultProfile(string profileName)
        {
            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlMarketWatch1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
            foreach (DataGridViewColumn col in uctlMarketWatch1.ui_ndgvMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

        }

        public void ReactivateMarketWatch(List<Symbol> symbolLst)
        {
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -=
               marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -=
                marketWatch_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate +=
               marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate +=
                marketWatch_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, symbolLst);
        }

        private void OnProfileApplyClick(string profileName)
        {
            if (
                !((Dictionary<string, ClsProfile>)_objProfiles).Keys.Contains(profileName + "_" +
                                                                               ProfileTypes.MarketWatch.ToString()))
                return;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.MarketWatch.ToString()];
            foreach (DataGridViewColumn col in uctlMarketWatch1.ui_ndgvMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

        }

        /// <summary>
        /// Called when user select the BuyOrder option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBuyOrderClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnBuyOrderClick Method");

            if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0];
                DisplayOrderEntryDialog("BUY", Properties.Settings.Default.BuyOrderColor, "Buy Order Entry",
                                        CommandIDS.PLACE_BUY_ORDER.ToString(), selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnBuyOrderClick Method");
        }

        /// <summary>
        /// Called when user select the SellOrder option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSellOrderClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnSellOrderClick Method");


            if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {

                DataGridViewRow selectedRow = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0];
                DisplayOrderEntryDialog("SELL", Properties.Settings.Default.SellOrderColor, "Sell Order Entry",
                                        CommandIDS.PLACE_SELL_ORDER.ToString(), selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnSellOrderClick Method");
        }


        private void setGridRowHeight()
        {
            //if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize > 8)
            //{
            //    if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize < 24)
            //    {
            //        CommonLibrary.UserControls.UctlMarketWatch.GridFontSize = 19;
            //    }
            //    foreach (DataGridViewRow row in uctlMarketWatch1.ui_ndgvMarketWatch.Rows)
            //    {
            //        row.Height = Convert.ToInt32(CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 4);
            //    }
            //}
        }


        /// <summary>
        /// Called when user select the Market Picture option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void OnMarketPictureClick(object sender, EventArgs e)
        {

            if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0];
                DisplayMarketPictureDialog(selectedRow);
            }
        }

        private void uctlMarketWatch1_OnScriptPortfolioApplyClick(string portfolioName)
        {
            try
            {
                if (portfolioName != string.Empty)
                {
                    Title = uctlMarketWatch1.Title + " - " + portfolioName;
                    _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName +
                               "/" + uctlMarketWatch1.CurrentProfileName;
                    if (((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Contains(portfolioName))
                    {
                        currentPortfolio = portfolioName;
                        ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)_objPortfolio)[portfolioName];
                        marketDS.dtMarketWatch.Rows.Clear();
                        uctlMarketWatch1.ui_ndgvMarketWatch.DataSource = marketDS.dtMarketWatch;
                        uctlMarketWatch1._DDRows.Clear();
                        int keycount = objPortfolio.Products.Keys.Count;
                        var lst = new List<Symbol>();
                        foreach (string key in objPortfolio.Products.Keys)
                        {
                            Symbol sym = Symbol.GetSymbol(key);
                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(sym.Contract))
                            {
                                InstrumentSpec inspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                                DataRow dr = marketDS.dtMarketWatch.NewRow();
                                marketDS.dtMarketWatch.Rows.Add(dr);
                                int index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                                uctlMarketWatch1._DDRows.Add(sym.Contract, marketDS.dtMarketWatch.Rows[index]);

                                marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                                marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = sym.KEY;
                                marketDS.dtMarketWatch.Rows[index]["ProductType"] = inspec.ProductType;
                                marketDS.dtMarketWatch.Rows[index]["ULAsset"] = inspec.UL_Asset;
                                marketDS.dtMarketWatch.Rows[index]["ProductName"] = inspec.Product;
                                DateTime exp = DateTime.Now;
                                DateTime.TryParse(inspec.ExpiryDate, out exp);
                                marketDS.dtMarketWatch.Rows[index]["Expiry"] = exp.ToString("dd/MM/yyyy"); ;
                                marketDS.dtMarketWatch.Rows[index]["StrikePrice"] = 0;
                                marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                                marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] = inspec.PriceQuantity.ToString();
                                lst.Add(sym);
                                if (!ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                                {
                                    ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                                }
                            }
                        }

                        ApplySnapShot(lst);
                        //marketDS.dtMarketWatch.DefaultView.Sort = "ContractName asc";
                        //marketDS.dtMarketWatch.AcceptChanges();
                        if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                        {
                            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lst);
                            ClsGlobal._isFirstRequest = false;
                        }
                        else
                            ClsCommonMethods.ShowErrorBox("Data Manager is not Connected.");
                    }
                    else
                    {
                        ClsCommonMethods.ShowErrorBox("Portfolio *" + portfolioName + "* is not found.");
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void uctlMarketWatch1_OnMarketWatchLoadClick(string obj)
        {
            try
            {
                if (ddSavedMW != null && ddSavedMW.ContainsKey(obj))
                {
                    DataTable dttemp = new DataTable();
                    dttemp = ddSavedMW[obj].MWDataTable.Copy();
                    uctlMarketWatch1._DDRows.Clear();
                    marketDS.dtMarketWatch.Rows.Clear();

                    var lst = new List<Symbol>();

                    foreach (DataRow rw in dttemp.Rows)
                    {
                        try
                        {
                            if (rw["InstrumentId"].ToString().Trim() != "")
                            {
                                Symbol sym = Symbol.GetSymbol(rw["InstrumentId"].ToString());
                                InstrumentSpec inspec = null;
                                //InstrumentSpec inspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym._ContractName, sym._ProductType, sym._ProductName);
                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(sym.Contract))
                                {
                                    inspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                                }

                                if (inspec != null)
                                {
                                    DataRow dr = marketDS.dtMarketWatch.NewRow();
                                    marketDS.dtMarketWatch.Rows.Add(dr);
                                    int index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                                    uctlMarketWatch1._DDRows.Add(sym.Contract, marketDS.dtMarketWatch.Rows[index]);

                                    if (inspec != null)
                                    {
                                        marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                                        marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = sym.KEY;
                                        marketDS.dtMarketWatch.Rows[index]["ProductType"] = inspec.ProductType;
                                        marketDS.dtMarketWatch.Rows[index]["ULAsset"] = inspec.UL_Asset;
                                        marketDS.dtMarketWatch.Rows[index]["ProductName"] = inspec.Product;
                                        //DateTime exp = Convert.ToDateTime(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(inspec.ExpiryDate)).Date;
                                        DateTime exp = DateTime.Now;
                                        DateTime.TryParse(inspec.ExpiryDate, out exp);
                                        marketDS.dtMarketWatch.Rows[index]["Expiry"] = exp.ToString("dd/MM/yyyy"); ;
                                        marketDS.dtMarketWatch.Rows[index]["StrikePrice"] = 0;
                                        marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                                        marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] =
                                            Convert.ToString(inspec.PriceQuantity);
                                        lst.Add(sym);
                                        if (!TWS.Cls.ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                                        {
                                            TWS.Cls.ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                marketDS.dtMarketWatch.Rows.InsertAt(marketDS.dtMarketWatch.NewRow(), dttemp.Rows.IndexOf(rw));
                            }
                        }
                        catch (Exception)
                        {
                            // MessageBox.Show(ex.Message);
                        }
                    }

                    ApplySnapShot(lst);

                    if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                    {
                        clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lst);

                        TWS.Cls.ClsGlobal._isFirstRequest = false;
                    }
                    else
                        ClsCommonMethods.ShowErrorBox("Data Manager is not Connected.");

                    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                    //Properties.Settings.Default.DefaultFontSize = tmpObj.FontSize;
                    dataGridViewCellStyle2.Font = new System.Drawing.Font(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.FontFamily.Name, ddSavedMW[obj].FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
                    dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
                    uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;
                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersHeight = Convert.ToInt32(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size + 13);
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }

        }

        frmPortfolio objfrmPortfolio;
        private void uctlMarketWatch1_OnScriptPortfolioModifyClick(string portfolioName)
        {
            objfrmPortfolio = new frmPortfolio(_objPortfolio, portfolioName, _userCode);
            objfrmPortfolio.OnSavePortfolio -= objfrmPortfolio_OnSavePortfolio;
            objfrmPortfolio.OnSavePortfolio += objfrmPortfolio_OnSavePortfolio;
            objfrmPortfolio.ShowDialog();
        }

        private void objfrmPortfolio_OnSavePortfolio(string potfolioName)
        {
            if (objfrmPortfolio != null)
            {
                objfrmPortfolio.Close();
                if (currentPortfolio == potfolioName)
                {
                    uctlMarketWatch1_OnScriptPortfolioApplyClick(potfolioName);
                }
                // CommonLibrary.Cls.ClsCommonMethods.ShowInformation("Porfolio Saved successfully.");
            }

        }

        private void uctlMarketWatch1_OnScriptPortfolioRemoveClick(string portfolioName)
        {
            ((Dictionary<string, ClsPortfolio>)_objPortfolio).Remove(portfolioName);

        }

        private void uctlMarketWatch1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnProfileRemoveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnProfileRemoveClick Method");
        }

        private void uctlMarketWatch1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnSetDefaultProfileClick Method");

            Properties.Settings.Default.MarketWatchProfile = profileName; //by vijay
            Properties.Settings.Default.Save(); //by vijay
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            Properties.Settings.Default.MarketWatchProfile = profileName;
            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            streamWrite.Close();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnSetDefaultProfileClick Method");
        }

        private void uctlMarketWatch1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnProfileSaveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnProfileSaveClick Method");
        }

        private void uctlMarketWatch1_OnUpDownTrendColorChanged(Color upColor, Color downColor, Color alertTriggerColor)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnUpDownTrendColorChanged Method");

            Properties.Settings.Default.UpTrendColor = upColor;
            Properties.Settings.Default.DownTrendColor = downColor;
            Properties.Settings.Default.AlertTriggerColor = alertTriggerColor;

            Properties.Settings.Default.Save();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnUpDownTrendColorChanged Method");
        }

        private void uctlMarketWatch1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {

            DataGridView.HitTestInfo hitTestInfo = uctlMarketWatch1.ui_ndgvMarketWatch.HitTest(arg2.X, arg2.Y);
            if (uctlMarketWatch1.ui_ndgvMarketWatch.RowCount > 0)
            {
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["SaveMarketWatch"].Enabled = true;
            }
            else
            {
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["SaveMarketWatch"].Enabled = false;
            }

            if (hitTestInfo.RowIndex < 0)
            {


                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = false;
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = false;
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = false;
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = false;
                uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["InsertRow"].Enabled = false;

            }
            else
            {
                if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count > 0)
                {
                    if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() == "")
                    {
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = false;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = false;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = false;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = false;

                    }
                    else
                    {

                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = true;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = true;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = true;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = true;

                    }
                    uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["InsertRow"].Enabled = true;
                    uctlMarketWatch1.ui_ndgvMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = true;
                }

            }
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey,
                                             DataGridViewRow selectedRow)
        {

            if (frmOrderEntry.INSTANCE.IsDisposed)
            {
                frmOrderEntry.INSTANCE = new frmOrderEntry(selectedRow, CommonLibrary.Cls.ClsGlobal.OrderMode.NEW);
                frmOrderEntry.INSTANCE.Formkey = formKey;
                frmOrderEntry.INSTANCE.FormText = formTitle;
                frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
                frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
                frmOrderEntry.INSTANCE.MdiParent = MdiParent;
                frmOrderEntry.INSTANCE.Show();
                frmOrderEntry.INSTANCE.FillValues(selectedRow);
            }
            else
            {
                frmOrderEntry.INSTANCE.Formkey = formKey;
                frmOrderEntry.INSTANCE.FormText = formTitle;
                frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
                frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
                frmOrderEntry.INSTANCE.MdiParent = MdiParent;
                frmOrderEntry.INSTANCE.Show();
                frmOrderEntry.INSTANCE.FillValues(selectedRow);
                frmOrderEntry.INSTANCE.Activate();
            }

        }

        private void DisplayMarketPictureDialog(DataGridViewRow selectedRow)
        {
            if (frmMarketPictureNew.Count < 4)
            {
                var objMarketPicture = new frmMarketPictureNew();
                objMarketPicture.StartPosition = FormStartPosition.CenterScreen;
                objMarketPicture.MdiParent = ParentForm;
                objMarketPicture.SetValuesToMarketPicture(selectedRow);
                objMarketPicture.Show();
            }
        }

        public void AddRowToMarketWatch(string key, InstrumentSpec objInstrumentSpec)
        {
            var lst = new List<Symbol>();

            var sym = Symbol.GetSymbol(key);
            int index = 0;
            if (!uctlMarketWatch1._DDRows.ContainsKey(sym.Contract))
            {
                var dr = marketDS.dtMarketWatch.NewRow();
                if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count > 0)
                {
                    index = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index;
                    marketDS.dtMarketWatch.Rows.InsertAt(dr, index);
                }
                else
                {
                    marketDS.dtMarketWatch.Rows.Add(dr);
                }
                //var index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                uctlMarketWatch1._DDRows.Add(sym.Contract, marketDS.dtMarketWatch.Rows[index]);
                if (objInstrumentSpec != null)
                {
                    marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                    marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = key;
                    marketDS.dtMarketWatch.Rows[index]["ProductType"] = objInstrumentSpec.ProductType;
                    marketDS.dtMarketWatch.Rows[index]["ULAsset"] = objInstrumentSpec.UL_Asset;
                    marketDS.dtMarketWatch.Rows[index]["ProductName"] = objInstrumentSpec.Product;
                    DateTime exp = DateTime.Now;
                    DateTime.TryParse(objInstrumentSpec.ExpiryDate, out exp);
                    marketDS.dtMarketWatch.Rows[index]["Expiry"] = exp.ToString("dd/MM/yyyy");
                    marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                    marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] = objInstrumentSpec.PriceQuantity.ToString();
                    marketDS.dtMarketWatch.Rows[index]["Specification"] = objInstrumentSpec.Specification;

                    lst.Add(sym);
                    if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize > 8)
                    {
                        if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize < 24)
                        {
                            CommonLibrary.UserControls.UctlMarketWatch.GridFontSize = 19;
                        }
                        foreach (DataGridViewRow row in uctlMarketWatch1.ui_ndgvMarketWatch.Rows)
                        {
                            row.Height = Convert.ToInt32(CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 4);
                        }
                    }
                }
                if (!ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                {
                    ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                }
                ApplySnapShot(lst);
                //marketDS.dtMarketWatch.DefaultView.Sort = "ContractName asc";
                //marketDS.dtMarketWatch.AcceptChanges();
                clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE, lst);

                //marketDS.dtMarketWatch.Rows[index].
            }
            else
            {
                try
                {
                    var dr = uctlMarketWatch1._DDRows[sym.Contract];
                    index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                }
                catch (Exception)
                {

                }

            }
            if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows.Count > 0)
            {
                uctlMarketWatch1.ui_ndgvMarketWatch.ClearSelection();
                uctlMarketWatch1.ui_ndgvMarketWatch.Rows[index].Selected = true;
                uctlMarketWatch1.ui_ndgvMarketWatch.FirstDisplayedScrollingRowIndex = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index;
                uctlMarketWatch1.ui_ndgvMarketWatch.Refresh();
            }
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from AddRowToMarketWatch Method");
        }

        private void SaveProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into SaveProfile Method");

            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            uctlMarketWatch1.CurrentProfileName = profileName;
            _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlMarketWatch1.CurrentPortfolioName + "/" + profileName;
            streamWrite.Close();

        }

        private void frmMarketWatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        int rowIndexFromMouseDown;
        DataGridViewRow rw;

        private void uctlMarketWatch1_OnGridDragDrop(object arg1, DragEventArgs e)
        {
            try
            {
                if (rowIndexFromMouseDown > -1)
                {
                    int rowIndexOfItemUnderMouseToDrop;
                    Point clientPoint = uctlMarketWatch1.ui_ndgvMarketWatch.PointToClient(new Point(e.X, e.Y));
                    rowIndexOfItemUnderMouseToDrop = uctlMarketWatch1.ui_ndgvMarketWatch.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

                    if (e.Effect == DragDropEffects.Move)
                    {
                        //======================
                        // get the row data from row before removing and add to new row
                        object[] rowArray = marketDS.dtMarketWatch.Rows[rowIndexFromMouseDown].ItemArray;
                        DataRow row = marketDS.dtMarketWatch.NewRow();
                        row.ItemArray = rowArray;

                        // remove old row and insert new row
                        marketDS.dtMarketWatch.Rows.RemoveAt(rowIndexFromMouseDown);
                        marketDS.dtMarketWatch.Rows.InsertAt(row, rowIndexOfItemUnderMouseToDrop);
                        InstrumentSpec objInstrumentSpec = null;
                        //InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(row["ContractName"].ToString(), row["ProductType"].ToString(), row["ProductName"].ToString());

                        if (objInstrumentSpec != null)
                        {
                            string key = Symbol.getKey(objInstrumentSpec)[0];
                            // var index = marketDS.dtMarketWatch.Rows.IndexOf(row);
                            if (uctlMarketWatch1._DDRows.ContainsKey(key))
                            {
                                uctlMarketWatch1._DDRows[key] = marketDS.dtMarketWatch.Rows[rowIndexOfItemUnderMouseToDrop];
                            }
                        }

                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void uctlMarketWatch1_OnGridDragEnter(object arg1, DragEventArgs e)
        {
            try
            {
                if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count > 0)
                {
                    // int rowIndexOfItemUnderMouseToDrop;
                    //  Point clientPoint = uctlMarketWatch1.ui_ndgvMarketWatch.PointToClient(new Point(e.X, e.Y));
                    // rowIndexOfItemUnderMouseToDrop = uctlMarketWatch1.ui_ndgvMarketWatch.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                    ///  if (rowIndexOfItemUnderMouseToDrop != rowIndexFromMouseDown)
                    {
                        // e.Effect = DragDropEffects.Move;
                    }
                    //else
                    //{
                    //    e.Effect = DragDropEffects.None;
                    //}
                }
            }
            catch (Exception)
            {

            }
        }

        private void uctlMarketWatch1_OnGridMouseClick(object arg1, MouseEventArgs e)
        {
            try
            {

                //if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count == 1)
                //{
                //    if (e.Button == MouseButtons.Left)
                //    {
                //        rw = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0];
                //        rowIndexFromMouseDown = uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index;
                //        uctlMarketWatch1.ui_ndgvMarketWatch.DoDragDrop(rw, DragDropEffects.Move);
                //    }
                //}
            }
            catch (Exception)
            {

            }
        }

        private void grdCons_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && rowIndexFromMouseDown > -1)
            {
                uctlMarketWatch1.ui_ndgvMarketWatch.DoDragDrop(uctlMarketWatch1.ui_ndgvMarketWatch.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
            }
        }

        private void grdCons_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = uctlMarketWatch1.ui_ndgvMarketWatch.HitTest(e.X, e.Y).RowIndex;
        }

        private void grdCons_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void uctlMarketWatch1_OnGridKeyDown(object arg1, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.Up)
                {
                    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                    Properties.Settings.Default.DefaultFontSize++;
                    dataGridViewCellStyle2.Font = new System.Drawing.Font(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.FontFamily.Name, Properties.Settings.Default.DefaultFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
                    dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
                    uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;

                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersHeight = Convert.ToInt32(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size + 13);
                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

                }
                else if (e.Control && e.KeyCode == Keys.Down)
                {
                    if (uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size > 8)
                    {
                        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                        Properties.Settings.Default.DefaultFontSize--;
                        dataGridViewCellStyle2.Font = new System.Drawing.Font(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.FontFamily.Name, Properties.Settings.Default.DefaultFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
                        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
                        uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
                        uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersHeight = Convert.ToInt32(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size + 13);

                    }
                }
                else if (e.Control && (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0))
                {
                    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                    Properties.Settings.Default.DefaultFontSize = 14F;
                    dataGridViewCellStyle2.Font = new System.Drawing.Font(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.FontFamily.Name, 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
                    dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
                    uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;
                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersHeight = Convert.ToInt32(uctlMarketWatch1.ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size + 13);
                    uctlMarketWatch1.ui_ndgvMarketWatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

            }
        }

        public void OnInsertRowClick(object sender, EventArgs e)
        {
            if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count > 0)
            {
                marketDS.dtMarketWatch.Rows.InsertAt(marketDS.dtMarketWatch.NewRow(), uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index);
                //    marketDS.dtMarketWatch.AcceptChanges();
                setGridRowHeight();
            }
        }

        public void OnMarketWatchSaveClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = ClsCommonMethods.ShowMessageBox("Do you want to save market watch?");
                if (result == DialogResult.Yes)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = marketDS.dtMarketWatch.Copy();
                    frmMarketWatchSave objFrmSave = new frmMarketWatchSave(ddSavedMW, _userCode, dtTemp, Properties.Settings.Default.DefaultFontSize);
                    objFrmSave.OnMarketWatchSaveClick -= new Action<Dictionary<string, clsSavedMW>>(objFrmSave_OnMarketWatchSaveClick);
                    objFrmSave.OnMarketWatchSaveClick += new Action<Dictionary<string, clsSavedMW>>(objFrmSave_OnMarketWatchSaveClick);
                    objFrmSave.StartPosition = FormStartPosition.CenterScreen;
                    objFrmSave.ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        void objFrmSave_OnMarketWatchSaveClick(Dictionary<string, clsSavedMW> obj)
        {
            try
            {
                ddSavedMW = obj;
                uctlMarketWatch1.SavedWorkSpace = ddSavedMW.Keys.ToList();
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Called when user select the Remove Symbol option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnRemoveSymbolClick(object sender, EventArgs e)
        {

            if (uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows.Count > 0)
            {
                if (uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
                {
                    DataRow[] r = marketDS.dtMarketWatch.Select("ContractName = '" + uctlMarketWatch1.ui_ndgvMarketWatch.Rows[uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() + "'");
                    if (r.Length > 0)
                    {
                        try
                        {
                            int temp = marketDS.dtMarketWatch.Rows.IndexOf(r[0]);
                            //string _key = marketDS.dtMarketWatch.Rows[temp]["InstrumentId"].ToString();
                            string ContractName = marketDS.dtMarketWatch.Rows[temp]["ContractName"].ToString();
                            marketDS.dtMarketWatch.Rows.RemoveAt(marketDS.dtMarketWatch.Rows.IndexOf(r[0]));
                            uctlMarketWatch1._DDRows.Remove(ContractName);
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                else
                {
                    marketDS.dtMarketWatch.Rows.RemoveAt(uctlMarketWatch1.ui_ndgvMarketWatch.SelectedRows[0].Index);
                }
                // marketDS.dtMarketWatch.AcceptChanges();
                setGridRowHeight();
            }

        }

        private void uctlMarketWatch1_OnMarketWatchRemoveClick(string obj)
        {
            try
            {
                if (ddSavedMW != null && ddSavedMW.ContainsKey(obj))
                {
                    ddSavedMW.Remove(obj);
                    string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetMarketWatchFileName(_userCode));
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    Stream streamWrite = File.Open(ClsTWSUtility.GetMarketWatchFileName(_userCode), FileMode.Create, FileAccess.Write);
                    var binaryWrite = new BinaryFormatter();
                    binaryWrite.Serialize(streamWrite, ddSavedMW);
                    streamWrite.Close();
                    uctlMarketWatch1.SavedWorkSpace = ddSavedMW.Keys.ToList();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
