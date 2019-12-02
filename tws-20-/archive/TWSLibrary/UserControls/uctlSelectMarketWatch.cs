using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlSelectMarketWatch : UctlBase
    {

        #region    "        MEMBERS           "        
        public List<string> _lstMW;
        private string _title = "Select Portfolio";
        private string selectedMW = string.Empty;

        public string SelectedMW
        {
            get { return selectedMW; }
            set { selectedMW = value; }
        }


        #endregion "        MEMBERS           "
        
        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlSelectPortfolio 
        /// </summary>        
        public uctlSelectMarketWatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initializing the components of the uctlSelectPortfolio with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public uctlSelectMarketWatch(List<string> customizeSettings)
        {
            InitializeComponent();
            _lstMW = customizeSettings;
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "


        private void ui_nlbSelectMW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_nlbSelectMW.SelectedItem != null)
            {
                ui_nbtnApply.Enabled = true;
                ui_nbtnRemove.Enabled = true;
            }

        }

        private void ui_nlbSelectMW_DoubleClick(object sender, EventArgs e)
        {
            if (ui_nlbSelectMW.SelectedItem != null)
            {
                OnApplyClick(ui_nlbSelectMW.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// Sets the text of the controls of the uctlSelectPortfolio user control according to corresponding localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Select + " " + ClsLocalizationHandler.Portfolio;

            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
            ui_nbtnRemove.Text = ClsLocalizationHandler.Remove;
            //ui_lblSelectProtfolioMessage.Text = Cls.clsLocalizationHandler.SelectPortfolioMessage;
        }

        /// <summary>
        /// Tasks performed on the control loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void uctlSelectMarketWatch_Load(object sender, EventArgs e)
        {            
            if (_lstMW != null)
            {
                foreach (string key in _lstMW)
                {
                    ui_nlbSelectMW.Items.Add(key);
                }
            }
            if (SelectedMW != string.Empty)
            {
                ui_nlbSelectMW.SelectedIndex = ui_nlbSelectMW.Items.IndexOf(SelectedMW);
            }
        }
        
        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            OnApplyClick(ui_nlbSelectMW.SelectedItem.ToString());
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }
        
        private void ui_nbtnRemove_Click(object sender, EventArgs e)
        {
            if (ui_nlbSelectMW.SelectedItem != null)
            {
                string item = ui_nlbSelectMW.SelectedItem.ToString();
                OnRemoveClick(item);
                ui_nlbSelectMW.Items.RemoveAt(ui_nlbSelectMW.Items.IndexOf(item));
            }
        }

        #endregion   "        METHODS          "

        #region    "         EVENTS           "

        public event Action<string> OnApplyClick = delegate { };
        public event Action<object, EventArgs> OnCancelClick = delegate { };
        public event Action<string> OnRemoveClick = delegate { };

        #endregion "         EVENTS           "


    }
}
