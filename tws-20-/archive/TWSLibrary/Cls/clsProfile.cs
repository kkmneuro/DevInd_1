using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLibrary.Cls
{
    public enum ProfileTypes
    {
        Trade,
        OrderBook,
        NetPosition,
        Serveillance,
        MarketWatch,
        Portfolio
    }

    [Serializable]
    public class ClsProfile
    {
        private readonly Dictionary<string, ClsColumnSetting> _DDcolumnSetting =
            new Dictionary<string, ClsColumnSetting>();

        private string _profileName;
        private ProfileTypes _profileType;

      

        public string ProfileName
        {
            get { return _profileName; }
            set { _profileName = value; }
        }

        public ProfileTypes ProfileType
        {
            get { return _profileType; }
            set { _profileType = value; }
        }

        public Dictionary<string, ClsColumnSetting> DDColumnSetting
        {
            get { return _DDcolumnSetting; }
        }

        public bool AddColumnSetting(string columnText, ClsColumnSetting columnSetting)
        {
            if (!_DDcolumnSetting.Keys.Contains(columnText))
            {
                _DDcolumnSetting.Add(columnText, columnSetting);
                _DDcolumnSetting.Add(columnText, columnSetting);
               

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveColumnSetting(string columnText)
        {
            if (_DDcolumnSetting.Keys.Contains(columnText))
            {
                _DDcolumnSetting.Remove(columnText);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}