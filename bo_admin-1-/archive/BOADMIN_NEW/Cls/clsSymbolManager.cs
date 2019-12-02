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
    public class clsSymbolManager : IclsManager
    {
        #region MEMBERS
        static clsSymbolManager _clsSymbolManager = null;
        public DS4Symbol _DS4Symbol = new DS4Symbol();
        List<string> _lstSymbolName = new List<string>();
        List<string> _lstSymbolNameDesc = new List<string>();
        public Dictionary<string, int> ddSymbolContractSize = new Dictionary<string, int>();
        public Dictionary<string, Dictionary<string, List<string>>> ddProductTypeProuctContract = new Dictionary<string, Dictionary<string, List<string>>>();
        public Dictionary<int, string> ddSymbolIdSymbolName = new Dictionary<int, string>();

        #endregion MEMBERS


        #region METHODS
        private clsSymbolManager()
        {

        }

        private void DohandleSessionTable(clsContractSpecification sym, bool isRowExist)
        {
            try
            {
                if (!isRowExist)
                {
                    foreach (clsSymbolSession item in sym.lstSession)
                    {
                        string _sessionEODMarketMaker = "";
                        if (item.SessionEODMarketMaker.EndsWith(","))
                            _sessionEODMarketMaker = item.SessionEODMarketMaker.Remove(item.SessionEODMarketMaker.Length - 1);
                        else
                            _sessionEODMarketMaker = item.SessionEODMarketMaker;
                        _DS4Symbol.dtSession.AdddtSessionRow(sym.Instruement_ID, item.Day.ToString(),
                                                             item.QuoteSession, item.TradeSession,
                                                             item.IsUseTimelimits, item.StartDate,
                                                             item.EndDate, _sessionEODMarketMaker);
                    }
                }
                else
                {
                    DS4Symbol.dtSessionRow[] row = (DS4Symbol.dtSessionRow[])_DS4Symbol.dtSession.Select("FK_InstrumentID = " + sym.Instruement_ID.ToString());
                    if (row.Length == 7)
                    {
                        int index = 0;
                        foreach (clsSymbolSession item in sym.lstSession)
                        {
                            row[index].FK_InstrumentID = sym.Instruement_ID;
                            row[index].Day = item.Day.ToString();
                            row[index].Quotes = item.QuoteSession;
                            row[index].Trade = item.TradeSession;
                            row[index].UseTimeLimits = item.IsUseTimelimits;
                            row[index].StartDate = item.StartDate;
                            row[index].EndDate = item.EndDate;
                            row[index].SessionEODMM = item.SessionEODMarketMaker;
                            index++;

                        }
                    }
                    else if (row.Length < 7)
                    {
                        int index = 0;
                        foreach (clsSymbolSession item in sym.lstSession)
                        {
                            string _sessionEODMarketMaker = "";
                            if (item.SessionEODMarketMaker.EndsWith(","))
                                _sessionEODMarketMaker = item.SessionEODMarketMaker.Remove(item.SessionEODMarketMaker.Length - 1);
                            else
                                _sessionEODMarketMaker = item.SessionEODMarketMaker;
                            if (index <= (row.Length - 1))
                            {
                                row[index].FK_InstrumentID = sym.Instruement_ID;
                                row[index].Day = item.Day.ToString();
                                row[index].Quotes = item.QuoteSession;
                                row[index].Trade = item.TradeSession;
                                row[index].UseTimeLimits = item.IsUseTimelimits;
                                row[index].StartDate = item.StartDate;
                                row[index].EndDate = item.EndDate;
                                row[index].SessionEODMM = _sessionEODMarketMaker;
                            }
                            else
                            {

                                _DS4Symbol.dtSession.AdddtSessionRow(sym.Instruement_ID, item.Day.ToString(),
                                                                     item.QuoteSession, item.TradeSession,
                                                                     item.IsUseTimelimits, item.StartDate,
                                                                     item.EndDate, _sessionEODMarketMaker);

                            }
                            index++;

                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsSymbolManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DohandleSessionTable()");
            }
        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsSymbolManager : Enter FillDataToDataSet()");
                                
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecficationCompleted += new EventHandler<HandleContractSpecficationCompletedEventArgs>(_objCS_HandleContractSpecficationCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleContractSpecfication(clsGlobal.userIDPwd, OperationTypes.GET, null);
                //foreach (clsContractSpecification item in clsProxyClassManager.INSTANCE.GetCsRecords())
                //{
                //    DoHandleSymbolTable(item);
                //}

                //Logging.FileHandling.WriteAllLog("clsSymbolManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsSymbolManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objCS_HandleContractSpecficationCompleted(object sender, HandleContractSpecficationCompletedEventArgs e)
        {
            foreach (clsContractSpecification item in e.Result)
            {
                DoHandleSymbolTable(item);
            }
            
            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleSymbolTable(clsContractSpecification sym)
        {
            try
            {
                if (!ddSymbolIdSymbolName.ContainsKey(sym.Instruement_ID))
                {
                    ddSymbolIdSymbolName.Add(sym.Instruement_ID, sym.SymbolName.Trim().ToUpper());
                }
                DS4Symbol.dtContractInformationRow SymbolRow = _DS4Symbol.dtContractInformation.FindByInstrumentID(sym.Instruement_ID);

                if (SymbolRow == null)
                {
                    SymbolRow = _DS4Symbol.dtContractInformation.NewRow() as DS4Symbol.dtContractInformationRow;
                    SymbolRow.InstrumentID = sym.Instruement_ID;
                    SymbolRow.Symbol = sym.SymbolName;
                    SymbolRow.Description = sym.Description;
                    SymbolRow.Source = sym.Source;                   //Source is productName
                    SymbolRow.Digits = sym.Digits;
                    SymbolRow.UA_Asset = sym.ULAssest;
                    SymbolRow.TradingCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.TradingCurrency)));
                    SymbolRow.SettlingCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.SettlingCurrency)));
                    SymbolRow.MarginCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.MarginCurrency)));
                    //SymbolRow.Orders = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetOrderType(Convert.ToInt32(sym.Orders)));
                    SymbolRow.Spread = sym.Spread;
                    SymbolRow.MaximumLots = sym.MaximumLots;
                    SymbolRow.MaximumOrderValue = sym.Maximum_Order_Value;
                    SymbolRow.BuySideTurnover = sym.BuySideTurnover;
                    SymbolRow.SellSideTurnover = sym.SellSideTurnover;
                    SymbolRow.MaximumAllowablePosition = sym.MaximumAllowablePosition;
                    SymbolRow.QuotationBaseValue = sym.QuotationBaseValue;
                    SymbolRow.DeliveryType = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryType(Convert.ToInt32(sym.DeliveryType)));
                    SymbolRow.DeliveryUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(Convert.ToInt32(sym.DeliveryUnit)));
                    SymbolRow.DeliveryQuantity = sym.DeliveryQuantity;
                    SymbolRow.MarketLot = sym.MarketLot;
                    if (sym.ExpiryDate == "")
                    {
                        SymbolRow.ExpiryDate = sym.ExpiryDate;
                    }
                    else
                    {
                        SymbolRow.ExpiryDate = Convert.ToDateTime(sym.ExpiryDate).ToShortDateString();
                    }
                    SymbolRow.StartDate = sym.StartDate;
                    SymbolRow.EndDate = sym.EndDate;
                    SymbolRow.TenderStartDate = sym.TenderStartDate;
                    SymbolRow.TenderEndDate = sym.TenderEndDate;
                    SymbolRow.DeliveryStartDate = sym.DeliveryStartDate;
                    SymbolRow.DeliveryEndDate = sym.DeliveryEndDate;
                    SymbolRow.DPRInitialPercentage = sym.DPRInitialPercentage;
                    SymbolRow.DPR_Range_Higher = sym.DPR_Range_Higher;
                    SymbolRow.DPRInterval = sym.DPRInterval;
                    SymbolRow.LimitandStopLevel = sym.LimitandStopLevel.ToString();
                    //SymbolRow.SpreadBalance = sym.SpreadBalance.ToString();
                    //SymbolRow.FreezeLevel = sym.FreezeLevel.ToString();
                    SymbolRow.SecurityType = clsUtility.GetStr(clsSecurityManager.INSTANCE.GetSecuritiesName(Convert.ToInt32(sym.FK_SecurityTypeID)));
                    SymbolRow.ContractSize = sym.ContractSize.ToString();
                    SymbolRow.InitialBuyMargin = sym.InitialBuyMargin;
                    SymbolRow.InitialSellMargin = sym.InitialSellMargin;
                    SymbolRow.MaintenanceBuyMargin = sym.MaintenanceBuyMargin;
                    SymbolRow.MaintenanceSellMargin = sym.MaintenanceSellMargin;
                    SymbolRow.Hedged = sym.Hedged.ToString();
                    SymbolRow.TickSize = sym.TickSize.ToString();
                    SymbolRow.TickPrice = sym.TickPrice.ToString();
                    SymbolRow.MaximumLostUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(clsUtility.GetInt(sym.MaximumLostUnit)));
                    SymbolRow.MarketLostUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(clsUtility.GetInt(sym.MarketLostUnit)));
                    SymbolRow.QuotationBaseValueUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(clsUtility.GetInt(sym.QuotationBaseValueUnit)));
                    SymbolRow.QuoteOffTime = sym.QuoteOffTime;

                    if (!ddSymbolContractSize.ContainsKey(SymbolRow.Symbol))
                    {
                        ddSymbolContractSize.Add(SymbolRow.Symbol, sym.ContractSize);
                    }
                    else
                    {
                        ddSymbolContractSize[SymbolRow.Symbol] = sym.ContractSize;
                    }

                    _lstSymbolNameDesc.Add(SymbolRow.Symbol + ", " + SymbolRow.Description);
                    if (!_lstSymbolName.Contains(SymbolRow.Symbol))
                    {
                        _lstSymbolName.Add(SymbolRow.Symbol);
                    }
                    _DS4Symbol.dtContractInformation.AdddtContractInformationRow(SymbolRow);
                    if (ddProductTypeProuctContract.ContainsKey(SymbolRow.SecurityType))
                    {
                        if (ddProductTypeProuctContract[SymbolRow.SecurityType].ContainsKey(SymbolRow.Source))
                        {
                            if (!ddProductTypeProuctContract[SymbolRow.SecurityType][SymbolRow.Source].Contains(SymbolRow.Symbol))
                            {
                                ddProductTypeProuctContract[SymbolRow.SecurityType][SymbolRow.Source].Add(SymbolRow.Symbol);
                            }
                        }
                        else
                        {
                            List<string> lstContract = new List<string>();
                            lstContract.Add(SymbolRow.Symbol);
                            ddProductTypeProuctContract[SymbolRow.SecurityType].Add(SymbolRow.Source, lstContract);
                        }
                    }
                    else
                    {
                        Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
                        List<string> lstContract = new List<string>();
                        lstContract.Add(SymbolRow.Symbol);
                        temp.Add(SymbolRow.Source, lstContract);
                        ddProductTypeProuctContract.Add(SymbolRow.SecurityType, temp);
                    }
                    //DohandleInstrumentSwapTable(sym, false); //Namo
                    DohandleSessionTable(sym, false);
                }
                else
                {
                    SymbolRow.InstrumentID = sym.Instruement_ID;
                    SymbolRow.Symbol = sym.SymbolName;
                    SymbolRow.Description = sym.Description;
                    SymbolRow.Source = sym.Source;                   //Source is productName
                    SymbolRow.Digits = sym.Digits;
                    SymbolRow.UA_Asset = sym.ULAssest;
                    SymbolRow.TradingCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.TradingCurrency)));
                    SymbolRow.SettlingCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.SettlingCurrency)));
                    SymbolRow.MarginCurrency = clsUtility.GetStr(clsCurrencyManager.INSTANCE.GetCurrency(Convert.ToInt32(sym.MarginCurrency)));
                    //SymbolRow.Orders = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetOrderType(Convert.ToInt32(sym.Orders)));
                    SymbolRow.Spread = sym.Spread;
                    SymbolRow.MaximumLots = sym.MaximumLots;
                    SymbolRow.MaximumOrderValue = sym.Maximum_Order_Value;
                    SymbolRow.BuySideTurnover = sym.BuySideTurnover;
                    SymbolRow.SellSideTurnover = sym.SellSideTurnover;
                    SymbolRow.MaximumAllowablePosition = sym.MaximumAllowablePosition;
                    SymbolRow.QuotationBaseValue = sym.QuotationBaseValue;
                    SymbolRow.DeliveryType = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryType(Convert.ToInt32(sym.DeliveryType)));
                    SymbolRow.DeliveryUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(Convert.ToInt32(sym.DeliveryUnit)));
                    SymbolRow.DeliveryQuantity = sym.DeliveryQuantity;
                    SymbolRow.MarketLot = sym.MarketLot;
                    if (sym.ExpiryDate == "")
                    {
                        SymbolRow.ExpiryDate = sym.ExpiryDate;
                    }
                    else
                    {
                        SymbolRow.ExpiryDate = Convert.ToDateTime(sym.ExpiryDate).ToShortDateString();
                    }
                    SymbolRow.StartDate = sym.StartDate;
                    SymbolRow.EndDate = sym.EndDate;
                    SymbolRow.TenderStartDate = sym.TenderStartDate;
                    SymbolRow.TenderEndDate = sym.TenderEndDate;
                    SymbolRow.DeliveryStartDate = sym.DeliveryStartDate;
                    SymbolRow.DeliveryEndDate = sym.DeliveryEndDate;
                    SymbolRow.DPRInitialPercentage = sym.DPRInitialPercentage;
                    SymbolRow.DPR_Range_Higher = sym.DPR_Range_Higher;
                    SymbolRow.DPRInterval = sym.DPRInterval;
                    SymbolRow.LimitandStopLevel = sym.LimitandStopLevel.ToString();
                    //SymbolRow.SpreadBalance = sym.SpreadBalance.ToString();
                    //SymbolRow.FreezeLevel = sym.FreezeLevel.ToString();
                    SymbolRow.SecurityType = clsUtility.GetStr(clsSecurityManager.INSTANCE.GetSecuritiesName(Convert.ToInt32(sym.FK_SecurityTypeID)));
                    SymbolRow.ContractSize = sym.ContractSize.ToString();
                    SymbolRow.InitialBuyMargin = sym.InitialBuyMargin;
                    SymbolRow.InitialSellMargin = sym.InitialSellMargin;
                    SymbolRow.MaintenanceBuyMargin = sym.MaintenanceBuyMargin;
                    SymbolRow.MaintenanceSellMargin = sym.MaintenanceSellMargin;
                    SymbolRow.Hedged = sym.Hedged.ToString();
                    SymbolRow.TickSize = sym.TickSize.ToString();
                    SymbolRow.TickPrice = sym.TickPrice.ToString();
                    SymbolRow.MaximumLostUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(Convert.ToInt32(sym.MaximumLostUnit)));
                    SymbolRow.MarketLostUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(Convert.ToInt32(sym.MarketLostUnit)));
                    SymbolRow.QuotationBaseValueUnit = clsUtility.GetStr(clsMasterInfoManager.INSTANCE.GetDeliveryUnit(Convert.ToInt32(sym.QuotationBaseValueUnit)));
                    SymbolRow.QuoteOffTime = sym.QuoteOffTime;
                    if (!ddSymbolContractSize.ContainsKey(SymbolRow.Symbol))
                    {
                        ddSymbolContractSize.Add(SymbolRow.Symbol, sym.ContractSize);
                    }
                    else
                    {
                        ddSymbolContractSize[SymbolRow.Symbol]= sym.ContractSize;
                    }
                    if (ddProductTypeProuctContract.ContainsKey(SymbolRow.SecurityType))
                    {
                        if (ddProductTypeProuctContract[SymbolRow.SecurityType].ContainsKey(SymbolRow.Source))
                        {
                            if (!ddProductTypeProuctContract[SymbolRow.SecurityType][SymbolRow.Source].Contains(SymbolRow.Symbol))
                            {
                                ddProductTypeProuctContract[SymbolRow.SecurityType][SymbolRow.Source].Add(SymbolRow.Symbol);
                            }
                        }
                        else
                        {
                            List<string> lstContract = new List<string>();
                            lstContract.Add(SymbolRow.Symbol);
                            ddProductTypeProuctContract[SymbolRow.SecurityType].Add(SymbolRow.Source, lstContract);
                        }
                    }
                    else
                    {
                        Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
                        List<string> lstContract = new List<string>();
                        lstContract.Add(SymbolRow.Symbol);
                        temp.Add(SymbolRow.Source, lstContract);
                        ddProductTypeProuctContract.Add(SymbolRow.SecurityType, temp);
                    }
                    DS4Symbol.dtSessionRow[] SessionRow = (DS4Symbol.dtSessionRow[])_DS4Symbol.dtSession.Select("FK_InstrumentID = " + sym.Instruement_ID.ToString()); //Namo
                    if (SessionRow.Length == 0)
                    {
                        DohandleSessionTable(sym, false);
                    }
                    else
                        DohandleSessionTable(sym, true);
                    //DohandleInstrumentSwapTable(sym, true);                
                }
                //_DS4Symbol.AcceptChanges();
                _DS4Symbol.dtContractInformation.AcceptChanges();
                _DS4Symbol.dtSession.AcceptChanges();
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsSymbolManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleSymbolTable()");
            }
        }

        private void DohandleInstrumentSwapTable(clsContractSpecification sym, bool isRowExist)
        {
            if (!isRowExist)
            {
                _DS4Symbol.dtInstrumentSwaps.AdddtInstrumentSwapsRow(sym.Instruement_ID, sym.InstrumentSwaps.LongPosition, sym.InstrumentSwaps.ShortPosition,
                    sym.InstrumentSwaps.IsEnable);
            }
            else
            {
                DS4Symbol.dtInstrumentSwapsRow row = _DS4Symbol.dtInstrumentSwaps.FirstOrDefault(ROW => ROW.FK_InstrumentID == sym.Instruement_ID);
                row.LongPosition = sym.InstrumentSwaps.LongPosition;
                row.ShortPosition = sym.InstrumentSwaps.ShortPosition;
                row.IsEnable = sym.InstrumentSwaps.IsEnable;
            }
        }

        public string[] GetSymbolNameArray()
        {
            _lstSymbolName.Sort();
            return _lstSymbolName.ToArray();
        }

        public string[] GetSymbolNameWithDescArray()
        {
            return _lstSymbolNameDesc.ToArray();
        }
        public string GetSymbolName(int SymbolId)
        {
            DS4Symbol.dtContractInformationRow SymbolRow = _DS4Symbol.dtContractInformation.FindByInstrumentID(SymbolId);
            if (SymbolRow == null)
                return null;
            return SymbolRow.Symbol;

        }
        public int GetSymbolId(string SymbolName)
        {
            DS4Symbol.dtContractInformationRow[] SymbolRow = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("Symbol = '" + SymbolName + "'");
            if (SymbolRow[0] == null)
                return 0;
            return SymbolRow[0].InstrumentID;

        }

        public string GetSecurityType(string SymbolName)
        {
            DS4Symbol.dtContractInformationRow[] SymbolRow = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("Symbol = '" + SymbolName + "'");

            if (SymbolRow[0] == null)
                return string.Empty;
            return SymbolRow[0].SecurityType;

        }

        public DS4Symbol.dtSessionRow[] GetSession(int InstrumentId)
        {
            DS4Symbol.dtSessionRow[] rows = null;

            rows = (DS4Symbol.dtSessionRow[])_DS4Symbol.dtSession.Select("FK_InstrumentID = " + InstrumentId.ToString());

            return rows;

        }

        #endregion METHODS


        #region PROPERTY
        public static clsSymbolManager INSTANCE
        {
            get
            {
                if (_clsSymbolManager == null)
                {
                    _clsSymbolManager = new clsSymbolManager();
                }
                return _clsSymbolManager;
            }
        }
        #endregion PROPERTY
        #region IclsManager

        public override void AddSetting(IProtocolStruct PS)
        {
            lock (_DS4Symbol.dtContractInformation)
            {
                //DoHandleSymbolTable((PS as SymbolPS)._Symbol);
            }


        }

        public override void RemoveSetting(string DataKey)
        {
            int InstrumentID = -999;
            try
            {
                InstrumentID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4Symbol.dtContractInformationRow SymbolRow = _DS4Symbol.dtContractInformation.FindByInstrumentID(InstrumentID);

            lock (_DS4Symbol.dtContractInformation)
            {
                _DS4Symbol.dtContractInformation.RemovedtContractInformationRow(SymbolRow);
            }

        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        #endregion IclsManager

        public DS4Symbol.dtContractInformationRow[] GetContractInformationBySecurityType(string securityType)
        {
            if (securityType == "")
                return null;
            DS4Symbol.dtContractInformationRow[] rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("SecurityType = '" + securityType + "'");
            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public DS4Symbol.dtContractInformationRow[] GetContractInformationByProductName(string productName)
        {
            if (productName == "")
                return null;
            DS4Symbol.dtContractInformationRow[] rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("Source = '" + productName + "'");
            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public DS4Symbol.dtContractInformationRow[] GetRow(string securityType, string productName, string symbol, string expiryDate)
        {
            expiryDate = Convert.ToDateTime(expiryDate).ToShortDateString();
            DS4Symbol.dtContractInformationRow[] rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("SecurityType = '" + securityType + "'" + "and  Source = '"
                + productName + "'" + "and Symbol = '" + symbol + "'" + "and  ExpiryDate = '" + expiryDate + "'");

            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public DS4Symbol.dtContractInformationRow[] GetRows(string expiryDate)
        {
            expiryDate = Convert.ToDateTime(expiryDate).ToShortDateString();
            DS4Symbol.dtContractInformationRow[] rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("ExpiryDate = '" + expiryDate + "'");

            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public DS4Symbol.dtContractInformationRow[] GetCSInfoByProductandSecurity(string securityType, string productName)
        {
            if (securityType == "" || productName == "")
                return null;
            DS4Symbol.dtContractInformationRow[] rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select("SecurityType = '" + securityType +
                "'" + "and  Source = '" + productName + "'");

            if (rows.Count() == 0)
                return null;

            return rows;
        }

        public DS4Symbol.dtContractInformationRow[] GetRows(string securityType, string productName, string symbol)
        {
            DS4Symbol.dtContractInformationRow[] rows = null;

            if (securityType == "All" && productName == "All")
            {
                rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select(
                "Symbol = '" + symbol + "'");
            }
            else if (securityType != "All" && productName != "All")
            {
                rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select(
                "SecurityType = '" + securityType + "'" + "and  Source = '"
                + productName + "'" + "and Symbol = '" + symbol + "'");
            }
            else if (securityType == "All" && productName != "All")
            {
                rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select(
                 "Source = '" + productName + "'" + "and Symbol = '" + symbol + "'");
            }
            else if (securityType != "All" && productName == "All")
            {
                rows = (DS4Symbol.dtContractInformationRow[])_DS4Symbol.dtContractInformation.Select(
                "SecurityType = '" + securityType + "'" + "and Symbol = '" + symbol + "'");
            }
            if (rows.Count() == 0)
                return null;

            return rows;
        }

    }
}
