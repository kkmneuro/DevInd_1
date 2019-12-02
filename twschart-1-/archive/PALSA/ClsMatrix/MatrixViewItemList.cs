using System;
using System.Collections.Generic;
using System.Linq;
//using FundXchange.Domain.ValueObjects;
//using FundXchange.Domain.Entities;
//using FundXchange.Model.Agents;
using System.Drawing;
using PALSA.Cls;
//using FundXchange.Domain.Enumerations;

namespace PALSA.ClsMatrix
{
    public delegate void MatrixViewItemChangedDelegate(List<MatrixViewItem> items);

    public interface IMatrixViewItemList
    {
        event MatrixViewItemChangedDelegate ItemsAdded;
        event MatrixViewItemChangedDelegate ItemsUpdated;
        event MatrixViewItemChangedDelegate ItemsRemoved;
        event MatrixViewItemChangedDelegate DepthInitialized;
        event Action<MatrixViewItem> OnLTPOccurred;
        //void AddInstrument(Instrument instrument);
        void AddInstrumentNew(double High, double Low);
        void AddDefaultValues();
        //void AddTrades(List<Trade> trades);//Kul
        void InitializeDepth(List<DepthByPrice> bids, List<DepthByPrice> offers);
        void InitializeDepthNew(DepthByPrice Depth, bool IsBuy);
        void UpdateDepth(DepthByPrice depth, bool isBuy);
        void RemoveDepth(double price, bool isBuy);
        void ClearItems();
        long GetTotalTradeVolume();
        long GetTotalBidSize();
        long GetTotalOfferSize();
        IList<MatrixViewItem> GetItems();
        void ProcessLTP(List<QuoteItem> List);
    }
    public class MatrixViewItemList : SortedList<double, MatrixViewItem>, IMatrixViewItemList
    {
        public event MatrixViewItemChangedDelegate ItemsAdded;
        public event MatrixViewItemChangedDelegate ItemsUpdated;
        public event MatrixViewItemChangedDelegate ItemsRemoved;
        public event MatrixViewItemChangedDelegate DepthInitialized;
        public event Action<MatrixViewItem> OnLTPOccurred;
        private double _highPrice = -1;
        private double _lowPrice = -1;
        private double _lastTrade = -1;
        private long _totalTradeVolume = 0;
        private long _totalBidSize = 0;
        private long _totalOfferSize = 0;
        private bool _instrumentAdded;
        //private DateTime currentTime = DateTime.UtcNow.AddHours(2);
        private DateTime currentTime = new DateTime(DateTime.UtcNow.AddHours(2).Year, DateTime.UtcNow.AddHours(2).Month, DateTime.UtcNow.AddHours(2).Day, 9, 15, 0);
        public static Color OutOfRangeColor = Color.Gray;
        private Dictionary<int, double> _dicLvlPrc = new Dictionary<int, double>();

        public long GetTotalTradeVolume()
        {
            return _totalTradeVolume;
        }
        public long GetTotalBidSize()
        {
            return _totalBidSize;
        }
        public long GetTotalOfferSize()
        {
            return _totalOfferSize;
        }


        public void AddInstrumentNew(double High, double Low)
        {
            if (_instrumentAdded)
                throw new ApplicationException("Instrument already added to this list.");
            if (High != 0 && Low != 0)
            {
                var itemsAdded = new List<MatrixViewItem>();
                var itemsUpdated = new List<MatrixViewItem>();
                _totalTradeVolume = 0;
                _totalBidSize = 0;
                _totalOfferSize = 0;
                AddUpdateDefaultPrice(High, ref itemsAdded, ref itemsUpdated,"HIGH");
                AddUpdateDefaultPrice(Low, ref itemsAdded, ref itemsUpdated, "LOW");
                _highPrice = High;
                _lowPrice = Low;
                _instrumentAdded = true;
                RaiseItemsAdded(itemsAdded);
                //KukRaiseItemsUpdated(itemsUpdated);
            }
        }

        //public void AddInstrument(Instrument instrument)
        //{
        //    if (_instrumentAdded)
        //        throw new ApplicationException("Instrument already added to this list.");

