using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    [DataContract]
    public class clsBrokerOperationsLog
    {
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public string BrokerName { get; set; }
        [DataMember]
        public int BrokerID { get; set; }      
        [DataMember]
        public string OperationName { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
