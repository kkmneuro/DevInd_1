using System.Text.RegularExpressions;

namespace CommonLibrary.Cls
{
    public class ClsValidate
    {
        //public static bool ValidateInt(int value)
        //{

        //}

        public static bool IsNotNull(string ctrlText)
        {
            bool flag = true;
            if (ctrlText == string.Empty)
            {
                flag = false;
            }
            return flag;
        }

        public static bool ValidateEmail(string ctrlText)
        {
            bool flag = true;

            Match objMatch = Regex.Match(ctrlText,
                                         @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
            if (!objMatch.Success)
            {
                flag = false;
            }
            return flag;
        }
    }
}