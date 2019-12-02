using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class ManagerRightsPS :IProtocolStruct
    {
        public ManagerRights _ManagerRights;
        public ManagerRightsPS()
        {
            _ManagerRights = new ManagerRights();
        }
        public ManagerRightsPS(ManagerRights deepCopy)
        {
            _ManagerRights._AccessibleRightsId = deepCopy._AccessibleRightsId;
            _ManagerRights._AvailableDataForDays = deepCopy._AvailableDataForDays;
            _ManagerRights._Description = deepCopy._Description;
            _ManagerRights._Group = deepCopy._Group;
            _ManagerRights._Id = deepCopy._Id;
            _ManagerRights._IpAccess = deepCopy._IpAccess;
            _ManagerRights._IPFrom = deepCopy._IPFrom;
            _ManagerRights._IPTo = deepCopy._IPTo;
            _ManagerRights._IsIpRestrict = deepCopy._IsIpRestrict;
            _ManagerRights._Login = deepCopy._Login;
            _ManagerRights._MailBoxName = deepCopy._MailBoxName;
            _ManagerRights._ManagerRoleId = deepCopy._ManagerRoleId;
            _ManagerRights._Name = deepCopy._Name;
            _ManagerRights._RoleId = deepCopy._RoleId;
            _ManagerRights._RoleName = deepCopy._RoleName;
            _ManagerRights._Roles= deepCopy._Roles;
            _ManagerRights._Right = deepCopy._Right;
            //_ManagerRights._IsAccessRightsManager = deepCopy._IsAccessRightsManager;
            //_ManagerRights._IsAccessRightsAdministration = deepCopy._IsAccessRightsAdministration;
            //_ManagerRights._IsAccessRightsReports = deepCopy._IsAccessRightsReports;
            //_ManagerRights._IsAccessRightsInternalMailSystem = deepCopy._IsAccessRightsInternalMailSystem;
            //_ManagerRights._IsAccessRightsSendNews = deepCopy._IsAccessRightsSendNews;
            //_ManagerRights._IsAccessRightsConnections = deepCopy._IsAccessRightsConnections;
            //_ManagerRights._IsAccessRightsConfigureServerPlugins = deepCopy._IsAccessRightsConfigureServerPlugins;
            //_ManagerRights._IsAccessRightsSuperviseTrades = deepCopy._IsAccessRightsSuperviseTrades;
            //_ManagerRights._IsAccessRightsAccountant = deepCopy._IsAccessRightsAccountant;
            //_ManagerRights._IsAccessRightsRiskManager = deepCopy._IsAccessRightsRiskManager;
            //_ManagerRights._IsAccessRightsJournals = deepCopy._IsAccessRightsJournals;
            //_ManagerRights._IsAccessRightsMarketWatch = deepCopy._IsAccessRightsMarketWatch;
            //_ManagerRights._IsAccessRightsPersonalDetails = deepCopy._IsAccessRightsPersonalDetails;
            //_ManagerRights._IsAccessRightsAutomaticServerReports = deepCopy._IsAccessRightsAutomaticServerReports;
            //_ManagerRights._IsTradingTransactionDealer = deepCopy._IsTradingTransactionDealer;
            //_ManagerRights._IsTradingTransactionEditDeleteTrades = deepCopy._IsTradingTransactionEditDeleteTrades;
            
        }
        public override int ID
        {
            get { return ProtocolStructIDS.ManagerRights_ID ; }
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
            AppendStr(_ManagerRights._AccessibleRightsId);
            AppendStr(_ManagerRights._AvailableDataForDays);
            AppendStr(_ManagerRights._Description);
            AppendStr(_ManagerRights._Group);
            AppendStr(_ManagerRights._Id);
            AppendStr(_ManagerRights._IpAccess);
            AppendStr(_ManagerRights._IPFrom);
            AppendStr(_ManagerRights._IPTo);
            AppendStr(_ManagerRights._IsIpRestrict);
            AppendStr(_ManagerRights._Login);
            AppendStr(_ManagerRights._MailBoxName);
            AppendStr(_ManagerRights._ManagerRoleId);
            AppendStr(_ManagerRights._Name);
            AppendStr(_ManagerRights._RoleId);
            AppendStr(_ManagerRights._RoleName);
            AppendStr(_ManagerRights._Roles);
            AppendStr(_ManagerRights._Right);
            //AppendStr(_ManagerRights._IsAccessRightsManager);
            //AppendStr(_ManagerRights._IsAccessRightsAdministration);
            //AppendStr(_ManagerRights._IsAccessRightsReports);
            //AppendStr(_ManagerRights._IsAccessRightsInternalMailSystem);
            //AppendStr(_ManagerRights._IsAccessRightsSendNews);
            //AppendStr(_ManagerRights._IsAccessRightsConnections);
            //AppendStr(_ManagerRights._IsAccessRightsConfigureServerPlugins);
            //AppendStr(_ManagerRights._IsAccessRightsSuperviseTrades);
            //AppendStr(_ManagerRights._IsAccessRightsAccountant);
            //AppendStr(_ManagerRights._IsAccessRightsRiskManager);
            //AppendStr(_ManagerRights._IsAccessRightsJournals);
            //AppendStr(_ManagerRights._IsAccessRightsMarketWatch);
            //AppendStr(_ManagerRights._IsAccessRightsPersonalDetails);
            //AppendStr(_ManagerRights._IsAccessRightsAutomaticServerReports);
            //AppendStr(_ManagerRights._IsTradingTransactionDealer);
            //AppendStr(_ManagerRights._IsTradingTransactionEditDeleteTrades);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
             _ManagerRights._AccessibleRightsId =SpltString[0];
             _ManagerRights._AvailableDataForDays = SpltString[1];
             _ManagerRights._Description =SpltString[2];
             _ManagerRights._Group = SpltString[3];
             _ManagerRights._Id = clsUtility.GetLong(SpltString[4]);
             _ManagerRights._IpAccess = SpltString[5];
             _ManagerRights._IPFrom= SpltString[6];
             _ManagerRights._IPTo = SpltString[7];
             _ManagerRights._IsIpRestrict = Convert.ToBoolean(SpltString[8]);
             _ManagerRights._Login =clsUtility.GetInt(SpltString[9]);
             _ManagerRights._MailBoxName = SpltString[10];
             _ManagerRights._ManagerRoleId = clsUtility.GetInt(SpltString[11]);
             _ManagerRights._Name = SpltString[12];
             _ManagerRights._RoleId = clsUtility.GetInt(SpltString[13]);
             _ManagerRights._RoleName = SpltString[14];
             _ManagerRights._Roles = SpltString[15];
             _ManagerRights._Right = SpltString[16];
           
        }
        public override string ToString()
        {
            return _ManagerRights==null?base.ToString(): _ManagerRights.ToString();
        }

        public override bool ValidateData()
        {
            base.ValidateData();
            Add2Vld("AvailableDataForDays is Empty", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty((_ManagerRights._AvailableDataForDays)));
            Add2Vld("AvailableDataForDays is not Integer", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger ((_ManagerRights._AvailableDataForDays)));
            Add2Vld("Group is empty", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ManagerRights._Group));
            Add2Vld("MailBox Name is empty", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty(_ManagerRights._MailBoxName));
            Add2Vld("IP From is incorrect", clsInterface4OME.clsUtil4ProtoVali.ValidateIP(_ManagerRights._IPFrom));
            Add2Vld("IP To is incorrect", clsInterface4OME.clsUtil4ProtoVali.ValidateIP (_ManagerRights._IPTo));
            Add2Vld("IP Check compare fails", clsInterface4OME.clsUtil4ProtoVali.ValidateCompareIp(_ManagerRights._IPFrom, _ManagerRights._IPTo));
           
            Add2Vld("Login Name is not integer", clsInterface4OME.clsUtil4ProtoVali.ValidateInteger(_ManagerRights._Login));
            Add2Vld("Login Name is empty", clsInterface4OME.clsUtil4ProtoVali.ValidateIsEmpty((_ManagerRights._Login)));           
            return IsValidlist();
        }
    }
}
