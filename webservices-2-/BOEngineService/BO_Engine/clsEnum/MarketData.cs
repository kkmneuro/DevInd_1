using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace clsInterface4OME
{
    public class MarketDataDepth
    {
        public MarketDataDepth(int _depth, string _instrument)
        {
            marketdepth = ++GlobalDepth;
            depth = _depth;
            instrument = _instrument;
        }
        public DicW4<double, int> BuySide;
        public DicW4<double, int> SellSide;
        public long marketdepth;
        public int depth;
        public string instrument;
        public static long GlobalDepth;
    }
    [Serializable]
    public class LTP_Trend
    {
        public double LTP;
        public int Qty;
        public Side side;
        public string Instrument;
        public DateTime LTP_Time;

        public LTP_Trend()
        {
            LTP = 0;
            Qty = 0;
            side = Side.NA;
            Instrument = string.Empty;
            LTP_Time = DateTime.UtcNow;
        }

        public override string ToString()
        {
            string temp = 
                ":Instrument=" + Instrument 
                + "LTP_Trend:LTP=" + LTP
                + "LTP TIME " + LTP_Time 
                + ":Qty=" + Qty 
                + ":side=" + side               
                
                + "\n";
            return temp;
        }
    }
}
