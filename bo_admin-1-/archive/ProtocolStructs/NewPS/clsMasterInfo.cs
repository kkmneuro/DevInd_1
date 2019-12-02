using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class clsMasterInfo
    {
        public List<String> _lstDeliveryUnit;
        public List<String> _lstOrderTypes;
        public List<String> _lstProductNames;
        public List<String> _lstDataTypes;
        public List<String> _lstIdleTimeOut;
        public List<String> _lstReconnectAfter;
        public int _lstDeliveryUnitCount;
        public int _lstOrderTypesCount;
        public int _lstProductNamesCount;
        public int _lstDataTypesCount;
        public int _lstIdleTimeOutCount;
        public int _lstReconnectAfterCount;
        public Dictionary<int, string> _DDRoles;
        public int _RolesCount;
        public Dictionary<int,string> _DDSymbols;
        public Dictionary<int, string> _DDLPNames;
        public int _LPNameCount;
        public Dictionary<int, string> _DDClientAccountTypes;
        public int _ClientAccountTypesCount;

        public clsMasterInfo()
        {
            _lstDeliveryUnitCount=0;
            _lstOrderTypesCount=0;
            _lstProductNamesCount=0;
            _lstDataTypesCount=0;
            _lstIdleTimeOutCount=0;
            _lstReconnectAfterCount=0;
            _lstDeliveryUnit=new List<string>();
            _lstOrderTypes=new List<string>();
            _lstProductNames=new List<string>();
            _lstDataTypes=new List<string>();
            _lstIdleTimeOut=new List<string>();
            _lstReconnectAfter=new List<string>();
            _DDRoles = new Dictionary<int, string>();
            _RolesCount = 0;
            _DDSymbols = new Dictionary<int, string>();
            _DDLPNames = new Dictionary<int, string>();
            _LPNameCount = 0;
            _DDClientAccountTypes = new Dictionary<int, string>();
            _ClientAccountTypesCount = 0;
        }

        public override string ToString()
        {
            return "_lstDeliveryUnitCount->" + _lstDeliveryUnitCount +
                "_lstOrderTypesCount->" + _lstOrderTypesCount +
                "_lstProductNamesCount->" + _lstProductNamesCount +
                "_lstDataTypesCount->" + _lstDataTypesCount +
                "_lstIdleTimeOutCount->" + _lstIdleTimeOutCount +
                "_lstReconnectAfterCount->" + _lstReconnectAfterCount +
                "_lstDeliveryUnitCount->" + _lstDeliveryUnit.Count +
                "_lstOrderTypesCount->" + _lstOrderTypes.Count +
                "_lstProductNamesCount->" + _lstProductNames.Count +
                "_lstDataTypesCount->" + _lstDataTypes.Count +
                "_lstIdleTimeOutCount->" + _lstIdleTimeOut.Count +
                "_lstReconnectAfterCount" + _lstReconnectAfter.Count +
                "_DDRoles" + _DDRoles+
                "_RolesCount"+_RolesCount+
                "_DDLPNames"+_DDLPNames+
                "_LPNameCount" + _LPNameCount +
                "_DDClientAccountTypes" + _DDClientAccountTypes +
                "_ClientAccountTypesCount" + _ClientAccountTypesCount;
        }
    }
}
