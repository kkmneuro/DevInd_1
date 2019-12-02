using System;
using System.Drawing;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
//using STOCKCHARTXLib;//by Namo

//using ProtocolStructs;

namespace PALSA.Frm
{
    public partial class FrmProperties : NForm
    {
        //bool offlinechart;
        //bool forgroundChart;
        //bool ChartShift;
        //bool chartAutoScroll;
        //bool ScaleFixOne;
        //bool ScaleFix;
        //bool BarChart;
        //bool CandleSticks;
        //bool lineChart;
        //bool showOHLC;
        //bool ShowAskLine;
        //bool PeriodSeperator;
        //bool ShowGrid;
        //bool ShowVolume;
        //bool objDescription;
        private readonly string Symbol;
        private readonly double maxY;
        private readonly double minY;
        public ChartProperty Props = new ChartProperty();

        /// <summary>
        /// This is constructor function of FrmProperties
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="data"></param>
        /// <param name="cp"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        public FrmProperties(string symbol, BarData[] data, ChartProperty cp, double minY, double maxY)
        {
            InitializeComponent();

            Symbol = symbol;
            Props = cp;
            this.minY = minY;
            this.maxY = maxY;
            LoadChart(symbol, data);
            SetLoadChartColor();
            //ApplyCommonProperty();
            LoadChartProperty(ref Props);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetCommonProperty()
        {
        }

        /// <summary>
        /// used to load chart colors over charts
        /// </summary>
        private void SetLoadChartColor()
        {
            //try
            {
                StockChartX1.ChartBackColor = Props.backGround;
                StockChartX1.ChartForeColor = Props.foreGround;
                StockChartX1.Gridcolor = Props.grid;
                StockChartX1.UpColor = Props.barUp;
                StockChartX1.DownColor = Props.barDown;
                StockChartX1.CandleUpOutlineColor = Props.bullCandle;
                StockChartX1.CandleDownOutlineColor = Props.bearCandle;
                StockChartX1.LineGraphColor = Props.lineGraph;
                // StockChartX1.AskLineColor = props.askline;
                // StockChartX1.StopLevelsColor = props.stopLevels;

                int volPanel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");

                if (volPanel != -1)
                    StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(Props.volume));

                StockChartX1.Update();
            }
            //catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// used to load chart after removing pervious All Series and Loads new charts         //Commented by Namo
        /// </summary>
        /// <param name="Symbol">symbol like EURJPY,EURUSD</param>
        /// <param name="Data">Data like EURJPY 8 Min</param>
        //public void LoadChart(string Symbol, BarData[] Data)
        //{
        //    //try
        //    {
        //        StockChartX1.RemoveAllSeries();

        //        StockChartX1.Symbol = Symbol.Replace(".", "");
        //        StockChartX1.Visible = true;

        //        //First add a panel (chart area) for the OHLC data:
        //        var panel = (short) StockChartX1.AddChartPanel();

        //        //Now add the open, high, low and close series to that panel:
        //        StockChartX1.AddSeries(Symbol + ".open", SeriesType.stCandleChart, panel);
        //        StockChartX1.AddSeries(Symbol + ".high", SeriesType.stCandleChart, panel);
        //        StockChartX1.AddSeries(Symbol + ".low", SeriesType.stCandleChart, panel);
        //        StockChartX1.AddSeries(Symbol + ".close", SeriesType.stCandleChart, panel);

        //        //Change the color:               
        //        StockChartX1.set_SeriesColor(Symbol + ".close", ColorTranslator.ToOle(Color.Lime));
        //        double jDate = 0;

        //        short row = 2;

        //        if (Data.Length > 20)
        //        {
        //            row = (short) (Data.Length - 20);
        //        }

        //        //Add the volume chart panel
        //        panel = (short) StockChartX1.AddChartPanel();
        //        StockChartX1.AddSeries(Symbol + ".volume", SeriesType.stVolumeChart, panel);

        //        //Change volume color and weight of the volume panel:
        //        StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(Color.Blue));
        //        StockChartX1.set_SeriesWeight(Symbol + ".volume", 1);

        //        //Resize the volume panel to make it smaller
        //        StockChartX1.set_PanelY1(1, (int) Math.Round(StockChartX1.Height*0.8));

        //        for (; row <= Data.Length - 1; row++)
        //        {
        //            jDate = StockChartX1.ToJulianDate(Data[row].TradeDate.Year, Data[row].TradeDate.Month,
        //                                              Data[row].TradeDate.Day, Data[row].TradeDate.Hour,
        //                                              Data[row].TradeDate.Minute, Data[row].TradeDate.Second);
        //            StockChartX1.AppendValue(Symbol + ".open", jDate, Data[row].OpenPrice);
        //            StockChartX1.AppendValue(Symbol + ".high", jDate, Data[row].HighPrice);
        //            StockChartX1.AppendValue(Symbol + ".low", jDate, Data[row].LowPrice);
        //            StockChartX1.AppendValue(Symbol + ".close", jDate, Data[row].ClosePrice);
        //            StockChartX1.AppendValue(Symbol + ".volume", jDate, Data[row].Volume);
        //        }

        //        StockChartX1.ScalePrecision = 4;
        //        StockChartX1.CurrentTickLine = true;
        //        StockChartX1.MaxDisplayRecords = Width/11;

        //        StockChartX1.Update();
        //    }
        //    // catch (Exception ex)
        //    {
        //    }
        //}

        private void nComboBox2_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// used for chart preview         //Commented by Namo
        /// </summary>
        //private void PreviewChart()
        //{
        //    //try
        //    {
        //        StockChartX1.ChartBackColor = colBtnBackground.Color;
        //        StockChartX1.ChartForeColor = colBtnForground.Color;
        //        StockChartX1.Gridcolor = colBtnGrid.Color;
        //        StockChartX1.UpColor = colBtnBarUp.Color;
        //        StockChartX1.DownColor = colBtnBarDown.Color;
        //        StockChartX1.CandleUpOutlineColor = colBtnBullCandle.Color;
        //        StockChartX1.CandleDownOutlineColor = colBtnBearCandle.Color;
        //        StockChartX1.LineGraphColor = colBtnLineGraph.Color;
        //        // StockChartX1.AskLineColor = colBtnAskLine.Color;
        //        // StockChartX1.StopLevelsColor = colBtnStopLevels.Color;

        //        int panel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");

        //        if (panel != -1)
        //        {
        //            StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(colBtnVolume.Color));
        //        }


        //        StockChartX1.Update();
        //    }
        //    //catch (Exception ex)
        //    {
        //    }
        //}

        /// <summary>
        /// This function Changes the Color scheme like 
        /// SetYellowOnBlack,SetGreenOnBlack,SetBlackOnWhite over charts data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColorScheme.SelectedIndex == 0)
            {
                SetYellowOnBlack();
            }
            else if (cboColorScheme.SelectedIndex == 1)
            {
                SetGreenOnBlack();
            }
            else if (cboColorScheme.SelectedIndex == 2)
            {
                SetBlackOnWhite();
            }

            PreviewChart();
        }

