namespace CommonLibrary.UserControls
{
    partial class uctlRiskMonitor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlRiskMonitor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlRiskMonitor = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nsbTradeWindow = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.ui_nsbBuyQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalFreeMarginLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalFreeMarginValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalUsedMarginLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalUsedMarginValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalEquity = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalEquityValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbUPL = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbUPLValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_uctlGridRiskMonitor = new CommonLibrary.UserControls.UctlGrid();
            this.ui_npnlRiskMonitor.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalFreeMarginLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalFreeMarginValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalUsedMarginLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalUsedMarginValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalEquity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalEquityValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbUPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbUPLValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_npnlRiskMonitor
            // 
            this.ui_npnlRiskMonitor.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlRiskMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlRiskMonitor.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlRiskMonitor.Name = "ui_npnlRiskMonitor";
            this.ui_npnlRiskMonitor.Size = new System.Drawing.Size(940, 578);
            this.ui_npnlRiskMonitor.TabIndex = 1;
            this.ui_npnlRiskMonitor.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ui_nsbTradeWindow, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ui_uctlGridRiskMonitor, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 576);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ui_nsbTradeWindow
            // 
            this.ui_nsbTradeWindow.Location = new System.Drawing.Point(3, 544);
            this.ui_nsbTradeWindow.Name = "ui_nsbTradeWindow";
            this.ui_nsbTradeWindow.Panels.AddRange(new Nevron.UI.WinForm.Controls.NStatusBarPanel[] {
            this.ui_nsbBuyQtyLabel,
            this.ui_nsbBuyQtyValue,
            this.ui_nsbSellQtyLabel,
            this.ui_nsbSellQtyValue,
            this.ui_nsbTotalFreeMarginLabel,
            this.ui_nsbTotalFreeMarginValue,
            this.ui_nsbTotalUsedMarginLabel,
            this.ui_nsbTotalUsedMarginValue,
            this.ui_nsbTotalEquity,
            this.ui_nsbTotalEquityValue,
            this.ui_nsbUPL,
            this.ui_nsbUPLValue});
            this.ui_nsbTradeWindow.ShowPanels = true;
            this.ui_nsbTradeWindow.Size = new System.Drawing.Size(932, 29);
            this.ui_nsbTradeWindow.SizingGrip = false;
            this.ui_nsbTradeWindow.TabIndex = 10;
            // 
            // ui_nsbBuyQtyLabel
            // 
            this.ui_nsbBuyQtyLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyQtyLabel.Name = "ui_nsbBuyQtyLabel";
            this.ui_nsbBuyQtyLabel.Text = "Buy Qty :";
            this.ui_nsbBuyQtyLabel.Width = 50;
            // 
            // ui_nsbBuyQtyValue
            // 
            this.ui_nsbBuyQtyValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbBuyQtyValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyQtyValue.Name = "ui_nsbBuyQtyValue";
            this.ui_nsbBuyQtyValue.Width = 10;
            // 
            // ui_nsbSellQtyLabel
            // 
            this.ui_nsbSellQtyLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellQtyLabel.Name = "ui_nsbSellQtyLabel";
            this.ui_nsbSellQtyLabel.Text = "Sell Qty :";
            this.ui_nsbSellQtyLabel.Width = 53;
            // 
            // ui_nsbSellQtyValue
            // 
            this.ui_nsbSellQtyValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbSellQtyValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellQtyValue.Name = "ui_nsbSellQtyValue";
            this.ui_nsbSellQtyValue.Width = 10;
            // 
            // ui_nsbTotalFreeMarginLabel
            // 
            this.ui_nsbTotalFreeMarginLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalFreeMarginLabel.Name = "ui_nsbTotalFreeMarginLabel";
            this.ui_nsbTotalFreeMarginLabel.Text = "Free Margin :";
            this.ui_nsbTotalFreeMarginLabel.Width = 75;
            // 
            // ui_nsbTotalFreeMarginValue
            // 
            this.ui_nsbTotalFreeMarginValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbTotalFreeMarginValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalFreeMarginValue.Name = "ui_nsbTotalFreeMarginValue";
            this.ui_nsbTotalFreeMarginValue.Width = 10;
            // 
            // ui_nsbTotalUsedMarginLabel
            // 
            this.ui_nsbTotalUsedMarginLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalUsedMarginLabel.Name = "ui_nsbTotalUsedMarginLabel";
            this.ui_nsbTotalUsedMarginLabel.Text = "Used Margin :";
            this.ui_nsbTotalUsedMarginLabel.Width = 90;
            // 
            // ui_nsbTotalUsedMarginValue
            // 
            this.ui_nsbTotalUsedMarginValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbTotalUsedMarginValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalUsedMarginValue.Name = "ui_nsbTotalUsedMarginValue";
            this.ui_nsbTotalUsedMarginValue.Width = 10;
            // 
            // ui_nsbTotalEquity
            // 
            this.ui_nsbTotalEquity.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbTotalEquity.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalEquity.Name = "ui_nsbTotalEquity";
            this.ui_nsbTotalEquity.Text = "Equity :";
            this.ui_nsbTotalEquity.Width = 52;
            // 
            // ui_nsbTotalEquityValue
            // 
            this.ui_nsbTotalEquityValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbTotalEquityValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalEquityValue.Name = "ui_nsbTotalEquityValue";
            this.ui_nsbTotalEquityValue.Width = 10;
            // 
            // ui_nsbUPL
            // 
            this.ui_nsbUPL.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbUPL.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbUPL.Name = "ui_nsbUPL";
            this.ui_nsbUPL.Text = "Unr P/L :";
            this.ui_nsbUPL.Width = 59;
            // 
            // ui_nsbUPLValue
            // 
            this.ui_nsbUPLValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbUPLValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbUPLValue.Name = "ui_nsbUPLValue";
            this.ui_nsbUPLValue.Width = 10;
            // 
            // ui_uctlGridRiskMonitor
            // 
            this.ui_uctlGridRiskMonitor.AllowUserToAddRows = false;
            this.ui_uctlGridRiskMonitor.AllowUserToDeleteRows = false;
            this.ui_uctlGridRiskMonitor.AllowUserToOrderColumns = true;
            this.ui_uctlGridRiskMonitor.AllowUserToResizeColumns = false;
            this.ui_uctlGridRiskMonitor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.ui_uctlGridRiskMonitor.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridRiskMonitor.AutoSize = true;
            this.ui_uctlGridRiskMonitor.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridRiskMonitor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridRiskMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.ui_uctlGridRiskMonitor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridRiskMonitor.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridRiskMonitor.ColumnHeaderHeight = 32;
            this.ui_uctlGridRiskMonitor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridRiskMonitor.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridRiskMonitor.ColumnHeadersHeight = 0;
            this.ui_uctlGridRiskMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_uctlGridRiskMonitor.ColumnHeadersVisible = true;
            this.ui_uctlGridRiskMonitor.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridRiskMonitor.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridRiskMonitor.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridRiskMonitor.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridRiskMonitor.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridRiskMonitor.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridRiskMonitor.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridRiskMonitor.DataSource = null;
            this.ui_uctlGridRiskMonitor.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridRiskMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridRiskMonitor.EnableCellCustomDraw = false;
            this.ui_uctlGridRiskMonitor.EnableHeaderCustomDraw = true;
            this.ui_uctlGridRiskMonitor.EnableHeadersVisualStyles = true;
            this.ui_uctlGridRiskMonitor.EnableMultiSelect = false;
            this.ui_uctlGridRiskMonitor.EnableSkinning = true;
            this.ui_uctlGridRiskMonitor.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridRiskMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_uctlGridRiskMonitor.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridRiskMonitor.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridRiskMonitor.GridPalette")));
            this.ui_uctlGridRiskMonitor.IColIndex = -1;
            this.ui_uctlGridRiskMonitor.IRowIndex = -1;
            this.ui_uctlGridRiskMonitor.IsGridReadOnly = true;
            this.ui_uctlGridRiskMonitor.IsGridVisible = true;
            this.ui_uctlGridRiskMonitor.IsRowHeadersVisible = false;
            this.ui_uctlGridRiskMonitor.Location = new System.Drawing.Point(4, 4);
            this.ui_uctlGridRiskMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.ui_uctlGridRiskMonitor.Name = "ui_uctlGridRiskMonitor";
            this.ui_uctlGridRiskMonitor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridRiskMonitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridRiskMonitor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridRiskMonitor.RowHeight = 20;
            this.ui_uctlGridRiskMonitor.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridRiskMonitor.Size = new System.Drawing.Size(930, 533);
            this.ui_uctlGridRiskMonitor.TabIndex = 0;
            this.ui_uctlGridRiskMonitor.Title = null;
            this.ui_uctlGridRiskMonitor.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridRiskMonitor_OnGridMouseDown);
            this.ui_uctlGridRiskMonitor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridRiskMonitor_MouseDown);
            // 
            // uctlRiskMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlRiskMonitor);
            this.Name = "uctlRiskMonitor";
            this.Size = new System.Drawing.Size(940, 578);
            this.Load += new System.EventHandler(this.uctlRiskMonitor_Load);
            this.ui_npnlRiskMonitor.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalFreeMarginLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalFreeMarginValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalUsedMarginLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalUsedMarginValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalEquity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalEquityValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbUPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbUPLValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlRiskMonitor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public UctlGrid ui_uctlGridRiskMonitor;
        public Nevron.UI.WinForm.Controls.NStatusBar ui_nsbTradeWindow;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalFreeMarginLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalFreeMarginValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalUsedMarginLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalUsedMarginValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalEquity;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalEquityValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbUPL;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbUPLValue;
    }
}
