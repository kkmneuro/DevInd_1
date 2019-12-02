using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PALSA.Cls
{
    public static class clsOHLC
    {
        public static IEnumerable<BarDataNew> GetOHLCData(string symbol, int period, int intervl, string Bars)
        {
            LstOHLC objOHLC = new LstOHLC();
            List<OHLC> _lstOHLC = objOHLC.GetOHLC(DateTime.UtcNow.ToString(), symbol, intervl, Bars, period);

            if (_lstOHLC.Count > 0)
            {
                List<BarDataNew> snapshots = TransformToBarData(_lstOHLC);
                return snapshots;
            }
            return new List<BarDataNew>();
        }

        private static List<BarDataNew> TransformToBarData(List<OHLC> ohlc)
        {
            List<BarDataNew> barData = new List<BarDataNew>();
            DateTime now = DateTime.UtcNow;
            DateTime startOfTradeDay = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0);


            foreach (var item in ohlc)
            {
                DateTime convertedDT = item._OHLCTime;
                item._OHLCTime = convertedDT;
            }


            TimeSpan dtDiff = Convert.ToDateTime(ohlc[0]._OHLCTime) - Convert.ToDateTime(ohlc[1]._OHLCTime);

            //List<OHLC> lstOHLC = GetUpdatedOHLC(ohlc);
            foreach (var item in ohlc)
            {
                BarDataNew bar = new BarDataNew();

                bar.OpenPrice = item._Open;
                bar.ClosePrice = item._Close;
                bar.HighPrice = item._High;
                bar.LowPrice = item._Low;
                bar.StartDateTime = Convert.ToDateTime(item._OHLCTime);
                bar.CloseDateTime = Convert.ToDateTime(item._OHLCTime).Subtract(dtDiff);

                bar.TradeDateTime = bar.CloseDateTime;
                bar.Volume = item._Volume;

                //if (bar.CloseDateTime >= startOfTradeDay)
                //{
                //    bar.CloseSequenceNumber = candlestick.CloseSequenceNumber;
                //}
                barData.Add(bar);
            }

            return barData;
        }

        private static List<OHLC> GetUpdatedOHLC(List<OHLC> ohlc)
        {
            TimeSpan dtDiff = Convert.ToDateTime(ohlc[0]._OHLCTime) - Convert.ToDateTime(ohlc[1]._OHLCTime);
            DateTime x = DateTime.UtcNow;
            //Namo 21 March
            //for (int i = ohlc.Count - 1; i >= 0; i--)
            //{
            //    ohlc[i]._OHLCTime = x.ToString();
            //    x = x.Add(dtDiff);
            //}
            return ohlc;
        }
    }

    public enum ePeriodicity : byte
    {
        Secondly = 9,
        Minutely_1 = 0,
        Minutely_5 = 1,
        Minutely_15 = 2,
        Minutely_30 = 3,
        Hourly_1 = 4,
        Hourly_4 = 5,
        Daily = 6,
        Weekly = 7,
        Monthly = 8
    }

    public class OHLC
    {
        public double _Close;
        public double _High;
        public double _Low;
        public DateTime _OHLCTime;
        public double _Open;
        public long _Volume;
    }
    public class LstOHLC
    {
        public int size;

        

        public List<OHLC> GetOHLC(string EndDate, string Symbol, int interval, string Bars, int period)
        {
            return new List<OHLC>();
        }
    }
    public enum NewHistoryType
    {
        YEAR = 0,
        QUARTER = 1,
        MONTH = 2,
        DAY = 3,
        WEEK = 4,
        HOUR = 5,
        MINUTE = 6,
        SECOND = 7,
        TICK = 8,
        VOLUME = 9
    }

    public enum ChartType
    {
        BAR,
        CANDLE,
        LINE
    }

    public enum PriceType
    {
        POINT_AND_FIGURE,
        RENKO,
        KAGI,
        THREE_LINE_BREAK,
        EQUI_VOLUME,
        EQUI_VOLUME_SHADOW,
        CANDLE_VOLUME,
        HEIKIN_ASHI,
        STANDARD_CHART,
    }

    internal class OHLCEntity
    {
        private readonly TimeSpan TS_;
        private double Close_;
        private double High_;
        private double Low_;
        private DateTime NextOHLCTime_;
        private DateTime OHLCTime_;
        private double Open_;
        private double Volume_;
        private int _Counter;

        public OHLCEntity(double Price, double Volume, DateTime CurrDT, TimeSpan ts)
        {
            Open_ = Price;
            High_ = Price;
            Low_ = Price;
            Close_ = Price;
            Volume_ = Volume;
            OHLCTime_ = CurrDT;
            NextOHLCTime_ = OHLCTime_ + ts;
            TS_ = ts;
            _Counter = 1;
        }

        public double OPEN
        {
            get { return Open_; }
            set { Open_ = value; }
        }

        public double HIGH
        {
            get { return High_; }
            set { High_ = Math.Max(High_, value); }
        }

        public double LOW
        {
            get { return Low_; }
            set { Low_ = Math.Min(Low_, value); }
        }

        public double CLOSE
        {
            get { return Close_; }
            set { Close_ = value; }
        }

        public double VOLUME
        {
            get { return Volume_; }
            set { Volume_ = Volume_ + value; }
        }

        public bool UpdateValues(double Price, double Volume, DateTime DT,
                                 out double o, out double h, out double l,
                                 out double c, out double v, out DateTime OHLCTIME)
        {
            bool status = false;
            o = 0.0;
            h = 0.0;
            l = 0.0;
            c = 0.0;
            v = 0.0;
            OHLCTIME = DateTime.UtcNow; //DateTime.UtcNow;
            if (DT >= NextOHLCTime_)
            {
                status = true;
                OPEN = CLOSE; //by vijay
                CLOSE = Price; //by vijay
                o = OPEN;
                h = HIGH;
                l = LOW;
                c = CLOSE;
                v = VOLUME;
                Open_ = High_ = Low_ = Close_ = Price;
                v = _Counter; //v;
                _Counter = 1;
                OHLCTIME = NextOHLCTime_;
                OHLCTime_ = NextOHLCTime_;
                NextOHLCTime_ = OHLCTime_ + TS_;
            }
            else
            {
                HIGH = Price;
                LOW = Price;
                VOLUME = Volume;
                o = OPEN;
                h = HIGH;
                l = LOW;
                //if (DT >= NextOHLCTime_ - TimeSpan.FromSeconds(1))
                //{
                //    c = Price; //Price; //CLOSE;
                //}
                //else
                //{
                //    c = CLOSE;
                //}
                CLOSE = Price; //by vijay
                c = Price; //CLOSE;
                v = VOLUME;
                ++_Counter;
            }
            return status;
        }
    }
}
