using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
using ProtocolStructs;
using clsInterface4OME;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlProductContracts : uctlGeneric, Interfaces.IUserCtrl
    {

        public DS4Symbol.dtContractInformationRow _row = null;
        // uctlSymbolChildSession _objUcSymbolChildSession = new uctlSymbolChildSession();
        public Symbol _SymbolSettings = null;
        public int _SymbolId = 999;
        public DialogType currentyDialogType;
        private string _ContractName = string.Empty;
        public uctlProductContracts()
        {
            InitializeComponent();
        }

        public void InitControls(DialogType dialogType)
        {
            currentyDialogType = dialogType;
            //InitControls();
            switch (dialogType)
            {
                case DialogType.View:
                    ViewDialogHandler();
                    break;
                case DialogType.AddContract:
                    AddContractDialogHandler();
                    break;
                case DialogType.Edit:
                    EditDialogHandler();
                    break;
                case DialogType.New:
                    NewDialogHandler();
                    break;
                default:
                    break;
            }
        }

        private void NewDialogHandler()
        {
            //ui_uctlContractInformation.ClearControlsText();
            ui_uctlContractInformation.ui_ncmbBaseValueUnit.SelectedIndex = 0;
            ui_uctlContractInformation.ui_ncmbDeliveryUnit.SelectedIndex = 0;
            ui_uctlContractInformation.ui_ncmbMarketLotsUnit.SelectedIndex = 0;
            ui_uctlContractInformation.ui_ncmbMaxLotsUnit.SelectedIndex = 0;
            ui_uctlContractInformation.ui_ncmbMarginCurrency.SelectedIndex = this.ui_uctlContractInformation.ui_ncmbMarginCurrency.Items.IndexOf("NPR");
            ui_uctlContractInformation.ui_ncmbSetlingCurrency.SelectedIndex = this.ui_uctlContractInformation.ui_ncmbSetlingCurrency.Items.IndexOf("NPR");
            ui_uctlContractInformation.ui_ncmbTradingCurrecny.SelectedIndex = this.ui_uctlContractInformation.ui_ncmbTradingCurrecny.Items.IndexOf("NPR");
            ui_uctlSession.InitControls();
        }

        private void EditDialogHandler()
        {
            InitControls();
        }

        private void AddContractDialogHandler()
        {
            InitControls();
        }

        private void ViewDialogHandler()
        {
            InitControls();
            ui_uctlContractInformation.Enabled = false;
            ui_uctlSession.Enabled = false;
        }

        private void uctlProductContracts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }
        }

        public void DisableTabs()
        {

        }

        private void ui_ntcProductContracts_Load(object sender, EventArgs e)
        {
            //InitControls();
        }

        private void InitControls()
        {
            if (_row == null)
            {
                ui_uctlContractInformation.SetValues(null);
                ui_uctlSession.InitControls();
                return;
            }
            _SymbolId = _row.InstrumentID;
            DS4Symbol.dtContractInformationRow SymbolRow = clsSymbolManager.INSTANCE._DS4Symbol.dtContractInformation.FindByInstrumentID(_SymbolId);
            _ContractName = SymbolRow.Symbol;
            ui_uctlContractInformation.SetValues(SymbolRow);
            ui_uctlSession._SymbolRow = SymbolRow;
            DS4Symbol.dtInstrumentSwapsRow swapRow = clsSymbolManager.INSTANCE._DS4Symbol.dtInstrumentSwaps.FirstOrDefault(a => a.FK_InstrumentID == SymbolRow.InstrumentID);

            if (swapRow != null)
            {
                ui_chkEnable.Checked = swapRow.IsEnable;
                ui_txtLongPosition.Text = swapRow.LongPosition.ToString();
                ui_txtShortPositions.Text = swapRow.ShortPosition.ToString();
                ui_ntxtSymbolName.Text = SymbolRow.Symbol;                
            }

            ui_uctlSession.InitControls();
            if (SymbolRow != null)
            {
                ui_uctlContractInformation.ui_nupQuoteUD.Value = SymbolRow.QuoteOffTime;
            }
        }

        private void ui_nbtSubmit_Click(object sender, EventArgs e)
        {
            ValidateSumbitInformation();
        }

        private void ValidateSumbitInformation()
        {
            if (ui_uctlContractInformation.ui_ntxtSymbol.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Symbol name.", "Contract Information Error", true);
                ui_ntcProductContracts.SelectedIndex = 0;
                ui_uctlContractInformation.ui_ntxtSymbol.Focus();
                return;
            }
            if (currentyDialogType == DialogType.New && clsSymbolManager.INSTANCE.ddSymbolIdSymbolName.Values.Contains(ui_uctlContractInformation.ui_ntxtSymbol.Text.Trim().ToUpper()))
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Symbol Already Exists, please enter a valid Symbol name.", "Contract Information Error", true);
                ui_ntcProductContracts.SelectedIndex = 0;
                ui_uctlContractInformation.ui_ntxtSymbol.Focus();
                return;
            }
            if (ui_uctlContractInformation.ui_ntxtSymbol.Text.Trim().ToUpper() == _ContractName.Trim().ToUpper() && currentyDialogType == DialogType.AddContract)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("This Contract name already exists, Please change the Contract name.", "Contract Information Error", true);
                ui_uctlContractInformation.ui_ntxtSymbol.Focus();
                return;
            }
            if (ui_uctlContractInformation.ui_ntxtSource.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please enter Source name.", "Contract Information Error", true);
                ui_ntcProductContracts.SelectedIndex = 0;
                ui_uctlContractInformation.ui_ntxtSource.Focus();
                return;
            }
            if (ui_uctlContractInformation.ui_ncmbSecurityType.Text == string.Empty)
            {
                DialogResult result = clsDialogBox.ShowErrorBox("Please select Security Type.", "Contract Information Error", true);
                ui_ntcProductContracts.SelectedIndex = 0;
                ui_uctlContractInformation.ui_ncmbSecurityType.Focus();
                return;
            }
            if (ui_uctlContractInformation.ui_ndtpExpiryDate.Value < DateTime.Now.Date)
            {
                clsDialogBox.ShowErrorBox("Expiry date should not be less than current date.", "Contract Information Error", true);
                return;
            }            
            
            SumbitInformation();
        }
        private void SumbitInformation()
        {
            string errorMsg;
            SymbolPS objSymbol = new SymbolPS();
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlProductContracts : Enter SumbitInformation()");
                #region "  Symbol   "
                clsContractSpecification objclsCS = new clsContractSpecification();
                objclsCS.SymbolName = ui_uctlContractInformation.ui_ntxtSymbol.Text.Trim();
                objclsCS.Description = ui_uctlContractInformation.ui_ntxtDescription.Text.Trim();
                objclsCS.Source = ui_uctlContractInformation.ui_ntxtSource.Text.Trim();
                objclsCS.Digits = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtDigits.Text);
                objclsCS.ULAssest = ui_uctlContractInformation.ui_ntxtULAssest.Text.Trim();
                objclsCS.TradingCurrency = Cls.clsCurrencyManager.INSTANCE.GetCurrencyId(ui_uctlContractInformation.ui_ncmbTradingCurrecny.Text).ToString();
                objclsCS.SettlingCurrency = Cls.clsCurrencyManager.INSTANCE.GetCurrencyId(ui_uctlContractInformation.ui_ncmbSetlingCurrency.Text).ToString();
                objclsCS.MarginCurrency = Cls.clsCurrencyManager.INSTANCE.GetCurrencyId(ui_uctlContractInformation.ui_ncmbMarginCurrency.Text).ToString();
                objclsCS.MaximumLots = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMaximumLots.Text);
                objclsCS.Maximum_Order_Value = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMaximumOrderValue.Text);
                objclsCS.BuySideTurnover = clsUtility.GetDecimal(ui_uctlContractInformation.ui_ntxtBuySideTurnover.Text);
                objclsCS.SellSideTurnover = clsUtility.GetDecimal(ui_uctlContractInformation.ui_ntxtSellSideTurnover.Text);
                objclsCS.MaximumAllowablePosition = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMaximumAllowablePosition.Text);
                objclsCS.QuotationBaseValue = ui_uctlContractInformation.ui_ntxtQuotationBaseValue.Text;
                objclsCS.DeliveryType = Cls.clsMasterInfoManager.INSTANCE.GetDeliveryTypeID(ui_uctlContractInformation.ui_ncmbDeliveryType.Text).ToString();
                objclsCS.DeliveryUnit = Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnitID(ui_uctlContractInformation.ui_ncmbDeliveryUnit.Text).ToString();
                objclsCS.DeliveryQuantity = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtDeliveryQuantity.Text);
                objclsCS.MarketLot = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMarketLot.Text);
                objclsCS.ExpiryDate = ui_uctlContractInformation.ui_ndtpExpiryDate.Value.ToString();
                objclsCS.StartDate = ui_uctlContractInformation.ui_ndtpStartDate.Value.ToString();
                objclsCS.EndDate = ui_uctlContractInformation.ui_ndtpEndDate.Value.ToString();
                objclsCS.TenderStartDate = ui_uctlContractInformation.ui_ndtpTenderStartDate.Value.ToString();
                objclsCS.TenderEndDate = ui_uctlContractInformation.ui_ndtpTenderEndDate.Value.ToString();
                objclsCS.DeliveryStartDate = ui_uctlContractInformation.ui_ndtpDeliveryStartDate.Value.ToString();
                objclsCS.DeliveryEndDate = ui_uctlContractInformation.ui_ndtpDeliveryEndDate.Value.ToString();
                objclsCS.DPRInitialPercentage = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtDPRInitialPercentage.Text);
                objclsCS.DPR_Range_Higher = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtDPRRangeHigher.Text);
                objclsCS.DPRInterval = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtDPRInterval.Text);
                objclsCS.LimitandStopLevel = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtLimtStopLevel.Text);
                objclsCS.FK_SecurityTypeID = Cls.clsSecurityManager.INSTANCE.GetSecuritiesId(ui_uctlContractInformation.ui_ncmbSecurityType.Text).ToString();
                objclsCS.ContractSize = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtContractSize.Text);
                objclsCS.InitialBuyMargin = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtInitialBuyMargin.Text);
                objclsCS.InitialSellMargin = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtInitialSellMargin.Text);
                objclsCS.MaintenanceBuyMargin = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMaintenanceBuyMargin.Text);
                objclsCS.MaintenanceSellMargin = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtMaintenanceSellMargin.Text);
                objclsCS.Hedged = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtHedged.Text.Trim());
                objclsCS.TickSize = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtTickSize.Text);
                objclsCS.TickPrice = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtTickPrice.Text);
                objclsCS.MaximumLostUnit = Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnitID(ui_uctlContractInformation.ui_ncmbMaxLotsUnit.Text).ToString();
                objclsCS.MarketLostUnit = Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnitID(ui_uctlContractInformation.ui_ncmbMarketLotsUnit.Text).ToString();
                objclsCS.QuotationBaseValueUnit = Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnitID(ui_uctlContractInformation.ui_ncmbBaseValueUnit.Text).ToString();
                objclsCS.Spread = clsUtility.GetInt(ui_uctlContractInformation.ui_ntxtSpread.Text);
                objclsCS.QuoteOffTime = clsUtility.GetInt(ui_uctlContractInformation.ui_nupQuoteUD.Value);

                #endregion Symbol

                #region Session

                objclsCS.SessionCount = ui_uctlSession.ui_dgvSession.Rows.Count;

                List<BOEngineServiceTCP.clsSymbolSession> lstSymbolSesssion = new List<clsSymbolSession>();
                for (int count = 0; count < objclsCS.SessionCount; count++)
                {
                    clsSymbolSession sess = new clsSymbolSession();
                    //sess.TradeSession = ui_uctlSession._dtSessionDataTable.Rows[count]["Trade"].ToString();
                    sess.TradeSession = ui_uctlSession._dtSessionDataTable.Rows[count]["Trade"].ToString();
                    sess.Day = (BOADMIN_NEW.BOEngineServiceTCP.DAYS)Enum.Parse(typeof(BOADMIN_NEW.BOEngineServiceTCP.DAYS), ui_uctlSession._dtSessionDataTable.Rows[count]["Day"].ToString(), true);
                    sess.QuoteSession = ui_uctlSession._dtSessionDataTable.Rows[count]["Quotes"].ToString();                    
                    sess.IsUseTimelimits = ui_uctlSession.ui_chkusetimelimit.Checked;
                    sess.StartDate = ui_uctlSession.ui_dtpStartDate.Value;
                    sess.EndDate = ui_uctlSession.ui_dtpEndDate.Value;
                    sess.SessionEODMarketMaker = ui_uctlSession._dtSessionDataTable.Rows[count]["SessionEODMM"].ToString();
                    lstSymbolSesssion.Add(sess);
                    Properties.Settings.Default.Save();
                }
                objclsCS.lstSession = lstSymbolSesssion.ToArray();

                #endregion " Session "

                #region "SWAPS"
                clsInstrumentSwaps objclsInstrumentSwaps = new clsInstrumentSwaps();
                ////objclsInstrumentSwaps.LongPosition = clsUtility.GetDecimal(ui_txtLongPosition.Text);
                ////objclsInstrumentSwaps.ShortPosition = clsUtility.GetDecimal(ui_txtShortPositions.Text);
                ////objclsInstrumentSwaps.IsEnable =Convert.ToBoolean(ui_chkEnable.Checked);

                objclsCS.InstrumentSwaps = objclsInstrumentSwaps;
                #endregion "SWAPS"

                //string opMsg;
                if (currentyDialogType == DialogType.Edit)
                {
                    //opMsg = "Edited Contract Specification record of SymbolName :" + objclsCS.SymbolName + "and SymbolID" + objclsCS.Instruement_ID
                    //    +" Symbol Name :"+objclsCS.SymbolName+" Source Name :"+objclsCS.Source+" Expiry Date:"+objclsCS.Source;
                    errorMsg = "Error in updating Contract Specification";
                    objclsCS.Instruement_ID = _SymbolId;
                    objclsCS = clsProxyClassManager.INSTANCE.UpdateCsInfo(objclsCS); //FrmMain.Instance._objContractSpec.UpdateContractSpecification(clsGlobal.userID, objclsCS);

                    if (ui_uctlContractInformation.prevDPR != objclsCS.DPR_Range_Higher)
                    {
                      //OrderServerManager.clsOrderServerManager.INSTANCE.ReloadDPRrange(objclsCS.FK_SecurityTypeID, objclsCS.Source, objclsCS.SymbolName, "ECX");
                    }
                }
                else
                {
                    //opMsg = "Inserted Contract Specification record of SymbolName :" + objclsCS.SymbolName + "and SymbolID" + objclsCS.Instruement_ID
                    //    + " Symbol Name :" + objclsCS.SymbolName + " Source Name :" + objclsCS.Source + " Expiry Date:" + objclsCS.Source;
                    errorMsg = "Error in inserting Contract Specification";
                    objclsCS.Instruement_ID = ProtocolStructIDS.DBInsert;
                    objclsCS = clsProxyClassManager.INSTANCE.InsertCsInfo(objclsCS); //FrmMain.Instance._objContractSpec.InsertIntoContractSpecification(clsGlobal.userID, objclsCS);
                }

                if (objclsCS.ServerResponseID != clsGlobal.FailureID)
                {

                    clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                    switch (currentyDialogType)
                    {

                        case DialogType.AddContract:
                            {
                                objclsBrokerOpLog.OperationName = "Contract Added";
                                objclsBrokerOpLog.Message = objclsCS.SymbolName + " Added.";
                            }
                            break;
                        case DialogType.Edit:
                            {
                                objclsBrokerOpLog.OperationName = "Contract Edited";
                                objclsBrokerOpLog.Message = objclsCS.SymbolName + "'s details edited.";
                            }
                            break;
                        case DialogType.New:
                            {
                                objclsBrokerOpLog.OperationName = "Contract Added";
                                objclsBrokerOpLog.Message = objclsCS.SymbolName + " Added.";
                            }
                            break;
                    }

                    //objclsBrokerOpLog.OperationName = currentyDialogType.ToString();
                    //objclsBrokerOpLog.ControlName = "Contract Sepcification";
                    //objclsBrokerOpLog.Message = opMsg;
                    clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);

                    clsSymbolManager.INSTANCE.DoHandleSymbolTable(objclsCS);
                }
                else if (objclsCS.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
                this.ParentForm.Close();

            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlProductContracts =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SumbitInformation()");
            }
        }

        public void ProcessCSResponse(object objSymbolPS)
        {
            SymbolPS ps = objSymbolPS as SymbolPS;
            clsDataManager.INSTANCE.HandleSocketData(ps);
        }
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uctlProductContracts_Load(object sender, EventArgs e)
        {
            ui_ntcProductContracts.TabPages.Remove(ui_ntpCharges);
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
