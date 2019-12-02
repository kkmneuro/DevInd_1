// C# Excel Writer library v2.0
// by Serhiy Perevoznyk, 2008-2011

using System.Drawing;

namespace XLSExportDemo
{
    internal class FontInfo
    {
        public FontInfo(Font font, ExcelColor color)
        {
            Font = font;
            Color = color;
        }

        public Font Font { get; set; }
        public ExcelColor Color { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is FontInfo)
            {
                var info = (FontInfo) obj;
                return (Font.Equals(info.Font) && (Color.Equals(info.Color)));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Font.GetHashCode() ^ Color.GetHashCode();
        }
    }
}