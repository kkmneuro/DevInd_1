using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using System.Collections;
//using FundXchange.Model.ViewModels.Charts;
using System.IO;
using PALSA.Cls;


namespace PALSA.FrmScanner
{
    public partial class frmScannerExplorer : NForm
    {
        #region Private Members
        //private frmMain m_frmMain;
        public Scanner _scanner = null;
        #endregion
        #region properties
       
       
        #endregion properties
        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainFormInstance">This is frmMain data type</param>
        public frmScannerExplorer()//(frmMain mainFormInstance)//Kul
        {

            InitializeComponent();
            //m_frmMain = mainFormInstance;
           
            //if (frmMain.NevronPalette != null)
            //    Palette = frmMain.NevronPalette;
            DirectoryInfo dirInf = new DirectoryInfo(Utils.ScannerPath);
            
            if (!dirInf.Exists)
                return;
            FileInfo[] fileInfo = dirInf.GetFiles("*.xml");
            if (fileInfo.Length > 0)
            {
                foreach (FileInfo item in fileInfo)
                {
                    lstboxScanner.Items.Add(item.Name.Split('.')[0]);
                }
            }
            

        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            _scanner = new Scanner();
            using (frmScannerExplorationEditor explorationEditor = new frmScannerExplorationEditor(_scanner))//Kul(m_frmMain,_scanner))
            {
                DialogResult dialogResult = explorationEditor.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    foreach (NListBoxItem scannerName in lstboxScanner.Items)
                    {
                        if (_scanner.ScannerName == scannerName.Text)
                        {
                            MessageBox.Show("Scanner is not added because scanner name is already exist!!");
                            return;
                        }
                    }

                    Utils.CreateScannerScript(_scanner);
                    lstboxScanner.Items.Add(_scanner.ScannerName);

                }
                else if (dialogResult == DialogResult.Cancel)
                {

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstboxScanner.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select any Scanner!!");
                return;
            }
            _scanner = Utils.GetScannerScript(lstboxScanner.SelectedItem.ToString());
            if (_scanner == null)
                return;
            using (frmScannerExplorationEditor editor = new frmScannerExplorationEditor(_scanner))//Kul(m_frmMain, _scanner))
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    if (_scanner.ScannerName == lstboxScanner.SelectedItem.ToString())
                    {
                    }
                    else
                    {
                        foreach (NListBoxItem scannerName in lstboxScanner.Items)
                        {
                            if (_scanner.ScannerName == scannerName.Text)
                            {
                                MessageBox.Show("Scanner is not added because scanner name is already exist!!");
                                return;
                            }
                        }

                        lstboxScanner.Items.Add(_scanner.ScannerName);

                    }

                    Utils.CreateScannerScript(_scanner);
                }

            }


        }
        
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lstboxScanner.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select any Scanner!!");
                return;
            }
            _scanner = Utils.GetScannerScript(lstboxScanner.SelectedItem.ToString());
            if (_scanner== null)
                return;
            _scanner.ScannerName = string.Empty;
            using (frmScannerExplorationEditor editor = new frmScannerExplorationEditor(_scanner))//(m_frmMain, _scanner))
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    foreach (NListBoxItem scannerName in lstboxScanner.Items)
                    {
                        if (_scanner.ScannerName == scannerName.Text)
                        {
                            MessageBox.Show("Scanner is not added because scanner name is already exist!!");
                            return;
                        }
                    }

                    Utils.CreateScannerScript(_scanner);
                    lstboxScanner.Items.Add(_scanner.ScannerName);

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteScanner();
        }
        /// <summary>
        /// delete selected scanner
        /// </summary>
        private void deleteScanner()
        {
            if (lstboxScanner.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select any Scanner!!");
                return;
            }
            DirectoryInfo dirInf = new DirectoryInfo(Utils.ScannerPath);
            FileInfo[] fileInfo = dirInf.GetFiles("*.xml");
            if (fileInfo.Length > 0)
            {
                foreach (FileInfo item in fileInfo)
                {
                    if (item.Name.Split('.')[0] == lstboxScanner.SelectedItem.ToString())
                    {
                        item.Delete();
                    }
                }
            }
            lstboxScanner.Items.Remove(lstboxScanner.SelectedItem.ToString());

        }

        

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            if (lstboxScanner.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select any Scanner!!");
                return;
            }

            _scanner = Utils.GetScannerScript(lstboxScanner.SelectedItem.ToString());
            if (_scanner == null)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        
        #endregion Methods
    }

   
}
