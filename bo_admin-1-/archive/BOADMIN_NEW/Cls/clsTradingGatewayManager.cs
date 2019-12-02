using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;
using clsInterface4OME.DSBO;
using ProtocolStructs;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    public class clsTradingGatewayManager : IclsManager
    {
        #region "   MEMBERS   "

        static clsTradingGatewayManager _clsTradingGatewayManager = null;
        public DS4TradingGateway _DS4TradingGateway = new DS4TradingGateway();
        List<string> _lstDataType = new List<string>();
        List<string> _lstIdleTimeOut = new List<string>();
        List<string> _lstReconnectAfter = new List<string>();


        #endregion "    MEMBERS  "

        #region "    PROPERTY     "

        public static clsTradingGatewayManager INSTANCE
        {
            get
            {
                if (_clsTradingGatewayManager == null)
                {
                    _clsTradingGatewayManager = new clsTradingGatewayManager();
                }
                return _clsTradingGatewayManager;
            }
        }

        #endregion "    PROPERTY     "

        private clsTradingGatewayManager()
        {

        }

        public void FillDataToDataSet()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsTradingGatewayManager : Enter FillDataToDataSet()");
                
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTradingGatewayCompleted += new EventHandler<HandleTradingGatewayCompletedEventArgs>(_objTradingGatewayClient_HandleTradingGatewayCompleted);
                clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTradingGatewayAsync(clsGlobal.userIDPwd,OperationTypes.GET,null);


                //Logging.FileHandling.WriteAllLog("clsTradingGatewayManager : Exit FillDataToDataSet()");
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTradingGatewayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in FillDataToDataSet()");
            }
        }

        void _objTradingGatewayClient_HandleTradingGatewayCompleted(object sender, HandleTradingGatewayCompletedEventArgs e)
        {
            foreach (clsTradingGateway item in e.Result)
            {
                DoHandleTradingGatewayTable(item);
            }
            
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTGAccountConnetionSettingsCompleted +=_objTGAccountConnectionSettingsClient_HandleTGAccountConnetionSettingsCompleted;
            clsProxyClassManager.INSTANCE._objBOEngineClient.HandleTGAccountConnetionSettingsAsync(clsGlobal.userIDPwd,OperationTypes.GET,null);
        }

        void _objTGAccountConnectionSettingsClient_HandleTGAccountConnetionSettingsCompleted(object sender, HandleTGAccountConnetionSettingsCompletedEventArgs e)
        {
            foreach (clsTGAccountConnectionSettings item2 in e.Result)
            {
                DoHandleAccountConnectionSettings(item2);
            }            

            FrmMain.Instance.stopProgressBar();
        }

        public void DoHandleTradingGatewayTable(clsTradingGateway tradingGateway)
        {
            try
            {
                DS4TradingGateway.dtTradingGatewayRow tradingGatewayRow = _DS4TradingGateway.dtTradingGateway.FindByPK_TradingGateWaysID(tradingGateway.PKTradingGateWaysID);
                if (tradingGatewayRow == null)
                {
                    tradingGatewayRow = _DS4TradingGateway.dtTradingGateway.NewRow() as DS4TradingGateway.dtTradingGatewayRow;
                    tradingGatewayRow.PK_TradingGateWaysID = tradingGateway.PKTradingGateWaysID;
                    tradingGatewayRow.Name = tradingGateway.Name;
                    tradingGatewayRow.Description = tradingGateway.Description;
                    tradingGatewayRow.Server_IP = tradingGateway.ServerIP;
                    tradingGatewayRow.Port = tradingGateway.Port;
                    tradingGatewayRow.DataType = tradingGateway.DataType;
                    tradingGatewayRow.Login = tradingGateway.Login;
                    tradingGatewayRow.Password = tradingGateway.Password;
                    tradingGatewayRow.IdleTimeOut = tradingGateway.IdleTimeOut;
                    tradingGatewayRow.ReconnectAfter = tradingGateway.ReconnectAfter;
                    tradingGatewayRow.SleepFor = tradingGateway.SleepFor;
                    tradingGatewayRow.Attempts = tradingGateway.Attempts;
                    tradingGatewayRow.IsEnable = tradingGateway.IsEnable;

                    _DS4TradingGateway.dtTradingGateway.AdddtTradingGatewayRow(tradingGatewayRow);
                    DoHandleSymbolInfo(tradingGateway, false);
                    //DoHandleAccountConnectionSettings(tradingGateway, false);
                    if (!_lstDataType.Contains(tradingGateway.DataType.ToString()))
                    {
                        _lstDataType.Add(tradingGateway.DataType.ToString());
                    }
                    if (!_lstIdleTimeOut.Contains(tradingGateway.IdleTimeOut.ToString()))
                    {
                        _lstIdleTimeOut.Add(tradingGateway.IdleTimeOut.ToString());
                    }
                    if (!_lstReconnectAfter.Contains(tradingGateway.ReconnectAfter.ToString()))
                    {
                        _lstReconnectAfter.Add(tradingGateway.ReconnectAfter.ToString());
                    }
                    tradingGatewayRow.EnableRMS = tradingGateway.EnableRMS;
                    tradingGatewayRow.OrderPort = tradingGateway.OrderPort;
                    tradingGatewayRow.OrderIP = tradingGateway.OrderIP;
                }
                else
                {

                    tradingGatewayRow.PK_TradingGateWaysID = tradingGateway.PKTradingGateWaysID;
                    tradingGatewayRow.Name = tradingGateway.Name;
                    tradingGatewayRow.Description = tradingGateway.Description;
                    tradingGatewayRow.Server_IP = tradingGateway.ServerIP;
                    tradingGatewayRow.Port = tradingGateway.Port;
                    tradingGatewayRow.DataType = tradingGateway.DataType;
                    tradingGatewayRow.Login = tradingGateway.Login;
                    tradingGatewayRow.Password = tradingGateway.Password;
                    tradingGatewayRow.IdleTimeOut = tradingGateway.IdleTimeOut;
                    tradingGatewayRow.ReconnectAfter = tradingGateway.ReconnectAfter;
                    tradingGatewayRow.SleepFor = tradingGateway.SleepFor;
                    tradingGatewayRow.Attempts = tradingGateway.Attempts;
                    tradingGatewayRow.IsEnable = tradingGateway.IsEnable;
                    tradingGatewayRow.EnableRMS = tradingGateway.EnableRMS;
                    tradingGatewayRow.OrderPort = tradingGateway.OrderPort;
                    tradingGatewayRow.OrderIP = tradingGateway.OrderIP;

                    DoHandleSymbolInfo(tradingGateway, true);
                    // DoHandleAccountConnectionSettings(tradingGateway, true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTradingGatewayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleTradingGatewayTable()");
            }
        }

        public void DoHandleAccountConnectionSettings(BOEngineServiceTCP.clsTGAccountConnectionSettings TGAccountSettings)//TradingGateway tradingGateway, bool isRowExists)
        {
            try
            {
                DS4TradingGateway.dtAccountConnectionSettingsRow row = _DS4TradingGateway.dtAccountConnectionSettings.FirstOrDefault(x => x.FK_TradingGatewaysID == TGAccountSettings.TGID
                            && x.AccountID == TGAccountSettings.AccountId);
                if (row == null)
                {
                    row = (DS4TradingGateway.dtAccountConnectionSettingsRow)_DS4TradingGateway.dtAccountConnectionSettings.NewdtAccountConnectionSettingsRow();

                    row.FK_TradingGatewaysID = TGAccountSettings.TGID;
                    row.AccountID = TGAccountSettings.AccountId;
                    row.Password = TGAccountSettings.Password;
                    row.IsEnable = TGAccountSettings.IsEnable;

                    _DS4TradingGateway.dtAccountConnectionSettings.AdddtAccountConnectionSettingsRow(row);
                }
                else
                {
                    row.FK_TradingGatewaysID = TGAccountSettings.TGID;
                    row.AccountID = TGAccountSettings.AccountId;
                    row.Password = TGAccountSettings.Password;
                    row.IsEnable = TGAccountSettings.IsEnable;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTradingGatewayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleAccountConnectionSettings()");
            }
            UpdateTGAccountConnetionSettins();
        }

        public string[] GetDataTypeArray()
        {
            return _lstDataType.ToArray();
        }
        public string[] GetIdleTimeOutArray()
        {
            return _lstIdleTimeOut.ToArray();
        }
        public string[] GetReconnectAfterArray()
        {
            return _lstReconnectAfter.ToArray();
        }
        public void DoHandleSymbolInfo(clsTradingGateway tradingGateway, bool isRowExist)
        {
            try
            {
                if (!isRowExist)
                {
                    foreach (string item in tradingGateway.LstSymbol)
                    {
                        if (tradingGateway.LstSymbolAlias[tradingGateway.LstSymbol.ToList().IndexOf(item)] == null)
                        {
                            _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false, item, "", 0,"","");
                        }
                        else
                        {
                            int index=tradingGateway.LstSymbol.ToList().IndexOf(item);
                            _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false, item,
                                tradingGateway.LstSymbolAlias[index]
                                , tradingGateway.LstSymbolConversionFormula[index],
                                tradingGateway.LstProductName[index],tradingGateway.LstProductAlias[index]);
                        }
                    }
                }
                else
                {
                    DS4TradingGateway.dtSymbolRow[] row = (DS4TradingGateway.dtSymbolRow[])_DS4TradingGateway.dtSymbol.Select("FK_TradingGatewayID = " + tradingGateway.PKTradingGateWaysID.ToString() + " ");
                    if (tradingGateway.LstSymbol.ToList().Count == 0)
                    {
                        foreach (DS4TradingGateway.dtSymbolRow rows in row)
                        {
                            _DS4TradingGateway.dtSymbol.RemovedtSymbolRow(rows);

                        }
                        return;
                    }

                    if (row.Count() == 0)
                    {
                        foreach (string symbol in tradingGateway.LstSymbol)
                        {
                            if (tradingGateway.LstSymbolAlias[tradingGateway.LstSymbol.ToList().IndexOf(symbol)] == null)
                            {
                                _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false, symbol, "", 0,"","");
                            }
                            else
                            {
                                int index = tradingGateway.LstSymbol.ToList().IndexOf(symbol);
                                _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false, symbol,
                                    tradingGateway.LstSymbolAlias[index],
                                    tradingGateway.LstSymbolConversionFormula[index],
                                    tradingGateway.LstProductName[index], tradingGateway.LstProductAlias[index]);
                            }
                        }
                        return;
                    }
                    //List<string> _lstSymbols=new List<string>();

                    //foreach (string item in tradingGateway._lstSymbol)
                    //{
                    //    _lstSymbols.Add(item);

                    //}
                    List<string> gridSymbols = new List<string>();
                    foreach (DS4TradingGateway.dtSymbolRow item2 in row)
                    {
                        gridSymbols.Add(item2.Symbol);
                    }

                    foreach (string item in tradingGateway.LstSymbol)
                    {
                        foreach (DS4TradingGateway.dtSymbolRow item2 in row)
                        {
                            if (item == item2.Symbol)
                            {
                                int index=tradingGateway.LstSymbol.ToList().IndexOf(item);
                                item2.Symbol = item;
                                item2.SymbolAlias = tradingGateway.LstSymbolAlias[index];
                                item2.SymbolConversionFormula = tradingGateway.LstSymbolConversionFormula[index];
                                item2.ProductName = tradingGateway.LstProductName[index];
                                item2.ProductAlias = tradingGateway.LstProductAlias[index];
                            }
                            else if (!gridSymbols.Contains(item))
                            {
                                if (tradingGateway.LstSymbolAlias[tradingGateway.LstSymbol.ToList().IndexOf(item)] == null)
                                {
                                    _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false, item, "", 0,"","");
                                }
                                else
                                {
                                    int index = tradingGateway.LstSymbol.ToList().IndexOf(item);
                                    _DS4TradingGateway.dtSymbol.AdddtSymbolRow(tradingGateway.PKTradingGateWaysID, false,
                                        item, tradingGateway.LstSymbolAlias[index],
                                        tradingGateway.LstSymbolConversionFormula[index],
                                        tradingGateway.LstProductName[index], tradingGateway.LstProductAlias[index]);
                                }
                            }
                            else if (!tradingGateway.LstSymbol.Contains(item2.Symbol))
                            {
                                _DS4TradingGateway.dtSymbol.RemovedtSymbolRow(item2);
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsTradingGatewayManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                  //  "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleSymbolInfo()");
            }
        }

        #region "     IclsManaager    "


        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.TradingGateway_ID:
                    //DoHandleTradingGatewayTable((PS as TradingGatewayPS)._TradingGatway);
                    break;
                case ProtocolStructIDS.TGAccountConnectionSettings_ID:
                    //DoHandleAccountConnectionSettings((PS as ProtocolStructs.NewPS.clsTGAccountConnectionSettingsPS)._accountConnectionSettings);
                    break;
            }
        }

        public override void RemoveSetting(string DataKey)
        {
            int TradingGatewayID = -999;
            try
            {
                TradingGatewayID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4TradingGateway.dtTradingGatewayRow Row = _DS4TradingGateway.dtTradingGateway.FindByPK_TradingGateWaysID(TradingGatewayID);
            lock (_DS4TradingGateway.dtSymbol)
            {
                _DS4TradingGateway.dtTradingGateway.RemovedtTradingGatewayRow(Row);
            }
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            if (!response._Status)
            {
                ShowErrorMessage(response.ToString());
            }
        }

        public DS4TradingGateway.dtSymbolRow[] GetSymbolsRow(int tradingGatewayID)
        {
            DS4TradingGateway.dtSymbolRow[] rows = null;

            rows = (DS4TradingGateway.dtSymbolRow[])_DS4TradingGateway.dtSymbol.Select("FK_TradingGatewayID = " + tradingGatewayID.ToString() + " ");

            return rows;

        }

        public DS4TradingGateway.dtAccountConnectionSettingsRow[] GetTGAccountConnetionSettings(int TGID)
        {
            DS4TradingGateway.dtAccountConnectionSettingsRow[] rows = null;

            rows = (DS4TradingGateway.dtAccountConnectionSettingsRow[])_DS4TradingGateway.dtAccountConnectionSettings.Select("FK_TradingGatewaysID = " + TGID.ToString() + " ");

            return rows;
        }

        public List<string> GetLPAccountList(int TGID)
        {
            List<string> lstLPAccounts = new List<string>();
            foreach (DS4TradingGateway.dtAccountConnectionSettingsRow item in GetTGAccountConnetionSettings(TGID))
            {
                lstLPAccounts.Add(item.AccountID);
            }
            return lstLPAccounts;
        }

        public event Action UpdateTGAccountConnetionSettins = delegate { };
        #endregion "     IclsManaager    "
    }
}
