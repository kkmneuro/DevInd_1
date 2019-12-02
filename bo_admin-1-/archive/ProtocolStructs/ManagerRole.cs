using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
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
