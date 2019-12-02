using System;

using System.Runtime.Serialization;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsTradingGateway
    /// </summary>
    [DataContract]
    public class clsTradingGateway
    {
        [DataMember]
        public int PKTradingGateWaysID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ServerIP { get; set; }
        [DataMember]
        public string Port { get; set; }
        [DataMember]
        public string DataType { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int IdleTimeOut { get; set; }
        [DataMember]
        public int ReconnectAfter { get; set; }
        [DataMember]
        public int SleepFor { get; set; }
        [DataMember]
        public int Attempts { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public List<string> LstSymbol { get; set; }
        [DataMember]
        public List<string> LstSymbolAlias { get; set; }
        [DataMember]
        public List<string> LstTotalSymbol { get; set; }
        [DataMember]
        public bool EnableRMS { get; set; }
        [DataMember]
        public int OrderPort { get; set; }
        [DataMember]
        public List<decimal> LstSymbolConversionFormula { get; set; }
        [DataMember]
        public string OrderIP { get; set; }
        [DataMember]
        public List<string> LstProductName { get; set; }
        [DataMember]
        public List<string> LstProductAlias { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}