using System;
using System.Collections.Generic;
using System.Linq;
using PALSA.Cls;


namespace PALSA.ClsRadar
{
    public class RadarGridController : IRadarGridController
    {
        #region Private members

        private readonly IRadarGridView _view;
        private readonly IDictionary<Guid, IRadarItem> _radars;
        private IList<Indicator> _activeIndicators;
        //private readonly IIndicatorRepository _indicatorRepository;
        private readonly IndicatorRepository _indicatorRepository;
        private readonly object _lockObject = new object();

        private delegate IRadarItem CreateRadarItemDelegate(Guid radarKey, SubscriptionDescriptor descriptor);
        private delegate void RemoveIndicatorsFromRadarItemsDelegate(IEnumerable<Indicator> selectedIndicators);

        #endregion

        #region Constructor

        public RadarGridController(/*IMarketRepository marketRepository,*/ IRadarGridView view)
        {
            
            _indicatorRepository = new IndicatorRepository();
            _view = view;
            _radars = new Dictionary<Guid, IRadarItem>();
            _activeIndicators = new List<Indicator>();

            
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= INSTANCE_onPriceUpdate;
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
        }
        

        void INSTANCE_onPriceUpdate(QuotesStream obj)
        {
            foreach (var item in obj.QuotesItem)
            {
                //Symbol sym = Symbol.GetSymbol(item.Key);

                //OnPriceFeed(sym, item.Value._lstItem);
            }
        }

        public Dictionary<string, Instrument> DDInstruments = new Dictionary<string, Instrument>();
        //Namo 21 March
        //private void OnPriceFeed(Symbol sym, List<QuoteItem> list)
        //{
        //    foreach (QuoteItem item2 in list)
        //    {
        //        if (!DDInstruments.Keys.Contains(sym.Contract))
        //        {
        //            Instrument Inst = new Instrument();
        //            Inst.Symbol = sym.Contract;
        //            Inst.Exchange = sym.Gateway;
        //            Inst.CompanyShortName = sym.Contract;
        //            Inst.CompanyLongName = sym.Contract;
        //            Inst.TotalTrades = 0;
        //            switch (item2._quoteType)
        //            {
        //                case QuoteStreamType.ASK:
        //                    {
        //                        if (ClsGlobal.DDRightZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDRightZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDRightZLevel.Add(sym.Contract, item2._Price);
        //                        }
        //                        Inst.BestOffer = item2._Price;
        //                        Inst.OfferVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.BID:
        //                    {
        //                        if (ClsGlobal.DDLeftZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLeftZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLeftZLevel.Add(sym.Contract, item2._Price);
        //                        }

        //                        Inst.BestBid = item2._Price;
        //                        Inst.BidVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.HIGH:
        //                    {
        //                        Inst.High = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.LOW:
        //                    {
        //                        Inst.Low = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.OPEN:
        //                    {
        //                        Inst.Open = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.CLOSE:
        //                    {
        //                        Inst.YesterdayClose = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME:
        //                    {
        //                        if (ClsGlobal.DDTotalValue.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalValue[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalValue.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        Inst.TotalValue = item2._Price;
        //                        Inst.TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.LAST:
        //                    {
        //                        if (ClsGlobal.DDLTP.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLTP[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLTP.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        Inst.LastTradeTime = DateTime.UtcNow;
        //                        Inst.LastTrade = item2._Price;
        //                        Inst.TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME_PER:
        //                    {
        //                        Inst.PercentageMoved = item2._Price;
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //            DDInstruments.Add(sym.Contract, Inst);
        //        }
        //        else
        //        {
        //            switch (item2._quoteType)
        //            {
        //                case QuoteStreamType.ASK:
        //                    {
        //                        if (ClsGlobal.DDRightZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDRightZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDRightZLevel.Add(sym.Contract, item2._Price);
        //                        }
        //                        DDInstruments[sym.Contract].BestOffer = item2._Price;
        //                        DDInstruments[sym.Contract].OfferVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.BID:
        //                    {
        //                        if (ClsGlobal.DDLeftZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLeftZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLeftZLevel.Add(sym.Contract, item2._Price);
        //                        }

        //                        DDInstruments[sym.Contract].BestBid = item2._Price;
        //                        DDInstruments[sym.Contract].BidVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.HIGH:
        //                    {
        //                        DDInstruments[sym.Contract].High = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.LOW:
        //                    {
        //                        DDInstruments[sym.Contract].Low = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.OPEN:
        //                    {
        //                        DDInstruments[sym.Contract].Open = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.CLOSE:
        //                    {
        //                        DDInstruments[sym.Contract].YesterdayClose = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME:
        //                    {
        //                        if (ClsGlobal.DDTotalValue.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalValue[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalValue.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        DDInstruments[sym.Contract].TotalValue = item2._Price;
        //                        DDInstruments[sym.Contract].TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.LAST:
        //                    {
        //                        if (ClsGlobal.DDLTP.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLTP[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLTP.Add(sym.Contract, item2._Price);
        //                        }
        //                        DDInstruments[sym.Contract].LastTradeTime = DateTime.UtcNow;
        //                        DDInstruments[sym.Contract].LastTrade = item2._Price;
        //                        DDInstruments[sym.Contract].TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME_PER:
        //                    {
        //                        DDInstruments[sym.Contract].PercentageMoved = item2._Price;
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //        }
        //        MarketRepositoryInstrumentUpdatedEvent(DDInstruments[sym.Contract]);//BroadCast quotes here
        //    }
        //}

