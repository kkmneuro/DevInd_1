using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class TradingGatewayPS : IProtocolStruct
    {
        public TradingGateway _TradingGatway;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public TradingGatewayPS()
        {
            _TradingGatway = new TradingGateway();
        }
        public TradingGatewayPS(TradingGateway deepCopy)
        {

            _TradingGatway._PK_TradingGateWaysID = deepCopy._PK_TradingGateWaysID;
            _TradingGatway._Name = deepCopy._Name;
            _TradingGatway._Description = deepCopy._Description;
            _TradingGatway._Server_IP = deepCopy._Server_IP;
            _TradingGatway._Port = deepCopy._Port;
            _TradingGatway._DataType = deepCopy._DataType;
            _TradingGatway._Login = deepCopy._Login;
            _TradingGatway._Password = deepCopy._Password;
            _TradingGatway._IdleTimeOut = deepCopy._IdleTimeOut;
            _TradingGatway._ReconnectAfter = deepCopy._ReconnectAfter;
            _TradingGatway._SleepFor = deepCopy._SleepFor;
            _TradingGatway._Attempts = deepCopy._Attempts;
            _TradingGatway._IsEnable = deepCopy._IsEnable;
            _TradingGatway._lstSymbol = deepCopy._lstSymbol;
            _TradingGatway._lstSymbolAlias      =deepCopy._lstSymbolAlias;
            _TradingGatway._lstTotalSymbol      = deepCopy._lstTotalSymbol;
            _TradingGatway._lstSymbolCount      = deepCopy._lstSymbolCount;
            _TradingGatway._lstSymbolAliasCount = deepCopy._lstSymbolAliasCount;
            _TradingGatway._lstTotalSymbolCount = deepCopy._lstTotalSymbolCount;
            _TradingGatway._enableRMS = deepCopy._enableRMS;
            _TradingGatway._orderPort = deepCopy._orderPort;
            _TradingGatway._lstSymbolConversionFormula = deepCopy._lstSymbolConversionFormula;
            _TradingGatway._lstSymbolConversionFormulaCount = deepCopy._lstSymbolConversionFormulaCount;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.TradingGateway_ID; }
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
            AppendStr(_TradingGatway._PK_TradingGateWaysID);
            AppendStr(_TradingGatway._Name);
            AppendStr(_TradingGatway._Description);
            AppendStr(_TradingGatway._Server_IP);
            AppendStr(_TradingGatway._Port);
            AppendStr(_TradingGatway._DataType);
            AppendStr(_TradingGatway._Login);
            AppendStr(_TradingGatway._Password);
            AppendStr(_TradingGatway._IdleTimeOut);
            AppendStr(_TradingGatway._ReconnectAfter);
            AppendStr(_TradingGatway._SleepFor);
            AppendStr(_TradingGatway._Attempts);
            AppendStr(_TradingGatway._IsEnable);
            AppendStr(_TradingGatway._lstSymbol.Count); 

            foreach (var item in _TradingGatway._lstSymbol)
            {
                AppendStr(item);
            }
            AppendStr(_TradingGatway._lstSymbolAlias.Count); 
            foreach (var item in _TradingGatway._lstSymbolAlias)
            {
                AppendStr(item);
            }
            AppendStr(_TradingGatway._lstTotalSymbol.Count); 
            foreach (var item in _TradingGatway._lstTotalSymbol)
			{
			 AppendStr(item);
			}
            AppendStr(_TradingGatway._enableRMS);
            AppendStr(_TradingGatway._orderPort);

            AppendStr(_TradingGatway._lstSymbolConversionFormula.Count);
            foreach (var item in _TradingGatway._lstSymbolConversionFormula)
            {
                AppendStr(item);
            }

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _TradingGatway._PK_TradingGateWaysID = clsUtility.GetInt(SpltString[++ind]);
            _TradingGatway._Name = SpltString[++ind];
            _TradingGatway._Description = SpltString[++ind];
            _TradingGatway._Server_IP = SpltString[++ind];
            _TradingGatway._Port = SpltString[++ind];
            _TradingGatway._DataType = SpltString[++ind];
            _TradingGatway._Login = SpltString[++ind];
            _TradingGatway._Password = SpltString[++ind];
            _TradingGatway._IdleTimeOut = clsUtility.GetInt(SpltString[++ind]);
            _TradingGatway._ReconnectAfter = clsUtility.GetInt(SpltString[++ind]);
            _TradingGatway._SleepFor = clsUtility.GetInt(SpltString[++ind]);
            _TradingGatway._Attempts = clsUtility.GetInt(SpltString[++ind]);
            _TradingGatway._IsEnable = Convert.ToBoolean(SpltString[++ind]);
            _TradingGatway._lstSymbolCount = clsUtility.GetInt(SpltString[++ind]);

            for (int i = 0; i < _TradingGatway._lstSymbolCount; i++)
            {
                _TradingGatway._lstSymbol.Add(SpltString[++ind]);
            }
            _TradingGatway._lstSymbolAliasCount = clsUtility.GetInt(SpltString[++ind]);
            for (int i = 0; i < _TradingGatway._lstSymbolAliasCount; i++)
            {
                _TradingGatway._lstSymbolAlias.Add(SpltString[++ind]);
            }
            _TradingGatway._lstTotalSymbolCount = clsUtility.GetInt(SpltString[++ind]);
            for (int i = 0; i < _TradingGatway._lstTotalSymbolCount; i++)
            {
                _TradingGatway._lstTotalSymbol.Add(SpltString[++ind]);
            }
            _TradingGatway._enableRMS = Convert.ToBoolean(SpltString[++ind]);
            _TradingGatway._orderPort = Convert.ToInt32(SpltString[++ind]);

            _TradingGatway._lstSymbolConversionFormulaCount = Convert.ToInt32(SpltString[++ind]);

            for (int i = 0; i < _TradingGatway._lstSymbolConversionFormulaCount; i++)
            {
                _TradingGatway._lstSymbolConversionFormula.Add(clsUtility.GetDecimal(SpltString[++ind]));
            }
        }
        public override string ToString()
        {
            return _TradingGatway == null ? base.ToString() : _TradingGatway.ToString();
        }


        public override bool ValidateData()
        {
            base.ValidateData();

            Add2Vld("PK_TradingGateWaysID", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty( _TradingGatway._PK_TradingGateWaysID.ToString()));
            Add2Vld("Name", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._Name.ToString()));
            Add2Vld("Description", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._Description.ToString()));
            Add2Vld("Server_IP", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._Server_IP.ToString()));
            Add2Vld("Port", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._Port.ToString()));
            Add2Vld("DataType", clsInterface4OME.clsUtil4ProtoVali.ValidateIPPort(_TradingGatway._DataType.ToString()));
            Add2Vld("Login", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger( _TradingGatway._Login.ToString()));
            Add2Vld("Password", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_TradingGatway._Password.ToString()));
            Add2Vld("IdleTimeOut", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_TradingGatway._IdleTimeOut.ToString()));
            Add2Vld("ReconnectAfter", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._ReconnectAfter.ToString()));
            Add2Vld("SleepFor", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_TradingGatway._SleepFor.ToString()));
            Add2Vld("Attempts", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger( _TradingGatway._Attempts.ToString()));
            Add2Vld("IsEnable", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_TradingGatway._IsEnable.ToString()));
            return IsValidlist();                                                               
        }
    }
}
 

