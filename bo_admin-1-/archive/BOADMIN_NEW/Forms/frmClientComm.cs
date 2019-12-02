using System;
using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Forms
{
    public partial class frmClientComm : FrmBase
    {     

        public frmClientComm()
        {
            InitializeComponent();           

            ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
            objSrchvalues.FromDateValue = DateTime.Now.Date;
            objSrchvalues.ToDateValue = DateTime.Now;
            objSrchvalues.Symbol = string.Empty;            
            GetReportData(objSrchvalues, ClientCommissionSearchType.BY_DATE);
        }

        private void ui_nbtnSearch1_Click(object sender, EventArgs e)
        {
            ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
            if (clsGlobal.BrokerID == 1)
            {
                objSrchvalues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objSrchvalues.BrokerParentID = 0;
            }
            else
            {
                if (ui_ntxtBrokerID.Text.Trim() == string.Empty)
                {
                    //objSrchvalues.BrokerID = Cls.clsGlobal.BrokerNameId;
                    //objSrchvalues.BrokerParentID = 0;
                }
                else
                {
                    objSrchvalues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objSrchvalues.BrokerParentID = Cls.clsGlobal.BrokerNameId;
                }
            }
            objSrchvalues.FromDateValue = clsUtility.GetDate(ui_ndtpDate.Value).Date;
            objSrchvalues.ToDateValue = clsUtility.GetDate(ui_ndtpTo.Value);
            objSrchvalues.AccountNumber = clsUtility.GetInt(ui_ntxtAccountNumber.Text);
            objSrchvalues.Symbol = clsUtility.GetStr(ui_ntxtSymbol.Text);
            GetReportData(objSrchvalues, ClientCommissionSearchType.BY_DATE_ACCOUNT_NUMBER_SYMBOL);
            
        }

        private void ui_ndtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
                if (clsGlobal.BrokerID != 1)
                {
                    objSrchvalues.BrokerID = Cls.clsGlobal.BrokerNameId;
                }
                objSrchvalues.FromDateValue = ui_ndtpDate.Value.Date;
                objSrchvalues.ToDateValue = ui_ndtpTo.Value;
                objSrchvalues.Symbol = string.Empty;
                GetReportData(objSrchvalues, ClientCommissionSearchType.BY_DATE);
                
            }
            catch (Exception)
            {

            }

        }

        private void frmClientComm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            
        }

        private void ui_ntxtAccountNumber_Leave(object sender, EventArgs e)
        {
            //ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
            //objSrchvalues.AccountNumber = Convert.ToInt32(ui_ntxtAccountNumber.Text);
            //objClientCommReport.GetReportData(objSrchvalues, ClientCommissionSearchType.BY_ACCOUNT_NUMBER);

            //ui_rptvClientComm.RefreshReport();
        }

        private void ui_ntxtSymbol_Leave(object sender, EventArgs e)
        {
            //ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
            //objSrchvalues.Symbol = ui_ntxtSymbol.Text;
            //objClientCommReport.GetReportData(objSrchvalues, ClientCommissionSearchType.BY_SYMBOL);

            //ui_rptvClientComm.RefreshReport();
        }

        private void ui_ndtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClientCommissionSearchValues objSrchvalues = new ClientCommissionSearchValues();
                if (clsGlobal.BrokerID != 1)
                {
                    objSrchvalues.BrokerID = Cls.clsGlobal.BrokerNameId;
                }
                objSrchvalues.FromDateValue = ui_ndtpDate.Value.Date;
                objSrchvalues.ToDateValue = ui_ndtpTo.Value;
                objSrchvalues.Symbol = string.Empty;
                GetReportData(objSrchvalues, ClientCommissionSearchType.BY_DATE);

                
            }
            catch (Exception)
            {
            }

        }

        public void GetReportData(ClientCommissionSearchValues searchValues, ClientCommissionSearchType searchType)//DateTime dateTime,TradeReportSearchType searchType)
        {            
            try
            {
                _objReportClient_GetClientCommmissionReportDataCompleted(Cls.clsProxyClassManager.INSTANCE._objReportClient.GetClientCommmissionReportData(
               Cls.clsGlobal.userIDPwd, searchValues, searchType));
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }         
        }

        void _objReportClient_GetClientCommmissionReportDataCompleted(clsClientCommission[] e)//object sender, GetClientCommmissionReportDataCompletedEventArgs e)
        {
            try
            {
                DS.DS4ClientComm objDS4ClientComm = new BOADMIN_NEW.DS.DS4ClientComm();

                foreach (clsClientCommission item in e)
                {
                    int contractSize = clsMasterInfoManager.INSTANCE.GetContractSize(item.Symbol);
                    
                    item.BuyQty = item.BuyQty / contractSize;                    
                    item.SellQty = item.SellQty / contractSize;                    
                    item.SettledQty = item.SettledQty / contractSize;                    
                    item.NetQty = item.NetQty / contractSize;                    

                    if (clsGlobal.BrokerID != 1 && (item.BrokerID == clsGlobal.BrokerNameId || clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(item.BrokerID)))
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4ClientComm.dtClientComm.AdddtClientCommRow(item.BrokerID, item.AccountID, item.Symbol.Trim(), item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BuyQty, item.BuyValue,
                                item.BuyAvg, item.SellQty, item.SellValue, item.SellAvg, item.SettledQty, item.NetQty, item.ClosingPrice, item.Commission, item.VatOnCommission,
                                item.CommissionVatTotal, item.GrossPL, item.NetPL, item.M2M, item.GrossM2M, item.UsedMargin, item.NetValue, item.NetAvgPrice);
                        }
                        else
                        {
                            objDS4ClientComm.dtClientComm.AdddtClientCommRow(item.BrokerID, item.AccountID, item.Symbol.Trim(), item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BuyQty, item.BuyValue,
                                item.BuyAvg, item.SellQty, item.SellValue, item.SellAvg, item.SettledQty, item.NetQty, item.ClosingPrice, item.Commission, item.VatOnCommission,
                                item.CommissionVatTotal, item.GrossPL, item.NetPL, item.M2M, item.GrossM2M, item.UsedMargin, item.NetValue, item.NetAvgPrice);
                        }
                    }
                    else if (clsGlobal.BrokerID == 1)
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4ClientComm.dtClientComm.AdddtClientCommRow(item.BrokerID, item.AccountID, item.Symbol.Trim(), item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BuyQty, item.BuyValue,
                                item.BuyAvg, item.SellQty, item.SellValue, item.SellAvg, item.SettledQty, item.NetQty, item.ClosingPrice, item.Commission, item.VatOnCommission,
                                item.CommissionVatTotal, item.GrossPL, item.NetPL, item.M2M, item.GrossM2M, item.UsedMargin, item.NetValue, item.NetAvgPrice);
                        }
                        else
                        {
                            objDS4ClientComm.dtClientComm.AdddtClientCommRow(item.BrokerID, item.AccountID, item.Symbol.Trim(), item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BuyQty, item.BuyValue,
                                item.BuyAvg, item.SellQty, item.SellValue, item.SellAvg, item.SettledQty, item.NetQty, item.ClosingPrice, item.Commission, item.VatOnCommission,
                                item.CommissionVatTotal, item.GrossPL, item.NetPL, item.M2M, item.GrossM2M, item.UsedMargin, item.NetValue, item.NetAvgPrice);
                        }
                    }
                }
                objClientCommReport.SetDataSource(objDS4ClientComm);
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("ClientCommReport : _objReportClient_GetClientCommmissionReportDataCompleted => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }
    }
}
