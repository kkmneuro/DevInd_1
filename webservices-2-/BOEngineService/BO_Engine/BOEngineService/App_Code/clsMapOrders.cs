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
/// Summary description for clsMapOrders
/// </summary>
[DataContract]
public class clsMapOrders
{
    [DataMember]
    public int MapOrderId { get; set; }
    [DataMember]
    public int BuyAccountID { get; set; }
    [DataMember]
    public int SellAccountID { get; set; }
    [DataMember]
    public Int64 BuySideOrderID { get; set; }
    [DataMember]
    public Int64 SellSideOrderID { get; set; }
    [DataMember]
    public int BuyFillID { get; set; }
    [DataMember]
    public int SellFillID { get; set; }
    [DataMember]
    public int FilledQty { get; set; }
    [DataMember]
    public DateTime LastUpdateTime { get; set; }
    [DataMember]
    public decimal Price { get; set; }
    [DataMember]
    public string Symbol { get; set; }
    [DataMember]
    public int ServerResponseID { get; set; }
}
