using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ITimeSettings
    /// </summary>
    [ServiceContract]
    public interface ITimeSettings
    {
        [OperationContract]
        List<clsTimeSettings> HandleTimeSettings(string userIdPwd, OperationTypes opType, clsTimeSettings timeSettings);
        //[OperationContract]
        //clsTimeSettings UpdateTimeSettings(string userIdPwd, clsTimeSettings timeSettings);
    }
}