using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLogic.DBML;
using System.Data.Linq;
using ReportServiceClasses;

namespace DataAcessLogic
{
    public class OMSDataAccess
    {
        public const int SUCCESS_ID = -50052;
        public const int FAILURE_ID = -50060;

        dbMan_BO_GetTradeReportDataByDateDataContext s_GetTradeReportDataByDate;
        dbMan_BO_GetTradeReportDataBySideDataContext s_GetTradeReportDataBySide;
        dbMan_BO_GetTradeReportDataByAccountNumberDataContext s_GetTradeReportDataByAccountNumber;
        dbMan_BO_GetTradeReportDataByOrderTypeDataContext s_GetTradeReportDataByOrderType;
        dbMan_BO_GetTradeReportDataByOrderNumberdbmlDataContext s_GetTradeReportDataByOrderNumber;
        dbMan_BO_GetTradeReportDataByTradeNumberDataContext s_GetTradeReportDataByTradeNumber;
        dbMan_BO_GetTradeReportDataByDateAndSideDataContext s_GetTradeReportDataByDateAndSide;
        dbMan_BO_GetTradeReportDataByDateAndAccountNumberDataContext s_GetTradeReportDataByDateAndAccountNumber;
        dbMan_BO_GetTradeReportDataByDateAndOrderTypeDataContext s_GetTradeReportDataByDateAndOrderType;
        dbMan_BO_GetTradeReportDataByDSADataContext s_GetTradeReportDataByDSA;
        dbMan_BO_GetTradeReportDataByDSOTDataContext s_GetTradeReportDataByDSOT;
        dbMan_BO_GetTradeReportDataByAllDataContext s_GetTradeReportDataByAll;
        dbMan_BO_GetTradeReportDataDataContext s_GetTradeReportData;
        dbMan_BO_GetOpenPositionReportDataDataContext s_GetOpenPositionReportData;

        public OMSDataAccess(string omsConnectionString)
        {
            s_GetTradeReportDataByDate = new dbMan_BO_GetTradeReportDataByDateDataContext(omsConnectionString);
            s_GetTradeReportDataBySide = new dbMan_BO_GetTradeReportDataBySideDataContext(omsConnectionString);
            s_GetTradeReportDataByAccountNumber = new dbMan_BO_GetTradeReportDataByAccountNumberDataContext(omsConnectionString);
            s_GetTradeReportDataByOrderType = new dbMan_BO_GetTradeReportDataByOrderTypeDataContext(omsConnectionString);
            s_GetTradeReportDataByOrderNumber = new dbMan_BO_GetTradeReportDataByOrderNumberdbmlDataContext(omsConnectionString);
            s_GetTradeReportDataByTradeNumber = new dbMan_BO_GetTradeReportDataByTradeNumberDataContext(omsConnectionString);
            s_GetTradeReportDataByDateAndSide = new dbMan_BO_GetTradeReportDataByDateAndSideDataContext(omsConnectionString);
            s_GetTradeReportDataByDateAndAccountNumber = new dbMan_BO_GetTradeReportDataByDateAndAccountNumberDataContext(omsConnectionString);
            s_GetTradeReportDataByDateAndOrderType = new dbMan_BO_GetTradeReportDataByDateAndOrderTypeDataContext(omsConnectionString);
            s_GetTradeReportDataByDSA = new dbMan_BO_GetTradeReportDataByDSADataContext(omsConnectionString);
            s_GetTradeReportDataByDSOT = new dbMan_BO_GetTradeReportDataByDSOTDataContext(omsConnectionString);
            s_GetTradeReportDataByAll = new dbMan_BO_GetTradeReportDataByAllDataContext(omsConnectionString);
            s_GetTradeReportData = new dbMan_BO_GetTradeReportDataDataContext(omsConnectionString);
            s_GetOpenPositionReportData = new dbMan_BO_GetOpenPositionReportDataDataContext(omsConnectionString);

        }

