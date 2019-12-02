using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TWS.Cls
{
    [Serializable]
    public class TWSSettings
    {
        public Dictionary<int, CommandBarSetting> DDCommandBarSetting = new Dictionary<int, CommandBarSetting>();
        public Dictionary<string, FormSettings> DDformSetting = new Dictionary<string, FormSettings>();
        public Dictionary<int, MenuSetting> DDmenuItemsSetting = new Dictionary<int, MenuSetting>();
    }

    [Serializable]
    public class MenuSetting
    {
        public MenuSetting(int commandId, string commandText, bool _checked)
        {
            CommandId = commandId;
            CommandText = commandText;
            Checked = _checked;
        }

        public int CommandId { get; set; }
        public string CommandText { get; set; }
        public bool Checked { get; set; }
    }

    [Serializable]
    public class FormSettings
    {
        public FormSettings(Point formLoc, FormWindowState windowState, int height, int width, String title)
        {
            FormLocation = formLoc;
            WindowState = windowState;
            Height = height;
            Width = width;
            Title = title;
        }

        public Point FormLocation { get; set; }
        public FormWindowState WindowState { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Title { get; set; }
    }

    [Serializable]
    public class CommandBarSetting
    {
        public bool CanFloat;
        public string Parent;

        public CommandBarSetting(int floatingX, int floatingY, int floatingWidth, int floatingHeight, int locationX,
                                 int locationY, int height, int width, int rowindex, int index, bool visible,
                                 string parent, bool canFloat)
        {
            FloatingX = floatingX;
            FloatingY = floatingY;
            FloatingWidth = floatingWidth;
            FloatingHeight = floatingHeight;
            LocationX = locationX;
            LocationY = locationX;
            Height = height;
            Width = width;
            RowIndex = rowindex;
            Index = index;
            Visible = visible;
            Parent = parent;
            CanFloat = canFloat;
        }

        public int FloatingX { get; set; }
        public int FloatingY { get; set; }
        public int FloatingWidth { get; set; }
        public int FloatingHeight { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int RowIndex { get; set; }
        public int Index { get; set; }
        public bool Visible { get; set; }
    }
}