        #endregion

        #region Public properties

        public IEnumerable<SubscriptionDescriptor> SubscribedSymbolDescriptors
        {
            get
            {
                return _radars.Where(r => r.Value != null).Select(r => r.Value.Descriptor).Distinct();
            }
        }

        private RadarTemplate _activeTemplate;
        public RadarTemplate Template
        {
            get
            {
                if (null == _activeTemplate)
                    _activeTemplate = RadarTemplate.Default;
                return _activeTemplate;
            }
            set { _activeTemplate = value; }
        }

        #endregion

        #region Public methods

        public void AddDefaultIndicators()
        {
            AddTrendIndicator();
        }

        public IEnumerable<IRadarItem> GetRadars()
        {
            IRadarItem[] radars = _radars.Values.ToArray();
            return radars;
        }

        public IEnumerable<Indicator> GetActiveIndicators()
        {
            Indicator[] indicators = _activeIndicators.ToArray();
            return indicators;
        }

        public void AddRadar(string symbol, string exchange)
        {
            var descriptor = new SubscriptionDescriptor(symbol, exchange, Template.IndicatorInterval, Template.IndicatorPeriodicity);
            AddRadar(descriptor);
        }

        public void AddRadar(SubscriptionDescriptor descriptor)
        {
            ValidateSubscriptionRequest(descriptor);

            Guid radarKey = Guid.NewGuid();
            _radars.Add(radarKey, null);

            var del = new CreateRadarItemDelegate(CreateRadarItem);
            del.BeginInvoke(radarKey, descriptor, delegate(IAsyncResult result)
            {
                if (result.IsCompleted)
                {
                    lock (_lockObject)
                    {
                        IRadarItem radarViewItem = del.EndInvoke(result);
                        if (null != radarViewItem)
                        {
                            _radars[radarKey] = radarViewItem;
                            _view.AddRadar(radarKey, radarViewItem.GetCells(false));

                            foreach (Indicator indicator in _activeIndicators)
                                radarViewItem.AddIndicator(indicator);
                        }
                        else
                        {
                            _radars.Remove(radarKey);
                        }
                    }
                }
            }, null);

        }

        public void RemoveRadars(IEnumerable<Guid> radarIdentifiers)
        {
            foreach (Guid uniqueId in radarIdentifiers)
            {
                RemoveRadar(uniqueId);
            }
        }

        public SubscriptionDescriptor GetRadarDescriptor(Guid uniqueIdentifer)
        {
            if (_radars.ContainsKey(uniqueIdentifer))
            {
                if(null != _radars[uniqueIdentifer])
                    return _radars[uniqueIdentifer].Descriptor;
            }
            return null;
        }

        public void SetRadarTimeFrames(IEnumerable<Guid> radarKeys, Periodicity periodicity, int interval)
        {
            foreach (Guid radarKey in radarKeys)
            {
                if (null != _radars[radarKey])
                {
                    _radars[radarKey].SetIndicatorIntervals(periodicity, interval, Template.StartingBars);
                }
            }
        }

        public void UpdateIndicators(IEnumerable<Indicator> selectedIndicators)
        {
            lock (_lockObject)
            {
                RemoveDeprecatedIndicators(selectedIndicators);
                AddNewIndicators(selectedIndicators.ToArray());
            }
        }

        public void RefreshIndicator(Indicator indicatorToRefresh)
        {
            var foundIndicator = _activeIndicators.FirstOrDefault(i => i.UniqueId == indicatorToRefresh.UniqueId);
            if (null != foundIndicator)
            {
                var del = new RemoveIndicatorsFromRadarItemsDelegate(RemoveIndicatorsFromRadarItems);
                del.BeginInvoke(new[] { foundIndicator }, delegate
                {
                    _activeIndicators.Remove(foundIndicator);

                    AddNewIndicator(indicatorToRefresh);
                }, null);
            }
        }

        public void SetIndicatorStatus(bool areEnabled)
        {
            foreach (var radar in _radars)
            {
                if(null != radar.Value)
                    radar.Value.SetIndicatorStatus(areEnabled);
            }
        }

        #endregion

        #region Helper methods

        private void ValidateSubscriptionRequest(SubscriptionDescriptor descriptor)
        {
            if (string.IsNullOrEmpty(descriptor.Symbol))
                throw new ArgumentException("Symbol cannot be empty");
            if (string.IsNullOrEmpty(descriptor.Exchange))//Commented By Kuldeep for time being
                throw new ArgumentException("Exchange cannot be empty");

            int count = 0;//_marketRepository.AllInstrumentReferences.Where(i => i.Symbol == descriptor.Symbol).Count();
            //if (count == 0)
            //    throw new ApplicationException(string.Format("Invalid symbol specified: {0}", descriptor.Symbol));
        }

