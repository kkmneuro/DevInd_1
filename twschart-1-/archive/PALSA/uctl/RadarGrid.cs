using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using FundXchange.Domain.Enumerations;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Controllers;
//using FundXchange.Model.ViewModels.RadarView;
//using FundXchange.Domain.Entities;
//using FundXchange.Model.ViewModels.Indicators;
//using FundXchange.Controls.GridView;
using Nevron.UI.WinForm.Controls;
using PALSA.ClsRadar;
using PALSA.Cls;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.ViewModels.Generic;
//using FundXchange.Application.Services;

namespace PALSA.uctl
{
    public partial class RadarGrid : UserControl, IRadarGridView
    {
        public RadarGrid()
        {   
            InitializeComponent();
            _controller = new RadarGridController(this);
        }

        private readonly IRadarGridController _controller;
        private static Color PositiveMovementColor = Color.LimeGreen;
        private static Color NegativeMovementColor = Color.Red;
        private object m_lockGrid = new object();

        public IEnumerable<string> SubscribedSymbolDescriptors
        {
            get { return _controller.SubscribedSymbolDescriptors.Select(descriptor => descriptor.ToString()); }
        }

        public IEnumerable<Guid> SelectedRadarItemIdentifiers
        {
            get { return GetSelectedRadarItemIdentifiers(); }
        }

        public RadarTemplate ActiveTemplate
        {
            get { return _controller.Template; }
        }

        public bool IsEmpty
        {
            get { return _controller.SubscribedSymbolDescriptors.Count() == 0; }
        }

        public delegate void ChartRequestedDelegate(string symbol, Periodicity periodicity, int interval);
        public event EventHandler RowsChanged;
        public event EventHandler TimeFrameChangeRequested;
        public event ChartRequestedDelegate ChartRequested;

        #region IRadarGrid Members

        public void AddIndicator(Indicator indicator)
        {
            var activeIndicators = GetActiveIndicators().ToList();
            if (!activeIndicators.Contains(indicator))
            {
                activeIndicators.Add(indicator);
                _controller.UpdateIndicators(activeIndicators);
            }
        }

        public void RefreshIndicator(Indicator indicatorToRefresh)
        {
            _controller.RefreshIndicator(indicatorToRefresh);
        }

        public void AddIndicatorColumns(Indicator indicator)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((Action) delegate ()
                {
                    AddIndicatorColumns(indicator);
                });
                return;
            }

            var indicatorColumn = CreateIndicatorValueColumn(indicator);
            var signalColumn = CreateIndicatorSignalColumn(indicator);

            ActiveTemplate.AddColumnTemplate(IndicatorColumnTemplate.CreateDefault(indicator, indicator.Abbreviation));

