using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateParser
{
    public class DateParser
    {
        Helper helper;
        public DateParser(string format)
        {
            helper = new Helper();
            helper.dateFormat = format;
        }
        public DateTime getDate(string date)
        {
           return DateTime.ParseExact(date, helper.dateFormat, helper);
        }
    }
    class Helper:IFormatProvider
    {
        public string dateFormat;
        
        #region IFormatProvider Members

        public object GetFormat(Type formatType)
        {
            return dateFormat;
        }

        #endregion
    }
   
}
