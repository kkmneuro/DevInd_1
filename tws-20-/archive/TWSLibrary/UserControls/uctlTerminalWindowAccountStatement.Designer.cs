namespace CommonLibrary.UserControls
{
    partial class uctlTerminalWindowAccountStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlTerminalWindowAccountStatement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_nrlblStatus = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.ui_lblProfitLoss = new System.Windows.Forms.Label();
            this.ui_lblProfitLossvalue = new System.Windows.Forms.Label();
            this.ui_lblCredit = new System.Windows.Forms.Label();
            this.ui_lblCreditValue = new System.Windows.Forms.Label();
            this.ui_lblDeposit = new System.Windows.Forms.Label();
            this.ui_lblDepositValue = new System.Windows.Forms.Label();
            this.ui_lblWithdrawl = new System.Windows.Forms.Label();
            this.ui_lblWithdrawlValue = new System.Windows.Forms.Label();
            this.ui_lblProfitUSD = new System.Windows.Forms.Label();
            this.ui_lblProfitPIP = new System.Windows.Forms.Label();
            this.ui_uctlGridAccountStatement = new CommonLibrary.UserControls.UctlGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nrlblStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_nrlblStatus
            // 
            this.ui_nrlblStatus.BackColor = System.Drawing.Color.Silver;
            this.ui_nrlblStatus.FillInfo.Color = System.Drawing.Color.Transparent;
            this.ui_nrlblStatus.FillInfo.Gradient1 = System.Drawing.Color.Transparent;
            this.ui_nrlblStatus.FillInfo.Gradient2 = System.Drawing.Color.Transparent;
            this.ui_nrlblStatus.Location = new System.Drawing.Point(123, 95);
            this.ui_nrlblStatus.Name = "ui_nrlblStatus";
            this.ui_nrlblStatus.ShadowInfo.Draw = false;
            this.ui_nrlblStatus.Size = new System.Drawing.Size(414, 23);
            this.ui_nrlblStatus.TabIndex = 1;
            // 
            // ui_lblProfitLoss
            // 
            this.ui_lblProfitLoss.AutoSize = true;
            this.ui_lblProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitLoss.Location = new System.Drawing.Point(741, 15);
            this.ui_lblProfitLoss.Name = "ui_lblProfitLoss";
            this.ui_lblProfitLoss.Size = new System.Drawing.Size(67, 13);
            this.ui_lblProfitLoss.TabIndex = 2;
            this.ui_lblProfitLoss.Text = "Profit/Loss  :";
            // 
            // ui_lblProfitLossvalue
            // 
            this.ui_lblProfitLossvalue.AutoSize = true;
            this.ui_lblProfitLossvalue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitLossvalue.Location = new System.Drawing.Point(814, 15);
            this.ui_lblProfitLossvalue.Name = "ui_lblProfitLossvalue";
            this.ui_lblProfitLossvalue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblProfitLossvalue.TabIndex = 3;
            this.ui_lblProfitLossvalue.Text = "0";
            // 
            // ui_lblCredit
            // 
            this.ui_lblCredit.AutoSize = true;
            this.ui_lblCredit.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblCredit.Location = new System.Drawing.Point(741, 39);
            this.ui_lblCredit.Name = "ui_lblCredit";
            this.ui_lblCredit.Size = new System.Drawing.Size(43, 13);
            this.ui_lblCredit.TabIndex = 4;
            this.ui_lblCredit.Text = "Credit  :";
            // 
            // ui_lblCreditValue
            // 
            this.ui_lblCreditValue.AutoSize = true;
            this.ui_lblCreditValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblCreditValue.Location = new System.Drawing.Point(814, 39);
            this.ui_lblCreditValue.Name = "ui_lblCreditValue";
            this.ui_lblCreditValue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblCreditValue.TabIndex = 5;
            this.ui_lblCreditValue.Text = "0";
            // 
            // ui_lblDeposit
            // 
            this.ui_lblDeposit.AutoSize = true;
            this.ui_lblDeposit.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDeposit.Location = new System.Drawing.Point(741, 62);
            this.ui_lblDeposit.Name = "ui_lblDeposit";
            this.ui_lblDeposit.Size = new System.Drawing.Size(52, 13);
            this.ui_lblDeposit.TabIndex = 6;
            this.ui_lblDeposit.Text = "Deposit  :";
            // 
            // ui_lblDepositValue
            // 
            this.ui_lblDepositValue.AutoSize = true;
            this.ui_lblDepositValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDepositValue.Location = new System.Drawing.Point(814, 62);
            this.ui_lblDepositValue.Name = "ui_lblDepositValue";
            this.ui_lblDepositValue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblDepositValue.TabIndex = 7;
            this.ui_lblDepositValue.Text = "0";
            // 
            // ui_lblWithdrawl
            // 
            this.ui_lblWithdrawl.AutoSize = true;
            this.ui_lblWithdrawl.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblWithdrawl.Location = new System.Drawing.Point(741, 85);
            this.ui_lblWithdrawl.Name = "ui_lblWithdrawl";
            this.ui_lblWithdrawl.Size = new System.Drawing.Size(63, 13);
            this.ui_lblWithdrawl.TabIndex = 8;
            this.ui_lblWithdrawl.Text = "Withdrawl  :";
            // 
            // ui_lblWithdrawlValue
            // 
            this.ui_lblWithdrawlValue.AutoSize = true;
            this.ui_lblWithdrawlValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblWithdrawlValue.Location = new System.Drawing.Point(814, 85);
            this.ui_lblWithdrawlValue.Name = "ui_lblWithdrawlValue";
            this.ui_lblWithdrawlValue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblWithdrawlValue.TabIndex = 9;
            this.ui_lblWithdrawlValue.Text = "0";
            // 
            // ui_lblProfitUSD
            // 
            this.ui_lblProfitUSD.AutoSize = true;
            this.ui_lblProfitUSD.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitUSD.Location = new System.Drawing.Point(799, 105);
            this.ui_lblProfitUSD.Name = "ui_lblProfitUSD";
            this.ui_lblProfitUSD.Size = new System.Drawing.Size(28, 13);
            this.ui_lblProfitUSD.TabIndex = 10;
            this.ui_lblProfitUSD.Text = "0.00";
            // 
            // ui_lblProfitPIP
            // 
            this.ui_lblProfitPIP.AutoSize = true;
            this.ui_lblProfitPIP.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProfitPIP.Location = new System.Drawing.Point(799, 127);
            this.ui_lblProfitPIP.Name = "ui_lblProfitPIP";
            this.ui_lblProfitPIP.Size = new System.Drawing.Size(28, 13);
            this.ui_lblProfitPIP.TabIndex = 11;
            this.ui_lblProfitPIP.Text = "0.00";
            // 
            // ui_uctlGridAccountStatement
            // 
            this.ui_uctlGridAccountStatement.AllowUserToAddRows = false;
            this.ui_uctlGridAccountStatement.AllowUserToDeleteRows = false;
            this.ui_uctlGridAccountStatement.AllowUserToOrderColumns = true;
            this.ui_uctlGridAccountStatement.AllowUserToResizeColumns = true;
            this.ui_uctlGridAccountStatement.AllowUserToResizeRows = false;
            this.ui_uctlGridAccountStatement.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridAccountStatement.AutoSize = true;
            this.ui_uctlGridAccountStatement.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridAccountStatement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridAccountStatement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridAccountStatement.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridAccountStatement.ColumnHeaderHeight = 23;
            this.ui_uctlGridAccountStatement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridAccountStatement.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridAccountStatement.ColumnHeadersHeight = 0;
            this.ui_uctlGridAccountStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_uctlGridAccountStatement.ColumnHeadersVisible = true;
            this.ui_uctlGridAccountStatement.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridAccountStatement.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridAccountStatement.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridAccountStatement.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridAccountStatement.DataGridScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ui_uctlGridAccountStatement.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridAccountStatement.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridAccountStatement.DataSource = null;
            this.ui_uctlGridAccountStatement.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridAccountStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridAccountStatement.EnableCellCustomDraw = true;
            this.ui_uctlGridAccountStatement.EnableHeaderCustomDraw = true;
            this.ui_uctlGridAccountStatement.EnableHeadersVisualStyles = true;
            this.ui_uctlGridAccountStatement.EnableMultiSelect = true;
            this.ui_uctlGridAccountStatement.EnableSkinning = true;
            this.ui_uctlGridAccountStatement.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridAccountStatement.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridAccountStatement.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridAccountStatement.GridPalette")));
            this.ui_uctlGridAccountStatement.IColIndex = -1;
            this.ui_uctlGridAccountStatement.IRowIndex = -1;
            this.ui_uctlGridAccountStatement.IsGridReadOnly = false;
            this.ui_uctlGridAccountStatement.IsGridVisible = true;
            this.ui_uctlGridAccountStatement.IsRowHeadersVisible = true;
            this.ui_uctlGridAccountStatement.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlGridAccountStatement.Name = "ui_uctlGridAccountStatement";
            this.ui_uctlGridAccountStatement.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridAccountStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridAccountStatement.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridAccountStatement.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridAccountStatement.Size = new System.Drawing.Size(1200, 209);
            this.ui_uctlGridAccountStatement.TabIndex = 0;
            this.ui_uctlGridAccountStatement.OnColumnHeaderClick += new CommonLibrary.UserControls.UctlGrid.DataGridViewColumnHeaderClickHandler(this.ui_uctlGridAccountStatement_OnColumnHeaderClick);
            this.ui_uctlGridAccountStatement.Load += new System.EventHandler(this.ui_uctlGridAccountStatement_Load);
            this.ui_uctlGridAccountStatement.Paint += new System.Windows.Forms.PaintEventHandler(this.ui_uctlGridAccountStatement_Paint);
            // 
            // uctlTerminalWindowAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_lblProfitPIP);
            this.Controls.Add(this.ui_lblProfitUSD);
            this.Controls.Add(this.ui_lblWithdrawlValue);
            this.Controls.Add(this.ui_lblWithdrawl);
            this.Controls.Add(this.ui_lblDepositValue);
            this.Controls.Add(this.ui_lblDeposit);
            this.Controls.Add(this.ui_lblCreditValue);
            this.Controls.Add(this.ui_lblCredit);
            this.Controls.Add(this.ui_lblProfitLossvalue);
            this.Controls.Add(this.ui_lblProfitLoss);
            this.Controls.Add(this.ui_nrlblStatus);
            this.Controls.Add(this.ui_uctlGridAccountStatement);
            this.Name = "uctlTerminalWindowAccountStatement";
            this.Size = new System.Drawing.Size(1200, 209);
            this.Load += new System.EventHandler(this.uctlTerminalWindowAccountStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_nrlblStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UctlGrid ui_uctlGridAccountStatement;
        private Nevron.UI.WinForm.Controls.NRichTextLabel ui_nrlblStatus;
        private System.Windows.Forms.Label ui_lblProfitLoss;
        private System.Windows.Forms.Label ui_lblProfitLossvalue;
        private System.Windows.Forms.Label ui_lblCredit;
        private System.Windows.Forms.Label ui_lblCreditValue;
        private System.Windows.Forms.Label ui_lblDeposit;
        private System.Windows.Forms.Label ui_lblDepositValue;
        private System.Windows.Forms.Label ui_lblWithdrawl;
        private System.Windows.Forms.Label ui_lblWithdrawlValue;
        private System.Windows.Forms.Label ui_lblProfitUSD;
        private System.Windows.Forms.Label ui_lblProfitPIP;
    }
}
