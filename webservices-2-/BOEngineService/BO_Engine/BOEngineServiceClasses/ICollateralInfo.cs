using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
/// <summary>
/// Summary description for ICollateralInfo
/// </summary>
    [ServiceContract]
    public interface ICollateralInfo
    {
        [OperationContract]
        List<clsCollateralInfo> GetCollateralInfo(string userIdPwd);
    }
}
