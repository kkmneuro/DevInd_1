using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//using AxSTOCKCHARTXLib;//by Namo
using ClientDLL_Model.Cls;
using ClientDLL_Model.Cls.Market;
using Logging;
using PALSA.Cls;
//using STOCKCHARTXLib;//by Namo

namespace PALSA.Frm
{
    public partial class frmNewChart : frmBase
    {
        //ePeriodicity crtPeriodicity;

        /// <summary>
        /// Setting Object Type values
        /// </summary>
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
        private const int OBJECT_LINE_VERTICAL = 619;
        private const int OBJECT_LINE_HORIZONTAL = 620;
        private const int OBJECT_LINE_ORDER = 621;
        private const int OBJECT_GENERIC = 622;
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
        private Form parentForm;

        public frmNewChart()
        {
            count += 1;
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into frmNetPosition Constructor");

            _formkey = _formkey = CommandIDS.NEW_CHART.ToString() + "/" + Convert.ToString(count);
            InitializeComponent();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from frmNewChart Constructor");
        }

        public override string Formkey
        {
            get { return _formkey; }
            set { _formkey = value; }
        }

        public string ChartSymbol
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

        public void InitChartData(DataGridViewRow row)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into InitChartData(DataGridViewRow row) Method");

            //count += 1;
            _formkey =
                _formkey =
                CommandIDS.NEW_CHART.ToString() + "/" + Convert.ToString(count) + "/" +
                row.Cells["ClmContractName"].Value;
            Text = row.Cells["ClmContractName"].Value + " : " + _chartBarType.ToString().Split(
                new[] {'_'}, StringSplitOptions.RemoveEmptyEntries)[0] + "_" + _barInterval;
            ChartSymbol = row.Cells["ClmContractName"].Value.ToString();
            BindContextMenuEvents();
            AddAllSeries();
            SetChartBarInterval();
            if (File.Exists("./OHLCLog/" + row.Cells["ClmContractName"].Value))
            {
                ui_ocxStockChart.LoadFile(Application.StartupPath + "\\OHLCLog\\" +
                                          row.Cells["ClmContractName"].Value);
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from InitChartData(DataGridViewRow row) Method");

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

            //AddChartData(lstOHLC);
        }

        public void InitChartData(string symbol, ePeriodicity periodiciy)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into InitChartData(string symbol,ePeriodicity periodiciy) Method");

            count += 1;
            _formkey = _formkey = CommandIDS.NEW_CHART.ToString() + "/" + Convert.ToString(count) + "/" + symbol;
            ChartSymbol = symbol;
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
            if (File.Exists("./OHLCLog/" + symbol))
            {
                ui_ocxStockChart.LoadFile(Application.StartupPath + "\\OHLCLog\\" + symbol);
            }
            //AddChartData(lstOHLC);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from InitChartData(string symbol,ePeriodicity periodiciy) Method");
        }

        public void AddAllSeries()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddAllSeries Method");

            //First setup the chart for real time data
            ui_ocxStockChart.RemoveAllSeries();
            //First add a panel (chart area) for the OHLC data:
            long panel = ui_ocxStockChart.AddChartPanel();
            long panel1 = panel;

            ui_ocxStockChart.Symbol = _chartSymbol;
            //Now add the open, high, low and close series to that panel:
            ui_ocxStockChart.AddSeries(_chartSymbol + ".open", SeriesType.stCandleChart, (int) panel);
            ui_ocxStockChart.AddSeries(_chartSymbol + ".high", SeriesType.stCandleChart, (int) panel);
            ui_ocxStockChart.AddSeries(_chartSymbol + ".low", SeriesType.stCandleChart, (int) panel);
            ui_ocxStockChart.AddSeries(_chartSymbol + ".close", SeriesType.stCandleChart, (int) panel);

