using System;

using System.Windows.Forms;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Forms
{
    /// <summary>
    /// Form of client control
    /// </summary>
    public partial class FrmClient_Accounts : FrmBase
    {
        static FrmClient_Accounts _Instance = null;
        public static FrmClient_Accounts GetInstance()
        {
            return _Instance ?? (_Instance = new FrmClient_Accounts());
        }

        private FrmClient_Accounts()
        {
            InitializeComponent();

        }
        //ClientId,ClientName,AccountGroupId,ClientTypeID
        string[] SearchParms = new string[6];

        /// <summary>
        /// operations to be performed on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClient_Accounts_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            ui_ncmbBrokerType.Items.Clear();
            ui_ncmbBrokerIds.Items.Clear();
            for (int index = clsGlobal.BrokerID; index < Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray().Length; index++)
            {
                if (!ui_ncmbBrokerType.Items.Contains(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]))
                {
                    ui_ncmbBrokerType.Items.Add(Cls.clsBrokerManager.INSTANCE.GetBrokerTypesArray()[index]);
                }
            }
            //ui_ncmbBrokerType.Items.AddRange(clsBrokerManager.INSTANCE.GetBrokerTypesArray());
            ui_ncmbBrokerType.Items.Insert(0, "All");
            ui_ncmbBrokerIds.Items.AddRange(clsAccountManager.INSTANCE.GetBrokerIDs());
            if(!ui_ncmbBrokerIds.Items.Contains(clsGlobal.BrokerNameId.ToString()))
               ui_ncmbBrokerIds.Items.Add(clsGlobal.BrokerNameId.ToString());
            ui_ncmbBrokerIds.Items.Insert(0, "All");
            ncmbAccountGroup.Items.Insert(0, "All");           
            ncmdClientType.Items.Insert(0, "All");
            ncmdClientType.SelectedIndex = 0;
            ui_ncmbBrokerType.SelectedIndex = 0;
            ui_ncmbBrokerIds.SelectedIndex = 0;
            ncmbAccountGroup.SelectedIndex = 0;
            const int id = (int)clsEnums.CommandIDS.CLIENTS;
           // FrmMain.Instance.R
            string x = clsGlobal.Role.Split('_')[id];
            uctlAccountMain1.ui_contextmnuCommonNewAccount.Visible = Convert.ToInt32(x.ToCharArray()[1].ToString()) != 0;
            if (Convert.ToInt32(x.ToCharArray()[2].ToString()) == 0)
            {
                uctlAccountMain1.ui_contextmnuCommonEditAccount.Visible = false;
                uctlAccountMain1._isEditable = false;
            }
            else
            {
                uctlAccountMain1.ui_contextmnuCommonEditAccount.Visible = true;
                uctlAccountMain1._isEditable = true;
            }
            ncmbAccountGroup.Items.Add(clsGlobal.BrokerCompany);
            ncmbAccountGroup.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstParentCompanyNames.ToArray());//clsAccountManager.INSTANCE.GetParentBrokersForClient("All").ToArray());
            ncmdClientType.Items.AddRange(clsParticipantTypeManager.INSTANCE.GetParticipantTypeArray());
        }


        private void ui_ntxtClientId_TextChanged(object sender, EventArgs e)
        {
            if (ui_ntxtClientId.Text != string.Empty)
            {
                SearchParms[0] = ui_ntxtClientId.Text;
            }
            else
                SearchParms[0] = null;
            uctlAccountMain1.HandleSearch(SearchParms);
        }

        private void ui_ntxtClientName_TextChanged(object sender, EventArgs e)
        {
            if (ui_ntxtClientName.Text != string.Empty)
            {
                SearchParms[1] = ui_ntxtClientName.Text;
            }
            else
                SearchParms[1] = null;

            uctlAccountMain1.HandleSearch(SearchParms);
        }

        private void ncmbAccountGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncmbAccountGroup.Text == "All" && ncmdClientType.SelectedItem!=null &&ncmdClientType.SelectedItem.ToString() == "All")
            {
                uctlAccountMain1.Init();
                return;
            }
            else if (ncmbAccountGroup.Text == "All" && ncmdClientType.SelectedItem != null && ncmdClientType.SelectedItem.ToString() != "All")
            {
                SearchParms[3] = Convert.ToString(Cls.clsParticipantTypeManager.INSTANCE.GetParticipantTypeId(ncmdClientType.SelectedItem.ToString()));
                uctlAccountMain1.HandleSearch(SearchParms);
            }
            else
            {
                SearchParms[2] = Convert.ToString(clsAccountManager.INSTANCE.GetBrokerIDByCompanyName(ncmbAccountGroup.SelectedItem.ToString()));//Cls.clsAccountManager.INSTANCE.GetGroupId(ncmbAccountGroup.SelectedItem.ToString()));
                uctlAccountMain1.HandleSearch(SearchParms);
            }
        }

        private void ncmdClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncmbAccountGroup.Text == "All" && ncmdClientType.SelectedItem != null && ncmdClientType.SelectedItem.ToString() == "All")
            {
                uctlAccountMain1.Init();
                return;
            }
            SearchParms[3] = Convert.ToString(Cls.clsParticipantTypeManager.INSTANCE.GetParticipantTypeId(ncmdClientType.SelectedItem.ToString()));
            uctlAccountMain1.HandleSearch(SearchParms);
        }

        private void ui_ntxtClientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void FrmClient_Accounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }

        private void ui_ncmbBrokerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerType.SelectedItem != null)
            {
                if (ui_ncmbBrokerType.SelectedItem.ToString() != "All")
                {
                    uctlAccountMain1.HandleClientSearchData(ui_ncmbBrokerType.SelectedItem.ToString(), string.Empty);
                    return;
                }
                uctlAccountMain1.HandleSearch(SearchParms);
            }
        }

        private void ui_ncmbBrokerIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbBrokerIds.SelectedItem != null)
            {
                if (ui_ncmbBrokerIds.SelectedItem.ToString() != "All")
                {
                    uctlAccountMain1.HandleClientSearchData(string.Empty, ui_ncmbBrokerIds.SelectedItem.ToString());
                    return;
                }
                uctlAccountMain1.HandleSearch(SearchParms);
            }
        }

    }
}
