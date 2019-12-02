using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PALSA.Frm;
using PALSA.Cls;
using System.Collections;
using AxSTOCKCHARTXLib;
using STOCKCHARTXLib;
//using Logging;
using System.IO;
using M4.Charts;
using ModulusFE.OMS.Interface;

namespace PALSA.uctl
{
    public partial class ctlNewChart : UctlBase
    {
        private const int OBJECT_LINE_TEXT = 504;
        private const int OBJECT_LINE_STANDARD = 605;
        private const int OBJECT_LINE_ELLIPSE = 606;
        private const int OBJECT_LINE_ERRORCHANNEL = 607;
        private const int OBJECT_LINE_FIBARCS = 608;
        private const int OBJECT_LINE_FIBFAN = 609;
        private const int OBJECT_LINE_FIBRETRACEMENT = 610;
        private const int OBJECT_LINE_FIBTIMEZONE = 611;
        private const int OBJECT_LINE_FREEHAND = 612;
        private const int OBJECT_LINE_GANNFAN = 613;
        private const int OBJECT_LINE_QUADRANTLNES = 614;
        private const int OBJECT_LINE_RAFFREGRESSION = 615;
        private const int OBJECT_LINE_RECTANGLE = 616;
        private const int OBJECT_LINE_SPEEDLINES = 617;
        private const int OBJECT_LINE_TIRONELEVELS = 618;
        //private const int OBJECT_LINE_VERTICAL = 619;
        //private const int OBJECT_LINE_HORIZONTAL = 620;
        private const int OBJECT_LINE_ORDER = 621;
        private const int OBJECT_GENERIC = 622;

        private const int otBuySymbolObject = 1;
        private const int otSellSymbolObject = 2;
        private const int otExitSymbolObject = 3;
        private const int otExitLongSymbolObject = 5;
        private const int otExitShortSymbolObject = 6;
        private const int otSignalSymbolObject = 7;
        private const int otIndicator = 497;
        private const int otStockBarChart = 500;
        private const int otCandleChart = 501;
        private const int otLineChart = 502;
        private const int otVolumeChart = 503;
        private const int otTextObject = 504;
        private const int otSymbolObject = 505;
        private const int otStockBarChartHLC = 506;
        private const int otOrder = 507;
        private const int otStaticTextObject = 510;
        private const int otLineObject = 601;
        private const int otTrendLineObject = 604;
        private const int otLineStudyObject = 604;

        private static int count;
        private readonly Hashtable m_Indicators = new Hashtable();

        public NewHistoryType ChartHistoryType_ = NewHistoryType.MINUTE;
        private OHLCEntity OHLCEntity_;
        private int _barInterval = 1;
        public ePeriodicity _chartBarType = ePeriodicity.Minutely_1;
        private ChartProperty _chartProperties = new ChartProperty();
        private string _chartSymbol = "DEMO";
        private int _chartYAxisPrecision = 6;

        private string _formkey;
        private bool _isShowVolume;
        private DateTime _lastDateTime = DateTime.UtcNow;
        public ChartType crtChartType;
        public PriceType crtPriceType = PriceType.STANDARD_CHART;
        public bool m_UserEditing;
        private string m_name;
        private int m_objectType;
        private bool m_showAskLine = true;
        private PALSA.Cls.PeriodEnum PrdEnum = PALSA.Cls.PeriodEnum.Year;
        private string numBars = "";
        //private Form parentForm;        
        public ctlNewChart()
        {
            InitializeComponent();
            ui_ocxStockChart.ScalePrecision = 5;
        }

        public string m_Symbol
        {
            set { _chartSymbol = value; }
            get { return _chartSymbol; }
        }

        public static int Count
        {
            get { return count; }
        }

        public int BarInterval
        {
            get { return _barInterval; }
        }

        public PALSA.Cls.PeriodEnum prdEnum
        {
            set { PrdEnum = value; }
            get { return PrdEnum; }
        }
        public string Num_Bars
        {
            get { return numBars; }
            set { numBars = value; }
        }
        BackgroundWorker bgChart = new BackgroundWorker();
        private void BindContextMenuEvents()
        {
            try
            {
                //mnuEditSeries.Click += mnuEditSeries_Click;
                //mnuDeleteObject.Click += mnuDeleteObject_Click;
                //mnuDeleteSeries.Click += mnuDeleteSeries_Click;
                //ctmLines.Showing += new CancelEventHandler(ctmLines_Showing);


                ////added for CtmDelete Objects  
                //mnuProperty.Click += new CommandEventHandler(mnuProperty_Click);
                //mnuDeleteObject.Click += new CommandEventHandler(mnuDeleteObject_Click);
                //mnuObjList.Click += new CommandEventHandler(mnuObjList_Click);
                //mnuSelDelete.Click += new CommandEventHandler(mnuSelDelete_Click);
                //mnuUnselAll.Click += new CommandEventHandler(mnuUnselAll_Click);
                //mnuUnselect.Click += new CommandEventHandler(mnuUnselect_Click);
                //mnuUndoDelete.Click += new CommandEventHandler(mnuUndoDelete_Click);
                //mnuIndicatorList.Click += new CommandEventHandler(mnucIndicatorList_Click);
                //mnuIndProperty.Click += new CommandEventHandler(mnuIndProperty_Click);
                //mnuDeleteIndicatorWindow.Click += new CommandEventHandler(mnuDeleteIndicatorWindow_Click);
                //ctmClose.Click += new CommandEventHandler(ctmClose_Click);
                //ctmModify.Click += new CommandEventHandler(ctmModify_Click);
                //ctmReverse.Click += new CommandEventHandler(ctmReverse_Click);
                //mnu2D.Click += new CommandEventHandler(mnu2D_Click);
                //mnu3D.Click += new CommandEventHandler(mnu3D_Click);
                //this.mnuUserPreferences.Properties.Visible = false;
            }
            catch
            {
                //Logger.LogEx(ex, "ctlChart", "BindContextMenuEvents()");
            }

        }

        volatile List<OHLC> lstOHLC = new List<OHLC>();

        public void InitChartData(string Key,List<OHLC> lstOHLC=null)//Default chart for 1 Min hardcoded
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into InitChartData(DataGridViewRow row) Method");
            _chartBarType = ePeriodicity.Minutely_1;
            string[] x = Key.Split('-');
            Text = x[0] + " : " + _chartBarType.ToString().Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0] + "_" + _barInterval;


