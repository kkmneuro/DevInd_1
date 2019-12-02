using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for ITradingGateway
    /// </summary>
    [ServiceContract]
    public interface ITradingGateway
    {
        [OperationContract]
        List<clsTradingGateway> HandleTradingGateway(string userIdPwd, OperationTypes opType, clsTradingGateway tradingGateway);
        //[OperationContract]
        //clsTradingGateway InsertIntoTradingGateway(string userIdPwd, clsTradingGateway tradingGateway);
        //[OperationContract]
        //clsTradingGateway UpdateTradingGateway(string userIdPwd, clsTradingGateway tradingGateway);
    }
}