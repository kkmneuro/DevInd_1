namespace PALSA.Cls
{
    public class ClsOrderEntry
    {
        #region    "        PROPERTY          "

        public int InstrumentName { get; set; }
        public string ExpiryDate { get; set; }
        public string OrderType { get; set; }
        public string OptionType { get; set; }
        public string Symbol { get; set; }
        public string Series { get; set; }
        public string StrikePrice { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public bool DQuantity { get; set; }
        public int AccountType { get; set; }
        public string ClientName { get; set; }
        public bool Client { get; set; }
        public int PartnerOminiId { get; set; }
        public string TrigPrice { get; set; }
        public bool UserRemark { get; set; }
        public int Validity { get; set; }
        public int ClientNameEnable { get; set; }

        #endregion    "        PROPERTY          "
    }
}