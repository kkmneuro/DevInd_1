using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
//using StockChart;
using stockXUserctrl;

namespace PALSA.Frm
{
    public partial class frmPropertyChartWPF : Form
    {
        //public System.Windows.Forms.Integration.ElementHost elementHost1;
        //chartingCtrl ctrol = null;
        private DataTable DTDAta;
        private Cls.ChartProperty cht;
        private double minY;
        private double maxY;
        private readonly string Symbol;
        public ChartProperty Props = new ChartProperty();
        private int slectedStyleIndex = 3;
        public frmPropertyChartWPF()
        {
            InitializeComponent();
            //ctrol = (chartingCtrl)this.elementHost1.Child;
        }

        public frmPropertyChartWPF(string m_symbol, DataTable DTDAta, Cls.ChartProperty cht, double minY, double maxY)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.Symbol = m_symbol;
            this.DTDAta = DTDAta;
            this.cht = cht;
            this.minY = minY;
            this.maxY = maxY;
            Props = cht;
            cboColorScheme.SelectedIndex = cht.slectedStyleIndex;
            chkStyle.Checked = cht.IsStyle;
            chkStyle_CheckedChanged(null, null);
            //SetLoadChartColor();
            ////ApplyCommonProperty();
            LoadChartProperty(ref Props);

            //ctrol = (chartingCtrl)this.elementHost1.Child;
            //CreateCtrls();
            //ctrol.SYMBOL_ = m_symbol;
            //LoadOHLC(m_symbol, DTDAta);
            //SetLoadChartColor();
            //LoadChartProperty(ref Props);
        }

