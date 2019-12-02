//M4 Trading Platform - copyright Modulus Financial Engineering, Inc. - all rights reserved.
//http://www.modulusfe.com

//NOTICE: TradeScript(tm) is provided under a separate license. Email sales@modulusfe.com for details.
using System.Windows.Forms;
//using FundXchange.Model.AuthenticationService;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using Nevron.UI.WinForm.Controls;
using TradeScriptLib;
//using M4Controls.Classes;
using System.IO;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.Controllers;
//using FundXchange.Infrastructure;
//using FundXchange.Application.Scanner;
using System.Collections;
using System.Media;
//using FundXchange.Model.AlertService;
//using FundXchange.Model.Gateways;
using PALSA.Cls;
using PALSA.FrmScanner;
using M4;

namespace PALSA.uctl
{
    public partial class ctlScanner //: IDataSubscriber
    {
        #region "Initialization and Members"
        private string endStr = ")";
        private string startStr = " (";
        private bool _dialogVisible, _stopScannerInitialization;
        private readonly List<string> _symbols;
        private List<string> _script;
        private List<string> _scriptName;
        private List<string> _ScriptType;
        private string _tempScript;
        private readonly List<ChartSelection> _scannerFrequency;
        Dictionary<string, string> sound;
        Dictionary<string, List<string>> FilterCount;
        private FrmMain _mainFormInstance;
        //private ctlData _dataManagerInstance;
        //private List<ScannerDTO> _userScanners;
        private readonly List<ScannerItem> _scannerItems = new List<ScannerItem>();
        TextWriter sw;

        //private readonly UserDTO _User;
        private readonly AlertController _Controller;

        //###############
        //Patents pending. Use of this scanning code outside of the M4 application is a violation of the license agreement.
        //###############
        private TradeScriptLib.Alert withEventsField_oScript;
        private TradeScriptLib.Alert oScript
        {
            get { return withEventsField_oScript; }
            set
            {
                if (withEventsField_oScript != null)
                {
                    withEventsField_oScript.ScriptError -= oScript_ScriptError;
                }
                withEventsField_oScript = value;
                if (withEventsField_oScript != null)
                {
                    withEventsField_oScript.ScriptError += oScript_ScriptError;
                }
            }
        }

        public ctlScanner(FrmMain oMain)
        {
            //_User = IoC.Resolve<FundXchange.Model.Gateways.UserDTO>();
            _Controller = new AlertController();//(_User.Account.UserId);
            sound = new Dictionary<string, string>();
            FilterCount = new Dictionary<string, List<string>>();
            Resize += ctlScanner_Resize;
            Load += ctlScanner_Load;
            InitializeComponent();
            _scannerFrequency = new List<ChartSelection>();
            _mainFormInstance = oMain;
            //_dataManagerInstance = oData;
            _symbols = new List<string>();
            _script = new List<string>();
            _scriptName = new List<string>();
            _ScriptType = new List<string>();
            //Namo 22 March  
            //oScript = new TradeScriptLib.Alert();
            //oScript.License = "XRT93NQR79ABTW788XR48";
            InitializeGrid();
        }

        public void closeScanner()
        {
            for (int i = 0; i < _scannerItems.Count; i++)
            {
                _scannerItems[i].Dispose();
                _scannerItems[i] = null;
            }
            _scannerItems.Clear();
 
        }

        private void InitializeGrid()
        {
            grdResults.RowTemplate.Height = 28;
            grdResults.ShowCellToolTips = false;
            grdResults.GridColor = Color.FromArgb(50, 50, 50);

            grdResults.RowsDefaultCellStyle.SelectionForeColor = Color.Yellow;

            grdResults.ForeColor = Color.Black;

            grdResults.DefaultCellStyle.ForeColor = Color.Black;
            grdResults.RowTemplate.Height = 30;

            DataGridViewTextBoxColumn tradeTime = new DataGridViewTextBoxColumn();
            {
                tradeTime.HeaderText = "Trade Time";
                tradeTime.Name = "Trade Time";
                tradeTime.ReadOnly = true;
                tradeTime.Visible = false;
            }
            grdResults.Columns.Add(tradeTime);
            DataGridViewTextBoxColumn closedTime = new DataGridViewTextBoxColumn();
            {
                closedTime.HeaderText = "Closed Time";
                closedTime.Name = "Closed Time";
                closedTime.ReadOnly = true;
                closedTime.Visible = false;
            }
            grdResults.Columns.Add(closedTime);
            DataGridViewTextBoxColumn symbolCol = new DataGridViewTextBoxColumn();
            {
                symbolCol.HeaderText = "Symbol";
                symbolCol.Name = "Symbol";
                symbolCol.ReadOnly = true;
            }
            grdResults.Columns.Add(symbolCol);

            DataGridViewTextBoxScannerColorColumn lastCol = new DataGridViewTextBoxScannerColorColumn();
            {
                lastCol.HeaderText = "Last";
                lastCol.Name = "Last";
                lastCol.ReadOnly = true;
            }
            grdResults.Columns.Add(lastCol);

            DataGridViewBarGraphColumn volumeCol = new DataGridViewBarGraphColumn();
            {
                volumeCol.HeaderText = "Volume";
                volumeCol.Name = "Volume";
                volumeCol.ReadOnly = true;
                volumeCol.SortMode = DataGridViewColumnSortMode.Automatic;
                volumeCol.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            }
            grdResults.Columns.Add(volumeCol);
            //Since alerttime is added at run time so comment it.
            //DataGridViewTextBoxScannerColorColumn alertTime = new DataGridViewTextBoxScannerColorColumn();
            //{
            //    alertTime.HeaderText = "Alert Time";
            //    alertTime.Name = "Alert Time";
            //    alertTime.ReadOnly = true;
            //}
            //grdResults.Columns.Add(alertTime);

            DataGridViewButtonColumn tradeCol = new DataGridViewButtonColumn();
            {
                tradeCol.HeaderText = "Trade";
                tradeCol.Name = "Trade";
                tradeCol.Text = "Trade";
                tradeCol.ToolTipText = "Enter Order";
                tradeCol.DefaultCellStyle.NullValue = "Trade";
                tradeCol.UseColumnTextForButtonValue = true;
                tradeCol.Visible = false;
            }
            grdResults.Columns.Add(tradeCol);

            DataGridViewButtonColumn chartCol = new DataGridViewButtonColumn();
            {
                chartCol.HeaderText = "Chart";
                chartCol.Name = "Chart";
                chartCol.Text = "Chart";
                chartCol.UseColumnTextForButtonValue = true;
            }
            grdResults.Columns.Add(chartCol);

            DataGridViewButtonColumn settingsCol = new DataGridViewButtonColumn();
            {
                settingsCol.HeaderText = "Settings";
                settingsCol.Name = "Settings";
                settingsCol.Text = "Settings";
                settingsCol.ToolTipText = "Edit Settings";
                settingsCol.DefaultCellStyle.NullValue = "Settings";
                settingsCol.UseColumnTextForButtonValue = true;
            }
            grdResults.Columns.Add(settingsCol);

            DataGridViewImageButtonColumn lockCol = new DataGridViewImageButtonColumn();
            {
                lockCol.HeaderText = "Lock Script";
                lockCol.Name = "Locked";
            }
            grdResults.Columns.Add(lockCol);

            DataGridViewImageButtonColumn startCol = new DataGridViewImageButtonColumn();
            {
                startCol.HeaderText = "Pause";
                startCol.Name = "Start";
                startCol.ToolTipText = "Start Scan";
            }
            grdResults.Columns.Add(startCol);
        }

