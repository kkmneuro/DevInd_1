using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

using BOADMIN_NEW.BOEngineServiceTCP;
using Nevron.UI.WinForm.Controls;
using System.Runtime.InteropServices;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class uctlAccountPersonal : uctlGeneric, Interfaces.IUserCtrl
    {


        #region MEMBERS
        #region UI_DATA

        public DS4Account.dtClientInfoRow _ClientRow = null;
        public DS4Account.dtAccountsRow _AccountsRow = null;
        public DS4Account.dtBankInformationRow _BankRow = null;
        public DS4Account.dtCountryMasterDataTable _dtCountries = null;
        public DS4AccountGroup.dtAccountGroupsDataTable _dtGroups = null;
        public DS4Account.dtBankInformationRow[] _BankAccounts = null;
        Dictionary<int, string> _DDBankAccounts = new Dictionary<int, string>();
        public int _ClientId = 0;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        public bool BankAccountDetailsChanged = false;
        public bool TradeAccountDetailsChanged = false;
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);

        #endregion UI_DATA

        #endregion MEMBERS
        /// <summary>
        /// 
        /// </summary>
        public uctlAccountPersonal()
        {
            try
            {
                InitializeComponent();

                clsBrokersManagerHandler.INSTANCE.UpdateBrokerList += new Action(INSTANCE_UpdateBrokerList);
                //ui_ncmbLeverage.SelectedIndex = 14;
                //ui_txtRegDate.Text =
                // ui_txtMastPassword.Text CreatePassword(97, 122) + CreatePassword(48,57) + CreatePassword(65, 85);
                //ui_ntxtMasterPassword.Text = CreatePassword(97, 122) + CreatePassword(48, 57) + CreatePassword(65, 85);
                //ui_ncmbGroup.Items.AddRange(clsGroupManager.INSTANCE.GetGroupNameArray());
                //ui_ncmbGroup.SelectedIndex = 0;
                //ui_ncmbCountry.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        void INSTANCE_UpdateBrokerList()
        {
            UpdateBrokerList();
        }
        //public uctlAccountPersonal(AccountDetails details)
        //{
        //    InitializeComponent();
        //    ui_txtName.Text = details.LoginName;
        //}

        #region IUserCtrl Members

        public void UpdateBrokerList()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(UpdateBrokerItems);

        }

        public void UpdateBrokerItems(object obj)
        {
            //foreach (string item in clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()))
            //{
            //if (clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.Contains(item))
            ui_ncmbGroup.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.ToArray());
            //}
            //foreach (string item in clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames)
            //{
            //}
            //ui_ncmbGroup.Items.AddRange(clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()).ToArray());//clsAccountManager.INSTANCE.GetAccountGroupNameArray());
            ui_ncmbGroup.Items.Insert(0, clsGlobal.BrokerCompany);
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Initializes the control
        /// </summary>
        public void InitControls()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter InitControls()");

                clsAccountManager.INSTANCE.FillDataToAccountDataSet(clsProxyClassManager.INSTANCE.GetAccountRecords(_ClientId, AccountOpType.ACCOUNT));
                //if (_ClientRow == null)
                //{
                //    ui_nbtnUpdate.Visible = true;
                //    ui_nbtnCancel.Visible = true;
                //    ui_nbtnOK.Visible = true;
                //    ui_lblMasterPassword.Visible = true;
                //    ui_ntxtMasterPassword.Visible = true;
                //    return;
                //}
                ui_ncmbLPName.Items.Clear();
                ui_ncmbLPName.Items.AddRange(clsMasterInfoManager.INSTANCE.GetLPNames().ToArray());
                if (_mode == clsEnums.FRM_MODE.EDIT && _AccountsRow != null && ui_ncmbLPName.Items.Contains(_AccountsRow.LP_Name))
                {
                    ui_ncmbLPName.SelectedIndex = ui_ncmbLPName.Items.IndexOf(_AccountsRow.LP_Name);
                    // ui_ncmbLPName.Enabled = false;
                }
                ui_ncmbGroup.Items.Clear();
                //foreach (string item in clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()))
                //{
                //if (clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.Contains(item))
                ui_ncmbGroup.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.ToArray());
                // }
                //ui_ncmbGroup.Items.AddRange(clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()).ToArray());//clsAccountManager.INSTANCE.GetAccountGroupNameArray());
                ui_ncmbGroup.Items.Add(clsGlobal.BrokerCompany);
                ui_ncmbClientAccountType.Items.AddRange(clsMasterInfoManager.INSTANCE.GetClientAccountTypes().ToArray());
                if (clsGlobal.BrokerID != 1)
                {
                    ui_ncmbClientAccountType.Items.Remove("MM");
                }
                clsAccountManager.INSTANCE._DS4Account.dtBankInformation.RowChanged += new DataRowChangeEventHandler(dtBankInformation_RowChanged);
                clsAccountManager.INSTANCE._DS4Account.dtAccounts.RowChanged += new DataRowChangeEventHandler(dtAccounts_RowChanged);
                _dtCountries = clsAccountManager.INSTANCE._DS4Account.dtCountryMaster;
                ui_ncmbBankAccountType.SelectedIndex = 0;

                foreach (DataRow dr in _dtCountries.Rows)
                {
                    ui_ncmbCountry.Items.Add(dr[1].ToString());
                    ui_ncmbNationality.Items.Add(dr[1].ToString());
                    ui_ncmbBankCountry.Items.Add(dr[1].ToString());
                }
                ui_ncmbCountry.SelectedIndex = 0;
                ui_ncmbNationality.SelectedIndex = 0;
                ui_ncmbBankCountry.SelectedIndex = 0;
                ui_ncmbBankCountry.SelectedIndex = 0;
                ui_ncmbCurrency.Items.AddRange(clsCurrencyManager.INSTANCE.GetCurrencyArray());
                ui_ncmbLeverage.Items.AddRange(clsLeverageManager.INSTANCE.GetLeverageArray());
                ui_ncmbParticipantType.Items.AddRange(clsParticipantTypeManager.INSTANCE.GetParticipantTypeArray());
                string[] BankAccountTypes = { "Saving", "Service", "Current" };
                DataGridViewComboBoxColumn countrycol = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn accountTypecol = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn editcol1 = new DataGridViewButtonColumn();
                editcol1.Name = "BankEditCol";
                editcol1.DefaultCellStyle.NullValue = "Edit";
                editcol1.Text = "Edit";
                editcol1.HeaderText = "Edit";
                DataGridViewButtonColumn editcol2 = new DataGridViewButtonColumn();
                editcol2.Name = "AccountEditCol";
                editcol2.Text = "Edit";
                editcol2.DefaultCellStyle.NullValue = "Edit";
                editcol2.HeaderText = "Edit";
                countrycol.DataPropertyName = "FK_BankCountryID";
                countrycol.DataSource = _dtCountries;
                countrycol.Name = "Country";
                countrycol.HeaderText = "Country";
                countrycol.DisplayMember = _dtCountries.CountryNameColumn.ColumnName;
                countrycol.ValueMember = _dtCountries.PK_CountryIDColumn.ColumnName;
                accountTypecol.DataSource = BankAccountTypes;
                accountTypecol.DataPropertyName = "BankAccountType";
                accountTypecol.Name = "BankAccountType";
                accountTypecol.HeaderText = "Account Type";
                ui_ndgvBankAccounts.Columns.Add(editcol1);
                ui_ndgvBankAccounts.Columns.Add(countrycol);
                ui_ndgvBankAccounts.Columns.Add(accountTypecol);
                ui_ncmbBankAccountType.Items.Clear();
                ui_ncmbBankAccountType.Items.AddRange(BankAccountTypes);
                DataGridViewComboBoxColumn Leveragecol = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn Currencycol = new DataGridViewComboBoxColumn();
                Leveragecol.DataPropertyName = "FK_Leverage";
                DS4Leverage.dtLeverageDataTable _dtLeverage = clsLeverageManager.INSTANCE._DS4Leverage.dtLeverage;
                DS4Currency.dtCurrencyDataTable _dtCurrency = clsCurrencyManager.INSTANCE._DS4Currency.dtCurrency;
                Leveragecol.DataSource = _dtLeverage;
                Leveragecol.Name = "Leverage";
                Leveragecol.HeaderText = "Leverage";
                Leveragecol.DisplayMember = _dtLeverage.LeverageColumn.ColumnName;
                Leveragecol.ValueMember = _dtLeverage.PK_LeverageIdColumn.ColumnName;
                Currencycol.DataSource = _dtCurrency;
                Currencycol.DataPropertyName = "FK_Currency";
                Currencycol.Name = "Currency";
                Currencycol.HeaderText = "Currency";
                Currencycol.DisplayMember = _dtCurrency.CurrencyNameColumn.ColumnName;
                Currencycol.ValueMember = _dtCurrency.PK_Currency_IDColumn.ColumnName;
                ui_ndgvAccounts.Columns.Add(editcol2);
                ui_ndgvAccounts.Columns.Add(Leveragecol);
                ui_ndgvAccounts.Columns.Add(Currencycol);
                ui_ndgvBankAccounts.DataSource = _BankAccounts;
                nTabControl1.TabPages[1].Enabled = false;
                nTabControl1.TabPages[2].Enabled = false;
                DS4Account.dtAccountsRow[] drArr = (DS4Account.dtAccountsRow[])clsAccountManager.INSTANCE._DS4Account.dtAccounts.Select("ClientId=" + _ClientId);
                ui_ndgvAccounts.DataSource = drArr;
                ui_nbtnUpdate.Text = "Save";
                if (_mode == clsEnums.FRM_MODE.ADD)
                {
                    ui_ndtpRegDate.Text = DateTime.Now.ToString();
                }

                if (_ClientRow != null)
                {
                    ui_nbtnUpdate.Text = "Update";
                    nTabControl1.TabPages[1].Enabled = true;
                    nTabControl1.TabPages[2].Enabled = true;
                    if (_ClientRow.Gender.Trim() == "MALE")
                        ui_ncmbGender.SelectedIndex = 0;
                    else
                        ui_ncmbGender.SelectedIndex = 1;
                    if (clsAccountManager.INSTANCE.AccountGrpAccountOwner.ContainsKey(_ClientRow.GroupName.ToUpper()))
                    {
                        ui_ncmbGroup.SelectedIndex = ui_ncmbGroup.Items.IndexOf(clsAccountManager.INSTANCE.AccountGrpAccountOwner[_ClientRow.GroupName.ToUpper()]);
                    }
                    else
                    ui_ncmbGroup.SelectedIndex = ui_ncmbGroup.Items.IndexOf(_ClientRow.GroupName);        
                   
                    ui_ncmbClientAccountType.SelectedIndex = ui_ncmbClientAccountType.Items.IndexOf(clsMasterInfoManager.INSTANCE.GetCLientAccountTypeName(_ClientRow.AccountTypeID));
                    DS4Account.dtBankInformationRow[] _dtBankAccounts = clsAccountManager.INSTANCE.GetBankAccounts(_ClientId);
                    ui_ncmbCountry.SelectedIndex = ui_ncmbCountry.Items.IndexOf(Cls.clsAccountManager.INSTANCE.GetCountryName(_ClientRow.FK_CountryID));
                    ui_ncmbNationality.SelectedIndex = ui_ncmbNationality.Items.IndexOf(Cls.clsAccountManager.INSTANCE.GetCountryName(_ClientRow.FK_NationalityID));
                    ui_ncmbParticipantType.SelectedIndex = _ClientRow.ParticipantType - 1;

                    if (_mode == clsEnums.FRM_MODE.ADD)
                    {
                        if (!_ClientRow.IsAddress1Null())
                            ui_ntxtAddress1.Text = _ClientRow.Address1;
                        if (!_ClientRow.IsAddress1Null())
                            ui_ntxtAddress2.Text = _ClientRow.Address2;
                    }
                    if (_ClientRow.Age.Trim() == string.Empty)
                    {
                        ui_ntxtAge.Text = "0";
                    }
                    else if (!_ClientRow.IsAgeNull())
                    {
                        ui_ntxtAge.Text = _ClientRow.Age;
                    }
                    //_AccountRow.Balance;
                    if (!_ClientRow.IsZoneNull())
                        ui_ntxtCity.Text = _ClientRow.Zone;
                    //_AccountRow.Deleted;
                    if (!_ClientRow.IsDOBNull())
                    {                        
                        if (_ClientRow.DOB != DateTime.MinValue)
                        {
                            ui_ndtpDOB.Value = _ClientRow.DOB;
                        }

                    }
                    //_AccountRow.Equity;
                    if (!_ClientRow.IsFaxNumberNull())
                        ui_ntxtfaxNumber.Text = _ClientRow.FaxNumber;
                    if (!_ClientRow.IsFirstNameNull())
                        ui_ntxtFirstName.Text = _ClientRow.FirstName;
                    if (!_ClientRow.IsLastNameNull())
                        ui_ntxtLastName.Text = _ClientRow.LastName;
                    //_AccountRow.LoginID;
                    if (!_ClientRow.IsMasterPasswordNull())
                        ui_ntxtMasterPassword.Text = _ClientRow.MasterPassword.Trim();
                    if (!_ClientRow.IsMidleNameNull())
                        ui_ntxtMiddleName.Text = _ClientRow.MidleName;
                    if (!_ClientRow.IsMobileNull())
                        ui_ntxtMobile.Text = _ClientRow.Mobile;
                    if (!_ClientRow.IsPANNull())
                        ui_ntxtPanNo.Text = _ClientRow.PAN;
                    //_ClientRow.ParticipantType;
                    if (!_ClientRow.IsPassportIdNull())
                        ui_ntxtPassportNo.Text = _ClientRow.PassportId;
                    if (!_ClientRow.IsPrimaryEmailAddressNull())
                        ui_ntxtEmail.Text = _ClientRow.PrimaryEmailAddress;
                    if (!_ClientRow.IsPrimaryPhoneNull())
                        ui_ntxtPhone.Text = _ClientRow.PrimaryPhone;
                    if (_mode == clsEnums.FRM_MODE.EDIT)
                    {
                        if (!_ClientRow.IsRegistrationDateNull())
                        {
                            if (_ClientRow.RegistrationDate != DateTime.MinValue)
                                ui_ndtpRegDate.Text = _ClientRow.RegistrationDate.ToString();
                        }
                    }

                    if (!_ClientRow.IsSecondaryEmailAddressNull())
                        ui_ntxtAlternativeEmail.Text = _ClientRow.SecondaryEmailAddress;
                    if (!_ClientRow.IsSecondaryPhoneNull() && _ClientRow.SecondaryPhone != string.Empty)
                        ui_ntxtSecondaryPhone.Text = _ClientRow.SecondaryPhone;
                    if (!_ClientRow.IsSSNNull())
                        ui_ntxtSSN.Text = _ClientRow.SSN;
                    if (!_ClientRow.IsDistrictNull())
                        ui_ntxtState.Text = _ClientRow.District;
                    if (!_ClientRow.IsAddress1Null())
                        ui_ntxtPIAddress1.Text = _ClientRow.Address1;
                    if (!_ClientRow.IsAddress2Null())
                        ui_ntxtPIAddress2.Text = _ClientRow.Address2;
                    if (!_ClientRow.IsStatusNull())
                        ui_nchkEnable.Checked = _ClientRow.Status;
                    if (!_ClientRow.IsTradingPasswordNull())
                        ui_ntxtTradingPassword.Text = _ClientRow.TradingPassword.Trim();
                    if (!_ClientRow.IsZipNull())
                        ui_ntxtZipCode.Text = _ClientRow.Zip;
                    if (!_ClientRow.IsLoginIDNull())
                        ui_ntxtLoginId.Text = _ClientRow.LoginID.Trim();
                    ui_ntxtMarkupValue.Text = _ClientRow.MarkupValue.ToString();
                    DataGridViewComboBoxColumn BankAccountscol = new DataGridViewComboBoxColumn();

                    foreach (DS4Account.dtBankInformationRow dr in _dtBankAccounts)
                    {
                        if (!_DDBankAccounts.ContainsValue(dr.BankName) && dr.BankName != string.Empty)
                        {
                            _DDBankAccounts.Add(dr.PK_BankID, dr.BankName);
                        }
                        //_DDBankAccounts.Add(dr.PK_BankID, dr.BankName);
                    }
                    ui_ncmbBankAccounts.Items.AddRange(_DDBankAccounts.Values.ToArray());
                    BankAccountscol.DataSource = _dtBankAccounts;
                    BankAccountscol.DataPropertyName = "FK_BankId";
                    BankAccountscol.Name = "BankAccount";
                    BankAccountscol.HeaderText = "Bank Account";
                    BankAccountscol.DisplayMember = clsAccountManager.INSTANCE._DS4Account.dtBankInformation.BankNameColumn.ColumnName;
                    BankAccountscol.ValueMember = clsAccountManager.INSTANCE._DS4Account.dtBankInformation.PK_BankIDColumn.ColumnName;
                    ui_ndgvAccounts.Columns.Add(BankAccountscol);
                    HideAllColumns(ui_ndgvBankAccounts);
                    StyleBankGrid();
                    HideAllColumns(ui_ndgvAccounts);
                    StyleAccountGrid();
                    if (_mode == clsEnums.FRM_MODE.EDIT)
                    {
                        ui_ntxtFirstName.Enabled = false;
                        ui_ntxtMiddleName.Enabled = false;
                        ui_ntxtLastName.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in InitControls()");
            }
        }

        void dtAccounts_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            Action A = () =>
            {
                ui_ndgvAccounts.DataSource = clsAccountManager.INSTANCE.GetTradeAccounts(_ClientId);
                HideAllColumns(ui_ndgvAccounts);
                StyleAccountGrid();
            };
            if (ui_ndgvAccounts.InvokeRequired)
            {
                ui_ndgvAccounts.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }
        /// <summary>
        /// Refresh the grid on row change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtBankInformation_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            Action A = () =>
            {
                _BankAccounts = clsAccountManager.INSTANCE.GetBankAccounts(_ClientId);
                ui_ndgvBankAccounts.DataSource = _BankAccounts;
                _DDBankAccounts.Clear();
                foreach (DS4Account.dtBankInformationRow dr in _BankAccounts)
                {
                    if (!_DDBankAccounts.ContainsValue(dr.BankName) && dr.BankName != string.Empty)
                    {
                        _DDBankAccounts.Add(dr.PK_BankID, dr.BankName);
                    }

                }
                ui_ncmbBankAccounts.Items.Clear();
                ui_ncmbBankAccounts.Items.AddRange(_DDBankAccounts.Values.ToArray());

                HideAllColumns(ui_ndgvBankAccounts);
                StyleBankGrid();
            };
            if (ui_ndgvBankAccounts.InvokeRequired)
            {
                ui_ndgvBankAccounts.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        /// <summary>
        /// Styles the grid
        /// </summary>
        private void StyleAccountGrid()
        {
            if (ui_ndgvAccounts.Columns.Count > 1)
            {
                if (ui_ndgvAccounts.Columns["BankAccount"] != null)
                {
                    ui_ndgvAccounts.Columns["BankAccount"].ReadOnly = true;
                }
                ui_ndgvAccounts.Columns["PK_AccountID"].ReadOnly = true;
                ui_ndgvAccounts.Columns["PK_AccountID"].HeaderText = "Account ID";
                ui_ndgvAccounts.Columns["PK_AccountID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["Balance"].ReadOnly = true;
                ui_ndgvAccounts.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["Equity"].ReadOnly = true;
                ui_ndgvAccounts.Columns["Equity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["BuySideTurnOver"].ReadOnly = true;
                ui_ndgvAccounts.Columns["BuySideTurnOver"].HeaderText = "Buy Side Turnover";
                ui_ndgvAccounts.Columns["BuySideTurnOver"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["SellSideTurnOver"].ReadOnly = true;
                ui_ndgvAccounts.Columns["SellSideTurnOver"].HeaderText = "Sell Side Turnover";
                ui_ndgvAccounts.Columns["SellSideTurnOver"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["Deleted"].ReadOnly = true;
                ui_ndgvAccounts.Columns["Leverage"].ReadOnly = true;
                ui_ndgvAccounts.Columns["Leverage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvAccounts.Columns["IsHedgingAllowed"].ReadOnly = true;
                ui_ndgvAccounts.Columns["IsHedgingAllowed"].HeaderText = "Is Hedging Allowed";
                ui_ndgvAccounts.Columns["IsTradeEnable"].ReadOnly = true;
                ui_ndgvAccounts.Columns["IsTradeEnable"].HeaderText = "Is Trade Enable";
                ui_ndgvAccounts.Columns["Currency"].ReadOnly = true;
                ui_ndgvAccounts.Columns["UsedMargin"].ReadOnly = true;
                ui_ndgvAccounts.Columns["UsedMargin"].HeaderText = "Used Margin";

                ui_ndgvAccounts.Columns["AccountEditCol"].Visible = true;
                if (ui_ndgvAccounts.Columns["BankAccount"] != null)
                {
                    ui_ndgvAccounts.Columns["BankAccount"].Visible = true;
                }
                ui_ndgvAccounts.Columns["PK_AccountID"].Visible = true;
                ui_ndgvAccounts.Columns["Balance"].Visible = true;
                ui_ndgvAccounts.Columns["Equity"].Visible = true;
                ui_ndgvAccounts.Columns["BuySideTurnOver"].Visible = true;
                ui_ndgvAccounts.Columns["SellSideTurnOver"].Visible = true;
                ui_ndgvAccounts.Columns["Deleted"].Visible = true;
                ui_ndgvAccounts.Columns["Leverage"].Visible = true;
                ui_ndgvAccounts.Columns["IsHedgingAllowed"].Visible = true;
                ui_ndgvAccounts.Columns["IsTradeEnable"].Visible = true;
                ui_ndgvAccounts.Columns["Currency"].Visible = true;
                ui_ndgvAccounts.Columns["UsedMargin"].Visible = true;
                ui_ndgvAccounts.Columns["IsLive"].Visible = true;
                ui_ndgvAccounts.Columns["IsLive"].HeaderText = "Account Type";
            }
        }


        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_btnUpdate_Click(object sender, EventArgs e)
        {
            ValidatePersonalInformation();

        }

        /// <summary>
        /// Validates information
        /// </summary>
        private void ValidatePersonalInformation()
        {
            if (ui_ncmbClientAccountType.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Account Type", "Input Error", true);
                ui_ncmbBankAccountType.Focus();
                return;
            }

            if (ui_ncmbGroup.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Account Group Name", "Input Error", true);
                ui_ncmbGroup.Focus();
                return;
            }
            if (ui_ntxtFirstName.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter First Name", "Input Error", true);
                ui_ntxtFirstName.Focus();
                return;
            }
            if (ui_ndtpDOB.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter DOB", "Input Error", true);
                ui_ndtpDOB.Focus();
                return;
            }
            if (ui_ntxtMasterPassword.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Master Password", "Input Error", true);
                ui_ntxtMasterPassword.Focus();
                return;
            }
            if (ui_ncmbParticipantType.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Please enter PartcipantType", "Input Error", true);
                ui_ncmbParticipantType.Focus();
                return;
            }
            if (clsUtility.GetDate(ui_ndtpDOB.Text) < ui_ndtpDOB.MinDate || clsUtility.GetDate(ui_ndtpDOB.Text) > ui_ndtpDOB.MaxDate)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Date should not beyond 1/1/1753-12/31/9999", "Input Error", true);
                ui_ndtpDOB.Focus();
                return;
            }
            if (ui_ntxtLoginId.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Login ID", "Input Error", true);
                ui_ntxtLoginId.Focus();
                return;
            }
            if (ui_ntxtEmail.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Email Address", "Input Error", true);
                ui_ntxtEmail.Focus();
                return;
            }
            if (!clsGlobal.ValidateEmail(ui_ntxtEmail.Text))
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Invalid Email Address", "Input Error", true);
                ui_ntxtEmail.Focus();
                return;
            }


            if (_ClientRow != null)
            {
                _mode = clsEnums.FRM_MODE.EDIT;
                EditClientInfo();
                //_frmCommonContainer.Close();
            }
            else
            {
                _mode = clsEnums.FRM_MODE.ADD;
                EditClientInfo();
            }
            //this.ParentForm.Close();
            //_frmCommonContainer.Close();

        }

        /// <summary>
        /// Perform record insertion
        /// </summary>
        private void AddTradeAccounts()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter AddTradeAccounts()");
                string errorMsg = "Error in inserting client AccountInfo";
                clsAccount objclsAccount = new clsAccount();

                objclsAccount.AccountId = ProtocolStructIDS.DBInsert;
                if (ui_ncmbGroup.SelectedItem != null)
                    objclsAccount.AccountGroupId = clsAccountManager.INSTANCE.GetGroupId(ui_ncmbGroup.SelectedItem.ToString());
                objclsAccount.Balence = 0;
                objclsAccount.BuySideTurnOver = clsUtility.GetDecimal(ui_ntxtBuySideTurnOver.Text.Trim());
                objclsAccount.ClientId = _ClientId;
                objclsAccount.CurrencyId = clsCurrencyManager.INSTANCE.GetCurrencyId(ui_ncmbCurrency.SelectedItem.ToString());
                objclsAccount.Deleted = false;
                objclsAccount.Equity = 0;
                objclsAccount.IsHedgingAllowed = ui_nchkHedgingAllowed.Checked;
                objclsAccount.IsTradeEnable = ui_nchkTradeEnable.Checked;
                objclsAccount.LeverageId = clsLeverageManager.INSTANCE.GetLeverageId(ui_ncmbLeverage.SelectedItem.ToString());
                if (ui_ncmbBankAccounts.SelectedItem != null)
                {
                    objclsAccount.RelatedBankId = clsAccountManager.INSTANCE.GetBankID(ui_ncmbBankAccounts.SelectedItem.ToString(), _ClientId);
                }

                objclsAccount.SellSideTurnOver = clsUtility.GetDecimal(ui_ntxtSellSideTurnOver.Text.Trim());
                objclsAccount.UsedMargin = 0;
                objclsAccount.LPName = ui_ncmbLPName.SelectedItem.ToString(); //"DAW"; //ui_ncmbLPName.SelectedItem.ToString();
                objclsAccount.LPAccountID = "  "; //ui_ncmbLPAccounts.SelectedItem.ToString();
                if (ui_ncmbAccounType.SelectedItem.ToString().Trim() == "Live")
                {
                    objclsAccount.IsLive = true;
                }
                else if (ui_ncmbAccounType.SelectedItem.ToString().Trim() == "Demo")
                {
                    objclsAccount.IsLive = false;
                }
                if (ui_ncmbHedgeType.SelectedItem != null)
                    objclsAccount.HedgeTypeID = clsMasterInfoManager.INSTANCE.GetHedgeTypeID(ui_ncmbHedgeType.SelectedItem.ToString());

                objclsAccount = clsProxyClassManager.INSTANCE.InsertAccount(objclsAccount);

                if (objclsAccount.ServerResponseID != clsGlobal.FailureID)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessAccountData, objclsAccount);
                }
                else if (objclsAccount.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in AddTradeAccounts()");
            }
        }

        public void ProcessAccountData(object obj)
        {
            clsAccountManager.INSTANCE.DoHandleAccountTable(obj as clsAccount);
        }

        /// <summary>
        /// Performed bank record insertion
        /// </summary>
        private void AddBankAccounts()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter AddBankAccounts()");
                string errorMsg = "Error in inserting client BankInfo";
                ui_ncmbBankAccountType.SelectedIndex = 0;
                clsBank objclsBank = new clsBank();
                objclsBank.BankID = ProtocolStructIDS.DBInsert;
                objclsBank.AccountHolderName = this.ui_ntxtAccountHolderName.Text.Trim();
                objclsBank.BankAccountID = this.ui_ntxtBankAccountNo.Text.Trim();
                objclsBank.BankName = this.ui_ntxtBankName.Text.Trim();
                objclsBank.BankCountryID = clsAccountManager.INSTANCE.GetCountryId(ui_ncmbBankCountry.SelectedItem.ToString());
                objclsBank.BankCity = this.ui_ntxtBankCity.Text.Trim();
                objclsBank.BankZipCode = this.ui_ntxtBankZipCode.Text.Trim();
                objclsBank.BankAddress = this.ui_ntxtAddress1.Text.Trim();
                objclsBank.BankAddress2 = this.ui_ntxtAddress2.Text.Trim();
                objclsBank.BankPhone = this.ui_ntxtBankPhone.Text.Trim();
                objclsBank.BankFax = this.ui_ntxtBankFaxNumber.Text.Trim();
                objclsBank.BankSwiftCode = this.ui_ntxtSwiftcode.Text.Trim();
                //changed by vijay on 25 April
                if (ui_ncmbBankAccountType.SelectedItem != null)
                    objclsBank.BankAccountType = this.ui_ncmbBankAccountType.SelectedItem.ToString();  //this.ui_ncmbBankAccountType.SelectedIndex.ToString();
                objclsBank.BankIFSCCode = this.ui_ntxtIFSCCode.Text.Trim();
                objclsBank.ClientID = _ClientId;
                objclsBank = clsProxyClassManager.INSTANCE.InsertBank(objclsBank);

                if (objclsBank.ServerResponseID != clsGlobal.FailureID)
                {
                    DialogResult result = clsDialogBox.ShowMessageBox("Bank information Saved.Do you want to add Account Information?", "Conformation");
                    if (result == DialogResult.Yes)
                    {
                        nTabControl1.TabPages[2].Enabled = true;
                        nTabControl1.SelectedIndex = 2;
                    }

                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessBankData, objclsBank);
                }
                else if (objclsBank.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in AddBankAccounts()");
            }
        }

        public void ProcessBankData(object obj)
        {
            clsAccountManager.INSTANCE.DoHandleBankTable(obj as clsBank);
        }

        /// <summary>
        /// Edits client info
        /// </summary>
        private void EditClientInfo()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter EditClientInfo()");
                string errorMsg;
                clsClientInfo objclsClientInfo = new clsClientInfo();

                objclsClientInfo.Status = ui_nchkEnable.Checked;
                objclsClientInfo.FirstName = ui_ntxtFirstName.Text.Trim();
                objclsClientInfo.MidleName = ui_ntxtMiddleName.Text.Trim();
                objclsClientInfo.LastName = ui_ntxtLastName.Text.Trim();
                objclsClientInfo.Address1 = ui_ntxtPIAddress1.Text.Trim();
                objclsClientInfo.Address2 = ui_ntxtPIAddress2.Text.Trim();
                objclsClientInfo.City = ui_ntxtCity.Text.Trim();
                objclsClientInfo.State = ui_ntxtState.Text.Trim();
                objclsClientInfo.Zip = ui_ntxtZipCode.Text.Trim();
                objclsClientInfo.FaxNumber = ui_ntxtfaxNumber.Text.Trim();
                if (ui_ntxtMobile.Text != string.Empty)
                {
                    objclsClientInfo.Mobile = ui_ntxtMobile.Text.Trim();
                }
                objclsClientInfo.PassportId = ui_ntxtPassportNo.Text.Trim();
                objclsClientInfo.SSN = ui_ntxtSSN.Text.Trim();
                objclsClientInfo.DOB = ui_ndtpDOB.Value;
                objclsClientInfo.Gender = clsUtility.GetStr(ui_ncmbGender.SelectedItem);
                objclsClientInfo.Status = ui_nchkEnable.Checked;
                objclsClientInfo.Country = clsUtility.GetStr(ui_ncmbCountry.SelectedItem);
                objclsClientInfo.FKCountryID = clsAccountManager.INSTANCE.GetCountryId(ui_ncmbCountry.SelectedItem.ToString()); //clsUtility.GetInt(_dtCountries.Select("CountryName=" + clsUtility.GetStr(ui_ncmbCountry.SelectedItem))[0]["PK_CountryID"]);
                objclsClientInfo.FKNationalityID = clsAccountManager.INSTANCE.GetCountryId(ui_ncmbNationality.SelectedItem.ToString()); //clsUtility.GetInt(_dtCountries.Select("CountryName=" + clsUtility.GetStr(ui_ncmbNationality.SelectedItem))[0]["PK_CountryID"]);
                objclsClientInfo.GroupName = clsUtility.GetStr(ui_ncmbGroup.SelectedItem);
                objclsClientInfo.AccountGroupID = clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbGroup.SelectedItem.ToString()); //clsAccountManager.INSTANCE.GetGroupId(ui_ncmbGroup.SelectedItem.ToString());
                objclsClientInfo.FKParticipantType = clsParticipantTypeManager.INSTANCE.GetParticipantTypeId(ui_ncmbParticipantType.Text);
                objclsClientInfo.FKAccountTypeID = clsMasterInfoManager.INSTANCE.GetClientAccountTypeID(ui_ncmbClientAccountType.SelectedItem.ToString()); //1;
                objclsClientInfo.Deleted = false;
                objclsClientInfo.MasterPassword = ui_ntxtMasterPassword.Text.Trim();
                objclsClientInfo.TradingPassword = ui_ntxtTradingPassword.Text.Trim();
                objclsClientInfo.PrimaryPhone = ui_ntxtPhone.Text.Trim();
                objclsClientInfo.SecondaryPhone = ui_ntxtSecondaryPhone.Text.Trim();
                objclsClientInfo.RegistrationDate = clsUtility.GetDate(ui_ndtpRegDate.Text.Trim());
                if (_mode == clsEnums.FRM_MODE.ADD)
                {
                    objclsClientInfo.RegistrationDate = DateTime.Now;
                }
                objclsClientInfo.PrimaryEmailAddress = ui_ntxtEmail.Text.Trim();
                objclsClientInfo.SecondaryEmailAddress = ui_ntxtAlternativeEmail.Text.Trim();
                objclsClientInfo.PAN = ui_ntxtPanNo.Text.Trim();
                objclsClientInfo.Age = ui_ntxtAge.Text.Trim();
                objclsClientInfo.LoginID = ui_ntxtLoginId.Text.Trim();
                if (ui_ntxtMarkupValue.Text != string.Empty)
                {
                    objclsClientInfo.MarkupValue = clsUtility.GetDecimal(ui_ntxtMarkupValue.Text);
                }
                string opMsg;
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    errorMsg = "Error in updating ClientInfo";
                    objclsClientInfo.ClientId = _ClientRow.ClientId;
                    objclsClientInfo.RegistrationDate = clsUtility.GetDate(ui_ndtpRegDate.Text);
                    opMsg = "Edited Client record of ClientID : " + objclsClientInfo.ClientId + " and Client Name : " + objclsClientInfo.FirstName +
                        " AccountGroup Name : " + objclsClientInfo.GroupName + ".";// " Registration Date :" + objclsClientInfo.RegistrationDate + "Login ID :"
                        //+ " Email Address :" + objclsClientInfo.PrimaryEmailAddress + " Gender :" + objclsClientInfo.Gender;

                    objclsClientInfo = clsProxyClassManager.INSTANCE.UpdateClientInfo(objclsClientInfo);
                }
                else
                {
                    errorMsg = "Error in inserting ClientInfo";
                    objclsClientInfo.ClientId = ProtocolStructIDS.DBInsert;
                    //objclsClientInfo.MasterPassword = EncriptionAndDecription.EncryptString(ui_ntxtMasterPassword.Text.Trim(), "BoTrade");
                    //objclsClientInfo.TradingPassword = EncriptionAndDecription.EncryptString(ui_ntxtTradingPassword.Text.Trim(), "BoTrade");
                    if (clsProxyClassManager.INSTANCE.AuthenticateClientID(ui_ntxtLoginId.Text.Trim()))
                    {
                        clsDialogBox.ShowErrorBox("Client of given id already exists", "BOAdmin", true);
                        return;
                    }
                    objclsClientInfo = clsProxyClassManager.INSTANCE.InsertClientInfo(objclsClientInfo);
                    opMsg = "Added Client record of ClientID : " + objclsClientInfo.ClientId + ", Client Name : " + objclsClientInfo.FirstName +
                        " and AccountGroup Name : " + objclsClientInfo.GroupName + ".";// " Registration Date :" + objclsClientInfo.RegistrationDate + "Login ID :"
                        //+ " Email Address :" + objclsClientInfo.PrimaryEmailAddress + " Gender :" + objclsClientInfo.Gender;
                }

                if (objclsClientInfo.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        if (_mode == clsEnums.FRM_MODE.EDIT)
                        {
                            objclsBrokerOpLog.OperationName = "Client record Edited";
                           
                        }
                        else if (_mode == clsEnums.FRM_MODE.ADD)
                            objclsBrokerOpLog.OperationName = "New Client Added";
                        objclsBrokerOpLog.Message = opMsg;
                        //string str = _mode.ToString();
                        //clsEnums.FRM_MODE enm = (clsEnums.FRM_MODE)Enum.Parse(typeof(clsEnums.FRM_MODE), str);
                        //objclsBrokerOpLog.OperationName = enm.ToString();
                        //objclsBrokerOpLog.ControlName = "Client";
                        //objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    if (_mode == clsEnums.FRM_MODE.ADD)
                    {
                        _ClientId = objclsClientInfo.ClientId;
                        DialogResult result = clsDialogBox.ShowMessageBox("Personal information Saved.Do you want to add Bank Account Information?", "Conformation");
                        if (result == DialogResult.Yes)
                        {
                            nTabControl1.TabPages[1].Enabled = true;
                            _ClientRow = clsAccountManager.INSTANCE._DS4Account.dtClientInfo.AsEnumerable().Last();
                            //_ClientId = _ClientRow.ClientId;
                            nTabControl1.SelectedIndex = 1;
                        }
                        else
                            _frmCommonContainer.Close();
                    }
                    if (_mode == clsEnums.FRM_MODE.EDIT)
                    {
                        DialogResult result = clsDialogBox.ShowMessageBox("Updated personal information is Saved.Do you want to edit Bank Account Information?", "Conformation");
                        if (result == DialogResult.Yes)
                        {
                            nTabControl1.SelectedIndex = 1;
                        }
                        else
                            _frmCommonContainer.Close();
                    }

                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessClientInfoData, objclsClientInfo);
                }
                else if (objclsClientInfo.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditClientInfo()");
            }
        }

        public void ProcessClientInfoData(object obj)
        {
            clsAccountManager.INSTANCE.DoHandleClientInfoTable(obj as clsClientInfo);
        }

        private void uctlAccountPersonal_Load(object sender, EventArgs e)
        {
            //Namo
        //    if (clsGlobal.BrokerID != 1)
        //    {
        //        //Namo
        //        //ui_nchkHedgingAllowed.Visible = false;
        //        //ui_ncmbHedgeType.Visible = false;
        //        //ui_lblHedgeType.Visible = false;
        //        //Namo
        //        //ui_ncmbLPName.Visible = false;
        //        //ui_lblLPName.Visible = false;
        //        //ui_ncmbLPAccounts.Visible = false;
        //        //ui_LPAccounts.Visible = false;
        //    }
        //    else
        //    {
        //        //Namo
        //        ui_nchkHedgingAllowed.Visible = true;
        //        ui_ncmbHedgeType.Visible = true;
        //        ui_lblHedgeType.Visible = true;
        //        //Namo
        //    }
            //Namo
            ui_ncmbAccounType.Items.Clear();
            if (clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim() == "ITCM")
            {
                ui_ncmbAccounType.Items.Add("Live");
                ui_ncmbAccounType.Items.Add("Demo");
            }
            else
            {
                ui_ncmbAccounType.Items.Add("Live");
            }
            ui_ncmbHedgeType.Items.Clear();
            ui_ncmbHedgeType.Items.AddRange(clsMasterInfoManager.INSTANCE.GetHedgeTypes());
            if (ui_ncmbHedgeType.Items.Contains("Hedgeing Not support"))
            {
                ui_ncmbHedgeType.SelectedIndex = ui_ncmbHedgeType.Items.IndexOf("Hedgeing Not support");
            }
            //InitControls();
            nTabControl1.SelectedIndex = 0;
            ui_ncmbGender.SelectedIndex = 0;
            ui_ncmbBrokerType.Items.Clear();
            //ui_ncmbBrokerType.Items.AddRange(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray());
            for (int index = Cls.clsGlobal.BrokerID - 1; index < Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray().Count(); index++)
            {
                ui_ncmbBrokerType.Items.Add((Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]).Trim());
            }
            ui_ncmbBrokerType.Items.Insert(0, "All");
            ui_ncmbBrokerType.SelectedIndex = 0;
        }

        private void ui_btnOK_Click(object sender, EventArgs e)
        {
            EditClientInfo();

            this.ParentForm.Close(); //_frmCommonContainer.Close();

        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {

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

        private void ui_chkAllow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ui_chkSendReport_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ui_chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_nchkEnable.Checked != false)
            {
                ui_ntxtTradingPassword.Enabled = true;
                ui_ntxtCity.Enabled = true;
                ui_ntxtState.Enabled = true;
                ui_ncmbCountry.Enabled = true;
                ui_ntxtPIAddress1.Enabled = true;
                ui_ntxtZipCode.Enabled = true;
                ui_ntxtPhone.Enabled = true;
                ui_ntxtEmail.Enabled = true;
                ui_ntxtFirstName.Enabled = true;
                ui_ntxtMasterPassword.Enabled = true;
            }
            else
            {
            }
        }

        private void ui_nbtnAddBankaccount_Click(object sender, EventArgs e)
        {
            UpdateHandler();
        }
        /// <summary>
        /// Perform validation
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

            //this lines added by vijay on 30 April
            if (ui_ndgvBankAccounts.Columns.Count > 0)
            {
                foreach (DataGridViewRow item in ui_ndgvBankAccounts.Rows)
                {
                    if (item.Cells["BankAccountID"].Value.ToString().Trim() == ui_ntxtBankAccountNo.Text.Trim())
                    {
                        DialogResult result = clsDialogBox.ShowErrorBox("The given account is already added", "Input Error", true);
                        ui_ntxtBankAccountNo.Focus();
                        return;
                    }
                }
            }

            //end vijay code on 30 April

            AddBankAccounts();
            ui_ntbAccountInfo.Focus();
        }
        /// <summary>
        /// Style grid
        /// </summary>
        private void StyleBankGrid()
        {
            if (ui_ndgvBankAccounts.Columns.Count > 0)
            {
                ui_ndgvBankAccounts.Columns["AccountHolderName"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["AccountHolderName"].HeaderText = "Account Holder Name";
                ui_ndgvAccounts.Columns["SellSideTurnOver"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvBankAccounts.Columns["BankAccountID"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankAccountID"].HeaderText = "Bank Account ID";
                ui_ndgvBankAccounts.Columns["BankAccountID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvBankAccounts.Columns["BankName"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankName"].HeaderText = "Bank Name";
                ui_ndgvBankAccounts.Columns["Country"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankCity"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankCity"].HeaderText = "Bank City";
                ui_ndgvBankAccounts.Columns["BankZipCode"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankZipCode"].HeaderText = "Bank Zip Code";
                ui_ndgvBankAccounts.Columns["BankAddress1"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankAddress1"].HeaderText = "Bank Address1";
                ui_ndgvBankAccounts.Columns["BankAddress2"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankAddress2"].HeaderText = "Bank Address2";
                ui_ndgvBankAccounts.Columns["BankPhone"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankPhone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvBankAccounts.Columns["BankPhone"].HeaderText = "Bank Phone";
                ui_ndgvBankAccounts.Columns["BankFax"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankFax"].HeaderText = "Bank Fax";
                ui_ndgvBankAccounts.Columns["BankFax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ui_ndgvBankAccounts.Columns["BankSwiftCode"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankSwiftCode"].HeaderText = "Bank Swift Code";
                ui_ndgvBankAccounts.Columns["BankAccountType"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankAccountType"].HeaderText = "Bank Account Type";
                ui_ndgvBankAccounts.Columns["BankIFSCCode"].ReadOnly = true;
                ui_ndgvBankAccounts.Columns["BankIFSCCode"].HeaderText = "Bank IFSC Code";
                ui_ndgvBankAccounts.Columns["BankEditCol"].Visible = true;
                ui_ndgvBankAccounts.Columns["AccountHolderName"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankAccountID"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankName"].Visible = true;
                ui_ndgvBankAccounts.Columns["Country"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankCity"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankZipCode"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankAddress1"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankAddress2"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankPhone"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankFax"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankSwiftCode"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankAccountType"].Visible = true;
                ui_ndgvBankAccounts.Columns["BankIFSCCode"].Visible = true;
            }
        }
        private void HideAllColumns(Nevron.UI.WinForm.Controls.NDataGridView grid)
        {
            foreach (DataGridViewColumn dc in grid.Columns)
            {
                dc.Visible = false;
            }
        }

        /// <summary>
        /// Handles cell click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvBankAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvBankAccounts.Columns[e.ColumnIndex].Name == "BankEditCol" && e.RowIndex > -1)
            {
                Bank bank = new Bank();
                DS4Account.dtBankInformationRow _bankRow = clsAccountManager.INSTANCE._DS4Account.dtBankInformation.FindByPK_BankID(Convert.ToInt32(ui_ndgvBankAccounts.Rows[e.RowIndex].Cells["PK_BankId"].Value.ToString()));
                bank._BankID = _bankRow.PK_BankID;
                bank._AccountHolderName = _bankRow.AccountHolderName;
                bank._BankAccountID = _bankRow.BankAccountID;
                bank._BankAccountType = _bankRow.BankAccountType;
                bank._BankAddress = _bankRow.BankAddress1;
                bank._BankAddress2 = _bankRow.BankAddress2;
                bank._BankCity = _bankRow.BankCity;
                bank._BankCountryID = _bankRow.FK_BankCountryID - 1;
                bank._BankFax = _bankRow.BankFax;
                bank._BankIFSCCode = _bankRow.BankIFSCCode;
                bank._BankName = _bankRow.BankName;
                bank._BankPhone = _bankRow.BankPhone;
                bank._BankSwiftCode = _bankRow.BankSwiftCode;
                bank._BankZipCode = _bankRow.BankZipCode;
                bank._ClientID = _bankRow.ClientID;
                EditBankAccount(bank, DialogType.Edit);
            }
        }

        private void EditBankAccount(Bank bank, DialogType dialogType)
        {
            //Forms.frmCommonContainer frmUpdateBankAccount = new BOADMIN_NEW.Forms.frmCommonContainer();
            uctlEditBankDetail objEditBankDetail = new uctlEditBankDetail();
            objEditBankDetail._bankToUpdate = bank;
            objEditBankDetail.OnBankAccountUpdate += new Action<Bank>(objEditBankDetail_OnBankAccountUpdate);
            objEditBankDetail.InitControls();
            objEditBankDetail._ContainerCaption = "Edit Account";
            objEditBankDetail.ShowDialog();
            //objEditBankDetail.Dock = DockStyle.Fill;
            //frmUpdateBankAccount.ClientSize = objEditBankDetail.Size;
            //frmUpdateBankAccount.Controls.Add(objEditBankDetail);
            //frmUpdateBankAccount.ShowDialog();

        }

        void objEditBankDetail_OnBankAccountUpdate(Bank obj)
        {
            UpdateBankAccount(obj);
        }
        /// <summary>
        /// updates bank account info
        /// </summary>
        /// <param name="bank"></param>
        private void UpdateBankAccount(Bank bank)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter UpdateBankAccount()");
                string errorMsg = "Error in updating Client BankInfo";
                clsBank objclsBank = new clsBank();
                objclsBank.AccountHolderName = bank._AccountHolderName;
                objclsBank.BankAccountID = bank._BankAccountID;
                objclsBank.BankAccountType = bank._BankAccountType;
                objclsBank.BankAddress = bank._BankAddress;
                objclsBank.BankAddress2 = bank._BankAddress2;
                objclsBank.BankCity = bank._BankCity;
                objclsBank.BankCountryID = bank._BankCountryID;
                objclsBank.BankFax = bank._BankFax;
                objclsBank.BankIFSCCode = bank._BankIFSCCode;
                objclsBank.BankID = bank._BankID;
                objclsBank.BankName = bank._BankName;
                objclsBank.BankPhone = bank._BankPhone;
                objclsBank.BankSwiftCode = bank._BankSwiftCode;
                objclsBank.BankZipCode = bank._BankZipCode;
                objclsBank.ClientID = bank._ClientID;

                //if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsBank = clsProxyClassManager.INSTANCE.UpdateBank(objclsBank);
                }

                if (objclsBank.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        objclsBrokerOpLog.OperationName = "Bank details edited";//_mode.ToString();
                        //objclsBrokerOpLog.ControlName = "Clients-Accounts Tab";
                        objclsBrokerOpLog.Message = "Edited Bank details of ClientID : " + objclsBank.ClientID + " Bank AccountID:" + objclsBank.BankAccountID + ".";
                            //" Bank Name :" + objclsBank.BankName + " Account Type :" + objclsBank.BankAccountType + " Bank Address :" + objclsBank.BankAddress;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    nTabControl1.TabPages[2].Enabled = true;

                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessBankData, objclsBank);
                }
                else if (objclsBank.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in UpdateBankAccount()");
            }
        }

        private void ui_ndgvBankAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ui_nbtnAddTradeAccount_Click(object sender, EventArgs e)
        {
            ValidateAddTradeAccounts();
        }

        private void ui_ndgvAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        /// <summary>
        /// Validation account info
        /// </summary>
        private void ValidateAddTradeAccounts()
        {
            if (ui_ndgvAccounts.Rows.Count>=1)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("A new account can not be created because You have already created a trading account.", "Input Error", true);                
                return;
            }
            
            if (ui_ncmbLeverage.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select leverage.", "Input Error", true);
                ui_ncmbLeverage.Focus();
                return;
            }
            if (ui_ncmbCurrency.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Currency.", "Input Error", true);
                ui_ncmbCurrency.Focus();
                return;
            }
            if (ui_ncmbBankAccounts.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Bank Account.", "Input Error", true);
                ui_ncmbBankAccounts.Focus();
                return;
            }
            //if (ui_ncmbLPName.Text == string.Empty)
            //{
            //    DialogResult result = clsDialogBox.ShowErrorBox("Please select LP Name.", "Input Error", true);
            //    ui_ncmbLPName.Focus();
            //    return;
            //}

            //if (ui_ncmbLPAccounts.SelectedItem == null)
            //{
            //    clsDialogBox.ShowErrorBox("Please select LPAccountID.", "Input Error", true);
            //    ui_ncmbLPAccounts.Focus();
            //    return;
            //}

            if (ui_ncmbAccounType.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Please select Account Type.", "Input Error", true);
                ui_ncmbAccounType.Focus();
                return;
            }


            AddTradeAccounts();
        }
        private void ui_ntxtAge_TextChanged(object sender, EventArgs e)
        {
            //ui_ndtpDOB.Value = Convert.ToDateTime(ui_ndtpRegDate.Value.Day.ToString() + "/" + ui_ndtpRegDate.Value.Month.ToString() + "/" + Convert.ToString(ui_ndtpRegDate.Value.Year - Convert.ToInt32(ui_ntxtAge.Text)));
        }

        private void ui_ndtpDOB_ValueChanged(object sender, EventArgs e)
        {

            //ui_ntxtAge.Enabled = false;
            //DateTime now = DateTime.Today;
            //int bDay = clsUtility.GetDate(ui_ndtpDOB.Text).Year;
            //int age = now.Year - bDay;
            //ui_ntxtAge.Text = age.ToString();
            // ui_ntxtAge.Text = Convert.ToString(ui_ndtpRegDate.Value.Year - Convert.ToInt32(ui_ntxtAge.Text));
        }

        private void ui_ndgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvAccounts.Rows.Count == 0)
            {
                return;
            }
            if (ui_ndgvAccounts.Columns[e.ColumnIndex].Name == "AccountEditCol" && e.RowIndex > -1)
            {
                Account acc = new Account();
                DS4Account.dtAccountsRow _accRow = clsAccountManager.INSTANCE._DS4Account.dtAccounts.FindByPK_AccountId(Convert.ToInt32(ui_ndgvAccounts.Rows[e.RowIndex].Cells["PK_AccountId"].Value.ToString()));
                acc._AccountGroupId = _accRow.FK_AccountGroupID;
                acc._AccountId = _accRow.PK_AccountId;
                acc._Balence = _accRow.Balance;
                acc._BuySideTurnOver = _accRow.BuySideTurnOver;
                acc._ClientId = _accRow.ClientID;
                acc._CurrencyId = _accRow.FK_Currency;
                acc._Deleted = _accRow.Deleted;
                acc._Equity = _accRow.Equity;
                acc._IsHedgingAllowed = _accRow.IsHedgingAllowed;
                acc._IsTradeEnable = _accRow.IsTradeEnable;
                acc._LeverageId = _accRow.FK_Leverage;
                acc._RelatedBankId = _accRow.FK_BankID;
                acc._SellSideTurnOver = _accRow.SellSideTurnOver;
                acc._UsedMargin = _accRow.UsedMargin;
                acc._HedgeTypeID = _accRow.HedgeTypeID;
                if (_accRow.IsLive.Trim().ToUpper() == "LIVE")
                {
                    acc._IsLive = true;
                }
                else if (_accRow.IsLive.Trim().ToUpper() == "DEMO")
                {
                    acc._IsLive = false;
                }                
                EditTradeAccount(acc);
            }
        }

        private void EditTradeAccount(Account acc)
        {
            //Forms.frmCommonContainer frmUpdateTradeAccount = new BOADMIN_NEW.Forms.frmCommonContainer();
            uctlEditAccountDetail objEditAccountDetail = new uctlEditAccountDetail();
            objEditAccountDetail._AccountToUpdate = acc;
            objEditAccountDetail.OnTradeAccountUpdate += new Action<Account>(objEditAccountDetail_OnTradeAccountUpdate); ;
            objEditAccountDetail.InitControls();
            //objEditAccountDetail.Dock = DockStyle.Fill;
            //frmUpdateTradeAccount.AcceptButton = objEditAccountDetail.ui_nbtnUpdateTradeAccount;
            //frmUpdateTradeAccount.ClientSize = objEditAccountDetail.Size;
            //frmUpdateTradeAccount.Controls.Add(objEditAccountDetail);
            //frmUpdateTradeAccount.ShowDialog();
            //frmUpdateTradeAccount.Close();
            objEditAccountDetail._ContainerCaption = "Edit Trade Account";
            objEditAccountDetail.ShowDialog();
        }

        void objEditAccountDetail_OnTradeAccountUpdate(Account acc)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountPersonal : Enter objEditAccountDetail_OnTradeAccountUpdate()");
                const string errorMsg = "Error in inserting client AccountInfo";
                clsAccount objclsAccount = new clsAccount();
                objclsAccount.AccountGroupId = acc._AccountGroupId;
                objclsAccount.AccountId = acc._AccountId;
                objclsAccount.IsLive = acc._IsLive;
                objclsAccount.Balence = acc._Balence;
                objclsAccount.ClientId = acc._ClientId;
                objclsAccount.CurrencyId = acc._CurrencyId;
                objclsAccount.Deleted = acc._Deleted;
                objclsAccount.Equity = acc._Equity;
                objclsAccount.IsHedgingAllowed = acc._IsHedgingAllowed;
                objclsAccount.IsTradeEnable = acc._IsTradeEnable;
                objclsAccount.SellSideTurnOver = acc._SellSideTurnOver;
                objclsAccount.BuySideTurnOver = acc._BuySideTurnOver;
                objclsAccount.LeverageId = acc._LeverageId;
                objclsAccount.UsedMargin = acc._UsedMargin;
                objclsAccount.RelatedBankId = (int)acc._RelatedBankId;
                objclsAccount.PaymentDate = acc._PaymentDate;
                objclsAccount.PaymentAmount = acc._PaymentAmount;
                objclsAccount.PaymentMode = acc._PaymentMode;
                objclsAccount.PaymentType = acc._PaymentType;
                objclsAccount.ChequeFdNo = acc._ChequeFDNo;
                objclsAccount.HedgeTypeID = acc._HedgeTypeID;
                //if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objclsAccount = clsProxyClassManager.INSTANCE.UpdateAccount(objclsAccount, AccountOpType.ACCOUNT);
                }
                if (objclsAccount.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        objclsBrokerOpLog.OperationName = "Account details edited";
                        //objclsBrokerOpLog.ControlName = "Clients-Accounts Tab";
                        objclsBrokerOpLog.Message = "Edited Account details of ClientID : " + objclsAccount.ClientId + " AccountID : " + objclsAccount.AccountId + ".";
                            //+ " PaymentType :" + objclsAccount.PaymentType + " PaymentAmount :" + objclsAccount.PaymentAmount + " Balance :" + objclsAccount.Balence +
                            //" Trade Enable :" + objclsAccount.IsTradeEnable + " Leverage :" + objclsAccount.LeverageId;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessAccountData, objclsAccount);
                }
                else if (objclsAccount.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountPersonal =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in objEditAccountDetail_OnTradeAccountUpdate()");
            }
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

        private void ui_ntxtBankFaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtfaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtSecondaryPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ui_ntxtBuySideTurnOver_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPressHandler(ui_ntxtBuySideTurnOver.Text, e, clsEnums.TextType.Real, 18, 2);
        }

        private void ui_ntxtSellSideTurnOver_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPressHandler(ui_ntxtSellSideTurnOver.Text, e, clsEnums.TextType.Real, 18, 2);
        }

        private void ui_ndtpDOB_Leave(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_ndtpDOB.Text) > DateTime.Today)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter valid DOB.", "Input Error", true);
                ui_ndtpDOB.Focus();
                return;
            }
        }

        private void ui_ntxtBankAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ui_ntxtCity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ui_ncmbLPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbLPAccounts.Items.Clear();
            if (ui_ncmbGroup.SelectedItem != null)
            {
                ui_ncmbLPAccounts.Items.AddRange(clsTradingGatewayManager.INSTANCE.GetLPAccountList(clsMasterInfoManager.INSTANCE.GetLPID(ui_ncmbLPName.SelectedItem.ToString())).ToArray());
            }
            ui_ncmbLPAccounts.Items.Insert(0, "");
        }

        private void ui_ncmbClientAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbClientAccountType.SelectedItem != null && ui_ncmbClientAccountType.SelectedItem.ToString() == "Market Maker")
            {
                ui_ntxtMarkupValue.Enabled = true;
            }
            else
            {
                ui_ntxtMarkupValue.Text = string.Empty;
                ui_ntxtMarkupValue.Enabled = false;
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

        private void ui_ncmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ntxtCountry.Text = ui_ncmbCountry.SelectedItem.ToString();
        }

        private void ui_ncmbCountry_Click(object sender, EventArgs e)
        {
            //ui_ncmbCountry.SetItemsAsAutoCompleteSource();

            //List<string> lst = new List<string>();
            //foreach (NListBoxItem item in ui_ncmbCountry.Items)
            //{
            //    lst.Add(item.Text);
            //}
            //int i = 0;
            //foreach (string item in lst)
            //{
            //    if (item.ToLower().StartsWith(ui_ncmbCountry.Text.ToLower()))
            //    {
            //        ui_ncmbCountry.SelectedItem = item;
            //        i++;
            //        //ui_ncmbTax.DropDownItems = i;
            //        return;
            //        //i++;
            //    }
            //}
        }

        private void ui_ncmbNationality_Click(object sender, EventArgs e)
        {

        }

        private void ui_ncmbBankCountry_Click(object sender, EventArgs e)
        {

        }

        private void ui_ncmbBrokerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbGroup.Items.Clear();
            if (ui_ncmbBrokerType.SelectedItem.ToString().Trim() == clsBrokerManager.INSTANCE.GetBrokerType(clsGlobal.BrokerID).Trim())
            {
                ui_ncmbGroup.Items.Add(clsGlobal.BrokerCompany);
                return;
            }

            if (ui_ncmbBrokerType.SelectedItem.ToString().Trim() == "All")
            {
                this.UpdateBrokerItems(null);
            }
            else
            {
                foreach (string item in clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()))
                {
                    if (clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.Contains(item)) //&& clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(
                    //clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(item)))
                    {
                        if (!ui_ncmbGroup.Items.Contains(item))
                        {
                            ui_ncmbGroup.Items.Add(item);
                        }
                    }
                }
                // ui_ncmbGroup.Items.AddRange(clsAccountManager.INSTANCE.GetParentBrokersForClient(ui_ncmbBrokerType.SelectedItem.ToString().Trim()).ToArray());//GetGroupNamesByBrokerType(ui_ncmbBrokerType.SelectedItem.ToString().Trim()).ToArray());
                //ui_ncmbGroup.Items.Add(clsGlobal.BrokerCompany);
            }
        }

        private void ui_ncmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbGroup.SelectedItem != null)
            {
                string str = clsAccountManager.INSTANCE.GetBrokerTypeByCompanyName(ui_ncmbGroup.SelectedItem.ToString().Trim());//.GetBrokerTypeByBrokerName(ui_ncmbGroup.SelectedItem.ToString()).Trim();
                ui_ncmbBrokerType.Text = str;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtNationality_KeyUp(object sender, KeyEventArgs e)
        {
            ui_ncmbNationality.SetItemsAsAutoCompleteSource();

            List<string> lst = new List<string>();
            foreach (NListBoxItem item in ui_ncmbNationality.Items)
            {
                lst.Add(item.Text);
            }
            int i = 0;
            foreach (string item in lst)
            {
                if (item.ToLower().StartsWith(ui_ntxtNationality.Text.ToLower()))
                {
                    ui_ncmbNationality.SelectedItem = item;
                    i++;
                    ui_ncmbNationality.DropDownItems = 7;
                    ui_ncmbNationality.DropDown();
                    ui_ntxtNationality.Text = item.ToString();
                    return;
                    //i++;
                }
            }
        }

        private void ui_ntxtCountry_KeyUp(object sender, KeyEventArgs e)
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
                    ui_ntxtCountry.Text = item.ToString();
                    return;
                    //i++;
                }
            }
        }

        private void ui_ntxtBankCountry_KeyUp(object sender, KeyEventArgs e)
        {
            ui_ncmbBankCountry.SetItemsAsAutoCompleteSource();

            List<string> lst = new List<string>();
            foreach (NListBoxItem item in ui_ncmbBankCountry.Items)
            {
                lst.Add(item.Text);
            }
            int i = 0;
            foreach (string item in lst)
            {
                if (item.ToLower().StartsWith(ui_ntxtBankCountry.Text.ToLower()))
                {
                    ui_ncmbBankCountry.SelectedItem = item;
                    i++;
                    ui_ncmbBankCountry.DropDownItems = 7;
                    ui_ncmbBankCountry.DropDown();
                    ui_ntxtBankCountry.Text = item.ToString();
                    return;
                    //i++;
                }
            }
        }

        private void ui_ncmbBankCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ntxtBankCountry.Text = ui_ncmbBankCountry.SelectedItem.ToString();
        }

        private void ui_ncmbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ntxtNationality.Text = ui_ncmbNationality.SelectedItem.ToString();
        }

        private void ui_nbtnDOB_Click(object sender, EventArgs e)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = this.ui_ndtpDOB.Width - 10;
            Int32 y = this.ui_ndtpDOB.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(ui_ndtpDOB.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(ui_ndtpDOB.Handle, WM_LBUTTONUP, 1, lParam);
        }

        private void ui_nchkHedgingAllowed_CheckedChanged(object sender, EventArgs e)
        {
            ui_ncmbHedgeType.Enabled = ui_nchkHedgingAllowed.Checked;
        }
    }
}
