using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IIPAccessList
    /// </summary>
    [ServiceContract]
    public interface IIPAccessList
    {
        [OperationContract]
        List<clsIPAccessList> HandleIPAccessList(string userId, OperationTypes opType, clsIPAccessList ipAccess);
        //[OperationContract]
        //clsIPAccessList InsertIntoIpAccessList(string userId,clsIPAccessList ipAccess);
        //[OperationContract]
        //int DeleteIpAccessList(string userId, int deleteID);
        //[OperationContract]
        //clsIPAccessList UpdateIpAccessList(string userId, clsIPAccessList ipAccess);
    }
}
