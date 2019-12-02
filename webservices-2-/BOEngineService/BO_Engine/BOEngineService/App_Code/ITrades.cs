using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.ServiceModel;
using System.Collections.Generic;
using BOEngineServiceClasses;

/// <summary>
/// Summary description for ITrades
/// </summary>
[ServiceContract]
public interface ITrades
{
    [OperationContract]
    List<clsTrades> GetTradeOrdersDetails(string userIdPwd, DateTime startDate, DateTime endDate);
    [OperationContract]
    List<clsTrades> GetTradeDetails(string userIdPwd, DateTime startDate, DateTime endDate);
    [OperationContract]
    clsModifyTrades ModifyTrade(string userId, clsModifyTrades ModifyTrades);
    [OperationContract]
    clsNewOrder NewTrade(string userId, clsNewOrder NewTrade);
    [OperationContract]
    clsSettleTrade SettleTrade(string userId, clsSettleTrade SettleTrade);

}
