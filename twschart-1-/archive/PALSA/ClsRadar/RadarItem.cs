using System;
using System.Linq;
using System.Collections.Generic;
using PALSA.Cls;
//using FundXchange.Domain.Entities;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.ViewModels.Indicators;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Model.Agents;
//using Charts = FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.ViewModels.Generic;
//using FundXchange.Domain.Enumerations;
//using Candlestick = FundXchange.Domain.ValueObjects.Candlestick;

namespace PALSA.ClsRadar
{    
    public class RadarItem : IRadarItem
    {
        public RadarItem(Guid uniqueId, Instrument instrument, Periodicity periodicity, int interval, int startingBars)
        {
            //_marketRepository = marketRepository;
            _indicators = new List<IRadarViewIndicator>();
            _associatedInstrument = instrument;
            UniqueId = uniqueId;
            
            InitializeCandlestickAgent(periodicity, interval, startingBars);
        }

        #region Private members

        private readonly IList<IRadarViewIndicator> _indicators;
        
        private Instrument _associatedInstrument;
        private CandlestickAgent _candlestickAgent;
        private Periodicity _periodicity;
        private int _interval;
        private object _lockObject = new object();

        #endregion

        #region Public members

        public Guid UniqueId { get; private set; }
        public SubscriptionDescriptor Descriptor
        {
            get
            {
                if (null != _associatedInstrument)
                {
                    return new SubscriptionDescriptor(_associatedInstrument.Symbol, _associatedInstrument.Exchange, _interval, _periodicity); 
                }
                return null;
            }
        }

        public event RowUpdateRequiredDelegate OnRowUpdateRequired;
        public event CellAddedDelegate OnCellAdditionRequired;
        public event CellUpdateRequiredDelegate OnCellUpdateRequired;

        #endregion

        #region Public methods

        public IEnumerable<IRadarViewIndicator> GetIndicators()
        {
            var indicatorArray = _indicators.ToArray();
            return indicatorArray;
        }

        public void AddIndicator(Indicator indicator)
        {
            IRadarViewIndicator radarIndicator;
            if (!TryFindRadarIndicator(indicator, out radarIndicator))
            {
                radarIndicator = new RadarItemIndicator(indicator);
                _indicators.Add(radarIndicator);

                IEnumerable<Candlestick> currentCandles = _candlestickAgent.GetItems();
                radarIndicator.InitializeWith(currentCandles);

                RaiseCellAdded(radarIndicator);
                radarIndicator.OnChanged += RadarIndicatorChanged;
            }
        }

        public void RemoveIndicator(Indicator indicator)
        {
            IRadarViewIndicator radarIndicator;
            if (TryFindRadarIndicator(indicator, out radarIndicator))
            {
                radarIndicator.PrepareForRemoval();
                _indicators.Remove(radarIndicator);
            }
        }

        public void PrepareForRemoval()
        {
            _candlestickAgent.Unsubscribe();
            _candlestickAgent.CandleAdded -= CandlestickAgentCandleAdded;
            _candlestickAgent.CandleUpdated -= CandlestickAgentCandleUpdated;
            _candlestickAgent = null;

            lock (_lockObject)
            {
                foreach (RadarItemIndicator radarIndicator in _indicators)
                {
                    radarIndicator.OnChanged -= RadarIndicatorChanged;
                    radarIndicator.PrepareForRemoval();
                }
            }
            _indicators.Clear();
        }

        public void UpdateWith(Instrument updatedInstrument)
        {
            if(updatedInstrument.Symbol != _associatedInstrument.Symbol)
                throw new ArgumentException("Invalid instrument supplied");
            _associatedInstrument = updatedInstrument;
        }

        public void SetIndicatorIntervals(Periodicity periodicity, int interval, int startingBars)
        {
            lock (_lockObject)
            {
                foreach (RadarItemIndicator radarViewIndicator in _indicators)
                {
                    radarViewIndicator.Clear();
                }
            }
            InitializeCandlestickAgent(periodicity, interval, startingBars);
            RaiseRowUpdateRequired(true);
        }

        public void SetIndicatorStatus(bool areActive)
        {
            lock (_lockObject)
            {
                foreach (IRadarViewIndicator indicator in _indicators)
                {
                    indicator.SetStatus(areActive);
                }
            }
        }

        public IEnumerable<RadarGridCell> GetCells(bool includeIndicatorCells)
        {
            List<RadarGridCell> gridCells = new List<RadarGridCell>();
            gridCells.Add(new RadarGridCell(
                UniqueId,
                string.Format("{0} {1}", _interval, _periodicity),
                CreateCellTag(_associatedInstrument.Symbol, "Interval"),
                RadarColumnType.Indicator));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.Symbol,
                CreateCellTag(_associatedInstrument.Symbol, "Symbol")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.LastTrade.ToString(),
                CreateCellTag(_associatedInstrument.Symbol, "LastTrade")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.LastTradeTime.ToString("HH:mm"),
                CreateCellTag(_associatedInstrument.Symbol, "LastTradedTime")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.Low.ToString(),
                CreateCellTag(_associatedInstrument.Symbol, "Low")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.High.ToString(),
                CreateCellTag(_associatedInstrument.Symbol, "High")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                _associatedInstrument.BestBid.ToString(),
                CreateCellTag(_associatedInstrument.Symbol, "BestBid")));

            gridCells.Add(new RadarGridCell(
                UniqueId,
                Math.Round(_associatedInstrument.PercentageMoved, 2).ToString(),
                CreateCellTag(_associatedInstrument.Symbol, "PercentageMovement")));

