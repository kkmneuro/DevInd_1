using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using PALSA.Cls;


namespace PALSA.ClsRadar
{
    public delegate void CandleChangedDelegate(string identifier, Candlestick candle);
    public delegate void CandleInitializedDelegate(string identifier, List<Candlestick> candles);

    public interface ICandlestickAgent
    {
        string Identifier { get; }
        event CandleChangedDelegate CandleAdded;
        event CandleChangedDelegate CandleUpdated;
        event CandleChangedDelegate CandleClosed;
        event CandleInitializedDelegate CandleInitialized;
        void Subscribe(string symbol, string exchange, int numBars, int barIntervalInMinutes, PALSA.Cls.PeriodEnum period);
        List<Candlestick> GetItems();
        bool Equals(object obj);
        Candlestick LatestCandle { get; }
    }

    public class CandlestickAgent : ICandlestickAgent
    {
        private Instrument _instrument;
        private SortedList<DateTime, Candlestick> _Items = new SortedList<DateTime, Candlestick>();

        //in minutes
        private int _barInterval;
        private Candlestick _currentCandle;
        //Kulprivate List<Trade> _replayTrades = new List<Trade>();
        private Thread _candleGenerationThread;
        private bool _hasOpen = true;

        public string Identifier { get; private set; }

        public Candlestick LatestCandle
        {
            get
            {
                return _currentCandle;
            }
        }

        public event CandleChangedDelegate CandleAdded;
        public event CandleChangedDelegate CandleUpdated;
        public event CandleChangedDelegate CandleClosed;
        public event CandleInitializedDelegate CandleInitialized;

        public CandlestickAgent()
            : this(Guid.NewGuid().ToString()) { }

        public CandlestickAgent(string identifier)
        {
            //SubscribeToLevel1Events();//By Kuldeep
            Identifier = identifier;
        }

        public void Subscribe(string symbol, string exchange, int numBars, int barIntervalInMinutes, PALSA.Cls.PeriodEnum period)
        {
            if (String.IsNullOrEmpty(symbol))
                throw new ApplicationException("Symbol cannot be Null or Empty when subscribing to Candlestick Agent");

            //if (String.IsNullOrEmpty(exchange))//Commented By Kuldeep
            //    throw new ApplicationException("Exchange cannot be Null or Empty when subscribing to Candlestick Agent");

            //int count = 0;//Kul_repository.AllInstrumentReferences.Where(i => i.Symbol == symbol).Count();
            //if (count == 0)
            //    throw new ApplicationException("Invalid symbol specified with subscribe to Candlestick Agent");

            if (numBars < 10)
                throw new ApplicationException("Invalid number of bars specified. At least 10 bars needed.");

            if (_instrument == null || symbol != _instrument.Symbol)
            {
                _barInterval = barIntervalInMinutes;
                _Items = new SortedList<DateTime, Candlestick>();

                Instrument instrument = new Instrument();//Kul_repository.SubscribeLevelOneWatch(symbol, exchange);
                _instrument = instrument;
                _instrument.Symbol = symbol;

                List<Candlestick> candlesticks = GetCandleSticks(symbol, exchange, barIntervalInMinutes, numBars, period);//kul_repository.GetEquityCandlesticks(symbol, exchange, barIntervalInMinutes, numBars, period);
                ProcessCandlesticks(candlesticks);

                if (CandleInitialized != null)
                {
                    CandleInitialized(symbol, _Items.Values.ToList());
                }
                CreateCandlestickThread();

                SubscribeToLevel1Events();//By Kuldeep
            }
        }

        private List<Candlestick> GetCandleSticks(string symbol, string exchange, int barIntervalInMinutes, int numBars, PALSA.Cls.PeriodEnum period)
        {
            List<OHLC> _lstOHLC = new List<OHLC>();
            _lstOHLC = clsTWSDataManagerJSON.INSTANCE.GetOHLC(DateTime.UtcNow, symbol, barIntervalInMinutes, numBars.ToString(), (int)period);
            if (_lstOHLC.Count > 0)
            {
                List<Candlestick> lstCandles = new List<Candlestick>();
                foreach (var item in _lstOHLC)
                {
                    Candlestick candle = new Candlestick();
                    candle.Open = item._Open;
                    candle.High = item._High;
                    candle.Low = item._Low;
                    candle.Close = item._Close;
                    candle.Volume = item._Volume;
                    candle.TimeOfStart = item._OHLCTime;
                    lstCandles.Add(candle);
                }
                return lstCandles;
            }
            else
            {
                //No data from Service
                return new List<Candlestick>();
            }
        }

