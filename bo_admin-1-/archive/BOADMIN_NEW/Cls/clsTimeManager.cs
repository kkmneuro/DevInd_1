using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsTimeManager : IclsManager
    {
        #region Members
        static clsTimeManager _clsTimeManager = null;
        List<string> _ListDay = new List<string>();
        public DS4Time _DS4Time = new DS4Time();
        #endregion Members
        #region Methods
        private clsTimeManager()
        {

        }

        public void FillDataToDataSet()
        {
            

            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTimeSettingsCompleted += new EventHandler<HandleTimeSettingsCompletedEventArgs>(_objTimeSettingsClient_HandleTimeSettingsCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTimeSettingsAsync(clsGlobal.userIDPwd,OperationTypes.GET,null);
            //foreach (clsTimeSettings item in clsProxyClassManager.INSTANCE.GetTimeSettingsRecords())
            //{
            //    DoHandleTimeTable(item);
            //}
        }

        void _objTimeSettingsClient_HandleTimeSettingsCompleted(object sender, HandleTimeSettingsCompletedEventArgs e)
        {
            foreach (clsTimeSettings item in e.Result)
            {
                DoHandleTimeTable(item);
            }
            
            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleTimeTable(clsTimeSettings T)
        {
            try
            {
                DS4Time.dtTimeRow _TimeRow = _DS4Time.dtTime.FindByDay(T.Day);
                if (_TimeRow == null)
                {
                    _DS4Time.dtTime.AdddtTimeRow(T.Day, T.TimeSpan);
                    if (!_ListDay.Contains(T.Day))
                    {
                        _ListDay.Add(T.Day);
                    }
                }
                else
                {
                    _TimeRow.Day = T.Day;
                    _TimeRow.TimeSpan = T.TimeSpan;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTimeManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleTimeTable()");
            }
        }

        public string[] GetDayArray()
        {
            return _ListDay.ToArray();
        }
        #endregion Methods
        #region Property
        public static clsTimeManager INSTANCE
        {
            get
            {
                if (_clsTimeManager == null)
                {
                    _clsTimeManager = new clsTimeManager();
                }
                return _clsTimeManager;
            }
        }
        #endregion Property

        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleTimeTable((PS as TimePS)._Time);
        }

        public override void RemoveSetting(string DataKey)
        {
            string day = DataKey;

            DS4Time.dtTimeRow Row = _DS4Time.dtTime.FindByDay(day);
            lock (_DS4Time.dtTime)
            {
                _DS4Time.dtTime.RemovedtTimeRow(Row);
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
