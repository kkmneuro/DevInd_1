/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//30 Jun 2014	Namo					Code is optimized for upnl calculation
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using TWS.DS;


namespace TWS.Frm
{
    public partial class frmTradeWindowFilter : frmBase
    {
        private static int count;
        private string _formkey;
        private object _objProfiles;
        private DataTable dtTradeGrid;
        FrmMain objFrmMain;

        public frmTradeWindowFilter(object objProfiles, string currentProfile, Keys SkeyFilter, FrmMain _objFrmMain)
        {
            InitializeComponent();
            dtTradeGrid = new DataTable();
            objFrmMain = _objFrmMain;
            _objProfiles = objProfiles;
            uctlTradeWindow1.ShortcutKeyFilter = SkeyFilter;
            uctlTradeWindow1.Profile = objProfiles;
            uctlTradeWindow1.CurrentProfileName = currentProfile;
            count += 1;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlTradeWindow1.CurrentProfileName;
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


        private void frmTradeWindow_Load(object sender, EventArgs e)
        {
            Cls.ClsGlobal.IsTradeBookOpen = true;

            var orderStatus = new List<string>();
            var orderTypes = new List<string>();
            var side = new List<string>();

            orderStatus.Clear();
            orderStatus.Add("All");
            orderStatus.Add("Settled");
            orderStatus.Add("Non Settled");
            orderTypes.Add("All");
            side.Add("All");

            uctlTradeWindow1.AddContracts(ClsTWSContractManager.INSTANCE.LstContract.ToArray());
            uctlTradeWindow1.FillProductTypes(ClsTWSContractManager.INSTANCE.LstProductTypes.ToArray());
            foreach (string x in TWS.Cls.ClsGlobal.DDOrderTypes.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                orderTypes.Add(c);
            }

            foreach (string x in TWS.Cls.ClsGlobal.DDSide.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                side.Add(c);
            }
            uctlTradeWindow1.AddOrderStatus(orderStatus.ToArray());
            uctlTradeWindow1.AddOrderTypes(orderTypes.ToArray());
            uctlTradeWindow1.AddSide(side.ToArray());

            uctlTradeWindow1.SelectionCriteriaChanged -= uctlTradeWindow1_SelectionCriteriaChanged;
            uctlTradeWindow1.SelectionCriteriaChanged += uctlTradeWindow1_SelectionCriteriaChanged;
            uctlTradeWindow1.OnSearchClick -= new Action<int, string, string, string, string, DateTime, DateTime>(uctlTradeWindow1_OnSearchClick);
            uctlTradeWindow1.OnSearchClick += new Action<int, string, string, string, string, DateTime, DateTime>(uctlTradeWindow1_OnSearchClick);
            List<string> lstAccountNos = clsTWSOrderManagerJSON.INSTANCE.GetParticipants();
            lstAccountNos.Insert(0, "All");
            uctlTradeWindow1.AddAccounts(lstAccountNos);


            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_DoHandleExecutionReport;
            clsTWSOrderManagerJSON.INSTANCE.DoHandleTradeHistoryResponse += INSTANCE_DoHandleTradeHistoryResponse;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderSettle -= new Action(INSTANCE_OnOrderSettle);
            clsTWSOrderManagerJSON.INSTANCE.OnOrderSettle += new Action(INSTANCE_OnOrderSettle);
            Title = uctlTradeWindow1.Title;

            if (TWS.Cls.ClsGlobal.MarketMakerAccountId > 0)
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterAvgPx"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterClOrdId"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["GrossPL"].Visible = true;
            }
            DoubleBuffered(uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid, true);
            dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
            uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;//Namo
            if (uctlTradeWindow1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlTradeWindow1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
                }
            }
            uctlTradeWindow1.HandleCloseOrderClick -= uctlTradeWindow1_HandleCloseOrderClick;
            uctlTradeWindow1.HandleCloseOrderClick += uctlTradeWindow1_HandleCloseOrderClick;
            uctlTradeWindow1.HandleRefreshClick -= uctlTradeWindow1_HandleRefreshClick;
            uctlTradeWindow1.HandleRefreshClick += uctlTradeWindow1_HandleRefreshClick;
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 -= INSTANCE_OnLTPChange;
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 += INSTANCE_OnLTPChange;
            uctlTradeWindow1.ui_uctlGridTradeWindow.AutoSizeColumsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void uctlTradeWindow1_HandleRefreshClick(object arg1, EventArgs arg2)
        {
            clsTWSOrderManagerJSON.INSTANCE.RefreshOrders();
            dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
            dtTradeGrid.AcceptChanges();
        }

