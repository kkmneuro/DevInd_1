using System;
//using FundXchange.Model.ViewModels.Indicators;
using System.Drawing;

namespace PALSA.ClsRadar
{
    [Serializable]
    public class IndicatorColumnTemplate : IEquatable<IndicatorColumnTemplate>
    {
        public IndicatorColumnTemplate(Indicator associatedIndicator, string columnIdentifier)
        {
            AssociatedIndicator = associatedIndicator;
            ColumnIdentifier = columnIdentifier;
            SortOrder = -1;
            OverBoughtConditionColor = Color.LimeGreen;
            OverSoldConditionColor = Color.Red;
        }

        public Indicator AssociatedIndicator { get; private set; }
        public string ColumnIdentifier { get; private set; }
        public Color OverBoughtConditionColor { get; set; }
        public Color OverSoldConditionColor { get; set; }
        public int OverBoughtValue { get; set; }
        public int OverSoldValue { get; set; }
        public int SortOrder { get; set; }

        public static IndicatorColumnTemplate CreateDefault(Indicator associatedIndicator, string columnIdentifier)
        {
            return new IndicatorColumnTemplate(associatedIndicator, columnIdentifier);
        }

        #region IEquatable<IndicatorColumnTemplate> Members

        public bool Equals(IndicatorColumnTemplate other)
        {
            return this.ColumnIdentifier == other.ColumnIdentifier;
        }

        #endregion
    }

    [Serializable]
    public class Indicator
    {
        public Indicator() { }

        public Indicator(string name, string abbreviation, string script)
            : this(name, abbreviation, script, false) { }

        public Indicator(string name, string abbreviation, string script, bool isUserDefined)
            : this(Guid.NewGuid(), name, abbreviation, script, isUserDefined) { }

        public Indicator(Guid uniqueId, string name, string abbreviation, string script, bool isUserDefined)
        {
            UniqueId = uniqueId;
            Name = name;
            Abbreviation = abbreviation;
            Script = script;
            IsUserDefined = isUserDefined;
        }

        public Guid UniqueId { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Script { get; private set; }
        public bool IsUserDefined { get; private set; }
        public bool IsTrendIndicator
        {
            get { return Name == "Trend Indicator"; }
        }

        public string BuyScript { get; set; }
        public string SellScript { get; set; }

        private string _tradeSignalScript;
        public string TradeSignalScript
        {
            get
            {
                if (string.IsNullOrEmpty(_tradeSignalScript))
                    return BuyScript;
                return _tradeSignalScript;
            }
            set { _tradeSignalScript = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Indicator)
            {
                return this.UniqueId == (obj as Indicator).UniqueId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return UniqueId.GetHashCode();
        }
    }
}
