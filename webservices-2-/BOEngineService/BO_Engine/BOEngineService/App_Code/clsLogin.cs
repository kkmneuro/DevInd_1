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
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clsLogin
/// </summary>
[DataContract]
public class clsLogin
{
    [DataMember]
    public string LoginId { get; set; }
    [DataMember]
    public string Password { get; set; }
    [DataMember]
    public int BrokerId { get; set; }
    [DataMember]
    public string Role { get; set; }
    [DataMember]
    public string IPAddress { get; set; }
    [DataMember]
    public string BrokerName { get; set; }
    [DataMember]
    public int? BrokerNameID { get; set; }
    [DataMember]
    public string BrokerCompany { get; set; }
    [DataMember]
    public bool IsEnable { get; set; }
    [DataMember]
    public string ServerResponseMsg { get; set; }
    [DataMember]
    public int ServerResponseID { get; set; }
}
