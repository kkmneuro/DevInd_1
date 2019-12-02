///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//05/03/2012	VP          1.Code for columnProfile
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;
using ClsGlobal = TWS.Cls.ClsGlobal;
using System.Threading;

namespace TWS.Frm
{
    public partial class frmOrderBook : frmBase
    {
        #region "        MEMBERS       "

        private static int count;
        private static DataGridViewColumn oldColumn;
        private static string dir = "Desc";
        private string _formkey;
        private object _objProfiles;
        private string x = string.Empty;
        private int y;

        #endregion "     MEMBERS       "

        #region "        PROPERTIES    "

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        #endregion "     PROPERTIES   "

        #region "       METHODS      "

        public frmOrderBook(object objProfiles, string currentProfile, Keys SkeyFilter)
        {
            InitializeComponent();
            uctlOrderBookNew1.MarketMakerAccountId = ClsGlobal.MarketMakerAccountId;
            uctlOrderBookNew1.ShortcutKeyFilter = SkeyFilter;
            uctlOrderBookNew1.Size = ClientSize;
            _objProfiles = objProfiles;
            uctlOrderBookNew1.Profiles = objProfiles;
            uctlOrderBookNew1.CurrentProfileName = currentProfile;
            count += 1;
            _formkey = CommandIDS.ORDER_BOOK.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlOrderBookNew1.CurrentProfileName;
        }

        private void frmOrderBook_Load(object sender, EventArgs e)
        {
            uctlOrderBookNew1.AddContracts(ClsTWSContractManager.INSTANCE.LstContract.ToArray());
            uctlOrderBookNew1.FillProductTypes(ClsTWSContractManager.INSTANCE.LstProductTypes.ToArray());
            uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid.Scroll += new ScrollEventHandler(ui_ndgvGrid_Scroll);
            uctlOrderBookNew1.AddOrderTypes(Cls.ClsGlobal.orderTypes.ToArray());
            uctlOrderBookNew1.AddSide(Cls.ClsGlobal.side.ToArray());
            uctlOrderBookNew1.AddOrderStatus(Cls.ClsGlobal.orderStatus.ToArray());
            uctlOrderBookNew1.SelectionCriteriaChanged -= uctlOrderBookNew1_SelectionCriteriaChanged;
            uctlOrderBookNew1.SelectionCriteriaChanged += uctlOrderBookNew1_SelectionCriteriaChanged;
            uctlOrderBookNew1.OnSearchClick -= new Action<int, string, string, string, string, string, DateTime, DateTime>(uctlOrderBookNew1_OnSearchClick);
            uctlOrderBookNew1.OnSearchClick += new Action<int, string, string, string, string, string, DateTime, DateTime>(uctlOrderBookNew1_OnSearchClick);
            uctlOrderBookNew1.OnGridMouseDown -= new Action<object, MouseEventArgs>(uctlOrderBookNew1_OnGridMouseDown);
            uctlOrderBookNew1.OnGridMouseDown += new Action<object, MouseEventArgs>(uctlOrderBookNew1_OnGridMouseDown); //uctlOrderBookNew1_OnGridMouseDown
            List<string> lstAccountNos = clsTWSOrderManagerJSON.INSTANCE.GetParticipants();
            lstAccountNos.Insert(0, "All");
            uctlOrderBookNew1.AddAccounts(lstAccountNos);

            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport -= INSTANCE_ExecutionReport;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse -= INSTANCE_OnOrderHistoryResponse;
            clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject -= INSTANCE_OnBusinessLevelReject;
            //uctlOrderBookNew1.OnAccountChanged -= uctlOrderBookNew1_OnAccountChanged;
            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_ExecutionReport;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderHistoryResponse += INSTANCE_OnOrderHistoryResponse;
            clsTWSOrderManagerJSON.INSTANCE.OnBusinessLevelReject += INSTANCE_OnBusinessLevelReject;
            //uctlOrderBookNew1.OnAccountChanged += uctlOrderBookNew1_OnAccountChanged;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderSettle -= new Action(INSTANCE_OnOrderSettle);
            clsTWSOrderManagerJSON.INSTANCE.OnOrderSettle += new Action(INSTANCE_OnOrderSettle);

            if (uctlOrderBookNew1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlOrderBookNew1.CurrentProfileName);
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
            DoubleBuffered(uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid, true);
            uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid.DataBindingComplete -=
    ui_ndgvGrid_DataBindingComplete;
            uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid.DataBindingComplete +=
                ui_ndgvGrid_DataBindingComplete;
            uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid.ColumnHeaderMouseClick -=
                ui_ndgvGrid_ColumnHeaderMouseClick;
            uctlOrderBookNew1.ui_uctlGridOrderBook.ui_ndgvGrid.ColumnHeaderMouseClick +=
                ui_ndgvGrid_ColumnHeaderMouseClick;
            uctlOrderBookNew1.HandleCancelOrderClick -= uctlOrderBookNew1_HandleCancelOrder;
            uctlOrderBookNew1.HandleCancelOrderClick += uctlOrderBookNew1_HandleCancelOrder;
            uctlOrderBookNew1.HandleModifyOrderClick -= uctlOrderBookNew1_HandleModifyOrderClick;
            uctlOrderBookNew1.HandleModifyOrderClick += uctlOrderBookNew1_HandleModifyOrderClick;
            uctlOrderBookNew1.HandleCloseOrderClick -= uctlOrders_HandleCloseOrderClick;
            uctlOrderBookNew1.HandleCloseOrderClick += uctlOrders_HandleCloseOrderClick;
            uctlOrderBookNew1.HandleRefreshClick -= uctlOrders_HandleRefreshClick;
            uctlOrderBookNew1.HandleRefreshClick += uctlOrders_HandleRefreshClick;
            if (Properties.Settings.Default.AlwaysOpenTheOrderBookWith.ToString().Trim() != "")
            {

                if (Properties.Settings.Default.AlwaysOpenTheOrderBookWith.ToString().Trim() == "---SELECT---")
                {
                    uctlOrderBookNew1.OrderStatus = "All";
                }
                else
                {
                    uctlOrderBookNew1.OrderStatus = Properties.Settings.Default.AlwaysOpenTheOrderBookWith.ToString().Trim();
                }
            }


        }


