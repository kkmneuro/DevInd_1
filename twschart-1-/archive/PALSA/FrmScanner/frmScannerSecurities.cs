using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Infrastructure;
using System.IO;
//using FundXchange.Model.ViewModels.Generic;
using PALSA.Cls;

namespace PALSA.FrmScanner
{
    public partial class frmScannerSecurities : NForm
    {
        #region Variables
        DataTable dataTable = new DataTable("Instruments");
        string path=string.Empty;
        #endregion Variables
        #region Properties
        /// <summary>
        /// Get symbols
        /// </summary>
        private readonly List<SymbolAttributes> _symbols;
        public IEnumerable<SymbolAttributes> Symbols
        {
            get { return _symbols; }
        }
        #endregion Properties
        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public frmScannerSecurities(List<SymbolAttributes> symbol)
        {
            InitializeComponent();
            _symbols = symbol;
            dataTable.Columns.Add("Symbol");
            dataTable.Columns.Add("Instrument Type");
            dataTable.Columns.Add("Company Long Name");
            dataTable.Columns.Add("ISIN");
            for (int i = 0; i < _symbols.Count; i++)
            {
                DataRow dr = dataTable.NewRow();
                dr[0] = _symbols[i].Symbol;
                dr[1] = _symbols[i].InstrumentType;
                dr[2] = _symbols[i].CompanyLongName;
                dr[3] = _symbols[i].ISIN;
                dataTable.Rows.Add(dr);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSecurities_Click(object sender, EventArgs e)
        {
            //Kul
            //List<string> selectedSymbols = new List<string>();

            //var marketRepository = IoC.Resolve<IMarketRepository>();

            //DialogResult result = new frmSymbolLookup(marketRepository, ref selectedSymbols, ref dataTable, true).ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    dgvSymbol.DataSource = dataTable;
            //    EnableBtn();
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string symbolName = string.Empty;
            DataGridViewSelectedRowCollection dr = dgvSymbol.SelectedRows;
            foreach (DataGridViewRow item in dr)
            {
                symbolName = item.Cells[0].Value.ToString();
                dataTable.Rows.Remove(dataTable.Select("Symbol='" + symbolName + "'")[0]);
            }
            dgvSymbol.DataSource = dataTable;
            EnableBtn();
        }

        private void frmScannerSecurities_Load(object sender, EventArgs e)
        {
            dgvSymbol.DataSource = dataTable;
            EnableBtn();
        }
        /// <summary>
        /// If grid has any symbol then Remove and RemoveAll button are enabled otherwise disabled. 
        /// </summary>
        private void EnableBtn()
        {
            if (dgvSymbol.RowCount > 0)
            {
                btnRemove.Enabled = true;
                btnRemoveAll.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnRemoveAll.Enabled = false;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            dgvSymbol.DataSource = dataTable;
            EnableBtn();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files|*.csv|Text Files|*.txt";
                if (saveFileDialog.ShowDialog() ==DialogResult.OK)
                {
                    SaveSymbolsInFile(saveFileDialog.FileName);
                }
            }
            
            
        }
        /// <summary>
        /// Save symboles in file
        /// </summary>
        /// <param name="fileName">file name of symbols</param>
        private void SaveSymbolsInFile(string fileName)
        {
            path= Path.GetFullPath(fileName);
            string delimiter = ",";
            StreamWriter sw = new StreamWriter(path);
            foreach (DataRow dr in dataTable.Rows)
            {
                sw.WriteLine(dr[0] + delimiter + dr[1] + delimiter + dr[2] + delimiter + dr[3]);
            }
            sw.Close();
        }

        private void chkUseLastExploration_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseLastExploration.Checked)
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
            
        }
        /// <summary>
        /// Load symbols from file which is saved.
        /// </summary>
        /// <param name="fileName">select file name of symbols</param>
        private void LoadSymbolsFromFile(string fileName)
        {
                dataTable.Clear();
                path = Path.GetFullPath(fileName);
                using (StreamReader sr = new StreamReader(path))
                {

                    string[] stringRow;
                    DataRow dr;
                    int i;
                    string[] symbolsInFile = sr.ReadToEnd().Split('\n');
                    if (symbolsInFile.Length > 0)
                    {
                        foreach (string datarow in symbolsInFile)
                        {
                            if (datarow != string.Empty)
                            {
                                i = 0;
                                stringRow = datarow.Split(',');
                                dr = dataTable.NewRow();
                                foreach (string item in stringRow)
                                {
                                    dr[i++] = item;
                                }
                                dataTable.Rows.Add(dr);
                            }
                        }
                    }

                }
                dgvSymbol.DataSource = dataTable;
                EnableBtn();
            }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataTable.Rows.Count > 0)
            {
                _symbols.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    _symbols.Add(new SymbolAttributes(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString()));
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        #endregion Methods
    }
}
