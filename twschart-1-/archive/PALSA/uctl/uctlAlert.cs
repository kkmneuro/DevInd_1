using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using PALSA.ClsAlerts;
using PALSA.FrmScanner;
using CommonLibrary.Cls;
//using ProtocolStructs;


namespace PALSA
{
    public partial class uctlAlert : UserControl
    {
        #region Variable
        private int _ndgAlertGridCurrRowIndex;
        #endregion

        #region Constructor       
        
        public uctlAlert()
        {
            if (InstanceAlertGrid != null)
                throw new Exception("Object Already Created");
            InitializeComponent();
            _ndgAlertGridCurrRowIndex = -1;
            AlertManager.Getreference().objAlertgrid_ = this;
            InstanceAlertGrid = this;

        }
        #endregion

        private static uctlAlert InstanceAlertGrid = null;
        public static uctlAlert GetReferenceAlertGrid()
        {
            if (InstanceAlertGrid == null)
                InstanceAlertGrid = new uctlAlert();

            return InstanceAlertGrid;
        }

        //
        //This function contains operation for enable/disable AlertMenuStripItems
        //
        private void ndgAlertGrid_Mousedown(object sender, MouseEventArgs e)
        {
            ndgAlertGrid.ClearSelection();
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = this.ndgAlertGrid.HitTest(e.X, e.Y);

                _ndgAlertGridCurrRowIndex = hti.RowIndex;
                if (_ndgAlertGridCurrRowIndex == -1)
                {
                    AlertMenuStrip.Items["Modify"].Enabled = false;
                    AlertMenuStrip.Items["Delete"].Enabled = false;
                    AlertMenuStrip.Items["EnableOnOff"].Enabled = false;
                    AlertMenuStrip.Items["AutoArrange"].Enabled = false;
                    AlertMenuStrip.Items["Grid"].Enabled = false;


                }
                else if (_ndgAlertGridCurrRowIndex >= 0)
                {
                    AlertMenuStrip.Items["Modify"].Enabled = true;
                    AlertMenuStrip.Items["Delete"].Enabled = true;
                    AlertMenuStrip.Items["EnableOnOff"].Enabled = true;
                    AlertMenuStrip.Items["Grid"].Enabled = true;
                    AlertMenuStrip.Items["AutoArrange"].Enabled = true;
                    ndgAlertGrid.Rows[hti.RowIndex].Selected = true;
                }
            }


        }

        //
        //This function used for performing operation at AlertMenuStripItems
        //
        private void InvokeActions(string action)
        {
            switch (action)
            {
                case "Create":
                    {

                        AlertMenuStrip.Visible = false;
                        frmAlert alert = new frmAlert(ALERT_MODE.CREATE, null);
                        alert.TopMost = true;
                        alert.ShowDialog();
                        break;
                    }
                case "Modify":
                    {
                        AlertMenuStrip.Visible = false;                        
                        _ndgAlertGridCurrRowIndex = ndgAlertGrid.SelectedRows[0].Index;
                        string id = ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colAlertId"].Value.ToString();
                        Alert alrt = AlertManager.Getreference().GetAlert(id);
                        frmAlert alert = new frmAlert(ALERT_MODE.MODIFY, alrt);
                        alert.TopMost = true;
                        alert.ShowDialog();
                        break;
                    }
                case "Delete":
                    {
                        AlertMenuStrip.Visible = false;                       
                        _ndgAlertGridCurrRowIndex = ndgAlertGrid.SelectedRows[0].Index;
                        string id = ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colAlertId"].Value.ToString();
                        ndgAlertGrid.Rows.RemoveAt(_ndgAlertGridCurrRowIndex);
                        AlertManager.Getreference().RemoveAlert(id);

                    }

                    break;
                case "EnableOnOff":
                    AlertMenuStrip.Visible = false;
                    _ndgAlertGridCurrRowIndex = ndgAlertGrid.SelectedRows[0].Index;
                    string Eid = ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colAlertId"].Value.ToString();
                    AlertManager.Getreference().EnableDisable(Eid);                   
                    break;
                case "AutoArrange":
                    this.ndgAlertGrid.AutoResizeColumns();
                    break;
                case "Grid":
                    if (this.ndgAlertGrid.CellBorderStyle == DataGridViewCellBorderStyle.Single)
                        this.ndgAlertGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    else if (this.ndgAlertGrid.CellBorderStyle == DataGridViewCellBorderStyle.None)
                        this.ndgAlertGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;                                  
                    break;
                default:
                    break;

            }
        }

