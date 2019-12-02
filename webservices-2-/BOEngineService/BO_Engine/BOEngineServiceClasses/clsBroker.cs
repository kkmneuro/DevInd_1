using System;

using System.Runtime.Serialization;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsBroker
    /// </summary>
    [DataContract]
    public class clsBroker
    {
        [DataMember]
        public int BrokerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string Leverage { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public string BrokerType { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Phone1 { get; set; }
        [DataMember]
        public string Phone2 { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public int MarginCallLevel1 { get; set; }
        [DataMember]
        public int MarginCallLevel2 { get; set; }
        [DataMember]
        public int MarginCallLevel3 { get; set; }
        [DataMember]
        public string News { get; set; }
        [DataMember]
        public string MaximumOrders { get; set; }
        [DataMember]
        public string Maximumsymbols { get; set; }
        [DataMember]
        public List<BrokerSymbol> LstSymbol { get; set; }
        [DataMember]
        public List<BrokerSymbol> LstTotalSymbols { get; set; }
        [DataMember]
        public List<string> LstFeeType { get; set; }
        [DataMember]
        public List<string> LstTaxType { get; set; }
        [DataMember]
        public List<charges> LstCharges { get; set; }
        [DataMember]
        public int BrokerParent { get; set; }
        [DataMember]
        public string Roles { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }        
    }

    public class BrokerSymbol
    {
        public int SymbolID { get; set; }
        public string SymbolName { get; set; }
        public int BidSpread { get; set; }
        public int AskSpread { get; set; }
        public int Spread { get; set; }
        public bool IsVariable { get; set; }
        public int RelativeBidChange { get; set; }
        public int RelativeAskChange { get; set; }
    }

    public class charges
    {
        public int ChargesID { get; set; }
        public int BrokersGroupID { get; set; }
        public int SymbolID { get; set; }
        public string Symbol { get; set; }
        public string Fee { get; set; }
        public decimal FeeValue { get; set; }
        public string Tax { get; set; }
        public Double TaxValue { get; set; }
    }

}
