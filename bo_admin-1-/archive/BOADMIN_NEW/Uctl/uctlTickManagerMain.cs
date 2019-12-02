using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.Forms;
using BOADMIN_NEW.BOEngineServiceTCP;
using BOADMIN_NEW.Cls;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using System.Globalization;
using System.IO;
using XLSExportDemo;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Tick margin main
    /// </summary>
    public partial class uctlTickManagerMain : UserControl
    {
        DS4HistoricalData _objDS4HistoricalData = new DS4HistoricalData();
        string _periodicity = string.Empty;
        TreeNode _clickedNode;

        public uctlTickManagerMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Tick manager cell mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvTickManager_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridView.HitTestInfo hInfo = ui_ndgvTickManager.HitTest(, e.Y);
            if (e.RowIndex>= 0)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    frmCommonContainer objfrmCommonContainer = new frmCommonContainer();
                    uctlTickChild objuctlTickChild = new uctlTickChild();
                    objfrmCommonContainer.ClientSize = objuctlTickChild.Size;
                    objuctlTickChild.OnHDataUpdate += new Action<clsHistoricalData>(objuctlTickChild_OnHDataUpdate);
                    objuctlTickChild.Periodicity = _periodicity;
                    objuctlTickChild.SetValues(ui_ndgvTickManager.Rows[e.RowIndex]);
                    objfrmCommonContainer.Controls.Add(objuctlTickChild);
                    objfrmCommonContainer.ShowDialog();
                }
            }
        }

        void objuctlTickChild_OnHDataUpdate(clsHistoricalData historyData)
        {
            
        }

        /// <summary>
        /// Ticker manager main handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlTickManagerMain_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string,Dictionary<string,string[]>> tgSymbolsInfo in Cls.clsMasterInfoManager.INSTANCE.DDTGSymbolsInfo)
            {
                ui_ntvTickManager.Nodes.Add(tgSymbolsInfo.Key, tgSymbolsInfo.Key);
                foreach (KeyValuePair<string, string[]> item in tgSymbolsInfo.Value)
                {
                    ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes.Add(item.Key, item.Key);
                    foreach (string symbol in item.Value)
                    {
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes.Add(symbol, symbol);
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("1 Minute (M1)", "1 Minute (M1)");
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("5 Minute (M1)", "5 Minute (M5)");
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("10 Minute (M1)", "10 Minute (M10)");
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("15 Minute (M1)", "15 Minute (M15)");
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("30 Minute (M1)", "30 Minute (M30)");
                        ui_ntvTickManager.Nodes[tgSymbolsInfo.Key].Nodes[item.Key].Nodes[symbol].Nodes.Add("60 Minute (M1)", "60 Minute (M60)");
                    }
                }
            }
        }

        /// <summary>
        /// tick manager double
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntvTickManager_DoubleClick(object sender, EventArgs e)
        {
            _clickedNode = ((TreeView)(sender)).SelectedNode;
            _clickedNode.ForeColor = Color.Red;
            if (((TreeView)(sender)).SelectedNode == null)
                return;
            if (((TreeView)(sender)).SelectedNode.Nodes.Count == 0)
            {
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetHistoricalDataCompleted += _objLoginClient_GetHistoricalDataCompleted;
                string symbolName=((TreeView)(sender)).SelectedNode.Parent.Text;
                switch (((TreeView)(sender)).SelectedNode.Text.Substring(0,2).Trim())
                {
                    case "1":
                        _periodicity = "1Min";
                        break;
                    case "5":
                        _periodicity = "5Min";
                        break;
                    case "10":
                        _periodicity = "10Min";
                        break;
                    case "15":
                        _periodicity = "15Min";
                        break;
                    case "30":
                        _periodicity = "30Min";
                        break;
                    case "60":
                        _periodicity = "60Min";
                        break;
                }
                clsProxyClassManager.INSTANCE._objBOEngineClient.GetHistoricalDataAsync(clsGlobal.userIDPwd,"AUDUSD", _periodicity, 100,null,OperationTypes.GET);
            }
        }

        /// <summary>
        /// historical data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _objLoginClient_GetHistoricalDataCompleted(object sender, GetHistoricalDataCompletedEventArgs e)
        {
            Action setcolor = () =>
                {
                    _clickedNode.ForeColor = Color.Green;
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(setcolor);
            }
            else
            {
                setcolor();
            }

            if (e.Result.ToList().Count == 0)
            {
                _objDS4HistoricalData.dtHistoricalData.Clear();
                _objDS4HistoricalData.Clear();
                return;
            }
            DS4HistoricalData.dtHistoricalDataRow row = _objDS4HistoricalData.dtHistoricalData.FindByID(e.Result[0].ID);

            if (row != null)
            {
                row.Date = clsUtility.GetDate(e.Result[0].FeedTime);
                row.Open = clsUtility.GetDouble(e.Result[0].Open);
                row.High = clsUtility.GetDouble(e.Result[0].High);
                row.Low = clsUtility.GetDouble(e.Result[0].Low);
                row.Close = clsUtility.GetDouble(e.Result[0].Close);
                row.Volume = clsUtility.GetLong(e.Result[0].Volume);
            }
            else
            {
                _objDS4HistoricalData.dtHistoricalData.Clear();
                _objDS4HistoricalData.Clear();
                foreach (clsHistoricalData item in e.Result)
                {
                    _objDS4HistoricalData.dtHistoricalData.AdddtHistoricalDataRow(item.ID, item.SymbolName, item.FeedTime, item.Open, item.High, item.Low, item.Close,
                        item.Volume);
                }
                Action A = () =>
                {
                    ui_ndgvTickManager.DataSource = _objDS4HistoricalData.dtHistoricalData;
                    StyleGrid();
                    ui_ndgvTickManager.Refresh();
                };
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(A);
                }
                else
                {
                    A();
                }
            }

        }

        private void StyleGrid()
        {
            ui_ndgvTickManager.Columns["ID"].Visible = false;
            ui_ndgvTickManager.Columns["SymbolName"].HeaderText = "Symbol Name";
        }

        private void ui_nbtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            objSaveFileDialog.DefaultExt = ".xls";
            DialogResult objDialogResult = objSaveFileDialog.ShowDialog();
            if (objDialogResult == DialogResult.OK)
            {
                ExportData(objSaveFileDialog.FileName);
                Cls.clsDialogBox.ShowErrorBox("Data Successfully Exported","Tick Manager",false);
            }
        }

        /// <summary>
        /// exports data into file
        /// </summary>
        /// <param name="fileName"></param>
        public void ExportData(string fileName)
        {
            var document = new ExcelDocument { UserName = "Vijay", CodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage };
            document.ColumnWidth(0, 120);
            document.ColumnWidth(1, 80);
            // Storing header part in Excel
            for (int i = 0; i < ui_ndgvTickManager.Columns.Count; i++)
            {
                if (ui_ndgvTickManager.Columns[i].Visible == true)
                {
                    document[0, i].Value = ui_ndgvTickManager.Columns[i].HeaderText;
                    document[0, i].Font = new Font("Tahoma", 10, FontStyle.Bold);
                    document[0, i].ForeColor = ExcelColor.DarkRed;
                    document[0, i].Alignment = Alignment.Centered;
                    document[0, i].BackColor = ExcelColor.Silver;
                }
            }
            // Storing Each row and column value to excel sheet
            for (int i = 0; i < ui_ndgvTickManager.Rows.Count; i++)
            {
                for (int j = 0; j < ui_ndgvTickManager.Columns.Count; j++)
                {
                    if (ui_ndgvTickManager.Rows[i].Cells[j].Value != null && ui_ndgvTickManager.Rows[i].Cells[j].Visible == true)
                        document.Cell(i + 1, j).Value = ui_ndgvTickManager.Rows[i].Cells[j].Value.ToString();
                }
            }
            var stream = new FileStream(fileName, FileMode.Create);
            document.Save(stream);
            stream.Close();
        }
    }
}
