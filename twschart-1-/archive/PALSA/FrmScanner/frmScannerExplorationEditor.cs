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
//using M4.Scripts;
//using FundXchange.Infrastructure;
//using FundXchange.Model.ViewModels.Charts;
using PALSA.Cls;
using PALSA.uctl;
using CommonLibrary.UserControls;

namespace PALSA.FrmScanner
{
    public partial class frmScannerExplorationEditor : NForm
    {
        #region Variables
        private ctlScannerExplorationEdit scannerExplorationEditTabA = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabB = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabC = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabD = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabE = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabF = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabG = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabH = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabI = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabJ = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabK = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabL = new ctlScannerExplorationEdit();
        private ctlScannerExplorationEdit scannerExplorationEditTabFilter = new ctlScannerExplorationEdit();
        //Kul
        //private frmMain m_frmmain;
        private List<string> m_existing = new List<string>();
        Scanner scannerDetail = new Scanner();
        int previousTabIndex = 0;
        private string endStr = ")";
        private string startStr = " (";
        #endregion Variables
        #region properties

        #endregion properties
        #region methods
        /// <summary>
        /// Constructor
        /// </summary>
        public frmScannerExplorationEditor(Scanner scanner)//Kul(frmMain mainfrm, Scanner scanner)
        {
            InitializeComponent();
            //m_frmmain = mainfrm;
            scannerDetail = scanner;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSecurities_Click(object sender, EventArgs e)
        {
            string Symb = string.Empty;
            ctlSelectSymbol ctlSymbol = new ctlSelectSymbol(scannerDetail.Symbols);//(ref Symb);
            //DialogResult dialogResult = ctlSymbol.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            if (scannerDetail.Symbols.Count > 0)
            {
                setSymbolMsg();
            }
            //}


            //Kul
            //using (frmScannerSecurities scannerSecurities = new frmScannerSecurities(scannerDetail.Symbols))
            //{
            //    DialogResult dialogResult = scannerSecurities.ShowDialog();
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        setSymbolMsg();
            //    }
            //}
        }


        private void frmScannerExplorationEditor_Load(object sender, EventArgs e)
        {

            tabA.Controls.Add(scannerExplorationEditTabA);
            scannerExplorationEditTabA.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabB.Controls.Add(scannerExplorationEditTabB);
            scannerExplorationEditTabB.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabC.Controls.Add(scannerExplorationEditTabC);
            scannerExplorationEditTabC.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabD.Controls.Add(scannerExplorationEditTabD);
            scannerExplorationEditTabD.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabE.Controls.Add(scannerExplorationEditTabE);
            scannerExplorationEditTabE.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabF.Controls.Add(scannerExplorationEditTabF);
            scannerExplorationEditTabF.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabG.Controls.Add(scannerExplorationEditTabG);
            scannerExplorationEditTabG.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabH.Controls.Add(scannerExplorationEditTabH);
            scannerExplorationEditTabH.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabI.Controls.Add(scannerExplorationEditTabI);
            scannerExplorationEditTabI.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabJ.Controls.Add(scannerExplorationEditTabJ);
            scannerExplorationEditTabJ.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabK.Controls.Add(scannerExplorationEditTabK);
            scannerExplorationEditTabK.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabL.Controls.Add(scannerExplorationEditTabL);
            scannerExplorationEditTabL.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tabFilter.Controls.Add(scannerExplorationEditTabFilter);
            //scannerExplorationEditTabFilter.TextLeaveEvent += new ctlScannerExplorationEdit.TextLeave(scannerExplorationEditTab_TextLeaveEvent);
            tcParent.SelectedTab = tabA;
            txtName.Text = scannerDetail.ScannerName;
            txtNotes.Text = scannerDetail.Note;
            for (int i = 0; i < scannerDetail.Scripts.Count; i++)
            {
                
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).ColumnName = scannerDetail.Scripts[i].ScriptName.ToString();
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Script = scannerDetail.Scripts[i].Script.ToString();
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Interval = scannerDetail.Scripts[i].Interval;
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Bars = scannerDetail.Scripts[i].Bars;
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Periodicity = scannerDetail.Scripts[i].Periodicity;
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Status = ScriptStatus.FullyOK;
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).ScriptType = scannerDetail.Scripts[i].ScriptType.ToString();
                    ((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).SoundPath = scannerDetail.Scripts[i].SoundPath.ToString();
                    if (((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Periodicity == Periodicity.Daily)
                        tcParent.TabPages[i].Text = scannerDetail.Scripts[i].ScriptName.ToString() + startStr + scannerDetail.Scripts[i].Interval.ToString() + scannerDetail.Scripts[i].Periodicity.ToString().Substring(0, 2) + "y" + endStr;
                    else if (((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Periodicity == Periodicity.Hourly)
                    {
                        tcParent.TabPages[i].Text = scannerDetail.Scripts[i].ScriptName.ToString() + startStr + scannerDetail.Scripts[i].Interval.ToString() + scannerDetail.Scripts[i].Periodicity.ToString().Substring(0, 4) + endStr;
                    }
                    else if (((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).Periodicity == Periodicity.Weekly)
                    {
                        tcParent.TabPages[i].Text = scannerDetail.Scripts[i].ScriptName.ToString() + startStr + scannerDetail.Scripts[i].Interval.ToString() + scannerDetail.Scripts[i].Periodicity.ToString().Substring(0, 4) + endStr;
                    }
                    else
                        tcParent.TabPages[i].Text = scannerDetail.Scripts[i].ScriptName.ToString() + startStr + scannerDetail.Scripts[i].Interval.ToString() + scannerDetail.Scripts[i].Periodicity.ToString().Substring(0, 3) + endStr;
                
            }
            ((ctlScannerExplorationEdit)tcParent.TabPages[12].Controls[0]).SoundPath = scannerDetail.FilterSoundPath;
            scannerExplorationEditTabFilter.EnableControl(true);
            setSymbolMsg();

        }
        /// <summary>
        /// Give the message which symbols are selected.
        /// </summary>
        private void setSymbolMsg()
        {
            string msg = string.Empty;
            if (scannerDetail.Symbols.Count > 0)
            {
                msg = "Selected symbols are ";
                foreach (SymbolAttributes item in scannerDetail.Symbols.ToList())
                {
                    msg += item.Symbol + ",";
                }
                msg.Remove(msg.Length - 1);
                msg += ".";
            }
            else
            {
                msg = "No symbols are selected.";
            }
            txtDescriptionDeatil.Text = msg;
            txtDescriptionDeatil.Font = new Font(txtDescriptionDeatil.Font.FontFamily, 10, FontStyle.Bold); ;
        }
        void scannerExplorationEditTab_TextLeaveEvent(object sender, EventArgs e)
        {
            changeTabName(sender, ((ctlScannerExplorationEdit)sender).Parent.Name.Remove(0, 3));
        }
        /// <summary>
        /// When column name of the tab is changed then set the name of tab is column name otherwise default tab name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        private void changeTabName(object sender, string name)
        {
            if (((ctlScannerExplorationEdit)sender).ColumnName != string.Empty)
            {
                ((ctlScannerExplorationEdit)sender).Parent.Text = ((ctlScannerExplorationEdit)sender).ColumnName;
            }
            else
                ((ctlScannerExplorationEdit)sender).Parent.Text = name;


       }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsVerify())
            {
                scannerDetail.Note = txtNotes.Text;
                scannerDetail.ScannerName = txtName.Text;
                if (((ctlScannerExplorationEdit)tcParent.TabPages[12].Controls[0]).SoundPath==string.Empty)
                    ((ctlScannerExplorationEdit)tcParent.TabPages[12].Controls[0]).SoundPath = Application.StartupPath + "\\Resx\\Alert.wav";
                scannerDetail.FilterSoundPath = ((ctlScannerExplorationEdit)tcParent.TabPages[12].Controls[0]).SoundPath;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                if (msg.Contains("scipt"))
                {
                    foreach (NTabPage item in tcParent.TabPages)
                    {
                        if (item.Text == msg.Remove(msg.IndexOf("has")).Trim())
                        {
                            tcParent.SelectedTab = item;
                            break;
                        }
                    }

                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show(msg, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        string msg = string.Empty;
        /// <summary>
        /// To check scripts are synatically correct or not and textboxes are properly filed or not.
        /// </summary>
        /// <returns></returns>
        private bool IsVerify()
        {
            msg = string.Empty;
            if (txtName.Text == string.Empty)
            {
                msg = "Please write name !!";
                txtName.Focus();
                return false;
            }

            else if (scannerDetail.Symbols.Count < 1)
            {
                msg = "Please select symbols!!";
                btnSecurities.Focus();
                return false;
            }
            else
            {

                scannerDetail.Scripts.Clear();
                foreach (NTabPage item in tcParent.TabPages)
                {
                    foreach (Control itm in item.Controls)
                    {
                        if (itm is ctlScannerExplorationEdit)
                        {
                            if (((ctlScannerExplorationEdit)itm).Status == ScriptStatus.PartiallyOK)
                            {
                                msg += item.Text + " has not scipt\n";
                                return false;
                            }
                            if (((ctlScannerExplorationEdit)itm).Status == ScriptStatus.FullyOK)
                            {
                                scannerDetail.Scripts.Add(new ScriptDeatil
                                    (
                                  ((ctlScannerExplorationEdit)itm).Script,
                                  ((ctlScannerExplorationEdit)itm).ColumnName,
                                  ((ctlScannerExplorationEdit)itm).ScriptType,
                                  ((ctlScannerExplorationEdit)itm).SoundPath,
                                  ((ctlScannerExplorationEdit)itm).Interval,
                                  ((ctlScannerExplorationEdit)itm).Bars,
                                  ((ctlScannerExplorationEdit)itm).Periodicity
                                    ));

                            }
                           
                        }
                    }
                }

                if (scannerDetail.Scripts.Count == 0)
                {
                    msg = "Write minimum one trade script.";
                    return false;
                }

                //Kul
                //ScriptValidationService validationService = IoC.Resolve<ScriptValidationService>();
                //for (int i = 0; i < scannerDetail.Scripts.Count; i++)
                //{
                //    if (!validationService.IsValid(scannerDetail.Scripts[i].Script))
                //    {
                //        msg = validationService.GetValidationResult(scannerDetail.Scripts[i].Script);
                //        return false;
                //    }
                //}
                return true;
            }
        }


        private void btnOptions_Click(object sender, EventArgs e)
        {
            using (frmExplorationOptions explorationOptions = new frmExplorationOptions())
            {
                if (explorationOptions.ShowDialog() == DialogResult.OK)
                {

                }
                else if (DialogResult == DialogResult.Cancel)
                {

                }
            }
        }


        private void btnFunctions_Click(object sender, EventArgs e)
        {
            using (frmRadarFormatColumns frie = new frmRadarFormatColumns(m_existing))//Kul(m_frmmain, m_existing))
            {
                if (frie.ShowDialog() == DialogResult.OK)
                {
                    if (frie.Columns.Count == 1)
                    {
                        ((ctlScannerExplorationEdit)tcParent.TabPages[tcParent.SelectedIndex].Controls[0]).ColumnName = frie.Columns[0].indicatorname;
                        ((ctlScannerExplorationEdit)tcParent.TabPages[tcParent.SelectedIndex].Controls[0]).Script = frie.Columns[0].script;
                        ((ctlScannerExplorationEdit)tcParent.TabPages[tcParent.SelectedIndex].Controls[0]).Status = ScriptStatus.FullyOK;
                        string name = ((ctlScannerExplorationEdit)tcParent.TabPages[tcParent.SelectedIndex].Controls[0]).Interval.ToString() +((ctlScannerExplorationEdit)tcParent.TabPages[tcParent.SelectedIndex].Controls[0]).Periodicity.ToString().Substring(0,1);
                        tcParent.TabPages[tcParent.SelectedIndex].Text=frie.Columns[0].indicatorname+" "+ name;
                       
                    }
                    else
                    {
                        MessageBox.Show("Select only 1 scripts", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else if (DialogResult == DialogResult.Cancel)
                {

                }

            }
        }

        #endregion methods

        private void tcParent_SelectedTabChanged(object sender, EventArgs e)
        {
            if ((((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).ColumnName != string.Empty))
            {
                string name = string.Empty;
                if (((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity == Periodicity.Daily)
                    name = ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Interval.ToString() + ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity.ToString().Substring(0, 2)+"y";
                else if (((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity == Periodicity.Weekly || ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity==Periodicity.Hourly)
                {name = ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Interval.ToString() + ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity.ToString().Substring(0, 4);}
                    else
                    name = ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Interval.ToString() + ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).Periodicity.ToString().Substring(0, 3) ;
                tcParent.TabPages[previousTabIndex].Text = ((ctlScannerExplorationEdit)tcParent.TabPages[previousTabIndex].Controls[0]).ColumnName + startStr + name + endStr;
                
            }
            previousTabIndex = tcParent.SelectedIndex;
        //    for (int i = 0; i < tcParent.TabPages.Count; i++)
        //    {
        //        if (((ctlScannerExplorationEdit)tcParent.TabPages[i].Controls[0]).ColumnName == string.Empty)
        //        {
        //            if (tcParent.TabPages[i].Name == tabFilter.Name)
        //            {
        //                scannerExplorationEditTabFilter.EnableControl(true);
        //                return;

        //            }
        //            scannerExplorationEditTabFilter.EnableControl(false);
        //            return;

        //        }
        //    }
        }
    }
}
