using System;
using System.Collections.Generic;
using System.Linq;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Domain.Entities;
//using FundXchange.Domain.ValueObjects;
//using FundXchange.Model.ViewModels.Matrix;
//using FundXchange.Model.Agents;
//using FundXchange.Domain;
using System.Drawing;
using PALSA.Cls;


namespace PALSA.ClsMatrix
{
    public class MatrixController
    {
        public Instrument Instrument { get; private set; }

        public static Color OpenColor = Color.Turquoise;
        public static Color CloseColor = Color.Gray;
        public static Color LastTradeColor = Color.FromArgb(255, 204, 0); //dark yellow
        public static Color HighColor = Color.Green;
        public static Color LowColor = Color.Orange;
        public static Color DefaultColor = Color.Black;
        public string m_symbol = string.Empty;
        public string m_InstID = string.Empty;

        //private readonly IMarketRepository _repository;
        private readonly IMatrixView _view;
        private readonly IMatrixViewItemList _items;
        //private readonly IErrorService _errorService;

        private readonly MessageHandler<object> _messageHandler;

        public int MaxTradingHour = 17;
        public int MinTradingHour = 9;
        string format = "0.";
        public MatrixController(IMatrixView view)
            : this (view, new MatrixViewItemList())
        {
        }

        public MatrixController(IMatrixView view,IMatrixViewItemList itemList)
        {
            _view = view;
            _messageHandler = new MessageHandler<object>("Matrix");
            _messageHandler.MessageReceived += MessageHandlerMessageReceived;
            _messageHandler.Start();

            _items = itemList;
            _items.DepthInitialized += _Items_DepthInitialized;
            //_items.AddDefaultValues();
            _view.ClearGrid();
  
        }

        public IList<MatrixViewItem> GetItems()
        {
            IList<MatrixViewItem> items = _items.GetItems();
            if (items == null)
                items = new List<MatrixViewItem>();
            return items;
        }

        //public void Subscribe(string symbol, string exchange)
        //{
        //    if (String.IsNullOrEmpty(symbol))
        //        throw new ApplicationException("Symbol cannot be Null or Empty when subscribing to Matrix");

        //    if (String.IsNullOrEmpty(exchange))
        //        throw new ApplicationException("Exchange cannot be Null or Empty when subscribing to Matrix");

        //    //int count = _repository.AllInstrumentReferences.Where(i => i.Symbol == symbol).Count();
        //    //if (count == 0)
        //    //    throw new ApplicationException("Invalid symbol specified with subscribe to Matrix");

        //    if (Instrument == null || symbol != Instrument.Symbol)
        //    {
        //        UnsubscribeLevelTwoEvents();
        //        UnsubscribeListEvents();
        //        _items.ClearItems();

        //        try
        //        {
        //            m_symbol = symbol;
        //            //Instrument instrument = _repository.SubscribeLevelOneWatch(symbol, exchange);
        //            //Instrument = instrument;
        //            //_items.AddInstrument(instrument);
        //            //if (_repository.LevelTwoInstrument != null && _repository.LevelTwoInstrument.Symbol == symbol)
        //            //{
        //            //    List<DepthByPrice> bids = _repository.Orderbook.GetBids();
        //            //    List<DepthByPrice> offers = _repository.Orderbook.GetOffers();
        //            //    Orderbook_OrderbookInitializedEvent(bids, offers);
        //            //    UpdateViewWithInstrument(Instrument);
        //            //}
        //            //else
        //            //{
        //            //    _repository.SubscribeLevelTwoWatch(symbol, exchange);
        //            //    UpdateViewWithInstrument(Instrument);
        //            //}
                    
        //            //SubscribeToLevelTwoEvents();

        //            //if (DateTime.UtcNow.AddHours(2).Hour >= MinTradingHour && DateTime.UtcNow.AddHours(2).Hour < MaxTradingHour)
        //            //{
        //            //    List<Trade> trades = _repository.GetTrades(exchange, symbol,(int) instrument.TotalTrades);
        //            //    _items.AddTrades(trades);
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            //_errorService.LogError(ex.Message, ex);
        //            throw;
        //        }
        //    }
        //}


