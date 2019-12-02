using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using LtechIndia.BackOffice.BOEngine.DAL.DB_New;
using clsInterface4OME;
using BOEngineServiceClasses;
namespace LtechIndia.BackOffice.BOEngine.DAL
{
    public partial class BLBO
    {
        #region MEMBERS      
        dbMan_BO_HolidayInsertDataContext s_BO_HolidayInsert;        
        dbMan_BO_HolidaySelectDataContext s_BO_HolidaySelect;        
        dbMan_BO_HolidayUpdateDataContext s_BO_HolidayUpdate;        
        dbMan_BO_SelectSymbolDefaultSettingDataContext s_BO_SelectSymbolDefaultSetting;
        dbMan_BO_SelectSymbolSessionDataContext s_BO_SelectSymbolSession;
        dbMan_BO_DeleteSymbolDataContext s_BO_DeleteSymbol;
        dbMan_BO_UpdateTimeSettingsDataContext s_UpdateTimeSettings;
        dbMan_BO_UpdateSymbolDataContext s_UpdateSymbol;
        dbMan_BO_DeleteSymbolSessionDataContext s_DeleteSymbolSession;
        dbMan_BO_DeleteSymbolSessionNewDataContext s_DeleteSymbolSessionNew;
        dbMan_BO_InsertAccountDetailDataContext s_InsertAccountDetails;
        dbMan_BO_UpdateAccountDetailsDataContext s_UpdateAccountDetails;
        dbMan_BO_InsertBankDetailsDataContext s_InsertBankDetails;
        dbMan_BO_UpdateBankDetailsDataContext s_UpdateBankDetails;
        dbMan_BO_UpdateParticipantDetailsDataContext s_UpdateParticipantDetails;
        dbMan_BO_InsertParticipantDetailsDataContext s_InsertParticipantDetails;
        dbMan_BO_InsertIntoAccountTransactionDataContext s_InsertIntoAccountTransactionDataContext;
        dbMan_BO_GetInstrumentSwapsDataContext S_dbMan_BO_GetInstrumentSwaps;
        dbMan_BO_InsertInstrumentSwapsDataContext s_dbMan_BO_InsertInstrumentSwaps;
        dbMan_BO_UpdateInstrumentSwapDataContext s_dbMan_BO_UpdateInstrumentSwap;
        dbMan_BO_GetSymbolQuoteSessionDataContext s_GetSymbolQuoteSession;
        dbMan_BO_GetSymbolTradeSessionDataContext s_GetSymbolTradeSession;

        #endregion MEMBERS

        public void Init(string lnqConnectionString)
        {            
            s_BO_HolidayInsert = new dbMan_BO_HolidayInsertDataContext(lnqConnectionString);         
            s_BO_HolidaySelect = new dbMan_BO_HolidaySelectDataContext(lnqConnectionString);            
            s_BO_HolidayUpdate = new dbMan_BO_HolidayUpdateDataContext(lnqConnectionString);            
            s_BO_SelectSymbolDefaultSetting = new dbMan_BO_SelectSymbolDefaultSettingDataContext(lnqConnectionString);
            s_BO_SelectSymbolSession = new dbMan_BO_SelectSymbolSessionDataContext(lnqConnectionString);
            s_BO_DeleteSymbol = new dbMan_BO_DeleteSymbolDataContext(lnqConnectionString);
            s_UpdateTimeSettings = new dbMan_BO_UpdateTimeSettingsDataContext(lnqConnectionString);
            s_UpdateSymbol = new dbMan_BO_UpdateSymbolDataContext(lnqConnectionString);
            s_DeleteSymbolSession = new dbMan_BO_DeleteSymbolSessionDataContext(lnqConnectionString);
            s_DeleteSymbolSessionNew = new dbMan_BO_DeleteSymbolSessionNewDataContext(lnqConnectionString);            
            s_InsertAccountDetails = new dbMan_BO_InsertAccountDetailDataContext(lnqConnectionString);
            s_UpdateAccountDetails = new dbMan_BO_UpdateAccountDetailsDataContext(lnqConnectionString);
            s_InsertBankDetails = new dbMan_BO_InsertBankDetailsDataContext(lnqConnectionString);
            s_UpdateBankDetails = new dbMan_BO_UpdateBankDetailsDataContext(lnqConnectionString);
            s_UpdateParticipantDetails = new dbMan_BO_UpdateParticipantDetailsDataContext(lnqConnectionString);
            s_InsertParticipantDetails = new dbMan_BO_InsertParticipantDetailsDataContext(lnqConnectionString);
            s_InsertIntoAccountTransactionDataContext = new dbMan_BO_InsertIntoAccountTransactionDataContext(lnqConnectionString);
            S_dbMan_BO_GetInstrumentSwaps = new dbMan_BO_GetInstrumentSwapsDataContext(lnqConnectionString);
            s_dbMan_BO_InsertInstrumentSwaps = new dbMan_BO_InsertInstrumentSwapsDataContext(lnqConnectionString);
            s_dbMan_BO_UpdateInstrumentSwap = new dbMan_BO_UpdateInstrumentSwapDataContext(lnqConnectionString);
            s_GetSymbolQuoteSession = new dbMan_BO_GetSymbolQuoteSessionDataContext(lnqConnectionString);
            s_GetSymbolTradeSession = new dbMan_BO_GetSymbolTradeSessionDataContext(lnqConnectionString);
        }
      
