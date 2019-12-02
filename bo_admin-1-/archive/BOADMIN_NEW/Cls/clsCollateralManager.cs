using System;
using System.Collections.Generic;
using System.Linq;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;
using clsInterface4OME;

namespace BOADMIN_NEW.Cls
{
    /// <summary>
    /// Collateral manager class
    /// </summary>
    public class clsCollateralManager : IclsManager
    {
        static clsCollateralManager _clsCollateralManager = null;
        public DS4BrokerCollateralInfo _DS4BrokerCollateralInfo = new DS4BrokerCollateralInfo();
        private clsCollateralManager()
        {
        }
        #region PROPERTY
        public static clsCollateralManager INSTANCE
        {
            get { return _clsCollateralManager ?? (_clsCollateralManager = new clsCollateralManager()); }
        }
        #endregion PROPERTY

        public override void AddSetting(IProtocolStruct PS)
        {
            
        }

        public void FillDataToCollateralTransDataSet(List<clsCollateralTransInfo> lstCollateralTransInfo)
        {
            foreach (clsCollateralTransInfo item in lstCollateralTransInfo)
            {
                DoHandleBrokerCollateralTransTable(item);
            }
        }

        /// <summary>
        /// Handles collateral type info
        /// </summary>
        /// <param name="collateralTypes"></param>
        public void DoHandleCollateralTypesTable(clsCollateralTypes collateralTypes)
        {
            try
            {
                
                DS4BrokerCollateralInfo.dtCollateralTypeMasterRow collateralTypeRow = _DS4BrokerCollateralInfo.dtCollateralTypeMaster.FindByCollateralTypeID(collateralTypes.CollateralTypeID);
                if (collateralTypeRow == null)
                {
                    collateralTypeRow = _DS4BrokerCollateralInfo.dtCollateralTypeMaster.NewRow() as DS4BrokerCollateralInfo.dtCollateralTypeMasterRow;
                    if (collateralTypeRow != null)
                    {
                        collateralTypeRow.CollateralType = collateralTypes.CollateralType;
                        collateralTypeRow.CollateralTypeID = collateralTypes.CollateralTypeID;
                        _DS4BrokerCollateralInfo.dtCollateralTypeMaster.AdddtCollateralTypeMasterRow(collateralTypeRow);
                    }
                }
                else
                {
                    collateralTypeRow.CollateralType = collateralTypes.CollateralType;
                    collateralTypeRow.CollateralTypeID = collateralTypes.CollateralTypeID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCollateralManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleCollateralTypesTable()");
            }
        }

        /// <summary>
        /// Handles broker collateral transaction info
        /// </summary>
        /// <param name="brokerCollateralTrans"></param>
        public void DoHandleBrokerCollateralTransTable(clsCollateralTransInfo brokerCollateralTrans)
        {
            try
            {
                DS4BrokerCollateralInfo.dtLastCollateralTransactionRow brokerCollateralTransRow = null;

                brokerCollateralTransRow = _DS4BrokerCollateralInfo.dtLastCollateralTransaction.FirstOrDefault(i => i.FK_AccountGroupId == brokerCollateralTrans.AccountGroupId && i.FK_CollateralTypeId == brokerCollateralTrans.CollateralTypeId) as DS4BrokerCollateralInfo.dtLastCollateralTransactionRow;

                if (brokerCollateralTransRow == null)
                {
                    brokerCollateralTransRow = _DS4BrokerCollateralInfo.dtLastCollateralTransaction.NewRow() as DS4BrokerCollateralInfo.dtLastCollateralTransactionRow;
                    if (brokerCollateralTransRow != null)
                    {
                        brokerCollateralTransRow.FK_AccountGroupId = brokerCollateralTrans.AccountGroupId;
                        brokerCollateralTransRow.FK_CollateralTypeId = brokerCollateralTrans.CollateralTypeId;
                        brokerCollateralTransRow.CollateralType = brokerCollateralTrans.CollateralType;
                        brokerCollateralTransRow.TotalAmount = Convert.ToDecimal(brokerCollateralTrans.TotalAmount.ToString("0.00"));
                        if (brokerCollateralTrans.TransactionDate == string.Empty)
                            brokerCollateralTransRow.TransactionDate = DateTime.Today.ToShortDateString();
                        else
                            brokerCollateralTransRow.TransactionDate = brokerCollateralTrans.TransactionDate;
                        brokerCollateralTransRow.TransactionType = brokerCollateralTrans.TransactionType;
                        brokerCollateralTransRow.Amount = Convert.ToDecimal(brokerCollateralTrans.Amount.ToString("0.00"));
                        _DS4BrokerCollateralInfo.dtLastCollateralTransaction.AdddtLastCollateralTransactionRow(brokerCollateralTransRow);
                    }
                }
                else
                {
                    brokerCollateralTransRow.FK_AccountGroupId = brokerCollateralTrans.AccountGroupId;
                    brokerCollateralTransRow.FK_CollateralTypeId = brokerCollateralTrans.CollateralTypeId;
                    brokerCollateralTransRow.CollateralType = brokerCollateralTrans.CollateralType;
                    brokerCollateralTransRow.TotalAmount = Convert.ToDecimal(brokerCollateralTrans.TotalAmount.ToString("0.00"));
                    brokerCollateralTransRow.TransactionDate = brokerCollateralTrans.TransactionDate == string.Empty ? DateTime.Today.ToShortDateString() : brokerCollateralTrans.TransactionDate;
                    brokerCollateralTransRow.TransactionType = brokerCollateralTrans.TransactionType;
                    brokerCollateralTransRow.Amount = Convert.ToDecimal(brokerCollateralTrans.Amount.ToString("0.00"));

                }
                if (brokerCollateralTrans.IsNewCollateralTrans)
                {
                    DS4BrokerCollateralInfo.dtBrokerCollateralInfoRow brokerCollateralInfoRow = _DS4BrokerCollateralInfo.dtBrokerCollateralInfo.FindByAccountGroupID(brokerCollateralTrans.AccountGroupId);
                    if (brokerCollateralTrans.TransactionType == "Deposit")
                        brokerCollateralInfoRow.TotalCollateral =Convert.ToDecimal((brokerCollateralInfoRow.TotalCollateral + brokerCollateralTrans.Amount).ToString("0.00"));
                    else
                        brokerCollateralInfoRow.TotalCollateral = Convert.ToDecimal((brokerCollateralInfoRow.TotalCollateral - brokerCollateralTrans.Amount).ToString("0.00"));
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCollateralManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBrokerCollateralTransTable()");
            }
            _DS4BrokerCollateralInfo.dtLastCollateralTransaction.AcceptChanges();
        }

        /// <summary>
        /// Handles broker collateral information
        /// </summary>
        /// <param name="brokerCollateralInfo"></param>
        public void DoHandleBrokerCollateralTable(clsCollateralInfo brokerCollateralInfo)
        {
            try
            {
                if (clsBrokerManager.INSTANCE.GetBrokerTypeId(clsUtility.GetStr(brokerCollateralInfo.BrokerType.Trim())) > Cls.clsGlobal.BrokerID
                    && Cls.clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(brokerCollateralInfo.AccountGroupID))//brokerCollateralInfo.BrokerTypeID > clsGlobal.BrokerID)  //Added by vijay on 30 April
                {
                    DS4BrokerCollateralInfo.dtBrokerCollateralInfoRow brokerCollateralInfoRow = _DS4BrokerCollateralInfo.dtBrokerCollateralInfo.FindByAccountGroupID(brokerCollateralInfo.AccountGroupID);
                    if (brokerCollateralInfoRow == null)
                    {
                        brokerCollateralInfoRow = _DS4BrokerCollateralInfo.dtBrokerCollateralInfo.NewRow() as DS4BrokerCollateralInfo.dtBrokerCollateralInfoRow;
                        if (brokerCollateralInfoRow != null)
                        {
                            brokerCollateralInfoRow.AccountGroupID = brokerCollateralInfo.AccountGroupID;
                            brokerCollateralInfoRow.AccountGroupName = brokerCollateralInfo.AccountGroupName;
                            brokerCollateralInfoRow.BrokerType = brokerCollateralInfo.BrokerType;
                            brokerCollateralInfoRow.CollateralforTrading = Convert.ToDecimal(brokerCollateralInfo.CollateralforTrading.ToString("0.00"));
                            brokerCollateralInfoRow.FK_BrokerTypeID = brokerCollateralInfo.BrokerTypeID;
                            brokerCollateralInfoRow.IsEnable = brokerCollateralInfo.IsEnable;
                            decimal d = Convert.ToDecimal(brokerCollateralInfo.Leverage.Trim());
                            brokerCollateralInfoRow.Leverage = d.ToString("0.00");
                            brokerCollateralInfoRow.Owner = brokerCollateralInfo.Owner;
                            brokerCollateralInfoRow.ParentAccountGroupID = brokerCollateralInfo.ParentAccountGroupID;
                            brokerCollateralInfoRow.ParentOwner = brokerCollateralInfo.ParentOwner;
                            brokerCollateralInfoRow.PayInShortage = Convert.ToDecimal(brokerCollateralInfo.PayInShortage.ToString("0.00"));
                            brokerCollateralInfoRow.PayOutShortage = Convert.ToDecimal(brokerCollateralInfo.PayOutShortage.ToString("0.00"));
                            brokerCollateralInfoRow.TotalCollateral = Convert.ToDecimal(brokerCollateralInfo.TotalCollateral.ToString("0.00"));
                            brokerCollateralInfoRow.Unallocated = Convert.ToDecimal(brokerCollateralInfo.Unallocated.ToString("0.00"));
                            brokerCollateralInfoRow.Utilized = Convert.ToDecimal(brokerCollateralInfo.Utilized.ToString("0.00"));
                            _DS4BrokerCollateralInfo.dtBrokerCollateralInfo.AdddtBrokerCollateralInfoRow(brokerCollateralInfoRow);
                        }
                    }
                    else
                    {

                        brokerCollateralInfoRow.AccountGroupID = brokerCollateralInfo.AccountGroupID;
                        brokerCollateralInfoRow.AccountGroupName = brokerCollateralInfo.AccountGroupName;
                        brokerCollateralInfoRow.BrokerType = brokerCollateralInfo.BrokerType;
                        brokerCollateralInfoRow.CollateralforTrading = Convert.ToDecimal(brokerCollateralInfo.CollateralforTrading.ToString("0.00")); ;
                        brokerCollateralInfoRow.FK_BrokerTypeID = brokerCollateralInfo.BrokerTypeID;
                        brokerCollateralInfoRow.IsEnable = brokerCollateralInfo.IsEnable;
                        decimal d = Convert.ToDecimal(brokerCollateralInfo.Leverage.Trim());
                        brokerCollateralInfoRow.Leverage = d.ToString("0.00");
                        brokerCollateralInfoRow.Owner = brokerCollateralInfo.Owner;
                        brokerCollateralInfoRow.ParentAccountGroupID = brokerCollateralInfo.ParentAccountGroupID;
                        brokerCollateralInfoRow.ParentOwner = brokerCollateralInfo.ParentOwner;
                        brokerCollateralInfoRow.PayInShortage = Convert.ToDecimal(brokerCollateralInfo.PayInShortage.ToString("0.00"));
                        brokerCollateralInfoRow.PayOutShortage = Convert.ToDecimal(brokerCollateralInfo.PayOutShortage.ToString("0.00"));
                        brokerCollateralInfoRow.TotalCollateral = Convert.ToDecimal(brokerCollateralInfo.TotalCollateral.ToString("0.00"));
                        brokerCollateralInfoRow.Unallocated = Convert.ToDecimal(brokerCollateralInfo.Unallocated.ToString("0.00"));
                        brokerCollateralInfoRow.Utilized = Convert.ToDecimal(brokerCollateralInfo.Utilized.ToString("0.00"));
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCollateralManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBrokerCollateralTable()");
            }
            _DS4BrokerCollateralInfo.dtBrokerCollateralInfo.AcceptChanges();
        }

        public override void RemoveSetting(string DataKey)
        {
            
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        internal DS4BrokerCollateralInfo.dtLastCollateralTransactionRow[] GetSummeryCollateral(int accountGroupId)
        {
            DS4BrokerCollateralInfo.dtLastCollateralTransactionRow[] lastCollateralTransRows = null;
            if (accountGroupId > 0)
            {
                lastCollateralTransRows = (DS4BrokerCollateralInfo.dtLastCollateralTransactionRow[])_DS4BrokerCollateralInfo.dtLastCollateralTransaction.Select("AccountGroupID = " + accountGroupId);

            }
            return lastCollateralTransRows;
        }

        /// <summary>
        /// Gets groupname by group id
        /// </summary>
        /// <param name="accountGroupId"></param>
        /// <returns></returns>
        internal string GetGroupName(int accountGroupId)
        {
            if (accountGroupId > 0)
            {
                DS4BrokerCollateralInfo.dtBrokerCollateralInfoRow[] brokerCollateralRow = (DS4BrokerCollateralInfo.dtBrokerCollateralInfoRow[])_DS4BrokerCollateralInfo.dtBrokerCollateralInfo.Select("AccountGroupID = " + accountGroupId);
                if (!brokerCollateralRow.Any())
                    return string.Empty;
                return brokerCollateralRow[0].AccountGroupName;
            }
            return string.Empty;
        }

        public int GetCollateralTypeID(string collateralName)
        {
            return collateralName == string.Empty ? 0 : _DS4BrokerCollateralInfo.dtCollateralTypeMaster.FirstOrDefault(a => a.CollateralType == collateralName).CollateralTypeID;
        }
    }
}
