using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;
using System.ComponentModel;

namespace CommonLibrary.UserControls
{
    public partial class UctlSurveillance : UctlBase
    {
        public Dictionary<long, DataGridViewRow> _DDRows = new Dictionary<long, DataGridViewRow>();
        private string _title = "Serveillance";
        private string _currentProfileName = string.Empty;
        private object _profiles;

        public string CurrentProfileName
        {
            get { return _currentProfileName; }
            set { _currentProfileName = value; }
        }

        public object Profiles
        {
            get { return _profiles; }
            set { _profiles = value; }
        }
        [Category("My property")]
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public UctlSurveillance()
        {
            InitializeComponent();
        }


        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };

        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[1];

            ContextMenuItems[0] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[0].Click += OnColumnProfileClick;
            ui_uctlGridSurveillance.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridSurveillance.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.Serveillance, _profiles , CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileRemoveClick +=objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick +=objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridSurveillance);
            objfrmColumnProfile.Text = this.Title + " " + objfrmColumnProfile.Text;
            objfrmColumnProfile.StartPosition = FormStartPosition.CenterParent;
            objfrmColumnProfile.ShowInTaskbar = false;
            objfrmColumnProfile.BringToFront();
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

        /// <summary>
        /// Applys the users column settings to the grid
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="currentProfile"></param>
        private void objfrmColumnProfile_OnOkClick(object profiles, string currentProfile)
        {
            Profiles = profiles;
            CurrentProfileName = currentProfile;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)Profiles)[currentProfile + "_" + ProfileTypes.Serveillance.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridSurveillance.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void uctlGrid1_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            CreateContextMenu();
        }

        private void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[25];
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmAccountType", "Account Type", false);
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmOmniId", "Omni Id", false);
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmClientName", "Client Name", false);
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmAccount", "Account No");
            columnsArray[3].DataPropertyName = "AccountNo";
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmProductType", "Product Type", false);
            columnsArray[4].DataPropertyName = "ProductType";
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmContract", "Contract");
            columnsArray[5].DataPropertyName = "Contract";
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmSeriesExpiry", "Series/Expiry");
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmStrikePrice", "Strike Price", false);
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmOptionType", "Option Type", false);
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmTradingCurrency","Trading Currency",false);
            columnsArray[9].DataPropertyName = "TradingCurrency";
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmProductName", "Product Name");
            columnsArray[10].DataPropertyName = "ProductName";
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmBuyQty", "Buy Qty.");
            columnsArray[11].DataPropertyName = "BuyQty";
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "clmBuyVal", "Buy Val.");
            columnsArray[12].DataPropertyName = "BuyVal";
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "clmBuyAvg", "Buy Avg.");
            columnsArray[13].DataPropertyName = "BuyAvg";
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "clmSellQty", "Sell Qty.");
            columnsArray[14].DataPropertyName = "SellQty";
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "clmSellVal", "Sell Val.");
            columnsArray[15].DataPropertyName = "SellVal";
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "clmSellAvg", "Sell Avg.");
            columnsArray[16].DataPropertyName = "SellAvg";
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "clmNetQty", "Net Qty.");
            columnsArray[17].DataPropertyName = "NetQty";
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "clmNetVal", "Net Val.");
            columnsArray[18].DataPropertyName = "NetVal";
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "clmNetPrice", "Net Price");
            columnsArray[19].DataPropertyName = "NetPrice";
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "clmMarketPrice", "Market Price");
            columnsArray[20].DataPropertyName = "MarketPrice";
            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "clmURPL", "U/PnL");
            columnsArray[21].DataPropertyName = "UR_PL";
            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "clmMTMVPos", "MTMV Pos.", false);
            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "clmMTMGL", "MTM G/L", false);
            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "clmColor", "Color", false);
            columnsArray[24].DataPropertyName = "Color";
            ui_uctlGridSurveillance.Columns.AddRange(columnsArray);
        }

        public void AddSide(string[] Side)
        {
            ui_ncmbSide.Items.Clear();
            ui_ncmbSide.Items.AddRange(Side);
            ui_ncmbSide.Items.Insert(0, "All");
            ui_ncmbSide.SelectedIndex = 0;
        }
    }
}