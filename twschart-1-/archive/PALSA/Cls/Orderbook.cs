using System;
using System.Linq;
using System.Collections.Generic;
//using FundXchange.Domain.Entities;
//using FundXchange.Domain.ValueObjects;


namespace PALSA.Cls
{
   // public delegate void OrderbookInitialized(List<DepthByPrice> bids, List<DepthByPrice> offers);
   // public delegate void OrderbookItemAdded(OrderbookItem order);
   // public delegate void OrderbookItemUpdated(OrderbookItem order);
   // public delegate void OrderbookItemDeleted(OrderbookItem order);
   // public delegate void DepthByPriceItemAdded(DepthByPrice depthByPrice, bool isBuy);
   // public delegate void DepthByPriceItemUpdated(DepthByPrice depthByPrice, bool isBuy);
   // public delegate void DepthByPriceItemDeleted(DepthByPrice depthByPrice, bool isBuy);
   // public delegate void DepthByPriceChanged(List<DepthByPrice> bids, List<DepthByPrice> offers);

   // public interface IOrderbook
   // {
   //     //Dictionary<string, OrderbookItem> Orders { get; set; }
   //     //SortedList<long, DepthByPrice> Bids { get; }
   //     //SortedList<long, DepthByPrice> Offers { get; }
   //     event OrderbookInitialized OrderbookInitializedEvent;
   //     event OrderbookItemAdded OrderbookItemAddedEvent;
   //     event OrderbookItemUpdated OrderbookItemUpdatedEvent;
   //     event OrderbookItemDeleted OrderbookItemDeletedEvent;
   //     event DepthByPriceItemAdded DepthByPriceItemAddedEvent;
   //     event DepthByPriceItemUpdated DepthByPriceItemUpdatedEvent;
   //     event DepthByPriceItemDeleted DepthByPriceItemDeletedEvent;
   //     event DepthByPriceChanged DepthByPriceChangedEvent;
   //     void AddOrder(OrderbookItem order, bool shouldRaiseEvent);
   //     void RemoveOrder(string orderCode);
   //     void InitializeOrderbook(List<OrderbookItem> orders);
   //     int GetIndexOfDepthItem(DepthByPrice depthByPrice, bool isBuy);
   //     bool IsTop5(OrderbookItem order);
   //     OrderbookItem GetOrder(string OriginalOrderCode);
   //     void AddQuote(FundXchange.Domain.ValueObjects.Quote quote);

   //     List<DepthByPrice> GetBids();
   //     List<DepthByPrice> GetOffers();
   //     Dictionary<string, OrderbookItem> GetOrders();

   //     void OnDomInitialize(List<ClientDLL_Model.Cls.Market.MarketDepthItem> list, string Symb, string Exchange);
   //     void OnDom(Dictionary<string, ClientDLL_Model.Cls.Market.Quote> DDQuote);
   //     event Action<string, double, long, uint, string, string> OnDomEvnt;
   // }

   // public class Orderbook : IOrderbook
   // {
   //     private readonly string _isin;
   //     private readonly string _symbol;
   //     private readonly string _exchange;
   //     private bool _isRestricted;

   //     private Dictionary<string, OrderbookItem> Orders { get; set; }
   //     private SortedList<double, DepthByPrice> Bids { get; set; }
   //     private SortedList<double, DepthByPrice> Offers { get; set; }

   //     private readonly object m_lock = new object();

   //     public event OrderbookItemAdded OrderbookItemAddedEvent;
   //     public event OrderbookItemUpdated OrderbookItemUpdatedEvent;
   //     public event OrderbookItemDeleted OrderbookItemDeletedEvent;

   //     public event DepthByPriceItemAdded DepthByPriceItemAddedEvent;
   //     public event DepthByPriceItemUpdated DepthByPriceItemUpdatedEvent;
   //     public event DepthByPriceItemDeleted DepthByPriceItemDeletedEvent;
   //     public event DepthByPriceChanged DepthByPriceChangedEvent;

   //     public event OrderbookInitialized OrderbookInitializedEvent;
   //     public event Action<string, double, long, uint,string,string> OnDomEvnt;

