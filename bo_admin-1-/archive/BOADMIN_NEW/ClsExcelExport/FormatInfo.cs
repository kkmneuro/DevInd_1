// C# Excel Writer library v2.0
// by Serhiy Perevoznyk, 2008-2011

using System.Drawing;

namespace XLSExportDemo
{
    internal class FormatInfo
    {
        private readonly CellInfo cell;
        private readonly int fontIndex;
        private readonly int formatIndex;

        public FormatInfo(CellInfo cell)
        {
            this.cell = cell;
            if (string.IsNullOrEmpty(cell.Format))
                formatIndex = 0;
            else
                formatIndex = cell.Document.Formats.IndexOf(cell.Format);

            var fontInfo = new FontInfo(cell.Font, cell.ForeColor);
            fontIndex = cell.Document.Fonts.IndexOf(fontInfo);
            if (fontIndex == -1)
            {
                cell.Document.Fonts.Add(fontInfo);
                fontIndex = cell.Document.Fonts.IndexOf(fontInfo);
            }

            if (fontIndex > 3)
                fontIndex++;
        }

        public ExcelColor BackColor
        {
            get { return cell.BackColor; }
        }

        public ExcelColor ForeColor
        {
            get { return cell.ForeColor; }
        }

        public Font Font
        {
            get { return cell.Font; }
        }

        public string Format
        {
            get { return cell.Format; }
        }

        public Alignment HorizontalAlignment
        {
            get { return cell.Alignment; }
        }

        public int FormatIndex
        {
            get { return formatIndex; }
        }

        public int FontIndex
        {
            get { return fontIndex; }
        }

        public override bool Equals(object obj)
        {
            if (obj is FormatInfo)
            {
                var info = (FormatInfo) obj;
                return ((fontIndex == info.fontIndex) && (formatIndex == info.formatIndex)
                        && (ForeColor.Index == info.ForeColor.Index) && (BackColor.Index == info.BackColor.Index)
                        && (HorizontalAlignment == info.HorizontalAlignment));
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}