        private IRadarItem CreateRadarItem(Guid radarKey, SubscriptionDescriptor descriptor)
        {
            Instrument radarInstrument = new Instrument();//Kul_marketRepository.SubscribeLevelOneWatch(descriptor.Symbol, descriptor.Exchange);
            radarInstrument.Symbol = descriptor.Symbol;
            
            if (null != radarInstrument)
            {
                IRadarItem radarViewItem = new RadarItem(radarKey, radarInstrument, descriptor.Periodicity, descriptor.Interval, _activeTemplate.StartingBars);

                radarViewItem.OnCellAdditionRequired += RadarViewItemIndicatorAdded;
                radarViewItem.OnCellUpdateRequired += RadarViewItemIndicatorValueChanged;
                radarViewItem.OnRowUpdateRequired += RadarViewItemOnIndicatorIntervalChanged;

                return radarViewItem;
            }
            return null;
        }        

        private void RemoveRadar(Guid radarKey)
        {
            var radarEntry = _radars[radarKey];
            if (null != radarEntry)
            {
                radarEntry.PrepareForRemoval();
                _radars.Remove(radarKey);
            }
        }

        private void RemoveIndicator(Guid indicatorId)
        {
            var foundIndicator = _activeIndicators.FirstOrDefault(i => i.UniqueId == indicatorId);
            if (null != foundIndicator)
            {
                var del = new RemoveIndicatorsFromRadarItemsDelegate(RemoveIndicatorsFromRadarItems);
                del.BeginInvoke(new[] { foundIndicator }, delegate
                {
                    _activeIndicators.Remove(foundIndicator);
                }, null);
            }
        }

        private void AddTrendIndicator()
        {
            Indicator trendIndicator;
            if (_indicatorRepository.TryGetIndicatorBy("Trend indicator", out trendIndicator))
            {
                AddNewIndicator(trendIndicator);
            }
        }

        private void AddNewIndicator(Indicator indicator)
        {
            if (!_activeIndicators.Contains(indicator))
            {
                _activeIndicators.Add(indicator);
                _view.AddIndicatorColumns(indicator);                

                AddIndicatorToRadarItems(indicator);
            }
        }

        private void AddNewIndicators(IEnumerable<Indicator> selectedIndicators)
        {
            lock (_lockObject)
            {
                foreach (Indicator indicator in selectedIndicators)
                {
                    AddNewIndicator(indicator);
                }
            }
        }

        private void AddIndicatorToRadarItems(Indicator indicator)
        {
            lock (_lockObject)
            {
                foreach (var radar in _radars)
                {
                    if (null != radar.Value)
                        radar.Value.AddIndicator(indicator);
                }
            }
        }

        private void RemoveIndicatorsFromRadarItems(IEnumerable<Indicator> indicatorsToRemove)
        {
            lock (_lockObject)
            {
                foreach (Indicator indicator in indicatorsToRemove)
                {
                    foreach (var radar in _radars)
                    {
                        if (null != radar.Value)
                            radar.Value.RemoveIndicator(indicator);
                    }
                    _view.RemoveIndicatorColumns(indicator);
                }
            }
        }

        private void RemoveDeprecatedIndicators(IEnumerable<Indicator> selectedIndicators)
        {
            var removalList = new List<Indicator>();
            foreach (Indicator indicator in _activeIndicators)
            {
                if (!selectedIndicators.Contains(indicator))
                {
                    removalList.Add(indicator);
                }
            }

            var del = new RemoveIndicatorsFromRadarItemsDelegate(RemoveIndicatorsFromRadarItems);
            del.BeginInvoke(removalList, delegate
            {
                _activeIndicators = selectedIndicators.ToList();
            }, null);
        }

        #endregion

        #region Event handlers

        private void MarketRepositoryInstrumentUpdatedEvent(Instrument instrument)
        {
            lock (_lockObject)
            {
                var interestedRadars = _radars.Values.Where(ri => ri != null && ri.IsInterestedIn(instrument));
                foreach (var radarItem in interestedRadars)
                {
                    radarItem.UpdateWith(instrument);
                    _view.UpdateCellsFor(radarItem.UniqueId, radarItem.GetCells(false));
                } 
            }
        }

        void RadarViewItemOnIndicatorIntervalChanged(Guid itemIdentifier, IEnumerable<RadarGridCell> cells)
        {
            _view.UpdateCellsFor(itemIdentifier, cells);
        }

        void RadarViewItemIndicatorAdded(RadarGridCell newCell)
        {
            _view.InitializeCell(newCell);
        }

        void RadarViewItemIndicatorValueChanged(RadarGridCell updatedCell)
        {
            _view.UpdateCell(updatedCell);
        }

        #endregion
    }
}
