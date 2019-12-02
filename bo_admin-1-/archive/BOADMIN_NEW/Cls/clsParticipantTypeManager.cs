using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsParticipantTypeManager : IclsManager
    {
        static clsParticipantTypeManager _clsParticipantTypeManager = null;
        public  DS4ParticipantType _DS4ParticipantTypes = new DS4ParticipantType();
        public List<string> _lstParticipantTypeName = new List<string>();

        #region PROPERTY
        public static clsParticipantTypeManager INSTANCE
        {
            get
            {
                if (_clsParticipantTypeManager == null)
                {
                    _clsParticipantTypeManager = new clsParticipantTypeManager();
                }
                return _clsParticipantTypeManager;
            }
        }
        #endregion PROPERTY
        public override void AddSetting(IProtocolStruct PS)
        {
            //DoHandleParticipantTypeTable((PS as ParticipantTypePS)._ParticipantType);
        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsParticipantTypeManager : Enter FillDataToDataSet()");

                clsProxyClassManager.INSTANCE._objBOEngineClient.GetParticipaintListCompleted += new EventHandler<GetParticipaintListCompletedEventArgs>(_objMasterInfoClient_GetParticipaintListCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetParticipaintListAsync(clsGlobal.userIDPwd);
                
                //Logging.FileHandling.WriteAllLog("clsParticipantTypeManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsParticipantTypeManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objMasterInfoClient_GetParticipaintListCompleted(object sender, GetParticipaintListCompletedEventArgs e)
        {
            foreach (clsParticipaintList participaint in e.Result)
            {
                DoHandleParticipantTypeTable(participaint);
            }
        }

        private void DoHandleParticipantTypeTable(clsParticipaintList participantType)
        {
            try
            {
                DS4ParticipantType.dtParticipantTypesRow participantTypeRow = _DS4ParticipantTypes.dtParticipantTypes.FindByPK_ParticipantTypeID(participantType.PKParticipantTypeID);
                if (participantTypeRow == null)
                {
                    participantTypeRow = _DS4ParticipantTypes.dtParticipantTypes.NewRow() as DS4ParticipantType.dtParticipantTypesRow;
                    participantTypeRow.ParticpantTypeName = participantType.ParticpantTypeName;
                    participantTypeRow.PK_ParticipantTypeID = participantType.PKParticipantTypeID;
                    if (!_lstParticipantTypeName.Contains(participantTypeRow.ParticpantTypeName) && participantTypeRow.ParticpantTypeName != string.Empty)
                    {
                        _lstParticipantTypeName.Add(participantTypeRow.ParticpantTypeName);
                    }

                    _DS4ParticipantTypes.dtParticipantTypes.AdddtParticipantTypesRow(participantTypeRow);
                }
                else
                {
                    participantTypeRow.ParticpantTypeName = participantType.ParticpantTypeName;
                    participantTypeRow.PK_ParticipantTypeID = participantType.PKParticipantTypeID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsParticipantTypeManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleParticipantTypeTable()");
            }
        }
        internal int GetParticipantTypeId(string ParticipantTypeName)
        {
            if (ParticipantTypeName == string.Empty || ParticipantTypeName == "All")
                return 0;
            DS4ParticipantType.dtParticipantTypesRow[] _ParticipantTypesRow = (DS4ParticipantType.dtParticipantTypesRow[])_DS4ParticipantTypes.dtParticipantTypes.Select("ParticpantTypeName = '" + ParticipantTypeName + "'");
            if (_ParticipantTypesRow == null)
                return 0;
            return _ParticipantTypesRow[0].PK_ParticipantTypeID;
        }
        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        internal string[] GetParticipantTypeArray()
        {
            return _lstParticipantTypeName.ToArray();
        }
    }
}