        public List<OMS_GetTradeReportDataByDateResult> BO_GetTradeReportDataByDate(DateTime date, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDate)
            {
                ISingleResult<OMS_GetTradeReportDataByDateResult> spResult = s_GetTradeReportDataByDate.OMS_GetTradeReportDataByDate(date, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDateResult>();
            }
        }

        public List<OMS_GetTradeReportDataBySideResult> BO_GetTradeReportDataBySide(string side, int brokerId)
        {
            lock (s_GetTradeReportDataBySide)
            {
                ISingleResult<OMS_GetTradeReportDataBySideResult> spResult = s_GetTradeReportDataBySide.OMS_GetTradeReportDataBySide(side, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataBySideResult>();
            }
        }

        public List<OMS_GetTradeReportDataByAccountNumberResult> BO_GetTradeReportDataByAccountNumber(int accountNumber, int brokerId)
        {
            lock (s_GetTradeReportDataByAccountNumber)
            {
                ISingleResult<OMS_GetTradeReportDataByAccountNumberResult> spResult = s_GetTradeReportDataByAccountNumber.OMS_GetTradeReportDataByAccountNumber(accountNumber, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByAccountNumberResult>();
            }
        }

        public List<OMS_GetTradeReportDataByOrderTypeResult> BO_GetTradeReportDataByOrderType(string orderType, int brokerId)
        {
            lock (s_GetTradeReportDataByOrderType)
            {
                ISingleResult<OMS_GetTradeReportDataByOrderTypeResult> spResult = s_GetTradeReportDataByOrderType.OMS_GetTradeReportDataByOrderType(orderType, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByOrderTypeResult>();
            }
        }

        public List<OMS_GetTradeReportDataByOrderNumberResult> BO_GetTradeReportDataByOrderNumber(Int64 orderNumber, int brokerId)
        {
            lock (s_GetTradeReportDataByOrderNumber)
            {
                ISingleResult<OMS_GetTradeReportDataByOrderNumberResult> spResult = s_GetTradeReportDataByOrderNumber.OMS_GetTradeReportDataByOrderNumber(orderNumber, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByOrderNumberResult>();
            }
        }

        public List<OMS_GetTradeReportDataByTradeNumberResult> BO_GetTradeReportDataByTradeNumber(Int64 tradeNumber, int brokerId)
        {
            lock (s_GetTradeReportDataByTradeNumber)
            {
                ISingleResult<OMS_GetTradeReportDataByTradeNumberResult> spResult = s_GetTradeReportDataByTradeNumber.OMS_GetTradeReportDataByTradeNumber(tradeNumber, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByTradeNumberResult>();
            }
        }

        public List<OMS_GetTradeReportDataByDateAndSideResult> BO_GetTradeReportDataByDateAndSide(DateTime dateValue, string side, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDateAndSide)
            {
                ISingleResult<OMS_GetTradeReportDataByDateAndSideResult> spResult = s_GetTradeReportDataByDateAndSide.OMS_GetTradeReportDataByDateAndSide(dateValue, side, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDateAndSideResult>();
            }
        }

        public List<OMS_GetTradeReportDataByDateAndAccountNumberResult> BO_GetTradeReportDataByDateAndAccountNumber(DateTime dateValue, int accountNo, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDateAndAccountNumber)
            {
                ISingleResult<OMS_GetTradeReportDataByDateAndAccountNumberResult> spResult = s_GetTradeReportDataByDateAndAccountNumber.
                    OMS_GetTradeReportDataByDateAndAccountNumber(dateValue, accountNo, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDateAndAccountNumberResult>();
            }
        }

        public List<OMS_GetTradeReportDataByDateAndOrderTypeResult> BO_GetTradeReportDataByDateAndOrderType(DateTime dateValue, string orderType, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDateAndOrderType)
            {
                ISingleResult<OMS_GetTradeReportDataByDateAndOrderTypeResult> spResult = s_GetTradeReportDataByDateAndOrderType.
                    OMS_GetTradeReportDataByDateAndOrderType(dateValue, orderType, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDateAndOrderTypeResult>();
            }
        }

        public List<OMS_GetTradeReportDataByDSAResult> BO_GetTradeReportDataByDSA(DateTime dateValue, string side, int accountNo, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDSA)
            {
                ISingleResult<OMS_GetTradeReportDataByDSAResult> spResult = s_GetTradeReportDataByDSA.
                    OMS_GetTradeReportDataByDSA(dateValue, side, accountNo, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDSAResult>();
            }
        }

        public List<OMS_GetTradeReportDataByDSOTResult> BO_GetTradeReportDataByDSOT(DateTime dateValue, string side, string orderType, DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByDSOT)
            {
                ISingleResult<OMS_GetTradeReportDataByDSOTResult> spResult = s_GetTradeReportDataByDSOT.
                    OMS_GetTradeReportDataByDSOT(dateValue, side, orderType, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByDSOTResult>();
            }
        }

        public List<OMS_GetTradeReportDataByAllResult> BO_GetTradeReportDataByAll(DateTime dateValue, string side, int accountNo, string orderType,
            DateTime toDate, int brokerId)
        {
            lock (s_GetTradeReportDataByAll)
            {
                ISingleResult<OMS_GetTradeReportDataByAllResult> spResult = s_GetTradeReportDataByAll.
                    OMS_GetTradeReportDataByAll(dateValue, side, accountNo, orderType, toDate, brokerId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataByAllResult>();
            }
        }

        public List<OMS_GetTradeReportDataResult> BO_GetTradeReportData(DateTime dateValue, string side, int accountNo, string orderType,
            DateTime toDate, int brokerId, string symbolName, int BrokerParentID)
        {
            lock (s_GetTradeReportData)
            {
                ISingleResult<OMS_GetTradeReportDataResult> spResult = s_GetTradeReportData.OMS_GetTradeReportData(dateValue,
                    side, accountNo, orderType, toDate, brokerId, symbolName, BrokerParentID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetTradeReportDataResult>();
            }
        }

        public List<OMS_GetOpenPositionReportDataResult> BO_GetOpenPositinReportData(DateTime dateValue, string side, int accountNo, string orderType,
            DateTime toDate, int brokerId, string symbolName, int BrokerParentID)
        {
            lock (s_GetOpenPositionReportData)
            {
                ISingleResult<OMS_GetOpenPositionReportDataResult> spResult = s_GetOpenPositionReportData.OMS_GetOpenPositionReportData(dateValue,
                    side, accountNo, orderType, toDate, brokerId, symbolName, BrokerParentID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<OMS_GetOpenPositionReportDataResult>();
            }
        }

    }

    public class BODataAccess
    {
        public const int SUCCESS_ID = -50052;
        public const int FAILURE_ID = -50060;

        dbMan_Report_OrderReportsDataContext s_OrderReports;
        dbMan_Report_ClientCommissionReport_MTMDataContext s_lientCommissionReport;
        dbMan_Report_StockLevelDataContext s_StockLevel;
        dbMan_Report_ClientHoldingStocklDataContext s_ClientHoldingStock;
        dbMan_BO_GetOrderTypesDataContext s_GetOrderTypes;
        dbMan_BO_GetSideTypesDataContext s_GetSideTypes;
        dbMan_Report_AccountTransReportDataContext s_AccountTrans;
        dbMan_BO_GetTIFTypesDataContext s_GetTIFTypes;
        dbMan_Report_DayClosingReportDataContext s_DayClosing;
        dbMan_BO_GetRoutingAdditionalConditionTypeDataContext s_RoutingAdditionCondtion;
        dbMan_BO_GetRoutingOrderTypeDataContext s_RoutingOrderType;
        dbMan_BO_GetRoutingRequestTypeDataContext s_RoutingRequestType;
        dbMan_BO_GetRoutingPerformActionDataContext s_RoutingPerformAction;
        dbMan_BO_GetRoutingDealerMapInfoDataContext s_GetRoutingDealerMapInfo;
        dbMan_BO_GetRoutingRuleAdditionParametersDataContext s_GetRoutingRuleAdditionParameters;
        dbMan_BO_GetRoutingRulesInfoDataContext s_GetRoutingRulesInfo;
        dbMan_BO_InsertRoutingDealerMapInfoDataContext s_InsertRoutingDealerMapInfo;
        dbMan_BO_InsertRoutingRuleAdditionParametersDataContext s_InsertRoutingRuleAdditionParameters;
        dbMan_BO_InsertRoutingRulesDataContext s_InsertRoutingRules;
        dbMan_BO_UpdateRoutingDealerMapInfoDataContext s_UpdateRoutingDealerMapInfo;
        dbMan_BO_UpdateRoutingRuleAdditionParametersDataContext s_UpdateRoutingRuleAdditionParameters;
        dbMan_BO_UpdateRoutingRulesDataContext s_BO_UpdateRoutingRules;
        dbMan_BO_GetDealerListDataContext s_DealerList;
        dbMan_BO_DeleteRoutingDealerMapInfoDataContext s_BO_DeleteRoutingDealerMapInfo;
        dbMan_BO_DeleteRoutingRuleAdditionParametersDataContext s_BO_DeleteRoutingRuleAdditionParameters;

        public BODataAccess(string connectionStr)
        {
            s_OrderReports = new dbMan_Report_OrderReportsDataContext(connectionStr);
            s_lientCommissionReport = new dbMan_Report_ClientCommissionReport_MTMDataContext(connectionStr);
            s_StockLevel = new dbMan_Report_StockLevelDataContext(connectionStr);
            s_ClientHoldingStock = new dbMan_Report_ClientHoldingStocklDataContext(connectionStr);
            s_GetOrderTypes = new dbMan_BO_GetOrderTypesDataContext(connectionStr);
            s_GetSideTypes = new dbMan_BO_GetSideTypesDataContext(connectionStr);
            s_AccountTrans = new dbMan_Report_AccountTransReportDataContext(connectionStr);
            s_GetTIFTypes = new dbMan_BO_GetTIFTypesDataContext(connectionStr);
            s_DayClosing = new dbMan_Report_DayClosingReportDataContext(connectionStr);
            s_RoutingAdditionCondtion = new dbMan_BO_GetRoutingAdditionalConditionTypeDataContext(connectionStr);
            s_RoutingOrderType = new dbMan_BO_GetRoutingOrderTypeDataContext(connectionStr);
            s_RoutingRequestType = new dbMan_BO_GetRoutingRequestTypeDataContext(connectionStr);
            s_RoutingPerformAction = new dbMan_BO_GetRoutingPerformActionDataContext(connectionStr);
            s_GetRoutingDealerMapInfo = new dbMan_BO_GetRoutingDealerMapInfoDataContext(connectionStr);
            s_GetRoutingRuleAdditionParameters = new dbMan_BO_GetRoutingRuleAdditionParametersDataContext(connectionStr);
            s_GetRoutingRulesInfo = new dbMan_BO_GetRoutingRulesInfoDataContext(connectionStr);
            s_InsertRoutingDealerMapInfo = new dbMan_BO_InsertRoutingDealerMapInfoDataContext(connectionStr);
            s_InsertRoutingRuleAdditionParameters = new dbMan_BO_InsertRoutingRuleAdditionParametersDataContext(connectionStr);
            s_InsertRoutingRules = new dbMan_BO_InsertRoutingRulesDataContext(connectionStr);
            s_UpdateRoutingDealerMapInfo = new dbMan_BO_UpdateRoutingDealerMapInfoDataContext(connectionStr);
            s_UpdateRoutingRuleAdditionParameters = new dbMan_BO_UpdateRoutingRuleAdditionParametersDataContext(connectionStr);
            s_BO_UpdateRoutingRules = new dbMan_BO_UpdateRoutingRulesDataContext(connectionStr);
            s_DealerList = new dbMan_BO_GetDealerListDataContext(connectionStr);
            s_BO_DeleteRoutingDealerMapInfo = new dbMan_BO_DeleteRoutingDealerMapInfoDataContext(connectionStr);
            s_BO_DeleteRoutingRuleAdditionParameters = new dbMan_BO_DeleteRoutingRuleAdditionParametersDataContext(connectionStr);
        }
        public int BO_DeleteRoutingDealerMapInfo(int ruleID)
        {
            int Result;
            lock (s_BO_DeleteRoutingDealerMapInfo)
            {
                int spResult = s_BO_DeleteRoutingDealerMapInfo.BO_DeleteRoutingDealerMapInfo(ruleID);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }
        public int BO_DeleteRoutingRuleAdditionParameters(int ruleID)
        {
            int Result;
            lock (s_BO_DeleteRoutingRuleAdditionParameters)
            {
                int spResult = s_BO_DeleteRoutingRuleAdditionParameters.BO_DeleteRoutingRuleAdditionParameter(ruleID);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }
        public int BO_UpdateRoutingRuleAdditionParameters(int ruleID, clsAdditionalConditions obj)
        {
            int Result;
            lock (s_UpdateRoutingRuleAdditionParameters)
            {
                int spResult = s_UpdateRoutingRuleAdditionParameters.BO_UpdateRoutingRuleAdditionParameter(ruleID, 0, obj.Type, obj.Condition, obj.Value);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }
        public clsRoutingRules BO_UpdateRoutingRule(clsRoutingRules obj)
        {
            lock (s_BO_UpdateRoutingRules)
            {
                int spResult = s_BO_UpdateRoutingRules.BO_UpdateRoutingRules(obj.ID, obj.Name, obj.PerformActionID, obj.PerformValue, obj.RequestTypeID, obj.OrderTypeID, obj.IsEnable);
                if (spResult == FAILURE_ID)
                {
                    obj.ServerResponseID = FAILURE_ID;
                }
                else
                    obj.ServerResponseID = SUCCESS_ID;
            }
            return obj;
        }

        public int BO_UpdateRoutingRuleAdditionParameters(int ruleID, clsDealer obj)
        {
            int Result;
            lock (s_UpdateRoutingDealerMapInfo)
            {
                int spResult = s_UpdateRoutingDealerMapInfo.BO_UpdateRoutingDealerMapInfo(ruleID, Convert.ToInt32(obj.Login), obj.Name);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }

        public clsRoutingRules BO_InsertRoutingRule(clsRoutingRules obj)
        {
            lock (s_InsertRoutingRules)
            {
                int? id=0;
                int spResult = s_InsertRoutingRules.BO_InsertRoutingRules(ref id, obj.Name, obj.PerformActionID, obj.PerformValue, obj.RequestTypeID, obj.OrderTypeID, obj.IsEnable);
                obj.ID = id.Value;
                if (spResult == FAILURE_ID)
                {
                    obj.ServerResponseID = FAILURE_ID;
                }
                else
                    obj.ServerResponseID = SUCCESS_ID;
            }
            return obj;
        }

        public int BO_InsertRoutingRuleAdditionParameters(int ruleID, clsAdditionalConditions obj)
        {
            int Result;
            lock (s_InsertRoutingRuleAdditionParameters)
            {
                int spResult = s_InsertRoutingRuleAdditionParameters.BO_InsertRoutingRuleAdditionParameter(ruleID, obj.TypeID, obj.Type,obj.Condition,obj.Value);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }
        public int BO_InsertRoutingDealerMapInfo(int ruleID, clsDealer obj)
        {
            int Result;
            lock (s_InsertRoutingDealerMapInfo)
            {
                int spResult = s_InsertRoutingDealerMapInfo.BO_InsertRoutingDealerMapInfo(ruleID,Convert.ToInt32(obj.Login.Trim()), obj.Name);

                if (spResult == FAILURE_ID)
                {
                    Result = FAILURE_ID;
                }
                else
                    Result = SUCCESS_ID;
            }
            return Result;
        }

        public List<BO_GetRoutingDealerMapInfoResult> BO_GetRoutingDealerMapInfo(int RoutingRuleId)
        {
            lock (s_GetRoutingDealerMapInfo)
            {
                ISingleResult<BO_GetRoutingDealerMapInfoResult> spResult = s_GetRoutingDealerMapInfo.BO_GetRoutingDealerMapInfo(RoutingRuleId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<BO_GetRoutingRuleAdditionParameterResult> BO_GetRoutingRuleAdditionParameter(int RoutingRuleId)
        {
            lock (s_GetRoutingRuleAdditionParameters)
            {
                ISingleResult<BO_GetRoutingRuleAdditionParameterResult> spResult = s_GetRoutingRuleAdditionParameters.BO_GetRoutingRuleAdditionParameter(RoutingRuleId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<BO_GetRoutingRulesInfoResult> BO_GetRoutingRuleAdditionParameter()
        {
            lock (s_GetRoutingRulesInfo)
            {
                ISingleResult<BO_GetRoutingRulesInfoResult> spResult = s_GetRoutingRulesInfo.BO_GetRoutingRulesInfo();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<Report_OrderReports1Result> BO_GetOrderReportData(DateTime? dateValue, DateTime? toDate, string side, int? accountNo, string orderType,
            long? orderID, int BrokerID, string symbolName, int BrokerParentID, int TIF_ID)
        {
            lock (s_OrderReports)
            {
                ISingleResult<Report_OrderReports1Result> spResult = s_OrderReports.Report_OrderReports1(orderID, accountNo, dateValue, toDate, orderType,
                    side, BrokerID, symbolName, BrokerParentID, TIF_ID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_OrderReports1Result> BO_GetOrderReportData(DateTime? dateValue, DateTime? toDate)
        {
            lock (s_OrderReports)
            {
                ISingleResult<Report_OrderReports1Result> spResult = s_OrderReports.Report_OrderReports1(0, 0, dateValue, toDate, string.Empty,
                    string.Empty, 0, string.Empty, 0, 0);
                //            var spResult = s_OrderReports.ExecuteQuery<Report_OrderReportsResult>("EXEC Report_OrderReports {0},{1},{2},{3}",
                //0,0,dateValue, toDate);

                //if ((int)spResult.ReturnValue == FAILURE_ID)
                //{
                //    return null;
                //}

                return spResult.ToList();
            }
        }

        public List<Report_ClientCommissionReport_MTMResult> BO_GetClientCommissionReportData(DateTime? FromDateValue, DateTime? ToDateValue, int? accountNo, string symbol, int brokerId,
            int BrokerParentID)
        {
            lock (s_lientCommissionReport)
            {
                ISingleResult<Report_ClientCommissionReport_MTMResult> spResult = s_lientCommissionReport.Report_ClientCommissionReport_MTM(accountNo,
                    FromDateValue, symbol, brokerId, BrokerParentID, ToDateValue);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_StockLevelResult> BO_GetStockLevelReportData(string symbol, string securityName, int brokerId, int BrokerParentID)
        {
            lock (s_StockLevel)
            {
                ISingleResult<Report_StockLevelResult> spResult = s_StockLevel.Report_StockLevel(symbol, securityName, brokerId, BrokerParentID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_ClientHoldingStockResult> BO_GetClientHoldingStockReportData(string symbol, DateTime dateValue, int brokerId, int BrokerParentID, int AccountId)
        {
            lock (s_ClientHoldingStock)
            {
                ISingleResult<Report_ClientHoldingStockResult> spResult;
                if (AccountId==0)
                {
                    spResult = s_ClientHoldingStock.Report_ClientHoldingStock(symbol, dateValue, brokerId, BrokerParentID, null);    
                }
                else
                {
                    spResult = s_ClientHoldingStock.Report_ClientHoldingStock(symbol, dateValue, brokerId, BrokerParentID, AccountId);
                }
                

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_ClientHoldingStockResult> BO_GetClientHoldingStockReportData()
        {
            lock (s_ClientHoldingStock)
            {
                var spResult = s_ClientHoldingStock.ExecuteQuery<Report_ClientHoldingStockResult>("EXEC Report_ClientHoldingStock");

                //if ((int)spResult.ReturnValue == FAILURE_ID)
                //{
                //    return null;
                //}

                return spResult.ToList();
            }
        }

        public List<BO_GetOMSOrderTypesResult> BO_GetOrderTypes()
        {
            lock (s_GetOrderTypes)
            {
                ISingleResult<BO_GetOMSOrderTypesResult> spResult = s_GetOrderTypes.BO_GetOMSOrderTypes();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetSideTypesResult> BO_GetSideTypes()
        {
            lock (s_GetSideTypes)
            {
                ISingleResult<BO_GetSideTypesResult> spResult = s_GetSideTypes.BO_GetSideTypes();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_AccountTransactionResult> BO_GetAccountTransReportData(DateTime fromDate, DateTime toDate, int accountNo, int brokerID
            , int BrokerParentID)
        {
            lock (s_AccountTrans)
            {
                ISingleResult<Report_AccountTransactionResult> spResult = s_AccountTrans.Report_AccountTransaction(fromDate,
                    toDate, accountNo, brokerID, BrokerParentID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetTIFTypesResult> BO_GetTIFTypes()
        {
            lock (s_GetTIFTypes)
            {
                ISingleResult<BO_GetTIFTypesResult> spResult = s_GetTIFTypes.BO_GetTIFTypes();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<Report_DayClosingReportResult> BO_GetDayClosingReportData(DateTime date, string symbol, int brokerId, int brokerParentId)
        {
            lock (s_DayClosing)
            {
                ISingleResult<Report_DayClosingReportResult> spResult = s_DayClosing.Report_DayClosingReport(symbol, date, brokerId, brokerParentId);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetRoutingAdditionalConditionTypeResult> BO_GetRoutingAddCond()
        {
            lock (s_RoutingAdditionCondtion)
            {
                ISingleResult<BO_GetRoutingAdditionalConditionTypeResult> spResult = s_RoutingAdditionCondtion.BO_GetRoutingAdditionalConditionType();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<BO_GetRoutingOrderTypeResult> BO_GetRoutingOrderType()
        {
            lock (s_RoutingOrderType)
            {
                ISingleResult<BO_GetRoutingOrderTypeResult> spResult = s_RoutingOrderType.BO_GetRoutingOrderType();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<BO_GetRoutingRequestTypeResult> BO_GetRoutingRequestType()
        {
            lock (s_RoutingRequestType)
            {
                ISingleResult<BO_GetRoutingRequestTypeResult> spResult = s_RoutingRequestType.BO_GetRoutingRequestType();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<BO_GetRoutingPerformActionResult> BO_GetRoutingActionType()
        {
            lock (s_RoutingPerformAction)
            {
                ISingleResult<BO_GetRoutingPerformActionResult> spResult = s_RoutingPerformAction.BO_GetRoutingPerformAction();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetDealerListResult> BO_GetDealerList()
        {
            lock (s_DealerList)
            {
                ISingleResult<BO_GetDealerListResult> spResult = s_DealerList.BO_GetDealerList();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
    }
}
