//<Revision History>

//Date : 02/01/2012
//Author Name : Vijay Prakash Singh
//Description : Added naming conventions comment to properties and methods

//</Revision History>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using CommonLibrary.UserControls;

namespace CommonLibrary.UserControls
{
    public partial class uctlAlertDialog : uctlBase
    {
        #region    "      MEMBERS       "

        string _title = "Alert Editor";


        public bool IsEnabled
        {
            get { return ui_nchkEnable.Checked; }
            set { ui_nchkEnable.Checked = value; }
        }

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

       

        /// <summary>
        /// This property indicates the sound enablility. This property is both settable and gettable.
        /// </summary>
        public string Action
        {
            get
            {
                return ui_ncmbAction.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbAction.SelectedItem = value;
            }
        }

        /// <summary>
        /// This property specifies the symbol to which alert is applied. This property is both settable and gettable.
        /// </summary>
        public string Symbol
        {
            get
            {
                return ui_ncmbSymbol.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbSymbol.SelectedItem = value;
            }
        }

        /// <summary>
        /// This property specifies the source sound. This property is both settable and gettable.
        /// </summary>
        public string Source
        {
            get
            {
                return ui_ncmbSource.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbSource.SelectedItem = value;
            }
        }

        /// <summary>
        /// This property indicates the duration for alert. This property is both settable and gettable.
        /// </summary>
        public string TimeOut
        {
            get
            {
                return ui_ncmbTimeout.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbTimeout.SelectedItem = value;
            }
        }

        /// <summary>
        /// This property specifies condition. This property is both settable and gettable.
        /// </summary>
        public string Condition
        {
            get
            {
                return ui_ncmbCondition.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbCondition.SelectedItem = value;
            }
        }

        /// <summary>
        /// This property specifies the price used with condition. This property is both settable and gettable.
        /// </summary>
        public string Price
        {
            get
            {
                return ui_ntxtPrice.Text;
            }
            set
            {
                ui_ntxtPrice.Text = value;
            }
        }

        /// <summary>
        /// This property indicates no of times the alert is occurs. This property is both settable and gettable.
        /// </summary>
        public string MaximunIteration
        {
            get
            {
                return ui_ncmbMaximumIteration.SelectedItem.ToString();
            }
            set
            {
                ui_ncmbMaximumIteration.SelectedItem = value;
            }
        }

        #endregion "      PROPERTY      "

        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public uctlAlertDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlAlertDialog(object customizeSettings)
        {

        }
        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = Cls.clsLocalizationHandler.Alert + " " + Cls.clsLocalizationHandler.Editor;

            ui_lblAction.Text = Cls.clsLocalizationHandler.Action + " :";
            ui_lblSymbol.Text = Cls.clsLocalizationHandler.Symbol + " :";
            ui_lblSource.Text = Cls.clsLocalizationHandler.Source+ " :";
            ui_lblTimeOut.Text = Cls.clsLocalizationHandler.Timeout + " :";
            ui_lblCondition.Text = Cls.clsLocalizationHandler.Condition + " :";
            ui_lblPrice.Text = Cls.clsLocalizationHandler.Price + " :";
            ui_lblMaximumIteration.Text = Cls.clsLocalizationHandler.Maximum+" "+Cls.clsLocalizationHandler.Iteration + " :";
            ui_nbtnOk.Text = Cls.clsLocalizationHandler.Ok;
            ui_nbtnCancel.Text = Cls.clsLocalizationHandler.Cancel;
            ui_nbtnTest.Text = Cls.clsLocalizationHandler.Test;
        }

        #endregion "      METHODS       "

        public event Action<object, EventArgs> OnOkClick;
        public event Action<object, EventArgs> OnCancelClick;
        public event Action<object, EventArgs> OnTestClick;
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            OnOkClick(sender,e);
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        private void ui_npnlAlertDialogContainer_Click(object sender, EventArgs e)
        {
            
        }

        private void ui_nbtnTest_Click(object sender, EventArgs e)
        {
            OnTestClick(sender, e);
        }
        
    }
}