        private void LoadOHLC(string sym, DataTable dt)
        {
            Action a = () =>
            {
                //if (ctrol.DTDAta == null)
                //{
                //    ctrol.DTDAta = new DataTable();
                //}
                //ctrol.DTDAta.Clear();
                //ctrol.DTDAta = DTDAta;
                //ctrol.LoadChart("", new DataTable());
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

        private void CreateCtrls()
        {
            try
            {
                //elementHost1 = new System.Windows.Forms.Integration.ElementHost();
                //elementHost1.Dock = DockStyle.Fill;
                //this.nuiPanel1.Controls.Add(elementHost1);
                //ctrol = new stockXUserctrl.chartingCtrl();
                //elementHost1.Child = ctrol;
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadChartProperty(ref ChartProperty props)
        {

            //nColorBtnSLLine.Color = props.SLLine;
            //nColorBthTPColor.Color = props.TPPline;
            colBtnBackground.Color = props.backGround;
            colBtnForground.Color = props.foreGround;
            colBtnGrid.Color = props.grid;
            colBtnBarUp.Color = props.barUp;
            colBtnBarDown.Color = props.barDown;
            nbtnCross.Color = props.Crosshair;
            nbtnDownOutLine.Color = props.DownOutLine;
            nbtnUpOutLine.Color = props.UpOutLine;
            //colBtnBullCandle.Color = props.bullCandle;
            //colBtnBearCandle.Color = props.bearCandle;
            //colBtnLineGraph.Color = props.lineGraph;
            //colBtnVolume.Color = props.volume;
            //colBtnAskLine.Color = props.askLine;
            //colBtnStopLevels.Color = props.stopLevels;
            //commented on 28-12-09 by vivek upadhyay
            //LoadCommonProperty();
            //ApplyCommonProperty();
            //chkOfflineChart.Checked = props.offlinechart;
            //chkForgroundChart.Checked = props.forgroundChart;
            //chkChartShift.Checked = props.chartShift;
            //chkChartAutoScroll.Checked = props.chartAutoScroll;
            //chkScaleFixone.Checked = props.scaleFixOne;
            //chkScalefix.Checked = props.scaleFix;
            //rdoBarChart.Checked = props.barChart;
            //rdoCandleSticks.Checked = props.candleSticks;
            //rdoLineChart.Checked = props.lineChart;
            //chkShowOHLC.Checked = props.showOHLC;
            //chkShowAskLine.Checked = props.showAskLine;
            //chkPeriodSeperator.Checked = props.periodSeperator;
            //chkShowGrid.Checked = props.showGrid;
            //chkShowVolumes.Checked = props.showVolume;
            //chkObjDescrption.Checked = props.objDescription;
        }

        /// <summary>
        /// Used to apply commonm property as they have sets in Property settings
        /// </summary>

        /// <summary>
        /// used to load Common property as they have set in Property.Settings
        /// </summary>

        private void btnOK_Click(object sender, EventArgs e)
        {
            //cboColorScheme_SelectedIndexChanged(null, null);
            ApplyColors();
            //LoadChartProperty(ref Props);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplyColors()
        {
            Props.backGround = colBtnBackground.Color;
            Props.foreGround = colBtnForground.Color;
            Props.grid = colBtnGrid.Color;
            Props.barUp = colBtnBarUp.Color;
            Props.barDown = colBtnBarDown.Color;
            Props.UpOutLine = nbtnUpOutLine.Color;
            Props.DownOutLine = nbtnDownOutLine.Color;
            Props.Crosshair = nbtnCross.Color;
            //Props.bullCandle = colBtnBullCandle.Color;
            //Props.bearCandle = colBtnBearCandle.Color;
            //Props.lineGraph = colBtnLineGraph.Color;
            //Props.volume = colBtnVolume.Color;
            //Props.askLine = colBtnAskLine.Color;
            //Props.stopLevels = colBtnStopLevels.Color;
            //Props.offlinechart = chkOfflineChart.Checked;
            //Props.forgroundChart = chkForgroundChart.Checked;
            //Props.chartShift = chkChartShift.Checked;
            //Props.chartAutoScroll = chkChartAutoScroll.Checked;
            //Props.scaleFixOne = chkScaleFixone.Checked;
            //Props.scaleFix = chkScalefix.Checked;
            //Props.barChart = rdoBarChart.Checked;
            //Props.candleSticks = rdoCandleSticks.Checked;
            //Props.lineChart = rdoLineChart.Checked;
            //Props.showOHLC = chkShowOHLC.Checked;
            //Props.showAskLine = chkShowAskLine.Checked;
            //Props.periodSeperator = chkPeriodSeperator.Checked;
            //Props.showGrid = chkShowGrid.Checked;
            //Props.showVolume = chkShowVolumes.Checked;
            //Props.objDescription = chkObjDescrption.Checked;
            //Props.minYScale = double.Parse(txtFixedMinimum.Text);
            //Props.maxYScale = double.Parse(txtFixedMaximun.Text);
            //Props.ThreeDStyle = chk3D.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //colBtnBackground.Color = StockChartX1.ChartBackColor = Color.Black;
            //colBtnForground.Color = StockChartX1.ChartForeColor = Color.FromArgb(114, 114, 114); //.White;
            //colBtnGrid.Color = StockChartX1.Gridcolor = Color.FromArgb(30, 32, 41); //LightSlateGray;
            //colBtnBarUp.Color = StockChartX1.UpColor = Color.Lime;
            //colBtnBarDown.Color = StockChartX1.DownColor = Color.Red;
            //colBtnBullCandle.Color = StockChartX1.CandleUpOutlineColor = Color.Lime;
            //colBtnBearCandle.Color = StockChartX1.CandleDownOutlineColor = Color.Red;
            //colBtnLineGraph.Color = StockChartX1.LineColor = Color.Lime;

            //int panel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");

            //if (panel != -1)
            //{
            //    colBtnVolume.Color = Color.LimeGreen;
            //    StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(Color.LimeGreen));
            //}

            //StockChartX1.Update();
            //chkOfflineChart.Checked = Props.offlinechart = false;
            //chkForgroundChart.Checked = Props.forgroundChart = false;
            //chkChartShift.Checked = Props.chartShift = false;
            //chkChartAutoScroll.Checked = Props.chartAutoScroll = true;
            //chkScaleFixone.Checked = Props.scaleFixOne = false;
            //chkScalefix.Checked = Props.scaleFix = false;
            //rdoBarChart.Checked = Props.barChart = false;
            //rdoCandleSticks.Checked = Props.candleSticks = true;
            //rdoLineChart.Checked = Props.lineChart = false;
            //chkShowOHLC.Checked = Props.showOHLC = false;
            //chkShowAskLine.Checked = Props.showAskLine = false;
            //chkPeriodSeperator.Checked = Props.periodSeperator = false;
            //chkShowGrid.Checked = Props.showGrid = true;
            //chkShowVolumes.Checked = Props.showVolume = true;
            //chkObjDescrption.Checked = Props.objDescription = false;
            //chk3D.Checked = Props.ThreeDStyle = false;
        }

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
            else if (cboColorScheme.SelectedIndex == 3)
            {
                colBtnBackground.Color = Color.White;
                colBtnForground.Color = Color.White;
                colBtnGrid.Color = Color.White;
                colBtnBarUp.Color = Color.White;
                colBtnBarDown.Color = Color.White;
            }
            Props.slectedStyleIndex = cboColorScheme.SelectedIndex;
            PreviewChart();
        }

        private void PreviewChart()
        {
            ////try
            //{
            //    StockChartX1.ChartBackColor = colBtnBackground.Color;
            //    StockChartX1.ChartForeColor = colBtnForground.Color;
            //    StockChartX1.Gridcolor = colBtnGrid.Color;
            //    StockChartX1.UpColor = colBtnBarUp.Color;
            //    StockChartX1.DownColor = colBtnBarDown.Color;
            //    StockChartX1.CandleUpOutlineColor = colBtnBullCandle.Color;
            //    StockChartX1.CandleDownOutlineColor = colBtnBearCandle.Color;
            //    StockChartX1.LineGraphColor = colBtnLineGraph.Color;
            //    // StockChartX1.AskLineColor = colBtnAskLine.Color;
            //    // StockChartX1.StopLevelsColor = colBtnStopLevels.Color;

            //    int panel = StockChartX1.GetPanelBySeriesName(StockChartX1.Symbol + ".volume");

            //    if (panel != -1)
            //    {
            //        StockChartX1.set_SeriesColor(Symbol + ".volume", ColorTranslator.ToOle(colBtnVolume.Color));
            //    }


            //    StockChartX1.Update();
            //}
            ////catch (Exception ex)
            //{
            //}
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
                //colBtnBullCandle.Color = Color.Black;
                //colBtnBearCandle.Color = Color.White;
                //colBtnLineGraph.Color = Color.Yellow;
                //colBtnVolume.Color = Color.LimeGreen;
                //colBtnAskLine.Color = Color.Red;
                //colBtnStopLevels.Color = Color.Red;
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
                //colBtnBullCandle.Color = Color.Black;
                //colBtnBearCandle.Color = Color.White;
                //colBtnLineGraph.Color = Color.Lime;
                //colBtnVolume.Color = Color.LimeGreen;
                //colBtnAskLine.Color = Color.Red;
                //colBtnStopLevels.Color = Color.Red;
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
                //colBtnBullCandle.Color = Color.White;
                //colBtnBearCandle.Color = Color.Black;
                //colBtnLineGraph.Color = Color.Black;
                //colBtnVolume.Color = Color.Green;
                //colBtnAskLine.Color = Color.OrangeRed;
                //colBtnStopLevels.Color = Color.OrangeRed;
            }
            //catch (Exception ex)
            //{

            //}
        }

        private void chkStyle_CheckedChanged(object sender, EventArgs e)
        {
            cboColorScheme.Enabled = chkStyle.Checked;
            Props.IsStyle = chkStyle.Checked;
        }
    }
}