        public int HandleBO_HolidayInsert(clsHoliday Obj)
        {
            lock (s_BO_HolidayInsert)
            {
                int spRetVal = s_BO_HolidayInsert.BO_HolidayInsert(Obj.Day, Obj.FromTime, Obj.ToTime, Obj.Symbol, Obj.IsEnable,
                    Obj.IsEveryYear, Obj.Description);
                if (spRetVal == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_HolidayInsert";
                    clsLog.LogSqlErr(str);
                }
                return spRetVal;
            }

        }

        public int HandleBO_InsertAccountDetail(clsAccount objAccount)
        {
            lock (s_InsertAccountDetails)
            {
                int? accountId = objAccount.AccountId;
                int sp_retval = s_InsertAccountDetails.BO_InsertAccountDetails(objAccount.ClientId,
                objAccount.AccountGroupId, objAccount.Balence, objAccount.Equity,
                objAccount.Deleted, objAccount.UsedMargin, objAccount.LeverageId,
                objAccount.IsHedgingAllowed, objAccount.IsTradeEnable, objAccount.CurrencyId,
                objAccount.BuySideTurnOver, objAccount.SellSideTurnOver, objAccount.RelatedBankId,
                ref accountId, objAccount.LPName, objAccount.LPAccountID, objAccount.IsLive, objAccount.HedgeTypeID);
                string x = objAccount.ToString();
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertAccountDetails";
                    clsLog.LogSqlErr(str);
                }
                objAccount.AccountId = (int)accountId;
                return sp_retval;
            }

        }
        public int HandleBO_UpdateAccountDetails(clsAccount objAccount)
        {
            lock (s_UpdateAccountDetails)
            {

                int sp_retval = s_UpdateAccountDetails.BO_UpdateAccountDetails(objAccount.AccountId, objAccount.ClientId,
                    objAccount.AccountGroupId, objAccount.Balence, objAccount.Equity, objAccount.Deleted, objAccount.UsedMargin,
                    objAccount.LeverageId, objAccount.IsHedgingAllowed, objAccount.IsTradeEnable, objAccount.CurrencyId,
                    objAccount.BuySideTurnOver, objAccount.SellSideTurnOver, objAccount.RelatedBankId, objAccount.HedgeTypeID);

                if (sp_retval == SUCCESS_ID)
                {
                    if (objAccount.PaymentType != string.Empty)
                    {
                        sp_retval = s_InsertIntoAccountTransactionDataContext.BO_InsertIntoAccountTransaction(
                            objAccount.AccountId, objAccount.PaymentAmount, objAccount.PaymentType,
                            objAccount.PaymentMode, objAccount.PaymentDate, objAccount.ChequeFdNo, objAccount.Remark);
                        if (sp_retval == FAILURE_ID)
                        {
                            string str = " Exception occured:-BO_InsertIntoAccountTransaction";
                            clsLog.LogSqlErr(str);
                        }
                    }
                }
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:-BO_UpdateAccountDetails";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }

        public int HandleBO_InsertBankDetails(clsBank objBank)
        {
            lock (s_InsertBankDetails)
            {
                int? bankId = objBank.BankID;
                int sp_retval = s_InsertBankDetails.BO_InsertBankDetails(objBank.AccountHolderName, objBank.BankAccountID, objBank.BankName,
                    objBank.BankCountryID, objBank.BankCity, objBank.BankZipCode, objBank.BankAddress,
                    objBank.BankAddress2, objBank.BankPhone, objBank.BankFax, objBank.BankSwiftCode,
                    objBank.ClientID, objBank.BankAccountType, objBank.BankIFSCCode, ref bankId);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertAccountDetails";
                    clsLog.LogSqlErr(str);
                }
                objBank.BankID = (int)bankId;
                return sp_retval;
            }

        }
        public int HandleBO_UpdateBankDetails(clsBank objBank)
        {
            lock (s_UpdateBankDetails)
            {

                int sp_retval = s_UpdateBankDetails.BO_UpdateBankDetails(objBank.BankID, objBank.AccountHolderName, objBank.BankAccountID,
                    objBank.BankName, objBank.BankCountryID, objBank.BankCity, objBank.BankZipCode, objBank.BankAddress,
                    objBank.BankAddress2, objBank.BankPhone, objBank.BankFax, objBank.BankSwiftCode, objBank.ClientID,
                    objBank.BankAccountType, objBank.BankIFSCCode);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:-BO_UpdateBankDetails";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }
        public int HandleBO_InsertParticipantDetails(clsClientInfo objClient)
        {
            lock (s_InsertParticipantDetails)
            {
                int? clientId = objClient.ClientId;
                int sp_retval = s_InsertParticipantDetails.BO_InsertParticipantDetail(objClient.FirstName, objClient.MidleName, objClient.LastName,
                    objClient.PrimaryEmailAddress, objClient.SecondaryEmailAddress, objClient.DOB, objClient.Gender, objClient.FKNationalityID,
                    objClient.Address1, objClient.Address2, objClient.FKCountryID, objClient.City, objClient.State, objClient.Zip,
                    objClient.PrimaryPhone, objClient.SecondaryPhone, objClient.FaxNumber, objClient.Mobile, objClient.PassportId,
                    objClient.SSN, objClient.Age, objClient.PAN, objClient.FKParticipantType, objClient.LoginID, objClient.MasterPassword,
                    objClient.TradingPassword, objClient.Status, objClient.Deleted, objClient.RegistrationDate, objClient.FKAccountTypeID,
                    objClient.AccountGroupID, ref clientId, objClient.MarkupValue);
                string x = objClient.ToString();
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_InsertParticipantDetails";
                    clsLog.LogSqlErr(str);
                }
                objClient.ClientId = (int)clientId;
                return sp_retval;
            }

        }
        public int HandleBO_UpdateParticipantDetails(clsClientInfo objClient)
        {
            lock (s_UpdateParticipantDetails)
            {

                int sp_retval = s_UpdateParticipantDetails.BO_UpdateParticipantDetail(
                    objClient.ClientId, objClient.FirstName, objClient.MidleName,
                    objClient.LastName, objClient.PrimaryEmailAddress, objClient.SecondaryEmailAddress,
                    objClient.DOB, objClient.Gender, objClient.FKNationalityID,
                    objClient.Address1, objClient.Address2, objClient.FKCountryID,
                    objClient.City, objClient.State, objClient.Zip,
                    objClient.PrimaryPhone, objClient.SecondaryPhone, objClient.FaxNumber,
                    objClient.Mobile, objClient.PassportId, objClient.SSN,
                    objClient.Age, objClient.PAN, objClient.FKParticipantType,
                    objClient.LoginID, objClient.MasterPassword, objClient.TradingPassword,
                    objClient.Status, objClient.Deleted, objClient.RegistrationDate,
                    objClient.FKAccountTypeID, objClient.AccountGroupID, objClient.MarkupValue);
                string x = objClient.ToString();
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:-BO_UpdateParticipantDetails";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
        }

        public List<BO_HolidaySelectResult> HandleBO_HolidaysSelect()
        {
            lock (s_BO_HolidaySelect)
            {
                ISingleResult<BO_HolidaySelectResult> ret = s_BO_HolidaySelect.BO_HolidaySelect();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_HolidaySelectResult> HolidaySelect = null;
                if (sp_retval == SUCCESS_ID)
                {
                    HolidaySelect = ret.ToList();
                }
                else
                {
                    string str = " Exception occured:- BO_HolidaySelect";
                    clsLog.LogSqlErr(str);
                }

                return HolidaySelect;
            }

        }
     
        public int HandleBO_HolidaysUpdate(clsHoliday obj)
        {
            lock (s_BO_HolidayUpdate)
            {
                int sp_retval = s_BO_HolidayUpdate.BO_HolidayUpdate(obj.Id, obj.Day, obj.FromTime, obj.ToTime,
                    obj.Symbol, obj.IsEnable, obj.IsEveryYear, obj.Description);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_HolidayUpdate";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }
        }     

        public List<BO_SelectSymbolDefaultSettingResult> HandleDBBO_SelectSymbolDefaultDetail()
        {
            lock (s_BO_SelectSymbolDefaultSetting)
            {
                ISingleResult<BO_SelectSymbolDefaultSettingResult> ret = s_BO_SelectSymbolDefaultSetting.BO_SelectSymbolDefaultSetting();
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_SelectSymbolDefaultSettingResult> SelectSymbolDefaultdetail = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectSymbolDefaultdetail = ret.ToList();
                }

                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_SelectSymbolDefaultSetting";
                    clsLog.LogSqlErr(str);
                }
                return SelectSymbolDefaultdetail;
            }
          
        }


        public List<BO_SelectSymbolsessionResult> HandleDBBO_SelectSymbolsession(int id)
        {
            lock (s_BO_SelectSymbolSession)
            {
                List<BO_SelectSymbolsessionResult> SelectSymbolsession = null;
                try
                {
                    ISingleResult<BO_SelectSymbolsessionResult> ret = s_BO_SelectSymbolSession.BO_SelectSymbolsession(id);
                    int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                    //List<BO_SelectSymbolsessionResult> SelectSymbolsession = null;
                    if (sp_retval == SUCCESS_ID)
                    {
                        SelectSymbolsession = ret.ToList();
                    }
                    else if (sp_retval == FAILURE_ID)
                    {
                        string str = " Exception occured:- BO_SelectSymbolsessionResult";
                        clsLog.LogSqlErr(str);
                    }
                }
                catch (Exception ex)
                {
                }
                return SelectSymbolsession;
            }           
        }

      
        public List<clsSymbolSession> Get_SelectSymbolsessionNew(int instrumentId)
        {
            lock (s_BO_SelectSymbolSession)
            {
                List<clsSymbolSession> lstSymbolSession = null;
                try
                {
                    ISingleResult<BO_SelectSymbolsessionResult> ret = s_BO_SelectSymbolSession.BO_SelectSymbolsession(instrumentId);
                    int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                    List<BO_SelectSymbolsessionResult> SelectSymbolsession = null;
                    if (sp_retval == SUCCESS_ID)
                    {
                        SelectSymbolsession = ret.ToList();
                    }
                    else if (sp_retval == FAILURE_ID)
                    {
                        string str = " Exception occured:- BO_SelectSymbolsessionResult";
                        clsLog.LogSqlErr(str);
                    }


                    int SessionCount = SelectSymbolsession.Count;
                    lstSymbolSession = new List<clsSymbolSession>();
                    for (int iSessionLoop = 0; iSessionLoop < SessionCount; iSessionLoop++)
                    {
                        clsSymbolSession symbolSession = new clsSymbolSession();
                        string session = string.Empty;
                        foreach (BO_GetSymbolQuotesessionResult quoteS in HandleDBBO_GetSymbolQuotesession(instrumentId,
                            SelectSymbolsession[iSessionLoop].Day))
                        {
                            if (quoteS.Quotes.Trim() != "" && quoteS.EndQuotes.Trim() != "")
                            {
                                session = session + quoteS.Quotes + "-" + quoteS.EndQuotes + ",";
                            }
                            else
                                session = session + ",";
                        }
                        symbolSession.QuoteSession = session.Remove(session.Length - 1);

                        symbolSession.Day = (DAYS)Enum.Parse(typeof(DAYS), SelectSymbolsession[iSessionLoop].Day, true);
                        session = string.Empty;
                        foreach (BO_GetSymbolTradesessionResult quoteS in HandleDBBO_GetSymbolTradesession(instrumentId,
                            SelectSymbolsession[iSessionLoop].Day))
                        {

                            if (quoteS.TradeStart.Trim() != "" && quoteS.TradeEnd.Trim() != "")
                            {
                                session = session + quoteS.TradeStart + "-" + quoteS.TradeEnd + ",";
                            }
                            else
                                session = session + ",";

                            symbolSession.SessionEODMarketMaker = symbolSession.SessionEODMarketMaker + quoteS.TradeStart + "-" + quoteS.TradeEnd + "_" + quoteS.EODSession.ToString() + "_" + quoteS.MarketMaker.ToString() + ",";
                        }
                        symbolSession.TradeSession = session.Remove(session.Length - 1);
                        session = string.Empty;
                        symbolSession.IsUseTimelimits = SelectSymbolsession[iSessionLoop].UseTimelimits.Value;
                        symbolSession.StartDate = SelectSymbolsession[iSessionLoop].StartDate.Value;
                        symbolSession.EndDate = SelectSymbolsession[iSessionLoop].EndDate.Value;

                        lstSymbolSession.Add(symbolSession);
                    }
                }
                catch (Exception ex)
                {
                }
                return lstSymbolSession;
            }
        }


        public List<clsSymbolSession> Get_SelectSymbolsession(clsContractSpecification objCS)
        {
            lock (s_BO_SelectSymbolSession)
            {
                //List<BO_SelectSymbolsessionResult> SelectSymbolsession = null;
                List<clsSymbolSession> lstSymbolSession = null;
                try
                {
                    ISingleResult<BO_SelectSymbolsessionResult> ret = s_BO_SelectSymbolSession.BO_SelectSymbolsession(objCS.Instruement_ID);
                    int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                    List<BO_SelectSymbolsessionResult> SelectSymbolsession = null;
                    if (sp_retval == SUCCESS_ID)
                    {
                        SelectSymbolsession = ret.ToList();
                    }
                    else if (sp_retval == FAILURE_ID)
                    {
                        string str = " Exception occured:- BO_SelectSymbolsessionResult";
                        clsLog.LogSqlErr(str);
                    }


                    objCS.SessionCount = SelectSymbolsession.Count;
                    lstSymbolSession = new List<clsSymbolSession>();
                    for (int iSessionLoop = 0; iSessionLoop < objCS.SessionCount; iSessionLoop++)
                    {
                        clsSymbolSession symbolSession = new clsSymbolSession();
                        string session = string.Empty;
                        foreach (BO_GetSymbolQuotesessionResult quoteS in HandleDBBO_GetSymbolQuotesession(objCS.Instruement_ID,
                            SelectSymbolsession[iSessionLoop].Day))
                        {
                            if (quoteS.Quotes.Trim() != "" && quoteS.EndQuotes.Trim() != "")
                            {
                                session = session + quoteS.Quotes + "-" + quoteS.EndQuotes + ",";
                            }
                            else
                                session = session + ",";
                        }
                        symbolSession.QuoteSession = session.Remove(session.Length - 1);//lstSymbolsession[iSessionLoop].Trade;

                        symbolSession.Day = (DAYS)Enum.Parse(typeof(DAYS), SelectSymbolsession[iSessionLoop].Day, true);
                        session = string.Empty;
                        foreach (BO_GetSymbolTradesessionResult quoteS in HandleDBBO_GetSymbolTradesession(objCS.Instruement_ID,
                            SelectSymbolsession[iSessionLoop].Day))
                        {

                            if (quoteS.TradeStart.Trim() != "" && quoteS.TradeEnd.Trim() != "")
                            {
                                session = session + quoteS.TradeStart + "-" + quoteS.TradeEnd + ",";
                            }
                            else
                                session = session + ",";

                            symbolSession.SessionEODMarketMaker = symbolSession.SessionEODMarketMaker + quoteS.TradeStart + "-" + quoteS.TradeEnd + "_" + quoteS.EODSession.ToString() + "_" + quoteS.MarketMaker.ToString() + ",";
                        }
                        symbolSession.TradeSession = session.Remove(session.Length - 1); //lstSymbolsession[iSessionLoop].Quotes;
                        session = string.Empty;
                        symbolSession.IsUseTimelimits = SelectSymbolsession[iSessionLoop].UseTimelimits.Value;
                        symbolSession.StartDate = SelectSymbolsession[iSessionLoop].StartDate.Value;
                        symbolSession.EndDate = SelectSymbolsession[iSessionLoop].EndDate.Value;

                        lstSymbolSession.Add(symbolSession);
                    }
                }
                catch (Exception ex)
                {
                }
                return lstSymbolSession;
            }
        }

        //---------------

        public List<BO_GetSymbolQuotesessionResult> HandleDBBO_GetSymbolQuotesession(int id, string day)
        {
            lock (s_BO_SelectSymbolSession)
            {
                ISingleResult<BO_GetSymbolQuotesessionResult> ret = s_GetSymbolQuoteSession.BO_GetSymbolQuotesession(id, day);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetSymbolQuotesessionResult> SelectSymbolsession = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectSymbolsession = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_SelectSymbolsessionResult";
                    clsLog.LogSqlErr(str);
                }
                return SelectSymbolsession;
            }
        }

        public List<BO_GetSymbolTradesessionResult> HandleDBBO_GetSymbolTradesession(int id, string day)
        {
            lock (s_BO_SelectSymbolSession)
            {
                ISingleResult<BO_GetSymbolTradesessionResult> ret = s_GetSymbolTradeSession.BO_GetSymbolTradesession(id, day);
                int sp_retval = clsUtility.GetInt(ret.ReturnValue);
                List<BO_GetSymbolTradesessionResult> SelectSymbolsession = null;
                if (sp_retval == SUCCESS_ID)
                {
                    SelectSymbolsession = ret.ToList();
                }
                else if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_SelectSymbolsessionResult";
                    clsLog.LogSqlErr(str);
                }
                return SelectSymbolsession;


            }
        }

        

