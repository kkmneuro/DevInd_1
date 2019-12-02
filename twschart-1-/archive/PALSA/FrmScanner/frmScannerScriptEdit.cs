using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
//using M4.Scripts;
//using FundXchange.Infrastructure;

namespace PALSA.FrmScanner
{
    public partial class frmScannerScriptEdit : NForm
    {
        #region Variables
        private string msg = string.Empty;
        #endregion Variables
        #region Properties
        /// <summary>
        /// Contains scripts which has to be changed.
        /// </summary>
        private List<string> _scripts;
        public List<string> Scripts
        {
            get { return _scripts; }
            set { _scripts = value; }
        }
        /// <summary>
        /// Contains the name of the scipts which has to be changed.
        /// </summary>
        private List<string> _scriptNames;
        public List<string> ScriptNames
        {
            get { return _scriptNames; }
            set { _scriptNames = value; }
        }
        #endregion Properties
        #region Methods
        /// <summary>
        /// constructor
        /// </summary>
        public frmScannerScriptEdit()
        {
            InitializeComponent();
            _scripts = new List<string>();
            _scriptNames = new List<string>();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _scriptNames.Clear();
                _scripts.Clear();
                for (int i = 0; i < tabcrtl.TabPages.Count; i++)
                {
                    _scriptNames.Add(tabcrtl.TabPages[i].Text);
                    _scripts.Add(tabcrtl.TabPages[i].Controls[0].Text);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(msg, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        /// <summary>
        /// To check syntax of scripts are valid or not.
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            //Kul
            //for (int i = 0; i < tabcrtl.TabPages.Count; i++)
            //{
            //    ScriptValidationService validationService = IoC.Resolve<ScriptValidationService>();
            //    if (!validationService.IsValid(tabcrtl.TabPages[i].Controls[0].Text))
            //    {
            //        msg = validationService.GetValidationResult(tabcrtl.TabPages[i].Controls[0].Text);
            //        return false;
            //    }

            //} 
            return true;
        }
        /// <summary>
        /// Load scripts for editing
        /// </summary>
        private void LoadScript()
        {
            for (int i = 0; i < _scriptNames.Count; i++)
            {
                NTabPage tabPage = new NTabPage();
                tabPage.Text = _scriptNames[i];
                NTextBox txtScripts = new NTextBox();
                txtScripts.Multiline = true;
                txtScripts.Dock = DockStyle.Fill;
                txtScripts.Text = _scripts[i];
                tabPage.Controls.Add(txtScripts);
                tabcrtl.Controls.Add(tabPage);
            }
        }
        private void frmScannerScriptEdit_Load(object sender, EventArgs e)
        {
            LoadScript();
        }
        #endregion Methods

    }
}
