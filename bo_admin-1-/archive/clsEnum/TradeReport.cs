using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace clsInterface4OME
{
    public class TradeReport
    {
        public TradeReport()
        {
            TradeID = Interlocked.Increment(ref TradeUniqueID);
        }
        public TradeReport(bool IsIncrement)
        {
            TradeTime = DateTime.UtcNow;
            //if (IsIncrement == true)
            //{

            //}
        }
        public TradeReport(TradeReport _trade)
        {
            this.BuyClientOrderID = _trade.BuyClientOrderID;
            this.BuyOrderStatus = _trade.BuyOrderStatus;
            this.BuyRequestType = _trade.BuyRequestType;
            this.BuyServerOrderID = _trade.BuyServerOrderID;
            this.CloseOrderID4Buy = _trade.CloseOrderID4Buy;
            this.CloseOrderID4Sell = _trade.CloseOrderID4Sell;
            this.Instrument = _trade.Instrument;
            this.Price = _trade.Price;
            this.Quantity = _trade.Quantity;
            this.SellClientOrderID = _trade.SellClientOrderID;
            this.SellOrderStatus = _trade.SellOrderStatus;
            this.SellRequestType = _trade.SellRequestType;
            this.SellServerOrderID = _trade.SellServerOrderID;
            this.TradeID = _trade.TradeID;
            this.BuyInitialQuantity = _trade.BuyInitialQuantity;
            this.SellInitialQuantity = _trade.SellInitialQuantity;
            this.TradeTime = _trade.TradeTime;
        }

        static string delemter = ":";

        public static long TradeUniqueID;

        public long TradeID;
        public long BuyServerOrderID;
        public long BuyClientOrderID;
        public long SellServerOrderID;
        public long SellClientOrderID;
        public double Price;
        public int Quantity;
        public int BuyInitialQuantity;
        public int SellInitialQuantity;
        public string Instrument;
        public TradeStatus BuyOrderStatus;
        public TradeStatus SellOrderStatus;
        public OrderRequestType BuyRequestType;
        public OrderRequestType SellRequestType;
        public long CloseOrderID4Buy;
        public long CloseOrderID4Sell;
        public DateTime TradeTime;

        public double BuyUsedMargin;
        public double BuyClosePnl;
        public double SellUsedMargin;
        public double SellClosedPnl;


        public override string ToString()
        {
            return
            "BuyClientOrderID = " + this.BuyClientOrderID + delemter +
            "BuyClosePnl = " + this.BuyClosePnl + delemter +
            "BuyInitialQuantity = " + this.BuyInitialQuantity + delemter +
            "BuyOrderStatus = " + this.BuyOrderStatus + delemter +
            "BuyRequestType = " + this.BuyRequestType + delemter +
            "BuyServerOrderID =" + this.BuyServerOrderID + delemter +
            "BuyUsedMargin = " + this.BuyUsedMargin + delemter +
            "CloseOrderID4Buy = " + this.CloseOrderID4Buy + delemter +
            "CloseOrderID4Sell = " + this.CloseOrderID4Sell + delemter +
            "Instrument = " + this.Instrument + delemter +
            "Price = " + this.Price + delemter +
            "Quantity = " + this.Quantity + delemter +
            "SellClientOrderID = " + this.SellClientOrderID + delemter +
            "SellClosedPnl = " + this.SellClosedPnl + delemter +
            "SellInitialQuantity = " + this.SellInitialQuantity + delemter +
            "SellOrderStatus = " + this.SellOrderStatus + delemter +
            "SellRequestType = " + this.SellRequestType + delemter +
            "SellServerOrderID = " + this.SellServerOrderID + delemter +
            "SellUsedMargin = " + this.SellUsedMargin + delemter +
            "Trade Report:TradeID = " + this.TradeID + delemter +
            "TradeTime = " + this.TradeTime + delemter;
        }

    }
}
