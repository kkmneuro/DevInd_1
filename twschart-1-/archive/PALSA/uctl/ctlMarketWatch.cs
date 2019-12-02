﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonLibrary.Cls;
//using Logging;
using PALSA.Cls;
using PALSA.DS;
using PALSA.Frm;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using ClsGlobal = PALSA.Cls.ClsGlobal;


namespace PALSA.uctl
{
    public partial class ctlMarketWatch : UctlBase
    {
        private static int count;
        public DS4MarketWatch marketDS = new DS4MarketWatch();
        //private readonly frmOrderEntry objfrmOrderEntry = new frmOrderEntry();
        Image downimg = null;
        Image upimg = null;
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
        private object _objPortfolio;
        private object _objProfiles;
        private string _userCode = string.Empty;
        private string _currentPortfolio = string.Empty;
        public string CurrentPortfolio
        {
            get { return _currentPortfolio; }
            set { _currentPortfolio = value; }
        }
        private Keys _shortcutKeyMarketPicture = Keys.None;
        public Keys ShortcutKeyOE { get; set; }
        public Keys ShortcutKeyBOE { get; set; }

        public Keys ShortcutKeySOE { get; set; }

        public Keys ShortcutKeyMarketPicture
        {
            get { return _shortcutKeyMarketPicture; }
            set { _shortcutKeyMarketPicture = value; }
        }

        public object ObjPortfolio
        {
            get { return _objPortfolio; }
            set
            {
                _objPortfolio = value;
                uctlMarketWatch1.Portfolios = value;
            }
        }

        #region Nested type: PriceQuoteHandler

        private delegate void PriceQuoteHandler(string key, Quote Quote);

        #endregion

        #region Nested type: QuoteSnapShotHandler
        //Namo 21 March
        //private delegate void QuoteSnapShotHandler(string key, QuoteSnapshot QuoteSnapShot);

        #endregion

        #region Nested type: UpdateQuoteHandler

        private delegate void UpdateQuoteHandler(QuoteItem quoteItem, DataRow row);

        #endregion

