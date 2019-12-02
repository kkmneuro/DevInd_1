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
    class clsTaxMasterManager : IclsManager
    {
        #region "   MEMBERS   "

        static clsTaxMasterManager _clsTaxMasterManager = null;
        public DS4TaxMaster _DS4TaxMaster = new DS4TaxMaster();

        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsTaxMasterManager INSTANCE
        {
            get
            {
                if (_clsTaxMasterManager == null)
                {
                    _clsTaxMasterManager = new clsTaxMasterManager();
                }
                return _clsTaxMasterManager;
            }
        }

        #endregion "    PROPERTY     "

        private clsTaxMasterManager()
        {

        }
        /// <summary>
        /// Fills data to datasets
        /// </summary>
        /// <param name="lstFeeMaster"></param>
        public void FillDataToDataSet(List<clsTaxMaster> lstTaxMaster)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsTaxMasterManager : Enter FillDataToDataSet()");

                foreach (clsTaxMaster taxMaster in lstTaxMaster)
                {
                    DoHandleTaxMasterTable(taxMaster);
                }

                //Logging.FileHandling.WriteAllLog("clsTaxMasterManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTaxMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }
        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsTaxMasterManager : Enter FillDataToDataSet()");
                

                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTaxMasterCompleted += new EventHandler<HandleTaxMasterCompletedEventArgs>(_objTaxMasterClient_HandleTaxMasterCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTaxMasterAsync(clsGlobal.userIDPwd,OperationTypes.GET,null);
              
                //Logging.FileHandling.WriteAllLog("clsTaxMasterManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTaxMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objTaxMasterClient_HandleTaxMasterCompleted(object sender, HandleTaxMasterCompletedEventArgs e)
        {
            foreach (clsTaxMaster item in e.Result)
            {
                DoHandleTaxMasterTable(item);
            }            

            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleTaxMasterTable(clsTaxMaster taxMaster)
        {
            try
            {
                
                DS4TaxMaster.dtTaxMasterRow taxMasterRow = _DS4TaxMaster.dtTaxMaster.FindByPK_TaxID(taxMaster.TaxID);

                if (taxMasterRow == null)
                {
                    taxMasterRow = _DS4TaxMaster.dtTaxMaster.NewRow() as DS4TaxMaster.dtTaxMasterRow;
                    taxMasterRow.PK_TaxID = taxMaster.TaxID;
                    taxMasterRow.TaxName = taxMaster.TaxName;
                    taxMasterRow.TaxPercent = taxMaster.TaxPercent;                 
                    taxMasterRow.Amount = taxMaster.Amount;
                    taxMasterRow.Description = taxMaster.Description;

                    _DS4TaxMaster.dtTaxMaster.AdddtTaxMasterRow(taxMasterRow);

                }
                else
                {
                    taxMasterRow.PK_TaxID = taxMaster.TaxID;
                    taxMasterRow.TaxName = taxMaster.TaxName;
                    taxMasterRow.TaxPercent = taxMaster.TaxPercent;
                    taxMasterRow.Amount = taxMaster.Amount;
                    taxMasterRow.Description = taxMaster.Description;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTaxMasterManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleTaxMasterTable()");
            }
        }
        #region "     IclsManaager    "


        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleTaxMasterTable((PS as TaxMasterPS)._TaxMaster);
        }

        public override void RemoveSetting(string DataKey)
        {
            int TaxMasterID = 50060;
            try
            {
                TaxMasterID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4TaxMaster.dtTaxMasterRow Row = _DS4TaxMaster.dtTaxMaster.FindByPK_TaxID(TaxMasterID);
            lock (_DS4TaxMaster.dtTaxMaster)
            {
                _DS4TaxMaster.dtTaxMaster.RemovedtTaxMasterRow(Row);
            }

        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        #endregion "     IclsManaager    "

        public DS4TaxMaster.dtTaxMasterRow GetTaxRow(string taxName)
        {
            DS4TaxMaster.dtTaxMasterRow row = _DS4TaxMaster.dtTaxMaster.FirstOrDefault(x => x.TaxName == taxName);

            return row;
        }
    }
}
