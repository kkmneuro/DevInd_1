using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Collections.Generic;

namespace ReportServiceClasses
{
    [ServiceContract]
    public interface IBoOperations
    {
        [OperationContract]
        clsBOMasterInfo GetMasterInfo();
        [OperationContract]
        List<clsRoutingRules> HandleRoutingOperations(string userIdPwd, clsRoutingRules routingRules, OperationType opType);
    }
}
