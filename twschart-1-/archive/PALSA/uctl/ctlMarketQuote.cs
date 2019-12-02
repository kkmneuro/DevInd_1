using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Logging;
using CommonLibrary.Cls;
using PALSA.Frm;
using PALSA.Cls;
using PALSA.DS;

namespace PALSA.uctl
{
    public partial class ctlMarketQuote : UctlBase
    {
        private object _objPortfolio;
        public override string Formkey
        {
            get
            {
                return _formkey;
            }
            set
            {
                _formkey = value;
            }
        }
        public string _formkey;
        public object Portfolios
        {
            set { _objPortfolio = value; }
            get { return _objPortfolio; }
        }
        public ctlMarketQuote(object objPortfolio)
        {
            InitializeComponent();
            this.Portfolios = objPortfolio;
            uctlForex1.Portfolios = objPortfolio;
        }


        //Namo 21 March
        //private void INSTANCE_onSnapShotUpdate(Dictionary<string, QuoteSnapshot> DDQuoteSnap)
        //{
        //    foreach (KeyValuePair<string, QuoteSnapshot> quotesnap in DDQuoteSnap)
        //    {
        //        var objclsQuote = new clsQuotes { Key = quotesnap.Key };
        //        Symbol sym = Symbol.GetSymbol(quotesnap.Key);
        //        objclsQuote.Symbol = sym.Contract;
        //        objclsQuote.SellPrice = quotesnap.Value._Low;
        //        objclsQuote.BuyPrice = quotesnap.Value._High;
        //        objclsQuote.SellUp = false;
        //        objclsQuote.BuyUp = false;
        //        objclsQuote.HighValue = quotesnap.Value._High;
        //        objclsQuote.LowValue = quotesnap.Value._Low;
        //        //
        //        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);// PALSA.Cls.ClsGlobal.DDContractInfo[sym.KEY];
        //        objclsQuote.Digits = instspec.Digits;
        //        uctlForex1.UpdateForexPairControl(objclsQuote);
        //    }
        //}
        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> DDQuotes)
        {
            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into INSTANCE_onPriceUpdate Method");

            foreach (var item in DDQuotes)
            {
                var objclsQuote = new clsQuotes();
                //var objclsUpdatePrice = new ClsUpdatePrice();
                //objclsUpdatePrice.ContractInfoKey = item.Key;
                objclsQuote.Key = item.Key;
                Symbol sym = Symbol.GetSymbol(item.Key);
                objclsQuote.Symbol = sym.Contract;
                //Namo 21 March
                //foreach (QuoteItem item2 in item.Value._lstItem)
                //{

                //    switch (item2._quoteType)
                //    {
                //        case QuoteStreamType.ASK:
                //            {
                //                objclsQuote.SellPrice = item2._Price;
                //                switch (item2._status)
                //                {

                //                    case QuoteItemStatus.DOWN:
                //                        {
                //                            objclsQuote.SellUp = false;
                //                        }
                //                        break;
                //                    case QuoteItemStatus.SAME:
                //                        break;
                //                    case QuoteItemStatus.UP:
                //                        {
                //                            objclsQuote.SellUp = true;
                //                        }
                //                        break;
                //                    default:
                //                        break;
                //                }
                //            }
                //            break;
                //        case QuoteStreamType.BID:
                //            {
                //                objclsQuote.BuyPrice = item2._Price;
                //                switch (item2._status)
                //                {

                //                    case QuoteItemStatus.DOWN:
                //                        {
                //                            objclsQuote.BuyUp = false;
                //                        }
                //                        break;
                //                    case QuoteItemStatus.SAME:
                //                        break;
                //                    case QuoteItemStatus.UP:
                //                        {
                //                            objclsQuote.BuyUp = true;
                //                        }
                //                        break;
                //                    default:
                //                        break;
                //                }
                //            }
                //            break;
                //        case QuoteStreamType.HIGH:
                //            objclsQuote.HighValue = item2._Price;
                //            break;
                //        case QuoteStreamType.LAST:
                //            break;
                //        case QuoteStreamType.LOW:
                //            objclsQuote.LowValue = item2._Price;
                //            break;
                //        case QuoteStreamType.VOLUME:
                //            break;
                //        case QuoteStreamType.VOLUME_PER:
                //            break;
                //    }
                //    //
                //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product); //PALSA.Cls.ClsGlobal.DDContractInfo[sym.KEY];
                //    objclsQuote.Digits = instspec.Digits;
                //    uctlForex1.UpdateForexPairControl(objclsQuote);
                //}
            }

            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from INSTANCE_onPriceUpdate Method");
        }