        public TradeScriptLib.Alert GetTSAlertObject(string Symbol)
        {
            ScannerItem scannerItem;
            if (TryGetScannerItemFor(Symbol, out scannerItem))
            {
                return scannerItem.AlertObject;
            }
            return null;
        }
        private bool TryGetScannerItemFor(string symbol, out ScannerItem scannerItem)
        {
            scannerItem = _scannerItems.FirstOrDefault(si => si.Symbol.ToLower() == symbol.ToLower());
            return scannerItem != null;
        }
        private bool TryGetScannerItemFor(string symbol, string alertName, out ScannerItem scannerItem)
        {
            scannerItem = null;
            foreach (ScannerItem ScannerItem in _scannerItems.ToList())
            {
                if (symbol.ToLower() == ScannerItem.Symbol.ToLower() && alertName == ScannerItem.AlertObject.AlertName)
                    scannerItem = ScannerItem;
            }
            return scannerItem != null;
        }
        //Loads all required data into memory. This function must be called first.
        public bool LoadAllSymbolsIntoMemory()
        {
            //Verify the input and check script for errors
            //// Kuldeep if (_dataManagerInstance == null) return false;
            //if (!TestScripts()) return false;
            //ToggleControls(false);

            //Clear everything
            for (int i = 0; i < _scannerItems.Count; i++)
            {
                _scannerItems[i].Dispose();
                _scannerItems[i] = null;
            }
            _scannerItems.Clear();

            grdResults.Rows.Clear();
            List<IEnumerable<BarDataNew>> lstbars = new List<IEnumerable<BarDataNew>>();
            Dictionary<string, string> barChart = new Dictionary<string, string>();
            DataGridViewBarGraphColumn volumeCol = grdResults.Columns["Volume"] as DataGridViewBarGraphColumn;
            if ((volumeCol != null))
            {
                volumeCol.MaximumValue = 0;
            }

            //Load history for all symbols into memory
            //pnlProgress.Cursor = Cursors.WaitCursor;
            //pnlProgress.Visible = false;//true;
            //ProgressBar1.Properties.Maximum = _symbols.Count;
            //lblInfo.Text = "Printing scanner, please wait...";
            List<string> symbolFailed = new List<string>();




            for (int n = 0; n <= _symbols.Count - 1; n++)
            {

                if (!_stopScannerInitialization)
                {
                    ScannerItem scannerItem;
                    if (TryGetScannerItemFor(_symbols[n], out scannerItem))
                    {
                        //lblInfo.Text = "Invalid symbol";
                        symbolFailed.Add(_symbols[n]);
                        continue;
                    }

                    //lblInfo.Text = "Printing scanner, please wait...";
                    //ProgressBar1.Properties.Value = n;
                    //lblSymbol.Text = _symbols[n];
                    Application.DoEvents();

                    barChart.Clear();
                    lstbars.Clear();
                    //foreach (string scriptDeatil in _script)
                    //{
                    IEnumerable<BarDataNew> bars = new List<BarDataNew>();
                    for (int i = 0; i < _script.Count; i++)
                    {
                        string strBars = _scannerFrequency[i].Bars.ToString() + _scannerFrequency[i].Interval.ToString() + _scannerFrequency[i].Periodicity.ToString();
                        if (!barChart.ContainsKey(strBars))
                        {
                            barChart.Add(strBars, _symbols[n]);
                            bars = GetBarData_For(_symbols[n], _scannerFrequency[i]);
                            if (bars == null || bars.Count() < 3)
                            {
                                //lblInfo.Text = "Failed load symbol ";
                                symbolFailed.Add(_symbols[n]);
                                break;
                            }
                        }

                        scannerItem = CreateScannerItem(_symbols[n], bars, _script[i], _scriptName[i] + "(" + _ScriptType[i] + ")", _scannerFrequency[i]);
                        _scannerItems.Add(scannerItem);
                        lstbars.Add(bars);

                        //_Controller.RegisterScanInstrument(_symbols[n],Per
                    }
                    if (lstbars.Count < 1)
                        continue;
                    InsertNewScannerItemRow(lstbars, _symbols[n]);
                }

            }
            _stopScannerInitialization = false;
            //pnlProgress.Visible = false;
            //pnlProgress.Cursor = Cursors.Arrow;
            ToggleControls(true);
            //cmdEditScript.Enabled = true;

            if (symbolFailed.Count > 0)
            {
                string message = "Failed load symbols: " + symbolFailed[0];
                for (int i = 1; i < symbolFailed.Count; i++)
                    message += ", " + symbolFailed[i];

                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (ScannerItem item in _scannerItems)
            {
                item.Start();
            }

            return true;
        }

        private IEnumerable<BarDataNew> GetBarData_For(string symbol, ChartSelection scannerFrequency)
        {
            PeriodEnum prd = Utils.GetPeriodFromPeriodicity(scannerFrequency.Periodicity);
            int period = (int)prd;
            int intervl = scannerFrequency.Interval;
            string Bars = scannerFrequency.Bars.ToString();
            return GetOHLCData(symbol, period, intervl, Bars);
            //Kuldeep
            //return _dataManagerInstance.GetHistory(symbol.ToUpper().Trim(), this, scannerFrequency.Periodicity, scannerFrequency.Interval, scannerFrequency.Bars).ToArray();
        }

        private IEnumerable<BarDataNew> GetOHLCData(string symbol, int period, int intervl, string Bars)
        {
            //ClientDLL_Model.Cls.Market.LstOHLC objOHLC = new ClientDLL_Model.Cls.Market.LstOHLC();
            List<OHLC> _lstOHLC = new List<OHLC>();
            _lstOHLC = clsTWSDataManagerJSON.INSTANCE.GetOHLC(DateTime.UtcNow, symbol, intervl, Bars, period);
            if (_lstOHLC.Count > 0)
            {
                List<BarDataNew> snapshots = TransformToBarData(_lstOHLC);
                return snapshots;
            }
            return new List<BarDataNew>();
        }

        private List<BarDataNew> TransformToBarData(List<OHLC> ohlc)
        {
            List<BarDataNew> barData = new List<BarDataNew>();
            DateTime now = DateTime.UtcNow;
            DateTime startOfTradeDay = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0);


            foreach (var item in ohlc)
            {
                DateTime convertedDT = item._OHLCTime;
                item._OHLCTime = convertedDT;
            }


            TimeSpan dtDiff = Convert.ToDateTime(ohlc[0]._OHLCTime) - Convert.ToDateTime(ohlc[1]._OHLCTime);

            //List<OHLC> lstOHLC = GetUpdatedOHLC(ohlc);
            foreach (var item in ohlc)
            {
                BarDataNew bar = new BarDataNew();

                bar.OpenPrice = item._Open;
                bar.ClosePrice = item._Close;
                bar.HighPrice = item._High;
                bar.LowPrice = item._Low;
                bar.StartDateTime = Convert.ToDateTime(item._OHLCTime);
                bar.CloseDateTime = Convert.ToDateTime(item._OHLCTime).Subtract(dtDiff);

                bar.TradeDateTime = bar.CloseDateTime;
                bar.Volume = item._Volume;

                //if (bar.CloseDateTime >= startOfTradeDay)
                //{
                //    bar.CloseSequenceNumber = candlestick.CloseSequenceNumber;
                //}
                barData.Add(bar);
            }

            return barData;
        }

        private List<OHLC> GetUpdatedOHLC(List<OHLC> ohlc)
        {
            TimeSpan dtDiff = Convert.ToDateTime(ohlc[0]._OHLCTime) - Convert.ToDateTime(ohlc[1]._OHLCTime);
            DateTime x = DateTime.UtcNow;
            //Namo 21 March
            //for (int i = ohlc.Count - 1; i >= 0; i--)
            //{
            //    ohlc[i]._OHLCTime = x.ToString();
            //    x = x.Add(dtDiff);
            //}
            return ohlc;
        }

        private IEnumerable<BarDataNew> GetLastIntervalBarData_(string symbol, int Interval, Periodicity Periodicity)
        {
            PeriodEnum prd = Utils.GetPeriodFromPeriodicity(Periodicity);
            int period = (int)prd;

            return GetOHLCData(symbol, period, Interval, "10");
            //Kuldeep
           // return _dataManagerInstance.GetHistory(symbol.ToUpper().Trim(), this, Periodicity, Interval, 10).ToArray();
        }

