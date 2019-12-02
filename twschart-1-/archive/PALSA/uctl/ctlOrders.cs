using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PALSA.Cls;
using CommonLibrary.Cls;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PALSA.Frm;

namespace PALSA.uctl
{
    public partial class ctlOrders : UserControl
    {
        private static int count;
        private static DataGridViewColumn oldColumn;
        private static string dir = "Desc";
        //private string _formkey;
        private object _objProfiles;
        private string x = string.Empty;
        private int y;

        public ctlOrders(object objProfiles, string currentProfile)
        {
            InitializeComponent();
            uctlOrders.Size = ClientSize;
            _objProfiles = objProfiles;
            uctlOrders.Profiles = objProfiles;
            uctlOrders.CurrentProfileName = currentProfile;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uctlOrders.CreateContextMenu();
            uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Visible = false;
            //uctlOrders.ContextMenu.MenuItems["CANCLE"].Visible = false;
            DataGridViewCellStyle datastyle = new DataGridViewCellStyle { BackColor = SystemColors.Control, ForeColor = SystemColors.WindowText, SelectionBackColor = SystemColors.Highlight, SelectionForeColor = SystemColors.HighlightText, Alignment = DataGridViewContentAlignment.MiddleLeft };
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeadersDefaultCellStyle = datastyle;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.CellMouseDoubleClick -= new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseDoubleClick);
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(ui_ndgvGrid_CellMouseDoubleClick);
            //uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.CellValueNeeded += new DataGridViewCellValueEventHandler(ui_ndgvGrid_CellValueNeeded);
        }

        //void ui_ndgvGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //{
        //    uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.Value;
        //}

        //void INSTANCE_onPriceUpdate(Dictionary<string, ClientDLL_Model.Cls.Market.Quote> DDQuote)
        //{
        //     foreach (var item in DDQuote)
        //    {
        //        PriceUpdate(item.Key, item.Value);
        //    }
        //}

        //private void PriceUpdate(string key, ClientDLL_Model.Cls.Market.Quote Quote)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new PriceQuoteHandler(PriceUpdate), key, Quote);
        //        return;
        //    }
        //    else
        //    {
        //        if (clsTWSOrderManagerJSON.INSTANCE._DDOpenPnlRow.Count == 0)
        //            return;
        //        DataRow row = null;

        //        if (clsTWSOrderManagerJSON.INSTANCE._DDOpenPnlRow.TryGetValue(key, out row))
        //        {
        //            List<QuoteItem> lst = Quote._lstItem;
        //            int lstCount = lst.Count;
        //            for (int iListLoop = 0; iListLoop < lstCount; iListLoop++)
        //            {
        //                if (lst[iListLoop]._MarketLevel != 0)
        //                    continue;
        //                UpdateQuote(lst[iListLoop], row);
        //            }
        //        }
        //    }
        //}

        //private void UpdateQuote(QuoteItem quoteItem, DataRow row)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new UpdateQuoteHandler(UpdateQuote), row, quoteItem);
        //        return;
        //    }
        //    else
        //    {
        //        //int index = marketDS.dtMarketWatch.Rows.IndexOf(row);
        //        int index = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows.IndexOf(row);
        //        DateTime dtx = PALSA.Cls.ClsGlobal.GetDateTimeDT(quoteItem._Time);
        //        string date = string.Empty;
        //        if (dtx != DateTime.MinValue)
        //        {
        //            //date = string.Format(
        //            //            Properties.Settings.Default.TimeFormat.Contains("24")
        //            //                ? "{0:dd/MM/yyyy HH:mm:ss}"
        //            //                : "{0:dd/MM/yyyy hh:mm:ss tt}", dtx);
        //            date = string.Format(
        //                       Properties.Settings.Default.TimeFormat.Contains("24")
        //                           ? "{0:HH:mm:ss}"
        //                           : "{0:hh:mm:ss tt}", dtx);
        //        }
        //        row["LastUpdatedTime"] = date;
        //        //clsTWSOrderManagerJSON.INSTANCE.GetDateTime(quoteItem._Time);
        //        //if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //        //{
        //        //    if (quoteItem._Time.ToString() != string.Empty)
        //        //        row["LastUpdatedTime"] = string.Format("{0: HH:mm:ss}", clsUtility.GetDateTime(quoteItem._Time));
        //        //}
        //        //else
        //        //{
        //        //    if (quoteItem._Time.ToString() != string.Empty)
        //        //        row["LastUpdatedTime"] = string.Format("{0: hh:mm:ss tt}",
        //        //                                               clsUtility.GetDateTime(quoteItem._Time));
        //        //}ClsGlobal.DDContractInfo[sym.KEY];
        //        Symbol sym = Symbol.GetSymbol(row["InstrumentId"].ToString());//ClsGlobal.DDContractInfo[sym.KEY];//
        //        InstrumentSpec instspec = ClsGlobal.DDContractInfo[sym.KEY];//ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract,sym.ProductType,sym.Product);
        //        string format = "0.";
        //        for (int i = 0; i < instspec.Digits; i++)
        //        {
        //            format += "0";
        //        }

        //        switch (quoteItem._quoteType)
        //        {
        //            case QuoteStreamType.CLOSE:
        //                {
        //                    row["ClosePrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
        //                }
        //                break;
        //            case QuoteStreamType.OPEN:
        //                {
        //                    row["OpenPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
        //                }
        //                break;
        //            case QuoteStreamType.ASK:
        //                {
        //                    row["SellPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
        //                    row["SellQty"] = quoteItem._Size;
        //                    if (quoteItem._status == QuoteItemStatus.DOWN) //Down
        //                    {

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.
        //                            BackColor = uctlMarketWatch1.DownTrendColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.White;
        //                    }
        //                    else if (quoteItem._status == QuoteItemStatus.UP) //UP
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.
        //                            BackColor = uctlMarketWatch1.UpTrendColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.White;
        //                    }
        //                    else //Unchanged
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.
        //                            BackColor = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmSellPrice"].Style.ForeColor = Color.Black;
        //                    }
        //                }
        //                break;
        //            case QuoteStreamType.BID:
        //                {
        //                    row["BuyPrice"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
        //                    row["BuyQty"] = quoteItem._Size;

