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

/// <summary>
/// Summary description for IMapOrders
/// </summary>
[ServiceContract]
public interface IMapOrders
{
    [OperationContract]
    List<clsMapOrders> GetMapOrders(string userIdPwd);
    [OperationContract]
    List<string> GetAccountIDsByAccountType(string userIdPwd,int AccountTypeID);
}
