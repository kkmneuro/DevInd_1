///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
//06/02/2012	NAMO	    1.Added code for persistency of form
//14/02/2012	NAMO	    1.Code for displaying information related to contractManager class
//16/02/2012    Vk          1.Correction in adding in list of expirydate
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using PALSA.Cls;

namespace PALSA.Frm
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
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> lstQuotes)
        {
            var objclsSnapValue = new clsSnapValue();

            Action A = () =>
                           {
                                   if (lstQuotes.ContainsKey(_crtSnapKey))
                                   {
                                   //Namo 21 March
                                   //foreach (QuoteItem item2 in lstQuotes[_crtSnapKey]._lstItem)
                                   //{
                                   //    switch (item2._quoteType)
                                   //    {
                                   //        case QuoteStreamType.ASK:
                                   //            {
                                   //                objclsSnapValue.SellQty = item2._Size.ToString();
                                   //                objclsSnapValue.SellPrice = item2._Price.ToString();
                                   //                ui_uctlSnapQuote.SetSellValues(objclsSnapValue);
                                   //            }
                                   //            break;
                                   //        case QuoteStreamType.BID:
                                   //            {
                                   //                objclsSnapValue.BuyQty = item2._Size.ToString();
                                   //                objclsSnapValue.BuyPrice = item2._Price.ToString();
                                   //                ui_uctlSnapQuote.SetBuyValues(objclsSnapValue);
                                   //            }
                                   //            break;
                                   //        case QuoteStreamType.LAST:
                                   //            {
                                   //                objclsSnapValue.LastTradedPrice = item2._Price.ToString();
                                   //                ui_uctlSnapQuote.SetLastPrice(objclsSnapValue);
                                   //            }
                                   //            break;
                                   //    }
                                   //}
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

            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(contract, productType, product);
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];

            Subscribe(contract, productType, product,"");

            if (instspec != null)
            {
                Action A =
                    () =>
                        {
                            ui_uctlSnapQuote.SetExpiryText(ClsGlobal.GetDateTime(instspec.ExpiryDate));
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
        }

        private void ui_uctlSnapQuote_OnProductSelected(string productType, string product)
        {
            //Namo 22 March
            //List<string> contracts;
            //var lstExpiryDate = new List<string>();

            //    contracts = ClsTWSContractManager.INSTANCE.GetAllContracts(productType, product);

            //foreach (string item in contracts)
            //{

            //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(item, productType, product);
            //    if (instspec != null)
            //    {
            //        lstExpiryDate.Add(ClsGlobal.GetDateTime(instspec.ExpiryDate));
            //    }
            //}
            //ui_uctlSnapQuote.AddExpiryDate(lstExpiryDate);
            //ui_uctlSnapQuote.AddContracts(contracts);
        }

        private void ui_uctlSnapQuote_OnProductTypeSelected(string productType)
        {
            //Namo 22 March
            //ui_uctlSnapQuote.AddProducts(ClsTWSContractManager.INSTANCE.GetAllProducts(productType));
        }

        public void SetMarketWatchValues(DataGridViewRow row)
        {
            ui_uctlSnapQuote.ui_ncmbProductType.SelectedItem = row.Cells["ClmProductType"].Value.ToString();
            ui_uctlSnapQuote.ui_ncmbProduct.SelectedItem = row.Cells["ClmProductName"].Value.ToString();
            ui_uctlSnapQuote.ui_ncmbContract.Text = row.Cells["ClmContractName"].Value.ToString();            
            Subscribe(row.Cells["ClmContractName"].Value.ToString(), row.Cells["ClmProductType"].Value.ToString(),
                      row.Cells["ClmProductName"].Value.ToString(), row.Cells["ClmInstrumentId"].Value.ToString());
        }

        public void Subscribe(string contract, string productType, string product,string key)
        {
            var lstSymbol = new List<Symbol>();
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
            if (key == string.Empty)
            {
                key = Symbol.getKey(instspec)[0].ToString();
            }
            _crtSnapKey = key;
            _crtSnapMarketKey = key;
            _formkey = CommandIDS.SNAP_QUOTE.ToString() + "/" + _crtSnapMarketKey;
            lstSymbol.Add(Symbol.GetSymbol(key));
            clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes( eMarketRequest.MARKET_QUOTE_REQUEST, lstSymbol);
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