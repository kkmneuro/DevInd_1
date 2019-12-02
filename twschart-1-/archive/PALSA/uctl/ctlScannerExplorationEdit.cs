using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using FundXchange.Model.ViewModels.Charts;
using Nevron.UI.WinForm.Controls;
using System.IO;
using System.Media;
using PALSA.Cls;

namespace PALSA.uctl
{
    /// <summary>
    /// Enum gives the scripts status that script and column name are properly filled or not.
    /// </summary>
    public enum ScriptStatus
    {
        FullyOK = 1,
        PartiallyOK = 2,
        NotOK = 3
    }

    public partial class ctlScannerExplorationEdit : UserControl
    {
        #region Variables

        private ScriptStatus _status = ScriptStatus.NotOK;
        
        #endregion Variables
        #region Properties
        private string _soundPath = Application.StartupPath + "\\Resx\\Alert.wav";
        public string SoundPath
        {
            get { return _soundPath; }
            set { _soundPath = value; }
        }
        public string ScriptType
        {
            get
            {
                if (rbBuy.Checked)
                { return rbBuy.Text; }
                else
                    return rbSell.Text;
            }
            set
            {
                if (value == "Buy")
                    rbBuy.Checked = true;
                else
                    rbSell.Checked = true;
            }
        }
        public int Bars
        {
            get
            {
                return Convert.ToInt32(nudBarCount.Value);
            }
            set
            {
                if (value < 3)
                    value = 3;
                nudBarCount.Value = value;
            }
        }

        public int Interval
        {
            get
            {
                return Convert.ToInt32(cboInterval.Text);
            }
            set
            {
                int itemIndex = FindIntervalIndex(value);
                cboInterval.SelectedIndex = itemIndex;
            }
        }

        public Periodicity Periodicity
        {
            get
            {
                return GetPeriodicity();
            }
            set
            {
                SetPeriodicity(value);
            }
        }
        /// <summary>
        /// Get and set status of scripts
        /// </summary>
        public ScriptStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Get and set Script name of scripts
        /// </summary>
        public string ColumnName
        {
            get
            {
                return txtColumnName.Text;
            }
            set
            {
                txtColumnName.Text = value;
            }

        }
        /// <summary>
        /// Get and set scripts
        /// </summary>
        public string Script
        {
            get
            {
                return txtScript.Text;
            }
            set
            {
                txtScript.Text = value;
            }

        }
       
        #endregion Properties
        #region Events and delegates

        public delegate void TextLeave(object sender, EventArgs e);
        public event TextLeave TextLeaveEvent;
        
        #endregion Events and delegates
        
        #region Methods
        /// <summary>
        /// Get the Periodicity
        /// </summary>
        /// <returns>Returns Periodicity enum</returns>
        private Periodicity GetPeriodicity()
        {
            switch (cboPeriodicity.Text)
            {
                case "Second":
                    return Periodicity.Secondly;
                case "Hour":
                    return Periodicity.Hourly;
                case "Day":
                    return Periodicity.Daily;
                case "Week":
                    return Periodicity.Weekly;
                case "Month":
                    return Periodicity.Monthly;
                default:
                    return Periodicity.Minutely;
            }
        }

        private string GetPeriodicity(Periodicity periodicity)
        {
            switch (periodicity)
            {
                case Periodicity.Secondly:
                    return "Second";
                case Periodicity.Hourly:
                    return "Hour";
                case Periodicity.Daily:
                    return "Day";
                case Periodicity.Weekly:
                    return "Week";
                case Periodicity.Monthly:
                    return "Month";
                default:
                    return "Minute";
            }
        }

