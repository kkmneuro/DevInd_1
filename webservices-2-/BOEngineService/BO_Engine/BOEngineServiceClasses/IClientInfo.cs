using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IClientInfo
    /// </summary>
    [ServiceContract]
    public interface IClientInfo
    {
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
        List<clsAccount> GetAccounts(string userIdPwd, int clientID,AccountOpType opType);
        [OperationContract]
        clsAccount InsertIntoAccount(string userIdPwd, clsAccount account);
        [OperationContract]
        clsAccount UpdateAccount(string userIdPwd, clsAccount account,AccountOpType opType);
        //[OperationContract]
        //List<clsAccountTransaction> HandleAccountTransactionOperation(string userIdPwd, OperationTypes opType,clsAccountTransaction account);
    }
}
