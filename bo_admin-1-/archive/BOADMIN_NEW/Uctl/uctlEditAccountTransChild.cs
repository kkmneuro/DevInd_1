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
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Accounts transaction child
    /// </summary>
    public partial class uctlEditAccountTransChild : UserControl
    {
        DateTime paymentDate;
        int id;
        public uctlEditAccountTransChild()
        {
            InitializeComponent();

            ui_ncmbPaymentType.Items.Clear();
            ui_ncmbPaymentType.Items.AddRange(Enum.GetNames(typeof(BOADMIN_NEW.Uctl.uctlEditAccountDetail.AmountType)));
        }

        private void ui_npnlTaxMaster_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// set values for controls
        /// </summary>
        /// <param name="row"></param>
        public void SetValues(DataGridViewRow row)
        {
            id = clsUtility.GetInt(row.Cells["ID"].Value.ToString());
            ui_ntxtAccountID.Text= row.Cells["AccountID"].Value.ToString();
            ui_ntxtAmount.Text = row.Cells["Amount"].Value.ToString();
            ui_ncmbPaymentType.SelectedIndex = ui_ncmbPaymentType.Items.IndexOf(row.Cells["PaymentType"].Value.ToString());
            ui_ntxtPaymentMode.Text = row.Cells["PaymentMode"].Value.ToString();
            ui_ntxtChequeFdNo.Text = row.Cells["ChequeNo"].Value.ToString();
            ui_ntxtRemark.Text = row.Cells["Remark"].Value.ToString();
            paymentDate =Convert.ToDateTime(row.Cells["PaymentDate"].Value.ToString());
        }

        /// <summary>
        /// handle ok button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            if (ui_ncmbPaymentType.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Please select payment type", "Accounts", true);
                return;
            }
            if (ui_ntxtPaymentMode.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Please specify payment mode", "Accounts", true);
                return;
            }

            clsAccount objclsAccount = new clsAccount();
            objclsAccount.EditAccountTransactionID = id;
            objclsAccount.AccountId = clsUtility.GetInt(ui_ntxtAccountID.Text);
            objclsAccount.PaymentAmount = clsUtility.GetDecimal(ui_ntxtAmount.Text);
            objclsAccount.PaymentType = ui_ncmbPaymentType.SelectedItem.ToString();
            objclsAccount.PaymentMode = clsUtility.GetStr(ui_ntxtPaymentMode.Text);
            objclsAccount.PaymentDate = paymentDate;
            objclsAccount.ChequeFdNo = clsUtility.GetStr(ui_ntxtChequeFdNo.Text);
            objclsAccount.Remark = clsUtility.GetStr(ui_ntxtRemark.Text);

            clsAccount objAccount= clsProxyClassManager.INSTANCE._objBOEngineClient.UpdateAccount(clsGlobal.userIDPwd, objclsAccount,
                AccountOpType.ACCOUNT_TRANSACTION);
            OnOkClick(objAccount);
            this.ParentForm.Close();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        public event Action<clsAccount> OnOkClick=delegate{};
    }
}
