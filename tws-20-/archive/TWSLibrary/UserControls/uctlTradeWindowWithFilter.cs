using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;


namespace CommonLibrary.UserControls
{
    public partial class uctlTradeWindowWithFilter : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        public Dictionary<long, DataGridViewRow> _DDRows = new Dictionary<long, DataGridViewRow>();
        private Keys _shortcutKey = Keys.None;
        private string _title = "Trade History Window";
        private bool _isAccountNoChanged = true;
        public event Action SelectionCriteriaChanged = delegate { };
        public event Action<int, string, string, string, string, DateTime, DateTime> OnSearchClick = delegate { };
        public object Profile { get; set; }
        private DateTime FromDate = DateTime.MinValue;
        private DateTime ToDate = DateTime.MinValue;

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

        public string Contract
        {
            get { return ui_ncmbContract.SelectedItem != null ? ui_ncmbContract.SelectedItem.ToString() : "All"; }
            set { ui_ncmbContract.SelectedIndex = ui_ncmbContract.Items.IndexOf(value); }
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


        public string ProductType
        {
            get { return ui_ncmbProductType.SelectedItem != null ? ui_ncmbProductType.SelectedItem.ToString() : "All"; }
            set { ui_ncmbProductType.SelectedIndex = ui_ncmbProductType.Items.IndexOf(value); }
        }

        public string OrderType
        {
            get { return ui_ncmbOrderType.SelectedItem != null ? ui_ncmbOrderType.SelectedItem.ToString() : "All"; }
            set { ui_ncmbOrderType.SelectedIndex = ui_ncmbOrderType.Items.IndexOf(value); }
        }

        public string BS
        {
            get { return ui_ncmbBS.SelectedItem != null ? ui_ncmbBS.SelectedItem.ToString() : "All"; }
            set { ui_ncmbBS.SelectedIndex = ui_ncmbBS.Items.IndexOf(value); }
        }

        public int AccountNo
        {
            get
            {
                return ui_ncmbAccountNo.SelectedItem != null && ui_ncmbAccountNo.SelectedItem.ToString() != "All"
                           ? Convert.ToInt32(ui_ncmbAccountNo.SelectedItem.ToString())
                           : 0;
            }
            set { ui_ncmbAccountNo.SelectedIndex = ui_ncmbAccountNo.Items.IndexOf(Convert.ToString(value)); }
        }

        public string OrderStatus
        {
            get { return ui_ncmbOrderStatus.SelectedItem != null ? ui_ncmbOrderStatus.SelectedItem.ToString() : "All"; }
            set { ui_ncmbOrderStatus.SelectedIndex = ui_ncmbOrderStatus.Items.IndexOf(value); }
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
        public uctlTradeWindowWithFilter()
        {
            InitializeComponent();
        }

        #endregion "         CONSTRUCTOR          "

        #region    "         EVENTS          "

        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };
        public event Action<object, EventArgs> HandleCloseOrderClick = delegate { };
        public event Action<object, EventArgs> HandleRefreshClick = delegate { };

        #endregion "          EVENTS         "

        #region    "         METHODS         "

        /// <summary>
        /// This method adds menu items to the context menu of uctlTradeWindow control
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[6];

            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Click += OnViewClick;
            ViewSubMenu(ContextMenuItems[0]);
            ContextMenuItems[1] = new ToolStripMenuItem("Filter");
            ContextMenuItems[1].Name = "Filter";
            ContextMenuItems[1].ShortcutKeys = ShortcutKeyFilter;
            ContextMenuItems[1].Visible = false;
            // ContextMenuItems[1].Click += OnFilterClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Save As");
            ContextMenuItems[2].Name = "SaveAs";
            ContextMenuItems[2].Click += OnSaveAsClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[3].Click += OnColumnProfileClick;           
            ContextMenuItems[4] = new ToolStripMenuItem("Close Order");
            ContextMenuItems[4].Name = "CloseOrder";
            ContextMenuItems[4].Click += OnCloseOrderClick;
            ContextMenuItems[5] = new ToolStripMenuItem("Refresh");
            ContextMenuItems[5].Name = "Refresh";            
            ContextMenuItems[5].ShortcutKeys = Keys.F5;
            ContextMenuItems[5].ShowShortcutKeys = true;
            ContextMenuItems[5].Click += OnRefreshClick;
            ui_uctlGridTradeWindow.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            HandleRefreshClick(sender, e);
        }

