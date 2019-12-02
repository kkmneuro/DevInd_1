using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOADMIN_NEW.Cls
{
    public class clsEnums
    {
        public enum TextType { Numeric, Real, MailAdd, Phone, Alphabet, AlphaNumeric,All,IP};
        public enum CommandIDS
        {
            CONTRACT_SPECIFICATION=0 , 
            CLIENTS=1, 
            TRADING_GATEWAY=2, 
            IP_ACCESS=3,
            HOLIDAYS=4,
            TIME_SETTINGS=5, 
            FEE_MASTER=6,
            TAX_MASTER=7,
            BROKER=8,
            ORDERS=9,
            TRADES=10,
            COLLATERAL=11,

            LOGIN = 12,
            LOGOFF=13,
            EXIT=14,
            CLOSE=15,
            CLOSE_ALL=16,
            CASCADE=17,
            TILE_HORIZONTALLY=18,
            TILE_VERTICALLY=19,
            MAP_ORDERS,
            COMMON_SETTINGS,
            VIRTUAL_DEALER,
            TRADE_REPORT,
            ORDER_REPORT,
            CLIENT_COMMISSION_REPORT,
            STOCK_LEVEL_REPORT,
            CLIENT_HOSTING_REPORT,
            MARGIN_REPORT,
            TOP_TRADED_INSTRUMENTS,
            NEW_CLIENT_INFO_REPORT,
            ACCOUNT_TRANS_REPORT,
            CHANGE_PASSWORD,
            CLOSE_PRICED_MANAGEMENT,
            DAY_CLOSING_REPORT,
            TICK_MANAGER,
            CLIENT_MARGIN_REPORT,
            ACCOUNT,
            OPERATIONS_LOG,
            EDIT_ACCOUNT_TRANS,
            FORCE_LOGOUT,
            OPEN_POSITION_REPORT
        }
        public enum VIEW_MODE
        {
            COMMON = 0,
            IPACESSLIST,
            DATASERVERS,
            TIME,
            HOLIDAYS,
            SYMBOLS,
            SECURITIES,
            GROUPS,
            MANAGERS,
            DATAFEEDS,
            BACKUP,
            LIVEUPDATE,
            SYNCHRONIZATIONS,
            PLUGINS,
            ACCOUNTS,
            ORDERS,
            CHARTS,
            TICKS,
            JOURNALS,
            NA
        }

        public enum FRM_MODE
        {
            EDIT,
            ADD,
            NA
        }
    }
}
