using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BOADMIN_NEW.ReportService;

namespace BOADMIN_NEW.Cls
{
    class clsReportsMasterInfoManager
    {
        static clsReportsMasterInfoManager _instance = null;
        public Dictionary<int, string> _DDOrderTypes=new Dictionary<int,string>();
        public Dictionary<int, string> _DDSideTypes=new Dictionary<int,string>();
        public Dictionary<int, string> _DDTIFTypes= new Dictionary<int, string>();
        public static clsReportsMasterInfoManager INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new clsReportsMasterInfoManager();
                }
                return _instance;
            }
        }

        public void HandleReportsMasterInfo(clsReportsMasterInfo masterInfo)
        {
            try
            {
                _DDOrderTypes = masterInfo.OrderTypes;
                _DDSideTypes = masterInfo.SideTypes;
                _DDTIFTypes = masterInfo.TIFTypes;
            }
            catch (Exception)
            {

            }
        }

        public int GetTIFID(string TIFName)
        {
            if(TIFName==string.Empty)
                return 0;
            return _DDTIFTypes.First(A => A.Value == TIFName).Key;
        }

    }
}
