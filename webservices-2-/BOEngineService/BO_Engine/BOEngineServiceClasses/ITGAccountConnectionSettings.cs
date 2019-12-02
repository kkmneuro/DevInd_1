using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ITGAccountConnectionSettings
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ITGAccountConnectionSettings
    {
        [OperationContract]
        List<clsTGAccountConnectionSettings> HandleTGAccountConnetionSettings(string userIdPwd, OperationTypes opType, clsTGAccountConnectionSettings TGACSettings);
        //[OperationContract]
        //clsTGAccountConnectionSettings InsertTGAccountConnetionSettings(string userIdPwd, clsTGAccountConnectionSettings TGACSettings);
        //[OperationContract]
        //clsTGAccountConnectionSettings UpdateTGAccountConnetionSettings(string userIdPwd, clsTGAccountConnectionSettings TGACSettings);
    }
}