        private void OnCloseOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to Close order?");
            if (result == DialogResult.Yes)
            {
                HandleCloseOrderClick(sender, e);
            }
        }


        public void FillProductTypes(string[] instNames)
        {
            ui_ncmbProductType.Items.AddRange(instNames);
            ui_ncmbProductType.SelectedIndex = 0;
        }
        public void AddOrderTypes(string[] orderTypes)
        {
            ui_ncmbOrderType.Items.AddRange(orderTypes);
            ui_ncmbOrderType.SelectedIndex = 0;
        }

        public void AddSide(string[] side)
        {
            ui_ncmbBS.Items.AddRange(side);
            ui_ncmbBS.SelectedIndex = 0;       
        }
        public void AddAccounts(List<string> lstAccountNos)
        {
            ui_ncmbAccountNo.Items.AddRange(lstAccountNos.ToArray());
            ui_ncmbAccountNo.SelectedIndex = 0;
        }

        public void AddContracts(string[] contracts)
        {
            ui_ncmbContract.Items.AddRange(contracts);
            ui_ncmbContract.SelectedIndex = 0;
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
                ((Dictionary<string, ClsProfile>)Profile)[currentProfile + "_" + ProfileTypes.Trade.ToString()];
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
            _title = ClsLocalizationHandler.Trade + " History " + ClsLocalizationHandler.Window;
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
            ui_uctlGridTradeWindow.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[38];

            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //OrderID
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "OrderNo", "Order No.");
            columnsArray[0].DefaultCellStyle = intCellStyle;
            columnsArray[0].DataPropertyName = "OrderNo";
            columnsArray[0].MinimumWidth = 70;
            columnsArray[0].Width = 70;
            //ExecutionID
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "TradeNo", "Trade No.");
            columnsArray[1].DefaultCellStyle = intCellStyle;
            columnsArray[1].DataPropertyName = "TradeNo";
            columnsArray[1].MinimumWidth = 70;
            columnsArray[1].Width = 70;
            //ContractName
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "Contract", "Contract");
            columnsArray[2].DataPropertyName = "Contract";
            columnsArray[2].Width = 90;
            //AccountID
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "Account", "Account");
            columnsArray[3].DefaultCellStyle = intCellStyle;
            columnsArray[3].DataPropertyName = "Account";
            columnsArray[3].MinimumWidth = 70;
            columnsArray[3].Width = 70;                     
            //ProductType
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "ProductType", "Product Type", false);
            columnsArray[4].DataPropertyName = "ProductType";
            columnsArray[4].MinimumWidth = 90;
            columnsArray[4].Width = 90;
            //Product
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "ProductName", "Product Name", false);
            columnsArray[5].DataPropertyName = "ProductName";
            columnsArray[5].Width = 90;
            //OrderType
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "OrderType", "Order Type");
            columnsArray[6].DataPropertyName = "OrderType";
            columnsArray[6].Width = 90;
            //Side
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "BS", "B/S");
            columnsArray[7].DataPropertyName = "BS";
            columnsArray[7].Width = 60;
            //QTY
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "Quantity", "Quantity");
            columnsArray[8].DefaultCellStyle = intCellStyle;
            columnsArray[8].DataPropertyName = "Quantity";
            columnsArray[8].Width = 70;
            //Price
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "Price", "Price");
            columnsArray[9].DefaultCellStyle = intCellStyle;
            columnsArray[9].DataPropertyName = "Price";
            columnsArray[9].Width = 70;
            //TriggerPrice
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "TriggerPrice", "Trigger Price");
            columnsArray[10].DefaultCellStyle = intCellStyle;
            columnsArray[10].DataPropertyName = "TriggerPrice";
            columnsArray[10].Width = 70;
            //NA 
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "AvgPrice", "Average Price");
            columnsArray[11].DefaultCellStyle = intCellStyle;
            columnsArray[11].DataPropertyName = "AvgPrice";
            columnsArray[11].Width = 90;
            //NA
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "FillPrice", "TP");
            columnsArray[12].ToolTipText = "Traded Price";
            columnsArray[12].DefaultCellStyle = intCellStyle;
            columnsArray[12].DataPropertyName = "FillPrice";
            columnsArray[12].Width = 80;
            //Commission
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "Commission", "Commission");
            columnsArray[13].DefaultCellStyle = intCellStyle;
            columnsArray[13].DataPropertyName = "Commission";
            columnsArray[13].Width = 80;
            //Tax
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "Tax", "Tax", false);
            columnsArray[14].DefaultCellStyle = intCellStyle;
            columnsArray[14].DataPropertyName = "Tax";
            columnsArray[14].Width = 70;
                        //OrderStatus
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "Status", "Status", false);
            columnsArray[15].DataPropertyName = "Status";
            columnsArray[15].Width = 90;
            //ExpiryDate
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "LeaveQty", "Leave Qty", false);
            columnsArray[16].DataPropertyName = "LeaveQty";
            columnsArray[16].Width = 70;
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "SettledQty", "Settled Qty");
            columnsArray[17].DefaultCellStyle = intCellStyle;
            columnsArray[17].DataPropertyName = "SettledQty";
            columnsArray[17].MinimumWidth = 70;
            columnsArray[17].Width = 70;
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "Profit", "Realised P/L");
            columnsArray[18].DefaultCellStyle = intCellStyle;
            columnsArray[18].DataPropertyName = "Profit";
            columnsArray[18].MinimumWidth = 70;
            columnsArray[18].Width = 70;
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "PnL", "Unrealised P/L");
            columnsArray[19].DefaultCellStyle = intCellStyle;
            columnsArray[19].DataPropertyName = "PnL";
            columnsArray[19].MinimumWidth = 70;
            columnsArray[19].Width = 70;
            //TransacTime
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "TradeTime", "Trade Time");
            columnsArray[20].DataPropertyName = "TradeTime";
            columnsArray[20].DisplayIndex = 0;
            
            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "SpreadSymbol", "Spread Symbol", false);
            //NA
            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "AccountType", "Account Type", false);
            //NA
            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "ClientName", "Client Name", false);
            //NA
            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "Client", "Client", false);
            //To Be Removed
            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "PartOmniId", "Part Id/Omni Id", false);
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
            //LastUpdatedTime
            columnsArray[35] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "LastUpdatedTime", "Last Updated Time", false);
            columnsArray[35].DataPropertyName = "LastUpdatedTime";

            //TradingCurrency
            columnsArray[36] = ClsCommonMethods.CreateGridColumn(columnsArray[36], "TradingCurrency", "Trading Currency", false);
            //NA
            columnsArray[37] = ClsCommonMethods.CreateGridColumn(columnsArray[37], "QtyTotal", "Total Quantity", false);
            //NA
            
            ui_uctlGridTradeWindow.AddColumns(columnsArray);
        }
        private void ui_uctlGridTradeWindow_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

        private void ui_nbtnHideFilter_Click(object sender, EventArgs e)
        {
            if (ui_npnlFilter.Visible)
            {
                ui_nbtnHideFilter.Text = "Show &Filter >>";
                ui_uctlGridTradeWindow.Height = ui_uctlGridTradeWindow.Height + ui_npnlFilter.Height + 6;
                ui_npnlFilter.Visible = false;
            }
            else
            {
                ui_nbtnHideFilter.Text = "Hide &Filter <<";
                ui_npnlFilter.Visible = true;
                ui_uctlGridTradeWindow.Height = ui_uctlGridTradeWindow.Height - ui_npnlFilter.Height - 6;
            }
        }

        private void ui_ncmbAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbAccountNo.SelectedIndex > -1)
            {
                _isAccountNoChanged = true;
                ui_ncmbProductType.SelectedIndex = 0;
                ui_ncmbOrderType.SelectedIndex = 0;
                ui_ncmbOrderStatus.SelectedIndex = 0;
                ui_ncmbBS.SelectedIndex = 0;
                ui_ncmbContract.SelectedIndex = 0;
                SelectionCriteriaChanged();
                _isAccountNoChanged = false;
                //OnAccountChanged();

            }
        }

        public void AddOrderStatus(string[] orderStatus)
        {
            ui_ncmbOrderStatus.Items.AddRange(orderStatus);          
            ui_ncmbOrderStatus.SelectedItem = "All";
        }

        private void ui_ncmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbContract.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void ui_ncmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbProductType.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void ui_ncmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbOrderType.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void ui_ncmbBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBS.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void uctlTradeWindowWithFilter_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            SetLocalization();
        }

        private void ui_uctlGridTradeWindow_Load_1(object sender, EventArgs e)
        {
            CreateContextMenu();
        }

        private void ui_uctlGridTradeWindow_OnGridMouseDown_1(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
          
            //if (ui_ncmbAccountNo.Text.Trim() != "" && ui_ncmbAccountNo.Text != "All")
            //    AccountNo = Convert.ToInt32(ui_ncmbAccountNo.SelectedItem.ToString());
            //else
            //    AccountNo = 0;
            //if (ui_ncmbProductType.SelectedItem != null)
            //    ProductType = ui_ncmbProductType.SelectedItem.ToString();
            //if (ui_ncmbOrderType.SelectedItem != null)
            //    OrderType = ui_ncmbOrderType.SelectedItem.ToString();
            //if (ui_ncmbBS.SelectedItem != null)
            //    BS = ui_ncmbBS.SelectedItem.ToString();     
            FromDate = ui_ndtpFrom.Value;
            ToDate = ui_ndtpTo.Value;

            ui_nsbFilterValue.Text = string.Empty;

            OnSearchClick(AccountNo, ProductType, OrderType, BS,Contract, FromDate, ToDate);
        }

        private void ui_ndtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ui_lblTo_Click(object sender, EventArgs e)
        {

        }

        private void ui_ndtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ui_lblFrom_Click(object sender, EventArgs e)
        {

        }

        private void ui_ncmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbOrderStatus.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }
    }
}
