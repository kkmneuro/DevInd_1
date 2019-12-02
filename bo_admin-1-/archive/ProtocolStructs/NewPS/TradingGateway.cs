using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class TradingGateway
    {
        public int _PK_TradingGateWaysID;
        public string _Name;
        public string _Description;
        public string _Server_IP;
        public string _Port;
        public string _DataType;
        public string _Login;
        public string _Password;
        public int _IdleTimeOut;
        public int _ReconnectAfter;
        public int _SleepFor;
        public int _Attempts;
        public bool _IsEnable;
        public List<string> _lstSymbol;
        public List<string> _lstSymbolAlias;
        public List<string> _lstTotalSymbol;
        public List<decimal> _lstSymbolConversionFormula;
        public int _lstSymbolCount;
        public int _lstSymbolAliasCount;
        public int _lstTotalSymbolCount;
        public int _lstSymbolConversionFormulaCount;
        public bool _enableRMS;
        public int _orderPort;

        public TradingGateway()
        {

            _PK_TradingGateWaysID = 0;
            _Name = string.Empty;
            _Description = string.Empty;
            _Server_IP = string.Empty;
            _Port = string.Empty;
            _DataType = string.Empty;
            _Login = string.Empty;
            _Password = string.Empty;
            _IdleTimeOut = 0;
            _ReconnectAfter = 0;
            _SleepFor = 0;
            _Attempts = 0;
            _IsEnable = true;
            _lstSymbol = new List<string>();
            _lstSymbolAlias = new List<string>();
            _lstTotalSymbol = new List<string>();
            _lstSymbolCount = 0;
            _lstSymbolAliasCount = 0;
            _lstTotalSymbolCount = 0;
            _enableRMS = false;
            _orderPort = 0;
            _lstSymbolConversionFormula = new List<decimal>();
            _lstSymbolConversionFormulaCount = 0;

        }
        public override string ToString()
        {
            return
            "_PK_TradingGateWaysID->" + _PK_TradingGateWaysID +
            "_Name->" + _Name +
            "_Description->" + _Description +
            "_Server_IP->" + _Server_IP +
            "_Port->" + _Port +
            "_DataType->" + _DataType +
            "_Login->" + _Login +
            "_Password->" + _Password +
            "_IdleTimeOut->" + _IdleTimeOut +
            "_ReconnectAfter->" + _ReconnectAfter +
            "_SleepFor->" + _SleepFor +
            "_Attempts->" + _Attempts +
            "_IsEnable->" + _IsEnable +
            "_SymbolCount-> " + _lstSymbol.Count +
            "_SymbolAliasCount->" + _lstSymbolAlias.Count +
            "_TotalSymbolCount->" + _lstTotalSymbol.Count+
            "_enableRMS->" + _enableRMS+
            "_orderPort->" + _orderPort+
            "_lstSymbolConversionFormula->" + _lstSymbolConversionFormula +
            "_lstSymbolConversionFormulaCount->" + _lstSymbolConversionFormulaCount;
        }
    }
}
