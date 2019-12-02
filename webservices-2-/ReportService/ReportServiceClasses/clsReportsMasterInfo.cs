using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsReportsMasterInfo
    {
        [DataMember]
        public Dictionary<int, string> OrderTypes { get; set; }
        [DataMember]
        public Dictionary<int, string> SideTypes { get; set; }
        [DataMember]
        public Dictionary<int, string> TIFTypes { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
