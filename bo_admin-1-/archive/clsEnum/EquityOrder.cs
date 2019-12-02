using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace clsInterface4OME
{
    /// <summary>
    /// This class allows the further augmentation of an order by allowing annotation of additional
    /// information that is applicable only in an equities market.
    /// </summary>
    [Serializable]
    public class EquityOrder : Order
    {
       
        public EquityOrder()
        {
            ServerOrderID = Interlocked.Increment(ref globalOrderId);
            

        }
        public EquityOrder(string instrument, OrderType orderType,
            Side buySell, double price, int quantity)
            : base()
        {
            this.Instrument = instrument;
            this.OrderType = orderType;
            this.BuySell = buySell;
            this.Price = price;
            this.Quantity = quantity;

        }
        public EquityOrder(string instrument, OrderType orderType,
           Side buySell, double price, int quantity, double SL, double TP)
            : base()
        {
            this.Instrument = instrument;
            this.OrderType = orderType;
            this.BuySell = buySell;
            this.Price = price;
            this.Quantity = quantity;
            this.SL = SL;
            this.TP = TP;

        }


    }
}
