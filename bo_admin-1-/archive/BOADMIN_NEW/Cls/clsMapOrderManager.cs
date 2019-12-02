using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME.DSBO;
using ProtocolStructs.NewPS;
using clsInterface4OME;
using ProtocolStructs;

namespace BOADMIN_NEW.Cls
{
    public class clsMapOrderManager : IclsManager
    {
        static clsMapOrderManager _clsBrokerManager = null;
        public DS4MapOrders _DS4MapOrders = new DS4MapOrders();
        List<string> _lstAccountIDs = new List<string>();

        public static clsMapOrderManager INSTANCE
        {
            get
            {
                if (_clsBrokerManager == null)
                {
                    _clsBrokerManager = new clsMapOrderManager();
                }
                return _clsBrokerManager;
            }
        }

        private void DoHandleBrokersTable(clsMapOrders mapOrders)
        {
            try
            {
                DS4MapOrders.dtMapOrdersRow mapOrdersRow = _DS4MapOrders.dtMapOrders.FindByMapOrderID(mapOrders._MapOrderId);

                if (mapOrdersRow == null)
                {
                    mapOrdersRow = _DS4MapOrders.dtMapOrders.NewRow() as DS4MapOrders.dtMapOrdersRow;

                    mapOrdersRow.MapOrderID = clsUtility.GetInt(mapOrders._MapOrderId);
                    mapOrdersRow.BuyAccountID = clsUtility.GetInt(mapOrders._BuyAccountID);
                    mapOrdersRow.BuyOrderID = clsUtility.GetLong(mapOrders._BuySideOrderID);
                    mapOrdersRow.SellAccountID = clsUtility.GetInt(mapOrders._SellAccountID);
                    mapOrdersRow.SellOrderID = clsUtility.GetLong(mapOrders._SellSideOrderID);
                    mapOrdersRow.BuyFillID = clsUtility.GetInt(mapOrders._BuyFillID);
                    mapOrdersRow.SellFillID = clsUtility.GetInt(mapOrders._SellFillID);
                    mapOrdersRow.FilledQty = clsUtility.GetInt(mapOrders._FilledQty);
                    mapOrdersRow.LastUpdatedTime = mapOrders._LastUpdateTime;
                    mapOrdersRow.Price = Convert.ToDecimal(mapOrders._Price.ToString("0.00"));
                    mapOrdersRow.Symbol = clsUtility.GetStr(mapOrders._Symbol);

                    _DS4MapOrders.dtMapOrders.AdddtMapOrdersRow(mapOrdersRow);
                }
                else
                {
                    mapOrdersRow.MapOrderID = clsUtility.GetInt(mapOrders._MapOrderId);
                    mapOrdersRow.BuyAccountID = clsUtility.GetInt(mapOrders._BuyAccountID);
                    mapOrdersRow.BuyOrderID = clsUtility.GetLong(mapOrders._BuySideOrderID);
                    mapOrdersRow.SellAccountID = clsUtility.GetInt(mapOrders._SellAccountID);
                    mapOrdersRow.SellOrderID = clsUtility.GetLong(mapOrders._SellSideOrderID);
                    mapOrdersRow.BuyFillID = clsUtility.GetInt(mapOrders._BuyFillID);
                    mapOrdersRow.SellFillID = clsUtility.GetInt(mapOrders._SellFillID);
                    mapOrdersRow.FilledQty = clsUtility.GetInt(mapOrders._FilledQty);
                    mapOrdersRow.LastUpdatedTime = mapOrders._LastUpdateTime;
                    mapOrdersRow.Price = Convert.ToDecimal(mapOrders._Price.ToString("0.00"));
                    mapOrdersRow.Symbol = clsUtility.GetStr(mapOrders._Symbol);
                }
                if (!_lstAccountIDs.Contains(mapOrders._BuyAccountID.ToString()))
                {
                    _lstAccountIDs.Add(mapOrders._BuyAccountID.ToString());
                }
                if (!_lstAccountIDs.Contains(mapOrders._SellAccountID.ToString()))
                {
                    _lstAccountIDs.Add(mapOrders._SellAccountID.ToString());
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsMapOrderManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBrokersTable()");
            }

            _DS4MapOrders.dtMapOrders.AcceptChanges();   //to make the dataset refresh
        }

        public override void AddSetting(IProtocolStruct PS)
        {
            DoHandleBrokersTable(((clsMapOrdersPS)PS)._MapOrders);
        }

        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAccountIDs()
        {
            return _lstAccountIDs;
        }
        public DS4MapOrders.dtMapOrdersRow[] GetRows(int accountID)
        {
            DS4MapOrders.dtMapOrdersRow[] rows = (DS4MapOrders.dtMapOrdersRow[])_DS4MapOrders.dtMapOrders.Select("BuyAccountID=" + accountID + " OR SellAccountID=" + accountID);

            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public bool GetMapOrderInfo()
        {
            bool flag = true;
            try
            {
                //Logging.FileHandling.WriteAllLog("clsMapOrderManager : Enter GetMapOrderInfo()");

                foreach (BOADMIN_NEW.BOEngineServiceTCP.clsMapOrders item in clsProxyClassManager.INSTANCE.GetMapOrdersRecords())
                {
                    if (item.ServerResponseID == clsGlobal.FailureID)
                    {
                        flag = false;
                        return flag;
                    }
                    ProtocolStructs.NewPS.clsMapOrdersPS objclsMapOrdersPS = new ProtocolStructs.NewPS.clsMapOrdersPS();
                    objclsMapOrdersPS._MapOrders._MapOrderId = item.MapOrderId;
                    objclsMapOrdersPS._MapOrders._BuyAccountID = item.BuyAccountID;
                    objclsMapOrdersPS._MapOrders._BuySideOrderID = item.BuySideOrderID;
                    objclsMapOrdersPS._MapOrders._SellAccountID = item.SellAccountID;
                    objclsMapOrdersPS._MapOrders._SellSideOrderID = item.SellSideOrderID;
                    objclsMapOrdersPS._MapOrders._BuyFillID = item.BuyFillID;
                    objclsMapOrdersPS._MapOrders._SellFillID = item.SellFillID;
                    objclsMapOrdersPS._MapOrders._FilledQty = item.FilledQty;
                    objclsMapOrdersPS._MapOrders._LastUpdateTime = item.LastUpdateTime;
                    objclsMapOrdersPS._MapOrders._Price = Convert.ToDecimal(item.Price.ToString("0.00"));                    
                    objclsMapOrdersPS._MapOrders._Symbol = item.Symbol;

                    clsDataManager.INSTANCE.HandleSocketData(objclsMapOrdersPS);
                }

                //Logging.FileHandling.WriteAllLog("clsMapOrderManager : Exit GetMapOrderInfo()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsMapOrderManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetMapOrderInfo()");
            }

            return flag;
        }
    }
}