   //     public Orderbook(string isin, string symbol, string exchange, bool isRestricted)
   //     {
   //         _isRestricted = isRestricted;
   //         _isin = isin;
   //         _symbol = symbol;
   //         _exchange = exchange;
   //         Bids = new SortedList<double, DepthByPrice>(new DescendingComparer<double>());
   //         Offers = new SortedList<double, DepthByPrice>();
   //         Orders = new Dictionary<string, OrderbookItem>();
   //     }


   //     public void OnDomInitialize(List<ClientDLL_Model.Cls.Market.MarketDepthItem> list, string Symb, string Exchange)// Kuldeep
   //     {

   //         List<DepthByPrice> DepthBid = new List<DepthByPrice>();
   //         List<DepthByPrice> DepthAsk = new List<DepthByPrice>();

   //         int Bidk =  list.Count;//Contract.DOM.BidLevels.Length;
   //         int AskK = list.Count;//Contract.DOM.AskLevels.Length;

   //         for (int i = 0; i < Bidk; i++)
   //         {
   //             DepthByPrice objDepthBid = new DepthByPrice(Symb, Exchange);
   //             OrderbookItem Ord = new OrderbookItem();

   //             objDepthBid.Symbol = Symb;
   //             objDepthBid.Volume = list[i]._BidSize;
   //             objDepthBid.Price = list[i]._BidPrice;
   //             objDepthBid.MktLevel = (int)list[i]._Level;

   //             Ord.OriginalOrderCode = "1";//(BidId + 1).ToString();//"5000";
   //             Ord.Price = list[i]._BidPrice;
   //             Ord.Size = list[i]._BidSize;
   //             Ord.OrderDate = FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(list[i]._BidTime);

   //             objDepthBid.Orders.Add(Ord);

   //             DepthBid.Add(objDepthBid);
   //             //BidId++;
   //         }

   //         for (int i = 0; i < AskK; i++)
   //         {
   //             DepthByPrice objDepthAsk = new DepthByPrice(Symb, Exchange);
   //             OrderbookItem Ord = new OrderbookItem();

   //             objDepthAsk.Symbol = Symb;
   //             objDepthAsk.Volume = list[i]._AskSize;
   //             objDepthAsk.Price = list[i]._AskPrice;
   //             objDepthAsk.MktLevel = (int)list[i]._Level;

   //             Ord.OriginalOrderCode = "1";//(BidId + 1).ToString();//"5000";
   //             Ord.Price = list[i]._AskPrice;
   //             Ord.Size = list[i]._AskSize;
   //             Ord.OrderDate = FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(list[i]._AskTime);

   //             objDepthAsk.Orders.Add(Ord);
   //             DepthAsk.Add(objDepthAsk);
   //             //AskId++;
   //         }

   //         if (OrderbookInitializedEvent != null)
   //             OrderbookInitializedEvent(DepthBid, DepthAsk);
   //     }


   //     public void OnDom(Dictionary<string, Quote> obj)
   //     {
   //         foreach (var item in obj)
   //         {
   //             ClientDLL_Model.Cls.Contract.Symbol sym = ClientDLL_Model.Cls.Contract.Symbol.GetSymbol(item.Key);
   //             foreach (QuoteItem item2 in item.Value._lstItem)
   //             {
   //                 //if (item2._MarketLevel == 5)
   //                 //    continue;
   //                 switch (item2._quoteType)
   //                 {
   //                     case QuoteStreamType.ASK:
   //                         {
   //                             if (OnDomEvnt != null)
   //                                 OnDomEvnt(sym.Contract,item2._Price, item2._Size, item2._MarketLevel, "ASK", FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(item2._Time).ToString());
   //                             CreateDepthItems(sym.Contract,item2._Price, item2._Size, item2._MarketLevel, "ASK", FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(item2._Time).ToString());
   //                             #region Commented TWS Code
   //                             // if (item2._MarketLevel == 0)
   //                             // {
   //                             //     if (item2._Price == 0 && item2._Size == 0)
   //                             //     {

