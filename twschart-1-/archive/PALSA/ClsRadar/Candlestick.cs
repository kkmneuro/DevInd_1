using System;
//using FundXchange.Domain.Base;

namespace PALSA.ClsRadar
{
    public class Candlestick //: InstrumentBase
    {
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public double LastTrade { get; set; }
        public DateTime TimeOfClose { get; set; }
        public DateTime TimeOfStart { get; set; }
        public long CloseSequenceNumber { get; set; }
        public string Symbol { get; set; }

    }
}