        //    if (instrument != null)
        //    {
        //        var itemsAdded = new List<MatrixViewItem>();
        //        var itemsUpdated = new List<MatrixViewItem>();
        //        _totalTradeVolume = 0;
        //        _totalBidSize = 0;
        //        _totalOfferSize = 0;
        //        //AddUpdateDefaultPrice(instrument.Open, ref itemsAdded, ref itemsUpdated);
        //        //AddUpdateDefaultPrice(instrument.YesterdayClose, ref itemsAdded, ref itemsUpdated);
        //        //AddUpdateDefaultPrice(instrument.High, ref itemsAdded, ref itemsUpdated);
        //        //AddUpdateDefaultPrice(instrument.Low, ref itemsAdded, ref itemsUpdated);
        //        //AddUpdateDefaultPrice(instrument.LastTrade, ref itemsAdded, ref itemsUpdated);

        //        _highPrice = instrument.High;
        //        _lowPrice = instrument.Low;
        //        _instrumentAdded = true;

        //        RaiseItemsAdded(itemsAdded);
        //        RaiseItemsUpdated(itemsUpdated);
        //    }
        //}

        private void RaiseItemsAdded(List<MatrixViewItem> items)
        {
            if (items.Count > 0)
            {
                if (ItemsAdded != null)
                    ItemsAdded(items);
            }
        }

        private void RaiseItemsUpdated(List<MatrixViewItem> items)
        {
            if (items.Count > 0)
            {
                if (ItemsUpdated != null)
                    ItemsUpdated(items);
            }
        }

        private void AddUpdateDefaultPrice(double price, ref List<MatrixViewItem> itemsAdded, ref List<MatrixViewItem> itemsUpdated,string highlow)
        {
            if (!this.ContainsKey(price))
            {
                MatrixViewItem item = new MatrixViewItem();
                item.Price = price;
                if (highlow == "HIGH")
                    item.MktLvl = 200;//By Kuldeep
                else
                    item.MktLvl = 100;
                this.Add(price, item);
                itemsAdded.Add(item);
            }
            else
            {
                itemsUpdated.Add(this[price]);
            }
        }
        public void ProcessLTP(List<QuoteItem> List)//By Kuldeep
        {
            QuoteItem LAST = List.Find(x => x._quoteType == QuoteStreamType.LAST);
            if (LAST != null)
            {
                LAST._Time = DateTime.UtcNow.ToString();
                if (!this.ContainsKey(LAST._Price))
                {
                    
                    var item = new MatrixViewItem { Price = LAST._Price, TradeVolume = LAST._Size, TimeTradeVolume = new List<long>() };

                    QuoteItem BID = List.Find(x => x._quoteType == QuoteStreamType.BID);
                    QuoteItem ASK = List.Find(x => x._quoteType == QuoteStreamType.ASK);
                    if (BID != null && ASK != null)
                    {
                        if (LAST._Price == BID._Price)
                            item.TradeAtBidSize += BID._Size;
                        else if(LAST._Price==ASK._Price)
                            item.TradeAtOfferSize += ASK._Size;
                        else
                            item.TradeAtBetSize += LAST._Size;
                    }
                    else
                    {
                        item.TradeAtBetSize += LAST._Size;//To show that trade is between Bid/Offer
                    }
                    if (Convert.ToDateTime(LAST._Time) <= currentTime)
                    {
                        item.TimeTradeVolume.Add(LAST._Size);
                    }
                    else
                    {
                        int n = ((int)(Convert.ToDateTime(LAST._Time) - currentTime).TotalMinutes / 15) + 1;
                        for (int i = 0; i < n; i++)
                        {
                            item.TimeTradeVolume.Add(0);
                        }
                        item.TimeTradeVolume.Add(LAST._Size);
                    }
                    _totalTradeVolume += LAST._Size;
                    //this.Add(trade.Price, item);
                    UpdateOutOfRangeColor(item);
                    //Fire Here to Handle the LTP
                    if (OnLTPOccurred != null)
                        OnLTPOccurred(item);
                }
                else
                {
                    this[LAST._Price].TradeVolume += LAST._Size;
                    QuoteItem BID = List.Find(x => x._quoteType == QuoteStreamType.BID);
                    QuoteItem ASK = List.Find(x => x._quoteType == QuoteStreamType.ASK);
                    if (BID != null && ASK != null)
                    {
                        if (LAST._Price == BID._Price)
                            this[LAST._Price].TradeAtBidSize += BID._Size;
                        else if (LAST._Price == ASK._Price)
                            this[LAST._Price].TradeAtOfferSize += ASK._Size;
                        else
                            this[LAST._Price].TradeAtBetSize += LAST._Size;
                    }
                    else
                    {
                        this[LAST._Price].TradeAtBetSize += LAST._Size;//To show that trade is between Bid/Offer
                    }

                    if (Convert.ToDateTime(LAST._Time) <= currentTime)
                    {
                        if (this[LAST._Price].TimeTradeVolume == null)
                        {
                            this[LAST._Price].TimeTradeVolume = new List<long>();
                            this[LAST._Price].TimeTradeVolume.Add(0);
                        }
                        else if (this[LAST._Price].TimeTradeVolume.Count == 0)
                        {
                            this[LAST._Price].TimeTradeVolume.Add(0);
                        }
                        this[LAST._Price].TimeTradeVolume[0] += LAST._Size;
                    }
                    else
                    {
                        int n = ((int)(Convert.ToDateTime(LAST._Time) - currentTime).TotalMinutes / 15) + 1;
                        if (this[LAST._Price].TimeTradeVolume == null)
                        {
                            this[LAST._Price].TimeTradeVolume = new List<long>();
                            this[LAST._Price].TimeTradeVolume.Add(0);
                        }
                        else if (this[LAST._Price].TimeTradeVolume.Count == 0)
                        {
                            this[LAST._Price].TimeTradeVolume.Add(0);
                        }
                        for (int i = this[LAST._Price].TimeTradeVolume.Count - 1; i < n; i++)
                        {
                            this[LAST._Price].TimeTradeVolume.Add(0);
                        }
                        this[LAST._Price].TimeTradeVolume[n] += LAST._Size;
                    }
                    _totalTradeVolume += LAST._Size;
                    UpdateOutOfRangeColor(this[LAST._Price]);
                    if (OnLTPOccurred != null)
                        OnLTPOccurred(this[LAST._Price]);
                }
            }
        }

