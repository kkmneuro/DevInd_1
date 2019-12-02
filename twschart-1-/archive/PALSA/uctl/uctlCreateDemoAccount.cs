using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Runtime.InteropServices;
using CommonLibrary.Cls;
using System.Threading;
using PALSA.Cls;

namespace PALSA.uctl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class uctlCreateDemoAccount : UserControl
    {
        #region MEMBERS
        #region UI_DATA

        Dictionary<int, string> _DDBankAccounts = new Dictionary<int, string>();
        public int _ClientId = 0;
        public bool BankAccountDetailsChanged = false;
        public bool TradeAccountDetailsChanged = false;
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);

        #endregion UI_DATA

        public event Action<string, string> OnLoginClicked = delegate { };

        #endregion MEMBERS
        /// <summary>
        /// 
        /// </summary>
        public uctlCreateDemoAccount()
        {
                InitializeComponent();
        }

        private void uctlAccountPersonal_Load(object sender, EventArgs e)
        {
            ui_nbtnLogin.Visible = false;
            ui_ncmbLeverage.Items.Clear();
            ui_ncmbCountry.Items.Clear();
            //ui_ncmbNationality.Items.Clear();
            ui_ncmbLeverage.Items.AddRange(PALSA.Cls.ClsGlobal.Leverage);// PALSA.Cls.clsTWSOrderManagerJSON.INSTANCE.GetLeverageList().ToArray();
            ui_ncmbCountry.Items.AddRange(PALSA.Cls.ClsGlobal.Countries);//PALSA.Cls.clsTWSOrderManagerJSON.INSTANCE.GetCountryList().ToArray()
            //ui_ncmbNationality.Items.AddRange(PALSA.Cls.ClsGlobal.Countries);//PALSA.Cls.clsTWSOrderManagerJSON.INSTANCE.GetCountryList().ToArray()
        }

        private void ui_btnOK_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            backgroundWorker1.WorkerReportsProgress=true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();        
        }

        private TradeAccount.LoginCredent CreateAccount()
        {
           
           return PALSA.Cls.clsTWSOrderManagerJSON.INSTANCE.CreateDemoAccount(ui_ntxtFirstName.Text 
               , Convert.ToDecimal(ui_ntxtBalence.Text),ui_ncmbCountry.SelectedItem.ToString(), 
               ui_ntxtEmail.Text, ui_ncmbLeverage.SelectedItem.ToString(),ui_ntxtCurrencyName.Text, true);
        }

        private bool ValidateInfo()
        {
            if (ui_ntxtFirstName.Text == string.Empty)
            {
                DialogResult result = ClsCommonMethods.ShowErrorBox("Please enter First Name");
                ui_ntxtFirstName.Focus();
                return false;
            }
            //if (ui_ntxtMasterPassword.Text == string.Empty)
            //{
            //    DialogResult result = ClsCommonMethods.ShowErrorBox("Please enter Master Password");
            //    ui_ntxtMasterPassword.Focus();
            //    return false;
            //}
            //if (ui_ntxtLoginId.Text == string.Empty)
            //{
            //    DialogResult result = ClsCommonMethods.ShowErrorBox("Please enter Login ID");
            //    ui_ntxtLoginId.Focus();
            //    return false;
            //}
            //if (ui_ncmbGender.SelectedItem == null)
            //{
            //    DialogResult result = ClsCommonMethods.ShowErrorBox("Please select gender");
            //    ui_ncmbGender.Focus();
            //    return false;
            //}
            if (ui_ncmbCountry.SelectedItem == null)
            {
                DialogResult result = ClsCommonMethods.ShowErrorBox("Please select country");
                ui_ncmbCountry.Focus();
                return false;
            }
            //if (ui_ncmbNationality.Text == string.Empty)
            //{
            //    DialogResult result = ClsCommonMethods.ShowErrorBox("Please select nationality");
            //    ui_ncmbNationality.Focus();
            //    return false;
            //}
            if (ui_ntxtEmail.Text == string.Empty)
            {
                DialogResult result = ClsCommonMethods.ShowErrorBox("Please enter Email Address");
                ui_ntxtEmail.Focus();
                return false;
            }
            if (!ClsCommonMethods.ValidateEmail(ui_ntxtEmail.Text))
            {
                DialogResult result = ClsCommonMethods.ShowErrorBox("Invalid Email Address");
                ui_ntxtEmail.Focus();
                return false;
            }
            //if (ui_ntxtMobile.Text == string.Empty)
            //{
            //    DialogResult result = ClsCommonMethods.ShowErrorBox("Please enter mobile no");
            //    ui_ntxtMobile.Focus();
            //    return false;
            //}
            if (ui_ncmbLeverage.SelectedItem ==null)
            {
                DialogResult result = ClsCommonMethods.ShowErrorBox("Please select leverage");
                ui_ncmbLeverage.Focus();
                return false;
            }

            return true;
        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private string CreatePassword(int min, int max)
        {
            string RandomString = string.Empty;
            Random random = new System.Random();
            for (int count = 0; count < 2; count++)
            {
                Char Randomchar = Convert.ToChar(random.Next(min, max));
                RandomString += Randomchar.ToString();
            }
            return RandomString;
        }


        private void HideAllColumns(Nevron.UI.WinForm.Controls.NDataGridView grid)
        {
            foreach (DataGridViewColumn dc in grid.Columns)
            {
                dc.Visible = false;
            }
        }

        //private void ui_ntxtBankPhone_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtBankFaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtfaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtSecondaryPhone_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //        e.Handled = true;
        //}

        //private void ui_ntxtBankAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void ui_ntxtState_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void ui_ntxtCity_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void ui_ntxtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtBankCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtLoginId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtMarkupValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ui_ncmbCountry_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ui_ntxtNationality_KeyUp(object sender, KeyEventArgs e)
        //{
        //    ui_ncmbNationality.SetItemsAsAutoCompleteSource();

        //    List<string> lst = new List<string>();
        //    foreach (NListBoxItem item in ui_ncmbNationality.Items)
        //    {
        //        lst.Add(item.Text);
        //    }
        //    int i = 0;
        //    foreach (string item in lst)
        //    {
        //        if (item.ToLower().StartsWith(ui_ntxtNationality.Text.ToLower()))
        //        {
        //            ui_ncmbNationality.SelectedItem = item;
        //            i++;
        //            ui_ncmbNationality.DropDownItems = 7;
        //            ui_ncmbNationality.DropDown();
        //            ui_ntxtNationality.Text = item.ToString();
        //            return;
        //            //i++;
        //        }
        //    }
        //}

        private void ui_ntxtBankCountry_KeyUp(object sender, KeyEventArgs e)
        {
            ui_ncmbCountry.SetItemsAsAutoCompleteSource();

            List<string> lst = new List<string>();
            foreach (NListBoxItem item in ui_ncmbCountry.Items)
            {
                lst.Add(item.Text);
            }
            int i = 0;
            foreach (string item in lst)
            {
                if (item.ToLower().StartsWith(ui_ntxtCountry.Text.ToLower()))
                {
                    ui_ncmbCountry.SelectedItem = item;
                    i++;
                    ui_ncmbCountry.DropDownItems = 7;
                    ui_ncmbCountry.DropDown();
                    ui_ncmbCountry.Text = item.ToString();
                    return;
                    //i++;
                }
            }
        }

        private void ui_ncmbBankCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ntxtCountry.Text = ui_ncmbCountry.SelectedItem.ToString();
        }

        //private void ui_ncmbNationality_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ui_ntxtNationality.Text = ui_ncmbNationality.SelectedItem.ToString();
        //}

        private void ui_ncmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbBankCountry_SelectedIndexChanged(null, null);
        }
        TradeAccount.LoginCredent credential = null;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (ValidateInfo())
            {
                credential = new TradeAccount.LoginCredent();
                credential = CreateAccount();
                //lblLoginIdPWD.Text = "Your Demo Account Created Successfuly. LoginId is " + x.loginId + " and Password is " + x.password + " .";
                //this.ParentForm.Close(); 
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (IsWorkerCompleted)
            {
                timer1.Enabled = false;
                ui_ntxtLoginID.Text= credential.loginId;
                ui_ntxtPassword.Text = credential.password;
                ui_nbtnLogin.Visible = true;
                nProgressBar1.Properties.Value = 100;
            }
            else
            {
                if (nProgressBar1.Properties.Value < 98)
                {
                    nProgressBar1.Properties.Value += 1;
                }
            }
        }
        volatile bool IsWorkerCompleted = false;
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IsWorkerCompleted = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                IsWorkerCompleted = true;
            }
        }

        private void ui_nbtnLogin_Click(object sender, EventArgs e)
        {
            OnLoginClicked(ui_ntxtLoginID.Text, ui_ntxtPassword.Text);
        }
    }
}