        void INSTANCE_OnNewOrderResponse()
        {
            //uctlOrderBookNew1_SelectionCriteriaChanged();//Namo
        }

        void ui_ndgvGrid_Scroll(object sender, ScrollEventArgs e)
        {
            //uctlOrderBookNew1.ui_nsbFilterValue.Text = Convert.ToString(e.NewValue) + " : " + Convert.ToString(e.OldValue);
        }

        void uctlOrderBookNew1_OnSearchClick(int AccountNo, string ProductType, string OrderType, string OrderStatus, string BS, string Contract, DateTime FromDate, DateTime ToDate)
        {
            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count > 0)
            {
                int _accountno = AccountNo;
                string _productType = ProductType;
                string _orderType = OrderType;
                string _orderStatus = OrderStatus;
                if (_orderStatus == "Non Settled")
                {
                    _orderStatus = string.Empty;
                }
                string _bS = BS;
                string _contract = Contract;
                DateTime _fromDate = FromDate;
                DateTime _toDate = ToDate;
                if (_orderStatus != "All" && _orderStatus != "Non Settled")
                {
                    _orderStatus = _orderStatus.Trim().Replace(' ', '_');
                    _orderStatus = _orderStatus.ToUpper();
                }
                if (_productType != "All")
                {
                    _productType = _productType.Trim().Replace(' ', '_');
                    _productType = _productType.ToUpper();
                }
                if (_orderType != "All")
                {
                    _orderType = _orderType.Replace(' ', '_');
                    _orderType = _orderType.ToUpper();
                }
                if (_contract != "All")
                {
                    _contract = _contract.Trim().Replace(' ', '_');
                    _contract = _contract.ToUpper();
                }
                if (_bS != "All")
                {
                    _bS = _bS.Replace(' ', '_');
                    _bS = _bS.ToUpper();
                }
                string query = string.Empty;
                query = _accountno == 0 ? "" : "Account=" + _accountno + " and ";
                query = query + (_productType == "All" ? "" : "ProductType='" + _productType + "' and ");
                query = query + (_orderType == "All" ? "" : "OrderType='" + _orderType + "' and ");
                query = query + (_bS == "All" ? "" : "BS='" + _bS + "' and ");
                if (OrderStatus.Trim() != "Non Settled")
                {
                    query = query + (_orderStatus == "All" ? "" : "OrderStatus='" + _orderStatus + "' and ");
                }
                query = query + (_contract == "All" ? "" : "Contract='" + _contract + "' and ");
                //query = query + ("TransactTime >= '" + DateTime.Now.Date + "' and ");
                query = query + ("TransactTime >='" + FromDate.Date + "' AND  TransactTime <='" + ToDate.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM") + "' and ");
                if (query != string.Empty)
                {
                    query = query.Remove(query.Length - 5);
                    if (uctlOrderBookNew1.OrderStatus == "Non Settled")
                    {
                        uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query + ", all non settled orders";
                        Action A = () =>
                        {
                            query = query + " AND CumQty - SettledQty > 0";
                            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                               clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
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
                    else
                    {
                        uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query;
                        //Binding bi = new Binding("DefaultCellStyle.BackColor", Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query), "clmColor");
                        //uctlOrderBookNew1.ui_uctlGridOrderBook.DataBindings.Add(bi);
                        Action A = () =>
                        {
                            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                               clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                            }
                            //DataRow[] r = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                            // gridCustomization();
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
                else if (OrderStatus == "Non Settled")
                {
                    uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query + ", all non settled orders";
                    Action A = () =>
                    {
                        query = query + " CumQty - SettledQty > 0";
                        if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                            uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                        else
                        {
                            clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                            uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                           clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
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
                else
                {
                    uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "All Orders";
                    if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                           clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
                    else
                    {
                        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                   clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
                    }
                }

            }
        }


        private void INSTANCE_OnBusinessLevelReject(DataRow obj, BusinessReject objBusinessReject)
        {
            Action A = () =>
            {
                System.Threading.Thread.Sleep(300);
                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort =
                    "ClientOrderId Desc";
                //uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                //    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable();
                if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();//Namo
                //uctlOrderBookNew1_SelectionCriteriaChanged();//Namo
                //gridCustomization();
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
        private void gridCustomization()
        {
            uctlOrderBookNew1.ui_uctlGridOrderBook.EnableCellCustomDraw = false;
            int sellQty = 0;
            int buyQty = 0;
            for (int i = 0; i < uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count; i++)
            {
                int j = i;
                if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null &&
                    uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.ToString() ==
                    Color.DarkGreen.Name)
                {
                    uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.ForeColor =
                        Color.White;
                }
                if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null)
                    uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.BackColor =
                        Color.FromName(
                            uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.
                                ToString());
                if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "REJECTED" || uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "CANCELLED")
                {
                    if (
                        uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmBS"].Value.ToString()
                            .ToUpper() == "SELL")
                    {
                        sellQty +=
                            Convert.ToInt32(
                                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
                                    .Value.ToString());
                    }
                    else
                    {
                        buyQty +=
                            Convert.ToInt32(
                                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
                                    .Value.ToString());
                    }
                }
            }
            uctlOrderBookNew1.SellQty = Convert.ToString(sellQty);
            uctlOrderBookNew1.BuyQty = Convert.ToString(buyQty);
        }
        private void frmOrderBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport -= INSTANCE_ExecutionReport;
            _formkey = CommandIDS.ORDER_BOOK.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlOrderBookNew1.CurrentProfileName;
        }

        private void ui_ndgvGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = uctlOrderBookNew1.ui_uctlGridOrderBook.Columns[e.ColumnIndex];
            if (oldColumn == null)
                oldColumn = uctlOrderBookNew1.ui_uctlGridOrderBook.Columns["clmOrderNumber"];
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
                ClsCommonMethods.ShowErrorBox("Select a single column and try again.");
            }
            else
            {
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending
                        ? SortOrder.Ascending
                        : SortOrder.Descending;
            }
            oldColumn = newColumn;
            //DataView dv = new DataView(Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory);
            if (direction != ListSortDirection.Ascending)
                dir = "Desc";
            else
                dir = "Asc";

            //DataTable dt2 = Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Clone();
            //dt2.Columns["ClientOrderID"].DataType = Type.GetType("System.Int32");

            //foreach (DataRow dr in Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows)
            //{
            //    dt2.ImportRow(dr);
            //}
            //dt2.AcceptChanges();
            //DataView dv = dt2.DefaultView;
            DataView dv = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView;
            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Columns[e.ColumnIndex].DataPropertyName != string.Empty)
            {
                dv.Sort = uctlOrderBookNew1.ui_uctlGridOrderBook.Columns[e.ColumnIndex].DataPropertyName + " " + dir;
                var dt = new DataTable();
                dt = dv.ToTable();
                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource = dt;
            }
        }

        private void INSTANCE_OnOrderHistoryResponse()
        {
            if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory, 1000))
            {
                try
                {
                    Action A = () =>
                   {
                       if (clsTWSOrderManagerJSON.INSTANCE != null)
                       {
                           //lock (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory)
                           //{
                           clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort = "OrderID Desc";
                           clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Columns["ClientOrderId"].DataType =
                               Type.GetType("System.Int32");
                           //uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                           //    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable();
                           //uctlOrderBookNew1_SelectionCriteriaChanged();//Namo
                           //lock (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory)
                           //{
                           if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                               clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
                           else
                           {
                               clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                               clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
                           }
                           //}
                           //gridCustomization();
                           // }
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
                finally
                {
                    System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory);
                }
            }
        }

        private void INSTANCE_ExecutionReport(Cls.ExecutionReport executionReport)
        {
            //uctlOrderBookNew1.ui_uctlGridOrderBook.Refresh();
            Action A = () =>
            {
                if (clsTWSOrderManagerJSON.INSTANCE != null)
                {
                    lock (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory)
                    {
                        //clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();

                        ////clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.Sort =
                        ////    "ClientOrderId Desc";
                        ////clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();

                        if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count == 1)
                        {
                            uctlOrderBookNew1_SelectionCriteriaChanged();
                        }
                        else if (uctlOrderBookNew1.AccountNo.ToString().ToUpper() != "ALL" || uctlOrderBookNew1.ProductType.ToUpper() != "ALL" || uctlOrderBookNew1.OrderType.ToUpper() != "ALL" || uctlOrderBookNew1.BS.ToUpper() != "ALL" || uctlOrderBookNew1.OrderStatus.ToUpper() != "ALL")
                        {
                            uctlOrderBookNew1_SelectionCriteriaChanged();
                        }
                        else
                        {
                            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.AcceptChanges();
                            }
                        }
                        //uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                        //    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.DefaultView.ToTable
                        //        ();
                        //// uctlOrderBookNew1_SelectionCriteriaChanged();//Namo
                        //gridCustomization();
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

        private void uctlOrders_HandleRefreshClick(object arg1, EventArgs arg2)
        {
            clsTWSOrderManagerJSON.INSTANCE.RefreshOrders();
        }

        private void uctlOrders_HandleCloseOrderClick(object arg1, EventArgs arg2)
        {
            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count > 0)
            {

                string orderStatus = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();

                if (orderStatus == "FILLED" || orderStatus == "PARTIALLY_FILLED")
                {
                    DateTime expiryDateTime = DateTime.UtcNow;
                    DateTime transactTime = DateTime.UtcNow;
                    DateTime.TryParse(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                    double transTime = transactTime.ToOADate();
                    DateTime.TryParse(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                    string pType = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductType"].Value.ToString();
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

                    string _side = string.Empty;

                    if (uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString().Trim().ToUpper() == "BUY")
                    {
                        _side = "SELL";
                    }
                    else
                    {
                        _side = "BUY";
                    }
                    sbyte ordType = TWS.Cls.ClsGlobal.DDOrderTypes[uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderType"].Value.ToString()];
                    sbyte side = TWS.Cls.ClsGlobal.DDSide[_side];
                    int Account = Convert.ToInt32(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmClient"].Value.ToString());
                    string clOrdId = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string CloseClOrdID = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                    string CloseOrderID = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();

                    string ContractName = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmContract"].Value.ToString().Trim();
                    string ProductType = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                    sbyte Producttype = TWS.Cls.ClsGlobal.DDProductTypes[pType];
                    int digit = 0;
                    if (ClsGlobal.DDContractDigit.ContainsKey(ContractName))
                    {
                        digit = ClsGlobal.DDContractDigit[ContractName];
                    }
                    int Contractsize = 1;
                    if (ClsGlobal.DDContractSize.ContainsKey(ContractName))
                    {
                        Contractsize = ClsGlobal.DDContractSize[ContractName];
                    }

                    double ordQty = 0;

                    ordQty = (Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTotalExecutedQuantity"].Value.ToString()) - Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["SettledQty"].Value.ToString())) * Contractsize;


                    double price = 0;

                    if (uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString().ToUpper() == "BUY")
                    {
                        price = TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName) * Math.Pow(10, digit);
                    }
                    else
                    {
                        price = TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName) * Math.Pow(10, digit);
                    }


                    double stopPx = Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTriggerPrice"].Value.ToString()) * Math.Pow(10, digit);
                    sbyte tif = TWS.Cls.ClsGlobal.DDValidity[uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmValidity"].Value.ToString()];
                    bool OCOrder = false;



                    clsTWSOrderManagerJSON.INSTANCE.CloseOrder(Account, clOrdId, ContractName, Producttype,
                                                            uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductName"].Value.ToString(), expiryDateTime,
                                                            uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmGateway"].Value.ToString(), clOrdId, side,
                                                            ordQty, ordType, price, stopPx, tif, 0, 0, transTime, 0, CloseClOrdID, CloseOrderID, OCOrder);
                }
                else
                {
                    ClsCommonMethods.ShowErrorBox(orderStatus + " Order can not be Closed.");
                    //ClsCommonMethods.ShowInformation(orderStatus + " Order can not be Closed.");
                }
            }
        }

        //private void INSTANCE_OnOrderHistoryResponse(List<ClientDLL_Model.Cls.Order.OrderHistory> lstOrderHistory)
        //{
        //    uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource = Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
        //}

        private void ApplyDefaultProfile(string profileName)
        {
            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlOrderBookNew1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlOrderBookNew1.ui_uctlGridOrderBook.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void OnProfileApplyClick(string profileName)
        {
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.OrderBook.ToString()];
            foreach (DataGridViewColumn col in uctlOrderBookNew1.ui_uctlGridOrderBook.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void SaveProfile(string profileName)
        {
            uctlOrderBookNew1.CurrentProfileName = profileName;
            _formkey = CommandIDS.ORDER_BOOK.ToString() + "/" + Convert.ToString(count) + "/" + profileName;

            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            streamWrite.Close();
        }

        

        #endregion "     METHODS    "

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            try
            {
                //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DoubleBuffered Method");

                Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                      BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv, setting, null);

               // FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DoubleBuffered Method");
            }
            catch (Exception)
            {


            }

        }
        void INSTANCE_OnOrderSettle()
        {
            //  uctlOrderBookNew1_SelectionCriteriaChanged();
        }
        private void uctlOrderBookNew1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count > 0)
            {
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["SaveAs"].Enabled = true;
                string OrderStatus =
                    uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();
                if (OrderStatus != "WORKING" && OrderStatus != "PARTIALLY_FILLED")
                {
                    uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CancelOrder"].Enabled = false;
                    uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;


                }
                else
                {
                    uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CancelOrder"].Enabled = true;
                    uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["ModifyOrder"].Enabled = true;

                }
                if (OrderStatus == "FILLED" || OrderStatus == "PARTIALLY_FILLED")
                {
                    double Orderqty = Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTotalExecutedQuantity"].Value.ToString()) - Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["SettledQty"].Value.ToString());
                    if (Orderqty > 0)
                    {
                        uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = true;
                    }
                    else
                        uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
                }
                else
                {
                    uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
                }
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = true;
            }
            else
            {
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["SaveAs"].Enabled = false;
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CancelOrder"].Enabled = false;
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["ModifyOrder"].Enabled = false;
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["Filter"].Enabled = false;
                uctlOrderBookNew1.ui_uctlGridOrderBook.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
            }
        }

        private void dtOrderHistory_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRowState drs = e.Row.RowState;
            x = "";
            y = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.IndexOf(e.Row);
            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count != 0 &&
                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[y] != null)
            {
                x = e.Row["Color"].ToString();

                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[y].DefaultCellStyle.BackColor = Color.FromName(x);
                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[y].Cells["clmStatus"].Value = e.Row["OrderStatus"].ToString();
                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[y].Cells["clmAvgPrice"].Value = e.Row["AvgPrice"].ToString();
                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[y].Cells["clmTotalExecutedQuantity"].Value =
                    e.Row["CumQty"].ToString();
            }
        }

        public void uctlOrderBookNew1_HandleCancelOrder(object arg1, EventArgs arg2)
        {
            try
            {
                if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count > 0)
                {
                    string orderStatus = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmStatus"].Value.ToString().ToUpper();

                    if (orderStatus != "CANCELED" && orderStatus != "FILLED")
                    {
                        DateTime expiryDateTime = DateTime.Now;
                        DateTime transactTime = DateTime.Now;
                        DateTime.TryParse(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTransactionTime"].Value.ToString(), out transactTime);
                        //double transTime = clsUtility.GetDoubleDate(transactTime);
                        DateTime.TryParse(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmSeriesExpiry"].Value.ToString(), out expiryDateTime);
                        string pType = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductType"].Value.ToString();
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

                        sbyte ordType = TWS.Cls.ClsGlobal.DDOrderTypes[uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderType"].Value.ToString()];
                        sbyte side = TWS.Cls.ClsGlobal.DDSide[uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString()];
                        uint Account = Convert.ToUInt32(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmClient"].Value.ToString());
                        string clOrdId = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString();
                        string ContractName = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmContract"].Value.ToString();
                        string ProductType = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductType"].Value.ToString();
                        sbyte Producttype = TWS.Cls.ClsGlobal.DDProductTypes[pType];

                        double ordQty = (Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderQuantity"].Value.ToString()) -
                            Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTotalExecutedQuantity"].Value.ToString()))
                            * Cls.ClsGlobal.DDContractSize[ContractName];
                        double price = 0;
                        if (!string.IsNullOrEmpty(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmPrice"].Value.ToString()))
                            price = Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmPrice"].Value.ToString());
                        double stopPx = Convert.ToDouble(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmTriggerPrice"].Value.ToString());
                        sbyte tif = TWS.Cls.ClsGlobal.DDValidity[uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmValidity"].Value.ToString()];

                        ClsCancelOrder objCalncelOrder = new ClsCancelOrder();
                        objCalncelOrder.Account = Account;
                        objCalncelOrder.ClOrdId = clOrdId;
                        objCalncelOrder.Contract = ContractName;
                        objCalncelOrder.Gateway = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmGateway"].Value.ToString();
                        objCalncelOrder.OrderID = Convert.ToInt32(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmOrderNumber"].Value.ToString());
                        objCalncelOrder.OrderQty = ordQty;
                        objCalncelOrder.OrderType = Convert.ToChar(ordType);
                        objCalncelOrder.origClOrdId = clOrdId;
                        objCalncelOrder.PositionEffect = '0';
                        objCalncelOrder.Price = price * Math.Pow(10, Cls.ClsGlobal.DDContractDigit[ContractName]);
                        objCalncelOrder.Product = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmProductName"].Value.ToString();
                        objCalncelOrder.ProductType = Convert.ToChar(Producttype);
                        objCalncelOrder.Side = Convert.ToChar(side);
                        objCalncelOrder.StopPx = stopPx * Math.Pow(10, Cls.ClsGlobal.DDContractDigit[ContractName]);
                        objCalncelOrder.TimeInForce = Convert.ToChar(tif);

                        clsTWSOrderManagerJSON.INSTANCE.CancelOrder(objCalncelOrder);
                    }
                    else
                    {
                        ClsCommonMethods.ShowInformation(orderStatus + " Order can not be canceled.");
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        public void uctlOrderBookNew1_HandleModifyOrderClick(object arg1, EventArgs arg2)
        {
            if (!uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmStatus"].Value.ToString().Contains("FILLED"))
            {
                string side = uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
                if (!frmOrderEntry.INSTANCE.IsDisposed)
                {
                    frmOrderEntry.INSTANCE.Title = "Modify Order " +
                                                   uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells[
                                                       "clmOrderNumber"].Value;
                    ;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = side;
                    Color color = side == "BUY"
                                      ? Properties.Settings.Default.BuyOrderColor
                                      : Properties.Settings.Default.SellOrderColor;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
                    frmOrderEntry.INSTANCE.MdiParent = MdiParent;
                    frmOrderEntry.INSTANCE.Show();
                    //uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.Mode = CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_nbtnSubmit.Text = "&Modify";
                    frmOrderEntry.INSTANCE.FillValuesToModify(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0]);
                    frmOrderEntry.INSTANCE.Activate();
                }
                else
                {
                    frmOrderEntry.INSTANCE = new frmOrderEntry(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0],
                                                               CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY);
                    frmOrderEntry.INSTANCE.Title = "Modify Order " +
                                                   uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells[
                                                       "clmOrderNumber"].Value;
                    ;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.Caption = side;
                    Color color = side == "BUY"
                                      ? Properties.Settings.Default.BuyOrderColor
                                      : Properties.Settings.Default.SellOrderColor;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_npnlOrderEntry.BackColor = color;
                    frmOrderEntry.INSTANCE.MdiParent = MdiParent;
                    frmOrderEntry.INSTANCE.Show();
                    //uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0].Cells["clmBS"].Value.ToString();
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.Mode = CommonLibrary.Cls.ClsGlobal.OrderMode.MODIFY;
                    frmOrderEntry.INSTANCE.uctlOrderEntry1.ui_nbtnSubmit.Text = "&Modify";
                    frmOrderEntry.INSTANCE.FillValuesToModify(uctlOrderBookNew1.ui_uctlGridOrderBook.SelectedRows[0]);
                }
            }
            else
            {
                ClsCommonMethods.ShowInformation("Filled orders can not be modified.");
            }
        }

        private void uctlOrderBookNew1_Click(object sender, EventArgs e)
        {
            Activate();
        }

        private void uctlOrderBookNew1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlOrderBookNew1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlOrderBookNew1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            Properties.Settings.Default.OrderBookProfile = profileName;
            Properties.Settings.Default.Save();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory, 500))
            {
                try
                {

                    if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count > 0)
                    {
                        int _accountno = uctlOrderBookNew1.AccountNo;
                        string _orderStatus = uctlOrderBookNew1.OrderStatus;
                        string _productType = uctlOrderBookNew1.ProductType;
                        if (_orderStatus == "Non Settled")
                        {
                            _orderStatus = string.Empty;
                        }
                        string _orderType = uctlOrderBookNew1.OrderType;
                        string _bS = uctlOrderBookNew1.BS;
                        string _contract = uctlOrderBookNew1.Contract;
                        if (_orderStatus != "All" && _orderStatus != "Non Settled")
                        {
                            _orderStatus = _orderStatus.Trim().Replace(' ', '_');
                            _orderStatus = _orderStatus.ToUpper();
                        }
                        if (_productType != "All")
                        {
                            _productType = _productType.Trim().Replace(' ', '_');
                            _productType = _productType.ToUpper();
                        }
                        if (_contract != "All")
                        {
                            _contract = _contract.Trim().Replace(' ', '_');
                            _contract = _contract.ToUpper();
                        }
                        if (_orderType != "All")
                        {
                            _orderType = _orderType.Replace(' ', '_');
                            _orderType = _orderType.ToUpper();
                        }
                        if (_bS != "All")
                        {
                            _bS = _bS.Replace(' ', '_');
                            _bS = _bS.ToUpper();
                        }
                        string query = string.Empty;
                        query = _accountno == 0 ? "" : "Account=" + _accountno + " and ";
                        query = query + (_productType == "All" ? "" : "ProductType='" + _productType + "' and ");
                        query = query + (_orderType == "All" ? "" : "OrderType='" + _orderType + "' and ");
                        query = query + (_bS == "All" ? "" : "Side='" + _bS + "' and ");
                        if (uctlOrderBookNew1.OrderStatus != "Non Settled")
                        {
                            query = query + (_orderStatus == "All" ? "" : "OrderStatus='" + _orderStatus + "' and ");
                        }
                        query = query + (_contract == "All" ? "" : "Contract='" + _contract + "' and ");
                        //  query = query + ("TransactTime >= '" + DateTime.Now.Date + "' and ");
                        if (query != string.Empty)
                        {
                            query = query.Remove(query.Length - 5);
                            if (uctlOrderBookNew1.OrderStatus == "Non Settled")
                            {
                                uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query + ", all non settled orders";
                                Action A = () =>
                                {
                                    query = query + " AND CumQty - SettledQty > 0";
                                    if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                            clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                    else
                                    {
                                        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                         clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
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
                            else
                            {
                                uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query;
                                //Binding bi = new Binding("DefaultCellStyle.BackColor", Cls.clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query), "clmColor");
                                //uctlOrderBookNew1.ui_uctlGridOrderBook.DataBindings.Add(bi);
                                Action A = () =>
                                {
                                    if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                            clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                    else
                                    {
                                        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                        uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                         clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                    }
                                    //DataRow[] r = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                    // gridCustomization();
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
                        else if (uctlOrderBookNew1.OrderStatus == "Non Settled")
                        {
                            uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "Select " + query + ", all non settled orders";
                            Action A = () =>
                            {
                                query = query + " CumQty - SettledQty > 0";
                                if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                    uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                        clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                    uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                     clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
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
                        else
                        {
                            uctlOrderBookNew1.ui_nsbOrderSatusBar.Panels[1].Text = "All Orders";
                            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS != null)
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                    clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS = new TWS.DS.DS4OrderHistory();
                                uctlOrderBookNew1.ui_uctlGridOrderBook.DataSource =
                                clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory;
                            }
                        }
                        //  gridCustomization();
                    }

                }
                finally
                {
                    System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory);
                }
            }
        }

        private void uctlOrderBookNew1_SelectionCriteriaChanged()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void uctlOrderBookNew1_OnAccountChanged()
        {
            clsTWSOrderManagerJSON.INSTANCE._orderId.Clear();
            clsTWSOrderManagerJSON.INSTANCE.RequestForOrderHistoryOfAccount(uctlOrderBookNew1.AccountNo);
        }

        private void bw_DoWork1(object sender, DoWorkEventArgs e)
        {
            lock (clsTWSOrderManagerJSON.INSTANCE.objLock)
            {
                uctlOrderBookNew1.ui_uctlGridOrderBook.EnableCellCustomDraw = false;
                int sellQty = 0;
                int buyQty = 0;
                lock (uctlOrderBookNew1.ui_uctlGridOrderBook)
                {
                    for (int i = 0; i < uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count; i++)
                    {
                        int j = i;
                        if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows.Count > 0)
                        {
                            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null &&
                                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.ToString() ==
                                Color.DarkGreen.Name)
                            {
                                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.ForeColor =
                                    Color.White;
                            }
                            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value != null)
                                uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].DefaultCellStyle.BackColor =
                                    Color.FromName(
                                        uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmColor"].Value.
                                            ToString());
                            if (uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "REJECTED" || uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmStatus"].Value.ToString().ToUpper() != "CANCELLED")
                            {
                                if (
                                    uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmBS"].Value.ToString()
                                        .ToUpper() == "SELL")
                                {
                                    sellQty +=
                                        Convert.ToInt32(
                                            uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
                                                .Value.ToString());
                                }
                                else
                                {
                                    buyQty +=
                                        Convert.ToInt32(
                                            uctlOrderBookNew1.ui_uctlGridOrderBook.Rows[j].Cells["clmOrderQuantity"]
                                                .Value.ToString());
                                }
                            }
                        }
                    }
                }
                uctlOrderBookNew1.SellQty = Convert.ToString(sellQty);
                uctlOrderBookNew1.BuyQty = Convert.ToString(buyQty);
            }

        }
        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Namo
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += bw_DoWork1;
            //bw.RunWorkerAsync();
        }


        private void frmOrderBook_KeyDown(object sender, KeyEventArgs e)
        {
            //if (((DataGridView)sender).Rows.Count >= e.NewValue && e.NewValue > 1)
            //{
            //    ((DataGridView)sender).FirstDisplayedScrollingRowIndex = e.NewValue;
            //    ((DataGridView)sender).Rows[e.NewValue].Selected = true;
            //} e.NewValue += 10;
        }
    }
}