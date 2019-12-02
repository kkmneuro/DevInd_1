using BOADMIN_NEW.Cls;
using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using System;

namespace BOADMIN_NEW.Forms
{
    public partial class frmClientHoldingStock : FrmBase
    {
        DS.DS4ClientHoldingStock objDS4ClientHoldingStock;
        public frmClientHoldingStock()
        {
            objDS4ClientHoldingStock = new DS.DS4ClientHoldingStock();
            InitializeComponent();
           // objCrClientHoldingStock.SetDatabaseLogon("sa", "admin123@");
        }

        private void frmClientHoldingStockNew_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            ClientHoldingSearchValues objSearchValues = new ClientHoldingSearchValues();
            objSearchValues.TradeDate = DateTime.Now;
            GetReportData(objSearchValues, ClientHoldingSearchType.ALL);
            //ui_rptvClientHoldingStock.RefreshReport();
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            ClientHoldingSearchValues objSearchValues = new ClientHoldingSearchValues();
            objSearchValues.TradeDate = clsUtility.GetDate(ui_ndtpTradeDate.Value);
            objSearchValues.Symbol = clsUtility.GetStr(ui_ntxtSymbol.Text);
            int ac = 0;
            int.TryParse(ui_ntxtAccountID.Text.Trim(), out ac);
            objSearchValues.AccountID = ac;
            if (clsGlobal.BrokerID == 1)
            {
                objSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objSearchValues.BrokerParentID = 0;
            }
            else
            {
                if (ui_ntxtBrokerID.Text.Trim() == string.Empty)
                {
                    //objSearchValues.BrokerID = Cls.clsGlobal.BrokerNameId;
                    //objSearchValues.BrokerParentID = 0;
                }
                else
                {
                    objSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objSearchValues.BrokerParentID = Cls.clsGlobal.BrokerNameId;
                }
            }
            GetReportData(objSearchValues, ClientHoldingSearchType.BY_SYMBOL);

            ui_rptvClientHoldingStock.RefreshReport();

        }

        public void GetReportData(ClientHoldingSearchValues searchValues, ClientHoldingSearchType searchType)
        {
            try
            {

                foreach (clsClientHoldingStock item in Cls.clsProxyClassManager.INSTANCE._objReportClient.GetClientHoldingReportData(Cls.clsGlobal.userIDPwd,
                    searchValues, searchType))
                {
                    int contractSize = clsMasterInfoManager.INSTANCE.GetContractSize(item.Symbol);

                    item.BuyQty = item.BuyQty / contractSize;
                    item.SellQty = item.SellQty / contractSize;

                    if (clsGlobal.BrokerID != 1 && (item.BrokerID == clsGlobal.BrokerNameId ||
                        clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(item.BrokerID)))
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4ClientHoldingStock.dtClientHoldingStock.AdddtClientHoldingStockRow(item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BrokerCompany, item.BrokerID, item.ClientName,
                                item.AccountID, item.Symbol, item.BuyQty, item.SellQty);
                        }
                        else
                        {
                            objDS4ClientHoldingStock.dtClientHoldingStock.AdddtClientHoldingStockRow(item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BrokerCompany, item.BrokerID, item.ClientName,
                                item.AccountID, item.Symbol, item.BuyQty, item.SellQty);
                        }
                    }
                    else if (clsGlobal.BrokerID == 1)
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4ClientHoldingStock.dtClientHoldingStock.AdddtClientHoldingStockRow(item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BrokerCompany, item.BrokerID, item.ClientName,
                                item.AccountID, item.Symbol, item.BuyQty, item.SellQty);
                        }
                        else
                        {
                            objDS4ClientHoldingStock.dtClientHoldingStock.AdddtClientHoldingStockRow(item.TradeDate.ToString("MM/dd/yyyy HH:mm:ss"), item.BrokerCompany, item.BrokerID, item.ClientName,
                               item.AccountID, item.Symbol, item.BuyQty * contractSize, item.SellQty * contractSize);
                        }
                    }
                }

                objCrClientHoldingStock.SetDataSource(objDS4ClientHoldingStock);

            }
            catch (Exception)
            {

            }
        }
    }
}
