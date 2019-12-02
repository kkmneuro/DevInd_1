using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;
using CommonLibrary.UserControls;

namespace PALSA.uctl
{
    public partial class uctlDealingDesk : UserControl
    {
        public uctlDealingDesk()
        {
            InitializeComponent();

            AddColumnsToGrid();
        }

        public void AddColumnsToGrid()
        {
            ui_uctlGridTop.ui_ndgvGrid.Columns.Clear();
            ui_uctlGridMiddle.ui_ndgvGrid.Columns.Clear();
            ui_uctlGridBottom.ui_ndgvGrid.Columns.Clear();
            AddColumns(ui_uctlGridTop.ui_ndgvGrid);
            AddColumns(ui_uctlGridMiddle.ui_ndgvGrid);
            AddColumns(ui_uctlGridBottom.ui_ndgvGrid);
            ui_uctlGridTop.ui_ndgvGrid.Columns.Remove("ClmLogin");
            ui_uctlGridTop.ui_ndgvGrid.DefaultCellStyle.BackColor = Color.White;
            ui_uctlGridMiddle.ui_ndgvGrid.DefaultCellStyle.BackColor = Color.White;
            ui_uctlGridBottom.ui_ndgvGrid.DefaultCellStyle.BackColor = Color.White;
            ui_uctlGridTop.AllowUserToAddRows = false;
            ui_uctlGridMiddle.AllowUserToAddRows = false;
            ui_uctlGridBottom.AllowUserToAddRows = false;
            ui_uctlGridTop.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ui_uctlGridMiddle.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ui_uctlGridBottom.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }

        public void AddColumns(DataGridView grid)
        {
            var columnsArray = new DataGridViewColumn[13];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "ClmDeal", "Deal");
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "ClmLogin", "Login");
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "ClmTime", "Time");
            //columnsArrayLeft[1].DefaultCellStyle = intCellStyle;
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "ClmType", "Type");
            //columnsArrayLeft[2].DefaultCellStyle = intCellStyle;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "ClmSymbol", "Symbol");
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "ClmVolume", "Volume");
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "ClmPrice1", "Price");
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "ClmSL", "S/L");
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "ClmTP", "T/P");
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "ClmPrice2", "Price");
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "ClmCommission", "Commission");
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "ClmSwap", "Swap");
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "ClmProfit", "Profit");

            grid.Columns.AddRange(columnsArray);
        }

        private void uctlDealingDesk_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem csm = new ToolStripMenuItem("Column Profile");
            csm.Click += OnColumnProfileClick;
            ui_uctlGridTop.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridTop.ContextMenuStrip.Items.Add(csm);

            ToolStripMenuItem csm1 = new ToolStripMenuItem("Column Profile");
            csm.Click += OnColumnProfileClick;
            ui_uctlGridMiddle.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridMiddle.ContextMenuStrip.Items.Add(csm1);

             ToolStripMenuItem csm2 = new ToolStripMenuItem("Column Profile");
            csm.Click += OnColumnProfileClick;
            ui_uctlGridBottom.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridBottom.ContextMenuStrip.Items.Add(csm2);
        }

        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            //Dictionary<string
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.MarketWatch, null,
                                                           string.Empty);
            objfrmColumnProfile.AddItemsToList(ui_uctlGridTop);
            objfrmColumnProfile.StartPosition = FormStartPosition.CenterParent;
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.ShowInTaskbar = false;
            objfrmColumnProfile.BringToFront();
            objfrmColumnProfile.ShowDialog();
        }

        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            //Profiles = profiles;
            //CurrentPortfolioName = currentProfile;
            //ClsProfile profile =
            //    ((Dictionary<string, ClsProfile>)Profiles)[currentProfile + "_" + ProfileTypes.MarketWatch.ToString()];
            //foreach (DataGridViewColumn col in ui_uctlGridMarketWatch.Columns)
            //{
            //    ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
            //    col.DisplayIndex = colsetting.Index;
            //    col.Visible = colsetting.Visible;
            //}
        }

        private void ui_nbtnReturn_Click(object sender, EventArgs e)
        {

        }

        private void ui_nbtnSendConfirm_Click(object sender, EventArgs e)
        {

        }

        private void ui_nbtnReject_Click(object sender, EventArgs e)
        {

        }

        private void ui_nbtnLeft_Click(object sender, EventArgs e)
        {

        }

        private void ui_nbtnRight_Click(object sender, EventArgs e)
        {

        }
    }
}
