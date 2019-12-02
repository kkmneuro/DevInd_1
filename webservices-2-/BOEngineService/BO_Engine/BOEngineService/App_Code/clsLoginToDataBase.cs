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

/// <summary>
/// Summary description for clsLoginToDataBase
/// </summary>
public class clsLoginToDataBase
{
    public string LoginId;
    public string Password;
    public int? BrokerId;
    public string Role;
    public string BrokerName_;
    public int? BrokerNameID_;
    public string BrokerCompany;
    public bool? IsEnable;
}
