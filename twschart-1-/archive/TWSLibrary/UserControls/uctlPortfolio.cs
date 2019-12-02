//<Revision History>

//Date : 03/01/2012
//Author Name : Namo Narayan Singh
//Description : Properties are redefined

//</Revision History>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlPortfolio : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly string _expiryDates = string.Empty;
        private readonly string _instrumentNames = string.Empty;
        private readonly string _optionType = string.Empty;
        private readonly string _series = string.Empty;
        private readonly string _strikePrice = string.Empty;
        public string SelectedPortfolio;
        private string _portfolioName = string.Empty;
        public Dictionary<string, ClsPortfolio> _portfolios;
        private string _symbol = string.Empty;
        private string _title = "Portfolio";
        public object objportfolio;

        #endregion    "        MEMBERS           "

        #region  "       PROPERTIES         "

        /// <summary>
        /// This property sets the title of the user control which is used by the container form to set its title. This property is both settable and gettable
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// To display searched items in grid
        /// </summary>
        public DataTable SearchedProducts { get; set; }

        ///// <summary>
        ///// To display selected portfolio products in grid
        ///// </summary>
        //public DataTable PortfolioProducts
        //{
        //    get
        //    {
        //        return _portfolioProducts;
        //    }
        //    set
        //    {
        //        _portfolioProducts = value;
        //    }
        //}

        /// <summary>
        /// To gets Portfolio name in the combo box
        /// </summary>
        public string PortfolioName
        {
            get { return _portfolioName; }
        }

        /// <summary>
        /// To get Instrument name in the combo box
        /// </summary>
        public string InstrumentNames
        {
            get { return _instrumentNames; }
        }

        /// <summary>
        /// gets the symbol name in the Portfolio control
        /// </summary>
        public string Symbol
        {
            get { return ui_ncmbContract.Text; }

            set { ui_ncmbContract.Text = value; }
        }

        /// <summary>
        ///gets the expiry date in the Portfolio control
        /// </summary>
        public string ExpiryDates
        {
            get { return _expiryDates; }
        }

        /// <summary>
        /// This property gets the selected instrument name from ui_ncmbStrikePrice combobox. This property is both settable and gettable
        /// </summary>
        public string StrikePrice
        {
            get { return _strikePrice; }
        }

        /// <summary>
        /// This property gets the text of series comboBox(ui_ncmbSeries )
        /// </summary>
        public string Series
        {
            get { return _series; }
        }

        /// <summary>
        /// This property gets the selected instrument name from ui_ncmbOptType combobox . This property is both settable and gettable
        /// </summary>
        public string OptionType
        {
            get { return _optionType; }
        }

        #endregion   "        PROPERTIES           "

        #region "       CONSTRUCTOR        "

        /// <summary>
        /// Constructor for initializing the components of the uctlPortfolio 
        /// </summary>
        /// <param name="obj"></param>
        public UctlPortfolio()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constructor for initializing the components of the uctlPortfolio with customized settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlPortfolio(object customizeSettings)
        {
        }

        #endregion "       CONSTRUCTOR        "

        #region  "         METHODS          "

        /// <summary>
        /// Sets the text of controls corresponding to localization value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Portfolio;

            ui_lblPortfolioName.Text = ClsLocalizationHandler.Portfolio + " " + ClsLocalizationHandler.Name + " :";
            ui_nbtnRemovePortfoilo.Text = ClsLocalizationHandler.Remove + " " + ClsLocalizationHandler.Portfolio;
            ui_nbtnRemove.Text = ClsLocalizationHandler.Remove + " " + ClsLocalizationHandler.Portfolio;
            ui_ngbeProductSearch.HeaderItem.Text = ClsLocalizationHandler.Product + " " + ClsLocalizationHandler.Search;
            ui_lblProductType.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name;
            ui_lblSeries.Text = ClsLocalizationHandler.Series;
            ui_lblContract.Text = ClsLocalizationHandler.Symbol;
            ui_lblExpiryDate.Text = ClsLocalizationHandler.Expiry + " " + ClsLocalizationHandler.Date;
            ui_lblStrikePrice.Text = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ui_lblOptType.Text = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ui_nbtnSearch.Text = ClsLocalizationHandler.Search;

            ui_lblSelected.Text = ClsLocalizationHandler.Selected + " :";
            ui_nbtnAdd.Text = ClsLocalizationHandler.Add;
            ui_nbtnRemove.Text = ClsLocalizationHandler.Remove;
            ui_nbtnSave.Text = ClsLocalizationHandler.Save + "..";
            ui_nbtnClose.Text = ClsLocalizationHandler.Close;
        }

        //public void SetPortfoio(Dictionary<string,object> _portfolio)
        //{
        //    _portfolioProducts = _portfolio;
        //}

        #endregion    "      METHODS       "

        private void ui_nbtnClose_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        private void ui_npnlPortfolio_Click(object sender, EventArgs e)
        {
        }

        private void uctlPortfolio_Load(object sender, EventArgs e)
        {
            ui_ncmbExpiryDate.SelectedIndex = 0;
            ui_ncmbProductType.SelectedIndex = 0;
            ui_ncmbGateway.SelectedIndex = 0;
            ui_ncmbExchange.SelectedIndex = 0;
            ui_ncmbPortfolioName.SelectedIndex = 0;

            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var columns = new DataGridViewColumn[9];
            columns[0] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "InstrumentId", "Inst. Id",
                                                           false);
            columns[1] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Gateway", "Gateway");
            columns[2] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "ProductType", "ProductType");
            columns[3] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Product", "Product Name");
            columns[4] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Contract", "Contract Name");
            columns[5] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Series_Expiry",
                                                           "Series/Expiry");
            columns[6] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "StrikePrice",
                                                           "Strike Price");
            columns[6].DefaultCellStyle = intCellStyle;
            columns[7] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "OptionType", "Option Type");
            columns[8] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "TradingCurrency",
                                                           "TradingCurrency");
            var columns1 = new DataGridViewColumn[9];
            columns1[0] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "InstrumentId", "Inst. Id",
                                                            false);
            columns1[1] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Gateway", "Gateway");
            columns1[2] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "ProductType",
                                                            "ProductType");
            columns1[3] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Product", "Product Name");
            columns1[4] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Contract", "Contract Name");
            columns1[5] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "Series_Expiry",
                                                            "Series/Expiry");
            columns1[6] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "StrikePrice",
                                                            "Strike Price");
            columns1[6].DefaultCellStyle = intCellStyle;
            columns1[7] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "OptionType", "Option Type");
            columns1[8] = ClsCommonMethods.CreateGridColumn(new DataGridViewTextBoxColumn(), "TradingCurrency",
                                                            "TradingCurrency");
            ui_uctlGridPortfolioProduct.AddColumns(columns1);
            ui_uctlGridPortfolioSelectedProduct.AddColumns(columns);
            _portfolios = (Dictionary<string, ClsPortfolio>)objportfolio;
            if (_portfolios != null)
            {
                foreach (string key in _portfolios.Keys)
                {
                    ui_ncmbPortfolioName.Items.Add(key);
                }
                ui_nbtnRemovePortfoilo.Enabled = true;
            }
            else
            {
                ui_nbtnRemovePortfoilo.Enabled = false;
            }
            if (SelectedPortfolio != string.Empty)
            {
                for (int i = 0; i < ui_ncmbPortfolioName.Items.Count; i++)
                {
                    if (ui_ncmbPortfolioName.Items[i].ToString() == SelectedPortfolio)
                        ui_ncmbPortfolioName.SelectedIndex = i;
                }
                ui_ntxtPortfolioName.Text = SelectedPortfolio;
            }
            //SetLocalization();
        }


        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            OnSearchClick(sender, e);
        }

        private void ui_ntxtSymbol_Validating(object sender, CancelEventArgs e)
        {
            OnSymbolValidating(sender, e);
        }


        private void ui_nbtnSave_Click(object sender, EventArgs e)
        {
            if (ui_ntxtPortfolioName.Text != string.Empty)
            {
                var obj = new ClsPortfolio();
                obj.PortfolioName = PortfolioName;
                //obj.Products.Add();

                foreach (DataGridViewRow dr in ui_uctlGridPortfolioSelectedProduct.Rows)
                {
                    string instrumentId = string.Empty;
                    string productType = string.Empty;
                    string productName = string.Empty;
                    string contract = string.Empty;
                    string series_Expiry = string.Empty;
                    string strikePrice = string.Empty;
                    string optionType = string.Empty;
                    string tradingCurrency = string.Empty;

                    if (dr.Cells["InstrumentId"].Value != null)
                        instrumentId = dr.Cells["InstrumentId"].Value.ToString();
                    if (dr.Cells["TradingCurrency"].Value != null)
                        tradingCurrency = dr.Cells["TradingCurrency"].Value.ToString();
                    if (dr.Cells["ProductType"].Value != null)
                        productType = dr.Cells["ProductType"].Value.ToString();
                    if (dr.Cells["Product"].Value != null)
                        productName = dr.Cells["Product"].Value.ToString();
                    if (dr.Cells["Contract"].Value != null)
                        contract = dr.Cells["Contract"].Value.ToString();
                    if (dr.Cells["Series_Expiry"].Value != null)
                        series_Expiry = dr.Cells["Series_Expiry"].Value.ToString();
                    if (dr.Cells["StrikePrice"].Value != null)
                        strikePrice = dr.Cells["StrikePrice"].Value.ToString();
                    if (dr.Cells["OptionType"].Value != null)
                        optionType = dr.Cells["OptionType"].Value.ToString();
                    ClsContracts objProduct = new ClsContracts(instrumentId, productType, productName,
                                                      contract, series_Expiry, strikePrice, optionType, tradingCurrency);

                    obj.AddProduct(objProduct.InstrumentId, objProduct);
                }
                if (_portfolios == null)
                    _portfolios = new Dictionary<string, ClsPortfolio>();
                if (!_portfolios.ContainsKey(PortfolioName))
                    _portfolios.Add(PortfolioName, obj);
                else
                    _portfolios[PortfolioName] = obj;
                OnSaveClick(_portfolios, PortfolioName);
            }
            else
            {
                MessageBox.Show("Please type the portfolio name.");
                ui_ntxtPortfolioName.Focus();
            }
        }

        private void ui_nbtnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in ui_uctlGridPortfolioSelectedProduct.SelectedRows)
            {
                ui_uctlGridPortfolioSelectedProduct.Rows.Remove(dgvr);
            }
        }

        private void ui_nbtnAdd_Click(object sender, EventArgs e)
        {
            var InstrumentIds = new List<string>();
            foreach (DataGridViewRow dgr in ui_uctlGridPortfolioSelectedProduct.Rows)
            {
                InstrumentIds.Add(dgr.Cells["InstrumentId"].Value.ToString());
            }
            foreach (DataGridViewRow dgvr in ui_uctlGridPortfolioProduct.SelectedRows)
            {
                var r = dgvr.Clone() as DataGridViewRow;
                if (!InstrumentIds.Contains(dgvr.Cells["InstrumentId"].Value.ToString()))
                {
                    foreach (DataGridViewCell cell in dgvr.Cells)
                    {
                        r.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    ui_uctlGridPortfolioSelectedProduct.Rows.Add(r);
                }
            }
            ui_uctlGridPortfolioSelectedProduct.ui_ndgvGrid.Sort(ui_uctlGridPortfolioSelectedProduct.Columns["Contract"], ListSortDirection.Ascending);
        }


        private void ui_nbtnRemovePortfoilo_Click(object sender, EventArgs e)
        {
            if (ui_ncmbPortfolioName.SelectedIndex > -1)
            {
                if (
                    ClsCommonMethods.ShowMessageBox("Are you sure to remove the selected portfolio?")
                                     == DialogResult.Yes)
                {
                    _portfolios.Remove(ui_ncmbPortfolioName.SelectedItem.ToString());
                    ui_ncmbPortfolioName.Items.Remove(ui_ncmbPortfolioName.SelectedItem);
                    ui_ntxtPortfolioName.Text = string.Empty;
                    ui_uctlGridPortfolioSelectedProduct.Rows.Clear();
                    OnRemovePortfolioClick(_portfolios);
                }
            }
            else
            {
                if (ui_ncmbPortfolioName.Items.Count > 0)
                {
                    ClsCommonMethods.ShowInformation("Please select the portfolio to remove.");
                    ui_ncmbPortfolioName.Focus();
                }
                else
                {
                    ClsCommonMethods.ShowInformation("There is no portfolio to remove!!");
                }
            }
        }

        private void ui_ncmbPortfolioName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ntxtPortfolioName.Text = ui_ncmbPortfolioName.Text;
            ui_uctlGridPortfolioSelectedProduct.Rows.Clear();
            ClsPortfolio _portfolio = _portfolios[ui_ntxtPortfolioName.Text];
            foreach (string instrumentId in _portfolio.Products.Keys)
            {
                ClsContracts contract = _portfolio.Products[instrumentId];
                ui_uctlGridPortfolioSelectedProduct.Rows.Add();
                int lastrow = ui_uctlGridPortfolioSelectedProduct.Rows.Count - 1;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["InstrumentId"].Value = instrumentId;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["Gateway"].Value = instrumentId.Split('_')[0];
                //ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["Gateway"].Value = "FutureX";
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["ProductType"].Value = contract.ProductType;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["Product"].Value = contract.ProductName;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["Contract"].Value = contract.Contract;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["Series_Expiry"].Value = contract.SeriesExpiry;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["StrikePrice"].Value = contract.StrikePrice;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["OptionType"].Value = contract.OptionType;
                ui_uctlGridPortfolioSelectedProduct.Rows[lastrow].Cells["TradingCurrency"].Value =
                    contract.TradingCurrency;
            }
            ui_uctlGridPortfolioSelectedProduct.ui_ndgvGrid.Sort(ui_uctlGridPortfolioSelectedProduct.Columns["Contract"], ListSortDirection.Ascending);
        }


        private void ui_ntxtPortfolioName_TextChanged(object sender, EventArgs e)
        {
            _portfolioName = ui_ntxtPortfolioName.Text;
        }

        private void ui_ntxtSymbol_TextChanged(object sender, EventArgs e)
        {
            OnSymbolTextChanged(sender, e);
        }

        private void ui_ncmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedSeriesChanged(sender, e);
        }

        private void ui_ncmbExpiryDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnExpiryDateSelected(sender, e);
        }

        private void ui_ncmbStrikePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedStrikePriceChanged(sender, e);
        }

        private void ui_ncmbOPtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedOptTypesChanged(sender, e);
        }

        public void ClearExpiryDates()
        {
            ui_ncmbExpiryDate.Items.Clear();
        }

        public void AddExpiryDate(string expiryDate)
        {
            //if (ui_ncmbExpiryDate.Items.Count == 0)
            //    ui_nbtnSearch.Enabled = true;
            ui_ncmbExpiryDate.Items.Add(expiryDate);
        }

        private void ui_uctlGridPortfolioSelectedProduct_OnRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRemoveSaveButton();
        }

        private void SetRemoveSaveButton()
        {
            if (ui_uctlGridPortfolioSelectedProduct.Rows.Count > 0)
            {
                ui_nbtnRemove.Enabled = true;
                ui_nbtnSave.Enabled = true;
            }
            else
            {
                ui_nbtnRemove.Enabled = false;
                ui_nbtnSave.Enabled = false;
            }
        }

        private void ui_uctlGridPortfolioSelectedProduct_OnRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRemoveSaveButton();
        }

        private void ui_ncmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedProductChanged(sender, e);
        }

        private void ui_ncmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbGateway.SelectedIndex > 0)
                OnSelectedProviderChanged(sender, e);
        }

        private void ui_ncmbExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbExchange.SelectedItem != null && ui_ncmbExchange.SelectedItem.ToString() != "---SELECT---")
                OnSelectedExchangeChanged(sender, e);
        }

        private void ui_ntxtContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnContractTyped(sender, e);
            }
        }

        #region    "      EVENTS        "

        public event Action<object, EventArgs> OnCancelClick = delegate { };
        public event Action<object, EventArgs> OnSearchClick = delegate { };
        public event Action<object, string> OnSaveClick = delegate { };
        public event Action<object, EventArgs> OnRemoveClick = delegate { };
        public event Action<object> OnRemovePortfolioClick = delegate { };
        public event Action<object, EventArgs> OnSelectedProductTypeChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedProductChanged = delegate { };
        public event Action<object, EventArgs> OnSymbolValidating = delegate { };
        public event Action<object, EventArgs> OnSymbolValidated = delegate { };
        public event Action<object, EventArgs> OnExpiryDateSelected = delegate { };
        public event Action<object, EventArgs> OnSymbolTextChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedSeriesChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedStrikePriceChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedOptTypesChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedProviderChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedExchangeChanged = delegate { };
        public event Action<object, EventArgs> OnContractTyped = delegate { };

        #endregion "      EVENTS        "
    }
}