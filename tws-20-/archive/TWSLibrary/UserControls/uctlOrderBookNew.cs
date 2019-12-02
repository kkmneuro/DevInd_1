///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//03/02/2012	VP          1.Added columnProfile menu in gridmenu and defined there functionality
//07/02/2012	VP          1.Added columns to the grid of the  control
//05/03/2012	VP          1.Code for columnProfile
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlOrderBookNew : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        private DateTime FromDate = DateTime.MinValue;
        private DateTime ToDate = DateTime.MinValue;
        public Dictionary<long, DataRow> _DDRow = new Dictionary<long, DataRow>();
        public event Action<int, string, string, string,string,string, DateTime, DateTime> OnSearchClick = delegate { };
        private Keys _shortcutKeyFilter = Keys.None;
        private string _title = "Order Book";

        private bool _isAccountNoChanged = true;

        //int _AccountNo = 0;
        //string _ProductType = string.Empty;
        //string _OrderType = string.Empty;
        //string _BS = string.Empty;
        //string _OrderStatus = string.Empty;

        public string ProductType
        {
            get { return ui_ncmbProductType.SelectedItem != null ? ui_ncmbProductType.SelectedItem.ToString() : "All"; }
            set { ui_ncmbProductType.SelectedIndex = ui_ncmbProductType.Items.IndexOf(value); }
        }

        public string Contract
        {
            get { return ui_ncmbContract.SelectedItem != null ? ui_ncmbContract.SelectedItem.ToString() : "All"; }
            set { ui_ncmbContract.SelectedIndex = ui_ncmbContract.Items.IndexOf(value); }
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

        public string OrderStatus
        {
            get { return ui_ncmbOrderStatus.SelectedItem != null ? ui_ncmbOrderStatus.SelectedItem.ToString() : "All"; }
            set { ui_ncmbOrderStatus.SelectedIndex = ui_ncmbOrderStatus.Items.IndexOf(value); }
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

        public Keys ShortcutKeyFilter
        {
            get { return _shortcutKeyFilter; }
            set { _shortcutKeyFilter = value; }
        }

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// Sets and gets the title of the order book control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string BuyQty
        {
            get { return ui_nsbBuyQtyValue.Text; }
            set { ui_nsbBuyQtyValue.Text = value; }
        }
        public string SellQty
        {
            get { return ui_nsbSelQtyValue.Text; }
            set { ui_nsbSelQtyValue.Text = value; }
        }
        public object Profiles { get; set; }

        public int MarketMakerAccountId { get; set; }
        
        public string CurrentProfileName { get; set; }

        /// <summary>
        /// This property sets the colour of the current row of the grid. This property is both settable and gettable
        /// </summary>
        public Color DataRowStyle { get; set; }

        /// <summary>
        /// Apply condition in filter and accordingly, the conditional output is displayed when required.
        /// </summary>
        public UctlFilter OrderFilter { get; set; }

        /// <summary>
        /// When pending order Executed then alert sound should fire
        /// </summary>
        public string AlertSound { get; set; }

        #endregion "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlOrderBook 
        /// </summary>
        public UctlOrderBookNew()
        {
            InitializeComponent();
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "
        public ToolStripMenuItem[] ContextMenuItems = new ToolStripMenuItem[8];
        /// <summary>
        /// This method adds menu items to the context menu of uctlOrderBook control
        /// </summary>
        public void CreateContextMenu(string[] orderStatus)
        {
            //try
            //{        
            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Click += OnViewClick;
            ContextMenuItems[0].Name = "View";
            ViewSubMenu(orderStatus, ContextMenuItems[0]);
            ContextMenuItems[1] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[1].Click += OnColumnProfileClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Save As");
            ContextMenuItems[2].Name = "SaveAs";
            ContextMenuItems[2].Click += OnSaveAsClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Cancel Order");
            ContextMenuItems[3].Name = "CancelOrder";
            ContextMenuItems[3].Click += OnCancelOrderClick;
            ContextMenuItems[4] = new ToolStripMenuItem("Filter");
            ContextMenuItems[4].Name = "Filter";
            ContextMenuItems[4].ShortcutKeys = ShortcutKeyFilter;
            ContextMenuItems[4].Visible = false;
            // ContextMenuItems[4].Click += OnFilterClick;
            ContextMenuItems[5] = new ToolStripMenuItem("Modify Order");
            ContextMenuItems[5].Name = "ModifyOrder";
            ContextMenuItems[5].ShortcutKeyDisplayString = "";
            //ContextMenuItems[5].ShortcutKeys = Keys.Shift+Keys.F4;
            //ContextMenuItems[5].ShowShortcutKeys = true;
            ContextMenuItems[5].Click += OnModifyOrderClick;
            ContextMenuItems[6] = new ToolStripMenuItem("Close Order");
            ContextMenuItems[6].Name = "CloseOrder";
            ContextMenuItems[6].Click += OnCloseOrderClick;
            ContextMenuItems[7] = new ToolStripMenuItem("Refresh");
            ContextMenuItems[7].Name = "Refresh";
            ContextMenuItems[7].ShortcutKeys = Keys.F5;
            ContextMenuItems[7].ShowShortcutKeys = true;
            ContextMenuItems[7].Click += OnRefreshClick;
            ui_uctlGridOrderBook.ContextMenuStrip.Items.AddRange(ContextMenuItems);
            //}
            //catch(Exception ex)
            //{ }
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
        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            #region "     Add Columns to grid      "

            var columnsArray = new DataGridViewColumn[50];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmOrderNumber", "Order Number");
            columnsArray[0].DataPropertyName = "ClientOrderID";
            columnsArray[0].DefaultCellStyle = intCellStyle;

            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmContract", "Contract");
            columnsArray[1].DataPropertyName = "Contract";
            columnsArray[1].DisplayIndex = 2;

            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmClient", "Account No");
            columnsArray[2].DataPropertyName = "Account";
            columnsArray[2].DefaultCellStyle = intCellStyle;

            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmProductType", "Product Type", false);
            columnsArray[3].DataPropertyName = "ProductType";

            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmProductName", "Product Name", false);
            columnsArray[4].DataPropertyName = "Product";
            columnsArray[4].DisplayIndex = 1;
                        

            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmSeriesExpiry", "Expiry", false);
            columnsArray[5].DataPropertyName = "ExpireDate";

            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmOrderType", "Order Type");
            columnsArray[6].DataPropertyName = "OrderType";

            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmBS", "B/S");
            columnsArray[7].DataPropertyName = "Side";

            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmOrderQuantity", "Order Qty");
            columnsArray[8].DataPropertyName = "OrderQty";
            columnsArray[8].DefaultCellStyle = intCellStyle;

            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmTotalExecutedQuantity", "Total Executed Quantity", false);
            columnsArray[9].DataPropertyName = "CumQty";
            columnsArray[9].DefaultCellStyle = intCellStyle;

            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmPendingQuantity", "Pending Quantity");
            columnsArray[10].DataPropertyName = "LeavesQty";
            columnsArray[10].DefaultCellStyle = intCellStyle;

            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmPrice", "Price");
            columnsArray[11].DataPropertyName = "Price";
            columnsArray[11].DefaultCellStyle = intCellStyle;

            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "ClmTriggerPrice", "Trigger Price");
            columnsArray[12].DataPropertyName = "StopPx";
            columnsArray[12].DefaultCellStyle = intCellStyle;

            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "clmStatus", "Status");
            columnsArray[13].DataPropertyName = "OrderStatus";

            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "clmValidity", "Validity", false);
            columnsArray[14].DataPropertyName = "TimeInForce";

            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "clmDisclosedQuantity", "Disclosed Quantity", false);
            columnsArray[15].DefaultCellStyle = intCellStyle;

            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "clmLastModifiedTime", "Last Modified Time", false);

            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "clmAvgPrice", "Average Price", false);
            columnsArray[17].DataPropertyName = "AvgPrice";
            columnsArray[17].DefaultCellStyle = intCellStyle;

            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "clmCommission", "Commission", false);
            columnsArray[18].DataPropertyName = "Commission";
            columnsArray[18].DefaultCellStyle = intCellStyle;

            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "clmTax", "Tax", false);
            columnsArray[19].DataPropertyName = "Tax";
            columnsArray[19].DefaultCellStyle = intCellStyle;

            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "clmOptionType", "Option Type", false);

            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "clmTradingCurrency", "Trading Currency", false);
            columnsArray[21].DataPropertyName = "TradingCurrency";

            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "clmAccountType", "Account Type", false);

            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "clmClientName", "Client Name", false);

            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "clmPartIdOmniId", "Part Id/Omni Id", false);

            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "clmNetVal", "Net Val.", false);
            columnsArray[25].DefaultCellStyle = intCellStyle;

            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "clmGoodTillDate", "Good Till Date",false);
            columnsArray[26].DataPropertyName = "ExpireDate";

            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "clmReason", "Reason", false);
            columnsArray[27].DataPropertyName = "Text";

            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "clmRemarks", "Remarks", false);

            columnsArray[29] = ClsCommonMethods.CreateGridColumn(columnsArray[29], "clmCounterTM", "Counter TM", false);

            columnsArray[30] = ClsCommonMethods.CreateGridColumn(columnsArray[30], "clmEnteredBy", "Entered By", false);

            columnsArray[31] = ClsCommonMethods.CreateGridColumn(columnsArray[31], "clmModifiedBy", "Modified By", false);

            columnsArray[32] = ClsCommonMethods.CreateGridColumn(columnsArray[32], "clmSpread", "Spread", false);

            columnsArray[33] = ClsCommonMethods.CreateGridColumn(columnsArray[33], "clmReferenceNo", "Reference No.", false);
            columnsArray[33].DataPropertyName = "OrderID";
            columnsArray[33].DefaultCellStyle = intCellStyle;

            columnsArray[34] = ClsCommonMethods.CreateGridColumn(columnsArray[34], "clmRealValue", "Real Value", false);

            columnsArray[35] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "clmYourMoneyUsed", "Your Money Used", false);

            columnsArray[36] = ClsCommonMethods.CreateGridColumn(columnsArray[36], "clmCurrentMarketPrice", "Current market price", false);

            columnsArray[37] = ClsCommonMethods.CreateGridColumn(columnsArray[37], "clmStopLoss", "Stop Loss", false);

            columnsArray[38] = ClsCommonMethods.CreateGridColumn(columnsArray[38], "clmTakeProfit", "Take Profit", false);

            columnsArray[39] = ClsCommonMethods.CreateGridColumn(columnsArray[39], "clmSwap", "Swap", false);

            columnsArray[40] = ClsCommonMethods.CreateGridColumn(columnsArray[40], "clmCommission", "Commission", false);

            columnsArray[41] = ClsCommonMethods.CreateGridColumn(columnsArray[41], "clmProfitCurrency", "Profit (Currency)", false);

            columnsArray[42] = ClsCommonMethods.CreateGridColumn(columnsArray[42], "clmProfitPIPS", "Profit PIPS", false);
            columnsArray[43] = ClsCommonMethods.CreateGridColumn(columnsArray[43], "clmGateway", "GateWay", false);
            columnsArray[43].DataPropertyName = "Gateway";
            columnsArray[44] = ClsCommonMethods.CreateGridColumn(columnsArray[44], "clmColor", "Color", false);
            columnsArray[44].DataPropertyName = "Color";
            columnsArray[45] = ClsCommonMethods.CreateGridColumn(columnsArray[45], "clmTransactionTime", "Transaction Time");
            columnsArray[45].DataPropertyName = "TransactTime";
            columnsArray[45].DisplayIndex = 11;
            columnsArray[46] = ClsCommonMethods.CreateGridColumn(columnsArray[46], "clmCounterClOrdId", "CounterClOrdId", false);
            columnsArray[46].DataPropertyName = "CounterClOrdId";
            columnsArray[47] = ClsCommonMethods.CreateGridColumn(columnsArray[47], "clmCounterAvgPx", "CounterAvgPx", false);
            columnsArray[47].DataPropertyName = "CounterAvgPx";
            columnsArray[48] = ClsCommonMethods.CreateGridColumn(columnsArray[48], "clmGrossPL", "Gross Profit Loss", false);
            columnsArray[48].DataPropertyName = "GrossPL";
            columnsArray[49] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "SettledQty", "Settled Qty", false);
            columnsArray[49].DefaultCellStyle = intCellStyle;
            columnsArray[49].DataPropertyName = "SettledQty";
            columnsArray[49].MinimumWidth = 70;
            columnsArray[49].Width = 70;
            if (MarketMakerAccountId > 0)
            {
                columnsArray[46].Visible = true;
                columnsArray[47].Visible = true;
                columnsArray[48].Visible = true;
            }

            ui_uctlGridOrderBook.AddColumns(columnsArray);

            #endregion "     Add Columns to grid      "
        }
        /// <summary>
        ///  This method adds sub menu items to the View item of context menu
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <param name="viewItem"></param>
        public void ViewSubMenu(string[] orderStatus, ToolStripMenuItem viewItem)
        {
            var viewSubItems = new ToolStripMenuItem[orderStatus.Length];
            for (int i = 0; i < orderStatus.Length; i++)
            {
                viewSubItems[i] = new ToolStripMenuItem(orderStatus[i]);
                viewSubItems[i].Click += OnClick;
            }
            viewItem.DropDownItems.AddRange(viewSubItems);
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
        /// This method adds functionality to the Column Profile item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.OrderBook, Profiles,
                                                           CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnProfileRemoveClick += objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick += objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridOrderBook);
            objfrmColumnProfile.ShowDialog();
        }

        private void objfrmColumnProfile_OnSetDefaultProfileClick(object profiles, string profileName)
        {
            OnSetDefaultProfileClick(profiles, profileName);
        }

        private void objfrmColumnProfile_OnProfileRemoveClick(object profiles, string profileName)
        {
            OnProfileRemoveClick(profiles, profileName);
        }

        private void objfrmColumnProfile_OnProfileSaveClick(object profiles, string profileName)
        {
            OnProfileSaveClick(profiles, profileName);
        }

        /// <summary>
        /// Applys the users column settings to the grid
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="currentProfile"></param>
        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            CurrentProfileName = currentProfile;
            Profiles = profiles;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)Profiles)[currentProfile + "_" + ProfileTypes.OrderBook.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridOrderBook.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        /// <summary>
        /// This method adds functionality to the Save As item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSaveAsClick(object sender, EventArgs e)
        {
            var objSaveFileDialog = new SaveFileDialog { DefaultExt = ".xls", Filter = "(*.xls)|*.xls" };
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
            if (objDialogResult == DialogResult.OK)
            {
                string filePath = objSaveFileDialog.FileName;
                ClsCommonMethods.SaveGridDataInExcel(filePath, ui_uctlGridOrderBook);
            }
        }

        private void OnModifyOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to modify order?");
            if (result == DialogResult.Yes)
            {
                HandleModifyOrderClick(sender, e);
            }
        }

        /// <summary>
        /// This method adds functionality to the Cancel Order item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelOrderClick(object sender, EventArgs e)
        {
            DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure to cancel order?");
            if (result == DialogResult.Yes)
            {
                HandleCancelOrderClick(sender, e);
            }
        }

        /// <summary>
        /// This method adds functionality to the filter item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFilterClick(object sender, EventArgs e)
        {
            var objUctlFilter = new UctlFilter();
            objUctlFilter.OnCancelClick += objUctlFilter_OnCancelClick;
            objUctlFilter.OnApplyClick += objUctlFilter_OnApplyClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objUctlFilter.Width + 8, objUctlFilter.Height + 28);
            _objfrmDialogForm.Size = objSize;
            _objfrmDialogForm.Controls.Add(objUctlFilter);
            objUctlFilter.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objUctlFilter.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.ShowDialog();
        }

        private void objUctlFilter_OnApplyClick(object arg1, EventArgs arg2, object arg3)
        //arg3 is the class containing the filter information
        {
        }

        private void objUctlFilter_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }

        /// <summary>
        /// This method adds functionality to the "All" item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, EventArgs e)
        {
            OrderStatus = ((ToolStripMenuItem)sender).Text;
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
        /// This method adds functionality to the Submitted item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSubmittedClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Executed item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExecutedClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Cancelled item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelledClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method adds functionality to the Reject item of context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRejectedClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets the text of controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Book;

            ui_lblInstrumentName.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name +
                                        " :";
            ui_lblOrderType.Text = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Type + " :";
            ui_lblTo.Text = ClsLocalizationHandler.To + " :";
            ui_lblFrom.Text = ClsLocalizationHandler.From + " :";
            ui_lblOrderStatus.Text = ClsLocalizationHandler.Order + " " + ClsLocalizationHandler.Status + " :";
            ui_nbtnHideFilter.Text = ClsLocalizationHandler.Show + " " + ClsLocalizationHandler.Filter + " >>";
            ui_nbtnHideFilter.Text = ClsLocalizationHandler.Hide + " " + ClsLocalizationHandler.Filter + " <<";
        }

        /// <summary>
        /// this method adds context menu to the control at run time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlOrderBook_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();           
            //AddColumnsToGrid(columnsArray);
            //CreateContextMenu(orderStatus);
            ui_uctlGridOrderBook.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //SetLocalization();
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid(DataGridViewColumn[] columnsArray)
        {
            ui_uctlGridOrderBook.AddColumns(columnsArray);
        }

        #endregion   "        METHODS          "

        private void ui_nbtnHideFilter_Click(object sender, EventArgs e)
        {
            if (ui_npnlFilter.Visible)
            {
                ui_nbtnHideFilter.Text = "Show &Filter >>";
                ui_uctlGridOrderBook.Height = ui_uctlGridOrderBook.Height + ui_npnlFilter.Height + 6;
                ui_npnlFilter.Visible = false;
            }
            else
            {
                ui_nbtnHideFilter.Text = "Hide &Filter <<";
                ui_npnlFilter.Visible = true;
                ui_uctlGridOrderBook.Height = ui_uctlGridOrderBook.Height - ui_npnlFilter.Height - 6;
            }
        }

        public void AddOrderTypes(string[] orderTypes)
        {
            ui_ncmbOrderType.Items.AddRange(orderTypes);
            ui_ncmbOrderType.SelectedIndex = 0;
        }

        public void AddContracts(string[] contracts)
        {
            ui_ncmbContract.Items.AddRange(contracts);
            ui_ncmbContract.SelectedIndex = 0;
        }

        public void AddSide(string[] side)
        {
            ui_ncmbBS.Items.AddRange(side);
            ui_ncmbBS.SelectedIndex = 0;
        }

        public void AddOrderStatus(string[] orderStatus)
        {
            ui_ncmbOrderStatus.Items.AddRange(orderStatus);
           // ui_ncmbOrderStatus.SelectedIndex = 0;
            //ui_ncmbOrderStatus.SelectedItem = "Working";
            
        }

        public void FillProductTypes(string[] instNames)
        {
            ui_ncmbProductType.Items.AddRange(instNames);
            ui_ncmbProductType.SelectedIndex = 0;
        }

        private void ui_uctlGridOrderBook_OnRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ui_nsbNoOfOrdersValue.Text = ui_uctlGridOrderBook.Rows.Count.ToString();
            //if (ui_uctlGridOrderBook.Rows.Count > 0)
            //{
            //    if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmOrderType"].Value.ToString().ToUpper() == "BUY")
            //    {
            //        if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmStatus"].Value.ToString().ToUpper() !=
            //            "REJECTED")
            //            ui_nsbBuyQtyValue.Text = ui_nsbBuyQtyValue.Text == string.Empty
            //                                         ? "0"
            //                                         : Convert.ToString(Convert.ToInt32(ui_nsbBuyQtyValue.Text) +
            //                                                            Convert.ToInt32(
            //                                                                ui_uctlGridOrderBook.Rows[e.RowIndex].Cells[
            //                                                                    "clmOrderQuantity"].Value.ToString()));
            //        //else
            //        //    ui_nsbBuyQtyValue.Text = ui_nsbBuyQtyValue.Text == string.Empty
            //        //                                 ? "0"
            //        //                                 : Convert.ToString(Math.Abs(Convert.ToInt32(ui_nsbBuyQtyValue.Text) -
            //        //                                                             Convert.ToInt32(
            //        //                                                                 ui_uctlGridOrderBook.Rows[e.RowIndex].
            //        //                                                                     Cells[
            //        //                                                                         "clmOrderQuantity"].Value.
            //        //                                                                     ToString())));
            //    }
            //    else
            //    {
            //        if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmStatus"].Value.ToString().ToUpper() !=
            //            "REJECTED")
            //            ui_nsbSelQtyValue.Text = ui_nsbSelQtyValue.Text == string.Empty
            //                                         ? "0"
            //                                         : Convert.ToString(Convert.ToInt32(ui_nsbSelQtyValue.Text) +
            //                                                            Convert.ToInt32(
            //                                                                ui_uctlGridOrderBook.Rows[e.RowIndex].Cells[
            //                                                                    "clmOrderQuantity"].Value.ToString()));
            //        //else
            //        //    ui_nsbSelQtyValue.Text = ui_nsbSelQtyValue.Text == string.Empty
            //        //                                 ? "0"
            //        //                                 : Convert.ToString(Math.Abs(Convert.ToInt32(ui_nsbSelQtyValue.Text) -
            //        //                                                             Convert.ToInt32(
            //        //                                                                 ui_uctlGridOrderBook.Rows[e.RowIndex].
            //        //                                                                     Cells[
            //        //                                                                         "clmOrderQuantity"].Value.
            //        //                                                                     ToString())));
            //    }
            //}

        }

        private void ui_uctlGridOrderBook_OnRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ui_nsbNoOfOrdersValue.Text = ui_uctlGridOrderBook.Rows.Count.ToString();
            //if (ui_uctlGridOrderBook.Rows.Count > 0)
            //{
            //    if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmOrderType"].Value.ToString().ToUpper() == "BUY")
            //    {
            //        if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmStatus"].Value.ToString().ToUpper() !=
            //            "REJECTED")
            //            ui_nsbBuyQtyValue.Text = ui_nsbBuyQtyValue.Text == string.Empty
            //                                         ? "0"
            //                                         : Convert.ToString(
            //                                             Math.Abs(Convert.ToInt32(ui_nsbBuyQtyValue.Text) -
            //                                                      Convert.ToInt32(
            //                                                          ui_uctlGridOrderBook.Rows[e.RowIndex].Cells[
            //                                                              "clmOrderQuantity"].Value.ToString())));
            //        //else
            //        //    ui_nsbBuyQtyValue.Text = ui_nsbBuyQtyValue.Text == string.Empty
            //        //                                 ? "0"
            //        //                                 : Convert.ToString(Math.Abs(Convert.ToInt32(ui_nsbBuyQtyValue.Text) -
            //        //                                                             Convert.ToInt32(
            //        //                                                                 ui_uctlGridOrderBook.Rows[e.RowIndex].
            //        //                                                                     Cells[
            //        //                                                                         "clmOrderQuantity"].Value.
            //        //                                                                     ToString())));
            //    }
            //    else
            //    {
            //        if (ui_uctlGridOrderBook.Rows[e.RowIndex].Cells["clmStatus"].Value.ToString().ToUpper() !=
            //            "REJECTED")
            //            ui_nsbSelQtyValue.Text = ui_nsbSelQtyValue.Text == string.Empty
            //                                         ? "0"
            //                                         : Convert.ToString(
            //                                             Math.Abs(Convert.ToInt32(ui_nsbSelQtyValue.Text) -
            //                                                      Convert.ToInt32(
            //                                                          ui_uctlGridOrderBook.Rows[e.RowIndex].Cells[
            //                                                              "clmOrderQuantity"].Value.ToString())));
            //        //else
            //        //    ui_nsbSelQtyValue.Text = ui_nsbSelQtyValue.Text == string.Empty
            //        //                                 ? "0"
            //        //                                 : Convert.ToString(Math.Abs(Convert.ToInt32(ui_nsbSelQtyValue.Text) -
            //        //                                                             Convert.ToInt32(
            //        //                                                                 ui_uctlGridOrderBook.Rows[e.RowIndex].
            //        //                                                                     Cells[
            //        //                                                                         "clmOrderQuantity"].Value.
            //        //                                                                     ToString())));
            //    }
            //}
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

        private void ui_ncmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbOrderStatus.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void ui_ncmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbContract.SelectedIndex > -1 && _isAccountNoChanged == false)
            {
                SelectionCriteriaChanged();
            }
        }

        private void ui_ndtpFrom_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ui_ndtpTo_ValueChanged(object sender, EventArgs e)
        {
        }

        public void HandleSearch()
        {
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            //ProductType = string.Empty;
            //OrderType = string.Empty;
            //BS = string.Empty;
            //OrderStatus = string.Empty;
            //AccountNo = 0;
            //if (ui_ncmbAccountNo.SelectedItem != null && ui_ncmbAccountNo.SelectedItem.ToString() != "All")
            //    AccountNo = Convert.ToInt32(ui_ncmbAccountNo.SelectedItem.ToString());
            //else
            //    AccountNo = 0;
            //if (ui_ncmbProductType.SelectedItem != null)
            //    ProductType = ui_ncmbProductType.SelectedItem.ToString();
            //if (ui_ncmbOrderType.SelectedItem != null)
            //    OrderType = ui_ncmbOrderType.SelectedItem.ToString();
            //if (ui_ncmbBS.SelectedItem != null)
            //    BS = ui_ncmbBS.SelectedItem.ToString();
            //if (ui_ncmbOrderStatus.SelectedItem != null)
            //    OrderStatus = ui_ncmbOrderStatus.SelectedItem.ToString();
            FromDate = ui_ndtpFrom.Value;
            ToDate = ui_ndtpTo.Value;

            ui_nsbFilterValue.Text = string.Empty;

            OnSearchClick(AccountNo, ProductType, OrderType,OrderStatus, BS,Contract, FromDate, ToDate);
        }

        //public event Action<int, string, string, string, string, DateTime, DateTime> OnSearchClick = delegate { };


        private void ui_tlpnlOrderBookTable_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ui_uctlGridOrderBook_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                OnGridMouseDown(sender, e);
            }
            catch (Exception)
            {
                
                
            }
            
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

        public void AddAccounts(List<string> lstAccountNos)
        {
            ui_ncmbAccountNo.Items.AddRange(lstAccountNos.ToArray());
            ui_ncmbAccountNo.SelectedIndex = 0;
        }

        private void ui_nsbOrderSatusBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
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

        private void uctlOrderBook_Click(object sender, EventArgs e)
        {
            Click(sender, e);
        }

        public new event EventHandler Click = delegate { };

        private void uctlOrderBook_MouseClick(object sender, MouseEventArgs e)
        {
            Click(sender, e);
        }

        private void ui_uctlGridOrderBook_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            //if (arg2.RowIndex > -1 && ui_uctlGridOrderBook.ui_ndgvGrid.Rows.Count > arg2.RowIndex)
            //{
            //    ui_uctlGridOrderBook.ui_ndgvGrid.ClearSelection();
            //    ui_uctlGridOrderBook.ui_ndgvGrid.Rows[arg2.RowIndex].Selected = true;
            //}
        }

        #region "          EVENTS         "

        public event Action OnAccountChanged = delegate { };
        public event Action SelectionCriteriaChanged = delegate { };
        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };
        public event Action<object, EventArgs> HandleCancelOrderClick = delegate { };
        public event Action<object, EventArgs> HandleModifyOrderClick = delegate { };
        public event Action<object, EventArgs> HandleCloseOrderClick = delegate { };
        public event Action<object, EventArgs> HandleRefreshClick = delegate { };
        

        #endregion "       EVENTS         "

        private void ui_uctlGridOrderBook_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        
    }
}