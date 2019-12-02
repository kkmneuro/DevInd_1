using System.Data;
using System.Windows.Forms;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using System;
using System.Collections.Generic;
using System.Net;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class uctlTradeMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region UI_DATA
        int _id;

        #endregion UI_DATA

        #region MEMBERS

        string[] SearchParms = new string[2];
        string[] SearchOTParms = new string[2];
        DateTime[] SearchTimeParms = new DateTime[2];
        #endregion MEMBERS

        /// <summary>
        /// Trade mani contructor
        /// </summary>
        public uctlTradeMain()
        {
            InitializeComponent();

            DataGridViewButtonColumn ModifyCol = new DataGridViewButtonColumn();
            DataGridViewButtonColumn SettleCol = new DataGridViewButtonColumn();
            ModifyCol.Name = "SettingModifyCol";
            ModifyCol.DefaultCellStyle.NullValue = "Modify";
            ModifyCol.Text = "Modify";
            ModifyCol.HeaderText = "Modify Order";
            ui_ndtgTrades.Columns.Add(ModifyCol);
            ui_ndtgTrades.Columns["SettingModifyCol"].Width = 80;

            SettleCol.Name = "SettingSettleCol";
            SettleCol.DefaultCellStyle.NullValue = "Settle";
            SettleCol.Text = "Settle";
            SettleCol.HeaderText = "Settle Order";
            ui_ndtgTrades.Columns.Add(SettleCol);
            ui_ndtgTrades.Columns["SettingSettleCol"].Width = 80;

            // clsTradeManager.INSTANCE._DS4Trade.dtTrade.TableNewRow += new DataTableNewRowEventHandler(dtTrade_TableNewRow);        
        }

        //void dtTrade_TableNewRow(object sender, DataTableNewRowEventArgs e)
        //{
        //    RefreshMe();
        //    ui_ndtgTrades.Rows[ui_ndtgTrades.Rows.Count].Selected = true;
        //  //  ui_ndtgTrades.Rows[ui_ndtgTrades.Rows.Count - 1].Selected = true;
        //}

        /// <summary>
        /// Refresh the grid
        /// </summary>
        void RefreshMe()
        {
            Action A = () =>
            {

                ui_ndtgTrades.ScrollBars = ScrollBars.None;
                ui_ndtgTrades.Refresh();

                if (ui_ndtgTrades.Rows.Count > 0)
                {
                    ui_ndtgTrades.FirstDisplayedScrollingRowIndex = ui_ndtgTrades.Rows.Count - 1;
                }

                ui_ndtgTrades.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndtgTrades.InvokeRequired)
            {
                ui_ndtgTrades.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        void dtOrders_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
            ui_ndtgTrades.Rows[ui_ndtgTrades.Rows.Count - 1].Selected = true;
        }

        #region IUserCtrl Members

        public void Init()
        {
            ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade;
            var columnS = ui_ndtgTrades.Columns["SettledQty"];
            if (columnS != null) columnS.Visible = false;
        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {

        }

        #endregion

        /// <summary>
        /// Contains operation to be performed when the control is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTradeMain_Load(object sender, EventArgs e)
        {

            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbAccountID.Items.Insert(0, "All");
            ui_ncmbOrderNo.Items.Insert(0, "All");
            ui_ncmbTradeNo.Items.Insert(0, "All");

            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbAccountID.SelectedIndex = 0;
            ui_ncmbOrderNo.SelectedIndex = 0;
            ui_ncmbTradeNo.SelectedIndex = 0;
            ui_ncmbOrderStatus.SelectedIndex = 0;
            ui_ncmbAccountID.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetAccountIDArray());
         
            foreach (var item in Cls.clsTradeManager.INSTANCE.GetBrokerNameArray())
            {
                try
                {
                    ui_ncmbBrokerName.Items.Add(item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            //ui_ncmbBrokerName.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetBrokerNameArray());
            ui_ncmbOrderNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetOrderNoArray());
            ui_ncmbTradeNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetTradeNoArray());

            Init();

            ui_ndtgTrades.Columns["AccountID"].HeaderText = "Account ID";
            ui_ndtgTrades.Columns["AccountID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["OrderID"].HeaderText = "Order ID";
            ui_ndtgTrades.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["OrderPrice"].HeaderText = "Order Price";
            ui_ndtgTrades.Columns["OrderPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["TriggerPrice"].HeaderText = "Trigger Price";
            ui_ndtgTrades.Columns["TriggerPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["BrokerName"].HeaderText = "Broker Name";
            ui_ndtgTrades.Columns["FilledQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["FilledQuantity"].HeaderText = "Filled Quantity";
            ui_ndtgTrades.Columns["LeaveQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["LeaveQuantity"].HeaderText = "Leave Quantity";
            ui_ndtgTrades.Columns["AvgFillPRice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgTrades.Columns["AvgFillPRice"].HeaderText = "Avg Fill Price";

            ui_ncmbAccountID.SelectedIndexChanged += (ui_ncmbAccountID_SelectedIndexChanged);
            ui_ncmbOrderNo.SelectedIndexChanged += (ui_ncmbOrderNo_SelectedIndexChanged);
            ui_ncmbTradeNo.SelectedIndexChanged += (ui_ncmbTradeNo_SelectedIndexChanged);
            ui_ncmbOrderStatus.SelectedIndexChanged += new EventHandler(ui_ncmbOrderStatus_SelectedIndexChanged);

        }

        /// <summary>
        /// Hides the filter bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnHideFilter_Click(object sender, EventArgs e)
        {
            if (ui_npnlFilter.Visible)
            {
                ui_nbtnHideFilter.Text = "Show &Filter >>";
                ui_ndtgTrades.Height = ui_ndtgTrades.Height + ui_npnlFilter.Height + 6;
                ui_npnlFilter.Visible = false;
                MytoolTip.SetToolTip(ui_nbtnHideFilter, "Show Filter");
            }
            else
            {
                ui_nbtnHideFilter.Text = "Hide &Filter <<";
                ui_npnlFilter.Visible = true;
                ui_ndtgTrades.Height = ui_ndtgTrades.Height - ui_npnlFilter.Height - 6;
                MytoolTip.SetToolTip(ui_nbtnHideFilter, "Hide Filter");
            }
        }

        private void ui_ndtgTrades_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ui_ncmbBrokerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerName.Text == "All")
            {
                ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade;
            }
            else
            {
                SearchParms[0] = ui_ncmbBrokerName.Text;
                SearchParms[1] = ui_ncmbAccountID.Text;

                HandleSearch(SearchParms);
            }
        }

        private void ui_ndtgTrades_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        /// Handle searching of information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            SearchTimeParms[0] = Convert.ToDateTime(ui_ndtpStartTime.Text).Date;
            SearchTimeParms[1] = Convert.ToDateTime(ui_ndtpEndDate.Text).Date;
            if (SearchTimeParms[0] > DateTime.Now)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Search start date can't be greater than current date, Please provide a valid input.", "Invalid Input", true);
                ui_ndtpStartTime.Focus();
                return;
            }

            if (SearchTimeParms[1] > DateTime.Now)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Search End date can't be greater than current date, Please provide a valid input.", "Invalid Input", true);
                ui_ndtpEndDate.Focus();
                return;
            }
            if (SearchTimeParms[0] > SearchTimeParms[1])
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Search start date Should not be greater than Search End date, Please provide a valid input.", "Invalid Input", true);
                ui_ndtpStartTime.Focus();
                return;
            }
            TimeSpan t = Convert.ToDateTime("01/31/2013 23:59:59 PM") - Convert.ToDateTime("01/01/2013 00:00:00 AM");//to get time span equals to 1 month
            if ((Convert.ToDateTime(ui_ndtpEndDate.Value.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")) - ui_ndtpStartTime.Value.Date) > t)
            {
                clsDialogBox.ShowErrorBox("Date range can not exceed 30 days.", "Error", true);
                ui_ndtpStartTime.Value = DateTime.Now;
                ui_ndtpStartTime.Focus();
                return;
            }
            clsTradeManager.INSTANCE.FillTradeDataSet(Convert.ToDateTime(SearchTimeParms[0]), Convert.ToDateTime(SearchTimeParms[1].ToString().Replace("12:00:00 AM", "23:59:59 PM")));
            //  ui_ndtgTrades.DataSource = null;
            ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade;
            defaultUISettings();
        }

        /// <summary>
        /// Handle search operation
        /// </summary>
        /// <param name="parameters"></param>
        public void HandleSearch(string[] parameters)
        {
            string query = string.Empty;

            if (parameters[0] != "All")
                query = "BrokerName = '" + parameters[0] + "'";

            if (parameters[0] == "All" && parameters[1] != "All")
                query = "AccountID = " + clsUtility.GetInt(parameters[1]);

            if (parameters[0] != "All" && parameters[1] != "All")
                query = query + "AND AccountID = " + clsUtility.GetInt(parameters[1]);

            if (query.Length > 0)
                query.Remove(0, 4);
            ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade.Select(query);
            GridStyle();
        }

        /// <summary>
        /// Handle the searching of information
        /// </summary>
        /// <param name="parameters"></param>
        public void HandleOTSearch(string[] parameters)
        {
            string query = string.Empty;
            if (parameters[0] == "Trade")
            {
                if (parameters[1] != "All")
                    query = query + "TradeNo = " + clsUtility.GetInt(parameters[1]);
            }
            if (parameters[0] == "Order")
            {
                if (parameters[1] != "All")
                    query = query + "OrderID = " + clsUtility.GetInt(parameters[1]);
            }
            if (parameters[0] == "Status")
            {
                if (parameters[1] != "All")
                {
                    if (parameters[1].Trim() == "Settled")
                    {
                        query = query + "LeaveQuantity = " + 0;
                    }
                    if (parameters[1].Trim() == "Open")
                    {
                        query = query + "LeaveQuantity > " + 0;
                    }

                }
            }
            if (query.Length > 0)
                query.Remove(0, 4);
            ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade.Select(query);
            GridStyle();
        }

        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {
            clsTradeManager.INSTANCE.FillTradeDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
            defaultUISettings();
        }

        /// <summary>
        /// Sets default value of the controls
        /// </summary>
        private void defaultUISettings()
        {
            ui_ncmbBrokerName.Items.Clear();
            ui_ncmbAccountID.Items.Clear();
            ui_ncmbOrderNo.Items.Clear();
            ui_ncmbTradeNo.Items.Clear();

            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbAccountID.Items.Insert(0, "All");
            ui_ncmbOrderNo.Items.Insert(0, "All");
            ui_ncmbTradeNo.Items.Insert(0, "All");

            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbAccountID.SelectedIndex = 0;
            ui_ncmbOrderNo.SelectedIndex = 0;
            ui_ncmbTradeNo.SelectedIndex = 0;
            ui_ncmbOrderStatus.SelectedIndex = 0;

            ui_ncmbAccountID.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetAccountIDArray());
            ui_ncmbBrokerName.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetBrokerNameArray());
            ui_ncmbOrderNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetOrderNoArray());
            ui_ncmbTradeNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetTradeNoArray());

            ui_ndtgTrades.DataSource = null;
            ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade;

        }
        private void ui_ndtgTrades_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ui_ndtgTrades.Refresh();
        }

        private void ui_nbtnNewTrade_Click(object sender, EventArgs e)
        {
            uctlTradeNew tradeNew = new uctlTradeNew(ui_ndtpStartTime.Value);
            tradeNew._ContainerCaption = "New Trade";
            tradeNew.ShowDialog();

        }

        /// <summary>
        /// Handles cell click event of the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndtgTrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _id = Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["OrderID"].Value);

                if (ui_ndtgTrades.Columns[e.ColumnIndex].Name == "SettingSettleCol")
                {
                    if (Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["SettledQty"].Value) < Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["FilledQuantity"].Value))
                    {

                        try
                        {
                            DialogResult result = clsDialogBox.ShowMessageBox("DISCLAIMER : The trade should be modified after getting approval of "+
                            "Exchange Executive Committee via e-mail. The Trade should not be modified when Exchange is in session. Any issue arising out of manual modification lies with Compliance Team.", "WARNING");
                            if (result == DialogResult.Yes)
                            {
                                uctlTradeSettle tradeSettle = new uctlTradeSettle();
                                tradeSettle.AccountID = Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["AccountID"].Value);
                                tradeSettle.SettledOrderID = _id;
                                tradeSettle.MaxSettleQty = Convert.ToInt64(ui_ndtgTrades.Rows[e.RowIndex].Cells["FilledQuantity"].Value) - Convert.ToInt64(ui_ndtgTrades.Rows[e.RowIndex].Cells["SettledQty"].Value);
                                tradeSettle.OrderType = '1';
                                tradeSettle.OrderStatusID = '3';
                                if (ui_ndtgTrades.Rows[e.RowIndex].Cells["Type"].Value.ToString().Trim() == "BUY")
                                {
                                    tradeSettle.Side = '2';
                                }
                                else
                                    tradeSettle.Side = '1';
                                tradeSettle.Symbol = ui_ndtgTrades.Rows[e.RowIndex].Cells["Symbol"].Value.ToString().Trim();
                                tradeSettle.Tif = '1';
                                tradeSettle.IPAddress = GetLocalIP();
                                tradeSettle.UsedMargin = 0;
                                tradeSettle.CloseQty = Convert.ToInt32(tradeSettle.MaxSettleQty);
                                tradeSettle._ContainerCaption = "Settle Order ID: " + _id.ToString();
                                tradeSettle.Price = Convert.ToDouble(ui_ndtgTrades.Rows[e.RowIndex].Cells["OrderPrice"].Value.ToString().Trim());
                                tradeSettle.PositionSize = Convert.ToInt64(ui_ndtgTrades.Rows[e.RowIndex].Cells["Quantity"].Value);
                                tradeSettle.ShowDialog();
                                if (tradeSettle.DbTransact)
                                {
                                    ui_ncmbTradeNo.Items.Clear();
                                    ui_ncmbOrderNo.Items.Clear();

                                    ui_ncmbOrderNo.Items.Insert(0, "All");
                                    ui_ncmbTradeNo.Items.Insert(0, "All");

                                    ui_ncmbOrderNo.SelectedIndex = 0;
                                    ui_ncmbTradeNo.SelectedIndex = 0;
                                    ui_ncmbOrderNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetOrderNoArray());
                                    ui_ncmbTradeNo.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetTradeNoArray());
                                    GridStyle();
                                }
                            }                            
                        }
                        catch (Exception)
                        {
                            //Logging.FileHandling.WriteAllLog("Exception :FrmMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in FrmMain_FormClosing()");
                        }
                        
                    }
                    else
                    {
                        DialogResult result = clsDialogBox.ShowErrorBox("All positions are already settled for OrderID :" + _id, "Server Responce", true);
                        return;
                    }
                }
                else if (ui_ndtgTrades.Columns[e.ColumnIndex].Name == "SettingModifyCol")
                {
                    uctlTradeModify tradeSettle = new uctlTradeModify(Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["AccountID"].Value), _id, e.RowIndex);
                    tradeSettle._ContainerCaption = "Modify Order ID: " + _id.ToString();
                    tradeSettle.ui_ntxtPrice.Text = ui_ndtgTrades.Rows[e.RowIndex].Cells["OrderPrice"].Value.ToString();
                    tradeSettle.Price = Convert.ToDecimal(ui_ndtgTrades.Rows[e.RowIndex].Cells["OrderPrice"].Value);
                    tradeSettle.ShowDialog();
                    if (tradeSettle.DbTransact)
                        GridStyle();
                }

            }
        }

        private void ui_ncmbOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOTParms[0] = "Order";
            SearchOTParms[1] = ui_ncmbOrderNo.Text;
            HandleOTSearch(SearchOTParms);

            SearchParms[0] = string.Empty;
        }

        private void ui_ncmbTradeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOTParms[0] = "Trade";
            SearchOTParms[1] = ui_ncmbTradeNo.Text;
            HandleOTSearch(SearchOTParms);

            SearchParms[0] = string.Empty;
        }

        private void ui_ndtgTrades_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //DataGridViewDisableButtonCell buttonCell =
                //        (DataGridViewDisableButtonCell)ui_ndtgTrades.
                //        Rows[e.RowIndex].Cells["SettledQty"];
                if (Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["SettledQty"].Value) < Convert.ToInt32(ui_ndtgTrades.Rows[e.RowIndex].Cells["FilledQuantity"].Value))
                {
                    ui_ndtgTrades.Rows[e.RowIndex].Cells["SettledQty"].ReadOnly = false;
                    //buttonCell.Enabled = true;
                    //ui_ndtgTrades.Invalidate();
                }
                else
                {
                    ui_ndtgTrades.Rows[e.RowIndex].Cells["SettledQty"].ReadOnly = true;
                    //buttonCell.Enabled = false;
                    //ui_ndtgTrades.Invalidate();
                }
            }
        }

        private string GetLocalIP()
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress item in addr)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    strHostName = item.ToString();
                }
            }
            return strHostName;
        }

        private void GridStyle()
        {
            var dataGridViewColumn = ui_ndtgTrades.Columns["RowError"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
            var gridViewColumn = ui_ndtgTrades.Columns["Table"];
            if (gridViewColumn != null) gridViewColumn.Visible = false;
            var viewColumn = ui_ndtgTrades.Columns["HasErrors"];
            if (viewColumn != null) viewColumn.Visible = false;
            var column = ui_ndtgTrades.Columns["RowState"];
            if (column != null) column.Visible = false;
            var columnS = ui_ndtgTrades.Columns["SettledQty"];
            if (columnS != null) columnS.Visible = false;
        }

        private void ui_ncmbAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchParms[0] = ui_ncmbBrokerName.Text;
            SearchParms[1] = ui_ncmbAccountID.Text;

            if (ui_ncmbBrokerName.Text == "All" && ui_ncmbAccountID.Text == "All")
            {
                ui_ndtgTrades.DataSource = clsTradeManager.INSTANCE._DS4Trade.dtTrade;
                GridStyle();
                return;
            }
            else
                HandleSearch(SearchParms);
            //if (ui_ncmbBrokerName.Text != "All" && ui_ncmbAccountID.Text != null)
            //{
            //    HandleSearch(SearchParms);
            //}
            //if (ui_ncmbBrokerName.Text == "All" && ui_ncmbAccountID.Text != null)
            //{
            //    HandleSearch(SearchParms);
            //}
        }

        private void ui_ncmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOTParms[0] = "Status";
            SearchOTParms[1] = ui_ncmbOrderStatus.Text;
            HandleOTSearch(SearchOTParms);

            SearchParms[0] = string.Empty;
        }

        private void ui_contextmnuCommonNewAccount_Click(object sender, EventArgs e)
        {
            uctlTradeNew tradeNew = new uctlTradeNew(ui_ndtpStartTime.Value);
            tradeNew._ContainerCaption = "New Trade";
            tradeNew.ShowDialog();
        }
    }
}
