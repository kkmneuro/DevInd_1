///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//02/01/2012	VP		    1.Added comment to properties and methods
//02/02/2012	VP		    1.Commenting of the code
//03/02/2012	VP          1.Added columnProfile menu in gridmenu and defined there functionality
//07/02/2012	VP          1.Added columns to the grid of the  control
//09/02/2012	VP          1.Correct the problem of displaying buy and sell OrderEntry form
//17/02/2012	VP          1.Define the functionlity of Customize menu 
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMarketWatch : UctlBase
    {
        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        public Dictionary<string, DataRow> _DDRows = new Dictionary<string, DataRow>();
        private DataGridViewRow _clickedRow;
        private string _currentPortfolioName = string.Empty;
        private string _currentProfileName = string.Empty;
        private object _portfolios;
        private object _profiles;
        private static int _fntSize;
        static UctlGrid _marketWatchGrid;
        #region    "        MEMBERS           "

        private Color _alertTriggerColor = Color.Blue;
        private Color _downTrendColor = Color.Red;
        private string _title = "Market Watch";
        private Color _upTrendColor = Color.Green;
        private Color _viewColor = Color.White;

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        public static int GridFontSize
        {
            get { return _fntSize; }
            set { _fntSize = value; }
        }

        //public float GridFontSize
        //{
        //    get { return _marketWatchGrid.Font.Size; }
        //    set { _marketWatchGrid.Font.Size = value; }
        //}

        [Category("My property")]
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sets and gets the current portfolioName of the market watch 
        /// </summary>
        public string CurrentPortfolioName
        {
            get { return _currentPortfolioName; }
            set { _currentPortfolioName = value; }
        }

        public string CurrentProfileName
        {
            get { return _currentProfileName; }
            set { _currentProfileName = value; }
        }

        public object Portfolios
        {
            get { return _portfolios; }
            set { _portfolios = value; }
        }

        public object Profiles
        {
            get { return _profiles; }
            set { _profiles = value; }
        }

        public DataGridViewRow ClickedRow
        {
            get { return _clickedRow; }
        }

        /// <summary>
        /// The property that set the background colour of the grid internally. This property is both gettable and settable.
        /// </summary>
        [AddCustomizeAttrs]
        public Color AlertTriggerColor
        {
            get { return _alertTriggerColor; }
            set { _alertTriggerColor = value; }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public Color ViewColor
        {
            get { return _viewColor; }
            set { _viewColor = value; }
        }

        #endregion "        PROPERTY          "

        #region "     CONSTRUCTOR    "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketWatch 
        /// </summary>
        public UctlMarketWatch()
        {
            InitializeComponent();
            _fntSize = 11;
            _marketWatchGrid = ui_uctlGridMarketWatch;
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// Sets the text of the controls of the marketwatch according to corresponding localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Watch;

            ui_uctlGridMarketWatch.Columns[0].HeaderText = ClsLocalizationHandler.Exchange;
            ui_uctlGridMarketWatch.Columns[1].HeaderText = ClsLocalizationHandler.Market + " " +
                                                           ClsLocalizationHandler.Type;
            ui_uctlGridMarketWatch.Columns[2].HeaderText = ClsLocalizationHandler.Instrument + " " +
                                                           ClsLocalizationHandler.Type;
            ui_uctlGridMarketWatch.Columns[3].HeaderText = ClsLocalizationHandler.Instrument + " " +
                                                           ClsLocalizationHandler.Name;
            ui_uctlGridMarketWatch.Columns[4].HeaderText = ClsLocalizationHandler.Code;
            ui_uctlGridMarketWatch.Columns[5].HeaderText = ClsLocalizationHandler.Symbol;
            //NO loclization value ui_MarketWatchGrid.Columns[6].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_uctlGridMarketWatch.Columns[7].HeaderText = ClsLocalizationHandler.Strike + " " +
                                                           ClsLocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[8].HeaderText = ClsLocalizationHandler.Option + " " +
                                                           ClsLocalizationHandler.Type;
            ui_uctlGridMarketWatch.Columns[9].HeaderText = ClsLocalizationHandler.Scrip + " " +
                                                           ClsLocalizationHandler.Name;
            ui_uctlGridMarketWatch.Columns[10].HeaderText = ClsLocalizationHandler.Status;
            //NO Lolization value ui_MarketWatchGrid.Columns[11].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_uctlGridMarketWatch.Columns[12].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Back;
            //NO Lolization value ui_MarketWatchGrid.Columns[13].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_uctlGridMarketWatch.Columns[14].HeaderText = ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_uctlGridMarketWatch.Columns[15].HeaderText = ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[16].HeaderText = ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_uctlGridMarketWatch.Columns[17].HeaderText = ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[14].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[15].HeaderText = ClsLocalizationHandler.Trend + " " +
                                                            ClsLocalizationHandler.Indicator;
            ui_uctlGridMarketWatch.Columns[16].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Time;
            //NO Lolization value ui_MarketWatchGrid.Columns[17].HeaderText = Cls.LocalizationHandler.Sell + " " + Cls.LocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[18].HeaderText = ClsLocalizationHandler.Volume + "(" +
                                                            ClsLocalizationHandler.In + " 000s)";
            ui_uctlGridMarketWatch.Columns[19].HeaderText = ClsLocalizationHandler.Value + "(" +
                                                            ClsLocalizationHandler.In + " lacs)";
            ui_uctlGridMarketWatch.Columns[20].HeaderText = "% " + ClsLocalizationHandler.Change;
            ui_uctlGridMarketWatch.Columns[21].HeaderText = ClsLocalizationHandler.Average + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Price;
            ui_uctlGridMarketWatch.Columns[22].HeaderText = ClsLocalizationHandler.High;
            ui_uctlGridMarketWatch.Columns[23].HeaderText = ClsLocalizationHandler.Low;
            ui_uctlGridMarketWatch.Columns[24].HeaderText = ClsLocalizationHandler.Open;
            ui_uctlGridMarketWatch.Columns[25].HeaderText = ClsLocalizationHandler.Close;
            ui_uctlGridMarketWatch.Columns[26].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_uctlGridMarketWatch.Columns[27].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_uctlGridMarketWatch.Columns[28].HeaderText = ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_uctlGridMarketWatch.Columns[29].HeaderText = "%" + ClsLocalizationHandler.OI;
            ui_uctlGridMarketWatch.Columns[30].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Updated + " " +
                                                            ClsLocalizationHandler.Time;
            ui_uctlGridMarketWatch.Columns[31].HeaderText = ClsLocalizationHandler.In + " " +
                                                            ClsLocalizationHandler.The + " " +
                                                            ClsLocalizationHandler.Money;
            ui_uctlGridMarketWatch.Columns[32].HeaderText = ClsLocalizationHandler.Net + " " +
                                                            ClsLocalizationHandler.Change + " " +
                                                            ClsLocalizationHandler.In + " Rs";
            ui_uctlGridMarketWatch.Columns[33].HeaderText = ClsLocalizationHandler.Fair + " " +
                                                            ClsLocalizationHandler.Value;
            ui_uctlGridMarketWatch.Columns[34].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Quantity;
            //NO Lolization value ui_MarketWatchGrid.Columns[35].HeaderText = "%" + Cls.LocalizationHandler.OI;
            ui_uctlGridMarketWatch.Columns[36].HeaderText = ClsLocalizationHandler.Lend + "/" +
                                                            ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Yield;
            ui_uctlGridMarketWatch.Columns[37].HeaderText = ClsLocalizationHandler.Borrow + "/" +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Yield;
            ui_uctlGridMarketWatch.Columns[38].HeaderText = "LPT " + ClsLocalizationHandler.Yield;
            ui_uctlGridMarketWatch.Columns[39].HeaderText = ClsLocalizationHandler.High + " " +
                                                            ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_uctlGridMarketWatch.Columns[40].HeaderText = ClsLocalizationHandler.Low + " " +
                                                            ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_uctlGridMarketWatch.Columns[41].HeaderText = ClsLocalizationHandler.Price + " " +
                                                            ClsLocalizationHandler.Quotation + " " +
                                                            ClsLocalizationHandler.Unit;
            ui_uctlGridMarketWatch.Columns[42].HeaderText = ClsLocalizationHandler.Tender;
            ui_uctlGridMarketWatch.Columns[43].HeaderText = ClsLocalizationHandler.News + " " +
                                                            ClsLocalizationHandler.Indicator;
            ui_uctlGridMarketWatch.Columns[44].HeaderText = ClsLocalizationHandler.Alert;
            ui_uctlGridMarketWatch.Columns[45].HeaderText = ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest + " " +
                                                            ClsLocalizationHandler.Previous + " " +
                                                            ClsLocalizationHandler.Close;
            ui_uctlGridMarketWatch.Columns[46].HeaderText = "BCast " + ClsLocalizationHandler.Indicator;
        }

        /// <summary>
        /// Called when the control is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_MarketWatchGrid_Load(object sender, EventArgs e)
        {
            CreateContextMenu();
            ui_uctlGridMarketWatch.BackgroundColor = Color.Black;
        }

        /// <summary>
        /// Added items to the context menu of the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[3];
            ContextMenuItems[0] = new ToolStripMenuItem("Scrip Portfolio");
            ContextMenuItems[0].Click += OnScriptPortfolioClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Customize");
            ContextMenuItems[1].Click += OnCustomizeClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[2].Click += OnColumnProfileClick;
            ui_uctlGridMarketWatch.ContextMenuStrip.ShowImageMargin = false;
            ui_uctlGridMarketWatch.ContextMenuStrip.Items.AddRange(ContextMenuItems);
        }

        /// <summary>
        ///Called when user select the "select Portfolio" option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnScriptPortfolioClick(object sender, EventArgs e)
        {
            var objuctlSelectPortfolio = new UctlSelectPortfolio(_portfolios);
            objuctlSelectPortfolio.SelectedPortfolio = CurrentPortfolioName;
            objuctlSelectPortfolio.OnCancelClick += objuctlSelectPortfolio_OnCancelClick;
            objuctlSelectPortfolio.OnApplyClick += objuctlSelectPortfolio_OnApplyClick;
            objuctlSelectPortfolio.OnModifyClick += objuctlSelectPortfolio_OnModifyClick;
            objuctlSelectPortfolio.OnRemoveClick += objuctlSelectPortfolio_OnRemoveClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
            _objfrmDialogForm.Size = objSize;
            _objfrmDialogForm.Controls.Add(objuctlSelectPortfolio);
            _objfrmDialogForm.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objuctlSelectPortfolio.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            _objfrmDialogForm.TopMost = false;
            //objfrmDialogForm.CancelButton= 
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
        }

        private void objuctlSelectPortfolio_OnRemoveClick(string portfilioName)
        {
            OnScriptPortfolioRemoveClick(portfilioName);
        }

        private void objuctlSelectPortfolio_OnModifyClick(string portfilioName)
        {
            OnScriptPortfolioModifyClick(portfilioName);
        }

        private void objuctlSelectPortfolio_OnApplyClick(string portfilioName)
        {
            _currentPortfolioName = portfilioName;
            OnScriptPortfolioApplyClick(portfilioName);
            _objfrmDialogForm.DialogResult = DialogResult.OK;
        }

        private void objuctlSelectPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }

        /// <summary>
        /// Displays columns profile dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColumnProfileClick(object sender, EventArgs e)
        {
            var objfrmColumnProfile = new FrmColumnProfile(ProfileTypes.MarketWatch, _profiles,
                                                           CurrentProfileName);
            objfrmColumnProfile.OnOkClick += objfrmColumnProfile_OnOkClick;
            objfrmColumnProfile.OnProfileRemoveClick += objfrmColumnProfile_OnProfileRemoveClick;
            objfrmColumnProfile.OnProfileSaveClick += objfrmColumnProfile_OnProfileSaveClick;
            objfrmColumnProfile.OnSetDefaultProfileClick += objfrmColumnProfile_OnSetDefaultProfileClick;
            objfrmColumnProfile.AddItemsToList(ui_uctlGridMarketWatch);
            objfrmColumnProfile.Text = Title + " " + objfrmColumnProfile.Text;
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
            CurrentPortfolioName = currentProfile;
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)Profiles)[currentProfile + "_" + ProfileTypes.MarketWatch.ToString()];
            foreach (DataGridViewColumn col in ui_uctlGridMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
            if (ui_uctlGridMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 25)
            {
                ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;



            }
            else
            {
                // ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.None;
                ui_uctlGridMarketWatch.ui_mnuSizeToFit.Checked = false;
            }


        }

        /// <summary>
        /// Called when user select the Customize option from the context menu. This option is used to customize the control except Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCustomizeClick(object sender, EventArgs e)
        {
            var objfrmDialogForm = new frmDialogForm();
            objfrmDialogForm.Controls.Clear();
            var objuctlMarketWatchCustomize = new UctlMarketWatchCustomize();
            objuctlMarketWatchCustomize.UpColor = UpTrendColor;
            objuctlMarketWatchCustomize.DownColor = DownTrendColor;
            objuctlMarketWatchCustomize.AlertTriggerColor = AlertTriggerColor;
            objfrmDialogForm.Controls.Add(objuctlMarketWatchCustomize);
            var objSize = new Size(objuctlMarketWatchCustomize.Width + 8,
                                   objuctlMarketWatchCustomize.Height + 28);
            objfrmDialogForm.Size = objSize;
            objuctlMarketWatchCustomize.OnOkClick += objuctlMarketWatchCustomize_OnOkClick;
            objfrmDialogForm.Text = "Customize";
            //objfrmDialogForm.Location = new Point(MousePosition.X, MousePosition.Y);
            objfrmDialogForm.StartPosition = FormStartPosition.CenterParent;
            objfrmDialogForm.TopMost = false;
            objfrmDialogForm.ShowDialog(ParentForm);
        }

        private void objuctlMarketWatchCustomize_OnOkClick(Color upTrendColor, Color downTrendColor,
                                                           Color alertTriggerColor)
        {
            OnUpDownTrendColorChanged(upTrendColor, downTrendColor, alertTriggerColor);
            UpTrendColor = upTrendColor;
            DownTrendColor = downTrendColor;
            AlertTriggerColor = alertTriggerColor;
        }

        #region "        EVENTS        "

        public event Action<string> OnScriptPortfolioApplyClick = delegate { };
        public event Action<string> OnScriptPortfolioModifyClick = delegate { };
        public event Action<string> OnScriptPortfolioRemoveClick = delegate { };
        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };

        #endregion "        EVENTS        "

        #endregion "       METHODS           "

        //to record the row indexes
        //public Dictionary<string, DataGridViewRow> _DDRows = new Dictionary<string, DataGridViewRow>();

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMarketWatch_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            //SetLocalization(); 

            ui_uctlGridMarketWatch.OnColumnWidthChange += new Action<object, DataGridViewColumnEventArgs>(ui_uctlGridMarketWatch_OnColumnWidthChange);
            if (CurrentProfileName != "")
            {
                ClsProfile profile =
                    ((Dictionary<string, ClsProfile>)Profiles)[CurrentProfileName + "_" + ProfileTypes.MarketWatch.ToString()];
                foreach (DataGridViewColumn col in ui_uctlGridMarketWatch.Columns)
                {
                    ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                    col.DisplayIndex = colsetting.Index;
                    col.Visible = colsetting.Visible;
                }
                if (ui_uctlGridMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 25)
                {
                    ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //UctlMarketWatch._marketWatchGrid.Enabled = false;


                }
                else
                {
                    ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.None;
                }
            }

            else
            {
                if (ui_uctlGridMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 16)
                {
                    ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    ui_uctlGridMarketWatch.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.None;
                }

            }

        }

        void ui_uctlGridMarketWatch_OnColumnWidthChange(object arg1, DataGridViewColumnEventArgs arg2)
        {

        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid()
        {
            var columnsArray = new DataGridViewColumn[29];
            var IntCellStyle = new DataGridViewCellStyle();
            IntCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "ClmInstrumentId", "Inst. ID", false);
            columnsArray[0].DataPropertyName = "InstrumentId";
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "ClmProductType", "ProductType", false);
            columnsArray[1].DataPropertyName = "ProductType";
            columnsArray[1].ToolTipText = "Product Type";
            columnsArray[1].Width = 80;
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "ClmULAsset", "U/LAsset", false);
            columnsArray[2].DataPropertyName = "ULAsset";
            columnsArray[2].ToolTipText = "U/L Asset";
            columnsArray[2].Width = 60;
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "ClmProductName", "Product");
            columnsArray[3].DataPropertyName = "ProductName";
            columnsArray[3].ToolTipText = "Product Name";
            columnsArray[3].Width = 80;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "ClmContractName", "Contract");
            columnsArray[4].DataPropertyName = "ContractName";
            columnsArray[4].ToolTipText = "Contract Name";
            columnsArray[4].Width = 80;
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "ClmExpiry", "Expiry");
            columnsArray[5].DataPropertyName = "Expiry";
            columnsArray[5].Width = 80;
            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "ClmStrikePrice", "Strike Price", false);
            columnsArray[6].DataPropertyName = "StrikePrice";
            columnsArray[6].ToolTipText = "Strike Price";
            columnsArray[6].Width = 80;
            columnsArray[6].DefaultCellStyle = IntCellStyle;
            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "ClmStatus", "Status", false);
            columnsArray[7].DataPropertyName = "Status";
            columnsArray[7].Width = 60;
            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "ClmPriceQuotationUnit", "PQUnit", false);
            columnsArray[8].ToolTipText = "Price Quotation Unit";
            columnsArray[8].DataPropertyName = "PriceQuotationUnit";
            columnsArray[8].DefaultCellStyle = IntCellStyle;
            columnsArray[8].Width = 50;
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "ClmBuyQty", "BID Size");
            columnsArray[9].DataPropertyName = "BuyQty";
            columnsArray[9].DefaultCellStyle = IntCellStyle;
            columnsArray[9].Width = 50;
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "ClmBuyPrice", "BID Price");
            columnsArray[10].DataPropertyName = "BuyPrice";
            columnsArray[10].DefaultCellStyle = IntCellStyle;
            columnsArray[10].Width = 70;
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "ClmSellPrice", "ASK Price");
            columnsArray[11].DataPropertyName = "SellPrice";
            columnsArray[11].DefaultCellStyle = IntCellStyle;
            columnsArray[11].Width = 70;
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "ClmSellQty", "ASK Size");
            columnsArray[12].DataPropertyName = "SellQty";
            columnsArray[12].DefaultCellStyle = IntCellStyle;
            columnsArray[12].Width = 50;
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "ClmLastUpdatedTime", "LUT", false);
            columnsArray[13].DataPropertyName = "LastUpdatedTime";
            columnsArray[13].ToolTipText = "Current Updated Time";
            columnsArray[13].Width = 60;
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "ClmLTP", "CTP");
            columnsArray[14].DataPropertyName = "LTP";
            columnsArray[14].ToolTipText = "Current Traded Price";
            columnsArray[14].DefaultCellStyle = IntCellStyle;
            columnsArray[14].Width = 70;
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "ClmNetChange", "Net Change");
            columnsArray[15].DataPropertyName = "NetChange";
            columnsArray[15].Width = 70;
            columnsArray[15].DefaultCellStyle = IntCellStyle;
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "ClmValue", "Value %", false);
            columnsArray[16].DataPropertyName = "Value";
            columnsArray[16].DefaultCellStyle = IntCellStyle;
            columnsArray[16].Width = 50;
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "ClmHigh", "High");
            columnsArray[17].DataPropertyName = "High";
            columnsArray[17].DefaultCellStyle = IntCellStyle;
            columnsArray[17].Width = 70;
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "ClmLow", "Low");
            columnsArray[18].DataPropertyName = "Low";
            columnsArray[18].DefaultCellStyle = IntCellStyle;
            columnsArray[18].Width = 70;
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "ClmOpenPrice", "Open Price");
            columnsArray[19].DataPropertyName = "OpenPrice";
            columnsArray[19].DefaultCellStyle = IntCellStyle;
            columnsArray[19].Width = 70;
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "ClmClosePrice", "Close Price");
            columnsArray[20].DataPropertyName = "ClosePrice";
            columnsArray[20].DefaultCellStyle = IntCellStyle;
            columnsArray[20].Width = 70;
            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "ClmPrevHigh", "Prev. High", false);
            columnsArray[21].DataPropertyName = "PrevHigh";
            columnsArray[21].DefaultCellStyle = IntCellStyle;
            columnsArray[21].Width = 70;
            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "ClmPrevLow", "Prev. Low", false);
            columnsArray[22].DataPropertyName = "PrevLow";
            columnsArray[22].DefaultCellStyle = IntCellStyle;
            columnsArray[22].Width = 70;
            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "ClmPrevOpen", "Prev. Open", false);
            columnsArray[23].DataPropertyName = "PrevOpen";
            columnsArray[23].DefaultCellStyle = IntCellStyle;
            columnsArray[23].Width = 70;
            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "ClmPrevClose", "Prev. Close", false);
            columnsArray[24].DataPropertyName = "PrevClose";
            columnsArray[24].DefaultCellStyle = IntCellStyle;
            columnsArray[24].Width = 70;
            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "ClmVolume", "Volume", false);
            columnsArray[25].DataPropertyName = "Volume";
            columnsArray[25].DefaultCellStyle = IntCellStyle;
            columnsArray[25].Width = 60;
            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "ClmSpecification", "Specification", false);
            columnsArray[26].DataPropertyName = "Specification";
            columnsArray[26].Width = 80;
            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "ClmFairPrice", "Fair Price", false);
            columnsArray[27].DataPropertyName = "FairPrice";
            columnsArray[27].DefaultCellStyle = IntCellStyle;
            columnsArray[27].Width = 70;
            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "clmImage", "Trend", new DataGridViewImageColumn());
            columnsArray[28].Width = 60;
            columnsArray[28].DefaultCellStyle.NullValue = null;
            columnsArray[28].Visible = false;
            foreach (DataGridViewColumn column in columnsArray)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            ui_uctlGridMarketWatch.AddColumns(columnsArray);
        }

        /// <summary>
        /// Sets the current row click values in clickedRow variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_uctlGridMarketWatch_OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                _clickedRow = ui_uctlGridMarketWatch.Rows[e.RowIndex];
        }

        private void ui_uctlGridMarketWatch_OnMouseClick(object obj)
        {
            //DataGridViewRow clickRow = ((uctlGrid)obj).SelectedRows[0];
        }

        public event Action<Color, Color, Color> OnUpDownTrendColorChanged;

        private void ui_uctlGridMarketWatch_OnGridMouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        public event Action<object, MouseEventArgs> OnGridMouseDown;

        private void ui_uctlGridMarketWatch_OnCellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ui_uctlGridMarketWatch_OnGridMouseOver(object arg1, EventArgs arg2)
        {
            //DataGridView.HitTestInfo hitInfo = ui_uctlGridMarketWatch.ui_ndgvGrid.HitTest(MousePosition.X, MousePosition.Y);
        }

        private void ui_uctlGridMarketWatch_OnGridCellEnter(object arg1, DataGridViewCellEventArgs arg2)
        {
            //if (arg2.RowIndex > -1 && ui_uctlGridMarketWatch.ui_ndgvGrid.Rows.Count > arg2.RowIndex)
            //{
            //    ui_uctlGridMarketWatch.ui_ndgvGrid.ClearSelection();
            //    ui_uctlGridMarketWatch.ui_ndgvGrid.Rows[arg2.RowIndex].Selected = true;
            //}
        }
    }
}