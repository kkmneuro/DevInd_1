///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//03/01/2012	NN		
//02/02/2012	VP		    1.Commenting of the code
//03/02/2012	VP          1.Added columnProfile menu in gridmenu and defined there functionality
//07/02/2012	VP          1.Added columns to the grid of the  control
//20/02/2012	VP          1.Add more fields and disabled some fields according to document
//05/03/2012    VP          1.Code for column profile 
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlTradeWindow : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        public Dictionary<long, DataGridViewRow> _DDRows = new Dictionary<long, DataGridViewRow>();
        private Keys _shortcutKey = Keys.None;
        private string _title = "Trade Window";

        public object Profile { get; set; }

        public Keys ShortcutKeyFilter
        {
            get { return _shortcutKey; }
            set { _shortcutKey = value; }
        }

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// Sets and gets the title of the Trade Window control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string CurrentProfileName { get; set; }

        public string BuyQty
        {
            get { return ui_nsbBuyQtyValue.Text; }
            set { ui_nsbBuyQtyValue.Text = value; }
        }
        public string BuyVal
        {
            get { return ui_nsbBuyValValue.Text; }
            set { ui_nsbBuyValValue.Text = value; }
        }
        public string BuyAtp
        {
            get { return ui_nsbBuyAtpValue.Text; }
            set { ui_nsbBuyAtpValue.Text = value; }
        }
        public string SellQty
        {
            get { return ui_nsbSellQtyValue.Text; }
            set { ui_nsbSellQtyValue.Text = value; }
        }
        public string SellVal
        {
            get { return ui_nsbSellValValue.Text; }
            set { ui_nsbSellValValue.Text = value; }
        }
        public string SellAtp
        {
            get { return ui_nsbSellAtpValue.Text; }
            set { ui_nsbSellAtpValue.Text = value; }
        }
        public string NoOfTotalOrder
        {
            get { return ui_nsbTotalTradesValue.Text; }
            set { ui_nsbTotalTradesValue.Text = value; }
        }
      
        /// <summary>
        /// This property sets the colour of the current row of the grid. This property is both settable and gettable
        /// </summary>
        public Color DataRowStyle { get; set; }

        /// <summary>
        ///  Apply condition in filter and accordingly, the conditional output is displayed when required.
        /// </summary>
        public UctlFilter OrderFilter { get; set; }

        #endregion "        PROPERTY          "

        #region "       CONSTRUCTOR        "

        /// <summary>
        /// Constructor for initilizing the components of the uctlTradeWindow 
        /// </summary>
        public uctlTradeWindow()
        {
            InitializeComponent();
        }

        #endregion "         CONSTRUCTOR          "

        #region    "         EVENTS          "

        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };

        #endregion "          EVENTS         "

        #region    "         METHODS         "

        /// <summary>
        /// This method adds menu items to the context menu of uctlTradeWindow control
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[4];

            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Click += OnViewClick;
            ViewSubMenu(ContextMenuItems[0]);
            ContextMenuItems[0].Visible = false;
            ContextMenuItems[1] = new ToolStripMenuItem("Filter");
            ContextMenuItems[1].Name = "Filter";
            ContextMenuItems[1].ShortcutKeys = ShortcutKeyFilter;
            ContextMenuItems[1].Visible = false;
            //ContextMenuItems[1].Click += OnFilterClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Save As");
            ContextMenuItems[2].Name = "SaveAs";
            ContextMenuItems[2].Click += OnSaveAsClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[3].Click += OnColumnProfileClick;

            ui_uctlGridTradeWindow.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        ///  This method adds sub menu items to the View item of context menu
        /// </summary>
        /// <param name="ViewItem">ToolStripMenuItem to which sub menu is to be added</param>
        public void ViewSubMenu(ToolStripMenuItem ViewItem)
        {
            var ViewSubItems = new ToolStripMenuItem[4];

            ViewSubItems[0] = new ToolStripMenuItem("All");
            ViewSubItems[0].Click += OnAllClick;
            ViewSubItems[1] = new ToolStripMenuItem("Pending");
            ViewSubItems[1].Click += OnPendingClick;
            ViewSubItems[2] = new ToolStripMenuItem("Approved");
            ViewSubItems[2].Click += OnApprovedClick;
            ViewSubItems[3] = new ToolStripMenuItem("Rejected");
            ViewSubItems[3].Click += OnRejectClick;

            ViewItem.DropDownItems.AddRange(ViewSubItems);
        }

        /// <summary>
        /// This method adds functionality to the Column Profile item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.Trade, Profile, CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileRemoveClick +=
                objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick +=
                objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridTradeWindow);
            objfrmColumnProfile.ShowDialog();
        }

        private void objfrmColumnProfile_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            OnSetDefaultProfileClick(objProfiles, profileName);
        }

        private void objfrmColumnProfile_OnProfileRemoveClick(object objProfile, string profileName)
        {
            OnProfileRemoveClick(objProfile, profileName);
        }

        private void objfrmColumnProfile_OnProfileSaveClick(object objProfile, string profileName)
        {
            OnProfileSaveClick(objProfile, profileName);
        }

        /// <summary>
        /// Applys the users column settings to the grid
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="currentProfile"></param>
        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            CurrentProfileName = currentProfile;
            Profile = profiles;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>) Profile)[currentProfile + "_" + ProfileTypes.Trade.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        /// <summary>
        /// This method adds functionality to the View item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the filter item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFilterClick(object sender, EventArgs e)
        {
            var objFilter = new UctlFilter();
            objFilter.OnCancelClick += objFilter_OnCancelClick;
            objFilter.OnApplyClick += objFilter_OnApplyClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objFilter.Width + 8, objFilter.Height + 28);
            _objfrmDialogForm.Size = objSize;
            _objfrmDialogForm.Controls.Add(objFilter);
            objFilter.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objFilter.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.ShowDialog();
        }

        /// <summary>
        /// Applys filtering conditions
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        private void objFilter_OnApplyClick(object arg1, EventArgs arg2, object arg3)
        {
        }

        /// <summary>
        /// closes the filter dialog
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void objFilter_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }

        /// <summary>
        /// This method adds functionality to the Save As item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveAsClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog();

            objSaveFileDialog.DefaultExt = ".xls";
            objSaveFileDialog.Filter = "(*.xls)|*.xls";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();

            if (objDialogResult == DialogResult.OK)
            {
                string filePath = objSaveFileDialog.FileName;
                ClsCommonMethods.SaveGridDataInExcel(filePath, ui_uctlGridTradeWindow);
            }
        }

        /// <summary>
        /// This method adds functionality to the "All" item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAllClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Pending item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPendingClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Approved item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApprovedClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Reject item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRejectClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds context menu to uctlTradeWindow control at Loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridTradeWindow_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
        }

        /// <summary>
        /// This method implements the localization to the control
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Trade + " " + ClsLocalizationHandler.Window;
            //   ui_TradeWindowGrid.Columns[0].HeaderText = Cls.clsLocalizationHandler.Instrument;
            //   ui_TradeWindowGrid.Columns[1].HeaderText = Cls.clsLocalizationHandler.Symbol;
            //   ui_TradeWindowGrid.Columns[2].HeaderText = Cls.clsLocalizationHandler.Series + "/" + Cls.clsLocalizationHandler.Expiry;
            //   ui_TradeWindowGrid.Columns[3].HeaderText = Cls.clsLocalizationHandler.Order + " " + Cls.clsLocalizationHandler.Type;
        }

        #endregion    "        METHODS           "

        /// <summary>
        /// Tasks performed on the control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTradeWindow_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            SetLocalization();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[37];

            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //AccountID
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "Account", "Account");
            columnsArray[0].DefaultCellStyle = intCellStyle;
            columnsArray[0].DataPropertyName = "Account";
            columnsArray[0].MinimumWidth = 60;
            columnsArray[0].Width = 60;
            //ExecutionID
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "TradeNo", "Trade No.");
            columnsArray[1].DefaultCellStyle = intCellStyle;
            columnsArray[1].DataPropertyName = "TradeNo";
            columnsArray[1].MinimumWidth = 60;
            columnsArray[1].Width = 60;
            //OrderID
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "OrderNo", "Order No.");
            columnsArray[2].DefaultCellStyle = intCellStyle;
            columnsArray[2].DataPropertyName = "OrderNo";
            columnsArray[2].MinimumWidth = 60;
            columnsArray[2].Width = 60;
            //ProductType
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "ProductType", "Product Type");
            columnsArray[3].DataPropertyName = "ProductType";
            columnsArray[3].MinimumWidth = 60;
            columnsArray[3].Width = 60;
            //Product
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "ProductName", "Product Name");
            columnsArray[4].DataPropertyName = "ProductName";
            columnsArray[4].Width = 70;
            //ContractName
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "Contract", "Contract");
            columnsArray[5].DataPropertyName = "Contract";
            columnsArray[5].Width = 70;
            //Side
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "BS", "B/S");
            columnsArray[6].DataPropertyName = "BS";
            columnsArray[6].Width = 50;
            //QTY
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "Quantity", "Quantity");
            columnsArray[7].DefaultCellStyle = intCellStyle;
            columnsArray[7].DataPropertyName = "Quantity";
            columnsArray[7].Width = 60;
            //Price
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "Price", "Price");
            columnsArray[8].DefaultCellStyle = intCellStyle;
            columnsArray[8].DataPropertyName = "Price";
            columnsArray[8].Width = 60;
            //TriggerPrice
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "TriggerPrice", "Trigger Price");
            columnsArray[9].DefaultCellStyle = intCellStyle;
            columnsArray[9].DataPropertyName = "TriggerPrice";
            columnsArray[9].Width = 60;
            //NA 
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "AvgPrice", "Average Price");
            columnsArray[10].DefaultCellStyle = intCellStyle;
            columnsArray[10].DataPropertyName = "AvgPrice";
            columnsArray[10].Width = 60;
            //NA
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "FillPrice", "Fill Price");
            columnsArray[11].DefaultCellStyle = intCellStyle;
            columnsArray[11].DataPropertyName = "FillPrice";
            columnsArray[11].Width = 70;
            //Commission
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "Commission", "Commission");
            columnsArray[12].DefaultCellStyle = intCellStyle;
            columnsArray[12].DataPropertyName = "Commission";
            columnsArray[12].Width = 70;
            //Tax
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "Tax", "Tax");
            columnsArray[13].DefaultCellStyle = intCellStyle;
            columnsArray[13].DataPropertyName = "Tax";
            columnsArray[13].Width = 70;
            //OrderType
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "OrderType", "Order Type");
            columnsArray[14].DataPropertyName = "OrderType";
            columnsArray[14].Width = 60;
            //OrderStatus
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "Status", "Status");
            columnsArray[15].DataPropertyName = "Status";
            columnsArray[15].Width = 60;
            //TransacTime
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "TradeTime", "Trade Time");
            columnsArray[16].DataPropertyName = "TradeTime";
            columnsArray[16].DisplayIndex = 0;
            //LastUpdatedTime
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "LastUpdatedTime",
                                                                "Last Updated Time", false);
            columnsArray[17].DataPropertyName = "LastUpdatedTime";
            //ExpiryDate
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "LeaveQty", "Leave Qty");
            columnsArray[18].DataPropertyName = "LeaveQty";
            columnsArray[18].Width = 60;
            //TradingCurrency
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "TradingCurrency", "Trading Currency",
                                                                 false);
            //NA
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "QtyTotal", "Total Quantity", false);
            //NA
            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "SpreadSymbol", "Spread Symbol",
                                                                 false);
            //NA
            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "AccountType", "Account Type", false);
            //NA
            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "ClientName", "Client Name", false);
            //NA
            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "Client", "Client", false);
            //To Be Removed
            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "PartOmniId", "Part Id/Omni Id",
                                                                 false);
            //NA
            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "Split", "Split", false);
            //NA
            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "SplitNo", "Split No.", false);
            //Text
            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "Remarks", "Remarks", false);
            //To Be Removed
            columnsArray[29] = ClsCommonMethods.CreateGridColumn(columnsArray[29], "EnteredBy", "Entered By", false);
            //To be Removed
            columnsArray[30] = ClsCommonMethods.CreateGridColumn(columnsArray[30], "InstRemark", "Inst Remark", false);
            //orderId
            columnsArray[31] = ClsCommonMethods.CreateGridColumn(columnsArray[31], "ReferenceNo", "Reference No.", false);
            columnsArray[31].DefaultCellStyle = intCellStyle;
            columnsArray[32] = ClsCommonMethods.CreateGridColumn(columnsArray[32], "CounterClOrdId", "CounterClOrdId", false);
            columnsArray[32].DataPropertyName = "CounterClOrdId";
            columnsArray[33] = ClsCommonMethods.CreateGridColumn(columnsArray[33], "CounterAvgPx", "CounterAvgPx", false);
            columnsArray[33].DefaultCellStyle = intCellStyle;
            columnsArray[33].DataPropertyName = "CounterAvgPx";
            columnsArray[34] = ClsCommonMethods.CreateGridColumn(columnsArray[34], "GrossPL", "Gross Profit Loss", false);
            columnsArray[34].DefaultCellStyle = intCellStyle;
            columnsArray[34].DataPropertyName = "GrossPL";
            columnsArray[35] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "SettledQty", "Settled Qty");
            columnsArray[35].DefaultCellStyle = intCellStyle;
            columnsArray[35].DataPropertyName = "SettledQty";
            columnsArray[35].MinimumWidth = 60;
            columnsArray[35].Width = 60;
            columnsArray[36] = ClsCommonMethods.CreateGridColumn(columnsArray[36], "PnL", "Profit & Loss");
            columnsArray[36].DefaultCellStyle = intCellStyle;
            columnsArray[36].DataPropertyName = "PnL";
            columnsArray[36].MinimumWidth = 60;
            columnsArray[36].Width = 60;
            ui_uctlGridTradeWindow.AddColumns(columnsArray);
        }

        private void ui_uctlGridTradeWindow_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

    }
}