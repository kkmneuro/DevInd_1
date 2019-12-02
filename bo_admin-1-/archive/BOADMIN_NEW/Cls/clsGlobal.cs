using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOADMIN_NEW.Cls;
using System.Windows.Forms;
using clsInterface4OME;

using System.Text.RegularExpressions;
using Nevron.UI.WinForm.Controls;
using System.Net;
using System.Collections;

namespace BOADMIN_NEW.Cls
{
    public static class clsGlobal
    {
        public const int SuccessID = -50052;
        public const int FailureID = -50060;
        public static string userIDPwd = string.Empty;
        public static int BrokerID = 0;
        public static string Role = string.Empty;
        public static string BrokerName = string.Empty;
        public static int BrokerNameId = 0;
        public static string CLietnID = string.Empty;
        public static bool IsCSLoaded = false;
        public static string BrokerCompany = string.Empty;
        public static string OrderServerURL = "ws://217.160.11.198:9022/test";
        public static string OrderServerUser = "system";
        public static string OrderServerPassword = "system";

        public static int countOccurrences(String MyString, char needle, int i)
        {
            return ((i = MyString.IndexOf(needle, i)) == -1) ? 0 : 1 + countOccurrences(MyString, needle, i + 1);
        }

        public static void KeyPressHandler(string text, KeyPressEventArgs e, BOADMIN_NEW.Cls.clsEnums.TextType textType, int size, int decimalPlaces)
        {
            switch (textType)
            {
                case BOADMIN_NEW.Cls.clsEnums.TextType.Numeric:
                    {
                        if (text.Length < size && size == 0) //size=0 for max int length
                        {
                            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                            {
                                e.Handled = true;

                            }
                            else
                            {
                                e.Handled = false;
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                        if (size == 0)
                        {
                            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                            {
                                e.Handled = true;

                            }
                            else
                            {
                                e.Handled = false;
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.Real:
                    {
                        if (text.Length < size)
                        {
                            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                            {
                                e.Handled = true;
                            }
                            if (text.Contains('.') && e.KeyChar != '\b')
                            {
                                if (e.KeyChar == '.')
                                {
                                    e.Handled = true;
                                }
                                else
                                {
                                    string[] RealNumber = text.Split('.');
                                    if (RealNumber[0].Length < (size - (decimalPlaces + 1)))
                                    {
                                        if (RealNumber[1].Length <= decimalPlaces)
                                            e.Handled = false;
                                        else
                                            e.Handled = true;
                                    }
                                    else
                                    {
                                        if (RealNumber[1].Length < decimalPlaces)
                                            e.Handled = false;
                                        else
                                            e.Handled = true;
                                    }

                                }
                            }
                            else if (text.Length == (size - decimalPlaces) && e.KeyChar != '\b')
                            {
                                if (!text.Contains('.') && e.KeyChar == '.')
                                {
                                    e.Handled = false;
                                }
                                else
                                    e.Handled = true;
                            }

                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }

                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.MailAdd:
                    {
                        
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.Phone:
                    {
                        if (text.Length < size)
                        {
                            if (Char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                            {
                                e.Handled = false;
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.Alphabet:
                    {
                        if (text.Length < size)
                        {
                            if (Char.IsLetter(e.KeyChar) && e.KeyChar == '\b')
                            {
                                e.Handled = false;
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.AlphaNumeric:
                    {
                        if (text.Length < size)
                        {
                            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && !Char.IsPunctuation(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = false;
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.All:
                    {
                        if (text.Length > size)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                    break;
                case BOADMIN_NEW.Cls.clsEnums.TextType.IP:
                    {
                        if (text.Length < size)
                        {
                            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                if (text.Contains('.'))
                                {
                                    int occurance = countOccurrences(text, '.', 0);
                                    if (occurance == 3 && e.KeyChar == '.')
                                        e.Handled = true;
                                    
                                   else if (occurance > 0 && occurance < 4)
                                    {
                                        string[] IP = text.Split('.');
                                        foreach (string item in IP)
                                        {
                                            if (item.Length == 3 && e.KeyChar != '.')
                                            {
                                                e.Handled = true;
                                                return;
                                            }
                                            else
                                                e.Handled = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (text.Length > 2 && e.KeyChar != '.')
                                        e.Handled = true;
                                    else
                                        e.Handled = false;
                                }
                               
                            }
                        }
                        else
                        {
                            if (e.KeyChar != '\b')
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }

                    }
                    break;
                default:
                    break;
            }
        }

        public static bool IsNotNull(string ctrlText)
        {
            bool flag=true;
            if (ctrlText ==string.Empty)
            {
                flag = false;
            }
            return flag;
        }

        public static bool ValidateEmail(string ctrlText)
        {
            bool flag=true;

            Match objMatch = Regex.Match(ctrlText, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",RegexOptions.IgnoreCase);
            if(!objMatch.Success)
            {
                 flag = false;
            }
            return flag;
        }

        public static void HandleZero(object sender, EventArgs e,int NoOfZero)
        {
            if (((NTextBox)sender).Text != string.Empty)
            {
                int value = Convert.ToInt32(((NTextBox)sender).Text);
                int NewValue = value.ToString("D").Length + NoOfZero;
                ((NTextBox)sender).Text = value.ToString("D" + NewValue.ToString());
            }
        }

        public static bool CheckTextAsCharacter(string text)
        {
            bool flag = true;

            Match objMatch = Regex.Match(text, @"/^[a-zA-Z\s]+$/");
            if (!objMatch.Success)
            {
                flag = false;
            }
            return flag;
        }

        public static bool CheckTextAsNumber(string text)
        {
            bool flag = true;

            Match objMatch = Regex.Match(text,@"^[0-9]*$");

            if (!objMatch.Success)
            {
                flag = false;
            }
            return flag;
        }
        public static bool ValidateIP(string IP)
        {
            try
            {
                string[] strarr = new string[4];
                int[] intarr = new int[4];

                if (countOccurrences(IP, '.', 0) != 3)
                    return false;


                strarr = IP.Split('.');
                for (int i = 0; i < 4; i++)
                {
                    intarr[i] = Convert.ToInt32(strarr[i]);
                }
                if (intarr[0] == 255 && intarr[1] == 255 && intarr[2] == 255 && intarr[3] == 255)
                    return false;
                if (intarr[0] <= 255 && intarr[0] > 0)
                {
                    if (intarr[1] <= 255 && intarr[0] >= 0)
                    {
                        if (intarr[2] <= 255 && intarr[0] >= 0)
                        {
                            if (intarr[3] <= 255 && intarr[0] >= 0)
                            {
                                return true;
                            }
                        }

                    }
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public static string GetIPAddress()
        {
            string LoaclIP = string.Empty;
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
            // Get the IP
            LoaclIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return LoaclIP;
        }
    }

}
