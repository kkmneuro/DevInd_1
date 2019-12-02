using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using System.ServiceModel;

using System.Collections.Generic;
using System.Net.Security;
using BOEngineServiceClasses;

/// <summary>
/// Summary description for ILogin
/// </summary>
[ServiceContract]
public interface ILogin
{
    [OperationContract(ProtectionLevel=ProtectionLevel.EncryptAndSign)]
    clsLogin AuthenticateLogin(string LoginPwd, clsLogin login, string ipAddress);
    [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    void LogOut(string LoginID, clsBrokerOperationsLog brokerOperations);
    [OperationContract(ProtectionLevel=ProtectionLevel.Sign)]
    List<clsBrokerOperationsLog> HandleBrokerOperationsLog(string LoginPwd, clsBrokerOperationsLog brokerOperations,DateTime fromDate,DateTime ToDate, OperationTypes opTypes);
    [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
    List<clsHistoricalData> GetHistoricalData(string LoginPwd, string symbolName, string periodicity, int barsNo,clsHistoricalData historicalInfo
        ,OperationTypes opTypes);
}