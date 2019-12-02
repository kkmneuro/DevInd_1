using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocolStructs.NewPS;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Gateway info 
    /// </summary>
    public partial class uctlGateway : UserControl
    {
        public DialogType currentyDialogType;
        int tradingGatewayId;
        //Dictionary<string, string> _DDMappingTable = new Dictionary<string, string>();
        List<clsSymbolMapping> _lstMapping = new List<clsSymbolMapping>();
        public uctlGateway()
        {
            InitializeComponent();

            clsTradingGatewayManager.INSTANCE.UpdateTGAccountConnetionSettins += new Action(INSTANCE_UpdateTGAccountConnetionSettins);
        }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            ValidateSubmitInformation();
        }

        /// <summary>
        /// validate information for submission
        /// </summary>
        private void ValidateSubmitInformation()
        {
            if (ui_ntxtName.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter the Trading Gateway Name.", "Trading Gateway Error", true);
                ui_ntxtName.Focus();
                return;
            }
            if (ui_ntxtPort.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Trading Gateway Port Number.", "Trading Gateway Error", true);
                ui_ntxtPort.Focus();
                return;
            }
            if (ui_ncmbDataType.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please Select Trading Gateway Data Type.", "Trading Gateway Error", true);
                ui_ncmbDataType.Focus();
                return;
            }
            if (ui_ntxtServerIP.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Trading Gateway Server IP.", "Trading Gateway Error", true);
                ui_ntxtServerIP.Focus();
                return;
            }
            if (Cls.clsGlobal.ValidateIP(ui_ntxtServerIP.Text) == false)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter a valid Trading Gateway Server IP.", "Trading Gateway Error", true);
                ui_ntxtServerIP.Focus();
                return;
            }

            if (ui_ntxtLogin.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Trading Gateway Login ID.", "Trading Gateway Error", true);
                ui_ntxtLogin.Focus();
                return;
            }
            if (ui_ntxtPassword.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Trading Gateway Password.", "Trading Gateway Error", true);
                ui_ntxtPassword.Focus();
                return;
            }
            SubmitInformation();
            //this.ParentForm.Close();
        }
        /// <summary>
        /// Summits the information for processing
        /// </summary>
        private void SubmitInformation()
        {
            string errorMsg;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlGateway : Enter SubmitInformation()");
                clsTradingGateway objclsTradingGateway = new clsTradingGateway();
                objclsTradingGateway.IsEnable = ui_nchkIsEnable.Checked;
                objclsTradingGateway.Name = ui_ntxtName.Text;
                objclsTradingGateway.Description = ui_ntxtDescription.Text;
                objclsTradingGateway.Login = ui_ntxtLogin.Text;
                objclsTradingGateway.Password = ui_ntxtPassword.Text;
                objclsTradingGateway.Port = ui_ntxtPort.Text;
                objclsTradingGateway.Attempts = clsUtility.GetInt(ui_ntxtAttempts.Text);
                objclsTradingGateway.ServerIP = ui_ntxtServerIP.Text;
                objclsTradingGateway.SleepFor = clsUtility.GetInt(ui_ntxtSleepFor.Text);
                objclsTradingGateway.DataType = ui_ncmbDataType.Text;
                objclsTradingGateway.IdleTimeOut = clsUtility.GetInt(ui_ncmbIdleTimeout.Text);
                objclsTradingGateway.ReconnectAfter = clsUtility.GetInt(ui_ncmbReconnectAfter.Text);
                objclsTradingGateway.EnableRMS = ui_nchkEnableRMS.Checked;
                objclsTradingGateway.OrderPort = clsUtility.GetInt(ui_ntxtOrderPort.Text);
                objclsTradingGateway.OrderIP = clsUtility.GetStr(ui_ntxtOrderIP.Text);

                List<string> lstSymbols = new List<string>();
                //foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                //{
                //    if (Convert.ToBoolean(item.Cells[1].Value) == true)
                //    {
                //        lstSymbols.Add(item.Cells[2].Value.ToString());
                //    }
                //}
                //objclsTradingGateway.LstSymbol = lstSymbols.ToArray();
                List<string> lstSymbolAlias = new List<string>();
                List<decimal> lstSymbolConversionFormula = new List<decimal>();
                List<string> lstProductName = new List<string>();
                List<string> lstProductAlias = new List<string>();
                foreach (DataGridViewRow item2 in ui_ndgvMapping.Rows)
                {
                    lstSymbols.Add(item2.Cells[0].Value.ToString());
                    if (item2.Cells[1].Value != null && item2.Cells[1].Value.ToString() != "")
                        lstSymbolAlias.Add(item2.Cells[1].Value.ToString());
                    else
                        lstSymbolAlias.Add("");

                    if (item2.Cells[4].Value.ToString() != string.Empty)
                        lstSymbolConversionFormula.Add(clsUtility.GetDecimal(item2.Cells[4].Value.ToString()));
                    else
                        lstSymbolConversionFormula.Add(0);

                    if (item2.Cells[2].Value != null && item2.Cells[2].Value.ToString() != "")
                        lstProductName.Add(item2.Cells[2].Value.ToString());
                    else
                        lstProductName.Add("");

                    if (item2.Cells[3].Value != null && item2.Cells[3].Value.ToString() != "")
                        lstProductAlias.Add(item2.Cells[3].Value.ToString());
                    else
                        lstProductAlias.Add("");
                }
                if (lstSymbols.Count > lstSymbolAlias.Count)
                {
                    clsDialogBox.ShowErrorBox("Please first click save and then ok", "Trading Gateway Error", true);
                    return;
                }
                objclsTradingGateway.LstSymbol = lstSymbols.ToArray();
                objclsTradingGateway.LstSymbolAlias = lstSymbolAlias.ToArray();
                objclsTradingGateway.LstSymbolConversionFormula = lstSymbolConversionFormula.ToArray();
                objclsTradingGateway.LstProductName = lstProductName.ToArray();
                objclsTradingGateway.LstProductAlias = lstProductAlias.ToArray();

                string opMsg;
                clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
           
                if (currentyDialogType == DialogType.Edit)
                {
                    opMsg = "Edited Trading Gateway record of GatewayName : " + objclsTradingGateway.Name +".";//+ "and ID" + 
                        //objclsTradingGateway.PKTradingGateWaysID+" Name :"+objclsTradingGateway.Name+" Server IP :"+objclsTradingGateway.ServerIP
                        //+" Order Port :"+objclsTradingGateway.OrderPort+" Order IP :"+objclsTradingGateway.OrderIP;
                    errorMsg = "Error in updating TradingGateway";
                    objclsTradingGateway.PKTradingGateWaysID = tradingGatewayId;
                    objclsTradingGateway = clsProxyClassManager.INSTANCE.UpdateTradingGateway(objclsTradingGateway);
                    objclsBrokerOpLog.OperationName = "Trading Gateway updated";
                }
                else
                {
                    opMsg = "Added Trading Gateway, GatewayName : " + objclsTradingGateway.Name + ".";//and ID" + objclsTradingGateway.PKTradingGateWaysID;
                    objclsBrokerOpLog.OperationName = "Trading Gateway added";
                    errorMsg = "Error in inserting TradingGateway";
                    objclsTradingGateway.PKTradingGateWaysID = ProtocolStructIDS.DBInsert;
                    objclsTradingGateway = clsProxyClassManager.INSTANCE.InsertTradingGateway(objclsTradingGateway);
                }

                if (objclsTradingGateway.ServerResponseID != clsGlobal.FailureID)
                {
                    {
                        //clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                        //objclsBrokerOpLog.OperationName = currentyDialogType.ToString();
                        //objclsBrokerOpLog.ControlName = "Contract Sepcification";
                        objclsBrokerOpLog.Message = opMsg;
                        clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                    }
                   //clsTradingGatewayManager.INSTANCE.DoHandleTradingGatewayTable(objclsTradingGateway);
                   System.Threading.ThreadPool.QueueUserWorkItem(ProcessTGResponse, objclsTradingGateway);
                }
                else if (objclsTradingGateway.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }

                this.ParentForm.Close();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlGateway =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SubmitInformation()");
            }
        }

        public void ProcessTGResponse(object obj)
        {
            clsTradingGatewayManager.INSTANCE.DoHandleTradingGatewayTable(obj as clsTradingGateway);
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// Sets values of the components of the user control
        /// </summary>
        /// <param name="ds4TradingGateway"></param>
        /// <param name="tradingGatewayRow"></param>
        /// <param name="dialogType"></param>
        public void SetValues(DS4TradingGateway ds4TradingGateway, DS4TradingGateway.dtTradingGatewayRow tradingGatewayRow, DialogType dialogType)
        {
            currentyDialogType = dialogType;

            if (dialogType == DialogType.Edit)
            {
                tradingGatewayId = tradingGatewayRow.PK_TradingGateWaysID;
                ui_nchkIsEnable.Checked = tradingGatewayRow.IsEnable;
                ui_ntxtName.Text = tradingGatewayRow.Name;
                ui_ntxtDescription.Text = tradingGatewayRow.Description;
                ui_ntxtLogin.Text = tradingGatewayRow.Login;
                ui_ntxtPassword.Text = tradingGatewayRow.Password;
                ui_ntxtPort.Text = tradingGatewayRow.Port;
                ui_ntxtAttempts.Text = tradingGatewayRow.Attempts.ToString();
                ui_ntxtServerIP.Text = tradingGatewayRow.Server_IP.ToString();
                ui_ntxtSleepFor.Text = tradingGatewayRow.SleepFor.ToString();
                ui_ncmbDataType.SelectedIndex = ui_ncmbDataType.Items.IndexOf(tradingGatewayRow.DataType);
                ui_ncmbIdleTimeout.Text = tradingGatewayRow.IdleTimeOut.ToString();
                ui_ncmbReconnectAfter.Text = tradingGatewayRow.ReconnectAfter.ToString();
                ui_nchkEnableRMS.Checked = tradingGatewayRow.EnableRMS;

                ui_ndgvSymbols.Rows.Clear();
                DS4TradingGateway.dtSymbolRow[] symbols = (DS4TradingGateway.dtSymbolRow[])Cls.clsTradingGatewayManager.INSTANCE.GetSymbolsRow(tradingGatewayRow.PK_TradingGateWaysID);
                ui_ndgvSymbols.Columns.Add("ui_clmFKTradingGateway", "FK_TradingGatewayID");
                DataGridViewCheckBoxColumn objDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                objDataGridViewCheckBoxColumn.Name = "ui_clmSelect";
                objDataGridViewCheckBoxColumn.HeaderText = "Select";
                ui_ndgvSymbols.Columns.Add(objDataGridViewCheckBoxColumn);
                ui_ndgvSymbols.Columns.Add("ui_clmSymbol", "Symbol");
                ui_ndgvSymbols.Columns.Add("ui_clmSymbolAlias", "SymbolAlias");
                ui_ndgvSymbols.Columns.Add("ui_clmProductName", "ProductName");
                ui_ndgvSymbols.Columns.Add("ui_clmProductAlias", "ProductAlias");
                ui_ndgvSymbols.Columns.Add("ui_clmSymbolConversionFormula", "SymbolConversionFormula");
                ui_ndgvSymbols.Columns["ui_clmSymbolAlias"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmFKTradingGateway"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmSymbolConversionFormula"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmProductName"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmProductAlias"].Visible = false;
                //foreach (DS4TradingGateway.dtSymbolRow item in symbols)
                //{
                //    ui_ndgvSymbols.Rows.Add(tradingGatewayRow.PK_TradingGateWaysID, item.Select, item.Symbol, item.SymbolAlias);
                //}
                ui_ntxtOrderPort.Text = tradingGatewayRow.OrderPort.ToString();
                ui_ntxtOrderIP.Text = tradingGatewayRow.OrderIP;
                AddNewFunctionality();  //commented by vijay

                foreach (DS4TradingGateway.dtSymbolRow item in symbols)
                {
                    foreach (DataGridViewRow item2 in ui_ndgvSymbols.Rows)
                    {
                        if (item2.Cells[2].Value.ToString() == item.Symbol)
                        {
                            item2.Cells[3].Value = item.SymbolAlias;
                            item2.Cells[1].Value = true;
                            item2.Cells[4].Value = item.SymbolConversionFormula;
                            item2.Cells[5].Value = item.ProductName;
                            item2.Cells[6].Value = item.ProductAlias;
                        }
                    }
                }

                SetValuesToMapping();

                foreach (DS4TradingGateway.dtAccountConnectionSettingsRow TGAccountConnetionS in clsTradingGatewayManager.INSTANCE.GetTGAccountConnetionSettings(tradingGatewayRow.PK_TradingGateWaysID))
                {
                    ui_ndgvAccountConnectionSettings.Rows.Add(TGAccountConnetionS.AccountID, TGAccountConnetionS.Password, TGAccountConnetionS.IsEnable);
                }
            }
            else
            {
                ui_ndgvSymbols.Rows.Clear();

                ui_ndgvSymbols.Columns.Add("ui_clmFKTradingGateway", "FK_TradingGatewayID");
                DataGridViewCheckBoxColumn objDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                objDataGridViewCheckBoxColumn.Name = "ui_clmSelect";
                objDataGridViewCheckBoxColumn.HeaderText = "Select";
                ui_ndgvSymbols.Columns.Add(objDataGridViewCheckBoxColumn);
                ui_ndgvSymbols.Columns.Add("ui_clmSymbol", "Symbol");
                ui_ndgvSymbols.Columns.Add("ui_clmSymbolAlias", "SymbolAlias");
                ui_ndgvSymbols.Columns.Add("ui_clmProductName", "ProductName");
                ui_ndgvSymbols.Columns.Add("ui_clmProductAlias", "ProductAlias");
                ui_ndgvSymbols.Columns["ui_clmSymbolAlias"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmFKTradingGateway"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmProductName"].Visible = false;
                ui_ndgvSymbols.Columns["ui_clmProductAlias"].Visible = false;

                AddNewFunctionality();   //commented by vijay on 08 April
                //ui_ndgvSymbols.DataSource = ds4TradingGateway.dtSymbol;
                //ui_ndgvSymbols.Columns["FK_TradingGatewayID"].Visible = false;
                //ui_ndgvSymbols.Columns["SymbolAlias"].Visible = false;
            }
            //foreach (BrokerSymbol symbol in Cls.clsBrokersManagerHandler.INSTANCE._lstTotalSymbols)
            //{
            //    ui_ndgvSymbols.Rows.Add(symbol.SymbolID, false, symbol.SymbolName);
            //}

        }

        public void AddNewFunctionality()
        {
            foreach (KeyValuePair<int, string> symbol in Cls.clsMasterInfoManager.INSTANCE._DDSymbols)//Cls.clsBrokersManagerHandler.INSTANCE._lstTotalSymbols)
            {
                ui_ndgvSymbols.Rows.Add(symbol.Key, false, symbol.Value);
            }

            #region "    Commented by vijay 08 April    "
            //List<string> lstSymbols = new List<string>();
            //List<string> lstSymbolsAlias = new List<string>();
            //List<int> lstKeys = new List<int>();
            //List<bool> lstChecked = new List<bool>();
            //foreach (DS4TradingGateway.dtSymbolRow item in Cls.clsTradingGatewayManager.INSTANCE._DS4TradingGateway.dtSymbol.Rows)
            //{
            //    if (!lstSymbols.Contains(item.Symbol))
            //    {
            //        lstSymbols.Add(item.Symbol);
            //        //lstSymbolsAlias.Add(item.SymbolAlias);
            //        lstKeys.Add(item.FK_TradingGatewayID);
            //        lstChecked.Add(item.Select);
            //    }
            //}

            //for (int i = 0; i < lstSymbols.Count; i++)
            //{
            //    ui_ndgvSymbols.Rows.Add(lstKeys[i], lstChecked[i], lstSymbols[i], ""); //lstSymbolsAlias[i]);
            //}

            #endregion "    Commented by vijay 08 April    "
        }

        private void ui_ntpMapping_Paint(object sender, PaintEventArgs e)
        {
            if (_lstMapping.Count == 0)
            {
                return;
            }

            ui_ndgvMapping.Rows.Clear();


            foreach (clsSymbolMapping item in _lstMapping)
            {
                ui_ndgvMapping.Rows.Add(item.Symbol, item.SymbolAlieas,item.ProductName,item.ProductAlias, item.SymbolConversionFormula);
            }
        }

        public void UpdateMappingGrid()
        {
            ui_ndgvMapping.Rows.Clear();


            foreach (clsSymbolMapping item in _lstMapping)
            {
                ui_ndgvMapping.Rows.Add(item.Symbol, item.SymbolAlieas,item.ProductName,item.ProductAlias ,item.SymbolConversionFormula);
            }
        }

        /// <summary>
        /// Saves symbols info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnSymbolsSave_Click(object sender, EventArgs e)
        {
            if (currentyDialogType == DialogType.Edit)
            {
                ui_ndgvMapping.Rows.Clear();
                ui_ndgvMapping.DataSource = null;
                //_DDMappingTable.Clear();
                foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value) == true)
                    {
                        if (_lstMapping.Find(lstItem => lstItem.Symbol == item.Cells[2].Value.ToString()) == null)//!_DDMappingTable.ContainsKey(item.Cells[2].Value.ToString()))
                        {
                            clsSymbolMapping objclsSymbolMapping = new clsSymbolMapping();
                            objclsSymbolMapping.Symbol = item.Cells[2].Value.ToString();
                            objclsSymbolMapping.SymbolAlieas = string.Empty;
                            objclsSymbolMapping.SymbolConversionFormula = 0;
                            objclsSymbolMapping.ProductName = string.Empty;
                            objclsSymbolMapping.ProductAlias = string.Empty;
                            _lstMapping.Add(objclsSymbolMapping);
                        }
                        //ui_ndgvMapping.Rows.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString());
                    }
                    else
                    {
                        _lstMapping.Remove(_lstMapping.Find(lstItem => lstItem.Symbol == item.Cells[2].Value.ToString())); //_DDMappingTable.Remove(item.Cells[2].Value.ToString());
                    }
                }
                UpdateMappingGrid();
            }
            else
            {
                foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value) == true)
                    {
                        //if (!_DDMappingTable.ContainsKey(item.Cells[2].Value.ToString()))
                        //{
                        //    _DDMappingTable.Add(item.Cells[2].Value.ToString(), "");
                        //}
                        if (_lstMapping.Find(lstItem => lstItem.Symbol == item.Cells[2].Value.ToString()) == null)
                        {
                            clsSymbolMapping objclsSymbolMapping = new clsSymbolMapping();
                            objclsSymbolMapping.Symbol = item.Cells[2].Value.ToString();
                            objclsSymbolMapping.SymbolAlieas = string.Empty;
                            objclsSymbolMapping.SymbolConversionFormula = 0;
                            objclsSymbolMapping.ProductName = string.Empty;
                            objclsSymbolMapping.ProductAlias = string.Empty;
                            _lstMapping.Add(objclsSymbolMapping);
                        }
                    }
                    if (Convert.ToBoolean(item.Cells[1].Value) == false)
                    {
                        _lstMapping.Remove(_lstMapping.Find(lstItem => lstItem.Symbol == item.Cells[2].Value.ToString()));//_DDMappingTable.Remove(item.Cells[2].Value.ToString());
                    }
                }
                UpdateMappingGrid();
            }
        }
        /// <summary>
        /// Saves mapping info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnMappingSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in ui_ndgvMapping.Rows)
            {
                clsSymbolMapping objclsSymbolMapping = _lstMapping.Find(lstItem => lstItem.Symbol == item.Cells[0].Value.ToString());

                if (item.Cells[1].Value == null)
                {
                    if (objclsSymbolMapping != null)
                    {
                        objclsSymbolMapping.SymbolAlieas = string.Empty;
                        objclsSymbolMapping.SymbolConversionFormula = 0;
                        objclsSymbolMapping.ProductName = string.Empty;
                        objclsSymbolMapping.ProductAlias = string.Empty;
                        //_lstMapping.Add(objclsSymbolMapping);
                    }//_DDMappingTable[item.Cells[0].Value.ToString()] = "";
                }
                else
                {
                    if (objclsSymbolMapping != null)
                    {
                        objclsSymbolMapping.SymbolAlieas = item.Cells[1].Value.ToString();
                        objclsSymbolMapping.SymbolConversionFormula = clsUtility.GetDecimal(item.Cells[2].Value);
                        //_lstMapping.Add(objclsSymbolMapping);
                    }
                    //_DDMappingTable[item.Cells[0].Value.ToString()] = item.Cells[1].Value.ToString();
                }
            }
        }
        /// <summary>
        /// loads intiial settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlGateway_Load(object sender, EventArgs e)
        {

            ui_ntcControlContainer.SelectedIndex = 0;
            //ui_ncmbDataType.Items.AddRange(Cls.clsTradingGatewayManager.INSTANCE.GetDataTypeArray());
            ui_ncmbIdleTimeout.Items.AddRange(Cls.clsTradingGatewayManager.INSTANCE.GetIdleTimeOutArray());
            ui_ncmbReconnectAfter.Items.AddRange(Cls.clsTradingGatewayManager.INSTANCE.GetReconnectAfterArray());
            ui_ncmbSecurityType.Items.AddRange(Cls.clsSecurityManager.INSTANCE.GetSecurityNameArray());
            ui_ncmbSecurityType.SelectedIndex = 0;
            if (currentyDialogType == DialogType.Edit || currentyDialogType == DialogType.View)
            {
                //foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                //{
                //    if (Convert.ToBoolean(item.Cells[1].Value) == true)
                //    {
                //        ui_ndgvMapping.Rows.Add(item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString());
                //    }
                //}
            }
            else
            {
                foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value) == true)
                    {
                        ui_ndgvMapping.Rows.Add(item.Cells[2].Value.ToString(), "");
                    }
                }
            }
        }
        /// <summary>
        /// saves values to mapping table
        /// </summary>
        public void SetValuesToMapping()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlGateway : Enter SetValuesToMapping()");

                if (currentyDialogType == DialogType.Edit)
                {
                    ui_ndgvMapping.Columns["ui_clmProductName"].ReadOnly = true;
                    //ui_ndgvMapping.Columns["ui_clmProductAlias"].ReadOnly = true;
                }

                if (currentyDialogType == DialogType.Edit)
                {
                    foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value) == true)
                        {
                            ui_ndgvMapping.Rows.Add(item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString(),item.Cells[5].Value.ToString(),
                                item.Cells[6].Value.ToString(), item.Cells[4].Value);

                            clsSymbolMapping objclsSymbolMapping = new clsSymbolMapping();
                            objclsSymbolMapping.Symbol = item.Cells[2].Value.ToString();
                            objclsSymbolMapping.SymbolAlieas = item.Cells[3].Value.ToString();
                            objclsSymbolMapping.SymbolConversionFormula = clsUtility.GetDecimal(item.Cells[4].Value);
                            objclsSymbolMapping.ProductName = item.Cells[5].Value.ToString();
                            objclsSymbolMapping.ProductAlias = item.Cells[6].Value.ToString();

                            _lstMapping.Add(objclsSymbolMapping);

                            //_DDMappingTable.Add(item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString());
                        }
                    }
                }
                //else
                //{
                //    foreach (DataGridViewRow item in ui_ndgvSymbols.Rows)
                //    {
                //        if (Convert.ToBoolean(item.Cells[1].Value) == true)
                //        {
                //            ui_ndgvMapping.Rows.Add(item.Cells[2].Value.ToString(), "");
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlGateway =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SetValuesToMapping()");
            }
        }

        private void ui_ntxtServerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
        /// <summary>
        /// Adds new gateway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_tsmAdd_Click(object sender, EventArgs e)
        {
            uctlAccountConnectionSettings objACSettings = new uctlAccountConnectionSettings();
            objACSettings.currentyDialogType = DialogType.New;
            objACSettings.OnOkClick += new Action<string, string, bool, DialogType>(objACSettings_OnOkClick);
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.ClientSize = objACSettings.Size;
            objfrmCommonContainer.Controls.Add(objACSettings);
            objfrmCommonContainer.ShowDialog();
        }

        /// <summary>
        /// Saves gateway
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="password"></param>
        /// <param name="isEnable"></param>
        /// <param name="dialogMode"></param>
        void objACSettings_OnOkClick(string accountId, string password, bool isEnable, DialogType dialogMode)
        {
            string errorMsg = string.Empty;
            ProtocolStructs.NewPS.clsTGAccountConnectionSettingsPS objTGAConnectionSettingsPS = new ProtocolStructs.NewPS.clsTGAccountConnectionSettingsPS();
            BOADMIN_NEW.BOEngineServiceTCP.clsTGAccountConnectionSettings objTGACS = new BOADMIN_NEW.BOEngineServiceTCP.clsTGAccountConnectionSettings();

            objTGACS.TGID = clsUtility.GetInt(tradingGatewayId);
            objTGACS.AccountId = clsUtility.GetStr(accountId);
            objTGACS.Password = clsUtility.GetStr(password);
            objTGACS.IsEnable = Convert.ToBoolean(isEnable);

            if (dialogMode == DialogType.New)
            {
                errorMsg = "Error in Inserting TGAccountConnectionSettings";

                objTGACS = clsProxyClassManager.INSTANCE.InsertTGAccountConnectionSettings(objTGACS);
            }
            else
            {
                errorMsg = "Error in Updating TGAccountConnectionSettings";

                objTGACS = clsProxyClassManager.INSTANCE.UpdateTGAccountConnectionSettings(objTGACS);
            }

            if (objTGACS.ServerResponseID != clsGlobal.FailureID)
            {
                clsTradingGatewayManager.INSTANCE.DoHandleAccountConnectionSettings(objTGACS);
            }
            else if (objTGACS.ServerResponseID == clsGlobal.FailureID)
            {
                clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
            }
        }

        /// <summary>
        /// Edit gateway information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_tsmEdit_Click(object sender, EventArgs e)
        {
            uctlAccountConnectionSettings objACSettings = new uctlAccountConnectionSettings();
            objACSettings.currentyDialogType = DialogType.Edit;
            objACSettings.OnOkClick += new Action<string, string, bool, DialogType>(objACSettings_OnOkClick);
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.ClientSize = objACSettings.Size;
            objfrmCommonContainer.Controls.Add(objACSettings);
            objACSettings.SetValues(ui_ndgvAccountConnectionSettings.SelectedRows[0]);
            objfrmCommonContainer.ShowDialog();
        }


        void INSTANCE_UpdateTGAccountConnetionSettins()
        {
            Action A = () =>
                {
                    ui_ndgvAccountConnectionSettings.Rows.Clear();
                    foreach (DS4TradingGateway.dtAccountConnectionSettingsRow TGAccountConnetionS in clsTradingGatewayManager.INSTANCE.GetTGAccountConnetionSettings(tradingGatewayId))
                    {
                        ui_ndgvAccountConnectionSettings.Rows.Add(TGAccountConnetionS.AccountID, TGAccountConnetionS.Password, TGAccountConnetionS.IsEnable);
                    }
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void ui_ndgvAccountConnectionSettings_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles mouse down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvAccountConnectionSettings_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hInfo = ui_ndgvAccountConnectionSettings.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Left && hInfo.RowIndex >= 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    ui_tsmEdit_Click(null, null);
                }
            }
            if (e.Button == MouseButtons.Right && hInfo.RowIndex < 0)
            {
                ui_tsmEdit.Enabled = false;
            }
            else
            {
                ui_tsmEdit.Enabled = true;
            }
        }

        private void ui_ndgvMapping_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        bool _showMsg = true;
        private void ui_ndgvMapping_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (currentyDialogType == DialogType.Edit && _showMsg==true)
            {
                string msg = string.Empty;
                msg = "Are you want to edit";
                //switch (ui_ndgvMapping.Columns[e.ColumnIndex].Name)
                //{
                //    case "ui_clmSymbol":
                //        {
                //            msg="Are you want to edit Symbol ?";
                //        }
                //        break;
                //    case "ui_clmSymbolAlias":
                //        {
                //            msg = "Are you want to edit Symbol Alias ?";
                //        }
                //        break;
                //    case "ui_clmProductAlias":
                //        {
                //            msg = "Are you want to edit Product Alias ?";
                //        }
                //        break;
                //    case "ui_clmSymbolConversionFormula":
                //        {
                //            msg = "Are you want to edit Symbol Conversion Formula ?";
                //        }
                //        break;
                //}
                clsDialogBox.ShowMessageBox(msg, "Trading Gateway");
                _showMsg = false;
            }
        }
    }

    public class clsSymbolMapping
    {
        public string Symbol { get; set; }
        public string SymbolAlieas { get; set; }
        public decimal SymbolConversionFormula { get; set; }
        public string ProductName { get; set; }
        public string ProductAlias { get; set; }
    }
}
