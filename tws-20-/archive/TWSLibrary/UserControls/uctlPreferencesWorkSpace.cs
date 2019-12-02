///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//16/01/2012	VP          1.Designing and Coding of form	 
//30/01/2012	VP		    1.Added methods SetValues and GetValues for setting and getting the values of controls
//01/02/2012	VP		    1.Defined functionality of Restore Default button
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlPreferencesWorkSpace : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "WorkSpace";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "      PROPERTY      "

        #region "        CONSTRUCTOR      "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public uctlPreferencesWorkSpace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlPreferencesWorkSpace(object customizeSettings)
        {
        }

        #endregion "     CONSTRUCTOR      "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.WorkSpace;

            ui_lblWorkSpaceStation.Text = ClsLocalizationHandler.WorkSpace + "/" +
                                          ClsLocalizationHandler.WorkStation;
            ui_lblDefaultWorkSpace.Text = ClsLocalizationHandler.SelectDefaultWorkSpace + " :";
            ui_nchkAutoLockWorkStation.Text = ClsLocalizationHandler.AutoLockWorkStation;
            ui_lblLockWorkStation.Text = ClsLocalizationHandler.LockWorkStation + " :";
            ui_lblMinutes.Text = ClsLocalizationHandler.Minutes;
            ui_nchkTimeWithSecond.Text = ClsLocalizationHandler.TimeWithSeconds;
            ui_lblColumnProfile.Text = ClsLocalizationHandler.ColumnProfile;
            ui_lblOpenViewsWith.Text = ClsLocalizationHandler.OpenAllViewsWith + "...";
            ui_lblMinutes.Text = ClsLocalizationHandler.Minutes;
            ui_nrbtnAllColumns.Text = ClsLocalizationHandler.AllColumns;
            ui_nrbtnDefaultProfile.Text = ClsLocalizationHandler.DefaultProfile;
            ui_nrbtnLastUsed.Text = ClsLocalizationHandler.LastUsed;
            ui_nbtnRestoreDefault.Text = ClsLocalizationHandler.RestoreDefaults;
        }

        /// <summary>
        /// Provides the current value of controls
        /// </summary>
        /// <returns>Workspace settings</returns>
        public ClsWorkSpace GetValues()
        {
            var objclsWorkSpace = new ClsWorkSpace();
            objclsWorkSpace.DefaultWorkSpace = ui_nflkpDefaultWorkSpace.Text;
            objclsWorkSpace.IsLockWorkStation = ui_nchkAutoLockWorkStation.Checked;
            objclsWorkSpace.LockWorkStationTime = int.Parse(ui_ntxtLockWorkStationTime.Text);
            objclsWorkSpace.IsLockTimeInSeconds = ui_nchkTimeWithSecond.Checked;
            objclsWorkSpace.IsShowDateTime = ui_nchkShowDateTime.Checked;
            objclsWorkSpace.OpenAllViewsWith = GetCheckedItemText();

            return objclsWorkSpace;
        }

        /// <summary>
        /// Provides the checked items 
        /// </summary>
        /// <returns>Selected checkbox name</returns>
        public string GetCheckedItemText()
        {
            string chkString = string.Empty;

            if (ui_nrbtnAllColumns.Checked)
                chkString = ui_nrbtnAllColumns.Name;
            if (ui_nrbtnDefaultProfile.Checked)
                chkString = ui_nrbtnDefaultProfile.Name;
            if (ui_nrbtnLastUsed.Checked)
                chkString = ui_nrbtnLastUsed.Name;

            return chkString;
        }

        /// <summary>
        /// Sets stored values to the controls
        /// </summary>
        /// <param name="workspaceSettings">Sotred settings</param>
        public void SetValues(ClsWorkSpace workspaceSettings)
        {
            ui_nflkpDefaultWorkSpace.Text = workspaceSettings.DefaultWorkSpace;
            ui_nchkAutoLockWorkStation.Checked = workspaceSettings.IsLockWorkStation;
            ui_nchkTimeWithSecond.Checked = workspaceSettings.IsLockTimeInSeconds;
            ui_ntxtLockWorkStationTime.Text = workspaceSettings.LockWorkStationTime.ToString();
            ui_nchkShowDateTime.Checked = workspaceSettings.IsShowDateTime;
            SetCheckeItem(workspaceSettings.OpenAllViewsWith);
        }

        /// <summary>
        /// Checks the specified checkbox
        /// </summary>
        /// <param name="rbtnName">checkbox name</param>
        public void SetCheckeItem(string rbtnName)
        {
            if (rbtnName == ui_nrbtnAllColumns.Name)
                ui_nrbtnAllColumns.Checked = true;
            if (rbtnName == ui_nrbtnDefaultProfile.Name)
                ui_nrbtnDefaultProfile.Checked = true;
            if (rbtnName == ui_nrbtnLastUsed.Name)
                ui_nrbtnLastUsed.Checked = true;
        }

        /// <summary>
        /// Restore defaults settings to controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            ui_nflkpDefaultWorkSpace.Text = "";
            ui_nchkAutoLockWorkStation.Checked = false;
            ui_nchkTimeWithSecond.Checked = false;
            ui_ntxtLockWorkStationTime.Text = "";
            ui_nchkShowDateTime.Checked = false;
            ui_nrbtnAllColumns.Checked = true;
        }

        #endregion "      METHODS       "
    }
}