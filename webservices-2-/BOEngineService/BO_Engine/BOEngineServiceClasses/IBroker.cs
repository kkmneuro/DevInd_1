using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IBroker
    /// </summary>
    [ServiceContract]
    public interface IBroker
    {
        [OperationContract]
        List<clsBroker> HandleBrokers(string userIdPwd,int BrokerId, OperationTypes opType, clsBroker broker);
        //[OperationContract]
        //clsBroker InsertIntoBroker(string userIdPwd, clsBroker broker);
        //[OperationContract]
        //clsBroker UpdateBroker(string userIdPwd, clsBroker broker);
    }
}
