//using FundXchange.Model.ViewModels.Generic;
using System.Drawing;
using System;
//using FundXchange.Domain.Enumerations;

namespace PALSA.ClsRadar
{
    public class RadarGridCell : GridCell
    {
        public RadarGridCell(Guid ownerId, string text, string tag)
            : this(ownerId, text, tag, RadarColumnType.InstrumentValue)
        {
        }

        public RadarGridCell(Guid ownerId, string text, string tag, RadarColumnType associatedColumnType)
            : base(text, Color.Black, Color.White)
        {
            OwnerId = ownerId;
            Tag = string.Format("{0}_{1}", tag, associatedColumnType);
            AssociatedColumnType = associatedColumnType;
        }

        public Guid OwnerId { get; private set; }
        public string Tag { get; private set; }
        public RadarColumnType AssociatedColumnType { get; private set; }
        public AlertScriptTypes AlertTriggered { get; set; }
    }

    public class GridCell
    {
        public GridCell()
        {
        }

        public GridCell(string text, Color backColor, Color foreColor)
        {
            Text = text;
            BackColor = backColor;
            ForeColor = foreColor;
        }

        public string Text { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
    }

    public enum RadarColumnType
    {
        InstrumentValue,
        Indicator
    }

    public enum AlertScriptTypes
    {
        None,
        Buy,
        Sell,
        TradeSignal
    }

    public enum RadarAlertType
    {
        Disabled,
        Simple,
        Professional
    }
}
