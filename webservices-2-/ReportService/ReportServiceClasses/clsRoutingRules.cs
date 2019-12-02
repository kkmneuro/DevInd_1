using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsRoutingRules
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string DealerCount { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int PerformActionID { get; set; }
        [DataMember]
        public string PerformValue { get; set; }
        [DataMember]
        public int RequestTypeID { get; set; }
        [DataMember]
        public int OrderTypeID { get; set; }
        [DataMember]
        public List<clsAdditionalConditions> AdditionalConditions { get; set; }
        [DataMember]
        public List<clsDealer> Dealers { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }

    [DataContract]
    public class clsAdditionalConditions
    {
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Condition { get; set; }
        [DataMember]
        public string Value { get; set; }
    }

    [DataContract]
    public class clsDealer
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    public enum OperationType
    {
        GET,
        INSERT,
        UPDATE,
        DELETE
    }
}
