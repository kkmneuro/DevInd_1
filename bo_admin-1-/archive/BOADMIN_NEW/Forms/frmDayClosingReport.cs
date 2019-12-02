using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using BOADMIN_NEW.DS;

namespace BOADMIN_NEW.Forms
{
    public partial class frmDayClosingReport : FrmBase
    {        
        public frmDayClosingReport()
        {
            InitializeComponent();
                        
            DayClosingSearchValues objDayClosingSearchValues = new DayClosingSearchValues();
            objDayClosingSearchValues.Date = DateTime.Now;
            objDayClosingSearchValues.Symbol = string.Empty;
            GetReportData(objDayClosingSearchValues);
            
        }

        private void frmDayClosingReport_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
        }

        private void ui_nbtnSearch_Click(object sender, EventArgs e)
        {
            DayClosingSearchValues objDayClosingSearchValues = new DayClosingSearchValues();
            if (clsGlobal.BrokerID == 1)
            {
                objDayClosingSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objDayClosingSearchValues.BrokerParentID = 0;
            }
            else
            {
                if (ui_ntxtBrokerID.Text.Trim() == string.Empty)
                {
                    //objTradeReportSearchValues.BrokerID = Cls.clsGlobal.BrokerNameId;
                    //objTradeReportSearchValues.BrokerParentID = 0;
                }
                else
                {
                    objDayClosingSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objDayClosingSearchValues.BrokerParentID = Cls.clsGlobal.BrokerNameId;
                }
            }
            objDayClosingSearchValues.Date = ui_ndtpDate.Value;
            if (ui_ntxtSymbol.Text == string.Empty)
            {
                objDayClosingSearchValues.Symbol = string.Empty;
            }
            else
            {
                objDayClosingSearchValues.Symbol = ui_ntxtSymbol.Text;
            }
            GetReportData(objDayClosingSearchValues);
            
        }

        private void ui_ntxtBrokerID_TextChanged(object sender, EventArgs e)
        {

        }

        public void GetReportData(DayClosingSearchValues dayClosingValues)
        {
            try
            {
                DS4DayClosingReport objDS4DayClosingReport = new DS4DayClosingReport();

                foreach (clsDayClosing dayClosing in clsProxyClassManager.INSTANCE._objReportClient.GetDayClosingReportData(clsGlobal.userIDPwd, dayClosingValues))
                {
                    DS4DayClosingReport.dtDayClosingReportRow row = objDS4DayClosingReport.dtDayClosingReport.FindBySymbolFutureDate(dayClosing.Symbol);
                    if (row == null)
                    {
                        if (clsGlobal.BrokerID != 1 && (dayClosing.BrokerId == clsGlobal.BrokerNameId ||
                            clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(dayClosing.BrokerId)))
                        {
                            objDS4DayClosingReport.dtDayClosingReport.AdddtDayClosingReportRow(dayClosing.SNo, dayClosing.Symbol, dayClosing.TradeDate.ToString("dd/MM/yy"),/* dayClosing.Open,
                    dayClosing.High, dayClosing.Low, dayClosing.Close, dayClosing.PrevDayClose,*/
                                                                                                             dayClosing.Buy, dayClosing.Sell, dayClosing.BuyValue,
                                dayClosing.SellValue, dayClosing.BuyQty, dayClosing.SellQty);
                        }
                        else if (clsGlobal.BrokerID == 1)
                        {
                            objDS4DayClosingReport.dtDayClosingReport.AdddtDayClosingReportRow(dayClosing.SNo, dayClosing.Symbol, dayClosing.TradeDate.ToString("dd/MM/yy"),/* dayClosing.Open,
                    dayClosing.High, dayClosing.Low, dayClosing.Close, dayClosing.PrevDayClose,*/
                                                                                                             dayClosing.Buy, dayClosing.Sell, dayClosing.BuyValue,
                                dayClosing.SellValue, dayClosing.BuyQty, dayClosing.SellQty);
                        }
                    }
                    else
                    {
                        if (clsGlobal.BrokerID != 1 && (dayClosing.BrokerId == clsGlobal.BrokerNameId ||
                            clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(dayClosing.BrokerId)))
                        {
                            row.TradedBuyUnit = row.TradedBuyUnit + dayClosing.Buy;
                            row.TradedSellUnit = row.TradedSellUnit + dayClosing.Sell;
                            row.TradedBuyValue = row.TradedBuyValue + dayClosing.BuyValue;
                            row.TradedSellValue = row.TradedSellValue + dayClosing.SellValue;
                            row.OpenBuyQuantity = row.OpenBuyQuantity + dayClosing.BuyQty;
                            row.OpenSellQuantity = row.OpenSellQuantity + dayClosing.SellQty;
                        }
                        else if (clsGlobal.BrokerID == 1)
                        {
                            row.TradedBuyUnit = row.TradedBuyUnit + dayClosing.Buy;
                            row.TradedSellUnit = row.TradedSellUnit + dayClosing.Sell;
                            row.TradedBuyValue = row.TradedBuyValue + dayClosing.BuyValue;
                            row.TradedSellValue = row.TradedSellValue + dayClosing.SellValue;
                            row.OpenBuyQuantity = row.OpenBuyQuantity + dayClosing.BuyQty;
                            row.OpenSellQuantity = row.OpenSellQuantity + dayClosing.SellQty;
                        }
                    }
                }
                objDayClosingReport.SetDataSource(objDS4DayClosingReport);
            }
            catch (Exception)
            {
            }
        }
    }
}
