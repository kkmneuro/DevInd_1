using System;
using System.Collections.Generic;
using PALSA.DS;
using PALSA.Frm;
using System.IO;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Cls
{
    [Serializable]
    public class PALSASettings
    {
        public Dictionary<string, DockPanelSettings> DDDocumentsSetting = new Dictionary<string, DockPanelSettings>();
        public Dictionary<string, List<OHLC>> DDsymbolsOhlc = new Dictionary<string, List<OHLC>>();
        public List<DockPanelSettings> LstDockPanel1Items=new List<DockPanelSettings>();
        public List<DockPanelSettings> LstDockPanel2Items = new List<DockPanelSettings>();
        public Dictionary<string,DS4MarketWatch> DDPortfolioQuotes=new Dictionary<string, DS4MarketWatch>();
     

    }
    public enum DockItems { MarketQuote,Chart, MarketWatch,MarketDepth,Radar,Scanner,Accounts, Alert, OrderBook, Trade, PendingOrder, Mail }; 

    [Serializable]
    public class DockPanelSettings
    {
        public DockPanelSettings(DockItems di,int docindex,string dockey,string ctrlKey,string text,bool isActive)
        {
            DockItem = di; 
            DocIndex=docindex;
            DocKey=dockey;
            CtrlKey=ctrlKey;
            Text=text;
            IsActive = isActive;
        }

        public DockPanelSettings()
        {
            // TODO: Complete member initialization
        }
        public DockItems DockItem { get; set; }
        public int DocIndex { get; set; }
        public string DocKey { get; set; }
        public string CtrlKey{get;set;}
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }
    [Serializable]
    public class DocSettings 
    {
        public DocSettings(int docindex,string dockey,string ctrlKey,string text,bool isActive)
        {
            DocIndex=docindex;
            DocKey=dockey;
            CtrlKey=ctrlKey;
            Text=text;
            IsActive = isActive;
        }
        public int DocIndex { get; set; }
        public string DocKey { get; set; }
        public string CtrlKey{get;set;}
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }

    //[Serializable]
    //public class MenuSetting
    //{
    //    public MenuSetting(int commandId, string commandText, bool _checked)
    //    {
    //        CommandId = commandId;
    //        CommandText = commandText;
    //        Checked = _checked;
    //    }

    //    public int CommandId { get; set; }
    //    public string CommandText { get; set; }
    //    public bool Checked { get; set; }
    //}

    //[Serializable]
    //public class FormSettings
    //{
    //    public FormSettings(Point formLoc, FormWindowState windowState, int height, int width, String title)
    //    {
    //        FormLocation = formLoc;
    //        WindowState = windowState;
    //        Height = height;
    //        Width = width;
    //        Title = title;
    //    }

    //    public Point FormLocation { get; set; }
    //    public FormWindowState WindowState { get; set; }
    //    public int Height { get; set; }
    //    public int Width { get; set; }
    //    public string Title { get; set; }
    //}

    //[Serializable]
    //public class CommandBarSetting
    //{
    //    public bool CanFloat;
    //    public string Parent;

    //    public CommandBarSetting(int floatingX, int floatingY, int floatingWidth, int floatingHeight, int locationX,
    //                             int locationY, int height, int width, int rowindex, int index, bool visible,
    //                             string parent, bool canFloat)
    //    {
    //        FloatingX = floatingX;
    //        FloatingY = floatingY;
    //        FloatingWidth = floatingWidth;
    //        FloatingHeight = floatingHeight;
    //        LocationX = locationX;
    //        LocationY = locationX;
    //        Height = height;
    //        Width = width;
    //        RowIndex = rowindex;
    //        Index = index;
    //        Visible = visible;
    //        Parent = parent;
    //        CanFloat = canFloat;
    //    }

    //    public int FloatingX { get; set; }
    //    public int FloatingY { get; set; }
    //    public int FloatingWidth { get; set; }
    //    public int FloatingHeight { get; set; }
    //    public int LocationX { get; set; }
    //    public int LocationY { get; set; }
    //    public int Height { get; set; }
    //    public int Width { get; set; }
    //    public int RowIndex { get; set; }
    //    public int Index { get; set; }
    //    public bool Visible { get; set; }
    //}
    public static class ClsTWSUtility
    {
        public static void SetFormProperties(NForm frm, ColorScheme curColorScheme)
        {
            NUIManager.Palette.Scheme = curColorScheme;
            NUIManager.ApplyPalette();
            if (frm != null)
            {
                //frm.CurrentFrameAppearance.CaptionFont = new Font("Verdana", 8F, FontStyle.Bold);
            }
            // frm.CurrentFrameAppearance.CaptionHeight = 24;
            //frm.CurrentFrameAppearance.ButtonSize = new Size(8, 8);
        }

        public static string GetHotKeysFileName()
        {
            string hotKeyFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                "TWS\\Setting\\Hotekey.TWS";
            return hotKeyFile;
        }

        public static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ' && char.IsLower(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
            return new string(array);
        }

        public static string GetPortfolioFileName(string UserCode)
        {
            string portfolioFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "TWS\\Setting\\" + UserCode + ".TWS";
            return portfolioFile;
        }

        public static string DeafultWorkSpacePath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "TWS\\WORKSPACE\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
        }

        public static string GetProfileFileName()
        {
            string profileFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                 "TWS\\Setting\\Profiles.TWS";
            return profileFile;
        }

        public static string GetMarketWatchFileName(string UserCode)
        {
            string profileFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                 "TWS\\Setting\\" + UserCode + "_MW.TWS";
            return profileFile;
        }

        public static string GetLoggingPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TWS\\Logs\\Log_" +
                   DateTime.Now.ToString("dd_MM_yyyy");
        }

        public static string GetChartsPath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "TWS\\Charts";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
        }

        internal static string GetSymbolsFilePath()
        {
            string symbolsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                     "TWS\\Setting\\Symbols.xml";
            string directorypath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                  "TWS\\Setting";

            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }

            return symbolsFile;
        }
    }
}