using System;
using System.Linq;
using System.Windows.Forms;

using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Main control class of feemaster
    /// </summary>
    public partial class uctlFeesMaster : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS

        public DialogType currentyDialogType;
        int _feeMasterId;

        #region UI_DATA
        public DS4FeeMaster.dtFeeMasterRow _row = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        #endregion UI_DATA

        #endregion MEMBERS

        public uctlFeesMaster()
        {
            InitializeComponent();
        }
        #region IUserCtrl Members

        public void Init()
        {
            
        }
        /// <summary>
        /// initialize control
        /// </summary>
        public void InitControls()
        {
            if (_row == null)
                return;

            ui_ntxtDescription.Text = _row.Description;
            ui_ntxtMaximumVolume.Text = _row.MaximunFeeValue.ToString();
            ui_ntxtMinimumVolume.Text = _row.MinimumFeeValue.ToString();
            ui_ntxtChargesName.Text = _row.FeeName;
            int n = ui_ncmbInterval.Items.IndexOf(_row.Interval);
            ui_ncmbInterval.SelectedIndex = ui_ncmbInterval.Items.IndexOf(_row.Interval);
        }
        /// <summary>
        /// submission of fee information
        /// </summary>
        protected void EditFees()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlFeesMaster : Enter EditFees()");
                clsFeeMaster objclsclsFeeMaster = new clsFeeMaster();
                objclsclsFeeMaster.FeeName = clsUtility.GetStr(ui_ntxtChargesName.Text.Trim());
                objclsclsFeeMaster.Description = ui_ntxtDescription.Text.Trim();
                objclsclsFeeMaster.Interval = clsUtility.GetStr(ui_ncmbInterval.SelectedItem);
                objclsclsFeeMaster.IsTaxable = ui_nchkIsTaxable.Checked;
                objclsclsFeeMaster.MaximumFeevalue = clsUtility.GetDecimal(ui_ntxtMaximumVolume.Text.Trim());
                objclsclsFeeMaster.MinimumFeeValue = clsUtility.GetDecimal(ui_ntxtMinimumVolume.Text.Trim());
                objclsclsFeeMaster.FeesMode = clsUtility.GetStr(ui_ncmbFeesMode.SelectedItem.ToString());
                objclsclsFeeMaster.LevyOn = clsUtility.GetStr(ui_ncmbLevyOn.SelectedItem.ToString());
                if (ui_ncmbPerDay.SelectedItem == null || ui_ncmbInterval.SelectedItem.ToString() != "Day")
                {
                    objclsclsFeeMaster.Days = string.Empty;
                }
                else
                {
                    objclsclsFeeMaster.Days = clsUtility.GetStr(ui_ncmbPerDay.SelectedItem.ToString());
                }
                string opMsg;
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsclsFeeMaster.FeeId = _row.PK_FeeID;
                    objclsclsFeeMaster = clsProxyClassManager.INSTANCE.UpdateFeeMaster(objclsclsFeeMaster);
                    opMsg = "Edited Fee Master record of FeeName : " + objclsclsFeeMaster.FeeName + ".";// "and FeeID :" + objclsclsFeeMaster.FeeId +
                        //" Min Value :"+objclsclsFeeMaster.MinimumFeeValue+" Max Value :"+objclsclsFeeMaster.MaximumFeevalue+" Fee Mode :"+
                        //objclsclsFeeMaster.FeesMode;
                    objclsBrokerOpLog.OperationName = "Fee details updated";
                }
                else
                {
                    objclsclsFeeMaster = clsProxyClassManager.INSTANCE.InsertFeeMaster(objclsclsFeeMaster);
                    if(!clsBrokersManagerHandler.INSTANCE._lstFeeType.Contains(objclsclsFeeMaster.FeeName))
                    {
                        clsBrokersManagerHandler.INSTANCE._lstFeeType.Add(objclsclsFeeMaster.FeeName);
                    }
                    opMsg = "Added new fee, Fee Name : " + objclsclsFeeMaster.FeeName + ".";//and FeeID :" + objclsclsFeeMaster.FeeId +
                        //" Min Value :" + objclsclsFeeMaster.MinimumFeeValue + " Max Value :" + objclsclsFeeMaster.MaximumFeevalue + " Fee Mode :" +
                        //objclsclsFeeMaster.FeesMode;
                    objclsBrokerOpLog.OperationName = "Fee details Added";
                }
                if (objclsclsFeeMaster.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        //clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        //objclsBrokerOpLog.OperationName = _mode.ToString();
                        //objclsBrokerOpLog.ControlName = "Fee Master";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    clsFeeMasterManager.INSTANCE.DoHandleFeeMasterTable(objclsclsFeeMaster);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlFeesMaster =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditFees()");
            }
        }
        public void SaveMe()
        {
            
        }
        #endregion IUserCtrl Members

        private void uctlFeesMaster_Load(object sender, EventArgs e)
        {
            if (this._mode == clsEnums.FRM_MODE.ADD)
            {
                ui_ncmbInterval.SelectedIndex = 0;
            }
            //InitControls();
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            UpdateHandler();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        /// <summary>
        /// Sets values of the control child components
        /// </summary>
        /// <param name="ds4FeeMaster"></param>
        /// <param name="feeMasterRow"></param>
        /// <param name="dialogType"></param>
        public void SetValues(DS4FeeMaster ds4FeeMaster, DS4FeeMaster.dtFeeMasterRow feeMasterRow, DialogType dialogType)
        {
            currentyDialogType = dialogType;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlFeesMaster : Enter EditFees()");
                if (dialogType == DialogType.Edit)
                {
                    _feeMasterId = feeMasterRow.PK_FeeID;
                    ui_ntxtChargesName.Text = feeMasterRow.FeeName;
                    ui_ntxtMinimumVolume.Text = feeMasterRow.MinimumFeeValue.ToString();
                    ui_ntxtMaximumVolume.Text = feeMasterRow.MaximunFeeValue.ToString();
                    ui_ntxtDescription.Text = feeMasterRow.Description;
                    ui_ncmbInterval.SelectedIndex = ui_ncmbInterval.Items.IndexOf(feeMasterRow.Interval);
                    ui_nchkIsTaxable.Checked = feeMasterRow.IsTaxable;
                    ui_ncmbFeesMode.SelectedIndex = ui_ncmbFeesMode.Items.IndexOf(feeMasterRow.FeesMode);
                    ui_ncmbLevyOn.SelectedIndex = ui_ncmbLevyOn.Items.IndexOf(feeMasterRow.LevyOn);
                    ui_ncmbPerDay.SelectedIndex = ui_ncmbPerDay.Items.IndexOf(feeMasterRow.Days);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlFeesMaster =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditFees()");
            }

        }
        /// <summary>
        /// Authenticates info for submission
        /// </summary>
        private void UpdateHandler()
        {
            if (ui_ntxtChargesName.Text.Trim() == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Fee name.", "Fee Error", true);
                ui_ntxtChargesName.Text = string.Empty;
                ui_ntxtChargesName.Focus();
                return;
            }
            if (ui_ntxtMinimumVolume.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Minimum Fee value.", "Fee Error", true);
                ui_ntxtMinimumVolume.Focus();
                return;
            }
            if (ui_ntxtMaximumVolume.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Maximum Fee value.", "Fee Error", true);
                ui_ntxtMaximumVolume.Focus();
                return;
            }
            if (ui_ncmbFeesMode.SelectedItem == null)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Fees Mode.", "Fee Error", true);
                ui_ncmbInterval.Focus();
                return;
            }
            if (ui_ncmbLevyOn.SelectedItem ==null)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Levy On.", "Fee Error", true);
                ui_ncmbInterval.Focus();
                return;
            }
            if (ui_ncmbInterval.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Fee interval.", "Fee Error", true);
                ui_ncmbInterval.Focus();
                return;
            }
            if (clsUtility.GetDecimal(ui_ntxtMinimumVolume.Text) > clsUtility.GetDecimal(ui_ntxtMaximumVolume.Text))
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Minimum Fee value should not be greater than Maximum Fee value.", "Fee Error", true);
                ui_ntxtMinimumVolume.Focus();
                return;
            }
            EditFees();
            _frmCommonContainer.Close();
        }

        private void ui_ntxtMinimumVolume_Leave(object sender, EventArgs e)
        {
            //Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMaximumVolume_Leave(object sender, EventArgs e)
        {
            //Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMinimumVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                if (!char.IsControl(e.KeyChar))
                {
                    TextBox tt = (TextBox)sender;
                    if (tt.Text.IndexOf('.') > -1 && tt.Text.Substring(tt.Text.IndexOf('.')).Length >= 6)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
                e.Handled = true;
            ////if (ui_ntxtMinimumVolume.Text.Contains('.'))
            ////{
            ////    if (ui_ntxtMinimumVolume.Text.Substring(ui_ntxtMinimumVolume.Text.IndexOf('.')+1).Length >= 5 && e.KeyChar != '\b')
            ////    {
            ////        e.Handled = true;
            ////        return;
            ////    }
            ////}
            ////if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            ////{
            ////    e.Handled = false;
            ////}
            ////else
            ////{
            ////    e.Handled = true;
            ////}
        }

        private void ui_ntxtMaximumVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                if (!char.IsControl(e.KeyChar))
                {
                    TextBox tt = (TextBox)sender;
                    if (tt.Text.IndexOf('.') > -1 && tt.Text.Substring(tt.Text.IndexOf('.')).Length >= 6)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
                e.Handled = true;

            ////if (ui_ntxtMaximumVolume.Text.Contains('.'))
            ////{
            ////    if (ui_ntxtMaximumVolume.Text.Substring(ui_ntxtMaximumVolume.Text.IndexOf('.') + 1).Length >= 5 && e.KeyChar != '\b')
            ////    {
            ////        e.Handled = true;
            ////        return;
            ////    }
            ////}
            ////if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            ////{
            ////    e.Handled = false;
            ////}
            ////else
            ////{
            ////    e.Handled = true;
            ////}
        }

        private void ui_ncmbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbInterval.SelectedItem != null && ui_ncmbInterval.SelectedItem.ToString() == "Day")
            {
                ui_ncmbPerDay.Enabled = true;
            }
            else
            {
                ui_ncmbPerDay.SelectedItem = null;
                ui_ncmbPerDay.Enabled = false;
            }
        }

    }
}