        //public void AddTrades(List<Trade> trades)
        //{
        //    var itemsAdded = new List<MatrixViewItem>();
        //    var pricesAdded = new List<long>();
        //    var pricesUpdated = new List<long>();

        //    foreach (Trade trade in trades)
        //    {
        //        if (!this.ContainsKey(trade.Price))
        //        {
        //            var item = new MatrixViewItem { Price = trade.Price, TradeVolume = trade.Volume, TimeTradeVolume = new List<long>() };
        //            if (trade.TradeStatus == TradeStatus.AtBid)
        //                item.TradeAtBidSize += trade.Volume;
        //            else if (trade.TradeStatus == TradeStatus.AtOffer)
        //                item.TradeAtOfferSize += trade.Volume;
        //            else if (trade.TradeStatus == TradeStatus.BetweenBidAndOffer)
        //                item.TradeAtBetSize += trade.Volume;
        //            else
        //            { }
        //            if (trade.TimeStamp <= currentTime)
        //            {
        //                item.TimeTradeVolume.Add(trade.Volume);
        //            }
        //            else
        //            {
        //                int n = ((int)(trade.TimeStamp - currentTime).TotalMinutes / 15) + 1;
        //                for (int i = 0; i < n; i++)
        //                {
        //                    item.TimeTradeVolume.Add(0);
        //                }
        //                item.TimeTradeVolume.Add(trade.Volume);

        //            }
        //            UpdateHighPrice(trade.Price, ref pricesUpdated);
        //            UpdateLowPrice(trade.Price, ref pricesUpdated);
        //            UpdateLastTrade(trade.Price, ref pricesUpdated);
        //            _totalTradeVolume += trade.Volume;
        //            this.Add(trade.Price, item);
        //            UpdateOutOfRangeColor(item);
        //            itemsAdded.Add(item);
        //            pricesAdded.Add(item.Price);

