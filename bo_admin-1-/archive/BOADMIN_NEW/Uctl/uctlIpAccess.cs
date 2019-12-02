using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsInterface4OME;
using ProtocolStructs;
using BOADMIN_NEW.Cls;
using System.Net;
using DSSocket.Classes;
using clsInterface4OME.DSBO;
using Nevron.UI.WinForm.Controls;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlIpAccess : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS
        #region UI_DATA
        public DS4IPAccesssList.dtIPAccessListRow _row = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        //Client objClient;
        #endregion UI_DATA
        #endregion MEMBERS
        public uctlIpAccess()
        {
            InitializeComponent();
            ui_cmbAction.SelectedIndex = 0;
        }

        private void nuiPanel1_Click(object sender, EventArgs e)
        {

        }

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            if (_row == null)
                return;
            ui_txtFrom.Text = _row.IPAddressFrom;
            ui_txtTo.Text = _row.IPAddressTo;
            ui_txtComment.Text = _row.Comment;
            ui_cmbAction.SelectedItem = _row.Action;

        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        protected void EditIpaccess()
        {
            clsIPAccessList objclsIPAccessList = new clsIPAccessList();
            objclsIPAccessList.Status = clsUtility.GetStr(ui_cmbAction.SelectedItem);
            objclsIPAccessList.FromIP = ui_txtFrom.Text.Trim();
            objclsIPAccessList.ToIp = ui_txtTo.Text.Trim();
            objclsIPAccessList.Comment = ui_txtComment.Text.Trim();
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlIpAccess : Enter EditIpaccess()");
                string opMsg;
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsIPAccessList.ID = _row.IPAccessID;
                    objclsIPAccessList = clsProxyClassManager.INSTANCE.UpdateIPAccessList(objclsIPAccessList);
                    opMsg = "Edited IP Access List record of ID:" + objclsIPAccessList.ID.ToString() + ".";// Action :" +
                        //objclsIPAccessList.Status + " From IP :" + objclsIPAccessList.FromIP + " To IP :" + objclsIPAccessList.ToIp;
                    objclsBrokerOpLog.OperationName = "Edited IP Access List";
                }
                else
                {
                    objclsIPAccessList.ID = ProtocolStructIDS.DBInsert;
                    objclsIPAccessList = clsProxyClassManager.INSTANCE.InsertIPAccessList(objclsIPAccessList);
                    opMsg = "Added IP Access record of ID : " + objclsIPAccessList.ID.ToString() + ", Action : " +
                        objclsIPAccessList.Status + ", From IP :" + objclsIPAccessList.FromIP + ", To IP : " + objclsIPAccessList.ToIp+".";
                    objclsBrokerOpLog.OperationName = "Added IP Access record";
                }
                if (objclsIPAccessList.ServerResponseMsg != clsGlobal.FailureID)
                {
                    {
                        //clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        //objclsBrokerOpLog.OperationName = _mode.ToString();
                        //objclsBrokerOpLog.ControlName = "IP Access List";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    clsIPAccessListManager.INSTANCE.DoHandleIPAccessListTable(objclsIPAccessList);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlIpAccess =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditIpaccess()");
            }
            _frmCommonContainer.Close();
        }

        private void ui_btnOk_Click(object sender, EventArgs e)
        {
            if (ui_txtFrom.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter From IP.", "IP Access Error", true);
                ui_txtFrom.Focus();
                return;
            }
            if (Cls.clsGlobal.ValidateIP(ui_txtFrom.Text) == false)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter a valid IP Address.", "IP Access Error", true);
                ui_txtFrom.Focus();
                return;
            }
            if (ui_txtTo.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter To IP.", "IP Access Error", true);
                ui_txtTo.Focus();
                return;
            }
            if (Cls.clsGlobal.ValidateIP(ui_txtTo.Text) == false)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter a valid IP Address.", "IP Access Error", true);
                ui_txtTo.Focus();
                return;
            }
            string[] ipFrom = ui_txtFrom.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ipTo = ui_txtTo.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 4; i++)
            {
                if (Convert.ToInt32(ipFrom[i]) > Convert.ToInt32(ipTo[i]))
                {
                    clsDialogBox.ShowErrorBox("Value of FromIP can not be greater than value of ToIp", "IP Access Error", true);
                    return;
                }
            }
            EditIpaccess();

        }

        private void uctlIpAccess_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();

        }

        private void ui_txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            //else
            //    clsGlobal.KeyPressHandler(ui_txtFrom.Text, e, clsEnums.TextType.IP, 20, 3);
        }

        private void ui_txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            //else
            //    clsGlobal.KeyPressHandler(ui_txtTo.Text, e, clsEnums.TextType.IP, 20, 3);
        }

        ////private bool ValidateIP(string IP)
        ////{

        ////    //IPAddress ip = System.Net.IPAddress.Parse(IP);
        ////    //if (ip == null)
        ////    //{
        ////    //    return false;
        ////    //}
        ////    //return true;

        ////    System.Net.IPAddress ipAddress = null;
        ////    bool isValidIp = System.Net.IPAddress.TryParse(IP, out ipAddress);
        ////    return isValidIp;
        ////}

    }
}
