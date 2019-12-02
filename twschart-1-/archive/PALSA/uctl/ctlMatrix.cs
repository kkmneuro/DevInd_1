using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
using PALSA.ClsMatrix;
using PALSA.Frm;
using M4;

namespace PALSA.uctl
{
    public partial class ctlMatrix : UserControl//, IMatrixView //Namo 21 March
    {
        #region Private members
        //private readonly OrderManagerController _OrderManagerController;
        //private readonly IMarketRepository _repository = IoC.Resolve<IMarketRepository>();
        private BackgroundWorker _unsubscribeThread;
        private readonly SortedList<double, MatrixViewItem> _matrixItems = new SortedList<double, MatrixViewItem>(new DescendingComparer());
        private Instrument _lastInstrumentUpdate;
        //private TradingAccount activeAccount = new TradingAccount();
        //private List<TradingAccount> lsttradingAccount;
        private List<OrderManagerItem> _lstOrder;
        private long _totalTradeVolume = 0;
        private long _totalBidSize = 0;
        private long _totalOfferSize = 0;
        private bool IsConfirm = true;
        private static Dictionary<string, bool> ColumnVisible = new Dictionary<string, bool>();

        private readonly MatrixController _Controller;
        //private FundXchange.Model.Infrastructure.ErrorService _ErrorService;
        private FrmMain _MainForm;
        //private ctlData _DataManager;
        private string _Symbol = "AGL";
        private string _InstID = string.Empty;
        private string _SymExpiryDate = string.Empty;
        public double _High = 0;
        public double _Low = 0;
        public string _AccountNumber = "";
        public double _PreviousLast = 0;
        private double _LastPrice = 0;
        private int _RIndex = 0;
        private bool _OpenPosition = false;

        private object m_lockGrid = new object();
        delegate void GridCallback(List<MatrixViewItem> items);
        private Dictionary<int, double> _dicBidLvl = new Dictionary<int, double>();
        private Dictionary<int, double> _dicAskLvl = new Dictionary<int, double>();

        #endregion


        public ctlMatrix(FrmMain mainForm)
            : this(mainForm, string.Empty, string.Empty, string.Empty, 0, 0)
        {
        }

        public ctlMatrix(FrmMain mainForm,string InsID, string initialSymbol,string Expiry, double HIGH, double LOW)
        {
            InitializeComponent();
            _MainForm = mainForm;
            _MainForm.m_DockManager.DocumentManager.DocumentClosing += DocumentManager_DocumentClosing;
            if (!string.IsNullOrEmpty(initialSymbol))
            {
                //Namo 21 March
             //_Symbol = initialSymbol;
             //_High = HIGH;
             //_Low = LOW;
             //_InstID = InsID;
             //_SymExpiryDate = Expiry;                
             //_lstOrder = new List<OrderManagerItem>();                
             //_Controller = new MatrixController(this);
             //dgvTop.Rows.Add(initialSymbol, imageList1.Images[2], 0, 0, 0, 0, 0);
             //foreach (var item in ColumnVisible)
             //{
             //    dgvBottom.Columns[item.Key].Visible = item.Value;
             //}
             //dgvBottom.EnableCellCustomDraw = false;
             //cmbxOrderType.SelectedIndex = 0;
             //cmbxDuration.SelectedIndex = 1;
             //AddAccountsToGrid();
             //CreateWatchThread();
             //ResizeGrid();
             //nTabControl1.Visible = true;
             //splitContainer1.Panel2Collapsed = true;

            }
        }

        void _OrderManagerController_StopLossOrdersChanged()
        {
            updateOrdersList();
        }

        void _OrderManagerController_ItemChanged(OrderManagerItem item)
        {
            //cmbxAccount_SelectedIndexChanged(null, null);
        }

