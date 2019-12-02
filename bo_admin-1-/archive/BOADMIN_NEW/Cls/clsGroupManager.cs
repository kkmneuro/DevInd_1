using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.DS;
namespace BOADMIN_NEW.Cls
{
    public class clsGroupManager : IclsManager
    {
        #region MEMBERS
        static clsGroupManager _clsGroupManager = null;
        public DS4Groups _DS4Groups = new DS4Groups();
        List<string> _lstGroupName = new List<string>();
        //Vinod created



        #endregion MEMBERS

        #region METHODS

        private clsGroupManager()
        {

        }

        public DS4Groups.dtSymbolRow[] GetSymbol(long Gid)
        {
            DS4Groups.dtSymbolRow[] rows = null;

            rows = (DS4Groups.dtSymbolRow[])_DS4Groups.dtSymbol.Select("FK_GroupID = " + Gid.ToString());

            return rows;

        }

        public DS4Groups.dtSecuritiesRow[] GetGroupSecurity(long Gid)
        {
            DS4Groups.dtSecuritiesRow[] rows = null;

            rows = (DS4Groups.dtSecuritiesRow[])_DS4Groups.dtSecurities.Select("FK_GroupID = " + Gid.ToString());

            return rows;

        }

        private void DoHandleGroupTable(Group group)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandleGroupTable()");
                DS4Groups.dtCommonRow _CommonRow = _DS4Groups.dtCommon.FindByGroupID(group._AccountGroupID);
                if (_CommonRow == null)
                {
                    _CommonRow = _DS4Groups.dtCommon.NewRow() as DS4Groups.dtCommonRow;
                    _CommonRow.GroupID = group._AccountGroupID;
                    _CommonRow.Name = group._AccountGroupName;
                    _CommonRow.Owner = group._Owner;
                    //_CommonRow.DepositCurrency = group._DepositeCurrency;
                    //_CommonRow.DepositByDefault = group._Deposite;
                    _CommonRow.LeverageByDefault = group._Leverage;
                    _CommonRow.AnnualInterestRate = group._AnnualInterestRate;
                    //_CommonRow.IsAdvancedSecurity = false;
                    _DS4Groups.dtCommon.AdddtCommonRow(_CommonRow);
                    _lstGroupName.Add(group._AccountGroupName);
                    DoHandlePermissionTable(group, false);
                    //DoHandleArchivingTable(group, false);
                    DoHandleMarginsTable(group, false);
                    DoHandleReportsTable(group, false);


                    DoHandleSymbolTable(group, false);
                    DoHandleSecuritiesTable(group, false);
                }
                else
                {
                    _CommonRow.GroupID = group._AccountGroupID;
                    _CommonRow.Name = group._AccountGroupName;
                    _CommonRow.Owner = group._Owner;
                    //_CommonRow.DepositCurrency = group._DepositeCurrency;
                    //_CommonRow.DepositByDefault = group._Deposite;
                    _CommonRow.LeverageByDefault = group._Leverage;
                    _CommonRow.AnnualInterestRate = group._AnnualInterestRate;
                    //_CommonRow.IsAdvancedSecurity = false;
                    DoHandlePermissionTable(group, true);
                    //DoHandleArchivingTable(group, true);
                    DoHandleMarginsTable(group, true);
                    DoHandleSecuritiesTable(group, true);

                    DoHandleSymbolTable(group, true);

                    DoHandleReportsTable(group, true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleGroupTable()");
            }
        }
        #region Permission handle
        private void DoHandlePermissionTable(Group group, bool isRowExist)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandlePermissionTable()");
                if (!isRowExist)
                {
                    _DS4Groups.dtPermission.AdddtPermissionRow(group._TimeOut, group._News, group._MaximumSymbols, group._MaximumOrders, group._AccountGroupID, group._GroupPermission);


                }
                else
                {
                    DS4Groups.dtPermissionRow[] row = (DS4Groups.dtPermissionRow[])_DS4Groups.dtPermission.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
                    if (row.Length == 1)
                    {
                        row[0].TimeOut = group._TimeOut;
                        row[0].News = group._News;
                        row[0].MaxSymbols = group._MaximumSymbols;
                        row[0].MaxOrders = group._MaximumOrders;
                        row[0].GroupPermission = group._GroupPermission;

                    }

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandlePermissionTable()");
            }
        }
        #endregion Permission handle

