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
    public partial class uctlMarketWatchNew : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        public Dictionary<string, DataRow> _DDRows = new Dictionary<string, DataRow>();
        private DataGridViewRow _clickedRow;
        private string _currentPortfolioName = string.Empty;
        private string _currentProfileName = string.Empty;
        private object _portfolios;
        private object _profiles;
        private static int _fntSize;
        private float _defaultFntSize = 8;
        private Color _alertTriggerColor = Color.Blue;
        private Color _downTrendColor = Color.Red;
        private string _title = "Market Watch";
        private Color _upTrendColor = Color.Green;
        private Color _viewColor = Color.White;
        private List<string> _SavedWorkSpace;

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        public static int GridFontSize
        {
            get { return _fntSize; }
            set { _fntSize = value; }
        }

        public float DefaultFontSize
        {
            get { return _defaultFntSize; }
            set { _defaultFntSize = value; }
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

        public List<string> SavedWorkSpace
        {
            get { return _SavedWorkSpace; }
            set { _SavedWorkSpace = value; }
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

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMarketWatch 
        /// </summary>        
        public uctlMarketWatchNew()
        {
            InitializeComponent();
            ui_ndgvMarketWatch.AutoGenerateColumns = false;
            DoubleBuffered = true;
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// Sets the text of the controls of the marketwatch according to corresponding localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Watch;

            ui_ndgvMarketWatch.Columns[0].HeaderText = ClsLocalizationHandler.Exchange;
            ui_ndgvMarketWatch.Columns[1].HeaderText = ClsLocalizationHandler.Market + " " +
                                                           ClsLocalizationHandler.Type;
            ui_ndgvMarketWatch.Columns[2].HeaderText = ClsLocalizationHandler.Instrument + " " +
                                                           ClsLocalizationHandler.Type;
            ui_ndgvMarketWatch.Columns[3].HeaderText = ClsLocalizationHandler.Instrument + " " +
                                                           ClsLocalizationHandler.Name;
            ui_ndgvMarketWatch.Columns[4].HeaderText = ClsLocalizationHandler.Code;
            ui_ndgvMarketWatch.Columns[5].HeaderText = ClsLocalizationHandler.Symbol;
            //NO loclization value ui_MarketWatchGrid.Columns[6].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_ndgvMarketWatch.Columns[7].HeaderText = ClsLocalizationHandler.Strike + " " +
                                                           ClsLocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[8].HeaderText = ClsLocalizationHandler.Option + " " +
                                                           ClsLocalizationHandler.Type;
            ui_ndgvMarketWatch.Columns[9].HeaderText = ClsLocalizationHandler.Scrip + " " +
                                                           ClsLocalizationHandler.Name;
            ui_ndgvMarketWatch.Columns[10].HeaderText = ClsLocalizationHandler.Status;
            //NO Lolization value ui_MarketWatchGrid.Columns[11].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_ndgvMarketWatch.Columns[12].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Back;
            //NO Lolization value ui_MarketWatchGrid.Columns[13].HeaderText = Cls.LocalizationHandler.Exchange;
            ui_ndgvMarketWatch.Columns[14].HeaderText = ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_ndgvMarketWatch.Columns[15].HeaderText = ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[16].HeaderText = ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_ndgvMarketWatch.Columns[17].HeaderText = ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[14].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[15].HeaderText = ClsLocalizationHandler.Trend + " " +
                                                            ClsLocalizationHandler.Indicator;
            ui_ndgvMarketWatch.Columns[16].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Time;
            //NO Lolization value ui_MarketWatchGrid.Columns[17].HeaderText = Cls.LocalizationHandler.Sell + " " + Cls.LocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[18].HeaderText = ClsLocalizationHandler.Volume + "(" +
                                                            ClsLocalizationHandler.In + " 000s)";
            ui_ndgvMarketWatch.Columns[19].HeaderText = ClsLocalizationHandler.Value + "(" +
                                                            ClsLocalizationHandler.In + " lacs)";
            ui_ndgvMarketWatch.Columns[20].HeaderText = "% " + ClsLocalizationHandler.Change;
            ui_ndgvMarketWatch.Columns[21].HeaderText = ClsLocalizationHandler.Average + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Price;
            ui_ndgvMarketWatch.Columns[22].HeaderText = ClsLocalizationHandler.High;
            ui_ndgvMarketWatch.Columns[23].HeaderText = ClsLocalizationHandler.Low;
            ui_ndgvMarketWatch.Columns[24].HeaderText = ClsLocalizationHandler.Open;
            ui_ndgvMarketWatch.Columns[25].HeaderText = ClsLocalizationHandler.Close;
            ui_ndgvMarketWatch.Columns[26].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_ndgvMarketWatch.Columns[27].HeaderText = ClsLocalizationHandler.Total + " " +
                                                            ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Quantity;
            ui_ndgvMarketWatch.Columns[28].HeaderText = ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_ndgvMarketWatch.Columns[29].HeaderText = "%" + ClsLocalizationHandler.OI;
            ui_ndgvMarketWatch.Columns[30].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Updated + " " +
                                                            ClsLocalizationHandler.Time;
            ui_ndgvMarketWatch.Columns[31].HeaderText = ClsLocalizationHandler.In + " " +
                                                            ClsLocalizationHandler.The + " " +
                                                            ClsLocalizationHandler.Money;
            ui_ndgvMarketWatch.Columns[32].HeaderText = ClsLocalizationHandler.Net + " " +
                                                            ClsLocalizationHandler.Change + " " +
                                                            ClsLocalizationHandler.In + " Rs";
            ui_ndgvMarketWatch.Columns[33].HeaderText = ClsLocalizationHandler.Fair + " " +
                                                            ClsLocalizationHandler.Value;
            ui_ndgvMarketWatch.Columns[34].HeaderText = ClsLocalizationHandler.Last + " " +
                                                            ClsLocalizationHandler.Traded + " " +
                                                            ClsLocalizationHandler.Quantity;
            //NO Lolization value ui_MarketWatchGrid.Columns[35].HeaderText = "%" + Cls.LocalizationHandler.OI;
            ui_ndgvMarketWatch.Columns[36].HeaderText = ClsLocalizationHandler.Lend + "/" +
                                                            ClsLocalizationHandler.Sell + " " +
                                                            ClsLocalizationHandler.Yield;
            ui_ndgvMarketWatch.Columns[37].HeaderText = ClsLocalizationHandler.Borrow + "/" +
                                                            ClsLocalizationHandler.Buy + " " +
                                                            ClsLocalizationHandler.Yield;
            ui_ndgvMarketWatch.Columns[38].HeaderText = "LPT " + ClsLocalizationHandler.Yield;
            ui_ndgvMarketWatch.Columns[39].HeaderText = ClsLocalizationHandler.High + " " +
                                                            ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_ndgvMarketWatch.Columns[40].HeaderText = ClsLocalizationHandler.Low + " " +
                                                            ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest;
            ui_ndgvMarketWatch.Columns[41].HeaderText = ClsLocalizationHandler.Price + " " +
                                                            ClsLocalizationHandler.Quotation + " " +
                                                            ClsLocalizationHandler.Unit;
            ui_ndgvMarketWatch.Columns[42].HeaderText = ClsLocalizationHandler.Tender;
            ui_ndgvMarketWatch.Columns[43].HeaderText = ClsLocalizationHandler.News + " " +
                                                            ClsLocalizationHandler.Indicator;
            ui_ndgvMarketWatch.Columns[44].HeaderText = ClsLocalizationHandler.Alert;
            ui_ndgvMarketWatch.Columns[45].HeaderText = ClsLocalizationHandler.Open + " " +
                                                            ClsLocalizationHandler.Interest + " " +
                                                            ClsLocalizationHandler.Previous + " " +
                                                            ClsLocalizationHandler.Close;
            ui_ndgvMarketWatch.Columns[46].HeaderText = "BCast " + ClsLocalizationHandler.Indicator;
        }

        /// <summary>
        /// Added items to the context menu of the grid
        /// </summary>
        public void CreateContextMenu()
        {
            var ContextMenuItems = new ToolStripMenuItem[4];
            ContextMenuItems[0] = new ToolStripMenuItem("Scrip Portfolio");
            ContextMenuItems[0].Click += OnScriptPortfolioClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Customize");
            ContextMenuItems[1].Click += OnCustomizeClick;
            ContextMenuItems[2] = new ToolStripMenuItem("Column Profile");
            ContextMenuItems[2].Click += OnColumnProfileClick;
            ContextMenuItems[3] = new ToolStripMenuItem("Load Workspace");
            ContextMenuItems[3].Click += OnLoadWorkspaceClick;
            ContextMenuItems[3].ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            ui_ndgvMarketWatch.ContextMenuStrip.ShowImageMargin = false;
            ui_ndgvMarketWatch.ContextMenuStrip.Items.AddRange(ContextMenuItems);
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
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
        }

        /// <summary>
        ///Called when user select the "load workspace" option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadWorkspaceClick(object sender, EventArgs e)
        {
            var objuctlLoadWorkSpace = new uctlSelectMarketWatch(_SavedWorkSpace);
            objuctlLoadWorkSpace.SelectedMW = CurrentPortfolioName;
            objuctlLoadWorkSpace.OnCancelClick += new Action<object, EventArgs>(objuctlLoadWorkSpace_OnCancelClick);
            objuctlLoadWorkSpace.OnApplyClick += new Action<string>(objuctlLoadWorkSpace_OnApplyClick);
            objuctlLoadWorkSpace.OnRemoveClick += new Action<string>(objuctlLoadWorkSpace_OnRemoveClick);
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlLoadWorkSpace.Width + 8, objuctlLoadWorkSpace.Height + 28);
            _objfrmDialogForm.Size = objSize;
            _objfrmDialogForm.Controls.Add(objuctlLoadWorkSpace);
            _objfrmDialogForm.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objuctlLoadWorkSpace.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            _objfrmDialogForm.TopMost = false;
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
        }

        void objuctlLoadWorkSpace_OnRemoveClick(string obj)
        {
            OnMarketWatchRemoveClick(obj);
        }

        void objuctlLoadWorkSpace_OnApplyClick(string obj)
        {
            OnMarketWatchLoadClick(obj);
            _objfrmDialogForm.DialogResult = DialogResult.OK;
        }

        void objuctlLoadWorkSpace_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
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
            objfrmColumnProfile.AddItemsToList(ui_ndgvMarketWatch);
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
            foreach (DataGridViewColumn col in ui_ndgvMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
            if (ui_ndgvMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 25)
            {
                ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //ui_ndgvMarketWatch.ui_mnuSizeToFit.Checked = false;
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

        //to record the row indexes
        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMarketWatchNew_Load(object sender, EventArgs e)
        {
            AddColumnsToGrid();
            //SetLocalization(); 

            ui_ndgvMarketWatch.ColumnWidthChanged += new DataGridViewColumnEventHandler(ui_ndgvMarketWatch_ColumnWidthChanged);
            if (CurrentProfileName != "")
            {
                ClsProfile profile =
                    ((Dictionary<string, ClsProfile>)Profiles)[CurrentProfileName + "_" + ProfileTypes.MarketWatch.ToString()];
                foreach (DataGridViewColumn col in ui_ndgvMarketWatch.Columns)
                {
                    ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                    col.DisplayIndex = colsetting.Index;
                    col.Visible = colsetting.Visible;
                }
                if (ui_ndgvMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 25)
                {
                    ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }
            }

            else
            {
                if (ui_ndgvMarketWatch.Columns.GetColumnCount(DataGridViewElementStates.Visible) <= 16)
                {
                    ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }

            }
            CreateContextMenu();
            // OnGridLoadingComplete();
            ui_ndgvMarketWatch.BackgroundColor = Color.Black;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Font = new System.Drawing.Font(ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.FontFamily.Name, _defaultFntSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            ui_ndgvMarketWatch.RowsDefaultCellStyle = dataGridViewCellStyle2;
            ui_ndgvMarketWatch.ColumnHeadersHeight = Convert.ToInt32(ui_ndgvMarketWatch.RowsDefaultCellStyle.Font.Size + 13);
            ui_ndgvMarketWatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        }

        void ui_ndgvMarketWatch_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
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
            ui_ndgvMarketWatch.Columns.Clear();
            ui_ndgvMarketWatch.Columns.AddRange(columnsArray);
        }

        /// <summary>
        /// Sets the current row click values in clickedRow variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvMarketWatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                _clickedRow = ui_ndgvMarketWatch.Rows[e.RowIndex];
        }

        private void ui_ndgvMarketWatch_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ui_ndgvMarketWatch_MouseDown(object sender, MouseEventArgs e)
        {
            OnGridMouseDown(sender, e);
        }

        private void nDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region "        EVENTS        "

        public event Action<string> OnScriptPortfolioApplyClick = delegate { };
        public event Action<string> OnScriptPortfolioModifyClick = delegate { };
        public event Action<string> OnScriptPortfolioRemoveClick = delegate { };

        public event Action<string> OnMarketWatchLoadClick = delegate { };
        public event Action<string> OnMarketWatchRemoveClick = delegate { };

        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };
        public event Action<Color, Color, Color> OnUpDownTrendColorChanged;
        public event Action<object, MouseEventArgs> OnGridMouseDown;
        #endregion "        EVENTS        "

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCustomize = new FrmCustomize(this);
            try
            {
                frmCustomize.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void ui_mnuSizeToFit_Click(object sender, EventArgs e)
        {
            if (ui_mnuSizeToFit.Checked == false)
            {
                ui_mnuSizeToFit.Checked = true;
            }
            else
            {
                ui_mnuSizeToFit.Checked = false;
            }
        }

        private void ui_mnuGrid_Click(object sender, EventArgs e)
        {
            if (ui_mnuGrid.Checked == false)
            {
                ui_mnuGrid.Checked = true;
                ui_ndgvMarketWatch.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            else
            {
                ui_mnuGrid.Checked = false;
                ui_ndgvMarketWatch.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
        }

        private void ui_mnuSizeToFit_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_mnuSizeToFit.Checked == false)
            {
                ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                ui_ndgvMarketWatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        #endregion "       METHODS           "

        private void ui_ndgvMarketWatch_KeyDown(object sender, KeyEventArgs e)
        {
            OnGridKeyDown(sender, e);
        }

        private void ui_ndgvMarketWatch_MouseClick(object sender, MouseEventArgs e)
        {
            OnGridMouseClick(sender, e);
        }

        private void ui_ndgvMarketWatch_DragEnter(object sender, DragEventArgs e)
        {
            OnGridDragEnter(sender, e);
        }

        private void ui_ndgvMarketWatch_DragDrop(object sender, DragEventArgs e)
        {
            OnGridDragDrop(sender, e);
        }

        private void ui_ndgvMarketWatch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public event Action<object, MouseEventArgs> OnGridMouseClick;
        public event Action<object, DragEventArgs> OnGridDragEnter;
        public event Action<object, DragEventArgs> OnGridDragDrop;
        public event Action<object, KeyEventArgs> OnGridKeyDown;

        private void ui_ndgvMarketWatch_DragLeave(object sender, EventArgs e)
        {

        }

    }
}
