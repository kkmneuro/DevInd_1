using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using ProtocolStructs.NewPS;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTradesMain : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        int iCurrRowIndex_ = -1;
        //int iCurrColIndex_ = -1;
      
        string[] SearchParms = new string[2];
        DateTime[] SearchTimeParms = new DateTime[2];
        #endregion MEMBERS

        public uctlTradesMain()
        {
            InitializeComponent();
           // clsOrdersManager.INSTANCE._DS4Trades.dtOrders.TableNewRow += new DataTableNewRowEventHandler(dtOrders_TableNewRow);
            //clsOrdersManager.INSTANCE._DS4Orders.dtOrders.RowChanged += new DataRowChangeEventHandler(dtOrders_RowChanged);
        }

        //void dtOrders_RowChanged(object sender, DataRowChangeEventArgs e)
        //{
        //    RefreshMe();

        //}


        void RefreshMe()
        {
            Action A = () =>
            {
                //ui_ndtgTrades.DataSource = clsOrdersManager.INSTANCE.GetTradesData();
                ui_ndtgTrades.ScrollBars = ScrollBars.None;
                ui_ndtgTrades.Refresh();

                if (ui_ndtgTrades.Rows.Count > 0)
                {
                    //ui_ndtgOrders.Rows[ui_ndtgOrders.Rows.Count - 1].Selected = true;
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
            //ui_ndtgTrades.DataSource = clsOrdersManager.INSTANCE.GetTradesData();
           // ui_ndtgTrades.DataSource = clsOrdersManager.INSTANCE._DS4Trades.dtOrders;
            DataGridViewButtonColumn SattleCol = new DataGridViewButtonColumn();
            DataGridViewButtonColumn ModifyCol = new DataGridViewButtonColumn();
            SattleCol.Name = "SettingSattleCol";
            SattleCol.DefaultCellStyle.NullValue = "Sattle";
            SattleCol.Text = "Sattle";
            SattleCol.HeaderText = "Sattle Order";
            ui_ndtgTrades.Columns.Add(SattleCol);
            ui_ndtgTrades.Columns["SettingSattleCol"].Width = 80;

            ModifyCol.Name = "SettingModifyCol";
            ModifyCol.DefaultCellStyle.NullValue = "Modify";
            ModifyCol.Text = "Modify";
            ModifyCol.HeaderText = "Modify Order";
            ui_ndtgTrades.Columns.Add(ModifyCol);
            ui_ndtgTrades.Columns["SettingModifyCol"].Width = 80;

        }

        public void InitControls()
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion



        private void EditOrder(DialogType dialogMode)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTradesMain : Enter EditOrder()");
                bool isRowClick = true;
                if (iCurrRowIndex_ < 0)
                    isRowClick = false;
                uctlTrades Trade = new uctlTrades();
                Trade._mode = clsEnums.FRM_MODE.EDIT;
                if (isRowClick)
                {
                    string strOrderIDColumn = (clsOrdersManager.INSTANCE._DS4Orders.dtOrders).OrderIDColumn.Caption;
                    if (ui_ndtgTrades.Rows[iCurrRowIndex_].Cells[strOrderIDColumn].Value == null)
                    {
                        return;
                    }

                    int ID = Convert.ToInt32(ui_ndtgTrades.Rows[iCurrRowIndex_].Cells[strOrderIDColumn].Value);
                    Trade.SetValues(Cls.clsOrdersManager.INSTANCE._DS4Orders, Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders.FindByOrderID(ID), dialogMode);
                    Trade._row = clsOrdersManager.INSTANCE._DS4Orders.dtOrders.FindByOrderID(ID);

                }
                Trade._ContainerCaption = "Order Details";
                Trade.ShowDialog();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTradesMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditOrder()");
            }
        }



        private void uctlTradesMain_Load(object sender, EventArgs e)
        {
            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbAccountID.Items.Insert(0, "All");
            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbAccountID.SelectedIndex = 0;

            //ui_ncmbAccountID.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetTradeAccountIDArray());
            //ui_ncmbBrokerName.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetTradeBrokerNameArray());
            SearchParms[0] = ui_ncmbBrokerName.Text;
            SearchParms[1] = ui_ncmbAccountID.Text;
            Init();
            //int id = (int)clsEnums.CommandIDS.TRADES;
            //string x = clsGlobal.Role.Split('_')[id];
            //if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            //{
            //    ui_contextmnuCommon.Items[0].Visible = false;
            //}
            //else
            //{
            //    ui_contextmnuCommon.Items[0].Visible = true;
            //}
            //if (Convert.ToInt32(x.ToCharArray()[3].ToString()) == 0)
            //{
            //    ui_contextmnuCommon.Items[1].Visible = false;
            //}
            //else
            //{
            //    ui_contextmnuCommon.Items[1].Visible = true;
            //}
            //ui_ndtgTrades.Columns["RowError"].Visible = false;
            //ui_ndtgTrades.Columns["Table"].Visible = false;
            //ui_ndtgTrades.Columns["HasErrors"].Visible = false;
            //ui_ndtgTrades.Columns["RowState"].Visible = false;
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

        }
        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ui_contextmnuCommon_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ui_ndtgTrades_MouseDown(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    DataGridView.HitTestInfo hitinfo = ui_ndtgTrades.HitTest(e.X, e.Y);
            //    iCurrRowIndex_ = hitinfo.RowIndex;
            //    iCurrColIndex_ = hitinfo.ColumnIndex;

            //    if (e.Button == MouseButtons.Left && iCurrRowIndex_ >= 0)
            //    {
            //        if (e.Clicks == 2 && e.Button == MouseButtons.Left)//Double Click
            //        {

            //            EditOrder(DialogType.Edit);

            //        }
            //    }
            //    if (e.Button == MouseButtons.Right && iCurrRowIndex_ < 0)
            //    {
            //        ui_contextmnuCommon.Items[0].Enabled = false;
            //        ui_contextmnuCommon.Items[1].Enabled = false;
            //    }
            //    else
            //    {
            //        ui_contextmnuCommon.Items[0].Enabled = true;
            //        ui_contextmnuCommon.Items[1].Enabled = true;
            //    }
            //}
            //catch (Exception e1)
            //{

            //    throw;
            //}

        }

        private void ui_ncmbBrokerName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (ui_ncmbBrokerName.Text == "All")
            //{
            //    ui_ndtgTrades.DataSource = Cls.clsOrdersManager.INSTANCE.GetTradesData();
            //    ui_ncmbAccountID.SelectedIndex = 0;
            //    return;
            //}
            //else
            //{
            //    SearchParms[0] = ui_ncmbBrokerName.Text;
            //    HandleSearch(SearchParms);
            //}

        }


        private void ui_ndtgTrades_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ui_ncmbaccountID_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            SearchParms[0] = ui_ncmbBrokerName.Text;
            SearchParms[1] = ui_ncmbAccountID.Text;

            if (ui_ncmbBrokerName.Text == "All" && ui_ncmbAccountID.Text == "All")
            {
               // ui_ndtgTrades.DataSource = Cls.clsOrdersManager.INSTANCE.GetTradesData();
                return;
            }
            if (ui_ncmbBrokerName.Text != "All" && ui_ncmbAccountID.Text != null)
            {
                HandleSearch(SearchParms);
            }
            if (ui_ncmbBrokerName.Text == "All" && ui_ncmbAccountID.Text != null)
            {
                HandleSearch(SearchParms);
            }


        }



        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            SearchTimeParms[0] = Convert.ToDateTime(ui_ndtpStartTime.Text);
            SearchTimeParms[1] = Convert.ToDateTime(ui_ndtpEndDate.Text);
            HandleTimeSearch(SearchParms, SearchTimeParms);
        }

        public void HandleSearch(string[] parameters)
        {
            string Query = string.Empty;
            if (parameters[0] != "All")
                Query = "BrokerName = '" + parameters[0] + "' AND (Status = '2' OR Status = '1')";//'FILLED'";
            if (parameters[0] == "All" && parameters[1] != "All")
                Query = "AccountID = " + clsUtility.GetInt(parameters[1]) + " AND (Status = '2' OR Status = '1')";//'FILLED'";
            if (parameters[0] != "All" && parameters[1] != "All")
                Query = Query + "AND AccountID = " + clsUtility.GetInt(parameters[1]);

            if (Query.Length > 0)
                Query.Remove(0, 4);
            ui_ndtgTrades.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders.Select(Query);

        }
        public void HandleTimeSearch(string[] parameters, DateTime[] timeParameters)
        {
            string Query = string.Empty;

            if (ui_ndtpStartTime.Text != "yyyy-MM-dd HH:mm" && ui_ndtpEndDate.Text != "yyyy-MM-dd HH:mm")
            {
                if (parameters[0] == "All" && parameters[1] == "All")
                    Query = "Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "' AND (Status = '2' OR Status = '1')";//'FILLED'";
                if (parameters[0] != "All")
                    Query = "BrokerName = '" + parameters[0] + "' AND Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "' AND (Status = '2' OR Status = '1')";//'FILLED'";
                if (parameters[0] != "All" && parameters[1] != "All")
                    Query = Query + "AND AccountID = " + clsUtility.GetInt(parameters[1]);
                if (parameters[0] == "All" && parameters[1] != "All")
                    Query = "AccountID = " + clsUtility.GetInt(parameters[1]) + " AND Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "' AND (Status = '2' OR Status = '1')";//'FILLED'";

            }
            if (Query.Length > 0)
                Query.Remove(0, 4);

            ui_ndtgTrades.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders.Select(Query);

        }

        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {
            //clsOrdersManager.INSTANCE.RefreshOrderData();
            clsTradeManager.INSTANCE.FillTradeDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
        }

        private void ui_ndtgTrades_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ui_ndtgTrades.Refresh();
        }

    }
}
