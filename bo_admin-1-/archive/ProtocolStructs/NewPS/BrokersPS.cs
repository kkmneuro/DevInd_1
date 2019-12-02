using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class BrokersPS:IProtocolStruct
    {

        public Brokers _Brokers;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public BrokersPS()
        {
            _Brokers = new Brokers();
        }

        public BrokersPS(Brokers deepCopy)
        {
            _Brokers._BrokerID = deepCopy._BrokerID;
            _Brokers._Name = deepCopy._Name;
            _Brokers._Owner = deepCopy._Owner;
            _Brokers._Leverage = deepCopy._Leverage;
            _Brokers._State = deepCopy._State;
            //_Brokers._BrokerName = deepCopy._BrokerName;
            //_Brokers._CompanyName = deepCopy._CompanyName;
            _Brokers._IsEnable = deepCopy._IsEnable;
            _Brokers._BrokerType = deepCopy._BrokerType;
            _Brokers._Address = deepCopy._Address;
            _Brokers._City = deepCopy._City;
            _Brokers._Phone1 = deepCopy._Phone1;
            _Brokers._Phone2 = deepCopy._Phone2;
            _Brokers._Fax = deepCopy._Fax;
            _Brokers._EMail = deepCopy._EMail;
            _Brokers._MarginCallLevel1 = deepCopy._MarginCallLevel1;
            _Brokers._MarginCallLevel2 = deepCopy._MarginCallLevel2;
            _Brokers._MarginCallLevel3 = deepCopy._MarginCallLevel3;
            _Brokers._News = deepCopy._News;
            _Brokers._MaximumOrders = deepCopy._MaximumOrders;
            _Brokers._Maximumsymbols = deepCopy._Maximumsymbols;
            _Brokers._lstSymbol = deepCopy._lstSymbol;
            _Brokers._lstCharges = deepCopy._lstCharges;
            _Brokers._lstTotalSymbols = deepCopy._lstTotalSymbols;
            _Brokers._lstFeeType = deepCopy._lstFeeType;
            _Brokers._lstTaxType = deepCopy._lstTaxType;
            _Brokers._lstSymbolCount = deepCopy._lstSymbolCount;
            _Brokers._lstTotalSymbolsCount = deepCopy._lstTotalSymbolsCount;
            _Brokers._lstFeeTypeCount = deepCopy._lstFeeTypeCount;
            _Brokers._lstTaxTypeCount = deepCopy._lstTaxTypeCount;
            _Brokers._lstChargesCount = deepCopy._lstChargesCount;
            _Brokers._BrokerParent = deepCopy._BrokerParent;
            _Brokers._Roles = deepCopy._Roles;
            _Brokers._RoleId=deepCopy._RoleId;
            _Brokers._RoleName = deepCopy._RoleName;
            _Brokers._LoginID = deepCopy._LoginID;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.BrokersGroup_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(_Brokers._lstChargesCount);
            AppendStr(_Brokers._lstFeeTypeCount);
            AppendStr(_Brokers._lstSymbolCount);
            AppendStr(_Brokers._lstTaxTypeCount);
            AppendStr(_Brokers._lstTotalSymbolsCount);
            AppendStr(_Brokers._BrokerID);
            AppendStr(_Brokers._Name);
            AppendStr(_Brokers._Owner);
            AppendStr(_Brokers._Leverage);
            AppendStr(_Brokers._State);
            //AppendStr(_Brokers._BrokerName);
            //AppendStr(_Brokers._CompanyName);
            AppendStr(_Brokers._IsEnable);
            AppendStr(_Brokers._BrokerType);
            AppendStr(_Brokers._Address);
            AppendStr(_Brokers._City);
            AppendStr(_Brokers._Phone1);
            AppendStr(_Brokers._Phone2);
            AppendStr(_Brokers._Fax);
            AppendStr(_Brokers._EMail);
            AppendStr(_Brokers._MarginCallLevel1);
            AppendStr(_Brokers._MarginCallLevel2);
            AppendStr(_Brokers._MarginCallLevel3);
            AppendStr(_Brokers._News);
            AppendStr(_Brokers._MaximumOrders);
            AppendStr(_Brokers._Maximumsymbols);
            foreach (var item in _Brokers._lstSymbol)
            {
                AppendStr(item.SymbolID);
                AppendStr(item.SymbolName);
            }

            foreach (var tsymbols in _Brokers._lstTotalSymbols)
            {
                AppendStr(tsymbols.SymbolID);
                AppendStr(tsymbols.SymbolName);
            }

            foreach (var feeType in _Brokers._lstFeeType)
            {
                AppendStr(feeType);
            }

            foreach (var taxType in _Brokers._lstTaxType)
            {
                AppendStr(taxType);
            }

            foreach (var item2 in _Brokers._lstCharges)
            {
                AppendStr(item2.ChargesID);
                AppendStr(item2.BrokersGroupID);
                AppendStr(item2.SymbolID);
                AppendStr(item2.Symbol);
                AppendStr(item2.Fee);
                AppendStr(item2.FeeValue);
                AppendStr(item2.Tax);
                AppendStr(item2.TaxValue);
            }
            AppendStr(_Brokers._BrokerParent);
            AppendStr(_Brokers._Roles);
            AppendStr(_Brokers._RoleId); 
            AppendStr(_Brokers._RoleName);
            AppendStr(_Brokers._LoginID);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;
            _Brokers._lstChargesCount = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._lstFeeTypeCount = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._lstSymbolCount = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._lstTaxTypeCount = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._lstTotalSymbolsCount = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._BrokerID = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._Name = SpltString[++ind];
            _Brokers._Owner = SpltString[++ind];
            _Brokers._Leverage = SpltString[++ind];
            _Brokers._State = SpltString[++ind];
            //_Brokers._BrokerName = SpltString[++ind];
            //_Brokers._CompanyName = SpltString[++ind];
            _Brokers._IsEnable =Convert.ToBoolean( SpltString[++ind]);
            _Brokers._BrokerType = SpltString[++ind];
            _Brokers._Address = SpltString[++ind];
            _Brokers._City = SpltString[++ind];
            _Brokers._Phone1 = SpltString[++ind];
            _Brokers._Phone2 = SpltString[++ind];
            _Brokers._Fax = SpltString[++ind];
            _Brokers._EMail = SpltString[++ind];
            _Brokers._MarginCallLevel1 = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._MarginCallLevel2 = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._MarginCallLevel3 =clsUtility.GetInt( SpltString[++ind]);
            _Brokers._News = SpltString[++ind];
            _Brokers._MaximumOrders = SpltString[++ind];
            _Brokers._Maximumsymbols = SpltString[++ind];

            for (int i = 0; i < _Brokers._lstSymbolCount; i++)
            {
                BrokerSymbol objBrokerSymbol = new BrokerSymbol();
                objBrokerSymbol.SymbolID = clsUtility.GetInt(SpltString[++ind]);
                objBrokerSymbol.SymbolName = SpltString[++ind];

                _Brokers._lstSymbol.Add(objBrokerSymbol);
            }

            for (int i = 0; i < _Brokers._lstTotalSymbolsCount; i++)
            {
                BrokerSymbol objBrokerSymbol = new BrokerSymbol();
                objBrokerSymbol.SymbolID = clsUtility.GetInt(SpltString[++ind]);
                objBrokerSymbol.SymbolName = SpltString[++ind];

                _Brokers._lstTotalSymbols.Add(objBrokerSymbol);
            }

            for (int i = 0; i < _Brokers._lstFeeTypeCount; i++)
            {
                _Brokers._lstFeeType.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _Brokers._lstTaxTypeCount; i++)
            {
                _Brokers._lstTaxType.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _Brokers._lstChargesCount; i++)
            {
                charges objcharges = new charges();
                objcharges.ChargesID = clsUtility.GetInt(SpltString[++ind]);
                objcharges.BrokersGroupID = clsUtility.GetInt(SpltString[++ind]);
                objcharges.SymbolID = clsUtility.GetInt(SpltString[++ind]);
                objcharges.Symbol = SpltString[++ind];
                objcharges.Fee = SpltString[++ind];
                objcharges.FeeValue =clsUtility.GetInt(SpltString[++ind]);
                objcharges.Tax = SpltString[++ind];
                objcharges.TaxValue =clsUtility.GetDouble(SpltString[++ind]);

                _Brokers._lstCharges.Add(objcharges);
            }

            _Brokers._BrokerParent =clsUtility.GetInt(SpltString[++ind]);
            _Brokers._Roles = SpltString[++ind];
            _Brokers._RoleId = clsUtility.GetInt(SpltString[++ind]);
            _Brokers._RoleName = SpltString[++ind];
            _Brokers._LoginID = SpltString[++ind];
        }

        public override string ToString()
        {
            return _Brokers == null ? base.ToString() : _Brokers.ToString();
        }
    }
}
