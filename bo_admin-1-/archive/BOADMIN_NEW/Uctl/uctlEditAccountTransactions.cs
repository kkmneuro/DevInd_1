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
using BOADMIN_NEW.DS;
using BOADMIN_NEW.Forms;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlEditAccountTransactions : UserControl
    {
        #region "      METHODS     "
        //public string 
        DS4EditAccountTrans _DS4DS4EditAccountTrans = new DS4EditAccountTrans();
        public uctlEditAccountTransactions()
        {
            InitializeComponent();
        }

        private void uctlAccountTransactions_Load(object sender, EventArgs e)
        {
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
                    ui_ncmbSTMClients.Items.Add(item.ClientId.ToString().Trim()+"_"+item.FirstName);
                }
            }
            else
            {
                int parentId= clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.FirstOrDefault(a => a.AccountGroupID == clsGlobal.BrokerNameId).ParentAccountGroupID;
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
                            ui_ncmbTM.Items.Add(clsGlobal.BrokerCompany);
                            ui_ncmbTM.SelectedIndex = 0;
                        }
                        break;
                    case "STM":
                        {
                            ui_ncmbITCM.Enabled = false;
                            ui_ncmbTCM.Enabled = false;
                            ui_ncmbTM.Enabled = false;
                            ui_ncmbSTM.Items.Add(clsGlobal.BrokerCompany);
                            ui_ncmbSTM.SelectedIndex = 0;
                        }
                        break;
                }
            }

            DataGridViewButtonColumn objDataGridViewButtonColumn = new DataGridViewButtonColumn();
            objDataGridViewButtonColumn.DefaultCellStyle.NullValue = "Edit";
            objDataGridViewButtonColumn.Name = "Edit";
            objDataGridViewButtonColumn.Text = "Edit";
            ui_ndgvAccountTransactions.Columns.Add(objDataGridViewButtonColumn);
        }

        private void ui_ntvBrokerClients_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            int accountID;
            if (!int.TryParse(ui_ntxtAccountID.Text, out accountID))
            {
                clsDialogBox.ShowErrorBox("Please specify account no", "Accounts", true);
                return;
            }

            UpdateAccountInfo(accountID);
            //this.ParentForm.Close();
        }

        private void UpdateAccountInfo(int accountID)
        {
            DS4Account.dtAccountsRow accountRow = clsAccountManager.INSTANCE._DS4Account.dtAccounts.FindByPK_AccountId(accountID);
            clsAccount objclsAccount = new clsAccount();
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
            objclsAccount = clsProxyClassManager.INSTANCE.UpdateAccount(objclsAccount,AccountOpType.ACCOUNT_TRANSACTION);

            if (objclsAccount.ServerResponseID != clsGlobal.FailureID)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(ProcessAccountData, objclsAccount);
            }
            else
            {
                clsDialogBox.ShowErrorBox("Error in updating", "Accounts", true);
            }
        }

        private void ProcessAccountData(object obj)
        {
            clsAccountManager.INSTANCE.DoHandleAccountTable(obj as clsAccount);
        }

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

        private void FillAccountInfo(string clientName,NComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<clsAccount> lstAccountsInfo = clsProxyClassManager.INSTANCE.GetAccountRecords(
                Convert.ToInt32(clientName.Split(new char[]{'_'},StringSplitOptions.RemoveEmptyEntries)[0]),AccountOpType.ACCOUNT);
            clsAccountManager.INSTANCE.FillDataToAccountDataSet(lstAccountsInfo);
            foreach (clsAccount account in lstAccountsInfo)
            {
                comboBox.Items.Add(account.AccountId.ToString());
            }
        }

        private void ui_ncmbITCMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ui_ncmbTCMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ui_ncmbTMClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            
        }

        private void ui_rbt3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ui_rbt2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ui_rbt1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void SetAccountIdText(bool checkedValue,object accountID)
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
            if (ui_ncmbAccounts4.SelectedItem!=null)
            {
                ui_ntxtAccountID.Text = ui_ncmbAccounts4.SelectedItem.ToString();
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetAccountsCompleted += new EventHandler<GetAccountsCompletedEventArgs>(_objClientInfoClient_GetAccountsCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetAccountsAsync(clsGlobal.userIDPwd,Convert.ToInt32(ui_ncmbAccounts4.SelectedItem),
                    AccountOpType.ACCOUNT_TRANSACTION);
                //DS4Account.dtAccountsRow row= clsAccountManager.INSTANCE._DS4Account.dtAccounts.FindByPK_AccountId(Convert.ToInt32(ui_ncmbAccounts4.SelectedItem));
            }
        }

        void _objClientInfoClient_GetAccountsCompleted(object sender, GetAccountsCompletedEventArgs e)
        {
            _DS4DS4EditAccountTrans.dtAccountTrans.Rows.Clear();

            foreach (clsAccount item in e.Result.ToList())
            {
                _DS4DS4EditAccountTrans.dtAccountTrans.AdddtAccountTransRow(item.EditAccountTransactionID,item.AccountId, item.PaymentAmount, item.PaymentType, item.PaymentMode, item.PaymentDate,
                    item.ChequeFdNo, item.Remark);
            }

            ui_ndgvAccountTransactions.DataSource = _DS4DS4EditAccountTrans.dtAccountTrans;
        }

        private void ui_ntxtITCM_KeyUp(object sender, KeyEventArgs e)
        {
            HandleComboBoxAutoComplete(ui_ncmbITCM, ui_ntxtITCM);
        }

        private void HandleComboBoxAutoComplete(NComboBox comboBox,NTextBox relatedTextBox)
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

        private void ui_ndgvAccountTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvAccountTransactions.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                DataGridViewRow row = ui_ndgvAccountTransactions.Rows[e.RowIndex];

                Forms.FrmBase objfrmCommonContainer = new FrmBase();
                Uctl.uctlEditAccountTransChild objuctlAccountTransactions = new BOADMIN_NEW.Uctl.uctlEditAccountTransChild();
                objuctlAccountTransactions.OnOkClick += new Action<clsAccount>(objuctlAccountTransactions_OnOkClick);
                objfrmCommonContainer.Text = "Edit";
                objfrmCommonContainer.ClientSize = objuctlAccountTransactions.Size;
                objfrmCommonContainer.Controls.Add(objuctlAccountTransactions);
                objuctlAccountTransactions.Dock = DockStyle.Fill;
                objfrmCommonContainer.MaximizeBox = false;
                objfrmCommonContainer.MinimizeBox = false;
                objfrmCommonContainer.BringToFront();
                objuctlAccountTransactions.SetValues(row);
                objfrmCommonContainer.ShowDialog();
                //string id = row.Cells["AccountID"].Value.ToString();
            }
        }

        void objuctlAccountTransactions_OnOkClick(clsAccount accountInfo)
        {
            DS4EditAccountTrans.dtAccountTransRow row = _DS4DS4EditAccountTrans.dtAccountTrans.FindByID(accountInfo.EditAccountTransactionID);

            if (row != null)
            {
                row.AccountID = accountInfo.AccountId;
                row.PaymentMode = accountInfo.PaymentMode;
                row.PaymentType = accountInfo.PaymentType;
                row.Amount = accountInfo.PaymentAmount;
                row.Remark = accountInfo.Remark;
                row.ChequeNo = accountInfo.ChequeFdNo;
            }
            _DS4DS4EditAccountTrans.dtAccountTrans.AcceptChanges();

        }
    }
}
