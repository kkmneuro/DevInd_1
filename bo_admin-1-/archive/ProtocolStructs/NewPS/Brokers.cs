using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class BrokerSymbol
    {
        public int SymbolID { get; set; }
        public string SymbolName { get; set; }
    }

    public class charges
    {
        public int ChargesID { get; set; }
        public int BrokersGroupID { get; set; }
        public int SymbolID { get; set; }
        public string Symbol { get; set; }
        public string Fee { get; set; }
        public int FeeValue { get; set; }
        public string Tax { get; set; }
        public Double TaxValue { get; set; }
    }

    public class Brokers
    {
        public int _BrokerID;
        public string _Name;
        public string _Owner;
        public string _Leverage;
        public string _State;
        public bool _IsEnable;
        public string _BrokerType;
        public string _Address;
        public string _City;
        public string _Phone1;
        public string _Phone2;
        public string _Fax;
        public string _EMail;
        public int _MarginCallLevel1;
        public int _MarginCallLevel2;
        public int _MarginCallLevel3;
        public string _News;
        public string _MaximumOrders;
        public string _Maximumsymbols;
        public List<BrokerSymbol> _lstSymbol;
        public List<BrokerSymbol> _lstTotalSymbols;
        public List<string> _lstFeeType;
        public List<string> _lstTaxType;
        public List<charges> _lstCharges;
        public int _lstSymbolCount;
        public int _lstTotalSymbolsCount;
        public int _lstFeeTypeCount;
        public int _lstTaxTypeCount;
        public int _lstChargesCount;
        public int _BrokerParent;
        public string _Roles;
        public int _RoleId;
        public string _RoleName;
        public string _LoginID;
        public Brokers()
        {
            _BrokerID=0;
            _Name = String.Empty;
            _Owner = String.Empty;
            _Leverage = String.Empty;
            _State = String.Empty;
            _IsEnable = false;
            _BrokerType = String.Empty;
            _Address = String.Empty;
            _City = String.Empty;
            _Phone1 = String.Empty;
            _Phone2 = String.Empty;
            _Fax = String.Empty;
            _EMail = String.Empty;
            _MarginCallLevel1 = 0;
            _MarginCallLevel2 = 0;
            _MarginCallLevel3 = 0;
            _News = String.Empty;
            _MaximumOrders = String.Empty;
            _Maximumsymbols = String.Empty;
            _lstSymbol = new List<BrokerSymbol>();
            _lstTotalSymbols = new List<BrokerSymbol>();
            _lstFeeType = new List<string>();
            _lstTaxType = new List<string>();
            _lstCharges = new List<charges>();
            _lstSymbolCount = 0;
            _lstTotalSymbolsCount = 0;
            _lstFeeTypeCount = 0;
            _lstTaxTypeCount = 0;
            _lstChargesCount = 0;
            _BrokerParent = 0;
            _Roles = string.Empty;
            _RoleId = 0;
            _RoleName = string.Empty;
            _LoginID = string.Empty;
        }

        public override string ToString()
        {
            return
            "_BrokerID->" + _BrokerID +
            "_Name->" + _Name +
            "_Owner->" + _Owner +
            "_Leverage->" + _Leverage +
            "_State->" + _State +
            "_IsEnable->" + _IsEnable +
            "_BrokerType->" + _BrokerType +
            "_Address->" + _Address +
            "_City->" + _City +
            "_Phone1->" + _Phone1 +
            "_Phone2->" + _Phone2 +
            "_Fax-> " + _Fax+
            "_EMail-> " + _EMail+
            "_MarginCallLevel1-> " + _MarginCallLevel1+
            "_MarginCallLevel2-> " + _MarginCallLevel2+
            "_MarginCallLevel3-> " + _MarginCallLevel3+
            "_News-> " + _News+
            "_MaximumOrders-> " + _MaximumOrders+
            "_Maximumsymbols-> " + _Maximumsymbols+
            "_SymbolCount-> " + _lstSymbol.Count+
            "_lstTotalSymbolsCount->"+_lstTotalSymbols.Count+
            "_lstFeeTypeCount->"+_lstFeeType.Count+
            "_lstTaxTypeCount->"+_lstTaxType.Count+
            "_lstChargesCount->"+_lstCharges.Count+
            "_lstSymbolCount->" + _lstSymbolCount +
            "_lstTotalSymbolsCount->" + _lstTotalSymbolsCount +
            "_lstFeeTypeCount->" + _lstFeeTypeCount +
            "_lstTaxTypeCount->" + _lstTaxTypeCount +
            "_lstChargesCount->" + _lstChargesCount +
            "_BrokerParent->" + _BrokerParent+
            "_Roles->" + _Roles+
            "_RoleId->" + _RoleId+
            "_RoleName->" + _RoleName+
            "_LoginID->" + _LoginID
            ;

        }
    }
}
