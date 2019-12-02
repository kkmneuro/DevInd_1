using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.BOEngineServiceTCP;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlOperationsLog : UserControl
    {
        public uctlOperationsLog()
        {
            InitializeComponent(); 
            
            //clsOperationsLogManager.INSTANCE._DS4OperationsLog.dtOperationsLog.RowChanged += new DataRowChangeEventHandler(dtOperationsLog_RowChanged);
            //clsOperationsLogManager.INSTANCE._DS4OperationsLog.dtOperationsLog.TableNewRow += new DataTableNewRowEventHandler(dtOperationsLog_TableNewRow);
        }

        void dtOperationsLog_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }

        void dtOperationsLog_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void RefreshMe()
        {
            Action a = () =>
            {
                ////ui_dtgFeesMaster.DataSource = clsFeeMasterManager.INSTANCE._DS4FeeMaster.dtFeeMaster;
                ui_ndtgOperationLog.ScrollBars = ScrollBars.None;
                ui_ndtgOperationLog.Refresh();

                if (ui_ndtgOperationLog.Rows.Count > 0)
                {
                    ui_ndtgOperationLog.FirstDisplayedScrollingRowIndex = ui_ndtgOperationLog.Rows.Count - 1;
                }

                ui_ndtgOperationLog.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndtgOperationLog.InvokeRequired)
            {
                ui_ndtgOperationLog.BeginInvoke(a);

            }
            else
            {
                a();
            }
        }

        private void uctlOperationsLog_Load(object sender, EventArgs e)
        {
            ui_ndtgOperationLog.DataSource = clsOperationsLogManager.INSTANCE._DS4OperationsLog.dtOperationsLog;
            ui_ncmbBrokerID.Items.AddRange(clsAccountManager.INSTANCE.GetBrokerIDs());
            if (ui_ncmbBrokerID.Items.Contains("2"))
            {
                ui_ncmbBrokerID.Items.Remove("2");
            }
            ui_ncmbBrokerID.Items.Insert(0, "All");
            ui_ncmbBrokerID.SelectedIndex = 0;
            GridStyle();
            if (ui_ndtgOperationLog.RowCount > 1)
            {
                ui_ndtpFromDate.Text = ui_ndtgOperationLog.Rows[ui_ndtgOperationLog.RowCount - 1].Cells["DateTime"].Value.ToString();
                ui_ndtpToDate.Text = ui_ndtgOperationLog.Rows[0].Cells["DateTime"].Value.ToString();
            }
        }
        private void GridStyle()
        {
            ui_ndtgOperationLog.Columns["SNo"].Visible = false;
            ui_ndtgOperationLog.Columns["BrokerName"].HeaderText = "Broker Name";
            ui_ndtgOperationLog.Columns["BrokerName"].Width = 90;
            ui_ndtgOperationLog.Columns["BrokerID"].HeaderText = "Broker ID";
            ui_ndtgOperationLog.Columns["BrokerID"].Width = 70;
            ui_ndtgOperationLog.Columns["BrokerID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ui_ndtgOperationLog.Columns["OperationName"].HeaderText = "Operation";
            ui_ndtgOperationLog.Columns["OperationName"].Width = 80;
            ui_ndtgOperationLog.Columns["DateTime"].HeaderText = "Date Time";
            ui_ndtgOperationLog.Columns["DateTime"].Width = 100;
            ui_ndtgOperationLog.Columns["DateTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ui_ndtgOperationLog.Columns["IPAddress"].HeaderText = "IP Address";
            ui_ndtgOperationLog.Columns["IPAddress"].Width = 110;
            ui_ndtgOperationLog.Columns["Message"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
           
        }
        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {
            clsBrokerOperationsLog BrokerOperationsLog = new clsBrokerOperationsLog();
            BrokerOperationsLog.BrokerID = clsGlobal.BrokerNameId;
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted -= new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted += new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogAsync(clsGlobal.userIDPwd, BrokerOperationsLog, ui_ndtpFromDate.Value.Date, Convert.ToDateTime(ui_ndtpToDate.Value.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")), OperationTypes.GET);
        }

        void _objLoginClient_HandleBrokerOperationsLogCompleted(object sender, HandleBrokerOperationsLogCompletedEventArgs e)
        {
            clsOperationsLogManager.INSTANCE.FillDataToDataSet(e.Result.ToList());            
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            if (ui_ndtpToDate.Value > Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")))
            {
                clsDialogBox.ShowErrorBox("\"To Date\" can't be greater than current date.", "Error", true);
                ui_ndtpToDate.Value = DateTime.Now;
                ui_ndtpToDate.Focus();
                return;
            }
            if (ui_ndtpFromDate.Value > Convert.ToDateTime(DateTime.Now.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")))
            {
                clsDialogBox.ShowErrorBox("\"From Date\" can't be greater than current date.", "Error", true);
                ui_ndtpFromDate.Value = DateTime.Now;
                ui_ndtpFromDate.Focus();
                return;
            }
            if (ui_ndtpFromDate.Value > ui_ndtpFromDate.Value)
            {
                clsDialogBox.ShowErrorBox("\"From Date\" can't be greater than \"To Date\".", "Error", true);
                ui_ndtpFromDate.Value = DateTime.Now;
                ui_ndtpFromDate.Focus();
                return;
            }
            TimeSpan t = Convert.ToDateTime("01/31/2013 23:59:59 PM") - Convert.ToDateTime("01/01/2013 00:00:00 AM");//to get time span equals to 1 month
            if ((Convert.ToDateTime(ui_ndtpToDate.Value.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")) - ui_ndtpFromDate.Value.Date) > t)
            {
                clsDialogBox.ShowErrorBox("Date range can not exceed 30 days.", "Error", true);
                ui_ndtpFromDate.Value = DateTime.Now;
                ui_ndtpFromDate.Focus();
                return;
            }           
            clsBrokerOperationsLog BrokerOperationsLog = new clsBrokerOperationsLog();
            if (ui_ncmbBrokerID.Text.Trim()!="" && ui_ncmbBrokerID.Text.Trim().ToUpper()!="ALL")
            {
                BrokerOperationsLog.BrokerID = Convert.ToInt32(ui_ncmbBrokerID.Text.Trim());
            }
            else
            BrokerOperationsLog.BrokerID = clsGlobal.BrokerNameId;            
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted -= new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogCompleted += new EventHandler<HandleBrokerOperationsLogCompletedEventArgs>(_objLoginClient_HandleBrokerOperationsLogCompleted);
            clsOperationsLogManager.INSTANCE._DS4OperationsLog.dtOperationsLog.Clear();
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleBrokerOperationsLogAsync(clsGlobal.userIDPwd, BrokerOperationsLog, ui_ndtpFromDate.Value.Date, Convert.ToDateTime(ui_ndtpToDate.Value.Date.ToString().Replace("12:00:00 AM", "23:59:59 PM")), OperationTypes.GET);

           
        }

        public void FormatGrid()
        {
            ui_ndtgOperationLog.Columns["BrokerName"].HeaderText = "Broker Name";
            ui_ndtgOperationLog.Columns["BrokerID"].HeaderText = "Broker ID";
            ui_ndtgOperationLog.Columns["BrokerID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOperationLog.Columns["BrokerType"].HeaderText = "Broker Type";
            ui_ndtgOperationLog.Columns["ControlName"].HeaderText = "Control Name";
            ui_ndtgOperationLog.Columns["OperationName"].HeaderText = "Operation Name";
            ui_ndtgOperationLog.Columns["DateTime"].HeaderText = "Date Time";
            ui_ndtgOperationLog.Columns["BrokerParent"].HeaderText = "Broker Parent ID";
            ui_ndtgOperationLog.Columns["BrokerParent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndtgOperationLog.Columns["IPAddress"].HeaderText = "IP Address";
            //ui_ndtgOperationLog.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ui_ndtgOperationLog.Columns["SNo"].Visible = false;
            ui_ndtgOperationLog.ShowRowErrors = false;
            ui_ndtgOperationLog.ShowCellErrors = false;
        }

        public void searchDate()
        {
            if (ui_ndtgOperationLog.RowCount > 1)
            {
                ui_ndtpFromDate.Text = ui_ndtgOperationLog.Rows[0].Cells["DateTime"].Value.ToString();
                ui_ndtpToDate.Text = ui_ndtgOperationLog.Rows[ui_ndtgOperationLog.RowCount - 1].Cells["DateTime"].Value.ToString();
            }
        }
               
    }
}
