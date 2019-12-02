using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using clsInterface4OME;

namespace clsInterface4OME
{
    public class OrderStatusReport:Order
    {
        public OrderStatusReport()
        {            
            
        }
        public OrderStatusReport(Order ord):base()
        {
            this.BuySell = ord.BuySell;
            this.ClientOrderID = ord.ClientOrderID;
            this.ExecID = Interlocked.Increment(ref globalReportID); //ord.OrderID;
            this.Instrument = ord.Instrument;
            this.ServerOrderID = ord.ServerOrderID;
            this.orderStatus = ord.orderStatus;
            this.OrderType = ord.OrderType;
            this.Price = ord.Price;

            this.SL = ord.SL;
            this.TP = ord.TP;
            this.AccountID = ord.AccountID;
            this.Quantity = ord.Quantity;
            this.Reason = Reason.NA;
            this.RequestType = ord.RequestType;
            this.TimeStamp = DateTime.UtcNow;
            this.TimeInForce = ord.TimeInForce;
            this.GTD = ord.GTD;
            this.CancelOrModifyID = ord.CancelOrModifyID;
            this.CloseOrderID = ord.CloseOrderID;
            this.AcntType = ord.AcntType;
            this.InitialQuantity= ord.InitialQuantity; 
        }
       
        public override string ToString()
        {
            string temp = String.Empty;

            temp += base.ToString() + delemeter + globalReportID + delemeter + ExecID + delemeter + Reason;

            return temp;
        }

        public static long globalReportID;
       
        public long ExecID;
      
        public Reason Reason;

       
    }
}