        void DocumentManager_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document.Text == "Matrix")
            {
                bool foundWindows = false;
                //if (null != _MainForm.m_ExternalWindow && _MainForm.m_ExternalWindow.Count > 0)
                //{
                //    for (int i = 0; i < _MainForm.m_ExternalWindow.Count; i++)
                //    {
                //        if ((string)_MainForm.m_ExternalWindow[i].Tag == "Matrix")
                //        {
                //            var extWindow = (frmExternalChartWindow)_MainForm.m_ExternalWindow[i];
                //            extWindow.m_DockManager.DocumentManager.DocumentClosing += DocumentManager_DocumentClosing;

                //            foundWindows = true;
                //            break;
                //        }
                //    }
                //}
                if (!foundWindows)
                {
                    ColumnVisible.Clear();
                    foreach (DataGridViewColumn item in dgvBottom.Columns)
                    {
                        ColumnVisible.Add(item.Name, item.Visible);
                    }

                    if (null != _Controller)
                        _Controller.Stop();

                    _unsubscribeThread = new BackgroundWorker();
                    _unsubscribeThread.DoWork += _UnsubscribeThread_DoWork;
                    _unsubscribeThread.RunWorkerAsync();
                }
            }
        }

        void _UnsubscribeThread_DoWork(object sender, DoWorkEventArgs e)
        {
            var marketDepthDoc = _MainForm.m_DockManager.DocumentManager.GetDocumentByText("Market Depth");
            if (marketDepthDoc == null)
            {
                _Controller.UnSubscribeDOM();
                //if (!string.IsNullOrEmpty(_Symbol))
                //    _repository.UnsubscribeLevelTwoWatch(_Symbol, "JSE");
            }
        }

        void RepositoryLevel2SymbolChanged(string symbol)
        {
            if (_Symbol != symbol)
            {
                ChangeToNewSymbol(symbol);
            }
        }

        #region Emulation

        //public List<VirtualOrder> m_virtualorders = new List<VirtualOrder>();
        //string fname = Application.StartupPath + @"\Orders.market";

        //public void SaveOrders()
        //{
        //    BinaryFormatter m_Serializer = new BinaryFormatter();
        //    FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None);
        //    m_Serializer.Serialize(fs, m_virtualorders);
        //    fs.Close();
        //}

        //public List<VirtualOrder> LoadOrders()
        //{
        //    BinaryFormatter m_Serializer = new BinaryFormatter();

        //    if (File.Exists(fname))
        //    {
        //        using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            return (List<VirtualOrder>)m_Serializer.Deserialize(fs);
        //        }
        //    }
        //    return new List<VirtualOrder>();
        //}

        #endregion

        public void UpdateTotalTradeVolume(long totalTradeVolume)
        {
            _totalTradeVolume = totalTradeVolume;
        }
        public void UpdateTotalBidSize(long totalBidSize)
        {
            _totalBidSize = totalBidSize;
        }
        public void UpdateTotalOfferSize(long totalOfferSize)
        {
            _totalOfferSize = totalOfferSize;
        }
        //Namo 21 March
        //private delegate void UpdateQuoteHandler(QuoteItem quoteItem);
        //public void UpdateTopGridLAST(QuoteItem last)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new UpdateQuoteHandler(UpdateTopGridLAST), last);
        //        return;
        //    }
        //    try
        //    {
        //        Color foreColor = new Color();
        //        dgvTop.Rows[0].Cells[0].Value = _Symbol;
        //        if (last._Price > _PreviousLast)
        //        {
        //            dgvTop.Rows[0].Cells[1].Value = imageList1.Images[0];
        //            foreColor = Color.Green;

        //        }
        //        else if (last._Price < _PreviousLast)
        //        {
        //            dgvTop.Rows[0].Cells[1].Value = imageList1.Images[1];
        //            foreColor = Color.Red;
        //        }
        //        else
        //        {
        //            dgvTop.Rows[0].Cells[1].Value = imageList1.Images[2];
        //            foreColor = Color.Black;
        //        }

        //        dgvTop.Rows[0].Cells[2].Value = last._Price;
        //        dgvTop.Rows[0].Cells[3].Value = Math.Round(((_PreviousLast - last._Price) / last._Price) * 100, 5);//Math.Round(instrument.PercentageMoved, 2);
        //        dgvTop.Rows[0].Cells[2].Style.ForeColor = foreColor;
        //        dgvTop.Rows[0].Cells[3].Style.ForeColor = foreColor;
        //        dgvTop.Rows[0].Cells[6].Value = nudQuantity.Value;
        //        //dgvTop.Rows[0].Cells[6].Value = M4Controls.Classes.GlobalDeclarations.ActiveAccount;

        //        _PreviousLast = last._Price;
        //        UpdateGridPriceColors();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        public void UpdateGridWithInstrument(Instrument instrument)
        {
            if (instrument != null)
            {
                _lastInstrumentUpdate = instrument;
                Color foreColor = new Color();
                dgvTop.Rows[0].Cells[0].Value = instrument.Symbol;
                if (instrument.PercentageMoved > 0)
                {
                    dgvTop.Rows[0].Cells[1].Value = imageList1.Images[0];
                    foreColor = Color.Green;

                }
                else if (instrument.PercentageMoved < 0)
                {
                    dgvTop.Rows[0].Cells[1].Value = imageList1.Images[1];
                    foreColor = Color.Red;
                }
                else
                {
                    dgvTop.Rows[0].Cells[1].Value = imageList1.Images[2];
                    foreColor = Color.Black;
                }

                dgvTop.Rows[0].Cells[2].Value = instrument.LastTrade;
                dgvTop.Rows[0].Cells[3].Value = Math.Round(instrument.PercentageMoved, 2);
                dgvTop.Rows[0].Cells[2].Style.ForeColor = foreColor;
                dgvTop.Rows[0].Cells[3].Style.ForeColor = foreColor;

                dgvTop.Rows[0].Cells[6].Value = nudQuantity.Value;
                //dgvTop.Rows[0].Cells[6].Value = M4Controls.Classes.GlobalDeclarations.ActiveAccount;

                UpdateGridPriceColors();
            }
        }

        public void HandleLTP(MatrixViewItem item)
        {
            int newRowItems = 0;
            lock (m_lockGrid)
            {
                if (!_matrixItems.ContainsKey(item.Price))
                {
                    _matrixItems.Add(item.Price, item);
                    newRowItems++;
                    dgvBottom.RowCount += newRowItems;
                }
                else
                {
                    _matrixItems[item.Price] = item;
                }
            }
        }


        public void AddGridRowItems(List<MatrixViewItem> items)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new GridCallback(AddGridRowItems), items);
                return;
            }

            try
            {
                lock (m_lockGrid)
                {
                    int newRowItems = 0;
                    foreach (MatrixViewItem item in items)
                    {
                        if (item.MktLvl == 100 || item.MktLvl == 200)
                        {
                            if (!_matrixItems.ContainsKey(item.Price))
                            {
                                _matrixItems.Add(item.Price, item);
                                newRowItems++;
                                dgvBottom.RowCount += newRowItems;
                            }
                        }
                        else if (item.OfferOrderCount == 0)//For Bid DOM
                        {
                            if (!_dicBidLvl.ContainsKey(item.MktLvl))
                            {
                                _dicBidLvl.Add(item.MktLvl, item.Price);
                                if (!_matrixItems.ContainsKey(item.Price))
                                {
                                    _matrixItems.Add(item.Price, item);
                                    newRowItems++;
                                    dgvBottom.RowCount += newRowItems;
                                }
                            }
                            else
                            {
                                double OldPrc = _dicBidLvl[item.MktLvl];
                                if (_matrixItems.ContainsKey(OldPrc))
                                {
                                    if (!_matrixItems.ContainsKey(item.Price))
                                    {
                                        //Remove Older one
                                        _matrixItems.Remove(OldPrc);
                                        _matrixItems.Add(item.Price, item);

                                        int elementIndex = _matrixItems.IndexOfKey(item.Price);
                                        if (dgvBottom.RowCount > elementIndex && dgvBottom.Rows[elementIndex].Visible)
                                            dgvBottom.InvalidateRow(elementIndex);

                                        _dicBidLvl[item.MktLvl] = item.Price;
                                    }
                                }


                               
                            }
 
                        }
                        else if (item.BidOrderCount == 0)//For Ask DOM
                        {
                            if (!_dicAskLvl.ContainsKey(item.MktLvl))
                            {
                                _dicAskLvl.Add(item.MktLvl, item.Price);
                                if (!_matrixItems.ContainsKey(item.Price))
                                {
                                    _matrixItems.Add(item.Price, item);
                                    newRowItems++;
                                    dgvBottom.RowCount += newRowItems;
                                }
                            }
                            else
                            {
                                double OldPrc = _dicAskLvl[item.MktLvl];
                                if (_matrixItems.ContainsKey(OldPrc))
                                {
                                    if (!_matrixItems.ContainsKey(item.Price))
                                    {

                                        //Remove Older one
                                        _matrixItems.Remove(OldPrc);
                                        _matrixItems.Add(item.Price, item);
                                        int elementIndex = _matrixItems.IndexOfKey(item.Price);
                                        if (dgvBottom.RowCount > elementIndex && dgvBottom.Rows[elementIndex].Visible)
                                            dgvBottom.InvalidateRow(elementIndex);
                                        _dicAskLvl[item.MktLvl] = item.Price;
                                    }
                                }

                            }
                        }

                        //if (!_matrixItems.ContainsKey(item.Price))
                        //{


                        //    _matrixItems.Add(item.Price, item);
                        //    newRowItems++;
                        //    dgvBottom.RowCount += newRowItems;


                        //}
                        //else
                        //{
                        //    _matrixItems[item.Price] = item;
                        //    int elementIndex = _matrixItems.IndexOfKey(item.Price);
                        //    if (dgvBottom.RowCount > elementIndex && dgvBottom.Rows[elementIndex].Visible)
                        //        dgvBottom.InvalidateRow(elementIndex);
                        //    if (_matrixItems[item.Price].MktLvl == item.MktLvl)
                        //    {

                        //    }
                        //}
                    }

                    dgvBottom.SuspendLayout();
                    //dgvBottom.RowCount += newRowItems;

                    //if (newRowItems > 30)//Kuldeep
                    //{
                    int middleOfMatrix = (dgvBottom.RowCount / 2) - 10;
                    if (middleOfMatrix > -1)
                        dgvBottom.FirstDisplayedScrollingRowIndex = middleOfMatrix;
                    // }

                    UpdateVolumeColumnMaximumValue();
                    dgvBottom.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                //_ErrorService.LogError(String.Format("Matrix Exception: {0}", ex), ex);
            }
        }


        private void UpdateVolumeColumnMaximumValue()
        {
            DataGridViewBarGraphColumn volumeColumn = dgvBottom.Columns[6] as DataGridViewBarGraphColumn;
            if (null != volumeColumn)
                volumeColumn.MaximumValue = _matrixItems.Max(i => i.Value.TradeVolume);
            DataGridViewBarTimeColumn TimeVolColumn = dgvBottom.Columns[7] as DataGridViewBarTimeColumn;
            if (null != TimeVolColumn)
                TimeVolColumn.MaximumValue = _matrixItems.Max(i => i.Value.TimeTradeVolume != null ? i.Value.TimeTradeVolume.Sum() : 0);
            DataGridViewBarGraphColumn bidColumn = dgvBottom.Columns[10] as DataGridViewBarGraphColumn;
            if (null != volumeColumn)
                bidColumn.MaximumValue = _matrixItems.Max(i => i.Value.BidSize);
            DataGridViewBarGraphColumn offerColumn = dgvBottom.Columns[12] as DataGridViewBarGraphColumn;
            if (null != volumeColumn)
                offerColumn.MaximumValue = _matrixItems.Max(i => i.Value.OfferSize);
            DataGridViewBarBuySellColumn BuySellColumn = dgvBottom.Columns[14] as DataGridViewBarBuySellColumn;
            if (null != BuySellColumn)
                BuySellColumn.MaximumValue = _matrixItems.Max(i => i.Value.TradeAtBetSize + i.Value.TradeAtBidSize + i.Value.TradeAtOfferSize);

        }

        public void UpdateGridRowItems(List<MatrixViewItem> items)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new GridCallback(UpdateGridRowItems), items);
                return;
            }
            try
            {
                lock (m_lockGrid)
                {
                    if (items.Count > 0)
                    {
                        foreach (MatrixViewItem item in items)
                        {
                            if (_matrixItems.ContainsKey(item.Price))
                            {
                                _matrixItems[item.Price] = item;
                                int elementIndex = _matrixItems.IndexOfKey(item.Price);
                                if (dgvBottom.RowCount > elementIndex && dgvBottom.Rows[elementIndex].Visible)
                                    dgvBottom.InvalidateRow(elementIndex);
                            }

                        }
                        UpdateVolumeColumnMaximumValue();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearGrid()
        {
            lock (m_lockGrid)
            {
                dgvBottom.SuspendLayout();
                dgvBottom.Rows.Clear();
                dgvBottom.ResumeLayout();
            }
        }

        private void CreateWatchThread()
        {
            var watchThread = new Thread(AddSymbolWatch)
            {
                Name = "MatrixWatchThread",
                IsBackground = true
            };
            watchThread.Start();
        }

        private void AddSymbolWatch()
        {
            if (!String.IsNullOrEmpty(_Symbol))
            {
                try
                {
                    //_Controller.Subscribe(_Symbol.ToString(), "JSE");
                    _Controller.SubscribeNew(_Symbol,_InstID, _High, _Low);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error: {0}", ex.Message));
                    //_ErrorService.LogError(string.Format("Matrix: {0}", ex.Message), ex);
                }
            }
        }

        private void UpdateGridPriceColors()
        {
            int startIndex = dgvBottom.FirstDisplayedScrollingRowIndex;
            int endIndex = startIndex + dgvBottom.DisplayedRowCount(true);

            for (int i = startIndex; i < endIndex; i++)
            {
                dgvBottom.InvalidateRow(i);
            }
        }

        private void ResizeGrid()
        {
            dgvBottom.Width = _MainForm.Width;
            int columnCount = dgvBottom.Columns.Count;
            int columnWidth = dgvBottom.Width / columnCount;

            foreach (DataGridViewColumn column in dgvBottom.Columns)
            {
                column.Width = columnWidth;
            }
            dgvBottom.Update();
        }

        #region Event handlers
        string msg = string.Empty;

        int CurrentRow = -1;
        int PrevRow = -1;
        int CurrentColumn = -1;
        int PrevColumn = -1;
        bool IsPrevOrder = false;
        bool IsOrder = true;
        private void dgvBottom_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_matrixItems.Count > e.RowIndex && RowIsCurrentlyVisible(e.RowIndex))
            {
                //if (e.RowIndex <= _matrixItems.Count)
                //{
                var viewItem = _matrixItems.ElementAt(e.RowIndex);

                if (e.ColumnIndex.Equals(2))
                {
                    string Ordermsg = string.Empty;
                    if (_lstOrder.Count == 0)
                        IsOrder = true;
                    foreach (OrderManagerItem item in _lstOrder.ToList())
                    {
                        //if (item.TriggerPrice == viewItem.Value.Price)
                        //{
                        //    if (item.OrderStatus == OrderStatusses.Open)
                        //    {
                        //        if (item.StopLossPrice != -1)
                        //        {
                        //            if (item.StopLossPrice == 0)
                        //                Ordermsg = item.Side.ToString().Substring(0, 1) + ":" + item.Quantity;
                        //            else
                        //            {
                        //                Ordermsg = item.Side.ToString().Substring(0, 1) + "S:" + item.Quantity + " LMT:" + item.StopLossPrice.ToString();
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Ordermsg = item.Side.ToString().Substring(0, 1) + "S:" + item.Quantity + " LMT:?";
                        //        }
                        //        e.Value = Ordermsg;

                        //        if (e.RowIndex.Equals(CurrentRow) && e.ColumnIndex.Equals(CurrentColumn))
                        //        {
                        //            e.Value = "Cancel Order";
                        //            IsPrevOrder = true;
                        //        }
                        //        IsOrder = false;
                        //        break;
                        //    }
                        //}
                        //IsOrder = true;
                    }

                    if (e.RowIndex.Equals(CurrentRow))
                    {
                        if (IsOrder)
                        {
                            e.Value = msg;
                        }
                    }
                    else if (e.RowIndex.Equals(PrevRow))
                    {
                        if (IsPrevOrder)
                        {
                            e.Value = Ordermsg;
                        }
                        else
                        {
                            e.Value = string.Empty;
                        }
                        Ordermsg = string.Empty;
                    }
                }
                else if (e.ColumnIndex.Equals(3))
                {
                    e.Value = viewItem.Value.BidSizeCell.Text;
                }
                else if (e.ColumnIndex.Equals(4))
                {
                    e.Value = viewItem.Value.Price;
                }
                else if (e.ColumnIndex.Equals(5))
                {
                    e.Value = viewItem.Value.OfferSizeCell.Text;
                }
                else if (e.ColumnIndex.Equals(6))
                {
                    e.Value = viewItem.Value.TradeVolume;
                }
                else if (e.ColumnIndex.Equals(7))
                {
                    e.Value = viewItem.Value.TimeTradeVolume;
                }
                else if (e.ColumnIndex.Equals(8))
                {
                    if (viewItem.Value.TradeVolume != 0)
                        e.Value = viewItem.Value.TradeVolume;
                }
                else if (e.ColumnIndex.Equals(9))
                {
                    if (_totalTradeVolume > 0 && viewItem.Value.TradeVolume > 0)
                        e.Value = (Math.Round(((viewItem.Value.TradeVolume * 100.0) / (double)_totalTradeVolume), 2)).ToString() + "%";
                }
                else if (e.ColumnIndex.Equals(10))
                {
                    e.Value = viewItem.Value.BidSize;
                }
                else if (e.ColumnIndex.Equals(11))
                {
                    if (_totalBidSize > 0 && viewItem.Value.BidSize > 0)
                        e.Value = (Math.Round(((viewItem.Value.BidSize * 100.0) / (double)_totalBidSize), 2)).ToString() + "%";
                }
                else if (e.ColumnIndex.Equals(12))
                {
                    e.Value = viewItem.Value.OfferSize;
                }
                else if (e.ColumnIndex.Equals(13))
                {
                    if (_totalOfferSize > 0 && viewItem.Value.OfferSize > 0)
                        e.Value = (Math.Round(((viewItem.Value.OfferSize * 100.0) / (double)_totalOfferSize), 2)).ToString() + "%";
                }
                else if (e.ColumnIndex.Equals(14))
                {
                    e.Value = viewItem.Value.TradeAtBidSize + ":" + viewItem.Value.TradeAtOfferSize + ":" + viewItem.Value.TradeAtBetSize;
                }

                SetCellDisplayProperties(e.RowIndex, e.ColumnIndex, viewItem.Value);
            //}
            }
        }

        //private void dgvBottom_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //{
 
        //}

        private bool RowIsCurrentlyVisible(int rowIndex)
        {
            int startIndex = dgvBottom.FirstDisplayedScrollingRowIndex;
            int endIndex = startIndex + dgvBottom.DisplayedRowCount(true);
            return rowIndex >= startIndex && rowIndex <= endIndex;
        }

        private void SetCellDisplayProperties(int rowIndex, int columnIndex, MatrixViewItem viewItem)
        {
            DataGridViewCell cell = dgvBottom[columnIndex, rowIndex];
            if (null != cell)
            {
                switch (columnIndex)
                {
                    case 2:
                        cell.Style.BackColor = Color.Black;
                        break;
                    case 3:
                        cell.Style.BackColor = viewItem.BidSizeCell.BackColor;
                        cell.Style.SelectionBackColor = viewItem.BidSizeCell.BackColor;
                        if (!IsOrder)
                        {
                            dgvBottom.Rows[rowIndex].Cells[columnIndex - 1].Style.BackColor = Color.White;
                            dgvBottom.Rows[rowIndex].Cells[columnIndex - 1].Style.ForeColor = Color.Black;
                            break;
                        }
                        if (PrevRow > 0 && PrevColumn > 0)
                        {
                            if (rowIndex.Equals(CurrentRow) && columnIndex.Equals(CurrentColumn))
                            {
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn].Style.BackColor = viewItem.BidSizeCell.BackColor;
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn - 1].Style.BackColor = viewItem.BidSizeCell.BackColor;
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn + 1].Style.BackColor = viewItem.BidSizeCell.BackColor;
                                dgvBottom.Rows[rowIndex].Cells[columnIndex - 1].Style.ForeColor = Color.White;
                            }
                            else if (rowIndex.Equals(PrevRow) && columnIndex.Equals(PrevColumn))
                            {
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn].Style.BackColor = viewItem.BidSizeCell.BackColor;
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn - 1].Style.BackColor = Color.Black;
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn + 1].Style.BackColor = viewItem.PriceCell.BackColor;
                                dgvBottom.Rows[rowIndex].Cells[columnIndex - 1].Style.ForeColor = Color.White;
                            }
                        }
                        break;
                    case 4:
                        if (null != _lastInstrumentUpdate)
                        {
                            if (viewItem.Price < _lastInstrumentUpdate.Low || viewItem.Price > _lastInstrumentUpdate.High)
                            {
                                cell.Style.BackColor = Color.Gray;
                            }
                            else if (viewItem.Price.Equals(_lastInstrumentUpdate.Open))
                            {
                                cell.Style.BackColor = MatrixController.OpenColor;
                            }
                            else if (viewItem.Price.Equals(_lastInstrumentUpdate.YesterdayClose))
                            {
                                cell.Style.BackColor = MatrixController.CloseColor;
                            }
                            else if (viewItem.Price.Equals(_lastInstrumentUpdate.Low))
                            {
                                cell.Style.BackColor = MatrixController.LowColor;
                            }
                            else if (viewItem.Price.Equals(_lastInstrumentUpdate.High))
                            {
                                cell.Style.BackColor = MatrixController.HighColor;
                            }
                            else if (viewItem.Price.Equals(_lastInstrumentUpdate.LastTrade))
                            {
                                cell.Style.BackColor = MatrixController.LastTradeColor;
                            }
                            else
                            {
                                cell.Style.BackColor = viewItem.PriceCell.BackColor;
                            }
                        }
                        cell.Style.SelectionBackColor = viewItem.PriceCell.BackColor;
                        break;
                    case 5:
                        cell.Style.BackColor = viewItem.OfferSizeCell.BackColor;
                        cell.Style.SelectionBackColor = viewItem.OfferSizeCell.BackColor;
                        if (!IsOrder)
                        {
                            dgvBottom.Rows[rowIndex].Cells[columnIndex - 3].Style.BackColor = Color.White;
                            dgvBottom.Rows[rowIndex].Cells[columnIndex - 3].Style.ForeColor = Color.Black;
                            break;
                        }
                        if (PrevRow > 0 && PrevColumn > 0)
                        {
                            if (rowIndex.Equals(CurrentRow) && columnIndex.Equals(CurrentColumn))
                            {
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn].Style.BackColor = viewItem.OfferSizeCell.BackColor;
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn - 1].Style.BackColor = viewItem.OfferSizeCell.BackColor;
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn - 2].Style.BackColor = viewItem.OfferSizeCell.BackColor;
                                dgvBottom.Rows[CurrentRow].Cells[CurrentColumn - 3].Style.BackColor = viewItem.OfferSizeCell.BackColor;
                                dgvBottom.Rows[rowIndex].Cells[columnIndex - 3].Style.ForeColor = Color.White;
                            }
                            else if (rowIndex.Equals(PrevRow) && columnIndex.Equals(PrevColumn))
                            {
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn].Style.BackColor = viewItem.OfferSizeCell.BackColor;
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn - 1].Style.BackColor = viewItem.PriceCell.BackColor;
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn - 2].Style.BackColor = viewItem.BidSizeCell.BackColor;
                                dgvBottom.Rows[PrevRow].Cells[PrevColumn - 3].Style.BackColor = Color.Black;
                                dgvBottom.Rows[rowIndex].Cells[columnIndex - 3].Style.ForeColor = Color.White;
                            }
                        }
                        break;

                    default:
                        cell.Style.BackColor = Color.Black;
                        cell.Style.ForeColor = Color.White;
                        break;
                }

            }
        }
        bool updateSetting = false;
        int triggerprice = 0;
        bool IsSetStopLimit = false;
        private void dgvBottom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvBottom.SelectedCells.Count > 0)
                {
                    string orderType = string.Empty;
                    DataGridView.HitTestInfo location = dgvBottom.HitTest(e.X, e.Y);
                    if (location.RowIndex > -1 && location.ColumnIndex > -1)
                    {
                        if (dgvBottom.Columns[location.ColumnIndex] == dgvBottom.Columns["clmnBidSize"])
                        {
                            var orderSide = "BUY";//FundXchange.Orders.FX_OrderService.OrderSide.Buy;
                            //if ((long)dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value <= _lastInstrumentUpdate.LastTrade)
                            //{
                            //    orderType = "MARKET";//"Limit";
                            //}
                            //else
                            //{
                                orderType = "MARKET";//SelectOrderType();
                                //if (!IsStopLimitOrder(orderSide, dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value.ToString(), orderType))
                                //    return;
                            //}
                            CreateSendOrderThread(orderSide, dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value.ToString(), orderType);
                        }
                        else if (dgvBottom.Columns[location.ColumnIndex] == dgvBottom.Columns["clmnAskSize"])
                        {
                            var orderSide = "SELL";//FundXchange.Orders.FX_OrderService.OrderSide.Sell;
                            //if ((long)dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value > _lastInstrumentUpdate.LastTrade)
                            //{
                            //    orderType = "MARKET";//"Limit";
                            //}
                            //else
                            //{
                                orderType = "MARKET";//SelectOrderType();
                                //if (!IsStopLimitOrder(orderSide, dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value.ToString(), orderType))
                                //    return;
                            //}

                            CreateSendOrderThread(orderSide, dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value.ToString(), orderType);
                        }
                        else if ((dgvBottom.Columns[location.ColumnIndex] == dgvBottom.Columns["clmnOrders"]))
                        {
                            if (dgvBottom.Rows[location.RowIndex].Cells[location.ColumnIndex].Value.ToString() != string.Empty)
                            {
                                updateSetting = true;
                                triggerprice = Convert.ToInt32(dgvBottom.Rows[location.RowIndex].Cells["clmnPrice"].Value.ToString());
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            else
            {

            }
        }

        private bool IsStopLimitOrder(string orderSide, string Price, string orderType)
        {
            if (orderType == "Stop Limit")
            {
                if (!IsSetStopLimit)
                {
                    triggerprice = Convert.ToInt32(Price);
                    IsSetStopLimit = true;
                    return true;
                }
                else
                {
                    foreach (OrderManagerItem item in _lstOrder.ToList())
                    {
                        if (triggerprice == item.TriggerPrice)
                        {
                            //_OrderManagerController.UpdateOrder("StopLimit", item.OrderId, 0, (int)nudQuantity.Value, null, triggerprice, Convert.ToInt32(Price), 0, PriceTypes.Trade);
                            //updateOrdersList();
                            ////dgvBottom.InvalidateRow(ht.RowIndex);
                        }
                    }
                    IsSetStopLimit = false;
                    return false;
                }
            }
            return true;

        }

        private void dgvTop_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(clmnAccountNO_SelectedIndexChanged);
            }
        }

        private void clmnAccountNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxAccount.SelectedItem = (sender as DataGridViewComboBoxEditingControl).EditingControlFormattedValue;
            //return;
            //string m_accid = (sender as ComboBox).SelectedItem.ToString();
            //Random r = new Random();
            //SuspendLayout();
            //dgvBottom.Rows.Clear();
            //ResumeLayout();
            //for (int k = 0; k < M4Controls.Classes.GlobalDeclarations.Orders.Count;k++ )
            //{
            //    if (M4Controls.Classes.GlobalDeclarations.Orders[k].Account.Name == m_accid)
            //    {
            //        M4Controls.Classes.Order ordr = M4Controls.Classes.GlobalDeclarations.Orders[k];
            //        //addrows(ordr.PL, ordr.FilledPrice, r.Next(1, 10000), r.Next(1, 100000), r.Next(1, 10000), ordr.FilledPrice);
            //        object[] data = new object[] { ordr.PL, ordr.FilledPrice, r.Next(1, 10000), r.Next(1, 100000), r.Next(8, 50), ordr.FilledPrice };
            //        AddRowsSafe((object)data, new EventArgs());
            //        dgvBottom.Rows[dgvBottom.RowCount - 1].Tag = ordr;
            //    }
            //}           
            //dgvBottom.Sort(dgvBottom.Columns[1], ListSortDirection.Descending);
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            rtxtQuantity.Text = nudQuantity.Value.ToString();
        }

        private void dgvTop_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //frmSymbol fsymbol = new frmSymbol();//By Kul for time being
                //_Symbol = fsymbol.GetSymbol(Utils.GetValue(_Symbol, "NPN"), "Watch Symbol");
                //_Symbol = _Symbol.ToUpper();
                //if (!String.IsNullOrEmpty(_Symbol))
                //{
                //    ChangeToNewSymbol(_Symbol);
                    
                //}
            }
        }

        private void ChangeToNewSymbol(string symbol)
        {
            _Symbol = symbol;
            dgvTop.SuspendLayout();
            dgvTop.Rows[0].Cells[0].Value = _Symbol;
            dgvTop.ResumeLayout();
            lock (m_lockGrid)
            {
                dgvBottom.SuspendLayout();
                dgvBottom.Rows.Clear();
                dgvBottom.ResumeLayout();
            }
            _matrixItems.Clear();
            CreateWatchThread();
        }

        private void btnPlaceMarket_Click(object sender, EventArgs e)
        {
            //CreateSendOrderThread(FundXchange.Orders.FX_OrderService.OrderSide.Buy,_lastInstrumentUpdate.LastTrade.ToString(), "Market");
        }

        private void btnTRLOrder_Click(object sender, EventArgs e)
        {
            //double value = _LastPrice;
            //VirtualOrder ord = new VirtualOrder();
            //ord.symbol = _Symbol;
            //ord.price = value;
            //ord.operation = "S";
            //ord.quantity = (int)nudQuantity.Value;
            //ord.id = Guid.NewGuid();
            //_OpenPosition = true;
            //m_virtualorders.Add(ord);
            //dgvBottom.SuspendLayout();
            //dgvBottom.Rows[_RIndex].Cells[1].Value = "TRL Sell";
            //dgvBottom.Rows[_RIndex].Cells[1].Tag = ord.id.ToString();
            //dgvBottom.ResumeLayout();
            //int q = Convert.ToInt32(dgvTop.Rows[0].Cells[4].Value.ToString());
            //q += (int)nudQuantity.Value;
            //dgvTop.SuspendLayout();
            //dgvTop.Rows[0].Cells[4].Value = q.ToString();
            //dgvTop.Rows[0].Cells[3].Value = CalcPL(_RIndex).ToString();
            //dgvTop.ResumeLayout();
            //if (_OpenPosition)
            //{
            //    for (int k = 0; k < dgvBottom.Rows.Count; k++)
            //    {
            //        dgvBottom.SuspendLayout();
            //        dgvBottom.Rows[k].Cells[0].Value = CalcPL(k);
            //        dgvBottom.ResumeLayout();
            //    }
            //}
        }

        private void btnOCOOrder_Click(object sender, EventArgs e)
        {
            //double value = _LastPrice;
            //VirtualOrder ord = new VirtualOrder();
            //ord.symbol = _Symbol;
            //ord.price = value;
            //ord.operation = "B";
            //ord.quantity = (int)nudQuantity.Value;
            //ord.id = Guid.NewGuid();
            //_OpenPosition = true;
            //m_virtualorders.Add(ord);
            //dgvBottom.SuspendLayout();
            //dgvBottom.Rows[_RIndex].Cells[1].Value = "OCO Buy";
            //dgvBottom.Rows[_RIndex].Cells[1].Tag = ord.id.ToString();
            //dgvBottom.ResumeLayout();
            //int q = Convert.ToInt32(dgvTop.Rows[0].Cells[4].Value.ToString());
            //q += (int)nudQuantity.Value;
            //dgvTop.SuspendLayout();
            //dgvTop.Rows[0].Cells[4].Value = q.ToString();
            //dgvTop.Rows[0].Cells[3].Value = CalcPL(_RIndex).ToString();
            //dgvTop.ResumeLayout();
            //if (_OpenPosition)
            //{
            //    for (int k = 0; k < dgvBottom.Rows.Count; k++)
            //    {
            //        dgvBottom.SuspendLayout();
            //        dgvBottom.Rows[k].Cells[0].Value = CalcPL(k);
            //        dgvBottom.ResumeLayout();
            //    }
            //}
        }

        #endregion

        #region Refactor

        private void SetupDummyOrders(Instrument instrument)
        {
            //Random random = new Random();
            //List<FundXchange.Domain.Entities.Order> orders = new List<FundXchange.Domain.Entities.Order>();
            //List<Bid> bids = new List<Bid>();
            //List<Offer> offers = new List<Offer>();
            //List<Trade> trades = new List<Trade>();

            //for (long i = instrument.LastTrade - 50; i < instrument.LastTrade; i++)
            //{
            //    CreateDummyOrdersForPrice(instrument, random, orders, bids, offers, trades, i);
            //}

            //for (long i = instrument.LastTrade; i < instrument.LastTrade + 50; i++)
            //{
            //    CreateDummyOrdersForPrice(instrument, random, orders, bids, offers, trades, i);
            //}

            //_Repository_InstrumentUpdatedEvent(instrument);
            //foreach (Trade trade in trades) 
            //_Repository_TradeOccurredEvent(trade);
            //_Repository_OrdersChangedEvent(orders);
            //_Repository_BidsChangedEvent(bids);
            //_Repository_OffersChangedEvent(offers);

        }

        //private static void CreateDummyOrdersForPrice(Instrument instrument, Random random, List<FundXchange.Domain.Entities.Order> orders,
        //    List<Bid> bids, List<Offer> offers, List<Trade> trades, long price)
        //{
            //int numBidOrders = 0;
            //long bidSize = 0;
            //int numOfferOrders = 0;
            //long offerSize = 0;
            //int numOrders = random.Next(1, 10);

            //for (int j = 0; j < numOrders; j++)
            //{
            //    int diff = random.Next(1, 10);

            //    FundXchange.Domain.Entities.Order order = new FundXchange.Domain.Entities.Order();
            //    order.Exchange = "JSE";
            //    order.Id = Guid.NewGuid().ToString();
            //    order.Price = price;
            //    order.Symbol = instrument.Symbol;
            //    order.Time = DateTime.UtcNow;
            //    order.Volume = random.Next(1, 1000);

            //    if (diff > 5)
            //    {
            //        order.Side = FundXchange.Domain.Entities.OrderSide.Buy;
            //        numBidOrders = numBidOrders + 1;
            //        bidSize += order.Volume;
            //    }
            //    else
            //    {
            //        order.Side = FundXchange.Domain.Entities.OrderSide.Sell;
            //        numOfferOrders = numOfferOrders + 1;
            //        offerSize += order.Volume;
            //    }
            //    orders.Add(order);
            //}

            //if (numBidOrders > 0)
            //{
            //    Bid bid = new Bid();
            //    bid.Exchange = instrument.Exchange;
            //    bid.Symbol = instrument.Symbol;
            //    bid.OrderCount = numBidOrders;
            //    bid.Price = price;
            //    bid.Size = bidSize;
            //    bids.Add(bid);
            //}
            //if (numOfferOrders > 0)
            //{
            //    Offer offer = new Offer();
            //    offer.Exchange = instrument.Exchange;
            //    offer.Symbol = instrument.Symbol;
            //    offer.OrderCount = numOfferOrders;
            //    offer.Price = price;
            //    offer.Size = offerSize;
            //    offers.Add(offer);
            //}

            //int tradeDiff = random.Next(1, 5);

            //if (tradeDiff > 2)
            //{
            //    Trade trade = new Trade();
            //    trade.BidVolume = random.Next(100, 10000);
            //    trade.Exchange = instrument.Exchange;
            //    trade.OfferVolume = random.Next(100, 10000);
            //    trade.Price = price;
            //    trade.Symbol = instrument.Symbol;
            //    trade.TimeStamp = DateTime.UtcNow;
            //    trade.Volume = random.Next(100, 100000);

            //    trades.Add(trade);
            //}
        //}

        private void InitPL()
        {
            //minPL = random.Next(-100, -10);
            //maxPL = Math.Abs(minPL);
        }

        private double CalcPL(int idx)
        {
            //double range = maxPL - minPL;
            //double step = Math.Round(range / dgvBottom.Rows.Count, 2);
            //return (double)Math.Round((minPL + (idx * step)), 2);
            return 0;
        }

        private void AddAccountsToGrid()
        {
            //List<string> brokerage = _OrderManagerController.GetBrokerages();
            //lsttradingAccount = _OrderManagerController.ChangeBrokerage(FundXchange.Orders.Enumerations.Brokerages.FundXchange);
            //for (int k = 0; k < lsttradingAccount.Count; k++)
            //{
            //    (dgvTop.Columns[7] as DataGridViewComboBoxColumn).Items.Add(lsttradingAccount[k].AccountNumber);
            //}
            //for (int k = 0; k < lsttradingAccount.Count; k++)
            //{
            //    cmbxAccount.Items.Add(lsttradingAccount[k].AccountNumber);
            //}
            //if (cmbxAccount.Items.Count > 0 && cmbxAccount.SelectedIndex < 0)
            //    cmbxAccount.SelectedIndex = 0;
        }

        #endregion

        private void DgvBottomCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex == 0 && e.ColumnIndex == 3)
            //{
            //    using (SolidBrush brush = new SolidBrush(e.CellStyle.BackColor))
            //    {
            //        using (Pen pen = new Pen(Color.Red))
            //        {
            //            Rectangle rect1 =
            //                new Rectangle(e.CellBounds.Location, e.CellBounds.Size);
            //            Rectangle rect2 =
            //                new Rectangle(e.CellBounds.Location, e.CellBounds.Size);

            //            rect1.X -= 1;
            //            rect1.Y -= 1;

            //            rect2.Width -= 1;
            //            rect2.Height -= 1;

            //            e.Graphics.DrawLine(pen, new Point(rect1.Left, rect1.Bottom), new Point(rect1.Right, rect1.Bottom));

            //            e.Graphics.FillRectangle(brush, rect2);
            //        }
            //    }

            //    e.PaintContent(e.CellBounds);
            //    //e.Handled = true;
            //}
            //base.OnCellPainting(e);
        }

        private class DescendingComparer : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                try
                {
                    return x.CompareTo(y) * -1;
                }
                catch (Exception ex)
                {
                    return x.ToString().CompareTo(y.ToString());
                }
            }

        }



        private void dgvBottom_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            string orderType = string.Empty;
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvBottom.Columns[e.ColumnIndex] == dgvBottom.Columns["clmnBidSize"])
                {
                    //if ((long)dgvBottom.Rows[e.RowIndex].Cells["clmnPrice"].Value <= _lastInstrumentUpdate.LastTrade)
                    //{
                    //    orderType = "Limit";
                    //}
                    //else
                    //{
                    orderType = "MARKET";//SelectOrderType();
                    //}
                    SetMessage("Buy", orderType, e.ColumnIndex, e.RowIndex);
                }
                else if (dgvBottom.Columns[e.ColumnIndex] == dgvBottom.Columns["clmnAskSize"])
                {
                    //if ((long)dgvBottom.Rows[e.RowIndex].Cells["clmnPrice"].Value > _lastInstrumentUpdate.LastTrade)
                    //{
                    //    orderType = "Limit";
                    //}
                    //else
                    //{
                    orderType = "MARKET";//SelectOrderType();
                    //}
                    SetMessage("Sell", orderType, e.ColumnIndex, e.RowIndex);
                }
                else if (dgvBottom.Columns[e.ColumnIndex] == dgvBottom.Columns["clmnOrders"])
                {
                    SetMessage(string.Empty, string.Empty, e.ColumnIndex, e.RowIndex);
                    if (updateSetting)
                    {
                        foreach (OrderManagerItem item in _lstOrder.ToList())
                        {
                            if (triggerprice == item.TriggerPrice)
                            {
                                DragDropEffects drag = DoDragDrop(item.OrderId, DragDropEffects.Move);
                            }
                        }

                        updateSetting = false;
                    }

                }
                else
                {
                    CurrentRow = PrevRow = -1;
                    CurrentColumn = PrevColumn = -1;
                }
            }
            else
            {
                CurrentRow = PrevRow = e.RowIndex;
                CurrentColumn = PrevColumn = e.ColumnIndex;
            }
        }
        private string SelectOrderType()
        {
            string OrderType = string.Empty;
            switch (cmbxOrderType.SelectedItem.ToString())
            {
                case "Auto(LMT/STP)":
                    OrderType = "Stop Market";
                    break;
                case "Auto(LMT/STL)":
                    OrderType = "Stop Limit";
                    break;
                case "Limit":
                    OrderType = "Limit";
                    break;
                case "Stop Limit":
                    OrderType = "Stop Limit";
                    break;
                case "Stop Market":
                    OrderType = "Stop Market";
                    break;
            }
            return OrderType;
        }
        private void SetMessage(string Side, string orderType, int columnIndex, int rowIndex)
        {
            if (Side != string.Empty)
                msg = Side + " " + Convert.ToString(nudQuantity.Value) + " " + orderType;
            else
                msg = string.Empty;
            PrevColumn = CurrentColumn;
            PrevRow = CurrentRow;
            CurrentColumn = columnIndex;
            CurrentRow = rowIndex;
            dgvBottom.InvalidateRow(rowIndex);
        }

        private void CreateSendOrderThread(string orderSide, string placedPrice, string orderType)
        {
            Thread sendOrderThread = new Thread(new ParameterizedThreadStart(SendOrder))
            {
                Name = "MatrixSendOrderThread",
                IsBackground = true
            };
            sendOrderThread.Start(orderSide.ToString() + ":" + placedPrice + ":" + orderType);
        }

        private void SendOrder(object order)
        {

            string[] orderAttribute = order.ToString().Split(':');
            string orderSide = orderAttribute[0];
            DateTime? expiryDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 17, 0, 0);
            if (cmbxDuration.SelectedItem.ToString() == "GTC")
                expiryDate = null;

            int triggerPrice = 0;
            int cancelPrice = 0;
            int stopLossPrice = 0;

            int quantity = Convert.ToInt32(nudQuantity.Text);
            int stopLossQuantity = quantity;
            double price = 0;
            if (orderAttribute[1] != "")
                price = Convert.ToDouble(orderAttribute[1]);
            string orderType = orderAttribute[2];
            if (orderType == "Stop Limit")
            {
                //triggerPrice = price;
                //stopLossPrice = -1;
            }
            else if (orderType == "Stop Market" || orderType == "Limit")
            {
                //triggerPrice = price;
                //stopLossPrice = 0;
            }
            if (IsConfirm)
                using (frmConfirm confirm = new frmConfirm("send", orderSide, quantity.ToString(), _Symbol, price.ToString(), orderType, cmbxDuration.SelectedItem.ToString(), "1"))//activeAccount.AccountNumber.ToString()))
                {
                    if (confirm.ShowDialog() == DialogResult.OK)
                    {
                        IsConfirm = confirm._isDisplay;
                    }
                    else if (confirm.DialogResult == DialogResult.Cancel)
                    { return; }
                }
            try
            {
                string orderId = string.Empty;
                nStatusBarPanel1.Text = ".:UROut:. " + orderSide.ToString() + " " + quantity.ToString() + " " + _Symbol + " " + price.ToString() + " " + orderType;

                SendOrderNew(_Symbol, orderSide, quantity, price, orderType);
                
                //orderId = _OrderManagerController.AddOrder("JSE", _lastInstrumentUpdate.Symbol, orderSide, expiryDate, triggerPrice, quantity, triggerPrice, stopLossPrice, cancelPrice,
                //     priceType, orderType);
                //if (orderType == "Market")
                //{
                //    //CreateOrderSend(_Symbol,)
                //    //orderId = _OrderManagerController.AddOrder("JSE", _lastInstrumentUpdate.Symbol, orderSide, expiryDate, triggerPrice, quantity, triggerPrice, stopLossPrice, cancelPrice,
                //    //     priceType, orderType);
                //}
                //else if (triggerPrice != 0)
                //{

                //    //orderId = _OrderManagerController.AddOrder("JSE", _lastInstrumentUpdate.Symbol, orderSide, expiryDate, triggerPrice, stopLossQuantity,
                //    //                      triggerPrice, stopLossPrice, cancelPrice,
                //    //                      priceType, "StopLoss");
                //}
                if (orderId != string.Empty)
                {
                    nStatusBarPanel1.Text = ".:<Received>:. " + orderSide.ToString() + " " + quantity.ToString() + " " + _lastInstrumentUpdate.Symbol + " " + price.ToString() + " " + orderType;
                }
                updateOrdersList();
                //SubmitOrder();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("Error! Brokerage does not support this functionality!!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //log exception
            }
        }

        private void SendOrderNew(string _Symbol, string orderSide,double quantity, double price, string orderType)//Kuldeep
        {
            //Namo 21 March
            //ClsNewOrder order = new ClsNewOrder();
            //ClientDLL_Model.Cls.Contract.Symbol symbool = ClientDLL_Model.Cls.Contract.Symbol.GetSymbol(_InstID);

            //string productType = symbool._ProductType;
            //string pType = string.Empty;
            //switch (productType)
            //{
            //    case "EQUITY":
            //        pType = "EQ";
            //        break;
            //    case "FUTURE":
            //        pType = "FUT";
            //        break;
            //    case "FOREX":
            //        pType = "FX";
            //        break;
            //    case "OPTION":
            //        pType = "OPT";
            //        break;
            //    case "SPOT":
            //        pType = "SP";
            //        break;
            //    case "PHYSICAL":
            //        pType = "PH";
            //        break;
            //    case "AUCTION":
            //        pType = "AU";
            //        break;
            //    case "BOND":
            //        pType = "BON";
            //        break;
            //}
            //;
            //order.Account = (uint)clsTWSOrderManagerJSON.INSTANCE.GetParticipantsList().Keys.ToArray()[0];
            //order.ClOrderID = Convert.ToString(Cls.ClsGlobal.GetClientOrderID());
            //order.ContractName = _Symbol;
            //DateTime dtEX;
            //if (DateTime.TryParse(_SymExpiryDate, out dtEX))
            //{
            //    if (dtEX != null)
            //        order.ExpiryDate = Convert.ToDateTime(_SymExpiryDate);
            //}
            //order.GatewayName = symbool._Gateway;
            //order.MinorDisclosedQty = 0;
            //order.OrderID = 0;
            //order.OrderType = Cls.ClsGlobal.DDOrderTypes["MARKET"];
            //order.PositionEffect = (sbyte)ClientDLL_Model.Cls.clsHashDefine.POSITION_OPENING_TRADE;
            //order.Price = price;
            //order.ProductName = symbool._ProductName;
            //order.Qty = quantity;
            //order.SbProductType = Cls.ClsGlobal.DDProductTypes[pType];

            //order.Side = Cls.ClsGlobal.DDSide[orderSide];
            //order.StopPX = 0;
            //order.StrProductType = symbool._ProductType;
            //order.Tif = Cls.ClsGlobal.DDValidity["DAY"];
            //clsTWSOrderManagerJSON.INSTANCE.SubmitNewOrder(order);
        }

        private void cmbxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (TradingAccount item in lsttradingAccount.ToList())
            //{
            //    if (item.AccountNumber == cmbxAccount.SelectedItem.ToString())
            //    {
            //        activeAccount = item;
            //        break;
            //    }
            //}

            //dgvTop.Rows[0].Cells[7].Value = activeAccount.AccountNumber;
            //updateOrdersList();

        }
        private void updateOrdersList()
        {
            //_OrderManagerController.ChangePortfolio(activeAccount);
            //var stopLossOrders = _OrderManagerController.GetStopLossOrders();
            //_lstOrder.Clear();
            //_lstOrder.AddRange(stopLossOrders);
            //foreach (OrderManagerItem item in _lstOrder.ToList())
            //{
            //    if (item.Side == FundXchange.Orders.FX_OrderService.OrderSide.Buy)
            //    {
            //        btnXBids.Enabled = true;
            //    }
            //    if (item.Side == FundXchange.Orders.FX_OrderService.OrderSide.Sell)
            //    {
            //        btnXOfrs.Enabled = true;
            //    }
            //    btnCancelAll.Enabled = true;
            //}
            //if (_lstOrder.Count == 0)
            //{
            //    btnXBids.Enabled = false;
            //    btnXOfrs.Enabled = false;
            //    btnCancelAll.Enabled = false;
            //}
            //SymbolSummary summaary = new SymbolSummary();
            //summaary = _OrderManagerController.GetSymbolSummary(dgvTop.Rows[0].Cells[0].ToString());
            //dgvTop.Rows[0].Cells[4].Value = summaary.Postion.ToString();
            //dgvTop.Rows[0].Cells[5].Value = summaary.TotalProfitLoss.ToString();


        }
        private void dgvBottom_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }
        private void dgvBottom_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = dgvBottom.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo ht = dgvBottom.HitTest(pt.X, pt.Y);
            string orderId = (string)e.Data.GetData(DataFormats.StringFormat);
            OrderManagerItem order = _lstOrder.Find(i => i.OrderId == orderId);
            int stopLossPrice = order.StopLossPrice;
            int triggerPrice = Convert.ToInt32(dgvBottom.Rows[ht.RowIndex].Cells["clmnPrice"].Value);
            if (order.StopLossPrice > 0 && order.StopLossPrice != order.TriggerPrice)
            {
                int diffrencePrice = order.StopLossPrice - order.TriggerPrice;
                stopLossPrice = triggerPrice + diffrencePrice;
            }
            //_OrderManagerController.UpdateOrder("StopLimit", orderId, 0, (int)nudQuantity.Value, null, triggerPrice, stopLossPrice, 0, PriceTypes.Trade);
            //nStatusBarPanel1.Text = ".:<Received>:.update " + order.Side + " " + order.Quantity.ToString() + " " + order.Symbol + " " + triggerPrice + " " + order.OrderType;
            updateOrdersList();
            dgvBottom.InvalidateRow(ht.RowIndex);
        }

        private void dgvBottom_MouseUp(object sender, MouseEventArgs e)
        {
            updateSetting = false;

            if (e.Button == MouseButtons.Left)
            {
                if (dgvBottom.SelectedCells.Count > 0)
                {
                    string orderType = string.Empty;
                    DataGridView.HitTestInfo location = dgvBottom.HitTest(e.X, e.Y);
                    if (location.RowIndex > -1 && location.ColumnIndex > -1)
                    {
                        if ((dgvBottom.Columns[location.ColumnIndex] == dgvBottom.Columns["clmnOrders"]))
                        {

                            if (dgvBottom.Rows[location.RowIndex].Cells[location.ColumnIndex].Value.ToString() != string.Empty)
                            {
                                int rowindex = location.RowIndex;
                                CreateDialogboxCancelThread(rowindex);
                            }
                        }

                    }
                }


            }
        }
        private void CreateDialogboxCancelThread(int rowindex)
        {
            Thread dialogboxThread = new Thread(new ParameterizedThreadStart(ShowDialogBox))
            {
                Name = "MatrixDialogboxThread",
                IsBackground = true
            };
            dialogboxThread.Start(rowindex);
        }
        private void ShowDialogBox(object rowindex)
        {
            foreach (OrderManagerItem item in _lstOrder.ToList())
            {
                if (Convert.ToInt64(dgvBottom.Rows[(int)rowindex].Cells["clmnPrice"].Value) == item.TriggerPrice)
                {
                    if (IsConfirm)
                        using (frmConfirm confirm = new frmConfirm("cancel", ""/*item.Side*/, item.Quantity.ToString(), item.Symbol, item.TriggerPrice.ToString(), item.OrderType, item.ExpiryDate == null ? "GTC" : "GTD", ""))//activeAccount.AccountNumber.ToString()))
                        {
                            if (confirm.ShowDialog() == DialogResult.OK)
                            {
                                IsConfirm = confirm._isDisplay;
                            }
                            else if (confirm.DialogResult == DialogResult.Cancel)
                            {
                                dgvBottom.InvalidateRow((int)rowindex);
                                return;
                            }
                        }
                    //_OrderManagerController.CancelOrder("StopLimit", item.OrderId);
                    //nStatusBarPanel1.Text = ".:<Received>:.Cancel " + item.Side + " " + item.Quantity.ToString() + " " + item.Symbol + " " + item.TriggerPrice.ToString() + " " + item.OrderType;
                    updateOrdersList();
                    dgvBottom.InvalidateRow((int)rowindex);
                }
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            //if (splitContainer1.Panel2Collapsed)//By Kuldeep for time being
            //    splitContainer1.Panel2Collapsed = false;
            //else
            //    splitContainer1.Panel2Collapsed = true;
        }

        private void btnCollapse_MouseHover(object sender, EventArgs e)
        {
            if(splitContainer1.Panel2Collapsed)
            toolTip1.SetToolTip(btnCollapse, "Show Trade Bar");
            else
                toolTip1.SetToolTip(btnCollapse, "Hide Trade Bar");
        }

        private void btnSellMkt_Click(object sender, EventArgs e)
        {
            //CreateSendOrderThread(FundXchange.Orders.FX_OrderService.OrderSide.Sell, _lastInstrumentUpdate.LastTrade.ToString(), "Market");
        }

        private void btnXBids_Click(object sender, EventArgs e)
        {
            foreach (OrderManagerItem order in _lstOrder.ToList())
            {
                //if (order.Side == FundXchange.Orders.FX_OrderService.OrderSide.Buy)
                //{
                //    _OrderManagerController.CancelOrder("StopLimit", order.OrderId);
                //    nStatusBarPanel1.Text = ".:<Received>:.Cancel " + order.Side + " " + order.Quantity.ToString() + " " + order.Symbol + " " + order.TriggerPrice.ToString() + " " + order.OrderType;

                //}
            }
            updateOrdersList();
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            foreach (OrderManagerItem order in _lstOrder.ToList())
            {
                    //_OrderManagerController.CancelOrder("StopLimit", order.OrderId);
                    //nStatusBarPanel1.Text = ".:<Received>:.Cancel " + order.Side + " " + order.Quantity.ToString() + " " + order.Symbol + " " + order.TriggerPrice.ToString() + " " + order.OrderType;
            }
            updateOrdersList();
        }

        private void btnXOfrs_Click(object sender, EventArgs e)
        {
            foreach (OrderManagerItem order in _lstOrder.ToList())
            {
                //if (order.Side == FundXchange.Orders.FX_OrderService.OrderSide.Sell)
                //{
                //    _OrderManagerController.CancelOrder("StopLimit", order.OrderId);
                //    nStatusBarPanel1.Text = ".:<Received>:.Cancel " + order.Side + " " + order.Quantity.ToString() + " " + order.Symbol + " " + order.TriggerPrice.ToString() + " " + order.OrderType;

                //}
            }
            updateOrdersList();
        }

    
    }
}