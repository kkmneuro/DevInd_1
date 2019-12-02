

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IFeeMaster
    /// </summary>
    [ServiceContract]
    public interface IFeeMaster
    {
        [OperationContract]
        List<clsFeeMaster> HandleFeeMaster(string userId, OperationTypes opType, clsFeeMaster feeValue);
        //[OperationContract]
        //clsFeeMaster InsertIntoFeeMaster(string userId, clsFeeMaster feeValue);
        //[OperationContract]
        //int DeleteFeeMaster(string userId, int deleteRecordID);
        //[OperationContract]
        //clsFeeMaster UpdateFeeMaster(string userId, clsFeeMaster feeValue);
    }

}