        void scannerItem_OnDataRequired(ScannerItem scannerItem)
        {
            //lock (sw)
            //{
            //    sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\Logs\\Timer.txt", true);
            //    sw.WriteLine("Timer calls scanner "+scannerItem.Symbol.ToString() + "    " + DateTime.UtcNow.ToString());
            //    sw.Close();  
            //}

            scannerItem.Stop();
            //scannerItem.AlertObject.ClearRecords();
            scannerItem.AlertObject.Alert -= OnAlert;

            var bars = GetLastIntervalBarData_(scannerItem.Symbol, scannerItem.Interval, scannerItem.ChartPeriodicity);

            BarDataNew BarData_ = new BarDataNew();
            int barVolume = 0;

            int index = 0;
            double jDate = scannerItem.AlertObject.ToJulianDate(bars.ElementAt(index).TradeDateTime.Year, bars.ElementAt(index).TradeDateTime.Month, bars.ElementAt(index).TradeDateTime.Day, bars.ElementAt(index).TradeDateTime.Hour, bars.ElementAt(index).TradeDateTime.Minute, bars.ElementAt(index).TradeDateTime.Second, bars.ElementAt(index).TradeDateTime.Millisecond);
            if (!scannerItem.AlertObject.GetRecordByJDate(jDate, ref BarData_.OpenPrice, ref BarData_.HighPrice, ref BarData_.LowPrice, ref BarData_.ClosePrice, ref barVolume))
            {
                scannerItem.AlertObject.AppendRecord(jDate, bars.ElementAt(index).OpenPrice, bars.ElementAt(index).HighPrice, bars.ElementAt(index).LowPrice, bars.ElementAt(index).ClosePrice, (int)bars.ElementAt(index).Volume);
                AppendLatestBar(bars.ElementAt(index), scannerItem.Symbol);
            }
            scannerItem.AlertObject.Alert += OnAlert;
            scannerItem.Start();


        }

        #endregion

        #region "Controls / Scanning"

        public bool m_Load = true;

        private void ctlScanner_Load(Object sender, EventArgs e)
        {
            //Kuldeep
            //if (!m_Load) return;
            //_userScanners = new List<ScannerDTO>();

            //foreach (ScannerDTO scanner in _User.Scanners)
            //{
            //    if (!_userScanners.Contains(scanner))
            //        _userScanners.Add(scanner);
            //}

            //LoadScanners(null);
        }

        private void ToggleControls(bool enableScanCommands)
        {
            //grpSaveLoadScanner.Enabled = enableScanCommands;
            //cmdScanner.Enabled = enableScanCommands;
        }

        private void cmdDelete_Click(System.Object sender, System.EventArgs e)
        {
            //DialogResult confirmation = MessageBox.Show("Are you certain you want to delete the selected scanner?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (confirmation == DialogResult.Yes)
            //{
            //    List<FundXchange.Model.AuthenticationService.ScannerDTO> scannerToRemove;
            //    if (TryGetScannerList(cboScanners.Text, out scannerToRemove))
            //    {
            //        _Controller.RemoveScanner(cboScanners.Text);

            //        var userScanners = _User.Scanners.ToList();
            //        foreach (ScannerDTO item in scannerToRemove)
            //        {
            //            userScanners.Remove(item);
            //            _userScanners.Remove(item);
            //        }
            //        _User.Scanners = userScanners.ToArray();


            //    }

            //    LoadScanners(null);
            //}
        }

        private void ctlScanner_Resize(object sender, System.EventArgs e)
        {
            grdResults.Height = Height - grdResults.Top - 10;
            grdResults.Left = 0;
            grdResults.Width = Width;
        }

        //Allows the user to enter a new scrpit that will be applied to all unlocked symbols
        private void cmdEditScript_Click(System.Object sender, System.EventArgs e)
        {
            //using (frmScannerScript settings = new frmScannerScript(_script[0].ToString()))
            //{
            //    settings.HeaderText = "Script (will be applied to all unlocked symbols)";

            //    DialogResult dialogResult = settings.ShowDialog();
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        _script[0] = _tempScript;
            //        //Apply script to each unlocked symbol            
            //        for (int n = 0; n <= grdResults.Rows.Count - 1; n++)
            //        {
            //            string symbol = grdResults.Rows[n].Cells["Symbol"].Value.ToString();
            //            bool locked = ((DataGridViewImageButtonCell)grdResults.Rows[n].Cells["Locked"]).Checked;

            //            ScannerItem scannerItem;
            //            if (TryGetScannerItemFor(symbol, out scannerItem))
            //            {
            //                if (!scannerItem.IsLocked)
            //                {
            //                    scannerItem.AlertObject.AlertScript = _script[0].ToString();
            //                }
            //            }
            //        }
            //    }
            //    else if (dialogResult == DialogResult.Abort)
            //    {
            //        _mainFormInstance.OpenURL(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Documents\TradeScript.pdf"), "TradeScript Help");
            //    }
            //}
        }

        private void grdResults_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //Kuldeep
                //if (grdResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                //    GlobalDeclarations.ActiveSymbol = grdResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                return;
            if (grdResults.SelectedRows.Count <= 0) return;

            string symbol = grdResults.SelectedRows[0].Cells["Symbol"].Value.ToString();

            List<ScannerItem> scannerItemlist;
            if (TryGetScannerItemListFor(symbol, out scannerItemlist))
            {
                //Trade
                if (e.ColumnIndex == 5)
                {
                    grdResults.Rows[e.RowIndex].Selected = true;
                    //MessageBox.Show("You will fill order", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //m_frmMain.EnterOrder(symbol);

                }
                //Chart
                else if (e.ColumnIndex == 6)
                {

                    ToggleControls(true);
                    grdResults.Cursor = Cursors.WaitCursor;
                    grdResults.Rows[e.RowIndex].Selected = true;
                    ChartSelection selection = GetSelection(symbol);
                    //Kuldeep
                    _mainFormInstance.CreateNewChart(selection);
                    grdResults.Cursor = Cursors.Arrow;
                    ToggleControls(true);

                }
                //Change the script for this individual alert
                else if (e.ColumnIndex == 7)
                {

                    //edit form
                    using (frmScannerScriptEdit editor = new frmScannerScriptEdit())
                    {
                        //settings.HeaderText = string.Format("{0} script settings", symbol);
                        for (int i = 0; i < scannerItemlist.Count; i++)
                        {

                            editor.ScriptNames.Add(scannerItemlist[i].AlertObject.AlertName);
                            editor.Scripts.Add(scannerItemlist[i].AlertObject.AlertScript);
                        }
                        DialogResult result = editor.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            //Kuldeep
                            //_mainFormInstance.OpenURL(
                            //    Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                            //                 @"Documents\TradeScript.pdf"), "TradeScript Help");
                            return;
                        }
                        else if (result == DialogResult.OK)
                        {
                            for (int i = 0; i < scannerItemlist.Count; i++)
                            {
                                for (int j = 0; j < editor.ScriptNames.Count; j++)
                                {
                                    if (scannerItemlist[i].AlertObject.AlertName == editor.ScriptNames[j])
                                        scannerItemlist[i].AlertObject.AlertScript = editor.Scripts[j];
                                }

                            }


                            DataGridViewImageButtonCell cell =
                                grdResults.Rows[e.RowIndex].Cells["Start"] as DataGridViewImageButtonCell;
                            if (cell == null) return;
                            cell.Checked = false;
                        }
                    }
                }
                //Lock/unlock script to control effects of the "Edit Script" button
                else if (e.ColumnIndex == 8)
                {
                    foreach (ScannerItem item in scannerItemlist)
                    {
                        if (item.IsLocked)
                        {
                            item.Unlock();
                        }
                        else
                            item.Lock();
                    }
                }
                //