            string sym = x[0].ToString();
            PALSA.Cls.PeriodEnum period = PALSA.Cls.PeriodEnum.Year;
            string[] periodicity = x[1].Split(' ');
            if (periodicity[1].ToLower().StartsWith("min"))
            {
                period = PALSA.Cls.PeriodEnum.Minute;
            }
            else if (periodicity[1].StartsWith("D"))
            {
                period = PALSA.Cls.PeriodEnum.Day;
            }
            else if (periodicity[1].StartsWith("H"))
            {
                period = PALSA.Cls.PeriodEnum.Hour;
            }
            else if (periodicity[1].ToLower().StartsWith("mon"))
            {
                period = PALSA.Cls.PeriodEnum.Month;
            }
            else if (periodicity[1].StartsWith("W"))
            {
                period = PALSA.Cls.PeriodEnum.Week;
            }
            else if (periodicity[1].StartsWith("Y"))
            {
                period = PALSA.Cls.PeriodEnum.Year;
            }
            LoadRTChart(sym, Convert.ToInt32(x[1].Split(' ')[0]), "250", period,lstOHLC);
        }
        public void InitChartData(DataGridViewRow row)//Default chart for 1 Min hardcoded
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into InitChartData(DataGridViewRow row) Method");
            _chartBarType = ePeriodicity.Minutely_1;

            Text = row.Cells["ClmContractName"].Value + " : " + _chartBarType.ToString().Split(
                   new[] {'_'}, StringSplitOptions.RemoveEmptyEntries)[0] + "_" + _barInterval;

            string sym = row.Cells["ClmContractName"].Value.ToString();
            LoadRTChart(sym, 1, "250", PALSA.Cls.PeriodEnum.Minute);
        }

        void bgChart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
        }

        void bgChart_DoWork(object sender, DoWorkEventArgs e)
        {
            lstOHLC = clsTWSDataManagerJSON.INSTANCE.GetOHLC(DateTime.UtcNow, m_Symbol, _barInterval, Num_Bars, (int)PrdEnum);       
            AddChartData(lstOHLC);
        }

        private void LoadRTChart(string sym, int interval, string bars, Cls.PeriodEnum periodEnum, List<OHLC> lstOHLC = null)
        {
            m_Symbol = sym;
            _barInterval = interval;
            PrdEnum = periodEnum;
            Num_Bars = bars;

            BindChartEvents();
            AddAllSeries();
            //SetChartBarInterval();
            if (File.Exists("./OHLCLog/" + m_Symbol))
            {
                ui_ocxStockChart.LoadFile(Application.StartupPath + "\\OHLCLog\\" +
                                          sym);
            }

            #region "     Code for reading data from file    "

            //if (File.Exists("./OHLCLog/" + row.Cells["ClmContractName"].Value.ToString() + "_1_MinuteBar.txt"))
            //{
            //    List<OHLC> lstOHCL = new List<OHLC>();
            //    FileStream objFileStream = new FileStream("./OHLCLog/" + row.Cells["ClmContractName"].Value.ToString() + "_1_MinuteBar.txt",
            //        FileMode.Open, FileAccess.Read);

            //    StreamReader objStreamReader = new StreamReader(objFileStream);
            //    for (int index = 0; index < 50; index++)
            //    {
            //        OHLC objOHLC = new OHLC();
            //        string []str=objStreamReader.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            //        objOHLC._Open =Convert.ToDouble(str[1]);
            //        objOHLC._High = Convert.ToDouble(str[3]);
            //        objOHLC._Low = Convert.ToDouble(str[5]);
            //        objOHLC._Close = Convert.ToDouble(str[7]);
            //        objOHLC._Volume = Convert.ToInt32(str[9]);
            //        objOHLC._OHLCTime = Convert.ToDateTime(str[15]+" " + str[16] +" "+ str[17]);

            //        lstOHCL.Add(objOHLC);
            //    }

            //    AddChartData(lstOHCL);
            //}

            #endregion "     Code for reading data from file    "
            if (lstOHLC != null)
            {
                AddChartData(lstOHLC);
                //Namo 21 March
                //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
                //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
            }
            else
            {
                bgChart = null;
                bgChart = new BackgroundWorker();
                bgChart.WorkerSupportsCancellation = true;
                bgChart.DoWork += new DoWorkEventHandler(bgChart_DoWork);
                bgChart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgChart_RunWorkerCompleted);
                bgChart.RunWorkerAsync();
            }
        }
        
        private void BindChartEvents()
        {
            ui_ocxStockChart.ItemRightClick -= new AxSTOCKCHARTXLib._DStockChartXEvents_ItemRightClickEventHandler(ui_ocxStockChart_ItemRightClick);
            ui_ocxStockChart.ItemRightClick += new AxSTOCKCHARTXLib._DStockChartXEvents_ItemRightClickEventHandler(ui_ocxStockChart_ItemRightClick);
        }
        
        public void InitChartData(string symbol, ePeriodicity periodiciy)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into InitChartData(string symbol,ePeriodicity periodiciy) Method");

            count += 1;
            _formkey = _formkey = CommandIDS.NEW_CHART.ToString() + "/" + Convert.ToString(count) + "/" + symbol;
            m_Symbol = symbol;
            switch (periodiciy)
            {
                case ePeriodicity.Minutely_1:
                    ChangePeriodicity(ePeriodicity.Minutely_1, 1, NewHistoryType.MINUTE);
                    break;
                case ePeriodicity.Minutely_5:
                    ChangePeriodicity(ePeriodicity.Minutely_1, 5, NewHistoryType.MINUTE);
                    break;
                case ePeriodicity.Minutely_15:
                    ChangePeriodicity(ePeriodicity.Minutely_1, 15, NewHistoryType.MINUTE);
                    break;
                case ePeriodicity.Minutely_30:
                    ChangePeriodicity(ePeriodicity.Minutely_1, 30, NewHistoryType.MINUTE);
                    break;
                case ePeriodicity.Hourly_1:
                    ChangePeriodicity(ePeriodicity.Hourly_1, 1, NewHistoryType.HOUR);
                    break;
                case ePeriodicity.Hourly_4:
                    ChangePeriodicity(ePeriodicity.Hourly_1, 4, NewHistoryType.HOUR);
                    break;
                case ePeriodicity.Daily:
                    ChangePeriodicity(ePeriodicity.Daily, 1, NewHistoryType.DAY);
                    break;
                case ePeriodicity.Weekly:
                    ChangePeriodicity(ePeriodicity.Weekly, 1, NewHistoryType.WEEK);
                    break;
                case ePeriodicity.Monthly:
                    ChangePeriodicity(ePeriodicity.Monthly, 1, NewHistoryType.MONTH);
                    break;
            }

            BindContextMenuEvents();
            AddAllSeries();
            Text = symbol + " : " + periodiciy.ToString();
            SetChartBarInterval();
            //if (File.Exists("./OHLCLog/" + symbol))
            //{
            //    ui_ocxStockChart.LoadFile(Application.StartupPath + "\\OHLCLog\\" + symbol);
            //}

            AddChartData(lstOHLC);

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from InitChartData(string symbol,ePeriodicity periodiciy) Method");
        }

        public void AddAllSeries()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddAllSeries Method");

            //First setup the chart for real time data
            ui_ocxStockChart.RemoveAllSeries();
            //First add a panel (chart area) for the OHLC data:
            long panel = ui_ocxStockChart.AddChartPanel();
            ui_ocxStockChart.Symbol = m_Symbol;

            //===Now add the open, high, low and close series to that panel:
            ui_ocxStockChart.AddSeries(m_Symbol + ".open", SeriesType.stCandleChart, (int)panel);
            ui_ocxStockChart.AddSeries(m_Symbol + ".high", SeriesType.stCandleChart, (int)panel);
            ui_ocxStockChart.AddSeries(m_Symbol + ".low", SeriesType.stCandleChart, (int)panel);
            ui_ocxStockChart.AddSeries(m_Symbol + ".close", SeriesType.stCandleChart, (int)panel);
            ui_ocxStockChart.AddSeries(m_Symbol + ".volume", SeriesType.stCandleChart, (int)panel);
            //ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".% move", false);

            ui_ocxStockChart.AddSeries(m_Symbol + ".line", SeriesType.stLineChart, (int)panel);
            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".line", false);

            //Change the color:
            //ui_ocxStockChart.set_SeriesColor(m_Symbol + ".close", ColorTranslator.ToOle(Color.White));
            ui_ocxStockChart.set_SeriesColor(m_Symbol + ".close", ColorTranslator.ToOle(Color.Lime));
            

            crtChartType = ChartType.CANDLE; // code by vijay            

            //===Add Volume Panel
            panel = ui_ocxStockChart.AddChartPanel();
            //Change volume color and weight of the volume panel:
            ui_ocxStockChart.set_SeriesColor(m_Symbol + ".volume", ColorTranslator.ToOle(Color.LimeGreen));
            //ui_ocxStockChart.set_SeriesWeight(m_Symbol + ".volume", 1); //By Ratan for removing Volume

            //Resize the volume panel to make it smaller
            ui_ocxStockChart.set_PanelY1(1, (int)Math.Round(ui_ocxStockChart.Height * 0.8));
            // edit - laxman, Set some initial properties
            ui_ocxStockChart.LineColor = Color.Red;

            ui_ocxStockChart.RealTimeXLabels = true;
            ui_ocxStockChart.ThreeDStyle = true;
            ui_ocxStockChart.HorizontalSeparators = true;
            ui_ocxStockChart.DisplayTitles = true;
            ui_ocxStockChart.ScalePrecision = _chartYAxisPrecision;
            ui_ocxStockChart.DisplayTitleBorder = true;
            ui_ocxStockChart.MaxDisplayRecords = Width / 11;
            //ui_ocxStockChart.UpColor = Color.Green;
            //ui_ocxStockChart.DownColor = Color.Red;
            ui_ocxStockChart.CandleUpOutlineColor = Color.Green;
            ui_ocxStockChart.CandleDownOutlineColor = Color.Red;

            ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close", ColorTranslator.ToOle(Color.Black));

            //==Colors
            ui_ocxStockChart.BackGradientTop = Color.White;
            ui_ocxStockChart.BackGradientBottom = Color.White;
            ui_ocxStockChart.ChartBackColor = Color.White;
            ui_ocxStockChart.Gridcolor = Color.Silver;
            ui_ocxStockChart.ChartForeColor = Color.Black;
            ui_ocxStockChart.UpColor = Color.Lime;
            ui_ocxStockChart.DownColor = Color.Red;
            ui_ocxStockChart.HorizontalSeparatorColor = Color.Silver;
            //m_SelectionBorderColor = Color.Blue;

            //ui_ocxStockChart.BackGradientTop = Color.Black;
            //ui_ocxStockChart.BackGradientBottom = Color.FromArgb(0xd5, 0xe7, 0xff);
            //ui_ocxStockChart.HorizontalSeparatorColor = Color.SkyBlue;
            
            ui_ocxStockChart.ThreeDStyle = false;
            ui_ocxStockChart.XGrid = true;
            ui_ocxStockChart.YGrid = true;
            ui_ocxStockChart.CrossHairs = false;
            UpdateYScale();
            ui_ocxStockChart.Update();


            #region Commented Properties of Galaxy Chart

            //ui_ocxStockChart.ChartBackColor = Color.Black;
            //ui_ocxStockChart.ChartForeColor = Color.Yellow;
            //ui_ocxStockChart.ShowOHLC = true;
            //ui_ocxStockChart.ShowVolumes = true;
            //ui_ocxStockChart.CurrentTickLine = true;
            //ui_ocxStockChart.AddHorizontalLine(-1, -1);
            //ui_ocxStockChart.AddVerticalLines(-1);
            //ui_ocxStockChart.PriceStyle = PriceStyle.psCandleVolume;
            //ui_ocxStockChart.CurrentTickLine = true;
            //Kului_ocxStockChart.ShowVolumes = _isShowVolume;
            #endregion

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddAllSeries Method");
        }

        private void UpdateYScale()
        {
            double max = ui_ocxStockChart.GetMaxValue(ui_ocxStockChart.Symbol + ".high");
            double min = ui_ocxStockChart.GetMinValue(ui_ocxStockChart.Symbol + ".low");
            //By Kuldeep
            ui_ocxStockChart.YScaleMinTick = (max - min) < 1.0 ? 0.05 : 0.25;        
            ui_ocxStockChart.ScalePrecision = 5;
        }

        public void SetChartBarInterval()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetChartBarInterval Method");

            if (_chartBarType == ePeriodicity.Minutely_1)
            {
                if (_barInterval == 1)
                    ui_ocxStockChart.BarInterval = 0;
                else if (_barInterval == 5)
                    ui_ocxStockChart.BarInterval = 1;
                else if (_barInterval == 15)
                    ui_ocxStockChart.BarInterval = 2;
                else if (_barInterval == 30)
                    ui_ocxStockChart.BarInterval = 3;
            }
            else if (_chartBarType == ePeriodicity.Hourly_1)
            {
                if (_barInterval == 1)
                    ui_ocxStockChart.BarInterval = 4;
                else if (_barInterval == 4)
                    ui_ocxStockChart.BarInterval = 5;
            }
            else if (_chartBarType == ePeriodicity.Daily)
            {
                ui_ocxStockChart.BarInterval = 6;
            }
            else if (_chartBarType == ePeriodicity.Weekly)
            {
                ui_ocxStockChart.BarInterval = 7;
            }
            else if (_chartBarType == ePeriodicity.Monthly)
            {
                ui_ocxStockChart.BarInterval = 8;
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetChartBarInterval Method");
        }

        public void AddChartData(List<OHLC> bars)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddChartData Method");
            Action a = () =>
            {
                //yyyy-mm-DD-hh-mm-ss
                for (int n = 0; n < bars.Count; n++)
                {
                    //string[] strArr = bars[n]._OHLCTime.Split('-');
                    //double jdate = ui_ocxStockChart.ToJulianDate(Convert.ToInt32(strArr[0]), Convert.ToInt32(strArr[1]),
                    //                                             Convert.ToInt32(strArr[2]), Convert.ToInt32(strArr[3]),
                    //                                             Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]));
                    
                    double jdate = 0;

                    ui_ocxStockChart.AppendValue(m_Symbol + ".open", jdate, bars[n]._Open);
                    ui_ocxStockChart.AppendValue(m_Symbol + ".high", jdate, bars[n]._High);
                    ui_ocxStockChart.AppendValue(m_Symbol + ".low", jdate, bars[n]._Low);
                    ui_ocxStockChart.AppendValue(m_Symbol + ".close", jdate, bars[n]._Close);
                    ui_ocxStockChart.AppendValue(m_Symbol + ".volume", jdate, bars[n]._Volume);
                    ui_ocxStockChart.AppendValue(m_Symbol + ".line", jdate, bars[n]._Close);
                    if (n % 100 == 0) ui_ocxStockChart.Update();
                } //for
                if (bars.Count > 0)
                {
                    _lastDateTime = bars[bars.Count - 1]._OHLCTime;
                }

                // Update the chart
                ui_ocxStockChart.Update(); // For VS.NET 2005
            };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(a);
            }
            else
            {
                a();
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddChartData Method");
        }

        public void AddBarUpdate(OHLC ohlc)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddBarUpdate Method");

            if (ui_ocxStockChart.IsDisposed)
                return;
            bool isNewNBar = false;

            if (ohlc._OHLCTime > _lastDateTime)
                isNewNBar = true;

            if (isNewNBar)
            {
                int RecordCount = ui_ocxStockChart.RecordCount;
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".open", ui_ocxStockChart.RecordCount, ohlc._Open);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".high", ui_ocxStockChart.RecordCount, ohlc._High);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".low", ui_ocxStockChart.RecordCount, ohlc._Low);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".close", ui_ocxStockChart.RecordCount, ohlc._Close);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".volume", ui_ocxStockChart.RecordCount, ohlc._Volume);

                double jdate = ui_ocxStockChart.ToJulianDate(ohlc._OHLCTime.Year, ohlc._OHLCTime.Month,
                                                             ohlc._OHLCTime.Day, ohlc._OHLCTime.Hour,
                                                             ohlc._OHLCTime.Minute, ohlc._OHLCTime.Second);

                ui_ocxStockChart.AppendValue(_chartSymbol + ".open", jdate, ohlc._Open);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".high", jdate, ohlc._High);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".low", jdate, ohlc._Low);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".close", jdate, ohlc._Close);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".volume", jdate, ohlc._Volume);
            }
            else
            {
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".open", ui_ocxStockChart.RecordCount, ohlc._Open);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".high", ui_ocxStockChart.RecordCount, ohlc._High);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".low", ui_ocxStockChart.RecordCount, ohlc._Low);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".close", ui_ocxStockChart.RecordCount, ohlc._Close);
                ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".volume", ui_ocxStockChart.RecordCount, ohlc._Volume);
                //v);
            }

            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddBarUpdate Method");
        }
        private void ui_ocxStockChart_MouseMoveEvent(object sender, _DStockChartXEvents_MouseMoveEvent e)
        {
            m_Value = ui_ocxStockChart.GetYValueByPixel(e.y);
            m_Record = e.record;
        }

        private void ui_ocxStockChart_ItemMouseMove(object sender, _DStockChartXEvents_ItemMouseMoveEvent e)
        {
        }

        private void ui_ocxStockChart_PaintEvent(object sender, _DStockChartXEvents_PaintEvent e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_ocxStockChart_PaintEvent Method");

            double tick = 0;
            int p = 0;
            string Symbol = ui_ocxStockChart.Symbol;
            // See if this Panel is the one with the OHLC bar chart
            p = ui_ocxStockChart.GetPanelBySeriesName(Symbol + ".close");
            if (p != e.panel) return;

            // Show the real-time tick box
            if (ui_ocxStockChart.RealTimeXLabels)
            {
                tick = ui_ocxStockChart.GetValue(Symbol + ".close", ui_ocxStockChart.RecordCount);
                ui_ocxStockChart.ShowLastTick(Symbol + ".close", tick);
                if (m_showAskLine)
                {
                    //QuoteResponse Qa = QuoteManager.getQuoteManager().getLastQuote(ui_ocxStockChart.Symbol);
                    //ui_ocxStockChart.ShowAskLine(Symbol + ".close", Convert.ToDouble(Qa.AskPx_.ToString()));
                }
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_ocxStockChart_PaintEvent Method");
        }

        //public void PriceUpdate(QuoteItem quoteItem) //QuoteResponse MD)
        //{
        //    //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into PriceUpdate Method");

        //    //DS_ = uctlNewHistoryManager.GetHistoryMgrInstance().GetMyWatchItem(this).DSOHLC_;
        //    double Price = 0.0;
        //    double Volume = 0.0;

        //    switch (quoteItem._quoteType)
        //    {
        //        case QuoteStreamType.ASK:
        //            {
        //            }
        //            break;
        //        case QuoteStreamType.BID:
        //            {
        //                Price = quoteItem._Price;
        //                Volume = quoteItem._Size;
        //            }
        //            break;
        //        case QuoteStreamType.HIGH:
        //            break;
        //        case QuoteStreamType.LAST:
        //            break;
        //        case QuoteStreamType.LOW:
        //            break;
        //        case QuoteStreamType.VOLUME:
        //            break;
        //    }
        //    if (Convert.ToInt32(Price) != 0)
        //    {
        //        if (PrdEnum == PALSA.Cls.PeriodEnum.Minute || PrdEnum == PALSA.Cls.PeriodEnum.Hour)
        //        {
        //            if (OHLCEntity_ == null)
        //            {
        //                TimeSpan ts = CalculateTimeSpan();
        //                DateTime OHLCTIME = getOhlcDate(ClsGlobal.GetDateTimeDT(quoteItem._Time));
        //                OHLCEntity_ = new OHLCEntity(Price, Volume, OHLCTIME, ts);


        //                double jdate = ui_ocxStockChart.ToJulianDate(OHLCTIME.Year,
        //                                                             OHLCTIME.Month,
        //                                                             OHLCTIME.Day,
        //                                                             OHLCTIME.Hour,
        //                                                             OHLCTIME.Minute,
        //                                                             OHLCTIME.Second);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".open", jdate, Price);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".high", jdate, Price);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".low", jdate, Price);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".close", jdate, Price);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".volume", jdate, Volume); // Volume);
        //                ui_ocxStockChart.AppendValue(_chartSymbol + ".line", jdate, Price);
        //            }
        //            else
        //            {
        //                double o, h, l, c, v;
        //                o = h = l = c = v = 0.0;
        //                DateTime dt = DateTime.UtcNow;
        //                bool isNewNBar = OHLCEntity_.UpdateValues(Price, Volume, ClsGlobal.GetDateTimeDT(quoteItem._Time),
        //                                                          out o, out h, out l, out c, out v, out dt);

        //                double jdate = ui_ocxStockChart.ToJulianDate(dt.Year,
        //                                         dt.Month,
        //                                         dt.Day,
        //                                         dt.Hour,
        //                                         dt.Minute,
        //                                         dt.Second);

        //                if (isNewNBar)
        //                {
        //                    int RecordCount = ui_ocxStockChart.RecordCount;
        //                    //ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".open", ui_ocxStockChart.RecordCount, o);
        //                    //ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".high", ui_ocxStockChart.RecordCount, h);
        //                    //ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".low", ui_ocxStockChart.RecordCount, l);
        //                    //ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".close", ui_ocxStockChart.RecordCount, c);
        //                    //ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".volume", ui_ocxStockChart.RecordCount,
        //                    //                                   v); //v);


        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".open", jdate, Price);
        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".high", jdate, Price);
        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".low", jdate, Price);
        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".close", jdate, Price);
        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".volume", jdate, v);
        //                    ui_ocxStockChart.AppendValue(m_Symbol + ".line", jdate, Price);
        //                }
        //                else
        //                {
        //                    if (ui_ocxStockChart != null) //condition by vijay
        //                    {

        //                        //ui_ocxStockChart.EditValue(_chartSymbol + ".open", jdate, o);
        //                        //ui_ocxStockChart.EditValue(_chartSymbol + ".high", jdate, h);
        //                        //ui_ocxStockChart.EditValue(_chartSymbol + ".low", jdate, l);
        //                        //ui_ocxStockChart.EditValue(_chartSymbol + ".close", jdate, c);
        //                        //ui_ocxStockChart.EditValue(_chartSymbol + ".volume", jdate, v);

        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".open", ui_ocxStockChart.RecordCount, o);
        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".high", ui_ocxStockChart.RecordCount, h);
        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".low", ui_ocxStockChart.RecordCount, l);
        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".close", ui_ocxStockChart.RecordCount, c);
        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".volume", ui_ocxStockChart.RecordCount, v);
        //                        ui_ocxStockChart.EditValueByRecord(m_Symbol + ".line", ui_ocxStockChart.RecordCount, c);
        //                    }
        //                }
        //            }
        //            ui_ocxStockChart.Update();
        //        }
        //    }

        //    //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from PriceUpdate Method");
        //}

        private TimeSpan CalculateTimeSpan()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into CalculateTimeSpan Method");

            TimeSpan timeSpan = TimeSpan.FromMinutes(_barInterval);
            switch (_chartBarType)
            {
                case ePeriodicity.Secondly:
                    {
                        timeSpan = TimeSpan.FromSeconds(_barInterval);
                    }
                    break;
                case ePeriodicity.Minutely_1:
                    {
                        timeSpan = TimeSpan.FromMinutes(_barInterval);
                    }
                    break;
                case ePeriodicity.Minutely_5:
                    {
                        timeSpan = TimeSpan.FromMinutes(_barInterval);
                    }
                    break;
                case ePeriodicity.Minutely_15:
                    {
                        timeSpan = TimeSpan.FromMinutes(_barInterval);
                    }
                    break;
                case ePeriodicity.Minutely_30:
                    {
                        timeSpan = TimeSpan.FromMinutes(_barInterval);
                    }
                    break;
                case ePeriodicity.Hourly_1:
                    {
                        timeSpan = TimeSpan.FromHours(_barInterval);
                    }
                    break;
                case ePeriodicity.Daily:
                    {
                        timeSpan = TimeSpan.FromDays(_barInterval);
                    }
                    break;
                case ePeriodicity.Weekly:
                    {
                        timeSpan = TimeSpan.FromDays(7 * _barInterval);
                    }
                    break;
                case ePeriodicity.Monthly:
                    {
                        timeSpan = TimeSpan.FromDays(30 * _barInterval);
                    }
                    break;
            }
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from CalculateTimeSpan Method");

            return timeSpan;
        }

        public DateTime getOhlcDate(DateTime DT)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into getOhlcDate Method");

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
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from getOhlcDate Method");

            return ReturnDateTime;
        }

        private void ctlNewChart_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ctlNewChart_Load Method");
            //parentForm = ParentForm;
            //((FrmMain)parentForm).ui_nmnuTechnicalAnalysis.Enabled = true;
            ui_ocxStockChart.EnumIndicators();
         
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ctlNewChart_Load Method");
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> ddQuotes)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into INSTANCE_onPriceUpdate Method");

            //Namo 21 March
            //foreach (var item in ddQuotes)
            //{
            //    foreach (QuoteItem quoteItem in item.Value._lstItem)
            //    {
            //        string[] str = item.Key.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            //        if (_chartSymbol == str[str.Count() - 1])
            //        {
            //            PriceUpdate(quoteItem);
            //        }
            //    }
            //}

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from INSTANCE_onPriceUpdate Method");
        }
        private void ui_ocxStockChart_OnRButtonDown(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_ocxStockChart_OnRButtonDown Method");

            //m_UserEditing = true;
            ui_ocxStockChart.UserEditing = true;
            //ui_cmsChart.Show(MousePosition.X, MousePosition.Y);
            //int m_objectType = (int)e.objectType;

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_ocxStockChart_OnRButtonDown Method");
        }

        private void ui_ocxStockChart_OnLButtonDown(object sender, EventArgs e)
        {
            //m_UserEditing = true;
            //if (frmMainGTS.GetReference().submnuHLine.Checked == true)
            {
                //try
                {
                    //ui_ocxStockChart.AddHorizontalLine(0, m_Value);
                    //frmMainGTS.GetReference().submnuHLine.Checked = false;
                }
                //catch (Exception ex)
                {
                    //Logger.LogEx(ex, "ctlChart", "ui_ocxStockChart_OnLButtonDown(object sender, EventArgs e) Region1");
                }
            }
            //if (frmMainGTS.GetReference().submnuVLine.Checked == true)
            //{
            //    try
            //    {
            //        ui_ocxStockChart.AddVerticalLines(m_Value);
            //        frmMainGTS.GetReference().submnuVLine.Checked = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        //Logger.LogEx(ex, "ctlChart", "ui_ocxStockChart_OnLButtonDown(object sender, EventArgs e) Region2");
            //    }
            //}
        }
        private bool m_Menu;
        private void ui_ocxStockChart_ItemRightClick(object sender, _DStockChartXEvents_ItemRightClickEvent e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_ocxStockChart_ItemRightClick Method");

            m_objectType = (int)e.objectType;
            m_name = e.name;
            Application.DoEvents();
            m_UserEditing = true;
            ui_ocxStockChart.UserEditing = true;
            //ui_cmsChart.Show(MousePosition.X, MousePosition.Y);


            Point p = new Point { X = (Cursor.Position.X + Left), Y = (Cursor.Position.Y + Top) };
            //mnuObjectProperties.Enabled = false;

            switch (e.objectType)
            {
                case ObjectType.otIndicator:
                case ObjectType.otVolumeChart:
                case ObjectType.otLineChart:
                case ObjectType.otCandleChart:
                case ObjectType.otStockBarChart:
                    mnuEditSeries.Enabled = true;
                    m_Menu = true;
                    bool needdelete = true;
                    if ((m_name == m_Symbol + ".open") || (m_name == m_Symbol + ".high") || (m_name == m_Symbol + ".low") || (m_name == m_Symbol + ".close") || (m_name == m_Symbol + ".volume") || (m_name == m_Symbol + ".line") || (m_name == m_Symbol + ".% move"))
                    {
                        needdelete = false;
                        ui_cmsChart.Show(MousePosition.X, MousePosition.Y);
                    }
                    if (needdelete)
                    {
                        //ctmDeleteSeries.Show(this, p);
                    }
                    ui_ocxStockChart.Update();
                    break;
                case ObjectType.otTextObject:
                    //mnuObjectProperties.Enabled = true;
                    m_Menu = true;
                    //ctmDeleteObject.Show(this, p);
                    break;
                case ObjectType.otLineStudyObject:
                    break;
                case ObjectType.otSymbolObject:
                case ObjectType.otLineObject:
                    m_Menu = true;
                    //ctmDeleteObject.Show(this, p);
                    break;
                case ObjectType.otOrder:
                    m_Menu = true;
                    //cmdDeleteOrders.Show(this, p);
                    break;
            }



            #region Commented

            //from galaxy
            //SetText();
            //Point p = new Point { X = (Cursor.Position.X + Left), Y = (Cursor.Position.Y + Top) };

            //m_name = EventArgs.name;
            ////if (!m_name.Contains(":"))
            ////{
            ////    m_name += " " +DateTime.UtcNow;
            ////}
            //m_objectType = (int)EventArgs.objectType;
            //switch (EventArgs.objectType)
            //{
            //    case (ObjectType)OBJECT_GENERIC:
            //        try
            //        {
            //            SetMnuItemName();
            //            IndicatorObjectDisplay();
            //            ctmLines.Show(this, p);
            //            Application.DoEvents();
            //        }
            //        catch (Exception ex)
            //        {
            //            Logger.LogEx(ex, "ctlChart", "StockChartX1_ItemRightClick(object sender, AxSTOCKCHARTXLib._DStockChartXEvents_ItemRightClickEvent EventArgs)");
            //        }
            //        break;
            //    case (ObjectType)OBJECT_LINE_STANDARD:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Trendline Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 25;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_ELLIPSE:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Ellipse Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 26;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_ERRORCHANNEL:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Error Channel Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 27;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_FIBARCS:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Fibonacci Arcs Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 28;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_FIBFAN:
            //        // m_Menu = true;                
            //        ctmDeleteObject.Commands[0].Properties.Text = "Fibonacci Fann Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 29;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_FIBRETRACEMENT:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Fibonacci Retracement Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 30;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_FIBTIMEZONE:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Fibonacci TimeZone Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 31;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_FREEHAND:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Free Hand Drawing Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 32;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_GANNFAN:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Gann Fan Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 33;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_QUADRANTLNES:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Quadrant Lines Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 34;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_RAFFREGRESSION:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Raff Regression Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 35;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_RECTANGLE:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Rectangle Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 36;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_SPEEDLINES:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Speed Lines Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 37;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_TIRONELEVELS:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Tirone Levels Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 38;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case ObjectType.otTextObject:
            //        ctmDeleteObject.Commands[0].Properties.Text = "My Text Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 39;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_HORIZONTAL:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Horizontal Line Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 47;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_VERTICAL:
            //        ctmDeleteObject.Commands[0].Properties.Text = "Vertical Line Properties";
            //        ctmDeleteObject.Commands[0].Properties.ImageIndex = 48;
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //    case (ObjectType)OBJECT_LINE_ORDER:
            //        //         this.ctmClose,
            //        //this.ctmReverse,
            //        //this.ctmModify}
            //        SelectedOrderLine = EventArgs.name;
            //        DS4Orders.OrdersRow row = OrderManager.getOrderManager().GetRow(SelectedOrderLine);
            //        if (row != null)
            //        {
            //            if (row.OrderStatus.Equals("FILLED", StringComparison.CurrentCultureIgnoreCase))
            //            {
            //                ctmOrderStatus.Commands[0].Properties.Visible = true;
            //                ctmOrderStatus.Commands[1].Properties.Visible = true;
            //                ctmOrderStatus.Commands[2].Properties.Visible = true;
            //                ctmOrderStatus.Show(this, p);
            //            }
            //            if (row.OrderStatus.Equals("PENDING", StringComparison.CurrentCultureIgnoreCase))
            //            {
            //                ctmOrderStatus.Commands[0].Properties.Visible = false;
            //                ctmOrderStatus.Commands[1].Properties.Visible = false;
            //                ctmOrderStatus.Commands[2].Properties.Visible = true;
            //                ctmOrderStatus.Show(this, p);
            //            }
            //            if (row.OrderStatus.Equals("CLOSED", StringComparison.CurrentCultureIgnoreCase))
            //            {
            //                StockChartX1.RemoveOrderObject(SelectedOrderLine);
            //            }
            //        }
            //        //ctmOrderStatus.Commands[1].Properties.Visible = false;
            //        //ctmOrderStatus.Commands[2].Properties.Visible = false;

            //        break;

            //    case ObjectType.otIndicator:
            //    case ObjectType.otLineChart:
            //    case ObjectType.otVolumeChart:
            //    case ObjectType.otCandleChart:
            //    case ObjectType.otStockBarChart:
            //        mnuEditSeries.Enabled = m_name.IndexOf(StockChartX1.Symbol + ".") == -1;
            //        ctmDeleteSeries.Commands[0].Properties.Text = m_name + "Properties";
            //        if (m_name.StartsWith("Bollinger Bands") ||
            //            m_name.StartsWith("Simple Moving Average")
            //            || m_name.StartsWith("Welles Wilder Smoothing")
            //            || m_name.StartsWith("Moving Average Envelope")
            //            || m_name.StartsWith("Parabolic SAR")
            //            || m_name.StartsWith("Typical Price")
            //            || m_name.StartsWith("Weighted Close")
            //            || m_name.StartsWith("Triangular Moving Average")
            //            || m_name.StartsWith("Fractal Chaos Bands"))
            //        {
            //            mnuDeleteIndicatorWindow.Enabled = false;
            //        }
            //        else
            //        {
            //            mnuDeleteIndicatorWindow.Enabled = true;
            //        }
            //        // m_Menu = true;
            //        ctmDeleteSeries.Show(this, p);
            //        StockChartX1.Update();
            //        break;
            //    //case ObjectType.otTextObject:
            //    case ObjectType.otLineStudyObject:
            //    case ObjectType.otSymbolObject:
            //    case ObjectType.otLineObject:
            //        // m_Menu = true;          
            //        ctmDeleteObject.Show(this, p);
            //        break;
            //}

            #endregion
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_ocxStockChart_ItemRightClick Method");
        }

        public void FillCurrentChartProperties()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FillCurrentChartProperties Method");

            _chartProperties.backGround = ui_ocxStockChart.BackGradientTop;
            _chartProperties.foreGround = ui_ocxStockChart.ChartForeColor;
            _chartProperties.grid = ui_ocxStockChart.Gridcolor;
            _chartProperties.barUp = ui_ocxStockChart.UpColor;
            _chartProperties.barDown = ui_ocxStockChart.DownColor;
            _chartProperties.bullCandle = ui_ocxStockChart.CandleUpOutlineColor;
            _chartProperties.bearCandle = ui_ocxStockChart.CandleDownOutlineColor;
            _chartProperties.lineGraph = ui_ocxStockChart.LineColor;
            _chartProperties.volume = ui_ocxStockChart.BackGradientBottom;
            //_chartProperties.askLine = ui_ocxStockChart.AskLineColor;
            //_chartProperties.stopLevels = ui_ocxStockChart.StopLevelsColor;
            //_chartProperties.SLLine = ui_ocxStockChart.SLColor;
            //_chartProperties.TPPline = ui_ocxStockChart.TPColor;
            //_chartProperties.offlinechart = ui_ocxStockChart.c;
            //_chartProperties.forgroundChart = ui_ocxStockChart.ForegroundChart;
            //_chartProperties.chartShift = ui_ocxStockChart.RightDrawingSpacePixels;
            //_chartProperties.chartAutoScroll = ui_ocxStockChart.Au;
            //_chartProperties.scaleFixOne = ui_ocxStockChart.scale;
            //_chartProperties.scaleFix = ui_ocxStockChart.ChartBackColor;
            _chartProperties.barChart = false;
            _chartProperties.candleSticks = false;
            _chartProperties.lineChart = false;
            switch (crtChartType)
            {
                case ChartType.BAR:
                    _chartProperties.barChart = true;
                    break;
                case ChartType.CANDLE:
                    _chartProperties.candleSticks = true;
                    break;
                case ChartType.LINE:
                    _chartProperties.lineChart = true;
                    break;
            }
            //_chartProperties.showOHLC = ui_ocxStockChart.ShowOHLC;
            //_chartProperties.showAskLine = ui_ocxStockChart.ask;
           //_chartProperties.periodSeperator = ui_ocxStockChart.Period;
            _chartProperties.showGrid = ui_ocxStockChart.XGrid || ui_ocxStockChart.YGrid;
            //_chartProperties.showVolume = ui_ocxStockChart.ShowVolumes;
            //_chartProperties.objDescription = ui_ocxStockChart.ShowObjectDescriptions;
            _chartProperties.ThreeDStyle = ui_ocxStockChart.ThreeDStyle;

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FillCurrentChartProperties Method");
        }

        public Cls.BarData[] GetDataFromChart()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into GetDataFromChart Method");

            var bars = new List<Cls.BarData>();
            string Symbol = ui_ocxStockChart.Symbol;
            int count = ui_ocxStockChart.RecordCount;

            if (count > 30)
                count = 30;

            for (int n = 1; n <= count; n++)
            {
                var bar = new Cls.BarData();

                string x = string.Format("{0:G}", ui_ocxStockChart.FromJulianDate(ui_ocxStockChart.GetJDate(Symbol + ".Close", n)));
                bar.iTradeDate =Convert.ToDateTime(x).ToBinary();
                bar.OpenPrice = ui_ocxStockChart.GetValue(Symbol + ".Open", n);
                bar.HighPrice = ui_ocxStockChart.GetValue(Symbol + ".High", n);
                bar.LowPrice = ui_ocxStockChart.GetValue(Symbol + ".Low", n);
                bar.ClosePrice = ui_ocxStockChart.GetValue(Symbol + ".Close", n);
                bar.Volume = ui_ocxStockChart.GetValue(Symbol + ".Volume", n);
                bars.Add(bar);
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from GetDataFromChart Method");

            return bars.ToArray();
        }

        public void SetChartProperties(ChartProperty props)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetChartProperties Method");

            if (InvokeRequired) //|| frmMainGTS.GetReference().InvokeRequired)
            {
                SetChartProperties(props);
                //this.BeginInvoke(new del_SetChartProperties(SetChartProperties), props);
            }
            else
            {
                //try
                {
                    // Get Volume and OHLC panel indexes
                    int volPanel = ui_ocxStockChart.GetPanelBySeriesName(ui_ocxStockChart.Symbol + ".volume");
                    int OHLCpanel = ui_ocxStockChart.GetPanelBySeriesName(ui_ocxStockChart.Symbol + ".close");

                    // ***************** Color Properties *******************
                    //ui_ocxStockChart.SLColor = props.SLLine;
                    //ui_ocxStockChart.TPColor = props.TPPline;
                    ui_ocxStockChart.ChartBackColor = props.backGround;
                    ui_ocxStockChart.BackGradientTop = props.backGround;
                    ui_ocxStockChart.BackGradientBottom = props.backGround;
                    ui_ocxStockChart.ChartForeColor = props.foreGround;
                    ui_ocxStockChart.Gridcolor = props.grid;
                    ui_ocxStockChart.UpColor = props.barUp;
                    ui_ocxStockChart.DownColor = props.barDown;
                    ui_ocxStockChart.CandleUpOutlineColor = props.bullCandle;
                    ui_ocxStockChart.CandleDownOutlineColor = props.bearCandle;
                    ui_ocxStockChart.LineColor = props.lineGraph;
                    //ui_ocxStockChart.AskLineColor = props.askLine;
                    //ui_ocxStockChart.StopLevelsColor = props.stopLevels;
                    if (volPanel != -1)
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".volume", ColorTranslator.ToOle(props.volume));
                    // Chart On ForeGround
                    //ui_ocxStockChart.ForegroundChart = props.forgroundChart;

                    // Chart Shift
                    if (props.chartShift)
                    {
                        ui_ocxStockChart.RightDrawingSpacePixels = 70;
                        //objChartFunc.SetChartToolBarChartShift(props.chartShift);
                    }
                    else
                    {
                        ui_ocxStockChart.RightDrawingSpacePixels = 0;
                        //objChartFunc.SetChartToolBarChartShift(props.chartShift);
                    }


                    // Auto Scroll
                    //ui_ocxStockChart.AutoScroll = props.chartAutoScroll;

                    // Chart Type 
                    if (props.candleSticks)
                    {
                        ui_ocxStockChart.set_SeriesType(ui_ocxStockChart.Symbol + ".close", SeriesType.stCandleChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(Color.Lime));
                        crtChartType = ChartType.CANDLE;
                    }
                    else if (props.barChart)
                    {
                        ui_ocxStockChart.set_SeriesType(ui_ocxStockChart.Symbol + ".close", SeriesType.stStockBarChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(Color.Lime));
                        crtChartType = ChartType.BAR;
                    }
                    else if (props.lineChart)
                    {
                        ui_ocxStockChart.set_SeriesType(ui_ocxStockChart.Symbol + ".close", SeriesType.stLineChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(props.lineGraph));

                        crtChartType = ChartType.LINE;
                    }

                    // Scale Fix
                    if (props.scaleFix && !props.scaleFixOne)
                    {
                        if (OHLCpanel != -1)
                            ui_ocxStockChart.SetYScale(OHLCpanel, props.maxYScale, props.minYScale);
                    }
                    else if (props.scaleFixOne)
                    {
                        double value = ui_ocxStockChart.GetValue(ui_ocxStockChart.Symbol + ".close",
                                                                 ui_ocxStockChart.LastVisibleRecord);

                        if (ui_ocxStockChart.Symbol.IndexOf("JPY") >= 0)
                            ui_ocxStockChart.SetYScale(OHLCpanel, value + 0.05, value - 0.05);
                        else
                            ui_ocxStockChart.SetYScale(OHLCpanel, value + 0.0005, value - 0.0005);
                    }
                    else if (!props.scaleFix && !props.scaleFixOne)
                        ui_ocxStockChart.ResetYScale(OHLCpanel);

                    //ui_ocxStockChart.ShowOHLC = props.showOHLC;
                    // Show Ask Line
                    // Note: ShowAskLine() is called in chart Paint event
                    m_showAskLine = props.showAskLine;
                    // Show Period Separators
                    //ui_ocxStockChart.ShowPeriodSeparators = props.periodSeperator;
                    ui_ocxStockChart.XGrid = props.showGrid;
                    ui_ocxStockChart.YGrid = props.showGrid;
                    //ui_ocxStockChart.ShowVolumes = props.showVolume;
                    ui_ocxStockChart.ThreeDStyle = props.ThreeDStyle;
                    _chartProperties = props;
                    ui_ocxStockChart.Update();
                }
                //catch (Exception ex)
                {
                }
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetChartProperties Method");
        }

        private void objfrmSelectSymbolForChart_OnOkClick(string symbol, ePeriodicity periodicity)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into objfrmSelectSymbolForChart_OnOkClick Method");

            //KulInitChartData(symbol, periodicity);

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from objfrmSelectSymbolForChart_OnOkClick Method");
        }

        public void DeleteIndicator(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into DeleteIndicator Method");

            int hyphenPos = name.IndexOf('-');
            //ui_ocxStockChart.RemoveSeries(name);
            if (hyphenPos != -1)
            {
                string[] arrIndicator = name.Split('-');
                m_name = arrIndicator[0] + "-";
            }
            if (hyphenPos != -1 && m_Indicators.ContainsKey(m_name))
            {
                m_Indicators.Remove(name);
                ui_ocxStockChart.RemoveSeries(name);
            }
            if (hyphenPos == -1)
            {
                ui_ocxStockChart.RemoveSeries(name);
            }
            ui_ocxStockChart.RemoveSeries(m_name);
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from DeleteIndicator Method");
        }

        private void ui_ocxStockChart_ClickEvent(object sender, EventArgs e)
        {
            //Activate();
        }

        #region "       Menu Handler Methods        "

        public void ChangeChartType(SeriesType stType, ChartProperty cprop)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangeChartType Method");

            string Symbol = ui_ocxStockChart.Symbol;
            //Cls.ChartProperty cp = cprop;
            ui_ocxStockChart.set_SeriesType(Symbol + ".open", stType);
            ui_ocxStockChart.set_SeriesType(Symbol + ".high", stType);
            ui_ocxStockChart.set_SeriesType(Symbol + ".low", stType);
            ui_ocxStockChart.set_SeriesType(Symbol + ".close", stType);

            if (stType == SeriesType.stLineChart)
                ui_ocxStockChart.set_SeriesColor(Symbol + ".close", ColorTranslator.ToOle(cprop.lineGraph));
            else
                ui_ocxStockChart.set_SeriesColor(Symbol + ".close", ColorTranslator.ToOle(Color.Lime));

            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangeChartType Method");
        }

        public void ChangePriceStyle(PriceType priceType)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangePriceStyle Method");

            crtPriceType = priceType;
            //try
            {
                switch (priceType)
                {
                    case PriceType.POINT_AND_FIGURE:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psPointAndFigure;
                        //(new frmPriceStyle()).GetInput(StockChartX1, m_frmMain.cboPriceStyles.HostedControl.Text);
                        break;
                    case PriceType.RENKO:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psRenko;
                        //(new frmPriceStyle()).GetInput(StockChartX1, m_frmMain.cboPriceStyles.HostedControl.Text);
                        break;
                    case PriceType.KAGI:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psKagi;
                        //(new frmPriceStyle()).GetInput(StockChartX1, m_frmMain.cboPriceStyles.HostedControl.Text);
                        break;
                    case PriceType.THREE_LINE_BREAK:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psThreeLineBreak;
                        //(new frmPriceStyle()).GetInput(StockChartX1, m_frmMain.cboPriceStyles.HostedControl.Text);
                        break;
                    case PriceType.EQUI_VOLUME:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psEquiVolume;
                        break;
                    case PriceType.EQUI_VOLUME_SHADOW:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psEquiVolumeShadow;
                        break;
                    case PriceType.CANDLE_VOLUME:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psCandleVolume;
                        break;
                    case PriceType.HEIKIN_ASHI:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psHeikinAshi;
                        break;
                    case PriceType.STANDARD_CHART:
                        ui_ocxStockChart.PriceStyle = PriceStyle.psStandard;
                        break;
                    default:
                        break;
                }
#region Old Galaxy Chart

                //switch (priceType)
                //{
                //    case PriceType.POINT_AND_FIGURE:
                //        ui_ocxStockChart.set_PriceStyleParam(1, 0); // Allow StockChartX to figure the box size
                //        ui_ocxStockChart.set_PriceStyleParam(2, 3); // Reversal size
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psPointAndFigure;
                //        break;
                //    case PriceType.RENKO:
                //        ui_ocxStockChart.set_PriceStyleParam(1, 1); // Reversal size
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psRenko;
                //        break;
                //    case PriceType.KAGI:
                //        ui_ocxStockChart.set_PriceStyleParam(1, 1); // Reversal size
                //        ui_ocxStockChart.set_PriceStyleParam(2, (int)DataType.dtPoints);
                //        // Points or percent (eg 1 or 0.01)
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psKagi;
                //        break;
                //    case PriceType.THREE_LINE_BREAK:
                //        ui_ocxStockChart.set_PriceStyleParam(1, 3); // Three line break (could be 1 to 50 line break)
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psThreeLineBreak;
                //        break;
                //    case PriceType.EQUI_VOLUME:
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psEquiVolume;
                //        break;
                //    case PriceType.EQUI_VOLUME_SHADOW:
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psEquiVolumeShadow;
                //        break;
                //    case PriceType.CANDLE_VOLUME:
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psCandleVolume;
                //        break;
                //    case PriceType.HEIKIN_ASHI:
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psHeikinAshi;
                //        break;
                //    case PriceType.STANDARD_CHART:
                //        ui_ocxStockChart.PriceStyle = PriceStyle.psStandard;
                //        //cp.barChart = false;
                //        //cp.lineChart = false;
                //        //cp.candleSticks = true;
                //        //ChangeChartType(SeriesType.stCandleChart, cp);
                //        break;
                //}

#endregion
                ui_ocxStockChart.Update();
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangePriceStyle Method");
        }


        public void ChangePeriodicity(ePeriodicity periodicity, int interval, NewHistoryType historyType)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + m_Symbol + " : Enter into ChangePeriodicity Method");

            Action A = () =>
            {
                OHLCEntity_ = null;
                //_chartBarType = periodicity;
                ChartHistoryType_ = historyType;
                
                Text = ui_ocxStockChart.Symbol + " : " +
                       periodicity.ToString().Split(new[] { '_' },
                                                    StringSplitOptions.RemoveEmptyEntries)[0] +
                       "_" + interval;

                lstOHLC.Clear();
                PALSA.Cls.PeriodEnum prd = GetPeriod(periodicity);
                LoadRTChart(m_Symbol, interval, "250", prd);
            };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangePeriodicity Method");
        }

        private Cls.PeriodEnum GetPeriod(ePeriodicity periodicity)
        {
            switch (periodicity)
            {
                case ePeriodicity.Minutely_1:
                    return Cls.PeriodEnum.Minute;
                case ePeriodicity.Minutely_5:
                    return Cls.PeriodEnum.Minute;
                case ePeriodicity.Minutely_15:
                    return Cls.PeriodEnum.Minute;
                case ePeriodicity.Minutely_30:
                    return Cls.PeriodEnum.Minute;
                case ePeriodicity.Hourly_1:
                    return Cls.PeriodEnum.Hour;
                case ePeriodicity.Hourly_4:
                    return Cls.PeriodEnum.Hour;
                case ePeriodicity.Daily:
                    return Cls.PeriodEnum.Day;
                case ePeriodicity.Weekly:
                    return Cls.PeriodEnum.Week;
                case ePeriodicity.Monthly:
                    return Cls.PeriodEnum.Month;
                default:
                    return Cls.PeriodEnum.Minute;
            }
        }

        public void ChangeChartType(ChartType chartType)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangeChartType Method");
            crtChartType = chartType;

            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".open", true);
            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".high", true);
            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".low", true);
            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".close", true);
            ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".line", false);
            switch (chartType)
            {
                case ChartType.BAR:
                    {
                        ChangeChartSeriesType(SeriesType.stStockBarChart);
                    }
                    break;
                case ChartType.CANDLE:
                    {
                        ChangeChartSeriesType(SeriesType.stCandleChart);
                    }
                    break;
                case ChartType.LINE:
                    {
                        //Kul
                        ChangeChartSeriesType(SeriesType.stLineChart);
                        //ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                        //                                 ColorTranslator.ToOle(Color.Red));//(ui_ocxStockChart.LineGraphColor));
                    }
                    break;
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangeChartType Method");
        }

        private void ChangeChartSeriesType(SeriesType seriesType)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangeChartSeriesType Method");

            if (seriesType == SeriesType.stLineChart)
            {
                ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".open", false);
                ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".high", false);
                ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".low", false);
                ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".close", false);
                ui_ocxStockChart.set_SeriesVisible(m_Symbol + ".line", true);
                ui_ocxStockChart.set_SeriesColor(m_Symbol + ".line", ColorTranslator.ToOle(Color.Black));
            }
            //ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".close", ColorTranslator.ToOle(Color.Lime));
            else
            {
                ui_ocxStockChart.set_SeriesType(m_Symbol + ".open", seriesType);
                ui_ocxStockChart.set_SeriesType(m_Symbol + ".high", seriesType);
                ui_ocxStockChart.set_SeriesType(m_Symbol + ".low", seriesType);
                ui_ocxStockChart.set_SeriesType(m_Symbol + ".close", seriesType);
                ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".close", ColorTranslator.ToOle(Color.Lime));
            }
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangeChartSeriesType Method");
        }

        public void ZoomIn()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ZoomIn Method");

            ui_ocxStockChart.ZoomIn(5); //ui_ocxStockChart.RecordCount);//5);
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ZoomIn Method");
        }

        public void ZoomOut()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ZoomOut Method");

            ui_ocxStockChart.ZoomOut(5); //ui_ocxStockChart.RecordCount);//5);
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ZoomOut Method");
        }

        public void TrackCursor()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TrackCursor Method");

            ui_ocxStockChart.CrossHairs = !ui_ocxStockChart.CrossHairs;
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TrackCursor Method");
        }

        public void SetVolumeDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetVolumeDisplay Method");

            //ui_ocxStockChart.ShowVolumes = !ui_ocxStockChart.ShowVolumes;
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetVolumeDisplay Method");
        }

        public void SetGridDisplay(bool status)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetGridDisplay Method");

            if (status)
            {
                ui_ocxStockChart.XGrid = true;
                ui_ocxStockChart.YGrid = true;
            }
            else
            {
                ui_ocxStockChart.XGrid = false;
                ui_ocxStockChart.YGrid = false;
            }
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetGridDisplay Method");
        }

        public void Set3DStyle()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into Set3DStyle Method");

            ui_ocxStockChart.ThreeDStyle = !ui_ocxStockChart.ThreeDStyle;
            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from Set3DStyle Method");
        }

        public void PrintChart()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into PrintChart Method");

            ui_ocxStockChart.PrintChart();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from PrintChart Method");
        }

        public void SaveChartDialog()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SaveChartDialog Method");

            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "(*.icx)|*.icx";
            objSaveFileDialog.Title = "Save";
            objSaveFileDialog.DefaultExt = ".icx";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                ui_ocxStockChart.SaveFile(objSaveFileDialog.FileName);
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SaveChartDialog Method");
        }

        public void SaveInFile(string filename)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SaveInFile Method");
            ui_ocxStockChart.SaveFile(filename);
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SaveInFile Method");
        }

        public void LoadFromFile(string filename)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into LoadFromFile Method");
            ui_ocxStockChart.LoadFile(filename);
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from LoadFromFile Method");
        }
        private SortedDictionary<string, int> indicatorsSortedList = new SortedDictionary<string, int>();
        public void AddIndicator(string indicator)
        {
            try
            {

                string objName = ui_ocxStockChart.SelectedKey;
                int n = 0;
                int indicatorindex = -1;
                if (ui_ocxStockChart.RecordCount < 3) return;
                string cnt = "";
                foreach (string str in indicatorsSortedList.Keys)
                {
                    if (indicator == str)
                    {
                        n = ui_ocxStockChart.GetIndicatorCountByType((Indicator)indicatorsSortedList[str]);
                        indicatorindex = indicatorsSortedList[str];
                    }
                }
                if (n > 0)
                {
                    cnt = " " + (n + 1);
                }
                int panel = IsOverlay(indicator) ? 0 : ui_ocxStockChart.AddChartPanel();
                if (indicatorindex != -1)
                {
                    ui_ocxStockChart.AddIndicatorSeries((Indicator)indicatorindex, indicator + cnt, panel, true);
                    //ui_ocxStockChart.SetSelectSeries(objName);//Namo
                    ui_ocxStockChart.Update();
                }


                //if (!m_undonow)
                //{
                //    lock (m_operations)
                //    {
                //        UndoClass m_undo = new UndoClass();
                //        m_undo.m_objname = indicator + cnt;
                //        m_undo.m_operation = "AddIndicatorSeries";
                //        m_operations.Push(m_undo);
                //    }
                //    if (this.Parent is frmExternalChartWindow)
                //    {
                //        (this.Parent as frmExternalChartWindow).cmdUndo.Enabled = true;
                //    }
                //    else
                //    {
                //        m_frmMain.cmdUndo.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                
            }
        }

        public void AddIndicator(IndicatorSelection indicator, int currPanel)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddIndicator Method");

            try
            {
                string cnt = "";
                int n = ui_ocxStockChart.GetIndicatorCountByType((Indicator)indicator.node);
                if (n > 0)
                {
                    cnt = " " + (n + 1);
                }
                var ind = (Indicator)(indicator.node);
                int panel = 0;

                int prevPanel = ui_ocxStockChart.GetPanelBySeriesName(ui_ocxStockChart.Symbol + ".close");

                if (IsOverlay(indicator.IndicatorName))
                {
                    if (currPanel > -1)
                        panel = currPanel;
                    else
                        panel = prevPanel;
                }
                else if (currPanel != -1 && currPanel != 0)
                    panel = currPanel;
                else
                    panel = ui_ocxStockChart.AddChartPanel();

                if (indicator.IndicatorName.CompareTo("Custom Indicator") == 0) // Custom Indicator
                    AddCustomIndicator(cnt, indicator.IndicatorName, panel);
                else
                    ui_ocxStockChart.AddIndicatorSeries(ind, indicator.IndicatorName + " " + cnt, panel, false);

                var node = new IndicatorsNode();
                node.Ind = ind;
                node.IndicatorText = indicator.IndicatorName + " " + cnt;
                node.Panel = panel;

                ui_ocxStockChart.Update();
            }
            catch 
            {

            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddIndicator Method");
        }

        public void AddCustomIndicator(string cnt, string indName, int panel)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddCustomIndicator Method");

            Indicator indicatorType = Indicator.indCustomIndicator;

            // Setup some properties that we want the user to input
            ui_ocxStockChart.AddIndicatorSeries(indicatorType, indName + " " + cnt, panel, true);
            ui_ocxStockChart.AddCustomIndDlgIndPropInt(indName, ParamType.ptPeriods, 10);
            ui_ocxStockChart.AddCustomIndDlgIndPropInt(indName, ParamType.ptPointsOrPercent, 12);
            ui_ocxStockChart.AddCustomIndDlgIndPropStr(indName, ParamType.ptSymbol, "");
            ui_ocxStockChart.AddCustomIndDlgIndPropDbl(indName, ParamType.ptLimitMoveValue, 16);

            // Some fake data
            double dtNull = -987654321; //STOCKCHARTXLib.DataType.dtNullValue

            var dData = new double[10];
            dData[0] = dtNull;
            dData[1] = 10.5;
            dData[2] = 2.0;
            dData[3] = 55.5;
            dData[4] = 2.5;
            dData[5] = 3.0;
            dData[6] = 3.9;
            dData[7] = 56.4;
            dData[8] = 42.5;
            dData[9] = 8.5;

            //try
            {
                // Set the custom indicator data
                ui_ocxStockChart.SetCustomIndicatorData(indName, dData, false);
            }
            //catch (Exception ex)
            //{

            //}

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddCustomIndicator Method");
        }

        private static bool IsOverlay(string name)
        {
            if (name == null)
                return false;

            //try
            {
                var overlays = new[]
                                   {
                                       "PARABOLIC", "PSAR", "FORECAST", "INTERCEPT",
                                       "WEIGHTED CLOSE", "TYPICAL PRICE", "WEIGHTED PRICE",
                                       "MEDIAN PRICE", "SMOOTHING", "BOLLINGER",
                                       "MOVING AVERAGE", "BANDS"
                                   };
                foreach (string overlay in overlays)
                {
                    if (name.IndexOf(overlay, StringComparison.CurrentCultureIgnoreCase) != -1)
                        return true;
                }
            }
            //catch (Exception ex)
            {
            }


            return false;
        }
        #region "    Techincal Analysis Add submenu handlers    "

        private double m_Value;
        private int m_Record;
        public void AddHorizontalLine()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddHorizontalLine Method");

            // ui_ocxStockChart.AddHorizontalLine(-1, -1);
            ////try
            ////{
            ////    string name = "H" + DateTime.Now.Ticks;
            ////    ui_ocxStockChart.AddHorizontalLine(ui_ocxStockChart.CurrentPanel, m_Value);//, name, 2);
            ////    ui_ocxStockChart.set_ObjectSelectable(ObjectType.otTrendLineObject, name, true);
            ////    ui_ocxStockChart.Update();
            ////}
            ////catch (Exception e)
            ////{
                            
            ////}
          //==============================
            try
            {
                string name = "H" + DateTime.Now.Ticks;
                if (m_Value == 0)
                    m_Value = ClsGlobal.DDRightZLevel[_chartSymbol];
                ui_ocxStockChart.AddHorizontalLine(ui_ocxStockChart.CurrentPanel, m_Value, name, 2);
                ui_ocxStockChart.set_ObjectSelectable(ObjectType.otTrendLineObject, name, true);
                ui_ocxStockChart.Update();               
            }
            catch (Exception ex)
            {
                //ErrorService.LogError("ctlChart", "mnucHorzLine_Click", ex.ToString());
            }

            //==============================
            //if (!m_undonow)
            //{
            //    UndoClass m_undo = new UndoClass();
            //    m_undo.m_objname = name;
            //    m_undo.m_operation = "AddVerticalLine";
            //    lock (m_operations)
            //    {
            //        m_operations.Push(m_undo);
            //    }
            //    SetExternalChartWindowUndo(true);
            //}

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddHorizontalLine Method");
        }

        public void AddVerticalLine()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddVerticalLine Method");
               // ui_ocxStockChart.AddVerticalLines(-1);
            string name = "V" + DateTime.Now.Ticks;
            ui_ocxStockChart.AddHorizontalLine(ui_ocxStockChart.CurrentPanel, m_Record, name, 1);
            ui_ocxStockChart.set_ObjectSelectable(ObjectType.otTrendLineObject, name, true);
            ui_ocxStockChart.Update();
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddVerticalLine Method");
        }

        public void AddText()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddText Method");



            string name = Convert.ToString(DateTime.Now);
            ui_ocxStockChart.AddUserDefinedText(name);

            ui_ocxStockChart.Focus();



            //try
            {
                //ui_ocxStockChart.AddUserDefinedText("My Text" + Convert.ToString(DateTime.UtcNow));
            }
            //catch (Exception ex)
            {
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddText Method");
        }

        public void TrendLineDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TrendLineDisplay Method");

            ui_ocxStockChart.AddUserTrendLine("Trendline " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TrendLineDisplay Method");
        }

        public void EllipseDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into EllipseDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsEllipse, "Ellipse " + Convert.ToString(DateTime.UtcNow));
            //StudyType.lsEllipse, Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from EllipseDisplay Method");
        }

        public void SpeedLineDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SpeedLineDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsSpeedLines, "Speedlines " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SpeedLineDisplay Method");
        }

        public void GannFanDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into GannFanDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsGannFan, "Gann Fan " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from GannFanDisplay Method");
        }

        public void FibonacciArcsDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FibonacciArcsDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciArcs, "Fibonacci Arcs " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FibonacciArcsDisplay Method");
        }

        public void FibonacciRetracementDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FibonacciRetracementDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciRetracements,
                                           "Fibonacci Retracements " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FibonacciRetracementDisplay Method");
        }

        public void FibonacciFanDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FibonacciFanDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciFan, "Fibonacci Fan " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FibonacciFanDisplay Method");
        }

        public void FibonacciTimezoneDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FibonacciTimezoneDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciTimeZones,
                                           "Fibonacci Timezones " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FibonacciTimezoneDisplay Method");
        }

        public void TironeLevelDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TironeLevelDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsTironeLevels, "Tirone Levels " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TironeLevelDisplay Method");
        }

        public void QuadrentLinesDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into QuadrentLinesDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsQuadrantLines, "Quadrant Lines " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from QuadrentLinesDisplay Method");
        }

        public void RafRegressionDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into RafRegressionDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsRaffRegression,
                                           "Raff regression " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from RafRegressionDisplay Method");
        }

        public void ErrorChannelDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ErrorChannelDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsErrorChannel, "Error Channel " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ErrorChannelDisplay Method");
        }

        public void RectangleDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into RectangleDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsRectangle, "Rectangle " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from RectangleDisplay Method");
        }

        public void FreeHandDrawingDisplay()
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into FreeHandDrawingDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFreehand, "Freehand " + Convert.ToString(DateTime.UtcNow));

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FreeHandDrawingDisplay Method");
        }

        public void DrawTrendLine()
        {
            //m_UserEditing = true;
            //DrawingLineStudy = true;

            string name = Convert.ToString(DateTime.Now);
            ui_ocxStockChart.AddUserTrendLine(name);
        }

        public void DrawLineStudy(StudyType studyType)
        {
            //m_UserEditing = true;
            //DrawingLineStudy = true;

            string name = Convert.ToString(DateTime.Now);
            ui_ocxStockChart.DrawLineStudy(studyType, name);
        }



        #endregion "    Techincal Analysis Add submenu handlers    "

        public class IndicatorsNode
        {
            public Indicator Ind;
            public string IndicatorText;
            public int Panel;
        }

        #endregion "      Menu Handler Methods       "


        private void ui_mnuSelectSymbol_Click(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_mnuSelectSymbol_Click Method");

            //var objfrmSelectSymbolForChart = new frmSelectSymbolForChart();
            //objfrmSelectSymbolForChart.OnOkClick +=
            //    objfrmSelectSymbolForChart_OnOkClick;
            //objfrmSelectSymbolForChart.ShowDialog(this);

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_mnuSelectSymbol_Click Method");
        }

        private void ui_mnuDeleteObject_Click_1(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_mnuDeleteObject_Click Method");

            ui_ocxStockChart.RemoveObject((ObjectType)m_objectType, m_name);

            //Kul
            //switch (m_objectType)
            //{
            //    case otBuySymbolObject:
            //         ui_ocxStockChart.RemoveObject(ObjectType.otBuySymbolObject, m_name);
            //        break;
            //        case otTextObject:
            //         ui_ocxStockChart.RemoveObject(ObjectType.otTextObject, m_name);
            //        break;
            //        case otStaticTextObject:
            //         ui_ocxStockChart.RemoveObject(ObjectType.otStaticTextObject, m_name);
            //        break;
            //        case otLineObject:
            //         ui_ocxStockChart.RemoveObject(ObjectType.otLineObject, m_name);
            //        break;
            //        case otTrendLineObject:
            //         ui_ocxStockChart.RemoveObject(ObjectType.otTrendLineObject, m_name);
            //        break;
            //    default:
            //        break;
            //}

            #region Galaxy Chart Object

            //switch (m_objectType)
            //{
                //case OBJECT_GENERIC:
                //    break;
                //case OBJECT_LINE_VERTICAL:
                //    ///ui_ocxStockChart.RemoveObject(ObjectType.otVerticalLineObject, m_name);
                //    ui_ocxStockChart.RemoveObject(ObjectType.otLineStudyObject, m_name);
                //    break;
                //case OBJECT_LINE_HORIZONTAL:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otLineStudyObject, m_name);
                //    break;
                //case OBJECT_LINE_ELLIPSE:
                //    //ui_ocxStockChart.RemoveObject(ObjectType.otEllipseObject, m_name);
                //    ui_ocxStockChart.RemoveObject(ObjectType., m_name);
                //    break;
                //case OBJECT_LINE_ERRORCHANNEL:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otErrorChannelsObject, m_name);
                //    break;
                //case OBJECT_LINE_FIBARCS:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciArcsObject, m_name);
                //    break;
                //case OBJECT_LINE_FIBFAN:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciFanObject, m_name);
                //    break;
                //case OBJECT_LINE_FIBRETRACEMENT:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciRetracementObject, m_name);
                //    break;
                //case OBJECT_LINE_FIBTIMEZONE:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciTimezoneObject, m_name);
                //    break;
                //case OBJECT_LINE_FREEHAND:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otFreeHandObject, m_name);
                //    break;
                //case OBJECT_LINE_GANNFAN:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otGannFanObject, m_name);
                //    break;
                //case OBJECT_LINE_QUADRANTLNES:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otLineStudyObject, m_name);
                //    break;
                //case OBJECT_LINE_RAFFREGRESSION:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otRaffRegressionObject, m_name);
                //    break;
                //case OBJECT_LINE_RECTANGLE:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otRectangleObject, m_name);
                //    break;
                //case OBJECT_LINE_SPEEDLINES:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otSpeedLineObject, m_name);
                //    break;
                //case OBJECT_LINE_TIRONELEVELS:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otTironeLevelsObject, m_name);
                //    break;
                //case OBJECT_LINE_ORDER:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otSymbolObject, m_name);
                //    break;
                //case OBJECT_LINE_TEXT:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otTextObject, m_name);
                //    break;
                //case OBJECT_LINE_STANDARD:
                //    ui_ocxStockChart.RemoveObject(ObjectType.otTrendLineObject, m_name);
                //    break;
                #endregion

            ui_ocxStockChart.Update();

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_mnuDeleteObject_Click Method");
        }

        private void ui_tsmDeleteIndicator_Click_1(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_tsmDeleteIndicator_Click Method");

            DeleteIndicator(m_name);

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_tsmDeleteIndicator_Click Method");
        }

        private void ui_mnuProperties_Click_1(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ui_mnuProperties_Click Method");

            //try
            {
                Cls.BarData[] Data1; //GTS.DataManager.BarData[] Data1;
                Data1 = GetDataFromChart();
                FillCurrentChartProperties();
                double minY = ui_ocxStockChart.GetMinValue(ui_ocxStockChart.Symbol + ".close");
                double maxY = ui_ocxStockChart.GetMaxValue(ui_ocxStockChart.Symbol + ".close");
                var prop = new FrmProperties(ui_ocxStockChart.Symbol, Data1, _chartProperties, minY, maxY);
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
            //catch (Exception ex)
            {
            }

            //FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ui_mnuProperties_Click Method");
        }


        internal void InitChartSelection(string sym, Cls.Periodicity periodicity, int intrvl, int bars)
        {
            PALSA.Cls.PeriodEnum prd = GetChartPeriod(periodicity);
            LoadRTChart(sym, intrvl, bars.ToString(), prd);
        }

        private PeriodEnum GetChartPeriod(Cls.Periodicity periodicity)
        {
            switch (periodicity)
            {
                case Cls.Periodicity.Unspecified:
                    return PALSA.Cls.PeriodEnum.Minute;
                case Cls.Periodicity.Minutely:
                    return PALSA.Cls.PeriodEnum.Minute;
                case Cls.Periodicity.Hourly:
                    return PALSA.Cls.PeriodEnum.Hour;
                case Cls.Periodicity.Daily:
                    return PALSA.Cls.PeriodEnum.Day;
                case Cls.Periodicity.Weekly:
                    return PALSA.Cls.PeriodEnum.Week;
                case Cls.Periodicity.Monthly:
                    return PALSA.Cls.PeriodEnum.Month;
                default:
                    return PALSA.Cls.PeriodEnum.Minute;
            }
        }

        private void ui_ocxStockChart_EnumIndicator(object sender, _DStockChartXEvents_EnumIndicatorEvent e)
        {
            Indicators ind = new Indicators();
            ind.name = e.indicatorName;
            ind.index = e.indicatorID;
            indicatorsSortedList.Add(ind.name, ind.index);
            //m_frmMain.cboIndicators.Items.Clear();
            //foreach (string str in indicatorsSortedList.Keys)
            //{

                //ClsGlobal.AddNewIndicator(str);
                // m_frmMain.cboIndicators.Items.Add(str);
                //string indicatorName = str.ToLower();
                //if (indicatorName.IndexOf("bands") != -1 || indicatorName.IndexOf("macd") != -1 || indicatorName.IndexOf("stochastic oscillator") != -1)
                //m_frmMain.cboIndicators.Items[m_frmMain.cboIndicators.Items.Count - 1].ImageIndex = 10;
                //else
                // m_frmMain.cboIndicators.Items[m_frmMain.cboIndicators.Items.Count - 1].ImageIndex = 9;
            //}
        }

        private void ui_ocxStockChart_ItemLeftClick(object sender, _DStockChartXEvents_ItemLeftClickEvent e)
        {
            string name = ui_ocxStockChart.SelectedKey;
            m_name = e.name;
            int weight, style;
            Color color;
            switch (ui_ocxStockChart.SelectedType)
            {
                case ObjectType.otSymbolObject:
                    m_UserEditing = !m_UserEditing;
                    break;
                case ObjectType.otTrendLineObject:
                    m_UserEditing = !m_UserEditing;

                    weight = ui_ocxStockChart.get_ObjectWeight(ObjectType.otTrendLineObject, name);
                    style = ui_ocxStockChart.get_ObjectStyle(ObjectType.otTrendLineObject, name);
                    color = ui_ocxStockChart.get_ObjectColor(ObjectType.otTrendLineObject, name);
                    //m_frmMain.m_SeriesProperties.Enabled = true;
                    //m_frmMain.m_SeriesProperties.UpdateValues(style, weight, color);
                    break;
                case ObjectType.otTextObject:
                    m_UserEditing = !m_UserEditing;

                    weight = (ui_ocxStockChart.TextAreaFontSize - 50) / 30;
                    style = 0;
                    color = ui_ocxStockChart.get_ObjectColor(ObjectType.otTrendLineObject, name);
                    //m_frmMain.m_SeriesProperties.Enabled = true;
                    //m_frmMain.m_SeriesProperties.UpdateValues(style, weight, color);
                    //m_frmMain.m_SeriesProperties.cmbTreandLineStyle.Enabled = false;
                    break;
                case ObjectType.otIndicator:
                    break;
                default:
                   // m_frmMain.m_SeriesProperties.Enabled = false;
                    break;
            }
        }

        private void ui_ocxStockChart_MouseEnterEvent(object sender, EventArgs e)
        {
            
        }

        private void horizontalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddHorizontalLine();
        }

        private void verticalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddVerticalLine();
        }

        private void deleteAllDrawingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ui_ocxStockChart.ClearDrawings();
            //foreach (HorizontalLine horzLine in m_horzLines)
            //{
            //    StockChartX1.RemoveHorizontalLine(horzLine.Panel, horzLine.Value);
            //}
        }

        private void trendLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawTrendLine();
        }

    }




}
