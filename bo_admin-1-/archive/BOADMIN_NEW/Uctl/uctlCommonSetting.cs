using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSSocket.Classes;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using ProtocolStructs.NewPS;
using System.Reflection;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlCommonSetting : uctlGeneric, Interfaces.IUserCtrl
    {
        #region UI_DATA
        //public DS4CommonSettingNew.dtCommonSettingsRow _row = null;
        string _value;
        string _property;
        int _id;
        #endregion UI_DATA

        public uctlCommonSetting()
        {
            InitializeComponent();
            //clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings.TableNewRow += new DataTableNewRowEventHandler(dtCommonSettings_TableNewRow);
            //clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings.RowChanging += new DataRowChangeEventHandler(dtCommonSettings_RowChanging);
            //clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings.RowChanged += new DataRowChangeEventHandler(dtCommonSettings_RowChanged);
        }

        void dtCommonSettings_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtCommonSettings_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            RefreshMe();
        }

        void dtCommonSettings_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }
        void RefreshMe()
        {
            Action A = () =>
            {
                ui_ndgvCommonSettings.ScrollBars = ScrollBars.None;
                ui_ndgvCommonSettings.Refresh();

                if (ui_ndgvCommonSettings.Rows.Count > 0)
                {
                    ui_ndgvCommonSettings.FirstDisplayedScrollingRowIndex = ui_ndgvCommonSettings.Rows.Count - 1;
                }

                ui_ndgvCommonSettings.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndgvCommonSettings.InvokeRequired)
            {
                ui_ndgvCommonSettings.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }
        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region IUserCtrl Members

        public void Init()
        {

            ui_ndgvCommonSettings.DataSource = clsCommonSettingsManagerNew.INSTANCE._DS4CommonSettingNew.dtCommonSettings;

            DataGridViewButtonColumn Updatecol = new DataGridViewButtonColumn();

            Updatecol.Name = "SettingUpdateCol";
            Updatecol.DefaultCellStyle.NullValue = "Update";
            Updatecol.Text = "Update";
            Updatecol.HeaderText = "Update";
            ui_ndgvCommonSettings.Columns.Add(Updatecol);
            ui_ndgvCommonSettings.Columns["SettingUpdateCol"].Width = 60;
            // ui_ndgvCommonSettings.Columns["SettingUpdateCol"].Visible = false;
            ui_ndgvCommonSettings.Columns["ID"].Visible = false;
        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {

        }

        #endregion

        private void uctlCommonSetting_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ui_ndgvCommonSettings, new object[] { true });
            Init();
        }

        private void ui_ndgvCommonSettings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cell = ui_ndgvCommonSettings.Rows[e.RowIndex].Cells["Value"];

                if (ui_ndgvCommonSettings.Columns[e.ColumnIndex].Name == "Value")
                {
                    ui_ndgvCommonSettings.ReadOnly = false;
                    ui_ndgvCommonSettings.CurrentCell = cell;
                    ui_ndgvCommonSettings.BeginEdit(true);
                }
                else if (ui_ndgvCommonSettings.Columns[e.ColumnIndex].Name == "SettingUpdateCol")
                {
                    _id = Convert.ToInt32(ui_ndgvCommonSettings.Rows[e.RowIndex].Cells["ID"].Value);
                    _value = cell.Value.ToString().Trim();
                    _property = ui_ndgvCommonSettings.Rows[e.RowIndex].Cells["Property"].Value.ToString();
                    UpdateHandler(_value, _id, _property);
                    //UpdateHandler(cell.Value.ToString().Trim(), Convert.ToInt32(ui_ndgvCommonSettings.Rows[e.RowIndex].Cells["ID"].Value), ui_ndgvCommonSettings.Rows[e.RowIndex].Cells["Property"].Value.ToString());
                }
                else
                {
                    ui_ndgvCommonSettings.ReadOnly = true;
                    return;
                }
            }
            else
            {
                return;
            }
        }
        protected void UpdateHandler(string value, int ID, string property)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCommonSetting : Enter UpdateHandler()");
                string errorMsg = "Error in updating Common Settings";
                clsCommonSettings objclsCommonSettings = new clsCommonSettings();
                objclsCommonSettings.ID = ID;
                objclsCommonSettings.Value = value;
                objclsCommonSettings.Property = property;

                objclsCommonSettings = clsProxyClassManager.INSTANCE.UpdateCommonSettings(objclsCommonSettings);

                if (objclsCommonSettings.ServerResponseID != clsGlobal.FailureID)
                {
                    clsCommonSettingsManagerNew.INSTANCE.DoHandleCommonSettingNewTable(objclsCommonSettings);
                }
                else if (objclsCommonSettings.ServerResponseID == clsGlobal.FailureID)
                {
                    clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCommonSetting =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in UpdateHandler()");
            }
        }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            if (ui_ndgvCommonSettings.Rows.Count == 0)
            {
                this.ParentForm.Close();
                return;
            }
            UpdateHandler(_value, _id, _property);
            this.ParentForm.Close();
        }
    }
}