                    //Play/pause
                else if (e.ColumnIndex == 9)
                {
                    DataGridViewImageButtonCell cell =
                        grdResults.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewImageButtonCell;
                    if (cell == null) return;
                    bool pause = cell.Checked;
                    foreach (ScannerItem item in scannerItemlist)
                    {
                        if (pause)
                        {

                            item.Stop();

                            //scannerItem.Stop();
                        }
                        else
                        {

                            item.Start();
                        }
                        //scannerItem.Start();
                    }

                }
                else if (e.ColumnIndex > 9)
                {
                    if (grdResults.Columns[e.ColumnIndex].Name != "Filter")
                    {
                        ToggleControls(true);
                        grdResults.Cursor = Cursors.WaitCursor;
                        grdResults.Rows[e.RowIndex].Selected = true;
                        ChartSelection selection = GetSelection(symbol, _scannerFrequency[e.ColumnIndex - 10]);
                        //Kuldeep
                        //_mainFormInstance.CreateNewChart(selection);
                        grdResults.Cursor = Cursors.Arrow;
                        ToggleControls(true);
                    }
                }
            }
        }

        private bool TryGetScannerItemListFor(string symbol, out List<ScannerItem> scannerItemlist)
        {
            scannerItemlist = new List<ScannerItem>();
            foreach (ScannerItem scannerItem in _scannerItems.ToList())
            {
                if (symbol.ToLower() == scannerItem.Symbol.ToLower())
                    scannerItemlist.Add(scannerItem);

            }
            return scannerItemlist.Count != 0;
        }

        #endregion

        #region "TradeScript"

        private void OnAlert(string Symbol, string AlertName)
        {
            DataGridViewRow row;
            List<string> FilterAlertNames = null;
            if (TryFindScannerGridRow(Symbol, out row))
            {
                //add sound
                if (!FilterCount.ContainsKey(Symbol))
                {
                    FilterAlertNames = new List<string>();
                    FilterCount.Add(Symbol, FilterAlertNames);
                    FilterCount[Symbol].Add(AlertName);
                }
                else
                {
                    if (!FilterCount[Symbol].Contains(AlertName))
                    {
                        FilterCount[Symbol].Add(AlertName);
                    }
                }
                if (FilterCount[Symbol].Count == _script.Count)
                {
                    row.Cells["Filter"].Value = true.ToString();
                    if (sound["Filter"] != string.Empty)
                    {
                        SoundPlayer playerFilter = new SoundPlayer(sound["Filter"]);
                        playerFilter.Play();
                    }
                }

                row.Cells[AlertName].Value = row.Cells["Trade Time"].Value;

                //sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\Logs\\Scaaner.txt", true);
                //sw.WriteLine("Alert time of " + Symbol + "    " + row.Cells["Trade Time"].Value + " and alert is " + AlertName + " on " + DateTime.UtcNow.ToString());
                //sw.Close();
                System.Threading.Thread.Sleep(200);
                if (sound[AlertName] != string.Empty)
                {
                    SoundPlayer player = new SoundPlayer(sound[AlertName]);
                    player.Play();
                }
            }
        }

        private void oScript_ScriptError(string symbol, string alertName, string description)
        {
            if (_dialogVisible) return;
            _dialogVisible = true;

            ScannerItem scannerItem;
            if (TryGetScannerItemFor(symbol, alertName, out scannerItem))
            {
                //Prevent the error from occuring over and over
                if (scannerItem.AlertObject == null) return;


                //Find and highlight the record
                int row = 0;
                for (int n = 0; n <= grdResults.Rows.Count - 1; n++)
                {
                    if (grdResults.Rows[n].Cells["Symbol"].Value.ToString() == symbol)
                    {
                        row = n;
                        break;
                    }
                }

                DataGridViewImageButtonCell cell = grdResults.Rows[row].Cells["Start"] as DataGridViewImageButtonCell;
                if (cell == null) return;

                _tempScript = scannerItem.AlertObject.AlertName;
                //If not already paused
                if (string.IsNullOrEmpty(scannerItem.AlertObject.AlertName))
                {
                    _tempScript = scannerItem.AlertObject.AlertScript;
                    scannerItem.AlertObject.AlertName = scannerItem.AlertObject.AlertScript;
                    //Using AlertName as a Tag
                    scannerItem.AlertObject.AlertScript = "";
                    //Pause
                    cell.Checked = true;
                }

                //Disply the error message
                if (!string.IsNullOrEmpty(oScript.ScriptHelp))
                {
                    if (
                        MessageBox.Show(
                            "Your script generated an error:" + '\n' + description + '\n' +
                            "Would you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(oScript.ScriptHelp, symbol, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your script generated an error:" + '\n' + description, symbol, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }

                //Show edit dialog
                //if (string.IsNullOrEmpty(scannerItem.AlertObject.AlertScript))
                //{
                //    _tempScript = scannerItem.AlertObject.AlertName;
                //}
                //else
                //{
                //    
                //}
                _tempScript = scannerItem.AlertObject.AlertScript;
                using (frmScannerScript settings = new frmScannerScript(_tempScript))
                {
                    settings.HeaderText = string.Format("{0} script settings", symbol);
                    DialogResult result = settings.ShowDialog();
                    if (result == DialogResult.Abort)
                    {
                        //m_frmMain.OpenURL("http://www.modulusfe.com/TradeScript/TradeScript.pdf", "TradeScript Help");
                        
                        //Kuldeep
                        //_mainFormInstance.OpenURL(
                        //    Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Documents\TradeScript.pdf"),
                        //    "TradeScript Help");
                        return;
                    }
                    if (result == DialogResult.OK)
                    {
                        scannerItem.AlertObject.AlertScript = this._tempScript;
                        scannerItem.AlertObject.AlertName = alertName;
                        cell.Checked = false;
                        //Script is running now
                    }
                    _dialogVisible = false;
                }
            }
        }

        //Checks the scripts for errors
        private bool TestScripts()
        {
            TradeScriptLib.Validate script = new TradeScriptLib.Validate();
            script.License = "XRT93NQR79ABTW788XR48";
            foreach (string scriptDeatil in _script.ToList())
            {
                string err = script.Validate(scriptDeatil);
                if (!string.IsNullOrEmpty(err))
                {
                    if (!string.IsNullOrEmpty(script.ScriptHelp))
                    {
                        if (MessageBox.Show("Your script" + scriptDeatil + "generated an error:" + '\n' + err.Replace("Error: ", "") + '\n' + "Would you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your script" + scriptDeatil + " generated an error:" + '\n' + err.Replace("Error: ", ""), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return true;
                }
            }
            return true;



        }

        //Get the user inputed selection information
        private ChartSelection GetSelection(string Symbol)
        {
            ChartSelection selection = new ChartSelection();
            selection.Periodicity = _scannerFrequency[0].Periodicity;
            selection.Interval = _scannerFrequency[0].Interval;
            selection.Bars = _scannerFrequency[0].Bars;
            selection.Symbol = Symbol;

            return selection;

        }
        private ChartSelection GetSelection(string Symbol, ChartSelection _scannerFrequency)
        {
            ChartSelection selection = new ChartSelection();
            selection.Periodicity = _scannerFrequency.Periodicity;
            selection.Interval = _scannerFrequency.Interval;
            selection.Bars = _scannerFrequency.Bars;
            selection.Symbol = Symbol;

            return selection;

        }
        #endregion

        #region "Save/Load"

        // Loads the list of previously saved scanners

        private void LoadScanners(string selectedScanner)
        {
            //cboScanners.Items.Clear();
            //if (selectedScanner != null)
            //    cboScanners.Items.Add(selectedScanner);
            ////foreach (string scanner in _ScannerName)
            ////{
            ////    cboScanners.Items.Add(scanner);
            ////}
            //if (cboScanners.Items.Count > 0)
            //{
            //    cboScanners.SelectedIndex = 0;
            //    if (!String.IsNullOrEmpty(selectedScanner))
            //    {
            //        cboScanners.SelectedItem = selectedScanner;
            //    }
            //}


        }

        private void SaveScanner()
        {
            //Kuldeep
            //if (!string.IsNullOrEmpty(txtScannerName.Text))
            //{
            //    for (int i = 0; i < _script.Count; i++)
            //    {

            //        var newScanner = new FundXchange.Model.AlertService.ScannerDTO()
            //                             {
            //                                 ScannerName = _scriptName[i] + _ScriptType[i],
            //                                 Exchange = FundXchange.Model.Infrastructure.GlobalDeclarations.EXCHANGE,
            //                                 AlertScript = _script[i],
            //                                 BarInterval = _scannerFrequency[i].Interval,
            //                                 BarHistory = _scannerFrequency[i].Bars,
            //                                 Periodicity = Utils.ConvertEnum<Periodicity, FundXchange.Model.AlertService.Periodicities>(_scannerFrequency[i].Periodicity),
            //                                 IsLocked = true,
            //                                 IsPaused = false
            //                             };

            //        _Controller.SaveScanner(newScanner);
            //        ScannerDTO scanner = CreateScannerDTOFrom(newScanner);
            //        AddScannerToUser(scanner);
            //    }
            //}

            //LoadScanners(txtScannerName.Text);
        }

        //Kuldeep
        //private void AddScannerToUser(ScannerDTO scanner)
        //{
        //    ScannerDTO scannerDto = _userScanners.Find(s => s.ScannerName == scanner.ScannerName);
        //    if (scannerDto != null)
        //    {
        //        _userScanners[_userScanners.IndexOf(scannerDto)] = scanner;
        //    }
        //    else
        //    {
        //        _userScanners.Add(scanner);
        //    }
        //}

        //private static ScannerDTO CreateScannerDTOFrom(FundXchange.Model.AlertService.ScannerDTO newScanner)
        //{
        //    return new ScannerDTO()
        //    {
        //        ScannerName = newScanner.ScannerName,
        //        Exchange = newScanner.Exchange,
        //        AlertScript = newScanner.AlertScript,
        //        BarInterval = newScanner.BarInterval,
        //        BarHistory = newScanner.BarHistory,
        //        Periodicity = Utils.ConvertEnum<FundXchange.Model.AlertService.Periodicities, Periodicities>(newScanner.Periodicity),
        //        IsLocked = newScanner.IsLocked,
        //        IsPaused = newScanner.IsPaused
        //    };
        //}

        //Load the selected scanner
        private void cboScanners_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Kuldeep
            //List<ScannerDTO> selectedScanner;
            //if (TryGetScannerList(cboScanners.Text, out selectedScanner))
            //{
            //    for (int i = 0; i < selectedScanner.Count; i++)
            //    {
            //        _script[i] = selectedScanner[i].AlertScript;
            //        _scannerFrequency[i].Interval = selectedScanner[i].BarInterval;
            //        _scannerFrequency[i].Bars = selectedScanner[i].BarHistory;
            //        _scannerFrequency[i].Periodicity = Utils.ConvertEnum<Periodicities, Periodicity>(selectedScanner[i].Periodicity);
            //    }


            //    txtScannerName.Text = cboScanners.Text;
            //    UpdateName(txtScannerName.Text);
            //}
            //else
            //{
            //    for (int i = 0; i < selectedScanner.Count; i++)
            //    {
            //        _script[i] = string.Empty;
            //        _scannerFrequency[i].Interval = 1;
            //        _scannerFrequency[i].Bars = 3;
            //        _scannerFrequency[i].Periodicity = Periodicity.Minutely;
            //    }


            //}
        }

        //Kul
        //private bool TryGetScanner(string scannerName, out ScannerDTO selectedScanner)
        //{
        //    selectedScanner = null;

        //    foreach (var scanner in _userScanners)
        //    {
        //        if (scanner.ScannerName == scannerName)
        //        {
        //            selectedScanner = scanner;
        //            break;
        //        }
        //    }
        //    return selectedScanner != null;
        //}
        //private bool TryGetScannerList(string scannerName, out List<ScannerDTO> selectedScanner)
        //{
        //    selectedScanner = new List<ScannerDTO>();

        //    foreach (var scanner in _userScanners)
        //    {
        //        if (scanner.ScannerName.Substring(0, scannerName.Length) == scannerName)
        //        {
        //            selectedScanner.Add(scanner);
        //        }
        //    }
        //    return selectedScanner.Count != 0;
        //}

        //Updates the Nevron tab text

        public void UpdateName(string Name)
        {
            try
            {
                ctlScanner scan = null;
                //Kul
                //foreach (NUIDocument doc in _mainFormInstance.m_DockManager.DocumentManager.Documents)
                //{
                //    if (doc.Client.Name == "ctlScanner")
                //    {
                //        scan = (ctlScanner)doc.Client;
                //        if (scan.Handle == this.Handle)
                //        {
                //            doc.Text = "Scanner: " + Name;
                //        }
                //    }
                //}
            }
            catch (NullReferenceException)
            {
            }
        }

        private void cmdStopScanner_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stopping the scanner will require a complete re-priming of data if you wish to restart the scanner", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _stopScannerInitialization = true;
                ToggleControls(true);
            }
        }

        private void cmdScanner_Click(object sender, EventArgs e)
        {
            Scanner _scanner = new Scanner();
            using (frmScannerExplorer scannerSettings = new frmScannerExplorer())//Kul(_mainFormInstance))
            {
                //scannerSettings.Bars = _scannerFrequency.Bars;
                //scannerSettings.Interval = _scannerFrequency.Interval;
                //scannerSettings.Periodicity = _scannerFrequency.Periodicity;
                //scannerSettings.ScannerName = txtScannerName.Text;
                DialogResult dialogResult = scannerSettings.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    for (int i = 0; i < _scriptName.Count; i++)
                    {
                        //_Controller.RemoveScanner(_scriptName[i] + _ScriptType[i]);
                        grdResults.Columns.Remove(_scriptName[i] + "(" + _ScriptType[i] + ")");

                    }
                    if (grdResults.Columns.Contains("Filter"))
                        grdResults.Columns.Remove("Filter");

                    //Kul
                    //List<FundXchange.Model.AlertService.ScannerDTO> scannerToRemove = _userScanners;
                    //var userScanners = _User.Scanners.ToList();
                    //foreach (ScannerDTO item in scannerToRemove.ToList())
                    //{
                    //    userScanners.Remove(item);
                    //    _userScanners.Remove(item);
                    //}
                    //_User.Scanners = userScanners.ToArray();                    //delete previous script columns
                    FilterCount.Clear();
                    sound.Clear();
                    _symbols.Clear();
                    _scannerFrequency.Clear();
                    _script.Clear();
                    _scriptName.Clear();
                    _ScriptType.Clear();

                    _scanner = scannerSettings._scanner;
                    foreach (SymbolAttributes symbol in _scanner.Symbols)
                    {
                        string symbolToAdd = symbol.Symbol.Trim().ToUpper();
                        if (!_symbols.Contains(symbolToAdd) && !String.IsNullOrEmpty(symbolToAdd))
                        {
                            _symbols.Add(symbolToAdd);
                        }
                    }

                    //txtScannerName.Text = _scanner.ScannerName;
                    // add new scripts columns
                    for (int i = 0; i < _scanner.Scripts.Count; i++)
                    {
                        _script.Add(_scanner.Scripts[i].Script);
                        _scriptName.Add(_scanner.Scripts[i].ScriptName);
                        _ScriptType.Add(_scanner.Scripts[i].ScriptType);
                        DataGridViewTextBoxScannerColorColumn alertTime = new DataGridViewTextBoxScannerColorColumn();
                        {
                            if (_scanner.Scripts[i].Periodicity == Periodicity.Daily)
                                alertTime.HeaderText = _scriptName[i] + startStr + _scanner.Scripts[i].Interval.ToString() + _scanner.Scripts[i].Periodicity.ToString().Substring(0, 2) + "y" + endStr;
                            else if (_scanner.Scripts[i].Periodicity == Periodicity.Hourly || _scanner.Scripts[i].Periodicity == Periodicity.Weekly)
                            {
                                alertTime.HeaderText = _scriptName[i] + startStr + _scanner.Scripts[i].Interval.ToString() + _scanner.Scripts[i].Periodicity.ToString().Substring(0, 4) + endStr;
                            }
                            else
                                alertTime.HeaderText = _scriptName[i] + startStr + _scanner.Scripts[i].Interval.ToString() + _scanner.Scripts[i].Periodicity.ToString().Substring(0, 3) + endStr;
                            alertTime.Name = _scriptName[i] + "(" + _ScriptType[i] + ")";
                            alertTime.ReadOnly = true;
                            alertTime.DisplayIndex = i + 5;
                        }
                        grdResults.Columns.Add(alertTime);
                        ChartSelection chartSelection = new ChartSelection();
                        chartSelection.Bars = _scanner.Scripts[i].Bars;
                        chartSelection.Periodicity = _scanner.Scripts[i].Periodicity;
                        chartSelection.Interval = _scanner.Scripts[i].Interval;

                        _scannerFrequency.Add(chartSelection);
                        sound.Add(alertTime.Name, _scanner.Scripts[i].SoundPath);
                    }
                    DataGridViewTextBoxScannerColorColumn FilterTime = new DataGridViewTextBoxScannerColorColumn();
                    {
                        FilterTime.HeaderText = "Filter";
                        FilterTime.Name = "Filter";
                        FilterTime.ReadOnly = true;
                        FilterTime.DisplayIndex = _scriptName.Count + 5;
                    }
                    grdResults.Columns.Add(FilterTime);
                    sound.Add(FilterTime.Name, _scanner.FilterSoundPath);
                    SaveScanner();

                    LoadAllSymbolsIntoMemory();
                   
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    //Kul _mainFormInstance.OpenTradeScriptGuide();
                }

            }
        }

        private void txtScannerName_TextChanged(object sender, EventArgs e)
        {
            //Kul
            //List<ScannerDTO> specifiedScanner;
            //if (!TryGetScannerList(txtScannerName.Text, out specifiedScanner))
            //{
            //    if (cboScanners.SelectedIndex > -1)
            //        cboScanners.SelectedIndex = -1;
            //}
        }

        #endregion

        #region "IDataSubscriber"

        //Realtime updates

        public void PriceUpdate(string Symbol, System.DateTime TradeDate, double LastPrice, long Volume)
        {
            //Update the TradeScript object
            Alert oAlert = GetTSAlertObject(Symbol);
            if (oAlert == null) return;
            double j = 0;
            double o = 0;
            double h = 0;
            double l = 0;
            double c = 0;
            int v = 0;
            if (oAlert.GetRecordByIndex(oAlert.RecordCount, ref j, ref o, ref h, ref l, ref c, ref v))
            {
                //Price changed, ok to update bar and run script
                if (c != LastPrice)
                {
                    if (LastPrice > h) h = LastPrice;
                    if (LastPrice < l) l = LastPrice;
                    c = LastPrice;
                    oAlert.EditRecord(j, o, h, l, c, v);
                    oAlert.Evaluate(oAlert.AlertScript);
                }
            }

            //Update the DataGridView
            DataGridViewRow row;
            if (TryFindScannerGridRow(Symbol, out row))
            {
                row.Cells["Trade Time"].Value = TradeDate;
                row.Cells["Last"].Value = LastPrice;
                row.Cells["Volume"].Value = Volume;
            }

        }

        //Bar udpates

        public void BarUpdate(string Symbol, Periodicity BarType, BarDataNew Bar)
        {
            //Finish the old bar
            Alert oAlert = GetTSAlertObject(Symbol);
            if (oAlert == null) return;
            //We are not watching this symbol because it wasn't in the list.
            double j = 0;
            double o = 0;
            double h = 0;
            double l = 0;
            double c = 0;
            int v = 0;
            if (oAlert.GetRecordByIndex(oAlert.RecordCount, ref j, ref o, ref h, ref l, ref c, ref v))
            {
                oAlert.EditRecord(j, Bar.OpenPrice, Bar.HighPrice, Bar.LowPrice, Bar.ClosePrice, (int)Bar.Volume);
            }

            //Add the new bar
            double jDate = oAlert.ToJulianDate(Bar.TradeDateTime.Year, Bar.TradeDateTime.Month, Bar.TradeDateTime.Day, Bar.TradeDateTime.Hour, Bar.TradeDateTime.Minute, Bar.TradeDateTime.Second, Bar.TradeDateTime.Millisecond);
            oAlert.AppendRecord(jDate, Bar.OpenPrice, Bar.HighPrice, Bar.LowPrice, Bar.ClosePrice, (int)Bar.Volume);

            //Update the DataGridView
            DataGridViewRow row;
            if (TryFindScannerGridRow(Symbol, out row))
            {
                row.Cells["Trade Time"].Value = Bar.TradeDateTime;
                row.Cells["Last"].Value = Bar.ClosePrice;
                row.Cells["Volume"].Value = Bar.Volume;
            }
        }

        public System.IntPtr GetHandle()
        {
            if (this.IsHandleCreated)
            {
                return this.Handle;
            }
            else
            {
                return (IntPtr)null;
            }
        }

        #endregion

        #region Helper methods

        private bool TryFindScannerGridRow(string symbol, out DataGridViewRow gridRow)
        {
            gridRow = null;
            foreach (DataGridViewRow row in grdResults.Rows)
            {
                if (row.Cells["Symbol"] != null)
                {
                    if (row.Cells["Symbol"].Value.ToString().Equals(symbol))
                    {
                        gridRow = row;
                    }
                }
            }
            return gridRow != null;
        }

        private ScannerItem CreateScannerItem(string symbol, IEnumerable<BarDataNew> bars, string script, string scriptName, ChartSelection scannerFrequency)
        {
            Alert scannerAlert = CreateAlertObjectFor(symbol, bars, script, scriptName);
            ScannerItem scanner = new ScannerItem(symbol, scannerAlert, Convert.ToInt32(scannerFrequency.Frequency.TotalMilliseconds), scannerFrequency.Periodicity, scannerFrequency.Interval);
            scanner.OnDataRequired += scannerItem_OnDataRequired;
            return scanner;
        }

        private Alert CreateAlertObjectFor(string symbol, IEnumerable<BarDataNew> bars, string script, string scriptName)
        {
            var alertObject = new Alert();
            alertObject.AlertName = scriptName;
            alertObject.AlertScript = script;
            alertObject.Symbol = symbol;
            alertObject.License = "XRT93NQR79ABTW788XR48";
            alertObject.ScriptError += oScript_ScriptError;
            alertObject.Alert += OnAlert;

            for (int j = 1; j <= bars.Count() - 1; j++)
            {
                double jDate = alertObject.ToJulianDate(bars.ElementAt(j).TradeDateTime.Year, bars.ElementAt(j).TradeDateTime.Month, bars.ElementAt(j).TradeDateTime.Day, bars.ElementAt(j).TradeDateTime.Hour, bars.ElementAt(j).TradeDateTime.Minute, bars.ElementAt(j).TradeDateTime.Second, bars.ElementAt(j).TradeDateTime.Millisecond);
                alertObject.AppendRecord(jDate, bars.ElementAt(j).OpenPrice, bars.ElementAt(j).HighPrice, bars.ElementAt(j).LowPrice, bars.ElementAt(j).ClosePrice, (int)bars.ElementAt(j).Volume);
            }
            return alertObject;
        }

        private void InsertNewScannerItemRow(List<IEnumerable<BarDataNew>> lstbars, string symbolName)
        {

            int newRowIndex = grdResults.Rows.Add(new DataGridViewRow());
            grdResults.Rows[newRowIndex].Height = 25;
            for (int i = 0; i < _scriptName.Count; i++)
            {
                DataGridViewTextBoxScannerColorCell alertTimeCell = grdResults.Rows[newRowIndex].Cells[_scriptName[i] + "(" + _ScriptType[i] + ")"] as DataGridViewTextBoxScannerColorCell;
                if (_ScriptType[i] == "Buy")
                    alertTimeCell.IsBuySell = true;
                else
                    alertTimeCell.IsBuySell = false;
                alertTimeCell.HighlightOnly = true;
                //alertTimeCell.Value = lstbars[0].Last().TradeDateTime;
                alertTimeCell.Interval = 5000;

            }
            grdResults.Rows[newRowIndex].Cells["Filter"].Value = false.ToString();

            //DataGridViewTextBoxScannerColorCell alertTimeCell = grdResults.Rows[newRowIndex].Cells["Alert Time"] as DataGridViewTextBoxScannerColorCell;
            //alertTimeCell.HighlightOnly = true;
            //alertTimeCell.Value = bars.Last().TradeDateTime;
            //alertTimeCell.Interval = 5000;

            grdResults.Rows[newRowIndex].Cells["Trade Time"].Value = lstbars[0].Last().TradeDateTime;
            grdResults.Rows[newRowIndex].Cells["Closed Time"].Value = lstbars[0].Last().CloseDateTime;
            //grdResults.Rows[newRowIndex].Cells["Symbol"].Value = scannerItem[0].Symbol;
            grdResults.Rows[newRowIndex].Cells["Symbol"].Value = symbolName;
            grdResults.Rows[newRowIndex].Cells["Last"].Value = lstbars[0].Last().ClosePrice;
            grdResults.Rows[newRowIndex].Cells["Volume"].Value = lstbars[0].Last().Volume;

            DataGridViewButtonCell button = grdResults.Rows[newRowIndex].Cells["Trade"] as DataGridViewButtonCell;
            button.Value = "Trade";
            button.FlatStyle = FlatStyle.Flat;

            button = grdResults.Rows[newRowIndex].Cells["Chart"] as DataGridViewButtonCell;
            button.Value = "Chart";
            button.FlatStyle = FlatStyle.Flat;

            button = grdResults.Rows[newRowIndex].Cells["Settings"] as DataGridViewButtonCell;
            button.Value = "Settings";
            button.FlatStyle = FlatStyle.Flat;

            button = grdResults.Rows[newRowIndex].Cells["Start"] as DataGridViewButtonCell;
            button.Value = "Start";
            button.FlatStyle = FlatStyle.Flat;

            DataGridViewImageButtonCell start = grdResults.Rows[newRowIndex].Cells["Start"] as DataGridViewImageButtonCell;
            start.ImageOn = Properties.Resources.Play; //My.Resources.Play;
            start.ImageOff = Properties.Resources.Pause; //My.Resources.Pause;
            start.OffsetY = 4;

            DataGridViewImageButtonCell @lock = grdResults.Rows[newRowIndex].Cells["Locked"] as DataGridViewImageButtonCell;
            @lock.ImageOn = Properties.Resources.Lock; //My.Resources.Lock;
            @lock.ImageOff = Properties.Resources.Unlock; //My.Resources.Unlock;
            @lock.OffsetY = 2;
        }

        private void AppendLatestBar(BarDataNew latestBarData_, string symbol)
        {
            for (int index = 0; index < grdResults.Rows.Count; index++)
            {
                DataGridViewRow row = grdResults.Rows[index];

                if (row.Cells["Symbol"].Value.ToString() == symbol)
                {
                    row.Cells["Trade Time"].Value = latestBarData_.TradeDateTime;
                    row.Cells["Closed Time"].Value = latestBarData_.CloseDateTime;
                    row.Cells["Last"].Value = latestBarData_.ClosePrice;
                    row.Cells["Volume"].Value = latestBarData_.Volume;
                    //sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\Logs\\TradeTime.txt", true);
                    //sw.WriteLine(symbol.ToString() + "  has lastest bar  " + row.Cells["Trade Time"].Value
                    //    + "   " + DateTime.UtcNow.ToString());
                    //sw.Close();
                }
            }
        }

        #endregion

        private void runScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdScanner_Click(null, null);
        }
    }

    class M4DataGridView : Nevron.UI.WinForm.Controls.NDataGridView
    {
        public M4DataGridView()
        {
            DoubleBuffered = true;
        }
    }
}

