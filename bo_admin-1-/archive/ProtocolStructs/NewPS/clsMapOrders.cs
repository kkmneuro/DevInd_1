using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class clsMapOrders
    {
        public int _MapOrderId;
        public int _BuyAccountID;
        public int _SellAccountID;
        public Int64 _BuySideOrderID;
        public Int64 _SellSideOrderID;
        public int _BuyFillID;
        public int _SellFillID;
        public int _FilledQty;
        public DateTime _LastUpdateTime;
        public decimal _Price;
        public string _Symbol;

        public clsMapOrders()
        {
            _MapOrderId = 0;
            _BuyAccountID = 0;
            _SellAccountID = 0;
            _BuySideOrderID = 0;
            _SellSideOrderID = 0;
            _BuyFillID = 0;
            _SellFillID = 0;
            _FilledQty = 0;
            _LastUpdateTime = DateTime.Now;
            _Price = 0;
            _Symbol = string.Empty;
        }
        public override string ToString()
        {
            return
            "_MapOrderId->" + _MapOrderId +
            "_BuyAccountID->" + _BuyAccountID +
            "_SellAccountID->" + _SellAccountID +
            "_BuySideOrderID->" + _BuySideOrderID +
            "_SellSideOrderID->" + _SellSideOrderID +
            "_BuyFillID->" + _BuyFillID +
            "_SellFillID->" + _SellFillID +
            "_FilledQty->" + _FilledQty +
            "_LastUpdateTime->" + _LastUpdateTime +
            "_Price" + _Price +
            "_Symbol" + _Symbol;
        }
    }
}
