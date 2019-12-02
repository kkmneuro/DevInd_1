using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LtechIndia.BackOffice.BOEngine.DAL
{

    public class DataFeeds
    {
        public bool _IsEnable;
        public int _Id;
        public string _Password;
        public Int64 _LoginID;
        public string _Vendor;
        public string _Source;
        public string _Server;
        public string _File;
        public string _KeyWords;
        public int _IdleTimeOut;
        public int _ReconnectAfter;
        public int _SleepFor;
        public int _Attempts;
        public string _Description;
        public string _Journal;

        public DataFeeds()
        {
            _IsEnable = true;
            _Id = 0;
            _LoginID = 0;
            _Vendor = string.Empty;
            _Source = string.Empty;
            _Server = string.Empty;
            _File = string.Empty;
            _KeyWords = string.Empty;
            _IdleTimeOut = 0;
            _ReconnectAfter = 0;
            _SleepFor = 0;
            _Attempts = 0;
            _Description = string.Empty;
            _Journal = string.Empty;
        }
        public override string ToString()
        {
            return
                "_Attempts->" + _Attempts +
                "_Description->" + _Description +
                "_File->" + _File +
                "_Id->" + _Id +
                "_IdleTimeOut->" + _IdleTimeOut +
                "_IsEnable->" + _IsEnable +
                "_Journal->" + _Journal +
                "_KeyWords->" + _KeyWords +
                "_LoginID->" + _LoginID +
                "_Password->" + _Password +
                "_ReconnectAfter->" + _ReconnectAfter +
                "_Server->" + _Server +
                "_SleepFor->" + _SleepFor +
                "_Source->" + _Source +
                "_Vendor->" + _Vendor;
        }
    }
    public class AccountPWD
    {
        public string _Pwd;

        public long _AccID;

        public bool _Check;
        public AccountPWD()
        {

            _Pwd = string.Empty;
            _AccID = 0;
            _Check = true;

        }
        public override string ToString()
        {
            return

                "_Pwd->" + _Pwd +
                "_AccID->" + _AccID
               + "_Check->" + _Check;
        }

    }

    public class DataServer
    {
        public int _ServerID;
        public string _IP;
        public int _Port;
        public bool _IsLive;
        public string _Priority;
        public string _Description;
        public string _InternalIpServer;
        public string _Loading;

        public DataServer()
        {
            _ServerID = 0;
            _IP = string.Empty;
            _Port = 0;
            _IsLive = false;
            _Priority = string.Empty;
            _Description = string.Empty;
            _InternalIpServer = string.Empty;
            _Loading = string.Empty;
        }
        public override string ToString()
        {
            return
                "_Description->" + _Description +
                "_Internelipserver->" + _InternalIpServer +
                "_IP->" + _IP +
                "_IsLive->" + _IsLive +
                "_Port->" + _Port +
                "_Priority->" + _Priority +
                "_ServerID->" + _ServerID +
                "_Loading->" + _Loading;
        }
    }
    public class Orders
    {
        public int _AccountID;
        public int _OrderID;
        public DateTime _Time;
        public string _Type;
        public int _Quantity;
        public string _SymbolID;
        public string _OrderType;
        public string _OrderPrice;
        public string _TriggerPrice;
        public string _Comment;
        public string _Status;
        public DateTime _Validity;
        public string _BrokerName;
        public int _Volume;
        public int _FilledQuantity;
        public int _LeaveQuantity;
        public int _AvgFillPrice;

        public Orders()
        {
            _AccountID = 0;
            _OrderID = 0;
            _Time = DateTime.Today;
            _Type = string.Empty;
            _Quantity = 0;
            _SymbolID = string.Empty;
            _OrderType = string.Empty;
            _OrderPrice = string.Empty;
            _TriggerPrice = string.Empty;
            _Comment = string.Empty;
            _Status = string.Empty;
            _Validity = DateTime.Today;
            _BrokerName = string.Empty;
            _Volume = 0;
            _FilledQuantity = 0;
            _LeaveQuantity = 0;
            _AvgFillPrice = 0;

        }

        public override string ToString()
        {
            return

            "_AccountID->" + _AccountID +
            "_OrderID->" + _OrderID +
            "_Time->" + _Time +
            "_Type->" + _Type +
            "_Quantity->" + _Quantity +
            "_SymbolID->" + _SymbolID +
            "_OrderType->" + _OrderType +
            "_OrderPrice->" + _OrderPrice +
            "_TriggerPrice->" + _TriggerPrice +
            "_Comment->" + _Comment +
            "_Status->" + _Status +
            "_Validity->" + _Validity +
            "_BrokerName->" + _BrokerName +
            "_Volume->" + _Volume +
            "_FilledQuantity->" + _FilledQuantity +
            "_LeaveQuantity->" + _LeaveQuantity +
            "_AvgFillPRice->" + _AvgFillPrice;

        }
    }

    public class Group
    {
        public Int64 _AccountGroupID;
        public DateTime _StartDate;
        public string _AccountGroupName;
        public string _Owner;
        public string _Leverage;
        public decimal _AnnualInterestRate;
        public DateTime _CreateDateAccount;
        public DateTime _ModifiedDateAccount;
        public string _SecurityIDAccount;
        public bool _EnableAccount;
        public int _MarginID;
        public int _MarginCallLevel;
        public int _MarginCallLevel2;
        public int _StopOutLevel;
        public bool _IsMarginActive;
        public string _StopOutLevelIn;
        public int _TimeOut;
        public bool _EnableGroupPermission;
        public string _News;
        public string _MaximumSymbols;
        public string _MaximumOrders;
        public string _GroupPermission;
        public int _ID_Permission;
        public DateTime _CreatedDatePermission;
        public DateTime _ModifiedDatePermission;
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

    public class ManagerRights
    {
        public Int64 _Id;
        public Int64 _Login;
        public string _Name;
        public string _RoleName;
        public string _AccessibleRightsId;
        public string _IpAccess;
        public int _ManagerRoleId;
        public string _MailBoxName;
        public string _AvailableDataForDays;
        public bool _IsIpRestrict;
        public string _Description;
        public int _RoleId;
        public string _Roles;
        public string _IPFrom;
        public string _IPTo;
        public string _Group;
        public string _Right;

        public ManagerRights()
        {
            _Id = 0;
            _Login = 0;
            _Name = string.Empty;
            _RoleName = string.Empty;
            _AccessibleRightsId = string.Empty;
            _IpAccess = string.Empty;
            _ManagerRoleId = 0;
            _MailBoxName = string.Empty;
            _AvailableDataForDays = string.Empty;
            _IsIpRestrict = true;
            _Description = string.Empty;
            _RoleId = 0;
            _Roles = string.Empty;
            _IPFrom = string.Empty;
            _IPTo = string.Empty;
            _Group = string.Empty;
            _Right = string.Empty;

        }

        public override string ToString()
        {
            return
                "_AccessibleRightsId->" + _AccessibleRightsId +
                "_AvailableDataForDays->" + _AvailableDataForDays +
                "_Description->" + _Description +
                "_Group->" + _Group +
                "_Id->" + _Id +
                "_IpAccess->" + _IpAccess +
                "_IPFrom->" + _IPFrom +
                "_IPTo->" + _IPTo +
                "_IsIpRestrict->" + _IsIpRestrict +
                "_Login->" + _Login +
                "_MailBoxName->" + _MailBoxName +
                "_ManagerRoleId->" + _ManagerRoleId +
                "_Name->" + _Name +
                 "_RoleId->" + _RoleId +
                "_RoleName->" + _RoleName +
                "_Roles->" + _Roles + "_Right->" + _Right;
        }
    }
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
    public class ClientInfo
    {
        public int _ClientId;
        public string _FirstName;
        public string _MidleName;
        public string _LastName;
        public string _Address1;
        public string _Address2;
        public string _City;
        public string _State;
        public string _Zip;
        public string _FaxNumber;
        public string _Mobile;
        public string _PassportId;
        public string _SSN;
        public DateTime _DOB;
        public string _Gender;
        public bool _Status;
        public string _Country;
        public int _FK_CountryID;
        public int _FK_NationalityID;
        public string _GroupName;
        public int _AccountGroupID;
        public int _FK_ParticipantType;
        public string _AccountType;
        public int _FK_AccountTypeID;
        public bool _Deleted;
        public decimal _Balance;
        public decimal _Equity;
        public string _MasterPassword;
        public string _TradingPassword;
        public string _PrimaryPhone;
        public string _SecondaryPhone;
        public DateTime _RegistrationDate;
        public string _PrimaryEmailAddress;
        public string _SecondaryEmailAddress;
        public string _PAN;
        public string _Age;
        public string _LoginID;
        public bool _isExists;
        public decimal _MarkupValue;

        public ClientInfo()
        {
            _ClientId = 0;
            _FirstName = string.Empty;
            _MidleName = string.Empty;
            _LastName = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Zip = string.Empty;
            _FaxNumber = string.Empty;
            _Mobile = string.Empty;
            _PassportId = string.Empty;
            _SSN = string.Empty;
            _DOB = DateTime.Today;
            _Gender = string.Empty;
            _Status = false;
            _Country = string.Empty;
            _FK_CountryID = 0;
            _FK_NationalityID = 0;
            _GroupName = string.Empty;
            _AccountGroupID = 0;
            _FK_ParticipantType = 0;
            _AccountType = string.Empty;
            _FK_AccountTypeID = 0;
            _Deleted = false;
            _Balance = 0;
            _Equity = 0;
            _MasterPassword = string.Empty;
            _PrimaryPhone = string.Empty;
            _SecondaryPhone = string.Empty;
            _RegistrationDate = DateTime.Today;
            _PrimaryEmailAddress = string.Empty;
            _SecondaryEmailAddress = string.Empty;
            _PAN = string.Empty;
            _Age = string.Empty;
            _LoginID = string.Empty;
            _isExists = false;
            _MarkupValue = 0;
        }
        public override string ToString()
        {
            return

             "_ClientId->" + _ClientId +
             "_FirstName->" + _FirstName +
             "_MidleName->" + _MidleName +
             "_LastName->" + _LastName +
             "_Address1->" + _Address1 +
             "_Address2->" + _Address2 +
             "_City->" + _City +
             "_State->" + _State +
             "_Zip->" + _Zip +
             "_FaxNumber->" + _FaxNumber +
             "_Mobile->" + _Mobile +
             "_PassportId->" + _PassportId +
             "_SSN->" + _SSN +
             "_DOB->" + _DOB +
             "_Gender->" + _Gender +
             "_Status->" + _Status +
             "_Country->" + _Country +
             "_FK_CountryID->" + _FK_CountryID +
             "_FK_NationalityID->" + _FK_NationalityID +
             "_GroupName->" + _GroupName +
             "_AccountGroupID->" + _AccountGroupID +
             "_FK_ParticipantType->" + _FK_ParticipantType +
             "_AccountType->" + _AccountType +
             "_FK_AccountTypeID->" + _FK_AccountTypeID +
             "_Deleted->" + _Deleted +
             "_Balance->" + _Balance +
             "_Equity->" + _Equity +
             "_MasterPassword->" + _MasterPassword +
             "_PrimaryPhone->" + _PrimaryPhone +
             "_SecondaryPhone->" + _SecondaryPhone +
             "_RegistrationDate->" + _RegistrationDate +
             "_PrimaryEmailAddress->" + _PrimaryEmailAddress +
             "_SecondaryEmailAddress->" + _SecondaryEmailAddress +
             "_PAN->" + _PAN +
             "_Age->" + _Age +
             "_LoginID->" + _LoginID +
            "_isExists->" + _isExists +
            "_MarkupValue->" + _MarkupValue;
        }
    }

    public class Security
    {
        public int _SecurityTypeID;
        public string _SecurityName;
        public string _SecurityDescription;
        public string _Symbols;

        public Security()
        {
            _SecurityTypeID = 0;
            _SecurityName = string.Empty;
            _SecurityDescription = string.Empty;
            _Symbols = string.Empty;
        }
        public override string ToString()
        {
            return
            "_SecurityTypeID->" + _SecurityTypeID +
            "_SecurityName->" + _SecurityName +
            "_SecurityDescription->" + _SecurityDescription +
            "_Symbols->" + _Symbols;
        }

    }
    public class Synchronization
    {
        public int _SynchronizationId;
        public bool _IsEnable;
        public enum MODE
        {
            Add = 1,
            Update,
            Replace,
            NA
        }
        public string _Server;
        public string _Symbols;
        public bool _IsLimits;
        public DateTime _StartDate;
        public MODE _Mode;
        public DateTime _EndDate;

        public Synchronization()
        {
            _EndDate = DateTime.Now;
            _IsEnable = true;
            _IsLimits = true;
            _Server = string.Empty;
            _StartDate = DateTime.Now;
            _Symbols = string.Empty;
            _SynchronizationId = 0;
            _Mode = MODE.NA;

        }
        public override string ToString()
        {
            return
                "_EndDate->" + _EndDate +
                "_IsEnable->" + _IsEnable +
                "_IsLimits->" + _IsLimits +
                "_Mode->" + _Mode +
                "_Server->" + _Server +
                "_StartDate->" + _StartDate +
                "_Symbols->" + _Symbols +
                "__SynchronizationId->" + _SynchronizationId;
        }

    }

    public class ParticipantOrder
    {
        public Int64 _ParticipantOrderId;
        public string _TradingOrderId;
        public string _OrderId2;
        public string _LPOrderId;
        public string _LPOrderId1;
        public Int64 _FK_AccountId;
        public string _OrderDateTimeRequested;
        public string _OrderDateTimeFilled;
        public string _Symbol;
        public decimal _PositionSize;
        public decimal _Price;
        public decimal _StopLoss;
        public decimal _TakeProfit;
        public int _OrderType;
        public string _TIF;
        public decimal _Commission;
        public decimal _Swap;
        public decimal _ProfitPIP;
        public decimal _ProfitInUSD;
        public decimal _RealValue;
        public decimal _YourMoneyUsed;
        public string _IPAddress;
        public int _OrderStatusId;
        public string _Status;
        public decimal _CumulativeQuantity;
        public decimal _Price2;
        public int _Side;
        public string _Lots;
        public string _OpenTime;
        public string _ClosedTime;
        public decimal _OpenPrice;
        public decimal _ClosePrice;
        public decimal _MarginRate;
        public decimal _FstConvRate;
        public decimal _SecConvRate;
        public decimal _AgentCommission;
        public decimal _Taxes;
        public string _Comment;
        public decimal _Profit;
        public string _ExpirationDate;
        public string _ValueDate;
        public bool _Deleted;


        public ParticipantOrder()
        {
            _ParticipantOrderId = 0;
            _TradingOrderId = string.Empty;
            _OrderId2 = string.Empty;
            _LPOrderId = string.Empty;
            _LPOrderId1 = string.Empty;
            _FK_AccountId = 0;
            _OrderDateTimeRequested = string.Empty;
            _OrderDateTimeFilled = string.Empty;
            _Symbol = string.Empty;
            _PositionSize = 0;
            _Price = 0;
            _StopLoss = 0;
            _TakeProfit = 0;
            _OrderType = 0;
            _TIF = string.Empty;
            _Commission = 0;
            _Swap = 0;
            _ProfitPIP = 0;
            _ProfitInUSD = 0;
            _RealValue = 0;
            _YourMoneyUsed = 0;
            _IPAddress = string.Empty;
            _OrderStatusId = 0;
            _Status = string.Empty;
            _CumulativeQuantity = 0;
            _Price2 = 0;
            _Side = 0;
            _Lots = string.Empty;
            _OpenTime = string.Empty;
            _ClosedTime = string.Empty;
            _OpenPrice = 0;
            _ClosePrice = 0;
            _MarginRate = 0;
            _FstConvRate = 0;
            _SecConvRate = 0;
            _AgentCommission = 0;
            _Taxes = 0;
            _Comment = string.Empty;
            _Profit = 0;
            _ExpirationDate = string.Empty;
            _ValueDate = string.Empty;
            _Deleted = true;
        }
        public override string ToString()
        {
            return
                "_AgentCommission->" + _AgentCommission +
                "_ClosedTime->" + _ClosedTime +
                "_ClosePrice->" + _ClosePrice +
                "_Comment->" + _Comment +
                "_Commission->" + _Commission +
                "_CumulativeQuantity->" + _CumulativeQuantity +
                "_Deleted->" + _Deleted +
                "_ExpirationDate->" + _ExpirationDate +
                "_FK_AccountId->" + _FK_AccountId +
                "_FstConvRate->" + _FstConvRate +
                "_IPAddress->" + _IPAddress +
                "_Lots->" + _Lots +
                "_LPOrderId->" + _LPOrderId +
                "_LPOrderId1->" + _LPOrderId1 +
                "_MarginRate->" + _MarginRate +
                "_OpenPrice->" + _OpenPrice +
                "_OpenTime->" + _OpenTime +
                "_OrderDateTimeFilled->" + _OrderDateTimeFilled +
                "_OrderDateTimeRequested->" + _OrderDateTimeRequested +
                "_OrderId2->" + _OrderId2 +
                "_OrderStatusId->" + _OrderStatusId +
                "_OrderType->" + _OrderType +
                "_ParticipantOrderId->" + _ParticipantOrderId +
                "_PositionSize->" + _PositionSize +
                "_Price->" + _Price +
                "_Price2->" + _Price2 +
                "_Profit->" + _Profit +
                "_ProfitInUSD->" + _ProfitInUSD +
                "_ProfitPIP->" + _ProfitPIP +
                "_RealValue->" + _RealValue +
                "_SecConvRate->" + _SecConvRate +
                "_Side->" + _Side +
                "_Status->" + _Status +
                "_StopLoss->" + _StopLoss +
                "_Swap->" + _Swap +
                "_Symbol->" + _Symbol +
                "_TakeProfit->" + _TakeProfit +
                "_Taxes->" + _Taxes +
                "_TIF->" + _TIF +
                "_TradingOrderId->" + _TradingOrderId +
                "_ValueDate->" + _ValueDate +
                "_YourMoneyUsed->" + _YourMoneyUsed;
        }

    }

    public class Chart
    {
        public int _Id;
        public DateTime _Time;
        public decimal _Open;
        public decimal _High;
        public decimal _Low;
        public decimal _Close;
        public decimal _Volume;
        public Chart()
        {
            _Id = 0;
            _Time = DateTime.Now;
            _Open = 0;
            _High = 0;
            _Low = 0;
            _Close = 0;
            _Volume = 0;
        }
        public override string ToString()
        {
            return
                "->" + _Close +
                "->" + _High +
                "->" + _Id +
                "->" + _Low +
                "->" + _Open +
                "->" + _Time +
                "->" + _Volume;
        }
    }


    public class SymbolSession
    {
        public string _TradeSession;
        public DAYS _Day;
        public string _QuoteSession;
        public bool _IsUseTimelimits;
        public DateTime _StartDate;
        public DateTime _EndDate;

    }
    public class Symbol
    {
        public Int32 _Instruement_ID;
        public string _SymbolName;
        public string _Description;
        public string _Source;
        public Int32 _Digits;
        public string _SettlingCurrency;
        public string _MarginCurrency;
        //public string _Orders;
        //public int _Spread;
        public int _MaximumLots;
        public decimal _BuySideTurnover;
        public decimal _SellSideTurnover;
        public int _MaximumAllowablePosition;
        public int _Hedged;
        //public Int32 _FreezeLevel;
        public Int32 _LimitandStopLevel;
        //public Int32 _SpreadBalance;
        public decimal _TickSize;
        public decimal _TickPrice;
        public int _ContractSize;
        public string _QuotationBaseValue;
        public int _Maintenance;
        public string _DeliveryType;
        public string _DeliveryUnit;
        public int _DeliveryQuantity;
        public int _MarketLot;
        public string _ExpiryDate;
        public string _StartDate;
        public string _EndDate;
        public string _TenderStartDate;
        public string _TenderEndDate;
        public string _DeliveryStartDate;
        public string _DeliveryEndDate;
        public int _DPRInitialPercentage;
        public int _DPRInterval;
        public int _InitialBuyMargin;
        public int _InitialSellMargin;
        public int _MaintenanceBuyMargin;
        public int _MaintenanceSellMargin;
        public string _ULAssest;
        public string _TradingCurrency;
        public int _Maximum_Order_Value;
        public int _DPR_Range_Higher;
        public string _FK_SecurityTypeID;
        public List<SymbolSession> _lstSession;
        public int _SessionCount;
        public string _MaximumLostUnit;
        public string _MarketLostUnit;
        public string _QuotationBaseValueUnit;

        public Symbol()
        {
            _Instruement_ID = 0;
            _SymbolName = string.Empty;
            _Description = string.Empty;
            _Source = string.Empty;
            _Digits = 0;
            _SettlingCurrency = string.Empty;
            _MarginCurrency = string.Empty;
            //_Orders = string.Empty;
            //_Spread = 0;
            _MaximumLots = 0;
            _BuySideTurnover = 0.0M;
            _SellSideTurnover = 0.0M;
            _MaximumAllowablePosition = 0;
            _Hedged = 0;
            //_FreezeLevel = 0;
            _LimitandStopLevel = 0;
            //_SpreadBalance = 0;
            _TickSize = 0;
            _TickPrice = 0;
            _ContractSize = 0;
            _QuotationBaseValue = string.Empty;
            _Maintenance = 0;
            _DeliveryType = string.Empty;
            _DeliveryUnit = string.Empty;
            _DeliveryQuantity = 0;
            _MarketLot = 0;
            _ExpiryDate = string.Empty;
            _StartDate = string.Empty;
            _EndDate = string.Empty;
            _TenderStartDate = string.Empty;
            _TenderEndDate = string.Empty;
            _DeliveryStartDate = string.Empty;
            _DeliveryEndDate = string.Empty;
            _DPRInitialPercentage = 0;
            _DPRInterval = 0;
            _InitialBuyMargin = 0;
            _InitialSellMargin = 0;
            _MaintenanceBuyMargin = 0;
            _MaintenanceSellMargin = 0;
            _ULAssest = string.Empty;
            _TradingCurrency = string.Empty;
            _Maximum_Order_Value = 0;
            _DPR_Range_Higher = 0;
            _FK_SecurityTypeID = string.Empty;
            _lstSession = new List<SymbolSession>();
            _SessionCount = 0;
            _MaximumLostUnit = string.Empty;
            _MarketLostUnit = string.Empty;
            _QuotationBaseValueUnit = string.Empty;

        }

        public override string ToString()
        {

            return "_Instruement_ID->" + _Instruement_ID +
         "_SymbolName->" + _SymbolName +
         "_Description->" + _Description +
         "_Source->" + _Source +
         "_Digits->" + _Digits +
         "_SettlingCurrency->" + _SettlingCurrency +
         "_MarginCurrency->" + _MarginCurrency +
         //"_Orders->" + _Orders +
         //"_Spread->" + _Spread +
         "_MaximumLots->" + _MaximumLots +
         "_BuySideTurnover->" + _BuySideTurnover +
         "_SellSideTurnover->" + _SellSideTurnover +
         "_MaximumAllowablePosition->" + _MaximumAllowablePosition +
         "_Hedged->" + _Hedged +
         //"_FreezeLevel->" + _FreezeLevel +
         "_LimitandStopLevel->" + _LimitandStopLevel +
         //"_SpreadBalance->" + _SpreadBalance +
         "_TickSize->" + _TickSize +
         "_TickPrice->" + _TickPrice +
         "_ContractSize->" + _ContractSize +
         "_QuotationBaseValue->" + _QuotationBaseValue +
         "_Maintenance->" + _Maintenance +
         "_DeliveryType->" + _DeliveryType +
         "_DeliveryUnit->" + _DeliveryUnit +
         "_DeliveryQuantity->" + _DeliveryQuantity +
         "_MarketLot->" + _MarketLot +
         "_ExpiryDate->" + _ExpiryDate +
         "_StartDate->" + _StartDate +
         "_EndDate->" + _EndDate +
         "_TenderStartDate->" + _TenderStartDate +
         "_TenderEndDate->" + _TenderEndDate +
         "_DeliveryStartDate->" + _DeliveryStartDate +
         "_DeliveryEndDate->" + _DeliveryEndDate +
         "_DPRInitialPercentage->" + _DPRInitialPercentage +
         "_DPRInterval->" + _DPRInterval +
         "_InitialBuyMargin->" + _InitialBuyMargin +
         "_InitialSellMargin->" + _InitialSellMargin +
         "_MaintenanceBuyMargin->" + _MaintenanceBuyMargin +
         "_MaintenanceSellMargin->" + _MaintenanceSellMargin +
         "_ULAssest->" + _ULAssest +
         "_TradingCurrency->" + _TradingCurrency +
         "_Maximum_Order_Value->" + _Maximum_Order_Value +
         "_DPR_Range_Higher->" + _DPR_Range_Higher +
         "_FK_SecurityTypeID->" + _FK_SecurityTypeID +
         //"_lstSession->"+_lstSession+
         "_SessionCount->" + _lstSession.Count +
         "_MaximumLostUnit->" + _MaximumLostUnit +
         "_MarketLostUnit->" + _MarketLostUnit +
         "_QuotationBaseValueUnit->" + _QuotationBaseValueUnit;

        }
    }

    public class Participant
    {
        public Int64 _IndividualID;
        public string _PrimaryPhone;
        public string _SecondaryPhone;
        public DateTime _CreationDate;
        public DateTime _LastModifiedDate;
        public bool _Deleted;
        public int _FK_ParticipantType;
        public string _FaxNumber;
        public string _PrimaryEmailAddress;
        public string _SecondaryEmailAddress;
        public bool _Active;
        public bool _AllowedToChangeTradeConfirmation;
        public Int64 _LoginID;
        public string _ParticipantType;
        public string _Fname;
        public string _Lname;
        public string _Address1;
        public string _Address2;
        public string _Country;
        public string _City;
        public string _State;
        public string _Zip;
        public string _Fax;
        public string _Phone;
        public string _Mobile;
        public string _PassportId;
        public string _SSN;
        public string _OrganizationId;
        public DateTime _DOB;
        public string _Gender;
        public bool _Status;

        public Participant()
        {
            _IndividualID = 0;
            _PrimaryPhone = string.Empty;
            _SecondaryPhone = string.Empty;
            _CreationDate = DateTime.Now;
            _LastModifiedDate = DateTime.Now;
            _Deleted = true;
            _FK_ParticipantType = 0;
            _FaxNumber = string.Empty;
            _PrimaryEmailAddress = string.Empty;
            _SecondaryEmailAddress = string.Empty;
            _Active = true;
            _AllowedToChangeTradeConfirmation = true;
            _LoginID = 0;
            _ParticipantType = string.Empty;
            _Fname = string.Empty;
            _Lname = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _Country = string.Empty;
            _City = string.Empty;
            _State = string.Empty;
            _Zip = string.Empty;
            _Fax = string.Empty;
            _Phone = string.Empty;
            _Mobile = string.Empty;
            _PassportId = string.Empty;
            _SSN = string.Empty;
            _OrganizationId = string.Empty;
            _DOB = DateTime.Now;
            _Gender = string.Empty;
            _Status = true;
        }
        public override string ToString()
        {
            return
                "_Active->" + _Active +
                "_Address1->" + _Address1 +
                "_Address2->" + _Address2 +
                "_AllowedToChangeTradeConfirmation->" + _AllowedToChangeTradeConfirmation +
                "_City->" + _City +
                "_Country->" + _Country +
                "_CreationDate->" + _CreationDate +
                "_Deleted->" + _Deleted +
                "_DOB->" + _DOB +
                "_Fax->" + _Fax +
                "_FaxNumber->" + _FaxNumber +
                "_FK_ParticipantType->" + _FK_ParticipantType +
                "_Fname->" + _Fname +
                 "_Gender->" + _Gender +
                "_IndividualID->" + _IndividualID +
                "_LastModifiedDate->" + _LastModifiedDate +
                "_Lname->" + _Lname +
                "_LoginID->" + _LoginID +
                "_Mobile->" + _Mobile +
                "_OrganizationId->" + _OrganizationId +
                "_ParticipantType->" + _ParticipantType +
                "_PassportId->" + _PassportId +
                "_Phone->" + _Phone +
                "_PrimaryEmailAddress->" + _PrimaryEmailAddress +
                "_PrimaryPhone->" + _PrimaryPhone +
                "_SecondaryEmailAddress->" + _SecondaryEmailAddress +
                "_SecondaryPhone->" + _SecondaryPhone +
                "_SSN->" + _SSN +
                "_State->" + _State +
                 "_Status->" + _Status +
                "_Zip->" + _Zip;

        }

    }

    public class RegisterNewUser
    {
        public string _P_PrimaryPhone;
        public string _P_SecondaryPhone;
        public bool _Deleted;
        public int _P_FK_ParticipantType;
        public string _P_FaxNumber;
        public string _P_PrimaryEmailAddress;
        public string _P_SecondaryEmailAddress;
        public bool _P_Active;
        public string _P_ParticipantType;
        public string _P_Fname;
        public string _P_Lname;
        public string _P_Address1;
        public string _P_Address2;
        public string _P_Country;
        public string _P_City;
        public string _P_State;
        public string _P_Zip;
        public string _P_Fax;
        public string _P_Phone;
        public string _P_Mobile;
        public string _P_PassportId;
        public string _P_SSN;
        public string _P_OrganizationId;
        public DateTime _P_DOB;
        public string _P_Gender;
        public bool _P_Status;
        public int _P_AccountTypeId;
        public string _P_Nationality;
        public string _Joint_P_PrimaryPhone;
        public string _Joint_P_SecondaryPhone;
        public bool _Joint_P_Deleted;
        public int _Joint_P_FK_ParticipantType;
        public string _Joint_P_FaxNumber;
        public string _Joint_P_PrimaryEmailAddress;
        public string _Joint_P_SecondaryEmailAddress;
        public bool _Joint_P_Active;
        public string _Joint_P_ParticipantType;
        public string _Joint_P_Fname;
        public string _Joint_P_Lname;
        public string _Joint_P_Address1;
        public string _Joint_P_Address2;
        public string _Joint_P_Country;
        public string _Joint_P_City;
        public string _Joint_P_State;
        public string _Joint_P_Zip;
        public string _Joint_P_Fax;
        public string _Joint_P_Phone;
        public string _Joint_P_Mobile;
        public string _Joint_P_PassportId;
        public string _Joint_P_SSN;
        public string _Joint_P_OrganizationId;
        public DateTime _Joint_P_DOB;
        public string _Joint_P_Gender;
        public bool _Joint_P_Status;
        public int _Joint_P_AccountTypeId;
        public string _Joint_P_Nationality;
        public Int64? _A_AccountId;
        public int _A_FK_AccountType;
        public int _A_AccountGroupId;
        public bool _A_IsEnable;
        public decimal _A_TaxRate;
        public int _A_IBManagerId;
        public string _A_Leverage;
        public string _A_MasterPassword;
        public string _A_InvestorPassword;
        public string _A_PhonePassword;
        public string _E_EmployerName;
        public string _E_CompanyAddress;
        public string _E_Country;
        public string _E_City;
        public string _E_State;
        public string _E_Zip;
        public string _E_Phone;
        public string _E_Fax;
        public string _E_EmployerEmail;
        public string _E_Designation;
        public string _E_Duration;
        public string _E_EmployementType;
        public string _E_RetiredYear;
        public string _E_WorkPhone;
        public string _Joint_E_EmployerName;
        public string _Joint_E_CompanyAddress;
        public string _Joint_E_Country;
        public string _Joint_E_City;
        public string _Joint_E_State;
        public string _Joint_E_Zip;
        public string _Joint_E_Phone;
        public string _Joint_E_Fax;
        public string _Joint_E_EmployerEmail;
        public string _Joint_E_Designation;
        public string _Joint_E_Duration;
        public string _Joint_E_EmployementType;
        public string _Joint_E_RetiredYear;
        public string _Joint_E_WorkPhone;
        public string _F_EstimatedAnnualIncome;
        public string _F_NetWorth;
        public string _F_LiquidNetWorth;
        public string _F_OtherFinancialInfo;
        public string _Joint_F_EstimatedAnnualIncome;
        public string _Joint_F_NetWorth;
        public string _Joint_F_LiquidNetWorth;
        public string _Joint_F_OtherFinancialInfo;
        public string _I_Equities;
        public string _I_Commodities;
        public string _I_Bonds;
        public string _I_ForeignExchange;
        public string _I_RealEstate;
        public string _I_Others;
        public string _Joint_I_Equities;
        public string _Joint_I_Commodities;
        public string _Joint_I_Bonds;
        public string _Joint_I_ForeignExchange;
        public string _Joint_I_RealEstate;
        public string _Joint_I_Others;
        public string _B_AccountHolderName;
        public string _B_BankAccountID;
        public string _B_BankName;
        public string _B_BankCountry;
        public string _B_BankCity;
        public string _B_BankZipCode;
        public string _B_BankAddress;
        public string _B_BankAddress2;
        public string _B_BankPhone;
        public string _B_BankFax;
        public string _B_BankSwiftCode;
        public int _B_ParticipantID;
        public string _B_P_Conuntry;
        public string _B_P_State;
        public string _B_P_City;
        public string _B_P_Zip;
        public string _B_p_Address1;
        public string _B_P_Address2;
        public string _B_ABACode;
        public string _OrganizationId;
        public string _Organization;
        public string _ORCountry;
        public string _ORDate;
        public string _ORAddress1;
        public string _ORAddress2;
        public string _ORCity;
        public string _ORState;
        public string _ORPhone1;
        public string _ORPhone2;
        public string _ORFax;
        public string _OREmail;
        public string _IdentificationID;
        public string _Ben_FirstName;
        public string _Ben_MiddleName;
        public string _Ben_LastName;
        public string _Ben_Gender;
        public string _Ben_Address1;
        public string _Ben_Address2;
        public string _Ben_City;
        public string _Ben_State;
        public int _Ben_Country;
        public string _Ben_Zip;
        public string _Ben_HomePh;
        public string _Ben_MobilePh;
        public string _Ben_Fax;
        public string _Ben_Email;
        public DateTime _Ben_DateOfBirth;
        public string _Ben_BirthCity;
        public string _Ben_BirthCountry;
        public string _Ben_ResidentNationaltity;
        public string _Ben_PassportId;
        public string _Ben_PassportImage;
        public string _Ben_AddressProofImg;
        public string _P_ImgAddress;
        public string _P_ImgPassport;
        public string _Joint_P_ImgAddress;
        public string _Joint_P_ImgPassport;
        public string _A_MarketType;

        public RegisterNewUser()
        {
            _P_PrimaryPhone = string.Empty;
            _P_SecondaryPhone = string.Empty;
            _Deleted = true;
            _P_FK_ParticipantType = 0;
            _P_FaxNumber = string.Empty;
            _P_PrimaryEmailAddress = string.Empty;
            _P_SecondaryEmailAddress = string.Empty;
            _P_Active = true;
            _P_ParticipantType = string.Empty;
            _P_Fname = string.Empty;
            _P_Lname = string.Empty;
            _P_Address1 = string.Empty;
            _P_Address2 = string.Empty;
            _P_Country = string.Empty;
            _P_City = string.Empty;
            _P_State = string.Empty;
            _P_Zip = string.Empty;
            _P_Fax = string.Empty;
            _P_Phone = string.Empty;
            _P_Mobile = string.Empty;
            _P_PassportId = string.Empty;
            _P_SSN = string.Empty;
            _P_OrganizationId = string.Empty;
            _P_DOB = DateTime.Now;
            _P_Gender = string.Empty;
            _P_Status = true;
            _P_AccountTypeId = 0;
            _P_Nationality = string.Empty;
            _Joint_P_PrimaryPhone = string.Empty;
            _Joint_P_SecondaryPhone = string.Empty;
            _Joint_P_Deleted = true;
            _Joint_P_FK_ParticipantType = 0;
            _Joint_P_FaxNumber = string.Empty;
            _Joint_P_PrimaryEmailAddress = string.Empty;
            _Joint_P_SecondaryEmailAddress = string.Empty;
            _Joint_P_Active = true;
            _Joint_P_ParticipantType = string.Empty;
            _Joint_P_Fname = string.Empty;
            _Joint_P_Lname = string.Empty;
            _Joint_P_Address1 = string.Empty;
            _Joint_P_Address2 = string.Empty;
            _Joint_P_Country = string.Empty;
            _Joint_P_City = string.Empty;
            _Joint_P_State = string.Empty;
            _Joint_P_Zip = string.Empty;
            _Joint_P_Fax = string.Empty;
            _Joint_P_Phone = string.Empty;
            _Joint_P_Mobile = string.Empty;
            _Joint_P_PassportId = string.Empty;
            _Joint_P_SSN = string.Empty;
            _Joint_P_OrganizationId = string.Empty;
            _Joint_P_DOB = DateTime.Now;
            _Joint_P_Gender = string.Empty;
            _Joint_P_Status = true;
            _Joint_P_AccountTypeId = 0;
            _Joint_P_Nationality = string.Empty;
            _A_AccountId = 0;
            _A_FK_AccountType = 0;
            _A_AccountGroupId = 0;
            _A_IsEnable = true;
            _A_TaxRate = 0;
            _A_IBManagerId = 0;
            _A_Leverage = string.Empty;
            _A_MasterPassword = string.Empty;
            _A_InvestorPassword = string.Empty;
            _A_PhonePassword = string.Empty;
            _E_EmployerName = string.Empty;
            _E_CompanyAddress = string.Empty;
            _E_Country = string.Empty;
            _E_City = string.Empty;
            _E_State = string.Empty;
            _E_Zip = string.Empty;
            _E_Phone = string.Empty;
            _E_Fax = string.Empty;
            _E_EmployerEmail = string.Empty;
            _E_Designation = string.Empty;
            _E_Duration = string.Empty;
            _E_EmployementType = string.Empty;
            _E_RetiredYear = string.Empty;
            _E_WorkPhone = string.Empty;
            _Joint_E_EmployerName = string.Empty;
            _Joint_E_CompanyAddress = string.Empty;
            _Joint_E_Country = string.Empty;
            _Joint_E_City = string.Empty;
            _Joint_E_State = string.Empty;
            _Joint_E_Zip = string.Empty;
            _Joint_E_Phone = string.Empty;
            _Joint_E_Fax = string.Empty;
            _Joint_E_EmployerEmail = string.Empty;
            _Joint_E_Designation = string.Empty;
            _Joint_E_Duration = string.Empty;
            _Joint_E_EmployementType = string.Empty;
            _Joint_E_RetiredYear = string.Empty;
            _Joint_E_WorkPhone = string.Empty;
            _F_EstimatedAnnualIncome = string.Empty;
            _F_NetWorth = string.Empty;
            _F_LiquidNetWorth = string.Empty;
            _F_OtherFinancialInfo = string.Empty;
            _Joint_F_EstimatedAnnualIncome = string.Empty;
            _Joint_F_NetWorth = string.Empty;
            _Joint_F_LiquidNetWorth = string.Empty;
            _Joint_F_OtherFinancialInfo = string.Empty;
            _I_Equities = string.Empty;
            _I_Commodities = string.Empty;
            _I_Bonds = string.Empty;
            _I_ForeignExchange = string.Empty;
            _I_RealEstate = string.Empty;
            _I_Others = string.Empty;
            _Joint_I_Equities = string.Empty;
            _Joint_I_Commodities = string.Empty;
            _Joint_I_Bonds = string.Empty;
            _Joint_I_ForeignExchange = string.Empty;
            _Joint_I_RealEstate = string.Empty;
            _Joint_I_Others = string.Empty;
            _B_AccountHolderName = string.Empty;
            _B_BankAccountID = string.Empty;
            _B_BankName = string.Empty;
            _B_BankCountry = string.Empty;
            _B_BankCity = string.Empty;
            _B_BankZipCode = string.Empty;
            _B_BankAddress = string.Empty;
            _B_BankAddress2 = string.Empty;
            _B_BankPhone = string.Empty;
            _B_BankFax = string.Empty;
            _B_BankSwiftCode = string.Empty;
            _B_ParticipantID = 0;
            _B_P_Conuntry = string.Empty;
            _B_P_State = string.Empty;
            _B_P_City = string.Empty;
            _B_P_Zip = string.Empty;
            _B_p_Address1 = string.Empty;
            _B_P_Address2 = string.Empty;
            _B_ABACode = string.Empty;
            _OrganizationId = string.Empty;
            _Organization = string.Empty;
            _ORCountry = string.Empty;
            _ORDate = string.Empty;
            _ORAddress1 = string.Empty;
            _ORAddress2 = string.Empty;
            _ORCity = string.Empty;
            _ORState = string.Empty;
            _ORPhone1 = string.Empty;
            _ORPhone2 = string.Empty;
            _ORFax = string.Empty;
            _OREmail = string.Empty;
            _IdentificationID = string.Empty;
            _Ben_FirstName = string.Empty;
            _Ben_MiddleName = string.Empty;
            _Ben_LastName = string.Empty;
            _Ben_Gender = string.Empty;
            _Ben_Address1 = string.Empty;
            _Ben_Address2 = string.Empty;
            _Ben_City = string.Empty;
            _Ben_State = string.Empty;
            _Ben_Country = 0;
            _Ben_Zip = string.Empty;
            _Ben_HomePh = string.Empty;
            _Ben_MobilePh = string.Empty;
            _Ben_Fax = string.Empty;
            _Ben_Email = string.Empty;
            _Ben_DateOfBirth = DateTime.Now;
            _Ben_BirthCity = string.Empty;
            _Ben_BirthCountry = string.Empty;
            _Ben_ResidentNationaltity = string.Empty;
            _Ben_PassportId = string.Empty;
            _Ben_PassportImage = string.Empty;
            _Ben_AddressProofImg = string.Empty;
            _P_ImgAddress = string.Empty;
            _P_ImgPassport = string.Empty;
            _Joint_P_ImgAddress = string.Empty;
            _Joint_P_ImgPassport = string.Empty;
            _A_MarketType = string.Empty;
        }

        public override string ToString()
        {
            return
                "_A_AccountGroupId->" + _A_AccountGroupId +
                "_A_AccountId->" + _A_AccountId +
                "_A_FK_AccountType->" + _A_FK_AccountType +
                "_A_IBManagerId->" + _A_IBManagerId +
                "_A_InvestorPassword->" + _A_InvestorPassword +
                "_A_IsEnable->" + _A_IsEnable +
                "_A_Leverage->" + _A_Leverage +
                "_A_MarketType->" + _A_MarketType +
                "_A_MasterPassword->" + _A_MasterPassword +
                "_A_PhonePassword->" + _A_PhonePassword +
                "_A_TaxRate->" + _A_TaxRate +
                "_B_ABACode->" + _B_ABACode +
                "_B_AccountHolderName->" + _B_AccountHolderName +
                "_B_BankAccountID->" + _B_BankAccountID +
                "_B_BankAddress->" + _B_BankAddress +
                "_B_BankAddress2->" + _B_BankAddress2 +
                "_B_BankCity->" + _B_BankCity +
                "_B_BankCountry->" + _B_BankCountry +
                "_B_BankFax->" + _B_BankFax +
                "_B_BankName->" + _B_BankName +
                "_B_BankPhone->" + _B_BankPhone +
                "_B_BankSwiftCode->" + _B_BankSwiftCode +
                "_B_BankZipCode->" + _B_BankZipCode +
                "_B_p_Address1->" + _B_p_Address1 +
                "_B_P_Address2->" + _B_P_Address2 +
                "_B_P_City->" + _B_P_City +
                "_B_P_Conuntry->" + _B_P_Conuntry +
                "_B_P_State->" + _B_P_State +
                "_B_P_Zip->" + _B_P_Zip +
                "_B_ParticipantID->" + _B_ParticipantID +
                "_Ben_Address1->" + _Ben_Address1 +
                "_Ben_Address2->" + _Ben_Address2 +
                "_Ben_AddressProofImg->" + _Ben_AddressProofImg +
                "_Ben_BirthCity->" + _Ben_BirthCity +
                "_Ben_BirthCountry->" + _Ben_BirthCountry +
                "_Ben_City->" + _Ben_City +
                "_Ben_Country->" + _Ben_Country +
                "_Ben_DateOfBirth->" + _Ben_DateOfBirth +
                "_Ben_Email->" + _Ben_Email +
                "_Ben_Fax->" + _Ben_Fax +
                "_Ben_FirstName->" + _Ben_FirstName +
                "_Ben_Gender->" + _Ben_Gender +
                "_Ben_HomePh->" + _Ben_HomePh +
                "_Ben_LastName->" + _Ben_LastName +
                "_Ben_MiddleName->" + _Ben_MiddleName +
                "_Ben_MobilePh->" + _Ben_MobilePh +
                "_Ben_PassportId->" + _Ben_PassportId +
                "_Ben_PassportImage->" + _Ben_PassportImage +
                "_Ben_ResidentNationaltity->" + _Ben_ResidentNationaltity +
                "_Ben_State->" + _Ben_State +
                "_Ben_Zip->" + _Ben_Zip +
                "_Deleted->" + _Deleted +
                "_E_City->" + _E_City +
                "_E_CompanyAddress->" + _E_CompanyAddress +
                "_E_Country->" + _E_Country +
                "_E_Designation->" + _E_Designation +
                "_E_Duration->" + _E_Duration +
                "_E_EmployementType->" + _E_EmployementType +
                "_E_EmployerEmail->" + _E_EmployerEmail +
                "_E_EmployerName->" + _E_EmployerName +
                "_E_Fax->" + _E_Fax +
                "_E_Phone->" + _E_Phone +
                "_E_RetiredYear->" + _E_RetiredYear +
                "_E_State->" + _E_State +
                "_E_WorkPhone->" + _E_WorkPhone +
                "_E_Zip->" + _E_Zip +
                "_F_EstimatedAnnualIncome->" + _F_EstimatedAnnualIncome +
                "_F_LiquidNetWorth->" + _F_LiquidNetWorth +
                "_F_NetWorth->" + _F_NetWorth +
                "_F_OtherFinancialInfo->" + _F_OtherFinancialInfo +
                "_I_Bonds->" + _I_Bonds +
                "_I_Commodities->" + _I_Commodities +
                "_I_Equities->" + _I_Equities +
                "_I_ForeignExchange->" + _I_ForeignExchange +
                "_I_Others->" + _I_Others +
                "_I_RealEstate->" + _I_RealEstate +
                "_IdentificationID->" + _IdentificationID +
                "_Joint_E_City->" + _Joint_E_City +
                "_Joint_E_CompanyAddress->" + _Joint_E_CompanyAddress +
                "_Joint_E_Country->" + _Joint_E_Country +
                "_Joint_E_Designation->" + _Joint_E_Designation +
                "_Joint_E_Duration->" + _Joint_E_Duration +
                "_Joint_E_EmployementType->" + _Joint_E_EmployementType +
                "_Joint_E_EmployerEmail->" + _Joint_E_EmployerEmail +
                "_Joint_E_EmployerName->" + _Joint_E_EmployerName +
                "_Joint_E_Fax->" + _Joint_E_Fax +
                "_Joint_E_Phone->" + _Joint_E_Phone +
                "_Joint_E_RetiredYear->" + _Joint_E_RetiredYear +
                "_Joint_E_State->" + _Joint_E_State +
                "_Joint_E_WorkPhone->" + _Joint_E_WorkPhone +
                "_Joint_E_Zip->" + _Joint_E_Zip +
                "_Joint_F_EstimatedAnnualIncome->" + _Joint_F_EstimatedAnnualIncome +
                "_Joint_F_LiquidNetWorth->" + _Joint_F_LiquidNetWorth +
                "_Joint_F_NetWorth->" + _Joint_F_NetWorth +
                "_Joint_F_OtherFinancialInfo->" + _Joint_F_OtherFinancialInfo +
                "_Joint_I_Bonds->" + _Joint_I_Bonds +
                "_Joint_I_Commodities->" + _Joint_I_Commodities +
                "_Joint_I_Equities->" + _Joint_I_Equities +
                "_Joint_I_ForeignExchange->" + _Joint_I_ForeignExchange +
                "_Joint_I_Others->" + _Joint_I_Others +
                "_Joint_I_RealEstate->" + _Joint_I_RealEstate +
                "_Joint_P_AccountTypeId->" + _Joint_P_AccountTypeId +
                "_Joint_P_Active->" + _Joint_P_Active +
                "_Joint_P_Address1->" + _Joint_P_Address1 +
                "_Joint_P_Address2->" + _Joint_P_Address2 +
                "_Joint_P_City->" + _Joint_P_City +
                "_Joint_P_Country->" + _Joint_P_Country +
                "_Joint_P_Deleted->" + _Joint_P_Deleted +
                "_Joint_P_DOB->" + _Joint_P_DOB +
                "_Joint_P_Fax->" + _Joint_P_Fax +
                "_Joint_P_FaxNumber->" + _Joint_P_FaxNumber +
                "_Joint_P_FK_ParticipantType->" + _Joint_P_FK_ParticipantType +
                "_Joint_P_Fname->" + _Joint_P_Fname +
                "_Joint_P_Gender->" + _Joint_P_Gender +
                "_Joint_P_ImgAddress->" + _Joint_P_ImgAddress +
                "_Joint_P_ImgPassport->" + _Joint_P_ImgPassport +
                "_Joint_P_Lname->" + _Joint_P_Lname +
                "_Joint_P_Mobile->" + _Joint_P_Mobile +
                "_Joint_P_Nationality->" + _Joint_P_Nationality +
                "_Joint_P_OrganizationId->" + _Joint_P_OrganizationId +
                "_Joint_P_ParticipantType->" + _Joint_P_ParticipantType +
                "_Joint_P_PassportId->" + _Joint_P_PassportId +
                "_Joint_P_Phone->" + _Joint_P_Phone +
                "_Joint_P_PrimaryEmailAddress->" + _Joint_P_PrimaryEmailAddress +
                "_Joint_P_PrimaryPhone->" + _Joint_P_PrimaryPhone +
                "_Joint_P_SecondaryEmailAddress->" + _Joint_P_SecondaryEmailAddress +
                "_Joint_P_SecondaryPhone->" + _Joint_P_SecondaryPhone +
                "_Joint_P_SSN->" + _Joint_P_SSN +
                "_Joint_P_State->" + _Joint_P_State +
                "_Joint_P_Status->" + _Joint_P_Status +
                "_Joint_P_Zip->" + _Joint_P_Zip +
                "_ORAddress1->" + _ORAddress1 +
                "_ORAddress2->" + _ORAddress2 +
                "_ORCity->" + _ORCity +
                "_ORCountry->" + _ORCountry +
                "_ORDate->" + _ORDate +
                "_OREmail->" + _OREmail +
                "_ORFax->" + _ORFax +
                "_Organization->" + _Organization +
                "_OrganizationId->" + _OrganizationId +
                "_ORPhone1->" + _ORPhone1 +
                "_ORPhone2->" + _ORPhone2 +
                "_ORState->" + _ORState +
                "_P_AccountTypeId->" + _P_AccountTypeId +
                "_P_Active->" + _P_Active +
                "_P_Address1->" + _P_Address1 +
                "_P_Address2->" + _P_Address2 +
                "_P_City->" + _P_City +
                "_P_Country->" + _P_Country +
                "_P_DOB->" + _P_DOB +
                "_P_Fax->" + _P_Fax +
                "_P_FaxNumber->" + _P_FaxNumber +
                "_P_FK_ParticipantType->" + _P_FK_ParticipantType +
                "_P_Fname->" + _P_Fname +
                "_P_Gender->" + _P_Gender +
                "_P_ImgAddress->" + _P_ImgAddress +
                "_P_ImgPassport->" + _P_ImgPassport +
                "_P_Lname->" + _P_Lname +
                "_P_Mobile->" + _P_Mobile +
                "_P_Nationality->" + _P_Nationality +
                "_P_OrganizationId->" + _P_OrganizationId +
                "_P_ParticipantType->" + _P_ParticipantType +
                "_P_PassportId->" + _P_PassportId +
                "_P_Phone->" + _P_Phone +
                "_P_PrimaryEmailAddress->" + _P_PrimaryEmailAddress +
                "_P_PrimaryPhone->" + _P_PrimaryPhone +
                "_P_SecondaryEmailAddress->" + _P_SecondaryEmailAddress +
                "_P_SecondaryPhone->" + _P_SecondaryPhone +
                "_P_SSN->" + _P_SSN +
                "_P_State->" + _P_State +
                "_P_Status->" + _P_Status +
                "_P_Zip->" + _P_Zip;


        }
    }

    public class LiveUpdate
    {
        public int _LiveUpdateId;
        public bool _IsEnable;
        public string _Company;
        public string _Type;
        public int _MaximumConnections;
        public string _Folder;
        public string _Version;
        public LiveUpdate()
        {
            _Company = string.Empty;
            _Folder = string.Empty;
            _IsEnable = true;
            _LiveUpdateId = 0;
            _MaximumConnections = 0;
            _Type = string.Empty;
            _Version = string.Empty;
        }
        public override string ToString()
        {
            return
              "_Company->" + _Company +
              "_Folder->" + _Folder +
              "_IsEnable->" + _IsEnable +
              "_LiveUpdateId->" + _LiveUpdateId +
              "_MaximumConnections->" + _MaximumConnections +
              "_Type->" + _Type +
              "_Version->" + _Version;
        }
    }

    public enum DBMODE
    {
        INSERT,
        UPDATE,
        DELETE,
        NA
    }
    public class ManagerRole
    {
        public int _RoleId;
        public string _RoleName;
        public string _AccessRightId;
        public DBMODE _DBMODE;
        public ManagerRole()
        {
            _RoleId = 0;
            _RoleName = string.Empty;
            _AccessRightId = string.Empty;
            _DBMODE = DBMODE.NA;
        }
        public override string ToString()
        {
            return "_RoleId -> " + _RoleId + "  _RoleName -> " + _RoleName + "   _AccessRightId -> " + _AccessRightId;
        }
    }
}
