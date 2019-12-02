using System;
using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Forms
{
    public partial class frmStockLevel : FrmBase
    {
        public frmStockLevel()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            
            StockLevelSearchValues objSearchValue = new StockLevelSearchValues();
            objSearchValue.FromDate = clsUtility.GetDate(DateTime.Now);
            objSearchValue.ToDate = clsUtility.GetDate(DateTime.Now);
            objSearchValue.Symbol = string.Empty;
            objSearchValue.ProductType = string.Empty;
            if (clsGlobal.BrokerID != 1)
            {
                objSearchValue.BrokerID = clsGlobal.BrokerNameId;
                objSearchValue.BrokerParentID = 0;
            }

            GetReportData(objSearchValue, StockLevelSearchType.BY_DATE);
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            StockLevelSearchValues objSearchValue = new StockLevelSearchValues();

            objSearchValue.FromDate = clsUtility.GetDate(ui_ndtpFromDate.Value);
            objSearchValue.ToDate = clsUtility.GetDate(ui_ndtpToDate.Value);
            objSearchValue.ProductType = clsUtility.GetStr(ui_ntxtProductType.Text);
            objSearchValue.Symbol = clsUtility.GetStr(ui_ntxtSymbol.Text);
            if (clsGlobal.BrokerID == 1)
            {
                objSearchValue.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objSearchValue.BrokerParentID = 0;
            }
            else
            {
                if (ui_ntxtBrokerID.Text.Trim() == string.Empty)
                {
                    objSearchValue.BrokerID = clsGlobal.BrokerNameId;
                    objSearchValue.BrokerParentID = 0;
                }
                else
                {
                    objSearchValue.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objSearchValue.BrokerParentID = clsGlobal.BrokerNameId;
                }
            }
            GetReportData(objSearchValue, StockLevelSearchType.BY_DATE_PRODUCT_TYPE_SYMBOL);
            
        }

        private void frmStockLevel_Load(object sender, EventArgs e)
        {
            
        }

        private void ui_ndtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }


        public void GetReportData(StockLevelSearchValues searchValues, StockLevelSearchType searchType)
        {
            DS.DS4StockLevel objDS4StockLevel = new DS.DS4StockLevel();

            foreach (clsStockLevel item in clsProxyClassManager.INSTANCE._objReportClient.GetStockLevelReportData(clsGlobal.userIDPwd, searchValues, searchType))
            {
                objDS4StockLevel.dtStockLevel.AdddtStockLevelRow(item.ProductType.Trim(), item.Symbol.Trim(), item.BuyUnit, item.SellUnit, item.Capital);
            }
            objStockLevel.SetDataSource(objDS4StockLevel);
        }
    }
}
