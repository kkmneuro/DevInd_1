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
    public class clsHolidayManager : IclsManager
    {
        #region MEMBERS
        static clsHolidayManager _clsHolidayManager = null;
        public DS4Holidays _DS4Holidays = new DS4Holidays();

        #endregion MEMBERS
        #region METHODS
        private clsHolidayManager()
        {

        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsHolidayManager : Enter FillDataToDataSet()");

                
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleHolidayCompleted += new EventHandler<HandleHolidayCompletedEventArgs>(_objHolidayClient_HandleHolidayCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleHolidayAsync(clsGlobal.userIDPwd,OperationTypes.GET,null);
                //foreach (clsHoliday item in clsProxyClassManager.INSTANCE.GetHolidayRecords())
                //{
                //    DoHandleHolidayTable(item);
                //}

                //Logging.FileHandling.WriteAllLog("clsHolidayManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsHolidayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objHolidayClient_HandleHolidayCompleted(object sender, HandleHolidayCompletedEventArgs e)
        {
            foreach (clsHoliday item in e.Result)
            {
                DoHandleHolidayTable(item);
            }
            

            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleHolidayTable(clsHoliday holi)
        {
            try
            {
                
                DS4Holidays.dtHolidayRow _HolidayRow = _DS4Holidays.dtHoliday.FindByHolidayID(holi.Id);
                if (_HolidayRow == null)
                {
                    if (holi.IsEveryYear == true)
                    {
                        string d = holi.Day.ToString("MM/dd");
                        _DS4Holidays.dtHoliday.AdddtHolidayRow(d, holi.IsEveryYear, holi.FromTime, holi.ToTime, holi.Symbol, holi.Description, holi.Id, holi.IsEnable);
                    }
                    else
                        _DS4Holidays.dtHoliday.AdddtHolidayRow(holi.Day.ToString("MM/dd/yyyy"), holi.IsEveryYear, holi.FromTime, holi.ToTime, holi.Symbol, holi.Description, holi.Id, holi.IsEnable);
                }
                else
                {
                    if (holi.IsEveryYear == true)
                    {
                        string d = holi.Day.ToString("MM/dd");
                        _HolidayRow.Date = d;
                        _HolidayRow.IsEveryYear = holi.IsEveryYear;
                        _HolidayRow.WorkTimeFrom = holi.FromTime;
                        _HolidayRow.WorkTimeTo = holi.ToTime;
                        _HolidayRow.Symbol = holi.Symbol;
                        _HolidayRow.Description = holi.Description;
                        _HolidayRow.HolidayID = holi.Id;
                        _HolidayRow.IsEnable = holi.IsEnable;
                    }
                    else
                    {
                        _HolidayRow.Date = holi.Day.ToString("MM/dd/yyyy");
                        _HolidayRow.IsEveryYear = holi.IsEveryYear;
                        _HolidayRow.WorkTimeFrom = holi.FromTime;
                        _HolidayRow.WorkTimeTo = holi.ToTime;
                        _HolidayRow.Symbol = holi.Symbol;
                        _HolidayRow.Description = holi.Description;
                        _HolidayRow.HolidayID = holi.Id;
                        _HolidayRow.IsEnable = holi.IsEnable;
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsHolidayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleHolidayTable()");
            }
        }
        #endregion METHODS

        #region PROPERTY
        public static clsHolidayManager INSTANCE
        {
            get
            {
                if (_clsHolidayManager == null)
                {
                    _clsHolidayManager = new clsHolidayManager();
                }
                return _clsHolidayManager;
            }
        }
        #endregion PROPERTY

        #region IclsManaager
        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleHolidayTable((PS as HolidayPS)._Holiday);
        }

        public override void RemoveSetting(string DataKey)
        {
            int HolidayID = -999;
            try
            {
                //Logging.FileHandling.WriteAllLog("clsHolidayManager : Enter RemoveSetting()");
                HolidayID = Convert.ToInt32(DataKey);
            }

            catch (Exception ex)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsHolidayManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in RemoveSetting()");
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4Holidays.dtHolidayRow Row = _DS4Holidays.dtHoliday.FindByHolidayID(HolidayID);
            lock (_DS4Holidays.dtHoliday)
            {
                _DS4Holidays.dtHoliday.RemovedtHolidayRow(Row);
            }

        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }
        #endregion IclsManager
    }

}
