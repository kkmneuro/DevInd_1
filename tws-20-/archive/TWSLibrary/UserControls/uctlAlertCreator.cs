///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//02/01/2012	VP		    1.Added naming conventions comment to properties and methods
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlAlertCreator : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Alert Creator";

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

        public bool IsAlertEnabled
        {
            get { return ui_nchkEnable.Checked; }
            set { ui_nchkEnable.Checked = value; }
        }


        /// <summary>
        /// This property indicates the sound enablility. This property is both settable and gettable.
        /// </summary>
        public string Action
        {
            get { return ui_ncmbAction.SelectedItem.ToString(); }
            set { ui_ncmbAction.SelectedItem = value; }
        }

        /// <summary>
        /// This property specifies the symbol to which alert is applied. This property is both settable and gettable.
        /// </summary>
        public string Symbol
        {
            get { return ui_ncmbSymbol.SelectedItem.ToString(); }
            set { ui_ncmbSymbol.SelectedItem = value; }
        }

        /// <summary>
        /// This property specifies the source sound. This property is both settable and gettable.
        /// </summary>
        public string Source
        {
            get { return ui_ncmbSource.SelectedItem.ToString(); }
            set { ui_ncmbSource.SelectedItem = value; }
        }

        /// <summary>
        /// This property indicates the duration for alert. This property is both settable and gettable.
        /// </summary>
        public string TimeOut
        {
            get { return ui_ncmbTimeout.SelectedItem.ToString(); }
            set { ui_ncmbTimeout.SelectedItem = value; }
        }

        /// <summary>
        /// This property specifies condition. This property is both settable and gettable.
        /// </summary>
        public string Condition
        {
            get { return ui_ncmbCondition.SelectedItem.ToString(); }
            set { ui_ncmbCondition.SelectedItem = value; }
        }

        /// <summary>
        /// This property specifies the price used with condition. This property is both settable and gettable.
        /// </summary>
        public string Price
        {
            get { return ui_ntxtPrice.Text; }
            set { ui_ntxtPrice.Text = value; }
        }

        /// <summary>
        /// This property indicates no of times the alert is occurs. This property is both settable and gettable.
        /// </summary>
        public string MaximunIteration
        {
            get { return ui_ncmbMaximumIteration.SelectedItem.ToString(); }
            set { ui_ncmbMaximumIteration.SelectedItem = value; }
        }

        #endregion "      PROPERTY      "

        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlAlertCreator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlAlertCreator(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Alert + " " + ClsLocalizationHandler.Create;

            ui_lblAction.Text = ClsLocalizationHandler.Action + " :";
            ui_lblSymbol.Text = ClsLocalizationHandler.Symbol + " :";
            ui_lblSource.Text = ClsLocalizationHandler.Source + " :";
            ui_lblTimeOut.Text = ClsLocalizationHandler.Timeout + " :";
            ui_lblCondition.Text = ClsLocalizationHandler.Condition + " :";
            ui_lblPrice.Text = ClsLocalizationHandler.Price + " :";
            ui_lblMaximumIteration.Text = ClsLocalizationHandler.Maximum + " " +
                                          ClsLocalizationHandler.Iteration + " :";
            ui_nbtnOk.Text = ClsLocalizationHandler.Ok;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
            ui_nbtnTest.Text = ClsLocalizationHandler.Test;
        }

        #endregion "      METHODS       "

        public event Action<object, EventArgs> OnOkClick;
        public event Action<object, EventArgs> OnCancelClick;
        public event Action<object, EventArgs> OnTestClick;

        /// <summary>
        /// Invokes OnOkClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            OnOkClick(sender, e);
        }

        /// <summary>
        /// Invokes OnCancelClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_npnlAlertDialogContainer_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Invokes OnTestClick click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnTest_Click(object sender, EventArgs e)
        {
            OnTestClick(sender, e);
        }

        private void ui_ntxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_ntxtPrice.Text, e, TextType.Real, 50, 1);
        }
    }
}