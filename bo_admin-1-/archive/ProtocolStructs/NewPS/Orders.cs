using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class Orders
    {
        public int    _AccountID;
        public int    _OrderID;
        public DateTime _Time;
        public string _Type;
        public int    _Quantity;
        public string _SymbolID;
        public string _OrderType;
        public string _OrderPrice;
        public string _TriggerPrice;
        public string _Comment;
        public string _Status;
        public DateTime _Validity;
        public string _BrokerName;
        public int   _Volume;
        public int   _FilledQuantity;
        public int   _LeaveQuantity;
        public int   _AvgFillPrice;

        public Orders()
        {
            _AccountID= 0;
            _OrderID= 0;
            _Time = DateTime.Today;
            _Type= string.Empty;
            _Quantity= 0;
            _SymbolID = string.Empty;
            _OrderType= string.Empty;
            _OrderPrice= string.Empty;
            _TriggerPrice= string.Empty;
            _Comment= string.Empty;
            _Status= string.Empty;
            _Validity = DateTime.Today;
            _BrokerName = string.Empty;
            _Volume = 0;
            _FilledQuantity = 0;
            _LeaveQuantity = 0;
            _AvgFillPrice = 0;

        }

        public override string ToString()
        {
            return

            "_AccountID->" + _AccountID +
            "_OrderID->" + _OrderID +
            "_Time->" + _Time +
            "_Type->" + _Type +
            "_Quantity->" + _Quantity +
            "_SymbolID->" + _SymbolID +
            "_OrderType->" + _OrderType +
            "_OrderPrice->" + _OrderPrice +
            "_TriggerPrice->" + _TriggerPrice +
            "_Comment->" + _Comment +
            "_Status->" + _Status +
            "_Validity->" + _Validity +
            "_BrokerName->" + _BrokerName +
            "_Volume->" + _Volume +
            "_FilledQuantity->" + _FilledQuantity +
            "_LeaveQuantity->" + _LeaveQuantity +
            "_AvgFillPRice->" + _AvgFillPrice;
   
        }
    }
}
