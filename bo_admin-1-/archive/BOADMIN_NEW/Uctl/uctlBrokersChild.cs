using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.BOEngineServiceTCP;
using System.Text.RegularExpressions;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlBrokersChild : UserControl
    {
        public DialogType CurrentyDialogType;
        int _brokerId;
        int _roleId = 0;
        int _iCurrRowIndex = -1;
        int _iCurrColIndex = -1;
        //bool _isRelative = false;
        //int _prvBid;
        //int _prvAsk;
        private string pattern = @"^(\+|-)?\d{0,4}(\d\.\d?|\.\d)?\d?$"; //@"^(\+|-)?[0-9]{0,5}$";
        DS.DS4Charges _DS4Charges = new BOADMIN_NEW.DS.DS4Charges();
        DS.DS4BrokerSymbol _DS4BrokerSymbol = new BOADMIN_NEW.DS.DS4BrokerSymbol();
        public DS4Brokers _DS4Brokers = new DS4Brokers();
        public uctlBrokersChild()
        {
            InitializeComponent();

            _DS4Charges.dtCharges.TableNewRow += dtCharges_TableNewRow;
            _DS4Charges.dtCharges.RowDeleted += dtCharges_RowDeleted;
            _DS4Charges.dtCharges.RowChanged += dtCharges_RowChanged;
        }

        public void OnChargesRowRemove(int brokerGroupId, int chargesId)
        {
            AddDataToChargesTab(brokerGroupId);
            DS.DS4Charges.dtChargesRow row = _DS4Charges.dtCharges.FindBySymbolChargesID(chargesId);
            lock (_DS4Charges.dtCharges)
            {
                _DS4Charges.dtCharges.RemovedtChargesRow(row);
            }
        }
        /// <summary>
        /// Intialize control values
        /// </summary>
        public void init()
        {
            ui_ndgvCharges.DataSource = _DS4Charges.dtCharges;
            ui_ndgvCharges.Columns["SymbolChargesID"].Visible = false;
            ui_ndgvCharges.Columns["BrokersGroupID"].Visible = false;
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ui_ndgvCharges.Columns["Symbol_ID"].DefaultCellStyle = cellStyle;
            ui_ndgvCharges.Columns["Symbol_ID"].HeaderText = "Symbol ID";
            ui_ndgvCharges.Columns["FeeValue"].DefaultCellStyle = cellStyle;
            ui_ndgvCharges.Columns["FeeValue"].HeaderText = "Fee Value";
            ui_ndgvCharges.Columns["TaxValue"].DefaultCellStyle = cellStyle;
            ui_ndgvCharges.Columns["TaxValue"].HeaderText = "Tax Value";
            ui_ndgvCharges.Columns["FeeType"].HeaderText = "Fee Type";
            ui_ndgvCharges.Columns["TaxType"].HeaderText = "Tax Type";

            ui_ncmbLeverage.Items.Clear();
            ui_ncmbBrokerType.Items.Clear();
            ui_ncmbLeverage.Items.AddRange(clsLeverageManager.INSTANCE.GetLeverageArray());
            //Cls.clsGlobal.BrokerID
            for (int index = Cls.clsGlobal.BrokerID; index < Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray().Count(); index++)
            {
                ui_ncmbBrokerType.Items.Add((Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]).Trim());
            }
        }

        void dtCharges_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshChargesGrid();
        }

        void dtCharges_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RefreshChargesGrid();
        }

        void dtCharges_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshChargesGrid();
        }

        private void RefreshChargesGrid()
        {
            Action a = () =>
            {
                ui_ndgvCharges.DataSource = _DS4Charges.dtCharges;
                ui_cmsCharges.Refresh();
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
        /// set control values
        /// </summary>
        /// <param name="brokers"></param>
        /// <param name="brokersRow"></param>
        /// <param name="dialogType"></param>
        public void SetValues(DS4Brokers brokers, DS4Brokers.dtBrokersRow brokersRow, DialogType dialogType)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlBrokersChild : Enter SetValues()");
                //brokerID = brokersRow.BrokersID;
                ui_ndgvCharges.Columns["SymbolChargesID"].Visible = false;
                CurrentyDialogType = dialogType;
                List<string> lstModules = Cls.clsBrokerManager.INSTANCE.GetAllModules();
                for (int i = 0; i < lstModules.Count(); i++)
                {
                    ui_ndgvRoleSettings.Rows.Add();
                    ui_ndgvRoleSettings.Rows[i].Cells["Module"].Value = lstModules[i];
                }
                string[] loginRole = clsGlobal.Role.Split('_');
                if (loginRole.Count() > 1)
                {
                    for (int i = 0; i < loginRole.Count(); i++)
                    {
                        ui_ndgvRoleSettings.Rows[i].Cells["View"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[0].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Add"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[1].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Edit"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[2].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Delete"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[3].ToString()));
                    }
                }
                if (dialogType == DialogType.Edit)
                {
                    ui_ncmbBrokerParent.Enabled = false;
                    ui_ncmbBrokerType.Enabled = false;

                    _brokerId = brokersRow.BrokersID;
                    ui_nchkEnable.Checked = brokersRow.Enable;
                    ui_ntxtBrokerName.Text = brokersRow.Name;    //brokersRow.BrokerName;
                    ui_ntxtBrokerName.Enabled = false;
                    ui_ntxtCompanyName.Text = brokersRow.Owner;    //brokersRow.CompanyName;                  
                    ui_ncmbLeverage.SelectedIndex = ui_ncmbLeverage.Items.IndexOf(brokersRow.Leverage);
                    //ui_ncmbLeverage.SelectedIndex = ui_ncmbLeverage.Items.IndexOf(Convert.ToInt32(brokersRow.Leverage.Trim()).ToString());
                    ui_ncmbBrokerType.SelectedIndex = ui_ncmbBrokerType.Items.IndexOf(brokersRow.BrokerType.Trim());
                    ui_ntxtAddress.Text = Convert.ToString(brokersRow.Address);
                    ui_ntxtCity.Text = brokersRow.Zone;
                    ui_ntxtState.Text = brokersRow.District;
                    if (brokersRow.Phone1 != string.Empty)
                    {
                        ui_ntxtPhone1.Text = brokersRow.Phone1;
                    }
                    if (brokersRow.Phone2 != string.Empty)
                    {
                        ui_ntxtPhone2.Text = brokersRow.Phone2;
                    }
                    if (brokersRow.Fax != string.Empty)
                    {
                        ui_ntxtFax.Text = brokersRow.Fax;
                    }
                    ui_ntxtEmail.Text = brokersRow.Email;
                    if (brokersRow.Margin_Call_Level1.ToString() != string.Empty)
                    {
                        ui_ntxtMarginCallLevel1.Text = brokersRow.Margin_Call_Level1.ToString();
                    }
                    if (brokersRow.Margin_Call_Level2.ToString() != string.Empty)
                    {
                        ui_ntxtMarginCallLevel2.Text = brokersRow.Margin_Call_Level2.ToString();
                    }
                    if (brokersRow.Margin_Call_Level3.ToString() != string.Empty)
                    {
                        ui_ntxtMarginCallLevel3.Text = brokersRow.Margin_Call_Level3.ToString();
                    }
                    ui_ncmbNews.Text = brokersRow.News;
                    if (brokersRow.MaximumOrders != string.Empty)
                    {
                        ui_ntxtMaximumOrders.Text = brokersRow.MaximumOrders;
                    }
                    if (brokersRow.MaximumSymbols != string.Empty)
                    {
                        ui_ntxtMaximuSymbols.Text = brokersRow.MaximumSymbols;
                    }
                    ui_ncmbBrokerParent.SelectedIndex = ui_ncmbBrokerParent.Items.IndexOf(brokersRow.ParentBrokerID);
                    ui_ntxtLoginID.Text = brokersRow.LoginId;
                    //ui_ntxtPanNo.Text = brokersRow.
                    //for symbol tab
                    ui_ndgvSymbolGrid.Rows.Clear();

                    DS4Brokers.dtSymbolRow[] symbols = (DS4Brokers.dtSymbolRow[])Cls.clsBrokersManagerHandler.INSTANCE.GetSymbolsRow(brokersRow.BrokersID);
                    string[] x = brokersRow.Roles.Split('_');
                    if (x.Count() > 1)
                    {
                        for (int i = 0; i < x.Count(); i++)
                        {
                            ui_ndgvRoleSettings.Rows[i].Cells["View"].Value = Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[0].ToString()));
                            ui_ndgvRoleSettings.Rows[i].Cells["Add"].Value = Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[1].ToString()));
                            ui_ndgvRoleSettings.Rows[i].Cells["Edit"].Value = Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[2].ToString()));
                            ui_ndgvRoleSettings.Rows[i].Cells["Delete"].Value = Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[3].ToString()));
                        }
                    }
                    _roleId = brokersRow.RoleId;
                    ui_ntxtRoleName.Text = brokersRow.RoleName;
                    AddColumnsToSymbolGrid();
                    AddSymbolsToSymbolGrid();
                    SetSymbolchecking(symbols);
                    AddDataToChargesTab(brokersRow.BrokersID);
                }
                else
                {
                    ui_ntxtLoginID.Text = GenerateLoginID();
                    AddColumnsToSymbolGrid();
                    AddSymbolsToSymbolGrid();
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlBrokersChild =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SetValues()");
            }
        }

        private string GenerateLoginID()
        {
            Random rad = new Random();
            string loginId = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                loginId += Convert.ToChar(rad.Next(48, 57));
            }
            return loginId;
        }
        /// <summary>
        /// adds Data to charges tab
        /// </summary>
        /// <param name="brokerId"></param>
        public void AddDataToChargesTab(int brokerId)
        {
            DS4Brokers.dtChargesRow[] chargesRows = (DS4Brokers.dtChargesRow[])Cls.clsBrokersManagerHandler.INSTANCE.GetChargesRow(brokerId);

            DS.DS4Charges.dtChargesRow[] chRow = (DS.DS4Charges.dtChargesRow[])_DS4Charges.dtCharges.Select("SymbolChargesID < " + 0);
            foreach (DS.DS4Charges.dtChargesRow row in chRow)
            {
                _DS4Charges.dtCharges.RemovedtChargesRow(row);
            }
            foreach (DS4Brokers.dtChargesRow item in chargesRows)
            {
                DS.DS4Charges.dtChargesRow chargesRow = _DS4Charges.dtCharges.FindBySymbolChargesID(item.SymbolChargesID);
                if (chargesRow == null)
                {
                    chargesRow = _DS4Charges.dtCharges.NewRow() as DS.DS4Charges.dtChargesRow;

                    if (chargesRow != null)
                    {
                        chargesRow.SymbolChargesID = item.SymbolChargesID;
                        chargesRow.BrokersGroupID = item.BrokersGroupID;
                        chargesRow.Symbol_ID = item.Symbol_ID;
                        chargesRow.Symbol = item.Symbol;
                        chargesRow.FeeType = item.FeeType;
                        chargesRow.FeeValue = item.FeeValue.ToString();
                        chargesRow.TaxType = item.TaxType;
                        chargesRow.TaxValue = item.TaxValue.ToString();

                        _DS4Charges.dtCharges.AdddtChargesRow(chargesRow);
                    }
                }
                else
                {
                    chargesRow.SymbolChargesID = item.SymbolChargesID;
                    chargesRow.BrokersGroupID = item.BrokersGroupID;
                    chargesRow.Symbol_ID = item.Symbol_ID;
                    chargesRow.Symbol = item.Symbol;
                    chargesRow.FeeType = item.FeeType;
                    chargesRow.FeeValue = item.FeeValue.ToString();
                    chargesRow.TaxType = item.TaxType;
                    chargesRow.TaxValue = item.TaxValue.ToString();
                }
            }

            ui_ndgvCharges.Columns["SymbolChargesID"].Visible = false;
        }
        /// <summary>
        /// add columns to grid
        /// </summary>
        public void AddColumnsToSymbolGrid()
        {
            ui_ndgvSymbolGrid.Columns.Add("ui_clmFKBrokersID", "FK_BrokersID");
            DataGridViewCheckBoxColumn objDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            objDataGridViewCheckBoxColumn.Name = "ui_clmSelect";
            objDataGridViewCheckBoxColumn.HeaderText = "Select";
            ui_ndgvSymbolGrid.Columns.Add(objDataGridViewCheckBoxColumn);
            ui_ndgvSymbolGrid.Columns.Add("ui_clmSymbolID", "Symbol ID");
            ui_ndgvSymbolGrid.Columns.Add("ui_clmSymbol", "Symbol");
            ui_ndgvSymbolGrid.Columns.Add("ui_clmBidSpread", "Bid Spread");
            ui_ndgvSymbolGrid.Columns.Add("ui_clmAskSpread", "Ask Spread");
            ui_ndgvSymbolGrid.Columns.Add("ui_clmSpread", "Spread");
            objDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            objDataGridViewCheckBoxColumn.Name = "ui_clmIsVariable";
            objDataGridViewCheckBoxColumn.HeaderText = "Is Spread Variable";
            //ui_ndgvSymbolGrid.Columns.Add("ui_clmSpread", "Spread");
            //ui_ndgvSymbolGrid.Columns.Add("ui_clmSpread", "Spread");
            ui_ndgvSymbolGrid.Columns.Add(objDataGridViewCheckBoxColumn);
            ui_ndgvSymbolGrid.Columns["ui_clmSymbol"].ReadOnly = true;
            var dataGridViewColumn = ui_ndgvSymbolGrid.Columns["ui_clmFKBrokersID"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = ui_ndgvSymbolGrid.Columns["ui_clmSymbolID"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
        }

        private void SetSymbolchecking(DS4Brokers.dtSymbolRow[] symbols)
        {
            foreach (DS4Brokers.dtSymbolRow item in symbols)
            {
                foreach (DataGridViewRow item2 in ui_ndgvSymbolGrid.Rows)
                {
                    if (clsUtility.GetInt(item2.Cells[2].Value) == item.Symbol_ID)
                    {
                        item2.Cells[1].Value = true;
                        item2.Cells[4].Value = item.BidSpread;
                        item2.Cells[5].Value = item.AskSpread;
                        item2.Cells[6].Value = item.Spread;
                        item2.Cells[7].Value = item.IsVariable;
                    }
                }
            }
        }

        public void AddSymbolsToSymbolGrid()
        {
            foreach (BOEngineServiceTCP.BrokerSymbol item in Cls.clsBrokersManagerHandler.INSTANCE._lstTotalSymbols)
            {
                DS.DS4BrokerSymbol.dtFilterSymbolRow row = _DS4BrokerSymbol.dtFilterSymbol.NewRow() as DS.DS4BrokerSymbol.dtFilterSymbolRow;
                DataRow[] _rows = _DS4BrokerSymbol.dtFilterSymbol.Select("SymbolID ="+ item.SymbolID);
                if (_rows.Length==0)
                {
                    row.SymbolID = item.SymbolID;
                    row.SymbolName = item.SymbolName;
                    row.PrevBidPrice = item.BidSpread;
                    row.PrevAskPrice = item.AskSpread;
                    _DS4BrokerSymbol.dtFilterSymbol.AdddtFilterSymbolRow(row);

                    ui_ndgvSymbolGrid.Rows.Add(0, false, item.SymbolID, item.SymbolName, item.BidSpread, item.AskSpread, item.Spread, item.IsVariable);
                }
              
            }
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            ValidateSubmitInformation();
        }
        /// <summary>
        /// Validates information
        /// </summary>
        private void ValidateSubmitInformation()
        {
            if (ui_ntxtBrokerName.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("BrokerName can't be null", "Broker Error ", true);   //Please specify broker name
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ntxtBrokerName.Focus();
                return;
            }

            if (ui_ncmbBrokerType.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("BrokerType can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ncmbBrokerType.Focus();
                return;
            }

            if (ui_ncmbLeverage.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Leverage can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ncmbLeverage.Focus();
                return;
            }

            //if (ui_ntxtEmail.Text != string.Empty)
            {
                if (!clsGlobal.ValidateEmail(ui_ntxtEmail.Text))
                {
                    clsDialogBox.ShowErrorBox("Invalid email address", "Broker Error ", true);
                    ui_ntcBrokers.SelectedIndex = 0;
                    ui_ntxtEmail.Focus();
                    return;
                }
            }

            if (ui_ntxtAddress.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Address can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ntxtAddress.Focus();
                return;
            }

            if (ui_ntxtCity.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("City can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ntxtCity.Focus();
                return;
            }

            if (ui_ntxtPhone1.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Phone1 can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ntxtPhone1.Focus();
                return;
            }
            if (ui_ntxtFax.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Fax can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 0;
                ui_ntxtFax.Focus();
                return;
            }
            //if (ui_ntxtPanNo.Text == string.Empty)
            //{
            //    clsDialogBox.ShowErrorBox("PAN No can't be null", "Broker Error ", true);
            //    ui_ntcBrokers.SelectedIndex = 0;
            //    ui_ntxtPanNo.Focus();
            //    return;
            //}
            if (ui_ntxtRoleName.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("RoleName can't be null", "Broker Error ", true);
                ui_ntcBrokers.SelectedIndex = 4;
                ui_ntxtRoleName.Focus();
                return;
            }

            SubmitInformation();
            //this.ParentForm.Close();
        }

        private bool ValidateControlInformation()
        {
            bool flag;
            flag = clsGlobal.IsNotNull(ui_ntxtBrokerName.Text);
            flag = clsGlobal.IsNotNull(ui_ncmbLeverage.Text);

            return flag;
        }

        /// <summary>
        /// Summits information for operation
        /// </summary>
        private void SubmitInformation()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlBrokersChild : Enter SubmitInformation()");

                string errorMsg = string.Empty;
                clsBroker objclsBroker = new clsBroker();
                List<BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol> lstSymbols = new List<BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol>();
                List<BOADMIN_NEW.BOEngineServiceTCP.charges> lstCharges = new List<BOADMIN_NEW.BOEngineServiceTCP.charges>();

                objclsBroker.IsEnable = ui_nchkEnable.Checked;
                objclsBroker.Name = ui_ntxtBrokerName.Text.Trim();
                objclsBroker.Owner = ui_ntxtCompanyName.Text.Trim();
                objclsBroker.Leverage = ui_ncmbLeverage.SelectedItem.ToString().Trim();
                objclsBroker.BrokerType = ui_ncmbBrokerType.Text.Trim();
                objclsBroker.Address = ui_ntxtAddress.Text.Trim();
                objclsBroker.City = ui_ntxtCity.Text.Trim();
                objclsBroker.State = ui_ntxtState.Text.Trim();
                objclsBroker.Phone1 = ui_ntxtPhone1.Text.Trim();
                objclsBroker.Phone2 = ui_ntxtPhone2.Text.Trim();
                objclsBroker.Fax = ui_ntxtFax.Text.Trim();
                objclsBroker.EMail = ui_ntxtEmail.Text.Trim();
                objclsBroker.MarginCallLevel1 = clsUtility.GetInt(ui_ntxtMarginCallLevel1.Text.Trim());
                objclsBroker.MarginCallLevel2 = clsUtility.GetInt(ui_ntxtMarginCallLevel2.Text.Trim());
                objclsBroker.MarginCallLevel3 = clsUtility.GetInt(ui_ntxtMarginCallLevel3.Text.Trim());
                objclsBroker.News = ui_ncmbNews.Text.Trim();
                objclsBroker.MaximumOrders = clsUtility.GetInt(ui_ntxtMaximumOrders.Text.Trim()).ToString();
                objclsBroker.Maximumsymbols = clsUtility.GetInt(ui_ntxtMaximuSymbols.Text.Trim()).ToString();
                if (ui_ncmbBrokerParent.Text.Trim() == string.Empty)
                {
                    objclsBroker.BrokerParent = clsGlobal.BrokerNameId;
                }
                else
                {
                    objclsBroker.BrokerParent = clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ui_ncmbBrokerParent.Text.Trim());
                }
                //.GetGroupId(ui_ncmbBrokerParent.Text.Trim()); //Cls.clsBrokersManagerHandler.INSTANCE.GetBrokerId(ui_ncmbBrokerParent.Text.Trim());
                objclsBroker.RoleId = _roleId;
                objclsBroker.LoginID = ui_ntxtLoginID.Text.Trim();
                string roles = GenerateRoles();
                objclsBroker.Roles = roles.Remove(roles.Length - 1, 1);
                objclsBroker.RoleName = ui_ntxtRoleName.Text.Trim();
                //if (ui_nrbtAbsolute.Checked)
                //{
                //    //objclsBroker.IsAbsolute = true;
                //}
                //else
                    //objclsBroker.IsAbsolute = false;
                    foreach (DataGridViewRow item in ui_ndgvSymbolGrid.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value) == true)
                        {
                            BOEngineServiceTCP.BrokerSymbol objBrokerSymbol = new BOEngineServiceTCP.BrokerSymbol();
                            objBrokerSymbol.SymbolID = clsUtility.GetInt(item.Cells[2].Value);
                            objBrokerSymbol.SymbolName = clsUtility.GetStr(item.Cells[3].Value);
                            objBrokerSymbol.BidSpread = clsUtility.GetInt(item.Cells[4].Value);
                            objBrokerSymbol.AskSpread = clsUtility.GetInt(item.Cells[5].Value);
                            objBrokerSymbol.Spread = clsUtility.GetInt(item.Cells[6].Value);
                            objBrokerSymbol.IsVariable = Convert.ToBoolean(item.Cells[7].Value);
                            //objBrokerSymbol.RelativeBidChange = objBrokerSymbol.BidSpread - clsUtility.GetInt(item.Cells[8].Value);
                            //objBrokerSymbol.RelativeAskChange = objBrokerSymbol.AskSpread - clsUtility.GetInt(item.Cells[2].Value);
                            objBrokerSymbol.RelativeBidChange = 0;
                            objBrokerSymbol.RelativeAskChange = 0;

                            lstSymbols.Add(objBrokerSymbol);
                        }
                    }
                objclsBroker.LstSymbol = lstSymbols.ToArray();

                foreach (DataGridViewRow item2 in ui_ndgvCharges.Rows)
                {
                    BOEngineServiceTCP.charges objcharges = new BOEngineServiceTCP.charges();
                    if (CurrentyDialogType == DialogType.Edit)
                    {
                        objcharges.ChargesID = clsUtility.GetInt(item2.Cells[0].Value);
                    }
                    objcharges.BrokersGroupID = _brokerId;
                    objcharges.SymbolID = clsUtility.GetInt(item2.Cells[2].Value);
                    objcharges.Symbol = item2.Cells[3].Value.ToString();
                    objcharges.Fee = item2.Cells[4].Value.ToString();
                    objcharges.FeeValue = clsUtility.GetDecimal(item2.Cells[5].Value);
                    objcharges.Tax = item2.Cells[6].Value.ToString();
                    objcharges.TaxValue = clsUtility.GetDouble(item2.Cells[7].Value);
                    lstCharges.Add(objcharges);
                }
                objclsBroker.LstCharges = lstCharges.ToArray();

                string opMsg = string.Empty;
                if (CurrentyDialogType == DialogType.Edit)
                {
                    opMsg = "Edited Broker record of BrokerName: " + objclsBroker.Name + " and BrokerID: " + objclsBroker.BrokerID + ".";
                        //+ " Broker Name :" + objclsBroker.Name + " Broker Type :" + objclsBroker.BrokerType +
                        //" Company Name :" + objclsBroker.Owner + " Login ID :" + objclsBroker.LoginID;
                    errorMsg = "Error in updating Broker Information";
                    objclsBroker.BrokerID = _brokerId;
                    objclsBroker = clsProxyClassManager.INSTANCE.UpdateBroker(objclsBroker);
                }
                else
                {
                    opMsg = "Added new Broker record of BrokerName:" + objclsBroker.Name + " and BrokerID:" + objclsBroker.BrokerID + ".";
                        //+ " Broker Name :" + objclsBroker.Name + " Broker Type :" + objclsBroker.BrokerType +
                        //" Company Name :" + objclsBroker.Owner + " Login ID :" + objclsBroker.LoginID;
                    errorMsg = "Error in inserting Broker Information";
                    objclsBroker.BrokerID = ProtocolStructIDS.DBInsert;
                    objclsBroker = clsProxyClassManager.INSTANCE.InsertBroker(objclsBroker);

                    if (objclsBroker.ServerResponseID != clsGlobal.FailureID)
                    {
                        //commented by vijay on 13 Aug
                        //clsAccountManager.INSTANCE.FillDataToAccountGroupDataSet(clsProxyClassManager.INSTANCE.GetAccountGroupRecords());

                        //System.Threading.ThreadPool.QueueUserWorkItem(FillDataToAccountGroup, null);
                        //UpdateAccountGroupName=>
                        //    {
                        //        clsDataManager.INSTANCE.HandleSocketData(objAccountGroupPS);
                        //    });
                    }
                }

                if (objclsBroker.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        if (CurrentyDialogType==DialogType.New)
                        {
                            objclsBrokerOpLog.OperationName = "New Broker added"; 
                        }
                        if (CurrentyDialogType == DialogType.Edit)
                        {
                            objclsBrokerOpLog.OperationName = "Broker's details added";
                        }
                        //objclsBrokerOpLog.ControlName = "Broker";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                    ProcessBrokerData(objclsBroker);
                    //System.Threading.ThreadPool.QueueUserWorkItem(ProcessBrokerData, objclsBroker);
                    this.ParentForm.Close();
                    System.Threading.ThreadPool.QueueUserWorkItem(FillDataToAccountGroup, null);
                }
                else if (objclsBroker.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlBrokersChild =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SubmitInformation()");
            }
        }

        public void FillDataToAccountGroup(object obj)
        {
            GetCollateralData();
            clsAccountManager.INSTANCE.FillDataToAccountGroupDataSet(clsProxyClassManager.INSTANCE.GetAccountGroupRecords());
        }

        public void ProcessBrokerData(object obj)
        {
            clsBrokersManagerHandler.INSTANCE.DoHandleBrokersTable(obj as clsBroker);
        }

        private void GetCollateralData()
        {
            foreach (clsCollateralInfo item in clsProxyClassManager.INSTANCE.GetCollateralInfoRecords())
            {
                clsCollateralManager.INSTANCE.DoHandleBrokerCollateralTable(item);

                clsCollateralManager.INSTANCE.FillDataToCollateralTransDataSet(clsProxyClassManager.INSTANCE.GetCollateralTransInfoRecords(item.AccountGroupID));
            }
        }
        /// <summary>
        /// Gets roles for broker
        /// </summary>
        /// <returns></returns>
        private string GenerateRoles()
        {
            string roles = string.Empty;
            foreach (DataGridViewRow dgr in ui_ndgvRoleSettings.Rows)
            {
                if (dgr.Cells["View"].Value != null && Convert.ToBoolean(dgr.Cells["View"].Value.ToString()))
                {
                    roles += "1";
                }
                else
                {
                    roles += "0";
                }
                if (dgr.Cells["Add"].Value != null && Convert.ToBoolean(dgr.Cells["Add"].Value.ToString()))
                {
                    roles += "1";
                }
                else
                {
                    roles += "0";
                }
                if (dgr.Cells["Edit"].Value != null && Convert.ToBoolean(dgr.Cells["Edit"].Value.ToString()))
                {
                    roles += "1";
                }
                else
                {
                    roles += "0";
                }
                if (dgr.Cells["Delete"].Value != null && Convert.ToBoolean(dgr.Cells["Delete"].Value.ToString()))
                {
                    roles += "1";
                }
                else
                {
                    roles += "0";
                }
                roles += "_";
            }
            return roles;
        }

        private void ui_mnuAdd_Click(object sender, EventArgs e)
        {
            DisplayChargesDialog(DialogType.AddContract, "Add");
        }
        /// <summary>
        /// Brokers charges click
        /// </summary>
        /// <param name="chargesInfo"></param>
        void objuctlBrokersCharges_OnOkClick(ChargesInfo chargesInfo)
        {
            DS.DS4Charges.dtChargesRow chargesRow = _DS4Charges.dtCharges.FindBySymbolChargesID(chargesInfo.SymbolChargesID);
            if (chargesRow == null)
            {
                chargesRow = _DS4Charges.dtCharges.NewRow() as DS.DS4Charges.dtChargesRow;

                if (chargesRow != null)
                {
                    chargesRow.SymbolChargesID = chargesInfo.SymbolChargesID;
                    chargesRow.BrokersGroupID = 0;
                    chargesRow.Symbol_ID = chargesInfo.SymbolID;
                    chargesRow.Symbol = chargesInfo.Symbol;
                    chargesRow.FeeType = chargesInfo.Fee;
                    chargesRow.FeeValue = chargesInfo.FeeValue;
                    chargesRow.TaxType = chargesInfo.Tax;
                    chargesRow.TaxValue = chargesInfo.TaxValue;

                    _DS4Charges.dtCharges.AdddtChargesRow(chargesRow);
                }
            }
            else
            {
                chargesRow.BrokersGroupID = 0;
                chargesRow.Symbol_ID = chargesInfo.SymbolID;
                chargesRow.Symbol = chargesInfo.Symbol;
                chargesRow.FeeType = chargesInfo.Fee;
                chargesRow.FeeValue = chargesInfo.FeeValue;
                chargesRow.TaxType = chargesInfo.Tax;
                chargesRow.TaxValue = chargesInfo.TaxValue;
            }
            _DS4Charges.dtCharges.AcceptChanges();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        /// <summary>
        /// handesl delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_mnuDelete_Click(object sender, EventArgs e)
        {
            if (_iCurrRowIndex == -1)
                return;
            string strChargesColumn = (clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtCharges).SymbolChargesIDColumn.Caption;
            if (ui_ndgvCharges.Rows[_iCurrRowIndex].Cells[strChargesColumn].Value == null)
            {
                return;
            }

            int id = (int)ui_ndgvCharges.Rows[_iCurrRowIndex].Cells[strChargesColumn].Value;
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = Cls.clsBrokersManagerHandler.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.BrokersGroup_ID;
            Delete._DBDelete._DeleteKey = id.ToString();
            Delete._ContainerCaption = "Delete";
            Delete.ShowDialog();
        }

        private void ui_mnuEdit_Click(object sender, EventArgs e)
        {
            DisplayChargesDialog(DialogType.Edit, "Edit");
        }
        /// <summary>
        /// handles mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvCharges_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitinfo = ui_ndgvCharges.HitTest(e.X, e.Y);
            _iCurrRowIndex = hitinfo.RowIndex;
            _iCurrColIndex = hitinfo.ColumnIndex;
            if (_iCurrRowIndex != -1)
            {
                ui_mnuEdit.Enabled = true;
                ui_mnuDelete.Enabled = true;
            }
            else
            {
                ui_mnuEdit.Enabled = false;
                ui_mnuDelete.Enabled = false;
            }

            if (ui_ndgvCharges.Rows.Count == 0)
            {
                return;
            }
            if (e.Button != MouseButtons.Left || _iCurrRowIndex < 0) return;
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)//Double Click
            {
                DisplayChargesDialog(DialogType.Edit, "Edit");
            }
        }
        /// <summary>
        /// display charges control dialog
        /// </summary>
        /// <param name="dialogType"></param>
        /// <param name="dialogText"></param>
        private void DisplayChargesDialog(DialogType dialogType, string dialogText)
        {
            bool isRowClick = !(_iCurrRowIndex < 0);

            uctlBrokersCharges objuctlBrokersCharges = new uctlBrokersCharges();
            //List<string> lstSymbols = new List<string>();
            Dictionary<int, string> ddSymbols = new Dictionary<int, string>();

            Forms.frmCommonContainer objfrmCommonContainer = new Forms.frmCommonContainer();

            foreach (DataGridViewRow row in ui_ndgvSymbolGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[1].Value) == true)
                {
                    ddSymbols.Add(Convert.ToInt32(row.Cells[2].Value), row.Cells[3].Value.ToString());
                    //lstSymbols.Add(row.Cells[3].Value.ToString());
                }
            }
            objuctlBrokersCharges.AddSymbols(ddSymbols);
            if (isRowClick)
            {

                string strChargesColumn = (Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtCharges).SymbolChargesIDColumn.Caption;
                if (ui_ndgvCharges.Rows.Count > 0)
                {
                    if (ui_ndgvCharges.Rows[_iCurrRowIndex].Cells[strChargesColumn].Value == null)
                    {
                        return;
                    }
                }
                int id = (int)ui_ndgvCharges.Rows[_iCurrRowIndex].Cells[strChargesColumn].Value;
                if (id > 0)
                {
                    objuctlBrokersCharges.SetValues(Cls.clsBrokersManagerHandler.INSTANCE._DS4Brokers.dtCharges.FindBySymbolChargesID(id), dialogType);
                }
                else
                {
                    objuctlBrokersCharges.SetValues(_DS4Charges.dtCharges.FindBySymbolChargesID(id), dialogType);
                }
            }

            if (!isRowClick && dialogType == DialogType.AddContract)
            {
                objuctlBrokersCharges.InitComboBox();
            }
            objuctlBrokersCharges.OnOkClick += objuctlBrokersCharges_OnOkClick;
            objfrmCommonContainer.Text = dialogText;
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.Size = new Size(objuctlBrokersCharges.Width - 5, objuctlBrokersCharges.Height + 10);
            objuctlBrokersCharges.Dock = DockStyle.Fill;
            objfrmCommonContainer.Controls.Add(objuctlBrokersCharges);
            objfrmCommonContainer.ShowDialog();
        }

        private void ui_ncmbBrokerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbBrokerParent.Items.Clear();

            if (clsGlobal.BrokerID == 1)
            {
                if (ui_ncmbBrokerType.SelectedItem.ToString().Trim() == "TCM")
                {
                    ui_ncmbBrokerParent.Items.Add(clsGlobal.BrokerCompany);
                }
                else
                {
                    ui_ncmbBrokerParent.Items.AddRange(clsAccountManager.INSTANCE.GetParentBrokers(ui_ncmbBrokerType.SelectedItem.ToString().Trim()).ToArray());
                }
                // ui_ncmbBrokerParent.Items.Add(clsGlobal.BrokerCompany);//lstParentBrokers.ToArray());
                //ui_ncmbBrokerParent.Items.Insert(0, "     ");
                ui_ncmbBrokerParent.SelectedIndex = 0;
                return;
            }
            //Commented by vijay on 08 oct 2012 AFTER THESE COMMENT  6 LINES
            //List<string> lstParentBrokers = clsAccountManager.INSTANCE.GetParentBrokersTypeFromAccountGroup(ui_ncmbBrokerType.SelectedItem.ToString()); //Cls.clsBrokersManagerHandler.INSTANCE.GetParentBrokersType(ui_ncmbBrokerType.SelectedItem.ToString());
            //if (lstParentBrokers.Count() == 0)
            //{
            //    ui_ncmbBrokerParent.Items.Add(clsBrokerManager.INSTANCE.GetBrokerType(Cls.clsGlobal.BrokerID));
            //    ui_ncmbBrokerParent.Items.Insert(0, "     ");
            //    ui_ncmbBrokerParent.SelectedIndex = 0;
            //}
            //else
            {
                ui_ncmbBrokerParent.Items.Add(clsGlobal.BrokerCompany);//.BrokerName);//lstParentBrokers.ToArray());
                //ui_ncmbBrokerParent.Items.Insert(0, "     ");
                ui_ncmbBrokerParent.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// sets broker types role according to broker type
        /// </summary>
        private void SetBrokerTypeRole()
        {
            if (ui_ncmbBrokerType.SelectedItem == null)
                return;

            string[] x = clsMasterInfoManager.INSTANCE.GetPredefinedRole(ui_ncmbBrokerType.SelectedItem.ToString().Trim())
                    .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ui_ndgvRoleSettings.Rows.Count; i++)
            {
                ui_ndgvRoleSettings.Rows[i].Cells["View"].Value = false;
                ui_ndgvRoleSettings.Rows[i].Cells["Add"].Value = false;
                ui_ndgvRoleSettings.Rows[i].Cells["Edit"].Value = false;
                ui_ndgvRoleSettings.Rows[i].Cells["Delete"].Value = false;
            }

            if (x.Count() <= 1) return;
            for (int i = 0; i < x.Count(); i++)
            {
                ui_ndgvRoleSettings.Rows[i].Cells["View"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[0].ToString()));
                ui_ndgvRoleSettings.Rows[i].Cells["Add"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[1].ToString()));
                ui_ndgvRoleSettings.Rows[i].Cells["Edit"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[2].ToString()));
                ui_ndgvRoleSettings.Rows[i].Cells["Delete"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(x[i].ToCharArray()[3].ToString()));
            }
        }

        private void nTextBox1_TextChanged(object sender, EventArgs e)
        {
            DS.DS4BrokerSymbol.dtFilterSymbolRow[] rows = 
                (DS.DS4BrokerSymbol.dtFilterSymbolRow[])_DS4BrokerSymbol.dtFilterSymbol.Select("SymbolName like '" + ui_ntxtSymbol.Text + "%'");

            if (rows.Count() == 0) return;
            ui_ndgvSymbolGrid.Rows.Clear();

            foreach (DS.DS4BrokerSymbol.dtFilterSymbolRow item in rows)
            {
                ui_ndgvSymbolGrid.Rows.Add(0, false, item.SymbolID, item.SymbolName, item.BidSpread, item.AskSpread, item.Spread);
            }
        }

        private void ui_nchkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_nchkEnable.Checked == true)
            {
                ui_ntxtLoginID.Enabled = true;
                if (CurrentyDialogType != DialogType.Edit)
                {
                    ui_ntxtBrokerName.Enabled = true;
                }              
                ui_ncmbBrokerType.Enabled = true;
                ui_ncmbBrokerParent.Enabled = true;
                ui_ntxtCompanyName.Enabled = true;
                ui_ncmbLeverage.Enabled = true;
                ui_ntxtEmail.Enabled = true;
                ui_ntxtAddress.Enabled = true;
                ui_ntxtCity.Enabled = true;
                ui_ntxtState.Enabled = true;
                ui_ntxtPhone1.Enabled = true;
                ui_ntxtPhone2.Enabled = true;
                ui_ntxtFax.Enabled = true;
                ui_ntxtPanNo.Enabled = true;
            }
            else
            {
                ui_ntxtLoginID.Enabled = false;
                ui_ntxtBrokerName.Enabled = false;
                ui_ncmbBrokerType.Enabled = false;
                ui_ncmbBrokerParent.Enabled = false;
                ui_ntxtCompanyName.Enabled = false;
                ui_ncmbLeverage.Enabled = false;
                ui_ntxtEmail.Enabled = false;
                ui_ntxtAddress.Enabled = false;
                ui_ntxtCity.Enabled = false;
                ui_ntxtState.Enabled = false;
                ui_ntxtPhone1.Enabled = false;
                ui_ntxtPhone2.Enabled = false;
                ui_ntxtFax.Enabled = false;
                ui_ntxtPanNo.Enabled = false;
            }
        }

        private void uctlBrokersChild_Load(object sender, EventArgs e)
        {
            ui_ntcBrokers.SelectedIndex = 0;
            InitControls();
        }
        public void InitControls()
        {
            ui_ncmbSecurityType.Items.Clear();
            ui_ncmbSecurityType.Items.Insert(0, "All");
            ui_ncmbSecurityType.Items.AddRange(Cls.clsSecurityManager.INSTANCE.GetSecurityNameArray());
            ui_ncmbSecurityType.SelectedIndex = 0;
            //if (CurrentyDialogType==DialogType.Edit)
            //{
            //    ui_ncmbLeverage.SelectedIndex = ui_ncmbLeverage.Items.IndexOf(_leverage);
            //}
        }
        private void ui_ntxtMarginCallLevel1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ui_ntxtMarginCallLevel2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ui_ntxtMarginCallLevel3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ui_ncmbBrokerParent_Click(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerType.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Please select BrokerType first", "Broker", true);
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

        private void ui_ntxtBrokerName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ui_ntxtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ui_ntxtMarginCallLevel1_Leave(object sender, EventArgs e)
        {
            Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMarginCallLevel2_Leave(object sender, EventArgs e)
        {
            Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMarginCallLevel3_Leave(object sender, EventArgs e)
        {
            Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMaximumOrders_Leave(object sender, EventArgs e)
        {
            Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntxtMaximuSymbols_Leave(object sender, EventArgs e)
        {
            Cls.clsGlobal.HandleZero(sender, e, 0);
        }

        private void ui_ntpRoles_Click(object sender, EventArgs e)
        {

        }

        private void ui_ntcBrokers_Click(object sender, EventArgs e)
        {

        }

        private void ui_ntpRoles_MouseClick(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// handles broker type selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntcBrokers_SelectedTabChanged(object sender, EventArgs e)
        {
            if (ui_ntcBrokers.SelectedTab.Name == "ui_ntpRoles")
            {
                if (ui_ncmbBrokerParent.SelectedItem == null)
                {
                    clsDialogBox.ShowErrorBox("Please fill broker information first", "Broker Error", true);
                    return;
                }
                DS4Brokers.dtBrokersRow row = clsBrokersManagerHandler.INSTANCE.GetBrokersDataByBrokerCompanyName(ui_ncmbBrokerParent.SelectedItem.ToString());
                if (row == null)
                    return;
                string[] loginRole = row.Roles.Split('_');
                if (loginRole.Count() > 1)
                {
                    for (int i = 0; i < loginRole.Count(); i++)
                    {
                        ui_ndgvRoleSettings.Rows[i].Cells["View"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[0].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Add"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[1].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Edit"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[2].ToString()));
                        ui_ndgvRoleSettings.Rows[i].Cells["Delete"].ReadOnly = !Convert.ToBoolean(Convert.ToInt32(loginRole[i].ToCharArray()[3].ToString()));
                    }
                }

                if (ui_ncmbBrokerType.SelectedItem.ToString() == "STM")
                {
                    ui_ndgvRoleSettings.Rows[8].Cells["Add"].ReadOnly = true;
                    ui_ndgvRoleSettings.Rows[8].Cells["Edit"].ReadOnly = true;
                    ui_ndgvRoleSettings.Rows[8].Cells["Add"].Value = false;
                    ui_ndgvRoleSettings.Rows[8].Cells["Edit"].Value = false;
                }
            }
        }

        bool _showMsg = true;
        private void ui_ndgvSymbolGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (CurrentyDialogType == DialogType.Edit && _showMsg)
            {
                string msg = "Are you want to edit " + ui_ndgvSymbolGrid.Columns[e.ColumnIndex].HeaderText;
                clsDialogBox.ShowMessageBox(msg, "Broker");
                _showMsg = false;
            }
        }

        private void ui_ncmbBrokerParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerParent.SelectedItem != null)
            {
                ui_ntpRoles.Enabled = true;
            }
        }

        private void ui_ncmbSecurityType_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (ui_ncmbSecurityType.Text == "All")
            {
               // ui_dtgSymbol.DataSource = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation;
                return;
            }

            //if (ui_ncmbSecurityType.Text != "All" && ui_ncmbProductName.Text != "All")
            //{
            //    DS4Symbol.dtContractInformationRow[] selectedRows = Cls.clsSymbolManager.INSTANCE.GetCSInfoByProductandSecurity(ui_ncmbSecurityType.Text, ui_ncmbProductName.Text);
            //    //FilledSortedDataToGrid(selectedRows);
            //    return;
            //}

            //DS4Symbol.dtContractInformation
        }

        private void ui_nrbtAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            //if (ui_nrbtAbsolute.Checked)
            //{
            //    _isRelative = false;
            //}
            //else
            //{
            //    _isRelative = true;
            //}
        }

        private void ui_ndgvSymbolGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.FormattedValue)
            //{

            //}
        }
       
        private void ui_ndgvSymbolGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ui_ndgvSymbolGrid.EditingControl.KeyPress -= EditingControl_KeyPress;
            ui_ndgvSymbolGrid.EditingControl.KeyPress += EditingControl_KeyPress;
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control editingControl = (Control)sender;
            if (e.KeyChar == '-' && editingControl.Text.Contains('-'))
            {
                e.Handled = true;
                return;
            }
            if (!char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {                
                if (!Regex.IsMatch(editingControl.Text + e.KeyChar, pattern))
                    e.Handled = true;
            }
        }

    }
}
