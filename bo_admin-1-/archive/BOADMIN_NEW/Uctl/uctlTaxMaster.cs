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

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTaxMaster : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS
        public DialogType currentyDialogType;
        int taxMasterId;
        #region UI_DATA
        public DS4TaxMaster.dtTaxMasterRow _row = null;
        public Cls.clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        #endregion UI_DATA

        #endregion MEMBERS

        public uctlTaxMaster()
        {
            InitializeComponent();
        }

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
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

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            UpdateHandler();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        protected void EditTax()
        {
            clsTaxMaster objclsTaxMaster = new clsTaxMaster();
            objclsTaxMaster.TaxName = ui_ntxtTaxName.Text.Trim();
            objclsTaxMaster.TaxPercent = clsUtility.GetDecimal(ui_ntxtTaxPercent.Text.Trim());
            objclsTaxMaster.Description = ui_ntxtDescription.Text.Trim();
            objclsTaxMaster.Amount = ui_ncmbAmount.Text.Trim();
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTaxMaster : Enter EditTax()");
                string opMsg;
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsTaxMaster.TaxID = _row.PK_TaxID;
                    objclsTaxMaster = clsProxyClassManager.INSTANCE.UpdateTaxMaster(objclsTaxMaster);
                    opMsg = "Tax name '" + objclsTaxMaster.TaxName + "' details are updated.";// +objclsTaxMaster.TaxID
                        //+" Tax Percent :"+objclsTaxMaster.TaxPercent+" Amount :"+objclsTaxMaster.Amount;
                    objclsBrokerOpLog.OperationName = "Edited tax details";
                }
                else
                {
                    objclsTaxMaster.TaxID = ProtocolStructIDS.DBInsert;
                    objclsTaxMaster = clsProxyClassManager.INSTANCE.InsertTaxMaster(objclsTaxMaster);
                    if (!clsBrokersManagerHandler.INSTANCE._lstTaxType.Contains(objclsTaxMaster.TaxName))
                    {
                        clsBrokersManagerHandler.INSTANCE._lstTaxType.Add(objclsTaxMaster.TaxName);
                    }
                    opMsg = "Added new Tax, Tax Name : " + objclsTaxMaster.TaxName + ", Tax Percent : " + objclsTaxMaster.TaxPercent + ", Amount : " + objclsTaxMaster.Amount+".";
                    objclsBrokerOpLog.OperationName = "Added new tax";
                }
                if (objclsTaxMaster.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        //clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        //objclsBrokerOpLog.OperationName = _mode.ToString();
                        //objclsBrokerOpLog.ControlName = "Tax Master";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    clsTaxMasterManager.INSTANCE.DoHandleTaxMasterTable(objclsTaxMaster);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTaxMaster =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditTax()");
            }
        }

        public void SetValues(DS4TaxMaster ds4TaxMaster, DS4TaxMaster.dtTaxMasterRow TaxMasterRow, DialogType dialogType)
        {
            currentyDialogType = dialogType;

            if (dialogType == DialogType.Edit)
            {
                taxMasterId = TaxMasterRow.PK_TaxID;
                ui_ntxtTaxName.Text = TaxMasterRow.TaxName;
                ui_ntxtTaxPercent.Text = TaxMasterRow.TaxPercent.ToString();
                ui_ntxtDescription.Text = TaxMasterRow.Description;
                ui_ncmbAmount.SelectedIndex = ui_ncmbAmount.Items.IndexOf(TaxMasterRow.Amount);

            }


        }
        private void UpdateHandler()
        {
            if (ui_ntxtTaxName.Text.Trim() == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter tax name.", "Tax Error", true);
                ui_ntxtTaxName.Text = string.Empty;
                ui_ntxtTaxName.Focus();
                return;
            }
            if (ui_ntxtTaxPercent.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter tax percent.", "Tax Error", true);
                ui_ntxtTaxPercent.Focus();
                return;
            }
            if (ui_ncmbAmount.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select the ammount.", "Tax Error", true);
                ui_ncmbAmount.Focus();
                return;
            }
            EditTax();
            _frmCommonContainer.Close();
        }

        private void ui_ntxtTaxPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            ////{
            ////    e.Handled = false;
            ////}
            ////else
            ////{
            ////    e.Handled = true;
            ////}          
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                if (!char.IsControl(e.KeyChar))
                {
                    TextBox tt = (TextBox)sender;
                    if (tt.Text.IndexOf('.') > -1 && tt.Text.Substring(tt.Text.IndexOf('.')).Length >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
                e.Handled = true;
            //clsGlobal.KeyPressHandler(ui_ntxtTaxPercent.Text, e, clsEnums.TextType.Real, 5, 2);
        }

        private void ui_ntxtTaxPercent_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtTaxPercent.Text.Contains('.'))
            {
                string[] RealNumber = ui_ntxtTaxPercent.Text.Split('.');
                if (clsUtility.GetInt(RealNumber[0]) < 10)
                {
                    if (clsUtility.GetInt(RealNumber[0]) == 0)
                    {
                        RealNumber[0] = "00";
                        ui_ntxtTaxPercent.Text = RealNumber[0] + "." + RealNumber[1];
                    }
                    else
                    {
                        RealNumber[0] = "0" + RealNumber[0];
                        ui_ntxtTaxPercent.Text = RealNumber[0] + "." + RealNumber[1];
                    }
                }
                if (RealNumber[1] == string.Empty)
                {
                    ui_ntxtTaxPercent.Text = RealNumber[0] + ".00";
                }
            }
            else if (Convert.ToInt32(ui_ntxtTaxPercent.Text.Trim()) < 10)
            {
                Cls.clsGlobal.HandleZero(sender, e, 1);
                ui_ntxtTaxPercent.Text = ui_ntxtTaxPercent.Text + ".00";
            }
            else
                ui_ntxtTaxPercent.Text = ui_ntxtTaxPercent.Text + ".00";
            //else
            //    Cls.clsGlobal.HandleZero(sender, e, 0);
        }
    }
}
