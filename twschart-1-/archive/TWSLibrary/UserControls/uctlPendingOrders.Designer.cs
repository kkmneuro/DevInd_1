namespace CommonLibrary.UserControls
{
    partial class UctlPendingOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlPendingOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlOrderBook = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tlpnlOrderBookTable = new System.Windows.Forms.TableLayoutPanel();
            this.ui_uctlGridPendingOrder = new CommonLibrary.UserControls.UctlGrid();
            this.ui_npnlOrderBook.SuspendLayout();
            this.ui_tlpnlOrderBookTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlOrderBook
            // 
            this.ui_npnlOrderBook.BackColor = System.Drawing.Color.Transparent;
            this.ui_npnlOrderBook.Controls.Add(this.ui_tlpnlOrderBookTable);
            this.ui_npnlOrderBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlOrderBook.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlOrderBook.Name = "ui_npnlOrderBook";
            this.ui_npnlOrderBook.Size = new System.Drawing.Size(994, 342);
            this.ui_npnlOrderBook.TabIndex = 0;
            // 
            // ui_tlpnlOrderBookTable
            // 
            this.ui_tlpnlOrderBookTable.AutoScroll = true;
            this.ui_tlpnlOrderBookTable.AutoSize = true;
            this.ui_tlpnlOrderBookTable.ColumnCount = 1;
            this.ui_tlpnlOrderBookTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_tlpnlOrderBookTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpnlOrderBookTable.Controls.Add(this.ui_uctlGridPendingOrder, 0, 0);
            this.ui_tlpnlOrderBookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpnlOrderBookTable.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpnlOrderBookTable.Name = "ui_tlpnlOrderBookTable";
            this.ui_tlpnlOrderBookTable.RowCount = 1;
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.ui_tlpnlOrderBookTable.Size = new System.Drawing.Size(992, 340);
            this.ui_tlpnlOrderBookTable.TabIndex = 2;
            // 
            // ui_uctlGridPendingOrder
            // 
            this.ui_uctlGridPendingOrder.AllowUserToAddRows = false;
            this.ui_uctlGridPendingOrder.AllowUserToDeleteRows = false;
            this.ui_uctlGridPendingOrder.AllowUserToOrderColumns = true;
            this.ui_uctlGridPendingOrder.AllowUserToResizeColumns = true;
            this.ui_uctlGridPendingOrder.AllowUserToResizeRows = true;
            this.ui_uctlGridPendingOrder.AlternatingRowStyle = dataGridViewCellStyle6;
            this.ui_uctlGridPendingOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_uctlGridPendingOrder.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_uctlGridPendingOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ui_uctlGridPendingOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridPendingOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridPendingOrder.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridPendingOrder.ColumnHeaderHeight = 4;
            this.ui_uctlGridPendingOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPendingOrder.ColumnHeadersCellStyle = dataGridViewCellStyle7;
            this.ui_uctlGridPendingOrder.ColumnHeadersHeight = 0;
            this.ui_uctlGridPendingOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridPendingOrder.ColumnHeadersVisible = true;
            this.ui_uctlGridPendingOrder.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridPendingOrder.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridPendingOrder.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridPendingOrder.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridPendingOrder.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridPendingOrder.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridPendingOrder.DataRowStyle = dataGridViewCellStyle8;
            this.ui_uctlGridPendingOrder.DataSource = null;
            this.ui_uctlGridPendingOrder.DefaultCellStyle = dataGridViewCellStyle8;
            this.ui_uctlGridPendingOrder.EnableCellCustomDraw = false;
            this.ui_uctlGridPendingOrder.EnableHeaderCustomDraw = true;
            this.ui_uctlGridPendingOrder.EnableHeadersVisualStyles = true;
            this.ui_uctlGridPendingOrder.EnableMultiSelect = false;
            this.ui_uctlGridPendingOrder.EnableSkinning = true;
            this.ui_uctlGridPendingOrder.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridPendingOrder.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridPendingOrder.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridPendingOrder.GridPalette")));
            this.ui_uctlGridPendingOrder.IColIndex = -1;
            this.ui_uctlGridPendingOrder.IRowIndex = -1;
            this.ui_uctlGridPendingOrder.IsGridReadOnly = true;
            this.ui_uctlGridPendingOrder.IsGridVisible = true;
            this.ui_uctlGridPendingOrder.IsRowHeadersVisible = false;
            this.ui_uctlGridPendingOrder.Location = new System.Drawing.Point(1, 1);
            this.ui_uctlGridPendingOrder.Margin = new System.Windows.Forms.Padding(1);
            this.ui_uctlGridPendingOrder.Name = "ui_uctlGridPendingOrder";
            this.ui_uctlGridPendingOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPendingOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ui_uctlGridPendingOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridPendingOrder.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ui_uctlGridPendingOrder.Size = new System.Drawing.Size(990, 338);
            this.ui_uctlGridPendingOrder.TabIndex = 6;
            this.ui_uctlGridPendingOrder.Title = null;
            // 
            // UctlPendingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlOrderBook);
            this.Name = "UctlPendingOrder";
            this.Size = new System.Drawing.Size(994, 342);
            this.Load += new System.EventHandler(this.uctlPendingOrder_Load);
            this.Click += new System.EventHandler(this.uctlOrderBook_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uctlOrderBook_MouseClick);
            this.ui_npnlOrderBook.ResumeLayout(false);
            this.ui_npnlOrderBook.PerformLayout();
            this.ui_tlpnlOrderBookTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlOrderBook;
        private System.Windows.Forms.TableLayoutPanel ui_tlpnlOrderBookTable;
        public UctlGrid ui_uctlGridPendingOrder;

    }
}
