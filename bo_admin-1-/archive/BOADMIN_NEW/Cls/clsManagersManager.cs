using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
namespace BOADMIN_NEW.Cls
{
    public class clsManagersManager:IclsManager
    {
        #region Members
        static clsManagersManager _clsManagersManager = null;
        public DS4Managers _DS4Managers = new DS4Managers();
        #endregion Members
        #region Method
        private clsManagersManager()
        {
        }
        private void DoHandleManagerTable(ManagerRights Man)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("clsManagersManager : Enter DoHandleManagerTable()");
                DS4Managers.dtManagerRow _ManagerRow = _DS4Managers.dtManager.FindByLogin(Man._Login);
                if (_ManagerRow == null)
                {
                    _DS4Managers.dtManager.AdddtManagerRow(Man._Login, Man._AvailableDataForDays, Man._Group, Man._MailBoxName, Man._IsIpRestrict, Man._IPFrom, Man._IPTo, Man._RoleId,Man._Name ,Man._Id,Man._Right);
                }
                else
                {
                    //_ManagerRow.AccessibleRightsID = Man._AccessibleRightsId;
                    _ManagerRow.Id=Man._Id;
                    _ManagerRow.IsIPFilter = Man._IsIpRestrict;
                    _ManagerRow.DataAvailableForDays = Man._AvailableDataForDays;
                    _ManagerRow.Groups = Man._Group;
                    _ManagerRow.MailBoxName = Man._MailBoxName;
                    _ManagerRow.IsIPFilter = Man._IsIpRestrict;
                    _ManagerRow.FilterIPAddressFrom  = Man._IPFrom;
                    _ManagerRow.FilterIPAddressTo = Man._IPTo;
                    _ManagerRow.RoleId = Man._RoleId ;
                  _ManagerRow.Name = Man._Name;
                  _ManagerRow.Right = Man._Right;
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsManagersManager =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in DoHandleManagerTable()");
            }
        }

        #endregion Method
        #region Property
        public static clsManagersManager INSTANCE
        {
            get
            {
                if (_clsManagersManager  == null)
                {
                    _clsManagersManager = new clsManagersManager();
                }
                return _clsManagersManager;
            }

        }
        #endregion Property

        public string[] GetManagerRoles()
        {
            List<DS4Managers.dtManagerRoleRow> lst =  _DS4Managers.dtManagerRole.ToList();
            string[] roles = new string[lst.Count];
            int ind = -1;
            foreach (DS4Managers.dtManagerRoleRow item in lst)
            {
                roles[++ind] = item.RoleName;
            }

            return roles;

        }

        public string GetManagerAccessRightIDS(string RoleName)
        {
            DS4Managers.dtManagerRoleRow[] row = (DS4Managers.dtManagerRoleRow[])_DS4Managers.dtManagerRole.Select("RoleName = '" + RoleName.ToString() + "'");
            if (row.Length == 1)
            {
                return row[0].AccessRightId;
            }
            return null;

        }
        public string GetRigtString(int id)
        {
            DS4Managers.dtManagerRoleRow[] row = (DS4Managers.dtManagerRoleRow[])_DS4Managers.dtManagerRole.Select("RoleId ='" + id.ToString() + "'");
            if (row.Length == 1)
            {
                return row[0].AccessRightId;
            }
            return null;
        }

        public int GetManagerRoleID(string RoleName)
        {
            DS4Managers.dtManagerRoleRow[] row = (DS4Managers.dtManagerRoleRow[])_DS4Managers.dtManagerRole.Select("RoleName = '" + RoleName.ToString() + "'");
            if (row.Length == 1)
            {
                return row[0].RoleID;
            }
            return -999;

        }
        public string GetManagerRoleName(int RoleId)
        {
            DS4Managers.dtManagerRoleRow[] row = (DS4Managers.dtManagerRoleRow[])_DS4Managers.dtManagerRole.Select("RoleId = " + RoleId.ToString());
            if (row.Length == 1)
            {
                return row[0].RoleName;
            }
            return null;

        }

        #region IclsManaager
        public override void AddSetting(IProtocolStruct PS)
        {
            switch (PS.ID)
            {
                case ProtocolStructIDS.ManagerRights_ID:
                    DoHandleManagerTable((PS as ManagerRightsPS)._ManagerRights);
                    break;
                case ProtocolStructIDS.ManagerRole_ID:
                    DoHandleManagerRole((PS as ManagerRolePS)._ManagerRole);
                    break;
                default:
                    break;
            }
            
        }

        private void DoHandleManagerRole(ManagerRole managerRole)
        {
            DS4Managers.dtManagerRoleRow ManagerRoleRow = _DS4Managers.dtManagerRole.FindByRoleID(managerRole._RoleId);
            if (ManagerRoleRow == null)
            {
                _DS4Managers.dtManagerRole.AdddtManagerRoleRow(managerRole._RoleId, managerRole._RoleName, managerRole._AccessRightId);
            }
            else
            {
                ManagerRoleRow.RoleID = managerRole._RoleId;
                ManagerRoleRow.RoleName = managerRole._RoleName;
                ManagerRoleRow.AccessRightId = managerRole._AccessRightId;
            }

        }
        public override void RemoveSetting(string DataKey)
        {
            int ManagerID = -999;
            try
            {
               ManagerID = Convert.ToInt32(DataKey);
            }
            catch (Exception ex)
            {
                FileHandling.WriteToLogEx(ex);
                return;
            }
            DS4Managers.dtManagerRow Row = _DS4Managers.dtManager.FindByLogin(ManagerID);
            lock (_DS4Managers.dtManager)
            {
                _DS4Managers.dtManager.RemovedtManagerRow(Row);
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
    }
}
