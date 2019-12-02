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
/// Summary description for clsTrades
/// </summary>
[DataContract]
public class clsTrades
{
    [DataMember]
    public int AccountID { get; set; }
    [DataMember]
    public int OrderID { get; set; }
    [DataMember]
    public int TradeNo { get; set; }
    [DataMember]
    public DateTime Time { get; set; }
    [DataMember]
    public string Type { get; set; }
    [DataMember]
    public int Quantity { get; set; }
    [DataMember]
    public string SymbolID { get; set; }
    [DataMember]
    public string OrderType { get; set; }
    [DataMember]
    public string OrderPrice { get; set; }
    [DataMember]
    public string TriggerPrice { get; set; }
    [DataMember]
    public string Comment { get; set; }
    [DataMember]
    public string Status { get; set; }
    [DataMember]
    public DateTime Validity { get; set; }
    [DataMember]
    public string BrokerName { get; set; }
    [DataMember]
    public int Volume { get; set; }
    [DataMember]
    public int FilledQuantity { get; set; }
    [DataMember]
    public int LeaveQuantity { get; set; }
    [DataMember]
    public int AvgFillPrice { get; set; }
    [DataMember]
    public int SettledQty { get; set; }
    [DataMember]
    public int ServerResponseID { get; set; }
}