        private void SubscribeToLevel1Events(string InstID)
        {
            //_repository.InstrumentUpdatedEvent += MarketRepositoryInstrumentUpdatedEvent;
            //_repository.TradeOccurredEvent += MarketRepositoryTradeOccurredEvent;
            
            Symbol sym = Symbol.GetSymbol(InstID);
            List<Symbol> lstSym = new List<Symbol>();
            lstSym.Add(sym);

            //Namo 21 March
            //InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
            ////InstrumentSpec objInstrumentSpec = ClsGlobal.DDContractInfo[m_InstID];
            //for (int i = 0; i < objInstrumentSpec.Digits; i++)
            //{
            //    format += "0";
            //}


            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;

            //clsTWSDataManagerJSON.INSTANCE.SubscribeForDom(true, eMarketRequest.MARKET_DEPTH, lstSym);
        }

        void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)
        {
            foreach (var item in obj)
            {                
                Symbol sym = Symbol.GetSymbol(item.Key);

                if (sym.Contract == m_symbol)
                {
                    double val = 0;
                    double BidPX = 0;
                    double AskPX = 0;
                    long Size = 0;
                    //Namo 21 March
                    //foreach (QuoteItem item2 in item.Value._lstItem)
                    //{
                    //    switch (item2._quoteType)
                    //    {
                    //        case QuoteStreamType.ASK:
                    //            {
                    //                AskPX = item2._Price;
                    //                Size = item2._Size;
                    //                DepthByPrice dp = CreateDepth(sym.Contract, AskPX, Size, (int)item2._MarketLevel);
                    //                _items.InitializeDepthNew(dp, false);
                    //            }
                    //            break;
                    //        case QuoteStreamType.BID:
                    //            {
                    //                BidPX = item2._Price;
                    //                Size = item2._Size;
                    //                DepthByPrice dp = CreateDepth(sym.Contract, BidPX, Size, (int)item2._MarketLevel);
                    //                _items.InitializeDepthNew(dp, true);
                    //            }
                    //            break;
                    //        case QuoteStreamType.LAST:
                    //            {
                    //                //Randomize(BANKS);
                    //                BidPX = item2._Price;
                    //                Size = item2._Size;
                    //                //Quote Bidquotes = CreateDummyData(sym.Contract, BidPX, Size, QuoteStreamType.BID);
                    //                //List<DepthByPrice> BidDepth = GetDepth(Symbol, sym.Gateway, Bidquotes, BANKS.ToList());
                    //                //EnqueueDepthByPriceChangedEvent(BidDepth, _Offers);
                    //            }
                    //            break;
                    //        case QuoteStreamType.VOLUME:
                    //            {

                    //            }
                    //            break;
                    //        case QuoteStreamType.VOLUME_PER:
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //}
                    //Namo 21 March
                    //HandleQuotes(item.Value._lstItem);//BroadCast for LTP and quotes
                }
            }
        }

        private DepthByPrice CreateDepth(string Sym, double Price, long Size,int MktLvl)
        {
            string temp = Price.ToString(format);
            DepthByPrice dp = new DepthByPrice(Sym, "OEC");
            dp.Exchange = "OEC";
            dp.Price = Convert.ToDouble(temp);//Price;
            dp.Volume = Size;
            dp.MktLevel = MktLvl;
            return dp;
        }

        //Namo 21 March
        //private void HandleQuotes(List<QuoteItem> list)//By Kuldeep
        //{
        //    QuoteItem LAST = list.Find(x => x._quoteType == QuoteStreamType.LAST);
        //    if (LAST!=null)
        //    {
        //        _view.UpdateTopGridLAST(LAST);//For Top Grid
        //        _items.ProcessLTP(list);
        //    }
        //}

        private void SubscribeToLevelTwoEvents()
        {
            //_repository.Orderbook.OrderbookInitializedEvent += Orderbook_OrderbookInitializedEvent;
            //_repository.Orderbook.DepthByPriceItemAddedEvent += Orderbook_DepthByPriceItemAddedEvent;
            //_repository.Orderbook.DepthByPriceItemUpdatedEvent += Orderbook_DepthByPriceItemUpdatedEvent;
            //_repository.Orderbook.DepthByPriceItemDeletedEvent += Orderbook_DepthByPriceItemDeletedEvent;
        }

