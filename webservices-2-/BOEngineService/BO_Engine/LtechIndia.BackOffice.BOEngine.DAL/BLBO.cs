using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using clsInterface4OME;
using LtechIndia.BackOffice.BOEngine.DAL.DB_New;
using BOEngineServiceClasses;
using System.Data.SqlClient;
using System.Data;

namespace LtechIndia.BackOffice.BOEngine.DAL
{
    public partial class BLBO
    {
        public const int SUCCESS_ID = -50052;
        public const int FAILURE_ID = -50060;
        DB_New.dbMan_BO_HolidayDeleteDataContext s_BO_HolidayDelete;
        dbMan_BO_AddNewSymbolDataContext s_AddNewSymbol;
        dbMan_BO_AddSymbolSessionDataContext s_AddSymbolSession;
        dbMan_BO_GetClientsBankInfoDataContext s_GetClientsBankInfo;
        dbMan_BO_GetParticipantAccountInfoDataContext s_GetParticipantAccountInfo;
        dbMan_BO_GetClientAccountInformationDataContext s_GetClientAccountInformation;
        dbMan_BO_GetCountryMasterInfoDataContext s_GetCountryMasterInfo;
        dbMan_BO_GetTradingGateWayInfoDataContext s_GetTradingGateWayInfo;
        dbMan_BO_GetTradingGatewayMapsInfoDataContext s_GetTradingGatewayMaps;
        dbMan_BO_InsertTradingGateWayInfoDataContext s_InsertTradingGateWayInfo;
        dbMan_BO_InsertTradingGateWayMapsInfoDataContext s_InsertTradingGateWayMapsInfo;
        dbMan_BO_GetAllAccountGroupInfoDataContext s_AllAccountGroupInfo;
        dbMan_BO_UpdateTradingGateWayInfoDataContext s_UpdateTradingGateWayInfo;
        dbMan_BO_UpdateTradingGateWayMapsDataContext s_UpdateTradingGateWayMaps;
        dbMan_BO_GetCurrencyListDataContext s_GetCurrencyList;
        dbMan_BO_GetBrokerTypesListDataContext s_GetBrokerTypesList;
        dbMan_BO_GetLeverageListDataContext s_GetLeverageList;
        dbMan_BO_GetTimeSettingsDataContext s_GetTimeSettings;
        dbMan_BO_GetParticipantTypeListDataContext s_GetParticipantTypeList;
        dbMan_BO_GetBrokersCollateralInfoDataContext s_GetBrokersCollateralInfo;
        dbMan_BO_GetAllCollateralTypesDataContext s_GetAllCollateralTypes;
        dbMan_BO_GetLastCollateralTransInfoForAccGrpDataContext s_GetLastCollateralTransInfoForAccGrp;
        dbMan_BO_InsertCollateralTransactionDataContext s_InsertCollateralTransaction;
        dbMan_BO_GetAllModulesDataContext s_GetAllModules;
        dbMan_BO_AuthenticateLoginDataContext s_AuthenticateLogin;
        dbMan_BO_GetIPAccessListDataContext s_GetIPAccessListDataContext;
        dbMan_BO_UpdateIPAccessListDataContext s_UpdateIPAccessListDataContext;
        dbMan_BO_InsertIPAccessListDataContext s_InsertIPAccessListDataContext;
        dbMan_BO_DeleteIPAccessListDataContext s_DeleteIPAccessListDataContext;
        dbMan_BO_GetBrokersInfoDataContext s_GetBrokersInfoDataContext;
        dbMan_BO_GetBrokersListDataContext s_GetBrokersListDataContext;
        dbMan_BO_GetBrokersSymbolMapInfoDataContext s_GetBrokersSymbolMapInfoDataContext;
        dbMan_BO_InsertIntoBrokersDataContext s_InsertIntoBrokersDataContext;
        dbMan_BO_InsertBrokersSymbolMapInfoDataContext s_InsertBrokersSymbolMapInfoDataContext;
        dbMan_BO_UpdateBrokersInfoDataContext s_UpdateBrokersInfoDataContext;
        dbMan_BO_UpdateBrokersRelativeSymbolMapDataContext s_UpdateBrokersRelativeSymbolMapDataContext;
        dbMan_BO_UpdateBrokersSymbolMapInfoDataContext s_UpdateBrokersSymbolMapInfoDataContext;
        dbMan_BO_GetAllSymbolsDataContext s_GetAllSymbolsDataContext;
        dbMan_BO_GetAllSymbolsNewDataContext s_GetAllSymbolsNewDataContext;
        dbMan_BO_GetAllFeeTypeDataContext s_GetAllFeeTypeDataContext;
        dbMan_BO_GetAllTaxTypeDataContext s_GetAllTaxTypeDataContext;
        dbMan_BO_GetBrokerSymbolSettingDataContext s_GetBrokerSymbolSettingDataContext;
        dbMan_BO_DeleteBrokersSymbolDataContext s_DeleteBrokersSymbolDataContext;
        dbMan_BO_SelectSymbolChargesDataContext s_SelectSymbolChargesDataContext;
        dbMan_BO_InsertIntoSymbolChargesDataContext s_InsertIntoSymbolChargesDataContext;
        dbMan_BO_UpdateSymbolChargesDataContext s_UpdateSymbolChargesDataContext;
        dbMan_BO_DeleteSymbolChargesDataContext s_DeleteSymbolChargesDataContext;
        dbMan_BO_GetSecurityTypeListDataContext s_GetSecurityTypeListDataContext;
        dbMan_BO_GetDeliveryUnitDataContext s_GetDeliveryUnitDataContext;
        dbMan_BO_GetOrderTypesDataContext s_GetOrderTypesDataContext;
        dbMan_BO_GetProductNamesDataContext s_GetProductNamesDataContext;
        dbMan_BO_GetPredefinedRolesDataContext s_GetPredefinedRolesDataContext;
        dbMan_BO_OMEGetMapOrderDataContext s_OMEGetMapOrderDataContext;
        dbMan_BO_DeleteSymbolAliasDataContext s_DeleteSymbolAliasDataContext;
        dbMan_BO_GetLPNameListDataContext s_GetLPNameListDataContext;
        dbMan_BO_ClientLoginAuthDataContext s_ClientLoginAuthDataContext;
        dbMan_BO_InsertTGAccountConnectionSettingsDataContext s_InsertTGAccountConnectionSettingsDataContext;
        dbMan_BO_GetTGAccountConnectionSettingsDataContext s_GetTGAccountConnectionSettingsDataContext;
        dbMan_BO_UpdateTGAccountConnectionSettingsDataContext s_UpdateTGAccountConnectionSettingsDataContext;
        dbMan_BO_GetClientAccountTypesDataContext s_GetClientAccountTypesDataContext;
        dbMan_BO_GetVirtualDealerInfoDataContext s_GetVirtualDealerInfoDataContext;
        dbMan_BO_InsertVirtualDealerInfoDataContext s_InsertVirtualDealerInfoDataContext;
        dbMan_BO_UpdateVirtualDealerInfoDataContext s_UpdateVirtualDealerInfoDataContext;
        dbMan_BO_DeleteVirtualDealerDataContext s_DeleteVirtualDealerDataContext;
        dbMan_BO_GetCollateralTransactionHistoryDataContext s_GetCollateralTransactionHistoryDataContext;
        dbMan_BO_GetAccountIDsByAccountTypeIDDataContext s_GetAccountIDsByAccountTypeIDDataContext;
        dbMan_BO_ChangePasswordDataContext s_ChangePasswordDataContext;
        dbMan_BO_GetInstClosingPriceDataContext s_GetInstClosingPriceDataContext;
        dbMan_BO_InsertInstClosingPriceDataContext s_InsertInstClosingPriceDataContext;
        dbMan_BO_UpdateInstClosingPriceDataContext s_pdateInstClosingPriceDataContext;
        dbMan_BO_GetUnexpiredSymbolsDataContext s_GetUnexpiredSymbolsDataContext;
        dbMan_BO_GetHedgeTypesDataContext s_GetHedgeTypesDataContext;
        dbMan_BO_GetTGListDataContext s_GetTGListDataContext;
        dbMan_BO_GetTGSymbolsInfoDataContext s_GetTGSymbolsInfoDataContext;        
        dbMan_BO_GetBrokersLogDataContext s_GetBrokersLogDataContext;
        dbMan_BO_InsertBrokersLogDataContext s_InsertBrokersLogDataContext;
        dbMan_BO_GetAccountTransactionDataContext s_GetAccountTransactionDataContext;
        dbMan_BO_UpdateAccountTransactionDataContext s_UpdateAccountTransactionDataContext;
        dbMan_BO_AddSymbolQuotesSessionDataContext s_AddSymbolQuotesSession;
        dbMan_BO_AddSymbolTradeSessionDataContext s_AddSymbolTradeSession;
        dbMan_BO_GetContractSizeDataContext s_GetContractSize;
        dbMan_BO_FeesMasterSelectDataContext s_FeesMasterSelect;
        dbMan_BO_FeeMasterInsertDataContext s_FeeMasterInsert;
        dbMan_BO_FeesMasterUpdateDataContext s_FeesMasterUpdate;
        dbMan_BO_FeesMasterDeleteDataContext s_FeesMasterDelete;
        dbMan_BO_TaxMasterSelectDataContext s_TaxMasterSelect;
        dbMan_BO_TaxMasterDeleteDataContext s_TaxMasterDelete;
        dbMan_BO_TaxMasterInsertDataContext s_TaxMasterInsert;
        dbMan_BO_TaxMasterupdateDataContext s_TaxMasterupdate;
        dbMan_BO_GetOrderInfoDataContext s_GetOrderInfo;
        dbMan_OMS_OrderDeleteDataContext s_OrderDelete;
        dbMan_OMS_OrderUpdateDataContext s_OrderUpdate;
        dbMan_BO_GetCommonSettingsNewDataContext s_CommonSettingsNew;
        dbMan_BO_UpdateCommonSettingDataContext s_UpdateCommonSetting;
        dbMan_BO_ModifyTradeDataContext s_ModifyTrade;
        dbMan_BO_SettleTradeDataContext s_SettleTrade;
        dbMan_BO_GetTradeInfoDataContext s_GetTradeInfo;
        dbMan_BO_UpdateHistoricalDataDataContext s_UpdateHistoricalDataDataContext;
        dbMan_BO_OME_InsertNewOrderDataContext s_OME_InsertNewOrderDataContext;
        dbMan_BO_OMSExchange_InsertNewOrderDataContext s_OMSExchange_InsertNewOrderDataContext;
        //SqlConnection conn = null;
        public BLBO(string lnqConnectionString, string lnqOMSExchangeConnectionStr, string OMEConnectionStr, string OME_OrderConnectionStr)
        {
            s_BO_HolidayDelete = new dbMan_BO_HolidayDeleteDataContext(lnqConnectionString);
            s_AddNewSymbol = new dbMan_BO_AddNewSymbolDataContext(lnqConnectionString);
            s_AddSymbolSession = new dbMan_BO_AddSymbolSessionDataContext(lnqConnectionString);
            s_GetClientsBankInfo = new dbMan_BO_GetClientsBankInfoDataContext(lnqConnectionString);
            s_GetParticipantAccountInfo = new dbMan_BO_GetParticipantAccountInfoDataContext(lnqConnectionString);
            s_GetClientAccountInformation = new dbMan_BO_GetClientAccountInformationDataContext(lnqConnectionString);
            s_GetCountryMasterInfo = new dbMan_BO_GetCountryMasterInfoDataContext(lnqConnectionString);
            s_GetTradingGateWayInfo = new dbMan_BO_GetTradingGateWayInfoDataContext(lnqConnectionString);
            s_GetTradingGatewayMaps = new dbMan_BO_GetTradingGatewayMapsInfoDataContext(lnqConnectionString);
            s_InsertTradingGateWayInfo = new dbMan_BO_InsertTradingGateWayInfoDataContext(lnqConnectionString);
            s_InsertTradingGateWayMapsInfo = new dbMan_BO_InsertTradingGateWayMapsInfoDataContext(lnqConnectionString);
            s_AllAccountGroupInfo = new dbMan_BO_GetAllAccountGroupInfoDataContext(lnqConnectionString);
            s_GetBrokerTypesList = new dbMan_BO_GetBrokerTypesListDataContext(lnqConnectionString);
            s_UpdateTradingGateWayInfo = new dbMan_BO_UpdateTradingGateWayInfoDataContext(lnqConnectionString);
            s_UpdateTradingGateWayMaps = new dbMan_BO_UpdateTradingGateWayMapsDataContext(lnqConnectionString);
            s_GetTimeSettings = new dbMan_BO_GetTimeSettingsDataContext(lnqConnectionString);
            s_GetLeverageList = new dbMan_BO_GetLeverageListDataContext(lnqConnectionString);
            s_GetCurrencyList = new dbMan_BO_GetCurrencyListDataContext(lnqConnectionString);
            s_GetParticipantTypeList = new dbMan_BO_GetParticipantTypeListDataContext(lnqConnectionString);
            s_GetIPAccessListDataContext = new dbMan_BO_GetIPAccessListDataContext(lnqConnectionString);
            s_UpdateIPAccessListDataContext = new dbMan_BO_UpdateIPAccessListDataContext(lnqConnectionString);
            s_InsertIPAccessListDataContext = new dbMan_BO_InsertIPAccessListDataContext(lnqConnectionString);
            s_DeleteIPAccessListDataContext = new dbMan_BO_DeleteIPAccessListDataContext(lnqConnectionString);
            s_FeesMasterSelect = new dbMan_BO_FeesMasterSelectDataContext(lnqConnectionString);
            s_FeeMasterInsert = new dbMan_BO_FeeMasterInsertDataContext(lnqConnectionString);
            s_FeesMasterUpdate = new dbMan_BO_FeesMasterUpdateDataContext(lnqConnectionString);
            s_FeesMasterDelete = new dbMan_BO_FeesMasterDeleteDataContext(lnqConnectionString);
            s_GetBrokersInfoDataContext = new dbMan_BO_GetBrokersInfoDataContext(lnqConnectionString);
            s_GetBrokersListDataContext = new dbMan_BO_GetBrokersListDataContext(lnqConnectionString);
            s_GetBrokersSymbolMapInfoDataContext = new dbMan_BO_GetBrokersSymbolMapInfoDataContext(lnqConnectionString);
            s_InsertIntoBrokersDataContext = new dbMan_BO_InsertIntoBrokersDataContext(lnqConnectionString);
            s_TaxMasterSelect = new dbMan_BO_TaxMasterSelectDataContext(lnqConnectionString);
            s_TaxMasterDelete = new dbMan_BO_TaxMasterDeleteDataContext(lnqConnectionString);
            s_TaxMasterInsert = new dbMan_BO_TaxMasterInsertDataContext(lnqConnectionString);
            s_TaxMasterupdate = new dbMan_BO_TaxMasterupdateDataContext(lnqConnectionString);
            s_DeleteSymbolAliasDataContext = new dbMan_BO_DeleteSymbolAliasDataContext(lnqConnectionString);

            s_InsertBrokersSymbolMapInfoDataContext = new dbMan_BO_InsertBrokersSymbolMapInfoDataContext(lnqConnectionString);
            s_UpdateBrokersInfoDataContext = new dbMan_BO_UpdateBrokersInfoDataContext(lnqConnectionString);
            s_UpdateBrokersRelativeSymbolMapDataContext = new dbMan_BO_UpdateBrokersRelativeSymbolMapDataContext(lnqConnectionString);
            s_UpdateBrokersSymbolMapInfoDataContext = new dbMan_BO_UpdateBrokersSymbolMapInfoDataContext(lnqConnectionString);
            s_GetAllSymbolsDataContext = new dbMan_BO_GetAllSymbolsDataContext(lnqConnectionString);
            s_GetAllSymbolsNewDataContext = new dbMan_BO_GetAllSymbolsNewDataContext(lnqConnectionString);
            s_GetAllFeeTypeDataContext = new dbMan_BO_GetAllFeeTypeDataContext(lnqConnectionString);
            s_GetAllTaxTypeDataContext = new dbMan_BO_GetAllTaxTypeDataContext(lnqConnectionString);
            s_GetBrokerSymbolSettingDataContext = new dbMan_BO_GetBrokerSymbolSettingDataContext(lnqConnectionString);
            s_DeleteBrokersSymbolDataContext = new dbMan_BO_DeleteBrokersSymbolDataContext(lnqConnectionString);
            s_SelectSymbolChargesDataContext = new dbMan_BO_SelectSymbolChargesDataContext(lnqConnectionString);
            s_InsertIntoSymbolChargesDataContext = new dbMan_BO_InsertIntoSymbolChargesDataContext(lnqConnectionString);
            s_UpdateSymbolChargesDataContext = new dbMan_BO_UpdateSymbolChargesDataContext(lnqConnectionString);
            s_DeleteSymbolChargesDataContext = new dbMan_BO_DeleteSymbolChargesDataContext(lnqConnectionString);
            s_GetOrderInfo = new dbMan_BO_GetOrderInfoDataContext(lnqOMSExchangeConnectionStr);
            s_GetSecurityTypeListDataContext = new dbMan_BO_GetSecurityTypeListDataContext(lnqConnectionString);
            s_OrderDelete = new dbMan_OMS_OrderDeleteDataContext(lnqOMSExchangeConnectionStr);
            s_GetDeliveryUnitDataContext = new dbMan_BO_GetDeliveryUnitDataContext(lnqConnectionString);
            s_GetOrderTypesDataContext = new dbMan_BO_GetOrderTypesDataContext(lnqConnectionString);
            s_GetProductNamesDataContext = new dbMan_BO_GetProductNamesDataContext(lnqConnectionString);
            s_OrderUpdate = new dbMan_OMS_OrderUpdateDataContext(lnqOMSExchangeConnectionStr);
            s_GetBrokersCollateralInfo = new dbMan_BO_GetBrokersCollateralInfoDataContext(lnqConnectionString);
            s_GetAllCollateralTypes = new dbMan_BO_GetAllCollateralTypesDataContext(lnqConnectionString);
            s_GetLastCollateralTransInfoForAccGrp = new dbMan_BO_GetLastCollateralTransInfoForAccGrpDataContext(lnqConnectionString);
            s_InsertCollateralTransaction = new dbMan_BO_InsertCollateralTransactionDataContext(lnqConnectionString);
            s_GetAllModules = new dbMan_BO_GetAllModulesDataContext(lnqConnectionString);
            s_AuthenticateLogin = new dbMan_BO_AuthenticateLoginDataContext(lnqConnectionString);
            s_GetPredefinedRolesDataContext = new dbMan_BO_GetPredefinedRolesDataContext(lnqConnectionString);
            s_OMEGetMapOrderDataContext = new dbMan_BO_OMEGetMapOrderDataContext(OMEConnectionStr);
            s_GetLPNameListDataContext = new dbMan_BO_GetLPNameListDataContext(lnqConnectionString);
            s_ClientLoginAuthDataContext = new dbMan_BO_ClientLoginAuthDataContext(lnqConnectionString);
            s_CommonSettingsNew = new dbMan_BO_GetCommonSettingsNewDataContext(lnqConnectionString);
            s_InsertTGAccountConnectionSettingsDataContext = new dbMan_BO_InsertTGAccountConnectionSettingsDataContext(lnqConnectionString);
            s_GetTGAccountConnectionSettingsDataContext = new dbMan_BO_GetTGAccountConnectionSettingsDataContext(lnqConnectionString);
            s_UpdateTGAccountConnectionSettingsDataContext = new dbMan_BO_UpdateTGAccountConnectionSettingsDataContext(lnqConnectionString);
            s_UpdateCommonSetting = new dbMan_BO_UpdateCommonSettingDataContext(lnqConnectionString);
            s_GetClientAccountTypesDataContext = new dbMan_BO_GetClientAccountTypesDataContext(lnqConnectionString);
            s_GetVirtualDealerInfoDataContext = new dbMan_BO_GetVirtualDealerInfoDataContext(lnqConnectionString);
            s_InsertVirtualDealerInfoDataContext = new dbMan_BO_InsertVirtualDealerInfoDataContext(lnqConnectionString);
            s_UpdateVirtualDealerInfoDataContext = new dbMan_BO_UpdateVirtualDealerInfoDataContext(lnqConnectionString);
            s_DeleteVirtualDealerDataContext = new dbMan_BO_DeleteVirtualDealerDataContext(lnqConnectionString);
            s_GetCollateralTransactionHistoryDataContext = new dbMan_BO_GetCollateralTransactionHistoryDataContext(lnqConnectionString);
            s_GetAccountIDsByAccountTypeIDDataContext = new dbMan_BO_GetAccountIDsByAccountTypeIDDataContext(lnqConnectionString);
            s_ChangePasswordDataContext = new dbMan_BO_ChangePasswordDataContext(lnqConnectionString);
            s_GetInstClosingPriceDataContext = new dbMan_BO_GetInstClosingPriceDataContext(lnqConnectionString);
            s_InsertInstClosingPriceDataContext = new dbMan_BO_InsertInstClosingPriceDataContext(lnqConnectionString);
            s_pdateInstClosingPriceDataContext = new dbMan_BO_UpdateInstClosingPriceDataContext(lnqConnectionString);
            s_GetUnexpiredSymbolsDataContext = new dbMan_BO_GetUnexpiredSymbolsDataContext(lnqConnectionString);
            s_GetHedgeTypesDataContext = new dbMan_BO_GetHedgeTypesDataContext(lnqConnectionString);
            s_ModifyTrade = new dbMan_BO_ModifyTradeDataContext(lnqOMSExchangeConnectionStr);
            s_SettleTrade = new dbMan_BO_SettleTradeDataContext(lnqOMSExchangeConnectionStr);
            s_GetTGListDataContext = new dbMan_BO_GetTGListDataContext(lnqConnectionString);
            s_GetTGSymbolsInfoDataContext = new dbMan_BO_GetTGSymbolsInfoDataContext(lnqConnectionString);            
            s_GetTradeInfo = new dbMan_BO_GetTradeInfoDataContext(lnqOMSExchangeConnectionStr);
            //conn = new SqlConnection(DataServerConnectionStr);
            s_GetBrokersLogDataContext = new dbMan_BO_GetBrokersLogDataContext(lnqConnectionString);
            s_InsertBrokersLogDataContext = new dbMan_BO_InsertBrokersLogDataContext(lnqConnectionString);
            s_GetAccountTransactionDataContext = new dbMan_BO_GetAccountTransactionDataContext(lnqConnectionString);
            s_UpdateAccountTransactionDataContext = new dbMan_BO_UpdateAccountTransactionDataContext(lnqConnectionString);
            s_AddSymbolQuotesSession = new dbMan_BO_AddSymbolQuotesSessionDataContext(lnqConnectionString);
            s_AddSymbolTradeSession = new dbMan_BO_AddSymbolTradeSessionDataContext(lnqConnectionString);
            s_GetContractSize = new dbMan_BO_GetContractSizeDataContext(lnqConnectionString);
            s_UpdateHistoricalDataDataContext = new dbMan_BO_UpdateHistoricalDataDataContext(lnqConnectionString);
            s_OMSExchange_InsertNewOrderDataContext = new dbMan_BO_OMSExchange_InsertNewOrderDataContext(lnqOMSExchangeConnectionStr);
            s_OME_InsertNewOrderDataContext = new dbMan_BO_OME_InsertNewOrderDataContext(OME_OrderConnectionStr);

            Init(lnqConnectionString);
        }

