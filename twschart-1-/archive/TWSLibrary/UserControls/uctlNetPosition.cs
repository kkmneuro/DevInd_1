///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//25/01/2012	VP		    1.Correct the layout properties of uctlNetPosition Control and added context menu to form.
//02/02/2012	VP		    1.Commenting of the code
//03/02/2012	VP          1.defined functionality of columnProfile menu
//20/02/2012	VP          1.Code for Saving Grid Data in Excel format
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlNetPosition : UctlBase
    {
        #region    "        MEMBERS           "

        public Dictionary<string, DataRow> _DDRows = new Dictionary<string, DataRow>();
        private string _title = "Net Position";
        //public Dictionary<string, DataGridViewRow> _DDRows = new Dictionary<string, DataGridViewRow>();

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// This property sets and gets the title of the uctlNetPosition control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public object Profiles { get; set; }

        public string CurrentProfileName { get; set; }

        /// <summary>
        /// Sets and gets the Instrument Name of the Instrument Name combo box
        /// </summary>
        public string InstrumentList
        {
            get
            {
                if (ui_ncmbContracts.SelectedItem != null)
                    return ui_ncmbContracts.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set { ui_ncmbContracts.SelectedItem = value; }
        }

        //public string AccountType
        //{
        //    get
        //    {
        //        if (ui_ncmbAccountType.SelectedItem != null)
        //            return ui_ncmbAccountType.SelectedItem.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    set { ui_ncmbAccountType.SelectedItem = value; }
        //}

        public string AccountNo
        {
            get
            {
                if (ui_ncmbAccountNo.SelectedItem != null)
                    return ui_ncmbAccountNo.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set { ui_ncmbAccountNo.SelectedItem = value; }
        }

        //public string ClientName
        //{
        //    get
        //    {
        //        if (ui_ncmbClientName.SelectedItem != null)
        //            return ui_ncmbClientName.SelectedItem.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    set { ui_ncmbClientName.SelectedItem = value; }
        //}

        //public string OminiID
        //{
        //    get
        //    {
        //        if (ui_ncmbOminiID.SelectedItem != null)
        //            return ui_ncmbOminiID.SelectedItem.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    set { ui_ncmbOminiID.SelectedItem = value; }
        //}

        //public string Product
        //{
        //    get
        //    {
        //        if (ui_ncmbProduct.SelectedItem != null)
        //            return ui_ncmbProduct.SelectedItem.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    set { ui_ncmbProduct.SelectedItem = value; }
        //}

        //public string TradingCurrency
        //{
        //    get
        //    {
        //        if (ui_ncmbTradingCurrency.SelectedItem != null)
        //            return ui_ncmbTradingCurrency.SelectedItem.ToString();
        //        else
        //            return string.Empty;
        //    }
        //    set { ui_ncmbTradingCurrency.SelectedItem = value; }
        //}

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlNetPosition 
        /// </summary>
        public UctlNetPosition()
        {
            InitializeComponent();
            AddColumnsToGrid();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlNetPosition with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlNetPosition(object customizeSettings)
        {
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// This method hides or show the filter panel and changes the text of Hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnHideFilter_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel2.Visible)
            {
                tableLayoutPanel2.Visible = false;
            }
            else
            {
                tableLayoutPanel2.Visible = true;
            }
        }

        /// <summary>
        /// Sets the text of the controls corresponding to their localized value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Net + " " + ClsLocalizationHandler.Position;
            //ui_lblAccountType.Text = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Type + " :";
            ui_lblClient.Text = ClsLocalizationHandler.Account + " " + ClsLocalizationHandler.Number + ":";
            //ui_lblClientName.Text = ClsLocalizationHandler.Client + " " + ClsLocalizationHandler.Name + " :";
            ui_lblContracts.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name +
                                   " :";
            //ui_lblOminiID.Text = ClsLocalizationHandler.Omni + " " + ClsLocalizationHandler.Id + " :";
            //ui_lblProduct.Text = ClsLocalizationHandler.Product + " :";
            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
            ui_nbtnHideFilter.Text = ClsLocalizationHandler.Show + " " + ClsLocalizationHandler.Filter + " >>";
            ui_nbtnHideFilter.Text = ClsLocalizationHandler.Hide + " " + ClsLocalizationHandler.Filter + " <<";
        }

        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[3];

            ContextMenuItems[0] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[0].Click += OnColumnProfileClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Square-Off Outstanding Positions");
            ContextMenuItems[1].Click += OnSquareOffOutstandingClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Save As");
            ContextMenuItems[2].Name = "SaveAs";
            ContextMenuItems[2].Click += OnSaveAsClick;

            ui_uctlGridNetPosition.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridNetPosition.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        /// Called when user select the ColumnProfile option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.NetPosition, Profiles,
                                                           CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnProfileRemoveClick +=
                objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick +=
                objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridNetPosition);
            objfrmColumnProfile.Text = Title + " " + objfrmColumnProfile.Text;
            objfrmColumnProfile.ShowDialog();
        }

        private void objfrmColumnProfile_OnSetDefaultProfileClick(object objProfile, string profileName)
        {
            OnSetDefaultProfileClick(objProfile, profileName);
        }

        private void objfrmColumnProfile_OnProfileRemoveClick(object objProfile, string profileName)
        {
            OnProfileRemoveClick(objProfile, profileName);
        }

        private void objfrmColumnProfile_OnProfileSaveClick(object objProfile, string profileName)
        {
            OnProfileSaveClick(objProfile, profileName);
        }


        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            CurrentProfileName = currentProfile;
            Profiles = profiles;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>) Profiles)[currentProfile + "_" + ProfileTypes.NetPosition.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridNetPosition.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        /// <summary>
        /// Called when user select the SquareOffOutstanding option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSquareOffOutstandingClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Called when user select the SaveAs option from the context menu.
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
                ClsCommonMethods.SaveGridDataInExcel(filePath, ui_uctlGridNetPosition);
            }
        }

        public void AddInstruments(List<string> lst)
        {
            ui_ncmbContracts.Items.Clear();
            if (lst != null)
            {
                ui_ncmbContracts.Items.Add("All");
                ui_ncmbContracts.Items.AddRange(lst.ToArray());
                ui_ncmbContracts.SelectedIndex = 0;
            }
        }

        //public void AddAccountType(List<string> lst)
        //{
        //    ui_ncmbAccountType.Items.Clear();
        //    if (lst != null)
        //    {
        //        ui_ncmbAccountType.Items.Add("All");
        //        ui_ncmbAccountType.Items.AddRange(lst.ToArray());
        //        ui_ncmbAccountType.SelectedIndex = 0;
        //    }
        //}

        public void ClearClient()
        {
            ui_ncmbAccountNo.Items.Clear();
        }

        public void AddAccountNo(List<string> lst)
        {
            ui_ncmbAccountNo.Items.Clear();
            if (lst != null)
            {
                ui_ncmbAccountNo.Items.AddRange(lst.ToArray());
                ui_ncmbAccountNo.SelectedIndex = 0;
            }
        }

        //public void AddClientName(List<string> lst)
        //{
        //    ui_ncmbClientName.Items.Clear();
        //    if (lst != null)
        //    {
        //        ui_ncmbClientName.Items.Add("All");
        //        ui_ncmbClientName.Items.AddRange(lst.ToArray());
        //        ui_ncmbClientName.SelectedIndex = 0;
        //    }
        //}

        //public void AddOminiID(List<string> lst)
        //{
        //    ui_ncmbOminiID.Items.Clear();
        //    if (lst != null)
        //    {
        //        ui_ncmbOminiID.Items.Add("All");
        //        ui_ncmbOminiID.Items.AddRange(lst.ToArray());
        //        ui_ncmbOminiID.SelectedIndex = 0;
        //    }
        //}

        //public void AddProduct(List<string> lst)
        //{
        //    ui_ncmbProduct.Items.Clear();
        //    if (lst != null)
        //    {
        //        ui_ncmbProduct.Items.Add("All");
        //        ui_ncmbProduct.Items.AddRange(lst.ToArray());
        //        ui_ncmbProduct.SelectedIndex = 0;
        //    }
        //}

        //public void AddTradingCurrency(List<string> lst)
        //{
        //    ui_ncmbTradingCurrency.Items.Clear();
        //    if (lst != null)
        //    {
        //        ui_ncmbTradingCurrency.Items.Add("All");
        //        ui_ncmbTradingCurrency.Items.AddRange(lst.ToArray());
        //        ui_ncmbTradingCurrency.SelectedIndex = 0;
        //    }
        //}

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[24];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmAccountType", "Account Type", false);
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmOmniId", "Omni Id", false);
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmClientName", "Client Name", false);
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmAccount", "Account No");
            columnsArray[3].DataPropertyName = "AccountNo";
            columnsArray[3].DefaultCellStyle = intCellStyle;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmProductType", "Product Type", false);
            columnsArray[4].DataPropertyName = "ProductType";
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmContract", "Contract");
            columnsArray[5].DataPropertyName = "Contract";
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmSeriesExpiry", "Series/Expiry");
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmStrikePrice", "Strike Price", false);
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmOptionType", "Option Type", false);
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmTradingCurrency",
                                                                "Trading Currency");
            columnsArray[9].DataPropertyName = "TradingCurrency";
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmProductName", "Product Name");
            columnsArray[10].DataPropertyName = "ProductName";
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmBuyQty", "Buy Qty.");
            columnsArray[11].DataPropertyName = "BuyQty";
            columnsArray[11].DefaultCellStyle = intCellStyle;
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "clmBuyVal", "Buy Val.");
            columnsArray[12].DataPropertyName = "BuyVal";
            columnsArray[12].DefaultCellStyle = intCellStyle;
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "clmBuyAvg", "Buy Avg.");
            columnsArray[13].DataPropertyName = "BuyAvg";
            columnsArray[13].DefaultCellStyle = intCellStyle;
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "clmSellQty", "Sell Qty.");
            columnsArray[14].DataPropertyName = "SellQty";
            columnsArray[14].DefaultCellStyle = intCellStyle;
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "clmSellVal", "Sell Val.");
            columnsArray[15].DataPropertyName = "SellVal";
            columnsArray[15].DefaultCellStyle = intCellStyle;
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "clmSellAvg", "Sell Avg.");
            columnsArray[16].DataPropertyName = "SellAvg";
            columnsArray[16].DefaultCellStyle = intCellStyle;
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "clmNetQty", "Net Qty.");
            columnsArray[17].DataPropertyName = "NetQty";
            columnsArray[17].DefaultCellStyle = intCellStyle;
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "clmNetVal", "Net Val.");
            columnsArray[18].DataPropertyName = "NetVal";
            columnsArray[18].DefaultCellStyle = intCellStyle;
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "clmNetPrice", "Net Price");
            columnsArray[19].DataPropertyName = "NetPrice";
            columnsArray[19].DefaultCellStyle = intCellStyle;
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "clmMarketPrice", "Market Price");
            columnsArray[20].DataPropertyName = "MarketPrice";
            columnsArray[20].DefaultCellStyle = intCellStyle;
            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "clmURPL", "U/PnL");
            columnsArray[21].DataPropertyName = "UR_PL";
            columnsArray[21].DefaultCellStyle = intCellStyle;
            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "clmMTMVPos", "MTMV Pos.", false);
            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "clmMTMGL", "MTM G/L", false);

            ui_uctlGridNetPosition.AddColumns(columnsArray);
        }

        #endregion   "        METHODS          "

        #region    "        EVENTS            "

        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };
        public event Action OnAccountChanged = delegate { };

        #endregion "        EVENTS            "

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlNetPosition_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
            SetLocalization();
            //Kul
            ui_uctlGridNetPosition.ColumnHeadersCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }


        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            string AccountNo = string.Empty;
            string Contract = string.Empty;
            if (ui_ncmbAccountNo.SelectedItem != null)
                AccountNo = ui_ncmbAccountNo.SelectedItem.ToString();
            if (ui_ncmbContracts.SelectedIndex > 0)
                Contract = ui_ncmbContracts.SelectedItem.ToString();
            OnApplyClick(AccountNo, Contract);
        }

        public event Action<string, string> OnApplyClick = delegate { };

      

        private void ui_uctlGridNetPosition_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

        public void AddContracts(List<string> lstContracts)
        {
            if (ui_ncmbContracts.Items != null)
            {
                ui_ncmbContracts.Items.Clear();
                ui_ncmbContracts.Items.AddRange(lstContracts.ToArray());
                ui_ncmbContracts.SelectedIndex = 0;
            }
        }

        private void ui_ncmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbAccountNo.SelectedIndex > -1)
            {
                ui_ncmbContracts.SelectedIndex = 0;

                OnAccountChanged();
            }
        }

        private void tableLayoutPanel2_VisibleChanged(object sender, EventArgs e)
        {
            if (tableLayoutPanel2.Visible)
            {
                ui_nbtnHideFilter.Text = "Hide &Filter >>";
            }
            else
            {
                ui_nbtnHideFilter.Text = "Show &Filter >>";
            }
        }
    }
}