   //                             //         //foreach (
   //                             //         //    DataGridViewRow dgr in
   //                             //         //        uctlMarketPicture1.ui_uctlGridRight.Rows)
   //                             //         //{
   //                             //         //    dgr.Cells["ClmPrice"].Value = string.Empty;
   //                             //         //    dgr.Cells["ClmLots"].Value = string.Empty;
   //                             //         //}
   //                             //     }
   //                             //     else
   //                             //     {
   //                             //         //uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //         //    ].Value = item2._Price;
   //                             //         //uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //         //    .Value = item2._Size;
   //                             //     }
   //                             // }
   //                             // else
   //                             // {
   //                             //     if (item2._Price == 0 && item2._Size == 0)
   //                             //     {
   //                             //         // uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //         //    ].Value = string.Empty;
   //                             //         //uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //         //    .Value = string.Empty;
   //                             //     }
   //                             //     else
   //                             //     {
   //                             //         //uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //         //    ].Value = item2._Price;
   //                             //         //uctlMarketPicture1.ui_uctlGridRight.Rows[
   //                             //         //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //         //    .Value = item2._Size;
   //                             //     }
   //                             // }
   //                             //// uctlMarketPicture1.ui_lblLUTValue.Text = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item2._Time);
   //                             #endregion
   //                         }
   //                         break;
   //                     case QuoteStreamType.BID:
   //                         {
   //                             if (OnDomEvnt != null)
   //                                 OnDomEvnt(sym.Contract,item2._Price, item2._Size, item2._MarketLevel, "BID", FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(item2._Time).ToString());
   //                             CreateDepthItems(sym.Contract,item2._Price, item2._Size, item2._MarketLevel, "BID", FundXchange.Domain.Cls.ClsGlobal.GetDateTimeDT(item2._Time).ToString());
   //                             #region Commented TWS Code
   //                             //    if (item2._MarketLevel == 0)
   //                             //    {
   //                             //        if (item2._Price == 0 && item2._Size == 0)
   //                             //        {
   //                             //            //foreach (
   //                             //            //    DataGridViewRow dgr in
   //                             //            //        uctlMarketPicture1.ui_uctlGridLeft.Rows)
   //                             //            //{
   //                             //            //    dgr.Cells["ClmPrice"].Value = string.Empty;
   //                             //            //    dgr.Cells["ClmLots"].Value = string.Empty;
   //                             //            //}
   //                             //        }
   //                             //        else
   //                             //        {
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //            //    ].Value = item2._Price;
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //            //    .Value = item2._Size;
   //                             //        }
   //                             //    }
   //                             //    else
   //                             //    {
   //                             //        if (item2._Price == 0 && item2._Size == 0)
   //                             //        {
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //            //    .Value = string.Empty;
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //            //    ].Value = string.Empty;
   //                             //        }
   //                             //        else
   //                             //        {
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
   //                             //            //    .Value = item2._Size;
   //                             //            //uctlMarketPicture1.ui_uctlGridLeft.Rows[
   //                             //            //    Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
   //                             //            //    ].Value = item2._Price;
   //                             //        }
   //                             //    }
   //                             // // uctlMarketPicture1.ui_lblLUTValue.Text = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item2._Time);
   //                             #endregion
   //                         }

   //                         break;
   //                     case QuoteStreamType.VOLUME:
   //                         {
   //                             //uctlMarketPicture1.ui_lblVolumeValue.Text =
   //                             //    item2._Size.ToString();
   //                         }
   //                         break;
   //                     case QuoteStreamType.VOLUME_PER:
   //                         break;
   //                     default:
   //                         break;
   //                 }

   //             }
   //         }
   //     }

   //     private void CreateDepthItems(string symb, double price, long size, uint mktLevel, string Side, string time)
   //     {
   //         DepthByPrice objDepthBid = new DepthByPrice(_symbol, "OEC");
   //         OrderbookItem Ord = new OrderbookItem();

   //         objDepthBid.Symbol = symb;
   //         objDepthBid.Volume = size;
   //         objDepthBid.Price = price;
   //         objDepthBid.MktLevel = (int)mktLevel;

   //         Ord.OriginalOrderCode = "1";
   //         Ord.Price = price;
   //         Ord.Size = size;
   //         Ord.OrderDate = Convert.ToDateTime(time);

   //         objDepthBid.Orders.Add(Ord);

