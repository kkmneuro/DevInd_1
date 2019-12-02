using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class OrdersPS : IProtocolStruct
    {
        
        public Orders _Order;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public OrdersPS()
        {
            _Order = new Orders();
        }

        public OrdersPS(Orders deepCopy)
        {
             _Order._AccountID = deepCopy._AccountID;
             _Order._OrderID = deepCopy._OrderID;
             _Order._Time = deepCopy._Time;
             _Order._Type = deepCopy._Type;
             _Order._Quantity = deepCopy._Quantity;
             _Order._SymbolID = deepCopy._SymbolID;
             _Order._OrderType = deepCopy._OrderType;
             _Order._OrderPrice = deepCopy._OrderPrice;
             _Order._TriggerPrice = deepCopy._TriggerPrice;
             _Order._Comment = deepCopy._Comment;
             _Order._Status = deepCopy._Status;
             _Order._Validity = deepCopy._Validity;
             _Order._BrokerName = deepCopy._BrokerName;
             _Order._Volume = deepCopy._Volume;
             _Order._FilledQuantity = deepCopy._FilledQuantity;
             _Order._LeaveQuantity = deepCopy._LeaveQuantity;
             _Order._AvgFillPrice = deepCopy._AvgFillPrice;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.Order_ID; }
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

            AppendStr(_Order._AccountID);
            AppendStr(_Order._OrderID);
            AppendStr(_Order._Time);
            AppendStr(_Order._Type);
            AppendStr(_Order._Quantity);
            AppendStr(_Order._SymbolID);
            AppendStr(_Order._OrderType);
            AppendStr(_Order._OrderPrice);
            AppendStr(_Order._TriggerPrice);
            AppendStr(_Order._Comment);
            AppendStr(_Order._Status);
            AppendStr(_Order._Validity);
            AppendStr(_Order._BrokerName);
            AppendStr(_Order._Volume);
            AppendStr(_Order._FilledQuantity);
            AppendStr(_Order._LeaveQuantity);
            AppendStr(_Order._AvgFillPrice);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;

            _Order._AccountID = clsUtility.GetInt(SpltString[++ind]);
            _Order._OrderID = clsUtility.GetInt(SpltString[++ind]);
            _Order._Time = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Order._Type = SpltString[++ind];
            _Order._Quantity = clsUtility.GetInt(SpltString[++ind]);
            _Order._SymbolID = SpltString[++ind];
            _Order._OrderType = SpltString[++ind];
            _Order._OrderPrice = SpltString[++ind];
            _Order._TriggerPrice = SpltString[++ind];
            _Order._Comment = SpltString[++ind];
            _Order._Status = SpltString[++ind];
            _Order._Validity = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Order._BrokerName = SpltString[++ind];
            _Order._Volume = clsUtility.GetInt(SpltString[++ind]);
            _Order._FilledQuantity = clsUtility.GetInt(SpltString[++ind]);
            _Order._LeaveQuantity = clsUtility.GetInt(SpltString[++ind]);
            _Order._AvgFillPrice = clsUtility.GetInt(SpltString[++ind]);

        }

        public override string ToString()
        {
            return _Order == null ? base.ToString() : _Order.ToString();
        }

    }
}
