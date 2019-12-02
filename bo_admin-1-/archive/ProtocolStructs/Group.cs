using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class GroupSecurity
    {
        // Gruop security setting
        public long _SecurityRowId;
        public string _SecurityIDSecurity;
        public bool _EnableGroup;
        public bool _EnableTrade;
        public string _Execution;
        public int _MaximumDeviation;
        public decimal _MinLotsInaMonths;
        public decimal _MaxLotsInaMonths;
        public decimal _Steps;
        public decimal _Taxes;
        public decimal _Spread;
        public bool _EnableCloseBy;
        public bool _MultipleCloseByOrders;
        public string _AutoCloseOut;
        public string _Volume;
        public string _Unit;
        public decimal _GroupCommission;
        public string _GroupCode;
        public string _VolumeAgent;
        public string _UnitAgent;
        public bool _RequestMode;
        public bool _DealerAnswer;
        public bool _DeviationSpec;
        public Boolean _IsDoNotCheckFreeMarginAfterDealersAnswer;
        public Boolean _IsFastConfirmationOnIEWithDeviationSpecified;
        public decimal _CommissionAgent;
        public decimal _CommissionStandard;

        public GroupSecurity()
        {
            _SecurityIDSecurity = string.Empty;
            _SecurityRowId = 0;
            _EnableGroup = true;
            _EnableTrade = true;
            _Execution = string.Empty;
            _MaximumDeviation = 0;
            _MinLotsInaMonths = 0;
            _MaxLotsInaMonths = 0;
            _Steps = 0;
            _Taxes = 0;
            _Spread = 0;
            _EnableCloseBy = true;
            _MultipleCloseByOrders = true;
            _AutoCloseOut = string.Empty;
            _Volume = string.Empty;
            _Unit = string.Empty;
            _GroupCommission = 0;
            _GroupCode = string.Empty;
            _VolumeAgent = string.Empty;
            _UnitAgent = string.Empty;
            _CommissionAgent = 0;
            _CommissionStandard = 0;
            _RequestMode = true;
            _DealerAnswer = true;
            _DeviationSpec = true;
            _IsDoNotCheckFreeMarginAfterDealersAnswer = false;
            _IsFastConfirmationOnIEWithDeviationSpecified = false;
           
        }
    }

    public class GroupSymbol
    {
        // Group symbol
        public long _SymbolRowId;
        public string _SecurityID;
        public decimal _MinimumLots;
        public decimal _MaximumLots;
        public string _SymbolID;
        public decimal _LongPositionSwap;
        public decimal _ShortPositionSwap;
        public decimal _MarginPercentage;
        public DateTime _CreateDate;
        public DateTime _ModifiedDate;

        public GroupSymbol()
        {
            _SymbolRowId = 0;
             _SecurityID = string.Empty;
            _MinimumLots = 0;
            _MaximumLots = 0;
            _SymbolID = string.Empty;
            _LongPositionSwap = 0;
            _ShortPositionSwap = 0;
            _MarginPercentage = 0;
            _CreateDate = DateTime.Now;
            _ModifiedDate = DateTime.Now;
        }
    }

    public class Group
    {

        //account group archieve
        public Int64 _AccountGroupID;
       
        //public int _InActivityPeriod;
        //public decimal _MaximumBalance;
        //public string _ArchiveDeletedPendingOrders;

        // account group
      
        public DateTime _StartDate;
   
        public string _AccountGroupName;
        public string _Owner;
        //public string _DepositeCurrency;
        //public string _Deposite;
        public string _Leverage;
        public decimal _AnnualInterestRate;
        public DateTime _CreateDateAccount;
        public DateTime _ModifiedDateAccount;
        public string _SecurityIDAccount;
        public bool _EnableAccount;
        // account Gruop margin
        public int _MarginID;
        public int _MarginCallLevel;
        //vijay
        public int _MarginCallLevel2;
        public int _StopOutLevel;
        //public int _VirtualCredit;
        //public string _FreeMargin;
        //public bool _FullyHedged;
        public bool _IsMarginActive;
        public string _StopOutLevelIn;
        // account group permission
        public int _TimeOut;
        public bool _EnableGroupPermission;
        public string _News;
        public string _MaximumSymbols;
        public string _MaximumOrders;
        public string _GroupPermission;
        public int _ID_Permission;
        public DateTime _CreatedDatePermission;
        public DateTime _ModifiedDatePermission;
        //Report 
        public string _SMTPServer;
        public string _SMTPLogin;
        public string _TemplatesPath;
        public string _SMTPPassword;
        public string _SupportEmail;
        public bool _IsCopyReport;
        public string _Signature;
        public bool _IsActive;
        public int _iGroupSymbolCnt;
        public List<GroupSymbol> _lstGroupSymbol = new List<GroupSymbol>();

        public int _iGroupSecurityCnt;
        public List<GroupSecurity> _lstGroupSecurity = new List<GroupSecurity>();


        public Group()
        {
            _AccountGroupID = 0;
            _iGroupSymbolCnt = 0;
            _iGroupSecurityCnt = 0;
            //_InActivityPeriod = 0;
            //_MaximumBalance = 0;
            //_ArchiveDeletedPendingOrders = string.Empty;
             _StartDate = DateTime.Now;
            _AccountGroupName = string.Empty;
            _Owner = string.Empty;
            //_DepositeCurrency = string.Empty;
            //_Deposite = string.Empty;
            _Leverage = string.Empty;
            _AnnualInterestRate = 0;
            _CreateDateAccount = DateTime.Now;
            _ModifiedDateAccount = DateTime.Now;
            _SecurityIDAccount = string.Empty;
            _EnableAccount = true;
            _MarginID = 0;
            _MarginCallLevel = 0;
            //vijay
            _MarginCallLevel2 = 0;
            _StopOutLevel = 0;
            //_VirtualCredit = 0;
            _TimeOut = 0;
            _EnableGroupPermission = true;
            _News = string.Empty;
            _MaximumSymbols = string.Empty;
            _MaximumOrders = string.Empty;
            _GroupPermission = string.Empty;
            _ID_Permission = 0;
            _CreatedDatePermission = DateTime.Now;
            _ModifiedDatePermission = DateTime.Now;
            //_FreeMargin = string.Empty; ;
            //_FullyHedged = false;
            _IsMarginActive = false;
            _StopOutLevelIn = string.Empty;
            _IsCopyReport = false;
            _Signature = string.Empty;
            _SMTPLogin = string.Empty;
            _SMTPPassword = string.Empty;
            _SMTPServer = string.Empty;
            _SupportEmail = string.Empty;
            _TemplatesPath = string.Empty;
            _IsActive = true;
        }
        public override string ToString()
        {
            return base.ToString();
            //    "_AccountGroupID->" + _AccountGroupID +
            //    "_AccountGroupName->" + _AccountGroupName +
            //    "_AnnualInterestRate->" + _AnnualInterestRate +
            //    "_ArchiveDeletedPendingOrders->" + _ArchiveDeletedPendingOrders +
            //    "_AutoCloseOut->" + _AutoCloseOut +
            //    "_Bonus->" + _Bonus +
            //    "_Commission->" + _CommissionStandard +
            //    "_CommissionAgent->" + _CommissionAgent +
            //    "_CommissionStandard->" + _CommissionStandard +
            //    "_CreateDate->" + _CreateDate +
            //    "_CreateDateAccount->" + _CreateDateAccount +
            //    "_CreatedDatePermission->" + _CreatedDatePermission +
            //    "_DealerAnswer->" + _DealerAnswer +
            //    "_Deposite->" + _Deposite +
            //    "_DepositeCurrency->" + _DepositeCurrency +
            //    "_DeviationSpec->" + _DeviationSpec +
            //    "_EnableAccount->" + _EnableAccount +
            //    "_EnableCloseBy->" + _EnableCloseBy +
            //    "_EnableGroup->" + _EnableGroup +
            //    "_EnableGroupPermission->" + _EnableGroupPermission +
            //    "_EnableTrade->" + _EnableTrade +
            //    "_EquityPromo->" + _EquityPromo +
            //    "_Execution->" + _Execution +
            //    "_FreeMargin->" + _FreeMargin +
            //    "_FullyHedged->" + _FullyHedged +
            //    "_GroupCode->" + _GroupCode +
            //    "_GroupCommission->" + _GroupCommission +
            //    "_GroupPermission->" + _GroupPermission +
            //    "_IsCopyReport->" + _IsCopyReport +
            //    "_ID_Permission->" + _ID_Permission +
            //    "_IDSecurity->" + _IDSecurity +
            //    "_InActivityPeriod->" + _InActivityPeriod +
            //    "_IsMarginActive->" + _IsMarginActive +
            //    "_Leverage->" + _Leverage +
            //    "_LiquidationRuleID->" + _LiquidationRuleID +
            //    "_LongPositionSwap->" + _LongPositionSwap +
            //    "_MarginCallLevel->" + _MarginCallLevel +
            //    "_MarginID->" + _MarginID +
            //    "_MarginPercentage->" + _MarginPercentage +
            //    "_MaximumBalance->" + _MaximumBalance +
            //    "_MaximumDeviation->" + _MaximumDeviation +
            //    "_MaximumLots->" + _MaximumLots +
            //    "_MaximumOrders->" + _MaximumOrders +
            //    "_MaximumSymbols->" + _MaximumSymbols +
            //    "_MaxLotsInaMonths->" + _MaxLotsInaMonths +
            //    "_MinimumLots->" + _MinimumLots +
            //    "_MinLotsInaMonths->" + _MinLotsInaMonths +
            //    "_ModifiedDate->" + _ModifiedDate +
            //    "_ModifiedDateAccount->" + _ModifiedDateAccount +
            //    "_ModifiedDatePermission->" + _ModifiedDatePermission +
            //    "_MultipleCloseByOrders->" + _MultipleCloseByOrders +
            //    "_News->" + _News +
            //    "_Owner->" + _Owner +
            //    "_RequestMode->" + _RequestMode +
            //    "_SecurityID->" + _SecurityID +
            //    "_SecurityIDAccount->" + _SecurityIDAccount +
            //    "_SecurityIDSecurity->" + _SecurityIDSecurity +
            //    "_ShortPositionSwap->" + _ShortPositionSwap +
            //    "_Signature->" + _Signature +
            //    "_SMTPLogin->" + _SMTPLogin +
            //    "_SMTPPassword->" + _SMTPPassword +
            //    "_SMTPServer->" + _SMTPServer +
            //    "_SupportEmail->" + _SupportEmail +
            //    "_Spread->" + _Spread +
            //    "_StartDate->" + _StartDate +
            //    "_Steps->" + _Steps +
            //    "_StopOutLevel->" + _StopOutLevel +
            //    "_StopOutLevelIn->" + _StopOutLevelIn +
            //    "_SymbolID->" + _SymbolID +
            //    "_Taxes->" + _Taxes +
            //    "_TemplatesPath " + _TemplatesPath +
            //    "_TimeOut->" + _TimeOut +
            //    "_Unit->" + _Unit +
            //    "_UnitAgent->" + _UnitAgent +
            //    "_VirtualCredit->" + _VirtualCredit +
            //    "_Volume->" + _Volume +
            //    "_VolumeAgent->" + _VolumeAgent +


            //"_IsDoNotCheckFreeMarginAfterDealersAnswer->" + _IsDoNotCheckFreeMarginAfterDealersAnswer +

            //"_IsFastConfirmationOnIEWithDeviationSpecified->" + _IsFastConfirmationOnIEWithDeviationSpecified +

            //"_Pt_Point ->" + _Pt_Point +

            //"_Pt_PerLots->" + _Pt_PerLots +

            //"_AgentPointCommission->" + _CommissionAgent;
        }
   
    
    }
}