   //         if (Side == "ASK")
   //         {
   //             RaiseDepthByPriceItemUpdated(objDepthBid, false);
   //         }
   //         else
   //         {
   //             RaiseDepthByPriceItemUpdated(objDepthBid, true);
   //         }

   //     }

   //     public List<DepthByPrice> GetBids()
   //     {
   //         lock (m_lock)
   //         {
   //             return Bids.Values.ToList();
   //         }
   //     }

   //     public List<DepthByPrice> GetOffers()
   //     {
   //         lock (m_lock)
   //         {
   //             return Offers.Values.ToList();
   //         }
   //     }

   //     public Dictionary<string, OrderbookItem> GetOrders()
   //     {
   //         lock (m_lock)
   //         {
   //             return Orders;
   //         }
   //     }

   //     public void InitializeOrderbook(List<OrderbookItem> orders)
   //     {
   //         foreach (OrderbookItem order in orders)
   //         {
   //             AddOrder(order, false);
   //         }

   //         lock (m_lock)
   //         {
   //             if (OrderbookInitializedEvent != null)
   //                 OrderbookInitializedEvent(Bids.Values.ToList(), Offers.Values.ToList());
   //         }
   //     }

   //     public void AddOrder(OrderbookItem order, bool shouldRaiseEvent)
   //     {
   //         lock (m_lock)
   //         {
   //             if (order.ISIN != _isin) return;

   //             if (Orders.ContainsKey(order.OriginalOrderCode))
   //             {
   //                 Orders[order.OriginalOrderCode] = order;
   //                 if (order.Side == OrderSide.Buy)
   //                 {
   //                     UpdateOrder(order, Bids, shouldRaiseEvent);
   //                 }
   //                 else
   //                 {
   //                     UpdateOrder(order, Offers, shouldRaiseEvent);
   //                 }

   //                 if (OrderbookItemUpdatedEvent != null && shouldRaiseEvent)
   //                     OrderbookItemUpdatedEvent(order);
   //             }
   //             else
   //             {
   //                 Orders.Add(order.OriginalOrderCode, order);
   //                 if (order.Side == OrderSide.Buy)
   //                 {
   //                     AddOrder(order, Bids, shouldRaiseEvent);
   //                 }
   //                 else
   //                 {
   //                     AddOrder(order, Offers, shouldRaiseEvent);
   //                 }

   //                 if (OrderbookItemAddedEvent != null && shouldRaiseEvent)
   //                     OrderbookItemAddedEvent(order);
   //             }
   //         }
   //     }

   //     public void RemoveOrder(string orderCode)
   //     {
   //         lock (m_lock)
   //         {
   //             OrderbookItem order = null;
   //             if (!Orders.ContainsKey(orderCode))
   //             {
   //                 Console.WriteLine(string.Format("OrderCode:{0} not found.", orderCode));
   //                 return;
   //             }

   //             order = Orders[orderCode];
   //             Orders.Remove(orderCode);

   //             if (order.Side == OrderSide.Buy)
   //             {
   //                 RemoveOrder(order, Bids);
   //             }
   //             else
   //             {
   //                 RemoveOrder(order, Offers);
   //             }
   //             if (OrderbookItemDeletedEvent != null)
   //                 OrderbookItemDeletedEvent(order);
   //         }
   //     }

   //     public int GetIndexOfDepthItem(DepthByPrice depthByPrice, bool isBuy)
   //     {
   //         if (isBuy)
   //         {
   //             return Bids.IndexOfValue(depthByPrice);
   //         }
   //         else
   //         {
   //             return Offers.IndexOfValue(depthByPrice);
   //         }
   //     }

   //     public bool IsTop5(OrderbookItem order)
   //     {
   //         double orderPrice = order.Price;

   //         if (order.Side == OrderSide.Buy)
   //         {
   //             if (Bids.Count < 5)
   //                 return true;
   //             if (Bids.ContainsKey(orderPrice))
   //             {
   //                 int index = Bids.IndexOfKey(orderPrice);
   //                 return index <= 5;
   //             }
   //             else
   //             {
   //                 return orderPrice > Bids.Keys[4];
   //             }
   //         }
   //         else
   //         {
   //             if (Offers.Count < 5)
   //                 return true;
   //             if (Offers.ContainsKey(orderPrice))
   //             {
   //                 int index = Offers.IndexOfKey(orderPrice);
   //                 return index <= 5;
   //             }
   //             else
   //             {
   //                 return orderPrice > Offers.Keys[4];
   //             }
   //         }
   //     }