        public int HandleDBBO_UpdateAccount(ClientInfo ObjAccount)
        {
            //lock (S_DBBO_UpdateAccount)
            //{
            //    int sp_retval = S_DBBO_UpdateAccount.DBBO_UpdateAccount(Convert.ToInt32(Convert.ToBoolean(ObjAccount._AccountId)), Convert.ToInt32(ObjAccount._AccountGroupID), ObjAccount._Levarage, ObjAccount._TaxRate, ObjAccount._Comment);
            //    if (sp_retval == -999)
            //    {
            //        string str = " Exception occured:- DBBO_UpdateAccount";
            //        clsLog.LogSqlErr(str);
            //    }
            //    return sp_retval;
            //}

            return 0;
        }

     

        public int HandleDBBO_UpdateBulkGroup(Group ObjGroup)
        {
#if LAXMAN
            lock (S_DBBO_UpdateBulkGroup)
            {
                int sp_retval = S_DBBO_UpdateBulkGroup.DBBO_UpdateBulkGroup(ObjGroup._AccountGroupID.ToString(),ObjGroup._GroupCode);
                if (sp_retval == -999)
                {
                    string str = " Exception occured:- DBBO_UpdateBulkGroup";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;
            }
#endif
            return -999;
        }

        public int HandleDBBO_UpdateBulkGroup_test(Group ObjGroup)
        {
#if LAXMAN
          lock (S_DBBO_UpdateBulkGroup_test)
          {
              int sp_retval = S_DBBO_UpdateBulkGroup_test.DBBO_UpdateBulkGroup_test(ObjGroup._AccountGroupID.ToString(), ObjGroup._GroupCode);
              if (sp_retval == -999)
              {
                  string str = " Exception occured:- DBBO_UpdateBulkGroup_test";
                  clsLog.LogSqlErr(str);
              }
              return sp_retval;
          }
#endif
            return -999;
        }

     

        public int HandleDBBO_UpdatefilterTab(Symbol objSymbol, string msg)
        {
            //lock (S_DBBO_UpdatefilterTab)
            //{
            //    int sp_retval = S_DBBO_UpdatefilterTab.DBBO_UpdatefilterTab(Convert.ToInt64(objSymbol._Instruement_ID), objSymbol._IsAllowRealTimeQuotesFromDataFeeds, objSymbol._IsSaveAllIncomingPrices, objSymbol._Filterationlevel, objSymbol._Automaticlimit, objSymbol._Filter, objSymbol._IgnoreQutoes, objSymbol._Smoothing, ref msg);
            //    if (sp_retval == -999)
            //    {
            //        string str = " Exception occured:- DBBO_UpdatefilterTab";
            //        clsLog.LogSqlErr(str);
            //    }
            //    return sp_retval;
            //}
            return 0;
        }

        public int HandleDBBO_UpdateIntoGroupDetails(Group objGroup)
        {

            //Commented by vijay(Change to updated code to incorporate the UI changes)

            //  lock (S_DBBO_UpdateIntoGroupDetails)
            //  {
            //      int sp_retval = S_DBBO_UpdateIntoGroupDetails.DBBO_UpdateIntoGroupDetails(objGroup._AccountGroupID, objGroup._AccountGroupName, objGroup._Owner, objGroup._DepositeCurrency, objGroup._Deposite, objGroup._Leverage, objGroup._AnnualInterestRate, objGroup._SecurityIDAccount, objGroup._EnableAccount, objGroup._InActivityPeriod, objGroup._MaximumBalance, objGroup._ArchiveDeletedPendingOrders, objGroup._MarginCallLevel, objGroup._StopOutLevel, objGroup._VirtualCredit, objGroup._TimeOut, objGroup._News, objGroup._MaximumSymbols, objGroup._MaximumOrders, objGroup._GroupPermission, objGroup._EnableGroupPermission, objGroup._SMTPServer, objGroup._SMTPLogin, objGroup._TemplatesPath, objGroup._SMTPPassword, objGroup._SupportEmail, objGroup._IsCopyReport, objGroup._Signature);  // S_DBBO_UpdateIntoGroupDetails.DBBO_UpdateIntoGroupDetails(objGroup._AccountGroupID, objGroup._AccountGroupName, objGroup._Owner, objGroup._DepositeCurrency, objGroup._Deposite, objGroup._Leverage, objGroup._AnnualInterestRate,objGroup._SecurityIDAccount , objGroup._EnableAccount, objGroup._InActivityPeriod, objGroup._MaximumBalance, objGroup._ArchiveDeletedPendingOrders, objGroup._MarginID, objGroup._MarginCallLevel, objGroup._StopOutLevel, objGroup._VirtualCredit, objGroup._TimeOut, objGroup._News, objGroup._MaximumSymbols, objGroup._MaximumOrders, objGroup._GroupPermission, objGroup._EnableGroupPermission);
            //      if (sp_retval == -999)
            //      {
            //          string str = " Exception occured:- DBBO_UpdateIntoGroup";
            //          clsLog.LogSqlErr(str);
            //      }
            //      return sp_retval;
            //  }

            //lock (S_DBBO_UpdateIntoGroupDetails)
            //{
            //    int sp_retval = S_DBBO_UpdateIntoGroupDetails.DBBO_UpdateIntoGroupDetails(objGroup._AccountGroupID, objGroup._AccountGroupName, objGroup._Owner, objGroup._DepositeCurrency, objGroup._Deposite, objGroup._Leverage, objGroup._AnnualInterestRate, objGroup._SecurityIDAccount, objGroup._EnableAccount, objGroup._InActivityPeriod, objGroup._MaximumBalance, objGroup._ArchiveDeletedPendingOrders, objGroup._MarginCallLevel, objGroup._StopOutLevel, objGroup._VirtualCredit, objGroup._TimeOut, objGroup._News, objGroup._MaximumSymbols, objGroup._MaximumOrders, objGroup._GroupPermission, objGroup._EnableGroupPermission, objGroup._SMTPServer, objGroup._SMTPLogin, objGroup._TemplatesPath, objGroup._SMTPPassword, objGroup._SupportEmail, objGroup._IsCopyReport, objGroup._Signature);  // S_DBBO_UpdateIntoGroupDetails.DBBO_UpdateIntoGroupDetails(objGroup._AccountGroupID, objGroup._AccountGroupName, objGroup._Owner, objGroup._DepositeCurrency, objGroup._Deposite, objGroup._Leverage, objGroup._AnnualInterestRate,objGroup._SecurityIDAccount , objGroup._EnableAccount, objGroup._InActivityPeriod, objGroup._MaximumBalance, objGroup._ArchiveDeletedPendingOrders, objGroup._MarginID, objGroup._MarginCallLevel, objGroup._StopOutLevel, objGroup._VirtualCredit, objGroup._TimeOut, objGroup._News, objGroup._MaximumSymbols, objGroup._MaximumOrders, objGroup._GroupPermission, objGroup._EnableGroupPermission);
            //    if(sp_retval == -999)
            //    {
            //        string str = " Exception occured:- DBBO_UpdateIntoGroup";
            //        clsLog.LogSqlErr(str);
            //    }
            //    return sp_retval;
            //}


            return -999;

        }     
     

        public int HandleDBBO_vaildatgroup_user(ClientInfo ObjAccount, string result)
        {
            //lock (S_DBBO_vaildatgroup_user)
            //{
            //    int sp_retval = S_DBBO_vaildatgroup_user.DBBO_vaildatgroup_user(Convert.ToString(ObjAccount._AccountId), ref result);
            //    if (sp_retval == -999)
            //    {
            //        string str = " Exception occured:- DBBO_UpdateTradeComission";
            //        clsLog.LogSqlErr(str);
            //    }
            //    return sp_retval;
            //}
            return 0;
        }
      
        public int HandleDBBO_DeleteSymbol(int ID)
        {
            lock (s_BO_DeleteSymbol)
            {
                int sp_retval = s_BO_DeleteSymbol.BO_DeleteSymbol(ID);
                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_DeleteSymbol";
                    clsLog.LogSqlErr(str);
                }
                return sp_retval;

            }          
        }