            if (includeIndicatorCells)
            {
                lock (_lockObject)
                {
                    foreach (RadarItemIndicator radarIndicator in _indicators)
                    {
                        gridCells.Add(CreateCellFor(radarIndicator));
                    }
                }
            }
            return gridCells;
        }

        public bool IsInterestedIn(Instrument instrument)
        {
            if (null != _associatedInstrument)
            {
                return _associatedInstrument.Symbol == instrument.Symbol;
            }
            return false;
        }

        #endregion

        #region Event handlers

        private void CandlestickAgentCandleInitialized(string identifier, List<Candlestick> candles)
        {
            var candlesCopy = candles.ToArray();

            lock (_lockObject)
            {
                foreach (IRadarViewIndicator indicator in _indicators)
                {
                    indicator.InitializeWith(candlesCopy);
                }
            }
            _candlestickAgent.CandleAdded += CandlestickAgentCandleAdded;
            _candlestickAgent.CandleUpdated += CandlestickAgentCandleUpdated;
        }

        private void CandlestickAgentCandleUpdated(string identifier, Candlestick candle)
        {
            lock (_lockObject)
            {
                foreach (IRadarViewIndicator indicator in _indicators)
                    indicator.UpdateCandle(candle);
            }
        }

        private void CandlestickAgentCandleAdded(string identifier, Candlestick candle)
        {
            lock (_lockObject)
            {
                foreach (RadarItemIndicator indicator in _indicators)
                {
                    indicator.AddCandle(candle);
                }
            }
        }

        void RadarIndicatorChanged(RadarItemIndicator sender)
        {
            RaiseCellUpdateRequired(sender);
        }

        #endregion

        #region Helper methods

        private void InitializeCandlestickAgent(Periodicity periodicity, int interval, int startingBars)
        {
            _interval = interval;
            _periodicity = periodicity;

            if (null != _candlestickAgent)
                _candlestickAgent.Unsubscribe();

            _candlestickAgent = new CandlestickAgent();
            _candlestickAgent.CandleInitialized += CandlestickAgentCandleInitialized;

            PeriodEnum period = GetPeriodFromPeriodicity(periodicity);
            _candlestickAgent.Subscribe(_associatedInstrument.Symbol, _associatedInstrument.Exchange, startingBars, interval, period);
        }

        private PeriodEnum GetPeriodFromPeriodicity(Periodicity periodicity)
        {
            switch (periodicity)
            {
                case Periodicity.Minutely:
                    return PeriodEnum.Minute;
                case Periodicity.Hourly:
                    return PeriodEnum.Hour;
                case Periodicity.Daily:
                    return PeriodEnum.Day;
                case Periodicity.Weekly:
                    return PeriodEnum.Week;
                case Periodicity.Monthly:
                    return PeriodEnum.Month;
                default:
                    return PeriodEnum.Minute;
            }
            
        }

        private void RaiseRowUpdateRequired(bool updateIndicatorCells)
        {
            if (null != OnRowUpdateRequired)
            {
                OnRowUpdateRequired(UniqueId, GetCells(updateIndicatorCells));
            }
        }

        private void RaiseCellAdded(IRadarViewIndicator indicator)
        {
            if (null != OnCellAdditionRequired)
            {
                OnCellAdditionRequired(CreateCellFor(indicator));
            }
        }

        private void RaiseCellUpdateRequired(IRadarViewIndicator indicator)
        {
            if (null != OnCellUpdateRequired)
            {
                OnCellUpdateRequired(CreateCellFor(indicator));
            }
        }

        private double GetApplicableCandlestickValue(Candlestick latestCandle)
        {
            if (latestCandle.TimeOfClose <= DateTime.UtcNow)
            {
                return latestCandle.Close;
            }
            return latestCandle.LastTrade;
        }

        private bool TryFindRadarIndicator(Indicator indicator, out IRadarViewIndicator radarIndicator)
        {
            radarIndicator = _indicators.FirstOrDefault(ri => ri.AssociatedIndicator.Name.Equals(indicator.Name));
            return radarIndicator != null;
        }

        private static string CreateCellTag(string symbol, string columnKey)
        {
            return string.Format("{0}_{1}", symbol, columnKey);
        }

        private RadarGridCell CreateCellFor(IRadarViewIndicator indicator)
        {
            if (indicator.AssociatedIndicator.IsTrendIndicator)
            {
                return CreateTrendCellFor(indicator);
            }

            string cellText = indicator.Value != 0 ? indicator.Value.ToString() : "-";
            string cellTag = CreateCellTag(_associatedInstrument.Symbol, indicator.AssociatedIndicator.Abbreviation);
            return new RadarGridCell(UniqueId, cellText, cellTag, RadarColumnType.Indicator) 
            { 
                AlertTriggered = indicator.AlertTriggered 
            };
        }

        private RadarGridCell CreateTrendCellFor(IRadarViewIndicator indicator)
        {
            string cellTag = CreateCellTag(_associatedInstrument.Symbol, indicator.AssociatedIndicator.Abbreviation);
            string cellText = "-";
            switch (indicator.AlertTriggered)
            {
                case AlertScriptTypes.Buy:
                    cellText = "Bullish";
                    break;
                case AlertScriptTypes.Sell:
                    cellText = "Bearish";
                    break;
            }
            return new RadarGridCell(UniqueId, cellText, cellTag, RadarColumnType.Indicator)
            {
                AlertTriggered = indicator.AlertTriggered
            };
        }

        #endregion
    }
}
