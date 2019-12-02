﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
//using System.Windows.Forms;

    public static class clsUtility
    {
        const int SWP_NOSIZE = 0x0001;
        public static Version AurumCUI = new Version("1.1.1.30");
        public static Version AurumAUI = new Version("8.1.1.23");


        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        public static void SetWindowPosition(int xpos, int ypos)
        {
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
        }

        public static void WriteLineColor4Client(DateTime time)
        {
            //return;
            WriteLineColor("From Client", time.ToLongTimeString(), ConsoleColor.Yellow);
        }
        public static void WriteLineColor4Server(DateTime time)
        {
            //return;
            WriteLineColor("From Server", time.ToLongTimeString(), ConsoleColor.Red);
        }
        public static void WriteLineColor4Client(string txt)
        {
            //return;
            WriteLineColor("From Client ", txt, ConsoleColor.Yellow);
        }
        public static void WriteLineColor4Server(string txt)
        {
            //return;
            WriteLineColor("From Server ", txt, ConsoleColor.Green);
        }
        //public static OleDbConnection getConnection(string DBIPAddress,string DBName,string UID,string Password)
        //{
        //    string con="Provider=sqloledb;Data Source="
        //        +";Initial Catalog="
        //        +";Integrated Security=SSPI;";
        //    return new OleDbConnection(con);
        //}
        //public static void DisableSortingOnDGV(DataGridView dgv)
        //{
        //    foreach (DataGridViewColumn item in dgv.Columns)
        //    {
        //        item.SortMode = DataGridViewColumnSortMode.NotSortable;
        //    }
        //}
        public static OleDbConnection getConnection(IPAddress DBIPAddress, string DBName, string userId, string password)
        {
            //#if DebugAurum
            //            string con11 = ("Provider=SQLOLEDB;Data Source=" + DBIPAddress + ";Initial Catalog=" + DBName + ";User ID =sa; Password=admin123@;");

            //            //string con = "Provider=sqloledb;Data Source="
            //            //    + DBIPAddress
            //            //    + ";Initial Catalog="
            //            //    + DBName
            //            //    + ";User id=sa;Password=admin123@";
            //#endif
            //"Provider=SQLOLEDB;Data Source=192.168.1.26;Initial Catalog=PruneGold;User ID =sa; Password=admin123@;"
            //#if ReleaseAurum
            string con11 = ("Provider=SQLOLEDB;Data Source=" + DBIPAddress + ";Initial Catalog=" + DBName + ";User ID =" + userId + "; Password=" + password + ";");

            //string con11= "Provider=sqloledb;Data Source="
            //    + DBIPAddress
            //    + ";Initial Catalog="
            //    + DBName
            //    + ";Integrated Security=SSPI;";
            //#endif

            return new OleDbConnection(con11);
        }

        public static void WriteLineColor(string text, string text2Color, ConsoleColor colr)
        {
            // return;
            //Console.Write(text);
            Console.ForegroundColor = colr;
            Console.WriteLine(text+ text2Color);
            Console.ResetColor();
        }
        public static void WriteSQLExc(string text)
        {
            WriteLineColor(text, ConsoleColor.Green);
        }
        public static void WriteLineColor(string text, ConsoleColor colr)
        {
            //return;
            Console.ForegroundColor = colr;
            Console.WriteLine(text);
            //FileHandling.WriteToLog(text);
            Console.ResetColor();
        }
        public static long GetLong(object Val)
        {
            if (Val == null)
                return 0;
            lock (Val)
            {
                if (Val != null)
                {
                    long lng;
                    long.TryParse(Math.Round(GetDecimal(Val), 0).ToString(), out lng);
                    return lng;
                }
                return 0;
            }
        }
        public static string Capitalize(object value)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToString().ToLower());
        }

        public static string Capitalize(this string value)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }
        public static long GetAccountID(string AccountIDWithGroup)
        {
            long AccountId = 0;
            if (AccountIDWithGroup.Length > 2)
            {
                AccountId = clsUtility.GetLong(AccountIDWithGroup.Substring(2, AccountIDWithGroup.Length - 2));
            }
            return AccountId;
        }

        public static uint Minus(int valLeft, int ValRight)
        {
            if (valLeft > ValRight)
            {
                return (uint)(valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }
        public static uint Minus(uint valLeft, int ValRight)
        {
            if (valLeft > ValRight)
            {
                return (uint)(valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }
        public static uint Minus(int valLeft, uint ValRight)
        {
            if (valLeft > ValRight)
            {
                return (uint)(valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }
        public static uint Minus(uint valLeft, uint ValRight)
        {
            if (valLeft > ValRight)
            {
                return (uint)(valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }

      
        public static decimal GetDecimal(object Val)
        {
            if (Val == null)
                return 0;
            lock (Val)
            {
                if (Val != null && Val != DBNull.Value)
                {
                    decimal lng;
                    decimal.TryParse(Val.ToString(), out lng);
                    return lng;
                    //int.TryParse(Val.ToString(), out lng);
                    //return  Convert.ToInt32(Val);
                    //return lng;
                }
                return 0;
            }
        }
        public static decimal Minus(decimal valLeft, decimal ValRight)
        {
            if (valLeft > ValRight)
            {
                return (valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }
        public static double Minus(double valLeft, double ValRight)
        {
            if (valLeft > ValRight)
            {
                return (valLeft - ValRight);
            }
            else
            {
                return 0;
            }
        }
        public static string GetStr(object Val)
        {
            if (Val == null)
                return string.Empty;

            lock (Val)
            {
                if (Val != null && Val != DBNull.Value)
                {
                    return Val.ToString();
                }
                return string.Empty;
            }
        }
        public static int GetInt(object Val)
        {
            if (Val == null)
                return 0;

            lock (Val)
            {
                if (Val != null && Val != DBNull.Value)
                {
                    decimal lng;
                    decimal.TryParse(Val.ToString(), out lng);
                    return decimal.ToInt32(lng);
                    //int.TryParse(Val.ToString(), out lng);
                    //return  Convert.ToInt32(Val);
                    //return lng;
                }
                return 0;
            }
        }
        public static uint GetUInt(object Val)
        {
            if (Val == null)
                return 0;

            lock (Val)
            {
                if (Val != null && Val != DBNull.Value)
                {
                    decimal lng;
                    decimal.TryParse(Val.ToString(), out lng);
                    if (lng > 0)
                    {
                        return decimal.ToUInt32(lng);
                    }
                    else
                    {
                        return 0;
                    }
                    //int.TryParse(Val.ToString(), out lng);
                    //return  Convert.ToInt32(Val);
                    //return lng;
                }
                return 0;
            }
        }
        public static double GetDouble(object Val)
        {
            if (Val == null || Val==DBNull.Value)
                return 0;

            lock (Val)
            {
                if (Val != null)
                {
                    double lng;
                    double.TryParse(Val.ToString(), out lng);
                    return lng;
                }
                return 0;
            }
        }

        public static object GetDateYaNull(object Val)
        {
            if (Val == null)
                return 0;

            lock (Val)
            {
                if (Val != null && Val != DBNull.Value)
                {
                    DateTime lng;
                    DateTime.TryParse(Val.ToString(), out lng);
                    return lng;
                }
                return null;
            }
        }

        public static DateTime GetDate4ProtoStru(string Val)
        {
            if (Val != string.Empty)
                return new DateTime(Convert.ToInt64(Val));
            else
                return DateTime.MinValue;
        }
        public static DateTime GetDate(object Val)
        {
            lock (Val)
            {
                if (Val != null)
                {
                    DateTime lng;
                    DateTime.TryParse(Val.ToString(), out lng);
                    return lng;
                }
                return DateTime.MinValue;
            }
        }
        public static string GetDTSchema(DataTable dtTable)
        {
            if (dtTable == null)
            {
                return string.Empty;
            }
            else
            {
                StringWriter sw = new StringWriter();
                dtTable.WriteXmlSchema(sw);
                return sw.ToString();
            }
        }

        public static string GetDTData(DataTable dtTable)
        {
            if (dtTable == null)
            {
                return string.Empty;
            }
            else
            {
                StringWriter sw = new StringWriter();
                dtTable.WriteXml(sw);
                return sw.ToString();
            }
        }
        //public static string DataTable(DataTable dtTable)
        //{
        //    if (dtTable == null)
        //    {
        //        return string.Empty;
        //    }
        //    else
        //    {
        //        StringWriter sw = new StringWriter();
        //        dtTable.WriteXml(sw);
        //        return sw.ToString();
        //    }
        //}
        public static DataTable GetDataTable(string strSchema, string strData)
        {
            if (string.IsNullOrEmpty(strSchema) || string.IsNullOrEmpty(strData))
                return new DataTable();

            StringReader sr = new StringReader(strSchema.ToString());
            DataTable dt = new DataTable();
            dt.ReadXmlSchema(sr);
            sr = new StringReader(strData);
            dt.ReadXml(sr);
            return dt;
        }

        //public static DataTable GetDataTable(string stTable)
        //{
        //    if (string.IsNullOrEmpty(stTable))
        //        return new DataTable();

        //    StringReader sr = new StringReader(stTable.ToString());
        //    DataTable dt = new DataTable();
        //    dt.ReadXml(sr);
        //    return dt;
        //}

        public static string Object2String(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                string s = Convert.ToBase64String(ms.GetBuffer());
                return s;
            }

        }

        public static object String2Object(string strObj)
        {
            BinaryFormatter bf = new BinaryFormatter();

            byte[] buffer = Convert.FromBase64String(strObj);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                return bf.Deserialize(ms);
            }
        }
        //public static string SerializeToXml<T>(T obj)
        //{
        //    using (StringWriter wr = new StringWriter())
        //    {
        //        var ser = new XmlSerializer(typeof(T));
        //        ser.Serialize(wr, obj);
        //        // T o = DeserializeFromXml<T>(wr.ToString());

        //        return wr.ToString();
        //    }
        //}

        //public static T DeserializeFromXml<T>(string xml)
        //{
        //    T result;
        //    var ser = new XmlSerializer(typeof(T));
        //    using (var tr = new StringReader(xml))
        //    {
        //        result = (T)ser.Deserialize(tr);
        //    }
        //    return result;
        //}
}