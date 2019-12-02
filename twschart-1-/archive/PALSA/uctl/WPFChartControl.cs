using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
//using StockChart;
using stockXUserctrl;
using System.Collections;
using PALSA.Frm;
using PALSA.Cls;

namespace PALSA.uctl
{
    public partial class WPFChartControl : UctlBase
    {
        private delegate void PriceQuoteHandler(string sym, Quote quote);
        Dictionary<DateTime, Cls.OHLC> minuteData = new Dictionary<DateTime, Cls.OHLC>();
        private Hashtable ht_RealTimeData = new Hashtable();
        public System.Windows.Forms.Integration.ElementHost elementHost1;
        chartingCtrl ctrol = null;
        public ePeriodicity _chartBarType = ePeriodicity.Minutely_1;
        public NewHistoryType ChartHistoryType_ = NewHistoryType.MINUTE;
        private PALSA.Cls.ChartProperty _chartProperties = new PALSA.Cls.ChartProperty();
        private string StkSymbol;
        private List<DateTime> lstChartDT = new List<DateTime>();
        private PALSA.Cls.BarDataNew _LatestCandleStick = new Cls.BarDataNew();
        private List<PALSA.Cls.BarDataNew> _lstCandleStick = new List<Cls.BarDataNew>();
        public string m_symbol
        {
            get { return StkSymbol; }
            set { StkSymbol = value; }
        }

        private int interval;
        public int m_Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        private string Bars;
        public string m_Bars
        {
            get { return Bars; }
            set { Bars = value; }
        }

        private PeriodEnum Periodicity;
        public PeriodEnum m_Periodicity
        {
            get { return Periodicity; }
            set { Periodicity = value; }
        }

        private DataTable dtData;
        public DataTable DTDAta
        {
            set
            {
                dtData = value;
                //ctrol.DTDAta = dtData;
            }
            get { return dtData;}
        }
        private FrmMain mainForm;
        private bool IsChangePeriodicity = false;
        private OHLCEntity OHLCEntity_;
        Dictionary<DateTime, Cls.OHLC> dicOHLC = new Dictionary<DateTime, Cls.OHLC>();
        public delegate void ChartBarAddedDelegate(PALSA.Cls.BarDataNew barData);
        public event ChartBarAddedDelegate ChartDataAdded;
        public delegate void ChartBarChangedDelegate(PALSA.Cls.BarDataNew barData);
        public event ChartBarChangedDelegate ChartDataChanged;
        public int Subscribers;
        public event Action<List<PALSA.Cls.BarDataNew>> OnHistoricalData = delegate { };
        public WPFChartControl(string sym,int period,PeriodEnum value, FrmMain mainfrm)
        {
            InitializeComponent();
            m_symbol = sym;
            CreateCtrls();

            mainForm = mainfrm;
            LoadOHLC(m_symbol, period, "250", value);
        }
        public WPFChartControl(string sym, FrmMain mainfrm)
        {
            InitializeComponent();
            m_symbol = sym;
            CreateCtrls();
            mainForm = mainfrm;

            LoadOHLC(m_symbol, 1, "250", PeriodEnum.Minute);
            
            //CreateTable();
            //CreateCtrls();
            //ctrol.DTDAta = DTDAta;
        }

        //Added by vijay on 29 Nov 
        public WPFChartControl(string sym, int interval, FrmMain mainfrm)
        {
            InitializeComponent();
            m_symbol = sym;
            CreateCtrls();
            mainForm = mainfrm;

            LoadOHLC(m_symbol, interval, "250", PeriodEnum.Minute);
        }

        public WPFChartControl(string sym, int period, PeriodEnum value, string bars,FrmMain mainfrm, bool IsEA)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            mainForm = mainfrm;
            LoadOHLC4EA(sym, period, bars, value);
        }

