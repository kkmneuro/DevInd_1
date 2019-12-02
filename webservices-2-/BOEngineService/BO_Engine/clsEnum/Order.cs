using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace clsInterface4OME
{
    /// <summary>
    /// Order is the triggering point of a successful transaction, and its values directly contribute to the
    /// overall functioning of the order-matching engine.
    /// </summary>
    [Serializable]
    public abstract class Order
    {
        protected static string delemeter = ":";
        public string Instrument;
        public Side BuySell;
        public OrderType OrderType;
        public double Price;
        public double SL;
        public double TP;
        private int quantity;
        public int InitialQuantity;
        public static long globalOrderId;
        long ServerOrderId;
        public OrderStatus orderStatus;
        public long ClientOrderID;
        public DateTime TimeStamp;
        public OrderRequestType RequestType;
        public TIF TimeInForce;
        public string AccountID;
        public DateTime GTD;
        //public enm4OMS OrderType4OMS;
        public long CancelOrModifyID;
        public long CloseOrderID;
        public long OrigClOrdID;
        public int LPID;
        public UserType AcntType;
        public bool IsATU =false;
        public Order()
        {
            //Generate Default Values
            //Global unique order ID
            //Order Time Stamp
            TimeStamp = DateTime.UtcNow;
            RequestType = OrderRequestType.NA;
            SL = 0;
            TP = 0;
            InitialQuantity = 0;
            orderStatus = OrderStatus.NOTVALID;
            GTD = DateTime.UtcNow;    //By default all orders is send fro Gool till day/
            AccountID = String.Empty;
            CloseOrderID = -1;
            OrigClOrdID = -1;
            LPID = -1;
            AcntType = UserType.Client;
            //OrderType4OMS = enm4OMS.NA;

        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    quantity = 0;
                else
                    quantity = value;
            }
        }

        public long ServerOrderID
        {
            get { return ServerOrderId; }
            set { ServerOrderId = value; }
        }

        public override string ToString()
        {            
            return
                 "AccountID=" + AccountID.ToString() + delemeter
                + "BuySell=" + BuySell.ToString() + delemeter
                + "CancelOrModifyID=" + CancelOrModifyID.ToString() + delemeter
                + "ClientOrderID=" + ClientOrderID.ToString() + delemeter
                + "CloseOrderID=" + CloseOrderID.ToString() + delemeter
                + "GTD=" + GTD.ToString() + delemeter
                + "InitialQty=" + InitialQuantity.ToString()
                + "Order:" + "Instrument=" + Instrument + delemeter
            + "orderStatus=" + orderStatus.ToString() + delemeter
            + "OrderType=" + OrderType.ToString() + delemeter
            + "OrigClOrdID=" + OrigClOrdID.ToString() + delemeter
            + "Price=" + Price.ToString() + delemeter
            + "quantity=" + quantity.ToString() + delemeter
            + "RequestType=" + RequestType.ToString() + delemeter
            + "ServerOrderId=" + ServerOrderId.ToString() + delemeter
            + "SL=" + SL.ToString() + delemeter
            + "TimeInForce=" + TimeInForce.ToString() + delemeter
            + "TimeStamp=" + TimeStamp.ToString() + delemeter
            + "TP=" + TP.ToString() + delemeter;

        }
    }
}
