namespace CommonLibrary.UserControls
{
	partial class uctlTradeWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlTradeWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlContorlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tlpnlOrderBookl = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nsbTradeWindow = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.ui_nsbFilterLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbFilterValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyValLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyValValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyAtpLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyAtpValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellValLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellValValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellAtpLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellAtpValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalTradesLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbTotalTradesValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_uctlGridTradeWindow = new CommonLibrary.UserControls.UctlGrid();
            this.ui_npnlContorlContainer.SuspendLayout();
            this.ui_tlpnlOrderBookl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyValLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyValValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyAtpLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyAtpValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellValLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellValValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellAtpLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellAtpValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalTradesLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalTradesValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_npnlContorlContainer
            // 
            this.ui_npnlContorlContainer.Controls.Add(this.ui_tlpnlOrderBookl);
            this.ui_npnlContorlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlContorlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlContorlContainer.Name = "ui_npnlContorlContainer";
            this.ui_npnlContorlContainer.Size = new System.Drawing.Size(815, 265);
            this.ui_npnlContorlContainer.TabIndex = 0;
            this.ui_npnlContorlContainer.Text = "nuiPanel1";
            // 
            // ui_tlpnlOrderBookl
            // 
            this.ui_tlpnlOrderBookl.ColumnCount = 2;
            this.ui_tlpnlOrderBookl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpnlOrderBookl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpnlOrderBookl.Controls.Add(this.ui_nsbTradeWindow, 0, 1);
            this.ui_tlpnlOrderBookl.Controls.Add(this.ui_uctlGridTradeWindow, 0, 0);
            this.ui_tlpnlOrderBookl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpnlOrderBookl.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpnlOrderBookl.Name = "ui_tlpnlOrderBookl";
            this.ui_tlpnlOrderBookl.RowCount = 2;
            this.ui_tlpnlOrderBookl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_tlpnlOrderBookl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ui_tlpnlOrderBookl.Size = new System.Drawing.Size(813, 263);
            this.ui_tlpnlOrderBookl.TabIndex = 1;
            // 
            // ui_nsbTradeWindow
            // 
            this.ui_tlpnlOrderBookl.SetColumnSpan(this.ui_nsbTradeWindow, 2);
            this.ui_nsbTradeWindow.Location = new System.Drawing.Point(3, 241);
            this.ui_nsbTradeWindow.Name = "ui_nsbTradeWindow";
            this.ui_nsbTradeWindow.Panels.AddRange(new Nevron.UI.WinForm.Controls.NStatusBarPanel[] {
            this.ui_nsbFilterLabel,
            this.ui_nsbFilterValue,
            this.ui_nsbBuyQtyLabel,
            this.ui_nsbBuyQtyValue,
            this.ui_nsbBuyValLabel,
            this.ui_nsbBuyValValue,
            this.ui_nsbBuyAtpLabel,
            this.ui_nsbBuyAtpValue,
            this.ui_nsbSellQtyLabel,
            this.ui_nsbSellQtyValue,
            this.ui_nsbSellValLabel,
            this.ui_nsbSellValValue,
            this.ui_nsbSellAtpLabel,
            this.ui_nsbSellAtpValue,
            this.ui_nsbTotalTradesLabel,
            this.ui_nsbTotalTradesValue});
            this.ui_nsbTradeWindow.ShowPanels = true;
            this.ui_nsbTradeWindow.Size = new System.Drawing.Size(807, 20);
            this.ui_nsbTradeWindow.SizingGrip = false;
            this.ui_nsbTradeWindow.TabIndex = 1;
            // 
            // ui_nsbFilterLabel
            // 
            this.ui_nsbFilterLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbFilterLabel.Name = "ui_nsbFilterLabel";
            this.ui_nsbFilterLabel.Text = "Filter :";
            this.ui_nsbFilterLabel.Width = 40;
            // 
            // ui_nsbFilterValue
            // 
            this.ui_nsbFilterValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.ui_nsbFilterValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbFilterValue.Name = "ui_nsbFilterValue";
            this.ui_nsbFilterValue.Width = 274;
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
            // ui_nsbBuyValLabel
            // 
            this.ui_nsbBuyValLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyValLabel.Name = "ui_nsbBuyValLabel";
            this.ui_nsbBuyValLabel.Text = "Buy Val :";
            this.ui_nsbBuyValLabel.Width = 50;
            // 
            // ui_nsbBuyValValue
            // 
            this.ui_nsbBuyValValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbBuyValValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyValValue.Name = "ui_nsbBuyValValue";
            this.ui_nsbBuyValValue.Width = 10;
            // 
            // ui_nsbBuyAtpLabel
            // 
            this.ui_nsbBuyAtpLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyAtpLabel.Name = "ui_nsbBuyAtpLabel";
            this.ui_nsbBuyAtpLabel.Text = "Buy ATP :";
            this.ui_nsbBuyAtpLabel.Width = 55;
            // 
            // ui_nsbBuyAtpValue
            // 
            this.ui_nsbBuyAtpValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbBuyAtpValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyAtpValue.Name = "ui_nsbBuyAtpValue";
            this.ui_nsbBuyAtpValue.Width = 10;
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
            // ui_nsbSellValLabel
            // 
            this.ui_nsbSellValLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellValLabel.Name = "ui_nsbSellValLabel";
            this.ui_nsbSellValLabel.Text = "Sell Val :";
            this.ui_nsbSellValLabel.Width = 50;
            // 
            // ui_nsbSellValValue
            // 
            this.ui_nsbSellValValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbSellValValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellValValue.Name = "ui_nsbSellValValue";
            this.ui_nsbSellValValue.Width = 10;
            // 
            // ui_nsbSellAtpLabel
            // 
            this.ui_nsbSellAtpLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellAtpLabel.Name = "ui_nsbSellAtpLabel";
            this.ui_nsbSellAtpLabel.Text = "Sell ATP :";
            this.ui_nsbSellAtpLabel.Width = 55;
            // 
            // ui_nsbSellAtpValue
            // 
            this.ui_nsbSellAtpValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbSellAtpValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellAtpValue.Name = "ui_nsbSellAtpValue";
            this.ui_nsbSellAtpValue.Width = 10;
            // 
            // ui_nsbTotalTradesLabel
            // 
            this.ui_nsbTotalTradesLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalTradesLabel.Name = "ui_nsbTotalTradesLabel";
            this.ui_nsbTotalTradesLabel.Text = "No Of Trades :";
            this.ui_nsbTotalTradesLabel.Width = 90;
            // 
            // ui_nsbTotalTradesValue
            // 
            this.ui_nsbTotalTradesValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.ui_nsbTotalTradesValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbTotalTradesValue.MinWidth = 30;
            this.ui_nsbTotalTradesValue.Name = "ui_nsbTotalTradesValue";
            this.ui_nsbTotalTradesValue.Width = 30;
            // 
            // ui_uctlGridTradeWindow
            // 
            this.ui_uctlGridTradeWindow.AllowUserToAddRows = false;
            this.ui_uctlGridTradeWindow.AllowUserToDeleteRows = false;
            this.ui_uctlGridTradeWindow.AllowUserToOrderColumns = true;
            this.ui_uctlGridTradeWindow.AllowUserToResizeColumns = true;
            this.ui_uctlGridTradeWindow.AllowUserToResizeRows = true;
            this.ui_uctlGridTradeWindow.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridTradeWindow.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridTradeWindow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridTradeWindow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridTradeWindow.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.ui_uctlGridTradeWindow.ColumnHeaderHeight = 4;
            this.ui_uctlGridTradeWindow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTradeWindow.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridTradeWindow.ColumnHeadersHeight = 0;
            this.ui_uctlGridTradeWindow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridTradeWindow.ColumnHeadersVisible = true;
            this.ui_tlpnlOrderBookl.SetColumnSpan(this.ui_uctlGridTradeWindow, 2);
            this.ui_uctlGridTradeWindow.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridTradeWindow.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridTradeWindow.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridTradeWindow.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridTradeWindow.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridTradeWindow.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridTradeWindow.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTradeWindow.DataSource = null;
            this.ui_uctlGridTradeWindow.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTradeWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridTradeWindow.EnableCellCustomDraw = true;
            this.ui_uctlGridTradeWindow.EnableHeaderCustomDraw = true;
            this.ui_uctlGridTradeWindow.EnableHeadersVisualStyles = true;
            this.ui_uctlGridTradeWindow.EnableMultiSelect = true;
            this.ui_uctlGridTradeWindow.EnableSkinning = true;
            this.ui_uctlGridTradeWindow.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridTradeWindow.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridTradeWindow.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridTradeWindow.GridPalette")));
            this.ui_uctlGridTradeWindow.IColIndex = -1;
            this.ui_uctlGridTradeWindow.IRowIndex = -1;
            this.ui_uctlGridTradeWindow.IsGridReadOnly = true;
            this.ui_uctlGridTradeWindow.IsGridVisible = true;
            this.ui_uctlGridTradeWindow.IsRowHeadersVisible = false;
            this.ui_uctlGridTradeWindow.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlGridTradeWindow.Margin = new System.Windows.Forms.Padding(0);
            this.ui_uctlGridTradeWindow.Name = "ui_uctlGridTradeWindow";
            this.ui_uctlGridTradeWindow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTradeWindow.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridTradeWindow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridTradeWindow.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridTradeWindow.Size = new System.Drawing.Size(813, 238);
            this.ui_uctlGridTradeWindow.TabIndex = 2;
            this.ui_uctlGridTradeWindow.Title = null;
            this.ui_uctlGridTradeWindow.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridTradeWindow_OnGridMouseDown);
            this.ui_uctlGridTradeWindow.Load += new System.EventHandler(this.ui_uctlGridTradeWindow_Load);
            // 
            // uctlTradeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ui_npnlContorlContainer);
            this.Name = "uctlTradeWindow";
            this.Size = new System.Drawing.Size(815, 265);
            this.Load += new System.EventHandler(this.uctlTradeWindow_Load);
            this.ui_npnlContorlContainer.ResumeLayout(false);
            this.ui_tlpnlOrderBookl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyValLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyValValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyAtpLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyAtpValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellValLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellValValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellAtpLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellAtpValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalTradesLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbTotalTradesValue)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlContorlContainer;
        private System.Windows.Forms.TableLayoutPanel ui_tlpnlOrderBookl;
        private Nevron.UI.WinForm.Controls.NStatusBar ui_nsbTradeWindow;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbFilterLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbFilterValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyValLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyValValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyAtpLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyAtpValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellValLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellValValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellAtpLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellAtpValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalTradesLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbTotalTradesValue;
        public UctlGrid ui_uctlGridTradeWindow;



    }
}
