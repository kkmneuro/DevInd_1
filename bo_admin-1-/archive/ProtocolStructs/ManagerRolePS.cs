using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class ManagerRolePS : IProtocolStruct
    {
       public ManagerRole _ManagerRole;
       public ManagerRolePS()
       {
           _ManagerRole=new ManagerRole();
       }
       public ManagerRolePS(ManagerRole deepCopy)
       {
           _ManagerRole._RoleId=deepCopy._RoleId;
           _ManagerRole._RoleName=deepCopy._RoleName;
           _ManagerRole._AccessRightId=deepCopy._AccessRightId;
           _ManagerRole._DBMODE=deepCopy._DBMODE;         

           
       }
       public override int ID
       {
           get { return ProtocolStructIDS.ManagerRole_ID; }
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
           AppendStr(_ManagerRole._RoleId);
           AppendStr(_ManagerRole._RoleName);
           AppendStr(_ManagerRole._AccessRightId);
           AppendStr(_ManagerRole._DBMODE.ToString());       
            EndStrW();
       }

       public override void ReadString(string Msgbfr)
       {
           int index = -1;
           StartStrR(Msgbfr);
           _ManagerRole._RoleId = clsUtility.GetInt(SpltString[++index]);
           _ManagerRole._RoleName = SpltString[++index];
           _ManagerRole._AccessRightId = SpltString[++index];
           _ManagerRole._DBMODE = (DBMODE)Enum.Parse(typeof(DBMODE), SpltString[++index], true);       
           
       }
       public override string ToString()
       {
           return _ManagerRole ==null ? base.ToString() : _ManagerRole.ToString();
       }

       public override bool ValidateData()
       {
           throw new NotImplementedException();
       }
    }
}
