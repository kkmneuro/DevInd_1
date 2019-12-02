using System;

using System.ServiceModel;
using System.Net.Security;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IVirtualDealer
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IVirtualDealer
    {
        [OperationContract]
        List<clsVirtualDealerInfo> HandleVirtualDealer(string userId, OperationTypes opType, clsVirtualDealerInfo virtualDealer);
    }

}