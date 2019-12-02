using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using clsInterface4OME;
using clsInterface4OME.DSBO;
using System.Windows.Forms;

namespace BOADMIN_NEW.Cls
{
    public abstract class IclsManager
    {
        public bool isManagerConnected
        {
            get
            {
                return clsDataManager.INSTANCE.isServerConnected;
            }
        }

        public abstract void AddSetting(IProtocolStruct PS);
        public abstract void RemoveSetting(string  DataKey);
        public abstract void ServerRequestResponse(DBResponse response);

        public bool SendData(IProtocolStruct PS,out string Status)
        {
            Status = string.Empty;
            //if (isManagerConnected)
            {
                Status = "Request is submitted";
                clsDataManager.INSTANCE.SubmitData(PS);
                return true;
            }
            //else
            //{
            //    Status = "Server is not connected";
            //    return false;
            //}
        }

        public void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccessMessage(string msg)
        {
                MessageBox.Show(msg, "Server Response", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }     
    }
}
