using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class GroupPS : IProtocolStruct
    {
        public Group _Group;
        List<DatavalidationInfo> lst = new List<DatavalidationInfo>();
        DatavalidationInfo Datvali;
        public GroupPS()
        {
            _Group = new Group();
        }
        public GroupPS(Group deepCopy)
        { 
        
          //  _Group._AccountGroupName = deepCopy._AccountGroupName;
          //  _Group._AnnualInterestRate = deepCopy._AnnualInterestRate;
          //  _Group._ArchiveDeletedPendingOrders = deepCopy._ArchiveDeletedPendingOrders;
          //  _Group._AutoCloseOut = deepCopy._AutoCloseOut;
          //  _Group._Bonus = deepCopy._Bonus;
          
          //  _Group._CommissionAgent = deepCopy._CommissionAgent;
          //  _Group._CommissionStandard = deepCopy._CommissionStandard;
          //  _Group._CreateDate = deepCopy._CreateDate;
          //  _Group._CreateDateAccount = deepCopy._CreateDateAccount;
          //  _Group._CreatedDatePermission = deepCopy._CreatedDatePermission;
          //  _Group._DealerAnswer = deepCopy._DealerAnswer;
          //  _Group._Deposite = deepCopy._Deposite;
          //  _Group._DepositeCurrency = deepCopy._DepositeCurrency;
          //  _Group._DeviationSpec = deepCopy._DeviationSpec;
          //  _Group._EnableAccount = deepCopy._EnableAccount;
          //  _Group._EnableCloseBy = deepCopy._EnableCloseBy;
          //  _Group._EnableGroup = deepCopy._EnableGroup;
          //  _Group._EnableGroupPermission = deepCopy._EnableGroupPermission;
          //  _Group._EnableTrade = deepCopy._EnableTrade;
          //  _Group._EquityPromo = deepCopy._EquityPromo;
          //  _Group._Execution = deepCopy._Execution;
          //  _Group._GroupCode = deepCopy._GroupCode;
          //  _Group._GroupCommission = deepCopy._GroupCommission;
          //  _Group._GroupPermission = deepCopy._GroupPermission;
          //  _Group._ID_Permission = deepCopy._ID_Permission;
          //  _Group._IDSecurity = deepCopy._IDSecurity;
          //  _Group._InActivityPeriod = deepCopy._InActivityPeriod;
          //  _Group._Leverage = deepCopy._Leverage;
          //  _Group._LiquidationRuleID = deepCopy._LiquidationRuleID;
          //  _Group._LongPositionSwap = deepCopy._LongPositionSwap;
          //  _Group._MarginCallLevel = deepCopy._MarginCallLevel;
          //  _Group._MarginID = deepCopy._MarginID;
          //  _Group._MarginPercentage = deepCopy._MarginPercentage;
          //  _Group._MaximumBalance = deepCopy._MaximumBalance;
          //  _Group._MaximumDeviation = deepCopy._MaximumDeviation;
          //  _Group._MaximumLots = deepCopy._MaximumLots;
          //  _Group._MaximumOrders = deepCopy._MaximumOrders;
          //  _Group._MaximumSymbols = deepCopy._MaximumSymbols;
          //  _Group._MaxLotsInaMonths = deepCopy._MaxLotsInaMonths;
          //  _Group._MinimumLots = deepCopy._MinimumLots;
          //  _Group._MinLotsInaMonths = deepCopy._MinLotsInaMonths;
          //  _Group._ModifiedDate = deepCopy._ModifiedDate;
          //  _Group._ModifiedDateAccount = deepCopy._ModifiedDateAccount;
          //  _Group._ModifiedDatePermission = deepCopy._ModifiedDatePermission;
          //  _Group._MultipleCloseByOrders = deepCopy._MultipleCloseByOrders;
          //  _Group._News = deepCopy._News;
          //  _Group._Owner = deepCopy._Owner;
          //  _Group._RequestMode = deepCopy._RequestMode;
          //  _Group._SecurityID = deepCopy._SecurityID;
          //  _Group._SecurityIDAccount = deepCopy._SecurityIDAccount;
          //  _Group._SecurityIDSecurity = deepCopy._SecurityIDSecurity;
          //  _Group._ShortPositionSwap = deepCopy._ShortPositionSwap;
          //  _Group._Spread = deepCopy._Spread;
          //  _Group._StartDate = deepCopy._StartDate;
          //  _Group._Steps = deepCopy._Steps;
          //  _Group._StopOutLevel = deepCopy._StopOutLevel;
          //  _Group._SymbolID = deepCopy._SymbolID;
          //  _Group._Taxes = deepCopy._Taxes;
          //  _Group._TimeOut = deepCopy._TimeOut;
          //  _Group._Unit = deepCopy._Unit;
          //  _Group._UnitAgent = deepCopy._UnitAgent;
          //  _Group._VirtualCredit = deepCopy._VirtualCredit;
          //  _Group._Volume = deepCopy._Volume;
          //  _Group._VolumeAgent = deepCopy._VolumeAgent;

          //  _Group._IsCopyReport = deepCopy._IsCopyReport;
          //  _Group._Signature = deepCopy._Signature;
          //  _Group._SMTPLogin = deepCopy._SMTPLogin;
          //  _Group._SMTPPassword = deepCopy._SMTPPassword;
          //  _Group._SMTPServer = deepCopy._SMTPServer;
          //  _Group._SupportEmail = deepCopy._SupportEmail;
          //  _Group._TemplatesPath = deepCopy._TemplatesPath;


          // _Group. _FreeMargin     =deepCopy._FreeMargin ;   
          // _Group. _FullyHedged     = deepCopy._FullyHedged ;
          // _Group. _IsMarginActive =deepCopy._IsMarginActive;

          //_Group._CommissionAgent =deepCopy._CommissionAgent ;

          //_Group._IsDoNotCheckFreeMarginAfterDealersAnswer=deepCopy._IsDoNotCheckFreeMarginAfterDealersAnswer;

          //_Group._IsFastConfirmationOnIEWithDeviationSpecified=deepCopy._IsFastConfirmationOnIEWithDeviationSpecified;

          //_Group._Pt_Point=deepCopy._Pt_Point;

          //_Group._Pt_PerLots=deepCopy._Pt_PerLots;

          //_Group._CommissionAgent = deepCopy._CommissionAgent;



         

        }
        public override int ID
        {
            get { return ProtocolStructIDS.Group_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        public override void WriteString()
        {
            StartStrW();
            AppendStr(_Group._iGroupSecurityCnt);
            foreach (GroupSecurity item in _Group._lstGroupSecurity)
            {
                AppendStr(item._SecurityRowId );
                AppendStr(item._SecurityIDSecurity);
                AppendStr(item._EnableGroup);
                AppendStr(item._EnableTrade);
                AppendStr(item._Execution );
                AppendStr(item._MaximumDeviation);
                AppendStr(item._MinLotsInaMonths);
                AppendStr(item._MaxLotsInaMonths );
                AppendStr(item._Steps);
                AppendStr(item._Taxes);
                AppendStr(item._Spread);
                AppendStr(item._EnableCloseBy );
                AppendStr(item._MultipleCloseByOrders);
                AppendStr(item._AutoCloseOut);
                AppendStr(item._Volume);
                AppendStr(item._Unit );
                AppendStr(item._GroupCommission );
                AppendStr(item._GroupCode);
                AppendStr(item._VolumeAgent );
                AppendStr(item._UnitAgent );
                AppendStr(item._CommissionAgent );
                AppendStr(item._CommissionStandard );
                AppendStr(item._RequestMode );
                AppendStr(item._DealerAnswer);
                AppendStr(item._DeviationSpec);
                AppendStr(item._IsDoNotCheckFreeMarginAfterDealersAnswer);
                AppendStr(item._IsFastConfirmationOnIEWithDeviationSpecified);

            }
            AppendStr(_Group._iGroupSymbolCnt);
            foreach (GroupSymbol item in _Group._lstGroupSymbol)
            {
                AppendStr(item._SymbolRowId );
                AppendStr(item._SecurityID);
                AppendStr(item._MinimumLots);
                AppendStr(item._MaximumLots);
                AppendStr(item._SymbolID );
                AppendStr(item._LongPositionSwap);
                AppendStr(item._ShortPositionSwap);
                AppendStr(item._MarginPercentage);
                AppendStr(item._CreateDate);
                AppendStr(item._ModifiedDate);
            }
            AppendStr(_Group._AccountGroupID);
            AppendStr(_Group._AccountGroupName);
            AppendStr(_Group._AnnualInterestRate);
            //AppendStr(_Group._ArchiveDeletedPendingOrders);
            AppendStr(_Group._CreateDateAccount);
            AppendStr(_Group._CreatedDatePermission);
            //AppendStr(_Group._Deposite);
            //AppendStr(_Group._DepositeCurrency);
            AppendStr(_Group._EnableAccount);
            AppendStr(_Group._EnableGroupPermission);
            AppendStr(_Group._GroupPermission);
            AppendStr(_Group._ID_Permission);
            //AppendStr(_Group._InActivityPeriod);
            AppendStr(_Group._Leverage);
            AppendStr(_Group._MarginCallLevel);
            AppendStr(_Group._MarginCallLevel2);
            AppendStr(_Group._MarginID);
            //AppendStr(_Group._MaximumBalance);
            AppendStr(_Group._MaximumOrders);
            AppendStr(_Group._MaximumSymbols);
            AppendStr(_Group._ModifiedDateAccount);
            AppendStr(_Group._ModifiedDatePermission);
            AppendStr(_Group._News);
            AppendStr(_Group._Owner);
            AppendStr(_Group._StartDate);
            AppendStr(_Group._StopOutLevel);
            AppendStr(_Group._TimeOut);
            //AppendStr(_Group._VirtualCredit);
            AppendStr(_Group._IsCopyReport);
            AppendStr(_Group._Signature);
            AppendStr(_Group._SMTPLogin);
            AppendStr(_Group._SMTPPassword);
            AppendStr(_Group._SMTPServer);
            AppendStr(_Group._SupportEmail);
            AppendStr(_Group._TemplatesPath);
            //AppendStr(_Group._FreeMargin);
            //AppendStr(_Group._FullyHedged);
            AppendStr(_Group._IsMarginActive);
            AppendStr(_Group._IsActive);
            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            int ind = -1;
            _Group._iGroupSecurityCnt = clsUtility.GetInt(SpltString[++ind]);
            for (int iLoop = 0; iLoop < _Group._iGroupSecurityCnt; iLoop++)
            {
                GroupSecurity item = new GroupSecurity();
                item._SecurityRowId =clsUtility.GetLong( SpltString[++ind]);
                item._SecurityIDSecurity=SpltString[++ind];
                item._EnableGroup=Convert.ToBoolean(SpltString[++ind]);
                item._EnableTrade=Convert.ToBoolean(SpltString[++ind]);
                item._Execution =SpltString[++ind];
                item._MaximumDeviation=clsUtility.GetInt(SpltString[++ind]);
                item._MinLotsInaMonths=clsUtility.GetDecimal(SpltString[++ind]);
                item._MaxLotsInaMonths =clsUtility.GetDecimal(SpltString[++ind]);
                item._Steps=clsUtility.GetDecimal(SpltString[++ind]);
                item._Taxes=clsUtility.GetDecimal(SpltString[++ind]);
                item._Spread=clsUtility.GetDecimal(SpltString[++ind]);
                item._EnableCloseBy =Convert.ToBoolean(SpltString[++ind]);
                item._MultipleCloseByOrders=Convert.ToBoolean(SpltString[++ind]);
                item._AutoCloseOut=SpltString[++ind];
                item._Volume=SpltString[++ind];
                item._Unit =SpltString[++ind];
                item._GroupCommission =clsUtility.GetDecimal(SpltString[++ind]);
                item._GroupCode=SpltString[++ind];
                item._VolumeAgent =SpltString[++ind];
                item._UnitAgent =SpltString[++ind];
                item._CommissionAgent = clsUtility.GetDecimal(SpltString[++ind]);
                item._CommissionStandard =clsUtility.GetDecimal(SpltString[++ind]);
                item._RequestMode =Convert.ToBoolean(SpltString[++ind]);
                item._DealerAnswer=Convert.ToBoolean(SpltString[++ind]);
                item._DeviationSpec=Convert.ToBoolean(SpltString[++ind]);
                item._IsDoNotCheckFreeMarginAfterDealersAnswer=Convert.ToBoolean(SpltString[++ind]);
                item._IsFastConfirmationOnIEWithDeviationSpecified=Convert.ToBoolean(SpltString[++ind]);

                _Group._lstGroupSecurity.Add(item);
            }
            _Group._iGroupSymbolCnt = clsUtility.GetInt(SpltString[++ind]);
            for (int iSymbolLoop = 0; iSymbolLoop < _Group._iGroupSymbolCnt; iSymbolLoop++)
            {
                GroupSymbol item = new GroupSymbol();
                item._SymbolRowId = clsUtility.GetLong(SpltString[++ind]);
                item._SecurityID=SpltString[++ind];
                item._MinimumLots=clsUtility.GetDecimal(SpltString[++ind]);
                item._MaximumLots=clsUtility.GetDecimal(SpltString[++ind]);
                item._SymbolID=SpltString[++ind];
                item._LongPositionSwap=clsUtility.GetDecimal(SpltString[++ind]);
                item._ShortPositionSwap=clsUtility.GetDecimal(SpltString[++ind]);
                item._MarginPercentage=clsUtility.GetDecimal(SpltString[++ind]);
                item._CreateDate=clsUtility.GetDate4ProtoStru(SpltString[++ind]);
                item._ModifiedDate = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
                _Group._lstGroupSymbol.Add(item);
            }
            _Group._AccountGroupID = clsUtility.GetLong(SpltString[++ind]);
                
            _Group._AccountGroupName = SpltString[++ind];
            _Group._AnnualInterestRate = clsUtility.GetDecimal(SpltString[++ind]);
            //_Group._ArchiveDeletedPendingOrders = SpltString[++ind];
            _Group._CreateDateAccount = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Group._CreatedDatePermission = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            //_Group._Deposite = SpltString[++ind];
           // _Group._DepositeCurrency = SpltString[++ind];
            _Group._EnableAccount = Convert.ToBoolean(SpltString[++ind]);
            _Group._EnableGroupPermission = Convert.ToBoolean(SpltString[++ind]);
            _Group._GroupPermission = SpltString[++ind];
            _Group._ID_Permission = clsUtility.GetInt(SpltString[++ind]);
            //_Group._InActivityPeriod = clsUtility.GetInt(SpltString[++ind]);
            _Group._Leverage = SpltString[++ind];
            _Group._MarginCallLevel = clsUtility.GetInt(SpltString[++ind]);
            _Group._MarginCallLevel2 = clsUtility.GetInt(SpltString[++ind]);
            _Group._MarginID = clsUtility.GetInt(SpltString[++ind]);
            //_Group._MaximumBalance = clsUtility.GetDecimal(SpltString[++ind]);
            _Group._MaximumOrders = SpltString[++ind];
            _Group._MaximumSymbols = SpltString[++ind];
            _Group._ModifiedDateAccount = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Group._ModifiedDatePermission = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Group._News = SpltString[++ind];
            _Group._Owner = SpltString[++ind];
            //_Group._SecurityIDAccount = SpltString[++ind];
            _Group._StartDate = clsUtility.GetDate4ProtoStru(SpltString[++ind]);
            _Group._StopOutLevel = clsUtility.GetInt(SpltString[++ind]);
            _Group._TimeOut = clsUtility.GetInt(SpltString[++ind]);
           // _Group._VirtualCredit = clsUtility.GetInt(SpltString[++ind]);
            _Group._IsCopyReport = Convert.ToBoolean(SpltString[++ind]);
            _Group._Signature = SpltString[++ind];
            _Group._SMTPLogin = SpltString[++ind];
            _Group._SMTPPassword = SpltString[++ind];
            _Group._SMTPServer = SpltString[++ind];
            _Group._SupportEmail = SpltString[++ind];
            _Group._TemplatesPath = SpltString[++ind];
           // _Group._FreeMargin = SpltString[++ind];
           // _Group._FullyHedged = Convert.ToBoolean(SpltString[++ind]);
            _Group._IsMarginActive = Convert.ToBoolean(SpltString[++ind]);
            _Group._IsActive = Convert.ToBoolean(SpltString[++ind]);

        }
        public override string ToString()
        {
            return _Group == null ? base.ToString() : _Group.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            #region Common
            Add2Vld("AccountGroupID", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._AccountGroupID.ToString()));
            Add2Vld("Name", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._AccountGroupName.ToString()));
            Add2Vld("Owner", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._Owner.ToString()));
            //Add2Vld("DepositeCurrency", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._DepositeCurrency.ToString()));
            //Add2Vld("Deposite", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(clsUtility.GetInt( _Group._Deposite).ToString()));
            Add2Vld("AnnualInterestRate", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(clsUtility.GetInt(_Group._AnnualInterestRate).ToString()));
            Add2Vld("Leverage", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(clsUtility.GetInt( _Group._Leverage).ToString()));
            #endregion Common

            #region permission
            Add2Vld("TimeOut", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(clsUtility.GetInt( _Group._TimeOut).ToString()));
            Add2Vld("News", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._News));
            Add2Vld("MaximumOrders", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._MaximumOrders.ToString()));
            Add2Vld("MaximumSymbols", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._MaximumSymbols.ToString()));
            #endregion permission
            #region Arciving
            //Add2Vld("InActivityPeriod", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._InActivityPeriod.ToString()));
            //Add2Vld("MaximumBalance", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._MaximumBalance.ToString()));
            //Add2Vld("ArchiveDeletedPendingOrders", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._ArchiveDeletedPendingOrders.ToString()));
            #endregion Arciving
            #region Margins
            Add2Vld("MarginCallLevel", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_Group._MarginCallLevel.ToString()));
            Add2Vld("MarginCallLevel", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_Group._MarginCallLevel2.ToString()));
            Add2Vld("StopOutLevel", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_Group._StopOutLevel.ToString()));
            //Add2Vld("VirtualCredit", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_Group._VirtualCredit.ToString()));
            //Add2Vld("FreeMargin", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._FreeMargin));
            #endregion Margins
            #region report
            Add2Vld("SMTPServer", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._SMTPServer.ToString()));
            Add2Vld("SMTPPassword", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._SMTPPassword.ToString()));
            Add2Vld("SupportEmail", clsInterface4OME.clsUtil4ProtoVali.ValidateEmail(_Group._SupportEmail.ToString()));
            Add2Vld("Signature", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._Signature.ToString()));
           Add2Vld("SMTPLogin", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_Group._SMTPLogin.ToString()));
            #endregion report

             #region symbol
            
             #endregion symbol
             return IsValidlist();
        }
    }
}
