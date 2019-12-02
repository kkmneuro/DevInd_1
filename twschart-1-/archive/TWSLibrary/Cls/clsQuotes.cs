﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Cls
{
    public class clsQuotes
    {
        public string Key { get; set; }
        public string Symbol { get; set; }
        public int Digits { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public Int32 ProfitLoss { get; set; }
        public double PCT { get; set; }
        public double HighValue { get; set; }
        public double LowValue { get; set; }
        public double AveragePrice { get; set; }
        public bool SellUp{get;set;}
        public bool BuyUp { get; set; }
        public Int32 Position { get; set; }
    }
}
