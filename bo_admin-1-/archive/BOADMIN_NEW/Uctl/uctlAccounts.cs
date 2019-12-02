using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsInterface4OME;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
namespace BOADMIN_NEW.Uctl
{
    public partial class uctlAccounts : uctlGeneric, Interfaces.IUserCtrl
    {

        public AccountDetails obj;
        public uctlAccounts()
        {
            InitializeComponent();
           
        }
        public DS4Account.dtClientInfoRow _row = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        uctlAccountPersonal objAccountPersonal = new uctlAccountPersonal();
        Int32 _ClientID = -999;
        

        #region IUserCtrl Members

        public void Init()
        {
            
        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {
        }

        #endregion

        private void ui_rdoPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (objAccountPersonal != null && ui_rdoPersonal.Checked)
            {
                ui_pnlContainer.Controls.Clear();
                objAccountPersonal.Dock = DockStyle.Fill;
                ui_pnlContainer.Controls.Add(objAccountPersonal);
            }
        }

        private void ui_rdoTrades_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ui_rdoSecurity_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        //Send Ui data 
        protected void EditAccount()
        { 
        }

        private void ui_btnCancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
            
        }

        private void uctlAccounts_Load(object sender, EventArgs e)
        {
            if (_row == null)
            {
                return;
            }
            _ClientID = _row.ClientId;
            DS4Account.dtClientInfoRow AccountRow = clsAccountManager.INSTANCE._DS4Account.dtClientInfo.FindByClientId(_ClientID);

            if (objAccountPersonal != null)
            {
                ui_pnlContainer.Controls.Clear();
                objAccountPersonal.Dock = DockStyle.Fill;
                ui_pnlContainer.Controls.Add(objAccountPersonal);
            }
        }
    }
}
