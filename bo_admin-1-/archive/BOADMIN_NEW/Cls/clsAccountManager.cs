using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using ProtocolStructs;
using clsInterface4OME.DSBO;

using System.Windows.Forms;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    /// <summary>
    /// Client manager
    /// </summary>
    public class clsAccountManager : IclsManager
    {

        #region MEMBERS

        static clsAccountManager _clsAccountManger = null;
        public DS4Account _DS4Account = new DS4Account();
        public DS4AccountGroup _DS4AccountGroups = new DS4AccountGroup();
        public List<string> _lstAccouontGroupName = new List<string>();
        List<string> _lstLessThanAccouontGroupName = new List<string>();
        public Dictionary<string, string> AccountGrpAccountOwner = new Dictionary<string, string>();
        public Dictionary<int, string> DicAccountIdName = new Dictionary<int, string>();
        #endregion MEMBERS

        #region METHODS
        private clsAccountManager()
        {
        }

        public bool CheckPwd(string pwd, long accid)
        {
            //DS4Account.dtAccountRow[] row = (DS4Account.dtAccountRow[])_DS4Account.dtAccount.Select("AccountId = " + accid.ToString());

            //string Pwddecrypted;
            //try
            //{
            //    Pwddecrypted = EncriptionAndDecription.DecryptString(row[0].MasterPassword, "BoTrade");
            //}
            //catch 
            //{
            //    Pwddecrypted = row[0].MasterPassword;
            //}
            //if (Pwddecrypted == Pwd)
            //    return true;
            //else
            return false;

        }




        #endregion METHODS

        #region PROPERTY
        public static clsAccountManager INSTANCE
        {
            get
            {
                if (_clsAccountManger == null)
                {
                    _clsAccountManger = new clsAccountManager();
                }
                return _clsAccountManger;
            }
        }
        #endregion PROPERTY

        #region IclsManager

        public override void AddSetting(IProtocolStruct PS)
        {
            try
            {
                ////Logging.FileHandling.WriteAllLog("clsAccountManager : Enter AddSetting()");

                switch (PS.ID)
                {
                    case ProtocolStructIDS.Country_ID:
                        //DoHandleCountryTable((PS as CountryPS)._Country);
                        break;
                    case ProtocolStructIDS.Bank_ID:
                        //DoHandleBankTable((PS as BankPS)._Bank);
                        break;
                    case ProtocolStructIDS.Account_ID:
                        // DoHandleAccountTable((PS as AccountPS)._Acc);
                        break;
                    case ProtocolStructIDS.Client_ID:
                        //DoHandleClientInfoTable((PS as ClientInfoPS)._Client);
                        break;
                    case ProtocolStructIDS.AccountGroup_ID:
                        // DoHandleAccountGroupTable((PS as AccountGroupPS)._AccGroup);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                // //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in AddSetting()");
            }
        }
        #region "Vinod created methods to handle AccountGroups"

        public void FillDataToAccountGroupDataSet(List<clsAccountGroup> lstAccountGroup)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsAccountManager : Enter FillDataToAccountGroupDataSet()");

                foreach (clsAccountGroup accountGroup in lstAccountGroup)
                {
                    DoHandleAccountGroupTable(accountGroup);
                }

                clsBrokersManagerHandler.INSTANCE._lstParentIds.Clear();
                clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.Clear();
                clsBrokersManagerHandler.INSTANCE._lstParentNames.Clear();
                clsBrokersManagerHandler.INSTANCE.Recursive(clsGlobal.BrokerNameId);
                //Logging.FileHandling.WriteAllLog("clsAccountManager : Exit FillDataToAccountGroupDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName +"ExceptionMessage "+ex.Message + 
                //  "ExceptionSource " +ex.Source+ "StackTrace" + ex.StackTrace + "in FillDataToAccountGroupDataSet()");
            }
        }

        public void FillDataToAccountDataSet(List<clsAccount> lstAccount)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsAccountManager : Enter FillDataToAccountDataSet()");

                foreach (clsAccount accountGroup in lstAccount)
                {
                    DoHandleAccountTable(accountGroup);
                }

                //Logging.FileHandling.WriteAllLog("clsAccountManager : Exit FillDataToAccountDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToAccountDataSet()");
            }
        }

        public void FillDataToBankDataSet(List<clsBank> lstBank)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsAccountManager : Enter FillDataToBankDataSet()");

                foreach (clsBank accountGroup in lstBank)
                {
                    DoHandleBankTable(accountGroup);
                }

                //Logging.FileHandling.WriteAllLog("clsAccountManager : Exit FillDataToBankDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToBankDataSet()");
            }
        }

        /// <summary>
        /// Handles accountgroup
        /// </summary>
        /// <param name="accGroup"></param>
        public void DoHandleAccountGroupTable(clsAccountGroup accGroup)
        {
            try
            {
                DS4AccountGroup.dtAccountGroupsRow _AccountGroupRow = _DS4AccountGroups.dtAccountGroups.FindByAccountGroupID(accGroup.AccountGroupID);
                if (_AccountGroupRow == null)
                {
                    _AccountGroupRow = _DS4AccountGroups.dtAccountGroups.NewRow() as DS4AccountGroup.dtAccountGroupsRow;
                    _AccountGroupRow.AccountGroupID = accGroup.AccountGroupID;
                    _AccountGroupRow.AccountGroupName = accGroup.AccountGroupName;
                    _AccountGroupRow.BrokerAddress = accGroup.BrokerAddress;
                    _AccountGroupRow.BrokerCity = accGroup.BrokerCity;
                    _AccountGroupRow.BrokerEmail = accGroup.BrokerEmail;
                    _AccountGroupRow.BrokerFax = accGroup.BrokerFax;
                    _AccountGroupRow.BrokerPhone1 = accGroup.BrokerPhone1;
                    _AccountGroupRow.BrokerPhone2 = accGroup.BrokerPhone2;
                    _AccountGroupRow.BrokerState = accGroup.BrokerState;
                    _AccountGroupRow.BrokerTypeID = accGroup.BrokerTypeID;
                    _AccountGroupRow.Charges = Convert.ToDecimal(accGroup.Charges.ToString("0.00"));
                    _AccountGroupRow.IsEnable = accGroup.IsEnable;
                    _AccountGroupRow.LeverageId = accGroup.LeverageId;
                    _AccountGroupRow.Owner = accGroup.Owner;
                    _AccountGroupRow.ParentAccountGroupID = accGroup.ParentBrokerId;
                    _AccountGroupRow.Password = accGroup.Password;
                    _DS4AccountGroups.dtAccountGroups.AdddtAccountGroupsRow(_AccountGroupRow);
                    if (_AccountGroupRow.BrokerTypeID > Cls.clsGlobal.BrokerID && clsBrokersManagerHandler.INSTANCE.
                        _lstParentIds.Contains(_AccountGroupRow.AccountGroupID))    //by vijay on 1 May 2012
                    {
                        _lstLessThanAccouontGroupName.Add(accGroup.AccountGroupName);  //by vijay on 1 May 2012
                    }
                    if (_AccountGroupRow.BrokerTypeID > Cls.clsGlobal.BrokerID) //condition added by vijay on 1 Mat 2012
                    {
                        _lstAccouontGroupName.Add(accGroup.AccountGroupName);
                    }
                    if (!AccountGrpAccountOwner.ContainsKey(accGroup.AccountGroupName.ToUpper()))
                    {
                        AccountGrpAccountOwner.Add(accGroup.AccountGroupName.ToUpper(), accGroup.Owner);
                    }
                }
                else
                {
                    _AccountGroupRow.AccountGroupID = accGroup.AccountGroupID;
                    _AccountGroupRow.AccountGroupName = accGroup.AccountGroupName;
                    _AccountGroupRow.BrokerAddress = accGroup.BrokerAddress;
                    _AccountGroupRow.BrokerCity = accGroup.BrokerCity;
                    _AccountGroupRow.BrokerEmail = accGroup.BrokerEmail;
                    _AccountGroupRow.BrokerFax = accGroup.BrokerFax;
                    _AccountGroupRow.BrokerPhone1 = accGroup.BrokerPhone1;
                    _AccountGroupRow.BrokerPhone2 = accGroup.BrokerPhone2;
                    _AccountGroupRow.BrokerState = accGroup.BrokerState;
                    _AccountGroupRow.BrokerTypeID = accGroup.BrokerTypeID;
                    _AccountGroupRow.Charges = Convert.ToDecimal(accGroup.Charges.ToString("0.00"));
                    _AccountGroupRow.IsEnable = accGroup.IsEnable;
                    _AccountGroupRow.LeverageId = accGroup.LeverageId;
                    _AccountGroupRow.Owner = accGroup.Owner;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleAccountGroupTable()");
            }
        }

        public string[] GetAccountGroupNameArray()
        {
            if (GetGroupName(clsGlobal.BrokerNameId) != null && !_lstAccouontGroupName.Contains(GetGroupName(clsGlobal.BrokerNameId)))
            {
                _lstAccouontGroupName.Add(GetGroupName(clsGlobal.BrokerNameId));
            }
            return _lstAccouontGroupName.ToArray();
        }

        public string[] GetLessThanAccountGroupdNameArray()
        {
            return _lstLessThanAccouontGroupName.ToArray();
        }


        public string GetGroupName(int AccountGroupId)
        {
            DS4AccountGroup.dtAccountGroupsRow _AccountGroupRow = _DS4AccountGroups.dtAccountGroups.FindByAccountGroupID(AccountGroupId);
            if (_AccountGroupRow == null)
                return null;
            return _AccountGroupRow.AccountGroupName;
        }

        public int GetGroupId(string GroupName)
        {
            DS4AccountGroup.dtAccountGroupsRow _AccountGroupRows = (DS4AccountGroup.dtAccountGroupsRow)_DS4AccountGroups.dtAccountGroups.FirstOrDefault(action => action.Owner == GroupName);
            //"AccountGroupName = '" + GroupName + "'");
            if (_AccountGroupRows == null)
                return 0;
            return _AccountGroupRows.AccountGroupID;
        }

        #endregion

        public void DoHandleCountryTable(clsCountryDetail country)
        {
            try
            {
                DS4Account.dtCountryMasterRow countryMasterRow = _DS4Account.dtCountryMaster.FindByPK_CountryID(country.CountryId);
                if (countryMasterRow == null)
                {
                    countryMasterRow = _DS4Account.dtCountryMaster.NewRow() as DS4Account.dtCountryMasterRow;
                    countryMasterRow.CountryCode = country.CountryCode;
                    countryMasterRow.CountryName = country.CountryName;
                    countryMasterRow.PK_CountryID = country.CountryId;
                    countryMasterRow.Nationality = country.Nationality;
                    _DS4Account.dtCountryMaster.AdddtCountryMasterRow(countryMasterRow);
                }
                else
                {
                    countryMasterRow.CountryCode = country.CountryCode;
                    countryMasterRow.CountryName = country.CountryName;
                    countryMasterRow.PK_CountryID = country.CountryId;
                    countryMasterRow.Nationality = country.Nationality;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleCountryTable()");
            }
        }

        /// <summary>
        /// Handles bank info
        /// </summary>
        /// <param name="bank"></param>
        public void DoHandleBankTable(clsBank bank)
        {
            try
            {
                DS4Account.dtBankInformationRow bankInformationRow = _DS4Account.dtBankInformation.FindByPK_BankID(bank.BankID);
                if (bankInformationRow == null)
                {
                    bankInformationRow = _DS4Account.dtBankInformation.NewRow() as DS4Account.dtBankInformationRow;
                    bankInformationRow.AccountHolderName = bank.AccountHolderName;
                    bankInformationRow.BankAccountID = bank.BankAccountID;
                    bankInformationRow.BankAccountType = bank.BankAccountType;
                    bankInformationRow.BankAddress1 = bank.BankAddress;
                    bankInformationRow.BankAddress2 = bank.BankAddress2;
                    bankInformationRow.BankCity = bank.BankCity;
                    bankInformationRow.FK_BankCountryID = bank.BankCountryID;
                    bankInformationRow.BankFax = bank.BankFax;
                    bankInformationRow.BankIFSCCode = bank.BankIFSCCode;
                    bankInformationRow.PK_BankID = bank.BankID;
                    bankInformationRow.BankName = bank.BankName;
                    bankInformationRow.BankPhone = bank.BankPhone;
                    bankInformationRow.BankSwiftCode = bank.BankSwiftCode;
                    bankInformationRow.BankZipCode = bank.BankZipCode;
                    bankInformationRow.ClientID = bank.ClientID;
                    _DS4Account.dtBankInformation.AdddtBankInformationRow(bankInformationRow);
                }
                else
                {
                    bankInformationRow.AccountHolderName = bank.AccountHolderName;
                    bankInformationRow.BankAccountID = bank.BankAccountID;
                    bankInformationRow.BankAccountType = bank.BankAccountType;
                    bankInformationRow.BankAddress1 = bank.BankAddress;
                    bankInformationRow.BankAddress2 = bank.BankAddress2;
                    bankInformationRow.BankCity = bank.BankCity;
                    bankInformationRow.FK_BankCountryID = bank.BankCountryID;
                    bankInformationRow.BankFax = bank.BankFax;
                    bankInformationRow.BankIFSCCode = bank.BankIFSCCode;
                    //bankInformationRow.PKBankID = bank.BankID;
                    bankInformationRow.BankName = bank.BankName;
                    bankInformationRow.BankPhone = bank.BankPhone;
                    bankInformationRow.BankSwiftCode = bank.BankSwiftCode;
                    bankInformationRow.BankZipCode = bank.BankZipCode;
                    bankInformationRow.ClientID = bank.ClientID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleBankTable()");
            }
        }

        /// <summary>
        /// Handles client info
        /// </summary>
        /// <param name="clientInfo"></param>
        public void DoHandleClientInfoTable(clsClientInfo clientInfo)
        {
            try
            {
                if (clientInfo.IsExists == true)
                {
                    MessageBox.Show("Login ID already exits");
                    return;
                }
                GetAccountGroupNameArray();
                DS4Account.dtClientInfoRow ClientRow = _DS4Account.dtClientInfo.FindByClientId(clientInfo.ClientId);
                if (clientInfo.AccountGroupID == clsGlobal.BrokerNameId || clsBrokersManagerHandler.INSTANCE._lstParentIds.Contains(clientInfo.AccountGroupID))//_lstAccouontGroupName.Contains(GetGroupName(clientInfo.AccountGroupID)))
                {
                    if (ClientRow == null)
                    {
                        ClientRow = _DS4Account.dtClientInfo.NewRow() as DS4Account.dtClientInfoRow;
                        ClientRow.ClientId = clientInfo.ClientId;
                        ClientRow.FirstName = clientInfo.FirstName;
                        ClientRow.MidleName = clientInfo.MidleName;
                        ClientRow.LastName = clientInfo.LastName;
                        ClientRow.Address1 = clientInfo.Address1;
                        ClientRow.Address2 = clientInfo.Address2;
                        ClientRow.Zone = clientInfo.City;
                        ClientRow.District = clientInfo.State;
                        ClientRow.Zip = clientInfo.Zip;
                        ClientRow.FaxNumber = clientInfo.FaxNumber;
                        ClientRow.Mobile = clientInfo.Mobile;
                        ClientRow.PassportId = clientInfo.PassportId;
                        ClientRow.SSN = clientInfo.SSN;
                        ClientRow.DOB = clientInfo.DOB;
                        ClientRow.Gender = clientInfo.Gender;
                        ClientRow.Status = clientInfo.Status;
                        ClientRow.Country = clientInfo.Country;
                        ClientRow.FK_CountryID = clientInfo.FKCountryID;
                        ClientRow.FK_NationalityID = clientInfo.FKNationalityID;
                        ClientRow.GroupName = GetBrokerCompanyName(clientInfo.AccountGroupID); //clientInfo.GroupName;
                        ClientRow.AccountGroupID = clientInfo.AccountGroupID;
                        ClientRow.ParticipantType = clientInfo.FKParticipantType;
                        ClientRow.AccountType = clientInfo.AccountType;
                        ClientRow.AccountTypeID = clientInfo.FKAccountTypeID;
                        ClientRow.Deleted = clientInfo.Deleted;
                        ClientRow.Balance = Convert.ToDecimal(clientInfo.Balance.ToString("0.00"));
                        ClientRow.Equity = clientInfo.Equity;
                        ClientRow.MasterPassword = clientInfo.MasterPassword;
                        ClientRow.TradingPassword = clientInfo.TradingPassword;
                        ClientRow.PrimaryPhone = clientInfo.PrimaryPhone;
                        ClientRow.SecondaryPhone = clientInfo.SecondaryPhone;
                        ClientRow.RegistrationDate = clientInfo.RegistrationDate;
                        ClientRow.PrimaryEmailAddress = clientInfo.PrimaryEmailAddress;
                        ClientRow.SecondaryEmailAddress = clientInfo.SecondaryEmailAddress;
                        ClientRow.PAN = clientInfo.PAN;
                        ClientRow.Age = clientInfo.Age;
                        ClientRow.LoginID = clientInfo.LoginID;
                        ClientRow.MarkupValue = clientInfo.MarkupValue;
                        ClientRow.AccountGroupType = GetBrokerTypeByBrokerName(ClientRow.AccountGroupID);

                        _DS4Account.dtClientInfo.AdddtClientInfoRow(ClientRow);

                        List<clsAccount> lstAccountsInfo = clsProxyClassManager.INSTANCE.GetAccountRecords(clientInfo.ClientId, AccountOpType.ACCOUNT);
                        clsAccountManager.INSTANCE.FillDataToAccountDataSet(lstAccountsInfo);
                        foreach (clsAccount account in lstAccountsInfo)
                        {
                            if (clientInfo.FKAccountTypeID == 1 && !DicAccountIdName.ContainsKey(account.AccountId))
                            {
                                DicAccountIdName.Add(account.AccountId, clientInfo.FirstName + " " + clientInfo.LastName);
                            }
                        }

                    }
                    else
                    {
                        //ClientRow.ClientId = clientInfo._ClientId;
                        ClientRow.FirstName = clientInfo.FirstName;
                        ClientRow.MidleName = clientInfo.MidleName;
                        ClientRow.LastName = clientInfo.LastName;
                        ClientRow.Address1 = clientInfo.Address1;
                        ClientRow.Address2 = clientInfo.Address2;
                        ClientRow.Zone = clientInfo.City;
                        ClientRow.District = clientInfo.State;
                        ClientRow.Zip = clientInfo.Zip;
                        ClientRow.FaxNumber = clientInfo.FaxNumber;
                        ClientRow.Mobile = clientInfo.Mobile;
                        ClientRow.PassportId = clientInfo.PassportId;
                        ClientRow.SSN = clientInfo.SSN;
                        ClientRow.DOB = clientInfo.DOB;
                        ClientRow.Gender = clientInfo.Gender;
                        ClientRow.Status = clientInfo.Status;
                        ClientRow.Country = clientInfo.Country;
                        ClientRow.FK_CountryID = clientInfo.FKCountryID;
                        ClientRow.FK_NationalityID = clientInfo.FKNationalityID;
                        ClientRow.GroupName = clientInfo.GroupName;
                        ClientRow.AccountGroupID = clientInfo.AccountGroupID;
                        ClientRow.ParticipantType = clientInfo.FKParticipantType;
                        ClientRow.AccountType = clientInfo.AccountType;
                        ClientRow.AccountTypeID = clientInfo.FKAccountTypeID;
                        ClientRow.Deleted = clientInfo.Deleted;
                        ClientRow.Balance = Convert.ToDecimal(clientInfo.Balance.ToString("0.00"));
                        ClientRow.Equity = Convert.ToDecimal(clientInfo.Equity.ToString("0.00"));
                        ClientRow.MasterPassword = clientInfo.MasterPassword;
                        ClientRow.TradingPassword = clientInfo.TradingPassword;
                        ClientRow.PrimaryPhone = clientInfo.PrimaryPhone;
                        ClientRow.SecondaryPhone = clientInfo.SecondaryPhone;
                        ClientRow.RegistrationDate = clientInfo.RegistrationDate;
                        ClientRow.PrimaryEmailAddress = clientInfo.PrimaryEmailAddress;
                        ClientRow.SecondaryEmailAddress = clientInfo.SecondaryEmailAddress;
                        ClientRow.PAN = clientInfo.PAN;
                        ClientRow.Age = clientInfo.Age;
                        ClientRow.LoginID = clientInfo.LoginID;
                        ClientRow.MarkupValue = clientInfo.MarkupValue;
                        ClientRow.AccountGroupType = GetBrokerTypeByBrokerName(ClientRow.AccountGroupID);//clientInfo.GroupName);
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleClientInfoTable()");
            }

        }

        /// <summary>
        /// Handles account info
        /// </summary>
        /// <param name="account"></param>
        public void DoHandleAccountTable(clsAccount account)
        {
            try
            {
                DS4Account.dtAccountsRow accountRow = _DS4Account.dtAccounts.FindByPK_AccountId(account.AccountId);
                if (accountRow == null)
                {
                    accountRow = _DS4Account.dtAccounts.NewRow() as DS4Account.dtAccountsRow;
                    if (accountRow != null)
                    {
                        accountRow.FK_AccountGroupID = account.AccountGroupId;
                        accountRow.PK_AccountId = account.AccountId;
                        accountRow.Balance = Convert.ToDecimal(account.Balence.ToString("0.00"));
                        accountRow.ClientID = account.ClientId;
                        accountRow.FK_Currency = account.CurrencyId;
                        accountRow.Deleted = account.Deleted;
                        accountRow.Equity = Convert.ToDecimal(account.Equity.ToString("0.00"));
                        accountRow.IsHedgingAllowed = account.IsHedgingAllowed;
                        accountRow.IsTradeEnable = account.IsTradeEnable;
                        accountRow.BuySideTurnOver = Convert.ToDecimal(account.BuySideTurnOver.ToString("0.00"));
                        accountRow.SellSideTurnOver = Convert.ToDecimal(account.SellSideTurnOver.ToString("0.00"));
                        accountRow.FK_Leverage = account.LeverageId;
                        accountRow.UsedMargin = Convert.ToDecimal(account.UsedMargin.ToString("0.00"));
                        accountRow.FK_BankID = account.RelatedBankId;
                        accountRow.LP_Name = account.LPName;
                        if (account.IsLive == true)
                        {
                            accountRow.IsLive = "Live";
                        }
                        else if (account.IsLive == false)
                        {
                            accountRow.IsLive = "Demo";
                        }
                        accountRow.HedgeTypeID = account.HedgeTypeID;

                        _DS4Account.dtAccounts.AdddtAccountsRow(accountRow);
                    }
                }
                else
                {
                    accountRow.FK_AccountGroupID = account.AccountGroupId;
                    //accountRow.PKAccountId = account.AccountId;
                    accountRow.Balance = Convert.ToDecimal(account.Balence.ToString("0.00"));
                    accountRow.ClientID = account.ClientId;
                    accountRow.FK_Currency = account.CurrencyId;
                    accountRow.Deleted = account.Deleted;
                    accountRow.Equity = Convert.ToDecimal(account.Equity.ToString("0.00"));
                    accountRow.IsHedgingAllowed = account.IsHedgingAllowed;
                    accountRow.IsTradeEnable = account.IsTradeEnable;
                    accountRow.BuySideTurnOver = Convert.ToDecimal(account.BuySideTurnOver.ToString("0.00"));
                    accountRow.SellSideTurnOver = Convert.ToDecimal(account.SellSideTurnOver.ToString("0.00"));
                    accountRow.FK_Leverage = account.LeverageId;
                    accountRow.UsedMargin = Convert.ToDecimal(account.UsedMargin.ToString("0.00"));
                    accountRow.FK_BankID = account.RelatedBankId;
                    accountRow.LP_Name = account.LPName;
                    accountRow.HedgeTypeID = account.HedgeTypeID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleAccountTable()");
            }
        }



        //public override void AddSetting(IProtocolStruct PS)
        //{
        //    DoHandleDataServersTable((PS as DataServerPS)._DataServer);
        //}

        public override void RemoveSetting(string DataKey)
        {
            //int ClientId = -999;
            //try
            //{
            //    ClientId = Convert.ToInt32(DataKey);
            //}
            //catch (Exception)
            //{
            //    FileHandling.WriteToLogEx(ex);
            //    return;
            //}
            //DS4Account.dtAccountRow Row = _DS4Account.dtAccount.FindByClientId(ClientId);

            //lock (_DS4Account.dtAccount)
            //{
            //    _DS4Account.dtAccount.RemovedtAccountRow(Row);
            //}

        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }
        #endregion IclsManager


        internal int GetCountryId(string CountryName)
        {
            DS4Account.dtCountryMasterRow[] _CountryMasterRow = (DS4Account.dtCountryMasterRow[])_DS4Account.dtCountryMaster.Select("CountryName = '" + CountryName + "'");
            if (_CountryMasterRow == null)
                return 0;
            return _CountryMasterRow[0].PK_CountryID;
        }
        internal DS4Account.dtAccountsRow[] GetTradeAccounts(int ClientId)
        {
            DS4Account.dtAccountsRow[] _AccRows = (DS4Account.dtAccountsRow[])_DS4Account.dtAccounts.Select("ClientID = " + ClientId + "");
            if (_AccRows == null)
                return null;
            else
                return _AccRows;
        }
        internal DS4Account.dtBankInformationRow[] GetBankAccounts(int ClientId)
        {
            DS4Account.dtBankInformationRow[] _bankRows = (DS4Account.dtBankInformationRow[])_DS4Account.dtBankInformation.Select("ClientID = " + ClientId + "");
            if (_bankRows == null)
                return null;
            else
                return _bankRows;
        }

        internal int GetBankID(string BankName, int ClientId)
        {
            DS4Account.dtBankInformationRow[] _bankRow = (DS4Account.dtBankInformationRow[])_DS4Account.dtBankInformation.Select("BankName = '" + BankName + "' and ClientId=" + ClientId);
            if (_bankRow == null)
                return 0;
            return _bankRow[0].PK_BankID;
        }

        internal string GetCountryName(int countryid)
        {
            if (countryid > 0)
            {
                DS4Account.dtCountryMasterRow[] _countryRow = (DS4Account.dtCountryMasterRow[])_DS4Account.dtCountryMaster.Select("pk_countryid = " + countryid);
                if (_countryRow.Count() == 0)
                    return string.Empty;
                return _countryRow[0].CountryName;
            }
            else
                return string.Empty;
        }

        internal string GetBankName(int bankId)
        {
            if (bankId > 0)
            {
                DS4Account.dtBankInformationRow[] _bankRow = (DS4Account.dtBankInformationRow[])_DS4Account.dtBankInformation.Select("PK_BankID = " + bankId);
                if (_bankRow != null && _bankRow.Rank > 0)
                    return _bankRow[0].BankName;
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Provides parent brokers
        /// </summary>
        /// <param name="BrokerType"></param>
        /// <returns></returns>
        public List<string> GetParentBrokersTypeFromAccountGroup(string BrokerType)
        {
            List<string> lstParentBrokers = new List<string>();
            try
            {
                //Logging.FileHandling.WriteAllLog("clsAccountManager : Enter GetParentBrokersTypeFromAccountGroup()");
                int id = clsBrokerManager.INSTANCE.GetBrokerTypeId(BrokerType);
                DS4AccountGroup.dtAccountGroupsRow[] rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID < " + id);
                if (rows == null)
                {
                    return lstParentBrokers;
                }
                foreach (DS4AccountGroup.dtAccountGroupsRow item in rows)
                {
                    lstParentBrokers.Add(item.AccountGroupName);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsAccountManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in GetParentBrokersTypeFromAccountGroup()");
            }
            return lstParentBrokers;
        }

        /// <summary>
        /// Provides parent broker
        /// </summary>
        /// <param name="brokerType"></param>
        /// <returns></returns>
        public List<string> GetParentBrokers(string brokerType)
        {
            List<string> lstParentBrokers = new List<string>();
            DS4AccountGroup.dtAccountGroupsRow[] rows = null;
            switch (brokerType.Trim())
            {
                case "TM":
                    {
                        rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId("TCM"));
                    }
                    break;
                case "STM":
                    {
                        rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId("TM"));
                    }
                    break;
                case "All":
                    {
                        rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId("TCM") + " OR " + "BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId("TM"));
                    }
                    break;
            }
            if (rows == null)
                return lstParentBrokers;

            lstParentBrokers.AddRange(rows.Select(item => item.Owner));
            return lstParentBrokers;
        }

        public List<string> GetParentBrokersForClient(string brokerType)
        {
            List<string> lstParentBrokers = new List<string>();
            DS4AccountGroup.dtAccountGroupsRow[] rows = null;
            switch (brokerType.Trim())
            {
                case "All":
                    {
                        rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select();
                    }
                    break;
                default:
                    {
                        rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId(brokerType));
                    }
                    break;
            }
            if (rows == null)
                return lstParentBrokers;
            lstParentBrokers.AddRange(rows.Select(item => item.Owner));
            return lstParentBrokers;
        }

        public List<string> GetGroupNamesByBrokerType(string brokerType)
        {
            List<string> lstBrokers = new List<string>();
            DS4AccountGroup.dtAccountGroupsRow[] rows = (DS4AccountGroup.dtAccountGroupsRow[])_DS4AccountGroups.dtAccountGroups.Select("BrokerTypeID = " +
                            clsBrokerManager.INSTANCE.GetBrokerTypeId(brokerType.Trim()));

            foreach (DS4AccountGroup.dtAccountGroupsRow item in rows)
            {
                if (_lstAccouontGroupName.Contains(item.AccountGroupName.Trim()))
                {
                    lstBrokers.Add(item.AccountGroupName);
                }
            }

            return lstBrokers;
        }


        public int GetBrokerIDByCompanyName(string companyName)
        {
            if (companyName == "All")
                return 0;
            DS4AccountGroup.dtAccountGroupsRow row = (DS4AccountGroup.dtAccountGroupsRow)_DS4AccountGroups.dtAccountGroups.FirstOrDefault(a => a.Owner == companyName);//.Select("Owner = '" + companyName + "'");

            if (row == null)
                return 0;

            return row.AccountGroupID;
        }

        public string GetBrokerCompanyName(int accountGroupId)
        {
            DS4AccountGroup.dtAccountGroupsRow accountGroupRow = _DS4AccountGroups.dtAccountGroups.FindByAccountGroupID(accountGroupId);
            if (accountGroupRow == null)
                return null;
            return accountGroupRow.Owner;
        }

        public string GetBrokerTypeByBrokerName(int accountGroupId)//(string acountGroupName)
        {
            DS4AccountGroup.dtAccountGroupsRow row = (DS4AccountGroup.dtAccountGroupsRow)_DS4AccountGroups.dtAccountGroups.First(
               A => A.AccountGroupID == accountGroupId); //A =>A.Owner == acountGroupName);

            if (row == null)
                return string.Empty;

            return clsBrokerManager.INSTANCE.GetBrokerType(row.BrokerTypeID);
        }

        public string GetBrokerTypeByCompanyName(string companyName)
        {
            DS4AccountGroup.dtAccountGroupsRow row = (DS4AccountGroup.dtAccountGroupsRow)_DS4AccountGroups.dtAccountGroups.First(
                A => A.Owner == companyName);

            if (row == null)
                return string.Empty;

            return clsBrokerManager.INSTANCE.GetBrokerType(row.BrokerTypeID);
        }

        public string[] GetBrokerIDs()
        {
            //List<string> lstBrokerIDs;
            if (clsGlobal.BrokerID != 1)
            {
                _lstIds.Clear();
                GetBrokerIDsByBrokerId(clsGlobal.BrokerNameId);
                //_lstIds.Add(clsGlobal.BrokerNameId.ToString());
                return _lstIds.ToArray();
            }
            return _DS4AccountGroups.dtAccountGroups.Select(a => a.AccountGroupID.ToString()).ToArray();
        }
        List<string> _lstIds = new List<string>();
        public void GetBrokerIDsByBrokerId(int brokerId)
        {
            if (_DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" + brokerId).Any())
            {
                foreach (DS4AccountGroup.dtAccountGroupsRow item in _DS4AccountGroups.dtAccountGroups.Select("ParentAccountGroupID=" + brokerId))
                {
                    _lstIds.Add(item.AccountGroupID.ToString());
                    GetBrokerIDsByBrokerId(item.AccountGroupID);
                }
            }
            return;
        }

        public int GetClientID(string clientName)
        {
            return _DS4Account.dtClientInfo.FirstOrDefault(a => a.FirstName == clientName).ClientId;
        }

        public int GetBrokerParent(int brokerID)
        {
            DS4AccountGroup.dtAccountGroupsRow row = (DS4AccountGroup.dtAccountGroupsRow)_DS4AccountGroups.dtAccountGroups.First(
                A => A.AccountGroupID == brokerID);

            if (row == null)
                return 0;

            return row.ParentAccountGroupID;
        }

        public string GetBrokerPassword(int brokerId)
        {
            return _DS4AccountGroups.dtAccountGroups.First(a => a.AccountGroupID == brokerId).Password;
        }

    }
}
