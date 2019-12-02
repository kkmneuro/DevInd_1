namespace CommonLibrary.UserControls
{
    partial class uctlTerminalWindowTrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlTerminalWindowTrade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_nrlblStatus = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.ui_lblProfitPIP = new System.Windows.Forms.Label();
            this.ui_lblProfitUSD = new System.Windows.Forms.Label();
            this.ui_lblTotalPendingOrdersValues = new System.Windows.Forms.Label();
            this.ui_lblTotalPendingOrders = new System.Windows.Forms.Label();
            this.ui_uctlGridTrade = new CommonLibrary.UserControls.UctlGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nrlblStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_nrlblStatus
            // 
            this.ui_nrlblStatus.BackColor = System.Drawing.Color.Silver;
            this.ui_nrlblStatus.FillInfo.Gradient1 = System.Drawing.Color.Transparent;
            this.ui_nrlblStatus.FillInfo.Gradient2 = System.Drawing.Color.Transparent;
            this.ui_nrlblStatus.Location = new System.Drawing.Point(258, 102);
            this.ui_nrlblStatus.Name = "ui_nrlblStatus";
            this.ui_nrlblStatus.ShadowInfo.Draw = false;
            this.ui_nrlblStatus.Size = new System.Drawing.Size(539, 23);
            this.ui_nrlblStatus.TabIndex = 1;
            // 
            // ui_lblProfitPIP
            // 
            this.ui_lblProfitPIP.AutoSize = true;
            this.ui_lblProfitPIP.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitPIP.Location = new System.Drawing.Point(994, 77);
            this.ui_lblProfitPIP.Name = "ui_lblProfitPIP";
            this.ui_lblProfitPIP.Size = new System.Drawing.Size(28, 13);
            this.ui_lblProfitPIP.TabIndex = 13;
            this.ui_lblProfitPIP.Text = "0.00";
            // 
            // ui_lblProfitUSD
            // 
            this.ui_lblProfitUSD.AutoSize = true;
            this.ui_lblProfitUSD.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitUSD.Location = new System.Drawing.Point(994, 55);
            this.ui_lblProfitUSD.Name = "ui_lblProfitUSD";
            this.ui_lblProfitUSD.Size = new System.Drawing.Size(28, 13);
            this.ui_lblProfitUSD.TabIndex = 12;
            this.ui_lblProfitUSD.Text = "0.00";
            // 
            // ui_lblTotalPendingOrdersValues
            // 
            this.ui_lblTotalPendingOrdersValues.AutoSize = true;
            this.ui_lblTotalPendingOrdersValues.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTotalPendingOrdersValues.Location = new System.Drawing.Point(995, 25);
            this.ui_lblTotalPendingOrdersValues.Name = "ui_lblTotalPendingOrdersValues";
            this.ui_lblTotalPendingOrdersValues.Size = new System.Drawing.Size(13, 13);
            this.ui_lblTotalPendingOrdersValues.TabIndex = 15;
            this.ui_lblTotalPendingOrdersValues.Text = "0";
            // 
            // ui_lblTotalPendingOrders
            // 
            this.ui_lblTotalPendingOrders.AutoSize = true;
            this.ui_lblTotalPendingOrders.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTotalPendingOrders.Location = new System.Drawing.Point(867, 25);
            this.ui_lblTotalPendingOrders.Name = "ui_lblTotalPendingOrders";
            this.ui_lblTotalPendingOrders.Size = new System.Drawing.Size(122, 13);
            this.ui_lblTotalPendingOrders.TabIndex = 14;
            this.ui_lblTotalPendingOrders.Text = "Total Pending Order(s)  :";
            // 
            // ui_uctlGridTrade
            // 
            this.ui_uctlGridTrade.AllowUserToAddRows = false;
            this.ui_uctlGridTrade.AllowUserToDeleteRows = false;
            this.ui_uctlGridTrade.AllowUserToOrderColumns = true;
            this.ui_uctlGridTrade.AllowUserToResizeColumns = true;
            this.ui_uctlGridTrade.AllowUserToResizeRows = true;
            this.ui_uctlGridTrade.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridTrade.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridTrade.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridTrade.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridTrade.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridTrade.ColumnHeaderHeight = 23;
            this.ui_uctlGridTrade.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTrade.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridTrade.ColumnHeadersHeight = 0;
            this.ui_uctlGridTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_uctlGridTrade.ColumnHeadersVisible = true;
            this.ui_uctlGridTrade.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridTrade.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridTrade.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridTrade.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridTrade.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridTrade.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridTrade.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTrade.DataSource = null;
            this.ui_uctlGridTrade.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridTrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridTrade.EnableCellCustomDraw = true;
            this.ui_uctlGridTrade.EnableHeaderCustomDraw = true;
            this.ui_uctlGridTrade.EnableHeadersVisualStyles = true;
            this.ui_uctlGridTrade.EnableMultiSelect = true;
            this.ui_uctlGridTrade.EnableSkinning = true;
            this.ui_uctlGridTrade.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridTrade.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridTrade.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridTrade.GridPalette")));
            this.ui_uctlGridTrade.IColIndex = -1;
            this.ui_uctlGridTrade.IRowIndex = -1;
            this.ui_uctlGridTrade.IsGridReadOnly = false;
            this.ui_uctlGridTrade.IsGridVisible = true;
            this.ui_uctlGridTrade.IsRowHeadersVisible = false;
            this.ui_uctlGridTrade.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlGridTrade.Name = "ui_uctlGridTrade";
            this.ui_uctlGridTrade.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridTrade.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridTrade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridTrade.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridTrade.Size = new System.Drawing.Size(1209, 188);
            this.ui_uctlGridTrade.TabIndex = 0;
            this.ui_uctlGridTrade.OnColumnHeaderClick += new CommonLibrary.UserControls.UctlGrid.DataGridViewColumnHeaderClickHandler(this.ui_uctlGridTrade_OnColumnHeaderClick);
            this.ui_uctlGridTrade.Load += new System.EventHandler(this.ui_uctlGridTrade_Load);
            this.ui_uctlGridTrade.Paint += new System.Windows.Forms.PaintEventHandler(this.ui_uctlGridTrade_Paint);
            // 
            // uctlTerminalWindowTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_lblTotalPendingOrdersValues);
            this.Controls.Add(this.ui_lblTotalPendingOrders);
            this.Controls.Add(this.ui_lblProfitPIP);
            this.Controls.Add(this.ui_lblProfitUSD);
            this.Controls.Add(this.ui_nrlblStatus);
            this.Controls.Add(this.ui_uctlGridTrade);
            this.Name = "uctlTerminalWindowTrade";
            this.Size = new System.Drawing.Size(1209, 188);
            this.Load += new System.EventHandler(this.uctlTerminalWindowTrade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_nrlblStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UctlGrid ui_uctlGridTrade;
        private Nevron.UI.WinForm.Controls.NRichTextLabel ui_nrlblStatus;
        private System.Windows.Forms.Label ui_lblProfitPIP;
        private System.Windows.Forms.Label ui_lblProfitUSD;
        private System.Windows.Forms.Label ui_lblTotalPendingOrdersValues;
        private System.Windows.Forms.Label ui_lblTotalPendingOrders;
    }
}