        public clsNewOrder BO_OMSExchange_InsertNewOrder(clsNewOrder objclsNewOrder)
        {
            int spResult = 0;
            lock (s_OMSExchange_InsertNewOrderDataContext)
            {
                long? OrderId = 0;
                try
                {
                    spResult = s_OMSExchange_InsertNewOrderDataContext.BO_OMSExchange_InsertNewOrder(objclsNewOrder.AccountID, objclsNewOrder.PositionSize,
                   objclsNewOrder.Price, objclsNewOrder.OrderType, objclsNewOrder.OrderStatus, objclsNewOrder.Side, objclsNewOrder.Symbol,
                   objclsNewOrder.TIF, objclsNewOrder.IPAddress, objclsNewOrder.ExpireDate, ref OrderId);
                    if (OrderId > 0)
                    {
                        objclsNewOrder.OrderID = (long)OrderId;
                    }
                    lock (s_OME_InsertNewOrderDataContext)
                    {
                        spResult = s_OME_InsertNewOrderDataContext.BO_OME_InsertNewOrder(objclsNewOrder.OrderID.ToString(), objclsNewOrder.AccountID,
                            objclsNewOrder.PositionSize, objclsNewOrder.Price, objclsNewOrder.OrderType, objclsNewOrder.OrderStatus, objclsNewOrder.Side,
                            objclsNewOrder.Symbol, objclsNewOrder.TIF, objclsNewOrder.IPAddress, objclsNewOrder.ExpireDate);
                    }
                }
                catch (Exception)
                {

                }
               
            }
            return objclsNewOrder;
        }
        public int HandleBO_ModifyTrade(clsModifyTrades obj)
        {
            lock (s_ModifyTrade)
            {
                ISingleResult<BO_ModifyTradeResult> ret = s_ModifyTrade.BO_ModifyTrade(obj.OrderID, obj.AccountID, obj.LastPrice);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_ModifyTrade";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }
        public int HandleBO_SettleTrade(clsSettleTrade obj)
        {
            lock (s_SettleTrade)
            {
                ISingleResult<BO_SettleOrdersResult> ret = s_SettleTrade.BO_SettleOrders(obj.SettledOrderID, obj.AccountID, obj.PositionSize, obj.Price, obj.OrderType, obj.OrderStatusID, obj.Side, obj.Symbol, obj.TIF, obj.IPAddress, obj.UsedMargin, obj.CloseQty, obj.SettledQty);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_SettleOrders";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }

        public List<BO_FeesMasterSelectResult> HandleDBBO_SelectFeesMaster()
        {
            lock (s_FeesMasterSelect)
            {
                ISingleResult<BO_FeesMasterSelectResult> ret = s_FeesMasterSelect.BO_FeesMasterSelect();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_FeesMasterSelectResult> SelectFees = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectFees = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_FeesMaster";
                    clsLog.LogSqlErr(str);
                }
                return SelectFees;
            }

        }
        public List<BO_GetCommonSettingNewResult> HandleDBBO_SelectCommonSettingsNew()
        {
            lock (s_CommonSettingsNew)
            {
                ISingleResult<BO_GetCommonSettingNewResult> ret = s_CommonSettingsNew.BO_GetCommonSettingNew();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetCommonSettingNewResult> SelectCommonSetting = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectCommonSetting = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetCommonSettingNewResult";
                    clsLog.LogSqlErr(str);
                }
                return SelectCommonSetting;
            }

        }
        public List<BO_TaxMasterSelectResult> HandleBO_SelectTaxMaster()
        {
            lock (s_TaxMasterSelect)
            {
                ISingleResult<BO_TaxMasterSelectResult> ret = s_TaxMasterSelect.BO_TaxMasterSelect();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_TaxMasterSelectResult> SelectTax = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectTax = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_TaxMaster";
                    clsLog.LogSqlErr(str);
                }
                return SelectTax;
            }

        }

        public List<OMS_GetOrderInfoResult> HandleBO_GetOrderInfo(DateTime startDate, DateTime endDate)
        {
            lock (s_GetOrderInfo)
            {


                ISingleResult<OMS_GetOrderInfoResult> ret = s_GetOrderInfo.OMS_GetOrderInfo(startDate, endDate);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<OMS_GetOrderInfoResult> SelectOrder = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectOrder = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetOrderInfo";
                    clsLog.LogSqlErr(str);
                }
                return SelectOrder;


            }

        }

