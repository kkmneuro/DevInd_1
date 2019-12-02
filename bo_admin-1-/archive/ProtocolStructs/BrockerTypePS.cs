using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs
{
    public class BrokerTypePS : IProtocolStruct
    {

        public BrokerType _BrType;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public BrokerTypePS()
        {
            _BrType = new BrokerType();
        }

        public BrokerTypePS(BrokerType deepCopy)
        {
            _BrType._BrokerType = deepCopy._BrokerType;
            _BrType._BrokerTypesID = deepCopy._BrokerTypesID;
            _BrType._Description = deepCopy._Description;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.Broker_ID; }
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

            AppendStr(_BrType._BrokerType);
            AppendStr(_BrType._BrokerTypesID);
            AppendStr(_BrType._Description);

            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _BrType._BrokerType = SpltString[++ind];
            _BrType._BrokerTypesID = clsUtility.GetInt(SpltString[++ind]);
            _BrType._Description = SpltString[++ind];
            

        }
        public override string ToString()
        {
            return _BrType == null ? base.ToString() : _BrType.ToString();
        }
    }
}