        //
        //This function used for performing operation at clicked AlertMenuStripItems
        //
        private void AlertMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
            InvokeActions( e.ClickedItem.Name);

        }

        //
        //This function used for performing operation at double click at alertgrid
        //
        private void ndgAlertGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ndgAlertGrid.RowCount >= 0)
            {
                DataGridView.HitTestInfo hti = this.ndgAlertGrid.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    int rowindex = ndgAlertGrid.SelectedRows[0].Index;
                    string id = ndgAlertGrid.Rows[rowindex].Cells["colAlertId"].Value.ToString();
                    Alert alrt = AlertManager.Getreference().GetAlert(id);
                    frmAlert alert = new frmAlert(ALERT_MODE.MODIFY, alrt);
                    alert.ShowDialog();
                }
            }
       }



        //Alert From Socket
        //delegate void del_AddAlertDetailIngrid(AlertResponse Alert);
        //public void AddAlertIngrid(AlertResponse Alert)
        //{
        //    if (InvokeRequired)
        //    {
        //        this.BeginInvoke(new del_AddAlertDetailIngrid(AddAlertIngrid), Alert);
        //    }
        //    else
        //    {
        //        Alert objalert = new Alert();
        //        if(Alert.Action_=="Sound")
        //        objalert.Action  =ALERT_ACTION.SOUND;
        //        else if (Alert.Action_ == "File")
        //            objalert.Action = ALERT_ACTION.FILE;
        //        else
        //        {
        //            if (Alert.Action_ == "Mail")
        //            {
        //                objalert.Action = ALERT_ACTION.EMAIL;
        //            }                
        //        }
        //        objalert.Condition = Alert.Condition_;
        //        objalert.SourcePath = Alert.Event_;
        //        objalert.MaximumIterations = Alert.Limit_;
        //         objalert.Symbol = Alert.Symbol_;
        //         objalert.timeout = Alert.TimeOut_.ToString();
        //         objalert.Value = Alert.Value_;
        //         objalert.setTypeConditionTradeScript(objalert.Condition);
        //        int rowindex;
        //        string[] arr;
        //        ndgAlertGrid.Rows.Add();
        //        rowindex = ndgAlertGrid.RowCount;
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colAlertId"].Value = objalert.ALERTID;
        //        ((TextAndImageCell)ndgAlertGrid.Rows[rowindex - 1].Cells["colSymbol"]).Image = imageList1.Images[0]; 
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colSymbol"].Value = objalert.Symbol;
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colCounter"].Value = objalert.CheckingCounter;
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colLimit"].Value = objalert.MaximumIterations;
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colTimeout"].Value = objalert.timeout;
        //        ndgAlertGrid.Rows[rowindex - 1].Cells["colEvent"].Value = objalert.SourcePath;
        //        if (objalert.Alert_Type != ALERT_TYPE.TIME)
        //        {
        //            arr = objalert.Value.Split('.');
        //            if (arr.Length == 2)
        //            {
        //                while (arr[1].Length < 5)
        //                    arr[1] += "0";
        //                arr[0] += ".";
        //                ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + arr[0].ToString() + arr[1].ToString();

        //            }
        //            else
        //            {
        //                ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + arr[0].ToString() + ".00000".ToString();

        //            }
        //        }
        //        else
        //            ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + objalert.Value;

        //        AlertManager.Getreference().AddAlert(objalert);
        //    }

        //}


        //
        //This function used for performing operation adding alert value in AlertGrid
        //
        delegate void del_AddAlertIngrid(Alert objalert);
        public void AddAlertIngrid(Alert objalert)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new del_AddAlertIngrid(AddAlertIngrid), objalert);
            }
            else
            {

                int rowindex;
                string[] arr;
                ndgAlertGrid.Rows.Add();
                rowindex = ndgAlertGrid.RowCount;
                ndgAlertGrid.Rows[rowindex - 1].Cells["colAlertId"].Value = objalert.ALERTID;
                ((TextAndImageCell)ndgAlertGrid.Rows[rowindex - 1].Cells["colSymbol"]).Image = imageList1.Images[0];
                ndgAlertGrid.Rows[rowindex - 1].Cells["colSymbol"].Value = objalert.Symbol;
                ndgAlertGrid.Rows[rowindex - 1].Cells["colCounter"].Value = objalert.CheckingCounter;
                ndgAlertGrid.Rows[rowindex - 1].Cells["colLimit"].Value = objalert.MaximumIterations;
                ndgAlertGrid.Rows[rowindex - 1].Cells["colTimeout"].Value = objalert.timeout;
                ndgAlertGrid.Rows[rowindex - 1].Cells["colEvent"].Value = objalert.SourcePath;
                if (objalert.Alert_Type != ALERT_TYPE.TIME)
                {
                    arr = objalert.Value.Split('.');
                    if (arr.Length == 2)
                    {
                        while (arr[1].Length < 5)
                            arr[1] += "0";
                        arr[0] += ".";
                        ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + arr[0].ToString() + arr[1].ToString();

                    }
                    else
                    {
                        ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + arr[0].ToString() + ".00000".ToString();

                    }
                }
                else
                    ndgAlertGrid.Rows[rowindex - 1].Cells["colCondition"].Value = objalert.Condition + objalert.Value;

                AlertManager.Getreference().AddAlert(objalert);
            }

        }

        //
        //This function used for performing operation modify alert value in AlertGrid
        //

        public void ModifyAlertIngrid(Alert objAlert)
        {
            int i = 0;
            string[] arr;
            foreach (Alert item in AlertManager.Getreference().lstAlerts_)
            {
                if (item.ALERTID == objAlert.ALERTID)
                {
                   
                    AlertManager.Getreference().lstAlerts_[i] = objAlert;
                  

                    break;
                }
                i++;
            }
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colAlertId"].Value = objAlert.ALERTID;
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colSymbol"].Value = objAlert.Symbol;
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colCounter"].Value = objAlert.CheckingCounter;
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colLimit"].Value = objAlert.MaximumIterations;
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colTimeout"].Value = objAlert.timeout;
            ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colEvent"].Value = objAlert.SourcePath;
            if (objAlert.Alert_Type != ALERT_TYPE.TIME)
            {
                arr = objAlert.Value.Split('.');
                if (arr.Length == 2)
                {
                    while (arr[1].Length < 5)
                        arr[1] += "0";
                    arr[0] += ".";
                    ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colCondition"].Value = objAlert.Condition + arr[0].ToString() + arr[1].ToString();

                }
                else
                {
                    ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colCondition"].Value = objAlert.Condition + arr[0].ToString() + ".00000".ToString();

                }
            }
            else
                ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colCondition"].Value = objAlert.Condition + objAlert.Value;

        }

        //
        //This function used for performing operation increase counter in AlertGrid
        //
        public void IncreaseCounterIngrid(Alert objAlert)
        {
            for (int i = 0; i < ndgAlertGrid.RowCount; i++)
            {
                if (ndgAlertGrid.Rows[i].Cells["colAlertId"].Value == objAlert.ALERTID)
                {

                    ndgAlertGrid.Rows[i].Cells["colCounter"].Value = objAlert.CheckingCounter.ToString();
                    ((TextAndImageCell)ndgAlertGrid.Rows[i].Cells["colSymbol"]).Image = imageList1.Images[2];                 
                     
                }
            }
            ndgAlertGrid.Refresh();
        }
        //
        //This function used for performing changing image at symbol column after clicked at AlertMenuItem
        //
        public void ChangeImage(Alert Ialert)
        {
            if (Ialert.Enable == false)
            {
                if (Ialert.CheckingCounter == Ialert.MaximumIterations)
                {
                    if (Ialert.imgEnable == false)
                        ((TextAndImageCell)ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colSymbol"]).Image = imageList1.Images[1];
                    else
                        ((TextAndImageCell)ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colSymbol"]).Image = imageList1.Images[0];
                }
                else
                    ((TextAndImageCell)ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colSymbol"]).Image = imageList1.Images[1];               
            }
            else
            {
                ((TextAndImageCell)ndgAlertGrid.Rows[_ndgAlertGridCurrRowIndex].Cells["colSymbol"]).Image = imageList1.Images[0];
            }
            ndgAlertGrid.Refresh();
        }

        //
        //This function used for performing shortcutkey of Insert,Modify,Delete etc. 
        //
        private void ndgAlertGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                InvokeActions("Create");
            }
            if (e.KeyCode == Keys.Enter)
            {
                InvokeActions("Modify");
            }
            if (e.KeyCode == Keys.Space)
            {
                InvokeActions("Enable On/Off");
            }
            if (e.KeyCode == Keys.A)
            {
                InvokeActions("Auto Arrange");
            }

            if (e.KeyCode == Keys.G)
            {
                InvokeActions("Grid");
            }
        }

        #region Alert Data Handling

        //public void OnNewData(AlertResponse response)
        //{
        //    AddAlertIngrid(response);
        //}

        
        #endregion

        private void uctlAlert_Load(object sender, EventArgs e)
        {
           // OrderManager.getOrderManager().AddOrderWatchItem(this, OrderManagerSubscriptionType.ALERTS);
        }


        
    }
}