        private void uctlTradeWindow1_HandleCloseOrderClick(object arg1, EventArgs arg2)
        {
            if (uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count > 0)
            {
                try
                {
                    DateTime expiryDateTime = DateTime.UtcNow;
                    DateTime transactTime = DateTime.UtcNow;
                    DateTime.TryParse(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["TradeTime"].Value.ToString(), out transactTime);
                    double transTime = transactTime.ToOADate();
                    string pType = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["ProductType"].Value.ToString();
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

                    if (uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["BS"].Value.ToString().Trim().ToUpper() == "BUY")
                    {
                        _side = "SELL";
                    }
                    else
                    {
                        _side = "BUY";
                    }

                    sbyte ordType = TWS.Cls.ClsGlobal.DDOrderTypes[uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["OrderType"].Value.ToString()];
                    sbyte side = TWS.Cls.ClsGlobal.DDSide[_side];
                    int Account = Convert.ToInt32(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["Account"].Value.ToString());
                    string clOrdId = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["OrderNo"].Value.ToString();
                    string CloseClOrdID = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["OrderNo"].Value.ToString();
                    string CloseOrderID = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["OrderNo"].Value.ToString();

                    string ContractName = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["Contract"].Value.ToString();
                    string ProductType = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["ProductType"].Value.ToString();
                    sbyte Producttype = TWS.Cls.ClsGlobal.DDProductTypes[pType];
                    int digit = 0;
                    if (TWS.Cls.ClsGlobal.DDContractDigit.ContainsKey(ContractName))
                    {
                        digit = TWS.Cls.ClsGlobal.DDContractDigit[ContractName];
                    }
                    int Contractsize = 1;
                    if (TWS.Cls.ClsGlobal.DDContractSize.ContainsKey(ContractName))
                    {
                        Contractsize = TWS.Cls.ClsGlobal.DDContractSize[ContractName];
                    }

                    double ordQty = 0;
                    ordQty = (Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["Quantity"].Value.ToString()) - Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["SettledQty"].Value.ToString())) * Contractsize;

                    double price = 0;

                    if (uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["BS"].Value.ToString().ToUpper() == "BUY")
                    {
                        price = TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName) * Math.Pow(10, digit);
                    }
                    else
                    {
                        price = TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName) * Math.Pow(10, digit);
                    }
                    double stopPx = Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["TriggerPrice"].Value.ToString()) * Math.Pow(10, digit);
                    sbyte tif = sbyte.MinValue;
                    DataRow[] orderRow = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select("ClientOrderID = '" + clOrdId + "'");
                    if (orderRow.Length > 0)
                    {
                        string _tif = orderRow[0]["TimeInForce"].ToString();
                        if (TWS.Cls.ClsGlobal.DDValidity.Keys.Contains(_tif))
                            tif = TWS.Cls.ClsGlobal.DDValidity[_tif];

                        bool OCOrder = false;
                        string productName = uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["ProductName"].Value.ToString();
                        InstrumentSpec objInstrumentSpec = null;
                        //InstrumentSpec objInstrumentSpec = Cls.ClsTWSContractManager.INSTANCE.GetContractSpec(ContractName, ProductType, productName);
                        objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[ContractName];

                        DateTime.TryParse(objInstrumentSpec.ExpiryDate, out expiryDateTime);
                        if (tif != sbyte.MinValue)
                        {
                            clsTWSOrderManagerJSON.INSTANCE.CloseOrder(Account, clOrdId, ContractName, Producttype,
                                                              productName, expiryDateTime, objInstrumentSpec.Gateway, clOrdId, side,
                                                              ordQty, ordType, price, stopPx, tif, 0, 0, transTime, 0, CloseClOrdID, CloseOrderID, OCOrder);
                        }
                    }
                    else
                    {
                        ClsCommonMethods.ShowInformation("This order is already closed.");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        void INSTANCE_OnOrderSettle()
        {
            if (uctlTradeWindow1.AccountNo.ToString().ToUpper() != "ALL" || uctlTradeWindow1.ProductType.ToUpper() != "ALL" || uctlTradeWindow1.OrderType.ToUpper() != "ALL" || uctlTradeWindow1.BS.ToUpper() != "ALL" || uctlTradeWindow1.OrderStatus.ToUpper() != "ALL")
            {
                uctlTradeWindow1_SelectionCriteriaChanged();
            }
            else
            {
                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                {
                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                    dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                    dtTradeGrid.AcceptChanges();
                }
                else
                {
                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                    dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                    dtTradeGrid.AcceptChanges();
                }
            }

        }

        void uctlTradeWindow1_OnSearchClick(int AccountNo, string ProductType, string OrderType, string BS, string Contract, DateTime FromDate, DateTime ToDate)
        {
            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count > 0)
            {
                int _accountno = AccountNo;
                string _productType = ProductType;
                string _orderType = OrderType;
                string _bS = BS;
                DateTime _fromDate = FromDate;
                DateTime _toDate = ToDate;

                string _contract = Contract;
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
                if (_bS != "All")
                {
                    _bS = _bS.Replace(' ', '_');
                    _bS = _bS.ToUpper();
                }
                if (_contract != "All")
                {
                    _contract = _contract.Trim().Replace(' ', '_');
                    _contract = _contract.ToUpper();
                }
                string query = string.Empty;
                query = _accountno == 0 ? "" : "Account=" + _accountno + " and ";
                query = query + (_productType == "All" ? "" : "ProductType='" + _productType + "' and ");
                query = query + (_orderType == "All" ? "" : "OrderType='" + _orderType + "' and ");
                query = query + (_bS == "All" ? "" : "BS='" + _bS + "' and ");
                query = query + (_contract == "All" ? "" : "Contract='" + _contract + "' and ");
                query = query + ("TradeTime >='" + FromDate.Date + "' AND  TradeTime <='" + ToDate.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM") + "' and ");

                if (query != string.Empty)
                {
                    query = query.Remove(query.Length - 5);
                    if (uctlTradeWindow1.OrderStatus == "All")
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query;
                        if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                        {
                            DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                            if (dr.Length > 0)
                            {
                                dtTradeGrid = dr.CopyToDataTable();
                                uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                            }
                            else
                            {
                                dtTradeGrid.Rows.Clear();
                                dtTradeGrid.AcceptChanges();
                            }
                        }
                        else
                        {
                            clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                            DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                            if (dr.Length > 0)
                            {
                                dtTradeGrid = dr.CopyToDataTable();
                                uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                            }
                            else
                            {
                                dtTradeGrid.Rows.Clear();
                                dtTradeGrid.AcceptChanges();
                            }
                        }
                    }
                    else if (uctlTradeWindow1.OrderStatus == "Settled")
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all settled orders";
                        Action A = () =>
                        {
                            query = query + " AND Quantity  - SettledQty = 0";
                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                            {
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }

                            }
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
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
                    else
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all non settled orders";
                        Action A = () =>
                        {
                            query = query + " AND Quantity  - SettledQty > 0";
                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                            {
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }
                            }
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
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
                }
                else if (uctlTradeWindow1.OrderStatus != "All")
                {
                    if (uctlTradeWindow1.OrderStatus == "Settled")
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all settled orders";
                        Action A = () =>
                        {
                            query = query + " Quantity  - SettledQty = 0";
                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                            {
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }
                            }
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
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
                    else
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all non settled orders";
                        Action A = () =>
                        {
                            query = query + " Quantity  - SettledQty > 0";
                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                            {
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }
                            }
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
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
                }
                else
                {
                    uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "All Orders";
                    if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                    {
                        dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;

                    }
                    else
                    {
                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                        dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                    }
                }
                OrderCalculation();
            }
        }

        private void uctlTradeWindow1_SelectionCriteriaChanged()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count > 0)
                {
                    int _accountno = uctlTradeWindow1.AccountNo;
                    string _productType = uctlTradeWindow1.ProductType;
                    string _orderType = uctlTradeWindow1.OrderType;
                    string _bS = uctlTradeWindow1.BS;
                    string _contract = uctlTradeWindow1.Contract;
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
                    if (_bS != "All")
                    {
                        _bS = _bS.Replace(' ', '_');
                        _bS = _bS.ToUpper();
                    }
                    if (_contract != "All")
                    {
                        _contract = _contract.Trim().Replace(' ', '_');
                        _contract = _contract.ToUpper();
                    }
                    string query = string.Empty;
                    query = _accountno == 0 ? "" : "Account=" + _accountno + " and ";
                    query = query + (_productType == "All" ? "" : "ProductType='" + _productType + "' and ");
                    query = query + (_orderType == "All" ? "" : "OrderType='" + _orderType + "' and ");
                    query = query + (_bS == "All" ? "" : "BS='" + _bS + "' and ");
                    query = query + (_contract == "All" ? "" : "Contract='" + _contract + "' and ");
                    if (query != string.Empty)
                    {
                        query = query.Remove(query.Length - 5);
                        if (uctlTradeWindow1.OrderStatus == "All")
                        {
                            uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query;

                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                            {
                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }
                            }
                            else
                            {
                                clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();

                                DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                if (dr.Length > 0)
                                {
                                    dtTradeGrid = dr.CopyToDataTable();
                                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                }
                                else
                                {
                                    dtTradeGrid.Rows.Clear();
                                    dtTradeGrid.AcceptChanges();
                                }
                            }
                        }
                        else if (uctlTradeWindow1.OrderStatus == "Settled")
                        {
                            uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all settled orders";
                            Action A = () =>
                            {
                                query = query + " AND Quantity  - SettledQty = 0";
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                {
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
                                    }

                                }
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
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
                        else
                        {
                            uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all non settled orders";
                            Action A = () =>
                            {
                                query = query + " AND Quantity  - SettledQty > 0";
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                {
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
                                    }
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                }
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
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

                    }
                    else if (uctlTradeWindow1.OrderStatus != "All")
                    {
                        if (uctlTradeWindow1.OrderStatus == "Settled")
                        {
                            uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all settled orders";
                            Action A = () =>
                            {
                                query = query + " Quantity  - SettledQty = 0";
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                {
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
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
                        else
                        {
                            uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "Select " + query + ", all non settled orders";
                            Action A = () =>
                            {
                                query = query + " Quantity  - SettledQty > 0";
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                {
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                                    //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select(query);
                                    if (dr.Length > 0)
                                    {
                                        dtTradeGrid = dr.CopyToDataTable();
                                        uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                                    }
                                    else
                                    {
                                        dtTradeGrid.Rows.Clear();
                                        dtTradeGrid.AcceptChanges();
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
                    }
                    else
                    {
                        uctlTradeWindow1.ui_nsbTradeWindow.Panels[1].Text = "All Orders";
                        if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                        {
                            //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                            //   clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
                            dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                            uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                        }
                        else
                        {
                            clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS4TradeHistory();
                            // uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                            //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
                            dtTradeGrid = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Copy();
                            uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = dtTradeGrid;
                        }
                    }
                    //if (uctlTradeWindow1.OrderStatus=="Non Settled")
                    //{
                    OrderCalculation();
                    //}               
                }
            }
            catch (Exception)
            {


            }

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
        private void INSTANCE_DoHandleTradeHistoryResponse(List<Cls.ExecutionReport> lstExecutionReport)
        {
            Action A =
                () =>
                {
                    //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                    //    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
                    uctlTradeWindow1_SelectionCriteriaChanged();

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

        private void INSTANCE_DoHandleExecutionReport(Cls.ExecutionReport item)
        {

            //Action A = () =>
            //               {
            //                   //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
            //                   uctlTradeWindow1.ui_uctlGridTradeWindow.Refresh();
            //                   //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
            //               };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
            uctlTradeWindow1_SelectionCriteriaChanged();
        }

        private void ApplyDefaultProfile(string profileName)
        {
            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlTradeWindow1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlTradeWindow1.ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void OnProfileApplyClick(string profileName)
        {
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.Trade.ToString()];
            foreach (DataGridViewColumn col in uctlTradeWindow1.ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void frmTradeWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlTradeWindow1.CurrentProfileName;
        }

        private void uctlTradeWindow1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void SaveProfile(string profileName)
        {
            uctlTradeWindow1.CurrentProfileName = profileName;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" + profileName;

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

        private void uctlTradeWindow1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlTradeWindow1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            Properties.Settings.Default.TradeProfile = profileName;
            Properties.Settings.Default.Save();
        }

        private void uctlTradeWindow1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            if (uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count > 0)
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["Filter"].Enabled = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["SaveAs"].Enabled = true;
                double Orderqty = Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["Quantity"].Value.ToString()) - Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.SelectedRows[0].Cells["SettledQty"].Value.ToString());
                if (Orderqty > 0)
                {
                    uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["CloseOrder"].Enabled = true;
                }
                else
                    uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
            }
            else
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["Filter"].Enabled = false;
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["SaveAs"].Enabled = false;
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["CloseOrder"].Enabled = false;
            }


        }
        private void OrderCalculation()
        {
            if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory, 500))
            {
                try
                {
                    Action A = () =>
                    {
                        double sellQty = 0;
                        double buyQty = 0;
                        int totOrder = 0;
                        double sellVal = 0;
                        double buyVal = 0;
                        double sellAvg = 0;
                        double buyAvg = 0;
                        double buyATP = 0;
                        double sellATP = 0;

                        if (dtTradeGrid.Rows.Count > 0)
                        {
                            if (dtTradeGrid.Select("BS = 'SELL'").Length > 0)
                            {
                                sellQty = Convert.ToDouble(dtTradeGrid.Compute("Sum(Quantity)", "BS = 'SELL'"));
                                sellVal = Convert.ToDouble(dtTradeGrid.Compute("Sum(FillPrice)", "BS = 'SELL'"));
                                sellAvg = Convert.ToDouble(dtTradeGrid.Compute("Sum(AvgPrice)", "BS = 'SELL'"));
                            }
                            else
                            {
                                sellQty = 0;
                                sellVal = 0;
                                sellAvg = 0;
                            }
                            if (dtTradeGrid.Select("BS = 'BUY'").Length > 0)
                            {
                                buyQty = Convert.ToDouble(dtTradeGrid.Compute("Sum(Quantity)", "BS = 'BUY'"));
                                buyVal = Convert.ToDouble(dtTradeGrid.Compute("Sum(FillPrice)", "BS = 'BUY'"));
                                buyAvg = Convert.ToDouble(dtTradeGrid.Compute("Sum(AvgPrice)", "BS = 'BUY'"));
                            }
                            else
                            {
                                buyQty = 0;
                                buyVal = 0;
                                buyAvg = 0;
                            }

                            totOrder = dtTradeGrid.Rows.Count;
                        }
                        else
                        {
                            sellQty = 0;
                            sellVal = 0;
                            sellAvg = 0;
                            buyQty = 0;
                            buyVal = 0;
                            buyAvg = 0;
                            totOrder = 0;
                        }
                        if (buyQty > 0)
                        {
                            buyATP = buyVal / buyQty;
                        }
                        if (sellQty > 0)
                        {
                            sellATP = sellVal / sellQty;
                        }
                        uctlTradeWindow1.SellQty = Convert.ToString(sellQty);
                        uctlTradeWindow1.SellVal = Convert.ToString(sellVal);
                        uctlTradeWindow1.SellAtp = Math.Round(sellATP, 2).ToString();
                        uctlTradeWindow1.BuyQty = Convert.ToString(buyQty);
                        uctlTradeWindow1.BuyVal = Convert.ToString(buyVal);
                        uctlTradeWindow1.BuyAtp =Math.Round(buyATP,2).ToString();
                        uctlTradeWindow1.NoOfTotalOrder = Convert.ToString(totOrder);
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
                    System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                }
            }
        }

        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory, 500))
            {
                try
                {
                    Action A = () =>
                    {
                        double sellQty = 0;
                        double buyQty = 0;
                        int totOrder = 0;
                        double sellVal = 0;
                        double buyVal = 0;
                        double sellAvg = 0;
                        double buyAvg = 0;
                        sellQty = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(Quantity)", "BS = 'SELL'"));
                        sellVal = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(FillPrice)", "BS = 'SELL'"));
                        sellAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(AvgPrice)", "BS = 'SELL'"));
                        buyQty = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(Quantity)", "BS = 'BUY'"));
                        buyVal = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(FillPrice)", "BS = 'BUY'"));
                        buyAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(AvgPrice)", "BS = 'BUY'"));

                        totOrder = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count;
                        uctlTradeWindow1.SellQty = Convert.ToString(sellQty);
                        uctlTradeWindow1.SellVal = Convert.ToString(sellVal);
                        uctlTradeWindow1.SellAtp = Convert.ToString(sellAvg);
                        uctlTradeWindow1.BuyQty = Convert.ToString(buyQty);
                        uctlTradeWindow1.BuyVal = Convert.ToString(buyVal);
                        uctlTradeWindow1.BuyAtp = Convert.ToString(buyAvg);
                        uctlTradeWindow1.NoOfTotalOrder = Convert.ToString(totOrder);
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
                    System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                }
            }
        }
        double UrPnl = 0;
        void INSTANCE_onPnLUpdate(string ContractName)
        {
            //if (clsTWSOrderManagerJSON.INSTANCE._isTradeHistoryLoaded)
            {
                Action A = () =>
                {
                    try
                    {
                        if (System.Threading.Monitor.TryEnter(dtTradeGrid, 500) && System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory, 500))
                        {
                            try
                            {
                                DataRow[] rws = null;
                                if (uctlTradeWindow1.Contract != "All")
                                {
                                    if (uctlTradeWindow1.Contract != ContractName)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        if (dtTradeGrid != null)
                                            rws = dtTradeGrid.Select("Contract = '" + ContractName + "' AND Quantity -SettledQty >0");
                                    }

                                }
                                else
                                {
                                    if (dtTradeGrid != null)
                                        rws = dtTradeGrid.Select("Contract = '" + ContractName + "' AND Quantity -SettledQty >0");
                                }
                                if (rws.Length > 0)
                                {
                                    foreach (DataRow rw in rws)
                                    {
                                        DataRow[] thDrw = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select("OrderNo = '" + rw["OrderNo"].ToString() + "'");
                                        int qty = (Convert.ToInt32(rw["Quantity"].ToString()) - Convert.ToInt32(rw["SettledQty"].ToString()));

                                        if (qty > 0)
                                        {
                                            if (rw["BS"].ToString().ToUpper() == "BUY")
                                            {
                                                if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString())) > 0)
                                                {
                                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                    {
                                                        double _pnl = 0.0;
                                                        if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        else
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        rw["PnL"] = _pnl;
                                                        rw.AcceptChanges();
                                                        thDrw[0]["PnL"] = _pnl;
                                                        thDrw[0].AcceptChanges();

                                                    }
                                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                    {
                                                        double _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                        rw["PnL"] = _pnl;
                                                        rw.AcceptChanges();
                                                        thDrw[0]["PnL"] = _pnl;
                                                        thDrw[0].AcceptChanges();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString())) > 0)
                                                {
                                                    if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                    {
                                                        double _pnl = 0.0;
                                                        if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);

                                                        }
                                                        else
                                                        {
                                                            _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                        }
                                                        rw["PnL"] = _pnl;
                                                        rw.AcceptChanges();
                                                        thDrw[0]["PnL"] = _pnl;
                                                        thDrw[0].AcceptChanges();
                                                    }
                                                    else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                    {
                                                        double _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                        rw["PnL"] = _pnl;
                                                        rw.AcceptChanges();
                                                        thDrw[0]["PnL"] = _pnl;
                                                        thDrw[0].AcceptChanges();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (rw["PnL"].ToString() != "0")
                                            {
                                                rw["PnL"] = 0;
                                                rw.AcceptChanges();
                                            }
                                        }
                                        //rw.AcceptChanges();
                                        //if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                        //    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                                        //    onPnLUpdate(ContractName);
                                    }
                                }
                            }

                            finally
                            {
                                System.Threading.Monitor.Exit(dtTradeGrid);
                                System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                            }
                            if (Properties.Settings.Default.AccountType.ToUpper().Trim() != "BROKER")
                            {
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count > 0)
                                {
                                    if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                        UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                    else
                                    {
                                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS.DS4TradeHistory();
                                        UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                    }
                                }
                                double balance = 0;
                                double margin = 0;
                                if (objFrmMain.tlsBalanceValue.Text != string.Empty)
                                    balance = Convert.ToDouble(objFrmMain.tlsBalanceValue.Text);

                                if (objFrmMain.tlsMarginValue.Text != string.Empty)
                                {
                                    margin = Convert.ToDouble(objFrmMain.tlsMarginValue.Text);
                                    objFrmMain.lblUsedMargin.Visible = true;
                                    objFrmMain.lblMarginLevel.Visible = true;
                                    objFrmMain.tlsMarginValue.Visible = true;
                                    objFrmMain.tlsMarginLevelValue.Visible = true;
                                }
                                else
                                {
                                    objFrmMain.lblUsedMargin.Visible = false;
                                    objFrmMain.lblMarginLevel.Visible = false;
                                    objFrmMain.tlsMarginValue.Visible = false;
                                    objFrmMain.tlsMarginLevelValue.Visible = false;
                                }
                                objFrmMain.lblPL.Text = Math.Round(UrPnl, 2).ToString("0.00");
                                objFrmMain.tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                                objFrmMain.tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(objFrmMain.tlsEquityValue.Text) - margin, 2));
                                if (margin == 0)
                                {
                                    objFrmMain.tlsMarginLevelValue.Text = "";
                                }
                                else
                                {
                                    objFrmMain.tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(objFrmMain.tlsEquityValue.Text) / margin * 100, 2));
                                }
                            }

                        }
                        //if (uctlTradeWindow1.OrderStatus=="Non Settled")
                        //{
                        //    uctlTradeWindow1_SelectionCriteriaChanged(); 
                        //}                        
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

        private void INSTANCE_OnLTPChange(string ContractName, double marketpriceAskBid)
        {
            Action A = () =>
            {
                try
                {
                    if (System.Threading.Monitor.TryEnter(dtTradeGrid, 500) && System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory, 500))
                    {
                        try
                        {
                            DataRow[] rws = null;
                            if (uctlTradeWindow1.Contract != "All")
                            {
                                if (uctlTradeWindow1.Contract != ContractName)
                                {
                                    return;
                                }
                                else
                                {
                                    if (dtTradeGrid != null)
                                        rws = dtTradeGrid.Select("Contract = '" + ContractName + "' AND Quantity -SettledQty >0");
                                }
                            }
                            else
                            {
                                if (dtTradeGrid != null)
                                    rws = dtTradeGrid.Select("Contract = '" + ContractName + "' AND Quantity -SettledQty >0");
                            }
                            if (rws.Length > 0)
                            {
                                foreach (DataRow rw in rws)
                                {
                                    rw["FillPrice"] = Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()));
                                    DataRow[] thDrw = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Select("OrderNo = '" + rw["OrderNo"].ToString() + "'");
                                    int qty = (Convert.ToInt32(rw["Quantity"].ToString()) - Convert.ToInt32(rw["SettledQty"].ToString()));

                                    if (qty > 0)
                                    {
                                        if (rw["BS"].ToString().ToUpper() == "BUY")
                                        {
                                            if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(rw["Contract"].ToString())) > 0)
                                            {
                                                if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                {
                                                    double _pnl = 0.0;
                                                    if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                    {
                                                        _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                    }
                                                    else
                                                    {
                                                        _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                    }
                                                    rw["PnL"] = _pnl;
                                                    rw.AcceptChanges();
                                                    thDrw[0]["PnL"] = _pnl;
                                                    thDrw[0].AcceptChanges();

                                                }
                                                else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                {
                                                    double _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()) - Convert.ToDouble(rw["AvgPrice"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                    rw["PnL"] = _pnl;
                                                    rw.AcceptChanges();
                                                    thDrw[0]["PnL"] = _pnl;
                                                    thDrw[0].AcceptChanges();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(rw["Contract"].ToString())) > 0)
                                            {
                                                if (rw["ProductType"].ToString().ToUpper() == "FUTURE")
                                                {
                                                    double _pnl = 0.0;
                                                    if (rw["ProductName"].ToString().ToUpper() == "CPF")
                                                    {
                                                        _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);

                                                    }
                                                    else
                                                    {
                                                        _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()], 2);
                                                    }
                                                    rw["PnL"] = _pnl;
                                                    rw.AcceptChanges();
                                                    thDrw[0]["PnL"] = _pnl;
                                                    thDrw[0].AcceptChanges();
                                                }
                                                else if (rw["ProductType"].ToString().ToUpper() == "FOREX")
                                                {
                                                    double _pnl = Math.Round(qty * (Convert.ToDouble(rw["AvgPrice"].ToString()) - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(rw["Contract"].ToString()))) * TWS.Cls.ClsGlobal.DDContractSize[rw["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[rw["Contract"].ToString()], 2);
                                                    rw["PnL"] = _pnl;
                                                    rw.AcceptChanges();
                                                    thDrw[0]["PnL"] = _pnl;
                                                    thDrw[0].AcceptChanges();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (rw["PnL"].ToString() != "0")
                                        {
                                            rw["PnL"] = 0;
                                            rw.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }

                        finally
                        {
                            System.Threading.Monitor.Exit(dtTradeGrid);
                            System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                        }
                        if (Properties.Settings.Default.AccountType.ToUpper().Trim() != "BROKER")
                        {
                            if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count > 0)
                            {
                                if (clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS != null)
                                    UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                else
                                {
                                    clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS = new DS.DS4TradeHistory();
                                    UrPnl = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Compute("Sum(PnL)", ""));
                                }
                            }
                            double balance = 0;
                            double margin = 0;
                            if (objFrmMain.tlsBalanceValue.Text != string.Empty)
                                balance = Convert.ToDouble(objFrmMain.tlsBalanceValue.Text);

                            if (objFrmMain.tlsMarginValue.Text != string.Empty)
                            {
                                margin = Convert.ToDouble(objFrmMain.tlsMarginValue.Text);
                                objFrmMain.lblUsedMargin.Visible = true;
                                objFrmMain.lblMarginLevel.Visible = true;
                                objFrmMain.tlsMarginValue.Visible = true;
                                objFrmMain.tlsMarginLevelValue.Visible = true;
                            }
                            else
                            {
                                objFrmMain.lblUsedMargin.Visible = false;
                                objFrmMain.lblMarginLevel.Visible = false;
                                objFrmMain.tlsMarginValue.Visible = false;
                                objFrmMain.tlsMarginLevelValue.Visible = false;
                            }
                            objFrmMain.lblPL.Text = Math.Round(UrPnl, 2).ToString("0.00");
                            objFrmMain.tlsEquityValue.Text = Convert.ToString(Math.Round(balance + UrPnl, 2));
                            objFrmMain.tlsFreeMarginValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(objFrmMain.tlsEquityValue.Text) - margin, 2));
                            if (margin == 0)
                            {
                                objFrmMain.tlsMarginLevelValue.Text = "";
                            }
                            else
                            {
                                objFrmMain.tlsMarginLevelValue.Text = Convert.ToString(Math.Round(Convert.ToDouble(objFrmMain.tlsEquityValue.Text) / margin * 100, 2));
                            }
                        }

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

        void INSTANCE_onPnLUpdate1(string ContractName)
        {
            if (uctlTradeWindow1.OrderStatus == "Non Settled")
            {
                if (clsTWSOrderManagerJSON.INSTANCE._isTradeHistoryLoaded && Properties.Settings.Default.AccountType.ToUpper().Trim() == "BROKER")
                {
                    Action A = () =>
                    {
                        try
                        {
                            if (System.Threading.Monitor.TryEnter(this.uctlTradeWindow1.ui_uctlGridTradeWindow, 1000))
                            {
                                try
                                {
                                    if (this.uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count; i++)
                                        {
                                            string _contractName = uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Contract"].Value.ToString();
                                            if (_contractName.ToUpper() == ContractName.ToUpper())
                                            {
                                                int qty = (Convert.ToInt32(uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Quantity"].Value) - Convert.ToInt32(uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["SettledQty"].Value));

                                                if (qty > 0)
                                                {
                                                    string _productType = uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["ProductType"].Value.ToString().ToUpper();
                                                    string _productName = uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["ProductName"].Value.ToString().ToUpper();
                                                    double _avgPrice = Convert.ToDouble(uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["AvgPrice"].Value.ToString());
                                                    if (uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["BS"].ToString().ToUpper() == "BUY")
                                                    {
                                                        if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(_contractName)) > 0)
                                                        {
                                                            if (_productType == "FUTURE")
                                                            {
                                                                double _pnl = 0.0;
                                                                if (_productName == "CPF")
                                                                {
                                                                    _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(_contractName) - _avgPrice)) * TWS.Cls.ClsGlobal.DDContractSize[_contractName], 2);
                                                                }
                                                                else
                                                                {
                                                                    _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(_contractName) - _avgPrice)) * TWS.Cls.ClsGlobal.DDContractSize[_contractName], 2);
                                                                }
                                                                uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value = _pnl.ToString();
                                                            }
                                                            else if (_productType == "FOREX")
                                                            {
                                                                double _pnl = Math.Round(qty * (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(_contractName) - _avgPrice)) * TWS.Cls.ClsGlobal.DDContractSize[uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Contract"].ToString()] * TWS.Cls.ClsGlobal.DDConversion[uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Contract"].ToString()], 2);
                                                                uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value = _pnl;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(_contractName)) > 0)
                                                        {
                                                            if (_productType == "FUTURE")
                                                            {
                                                                double _pnl = 0.0;
                                                                if (_productName == "CPF")
                                                                {
                                                                    _pnl = Math.Round(qty * (_avgPrice - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(_contractName))) * TWS.Cls.ClsGlobal.DDContractSize[_contractName], 2);

                                                                }
                                                                else
                                                                {
                                                                    _pnl = Math.Round(qty * (_avgPrice - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(_contractName))) * TWS.Cls.ClsGlobal.DDContractSize[_contractName], 2);
                                                                }
                                                                uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value = _pnl;
                                                            }
                                                            else if (_productType == "FOREX")
                                                            {
                                                                double _pnl = Math.Round(qty * (_avgPrice - Convert.ToDouble(TWS.Cls.ClsGlobal.GetZeroLevelLTP(_contractName))) * TWS.Cls.ClsGlobal.DDContractSize[_contractName] * TWS.Cls.ClsGlobal.DDConversion[_contractName], 2);
                                                                uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value = _pnl;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value.ToString().Trim() != "0")
                                                        uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["PnL"].Value = 0;
                                                }
                                            }
                                        }
                                    }

                                }

                                finally
                                {
                                    System.Threading.Monitor.Exit(this.uctlTradeWindow1.ui_uctlGridTradeWindow);
                                }

                            }
                        }
                        catch (Exception)
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

        private void frmTradeWindowFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cls.ClsGlobal.IsTradeBookOpen = false;
        }
    }
}
