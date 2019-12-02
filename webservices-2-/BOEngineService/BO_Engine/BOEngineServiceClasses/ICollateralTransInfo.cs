using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ICollateralTransInfo
    /// </summary>
    [ServiceContract]
    public interface ICollateralTransInfo
    {
        [OperationContract]
        List<clsCollateralTransInfo> HandleCollateralTransInfo(string userIdPwd, int accountGroupID, OperationTypes opType, clsCollateralTransInfo collateralTransInfo);
        [OperationContract]
        List<clsCollateralTransInfo> GetCollateralTransactionHistory(string userIdPwd, int accountGroupID, int CollateralTypeID);
        //[OperationContract]
        //clsCollateralTransInfo InsertCollateralTransInfo(string userIdPwd, clsCollateralTransInfo collateralTransInfo);
    }
}
