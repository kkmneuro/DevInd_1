using System;
using System.Linq;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.Cls
{
    public class ClsHotKeyManager
    {
        public void SetHotKey(string name, string str, NCommand cmd)
        {
            if ((str.Equals("[NONE]", StringComparison.InvariantCultureIgnoreCase)) || (!str.Contains("+")))
            {
                return;
            }
            string[] strArray = str.Split('+'); //strArray[1].Split('+');
            foreach (string item in strArray.Select(element => element.Trim()))
            {
                if (item.Equals("Alt", StringComparison.InvariantCultureIgnoreCase))
                {
                    cmd.Properties.Shortcut.Modifiers = Keys.Alt;
                }
                else if (item.Equals("Shift", StringComparison.InvariantCultureIgnoreCase))
                {
                    cmd.Properties.Shortcut.Modifiers = Keys.Shift;
                }
                else if (item.Equals("Ctrl", StringComparison.InvariantCultureIgnoreCase))
                {
                    cmd.Properties.Shortcut.Modifiers = Keys.Control;
                }
                else
                {
                    string key = item;
                    switch (item)
                    {
                        case "0":
                            key = "D0";
                            break;
                        case "1":
                            key = "D1";
                            break;
                        case "2":
                            key = "D2";
                            break;
                        case "3":
                            key = "D3";
                            break;
                        case "4":
                            key = "D4";
                            break;
                        case "5":
                            key = "D5";
                            break;
                        case "6":
                            key = "D6";
                            break;
                        case "7":
                            key = "D7";
                            break;
                        case "8":
                            key = "D8";
                            break;
                        case "9":
                            key = "D9";
                            break;
                        default:
                            break;
                    }
                    cmd.Properties.Shortcut.Key = (Keys) Enum.Parse(typeof (Keys), key);
                }
            }
        }
    }
}