using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using FundXchange.Domain.Enumerations;
//using FundXchange.Model.ViewModels.Charts;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using PALSA.Cls;

namespace PALSA.Cls
{
    public static class Utils
    {
        public static void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSrcStr, int cchSrc, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDestStr, int cchDest);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int LCMapStringA(int Locale, int dwMapFlags, [MarshalAs(UnmanagedType.LPArray)] byte[] lpSrcStr, int cchSrc, [MarshalAs(UnmanagedType.LPArray)] byte[] lpDestStr, int cchDest);

        public static string GetCurrencySymbol()
        {
            return CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        }

        public static string GetValue(string value, string defValue)
        {
            return string.IsNullOrEmpty(value) ? defValue : value;
        }

        public static bool IsNumeric(object Expression)
        {
            IConvertible convertible = Expression as IConvertible;
            if (convertible != null)
            {
                switch (convertible.GetTypeCode())
                {
                    case TypeCode.Boolean:
                        return true;

                    case TypeCode.Char:
                    case TypeCode.String:
                        {
                            double num;
                            string str = convertible.ToString(null);
                            try
                            {
                                long num2 = 0;
                                if (IsHexOrOctValue(str, ref num2))
                                {
                                    return true;
                                }
                            }
                            catch (FormatException)
                            {
                                return false;
                            }
                            return double.TryParse(str, out num);
                        }
                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// The path of the folder where all scripts of symbols are saved.
        /// </summary>
        internal static string ScannerPath = Application.StartupPath + "\\Scanners";
        /// <summary>
        /// This method serializes the ScannerData class.
        /// </summary>
        /// <param name="sd">This is a parameter which is ScannerData class data type.</param>
        internal static void CreateScannerScript(Scanner sd)
        {
            DirectoryInfo dirInf = new DirectoryInfo(ScannerPath);
            if (!dirInf.Exists)
            {
                dirInf.Create();
            }
            StreamWriter w = new StreamWriter(ScannerPath + "\\" + sd.ScannerName + ".xml");
            XmlSerializer x = new XmlSerializer(sd.GetType());
            x.Serialize(w, sd);
            w.Close();

        }
        /// <summary>
        /// This method deserializes the saved script.
        /// </summary>
        /// <param name="path">The path where scripts are saved.</param>
        /// <returns>It returns ScannerData class</returns>
        internal static Scanner GetScannerScript(string path)
        {
            Scanner sd = null;
            string fullpath = ScannerPath + "\\" + path + ".xml";
            if (File.Exists(fullpath))
            {
                sd = new Scanner();
                StreamReader sr = new StreamReader(fullpath);
                XmlTextReader xr = new XmlTextReader(sr);
                XmlSerializer xs = new XmlSerializer(sd.GetType());
                object c;
                if (xs.CanDeserialize(xr))
                {
                    c = xs.Deserialize(xr);
                    Type t = sd.GetType();
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        p.SetValue(sd, p.GetValue(c, null), null);
                    }
                }
                xr.Close();
                sr.Close();

            }
            return sd;

        }
        internal static bool IsHexOrOctValue(string Value, ref long i64Value)
        {
            int num = 0;
            int length = Value.Length;
            while (num < length)
            {
                char ch = Value[num];
                if ((ch == '&') && ((num + 2) < length))
                {
                    ch = char.ToLower(Value[num + 1], CultureInfo.InvariantCulture);
                    string str = ToHalfwidthNumbers(Value.Substring(num + 2), GetCultureInfo());
                    switch (ch)
                    {
                        case 'h':
                            i64Value = Convert.ToInt64(str, 0x10);
                            return true;

                        case 'o':
                            i64Value = Convert.ToInt64(str, 8);
                            return true;
                    }
                    throw new FormatException();
                }
                if ((ch != ' ') && (ch != '　'))
                {
                    return false;
                }
                num++;
            }
            return false;
        }

        internal static string ToHalfwidthNumbers(string s, CultureInfo culture)
        {
            int num = culture.LCID & 0x3ff;
            if (((num != 4) && (num != 0x11)) && (num != 0x12))
            {
                return s;
            }
            return vbLCMapString(culture, 0x400000, s);
        }

        internal static string vbLCMapString(CultureInfo loc, int dwMapFlags, string sSrc)
        {
            int length = sSrc == null ? 0 : sSrc.Length;
            if (length == 0)
            {
                return "";
            }
            int lCID = loc.LCID;
            Encoding encoding = Encoding.GetEncoding(loc.TextInfo.ANSICodePage);
            if (!encoding.IsSingleByte)
            {
                string s = sSrc;
                if (s != null)
                {
                    byte[] bytes = encoding.GetBytes(s);
                    int num2 = LCMapStringA(lCID, dwMapFlags, bytes, bytes.Length, null, 0);
                    byte[] buffer = new byte[(num2 - 1) + 1];
                    LCMapStringA(lCID, dwMapFlags, bytes, bytes.Length, buffer, num2);
                    return encoding.GetString(buffer);
                }
            }
            string lpDestStr = new string(' ', length);
            LCMapString(lCID, dwMapFlags, ref sSrc, length, ref lpDestStr, length);
            return lpDestStr;
        }

        internal static CultureInfo GetCultureInfo()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        internal static int GetLocaleCodePage()
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage;
        }
        public static char Chr(int CharCode)
        {
            if ((CharCode < -32768) || (CharCode > 65535))
            {
                throw new ArgumentException("Argument out of range");
            }
            if ((CharCode >= 0) && (CharCode <= 127))
            {
                return Convert.ToChar(CharCode);
            }
            Encoding encoding = Encoding.GetEncoding(GetLocaleCodePage());
            if (encoding.IsSingleByte && ((CharCode < 0) || (CharCode > 255)))
            {
                throw new ArgumentException("Argument out of range");
            }
            char[] chars = new char[2];
            byte[] bytes = new byte[2];
            Decoder decoder = encoding.GetDecoder();
            if ((CharCode >= 0) && (CharCode <= 255))
            {
                bytes[0] = (byte)(CharCode & 255);
                decoder.GetChars(bytes, 0, 1, chars, 0);
            }
            else
            {
                bytes[0] = (byte)((CharCode & 65280) >> 8);
                bytes[1] = (byte)(CharCode & 255);
                decoder.GetChars(bytes, 0, 2, chars, 0);
            }
            return chars[0];
        }

        public static TReturnEnum ConvertEnum<TEnum, TReturnEnum>(TEnum input)
        {
            try
            {
                //if (Enum.IsDefined(typeof(TReturnEnum), input))
                //{
                //    return (TReturnEnum)Enum.ToObject(typeof(TReturnEnum), input);
                //}
                if (Enum.IsDefined(typeof(TReturnEnum), input.ToString()))
                {
                    return (TReturnEnum)Enum.Parse(typeof(TReturnEnum), input.ToString());
                }
            }
            catch(ArgumentException) {}
            return default(TReturnEnum);
        }

        internal static PeriodEnum GetPeriodFromPeriodicity(Periodicity periodicity)
        {
            switch (periodicity)
            {
                case Periodicity.Minutely:
                    return PeriodEnum.Minute;
                case Periodicity.Hourly:
                    return PeriodEnum.Hour;
                case Periodicity.Daily:
                    return PeriodEnum.Day;
                case Periodicity.Weekly:
                    return PeriodEnum.Week;
                case Periodicity.Monthly:
                    return PeriodEnum.Month;
                default:
                    return PeriodEnum.Minute;
            }

        }
    }
    public class SymbolAttributes
    {
        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        private string _InstrumentType;
        public string InstrumentType
        {
            get { return _InstrumentType; }
            set { _InstrumentType = value; }
        }
        private string _companyLongName;
        public string CompanyLongName
        {
            get { return _companyLongName; }
            set { _companyLongName = value; }
        }
        private string _ISIN;
        public string ISIN
        {
            get { return _ISIN; }
            set { _ISIN = value; }
        }
        public SymbolAttributes()
        {
            _symbol = string.Empty;
            _InstrumentType = string.Empty;
            _companyLongName = string.Empty;
            _ISIN = string.Empty;
        }
        public SymbolAttributes(string symbol, string InstrumentType, string companyLongName, string ISIN)
        {
            _symbol = symbol;
            _InstrumentType = InstrumentType;
            _companyLongName = companyLongName;
            _ISIN = ISIN;
        }
    }
    public class ScriptDeatil
    {
        public string SoundPath;
        public string ScriptType;
        public int Interval;
        public int Bars;
        public Periodicity Periodicity;
        public string Script;
        public string ScriptName;
        public ScriptDeatil()
        {
            SoundPath = string.Empty;
            ScriptType = string.Empty;
            Script = string.Empty;
            ScriptName = string.Empty;
            Interval = 1;
            Bars = 3;
            Periodicity = Periodicity.Minutely;
        }
        public ScriptDeatil(string script, string scriptName,  string scriptType,string soundPath, int interval, int bars, Periodicity periodicity)
        {
            Script = script;
            ScriptName = scriptName;
            SoundPath = soundPath;
            ScriptType = scriptType;
            Interval = interval;
            Bars = bars;
            Periodicity = periodicity;
        }
    }
    /// <summary>
    /// This class wraps all attributs of a scanner
    /// </summary>
    public class Scanner : XmlSerializer
    {
        private string _scannerName;
        public string ScannerName
        {
            get { return _scannerName; }
            set { _scannerName = value; }
        }
        private string _notes;
        public string Note
        {
            get { return _notes; }
            set { _notes = value; }
        }
        private string _filterSoundPath;
        public string FilterSoundPath
        {
            get { return _filterSoundPath; }
            set { _filterSoundPath = value; }
        }
        private List<SymbolAttributes> _symbols;
        public List<SymbolAttributes> Symbols
        {
            get { return _symbols; }
            set { _symbols = value; }
        }
        private List<ScriptDeatil> _scripts;
        public List<ScriptDeatil> Scripts
        {
            get { return _scripts; }
            set { _scripts = value; }
        }

        public Scanner()
        {
            _scannerName = string.Empty;
            _notes = string.Empty;
            _filterSoundPath = string.Empty;
            _symbols = new List<SymbolAttributes>();
            _scripts= new List<ScriptDeatil>();
        }
        public Scanner(string scannerName, string notes,string filterSoundPath,List<SymbolAttributes> symbols, List<ScriptDeatil> scripts)
        {
            _scannerName = scannerName;
            _notes = notes;
            _filterSoundPath = filterSoundPath;
            _symbols = symbols;
            _scripts=scripts;
        }
    }
}
