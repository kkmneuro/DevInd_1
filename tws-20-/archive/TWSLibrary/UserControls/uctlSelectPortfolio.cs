using System;
using System.Collections.Generic;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlSelectPortfolio : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly object obj;
        public Dictionary<string, ClsPortfolio> _portfolios;
        private string _title = "Select Portfolio";
        private string selectedPortfolio = string.Empty;

        public string SelectedPortfolio
        {
            get { return selectedPortfolio; }
            set { selectedPortfolio = value; }
        }

        #endregion "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// Sets and gets the title of the uctlSelectPortfolio control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initializing the components of the uctlSelectPortfolio 
        /// </summary>
        public UctlSelectPortfolio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initializing the components of the uctlSelectPortfolio with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlSelectPortfolio(object customizeSettings)
        {
            InitializeComponent();
            obj = customizeSettings;
        }

        #endregion "    CONSTRUCTOR     "

        #region    "        METHODS           "

        /// <summary>
        /// Sets the text of the controls of the uctlSelectPortfolio user control according to corresponding localization value
        /// </summary>
        public override void SetLocalization()
        {
            _title = ClsLocalizationHandler.Select + " " + ClsLocalizationHandler.Portfolio;

            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
            ui_nbtnModify.Text = ClsLocalizationHandler.Modify;
            ui_nbtnRemove.Text = ClsLocalizationHandler.Remove;
            //ui_lblSelectProtfolioMessage.Text = Cls.clsLocalizationHandler.SelectPortfolioMessage;
        }

        /// <summary>
        /// Tasks performed on the control loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlSelectPortfolio_Load(object sender, EventArgs e)
        {
            _portfolios = (Dictionary<string, ClsPortfolio>) obj;
            if (_portfolios != null)
            {
                foreach (string key in _portfolios.Keys)
                {
                    ui_nlbSelectPortfolio.Items.Add(key);
                }
            }
            if (SelectedPortfolio != string.Empty)
            {
                ui_nlbSelectPortfolio.SelectedIndex = ui_nlbSelectPortfolio.Items.IndexOf(SelectedPortfolio);
            }
        }

        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            OnApplyClick(ui_nlbSelectPortfolio.SelectedItem.ToString());
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }


        private void ui_nbtnModify_Click(object sender, EventArgs e)
        {
            if (ui_nlbSelectPortfolio.SelectedItem != null)
            {
                OnModifyClick(ui_nlbSelectPortfolio.SelectedItem.ToString());
            }
        }

        private void ui_nbtnRemove_Click(object sender, EventArgs e)
        {
            if (ui_nlbSelectPortfolio.SelectedItem != null)
            {
                string item = ui_nlbSelectPortfolio.SelectedItem.ToString();
                OnRemoveClick(item);
                ui_nlbSelectPortfolio.Items.RemoveAt(ui_nlbSelectPortfolio.Items.IndexOf(item));
            }
        }

        #endregion   "        METHODS          "

        #region    "         EVENTS           "

        public event Action<string> OnApplyClick = delegate { };
        public event Action<object, EventArgs> OnCancelClick = delegate { };
        public event Action<string> OnModifyClick = delegate { };
        public event Action<string> OnRemoveClick = delegate { };

        #endregion "         EVENTS           "

        private void ui_nlbSelectPortfolio_DoubleClick(object sender, EventArgs e)
        {
            if (ui_nlbSelectPortfolio.SelectedItem != null)
            {
                OnApplyClick(ui_nlbSelectPortfolio.SelectedItem.ToString());
            }
        }

        private void ui_nlbSelectPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_nlbSelectPortfolio.SelectedItem != null)
            {
                ui_nbtnApply.Enabled = true;
                ui_nbtnModify.Enabled = true;
                ui_nbtnRemove.Enabled = true;
            }
        }
    }
}