        /// <summary>
        /// set yellow on balck color on chart
        /// </summary>
        private void SetYellowOnBlack()
        {
            //try
            {
                colBtnBackground.Color = Color.Black;
                colBtnForground.Color = Color.FromArgb(114, 114, 114); //Color.White;
                colBtnGrid.Color = Color.LightSlateGray;
                colBtnBarUp.Color = Color.Yellow;
                colBtnBarDown.Color = Color.Yellow;
                colBtnBullCandle.Color = Color.Black;
                colBtnBearCandle.Color = Color.White;
                colBtnLineGraph.Color = Color.Yellow;
                colBtnVolume.Color = Color.LimeGreen;
                colBtnAskLine.Color = Color.Red;
                colBtnStopLevels.Color = Color.Red;
            }
            //catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// set greenOnblack on chart
        /// </summary>
        private void SetGreenOnBlack()
        {
            //try
            {
                colBtnBackground.Color = Color.Black;
                colBtnForground.Color = Color.FromArgb(114, 114, 114); //Color.White;
                colBtnGrid.Color = Color.LightSlateGray;
                colBtnBarUp.Color = Color.Lime;
                colBtnBarDown.Color = Color.Lime;
                colBtnBullCandle.Color = Color.Black;
                colBtnBearCandle.Color = Color.White;
                colBtnLineGraph.Color = Color.Lime;
                colBtnVolume.Color = Color.LimeGreen;
                colBtnAskLine.Color = Color.Red;
                colBtnStopLevels.Color = Color.Red;
            }
            //catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// set blackon white on chart
        /// </summary>
        private void SetBlackOnWhite()
        {
            //try
            {
                colBtnBackground.Color = Color.White;
                colBtnForground.Color = Color.Black;
                colBtnGrid.Color = Color.Silver;
                colBtnBarUp.Color = Color.Black;
                colBtnBarDown.Color = Color.Black;
                colBtnBullCandle.Color = Color.White;
                colBtnBearCandle.Color = Color.Black;
                colBtnLineGraph.Color = Color.Black;
                colBtnVolume.Color = Color.Green;
                colBtnAskLine.Color = Color.OrangeRed;
                colBtnStopLevels.Color = Color.OrangeRed;
            }
            //catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// used to perform reset operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            colBtnBackground.Color = StockChartX1.ChartBackColor = Color.Black;
            colBtnForground.Color = StockChartX1.ChartForeColor = Color.FromArgb(114, 114, 114); //.White;
            colBtnGrid.Color = StockChartX1.Gridcolor = Color.FromArgb(30, 32, 41); //LightSlateGray;
            colBtnBarUp.Color = StockChartX1.UpColor = Color.Lime;
            colBtnBarDown.Color = StockChartX1.DownColor = Color.Red;
            colBtnBullCandle.Color = StockChartX1.CandleUpOutlineColor = Color.Lime;
            colBtnBearCandle.Color = StockChartX1.CandleDownOutlineColor = Color.Red;
            colBtnLineGraph.Color = StockChartX1.LineColor = Color.Lime;
            // StockChartX1.AskLineColor = Color.Red;
            // StockChartX1.StopLevelsColor = Color.Red;

            int panel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");

            if (panel != -1)
            {
                colBtnVolume.Color = Color.LimeGreen;
                StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(Color.LimeGreen));
            }

            StockChartX1.Update();
            //LoadChartProperty(ref props);
            chkOfflineChart.Checked = Props.offlinechart = false;
            chkForgroundChart.Checked = Props.forgroundChart = false;
            chkChartShift.Checked = Props.chartShift = false;
            chkChartAutoScroll.Checked = Props.chartAutoScroll = true;
            chkScaleFixone.Checked = Props.scaleFixOne = false;
            chkScalefix.Checked = Props.scaleFix = false;
            rdoBarChart.Checked = Props.barChart = false;
            rdoCandleSticks.Checked = Props.candleSticks = true;
            rdoLineChart.Checked = Props.lineChart = false;
            chkShowOHLC.Checked = Props.showOHLC = false;
            chkShowAskLine.Checked = Props.showAskLine = false;
            chkPeriodSeperator.Checked = Props.periodSeperator = false;
            chkShowGrid.Checked = Props.showGrid = true;
            chkShowVolumes.Checked = Props.showVolume = true;
            chkObjDescrption.Checked = Props.objDescription = false;
            chk3D.Checked = Props.ThreeDStyle = false;
        }

        //private void SetChartShift()
        //{
        //    if (chkChartShift.Checked == true)
        //    {
        //        StockChartX1.RightDrawingSpacePixels = 700;
        //        StockChartX1.Update();
        //    }
        //    else
        //    {
        //        StockChartX1.RightDrawingSpacePixels = 70;
        //        StockChartX1.Update();
        //    }
        //}

        /// <summary>
        /// used to perform Ok Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyColors();

            LoadChartProperty(ref Props);
            DialogResult = DialogResult.OK;
            ApplyCommonProperty();
            //frmMainGTS.GetReference().EnableDisabelEcoCalandar(!chkOfflineChart.Checked);
            Close();
        }

