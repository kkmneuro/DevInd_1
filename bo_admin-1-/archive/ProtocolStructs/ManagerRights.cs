using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
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
      

        //public bool _IsAccessRightsManager;
        //public bool _IsAccessRightsAdministration;
        //public bool _IsAccessRightsReports;
        //public bool _IsAccessRightsInternalMailSystem;
        //public bool _IsAccessRightsSendNews;
        //public bool _IsAccessRightsConnections;
        //public bool _IsAccessRightsConfigureServerPlugins;
        //public bool _IsAccessRightsSuperviseTrades;
        //public bool _IsAccessRightsAccountant;
        //public bool _IsAccessRightsRiskManager;
        //public bool _IsAccessRightsJournals;
        //public bool _IsAccessRightsMarketWatch;
        //public bool _IsAccessRightsPersonalDetails;
        //public bool _IsAccessRightsAutomaticServerReports;
        //public bool _IsTradingTransactionDealer;
        //public bool _IsTradingTransactionEditDeleteTrades;


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
            //_IsAccessRightsInternalMailSystem = true;
            //_IsAccessRightsAdministration = true;
            //_IsAccessRightsReports = true;
            //_IsAccessRightsInternalMailSystem = true;
            //_IsAccessRightsSendNews = true;
            //_IsAccessRightsConnections = true;
            //_IsAccessRightsConfigureServerPlugins = true;
            //_IsAccessRightsSuperviseTrades = true;
            //_IsAccessRightsAccountant = true;
            //_IsAccessRightsRiskManager = true;
            //_IsAccessRightsJournals = true;
            //_IsAccessRightsMarketWatch = true;
            //_IsAccessRightsPersonalDetails = true;
            //_IsAccessRightsAutomaticServerReports = true;
            //_IsTradingTransactionDealer = true;
            //_IsTradingTransactionEditDeleteTrades = true;

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
                //"_IsAccessRightsManager->" + _IsAccessRightsManager +
                //"_IsAccessRightsAdministration" + _IsAccessRightsAdministration +
                //"_IsAccessRightsReports" + _IsAccessRightsReports +
                //"_IsAccessRightsManager->" + _IsAccessRightsInternalMailSystem +
                //"_IsAccessRightsAdministration" + _IsAccessRightsSendNews +
                //"_IsAccessRightsReports" + _IsAccessRightsConnections +
                //"_IsAccessRightsManager->" + _IsAccessRightsConfigureServerPlugins +
                //"_IsAccessRightsAdministration" + _IsAccessRightsSuperviseTrades +
                //"_IsAccessRightsReports" + _IsAccessRightsAccountant +
                //"_IsAccessRightsManager->" + _IsAccessRightsRiskManager +
                //"_IsAccessRightsAdministration" + _IsAccessRightsJournals +
                //"_IsAccessRightsReports" + _IsAccessRightsMarketWatch +
                //"_IsAccessRightsReports" + _IsAccessRightsPersonalDetails +
                //"_IsAccessRightsManager->" + _IsAccessRightsAutomaticServerReports +
                //"_IsTradingTransactionDealer" + _IsTradingTransactionDealer +
                //"_IsTradingTransactionEditDeleteTrades" + _IsTradingTransactionEditDeleteTrades;
        }
    }
}
