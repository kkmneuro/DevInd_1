using BOEngineServiceClasses;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BOEngine
{
   
    [ServiceContract]
    public interface IBOEngineService
    {

        [OperationContract]
        clsLogin AuthenticateLogin(string LoginPwd, clsLogin login, string ipAddress);
        [OperationContract]

        void LogOut(string LoginID, clsBrokerOperationsLog brokerOperations);
        [OperationContract]
        List<clsBrokerOperationsLog> HandleBrokerOperationsLog(string LoginPwd, clsBrokerOperationsLog brokerOperations, DateTime fromDate, DateTime ToDate, OperationTypes opTypes);

        [OperationContract]
        List<clsHistoricalData> GetHistoricalData(string LoginPwd, string symbolName, string periodicity, int barsNo, clsHistoricalData historicalInfo
            , OperationTypes opTypes);

        [OperationContract]
        List<clsIPAccessList> HandleIPAccessList(string userId, OperationTypes opType, clsIPAccessList ipAccess);

        [OperationContract]
        List<clsFeeMaster> HandleFeeMaster(string userId, OperationTypes opType, clsFeeMaster feeValue);

        [OperationContract]
        List<clsTaxMaster> HandleTaxMaster(string userId, OperationTypes opType, clsTaxMaster taxValue);

        [OperationContract]
        List<clsHoliday> HandleHoliday(string userId, OperationTypes opType, clsHoliday holiday);

        [OperationContract()]
        List<clsContractSpecification> HandleContractSpecfication(string userId, OperationTypes opType, clsContractSpecification csInfo);

        [OperationContract()]
        List<clsSymbolSessionNew> HandleContractSession(string userId, OperationTypes opType, List<int> instrumentIds);

        [OperationContract]
        clsMasterInfo GetMasterInfo(string userId);
        [OperationContract]
        List<clsLeverage> GetLeverageList(string userIdPwd);
        [OperationContract]
        List<clsModule> GetModules(string userIdPwd);
        [OperationContract]
        List<clsParticipaintList> GetParticipaintList(string userIdPwd);
        [OperationContract]
        List<clsSecurityType> GetSecurityType(string userId);
        [OperationContract]
        List<clsCurrency> GetCurrencyList(string userId);
        [OperationContract]
        List<clsBrokerList> GetBrokerList(string userIdPwd);
        [OperationContract]
        List<clsCountryDetail> GetCountryDetails(string userIdPwd);
        [OperationContract]
        List<clsAccountGroup> GetAccountGroup(string userIdPwd);

        [OperationContract]
        List<clsTimeSettings> HandleTimeSettings(string userIdPwd, OperationTypes opType, clsTimeSettings timeSettings);

        [OperationContract]
        List<clsTradingGateway> HandleTradingGateway(string userIdPwd, OperationTypes opType, clsTradingGateway tradingGateway);

        [OperationContract]
        List<clsBroker> HandleBrokers(string userIdPwd, int BrokerId, OperationTypes opType, clsBroker broker);

        [OperationContract]
        List<clsCollateralTypes> GetCollateralTypes(string userIdPwd);

        [OperationContract]
        List<clsClientInfo> GetClientInfo(string userIdPwd);
        [OperationContract]
        clsClientInfo InsertIntoClientInfo(string userIdPwd, clsClientInfo clientInfo);
        [OperationContract]
        clsClientInfo UpdateClientInfo(string userIdPwd, clsClientInfo clientInfo);
        [OperationContract]
        bool AuthenticateClientID(string userIdPwd, string clientID);
        [OperationContract]
        List<clsBank> GetBankInfo(string userIdPwd, int clientID);
        [OperationContract]
        clsBank InsertIntoBankInfo(string userIdPwd, clsBank bank);
        [OperationContract]
        clsBank UpdateBankInfo(string userIdPwd, clsBank bank);
        [OperationContract]
        List<clsAccount> GetAccounts(string userIdPwd, int clientID, AccountOpType opType);
        [OperationContract]
        clsAccount InsertIntoAccount(string userIdPwd, clsAccount account);
        [OperationContract]
        clsAccount UpdateAccount(string userIdPwd, clsAccount account, AccountOpType opType);

        [OperationContract]
        List<clsCollateralInfo> GetCollateralInfo(string userIdPwd);

        [OperationContract]
        List<clsCollateralTransInfo> HandleCollateralTransInfo(string userIdPwd, int accountGroupID, OperationTypes opType, clsCollateralTransInfo collateralTransInfo);
        [OperationContract]
        List<clsCollateralTransInfo> GetCollateralTransactionHistory(string userIdPwd, int accountGroupID, int CollateralTypeID);

        [OperationContract]
        List<clsTrades> GetTradeOrdersDetails(string userIdPwd, DateTime startDate, DateTime endDate);
        [OperationContract]
        List<clsTrades> GetTradeDetails(string userIdPwd, DateTime startDate, DateTime endDate);
        [OperationContract]
        clsModifyTrades ModifyTrade(string userId, clsModifyTrades ModifyTrades);
        [OperationContract]
        clsNewOrder NewTrade(string userId, clsNewOrder NewTrade);
        [OperationContract]
        clsSettleTrade SettleTrade(string userId, clsSettleTrade SettleTrade);

        [OperationContract]
        List<clsMapOrders> GetMapOrders(string userIdPwd);
        [OperationContract]
        List<string> GetAccountIDsByAccountType(string userIdPwd, int AccountTypeID);

        [OperationContract]
        List<clsTGAccountConnectionSettings> HandleTGAccountConnetionSettings(string userIdPwd, OperationTypes opType, clsTGAccountConnectionSettings TGACSettings);

        [OperationContract]
        List<clsVirtualDealerInfo> HandleVirtualDealer(string userId, OperationTypes opType, clsVirtualDealerInfo virtualDealer);

        [OperationContract]
        List<clsCommonSettings> HandleCommonSettings(string userId, OperationTypes opType, clsCommonSettings commonSettings);
        [OperationContract]
        List<clsInstrumentClosingPrice> HandleInstClosingPrice(string userId, clsInstrumentClosingPrice instrumentClosingPrice,
            OperationTypes operationType);
    }

}
