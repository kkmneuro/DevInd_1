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
    public partial class uctlOrderMain : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS    

        string[] SearchParms = new string[2];
        DateTime[] SearchTimeParms = new DateTime[2];
        //int iCurrRowIndex_ = -1;
        //int iCurrColIndex_ = -1;

        #endregion MEMBERS

        public uctlOrderMain()
        {
            InitializeComponent();          
        }        
              

        #region IUserCtrl Members

        public void Init()
        {
            ui_ndtgOrders.DataSource = clsOrdersManager.INSTANCE._DS4Orders.dtOrders;
            ui_ndtgOrders.AutoGenerateColumns = true;
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
        

        private void uctlOrderMain_Load(object sender, EventArgs e)
        {
            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbaccountID.Items.Insert(0, "All");
            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbaccountID.SelectedIndex = 0;

            ui_ncmbaccountID.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetAccountIDArray());
            ui_ncmbBrokerName.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetBrokerNameArray());
            SearchParms[0] = ui_ncmbBrokerName.Text;
            SearchParms[1] = ui_ncmbaccountID.Text;


            Init();
            int id = (int)clsEnums.CommandIDS.ORDERS;
            string x = clsGlobal.Role.Split('_')[id];
            if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            {
                //ui_contextmnuCommon.Items[0].Visible = false;
            }
            else
            {
                //ui_contextmnuCommon.Items[0].Visible = true;
            }
            if (Convert.ToInt32(x.ToCharArray()[3].ToString()) == 0)
            {
                //ui_contextmnuCommon.Items[1].Visible = false;
            }
            else
            {
                //ui_contextmnuCommon.Items[1].Visible = true;
            }
            ui_ndtgOrders.Columns["AccountID"].HeaderText = "Account ID";
            ui_ndtgOrders.Columns["AccountID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["OrderID"].HeaderText = "Order ID";
            ui_ndtgOrders.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["OrderPrice"].HeaderText = "Order Price";
            ui_ndtgOrders.Columns["OrderPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["TriggerPrice"].HeaderText = "Trigger Price";
            ui_ndtgOrders.Columns["TriggerPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["BrokerName"].HeaderText = "Broker Name";
            ui_ndtgOrders.Columns["FilledQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["FilledQuantity"].HeaderText = "Filled Quantity";
            ui_ndtgOrders.Columns["LeaveQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["LeaveQuantity"].HeaderText = "Leave Quantity";
            ui_ndtgOrders.Columns["AvgFillPRice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOrders.Columns["AvgFillPRice"].HeaderText = "Avg Fill Price";
        }

        private void ui_ndtgOrders_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void ui_ndtgOrders_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ui_ncmbBrokerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerName.Text == "All")
            {
                ui_ndtgOrders.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders;
                ui_ncmbaccountID.SelectedIndex = 0;
                return;
            }
            else
            {
                SearchParms[0] = ui_ncmbBrokerName.Text;
                HandleSearch(SearchParms);
            }

        }

        private void ui_ncmbaccountID_SelectedIndexChanged(object sender, EventArgs e)
        {

            SearchParms[0] = ui_ncmbBrokerName.Text;
            SearchParms[1] = ui_ncmbaccountID.Text;

            if (ui_ncmbBrokerName.Text == "All" && ui_ncmbaccountID.Text == "All")
            {
                ui_ndtgOrders.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders;
                return;
            }
            if (ui_ncmbBrokerName.Text != "All" && ui_ncmbaccountID.Text != null)
            {
                HandleSearch(SearchParms);
            }
            if (ui_ncmbBrokerName.Text == "All" && ui_ncmbaccountID.Text != null)
            {
                HandleSearch(SearchParms);
            }

        }


        public void HandleSearch(string[] parameters)
        {
            string Query = string.Empty;
            if (parameters[0] != "All")
                Query = "BrokerName = '" + parameters[0] + "' ";
            if (parameters[0] == "All" && parameters[1] != "All")
                Query = "AccountID = " + clsUtility.GetInt(parameters[1]);
            if (parameters[0] != "All" && parameters[1] != "All")
                Query = Query + "AND AccountID = " + clsUtility.GetInt(parameters[1]);

            if (Query.Length > 0)
                Query.Remove(0, 4);
            ui_ndtgOrders.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders.Select(Query);

        }

        private void ui_nbrnSearch_Click(object sender, EventArgs e)
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
            clsOrdersManager.INSTANCE.FillOrderDataSet(Convert.ToDateTime(SearchTimeParms[0]), Convert.ToDateTime(SearchTimeParms[1].ToString().Replace("12:00:00 AM", "23:59:59 PM")));
            ui_ndtgOrders.DataSource = clsOrdersManager.INSTANCE._DS4Orders.dtOrders;
            defaultUISettings();
            //SearchTimeParms[0] = Convert.ToDateTime(ui_ndtpStartTime.Text);
            //SearchTimeParms[1] = Convert.ToDateTime(ui_ndtpEndDate.Text);
            //HandleTimeSearch(SearchParms, SearchTimeParms);
        }
        public void HandleTimeSearch(string[] parameters, DateTime[] timeParameters)
        {
            string Query = string.Empty;

            if (ui_ndtpStartTime.Text != "yyyy-MM-dd HH:mm" && ui_ndtpEndDate.Text != "yyyy-MM-dd HH:mm")
            {
                if (parameters[0] == "All" && parameters[1] == "All")
                    Query = "Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "'";
                if (parameters[0] != "All")
                    Query = "BrokerName = '" + parameters[0] + "' AND Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "'";
                if (parameters[0] != "All" && parameters[1] != "All")
                    Query = Query + "AND AccountID = " + clsUtility.GetInt(parameters[1]);
                if (parameters[0] == "All" && parameters[1] != "All")
                    Query = "AccountID = " + clsUtility.GetInt(parameters[1]) + " AND Time >= '" + SearchTimeParms[0] + "' AND Time <= '" + SearchTimeParms[1] + "'";

            }
            if (Query.Length > 0)
                Query.Remove(0, 4);

            ui_ndtgOrders.DataSource = Cls.clsOrdersManager.INSTANCE._DS4Orders.dtOrders.Select(Query);

        }

        private void ui_ndtgOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {
            clsOrdersManager.INSTANCE.FillOrderDataSet(DateTime.Now.Date, Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")));
            defaultUISettings();
            //clsOrdersManager.INSTANCE.RefreshOrderData(DateTime.Now, DateTime.Now);
        }

        private void ui_ndtgOrders_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void defaultUISettings()
        {
            ui_ncmbBrokerName.Items.Clear();
            ui_ncmbaccountID.Items.Clear();
      

            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbaccountID.Items.Insert(0, "All");
       

            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbaccountID.SelectedIndex = 0;

            ui_ncmbaccountID.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetAccountIDArray());
            ui_ncmbBrokerName.Items.AddRange(Cls.clsTradeManager.INSTANCE.GetBrokerNameArray());         
        }
    }
}
