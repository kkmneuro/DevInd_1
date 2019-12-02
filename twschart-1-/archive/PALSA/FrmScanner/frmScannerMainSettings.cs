using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Model.ViewModels.Charts;
//using M4.Scripts;
//using FundXchange.Model.ViewModels.Generic;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;

namespace PALSA.FrmScanner
{
	public partial class frmScannerMainSettings
    {
        #region Private Members

        //Kul private frmMain m_frmMain;

        #endregion

        #region Public Properties

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

        private readonly List<string> _symbols;
        public IEnumerable<string> Symbols 
        {
            get { return _symbols; }
        }

        #endregion

        public frmScannerMainSettings(IEnumerable<string> symbols)//Kul(frmMain mainFormInstance, IEnumerable<string> symbols)
		{			
			InitializeComponent();

            //m_frmMain = mainFormInstance;
            _symbols = new List<string>(symbols);

            //Kul
            //if(frmMain.NevronPalette!= null)
            //    Palette = frmMain.NevronPalette;
		}

		private void OK_Button_Click_1(System.Object sender, System.EventArgs e)
		{
			if (VerifyForm()) 
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		private void Cancel_Button_Click_1(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

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

		private bool VerifyForm()
		{
            //Kul
            //ScriptValidationService validationService = IoC.Resolve<ScriptValidationService>();
            //if (validationService.IsValid(txtScript.Text))
            //{
            //    uint uintVal = 0;
            //    if (string.IsNullOrEmpty(cboPeriodicity.Text))
            //    {
            //        cboPeriodicity.Focus();
            //        MessageBox.Show("Please select a periodicity", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //    if (_symbols.Count < 2)
            //    {
            //        MessageBox.Show("Please enter a list of symbols", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //    else if (_symbols.Count > 5000)
            //    {
            //        MessageBox.Show("Please enter fewer symbols (max 5000)", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //    return true;
            //}
            //string validationMessage = validationService.GetValidationResult(txtScript.Text);
            //MessageBox.Show(validationMessage, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

		    return false;
		}


		//Estimates the maximum number of periods used in the script
		private void txtScript_TextChanged(object sender, EventArgs e)
		{
			string c = null;
			int value = 0;
			int max = 0;
			string sNum = "";
			int left = 0;
			int right = 0;
			int num = 0;
			for (int n = 0; n <= txtScript.Text.Length - 1; n++) {
				c = txtScript.Text.Substring(n, 1);
				if (c == "(") {
					left += 1;
				}
				else if (c == ")") {
					right += 1;
				}
				bool inFunc = false;
				inFunc = left != right;
				num = System.Text.Encoding.ASCII.GetBytes(c)[0];
				if (inFunc & num > 47 & num < 58) {
					sNum += c;
				}
				else {
					if (int.TryParse(sNum, out value)) {
						if (value > max) max = value; 
					}
					sNum = "";
				}
			}
		}

		private void cmdBrowse_Click(object sender, EventArgs e)
		{
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV Files|*.csv|Text Files|*.txt";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadSymbolsFromFile(dialog.FileName);
                }
            }
		}

        private void btnSelectSymbols_Click(object sender, EventArgs e)
        {
            List<string> selectedSymbols = new List<string>();

            //Kul
            //var marketRepository = IoC.Resolve<IMarketRepository>();

            //DialogResult result = new frmSymbolLookup(marketRepository, ref selectedSymbols, true).ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    _symbols.Clear();
            //    _symbols.AddRange(selectedSymbols);

            //    lblSymbolFile.Text = string.Format("{0} symbols loaded", _symbols.Count);
            //}
        }

        private void LoadSymbolsFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            using (StreamReader sr = new StreamReader(fileName))
            {
                _symbols.Clear();
                string[] symbolsInFile = sr.ReadToEnd().Split(',', '\n');
                if (symbolsInFile.Length > 0)
                {
                    IEnumerable<string> distinctSymbols = symbolsInFile.Distinct();
                    //Kul
                    //foreach (string symbol in distinctSymbols)
                    //{
                    //    if (SubscriptionDescriptor.IsValidDescriptor(symbol))
                    //    {
                    //        SubscriptionDescriptor descriptor = SubscriptionDescriptor.From(symbol);
                    //        _symbols.Add(descriptor.Symbol);
                    //    }
                    //    else
                    //    {
                    //        _symbols.Add(symbol.ToUpper().Trim());
                    //    }
                    //}
                    lblSymbolFile.Text = string.Format("{0} symbols loaded", _symbols.Count);
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

        private void cboPeriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboInterval.SelectedIndex = 0;
            cboInterval.Enabled = cboPeriodicity.SelectedIndex == 0;
            
        }
	}
}
