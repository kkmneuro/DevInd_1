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

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlEditAccountDetail : uctlGeneric, Interfaces.IUserCtrl
    {
        public uctlEditAccountDetail()
        {
            InitializeComponent();
        }
        public Account _AccountToUpdate;
        public event Action<Account> OnTradeAccountUpdate = delegate { };
        private void ui_nbtnUpdateTradeAccount_Click(object sender, EventArgs e)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlEditAccountDetail : Enter ui_nbtnUpdateTradeAccount_Click()");
                if (ui_ncmbBankAccounts.Text == string.Empty)
                {
                    DialogResult result = clsDialogBox.ShowErrorBox("Please select Bank Account.", "Input Error", true);
                    ui_ncmbBankAccounts.Focus();
                    return;
                }
                //_AccountToUpdate._AccountGroupId = ui_ntxtAccountHolderName.Text;
                //_AccountToUpdate._AccountId = ui_ntxtBankAccountNo.Text;
                if (ui_ntxtAmount.Text != string.Empty && ui_ncmbPaymentType.SelectedItem == null)
                {
                    clsDialogBox.ShowErrorBox("Please select AmountType", "Account Error", true);
                    ui_ncmbPaymentType.Focus();
                    return;
                }
                if (ui_ntxtAmount.Text != string.Empty && ui_ncmbPaymentType.SelectedItem != null && ui_ntxtPaymentMode.Text == string.Empty)
                {
                    clsDialogBox.ShowErrorBox("Please specifiy paymentmode", "Account Error", true);
                    ui_ntxtPaymentMode.Focus();
                    return;
                }

                if (ui_ncmbPaymentType.SelectedItem != null)
                {
                    if (ui_ncmbPaymentType.SelectedItem.ToString() == "Deposit" && ui_ntxtAmount.Text != string.Empty)
                    {

                        _AccountToUpdate._Balence = _AccountToUpdate._Balence + Convert.ToDecimal(ui_ntxtAmount.Text);
                        _AccountToUpdate._PaymentAmount = clsUtility.GetDecimal(ui_ntxtAmount.Text);
                        _AccountToUpdate._PaymentType = ui_ncmbPaymentType.SelectedItem.ToString();
                        _AccountToUpdate._PaymentMode = ui_ntxtPaymentMode.Text;
                        _AccountToUpdate._PaymentDate = DateTime.Now;

                    }
                    else if (ui_ncmbPaymentType.SelectedItem.ToString() == "Withdraw" && ui_ntxtAmount.Text != string.Empty)
                    {
                        _AccountToUpdate._Balence = _AccountToUpdate._Balence - Convert.ToDecimal(ui_ntxtAmount.Text);
                        _AccountToUpdate._PaymentAmount = clsUtility.GetDecimal(ui_ntxtAmount.Text);
                        _AccountToUpdate._PaymentType = ui_ncmbPaymentType.SelectedItem.ToString();
                        _AccountToUpdate._PaymentMode = ui_ntxtPaymentMode.Text;
                        _AccountToUpdate._PaymentDate = DateTime.Now;
                    }
                }
                if (ui_ncmbAcType.SelectedItem.ToString().Trim() == "Live")
                {
                    _AccountToUpdate._IsLive = true;
                }
                else if (ui_ncmbAcType.SelectedItem.ToString().Trim() == "Demo")
                {
                    _AccountToUpdate._IsLive = false;
                }
                //_AccountToUpdate._Balence = ui_ncmbBankAccountType.Text;
                _AccountToUpdate._BuySideTurnOver = clsUtility.GetDecimal(ui_ntxtBuySideTurnOver.Text);
                //_AccountToUpdate._ClientId = ui_ntxtAddress2.Text;
                _AccountToUpdate._CurrencyId = Cls.clsCurrencyManager.INSTANCE.GetCurrencyId(ui_ncmbCurrency.SelectedItem.ToString());
                _AccountToUpdate._Deleted = ui_nchkDisable.Checked;
                //_AccountToUpdate._Equity = ui_ntxtBankFaxNumber.Text;
                _AccountToUpdate._IsHedgingAllowed = ui_nchkHedgingAllowed.Checked;
                _AccountToUpdate._IsTradeEnable = ui_nchkTradeEnable.Checked;
                _AccountToUpdate._LeverageId = Cls.clsLeverageManager.INSTANCE.GetLeverageId(ui_ncmbLeverage.SelectedItem.ToString());
                _AccountToUpdate._RelatedBankId = Cls.clsAccountManager.INSTANCE.GetBankID(ui_ncmbBankAccounts.Text, _AccountToUpdate._ClientId);
                _AccountToUpdate._SellSideTurnOver = clsUtility.GetDecimal(ui_ntxtSellSideTurnOver.Text);
                _AccountToUpdate._ChequeFDNo = clsUtility.GetStr(ui_ntxtChequeFdNo.Text);
                if (ui_ncmbHedgeType.SelectedItem != null)
                    _AccountToUpdate._HedgeTypeID = clsMasterInfoManager.INSTANCE.GetHedgeTypeID(ui_ncmbHedgeType.SelectedItem.ToString());
                //_AccountToUpdate._UsedMargin = ui_ntxtBankZipCode.Text;
                OnTradeAccountUpdate(_AccountToUpdate);
                _frmCommonContainer.Close();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlEditAccountDetail =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ui_nbtnUpdateTradeAccount_Click()");
            }
        }
        internal void InitControls()
        {
            ui_ncmbHedgeType.Items.Clear();
            ui_ncmbHedgeType.Items.AddRange(clsMasterInfoManager.INSTANCE.GetHedgeTypes());
            if (ui_ncmbHedgeType.Items.Contains("Hedgeing Not support"))
            {
                ui_ncmbHedgeType.SelectedIndex = ui_ncmbHedgeType.Items.IndexOf("Hedgeing Not support");
            }
            ui_ncmbLeverage.Items.AddRange(clsLeverageManager.INSTANCE.GetLeverageArray());            
            DS4Account.dtBankInformationRow[] _dtBankAccounts = clsAccountManager.INSTANCE.GetBankAccounts(_AccountToUpdate._ClientId);
            Dictionary<int, string> _DDBankAccounts = new Dictionary<int, string>();
            foreach (DS4Account.dtBankInformationRow dr in _dtBankAccounts)
            {
                if (!_DDBankAccounts.ContainsValue(dr.BankName) && dr.BankName != string.Empty)
                    _DDBankAccounts.Add(dr.PK_BankID, dr.BankName);
            }
            ui_ncmbBankAccounts.Items.AddRange(_DDBankAccounts.Values.ToArray());
            ui_ncmbCurrency.Items.AddRange(clsCurrencyManager.INSTANCE.GetCurrencyArray());
            ui_ncmbCurrency.SelectedIndex = _AccountToUpdate._CurrencyId - 1;
            ui_ntxtBuySideTurnOver.Text = clsUtility.GetStr(_AccountToUpdate._BuySideTurnOver);
            ui_nchkDisable.Checked = _AccountToUpdate._Deleted;
          //  ui_nchkHedgingAllowed.Checked = _AccountToUpdate._IsHedgingAllowed;
          //  ui_ncmbHedgeType.Enabled = _AccountToUpdate._IsHedgingAllowed;
            ui_nchkTradeEnable.Checked = _AccountToUpdate._IsTradeEnable;
            ui_ncmbBankAccounts.Editable = true;
            ui_ncmbLeverage.SelectedIndex = _AccountToUpdate._LeverageId - 1;
            ui_ncmbBankAccounts.Text = clsAccountManager.INSTANCE.GetBankName(_AccountToUpdate._RelatedBankId);
            ui_ntxtSellSideTurnOver.Text = clsUtility.GetStr(_AccountToUpdate._SellSideTurnOver);
           // ui_ncmbHedgeType.SelectedIndex =ui_ncmbHedgeType.Items.IndexOf(clsMasterInfoManager.INSTANCE.GetHedgeType(_AccountToUpdate._HedgeTypeID));
            ui_ncmbPaymentType.Items.Clear();
            ui_ncmbPaymentType.Items.AddRange(Enum.GetNames(typeof(AmountType)));
            ui_ncmbPaymentType.SelectedIndex = 0;
            ui_ncmbAcType.Items.Clear();
            if (clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim() == "ITCM")
            {
                ui_ncmbAcType.Items.Add("Live");
                ui_ncmbAcType.Items.Add("Demo");
            }
            else
            {
                ui_ncmbAcType.Items.Add("Live");
            }
            if (_AccountToUpdate._IsLive)
            {
                if (ui_ncmbAcType.Items.Contains("Live"))
                {
                    ui_ncmbAcType.SelectedIndex = ui_ncmbAcType.Items.IndexOf("Live");
                }
                //else
                //{
                //    ui_ncmbAcType.Items.Add("Live");
                //    ui_ncmbAcType.SelectedIndex = ui_ncmbAcType.Items.IndexOf("Live");
                //}                
            }
            else
            {
                if (ui_ncmbAcType.Items.Contains("Demo"))
                {
                    ui_ncmbAcType.SelectedIndex = ui_ncmbAcType.Items.IndexOf("Demo");
                }
                //else
                //{
                //    ui_ncmbAcType.Items.Add("Demo");
                //    ui_ncmbAcType.SelectedIndex = ui_ncmbAcType.Items.IndexOf("Demo");
                //}                
            }
            
        }

        public enum AmountType { Deposit, Withdraw };

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.InitControls()
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_ntxtSellSideTurnOver_TextChanged(object sender, EventArgs e)
        {

        }

        private void ui_ntxtSellSideTurnOver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtBuySideTurnOver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uctlEditAccountDetail_Load(object sender, EventArgs e)
        {
            if (clsGlobal.BrokerID != 1)
            {
                ui_nchkHedgingAllowed.Visible = false;
            }
            else
            {
                ui_nchkHedgingAllowed.Visible = true;
            }
            
        }

        private void ui_nchkHedgingAllowed_CheckedChanged(object sender, EventArgs e)
        {
            ui_ncmbHedgeType.Enabled = ui_nchkHedgingAllowed.Checked;
        }

        private void ui_ntxtAmount_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (tt.Text.IndexOf('.') > -1 && tt.Text.Substring(tt.Text.IndexOf('.')).Length >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtAmount_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtAmount.Text.Contains('.'))
            {
                string[] RealNumber = ui_ntxtAmount.Text.Split('.');
                if (clsUtility.GetInt(RealNumber[0]) < 10)
                {
                    if (clsUtility.GetInt(RealNumber[0]) == 0)
                    {
                        RealNumber[0] = "00";
                        ui_ntxtAmount.Text = RealNumber[0] + "." + RealNumber[1];
                    }
                    else
                    {
                        RealNumber[0] = "0" + RealNumber[0];
                        ui_ntxtAmount.Text = RealNumber[0] + "." + RealNumber[1];
                    }
                }
                if (RealNumber[1] == string.Empty)
                {
                    ui_ntxtAmount.Text = RealNumber[0] + ".00";
                }
            }
            else if (Convert.ToInt32(ui_ntxtAmount.Text.Trim())<10)
            {
                Cls.clsGlobal.HandleZero(sender, e, 1);
                ui_ntxtAmount.Text = ui_ntxtAmount.Text + ".00";
            }
            else
                ui_ntxtAmount.Text = ui_ntxtAmount.Text + ".00";
        }
    }
}
