using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using ReportServiceClasses;
using DataAcessLogic;
using System.Collections.Generic;
using System.ServiceModel;
using DataAcessLogic.DBML;
using System.Data;

/// <summary>
/// Summary description for ReportService
/// </summary>
public class ReportService : IReport, IBoOperations
{
    OMSDataAccess _objOMSDataAccess;
    BODataAccess _objBODataAccess;
    List<string> _lstConnectedClients = new List<string>();
    public ReportService()
    {
        _objOMSDataAccess = new OMSDataAccess(ConfigurationManager.ConnectionStrings["OMSExchange"].ConnectionString);
        _objBODataAccess = new BODataAccess(ConfigurationManager.ConnectionStrings["BOExchange"].ConnectionString);
    }

    #region IReport Members

    public List<clsTradeReport> GetTradeReportData(string userIdPwd, TradeReportSearchValues searchValues, TradeReportSearchType searchType)
    {
        try
        {
            List<clsTradeReport> lstTradeReport = new List<clsTradeReport>();

            //if (!_lstConnectedClients.Contains(userIdPwd))
            //{
            //    clsTradeReport objclsTradeReport = new clsTradeReport();

            //    objclsTradeReport.ServerResponseID = -50060;
            //    lstTradeReport.Add(objclsTradeReport);
            //    return lstTradeReport;
            //}
            switch (searchType)
            {
                #region "  OLD Code2  "
                //case TradeReportSearchType.BY_DATE:
                //    {
                //        List<OMS_GetTradeReportDataByDateResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDate(searchValues.DateValue,
                //            searchValues.ToDate,searchValues.BrokerID);
                //        if (spResult == null)
                //        {
                //            return lstTradeReport;
                //        }
                //        foreach (OMS_GetTradeReportDataByDateResult item in spResult)
                //        {
                //            clsTradeReport objclsTradeReport = new clsTradeReport();
                //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                //            objclsTradeReport.ServerResponseID = -50052;

                //            lstTradeReport.Add(objclsTradeReport);
                //        }
                //    }
                //    break;
                //case TradeReportSearchType.BY_SIDE:
                //    {
                //        List<OMS_GetTradeReportDataBySideResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataBySide(searchValues.Side, searchValues.BrokerID);
                //        if (spResult == null)
                //        {
                //            return lstTradeReport;
                //        }
                //        foreach (OMS_GetTradeReportDataBySideResult item in spResult)
                //        {
                //            clsTradeReport objclsTradeReport = new clsTradeReport();
                //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                //            objclsTradeReport.ServerResponseID = -50052;

                //            lstTradeReport.Add(objclsTradeReport);
                //        }
                //    }
                //    break;
                //case TradeReportSearchType.BY_ACCOUNT_NUMBER:
                //    {
                //        List<OMS_GetTradeReportDataByAccountNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByAccountNumber(searchValues.AccountNumber, searchValues.BrokerID);
                //        if (spResult == null)
                //        {
                //            return lstTradeReport;
                //        }
                //        foreach (OMS_GetTradeReportDataByAccountNumberResult item in spResult)
                //        {
                //            clsTradeReport objclsTradeReport = new clsTradeReport();
                //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                //            objclsTradeReport.ServerResponseID = -50052;

                //            lstTradeReport.Add(objclsTradeReport);
                //        }
                //    }
                //    break;
                //case TradeReportSearchType.BY_ORDER_TYPE:
                //    {
                //        List<OMS_GetTradeReportDataByOrderTypeResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByOrderType(searchValues.OrderType, searchValues.BrokerID);
                //        if (spResult == null)
                //        {
                //            return lstTradeReport;
                //        }
                //        foreach (OMS_GetTradeReportDataByOrderTypeResult item in spResult)
                //        {
                //            clsTradeReport objclsTradeReport = new clsTradeReport();
                //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                //            objclsTradeReport.ServerResponseID = -50052;

                //            lstTradeReport.Add(objclsTradeReport);
                //        }
                //    }
                //    break;
                #endregion "  OLD Code2  "
                case TradeReportSearchType.BY_ORDER_NUMBER:
                    {
                        List<OMS_GetTradeReportDataByOrderNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByOrderNumber(searchValues.OrderNumber, searchValues.BrokerID);
                        if (spResult == null)
                        {
                            return lstTradeReport;
                        }
                        foreach (OMS_GetTradeReportDataByOrderNumberResult item in spResult)
                        {
                            clsTradeReport objclsTradeReport = new clsTradeReport();
                            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                            objclsTradeReport.Side = clsUtility.GetStr(item.Side).Trim();
                            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                            objclsTradeReport.BrokerType = clsUtility.GetStr(item.BrokerType);
                            objclsTradeReport.profitValue = clsUtility.GetDecimal(item.ProfitValue);
                            objclsTradeReport.commission = clsUtility.GetDecimal(item.Commission);
                            string[] brokerHirarchy = item.Brokershierarchy.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            if (brokerHirarchy.Count() != 0)
                            {
                                objclsTradeReport.ITCM = brokerHirarchy[0] + "_ITCM";
                                for (int index = 2; index < brokerHirarchy.Count(); index++)
                                {
                                    switch (brokerHirarchy[index])
                                    {
                                        case "TCM":
                                            objclsTradeReport.TCM = brokerHirarchy[index - 1] + "_TCM";
                                            break;
                                        case "TM":
                                            objclsTradeReport.TM = brokerHirarchy[index - 1] + "_TM";
                                            break;
                                        case "STM":
                                            objclsTradeReport.STM = brokerHirarchy[index - 1] + "_STM";
                                            break;
                                    }
                                }
                            }
                            objclsTradeReport.ServerResponseID = -50052;

                            lstTradeReport.Add(objclsTradeReport);
                        }
                    }
                    break;
                case TradeReportSearchType.BY_TRADE_NUMBER:
                    {
                        List<OMS_GetTradeReportDataByTradeNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByTradeNumber(searchValues.TradeNumber, searchValues.BrokerID);
                        if (spResult == null)
                        {
                            return lstTradeReport;
                        }
                        foreach (OMS_GetTradeReportDataByTradeNumberResult item in spResult)
                        {
                            clsTradeReport objclsTradeReport = new clsTradeReport();
                            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                            objclsTradeReport.Side = clsUtility.GetStr(item.Side).Trim();
                            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                            objclsTradeReport.BrokerType = clsUtility.GetStr(item.BrokerType);
                            objclsTradeReport.profitValue = clsUtility.GetDecimal(item.ProfitValue);
                            objclsTradeReport.commission = clsUtility.GetDecimal(item.Commission);
                            string[] brokerHirarchy = item.Brokershierarchy.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            if (brokerHirarchy.Count() != 0)
                            {
                                objclsTradeReport.ITCM = brokerHirarchy[0] + "_ITCM"; ;
                                for (int index = 2; index < brokerHirarchy.Count(); index++)
                                {
                                    switch (brokerHirarchy[index])
                                    {
                                        case "TCM":
                                            objclsTradeReport.TCM = brokerHirarchy[index - 1] + "_TCM";
                                            break;
                                        case "TM":
                                            objclsTradeReport.TM = brokerHirarchy[index - 1] + "_TM";
                                            break;
                                        case "STM":
                                            objclsTradeReport.STM = brokerHirarchy[index - 1] + "_STM";
                                            break;
                                    }
                                }
                            }
                            objclsTradeReport.ServerResponseID = -50052;

                            lstTradeReport.Add(objclsTradeReport);
                        }
                    }
                    break;
                case TradeReportSearchType.BY_OPEN_POSITION:
                    {
                        List<OMS_GetOpenPositionReportDataResult> spResult = _objOMSDataAccess.BO_GetOpenPositinReportData(searchValues.DateValue,
                            searchValues.Side, searchValues.AccountNumber, searchValues.OrderType, searchValues.ToDate, searchValues.BrokerID,
                            searchValues.Symbol, searchValues.BrokerParentID);
                        if (spResult == null)
                        {
                            return lstTradeReport;
                        }
                        foreach (OMS_GetOpenPositionReportDataResult item in spResult)
                        {
                            clsTradeReport objclsTradeReport = new clsTradeReport();
                            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                            objclsTradeReport.Side = clsUtility.GetStr(item.Side).Trim();
                            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                            objclsTradeReport.BrokerType = clsUtility.GetStr(item.BrokerType);
                            objclsTradeReport.profitValue = clsUtility.GetDecimal(item.ProfitValue);
                            objclsTradeReport.commission = clsUtility.GetDecimal(item.Commission);
                            string[] brokerHirarchy = item.Brokershierarchy.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            if (brokerHirarchy.Count() != 0)
                            {
                                objclsTradeReport.ITCM = brokerHirarchy[0] + "_ITCM"; ;
                                for (int index = 2; index < brokerHirarchy.Count(); index++)
                                {
                                    switch (brokerHirarchy[index])
                                    {
                                        case "TCM":
                                            objclsTradeReport.TCM = brokerHirarchy[index - 1] + "_TCM";
                                            break;
                                        case "TM":
                                            objclsTradeReport.TM = brokerHirarchy[index - 1] + "_TM";
                                            break;
                                        case "STM":
                                            objclsTradeReport.STM = brokerHirarchy[index - 1] + "_STM";
                                            break;
                                    }
                                }
                            }
                            objclsTradeReport.ServerResponseID = -50052;

                            lstTradeReport.Add(objclsTradeReport);
                        }
                    }
                    break;
                default:
                    {
                        List<OMS_GetTradeReportDataResult> spResult = _objOMSDataAccess.BO_GetTradeReportData(searchValues.DateValue,
                            searchValues.Side, searchValues.AccountNumber, searchValues.OrderType, searchValues.ToDate, searchValues.BrokerID,
                            searchValues.Symbol, searchValues.BrokerParentID);
                        if (spResult == null)
                        {
                            return lstTradeReport;
                        }
                        foreach (OMS_GetTradeReportDataResult item in spResult)
                        {
                            clsTradeReport objclsTradeReport = new clsTradeReport();
                            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                            objclsTradeReport.Side = clsUtility.GetStr(item.Side).Trim();
                            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                            objclsTradeReport.BrokerType = clsUtility.GetStr(item.BrokerType);
                            objclsTradeReport.profitValue = clsUtility.GetDecimal(item.ProfitValue);
                            objclsTradeReport.commission = clsUtility.GetDecimal(item.Commission);
                            string[] brokerHirarchy = item.Brokershierarchy.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            if (brokerHirarchy.Count() != 0)
                            {
                                objclsTradeReport.ITCM = brokerHirarchy[0] + "_ITCM"; ;
                                for (int index = 2; index < brokerHirarchy.Count(); index++)
                                {
                                    switch (brokerHirarchy[index])
                                    {
                                        case "TCM":
                                            objclsTradeReport.TCM = brokerHirarchy[index - 1] + "_TCM";
                                            break;
                                        case "TM":
                                            objclsTradeReport.TM = brokerHirarchy[index - 1] + "_TM";
                                            break;
                                        case "STM":
                                            objclsTradeReport.STM = brokerHirarchy[index - 1] + "_STM";
                                            break;
                                    }
                                }
                            }
                            objclsTradeReport.ServerResponseID = -50052;

                            lstTradeReport.Add(objclsTradeReport);
                        }
                    }
                    break;
                    #region "  OLD Code  "
                    //case TradeReportSearchType.BY_DATE_SIDE:
                    //    {
                    //        List<OMS_GetTradeReportDataByDateAndSideResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndSide(searchValues.DateValue,
                    //            searchValues.Side, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByDateAndSideResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    //case TradeReportSearchType.BY_DATE_ACCOUNT_NUMBER:
                    //    {
                    //        List<OMS_GetTradeReportDataByDateAndAccountNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndAccountNumber
                    //            (searchValues.DateValue, searchValues.AccountNumber, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByDateAndAccountNumberResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    //case TradeReportSearchType.BY_DATE_ORDER_TYPE:
                    //    {
                    //        List<OMS_GetTradeReportDataByDateAndOrderTypeResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndOrderType(
                    //            searchValues.DateValue, searchValues.OrderType, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByDateAndOrderTypeResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    //case TradeReportSearchType.BY_DATE_SIDE_ACCOUNT_NUMBER:
                    //    {
                    //        List<OMS_GetTradeReportDataByDSAResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDSA(searchValues.DateValue,
                    //            searchValues.Side, searchValues.AccountNumber, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByDSAResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    //case TradeReportSearchType.BY_DATE_SIDE_ORDER_TYPE:
                    //    {
                    //        List<OMS_GetTradeReportDataByDSOTResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDSOT(searchValues.DateValue,
                    //            searchValues.Side, searchValues.OrderType, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByDSOTResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    //case TradeReportSearchType.BY_DATE_SIDE_ACCOUNT_NUMBER_ORDER_TYPE:
                    //    {
                    //        List<OMS_GetTradeReportDataByAllResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByAll(searchValues.DateValue,
                    //            searchValues.Side, searchValues.AccountNumber, searchValues.OrderType, searchValues.ToDate, searchValues.BrokerID);
                    //        if (spResult == null)
                    //        {
                    //            return lstTradeReport;
                    //        }
                    //        foreach (OMS_GetTradeReportDataByAllResult item in spResult)
                    //        {
                    //            clsTradeReport objclsTradeReport = new clsTradeReport();
                    //            objclsTradeReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //            objclsTradeReport.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    //            objclsTradeReport.Side = clsUtility.GetStr(item.Side);
                    //            objclsTradeReport.OrderType = clsUtility.GetStr(item.Name);
                    //            objclsTradeReport.Symbol = clsUtility.GetStr(item.ContractName);
                    //            objclsTradeReport.Price = clsUtility.GetLong(item.Price);
                    //            objclsTradeReport.OrderNumber = clsUtility.GetLong(item.PK_OrderID);
                    //            objclsTradeReport.OrderDateTime = clsUtility.GetDate(item.OrderDateTimeRequested);
                    //            objclsTradeReport.Lot = clsUtility.GetLong(item.PositionSize);
                    //            objclsTradeReport.TradePrice = clsUtility.GetDecimal(item.TradePrice);
                    //            objclsTradeReport.TradeTime = clsUtility.GetDate(item.TradeTime);
                    //            objclsTradeReport.TradeNumber = clsUtility.GetLong(item.TradeNumber);
                    //            objclsTradeReport.ServerResponseID = -50052;

                    //            lstTradeReport.Add(objclsTradeReport);
                    //        }
                    //    }
                    //    break;
                    #endregion "  OLD Code  "
            }

            return lstTradeReport;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IReport Members

    public List<clsOrderReport> GetOrderReportData(string userIdPwd, TradeReportSearchValues searchValues, TradeReportSearchType searchType)
    {
        try
        {
            List<clsOrderReport> lstOrderReport = new List<clsOrderReport>();

            //if (!_lstConnectedClients.Contains(userIdPwd))
            //{
            //    clsTradeReport objclsTradeReport = new clsTradeReport();

            //    objclsTradeReport.ServerResponseID = -50060;
            //    lstTradeReport.Add(objclsTradeReport);
            //    return lstTradeReport;
            //}
            List<Report_OrderReports1Result> spResult = _objBODataAccess.BO_GetOrderReportData(searchValues.DateValue, searchValues.ToDate,
                            searchValues.Side, searchValues.AccountNumber, searchValues.OrderType, searchValues.OrderNumber, searchValues.BrokerID,
                            searchValues.Symbol, searchValues.BrokerParentID, searchValues.TIF_ID);
            //List<Report_OrderReports1Result> spResult=null;
            //switch (searchType)
            //{
            //    case TradeReportSearchType.BY_DATE:
            //        {
            //            spResult = _objBODataAccess.BO_GetOrderReportData(searchValues.DateValue, searchValues.ToDate);

            //        }
            //        break;
            //}
            //    case TradeReportSearchType.BY_SIDE:
            //        {
            //            List<OMS_GetTradeReportDataBySideResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataBySide(searchValues.Side);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_ACCOUNT_NUMBER:
            //        {
            //            List<OMS_GetTradeReportDataByAccountNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByAccountNumber(searchValues.AccountNumber);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_ORDER_TYPE:
            //        {
            //            List<OMS_GetTradeReportDataByOrderTypeResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByOrderType(searchValues.OrderType);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_ORDER_NUMBER:
            //        {
            //            List<OMS_GetTradeReportDataByOrderNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByOrderNumber(searchValues.OrderNumber);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_SIDE:
            //        {
            //            List<OMS_GetTradeReportDataByDateAndSideResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndSide(searchValues.DateValue,
            //                searchValues.Side);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_ACCOUNT_NUMBER:
            //        {
            //            List<OMS_GetTradeReportDataByDateAndAccountNumberResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndAccountNumber
            //                (searchValues.DateValue,searchValues.AccountNumber);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_ORDER_TYPE:
            //        {
            //            List<OMS_GetTradeReportDataByDateAndOrderTypeResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDateAndOrderType(
            //                searchValues.DateValue,searchValues.OrderType);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_SIDE_ACCOUNT_NUMBER:
            //        {
            //            List<OMS_GetTradeReportDataByDSAResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDSA(searchValues.DateValue,
            //                searchValues.Side, searchValues.AccountNumber);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_SIDE_ORDER_TYPE:
            //        {
            //            List<OMS_GetTradeReportDataByDSOTResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByDSOT(searchValues.DateValue,
            //                searchValues.Side, searchValues.OrderType);
            //        }
            //        break;
            //    case TradeReportSearchType.BY_DATE_SIDE_ACCOUNT_NUMBER_ORDER_TYPE:
            //        {
            //            List<OMS_GetTradeReportDataByAllResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByAll(searchValues.DateValue,
            //                searchValues.Side,searchValues.AccountNumber,searchValues.OrderType);
            //        }
            //        break;
            //}
            if (spResult == null)
            {
                return lstOrderReport;
            }
            foreach (Report_OrderReports1Result item in spResult)
            {
                clsOrderReport objclsOrderReport = new clsOrderReport();
                objclsOrderReport.BrokerID = clsUtility.GetInt(item.BrokerID);
                objclsOrderReport.AccountID = clsUtility.GetInt(item.AccountID);
                objclsOrderReport.OrderNumber = clsUtility.GetLong(item.OrderID);
                objclsOrderReport.OrderDateTime = clsUtility.GetDate(item.OrdDate_TimeRequested);
                objclsOrderReport.OrderType = clsUtility.GetStr(item.OrderType);
                objclsOrderReport.Side = clsUtility.GetStr(item.Buy_Sell).Trim();
                objclsOrderReport.Lot = clsUtility.GetLong(item.OrdQty);
                objclsOrderReport.Symbol = clsUtility.GetStr(item.Symbol);
                objclsOrderReport.Price = clsUtility.GetLong(item.Price);
                objclsOrderReport.ExecutionQty = clsUtility.GetInt(item.ExecuQty);
                objclsOrderReport.OrderStatus = clsUtility.GetStr(item.OrderStatus);
                objclsOrderReport.AverageFillPrice = clsUtility.GetDecimal(item.AvgFillPrice);
                objclsOrderReport.Commission = clsUtility.GetDecimal(item.Commission);
                objclsOrderReport.Tax = clsUtility.GetDecimal(item.Tax);
                objclsOrderReport.TIF = clsUtility.GetStr(item.Validity);

                objclsOrderReport.ServerResponseID = -50052;

                lstOrderReport.Add(objclsOrderReport);
            }
            return lstOrderReport;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IReport Members


    public List<clsClientCommission> GetClientCommmissionReportData(string userIdPwd, ClientCommissionSearchValues searchValues, ClientCommissionSearchType searchType)
    {
        List<clsClientCommission> lstClientCommReport = new List<clsClientCommission>();
        try
        {

            List<Report_ClientCommissionReport_MTMResult> spResult = _objBODataAccess.BO_GetClientCommissionReportData(searchValues.FromDateValue,
                searchValues.ToDateValue, searchValues.AccountNumber, searchValues.Symbol, searchValues.BrokerID, searchValues.BrokerParentID);

            //switch (searchType)
            //{
            //    case ClientCommissionSearchType.BY_DATE:
            //        {
            //            //List<OMS_GetTradeReportDataByAllResult> spResult = _objOMSDataAccess.BO_GetTradeReportDataByAll(searchValues.DateValue,
            //            //    searchValues.Side, searchValues.AccountNumber, searchValues.OrderType);
            //            if (lstClientCommReport == null)
            //            {
            //                return lstClientCommReport;
            //            }
            //            //foreach (OMS_GetTradeReportDataByAllResult item in spResult)
            //            //{
            //            //    clsClientCommission objclsClientCommission = new clsClientCommission();

            //            //    objclsClientCommission.ServerResponseID = -50052;

            //            //    lstClientCommReport.Add(objclsClientCommission);
            //            //}
            //        }
            //        break;
            //    case ClientCommissionSearchType.BY_ACCOUNT_NUMBER:
            //        {
            //        }
            //        break;
            //    case ClientCommissionSearchType.BY_SYMBOL:
            //        {
            //        }
            //        break;
            //    case ClientCommissionSearchType.BY_DATE_ACCOUNT_NUMBER:
            //        {
            //        }
            //        break;
            //    case ClientCommissionSearchType.BY_DATE_SYMBOL:
            //        {
            //        }
            //        break;
            //    case ClientCommissionSearchType.BY_DATE_ACCOUNT_NUMBER_SYMBOL:
            //        {
            //        }
            //        break;
            //}
            if (spResult == null)
            {
                return lstClientCommReport;
            }
            foreach (Report_ClientCommissionReport_MTMResult item in spResult)
            {
                try
                {
                    clsClientCommission objclsClientCommission = new clsClientCommission();
                    //objclsClientCommission.BrokerID=item.bro
                    objclsClientCommission.AccountID = clsUtility.GetInt(item.FK_AccountID);
                    objclsClientCommission.Symbol = clsUtility.GetStr(item.Symbol);
                    DateTime _TradeDate = DateTime.Now;
                    DateTime.TryParse(item.DateTime.ToString(), out _TradeDate);
                    objclsClientCommission.TradeDate = _TradeDate;
                    //objclsClientCommission.TradeDate = clsUtility.GetDate(item.DateTime);
                    objclsClientCommission.BuyQty = clsUtility.GetInt(item.BuyQty);
                    objclsClientCommission.BuyValue = clsUtility.GetDouble(item.BuyValue);
                    objclsClientCommission.BuyAvg = clsUtility.GetDouble(item.BuyAvg);
                    objclsClientCommission.SellQty = clsUtility.GetInt(item.SellQty);
                    objclsClientCommission.SellValue = clsUtility.GetDouble(item.SellValue);
                    objclsClientCommission.SellAvg = clsUtility.GetDouble(item.SellAvg);
                    objclsClientCommission.SettledQty = clsUtility.GetInt(item.SqrQty);
                    objclsClientCommission.NetQty = clsUtility.GetInt(item.NetQty);
                    //objclsClientCommission.ClosingPrice = item.cl;
                    objclsClientCommission.Commission = clsUtility.GetDecimal(item.Commission);
                    objclsClientCommission.VatOnCommission = clsUtility.GetDecimal(item.Tax);
                    objclsClientCommission.CommissionVatTotal = clsUtility.GetDecimal(objclsClientCommission.Commission + objclsClientCommission.VatOnCommission);
                    objclsClientCommission.GrossPL = clsUtility.GetDecimal(item.GrossPL);
                    objclsClientCommission.NetPL = clsUtility.GetDecimal(item.NetPL);
                    //objclsClientCommission.M2M = item.MarketCapitaliz;
                    //objclsClientCommission.GrossM2M = item.FK_AccountID;
                    //objclsClientCommission.UsedMargin = item.;
                    objclsClientCommission.NetValue = clsUtility.GetDecimal(item.NetValue);
                    objclsClientCommission.NetAvgPrice = clsUtility.GetDecimal(item.NetAvgPrice);
                    objclsClientCommission.BrokerID = clsUtility.GetInt(item.BrokerId);

                    objclsClientCommission.ServerResponseID = -50052;

                    lstClientCommReport.Add(objclsClientCommission);
                }
                catch (Exception)
                {
                }

            }
            return lstClientCommReport;
        }
        catch (Exception ex)
        {
            ///throw new FaultException(ex.Message);
            return lstClientCommReport;
        }
    }

    #endregion

    #region IReport Members


    public List<clsStockLevel> GetStockLevelReportData(string userIdPwd, StockLevelSearchValues searchValues, StockLevelSearchType searchType)
    {
        List<clsStockLevel> lstStockLevelReport = new List<clsStockLevel>();
        List<Report_StockLevelResult> spResult = _objBODataAccess.BO_GetStockLevelReportData(searchValues.Symbol, searchValues.ProductType,
            searchValues.BrokerID, searchValues.BrokerParentID);
        if (spResult == null)
        {
            return lstStockLevelReport;
        }
        foreach (Report_StockLevelResult item in spResult)
        {
            clsStockLevel objclsStockLevel = new clsStockLevel();
            objclsStockLevel.ProductType = clsUtility.GetStr(item.ProductType);
            objclsStockLevel.Symbol = clsUtility.GetStr(item.Symbol);
            objclsStockLevel.BuyUnit = clsUtility.GetInt(item.BuyUnit);
            objclsStockLevel.SellUnit = clsUtility.GetInt(item.SellUnit);
            objclsStockLevel.Capital = clsUtility.GetDecimal(item.Capital);
            objclsStockLevel.ServerResponseID = -50052;

            lstStockLevelReport.Add(objclsStockLevel);
        }
        return lstStockLevelReport;
    }

    public List<clsClientHoldingStock> GetClientHoldingReportData(string userIdPwd, ClientHoldingSearchValues searchValues, ClientHoldingSearchType searchType)
    {
        List<clsClientHoldingStock> lstClientHoldingStock = new List<clsClientHoldingStock>();
        List<Report_ClientHoldingStockResult> spResult = null;
        if (searchType == ClientHoldingSearchType.ALL)
        {
            spResult = _objBODataAccess.BO_GetClientHoldingStockReportData();
        }
        else
        {
            spResult = _objBODataAccess.BO_GetClientHoldingStockReportData(searchValues.Symbol, searchValues.TradeDate, searchValues.BrokerID, searchValues.BrokerParentID, searchValues.AccountID);
        }

        if (spResult == null)
        {
            return lstClientHoldingStock;
        }
        foreach (Report_ClientHoldingStockResult item in spResult)
        {
            clsClientHoldingStock objclsClientHoldingStock = new clsClientHoldingStock();
            objclsClientHoldingStock.TradeDate = clsUtility.GetDate(item.DateTime);
            objclsClientHoldingStock.BrokerCompany = clsUtility.GetStr(item.BrokerCompany);
            objclsClientHoldingStock.ClientName = clsUtility.GetStr(item.ClintName);
            objclsClientHoldingStock.AccountID = clsUtility.GetInt(item.FK_AccountID);
            objclsClientHoldingStock.Symbol = clsUtility.GetStr(item.Symbol);
            objclsClientHoldingStock.BuyQty = clsUtility.GetInt(item.BuyUnit);
            objclsClientHoldingStock.SellQty = clsUtility.GetInt(item.SellUnit);
            objclsClientHoldingStock.BrokerID = clsUtility.GetInt(item.BrokerID);
            objclsClientHoldingStock.ServerResponseID = -50052;

            lstClientHoldingStock.Add(objclsClientHoldingStock);
        }
        return lstClientHoldingStock;
    }

    public List<clsMarginReports> GetMarginReportData(string userIdPwd, MarginSearchValues searchValues, MarginSearchType searchType)
    {
        List<clsMarginReports> lstMarginReports = new List<clsMarginReports>();

        return lstMarginReports;
    }

    public List<clsTopTradedInstruments> GetTopTradedInstReportData(string userIdPwd)
    {
        List<clsTopTradedInstruments> lstTopTradedInst = new List<clsTopTradedInstruments>();

        return lstTopTradedInst;
    }

    public List<clsNewClientInfo> GetNewClientInfoReportData(string userIdPwd)
    {
        List<clsNewClientInfo> lstNewClientInfo = new List<clsNewClientInfo>();

        return lstNewClientInfo;
    }

    #endregion

    #region IReport Members


    public clsReportsMasterInfo GetReportsMasterInfo(string userIdPwd)
    {
        try
        {
            clsReportsMasterInfo objclsReportsMasterInfo = new clsReportsMasterInfo();

            List<BO_GetOMSOrderTypesResult> spResult = _objBODataAccess.BO_GetOrderTypes();
            List<BO_GetSideTypesResult> spResult1 = _objBODataAccess.BO_GetSideTypes();
            List<BO_GetTIFTypesResult> spResultTIFTypes = _objBODataAccess.BO_GetTIFTypes();

            Dictionary<int, string> ddValues = new Dictionary<int, string>();
            foreach (BO_GetOMSOrderTypesResult orderType in spResult)
            {
                ddValues.Add(orderType.PK_OrderTypeID, orderType.Description);
            }
            objclsReportsMasterInfo.OrderTypes = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetSideTypesResult orderSide in spResult1)
            {
                ddValues.Add(orderSide.PK_SideID, orderSide.Description);
            }
            objclsReportsMasterInfo.SideTypes = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetTIFTypesResult TIFTypes in spResultTIFTypes)
            {
                ddValues.Add(clsUtility.GetInt(TIFTypes.TIF_Id), clsUtility.GetStr(TIFTypes.TIF));
            }
            objclsReportsMasterInfo.TIFTypes = ddValues;

            objclsReportsMasterInfo.ServerResponseID = -50052;

            return objclsReportsMasterInfo;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IReport Members


    public List<clsAccountTrans> GetAccountTransReportData(string userIdPwd, AccountTransSearchValues searchValues)
    {
        try
        {
            List<clsAccountTrans> lstAccountTransaction = new List<clsAccountTrans>();
            List<Report_AccountTransactionResult> spResult = _objBODataAccess.BO_GetAccountTransReportData(searchValues.FromDate, searchValues.ToDate,
                searchValues.AccountID, searchValues.BrokerID, searchValues.BrokerParentID);

            if (spResult == null)
            {
                return lstAccountTransaction;
            }
            foreach (Report_AccountTransactionResult item in spResult)
            {
                clsAccountTrans objclsclsAccountTrans = new clsAccountTrans();
                objclsclsAccountTrans.AccountID = clsUtility.GetInt(item.Account_ID);
                objclsclsAccountTrans.Amount = clsUtility.GetDecimal(item.Amount);
                objclsclsAccountTrans.PaymentMode = clsUtility.GetStr(item.PaymentMode);
                objclsclsAccountTrans.PaymentType = clsUtility.GetStr(item.PaymentType);
                objclsclsAccountTrans.PaymentDate = clsUtility.GetDate(item.PaymentDate);
                objclsclsAccountTrans.ChequeNo = clsUtility.GetStr(item.Cheque_FD_No);
                objclsclsAccountTrans.Remark = clsUtility.GetStr(item.Remark);
                objclsclsAccountTrans.ServerResponseID = -50052;

                lstAccountTransaction.Add(objclsclsAccountTrans);
            }

            return lstAccountTransaction;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IReport Members


    public List<clsDayClosing> GetDayClosingReportData(string userIdPwd, DayClosingSearchValues searchValues)
    {
        List<Report_DayClosingReportResult> spResult = _objBODataAccess.BO_GetDayClosingReportData(searchValues.Date, searchValues.Symbol, searchValues.BrokerID,
            searchValues.BrokerParentID);
        List<clsDayClosing> lstDayClosing = new List<clsDayClosing>();

        if (spResult == null)
        {
            return lstDayClosing;
        }
        int sno = 1;
        foreach (Report_DayClosingReportResult item in spResult)
        {
            clsDayClosing objclsDayClosing = new clsDayClosing();
            objclsDayClosing.SNo = sno;
            objclsDayClosing.Symbol = clsUtility.GetStr(item.Symbol);
            objclsDayClosing.TradeDate = clsUtility.GetDate(item.TradeDate);
            //objclsDayClosing.Open = clsUtility.GetLong(item.OpenBuyQty);
            //objclsDayClosing.High = clsUtility.GetLong(item.Symbol);
            //objclsDayClosing.Low = clsUtility.GetLong(item.Symbol);
            //objclsDayClosing.Close = clsUtility.GetLong(item.Symbol);
            //objclsDayClosing.PrevDayClose = clsUtility.GetLong(item.Symbol);
            objclsDayClosing.BuyQty = clsUtility.GetLong(item.OpenBuyQty);
            objclsDayClosing.SellQty = clsUtility.GetLong(item.OpenSellQty);
            objclsDayClosing.BuyValue = clsUtility.GetLong(item.TradeBuyCapital);
            objclsDayClosing.SellValue = clsUtility.GetLong(item.TradeSellCapital);
            objclsDayClosing.Buy = clsUtility.GetLong(item.TradeBuyUnit);
            objclsDayClosing.Sell = clsUtility.GetLong(item.TradeSellUnit);
            objclsDayClosing.BrokerId = clsUtility.GetInt(item.BrokerID);
            sno++;
            objclsDayClosing.ServerResponseID = -50052;

            lstDayClosing.Add(objclsDayClosing);
        }
        return lstDayClosing;
    }

    #endregion

    #region IBoOperations Members

    public clsBOMasterInfo GetMasterInfo()
    {
        try
        {
            clsBOMasterInfo objclsBOMasterInfo = new clsBOMasterInfo();

            List<BO_GetRoutingAdditionalConditionTypeResult> spResultAddCond = _objBODataAccess.BO_GetRoutingAddCond();
            List<BO_GetRoutingOrderTypeResult> spResultOrderType = _objBODataAccess.BO_GetRoutingOrderType();
            List<BO_GetRoutingRequestTypeResult> spResultrequestType = _objBODataAccess.BO_GetRoutingRequestType();
            List<BO_GetRoutingPerformActionResult> spResultPerformAction = _objBODataAccess.BO_GetRoutingActionType();
            List<BO_GetDealerListResult> spResultDealerlist = _objBODataAccess.BO_GetDealerList();

            Dictionary<int, string> ddValues = new Dictionary<int, string>();
            foreach (BO_GetRoutingAdditionalConditionTypeResult AddCond in spResultAddCond)
            {
                ddValues.Add(AddCond.PK_RoutingAdditionalCondition, AddCond.AdditionalConditionName);
            }
            objclsBOMasterInfo.DDAdditionalConditionType = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetRoutingOrderTypeResult OrderType in spResultOrderType)
            {
                ddValues.Add(OrderType.PK_RoutingOrderTypeID, OrderType.OrderTypeName);
            }
            objclsBOMasterInfo.DDOrderType = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetRoutingRequestTypeResult requestType in spResultrequestType)
            {
                ddValues.Add(clsUtility.GetInt(requestType.PK_RequestTypeID), clsUtility.GetStr(requestType.RequestTypeName));
            }
            objclsBOMasterInfo.DDRequestType = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetRoutingPerformActionResult PerformAction in spResultPerformAction)
            {
                ddValues.Add(clsUtility.GetInt(PerformAction.PK_PerformActionID), clsUtility.GetStr(PerformAction.PerformActionName));
            }
            objclsBOMasterInfo.DDRoutingPerformAction = ddValues;

            ddValues = new Dictionary<int, string>();
            foreach (BO_GetDealerListResult dealer in spResultDealerlist)
            {
                ddValues.Add(clsUtility.GetInt(dealer.PK_ParticipantID), clsUtility.GetStr(dealer.FirstName + " " + dealer.MidleName + " " + dealer.LastName));
            }
            objclsBOMasterInfo.DDDealerList = ddValues;

            objclsBOMasterInfo.ServerResponseID = -50052;

            return objclsBOMasterInfo;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public List<clsRoutingRules> HandleRoutingOperations(string userIdPwd, clsRoutingRules routingRules, OperationType opType)
    {
        List<clsRoutingRules> lstRoutingRules = new List<clsRoutingRules>();

        switch (opType)
        {
            case OperationType.GET:
                {
                    foreach (BO_GetRoutingRulesInfoResult item in _objBODataAccess.BO_GetRoutingRuleAdditionParameter())
                    {
                        clsRoutingRules objclsRoutingRules = new clsRoutingRules();
                        objclsRoutingRules.ID = item.PK_RoutingRuleID;
                        //objclsRoutingRules.DealerCount = clsUtility.GetStr(item.PK_RoutingRuleID);
                        objclsRoutingRules.IsEnable = Convert.ToBoolean(item.IsEnable);
                        objclsRoutingRules.Name = clsUtility.GetStr(item.RuleName);
                        objclsRoutingRules.PerformActionID = clsUtility.GetInt(item.FK_PerformActionID);
                        objclsRoutingRules.PerformValue = clsUtility.GetStr(item.PerformActionValue);
                        objclsRoutingRules.RequestTypeID = clsUtility.GetInt(item.PK_RoutingRuleID);
                        objclsRoutingRules.OrderTypeID = clsUtility.GetInt(item.PK_RoutingRuleID);

                        List<clsAdditionalConditions> lstAdditionalCond = new List<clsAdditionalConditions>();

                        foreach (BO_GetRoutingRuleAdditionParameterResult item2 in _objBODataAccess.BO_GetRoutingRuleAdditionParameter(objclsRoutingRules.ID))
                        {
                            clsAdditionalConditions objclsAdditionalConditions = new clsAdditionalConditions();
                            objclsAdditionalConditions.Type = item2.Type;
                            objclsAdditionalConditions.Condition = item2.Condition;
                            objclsAdditionalConditions.Value = item2.Values;
                            lstAdditionalCond.Add(objclsAdditionalConditions);
                        }
                        objclsRoutingRules.AdditionalConditions = lstAdditionalCond;

                        List<clsDealer> lstDealer = new List<clsDealer>();

                        foreach (BO_GetRoutingDealerMapInfoResult item3 in _objBODataAccess.BO_GetRoutingDealerMapInfo(objclsRoutingRules.ID))
                        {
                            clsDealer objclsDealer = new clsDealer();
                            objclsDealer.Login = item3.DealerID.ToString();
                            objclsDealer.Name = item3.DealerName;
                            lstDealer.Add(objclsDealer);
                        }
                        objclsRoutingRules.Dealers = lstDealer;
                        objclsRoutingRules.DealerCount = lstDealer.Count.ToString();
                        lstRoutingRules.Add(objclsRoutingRules);
                    }
                }
                break;
            case OperationType.INSERT:
                {
                    routingRules = _objBODataAccess.BO_InsertRoutingRule(routingRules);
                    foreach (clsAdditionalConditions item in routingRules.AdditionalConditions)
                    {
                        _objBODataAccess.BO_InsertRoutingRuleAdditionParameters(routingRules.ID, item);
                    }

                    foreach (clsDealer item1 in routingRules.Dealers)
                    {
                        _objBODataAccess.BO_InsertRoutingDealerMapInfo(routingRules.ID, item1);
                    }
                    lstRoutingRules.Add(routingRules);
                }
                break;
            case OperationType.UPDATE:
                {
                    routingRules = _objBODataAccess.BO_UpdateRoutingRule(routingRules);
                    _objBODataAccess.BO_DeleteRoutingRuleAdditionParameters(routingRules.ID);
                    foreach (clsAdditionalConditions item in routingRules.AdditionalConditions)
                    {
                        _objBODataAccess.BO_InsertRoutingRuleAdditionParameters(routingRules.ID, item);
                    }

                    _objBODataAccess.BO_DeleteRoutingDealerMapInfo(routingRules.ID);
                    foreach (clsDealer item1 in routingRules.Dealers)
                    {
                        _objBODataAccess.BO_InsertRoutingDealerMapInfo(routingRules.ID, item1);
                    }
                    lstRoutingRules.Add(routingRules);
                }
                break;
        }

        return lstRoutingRules;
    }

    #endregion
}
