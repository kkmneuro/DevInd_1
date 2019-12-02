namespace CommonLibrary.Cls
{
    public partial class ClsLocalizationHandler
    {
        #region    "       PROPERTY          "

        public static string LangaugeCode
        {
            get { return _languageCode; }
            set { _languageCode = value; }
        }

        public static string Selected
        {
            get { return _selected; }
        }

        public static string Select
        {
            get { return _select; }
        }

        public static ClsLocalizationHandler INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClsLocalizationHandler();
                }
                return _instance;
            }
        }

        public static string Window
        {
            get { return _window; }
        }

        public static string Exchange
        {
            get { return _exchange; }
        }

        public static string Market
        {
            get { return _market; }
        }

        public static string Type
        {
            get { return _type; }
        }

        public static string Instrument
        {
            get { return _instrument; }
        }

        public static string Name
        {
            get { return _name; }
        }

        public static string Code
        {
            get { return _code; }
        }

        public static string Symbol
        {
            get { return _symbol; }
        }

        public static string Strike
        {
            get { return _strike; }
        }

        public static string Price
        {
            get { return _price; }
        }

        public static string Option
        {
            get { return _option; }
        }

        public static string Scrip
        {
            get { return _scrip; }
        }

        public static string Status
        {
            get { return _status; }
        }

        public static string Total
        {
            get { return _total; }
        }

        public static string Buy
        {
            get { return _buy; }
        }

        public static string Back
        {
            get { return _back; }
        }

        public static string Quantity
        {
            get { return _qty; }
        }

        public static string Sell
        {
            get { return _sell; }
        }

        public static string Last
        {
            get { return _last; }
        }

        public static string Traded
        {
            get { return _traded; }
        }

        public static string Trend
        {
            get { return _trend; }
        }

        public static string Indicator
        {
            get { return _indicator; }
        }

        public static string Time
        {
            get { return _time; }
        }

        public static string Volume
        {
            get { return _volume; }
        }

        public static string Value
        {
            get { return _value; }
        }

        public static string Change
        {
            get { return _change; }
        }

        public static string Average
        {
            get { return _avg; }
        }

        public static string High
        {
            get { return _high; }
        }

        public static string Low
        {
            get { return _low; }
        }

        public static string Open
        {
            get { return _open; }
        }

        public static string Close
        {
            get { return _close; }
        }

        public static string Interest
        {
            get { return _interest; }
        }

        public static string OI
        {
            get { return _oI; }
        }

        public static string Updated
        {
            get { return _updated; }
        }

        public static string In
        {
            get { return _in; }
        }

        public static string The
        {
            get { return _the; }
        }

        public static string Money
        {
            get { return _money; }
        }

        public static string Net
        {
            get { return _net; }
        }

        public static string Fair
        {
            get { return _fair; }
        }

        public static string Yield
        {
            get { return _yield; }
        }

        public static string Lend
        {
            get { return _lend; }
        }

        public static string Borrow
        {
            get { return _borrow; }
        }

        public static string Quotation
        {
            get { return _quotation; }
        }

        public static string Unit
        {
            get { return _unit; }
        }

        public static string Tender
        {
            get { return _tender; }
        }

        public static string News
        {
            get { return _news; }
        }

        public static string Alert
        {
            get { return _alert; }
        }

        public static string Previous
        {
            get { return _previous; }
        }

        public static string Member
        {
            get { return _member; }
        }

        public static string Id
        {
            get { return _id; }
        }

        public static string Trader
        {
            get { return _tender; }
        }

        public static string Script
        {
            get { return _script; }
        }

        public static string Group
        {
            get { return _group; }
        }

        public static string Order
        {
            get { return _order; }
        }

        public static string Spread
        {
            get { return _spread; }
        }

        public static string Number
        {
            get { return _number; }
        }

        public static string Trade
        {
            get { return _trade; }
        }

        public static string User
        {
            get { return _user; }
        }

        public static string Remarks
        {
            get { return _remarks; }
        }

        public static string Product
        {
            get { return _product; }
        }

        public static string Entry
        {
            get { return _entry; }
        }

        public static string Client
        {
            get { return _client; }
        }

        public static string Initiated
        {
            get { return _initiated; }
        }

        public static string From
        {
            get { return _from; }
        }

        public static string Modified
        {
            get { return _modified; }
        }

        public static string Watch
        {
            get { return _watch; }
        }

        public static string Lot
        {
            get { return _lot; }
        }

        public static string Weight
        {
            get { return _weight; }
        }

        public static string Position
        {
            get { return _position; }
        }

        public static string Segment
        {
            get { return _segment; }
        }

        public static string Periodicity
        {
            get { return _periodicity; }
        }

        public static string Security
        {
            get { return _security; }
        }

        public static string Contract
        {
            get { return _contract; }
        }

        public static string Integrated
        {
            get { return _integrated; }
        }

        public static string Both
        {
            get { return _both; }
        }

        public static string Range
        {
            get { return _range; }
        }

        public static string Currency
        {
            get { return _currency; }
        }

        public static string All
        {
            get { return _all; }
        }

        public static string Asset
        {
            get { return _asset; }
        }

        public static string Account
        {
            get { return _account; }
        }

        public static string Series
        {
            get { return _series; }
        }

        public static string Expiry
        {
            get { return _expiry; }
        }

        public static string Date
        {
            get { return _date; }
        }

        public static string Reference
        {
            get { return _reference; }
        }

        public static string Other
        {
            get { return _other; }
        }

        public static string To
        {
            get { return _to; }
        }

        public static string Trading
        {
            get { return _trading; }
        }

        public static string Filter
        {
            get { return _filter; }
        }

        public static string Editor
        {
            get { return _editor; }
        }

        public static string Action
        {
            get { return _action; }
        }

        public static string Maximum
        {
            get { return _maximum; }
        }

        public static string Iteration
        {
            get { return _iteration; }
        }

        public static string Test
        {
            get { return _test; }
        }

        public static string Message
        {
            get { return _message; }
        }

        public static string Email
        {
            get { return _email; }
        }

        public static string Picture
        {
            get { return _picture; }
        }

        public static string Top
        {
            get { return _top; }
        }

        public static string Gainers
        {
            get { return _gainers; }
        }

        public static string Losers
        {
            get { return _losers; }
        }

        public static string Portfolio
        {
            get { return _portfolio; }
        }

        public static string Search
        {
            get { return _search; }
        }

        public static string Remove
        {
            get { return _remove; }
        }

        public static string Add
        {
            get { return _add; }
        }

        public static string Save
        {
            get { return _save; }
        }

        public static string Real
        {
            get { return _real; }
        }

        public static string Mails
        {
            get { return _mails; }
        }

        public static string Reverse
        {
            get { return _reverse; }
        }

        public static string Check
        {
            get { return _check; }
        }

        public static string Profit
        {
            get { return _profit; }
        }

        public static string Your
        {
            get { return _your; }
        }

        public static string Used
        {
            get { return _used; }
        }

        public static string Current
        {
            get { return _current; }
        }

        public static string Stop
        {
            get { return _stop; }
        }

        public static string Loss
        {
            get { return _loss; }
        }

        public static string Take
        {
            get { return _take; }
        }

        public static string Swap
        {
            get { return _swap; }
        }

        public static string Commission
        {
            get { return _commission; }
        }

        public static string Entered
        {
            get { return _entered; }
        }

        public static string Headline
        {
            get { return _headline; }
        }

        public static string Description
        {
            get { return _description; }
        }

        public static string Condition
        {
            get { return _condition; }
        }

        public static string Counter
        {
            get { return _counter; }
        }

        public static string Limit
        {
            get { return _limit; }
        }

        public static string Timeout
        {
            get { return _timeout; }
        }

        public static string PEvent
        {
            get { return _Pevent; }
        }

        public static string Create
        {
            get { return _create; }
        }

        public static string Enable
        {
            get { return _enable; }
        }

        public static string Auto
        {
            get { return _auto; }
        }

        public static string Arrange
        {
            get { return _arrange; }
        }

        public static string Grid
        {
            get { return _grid; }
        }

        public static string Hide
        {
            get { return _hide; }
        }

        public static string Credit
        {
            get { return _credit; }
        }

        public static string Deposit
        {
            get { return _deposit; }
        }

        public static string Withdrawal
        {
            get { return _withdrawal; }
        }

        public static string History
        {
            get { return _history; }
        }

        public static string Months
        {
            get { return _months; }
        }

        public static string Period
        {
            get { return _period; }
        }

        public static string Report
        {
            get { return _report; }
        }

        public static string PAs //PAs=as
        {
            get { return _Pas; }
        }

        public static string Taxes
        {
            get { return _taxes; }
        }

        public static string Comments
        {
            get { return _comments; }
        }

        public static string Detailed
        {
            get { return _detailed; }
        }

        public static string Copy
        {
            get { return _copy; }
        }

        public static string Scroll
        {
            get { return _scroll; }
        }

        public static string View
        {
            get { return _view; }
        }

        public static string Subject
        {
            get { return _subject; }
        }

        public static string Body
        {
            get { return _body; }
        }

        public static string Validity
        {
            get { return _validity; }
        }

        public static string Submit
        {
            get { return _submit; }
        }

        public static string Clear
        {
            get { return _clear; }
        }

        public static string Apply
        {
            get { return _apply; }
        }

        public static string Cancel
        {
            get { return _cancel; }
        }

        public static string Omni
        {
            get { return _omni; }
        }

        public static string Pending
        {
            get { return _pending; }
        }

        public static string PFor
        {
            get { return _Pfor; }
        }

        public static string Help
        {
            get { return _help; }
        }

        public static string Log
        {
            get { return _log; }
        }

        public static string Book
        {
            get { return _book; }
        }

        public static string Life
        {
            get { return _life; }
        }

        public static string Send
        {
            get { return _send; }
        }

        public static string Source
        {
            get { return _source; }
        }

        public static string Ok
        {
            get { return _ok; }
        }

        public static string Terminal
        {
            get { return _terminal; }
        }

        public static string Panel
        {
            get { return _panel; }
        }

        public static string Statement
        {
            get { return _statement; }
        }

        public static string Forex
        {
            get { return _forex; }
        }

        public static string Pair
        {
            get { return _pair; }
        }

        public static string AlwaysUseMinQtyGivenHere
        {
            get { return _alwaysUseMinimumQtyGivenHere; }
        }


        public static string MinOrderQty
        {
            get { return _minOrderQty; }
        }

        public static string Disable
        {
            get { return _disable; }
        }

        public static string OrderValidity
        {
            get { return _orderValidity; }
        }

        public static string TriggerPriceSameAsLimitPrice
        {
            get { return _triggerPriceSameAsLimitPrice; }
        }

        public static string Default
        {
            get { return _default; }
        }

        public static string PrefixClientIdWith
        {
            get { return _prefixClientIdWith; }
        }

        public static string PrefixOmniIdWith
        {
            get { return _prefixOmniIdWith; }
        }

        public static string RetainLastClientId
        {
            get { return _retainLastClientId; }
        }

        public static string ClientNameEnable
        {
            get { return _clientNameEnable; }
        }

        public static string RetainLastParticipaintCode
        {
            get { return _retainLastParticipaintCode; }
        }

        public static string UnregisteredClientAlert
        {
            get { return _unregisteredClientAlert; }
        }

        public static string OTROrderAlert
        {
            get { return _OTROrderAlert; }
        }

        public static string CursorSetting
        {
            get { return _cursorSetting; }
        }

        public static string OrderEntryOnce
        {
            get { return _orderEntryOnce; }
        }

        public static string OrderEntryMultiple
        {
            get { return _orderEntryMultiple; }
        }

        public static string DisableProductDetails
        {
            get { return _disableProductDetails; }
        }

        public static string CloseOrderEntryAfterSubmission
        {
            get { return _closeOrderEntryAfterSubmission; }
        }

        public static string PriceDecimalSelection
        {
            get { return _priceDecimalSelection; }
        }

        public static string CombinationOrder
        {
            get { return _combinationOrder; }
        }

        public static string RestoreDefaults
        {
            get { return _restoreDefaults; }
        }

        public static string Ticker
        {
            get { return _ticker; }
        }

        public static string Commodity
        {
            get { return _commodity; }
        }

        public static string Speed
        {
            get { return _speed; }
        }

        public static string Display
        {
            get { return _display; }
        }

        public static string SelectInformationinPreferencePortolio
        {
            get { return _selectInformationinPreferencePortolio; }
        }

        public static string WorkSpace
        {
            get { return _workSpace; }
        }

        public static string WorkStation
        {
            get { return _workStation; }
        }

        public static string SelectDefaultWorkSpace
        {
            get { return _selectDefaultWorkSpace; }
        }

        public static string AutoLockWorkStation
        {
            get { return _autoLockWorkStation; }
        }

        public static string LockWorkStation
        {
            get { return _lockWorkStation; }
        }

        public static string ShowDateTime
        {
            get { return _showDateTime; }
        }

        public static string Minutes
        {
            get { return _minutes; }
        }

        public static string TimeWithSeconds
        {
            get { return _timeWithSeconds; }
        }

        public static string ColumnProfile
        {
            get { return _columnProfile; }
        }

        public static string OpenAllViewsWith
        {
            get { return _openAllViewsWith; }
        }

        public static string AllColumns
        {
            get { return _allColumns; }
        }

        public static string DefaultProfile
        {
            get { return _defaultProfile; }
        }

        public static string LastUsed
        {
            get { return _lastUsed; }
        }

        public static string PreferenceAlertTitleLabel
        {
            get { return _preferenceAlertTitleLabel; }
        }

        public static string FreshOrder
        {
            get { return _freshOrder; }
        }

        public static string OrderModification
        {
            get { return _orderModification; }
        }

        public static string MarketOrder
        {
            get { return _marketOrder; }
        }

        public static string OrderCancellation
        {
            get { return _orderCancellation; }
        }

        public static string TradeModification
        {
            get { return _tradeModification; }
        }

        public static string DifferentProductOrder
        {
            get { return _differentProductOrder; }
        }

        public static string OutsideDPROrder
        {
            get { return _outsideDPROrder; }
        }

        public static string QtyAlert
        {
            get { return _qtyAlert; }
        }

        public static string PriceAlert
        {
            get { return _priceAlert; }
        }

        public static string ValueAlert
        {
            get { return _valueAlert; }
        }

        public static string OpenPositionAlertOnLogoff
        {
            get { return _openPositionAlertOnLogoff; }
        }

        public static string PendingOrdersAlertOnLogoff
        {
            get { return _pendingOrdersAlertOnLogoff; }
        }

        public static string TradingCurrencyAlert
        {
            get { return _tradingCurrencyAlert; }
        }

        public static string PrintOrderConfirmation
        {
            get { return _printOrderConfirmation; }
        }

        public static string PrintTradeConfirmation
        {
            get { return _printTradeConfirmation; }
        }

        public static string MessageBarMessageType
        {
            get { return _messageBarMessageType; }
        }

        public static string Beep
        {
            get { return _beep; }
        }

        public static string OnEventDo
        {
            get { return _onEventDo; }
        }

        public static string FlashMessageBar
        {
            get { return _flashMessageBar; }
        }

        public static string MessageBox
        {
            get { return _messageBox; }
        }

        public static string PreferenceGeneralLogLabelText
        {
            get { return _preferenceGeneralLogTextLabel; }
        }

        public static string TimeFormatTobeUsedInViews
        {
            get { return _timeFormatTobeUsedInViews; }
        }

        public static string AlwaysOpenTheOrderBookWith
        {
            get { return _alwaysOpenTheOrderBookWith; }
        }

        public static string DefaultInstrumentName
        {
            get { return _defaultInstrumentName; }
        }

        public static string MaxMessageInMessageLog
        {
            get { return _maxMessageInMessageLog; }
        }

        public static string General
        {
            get { return _general; }
        }

        public static string Preferences
        {
            get { return _preferences; }
        }

        public static string Quote
        {
            get { return _quote; }
        }

        public static string Snap
        {
            get { return _snap; }
        }

        public static string Index
        {
            get { return _index; }
        }

        public static string Show
        {
            get { return _show; }
        }

        public static string Hot
        {
            get { return _hot; }
        }

        public static string Keys
        {
            get { return _keys; }
        }

        public static string Settings
        {
            get { return _settings; }
        }


        public static string Off
        {
            get { return _off; }
        }

        public static string Modify
        {
            get { return _modify; }
        }

        public static string Information
        {
            get { return _information; }
        }

        public static string Bar
        {
            get { return _bar; }
        }

        public static string Login
        {
            get { return _login; }
        }

        public static string LogOff
        {
            get { return _logOff; }
        }

        public static string Load
        {
            get { return _load; }
        }

        public static string Exit
        {
            get { return _exit; }
        }

        public static string ToolBar
        {
            get { return _toolBar; }
        }

        public static string FilterBar
        {
            get { return _filterBar; }
        }

        public static string MessageBar
        {
            get { return _messageBar; }
        }

        public static string StatusBar
        {
            get { return _statusBar; }
        }

        public static string Middle
        {
            get { return _middle; }
        }

        public static string Bottom
        {
            get { return _bottom; }
        }

        public static string Admin
        {
            get { return _admin; }
        }


        public static string IndiciesView
        {
            get { return _indiciesView; }
        }

        public static string FullScreen
        {
            get { return _fullScreen; }
        }

        public static string PlaceBuyOrder
        {
            get { return _placeBuyOrder; }
        }


        public static string PlaceSellOrder
        {
            get { return _placeSellOrder; }
        }

        public static string New
        {
            get { return _new; }
        }

        public static string Cascade
        {
            get { return _cascade; }
        }

        public static string TileHorizontally
        {
            get { return _tileHorizontally; }
        }

        public static string TileVertically
        {
            get { return _tileVertically; }
        }

        public static string Trades
        {
            get { return _trades; }
        }

        public static string Customize
        {
            get { return _customize; }
        }


        public static string File
        {
            get { return _file; }
        }

        public static string Tools
        {
            get { return _tools; }
        }

        public static string Themes
        {
            get { return _themes; }
        }

        public static string Participant
        {
            get { return _participant; }
        }

        public static string List
        {
            get { return _list; }
        }


        public static string Setting
        {
            get { return _setting; }
        }


        public static string Delivery
        {
            get { return _delivery; }
        }

        public static string Numerator
        {
            get { return _numerator; }
        }

        public static string Denomenator
        {
            get { return _denomenator; }
        }

        public static string Initial
        {
            get { return _initial; }
        }

        public static string Margin
        {
            get { return _margin; }
        }

        public static string Size
        {
            get { return _size; }
        }

        public static string Benefit
        {
            get { return _benefit; }
        }


        public static string Start
        {
            get { return _start; }
        }

        public static string End
        {
            get { return _end; }
        }

        public static string Specification
        {
            get { return _specification; }
        }

        //public static string MostActiveProducts
        //{
        //    get
        //    {
        //        return _mostActiveProducts;
        //    }
        //}

        //public static string MostActiveProductsByValue
        //{
        //    get
        //    {
        //        return _mostActiveProductsByValue;
        //    }
        //}

        //public static string MostActiveProductsByVolume
        //{
        //    get
        //    {
        //        return _mostActiveProductsByVolume;
        //    }
        //}
        //public static string SelectPortfolioMessage
        //{
        //    get
        //    {
        //        return _selectPortfolioMessage;
        //    }
        //}

        #endregion "       PROPERTY           "
    }
}