            lock (m_lockGrid)
            {
                dgvRadar.SuspendLayout();
                dgvRadar.Columns.Add(indicatorColumn);
                dgvRadar.Columns.Add(signalColumn);
                dgvRadar.ResumeLayout();
            }
        }

        private static DataGridViewTextBoxColumn CreateIndicatorValueColumn(Indicator indicator)
        {
            var indicatorColumn = new DataGridViewTextBoxColumn()
            {
                Name = string.Format("col{0}", indicator.Abbreviation),
                HeaderText = indicator.Abbreviation,
                Tag = string.Format("Indicator_{0}", indicator.Abbreviation),
                ToolTipText = indicator.Name
            };
            return indicatorColumn;
        }

        private DataGridViewImageColumn CreateIndicatorSignalColumn(Indicator indicator)
        {
            var signalColumn = new DataGridViewImageColumn()
            {
                Name = string.Format("col{0}_Signal", indicator.Abbreviation),
                Tag = string.Format("Indicator_{0}_Signal", indicator.Abbreviation),
                HeaderText = string.Empty,
                Description = string.Format("Signal column for {0}", indicator.Abbreviation),
                ToolTipText = string.Format("{0} signal", indicator.Name),
                ImageLayout = DataGridViewImageCellLayout.Normal,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 16,
                Image = signalImageList.Images[2],
            };
            return signalColumn;
        }

        public void RemoveIndicatorColumns(Indicator indicator)
        {
            int columnIndex;
            if (TryGetIndicatorColumnIndex(indicator, out columnIndex))
            {
                lock (m_lockGrid)
                {                    
                    dgvRadar.Columns.RemoveAt(columnIndex);
                    
                }
                ActiveTemplate.RemoveColumnTemplate(indicator.Abbreviation);

                int signalColumnIndex;
                if (TryGetIndicatorSignalColumnIndex(indicator, out signalColumnIndex))
                {
                    lock (m_lockGrid)
                    {
                        
                        dgvRadar.Columns.RemoveAt(signalColumnIndex);
                        
                    }
                }
            }
        }

        public void AddRadar(string symbol, string exchange)
        {
            try
            {
                _controller.AddRadar(symbol, exchange);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Subscription error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void AddRadar(SubscriptionDescriptor descriptor)
        {
            try
            {
                _controller.AddRadar(descriptor);
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(this, e.Message, "Subscription error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void AddRadar(Guid uniqueId, IEnumerable<RadarGridCell> cells)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((Action)delegate()
                {
                    AddRadar(uniqueId, cells);
                });
                return;
            }

            DataGridViewRow radarRow = new DataGridViewRow()
            {
                Tag = uniqueId
            };

            foreach (RadarGridCell radarGridCell in cells)
            {
                DataGridViewTextBoxCell cell = CreateGridViewCellFrom(radarGridCell);
                radarRow.Cells.Add(cell);
            }

            lock (m_lockGrid)
            {
                dgvRadar.SuspendLayout();
                dgvRadar.Rows.Add(radarRow);
                dgvRadar.ResumeLayout();
            }
        }

        public void InitializeCell(RadarGridCell cell)
        {
            lock (m_lockGrid)
            {
                int rowIndex;
                if (TryGetRadarItemRowIndex(cell.OwnerId, out rowIndex))
                {
                    InsertCellAtExpectedPosition(cell, rowIndex);
                }
            }
        }

        public void UpdateCell(RadarGridCell cell)
        {
            UpdateCellsFor(cell.OwnerId, new[] { cell });
        }

        public void UpdateCellsFor(Guid uniqueId, IEnumerable<RadarGridCell> cells)
        {
            lock (m_lockGrid)
            {
                int rowIndex;
                if (TryGetRadarItemRowIndex(uniqueId, out rowIndex))
                {
                    foreach (var cell in cells)
                    {
                        DataGridViewCell gridCell;
                        if (TryFindCellBy(cell.Tag, rowIndex, out gridCell))
                        {
                            UpdateGridViewCell(cell, gridCell);
                        }
                    }
                }
            }
        }

        public void DeleteSelectedRows()
        {
            lock (m_lockGrid)
            {
                var selectedRows = GetSelectedRows();

                if (selectedRows.Count() > 0)
                {
                    _controller.RemoveRadars(SelectedRadarItemIdentifiers);

                    SuspendLayout();
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        dgvRadar.Rows.Remove(row);
                    }
                    ResumeLayout();
                }
            }
        }

        public void InsertBlankRow()
        {
            int targetRowIndex = GetRowIndexForNewRow();

            lock (m_lockGrid)
            {
                dgvRadar.SuspendLayout();
                dgvRadar.Rows.Insert(targetRowIndex, 1);
                dgvRadar.ResumeLayout();
            }
        }

        public void UpdateIndicators(IEnumerable<Indicator> selectedIndicators)
        {
            _controller.UpdateIndicators(selectedIndicators);
        }

        public void InsertLabelRow()
        {
            int targetRowIndex = GetRowIndexForNewRow();
            DataGridViewRow labelRow = CreateLabelRow();

            lock (m_lockGrid)
            {
                dgvRadar.SuspendLayout();
                dgvRadar.Rows.Insert(targetRowIndex, labelRow);
                dgvRadar.Rows[targetRowIndex].ReadOnly = false;
                dgvRadar.ResumeLayout();
            }
        }

        public void SelectRadar(string instrumentSymbol)
        {
            int radarRowIndex;
            if (TryGetRadarItemRowIndex(instrumentSymbol, out radarRowIndex))
            {
                lock (m_lockGrid)
                {
                    dgvRadar.ClearSelection();
                    HighlightRow(radarRowIndex);
                }
            }
        }

        private void HighlightRow(int rowIndex)
        {
            foreach (DataGridViewRow row in dgvRadar.Rows)
            {
                row.DefaultCellStyle.Font = new Font(ActiveTemplate.Font.FontFamily, ActiveTemplate.Font.Size, ActiveTemplate.Font.Style);
            }
            dgvRadar.Rows[rowIndex].DefaultCellStyle.Font = new Font(ActiveTemplate.Font.FontFamily, ActiveTemplate.Font.Size, FontStyle.Bold);
        }

        public void ApplyTemplate(RadarTemplate radarTemplate)
        {   
            _controller.Template = radarTemplate;
            if (!radarTemplate.IsSavedToDisk)
                _controller.AddDefaultIndicators();
            _controller.SetIndicatorStatus(radarTemplate.IndicatorsEnabled);
            dgvRadar.DefaultCellStyle.Font = radarTemplate.Font;
            dgvRadar.CellBorderStyle = GetRequiredBorderStyle(radarTemplate);
            dgvRadar.GridColor = radarTemplate.GridLineColor;

            _controller.UpdateIndicators(radarTemplate.ColumnTemplates.Select(ct => ct.AssociatedIndicator));

            foreach (var columnTemplate in radarTemplate.ColumnTemplates)
            {
                ApplyColumnTemplate(columnTemplate);
            }
        }

        public void UpdateSelectedRadarTimeFrames(Periodicity periodicity, int interval)
        {
            _controller.SetRadarTimeFrames(SelectedRadarItemIdentifiers, periodicity, interval);
        }

        public IEnumerable<Indicator> GetActiveIndicators()
        {
            return _controller.GetActiveIndicators();
        }

        public void Clear()
        {
            lock (m_lockGrid)
            {
                dgvRadar.SuspendLayout();

                dgvRadar.SelectAll();
                _controller.RemoveRadars(SelectedRadarItemIdentifiers);
                dgvRadar.Rows.Clear();

                dgvRadar.ResumeLayout();
            }
        }

        #endregion

        #region Event handlers

        private void DgvRadarRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {            
            RaiseRowsChanged();
        }

        private void DgvRadarRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {            
            RaiseRowsChanged();
        }

        private void DgvRadarCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!((sender as DataGridView).CurrentCell is SpanningTextBoxCell))
            {
                e.Cancel = true;
            }
        }

        private void dgvRadar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
                HighlightRow(e.RowIndex);
        }

        private void DgvRadarCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!IsBlankOrLabelRow(dgvRadar.Rows[e.RowIndex]))
                {
                    if (e.ColumnIndex.Equals(0) && SelectedRadarItemIdentifiers.Count() > 0)
                    {
                        RaiseTimeFrameChangeRequested();
                    }
                    else
                    {
                        Guid rowIdentifier = GetRowIndentifier(e.RowIndex);

                        var selectedDescriptor = _controller.GetRadarDescriptor(rowIdentifier);
                        if (null != selectedDescriptor)
                            RaiseChartRequested(selectedDescriptor);
                    }
                }
            }
        }

        private void dgvRadar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedRows();
                e.Handled = true;
            }
        }

        private void dgvRadar_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            //if (IsIndicatorColumn(e.Column))
            //{
            //    var signalColumn = FindSignalColumnUsing(e.Column.Tag.ToString());
            //    if (null != signalColumn)
            //    {   
            //        signalColumn.Visible = e.Column.Displayed;
            //    }
            //}
        }

        #endregion

        #region Helper methods

        private int GetRowIndexForNewRow()
        {
            int targetRowIndex = 0;
            if (dgvRadar.SelectedCells.Count > 0)
            {
                targetRowIndex = dgvRadar.SelectedCells[0].RowIndex;
            }
            return targetRowIndex;
        }

        private void RaiseRowsChanged()
        {
            if (null != RowsChanged)
                RowsChanged(this, new EventArgs());
        }

        private void RaiseTimeFrameChangeRequested()
        {
            if (null != TimeFrameChangeRequested)
                TimeFrameChangeRequested(this, new EventArgs());
        }

        private void RaiseChartRequested(SubscriptionDescriptor subscriptionDescriptor)
        {
            if (null != ChartRequested)
                ChartRequested(subscriptionDescriptor.Symbol, subscriptionDescriptor.Periodicity, subscriptionDescriptor.Interval);
        }

        private void InsertCellAtExpectedPosition(RadarGridCell cell, int rowIndex)
        {
            string[] splitTag = cell.Tag.Split('_');
            if (splitTag.Length > 1)
            {
                string expectedColumnName = string.Format("col{0}", splitTag[1]);

                DataGridViewCell targetCell = dgvRadar.Rows[rowIndex].Cells[expectedColumnName];
                if (null != targetCell)
                {
                    targetCell.Tag = cell.Tag;
                    targetCell.Value = cell.Text;
                    targetCell.Style.ForeColor = Color.WhiteSmoke;
                    targetCell.Style.BackColor = SystemColors.ControlDarkDark;

                    if (cell.AssociatedColumnType == RadarColumnType.Indicator)
                    {
                        UpdateSignalCell(cell, targetCell);
                        ApplyIndicatorColumnTemplate(cell, targetCell);
                    }
                }
            }
        }

        private void DrawCellCandle(RadarGridCell cell, DataGridViewCell targetCell)
        {   
            Pen pen = new Pen(Brushes.Yellow, 5);
            Graphics e = dgvRadar.CreateGraphics();
            e.DrawLine(pen, new PointF(targetCell.ContentBounds.Right, targetCell.ContentBounds.Top), new PointF(targetCell.ContentBounds.Right, targetCell.ContentBounds.Bottom));
        }

        private bool TryGetRadarItemRowIndex(string symbol, out int rowIndex)
        {
            rowIndex = -1;
            foreach (DataGridViewRow dataRow in dgvRadar.Rows)
            {
                if (dataRow.Cells["colSymbol"].Value != null)
                {
                    if (dataRow.Cells["colSymbol"].Value.ToString() == symbol)
                    {
                        rowIndex = dgvRadar.Rows.IndexOf(dataRow);
                        break;
                    }
                }
            }
            return rowIndex > -1;
        }

        private bool TryGetRadarItemRowIndex(Guid uniqueId, out int rowIndex)
        {
            rowIndex = -1;
            foreach (DataGridViewRow dataRow in dgvRadar.Rows)
            {
                if (null != dataRow.Tag && dataRow.Tag.ToString() == uniqueId.ToString())
                {
                    rowIndex = dgvRadar.Rows.IndexOf(dataRow);
                    break;
                }
            }
            return rowIndex > -1;
        }

        private bool TryGetIndicatorColumnIndex(Indicator indicator, out int columnIndex)
        {
            columnIndex = -1;
            string expectedTag = string.Format("Indicator_{0}", indicator.Abbreviation);
            foreach(DataGridViewColumn column in dgvRadar.Columns)
            {   
                if (column.Tag != null && column.Tag.ToString() == expectedTag)
                {
                    columnIndex = dgvRadar.Columns.IndexOf(column);
                    break;
                }
            }
            return columnIndex > -1;
        }

        private bool TryGetIndicatorSignalColumnIndex(Indicator indicator, out int columnIndex)
        {
            columnIndex = -1;
            string expectedTag = string.Format("Indicator_{0}_Signal", indicator.Abbreviation);
            foreach (DataGridViewColumn column in dgvRadar.Columns)
            {
                if (column.Tag != null && column.Tag.Equals(expectedTag))
                {
                    columnIndex = dgvRadar.Columns.IndexOf(column);
                    break;
                }
            }
            return columnIndex > -1;
        }

        private bool TryFindCellBy(string tag, int rowIndex, out DataGridViewCell cell)
        {
            cell = null;
            foreach (DataGridViewCell gridCell in dgvRadar.Rows[rowIndex].Cells)
            {
                if (gridCell.Tag != null && gridCell.Tag.Equals(tag))
                {
                    cell = gridCell;
                    break;
                }
            }
            return cell != null;
        }

        private static DataGridViewTextBoxCell CreateGridViewCellFrom(RadarGridCell radarGridCell)
        {
            var newCell = new DataGridViewTextBoxCell()
            {
                Value = radarGridCell.Text,
                Tag = radarGridCell.Tag
            };
            newCell.Style.ForeColor = Color.WhiteSmoke;
            newCell.Style.BackColor = SystemColors.ControlDarkDark;

            return newCell;
        }

        private static string GetCellSymbol(RadarGridCell cell)
        {
            string[] split = cell.Tag.Split('_');
            if (split.Length > 1)
            {
                return split[0];
            }
            return string.Empty;
        }

        private void UpdateGridViewCell(RadarGridCell cell, DataGridViewCell gridCell)
        {
            double oldValue;
            if (double.TryParse(gridCell.Value.ToString(), out oldValue))
            {
                double newValue;
                if (double.TryParse(cell.Text, out newValue))
                {
                    if (cell.AssociatedColumnType == RadarColumnType.InstrumentValue)
                    {
                        if (newValue > oldValue)
                        {
                            SetCellStyle(gridCell, PositiveMovementColor, Color.Black);
                        }
                        else if (newValue < oldValue)
                        {
                            SetCellStyle(gridCell, NegativeMovementColor, Color.Black);
                        }
                    }
                    else
                    {
                        ApplyIndicatorColumnTemplate(cell, gridCell);
                    }
                }
            }
            gridCell.Value = cell.Text;
            if(cell.AssociatedColumnType.Equals(RadarColumnType.Indicator))
            {
                UpdateSignalCell(cell, gridCell);
            }
        }

        private void ApplyIndicatorColumnTemplate(RadarGridCell cell, DataGridViewCell targetCell)
        {
            string associatedColumnIdentifier = targetCell.OwningColumn.Tag.ToString();
            IndicatorColumnTemplate associatedTemplate = _controller.Template.FindTemplate(associatedColumnIdentifier);

            if (null != associatedTemplate)
            {
                double cellValue;
                if (double.TryParse(cell.Text, out cellValue))
                {
                    if (cellValue >= associatedTemplate.OverBoughtValue)
                    {
                        SetCellStyle(targetCell, associatedTemplate.OverBoughtConditionColor, Color.Black);
                    }
                    else if (cellValue <= associatedTemplate.OverSoldValue)
                    {
                        SetCellStyle(targetCell, associatedTemplate.OverSoldConditionColor, Color.Black);
                    }
                }
            }
        }

        private void UpdateSignalCell(RadarGridCell cell, DataGridViewCell gridCell)
        {
            var signalCell = GetSignalCellFor(gridCell);

            if(null != signalCell)
            {
                switch (cell.AlertTriggered)
                {
                    case AlertScriptTypes.Buy:
                        signalCell.Value = signalImageList.Images[0];
                        signalCell.ToolTipText = "Sell alert triggered";
                        break;
                    case AlertScriptTypes.Sell:
                        signalCell.Value = signalImageList.Images[1];
                        signalCell.ToolTipText = "Buy alert triggered";
                        break;
                    default:
                        signalCell.Value = signalImageList.Images[2];
                        signalCell.ToolTipText = "No alerts triggered";
                        signalCell.Style.BackColor = dgvRadar.DefaultCellStyle.BackColor;
                        break;
                }
            }
        }

        private DataGridViewImageCell GetSignalCellFor(DataGridViewCell indicatorCell)
        {
            if(dgvRadar.Columns.Count > (indicatorCell.ColumnIndex + 1))
            {
                var signalColumn = dgvRadar.Columns[indicatorCell.ColumnIndex + 1];
                if(signalColumn is DataGridViewImageColumn)
                {
                    return dgvRadar[signalColumn.Index, indicatorCell.RowIndex] as DataGridViewImageCell;
                }
            }
            return null;
        }

        private static void SetCellStyle(DataGridViewCell gridCell, Color backColor, Color foreColor)
        {
            gridCell.Style.BackColor = gridCell.Style.SelectionBackColor = backColor;
            gridCell.Style.ForeColor = gridCell.Style.SelectionForeColor = foreColor;
        }

        private static DataGridViewRow CreateLabelRow()
        {
            var labelRow = new DataGridViewRow();
            var labelCell = new SpanningTextBoxCell();

            labelRow.Cells.Add(labelCell);
            labelRow.DefaultCellStyle.BackColor = Color.DarkGray;
            labelRow.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            labelRow.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            labelRow.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            return labelRow;
        }

        private void ApplyColumnTemplate(IndicatorColumnTemplate columnTemplate)
        {
            int columnIndex;
            if (TryGetIndicatorColumnIndex(columnTemplate.AssociatedIndicator, out columnIndex))
            {
                foreach (DataGridViewRow gridRow in dgvRadar.Rows)
                {
                    if (gridRow.Cells[columnIndex].Tag != null && gridRow.Cells[columnIndex].Tag.ToString().Contains(columnTemplate.ColumnIdentifier))
                    {
                        FormatCell(columnTemplate, gridRow.Cells[columnIndex]);
                    }
                }
            }
        }

        private static void FormatCell(IndicatorColumnTemplate columnTemplate, DataGridViewCell gridCell)
        {
            double cellValue;
            if (double.TryParse(gridCell.Value.ToString(), out cellValue))
            {
                if (cellValue >= columnTemplate.OverBoughtValue)
                {
                    SetCellStyle(gridCell, columnTemplate.OverBoughtConditionColor, Color.Black);
                }
                else if (cellValue <= columnTemplate.OverSoldValue)
                {
                    SetCellStyle(gridCell, columnTemplate.OverSoldConditionColor, Color.Black);
                }
            }
        }

        private DataGridViewCellBorderStyle GetRequiredBorderStyle(RadarTemplate radarTemplate)
        {
            // This method determines the required cell border style based upon the defined template.
            // The reason for the branching is due to the fact that the enumeration value yielded does not support combinatory values.
            if (radarTemplate.ShowHorizontalGridLines && radarTemplate.ShowVerticalGridLines)
            {
                return DataGridViewCellBorderStyle.Single;
            }
            if (radarTemplate.ShowHorizontalGridLines)
            {
                return DataGridViewCellBorderStyle.SingleHorizontal;
            }
            return DataGridViewCellBorderStyle.SingleVertical;
        }

        private IEnumerable<Guid> GetSelectedRadarItemIdentifiers()
        {
            List<Guid> selectedRadarItems = new List<Guid>();
            foreach (DataGridViewRow selectedRow in GetSelectedRows())
            {
                if (!IsBlankOrLabelRow(selectedRow))
                {
                    Guid itemGuid = new Guid(selectedRow.Tag.ToString());
                    selectedRadarItems.Add(itemGuid);
                }
            }
            return selectedRadarItems;
        }

        private IEnumerable<DataGridViewRow> GetSelectedRows()
        {
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewCell selectedCell in dgvRadar.SelectedCells)
            {
                DataGridViewRow parentRow = selectedCell.OwningRow;
                if (!selectedRows.Contains(parentRow))
                {
                    selectedRows.Add(parentRow);
                }
            }
            return selectedRows;
        }

        private bool IsBlankOrLabelRow(DataGridViewRow selectedRow)
        {
            try
            {
                return null == selectedRow.Cells[0].Tag;
            }
            catch (IndexOutOfRangeException) { }
            return true;
        }

        private DataGridViewColumn FindSignalColumnUsing(string indicatorTag)
        {
            foreach (DataGridViewColumn column in dgvRadar.Columns)
            {
                if (column.Tag != null && column.Tag.ToString().StartsWith(indicatorTag) && column.Tag.ToString().EndsWith("Signal"))
                {
                    return column;
                }
            }
            return null;
        }

        private bool IsIndicatorColumn(DataGridViewColumn dataGridViewColumn)
        {
            if (dataGridViewColumn.Tag != null)
            {
                return dataGridViewColumn.Tag.ToString().StartsWith("Indicator_");
            }
            return false;
        }

        private Guid GetRowIndentifier(int rowIndex)
        {
            var selectedRow = dgvRadar.Rows[rowIndex];
            if (null != selectedRow.Tag)
            {
                return new Guid(selectedRow.Tag.ToString());
            }
            return Guid.Empty;
        }

        #endregion

        
    }
}
