using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtocolStructs.NewPS;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsMasterInfoManager:IclsManager
    {
        static clsMasterInfoManager _instance = null;
        List<string> _lstDeliverUnits;
        List<string> _lstOrderTypes;
        List<string> _lstProductNames;
        List<string> _lstUnExpiredSymbols;
        Dictionary<int, string> _DDRoles;
        public Dictionary<int, string> _DDSymbols;
        Dictionary<int, string> _DDLPNames;
        Dictionary<int, string> _DDClientAccountTypes;
        Dictionary<int, string> _DDHedgeTypes;
        Dictionary<string, Dictionary<string, string[]>> _DDTGymbolsInfo;
        Dictionary<string, int> _DDContractSize;
        Dictionary<string, string> _DDCommonSettings;
        public static clsMasterInfoManager INSTANCE
        {
            get
         {
                if (_instance == null)
                {
                    _instance = new clsMasterInfoManager();
                }
                return _instance;
            }
        }

        public Dictionary<string, Dictionary<string, string[]>> DDTGSymbolsInfo
        {
            get
            {
                return _DDTGymbolsInfo;
            }
        }
        public List<string> GetDeliveryUnits
        {
            get
            {
                return _lstDeliverUnits;
            }
        }

        public List<string> GetOrderTypes
        {
            get
            {
                return _lstOrderTypes;
            }
        }

        public List<string> GetProductNames
        {
            get
            {
                return _lstProductNames;
            }
        }

        public string[] GetHedgeTypes()
        {
            return _DDHedgeTypes.Values.ToArray();
        }

        public override void AddSetting(IProtocolStruct PS)
        {
            
        }

        public void HandleMasterInfo(BOEngineServiceTCP.clsMasterInfo clsMasterInfo)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsMasterInfoManager : Enter HandleMasterInfo()");

                _lstDeliverUnits = clsMasterInfo.lstDeliveryUnit.ToList();
                _lstOrderTypes = clsMasterInfo.lstOrderTypes.ToList();
                _lstProductNames = clsMasterInfo.lstProductNames.ToList();
                _DDRoles = clsMasterInfo.DDRoles;
                _DDSymbols = clsMasterInfo.DDSymbols;
                _DDLPNames = clsMasterInfo.DDLPNames;
                _DDClientAccountTypes = clsMasterInfo.DDClientAccountTypes;
                _lstUnExpiredSymbols = clsMasterInfo.lstUnexpiredSymbols.ToList();
                _DDHedgeTypes = clsMasterInfo.DDHedgeTypes;
                _DDTGymbolsInfo = clsMasterInfo.DDTGSymbolsInfo;
                _DDContractSize = clsMasterInfo.DDContractSize;
                _DDCommonSettings = clsMasterInfo.DDCommonSettings;
                
                //Logging.FileHandling.WriteAllLog("clsMasterInfoManager : Exit HandleMasterInfo()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsMasterInfoManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleMasterInfo()");
            }
        }

        public string GetPredefinedRole(int roleID)
        {
            if (_DDRoles.ContainsKey(roleID))
            {
                return _DDRoles[roleID];
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetPredefinedRole(string brokerName)
        {
            if (brokerName == string.Empty)
                return string.Empty;
            return GetPredefinedRole(clsBrokerManager.INSTANCE.GetBrokerTypeId(brokerName));
        }
        public override void RemoveSetting(string DataKey)
        {
        }

        public override void ServerRequestResponse(DBResponse response)
        {
        }

        public int GetOrderID(string orderName)
        {
            return _lstOrderTypes.IndexOf(orderName) + 1;
        }

        public int GetDeliveryUnitID(string unitName)
        {
            return _lstDeliverUnits.IndexOf(unitName)+1;
        }

        public string GetOrderType(int id)
        {
            return _lstOrderTypes[id - 1]; 
        }

        public string GetDeliveryUnit(int id)
        {
            if (_lstDeliverUnits!=null)
            {
                return _lstDeliverUnits[id - 1];     
            }
            else
            {
                return ""; 
            }
            
        }

        public string GetDeliveryType(int id)
        {
            string deliveryType;
            switch (id)
            {
                case 1:
                    deliveryType = "Deliverable";
                    break;
                case 2:
                    deliveryType = "NonDeliverable";
                    break;
                default:
                    deliveryType ="NONE";
                    break;
            }
            return deliveryType;
        }

        public int GetDeliveryTypeID(string deliveryType)
        {
            int deliveryTypeID;

            switch (deliveryType)
            {
                case "Deliverable":
                    deliveryTypeID= (int)DeliveryType.Deliverable;
                    break;
                case "NonDeliverable":
                    deliveryTypeID= (int)DeliveryType.NONDeliverable;
                    break;
                default:
                    deliveryTypeID=0;
                    break;
            }
            return deliveryTypeID;
        }

        public enum DeliveryType:int
        {
            Deliverable=1,
            NONDeliverable
        }

        public string[] GetSymbolList()
        {
            if (_DDSymbols == null)
            {
                return null;
            }
            return _DDSymbols.Values.ToArray();
        }

        public List<string> GetLPNames()
        {
            List<string> lst = new List<string>();
            if (_DDLPNames == null)
            {
                return lst;
            }
            return _DDLPNames.Values.ToList();
        }

        public int GetLPID(string LPName)
        {
            if (LPName == string.Empty)
                return 0;
            return _DDLPNames.First(x => x.Value == LPName).Key;
        }

        public List<string> GetClientAccountTypes()
        {
            List<string> lstAccountTypes = new List<string>();

            if (_DDClientAccountTypes == null)
            {
                return lstAccountTypes;
            }
            return _DDClientAccountTypes.Values.ToList();
        }
        public int GetClientAccountTypeID(string clientAccountType)
        {
            if (clientAccountType == string.Empty)
                return 0;
            return _DDClientAccountTypes.FirstOrDefault(x => x.Value == clientAccountType).Key;
        }

        public string GetCLientAccountTypeName(int ID)
        {
            if (_DDClientAccountTypes.ContainsKey(ID))
                return _DDClientAccountTypes[ID];

            return string.Empty;
        }

        public int GetSymbolId(string symbolName)
        {
            if (symbolName.Trim() == string.Empty)
                return 0;
            return _DDSymbols.First(A => A.Value == symbolName.Trim()).Key;
        }

        public string GetSymbolName(int symbolId)
        {
            if (!_DDSymbols.ContainsKey(symbolId))
            {
                return string.Empty;
            }
            return _DDSymbols[symbolId];
        }

        public string[] GetUnexpiredSymbols()
        {
            return _lstUnExpiredSymbols.ToArray();
        }

        public string GetHedgeType(int hedgeTypeId)
        {
            if (!_DDHedgeTypes.ContainsKey(hedgeTypeId))
               return string.Empty;
            return _DDHedgeTypes[hedgeTypeId];
        }

        public int GetHedgeTypeID(string hedgeType)
        {
            if (hedgeType == string.Empty)
                return 0;
            return _DDHedgeTypes.First(hedge => hedge.Value == hedgeType).Key;
        }

        public int GetContractSize(string id)
        {
            return _DDContractSize[id];
        }

        public string GetCommonSettingsValue(string propertyName)
        {
            if (clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings.Rows.Count == 0)
            {
                return _DDCommonSettings[propertyName];
            }
            else
            {
                return ((DS4CommonSettingNew.dtCommonSettingsRow)clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings.First(x=>x.Property== propertyName)).Value;
            }
        }
    }
}
