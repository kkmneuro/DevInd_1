using System;
using System.Drawing;
using System.IO;
using Nevron.UI.WinForm.Controls;
using System.Windows.Forms;

namespace PALSA.Cls
{
    public static class ClsPalsaUtility
    {
        public static void SetFormProperties(NForm frm, ColorScheme curColorScheme)
        {
            try
            {
                NUIManager.Palette.Scheme = curColorScheme;
                NUIManager.ApplyPalette();
                if (frm.CurrentFrameAppearance!=null)
                {
                    frm.CurrentFrameAppearance.CaptionFont = new Font("Verdana", 8F, FontStyle.Bold); 
                }                
            }
            catch (Exception)
            {
                
                
            }
           
            // frm.CurrentFrameAppearance.CaptionHeight = 24;
            //frm.CurrentFrameAppearance.ButtonSize = new Size(8, 8);
        }

        public static string GetHotKeysFileName()
        {
            string hotKeyFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                "LTechIndia\\Setting\\Hotekey.palsa";
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
        public static string GetDefaultPortfolioFile()
        {
            string directorypath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "LTechIndia\\Setting";
            string portfolioFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                     "LTechIndia\\Setting\\Default.palsa";
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
                //if (File.Exists(portfolioFile))
                //{
                   
                //}
                //else
                //{
                //    File.Move(Application.StartupPath + "\\Resx\\Default.palsa", directorypath + "\\Default.palsa");
                //}
            }
                 File.Copy(Application.StartupPath + "\\Resx\\Default.palsa", directorypath + "\\Default.palsa", true);          
            return portfolioFile;
        }
        public static string GetPortfolioFileName(string UserCode)
        {
            string portfolioFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "LTechIndia\\Setting\\" + UserCode + ".palsa";
            return portfolioFile;
        }

        public static string GetChartFolder()
        {
            string chartFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "LTechIndia\\Setting\\";
            return chartFolder;
        }

        public static string DeafultWorkSpacePath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                   "LTechIndia\\WORKSPACE";
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                              "LTechIndia\\WORKSPACE\\Default.dfb";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //if (File.Exists(filepath))
            //{
            //    File.Copy(Application.StartupPath + "\\Resx\\Default.dfb", directoryPath + "\\Default.dfb", true);
            //    File.Copy(Application.StartupPath + "\\Resx\\Default.dat", directoryPath + "\\Default.dat", true);
            //}
            //else
            //{
          
                File.Copy(Application.StartupPath + "\\Resx\\Default.dfb", directoryPath + "\\Default.dfb", true);
                File.Copy(Application.StartupPath + "\\Resx\\Default.dat", directoryPath + "\\Default.dat", true);


        //}
            //else
            //{
            //    File.Copy(Application.StartupPath + "\\Resx\\Default.dfb", directoryPath + "\\", true);
            //    File.Copy(Application.StartupPath + "\\Resx\\Default.dat", directoryPath + "\\", true);
            //}
            //else
            //{
            //    File.Copy(Application.StartupPath + "\\Resx\\Default.dfb", directoryPath + "\\Default.dfb", true);
            //}
          
            return filepath;
        }

        public static string GetProfileFileName()
        {
            string profileFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                 "LTechIndia\\Setting\\Profiles.palsa";
            return profileFile;
        }

        public static string GetLoggingPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LTechIndia\\Logs\\Log_" +
                   DateTime.UtcNow.ToString("dd_MM_yyyy");
        }

        //public static string GetChartsPath()
        //{
        //    string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
        //                           "DAWISH_IT\\Charts";
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }
        //    return directoryPath;
        //}

        internal static string GetSymbolsFilePath()
        {
            string symbolsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                "LTechIndia\\Setting\\Symbols.xml";
            string directorypath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                                  "LTechIndia\\Setting";

            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
                //if (File.Exists(portfolioFile))
                //{

                //}
                //else
                //{
                //    File.Move(Application.StartupPath + "\\Resx\\Default.palsa", directorypath + "\\Default.palsa");
                //}
            }
            File.Copy(Application.StartupPath + "\\Resx\\Symbols.xml", directorypath + "\\Symbols.xml", true);
            return symbolsFile;
        }
    }
}