#region Custom controls

namespace M4
{
    #region "Custom Column Support"

    public class DataGridViewImageButtonColumn : DataGridViewColumn
    {

        public DataGridViewImageButtonColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonCell();
            this.ReadOnly = true;
        }

        public override System.Windows.Forms.DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set { base.CellTemplate = value; }
        }

        public long MaximumValue { get; set; }

        public void CalculateMaximumValue()
        {
            if (!DataGridView.VirtualMode)
            {
                int colIndex = this.DisplayIndex;
                int maximumValue = 0;
                for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
                {
                    DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                    if (null != row.Cells[colIndex].Value)
                        maximumValue = (int)Math.Max(maximumValue, double.Parse(row.Cells[colIndex].Value.ToString()));
                }
                MaximumValue = maximumValue;
            }
        }
    }
}
namespace M4
{

    public class DataGridViewImageButtonCell : DataGridViewButtonCell
    {

        private bool m_checked = false;
        private bool m_mouseOver = false;
        private Image m_imageOn;
        private Image m_imageOff;
        private int m_offsetY;

        private int m_offsetX;
        public int OffsetY
        {
            get { return m_offsetY; }
            set { m_offsetY = value; }
        }

        public int OffsetX
        {
            get { return m_offsetX; }
            set { m_offsetX = value; }
        }

