using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace OHLCFundExchangeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOHLCFundExchangeService" in both code and config file together.
    [ServiceContract]
    public interface IOHLCFundExchangeService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "{EndDate}/{Bars}/{SymbolID}/{periodicity}")]
        List<OHLCData> GetHistoricalDataBySymbolID(string endDate, int symbolId, int interval, string bars, PeriodEnum periodicity);
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "{EndDate}/{Bars}/{Symbol}/{periodicity}")]
        List<OHLCData> GetHistoricalDataBySymbolName(string endDate, string symbol, int interval, string bars, PeriodEnum periodicity);
    }

    [DataContract]
    public class OHLCData
    {
        [DataMember]
        public DateTime DateTime;
        [DataMember]
        public double Open;
        [DataMember]
        public double High;
        [DataMember]
        public double Low;
        [DataMember]
        public double Close;
        [DataMember]
        public double Volume;
    }
  
    [DataContract]
    public enum PeriodEnum : int
    { [EnumMember] Minute = 1, [EnumMember] Hour = 60, [EnumMember] Day = 480, [EnumMember] Week = 2400, [EnumMember] Month = 9600, [EnumMember] Year = 115200 };
}
