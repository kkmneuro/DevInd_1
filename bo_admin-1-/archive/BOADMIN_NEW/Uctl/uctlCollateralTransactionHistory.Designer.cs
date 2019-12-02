namespace BOADMIN_NEW.Uctl
{
    partial class uctlCollateralTransactionHistory
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
            this.ui_ndgvCollateralHistory = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_clmCollateralType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_clmTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_clmTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCollateralHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_ndgvCollateralHistory
            // 
            this.ui_ndgvCollateralHistory.AllowUserToAddRows = false;
            this.ui_ndgvCollateralHistory.AllowUserToDeleteRows = false;
            this.ui_ndgvCollateralHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvCollateralHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_ndgvCollateralHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ui_clmCollateralType,
            this.ui_clmAmount,
            this.ui_clmTransactionType,
            this.ui_clmTransactionDate});
            this.ui_ndgvCollateralHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvCollateralHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvCollateralHistory.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvCollateralHistory.Name = "ui_ndgvCollateralHistory";
            this.ui_ndgvCollateralHistory.ReadOnly = true;
            this.ui_ndgvCollateralHistory.RowHeadersVisible = false;
            this.ui_ndgvCollateralHistory.Size = new System.Drawing.Size(552, 226);
            this.ui_ndgvCollateralHistory.TabIndex = 0;
            // 
            // ui_clmCollateralType
            // 
            this.ui_clmCollateralType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ui_clmCollateralType.HeaderText = "CollateralType";
            this.ui_clmCollateralType.Name = "ui_clmCollateralType";
            this.ui_clmCollateralType.ReadOnly = true;
            // 
            // ui_clmAmount
            // 
            this.ui_clmAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ui_clmAmount.HeaderText = "Amount";
            this.ui_clmAmount.Name = "ui_clmAmount";
            this.ui_clmAmount.ReadOnly = true;
            // 
            // ui_clmTransactionType
            // 
            this.ui_clmTransactionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ui_clmTransactionType.HeaderText = "Transaction Type";
            this.ui_clmTransactionType.Name = "ui_clmTransactionType";
            this.ui_clmTransactionType.ReadOnly = true;
            // 
            // ui_clmTransactionDate
            // 
            this.ui_clmTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ui_clmTransactionDate.HeaderText = "Transaction Date";
            this.ui_clmTransactionDate.Name = "ui_clmTransactionDate";
            this.ui_clmTransactionDate.ReadOnly = true;
            // 
            // uctlCollateralTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_ndgvCollateralHistory);
            this.Name = "uctlCollateralTransactionHistory";
            this.Size = new System.Drawing.Size(552, 226);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCollateralHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvCollateralHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_clmCollateralType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_clmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_clmTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_clmTransactionDate;
    }
}
