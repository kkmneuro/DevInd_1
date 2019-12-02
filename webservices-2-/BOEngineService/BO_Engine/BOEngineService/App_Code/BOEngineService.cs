using System;
using System.Configuration;
using System.Collections.Generic;
using LtechIndia.BackOffice.BOEngine.DAL;
using System.ServiceModel;
using LtechIndia.BackOffice.BOEngine.DAL.DB_New;
using clsInterface4OME;
using BOEngineServiceClasses;

/// <summary>
/// Summary description for BOEngineService
/// </summary>
[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
public class BOEngineService : ILogin, IIPAccessList, IFeeMaster, ITaxMaster, IHoliday, IContractSpecification, IMasterInfo
    , ITimeSettings, ITradingGateway, IBroker, ICollateralTypes,
    IClientInfo, ICollateralInfo, ICollateralTransInfo, ITrades, IMapOrders, ITGAccountConnectionSettings, IVirtualDealer, ICommonSettings, IInstrumentClosingPrice
{
    List<string> _lstConnectedClients = new List<string>();
    Dictionary<string, string> _DDLogin = new Dictionary<string, string>();
    BLBO _BLBO = null;
    public BOEngineService()
    {
        //_BLBO = new BLBO(ConfigurationManager.ConnectionStrings["BOExchange"].ConnectionString, ConfigurationManager.ConnectionStrings["OMSExchange"].ConnectionString,
        //    ConfigurationManager.ConnectionStrings["OMEConnectionStr"].ConnectionString, ConfigurationManager.ConnectionStrings["DataManagerCnnStr"].ConnectionString);
        _BLBO = new BLBO(ConfigurationManager.ConnectionStrings["BOExchange"].ConnectionString, ConfigurationManager.ConnectionStrings["OMSExchange"].ConnectionString,
           ConfigurationManager.ConnectionStrings["OMEConnectionStr"].ConnectionString, ConfigurationManager.ConnectionStrings["OME_ORDERConnectionStr"].ConnectionString);
    }

    #region ILogin Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public clsLogin AuthenticateLogin(string loginPwd, clsLogin login, string ipAddress)
    {
        try
        {
            if (login.BrokerCompany != string.Empty && login.BrokerCompany != null)
            {
                int spResult = _BLBO.Bo_ChangePassword(login.LoginId, login.BrokerCompany, login.Password);

                if (spResult != -50060)
                {
                    login.ServerResponseID = -50052;
                    return login;
                }
            }

            clsLogin objLoginResponse = new clsLogin();
            string AuthenticationId = login.LoginId;

            clsLoginToDataBase objclsLoginToDataBase = new clsLoginToDataBase();
            objclsLoginToDataBase.LoginId = login.LoginId;
            objclsLoginToDataBase.Password = login.Password;
            objclsLoginToDataBase.BrokerId = login.BrokerId;
            objclsLoginToDataBase.Role = login.Role;

            if (AuthenticationId != null)
            {
                int retVal = _BLBO.HandleBO_AuthenticateLogin(objclsLoginToDataBase.LoginId, objclsLoginToDataBase.Password,
                    ref objclsLoginToDataBase.BrokerId, ref objclsLoginToDataBase.Role, ref objclsLoginToDataBase.BrokerName_,
                    ref objclsLoginToDataBase.BrokerNameID_, ref objclsLoginToDataBase.BrokerCompany, ref objclsLoginToDataBase.IsEnable);

                if (objclsLoginToDataBase.BrokerId > 0)
                {
                    if (_DDLogin.ContainsKey(loginPwd) && _DDLogin[loginPwd] != ipAddress)
                    {
                        objLoginResponse.ServerResponseMsg = "Already Login";
                        objLoginResponse.BrokerId = -5;
                        objLoginResponse.Role = objclsLoginToDataBase.Role;
                        objLoginResponse.LoginId = objclsLoginToDataBase.LoginId;
                        objLoginResponse.Password = objclsLoginToDataBase.Password;
                        objLoginResponse.BrokerName = objclsLoginToDataBase.BrokerName_;
                        objLoginResponse.BrokerNameID = objclsLoginToDataBase.BrokerNameID_;
                        objLoginResponse.BrokerCompany = objclsLoginToDataBase.BrokerCompany;
                        objLoginResponse.IsEnable = objclsLoginToDataBase.IsEnable.Value;
                    }
                    else
                    {
                        if (!_DDLogin.ContainsKey(loginPwd))
                        {
                            _lstConnectedClients.Add(loginPwd);
                            _DDLogin.Add(loginPwd, ipAddress);
                        }

                        objLoginResponse.ServerResponseMsg = "Login Successful";
                        objLoginResponse.ServerResponseID = -50052;
                        objLoginResponse.BrokerId = objclsLoginToDataBase.BrokerId.Value;
                        objLoginResponse.Role = objclsLoginToDataBase.Role;
                        objLoginResponse.LoginId = objclsLoginToDataBase.LoginId;
                        objLoginResponse.Password = objclsLoginToDataBase.Password;
                        objLoginResponse.BrokerName = objclsLoginToDataBase.BrokerName_;
                        objLoginResponse.BrokerNameID = objclsLoginToDataBase.BrokerNameID_;
                        objLoginResponse.BrokerCompany = objclsLoginToDataBase.BrokerCompany;
                        objLoginResponse.IsEnable = objclsLoginToDataBase.IsEnable.Value;
                        int id = _BLBO.Bo_InsertBrokersLog(objclsLoginToDataBase.BrokerName_, objclsLoginToDataBase.BrokerNameID_, "Login", DateTime.Now, objclsLoginToDataBase.BrokerName_ + " Login Successful", ipAddress);

                    }
                }
                else
                {
                    objLoginResponse.ServerResponseMsg = "Login Unsuccessful";
                    objLoginResponse.BrokerId = objclsLoginToDataBase.BrokerId.Value;
                    objLoginResponse.Role = objclsLoginToDataBase.Role;
                    objLoginResponse.LoginId = objclsLoginToDataBase.LoginId;
                    objLoginResponse.Password = objclsLoginToDataBase.Password;
                }
            }
            else
            {
                login.ServerResponseMsg = "UnAuthorize Access";
                objLoginResponse = login;
            }

            return objLoginResponse;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in AuthenticateLogin()");

            throw new FaultException(ex.Message);
        }
    }
    [OperationBehavior(AutoDisposeParameters = true)]
    public void LogOut(string LoginIDPwd, clsBrokerOperationsLog brokerOperations)
    {

        try
        {

            if (_lstConnectedClients.Contains(LoginIDPwd))
            {
                int id = _BLBO.Bo_InsertBrokersLog(brokerOperations);
                _lstConnectedClients.Remove(LoginIDPwd);
                _DDLogin.Remove(LoginIDPwd);
            }
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in LogOut()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IIPAccessList Members

    public List<clsIPAccessList> HandleIPAccessList(string userId, OperationTypes opType, clsIPAccessList ipAccess)
    {
        try
        {
            List<clsIPAccessList> lstAccessIP = new List<clsIPAccessList>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsIPAccessList ipAccessList = new clsIPAccessList();

                ipAccessList.ServerResponseMsg = -50060;
                lstAccessIP.Add(ipAccessList);
                return lstAccessIP;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetIpAccessListResult> lstAccess = _BLBO.HandleDBBO_SelectAccessIp();
                        if (lstAccess == null)
                        {
                            return lstAccessIP;
                        }
                        foreach (BO_GetIpAccessListResult item in lstAccess)
                        {
                            clsIPAccessList ipAccessList = new clsIPAccessList();
                            ipAccessList.ID = item.PK_IPAccessListID;
                            ipAccessList.FromIP = item.From_IP;
                            ipAccessList.ToIp = item.Comment;
                            ipAccessList.Status = item.Status;
                            ipAccessList.ToIp = item.To_IP;
                            ipAccessList.Comment = item.Comment;
                            ipAccessList.ServerResponseMsg = -50052;

                            lstAccessIP.Add(ipAccessList);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleDBBO_InsertIpAccessTab(ipAccess);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            ipAccess.ServerResponseMsg = -50060;
                        }
                        else
                        {
                            ipAccess.ID = ID;
                            ipAccess.ServerResponseMsg = -50052;
                        }
                        lstAccessIP.Add(ipAccess);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleDBBO_UpdateIpAccessTab(ipAccess) == BLBO.FAILURE_ID)
                        {
                            ipAccess.ServerResponseMsg = -50060;
                        }
                        else
                        {
                            ipAccess.ServerResponseMsg = -50052;
                        }
                        lstAccessIP.Add(ipAccess);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.HandleDBBO_DeleteIpAccess(ipAccess.ID);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            ipAccess.ID = -50060;
                        }
                        else
                        {
                            ipAccess.ID = ID;
                        }
                        lstAccessIP.Add(ipAccess);
                    }
                    break;
            }


            return lstAccessIP;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetIPAccessList()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IFeeMaster Members

    public List<clsFeeMaster> HandleFeeMaster(string userId, OperationTypes opType, clsFeeMaster feeValue)
    {
        try
        {
            List<clsFeeMaster> lstFeeMaster = new List<clsFeeMaster>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsFeeMaster objclsFeeMaster = new clsFeeMaster();

                objclsFeeMaster.ServerResponseID = -50060;
                lstFeeMaster.Add(objclsFeeMaster);
                return lstFeeMaster;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_FeesMasterSelectResult> lstFee = _BLBO.HandleDBBO_SelectFeesMaster();

                        if (lstFee == null)
                        {
                            return lstFeeMaster;
                        }
                        foreach (BO_FeesMasterSelectResult item in lstFee)
                        {
                            clsFeeMaster objclsFeeMaster = new clsFeeMaster();
                            objclsFeeMaster.Description = item.Description;
                            objclsFeeMaster.FeeName = item.FeeName;
                            objclsFeeMaster.Interval = item.Interval;
                            objclsFeeMaster.IsTaxable = item.IsTaxable.Value;
                            objclsFeeMaster.MaximumFeevalue = clsUtility.GetDecimal(item.MaximunFeeValue);
                            objclsFeeMaster.MinimumFeeValue = clsUtility.GetDecimal(item.MinimumFeeValue);
                            objclsFeeMaster.FeeId = item.PK_FeeID;
                            objclsFeeMaster.FeesMode = clsUtility.GetStr(item.FeesMode);
                            objclsFeeMaster.LevyOn = clsUtility.GetStr(item.LevyOn);
                            objclsFeeMaster.Days = clsUtility.GetStr(item.Days);
                            objclsFeeMaster.ServerResponseID = -50052;

                            lstFeeMaster.Add(objclsFeeMaster);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleBO_FeesMasterInsert(feeValue);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            feeValue.ServerResponseID = -50060;
                        }
                        else
                        {
                            feeValue.FeeId = ID;
                            feeValue.ServerResponseID = -50052;
                        }

                        lstFeeMaster.Add(feeValue);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleBO_FeesMasterUpdate(feeValue) == BLBO.FAILURE_ID)
                        {
                            feeValue.ServerResponseID = -50060;
                        }
                        else
                        {
                            feeValue.ServerResponseID = -50052;
                        }

                        lstFeeMaster.Add(feeValue);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.HandleBO_DeleteFeeMasterDelete(feeValue.FeeId);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            feeValue.FeeId = -50060;
                        }
                        else
                        {
                            feeValue.FeeId = ID;
                        }

                        lstFeeMaster.Add(feeValue);
                    }
                    break;
            }

            return lstFeeMaster;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetFeeMaster()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ITaxMaster Members

    public List<clsTaxMaster> HandleTaxMaster(string userId, OperationTypes opType, clsTaxMaster taxValue)
    {
        try
        {
            List<clsTaxMaster> lstTaxMaster = new List<clsTaxMaster>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsTaxMaster objclsTaxMaster = new clsTaxMaster();

                objclsTaxMaster.ServerResponseID = -50060;
                lstTaxMaster.Add(objclsTaxMaster);
                return lstTaxMaster;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_TaxMasterSelectResult> lstTax = _BLBO.HandleBO_SelectTaxMaster();
                        if (lstTax == null)
                        {
                            return lstTaxMaster;
                        }
                        foreach (BO_TaxMasterSelectResult item in lstTax)
                        {
                            clsTaxMaster objclsTaxMaster = new clsTaxMaster();
                            objclsTaxMaster.Description = item.Description;
                            objclsTaxMaster.TaxName = item.TaxName;
                            objclsTaxMaster.Amount = item.Amount;
                            objclsTaxMaster.TaxID = clsUtility.GetInt(item.PK_TaxID);
                            objclsTaxMaster.TaxPercent = clsUtility.GetDecimal(item.TaxPercent);
                            objclsTaxMaster.ServerResponseID = -50052;

                            lstTaxMaster.Add(objclsTaxMaster);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleBO_InsertTaxMaster(taxValue);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            taxValue.ServerResponseID = -50060;
                        }
                        else
                        {
                            taxValue.TaxID = ID;
                            taxValue.ServerResponseID = -50052;
                        }

                        lstTaxMaster.Add(taxValue);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleBO_TaxMasterUpdate(taxValue) == BLBO.FAILURE_ID)
                        {
                            taxValue.ServerResponseID = -50060;
                        }
                        else
                        {
                            taxValue.ServerResponseID = -50052;
                        }

                        lstTaxMaster.Add(taxValue);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.HandleBO_TaxMasterDelete(taxValue.TaxID);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            taxValue.TaxID = -50060;
                        }
                        else
                        {
                            taxValue.TaxID = ID;
                        }

                        lstTaxMaster.Add(taxValue);
                    }
                    break;
            }


            return lstTaxMaster;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTaxMaster()");

            throw new FaultException(ex.Message);
        }
    }

    //public clsTaxMaster InsertIntoTaxMaster(string userId, clsTaxMaster taxValue)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            taxValue.ServerResponseID = -50060;

    //            return taxValue;
    //        }

    //        int ID = _BLBO.HandleBO_InsertTaxMaster(taxValue);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            taxValue.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            taxValue.TaxID = ID;
    //            taxValue.ServerResponseID = -50052;
    //        }
    //        return taxValue;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoTaxMaster()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    //public int DeleteTaxMaster(string userId, int deleteRecordID)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            deleteRecordID = -50060;

    //            return deleteRecordID;
    //        }

    //        int ID = _BLBO.HandleBO_TaxMasterDelete(deleteRecordID);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            deleteRecordID = -50060;
    //        }
    //        else
    //        {
    //            deleteRecordID = ID;
    //        }

    //        return deleteRecordID;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DeleteTaxMaster()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    //public clsTaxMaster UpdateTaxMaster(string userId, clsTaxMaster taxValue)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            taxValue.ServerResponseID = -50060;

    //            return taxValue;
    //        }

    //        if (_BLBO.HandleBO_TaxMasterUpdate(taxValue) == BLBO.FAILURE_ID)
    //        {
    //            taxValue.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            taxValue.ServerResponseID = -50052;
    //        }
    //        return taxValue;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateTaxMaster()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    #endregion

    #region IHoliday Members

    public List<clsHoliday> HandleHoliday(string userId, OperationTypes opType, clsHoliday holiday)
    {
        try
        {
            List<clsHoliday> lstHoliday = new List<clsHoliday>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsHoliday objclsHoliday = new clsHoliday();

                objclsHoliday.ServerResponseID = -50060;
                lstHoliday.Add(objclsHoliday);
                return lstHoliday;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_HolidaySelectResult> lstSpResult = _BLBO.HandleBO_HolidaysSelect();
                        if (lstSpResult == null)
                        {
                            return lstHoliday;
                        }
                        foreach (BO_HolidaySelectResult item in lstSpResult)
                        {
                            clsHoliday objclsHoliday = new clsHoliday();

                            objclsHoliday.Id = item.PK_ID;
                            objclsHoliday.Day = item.Date.Value;
                            objclsHoliday.FromTime = item.FromTime;
                            objclsHoliday.ToTime = item.ToTime;
                            objclsHoliday.Symbol = item.Symbol;
                            objclsHoliday.Description = item.Description;
                            objclsHoliday.IsEnable = item.IsEnable.Value;
                            objclsHoliday.IsEveryYear = item.IsEveryYear.Value;
                            objclsHoliday.ServerResponseID = -50052;

                            lstHoliday.Add(objclsHoliday);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleBO_HolidayInsert(holiday);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            holiday.ServerResponseID = -50060;
                        }
                        else
                        {
                            holiday.Id = ID;
                            holiday.ServerResponseID = -50052;
                        }
                        lstHoliday.Add(holiday);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleBO_HolidaysUpdate(holiday) == BLBO.FAILURE_ID)
                        {
                            holiday.ServerResponseID = -50060;
                        }
                        else
                        {
                            holiday.ServerResponseID = -50052;
                        }
                        lstHoliday.Add(holiday);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.HandleBO_DeleteHoliday(holiday.Id);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            holiday.Id = -50060;
                        }
                        else
                        {
                            holiday.Id = ID;
                        }
                        lstHoliday.Add(holiday);
                    }
                    break;
            }

            return lstHoliday;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetHoliday()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion
    //#region IContractSpecification Members

    //List<clsContractSpecification> IContractSpecification.HandleContractSpecfication(string userId, OperationTypes opType, clsContractSpecification csInfo)
    //{
    //    throw new NotImplementedException();
    //}

    //List<clsSymbolSessionNew> IContractSpecification.HandleContractSession(string userId, OperationTypes opType, List<int> instrumentId)
    //{
    //    throw new NotImplementedException();
    //}

    //#endregion
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsSymbolSessionNew> HandleContractSession(string userId, OperationTypes opType, List<int> instrumentIds)
    {
        try
        {
            List<clsSymbolSessionNew> lstObjCSession = new List<clsSymbolSessionNew>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsSymbolSessionNew objCSession = new clsSymbolSessionNew();
                clsSymbolSession objSS = new clsSymbolSession();
                objCSession.ServerResponseID = -50060;
                objCSession.lstSession.Add(objSS);
                lstObjCSession.Add(objCSession);
                return lstObjCSession;
            }

            switch (opType)
            {
                case OperationTypes.GET_SESSION:
                    {
                        try
                        {
                            foreach (int instrumentId in instrumentIds)
                            {
                                clsSymbolSessionNew objCSession = new clsSymbolSessionNew();
                                clsSymbolSession objSS = new clsSymbolSession();
                                objCSession.lstSession = _BLBO.Get_SelectSymbolsessionNew(instrumentId);
                                objCSession.ServerResponseID = -50052;
                                lstObjCSession.Add(objCSession);
                            }

                        }

                        catch (Exception ex)
                        {
                   //         Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleContractSession()");
                            throw new FaultException(ex.Message);
                        }
                    }
                    break;
            }

            return lstObjCSession;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleContractSession()");

            throw new FaultException(ex.Message);
        }
    }
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsContractSpecification> HandleContractSpecfication(string userId, OperationTypes opType, clsContractSpecification csInfo)
    {
        try
        {
            List<clsContractSpecification> lstCS = new List<clsContractSpecification>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsContractSpecification objCS = new clsContractSpecification();

                objCS.ServerResponseID = -50060;
                lstCS.Add(objCS);
                return lstCS;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        try
                        {
                            List<BO_SelectSymbolDefaultSettingResult> lstContractSpec = _BLBO.HandleDBBO_SelectSymbolDefaultDetail();
                            if (lstContractSpec == null)
                            {
                                return lstCS;
                            }
                            foreach (BO_SelectSymbolDefaultSettingResult item in lstContractSpec)
                            {
                                clsContractSpecification objCS = new clsContractSpecification();
                                objCS.Instruement_ID = item.PK_InstruementID;
                                objCS.SymbolName = item.Symbol;
                                objCS.Description = item.Descriptions;
                                objCS.Source = item.Source;
                                objCS.Digits = item.Digits.Value;
                                objCS.ULAssest = item.ULAssest;
                                objCS.TradingCurrency = clsUtility.GetStr(item.TradingCurrency);
                                objCS.SettlingCurrency = clsUtility.GetStr(item.SettlingCurrency);
                                objCS.MarginCurrency = clsUtility.GetStr(item.MarginCurrency);
                                objCS.MaximumLots = Convert.ToInt32(item.Maximum_Lots);
                                objCS.Maximum_Order_Value = item.Maximum_Order_Value.HasValue ? item.Maximum_Order_Value.Value : 0;
                                objCS.BuySideTurnover = item.Buy_Side_Turnover.HasValue ? item.Buy_Side_Turnover.Value : 0.0M;
                                objCS.SellSideTurnover = item.Sell_Side_Turnover.HasValue ? item.Sell_Side_Turnover.Value : 0.0M;
                                objCS.MaximumAllowablePosition = item.Maximum_Allowable_Position.HasValue ? item.Maximum_Allowable_Position.Value : 0;
                                objCS.QuotationBaseValue = item.Quotation_Base_Value.ToString();
                                objCS.DeliveryType = clsUtility.GetStr(item.Delivery_Type);
                                objCS.DeliveryUnit = clsUtility.GetStr(item.DeliveryUnit);
                                objCS.DeliveryQuantity = Convert.ToInt32(item.Delivery_Quantity);
                                objCS.MarketLot = Convert.ToInt32(item.Market_Lot);
                                if (item.Expiry_Date == null)
                                {
                                    objCS.ExpiryDate = "";
                                }
                                else
                                {
                                    objCS.ExpiryDate = clsUtility.GetDate(item.Expiry_Date).ToShortDateString();
                                }
                                objCS.StartDate = item.Start_Date.ToString();
                                objCS.EndDate = item.End_Date.ToString();
                                objCS.TenderStartDate = item.Tender_start_Date.ToString();
                                objCS.TenderEndDate = item.Tender_End_Date.ToString();
                                objCS.DeliveryStartDate = item.Delivery_Start_Date.ToString();
                                objCS.DeliveryEndDate = item.Delivery_End_Date.ToString();
                                objCS.DPRInitialPercentage = Convert.ToInt32(item.DPR_Initial_Percentage);
                                objCS.DPR_Range_Higher = Convert.ToInt32(item.DPR_Range_Higher);
                                objCS.DPRInterval = Convert.ToInt32(item.DPR_Interval);
                                objCS.LimitandStopLevel = item.LimitandStopLevel;
                                objCS.FK_SecurityTypeID = clsUtility.GetStr(item.SecurityType);
                                objCS.ContractSize = Convert.ToInt32(item.ContractSize);
                                objCS.InitialBuyMargin = Convert.ToInt32(item.Initial_Buy_Margin);
                                objCS.InitialSellMargin = Convert.ToInt32(item.Initial_Sell_Margin);
                                objCS.MaintenanceBuyMargin = Convert.ToInt32(item.Maintenance_Buy_Margin);
                                objCS.MaintenanceSellMargin = Convert.ToInt32(item.Maintenance_Sell_Margin);
                                objCS.Hedged = Convert.ToInt32(item.Hedged);
                                objCS.TickSize = Convert.ToInt32(item.TickSize);
                                objCS.TickPrice = Convert.ToInt32(item.TickPrice);
                                objCS.MarketLostUnit = clsUtility.GetStr(item.FK_MarketLotsUnit);
                                objCS.MaximumLostUnit = clsUtility.GetStr(item.FK_MaximumLostUnit);
                                objCS.QuotationBaseValueUnit = clsUtility.GetStr(item.FK_QuotationBaseValueUnit);
                                objCS.Spread = clsUtility.GetInt(item.Spread);
                                objCS.QuoteOffTime = item.OffQuoteTimeLimitInSec;
                                #region " Namo "

                                //objCS.lstSession = new List<clsSymbolSession>();
                                 objCS.lstSession = _BLBO.Get_SelectSymbolsession(objCS);

                                ////List<BO_SelectSymbolsessionResult> lstSymbolsession = _BLBO.HandleDBBO_SelectSymbolsession(objCS.Instruement_ID);
                                ////{
                                ////    objCS.SessionCount = lstSymbolsession.Count;
                                ////    List<clsSymbolSession> lstSymbolSession = new List<clsSymbolSession>();
                                ////    for (int iSessionLoop = 0; iSessionLoop < objCS.SessionCount; iSessionLoop++)
                                ////    {
                                ////        clsSymbolSession symbolSession = new clsSymbolSession();
                                ////        string session = string.Empty;
                                ////        foreach (BO_GetSymbolQuotesessionResult quoteS in _BLBO.HandleDBBO_GetSymbolQuotesession(objCS.Instruement_ID,
                                ////            lstSymbolsession[iSessionLoop].Day))
                                ////        {
                                ////            session = session + quoteS.Quotes + "-" + quoteS.EndQuotes + ",";
                                ////        }
                                ////        symbolSession.QuoteSession = session;//lstSymbolsession[iSessionLoop].Trade;

                                ////        symbolSession.Day = (DAYS)Enum.Parse(typeof(DAYS), lstSymbolsession[iSessionLoop].Day, true);
                                ////        session = string.Empty;
                                ////        foreach (BO_GetSymbolTradesessionResult quoteS in _BLBO.HandleDBBO_GetSymbolTradesession(objCS.Instruement_ID,
                                ////            lstSymbolsession[iSessionLoop].Day))
                                ////        {
                                ////            session = session + quoteS.TradeStart + "-" + quoteS.TradeEnd + ",";
                                ////        }
                                ////        symbolSession.TradeSession = session; //lstSymbolsession[iSessionLoop].Quotes;
                                ////        session = string.Empty;
                                ////        symbolSession.IsUseTimelimits = lstSymbolsession[iSessionLoop].UseTimelimits.Value;
                                ////        symbolSession.StartDate = lstSymbolsession[iSessionLoop].StartDate.Value;
                                ////        symbolSession.EndDate = lstSymbolsession[iSessionLoop].EndDate.Value;
                                ////        lstSymbolSession.Add(symbolSession);
                                ////    }

                                ////    objCS.lstSession = lstSymbolSession;

                                ////}
                                ////clsInstrumentSwaps objclsInstrumentSwaps = new clsInstrumentSwaps();
                                ////foreach (BO_GetInstrumentSwapsResult instrumentSwap in _BLBO.HandleBO_GetInstrumentSwaps(objCS.Instruement_ID))
                                ////{
                                ////    objclsInstrumentSwaps.IsEnable = Convert.ToBoolean(instrumentSwap.IsEnable);
                                ////    objclsInstrumentSwaps.LongPosition = clsUtility.GetDecimal(instrumentSwap.LongPosition);
                                ////    objclsInstrumentSwaps.ShortPosition = clsUtility.GetDecimal(instrumentSwap.ShortPosition);
                                ////}
                                ////objCS.InstrumentSwaps = objclsInstrumentSwaps;
                                #endregion " Namo "
                                objCS.ServerResponseID = -50052;

                                lstCS.Add(objCS);
                            }
                        }
                        catch (Exception ex)
                        {
                   //         Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in HandleContractSpecfication()");
                            throw new FaultException(ex.Message);
                        }
                    }

                    break;
                case OperationTypes.INSERT:
                    {
                        #region " Namo "
                        string sessionString = string.Empty;
                        //int count = 0;

                        //foreach (clsSymbolSession item in csInfo.lstSession)
                        //{
                        //    sessionString += item.Day.ToString() + "~";
                        //    sessionString += item.IsUseTimelimits.ToString() + "~";
                        //    sessionString += item.StartDate.ToString() + "~";
                        //    sessionString += item.EndDate.ToString() + "~";
                        //    sessionString += item.QuoteSession.ToString() + "~";
                        //    if (count == 6)
                        //    {
                        //        sessionString += item.TradeSession.ToString();
                        //    }
                        //    else
                        //    {
                        //        sessionString += item.TradeSession.ToString() + ">";
                        //    } count++;
                        //}
                        #endregion
                        int ID = _BLBO.HandleBO_AddNewSymbol(csInfo, sessionString);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            csInfo.ServerResponseID = -50060;
                        }
                        else
                        {
                            csInfo.Instruement_ID = ID;
                            csInfo.ServerResponseID = -50052;
                        }
                        lstCS.Add(csInfo);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        string sessionString = string.Empty;

                        #region " Namo "
                        int count = 0;
                        foreach (clsSymbolSession item in csInfo.lstSession)
                        {
                            sessionString += item.Day.ToString() + "~";
                            sessionString += item.IsUseTimelimits.ToString() + "~";
                            sessionString += item.StartDate.ToString() + "~";
                            sessionString += item.EndDate.ToString() + "~";
                            sessionString += item.QuoteSession.ToString() + "~";
                            if (count == 6)
                            {
                                sessionString += item.TradeSession.ToString();
                            }
                            else
                            {
                                sessionString += item.TradeSession.ToString() + ">";
                            } count++;
                        }
                        #endregion
                        csInfo.Instruement_ID = csInfo.Instruement_ID;
                        int ID = _BLBO.HandleBO_UpdateSymbol(csInfo, sessionString);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            csInfo.ServerResponseID = -50060;
                        }
                        else
                        {
                            csInfo.ServerResponseID = -50052;
                        }
                        lstCS.Add(csInfo);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.HandleDBBO_DeleteSymbol(csInfo.Instruement_ID);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            csInfo.Instruement_ID = -50060;
                        }
                        else
                        {
                            csInfo.Instruement_ID = ID;
                        }
                        lstCS.Add(csInfo);
                    }
                    break;
            }

            return lstCS;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetContractSpecfication()");

            throw new FaultException(ex.Message);
        }
    }

    #region
    //[OperationBehavior(AutoDisposeParameters = true)]
    //public clsContractSpecification InsertIntoContractSpecification(string userId, clsContractSpecification csInfo)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            csInfo.ServerResponseID = -50060;

    //            return csInfo;
    //        }

    //        string sessionString = string.Empty;
    //        int count = 0;

    //        foreach (clsSymbolSession item in csInfo.lstSession)
    //        {
    //            sessionString += item.Day.ToString() + "~";
    //            sessionString += item.IsUseTimelimits.ToString() + "~";
    //            sessionString += item.StartDate.ToString() + "~";
    //            sessionString += item.EndDate.ToString() + "~";
    //            sessionString += item.QuoteSession.ToString() + "~";
    //            if (count == 6)
    //            {
    //                sessionString += item.TradeSession.ToString();
    //            }
    //            else
    //            {
    //                sessionString += item.TradeSession.ToString() + ">";
    //            } count++;
    //        }

    //        int ID = _BLBO.HandleBO_AddNewSymbol(csInfo, sessionString);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            csInfo.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            csInfo.Instruement_ID = ID;
    //            csInfo.ServerResponseID = -50052;
    //        }
    //        return csInfo;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoContractSpecification()");

    //        throw new FaultException(ex.Message);
    //    }
    //}
    //[OperationBehavior(AutoDisposeParameters = true)]
    //public int DeleteContractSpecification(string userId, int deleteRecordID)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            deleteRecordID = -50060;

    //            return deleteRecordID;
    //        }

    //        int ID = _BLBO.HandleDBBO_DeleteSymbol(deleteRecordID);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            deleteRecordID = -50060;
    //        }
    //        else
    //        {
    //            deleteRecordID = ID;
    //        }

    //        return deleteRecordID;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DeleteContractSpecification()");

    //        throw new FaultException(ex.Message);
    //    }
    //}
    //[OperationBehavior(AutoDisposeParameters = true)]
    //public clsContractSpecification UpdateContractSpecification(string userId, clsContractSpecification csInfo)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userId))
    //        {
    //            csInfo.ServerResponseID = -50060;

    //            return csInfo;
    //        }

    //        string sessionString = string.Empty;
    //        int count = 0;

    //        foreach (clsSymbolSession item in csInfo.lstSession)
    //        {
    //            sessionString += item.Day.ToString() + "~";
    //            sessionString += item.IsUseTimelimits.ToString() + "~";
    //            sessionString += item.StartDate.ToString() + "~";
    //            sessionString += item.EndDate.ToString() + "~";
    //            sessionString += item.QuoteSession.ToString() + "~";
    //            if (count == 6)
    //            {
    //                sessionString += item.TradeSession.ToString();
    //            }
    //            else
    //            {
    //                sessionString += item.TradeSession.ToString() + ">";
    //            } count++;
    //        }

    //        csInfo.Instruement_ID = csInfo.Instruement_ID;
    //        int ID = _BLBO.HandleBO_UpdateSymbol(csInfo, sessionString);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            csInfo.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            csInfo.ServerResponseID = -50052;
    //        }
    //        return csInfo;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateContractSpecification()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    #endregion

    #region ICurrency Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsCurrency> GetCurrencyList(string userId)
    {
        try
        {
            List<clsCurrency> lstCurrencyList = new List<clsCurrency>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsCurrency objclsCurrency = new clsCurrency();

                objclsCurrency.ServerResponseID = -50060;
                lstCurrencyList.Add(objclsCurrency);
                return lstCurrencyList;
            }
            List<BO_GetCurrencyListResult> lstCurrency = _BLBO.HandleBO_GetCurrencyList();
            if (lstCurrency == null)
            {
                return lstCurrencyList;
            }
            foreach (BO_GetCurrencyListResult item in lstCurrency)
            {
                clsCurrency objclsCurrency = new clsCurrency();
                objclsCurrency.Currency_ID = item.PK_Currency_ID;
                objclsCurrency.CurrencyDescription = item.CurrencyDescription;
                objclsCurrency.CurrencyName = item.CurrencyName;
                objclsCurrency.ServerResponseID = -50052;

                lstCurrencyList.Add(objclsCurrency);
            }

            return lstCurrencyList;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCurrencyList()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ISecurityType Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsSecurityType> GetSecurityType(string userId)
    {
        try
        {
            List<clsSecurityType> lstSecurityType = new List<clsSecurityType>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsSecurityType objclsSecurityType = new clsSecurityType();

                objclsSecurityType.ServerResponseID = -50060;
                lstSecurityType.Add(objclsSecurityType);
                return lstSecurityType;
            }
            List<BO_GetSecurityTypeListResult> lstSecurity = _BLBO.HandleBO_GetSecurityType();
            if (lstSecurity == null)
            {
                return lstSecurityType;
            }
            foreach (BO_GetSecurityTypeListResult item in lstSecurity)
            {
                clsSecurityType objclsSecurityType = new clsSecurityType();
                objclsSecurityType.SecurityTypeID = item.PK_SecurityTypeID;
                objclsSecurityType.SecurityName = item.SecurityName;
                objclsSecurityType.SecurityDescription = item.SecurityDescription;
                objclsSecurityType.ServerResponseID = -50052;

                lstSecurityType.Add(objclsSecurityType);
            }

            return lstSecurityType;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetSecurityType()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IMasterInfo Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public BOEngineServiceClasses.clsMasterInfo GetMasterInfo(string userId)
    {
        try
        {
            BOEngineServiceClasses.clsMasterInfo objclsMasterInfo = new BOEngineServiceClasses.clsMasterInfo();

            if (!_lstConnectedClients.Contains(userId))
            {
                objclsMasterInfo.ServerResponseID = -50060;
                return objclsMasterInfo;
            }
            List<string> lstDeliveryUnits = new List<string>();
            List<string> lstOrderTypes = new List<string>();
            List<string> lstProductNames = new List<string>();
            List<string> lstUnexpiredSymbol = new List<string>();
            Dictionary<int, string> DDsymbols = new Dictionary<int, string>();
            Dictionary<int, string> DDRoles = new Dictionary<int, string>();
            Dictionary<int, string> DDLPNames = new Dictionary<int, string>();
            Dictionary<int, string> DDClientAccountTypes = new Dictionary<int, string>();
            Dictionary<string, int> DDContractSize = new Dictionary<string, int>();

            List<BO_GetDeliveryUnitResult> lstDUnits = _BLBO.GetDeliverUnitNames();

            foreach (BO_GetDeliveryUnitResult deliverUnit in lstDUnits)
            {
                lstDeliveryUnits.Add(deliverUnit.Unit.Trim());
            }
            objclsMasterInfo.lstDeliveryUnit = lstDeliveryUnits;

            List<BO_GetOrderTypesResult> lstOTypes = _BLBO.GetOrderTypes();
            foreach (BO_GetOrderTypesResult orderTypes in lstOTypes)
            {
                lstOrderTypes.Add(orderTypes.OrderName);
            }
            objclsMasterInfo.lstOrderTypes = lstOrderTypes;

            List<BO_GetProductNamesResult> lstPNames = _BLBO.GetProductNames();
            foreach (BO_GetProductNamesResult productNames in lstPNames)
            {
                lstProductNames.Add(productNames.Source);
            }
            objclsMasterInfo.lstProductNames = lstProductNames;

            List<BO_GetPredefinedRolesResult> lstPredefinedRoles = _BLBO.HandleBO_GetPredefinedRoles();

            foreach (BO_GetPredefinedRolesResult predefinedRoles in lstPredefinedRoles)
            {
                DDRoles.Add(predefinedRoles.RoleId, predefinedRoles.SetOfAuth);
            }
            objclsMasterInfo.DDRoles = DDRoles;

            List<BO_GetAllSymbolsResult> symbolResult = _BLBO.GetAllSymbols();
            foreach (BO_GetAllSymbolsResult symbol in symbolResult)
            {
                DDsymbols.Add(symbol.PK_InstruementID, symbol.Symbol);
            }
            objclsMasterInfo.DDSymbols = DDsymbols;

            List<BO_GetLPNameListResult> lpNameResult = _BLBO.GetLPNameList();
            foreach (BO_GetLPNameListResult lpName in lpNameResult)
            {
                DDLPNames.Add(lpName.PK_TradingGateWaysID, lpName.Name);
            }
            objclsMasterInfo.DDLPNames = DDLPNames;

            List<BO_GetAccountTypesResult> clientAccountType = _BLBO.GetClientAccountTypes();
            foreach (BO_GetAccountTypesResult accType in clientAccountType)
            {
                DDClientAccountTypes.Add(accType.PK_AccountTypeID, accType.AccountTypeName);
            }
            objclsMasterInfo.DDClientAccountTypes = DDClientAccountTypes;

            List<BO_GetUnexpiredSymbolsResult> lstUnexpiredSymbols = _BLBO.Bo_GetUnexpiredSymbols();

            foreach (BO_GetUnexpiredSymbolsResult item in lstUnexpiredSymbols)
            {
                lstUnexpiredSymbol.Add(clsUtility.GetStr(item.Symbol));
            }
            objclsMasterInfo.lstUnexpiredSymbols = lstUnexpiredSymbol;
            List<BO_GetHedgeTypesResult> HedgeTypes = _BLBO.Bo_GetHedgeTypes();
            DDClientAccountTypes = new Dictionary<int, string>();
            foreach (BO_GetHedgeTypesResult item in HedgeTypes)
            {
                DDClientAccountTypes.Add(clsUtility.GetInt(item.Hedge_ID), clsUtility.GetStr(item.Hedge_Type));
            }
            objclsMasterInfo.DDHedgeTypes = DDClientAccountTypes;

            Dictionary<string, Dictionary<string, List<string>>> ddTGymbolsInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            foreach (BO_GetTGListResult tg in _BLBO.Bo_GetTGList())
            {
                Dictionary<string, List<string>> tgSymbols = new Dictionary<string, List<string>>();

                foreach (BO_GetTGSymbolsInfoResult symbolInfo in _BLBO.Bo_GetTGSymbolsInfo(tg.PK_TradingGateWaysID))
                {
                    List<string> lstSymbols = new List<string>();
                    if (!tgSymbols.ContainsKey(symbolInfo.SecurityName))
                    {
                        lstSymbols.Add(symbolInfo.Symbol);
                        tgSymbols.Add(symbolInfo.SecurityName, lstSymbols);
                    }
                    else
                        tgSymbols[symbolInfo.SecurityName].Add(symbolInfo.Symbol);
                }
                ddTGymbolsInfo.Add(tg.Name, tgSymbols);
            }
            objclsMasterInfo.DDTGSymbolsInfo = ddTGymbolsInfo;
            foreach (BO_GetContractSizeResult contractSize in _BLBO.Bo_GetContractSize())
            {
                if (!DDContractSize.ContainsKey(contractSize.SymbolName))
                {
                    DDContractSize.Add(contractSize.SymbolName, contractSize.ContractSize.Value);
                }
            }
            objclsMasterInfo.DDContractSize = DDContractSize;
            Dictionary<string, string> ddCommonSettings = new Dictionary<string, string>();
            foreach (BO_GetCommonSettingNewResult item in _BLBO.HandleDBBO_SelectCommonSettingsNew())
            {
                ddCommonSettings.Add(item.Property, item.Value);
            }
            objclsMasterInfo.DDCommonSettings = ddCommonSettings;
            objclsMasterInfo.ServerResponseID = -50052;
            return objclsMasterInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetMasterInfo()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ITimeSettings Members

    public List<clsTimeSettings> HandleTimeSettings(string userIdPwd, OperationTypes opType, clsTimeSettings timeSettings)
    {
        try
        {
            List<clsTimeSettings> lstTimeSettings = new List<clsTimeSettings>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsTimeSettings objclsTimeSettings = new clsTimeSettings();

                objclsTimeSettings.ServerResponseID = -50060;
                lstTimeSettings.Add(objclsTimeSettings);
                return lstTimeSettings;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetTimeSettingsResult> spResult = _BLBO.HandleGetTimeSettings();
                        if (spResult == null)
                        {
                            return lstTimeSettings;
                        }
                        foreach (BO_GetTimeSettingsResult item in spResult)
                        {
                            clsTimeSettings objclsTimeSettings = new clsTimeSettings();
                            objclsTimeSettings.Day = item.Days;
                            objclsTimeSettings.TimeSpan = item.SetTime;
                            objclsTimeSettings.ServerResponseID = -50052;

                            lstTimeSettings.Add(objclsTimeSettings);
                        }
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleBO_UpdateTimeSettings(timeSettings) == BLBO.FAILURE_ID)
                        {
                            timeSettings.ServerResponseID = -50060;
                        }
                        else
                        {
                            timeSettings.ServerResponseID = -50052;
                        }
                        lstTimeSettings.Add(timeSettings);
                    }
                    break;
            }

            return lstTimeSettings;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTimeSettings()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ITradingGateway Members

    public List<clsTradingGateway> HandleTradingGateway(string userIdPwd, OperationTypes opType, clsTradingGateway tradingGateway)
    {
        try
        {
            List<clsTradingGateway> lstTradingGateway = new List<clsTradingGateway>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsTradingGateway objclsTradingGateway = new clsTradingGateway();

                objclsTradingGateway.ServerResponseID = -50060;
                lstTradingGateway.Add(objclsTradingGateway);
                return lstTradingGateway;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetTradingGateWaysResult> spResult = _BLBO.HandleBO_GetTradingGateWays();
                        if (spResult == null)
                        {
                            return lstTradingGateway;
                        }
                        List<string> lstSymbols;
                        List<string> lstSymbolAlias;
                        foreach (BO_GetTradingGateWaysResult item in spResult)
                        {
                            lstSymbols = new List<string>();
                            lstSymbolAlias = new List<string>();
                            List<decimal> lstSymbolConversionFormula = new List<decimal>();
                            List<string> lstProductName = new List<string>();
                            List<string> lstProductAlias = new List<string>();

                            clsTradingGateway objclsTradingGateway = new clsTradingGateway();

                            objclsTradingGateway.PKTradingGateWaysID = item.PK_TradingGateWaysID;
                            objclsTradingGateway.Name = item.Name;
                            objclsTradingGateway.Description = item.Description;
                            objclsTradingGateway.ServerIP = item.Server_IP;
                            objclsTradingGateway.Port = item.Port.ToString();
                            objclsTradingGateway.DataType = item.DataTypes;
                            objclsTradingGateway.Login = item.Login;
                            objclsTradingGateway.Password = item.Password;
                            objclsTradingGateway.IdleTimeOut = Convert.ToInt32(item.IdleTimeOut);
                            objclsTradingGateway.ReconnectAfter = Convert.ToInt32(item.ReconnectAfter);
                            objclsTradingGateway.SleepFor = Convert.ToInt32(item.SleepFor);
                            objclsTradingGateway.Attempts = Convert.ToInt32(item.Attempts);
                            objclsTradingGateway.IsEnable = Convert.ToBoolean(item.IsEnable);

                            List<BO_GetTradingGateWaySymbolMapInfoResult> lstTradingGatewayMap = _BLBO.HandleBO_GetTradingGateWaySymbolMapInfo(item.PK_TradingGateWaysID);
                            foreach (BO_GetTradingGateWaySymbolMapInfoResult item2 in lstTradingGatewayMap)
                            {
                                if (!lstSymbols.Contains(item2.SourceName))
                                {
                                    lstSymbols.Add(item2.SourceName);
                                }
                                lstSymbolAlias.Add(item2.SymbolAlias);
                                lstSymbolConversionFormula.Add(clsUtility.GetDecimal(item2.Symbol_Conversion_Formula));
                                lstProductName.Add(clsUtility.GetStr(item2.Symbol_Product));
                                lstProductAlias.Add(clsUtility.GetStr(item2.ProductAlias));
                            }
                            objclsTradingGateway.LstSymbol = lstSymbols;
                            objclsTradingGateway.LstSymbolAlias = lstSymbolAlias;
                            objclsTradingGateway.LstSymbolConversionFormula = lstSymbolConversionFormula;
                            objclsTradingGateway.LstProductName = lstProductName;
                            objclsTradingGateway.LstProductAlias = lstProductAlias;
                            objclsTradingGateway.EnableRMS = Convert.ToBoolean(item.Enable_RMS);
                            objclsTradingGateway.OrderPort = clsUtility.GetInt(item.Order_Port);
                            objclsTradingGateway.OrderIP = clsUtility.GetStr(item.Order_IP);
                            objclsTradingGateway.ServerResponseID = -50052;

                            lstTradingGateway.Add(objclsTradingGateway);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        clsTradingGateway obj = _BLBO.HandleInsertTradingGateWayInfo(tradingGateway);
                        if (obj.PKTradingGateWaysID == BLBO.FAILURE_ID)
                        {
                            tradingGateway.ServerResponseID = -50060;
                        }
                        else
                        {
                            //tradingGateway.PKTradingGateWaysID = ID;
                            tradingGateway.ServerResponseID = -50052;
                        }
                        lstTradingGateway.Add(obj);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        tradingGateway = _BLBO.HandleUpdateTradingGateWayInfo(tradingGateway);
                        lstTradingGateway.Add(tradingGateway);
                    }
                    break;
            }

            return lstTradingGateway;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTradingGateway()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IBroker Members

    public List<clsBroker> HandleBrokers(string userIdPwd, int BrokerId, OperationTypes opType, clsBroker broker)
    {
        try
        {
            bool getGlobalItems = false;
            List<clsBroker> lstBroker = new List<clsBroker>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsBroker objclsBroker = new clsBroker();

                objclsBroker.ServerResponseID = -50060;
                lstBroker.Add(objclsBroker);
                return lstBroker;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetBrokersInfoResult> spResult = _BLBO.HandleBO_GetBrokersInfo();
                        if (spResult == null)
                        {
                            return lstBroker;
                        }
                        foreach (BO_GetBrokersInfoResult item in spResult)
                        {
                            clsBroker objclsBroker = new clsBroker();
                            List<BrokerSymbol> lstSymbols = new List<BrokerSymbol>();
                            List<charges> lstCharges = new List<charges>();

                            objclsBroker.BrokerID = item.PK_AccountGroupID;
                            objclsBroker.Name = item.AccountGroupName;
                            objclsBroker.Owner = item.Owner;
                            objclsBroker.Leverage = item.Leverage;
                            objclsBroker.IsEnable = Convert.ToBoolean(item.IsEnable);
                            objclsBroker.BrokerType = item.BrokerType;
                            objclsBroker.Address = item.BrokerAddress;
                            objclsBroker.City = item.BrokerCity;
                            objclsBroker.State = item.BrokerState;
                            objclsBroker.Phone1 = item.BrokerPhone1;
                            objclsBroker.Phone2 = item.BrokerPhone2;
                            objclsBroker.Fax = item.BrokerFax;
                            objclsBroker.EMail = item.BrokerEmail;
                            objclsBroker.MarginCallLevel1 = Convert.ToInt32(item.MarginCallLevel1);
                            objclsBroker.MarginCallLevel2 = Convert.ToInt32(item.MarginCallLevel2);
                            objclsBroker.MarginCallLevel3 = Convert.ToInt32(item.MarginCallLevel3);
                            objclsBroker.News = item.News;
                            objclsBroker.MaximumOrders = item.MaximumOrders;
                            objclsBroker.Maximumsymbols = item.MaximumSymbols;
                            objclsBroker.BrokerParent = clsUtility.GetInt(item.ParentAccountGroupID);
                            objclsBroker.Roles = item.Roles;
                            objclsBroker.RoleId = clsUtility.GetInt(item.RoleId);
                            objclsBroker.RoleName = item.RoleName;
                            objclsBroker.LoginID = item.LoginId;
                            List<BO_GetBrokersSymbolMapInfoResult> lstBrokersSymbolMap = _BLBO.HandleDBBO_GetBrokersSymbolMapInfo(item.PK_AccountGroupID);
                            foreach (BO_GetBrokersSymbolMapInfoResult item2 in lstBrokersSymbolMap)
                            {
                                BrokerSymbol objBrokerSymbol = new BrokerSymbol();
                                objBrokerSymbol.SymbolID = item2.FK_InstruementID;
                                objBrokerSymbol.SymbolName = item2.SourceName;
                                objBrokerSymbol.BidSpread = clsUtility.GetInt(item2.BidSpread);
                                objBrokerSymbol.AskSpread = clsUtility.GetInt(item2.AskSpread);
                                objBrokerSymbol.Spread = clsUtility.GetInt(item2.Spread);
                                objBrokerSymbol.IsVariable = Convert.ToBoolean(item2.IsVariable);
                                objBrokerSymbol.RelativeAskChange = 0;
                                objBrokerSymbol.RelativeBidChange = 0;

                                lstSymbols.Add(objBrokerSymbol);
                            }

                            List<BO_SelectBrokersChargesInfoResult> lstSymbolCharges = _BLBO.HandleDBBO_GetSymbolCharges(item.PK_AccountGroupID);
                            foreach (BO_SelectBrokersChargesInfoResult symbolCharges in lstSymbolCharges)
                            {
                                charges objcharges = new charges();
                                objcharges.ChargesID = symbolCharges.PK_SymbolsChargesID;
                                objcharges.BrokersGroupID = symbolCharges.FK_AccountGroupId;
                                objcharges.SymbolID = symbolCharges.FK_InstruementID;
                                objcharges.Symbol = symbolCharges.Symbol;
                                objcharges.Fee = symbolCharges.FeeName;
                                objcharges.FeeValue = clsUtility.GetDecimal(symbolCharges.FeeValue);
                                objcharges.Tax = symbolCharges.TaxName;
                                objcharges.TaxValue = clsUtility.GetDouble(symbolCharges.TaxPercent);
                                if (!lstCharges.Contains(objcharges))
                                {
                                    lstCharges.Add(objcharges);
                                }
                            }

                            List<BrokerSymbol> lstTSymbols = new List<BrokerSymbol>();
                            if (!getGlobalItems)
                            {
                                List<BO_GetAllSymbolsNewResult> lstTotalSymbols = _BLBO.GetAllSymbols(BrokerId);
                                foreach (BO_GetAllSymbolsNewResult symbol in lstTotalSymbols)
                                {
                                    BrokerSymbol objBrokerSymbol = new BrokerSymbol();
                                    objBrokerSymbol.SymbolID = symbol.PK_InstruementID;
                                    objBrokerSymbol.SymbolName = symbol.Symbol;

                                    lstTSymbols.Add(objBrokerSymbol);
                                }
                                objclsBroker.LstTotalSymbols = lstTSymbols;

                                List<string> lstFee = new List<string>();
                                List<string> lstTax = new List<string>();
                                List<BO_GetAllFeeTypeResult> lstFeeType = _BLBO.GetAllFeeType();
                                foreach (BO_GetAllFeeTypeResult feeType in lstFeeType)
                                {
                                    lstFee.Add(feeType.FeeName);
                                }
                                objclsBroker.LstFeeType = lstFee;

                                List<BO_GetAllTaxTypeResult> lstTaxType = _BLBO.GetAllTaxType();
                                foreach (BO_GetAllTaxTypeResult taxType in lstTaxType)
                                {
                                    lstTax.Add(taxType.TaxName);
                                }
                                objclsBroker.LstTaxType = lstTax;
                                getGlobalItems = true;
                            }

                            objclsBroker.LstSymbol = lstSymbols;
                            objclsBroker.LstCharges = lstCharges;

                            objclsBroker.ServerResponseID = -50052;

                            lstBroker.Add(objclsBroker);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleInsertIntoBrokers(broker);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            broker.ServerResponseID = -50060;
                        }
                        else
                        {
                            foreach (charges item in broker.LstCharges)
                            {
                                broker.LstCharges[broker.LstCharges.IndexOf(item)].ChargesID = _BLBO.HandleInsertIntoSymbolCharges(item, ID);
                                broker.LstCharges[broker.LstCharges.IndexOf(item)].BrokersGroupID = ID;
                            }
                            broker.RoleId = broker.RoleId;
                            broker.BrokerID = ID;
                            broker.ServerResponseID = -50052;
                        }
                        lstBroker.Add(broker);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleUpdateIntoBrokers(broker) == BLBO.FAILURE_ID)
                        {
                            broker.ServerResponseID = -50060;
                        }
                        else
                        {
                            foreach (charges item in broker.LstCharges)
                            {
                                if (item.ChargesID <= 0)
                                {
                                    broker.LstCharges[broker.LstCharges.IndexOf(item)].ChargesID = _BLBO.HandleInsertIntoSymbolCharges(item, broker.BrokerID);
                                    broker.LstCharges[broker.LstCharges.IndexOf(item)].BrokersGroupID = broker.BrokerID;
                                }
                                else
                                {
                                    _BLBO.HandleDBBO_UpdateSymbolCharges(item);
                                }
                            }
                            broker.ServerResponseID = -50052;
                        }
                        lstBroker.Add(broker);
                    }
                    break;
            }

            return lstBroker;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetBrokers()");

            throw new FaultException(ex.Message);
        }
    }

    //public clsBroker InsertIntoBroker(string userIdPwd, clsBroker broker)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userIdPwd))
    //        {
    //            broker.ServerResponseID = -50060;

    //            return broker;
    //        }
    //        int ID = _BLBO.HandleInsertIntoBrokers(broker);
    //        if (ID == BLBO.FAILURE_ID)
    //        {
    //            broker.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            foreach (charges item in broker.LstCharges)
    //            {
    //                broker.LstCharges[broker.LstCharges.IndexOf(item)].ChargesID = _BLBO.HandleInsertIntoSymbolCharges(item, ID);
    //                broker.LstCharges[broker.LstCharges.IndexOf(item)].BrokersGroupID = ID;
    //            }
    //            broker.RoleId = broker.RoleId;
    //            broker.BrokerID = ID;
    //            broker.ServerResponseID = -50052;
    //        }
    //        return broker;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoBroker()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    //public clsBroker UpdateBroker(string userIdPwd, clsBroker broker)
    //{
    //    try
    //    {
    //        if (!_lstConnectedClients.Contains(userIdPwd))
    //        {
    //            broker.ServerResponseID = -50060;

    //            return broker;
    //        }

    //        if (_BLBO.HandleUpdateIntoBrokers(broker) == BLBO.FAILURE_ID)
    //        {
    //            broker.ServerResponseID = -50060;
    //        }
    //        else
    //        {
    //            foreach (charges item in broker.LstCharges)
    //            {
    //                if (item.ChargesID <= 0)
    //                {
    //                    broker.LstCharges[broker.LstCharges.IndexOf(item)].ChargesID = _BLBO.HandleInsertIntoSymbolCharges(item, broker.BrokerID);
    //                    broker.LstCharges[broker.LstCharges.IndexOf(item)].BrokersGroupID = broker.BrokerID;
    //                }
    //                else
    //                {
    //                    _BLBO.HandleDBBO_UpdateSymbolCharges(item);
    //                }
    //            }

    //            broker.ServerResponseID = -50052;
    //        }
    //        return broker;
    //    }
    //    catch (Exception ex)
    //    {
    //        Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
    //                "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateBroker()");

    //        throw new FaultException(ex.Message);
    //    }
    //}

    #endregion

    #region IBrokerList Members

    public List<clsBrokerList> GetBrokerList(string userIdPwd)
    {
        try
        {
            List<clsBrokerList> lstBrokerList = new List<clsBrokerList>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsBrokerList objclsBrokerList = new clsBrokerList();

                objclsBrokerList.ServerResponseID = -50060;
                lstBrokerList.Add(objclsBrokerList);
                return lstBrokerList;
            }
            List<BO_GetBrokerTypesListResult> spResult = _BLBO.HandleBO_GetBrokerTypesList();
            if (spResult == null)
            {
                return lstBrokerList;
            }
            foreach (BO_GetBrokerTypesListResult item in spResult)
            {
                clsBrokerList objclsBrokerList = new clsBrokerList();
                objclsBrokerList.BrokerType = item.BrokerType;
                objclsBrokerList.BrokerTypesID = item.PK_BrokerTypesID;
                objclsBrokerList.Description = item.Description;
                objclsBrokerList.ServerResponseID = -50052;

                lstBrokerList.Add(objclsBrokerList);
            }

            return lstBrokerList;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetBrokerList()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IModule Members

    public List<clsModule> GetModules(string userIdPwd)
    {
        try
        {
            List<clsModule> lstModules = new List<clsModule>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsModule objclsModule = new clsModule();

                objclsModule.ServerResponseID = -50060;
                lstModules.Add(objclsModule);
                return lstModules;
            }
            List<BO_GetAllModulesResult> spResult = _BLBO.HandleBO_GetAllModules();
            if (spResult == null)
            {
                return lstModules;
            }
            foreach (BO_GetAllModulesResult item in spResult)
            {
                clsModule objclsModule = new clsModule();
                objclsModule.ID = item.Id;
                objclsModule.ModName = item.ModName;
                objclsModule.ServerResponseID = -50052;

                lstModules.Add(objclsModule);
            }

            return lstModules;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetModules()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ILeverage Members

    public List<clsLeverage> GetLeverageList(string userIdPwd)
    {
        try
        {
            List<clsLeverage> lstLeverage = new List<clsLeverage>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsLeverage objclsLeverage = new clsLeverage();

                objclsLeverage.ServerResponseID = -50060;
                lstLeverage.Add(objclsLeverage);
                return lstLeverage;
            }
            List<BO_GetLeverageListResult> spResult = _BLBO.HandleBO_GetLeverageList();
            if (spResult == null)
            {
                return lstLeverage;
            }
            foreach (BO_GetLeverageListResult item in spResult)
            {
                clsLeverage objclsLeverage = new clsLeverage();
                objclsLeverage.Leverage = item.Leverage;
                objclsLeverage.LeverageId = item.PK_LeverageId;
                objclsLeverage.ServerResponseID = -50052;

                lstLeverage.Add(objclsLeverage);
            }

            return lstLeverage;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetLeverageList()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IParticipaintList Members

    public List<clsParticipaintList> GetParticipaintList(string userIdPwd)
    {
        try
        {
            List<clsParticipaintList> lstPartcipaint = new List<clsParticipaintList>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsParticipaintList objclsParticipaintList = new clsParticipaintList();

                objclsParticipaintList.ServerResponseID = -50060;
                lstPartcipaint.Add(objclsParticipaintList);
                return lstPartcipaint;
            }
            List<BO_GetParticipantTypeListResult> spResult = _BLBO.HandleBO_GetParticipantTypeList();
            if (spResult == null)
            {
                return lstPartcipaint;
            }
            foreach (BO_GetParticipantTypeListResult item in spResult)
            {
                clsParticipaintList objclsParticipaintList = new clsParticipaintList();
                objclsParticipaintList.PKParticipantTypeID = item.PK_ParticipantTypeID;
                objclsParticipaintList.ParticpantTypeName = item.ParticpantTypeName;
                objclsParticipaintList.ServerResponseID = -50052;

                lstPartcipaint.Add(objclsParticipaintList);
            }

            return lstPartcipaint;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetParticipaintList()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICountryDetail Members

    public List<clsCountryDetail> GetCountryDetails(string userIdPwd)
    {
        try
        {
            List<clsCountryDetail> lstCountryDetail = new List<clsCountryDetail>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsCountryDetail objclsCountryDetail = new clsCountryDetail();

                objclsCountryDetail.ServerResponseID = -50060;
                lstCountryDetail.Add(objclsCountryDetail);
                return lstCountryDetail;
            }
            List<BO_GetCountryMasterInfoResult> spResult = _BLBO.HandleBO_GetCountryMasterInfo();
            if (spResult == null)
            {
                return lstCountryDetail;
            }
            foreach (BO_GetCountryMasterInfoResult item in spResult)
            {
                clsCountryDetail objclsCountryDetail = new clsCountryDetail();
                objclsCountryDetail.CountryCode = item.CountryCode;
                objclsCountryDetail.CountryId = item.PK_CountryID;
                objclsCountryDetail.CountryName = item.CountryName;
                objclsCountryDetail.Nationality = item.Nationality;
                objclsCountryDetail.ServerResponseID = -50052;

                lstCountryDetail.Add(objclsCountryDetail);
            }

            return lstCountryDetail;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCountryDetails()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICollateralTypes Members

    public List<clsCollateralTypes> GetCollateralTypes(string userIdPwd)
    {
        try
        {
            List<clsCollateralTypes> lstCollateralTypes = new List<clsCollateralTypes>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsCollateralTypes objclsCollateralTypes = new clsCollateralTypes();

                objclsCollateralTypes.ServerResponseID = -50060;
                lstCollateralTypes.Add(objclsCollateralTypes);
                return lstCollateralTypes;
            }
            List<BO_GetAllCollateralTypesResult> spResult = _BLBO.HandleBO_GetAllCollateralTypes();
            if (spResult == null)
            {
                return lstCollateralTypes;
            }
            foreach (BO_GetAllCollateralTypesResult item in spResult)
            {
                clsCollateralTypes objclsCollateralTypes = new clsCollateralTypes();
                objclsCollateralTypes.CollateralType = item.CollateralType;
                objclsCollateralTypes.CollateralTypeID = item.PK_CollateralTypeID;
                objclsCollateralTypes.ServerResponseID = -50052;

                lstCollateralTypes.Add(objclsCollateralTypes);
            }

            return lstCollateralTypes;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCollateralTypes()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IAccount Members

    public List<clsAccount> GetAccounts(string userIdPwd, int clientID, AccountOpType opType)
    {
        try
        {
            List<clsAccount> lstAccount = new List<clsAccount>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsAccount objclsAccount = new clsAccount();

                objclsAccount.ServerResponseID = -50060;
                lstAccount.Add(objclsAccount);
                return lstAccount;
            }
            switch (opType)
            {
                case AccountOpType.ACCOUNT:
                    {
                        List<BO_GetClientAccountInformationResult> spResult = _BLBO.HandleBO_GetClientAccountInformation(clientID);
                        if (spResult == null)
                        {
                            return lstAccount;
                        }
                        foreach (BO_GetClientAccountInformationResult item in spResult)
                        {
                            clsAccount objclsAccount = new clsAccount();
                            objclsAccount.AccountGroupId = clsUtility.GetInt(item.FK_AccountGroupID);
                            objclsAccount.AccountId = item.PK_AccountId;
                            objclsAccount.Balence = item.Balance;
                            objclsAccount.ClientId = clientID;
                            objclsAccount.CurrencyId = clsUtility.GetInt(item.FK_Currency);
                            objclsAccount.Deleted = Convert.ToBoolean(item.Deleted);
                            objclsAccount.Equity = item.Equity;
                            objclsAccount.IsHedgingAllowed = Convert.ToBoolean(item.IsHedgingAllowed);
                            objclsAccount.IsTradeEnable = Convert.ToBoolean(item.IsTradeEnable);
                            objclsAccount.SellSideTurnOver = item.SellSideTurnOver;
                            objclsAccount.BuySideTurnOver = item.BuySideTurnOver;
                            objclsAccount.LeverageId = item.FK_Leverage;
                            objclsAccount.UsedMargin = item.UsedMargin;
                            objclsAccount.IsLive = Convert.ToBoolean(item.IsLive);
                            //if (item.FK_BankID.HasValue)
                            objclsAccount.RelatedBankId = clsUtility.GetInt(item.FK_BankID);
                            //else
                            //objclsAccount.RelatedBankId = 0;
                            objclsAccount.HedgeTypeID = clsUtility.GetInt(item.FK_HedgeType_ID);
                            objclsAccount.ServerResponseID = -50052;

                            lstAccount.Add(objclsAccount);
                        }
                    }
                    break;
                case AccountOpType.ACCOUNT_TRANSACTION:
                    {
                        //List<BO_GetAccountTransactionResult> spResult = _BLBO.BO_GetAccountTransactionInfo(clientID);
                        //if (spResult == null)
                        //{
                        //    return lstAccount;
                        //}
                        //foreach (BO_GetAccountTransactionResult item in spResult)
                        //{
                        //    clsAccount objclsAccount = new clsAccount();
                        //    objclsAccount.AccountId = clsUtility.GetInt(item.Account_ID);
                        //    objclsAccount.ClientId = clientID;
                        //    objclsAccount.PaymentAmount = clsUtility.GetDecimal(item.Amount);
                        //    objclsAccount.PaymentType = clsUtility.GetStr(item.PaymentType);
                        //    objclsAccount.PaymentMode = clsUtility.GetStr(item.PaymentMode);
                        //    objclsAccount.PaymentDate = clsUtility.GetDate(item.PaymentDate);
                        //    objclsAccount.ChequeFdNo = clsUtility.GetStr(item.Cheque_FD_No);
                        //    objclsAccount.Remark = clsUtility.GetStr(item.Remark);
                        //    objclsAccount.EditAccountTransactionID = clsUtility.GetInt(item.PK_TransactionID);
                        //    objclsAccount.ServerResponseID = -50052;

                        //    lstAccount.Add(objclsAccount);
                        //}
                    }
                    break;
            }


            return lstAccount;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetAccounts()");

            throw new FaultException(ex.Message);
        }
    }

    public clsAccount InsertIntoAccount(string userIdPwd, clsAccount account)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                account.ServerResponseID = -50060;

                return account;
            }
            int ID = _BLBO.HandleBO_InsertAccountDetail(account);
            if (ID == BLBO.FAILURE_ID)
            {
                account.ServerResponseID = -50060;
            }
            else
            {
                account.AccountId = account.AccountId;
                account.ServerResponseID = -50052;
            }
            return account;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoAccount()");

            throw new FaultException(ex.Message);
        }
    }

    public clsAccount UpdateAccount(string userIdPwd, clsAccount account, AccountOpType opType)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                account.ServerResponseID = -50060;

                return account;
            }

            switch (opType)
            {
                case AccountOpType.ACCOUNT:
                    {
                        if (_BLBO.HandleBO_UpdateAccountDetails(account) == BLBO.FAILURE_ID)
                        {
                            account.ServerResponseID = -50060;
                        }
                        else
                        {
                            account.ServerResponseID = -50052;
                        }
                    }
                    break;
                case AccountOpType.ACCOUNT_TRANSACTION:
                    {
                        if (_BLBO.Bo_UpdateAccountTransactionInfo(account) == BLBO.FAILURE_ID)
                        {
                            account.ServerResponseID = -50060;
                        }
                        else
                        {
                            account.ServerResponseID = -50052;
                        }
                    }
                    break;
            }

            return account;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateAccount()");

            throw new FaultException(ex.Message);
        }
    }
    #endregion

    #region IAccountGroup Members

    public List<clsAccountGroup> GetAccountGroup(string userIdPwd)
    {
        try
        {
            List<clsAccountGroup> lstAccountGroup = new List<clsAccountGroup>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsAccountGroup objclsAccountGroup = new clsAccountGroup();

                objclsAccountGroup.ServerResponseID = -50060;
                lstAccountGroup.Add(objclsAccountGroup);
                return lstAccountGroup;
            }
            //List<BO_GetAllAccountGroupInfoResult> spResult = _BLBO.HandleBO_GetAllAccountGroupInfo();
            //if (spResult == null)
            //{
            //    return lstAccountGroup;
            //}
            //foreach (BO_GetAllAccountGroupInfoResult item in spResult)
            //{
            //    clsAccountGroup objclsAccountGroup = new clsAccountGroup();
            //    objclsAccountGroup.AccountGroupID = item.AccountGroupID;
            //    objclsAccountGroup.AccountGroupName = item.AccountGroupName;
            //    objclsAccountGroup.BrokerAddress = item.BrokerAddress;
            //    objclsAccountGroup.BrokerCity = item.BrokerCity;
            //    objclsAccountGroup.BrokerEmail = item.BrokerEmail;
            //    objclsAccountGroup.BrokerFax = item.BrokerFax;
            //    objclsAccountGroup.BrokerPhone1 = item.BrokerFax;
            //    objclsAccountGroup.BrokerPhone2 = item.BrokerPhone1;
            //    objclsAccountGroup.BrokerState = item.BrokerState;
            //    objclsAccountGroup.BrokerTypeID = item.FK_BrokerTypeID.HasValue ? item.FK_BrokerTypeID.Value : 0;
            //    objclsAccountGroup.Charges = item.Charges.HasValue ? item.Charges.Value : 0;
            //    objclsAccountGroup.IsEnable = item.IsEnable.HasValue ? item.IsEnable.Value : false;
            //    objclsAccountGroup.LeverageId = item.FK_LeverageID;
            //    objclsAccountGroup.Owner = item.Owner;
            //    objclsAccountGroup.ParentBrokerId = clsUtility.GetInt(item.ParentAccountGroupID);
            //    objclsAccountGroup.Password = clsUtility.GetStr(item.Password);
            //    objclsAccountGroup.ServerResponseID = -50052;

            //    lstAccountGroup.Add(objclsAccountGroup);
            //}
            lstAccountGroup = _BLBO.GetAllAccountGrouplist();
            return lstAccountGroup;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetAccountGroup()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IBank Members

    public List<clsBank> GetBankInfo(string userIdPwd, int clientID)
    {
        try
        {
            List<clsBank> lstBankInfo = new List<clsBank>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsBank objclsBank = new clsBank();

                objclsBank.ServerResponseID = -50060;
                lstBankInfo.Add(objclsBank);
                return lstBankInfo;
            }
            List<BO_GetClientBankInformationResult> spResult = _BLBO.HandleBO_GetClientsBankInfo(clientID);
            if (spResult == null)
            {
                return lstBankInfo;
            }
            foreach (BO_GetClientBankInformationResult item in spResult)
            {
                clsBank objclsBank = new clsBank();
                objclsBank.AccountHolderName = item.AccountHolderName;
                objclsBank.BankAccountID = item.BankAccountID;
                objclsBank.BankAccountType = item.BankAccountType;
                objclsBank.BankAddress = item.BankAddress1;
                objclsBank.BankAddress2 = item.BankAddress2;
                objclsBank.BankCity = item.BankCity;
                objclsBank.BankCountryID = Convert.ToInt32(item.FK_BankCountryID);
                objclsBank.BankFax = item.BankFax;
                objclsBank.BankIFSCCode = item.BankIFSCCode;
                objclsBank.BankID = item.PK_BankID;
                objclsBank.BankName = item.BankName;
                objclsBank.BankPhone = item.BankPhone;
                objclsBank.BankSwiftCode = item.BankSwiftCode;
                objclsBank.BankZipCode = item.BankZipCode;
                objclsBank.ClientID = Convert.ToInt32(item.FK_ParticipantID);
                objclsBank.ServerResponseID = -50052;

                lstBankInfo.Add(objclsBank);
            }

            return lstBankInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetBankInfo()");

            throw new FaultException(ex.Message);
        }
    }

    public clsBank InsertIntoBankInfo(string userIdPwd, clsBank bank)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                bank.ServerResponseID = -50060;

                return bank;
            }

            int ID = _BLBO.HandleBO_InsertBankDetails(bank);
            if (ID == BLBO.FAILURE_ID)
            {
                bank.ServerResponseID = -50060;
            }
            else
            {
                bank.BankID = bank.BankID;
                bank.ServerResponseID = -50052;
            }
            return bank;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoBankInfo()");

            throw new FaultException(ex.Message);
        }
    }

    public clsBank UpdateBankInfo(string userIdPwd, clsBank bank)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                bank.ServerResponseID = -50060;

                return bank;
            }

            if (_BLBO.HandleBO_UpdateBankDetails(bank) == BLBO.FAILURE_ID)
            {
                bank.ServerResponseID = -50060;
            }
            else
            {
                bank.ServerResponseID = -50052;
            }
            return bank;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateBankInfo()");

            throw new FaultException(ex.Message);
        }
    }
    #endregion

    #region IClientInfo Members

    public List<clsClientInfo> GetClientInfo(string userIdPwd)
    {
        try
        {
            List<clsClientInfo> lstClientInfo = new List<clsClientInfo>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsClientInfo objclsClientInfo = new clsClientInfo();

                objclsClientInfo.ServerResponseID = -50060;
                lstClientInfo.Add(objclsClientInfo);
                return lstClientInfo;
            }
            List<BO_GetParticipantAccountInfoResult> spResult = _BLBO.HandleBO_GetParticipantAccountInfo();
            if (spResult == null)
            {
                return lstClientInfo;
            }
            foreach (BO_GetParticipantAccountInfoResult item in spResult)
            {
                try
                {

                    clsClientInfo objclsClientInfo = new clsClientInfo();
                    objclsClientInfo.AccountGroupID = clsUtility.GetInt(item.FK_AccountGroupID);
                    objclsClientInfo.AccountType = clsUtility.GetStr(item.AccountTypeName);
                    objclsClientInfo.Address1 = clsUtility.GetStr(item.Address1);
                    objclsClientInfo.Address2 = clsUtility.GetStr(item.Address2);
                    objclsClientInfo.Age = clsUtility.GetStr(item.Age);
                    objclsClientInfo.Balance = item.Balance.HasValue ? (decimal)item.Balance : 0;
                    objclsClientInfo.City = clsUtility.GetStr(item.City);
                    objclsClientInfo.ClientId = clsUtility.GetInt(item.ClientID);
                    objclsClientInfo.FKCountryID = clsUtility.GetInt(item.FK_CountryID);
                    objclsClientInfo.Deleted = Convert.ToBoolean(item.Deleted);
                    objclsClientInfo.DOB = clsUtility.GetDate(item.DOB);
                    objclsClientInfo.Equity = item.Equity.HasValue ? (decimal)item.Equity : 0;
                    objclsClientInfo.FaxNumber = clsUtility.GetStr(item.FaxNumber);
                    objclsClientInfo.FirstName = clsUtility.GetStr(item.FirstName);
                    objclsClientInfo.FKAccountTypeID = clsUtility.GetInt(item.FK_AccountTypeID);
                    objclsClientInfo.FKNationalityID = clsUtility.GetInt(item.FK_NationalityID);
                    objclsClientInfo.FKParticipantType = clsUtility.GetInt(item.FK_ParticipantType);
                    objclsClientInfo.Gender = clsUtility.GetStr(item.Gender);
                    objclsClientInfo.GroupName = clsUtility.GetStr(item.AccountGroupName);
                    objclsClientInfo.LastName = clsUtility.GetStr(item.LastName);
                    objclsClientInfo.LoginID = clsUtility.GetStr(item.LoginID);
                    objclsClientInfo.MasterPassword = clsUtility.GetStr(item.MasterPassword);
                    objclsClientInfo.MidleName = clsUtility.GetStr(item.MidleName);
                    objclsClientInfo.Mobile = clsUtility.GetStr(item.Mobile);
                    objclsClientInfo.PAN = clsUtility.GetStr(item.PAN);
                    objclsClientInfo.PassportId = clsUtility.GetStr(item.PassportID);
                    objclsClientInfo.PrimaryEmailAddress = clsUtility.GetStr(item.PrimaryEmailAddress);
                    objclsClientInfo.PrimaryPhone = clsUtility.GetStr(item.PrimaryPhone);
                    objclsClientInfo.RegistrationDate = clsUtility.GetDate(item.RegistrationDate);
                    objclsClientInfo.SecondaryEmailAddress = clsUtility.GetStr(item.SecondaryEmailAddress);
                    objclsClientInfo.SecondaryPhone = clsUtility.GetStr(item.SecondaryPhone);
                    objclsClientInfo.SSN = clsUtility.GetStr(item.SSN);
                    objclsClientInfo.State = clsUtility.GetStr(item.State);
                    objclsClientInfo.Status = Convert.ToBoolean(item.Status);
                    objclsClientInfo.TradingPassword = clsUtility.GetStr(item.TradingPassword);
                    objclsClientInfo.Zip = clsUtility.GetStr(item.Zip);
                    objclsClientInfo.MarkupValue = clsUtility.GetDecimal(item.MarkupValue);
                    objclsClientInfo.ServerResponseID = -50052;

                    lstClientInfo.Add(objclsClientInfo);
                }
                catch (Exception)
                {

                }
            }

            return lstClientInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                    //"ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetClientInfo()");

            throw new FaultException(ex.Message);
        }
    }

    public clsClientInfo InsertIntoClientInfo(string userIdPwd, clsClientInfo clientInfo)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clientInfo.ServerResponseID = -50060;

                return clientInfo;
            }

            // if (!_BLBO.CLientLoginAuth(clientInfo.LoginID))
            {
                int ID = _BLBO.HandleBO_InsertParticipantDetails(clientInfo);
                if (ID == BLBO.FAILURE_ID)
                {
                    clientInfo.ServerResponseID = -50060;
                }
                else
                {
                    clientInfo.ClientId = clientInfo.ClientId;
                    clientInfo.ServerResponseID = -50052;
                }
            }
            //else
            //{
            //    clientInfo.IsExists = true;
            //    clientInfo.ServerResponseID = -50060;
            //}
            return clientInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in InsertIntoClientInfo()");

            throw new FaultException(ex.Message);
        }
    }

    public clsClientInfo UpdateClientInfo(string userIdPwd, clsClientInfo clientInfo)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clientInfo.ServerResponseID = -50060;

                return clientInfo;
            }

            if (_BLBO.HandleBO_UpdateParticipantDetails(clientInfo) == BLBO.FAILURE_ID)
            {
                clientInfo.ServerResponseID = -50060;
            }
            else
            {
                clientInfo.ServerResponseID = -50052;
            }
            return clientInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in UpdateClientInfo()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICollateralInfo Members

    public List<clsCollateralInfo> GetCollateralInfo(string userIdPwd)
    {
        try
        {
            List<clsCollateralInfo> lstCollateralInfo = new List<clsCollateralInfo>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsCollateralInfo objclsCollateralInfo = new clsCollateralInfo();

                objclsCollateralInfo.ServerResponseID = -50060;
                lstCollateralInfo.Add(objclsCollateralInfo);
                return lstCollateralInfo;
            }
            List<BO_GetBrokersCollateralInfoResult> spResult = _BLBO.HandleBO_GetBrokersCollateralInfo();
            if (spResult == null)
            {
                return lstCollateralInfo;
            }
            foreach (BO_GetBrokersCollateralInfoResult item in spResult)
            {
                clsCollateralInfo objclsCollateralInfo = new clsCollateralInfo();
                objclsCollateralInfo.AccountGroupID = item.PK_AccountGroupID;
                objclsCollateralInfo.AccountGroupName = item.AccountGroupName;
                objclsCollateralInfo.BrokerType = item.BrokerType;
                objclsCollateralInfo.BrokerTypeID = item.FK_BrokerTypeID.HasValue ? clsUtility.GetInt(item.FK_BrokerTypeID) : 0;
                objclsCollateralInfo.CollateralforTrading = item.CollateralforTrading.HasValue ? clsUtility.GetDecimal(item.CollateralforTrading) : 0;
                objclsCollateralInfo.IsEnable = item.IsEnable.HasValue ? Convert.ToBoolean(item.IsEnable) : false;
                objclsCollateralInfo.Leverage = item.Leverage;
                objclsCollateralInfo.Owner = item.Owner;
                objclsCollateralInfo.ParentAccountGroupID = item.ParentAccountGroupID.HasValue ? clsUtility.GetInt(item.ParentAccountGroupID) : 0;
                objclsCollateralInfo.ParentOwner = item.ParentOwner;
                objclsCollateralInfo.PayInShortage = item.PayInShortage.HasValue ? clsUtility.GetDecimal(item.PayInShortage) : 0;
                objclsCollateralInfo.PayOutShortage = item.PayOutShortage.HasValue ? clsUtility.GetDecimal(item.PayOutShortage) : 0;
                objclsCollateralInfo.TotalCollateral = item.TotalCollateral.HasValue ? clsUtility.GetDecimal(item.TotalCollateral) : 0;
                objclsCollateralInfo.Unallocated = item.Unallocated.HasValue ? clsUtility.GetDecimal(item.Unallocated) : 0;
                objclsCollateralInfo.Utilized = item.Utilized.HasValue ? clsUtility.GetDecimal(item.Utilized) : 0;
                objclsCollateralInfo.ServerResponseID = -50052;

                lstCollateralInfo.Add(objclsCollateralInfo);
            }

            return lstCollateralInfo;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCollateralInfo()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICollateralTransInfo Members

    public List<clsCollateralTransInfo> HandleCollateralTransInfo(string userIdPwd, int accountGroupID, OperationTypes opType, clsCollateralTransInfo collateralTransInfo)
    {
        try
        {
            List<clsCollateralTransInfo> lstCollateralTrans = new List<clsCollateralTransInfo>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsCollateralTransInfo objclsCollateralTransInfo = new clsCollateralTransInfo();

                objclsCollateralTransInfo.ServerResponseID = -50060;
                lstCollateralTrans.Add(objclsCollateralTransInfo);
                return lstCollateralTrans;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetLastCollateralTransInfoForAccGrpResult> spResult = _BLBO.HandleBO_GetLastCollateralTransInfoForAccGrp(accountGroupID);
                        if (spResult == null)
                        {
                            return lstCollateralTrans;
                        }
                        foreach (BO_GetLastCollateralTransInfoForAccGrpResult item in spResult)
                        {
                            clsCollateralTransInfo objclsCollateralTransInfo = new clsCollateralTransInfo();
                            objclsCollateralTransInfo.AccountGroupId = clsUtility.GetInt(item.FK_AccountGroupID);
                            objclsCollateralTransInfo.Amount = item.Amount;
                            objclsCollateralTransInfo.CollateralType = item.CollateralType;
                            objclsCollateralTransInfo.CollateralTypeId = item.FK_CollateralTypeID;
                            objclsCollateralTransInfo.TotalAmount = item.TotalAmount;
                            objclsCollateralTransInfo.TransactionDate = item.LastTransDate;
                            objclsCollateralTransInfo.TransactionType = item.TransactionType;
                            objclsCollateralTransInfo.IsNewCollateralTrans = false;
                            objclsCollateralTransInfo.ServerResponseID = -50052;

                            lstCollateralTrans.Add(objclsCollateralTransInfo);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleInsertIntoBrokersCollateralTransaction(collateralTransInfo);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            collateralTransInfo.ServerResponseID = -50060;
                        }
                        else
                        {
                            collateralTransInfo.IsNewCollateralTrans = true;
                            collateralTransInfo.ServerResponseID = -50052;
                        }
                        lstCollateralTrans.Add(collateralTransInfo);
                    }
                    break;
            }

            return lstCollateralTrans;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCollateralTransInfo()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ITrades Members

    public List<clsTrades> GetTradeOrdersDetails(string userIdPwd, DateTime startDate, DateTime endDate)
    {
        try
        {
            List<clsTrades> lstTrades = new List<clsTrades>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsTrades objclsTrades = new clsTrades();

                objclsTrades.ServerResponseID = -50060;
                lstTrades.Add(objclsTrades);
                return lstTrades;
            }
            List<OMS_GetOrderInfoResult> spResult = _BLBO.HandleBO_GetOrderInfo(startDate, endDate);
            if (spResult == null)
            {
                return lstTrades;
            }
            foreach (OMS_GetOrderInfoResult item in spResult)
            {
                clsTrades objclsTrades = new clsTrades();
                objclsTrades.AccountID = item.FK_AccountID;
                objclsTrades.OrderID = clsUtility.GetInt(item.PK_OrderID);
                objclsTrades.TradeNo = clsUtility.GetInt(item.TradeNo);
                objclsTrades.OrderPrice = item.Price.ToString();
                objclsTrades.Quantity = clsUtility.GetInt(item.PositionSize);
                objclsTrades.Time = Convert.ToDateTime(item.OrderDateTimeRequested);
                objclsTrades.Type = item.Side;
                if (item.GTD != null)
                {
                    objclsTrades.Validity = clsUtility.GetDate(item.GTD);
                }

                objclsTrades.TriggerPrice = item.StopPx.ToString();
                objclsTrades.SymbolID = item.ContractName;
                objclsTrades.Status = item.OrderStatus.ToString();
                objclsTrades.OrderType = item.Name;
                objclsTrades.Comment = item.Reason;
                objclsTrades.BrokerName = item.BrokerName;
                objclsTrades.Volume = clsUtility.GetInt(item.PositionSize);
                objclsTrades.FilledQuantity = clsUtility.GetInt(item.FilledQty);
                objclsTrades.LeaveQuantity = clsUtility.GetInt(item.LeaveQty);
                objclsTrades.AvgFillPrice = clsUtility.GetInt(item.AvgFillPRice);
                objclsTrades.SettledQty = clsUtility.GetInt(item.SettledQty);
                objclsTrades.ServerResponseID = -50052;

                lstTrades.Add(objclsTrades);
            }

            return lstTrades;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTradeOrdersDetails()");

            throw new FaultException(ex.Message);
        }
    }
    public List<clsTrades> GetTradeDetails(string userIdPwd, DateTime startDate, DateTime endDate)
    {
        try
        {
            List<clsTrades> lstTrades = new List<clsTrades>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsTrades objclsTrades = new clsTrades();

                objclsTrades.ServerResponseID = -50060;
                lstTrades.Add(objclsTrades);
                return lstTrades;
            }
            List<OMS_GetTradesInfoResult> spResult = _BLBO.HandleBO_GetTradeInfo(startDate, endDate);
            if (spResult == null)
            {
                return lstTrades;
            }
            foreach (OMS_GetTradesInfoResult item in spResult)
            {
                clsTrades objclsTrades = new clsTrades();
                objclsTrades.AccountID = item.FK_AccountID;
                objclsTrades.OrderID = clsUtility.GetInt(item.PK_OrderID);
                objclsTrades.TradeNo = clsUtility.GetInt(item.TradeNo);
                objclsTrades.OrderPrice = item.Price.ToString();
                objclsTrades.Quantity = clsUtility.GetInt(item.PositionSize);
                objclsTrades.Time = Convert.ToDateTime(item.OrderDateTimeRequested);
                objclsTrades.Type = item.Side;
                if (item.GTD != null)
                {
                    objclsTrades.Validity = clsUtility.GetDate(item.GTD);
                }

                objclsTrades.TriggerPrice = item.StopPx.ToString();
                objclsTrades.SymbolID = item.ContractName;
                objclsTrades.Status = item.OrderStatus.ToString();
                objclsTrades.OrderType = item.Name;
                objclsTrades.Comment = item.Reason;
                objclsTrades.BrokerName = item.BrokerName;
                objclsTrades.Volume = clsUtility.GetInt(item.PositionSize);
                objclsTrades.FilledQuantity = clsUtility.GetInt(item.FilledQty);
                objclsTrades.LeaveQuantity = clsUtility.GetInt(item.LeaveQty);
                objclsTrades.AvgFillPrice = clsUtility.GetInt(item.AvgFillPRice);
                objclsTrades.SettledQty = clsUtility.GetInt(item.SettledQty);
                objclsTrades.ServerResponseID = -50052;

                lstTrades.Add(objclsTrades);
            }

            return lstTrades;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTradeOrdersDetails()");

            throw new FaultException(ex.Message);
        }
    }
    public clsModifyTrades ModifyTrade(string userId, clsModifyTrades ModifyTrades)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userId))
            {
                ModifyTrades.ServerResponseMsg = -50060;
                return ModifyTrades;
            }

            if (_BLBO.HandleBO_ModifyTrade(ModifyTrades) == BLBO.FAILURE_ID)
            {
                ModifyTrades.ServerResponseMsg = -50060;
            }
            else
            {
                ModifyTrades.ServerResponseMsg = -50052;
            }

        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in ModifyTrade()");

            throw new FaultException(ex.Message);
        }
        return ModifyTrades;
    }

    public clsNewOrder NewTrade(string userId, clsNewOrder NewTrades)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userId))
            {                
                return NewTrades;
            }
            else
            {
                NewTrades = _BLBO.BO_OMSExchange_InsertNewOrder(NewTrades);
            }
        }
        catch (Exception ex)
        {            
            throw new FaultException(ex.Message);
        }
        return NewTrades;
    }
    public clsSettleTrade SettleTrade(string userId, clsSettleTrade settleTrade)
    {
        try
        {
            if (!_lstConnectedClients.Contains(userId))
            {
                settleTrade.ServerResponseMsg = -50060;
                return settleTrade;
            }

            if (_BLBO.HandleBO_SettleTrade(settleTrade) == BLBO.FAILURE_ID)
            {
                settleTrade.ServerResponseMsg = -50060;
            }
            else
            {
                settleTrade.ServerResponseMsg = -50052;
            }

        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in SettleTrade()");

            throw new FaultException(ex.Message);
        }
        return settleTrade;
    }
    #endregion

    #region IMapOrders Members

    public List<clsMapOrders> GetMapOrders(string userIdPwd)
    {
        try
        {
            List<clsMapOrders> lstMapOrders = new List<clsMapOrders>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsMapOrders objclsMapOrders = new clsMapOrders();

                objclsMapOrders.ServerResponseID = -50060;
                lstMapOrders.Add(objclsMapOrders);
                return lstMapOrders;
            }
            List<OME_GetMapOrderResult> spResult = _BLBO.GetMapOrderInfo();
            if (spResult == null)
            {
                return lstMapOrders;
            }
            foreach (OME_GetMapOrderResult item in spResult)
            {
                clsMapOrders objclsMapOrders = new clsMapOrders();
                objclsMapOrders.MapOrderId = clsUtility.GetInt(item.PK_ID);
                objclsMapOrders.BuyAccountID = clsUtility.GetInt(item.BuySideAccountID);
                objclsMapOrders.BuySideOrderID = clsUtility.GetLong(item.BuySideOrderID);
                objclsMapOrders.SellAccountID = clsUtility.GetInt(item.SellSideAccountID);
                objclsMapOrders.SellSideOrderID = clsUtility.GetLong(item.SellSideOrderID);
                objclsMapOrders.BuyFillID = clsUtility.GetInt(item.BuyFillID);
                objclsMapOrders.SellFillID = clsUtility.GetInt(item.SellFillID);
                objclsMapOrders.FilledQty = clsUtility.GetInt(item.Filled_Qty);
                if (item.LastUpdateTime != null)
                    objclsMapOrders.LastUpdateTime = clsUtility.GetDate(item.LastUpdateTime);
                if (clsUtility.GetDecimal(item.Price) == 0)
                {
                    objclsMapOrders.Price = 0;
                }
                else
                {
                    objclsMapOrders.Price = Math.Round(clsUtility.GetDecimal(item.Price), item.Digit.Value);
                }
                objclsMapOrders.Symbol = clsUtility.GetStr(item.Symbol);
                objclsMapOrders.ServerResponseID = -50052;

                lstMapOrders.Add(objclsMapOrders);
            }

            return lstMapOrders;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetMapOrders()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ITGAccountConnectionSettings Members

    public List<BOEngineServiceClasses.clsTGAccountConnectionSettings> HandleTGAccountConnetionSettings(string userIdPwd, OperationTypes opType, BOEngineServiceClasses.clsTGAccountConnectionSettings TGACSettings)
    {
        try
        {
            List<BOEngineServiceClasses.clsTGAccountConnectionSettings> lstTGACSettings = new List<BOEngineServiceClasses.clsTGAccountConnectionSettings>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                BOEngineServiceClasses.clsTGAccountConnectionSettings objclsTGACSettings = new BOEngineServiceClasses.clsTGAccountConnectionSettings();

                objclsTGACSettings.ServerResponseID = -50060;
                lstTGACSettings.Add(objclsTGACSettings);
                return lstTGACSettings;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetTGAccountConnectionSettingsResult> spResult = _BLBO.HandleGetTGAccountConnectionSettings();
                        if (spResult == null)
                        {
                            return lstTGACSettings;
                        }
                        foreach (BO_GetTGAccountConnectionSettingsResult item in spResult)
                        {
                            BOEngineServiceClasses.clsTGAccountConnectionSettings objclsTGACSettings = new BOEngineServiceClasses.clsTGAccountConnectionSettings();
                            objclsTGACSettings.TGID = clsUtility.GetInt(item.FK_TradingGateWaysID);
                            objclsTGACSettings.AccountId = clsUtility.GetStr(item.LPConnectionAccountID);
                            objclsTGACSettings.Password = clsUtility.GetStr(item.LPConnectionPassword);
                            objclsTGACSettings.IsEnable = Convert.ToBoolean(item.IsEnable);

                            objclsTGACSettings.ServerResponseID = -50052;

                            lstTGACSettings.Add(objclsTGACSettings);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.HandleInsertTGAccountConnectionSettings(TGACSettings);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            TGACSettings.ServerResponseID = -50060;
                        }
                        else
                        {
                            TGACSettings.ServerResponseID = -50052;
                        }
                        lstTGACSettings.Add(TGACSettings);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleUpdateTGAccountConnectionSettings(TGACSettings) == BLBO.FAILURE_ID)
                        {
                            TGACSettings.ServerResponseID = -50060;
                        }
                        else
                        {
                            TGACSettings.ServerResponseID = -50052;
                        }
                        lstTGACSettings.Add(TGACSettings);
                    }
                    break;
            }

            return lstTGACSettings;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetTGAccountConnetionSettings()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IVirtualDealer Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsVirtualDealerInfo> HandleVirtualDealer(string userId, OperationTypes opType, clsVirtualDealerInfo virtualDealer)
    {
        try
        {
            List<clsVirtualDealerInfo> lstVirtualDealer = new List<clsVirtualDealerInfo>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsVirtualDealerInfo objclsVirtualDealer = new clsVirtualDealerInfo();

                objclsVirtualDealer.ServerResponseID = -50060;
                lstVirtualDealer.Add(objclsVirtualDealer);
                return lstVirtualDealer;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetVirtualDealersResult> spResult = _BLBO.GetVirtualDealerInfo();
                        if (lstVirtualDealer == null)
                        {
                            return lstVirtualDealer;
                        }
                        foreach (BO_GetVirtualDealersResult item in spResult)
                        {
                            clsVirtualDealerInfo objclsVirtualDealer = new clsVirtualDealerInfo();

                            objclsVirtualDealer.VirtualDealerID = clsUtility.GetInt(item.PK_VirtualDealerID);
                            objclsVirtualDealer.Delay = clsUtility.GetInt(item.Delay);
                            objclsVirtualDealer.VirtualManagerAccount = clsUtility.GetStr(item.Virtual_Manager_Account);
                            objclsVirtualDealer.Groups = clsUtility.GetStr(item.Groups);
                            objclsVirtualDealer.Symbols = clsUtility.GetStr(item.Symbols);
                            objclsVirtualDealer.MaximumVolume = clsUtility.GetDecimal(item.Max_Volume);
                            objclsVirtualDealer.MaximumLosingSlippage = clsUtility.GetInt(item.Max_Losing_Slippage);
                            objclsVirtualDealer.MaximumProfitSlippage = clsUtility.GetInt(item.Max_Profit_Slippage);
                            objclsVirtualDealer.MaximumProfitSlippageVolume = clsUtility.GetInt(item.Max_Profit_Slippage_Volume);
                            objclsVirtualDealer.GapLevel = clsUtility.GetInt(item.Gap_Level.Value);
                            objclsVirtualDealer.GapSafeLevel = clsUtility.GetInt(item.Gap_Safe_Level.Value);
                            objclsVirtualDealer.GapTickCounter = clsUtility.GetInt(item.Gap_Tick_Counter.Value);
                            objclsVirtualDealer.GapPendingCancel = clsUtility.GetInt(item.Gap_Pendings_Cancel.Value);
                            objclsVirtualDealer.GapTakeProfitSlide = clsUtility.GetInt(item.Gap_Take_Profit_Slide.Value);
                            objclsVirtualDealer.GapStopLossSlide = clsUtility.GetInt(item.Gap_Stop_Loss_Slide.Value);
                            objclsVirtualDealer.NewsStopsFreezes = clsUtility.GetInt(item.News_Stops_Freezes.Value);
                            objclsVirtualDealer.AllowPendingsOnNews = clsUtility.GetInt(item.Allow_Pendings_On_News.Value);
                            objclsVirtualDealer.ServerResponseID = -50052;

                            lstVirtualDealer.Add(objclsVirtualDealer);
                        }
                    }
                    break;
                case OperationTypes.INSERT:
                    {
                        int ID = _BLBO.InsertVirtualDealerInfo(virtualDealer);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            virtualDealer.ServerResponseID = -50060;
                        }
                        else
                        {
                            virtualDealer.VirtualDealerID = ID;
                            virtualDealer.ServerResponseID = -50052;
                        }
                        lstVirtualDealer.Add(virtualDealer);
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.UpdateVirtualDealerInfo(virtualDealer) == BLBO.FAILURE_ID)
                        {
                            virtualDealer.ServerResponseID = -50060;
                        }
                        else
                        {
                            virtualDealer.ServerResponseID = -50052;
                        }
                        lstVirtualDealer.Add(virtualDealer);
                    }
                    break;
                case OperationTypes.DELETE:
                    {
                        int ID = _BLBO.DeleteVirtualDealer(virtualDealer.VirtualDealerID);
                        if (ID == BLBO.FAILURE_ID)
                        {
                            virtualDealer.VirtualDealerID = -50060;
                        }
                        else
                        {
                            virtualDealer.VirtualDealerID = ID;
                        }
                        lstVirtualDealer.Add(virtualDealer);
                    }
                    break;
            }

            return lstVirtualDealer;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetVirtualDealer()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICommonSettings Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsCommonSettings> HandleCommonSettings(string userId, OperationTypes opType, clsCommonSettings commonSettings)
    {
        try
        {
            List<clsCommonSettings> lstCommonSettings = new List<clsCommonSettings>();

            if (!_lstConnectedClients.Contains(userId))
            {
                clsCommonSettings objclsCommonSettings = new clsCommonSettings();

                objclsCommonSettings.ServerResponseID = -50060;
                lstCommonSettings.Add(objclsCommonSettings);
                return lstCommonSettings;
            }

            switch (opType)
            {
                case OperationTypes.GET:
                    {
                        List<BO_GetCommonSettingNewResult> spResult = _BLBO.HandleDBBO_SelectCommonSettingsNew();
                        if (lstCommonSettings == null)
                        {
                            return lstCommonSettings;
                        }
                        foreach (BO_GetCommonSettingNewResult item in spResult)
                        {
                            clsCommonSettings objclsCommonSettings = new clsCommonSettings();

                            objclsCommonSettings.ID = item.ID;
                            objclsCommonSettings.Property = item.Property;
                            objclsCommonSettings.Value = item.Value;
                            objclsCommonSettings.ServerResponseID = -50052;

                            lstCommonSettings.Add(objclsCommonSettings);
                        }
                    }
                    break;
                case OperationTypes.UPDATE:
                    {
                        if (_BLBO.HandleBO_CommonSettingUpdate(commonSettings) == BLBO.FAILURE_ID)
                        {
                            commonSettings.ServerResponseID = -50060;
                        }
                        else
                        {
                            commonSettings.ServerResponseID = -50052;
                        }
                        lstCommonSettings.Add(commonSettings);
                    }
                    break;
            }
            return lstCommonSettings;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCommonSettings()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region ICollateralTransInfo Members

    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsCollateralTransInfo> GetCollateralTransactionHistory(string userIdPwd, int accountGroupID, int CollateralTypeID)
    {
        try
        {
            List<clsCollateralTransInfo> lstCollateralTrans = new List<clsCollateralTransInfo>();

            if (!_lstConnectedClients.Contains(userIdPwd))
            {
                clsCollateralTransInfo objclsCollateralTransInfo = new clsCollateralTransInfo();

                objclsCollateralTransInfo.ServerResponseID = -50060;
                lstCollateralTrans.Add(objclsCollateralTransInfo);
                return lstCollateralTrans;
            }
            List<BO_GetCollateralTransactionHistoryResult> spResult = _BLBO.Handle_BO_GetCollateralTransactionHistory(accountGroupID, CollateralTypeID);
            if (spResult == null)
            {
                return lstCollateralTrans;
            }
            foreach (BO_GetCollateralTransactionHistoryResult item in spResult)
            {
                clsCollateralTransInfo objclsCollateralTransInfo = new clsCollateralTransInfo();
                objclsCollateralTransInfo.AccountGroupId = clsUtility.GetInt(item.FK_AccountGroupID);
                objclsCollateralTransInfo.Amount = item.Amount;
                //objclsCollateralTransInfo.CollateralType = item.CollateralType;
                objclsCollateralTransInfo.CollateralTypeId = item.FK_CollateralTypeID;
                objclsCollateralTransInfo.TotalAmount = item.TotalAmount;
                objclsCollateralTransInfo.TransactionDate = item.LastUpdateDate.ToString();
                objclsCollateralTransInfo.TransactionType = item.TransactionType;
                objclsCollateralTransInfo.IsNewCollateralTrans = false;
                objclsCollateralTransInfo.ServerResponseID = -50052;

                lstCollateralTrans.Add(objclsCollateralTransInfo);
            }

            return lstCollateralTrans;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetCollateralTransactionHistory()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IMapOrders Members
    [OperationBehavior(AutoDisposeParameters = true)]
    public List<string> GetAccountIDsByAccountType(string userIdPwd, int AccountTypeID)
    {
        try
        {
            List<string> lstAccountIDs = new List<string>();

            List<BO_GetAccountIDsByAccountTypeIDResult> spResult = _BLBO.BO_GetAccountIDsByAccountTypeID(AccountTypeID);
            if (spResult == null)
            {
                return lstAccountIDs;
            }
            foreach (BO_GetAccountIDsByAccountTypeIDResult item in spResult)
            {
                lstAccountIDs.Add(item.PK_AccountId.ToString());
            }

            return lstAccountIDs;
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //        "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in GetAccountIDsByAccountType()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IClientInfo Members


    public bool AuthenticateClientID(string userIdPwd, string clientID)
    {
        try
        {
            return _BLBO.CLientLoginAuth(clientID);
        }
        catch (Exception ex)
        {
            //Logging.FileHandling.WriteAllLog("Exception :BOEngineService => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
            //                    "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in AuthenticateClientID()");

            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region IInstrumentClosingPrice Members

    public List<clsInstrumentClosingPrice> HandleInstClosingPrice(string userId, clsInstrumentClosingPrice instrumentClosingPrice, OperationTypes operationType)
    {
        List<clsInstrumentClosingPrice> lstInstrumentClosingPrice = new List<clsInstrumentClosingPrice>();
        if (!_lstConnectedClients.Contains(userId))
        {
            clsInstrumentClosingPrice objclsInstrumentClosingPrice = new clsInstrumentClosingPrice();

            objclsInstrumentClosingPrice.ServerResponseID = -50060;
            lstInstrumentClosingPrice.Add(objclsInstrumentClosingPrice);
            return lstInstrumentClosingPrice;
        }
        switch (operationType)
        {
            case OperationTypes.GET:
                {
                    List<BO_GetInstClosingPriceResult> spResult = _BLBO.Bo_GetInstrClosingPrice();
                    if (lstInstrumentClosingPrice == null)
                    {
                        return lstInstrumentClosingPrice;
                    }
                    foreach (BO_GetInstClosingPriceResult item in spResult)
                    {
                        clsInstrumentClosingPrice objclsInstrumentClosingPrice = new clsInstrumentClosingPrice();
                        objclsInstrumentClosingPrice.PK_InstrumentClosingPrice = clsUtility.GetLong(item.PK_InstrumentClosingPrice);
                        objclsInstrumentClosingPrice.FK_InstrumentID = clsUtility.GetInt(item.FK_InstrumentID);
                        objclsInstrumentClosingPrice.ClosingPrice = clsUtility.GetDecimal(item.ClosingPrice);
                        objclsInstrumentClosingPrice.ClosingDate = clsUtility.GetDate(item.ClosingDate);

                        objclsInstrumentClosingPrice.ServerResponseID = -50052;

                        lstInstrumentClosingPrice.Add(objclsInstrumentClosingPrice);
                    }
                }
                break;
            case OperationTypes.INSERT:
                {
                    int ID = _BLBO.Bo_InsertInstClosingPrice(instrumentClosingPrice);
                    if (ID == BLBO.FAILURE_ID)
                    {
                        instrumentClosingPrice.ServerResponseID = -50060;
                    }
                    else
                    {
                        instrumentClosingPrice.PK_InstrumentClosingPrice = ID;
                        instrumentClosingPrice.ServerResponseID = -50052;
                    }
                    lstInstrumentClosingPrice.Add(instrumentClosingPrice);
                }
                break;
            case OperationTypes.UPDATE:
                {
                    int ID = _BLBO.Bo_UpdateInstClosingPrice(instrumentClosingPrice);
                    if (ID == BLBO.FAILURE_ID)
                    {
                        instrumentClosingPrice.ServerResponseID = -50060;
                    }
                    else
                    {
                        instrumentClosingPrice.ServerResponseID = -50052;
                    }
                    lstInstrumentClosingPrice.Add(instrumentClosingPrice);
                }
                break;
        }
        return lstInstrumentClosingPrice;
    }

    #endregion

    #region ILogin Members

    [OperationBehavior(AutoDisposeParameters = true)]
    public List<clsBrokerOperationsLog> HandleBrokerOperationsLog(string LoginPwd, clsBrokerOperationsLog brokerOperations, DateTime fromDate, DateTime ToDate, OperationTypes opTypes)
    {
        List<clsBrokerOperationsLog> _lstBrokersLog = new List<clsBrokerOperationsLog>();
        if (!_lstConnectedClients.Contains(LoginPwd))
        {
            clsBrokerOperationsLog objclsBrokerOperationsLog = new clsBrokerOperationsLog();
            objclsBrokerOperationsLog.ServerResponseID = -50060;
            _lstBrokersLog.Add(objclsBrokerOperationsLog);
            return _lstBrokersLog;
        }
        switch (opTypes)
        {
            case OperationTypes.GET:
                {
                    //List<BO_GetBrokersListResult> spRslt = _BLBO.HandleBO_GetBrokersList(brokerOperations.BrokerID);

                    //foreach (var i in spRslt)
                    //{
                    //    foreach (BO_GetBrokersLogResult item in _BLBO.Bo_GetBrokersLog(Convert.ToInt32(i)))
                    //    {
                    //        clsBrokerOperationsLog objclsBrokerOperationsLog = new clsBrokerOperationsLog();
                    //        objclsBrokerOperationsLog.SNo = clsUtility.GetInt(item.SNo);
                    //        objclsBrokerOperationsLog.BrokerName = clsUtility.GetStr(item.BrokerName);
                    //        objclsBrokerOperationsLog.BrokerID = clsUtility.GetInt(item.BrokerID);
                    //        objclsBrokerOperationsLog.OperationName = clsUtility.GetStr(item.OperationName);
                    //        objclsBrokerOperationsLog.DateTime = clsUtility.GetDate(item.DateTime);
                    //        objclsBrokerOperationsLog.Message = clsUtility.GetStr(item.Message);
                    //        objclsBrokerOperationsLog.IPAddress = clsUtility.GetStr(item.IPAddress);
                    //        objclsBrokerOperationsLog.ServerResponseID = -50052;

                    //        lstBrokersLog.Add(objclsBrokerOperationsLog);
                    //    }
                    //}
                    _lstBrokersLog = _BLBO.HandleBrokersOperationsLog(brokerOperations.BrokerID, fromDate, ToDate);
                }
                break;
            case OperationTypes.INSERT:
                {
                    int id = _BLBO.Bo_InsertBrokersLog(brokerOperations);
                    if (id == -50060)
                    {
                        brokerOperations.ServerResponseID = -50060;
                    }
                    else
                    {
                        brokerOperations.SNo = id;
                        brokerOperations.ServerResponseID = -50052;
                    }
                }
                break;
        }
        return _lstBrokersLog;
    }

    #endregion

    #region ILogin Members


    public List<clsHistoricalData> GetHistoricalData(string LoginPwd, string symbolName, string periodicity, int barsNo, clsHistoricalData historicalInfo
        , OperationTypes opTypes)
    {
        List<clsHistoricalData> lstHistoricalData = new List<clsHistoricalData>();
        if (!_lstConnectedClients.Contains(LoginPwd))
        {
            clsHistoricalData objclsHistoricalData = new clsHistoricalData();
            objclsHistoricalData.ServerResponseID = -50060;
            lstHistoricalData.Add(objclsHistoricalData);
            return lstHistoricalData;
        }
        switch (opTypes)
        {
            case OperationTypes.GET:
                {
                    lstHistoricalData = _BLBO.Bo_GetHistoricalData(symbolName, periodicity, barsNo);
                }
                break;
            case OperationTypes.UPDATE:
                {
                    //historicalInfo.ServerResponseID = _BLBO.Bo_UpdateHistoryInfo(historicalInfo, periodicity);
                    //lstHistoricalData.Add(historicalInfo);
                }
                break;
        }
        return lstHistoricalData;
    }

    #endregion

    #region IClientInfo Members


    public List<clsAccountTransaction> HandleAccountTransactionOperation(string userIdPwd, OperationTypes opType, clsAccountTransaction account)
    {
        throw new NotImplementedException();
    }

    #endregion

}
