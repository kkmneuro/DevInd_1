using System;
using System.Collections.Generic;
using System.Linq;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    /// <summary>
    /// Broker Manager
    /// </summary>
    public class clsBrokersManagerHandler : IclsManager
    {
        #region "   MEMBERS   "

        public List<BrokerSymbol> _lstTotalSymbols = new List<BrokerSymbol>();
        public List<string> _lstFeeType = new List<string>();
        public List<string> _lstTaxType = new List<string>();
        bool _isGloablContentLoad = false;
        static clsBrokersManagerHandler _clsBrokerManager = null;
        public DS4Brokers _DS4Brokers = new DS4Brokers();
        public event Action UpdateBrokerList = delegate { };
        public List<int> _lstParentIds = new List<int>();
        public List<string> _lstParentCompanyNames = new List<string>();
        public List<string> _lstParentNames = new List<string>();
        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsBrokersManagerHandler INSTANCE
        {
            get { return _clsBrokerManager ?? (_clsBrokerManager = new clsBrokersManagerHandler()); }
        }

        private clsBrokersManagerHandler()
        {
            //Recursive(clsGlobal.BrokerNameId);
        }

        public void FillBrokersDataSet(List<clsBroker> lstBroker)
        {
            foreach (clsBroker item in lstBroker)
            {
                DoHandleBrokersTable(item);
            }
        }

        #endregion "    PROPERTY     "

        /// <summary>
        /// Handles broker info
        /// </summary>
        /// <param name="brokers"></param>
        public void DoHandleBrokersTable(clsBroker brokers)
        {
            try
            {
                if (!_isGloablContentLoad)//&& brokers.Name== "System"
                {
                    _lstTotalSymbols = brokers.LstTotalSymbols.ToList();
                    _lstFeeType = brokers.LstFeeType.ToList();
                    _lstTaxType = brokers.LstTaxType.ToList();
                    _isGloablContentLoad = true;
                }

                DS4Brokers.dtBrokersRow brokersRow = _DS4Brokers.dtBrokers.FindByBrokersID(brokers.BrokerID);
                if (clsBrokerManager.INSTANCE.GetBrokerTypeId(clsUtility.GetStr(brokers.BrokerType.Trim())) > Cls.clsGlobal.BrokerID
                    && (brokers.BrokerParent==clsGlobal.BrokerNameId ||_lstParentIds.Contains(brokers.BrokerParent)))  //added by vijay on 22 April
                {
                    if (brokersRow == null)
                    {
                        brokersRow = _DS4Brokers.dtBrokers.NewRow() as DS4Brokers.dtBrokersRow;

                        if (brokersRow != null)
                        {
                            brokersRow.BrokersID = brokers.BrokerID;
                            brokersRow.Name = clsUtility.GetStr(brokers.Name);
                            brokersRow.Owner = clsUtility.GetStr(brokers.Owner);
                            //brokersRow.BrokerName = brokers.BrokerName;
                            //brokersRow.CompanyName = brokers.CompanyName;
                            //decimal d = Convert.ToDecimal(brokers.Leverage);
                            //brokersRow.Leverage = d.ToString("0.00");//clsUtility.GetStr(brokers.Leverage);
                            brokersRow.Leverage = brokers.Leverage.Trim();
                            brokersRow.Enable = brokers.IsEnable;
                            brokersRow.BrokerType = brokers.BrokerType;
                            brokersRow.Address = clsUtility.GetStr(brokers.Address);
                            brokersRow.Zone = clsUtility.GetStr(brokers.City);
                            brokersRow.District = clsUtility.GetStr(brokers.State);
                            brokersRow.Phone1 = clsUtility.GetStr(brokers.Phone1);
                            brokersRow.Phone2 = clsUtility.GetStr(brokers.Phone2);
                            brokersRow.Fax = clsUtility.GetStr(brokers.Fax);
                            brokersRow.Email = clsUtility.GetStr(brokers.EMail);
                            brokersRow.Margin_Call_Level1 = brokers.MarginCallLevel1;
                            brokersRow.Margin_Call_Level2 = brokers.MarginCallLevel2;
                            brokersRow.Margin_Call_Level3 = brokers.MarginCallLevel3;
                            brokersRow.News = clsUtility.GetStr(brokers.News);
                            brokersRow.MaximumOrders = clsUtility.GetStr(brokers.MaximumOrders);
                            brokersRow.MaximumSymbols = clsUtility.GetStr(brokers.Maximumsymbols);
                            brokersRow.ParentBrokerID = clsAccountManager.INSTANCE.GetBrokerCompanyName(clsUtility.GetInt(brokers.BrokerParent));//.GetGroupName(clsUtility.GetInt(brokers.BrokerParent)); //clsUtility.GetInt(brokers.BrokerParent).ToString(); //GetBrokerName(clsUtility.GetInt(brokers.BrokerParent));
                            brokersRow.Roles = brokers.Roles;
                            brokersRow.RoleId = brokers.RoleId;
                            brokersRow.RoleName = brokers.RoleName;
                            brokersRow.LoginId = brokers.LoginID;
                            _DS4Brokers.dtBrokers.AdddtBrokersRow(brokersRow);
                            
                        }
                        HandleChargesInfo(brokers);
                        DoHandleSymbolInfo(brokers, false);
                        HandleForBrokerParnets(brokers);
                    }
                    else
                    {

                        brokersRow.BrokersID = brokers.BrokerID;
                        brokersRow.Name = clsUtility.GetStr(brokers.Name);
                        brokersRow.Owner = clsUtility.GetStr(brokers.Owner);
                        //brokersRow.BrokerName = brokers.BrokerName;
                        //brokersRow.CompanyName = brokers.CompanyName;
                        //decimal d = Convert.ToDecimal(brokers.Leverage);
                        //brokersRow.Leverage = d.ToString("0.00");//clsUtility.GetStr(brokers.Leverage);
                        brokersRow.Leverage = brokers.Leverage.Trim();
                        brokersRow.Enable = brokers.IsEnable;
                        brokersRow.BrokerType = brokers.BrokerType;
                        brokersRow.Address = clsUtility.GetStr(brokers.Address);
                        brokersRow.Zone = clsUtility.GetStr(brokers.City);
                        brokersRow.District = clsUtility.GetStr(brokers.State);
                        brokersRow.Phone1 = clsUtility.GetStr(brokers.Phone1);
                        brokersRow.Phone2 = clsUtility.GetStr(brokers.Phone2);
                        brokersRow.Fax = clsUtility.GetStr(brokers.Fax);
                        brokersRow.Email = clsUtility.GetStr(brokers.EMail);
                        brokersRow.Margin_Call_Level1 = brokers.MarginCallLevel1;
                        brokersRow.Margin_Call_Level2 = brokers.MarginCallLevel2;
                        brokersRow.Margin_Call_Level3 = brokers.MarginCallLevel3;
                        brokersRow.News = clsUtility.GetStr(brokers.News);
                        brokersRow.MaximumOrders = clsUtility.GetStr(brokers.MaximumOrders);
                        brokersRow.MaximumSymbols = clsUtility.GetStr(brokers.Maximumsymbols);
                        brokersRow.ParentBrokerID = clsAccountManager.INSTANCE.GetBrokerCompanyName(clsUtility.GetInt(brokers.BrokerParent));//.GetGroupName(clsUtility.GetInt(brokers.BrokerParent));//GetBrokerName(clsUtility.GetInt(brokers.BrokerParent));
                        brokersRow.Roles = brokers.Roles;
                        brokersRow.RoleId = brokers.RoleId;
                        brokersRow.RoleName = brokers.RoleName;
                        brokersRow.LoginId = brokers.LoginID;
                        HandleChargesInfo(brokers);
                        DoHandleSymbolInfo(brokers, true);
                        HandleForBrokerParnets(brokers);
                    }
                    _DS4Brokers.dtBrokers.AcceptChanges();
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokersManagerHandler => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //    "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBrokersTable()");
            }
            UpdateBrokerList();
        }

        /// <summary>
        /// Handles broker parent info
        /// </summary>
        /// <param name="brokers"></param>
        private void HandleForBrokerParnets(clsBroker brokers)
        {
            try
            {
                DS4Brokers.dtBrokerParentRow brokerParentRow = _DS4Brokers.dtBrokerParent.FindByBrokersID(brokers.BrokerID);
                if (brokerParentRow == null)
                {
                    brokerParentRow = _DS4Brokers.dtBrokerParent.NewRow() as DS4Brokers.dtBrokerParentRow;

                    if (brokerParentRow != null)
                    {
                        brokerParentRow.BrokersID = brokers.BrokerID;
                        brokerParentRow.BrokerName = brokers.Name;
                        brokerParentRow.BrokerType = brokers.BrokerType;
                        brokerParentRow.BrokerTypeID = clsBrokerManager.INSTANCE.GetBrokerTypeId(brokers.BrokerType);

                        _DS4Brokers.dtBrokerParent.AdddtBrokerParentRow(brokerParentRow);
                    }
                }
                else
                {
                    brokerParentRow.BrokersID = brokers.BrokerID;
                    brokerParentRow.BrokerName = brokers.Name;
                    brokerParentRow.BrokerType = brokers.BrokerType;
                    brokerParentRow.BrokerTypeID = clsBrokerManager.INSTANCE.GetBrokerTypeId(brokers.BrokerType);
                }
                _DS4Brokers.dtBrokerParent.AcceptChanges();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokersManagerHandler => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                 //   "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleForBrokerParnets()");
            }
        }

        /// <summary>
        /// Handles charges info
        /// </summary>
        /// <param name="brokers"></param>
        private void HandleChargesInfo(clsBroker brokers)
        {
            try
            {
                lock (_DS4Brokers)
                {
                    foreach (BOADMIN_NEW.BOEngineServiceTCP.charges item in brokers.LstCharges)
                    {
                        DS4Brokers.dtChargesRow chargesRow = _DS4Brokers.dtCharges.FindBySymbolChargesID(item.ChargesID);
                        if (chargesRow == null)
                        {
                            chargesRow = _DS4Brokers.dtCharges.NewRow() as DS4Brokers.dtChargesRow;

                            if (chargesRow != null)
                            {
                                chargesRow.SymbolChargesID = clsUtility.GetInt(item.ChargesID);
                                chargesRow.BrokersGroupID = clsUtility.GetInt(item.BrokersGroupID);
                                chargesRow.Symbol_ID = clsUtility.GetInt(item.SymbolID);
                                chargesRow.Symbol = clsUtility.GetStr(item.Symbol);
                                chargesRow.FeeType = clsUtility.GetStr(item.Fee);
                                chargesRow.FeeValue = item.FeeValue;//Convert.ToDecimal(item.FeeValue.ToString("0.00"));
                                chargesRow.TaxType = clsUtility.GetStr(item.Tax);
                                chargesRow.TaxValue = item.TaxValue;//Convert.ToDouble(item.TaxValue.ToString("0.00"));

                                _DS4Brokers.dtCharges.AdddtChargesRow(chargesRow);
                            }
                        }
                        else
                        {
                            chargesRow.SymbolChargesID = clsUtility.GetInt(item.ChargesID);
                            chargesRow.BrokersGroupID = clsUtility.GetInt(item.BrokersGroupID);
                            chargesRow.Symbol_ID = clsUtility.GetInt(item.SymbolID);
                            chargesRow.Symbol = clsUtility.GetStr(item.Symbol);
                            chargesRow.FeeType = clsUtility.GetStr(item.Fee);
                            chargesRow.FeeValue = item.FeeValue;
                            chargesRow.TaxType = clsUtility.GetStr(item.Tax);
                            chargesRow.TaxValue = item.TaxValue;
                        }
                        _DS4Brokers.dtCharges.AcceptChanges();
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokersManagerHandler => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleChargesInfo()");
            }
        }

        /// <summary>
        /// Handles symbol info
        /// </summary>
        /// <param name="brokers"></param>
        /// <param name="isRowExist"></param>
        private void DoHandleSymbolInfo(clsBroker brokers, bool isRowExist)
        {
            try
            {
                if (!isRowExist)
                {
                    foreach (BrokerSymbol item in brokers.LstSymbol)
                    {
                        _DS4Brokers.dtSymbol.AdddtSymbolRow(brokers.BrokerID, false, item.SymbolID, item.SymbolName,
                            item.BidSpread, item.AskSpread, item.Spread, item.IsVariable, item.BidSpread, item.AskSpread);
                    }
                }
                else
                {
                    DS4Brokers.dtSymbolRow[] row = (DS4Brokers.dtSymbolRow[])_DS4Brokers.dtSymbol.Select("FK_BrokersID = " + brokers.BrokerID.ToString() + " ");
                    if (brokers.LstSymbol.Count() == 0)
                    {
                        foreach (DS4Brokers.dtSymbolRow rows in row)
                        {
                            _DS4Brokers.dtSymbol.RemovedtSymbolRow(rows);
                        }
                        return;
                    }

                    if (row.Count() == 0)
                    {
                        foreach (BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol symbol in brokers.LstSymbol)
                        {
                            _DS4Brokers.dtSymbol.AdddtSymbolRow(brokers.BrokerID, false, symbol.SymbolID, symbol.SymbolName,
                                symbol.BidSpread, symbol.AskSpread, symbol.Spread, symbol.IsVariable, symbol.BidSpread, symbol.AskSpread);
                        }
                        return;
                    }

                    List<int> gridSymbols = new List<int>();
                    foreach (DS4Brokers.dtSymbolRow item2 in row)
                    {
                        gridSymbols.Add(item2.Symbol_ID);
                    }

                    List<int> brokersSymbolsId = brokers.LstSymbol.Select(brokerSymbol => brokerSymbol.SymbolID).ToList();

                    foreach (BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol item in brokers.LstSymbol)
                    {
                        foreach (DS4Brokers.dtSymbolRow item2 in row)
                        {
                            if (item.SymbolID == item2.Symbol_ID)
                            {
                                item2.Symbol = item.SymbolName;
                                item2.BidSpread = item.BidSpread;
                                item2.AskSpread = item.AskSpread;
                                item2.Spread = item.Spread;
                                item2.IsVariable = item.IsVariable;
                                item2.PrevBidSpread = item.BidSpread;
                                item2.PrevAskSpread = item.AskSpread;
                            }
                            else if (!gridSymbols.Contains(item.SymbolID))
                            {
                                _DS4Brokers.dtSymbol.AdddtSymbolRow(brokers.BrokerID, false, item.SymbolID, item.SymbolName,
                                    item.BidSpread, item.AskSpread, item.Spread, item.IsVariable, item.BidSpread, item.AskSpread);
                            }
                            else if (!brokersSymbolsId.Contains(item2.Symbol_ID))
                            {
                                _DS4Brokers.dtSymbol.RemovedtSymbolRow(item2);
                            }
                            _DS4Brokers.dtSymbol.AcceptChanges();
                        }
                    }
                }
                _DS4Brokers.dtSymbol.AcceptChanges();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokersManagerHandler => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleSymbolInfo()");
            }
        }

        public override void AddSetting(ProtocolStructs.IProtocolStruct PS)
        {
            //DoHandleBrokersTable((PS as BrokersPS)._Brokers);
        }

        public override void RemoveSetting(string DataKey)
        {
            int chargesId = -999;
            try
            {
                chargesId = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4Brokers.dtChargesRow Row = _DS4Brokers.dtCharges.FindBySymbolChargesID(chargesId);
            int brokerId = Row.BrokersGroupID;
            lock (_DS4Brokers.dtCharges)
            {
                _DS4Brokers.dtCharges.RemovedtChargesRow(Row);
            }
            OnChargesRowRemove(brokerId, chargesId);
            //int BrokersID = -999;
            //try
            //{
            //    BrokersID = Convert.ToInt32(DataKey);
            //}
            //catch (Exception)
            //{
            //    FileHandling.WriteToLogEx(ex);
            //    return;
            //}
            //DS4Brokers.dtBrokersRow Row = _DS4Brokers.dtBrokers.FindByBrokersID(BrokersID);
            //lock (_DS4Brokers.dtBrokers)
            //{
            //    _DS4Brokers.dtBrokers.RemovedtBrokersRow(Row);
            //}
        }

        public event Action<int, int> OnChargesRowRemove;

        public override void ServerRequestResponse(ProtocolStructs.DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        public DS4Brokers.dtSymbolRow[] GetSymbolsRow(int brokersGroupId)
        {
            DS4Brokers.dtSymbolRow[] rows = null;

            rows = (DS4Brokers.dtSymbolRow[])_DS4Brokers.dtSymbol.Select("FK_BrokersID = " + brokersGroupId.ToString() + " ");

            return rows;

        }

        public DS4Brokers.dtChargesRow[] GetChargesRow(int brokersGroupId)
        {
            DS4Brokers.dtChargesRow[] rows = null;

            rows = (DS4Brokers.dtChargesRow[])_DS4Brokers.dtCharges.Select("BrokersGroupID = " + brokersGroupId.ToString() + " ");

            return rows;

        }

        public List<string> GetParentBrokersType(string brokerType)
        {
            List<string> lstParentBrokers = new List<string>();
            try
            {
                //Logging.FileHandling.WriteAllLog("clsBrokersManagerHandler : Enter GetParentBrokersType()");
                int id = clsBrokerManager.INSTANCE.GetBrokerTypeId(brokerType);
                DS4Brokers.dtBrokerParentRow[] rows = (DS4Brokers.dtBrokerParentRow[])_DS4Brokers.dtBrokerParent.Select("BrokerTypeID < " + id);
                lstParentBrokers.AddRange(rows.Select(item => item.BrokerName));
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBrokersManagerHandler =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleSymbolInfo()");
            }
            return lstParentBrokers;
        }

        public int GetBrokerId(string brokerName)
        {
            if (brokerName == "")
                return 0;

            DS4Brokers.dtBrokerParentRow[] rows = (DS4Brokers.dtBrokerParentRow[])_DS4Brokers.dtBrokerParent.Select("BrokerName = '" + brokerName + "' ");

            if (rows.Count() != 0 && rows[0] != null)
            {
                return rows[0].BrokersID;
            }
            else
            {
                return 1;
            }
        }

        public string GetBrokerName(int brokerId)
        {
            string brokerName = string.Empty;

            if (brokerId == 0)
                brokerName = "";
            else
            {
                DS4Brokers.dtBrokerParentRow[] rows = (DS4Brokers.dtBrokerParentRow[])_DS4Brokers.dtBrokerParent.Select("BrokersID = " + brokerId);
                if (rows.Count() != 0 && rows[0] != null)
                {
                    brokerName = rows[0].BrokerName;
                }
            }
            return brokerName;
        }

        List<string> lstBrokersName = new List<string>();

        public List<string> GetAllBrokersName()
        {
            foreach (DS4Brokers.dtBrokerParentRow item in _DS4Brokers.dtBrokerParent.Rows)
            {
                if (!lstBrokersName.Contains(item.BrokerName))
                {
                    lstBrokersName.Add(item.BrokerName);
                }
            }

            return lstBrokersName;
        }

        public DS4Brokers.dtBrokersRow GetBrokerData(string brokerName)
        {
            if (brokerName == "")
                return null;
            return _DS4Brokers.dtBrokers.FindByBrokersID(clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(brokerName));//GetBrokerId(brokerName));
        }

        public DS4Brokers.dtBrokersRow[] GetBrokersDataByBrokerType(string brokerTypeName)
        {
            if (brokerTypeName == "")
                return null;
            DS4Brokers.dtBrokersRow[] rows = (DS4Brokers.dtBrokersRow[])_DS4Brokers.dtBrokers.Select("BrokerType = '" + brokerTypeName + "'");
            if (!rows.Any())
                return null;

            return rows;
        }

        public DS4Brokers.dtBrokersRow GetBrokersDataByBrokerCompanyName(string companyName)
        {
            if (companyName == "")
                return null;
            DS4Brokers.dtBrokersRow[] rows = (DS4Brokers.dtBrokersRow[])_DS4Brokers.dtBrokers.Select("Owner = '" + companyName + "'");
            if (!rows.Any())
                return null;

            return rows[0];
        }

        public void Recursive(int brokerId)
        {
            if(!clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select(a=>a.ParentAccountGroupID==brokerId).Any())
                return;
            DS4AccountGroup.dtAccountGroupsRow[] rows = (DS4AccountGroup.dtAccountGroupsRow[])
                                                        clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups
                                                            .Select("ParentAccountGroupID=" + brokerId);
            _lstParentIds.AddRange(
                ((rows).Select(a => a.AccountGroupID)).ToArray());
            _lstParentCompanyNames.AddRange(((rows).Select(a => a.Owner)).ToArray());
            _lstParentNames.AddRange((rows).Select(a => a.AccountGroupName).ToArray());
            foreach (DS4AccountGroup.dtAccountGroupsRow row in rows)
            {
                Recursive(row.AccountGroupID);
            }
        }
        List<int> lstChildIDs = new List<int>();
        public void GetChildIDs(int brokerId)
        {
            if (!clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups.Select(a => a.ParentAccountGroupID == brokerId).Any())
                return;
            DS4AccountGroup.dtAccountGroupsRow[] rows = (DS4AccountGroup.dtAccountGroupsRow[])
                                                        clsAccountManager.INSTANCE._DS4AccountGroups.dtAccountGroups
                                                            .Select("ParentAccountGroupID=" + brokerId);
            lstChildIDs.AddRange(
                ((rows).Select(a => a.AccountGroupID)).ToArray());
        }

        //public void DisableAllChildBrokers(int brokerId)
        //{
        //    GetChildIDs(brokerId);
        //    foreach (int item in lstChildIDs)
        //    {
        //        DisableChilds(_DS4Brokers.dtBrokers.FindByBrokersID(item));
        //    }
        //}

        //public void DisableChilds(DS4Brokers.dtBrokersRow brokerrow)
        //{
        //    clsBroker objclsBroker = new clsBroker();
        //    List<BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol> lstSymbols = new List<BOADMIN_NEW.BOEngineServiceTCP.BrokerSymbol>();
        //    List<BOADMIN_NEW.BOEngineServiceTCP.charges> lstCharges = new List<BOADMIN_NEW.BOEngineServiceTCP.charges>();

        //    objclsBroker.IsEnable = brokerrow.Enable;
        //    objclsBroker.Name = brokerrow.Name;
        //    objclsBroker.Owner = brokerrow.Owner;
        //    objclsBroker.Leverage = brokerrow.Leverage;
        //    objclsBroker.BrokerType = brokerrow.BrokerType;
        //    objclsBroker.Address = brokerrow.Address;
        //    objclsBroker.City = brokerrow.Zone;
        //    objclsBroker.State = brokerrow.District;
        //    objclsBroker.Phone1 = brokerrow.Phone1;
        //    objclsBroker.Phone2 = brokerrow.Phone2;
        //    objclsBroker.Fax = brokerrow.Fax;
        //    objclsBroker.EMail = brokerrow.Email;
        //    objclsBroker.MarginCallLevel1 =brokerrow.Margin_Call_Level1 ;
        //    objclsBroker.MarginCallLevel2 = brokerrow.Margin_Call_Level2;
        //    objclsBroker.MarginCallLevel3 = brokerrow.Margin_Call_Level3;
        //    objclsBroker.News = brokerrow.News;
        //    objclsBroker.MaximumOrders = brokerrow.MaximumOrders;
        //    objclsBroker.Maximumsymbols = brokerrow.MaximumSymbols;
        //    objclsBroker.BrokerParent =Convert.ToInt32(brokerrow.ParentBrokerID);
        //    objclsBroker.RoleId = brokerrow.RoleId;
        //    objclsBroker.LoginID = brokerrow.LoginId;
        //    objclsBroker.RoleName = brokerrow.RoleName;
        //    objclsBroker.Roles = brokerrow.Roles;

        //    foreach (DS4Brokers.dtSymbolRow item in GetSymbolsRow(brokerrow.BrokersID))
        //    {
        //        BOEngineServiceTCP.BrokerSymbol objBrokerSymbol = new BOEngineServiceTCP.BrokerSymbol();
        //        objBrokerSymbol.SymbolID = item.Symbol_ID;
        //        objBrokerSymbol.SymbolName = item.Symbol;
        //        objBrokerSymbol.BidSpread = item.BidSpread;
        //        objBrokerSymbol.AskSpread = item.AskSpread;
        //        objBrokerSymbol.Spread = item.Spread;
        //        objBrokerSymbol.IsVariable = item.IsVariable;
        //        lstSymbols.Add(objBrokerSymbol);
        //    }
        //    objclsBroker.LstSymbol = lstSymbols.ToArray();

        //    foreach (DS4Brokers.dtChargesRow item in GetChargesRow(brokerrow.BrokersID))
        //    {
        //        BOEngineServiceTCP.charges objcharges = new BOEngineServiceTCP.charges();

        //        objcharges.ChargesID = objcharges.ChargesID;
        //        objcharges.BrokersGroupID = brokerrow.BrokersID;
        //        objcharges.SymbolID = objcharges.SymbolID;
        //        objcharges.Symbol = objcharges.Symbol;
        //        objcharges.Fee = objcharges.Fee;
        //        objcharges.FeeValue = objcharges.FeeValue;
        //        objcharges.Tax = objcharges.Tax;
        //        objcharges.TaxValue = objcharges.TaxValue;
        //        lstCharges.Add(objcharges);
        //    }
        //    objclsBroker.LstCharges = lstCharges.ToArray();


        //}


    }
}
