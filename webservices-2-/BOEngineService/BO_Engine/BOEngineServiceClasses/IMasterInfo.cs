using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IMasterInfo
    /// </summary>
    [ServiceContract]
    public interface IMasterInfo
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        clsMasterInfo GetMasterInfo(string userId);
        [OperationContract]
        List<clsLeverage> GetLeverageList(string userIdPwd);
        [OperationContract]
        List<clsModule> GetModules(string userIdPwd);
        [OperationContract]
        List<clsParticipaintList> GetParticipaintList(string userIdPwd);
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        List<clsSecurityType> GetSecurityType(string userId);
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        List<clsCurrency> GetCurrencyList(string userId);
        [OperationContract]
        List<clsBrokerList> GetBrokerList(string userIdPwd);
        [OperationContract]
        List<clsCountryDetail> GetCountryDetails(string userIdPwd);
        [OperationContract]
        List<clsAccountGroup> GetAccountGroup(string userIdPwd);
    }
}
