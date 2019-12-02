using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsCommonManager
    {
        #region MEMBERS
        static clsCommonManager _clsCommonManager = null;
        public DS4Common _DS4Common = new DS4Common();
        List<string> _lstTimeZone = new List<string>();
        #endregion MEMBERS

        #region METHODS
        private clsCommonManager()
        {
            for (int iLoop = -12; iLoop <= 12; iLoop++)
            {
                if (iLoop >= 0)
                {
                    _lstTimeZone.Add("GMT+" + string.Format("{0:00:00}", iLoop));
                }
                else
                {
                    _lstTimeZone.Add("GMT" + string.Format("{0:00:00}", iLoop));
                }
            }


        }

        public void AddCommonSetting(Common Com)
        {
            DoHandleCommonTable(Com);
        }

        private void DoHandleCommonTable(Common Com)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsCommonManager : Enter DoHandleCommonTable()");
                DS4Common.dtCommonRow _CommonRow = _DS4Common.dtCommon.FindByCommonId(Com._CommonId);
                if (_CommonRow == null)
                {
                    _DS4Common.dtCommon.AdddtCommonRow(Com._CommonId, Com._Property, Com._Value);
                }
                else
                {
                    _CommonRow.CommonId = Com._CommonId;
                    _CommonRow.Property = Com._Property;
                    _CommonRow.value = Com._Value;

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCommonManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleCommonTable()");
            }
        }
        #endregion METHODS
        #region PROPERTY
        public static clsCommonManager INSTANCE
        {
            get
            {
                if (_clsCommonManager == null)
                {
                    _clsCommonManager = new clsCommonManager();
                }
                return _clsCommonManager;
            }
        }
        #endregion PROPERTY
    }
}
