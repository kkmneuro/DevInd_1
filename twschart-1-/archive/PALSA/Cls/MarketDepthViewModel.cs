using System;
using System.Collections.Generic;
using System.ComponentModel;
//using FundXchange.Domain.Entities;
//using FundXchange.Model.ViewModels.MarketDepth;

namespace PALSA.Cls
{
    public class MarketDepthViewModel
    {
        #region Types

        public class SymbolTable
        {
            public const int SYMBOL_COLUMN = 0;
            public const int BID_TICK_COLUMN = 1;
            public const int LAST_COLUMN = 2;
            public const int NET_CHANGE_COLUMN = 3;
            public const int OPEN_COLUMN = 4;
            public const int HIGH_COLUMN = 5;
            public const int LOW_COLUMN = 6;
            public const int CLOSE_COLUMN = 7;
            public const int TRADE_SIZE_COLUMN = 8;
            public const int PRICE_INTERVALS_COLUMN = 9;
        }

        #endregion

        #region Public Properties

        //public Instrument Instrument { get; internal set; }
        //public List<Instrument> SymbolWatchList { get; set; }

        public List<Order> BuyOrders { get; internal set; }
        public List<Order> SellOrders { get; internal set; }
        public List<BidOfferBase> Bids { get; internal set; }
        public List<BidOfferBase> Offers { get; internal set; }
        public BindingList<BidOfferCross> BidOfferCrossBinding { get; internal set; }

        #endregion

        #region Constructors

        public MarketDepthViewModel()
        {
            //Instrument = new Instrument();
            //SymbolWatchList = new List<Instrument>();
            BuyOrders = new List<Order>();
            SellOrders = new List<Order>();
            Bids = new List<BidOfferBase>();
            Offers = new List<BidOfferBase>();
            BidOfferCrossBinding = new BindingList<BidOfferCross>();
        }

        #endregion
    }

    public class Instrument
    {
        public string Symbol { get; set; }
        public string ISIN { get; set; }
        public string Exchange { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyLongName { get; set; }
        public double CentsMoved { get; set; }
        //public long LastTrade { get; set; }
        public double LastTrade { get; set; }
        public DateTime LastTradeTime { get; set; }
        public long LastTradeSequenceNumber { get; set; }
        //public long High { get; set; }
        //public long Low { get; set; }
        //public long Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        //public long BestBid { get; set; }
        public double BestBid { get; set; }
        public long BidVolume { get; set; }
        //public long BestOffer { get; set; }
        public double BestOffer { get; set; }
        public long OfferVolume { get; set; }
        public double PercentageMoved { get; set; }
        public long TotalTrades { get; set; }
        //public long TotalValue { get; set; }
        public double TotalValue { get; set; }
        public long TotalVolume { get; set; }
        public double YesterdayClose { get; set; }
        //public long YesterdayClose { get; set; }
        public bool IsIndex { get; set; }
        public int TickSize { get; set; }

        public List<BidOfferBase> Bids { get; set; }
        public List<BidOfferBase> Offers { get; set; }
        public List<Order> Orders { get; set; }
        //public List<Trade> Trades { get; private set; }
        //public List<Quote> Quotes { get; private set; }

        public Instrument()
        {
            //Trades = new List<Trade>();
            Bids = new List<BidOfferBase>();
            Offers = new List<BidOfferBase>();
            Orders = new List<Order>();
            //Quotes = new List<Quote>();
        }

        //public void AddTrade(Trade trade)
        //{
            //Trades.Add(trade);

            //TotalValue += (trade.Volume * trade.Price);
            //TotalValue += trade.Volume;
            //LastTrade = trade.Price;
            //TotalTrades++;
        //}

        //public void AddQuote(Quote quote)
        //{
        //    Quotes.Add(quote);

        //    BestBid = quote.BestBidPrice;
        //    BidVolume = quote.BestBidSize;
        //    BestOffer = quote.BestAskPrice;
        //    OfferVolume = quote.BestAskSize;
        //}

        public override bool Equals(object obj)
        {
            if (obj is Instrument)
            {
                return this.Symbol == (obj as Instrument).Symbol && this.Exchange == (obj as Instrument).Exchange;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ISIN.GetHashCode();
        }
    }

    public class BidOfferBase //: InstrumentBase
    {
        public double Price { get; set; }
        public long Size { get; set; }
        public int OrderCount { get; set; }
    }

    public enum OrderSide
    {
        Buy,
        Sell
    }

    public class Order : INotifyPropertyChanged
    {
        private string id;
        private double price;
        private long volume;
        private DateTime time;
        private OrderSide side;

        public long SequenceNumber { get; set; }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value != this.price)
                {
                    this.price = value;
                    NotifyPropertyChanged("Price");
                }
            }
        }
        public long Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                if (value != this.volume)
                {
                    this.volume = value;
                    NotifyPropertyChanged("Volume");
                }
            }
        }
        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
                NotifyPropertyChanged("Time");
            }
        }
        public OrderSide Side
        {
            get
            {
                return this.side;
            }
            set
            {
                this.side = value;
                NotifyPropertyChanged("Side");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