        public Image ImageOn
        {
            get { return m_imageOn; }
            set { m_imageOn = value; }
        }

        public Image ImageOff
        {
            get { return m_imageOff; }
            set { m_imageOff = value; }
        }

        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }

        protected override void OnClick(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            m_checked = !m_checked;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(int rowIndex)
        {
            m_mouseOver = true;
            base.OnMouseEnter(rowIndex);
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            m_mouseOver = false;
            DataGridView.InvalidateCell(this);
            base.OnMouseLeave(rowIndex);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,

        DataGridViewPaintParts paintParts)
        { 
            if (DataGridView.SelectedRows.Count > 0)//Edited by vinod as no row count
            {
            if (m_imageOn == null | m_imageOff == null) return;

            Image img = (m_checked ? m_imageOn : m_imageOff);
            int left = cellBounds.X + cellBounds.Width / 2 - img.Width / 2;

            graphics.FillRectangle(Brushes.Black, cellBounds);

            //Draw cell border
            Color color = DataGridView.DefaultCellStyle.ForeColor;
           
                if (DataGridView.SelectedRows[0].Index == rowIndex) color = DataGridView.RowsDefaultCellStyle.SelectionForeColor;
                Pen p = new Pen(color);
                Pen p2 = new Pen(DataGridView.GridColor);
                graphics.DrawRectangle(p2, cellBounds.X, cellBounds.Y, cellBounds.Width - 1, cellBounds.Height - 1);
                graphics.DrawRectangle(p, cellBounds.X, cellBounds.Y, cellBounds.Width - 2, cellBounds.Height - 2);
                p.Dispose();
                p2.Dispose();

                graphics.DrawImage(img, left + m_offsetX, cellBounds.Y + m_offsetY, img.Width, img.Height);
            }

        }

    }
}
namespace M4
{

