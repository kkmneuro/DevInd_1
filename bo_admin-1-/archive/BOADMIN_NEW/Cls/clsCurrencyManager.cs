using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOADMIN_NEW.Cls;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;
namespace BOADMIN_NEW.Cls
{
    public class clsCurrencyManager : IclsManager
    {
        static clsCurrencyManager _clsCurrencyManager = null;
        public DS4Currency _DS4Currency = new DS4Currency();
        List<string> _lstCurrency = new List<string>();
        private clsCurrencyManager()
        {
        }
        #region PROPERTY
        public static clsCurrencyManager INSTANCE
        {
            get
            {
                if (_clsCurrencyManager == null)
                {
                    _clsCurrencyManager = new clsCurrencyManager();
                }
                return _clsCurrencyManager;
            }
        }
        #endregion PROPERTY


        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.Currency_ID:
                    //DoHandleCurrency((PS as CurrencyPS)._Currency);
                    break;
                default:
                    break;
            }
        }

        public void FillDataToDataSet()
        {
            clsProxyClassManager.INSTANCE._objBOEngineClient.GetCurrencyListCompleted += new EventHandler<GetCurrencyListCompletedEventArgs>(_objMasterInfoClient_GetCurrencyListCompleted);
            clsProxyClassManager.INSTANCE._objBOEngineClient.GetCurrencyListAsync(clsGlobal.userIDPwd);
            //foreach (clsCurrency currency in clsProxyClassManager.INSTANCE.GetCurrencyList())
            //{
            //    DoHandleCurrency(currency);
            //}
        }

        void _objMasterInfoClient_GetCurrencyListCompleted(object sender, GetCurrencyListCompletedEventArgs e)
        {
            foreach (clsCurrency currency in e.Result)
            {
                DoHandleCurrency(currency);
            }
        }
        public void DoHandleCurrency(clsCurrency currency)
        {
            try
            {
                DS4Currency.dtCurrencyRow currencyRow = _DS4Currency.dtCurrency.FindByPK_Currency_ID(currency.Currency_ID);
                if (currencyRow == null)
                {
                    currencyRow = _DS4Currency.dtCurrency.NewRow() as DS4Currency.dtCurrencyRow;
                    currencyRow.CurrencyDescription = currency.CurrencyDescription;
                    currencyRow.CurrencyName = currency.CurrencyName;
                    currencyRow.PK_Currency_ID = currency.Currency_ID;
                    _DS4Currency.dtCurrency.AdddtCurrencyRow(currencyRow);
                    if (currency.CurrencyName != string.Empty)
                        _lstCurrency.Add(currency.CurrencyName);
                }
                else
                {
                    currencyRow.CurrencyDescription = currency.CurrencyDescription;
                    currencyRow.CurrencyName = currency.CurrencyName;
                    currencyRow.PK_Currency_ID = currency.Currency_ID;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsCurrencyManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleCurrency()");
            }
        }

        public string[] GetCurrencyArray()
        {
            return _lstCurrency.ToArray();
        }

        public string GetCurrency(int currencyId)
        {
            DS4Currency.dtCurrencyRow _currencyRow = _DS4Currency.dtCurrency.FindByPK_Currency_ID(currencyId);
            if (_currencyRow == null)
                return null;
            return _currencyRow.CurrencyName;
        }

        public int GetCurrencyId(string currencyName)
        {

            DS4Currency.dtCurrencyRow[] _currencyRows = (DS4Currency.dtCurrencyRow[])_DS4Currency.dtCurrency.Select("CurrencyName = '" + currencyName + "'");
            if (_currencyRows == null)
                return 0;
            return _currencyRows[0].PK_Currency_ID;
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
