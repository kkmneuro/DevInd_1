using System;
using System.Linq;
using System.Windows.Forms;

namespace CommonLibrary.Cls
{
    public enum TextType
    {
        Numeric,
        Real,
        MailAdd,
        Phone,
        Alphabet,
        AlphaNumeric,
        All,
        IP
    };

    public static class ClsGlobal
    {
        #region OrderMode enum

        public enum OrderMode
        {
            NEW,
            CANCEL,
            MODIFY
        };

        #endregion

        public static int BrokerID;
        public static string Role = string.Empty;

        public static int CountOccurrences(String myString, char needle, int i)
        {
            return ((i = myString.IndexOf(needle, i)) == -1) ? 0 : 1 + CountOccurrences(myString, needle, i + 1);
        }

        public static void KeyPressHandler(string text, KeyPressEventArgs e, TextType textType, int size,
                                           int decimalPlaces)
        {
            switch (textType)
            {
                case TextType.Numeric:
                    {
                        e.Handled = text.Length < size && size == 0
                                        ? !Char.IsNumber(e.KeyChar) && e.KeyChar != '\b'
                                        : e.KeyChar != '\b';
                        e.Handled = size == 0 ? !Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' : e.KeyChar != '\b';
                    }
                    break;
                case TextType.Real:
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
                                    string[] realNumber = text.Split('.');
                                    e.Handled = realNumber[0].Length < (size - (decimalPlaces + 1))
                                                    ? realNumber[1].Length > decimalPlaces
                                                    : realNumber[1].Length >= decimalPlaces;
                                }
                            }
                            else if (text.Length == (size - decimalPlaces) && e.KeyChar != '\b')
                            {
                                e.Handled = text.Contains('.') || e.KeyChar != '.';
                            }
                        }
                        else
                        {
                            e.Handled = e.KeyChar != '\b';
                        }
                    }
                    break;
                case TextType.Phone:
                    {
                        e.Handled = text.Length < size
                                        ? !Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'
                                        : e.KeyChar != '\b';
                    }
                    break;
                case TextType.Alphabet:
                    {
                        e.Handled = text.Length < size
                                        ? !Char.IsLetter(e.KeyChar) || e.KeyChar != '\b'
                                        : e.KeyChar != '\b';
                    }
                    break;
                case TextType.AlphaNumeric:
                    {
                        e.Handled = text.Length < size
                                        ? !Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' &&
                                          !Char.IsPunctuation(e.KeyChar)
                                        : e.KeyChar != '\b';
                    }
                    break;
                case TextType.All:
                    {
                        e.Handled = text.Length > size;
                    }
                    break;
                case TextType.IP:
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
                                    int occurance = CountOccurrences(text, '.', 0);
                                    if (occurance == 3 && e.KeyChar == '.')
                                        e.Handled = true;
                                    else if (occurance > 0 && occurance < 4)
                                    {
                                        string[] IP = text.Split('.');
                                        foreach (string item in IP)
                                        {
                                            e.Handled = item.Length > 2 && e.KeyChar != '.';
                                        }
                                    }
                                }
                                else
                                {
                                    e.Handled = text.Length > 2 && e.KeyChar != '.';
                                }
                            }
                        }
                        else
                        {
                            e.Handled = e.KeyChar != '\b';
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}