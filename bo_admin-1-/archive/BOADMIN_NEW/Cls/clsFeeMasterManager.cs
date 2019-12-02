using System;
using System.Collections.Generic;
using System.Linq;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    /// <summary>
    /// FeeMaster manager class
    /// </summary>
    class clsFeeMasterManager : IclsManager
    {
        #region "   MEMBERS   "

        static clsFeeMasterManager _ClsFeeMasterManager = null;
        public DS4FeeMaster _DS4FeeMaster = new DS4FeeMaster();

        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsFeeMasterManager INSTANCE
        {
            get { return _ClsFeeMasterManager ?? (_ClsFeeMasterManager = new clsFeeMasterManager()); }
        }

        #endregion "    PROPERTY     "

        private clsFeeMasterManager()
        {

        }
        /// <summary>
        /// Fills data to datasets
        /// </summary>
        /// <param name="lstFeeMaster"></param>
        public void FillDataToDataSet(List<clsFeeMaster> lstFeeMaster)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsFeeMasterManager : Enter FillDataToDataSet()");

                foreach (clsFeeMaster feeMaster in lstFeeMaster)
                {
                    DoHandleFeeMasterTable(feeMaster);
                }

                //Logging.FileHandling.WriteAllLog("clsFeeMasterManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsFeeMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        /// <summary>
        /// Handles Fee Master information
        /// </summary>
        /// <param name="feeMaster"></param>
        public void DoHandleFeeMasterTable(clsFeeMaster feeMaster)
        {
            try
            {
                
                DS4FeeMaster.dtFeeMasterRow feeMasterRow = _DS4FeeMaster.dtFeeMaster.FindByPK_FeeID(feeMaster.FeeId);

                if (feeMasterRow == null)
                {
                    feeMasterRow = _DS4FeeMaster.dtFeeMaster.NewRow() as DS4FeeMaster.dtFeeMasterRow;
                    if (feeMasterRow != null)
                    {
                        feeMasterRow.PK_FeeID = feeMaster.FeeId;
                        feeMasterRow.FeeName = feeMaster.FeeName;
                        feeMasterRow.MinimumFeeValue = feeMaster.MinimumFeeValue;
                        feeMasterRow.MaximunFeeValue = feeMaster.MaximumFeevalue;
                        feeMasterRow.Interval = feeMaster.Interval;
                        feeMasterRow.IsTaxable = feeMaster.IsTaxable;
                        feeMasterRow.Description = feeMaster.Description;
                        feeMasterRow.FeesMode = feeMaster.FeesMode;
                        feeMasterRow.LevyOn = feeMaster.LevyOn;
                        feeMasterRow.Days = feeMaster.Days;

                        _DS4FeeMaster.dtFeeMaster.AdddtFeeMasterRow(feeMasterRow);
                    }
                }
                else
                {
                    feeMasterRow.PK_FeeID = feeMaster.FeeId;
                    feeMasterRow.FeeName = feeMaster.FeeName;
                    feeMasterRow.MinimumFeeValue = feeMaster.MinimumFeeValue;
                    feeMasterRow.MaximunFeeValue = feeMaster.MaximumFeevalue;
                    feeMasterRow.Interval = feeMaster.Interval;
                    feeMasterRow.IsTaxable = feeMaster.IsTaxable;
                    feeMasterRow.Description = feeMaster.Description;
                    feeMasterRow.FeesMode = feeMaster.FeesMode;
                    feeMasterRow.LevyOn = feeMaster.LevyOn;
                    feeMasterRow.Days = feeMaster.Days;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsFeeMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleFeeMasterTable()");
            }
        }
        #region "     IclsManaager    "


        public override void AddSetting(IProtocolStruct PS)
        {
            
        }
        /// <summary>
        /// Updates dataset status
        /// </summary>
        /// <param name="DataKey"></param>
        public override void RemoveSetting(string DataKey)
        {
            int feeMasterId = 50060;
            try
            {
                feeMasterId = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4FeeMaster.dtFeeMasterRow row = _DS4FeeMaster.dtFeeMaster.FindByPK_FeeID(feeMasterId);
            lock (_DS4FeeMaster.dtFeeMaster)
            {
                _DS4FeeMaster.dtFeeMaster.RemovedtFeeMasterRow(row);
            }
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        public DS4FeeMaster.dtFeeMasterRow GetFeeRow(string feeName)
        {
            DS4FeeMaster.dtFeeMasterRow row = _DS4FeeMaster.dtFeeMaster.FirstOrDefault(x => x.FeeName == feeName);

            return row;
        }



        #endregion "     IclsManaager    "
    }
}
