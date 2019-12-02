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

using BOADMIN_NEW.BOEngineServiceTCP;
using System.Runtime.InteropServices;

namespace BOADMIN_NEW.Uctl
{

    public partial class uctlHolidays : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS
        #region UI_DATA
        public DialogType currentyDialogType;
        int holidayId;
        public DS4Holidays.dtHolidayRow _row = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        #endregion UI_DATA
        // Client objClient;

        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);
        #endregion MEMBERS

        public uctlHolidays()
        {
            InitializeComponent();
            ui_chkEnable.Checked = true;
        }

        private void EnableOrDisable()
        {
            if (ui_chkEnable.Checked == false)
            {
                ui_cmbSymbol.Enabled = false;
                ui_ndtpDate.Enabled = false;
                ui_txtTimeFrom.Enabled = false;
                ui_txtTo.Enabled = false;
                ui_txtDescription.Enabled = false;
                ui_chkEveryYear.Enabled = false;

            }
            else
            {
                ui_cmbSymbol.Enabled = true;
                ui_ndtpDate.Enabled = true;
                ui_txtTimeFrom.Enabled = true;
                ui_txtTo.Enabled = true;
                ui_txtDescription.Enabled = true;
                ui_chkEveryYear.Enabled = true;
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            EnableOrDisable();
        }

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            try
            {
                ui_cmbSymbol.Items.AddRange(clsMasterInfoManager.INSTANCE.GetSymbolList());
                if (_row == null)
                    return;
                ui_cmbSymbol.SelectedIndex = ui_cmbSymbol.Items.IndexOf(_row.Symbol.ToString());
                ui_ndtpDate.Text = _row.Date.ToString();
                ui_txtDescription.Text = _row.Description;
                ui_txtTimeFrom.Text = _row.WorkTimeFrom;
                ui_txtTo.Text = _row.WorkTimeTo;
                ui_cmbSymbol.SelectedItem = _row.Symbol;
                ui_chkEveryYear.Checked = _row.IsEveryYear;
                ui_chkEnable.Checked = _row.IsEnable;
                EnableOrDisable();
            }
            catch (Exception)
            {
            }
            // ui_cmbSymbol.Text = Symbol_; 

        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion


        private void uctlHolidays_Load(object sender, EventArgs e)
        {
            InitControls();
        }



        void EditHoliday()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlHolidays : Enter EditHoliday()");
                clsHoliday objclsHoliday = new clsHoliday();

                objclsHoliday.Day = Convert.ToDateTime(ui_ndtpDate.Value);
                objclsHoliday.Description = ui_txtDescription.Text.Trim();
                objclsHoliday.FromTime = ui_txtTimeFrom.Text;
                objclsHoliday.IsEveryYear = ui_chkEveryYear.Checked;
                objclsHoliday.IsEnable = ui_chkEnable.Checked;
                objclsHoliday.Symbol = clsUtility.GetStr(ui_cmbSymbol.SelectedItem);
                objclsHoliday.ToTime = ui_txtTo.Text;
                string opMsg;
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsHoliday.Id = _row.HolidayID;
                    objclsHoliday = clsProxyClassManager.INSTANCE.UpdateHoliday(objclsHoliday);
                    opMsg = "Edited Holiday details of Symbol : " + objclsHoliday.Symbol + ".";//and HolidayID" + objclsHoliday.Id+" Day :"+objclsHoliday.Day
                        //+" Symbol :"+objclsHoliday.Symbol+" From Time :"+objclsHoliday.FromTime+" To Time :"+objclsHoliday.ToTime;
                    objclsBrokerOpLog.OperationName = "Edited Holiday record";
                }
                else
                {
                    objclsHoliday.Id = ProtocolStructIDS.DBInsert;
                    objclsHoliday = clsProxyClassManager.INSTANCE.InsertHoliday(objclsHoliday);
                    opMsg = "Added Holiday for Symbol : " + objclsHoliday.Symbol + ".";//and HolidayID" + objclsHoliday.Id + " Day :" + objclsHoliday.Day
                        //+ " Symbol :" + objclsHoliday.Symbol + " From Time :" + objclsHoliday.FromTime + " To Time :" + objclsHoliday.ToTime;
                    objclsBrokerOpLog.OperationName = "Added Holiday record";
                }
                try
                {
                    if (objclsHoliday.ServerResponseID != clsGlobal.FailureID)
                    {
                        {
                            //clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                            //objclsBrokerOpLog.OperationName = _mode.ToString();
                            //objclsBrokerOpLog.ControlName = "Holiday";
                            objclsBrokerOpLog.Message = opMsg;
                            clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                        }
                        clsHolidayManager.INSTANCE.DoHandleHolidayTable(objclsHoliday);
                    }
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlHolidays =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditHoliday()");
            }
            EnableOrDisable();
        }

        private void ui_btnOk_Click(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_txtTimeFrom.Text) >= clsUtility.GetDate(ui_txtTo.Text))
            {
                DialogResult result = clsDialogBox.ShowErrorBox("\"Work time from\" should be less than \"Work time to\"", "Holiday Error", true);
                ui_txtTimeFrom.Focus();
                return;
            }

            if (ui_cmbSymbol.SelectedItem == null)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select symbol !!", "Holiday Error", true);
                ui_cmbSymbol.Focus();
                return;
            }

            EditHoliday();
            _frmCommonContainer.Close();
        }

        private void ui_chkEveryYear_CheckedChanged(object sender, EventArgs e)
        {

            if (ui_chkEveryYear.Checked == true)
            {
                ui_ndtpDate.Format = DateTimePickerFormat.Custom;
                ui_ndtpDate.CustomFormat = "MM/dd";
            }
            else
            {
                ui_ndtpDate.Format = DateTimePickerFormat.Custom;
                ui_ndtpDate.CustomFormat = "MM/dd/yyyy";
            }

        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        
        public void SetValues(DS4Holidays ds4Holidays, DS4Holidays.dtHolidayRow HolidayRow, DialogType dialogType)
        {
            currentyDialogType = dialogType;

            if (dialogType == DialogType.Edit)
            {
                try
                {
                    holidayId = HolidayRow.HolidayID;
                    ui_chkEnable.Checked = HolidayRow.IsEnable;
                    ui_chkEveryYear.Checked = HolidayRow.IsEveryYear;
                    ui_ndtpDate.Text = HolidayRow.Date.ToString();
                    ui_txtTimeFrom.Text = HolidayRow.WorkTimeFrom;
                    ui_txtTo.Text = HolidayRow.WorkTimeTo;
                    ui_cmbSymbol.Text = HolidayRow.Symbol;
                    ui_txtDescription.Text = HolidayRow.Description;
                }
                catch (Exception)
                {

                }
            }

        }

        private void ui_btnDate_Click(object sender, EventArgs e)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = this.ui_ndtpDate.Width - 10;
            Int32 y = this.ui_ndtpDate.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(ui_ndtpDate.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(ui_ndtpDate.Handle, WM_LBUTTONUP, 1, lParam);
        }
    }
}



