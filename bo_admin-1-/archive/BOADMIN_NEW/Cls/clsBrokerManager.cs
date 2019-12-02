using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using BOADMIN_NEW.BOEngineServiceTCP;
namespace BOADMIN_NEW.Cls
{
    public class clsBrokerManager : IclsManager
    {
        static clsBrokerManager _clsBrokerManger = null;
        public DS4BrokerTypes _DS4BrokerTypes = new DS4BrokerTypes();
        public DS4Brokers _DS4Brokers = new DS4Brokers();
        List<string> _lstBrokerTypes = new List<string>();
        List<string> _lstModules = new List<string>();
        private clsBrokerManager()
        {
        }
        #region PROPERTY
        public static clsBrokerManager INSTANCE
        {
            get
            {
                if (_clsBrokerManger == null)
                {
                    _clsBrokerManger = new clsBrokerManager();
                }
                return _clsBrokerManger;
            }
        }
        #endregion PROPERTY


        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.Broker_ID:
                    //DoHandleBrokerType((PS as BrokerTypePS)._BrType);
                    break;
                case ProtocolStructIDS.Module_ID:
                    // DoHandleModules((PS as ModulePS)._Module);
                    break;
                default:
                    break;
            }
        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsBrokerManager : Enter FillDataToDataSet()");

                //clsProxyClassManager.INSTANCE._objMasterInfoClient.GetBrokerListCompleted += new EventHandler<GetBrokerListCompletedEventArgs>(_objMasterInfoClient_GetBrokerListCompleted);
                //clsProxyClassManager.INSTANCE._objMasterInfoClient.GetBrokerListAsync(clsGlobal.userIDPwd);
                //clsProxyClassManager.INSTANCE._objMasterInfoClient.GetModulesCompleted += new EventHandler<GetModulesCompletedEventArgs>(_objMasterInfoClient_GetModulesCompleted);
                //clsProxyClassManager.INSTANCE._objMasterInfoClient.GetCurrencyListAsync(clsGlobal.userIDPwd);
                foreach (clsBrokerList brokerlst in clsProxyClassManager.INSTANCE.GetBrokerListRcords())
                {
                    DoHandleBrokerType(brokerlst);
                }
                foreach (clsModule module in clsProxyClassManager.INSTANCE.GetModuleRcords())
                {
                    DoHandleModules(module);
                }

                //Logging.FileHandling.WriteAllLog("clsBrokerManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokerManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objMasterInfoClient_GetModulesCompleted(object sender, GetModulesCompletedEventArgs e)
        {
            foreach (clsModule module in e.Result)
            {
                DoHandleModules(module);
            }
        }

        void _objMasterInfoClient_GetBrokerListCompleted(object sender, GetBrokerListCompletedEventArgs e)
        {
            foreach (clsBrokerList brokerlst in e.Result)
            {
                DoHandleBrokerType(brokerlst);
            }
        }
        public void DoHandleModules(clsModule module)
        {
            try
            {
                DS4Brokers.dtModulesRow moduleRow = _DS4Brokers.dtModules.FindById(module.ID);
                if (moduleRow == null)
                {
                    moduleRow = _DS4Brokers.dtModules.NewRow() as DS4Brokers.dtModulesRow;
                    moduleRow.Id = module.ID;
                    moduleRow.ModName = module.ModName;
                    _DS4Brokers.dtModules.AdddtModulesRow(moduleRow);
                    _lstModules.Add(module.ModName.Trim());
                }
                else
                {
                    moduleRow.Id = module.ID;
                    moduleRow.ModName = module.ModName;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokerManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleModules()");
            }
        }
        public List<string> GetAllModules()
        {
            return _lstModules;
        }
        public void DoHandleBrokerType(clsBrokerList brokerType)
        {
            try
            {
                DS4BrokerTypes.dtBrokerTypesRow brokerTypesRow = _DS4BrokerTypes.dtBrokerTypes.FindByPK_BrokerTypesID(brokerType.BrokerTypesID);
                if (brokerTypesRow == null)
                {
                    brokerTypesRow = _DS4BrokerTypes.dtBrokerTypes.NewRow() as DS4BrokerTypes.dtBrokerTypesRow;
                    brokerTypesRow.BrokerType = brokerType.BrokerType;
                    brokerTypesRow.PK_BrokerTypesID = brokerType.BrokerTypesID;
                    brokerTypesRow.Description = brokerType.Description;
                    _DS4BrokerTypes.dtBrokerTypes.AdddtBrokerTypesRow(brokerTypesRow);
                    _lstBrokerTypes.Add(brokerType.BrokerType);
                }
                else
                {
                    brokerTypesRow.BrokerType = brokerType.BrokerType;
                    brokerTypesRow.PK_BrokerTypesID = brokerType.BrokerTypesID;
                    brokerTypesRow.Description = brokerType.Description;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokerManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBrokerType()");
            }
        }
        public string[] GetBrokerTypesArray()
        {
            return _lstBrokerTypes.ToArray();
        }
        public string GetBrokerType(int BrokerTypesID)
        {
            DS4BrokerTypes.dtBrokerTypesRow _brokerTypesRow = _DS4BrokerTypes.dtBrokerTypes.FindByPK_BrokerTypesID(BrokerTypesID);
            if (_brokerTypesRow == null)
                return null;
            return _brokerTypesRow.BrokerType;
        }

        public int GetBrokerTypeId(string broker)
        {

            DS4BrokerTypes.dtBrokerTypesRow[] _brokerTypesRows = (DS4BrokerTypes.dtBrokerTypesRow[])_DS4BrokerTypes.dtBrokerTypes.Select("BrokerType = '" + broker + "'");
            if (_brokerTypesRows.Length == 0)
                return 0;
            return _brokerTypesRows[0].PK_BrokerTypesID;
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
