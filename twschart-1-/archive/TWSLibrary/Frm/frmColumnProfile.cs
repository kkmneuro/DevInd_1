///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//03/02/2012	VP		    1.Control desgining and naming of controls.
//                          2.Coding and code commenting
//16/02/2012    VK          1.Adding Functionalty for saving profile
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// Code for ColumnProfile
    /// </summary>
    public partial class FrmColumnProfile : NForm
    {
        #region    "     MEMBERS     "

        private readonly string _profiletype;
        //private Dictionary<string, string> DDColumns = new Dictionary<string, string>();
        public Dictionary<string, ClsProfile> DDProfile;
        private string _currentProfileName;

        #endregion "     MEMBERS     "

        #region    "     PROPERTIES     "

        #endregion "     PROPERTIES     "

        #region    "     CONSTRUCTORS     "

        public FrmColumnProfile(ProfileTypes profiletype, object profiles, string _CurrentProfile)
        {
            DDProfile = profiles as Dictionary<string, ClsProfile>;
            if (DDProfile == null) //by vijay
                DDProfile = new Dictionary<string, ClsProfile>(); //by vijay
            _currentProfileName = _CurrentProfile;
            _profiletype = profiletype.ToString();
            InitializeComponent();
        }

        #endregion "     CONSTRUCTORS     "

        #region    "     METHODS     "

        /// <summary>
        /// Adds item to the ui_nlstColumns list
        /// </summary>
        /// <param name="grid">Called control datagrid</param>
        public void AddItemsToList(UctlGrid grid)
        {
            foreach (DataGridViewColumn item in grid.Columns)
            {
                ui_nlstColumns.Items.Add(item.HeaderText);

                if (item.Visible)
                {
                    ui_nlstColumns.Items[item.HeaderText].Checked = true;
                }
            }
        }

        /// <summary>
        /// Tasks to be performed when form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmColumnProfile_Load(object sender, EventArgs e)
        {
            if (DDProfile != null && _profiletype != string.Empty)
            {
                foreach (string key in DDProfile.Keys)
                {
                    if (key.Contains(_profiletype))
                    {
                        ui_ncmbColumnProfile.Items.Add(key.Split('_')[0]);
                    }
                }
            }
            if (_currentProfileName == string.Empty)
            {
                ui_ncmbColumnProfile.SelectedIndex = 0;
            }
            else
            {
                ui_ncmbColumnProfile.Text = _currentProfileName;
            }
        }

        /// <summary>
        /// Moves the selected item in the ui_nlstColumns list one place up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnMoveUp_Click(object sender, EventArgs e)
        {
            if (ui_nlstColumns.SelectedIndex > 0)
            {
                var item = (NListBoxItem) ui_nlstColumns.SelectedItem;
                int index = ui_nlstColumns.SelectedIndex;
                ui_nlstColumns.Items.RemoveAt(index);
                ui_nlstColumns.Items.Insert(index - 1, item);
                ui_nlstColumns.SelectedIndex = index - 1; //change by vijay
            }
        }

        /// <summary>
        /// Moves the selected item in the ui_nlstColumns list one place down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnMoveDown_Click(object sender, EventArgs e)
        {
            if (ui_nlstColumns.SelectedIndex != -1 && ui_nlstColumns.SelectedIndex < ui_nlstColumns.Items.Count - 1)
            {
                var item = (NListBoxItem) ui_nlstColumns.SelectedItem;
                int index = ui_nlstColumns.SelectedIndex;
                ui_nlstColumns.Items.RemoveAt(index);
                ui_nlstColumns.Items.Insert(index + 1, item);
                ui_nlstColumns.SelectedIndex = index + 1;
            }
            else
            {
                MessageBox.Show("Please select the column!!!");
            }
        }

        /// <summary>
        /// Chcked the selected items in the ui_nlstColumns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnShow_Click(object sender, EventArgs e)
        {
            foreach (NListBoxItem item in ui_nlstColumns.SelectedItems)
            {
                item.Checked = true;
            }
        }

        /// <summary>
        /// Unchcked the selected items in the ui_nlstColumns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uui_nbtnHide_Click(object sender, EventArgs e)
        {
            foreach (NListBoxItem item in ui_nlstColumns.SelectedItems)
            {
                item.Checked = false;
            }
        }

        /// <summary>
        /// Applys selected column profile to the invoked control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            //MessageBox code by vijay
            if (ui_ncmbColumnProfile.Text == "" || ui_ncmbColumnProfile.Text == "--SELECT--")
            {
                MessageBox.Show("Please Specify Profile Name");
                return;
            }
            TopMost = false;
            string message = "Do you want to save the column profile or just apply it?" +
                             Environment.NewLine +
                             "Press *Yes* for Saving and Applying this column profile." +
                             Environment.NewLine +
                             "Press *No* for just Applying this column profile." +
                             Environment.NewLine +
                             "Press *Cancel* to return to column profile settings.";
            DialogResult result = MessageBox.Show(message, "LTech India", MessageBoxButtons.YesNoCancel);
                //ClsCommonMethods.ShowExitMessageBox(message);
            //DialogResult result = MessageBox.Show("Do you wish to save the column profile or just apply it?" + Environment.NewLine + "Press *Yes* for saveing and applying this column profile." + Environment.NewLine + "Press *No* for just applying this column profile." + Environment.NewLine + "Press *Cancel* to return to column profile settings.", "", MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        ui_nbtnSave_Click(sender, e);
                        ApplyProfile();
                        Close();
                        break;
                    }
                case DialogResult.No:
                    {
                        ApplyProfile();
                        Close();
                        break;
                    }
                case DialogResult.Cancel:
                    TopMost = true;
                    break;
                default:
                    TopMost = true;
                    break;
            }
        }

        private void ApplyProfile()
        {
            _currentProfileName = ui_ncmbColumnProfile.Text;
            OnOkClick(DDProfile, _currentProfileName);
        }

        private void SaveProfile(Dictionary<string, ClsProfile> dictionary)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Checks all items of ui_nlstColumns listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nchkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_nchkSelectAll.Checked)
            {
                foreach (NListBoxItem item in ui_nlstColumns.Items)
                {
                    item.Checked = true;
                }
            }
        }

        #endregion "     METHODS     "

        #region    "     EVENTS     "

        public event Action<object, string> OnOkClick = delegate { };
        public event Action<object, string> OnProfileSaveClick = delegate { };
        public event Action<object, string> OnProfileRemoveClick = delegate { };
        public event Action<object, string> OnSetDefaultProfileClick = delegate { };

        #endregion "     EVENTS     "

        private void ui_nbtnSave_Click(object sender, EventArgs e)
        {
            if (ui_ncmbColumnProfile.Text == "" || ui_ncmbColumnProfile.Text == "--SELECT--")
            {
                ClsCommonMethods.ShowErrorBox("Please Specify Profile Name");
                ui_ncmbColumnProfile.Focus();
                return;
            }
            var objProfiles = new ClsProfile();
            _currentProfileName = ui_ncmbColumnProfile.Text;
            if (!ui_ncmbColumnProfile.Items.Contains(ui_ncmbColumnProfile.Text))
            {
                ui_ncmbColumnProfile.Items.Add(ui_ncmbColumnProfile.Text);
            }
            objProfiles.ProfileName = ui_ncmbColumnProfile.Text;

            objProfiles.ProfileType = (ProfileTypes) Enum.Parse(typeof (ProfileTypes), _profiletype);
            string profileKey = objProfiles.ProfileName + "_" + _profiletype;
            foreach (NListBoxItem item in ui_nlstColumns.Items)
            {
                var objcolumnSetting = new ClsColumnSetting(ui_nlstColumns.Items.IndexOf(item),
                                                            item.Checked, item.Text);
                objProfiles.DDColumnSetting.Add(item.Text, objcolumnSetting);
            }

            if (DDProfile == null)
                DDProfile = new Dictionary<string, ClsProfile>();
            if (!DDProfile.ContainsKey(profileKey))
                DDProfile.Add(profileKey, objProfiles);
            else
                DDProfile[profileKey] = objProfiles;
            OnProfileSaveClick(DDProfile, ui_ncmbColumnProfile.Text);
        }

        private void ui_nbtnRemove_Click(object sender, EventArgs e)
        {
            string profileKey = ui_ncmbColumnProfile.Text + "_" + _profiletype;
            if (DDProfile.ContainsKey(profileKey))
            {
                DDProfile.Remove(profileKey);
                ui_ncmbColumnProfile.Items.Remove(ui_ncmbColumnProfile.Text);
                ui_ncmbColumnProfile.Text = "";
            }
            OnProfileRemoveClick(DDProfile, ui_ncmbColumnProfile.Text);
        }

        private void ui_nbtnSetDefaultProfile_Click(object sender, EventArgs e)
        {
            if (ui_ncmbColumnProfile.Text == "" || ui_ncmbColumnProfile.Text == "--SELECT--")
            {
                ClsCommonMethods.ShowErrorBox("Please Select a profile");
                ui_ncmbColumnProfile.Focus();
                return;
            }

            var objProfiles = new ClsProfile();
            _currentProfileName = ui_ncmbColumnProfile.Text;

            ui_ncmbColumnProfile.Items.Add(ui_ncmbColumnProfile.Text);
            objProfiles.ProfileName = ui_ncmbColumnProfile.Text;

            objProfiles.ProfileType = (ProfileTypes) Enum.Parse(typeof (ProfileTypes), _profiletype);
            string profileKey = objProfiles.ProfileName + "_" + _profiletype;
            foreach (NListBoxItem item in ui_nlstColumns.Items)
            {
                var objcolumnSetting = new ClsColumnSetting(ui_nlstColumns.Items.IndexOf(item),
                                                            item.Checked, item.Text);
                objProfiles.DDColumnSetting.Add(item.Text, objcolumnSetting);
            }

            if (DDProfile == null)
                DDProfile = new Dictionary<string, ClsProfile>();
            if (!DDProfile.ContainsKey(profileKey))
                DDProfile.Add(profileKey, objProfiles);
            else
                DDProfile[profileKey] = objProfiles;
            OnSetDefaultProfileClick(DDProfile, ui_ncmbColumnProfile.Text);
        }

        private void ui_ncmbColumnProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbColumnProfile.SelectedIndex > 0)
            {
                _currentProfileName = ui_ncmbColumnProfile.SelectedItem.ToString();
                ClsProfile profile = DDProfile[_currentProfileName + "_" + _profiletype];

                var Tempnlist = new NListBox();
                foreach (NListBoxItem item in ui_nlstColumns.Items)
                {
                    Tempnlist.Items.Add(item);
                }
                foreach (NListBoxItem item in Tempnlist.Items)
                {
                    ClsColumnSetting colsetting = null;
                    if (profile.DDColumnSetting.TryGetValue(item.Text, out colsetting) && colsetting != null)
                    {
                        item.Checked = colsetting.Visible;
                        ui_nlstColumns.Items.SetIndex(item.Index, colsetting.Index);
                    }
                }
                foreach (object item in ui_nlstColumns.Items)
                {
                    Tempnlist.Items.Add(item);
                }
            }
        }

        private void ui_nlstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ui_nlstColumns.SelectedItems.Count == 1)
            //{
            //if (((Nevron.UI.WinForm.Controls.NListBoxItem)(((System.Windows.Forms.ListBox)(sender)).SelectedItem)).Checked)
            //{
            //    ((Nevron.UI.WinForm.Controls.NListBoxItem)(((System.Windows.Forms.ListBox)(sender)).SelectedItem)).Checked = false;
            //}
            //else
            //{
            //    ((Nevron.UI.WinForm.Controls.NListBoxItem)(((System.Windows.Forms.ListBox)(sender)).SelectedItem)).Checked = true;
            //}
            //}
        }
    }
}