﻿using System;
//using FundXchange.Model.ViewModels.Indicators;
//using FundXchange.Domain.Entities;
//using FundXchange.Model.ViewModels.Charts;
using System.Collections.Generic;
using PALSA.Cls;
//using FundXchange.Model.ViewModels.Generic;
namespace PALSA.ClsRadar
{
    public delegate void RowUpdateRequiredDelegate(Guid itemIdentifier, IEnumerable<RadarGridCell> cells);
    public delegate void CellUpdateRequiredDelegate(RadarGridCell updatedCell);
    public delegate void CellAddedDelegate(RadarGridCell newCell);

    public interface IRadarItem
    {
        event RowUpdateRequiredDelegate OnRowUpdateRequired;
        event CellAddedDelegate OnCellAdditionRequired;
        event CellUpdateRequiredDelegate OnCellUpdateRequired;
        Guid UniqueId { get; }
        SubscriptionDescriptor Descriptor { get; }
        IEnumerable<IRadarViewIndicator> GetIndicators();
        IEnumerable<RadarGridCell> GetCells(bool includeIndicatorCells);
        void AddIndicator(Indicator indicator);
        void PrepareForRemoval();
        void RemoveIndicator(Indicator indicator);
        void SetIndicatorIntervals(Periodicity periodicity, int interval, int startingBars);
        void SetIndicatorStatus(bool areActive);
        void UpdateWith(Instrument updatedInstrument);
        bool IsInterestedIn(Instrument instrument);
    }

    public delegate void RadarIndicatorChangedDelegate(RadarItemIndicator sender);

    public interface IRadarViewIndicator
    {
        event RadarIndicatorChangedDelegate OnChanged;
        Indicator AssociatedIndicator { get; }
        double Value { get; }
        bool IsOverBought { get; }
        bool IsOverSold { get; }
        AlertScriptTypes AlertTriggered { get; }
        bool IsActive { get; }
        void PrepareForRemoval();
        void AddCandle(Candlestick candlestick);
        void UpdateCandle(Candlestick candlestick);
        void InitializeWith(IEnumerable<Candlestick> candles);
        void SetStatus(bool areActive);
    }
}