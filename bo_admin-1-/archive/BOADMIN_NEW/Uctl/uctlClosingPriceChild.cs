using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.BOEngineServiceTCP;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
using System.Runtime.InteropServices;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlClosingPriceChild : UserControl
    {
        public DialogType _dialogType;
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);
        public uctlClosingPriceChild()
        {
            InitializeComponent();
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            if (ui_ncmbSymbolName.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Please select symbol", "Instrument Closing Price Error", true);
                return;
            }

            if (ui_ntxtClosingPrice.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Please provide closing price", "Instrument Closing Price Error", true);
                return;
            }
            HandleOperations();
        }

        private void HandleOperations()
        {
            clsInstrumentClosingPrice []lst=null;
            clsInstrumentClosingPrice objInstClosingPrice = new clsInstrumentClosingPrice();
            objInstClosingPrice.PK_InstrumentClosingPrice = clsUtility.GetLong(ui_ntxtSymbolClosingPrice.Text);
            objInstClosingPrice.FK_InstrumentID = clsUtility.GetInt(clsMasterInfoManager.INSTANCE.GetSymbolId(ui_ncmbSymbolName.SelectedItem.ToString()));
            objInstClosingPrice.ClosingPrice = clsUtility.GetDecimal(ui_ntxtClosingPrice.Text);
            objInstClosingPrice.ClosingDate = clsUtility.GetDate(ui_ndtpClosingDate.Value);
                        
            string opMsg=string.Empty;
            if (_dialogType == DialogType.New)
            {
                opMsg = "Edited Instrument Closing Price record of Symbol:" + ui_ncmbSymbolName.SelectedItem.ToString()+" Closing Price:"+
                    objInstClosingPrice.ClosingPrice+" Closing Date:"+objInstClosingPrice.ClosingDate;
                lst=clsProxyClassManager.INSTANCE._objBOEngineClient.HandleInstClosingPrice(clsGlobal.userIDPwd, objInstClosingPrice, OperationTypes.INSERT);
            }
            else if (_dialogType == DialogType.Edit)
            {
                opMsg = "Inserted Instrument Closing Price record of Symbol:" + ui_ncmbSymbolName.SelectedItem.ToString() + " Closing Price:" +
                    objInstClosingPrice.ClosingPrice + " Closing Date:" + objInstClosingPrice.ClosingDate;
                lst=clsProxyClassManager.INSTANCE._objBOEngineClient.HandleInstClosingPrice(clsGlobal.userIDPwd, objInstClosingPrice, OperationTypes.UPDATE);
            }

            if (lst[0].ServerResponseID != clsGlobal.FailureID)
            {
                {
                    clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                    objclsBrokerOpLog.OperationName = _dialogType.ToString();                   
                    objclsBrokerOpLog.Message = opMsg;
                    clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                }
                clsSymbolClosingPriceManager.INSTANCE.HandleInstClosingPrice(objInstClosingPrice);
            }            
            this.ParentForm.Close();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ui_ncmbSymbolName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uctlClosingPriceChild_Load(object sender, EventArgs e)
        {
            if (_dialogType == DialogType.New)
            {
                ui_ncmbSymbolName.Items.Clear();
                ui_ncmbSymbolName.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetUnexpiredSymbols());
            }
        }

        internal void SetValues(DS4InstrumentClosingPrice.dtInstrumentClosingPriceRow row)
        {
            ui_ncmbSymbolName.Items.Clear();
            ui_ncmbSymbolName.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetUnexpiredSymbols());
            ui_ncmbSymbolName.SelectedIndex=ui_ncmbSymbolName.Items.IndexOf(row.InstrumentID);
            ui_ntxtSymbolClosingPrice.Text=row.InstrumentClosingPrice.ToString();
            ui_ntxtClosingPrice.Text=row.ClosingPrice.ToString();
            ui_ndtpClosingDate.Value = row.ClosingDate;
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = ui_ndtpClosingDate.Width - 10;
            Int32 y = ui_ndtpClosingDate.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(ui_ndtpClosingDate.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(ui_ndtpClosingDate.Handle, WM_LBUTTONUP, 1, lParam);
        }

        private void ui_ntxtClosingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ui_ntxtClosingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ui_ntxtClosingPrice.Text.Contains('.'))
            {
                if (ui_ntxtClosingPrice.Text.Substring(ui_ntxtClosingPrice.Text.IndexOf('.') + 1).Length >= 5 && e.KeyChar != '\b')
                {
                    e.Handled = true;
                    return;
                }
            }
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