        public int HandleBO_UpdateTimeSettings(clsTimeSettings objTime)
        {
            lock (s_UpdateTimeSettings)
            {
                int spRetVal = s_UpdateTimeSettings.BO_UpdateTimeSettings(objTime.Day, objTime.TimeSpan);
                if (spRetVal == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateTimeSettings";
                    clsLog.LogSqlErr(str);
                }
                return spRetVal;
            }
        }


        public int HandleBO_UpdateSymbol(clsContractSpecification ObjSymbol, string sessionString)
        {
            lock (s_UpdateSymbol)
            {
                int sp_retval = s_UpdateSymbol.BO_UpdateSymbol(ObjSymbol.Instruement_ID, ObjSymbol.SymbolName, ObjSymbol.Description, ObjSymbol.Source, ObjSymbol.Digits,
                                                                 clsUtility.GetInt(ObjSymbol.TradingCurrency), clsUtility.GetInt(ObjSymbol.SettlingCurrency), clsUtility.GetInt(ObjSymbol.MarginCurrency),
                                                  clsUtility.GetInt(ObjSymbol.Spread), ObjSymbol.MaximumLots, clsUtility.GetInt(ObjSymbol.Maximum_Order_Value),
                                                                 clsUtility.GetDecimal(ObjSymbol.BuySideTurnover), clsUtility.GetDecimal(ObjSymbol.SellSideTurnover), clsUtility.GetInt(ObjSymbol.MaximumAllowablePosition),
                                                                 ObjSymbol.Hedged,/*ObjSymbol.FreezeLevel ,*/ ObjSymbol.LimitandStopLevel,
                    /*ObjSymbol.SpreadBalance,*/ clsUtility.GetInt(ObjSymbol.TickSize), clsUtility.GetInt(ObjSymbol.TickPrice),
                                                                 ObjSymbol.ContractSize, clsUtility.GetInt(ObjSymbol.QuotationBaseValue), ObjSymbol.Maintenance,
                                                                 clsUtility.GetInt(ObjSymbol.DeliveryType), clsUtility.GetInt(ObjSymbol.DeliveryUnit), ObjSymbol.DeliveryQuantity,
                                                                ObjSymbol.MarketLot, Convert.ToDateTime(ObjSymbol.ExpiryDate), Convert.ToDateTime(ObjSymbol.StartDate), Convert.ToDateTime(ObjSymbol.EndDate),
                                                                 Convert.ToDateTime(ObjSymbol.TenderStartDate), Convert.ToDateTime(ObjSymbol.TenderEndDate), Convert.ToDateTime(ObjSymbol.DeliveryStartDate),
                                                                 Convert.ToDateTime(ObjSymbol.DeliveryEndDate), ObjSymbol.DPRInitialPercentage,
                                                                 ObjSymbol.DPRInterval, ObjSymbol.InitialBuyMargin, ObjSymbol.InitialSellMargin,
                                                                 ObjSymbol.MaintenanceBuyMargin, ObjSymbol.MaintenanceSellMargin, ObjSymbol.ULAssest,
                                                                  ObjSymbol.DPR_Range_Higher, clsUtility.GetInt(ObjSymbol.FK_SecurityTypeID), ObjSymbol.QuoteOffTime, clsUtility.GetInt(ObjSymbol.MarketLostUnit), clsUtility.GetInt(ObjSymbol.MaximumLostUnit), clsUtility.GetInt(ObjSymbol.QuotationBaseValueUnit));

                if (sp_retval == FAILURE_ID)
                {
                    string str = " Exception occured:- BO_UpdateSymbol";
                    clsLog.LogSqlErr(str);
                }
                #region
                else
                {
                    int InstrumentId = ObjSymbol.Instruement_ID;
                    int spretv = s_DeleteSymbolSession.BO_DeleteSymbolSession(ObjSymbol.Instruement_ID);
                    if (spretv == FAILURE_ID)
                    {
                        string str = " Exception occured:- BO_AddSymbolSession";
                        clsLog.LogSqlErr(str);
                    }
                    else
                    {
                        foreach (var item in ObjSymbol.lstSession)
                        {
                            int spretvNew = s_DeleteSymbolSessionNew.BO_DeleteSymbolSessionNew(ObjSymbol.Instruement_ID, (int)item.Day);
                            string[] quoteSessions = item.QuoteSession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int spret = SUCCESS_ID;
                            foreach (string session in quoteSessions)
                            {
                                if (session.Trim() != string.Empty)
                                {
                                    spret = s_AddSymbolQuotesSession.BO_AddSymbolQuotesSession(sp_retval, (int)item.Day,
                                    session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                                    item.IsUseTimelimits, item.StartDate, item.EndDate, session.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                                }
                            }

                            string[] tradeSessions = item.SessionEODMarketMaker.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string session in tradeSessions)
                            {
                                if (session.Trim() != string.Empty)
                                {
                                    string[] _sessionsEODMM = session.Split('_');
                                    spret = s_AddSymbolTradeSession.BO_AddSymbolTradeSession(sp_retval, (int)item.Day,
                                   _sessionsEODMM[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0],
                                   _sessionsEODMM[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1],
                                   Convert.ToBoolean(_sessionsEODMM[1]),
                                   Convert.ToBoolean(_sessionsEODMM[2])
                                   );
                                }
                            }
                            //int spret = s_AddSymbolSession.BO_AddSymbolSession(sp_retval, item.TradeSession, (int)item.Day, item.QuoteSession,
                            //    item.IsUseTimelimits, item.StartDate, item.EndDate);
                            if (spret == FAILURE_ID)
                            {
                                string str = " Exception occured:- BO_AddSymbolSession";
                                clsLog.LogSqlErr(str);
                            }
                            int spInstrumentSwap = s_dbMan_BO_UpdateInstrumentSwap.BO_UpdateInstrumentSwaps(sp_retval, ObjSymbol.InstrumentSwaps.LongPosition,
                          ObjSymbol.InstrumentSwaps.ShortPosition, ObjSymbol.InstrumentSwaps.IsEnable);
                        }
                    }
                }
                #endregion
                return sp_retval;
            }
        }

        public List<BO_GetInstrumentSwapsResult> HandleBO_GetInstrumentSwaps(int instrumentId)
        {
            lock (S_dbMan_BO_GetInstrumentSwaps)
            {
                ISingleResult<BO_GetInstrumentSwapsResult> spRetVal = null;
                try
                {
                    spRetVal = S_dbMan_BO_GetInstrumentSwaps.BO_GetInstrumentSwaps(instrumentId);
                    if ((int)spRetVal.ReturnValue == FAILURE_ID)
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                }
                return spRetVal.ToList();
            }
        }
    }

}
