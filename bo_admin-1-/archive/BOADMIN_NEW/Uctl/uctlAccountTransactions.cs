using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.Cls;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;
using Nevron.UI.WinForm.Controls;
using clsInterface4OME;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class uctlAccountTransactions : UserControl
    {
        #region "      METHODS     "
        //public string 
        public uctlAccountTransactions()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlAccountTransactions_Load(object sender, EventArgs e)
        {
            ui_ncmbPaymentType.Items.Clear();
            ui_ncmbPaymentType.Items.AddRange(Enum.GetNames(typeof(BOADMIN_NEW.Uctl.uctlEditAccountDetail.AmountType)));
            if (clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim() == "ITCM")
            {
                ui_ncmbITCM.Items.Add(clsGlobal.BrokerCompany);
                ui_ncmbITCM.SelectedIndex = 0;
                ui_lblParentBrokerValue.Text = clsGlobal.BrokerCompany.Trim();
                foreach (DS4AccountGroup.dtAccountGroupsRow item in clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" + clsGlobal.BrokerNameId))
                {
                    ui_ncmbTCM.Items.Add(item.Owner);
                }

                foreach (DS4Account.dtClientInfoRow item in clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select("AccountGroupID=" + clsGlobal.BrokerNameId))
                {
                    //ui_ncmbITCMClients.Items.Add(item.FirstName);
                    ui_ncmbSTMClients.Items.Add(item.ClientId.ToString().Trim() + "_" + item.FirstName);
                }
            }
            else
            {
                int parentId = clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.FirstOrDefault(a => a.AccountGroupID == clsGlobal.BrokerNameId).ParentAccountGroupID;
                ui_lblParentBrokerValue.Text = clsAccountManager.INSTANCE.GetBrokerCompanyName(parentId).Trim();
                switch (clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim())
                {
                    case "TCM":
                        {
                            ui_ncmbITCM.Enabled = false;
                            //ui_ncmbITCMClients.Enabled = false;
                            //ui_ncmbAccounts1.Enabled = false;
                            ui_ncmbTCM.Items.Add(clsGlobal.BrokerCompany);
                            ui_ncmbTCM.SelectedIndex = 0;
                        }
                        break;
                    case "TM":
                        {
                            ui_ncmbITCM.Enabled = false;
                            ui_ncmbTCM.Enabled = false;
                            //ui_ncmbITCMClients.Enabled = false;
                            //ui_ncmbTCMClients.Enabled = false;
                            //ui_ncmbAccounts1.Enabled = false;
                            //ui_ncmbAccounts2.Enabled = false;
                            ui_ncmbTM.Items.Add(clsGlobal.BrokerCompany);
                            ui_ncmbTM.SelectedIndex = 0;
                        }
                        break;
                    case "STM":
                        {
                            ui_ncmbITCM.Enabled = false;
                            ui_ncmbTCM.Enabled = false;
                            ui_ncmbTM.Enabled = false;
                            //ui_ncmbITCMClients.Enabled = false;
                            //ui_ncmbTCMClients.Enabled = false;
                            //ui_ncmbTMClients.Enabled = false;
                            //ui_ncmbAccounts1.Enabled = false;
                            //ui_ncmbAccounts2.Enabled = false;
                            //ui_ncmbAccounts3.Enabled = false;
                            ui_ncmbSTM.Items.Add(clsGlobal.BrokerCompany);
                            ui_ncmbSTM.SelectedIndex = 0;
                        }
                        break;
                }
            }
            // if (clsGlobal.BrokerID == 1)
            //{
            //string key = clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim() + "_" + clsGlobal.BrokerNameId + "_" + clsGlobal.BrokerCompany;
            //ui_ntvBrokerClients.Nodes.Add(key, key);
            //Recursive(key, clsGlobal.BrokerNameId, ui_ntvBrokerClients.Nodes[key]);
            // }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="brokerId"></param>
        /// <param name="parentNode"></param>
        public void Recursive(string key, int brokerId, TreeNode parentNode)
        {
            foreach (DS4AccountGroup.dtAccountGroupsRow item in clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" + brokerId)) //clsGlobal.BrokerID))
            {
                string key1 = clsBrokerManager.INSTANCE.GetBrokerType(item.BrokerTypeID).Trim() + "_" + item.AccountGroupID + "_" + item.Owner;
                //ui_ntvBrokerClients.Nodes[key].Nodes.Add(key1);
                parentNode.Nodes.Add(key1, key1);
                Recursive(key1, item.AccountGroupID, parentNode.Nodes[key1]);
            }

            //ui_ntvBrokerClients.Nodes[key].Nodes.Add("Clients", "Clients");
            parentNode.Nodes.Add("Clients", "Clients");
            foreach (DS4Account.dtClientInfoRow item in clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select("AccountGroupID=" + brokerId))
            {
                //ui_ntvBrokerClients.Nodes[key].Nodes["Clients"].Nodes.Add(item.FirstName);
                parentNode.Nodes["Clients"].Nodes.Add(item.FirstName, item.FirstName);
                List<clsAccount> lstAccountsInfo = clsProxyClassManager.INSTANCE.GetAccountRecords(item.ClientId, AccountOpType.ACCOUNT);
                clsAccountManager.INSTANCE.FillDataToAccountDataSet(lstAccountsInfo);
                foreach (clsAccount account in lstAccountsInfo)
                {
                    parentNode.Nodes["Clients"].Nodes[item.FirstName].Nodes.Add(account.AccountId.ToString());
                }
            }
            return;
        }

        private void ui_ntvBrokerClients_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                ui_ntxtAccountID.Text = e.Node.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            int accountID;
            if (!int.TryParse(ui_ntxtAccountID.Text, out accountID))
            {
                clsDialogBox.ShowErrorBox("Please specify account no", "Accounts", true);
                return;
            }
            if (ui_ntxtAmount.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Please specify amount", "Accounts", true);
                return;
            }

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

            UpdateAccountInfo(accountID);
            //this.ParentForm.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        private void UpdateAccountInfo(int accountID)
        {
            DS4Account.dtAccountsRow accountRow = clsAccountManager.INSTANCE._DS4Account.dtAccounts.FindByPK_AccountId(accountID);
            clsAccount objclsAccount = new clsAccount();
            clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
            if (ui_ncmbPaymentType.SelectedItem != null)
            {
                if (ui_ncmbPaymentType.SelectedItem.ToString() == "Deposit" && ui_ntxtAmount.Text != string.Empty)
                {

                    objclsAccount.Balence = accountRow.Balance + Convert.ToDecimal(ui_ntxtAmount.Text);
                    objclsAccount.PaymentAmount = clsUtility.GetDecimal(ui_ntxtAmount.Text);
                    objclsAccount.PaymentType = ui_ncmbPaymentType.SelectedItem.ToString();
                    objclsAccount.PaymentMode = ui_ntxtPaymentMode.Text;
                    objclsAccount.PaymentDate = DateTime.Now;
                    objclsBrokerOpLog.OperationName = "Deposit";
                }
                else if (ui_ncmbPaymentType.SelectedItem.ToString() == "Withdraw" && ui_ntxtAmount.Text != string.Empty)
                {
                    objclsAccount.Balence = accountRow.Balance - Convert.ToDecimal(ui_ntxtAmount.Text);
                    objclsAccount.PaymentAmount = clsUtility.GetDecimal(ui_ntxtAmount.Text);
                    objclsAccount.PaymentType = ui_ncmbPaymentType.SelectedItem.ToString();
                    objclsAccount.PaymentMode = ui_ntxtPaymentMode.Text;
                    objclsAccount.PaymentDate = DateTime.Now;
                    objclsBrokerOpLog.OperationName = "Withdraw";
                }
            }
            objclsAccount.Remark = clsUtility.GetStr(ui_ntxtRemark.Text);
            objclsAccount.ChequeFdNo = clsUtility.GetStr(ui_ntxtChequeFdNo.Text);
            objclsAccount.AccountGroupId = clsUtility.GetInt(accountRow.FK_AccountGroupID);
            objclsAccount.AccountId = clsUtility.GetInt(accountID);
            objclsAccount.ClientId = clsUtility.GetInt(accountRow.ClientID);
            objclsAccount.CurrencyId = clsUtility.GetInt(accountRow.FK_Currency);
            objclsAccount.Deleted = accountRow.Deleted;
            objclsAccount.Equity = clsUtility.GetDecimal(accountRow.Equity);
            objclsAccount.IsHedgingAllowed = accountRow.IsHedgingAllowed;
            objclsAccount.IsTradeEnable = accountRow.IsTradeEnable;
            objclsAccount.SellSideTurnOver = clsUtility.GetDecimal(accountRow.SellSideTurnOver);
            objclsAccount.BuySideTurnOver = clsUtility.GetDecimal(accountRow.BuySideTurnOver);
            objclsAccount.LeverageId = clsUtility.GetInt(accountRow.FK_Leverage);
            objclsAccount.UsedMargin = accountRow.UsedMargin;
            objclsAccount.RelatedBankId = clsUtility.GetInt(accountRow.FK_BankID);
            objclsAccount.HedgeTypeID = clsUtility.GetInt(accountRow.HedgeTypeID);
            objclsAccount = clsProxyClassManager.INSTANCE.UpdateAccount(objclsAccount, AccountOpType.ACCOUNT);

            if (objclsAccount.ServerResponseID != clsGlobal.FailureID)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(ProcessAccountData, objclsAccount);                
                if (objclsBrokerOpLog.OperationName == "Deposit")
                {
                    objclsBrokerOpLog.Message = objclsAccount.PaymentAmount + " amount is deposited in Account : " + accountID + " by "+objclsAccount.PaymentMode+".";
                }
                else if (objclsBrokerOpLog.OperationName == "Withdraw")
                    objclsBrokerOpLog.Message = objclsAccount.PaymentAmount + " amount is withdrawn from Account : " + accountID + ".";
                
                clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);               
            }
            else
            {
                clsDialogBox.ShowErrorBox("Error in updating", "Accounts", true);
            }
            ui_lblBalanceValue.Text = objclsAccount.Balence.ToString("0.00");
            ui_ntxtAccountID.Text = string.Empty;
            ui_ntxtAmount.Text = string.Empty;
            ui_ntxtChequeFdNo.Text = string.Empty;
            ui_ntxtRemark.Text = string.Empty;
            ui_ntxtPaymentMode.Text = string.Empty;
            ui_ncmbPaymentType.SelectedItem = null;
        }

        private void ProcessAccountData(object obj)
        {
            clsAccountManager.INSTANCE.DoHandleAccountTable(obj as clsAccount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbTCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbTCM.SelectedItem == null)
                return;
            ui_ntxtTCM.Text = ui_ncmbTCM.SelectedItem.ToString();
            ui_ncmbTM.Items.Clear();
            ui_ntxtTM.Text = string.Empty;
            //ui_ncmbTCMClients.Items.Clear();
            ui_ncmbSTMClients.Items.Clear();
            ui_ntxtSTMCient.Text = string.Empty;
            foreach (DS4AccountGroup.dtAccountGroupsRow item in clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" +
                clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbTCM.SelectedItem.ToString())))
            {
                ui_ncmbTM.Items.Add(item.Owner);
            }
            foreach (DS4Account.dtClientInfoRow item in clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select("AccountGroupID=" +
                clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbTCM.SelectedItem.ToString())))
            {
                //ui_ncmbTCMClients.Items.Add(item.FirstName);
                ui_ncmbSTMClients.Items.Add(item.ClientId.ToString().Trim() + "_" + item.FirstName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbTM.SelectedItem == null)
                return;
            ui_ntxtTM.Text = ui_ncmbTM.SelectedItem.ToString();
            ui_ncmbSTM.Items.Clear();
            ui_ntxtSTM.Text = string.Empty;
            //ui_ncmbTMClients.Items.Clear();
            ui_ncmbSTMClients.Items.Clear();
            ui_ntxtSTMCient.Text = string.Empty;
            foreach (DS4AccountGroup.dtAccountGroupsRow item in clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" +
                clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbTM.SelectedItem.ToString())))
            {
                ui_ncmbSTM.Items.Add(item.Owner);
            }
            foreach (DS4Account.dtClientInfoRow item in clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select("AccountGroupID=" +
               clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbTM.SelectedItem.ToString())))
            {
                //ui_ncmbTMClients.Items.Add(item.FirstName);
                ui_ncmbSTMClients.Items.Add(item.ClientId.ToString().Trim() + "_" + item.FirstName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbSTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbSTM.SelectedItem == null)
                return;
            ui_ntxtSTM.Text = ui_ncmbSTM.SelectedItem.ToString();
            ui_ncmbSTMClients.Items.Clear();
            ui_ntxtSTMCient.Text = string.Empty;
            foreach (DS4Account.dtClientInfoRow item in clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select("AccountGroupID=" +
                clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbSTM.SelectedItem.ToString())))
            {
                ui_ncmbSTMClients.Items.Add(item.ClientId.ToString().Trim() + "_" + item.FirstName);
            }
        }

        private void ui_ncmbLoginBrokerClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillAccountInfo(string clientName, NComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<clsAccount> lstAccountsInfo = clsProxyClassManager.INSTANCE.GetAccountRecords(
                Convert.ToInt32(clientName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0]), AccountOpType.ACCOUNT);
            clsAccountManager.INSTANCE.FillDataToAccountDataSet(lstAccountsInfo);
            foreach (clsAccount account in lstAccountsInfo)
            {
                comboBox.Items.Add(account.AccountId.ToString());
            }
        }

        private void ui_ncmbITCMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_ncmbITCMClients.SelectedItem == null)
            //    return;
            //ui_ntxtITCMClient.Text = ui_ncmbITCMClients.SelectedItem.ToString();
            //FillAccountInfo(ui_ncmbITCMClients.SelectedItem.ToString(),ui_ncmbAccounts1);
        }

        private void ui_ncmbTCMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_ncmbTCMClients.SelectedItem == null)
            //    return;
            //ui_ntxtTCMClient.Text = ui_ncmbTCMClients.SelectedItem.ToString();
            //FillAccountInfo(ui_ncmbTCMClients.SelectedItem.ToString(), ui_ncmbAccounts2);
        }

        private void ui_ncmbTMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_ncmbTMClients.SelectedItem == null)
            //    return;
            //ui_ntxtTMClient.Text = ui_ncmbTMClients.SelectedItem.ToString();
            //FillAccountInfo(ui_ncmbTMClients.SelectedItem.ToString(), ui_ncmbAccounts3);
        }

        private void ui_ncmbSTMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbSTMClients.SelectedItem == null)
                return;
            ui_ntxtSTMCient.Text = ui_ncmbSTMClients.SelectedItem.ToString();
            FillAccountInfo(ui_ncmbSTMClients.SelectedItem.ToString(), ui_ncmbAccounts4);
        }

        private void ui_ncmbITCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbITCM.SelectedItem == null)
                return;
            ui_ntxtITCM.Text = ui_ncmbITCM.SelectedItem.ToString();
        }

        private void ui_rbt4_CheckedChanged(object sender, EventArgs e)
        {
            SetAccountIdText(ui_rbt4.Checked, ui_ncmbAccounts4.SelectedItem);
        }

        private void ui_rbt3_CheckedChanged(object sender, EventArgs e)
        {
            //SetAccountIdText(ui_rbt3.Checked, ui_ncmbAccounts3.SelectedItem);
        }

        private void ui_rbt2_CheckedChanged(object sender, EventArgs e)
        {
            // SetAccountIdText(ui_rbt2.Checked, ui_ncmbAccounts2.SelectedItem);
        }

        private void ui_rbt1_CheckedChanged(object sender, EventArgs e)
        {
            //SetAccountIdText(ui_rbt1.Checked, ui_ncmbAccounts1.SelectedItem);
        }

        public void SetAccountIdText(bool checkedValue, object accountID)
        {
            if (checkedValue)
            {
                if (accountID == null)
                    return;
                ui_ntxtAccountID.Text = accountID.ToString();
            }
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ui_ncmbAccounts4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbAccounts4.SelectedItem != null)
            {
                ui_ntxtAccountID.Text = ui_ncmbAccounts4.SelectedItem.ToString();
                DS4Account.dtAccountsRow row = clsAccountManager.INSTANCE._DS4Account.dtAccounts.FindByPK_AccountId(Convert.ToInt32(ui_ncmbAccounts4.SelectedItem));
                ui_lblBalanceValue.Text = row.Balance.ToString("0.00");
                ui_lblUsedMarginValue.Text = row.UsedMargin.ToString("0.00");
            }
        }

        private void ui_ntxtITCM_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbITCM, ui_ntxtITCM);
        }

        private void HandleComboBoxAutoComplete(NComboBox comboBox, NTextBox relatedTextBox)
        {
            comboBox.SetItemsAsAutoCompleteSource();

            List<string> lst = new List<string>();
            foreach (NListBoxItem item in comboBox.Items)
            {
                lst.Add(item.Text);
            }
            int i = 0;
            foreach (string item in lst)
            {
                if (item.ToLower().StartsWith(relatedTextBox.Text.ToLower()))
                {
                    comboBox.SelectedItem = item;
                    i++;
                    comboBox.DropDownItems = 7;
                    comboBox.DropDown();
                    relatedTextBox.Text = item.ToString();
                    return;
                    //i++;
                }
            }
        }

        private void ui_ntxtTCM_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbTCM, ui_ntxtTCM);
        }

        private void ui_ntxtTM_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbTM, ui_ntxtTM);
        }

        private void ui_ntxtSTM_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbSTM, ui_ntxtSTM);
        }

        private void ui_ntxtSTMCient_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbSTMClients, ui_ntxtSTMCient);
        }

        #endregion "    METHODS    "
    }
}
