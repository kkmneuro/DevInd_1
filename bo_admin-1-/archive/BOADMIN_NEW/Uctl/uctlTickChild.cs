using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.BOEngineServiceTCP;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Tick control
    /// </summary>
    public partial class uctlTickChild : UserControl
    {
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);

        int _recordID;
        string _symbol=string.Empty;
        string _periodicity = string.Empty;

        public string Periodicity
        {
            set
            {
                _periodicity = value;
            }
        }
        public uctlTickChild()
        {
            InitializeComponent();
        }

        private void nButton7_Click(object sender, EventArgs e)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = ui_ndtpDate.Width - 10;
            Int32 y = ui_ndtpDate.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(ui_ndtpDate.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(ui_ndtpDate.Handle, WM_LBUTTONUP, 1, lParam);
        }

        /// <summary>
        /// Ok click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            clsHistoricalData objclsHistoricalData = new clsHistoricalData();
            objclsHistoricalData.ID = _recordID;
            objclsHistoricalData.SymbolName = _symbol;
            objclsHistoricalData.FeedTime = clsUtility.GetDate( ui_ndtpDate.Value);
            objclsHistoricalData.Open = clsUtility.GetDouble(ui_ntxtOpen.Text);
            objclsHistoricalData.High = clsUtility.GetDouble(ui_ntxtHigh.Text);
            objclsHistoricalData.Low = clsUtility.GetDouble(ui_ntxtLow.Text);
            objclsHistoricalData.Close = clsUtility.GetDouble(ui_ntxtClose.Text);
            objclsHistoricalData.Volume = clsUtility.GetLong(ui_ntxtVolume.Text);

            clsProxyClassManager.INSTANCE._objBOEngineClient.GetHistoricalDataCompleted += _objLoginClient_GetHistoricalDataCompleted;
            clsProxyClassManager.INSTANCE._objBOEngineClient.GetHistoricalDataAsync(clsGlobal.userIDPwd, null, _periodicity, 0, objclsHistoricalData, 
                OperationTypes.UPDATE);
            this.ParentForm.Close();
        }

        void _objLoginClient_GetHistoricalDataCompleted(object sender, GetHistoricalDataCompletedEventArgs e)
        {
            if (e.Result.ToList()[0].ServerResponseID != clsGlobal.FailureID)
            {
                OnHDataUpdate(e.Result.ToList()[0]);
            }
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// sets the values of the control
        /// </summary>
        /// <param name="row"></param>
        public void SetValues(DataGridViewRow row)
        {
            _recordID = clsUtility.GetInt(row.Cells["ID"].Value);
            _symbol = clsUtility.GetStr(row.Cells["SymbolName"].Value);
            ui_ndtpDate.Value = clsUtility.GetDate(row.Cells["Date"].Value);
            ui_ntxtOpen.Text = row.Cells["Open"].Value.ToString();
            ui_ntxtHigh.Text = row.Cells["High"].Value.ToString();
            ui_ntxtLow.Text = row.Cells["Low"].Value.ToString();
            ui_ntxtClose.Text = row.Cells["Close"].Value.ToString();
            ui_ntxtVolume.Text = row.Cells["Volume"].Value.ToString();
        }

        public event Action<clsHistoricalData> OnHDataUpdate = delegate { };
    }
}
