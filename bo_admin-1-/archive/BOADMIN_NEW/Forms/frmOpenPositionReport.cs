﻿using System;
using System.Linq;
using BOADMIN_NEW.ReportService;
using BOADMIN_NEW.Cls;
using clsInterface4OME;

namespace BOADMIN_NEW.Forms
{
    public partial class frmOpenPositionReport : FrmBase
    {        
        public frmOpenPositionReport()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;

            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            objTradeReportSearchValues.DateValue = DateTime.Now;
            objTradeReportSearchValues.ToDate = DateTime.Now;
            objTradeReportSearchValues.Symbol = string.Empty;
            objTradeReportSearchValues.Side = string.Empty;
            objTradeReportSearchValues.OrderType = string.Empty;

            GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_OPEN_POSITION);

        }

        private void frmTradeReport_Load(object sender, EventArgs e)
        {
            //if (clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Count == 0 || clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Count == 0)
            //{               
            //    clsReportsMasterInfoManager.INSTANCE.HandleReportsMasterInfo(clsProxyClassManager.INSTANCE._objReportClient.GetReportsMasterInfo(clsGlobal.userIDPwd));
            //}
            //ui_ncmbOrderType.Items.AddRange(clsReportsMasterInfoManager.INSTANCE._DDOrderTypes.Values.ToArray());
            //ui_ncmbSide.Items.AddRange(clsReportsMasterInfoManager.INSTANCE._DDSideTypes.Values.ToArray());
            //ui_ncmbOrderType.Items.Insert(0, "All");
            //ui_ncmbSide.Items.Insert(0, "All");
            //ui_ncmbSide.SelectedIndex = 0;
            //ui_ncmbOrderType.SelectedIndex = 0;            
        }

        private void ui_ndtpDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ui_nbtnSearch2_Click(object sender, EventArgs e)
        {
            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            if (ui_ntxtOrderNumber.Text != string.Empty)
            {
                objTradeReportSearchValues.OrderNumber = Convert.ToInt64(ui_ntxtOrderNumber.Text);
                GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_ORDER_NUMBER);
            }
            else if (ui_ntxtTradeNumber.Text != string.Empty)
            {
                objTradeReportSearchValues.TradeNumber = Convert.ToInt64(ui_ntxtTradeNumber.Text);
                GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_TRADE_NUMBER);
            }

            
        }

        private void ui_nbtnSearch1_Click(object sender, EventArgs e)
        {
            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();

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

            objTradeReportSearchValues.DateValue = clsUtility.GetDate(ui_ndtpFromDate.Value);
            objTradeReportSearchValues.ToDate = clsUtility.GetDate(ui_ndtpToDate.Value);
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
            objTradeReportSearchValues.Symbol = clsUtility.GetStr(ui_ntxtSymbol.Text);

            GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_DATE_SIDE_ACCOUNT_NUMBER_ORDER_TYPE);

       
        }

        private void ui_ntxtAccountNumber_Leave(object sender, EventArgs e)
        {
            //if (ui_ntxtAccountNumber.Text != string.Empty) //&& ui_ntxtSide.Text == string.Empty && ui_ntxtOrderType.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.AccountNumber = clsUtility.GetInt(ui_ntxtAccountNumber.Text);
            //    objTradeReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_ACCOUNT_NUMBER);

            //    ui_trRvTrade.RefreshReport();
            //}
        }

        private void ui_ncmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_ncmbOrderType.SelectedItem != null) //&& ui_ntxtSide.Text == string.Empty && ui_ntxtAccountNumber.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.OrderType = ui_ncmbOrderType.SelectedItem.ToString();
            //    objTradeReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_ORDER_TYPE);

            //    ui_trRvTrade.RefreshReport();
            //}
        }

        private void ui_ncmbSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_ncmbSide.SelectedItem!=null ) // != string.Empty && ui_ntxtAccountNumber.Text == string.Empty && ui_ncmbSide.Text == string.Empty)
            //{
            //    TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            //    objTradeReportSearchValues.Side = ui_ncmbSide.SelectedItem.ToString();
            //    objTradeReport.GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_SIDE);

            //    ui_trRvTrade.RefreshReport();
            //}
        }

        private void ui_ntxtTradeNumber_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtTradeNumber.Text != string.Empty)
            {
                TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
                objTradeReportSearchValues.TradeNumber = Convert.ToInt64(ui_ntxtTradeNumber.Text);
                GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_TRADE_NUMBER);

                
            }
        }


        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {                      

            TradeReportSearchValues objTradeReportSearchValues = new TradeReportSearchValues();
            objTradeReportSearchValues.DateValue = DateTime.Now;
            objTradeReportSearchValues.ToDate = DateTime.Now;
            objTradeReportSearchValues.Symbol = string.Empty;
            objTradeReportSearchValues.Side = string.Empty;
            objTradeReportSearchValues.OrderType = string.Empty;
            GetReportData(objTradeReportSearchValues, TradeReportSearchType.BY_OPEN_POSITION);
        }

        public void GetReportData(TradeReportSearchValues searchValues, TradeReportSearchType searchType)//DateTime dateTime,TradeReportSearchType searchType)
        {

            if (clsProxyClassManager.INSTANCE._objReportClient != null)
            {
                _objReportClient_GetTradeReportDataCompleted(clsProxyClassManager.INSTANCE._objReportClient.GetTradeReportData(clsGlobal.userIDPwd, searchValues, searchType));
              
            }
        }

        void _objReportClient_GetTradeReportDataCompleted(clsTradeReport[] e)//object sender, GetTradeReportDataCompletedEventArgs e)
        {
            try
            {
                DS.DS4OpenPosition objDS4OpenPosition = new DS.DS4OpenPosition();

                foreach (clsTradeReport item in e)
                {
                    item.Lot = item.Lot / clsMasterInfoManager.INSTANCE.GetContractSize(item.Symbol);                             

                    if (clsGlobal.BrokerID != 1 && (item.BrokerID == clsGlobal.BrokerNameId ||
                        clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(item.BrokerID)))
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4OpenPosition.dtOpenPosition.AdddtOpenPositionRow(item.BrokerID, item.ITCM, item.TCM, item.TM, item.STM, item.AccountID, item.OrderNumber,
                                item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                item.OrderType, item.Side, item.Lot, item.Symbol, item.Price, item.TradeTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                Convert.ToDecimal(item.TradePrice.ToString("0.00")), item.TradeNumber);
                        }
                        else
                        {
                            objDS4OpenPosition.dtOpenPosition.AdddtOpenPositionRow(item.BrokerID, item.ITCM, item.TCM, item.TM, item.STM, item.AccountID, item.OrderNumber,
                                item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                item.OrderType, item.Side, item.Lot, item.Symbol, item.Price, item.TradeTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                Convert.ToDecimal(item.TradePrice.ToString("0.00")), item.TradeNumber);
                        }

                    }
                    else if (clsGlobal.BrokerID == 1)
                    {
                        if (clsMasterInfoManager.INSTANCE.GetCommonSettingsValue("Quantity") == "Lots")
                        {
                            objDS4OpenPosition.dtOpenPosition.AdddtOpenPositionRow(item.BrokerID, item.ITCM, item.TCM, item.TM, item.STM, item.AccountID, item.OrderNumber,
                                item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                item.OrderType, item.Side, item.Lot, item.Symbol, item.Price, item.TradeTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                Convert.ToDecimal(item.TradePrice.ToString("0.00")), item.TradeNumber);
                        }
                        else
                        {
                            objDS4OpenPosition.dtOpenPosition.AdddtOpenPositionRow(item.BrokerID, item.ITCM, item.TCM, item.TM, item.STM, item.AccountID, item.OrderNumber,
                                item.OrderDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                item.OrderType, item.Side, item.Lot, item.Symbol, item.Price, item.TradeTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                Convert.ToDecimal(item.TradePrice.ToString("0.00")), item.TradeNumber);
                            
                        }
                    }
                }
                OpenPositionReport.SetDataSource(objDS4OpenPosition);
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("TradeReport : _objReportClient_GetTradeReportDataCompleted => Exception" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }

    }
}