        //                    if (quoteItem._status == QuoteItemStatus.DOWN) //Down
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = downimg;

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor
        //                            = uctlMarketWatch1.DownTrendColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
        //                    }
        //                    else if (quoteItem._status == QuoteItemStatus.UP) //UP
        //                    {

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = upimg;

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor
        //                            = uctlMarketWatch1.UpTrendColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.White;
        //                    }
        //                    else //Unchanged
        //                    {
        //                        //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\Unchanged.png");
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.BackColor
        //                            = uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmBuyPrice"].Style.ForeColor = Color.Black;
        //                    }
        //                }
        //                break;
        //            case QuoteStreamType.HIGH:
        //                {
        //                    row["High"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format); ;
        //                    if (quoteItem._status == QuoteItemStatus.DOWN)
        //                    {

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor =
        //                            uctlMarketWatch1.DownTrendColor;
        //                    }
        //                    else if (quoteItem._status == QuoteItemStatus.UP)
        //                    {

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor =
        //                            uctlMarketWatch1.UpTrendColor;
        //                    }
        //                    else //Unchanged
        //                    {

        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmHigh"].Style.BackColor =
        //                            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
        //                    }

        //                }
        //                break;
        //            case QuoteStreamType.LAST:
        //                {
        //                    //if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //                    //{
        //                    //    row["LastUpdatedTime"] = string.Format("{0: HH:mm:ss}", clsUtility.GetDateTime(quoteItem._Time));

        //                    //}
        //                    //else
        //                    //{
        //                    //    row["LastUpdatedTime"] = string.Format("{0: hh:mm:ss tt}", clsUtility.GetDateTime(quoteItem._Time));             
        //                    //}

        //                    if (quoteItem._status == QuoteItemStatus.DOWN) //Down
        //                    {
        //                        //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
        //                        //    Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value =
        //                            Convert.ToDecimal(quoteItem._Price);
        //                    }
        //                    else if (quoteItem._status == QuoteItemStatus.UP) //UP
        //                    {
        //                        //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value =
        //                        //    Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value =
        //                            Convert.ToDecimal(quoteItem._Price);
        //                    }
        //                    else //Unchanged
        //                    {
        //                        //uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\Unchanged.png");
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLTP"].Value =
        //                            Convert.ToDecimal(quoteItem._Price);
        //                    }
        //                }
        //                break;
        //            case QuoteStreamType.LOW:
        //                {
        //                    row["Low"] = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(format);
        //                    if (quoteItem._status == QuoteItemStatus.DOWN)
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor =
        //                            uctlMarketWatch1.DownTrendColor;
        //                    }
        //                    else if (quoteItem._status == QuoteItemStatus.UP)
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor =
        //                            uctlMarketWatch1.UpTrendColor;
        //                    }
        //                    else //Unchanged
        //                    {
        //                        uctlMarketWatch1.ui_uctlGridMarketWatch.Rows[index].Cells["ClmLow"].Style.BackColor =
        //                            uctlMarketWatch1.ui_uctlGridMarketWatch.ui_ndgvGrid.BackColor;
        //                    }
        //                }
        //                break;
        //            case QuoteStreamType.VOLUME:
        //                {
        //                    row["Volume"] = quoteItem._Size;
        //                }
        //                break;
        //            case QuoteStreamType.VOLUME_PER:
        //                {
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from UpdateQuote Method");
        //}


