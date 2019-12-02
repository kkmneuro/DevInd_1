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

namespace PALSA.uctl
{
    public partial class ctlHistory : UserControl
    {
        private static int count;
        private static DataGridViewColumn oldColumn;
        private static string dir = "Desc";
        //private string _formkey;
        private object _objProfiles;
        private string x = string.Empty;
        private int y;
        public ctlHistory(object objProfiles, string currentProfile,Keys shortcutKeys)
        {
            InitializeComponent();
            uctlHistory.Size = ClientSize;
            _objProfiles = objProfiles;
            uctlHistory.Profiles = objProfiles;
            uctlHistory.CurrentProfileName = currentProfile;
            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle datastyle = new DataGridViewCellStyle { BackColor = SystemColors.Control, ForeColor = SystemColors.WindowText, SelectionBackColor = SystemColors.Highlight, SelectionForeColor = SystemColors.HighlightText, Alignment = DataGridViewContentAlignment.MiddleLeft };

            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeadersDefaultCellStyle = datastyle;
        }

        private void ctlPendingOrders_Load(object sender, EventArgs e)
        {



            #region "     Add Columns to grid      "

            var columnsArray = new DataGridViewColumn[56];
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
       
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "clmOrderNumber", "Order Number");
            columnsArray[0].DataPropertyName = "ClientOrderID";
            columnsArray[0].DefaultCellStyle = intCellStyle;

            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "clmClient", "Account No",false);
            columnsArray[1].DataPropertyName = "Account";
            columnsArray[1].DefaultCellStyle = intCellStyle;

            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "clmProductType", "Product Type",false);
            columnsArray[2].DataPropertyName = "ProductType";

            columnsArray[3] = ClsCommonMethods.CreateGridColumn(columnsArray[3], "clmProductName", "Product Name",false);
            columnsArray[3].DataPropertyName = "Product";

            columnsArray[4] = ClsCommonMethods.CreateGridColumn(columnsArray[4], "clmContract", "Contract");
            columnsArray[4].DataPropertyName = "Contract";

            columnsArray[5] = ClsCommonMethods.CreateGridColumn(columnsArray[5], "clmSeriesExpiry", "Expiry",false);
            columnsArray[5].DataPropertyName = "ExpireDate";

            columnsArray[6] = ClsCommonMethods.CreateGridColumn(columnsArray[6], "clmOrderType", "Order Type");
            columnsArray[6].DataPropertyName = "OrderType";

            columnsArray[7] = ClsCommonMethods.CreateGridColumn(columnsArray[7], "clmBS", "B/S");
            columnsArray[7].DataPropertyName = "Side";

            columnsArray[8] = ClsCommonMethods.CreateGridColumn(columnsArray[8], "clmOrderQuantity", "Order Qty");
            columnsArray[8].DataPropertyName = "OrderQty";
            columnsArray[8].DefaultCellStyle = intCellStyle;

            columnsArray[9] = ClsCommonMethods.CreateGridColumn(columnsArray[9], "clmTotalExecutedQuantity",
                                                                "Total Executed Quantity",false);
            columnsArray[9].DataPropertyName = "CumQty";
            columnsArray[9].DefaultCellStyle = intCellStyle;

            columnsArray[10] = ClsCommonMethods.CreateGridColumn(columnsArray[10], "clmPendingQuantity",
                                                                 "Pending Quantity",false);
            columnsArray[10].DataPropertyName = "LeavesQty";
            columnsArray[10].DefaultCellStyle = intCellStyle;

            columnsArray[11] = ClsCommonMethods.CreateGridColumn(columnsArray[11], "clmPrice", "Price",false);
            columnsArray[11].DataPropertyName = "Price";
            columnsArray[11].DefaultCellStyle = intCellStyle;

            columnsArray[12] = ClsCommonMethods.CreateGridColumn(columnsArray[12], "clmStatus", "Status");
            columnsArray[12].DataPropertyName = "OrderStatus";

            columnsArray[13] = ClsCommonMethods.CreateGridColumn(columnsArray[13], "clmValidity", "Validity",false);
            columnsArray[13].DataPropertyName = "TimeInForce";

            columnsArray[14] = ClsCommonMethods.CreateGridColumn(columnsArray[14], "clmDisclosedQuantity",
                                                                 "Disclosed Quantity",false);
            columnsArray[14].DefaultCellStyle = intCellStyle;

            columnsArray[15] = ClsCommonMethods.CreateGridColumn(columnsArray[15], "clmLastModifiedTime",
                                                                 "Last Modified Time", false);

            columnsArray[16] = ClsCommonMethods.CreateGridColumn(columnsArray[16], "clmAvgPrice", "Average Price");
            columnsArray[16].DataPropertyName = "AvgPrice";
            columnsArray[16].DefaultCellStyle = intCellStyle;

            columnsArray[17] = ClsCommonMethods.CreateGridColumn(columnsArray[17], "clmCommission", "Commission",false);
            columnsArray[17].DataPropertyName = "Commission";
            columnsArray[17].DefaultCellStyle = intCellStyle;
            columnsArray[18] = ClsCommonMethods.CreateGridColumn(columnsArray[18], "clmTax", "Tax",false);
            columnsArray[18].DataPropertyName = "Tax";
            columnsArray[18].DefaultCellStyle = intCellStyle;

            columnsArray[19] = ClsCommonMethods.CreateGridColumn(columnsArray[19], "clmOptionType", "Option Type", false);

            columnsArray[20] = ClsCommonMethods.CreateGridColumn(columnsArray[20], "clmTradingCurrency", "Trading Currency", false);
            columnsArray[20].DataPropertyName = "TradingCurrency";

            columnsArray[21] = ClsCommonMethods.CreateGridColumn(columnsArray[21], "clmAccountType", "Account Type",
                                                                 false);

            columnsArray[22] = ClsCommonMethods.CreateGridColumn(columnsArray[22], "clmClientName", "Client Name", false);

            columnsArray[23] = ClsCommonMethods.CreateGridColumn(columnsArray[23], "clmPartIdOmniId", "Part Id/Omni Id",
                                                                 false);

            columnsArray[24] = ClsCommonMethods.CreateGridColumn(columnsArray[24], "clmNetVal", "Net Val.", false);
            columnsArray[24].DefaultCellStyle = intCellStyle;

            columnsArray[25] = ClsCommonMethods.CreateGridColumn(columnsArray[25], "clmGoodTillDate", "Good Till Date",
                                                                 false);
            columnsArray[25].DataPropertyName = "ExpireDate";
            //
            columnsArray[26] = ClsCommonMethods.CreateGridColumn(columnsArray[26], "clmTriggerPrice", "Trigger Price",
                                                                 false);
            columnsArray[26].DataPropertyName = "StopPx";
            columnsArray[26].DefaultCellStyle = intCellStyle;

            columnsArray[27] = ClsCommonMethods.CreateGridColumn(columnsArray[27], "clmReason", "Reason",false);
            columnsArray[27].DataPropertyName = "Text";

            columnsArray[28] = ClsCommonMethods.CreateGridColumn(columnsArray[28], "clmRemarks", "Remarks", false);

            columnsArray[29] = ClsCommonMethods.CreateGridColumn(columnsArray[29], "clmCounterTM", "Counter TM", false);

            columnsArray[30] = ClsCommonMethods.CreateGridColumn(columnsArray[30], "clmEnteredBy", "Entered By", false);

            columnsArray[31] = ClsCommonMethods.CreateGridColumn(columnsArray[31], "clmModifiedBy", "Modified By", false);

            columnsArray[32] = ClsCommonMethods.CreateGridColumn(columnsArray[32], "clmSpread", "Spread", false);

            columnsArray[33] = ClsCommonMethods.CreateGridColumn(columnsArray[33], "clmReferenceNo", "Reference No.",
                                                                 false);
            columnsArray[33].DataPropertyName = "OrderID";
            columnsArray[33].DefaultCellStyle = intCellStyle;

            columnsArray[34] = ClsCommonMethods.CreateGridColumn(columnsArray[34], "clmRealValue", "Real Value", false);

            columnsArray[35] = ClsCommonMethods.CreateGridColumn(columnsArray[35], "clmYourMoneyUsed", "Your Money Used",
                                                                 false);

            columnsArray[36] = ClsCommonMethods.CreateGridColumn(columnsArray[36], "clmCurrentMarketPrice",
                                                                 "Current market price", false);

            columnsArray[37] = ClsCommonMethods.CreateGridColumn(columnsArray[37], "clmStopLoss", "Stop Loss", false);

            columnsArray[38] = ClsCommonMethods.CreateGridColumn(columnsArray[38], "clmTakeProfit", "Take Profit", false);

            columnsArray[39] = ClsCommonMethods.CreateGridColumn(columnsArray[39], "clmSwap", "Swap", false);


            columnsArray[40] = ClsCommonMethods.CreateGridColumn(columnsArray[40], "clmProfitCurrency",
                                                                 "Profit (Currency)", false);

            columnsArray[41] = ClsCommonMethods.CreateGridColumn(columnsArray[41], "clmProfitPIPS", "Profit PIPS", false);
            columnsArray[42] = ClsCommonMethods.CreateGridColumn(columnsArray[42], "clmGateway", "GateWay", false);
            columnsArray[42].DataPropertyName = "Gateway";
            columnsArray[43] = ClsCommonMethods.CreateGridColumn(columnsArray[43], "clmColor", "Color", false);
            columnsArray[43].DataPropertyName = "Color";
            columnsArray[44] = ClsCommonMethods.CreateGridColumn(columnsArray[44], "clmTransactionTime", "Transaction Time");
            columnsArray[44].DataPropertyName = "TransactTime";
            columnsArray[44].DisplayIndex = 1;
            columnsArray[45] = ClsCommonMethods.CreateGridColumn(columnsArray[45], "clmCounterClOrdId", "CounterClOrdId", false);
            columnsArray[45].DataPropertyName = "CounterClOrdId";
            columnsArray[45].DefaultCellStyle = intCellStyle;
            columnsArray[46] = ClsCommonMethods.CreateGridColumn(columnsArray[46], "clmCounterAvgPx", "CounterAvgPx", false);
            columnsArray[46].DataPropertyName = "CounterAvgPx";
            columnsArray[46].DefaultCellStyle = intCellStyle;
            columnsArray[47] = ClsCommonMethods.CreateGridColumn(columnsArray[47], "clmGrossPL", "Gross Profit Loss", false);
            columnsArray[47].DataPropertyName = "GrossPL";
            columnsArray[47].DefaultCellStyle = intCellStyle;
            columnsArray[48] = ClsCommonMethods.CreateGridColumn(columnsArray[48], "clmPositionEffect", "PositionEffect", false);
            columnsArray[48].DataPropertyName = "PositionEffect";
            columnsArray[49] = ClsCommonMethods.CreateGridColumn(columnsArray[49], "clmCloseQuantity", "Closed Quantity",false);
            columnsArray[49].DataPropertyName = "ClosedQty";
            columnsArray[49].DefaultCellStyle = intCellStyle;
            columnsArray[50] = ClsCommonMethods.CreateGridColumn(columnsArray[50], "clmSLClOrdID", "SLClOrdID",false);
            columnsArray[50].DataPropertyName = "SLClOrdId";
            columnsArray[50].DefaultCellStyle = intCellStyle;
            columnsArray[51] = ClsCommonMethods.CreateGridColumn(columnsArray[51], "clmTPClOrdID", "TPClOrdID",false);
            columnsArray[51].DataPropertyName = "TPClOrdId";
            columnsArray[51].DefaultCellStyle = intCellStyle;         
            columnsArray[52] = ClsCommonMethods.CreateGridColumn(columnsArray[52], "clmClosePrice", "Closed Price");
            columnsArray[52].DataPropertyName = "ClosedPrice";
            columnsArray[52].DefaultCellStyle = intCellStyle;
            columnsArray[53] = ClsCommonMethods.CreateGridColumn(columnsArray[53], "clmSLPrice", "SL");
            columnsArray[53].DataPropertyName = "SLPrice";
            columnsArray[53].DefaultCellStyle = intCellStyle;
            columnsArray[54] = ClsCommonMethods.CreateGridColumn(columnsArray[54], "clmTPPrice", "TP");
            columnsArray[54].DataPropertyName = "TPPrice";
            columnsArray[54].DefaultCellStyle = intCellStyle;
            columnsArray[55] = ClsCommonMethods.CreateGridColumn(columnsArray[55], "clmProfit", "P/L");
            columnsArray[55].DataPropertyName = "Profit";
            columnsArray[55].DefaultCellStyle = intCellStyle;
            //columnsArray[55].DefaultCellStyle.Format = "0.00";
            if (PALSA.Cls.ClsGlobal.MarketMakerAccountId > 0)
            {
                columnsArray[45].Visible = true;
                columnsArray[46].Visible = true;
                columnsArray[47].Visible = true;
            }

            uctlHistory.AddColumnsToGrid(columnsArray);

            #endregion "     Add Columns to grid      "


            //clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport -= INSTANCE_ExecutionReport;
            //clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse -= INSTANCE_OnOrderHistoryResponse;
            //clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject -= INSTANCE_OnBusinessLevelReject;
            //clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_ExecutionReport;
            //clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse += INSTANCE_OnOrderHistoryResponse;
            //clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject += INSTANCE_OnBusinessLevelReject;

            //Namo 21 March
            //clsTWSOrderManagerJSON.INSTANCE.onPositionClosed -= new Action (INSTANCE_OnPositionClosed);
            //clsTWSOrderManagerJSON.INSTANCE.onPositionClosed += new Action (INSTANCE_OnPositionClosed);

            if (uctlHistory.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlHistory.CurrentProfileName);
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
            DoubleBuffered(uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid, true);
            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.DataBindingComplete -=ui_ndgvGrid_DataBindingComplete;
            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.DataBindingComplete += ui_ndgvGrid_DataBindingComplete;
            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeaderMouseClick -=ui_ndgvGrid_ColumnHeaderMouseClick;
            uctlHistory.ui_uctlGridPendingOrder.ui_ndgvGrid.ColumnHeaderMouseClick +=ui_ndgvGrid_ColumnHeaderMouseClick;
            //Namo 21 March
            //uctlHistory.ui_uctlGridPendingOrder.DataSource =clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose;
        }

        private void INSTANCE_OnPositionClosed()
        {
            Action A = () =>
            {
                if (clsTWSOrderManagerJSON.INSTANCE != null)
                {
                    //Namo 21 March
                    //lock (clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose)
                    //{
                    //    clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.AcceptChanges();
                    //    if (clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.DefaultView.Sort != "ClientOrderId Desc")
                    //        clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.DefaultView.Sort = "ClientOrderId Desc";
                    //    uctlHistory.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.DefaultView.ToTable();
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
            DataGridViewColumn newColumn = uctlHistory.ui_uctlGridPendingOrder.Columns[e.ColumnIndex];
            if (oldColumn == null)
                oldColumn = uctlHistory.ui_uctlGridPendingOrder.Columns["clmOrderNumber"];
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
            //DataView dv = clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.DefaultView;
            //if (uctlHistory.ui_uctlGridPendingOrder.Columns[e.ColumnIndex].DataPropertyName != string.Empty)
            //{
            //    dv.Sort = uctlHistory.ui_uctlGridPendingOrder.Columns[e.ColumnIndex].DataPropertyName + " " + dir;
            //    var dt = new DataTable();
            //    dt = dv.ToTable();
            //    uctlHistory.ui_uctlGridPendingOrder.DataSource = dt; 
            //}
        }
        private void OnProfileApplyClick(string profileName)
        {
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.OrderBook.ToString()];
            foreach (DataGridViewColumn col in uctlHistory.ui_uctlGridPendingOrder.Columns)
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
        //        uctlPendingOrder1.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Select("OrderStatus=Working");
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
        //        uctlPendingOrder1.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Select("OrderStatus=Working");
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
        //                uctlPendingOrder1.ui_uctlGridPendingOrder.DataSource = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable
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
            uctlHistory.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlHistory.ui_uctlGridPendingOrder.Columns)
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
            if (uctlHistory.ui_uctlGridPendingOrder.Rows.Count > 0)
            {
                uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["SaveAs"].Enabled = true;
                string OrderStatus =
                    uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();
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
                    uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Enabled = false;
                    uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;
                }
                else
                {
                    uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Enabled = true;
                    uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = true;
                }
                //uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = true;
            }
            else
            {
                uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["SaveAs"].Enabled = false;
                uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["CancelOrder"].Enabled = false;
                uctlHistory.ui_uctlGridPendingOrder.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;
                //uctlOrderBook1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = false;
            }
        }

        private void dtOrderHistory_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRowState drs = e.Row.RowState;
            //Namo 21 March
            //x = "";
            //y = clsTWSOrderManagerJSON.INSTANCE.positionCloseDS.dtPositionClose.Rows.IndexOf(e.Row);
            //if (uctlHistory.ui_uctlGridPendingOrder.Rows.Count != 0 &&
            //    uctlHistory.ui_uctlGridPendingOrder.Rows[y] != null)
            //{
            //    x = e.Row["Color"].ToString();

            //    uctlHistory.ui_uctlGridPendingOrder.Rows[y].DefaultCellStyle.BackColor = Color.FromName(x);
            //    uctlHistory.ui_uctlGridPendingOrder.Rows[y].Cells["clmStatus"].Value = e.Row["OrderStatus"].ToString();
            //    uctlHistory.ui_uctlGridPendingOrder.Rows[y].Cells["clmAvgPrice"].Value = e.Row["AvgPrice"].ToString();
            //    uctlHistory.ui_uctlGridPendingOrder.Rows[y].Cells["clmTotalExecutedQuantity"].Value =e.Row["CumQty"].ToString();
            //}

        }

        public void uctlOrderBook1_HandleCancelOrder(object arg1, EventArgs arg2)
        {

            if (uctlHistory.ui_uctlGridPendingOrder.Rows.Count > 0)
            {

                //int index =
                //    uctlOrderBook1.ui_uctlGridOrderBook.Rows.IndexOf(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Rows[index];

                ////= clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                //int index = ((DataTable)uctlOrderBook1.ui_uctlGridOrderBook.DataSource).Rows.IndexOf(((DataRowView)uctlOrderBook1.ui_uctlGridOrderBook.ui_ndgvGrid.SelectedRows[0].DataBoundItem).Row);
                //DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows[index];
                string orderStatus = uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();

                if (orderStatus != "CANCELED" && orderStatus != "FILLED")
                {
                    DateTime expiryDateTime = DateTime.UtcNow;
                    DateTime transactTime = DateTime.UtcNow;
                    DateTime.TryParse(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                    double transTime = transactTime.ToOADate();
                    DateTime.TryParse(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                    string pType = uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
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


                    sbyte ordType = PALSA.Cls.ClsGlobal.DDOrderTypes[uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderType"].Value.ToString()];
                    sbyte side = PALSA.Cls.ClsGlobal.DDSide[uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmBS"].Value.ToString()];
                    uint Account = Convert.ToUInt32(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmClient"].Value.ToString());
                    string clOrdId = uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string ContractName = uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmContract"].Value.ToString();
                    string ProductType = uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    sbyte Producttype = PALSA.Cls.ClsGlobal.DDProductTypes[pType];
                    uint ordQty = Convert.ToUInt32(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderQuantity"].Value.ToString());
                    double price = 0;
                    if (!string.IsNullOrEmpty(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmPrice"].Value.ToString()))
                        price = Convert.ToDouble(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmPrice"].Value.ToString());
                    double stopPx = Convert.ToDouble(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmTriggerPrice"].Value.ToString());
                    sbyte tif = PALSA.Cls.ClsGlobal.DDValidity[uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmValidity"].Value.ToString()];
                    //Namo 21 March
                    //clsTWSOrderManagerJSON.INSTANCE.CancelOrder(Account, clOrdId, ContractName, ProductType, Producttype,
                    //                                        uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmProductName"].Value.ToString(), expiryDateTime,
                    //                                        uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmGateway"].Value.ToString(),
                    //                                        Convert.ToUInt32(uctlHistory.ui_uctlGridPendingOrder.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString()), side,
                    //                                        ordQty, ordType, price, stopPx, tif, 0, 0, transTime,0);
                }
                else
                {
                    MessageBox.Show(orderStatus + " Order can not be canceled.");
                }
            }
        }

        public void uctlOrderBook1_HandleModifyOrderClick(object arg1, EventArgs arg2)
        {
            ////frmOrderEntry objfrmOrderEntry = new frmOrderEntry();
            ////objfrmOrderEntry.Sizable = false;
            ////objfrmOrderEntry.StartPosition = FormStartPosition.CenterScreen;
            ////objfrmOrderEntry.uctlOrderEntry1.ui_nbtnSubmit.Text = "&Modify";
            ////objfrmOrderEntry.Title = "Modify Order" + uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
            ////objfrmOrderEntry.uctlOrderEntry1.ui_lblOrderEntryType.Text = uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
            ////objfrmOrderEntry.ConfirmationMessage = "Are you sure to modify order?";
            ////objfrmOrderEntry.ShowDialog();

            ////Frm.frmOrderEntry.INSTANCE.Formkey = formKey;
            ////int index =
            ////    uctlOrderBook1.ui_uctlGridOrderBook.Rows.IndexOf(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
            ////DataRow dr = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable().Rows[index];
            //if (
            //    !uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmStatus"].Value.ToString().Contains(
            //        "FILLED"))
            //{
            //    string side = uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
            //    if (!frmOrderEntry.INSTANCE.IsDisposed)
            //    {
            //        frmOrderEntry.INSTANCE.Title = "Modify Order " +
            //                                       uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells[
            //                                           "clmOrderNumber"].Value;
            //        ;
            //        frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = side;
            //        Color color = side == "BUY"
            //                          ? Properties.Settings.Default.BuyOrderColor
            //                          : Properties.Settings.Default.SellOrderColor;
            //        frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //        frmOrderEntry.INSTANCE.MdiParent = MdiParent;
            //        frmOrderEntry.INSTANCE.Show();
            //        //uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
            //        frmOrderEntry.INSTANCE.uctlOrderEntry1.Mode = CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY;
            //        frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_nbtnSubmit.Text = "&Modify";
            //        frmOrderEntry.INSTANCE.FillValuesToModify(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
            //        frmOrderEntry.INSTANCE.Activate();
            //    }
            //    else
            //    {
            //        //frmOrderEntry.INSTANCE = new frmOrderEntry(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0],
            //        //                                           CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY);
            //        //frmOrderEntry.INSTANCE.Title = "Modify Order " +
            //        //                               uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells[
            //        //                                   "clmOrderNumber"].Value;
            //        //;
            //        //frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = side;
            //        //Color color = side == "BUY"
            //        //                  ? Properties.Settings.Default.BuyOrderColor
            //        //                  : Properties.Settings.Default.SellOrderColor;
            //        //frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
            //        //frmOrderEntry.INSTANCE.MdiParent = MdiParent;
            //        //frmOrderEntry.INSTANCE.Show();
            //        ////uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
            //        //frmOrderEntry.INSTANCE.uctlOrderEntry1.Mode = CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY;
            //        //frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_nbtnSubmit.Text = "&Modify";
            //        //frmOrderEntry.INSTANCE.FillValuesToModify(uctlOrderBook1.ui_uctlGridOrderBook.SelectedRows[0]);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Filled orders can not be modified.");
            //}
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
            uctlHistory.CurrentProfileName = profileName;
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
        //            uctlPendingOrder1.ui_uctlGridPendingOrder.DataSource =
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

    }
}
