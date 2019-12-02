using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ICommonSettings
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ICommonSettings
    {
        [OperationContract]
        List<clsCommonSettings> HandleCommonSettings(string userId, OperationTypes opType, clsCommonSettings commonSettings);
        //[OperationContract]
        //clsCommonSettings UpdateCommonSettings(string userId, clsCommonSettings commonSettings);
    }
}