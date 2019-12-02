using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlPreferencesMarketWatch : UctlBase
    {
        public uctlPreferencesMarketWatch()
        {
            InitializeComponent();
            if (ui_nChkEnableTradingOnMarketWatch.Checked == true)
            {
                ui_nGrpClickMode.Enabled = true;
                ui_nGrpExecutionMode.Enabled = true;
            }
            else
            {
                ui_nGrpClickMode.Enabled = false;
                ui_nGrpExecutionMode.Enabled = false;
            }
        }

        private void ui_nChkEnableTradingOnMarketWatch_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_nChkEnableTradingOnMarketWatch.Checked == true)
            {
                ui_nGrpClickMode.Enabled = true;
                ui_nGrpExecutionMode.Enabled = true;
            }
            else
            {
                ui_nGrpClickMode.Enabled = false;
                ui_nGrpExecutionMode.Enabled = false;
            }

        }
        public void SetValues(ClsMarketWatchPreferanceSettings objMarketWatchSetting)
        {
           ui_nUDDefaultQuantity.Value= objMarketWatchSetting.MarketWatchTradingDefaultQuantity;
           ui_nChkEnableTradingOnMarketWatch.Checked = objMarketWatchSetting.EnableTradingOnMarketWatch;
           ui_nrdbDirectMarket.Checked = objMarketWatchSetting.DirectMarketExecution;
           ui_nrdbShowOrderEntry.Checked = !objMarketWatchSetting.DirectMarketExecution;
           ui_nrdbSingleClick.Checked = objMarketWatchSetting.SingleClickOrderSubmit;
           ui_nrdbDoubleClick.Checked = !objMarketWatchSetting.SingleClickOrderSubmit;

        }

        public ClsMarketWatchPreferanceSettings GetValues()
        {
            var objMarketWatchSetting = new ClsMarketWatchPreferanceSettings();

            objMarketWatchSetting.MarketWatchTradingDefaultQuantity=Convert.ToInt32(ui_nUDDefaultQuantity.Value) ;
            objMarketWatchSetting.EnableTradingOnMarketWatch=ui_nChkEnableTradingOnMarketWatch.Checked ;
            objMarketWatchSetting.DirectMarketExecution = ui_nrdbDirectMarket.Checked;
            objMarketWatchSetting.SingleClickOrderSubmit = ui_nrdbSingleClick.Checked;
            return objMarketWatchSetting;
        }
        private void ui_nbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            RestorDefault();
        }
        public void RestorDefault()
        {
            ui_nChkEnableTradingOnMarketWatch.Checked = false;
        }



    }
}
