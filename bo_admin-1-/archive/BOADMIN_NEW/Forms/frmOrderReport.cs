using System;
using System.Linq;
using BOADMIN_NEW.ReportService;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Forms
{
    public partial class frmOrderReport : FrmBase
    {

        public frmOrderReport()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;

            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            objTradeReportSearchValues.DateValue = DateTime.Now;
            objTradeReportSearchValues.ToDate = DateTime.Now;
            objTradeReportSearchValues.OrderType = string.Empty;
            objTradeReportSearchValues.Side = string.Empty;
            objTradeReportSearchValues.Symbol = string.Empty;
            objTradeReportSearchValues.TIF_ID = 0;
            GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_DATE);
        }

        private void ui_ntxtSide_Leave(object sender, EventArgs e)
        {
            //if (ui_ntxtSide.Text != string.Empty && ui_ntxtAccountNumber.Text == string.Empty && ui_ntxtOrderType.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.Side = ui_ntxtSide.Text;
            //    objOrderReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_SIDE);

            //    ui_rptvOrder.RefreshReport();
            //}
        }

        private void ui_ntxtAccountNumber_Leave(object sender, EventArgs e)
        {
            //if (ui_ntxtAccountNumber.Text != string.Empty && ui_ntxtSide.Text == string.Empty && ui_ntxtOrderType.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.AccountNumber = Convert.ToInt32(ui_ntxtAccountNumber.Text);
            //    objOrderReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_ACCOUNT_NUMBER);

            //    ui_rptvOrder.RefreshReport();
            //}
        }

        private void ui_ntxtOrderType_Leave(object sender, EventArgs e)
        {
            //if (ui_ntxtOrderType.Text != string.Empty && ui_ntxtSide.Text == string.Empty && ui_ntxtAccountNumber.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.OrderType = ui_ntxtOrderType.Text;
            //    objOrderReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_ORDER_TYPE);

            //    ui_rptvOrder.RefreshReport();
            //}
        }

        private void ui_nbtnSearch1_Click(object sender, EventArgs e)
        {
            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            objTradeReportSearchValues.DateValue = ui_ndtpFromDate.Value;
            objTradeReportSearchValues.ToDate = ui_ndtpToDate.Value;
            if (clsGlobal.BrokerID == 1)
            {
                objTradeReportSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                objTradeReportSearchValues.BrokerParentID = 0;
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
                    objTradeReportSearchValues.BrokerID = clsUtility.GetInt(ui_ntxtBrokerID.Text);
                    objTradeReportSearchValues.BrokerParentID = Cls.clsGlobal.BrokerNameId;
                }
            }
            if (ui_ncmbSide.SelectedItem != null)
            {
                if (ui_ncmbSide.SelectedItem.ToString() != "All")
                {
                    objTradeReportSearchValues.Side = clsUtility.GetStr(ui_ncmbSide.SelectedItem.ToString());
                }
                else
                {
                    objTradeReportSearchValues.Side = string.Empty;
                }
            }
            else
            {
                objTradeReportSearchValues.Side = string.Empty;
            }
            objTradeReportSearchValues.AccountNumber = clsUtility.GetInt(ui_ntxtAccountNumber.Text);
            if (ui_ncmbOrderType.SelectedItem != null)
            {
                if (ui_ncmbOrderType.SelectedItem.ToString() != "All")
                {
                    objTradeReportSearchValues.OrderType = clsUtility.GetStr(ui_ncmbOrderType.SelectedItem.ToString());
                }
                else
                {
                    objTradeReportSearchValues.OrderType = string.Empty;
                }
            }
            else
            {
                objTradeReportSearchValues.OrderType = string.Empty;
            }
            objTradeReportSearchValues.OrderNumber = clsUtility.GetLong(ui_ntxtOrderNumber.Text);
            objTradeReportSearchValues.Symbol = clsUtility.GetStr(ui_ntxtSymbol.Text);
            if (ui_ncmbTIF.SelectedItem != null)
            {
                if (ui_ncmbTIF.SelectedItem.ToString() != "All")
                {
                    objTradeReportSearchValues.TIF_ID = clsReportsMasterInfoManager.INSTANCE.GetTIFID(ui_ncmbTIF.SelectedItem.ToString());
                }
                else
                {
                    objTradeReportSearchValues.TIF_ID = 0;
                }
            }
            else
            {
                objTradeReportSearchValues.TIF_ID = 0;
            }
            GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_DATE);
            
        }

        private void frmOrderReport_Load(object sender, EventArgs e)
        {
            if (clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Count == 0 || clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Count == 0)
            {
                clsReportsMasterInfoManager.INSTANCE.HandleReportsMasterInfo(clsProxyClassManager.INSTANCE._objReportClient.GetReportsMasterInfo(clsGlobal.userIDPwd));
            }
            ui_ncmbOrderType.Items.AddRange(clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Values.ToArray());
            ui_ncmbSide.Items.AddRange(clsReportsMasterInfoManager.INSTANCE._DDSideTypes.Values.ToArray());
            ui_ncmbTIF.Items.AddRange(clsReportsMasterInfoManager.INSTANCE._DDTIFTypes.Values.ToArray());
            ui_ncmbOrderType.Items.Insert(0, "All");
            ui_ncmbSide.Items.Insert(0, "All");
            ui_ncmbTIF.Items.Insert(0, "All");
            ui_ncmbSide.SelectedIndex = 0;
            ui_ncmbOrderType.SelectedIndex = 0;
            ui_ncmbTIF.SelectedIndex = 0;

            
        }

        private void ui_ndtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //_isDateChanged = true;
        }

        private void ui_ndtpToDate_ValueChanged(object sender, EventArgs e)
        {
            // _isDateChanged = true;
        }

        private void ui_rptvOrder_Load(object sender, EventArgs e)
        {

        }

        public void GetReportData(TradeReportSearchValues searchValues, TradeReportSearchType searchType)
        {
            _objReportClient_GetOrderReportDataCompleted(Cls.clsProxyClassManager.INSTANCE._objReportClient.GetOrderReportData(clsGlobal.userIDPwd, searchValues, searchType));

        }

        void _objReportClient_GetOrderReportDataCompleted(clsOrderReport[] e)//object sender, GetOrderReportDataCompletedEventArgs e)
        {
            try
            {
                DS.DS4Order objDS4Order = new DS.DS4Order();

                foreach (clsOrderReport item in e)
                {
                    int contractSize = clsMasterInfoManager.INSTANCE.GetContractSize(item.Symbol);

                    item.Lot = item.Lot / contractSize;
                    item.ExecutionQty = item.ExecutionQty / contractSize;
                    if (clsGlobal.BrokerID != 1 && (item.BrokerID == clsGlobal.BrokerNameId ||
                        clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(item.BrokerID)))
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4Order.dtOrder.AdddtOrderRow(item.BrokerID, item.AccountID, item.OrderNumber, item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"), item.OrderType.Trim(), item.Side.Trim(), item.Lot,
                                item.Symbol.Trim(), item.Price, item.ExecutionQty, item.OrderStatus.Trim(), item.AverageFillPrice, item.Commission, item.Tax, item.TIF);
                        }
                        else
                        {
                            objDS4Order.dtOrder.AdddtOrderRow(item.BrokerID, item.AccountID, item.OrderNumber, item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"), item.OrderType.Trim(), item.Side.Trim(), item.Lot,
                                item.Symbol.Trim(), item.Price, item.ExecutionQty, item.OrderStatus.Trim(), item.AverageFillPrice, item.Commission, item.Tax, item.TIF);
                        }
                    }
                    else if (clsGlobal.BrokerID == 1)
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4Order.dtOrder.AdddtOrderRow(item.BrokerID, item.AccountID, item.OrderNumber, item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"), item.OrderType.Trim(), item.Side.Trim(), item.Lot,
                               item.Symbol.Trim(), item.Price, item.ExecutionQty, item.OrderStatus.Trim(), item.AverageFillPrice, item.Commission, item.Tax, item.TIF);
                        }
                        else
                        {
                            objDS4Order.dtOrder.AdddtOrderRow(item.BrokerID, item.AccountID, item.OrderNumber, item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"), item.OrderType.Trim(), item.Side.Trim(), item.Lot,
                               item.Symbol.Trim(), item.Price, item.ExecutionQty, item.OrderStatus.Trim(), item.AverageFillPrice, item.Commission, item.Tax, item.TIF);
                        }
                    }
                }

                objOpenOrdersReport.SetDataSource(objDS4Order);
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("OrderReport : _objReportClient_GetOrderReportDataCompleted => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }
    }
}
