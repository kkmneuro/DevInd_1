using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ITaxMaster
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.Sign)]
    public interface ITaxMaster
    {
        [OperationContract]
        List<clsTaxMaster> HandleTaxMaster(string userId,OperationTypes opType, clsTaxMaster taxValue);
        //[OperationContract]
        //clsTaxMaster InsertIntoTaxMaster(string userId, clsTaxMaster taxValue);
        //[OperationContract]
        //int DeleteTaxMaster(string userId, int deleteRecordID);
        //[OperationContract]
        //clsTaxMaster UpdateTaxMaster(string userId, clsTaxMaster taxValue);
    }
}
