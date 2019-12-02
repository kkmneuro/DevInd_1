using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsBackupManager
    {
        #region Members
        static clsBackupManager _clsBackupManager = null;
        public DS4Backup _DS4Backup = new DS4Backup();
        #endregion Members
        #region Methods
        private clsBackupManager()
        {

        }
        public void AddBackupSettings(BackUp Bac)
        {
            DoHandleBackupTable(Bac);
        }
        private void DoHandleBackupTable(BackUp Bac)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsBackupManager : Enter DoHandleBackupTable()");
                DS4Backup.dtBackupRow _dtBackupRow = _DS4Backup.dtBackup.FindByBackUpId(Bac._BackUpId);
                if (_dtBackupRow == null)
                {
                    _DS4Backup.dtBackup.AdddtBackupRow(Bac._BackUpId, Bac._Property, Bac._Value);
                }
                else
                {
                    _dtBackupRow.BackUpId = Bac._BackUpId;
                    _dtBackupRow.Property = Bac._Property;
                    _dtBackupRow.Value = Bac._Value;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBackupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleBackupTable()");
            }
        }
        #endregion Methods
        #region Property
        public static clsBackupManager INSTANCE
        {
            get
            {
                if (_clsBackupManager == null)
                {
                    _clsBackupManager = new clsBackupManager();
                }
                return _clsBackupManager;
            }

        }
        #endregion Property

    }
}
