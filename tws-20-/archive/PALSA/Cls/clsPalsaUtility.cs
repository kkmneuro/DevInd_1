using System;
using System.Drawing;
using System.IO;
using Nevron.UI.WinForm.Controls;

namespace TWS.Cls
{
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
                                 "TWS\\Setting\\"+ UserCode + "_MW.TWS";
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