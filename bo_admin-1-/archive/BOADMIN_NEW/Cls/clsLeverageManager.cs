using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using BOADMIN_NEW.BOEngineServiceTCP;
namespace BOADMIN_NEW.Cls
{
    public class clsLeverageManager : IclsManager
    {
        static clsLeverageManager _clsLeverageManager = null;
        public DS4Leverage _DS4Leverage = new DS4Leverage();
        List<string> _lstLeverage = new List<string>();
        private clsLeverageManager()
        {
        }
        #region PROPERTY
        public static clsLeverageManager INSTANCE
        {
            get
            {
                if (_clsLeverageManager == null)
                {
                    _clsLeverageManager = new clsLeverageManager();
                }
                return _clsLeverageManager;
            }
        }
        #endregion PROPERTY


        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.Leverage_ID:
                    //DoHandleLeverage((PS as LeveragePS)._Leverage);
                    break;
                default:
                    break;
            }
        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsLeverageManager : Enter FillDataToDataSet()");

                clsProxyClassManager.INSTANCE._objBOEngineClient.GetLeverageListCompleted += new EventHandler<GetLeverageListCompletedEventArgs>(_objMasterInfoClient_GetLeverageListCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetLeverageListAsync(clsGlobal.userIDPwd);
                //foreach (clsLeverage leverage in clsProxyClassManager.INSTANCE.GetLeverageRecords())
                //{
                //    DoHandleLeverage(leverage);
                //}

                //Logging.FileHandling.WriteAllLog("clsLeverageManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsLeverageManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objMasterInfoClient_GetLeverageListCompleted(object sender, GetLeverageListCompletedEventArgs e)
        {
            foreach (clsLeverage leverage in e.Result)
            {
                DoHandleLeverage(leverage);
            }
        }

        private void DoHandleLeverage(clsLeverage leverage)
        {
            try
            {
                
                DS4Leverage.dtLeverageRow leverageRow = _DS4Leverage.dtLeverage.FindByPK_LeverageId(leverage.LeverageId);
                if (leverageRow == null)
                {
                    leverageRow = _DS4Leverage.dtLeverage.NewRow() as DS4Leverage.dtLeverageRow;
                    leverageRow.Leverage = leverage.Leverage;
                    leverageRow.PK_LeverageId = leverage.LeverageId;
                    _DS4Leverage.dtLeverage.AdddtLeverageRow(leverageRow);
                    _lstLeverage.Add(leverageRow.Leverage);
                }
                else
                {
                    //leverageRow.Leverage = leverage._Leverage;
                    //leverageRow.PK_LeverageId = leverage._LeverageId;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsLeverageManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleLeverage()");
            }
        }
        public string[] GetLeverageArray()
        {
            return _lstLeverage.ToArray();
        }
        public string GetLeverage(int LeverageId)
        {
            DS4Leverage.dtLeverageRow _leverageRow = _DS4Leverage.dtLeverage.FindByPK_LeverageId(LeverageId);
            if (_leverageRow == null)
                return null;
            return _leverageRow.Leverage;
        }

        public int GetLeverageId(string leverage)
        {

            DS4Leverage.dtLeverageRow[] _leverageRows = (DS4Leverage.dtLeverageRow[])_DS4Leverage.dtLeverage.Select("Leverage = '" + leverage + "'");
            if (_leverageRows == null)
                return 0;
            return _leverageRows[0].PK_LeverageId;
        }
        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