            crtChartType = ChartType.CANDLE; // code by vijay
            ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".close", ColorTranslator.ToOle(Color.Lime));

            panel = ui_ocxStockChart.AddChartPanel();
            ui_ocxStockChart.AddSeries(_chartSymbol + ".volume", SeriesType.stCandleChart, (int) panel);

            //Change volume color and weight of the volume panel:
            ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".volume", ColorTranslator.ToOle(Color.LimeGreen));
            ui_ocxStockChart.set_SeriesWeight(_chartSymbol + ".volume", 1); //By Ratan for removing Volume

            //Resize the volume panel to make it smaller
            ui_ocxStockChart.set_PanelY1(1, (int) Math.Round(ui_ocxStockChart.Height*0.8));


            // edit - laxman, Set some initial properties
            ui_ocxStockChart.LineColor = Color.Red;

            ui_ocxStockChart.ScalePrecision = _chartYAxisPrecision;
            ui_ocxStockChart.DisplayTitles = true;
            ui_ocxStockChart.DisplayTitleBorder = true;
            ui_ocxStockChart.RealTimeXLabels = true;
            //ui_ocxStockChart.CurrentTickLine = true;
            ui_ocxStockChart.MaxDisplayRecords = Width/11;
            ui_ocxStockChart.ShowVolumes = _isShowVolume;

            ui_ocxStockChart.ThreeDStyle = false;
            ui_ocxStockChart.XGrid = true;
            ui_ocxStockChart.DisplayTitleBorder = true;
            ui_ocxStockChart.RealTimeXLabels = true;
            //ui_ocxStockChart.ScalePrecision = 4;
            ui_ocxStockChart.UpColor = Color.Green;
            ui_ocxStockChart.DownColor = Color.Red;
            ui_ocxStockChart.CandleUpOutlineColor = Color.Green;
            ui_ocxStockChart.CandleDownOutlineColor = Color.Red;
            ui_ocxStockChart.DisplayTitles = true;
            ui_ocxStockChart.ChartBackColor = Color.Black;
            ui_ocxStockChart.ChartForeColor = Color.Yellow;
            ui_ocxStockChart.BackGradientTop = Color.Black;
            ui_ocxStockChart.BackGradientBottom = Color.FromArgb(0xd5, 0xe7, 0xff);
            ui_ocxStockChart.HorizontalSeparatorColor = Color.SkyBlue;
            ;
            ui_ocxStockChart.ThreeDStyle = false;
            ui_ocxStockChart.XGrid = true;
            ui_ocxStockChart.DisplayTitleBorder = true;
            ui_ocxStockChart.RealTimeXLabels = true;
            //ui_ocxStockChart.ShowOHLC = true;
            //ui_ocxStockChart.ShowVolumes = true;
            //ui_ocxStockChart.CurrentTickLine = true;
            //ui_ocxStockChart.AddHorizontalLine(-1, -1);
            //ui_ocxStockChart.AddVerticalLines(-1);
            //ui_ocxStockChart.PriceStyle = PriceStyle.psCandleVolume;

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddAllSeries Method");
        }

        public void SetChartBarInterval()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into SetChartBarInterval Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetChartBarInterval Method");
        }

        public void AddChartData(List<OHLC> bars)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddChartData Method");

            for (int n = 0; n < bars.Count; n++)
            {
                double jdate = ui_ocxStockChart.ToJulianDate(bars[n]._OHLCTime.Year, bars[n]._OHLCTime.Month,
                                                             bars[n]._OHLCTime.Day, bars[n]._OHLCTime.Hour,
                                                             bars[n]._OHLCTime.Minute, bars[n]._OHLCTime.Second);

                ui_ocxStockChart.AppendValue(_chartSymbol + ".open", jdate, bars[n]._Open);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".high", jdate, bars[n]._High);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".low", jdate, bars[n]._Low);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".close", jdate, bars[n]._Close);
                ui_ocxStockChart.AppendValue(_chartSymbol + ".volume", jdate, bars[n]._Volume);
                if (n%100 == 0) ui_ocxStockChart.Update();
            } //for
            if (bars.Count > 0)
            {
                _lastDateTime = bars[bars.Count - 1]._OHLCTime;
            }

            // Update the chart
            ui_ocxStockChart.Update(); // For VS.NET 2005

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddChartData Method");
        }

        public void AddBarUpdate(OHLC ohlc)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddBarUpdate Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddBarUpdate Method");
        }

        private void ui_ocxStockChart_MouseMoveEvent(object sender,
                                                     _DStockChartXEvents_MouseMoveEvent e)
        {
        }

        private void ui_ocxStockChart_ItemMouseMove(object sender,
                                                    _DStockChartXEvents_ItemMouseMoveEvent e)
        {
        }

        private void ui_ocxStockChart_PaintEvent(object sender, _DStockChartXEvents_PaintEvent e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_ocxStockChart_PaintEvent Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_ocxStockChart_PaintEvent Method");
        }

        public void PriceUpdate(QuoteItem quoteItem) //QuoteResponse MD)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into PriceUpdate Method");

            //DS_ = uctlNewHistoryManager.GetHistoryMgrInstance().GetMyWatchItem(this).DSOHLC_;
            double Price = 0.0;
            double Volume = 0.0;

            switch (quoteItem._quoteType)
            {
                case QuoteStreamType.ASK:
                    {
                        #region "Test data File Write"

                        //{
                        //    FileStream objFileStream;
                        //    //if (!File.Exists(@"E:\TWS Smple\branches\OHLC.txt"))
                        //    //{
                        //    objFileStream = new FileStream(@"E:\TWS Smple\branches\OHLC.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                        //   // }
                        //   // else
                        //    //{
                        //        //objFileStream = new FileStream(@"E:\TWS Smple\branches\OHLC.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                        //    //}
                        //    StreamWriter objStreamWriter = new StreamWriter(objFileStream);
                        //    objStreamWriter.AutoFlush = true;
                        //    //objStreamWriter.WriteLine(DateTime.Now.ToShortDateString());
                        //    objStreamWriter.WriteLine(this._chartSymbol + "=>" + clsUtility.GetDateTime(quoteItem._Time).ToString() + quoteItem._Price.ToString());
                        //}

                        #endregion "Test data File Write"

                        if (quoteItem._Price.ToString().Contains('.'))
                        {
                            ui_ocxStockChart.ScalePrecision =
                                quoteItem._Price.ToString().Split(new[] {'.'},
                                                                  StringSplitOptions.RemoveEmptyEntries)[1].Length;
                        }
                        else
                        {
                            ui_ocxStockChart.ScalePrecision = 0;
                        }
                        Price = quoteItem._Price;
                        Volume = quoteItem._Size;
                    }
                    break;
                case QuoteStreamType.BID:
                    {
                        //Price = quoteItem._Price;
                        //Volume = quoteItem._Size;
                    }
                    break;
                case QuoteStreamType.HIGH:
                    break;
                case QuoteStreamType.LAST:
                    break;
                case QuoteStreamType.LOW:
                    break;
                case QuoteStreamType.VOLUME:
                    break;
            }
            if (Convert.ToInt32(Price) != 0)
            {
                if (OHLCEntity_ == null)
                {
                    //int RowCnt = DS_.Tables[0].Rows.Count;
                    //DateTime LastDateTime = (DS_.Tables[0].Rows[RowCnt - 1] as clsInterface4OME.dsOHLC.tbOHLCRow).ArrivalTime;
                    //DateTime SecondLastDateTime = (DS_.Tables[0].Rows[RowCnt - 2] as clsInterface4OME.dsOHLC.tbOHLCRow).ArrivalTime;
                    TimeSpan ts = CalculateTimeSpan();
                    //TimeSpan.FromMinutes(_barInterval); //LastDateTime - SecondLastDateTime;
                    DateTime OHLCTIME = getOhlcDate(ClsGlobal.GetDateTimeDT(quoteItem._Time));

                    //MD.TimeQuoteSending_
                    //DateTime OHLCTIME = LastDateTime + ts;
                    OHLCEntity_ = new OHLCEntity(Price, Volume, OHLCTIME, ts);


                    double jdate = ui_ocxStockChart.ToJulianDate(OHLCTIME.Year,
                                                                 OHLCTIME.Month,
                                                                 OHLCTIME.Day,
                                                                 OHLCTIME.Hour,
                                                                 OHLCTIME.Minute,
                                                                 OHLCTIME.Second);
                    ui_ocxStockChart.AppendValue(_chartSymbol + ".open", jdate, Price);
                    ui_ocxStockChart.AppendValue(_chartSymbol + ".high", jdate, Price);
                    ui_ocxStockChart.AppendValue(_chartSymbol + ".low", jdate, Price);
                    ui_ocxStockChart.AppendValue(_chartSymbol + ".close", jdate, Price);
                    ui_ocxStockChart.AppendValue(_chartSymbol + ".volume", jdate, 1.0); // Volume);
                }
                else
                {
                    double o, h, l, c, v;
                    o = h = l = c = v = 0.0;
                    DateTime dt = DateTime.UtcNow;
                    bool isNewNBar = OHLCEntity_.UpdateValues(Price, Volume, ClsGlobal.GetDateTimeDT(quoteItem._Time),
                                                              out o, out h, out l, out c, out v, out dt);
                    if (isNewNBar)
                    {
                        int RecordCount = ui_ocxStockChart.RecordCount;
                        ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".open", ui_ocxStockChart.RecordCount, o);
                        ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".high", ui_ocxStockChart.RecordCount, h);
                        ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".low", ui_ocxStockChart.RecordCount, l);
                        ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".close", ui_ocxStockChart.RecordCount, c);
                        ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".volume", ui_ocxStockChart.RecordCount,
                                                           Volume); //v);

                        double jdate = ui_ocxStockChart.ToJulianDate(dt.Year,
                                                                     dt.Month,
                                                                     dt.Day,
                                                                     dt.Hour,
                                                                     dt.Minute,
                                                                     dt.Second);
                        ui_ocxStockChart.AppendValue(_chartSymbol + ".open", jdate, Price);
                        ui_ocxStockChart.AppendValue(_chartSymbol + ".high", jdate, Price);
                        ui_ocxStockChart.AppendValue(_chartSymbol + ".low", jdate, Price);
                        ui_ocxStockChart.AppendValue(_chartSymbol + ".close", jdate, Price);
                        ui_ocxStockChart.AppendValue(_chartSymbol + ".volume", jdate, Volume); //v);//1.0);//Volume);
                    }
                    else
                    {
                        if (ui_ocxStockChart == null)
                            return;

                        if (ui_ocxStockChart != null) //condition by vijay
                        {
                            ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".open", ui_ocxStockChart.RecordCount, o);
                            ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".high", ui_ocxStockChart.RecordCount, h);
                            ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".low", ui_ocxStockChart.RecordCount, l);
                            ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".close", ui_ocxStockChart.RecordCount, c);
                            ui_ocxStockChart.EditValueByRecord(_chartSymbol + ".volume", ui_ocxStockChart.RecordCount,
                                                               Volume); //v); //1.0);//v);
                        }
                    }
                }
                ui_ocxStockChart.Update();
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from PriceUpdate Method");
        }

        private TimeSpan CalculateTimeSpan()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into CalculateTimeSpan Method");

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
                        timeSpan = TimeSpan.FromDays(7*_barInterval);
                    }
                    break;
                case ePeriodicity.Monthly:
                    {
                        timeSpan = TimeSpan.FromDays(30*_barInterval);
                    }
                    break;
            }
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from CalculateTimeSpan Method");

            return timeSpan;
        }

        public DateTime getOhlcDate(DateTime DT)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into getOhlcDate Method");

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
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from getOhlcDate Method");

            return ReturnDateTime;
        }

        private void frmNewChart_Load(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into frmNewChart_Load Method");
            parentForm = ParentForm;
            ((FrmMain) parentForm).ui_nmnuTechnicalAnalysis.Enabled = true;
            ClsTWSDataManager.INSTANCE.onPriceUpdate +=
                INSTANCE_onPriceUpdate;

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from frmNewChart_Load Method");
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> ddQuotes)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into INSTANCE_onPriceUpdate Method");


            foreach (var item in ddQuotes)
            {
                foreach (QuoteItem quoteItem in item.Value._lstItem)
                {
                    string[] str = item.Key.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                    if (_chartSymbol == str[str.Count() - 1])
                    {
                        PriceUpdate(quoteItem);
                    }
                }
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from INSTANCE_onPriceUpdate Method");
        }

        private void frmNewChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into frmNewChart_FormClosing Method");

            ClsTWSDataManager.INSTANCE.onPriceUpdate -=
                INSTANCE_onPriceUpdate;
            Dispose();
            ui_ocxStockChart.Dispose();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from frmNewChart_FormClosing Method");
        }

        private void BindContextMenuEvents()
        {
        }

        private void ui_ocxStockChart_OnRButtonDown(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_ocxStockChart_OnRButtonDown Method");

            //m_UserEditing = true;
            ui_ocxStockChart.UserEditing = true;
            //ui_cmsChart.Show(MousePosition.X, MousePosition.Y);
            //int m_objectType = (int)e.objectType;

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_ocxStockChart_OnRButtonDown Method");
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

        private void ui_mnuDeleteObject_Click(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_mnuDeleteObject_Click Method");

            switch (m_objectType)
            {
                case OBJECT_LINE_VERTICAL:
                    ui_ocxStockChart.RemoveObject(ObjectType.otVerticalLineObject, m_name);
                    break;
                case OBJECT_LINE_HORIZONTAL:
                    ui_ocxStockChart.RemoveObject(ObjectType.otLineStudyObject, m_name);
                    break;
                case OBJECT_LINE_ELLIPSE:
                    ui_ocxStockChart.RemoveObject(ObjectType.otEllipseObject, m_name);
                    break;
                case OBJECT_LINE_ERRORCHANNEL:
                    ui_ocxStockChart.RemoveObject(ObjectType.otErrorChannelsObject, m_name);
                    break;
                case OBJECT_LINE_FIBARCS:
                    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciArcsObject, m_name);
                    break;
                case OBJECT_LINE_FIBFAN:
                    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciFanObject, m_name);
                    break;
                case OBJECT_LINE_FIBRETRACEMENT:
                    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciRetracementObject, m_name);
                    break;
                case OBJECT_LINE_FIBTIMEZONE:
                    ui_ocxStockChart.RemoveObject(ObjectType.otFibonacciTimezoneObject, m_name);
                    break;
                case OBJECT_LINE_FREEHAND:
                    ui_ocxStockChart.RemoveObject(ObjectType.otFreeHandObject, m_name);
                    break;
                case OBJECT_LINE_GANNFAN:
                    ui_ocxStockChart.RemoveObject(ObjectType.otGannFanObject, m_name);
                    break;
                case OBJECT_LINE_QUADRANTLNES:
                    ui_ocxStockChart.RemoveObject(ObjectType.otLineStudyObject, m_name);
                    break;
                case OBJECT_LINE_RAFFREGRESSION:
                    ui_ocxStockChart.RemoveObject(ObjectType.otRaffRegressionObject, m_name);
                    break;
                case OBJECT_LINE_RECTANGLE:
                    ui_ocxStockChart.RemoveObject(ObjectType.otRectangleObject, m_name);
                    break;
                case OBJECT_LINE_SPEEDLINES:
                    ui_ocxStockChart.RemoveObject(ObjectType.otSpeedLineObject, m_name);
                    break;
                case OBJECT_LINE_TIRONELEVELS:
                    ui_ocxStockChart.RemoveObject(ObjectType.otTironeLevelsObject, m_name);
                    break;
                case OBJECT_LINE_ORDER:
                    ui_ocxStockChart.RemoveObject(ObjectType.otSymbolObject, m_name);
                    break;
                case OBJECT_LINE_TEXT:
                    ui_ocxStockChart.RemoveObject(ObjectType.otTextObject, m_name);
                    break;
                case OBJECT_LINE_STANDARD:
                    ui_ocxStockChart.RemoveObject(ObjectType.otTrendLineObject, m_name);
                    break;
            }
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_mnuDeleteObject_Click Method");
        }

        private void ui_ocxStockChart_ItemRightClick(object sender,
                                                     _DStockChartXEvents_ItemRightClickEvent e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_ocxStockChart_ItemRightClick Method");

            m_objectType = (int) e.objectType;
            m_name = e.name;
            Application.DoEvents();
            m_UserEditing = true;
            ui_ocxStockChart.UserEditing = true;
            ui_cmsChart.Show(MousePosition.X, MousePosition.Y);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_ocxStockChart_ItemRightClick Method");
        }

        private void frmNewChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            if (count > 0)
                ((FrmMain) parentForm).ui_nmnuTechnicalAnalysis.Enabled = true;
            else
                ((FrmMain) parentForm).ui_nmnuTechnicalAnalysis.Enabled = false;
        }

        private void ui_mnuProperties_Click(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_mnuProperties_Click Method");

            //try
            {
                BarData[] Data1; //GTS.DataManager.BarData[] Data1;
                Data1 = GetDataFromChart();
                FillCurrentChartProperties();
                double minY = ui_ocxStockChart.GetMinValue(ui_ocxStockChart.Symbol + ".close");
                double maxY = ui_ocxStockChart.GetMaxValue(ui_ocxStockChart.Symbol + ".close");
                var prop = new FrmProperties(ui_ocxStockChart.Symbol, Data1, _chartProperties, minY, maxY);
                DialogResult dlg = prop.ShowDialog();

                if (dlg == DialogResult.OK)
                {
                    _chartProperties = prop.Props;
                    //frmMainGTS.GetReference().cp = prop.props;
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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_mnuProperties_Click Method");
        }

        public void FillCurrentChartProperties()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FillCurrentChartProperties Method");

            _chartProperties.backGround = ui_ocxStockChart.ChartBackColor;
            _chartProperties.foreGround = ui_ocxStockChart.ChartForeColor;
            _chartProperties.grid = ui_ocxStockChart.Gridcolor;
            _chartProperties.barUp = ui_ocxStockChart.UpColor;
            _chartProperties.barDown = ui_ocxStockChart.DownColor;
            _chartProperties.bullCandle = ui_ocxStockChart.CandleUpOutlineColor;
            _chartProperties.bearCandle = ui_ocxStockChart.CandleDownOutlineColor;
            _chartProperties.lineGraph = ui_ocxStockChart.LineGraphColor;
            //_chartProperties.volume= ui_ocxStockChart.vo;
            _chartProperties.askLine = ui_ocxStockChart.AskLineColor;
            _chartProperties.stopLevels = ui_ocxStockChart.StopLevelsColor;
            _chartProperties.SLLine = ui_ocxStockChart.SLColor;
            _chartProperties.TPPline = ui_ocxStockChart.TPColor;
            //_chartProperties.offlinechart = ui_ocxStockChart.c;
            _chartProperties.forgroundChart = ui_ocxStockChart.ForegroundChart;
            //_chartProperties.chartShift = ui_ocxStockChart.RightDrawingSpacePixels;
            _chartProperties.chartAutoScroll = ui_ocxStockChart.AutoScroll;
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
            _chartProperties.showOHLC = ui_ocxStockChart.ShowOHLC;
            //_chartProperties.showAskLine = ui_ocxStockChart.ask;
            _chartProperties.periodSeperator = ui_ocxStockChart.ShowPeriodSeparators;
            _chartProperties.showGrid = ui_ocxStockChart.XGrid || ui_ocxStockChart.YGrid;
            _chartProperties.showVolume = ui_ocxStockChart.ShowVolumes;
            //_chartProperties.objDescription = ui_ocxStockChart.ShowObjectDescriptions;
            _chartProperties.ThreeDStyle = ui_ocxStockChart.ThreeDStyle;

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from FillCurrentChartProperties Method");
        }

        public BarData[] GetDataFromChart()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into GetDataFromChart Method");

            var bars = new List<BarData>();
            string Symbol = ui_ocxStockChart.Symbol;
            int count = ui_ocxStockChart.RecordCount;

            if (count > 30)
                count = 30;

            for (int n = 1; n <= count; n++)
            {
                var bar = new BarData
                              {
                                  iTradeDate =
                                      Convert.ToDateTime(
                                          ui_ocxStockChart.FromJulianDate(
                                              ui_ocxStockChart.GetJDate(Symbol + ".Close", n))).ToBinary(),
                                  OpenPrice = ui_ocxStockChart.GetValue(Symbol + ".Open", n),
                                  HighPrice = ui_ocxStockChart.GetValue(Symbol + ".High", n),
                                  LowPrice = ui_ocxStockChart.GetValue(Symbol + ".Low", n),
                                  ClosePrice = ui_ocxStockChart.GetValue(Symbol + ".Close", n),
                                  Volume = ui_ocxStockChart.GetValue(Symbol + ".Volume", n)
                              };
                bars.Add(bar);
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from GetDataFromChart Method");

            return bars.ToArray();
        }

        public void SetChartProperties(ChartProperty props)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetChartProperties Method");

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
                    ui_ocxStockChart.SLColor = props.SLLine;
                    ui_ocxStockChart.TPColor = props.TPPline;
                    ui_ocxStockChart.ChartBackColor = props.backGround;
                    ui_ocxStockChart.ChartForeColor = props.foreGround;
                    ui_ocxStockChart.Gridcolor = props.grid;
                    ui_ocxStockChart.UpColor = props.barUp;
                    ui_ocxStockChart.DownColor = props.barDown;
                    ui_ocxStockChart.CandleUpOutlineColor = props.bullCandle;
                    ui_ocxStockChart.CandleDownOutlineColor = props.bearCandle;
                    ui_ocxStockChart.LineGraphColor = props.lineGraph;
                    ui_ocxStockChart.AskLineColor = props.askLine;
                    ui_ocxStockChart.StopLevelsColor = props.stopLevels;
                    if (volPanel != -1)
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".volume",
                                                         ColorTranslator.ToOle(props.volume));

                    //// **************** Common Properties *******************

                    // Offline Chart
                    //if (props.offlinechart)
                    //{
                    //    if (!frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text.Contains("(Offline)"))
                    //    {
                    //        string temp_Str = frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text;
                    //        frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text += " (Offline)";
                    //        ReplaceChartNameInNavigator(frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text, temp_Str);
                    //        ChartName.Properties.Text = frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text;
                    //    }
                    //}
                    //else
                    //{
                    //    NUIDocument active_doc = frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument;
                    //    if (active_doc != null)
                    //    {
                    //        if (active_doc.Text.IndexOf("Offline") > 0)
                    //        {
                    //            string temp_Str = frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text;
                    //            ReplaceChartNameInNavigator(frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text, temp_Str);
                    //            ChartName.Properties.Text = frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text;
                    //        }
                    //    }
                    //}

                    // Chart On ForeGround
                    ui_ocxStockChart.ForegroundChart = props.forgroundChart;

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
                    ui_ocxStockChart.AutoScroll = props.chartAutoScroll;

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

                    ui_ocxStockChart.ShowOHLC = props.showOHLC;
                    // Show Ask Line
                    // Note: ShowAskLine() is called in chart Paint event
                    m_showAskLine = props.showAskLine;
                    // Show Period Separators
                    ui_ocxStockChart.ShowPeriodSeparators = props.periodSeperator;
                    ui_ocxStockChart.XGrid = props.showGrid;
                    ui_ocxStockChart.YGrid = props.showGrid;
                    ui_ocxStockChart.ShowVolumes = props.showVolume;
                    ui_ocxStockChart.ThreeDStyle = props.ThreeDStyle;
                    _chartProperties = props;
                    ui_ocxStockChart.Update();
                }
                //catch (Exception ex)
                {
                }
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetChartProperties Method");
        }

        private void ui_mnuSelectSymbol_Click(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_mnuSelectSymbol_Click Method");

            var objfrmSelectSymbolForChart = new frmSelectSymbolForChart();
            objfrmSelectSymbolForChart.OnOkClick +=
                objfrmSelectSymbolForChart_OnOkClick;
            objfrmSelectSymbolForChart.ShowDialog(this);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_mnuSelectSymbol_Click Method");
        }

        private void objfrmSelectSymbolForChart_OnOkClick(string symbol, ePeriodicity periodicity)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into objfrmSelectSymbolForChart_OnOkClick Method");

            InitChartData(symbol, periodicity);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from objfrmSelectSymbolForChart_OnOkClick Method");
        }

        private void ui_tsmDeleteIndicator_Click(object sender, EventArgs e)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ui_tsmDeleteIndicator_Click Method");

            DeleteIndicator(m_name);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ui_tsmDeleteIndicator_Click Method");
        }

        public void DeleteIndicator(string name)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into DeleteIndicator Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from DeleteIndicator Method");
        }

        private void ui_ocxStockChart_ClickEvent(object sender, EventArgs e)
        {
            Activate();
        }

        #region "       Menu Handler Methods        "

        public void ChangeChartType(SeriesType stType, ChartProperty cprop)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangeChartType Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangeChartType Method");
        }

        public void ChangePriceStyle(PriceType priceType)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangePriceStyle Method");

            crtPriceType = priceType;
            //try
            {
                switch (priceType)
                {
                    case PriceType.POINT_AND_FIGURE:
                        ui_ocxStockChart.set_PriceStyleParam(1, 0); // Allow StockChartX to figure the box size
                        ui_ocxStockChart.set_PriceStyleParam(2, 3); // Reversal size
                        ui_ocxStockChart.PriceStyle = PriceStyle.psPointAndFigure;
                        break;
                    case PriceType.RENKO:
                        ui_ocxStockChart.set_PriceStyleParam(1, 1); // Reversal size
                        ui_ocxStockChart.PriceStyle = PriceStyle.psRenko;
                        break;
                    case PriceType.KAGI:
                        ui_ocxStockChart.set_PriceStyleParam(1, 1); // Reversal size
                        ui_ocxStockChart.set_PriceStyleParam(2, (int) DataType.dtPoints);
                        // Points or percent (eg 1 or 0.01)
                        ui_ocxStockChart.PriceStyle = PriceStyle.psKagi;
                        break;
                    case PriceType.THREE_LINE_BREAK:
                        ui_ocxStockChart.set_PriceStyleParam(1, 3); // Three line break (could be 1 to 50 line break)
                        ui_ocxStockChart.PriceStyle = PriceStyle.psThreeLineBreak;
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
                        //cp.barChart = false;
                        //cp.lineChart = false;
                        //cp.candleSticks = true;
                        //ChangeChartType(SeriesType.stCandleChart, cp);
                        break;
                }

                ui_ocxStockChart.Update();
            }
            //catch (Exception ex)
            //{

            //}

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangePriceStyle Method");
        }


        public void ChangePeriodicity(ePeriodicity periodicity, int interval, NewHistoryType historyType)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangePeriodicity Method");

            Action A = () =>
                           {
                               ui_ocxStockChart.ClearAllSeries();
                               OHLCEntity_ = null;
                               _chartBarType = periodicity;
                               _barInterval = interval;
                               ChartHistoryType_ = historyType;
                               SetChartBarInterval();

                               Text = ui_ocxStockChart.Symbol + " : " +
                                      periodicity.ToString().Split(new[] {'_'},
                                                                   StringSplitOptions.RemoveEmptyEntries)[0] +
                                      "_" + interval;
                               ui_ocxStockChart.Update();
                           };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangePeriodicity Method");
        }

        public void ChangeChartType(ChartType chartType)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ChangeChartType Method");

            crtChartType = chartType;
            switch (chartType)
            {
                case ChartType.BAR:
                    {
                        ChangeChartSeriesType(SeriesType.stStockBarChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(Color.Lime));
                    }
                    break;
                case ChartType.CANDLE:
                    {
                        ChangeChartSeriesType(SeriesType.stCandleChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(Color.Lime));
                    }
                    break;
                case ChartType.LINE:
                    {
                        ChangeChartSeriesType(SeriesType.stLineChart);
                        ui_ocxStockChart.set_SeriesColor(ui_ocxStockChart.Symbol + ".close",
                                                         ColorTranslator.ToOle(ui_ocxStockChart.LineGraphColor));
                    }
                    break;
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ChangeChartType Method");
        }

        private void ChangeChartSeriesType(SeriesType seriesType)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ChangeChartSeriesType Method");

            //string Symbol = ui_ocxStockChart.Symbol;
            //cp = cprop;
            ui_ocxStockChart.set_SeriesType(_chartSymbol + ".open", seriesType);
            ui_ocxStockChart.set_SeriesType(_chartSymbol + ".high", seriesType);
            ui_ocxStockChart.set_SeriesType(_chartSymbol + ".low", seriesType);
            ui_ocxStockChart.set_SeriesType(_chartSymbol + ".close", seriesType);

            if (seriesType == SeriesType.stLineChart)
                ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".close", ColorTranslator.ToOle(Color.Lime));
            else
                ui_ocxStockChart.set_SeriesColor(_chartSymbol + ".close", ColorTranslator.ToOle(Color.Lime));

            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from ChangeChartSeriesType Method");
        }

        public void ZoomIn()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ZoomIn Method");

            ui_ocxStockChart.ZoomIn(5); //ui_ocxStockChart.RecordCount);//5);
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ZoomIn Method");
        }

        public void ZoomOut()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into ZoomOut Method");

            ui_ocxStockChart.ZoomIn(5); //ui_ocxStockChart.RecordCount);//5);
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ZoomOut Method");
        }

        public void TrackCursor()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TrackCursor Method");

            ui_ocxStockChart.CrossHairs = !ui_ocxStockChart.CrossHairs;
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TrackCursor Method");
        }

        public void SetVolumeDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetVolumeDisplay Method");

            ui_ocxStockChart.ShowVolumes = !ui_ocxStockChart.ShowVolumes;
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetVolumeDisplay Method");
        }

        public void SetGridDisplay(bool status)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SetGridDisplay Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SetGridDisplay Method");
        }

        public void Set3DStyle()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into Set3DStyle Method");

            ui_ocxStockChart.ThreeDStyle = !ui_ocxStockChart.ThreeDStyle;
            ui_ocxStockChart.Update();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from Set3DStyle Method");
        }

        public void PrintChart()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into PrintChart Method");

            ui_ocxStockChart.PrintChart();

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from PrintChart Method");
        }

        public void SaveChart()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SaveChart Method");

            var objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "(*.icx)|*.icx";
            objSaveFileDialog.Title = "Save";
            objSaveFileDialog.DefaultExt = ".icx";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                ui_ocxStockChart.SaveFile(objSaveFileDialog.FileName);
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SaveChart Method");
        }

        public void AddIndicatorList()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddIndicatorList Method");

            IndicatorSelection selection = (new frmIndicator()).GetIndicatorSelection();
            if (selection.IndicatorName == null)
                return;
            Application.DoEvents();
            AddIndicator(selection, -1);

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddIndicatorList Method");
        }

        public void AddIndicator(IndicatorSelection indicator, int currPanel)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddIndicator Method");

            //try
            {
                //if (frmMainGTS.GetReference().m_DockManager.DocumentManager.Documents.Length.Equals(0))
                //    return;
                //else if (frmMainGTS.GetReference().m_DockManager.DocumentManager.ActiveDocument.Text == "Eco Calendar")
                //    return;
                //else if (ui_ocxStockChart.RecordCount < 3) return;
                string cnt = "";
                int n = ui_ocxStockChart.GetIndicatorCountByType((Indicator) indicator.node);
                if (n > 0)
                {
                    cnt = " " + (n + 1);
                }
                var ind = (Indicator) (indicator.node);
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
            //catch (Exception ex)
            //{

            //}

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddIndicator Method");
        }

        public void AddCustomIndicator(string cnt, string indName, int panel)
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddCustomIndicator Method");

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

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddCustomIndicator Method");
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

        public void AddHorizontalLine()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddHorizontalLine Method");

            //try
            {
                // double x = -1;
                ui_ocxStockChart.AddHorizontalLine(-1, -1);
            }
            //catch (Exception ex)
            {
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddHorizontalLine Method");
        }

        public void AddVerticalLine()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddVerticalLine Method");

            //try
            {
                ui_ocxStockChart.AddVerticalLines(-1);
            }
            //catch (Exception ex)
            {
            }
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddVerticalLine Method");
        }

        public void AddText()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into AddText Method");

            //try
            {
                ui_ocxStockChart.AddUserDefinedText("My Text" + Convert.ToString(DateTime.Now));
            }
            //catch (Exception ex)
            {
            }

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from AddText Method");
        }

        public void TrendLineDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TrendLineDisplay Method");

            ui_ocxStockChart.AddUserTrendLine("Trendline " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TrendLineDisplay Method");
        }

        public void EllipseDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into EllipseDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsEllipse, "Ellipse " + Convert.ToString(DateTime.Now));
            //StudyType.lsEllipse, Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from EllipseDisplay Method");
        }

        public void SpeedLineDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into SpeedLineDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsSpeedLines, "Speedlines " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from SpeedLineDisplay Method");
        }

        public void GannFanDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into GannFanDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsGannFan, "Gann Fan " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from GannFanDisplay Method");
        }

        public void FibonacciArcsDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FibonacciArcsDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciArcs, "Fibonacci Arcs " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from FibonacciArcsDisplay Method");
        }

        public void FibonacciRetracementDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FibonacciRetracementDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciRetracements,
                                           "Fibonacci Retracements " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from FibonacciRetracementDisplay Method");
        }

        public void FibonacciFanDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FibonacciFanDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciFan, "Fibonacci Fan " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from FibonacciFanDisplay Method");
        }

        public void FibonacciTimezoneDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FibonacciTimezoneDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFibonacciTimeZones,
                                           "Fibonacci Timezones " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from FibonacciTimezoneDisplay Method");
        }

        public void TironeLevelDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into TironeLevelDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsTironeLevels, "Tirone Levels " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from TironeLevelDisplay Method");
        }

        public void QuadrentLinesDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into QuadrentLinesDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsQuadrantLines, "Quadrant Lines " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from QuadrentLinesDisplay Method");
        }

        public void RafRegressionDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into RafRegressionDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsRaffRegression,
                                           "Raff regression " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from RafRegressionDisplay Method");
        }

        public void ErrorChannelDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into ErrorChannelDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsErrorChannel, "Error Channel " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from ErrorChannelDisplay Method");
        }

        public void RectangleDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Enter into RectangleDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsRectangle, "Rectangle " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol + " : Exit from RectangleDisplay Method");
        }

        public void FreeHandDrawingDisplay()
        {
            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Enter into FreeHandDrawingDisplay Method");

            ui_ocxStockChart.DrawLineStudy(StudyType.lsFreehand, "Freehand " + Convert.ToString(DateTime.Now));

            FileHandling.WriteDevelopmentLog("Chart " + _chartSymbol +" : Exit from FreeHandDrawingDisplay Method");
        }

        #region "    Techincal Analysis Add submenu handlers    "

        #endregion "    Techincal Analysis Add submenu handlers    "

        public class IndicatorsNode
        {
            public Indicator Ind;
            public string IndicatorText;
            public int Panel;
        }

        #endregion "      Menu Handler Methods       "
    }

    public enum ePeriodicity : byte
    {
        Secondly = 9,
        Minutely_1 = 0,
        Minutely_5 = 1,
        Minutely_15 = 2,
        Minutely_30 = 3,
        Hourly_1 = 4,
        Hourly_4 = 5,
        Daily = 6,
        Weekly = 7,
        Monthly = 8
    }

    public class OHLC
    {
        public double _Close;
        public double _High;
        public double _Low;
        public DateTime _OHLCTime;
        public double _Open;
        public long _Volume;
    }

    public enum NewHistoryType
    {
        YEAR = 0,
        QUARTER = 1,
        MONTH = 2,
        DAY = 3,
        WEEK = 4,
        HOUR = 5,
        MINUTE = 6,
        SECOND = 7,
        TICK = 8,
        VOLUME = 9
    }

    public enum ChartType
    {
        BAR,
        CANDLE,
        LINE
    }

    public enum PriceType
    {
        POINT_AND_FIGURE,
        RENKO,
        KAGI,
        THREE_LINE_BREAK,
        EQUI_VOLUME,
        EQUI_VOLUME_SHADOW,
        CANDLE_VOLUME,
        HEIKIN_ASHI,
        STANDARD_CHART,
    }

    internal class OHLCEntity
    {
        private readonly TimeSpan TS_;
        private double Close_;
        private double High_;
        private double Low_;
        private DateTime NextOHLCTime_;
        private DateTime OHLCTime_;
        private double Open_;
        private double Volume_;
        private int _Counter;

        public OHLCEntity(double Price, double Volume, DateTime CurrDT, TimeSpan ts)
        {
            Open_ = Price;
            High_ = Price;
            Low_ = Price;
            Close_ = Price;
            Volume_ = Volume;
            OHLCTime_ = CurrDT;
            NextOHLCTime_ = OHLCTime_ + ts;
            TS_ = ts;
            _Counter = 1;
        }

        public double OPEN
        {
            get { return Open_; }
            set { Open_ = value; }
        }

        public double HIGH
        {
            get { return High_; }
            set { High_ = Math.Max(High_, value); }
        }

        public double LOW
        {
            get { return Low_; }
            set { Low_ = Math.Min(Low_, value); }
        }

        public double CLOSE
        {
            get { return Close_; }
            set { Close_ = value; }
        }

        public double VOLUME
        {
            get { return Volume_; }
            set { Volume_ = Volume_ + value; }
        }

        public bool UpdateValues(double Price, double Volume, DateTime DT,
                                 out double o, out double h, out double l,
                                 out double c, out double v, out DateTime OHLCTIME)
        {
            bool status = false;
            o = 0.0;
            h = 0.0;
            l = 0.0;
            c = 0.0;
            v = 0.0;
            OHLCTIME = DateTime.Now; //DateTime.UtcNow;
            if (DT >= NextOHLCTime_)
            {
                status = true;
                OPEN = CLOSE; //by vijay
                CLOSE = Price; //by vijay
                o = OPEN;
                h = HIGH;
                l = LOW;
                c = CLOSE;
                v = VOLUME;
                Open_ = High_ = Low_ = Close_ = Price;
                v = _Counter; //v;
                _Counter = 1;
                OHLCTIME = NextOHLCTime_;
                OHLCTime_ = NextOHLCTime_;
                NextOHLCTime_ = OHLCTime_ + TS_;
            }
            else
            {
                HIGH = Price;
                LOW = Price;
                VOLUME = Volume;
                o = OPEN;
                h = HIGH;
                l = LOW;
                //if (DT >= NextOHLCTime_ - TimeSpan.FromSeconds(1))
                //{
                //    c = Price; //Price; //CLOSE;
                //}
                //else
                //{
                //    c = CLOSE;
                //}
                CLOSE = Price; //by vijay
                c = Price; //CLOSE;
                v = VOLUME;
                ++_Counter;
            }
            return status;
        }
    }
}