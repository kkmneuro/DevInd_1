using System.Linq;
using System.Collections.Generic;
//using FundXchange.Model.Repositories;
//using FundXchange.Model.ViewModels.Indicators;
//using FundXchange.Model.AuthenticationService;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Gateways;
using System;
using PALSA.Frm;

namespace PALSA.ClsRadar
{
    public class IndicatorRepository : IIndicatorRepository
    {
        //static IndicatorRepository()
        //{
        //    InitializeIndicators();
        //    InitializeIndicatorGroups();
        //}

        public IndicatorRepository()
        {
            InitializeIndicators();
            InitializeIndicatorGroups();
        }

        //private static readonly AlertServiceGateway ServiceGateway = new AlertServiceGateway(new ErrorService());

        private static readonly AlertScriptService.AlertScriptServiceClient AlertServ = new AlertScriptService.AlertScriptServiceClient();
        private static readonly List<Indicator> Indicators = new List<Indicator>();
        private static IEnumerable<IndicatorGroup> IndicatorGroups = new List<IndicatorGroup>();

        public IEnumerable<Indicator> AvailableIndicators
        {
            get { return Indicators; }
        }

        private static void InitializeIndicators()//Kul
        {
            List<AlertScriptService.AlertScripts> alertScriptArr=new List<AlertScriptService.AlertScripts>();//changes done by vinod
            //try{
            //     alertScriptArr.AddRange(AlertServ.GetAlertScripts());
            //}
            //catch
            //{
            //}
            AlertScriptService.AlertScripts[] AlertScripts = alertScriptArr.ToArray();
            foreach (var alertScript in AlertScripts)
            {
                if (!AlertScriptAlreadyRepresented(alertScript))
                {
                    if (alertScript != null)
                    {
                        Indicators.Add(CreateIndicatorFrom(alertScript));
                    }
                }
            }
            //foreach (var alertScript in User.AlertScripts)
            //{
            //    if (!AlertScriptAlreadyRepresented(alertScript))
            //    {
            //        if (alertScript != null)
            //        {
            //            Indicators.Add(CreateIndicatorFrom(alertScript));
            //        }
            //    }
            //}
            //LoadListValues();//Changed by Kuldeep
            //foreach (var item in indicatorListValues)
            //{
            //    Guid gd = new Guid();
            //    Indicator ind = new Indicator(gd, item, item, "", true);
            //    Indicators.Add(ind);
            //}

        }

        private static Indicator CreateIndicatorFrom(AlertScriptService.AlertScripts alertScript)
        {
            return new Indicator(alertScript.UniqueIdField, alertScript.AlertName, alertScript.Abbreviation, alertScript.DefaultScript, alertScript.IsUserDefined)
            {
                BuyScript = alertScript.BuyScript,
                SellScript = alertScript.SellScript,
                TradeSignalScript = alertScript.TradeSignalScript
            };
        }

