using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClientDLL_Model.Cls;
using ClientDLL_Model.Cls.Contract;
using ClientDLL_Model.Cls.Market;
using CommonLibrary.Cls;
using Logging;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmMarketQuote : frmBase
    {
        private static int count;
        private string _formkey;
        public object _objPortfolio;

        public frmMarketQuote()
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into frmMarketQuote Constructor");

            count += 1;
            InitializeComponent();
            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlForex1.CurrentPortfolioName;

            FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from frmMarketQuote Constructor");
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
            FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into ui_uctlForex_Load Method");

            uctlForex1.Portfolios = _objPortfolio;
            ClsTWSDataManager.INSTANCE.onPriceUpdate +=
                INSTANCE_onPriceUpdate;

            FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from ui_uctlForex_Load Method");
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> DDQuotes)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into INSTANCE_onPriceUpdate Method");

            foreach (var item in DDQuotes)
            {
                var objclsUpdatePrice = new ClsUpdatePrice();
                objclsUpdatePrice.ContractInfoKey = item.Key;

                foreach (QuoteItem item2 in item.Value._lstItem)
                {
                    switch (item2._quoteType)
                    {
                        case QuoteStreamType.ASK:
                            {
                                objclsUpdatePrice.SellPrice = item2._Price;

                                switch (item2._status)
                                {
                                    case QuoteItemStatus.DOWN:
                                        {
                                            objclsUpdatePrice.SellColor =
                                                Properties.Settings.Default.MarketQuoteDownColor;
                                            objclsUpdatePrice.SellImagePath = Application.StartupPath +
                                                                              "\\Resx\\DownArrowForMarketQuote.png";
                                        }
                                        break;
                                    case QuoteItemStatus.SAME:
                                        {
                                            objclsUpdatePrice.SellColor = Color.White;
                                            objclsUpdatePrice.SellImagePath = Application.StartupPath +
                                                                              "\\Resx\\NoChangeArrowForMarketWatch.png";
                                        }
                                        break;
                                    case QuoteItemStatus.UP:
                                        {
                                            objclsUpdatePrice.SellColor = Properties.Settings.Default.MarketQuoteUpColor;
                                            objclsUpdatePrice.SellImagePath = Application.StartupPath +
                                                                              "\\Resx\\UpArrowForMarketQuote.png";
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case QuoteStreamType.BID:
                            {
                                objclsUpdatePrice.BuyPrice = item2._Price;

                                switch (item2._status)
                                {
                                    case QuoteItemStatus.DOWN:
                                        {
                                            objclsUpdatePrice.BuyColor =
                                                Properties.Settings.Default.MarketQuoteDownColor;
                                            objclsUpdatePrice.BuyImagePath = Application.StartupPath +
                                                                             "\\Resx\\DownArrowForMarketQuote.png";
                                        }
                                        break;
                                    case QuoteItemStatus.SAME:
                                        {
                                            objclsUpdatePrice.BuyColor = Color.White;
                                            objclsUpdatePrice.BuyImagePath = Application.StartupPath +
                                                                             "\\Resx\\NoChangeArrowForMarketWatch.png";
                                        }
                                        break;
                                    case QuoteItemStatus.UP:
                                        {
                                            objclsUpdatePrice.BuyColor = Properties.Settings.Default.MarketQuoteUpColor;
                                            objclsUpdatePrice.BuyImagePath = Application.StartupPath +
                                                                             "\\Resx\\UpArrowForMarketQuote.png";
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                            //case ClientDLL_Model.Cls.QuoteStreamType.HIGH:
                            //    break;
                            //case ClientDLL_Model.Cls.QuoteStreamType.LAST:
                            //    break;
                            //case ClientDLL_Model.Cls.QuoteStreamType.LOW:
                            //    break;
                            //case ClientDLL_Model.Cls.QuoteStreamType.VOLUME:
                            //    break;
                            //case ClientDLL_Model.Cls.QuoteStreamType.VOLUME_PER:
                            //    break;
                    }
                    uctlForex1.UpdateForexPairControl(objclsUpdatePrice);
                }
            }

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from INSTANCE_onPriceUpdate Method");
        }

        private void ui_uctlForex_OnScriptPortfolioApplyClick(string portfolioName)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into ui_uctlForex_OnScriptPortfolioApplyClick Method");

            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName;
            //List<string> lstSymbols = new List<string>();
            var DDKeySymbol = new Dictionary<string, string>();
            if (portfolioName != string.Empty)
            {
                Title = Text + ":" + portfolioName;
                if (((Dictionary<string, ClsPortfolio>) _objPortfolio).Keys.Contains(portfolioName))
                {
                    ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>) _objPortfolio)[portfolioName];
                    int keycount = objPortfolio.Products.Keys.Count;
                    foreach (var item in objPortfolio.Products)
                    {
                        Symbol objSymbol = Symbol.GetSymbol(item.Key);
                        //lstSymbols.Add(item.Value.InstrumentId.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).Last());
                        DDKeySymbol.Add(objSymbol.KEY,
                                        item.Value.InstrumentId.Split(new[] {'_'},
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

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from ui_uctlForex_OnScriptPortfolioApplyClick Method");
        }

        private void ui_uctlForex_OnScriptPortfolioModifyClick(string obj)
        {
        }

        private void ui_uctlForex_OnScriptPortfolioRemoveClick(string obj)
        {
        }

        private void frmMarketQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into frmMarketQuote_FormClosed Method");

            count -= 1;
            _formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlForex1.CurrentPortfolioName;

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from frmMarketQuote_FormClosed Method");
        }

        private void frmMarketQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into frmMarketQuote_FormClosing Method");

            ClsTWSDataManager.INSTANCE.onPriceUpdate -=INSTANCE_onPriceUpdate;

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from frmMarketQuote_FormClosing Method");
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey, double qty)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into DisplayOrderEntryDialog Method");

            if (frmOrderEntry.INSTANCE.IsDisposed)
            {
                frmOrderEntry.INSTANCE = new frmOrderEntry();
            }
            //Frm.frmOrderEntry.INSTANCE.FillValues(selectedRow);
            //frmOrderEntry.INSTANCE.Formkey = formKey;
            //frmOrderEntry.INSTANCE.FormText = formTitle;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity = Properties.Settings.Default.MinOrderQty;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.SetQuantity(qty);
            //frmOrderEntry.INSTANCE.MdiParent = MdiParent;
            //string str = frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity;
            frmOrderEntry.INSTANCE.Show();

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from DisplayOrderEntryDialog Method");
        }

        private void uctlForex1_OnOrderEntryDialog(string arg1, double arg2, double arg3)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into uctlForex1_OnOrderEntryDialog Method");

            //if (arg1 == "BUY")
            //{
            //    DisplayOrderEntryDialog("BUY", Color.Green, "Buy Order Entry",
            //                            CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
            //}
            //else
            //{
            //    DisplayOrderEntryDialog("SELL", Color.Blue, "Sell Order Entry",
            //                            CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
            //}

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from uctlForex1_OnOrderEntryDialog Method");
        }

        private void uctlForex1_OnOrderSend(string arg1, double arg2, int arg3)
        {
        }

        public void SetValuesFromWorkSpace(string portFolio)
        {
            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Enter into SetValuesFromWorkSpace Method");

            ui_uctlForex_OnScriptPortfolioApplyClick(portFolio);

            FileHandling.WriteDevelopmentLog("MarketQuote" + count +" : Exit from SetValuesFromWorkSpace Method");
        }
    }
}