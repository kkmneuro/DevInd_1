using System;
using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Forms
{
    /// <summary>
    /// Account transaction history
    /// </summary>
    public partial class frmAccountTransReport : FrmBase
    {        
        public frmAccountTransReport()
        {
            InitializeComponent();            

            AccountTransSearchValues objSearchValues = new AccountTransSearchValues();
            objSearchValues.FromDate = ui_ndtpFromDate.Value;
            objSearchValues.ToDate = ui_ndtpToDate.Value;
            if (clsGlobal.BrokerID != 1)
            {
                objSearchValues.BrokerID = clsGlobal.BrokerNameId;
                objSearchValues.BrokerParentID = 0;
            }
            GetReportData(objSearchValues);
        }

        /// <summary>
        /// Search records
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            AccountTransSearchValues objSearchValues = new AccountTransSearchValues();
            objSearchValues.FromDate = ui_ndtpFromDate.Value;
            objSearchValues.ToDate = ui_ndtpToDate.Value;
            objSearchValues.AccountID = clsUtility.GetInt(ui_ntxtAccountNumber.Text);
            if (clsGlobal.BrokerID == 1)
            {
                objSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objSearchValues.BrokerParentID = 0;
            }
            else
            {
                if (ui_ntxtBrokerID.Text.Trim() == string.Empty)
                {
                    objSearchValues.BrokerID = clsGlobal.BrokerNameId;
                    objSearchValues.BrokerParentID = 0;
                }
                else
                {
                    objSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objSearchValues.BrokerParentID = clsGlobal.BrokerNameId;
                }
            }
            GetReportData(objSearchValues);            
        }

        private void frmAccountTransReport_Load(object sender, EventArgs e)
        {            
            this.Icon = Properties.Resources.favicon;
        }
        public void GetReportData(AccountTransSearchValues searchValues)
        {
            DS.DS4AccountTrans objDS4DS4AccountTrans = new DS.DS4AccountTrans();

            foreach (clsAccountTrans item in clsProxyClassManager.INSTANCE._objReportClient.GetAccountTransReportData(clsGlobal.userIDPwd, searchValues))
            {
                objDS4DS4AccountTrans.dtAccountTrans.AdddtAccountTransRow(item.AccountID, item.Amount, item.PaymentType.Trim(), item.PaymentMode.Trim(),
                    item.PaymentDate.ToString("MM/dd/yyyy HH:mm:ss"), item.ChequeNo.Trim(), item.Remark);
            }
            objAccountTransReport.SetDataSource(objDS4DS4AccountTrans);
        }
    }
}