        public List<OMS_GetTradesInfoResult> HandleBO_GetTradeInfo(DateTime startDate, DateTime endDate)
        {
            lock (s_GetTradeInfo)
            {
                ISingleResult<OMS_GetTradesInfoResult> ret = s_GetTradeInfo.OMS_GetTradesInfo(startDate, endDate);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<OMS_GetTradesInfoResult> SelectOrder = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectOrder = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetTradeInfo";
                    clsLog.LogSqlErr(str);
                }
                return SelectOrder;
            }

        }

        public int HandleBO_TaxMasterDelete(int id)
        {
            lock (s_TaxMasterDelete)
            {
                int sp_retval = s_TaxMasterDelete.BO_TaxMasterDelete(id);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteTaxMaster";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }

        }

        public int HandleBO_InsertTaxMaster(clsTaxMaster ObjTaxMaster)
        {
            lock (s_TaxMasterInsert)
            {
                int sp_retval = s_TaxMasterInsert.BO_TaxMasterInsert(ObjTaxMaster.TaxName, ObjTaxMaster.TaxPercent, ObjTaxMaster.Amount,
                    ObjTaxMaster.Description);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertTaxMaster";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }

        }

        public int HandleBO_TaxMasterUpdate(clsTaxMaster obj)
        {
            lock (s_TaxMasterupdate)
            {
                int sp_retval = s_TaxMasterupdate.BO_TaxMasterUpdate(obj.TaxID, obj.TaxName, obj.TaxPercent, obj.Amount, obj.Description);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_FeesMasterUpdate";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }
        }

        public int HandleBO_FeesMasterUpdate(clsFeeMaster Obj)
        {
            lock (s_FeesMasterUpdate)
            {
                int sp_retval = s_FeesMasterUpdate.BO_FeeMasterUpdate(Obj.FeeId, Obj.FeeName, Obj.MinimumFeeValue, Obj.MaximumFeevalue,
                    Obj.Interval, Obj.IsTaxable, Obj.Description, Obj.FeesMode, Obj.LevyOn, Obj.Days);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_FeesMasterUpdate";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }
        }
        public int HandleBO_CommonSettingUpdate(clsCommonSettings obj)
        {
            lock (s_UpdateCommonSetting)
            {
                int sp_retval = s_UpdateCommonSetting.BO_UpdateCommonSettings(obj.ID, obj.Value);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateCommonSetting";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }
        }
        public int HandleBO_DeleteFeeMasterDelete(int id)
        {
            lock (s_FeesMasterDelete)
            {
                int sp_retval = s_FeesMasterDelete.BO_FeesMasterDelete(id);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteFeeMaster";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }


        }

        public int HandleBO_FeesMasterInsert(clsFeeMaster Obj)
        {
            lock (s_FeeMasterInsert)
            {
                int spRetVal = s_FeeMasterInsert.BO_FeesMasterInsert(Obj.FeeName, Obj.MinimumFeeValue, Obj.MaximumFeevalue,
                    Obj.Interval, Obj.IsTaxable, Obj.Description, Obj.FeesMode, Obj.LevyOn, Obj.Days);
                if (spRetVal == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_FeesMasterInsert";
                    clsLog.LogSqlErr(str);
                }
                return spRetVal;
            }

        }

        public int HandleOMS_OrderDelete(int id)
        {
            lock (s_OrderDelete)
            {
                int sp_retval = s_OrderDelete.OMS_OrderDelete(id);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- OMS_OrderDelete";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }

        }

        public int HandleOMS_OrderUpdate(Orders obj)
        {
            lock (s_OrderUpdate)
            {
                int sp_retval = s_OrderUpdate.OMS_OrdersUpdate(obj._OrderID, obj._AccountID, obj._Time, obj._Type, obj._Quantity, Convert.ToInt32(obj._SymbolID), obj._OrderType, clsUtility.GetInt(obj._OrderPrice), clsUtility.GetInt(obj._TriggerPrice), obj._Comment, obj._Status, obj._Validity);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_FeesMasterUpdate";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }
        }

        public int HandleBO_AddNewSymbol(clsContractSpecification ObjSymbol, string sessionString)
        {
            lock (s_AddNewSymbol)
            {
                int sp_retval = 0;

                sp_retval = s_AddNewSymbol.BO_AddNewSymbol(ObjSymbol.SymbolName, ObjSymbol.Description, ObjSymbol.Source, ObjSymbol.Digits,
                                                               clsUtility.GetInt(ObjSymbol.TradingCurrency), clsUtility.GetInt(ObjSymbol.SettlingCurrency), clsUtility.GetInt(ObjSymbol.MarginCurrency),
                                                               clsUtility.GetInt(ObjSymbol.Spread),
                                                               ObjSymbol.MaximumLots, clsUtility.GetInt(ObjSymbol.Maximum_Order_Value),
                                                               clsUtility.GetDecimal(ObjSymbol.BuySideTurnover), clsUtility.GetDecimal(ObjSymbol.SellSideTurnover), clsUtility.GetInt(ObjSymbol.MaximumAllowablePosition),
                                                               ObjSymbol.Hedged,
                                                               /* ObjSymbol.FreezeLevel,*/
                                                               ObjSymbol.LimitandStopLevel,
                                                               /*ObjSymbol.SpreadBalance,*/
                                                               clsUtility.GetInt(ObjSymbol.TickSize), clsUtility.GetInt(ObjSymbol.TickPrice),
                                                               ObjSymbol.ContractSize, clsUtility.GetInt(ObjSymbol.QuotationBaseValue), ObjSymbol.Maintenance,
                                                               clsUtility.GetInt(ObjSymbol.DeliveryType), clsUtility.GetInt(ObjSymbol.DeliveryUnit), ObjSymbol.DeliveryQuantity,
                                                              ObjSymbol.MarketLot, Convert.ToDateTime(ObjSymbol.ExpiryDate), Convert.ToDateTime(ObjSymbol.StartDate), Convert.ToDateTime(ObjSymbol.EndDate),
                                                               Convert.ToDateTime(ObjSymbol.TenderStartDate), Convert.ToDateTime(ObjSymbol.TenderEndDate), Convert.ToDateTime(ObjSymbol.DeliveryStartDate),
                                                               Convert.ToDateTime(ObjSymbol.DeliveryEndDate), ObjSymbol.DPRInitialPercentage,
                                                               ObjSymbol.DPRInterval, ObjSymbol.InitialBuyMargin, ObjSymbol.InitialSellMargin,
                                                               ObjSymbol.MaintenanceBuyMargin, ObjSymbol.MaintenanceSellMargin, ObjSymbol.ULAssest,
                                                                ObjSymbol.DPR_Range_Higher, clsUtility.GetInt(ObjSymbol.FK_SecurityTypeID), clsUtility.GetInt(ObjSymbol.MarketLostUnit), clsUtility.GetInt(ObjSymbol.MaximumLostUnit), clsUtility.GetInt(ObjSymbol.QuotationBaseValueUnit), ObjSymbol.QuoteOffTime);

                string x = ObjSymbol.ToString();
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_AddNewSymbol";
                    clsLog.LogSqlErr(str);
                }
                #region " Namo "
                else
                {
                    foreach (var item in ObjSymbol.lstSession)
                    {
                        string[] quoteSessions = item.QuoteSession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int spret = SUCCESS_ID;
                        foreach (string session in quoteSessions)
                        {
                            if (session.Trim() != string.Empty)
                            {
                                spret = s_AddSymbolQuotesSession.BO_AddSymbolQuotesSession(sp_retval, (int)item.Day,
                                session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                                item.IsUseTimelimits, item.StartDate, item.EndDate, session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                            }
                        }

                        string[] tradeSessions = item.TradeSession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string session in tradeSessions)
                        {
                            if (session.Trim() != string.Empty)
                            {
                                string[] _sessionsEODMM = session.Split('_');
                                spret = s_AddSymbolTradeSession.BO_AddSymbolTradeSession(sp_retval, (int)item.Day,
                               _sessionsEODMM[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                               _sessionsEODMM[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1],
                               Convert.ToBoolean(_sessionsEODMM[1]),
                               Convert.ToBoolean(_sessionsEODMM[2])
                               );
                            }
                        }
                        //int spret = s_AddSymbolSession.BO_AddSymbolSession(sp_retval, item.TradeSession, (int)item.Day, item.QuoteSession,
                        //    item.IsUseTimelimits, item.StartDate, item.EndDate);
                        if (spret == FAILURE_ID)
                        {
                            string str = " Exception occured:- BO_AddSymbolSession";
                            clsLog.LogSqlErr(str);
                        }
                        int spInstrumentSwap = s_dbMan_BO_UpdateInstrumentSwap.BO_UpdateInstrumentSwaps(sp_retval, ObjSymbol.InstrumentSwaps.LongPosition,
                      ObjSymbol.InstrumentSwaps.ShortPosition, ObjSymbol.InstrumentSwaps.IsEnable);
                    }
                }
                //else
                //{

                //    foreach (var item in ObjSymbol.lstSession)
                //    {
                //        string[] quoteSessions = item.QuoteSession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //        int spret = SUCCESS_ID;
                //        foreach (string session in quoteSessions)
                //        {
                //            if (session.Trim() != string.Empty)
                //            {
                //                spret = s_AddSymbolQuotesSession.BO_AddSymbolQuotesSession(sp_retval, (int)item.Day,
                //                session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                //                item.IsUseTimelimits, item.StartDate, item.EndDate, session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                //            }
                //        }

                //        string[] tradeSessions = item.QuoteSession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //        foreach (string session in tradeSessions)
                //        {
                //            if (session.Trim() != string.Empty)
                //            {
                //                spret = s_AddSymbolTradeSession.BO_AddSymbolTradeSession(sp_retval, (int)item.Day,
                //               session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                //               session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                //            }
                //        }
                //        if (spret == FAILURE_ID)
                //        {
                //            string str = " Exception occured:- BO_AddSymbolSession";
                //            clsLog.LogSqlErr(str);
                //        }
                //    }

                //    int spInstrumentSwap = s_dbMan_BO_InsertInstrumentSwaps.BO_InsertInstrumentSwaps(sp_retval, ObjSymbol.InstrumentSwaps.LongPosition,
                //        ObjSymbol.InstrumentSwaps.ShortPosition, ObjSymbol.InstrumentSwaps.IsEnable);
                //}
                #endregion 
                return sp_retval;
            }


        }

        public int HandleBO_DeleteHoliday(int id)
        {
            lock (s_BO_HolidayDelete)
            {
                int sp_retval = s_BO_HolidayDelete.BO_HolidayDelete(id);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteHoliday";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }



        }



        public List<BO_GetSecurityTypeListResult> HandleBO_GetSecurityType()
        {
            lock (s_GetSecurityTypeListDataContext)
            {
                ISingleResult<BO_GetSecurityTypeListResult> ret = s_GetSecurityTypeListDataContext.BO_GetSecurityTypeList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetSecurityTypeListResult> GetSecurityType = null;
                if (sp_retval == SUCCESS_ID)
                {
                    GetSecurityType = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_GetSecurityType";
                    clsLog.LogSqlErr(str);
                }
                return GetSecurityType;
            }
        }


        public int HandleDBBO_InsertIntoAccountGroup(Group GRP)
        {
            //Commented by vijay(Change to updated code to incorporate the UI changes)

            //lock (S_InsertIntoAccountGroup)
            //{
            //    int sp_retval = S_InsertIntoAccountGroup.DBBO_InsertIntoAccountGroup(GRP._AccountGroupName, GRP._Owner, GRP._DepositeCurrency, GRP._Deposite, GRP._Leverage, GRP._AnnualInterestRate, GRP._SecurityIDAccount, GRP._EnableAccount, null, null, GRP._InActivityPeriod, GRP._MaximumBalance, GRP._ArchiveDeletedPendingOrders, GRP._MarginCallLevel, GRP._StopOutLevel, GRP._VirtualCredit, GRP._TimeOut, GRP._News, GRP._MaximumSymbols, GRP._MaximumOrders, GRP._GroupPermission, GRP._SMTPServer, GRP._SMTPLogin, GRP._TemplatesPath, GRP._SMTPPassword, GRP._SupportEmail, GRP._IsCopyReport, GRP._Signature);
            //    if (sp_retval == -999)
            //    {
            //        string str = " Exception occured:- DBBO_InsertIntoAccountGroup";
            //        clsLog.LogSqlErr(str);
            //    }
            //    return sp_retval;
            //}
            return 0;  //written by only for temporary
        }


        public List<BO_GetClientBankInformationResult> HandleBO_GetClientsBankInfo(int? clientID)
        {
            lock (s_GetClientsBankInfo)
            {
                ISingleResult<BO_GetClientBankInformationResult> ret = s_GetClientsBankInfo.BO_GetClientBankInformation(clientID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetClientBankInformationResult> ClientBankInformation = null;
                if (sp_retval == SUCCESS_ID)
                {
                    ClientBankInformation = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_AccountOverview";
                    clsLog.LogSqlErr(str);
                }
                return ClientBankInformation;
            }
        }
        public List<BO_GetParticipantAccountInfoResult> HandleBO_GetParticipantAccountInfo()
        {
            lock (s_GetParticipantAccountInfo)
            {
                ISingleResult<BO_GetParticipantAccountInfoResult> ret = s_GetParticipantAccountInfo.BO_GetParticipantAccountInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetParticipantAccountInfoResult> toatlClient = null;
                if (sp_retval == SUCCESS_ID)
                {
                    toatlClient = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_AccountOverview";
                    clsLog.LogSqlErr(str);
                }
                return toatlClient;
            }
        }

        public List<BO_GetClientAccountInformationResult> HandleBO_GetClientAccountInformation(int? clientID)
        {
            lock (s_GetClientAccountInformation)
            {
                ISingleResult<BO_GetClientAccountInformationResult> ret = s_GetClientAccountInformation.BO_GetClientAccountInformation(clientID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetClientAccountInformationResult> ClientAccountInfo = null;
                if (sp_retval == SUCCESS_ID)
                {
                    ClientAccountInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_AccountOverview";
                    clsLog.LogSqlErr(str);
                }
                return ClientAccountInfo;
            }
        }

        public List<BO_GetClientBankInformationResult> HandleBO_GetClientBankInformation(int? clientID)
        {
            lock (s_GetClientsBankInfo)
            {
                ISingleResult<BO_GetClientBankInformationResult> ret = s_GetClientsBankInfo.BO_GetClientBankInformation(clientID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetClientBankInformationResult> ClientBankInformation = null;
                if (sp_retval == SUCCESS_ID)
                {
                    ClientBankInformation = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_AccountOverview";
                    clsLog.LogSqlErr(str);
                }
                return ClientBankInformation;
            }
        }

        public List<BO_GetCountryMasterInfoResult> HandleBO_GetCountryMasterInfo()
        {
            lock (s_GetCountryMasterInfo)
            {
                ISingleResult<BO_GetCountryMasterInfoResult> ret = s_GetCountryMasterInfo.BO_GetCountryMasterInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetCountryMasterInfoResult> CountryMasterInfo = null;
                if (sp_retval == SUCCESS_ID)
                {
                    CountryMasterInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetCountryMasterInfo";
                    clsLog.LogSqlErr(str);
                }
                return CountryMasterInfo;


            }
        }

        public List<BO_GetTradingGateWaysResult> HandleBO_GetTradingGateWays()
        {
            lock (s_GetTradingGateWayInfo)
            {
                ISingleResult<BO_GetTradingGateWaysResult> ret = s_GetTradingGateWayInfo.BO_GetTradingGateWays();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetTradingGateWaysResult> TradingGateWays = null;
                if (sp_retval == SUCCESS_ID)
                {
                    TradingGateWays = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:-BO_GetTradingGateWaysResult";
                    clsLog.LogSqlErr(str);
                }
                return TradingGateWays;
            }
        }

        public List<BO_GetTradingGateWaySymbolMapInfoResult> HandleBO_GetTradingGateWaySymbolMapInfo(int tradingGateWayID)
        {
            lock (s_GetTradingGatewayMaps)
            {
                ISingleResult<BO_GetTradingGateWaySymbolMapInfoResult> ret = s_GetTradingGatewayMaps.BO_GetTradingGateWaySymbolMapInfo(tradingGateWayID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetTradingGateWaySymbolMapInfoResult> TradingGateWaySymbolMapInfo = null;
                if (sp_retval == SUCCESS_ID)
                {
                    TradingGateWaySymbolMapInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetTradingGateWaySymbolMapInfo";
                    clsLog.LogSqlErr(str);
                }
                return TradingGateWaySymbolMapInfo;
            }
        }

        public clsTradingGateway HandleInsertTradingGateWayInfo(clsTradingGateway obj)
        {
            string productName = string.Empty;
            lock (s_InsertTradingGateWayInfo)
            {
                int spRetval = s_InsertTradingGateWayInfo.BO_InsertTradingGateWayInfo(obj.Name, obj.Description, obj.ServerIP, clsUtility.GetInt(obj.Port)
                    , obj.DataType, obj.Login, obj.Password, obj.IdleTimeOut, obj.ReconnectAfter, obj.SleepFor
                    , obj.Attempts, obj.IsEnable, obj.EnableRMS, obj.OrderPort, obj.OrderIP);
                if (spRetval != FAILURE_ID)
                {
                    foreach (var item in obj.LstSymbol)
                    {
                        int sretVal = s_InsertTradingGateWayMapsInfo.BO_InsertTradingGateWayMapsInfo(spRetval
                            , item, obj.LstSymbolAlias[obj.LstSymbol.IndexOf(item)], obj.LstSymbolConversionFormula[obj.LstSymbol.IndexOf(item)],
                            ref productName, obj.LstProductAlias[obj.LstSymbol.IndexOf(item)]);

                        obj.LstProductName[obj.LstSymbol.IndexOf(item)] = productName;
                        if (sretVal == FAILURE_ID)
                        {
                            string str = " Exception occured:- BO_InsertTradingGateWayMapsInfo";
                            clsLog.LogSqlErr(str);
                        }
                    }

                    //foreach (AccountConnectionSettings  item in obj._ACSettings)
                    //{
                    //    int sretVal = s_InsertTGAccountConnectionSettingsDataContext.BO_InsertTGAccountConnectionSettings(spRetval, item.AccountId, item.Password,
                    //        item.IsEnable);

                    //    if (sretVal == FAILURE_ID)
                    //    {
                    //        clsLog.LogSqlErr(" Exception occured:- BO_InsertTGAccountConnectionSettings");
                    //    }
                    //}
                }
                else if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertTradingGateWayInfo";
                    clsLog.LogSqlErr(str);
                }
                obj.PKTradingGateWaysID = spRetval;
                return obj;
            }

        }

        public int HandleInsertTGAccountConnectionSettings(BOEngineServiceClasses.clsTGAccountConnectionSettings obj)
        {
            lock (s_InsertTGAccountConnectionSettingsDataContext)
            {
                int spRetval = s_InsertTGAccountConnectionSettingsDataContext.BO_InsertTGAccountConnectionSettings(obj.TGID, obj.AccountId, obj.Password,
                            obj.IsEnable);
                if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertTGAccountConnectionSettings";
                    clsLog.LogSqlErr(str);
                }
                return spRetval;
            }

        }

        public List<BO_GetTGAccountConnectionSettingsResult> HandleGetTGAccountConnectionSettings()
        {
            lock (s_GetTGAccountConnectionSettingsDataContext)
            {
                ISingleResult<BO_GetTGAccountConnectionSettingsResult> result = s_GetTGAccountConnectionSettingsDataContext.BO_GetTGAccountConnectionSettings();
                List<BO_GetTGAccountConnectionSettingsResult> lstResult = null;
                if ((int)result.ReturnValue == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertTGAccountConnectionSettings";
                    clsLog.LogSqlErr(str);
                }
                else
                {
                    lstResult = result.ToList();
                }
                return lstResult;
            }
        }

        public int HandleUpdateTGAccountConnectionSettings(BOEngineServiceClasses.clsTGAccountConnectionSettings obj)
        {
            lock (s_UpdateTGAccountConnectionSettingsDataContext)
            {
                int spRetval = s_UpdateTGAccountConnectionSettingsDataContext.BO_UpdateTGAccountConnectionSettings(obj.TGID, obj.AccountId, obj.Password,
                            obj.IsEnable);
                if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateTGAccountConnectionSettings";
                    clsLog.LogSqlErr(str);
                }
                return spRetval;
            }
        }

        public clsTradingGateway HandleUpdateTradingGateWayInfo(clsTradingGateway obj)
        {
            string productName = string.Empty;
            lock (s_UpdateTradingGateWayInfo)
            {
                int spRetval = s_UpdateTradingGateWayInfo.BO_UpdateTradingGateWayInfo(obj.PKTradingGateWaysID, obj.Name, obj.Description, obj.ServerIP, clsUtility.GetInt(obj.Port)
                    , obj.DataType, obj.Login, obj.Password, obj.IdleTimeOut, obj.ReconnectAfter, obj.SleepFor
                    , obj.Attempts, obj.IsEnable, obj.EnableRMS, obj.OrderPort, obj.OrderIP);


                if (spRetval != FAILURE_ID)
                {
                    if (obj.LstSymbolAlias.Count != 0)
                    {
                        s_DeleteSymbolAliasDataContext.BO_DeleteSymbolAlias(obj.PKTradingGateWaysID);
                        foreach (var item in obj.LstSymbol)
                        {
                            int sretVal = s_InsertTradingGateWayMapsInfo.BO_InsertTradingGateWayMapsInfo(obj.PKTradingGateWaysID
                                           , item, obj.LstSymbolAlias[obj.LstSymbol.IndexOf(item)], obj.LstSymbolConversionFormula[obj.LstSymbol.IndexOf(item)],
                                          ref productName, obj.LstProductAlias[obj.LstSymbol.IndexOf(item)]);

                            obj.LstProductName[obj.LstSymbol.IndexOf(item)] = productName;
                            if (sretVal == FAILURE_ID)
                            {
                                string str = " Exception occured:- BO_UpdateTradingGateWaySymbolMapsInfo";
                                clsLog.LogSqlErr(str);
                            }

                        }
                    }
                }
                else if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateTradingGateWayInfo";
                    clsLog.LogSqlErr(str);
                }
                obj.ServerResponseID = spRetval;
                //return spRetval;
                return obj;
            }

        }


        public List<BO_GetTimeSettingsResult> HandleGetTimeSettings()
        {
            lock (s_GetTimeSettings)
            {
                ISingleResult<BO_GetTimeSettingsResult> ret = s_GetTimeSettings.BO_GetTimeSettings();
                int spRetVal = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetTimeSettingsResult> GetTimeSettings = null;
                if (spRetVal == SUCCESS_ID)
                {
                    GetTimeSettings = ret.ToList();
                }
                else if (spRetVal == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetTimeSettingsResult";
                    clsLog.LogSqlErr(str);
                }
                return GetTimeSettings;
            }


        }


        public List<BO_GetAllAccountGroupInfoResult> HandleBO_GetAllAccountGroupInfo()
        {
            lock (s_AllAccountGroupInfo)
            {
                ISingleResult<BO_GetAllAccountGroupInfoResult> ret = s_AllAccountGroupInfo.BO_GetAllAccountGroupInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetAllAccountGroupInfoResult> AllAccountGroupInfo = null;
                if (sp_retval == SUCCESS_ID)
                {
                    AllAccountGroupInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllAccountGroupInfoResult";
                    clsLog.LogSqlErr(str);
                }
                return AllAccountGroupInfo;
            }

        }
        public List<clsAccountGroup> GetAllAccountGrouplist()
        {
            List<clsAccountGroup> lstAccountGroup = new List<clsAccountGroup>();
            List<BO_GetAllAccountGroupInfoResult> AllAccountGroupInfo = null;
            lock (s_AllAccountGroupInfo)
            {
                ISingleResult<BO_GetAllAccountGroupInfoResult> ret = s_AllAccountGroupInfo.BO_GetAllAccountGroupInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                if (sp_retval == SUCCESS_ID)
                {
                    AllAccountGroupInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllAccountGroupInfoResult";
                    clsLog.LogSqlErr(str);
                }

            }
            if (AllAccountGroupInfo == null)
            {
                return lstAccountGroup;
            }
            foreach (BO_GetAllAccountGroupInfoResult item in AllAccountGroupInfo)
            {
                try
                {
                    clsAccountGroup objclsAccountGroup = new clsAccountGroup();
                    objclsAccountGroup.AccountGroupID = item.AccountGroupID;
                    objclsAccountGroup.AccountGroupName = item.AccountGroupName;
                    objclsAccountGroup.BrokerAddress = item.BrokerAddress;
                    objclsAccountGroup.BrokerCity = item.BrokerCity;
                    objclsAccountGroup.BrokerEmail = item.BrokerEmail;
                    objclsAccountGroup.BrokerFax = item.BrokerFax;
                    objclsAccountGroup.BrokerPhone1 = item.BrokerFax;
                    objclsAccountGroup.BrokerPhone2 = item.BrokerPhone1;
                    objclsAccountGroup.BrokerState = item.BrokerState;
                    objclsAccountGroup.BrokerTypeID = item.FK_BrokerTypeID.HasValue ? item.FK_BrokerTypeID.Value : 0;
                    objclsAccountGroup.Charges = item.Charges.HasValue ? item.Charges.Value : 0;
                    objclsAccountGroup.IsEnable = item.IsEnable.HasValue ? item.IsEnable.Value : false;
                    objclsAccountGroup.LeverageId = item.FK_LeverageID;
                    objclsAccountGroup.Owner = item.Owner;
                    objclsAccountGroup.ParentBrokerId = clsUtility.GetInt(item.ParentAccountGroupID);
                    objclsAccountGroup.Password = clsUtility.GetStr(item.Password);
                    objclsAccountGroup.ServerResponseID = -50052;

                    lstAccountGroup.Add(objclsAccountGroup);
                }
                catch (Exception ex)
                {

                }

            }
            return lstAccountGroup;
        }
        public List<BO_GetBrokerTypesListResult> HandleBO_GetBrokerTypesList()
        {
            lock (s_GetBrokerTypesList)
            {
                ISingleResult<BO_GetBrokerTypesListResult> ret = s_GetBrokerTypesList.BO_GetBrokerTypesList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetBrokerTypesListResult> BrokerTypesList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    BrokerTypesList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetBrokerTypesListResult";
                    clsLog.LogSqlErr(str);
                }
                return BrokerTypesList;
            }

        }
        public List<BO_GetLeverageListResult> HandleBO_GetLeverageList()
        {
            lock (s_GetLeverageList)
            {
                ISingleResult<BO_GetLeverageListResult> ret = s_GetLeverageList.BO_GetLeverageList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetLeverageListResult> LeverageList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    LeverageList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetLeverageListResult";
                    clsLog.LogSqlErr(str);
                }
                return LeverageList;
            }

        }
        public List<BO_GetCurrencyListResult> HandleBO_GetCurrencyList()
        {
            lock (s_GetCurrencyList)
            {
                ISingleResult<BO_GetCurrencyListResult> ret = s_GetCurrencyList.BO_GetCurrencyList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetCurrencyListResult> CurrencyList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    CurrencyList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetCurrencyListResult";
                    clsLog.LogSqlErr(str);
                }
                return CurrencyList;
            }

        }

        public List<BO_GetParticipantTypeListResult> HandleBO_GetParticipantTypeList()
        {
            lock (s_GetParticipantTypeList)
            {
                ISingleResult<BO_GetParticipantTypeListResult> ret = s_GetParticipantTypeList.BO_GetParticipantTypeList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetParticipantTypeListResult> ParticipantTypeList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    ParticipantTypeList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetParticipantTypeList";
                    clsLog.LogSqlErr(str);
                }
                return ParticipantTypeList;
            }
        }


        //by vijay for Brokers
        public List<BO_GetBrokersInfoResult> HandleBO_GetBrokersInfo()
        {
            lock (s_GetBrokersInfoDataContext)
            {
                ISingleResult<BO_GetBrokersInfoResult> ret = s_GetBrokersInfoDataContext.BO_GetBrokersInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetBrokersInfoResult> brokersList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    brokersList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_GetgroupSecurityByIdResult";
                    clsLog.LogSqlErr(str);
                }
                return brokersList;
            }
        }
        //by Namo for Brokers s_GetBrokersListDataContext
        public List<BO_GetBrokersListResult> HandleBO_GetBrokersList(int AccountGrpID)
        {
            lock (s_GetBrokersListDataContext)
            {
                ISingleResult<BO_GetBrokersListResult> ret = s_GetBrokersListDataContext.BO_GetBrokersList(AccountGrpID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetBrokersListResult> brokersList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    brokersList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetBrokersListResult";
                    clsLog.LogSqlErr(str);
                }
                return brokersList;
            }
        }
        //by vijay for Brokers
        public List<BO_GetBrokersSymbolMapInfoResult> HandleDBBO_GetBrokersSymbolMapInfo(int brokerID)
        {
            lock (s_GetBrokersSymbolMapInfoDataContext)
            {
                ISingleResult<BO_GetBrokersSymbolMapInfoResult> ret = s_GetBrokersSymbolMapInfoDataContext.BO_GetBrokersSymbolMapInfo(brokerID);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetBrokersSymbolMapInfoResult> brokersSymbolMapInfoList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    brokersSymbolMapInfoList = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- DBBO_GetgroupSecurityByIdResult";
                    clsLog.LogSqlErr(str);
                }
                return brokersSymbolMapInfoList;
            }
        }

        //by vijay for Brokers
        public int HandleInsertIntoBrokers(clsBroker broker)
        {
            lock (s_InsertIntoBrokersDataContext)
            {
                int? returnRoleId = 0;
                string LoginId = broker.LoginID;
                int spRetval = s_InsertIntoBrokersDataContext.BO_InsertInToBrokers(broker.Name, broker.Owner,
                    broker.Leverage, broker.State, broker.IsEnable, broker.BrokerType, broker.Address, broker.City,
                    broker.Phone1, broker.Phone2, broker.Fax, broker.EMail, broker.MarginCallLevel1, broker.MarginCallLevel2,
                    broker.MarginCallLevel3, broker.News, broker.MaximumOrders, broker.Maximumsymbols, broker.BrokerParent, broker.RoleName,
                    broker.Roles, ref LoginId, ref returnRoleId);

                if (spRetval != FAILURE_ID)
                {
                    broker.RoleId = returnRoleId.HasValue ? (int)returnRoleId : 0;
                    broker.LoginID = LoginId;
                    foreach (var item in broker.LstSymbol)
                    {
                        int sretVal = s_InsertBrokersSymbolMapInfoDataContext.BO_InsertBrokersSymbolMapInfo(spRetval
                            , item.SymbolID, broker.BrokerType, item.BidSpread, item.AskSpread, item.Spread, item.IsVariable, item.RelativeBidChange, item.RelativeAskChange);
                        if (sretVal == FAILURE_ID)
                        {
                            string str = " Exception occured:- BO_InsertBrokersSymbolMapInfo";
                            clsLog.LogSqlErr(str);
                        }
                    }
                }
                else if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BrokersInfo";
                    clsLog.LogSqlErr(str);
                }
                return spRetval;
            }
        }

        //by vijay for Brokers
        public int HandleUpdateIntoBrokers(clsBroker broker)
        {
            lock (s_UpdateBrokersInfoDataContext)
            {
                int spRetval = s_UpdateBrokersInfoDataContext.BO_UpdateBrokersInfo(broker.BrokerID, broker.Name, broker.Owner, broker.Leverage, broker.State,
                    broker.IsEnable, broker.BrokerType, broker.Address, broker.City, broker.Phone1, broker.Phone2,
                    broker.Fax, broker.EMail, broker.MarginCallLevel1, broker.MarginCallLevel2, broker.MarginCallLevel3,
                    broker.News, broker.MaximumOrders, broker.Maximumsymbols, broker.BrokerParent, broker.Roles, broker.RoleId, broker.RoleName);
                if (spRetval != FAILURE_ID)
                {
                    s_DeleteBrokersSymbolDataContext.BO_DeleteBrokersSymbol(broker.BrokerID);
                    foreach (var item in broker.LstSymbol)
                    {
                        int sretVal = s_InsertBrokersSymbolMapInfoDataContext.BO_InsertBrokersSymbolMapInfo(broker.BrokerID,
                            item.SymbolID, broker.BrokerType, item.BidSpread, item.AskSpread, item.Spread, item.IsVariable, item.RelativeBidChange, item.RelativeAskChange);

                        if (sretVal == FAILURE_ID)
                        {
                            string str = " Exception occured:- BO_UpdateBrokersSymbolMapInfo";
                            clsLog.LogSqlErr(str);
                        }

                    }
                }
                else if (spRetval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateBrokersInfo";
                    clsLog.LogSqlErr(str);
                }
                ////if (spRetval != FAILURE_ID)
                ////{
                ////    s_DeleteBrokersSymbolDataContext.BO_DeleteBrokersSymbol(broker.BrokerID);
                ////    foreach (var item in broker.LstSymbol)
                ////    {
                ////        int sretVal = s_InsertBrokersSymbolMapInfoDataContext.BO_InsertBrokersSymbolMapInfo(broker.BrokerID,
                ////            item.SymbolID, broker.BrokerType, item.BidSpread, item.AskSpread, item.Spread, item.IsVariable, item.RelativeBidChange,item.RelativeAskChange);

                ////        if (sretVal == FAILURE_ID)
                ////        {
                ////            string str = " Exception occured:- BO_UpdateBrokersSymbolMapInfo";
                ////            clsLog.LogSqlErr(str);
                ////        }
                ////        else if (sretVal != FAILURE_ID)
                ////        {
                ////            List<BO_GetBrokersListResult> spRslt = HandleBO_GetBrokersList(broker.BrokerID);
                ////            //if (broker.IsRelative)
                ////            //{
                ////                foreach (var i in spRslt)
                ////                {
                ////                    foreach (var itm in broker.LstSymbol)
                ////                    {
                ////                        int Val = s_UpdateBrokersRelativeSymbolMapDataContext.BO_UpdateBrokersRelativeSymbolMap(Convert.ToInt32(i), itm.RelativeBidChange,itm.RelativeAskChange,itm.SymbolID);
                ////                    }

                ////                }
                ////            //}
                ////        }
                ////    }
                ////}
                ////else if (spRetval == FAILURE_ID)
                ////{
                ////    string str = " Exception occured:- BO_UpdateBrokersInfo";
                ////    clsLog.LogSqlErr(str);
                ////}
                return spRetval;
            }
        }
        //by Namo for Brokers  dbMan_BO_UpdateBrokersRelativeSymbolMapDataContext
        //public int HandleUpdateBrokersRelativeSymbolMap(int brokerID, int bidPrice, int askPrice, int relativeChange)
        //{
        //    lock (s_UpdateBrokersRelativeSymbolMapDataContext)
        //    {
        //        int spRetval = s_UpdateBrokersRelativeSymbolMapDataContext.BO_UpdateBrokersRelativeSymbolMap(brokerID, bidPrice, askPrice, relativeChange);

        //        if (spRetval == FAILURE_ID)
        //        {
        //            string str = " Exception occured:- HandleUpdateBrokersRelativeSymbolMap";
        //            clsLog.LogSqlErr(str);
        //        }
        //        return spRetval;
        //    }
        //}

        public List<BO_GetAllSymbolsResult> GetAllSymbols()
        {
            lock (s_GetAllSymbolsDataContext)
            {
                ISingleResult<BO_GetAllSymbolsResult> result = s_GetAllSymbolsDataContext.BO_GetAllSymbols();

                int sp_retval = clsUtility.GetInt(result.ReturnValue);
                List<BO_GetAllSymbolsResult> symbolList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    symbolList = result.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllSymbolsResult";
                    clsLog.LogSqlErr(str);
                }
                return symbolList;
            }
        }
        public List<BO_GetAllSymbolsNewResult> GetAllSymbols(int BrokerId)
        {
            lock (s_GetAllSymbolsNewDataContext)
            {
                ISingleResult<BO_GetAllSymbolsNewResult> result = s_GetAllSymbolsNewDataContext.BO_GetAllSymbolsNew(BrokerId);

                int sp_retval = clsUtility.GetInt(result.ReturnValue);
                List<BO_GetAllSymbolsNewResult> symbolList = null;
                if (sp_retval == SUCCESS_ID)
                {
                    symbolList = result.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllSymbolsResult";
                    clsLog.LogSqlErr(str);
                }
                return symbolList;
            }
        }

        public List<BO_GetAllFeeTypeResult> GetAllFeeType()
        {
            lock (s_GetAllFeeTypeDataContext)
            {
                ISingleResult<BO_GetAllFeeTypeResult> result = s_GetAllFeeTypeDataContext.BO_GetAllFeeType();

                int sp_retval = clsUtility.GetInt(result.ReturnValue);
                List<BO_GetAllFeeTypeResult> lstFeeType = null;
                if (sp_retval == SUCCESS_ID)
                {
                    lstFeeType = result.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllFeeTypeResult";
                    clsLog.LogSqlErr(str);
                }
                return lstFeeType;
            }
        }

        public List<BO_GetAllTaxTypeResult> GetAllTaxType()
        {
            lock (s_GetAllTaxTypeDataContext)
            {
                ISingleResult<BO_GetAllTaxTypeResult> result = s_GetAllTaxTypeDataContext.BO_GetAllTaxType();

                int sp_retval = clsUtility.GetInt(result.ReturnValue);
                List<BO_GetAllTaxTypeResult> lstTaxType = null;
                if (sp_retval == SUCCESS_ID)
                {
                    lstTaxType = result.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllTaxTypeResult";
                    clsLog.LogSqlErr(str);
                }
                return lstTaxType;
            }
        }

        public int HandleInsertIntoSymbolCharges(charges charge, int brokersGroupID)
        {
            int returnValue = s_InsertIntoSymbolChargesDataContext.BO_InsertIntoSymbolCharges(brokersGroupID,
                charge.SymbolID, charge.Fee, charge.FeeValue, charge.Tax, Convert.ToDecimal(charge.TaxValue));

            if (returnValue == FAILURE_ID)
            {
                string str = " Exception occured:- BO_InsertIntoSymbolCharges";
                clsLog.LogSqlErr(str);
            }
            return returnValue;
        }

        public List<BO_SelectBrokersChargesInfoResult> HandleDBBO_GetSymbolCharges(int brokerID)
        {
            lock (s_SelectSymbolChargesDataContext)
            {
                ISingleResult<BO_SelectBrokersChargesInfoResult> returnValue = s_SelectSymbolChargesDataContext.BO_SelectBrokersChargesInfo(brokerID);

                int sp_retval = clsUtility.GetInt(returnValue.ReturnValue);
                List<BO_SelectBrokersChargesInfoResult> lstSymbolCharges = null;
                if (sp_retval == SUCCESS_ID)
                {
                    lstSymbolCharges = returnValue.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_SelectBrokersChargesInfo";
                    clsLog.LogSqlErr(str);
                }
                return lstSymbolCharges;
            }
        }

        public int HandleDBBO_DeleteSymbolCharges(int ID)
        {
            lock (s_DeleteSymbolChargesDataContext)
            {
                int sp_retval = s_DeleteSymbolChargesDataContext.BO_DeleteSymbolCharges(ID);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteSymbolCharges";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }
        public void HandleDBBO_UpdateSymbolCharges(charges chge)
        {
            lock (s_UpdateSymbolChargesDataContext)
            {
                int retval = s_UpdateSymbolChargesDataContext.BO_UpdateSymbolCharges(chge.ChargesID,
                    chge.BrokersGroupID, chge.SymbolID, chge.Fee, chge.FeeValue, chge.Tax,
                    clsUtility.GetDecimal(chge.TaxValue));

                if (retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateSymbolCharges";
                    clsLog.LogSqlErr(str);
                }
            }
        }
        public List<BO_GetIpAccessListResult> HandleDBBO_SelectAccessIp()
        {
            lock (s_GetIPAccessListDataContext)
            {
                ISingleResult<BO_GetIpAccessListResult> ret = s_GetIPAccessListDataContext.BO_GetIpAccessList();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetIpAccessListResult> SelectAccessIp = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectAccessIp = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- Bo_GetIpAccessList";
                    clsLog.LogSqlErr(str);
                }
                return SelectAccessIp;
            }
        }
        public int HandleDBBO_InsertIpAccessTab(clsIPAccessList ObjAccessIp)
        {
            lock (s_InsertIPAccessListDataContext)
            {
                int sp_retval = s_InsertIPAccessListDataContext.BO_InsertIPAccessList(ObjAccessIp.Status, ObjAccessIp.FromIP, ObjAccessIp.ToIp, ObjAccessIp.Comment);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertIPAccessList";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }

        }

        public int HandleDBBO_UpdateIpAccessTab(clsIPAccessList ObjAccessIp)
        {
            lock (s_UpdateIPAccessListDataContext)
            {
                int sp_retval = s_UpdateIPAccessListDataContext.BO_UpdateIPAccessList(ObjAccessIp.ID, ObjAccessIp.Status, ObjAccessIp.FromIP, ObjAccessIp.ToIp, ObjAccessIp.Comment);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateIPAccessList";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }

        public int HandleDBBO_DeleteIpAccess(int id)
        {

            lock (s_DeleteIPAccessListDataContext)
            {
                int sp_retval = s_DeleteIPAccessListDataContext.BO_DeleteIPAccessList(id);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteIPAccessList";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }

        }
        public int Bo_UpdateHistoryInfo(clsHistoricalData historyData, string periodicity)
        {
            int spResult = 0;
            //lock (s_UpdateHistoricalDataDataContext)
            //{
            //    int spResult = s_UpdateHistoricalDataDataContext.BO_UpdateHistoricalData(historyData.ID, periodicity, historyData.FeedTime, historyData.Open,
            //        historyData.High, historyData.Low, historyData.Close, historyData.Volume);
            //    if (spResult == FAILURE_ID)
            //    {
            //        return FAILURE_ID;
            //    }

            //    return spResult;
            //}
            return spResult;
        }
        public List<BO_GetDeliveryUnitResult> GetDeliverUnitNames()
        {
            lock (s_GetDeliveryUnitDataContext)
            {
                ISingleResult<BO_GetDeliveryUnitResult> result = s_GetDeliveryUnitDataContext.BO_GetDeliveryUnit();
                List<BO_GetDeliveryUnitResult> lstDileveryUnits = null;
                if (clsUtility.GetInt(result.ReturnValue) == SUCCESS_ID)
                {
                    lstDileveryUnits = result.ToList();
                }
                else if (clsUtility.GetInt(result.ReturnValue) == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetDeliveryUnit";
                    clsLog.LogSqlErr(str);
                }

                return lstDileveryUnits;
            }
        }

        public List<BO_GetLPNameListResult> GetLPNameList()
        {
            lock (s_GetLPNameListDataContext)
            {
                ISingleResult<BO_GetLPNameListResult> result = s_GetLPNameListDataContext.BO_GetLPNameList();
                List<BO_GetLPNameListResult> lstLPNames = null;
                if (clsUtility.GetInt(result.ReturnValue) == SUCCESS_ID)
                {
                    lstLPNames = result.ToList();
                }
                else if (clsUtility.GetInt(result.ReturnValue) == FAILURE_ID)
                {
                    string str = " Exception occured:- GetLPNameList";
                    clsLog.LogSqlErr(str);
                }

                return lstLPNames;
            }
        }

        public List<BO_GetOrderTypesResult> GetOrderTypes()
        {
            lock (s_GetOrderTypesDataContext)
            {
                ISingleResult<BO_GetOrderTypesResult> result = s_GetOrderTypesDataContext.BO_GetOrderTypes();
                List<BO_GetOrderTypesResult> lstOrderTypes = null;
                if (clsUtility.GetInt(result.ReturnValue) == SUCCESS_ID)
                {
                    lstOrderTypes = result.ToList();
                }
                else if (clsUtility.GetInt(result.ReturnValue) == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetOrderTypes";
                    clsLog.LogSqlErr(str);
                }
                return lstOrderTypes;
            }


        }

        public List<BO_GetProductNamesResult> GetProductNames()
        {
            lock (s_GetDeliveryUnitDataContext)
            {
                ISingleResult<BO_GetProductNamesResult> result = s_GetProductNamesDataContext.BO_GetProductNames();
                List<BO_GetProductNamesResult> lstProductNames = null;
                if (clsUtility.GetInt(result.ReturnValue) == SUCCESS_ID)
                {
                    lstProductNames = result.ToList();
                }
                else if (clsUtility.GetInt(result.ReturnValue) == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetProductNames";
                    clsLog.LogSqlErr(str);
                }
                return lstProductNames;
            }


        }

        public List<BO_GetBrokersCollateralInfoResult> HandleBO_GetBrokersCollateralInfo()
        {
            lock (s_GetBrokersCollateralInfo)
            {
                ISingleResult<BO_GetBrokersCollateralInfoResult> ret = s_GetBrokersCollateralInfo.BO_GetBrokersCollateralInfo();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetBrokersCollateralInfoResult> BrokersCollateralInfo = null;
                if (sp_retval == SUCCESS_ID)
                {
                    BrokersCollateralInfo = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetBrokersCollateralInfo";
                    clsLog.LogSqlErr(str);
                }
                return BrokersCollateralInfo;
            }

        }

        public List<BO_GetAllCollateralTypesResult> HandleBO_GetAllCollateralTypes()
        {
            lock (s_GetAllCollateralTypes)
            {
                ISingleResult<BO_GetAllCollateralTypesResult> ret = s_GetAllCollateralTypes.BO_GetAllCollateralTypes();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetAllCollateralTypesResult> CollateralTypes = null;
                if (sp_retval == SUCCESS_ID)
                {
                    CollateralTypes = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllCollateralTypesResult";
                    clsLog.LogSqlErr(str);
                }
                return CollateralTypes;
            }

        }

        public List<BO_GetLastCollateralTransInfoForAccGrpResult> HandleBO_GetLastCollateralTransInfoForAccGrp(int AccountGroupId)
        {
            lock (s_GetLastCollateralTransInfoForAccGrp)
            {
                ISingleResult<BO_GetLastCollateralTransInfoForAccGrpResult> ret = s_GetLastCollateralTransInfoForAccGrp.BO_GetLastCollateralTransInfoForAccGrp(AccountGroupId);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetLastCollateralTransInfoForAccGrpResult> LastCollateralTransInfoForAccGrp = null;
                if (sp_retval == SUCCESS_ID)
                {
                    LastCollateralTransInfoForAccGrp = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetLastCollateralTransInfoForAccGrp";
                    clsLog.LogSqlErr(str);
                }
                return LastCollateralTransInfoForAccGrp;
            }

        }


        public int HandleInsertIntoBrokersCollateralTransaction(clsCollateralTransInfo brokerCollateralTrans)
        {
            int returnValue = s_InsertCollateralTransaction.BO_InsertCollateralTransaction((int?)brokerCollateralTrans.AccountGroupId,
                (int?)brokerCollateralTrans.CollateralTypeId, (decimal?)brokerCollateralTrans.Amount,
                (decimal?)brokerCollateralTrans.TotalAmount, brokerCollateralTrans.TransactionType);
            string x = brokerCollateralTrans.ToString();
            if (returnValue == FAILURE_ID)
            {
                string str = " Exception occured:- BO_InsertIntoSymbolCharges";
                clsLog.LogSqlErr(str);
            }
            return returnValue;
        }

        public List<BO_GetAllModulesResult> HandleBO_GetAllModules()
        {
            lock (s_GetAllModules)
            {
                ISingleResult<BO_GetAllModulesResult> ret = s_GetAllModules.BO_GetAllModules();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetAllModulesResult> AllModules = null;
                if (sp_retval == SUCCESS_ID)
                {
                    AllModules = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetAllModules";
                    clsLog.LogSqlErr(str);
                }
                return AllModules;
            }

        }
        public int HandleBO_AuthenticateLogin(string loginId, string pwd, ref int? brokerid, ref string role, ref string brokerName, ref int? brokerNameId,
            ref string brokerCompany, ref bool? IsEnable)
        {
            lock (s_AuthenticateLogin)
            {
                int sp_retval = s_AuthenticateLogin.BO_AuthenticateLogin(loginId, pwd, ref brokerid, ref role, ref brokerName, ref brokerNameId, ref brokerCompany, ref IsEnable);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_AuthenticateLogin";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }

        public List<BO_GetPredefinedRolesResult> HandleBO_GetPredefinedRoles()
        {
            lock (s_GetPredefinedRolesDataContext)
            {
                ISingleResult<BO_GetPredefinedRolesResult> result = s_GetPredefinedRolesDataContext.BO_GetPredefinedRoles();
                List<BO_GetPredefinedRolesResult> lstPredefinedRoles = null;
                if ((int)result.ReturnValue == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_GetPredefinedRoles";
                    clsLog.LogSqlErr(str);
                }
                else
                {
                    lstPredefinedRoles = result.ToList();
                }

                return lstPredefinedRoles;
            }
        }

        public List<OME_GetMapOrderResult> GetMapOrderInfo()
        {
            ISingleResult<OME_GetMapOrderResult> result = s_OMEGetMapOrderDataContext.OME_GetMapOrder();

            List<OME_GetMapOrderResult> lstMapInfo = null;

            if ((int)result.ReturnValue == FAILURE_ID)
            {
                string str = " Exception occured:- BO_GetPredefinedRoles";
                clsLog.LogSqlErr(str);
            }
            else
            {
                lstMapInfo = result.ToList();
            }

            return lstMapInfo;
        }

        public bool CLientLoginAuth(string loginId)
        {
            bool isLoginExists = false;
            ISingleResult<BO_ClientLOginInfoAuthResult> result = s_ClientLoginAuthDataContext.BO_ClientLOginInfoAuth(loginId);

            if ((int)result.ReturnValue == FAILURE_ID)
            {
                string str = " Exception occured:- BO_GetPredefinedRoles";
                clsLog.LogSqlErr(str);
            }
            else
            {
                if (result.Count() > 0)
                {
                    isLoginExists = true;
                }
            }
            return isLoginExists;
        }

        public List<BO_GetAccountTypesResult> GetClientAccountTypes()
        {
            lock (s_GetClientAccountTypesDataContext)
            {
                ISingleResult<BO_GetAccountTypesResult> spResult = s_GetClientAccountTypesDataContext.BO_GetAccountTypes();

                List<BO_GetAccountTypesResult> lstAccountTypes = spResult.ToList();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    string str = " Exception occured:- GetClientAccountTypes";
                    clsLog.LogSqlErr(str);
                }
                return lstAccountTypes;
            }
        }

        public List<BO_GetVirtualDealersResult> GetVirtualDealerInfo()
        {
            lock (s_GetVirtualDealerInfoDataContext)
            {
                ISingleResult<BO_GetVirtualDealersResult> spResult = s_GetVirtualDealerInfoDataContext.BO_GetVirtualDealers();

                List<BO_GetVirtualDealersResult> lstVirtualDealer = null;

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {

                }
                else
                {
                    lstVirtualDealer = spResult.ToList();
                }
                return lstVirtualDealer;
            }
        }

        public int InsertVirtualDealerInfo(clsVirtualDealerInfo virtualDealer)
        {
            lock (s_InsertVirtualDealerInfoDataContext)
            {
                int spResult = s_InsertVirtualDealerInfoDataContext.BO_InsertVirtualDealerInfo(virtualDealer.VirtualDealerID, virtualDealer.Delay,
                    virtualDealer.VirtualManagerAccount, virtualDealer.Groups, virtualDealer.Symbols, virtualDealer.MaximumVolume,
                    virtualDealer.MaximumLosingSlippage, virtualDealer.MaximumProfitSlippage, virtualDealer.MaximumProfitSlippageVolume,
                    virtualDealer.GapLevel, virtualDealer.GapSafeLevel, virtualDealer.GapTickCounter,
                    virtualDealer.GapPendingCancel, virtualDealer.GapTakeProfitSlide, virtualDealer.GapStopLossSlide, virtualDealer.NewsStopsFreezes,
                    virtualDealer.AllowPendingsOnNews);

                if (spResult == FAILURE_ID)
                {
                    return FAILURE_ID;
                }
                return spResult;
            }
        }

        public int UpdateVirtualDealerInfo(clsVirtualDealerInfo virtualDealer)
        {
            lock (s_UpdateVirtualDealerInfoDataContext)
            {
                int spResult = s_UpdateVirtualDealerInfoDataContext.BO_UpdateVirtualDealerInfo(virtualDealer.VirtualDealerID, virtualDealer.Delay,
                    virtualDealer.VirtualManagerAccount, virtualDealer.Groups, virtualDealer.Symbols, virtualDealer.MaximumVolume,
                    virtualDealer.MaximumLosingSlippage, virtualDealer.MaximumProfitSlippage, virtualDealer.MaximumProfitSlippageVolume,
                    virtualDealer.GapLevel, virtualDealer.GapSafeLevel, virtualDealer.GapTickCounter,
                    virtualDealer.GapPendingCancel, virtualDealer.GapTakeProfitSlide, virtualDealer.GapStopLossSlide, virtualDealer.NewsStopsFreezes,
                    virtualDealer.AllowPendingsOnNews);

                if (spResult == FAILURE_ID)
                {
                    return FAILURE_ID;
                }
                return spResult;
            }
        }

        public int DeleteVirtualDealer(int virtualDealerId)
        {
            lock (s_DeleteVirtualDealerDataContext)
            {
                int spResult = s_DeleteVirtualDealerDataContext.BO_DeleteVirtualDealer(virtualDealerId);

                if (spResult == FAILURE_ID)
                {
                    return FAILURE_ID;
                }
                return spResult;
            }
        }

        public List<BO_GetCollateralTransactionHistoryResult> Handle_BO_GetCollateralTransactionHistory(int AccountGroupID, int CollateralTypeID)
        {
            lock (s_GetCollateralTransactionHistoryDataContext)
            {
                List<BO_GetCollateralTransactionHistoryResult> lstCollateralTransHistory = null;
                ISingleResult<BO_GetCollateralTransactionHistoryResult> spResult = s_GetCollateralTransactionHistoryDataContext
                    .BO_GetCollateralTransactionHistory(AccountGroupID, CollateralTypeID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return lstCollateralTransHistory = spResult.ToList();
            }
        }

        public List<BO_GetAccountIDsByAccountTypeIDResult> BO_GetAccountIDsByAccountTypeID(int AccountTypeID)
        {
            lock (s_GetAccountIDsByAccountTypeIDDataContext)
            {
                ISingleResult<BO_GetAccountIDsByAccountTypeIDResult> spResult = s_GetAccountIDsByAccountTypeIDDataContext.BO_GetAccountIDsByAccountTypeID(AccountTypeID);

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList<BO_GetAccountIDsByAccountTypeIDResult>();
            }
        }

        public int Bo_ChangePassword(string loginId, string oldPassword, string newPassword)
        {
            lock (s_ChangePasswordDataContext)
            {
                int spResult = s_ChangePasswordDataContext.BO_ChangePassword(loginId, oldPassword, newPassword);

                if (spResult == FAILURE_ID)
                {
                    return -50060;
                }

                return spResult;
            }
        }

        public List<BO_GetInstClosingPriceResult> Bo_GetInstrClosingPrice()
        {
            lock (s_GetInstClosingPriceDataContext)
            {
                ISingleResult<BO_GetInstClosingPriceResult> spResult = s_GetInstClosingPriceDataContext.BO_GetInstClosingPrice();

                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public int Bo_InsertInstClosingPrice(clsInstrumentClosingPrice instClosingPrice)
        {
            lock (s_InsertInstClosingPriceDataContext)
            {
                int spResult = s_InsertInstClosingPriceDataContext.BO_InsertInstClosingPrice(
                    instClosingPrice.FK_InstrumentID, instClosingPrice.ClosingPrice, instClosingPrice.ClosingDate);

                if (spResult == FAILURE_ID)
                {
                    return -50060;
                }

                return spResult;
            }
        }

        public int Bo_UpdateInstClosingPrice(clsInstrumentClosingPrice instClosingPrice)
        {
            lock (s_pdateInstClosingPriceDataContext)
            {
                int spResult = s_pdateInstClosingPriceDataContext.BO_UpdateInstClosingPrice(instClosingPrice.PK_InstrumentClosingPrice,
                    instClosingPrice.FK_InstrumentID, instClosingPrice.ClosingPrice, instClosingPrice.ClosingDate);
                if (spResult == FAILURE_ID)
                {
                    return -50060;
                }

                return spResult;
            }
        }

        public List<BO_GetUnexpiredSymbolsResult> Bo_GetUnexpiredSymbols()
        {
            lock (s_GetUnexpiredSymbolsDataContext)
            {
                ISingleResult<BO_GetUnexpiredSymbolsResult> spResult = s_GetUnexpiredSymbolsDataContext.BO_GetUnexpiredSymbols();
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetHedgeTypesResult> Bo_GetHedgeTypes()
        {
            lock (s_GetHedgeTypesDataContext)
            {
                ISingleResult<BO_GetHedgeTypesResult> spResult = s_GetHedgeTypesDataContext.BO_GetHedgeTypes();
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }
                return spResult.ToList();
            }
        }

        public List<BO_GetTGListResult> Bo_GetTGList()
        {
            lock (s_GetTGListDataContext)
            {
                ISingleResult<BO_GetTGListResult> spResult = s_GetTGListDataContext.BO_GetTGList();
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<BO_GetTGSymbolsInfoResult> Bo_GetTGSymbolsInfo(int tgID)
        {
            lock (s_GetTGSymbolsInfoDataContext)
            {
                ISingleResult<BO_GetTGSymbolsInfoResult> spResult = s_GetTGSymbolsInfoDataContext.BO_GetTGSymbolsInfo(tgID);
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

        public List<clsHistoricalData> Bo_GetHistoricalData(string symbolName, string periodicity, int? barsNo)
        {
            //lock (s_GetHistoricalDataDataContext)
            //{
            // ISingleResult<BO_GetHedgeTypesResult> spResult = s_GetHistoricalDataDataContext.BO_GetHistoricalData(symbolName,periodicity,barsNo);
            //    if ((int)spResult.ReturnValue == FAILURE_ID)
            //    {
            //        return null;
            //    }

            //    return spResult.ToList();
            //}

            List<clsHistoricalData> lstHistoryData = new List<clsHistoricalData>();
            ////SqlDataReader rdr = null;
            ////conn.Open();
            ////SqlCommand cmd = new SqlCommand(
            ////    "BO_GetHistoricalData", conn);
            ////cmd.CommandType = CommandType.StoredProcedure;
            ////cmd.Parameters.Add(
            ////    new SqlParameter("@SymbolName", symbolName));
            ////cmd.Parameters.Add(
            ////    new SqlParameter("@Periodicity", periodicity));
            ////cmd.Parameters.Add(
            ////    new SqlParameter("@bar", barsNo));
            ////rdr = cmd.ExecuteReader();
            ////while (rdr.Read())
            ////{
            ////    clsHistoricalData objclsHistoricalData = new clsHistoricalData();
            ////    objclsHistoricalData.SymbolName = rdr["Symbol"].ToString();
            ////    objclsHistoricalData.ID = Convert.ToInt32(rdr["ID"]);
            ////    objclsHistoricalData.FeedTime = Convert.ToDateTime(rdr["FeedTime"]);
            ////    objclsHistoricalData.Open = clsUtility.GetDouble(rdr["OpenPrice"]);
            ////    objclsHistoricalData.High = clsUtility.GetDouble(rdr["HighPrice"]);
            ////    objclsHistoricalData.Low = clsUtility.GetDouble(rdr["LowPrice"]);
            ////    objclsHistoricalData.Close = clsUtility.GetDouble(rdr["ClosePrice"]);
            ////    objclsHistoricalData.Volume = clsUtility.GetLong(rdr["Volume"]);

            ////    lstHistoryData.Add(objclsHistoricalData);
            ////}

            //conn.Close();
            return lstHistoryData;
        }


        public List<BO_GetBrokersLogNewResult> Bo_GetBrokersLog(int? brokerId, DateTime fromDate, DateTime ToDate)
        {
            lock (s_GetBrokersLogDataContext)
            {
                ISingleResult<BO_GetBrokersLogNewResult> spResult = s_GetBrokersLogDataContext.BO_GetBrokersLogNew(brokerId, fromDate, ToDate);
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }
        public List<clsBrokerOperationsLog> HandleBrokersOperationsLog(int _brokerId, DateTime frmDate, DateTime toDate)
        {
            List<clsBrokerOperationsLog> lstBrokersLog = new List<clsBrokerOperationsLog>();
            List<BO_GetBrokersListResult> spRslt = HandleBO_GetBrokersList(_brokerId);

            foreach (var i in spRslt)
            {
                foreach (BO_GetBrokersLogNewResult item in Bo_GetBrokersLog(i.PK_AccountGroupID, frmDate, toDate))
                {
                    clsBrokerOperationsLog objclsBrokerOperationsLog = new clsBrokerOperationsLog();
                    objclsBrokerOperationsLog.SNo = clsUtility.GetInt(item.SNo);
                    objclsBrokerOperationsLog.BrokerName = clsUtility.GetStr(item.BrokerName);
                    objclsBrokerOperationsLog.BrokerID = clsUtility.GetInt(item.BrokerID);
                    objclsBrokerOperationsLog.OperationName = clsUtility.GetStr(item.OperationName);
                    objclsBrokerOperationsLog.DateTime = clsUtility.GetDate(item.DateTime);
                    objclsBrokerOperationsLog.Message = clsUtility.GetStr(item.Message);
                    objclsBrokerOperationsLog.IPAddress = clsUtility.GetStr(item.IPAddress);
                    objclsBrokerOperationsLog.ServerResponseID = -50052;

                    lstBrokersLog.Add(objclsBrokerOperationsLog);
                }
            }
            return lstBrokersLog;
        }
        public int Bo_InsertBrokersLog(clsBrokerOperationsLog brokerLogInfo)
        {
            lock (s_InsertBrokersLogDataContext)
            {
                int spResult = s_InsertBrokersLogDataContext.BO_InsertBrokerLog(brokerLogInfo.BrokerName, brokerLogInfo.BrokerID,
                    brokerLogInfo.OperationName, brokerLogInfo.Message, brokerLogInfo.IPAddress);
                if (spResult == FAILURE_ID)
                {
                    return FAILURE_ID;
                }

                return spResult;
            }
        }
        //Namo
        public int Bo_InsertBrokersLog(string _brokerName, int? _brokerID, string _operationName, DateTime _dateTime, string _Message, string _IPAddress)
        {
            lock (s_InsertBrokersLogDataContext)
            {
                int spResult = s_InsertBrokersLogDataContext.BO_InsertBrokerLog(_brokerName, _brokerID,
                    _operationName, _Message, _IPAddress);
                if (spResult == FAILURE_ID)
                {
                    return FAILURE_ID;
                }

                return spResult;
            }
        }

        //public List<BO_GetAccountTransactionResult> BO_GetAccountTransactionInfo(int AccountTypeID)
        //{
        //    lock (s_GetAccountTransactionDataContext)
        //    {
        //        ISingleResult<BO_GetAccountTransactionResult> spResult = s_GetAccountTransactionDataContext.BO_GetAccountTransaction(AccountTypeID);

        //        if ((int)spResult.ReturnValue == FAILURE_ID)
        //        {
        //            return null;
        //        }

        //        return spResult.ToList<BO_GetAccountTransactionResult>();
        //    }
        //}

        public int Bo_UpdateAccountTransactionInfo(clsAccount accountsTransInfo)
        {
            lock (s_UpdateAccountTransactionDataContext)
            {
                int spResult = 0;
                //int spResult = s_UpdateAccountTransactionDataContext.BO_UpdateAccountTransaction(accountsTransInfo.EditAccountTransactionID, accountsTransInfo.AccountId, accountsTransInfo.PaymentAmount,
                //    accountsTransInfo.PaymentType, accountsTransInfo.PaymentMode, accountsTransInfo.PaymentDate, accountsTransInfo.ChequeFdNo, accountsTransInfo.Remark);
                //if (spResult == FAILURE_ID)
                //{
                //    return FAILURE_ID;
                //}

                return spResult;
            }
        }

        public List<BO_GetContractSizeResult> Bo_GetContractSize()
        {
            lock (s_GetContractSize)
            {
                ISingleResult<BO_GetContractSizeResult> spResult = s_GetContractSize.BO_GetContractSize();
                if ((int)spResult.ReturnValue == FAILURE_ID)
                {
                    return null;
                }

                return spResult.ToList();
            }
        }

    }

}