        private void SetPeriodicity(Periodicity periodicity)
        {
            string valueToFind = GetPeriodicity(periodicity);

            for (int n = 0; n <= cboPeriodicity.Items.Count - 1; n++)
            {
                if (cboPeriodicity.Items[n].Text == valueToFind)
                {
                    cboPeriodicity.SelectedIndex = n;
                    break;
                }
            }
        }
        private int FindIntervalIndex(int value)
        {
            foreach (NListBoxItem item in cboInterval.Items)
            {
                if (int.Parse(item.Text) == value)
                    return cboInterval.Items.IndexOf(item);
            }
            return 0;
        }

        
        /// <summary>
        /// constructor
        /// </summary>
        public ctlScannerExplorationEdit()
        {
            InitializeComponent();
            cboInterval.SelectedIndex = 0;
            cboPeriodicity.SelectedIndex = 0;
        }
        private void txtColumnName_Leave(object sender, EventArgs e)
        {
            if (txtColumnName.Text == string.Empty)
            {
                _status = ScriptStatus.NotOK;
                
            }
            else if (txtColumnName.Text != string.Empty && txtScript.Text == string.Empty)
            {
                _status = ScriptStatus.PartiallyOK;
                
            }
            else
            {
                _status = ScriptStatus.FullyOK;
                
            }
            TextLeaveEvent(this, e);

        }
        public void EnableControl(bool enable)
        {
            if (!enable)
            {
                lblColumnName.Enabled = false;
                rbBuy.Enabled = false;
                rbSell.Enabled = false;
                txtColumnName.Enabled = false;
                txtScript.Enabled = false;
                Label6.Enabled = false;
                Label7.Enabled = false;
                Label8.Enabled = false;
                cboInterval.Enabled = false;
                cboPeriodicity.Enabled = false;
                nudBarCount.Enabled = false;
                btnSound.Enabled = false;
            }
            else
            {
                lblColumnName.Enabled = false;
                rbBuy.Enabled = false;
                rbSell.Enabled = false;
                txtColumnName.Enabled = false;
                txtScript.Enabled = false;
                Label6.Enabled = false;
                Label7.Enabled = false;
                Label8.Enabled = false;
                cboInterval.Enabled = false;
                cboPeriodicity.Enabled = false;
                nudBarCount.Enabled = false;
                btnSound.Enabled = true;
            }
            
        }
        private void txtScript_Enter(object sender, EventArgs e)
        {
            if (txtColumnName.Text == string.Empty)
            { _status = ScriptStatus.NotOK;
            
                MessageBox.Show("Please enter the coloumn Name");
                txtColumnName.Focus();
               
            }
            else
            {
                _status = ScriptStatus.PartiallyOK;
                
            }
        }
        private void txtScript_TextChanged(object sender, EventArgs e)
        {
            string c = null;
            int value = 0;
            int max = 0;
            string sNum = "";
            int left = 0;
            int right = 0;
            int num = 0;
            for (int n = 0; n <= txtScript.Text.Length - 1; n++)
            {
                c = txtScript.Text.Substring(n, 1);
                if (c == "(")
                {
                    left += 1;
                }
                else if (c == ")")
                {
                    right += 1;
                }
                bool inFunc = false;
                inFunc = left != right;
                num = System.Text.Encoding.ASCII.GetBytes(c)[0];
                if (inFunc & num > 47 & num < 58)
                {
                    sNum += c;
                }
                else
                {
                    if (int.TryParse(sNum, out value))
                    {
                        if (value > max) max = value;
                    }
                    sNum = "";
                }
            }
        }
        private void txtScript_Leave(object sender, EventArgs e)
        {
            if (txtScript.Text != string.Empty && txtColumnName.Text!=string.Empty)
            {

                _status = ScriptStatus.FullyOK;
                    
            }
            else
            {
                //txtColumnName.Text = string.Empty;
                _status = ScriptStatus.PartiallyOK;
                
            }
        }



        private void btnSound_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Sound Change";
                dialog.Filter = "wav files|*.wav";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.FileName = _soundPath;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _soundPath = Path.GetFullPath(dialog.FileName);
                    btnSound.Text = "Changed Sound";
                    
                }
            }
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = _soundPath;
            player.Play();
        }
        #endregion Methods

        private void cboPeriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboPeriodicity.Text)
            {
                case "Hour":
                case "Day":
                case "Week":
                    {
                        cboInterval.SelectedIndex = 0;
                        cboInterval.Enabled = false;
                    }
                    break;
                case "Minute":
                    cboInterval.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
