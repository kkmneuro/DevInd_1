using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using ProtocolStructs.NewPS;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    class clsCommonSettingsManagerNew : IclsManager
    {
        #region "   MEMBERS   "

        static clsCommonSettingsManagerNew _clsCommonSettingsManagerNew = null;
        public DS4CommonSettingNew _DS4CommonSettingNew = new DS4CommonSettingNew();

        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsCommonSettingsManagerNew INSTANCE
        {
            get
            {
                if (_clsCommonSettingsManagerNew == null)
                {
                    _clsCommonSettingsManagerNew = new clsCommonSettingsManagerNew();
                }
                return _clsCommonSettingsManagerNew;
            }
        }

        #endregion "    PROPERTY     "

        private clsCommonSettingsManagerNew()
        {

        }

        public void FillDataToDataSet(List<clsCommonSettings> lstCommonSettings)
        {
            foreach (clsCommonSettings item in lstCommonSettings)
            {
                DoHandleCommonSettingNewTable(item);
            }
        }

        public void DoHandleCommonSettingNewTable(clsCommonSettings commonSetting)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsCommonSettingsManagerNew : Enter DoHandleCommonSettingNewTable()");
                DS4CommonSettingNew.dtCommonSettingsRow CommonSettingsRow = _DS4CommonSettingNew.dtCommonSettings.FindByID(commonSetting.ID);

                if (CommonSettingsRow == null)
                {
                    CommonSettingsRow = _DS4CommonSettingNew.dtCommonSettings.NewRow() as DS4CommonSettingNew.dtCommonSettingsRow;
                    CommonSettingsRow.ID = commonSetting.ID;
                    CommonSettingsRow.Property = commonSetting.Property;
                    CommonSettingsRow.Value = commonSetting.Value;

                    _DS4CommonSettingNew.dtCommonSettings.AdddtCommonSettingsRow(CommonSettingsRow);

                }
                else
                {
                    CommonSettingsRow.ID = commonSetting.ID;
                    CommonSettingsRow.Property = commonSetting.Property;
                    CommonSettingsRow.Value = commonSetting.Value;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCommonSettingsManagerNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleCommonSettingNewTable()");
            }
            //_DS4CommonSettingNew.AcceptChanges();
            //_DS4CommonSettingNew.dtCommonSettings.AcceptChanges();
        }

        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleCommonSettingNewTable((PS as clsCommonSettingsNewPS)._CommonSettings);
        }

        public override void RemoveSetting(string DataKey)
        {
            int CommonSettingID = 50060;
            try
            {
                //Logging.FileHandling.WriteAllLog("clsCommonSettingsManagerNew : Enter RemoveSetting()");
                CommonSettingID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCommonSettingsManagerNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in RemoveSetting()");
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4CommonSettingNew.dtCommonSettingsRow Row = _DS4CommonSettingNew.dtCommonSettings.FindByID(CommonSettingID);
            lock (_DS4CommonSettingNew.dtCommonSettings)
            {
                _DS4CommonSettingNew.dtCommonSettings.RemovedtCommonSettingsRow(Row);
            }
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }
    }
}
