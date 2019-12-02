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
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Edit bank details
    /// </summary>
    public partial class uctlEditBankDetail : uctlGeneric, Interfaces.IUserCtrl
    {
        public uctlEditBankDetail()
        {
            InitializeComponent();
        }
        public Bank _bankToUpdate;
        public event Action<Bank> OnBankAccountUpdate = delegate { };
        private void ui_nbtnUpdateBankAccount_Click(object sender, EventArgs e)
        {
            UpdateHandler();


        }
        /// <summary>
        /// update handler
        /// </summary>
        private void UpdateHandler()
        {
            if (ui_ntxtBankName.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Bank Name.", "Input Error", true);
                ui_ntxtBankName.Focus();
                return;
            }
            if (ui_ntxtAccountHolderName.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Account Holder's Name.", "Input Error", true);
                ui_ntxtAccountHolderName.Focus();
                return;
            }

            if (ui_ntxtBankAccountNo.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Account Number.", "Input Error", true);
                ui_ntxtBankAccountNo.Focus();
                return;
            }

            if (ui_ncmbBankAccountType.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Account Type.", "Input Error", true);
                ui_ncmbBankAccountType.Focus();
                return;
            }

            if (ui_ncmbBankCountry.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Country.", "Input Error", true);
                ui_ncmbBankCountry.Focus();
                return;
            }

            SubmitInformation();
            this.ParentForm.Close();
        }

        /// <summary>
        /// summit information
        /// </summary>
        private void SubmitInformation()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlEditBankDetail : Enter SubmitInformation()");
                _bankToUpdate._AccountHolderName = ui_ntxtAccountHolderName.Text;
                _bankToUpdate._BankAccountID = ui_ntxtBankAccountNo.Text;
                _bankToUpdate._BankAccountType = ui_ncmbBankAccountType.Text;
                _bankToUpdate._BankAddress = ui_ntxtAddress1.Text;
                _bankToUpdate._BankAddress2 = ui_ntxtAddress2.Text;
                _bankToUpdate._BankCity = ui_ntxtBankCity.Text;
                _bankToUpdate._BankCountryID = Cls.clsAccountManager.INSTANCE.GetCountryId(ui_ncmbBankCountry.SelectedItem.ToString());
                _bankToUpdate._BankFax = ui_ntxtBankFaxNumber.Text;
                _bankToUpdate._BankIFSCCode = ui_ntxtIFSCCode.Text;
                _bankToUpdate._BankName = ui_ntxtBankName.Text;
                _bankToUpdate._BankPhone = ui_ntxtBankPhone.Text;
                _bankToUpdate._BankSwiftCode = ui_ntxtSwiftcode.Text;
                _bankToUpdate._BankZipCode = ui_ntxtBankZipCode.Text;
                OnBankAccountUpdate(_bankToUpdate);
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlEditBankDetail =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SubmitInformation()");
            }
        }

        /// <summary>
        /// initialize controls of the control
        /// </summary>
        internal void InitControls()
        {
            //=_bankToUpdate._BankID;             //_bankToUpdate._ClientID;
            DS4Account.dtCountryMasterDataTable _dtCountries = Cls.clsAccountManager.INSTANCE._DS4Account.dtCountryMaster;
            foreach (DataRow dr in _dtCountries.Rows)
            {
                ui_ncmbBankCountry.Items.Add(dr[1].ToString());
            }
            ui_ntxtAccountHolderName.Text = _bankToUpdate._AccountHolderName;
            ui_ntxtBankAccountNo.Text = _bankToUpdate._BankAccountID;
            ui_ncmbBankAccountType.SelectedIndex = ui_ncmbBankAccountType.Items.IndexOf(_bankToUpdate._BankAccountType);
            ui_ntxtAddress1.Text = _bankToUpdate._BankAddress;
            ui_ntxtAddress2.Text = _bankToUpdate._BankAddress2;
            ui_ntxtBankCity.Text = _bankToUpdate._BankCity;
            ui_ncmbBankCountry.SelectedIndex = _bankToUpdate._BankCountryID;
            ui_ntxtBankFaxNumber.Text = _bankToUpdate._BankFax;
            ui_ntxtIFSCCode.Text = _bankToUpdate._BankIFSCCode;
            ui_ntxtBankName.Text = _bankToUpdate._BankName;
            ui_ntxtBankPhone.Text = _bankToUpdate._BankPhone;
            ui_ntxtSwiftcode.Text = _bankToUpdate._BankSwiftCode;
            ui_ntxtBankZipCode.Text = _bankToUpdate._BankZipCode.Trim();
        }

        private void ui_ntxtBankPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// handles key press handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtBankFaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }


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
    }
}