        //        }
        //        else
        //        {
        //            this[trade.Price].TradeVolume += trade.Volume;
        //            if (trade.TradeStatus == TradeStatus.AtBid)
        //                this[trade.Price].TradeAtBidSize += trade.Volume;
        //            else if (trade.TradeStatus == TradeStatus.AtOffer)
        //                this[trade.Price].TradeAtOfferSize += trade.Volume;
        //            else if (trade.TradeStatus == TradeStatus.BetweenBidAndOffer)
        //                this[trade.Price].TradeAtBetSize += trade.Volume;
        //            else
        //            { }
        //            if (trade.TimeStamp <= currentTime)
        //            {
        //                if (this[trade.Price].TimeTradeVolume == null)
        //                {
        //                    this[trade.Price].TimeTradeVolume = new List<long>();
        //                    this[trade.Price].TimeTradeVolume.Add(0);
        //                }
        //                else if (this[trade.Price].TimeTradeVolume.Count == 0)
        //                {
        //                    this[trade.Price].TimeTradeVolume.Add(0);
        //                }
        //                this[trade.Price].TimeTradeVolume[0] += trade.Volume;
        //            }
        //            else
        //            {
        //                int n = ((int)(trade.TimeStamp - currentTime).TotalMinutes / 15) + 1;
        //                if (this[trade.Price].TimeTradeVolume == null)
        //                {
        //                    this[trade.Price].TimeTradeVolume = new List<long>();
        //                    this[trade.Price].TimeTradeVolume.Add(0);
        //                }
        //                else if (this[trade.Price].TimeTradeVolume.Count == 0)
        //                {
        //                    this[trade.Price].TimeTradeVolume.Add(0);
        //                }
        //                for (int i = this[trade.Price].TimeTradeVolume.Count - 1; i < n; i++)
        //                {
        //                    this[trade.Price].TimeTradeVolume.Add(0);
        //                }
        //                this[trade.Price].TimeTradeVolume[n] += trade.Volume;
        //            }
        //            _totalTradeVolume += trade.Volume;
        //            UpdateLastTrade(trade.Price, ref pricesUpdated);
        //            UpdateOutOfRangeColor(this[trade.Price]);
        //            pricesUpdated.Add(trade.Price);
        //        }
        //    }

        //    for (long i = _lowPrice; i <= _highPrice; i++)
        //    {
        //        if (!this.ContainsKey(i))
        //        {
        //            var item = new MatrixViewItem
        //                           {
        //                               BidOrderCount = 0,
        //                               BidSize = 0,
        //                               OfferOrderCount = 0,
        //                               OfferSize = 0,
        //                               TradeVolume = 0,
        //                               TradeAtOfferSize = 0,
        //                               TradeAtBidSize = 0,
        //                               TradeAtBetSize = 0,
        //                               TimeTradeVolume = new List<long>(),
        //                               Price = i
        //                           };

        //            UpdateOutOfRangeColor(item);

        //            this.Add(i, item);
        //            itemsAdded.Add(item);
        //            pricesAdded.Add(item.Price);
        //        }
        //    }

        //    for (int i = 0; i < itemsAdded.Count; i++)
        //    {
        //        itemsAdded[i].BidOrderCount = this[itemsAdded[i].Price].BidOrderCount;
        //        itemsAdded[i].BidSize = this[itemsAdded[i].Price].BidSize;
        //        itemsAdded[i].OfferOrderCount = this[itemsAdded[i].Price].OfferOrderCount;
        //        itemsAdded[i].OfferSize = this[itemsAdded[i].Price].OfferSize;
        //        itemsAdded[i].TradeVolume = this[itemsAdded[i].Price].TradeVolume;
        //        itemsAdded[i].TradeAtBetSize = this[itemsAdded[i].Price].TradeAtBetSize;
        //        itemsAdded[i].TradeAtBidSize = this[itemsAdded[i].Price].TradeAtBidSize;
        //        itemsAdded[i].TradeAtOfferSize = this[itemsAdded[i].Price].TradeAtOfferSize;
        //        itemsAdded[i].TimeTradeVolume = this[itemsAdded[i].Price].TimeTradeVolume;
        //    }

        //    List<long> pricesNeedingUpdate = pricesUpdated.Distinct().Where(i => !pricesAdded.Contains(i)).ToList();

        //    List<MatrixViewItem> itemsToUpdate = new List<MatrixViewItem>();
        //    foreach (long price in pricesNeedingUpdate)
        //    {
        //        itemsToUpdate.Add(this[price]);
        //    }