        private void uctlForex1_OnScriptPortfolioApplyClick(string portfolioName)
        {
            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into ui_uctlForex_OnScriptPortfolioApplyClick Method");

            //_formkey = CommandIDS.MARKET_QUOTE.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName;
            List<Symbol> lst = new List<Symbol>();
            var DDKeySymbol = new Dictionary<string, string>();
            if (portfolioName != string.Empty && ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Contains(portfolioName))
            {
                ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)_objPortfolio)[portfolioName];
                int keycount = objPortfolio.Products.Keys.Count;
                foreach (Symbol objSymbol in objPortfolio.Products.Select(item => Symbol.GetSymbol(item.Key)))
                {
                    lst.Add(objSymbol);
                    DDKeySymbol.Add(objSymbol.KEY, objSymbol.Contract);
                }
            }

            if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected || portfolioName == "Default")
            {

                // clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(true, eMarketRequest.MARKET_QUOTE_REQUEST, lst);
                //    clsTWSDataManagerJSON.INSTANCE.SubscribeForQuoteSnapShot(true, eMarketRequest.MARKET_QUOTE_SNAP, lst);
                uctlForex1.InitializePairs(DDKeySymbol);
                var objclsForexPair = new ClsForexPair();
                objclsForexPair.BackColor = Properties.Settings.Default.MarketQuoteBackColor;
                objclsForexPair.OrderFormSetting = Properties.Settings.Default.OrderFormSetting;
                objclsForexPair.PositionSizeType = Properties.Settings.Default.PositionSizeType;
                objclsForexPair.UpTrendColor = Properties.Settings.Default.UpTrendColor;
                objclsForexPair.DownTrendColor = Properties.Settings.Default.DownTrendColor;
                uctlForex1.ApplyForexPairSettings(objclsForexPair);
            }
            else
                ClsCommonMethods.ShowErrorBox("Data Manager is not Connected.");



            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from ui_uctlForex_OnScriptPortfolioApplyClick Method");
        }

        private void uctlForex1_OnScriptPortfolioModifyClick(string obj)
        {
        }

        private void uctlForex1_OnScriptPortfolioRemoveClick(string obj)
        {
        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey, double qty)
        {
            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into DisplayOrderEntryDialog Method");

            if (frmOrderEntry.INSTANCE.IsDisposed)
            {
                frmOrderEntry.INSTANCE = new frmOrderEntry();
            }
            //Frm.frmOrderEntry.INSTANCE.FillValues(selectedRow);
            frmOrderEntry.INSTANCE.Formkey = formKey;
            //frmOrderEntry.INSTANCE.FormText = formTitle;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity = Properties.Settings.Default.MinOrderQty;
            //frmOrderEntry.INSTANCE.uctlOrderEntry1.SetQuantity(qty);
            //frmOrderEntry.INSTANCE.MdiParent = FrmMain.INSTANCE;
            //string str = frmOrderEntry.INSTANCE.uctlOrderEntry1.Quantity;
            frmOrderEntry.INSTANCE.Show();

            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from DisplayOrderEntryDialog Method");
        }

        //private void uctlForex1_OnOrderEntryDialog(string arg1, double arg2, double arg3)
        //{
        //    ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into uctlForex1_OnOrderEntryDialog Method");

        //    //if (arg1 == "BUY")
        //    //{
        //    //    DisplayOrderEntryDialog("BUY", Color.Green, "Buy Order Entry",
        //    //                            CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
        //    //}
        //    //else
        //    //{
        //    //    DisplayOrderEntryDialog("SELL", Color.Blue, "Sell Order Entry",
        //    //                            CommandIDS.PLACE_SELL_ORDER.ToString(), arg3);
        //    //}

        //    ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from uctlForex1_OnOrderEntryDialog Method");
        //}

        //private void uctlForex1_OnOrderSend(string arg1, double arg2, int arg3)
        //{
        //}

        public void SetValuesFromWorkSpace(string portFolio, DS.DS4MarketWatch marketQuotes)
        {
            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Enter into SetValuesFromWorkSpace Method");

            uctlForex1_OnScriptPortfolioApplyClick(portFolio);
            if (marketQuotes != null)
            {
                foreach (DataRow row in marketQuotes.dtMarketWatch.Rows)
                {
                    var objclsQuote = new clsQuotes();
                    objclsQuote.Key = row["InstrumentID"].ToString();
                    Symbol sym = Symbol.GetSymbol(objclsQuote.Key);
                    objclsQuote.Symbol = sym.Contract;
                    if (row["SellPrice"].ToString() != string.Empty)
                    {
                        objclsQuote.SellPrice = Convert.ToDouble(row["SellPrice"].ToString());
                        if (row["SellPriceState"].ToString() == "DOWN")
                        {
                            objclsQuote.SellUp = false;
                        }
                        else if (row["SellPriceState"].ToString() == "UP")
                        {
                            objclsQuote.SellUp = true;
                        }

                        objclsQuote.BuyPrice = Convert.ToDouble(row["BuyPrice"].ToString());
                        if (row["BuyPriceState"].ToString() == "DOWN")
                        {
                            objclsQuote.BuyUp = false;
                        }
                        else if (row["BuyPriceState"].ToString() == "UP")
                        {
                            objclsQuote.BuyUp = true;
                        }

                        objclsQuote.LowValue = Convert.ToDouble(row["Low"].ToString());
                        objclsQuote.HighValue = Convert.ToDouble(row["High"].ToString());

                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(sym.Contract))
                        {
                            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                            objclsQuote.Digits = instspec.Digits;
                            uctlForex1.UpdateForexPairControl(objclsQuote);
                        }
                    }
                }
            }

            ////FileHandling.WriteDevelopmentLog("MarketQuote" + count + " : Exit from SetValuesFromWorkSpace Method");
        }
        void uctlForex1_OnSellMarketClick(string key, string account, double price, double qty)
        {
            //Namo 21 March
            //if (FrmMain.LoggedInSuccess)
            //{
            //ClsNewOrder order = new ClsNewOrder();
            ////string[] strArr = type.Split(' ');
            //Symbol sym = Symbol.GetSymbol(key);
            //string productType = sym.ProductType;
            //string pType = string.Empty;
            //switch (productType)
            //{
            //    case "EQUITY":
            //        pType = "EQ";
            //        break;
            //    case "FUTURE":
            //        pType = "FUT";
            //        break;
            //    case "FOREX":
            //        pType = "FX";
            //        break;
            //    case "OPTION":
            //        pType = "OPT";
            //        break;
            //    case "SPOT":
            //        pType = "SP";
            //        break;
            //    case "PHYSICAL":
            //        pType = "PH";
            //        break;
            //    case "AUCTION":
            //        pType = "AU";
            //        break;
            //    case "BOND":
            //        pType = "BON";
            //        break;
            //}
            //;
            //order.Account = Convert.ToUInt32(clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0].ToString());
            //order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //order.ContractName = sym.Contract;
            ////DateTime dtEX;
            ////if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
            ////{
            ////    if (dtEX != null)
            ////        order.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
            ////}
            //order.GatewayName = sym.Gateway;
            //order.MinorDisclosedQty = 0;
            //order.OrderID = 0;
            //order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
            //order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
            //order.Price = price;
            //order.ProductName = sym.Product;
            //order.Qty = qty * clsTWSOrderManagerJSON.INSTANCE.Lotsize;
            //order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];

            //order.Side = (sbyte)clsHashDefine.SIDE_SELL;

            //order.StopPX = 0;
            //order.StrProductType = sym.ProductType;
            //order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
            //order.StopLoss = 0;
            //order.TakeProfit = 0;

            //clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            //            }
            //else
            //{
            //    clsTWSOrderManagerJSON.INSTANCE.SendMessageForStatus("Please login to place order.");
            //}
        }

        void uctlForex1_OnSellClick(string arg1, string arg2, double arg3, double arg4)
        {
            //throw new System.NotImplementedException();
        }

        void uctlForex1_OnCloseClick()
        {
            //throw new System.NotImplementedException();
        }

        void uctlForex1_OnBuyMarketClick(string key, string account, double price, double qty)
        {
            //if (FrmMain.LoggedInSuccess)
            //{
            //    ClsNewOrder order = new ClsNewOrder();
            //    //string[] strArr = type.Split(' ');
            //    Symbol sym = Symbol.GetSymbol(key);
            //    string productType = sym.ProductType;
            //    string pType = string.Empty;
            //    switch (productType)
            //    {
            //        case "EQUITY":
            //            pType = "EQ";
            //            break;
            //        case "FUTURE":
            //            pType = "FUT";
            //            break;
            //        case "FOREX":
            //            pType = "FX";
            //            break;
            //        case "OPTION":
            //            pType = "OPT";
            //            break;
            //        case "SPOT":
            //            pType = "SP";
            //            break;
            //        case "PHYSICAL":
            //            pType = "PH";
            //            break;
            //        case "AUCTION":
            //            pType = "AU";
            //            break;
            //        case "BOND":
            //            pType = "BON";
            //            break;
            //    }
            //    ;
            //    order.Account = Convert.ToUInt32(clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0].ToString());
            //    order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //    order.ContractName = sym.Contract;
            //    //DateTime dtEX;
            //    //if (DateTime.TryParse(CurrentOrder.ExpiryDate, out dtEX))
            //    //{
            //    //    if (dtEX != null)
            //    //        order.ExpiryDate = Convert.ToDateTime(CurrentOrder.ExpiryDate);
            //    //}
            //    order.GatewayName = sym.Gateway;
            //    order.MinorDisclosedQty = 0;
            //    order.OrderID = 0;
            //    order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
            //    order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
            //    order.Price = price;
            //    order.ProductName = sym.Product;
            //    order.Qty = qty * clsTWSOrderManagerJSON.INSTANCE.Lotsize;
            //    order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];

            //    order.Side = (sbyte)clsHashDefine.SIDE_BUY;

            //    order.StopPX = 0;
            //    order.StrProductType = sym.ProductType;
            //    order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
            //    order.StopLoss = 0;
            //    order.TakeProfit = 0;

            //    clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            //}
            //else
            //{
            //    clsTWSOrderManagerJSON.INSTANCE.SendMessageForStatus("Please login to place order.");
            //}
        }

        void uctlForex1_OnBuyClick(string arg1, string arg2, double arg3, double arg4)
        {
            //throw new System.NotImplementedException();
        }

        void uctlForex1_Load(object sender, System.EventArgs e)
        {


            uctlForex1.Portfolios = _objPortfolio;
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -= new Action<Dictionary<string, QuoteSnapshot>>(INSTANCE_onSnapShotUpdate);
            //clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += new Action<Dictionary<string, QuoteSnapshot>>(INSTANCE_onSnapShotUpdate);


        }
    }
}