        private static readonly List<String> indicatorListValues = new List<string>();
        private static void LoadListValues()
        {
            //try
            //{
            AddNewIndicator("Simple Moving Average");
            AddNewIndicator("Exponential Moving Average");
            AddNewIndicator("Time Series Moving Average");
            AddNewIndicator("Triangular Moving Average");
            AddNewIndicator("Variable Moving Average");
            AddNewIndicator("VIDYA");
            AddNewIndicator("Welles Wilder Smoothing");
            AddNewIndicator("Weighted Moving Average");
            AddNewIndicator("Williams Pct R");
            AddNewIndicator("Williams Accumulation Distribution");
            AddNewIndicator("Volume Oscillator");
            AddNewIndicator("Vertical Horizontal Filter");
            AddNewIndicator("Ultimate Oscillator");
            AddNewIndicator("True Range");
            AddNewIndicator("TRIX");
            AddNewIndicator("Rainbow Oscillator");
            AddNewIndicator("Price Oscillator");
            AddNewIndicator("Parabolic SAR");
            AddNewIndicator("Momentum Oscillator");
            AddNewIndicator("MACD");
            AddNewIndicator("Ease Of Movement");
            AddNewIndicator("Directional Movement System");
            AddNewIndicator("Detrended Price Oscillator");
            AddNewIndicator("Chande Momentum Oscillator");
            AddNewIndicator("Chalkin Volatility");
            AddNewIndicator("Aroon");
            AddNewIndicator("Aroon Oscillator");
            AddNewIndicator("Linear Regression Required");
            AddNewIndicator("Linear Regressin Forecast");
            AddNewIndicator("Linear Regression Slope");
            AddNewIndicator("Linear Regression Intercept");
            AddNewIndicator("Price Volume Trend");
            AddNewIndicator("Performance Index");
            AddNewIndicator("Commodity Channel Index");
            AddNewIndicator("Chaikin Money Flow");
            AddNewIndicator("Weighted Close");
            AddNewIndicator("Volume ROC");
            AddNewIndicator("Typical Price");
            AddNewIndicator("Standard Deviation");
            AddNewIndicator("Price ROC");
            AddNewIndicator("Median");
            AddNewIndicator("High Minus Low");
            AddNewIndicator("Bollinger Bands");
            AddNewIndicator("Fractal Chaos Bands");
            AddNewIndicator("High Low Bands");
            AddNewIndicator("Moving Average Envelope");
            AddNewIndicator("Swing Index");
            AddNewIndicator("Accumulative Swing Index");
            AddNewIndicator("Comperative RSI");
            AddNewIndicator("Mass Index");
            AddNewIndicator("Money Flow Index");
            AddNewIndicator("Negative Volume Index");
            AddNewIndicator("On Balance Volume");
            AddNewIndicator("Positive Volume Index");
            AddNewIndicator("Relative Strength Index");
            AddNewIndicator("Trade Volume Index");
            AddNewIndicator("Stochastic Oscillator");
            AddNewIndicator("Stochastic Momentum Index");
            AddNewIndicator("Fractal Chaos Oscillator");
            AddNewIndicator("Prime Number Oscillator");
            AddNewIndicator("Prime Number Bands");
            AddNewIndicator("Historical Volatility");
            AddNewIndicator("MACD Histogram");
            AddNewIndicator("Custom Indicator");
            indicatorListValues.Sort();
        }

        private static void AddNewIndicator(string p)
        {
            indicatorListValues.Add(p);
        }


        //Kul
        private static bool AlertScriptAlreadyRepresented(AlertScriptService.AlertScripts alertScript)
        {
            Indicator foundIndicator = Indicators.FirstOrDefault(i => i.Name == alertScript.AlertName);
            return foundIndicator != null;
        }

        private static void InitializeIndicatorGroups()
        {
            IndicatorGroupingStrategy groupingStrategy = new IndicatorGroupingStrategy(Indicators);
            IndicatorGroups = groupingStrategy.GetGroups();
        }

        public void AddIndicator(Indicator indicator)
        {
            Indicators.Add(indicator);
            //var newAlertScript = CreateAlertScriptDtoFrom(indicator);
            //User.AlertScripts = User.AlertScripts.Union(new List<FundXchange.Model.AlertService.AlertScriptDTO>() { newAlertScript }).ToArray();
            //ServiceGateway.SaveAlertScript(User.Account.UserId, CreateAlertScriptDtoFrom(newAlertScript));
        }

        public void UpdateIndicator(Guid uniqueId, Indicator newIndicatorDefinition)
        {
            if (newIndicatorDefinition.IsUserDefined)
            {
                RemoveIndicator(uniqueId);
                AddIndicator(newIndicatorDefinition);
            }
        }