        #region Archive handle
        private void DoHandleArchivingTable(Group group, bool isRowExist)
        {
            //if (!isRowExist)
            //{
            //    _DS4Groups.dtArchiving.AdddtArchivingRow(group._InActivityPeriod, group._MaximumBalance, group._ArchiveDeletedPendingOrders, group._AccountGroupID);
            //}
            //else
            //{
            //    DS4Groups.dtArchivingRow[] row = (DS4Groups.dtArchivingRow[])_DS4Groups.dtArchiving.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
            //    if (row.Length == 1)
            //    {
            //        row[0].ArchiveDeletedPendingOrder = group._ArchiveDeletedPendingOrders;
            //        row[0].InactivePeriod = group._InActivityPeriod;
            //        row[0].MaxBalance = group._MaximumBalance;
            //        row[0].FK_GroupID = group._AccountGroupID;

            //    }

            //}
        }
        #endregion Archive handle

        #region margin handle
        private void DoHandleMarginsTable(Group group, bool isRowExist)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandlePermissionTable()");
                if (!isRowExist)
                {
                    _DS4Groups.dtMargins.AdddtMarginsRow(group._MarginCallLevel, group._StopOutLevel, group._StopOutLevelIn, group._AccountGroupID, group._MarginCallLevel2);
                }
                else
                {
                    DS4Groups.dtMarginsRow[] row = (DS4Groups.dtMarginsRow[])_DS4Groups.dtMargins.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
                    if (row.Length == 1)
                    {

                        row[0].MarginCallLevel = group._MarginCallLevel;
                        row[0].MarginCallLevel2 = group._MarginCallLevel2;
                        row[0].StopOutLevel = group._StopOutLevel;
                        //row[0].FreeMargin = group._FreeMargin;
                        //row[0].VirtualCredit = group._VirtualCredit;
                        //row[0].IsSkipFullyHedged = group._FullyHedged;
                        row[0].StopOutLevelIn = group._StopOutLevelIn;

                    }

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandlePermissionTable()");
            }
        }
        #endregion

        private void DoHandleReportsTable(Group group, bool isRowExist)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandleReportsTable()");
                if (!isRowExist)
                {
                    _DS4Groups.dtReports.AdddtReportsRow(group._SMTPServer, group._TemplatesPath, group._SMTPLogin, group._SMTPPassword, group._SupportEmail, group._Signature, group._IsCopyReport, group._AccountGroupID, group._IsActive);
                }
                else
                {
                    DS4Groups.dtReportsRow[] row = (DS4Groups.dtReportsRow[])_DS4Groups.dtReports.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
                    if (row.Length == 1)
                    {

                        row[0].SMTPServer = group._SMTPServer;
                        row[0].TemplatePath = group._TemplatesPath;
                        row[0].SMTPLogin = group._SMTPLogin;
                        row[0].SMTPPassword = group._SMTPPassword;
                        row[0].SupportEmail = group._SupportEmail;
                        row[0].Signature = group._Signature;
                        row[0].IsCopyReportToSupport = group._IsCopyReport;
                        row[0].IsEnable = group._IsActive;

                    }

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleReportsTable()");
            }
        }

        #region Security
        private void DoHandleSecuritiesTable(Group group, bool isRowExist)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandleSecuritiesTable()");
                if (!isRowExist)
                {
                    foreach (GroupSecurity item in group._lstGroupSecurity)
                    {


                        _DS4Groups.dtSecurities.AdddtSecuritiesRow(item._EnableTrade, item._RequestMode, item._Execution, item._Spread, item._MaximumDeviation, item._IsDoNotCheckFreeMarginAfterDealersAnswer, item._IsFastConfirmationOnIEWithDeviationSpecified, item._MultipleCloseByOrders, item._AutoCloseOut, item._MinLotsInaMonths, item._MaxLotsInaMonths, item._Steps, group._AccountGroupID, item._CommissionStandard, item._Taxes, item._Unit, item._Volume, item._CommissionAgent, item._SecurityIDSecurity, item._UnitAgent, item._VolumeAgent, item._EnableGroup, item._SecurityRowId);

                    }
                }
                else
                {
                    DS4Groups.dtSecuritiesRow[] row = (DS4Groups.dtSecuritiesRow[])_DS4Groups.dtSecurities.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
                    if (row != null)
                    {
                        int index = 0;
                        foreach (GroupSecurity item in group._lstGroupSecurity)
                        {
                            row[index].IsTrade = item._EnableTrade;
                            row[index].IsUseConfirmationIn = item._RequestMode;
                            row[index].Execution = item._Execution;
                            row[index].SpreadDifference = item._Spread;
                            row[index].MaximumDeviation = item._MaximumDeviation;
                            row[index].IsDoNotCheckFreeMarginAfterDealersAnswer = item._IsDoNotCheckFreeMarginAfterDealersAnswer;
                            row[index].IsFastConfirmationOnIEWithDeviationSpecified = item._IsFastConfirmationOnIEWithDeviationSpecified;
                            row[index].IsMultipleCloseByOrders = item._MultipleCloseByOrders;
                            row[index].AutoCloseOut = item._AutoCloseOut;
                            row[index].LotsMinimum = item._MinLotsInaMonths;
                            row[index].LotsMaximum = item._MaxLotsInaMonths;
                            row[index].LotsStep = item._Steps;
                            row[index].CommissionStandard = item._CommissionStandard;
                            row[index].CommissionTaxes = item._Taxes;
                            row[index].Pt_Point = item._Unit;
                            row[index].Pt_PerLots = item._Volume;
                            row[index].CommissionAgent = item._CommissionAgent;
                            row[index].SecurityId = item._SecurityIDSecurity;
                            row[index].EnableSecurity = item._EnableGroup;
                            row[index].SecurityRowId = item._SecurityRowId;
                            row[index].Agent_Pt_Point = item._UnitAgent;
                            row[index].Agent_Pt_PerLots = item._VolumeAgent;
                            index++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleSecuritiesTable()");
            }

        }


        #endregion Security
        #region Symbol
        private void DoHandleSymbolTable(Group group, bool isRowExist)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsGroupManager : Enter DoHandleSymbolTable()");
                //GroupSymbol Gsymbol=new GroupSymbol();

                if (!isRowExist)
                {
                    foreach (GroupSymbol item in group._lstGroupSymbol)
                    {

                        _DS4Groups.dtSymbol.AdddtSymbolRow(item._SymbolID.ToString(), item._LongPositionSwap, item._ShortPositionSwap, item._MarginPercentage, group._AccountGroupID, item._SymbolID, item._SymbolRowId);


                    }
                }
                else
                {
                    DS4Groups.dtSymbolRow[] row = (DS4Groups.dtSymbolRow[])_DS4Groups.dtSymbol.Select("FK_GroupID = " + group._AccountGroupID.ToString() + " ");
                    if (row != null)
                    {
                        int index = 0;
                        foreach (GroupSymbol item in group._lstGroupSymbol)
                        {
                            if (row.Length > index)
                            {
                                row[index].Symbol = item._SymbolID.ToString();
                                row[index].LongPositioningSwap = item._LongPositionSwap;
                                row[index].ShortPositiioningSwap = item._ShortPositionSwap;
                                row[index].MarginPercentage = item._MarginPercentage;
                                row[index].FK_GroupID = group._AccountGroupID;
                                row[index].SymbolRowId = item._SymbolRowId;
                                index++;
                            }
                            else
                            {
                                _DS4Groups.dtSymbol.AdddtSymbolRow(item._SymbolID.ToString(), item._LongPositionSwap, item._ShortPositionSwap, item._MarginPercentage, group._AccountGroupID, item._SymbolID, item._SymbolRowId);

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsGroupManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleSymbolTable()");
            }
        }

        #endregion Symbol


        public string[] GetGroupNameArray()
        {
            return _lstGroupName.ToArray();
        }
        public string GetGroupName(long AccountGroupId)
        {
            DS4Groups.dtCommonRow CommonRow = _DS4Groups.dtCommon.FindByGroupID(AccountGroupId);
            if (CommonRow == null)
                return null;
            return CommonRow.Name;
        }

        public long GetGroupId(string GroupName)
        {

            DS4Groups.dtCommonRow[] CommonRow = (DS4Groups.dtCommonRow[])_DS4Groups.dtCommon.Select("Name = '" + GroupName + "'");
            if (CommonRow == null)
                return 0;
            return CommonRow[0].GroupID;
        }



        #endregion METHODS

        #region PROPERTY
        public static clsGroupManager INSTANCE
        {
            get
            {
                if (_clsGroupManager == null)
                {
                    _clsGroupManager = new clsGroupManager();
                }
                return _clsGroupManager;
            }
        }
        #endregion PROPERTY

        #region iclsManager

        public override void AddSetting(IProtocolStruct PS)
        {
            lock (_DS4Groups)
            {
                DoHandleGroupTable((PS as GroupPS)._Group);
            }

        }

        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }

        public override void ServerRequestResponse(DBResponse response)
        {
            throw new NotImplementedException();
        }
        #endregion iclsManager
    }
}