        private void LoadOHLC4EA(string symbol, int period, string numBars, PeriodEnum prd)
        {
            m_symbol = symbol;
            m_Interval = period;
            m_Bars = numBars;
            m_Periodicity = prd;
            CreateCtrls();

            _lstCandleStick.Clear();
            DataTable table = new DataTable();
            table.Columns.Add("open", typeof(double));
            table.Columns.Add("high", typeof(double));
            table.Columns.Add("low", typeof(double));
            table.Columns.Add("close", typeof(double));
            table.Columns.Add("Vol", typeof(long));
            table.Columns.Add("feedtime", typeof(DateTime));

            List<Cls.OHLC> lst = new List<Cls.OHLC>();
            LstOHLC _lstOHLC = new LstOHLC();
            lst = PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.GetOHLC(DateTime.Now, m_symbol, m_Interval, m_Bars, (int)m_Periodicity);

            foreach (var item in lst)
            {
                DataRow dr = table.NewRow();
                dr["open"] = item._Open;
                dr["high"] = item._High;
                dr["low"] = item._Low;
                dr["close"] = item._Close;
                dr["Vol"] = item._Volume;
                dr["feedtime"] = item._OHLCTime;

                PALSA.Cls.BarDataNew bar = new Cls.BarDataNew();
                bar.OpenPrice = item._Open;
                bar.HighPrice = item._High;
                bar.LowPrice = item._Low;
                bar.ClosePrice = item._Close;
                bar.Volume = item._Volume;
                bar.StartDateTime = item._OHLCTime.AddMinutes(-m_Interval);
                bar.CloseDateTime = item._OHLCTime;
                bar.TradeDateTime = item._OHLCTime;
                _lstCandleStick.Add(bar);
                table.Rows.Add(dr);
            }
            if (DTDAta == null)
            {
                DTDAta = new DataTable();
            }
            DTDAta.Clear();
            DTDAta = table;
            _lstCandleStick = _lstCandleStick.OrderBy(b => b.StartDateTime).ToList();


            ctrol.setSymbol(m_symbol);
            ctrol.DTDAta = DTDAta;

            ctrol.ResetAndFillCHartAgain();
            //Namo 21 March
            //PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
            //PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> ddQuotes)
        {
            foreach (var item in ddQuotes)
            {
                //Namo 21 March
                //foreach (QuoteItem quoteItem in item.Value._lstItem)
                //{
                //    string[] str = item.Key.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                //    if (m_symbol == str[str.Count() - 1])
                //    {
                //        //UpdateChart(m_symbol, item.Value);
                //        UpdateChartNew(m_symbol, item.Value);
                //    }
                //}
            }

            ////FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from INSTANCE_onPriceUpdate Method");
        }

        public DateTime getOhlcDate(DateTime DT)
        {
            ////FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into getOhlcDate Method");

            bool isHourZero, isMinuteZero, isSecondZero, isMonthZero, isDayZero;
            isHourZero = isMinuteZero = isSecondZero = isMonthZero = isDayZero = false;
            DateTime ReturnDateTime = DateTime.UtcNow;
            switch (ChartHistoryType_)
            {
                case NewHistoryType.DAY:
                    isHourZero = true;
                    isMinuteZero = true;
                    isSecondZero = true;
                    break;
                case NewHistoryType.HOUR:
                    isMinuteZero = true;
                    isSecondZero = true;
                    break;
                case NewHistoryType.MINUTE:
                    isSecondZero = true;
                    break;
                case NewHistoryType.MONTH:
                    isHourZero = true;
                    isMinuteZero = true;
                    isSecondZero = true;
                    break;
                case NewHistoryType.QUARTER:
                    break;
                case NewHistoryType.SECOND:
                    break;
                case NewHistoryType.WEEK:
                    isHourZero = true;
                    isMinuteZero = true;
                    isSecondZero = true;
                    break;
                case NewHistoryType.YEAR:
                    isHourZero = true;
                    isMinuteZero = true;
                    isSecondZero = true;
                    isMonthZero = true;
                    isDayZero = true;
                    break;
                default:
                    break;
            }

            if (isSecondZero)
            {
                ReturnDateTime = new DateTime(DT.Year, DT.Month,
                                              DT.Day, DT.Hour,
                                              DT.Minute, 0);
            }
            if (isMinuteZero)
            {
                ReturnDateTime = new DateTime(DT.Year, DT.Month,
                                              DT.Day, DT.Hour,
                                              0, DT.Second);
            }
            if (isHourZero)
            {
                ReturnDateTime = new DateTime(DT.Year, DT.Month,
                                              DT.Day, 0,
                                              DT.Minute, DT.Second);
            }
            if (isMonthZero && isDayZero)
            {
                ReturnDateTime = new DateTime(DT.Year, 0,
                                              0, 0,
                                              0, 0);
            }
            ////FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from getOhlcDate Method");

            return ReturnDateTime;
        }

        private TimeSpan CalculateTimeSpan()
        {
            ////FileHandling.WriteDevelopmentLog("Chart " + m_symbol + " : Enter into CalculateTimeSpan Method");

            TimeSpan timeSpan = TimeSpan.FromMinutes(m_Interval);
            switch (_chartBarType)
            {
                case ePeriodicity.Secondly:
                    {
                        timeSpan = TimeSpan.FromSeconds(m_Interval);
                    }
                    break;
                case ePeriodicity.Minutely_1:
                    {
                        timeSpan = TimeSpan.FromMinutes(m_Interval);
                    }
                    break;
                case ePeriodicity.Minutely_5:
                    {
                        timeSpan = TimeSpan.FromMinutes(m_Interval);
                    }
                    break;
                case ePeriodicity.Minutely_15:
                    {
                        timeSpan = TimeSpan.FromMinutes(m_Interval);
                    }
                    break;
                case ePeriodicity.Minutely_30:
                    {
                        timeSpan = TimeSpan.FromMinutes(m_Interval);
                    }
                    break;
                case ePeriodicity.Hourly_1:
                    {
                        timeSpan = TimeSpan.FromHours(m_Interval);
                    }
                    break;
                case ePeriodicity.Daily:
                    {
                        timeSpan = TimeSpan.FromDays(m_Interval);
                    }
                    break;
                case ePeriodicity.Weekly:
                    {
                        timeSpan = TimeSpan.FromDays(7 * m_Interval);
                    }
                    break;
                case ePeriodicity.Monthly:
                    {
                        timeSpan = TimeSpan.FromDays(30 * m_Interval);
                    }
                    break;
            }
            ////FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from CalculateTimeSpan Method");

            return timeSpan;
        }

        BackgroundWorker bgChart = new BackgroundWorker();
        void LoadOHLC(string sym, int interval, string bars, PeriodEnum Periodicity)
        {
            m_symbol = sym;
            m_Interval = interval;
            m_Bars = bars;
            m_Periodicity = Periodicity;

            bgChart = null;
            bgChart = new BackgroundWorker();
            bgChart.WorkerSupportsCancellation = true;
            bgChart.DoWork += new DoWorkEventHandler(bgChart_DoWork);
            bgChart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgChart_RunWorkerCompleted);
            bgChart.RunWorkerAsync();       
        }