    public class DataGridViewBarGraphColumn : DataGridViewColumn
    {
        public DataGridViewBarGraphColumn()
        {
            this.CellTemplate = new DataGridViewBarGraphCell();
            this.ReadOnly = true;
        }

        public long MaximumValue { get; set; }

        public void CalculateMaxValue()
        {
            if (!DataGridView.VirtualMode)
            {
                int colIndex = this.DisplayIndex;
                int maximumValue = 0;
                for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
                {
                    DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                    if (null != row.Cells[colIndex].Value)
                        maximumValue = (int)Math.Max(maximumValue, double.Parse(row.Cells[colIndex].Value.ToString()));
                }
                MaximumValue = maximumValue;
            }
        }
    }
    public class DataGridViewBarBuySellColumn : DataGridViewColumn
    {
        public DataGridViewBarBuySellColumn()
        {
            this.CellTemplate = new DataGridViewBarBuySellCell();
            this.ReadOnly = true;
        }

        public long MaximumValue { get; set; }

        public void CalculateMaxValue()
        {
            if (!DataGridView.VirtualMode)
            {
                int colIndex = this.DisplayIndex;
                int maximumValue = 0;
                for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
                {
                    DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                    if (null != row.Cells[colIndex].Value)
                        maximumValue = (int)Math.Max(maximumValue, double.Parse(row.Cells[colIndex].Value.ToString()));
                }
                MaximumValue = maximumValue;
            }
        }
    }
   

}
namespace M4
{
    public class DataGridViewBarBuySellCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            decimal AtBidcellValue = default(decimal);
            decimal AtOffercellValue = default(decimal);
            decimal AtBewcellValue = default(decimal);
            decimal TotalcellValue = default(decimal);
            if (value == null)
            {
                AtBidcellValue = 0;
                AtOffercellValue = 0;
                AtBewcellValue = 0;
                TotalcellValue = 0;

            }
            else
            {
                string[] tradeValue = value.ToString().Split(':');
                AtBidcellValue = decimal.Parse(tradeValue[0].ToString());
                AtOffercellValue = decimal.Parse(tradeValue[1].ToString());
                AtBewcellValue = decimal.Parse(tradeValue[2].ToString());
                TotalcellValue = AtBidcellValue + AtOffercellValue + AtBewcellValue;

            }
            DataGridViewBarBuySellColumn parent = (DataGridViewBarBuySellColumn)this.OwningColumn;
            parent.CalculateMaxValue();
            long maxValue = parent.MaximumValue;
            decimal availableWidth = cellBounds.Width;
            if (maxValue != 0)
            {
                availableWidth = (decimal)(TotalcellValue / maxValue) * availableWidth;
            }
            if (TotalcellValue != 0)
            {
                AtBidcellValue = (decimal)(AtBidcellValue / TotalcellValue) * availableWidth;
                AtOffercellValue = (decimal)(AtOffercellValue / TotalcellValue) * availableWidth;
                AtBewcellValue = (decimal)(AtBewcellValue / TotalcellValue) * availableWidth;
            }
            RectangleF OfferNewRec = new RectangleF(cellBounds.X, cellBounds.Y, (float)AtOffercellValue, cellBounds.Height - 1);
            RectangleF BetNewRec = new RectangleF(OfferNewRec.Right, cellBounds.Y, (float)AtBewcellValue, cellBounds.Height - 1);
            RectangleF BidNewRec = new RectangleF(BetNewRec.Right, cellBounds.Y, (float)AtBidcellValue, cellBounds.Height - 1);
            graphics.FillRectangle(Brushes.Green, OfferNewRec);
            graphics.FillRectangle(Brushes.White, BetNewRec);
            graphics.FillRectangle(Brushes.Red, BidNewRec);
        }
    }
    public class DataGridViewBarGraphCell : DataGridViewTextBoxCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            //base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, "", errorText, cellStyle, advancedBorderStyle, paintParts);

            // Get the value of the cell:
            decimal cellValue = default(decimal);
            if (value == null)
            {//Information.IsDBNull(value)) {
                cellValue = 0;
            }
            else
            {
                cellValue = decimal.Parse(value.ToString());
            }

            // If cell value is 0, you still
            // want to show something, so set the value
            // to 1.
            if (cellValue == 0)
            {
                cellValue = 1;
            }

            const int HORIZONTALOFFSET = 1;

            // Get the parent column and the maximum value:
            DataGridViewBarGraphColumn parent = (DataGridViewBarGraphColumn)this.OwningColumn;
            parent.CalculateMaxValue();
            long maxValue = parent.MaximumValue;
            Font fnt = parent.InheritedStyle.Font;

            SizeF maxValueSize = graphics.MeasureString(maxValue.ToString(), fnt);
            float availableWidth = cellBounds.Width;
            // - maxValueSize.Width - _

            if (maxValue != 0)
            {
                cellValue = (decimal)(cellValue / maxValue) * (decimal)availableWidth;
            }

            // Draw the bar, truncating to fit in the space 
            // you've got in the cell:
            const int VERTOFFSET = 4;
            RectangleF newRect = new RectangleF(cellBounds.X + HORIZONTALOFFSET, cellBounds.Y - VERTOFFSET, (float)cellValue, cellBounds.Height - (VERTOFFSET * 2));

            Image img = GradientBar((int)cellValue, (int)cellBounds.Height - 3);
            graphics.DrawImage(img, cellBounds.X - 1 + HORIZONTALOFFSET, cellBounds.Y - 1, img.Width, img.Height + 2);
            //graphics.FillRectangle(Brushes.Green, new Rectangle(cellBounds.X + HORIZONTALOFFSET, cellBounds.Y, img.Width, img.Height + 3));

            //graphics.DrawImage(img, cellBounds.X + HORIZONTALOFFSET, cellBounds.Y , img.Width, img.Height+3);

            // Get the text to draw and calculate its width:
            string cellText = formattedValue.ToString();
            SizeF textSize = graphics.MeasureString(cellText, fnt);

            // Calculate where text would start:
            //Dim textStart As PointF = _
            //New PointF( _
            //HORIZONTALOFFSET + cellValue + SPACER, _
            //(cellBounds.Height - textSize.Height) / 2)
            PointF textStart = new PointF(1, (cellBounds.Height - textSize.Height) / 2);



            // Calculate the correct color:
            Color textColor = parent.InheritedStyle.ForeColor;
            if ((cellState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                textColor = parent.InheritedStyle.SelectionForeColor;
            }

            // Draw the text:
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                //graphics.DrawString(cellText, fnt, brush, cellBounds.X + textStart.X, cellBounds.Y + textStart.Y);

                if (this.DataGridView != null)
                {
                    graphics.FillRectangle(Brushes.Black, new Rectangle(cellBounds.X + HORIZONTALOFFSET + img.Width - 1, cellBounds.Y, this.OwningColumn.Width, img.Height + 2));
                    graphics.FillRectangle(Brushes.Black, new Rectangle(cellBounds.X - 1 + HORIZONTALOFFSET, cellBounds.Y - 2, this.OwningColumn.Width + 1, 2));
                    //graphics.FillRectangle(Brushes.Black, new Rectangle(cellBounds.X - 1 + HORIZONTALOFFSET, cellBounds.Y-3 , this.DataGridView.Columns[6].Width + 1, 3));
                }
            }
        }

        private double Normalize(double Value, double Max, double Min)
        {
            if ((Max - Min) > 0)
            {
                return (Value - Min) / (Max - Min);
            }
            else
            {
                return Value;
            }
        }

        //Creates a variable width gradient bar with text
        private Image GradientBar(int Width, int Height)
        {
            Image img = PALSA.Properties.Resources.gradient_green;
            img = ResizeImage(img, Width, Height);

            Bitmap OrgImg = new Bitmap(img);
            Bitmap TargImg = new Bitmap(OrgImg.Width, OrgImg.Height);
            Graphics gr = Graphics.FromImage(TargImg);

            gr.DrawImage(OrgImg, 0, 0, OrgImg.Width, OrgImg.Height);
            //gr.DrawString(Text, Font, FontColor, 1, 1)

            return TargImg;

        }

        //Resizes an image

        private Image ResizeImage(Image originalImage, int width, int height)
        {
            if (width < 1) width = 1;
            if (height < 1) height = 1;

            Image finalImage = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(finalImage);

            graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Rectangle rectangle = new Rectangle(0, 0, width, height);

            graphic.DrawImage(originalImage, rectangle);

            return finalImage;

        }
    }
}
namespace M4
{



