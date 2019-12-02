using System.Collections;

namespace CommonLibrary.Cls
{
    public struct ClsDefaultHotKeySettings
    {
        private static Hashtable _degaulthotKeySettingsHashTable;

        public static Hashtable GetDefaultHotKeySettings()
        {
            _degaulthotKeySettingsHashTable = new Hashtable
                                                  {
                                                      {"PLACE_BUY_ORDER", "F1"},
                                                      {"PLACE_SELL_ORDER", "F2"},
                                                      {"ORDER_BOOK", "F3"},
                                                      {"MARKET_WATCH", "F4"},
                                                      {"FILTER", "F5"},
                                                      {"MARKET_PICTURE", "F6"},
                                                      {"TRADE", "F8"},
                                                      {"MODIFIED_TRADES", "F9"},
                                                      {"MESSAGE_LOG", "F10"},
                                                      {"LOGIN", "CTRL+L"},
                                                      {"LOGOFF", "CTRL+O"},
                                                      {"FILTER_BAR", "CTRL+S"},
                                                      {"PREFERENCES", "CTRL+R"},
                                                      {"LOCK_WORKSTATION", "CTRL+W"},
                                                      {"NET_POSITION", "CTRL+F6"},
                                                      {"SNAP_QUOTE", "ALT+F9"},
                                                      {"PORTFOLIO", "SHIFT+P"},
                                                      {"MODIFY_ORDER", "SHIFT+F2"},
                                                      {"CANCEL_SELECTED_ORDERS", "SHIFT+F3"},
                                                      {"CANCEL_ALL_ORDERS", "SHIFT+F4"},
                                                      {"CONTRACT_INFORMATION", "SHIFT+F8"},
                                                      {"TICKER", "CTRL+SHIFT+F4"},
                                                      {"TOP_GAINERS_LOSERS", "CTRL+SHIFT+F8"},
                                                      {"STATUS_BAR", "CTRL+SHIFT+S"}
                                                  };

            return _degaulthotKeySettingsHashTable;
        }
    }
}