using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
using System.Reflection;
using BOADMIN_NEW.Forms;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Broker class
    /// </summary>
    public partial class uctlBrokers : UserControl, Interfaces.IUserCtrl
    {
        int _iCurrRowIndex = -1;
        uctlBrokersChild _objuctlBrokersChild;
        DS.DS4BrokerNameFilter _DS4BrokerNameFilter = new DS.DS4BrokerNameFilter();
        private bool _isEditable = false;

        public uctlBrokers()
        {
            DoubleBuffered = true;
            InitializeComponent();
            SetDoubleBuffered(true);
            //Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.RowDeleted += new DataRowChangeEventHandler(dtBrokers_RowDeleted);
            Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.TableNewRow += dtBrokers_TableNewRow;
            //Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.RowChanged += new DataRowChangeEventHandler(dtBrokers_RowChanged);

            Cls.clsBrokersManagerHandler.INSTANCE.OnChargesRowRemove += INSTANCE_OnChargesRowRemove;
        }

        void INSTANCE_OnChargesRowRemove(int brokerGroupId, int chargesId)
        {
            _objuctlBrokersChild.OnChargesRowRemove(brokerGroupId, chargesId);
        }

/*
        void dtBrokers_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
            SetBrokerColor((((clsInterface4OME.DSBO.DS4Brokers.dtBrokersDataTable)(sender))).Rows.IndexOf(e.Row), e.Row);
        }
*/

        public void SetDoubleBuffered(bool flag)
        {
            Type type = ui_ndgvBrokers.GetType();
            PropertyInfo pInfo = type.GetProperty("DoubleBuffered",BindingFlags.Instance|BindingFlags.NonPublic);
            pInfo.SetValue(ui_ndgvBrokers, flag, null);
        }
        /// <summary>
        /// sets broker color
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="row"></param>
        private void SetBrokerColor(int rowIndex, DataRow row)
        {
            Action a = () =>
            {
                if (Convert.ToBoolean(row.ItemArray[4]) == false)
                {
                    if (ui_ndgvBrokers.Rows.Count > 0)
                    {
                        foreach (DataGridViewCell cell in ui_ndgvBrokers.Rows[rowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.Yellow;
                        }
                    }
                }
                else
                {
                    if (ui_ndgvBrokers.Rows.Count > 0)
                    {
                        foreach (DataGridViewCell cell in ui_ndgvBrokers.Rows[rowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.White;
                        }
                    }
                }
                ui_ndgvBrokers.Refresh();
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

        void dtBrokers_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
            if (e.Row.ItemArray[0].ToString() != string.Empty)
            {
                SetBrokerColor((((clsInterface4OME.DSBO.DS4Brokers.dtBrokersDataTable)(sender))).Rows.IndexOf(e.Row), e.Row);
            }
            RefreshComboBox();
        }

        public void RefreshComboBox()
        {
            Action a = () =>
            {
                ui_ncmbBrokerName.Items.Clear();
                ui_ncmbBrokerName.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.ToArray());//clsAccountManager.INSTANCE.GetParentBrokers("All").ToArray());
                //ui_ncmbBrokerName.Items.Add(clsGlobal.BrokerCompany);
                ui_ncmbBrokerName.Items.Insert(0, "All");
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

        void RefreshMe()
        {
            Action a = () =>
            {
                //ui_ndgvBrokers.DataSource = Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers;
                ui_ndgvBrokers.ScrollBars = ScrollBars.None;
                ui_ndgvBrokers.Refresh();

                if (ui_ndgvBrokers.Rows.Count > 0)
                {
                    //ui_ndtgOrders.Rows[ui_ndtgOrders.Rows.Count - 1].Selected = true;
                    ui_ndgvBrokers.FirstDisplayedScrollingRowIndex = ui_ndgvBrokers.Rows.Count - 1;
                }

                ui_ndgvBrokers.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndgvBrokers.InvokeRequired)
            {
                ui_ndgvBrokers.BeginInvoke(a);

            }
            else
            {
                a();
            }
        }

        #region IUserCtrl Members

        public void Init()
        {
            lock (ui_ndgvBrokers)
            {
                ui_ndgvBrokers.DataSource = Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers;

                ui_ndgvBrokers.Columns["Owner"].DisplayIndex = 0;
                ui_ndgvBrokers.Columns["BrokersID"].DisplayIndex = 1;
                ui_ndgvBrokers.Columns["BrokerType"].DisplayIndex = 2;
                ui_ndgvBrokers.Columns["ParentBrokerID"].HeaderText = "Parent Broker";
                ui_ndgvBrokers.Columns["ParentBrokerID"].DisplayIndex = 3;
                //ui_ndgvBrokers.Columns["BrokersID"].Visible = false;
                //ui_ndgvBrokers.Columns["BrokerName"].Visible = false;
                //ui_ndgvBrokers.Columns["CompanyName"].Visible = false;
                ui_ndgvBrokers.Columns["Enable"].Visible = false;
                //ui_ndgvBrokers.Columns["BrokerType"].Visible = false;
                ui_ndgvBrokers.Columns["Address"].Visible = false;
                ui_ndgvBrokers.Columns["Zone"].Visible = false;
                ui_ndgvBrokers.Columns["Phone1"].Visible = false;
                ui_ndgvBrokers.Columns["Phone2"].Visible = false;
                ui_ndgvBrokers.Columns["Fax"].Visible = false;
                ui_ndgvBrokers.Columns["Email"].Visible = false;
                ui_ndgvBrokers.Columns["Margin_Call_Level1"].Visible = false;
                ui_ndgvBrokers.Columns["Margin_Call_Level2"].Visible = false;
                ui_ndgvBrokers.Columns["Margin_Call_Level3"].Visible = false;
                ui_ndgvBrokers.Columns["News"].Visible = false;
                ui_ndgvBrokers.Columns["MaximumOrders"].Visible = false;
                ui_ndgvBrokers.Columns["MaximumSymbols"].Visible = false;
            }
            const int id = (int)clsEnums.CommandIDS.BROKER;
            if (clsGlobal.Role == string.Empty) return;
            string x = clsGlobal.Role.Split('_')[id];
            ui_cmsBrokers.Items[0].Visible = Convert.ToInt32(x.ToCharArray()[1].ToString()) != 0;
            if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            {
                ui_cmsBrokers.Items[1].Visible = false;
                _isEditable = false;
            }
            else
            {
                ui_cmsBrokers.Items[1].Visible = true;
                _isEditable = true;
            }
        }

        public void InitControls()
        {
            ui_ncmbBrokerName.Items.Clear();
            ui_ncmbBrokerType.Items.Clear();
            ui_ncmbBrokerName.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.ToArray());//clsAccountManager.INSTANCE.GetParentBrokers("All").ToArray());
            //ui_ncmbBrokerName.Items.Add(clsGlobal.BrokerCompany);
            //ui_ncmbBrokerType.Items.AddRange(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray());//commented by vijay on 22 April
            for (int index = clsGlobal.BrokerID; index < Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray().Count(); index++)
            {
                if (!ui_ncmbBrokerType.Items.Contains(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]))
                {
                    ui_ncmbBrokerType.Items.Add(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]);
                }
            }
            ui_ncmbBrokerName.Items.Insert(0, "All");
            ui_ncmbBrokerType.Items.Insert(0, "All");
        }

        public void SaveMe()
        {

        }

        #endregion

        private void ui_mnuAdd_Click(object sender, EventArgs e)
        {
            AddMenuHandler();
        }

        private void AddMenuHandler()
        {
            DisplayBrokersDialog(DialogType.AddContract, "Add Broker");
        }

        private void ui_mnuEdit_Click(object sender, EventArgs e)
        {
            EditMenuHandler();
        }

        private void EditMenuHandler()
        {
            DisplayBrokersDialog(DialogType.Edit, "Edit Broker");
        }
        /// <summary>
        /// Loads initial broker info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlBrokers_Load(object sender, EventArgs e)
        {
            Init();
            InitControls();
            ui_ncmbBrokerIds.Items.Clear();
            ui_ncmbBrokerIds.Items.AddRange(clsAccountManager.INSTANCE.GetBrokerIDs());
            if(ui_ncmbBrokerIds.Items.Contains("2"))
            {
              ui_ncmbBrokerIds.Items.Remove("2");
            }
            ui_ncmbBrokerIds.Items.Insert(0, "All");
            ui_ncmbBrokerIds.SelectedIndex = 0;
            ui_ncmbBrokerName.SelectedIndex = 0;
            ui_ncmbBrokerType.SelectedIndex = 0;
            var dataGridViewColumn = ui_ndgvBrokers.Columns["Leverage"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var gridViewColumn = ui_ndgvBrokers.Columns["ParentBrokerID"];
            if (gridViewColumn != null)
                gridViewColumn.HeaderText = "Parent Broker ID";
            var viewColumn = ui_ndgvBrokers.Columns["RoleId"];
            if (viewColumn != null) viewColumn.HeaderText = "Role ID";
            var column = ui_ndgvBrokers.Columns["RoleId"];
            if (column != null)
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var dataGridViewColumn1 = ui_ndgvBrokers.Columns["RoleName"];
            if (dataGridViewColumn1 != null) dataGridViewColumn1.HeaderText = "Role Name";
            var gridViewColumn1 = ui_ndgvBrokers.Columns["LoginId"];
            if (gridViewColumn1 != null) gridViewColumn1.HeaderText = "Login ID";
            ui_ndgvBrokers.Columns["BrokerType"].HeaderText = "Broker Type";
            ui_ndgvBrokers.Columns["BrokersID"].HeaderText = "Brokers ID";
            SetDoubleBuffered(true);

            if (clsGlobal.BrokerID == 1)
            {
                ui_mnuChangePassword.Visible = true;
            }
            else
            {
                ui_mnuChangePassword.Visible = false;
            }
        }

        /// <summary>
        /// Displays broker dialog
        /// </summary>
        /// <param name="dialogMode"></param>
        /// <param name="dialogText"></param>
        public void DisplayBrokersDialog(DialogType dialogMode, string dialogText)
        {
            bool isRowClick = !(_iCurrRowIndex < 0);
            _objuctlBrokersChild = new uctlBrokersChild();
            _objuctlBrokersChild.init();
            int id = 0;
            if (isRowClick)
            {

                string strBrokersColumn = (Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers).BrokersIDColumn.Caption;
                if (ui_ndgvBrokers.Rows[_iCurrRowIndex].Cells[strBrokersColumn].Value == null)
                {
                    return;
                }
                id = (int)ui_ndgvBrokers.Rows[_iCurrRowIndex].Cells[strBrokersColumn].Value;
                //objuctlBrokersChild.SetValues(Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers, Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.FindByBrokersID(ID), dialogMode); //commented by vijay on 23 April
            }
            _objuctlBrokersChild.SetValues(Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers, Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.FindByBrokersID(id), dialogMode);  //Added by vijay on 23 April
            //if (!isRowClick && dialogMode == DialogType.AddContract)  //commented by vijay on 23 April
            //{
            //    objuctlBrokersChild.AddColumnsToSymbolGrid();
            //    objuctlBrokersChild.AddSymbolsToSymbolGrid();
            //}
            DS4Brokers.dtBrokersRow brokersRow = Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.FindByBrokersID(id);
            Forms.frmCommonContainer objfrmCommonContainer = new Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.Size = new Size(_objuctlBrokersChild.Width + 35, _objuctlBrokersChild.Height + 55);


            _objuctlBrokersChild.Dock = DockStyle.Fill;
            objfrmCommonContainer.Text = dialogText;
            objfrmCommonContainer.Controls.Add(_objuctlBrokersChild);
            objfrmCommonContainer.ShowDialog();
        }
        /// <summary>
        /// Handles mouse down button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvBrokers_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_ndgvBrokers.Rows.Count == 0)
            {
                ui_cmsBrokers.Items[1].Enabled = false;
                return;
            }
            DataGridView.HitTestInfo hitinfo = ui_ndgvBrokers.HitTest(e.X, e.Y);
            _iCurrRowIndex = hitinfo.RowIndex;
            if (e.Button != MouseButtons.Right || e.Clicks != 1) return;
            if (_iCurrRowIndex < 0)
            {
                ui_cmsBrokers.Items[1].Enabled = false;
            }
            else
            {
                ui_ndgvBrokers.Rows[_iCurrRowIndex].Selected = true;
                ui_cmsBrokers.Items[1].Enabled = true;
            }
        }
        /// <summary>
        /// Handles selected index changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbBrokerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerName.Text == "All")
            {
                ui_ndgvBrokers.DataSource = clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers;
                return;
            }

            DS4Brokers.dtBrokersRow row = clsBrokersManagerHandler.INSTANCE.GetBrokerData(ui_ncmbBrokerName.Text);
            _DS4BrokerNameFilter.dtBrokerFilter.Rows.Clear();
            if (row != null)
            {
                DS.DS4BrokerNameFilter.dtBrokerFilterRow newRow = _DS4BrokerNameFilter.dtBrokerFilter.NewRow() as DS.DS4BrokerNameFilter.dtBrokerFilterRow;
                if (newRow != null)
                {
                    newRow.BrokersID = row.BrokersID;
                    newRow.Name = row.Name;
                    newRow.Owner = row.Owner;
                    newRow.Leverage = row.Leverage;
                    newRow.Enable = row.Enable;
                    newRow.BrokerType = row.BrokerType;
                    newRow.Address = row.Address;
                    newRow.City = row.Zone;
                    newRow.State = row.District;
                    newRow.Phone1 = row.Phone1;
                    newRow.Phone2 = row.Phone2;
                    newRow.Fax = row.Fax;
                    newRow.Email = row.Email;
                    newRow.Margin_Call_Level1 = row.Margin_Call_Level1;
                    newRow.Margin_Call_Level2 = row.Margin_Call_Level2;
                    newRow.Margin_Call_Level3 = row.Margin_Call_Level3;
                    newRow.News = row.News;
                    newRow.MaximumOrders = row.MaximumOrders;
                    newRow.MaximumSymbols = row.MaximumSymbols;
                    newRow.ParentBrokerID = row.ParentBrokerID;

                    _DS4BrokerNameFilter.dtBrokerFilter.AdddtBrokerFilterRow(newRow);
                }
            }
            ui_ndgvBrokers.DataSource = _DS4BrokerNameFilter.dtBrokerFilter;

        }
        /// <summary>
        /// Action to performed on selecting broker type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbBrokerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerType.Text == "All")
            {
                ui_ndgvBrokers.DataSource = Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers;
                return;
            }

            DS4Brokers.dtBrokersRow[] rows = Cls.clsBrokersManagerHandler.INSTANCE.GetBrokersDataByBrokerType(ui_ncmbBrokerType.Text);
            _DS4BrokerNameFilter.dtBrokerFilter.Rows.Clear();

            if (rows != null)
            {
                foreach (DS4Brokers.dtBrokersRow row in rows)
                {
                    DS.DS4BrokerNameFilter.dtBrokerFilterRow newRow = _DS4BrokerNameFilter.dtBrokerFilter.NewRow() as DS.DS4BrokerNameFilter.dtBrokerFilterRow;
                    if (newRow != null)
                    {
                        newRow.BrokersID = row.BrokersID;
                        newRow.Name = row.Name;
                        newRow.Owner = row.Owner;
                        newRow.Leverage = row.Leverage;
                        newRow.Enable = row.Enable;
                        newRow.BrokerType = row.BrokerType;
                        newRow.Address = row.Address;
                        newRow.City = row.Zone;
                        newRow.State = row.District;
                        newRow.Phone1 = row.Phone1;
                        newRow.Phone2 = row.Phone2;
                        newRow.Fax = row.Fax;
                        newRow.Email = row.Email;
                        newRow.Margin_Call_Level1 = row.Margin_Call_Level1;
                        newRow.Margin_Call_Level2 = row.Margin_Call_Level2;
                        newRow.Margin_Call_Level3 = row.Margin_Call_Level3;
                        newRow.News = row.News;
                        newRow.MaximumOrders = row.MaximumOrders;
                        newRow.MaximumSymbols = row.MaximumSymbols;
                        newRow.ParentBrokerID = row.ParentBrokerID;

                        _DS4BrokerNameFilter.dtBrokerFilter.AdddtBrokerFilterRow(newRow);
                    }
                }
            }

            ui_ndgvBrokers.DataSource = _DS4BrokerNameFilter.dtBrokerFilter;
        }

        private void ui_ndgvBrokers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //SetDisableBrokersColor();

            //ui_ndgvBrokers.Refresh();
        }

        private void SetDisableBrokersColor()
        {
            foreach (DataGridViewCell cell in from DataGridViewRow item in ui_ndgvBrokers.Rows where Convert.ToBoolean(item.Cells["Enable"].Value) == false from DataGridViewCell cell in item.Cells select cell)
            {
                cell.Style.BackColor = Color.Yellow;
            }
        }

        private void ui_ndgvBrokers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ui_ndgvBrokers.Rows.Count == 0)
            {
                return;
            }
            _iCurrRowIndex = ui_ndgvBrokers.CurrentRow.Index;
            if (_iCurrRowIndex == -1)
                return;
            else if(_isEditable==true)
                EditMenuHandler();
        }

        private void ui_ndgvBrokers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ui_ndgvBrokers.Refresh();
        }

        private void ui_ncmbBrokerIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerIds.SelectedItem.ToString() == "All")
            {
                ui_ndgvBrokers.DataSource = Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers;
                return;
            }

            ui_ndgvBrokers.DataSource = (from broker in Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtBrokers.AsEnumerable()
                                        where
                                            broker.BrokersID == Convert.ToInt32(ui_ncmbBrokerIds.SelectedItem)
                                        select broker).CopyToDataTable();
        }

        private void ui_mnuChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword objfrmChangePassword = new frmChangePassword();
            this.Parent = this.ParentForm;
            objfrmChangePassword.BringToFront();
            objfrmChangePassword.LoginID = ui_ndgvBrokers.SelectedRows[0].Cells["LoginId"].Value.ToString();
            objfrmChangePassword.OldPassword=clsAccountManager.INSTANCE.GetBrokerPassword(Convert.ToInt32(ui_ndgvBrokers.SelectedRows[0].Cells["BrokersID"].Value));
            objfrmChangePassword.ShowDialog();
        }
    }
}
