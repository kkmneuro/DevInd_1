using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;
using System.IO;
using TWS.Cls;
using System.Runtime.Serialization.Formatters.Binary;

namespace TWS.Frm
{
    public partial class frmMarketWatchSave : frmBase
    {
        // public object objMW;
        string userName;
        public Dictionary<string, clsSavedMW> ddSavedMW;
        DataTable dtMW;
        float fontSize = 12;
        public event Action<Dictionary<string, clsSavedMW>> OnMarketWatchSaveClick = delegate { };

        public frmMarketWatchSave(Dictionary<string, clsSavedMW> _ddSavedMW, string userCode, DataTable _dtMW, float _fontSize)
        {
            InitializeComponent();
            userName = userCode;
            //  objMW = obj;
            dtMW = _dtMW;
            fontSize = _fontSize;
            ddSavedMW = _ddSavedMW;
        }

        private void frmMarketWatchSave_Load(object sender, EventArgs e)
        {
            uctlSaveMarketWatch1.btnSave.Click += new EventHandler(btnSave_Click);
            uctlSaveMarketWatch1.btnCancel.Click += new EventHandler(btnCancel_Click);
            // ddSavedMW = (Dictionary<string, clsSavedMW>)objMW;
            if (ddSavedMW != null)
            {
                foreach (string key in ddSavedMW.Keys)
                {
                    uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Items.Add(key);
                }
            }
            //uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Items.AddRange(marketWatchList);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            SaveClickHandler();
        }

        private void frmMarketWatchSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void SaveMarketWatch()
        {
            try
            {

                string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetMarketWatchFileName(userName));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                Stream streamWrite = File.Open(ClsTWSUtility.GetMarketWatchFileName(userName), FileMode.Create, FileAccess.Write);
                var binaryWrite = new BinaryFormatter();
                clsSavedMW objSavedMW = new clsSavedMW();
                objSavedMW.FontSize = fontSize;
                objSavedMW.MWDataTable = dtMW;

                if (ddSavedMW == null)
                {
                    ddSavedMW = new Dictionary<string, clsSavedMW>();
                }
                if (ddSavedMW.ContainsKey(uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Text.Trim()))
                {
                    ddSavedMW[uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Text.Trim()] = objSavedMW;
                }
                else
                {
                    ddSavedMW.Add(uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Text.Trim(), objSavedMW);
                }

                binaryWrite.Serialize(streamWrite, ddSavedMW);
                streamWrite.Close();
                OnMarketWatchSaveClick(ddSavedMW);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveClickHandler()
        {            
            try
            {
                if (uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Text.Trim() == "")
                {
                    ClsCommonMethods.ShowErrorBox("Name can't be blank, Please provide a name.");
                    uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Focus();
                    return;
                }
                else if (uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Items.Contains(uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Text.Trim()))
                {
                    DialogResult result = ClsCommonMethods.ShowMessageBox("This name already exist. Do you want to over write.");
                    if (result == DialogResult.Yes)
                    {
                        SaveMarketWatch();
                        this.Close();
                    }
                    else
                    {
                        uctlSaveMarketWatch1.ui_ncmbMarketWatchName.Focus();
                        return;
                    }
                }
                else
                {
                    SaveMarketWatch();
                    this.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void uctlSaveMarketWatch1_OnSaveClick()
        {
            SaveClickHandler();
        }
    }
}
