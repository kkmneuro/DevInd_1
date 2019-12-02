using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.IO;
using System.Globalization;
using System.Text;
using System.Net.NetworkInformation;

namespace TWS.Cls
{
    public static class ClsGlobal
    {
        public static int BrokerAccountId = 0;
        public static int MarketMakerAccountId = 0;
        public static Dictionary<string, sbyte> DDOrderTypes;
        public static Dictionary<string, sbyte> DDSide;
        public static Dictionary<string, sbyte> DDValidity;
        public static Dictionary<string, sbyte> DDOrderStatus;
        public static Dictionary<sbyte, string> DDReverseOrderStatus;
        public static Dictionary<sbyte, string> DDReverseOrderType;
        public static Dictionary<sbyte, string> DDReverseSide;
        public static Dictionary<sbyte, string> DDReverseValidity;
        public static Dictionary<string, double> DDLeftZLevel;
        public static Dictionary<string, double> DDRightZLevel;
        public static Dictionary<string, double> DDLTP;
        public static Dictionary<string, double> DDRightZLevelQty;//Ask
        public static Dictionary<string, double> DDLeftZLevelQty;//Bid
        public static Dictionary<string, double> DDConversion;
        public static List<string> FutureSymbolList;
        public static Dictionary<string, int> DDContractSize;
        public static Dictionary<string, int> DDContractDigit;
        //public static List<Symbol> SubscibedSymbolList;
        public static Dictionary<string, Symbol> SubscibedSymbolList;
        public static Dictionary<string, double> DDOpen;
        public static Dictionary<string, double> DDHigh;
        public static Dictionary<string, double> DDLow;
        public static Dictionary<string, double> DDClose;
        public static Dictionary<string, int> DDVolume;
        private static int _clientOrderId = 700;
        public static bool _isFirstRequest = true;
        public static int BrokerGroupId = 2;
        public static bool IsTradeBookOpen = false;
        public static List<string> orderStatus;
        public static List<string> orderTypes;
        public static List<string> side;
        public static Dictionary<string, sbyte> DDProductTypes;
        public static Dictionary<sbyte, string> DDReverseProductType;
        //private static string ProductName = "BT TRADER";
        //public static string CompanyName = "BHAGWATI TRADERS";
        // public static string CompanyName = "BANKE BIHARI TRADING SOLUTIONS";        
        public static System.Drawing.Image SplashImage;
        public static System.Drawing.Image AboutImage;
        public static System.Drawing.Icon Icon;
        public static string ContactAddress = "";
        public static string ProductName = "Trading Work Station";
        public static string Copyright = "";
        