        //    RaiseItemsAdded(itemsAdded);
        //    RaiseItemsUpdated(itemsToUpdate);
        //}

        private void UpdateHighPrice(long price, ref List<double> itemsUpdated)
        {
            if (price > _highPrice)
            {
                if (this.ContainsKey(_highPrice))
                {
                    itemsUpdated.Add(_highPrice);
                }
                _highPrice = price;
            }
        }

        private void UpdateLowPrice(long price, ref List<double> itemsUpdated)
        {
            if (price < _lowPrice || _lowPrice == -1)
            {
                if (this.ContainsKey(_lowPrice))
                {
                    itemsUpdated.Add(_lowPrice);
                }
                _lowPrice = price;
            }
        }

        private void UpdateLastTrade(long price, ref List<double> itemsUpdated)
        {
            if (this.ContainsKey(_lastTrade))
            {
                itemsUpdated.Add(_lastTrade);
            }
            _lastTrade = price;
        }

        public void InitializeDepth(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            foreach (DepthByPrice depth in bids)
            {
                UpdateDepthItem(depth, true, false);
            }
            foreach (DepthByPrice depth in offers)
            {
                UpdateDepthItem(depth, false, false);
            }
            AddDefaultValues();

            if (DepthInitialized != null)
                DepthInitialized(this.Values.ToList());
        }

        public void InitializeDepthNew(DepthByPrice Depth, bool Isbuy)
        {

            OrderbookItem Ord = new OrderbookItem();
            Ord.Price = Depth.Price;
            Ord.Size = Depth.Volume;
            Ord.OrderDate = DateTime.UtcNow;
            Ord.OriginalOrderCode = "1";
            Depth.Orders.Add(Ord);
            UpdateDepth(Depth, Isbuy);
            if (DepthInitialized != null)
                DepthInitialized(this.Values.ToList());
        }

        public void AddDefaultValues()
        {
            //fill in default values
            //for (long i = _lowPrice; i <= _highPrice; i++)
            for (double i = _lowPrice; i <= _highPrice; i += 0.25)
            {
                if (!this.ContainsKey(i))
                {
                    MatrixViewItem item = new MatrixViewItem();
                    item.BidOrderCount = 0;
                    item.BidSize = 0;
                    item.OfferOrderCount = 0;
                    item.OfferSize = 0;
                    item.TradeVolume = 0;
                    item.Price = i;
                    item.TradeAtBetSize = 0;
                    item.TradeAtBidSize = 0;
                    item.TradeAtOfferSize = 0;
                    item.TimeTradeVolume = new List<long>();
                    UpdateOutOfRangeColor(item);
                    this.Add(i, item);
                }
            }
        }
        private void UpdateOutOfRangeColor(MatrixViewItem item)
        {
            if (item.Price > _highPrice)
            {
                item.PriceBackgroundColor = OutOfRangeColor;
            }
            else if (item.Price < _lowPrice)
            {
                item.PriceBackgroundColor = OutOfRangeColor;
            }
            else
            {
                item.PriceBackgroundColor = Color.Black;
            }
        }

