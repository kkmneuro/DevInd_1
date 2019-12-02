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
    public class clsSecurityManager : IclsManager
    {
        #region Members
        static clsSecurityManager _clsSecurityManager = null;
        public DS4Securities _DS4Securities = new DS4Securities();
        List<string> _lstSecurityName = new List<string>();
        #endregion Members
        #region Methods
        private clsSecurityManager()
        {
        }

        public void FillDataToDataSet()
        {
            clsProxyClassManager.INSTANCE._objBOEngineClient.GetSecurityTypeCompleted += new EventHandler<GetSecurityTypeCompletedEventArgs>(_objMasterInfoClient_GetSecurityTypeCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.GetSecurityTypeAsync(clsGlobal.userIDPwd);
           
        }

        void _objMasterInfoClient_GetSecurityTypeCompleted(object sender, GetSecurityTypeCompletedEventArgs e)
        {
            foreach (clsSecurityType securityType in e.Result)
            {
                DoHandleSecurityTable(securityType);
            }
        }
        private void DoHandleSecurityTable(clsSecurityType Secur)
        {
            try
            {
                DS4Securities.dtSecuritiesRow _SecurityRow = _DS4Securities.dtSecurities.FindBySecurityID(Secur.SecurityTypeID);
                if (_SecurityRow == null)
                {
                    if (Secur.SecurityName != string.Empty)
                    {
                        _lstSecurityName.Add(Secur.SecurityName);
                    }
                    _DS4Securities.dtSecurities.AdddtSecuritiesRow(Secur.SecurityName, Secur.SecurityDescription, Secur.Symbols, Secur.SecurityTypeID);
                }
                else
                {
                    _SecurityRow.Name = Secur.SecurityName;
                    _SecurityRow.Description = Secur.SecurityDescription;
                    _SecurityRow.Symbols = Secur.Symbols;
                    _SecurityRow.SecurityID = Secur.SecurityTypeID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsSecurityManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleSecurityTable()");
            }
        }
        public string[] GetSecurityNameArray()
        {
            return _lstSecurityName.ToArray();
        }
        public string GetSecuritiesName(int SecurityTypeId)
        {
            DS4Securities.dtSecuritiesRow SecuritiesRow = _DS4Securities.dtSecurities.FindBySecurityID(SecurityTypeId);
            if (SecuritiesRow == null)
                return null;
            return SecuritiesRow.Name;
        }

        public int GetSecuritiesId(string SecuritiesName)
        {

            DS4Securities.dtSecuritiesRow[] SecuritiesRow = (DS4Securities.dtSecuritiesRow[])_DS4Securities.dtSecurities.Select("Name = '" + SecuritiesName + "'");
            if (SecuritiesRow == null)
                return 0;
            return SecuritiesRow[0].SecurityID;
        }
        #endregion Methods

        #region Property
        public static clsSecurityManager INSTANCE
        {
            get
            {
                if (_clsSecurityManager == null)
                {
                    _clsSecurityManager = new clsSecurityManager();
                }
                return _clsSecurityManager;
            }
        }
        #endregion Property

        #region IclsManager
        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.Security_ID:
                    //DoHandleSecurityTable((PS as SecurityPS)._Security);
                    break;
                default:
                    break;
            }

        }



        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            throw new NotImplementedException();
        }
        #endregion IclsManager
    }
}