        public void Unsubscribe()
        {
            if(null != _candleGenerationThread && _candleGenerationThread.IsAlive)
                _candleGenerationThread.Abort();
        }

        private void CreateCandlestickThread()
        {
            if (_instrument != null)
            {
                _candleGenerationThread = new Thread(GenerateCandles);
                _candleGenerationThread.Name = String.Format("CandleGenerationThread_{0}", _instrument.Symbol);
                _candleGenerationThread.IsBackground = true;
                _candleGenerationThread.Start();
            }
        }

        private void GenerateCandles()
        {
            while (true)
            {
                if (!IsTradingDay())
                {
                    Thread.Sleep(30000);
                }
                else
                {
                    DateTime currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, 0);
                    DateTime beginningOfDay = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 9, 0, 0);
                    TimeSpan timeDiff = currentDate - beginningOfDay;
                    if (timeDiff.TotalMinutes % _barInterval == 0)
                    {
                        int interval = _barInterval;
                        if (interval == 480)
                            interval = (480 * 3);

                        _currentCandle.TimeOfClose = _currentCandle.TimeOfStart.AddMinutes(interval);
                        
                        _Items[_currentCandle.TimeOfStart] = _currentCandle;
                        
                        if (CandleClosed != null)
                        {
                            CandleClosed(_currentCandle.Symbol, _currentCandle);
                        }

                        _currentCandle.TimeOfStart = _currentCandle.TimeOfClose;
                        _currentCandle.Open = _currentCandle.Close;
                        _currentCandle.High = _currentCandle.Close;
                        _currentCandle.Low = _currentCandle.Close;
                        _currentCandle.Close = _currentCandle.Close;
                        _currentCandle.Volume = 0;
                        _hasOpen = false;

                        if (!_Items.ContainsKey(_currentCandle.TimeOfStart))
                        {
                            _Items.Add(_currentCandle.TimeOfStart, _currentCandle);                            
                        }

                        if (CandleAdded != null)
                        {
                            CandleAdded(_currentCandle.Symbol, _currentCandle);
                        }
                    }
                }
                Thread.Sleep(30000);
            }
        }

        private bool IsTradingDay()
        {
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday)
                return false;
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Sunday)
                return false;
            if (DateTime.UtcNow.Hour > 17)
                return false;
            if (DateTime.UtcNow.Hour == 17 && DateTime.UtcNow.Minute > 0)
                return false;
            if (DateTime.UtcNow.Hour < 9)
                return false;
            return true;
        }

        private void SubscribeToLevel1Events()
        {//Namo 21 March
         //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
         //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;

        }

        void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)
        {
            //Namo 21 March
            //foreach (var item in obj)
            //{
            //    string[] str = item.Key.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            //    //var alrt = lstAlerts_.Find(i => i.Symbol == str[str.Count() - 1]);
            //    if (str[str.Count() - 1] == _instrument.Symbol)
            //    {
            //        QuoteItem BID = item.Value._lstItem.Find(i => i._quoteType == QuoteStreamType.BID);
            //        if (BID != null)//Update from Bid Price
            //        {
            //            ProcessQuotes(BID);
            //        }
            //        //foreach (QuoteItem quoteItem in item.Value._lstItem)
            //        //{
            //        //    //ProcessQuotes()
            //        //}
            //    }
            //}
        }
        //Namo 21 March
        //private void ProcessQuotes(QuoteItem BID)
        //{
        //    if (null != _currentCandle)
        //    {
        //        if (ClsGlobal.GetDateTimeDT(BID._Time)>= _currentCandle.TimeOfStart)
        //        {
        //            _currentCandle.TimeOfClose = ClsGlobal.GetDateTimeDT(BID._Time);
        //            _currentCandle.Volume += BID._Size;

        //            if (!_hasOpen)
        //                _currentCandle.Open = BID._Price;
        //            if (BID._Price > _currentCandle.High)
        //                _currentCandle.High = BID._Price;
        //            if (BID._Price < _currentCandle.Low || _currentCandle.Low == 0)
        //                _currentCandle.Low = BID._Price;
        //            _currentCandle.Close = BID._Price;
        //            _currentCandle.LastTrade = BID._Price;

        //            if (!_Items.ContainsKey(_currentCandle.TimeOfStart))
        //                _Items.Add(_currentCandle.TimeOfStart, _currentCandle);
        //            else
        //                _Items[_currentCandle.TimeOfStart] = _currentCandle;

        //            if (CandleUpdated != null)
        //            {
        //                CandleUpdated(_currentCandle.Symbol, _currentCandle);
        //            }
        //        }
        //        else
        //        {
        //            DateTime previousCandleStartTime = _currentCandle.TimeOfStart.AddMinutes(-_barInterval);//By Kuldeep

        //            if (!_Items.ContainsKey(_currentCandle.TimeOfStart))
        //                _Items.Add(previousCandleStartTime, _currentCandle);

        //            if (BID._Price > _Items[previousCandleStartTime].High)
        //                _Items[previousCandleStartTime].High = BID._Price;
        //            if (BID._Price < _Items[previousCandleStartTime].Low || _Items[previousCandleStartTime].Low == 0)
        //                _Items[previousCandleStartTime].Low = BID._Price;
        //            _Items[previousCandleStartTime].Close = BID._Price;
        //            _Items[previousCandleStartTime].Volume += BID._Size;

        //            if (CandleUpdated != null)
        //            {
        //                CandleUpdated(_Items[previousCandleStartTime].Symbol, _Items[previousCandleStartTime]);
        //            }
        //        }
        //    }
        //}

        //void _marketRepository_TradeOccurredEvent(Trade trade)
        //{
        //    if(_instrument == null) return;
        //    if (trade.Symbol == _instrument.Symbol)
        //    {
        //        ProcessTrade(trade);
        //    }
        //}

        //private void ProcessTrade(Trade trade)
        //{
        //    if (null != _currentCandle)
        //    {
        //        if (trade.TimeStamp >= _currentCandle.TimeOfStart)
        //        {
        //            _currentCandle.TimeOfClose = trade.TimeStamp;
        //            _currentCandle.Volume += trade.Volume;

        //            if (!_hasOpen)
        //                _currentCandle.Open = trade.Price;
        //            if (trade.Price > _currentCandle.High)
        //                _currentCandle.High = trade.Price;
        //            if (trade.Price < _currentCandle.Low || _currentCandle.Low == 0)
        //                _currentCandle.Low = trade.Price;
        //            _currentCandle.Close = trade.Price;
        //            _currentCandle.LastTrade = trade.Price;

        //            if(!_Items.ContainsKey(_currentCandle.TimeOfStart))
        //                _Items.Add(_currentCandle.TimeOfStart, _currentCandle);
        //            else
        //                _Items[_currentCandle.TimeOfStart] = _currentCandle;

        //            if (CandleUpdated != null)
        //            {
        //                CandleUpdated(_currentCandle.Symbol, _currentCandle);
        //            }
        //        }
        //        else
        //        {
        //            DateTime previousCandleStartTime = _currentCandle.TimeOfClose;//_currentCandle.TimeOfStart.AddMinutes(-_barInterval);//By Kuldeep

        //            if (!_Items.ContainsKey(_currentCandle.TimeOfStart))
        //                _Items.Add(previousCandleStartTime, _currentCandle);

        //            if (trade.Price > _Items[previousCandleStartTime].High)
        //                _Items[previousCandleStartTime].High = trade.Price;
        //            if (trade.Price < _Items[previousCandleStartTime].Low || _Items[previousCandleStartTime].Low == 0)
        //                _Items[previousCandleStartTime].Low = trade.Price;
        //            _Items[previousCandleStartTime].Close = trade.Price;
        //            _Items[previousCandleStartTime].Volume += trade.Volume;

        //            if (CandleUpdated != null)
        //            {
        //                CandleUpdated(_Items[previousCandleStartTime].Symbol, _Items[previousCandleStartTime]);
        //            }
        //        }
        //    }
        //}

        private void ProcessCandlesticks(List<Candlestick> candles)
        {
            foreach (Candlestick candle in candles)
            {
                candle.TimeOfClose = candle.TimeOfStart.AddMinutes(_barInterval);//Kuldeep

                if (!_Items.ContainsKey(candle.TimeOfClose))
                {
                    _Items.Add(candle.TimeOfClose, candle);
                }
            }
            if (candles.Count > 0)
            {
                Candlestick lastCandle = candles.Last();
                _currentCandle = lastCandle;
            }
        }

        public List<Candlestick> GetItems()
        {
            return _Items.Values.ToList();
        }

        public override bool Equals(object obj)
        {
            return (obj as CandlestickAgent).Identifier == this.Identifier;
        }
    }
}