        /// <summary>
        /// used to change chart style *commented by Namo
        /// </summary>       /// <param name="BarStyle"></param>
        //public void ChangeChartStyle(SeriesType stType)
        //{
        //    string Symbol = StockChartX1.Symbol;

        //    StockChartX1.PriceStyle = PriceStyle.psStandard;

        //    StockChartX1.set_SeriesType(Symbol + ".open", stType);
        //    StockChartX1.set_SeriesType(Symbol + ".high", stType);
        //    StockChartX1.set_SeriesType(Symbol + ".low", stType);
        //    StockChartX1.set_SeriesType(Symbol + ".close", stType);

        //    if (stType == SeriesType.stLineChart)
        //        StockChartX1.set_SeriesColor(Symbol + ".close", ColorTranslator.ToOle(Props.lineGraph));
        //    else
        //        StockChartX1.set_SeriesColor(Symbol + ".close", ColorTranslator.ToOle(Color.Lime));
        //    StockChartX1.Update();
        //}

        /// <summary>
        /// used for applying colors on charts as they are sets in Property Settings
        /// </summary>
        private void ApplyColors()
        {
            //try
            {
                //Properties.Settings.Default.SLLineColor = props.SLLine = nColorBtnSLLine.Color;
                //Properties.Settings.Default.TPLineColor = props.TPPline = nColorBthTPColor.Color;
                //Properties.Settings.Default.backGround = props.backGround = colBtnBackground.Color;
                //Properties.Settings.Default.foreGround = props.foreGround = colBtnForground.Color;
                //Properties.Settings.Default.grid = props.grid = colBtnGrid.Color;
                //Properties.Settings.Default.barUp = props.barUp = colBtnBarUp.Color;
                //Properties.Settings.Default.barDown = props.barDown = colBtnBarDown.Color;
                //Properties.Settings.Default.bullCandle = props.bullCandle = colBtnBullCandle.Color;
                //Properties.Settings.Default.bearCandle = props.bearCandle = colBtnBearCandle.Color;
                //Properties.Settings.Default.lineGraph = props.lineGraph = colBtnLineGraph.Color;
                //Properties.Settings.Default.volume = props.volume = colBtnVolume.Color;
                //Properties.Settings.Default.askLine = props.askLine = colBtnAskLine.Color;
                //Properties.Settings.Default.stopLevels = props.stopLevels = colBtnStopLevels.Color;
                //Properties.Settings.Default.offlineChart = props.offlinechart = chkOfflineChart.Checked;
                //Properties.Settings.Default.foregroundChart = props.forgroundChart = chkForgroundChart.Checked;
                //Properties.Settings.Default.chartShift = props.chartShift = chkChartShift.Checked;
                //Properties.Settings.Default.chartAutoScroll = props.chartAutoScroll = chkChartAutoScroll.Checked;
                //Properties.Settings.Default.scaleFixOne = props.scaleFixOne = chkScaleFixone.Checked;
                //Properties.Settings.Default.scaleFix = props.scaleFix = chkScalefix.Checked;
                //Properties.Settings.Default.barChart = props.barChart = rdoBarChart.Checked;
                //Properties.Settings.Default.candleStick = props.candleSticks = rdoCandleSticks.Checked;
                //Properties.Settings.Default.lineChart = props.lineChart = rdoLineChart.Checked;
                //Properties.Settings.Default.showOHLC = props.showOHLC = chkShowOHLC.Checked;
                //Properties.Settings.Default.showAskLine = props.showAskLine = chkShowAskLine.Checked;
                //Properties.Settings.Default.periodSeperator = props.periodSeperator = chkPeriodSeperator.Checked;
                //Properties.Settings.Default.showGrid = props.showGrid = chkShowGrid.Checked;
                //Properties.Settings.Default.showVolume = props.showVolume = chkShowVolumes.Checked;
                //Properties.Settings.Default.objDescription = props.objDescription = chkObjDescrption.Checked;
                //Properties.Settings.Default.minScale = props.minYScale = double.Parse(txtFixedMinimum.Text);
                //Properties.Settings.Default.maxScale = props.maxYScale = double.Parse(txtFixedMaximun.Text);
                ////Properties.Settings.Default.TwoDStyle = props.TwoDStyle = chk2D.Checked;
                //Properties.Settings.Default.ThreeDStyle = props.ThreeDStyle = chk3D.Checked;
                //Properties.Settings.Default.Save();

                Props.backGround = colBtnBackground.Color;
                Props.foreGround = colBtnForground.Color;
                Props.grid = colBtnGrid.Color;
                Props.barUp = colBtnBarUp.Color;
                Props.barDown = colBtnBarDown.Color;
                Props.bullCandle = colBtnBullCandle.Color;
                Props.bearCandle = colBtnBearCandle.Color;
                Props.lineGraph = colBtnLineGraph.Color;
                Props.volume = colBtnVolume.Color;
                Props.askLine = colBtnAskLine.Color;
                Props.stopLevels = colBtnStopLevels.Color;
                Props.offlinechart = chkOfflineChart.Checked;
                Props.forgroundChart = chkForgroundChart.Checked;
                Props.chartShift = chkChartShift.Checked;
                Props.chartAutoScroll = chkChartAutoScroll.Checked;
                Props.scaleFixOne = chkScaleFixone.Checked;
                Props.scaleFix = chkScalefix.Checked;
                Props.barChart = rdoBarChart.Checked;
                Props.candleSticks = rdoCandleSticks.Checked;
                Props.lineChart = rdoLineChart.Checked;
                Props.showOHLC = chkShowOHLC.Checked;
                Props.showAskLine = chkShowAskLine.Checked;
                Props.periodSeperator = chkPeriodSeperator.Checked;
                Props.showGrid = chkShowGrid.Checked;
                Props.showVolume = chkShowVolumes.Checked;
                Props.objDescription = chkObjDescrption.Checked;
                Props.minYScale = double.Parse(txtFixedMinimum.Text);
                Props.maxYScale = double.Parse(txtFixedMaximun.Text);
                Props.ThreeDStyle = chk3D.Checked;
            }
            ////catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// used for load chartProperty whatever sets in Property Settings
        /// </summary>
        /// <param name="props">contains charts property</param>
        private void LoadChartProperty(ref ChartProperty props)
        {
            //try
            {
                nColorBtnSLLine.Color = props.SLLine;
                nColorBthTPColor.Color = props.TPPline;
                colBtnBackground.Color = props.backGround;
                colBtnForground.Color = props.foreGround;
                colBtnGrid.Color = props.grid;
                colBtnBarUp.Color = props.barUp;
                colBtnBarDown.Color = props.barDown;
                colBtnBullCandle.Color = props.bullCandle;
                colBtnBearCandle.Color = props.bearCandle;
                colBtnLineGraph.Color = props.lineGraph;
                colBtnVolume.Color = props.volume;
                colBtnAskLine.Color = props.askLine;
                colBtnStopLevels.Color = props.stopLevels;
                //commented on 28-12-09 by vivek upadhyay
                LoadCommonProperty();
                //ApplyCommonProperty();        //Commented by Namo
                chkOfflineChart.Checked = props.offlinechart;
                chkForgroundChart.Checked = props.forgroundChart;
                chkChartShift.Checked = props.chartShift;
                chkChartAutoScroll.Checked = props.chartAutoScroll;
                chkScaleFixone.Checked = props.scaleFixOne;
                chkScalefix.Checked = props.scaleFix;
                rdoBarChart.Checked = props.barChart;
                rdoCandleSticks.Checked = props.candleSticks;
                rdoLineChart.Checked = props.lineChart;
                chkShowOHLC.Checked = props.showOHLC;
                chkShowAskLine.Checked = props.showAskLine;
                chkPeriodSeperator.Checked = props.periodSeperator;
                chkShowGrid.Checked = props.showGrid;
                chkShowVolumes.Checked = props.showVolume;
                chkObjDescrption.Checked = props.objDescription;
            }
            //catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// Used to apply commonm property as they have sets in Property settings        //Commented by Namo
        ///// </summary>
        //private void ApplyCommonProperty()
        //{
        //    if (rdoBarChart.Checked)
        //    {
        //        ChangeChartStyle(SeriesType.stStockBarChart);
        //        rdoBarChart.Checked = Props.barChart;
        //    }
        //    else if (rdoCandleSticks.Checked)
        //    {
        //        ChangeChartStyle(SeriesType.stCandleChart);
        //        rdoCandleSticks.Checked = Props.candleSticks;
        //    }
        //    else if (rdoLineChart.Checked)
        //    {
        //        ChangeChartStyle(SeriesType.stLineChart);
        //        rdoLineChart.Checked = Props.lineChart;
        //    }
        //    if (chkShowVolumes.Checked)
        //    {
        //        //StockChartX1.set_SeriesVisible(symbol + ".Volume", true);
        //    }
        //    if (chkShowGrid.Checked)
        //    {
        //        StockChartX1.XGrid = true;
        //        StockChartX1.YGrid = true;
        //        chkShowGrid.Checked = Props.showGrid;
        //    }
        //}

        /// <summary>
        /// used to load Common property as they have set in Property.Settings
        /// </summary>
        private void LoadCommonProperty()
        {
            chkOfflineChart.Checked = Props.offlinechart;
            chkForgroundChart.Checked = Props.forgroundChart;
            chkChartShift.Checked = Props.chartShift;
            chkChartAutoScroll.Checked = Props.chartAutoScroll;
            chkScaleFixone.Checked = Props.scaleFixOne;
            chkScalefix.Checked = Props.scaleFix;
            rdoBarChart.Checked = Props.barChart;
            rdoCandleSticks.Checked = Props.candleSticks;
            rdoLineChart.Checked = Props.lineChart;
            chkShowOHLC.Checked = Props.showOHLC;
            chkShowAskLine.Checked = Props.showAskLine;
            chkPeriodSeperator.Checked = Props.periodSeperator;
            chkShowGrid.Checked = Props.showGrid;
            chkShowVolumes.Checked = Props.showVolume;
            chkObjDescrption.Checked = Props.objDescription;
            //chk2D.Checked = props.TwoDStyle;
            chk3D.Checked = Props.ThreeDStyle;
            if (Props.minYScale == 0)
                Props.minYScale = minY;

            txtFixedMaximun.Text = Props.minYScale.ToString();

            if (Props.maxYScale == 0)
                Props.maxYScale = maxY;

            txtFixedMinimum.Text = Props.maxYScale.ToString();
        }

        /// <summary>
        /// used to save All Data
        /// </summary>
        private void SaveAllData()
        {
        }

        /// <summary>
        /// Used to set text operations for loclizations
        /// </summary>
        private void SetText()
        {
            //try
            {
                //tabPageColors.Text = frmMainGTS.rm.GetString("Colors");
                //lblColorScheme.Text = frmMainGTS.rm.GetString("Color_Scheme");
                //lblBackground.Text = frmMainGTS.rm.GetString("Background");
                //lblForground.Text = frmMainGTS.rm.GetString("Foreground");
                //lblGrid.Text = frmMainGTS.rm.GetString("Grid");
                //lblBarUp.Text = frmMainGTS.rm.GetString("Bar_Up");
                //lblBarDown.Text = frmMainGTS.rm.GetString("Bar_Down");
                //lblBullCandle.Text = frmMainGTS.rm.GetString("Bull_Candle");
                //lblBearCandle.Text = frmMainGTS.rm.GetString("Bear_Candle");
                //lblLineGrph.Text = frmMainGTS.rm.GetString("Line_Graph");
                //lblAskLine.Text = frmMainGTS.rm.GetString("Ask_Line");
                //lblVolume.Text = frmMainGTS.rm.GetString("volumes");
                //lblStopLevels.Text = frmMainGTS.rm.GetString("Stop_levels");
                //chkOfflineChart.Text = frmMainGTS.rm.GetString("Offline_Chart");
                //chkForgroundChart.Text = frmMainGTS.rm.GetString("Chart_ on_foreground");
                //chkChartShift.Text = frmMainGTS.rm.GetString("Chart_Shift");
                //chkChartAutoScroll.Text = frmMainGTS.rm.GetString("Chart_Autoscroll");
                //chkScaleFixone.Text = frmMainGTS.rm.GetString("Scale_fix_ one_one");
                //chkScalefix.Text = frmMainGTS.rm.GetString("Scale_fix");
                //lblFixedMaximum.Text = frmMainGTS.rm.GetString("Fixed_Maximum");
                //lblFixedMinimum.Text = frmMainGTS.rm.GetString("Fixed_minimum");
                //rdoBarChart.Text = frmMainGTS.rm.GetString("Bar_Chart");
                //rdoCandleSticks.Text = frmMainGTS.rm.GetString("Candlesticks");
                //rdoLineChart.Text = frmMainGTS.rm.GetString("Line_Chart");
                ////tabPageCommon.Text = frmMainGTS.rm.GetString("common");
                //chkShowOHLC.Text = frmMainGTS.rm.GetString("show_OHLC");
                //chkShowAskLine.Text = frmMainGTS.rm.GetString("show_Ask_line");
                //chkPeriodSeperator.Text = frmMainGTS.rm.GetString("show_period_seperators");
                //chkShowGrid.Text     = frmMainGTS.rm.GetString("show_grid");
                //chkShowVolumes.Text  = frmMainGTS.rm.GetString("show_volumes");
                //chkObjDescrption.Text = frmMainGTS.rm.GetString("show_object_descriptions");
                //chk3D.Text = frmMainGTS.rm.GetString("3D_Style");
                //tabPageCommon.Text = frmMainGTS.rm.GetString("Common");
            }
            //catch (Exception ex)
            //{

            //}
        }

        private void frmProperties_Load(object sender, EventArgs e)
        {
            chk3D.Checked = Props.ThreeDStyle;
            SetText();
        }

        private void chkScaleFixone_CheckStateChanged(object sender, EventArgs e)
        {
            chkScalefix.Checked = true;
            if (chkScaleFixone.Checked)
            {
                txtFixedMaximun.Enabled = false;
                txtFixedMinimum.Enabled = false;
                lblFixedMaximum.Enabled = false;
                lblFixedMinimum.Enabled = false;
            }
            else
            {
                txtFixedMaximun.Enabled = true;
                txtFixedMinimum.Enabled = true;
                lblFixedMaximum.Enabled = true;
                lblFixedMinimum.Enabled = true;
            }
        }

        private void chkScaleFixone_CheckedChanged(object sender, EventArgs e)
        {
            //chkScaleFixone.Checked = true;
            //txtFixedMaximun.Enabled = true;
            //txtFixedMinimum.Enabled = true;
            //lblFixedMaximum.Enabled = true;
            //lblFixedMinimum.Enabled = true;

            //chkScaleFixone.Checked = true;


            //chkScalefix.Checked = true;
            //if (chkScaleFixone.Checked == true)
            //{
            //    txtFixedMaximun.Enabled = false;
            //    txtFixedMinimum.Enabled = false;
            //    lblFixedMaximum.Enabled = false;
            //    lblFixedMinimum.Enabled = false;
            //}
            //else
            //{
            //    txtFixedMaximun.Enabled = true;
            //    txtFixedMinimum.Enabled = true;
            //    lblFixedMaximum.Enabled = true;
            //    lblFixedMinimum.Enabled = true;
            //}
        }

        /// <summary>
        /// used for scale fix opeartions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkScalefix_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkScalefix.Checked == false)
            //{
            //    txtFixedMaximun.Enabled = false;
            //    txtFixedMinimum.Enabled = false;
            //    lblFixedMaximum.Enabled = false;
            //    lblFixedMinimum.Enabled = false;
            //    chkScaleFixone.Checked = false;
            //}
            //else
            //{
            //    txtFixedMaximun.Enabled = true;
            //    txtFixedMinimum.Enabled = true;
            //    lblFixedMaximum.Enabled = true;
            //    lblFixedMinimum.Enabled = true;
            //}
        }

        private void chkScalefix_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkScalefix.Checked == false)
            {
                txtFixedMaximun.Enabled = false;
                txtFixedMinimum.Enabled = false;
                lblFixedMaximum.Enabled = false;
                lblFixedMinimum.Enabled = false;
            }
            else
            {
                txtFixedMaximun.Enabled = true;
                txtFixedMinimum.Enabled = true;
                lblFixedMaximum.Enabled = true;
                lblFixedMinimum.Enabled = true;
            }
        }