        static ClsGlobal()
        {
            LoadBrandInfo();
            DDProductTypes = new Dictionary<string, sbyte>();
            DDReverseProductType = new Dictionary<sbyte, string>();
            SubscibedSymbolList = new Dictionary<string, Symbol>();
            DDRightZLevelQty = new Dictionary<string, double>();
            DDLeftZLevelQty = new Dictionary<string, double>();
            DDLeftZLevel = new Dictionary<string, double>();
            DDRightZLevel = new Dictionary<string, double>();
            DDLTP = new Dictionary<string, double>();
            DDOpen = new Dictionary<string, double>();
            DDHigh = new Dictionary<string, double>();
            DDLow = new Dictionary<string, double>();
            DDClose = new Dictionary<string, double>();
            DDVolume = new Dictionary<string, int>();
            DDContractSize = new Dictionary<string, int>();
            DDContractDigit = new Dictionary<string, int>();
            FieldInfo[] fieldInfos = typeof(clsHashDefine).GetFields();
            DDConversion = new Dictionary<string, double>();
            FutureSymbolList = new List<string>();
            if (!DDConversion.Keys.Contains("AUDCAD"))
                DDConversion.Add("AUDCAD", 1.01366);
            if (!DDConversion.Keys.Contains("AUDCHF"))
                DDConversion.Add("AUDCHF", 1.07849);
            if (!DDConversion.Keys.Contains("AUDJPY"))
                DDConversion.Add("AUDJPY", 0.01137);
            if (!DDConversion.Keys.Contains("AUDNZD"))
                DDConversion.Add("AUDNZD", 0.82287);
            if (!DDConversion.Keys.Contains("AUDUSD"))
                DDConversion.Add("AUDUSD", 1);
            if (!DDConversion.Keys.Contains("CADCHF"))
                DDConversion.Add("CADCHF", 1.07849);
            if (!DDConversion.Keys.Contains("CADJPY"))
                DDConversion.Add("CADJPY", 0.0113726);
            if (!DDConversion.Keys.Contains("CHFJPY"))
                DDConversion.Add("CHFJPY", 0.0113726);
            if (!DDConversion.Keys.Contains("EURAUD"))
                DDConversion.Add("EURAUD", 1.04172);
            if (!DDConversion.Keys.Contains("EURCAD"))
                DDConversion.Add("EURCAD", 1.01366);
            if (!DDConversion.Keys.Contains("EURCHF"))
                DDConversion.Add("EURCHF", 1.07849);
            if (!DDConversion.Keys.Contains("EURGBP"))
                DDConversion.Add("EURGBP", 1.60189);
            if (!DDConversion.Keys.Contains("EURJPY"))
                DDConversion.Add("EURJPY", 0.01137);
            if (!DDConversion.Keys.Contains("EURNZD"))
                DDConversion.Add("EURNZD", 0.82338);
            if (!DDConversion.Keys.Contains("EURUSD"))
                DDConversion.Add("EURUSD", 1);
            if (!DDConversion.Keys.Contains("GBPAUD"))
                DDConversion.Add("GBPAUD", 1.04185);
            if (!DDConversion.Keys.Contains("GBPCAD"))
                DDConversion.Add("GBPCAD", 1.01366);
            if (!DDConversion.Keys.Contains("GBPCHF"))
                DDConversion.Add("GBPCHF", 1.07849);
            if (!DDConversion.Keys.Contains("GBPJPY"))
                DDConversion.Add("GBPJPY", 0.01137);
            if (!DDConversion.Keys.Contains("GBPUSD"))
                DDConversion.Add("GBPUSD", 1);
            if (!DDConversion.Keys.Contains("NZDJPY"))
                DDConversion.Add("NZDJPY", 0.01137);
            if (!DDConversion.Keys.Contains("NZDUSD"))
                DDConversion.Add("NZDUSD", 1);
            if (!DDConversion.Keys.Contains("USDCAD"))
                DDConversion.Add("USDCAD", 1.01366);
            if (!DDConversion.Keys.Contains("USDCHF"))
                DDConversion.Add("USDCHF", 1.07849);
            if (!DDConversion.Keys.Contains("USDJPY"))
                DDConversion.Add("USDJPY", 0.01137);
            DDOrderStatus = new Dictionary<string, sbyte>();
            DDOrderTypes = new Dictionary<string, sbyte>();
            DDSide = new Dictionary<string, sbyte>();
            DDValidity = new Dictionary<string, sbyte>();
            DDReverseOrderStatus = new Dictionary<sbyte, string>();
            DDReverseOrderType = new Dictionary<sbyte, string>();
            DDReverseSide = new Dictionary<sbyte, string>();
            DDReverseValidity = new Dictionary<sbyte, string>();
            for (int i = 0; i < fieldInfos.Count(); i++)
            {
                if (fieldInfos[i].Name.Contains("ORDER_TYPE_"))
                {
                    //if (!fieldInfos[i].Name.Contains("STOP"))
                    {
                        string x = fieldInfos[i].Name.Replace("ORDER_TYPE_", "").Replace("_ORDER", "");
                        DDOrderTypes.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                    }
                    //DDOrderTypes.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
                else if (fieldInfos[i].Name.Contains("SIDE_BUY") || fieldInfos[i].Name.Contains("SIDE_SELL"))
                {
                    string x = fieldInfos[i].Name.Replace("SIDE_", "");
                    DDSide.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
                else if (fieldInfos[i].Name.Contains("TIF_DAY"))
                {
                    string x = fieldInfos[i].Name.Replace("TIF_", "");
                    DDValidity.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
                else if (fieldInfos[i].Name.Contains("TIF_GTC"))
                {
                    string x = fieldInfos[i].Name.Replace("TIF_", "");
                    DDValidity.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
                else if (fieldInfos[i].Name.Contains("ORDER_STATUS_"))
                {
                    string x = fieldInfos[i].Name.Replace("ORDER_STATUS_", "");
                    if (x.ToLower() == "new")
                        x = "WORKING";
                    DDOrderStatus.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
                else if (fieldInfos[i].Name.Contains("SECURITY_TYPE_"))
                {
                    string x = fieldInfos[i].Name.Replace("SECURITY_TYPE_", "");
                    DDProductTypes.Add(x, (sbyte)Convert.ToByte(fieldInfos[i].GetValue(fieldInfos[i])));
                }
            }
            foreach (string s in DDOrderStatus.Keys.ToArray())
            {
                if (!DDReverseOrderStatus.ContainsKey(DDOrderStatus[s]))
                    DDReverseOrderStatus.Add(DDOrderStatus[s], s);
            }
            foreach (string s in DDOrderTypes.Keys.ToArray())
            {
                DDReverseOrderType.Add(DDOrderTypes[s], s);
            }
            foreach (string s in DDSide.Keys.ToArray())
            {
                DDReverseSide.Add(DDSide[s], s);
            }
            foreach (string s in DDProductTypes.Keys.ToArray())
            {
                DDReverseProductType.Add(DDProductTypes[s], s);
            }
            foreach (string s in DDValidity.Keys.ToArray())
            {
                DDReverseValidity.Add(DDValidity[s], s);
            }

            orderStatus = new List<string>();
            orderTypes = new List<string>();
            side = new List<string>();

            orderTypes.Clear();
            orderStatus.Clear();
            side.Clear();
            orderTypes.Add("All");
            orderStatus.Add("All");
            side.Add("All");

            foreach (string x in ClsGlobal.DDOrderTypes.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                orderTypes.Add(c);
            }
            foreach (string x in ClsGlobal.DDOrderStatus.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                orderStatus.Add(c);
            }
            foreach (string x in ClsGlobal.DDSide.Keys.ToArray())
            {
                string c = x.Replace('_', ' ').ToLower();
                c = ClsTWSUtility.UppercaseWords(c);
                side.Add(c);
            }
            orderStatus.Add("Non Settled");
        }
        public static double GetZeroLevelBidPrice(string symbol)
        {
            if (DDLeftZLevel.Keys.Contains(symbol))
                return DDLeftZLevel[symbol];
            else
                return 0;
        }
        public static double GetZeroLevelLTP(string symbol)
        {
            if (DDLTP.Keys.Contains(symbol))
                return DDLTP[symbol];
            else
                return 0;
        }
        public static double GetZeroLevelAskPrice(string symbol)
        {
            if (DDRightZLevel.Keys.Contains(symbol))
                return DDRightZLevel[symbol];
            else
                return 0;
        }
        public static int GetClientOrderID()
        {
            //Monitor.Enter(_clientOrderId);
            //try
            //{
            return ++_clientOrderId;
            //}
            //finally
            //{
            //    Monitor.Exit(_clientOrderId);
            //}

        }

        public static void SetColumnSortMode(this NDataGridView dataGridView, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = sortMode;
            }
        }
        public static System.Drawing.Icon GetIcon()
        {
            System.Drawing.Icon _icon;
            switch (ProductName)
            {
                case "BB TRADER":
                    _icon = Properties.Resources.favicon;
                    break;
                default:
                    _icon = Properties.Resources.Default;
                    break;
            }
            ;
            return _icon;
        }

        private static void LoadBrandInfo()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\BrandInfo\\Splsh.png"))
                {
                    SplashImage = System.Drawing.Image.FromFile(Application.StartupPath + "\\BrandInfo\\Splsh.png");
                }
                else
                {
                    SplashImage = Properties.Resources.DefaultSplsh;
                }

            }
            catch (Exception)
            {
                SplashImage = Properties.Resources.DefaultSplsh;
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\BrandInfo\\About.png"))
                {
                    AboutImage = System.Drawing.Image.FromFile(Application.StartupPath + "\\BrandInfo\\About.png");
                }
                else
                {
                    AboutImage = Properties.Resources.AboutLogo;
                }

            }
            catch (Exception)
            {
                AboutImage = Properties.Resources.AboutLogo;
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\BrandInfo\\favicon.ico"))
                {
                    Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath + "\\BrandInfo\\favicon.ico");
                }
                else
                {
                    Icon = Properties.Resources.Default;
                }

            }
            catch (Exception)
            {
                Icon = Properties.Resources.Default;
            }
            try
            {
                if (File.Exists(Application.StartupPath + "\\BrandInfo\\BrandInfo.txt"))
                {
                    int totalLines = File.ReadLines(Application.StartupPath + "\\BrandInfo\\BrandInfo.txt").Count();
                    string[] lines = File.ReadAllLines(Application.StartupPath + "\\BrandInfo\\BrandInfo.txt", Encoding.GetEncoding("iso-8859-1"));

                    if (totalLines >= 3)
                    {
                        if (lines[0].Trim() != "" && lines[0].Contains('~'))
                        {
                            string[] temp = lines[0].Split('~');
                            if (temp[0].Trim().ToUpper() == "PRODUCT_NAME" && temp[1].Trim() != "")
                            {
                                ProductName = temp[1].Trim();
                            }
                        }
                        if (lines[1].Trim() != "" && lines[1].Contains('~'))
                        {
                            string[] temp = lines[1].Split('~');
                            if (temp[0].Trim().ToUpper() == "ADDRESS" && temp[1].Trim() != "")
                            {
                                if (temp[1].Contains(';'))
                                {
                                    string[] add = temp[1].Split(';');
                                    for (int i = 0; i < add.Length; i++)
                                    {
                                        ContactAddress = ContactAddress + add[i].Trim() + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    ContactAddress = temp[1].Trim();
                                }
                            }
                        }
                        if (lines[2].Trim() != "" && lines[2].Contains('~'))
                        {
                            string[] temp = lines[2].Split('~');
                            if (temp[0].Trim().ToUpper() == "COPYRIGHT" && temp[1].Trim() != "")
                            {
                                Copyright = temp[1].Trim();
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        public static string GetTWSProductName()
        {
            //string _ProductName;
            //switch (BrokerGroupId)
            //{
            //    case 2:
            //        _ProductName = " BB Trader : ";
            //        break;
            //    case 60:
            //        _ProductName = "  GCDS-TRADER : ";
            //        break;
            //    case 74:
            //        _ProductName = "  MIPL-TRADER : ";
            //        break;
            //    case 90:
            //        _ProductName = "  LAXMI GOLD TRADER : ";
            //        break;
            //    case 77:
            //        _ProductName = "  FEWA TRADER : ";
            //        break;
            //    case 107:
            //        _ProductName = " UMX-TRADER : ";
            //        break;
            //    default:
            //        _ProductName = "  LTECH TRADER : ";
            //        break;
            //}
            //;
            //return _ProductName;
            return ProductName;
        }
        //public static DateTime GetDateTimeDT(string datetime)
        //{
        //    //yyyy-mm-DD-hh-mm-ss
        //    DateTime dtx = DateTime.MinValue;
        //    if (datetime != string.Empty)
        //    {
        //        string[] x = datetime.Split('-');
        //        string dat = x[1].ToString() + "/" + x[2].ToString() + "/" + x[0].ToString() + " " + x[3].ToString() + ":" + x[4].ToString() + ":" + x[5].ToString();
        //        //DateTime dtx = DateTime.MinValue;
        //        DateTime.TryParse(dat, out dtx);
        //        //string date = string.Empty;
        //        //if (dtx != DateTime.MinValue)
        //        //{
        //        //    date = string.Format(
        //        //                Properties.Settings.Default.TimeFormat.Contains("24")
        //        //                    ? "{0:dd/MM/yyyy HH:mm:ss}"
        //        //                    : "{0:dd/MM/yyyy hh:mm:ss tt}", dtx);
        //        //}
        //        return dtx;
        //    }
        //    else
        //        return dtx;
        //}

        public static DateTime GetDateTimeDT(string datetime)
        {
            try
            {
                if (datetime != string.Empty)
                {
                    string[] x = datetime.Split('-');
                    string dat = x[1].ToString() + "/" + x[2].ToString() + "/" + x[0].ToString() + " " + x[3].ToString() + ":" + x[4].ToString() + ":" + x[5].ToString();
                    DateTime dtx = DateTime.MinValue;
                    if (CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern != "M/d/yyyy")
                    {
                        dtx = DateTime.Parse(dat, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        DateTime.TryParse(dat, out dtx);
                    }

                    return dtx;
                }
                else
                    return DateTime.MinValue;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static string GetDateTime(string datetime)
        {
            try
            {
                if (datetime != string.Empty)
                {
                    DateTime exp = DateTime.Now;
                    DateTime.TryParse(datetime, out exp);
                 return  exp.ToString("dd/MM/yyyy");
                }
                else
                    return DateTime.MinValue.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                return DateTime.MinValue.ToString("dd/MM/yyyy");
            }
        }

     

        public static void Log(string pText)
        {
            string workingDir = string.Empty;
            workingDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\TWS\\Logs" + "\\Log_" + DateTime.Now.ToString("dd_MM_yyyy");

            if (File.Exists(workingDir + "\\PriceLog.txt"))
            {
                TextWriter tsw = new StreamWriter(workingDir + "\\PriceLog.txt", true);
                tsw.WriteLine(DateTime.Now.ToString() + " : " + pText);
                tsw.Close();
            }
            else
            {
                System.IO.Directory.CreateDirectory(workingDir);
                FileStream fsDevelopmentLog = new FileStream(workingDir + "\\PriceLog.txt", FileMode.OpenOrCreate, FileAccess.Write,
                                                  FileShare.ReadWrite);
                fsDevelopmentLog.Close();
                try
                {
                    TextWriter tsw = new StreamWriter(workingDir + "\\PriceLog.txt", true);
                    tsw.WriteLine(DateTime.Now.ToString() + " : " + pText);
                    tsw.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        public static bool CheckNetConnectivity()
        {
            bool status = false;
            try
            {
                status = NetworkInterface.GetIsNetworkAvailable();
            }
            catch (Exception)
            {
                return status;
            }
            return status;
        }
    }
}