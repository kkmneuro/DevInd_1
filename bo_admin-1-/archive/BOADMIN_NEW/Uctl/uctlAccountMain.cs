using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOADMIN_NEW.Cls;
using System.Collections.Generic;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Client main class
    /// </summary>
    public partial class uctlAccountMain : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS
        public const string strNewAccount_ = "New Account";
        public const string strEditAccount_ = "Edit Account";
        public const string strDeleteAccount_ = "Delete Account";
        public const string strGroupOperations_ = "Group Operations";
        public const string strFind_ = "Find";
        public const string strFindNext_ = "Find Next";
        int _iCurrRowIndex = -1;
        public bool _isEditable = false;

        #endregion MEMBERS

        public uctlAccountMain()
        {
            InitializeComponent();
            clsAccountManager.INSTANCE._DS4Account.dtClientInfo.RowDeleted += dtAccount_RowDeleted;
            clsAccountManager.INSTANCE._DS4Account.dtClientInfo.RowChanged += dtClientInfo_RowChanged;
            clsAccountManager.INSTANCE._DS4Account.dtClientInfo.TableNewRow += dtAccount_TableNewRow;
        }

        void dtClientInfo_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }
        void RefreshMe()
        {
            Action A = () =>
            {
                if (ui_dtgAccounts.Rows.Count > 0)
                {
                    //ui_ndtgOrders.Rows[ui_ndtgOrders.Rows.Count - 1].Selected = true;
                    //ui_dtgAccounts.FirstDisplayedScrollingRowIndex = ui_dtgAccounts.Rows.Count - 1;
                }

                ui_dtgAccounts.ScrollBars = ScrollBars.Both;
            };
            if (ui_dtgAccounts.InvokeRequired)
            {
                ui_dtgAccounts.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }
        void dtAccount_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }



        void dtAccount_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        #region IUserCtrl Members

        public void Init()
        {

            ui_dtgAccounts.DataSource = clsAccountManager.INSTANCE._DS4Account.dtClientInfo;
            HideColumns();
            StyleParticipantsGrid();

        }


        private void HideColumns()
        {
            foreach (DataGridViewColumn dc in ui_dtgAccounts.Columns)
            {
                dc.Visible = false;
            }
        }
        /// <summary>
        /// styles grid
        /// </summary>
        private void StyleParticipantsGrid()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountMain : Enter StyleParticipantsGrid()");
                ui_dtgAccounts.RowHeadersVisible = false;
                ui_dtgAccounts.Columns["ClientId"].ReadOnly = true;
                ui_dtgAccounts.Columns["ClientId"].HeaderText = "Client ID";
                ui_dtgAccounts.Columns["FirstName"].ReadOnly = true;
                ui_dtgAccounts.Columns["LastName"].ReadOnly = true;
                ui_dtgAccounts.Columns["MidleName"].ReadOnly = true;
                ui_dtgAccounts.Columns["Address1"].ReadOnly = true;
                ui_dtgAccounts.Columns["Address2"].ReadOnly = true;
                ui_dtgAccounts.Columns["Zone"].ReadOnly = true;
                ui_dtgAccounts.Columns["District"].ReadOnly = true;
                ui_dtgAccounts.Columns["Zip"].ReadOnly = true;
                ui_dtgAccounts.Columns["FaxNumber"].ReadOnly = true;
                ui_dtgAccounts.Columns["Mobile"].ReadOnly = true;
                ui_dtgAccounts.Columns["PassportId"].ReadOnly = true;
                ui_dtgAccounts.Columns["Country"].ReadOnly = true;
                ui_dtgAccounts.Columns["AccountGroupID"].ReadOnly = true;
                ui_dtgAccounts.Columns["AccountGroupType"].ReadOnly = true;

                ui_dtgAccounts.Columns["ClientId"].Visible = true;
                ui_dtgAccounts.Columns["FirstName"].Visible = true;
                ui_dtgAccounts.Columns["LastName"].Visible = true;
                ui_dtgAccounts.Columns["MidleName"].Visible = true;
                ui_dtgAccounts.Columns["Address1"].Visible = true;
                ui_dtgAccounts.Columns["Address2"].Visible = true;
                ui_dtgAccounts.Columns["Zone"].Visible = true;
                ui_dtgAccounts.Columns["District"].Visible = true;
                ui_dtgAccounts.Columns["Zip"].Visible = true;
                ui_dtgAccounts.Columns["FaxNumber"].Visible = true;
                ui_dtgAccounts.Columns["Mobile"].Visible = true;
                ui_dtgAccounts.Columns["PassportId"].Visible = true;
                ui_dtgAccounts.Columns["Country"].Visible = true;
                ui_dtgAccounts.Columns["AccountGroupType"].Visible = true;
                ui_dtgAccounts.Columns["AccountGroupID"].Visible = true;
                ui_dtgAccounts.Columns["AccountGroupID"].DisplayIndex = 5;
                ui_dtgAccounts.Columns["AccountGroupType"].DisplayIndex = 6;
                ui_dtgAccounts.Columns["AccountGroupID"].HeaderText = "Account Group ID";
                ui_dtgAccounts.Columns["AccountGroupType"].HeaderText = "Account Group Type";
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in StyleParticipantsGrid()");
            }
        }

        public void InitControls()
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion
        /// <summary>
        /// Trigers when seach in grid happens
        /// </summary>
        /// Note: parameters cientid,clientname,accountGroup,clienttype,registrationdaterange
        public void HandleSearch(string[] parameters)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountMain : Enter HandleSearch()");
                StringBuilder Query = new StringBuilder();
                if (parameters[0] != null && !string.IsNullOrEmpty(parameters[0]))
                    Query.Append(" and ClientID =" + parameters[0]);
                if (parameters[1] != null && !string.IsNullOrEmpty(parameters[1]))
                    Query.Append(" and FirstName Like '" + parameters[1] + "%' ");
                if (parameters[2] != null && Convert.ToInt32(parameters[2].ToString()) > 0)
                    Query.Append(" and  AccountGroupID =" + parameters[2]);
                if (parameters[3] != null && Convert.ToInt32(parameters[3].ToString()) > 0)
                    Query.Append(" and ParticipantType =" + parameters[3]);//
                if (Query.Length > 0)
                    Query.Remove(0, 4);
                //Query.Append(" and RegistrationDate >='" +Convert.ToDateTime(parameters[4].ToString())+"' and RegistrationDate <='" +Convert.ToDateTime(parameters[4].ToString())+ "'");
                ui_dtgAccounts.DataSource = clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select(Query.ToString());
                HideColumns();
                StyleParticipantsGrid();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in HandleSearch()");
            }
        }

        public void HandleClientSearchData(string brokerType, string brokerId)
        {
            string searchStr = string.Empty;
            if (brokerType != string.Empty && brokerId != string.Empty)
            {
                searchStr = "AccountGroupType='" + brokerType + "',AccountGroupID=" + Convert.ToInt32(brokerId);
            }
            else if (brokerType != string.Empty && brokerId == string.Empty)
            {
                searchStr = "AccountGroupType='" + brokerType + "'";
            }
            else if (brokerType == string.Empty && brokerId != string.Empty)
            {
                searchStr = "AccountGroupID=" + Convert.ToInt32(brokerId);
            }
            ui_dtgAccounts.DataSource = clsAccountManager.INSTANCE._DS4Account.dtClientInfo.Select(searchStr);
            HideColumns();
            StyleParticipantsGrid();
        }


        private void EditAccount()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlAccountMain : Enter EditAccount()");
                // Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
                uctlAccountPersonal objectAccountPersonal = new uctlAccountPersonal();
                objectAccountPersonal._mode = clsEnums.FRM_MODE.EDIT;
                bool isRowClick = !(_iCurrRowIndex < 0);
                if (isRowClick)
                {
                    string strSymbolColumn = (clsAccountManager.INSTANCE._DS4Account.dtClientInfo.ClientIdColumn.ColumnName);
                    if (ui_dtgAccounts.Rows[_iCurrRowIndex].Cells[strSymbolColumn].Value == null)
                    {
                        return;
                    }
                    int id = (int)ui_dtgAccounts.Rows[_iCurrRowIndex].Cells[strSymbolColumn].Value;
                    objectAccountPersonal._ClientRow = clsAccountManager.INSTANCE._DS4Account.dtClientInfo.FindByClientId(id);
                    clsAccountManager.INSTANCE.FillDataToBankDataSet(clsProxyClassManager.INSTANCE.GetBankRecords(id));
                    objectAccountPersonal._BankAccounts = clsAccountManager.INSTANCE.GetBankAccounts(id);
                    objectAccountPersonal._ClientId = id;
                }
                ////  objfrmCommonContainer.Controls.Clear();
                objectAccountPersonal.InitControls();
                objectAccountPersonal._ContainerCaption = "Edit Account";
                objectAccountPersonal.ShowDialog();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlAccountMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditAccount()");
            }
        }

        private void AddNewAccount()
        {
            // Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            Uctl.uctlAccountPersonal objectAccountPersonal = new BOADMIN_NEW.Uctl.uctlAccountPersonal();
            objectAccountPersonal._mode = clsEnums.FRM_MODE.ADD;
            //objfrmCommonContainer.Controls.Clear();
            objectAccountPersonal.InitControls();
            objectAccountPersonal._ContainerCaption = "Add New Account";
            objectAccountPersonal.ShowDialog();
        }


        private void ui_dtgAccounts_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_dtgAccounts.Rows.Count == 0)
            {
                ui_contextmnuCommon.Items[1].Enabled = false;
                _isEditable = false;
                ui_contextmnuCommon.Items[2].Enabled = false;
                return;
            }
            DataGridView.HitTestInfo hitinfo = ui_dtgAccounts.HitTest(e.X, e.Y);
            _iCurrRowIndex = hitinfo.RowIndex;
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (_iCurrRowIndex < 0)
                {
                    ui_contextmnuCommon.Items[1].Enabled = false;
                    ui_contextmnuCommon.Items[2].Enabled = false;
                }
                else
                {
                    ui_dtgAccounts.Rows[_iCurrRowIndex].Selected = true;
                    ui_contextmnuCommon.Items[1].Enabled = true;
                    ui_contextmnuCommon.Items[2].Enabled = true;
                }
            }
        }

        private void ui_contextmnuCommon_Opening(object sender, CancelEventArgs e)
        {

            if (_iCurrRowIndex >= 0)
            {
                if (ui_dtgAccounts.Rows.Count > 1)
                {
                    //ui_contextmnuCommonMoveUp.Enabled = true;
                    //ui_contextmnuCommonMoveDown.Enabled = true;
                }
                ui_contextmnuCommonEditAccount.Enabled = true;
                // ui_contextmnuCommonDeleteAccount.Enabled = true;


            }
            else
            {
                ui_contextmnuCommonEditAccount.Enabled = false;
                // ui_contextmnuCommonDeleteAccount.Enabled = false;

            }

        }

        private void uctlAccountMain_Load(object sender, EventArgs e)
        {
            Init();
            ui_dtgAccounts.Columns["FirstName"].HeaderText = "First Name";
            ui_dtgAccounts.Columns["MidleName"].HeaderText = "Midle Name";
            ui_dtgAccounts.Columns["LastName"].HeaderText = "Last Name";
            ui_dtgAccounts.Columns["Zip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgAccounts.Columns["FaxNumber"].HeaderText = "Fax Number";
            ui_dtgAccounts.Columns["FaxNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgAccounts.Columns["Mobile"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_dtgAccounts.Columns["PassportId"].HeaderText = "Passport ID";
            ui_dtgAccounts.Columns["PassportId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        #region IUserCtrl Members

        void BOADMIN_NEW.Interfaces.IUserCtrl.Init()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.InitControls()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_contextmnuCommonNewAccount_Click(object sender, EventArgs e)
        {
            AddNewAccount();
        }

        private void ui_contextmnuCommonEditAccount_Click(object sender, EventArgs e)
        {
            EditAccount();
        }



        private void ui_dtgAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ui_dtgAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_dtgAccounts.Rows.Count == 0)
            {
                return;
            }
            _iCurrRowIndex = ui_dtgAccounts.CurrentRow.Index;
            if (_iCurrRowIndex == -1)
                return;
            else if (_isEditable == true)
                EditAccount();
        }

    }
}
public class AccountDetails
{
    public string LoginName;
    public string Email;
    public string Balance;
    public string Status;
    public string City;
    public string Group;


}