        private void UnsubscribeLevelTwoEvents()
        {
            //if (null != _repository.Orderbook)
            //{
            //    _repository.Orderbook.OrderbookInitializedEvent -= Orderbook_OrderbookInitializedEvent;
            //    _repository.Orderbook.DepthByPriceItemAddedEvent -= Orderbook_DepthByPriceItemAddedEvent;
            //    _repository.Orderbook.DepthByPriceItemUpdatedEvent -= Orderbook_DepthByPriceItemUpdatedEvent;
            //    _repository.Orderbook.DepthByPriceItemDeletedEvent -= Orderbook_DepthByPriceItemDeletedEvent;
            //}
        }

        private void SubscribeToListEvents()
        {
            _items.ItemsAdded += _Items_ItemAdded;
            _items.ItemsUpdated += _Items_ItemUpdated;
            _items.OnLTPOccurred +=new Action<MatrixViewItem>(_items_OnLTPOccurred);
        }

        void _items_OnLTPOccurred(MatrixViewItem items)
        {
            //Pass to Main form here            
            string temp = items.Price.ToString(format);
            items.Price = Convert.ToDouble(temp);
            _view.HandleLTP(items);
        }

        private void UnsubscribeListEvents()
        {
            _items.ItemsAdded -= _Items_ItemAdded;
            _items.ItemsUpdated -= _Items_ItemUpdated;
        }

        void MessageHandlerMessageReceived(object message)
        {
            //if (message is Trade)
            //{
            //    ProcessTrade((Trade)message);
            //}
            if (message is Instrument)
            {
                ProcessInstrument((Instrument)message);
            }
            else if (message is OrderbookInitEvent)
            {
                var orders = (OrderbookInitEvent)message;
                _items.InitializeDepth(orders.Bids, orders.Offers);
            }
            else if (message is DepthEvent)
            {
                var depth = (DepthEvent)message;
                switch (depth.DepthType)
                {
                    case DepthEvent.DepthTypes.Add:
                        ProcessDepthAdd(depth.Item, depth.IsBuy);
                        break;
                    case DepthEvent.DepthTypes.Delete:
                        ProcessDepthDelete(depth.Item, depth.IsBuy);
                        break;
                    case DepthEvent.DepthTypes.Update:
                        ProcessDepthUpdate(depth.Item, depth.IsBuy);
                        break;
                    default:
                        break;
                }

            }
        }

        //void MarketRepositoryTradeOccurredEvent(Trade trade)
        //{
        //    _messageHandler.AddMessage(trade);
        //}

        //private void ProcessTrade(Trade trade)
        //{
        //    try
        //    {
        //        if (trade.Symbol == Instrument.Symbol)
        //        {
        //            _items.AddTrades(new List<Trade>() { trade });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex);
        //    }
        //}

        void MarketRepositoryInstrumentUpdatedEvent(Instrument instrument)
        {
            _messageHandler.AddMessage(instrument);
        }