        public ctlMarketWatch(object objPortfolio)
        {
            InitializeComponent();
            ObjPortfolio = objPortfolio;
            uctlMarketWatch1.Portfolios = objPortfolio;
            var columnsArray = new DataGridViewColumn[29];
            var IntCellStyle = new DataGridViewCellStyle();
            IntCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            #region "  Add Columns to grid  "
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
            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "ClmProductName", "Product", false);
            columnsArray[3].DataPropertyName = "ProductName";
            columnsArray[3].ToolTipText = "Product Name";
            columnsArray[3].Width = 80;
            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "ClmContractName", "Contract");
            columnsArray[4].DataPropertyName = "ContractName";
            columnsArray[4].ToolTipText = "Contract Name";
            columnsArray[4].Width = 80;
            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "ClmExpiry", "Expiry", false);
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
            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "ClmBuyPrice", "BID Price");
            columnsArray[9].DataPropertyName = "BuyPrice";
            columnsArray[9].DefaultCellStyle = IntCellStyle;
            columnsArray[9].Width = 70;
            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "ClmBuyQty", "BID Size", false);
            columnsArray[10].DataPropertyName = "BuyQty";
            columnsArray[10].DefaultCellStyle = IntCellStyle;
            columnsArray[10].Width = 50;
            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "ClmSellQty", "ASK Size", false);
            columnsArray[11].DataPropertyName = "SellQty";
            columnsArray[11].DefaultCellStyle = IntCellStyle;
            columnsArray[11].Width = 50;
            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "ClmSellPrice", "ASK Price");
            columnsArray[12].DataPropertyName = "SellPrice";
            columnsArray[12].DefaultCellStyle = IntCellStyle;
            columnsArray[12].Width = 70;
            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "ClmLastUpdatedTime", "LUT", true);
            columnsArray[13].DataPropertyName = "LastUpdatedTime";
            columnsArray[13].ToolTipText = "Last Updated Time";
            columnsArray[13].Width = 60;
            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "ClmLTP", "LTP", false);
            columnsArray[14].DataPropertyName = "LTP";
            columnsArray[14].ToolTipText = "Last Traded Price";
            columnsArray[14].DefaultCellStyle = IntCellStyle;
            columnsArray[14].Width = 70;
            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "ClmVolume", "Volume", false);
            columnsArray[15].DataPropertyName = "Volume";
            columnsArray[15].DefaultCellStyle = IntCellStyle;
            columnsArray[15].Width = 60;
            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "ClmValue", "Value %", false);
            columnsArray[16].DataPropertyName = "Value";
            columnsArray[16].DefaultCellStyle = IntCellStyle;
            columnsArray[16].Width = 50;
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "ClmHigh", "High", false);
            columnsArray[17].DataPropertyName = "High";
            columnsArray[17].DefaultCellStyle = IntCellStyle;
            columnsArray[17].Width = 70;
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "ClmLow", "Low", false);
            columnsArray[18].DataPropertyName = "Low";
            columnsArray[18].DefaultCellStyle = IntCellStyle;
            columnsArray[18].Width = 70;
            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "ClmOpenPrice", "Open Price", false);
            columnsArray[19].DataPropertyName = "OpenPrice";
            columnsArray[19].DefaultCellStyle = IntCellStyle;
            columnsArray[19].Width = 70;
            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "ClmClosePrice", "Close Price", false);
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
            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "ClmNetChange", "Net Change", false);
            columnsArray[25].DataPropertyName = "NetChange";
            columnsArray[25].Width = 70;
            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "ClmSpecification", "Specification", false);
            columnsArray[26].DataPropertyName = "Specification";
            columnsArray[26].Width = 80;
            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "ClmFairPrice", "Fair Price", false);
            columnsArray[27].DataPropertyName = "FairPrice";
            columnsArray[27].DefaultCellStyle = IntCellStyle;
            columnsArray[27].Width = 70;
            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "clmImage", "Trend", new DataGridViewImageColumn());
            columnsArray[28].Width = 60;
            columnsArray[28].DisplayIndex = 0;
            //columnsArray[28].Visible = false;
            columnsArray[28].DefaultCellStyle.NullValue = null;

            uctlMarketWatch1.AddColumnsToGrid(columnsArray);
            #endregion 
            downimg = Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
            upimg = Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
            uctlMarketWatch1.ui_uctlGridMarketWatch.EnableCellCustomDraw = false;
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellValueNeeded += new DataGridViewCellValueEventHandler(ui_ndgvGrid_CellValueNeeded);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellClick -= new DataGridViewCellEventHandler(ui_ndgvGrid_CellClick);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellClick += new DataGridViewCellEventHandler(ui_ndgvGrid_CellClick);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellMouseClick -= new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseClick);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellMouseClick += new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseClick);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellMouseDoubleClick -= new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseDoubleClick);
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseDoubleClick);

        }

        void ui_ndgvGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //if (marketDS.dtMarketWatch.Rows[e.RowIndex]["BuyPriceState"].ToString() == "UP")
            //{
            //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[e.RowIndex].Cells["ClmImage"].Value = downimg;
            //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[e.RowIndex].Cells["ClmBuyPrice"].Style.BackColor =
            //        Color.Red;
            //    uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[e.RowIndex].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
            //}

        }
        public void LoadFromDataset(DS4MarketWatch marketDs)
        {

            //uctlMarketWatch1.ui_uctlGridMarketWatch.EnableCellCustomDraw = false;
            //uctlMarketWatch1.DownTrendColor = Color.Red;
            //uctlMarketWatch1.UpTrendColor = Color.Green;
            uctlMarketWatch1.ui_uctlGridMarketWatch.DataSource = marketDS.dtMarketWatch;
            //foreach (DataRow row in marketDs.dtMarketWatch.Rows)
            //{
            //    int index = marketDs.dtMarketWatch.Rows.IndexOf(row);//row["LastUpdatedTime"];
            //    Symbol sym = Symbol.GetSymbol(row["InstrumentId"].ToString());//ClsGlobal.DDContractInfo[sym.KEY];//
            //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
            //    string format = "0.";
            //    for (int i = 0; i < instspec.Digits; i++)
            //    {
            //        format += "0";
            //    }
            //    if (row["BuyPrice"].ToString() != string.Empty)
            //    {
            //        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Value =
            //            decimal.Round(Convert.ToDecimal(row["BuyPrice"].ToString()), 5).ToString(format);
            //        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Value =
            //            decimal.Round(Convert.ToDecimal(row["SellPrice"].ToString()), 5).ToString(format);
            //        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLastUpdatedTime"].Value = row["LastUpdatedTime"].ToString();
            //        if (row["BuyPriceState"].ToString() == "DOWN") //Down
            //        {
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = downimg;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor =
            //             uctlMarketWatch1.DownTrendColor;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
            //        }
            //        else if (row["BuyPriceState"].ToString() == "UP") //UP
            //        {
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = upimg;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor =
            //             uctlMarketWatch1.UpTrendColor;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
            //        }

            //        if (row["SellPriceState"].ToString() == "DOWN") //Down
            //        {
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor =uctlMarketWatch1.DownTrendColor;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor =Color.White;
            //        }
            //        else if (row["SellPriceState"].ToString() == "UP") //UP
            //        {
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor =
            //            uctlMarketWatch1.UpTrendColor;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor =
            //                Color.White;
            //        }
            //        else //Unchanged
            //        {
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
            //            uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.Black;
            //        }
            //    }
            //}

        }

        void ui_ndgvGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (iRowIndex > -1 && iCollIndex > -1)
            {
                if (Properties.Settings.Default.EnableTradingOnMarketWatch)
                {
                    if (!Properties.Settings.Default.SingleClickOrderSubmit)
                    {
                        double _askPrice = Convert.ToDouble(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmSellPrice"].Value.ToString());
                        double _bidPrice = Convert.ToDouble(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmBuyPrice"].Value.ToString());
                        Symbol sym = Symbol.GetSymbol(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmInstrumentId"].Value.ToString());
                        if (uctlMarketWatch1.ui_uctlGridMarketWatch.Columns[iCollIndex].Name == "ClmBuyPrice")
                        {
                            if (Properties.Settings.Default.DirectMarketExecution)
                            {
                                ClsNewOrder order = new ClsNewOrder();
                                string productType = sym.ProductType;
                                string pType = string.Empty;
                                switch (productType)
                                {
                                    case "EQUITY":
                                        pType = "EQ";
                                        break;
                                    case "FUTURE":
                                        pType = "FUT";
                                        break;
                                    case "FOREX":
                                        pType = "FX";
                                        break;
                                    case "OPTION":
                                        pType = "OPT";
                                        break;
                                    case "SPOT":
                                        pType = "SP";
                                        break;
                                    case "PHYSICAL":
                                        pType = "PH";
                                        break;
                                    case "AUCTION":
                                        pType = "AU";
                                        break;
                                    case "BOND":
                                        pType = "BON";
                                        break;
                                }
                                ;
                                order.Account = clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
                                order.ClOrdId = Cls.ClsGlobal.GetClientOrderID().ToString();
                                order.Contract = sym.Contract;
                                order.ExpireDate = 0;
                                //DateTime dtEX;
                                //if (DateTime.TryParse(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString(), out dtEX))
                                //{
                                //    if (dtEX != null)
                                //        order.ExpiryDate = Convert.ToDateTime(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString());
                                //}
                                order.Gateway = sym.Gateway;
                                order.OrderID = 0;
                                order.OrderType = (char)Cls.ClsGlobal.DDOrderTypes["MARKET"];
                                order.PositionEffect = 'O';
                                order.Price = _askPrice;
                                order.Product = sym.Product;
                                order.OrderQty = Convert.ToDouble(Properties.Settings.Default.MarketWatchTradingDefaultQuantity);//Convert.ToUInt32(cbVolume.SelectedItem.ToString());
                                order.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                                order.Side = clsHashDefine.SIDE_SELL;
                                order.StopPx = 0;
                                order.TimeInForce = (char)Cls.ClsGlobal.DDValidity["DAY"];
                                order.origClOrdId = "";
                                order.LnkdOrdId = "";
                                clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
                            }
                            else
                            {
                                OnPlaceOrderClick(null, null);
                            }
                        }
                        else if (uctlMarketWatch1.ui_uctlGridMarketWatch.Columns[iCollIndex].Name == "ClmSellPrice")
                        {
                            if (Properties.Settings.Default.DirectMarketExecution)
                            {
                                var order = new ClsNewOrder();
                                string productType = sym.ProductType;
                                string pType = string.Empty;
                                switch (productType)
                                {
                                    case "EQUITY":
                                        pType = "EQ";
                                        break;
                                    case "FUTURE":
                                        pType = "FUT";
                                        break;
                                    case "FOREX":
                                        pType = "FX";
                                        break;
                                    case "OPTION":
                                        pType = "OPT";
                                        break;
                                    case "SPOT":
                                        pType = "SP";
                                        break;
                                    case "PHYSICAL":
                                        pType = "PH";
                                        break;
                                    case "AUCTION":
                                        pType = "AU";
                                        break;
                                    case "BOND":
                                        pType = "BON";
                                        break;
                                }
                                ;
                                order.Account = clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
                                order.ClOrdId = ClsGlobal.GetClientOrderID().ToString();
                                order.Contract = sym.Contract;
                                order.ExpireDate = 0;
                                order.ProductType = Convert.ToChar(Cls.ClsGlobal.DDProductTypes[pType]);
                                order.Gateway = sym.Gateway;
                                order.OrderID = 0;
                                order.OrderType = (char)Cls.ClsGlobal.DDOrderTypes["MARKET"];
                                order.PositionEffect = 'O';
                                order.Price = _bidPrice;
                                order.Product = sym.Product;
                                order.OrderQty = Convert.ToDouble(Properties.Settings.Default.MarketWatchTradingDefaultQuantity);//Convert.ToUInt32(cbVolume.SelectedItem.ToString());                                                                
                                order.Side = clsHashDefine.SIDE_BUY;
                                order.StopPx = 0;
                                order.TimeInForce = (char)Cls.ClsGlobal.DDValidity["DAY"];
                                order.origClOrdId = "";
                                order.LnkdOrdId = "";


                                clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
                            }
                            else
                            {
                                OnPlaceOrderClick(null, null);
                            }
                        }
                    }
                }

                OnChartClick(sender, e);
            }
        }

        void ui_ndgvGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Namo 21 March
            //if (iRowIndex > -1 && iCollIndex > -1)
            //{
            //    if (Properties.Settings.Default.EnableTradingOnMarketWatch)
            //    {
            //        if (Properties.Settings.Default.SingleClickOrderSubmit)
            //        {
            //            double _askPrice = 0.0;
            //            double _bidPrice = 0.0;
            //            if (!String.IsNullOrEmpty(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmSellPrice"].Value.ToString()))
            //            {
            //                _askPrice = Convert.ToDouble(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmSellPrice"].Value.ToString());
            //            }
            //            if (!string.IsNullOrEmpty(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmBuyPrice"].Value.ToString()))
            //            {
            //                _bidPrice = Convert.ToDouble(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmBuyPrice"].Value.ToString());
            //            }
            //            Symbol sym = Symbol.GetSymbol(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmInstrumentId"].Value.ToString());
            //            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Columns[iCollIndex].Name == "ClmBuyPrice")
            //            {
            //                if (Properties.Settings.Default.DirectMarketExecution)
            //                {
            //                    ClsNewOrder order = new ClsNewOrder();
            //                    string productType = sym.ProductType;
            //                    string pType = string.Empty;
            //                    switch (productType)
            //                    {
            //                        case "EQUITY":
            //                            pType = "EQ";
            //                            break;
            //                        case "FUTURE":
            //                            pType = "FUT";
            //                            break;
            //                        case "FOREX":
            //                            pType = "FX";
            //                            break;
            //                        case "OPTION":
            //                            pType = "OPT";
            //                            break;
            //                        case "SPOT":
            //                            pType = "SP";
            //                            break;
            //                        case "PHYSICAL":
            //                            pType = "PH";
            //                            break;
            //                        case "AUCTION":
            //                            pType = "AU";
            //                            break;
            //                        case "BOND":
            //                            pType = "BON";
            //                            break;
            //                    }
            //                    ;
            //                    order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
            //                    order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //                    order.ContractName = sym.Contract;
            //                    DateTime dtEX;
            //                    if (DateTime.TryParse(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString(), out dtEX))
            //                    {
            //                        if (dtEX != null)
            //                            order.ExpiryDate = Convert.ToDateTime(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString());
            //                    }
            //                    order.GatewayName = sym.Gateway;
            //                    order.MinorDisclosedQty = 0;
            //                    order.OrderID = 0;
            //                    order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
            //                    order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
            //                    order.Price = _askPrice;
            //                    order.ProductName = sym.Product;
            //                    order.Qty = Convert.ToDouble(Properties.Settings.Default.MarketWatchTradingDefaultQuantity);//Convert.ToUInt32(cbVolume.SelectedItem.ToString());
            //                    order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
            //                    order.Side = (sbyte)clsHashDefine.SIDE_SELL;
            //                    order.StopPX = 0;
            //                    order.StrProductType = sym.ProductType;
            //                    order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
            //                    clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            //                }
            //                else
            //                {
            //                    OnPlaceOrderClick(null, null);
            //                }
            //            }
            //            else if (uctlMarketWatch1.ui_uctlGridMarketWatch.Columns[iCollIndex].Name == "ClmSellPrice")
            //            {
            //                if (Properties.Settings.Default.DirectMarketExecution)
            //                {
            //                    ClsNewOrder order = new ClsNewOrder();
            //                    string productType = sym.ProductType;
            //                    string pType = string.Empty;
            //                    switch (productType)
            //                    {
            //                        case "EQUITY":
            //                            pType = "EQ";
            //                            break;
            //                        case "FUTURE":
            //                            pType = "FUT";
            //                            break;
            //                        case "FOREX":
            //                            pType = "FX";
            //                            break;
            //                        case "OPTION":
            //                            pType = "OPT";
            //                            break;
            //                        case "SPOT":
            //                            pType = "SP";
            //                            break;
            //                        case "PHYSICAL":
            //                            pType = "PH";
            //                            break;
            //                        case "AUCTION":
            //                            pType = "AU";
            //                            break;
            //                        case "BOND":
            //                            pType = "BON";
            //                            break;
            //                    }
            //                    ;
            //                    order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
            //                    order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //                    order.ContractName = sym.Contract;
            //                    DateTime dtEX;
            //                    if (DateTime.TryParse(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString(), out dtEX))
            //                    {
            //                        if (dtEX != null)
            //                            order.ExpiryDate = Convert.ToDateTime(uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[iRowIndex].Cells["ClmExpiry"].Value.ToString());
            //                    }
            //                    order.GatewayName = sym.Gateway;
            //                    order.MinorDisclosedQty = 0;
            //                    order.OrderID = 0;
            //                    order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
            //                    order.PositionEffect = (sbyte)clsHashDefine.POSITION_OPENING_TRADE;
            //                    order.Price = _bidPrice;
            //                    order.ProductName = sym.Product;
            //                    order.Qty = (uint)Properties.Settings.Default.MarketWatchTradingDefaultQuantity;//Convert.ToUInt32(cbVolume.SelectedItem.ToString());
            //                    order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];
            //                    order.Side = (sbyte)clsHashDefine.SIDE_BUY;
            //                    order.StopPX = 0;
            //                    order.StrProductType = sym.ProductType;
            //                    order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
            //                    clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
            //                }
            //                else
            //                {
            //                    OnPlaceOrderClick(null, null);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        int iRowIndex = -1;
        int iCollIndex = -1;
        void ui_ndgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iRowIndex = e.RowIndex;
            iCollIndex = e.ColumnIndex;
        }

        void ui_ndgvGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventHandler e)
        {

        }


        void uctlMarketWatch1_OnDoubleClicck(object arg1, System.EventArgs arg2)
        {

        }



        private void ctlMarketWatch_Load(object sender, EventArgs e)
        {
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into frmMarketWatch_Load Method");

            //objfrmOrderEntry.Dispose();
            var ContextMenuItems = new ToolStripMenuItem[4];
            ResizeRedraw = false;
            //Width = MdiParent.Width - 20;
            //MainMenuStrip = MdiParent.MainMenuStrip;
            //ContextMenuItems[0] = new ToolStripMenuItem("Buy Order");
            //ContextMenuItems[0].Name = "BuyOrder";
            //ContextMenuItems[0].Enabled = false;
            //ContextMenuItems[0].ShortcutKeys = ShortcutKeyBOE;
            //ContextMenuItems[0].Click += OnBuyOrderClick;
            //ContextMenuItems[1] = new ToolStripMenuItem("Sell Order");
            //ContextMenuItems[1].Name = "SellOrder";
            //ContextMenuItems[1].Enabled = false;
            //ContextMenuItems[1].ShortcutKeys = ShortcutKeySOE;
            //ContextMenuItems[1].Click += OnSellOrderClick;


            ContextMenuItems[3] = new ToolStripMenuItem("Chart");
            ContextMenuItems[3].Name = "Chart";
            ContextMenuItems[3].Enabled = false;
            ContextMenuItems[3].Click += OnChartClick;
            //ContextMenuItems[2] = new ToolStripMenuItem("Market Picture");
            //ContextMenuItems[2].Name = "MarketPicture";
            //ContextMenuItems[2].Enabled = false;
            //ContextMenuItems[2].Click += OnMarketPictureClick;
            ContextMenuItems[1] = new ToolStripMenuItem("Place Order");
            ContextMenuItems[1].Name = "PlaceOrder";
            ContextMenuItems[1].Enabled = false;
            ContextMenuItems[1].ShortcutKeys = ShortcutKeyOE;
            ContextMenuItems[1].Click += OnPlaceOrderClick;


            ContextMenuItems[2] = new ToolStripMenuItem("Level2 Data");
            ContextMenuItems[2].Name = "Level2Data";
            ContextMenuItems[2].Enabled = false;
            ContextMenuItems[2].Click += OnLevel2Click;

            ContextMenuItems[0] = new ToolStripMenuItem("Matrix");
            ContextMenuItems[0].Name = "Matrix";
            ContextMenuItems[0].Enabled = false;
            ContextMenuItems[0].Visible = false;
            ContextMenuItems[0].Click += OnMatrixClick;
            //ContextMenuItems[0].Visible = false;

            foreach (ToolStripMenuItem item in ContextMenuItems)
            {
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items.Insert(0, item);
            }
            if (uctlMarketWatch1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlMarketWatch1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.MarketWatchProfile + "_" + ProfileTypes.MarketWatch.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.MarketWatchProfile + "_" + ProfileTypes.MarketWatch.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
                }
            }
            DoubleBuffered(uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid, true);
            if (uctlMarketWatch1.CurrentPortfolioName != string.Empty)
            {
                uctlMarketWatch1_OnScriptPortfolioApplyClick(uctlMarketWatch1.CurrentPortfolioName);
            }
            else if (_objPortfolio != null && ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().Contains(
                        Properties.Settings.Default.MarketWatchPortfolio))
                {
                    int index =
                        ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList().IndexOf(
                            Properties.Settings.Default.MarketWatchPortfolio);
                    uctlMarketWatch1_OnScriptPortfolioApplyClick(
                        ((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.ToList()[index]);
                }
            }

            uctlMarketWatch1.ui_uctlGridMarketWatch.DataSource = marketDS.dtMarketWatch;
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -= marketWatch_onSnapShotUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += marketWatch_onSnapShotUpdate;

            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from frmMarketWatch_Load Method");
        }

        public event Action<DataGridViewRow> OnSymbolMatrixClick = delegate { };
        private void OnMatrixClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnLevel2Click Method");
            string sym = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Cells["ClmContractName"].Value.ToString();
            if (sym != null)
            {
                //InstrumentId
                //OnSymbolLevel2Click(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Cells["ClmInstrumentId"].Value.ToString());
                OnSymbolMatrixClick(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0]);
            }
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnLevel2Click Method");
        }


        public event Action<DataGridViewRow> OnSymbolLevel2Click = delegate { };
        private void OnLevel2Click(object sender, EventArgs e)
        {

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnLevel2Click Method");
            //Namo 21 March
            //if (clsTWSOrderManagerJSON.INSTANCE.IsDemo)
            //{
            //    MessageBox.Show("Please open Live account to view the Level2 Data.");
            //}
            //else
            {
                string sym = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0].Cells["ClmContractName"].Value.ToString();
                if (sym != null)
                {
                    OnSymbolLevel2Click(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0]);
                }
            }
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnLevel2Click Method");
        }


        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DoubleBuffered Method");
        }
        //Namo 21 March
        //private void marketWatch_onSnapShotUpdate(Dictionary<string, QuoteSnapshot> DDQuoteSnapshot)
        //{
        //    //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into marketWatch_onSnapShotUpdate Method");

        //    foreach (var item in DDQuoteSnapshot)
        //    {
        //        if (uctlMarketWatch1._DDRows.Count == 0)
        //            return;
        //        KeyValuePair<string, QuoteSnapshot> item1 = item;
        //        Action A = () =>
        //        {
        //            DataRow row = null;
        //            if (uctlMarketWatch1._DDRows.TryGetValue(item1.Key, out row))
        //            {
        //                string contract = item1.Key.Substring(item1.Key.LastIndexOf('_') + 1);
        //                Symbol sym = Symbol.GetSymbol(item1.Key);
        //                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
        //                string format = "0.";
        //                for (int i = 0; i < instspec.Digits; i++)
        //                {
        //                    format += "0";
        //                }
        //                if (PALSA.Cls.ClsGlobal.DDRightZLevel.Keys.Contains(contract))
        //                {
        //                    row["SellPrice"] = PALSA.Cls.ClsGlobal.DDRightZLevel[contract].ToString(format);
        //                    if (PALSA.Cls.ClsGlobal.DDRightZLevelQty.Keys.Contains(contract))
        //                    {
        //                        row["SellQty"] = PALSA.Cls.ClsGlobal.DDRightZLevelQty[contract];
        //                    }
        //                }
        //                if (PALSA.Cls.ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
        //                {
        //                    row["BuyPrice"] = PALSA.Cls.ClsGlobal.DDLeftZLevel[contract].ToString(format);
        //                    if (PALSA.Cls.ClsGlobal.DDLeftZLevelQty.Keys.Contains(contract))
        //                    {
        //                        row["BuyQty"] = PALSA.Cls.ClsGlobal.DDLeftZLevelQty[contract];
        //                    }
        //                }
        //                row["ClosePrice"] = item1.Value._Close.ToString(format);
        //                row["PrevHigh"] = item1.Value._High.ToString(format);
        //                row["High"] = item1.Value._High.ToString(format);
        //                row["LTP"] = item1.Value._LastPrice.ToString(format);
        //                //row[""] = item.Value._LastSize;
        //                //row[""] = item.Value._LastTime;
        //                DateTime dtx = DateTime.UtcNow;
        //                string date = string.Empty;
        //                if (dtx != DateTime.MinValue)
        //                {
        //                    date = string.Format(
        //                                Properties.Settings.Default.TimeFormat.Contains("24")
        //                                    ? "{0:dd/MM/yyyy HH:mm:ss}"
        //                                    : "{0:dd/MM/yyyy hh:mm:ss tt}", dtx);
        //                }
        //                row["LastUpdatedTime"] = date;//clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item1.Value._LastUpdatedTime);


        //                //if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //                //    row["LastUpdatedTime"] =
        //                //        DateTime.Parse(
        //                //            clsUtility.GetDateTime(item.Value._LastUpdatedTime).ToShortDateString
        //                //                ()).ToString("HH:mm:ss tt");
        //                //else
        //                //    row["LastUpdatedTime"] =
        //                //        clsUtility.GetDateTime(item.Value._LastUpdatedTime).ToString(
        //                //            "hh:mm:ss tt");
        //                row["PrevLow"] = item1.Value._Low.ToString(format);
        //                row["Low"] = item1.Value._Low.ToString(format);
        //                //row[""] = quoteSnapshot._MarketDepthLevel;
        //                row["OpenPrice"] = item1.Value._Open.ToString(format);
        //                //row[""] = quoteSnapshot._Symbol;
        //                row["Volume"] = item1.Value._Volume;
        //                //row[""] = quoteSnapshot._VolumePercent;
        //                //row[""] = quoteSnapshot._WeeksHigh52;
        //                //row[""] = quoteSnapshot._WeeksLow52;
        //            }
        //            else
        //            {
        //            }
        //        };
        //        if (InvokeRequired)
        //        {
        //            BeginInvoke(A);
        //        }
        //        else
        //        {
        //            A();
        //        }
        //    }
        //    //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from marketWatch_onSnapShotUpdate Method");
        //}
        private void marketWatch_onPriceUpdate(Dictionary<string, Quote> DDQuote)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into marketWatch_onPriceUpdate Method");

            foreach (var item in DDQuote)
            {
                marketWatch_onPriceUpdate(item.Key, item.Value);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from marketWatch_onPriceUpdate Method");
        }

        private void marketWatch_onPriceUpdate(string key, Quote Quote)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into marketWatch_onPriceUpdate Method");

            if (InvokeRequired)
            {
                BeginInvoke(new PriceQuoteHandler(marketWatch_onPriceUpdate), key, Quote);
                return;
            }
            else
            {
                if (uctlMarketWatch1._DDRows.Count == 0)
                    return;
                DataRow row = null;
                //SuspendLayout();
                if (uctlMarketWatch1._DDRows.TryGetValue(key, out row))
                {
                    //Namo 21 March
                    //List<QuoteItem> lst = Quote._lstItem;
                    //int lstCount = lst.Count;
                    //for (int iListLoop = 0; iListLoop < lstCount; iListLoop++)
                    //{
                    //    if (lst[iListLoop]._MarketLevel != 0)
                    //        continue;
                    //    UpdateQuote(lst[iListLoop], row);
                    //}
                }
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from marketWatch_onPriceUpdate Method");
        }

        private void UpdateQuote(QuoteItem quoteItem, DataRow row)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into UpdateQuote Method");

            if (InvokeRequired)
            {
                BeginInvoke(new UpdateQuoteHandler(UpdateQuote), row, quoteItem);
                return;
            }
            else
            {
                int index = marketDS.dtMarketWatch.Rows.IndexOf(row);
                DateTime dtx = ClsGlobal.GetDateTimeDT(quoteItem._Time);
                string date = string.Empty;
                if (dtx != DateTime.MinValue)
                {
                    date = string.Format(
                               Properties.Settings.Default.TimeFormat.Contains("24")
                                   ? "{0:HH:mm:ss}"
                                   : "{0:hh:mm:ss tt}", dtx);
                }
                row["LastUpdatedTime"] = date;                
                Symbol sym = Symbol.GetSymbol(row["InstrumentId"].ToString());
               // InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                string format = "0.";
                for (int i = 0; i < instspec.Digits; i++)
                {
                    format += "0";
                }

                switch (quoteItem._quoteType)
                {
                    case QuoteStreamType.CLOSE:
                        {
                            row["ClosePrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
                        }
                        break;
                    case QuoteStreamType.OPEN:
                        {
                            row["OpenPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
                        }
                        break;
                    case QuoteStreamType.ASK:
                        {
                            row["SellPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
                            row["SellQty"] = quoteItem._Size;
                            if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                            {
                                row["SellPriceState"] = "DOWN";
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.White;
                            }
                            else if (quoteItem._status == QuoteItemStatus.UP) //UP
                            {
                                row["SellPriceState"] = "UP";
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.White;
                            }
                            else //Unchanged
                            {
                                row["SellPriceState"] = string.Empty;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.Black;
                            }
                        }
                        break;
                    case QuoteStreamType.BID:
                        {
                            row["BuyPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
                            row["BuyQty"] = quoteItem._Size;

                            if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                            {
                                row["BuyPriceState"] = "DOWN";
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = downimg;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
                            }
                            else if (quoteItem._status == QuoteItemStatus.UP) //UP
                            {
                                row["BuyPriceState"] = "UP";
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = upimg;

                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
                            }
                            else //Unchanged
                            {
                                row["BuyPriceState"] = string.Empty;
                                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\Unchanged.png");
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.Black;
                            }
                        }
                        break;
                    case QuoteStreamType.HIGH:
                        {
                            row["High"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format); ;
                            if (quoteItem._status == QuoteItemStatus.DOWN)
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                            }
                            else if (quoteItem._status == QuoteItemStatus.UP)
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                            }
                            else //Unchanged
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
                            }
                        }
                        break;
                    case QuoteStreamType.LAST:
                        {
                            //if (Properties.Settings.Default.TimeFormat.Contains("24"))
                            //{
                            //    row["LastUpdatedTime"] = string.Format("{0: HH:mm:ss}", clsUtility.GetDateTime(quoteItem._Time));

                            //}
                            //else
                            //{
                            //    row["LastUpdatedTime"] = string.Format("{0: hh:mm:ss tt}", clsUtility.GetDateTime(quoteItem._Time));             
                            //}

                            if (quoteItem._status == QuoteItemStatus.DOWN) //Down
                            {
                                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                //    Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value = Convert.ToDecimal(quoteItem._Price);
                            }
                            else if (quoteItem._status == QuoteItemStatus.UP) //UP
                            {
                                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
                                //    Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value = Convert.ToDecimal(quoteItem._Price);
                            }
                            else //Unchanged
                            {
                                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\Unchanged.png");
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value = Convert.ToDecimal(quoteItem._Price);
                            }
                        }
                        break;
                    case QuoteStreamType.LOW:
                        {
                            row["Low"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
                            if (quoteItem._status == QuoteItemStatus.DOWN)
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor = uctlMarketWatch1.DownTrendColor;
                            }
                            else if (quoteItem._status == QuoteItemStatus.UP)
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor = uctlMarketWatch1.UpTrendColor;
                            }
                            else //Unchanged
                            {
                                uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
                            }
                        }
                        break;
                    case QuoteStreamType.VOLUME:
                        {
                            row["Volume"] = quoteItem._Size;
                        }
                        break;
                    case QuoteStreamType.VOLUME_PER:
                        {
                        }
                        break;
                    default:
                        break;
                }
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from UpdateQuote Method");
        }

        private void ApplyDefaultProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into ApplyDefaultProfile Method");

            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlMarketWatch1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
            foreach (DataGridViewColumn col in uctlMarketWatch1.ui_uctlGridMarketWatch.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from ApplyDefaultProfile Method");
        }

        private void OnProfileApplyClick(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnProfileApplyClick Method");
            if (_objProfiles != null)
            {
                if (
                    !((Dictionary<string, ClsProfile>)_objProfiles).Keys.Contains(profileName + "_" +
                                                                                   ProfileTypes.MarketWatch.ToString()))
                    return;
                ClsProfile profile =
                    ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.MarketWatch.ToString()];
                foreach (DataGridViewColumn col in uctlMarketWatch1.ui_uctlGridMarketWatch.Columns)
                {
                    ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                    col.DisplayIndex = colsetting.Index;
                    col.Visible = colsetting.Visible;
                }

            }
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnProfileApplyClick Method");
        }

        /// <summary>
        /// Called when user select the BuyOrder option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBuyOrderClick(object sender, EventArgs e)
        {
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnBuyOrderClick Method");

            //if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
            //    DisplayOrderEntryDialog("BUY", Properties.Settings.Default.BuyOrderColor, "Buy Order Entry",
            //                            CommandIDS.PLACE_BUY_ORDER.ToString(), selectedRow);
            //}

            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnBuyOrderClick Method");
        }

        public void OnPlaceOrderClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnBuyOrderClick Method");

            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
                DisplayOrderEntry(selectedRow);
            }
            else
            {
                DisplayOrderEntry(null);
            }
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnBuyOrderClick Method");
        }
        private void DisplayOrderEntry(DataGridViewRow selectedRow)
        {
            //if (selectedRow == null)
            //{
            if (selectedRow.Cells["ClmContractName"].Value.ToString().Trim() != "")
            {
                frmOrderEntry orderentry = new frmOrderEntry(selectedRow, CommonLibrary.Cls.ClsGlobal.OrderMode.NEW);
                orderentry.ShowDialog();
            }
            //}
            //else
            //{
            //    frmOrderEntry orderentry = new frmOrderEntry(selectedRow, CommonLibrary.Cls.ClsGlobal.OrderMode.NEW);
            //    orderentry.ShowDialog();
            //}
        }
        /// <summary>
        /// Called when user select the SellOrder option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSellOrderClick(object sender, EventArgs e)
        {
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnSellOrderClick Method");

            //if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
            //    DisplayOrderEntryDialog("SELL", Properties.Settings.Default.SellOrderColor, "Sell Order Entry",
            //                            CommandIDS.PLACE_SELL_ORDER.ToString(), selectedRow);
            //}

            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnSellOrderClick Method");
        }

        public event Action<DataGridViewRow> OnSymbolChartClick = delegate { };

        private void OnChartClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnChartClick Method");

            OnSymbolChartClick(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0]);
            //frmChart objfrmChart = new frmChart();
            //objfrmChart.MdiParent = this.ParentForm;
            //objfrmChart.Show();
            //objfrmChart.InitChartData(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0]);           
            //var objfrmNewChart = new frmNewChart();
            //objfrmNewChart.MdiParent = ParentForm;
            //objfrmNewChart.Show();
            //objfrmNewChart.InitChartData(uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0]);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnChartClick Method");
            // OnNewChart();
        }
        /// <summary>
        /// Called when user select the Market Picture option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMarketPictureClick(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into OnMarketPictureClick Method");

            if (uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = uctlMarketWatch1.ui_uctlGridMarketWatch.SelectedRows[0];
                DisplayMarketPictureDialog(selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from OnMarketPictureClick Method");
        }
        public event Action<string> OnScriptPortfolioApplyClick;
        public void uctlMarketWatch1_OnScriptPortfolioApplyClick(string portfolioName, DataTable dt = null)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnScriptPortfolioApplyClick Method");

            marketDS.dtMarketWatch.Rows.Clear();
            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DataSource = marketDS.dtMarketWatch;
            //uctlMarketWatch1.ui_uctlGridMarketWatch.AutoSize = true;
            //uctlMarketWatch1.AutoSize = true;
            if (portfolioName != string.Empty)
            {
                //Title = uctlMarketWatch1.Title + " - " + portfolioName;            
                _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" + portfolioName + "/" + uctlMarketWatch1.CurrentProfileName;

                if (((Dictionary<string, ClsPortfolio>)_objPortfolio).Keys.Contains(portfolioName))
                {
                    ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)_objPortfolio)[portfolioName];
                    marketDS.dtMarketWatch.Rows.Clear();
                    uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.DataSource = marketDS.dtMarketWatch;
                    uctlMarketWatch1._DDRows.Clear();
                    int keycount = objPortfolio.Products.Keys.Count;
                    var lst = new List<Symbol>();
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            marketDS.dtMarketWatch.ImportRow(dr);
                            Symbol sym = Symbol.GetSymbol(dr["InstrumentID"].ToString());
                            uctlMarketWatch1._DDRows.Add(sym.KEY, marketDS.dtMarketWatch.Rows[dt.Rows.IndexOf(dr)]);
                            lst.Add(sym);
                        }
                    }
                    else
                    {
                        foreach (string key in objPortfolio.Products.Keys)
                        {
                            DataRow dr = marketDS.dtMarketWatch.NewRow();
                            marketDS.dtMarketWatch.Rows.Add(dr);
                            int index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                            Symbol sym = Symbol.GetSymbol(key);
                            uctlMarketWatch1._DDRows.Add(sym.KEY, marketDS.dtMarketWatch.Rows[index]);
                            InstrumentSpec inspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                            //InstrumentSpec inspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
                            if (inspec != null)
                            {
                                marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                                marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = sym.KEY;
                                marketDS.dtMarketWatch.Rows[index]["ProductType"] = inspec.ProductType;
                                marketDS.dtMarketWatch.Rows[index]["ULAsset"] = inspec.UL_Asset;
                                marketDS.dtMarketWatch.Rows[index]["ProductName"] = inspec.Product;
                                DateTime exp = DateTime.Now;
                                DateTime.TryParse(inspec.ExpiryDate, out exp);
                                marketDS.dtMarketWatch.Rows[index]["Expiry"] = exp.ToString("dd/MM/yyyy"); ;
                                marketDS.dtMarketWatch.Rows[index]["StrikePrice"] = 0;
                                marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                                marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] = Convert.ToString(inspec.PriceQuantity);
                                lst.Add(sym);
                            }
                        }
                    }
                    _currentPortfolio = portfolioName;
                    ClsGlobal.CurrentPortfolio = portfolioName;
                    if (clsTWSDataManagerJSON.INSTANCE.IsDataMgrConnected || dt != null)
                    {
                        clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(eMarketRequest.MARKET_QUOTE_REQUEST, lst);
                    }
                    else
                    {
                        ClsCommonMethods.ShowErrorBox("Data Manager is not Connected.");
                    }
                    OnScriptPortfolioApplyClick(portfolioName);
                }
                else
                {
                    ClsCommonMethods.ShowErrorBox("Portfolio *" + portfolioName + "* is not found.");
                }
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnScriptPortfolioApplyClick Method");
        }

        private void uctlMarketWatch1_OnScriptPortfolioModifyClick(string portfolioName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnScriptPortfolioModifyClick Method");

            var objfrmPortfolio = new frmPortfolio(_objPortfolio, portfolioName, _userCode);
            objfrmPortfolio.ShowDialog();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnScriptPortfolioModifyClick Method");
        }

        private void uctlMarketWatch1_OnScriptPortfolioRemoveClick(string portfolioName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnScriptPortfolioRemoveClick Method");

            ((Dictionary<string, ClsPortfolio>)_objPortfolio).Remove(portfolioName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnScriptPortfolioRemoveClick Method");
        }

        private void uctlMarketWatch1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnProfileRemoveClick Method");

            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnProfileRemoveClick Method");
        }

        private void uctlMarketWatch1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnSetDefaultProfileClick Method");

            Properties.Settings.Default.MarketWatchProfile = profileName; //by vijay
            Properties.Settings.Default.Save(); //by vijay
            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            Properties.Settings.Default.MarketWatchProfile = profileName;
            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            streamWrite.Close();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnSetDefaultProfileClick Method");
        }

        private void uctlMarketWatch1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnProfileSaveClick Method");

            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnProfileSaveClick Method");
        }

        private void uctlMarketWatch1_OnUpDownTrendColorChanged(Color upColor, Color downColor, Color alertTriggerColor)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnUpDownTrendColorChanged Method");

            Properties.Settings.Default.UpTrendColor = upColor;
            Properties.Settings.Default.DownTrendColor = downColor;
            Properties.Settings.Default.AlertTriggerColor = alertTriggerColor;

            Properties.Settings.Default.Save();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnUpDownTrendColorChanged Method");
        }
        //GridHitInfo downHitInfo = null;
        private void uctlMarketWatch1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into uctlMarketWatch1_OnGridMouseDown Method");

            DataGridView.HitTestInfo hitTestInfo = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.HitTest(arg2.X,
                                                                                                               arg2.Y);
            if (hitTestInfo.RowIndex < 0)
            {
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["PlaceOrder"].Enabled = false;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = false;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = false;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Chart"].Enabled = false;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Matrix"].Enabled = false;
            }
            else
            {
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["PlaceOrder"].Enabled = true;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["BuyOrder"].Enabled = true;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["SellOrder"].Enabled = true;
                //uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["MarketPicture"].Enabled = true;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Chart"].Enabled = true;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Level2Data"].Enabled = true;
                uctlMarketWatch1.ui_uctlGridMarketWatch.ContextMenuStrip.Items["Matrix"].Enabled = true;
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from uctlMarketWatch1_OnGridMouseDown Method");
        }

        private void uctlMarketWatch1_OnMouseMove(object arg1, MouseEventArgs arg2)
        {

        }

        private void uctlMarketWatch1_OnDragDrop(object arg1, System.Windows.Forms.DragEventArgs arg2)
        {

        }

        void uctlMarketWatch1_OnGridDragOver(object arg1, System.Windows.Forms.DragEventArgs arg2)
        {

        }

        private void DisplayOrderEntryDialog(string title, Color color, string formTitle, string formKey,
                                             DataGridViewRow selectedRow)
        {
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DisplayOrderEntryDialog Method");

            //if (frmOrderEntry.INSTANCE.IsDisposed)
            //{
            //    frmOrderEntry.INSTANCE = new frmOrderEntry(selectedRow, CommonLibrary.Cls.ClsGlobal.OrderMode.NEW);
            //    frmOrderEntry.INSTANCE.Formkey = formKey;
            //    frmOrderEntry.INSTANCE.FormText = formTitle;
            //    frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            //    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //    frmOrderEntry.INSTANCE.MdiParent = FrmMain.INSTANCE;
            //    frmOrderEntry.INSTANCE.Show();
            //    frmOrderEntry.INSTANCE.FillValues(selectedRow);
            //}
            //else
            //{
            //    frmOrderEntry.INSTANCE.Formkey = formKey;
            //    frmOrderEntry.INSTANCE.FormText = formTitle;
            //    frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = title;
            //    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //    frmOrderEntry.INSTANCE.MdiParent = FrmMain.INSTANCE;
            //    frmOrderEntry.INSTANCE.Show();
            //    frmOrderEntry.INSTANCE.FillValues(selectedRow);
            //    frmOrderEntry.INSTANCE.Activate();
            //}


            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DisplayOrderEntryDialog Method");
        }

        private void DisplayMarketPictureDialog(DataGridViewRow selectedRow)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DisplayMarketPictureDialog Method");

            if (frmMarketPicture.Count < 4)
            {
                var objMarketPicture = new frmMarketPicture();
                objMarketPicture.StartPosition = FormStartPosition.CenterScreen;
                objMarketPicture.MdiParent = ParentForm;
                objMarketPicture.Show();
                objMarketPicture.SetValuesToMarketPicture(selectedRow);
            }

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DisplayMarketPictureDialog Method");
        }

        public void AddRowToMarketWatch(string key, InstrumentSpec objInstrumentSpec)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into AddRowToMarketWatch Method");

            var lst = new List<Symbol>();

            var sym = Symbol.GetSymbol(key);
            if (!uctlMarketWatch1._DDRows.Keys.Contains(key))
            {
                var dr = marketDS.dtMarketWatch.NewRow();
                marketDS.dtMarketWatch.Rows.Add(dr);
                //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows.Add(1);
                var index = marketDS.dtMarketWatch.Rows.IndexOf(dr);
                uctlMarketWatch1._DDRows.Add(key, marketDS.dtMarketWatch.Rows[index]);
                if (objInstrumentSpec != null)
                {
                    marketDS.dtMarketWatch.Rows[index]["ContractName"] = sym.Contract;
                    marketDS.dtMarketWatch.Rows[index]["InstrumentId"] = key;
                    marketDS.dtMarketWatch.Rows[index]["ProductType"] = objInstrumentSpec.ProductType;
                    marketDS.dtMarketWatch.Rows[index]["ULAsset"] = objInstrumentSpec.UL_Asset;
                    marketDS.dtMarketWatch.Rows[index]["ProductName"] = objInstrumentSpec.Product;
                    DateTime exp = DateTime.Now;
                    DateTime.TryParse(objInstrumentSpec.ExpiryDate, out exp);
                    marketDS.dtMarketWatch.Rows[index]["Expiry"] = exp.ToString("dd/MM/yyyy"); ;
                    marketDS.dtMarketWatch.Rows[index]["Status"] = "";
                    marketDS.dtMarketWatch.Rows[index]["PriceQuotationUnit"] =
                        Convert.ToString(objInstrumentSpec.PriceQuantity);
                    marketDS.dtMarketWatch.Rows[index]["Specification"] = objInstrumentSpec.Specification;
                    marketDS.dtMarketWatch.AcceptChanges();
                    lst.Add(sym);
                }
                clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(eMarketRequest.MARKET_QUOTE_REQUEST, lst);
            }
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from AddRowToMarketWatch Method");
        }

        private void SaveProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into SaveProfile Method");

            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            uctlMarketWatch1.CurrentProfileName = profileName;
            _formkey = CommandIDS.MARKET_WATCH.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlMarketWatch1.CurrentPortfolioName + "/" + profileName;
            streamWrite.Close();

            //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from SaveProfile Method");
        }

    }
}
