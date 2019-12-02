using System;

using System.Runtime.Serialization;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsMasterInfo
    /// </summary>
    [DataContract]
    public class clsMasterInfo
    {
        [DataMember]
        public List<String> lstDeliveryUnit { get; set; }
        [DataMember]
        public List<String> lstOrderTypes { get; set; }
        [DataMember]
        public List<String> lstProductNames { get; set; }
        [DataMember]
        public List<String> lstDataTypes { get; set; }
        [DataMember]
        public List<String> lstIdleTimeOut { get; set; }
        [DataMember]
        public List<String> lstReconnectAfter { get; set; }
        [DataMember]
        public Dictionary<int, string> DDRoles { get; set; }
        [DataMember]
        public Dictionary<int, string> DDSymbols { get; set; }
        [DataMember]
        public Dictionary<int, string> DDLPNames { get; set; }
        [DataMember]
        public Dictionary<int, string> DDClientAccountTypes { get; set; }
        [DataMember]
        public List<String> lstUnexpiredSymbols { get; set; }
        [DataMember]
        public Dictionary<int, string> DDHedgeTypes { get; set; }
        [DataMember]
        public Dictionary<string, Dictionary<string, List<string>>> DDTGSymbolsInfo { get; set; }
        [DataMember]
        public Dictionary<string, int> DDContractSize { get; set; }
        [DataMember]
        public Dictionary<string, string> DDCommonSettings { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}