   //     // TODO: [LeeM]: This is a hack
   //     public void AddQuote(FundXchange.Domain.ValueObjects.Quote quote)
   //     {
   //         if (quote.Symbol == _symbol)
   //         {
   //             try
   //             {
   //                 UpdateBidsWithQuote(quote);
   //                 UpdateOffersWithQuote(quote);
   //             }
   //             catch (Exception ex)
   //             {
   //                 Console.WriteLine("Error in Orderbook Add Quote Hack: " + ex.ToString());
   //             }
   //         }
   //     }

   //     private void UpdateOffersWithQuote(FundXchange.Domain.ValueObjects.Quote quote)
   //     {
   //         lock (m_lock)
   //         {
   //             if (Offers.Count > 0)
   //             {
   //                 while (Offers.IndexOfKey(quote.BestAskPrice) != 0)
   //                 {
   //                     DepthByPrice[] prices = Offers.Values.ToArray();
   //                     foreach (DepthByPrice price in prices)
   //                     {
   //                         if (price.Price >= quote.BestAskPrice)
   //                             return;

   //                         OrderbookItem[] orders = price.Orders.ToArray();
   //                         foreach (OrderbookItem order in orders)
   //                         {
   //                             RemoveOrder(order.OriginalOrderCode);
   //                         }
   //                     }
   //                 }
   //             }
   //         }
   //     }

   //     private void UpdateBidsWithQuote(FundXchange.Domain.ValueObjects.Quote quote)
   //     {
   //         lock (m_lock)
   //         {
   //             if (Bids.Count > 0)
   //             {   
   //                 while (Bids.IndexOfKey(quote.BestBidPrice) != 0)
   //                 {
   //                     DepthByPrice[] prices = Bids.Values.ToArray();
   //                     foreach (DepthByPrice price in prices)
   //                     {
   //                         if (price.Price <= quote.BestBidPrice)
   //                             return;

   //                         OrderbookItem[] orders = price.Orders.ToArray();
   //                         foreach (OrderbookItem order in orders)
   //                         {
   //                             RemoveOrder(order.OriginalOrderCode);
   //                         }
   //                     }
   //                 }
   //             }
   //         }
   //     }

   //     public OrderbookItem GetOrder(string OriginalOrderCode)
   //     {
   //         if (Orders.ContainsKey(OriginalOrderCode))
   //             return Orders[OriginalOrderCode];

   //         return null;
   //     }

   //     private void AddOrder(OrderbookItem order, SortedList<double, DepthByPrice> ordersByPrice, bool shouldRaiseEvent)
   //     {
   //         double orderPrice = order.Price;
   //         bool isAdd = false;

   //         if (!ordersByPrice.ContainsKey(orderPrice))
   //         {
   //             DepthByPrice depthItem = new DepthByPrice(_symbol, _exchange);
   //             depthItem.Price = orderPrice;
   //             ordersByPrice.Add(orderPrice, depthItem);

   //             isAdd = true;
   //         }
   //         ordersByPrice[orderPrice].Orders.Add(order);
   //         ordersByPrice[orderPrice].Volume += order.Size;

   //         if (shouldRaiseEvent)
   //         {
   //             if (isAdd)
   //             {
   //                 RaiseDepthByPriceItemAdded(ordersByPrice[orderPrice], (order.Side == OrderSide.Buy));
   //             }
   //             else
   //             {
   //                 RaiseDepthByPriceItemUpdated(ordersByPrice[orderPrice], (order.Side == OrderSide.Buy));
   //             }
   //             RaiseDepthByPriceChanged(Bids.Values.ToList(), Offers.Values.ToList());
   //         }
   //     }

   //     private void UpdateOrder(OrderbookItem order, SortedList<double, DepthByPrice> ordersByPrice, bool shouldRaiseEvent)
   //     {
   //         double orderPrice = order.Price;

