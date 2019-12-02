///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//06/02/2012	VP		    1.Added code for persistency of form
//14/02/2012	VP		    1.Code for displaying information related to contractManager class
//16/02/2012    Vk          1.Correction in adding in list of expirydate
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmSnapQuote : frmBase
    {
        private static int count;

        private static frmSnapQuote _instance;
        private string _crtSnapKey=string.Empty;
        private string _crtSnapMarketKey=string.Empty;
        private string _formkey;

        public frmSnapQuote()
        {
            InitializeComponent();
            count += 1;
            _formkey = CommandIDS.SNAP_QUOTE.ToString() + "/" + Convert.ToString(count);
        }

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public static frmSnapQuote INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSnapQuote();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private void frmSnapQuote_Load(object sender, EventArgs e)
        {
            Title = "Snap Quote";
            ui_uctlSnapQuote.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
            MinimumSize = Size;
            MaximumSize = Size;
        }
        private void INSTANCE_onPriceUpdate(QuotesStream _QuotesStream)
        {
            Action A = () =>
            {
                foreach (var quotes in _QuotesStream.QuotesItem)
                {
                    try
                    {
                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(quotes.Contract) && quotes.MarketLevel == 0)
                        {
                            InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[quotes.Contract];
                            var objclsSnapValue = new clsSnapValue();
                         
                            long _size = quotes.Size;
                            if (spec != null && spec.ContractSize > 0)
                            {
                                _size = (long)(quotes.Size / spec.ContractSize);
                            }
                            double _Price = quotes.Price / Math.Pow(10, spec.Digits);
                            switch (quotes.QuotesStreamType)
                            {
                                case "A":
                                    {
                                        objclsSnapValue.SellQty = _size.ToString();
                                        objclsSnapValue.SellPrice = _Price.ToString();
                                        ui_uctlSnapQuote.SetSellValues(objclsSnapValue);
                                    }
                                    break;
                                case "B":
                                    {
                                        objclsSnapValue.BuyQty = _size.ToString();
                                        objclsSnapValue.BuyPrice = _Price.ToString();
                                        ui_uctlSnapQuote.SetBuyValues(objclsSnapValue);
                                    }
                                    break;
                                case "L":
                                    {
                                        objclsSnapValue.LastTradedPrice = _Price.ToString();
                                        ui_uctlSnapQuote.SetLastPrice(objclsSnapValue);
                                    }
                                    break;
                                default:
                                    break;
                            }
                            
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
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

        private void frmSnapQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.SNAP_QUOTE.ToString(); //+ "/" + Convert.ToString(count);
        }

        private void ui_uctlSnapQuote_OnContractSelected(string productType, string product, string contract)
        {

            try
            {
                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
                Subscribe(contract, productType, product, "");

                Action A =
                    () =>
                    {
                        DateTime exp = DateTime.Now;
                        DateTime.TryParse(instspec.ExpiryDate, out exp);
                        string expiryDate = exp.ToString("dd/MM/yyyy");
                        ui_uctlSnapQuote.SetExpiryText(expiryDate);
                        //ui_uctlSnapQuote.SetExpiryText(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(instspec.ExpiryDate));
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

        private void ui_uctlSnapQuote_OnProductSelected(string productType, string product)
        {
            try
            {
                List<string> contracts;
                var lstExpiryDate = new List<string>();

                contracts = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][product];

                foreach (string item in contracts)
                {

                    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[item];
                    if (instspec != null)
                    {
                        DateTime exp = DateTime.Now;
                        DateTime.TryParse(instspec.ExpiryDate, out exp);
                        string expiryDate = exp.ToString("dd/MM/yyyy");
                        lstExpiryDate.Add(expiryDate);
                        //lstExpiryDate.Add(clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(instspec.ExpiryDate));
                    }
                }
                ui_uctlSnapQuote.AddExpiryDate(lstExpiryDate);
                ui_uctlSnapQuote.AddContracts(contracts);
            }
            catch (Exception)
            {

            }
        }

        private void ui_uctlSnapQuote_OnProductTypeSelected(string productType)
        {

            ui_uctlSnapQuote.AddProducts(ClsTWSContractManager.INSTANCE.LstProductTypes);
        }

        public void SetMarketWatchValues(DataGridViewRow row)
        {
            ui_uctlSnapQuote.ui_ncmbProductType.SelectedItem = row.Cells["ClmProductType"].Value.ToString();
            ui_uctlSnapQuote.ui_ncmbProduct.SelectedItem = row.Cells["ClmProductName"].Value.ToString();
            ui_uctlSnapQuote.ui_ncmbContract.Text = row.Cells["ClmContractName"].Value.ToString();
            //ui_uctlSnapQuote.ui_ncmbExpiryDate.SelectedItem =
            //    Convert.ToDateTime(row.Cells["ClmExpiry"].Value).ToShortDateString();

            Subscribe(row.Cells["ClmContractName"].Value.ToString(), row.Cells["ClmProductType"].Value.ToString(),
                      row.Cells["ClmProductName"].Value.ToString(), row.Cells["ClmInstrumentId"].Value.ToString());
        }

        public void Subscribe(string contract, string productType, string product,string key)
        {
            var lstSymbol = new List<Symbol>();
            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(contract, productType, product); //Commented : Ajay
            InstrumentSpec instspec = null;
            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(contract))
            {
                instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
            }
            if (key == string.Empty)
            {
                key = Symbol.getKey(instspec)[0].ToString();
            }
            _crtSnapKey = key;
            _crtSnapMarketKey = key;
            _formkey = CommandIDS.SNAP_QUOTE.ToString() + "/" + _crtSnapMarketKey;
            lstSymbol.Add(Symbol.GetSymbol(key));

            //TWS.Cls.ClsGlobal.SubscibedSymbolList.ContainsKey(
            //TWS.Cls.ClsGlobal.SubscibedSymbolList.Add(Symbol.GetSymbol(key));
            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes( SubscribeRequestType.SUBSCRIBE,lstSymbol);
        }

        public void SetValuesFromWorkSpace(string snapMarketKey, string expriyDate)
        {
            string[] str = snapMarketKey.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);

            ui_uctlSnapQuote.ui_ncmbProductType.SelectedItem = str[0];
            ui_uctlSnapQuote.ui_ncmbProduct.SelectedItem = str[1];
            ui_uctlSnapQuote.ui_ncmbContract.Text = str[2];
            ui_uctlSnapQuote.ui_ncmbExpiryDate.SelectedItem = str[3] + "/" + expriyDate;

            Subscribe(str[2], str[0], str[1],"");
        }
    }
}