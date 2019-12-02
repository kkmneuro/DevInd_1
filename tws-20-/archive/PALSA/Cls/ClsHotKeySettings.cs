using System;

namespace TWS.Cls
{
    [Serializable]
    public class ClsHotKeySettings
    {
        public string BUY_ORDER_ENTRY { get; set; }

        public string SELL_ORDER_ENTRY { get; set; }

        public string ORDER_BOOK { get; set; }

        public string MARKET_WATCH { get; set; }

        public string FILTER { get; set; }

        public string MARKET_PICTURE { get; set; }

        public string TRADES { get; set; }

        public string MODIFIED_TRADES { get; set; }

        public string MESSAGE_LOG { get; set; }

        public string LOG_IN { get; set; }

        public string LOG_OFF { get; set; }

        public string FILTER_BAR { get; set; }

        public string PREFERENCES { get; set; }

        public string LOCK_WORKSTATION { get; set; }

        public string NET_POSITION { get; set; }

        public string SNAP_QUOTE { get; set; }

        public string PORTFOLIO { get; set; }

        public string MODIFY_ORDER { get; set; }

        public string CANCEL_SELECTED_ORDERS { get; set; }

        public string CANCEL_ALL_ORDERS { get; set; }

        public string PRODUCT_INFORMATION { get; set; }

        public string TICKER { get; set; }

        public string TOP_GAINERS_LOSERS { get; set; }


        public string STATUS_BAR { get; set; }

        #region "         CONSTRUCTOR              "

        public ClsHotKeySettings(string buyOrderEntry, string sellOrderEntry,
                                 string orderBook, string marketWatch, string filter, string marketPicture,
                                 string trades, string modifiedTrades, string messageLog, string logIn,
                                 string logOff, string filterBar, string preferences,
                                 string lockWorkstation, string netPosition, string snapQuote, string portfolio,
                                 string modifyOrder,string cancelSelectedOrder,
                                 string cancelAllOrders, string productInformation, string ticker,
                                 string topGainersLosers, string statusBar)
        {
            BUY_ORDER_ENTRY = buyOrderEntry;
            SELL_ORDER_ENTRY = sellOrderEntry;
            ORDER_BOOK = orderBook;
            MARKET_WATCH = marketWatch;
            FILTER = filter;
            MARKET_PICTURE = marketPicture;
            TRADES = trades;
            MODIFIED_TRADES = modifiedTrades;
            MESSAGE_LOG = messageLog;
            LOG_IN = logIn;
            LOG_OFF = logOff;
            FILTER_BAR = filterBar;
            PREFERENCES = preferences;
            LOCK_WORKSTATION = lockWorkstation;
            NET_POSITION = netPosition;
            SNAP_QUOTE = snapQuote;
            PORTFOLIO = portfolio;
            MODIFY_ORDER = modifyOrder;
            CANCEL_SELECTED_ORDERS = cancelSelectedOrder;
            CANCEL_ALL_ORDERS = cancelAllOrders;
            PRODUCT_INFORMATION = productInformation;
            TICKER = ticker;
            TOP_GAINERS_LOSERS = topGainersLosers;
            STATUS_BAR = statusBar;
        }

        #endregion
    }
}