        void bgChart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action a = () =>
            {
                ctrol.setSymbol(m_symbol);
                ctrol.DTDAta = DTDAta;
                //if (IsChangePeriodicity)
                //{
                //    ctrol.ClearSeries();
                //    IsChangePeriodicity = false;
                //}
                //else
                {
                    ctrol.ResetAndFillCHartAgain();
                }


                //Namo 21 March
                //PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
                //PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
            };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(a);
            }
            else
            {
                a();
            }
            
        }

        void bgChart_DoWork(object sender, DoWorkEventArgs e)
        {
            _lstCandleStick.Clear();
            DataTable table = new DataTable();
            table.Columns.Add("open", typeof(double));
            table.Columns.Add("high", typeof(double));
            table.Columns.Add("low", typeof(double));
            table.Columns.Add("close", typeof(double));
            table.Columns.Add("Vol", typeof(long));
            table.Columns.Add("feedtime", typeof(DateTime));

            List<Cls.OHLC> lst = new List<Cls.OHLC>();
            LstOHLC _lstOHLC = new LstOHLC();
            lst = PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.GetOHLC(DateTime.UtcNow, m_symbol, m_Interval, m_Bars, (int)m_Periodicity);
            
            foreach (var item in lst)
            {
                DataRow dr = table.NewRow();
                dr["open"] = item._Open;
                dr["high"] = item._High;
                dr["low"] = item._Low;
                dr["close"] = item._Close;
                dr["Vol"] = item._Volume;
                dr["feedtime"] = item._OHLCTime;

                PALSA.Cls.BarDataNew bar = new Cls.BarDataNew();
                bar.OpenPrice = item._Open;
                bar.HighPrice = item._High;
                bar.LowPrice = item._Low;
                bar.ClosePrice = item._Close;
                bar.Volume = item._Volume;
                bar.StartDateTime = item._OHLCTime.AddMinutes(-m_Interval);
                bar.CloseDateTime = item._OHLCTime;
                bar.TradeDateTime = item._OHLCTime;
                _lstCandleStick.Add(bar);
                table.Rows.Add(dr);
            }
            if (DTDAta == null)
            {
                DTDAta = new DataTable();
            }
            DTDAta.Clear();
            DTDAta = table;
            _lstCandleStick = _lstCandleStick.OrderBy(b => b.StartDateTime).ToList();
            if (OnHistoricalData != null)
                OnHistoricalData(_lstCandleStick);
        }

        private void CreateCtrls()
        {
            try
            {
                elementHost1 = new System.Windows.Forms.Integration.ElementHost();
                elementHost1.Dock = DockStyle.Fill;
                this.Controls.Add(elementHost1);//added host ctrl to this ctrls
                ctrol = new chartingCtrl();
                elementHost1.Child = ctrol;// here added chart to host

                //Kuldeep
                ctrol.OnPeriodicity -= new Action<string, int, string>(ctrol_OnPeriodicity);
                ctrol.OnPeriodicity += new Action<string, int, string>(ctrol_OnPeriodicity);
                ctrol.OnOrder -= new Action<string>(ctrol_OnOrder);
                ctrol.OnOrder += new Action<string>(ctrol_OnOrder);
                ctrol.OnProperties -= new Action(ctrol_OnProperties);
                ctrol.OnProperties += new Action(ctrol_OnProperties);

            }
            catch
            {
            }
        }

        void ctrol_OnProperties()
        {
            //return;//By Kuldeep
            double minY = 0;
            double maxY = 0;
            FillCurrentChartProperties();
            var prop = new frmPropertyChartWPF(m_symbol, DTDAta, _chartProperties, minY, maxY);
            DialogResult dlg = prop.ShowDialog();

            if (dlg == DialogResult.OK)
            {
                _chartProperties = prop.Props;

                Action A = () => { SetChartProperties(_chartProperties); };
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

        public void SetChartProperties(PALSA.Cls.ChartProperty props)
        {
            Action a = () => 
            {
                ctrol.SetColor("backGround", props.backGround);
                ctrol.SetColor("foreGround", props.foreGround);
                ctrol.SetColor("barDown", props.barDown);
                ctrol.SetColor("barUp", props.barUp);
                ctrol.SetColor("Crosshair", props.Crosshair);
                ctrol.SetColor("Grid", props.grid);
                ctrol.SetColor("DownOutLine", props.DownOutLine);
                ctrol.SetColor("UpOutLine", props.UpOutLine);
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(a);
            }
            else
            {
                a();
            }
        }

        private void FillCurrentChartProperties()
        {
            _chartProperties.backGround = ctrol.GetChartColor("backGround");
            _chartProperties.foreGround = ctrol.GetChartColor("foreGround");
            _chartProperties.grid = ctrol.GetChartColor("Grid");
            _chartProperties.barUp = ctrol.GetChartColor("barUp");
            _chartProperties.barDown = ctrol.GetChartColor("barDown");
            _chartProperties.UpOutLine = ctrol.GetChartColor("UpOutLine");
            _chartProperties.DownOutLine = ctrol.GetChartColor("DownOutLine");
            _chartProperties.Crosshair = ctrol.GetChartColor("Crosshair");
            //_chartProperties.barDown = ctrol.GetChartColor("PanelValueBack");
            //_chartProperties.barDown = ctrol.GetChartColor("PanelValueFore");

            //_chartProperties.bullCandle = ctrol.GetChartColor("bullCandle");
            //_chartProperties.bearCandle = ctrol.GetChartColor("bearCandle");
            //_chartProperties.lineGraph = ctrol.GetChartColor("lineGraph");
            //_chartProperties.askLine = ctrol.GetChartColor("askLine");
            //_chartProperties.stopLevels = ctrol.GetChartColor("stopLevels");
            //_chartProperties.SLLine = ctrol.GetChartColor("SLLine");
            //_chartProperties.TPPline = ctrol.GetChartColor("TPPline");
            //_chartProperties.forgroundChart = ctrol.GetBoolProperty("forgroundChart");//ui_ocxStockChart.ForegroundChart;
            //_chartProperties.chartAutoScroll = ctrol.GetBoolProperty("chartAutoScroll");
            //_chartProperties.showOHLC = ctrol.GetBoolProperty("showOHLC");
            //_chartProperties.periodSeperator = ctrol.GetBoolProperty("periodSeperator");
            //_chartProperties.showGrid = ctrol.GetBoolProperty("showGrid");
            //_chartProperties.showVolume = ctrol.GetBoolProperty("showVolume");
            //_chartProperties.ThreeDStyle = ctrol.GetBoolProperty("ThreeDStyle");

            //string chartType = ctrol.GetChartType();
            //switch (chartType)
            //{
            //    case "LineChart":
            //        _chartProperties.barChart = false;
            //        _chartProperties.candleSticks = false;
            //        _chartProperties.lineChart = true;
            //        break;
            //    case "BarChart":
            //        _chartProperties.barChart = true;
            //        _chartProperties.candleSticks = false;
            //        _chartProperties.lineChart = false;
            //        break;
            //    case "CandleChart":
            //        _chartProperties.barChart = false;
            //        _chartProperties.candleSticks = true;
            //        _chartProperties.lineChart = false;
            //        break;
            //}

        }

        void ctrol_OnOrder(string obj)
        {
            Frm.frmOrderEntry frm = new frmOrderEntry(obj);
            frm.ShowDialog();
        }

        void ctrol_OnPeriodicity(string periodicity, int intr, string historyType)
        {
            ePeriodicity prd = (ePeriodicity)Enum.Parse(typeof(ePeriodicity), periodicity, true);
            NewHistoryType Hist = (NewHistoryType)Enum.Parse(typeof(NewHistoryType), historyType, true);
            ChangePeriodicity(prd, intr, Hist);

            if (mainForm.m_DockManager.DocumentManager.ActiveDocument != null && mainForm.m_DockManager.DocumentManager.ActiveDocument.Key.Contains("Chart"))
            {
                string oldKey = mainForm.m_DockManager.DocumentManager.ActiveDocument.Text;//By Kuldeep
                string[] splt = oldKey.Split('-');
                mainForm.m_DockManager.DocumentManager.ActiveDocument.Text = splt[0] + "-" + interval + historyType.ToString();
            }
        }


        internal void LoadChartType(ChartType chartType)
        {
            switch (chartType)
            {
                case ChartType.BAR:
                    ctrol.setBarStyle="standard";
                    break;
                case ChartType.CANDLE:
                    ctrol.setBarStyle="candlestick";
                    break;
                case ChartType.LINE:
                    ctrol.setBarStyle="linear";
                    break;
                default:
                    break;
            }
        }

        public void Zoom(string zoom)
        {
            ctrol.ZoomChart(zoom);
        }

        public void TrackCursor(bool flag)
        {
            ctrol.TrackCursor(flag);
        }

        internal void LoadPriceType(PriceType priceType)
        {
            switch (priceType)
            {
                case PriceType.POINT_AND_FIGURE:
                    ctrol.setPriceStyle="pointandfigure";
                    break;
                case PriceType.RENKO:
                    ctrol.setPriceStyle="renko";
                    break;
                case PriceType.KAGI:
                    ctrol.setPriceStyle="kagi";
                    break;
                case PriceType.THREE_LINE_BREAK:
                    ctrol.setPriceStyle="threelinebreak";
                    break;
                case PriceType.EQUI_VOLUME:
                    ctrol.setPriceStyle="equivolume";
                    break;
                case PriceType.EQUI_VOLUME_SHADOW:
                    ctrol.setPriceStyle="equivolumeshadow";
                    break;
                case PriceType.CANDLE_VOLUME:
                    ctrol.setPriceStyle="candlevolume";
                    break;
                case PriceType.HEIKIN_ASHI:
                    ctrol.setPriceStyle="heikinashi";
                    break;
                case PriceType.STANDARD_CHART:
                    ctrol.setPriceStyle="standard";
                    break;
                default:
                    break;
            }
        }

        public void AddIndicatorList()
        {
            IndicatorSelection selection = (new frmIndicator()).GetIndicatorSelection();
            if (selection.IndicatorName == null)
                return;
            Application.DoEvents();
            ApplyIndicator(selection.IndicatorName);
        }

        public void ApplyIndicator(string str)
        {
            ctrol.ApplyIndicatorNew(str);
        }

        public void ApplyLineStudy(string str)
        {
            ctrol.ApplyLineStudy(str);
        }

        private void UpdateChartNew(string sym, Quote quote)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new PriceQuoteHandler(UpdateChartNew), sym, quote);
                return;
            }
            else
            {
                //Namo 21 March
                //QuoteItem BID = quote._lstItem.Find(i => i._quoteType == QuoteStreamType.BID);
                //bool isData = false;
                ////DateTime dt = DateTime.UtcNow;
                ////DateTime dtnew = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                //Cls.OHLC ohlc = new Cls.OHLC();
                //if (BID != null)
                //{
                //    /**** Modify Date Time here ****/
                //    //PALSA.Cls.BarDataNew LatestBar = _lstCandleStick[_lstCandleStick.Count - 1];
                //    DateTime dt = PALSA.Cls.ClsGlobal.GetDateTimeDT(BID._Time);
                //    DateTime dtNow = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                //    switch (m_Periodicity)
                //    {
                //        case PeriodEnum.Minute:
                //            if (m_Interval == 5 || m_Interval == 10 || m_Interval == 15 || m_Interval == 30)
                //            {
                //                if (dtNow.Minute % m_Interval == 0)
                //                {
                //                    //Create New Bar
                //                    if (!dicOHLC.ContainsKey(dtNow))
                //                    {
                //                        ohlc._Open = BID._Price;
                //                        ohlc._Close = BID._Price;
                //                        ohlc._Low = BID._Price;
                //                        ohlc._High = BID._Price;
                //                        ohlc._Volume = BID._Size;
                //                        dicOHLC.Clear();
                //                        dicOHLC.Add(dtNow, ohlc);
                //                    }
                //                    else
                //                    {
                //                        DateTime dtOld = dicOHLC.Keys.First();
                //                        Cls.OHLC _ohlc = dicOHLC[dtOld];
                //                        if (BID._Price > _ohlc._High)
                //                            _ohlc._High = BID._Price;
                //                        if (BID._Price < _ohlc._Low)
                //                            _ohlc._Low = BID._Price;
                //                        _ohlc._Close = BID._Price;
                //                        _ohlc._Volume = BID._Size;
                //                        dicOHLC[dtOld] = _ohlc;
                //                    }
                //                }
                //                else
                //                {
                //                    // Update Old Bar
                //                    if (dicOHLC.Count > 0)
                //                    {
                //                        DateTime dtOld = dicOHLC.Keys.First();
                //                        Cls.OHLC _ohlc = dicOHLC[dtOld];
                //                        if (BID._Price > _ohlc._High)
                //                            _ohlc._High = BID._Price;
                //                        if (BID._Price < _ohlc._Low)
                //                            _ohlc._Low = BID._Price;
                //                        _ohlc._Close = BID._Price;
                //                        _ohlc._Volume = BID._Size;
                //                        dicOHLC[dtOld] = _ohlc;
                //                    }
                //                    else
                //                    {
                //                        ohlc._Open = BID._Price;
                //                        ohlc._Close = BID._Price;
                //                        ohlc._Low = BID._Price;
                //                        ohlc._High = BID._Price;
                //                        ohlc._Volume = BID._Size;
                //                        dicOHLC.Clear();
                //                        dicOHLC.Add(dtNow, ohlc);
                //                    }
                //                }
                //                foreach (var item in dicOHLC)
                //                {
                //                    if (ctrol != null)
                //                    ctrol.CreateNewOHLC(item.Key, item.Value._Open, item.Value._High, item.Value._Low, item.Value._Close, item.Value._Volume);
                //                    PALSA.Cls.BarDataNew br=new PALSA.Cls.BarDataNew();//Added By Kuldeep for EA and Optimization
                //                    br.TradeDateTime=item.Key;
                //                    br.OpenPrice=item.Value._Open;
                //                    br.HighPrice=item.Value._High;
                //                    br.LowPrice=item.Value._Low;
                //                    br.ClosePrice=item.Value._Close;
                //                    SendToEA(br);
                //                }

                //            }
                //            else if (m_Interval == 1)
                //            {
                //                UpdateChart(sym, quote);
                //            }
                //            break;
                //        case PeriodEnum.Hour:
                //            break;                        
                //        default:
                //            break;
                //    }                 
                //}
            }
        }

        Hashtable hashDATA = new Hashtable();

        private void UpdateChart(string sym, Quote quote)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new PriceQuoteHandler(UpdateChart), sym, quote);
                return;
            }
            else
            {
                //Namo 21 March
                //QuoteItem BID = quote._lstItem.Find(i => i._quoteType == QuoteStreamType.LAST);
                //bool isData = false;
                //if (BID != null)
                //{
                //    //DateTime dt = DateTime.UtcNow;
                //    DateTime dt = PALSA.Cls.ClsGlobal.GetDateTimeDT(BID._Time);
                //    DateTime dtnew = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);

                //    Cls.OHLC ohlc = new Cls.OHLC();
                //    if (ht_RealTimeData.Contains(sym))
                //    {
                //        Hashtable ht_Feed_OHCL = (Hashtable)ht_RealTimeData[sym];
                //        if (ht_Feed_OHCL.Contains(dtnew))
                //        {
                //            ohlc = (Cls.OHLC)ht_Feed_OHCL[dtnew];

                //            if (BID._Price > ohlc._High)
                //                ohlc._High = BID._Price;

                //            if (BID._Price < ohlc._Low)
                //                ohlc._Low = BID._Price;

                //            ohlc._Close = BID._Price;
                //            ohlc._Volume = BID._Size;
                //            ht_Feed_OHCL[dtnew] = ohlc;
                //        }
                //        else
                //        {
                //            ht_Feed_OHCL.Clear();
                //            ohlc._Open = BID._Price;
                //            ohlc._Close = BID._Price;
                //            ohlc._Low = BID._Price;
                //            ohlc._High = BID._Price;
                //            ohlc._Volume = BID._Size;
                //            isData = true;
                //            ht_Feed_OHCL.Add(dtnew, ohlc);
                //        }
                //        ht_RealTimeData[sym] = ht_Feed_OHCL;
                //    }
                //    else
                //    {
                //        ohlc._Open = BID._Price;
                //        ohlc._Close = BID._Price;
                //        ohlc._Low = BID._Price;
                //        ohlc._High = BID._Price;
                //        ohlc._Volume = BID._Size;
                //        Hashtable ht_Feed_OHCL = new Hashtable();
                //        ht_Feed_OHCL.Add(dtnew, ohlc);
                //        ht_RealTimeData.Add(sym, ht_Feed_OHCL);
                //    }

                //    if (ohlc._Close > 0 && ohlc._High > 0 && ohlc._Low > 0 && ohlc._Open > 0)
                //    {
                //        if (ctrol != null)
                //            ctrol.CreateNewOHLC(dtnew, ohlc._Open, ohlc._High, ohlc._Low, ohlc._Close, ohlc._Volume);

                //        PALSA.Cls.BarDataNew br = new PALSA.Cls.BarDataNew();//Added By Kuldeep for EA and Optimization
                //        br.TradeDateTime = dtnew;
                //        br.OpenPrice = ohlc._Open;
                //        br.HighPrice = ohlc._High;
                //        br.LowPrice = ohlc._Low;
                //        br.ClosePrice = ohlc._Close;
                //        SendToEA(br);
                //    }
                //}
            }
        }

        private void SendToEA(Cls.BarDataNew br)
        {
            if (!hashDATA.ContainsKey(br.TradeDateTime))
            {
                hashDATA.Clear();
                hashDATA.Add(br.TradeDateTime, br);
                if (ChartDataAdded != null)
                    ChartDataAdded(br);
            }
            else
            {
                PALSA.Cls.BarDataNew bar = (PALSA.Cls.BarDataNew)hashDATA[br.TradeDateTime];
                if (ChartDataChanged != null)
                    ChartDataChanged(bar);
            }
        }

        private int GetMinutesElapsed(DateTime dtLast)
        {
            return 0; //Math.Abs(
        }

        private Cls.OHLC RealtimeData;
        private string p;
        private int p_2;
        private PeriodEnum pr;
        private FrmMain frmMain;
        private bool p_3;
        public Cls.OHLC REALtimeData
        {
            set
            {
                RealtimeData = value;
            }
        }

        internal void ChangePeriodicity(ePeriodicity periodicity, int interval, NewHistoryType historyType)
        {
            IsChangePeriodicity = true;
           //trol.ClearAllSeries();
            OHLCEntity_ = null;
            //_chartBarType = periodicity;
            ChartHistoryType_ = historyType;
            //lstOHLC.Clear();
            PeriodEnum prd = GetPeriod(periodicity);
            LoadOHLC(m_symbol, interval, "250", prd);
        }
        private PeriodEnum GetPeriod(ePeriodicity periodicity)
        {
            switch (periodicity)
            {
                case ePeriodicity.Minutely_1:
                    return PeriodEnum.Minute;
                case ePeriodicity.Minutely_5:
                    return PeriodEnum.Minute;
                case ePeriodicity.Minutely_15:
                    return PeriodEnum.Minute;
                case ePeriodicity.Minutely_30:
                    return PeriodEnum.Minute;
                case ePeriodicity.Hourly_1:
                    return PeriodEnum.Hour;
                case ePeriodicity.Hourly_4:
                    return PeriodEnum.Hour;
                case ePeriodicity.Daily:
                    return PeriodEnum.Day;
                case ePeriodicity.Weekly:
                    return PeriodEnum.Week;
                case ePeriodicity.Monthly:
                    return PeriodEnum.Month;
                default:
                    return PeriodEnum.Minute;
            }
        }

        internal void Grid(bool p)
        {
            ctrol.Grid(p);
        }

        internal void Volume(bool p)
        {
            ctrol.Volume(p);
        }

        public void CreateContextMenu()
        {
            ctrol.CreateContextMenu();
        }

        private void WPFChartControl_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ctrol.CreateContextMenu();
            //}
        }

        private void WPFChartControl_Load(object sender, EventArgs e)
        {
            //ctrol.CreateContextMenu();
            VisibleGrid();

            mainForm.m_DockManager.DocumentManager.DocumentClosing += new Nevron.UI.WinForm.Controls.DocumentCancelEventHandler(DocumentManager_DocumentClosing);
        }

        void DocumentManager_DocumentClosing(object sender, Nevron.UI.WinForm.Controls.DocumentCancelEventArgs e)
        {
            //Namo 21 March
           // PALSA.Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
        }

        //public bool CrossHairs { get { return ctrol.CrossHair; } set { ctrol.CrossHair=value;} }

        internal void SetCrossHairs()
        {
            ctrol.CrossHair();
        }

        internal void HideGrid()
        {
            ctrol.SetColor("Grid", System.Drawing.Color.FromArgb(153, 204,255));
            ctrol.HideGrid();
        }

        internal void VisibleGrid()
        {
            ctrol.SetColor("Grid", System.Drawing.Color.FromArgb(153, 204,255));
            ctrol.VisibleGrid();
        }

        internal void SaveChart()
        {
            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "(*.icx)|*.icx";
            objSaveFileDialog.Title = "Save";
            objSaveFileDialog.DefaultExt = ".icx";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                //ui_ocxStockChart.SaveFile(objSaveFileDialog.FileName);
                ctrol.SaveChart(objSaveFileDialog.FileName);
            }

           
        }

        internal void PrintChart()
        {
            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "(*.png)|*.png";
            objSaveFileDialog.Title = "Print";
            objSaveFileDialog.DefaultExt = ".png";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                //ui_ocxStockChart.SaveFile(objSaveFileDialog.FileName);
                ctrol.PrintChart(objSaveFileDialog.FileName);
            }
        }

        internal void Chart3DStyle(bool p)
        {
            ctrol.Chart3dStyle(p);
        }

        internal void AddSymbolObjetc(string name, string symbol)
        {
            ctrol.AddSymbolObject(name, symbol);
        }

        internal Cls.BarDataNew[] GetDataFromChart()
        {
            return Enumerable.ToArray(_lstCandleStick);
        }

        internal long GetRecordByJDate(double jDate)
        {
            //return ctrol.GetRecord(jDate);
            return 0;
        }
    }
}
