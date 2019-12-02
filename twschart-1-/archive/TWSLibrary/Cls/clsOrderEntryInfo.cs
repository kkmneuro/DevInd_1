using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Cls
{
    public class ClsOrderEntryInfo
    {
        public string Side { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        //public string ClOrderId { get; set; }
        public string OrderType { get; set; }
        public string Symbol { get; set; }
        public string GatewayName { get; set; }
        public string ExpiryDate { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double StopPrice { get; set; }
        public string AccountType { get; set; }
        public string ClientName { get; set; }
        public string Client { get; set; }
        public string Validity { get; set; }
        public string UserRemark { get; set; }
        public double StopLoss { get; set; }
        public double TakeProfit { get; set; }
        public string CloseClOrdID { get; set; }
        public string CloseOrderID { get; set; }
    }
}
