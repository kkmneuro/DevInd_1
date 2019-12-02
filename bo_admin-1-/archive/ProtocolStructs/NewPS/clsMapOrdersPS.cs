using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class clsMapOrdersPS : IProtocolStruct
    {
        public clsMapOrders _MapOrders;

        public clsMapOrdersPS()
        {
            _MapOrders = new clsMapOrders();
        }

        public clsMapOrdersPS(clsMapOrders deepCopy)
        {
            _MapOrders._MapOrderId = deepCopy._MapOrderId;
            _MapOrders._BuyAccountID = deepCopy._BuyAccountID;
            _MapOrders._SellAccountID = deepCopy._SellAccountID;
            _MapOrders._BuySideOrderID = deepCopy._BuySideOrderID;
            _MapOrders._SellSideOrderID = deepCopy._SellSideOrderID;
            _MapOrders._BuyFillID = deepCopy._BuyFillID;
            _MapOrders._SellFillID = deepCopy._SellFillID;
            _MapOrders._FilledQty = deepCopy._FilledQty;
            _MapOrders._LastUpdateTime = deepCopy._LastUpdateTime;
            _MapOrders._Price = deepCopy._Price;
            _MapOrders._Symbol = deepCopy._Symbol;
        }

        public override int ID
        {
            get { return ProtocolStructIDS.MapOrders_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {

        }

        public override void StartRead(byte[] buffer)
        {

        }

        public override void WriteString()
        {
            StartStrW();
            AppendStr(_MapOrders._MapOrderId);
            AppendStr(_MapOrders._BuyAccountID);
            AppendStr(_MapOrders._SellAccountID);
            AppendStr(_MapOrders._BuySideOrderID);
            AppendStr(_MapOrders._SellSideOrderID);
            AppendStr(_MapOrders._BuyFillID);
            AppendStr(_MapOrders._SellFillID);
            AppendStr(_MapOrders._FilledQty);
            AppendStr(_MapOrders._LastUpdateTime);
            AppendStr(_MapOrders._Price);
            AppendStr(_MapOrders._Symbol);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;

            _MapOrders._MapOrderId = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._BuyAccountID = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._SellAccountID = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._BuySideOrderID = clsUtility.GetLong(SpltString[++ind]);
            _MapOrders._SellSideOrderID = clsUtility.GetLong(SpltString[++ind]);
            _MapOrders._BuyFillID = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._SellFillID = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._FilledQty = clsUtility.GetInt(SpltString[++ind]);
            _MapOrders._LastUpdateTime = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _MapOrders._Price = clsUtility.GetDecimal(SpltString[++ind]);
            _MapOrders._Symbol = clsUtility.GetStr(SpltString[++ind]);
        }
    }
}
