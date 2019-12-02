using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace AlertScriptService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlertScriptService" in both code and config file together.
    [ServiceContract]
    public interface IAlertScriptService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<AlertScripts> GetAlertScripts();
    }

    [DataContract]
    public class AlertScripts
    {
        [DataMember]
        public string Abbreviation;
        [DataMember]
        public string AlertName;
        [DataMember]
        public string Bars;
        [DataMember]
        public string BuyScript;
        [DataMember]
        public bool DayHours;
        [DataMember]
        public string DefaultScript;
        [DataMember]
        public bool Enabled;
        [DataMember]
        public bool EndOfDay;
        [DataMember]
        public string Exchange;
        [DataMember]
        public string ExitLongScript;
        [DataMember]
        public string ExitShortScript;
        [DataMember]
        public bool GTC;
        [DataMember]
        public bool GTCHours;
        [DataMember]
        public int Interval;
        [DataMember]
        public bool IsUserDefined;
        [DataMember]
        public bool Limit;
        [DataMember]
        public bool Market;
        [DataMember]
        public short NumberOfLines;
        [DataMember]
        public string Period;
        [DataMember]
        public string Portfolio;
        [DataMember]
        public int Quantity;
        [DataMember]
        public string SellScript;
        [DataMember]
        public bool StopLimit;
        [DataMember]
        public string StopLimitValue;
        [DataMember]
        public bool StopMarket;
        [DataMember]
        public string Symbol;
        [DataMember]
        public string TradeSignalScript;
        [DataMember]
        public Guid UniqueIdField;

    }
}