        void ui_ndgvGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ClsCommonMethods.ShowMessageBox("Are you sure to close selected order?") == DialogResult.Yes)
            {
                uctlOrders_HandleCloseOrderClick(null, null);
            }
        }

        private void ctlOrders_Load(object sender, EventArgs e)
        {
            #region "     Add Columns to grid      "

            var columnsArray = new DataGridViewColumn[56];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmOrderNumber", "Order Number");
            columnsArray[0].DataPropertyName = "ClientOrderID";
            columnsArray[0].DefaultCellStyle = intCellStyle;

            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmClient", "Account No", false);
            columnsArray[1].DataPropertyName = "Account";
            columnsArray[1].DefaultCellStyle = intCellStyle;

            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmProductType", "Product Type", false);
            columnsArray[2].DataPropertyName = "ProductType";

            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmProductName", "Product Name", false);
            columnsArray[3].DataPropertyName = "Product";

            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmContract", "Contract");
            columnsArray[4].DataPropertyName = "Contract";

            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmSeriesExpiry", "Expiry", false);
            columnsArray[5].DataPropertyName = "ExpireDate";

            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmOrderType", "Order Type");
            columnsArray[6].DataPropertyName = "OrderType";

            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmBS", "B/S");
            columnsArray[7].DataPropertyName = "Side";

            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmOrderQuantity", "Order Qty");
            columnsArray[8].DataPropertyName = "OrderQty";
            columnsArray[8].DefaultCellStyle = intCellStyle;

            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmTotalExecutedQuantity",
                                                                "Total Executed Quantity", false);
            columnsArray[9].DataPropertyName = "CumQty";
            columnsArray[9].DefaultCellStyle = intCellStyle;

            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmPendingQuantity",
                                                                 "Pending Quantity", false);
            columnsArray[10].DataPropertyName = "LeavesQty";
            columnsArray[10].DefaultCellStyle = intCellStyle;



            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmStatus", "Status");
            columnsArray[11].DataPropertyName = "OrderStatus";

            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "clmValidity", "Validity", false);
            columnsArray[12].DataPropertyName = "TimeInForce";

            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "clmDisclosedQuantity",
                                                                 "Disclosed Quantity", false);
            columnsArray[13].DefaultCellStyle = intCellStyle;

            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "clmLastModifiedTime",
                                                                 "Last Modified Time", false);

            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "clmAvgPrice", "Average Price");
            columnsArray[15].DataPropertyName = "AvgPrice";
            columnsArray[15].DefaultCellStyle = intCellStyle;

            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "clmCommission", "Commission", false);
            columnsArray[16].DataPropertyName = "Commission";
            columnsArray[16].DefaultCellStyle = intCellStyle;
            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "clmTax", "Tax", false);
            columnsArray[17].DataPropertyName = "Tax";
            columnsArray[17].DefaultCellStyle = intCellStyle;

            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "clmOptionType", "Option Type", false);

            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "clmTradingCurrency", "Trading Currency", false);
            columnsArray[19].DataPropertyName = "TradingCurrency";

            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "clmAccountType", "Account Type",
                                                                 false);

            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "clmClientName", "Client Name", false);

            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "clmPartIdOmniId", "Part Id/Omni Id",
                                                                 false);

            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "clmNetVal", "Net Val.", false);
            columnsArray[23].DefaultCellStyle = intCellStyle;

            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "clmGoodTillDate", "Good Till Date",
                                                                 false);
            columnsArray[24].DataPropertyName = "ExpireDate";
            //
            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "clmTriggerPrice", "Trigger Price",
                                                                 false);
            columnsArray[25].DataPropertyName = "StopPx";
            columnsArray[25].DefaultCellStyle = intCellStyle;

            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "clmReason", "Reason", false);
            columnsArray[26].DataPropertyName = "Text";

            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "clmRemarks", "Remarks", false);

            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "clmCounterTM", "Counter TM", false);

            columnsArray[29] = ClsCommonMethods.CreateGridColumn(columnsArray[29], "clmEnteredBy", "Entered By", false);

            columnsArray[30] = ClsCommonMethods.CreateGridColumn(columnsArray[30], "clmModifiedBy", "Modified By", false);

            columnsArray[31] = ClsCommonMethods.CreateGridColumn(columnsArray[31], "clmSpread", "Spread", false);

            columnsArray[32] = ClsCommonMethods.CreateGridColumn(columnsArray[32], "clmReferenceNo", "Reference No.",
                                                                 false);
            columnsArray[32].DataPropertyName = "OrderID";
            columnsArray[32].DefaultCellStyle = intCellStyle;

            columnsArray[33] = ClsCommonMethods.CreateGridColumn(columnsArray[33], "clmRealValue", "Real Value", false);

            columnsArray[34] = ClsCommonMethods.CreateGridColumn(columnsArray[34], "clmYourMoneyUsed", "Your Money Used",
                                                                 false);

            columnsArray[35] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "clmCurrentMarketPrice",
                                                                 "Current market price", false);

            columnsArray[36] = ClsCommonMethods.CreateGridColumn(columnsArray[36], "clmStopLoss", "Stop Loss", false);

            columnsArray[37] = ClsCommonMethods.CreateGridColumn(columnsArray[37], "clmTakeProfit", "Take Profit", false);

            columnsArray[38] = ClsCommonMethods.CreateGridColumn(columnsArray[38], "clmSwap", "Swap", false);


            columnsArray[39] = ClsCommonMethods.CreateGridColumn(columnsArray[39], "clmProfitCurrency",
                                                                 "Profit (Currency)", false);

            columnsArray[40] = ClsCommonMethods.CreateGridColumn(columnsArray[40], "clmProfitPIPS", "Profit PIPS", false);
            columnsArray[41] = ClsCommonMethods.CreateGridColumn(columnsArray[41], "clmGateway", "GateWay", false);
            columnsArray[41].DataPropertyName = "Gateway";
            columnsArray[42] = ClsCommonMethods.CreateGridColumn(columnsArray[42], "clmColor", "Color", false);
            columnsArray[42].DataPropertyName = "Color";
            columnsArray[43] = ClsCommonMethods.CreateGridColumn(columnsArray[43], "clmTransactionTime", "Transaction Time");
            columnsArray[43].DataPropertyName = "TransactTime";
            columnsArray[43].DisplayIndex = 1;
            columnsArray[44] = ClsCommonMethods.CreateGridColumn(columnsArray[44], "clmCounterClOrdId", "CounterClOrdId", false);
            columnsArray[44].DataPropertyName = "CounterClOrdId";
            columnsArray[44].DefaultCellStyle = intCellStyle;
            columnsArray[45] = ClsCommonMethods.CreateGridColumn(columnsArray[45], "clmCounterAvgPx", "CounterAvgPx", false);
            columnsArray[45].DataPropertyName = "CounterAvgPx";
            columnsArray[45].DefaultCellStyle = intCellStyle;
            columnsArray[46] = ClsCommonMethods.CreateGridColumn(columnsArray[46], "clmGrossPL", "Gross Profit Loss", false);
            columnsArray[46].DataPropertyName = "GrossPL";
            columnsArray[46].DefaultCellStyle = intCellStyle;
            columnsArray[47] = ClsCommonMethods.CreateGridColumn(columnsArray[47], "clmPositionEffect", "PositionEffect", false);
            columnsArray[47].DataPropertyName = "PositionEffect";
            columnsArray[48] = ClsCommonMethods.CreateGridColumn(columnsArray[48], "clmCloseQuantity", "Closed Quantity", false);
            columnsArray[48].DataPropertyName = "ClosedQty";
            columnsArray[48].DefaultCellStyle = intCellStyle;
            columnsArray[49] = ClsCommonMethods.CreateGridColumn(columnsArray[49], "clmSLClOrdID", "SLClOrdID", false);
            columnsArray[49].DataPropertyName = "SLClOrdId";
            columnsArray[49].DefaultCellStyle = intCellStyle;
            columnsArray[50] = ClsCommonMethods.CreateGridColumn(columnsArray[50], "clmTPClOrdID", "TPClOrdID", false);
            columnsArray[50].DataPropertyName = "TPClOrdId";
            columnsArray[50].DefaultCellStyle = intCellStyle;
            columnsArray[51] = ClsCommonMethods.CreateGridColumn(columnsArray[51], "clmSLPrice", "SL");
            columnsArray[51].DataPropertyName = "SLPrice";
            columnsArray[51].DefaultCellStyle = intCellStyle;
            columnsArray[52] = ClsCommonMethods.CreateGridColumn(columnsArray[52], "clmTPPrice", "TP");
            columnsArray[52].DataPropertyName = "TPPrice";
            columnsArray[52].DefaultCellStyle = intCellStyle;
            columnsArray[53] = ClsCommonMethods.CreateGridColumn(columnsArray[53], "clmProfit", "Profit", false);
            columnsArray[53].DataPropertyName = "Profit";
            columnsArray[53].DefaultCellStyle = intCellStyle;
            columnsArray[54] = ClsCommonMethods.CreateGridColumn(columnsArray[54], "clmCurrentPrice", "Curr Price");
            //columnsArray[54].DataPropertyName = "Price";
            columnsArray[54].DefaultCellStyle = intCellStyle;
            columnsArray[55] = ClsCommonMethods.CreateGridColumn(columnsArray[55], "clmPnl", "Open P/L");
            columnsArray[55].DefaultCellStyle = intCellStyle;

            if (PALSA.Cls.ClsGlobal.MarketMakerAccountId > 0)
            {
                columnsArray[45].Visible = true;
                columnsArray[46].Visible = true;
                columnsArray[47].Visible = true;
            }

            uctlOrders.AddColumnsToGrid(columnsArray);

            #endregion "     Add Columns to grid      "


            //clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport -= INSTANCE_ExecutionReport;
            //clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse -= INSTANCE_OnOrderHistoryResponse;
            //clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject -= INSTANCE_OnBusinessLevelReject;
            //clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_ExecutionReport;
            //clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse += INSTANCE_OnOrderHistoryResponse;
            //clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject += INSTANCE_OnBusinessLevelReject;
            clsTWSOrderManagerJSON.INSTANCE.OnParticipantResponse += new Action<Dictionary<int, DataRow>>(INSTANCE_OnParticipantResponse);
            //Namo 21 March
            //clsTWSOrderManagerJSON.INSTANCE.onPositionOpened -= new Action(INSTANCE_OnPositionOpened);
            //clsTWSOrderManagerJSON.INSTANCE.onPositionOpened += new Action(INSTANCE_OnPositionOpened);

            if (uctlOrders.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlOrders.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.OrderBookProfile + "_" + ProfileTypes.OrderBook.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.OrderBookProfile + "_" + ProfileTypes.OrderBook.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
                }
            }
            DoubleBuffered(uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid, true);
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.DataBindingComplete -= ui_ndgvGrid_DataBindingComplete;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.DataBindingComplete += ui_ndgvGrid_DataBindingComplete;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeaderMouseClick -= ui_ndgvGrid_ColumnHeaderMouseClick;
            uctlOrders.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeaderMouseClick += ui_ndgvGrid_ColumnHeaderMouseClick;
            //Namo 21 March
            //uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen;

            Dictionary<int, DataRow> obj = clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList();
            if (obj.Keys.Count > 0)
            {
                DataRow dr = obj[obj.Keys.ToArray()[0]];

                double margin = 0;
                double balance = 0;
                double equity = 0;
                if (dr["Balance"].ToString() != string.Empty)
                    balance = Convert.ToDouble(dr["Balance"].ToString());
                if (dr["UsedMargin"].ToString() != string.Empty)
                {
                    margin = Convert.ToDouble(dr["UsedMargin"].ToString());
                    lblUsedMargin.Visible = true;
                    lblMarginLevel.Visible = true;
                    tlsMarginValue.Visible = true;
                    tlsMarginLevelValue.Visible = true;
                }
                else
                {
                    lblUsedMargin.Visible = false;
                    lblMarginLevel.Visible = false;
                    tlsMarginValue.Visible = false;
                    tlsMarginLevelValue.Visible = false;
                }
                if (tlsEquityValue.Text != string.Empty)
                    equity = Convert.ToDouble(tlsEquityValue.Text);
                tlsMarginValue.Text = Convert.ToString(Math.Round(margin, 2));
                tlsBalanceValue.Text = Convert.ToString(Math.Round(balance, 2));
                tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                tlsFreeMarginValue.Text = Convert.ToString(Math.Round(equity - margin, 2));
                tlsMarginLevelValue.Text = Convert.ToString(Math.Round(equity / margin * 100, 2));
            }

        }
        double UrPnl = 0;
        void INSTANCE_OnParticipantResponse(Dictionary<int, DataRow> obj)
        {
            Action A = () =>
           {
               DataRow dr = obj[obj.Keys.ToArray()[0]];
               double margin = 0;
               double balance = 0;
               double equity = 0;
               if (dr["Balance"].ToString() != string.Empty)
                   balance = Convert.ToDouble(dr["Balance"].ToString());
               if (dr["UsedMargin"].ToString() != string.Empty)
               {
                   margin = Convert.ToDouble(dr["UsedMargin"].ToString());
                   lblUsedMargin.Visible = true;
                   lblMarginLevel.Visible = true;
                   tlsMarginValue.Visible = true;
                   tlsMarginLevelValue.Visible = true;
               }
               else
               {
                   lblUsedMargin.Visible = false;
                   lblMarginLevel.Visible = false;
                   tlsMarginValue.Visible = false;
                   tlsMarginLevelValue.Visible = false;
               }
               if (tlsEquityValue.Text != string.Empty)
                   equity = Convert.ToDouble(tlsEquityValue.Text);
               tlsMarginValue.Text = Convert.ToString(Math.Round(margin, 2));
               tlsBalanceValue.Text = Convert.ToString(Math.Round(balance, 2));
               tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
               tlsFreeMarginValue.Text = Convert.ToString(Math.Round(equity - margin, 2));
               tlsMarginLevelValue.Text = Convert.ToString(Math.Round(equity / margin * 100, 2));
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

        private void INSTANCE_OnPositionOpened()
        {
            Action A = () =>
            {
                if (clsTWSOrderManagerJSON.INSTANCE != null)
                {
                    //Namo 21 March
                    //lock (clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen)
                    //{
                    //    clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.AcceptChanges();
                    //    //if (clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.Sort != "ClientOrderId Desc")
                    //    //    clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.Sort = "ClientOrderId Desc";

                    //    //uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.ToTable();
                    //    uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen;
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

        private void ui_ndgvGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = uctlOrders.ui_uctlGridPendingOrder.Columns[e.ColumnIndex];
            if (oldColumn == null)
                oldColumn = uctlOrders.ui_uctlGridPendingOrder.Columns["clmOrderNumber"];
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dir == "Asc")
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    //oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // If no column has been selected, display an error dialog  box.
            if (newColumn == null)
            {
                MessageBox.Show("Select a single column and try again.",
                                "Error: Invalid Selection", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending
                        ? SortOrder.Ascending
                        : SortOrder.Descending;
            }
            oldColumn = newColumn;
            //DataView dv = new DataView(Cls.clsTWSOrderManager.INSTANCE.orderHistoryDS.dtOrderHistory);
            if (direction != ListSortDirection.Ascending)
                dir = "Desc";
            else
                dir = "Asc";

            //DataTable dt2 = Cls.clsTWSOrderManager.INSTANCE.orderHistoryDS.dtOrderHistory.Clone();
            //dt2.Columns["ClientOrderID"].DataType = Type.GetType("System.Int32");

            //foreach (DataRow dr in Cls.clsTWSOrderManager.INSTANCE.orderHistoryDS.dtOrderHistory.Rows)
            //{
            //    dt2.ImportRow(dr);
            //}
            //dt2.AcceptChanges();
            //DataView dv = dt2.DefaultView;
            //Namo 21 March
            //DataView dv = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView;
            //if (uctlOrders.ui_uctlGridPendingOrder.Columns[e.ColumnIndex].DataPropertyName != string.Empty)
            //{
            //    dv.Sort = uctlOrders.ui_uctlGridPendingOrder.Columns[e.ColumnIndex].DataPropertyName + " " + dir;
            //    var dt = new DataTable();
            //    dt = dv.ToTable();
            //    uctlOrders.ui_uctlGridPendingOrder.DataSource = dt;
            //}
        }
        private void OnProfileApplyClick(string profileName)
        {
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.OrderBook.ToString()];
            foreach (DataGridViewColumn col in uctlOrders.ui_uctlGridPendingOrder.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        //private void INSTANCE_OnOrderHistoryResponse()
        //{
        //    //clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort = "ClientOrderId Desc";
        //    Action A = () =>
        //    {
        //        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
        //        if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort != "OrderID Desc")
        //            clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort = "OrderID Desc";
        //        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Columns["ClientOrderId"].DataType = Type.GetType("System.Int32");
        //        uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Select("OrderStatus=Working");
        //    };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }

        //}
        //private void INSTANCE_OnBusinessLevelReject(DataRow obj, BusinessReject objBusinessReject)
        //{
        //    Action A = () =>
        //    {
        //        System.Threading.Thread.Sleep(300);
        //        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
        //        if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort != "ClientOrderId Desc")
        //            clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort = "ClientOrderId Desc";
        //        uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Select("OrderStatus=Working");
        //    };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }
        //}
        //private void INSTANCE_ExecutionReport(ExecutionReport executionReport)
        //{
        //    //uctlOrderBook1.ui_uctlGridOrderBook.Refresh();
        //    Action A = () =>
        //    {
        //        if (clsTWSOrderManagerJSON.INSTANCE != null)
        //        {
        //            lock (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory)
        //            {
        //                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
        //                if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort != "ClientOrderId Desc")
        //                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort = "ClientOrderId Desc";
        //                uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable
        //                        ().Select("OrderStatus=Working");
        //            }
        //        }
        //    };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }
        //}

        private void ApplyDefaultProfile(string profileName)
        {
            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlOrders.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlOrders.ui_uctlGridPendingOrder.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }
        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            ////FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DoubleBuffered Method");
        }

        private void uctlOrderBook1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            if (uctlOrders.ui_uctlGridPendingOrder.Rows.Count > 0)
            {
                uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["SaveAs"].Enabled = true;
                string OrderStatus =
                    uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();
                //if (OrderStatus == "FILLED")
                //{
                //    uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = true;
                //}
                //else
                //{
                //    uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
                //}

                if (OrderStatus != "WORKING" && OrderStatus != "PARTIALLY_FILLED")
                {
                    uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Enabled = false;
                    uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;
                }
                else
                {
                    uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Enabled = true;
                    uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = true;
                }
                //uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = true;
            }
            else
            {
                uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["SaveAs"].Enabled = false;
                uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
                uctlOrders.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;
                //uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = false;
            }
        }

        private void dtOrderHistory_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //DataRowState drs = e.Row.RowState;
            ////if (e.Row.RowState == DataRowState.Modified)
            ////{
            //x = "";
            //y = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.IndexOf(e.Row);
            //if (uctlOrders.ui_uctlGridPendingOrder.Rows.Count != 0 &&
            //    uctlOrders.ui_uctlGridPendingOrder.Rows[y] != null)
            //{
            //    x = e.Row["Color"].ToString();

            //    uctlOrders.ui_uctlGridPendingOrder.Rows[y].DefaultCellStyle.BackColor = Color.FromName(x);
            //    uctlOrders.ui_uctlGridPendingOrder.Rows[y].Cells["clmStatus"].Value = e.Row["OrderStatus"].ToString();
            //    uctlOrders.ui_uctlGridPendingOrder.Rows[y].Cells["clmAvgPrice"].Value = e.Row["AvgPrice"].ToString();
            //    uctlOrders.ui_uctlGridPendingOrder.Rows[y].Cells["clmTotalExecutedQuantity"].Value =
            //        e.Row["CumQty"].ToString();
            //}
            //}
        }

        public void uctlOrderBook1_HandleCancelOrder(object arg1, EventArgs arg2)
        {

            if (uctlOrders.ui_uctlGridPendingOrder.Rows.Count > 0)
            {

                //int index =
                //    uctlOrderBook1.ui_uctlGridOrderBook.Rows.IndexOf(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Rows[index];

                ////= clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                //int index = ((DataTable)uctlOrderBook1.ui_uctlGridOrderBook.DataSource).Rows.IndexOf(((DataRowView)uctlOrderBook1.ui_uctlGridOrderBook.ui_ndgvGrid.SelectedRows[0].DataBoundItem).Row);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                string orderStatus = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();

                if (orderStatus != "CANCELED" && orderStatus != "FILLED")
                {
                    DateTime expiryDateTime = DateTime.UtcNow;
                    DateTime transactTime = DateTime.UtcNow;
                    DateTime.TryParse(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                    double transTime = transactTime.ToOADate();
                    DateTime.TryParse(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                    string pType = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    switch (pType)
                    {
                        case "Equity":
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
                        default:
                            break;
                    }
                    ;


                    sbyte ordType = PALSA.Cls.ClsGlobal.DDOrderTypes[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderType"].Value.ToString()];
                    sbyte side = PALSA.Cls.ClsGlobal.DDSide[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmBS"].Value.ToString()];
                    uint Account = Convert.ToUInt32(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmClient"].Value.ToString());
                    string clOrdId = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string ContractName = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmContract"].Value.ToString();
                    string ProductType = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    sbyte Producttype = PALSA.Cls.ClsGlobal.DDProductTypes[pType];
                    uint ordQty = Convert.ToUInt32(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderQuantity"].Value.ToString());
                    double price = 0;
                    if (!string.IsNullOrEmpty(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmPrice"].Value.ToString()))
                        price = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmPrice"].Value.ToString());
                    double stopPx = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTriggerPrice"].Value.ToString());
                    sbyte tif = PALSA.Cls.ClsGlobal.DDValidity[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmValidity"].Value.ToString()];
                    //Namo 21 March
                    //clsTWSOrderManagerJSON.INSTANCE.CancelOrder(Account, clOrdId, ContractName, ProductType, Producttype,
                    //                                        uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductName"].Value.ToString(), expiryDateTime,
                    //                                        uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmGateway"].Value.ToString(),
                    //                                        Convert.ToUInt32(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString()), side,
                    //                                        ordQty, ordType, price, stopPx, tif, 0, 0, transTime, 0);
                }
                else
                {
                    MessageBox.Show(orderStatus + " Order can not be canceled.");
                }
            }
        }





        private void uctlOrderBook1_Click(object sender, EventArgs e)
        {
            //Activate();
        }

        private void uctlOrderBook1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);
        }
        private void SaveProfile(string profileName)
        {
            uctlOrders.CurrentProfileName = profileName;
            //_formkey = CommandIDS.ORDER_BOOK.ToString() + "/" + Convert.ToString(count) + "/" + profileName;

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
        }
        private void uctlOrderBook1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlOrderBook1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            Properties.Settings.Default.OrderBookProfile = profileName;
            Properties.Settings.Default.Save();
        }

        //private void uctlOrderBook1_SelectionCriteriaChanged()
        //{
        //    if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count > 0)
        //    {
        //        string _productType = uctlOrderBook1.ProductType;
        //        string _orderStatus = uctlOrderBook1.OrderStatus;
        //        string _orderType = uctlOrderBook1.OrderType;
        //        string _bS = uctlOrderBook1.BS;
        //        if (_orderStatus != "All")
        //        {
        //            _orderStatus = _orderStatus.Trim().Replace(' ', '_');
        //            _orderStatus = _orderStatus.ToUpper();
        //        }
        //        if (_productType != "All")
        //        {
        //            _productType = _productType.Trim().Replace(' ', '_');
        //            _productType = _productType.ToUpper();
        //        }
        //        if (_orderType != "All")
        //        {
        //            _orderType = _orderType.Replace(' ', '_');
        //            _orderType = _orderType.ToUpper();
        //        }
        //        if (_bS != "All")
        //        {
        //            _bS = _bS.Replace(' ', '_');
        //            _bS = _bS.ToUpper();
        //        }
        //        string query = string.Empty;
        //        //query = _accountno == 0 ? "" : "Account=" + _accountno + " and ";
        //        query = _productType == "All" ? "" : "ProductType='" + _productType + "' and ";
        //        query = query + (_orderType == "All" ? "" : "OrderType='" + _orderType + "' and ");
        //        query = query + (_bS == "All" ? "" : "Side='" + _bS + "' and ");
        //        query = query + (_orderStatus == "All" ? "" : "OrderStatus='" + _orderStatus + "' and ");
        //        if (query != string.Empty)
        //        {
        //            query = query.Remove(query.Length - 5);
        //            uctlOrderBook1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query;
        //            //Binding bi = new Binding("DefaultCellStyle.BackColor", Cls.clsTWSOrderManager.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query), "clmColor");
        //            //uctlOrderBook1.ui_uctlGridOrderBook.DataBindings.Add(bi);
        //            uctlOrderBook1.ui_uctlGridOrderBook.DataSource =
        //                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
        //        }
        //        else
        //        {
        //            uctlOrders.ui_uctlGridPendingOrder.DataSource =
        //                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
        //        }
        //    }
        //}

        //private void uctlOrderBook1_OnAccountChanged()
        //{
        //    clsTWSOrderManagerJSON.INSTANCE.RequestForOrderHistoryOfAccount(uctlOrderBook1.AccountNo);
        //}

        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ////Action A = () =>
            ////               {
            //uctlOrderBook1.ui_uctlGridOrderBook.EnableCellCustomDraw = false;
            //int sellQty = 0;
            //int buyQty = 0;
            //for (int i = 0; i < uctlOrderBook1.ui_uctlGridOrderBook.Rows.Count; i++)
            //{
            //    int j = i;
            //    if (uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null &&
            //        uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.ToString() ==
            //        Color.DarkGreen.Name)
            //    {
            //        uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.ForeColor =
            //            Color.White;
            //    }
            //    if (uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null)
            //        uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.BackColor =
            //            Color.FromName(
            //                uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.
            //                    ToString());
            //    if (uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "REJECTED" || uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "CANCELLED")
            //    {
            //        if (
            //            uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmBS"].Value.ToString()
            //                .ToUpper() == "SELL")
            //        {
            //            sellQty +=
            //                Convert.ToInt32(
            //                    uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
            //                        .Value.ToString());
            //        }
            //        else
            //        {
            //            buyQty +=
            //                Convert.ToInt32(
            //                    uctlOrderBook1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
            //                        .Value.ToString());
            //        }
            //    }
            //}
            //uctlOrderBook1.SellQty = Convert.ToString(sellQty);
            //uctlOrderBook1.BuyQty = Convert.ToString(buyQty);
            ////               };
            ////if (InvokeRequired)
            ////{
            ////    BeginInvoke(A);
            ////}
            ////else
            ////{
            ////    A();
            ////}
        }

        private void uctlOrders_HandleCloseOrderClick(object arg1, EventArgs arg2)
        {
            if (uctlOrders.ui_uctlGridPendingOrder.Rows.Count > 0)
            {

                //int index =
                //    uctlOrderBook1.ui_uctlGridOrderBook.Rows.IndexOf(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Rows[index];

                ////= clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                //int index = ((DataTable)uctlOrderBook1.ui_uctlGridOrderBook.DataSource).Rows.IndexOf(((DataRowView)uctlOrderBook1.ui_uctlGridOrderBook.ui_ndgvGrid.SelectedRows[0].DataBoundItem).Row);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                string orderStatus = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();

                if (orderStatus == "FILLED")
                {
                    DateTime expiryDateTime = DateTime.UtcNow;
                    DateTime transactTime = DateTime.UtcNow;
                    DateTime.TryParse(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                    double transTime = transactTime.ToOADate();
                    DateTime.TryParse(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                    string pType = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    switch (pType)
                    {
                        case "Equity":
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
                        default:
                            break;
                    }
                    ;


                    sbyte ordType = PALSA.Cls.ClsGlobal.DDOrderTypes[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderType"].Value.ToString()];
                    sbyte side = PALSA.Cls.ClsGlobal.DDSide[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmBS"].Value.ToString()];
                    uint Account = Convert.ToUInt32(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmClient"].Value.ToString());
                    string clOrdId = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string CloseClOrdID = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string CloseOrderID = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();

                    string ContractName = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmContract"].Value.ToString();
                    string ProductType = uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    sbyte Producttype = PALSA.Cls.ClsGlobal.DDProductTypes[pType];
                    double ordQty = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderQuantity"].Value.ToString());
                    double price = 0;
                    //if (!string.IsNullOrEmpty(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmAvgPrice"].Value.ToString()))
                    //buy then BidOfferBase else ask
                    if (uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmBS"].Value.ToString().ToUpper() == "BUY")
                    {
                        price = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName);
                    }
                    else
                    {
                        price = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName);
                    }


                    double stopPx = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTriggerPrice"].Value.ToString());
                    sbyte tif = PALSA.Cls.ClsGlobal.DDValidity[uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmValidity"].Value.ToString()];
                    bool OCOrder = false;
                    decimal slprice = 0;
                    decimal tpPrice = 0;
                    if (uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSLPrice"].Value != null && !String.IsNullOrEmpty(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSLPrice"].Value.ToString()))
                        slprice = Convert.ToDecimal(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSLPrice"].Value.ToString());
                    if (uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTPPrice"].Value != null && !String.IsNullOrEmpty(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTPPrice"].Value.ToString()))
                        tpPrice = Convert.ToDecimal(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTPPrice"].Value.ToString());
                    if ((slprice + tpPrice) > 0M)
                        OCOrder = true;
                    //Namo 21 March
                    //clsTWSOrderManagerJSON.INSTANCE.CloseOrder(Account, clOrdId, ContractName, ProductType, Producttype,
                    //                                        uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductName"].Value.ToString(), expiryDateTime,
                    //                                        uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmGateway"].Value.ToString(), clOrdId, side,
                    //                                        ordQty, ordType, price, stopPx, tif, 0, 0, transTime, 0, CloseClOrdID, CloseOrderID, OCOrder);
                }
                else
                {
                    MessageBox.Show(orderStatus + " Order can not be Closed.");
                }
            }
        }

        private void uctlOrders_HandleModifyOrderClick(object arg1, EventArgs arg2)
        {
            if (uctlOrders.ui_uctlGridPendingOrder.SelectedRows != null && uctlOrders.ui_uctlGridPendingOrder.SelectedRows.Count > 0)
            {
                frmOrderEntry orderentry = new frmOrderEntry(uctlOrders.ui_uctlGridPendingOrder.SelectedRows[0], CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY);
                orderentry.ShowDialog();
            }
            else
            {
                //Namo 21 March
                // clsTWSOrderManagerJSON.INSTANCE.SendMessageForStatus("No order selected to modify.");
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen))
        //    //{
        //    //    try
        //    //    {
        //    //        UrPnl = 0;
        //    //        for (int i = 0; i < clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows.Count; i++)
        //    //        {
        //    //            int k = i;
        //    //            double askPrice = 0;
        //    //            double bidPrice = 0;
        //    //            string contract = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["Contract"].ToString();
        //    //            string productType = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["ProductType"].ToString();
        //    //            string productName = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["Product"].ToString();
        //    //            bidPrice = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(contract);
        //    //            askPrice = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(contract);
        //    //            InstrumentSpec inst = ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(productType, contract, productName);
        //    //            string format = "0.";
        //    //            for (int j = 0; j < inst.Digits; j++)
        //    //            {
        //    //                format += "0";
        //    //            }
        //    //            string side = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["side"].ToString();
        //    //            int orderqty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["orderqty"].ToString());
        //    //            double averageprice = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["AvgPrice"].ToString());

        //    //            if (side.ToUpper() == "BUY")
        //    //            {
        //    //                clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["Pnl"] = (orderqty * (bidPrice - averageprice)).ToString(format);
        //    //                UrPnl += (orderqty * (bidPrice - averageprice));
        //    //            }
        //    //            else
        //    //            {
        //    //                clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.Rows[k]["Pnl"] = (orderqty * (averageprice - askPrice)).ToString(format);
        //    //                UrPnl += (orderqty * (averageprice - askPrice));
        //    //            }
        //    //        }
        //    //        //clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.AcceptChanges();
        //    //        ////if (clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.Sort != "ClientOrderId Desc")
        //    //        ////    clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.Sort = "ClientOrderId Desc";
        //    //        uctlOrders.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen.DefaultView.ToTable();
        //    //        tlsEquityValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsBalanceValue.Text) + UrPnl, 2));
        //    //        tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) - Convert.ToDouble(tlsMarginValue.Text), 2));
        //    //        tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) / Convert.ToDouble(tlsMarginValue.Text), 2));
        //    //    }
        //    //    finally
        //    //    {
        //    //        System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.positionOpenDS.dtPositionOpen);
        //    //    }
        //    //}
        //    Action A = () =>
        //    {
        //        UrPnl = 0;
        //        for (int i = 0; i < uctlOrders.ui_uctlGridPendingOrder.Rows.Count; i++)
        //        {
        //            int k = i;
        //            double askPrice = 0;
        //            double bidPrice = 0;

        //            string contract = uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmContract"].Value.ToString();
        //            string productType = uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmProductType"].Value.ToString();
        //            string productName = uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmProductName"].Value.ToString();
        //            bidPrice = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(contract);
        //            askPrice = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(contract);
        //            InstrumentSpec inst = ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(productType, contract, productName);
        //            string format = "0.";
        //            for (int j = 0; j < inst.Digits; j++)
        //            {
        //                format += "0";
        //            }
        //            string side = uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmBS"].Value.ToString();
        //            double orderqty = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmOrderQuantity"].Value.ToString());
        //            double averageprice = Convert.ToDouble(uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmAvgPrice"].Value.ToString());

        //            if (side.ToUpper() == "BUY")
        //            {
        //                double prl = Math.Round(orderqty * (bidPrice - averageprice) * inst.ContractSize * PALSA.Cls.ClsGlobal.DDConversion[contract], 2);
        //                uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmPnl"].Value = prl.ToString("0.00");
        //                uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmCurrentPrice"].Value = PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(contract).ToString(format);
        //                UrPnl += prl;
        //            }
        //            else
        //            {
        //                double prl = Math.Round(orderqty * (averageprice - askPrice) * inst.ContractSize * PALSA.Cls.ClsGlobal.DDConversion[contract], 2);
        //                uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmPnl"].Value = prl.ToString("0.00");
        //                uctlOrders.ui_uctlGridPendingOrder.Rows[k].Cells["clmCurrentPrice"].Value = PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(contract).ToString(format);
        //                UrPnl += prl;
        //            }
        //        }
        //        double balance = 0;
        //        double margin = 0;
        //        if (tlsBalanceValue.Text != string.Empty)
        //            balance = Convert.ToDouble(tlsBalanceValue.Text);
        //        if (tlsMarginValue.Text != string.Empty)
        //        {
        //            margin = Convert.ToDouble(tlsMarginValue.Text);
        //            lblUsedMargin.Visible = true;
        //            lblMarginLevel.Visible = true;
        //            tlsMarginValue.Visible = true;
        //            tlsMarginLevelValue.Visible = true;
        //        }
        //        else
        //        {
        //            lblUsedMargin.Visible = false;
        //            lblMarginLevel.Visible = false;
        //            tlsMarginValue.Visible = false;
        //            tlsMarginLevelValue.Visible = false;
        //        }
        //        tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));

        //        tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) - margin, 2));
        //        tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) / margin*100, 2));

        //    };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            Action A = () =>
            {
                try
                {
                    UrPnl = 0;
                    foreach (DataRow rw in clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows)
                    {
                        double qty = (Convert.ToDouble(rw["Quantity"].ToString()) - Convert.ToDouble(rw["SettledQty"].ToString()));

                        if (qty > 0)
                        {
                            int index = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.IndexOf(rw);
                            if (rw["BS"].ToString().ToUpper() == "BUY")
                            {
                                if (Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString())) > 0)
                                {
                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                    {
                                        double _pnl = Math.Round(qty * (Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * PALSA.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                        rw["PnL"] = _pnl;
                                    }
                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                    {
                                        double _pnl = Math.Round(qty * (Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * PALSA.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * PALSA.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                        rw["PnL"] = _pnl;
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString())) > 0)
                                {
                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                    {
                                        double _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * PALSA.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                        rw["PnL"] = _pnl;
                                    }
                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                    {
                                        double _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(PALSA.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * PALSA.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * PALSA.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                        rw["PnL"] = _pnl;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (rw["PnL"].ToString() != "0")
                                rw["PnL"] = 0;
                        }
                    }

                    if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count > 0)
                    {
                        UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                    }

                    double balance = 0;
                    double margin = 0;
                    if (tlsBalanceValue.Text != string.Empty)
                        balance = Convert.ToDouble(tlsBalanceValue.Text);
                    if (tlsMarginValue.Text != string.Empty)
                    {
                        margin = Convert.ToDouble(tlsMarginValue.Text);
                        lblUsedMargin.Visible = true;
                        lblMarginLevel.Visible = true;
                        tlsMarginValue.Visible = true;
                        tlsMarginLevelValue.Visible = true;
                    }
                    else
                    {
                        lblUsedMargin.Visible = false;
                        lblMarginLevel.Visible = false;
                        tlsMarginValue.Visible = false;
                        tlsMarginLevelValue.Visible = false;
                    }
                    //lblPL.Text = Math.Round(UrPnl, 2).ToString("0.00");
                    tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                    tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) - margin, 2));
                    if (margin == 0)
                    {
                        tlsMarginLevelValue.Text = "";
                    }
                    else
                    {
                        tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(tlsEquityValue.Text) / margin * 100, 2));
                    }
                }
                catch
                {
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
    }
}
