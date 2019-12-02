using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmMarketQuote : frmBase
    {
        private static int count;
        private string _formkey;
        public object _objPortfolio;

        public frmMarketQuote()
        {
            //FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into frmMarketQuote Constructor");

            count += 1;
            InitializeComponent();
            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlForex1.CurrentPortfolioName;

            //FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from frmMarketQuote Constructor");
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

        public static int Count
        {
            get { return count; }
        }

        public object PortFolios
        {
            set { _objPortfolio = value; }
            get { return _objPortfolio; }
        }

        private void ui_uctlForex_Load(object sender, EventArgs e)
        {
            uctlForex1.Portfolios = _objPortfolio;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
        }

        private void INSTANCE_onPriceUpdate(QuotesStream _QuotesStream)
        {            
            foreach (var quotes in _QuotesStream.QuotesItem)
            {
                try
                {
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(quotes.Contract) && quotes.MarketLevel == 0)
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[quotes.Contract];
                        var objclsUpdatePrice = new ClsUpdatePrice();
                        objclsUpdatePrice.ContractInfoKey = spec.Gateway + "_" + spec.ProductType + "_" + spec.Product + "_" + spec.Contract;
                        
                        double _Price = quotes.Price / Math.Pow(10, spec.Digits);
                        switch (quotes.QuotesStreamType)
                        {
                            case "A":
                                {                        
                                    double prevPrice = objclsUpdatePrice.SellPrice;
                                    objclsUpdatePrice.SellPrice = _Price;

                                    if (prevPrice > _Price) // DOWN
                                    {
                                        objclsUpdatePrice.SellColor =
                                            Properties.Settings.Default.MarketQuoteDownColor;
                                        objclsUpdatePrice.SellImagePath = Application.StartupPath + "\\Resx\\DownArrowForMarketQuote.png";
                                    }
                                    else if (prevPrice == _Price) // NO CHANGE
                                    {
                                        objclsUpdatePrice.SellColor = Color.White;
                                        objclsUpdatePrice.SellImagePath = Application.StartupPath + "\\Resx\\NoChangeArrowForMarketWatch.png";
                                    }
                                    else if (prevPrice < _Price) // UP 
                                    {
                                        objclsUpdatePrice.SellColor = Properties.Settings.Default.MarketQuoteUpColor;
                                        objclsUpdatePrice.SellImagePath = Application.StartupPath + "\\Resx\\UpArrowForMarketQuote.png";
                                    }
                                }
                                break;
                            case "B":
                                {

                                    double prevPrice = objclsUpdatePrice.BuyPrice;
                                    objclsUpdatePrice.BuyPrice = _Price;

                                    if (prevPrice > _Price) // DOWN
                                    {
                                        objclsUpdatePrice.BuyColor =  Properties.Settings.Default.MarketQuoteDownColor;
                                        objclsUpdatePrice.BuyImagePath = Application.StartupPath + "\\Resx\\DownArrowForMarketQuote.png";
                                    }
                                    else if (prevPrice == _Price) // NO CHANGE
                                    {
                                        objclsUpdatePrice.BuyColor = Color.White;
                                        objclsUpdatePrice.BuyImagePath = Application.StartupPath + "\\Resx\\NoChangeArrowForMarketWatch.png";
                                    }
                                    else if (prevPrice < _Price) // UP 
                                    {
                                        objclsUpdatePrice.BuyColor = Properties.Settings.Default.MarketQuoteUpColor;
                                        objclsUpdatePrice.BuyImagePath = Application.StartupPath + "\\Resx\\UpArrowForMarketQuote.png";
                                    }                             
                                }
                                break;                     
                            default:
                                break;
                        }
                        uctlForex1.UpdateForexPairControl(objclsUpdatePrice);
                    }

                }
                catch (Exception)
                {

                }
            }

        }      

        private void ui_uctlForex_OnScriptPortfolioApplyClick(string portfolioName)
        {
            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into ui_uctlForex_OnScriptPortfolioApplyClick Method");

            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName;
            //List<string> lstSymbols = new List<string>();
            var DDKeySymbol = new Dictionary<string, string>();
            if (portfolioName != string.Empty)
            {
                Title = Text + ":" + portfolioName;
                if (((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Contains(portfolioName))
                {
                    ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)_objPortfolio)[portfolioName];
                    int keycount = objPortfolio.Products.Keys.Count;
                    foreach (var item in objPortfolio.Products)
                    {
                        Symbol objSymbol = Symbol.GetSymbol(item.Key);
                        //lstSymbols.Add(item.Value.InstrumentId.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).Last());
                        DDKeySymbol.Add(objSymbol.KEY,
                                        item.Value.InstrumentId.Split(new[] { '_' },
                                                                      StringSplitOptions.RemoveEmptyEntries).Last());
                    }
                }
            }
            uctlForex1.InitializePairs(DDKeySymbol);

            var objclsForexPair = new ClsForexPair();
            objclsForexPair.BackColor = Properties.Settings.Default.MarketQuoteBackColor;
            objclsForexPair.OrderFormSetting = Properties.Settings.Default.OrderFormSetting;
            objclsForexPair.PositionSizeType = Properties.Settings.Default.PositionSizeType;
            objclsForexPair.UpTrendColor = Properties.Settings.Default.UpTrendColor;
            objclsForexPair.DownTrendColor = Properties.Settings.Default.DownTrendColor;

            uctlForex1.ApplyForexPairSettings(objclsForexPair);
            //uctlForex1.InitializePairs(lstSymbols);

            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from ui_uctlForex_OnScriptPortfolioApplyClick Method");
        }

        private void ui_uctlForex_OnScriptPortfolioModifyClick(string obj)
        {
        }

        private void ui_uctlForex_OnScriptPortfolioRemoveClick(string obj)
        {
        }

        private void frmMarketQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" + uctlForex1.CurrentPortfolioName;

        }

        private void frmMarketQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey, double qty)
        {
            if (frmOrderEntry.INSTANCE.IsDisposed)
            {
                frmOrderEntry.INSTANCE = new frmOrderEntry();
            }
            //Frm.frmOrderEntry.INSTANCE.FillValues(selectedRow);
            frmOrderEntry.INSTANCE.Formkey = formKey;
            frmOrderEntry.INSTANCE.FormText = formTitle;
            frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity = Properties.Settings.Default.MinOrderQty;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.SetQuantity(qty);
            frmOrderEntry.INSTANCE.MdiParent = MdiParent;
            //string str = frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity;
            frmOrderEntry.INSTANCE.Show();
        }

        private void uctlForex1_OnOrderEntryDialog(string arg1, double arg2, double arg3)
        {
            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into uctlForex1_OnOrderEntryDialog Method");

            if (arg1 == "BUY")
            {
                DisplayOrderEntryDialog("BUY", Color.Green, "Buy Order Entry",
                                        CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
            }
            else
            {
                DisplayOrderEntryDialog("SELL", Color.Blue, "Sell Order Entry",
                                        CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
            }

            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from uctlForex1_OnOrderEntryDialog Method");
        }

        private void uctlForex1_OnOrderSend(string arg1, double arg2, int arg3)
        {
        }

        public void SetValuesFromWorkSpace(string portFolio)
        {
            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into SetValuesFromWorkSpace Method");

            ui_uctlForex_OnScriptPortfolioApplyClick(portFolio);

            //FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from SetValuesFromWorkSpace Method");
        }
    }
}