        /// <summary>
        /// used for background color changed in chart        //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnBackground_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.ChartBackColor = colBtnBackground.Color;
        //}

        /// <summary>
        /// used for forground color change         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void colBtnForground_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.ChartForeColor = colBtnForground.Color;
        //}

        /// <summary>
        /// used for BtnGrd ColorChanged        //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnGrid_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.Gridcolor = colBtnGrid.Color;
        //}

        /// <summary>
        /// used for BtnBarUpColorChanged         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnBarUp_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.UpColor = colBtnBarUp.Color;
        //}

        /// <summary>
        /// Used for BtnBarDownColorChanged        //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnBarDown_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.DownColor = colBtnBarDown.Color;
        //}

        /// <summary>
        /// Used for BtnBullCandle Chanegd         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnBullCandle_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.CandleUpOutlineColor = colBtnBullCandle.Color;
        //}

        /// <summary>
        /// used for BtnBearCandle changed         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnBearCandle_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.CandleDownOutlineColor = colBtnBearCandle.Color;
        //}

        /// <summary>
        /// used for BtnLineGraphColorChanged         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnLineGraph_ColorChanged(object sender, EventArgs e)
        //{
        //    StockChartX1.LineGraphColor = colBtnLineGraph.Color;
        //}

        /// <summary>
        /// used for BtnVolumeColorChanged         //Commented by Namo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void colBtnVolume_ColorChanged(object sender, EventArgs e)
        //{
        //    int panel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");
        //    if (panel != -1)
        //    {
        //        StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(colBtnVolume.Color));
        //    }
        //}

        /// <summary>
        ///  used for ChartShiftColor Chaneged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkChartShift_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void nCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void colorsGrpBox4_Enter(object sender, EventArgs e)
        {
        }
    }
}