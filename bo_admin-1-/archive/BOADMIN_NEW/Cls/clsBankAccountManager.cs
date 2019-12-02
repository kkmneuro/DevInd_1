using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOADMIN_NEW.Cls;
using ProtocolStructs;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsBankAccountManager : IclsManager
    {
        static clsBankAccountManager _clsBankAccountManager = null;
        public DS4BankAccount _DS4BankAccount = new DS4BankAccount();
        List<string> _lstBankAccount = new List<string>();
        private clsBankAccountManager()
        {
        }
        #region PROPERTY
        public static clsBankAccountManager INSTANCE
        {
            get
            {
                if (_clsBankAccountManager == null)
                {
                    _clsBankAccountManager = new clsBankAccountManager();
                }
                return _clsBankAccountManager;
            }
        }
        #endregion PROPERTY


        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.Bank_ID:
                    DoHandleBankAccount((PS as BankPS)._Bank);
                    break;
                default:
                    break;
            }
        }

        private void DoHandleBankAccount(Bank bank)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsBankAccountManager : Enter DoHandleBankAccount()");
                DS4BankAccount.dtBankInformationRow bankInformationRow = _DS4BankAccount.dtBankInformation.FindByPK_BankID(bank._BankID);
                if (bankInformationRow == null)
                {
                    bankInformationRow = _DS4BankAccount.dtBankInformation.NewRow() as DS4BankAccount.dtBankInformationRow;
                    bankInformationRow.AccountHolderName = bank._AccountHolderName;
                    bankInformationRow.BankAccountID = bank._BankAccountID;
                    bankInformationRow.BankAccountType = bank._BankAccountType;
                    bankInformationRow.BankAddress1 = bank._BankAddress;
                    bankInformationRow.BankAddress2 = bank._BankAddress2;
                    bankInformationRow.BankCity = bank._BankCity;
                    bankInformationRow.BankFax = bank._BankFax;
                    bankInformationRow.BankIFSCCode = bank._BankIFSCCode;
                    bankInformationRow.BankName = bank._BankName;
                    bankInformationRow.BankPhone = bank._BankPhone;
                    bankInformationRow.BankSwiftCode = bank._BankSwiftCode;
                    bankInformationRow.BankZipCode = bank._BankZipCode;
                    bankInformationRow.FK_BankCountryID = bank._BankCountryID;
                    bankInformationRow.FK_ParticipantID = bank._ClientID;
                    bankInformationRow.PK_BankID = bank._BankID;
                    _DS4BankAccount.dtBankInformation.AdddtBankInformationRow(bankInformationRow);
                    _lstBankAccount.Add(bank._BankName);
                }
                else
                {
                    bankInformationRow.AccountHolderName = bank._AccountHolderName;
                    bankInformationRow.BankAccountID = bank._BankAccountID;
                    bankInformationRow.BankAccountType = bank._BankAccountType;
                    bankInformationRow.BankAddress1 = bank._BankAddress;
                    bankInformationRow.BankAddress2 = bank._BankAddress2;
                    bankInformationRow.BankCity = bank._BankCity;
                    bankInformationRow.BankFax = bank._BankFax;
                    bankInformationRow.BankIFSCCode = bank._BankIFSCCode;
                    bankInformationRow.BankName = bank._BankName;
                    bankInformationRow.BankPhone = bank._BankPhone;
                    bankInformationRow.BankSwiftCode = bank._BankSwiftCode;
                    bankInformationRow.BankZipCode = bank._BankZipCode;
                    bankInformationRow.FK_BankCountryID = bank._BankCountryID;
                    bankInformationRow.FK_ParticipantID = bank._ClientID;
                    bankInformationRow.PK_BankID = bank._BankID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsBankAccountManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleBankAccount()");
            }
        }

        public string[] GetBankAccountsArray()
        {
            return _lstBankAccount.ToArray();
        }
        public DS4BankAccount.dtBankInformationRow[] GetBankAccounts(int ClientId)
        {
            DS4BankAccount.dtBankInformationRow[] _bankRows = (DS4BankAccount.dtBankInformationRow[])_DS4BankAccount.dtBankInformation.Select("FK_ParticipantID = " + ClientId + "");
            if (_bankRows == null)
                return null;
            else
                return _bankRows;
        }
        //public int GetCountryId(int bankId)
        //{

        //    DS4BankAccount.dtBankInformationRow[] _currencyRows = (DS4Currency.dtCurrencyRow[])_DS4Currency.dtCurrency.Select("PK_Currency_ID = " + currencyId + "");
        //    if (_currencyRows == null)
        //        return 0;
        //    return _currencyRows[0].FK_CountryID;
        //}
        //public int GetCountryId(string currencyName)
        //{

        //    DS4BankAccount.dtBankInformationRow[] _currencyRows = (DS4Currency.dtCurrencyRow[])_DS4Currency.dtCurrency.Select("CurrencyName = '" + currencyName + "'");
        //    if (_currencyRows == null)
        //        return 0;
        //    return _currencyRows[0].FK_CountryID;
        //}
        //public string GetBankAccountNo(int bankId)
        //{
        //    DS4BankAccount.dtBankInformationRow _currencyRow = _DS4Currency.dtCurrency.FindByPK_Currency_ID(currencyId);
        //    if (_currencyRow == null)
        //        return null;
        //    return _currencyRow.CurrencyName;
        //}
        //public string GetTradeAccountNo(int bankId)
        //{
        //    DS4BankAccount.dtBankInformationRow _bankInformationRow = _DS4BankAccount.dtBankInformation.FindByPK_BankID(bankId);
        //    if (_bankInformationRow == null)
        //        return null;
        //    return _bankInformationRow.CurrencyName;
        //}

        //public int GetCurrencyId(string currencyName)
        //{

        //    DS4BankAccount.dtBankInformationRow[] _currencyRows = (DS4Currency.dtCurrencyRow[])_DS4Currency.dtCurrency.Select("CurrencyName = '" + currencyName + "'");
        //    if (_currencyRows == null)
        //        return 0;
        //    return _currencyRows[0].PK_Currency_ID;
        //}

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
