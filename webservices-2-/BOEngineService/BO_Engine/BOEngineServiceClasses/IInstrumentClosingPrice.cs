using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    [ServiceContract]
    public interface IInstrumentClosingPrice
    {
        [OperationContract]
        List<clsInstrumentClosingPrice> HandleInstClosingPrice(string userId, clsInstrumentClosingPrice instrumentClosingPrice,
            OperationTypes operationType);
    }

    public enum OperationTypes
    {
        GET,
        INSERT,
        UPDATE,
        DELETE,
        GET_SESSION
    }
}
