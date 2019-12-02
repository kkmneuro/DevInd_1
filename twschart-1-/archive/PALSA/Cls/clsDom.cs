using System;

namespace PALSA.Cls
{
    public class ClsDom
    {
        public string ContractExpiryDate { get; set; }
        public double BuyPrice { get; set; }
        public Int64 BuyQty { get; set; }
        public double SellPrice { get; set; }
        public Int64 SellQty { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
    }
}