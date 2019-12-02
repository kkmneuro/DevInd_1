using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Main collateral control
    /// </summary>
    public partial class uctlCollateralMain : UserControl
    {
        public uctlCollateralMain()
        {
            InitializeComponent();

            clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtBrokerCollateralInfo.TableNewRow += new DataTableNewRowEventHandler(dtBrokerCollateralInfo_TableNewRow);
        }
        /// <summary>
        /// Refresh grid on row change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dtBrokerCollateralInfo_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            Action a = () =>
                {
                    ui_ndgvCollateral.ScrollBars = ScrollBars.None;
                    ui_ndgvCollateral.Refresh();

                    if (ui_ndgvCollateral.Rows.Count > 0)
                    {
                        //ui_ndtgOrders.Rows[ui_ndtgOrders.Rows.Count - 1].Selected = true;
                        ui_ndgvCollateral.FirstDisplayedScrollingRowIndex = ui_ndgvCollateral.Rows.Count - 1;
                    }

                    ui_ndgvCollateral.ScrollBars = ScrollBars.Both;
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(a);
            }
            else
            {
                a();
            }
        }
        /// <summary>
        /// Initializes the control elements
        /// </summary>
        public void InitControls()
        {
            ui_ncmbAccountGroupName.Items.Add("-Select-");
            ui_ncmbBrokerTypes.Items.Add("-Select-");
            ui_ncmbAccountGroupName.SelectedIndex = 0;
            ui_ncmbBrokerTypes.SelectedIndex = 0;
            ui_ncmbAccountGroupName.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentNames.ToArray());//clsAccountManager.INSTANCE.GetLessThanAccountGroupdNameArray());
            //ui_ncmbBrokerTypes.Items.AddRange(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray());
            for (int index = Cls.clsGlobal.BrokerID; index < Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray().Count(); index++)
            {
                ui_ncmbBrokerTypes.Items.Add(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]);
            }
            ui_ndgvCollateral.DataSource = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtBrokerCollateralInfo;
            HideColumns();
            StyleCollateralGrid();
        }
        string[] SearchParms = new string[4];
        private void ui_ncmbBrokerTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchParms[0] = Convert.ToString(clsBrokerManager.INSTANCE.GetBrokerTypeId(ui_ncmbBrokerTypes.SelectedItem.ToString()));
            HandleSearch(SearchParms);
        }

        private void ui_ncmbAccountGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchParms[1] = Convert.ToString(Cls.clsAccountManager.INSTANCE.GetGroupId(ui_ncmbAccountGroupName.SelectedItem.ToString()));
            HandleSearch(SearchParms);
        }

        private void ui_ntxtParentOwnerName_TextChanged(object sender, EventArgs e)
        {
            if (ui_ntxtParentOwnerName.Text != string.Empty)
            {
                SearchParms[2] = ui_ntxtParentOwnerName.Text;
            }
            else
                SearchParms[2] = null;
            HandleSearch(SearchParms);
        }

        private void ui_ntxtOwnerName_TextChanged(object sender, EventArgs e)
        {
            if (ui_ntxtOwnerName.Text != string.Empty)
            {
                SearchParms[3] = ui_ntxtOwnerName.Text;
            }
            else
                SearchParms[3] = null;
            HandleSearch(SearchParms);
        }

        /// //BrockerTypesId,AccountGroupID,ParentOwner,owner
        public void HandleSearch(string[] parameters)
        {
            StringBuilder query = new StringBuilder();
            if (parameters[0] != null && Convert.ToInt32(parameters[0].ToString()) > 0)
                query.Append(" and FK_BrokerTypeID =" + parameters[0]);
            if (parameters[1] != null && Convert.ToInt32(parameters[1].ToString()) > 0)
                query.Append(" and AccountGroupID =" + parameters[1]);
            if (parameters[2] != null && !string.IsNullOrEmpty(parameters[2]))
                query.Append(" and ParentOwner Like '" + parameters[2] + "%' ");
            if (parameters[3] != null && !string.IsNullOrEmpty(parameters[3]))
                query.Append(" and Owner Like '" + parameters[3] + "%' ");
            if (query.Length > 0)
                query.Remove(0, 4);

            ui_ndgvCollateral.DataSource = Cls.clsCollateralManager.INSTANCE._DS4BrokerCollateralInfo.dtBrokerCollateralInfo.Select(query.ToString());
            HideColumns();
            StyleCollateralGrid();
        }

        /// <summary>
        /// Styles the grid
        /// </summary>
        private void StyleCollateralGrid()
        {
            const int id = (int)clsEnums.CommandIDS.COLLATERAL;
            string x = clsGlobal.Role.Split('_')[id];
            ui_ndgvCollateral.Columns["Edit"].Visible = Convert.ToInt32(x.ToCharArray()[2].ToString()) != 0;

            ui_ndgvCollateral.Columns["GroupName"].Visible = true;
            ui_ndgvCollateral.Columns["ParentOwnerName"].Visible = true;
            ui_ndgvCollateral.Columns["OwnerName"].Visible = true;
            ui_ndgvCollateral.Columns["Leverage"].Visible = true;
            ui_ndgvCollateral.Columns["Leverage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["TotalCollateral"].Visible = true;
            ui_ndgvCollateral.Columns["TotalCollateral"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["Unallocated"].Visible = true;
            ui_ndgvCollateral.Columns["Unallocated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["Utilized"].Visible = true;
            ui_ndgvCollateral.Columns["Utilized"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["PayInShortage"].Visible = true;
            ui_ndgvCollateral.Columns["PayInShortage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["PayOutShortage"].Visible = true;
            ui_ndgvCollateral.Columns["PayOutShortage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCollateral.Columns["CollateralforTrading"].Visible = true;
            ui_ndgvCollateral.Columns["CollateralforTrading"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ui_ndgvCollateral.Columns["GroupName"].ReadOnly = true;
            ui_ndgvCollateral.Columns["ParentOwnerName"].ReadOnly = true;
            ui_ndgvCollateral.Columns["OwnerName"].ReadOnly = true;
            ui_ndgvCollateral.Columns["Leverage"].ReadOnly = true;
            ui_ndgvCollateral.Columns["TotalCollateral"].ReadOnly = true;
            ui_ndgvCollateral.Columns["Unallocated"].ReadOnly = true;
            ui_ndgvCollateral.Columns["Utilized"].ReadOnly = true;
            ui_ndgvCollateral.Columns["PayInShortage"].ReadOnly = true;
            ui_ndgvCollateral.Columns["PayOutShortage"].ReadOnly = true;
            ui_ndgvCollateral.Columns["CollateralforTrading"].ReadOnly = true;
        }

        private void HideColumns()
        {
            foreach (DataGridViewColumn dc in ui_ndgvCollateral.Columns)
            {
                dc.Visible = false;
            }
        }

        private void ui_ndgvCollateral_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvCollateral.Rows.Count == 0)
            {
                return;
            }
            if (ui_ndgvCollateral.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex > -1)
            {
                EditBrockersColateralInfo(Convert.ToInt32(ui_ndgvCollateral.Rows[e.RowIndex].Cells["AccountGroupID"].Value.ToString()));

            }
        }

        /// <summary>
        /// Edits brokers collateral information
        /// </summary>
        /// <param name="accountGroupId"></param>
        private void EditBrockersColateralInfo(int accountGroupId)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCollateralMain : Enter EditBrockersColateralInfo()");
                Forms.frmCommonContainer frmUpdateBankAccount = new Forms.frmCommonContainer();
                uctlEditBrokersCollateralInfo objEditBrokersCollateralInfo = new uctlEditBrokersCollateralInfo
                                                                                 {_AccountGroupID = accountGroupId};
                frmUpdateBankAccount.Text = "Edit Collateral - " + accountGroupId;
                objEditBrokersCollateralInfo.InitControls();
                objEditBrokersCollateralInfo.Dock = DockStyle.Fill;
                frmUpdateBankAccount.ClientSize = objEditBrokersCollateralInfo.Size;
                frmUpdateBankAccount.Controls.Add(objEditBrokersCollateralInfo);

                frmUpdateBankAccount.ShowDialog();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCollateralMain =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditBrockersColateralInfo()");
            }
        }

        private void ui_ndgvCollateral_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}
