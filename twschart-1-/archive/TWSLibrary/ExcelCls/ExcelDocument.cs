// C# Excel Writer library v2.0
// by Serhiy Perevoznyk, 2008-2011

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace XLSExportDemo
{
    public class ExcelDocument
    {
        private readonly Dictionary<Int64, CellInfo> cells;
        private readonly ushort[] clBegin = {BIFF.BOFRecord, 0x8, 0x0, 0x10, 0x0, 0x0};
        private readonly ushort[] clEnd = {BIFF.EOFRecord, 00};
        private readonly List<ColumnInfo> columns;
        private readonly Font defaultFont = new Font("Arial", 10);

        private readonly List<FontInfo> fonts;
        private readonly List<string> formats;
        private readonly List<FormatInfo> fx;
        private readonly List<int> rows;

        public ExcelDocument()
        {
            CodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage;
            rows = new List<int>();
            columns = new List<ColumnInfo>();
            cells = new Dictionary<Int64, CellInfo>();
            fonts = new List<FontInfo>();

            fonts.Add(new FontInfo(DefaultFont, ExcelColor.Automatic));
            fonts.Add(new FontInfo(DefaultFont, ExcelColor.Automatic));
            fonts.Add(new FontInfo(DefaultFont, ExcelColor.Automatic));
            fonts.Add(new FontInfo(DefaultFont, ExcelColor.Automatic));

            fx = new List<FormatInfo>();

            formats = new List<string>();
            formats.Add("General");
            formats.Add("0");
            formats.Add("0.00");
            formats.Add("#,##0");
            formats.Add("#,##0.00");
            formats.Add("($#,##0_);($#,##0)");
            formats.Add("($#,##0_);[Red]($#,##0)");
            formats.Add("($#,##0.00_);($#,##0.00)");
            formats.Add("($#,##0.00_);[Red]($#,##0.00)");
            formats.Add("0%");
            formats.Add("0.00%");
            formats.Add("0.00E+00");
            formats.Add("# ?/?");
            formats.Add("# ??/??");
            formats.Add("m/d/yy");
            formats.Add("d-mmm-yy");
            formats.Add("d-mmm");
            formats.Add("mmm-yy");
            formats.Add("h:mm AM/PM");
            formats.Add("h:mm:ss AM/PM");
            formats.Add("h:mm");
            formats.Add("h:mm:ss");
            formats.Add("m/d/yy h:mm");
            formats.Add("(#,##0_);(#,##0)");
            formats.Add("(#,##0_);[Red](#,##0)");
            formats.Add("(#,##0.00_);(#,##0.00)");
            formats.Add("(#,##0.00_);[Red](#,##0.00)");
            formats.Add("_(* #,##0_);_(* (#,##0);_(* \"-\"_);_(@_)");
            formats.Add("_($* #,##0_);_($* (#,##0);_($* \"-\"_);_(@_)");
            formats.Add("_(* #,##0.00_);_(* (#,##0.00);_(* \"-\"??_);_(@_)");
            formats.Add("_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)");
            formats.Add("mm:ss");
            formats.Add("[h]:mm:ss");
            formats.Add("mm:ss.0");
            formats.Add("##0.0E+0");
            formats.Add("@");
        }

        internal List<string> Formats
        {
            get { return formats; }
        }

        internal List<FontInfo> Fonts
        {
            get { return fonts; }
        }

        internal List<FormatInfo> FX
        {
            get { return fx; }
        }

        public Cell this[int row, int column]
        {
            get { return Cell(row, column); }
        }

        public Font DefaultFont
        {
            get { return defaultFont; }
        }

        /// <summary>
        /// Gets or sets the code page.
        /// </summary>
        /// <value>The code page.</value>
        public int CodePage { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        internal CellInfo GetCellInfo(int row, int column)
        {
            Int64 key = HashCode(row, column);
            CellInfo result;
            if (cells.TryGetValue(key, out result))
                return result;
            else
            {
                if (rows.IndexOf(row) == -1)
                    rows.Add(row);
                result = new CellInfo(this);
                result.Row = row;
                result.Column = column;
                cells.Add(key, result);
                return result;
            }
        }

        private static Int64 HashCode(int row, int column)
        {
            return (((Int64) row << 32) + column);
        }

        public Cell Cell(int row, int column)
        {
            return new Cell(row, column, this);
        }

        public void WriteCell(int row, int column, object value)
        {
            Cell(row, column).Value = value;
        }

        public void ColumnWidth(int column, int width)
        {
            var info = new ColumnInfo {Index = column, Width = width};
            int idx = columns.IndexOf(info);
            if (idx == -1)
            {
                columns.Add(info);
            }
            else
            {
                columns[idx].Width = width;
            }
        }

        private static void WriteUshortArray(BinaryWriter writer, ushort[] value)
        {
            for (int i = 0; i < value.Length; i++)
                writer.Write(value[i]);
        }

        private static void WriteByteArray(BinaryWriter writer, byte[] value)
        {
            for (int i = 0; i < value.Length; i++)
                writer.Write(value[i]);
        }

        private void WriteEmptyCell(BinaryWriter writer, CellInfo cell)
        {
            ushort[] clData = {0x0201, 6, 0, 0, 15};
            clData[2] = (ushort) cell.Row;
            clData[3] = (ushort) cell.Column;
            WriteUshortArray(writer, clData);
        }

        private static bool IsNumber(object value)
        {
            if (value is sbyte) return true;
            if (value is byte) return true;
            if (value is short) return true;
            if (value is ushort) return true;
            if (value is int) return true;
            if (value is uint) return true;
            if (value is long) return true;
            if (value is ulong) return true;
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }

        private void WriteCellValue(BinaryWriter writer, CellInfo cell)
        {
            if (cell.Value == null)
                WriteEmptyCell(writer, cell);
            else if (cell.Value is string)
                WriteStringCell(writer, cell);
            else if (IsNumber(cell.Value))
                WriteNumberCell(writer, cell);
            else if (cell.Value is DateTime)
                WriteDateCell(writer, cell);
            else
                WriteStringCell(writer, cell);
        }

        private void WriteStringCell(BinaryWriter writer, CellInfo cell)
        {
            string value;
            if (cell.Value is string)
                value = (string) cell.Value;
            else
                value = cell.Value.ToString();
            if (value.Length > 255)
                value = value.Substring(0, 255);
            ushort[] clData = {BIFF.LabelRecord, 0, 0, 0, 0, 0};
            byte[] plainText = Encoding.GetEncoding(CodePage).GetBytes(value);
            int iLen = plainText.Length;
            clData[1] = (ushort) (8 + iLen);
            clData[2] = (ushort) cell.Row;
            clData[3] = (ushort) cell.Column;
            clData[4] = cell.FXIndex;
            clData[5] = (ushort) iLen;
            WriteUshortArray(writer, clData);
            writer.Write(plainText);
        }

        private void WriteDateCell(BinaryWriter writer, CellInfo cell)
        {
            DateTime value;
            if (cell.Value is DateTime)
            {
                value = (DateTime) cell.Value;
                var baseDate = new DateTime(1899, 12, 31);
                TimeSpan ts = value - baseDate;
                var days = (double) (ts.Days + 1);
                if (days >= 60)
                {
                    days += 1;
                }
                ushort[] clData = {BIFF.NumberRecord, 14, (ushort) cell.Row, (ushort) cell.Column, cell.FXIndex};
                WriteUshortArray(writer, clData);
                writer.Write(days);
            }
        }


        private void WriteNumberCell(BinaryWriter writer, CellInfo cell)
        {
            double dValue = Convert.ToDouble(cell.Value);
            ushort[] clData = {BIFF.NumberRecord, 14, (ushort) cell.Row, (ushort) cell.Column, cell.FXIndex};
            WriteUshortArray(writer, clData);
            writer.Write(dValue);
        }

        public void Save(Stream stream)
        {
            if (CodePage == 0)
                CodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage;

            BuildInternalTables();

            var writer = new BinaryWriter(stream);
            WriteUshortArray(writer, clBegin);

            WriteAuthorRecord(writer);
            WriteCodepageRecord(writer);
            WriteFontTable(writer);
            WriteHeaderRecord(writer);
            WriteFooterRecord(writer);
            WriteFormatTable(writer);
            WriteWindowProtectRecord(writer);
            WriteXFTable(writer);
            WriteStyleTable(writer);

            foreach (ColumnInfo t in columns)
            {
                WriteColumnInfoRecord(writer, t);
            }

            rows.Sort();

            foreach (int t in rows)
            {
                foreach (var cell in cells)
                {
                    if (cell.Value.Row == t)
                        WriteCellValue(writer, cell.Value);
                }
            }


            WriteUshortArray(writer, clEnd);
            writer.Flush();
        }

        private void BuildInternalTables()
        {
            FormatInfo info;

            foreach (var cell in cells)
            {
                info = new FormatInfo(cell.Value);
                if (cell.Value.Document.FX.IndexOf(info) == -1)
                    cell.Value.Document.FX.Add(info);

                cell.Value.FXIndex = (byte) (cell.Value.Document.FX.IndexOf(info) + 21);
            }
        }


        private void WriteAuthorRecord(BinaryWriter writer)
        {
            ushort[] clData = {0x005c, 32};
            string writerName;
            if (string.IsNullOrEmpty(UserName))
                writerName = string.Empty.PadRight(31);
            else
            {
                writerName = UserName.Substring(0, UserName.Length > 31 ? 31 : UserName.Length);
                writerName = writerName.PadRight(31);
            }

            WriteUshortArray(writer, clData);
            writer.Write(writerName);
        }

        private void WriteCodepageRecord(BinaryWriter writer)
        {
            ushort[] clData = {BIFF.CodepageRecord, 0x2, 0};
            clData[2] = (ushort) CodePage;
            WriteUshortArray(writer, clData);
        }

        private void WriteHeaderRecord(BinaryWriter writer)
        {
            ushort[] clData = {BIFF.HeaderRecord, 0};
            WriteUshortArray(writer, clData);
        }

        private void WriteFooterRecord(BinaryWriter writer)
        {
            ushort[] clData = {BIFF.FooterRecord, 0};
            WriteUshortArray(writer, clData);
        }

        private void WriteFormat(BinaryWriter writer, string value)
        {
            ushort[] clData = {BIFF.FormatRecord, 0};
            byte[] plainText = Encoding.ASCII.GetBytes(value);
            int iLen = plainText.Length;
            clData[1] = (ushort) (1 + iLen);
            WriteUshortArray(writer, clData);
            writer.Write((byte) iLen);
            writer.Write(plainText);
        }

        private void WriteFormatTable(BinaryWriter writer)
        {
            foreach (string t in formats)
            {
                WriteFormat(writer, t);
            }
        }

        private void WriteWindowProtectRecord(BinaryWriter writer)
        {
            ushort[] clData = {BIFF.WindowProtectRecord, 2, 0};
            WriteUshortArray(writer, clData);
        }

        private void WriteColumnInfoRecord(BinaryWriter writer, ColumnInfo info)
        {
            ushort[] clData = {
                                  BIFF.ColumnInfoRecord, 12, (ushort) info.Index, (ushort) info.Index,
                                  (ushort) (info.Width*256/7), 15, 0, 0
                              };
            WriteUshortArray(writer, clData);
        }

        private void WriteFontRecord(BinaryWriter writer, Font font, ExcelColor color)
        {
            ushort[] clData = {BIFF.FontRecord, 0, 0, 0, color.Index};
            byte[] plainText = Encoding.ASCII.GetBytes(font.FontFamily.Name);
            int iLen = plainText.Length;
            clData[1] = (ushort) (7 + iLen);
            clData[2] = (ushort) (font.SizeInPoints*20);
            int flags = 0;
            if (font.Bold)
                flags |= 1;
            if (font.Italic)
                flags |= 2;
            if (font.Underline)
                flags |= 4;
            if (font.Strikeout)
                flags |= 8;
            clData[3] = (ushort) flags;

            WriteUshortArray(writer, clData);
            writer.Write((byte) iLen);
            writer.Write(plainText);
        }

        private void WriteFontTable(BinaryWriter writer)
        {
            foreach (FontInfo font in fonts)
            {
                WriteFontRecord(writer, font.Font, font.Color);
            }
        }

        private void WriteXFTable(BinaryWriter writer)
        {
            ushort[][] clData = {
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0x03F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0001, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0001, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0002, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0002, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0xF7F5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0000, 0x0001, 0x0000, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x2101, 0xFBF5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x1F01, 0xFBF5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x2001, 0xFBF5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x1E01, 0xFBF5, 0xFFF0, 0xCE00, 0x0000, 0x0000},
                                    new ushort[] {0x0243, 0x00C, 0x0901, 0xFBF5, 0xFFF0, 0xCE00, 0x0000, 0x0000}
                                };
            for (int i = 0; i < 21; i++)
            {
                WriteUshortArray(writer, clData[i]);
            }

            foreach (FormatInfo info in fx)
            {
                WriteFXRecord(writer, info);
            }
        }

        private void WriteFXRecord(BinaryWriter writer, FormatInfo info)
        {
            var clData = new ushort[2];
            clData[0] = BIFF.ExtendedRecord;
            clData[1] = 0x00C;
            WriteUshortArray(writer, clData);

            var clValue = new byte[4];
            clValue[0] = (byte) info.FontIndex;
            clValue[1] = (byte) info.FormatIndex;
            clValue[2] = 0x01;

            byte attr = 0;
            if (info.FontIndex > 0)
                attr |= 0x02;
            if (info.HorizontalAlignment != Alignment.General)
                attr |= 0x04;
            if (info.BackColor.Index != ExcelColor.Automatic.Index)
                attr |= 0x10;
            attr = (byte) (attr << 2);
            clValue[3] = attr;
            WriteByteArray(writer, clValue);

            //(orig & ~mask) | (input & mask)

            var horizontalAlignment = (ushort) info.HorizontalAlignment;

            ushort backgroundArea = 1;
            if (info.BackColor.Index != ExcelColor.Automatic.Index)
            {
                backgroundArea =
                    (ushort) ((backgroundArea & ~0x07C0) | (info.BackColor.Index & 0x07C0 >> 6) << 6);
                backgroundArea =
                    (ushort)
                    ((backgroundArea & ~0xF800) | (ExcelColor.WindowText.Index & 0xF800 >> 11) << 11);
            }
            else
                backgroundArea = 0xCE00;

            ushort[] rest = {horizontalAlignment, backgroundArea, 0x0000, 0x0000};
            WriteUshortArray(writer, rest);
        }

        private void WriteStyleTable(BinaryWriter writer)
        {
            byte[][] clData = {
                                  new byte[] {0x10, 0x80, 0x03, 0xFF},
                                  new byte[] {0x11, 0x00, 0x09, 0x43, 0x6F, 0x6D, 0x6D, 0x61, 0x20, 0x5B, 0x30, 0x5D},
                                  new byte[] {0x12, 0x80, 0x04, 0xFF},
                                  new byte[]
                                      {
                                          0x13, 0x00, 0x0C, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x63, 0x79, 0x20, 0x5B,
                                          0x30, 0x5D
                                      },
                                  new byte[] {0x00, 0x80, 0x00, 0xFF},
                                  new byte[] {0x14, 0x80, 0x05, 0xFF}
                              };

            var clHeader = new ushort[2];
            clHeader[0] = BIFF.StyleRecord;

            for (int i = 0; i < 6; i++)
            {
                clHeader[1] = (ushort) clData[i].Length;
                WriteUshortArray(writer, clHeader);
                WriteByteArray(writer, clData[i]);
            }
        }
    }
}