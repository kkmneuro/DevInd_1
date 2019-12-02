using System;

namespace CommonLibrary.Cls
{
    [Serializable]
    public class ClsColumnSetting
    {
        public ClsColumnSetting(int index, bool visible, string columnText)
        {
            Index = index;
            Visible = visible;
            ColumnText = columnText;
        }

        public int Index { get; set; }
        public bool Visible { get; set; }
        public string ColumnText { get; set; }
    }
}