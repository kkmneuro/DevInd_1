using System;

using System.ServiceModel;
using System.Collections.Generic;
using System.Net.Security;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IContractSpecification
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IContractSpecification
    {
        [OperationContract()]
        List<clsContractSpecification> HandleContractSpecfication(string userId, OperationTypes opType, clsContractSpecification csInfo);
        [OperationContract()]
        List<clsSymbolSessionNew> HandleContractSession(string userId, OperationTypes opType, List<int> instrumentIds);
        //[OperationContract()]
        //clsContractSpecification InsertIntoContractSpecification(string userId, clsContractSpecification csInfo);
        //[OperationContract()]
        //int DeleteContractSpecification(string userId, int deleteRecordID);
        //[OperationContract()]
        //clsContractSpecification UpdateContractSpecification(string userId, clsContractSpecification csInfo);
    }
}
