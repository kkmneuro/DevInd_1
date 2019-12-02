//<Revision History>

//Date : 04/01/2012
//Author Name : Vijay Prakash Singh
//Description : Naming convention of controls, commenting of properties and methods and defining regions

//</Revision History>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class FrmAddRemoveForexPair : Form
    {
        #region   "        MEMBERS         "

        public UctlForex ParentForex;
        private int _iTargetForexprDropIndx = -1;
        //public uctlMarketWatch ParentMarketWatch_ = uctlMarketWatch.GetMarketWatchInstance;
        private object[] _initiallist;
        //bool _bApply = false;
        public bool _isForMarketWatch = true;
        private bool _isTargetForexprDragDrop;
        private string _title = "frmAddRemoveForexPair";

        #endregion "         MEMBERS        "

        #region    "        PROPERTIES      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion "        PROPERTIES      "

        #region    "        METHODS         "

        /// <summary>
        ///  Constructor for initilizing the controls of the form "frmAddRemoveForexPair
        /// </summary>
        /// <param name="sourcePairs">All Symobls list</param>
        /// <param name="visiblePairs">list of visible ForexPair symbols</param>
        public FrmAddRemoveForexPair(List<string> sourcePairs, List<string> visiblePairs)
        {
            InitializeComponent();
            AcceptButton = ui_nbtnOk;
            CancelButton = ui_nbtnCancel;
            FormBorderStyle = FormBorderStyle.None;
            SetForexprLists(sourcePairs, visiblePairs);
        }

        /// <summary>
        /// Sets the items in the list ui_nlstvisiblePairs & ui_nlstInvisiblePairs 
        /// </summary>
        /// <param name="sourcePairs">All Symobls list</param>
        /// <param name="visiblePairs">list of visible ForexPair symbols</param>
        private void SetForexprLists(List<string> sourcePairs, List<string> visiblePairs)
        {
            foreach (string item in visiblePairs)
            {
                int index = sourcePairs.IndexOf(item);
                if (index >= 0)
                {
                    sourcePairs.RemoveAt(index);
                }
                ui_nlstvisiblePairs.Items.Add(item);
            }

            foreach (string item in sourcePairs)
            {
                ui_nlstInvisiblePairs.Items.Add(item);
            }
            //ui_nlstInvisiblePairs.Items.AddRange(sourcePairs.ToArray());
            //ui_nlstvisiblePairs.Items.AddRange(visiblePairs.ToArray());
        }

        /// <summary>
        /// Sets the selected visible symbols for the ForexPair control to Forex control ( ChangeSettings(arr) method in uctlForex)
        /// </summary>
        private void ApplyForexSettings()
        {
            int length = ui_nlstvisiblePairs.Items.Count;
            var arr = new object[length];
            for (int loop = 0; loop < length; loop++)
                arr[loop] = ui_nlstvisiblePairs.Items[loop].Text;
            ParentForex.ChangeSettings(arr); //ChangeSettings(arr) method in uctlForex
        }

        /// <summary>
        /// This method apply market watch settings
        /// </summary>
        private void ApplyMarketWatchSettings()
        {
            int length = ui_nlstvisiblePairs.Items.Count;
            var arr = new object[length];
            for (int loop = 0; loop < length; loop++)
                arr[loop] = ui_nlstvisiblePairs.Items[loop].Text;
            //ParentMarketWatch_.ChangeSettings(arr);
        }

        /// <summary>
        /// Apply changes to uctlForex control
        /// </summary>
        private void ApplyTheChanges()
        {
            if (_isForMarketWatch)
                ApplyMarketWatchSettings();
            else
                ApplyForexSettings();
        }

        /// <summary>
        /// Contains tasks to be performed whene the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddRemoveForexPair_Load(object sender, EventArgs e)
        {
            nExpanderTitle.State = ExpanderState.Collapsed;
            int length = ui_nlstvisiblePairs.Items.Count;
            _initiallist = new object[length];
            for (int loop = 0; loop < length; loop++)
                _initiallist[loop] = ui_nlstvisiblePairs.Items[loop].Text;
            string strHelp = "Use \"Move\" or \"Move All\" buttons for adding/removing instruments. The sequence of" +
                             " instruments in \"Quote\" is same as listed in right list box. User can use \"drag " +
                             "and drop\" for sequencing or moving.";
            if (_isForMarketWatch)
            {
                //strHelp = strHelp.Replace("forex pairs", "instruments");
                strHelp = strHelp.Replace("Quote", "Market Watch");
                lblHelp.Text = strHelp;
                nExpanderTitle.Text = "Modify Instruments in Market Watch";
            }
            else
            {
                nExpanderTitle.Text = "Modify Instruments in Quotes"; //Add/Remove Forex Pairs";
                lblHelp.Text = strHelp;
            }
        }

        /// <summary>
        /// Action to be performed on MouseDown event of nlstInvisiblePairs list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstInvisiblePairs_MouseDown(object sender, MouseEventArgs e)
        {
            if (ui_nlstInvisiblePairs.Items.Count == 0)
                return;
            int index = ui_nlstInvisiblePairs.IndexFromPoint(e.X, e.Y);
            if (index < 0)
                return;
            string s = ui_nlstInvisiblePairs.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                ui_nlstInvisiblePairs.Items.RemoveAt(ui_nlstInvisiblePairs.IndexFromPoint(e.X, e.Y));
            }
        }

        /// <summary>
        /// Action to be performed on DragOver event of nlstvisiblePairs list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstvisiblePairs_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        /// <summary>
        /// Action to be performed on DragDrop event of nlstvisiblePairs list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstvisiblePairs_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = ui_nlstvisiblePairs.PointToClient(new Point(e.X, e.Y));
            _iTargetForexprDropIndx = ui_nlstvisiblePairs.IndexFromPoint(clientPoint);
            if (_isTargetForexprDragDrop == false && e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                var str = (string) e.Data.GetData(DataFormats.StringFormat);
                ui_nlstvisiblePairs.Items.Add(str);
            }
        }

        /// <summary>
        /// Action to be performed on MouseDown event of nlstvisiblePairs list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstvisiblePairs_MouseDown(object sender, MouseEventArgs e)
        {
            _isTargetForexprDragDrop = true;

            int mousDownIndex = -1;

            if (ui_nlstvisiblePairs.Items.Count == 0)
                return;
            if ((mousDownIndex = ui_nlstvisiblePairs.IndexFromPoint(e.X, e.Y)) < 0)
                return;
            string s = ui_nlstvisiblePairs.Items[mousDownIndex].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                                              DragDropEffects.All);

            if (dde1 == DragDropEffects.All && _iTargetForexprDropIndx >= 0)
            {
                ui_nlstvisiblePairs.Items.RemoveAt(mousDownIndex);
                ui_nlstvisiblePairs.Items.Insert(_iTargetForexprDropIndx, s);
            }
            _isTargetForexprDragDrop = false;
            _iTargetForexprDropIndx = -1;
        }

        /// <summary>
        /// Applys changes to uctlForex control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            ApplyTheChanges();
            Close();
        }

        /// <summary>
        /// Closes the form "frmAddRemoveForexPair dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            //if (bApply == true)
            //{
            //    Parent_.ChangeSettings(initiallist);             
            //}
            Close();
        }

        /// <summary>
        /// Applys changes to uctlForex control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnApply_Click(object sender, EventArgs e)
        {
            //_bApply = true;
            ApplyTheChanges();
        }

        /// <summary>
        /// Moves all items of ui_nlstvisible list to ui_nlstInvisible list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRemoveAll_Click(object sender, EventArgs e)
        {
            Enabled = false;
            foreach (object item in ui_nlstvisiblePairs.Items)
            {
                ui_nlstInvisiblePairs.Items.Add(item);
            }
            ui_nlstvisiblePairs.Items.Clear();
            Enabled = true;
        }

        /// <summary>
        /// Moves all items of ui_nlstInvisible list to ui_nlstvisible list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnAddAll_Click(object sender, EventArgs e)
        {
            Enabled = false;
            foreach (object item in ui_nlstInvisiblePairs.Items)
            {
                ui_nlstvisiblePairs.Items.Add(item);
            }
            ui_nlstInvisiblePairs.Items.Clear();
            Enabled = true;
        }

        /// <summary>
        /// Moves the selected items from ui_nlstvisible list to ui_nlstInvisible list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnRemove_Click(object sender, EventArgs e)
        {
            if (ui_nlstvisiblePairs.SelectedItem == null)
            {
                MessageBox.Show("Please select the symbol from right list box.", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            Enabled = false;
            //ui_nlstInvisiblePairs.Items.Add(ui_nlstvisiblePairs.SelectedItem);
            //ui_nlstvisiblePairs.Items.Remove(ui_nlstvisiblePairs.SelectedItem);

            var tmpList = new List<object>();
            foreach (object item in ui_nlstvisiblePairs.SelectedItems)
            {
                ui_nlstInvisiblePairs.Items.Add(item);
                tmpList.Add(item);
            }
            foreach (object item in tmpList)
            {
                ui_nlstvisiblePairs.Items.Remove(item);
            }
            tmpList = null;
            Enabled = true;
        }

        /// <summary>
        /// Moves the selected items from ui_nlstInvisible list to ui_nlstvisible list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnAdd_Click(object sender, EventArgs e)
        {
            if (ui_nlstInvisiblePairs.SelectedItem == null)
            {
                MessageBox.Show("Please select the symbol from left list box.", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            //ui_nlstvisiblePairs.Items.Add(ui_nlstInvisiblePairs.SelectedItem);
            //ui_nlstInvisiblePairs.Items.Remove(ui_nlstInvisiblePairs.SelectedItem);
            Enabled = false;

            var tmpList = new List<object>();
            foreach (object item in ui_nlstInvisiblePairs.SelectedItems)
            {
                ui_nlstvisiblePairs.Items.Add(item);
                tmpList.Add(item);
            }
            foreach (object item in tmpList)
            {
                ui_nlstInvisiblePairs.Items.Remove(item);
            }
            Enabled = true;
        }

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public void SetLocalization()
        {
            Title = "";
            ui_nbtnAdd.Text = ClsLocalizationHandler.Add + " >";
            ui_nbtnAddAll.Text = ClsLocalizationHandler.Add + ClsLocalizationHandler.All + " >>";
            ui_nbtnRemove.Text = "< " + ClsLocalizationHandler.Remove;
            ui_nbtnRemoveAll.Text = "<< " + ClsLocalizationHandler.Remove + ClsLocalizationHandler.All;
            ui_nbtnOk.Text = ClsLocalizationHandler.Ok;
            ui_nbtnApply.Text = ClsLocalizationHandler.Apply;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
        }

        #endregion "        METHODS      "
    }
}