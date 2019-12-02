using System;

namespace PALSA.Cls
{
    [Serializable]
    public class BarDataNew
    {
        public DateTime StartDateTime;
        public DateTime TradeDateTime;
        public DateTime CloseDateTime;
        public double OpenPrice;
        public double HighPrice;
        public double LowPrice;
        public double ClosePrice;
        public double Volume;
        public long CloseSequenceNumber { get; set; }
    }
}