   //         if (!ordersByPrice.ContainsKey(orderPrice)) return;

   //         OrderbookItem currentOrderDetails = ordersByPrice[orderPrice].Orders.Find(o => o.OriginalOrderCode == order.OriginalOrderCode);

   //         if (currentOrderDetails != null)
   //         {
   //             long volumeDifference = order.Size - currentOrderDetails.Size;

   //             ordersByPrice[orderPrice].Orders[ordersByPrice[orderPrice].Orders.IndexOf(currentOrderDetails)] = order;
   //             ordersByPrice[orderPrice].Volume += volumeDifference;

   //             if (shouldRaiseEvent)
   //             {
   //                 RaiseDepthByPriceItemUpdated(ordersByPrice[orderPrice], (order.Side == OrderSide.Buy));
   //                 RaiseDepthByPriceChanged(Bids.Values.ToList(), Offers.Values.ToList());
   //             }
   //         }
   //     }

   //     private void RemoveOrder(OrderbookItem order, SortedList<double, DepthByPrice> ordersByPrice)
   //     {
   //         double orderPrice = order.Price;

   //         if (!ordersByPrice.ContainsKey(orderPrice)) return;

   //         ordersByPrice[orderPrice].Orders.Remove(order);
   //         ordersByPrice[orderPrice].Volume -= order.Size;

   //         if (ordersByPrice[orderPrice].Volume <= 0)
   //         {
   //             DepthByPrice depthByPrice = ordersByPrice[orderPrice];

   //             ordersByPrice.Remove(orderPrice);

   //             RaiseDepthByPriceItemDeleted(depthByPrice, (order.Side == OrderSide.Buy));
   //         }
   //         else
   //         {
   //             RaiseDepthByPriceItemUpdated(ordersByPrice[orderPrice], (order.Side == OrderSide.Buy));
   //         }

   //         RaiseDepthByPriceChanged(Bids.Values.ToList(), Offers.Values.ToList());
   //     }

   //     private void RaiseDepthByPriceItemAdded(DepthByPrice depthItem, bool isBuy)
   //     {
   //         if (null != DepthByPriceItemAddedEvent)
   //         {
   //             DepthByPrice clone = (DepthByPrice)depthItem.Clone();
   //             DepthByPriceItemAddedEvent(clone, isBuy);
   //         }
   //     }

   //     private void RaiseDepthByPriceItemUpdated(DepthByPrice depthItem, bool isBuy)
   //     {
   //         if (null != DepthByPriceItemUpdatedEvent)
   //         {
   //             DepthByPrice clone = (DepthByPrice)depthItem.Clone();
   //             DepthByPriceItemUpdatedEvent(clone, isBuy);
   //         }
   //     }

   //     private void RaiseDepthByPriceItemDeleted(DepthByPrice depthItem, bool isBuy)
   //     {
   //         if (null != DepthByPriceItemDeletedEvent)
   //         {
   //             DepthByPrice clone = (DepthByPrice)depthItem.Clone();
   //             DepthByPriceItemDeletedEvent(clone, isBuy);
   //         }
   //     }

   //     private void RaiseDepthByPriceChanged(IEnumerable<DepthByPrice> bids, IEnumerable<DepthByPrice> offers)
   //     {
   //         if (null != DepthByPriceChangedEvent)
   //         {
   //             List<DepthByPrice> clonedBids = CopyIt(bids);
   //             List<DepthByPrice> clonedOffers = CopyIt(offers);

   //             DepthByPriceChangedEvent(clonedBids, clonedOffers);
   //         }
   //     }

   //     private static List<DepthByPrice> CopyIt(IEnumerable<DepthByPrice> src)
   //     {
   //         List<DepthByPrice> copy = new List<DepthByPrice>();
   //         foreach (DepthByPrice depthByPrice in src)
   //         {
   //             copy.Add((DepthByPrice)depthByPrice.Clone());
   //         }
   //         return copy;
   //     }
   // }

   // public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
   //{
   //   public int Compare(T x, T y)
   //   {
   //      return y.CompareTo(x);
   //   }
   // }
}
