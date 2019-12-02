using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ICollateralTypes
    /// </summary>
    [ServiceContract]
    public interface ICollateralTypes
    {
        [OperationContract]
        List<clsCollateralTypes> GetCollateralTypes(string userIdPwd);
    }
}