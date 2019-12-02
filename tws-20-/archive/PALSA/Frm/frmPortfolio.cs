///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//17/01/2012	VP          Designing and Coding of form	
//18/01/2012	VP		    Commenting of Code
//02/02/2012	VP		    1.Commenting of the code
//16/02/2012	VP		    1.Code for closing of form on Escape key
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TWS.Cls;

namespace TWS.Frm
{
    /// <summary>
    /// Code for portfolio dialog
    /// </summary>
    public partial class frmPortfolio : frmBase
    {
        #region    "      MEMBERS      "

        public static object _obj;
        private string _userCode = string.Empty;
        //string selectedGateway = "ECXS";
        string selectedGateway = "ECX";
        //private string DefaultGateway = "FutureX";
        private string DefaultGateway = "ECXS";
        #endregion "      MEMBERS      "

        #region    "   CONSTRUCTORS    "

        /// <summary>
        /// Constructor for initilizing the  
        /// </summary>
        public frmPortfolio(object obj, string portfolioname, string userCode)
        {
            InitializeComponent();
            Text = ui_uctlPortfolio.Title;
            _obj = obj;
            _userCode = userCode;
            ui_uctlPortfolio.objportfolio = _obj;
            ui_uctlPortfolio.SelectedPortfolio = portfolioname;
        }

        #endregion "   CONSTRUCTORS    "

        #region    "      METHODS      "

        public event Action<string> OnSavePortfolio = delegate { };

        /// <summary>
        /// Called when form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPortfolio_Load(object sender, EventArgs e)
        {
            Text = ui_uctlPortfolio.Title;
            TopMost = true;
            ui_uctlPortfolio.OnCancelClick += ui_uctlPortfolio_OnCancelClick;
            ui_uctlPortfolio.OnSaveClick += ui_uctlPortfolio_OnSaveClick;
            ui_uctlPortfolio.OnContractTyped += ui_uctlPortfolio_OnContractTyped;
            ui_uctlPortfolio.ui_ncmbGateway.Enabled = false;
            ui_uctlPortfolio.ui_ncmbProductType.SelectedIndexChanged -= new System.EventHandler(ui_uctlPortfolio_OnSelectedProductTypeChanged);
            ui_uctlPortfolio.ui_ncmbProductType.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys.ToArray());
            ui_uctlPortfolio.ui_ncmbProductType.SelectedIndex = 0;
            ui_uctlPortfolio.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(ui_uctlPortfolio_OnSelectedProductTypeChanged);

            ui_uctlPortfolio.ui_ncmbProduct.Items.Insert(0, "--SELECT--");
            ui_uctlPortfolio.ui_ncmbProduct.SelectedIndex = 0;

