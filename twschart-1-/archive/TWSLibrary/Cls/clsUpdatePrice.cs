using System.Drawing;

namespace CommonLibrary.Cls
{
    public class ClsUpdatePrice
    {
        public string ContractInfoKey { get; set; }
        public double BuyPrice { get; set; }
        public Color BuyColor { get; set; }
        public double SellPrice { get; set; }
        public Color SellColor { get; set; }
        public string BuyImagePath { get; set; }
        public string SellImagePath { get; set; }
    }
}