        public void UpdateDepth(DepthByPrice depth, bool isBuy)
        {
            UpdateDepthItem(depth, isBuy, true);
        }
        object lck = new object();
        private void UpdateDepthItem(DepthByPrice depth, bool isBuy, bool shouldRaiseEvent)
        {
            //Check Market Level and Corresponding prices/sizes
            double OldPrc = 0;
            if(!_dicLvlPrc.ContainsKey(depth.MktLevel))
            {
                _dicLvlPrc.Add(depth.MktLevel,depth.Price);
                if (!this.ContainsKey(depth.Price))
                {
                    MatrixViewItem item = new MatrixViewItem();
                    if (isBuy)
                    {
                        item.BidOrderCount = depth.Orders.Count;
                        item.BidSize = depth.Volume;
                        _totalBidSize += item.BidSize;
                    }
                    else
                    {
                        item.OfferOrderCount = depth.Orders.Count;
                        item.OfferSize = depth.Volume;
                        _totalOfferSize += item.OfferSize;
                    }
                    item.Price = depth.Price;
                    item.MktLvl = depth.MktLevel;
                    this.Add(item.Price, item);
                    UpdateOutOfRangeColor(item);
                }
            }
            else
            {
                OldPrc = _dicLvlPrc[depth.MktLevel];
                if (this.ContainsKey(OldPrc))
                {
                    if (!this.ContainsKey(depth.Price))
                    {
                        MatrixViewItem item = new MatrixViewItem();
                        if (isBuy)
                        {
                            item.BidOrderCount = depth.Orders.Count;
                            item.BidSize = depth.Volume;
                            _totalBidSize += item.BidSize;
                        }
                        else
                        {
                            item.OfferOrderCount = depth.Orders.Count;
                            item.OfferSize = depth.Volume;
                            _totalOfferSize += item.OfferSize;
                        }
                        item.Price = depth.Price;
                        item.MktLvl = depth.MktLevel;
                        this.Remove(OldPrc);
                        this.Add(item.Price, item);
                        UpdateOutOfRangeColor(item);
                        _dicLvlPrc[depth.MktLevel] = depth.Price;
                    }
                }
                else
                {
        
                }               
            }
            foreach (var item in this.Keys)
            {
                if (!_dicLvlPrc.ContainsValue(item))
                {
                    this[item].BidOrderCount = 0;
                    this[item].BidSize = 0;
                    this[item].OfferOrderCount = 0;
                    this[item].OfferSize = 0;
                }
            }

            //if (!this.ContainsKey(depth.Price))
            //{
            //    //CheckLevel

            //    MatrixViewItem item = new MatrixViewItem();
            //    if (isBuy)
            //    {
            //        item.BidOrderCount = depth.Orders.Count;
            //        item.BidSize = depth.Volume;
            //        _totalBidSize += item.BidSize;
            //    }
            //    else
            //    {
            //        item.OfferOrderCount = depth.Orders.Count;
            //        item.OfferSize = depth.Volume;
            //        _totalOfferSize += item.OfferSize;
            //    }
            //    item.Price = depth.Price;
            //    UpdateOutOfRangeColor(item);
            //    this.Add(item.Price, item);

            //    //if (shouldRaiseEvent)//Kuldeep
            //    //    RaiseItemsAdded(new List<MatrixViewItem>() { item });
            //}
            //else
            //{
            //    if (isBuy)
            //    {
            //        _totalBidSize += depth.Volume - this[depth.Price].BidSize;
            //        this[depth.Price].BidOrderCount = depth.Orders.Count;
            //        this[depth.Price].BidSize = depth.Volume;
            //    }
            //    else
            //    {
            //        _totalBidSize += depth.Volume - this[depth.Price].OfferSize;
            //        this[depth.Price].OfferOrderCount = depth.Orders.Count;
            //        this[depth.Price].OfferSize = depth.Volume;
            //    }
            //    UpdateOutOfRangeColor(this[depth.Price]);
            //    //if (shouldRaiseEvent)//Kuldeep
            //    //    RaiseItemsUpdated(new List<MatrixViewItem>() { this[depth.Price] });
            //}
        }

        public void RemoveDepth(double price, bool isBuy)
        {
            if (!this.ContainsKey(price))
                return;
                //throw new ApplicationException("List does not contain specified price.");

            if (isBuy)
            {
                this[price].BidOrderCount = 0;
                this[price].BidSize = 0;
            }
            else
            {
                this[price].OfferOrderCount = 0;
                this[price].OfferSize = 0;
            }
            RaiseItemsUpdated(new List<MatrixViewItem>() { this[price] });
            //only remove price if depth is zero and no trades at that price
            //if (this[price].TradeVolume == 0 && this[price].BidOrderCount == 0 && this[price].BidSize == 0 && this[price].OfferOrderCount == 0
            //    && this[price].OfferSize == 0)
            //{
            //    MatrixViewItem item = this[price];
            //    this.Remove(price);

            //    if (ItemsRemoved != null)
            //        ItemsRemoved(new List<MatrixViewItem>() { item });
            //}
            //else
            //{
            //    RaiseItemsUpdated(new List<MatrixViewItem>() { this[price] });
            //}
        }

        public IList<MatrixViewItem> GetItems()
        {
            return this.Values;
        }

        public void ClearItems()
        {
            _instrumentAdded = false;
            this.Clear();
        }
    }

}
