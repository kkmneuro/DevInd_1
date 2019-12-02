using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsBOMasterInfo
    {
        [DataMember]
        public Dictionary<int, string> DDRoutingPerformAction { get; set; }
        [DataMember]
        public Dictionary<int, string> DDRequestType { get; set; }
        [DataMember]
        public Dictionary<int, string> DDOrderType { get; set; }
        [DataMember]
        public Dictionary<int, string> DDAdditionalConditionType { get; set; }
        [DataMember]
        public Dictionary<int, string> DDDealerList { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
