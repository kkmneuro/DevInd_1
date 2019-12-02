using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace TickerDisplayInfoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITickerDisplayInfoService" in both code and config file together.
    [ServiceContract]
    public interface ITickerDisplayInfoService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<string> GetTickerDisplayInfo(int AccountGroupId);
    }

    [DataContract]
    public class TickerDisplayInfo
    {
        [DataMember]
        public string TickerInfo;
    }
}
