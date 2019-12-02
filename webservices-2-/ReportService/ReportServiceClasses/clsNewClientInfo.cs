using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsNewClientInfo
    {
        [DataMember]
        public int BrokerID { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public DateTime DateOfRegistration { get; set; }
        [DataMember]
        public long Capital { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