    public class DataGridViewTextBoxScannerColorColumn : DataGridViewTextBoxColumn
    {


        public DataGridViewTextBoxScannerColorColumn()
        {
            this.CellTemplate = new DataGridViewTextBoxScannerColorCell();
            this.ReadOnly = true;
        }


        public long MaximumValue { get; set; }

        public void CalculateMaxValue()
        {
            int colIndex = this.DisplayIndex;
            int maximumValue = 0;
            for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
            {
                DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                if (null != row.Cells[colIndex].Value)
                    maximumValue = (int)Math.Max(maximumValue, double.Parse(row.Cells[colIndex].Value.ToString()));
            }
            MaximumValue = maximumValue;
        }
    }
}
namespace M4
{

    public class DataGridViewTextBoxScannerColorCell : DataGridViewTextBoxCell
    {

        private Timer m_Timer = null;
        private double m_LastValue = 0;
        private Color m_Color;
        private int m_interval = 2000;

        private bool m_HighlightOnly = false;
        public bool HighlightOnly
        {
            get { return m_HighlightOnly; }
            set { m_HighlightOnly = value; }
        }
        private bool m_IsBuySell = false;
        public bool IsBuySell
        {
            get { return m_IsBuySell; }
            set { m_IsBuySell = value; }
        }
        public DataGridViewTextBoxScannerColorCell()
        {
            m_Timer = new Timer();
            m_Timer.Interval = 2000;
            m_Timer.Tick += m_Timer_Tick;
        }

        public int Interval
        {
            get { return m_interval; }
            set { m_interval = value; }
        }


        protected override bool SetValue(int rowIndex, object value)
        {
            m_Timer.Enabled = false;


            if (m_HighlightOnly)
            {
                if (value != this.Value)
                {
                    this.Style.BackColor = Color.Yellow;
                    if (m_IsBuySell)
                    {
                        this.Style.SelectionBackColor = Color.Green;
                        this.Style.BackColor = Color.Green;
                    }
                    else
                    {
                        this.Style.BackColor = Color.Red;
                        this.Style.SelectionBackColor = Color.Red;
                    } this.Style.SelectionForeColor = Color.Black;
                    this.Style.ForeColor = Color.Black;
                    m_Timer.Interval = m_interval;
                    m_Timer.Enabled = true;
                }

            }

            else
            {
                double price = 0;
                double.TryParse(value.ToString(), out price);

                if (price > m_LastValue)
                {
                    m_Color = Color.Lime;
                }
                else if (price < m_LastValue)
                {
                    m_Color = Color.Red;
                }
                else
                {
                    m_Color = Color.Silver;
                }

                this.Style.BackColor = m_Color;
                this.Style.SelectionBackColor = m_Color;

                m_Timer.Interval = m_interval;
                m_Timer.Enabled = true;

                m_LastValue = price;
            }

            return base.SetValue(rowIndex, value);

        }

        private void m_Timer_Tick(object sender, System.EventArgs e)
        {
            if (DataGridView == null) return;
            this.Style.BackColor = DataGridView.DefaultCellStyle.BackColor;
            this.Style.SelectionBackColor = DataGridView.RowsDefaultCellStyle.SelectionBackColor;
            this.Style.SelectionForeColor = DataGridView.DefaultCellStyle.ForeColor;
            this.Style.ForeColor = DataGridView.DefaultCellStyle.ForeColor;
            m_Timer.Enabled = false;
        }

    }
}

    #endregion

#endregion