            foreach (string PrdctType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
            {
                try
                {
                    foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType].Keys)
                    {
                        try
                        {
                            foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType][prdct])
                            {
                                try
                                {
                                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                    {
                                        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];

                                        //foreach (string key in Symbol.getKey(instspec).Where(key => selectedGateway == Symbol.GetSymbol(key).Gateway || selectedGateway == "---SELECT---"))
                                        foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                        {
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                                            int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                                            //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = PrdctType;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = prdct;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbl;
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = ClsGlobal.GetDateTime(instspec.ExpiryDate);
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                                        }
                                    }

                                }
                                catch (Exception)
                                {

                                }
                            }

                        }
                        catch (Exception)
                        {

                        }

                    }

                }
                catch (Exception)
                {

                }
            }
            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.ui_ndgvGrid.Sort(ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Columns["Contract"], ListSortDirection.Ascending);
        }

        /// <summary>
        /// Called when cancel button clicked
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void ui_uctlPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            Close();
        }

        #endregion "      METHODS      "

        /// <summary>
        /// Saves the portfolio settings
        /// </summary>
        /// <param name="portfolio"></param>
        private void ui_uctlPortfolio_OnSaveClick(object portfolio, string portfolioName)
        {
            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetPortfolioFileName(_userCode));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetPortfolioFileName(_userCode), FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, portfolio);
            streamWrite.Close();
            //this.DialogResult = DialogResult.Yes;
            try
            {
                OnSavePortfolio(portfolioName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ui_uctlPortfolio_OnContractTyped(object arg1, EventArgs arg2)
        {
            if (!ui_uctlPortfolio.ui_ncmbGateway.Items.Contains(DefaultGateway))
            {
                ui_uctlPortfolio.ui_ncmbGateway.Items.Add(DefaultGateway);
            }
        }

        private void ui_uctlPortfolio_OnSearchClick(object arg1, EventArgs arg2)
        {
            try
            {
                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Clear();
                if (ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString() == "---SELECT---")
                {
                    foreach (string PrdctType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                    {
                        try
                        {
                            if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(PrdctType))
                            {
                                foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType].Keys)
                                {
                                    try
                                    {
                                        foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType][prdct])
                                        {
                                            try
                                            {
                                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                                {
                                                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                    //foreach (string key in Symbol.getKey(instspec).Where(key => selectedGateway == Symbol.GetSymbol(key).Gateway || selectedGateway == "---SELECT---"))
                                                    foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                    {
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                                                        int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                                                        //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = PrdctType;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = prdct;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbl;
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                                                    }
                                                }

                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {

                                    }

                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                else if (ui_uctlPortfolio.ui_ncmbProductType.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString() != "---SELECT---" &&
                         (ui_uctlPortfolio.ui_ncmbProduct.Text == string.Empty ||
                          ui_uctlPortfolio.ui_ncmbProduct.SelectedItem.ToString() == "---SELECT---"))
                {
                    string productType = ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString();
                    List<string> products = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].Keys.ToList();
                    foreach (string product in products)
                    {
                        List<string> symbols = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product];
                        foreach (string symbol in symbols)
                        {
                            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbol];
                            List<string> keys = Symbol.getKey(instspec);
                            foreach (string key in keys.Where(key => key != string.Empty && (Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---")))
                            {
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                                int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                                //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = productType;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = product;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbol;
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                            }
                        }
                    }
                }
                else if (ui_uctlPortfolio.ui_ncmbProductType.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbProduct.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString() != "---SELECT---" &&
                         ui_uctlPortfolio.ui_ncmbProduct.SelectedItem.ToString() != "---SELECT---" &&
                         ui_uctlPortfolio.ui_ncmbContract.Text != string.Empty)
                {
                    string productType = ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString();
                    string product = ui_uctlPortfolio.ui_ncmbProduct.SelectedItem.ToString();
                    List<string> symbols = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product];
                    foreach (string symbol in symbols)
                    {
                        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbol];
                        List<string> keys = Symbol.getKey(instspec);
                        foreach ( string key in keys.Where(key => key != string.Empty && (Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---")))
                        {
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                            int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                            //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = productType;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = product;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbol;
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                        }
                    }
                }
                else if (ui_uctlPortfolio.ui_ncmbProductType.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbProduct.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString() != "---SELECT---" &&
                         ui_uctlPortfolio.ui_ncmbProduct.SelectedItem.ToString() != "---SELECT---" &&
                         ui_uctlPortfolio.ui_ncmbContract.Text == string.Empty && ui_uctlPortfolio.ui_ncmbGateway.SelectedItem != null &&
                         ui_uctlPortfolio.ui_ncmbGateway.SelectedItem.ToString() != "---SELECT---")
                {
                    string productType = ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString();
                    string product = ui_uctlPortfolio.ui_ncmbProduct.SelectedItem.ToString();
                    //string gateway = ui_uctlPortfolio.ui_ncmbGateway.SelectedItem.ToString();
                    List<string> symbols = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product];
                    foreach (string symbol in symbols)
                    {
                        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbol];
                        List<string> keys = Symbol.getKey(instspec);
                        foreach (string key in keys)
                        {
                            if (key != string.Empty)
                            {
                                if (Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()))
                                {
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                                    int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                                    //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = productType;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = product;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbol;
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                                }
                            }
                        }
                    }
                }

                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.ui_ndgvGrid.Sort(ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Columns["Contract"], ListSortDirection.Ascending);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void ui_uctlPortfolio_OnRemovePortfolioClick(object _portfolio)
        {
            _obj = _portfolio;
            ui_uctlPortfolio_OnSaveClick(_portfolio, "");
        }


        private void ui_uctlPortfolio_OnExpiryDateSelected(object arg1, EventArgs arg2)
        {
        }

        private void ui_uctlPortfolio_OnSelectedProductTypeChanged(object arg1, EventArgs arg2)
        {
            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Clear();
            ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged -= Ui_ncmbContract_SelectedIndexChanged;
            ui_uctlPortfolio.ui_ncmbProduct.SelectedIndexChanged -= ui_uctlPortfolio_OnSelectedProductChanged;
            ui_uctlPortfolio.ui_ncmbContract.Items.Clear();
            ui_uctlPortfolio.ui_ncmbProduct.Items.Clear();
            if (ui_uctlPortfolio.ui_ncmbProductType.Text.Trim().Contains("SELECT"))
            {
                ui_uctlPortfolio.ui_ncmbGateway.Enabled = true;
            }
            else
            {
                if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()))
                {
                    string[] products = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString()].Keys.ToArray();
                    ui_uctlPortfolio.ui_ncmbProduct.Items.AddRange(products);
                    foreach (var prdct in products)
                    {
                        try
                        {
                            foreach (var symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString()][prdct])
                            {
                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                {
                                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                    foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                    {
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                                        int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                                        //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString();
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = prdct;
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbl;
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                                        ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = instspec.TradingCurrency;
                                    }
                                }
                            }

                        }
                        catch (Exception)
                        {

                        }
                    }

                }
            }

            ui_uctlPortfolio.ui_ncmbProduct.Items.Insert(0, "--SELECT--");
            ui_uctlPortfolio.ui_ncmbProduct.SelectedIndex = 0;
            ui_uctlPortfolio.ui_ncmbContract.Items.Insert(0, "--SELECT--");
            ui_uctlPortfolio.ui_ncmbContract.SelectedIndex = 0;
            ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged += Ui_ncmbContract_SelectedIndexChanged;
            ui_uctlPortfolio.ui_ncmbProduct.SelectedIndexChanged += ui_uctlPortfolio_OnSelectedProductChanged;
            ui_uctlPortfolio.ui_uctlGridPortfolioProduct.ui_ndgvGrid.Sort(ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Columns["Contract"], ListSortDirection.Ascending);
        }


        private void ui_uctlPortfolio_OnSelectedOptTypesChanged(object arg1, EventArgs arg2)
        {
        }


        private void ui_uctlPortfolio_OnSymbolTextChanged(object arg1, EventArgs arg2)
        {
        }

        private void frmPortfolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ui_uctlPortfolio_OnSelectedProductChanged(object arg1, EventArgs arg2)
        {
            try
            {
                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Clear();
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged -= Ui_ncmbContract_SelectedIndexChanged;
                ui_uctlPortfolio.ui_ncmbContract.Items.Clear();

                if (ui_uctlPortfolio.ui_ncmbProduct.Text.Trim().Contains("SELECT"))
                {
                    if (ui_uctlPortfolio.ui_ncmbProductType.Text.Trim().Contains("SELECT"))
                    {
                        foreach (string PrdctType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                        {
                            try
                            {
                                foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType].Keys)
                                {
                                    try
                                    {
                                        foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType][prdct])
                                        {
                                            try
                                            {
                                                ui_uctlPortfolio.ui_ncmbContract.Items.Add(symbl);
                                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                                {
                                                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                    foreach (string key in Symbol.getKey(instspec).Where(key =>Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                    {
                                                        AddRowToGrid(key, prdct, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {

                                    }

                                }

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    else
                    {
                        if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()))
                        {
                            foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()].Keys)
                            {
                                try
                                {
                                    foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()][prdct])
                                    {
                                        try
                                        {
                                            ui_uctlPortfolio.ui_ncmbContract.Items.Add(symbl);
                                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                            {
                                                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                {
                                                    AddRowToGrid(key, prdct, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                }
                                catch (Exception)
                                {

                                }

                            }
                        }
                    }
                }
                else
                {
                    string product = ui_uctlPortfolio.ui_ncmbProduct.Text.Trim();
                    if (ui_uctlPortfolio.ui_ncmbProductType.Text.Trim().Contains("SELECT"))
                    {
                        foreach (var productType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                        {
                            foreach (var prd in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].Keys)
                            {
                                if (product == prd)
                                {
                                    foreach (var symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product])
                                    {
                                        ui_uctlPortfolio.ui_ncmbContract.Items.Add(symbl);
                                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                        {
                                            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                            foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                            {
                                                AddRowToGrid(key, product, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string productType = ui_uctlPortfolio.ui_ncmbProductType.Text.Trim();
                        if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(productType)
                            && ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].ContainsKey(product))
                        {
                            foreach (var symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product])
                            {
                                ui_uctlPortfolio.ui_ncmbContract.Items.Add(symbl);
                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                {
                                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                    foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                    {
                                        AddRowToGrid(key, product, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                    }
                                }
                            }
                        }

                    }

                }

                ui_uctlPortfolio.ui_ncmbContract.Items.Insert(0, "--SELECT--");
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndex = 0;
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged += Ui_ncmbContract_SelectedIndexChanged;
            }
            catch (Exception)
            {
            }
        }
        private void Ui_ncmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Clear();
                string _sym = ui_uctlPortfolio.ui_ncmbContract.Text.Trim();
                if (!_sym.Contains("SELECT") && ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(_sym))
                {
                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[_sym];
                    foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                    {
                        AddRowToGrid(key, instspec.Product, _sym, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                    }
                }
                else
                {

                    if (ui_uctlPortfolio.ui_ncmbProduct.Text.Trim().Contains("SELECT"))
                    {
                        if (ui_uctlPortfolio.ui_ncmbProductType.Text.Trim().Contains("SELECT"))
                        {
                            foreach (string PrdctType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                            {
                                try
                                {
                                    foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType].Keys)
                                    {
                                        try
                                        {
                                            foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[PrdctType][prdct])
                                            {
                                                try
                                                {
                                                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                                    {
                                                        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                        foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                        {
                                                            AddRowToGrid(key, prdct, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                                        }
                                                    }
                                                }
                                                catch (Exception)
                                                {

                                                }
                                            }

                                        }
                                        catch (Exception)
                                        {

                                        }

                                    }

                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                        else
                        {
                            if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()))
                            {
                                foreach (string prdct in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()].Keys)
                                {
                                    try
                                    {
                                        foreach (string symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[ui_uctlPortfolio.ui_ncmbProductType.Text.Trim()][prdct])
                                        {
                                            try
                                            {
                                                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                                {
                                                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                    foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                    {
                                                        AddRowToGrid(key, prdct, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {

                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        string product = ui_uctlPortfolio.ui_ncmbProduct.Text.Trim();
                        if (ui_uctlPortfolio.ui_ncmbProductType.Text.Trim().Contains("SELECT"))
                        {
                            foreach (var productType in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys)
                            {
                                foreach (var prd in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].Keys)
                                {
                                    if (product == prd)
                                    {
                                        foreach (var symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product])
                                        {
                                            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                            {
                                                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                                foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                                {
                                                    AddRowToGrid(key, product, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            string productType = ui_uctlPortfolio.ui_ncmbProductType.Text.Trim();
                            if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.ContainsKey(productType)
                                && ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].ContainsKey(product))
                            {
                                foreach (var symbl in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product])
                                {
                                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(symbl))
                                    {
                                        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[symbl];
                                        foreach (string key in Symbol.getKey(instspec).Where(key => Symbol.GetSymbol(key).Gateway.ToUpper().Contains(selectedGateway.ToUpper()) || selectedGateway == "---SELECT---"))
                                        {
                                            AddRowToGrid(key, product, symbl, ClsGlobal.GetDateTime(instspec.ExpiryDate), instspec.TradingCurrency);
                                        }
                                    }
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void AddRowToGrid(string key, string _product, string symbl, string ExpiryDate, string TradingCurrency)
        {
            try
            {
                Action A = () =>
                {
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Add();
                    int lastrow = ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows.Count - 1;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[0].Value = key;
                    //ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = Symbol.GetSymbol(key).Gateway;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[1].Value = DefaultGateway;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[2].Value = ui_uctlPortfolio.ui_ncmbProductType.SelectedItem.ToString();
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[3].Value = _product;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[4].Value = symbl;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[5].Value = ExpiryDate;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[6].Value = "";
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Rows[lastrow].Cells[7].Value = TradingCurrency;
                    ui_uctlPortfolio.ui_uctlGridPortfolioProduct.ui_ndgvGrid.Sort(ui_uctlPortfolio.ui_uctlGridPortfolioProduct.Columns["Contract"], ListSortDirection.Ascending);
                };
                if (InvokeRequired)
                {
                    BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }
            catch (Exception)
            {

            }
        }

        private void ui_uctlPortfolio_OnSelectedProviderChanged(object arg1, EventArgs arg2)
        {
            if (ui_uctlPortfolio.ui_ncmbGateway.SelectedItem != null)
            {
                selectedGateway = ui_uctlPortfolio.ui_ncmbGateway.SelectedItem.ToString();
            }
        }

        private void ui_uctlPortfolio_OnSelectedExchangeChanged(object arg1, EventArgs arg2)
        {
            try
            {
                ui_uctlPortfolio.ui_ncmbProductType.SelectedIndexChanged -= new System.EventHandler(ui_uctlPortfolio_OnSelectedProductTypeChanged);
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged -= Ui_ncmbContract_SelectedIndexChanged;
                ui_uctlPortfolio.ui_ncmbProduct.SelectedIndexChanged -= ui_uctlPortfolio_OnSelectedProductChanged;
                ui_uctlPortfolio.ui_ncmbProductType.Items.Clear();
                ui_uctlPortfolio.ui_ncmbProductType.Items.AddRange(ClsTWSContractManager.INSTANCE.ddProductTypesProductContract.Keys.ToArray());
                ui_uctlPortfolio.ui_ncmbProductType.Items.Insert(0, "--SELECT--");
                ui_uctlPortfolio.ui_ncmbProductType.SelectedIndex = 0;
                ui_uctlPortfolio.ui_ncmbProduct.Items.Clear();
                ui_uctlPortfolio.ui_ncmbProduct.Items.Insert(0, "--SELECT--");
                ui_uctlPortfolio.ui_ncmbProduct.SelectedIndex = 0;
                ui_uctlPortfolio.ui_ncmbContract.Items.Clear();
                ui_uctlPortfolio.ui_ncmbContract.Items.Insert(0, "--SELECT--");
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndex = 0;
                ui_uctlPortfolio.ui_ncmbContract.SelectedIndexChanged += Ui_ncmbContract_SelectedIndexChanged;
                ui_uctlPortfolio.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(ui_uctlPortfolio_OnSelectedProductTypeChanged);
                ui_uctlPortfolio.ui_ncmbProduct.SelectedIndexChanged += ui_uctlPortfolio_OnSelectedProductChanged;
            }
            catch (Exception)
            {

            }

        }



        private void ui_uctlPortfolio_Load(object sender, EventArgs e)
        {

        }
    }
}