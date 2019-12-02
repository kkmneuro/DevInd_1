using System;
//using FundXchange.Orders.FX_OrderService;

namespace PALSA.ClsMatrix
{
    public class OrderManagerItem
    {
        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public string OrderId { get; set; }
        public int Entry { get; set; }
        public int TriggerPrice { get; set; }
        public int StopLossPrice { get; set; }
        public int CancelPrice { get; set; }
        public int Quantity { get; set; }
        public int LastTrade { get; set; }
        public int Bid { get; set; }
        public int Offer { get; set; }
        public DateTime Time { get; set; }
        //public OrderSide Side { get; set; }
        public string PriceType { get; set; }
        //public OrderStatusses OrderStatus { get; set; }
        public string OrderType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? OrderDate { get; set; }

        public int ProfitLoss
        {
            get
            {
                return (Entry - LastTrade) * Quantity;
            }
        }

        public decimal PercentageGain
        {
            get
            {
                int diff = Entry - LastTrade;
                decimal percentMove = 0;
                if (Entry > 0)
                    percentMove = ((decimal)diff * 100) / Entry;
                percentMove = decimal.Round(percentMove, 2);
                return percentMove;
            }
        }
    }
}
