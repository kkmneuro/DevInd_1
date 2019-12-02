using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AlertService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlertService" in both code and config file together.
    [ServiceContract]
    public interface IAlertService
    {
        [OperationContract]
        GeneralResult AddAlert(int userId, AlertDTO alert);
        [OperationContract]
        GeneralResult AddAlertScript(int userId, AlertScriptDTO alertScriptDTO);
        [OperationContract]
        GeneralResult RemoveAlertScript(int userId, string alertName);
        [OperationContract]
        GeneralResult RemoveAlertScriptById(int userId, Guid alertId);
        [OperationContract]
        GeneralResult RemoveScanner(int userId, string scannerName);
        [OperationContract]
        GeneralResult SaveScanner(int userId, ScannerDTO scannerDTO);

    }

    [DataContract]
    public class GeneralResult : ActionResultOfboolean
    {

    }

    [DataContract]
    public class ActionResultOfboolean
    {
        private string ErrorMessageField;
        private bool ObjectField;
        private ResultType ResultField;

        [DataMember]
        public string ErrorMessage
        {
            set
            {
                ErrorMessageField = value;
            }
            get
            {
                return ErrorMessageField;
            }
        }

        [DataMember]
        public bool Object
        {
            set
            {
                ObjectField = value;
            }
            get
            {
                return ObjectField;
            }
        }
        [DataMember]
        public ResultType Result
        {
            set
            {
                ResultField = value;
            }
            get
            {
                return ResultField;
            }
        }
    }

    [DataContract]
    public class AlertDTO
    {
        private string AlertNameField;
        private AlertType AlertTypeField;
        private string ExchangeField;
        private string SymbolField;
        private string TagField;

        [DataMember]
        public string AlertName
        {
            set
            {
                AlertNameField = value;
            }
            get
            {
                return AlertNameField;
            }
        }

        [DataMember]
        public AlertType AlertType
        {
            set
            {
                AlertTypeField = value;
            }
            get
            {
                return AlertTypeField;
            }
        }

        [DataMember]
        public string Exchange
        {
            set
            {
                ExchangeField = value;
            }
            get
            {
                return ExchangeField;
            }
        }

        [DataMember]
        public string Symbol
        {
            set
            {
                SymbolField = value;
            }
            get
            {
                return SymbolField;
            }
        }

        [DataMember]
        public string Tag
        {
            set
            {
                TagField = value;
            }
            get
            {
                return TagField;
            }
        }

    }

    [DataContract]
    public class AlertScriptDTO
    {
        private string AbbreviationField;
        private string AlertNameField;
        private int BarsField;
        private string BuyScriptField;
        private bool DayHoursField;
        private string DefaultScriptField;
        private bool EnabledField;
        private bool EndOfDayField;
        private string ExchangeField;
        private string ExitLongScriptField;
        private string ExitShortScriptField;
        private bool GTCField;
        private bool GTCHoursField;
        private int IntervalField;
        private bool IsUserDefinedField;
        private bool LimitField;
        private bool MarketField;
        private string PeriodField;
        private string PortfolioField;
        private int QuantityField;
        private string SellScriptField;
        private bool StopLimitField;
        private string StopLimitValueField;
        private bool StopMarketField;
        private string SymbolField;
        private string TradeSignalScriptField;
        private Guid UniqueIdField;

        [DataMember]
        public string Abbreviation
        {
            set
            {
                AbbreviationField = value;
            }
            get
            {
                return AbbreviationField;
            }
        }

        [DataMember]
        public string AlertName
        {
            set
            {
                AlertNameField = value;
            }
            get
            {
                return AlertNameField;
            }
        }

        [DataMember]
        public int Bars
        {
            set
            {
                BarsField = value;
            }
            get
            {
                return BarsField;
            }
        }

        [DataMember]
        public string BuyScript
        {
            set
            {
                BuyScriptField = value;
            }
            get
            {
                return BuyScriptField;
            }
        }

        [DataMember]
        public bool DayHours
        {
            set
            {
                DayHoursField = value;
            }
            get
            {
                return DayHoursField;
            }
        }

        [DataMember]
        public string DefaultScript
        {
            set
            {
                DefaultScriptField = value;
            }
            get
            {
                return DefaultScriptField;
            }
        }

        [DataMember]
        public bool Enabled
        {
            set
            {
                EnabledField = value;
            }
            get
            {
                return EnabledField;
            }
        }

        [DataMember]
        public bool EndOfDay
        {
            set
            {
                EndOfDayField = value;
            }
            get
            {
                return EndOfDayField;
            }
        }

        [DataMember]
        public string Exchange
        {
            set
            {
                ExchangeField = value;
            }
            get
            {
                return ExchangeField;
            }
        }

        [DataMember]
        public string ExitLongScript
        {
            set
            {
                ExitLongScriptField = value;
            }
            get
            {
                return ExitLongScriptField;
            }
        }

        [DataMember]
        public string ExitShortScript
        {
            set
            {
                ExitLongScriptField = value;
            }
            get
            {
                return ExitLongScriptField;
            }
        }

        [DataMember]
        public bool GTC
        {
            set
            {
                GTCField = value;
            }
            get
            {
                return GTCField;
            }
        }

        [DataMember]
        public bool GTCHours
        {
            set
            {
                GTCHoursField = value;
            }
            get
            {
                return GTCHoursField;
            }
        }

        [DataMember]
        public int Interval
        {
            set
            {
                IntervalField = value;
            }
            get
            {
                return IntervalField;
            }
        }

        [DataMember]
        public bool IsUserDefined
        {
            set
            {
                IsUserDefinedField = value;
            }
            get
            {
                return IsUserDefinedField;
            }
        }

        [DataMember]
        public bool Limit
        {
            set
            {
                LimitField = value;
            }
            get
            {
                return LimitField;
            }
        }

        [DataMember]
        public bool Market
        {
            set
            {
                MarketField = value;
            }
            get
            {
                return MarketField;
            }
        }

        [DataMember]
        public string Period
        {
            set
            {
                PeriodField = value;
            }
            get
            {
                return PeriodField;
            }
        }

        [DataMember]
        public string Portfolio
        {
            set
            {
                PortfolioField = value;
            }
            get
            {
                return PortfolioField;
            }
        }

        [DataMember]
        public int Quantity
        {
            set
            {
                QuantityField = value;
            }
            get
            {
                return QuantityField;
            }
        }

        [DataMember]
        public string SellScript
        {
            set
            {
                SellScriptField = value;
            }
            get
            {
                return SellScriptField;
            }
        }

        [DataMember]
        public bool StopLimit
        {
            set
            {
                StopLimitField = value;
            }
            get
            {
                return StopLimitField;
            }
        }

        [DataMember]
        public string StopLimitValue
        {
            set
            {
                StopLimitValueField = value;
            }
            get
            {
                return StopLimitValueField;
            }
        }

        [DataMember]
        public bool StopMarket
        {
            set
            {
                StopMarketField = value;
            }
            get
            {
                return StopMarketField;
            }
        }

        [DataMember]
        public string Symbol
        {
            set
            {
                SymbolField = value;
            }
            get
            {
                return SymbolField;
            }
        }

        [DataMember]
        public string TradeSignalScript
        {
            set
            {
                TradeSignalScriptField = value;
            }
            get
            {
                return TradeSignalScriptField;
            }
        }

        [DataMember]
        public Guid UniqueId
        {
            set
            {
                UniqueIdField = value;
            }
            get
            {
                return UniqueIdField;
            }
        }

    }

    [DataContract]
    public class ScannerDTO
    {
        private string AlertScriptField;
        private int BarHistoryField;
        private int BarIntervalField;
        private string ExchangeField;
        private bool IsLockedField;
        private bool IsPausedField;
        private Periodicities PeriodicityField;
        private string ScannerNameField;
        private string SymbolField;

        [DataMember]
        public string AlertScript
        {
            set
            {
                AlertScriptField = value;
            }
            get
            {
                return AlertScriptField;
            }
        }

        [DataMember]
        public int BarHistory
        {
            set
            {
                BarHistoryField = value;
            }
            get
            {
                return BarHistoryField;
            }
        }

        [DataMember]
        public int BarInterval
        {
            set
            {
                BarIntervalField = value;
            }
            get
            {
                return BarIntervalField;
            }
        }

        [DataMember]
        public string Exchange
        {
            set
            {
                ExchangeField = value;
            }
            get
            {
                return ExchangeField;
            }
        }

        [DataMember]
        public bool IsLocked
        {
            set
            {
                IsLockedField = value;
            }
            get
            {
                return IsLockedField;
            }
        }

        [DataMember]
        public bool IsPaused
        {
            set
            {
                IsPausedField = value;
            }
            get
            {
                return IsPausedField;
            }
        }

        [DataMember]
        public Periodicities Periodicity
        {
            set
            {
                PeriodicityField = value;
            }
            get
            {
                return PeriodicityField;
            }
        }

        [DataMember]
        public string ScannerName
        {
            set
            {
                ScannerNameField = value;
            }
            get
            {
                return ScannerNameField;
            }
        }

        [DataMember]
        public string Symbol
        {
            set
            {
                SymbolField = value;
            }
            get
            {
                return SymbolField;
            }
        }
    }

    [DataContract]
    public enum ResultType
    {
        [EnumMember]
        Failure,
        [EnumMember]
        Success,
        [EnumMember]
        Warning
    };

    [DataContract]
    public enum AlertType
    {
        [EnumMember]
        News,
        [EnumMember]
        Order,
        [EnumMember]
        Script
    };

    [DataContract]
    public enum Periodicities
    {
        [EnumMember]
        Daily,
        [EnumMember]
        Hourly,
        [EnumMember]
        Minutely,
        [EnumMember]
        Secondly,
        [EnumMember]
        Weekly
    };
}