        private void ProcessInstrument(Instrument instrument)
        {
            try
            {
                if (instrument.Symbol == Instrument.Symbol)
                {
                    UpdateViewWithInstrument(instrument);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

        void Orderbook_OrderbookInitializedEvent(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            var ev = new OrderbookInitEvent
                         {
                             Bids = bids,
                             Offers = offers
                         };

            _messageHandler.AddMessage(ev); 
        }

        void Orderbook_DepthByPriceItemDeletedEvent(DepthByPrice depthByPrice, bool isBuy)
        {
            var ev = new DepthEvent
                                {
                                    DepthType = DepthEvent.DepthTypes.Delete,
                                    IsBuy = isBuy,
                                    Item = depthByPrice
                                };

            _messageHandler.AddMessage(ev);
        }

        private void ProcessDepthDelete(DepthByPrice depthByPrice, bool isBuy)
        {
            if (depthByPrice.Symbol == Instrument.Symbol)
            {
                _items.RemoveDepth(depthByPrice.Price, isBuy);
            }
        }

        void Orderbook_DepthByPriceItemUpdatedEvent(DepthByPrice depthByPrice, bool isBuy)
        {
            var ev = new DepthEvent
                         {
                             DepthType = DepthEvent.DepthTypes.Update,
                             IsBuy = isBuy,
                             Item = depthByPrice
                         };

            _messageHandler.AddMessage(ev);
        }

        private void ProcessDepthUpdate(DepthByPrice depthByPrice, bool isBuy)
        {
            if (depthByPrice.Symbol == Instrument.Symbol)
            {
                _items.UpdateDepth(depthByPrice, isBuy);
            }
        }

        void Orderbook_DepthByPriceItemAddedEvent(DepthByPrice depthByPrice, bool isBuy)
        {
            var ev = new DepthEvent
                                {
                                    DepthType = DepthEvent.DepthTypes.Add,
                                    IsBuy = isBuy,
                                    Item = depthByPrice
                                };

            _messageHandler.AddMessage(ev);
        }

        private void ProcessDepthAdd(DepthByPrice depthByPrice, bool isBuy)
        {
            if (depthByPrice.Symbol == Instrument.Symbol)
            {
                _items.UpdateDepth(depthByPrice, isBuy);
            }
        }

        private void UpdateViewWithInstrument(Instrument instrument)
        {
            _view.UpdateGridWithInstrument(instrument);
        }

        void _Items_DepthInitialized(List<MatrixViewItem> items)
        {
            //_view.ClearGrid();
            _view.AddGridRowItems(items);
            //_view.UpdateGridWithInstrument(Instrument);//Kuldeep
            _view.UpdateTotalTradeVolume(_items.GetTotalTradeVolume());
            _view.UpdateTotalBidSize(_items.GetTotalBidSize());
            _view.UpdateTotalOfferSize(_items.GetTotalOfferSize());
            //SubscribeToListEvents();//By Kul
        }

        void _Items_ItemUpdated(List<MatrixViewItem> items)
        {
            _view.UpdateGridRowItems(items);
            _view.UpdateTotalTradeVolume(_items.GetTotalTradeVolume());
            _view.UpdateTotalBidSize(_items.GetTotalBidSize());
            _view.UpdateTotalOfferSize(_items.GetTotalOfferSize());
        }

        void _Items_ItemAdded(List<MatrixViewItem> items)
        {
            _view.AddGridRowItems(items);
            _view.UpdateTotalTradeVolume(_items.GetTotalTradeVolume());
            _view.UpdateTotalBidSize(_items.GetTotalBidSize());
            _view.UpdateTotalOfferSize(_items.GetTotalOfferSize());
        }

        public void Stop()
        {
            _messageHandler.Dispose();
        }


        internal void SubscribeNew(string _Symbol, string InsID, double High, double Low)
        {
            UnsubscribeLevelTwoEvents();
            UnsubscribeListEvents();
            _items.ClearItems();
            try
            {

                //Kul
                SubscribeToListEvents();
                m_symbol = _Symbol;
                m_InstID = InsID;
                _items.AddInstrumentNew(High, Low);
                SubscribeToLevel1Events(m_InstID);

   

                //Instrument instrument = _repository.SubscribeLevelOneWatch(symbol, exchange);
                //Instrument = instrument;
                //if (_repository.LevelTwoInstrument != null && _repository.LevelTwoInstrument.Symbol == symbol)
                //{
                //    List<DepthByPrice> bids = _repository.Orderbook.GetBids();
                //    List<DepthByPrice> offers = _repository.Orderbook.GetOffers();
                //    Orderbook_OrderbookInitializedEvent(bids, offers);
                //    UpdateViewWithInstrument(Instrument);
                //}
                //else
                //{
                //    _repository.SubscribeLevelTwoWatch(symbol, exchange);
                //    UpdateViewWithInstrument(Instrument);
                //}

                //SubscribeToLevelTwoEvents();
            }
            catch (Exception ex)
            {
                //_errorService.LogError(ex.Message, ex);
                throw;
            }
        }

        internal void UnSubscribeDOM()
        {
            //Namo 21 March
         // clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
        }
    }

    internal class OrderbookInitEvent
    {
        internal List<DepthByPrice> Bids;
        internal List<DepthByPrice> Offers;
    }

    internal class DepthEvent
    {
        internal DepthByPrice Item;
        internal bool IsBuy;
        internal enum DepthTypes
        {
            Add,
            Update,
            Delete
        }
        internal DepthTypes DepthType;
    }
}
