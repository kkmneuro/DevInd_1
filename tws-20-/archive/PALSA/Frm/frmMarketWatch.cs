///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	Namo		    1.Desgining of the form
//13/02/2012	Namo		    1.Code for displaying buy and sell OrderEntry dialog from frmMarketWatch
//                              2.code Pull data in order entry (buy/sell) from selected record of order entry while it opens from market watch
//17/02/2012    Namo            1.code to add a Product to active Market Watch correcsponding to Selected products from FilterBar
//05/03/2012	Namo            1.Code for Setting Default column profile
//1 July 2014	Namo		    1.sorting of grid data on expiry date is removed
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
    public partial class frmMarketWatch : frmBase
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

        #region Nested type: PriceQuoteHandler

        private delegate void PriceQuoteHandler(string key, Quote Quote);

        #endregion

        #region Nested type: QuoteSnapShotHandler

        private delegate void QuoteSnapShotHandler(string key, QuoteSnapshot QuoteSnapShot);

        #endregion

        #region Nested type: UpdateQuoteHandler

        private delegate void UpdateQuoteHandler(QuoteItem quoteItem, DataRow row);

        #endregion

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

        #region "        CONSTRUCTOR         "

        public frmMarketWatch(object objPortfolio, object objProfiles, string portfolioName, string profileName, string userCode)
        {
            count += 1;
            _userCode = userCode;
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into frmMarketWatch Constructor");

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
            uctlMarketWatch1.ui_uctlGridMarketWatch.EnableCellCustomDraw = false;
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
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from frmMarketWatch Method");
        }


        #endregion "        CONSTRUCTOR         "

        #region "         METHODS         "

        private void frmMarketWatch_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into frmMarketWatch_Load Method");

            var ContextMenuItems = new ToolStripMenuItem[5];
            ResizeRedraw = false;
            Width = MdiParent.Width - 20;
            MainMenuStrip = MdiParent.MainMenuStrip;
            ContextMenuItems[0] = new ToolStripMenuItem("Buy Order");
            ContextMenuItems[0].Name = "BuyOrder";
            ContextMenuItems[0].Enabled = false;
            ContextMenuItems[0].ShortcutKeys = ShortcutKeyBOE;
            ContextMenuItems[0].Click += OnBuyOrderClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Sell Order");
            ContextMenuItems[1].Name = "SellOrder";
            ContextMenuItems[1].Enabled = false;
            ContextMenuItems[1].ShortcutKeys = ShortcutKeySOE;
            ContextMenuItems[1].Click += OnSellOrderClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Market Picture");
            ContextMenuItems[2].Name = "MarketPicture";
            ContextMenuItems[2].Enabled = false;
            ContextMenuItems[2].Click += OnMarketPictureClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Delete Row");
            ContextMenuItems[3].Name = "RemoveSymbol";
            ContextMenuItems[3].Enabled = false;
            ContextMenuItems[3].ShortcutKeys = Keys.Delete;
            ContextMenuItems[3].ShortcutKeyDisplayString = "Delete";
            ContextMenuItems[3].Click += OnRemoveSymbolClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Insert Row");
            ContextMenuItems[4].Name = "InsertRow";
            ContextMenuItems[4].ToolTipText = "Insert a blank row";
            ContextMenuItems[4].Enabled = false;
            ContextMenuItems[4].ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter)));
            ContextMenuItems[4].Click += OnInsertRowClick;

            Title = uctlMarketWatch1.Title + " - " + uctlMarketWatch1.CurrentPortfolioName;

            DoubleBuffered(uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid, true);
            if (uctlMarketWatch1.CurrentPortfolioName != string.Empty)
            {
                uctlMarketWatch1_OnScriptPortfolioApplyClick(uctlMarketWatch1.CurrentPortfolioName);
            }
            else if (_objPortfolio != null && ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().Contains(
                        Properties.Settings.Default.MarketWatchPortfolio))
                {
                    int index =
                        ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().IndexOf(
                            Properties.Settings.Default.MarketWatchPortfolio);
                    uctlMarketWatch1_OnScriptPortfolioApplyClick(
                        ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList()[index]);
                }
            }
            uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items.AddRange(ContextMenuItems);
            uctlMarketWatch1.ui_uctlGridMarketWatch.DataSource = marketDS.dtMarketWatch;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += marketWatch_onSnapShotUpdate;
            tm.Enabled = true;
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from frmMarketWatch_Load Method");
        }

        private void frmMarketWatch_Resize(object sender, EventArgs e)
        {
            uctlMarketWatch1.Width = Size.Width;
            uctlMarketWatch1.Height = Size.Height;
        }

        private void frmMarketWatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;

        }

        private void frmMarketWatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into frmMarketWatch_FormClosed Method");
            count -= 1;
            _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlMarketWatch1.CurrentPortfolioName + "/" + uctlMarketWatch1.CurrentProfileName;
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from frmMarketWatch_FormClosed Method");
        }


        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DoubleBuffered Method");
        }

        private void ApplySnapShot(List<Symbol> lst)
        {

            foreach (var item in lst)
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;

                DataRow row = null;
                if (uctlMarketWatch1._DDRows.TryGetValue(item.KEY, out row))
                {
                    string contract = item.KEY.Substring(item.KEY.LastIndexOf('_') + 1);
                    if (ClsGlobal.DDRightZLevel.Keys.Contains(contract))
                    {
                        row["SellPrice"] = ClsGlobal.DDRightZLevel[contract].ToString("0.00");
                        if (ClsGlobal.DDRightZLevelQty.Keys.Contains(contract))
                        {
                            row["SellQty"] = ClsGlobal.DDRightZLevelQty[contract].ToString("0.00");
                        }
                    }
                    if (ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
                    {
                        row["BuyPrice"] = ClsGlobal.DDLeftZLevel[contract].ToString("0.00");
                        if (ClsGlobal.DDLeftZLevelQty.Keys.Contains(contract))
                        {
                            row["BuyQty"] = ClsGlobal.DDLeftZLevelQty[contract].ToString("0.00");
                        }
                    }
                    if (ClsGlobal.DDClose.Keys.Contains(contract))
                    {
                        row["ClosePrice"] = ClsGlobal.DDClose[contract].ToString("0.00");
                    }
                    if (ClsGlobal.DDHigh.Keys.Contains(contract))
                    {
                        row["High"] = ClsGlobal.DDHigh[contract].ToString("0.00");
                        row["PrevHigh"] = ClsGlobal.DDHigh[contract].ToString("0.00");
                    }
                    if (ClsGlobal.DDLTP.Keys.Contains(contract))
                    {
                        row["LTP"] = ClsGlobal.DDLTP[contract].ToString("0.00");
                    }
                    if (ClsGlobal.DDLTP.Keys.Contains(contract) && ClsGlobal.DDClose.Keys.Contains(contract))
                    {
                        row["NetChange"] = (ClsGlobal.DDLTP[contract] - ClsGlobal.DDClose[contract]).ToString("0.00");

                    }
                    DateTime dtx = DateTime.Now;
                    row["LastUpdatedTime"] = dtx;
                    if (ClsGlobal.DDLow.Keys.Contains(contract))
                    {
                        row["Low"] = ClsGlobal.DDLow[contract].ToString("0.00");
                        row["PrevLow"] = ClsGlobal.DDLow[contract].ToString("0.00");
                    }

                    if (ClsGlobal.DDOpen.Keys.Contains(contract))
                    {
                        row["OpenPrice"] = ClsGlobal.DDOpen[contract].ToString("0.00");
                    }

                    if (ClsGlobal.DDVolume.Keys.Contains(contract))
                    {
                        row["Volume"] = ClsGlobal.DDVolume[contract];
                    }

                }

            }

        }


        public void marketWatch_onSnapShotUpdate(Dictionary<string, QuoteSnapshot> DDQuoteSnapshot)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into marketWatch_onSnapShotUpdate Method");

            foreach (var item in DDQuoteSnapshot)
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;
                KeyValuePair<string, QuoteSnapshot> item1 = item;
                Action A = () =>
                               {
                                   DataRow row = null;
                                   if (uctlMarketWatch1._DDRows.TryGetValue(item1.Key, out row))
                                   {
                                       string contract = item1.Key.Substring(item1.Key.LastIndexOf('_') + 1);
                                       if (ClsGlobal.DDRightZLevel.Keys.Contains(contract))
                                       {
                                           row["SellPrice"] = ClsGlobal.DDRightZLevel[contract].ToString("0.00");
                                           if (ClsGlobal.DDRightZLevelQty.Keys.Contains(contract))
                                           {
                                               row["SellQty"] = ClsGlobal.DDRightZLevelQty[contract].ToString("0.00");
                                           }
                                       }
                                       if (ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
                                       {
                                           row["BuyPrice"] = ClsGlobal.DDLeftZLevel[contract].ToString("0.00");
                                           if (ClsGlobal.DDLeftZLevelQty.Keys.Contains(contract))
                                           {
                                               row["BuyQty"] = ClsGlobal.DDLeftZLevelQty[contract].ToString("0.00");
                                           }
                                       }
                                       row["ClosePrice"] = item1.Value.Close.ToString("0.00");
                                       row["PrevHigh"] = item1.Value.High.ToString("0.00");
                                       row["High"] = item1.Value.High.ToString("0.00");
                                       row["LTP"] = item1.Value.LastPrice.ToString("0.00");

                                       DateTime dtx = DateTime.Now;
                                       string date = string.Empty;

                                       DateTime.TryParse(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(Convert.ToString(item1.Value.LastUpdatedTime)), out dtx);
                                       row["LastUpdatedTime"] = dtx;
                                       row["PrevLow"] = item1.Value.Low.ToString("0.00");
                                       row["Low"] = item1.Value.Low.ToString("0.00");
                                       row["OpenPrice"] = item1.Value.Open.ToString("0.00");
                                       row["Volume"] = item1.Value.Volume;

                                   }
                                   else
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
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from marketWatch_onSnapShotUpdate Method");
        }

        public void marketWatch_onPriceUpdate(Dictionary<string, Quote> DDQuote)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into marketWatch_onPriceUpdate Method");

            foreach (var item in DDQuote)
            {
                marketWatch_onPriceUpdate(item.Key, item.Value);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from marketWatch_onPriceUpdate Method");
        }

        private void marketWatch_onPriceUpdate(string key, Quote Quote)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into marketWatch_onPriceUpdate Method");

            if (InvokeRequired)
            {
                BeginInvoke(new PriceQuoteHandler(marketWatch_onPriceUpdate), key, Quote);
                return;
            }
            else
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;
                DataRow row = null;
                SuspendLayout();
                if (uctlMarketWatch1._DDRows.TryGetValue(key, out row))
                {
                    List<QuoteItem> lst = Quote._lstItem;
                    int lstCount = lst.Count;
                    for (int iListLoop = 0; iListLoop < lstCount; iListLoop++)
                    {
                        if (lst[iListLoop].MarketLevel != 0)
                            continue;
                        UpdateQuote(lst[iListLoop], row);
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from marketWatch_onPriceUpdate Method");
        }

        private void UpdateQuote(QuoteItem quoteItem, DataRow row)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into UpdateQuote Method");
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpdateQuoteHandler(UpdateQuote), row, quoteItem);
                    return;
                }
                else
                {
                    int index = marketDS.dtMarketWatch.Rows.IndexOf(row);
                    DateTime dtx = DateTime.Now;
                    string date = string.Empty;
                    if (dtx != DateTime.MinValue)
                    {
                        date = string.Format(
                                    Properties.Settings.Default.TimeFormat.Contains("24")
                                        ? "{0:dd/MM/yyyy HH:mm:ss}"
                                        : "{0:dd/MM/yyyy hh:mm:ss tt}", dtx);
                    }
                    marketDS.dtMarketWatch.Rows[index]["LastUpdatedTime"] = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(quoteItem.Time);
                    switch (quoteItem.QST)
                    {
                        case QuoteStreamType.CLOSE:
                            {
                                marketDS.dtMarketWatch.Rows[index]["ClosePrice"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                            }
                            break;
                        case QuoteStreamType.OPEN:
                            {
                                marketDS.dtMarketWatch.Rows[index]["OpenPrice"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                            }
                            break;
                        case QuoteStreamType.ASK:
                            {
                                long prevSize = 0;
                                double prevPrice = 0;
                                double.TryParse(marketDS.dtMarketWatch.Rows[index]["SellPrice"].ToString().Trim(), out prevPrice);
                                long.TryParse(marketDS.dtMarketWatch.Rows[index]["SellQty"].ToString().Trim(), out prevSize);
                                marketDS.dtMarketWatch.Rows[index]["SellPrice"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                                marketDS.dtMarketWatch.Rows[index]["SellQty"] = quoteItem.Size.ToString("0.00");
                                if (quoteItem.Size > prevSize)
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.UpTrendColor;

                                }
                                else if (quoteItem.Size < prevSize)
                                {

                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                }


                                //if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                                //{
                                //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                //}
                                //else if (quoteItem._status == QuoteItemStatus.UP) //UP
                                //{
                                //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                //}
                                if (prevPrice > quoteItem.Price) //Down
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                }
                                else if (prevPrice < quoteItem.Price) //UP
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                }

                            }
                            break;
                        case QuoteStreamType.BID:
                            {

                                long prevSize = 0;
                                double prevPrice = 0;
                                double.TryParse(marketDS.dtMarketWatch.Rows[index]["BuyPrice"].ToString().Trim(), out prevPrice);
                                long.TryParse(marketDS.dtMarketWatch.Rows[index]["BuyQty"].ToString().Trim(), out prevSize);
                                marketDS.dtMarketWatch.Rows[index]["BuyPrice"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                                marketDS.dtMarketWatch.Rows[index]["BuyQty"] = quoteItem.Size.ToString("0.00");

                                if (quoteItem.Size > prevSize)
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.UpTrendColor;

                                }
                                else if (quoteItem.Size < prevSize)
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                }
                                if (prevPrice > quoteItem.Price) //Down
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;

                                }
                                else if (prevPrice < quoteItem.Price) //UP
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                }

                                //if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                                //{
                                //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                //}
                                //else if (quoteItem._status == QuoteItemStatus.UP) //UP
                                //{
                                //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;

                                //}
                                //else //Unchanged
                                //{
                                //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor
                                //        = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
                                //}                                    
                            }
                            break;
                        case QuoteStreamType.HIGH:
                            {
                                marketDS.dtMarketWatch.Rows[index]["High"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                            }
                            break;
                        case QuoteStreamType.LAST:
                            {
                                marketDS.dtMarketWatch.Rows[index]["LTP"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");

                                if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                        Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                                }
                                else if (quoteItem._status == QuoteItemStatus.UP) //UP
                                {
                                    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                        Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                                }

                                if (marketDS.dtMarketWatch.Rows[index]["LTP"] != null && marketDS.dtMarketWatch.Rows[index]["ClosePrice"] != null)
                                {
                                    decimal ltp = Convert.ToDecimal(quoteItem.Price) - Convert.ToDecimal(marketDS.dtMarketWatch.Rows[index]["ClosePrice"]);
                                    marketDS.dtMarketWatch.Rows[index]["NetChange"] = ltp.ToString("0.00");
                                    if (ltp < 0)
                                    {

                                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmNetChange"].Style.BackColor
                                           = uctlMarketWatch1.DownTrendColor;
                                    }
                                    else
                                    {

                                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmNetChange"].Style.BackColor
                                           = uctlMarketWatch1.UpTrendColor;
                                    }
                                }
                                else
                                    marketDS.dtMarketWatch.Rows[index]["NetChange"] = "0.00";
                            }
                            break;
                        case QuoteStreamType.LOW:
                            {
                                marketDS.dtMarketWatch.Rows[index]["Low"] = Convert.ToDecimal(quoteItem.Price).ToString("0.00");
                            }
                            break;
                        case QuoteStreamType.VOLUME:
                            {
                                marketDS.dtMarketWatch.Rows[index]["Volume"] = quoteItem.Size;
                            }
                            break;
                        case QuoteStreamType.VOLUME_PER:
                            {
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from UpdateQuote Method");
        }


        void tm_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count; i++)
                {
                    try
                    {
                        string lut = uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmLastUpdatedTime"].Value.ToString();
                        if (lut != null && lut.Trim() != "")
                        {
                            DateTime _lut = DateTime.Now;
                            DateTime.TryParse(lut, out _lut);
                            TimeSpan tmpTime = DateTime.Now - _lut;
                            if (tmpTime.TotalSeconds >= 3)
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmSellQty"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmBuyQty"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
                                //  uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[i].Cells["ClmNetChange"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DefaultCellStyle.BackColor;
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

        //code by vijay to apply default set column profile 
        private void ApplyDefaultProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into ApplyDefaultProfile Method");

            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlMarketWatch1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
            foreach (DataGridViewColumn col in uctlMarketWatch1.ui_uctlGridMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from ApplyDefaultProfile Method");
        }

        public void ReactivateMarketWatch(List<Symbol> symbolLst)
        {
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -= marketWatch_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += marketWatch_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE,symbolLst);            
        }

        private void OnProfileApplyClick(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnProfileApplyClick Method");

            if (
                !((Dictionary<string, ClsProfile>)_objProfiles).Keys.Contains(profileName + "_" +
                                                                               ProfileTypes.MarketWatch.ToString()))
                return;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.MarketWatch.ToString()];
            foreach (DataGridViewColumn col in uctlMarketWatch1.ui_uctlGridMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnProfileApplyClick Method");
        }

        /// <summary>
        /// Called when user select the BuyOrder option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBuyOrderClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnBuyOrderClick Method");

            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
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


            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {

                DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
                DisplayOrderEntryDialog("SELL", Properties.Settings.Default.SellOrderColor, "Sell Order Entry",
                                        CommandIDS.PLACE_SELL_ORDER.ToString(), selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnSellOrderClick Method");
        }
        /// <summary>
        /// Called when user select the Remove Symbol option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnRemoveSymbolClick(object sender, EventArgs e)
        {

            if (uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows.Count > 0)
            {
                if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
                {
                    DataRow[] r = marketDS.dtMarketWatch.Select("ContractName = '" + uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() + "'");
                    if (r.Length > 0)
                    {
                        int temp = marketDS.dtMarketWatch.Rows.IndexOf(r[0]);
                        string _key = marketDS.dtMarketWatch.Rows[temp]["InstrumentId"].ToString();
                        marketDS.dtMarketWatch.Rows.RemoveAt(marketDS.dtMarketWatch.Rows.IndexOf(r[0]));
                        uctlMarketWatch1._DDRows.Remove(_key);
                    }
                }
                else
                {
                    marketDS.dtMarketWatch.Rows.RemoveAt(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index);
                }

                marketDS.dtMarketWatch.AcceptChanges();

                setGridRowHeight();
            }

        }

        private void setGridRowHeight()
        {
            if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize > 8)
            {
                if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize < 24)
                {
                    CommonLibrary.UserControls.UctlMarketWatch.GridFontSize = 19;
                }
                foreach (DataGridViewRow row in uctlMarketWatch1.ui_uctlGridMarketWatch.Rows)
                {
                    row.Height = Convert.ToInt32(CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 4);
                }
            }
        }

        public void OnInsertRowClick(object sender, EventArgs e)
        {
            if (uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows.Count > 0)
            {
                marketDS.dtMarketWatch.Rows.InsertAt(marketDS.dtMarketWatch.NewRow(), uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index);
                marketDS.dtMarketWatch.AcceptChanges();
                setGridRowHeight();
            }
        }




        /// <summary>
        /// Called when user select the Market Picture option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void OnMarketPictureClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnMarketPictureClick Method");

            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0 && uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() != "")
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
                DisplayMarketPictureDialog(selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnMarketPictureClick Method");
        }

        private void uctlMarketWatch1_OnScriptPortfolioApplyClick(string portfolioName)
        {
            if (portfolioName != string.Empty)
            {
                Title = uctlMarketWatch1.Title + " - " + portfolioName;
                _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName +
                           "/" + uctlMarketWatch1.CurrentProfileName;
                if (((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Contains(portfolioName))
                {
                    ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)_objPortfolio)[portfolioName];
                    marketDS.dtMarketWatch.Rows.Clear();
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DataSource = marketDS.dtMarketWatch;
                    uctlMarketWatch1._DDRows.Clear();
                    int keycount = objPortfolio.Products.Keys.Count;
                    var lst = new List<Symbol>();
                    foreach (string key in objPortfolio.Products.Keys)
                    {
                        try
                        {

                            Symbol sym = Symbol.GetSymbol(key);
                            InstrumentSpec inspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                            if (inspec != null)
                            {
                                DataRow dr = marketDS.dtMarketWatch.NewRow();
                                marketDS.dtMarketWatch.Rows.Add(dr);
                                int index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                                uctlMarketWatch1._DDRows.Add(sym.KEY, marketDS.dtMarketWatch.Rows[index]);

                                if (inspec != null)
                                {
                                    marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                                    marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = sym.KEY;
                                    marketDS.dtMarketWatch.Rows[index]["ProductType"] = inspec.ProductType;
                                    marketDS.dtMarketWatch.Rows[index]["ULAsset"] = inspec.UL_Asset;
                                    marketDS.dtMarketWatch.Rows[index]["ProductName"] = inspec.Product;
                                    DateTime exp = Convert.ToDateTime(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(inspec.ExpiryDate)).Date;
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
                        catch (Exception)
                        {


                        }
                    }

                    ApplySnapShot(lst);

                    if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected)
                    {
                        clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE ,lst);
                        
                        TWS.Cls.ClsGlobal._isFirstRequest = false;
                    }
                    else
                        ClsCommonMethods.ShowErrorBox("Data Manager is not Connected.");

                    if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize > 8)
                    {
                        if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize < 24)
                        {
                            CommonLibrary.UserControls.UctlMarketWatch.GridFontSize = 19;
                        }
                        foreach (DataGridViewRow row in uctlMarketWatch1.ui_uctlGridMarketWatch.Rows)
                        {
                            row.Height = Convert.ToInt32(CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 4);
                        }             
                    }
                }
                else
                {
                    ClsCommonMethods.ShowErrorBox("Portfolio *" + portfolioName + "* is not found.");
                }
            }         
        }

        private void uctlMarketWatch1_OnScriptPortfolioModifyClick(string portfolioName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnScriptPortfolioModifyClick Method");

            var objfrmPortfolio = new frmPortfolio(_objPortfolio, portfolioName, _userCode);
            objfrmPortfolio.OnSavePortfolio -= objfrmPortfolio_OnSavePortfolio;
            objfrmPortfolio.OnSavePortfolio += objfrmPortfolio_OnSavePortfolio;
            objfrmPortfolio.ShowDialog();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnScriptPortfolioModifyClick Method");
        }

        private void objfrmPortfolio_OnSavePortfolio(string potfolioName)
        {
            CommonLibrary.Cls.ClsCommonMethods.ShowInformation("Porfolio Saved successfully.");
        }

        private void uctlMarketWatch1_OnScriptPortfolioRemoveClick(string portfolioName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnScriptPortfolioRemoveClick Method");

            ((Dictionary<string, ClsPortfolio>)_objPortfolio).Remove(portfolioName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnScriptPortfolioRemoveClick Method");
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
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into uctlMarketWatch1_OnGridMouseDown Method");

            DataGridView.HitTestInfo hitTestInfo = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.HitTest(arg2.X,
                                                                                                               arg2.Y);
            if (hitTestInfo.RowIndex < 0)
            {


                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["InsertRow"].Enabled = false;

                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Chart"].Enabled = false;

            }
            else
            {

                if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index].Cells["ClmContractName"].Value.ToString() == "")
                {
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = false;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = false;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = false;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = false;

                }
                else
                {

                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = true;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = true;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = true;
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = true;

                }
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["InsertRow"].Enabled = true;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["RemoveSymbol"].Enabled = true;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Chart"].Enabled = true;
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from uctlMarketWatch1_OnGridMouseDown Method");
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey,
                                             DataGridViewRow selectedRow)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into DisplayOrderEntryDialog Method");

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


            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from DisplayOrderEntryDialog Method");
        }

        private void DisplayMarketPictureDialog(DataGridViewRow selectedRow)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Enter into DisplayMarketPictureDialog Method");

            if (frmMarketPicture.Count < 4)
            {
                var objMarketPicture = new frmMarketPictureNew();
                objMarketPicture.StartPosition = FormStartPosition.CenterScreen;
                objMarketPicture.MdiParent = ParentForm;
                objMarketPicture.SetValuesToMarketPicture(selectedRow);
                objMarketPicture.Show();
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from DisplayMarketPictureDialog Method");
        }

        public void AddRowToMarketWatch(string key, InstrumentSpec objInstrumentSpec)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into AddRowToMarketWatch Method");

            var lst = new List<Symbol>();

            var sym = Symbol.GetSymbol(key);
            if (!uctlMarketWatch1._DDRows.Keys.Contains(key))
            {
                var dr = marketDS.dtMarketWatch.NewRow();
                if (uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows.Count > 0)
                {
                    int selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Index;
                    marketDS.dtMarketWatch.Rows.InsertAt(dr, selectedRow);

                }
                else
                {
                    marketDS.dtMarketWatch.Rows.Add(dr);
                }
                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Add(1);
                var index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                //int index = 0;
                uctlMarketWatch1._DDRows.Add(key, marketDS.dtMarketWatch.Rows[index]);


                if (objInstrumentSpec != null)
                {



                    //var dr1 = marketDS.dtMarketWatch.NewRow();
                    //marketDS.dtMarketWatch.Rows.Add(dr1);
                    //marketDS.dtMarketWatch.AcceptChanges();
                    marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                    marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = key;
                    marketDS.dtMarketWatch.Rows[index]["ProductType"] = objInstrumentSpec.ProductType;
                    marketDS.dtMarketWatch.Rows[index]["ULAsset"] = objInstrumentSpec.UL_Asset;
                    marketDS.dtMarketWatch.Rows[index]["ProductName"] = objInstrumentSpec.Product;
                    marketDS.dtMarketWatch.Rows[index]["Expiry"] = Convert.ToDateTime(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(objInstrumentSpec.ExpiryDate)).Date.ToString("dd/MM/yyyy");
                    marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                    marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] =
                        Convert.ToString(objInstrumentSpec.PriceQuantity);
                    marketDS.dtMarketWatch.Rows[index]["Specification"] = objInstrumentSpec.Specification;
                    ////marketDS.dtMarketWatch.DefaultView.Sort = "Expiry asc";
                    ////marketDS.dtMarketWatch.AcceptChanges();
                    lst.Add(sym);
                    if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize > 8)
                    {
                        if (CommonLibrary.UserControls.UctlMarketWatch.GridFontSize < 24)
                        {
                            CommonLibrary.UserControls.UctlMarketWatch.GridFontSize = 19;
                        }
                        foreach (DataGridViewRow row in uctlMarketWatch1.ui_uctlGridMarketWatch.Rows)
                        {
                            row.Height = Convert.ToInt32(CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 4);
                        }

                        //uctlMarketWatch1.ui_uctlGridMarketWatch.ColumnHeaderHeight = CommonLibrary.UserControls.UctlMarketWatch.GridFontSize + 15;
                    }
                }
                if (!TWS.Cls.ClsGlobal.SubscibedSymbolList.ContainsKey(sym.Contract))
                {
                    TWS.Cls.ClsGlobal.SubscibedSymbolList.Add(sym.Contract, sym);
                }
                ApplySnapShot(lst);
                //clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(true, eMarketRequest.MARKET_QUOTE_REQUEST, lst); // Commented : Ajay

                clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(SubscribeRequestType.SUBSCRIBE,lst); // Added : Ajay
                //  clsTWSDataManagerJSON.INSTANCE.SubscribeForQuoteSnapShot(true, eMarketRequest.MARKET_QUOTE_SNAP, lst);
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

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from SaveProfile Method");
        }

        private void frmMarketWatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion "      METHODS      "

    }
}