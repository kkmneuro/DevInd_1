// C# Excel Writer library v2.0
// by Serhiy Perevoznyk, 2008-2011

namespace XLSExportDemo
{
    internal class ColumnInfo
    {
        public int Width { get; set; }
        public int Index { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ColumnInfo)
            {
                return (Index == ((ColumnInfo) obj).Index);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}