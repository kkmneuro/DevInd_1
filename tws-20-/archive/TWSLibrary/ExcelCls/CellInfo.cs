// C# Excel Writer library v2.0
// by Serhiy Perevoznyk, 2008-2011

using System;
using System.Drawing;

namespace XLSExportDemo
{
    internal class CellInfo
    {
        private object _value;

        public CellInfo(ExcelDocument document)
        {
            BackColor = ExcelColor.Automatic;
            ForeColor = ExcelColor.Automatic;
            Font = document.DefaultFont;
            Document = document;
        }

        internal byte FXIndex { get; set; }
        public ExcelDocument Document { get; set; }

        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (value is DateTime)
                    Format = Document.Formats[15];
            }
        }

        public string Format { get; set; }
        public ExcelColor BackColor { get; set; }
        public ExcelColor ForeColor { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Font Font { get; set; }
        public Alignment Alignment { get; set; }
    }
}