        //kUL
        //private FundXchange.Model.AlertService.AlertScriptDTO CreateAlertScriptDtoFrom(FundXchange.Model.AlertService.AlertScriptDTO newAlertScript)
        //{
        //    return new FundXchange.Model.AlertService.AlertScriptDTO()
        //    {
        //        UniqueId = newAlertScript.UniqueId,
        //        Abbreviation = newAlertScript.Abbreviation,
        //        AlertName = newAlertScript.AlertName,
        //        Bars = newAlertScript.Bars,
        //        BuyScript = newAlertScript.BuyScript,
        //        DayHours = newAlertScript.DayHours,
        //        DefaultScript = newAlertScript.DefaultScript,
        //        Enabled = newAlertScript.Enabled,
        //        EndOfDay = newAlertScript.EndOfDay,
        //        Exchange = newAlertScript.Exchange,
        //        ExitLongScript = newAlertScript.ExitLongScript,
        //        ExitShortScript = newAlertScript.ExitShortScript,
        //        GTC = newAlertScript.GTC,
        //        GTCHours = newAlertScript.GTCHours,
        //        Interval = newAlertScript.Interval,
        //        IsUserDefined = newAlertScript.IsUserDefined,
        //        Limit = newAlertScript.Limit,
        //        Market = newAlertScript.Market,
        //        Period = newAlertScript.Period,
        //        Portfolio = newAlertScript.Portfolio,
        //        Quantity = newAlertScript.Quantity,
        //        SellScript = newAlertScript.SellScript,
        //        StopLimit = newAlertScript.StopLimit,
        //        StopLimitValue = newAlertScript.StopLimitValue,
        //        StopMarket = newAlertScript.StopMarket,
        //        Symbol = newAlertScript.Symbol,
        //        TradeSignalScript = newAlertScript.TradeSignalScript
        //    };
        //}

        //private FundXchange.Model.AlertService.AlertScriptDTO CreateAlertScriptDtoFrom(Indicator indicator)
        //{
        //    return new FundXchange.Model.AlertService.AlertScriptDTO()
        //    {
        //        AlertName = indicator.Name,
        //        Abbreviation = indicator.Abbreviation,
        //        DefaultScript = indicator.Script,
        //        BuyScript = indicator.BuyScript,
        //        SellScript = indicator.SellScript,
        //        TradeSignalScript = indicator.TradeSignalScript,
        //        IsUserDefined = true,
        //        UniqueId = indicator.UniqueId
        //    };
        //}

        public bool TryGetIndicatorBy(string name, out Indicator indicator)
        {
            indicator = Indicators.FirstOrDefault(i => i.Name.ToLowerInvariant() == name.ToLowerInvariant());
            return indicator != null;
        }

        public bool ScriptNameIsValid(string name)
        {
            var foundSystemIndicator = Indicators.FirstOrDefault(i => i.Name.ToLowerInvariant() == name.ToLowerInvariant() && !i.IsUserDefined);
            return foundSystemIndicator == null;
        }

        #region IIndicatorRepository Members


