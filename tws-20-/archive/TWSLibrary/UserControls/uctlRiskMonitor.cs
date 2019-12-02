using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlRiskMonitor : UctlBase
    {
        public event Action<object, MouseEventArgs> OnGridMouseDown;
                
        private Color _downTrendColor = Color.Red;
        private Color _upTrendColor = Color.Blue;
        /// <summary>
        /// This property set specified the colour of the cells when there is Up Trend. This property is both gettable and settable.
        /// </summary>
        [AddCustomizeAttrs]
        public Color UpTrendColor
        {
            get { return _upTrendColor; }
            set { _upTrendColor = value; }
        }

        /// <summary>
        /// This property set specified the colour of the cells when there is Down Trend. This property is both gettable and settable.
        /// </summary>
        [AddCustomizeAttrs]
        public Color DownTrendColor
        {
            get { return _downTrendColor; }
            set { _downTrendColor = value; }
        }

        public string TotalBuyQty
        {
            get { return ui_nsbBuyQtyValue.Text; }
            set { ui_nsbBuyQtyValue.Text = value; }
        }

        public string TotalSellQty
        {
            get { return ui_nsbSellQtyValue.Text; }
            set { ui_nsbSellQtyValue.Text = value; }
        }
        public string TotalMargin
        {
            get { return ui_nsbTotalFreeMarginValue.Text; }
            set { ui_nsbTotalFreeMarginValue.Text = value; }
        }
        public string TotalUsedMargin
        {
            get { return ui_nsbTotalUsedMarginValue.Text; }
            set { ui_nsbTotalUsedMarginValue.Text = value; }
        }
        public string Equity
        {
            get { return ui_nsbTotalEquityValue.Text; }
            set { ui_nsbTotalEquityValue.Text = value; }
        }

        public string TotalPnL
        {
            get { return ui_nsbUPLValue.Text; }
            set { ui_nsbUPLValue.Text = value; }
        }

        public uctlRiskMonitor()
        {
            InitializeComponent();
            AddColumnsToGrid();
            ui_uctlGridRiskMonitor.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ui_uctlGridRiskMonitor_MouseDown(object sender, MouseEventArgs e)
        {
            //OnGridMouseDown(sender, e);
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[10];
            var IntCellStyle = new DataGridViewCellStyle();
            IntCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmAccount", "Account No");
            columnsArray[0].DataPropertyName = "AccountNo";
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmTraderName", "Trader Name");
            columnsArray[1].DataPropertyName = "TraderName";
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmBalance", "Balance");
            columnsArray[2].DataPropertyName = "Balance";
            columnsArray[2].DefaultCellStyle = IntCellStyle;
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmUsedMargin", "Used Margin");
            columnsArray[3].DataPropertyName = "UsedMargin";
            columnsArray[3].DefaultCellStyle = IntCellStyle;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmFreeMargin", "Free Margin");
            columnsArray[4].DataPropertyName = "FreeMargin";
            columnsArray[4].DefaultCellStyle = IntCellStyle;
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmMarginLevel", "Margin Level");
            columnsArray[5].DataPropertyName = "MarginLevel";
            columnsArray[5].DefaultCellStyle = IntCellStyle;
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmEquity", "Equity");
            columnsArray[6].DataPropertyName = "Equity";
            columnsArray[6].DefaultCellStyle = IntCellStyle;
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmProfitLoss", "Profit/Loss",false);
            columnsArray[7].DataPropertyName = "ProfitLoss";
            columnsArray[7].DefaultCellStyle = IntCellStyle;
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmURPL", "U/PnL");
            columnsArray[8].DataPropertyName = "UR_PL";
            columnsArray[8].DefaultCellStyle = IntCellStyle;
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmImage", "Trend", new DataGridViewImageColumn());
            columnsArray[9].Width = 60;
            columnsArray[9].DefaultCellStyle.NullValue = null;
            columnsArray[9].Visible = false;

            ui_uctlGridRiskMonitor.AddColumns(columnsArray);
        }

        private void uctlRiskMonitor_Load(object sender, EventArgs e)
        {
            Label.CheckForIllegalCrossThreadCalls = false;
        }

        private void ui_uctlGridRiskMonitor_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }
    }
}