        public bool IsGroupedIndicator(Indicator indicator)
        {
            foreach (var group in IndicatorGroups)
            {
                if (group.HasChild(indicator))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Indicator> GetSiblingsOf(Indicator indicator)
        {
            if (IsGroupedIndicator(indicator))
            {
                IndicatorGroup group = FindGroup(indicator);
                if (null != group)
                {
                    return group.GetSiblingsOf(indicator);
                }
            }
            return new Indicator[] { };
        }

        private IndicatorGroup FindGroup(Indicator indicator)
        {
            foreach (var group in IndicatorGroups)
            {
                if (group.HasChild(indicator))
                {
                    return group;
                }
            }
            return null;
        }

        #endregion

        public void RefreshIndicators()
        {
            InitializeIndicators();
        }

        public void RemoveIndicator(System.Guid uniqueId)
        {
            var foundIndicator = Indicators.FirstOrDefault(i => i.UniqueId == uniqueId);
            if (null != foundIndicator)
            {
                if (foundIndicator.IsUserDefined)
                {
                    Indicators.Remove(foundIndicator);
                    //ServiceGateway.RemoveAlertScript(User.Account.UserId, foundIndicator.UniqueId);
                }
            }
        }

        private class IndicatorGroupingStrategy
        {
            private readonly IEnumerable<Indicator> _availableIndicators;

            private readonly IDictionary<string, Func<Indicator, bool>> _requiredGroups;

            public IndicatorGroupingStrategy(IEnumerable<Indicator> availableIndicators)
            {
                _availableIndicators = availableIndicators;
                _requiredGroups = new Dictionary<string, Func<Indicator, bool>>()
                {
                    {"MACD", new Func<Indicator, bool>(i => i.Name.StartsWith("MACD") && !i.Name.ToLowerInvariant().Contains("system") && !i.IsUserDefined)}, 
                    {"Stochastic Momentum", new Func<Indicator, bool>(i => i.Name.StartsWith("Stochastic Momentum") && !i.IsUserDefined)}, 
                    {"Stochastic Oscillator", new Func<Indicator, bool>(i => i.Name.StartsWith("Stochastic Oscillator") && !i.IsUserDefined)}, 
                    {"Prime Number Bands", new Func<Indicator, bool>(i => i.Name.StartsWith("Prime Number Bands") && !i.IsUserDefined)}, 
                    {"Moving Average Envelope", new Func<Indicator, bool>(i => i.Name.StartsWith("Moving Average Envelope") && !i.IsUserDefined)}, 
                    {"Keltner Channel", new Func<Indicator, bool>(i => i.Name.StartsWith("Keltner Channel") && !i.IsUserDefined)}, 
                    {"Bollinger Bands", new Func<Indicator, bool>(i => i.Name.StartsWith("Bollinger Bands") && !i.IsUserDefined)}
                };
            }

            public IEnumerable<IndicatorGroup> GetGroups()
            {
                List<IndicatorGroup> groups = new List<IndicatorGroup>();
                foreach (var requiredGroup in _requiredGroups)
                {
                    IndicatorGroup group = new IndicatorGroup(requiredGroup.Key, _availableIndicators.Where(requiredGroup.Value));
                    if(group.HasChildren())
                    {
                        groups.Add(group);
                    }
                }
                return groups;
            }
        }
    }

    public interface IIndicatorRepository
    {
        IEnumerable<Indicator> AvailableIndicators { get; }
        void AddIndicator(Indicator indicator);
        void UpdateIndicator(Guid uniqueId, Indicator newIndicatorDefinition);
        void RemoveIndicator(System.Guid guid);
        bool IsGroupedIndicator(Indicator indicator);
        void RefreshIndicators();
        IEnumerable<Indicator> GetSiblingsOf(Indicator indicator);
        bool TryGetIndicatorBy(string name, out Indicator indicator);
        bool ScriptNameIsValid(string name);
    }

    public class IndicatorGroup
    {
        public IndicatorGroup(string groupName, IEnumerable<Indicator> siblingIndicators)
        {
            _siblingIndicators = siblingIndicators;
        }

        public IndicatorGroup(string groupName, params Indicator[] siblingIndicators)
            : this(groupName, siblingIndicators.AsEnumerable()) { }

        private readonly string _groupName;
        private readonly IEnumerable<Indicator> _siblingIndicators;

        public bool HasChildren()
        {
            return _siblingIndicators.Count() > 0;
        }

        public bool HasChild(Indicator indicator)
        {
            return _siblingIndicators.Contains(indicator);
        }

        public IEnumerable<Indicator> GetSiblingsOf(Indicator indicator)
        {
            return _siblingIndicators.Except(new[] { indicator });
        }

        public static IndicatorGroup Create(string groupName, IEnumerable<Indicator> availableIndicators, Func<Indicator, bool> predicate)
        {
            return new IndicatorGroup(groupName, availableIndicators.Where(predicate));
        }
    }
}