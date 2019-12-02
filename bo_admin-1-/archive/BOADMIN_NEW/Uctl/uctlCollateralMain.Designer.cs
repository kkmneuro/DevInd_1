namespace BOADMIN_NEW.Uctl
{
    partial class uctlCollateralMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndgvCollateral = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentOwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCollateral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unallocated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utilized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayInShortage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayOutShortage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollateralforTrading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBrokerType = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerTypes = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblAccountGroupName = new System.Windows.Forms.Label();
            this.lblParentOwner = new System.Windows.Forms.Label();
            this.ui_ntxtParentOwnerName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtOwnerName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.ui_ncmbAccountGroupName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCollateral)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(1030, 344);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.Controls.Add(this.ui_ndgvCollateral, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBrokerType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBrokerTypes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountGroupName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblParentOwner, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtParentOwnerName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtOwnerName, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOwnerName, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbAccountGroupName, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.177216F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.82278F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 342);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ui_ndgvCollateral
            // 
            this.ui_ndgvCollateral.AllowUserToAddRows = false;
            this.ui_ndgvCollateral.AllowUserToDeleteRows = false;
            this.ui_ndgvCollateral.AllowUserToOrderColumns = true;
            this.ui_ndgvCollateral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvCollateral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvCollateral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvCollateral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ndgvCollateral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.GroupName,
            this.ParentOwnerName,
            this.OwnerName,
            this.Leverage,
            this.TotalCollateral,
            this.Unallocated,
            this.Utilized,
            this.PayInShortage,
            this.PayOutShortage,
            this.CollateralforTrading});
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndgvCollateral, 9);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvCollateral.DefaultCellStyle = dataGridViewCellStyle4;
            this.ui_ndgvCollateral.DisplayChildRelations = false;
            this.ui_ndgvCollateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvCollateral.EnableCellCustomDraw = false;
            this.ui_ndgvCollateral.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvCollateral.Location = new System.Drawing.Point(6, 36);
            this.ui_ndgvCollateral.Name = "ui_ndgvCollateral";
            this.ui_ndgvCollateral.RowHeadersVisible = false;
            this.ui_ndgvCollateral.Size = new System.Drawing.Size(1016, 300);
            this.ui_ndgvCollateral.TabIndex = 0;
            this.ui_ndgvCollateral.UseColumnContextMenu = false;
            this.ui_ndgvCollateral.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvCollateral_CellClick);
            this.ui_ndgvCollateral.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_ndgvCollateral_DataError);
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Edit";
            this.Edit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Edit.FillWeight = 80F;
            this.Edit.HeaderText = "Edit Collateral";
            this.Edit.Name = "Edit";
            this.Edit.Width = 80;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "AccountGroupName";
            this.GroupName.HeaderText = "Group Name";
            this.GroupName.Name = "GroupName";
            // 
            // ParentOwnerName
            // 
            this.ParentOwnerName.DataPropertyName = "ParentOwner";
            this.ParentOwnerName.HeaderText = "Parent Owner";
            this.ParentOwnerName.Name = "ParentOwnerName";
            // 
            // OwnerName
            // 
            this.OwnerName.DataPropertyName = "Owner";
            this.OwnerName.HeaderText = "Owner Name";
            this.OwnerName.Name = "OwnerName";
            // 
            // Leverage
            // 
            this.Leverage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Leverage.DataPropertyName = "Leverage";
            this.Leverage.FillWeight = 60F;
            this.Leverage.HeaderText = "Leverage";
            this.Leverage.Name = "Leverage";
            this.Leverage.Width = 60;
            // 
            // TotalCollateral
            // 
            this.TotalCollateral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalCollateral.DataPropertyName = "TotalCollateral";
            dataGridViewCellStyle3.NullValue = "0";
            this.TotalCollateral.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalCollateral.FillWeight = 90F;
            this.TotalCollateral.HeaderText = "Total Collateral";
            this.TotalCollateral.Name = "TotalCollateral";
            this.TotalCollateral.Width = 90;
            // 
            // Unallocated
            // 
            this.Unallocated.DataPropertyName = "Unallocated";
            this.Unallocated.HeaderText = "Unallocated";
            this.Unallocated.Name = "Unallocated";
            // 
            // Utilized
            // 
            this.Utilized.DataPropertyName = "Utilized";
            this.Utilized.HeaderText = "Utilized";
            this.Utilized.Name = "Utilized";
            // 
            // PayInShortage
            // 
            this.PayInShortage.DataPropertyName = "PayInShortage";
            this.PayInShortage.HeaderText = "Pay In Shortage";
            this.PayInShortage.Name = "PayInShortage";
            // 
            // PayOutShortage
            // 
            this.PayOutShortage.DataPropertyName = "PayOutShortage";
            this.PayOutShortage.HeaderText = "Pay Out Shortage";
            this.PayOutShortage.Name = "PayOutShortage";
            // 
            // CollateralforTrading
            // 
            this.CollateralforTrading.DataPropertyName = "CollateralforTrading";
            this.CollateralforTrading.HeaderText = "Trading Collateral";
            this.CollateralforTrading.Name = "CollateralforTrading";
            // 
            // lblBrokerType
            // 
            this.lblBrokerType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBrokerType.AutoSize = true;
            this.lblBrokerType.Location = new System.Drawing.Point(6, 11);
            this.lblBrokerType.Name = "lblBrokerType";
            this.lblBrokerType.Size = new System.Drawing.Size(71, 13);
            this.lblBrokerType.TabIndex = 1;
            this.lblBrokerType.Text = "Broker Type :";
            // 
            // ui_ncmbBrokerTypes
            // 
            this.ui_ncmbBrokerTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBrokerTypes.Editable = true;
            this.ui_ncmbBrokerTypes.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerTypes.Location = new System.Drawing.Point(90, 7);
            this.ui_ncmbBrokerTypes.Name = "ui_ncmbBrokerTypes";
            this.ui_ncmbBrokerTypes.Size = new System.Drawing.Size(96, 22);
            this.ui_ncmbBrokerTypes.TabIndex = 0;
            this.ui_ncmbBrokerTypes.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerTypes_SelectedIndexChanged);
            // 
            // lblAccountGroupName
            // 
            this.lblAccountGroupName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccountGroupName.AutoSize = true;
            this.lblAccountGroupName.Location = new System.Drawing.Point(192, 11);
            this.lblAccountGroupName.Name = "lblAccountGroupName";
            this.lblAccountGroupName.Size = new System.Drawing.Size(116, 13);
            this.lblAccountGroupName.TabIndex = 3;
            this.lblAccountGroupName.Text = "Account Group Name :";
            // 
            // lblParentOwner
            // 
            this.lblParentOwner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblParentOwner.AutoSize = true;
            this.lblParentOwner.Location = new System.Drawing.Point(436, 11);
            this.lblParentOwner.Name = "lblParentOwner";
            this.lblParentOwner.Size = new System.Drawing.Size(109, 13);
            this.lblParentOwner.TabIndex = 4;
            this.lblParentOwner.Text = "Parent Owner Name :";
            // 
            // ui_ntxtParentOwnerName
            // 
            this.ui_ntxtParentOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtParentOwnerName.Location = new System.Drawing.Point(551, 9);
            this.ui_ntxtParentOwnerName.MaxLength = 50;
            this.ui_ntxtParentOwnerName.Name = "ui_ntxtParentOwnerName";
            this.ui_ntxtParentOwnerName.Size = new System.Drawing.Size(123, 18);
            this.ui_ntxtParentOwnerName.TabIndex = 2;
            this.ui_ntxtParentOwnerName.TextChanged += new System.EventHandler(this.ui_ntxtParentOwnerName_TextChanged);
            // 
            // ui_ntxtOwnerName
            // 
            this.ui_ntxtOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtOwnerName.Location = new System.Drawing.Point(763, 9);
            this.ui_ntxtOwnerName.MaxLength = 50;
            this.ui_ntxtOwnerName.Name = "ui_ntxtOwnerName";
            this.ui_ntxtOwnerName.Size = new System.Drawing.Size(124, 18);
            this.ui_ntxtOwnerName.TabIndex = 3;
            this.ui_ntxtOwnerName.TextChanged += new System.EventHandler(this.ui_ntxtOwnerName_TextChanged);
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.Location = new System.Drawing.Point(680, 11);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(75, 13);
            this.lblOwnerName.TabIndex = 8;
            this.lblOwnerName.Text = "Owner Name :";
            // 
            // ui_ncmbAccountGroupName
            // 
            this.ui_ncmbAccountGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbAccountGroupName.Editable = true;
            this.ui_ncmbAccountGroupName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountGroupName.Location = new System.Drawing.Point(315, 7);
            this.ui_ncmbAccountGroupName.Name = "ui_ncmbAccountGroupName";
            this.ui_ncmbAccountGroupName.Size = new System.Drawing.Size(115, 22);
            this.ui_ncmbAccountGroupName.TabIndex = 1;
            this.ui_ncmbAccountGroupName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAccountGroupName_SelectedIndexChanged);
            // 
            // uctlCollateralMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlCollateralMain";
            this.Size = new System.Drawing.Size(1030, 344);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvCollateral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvCollateral;
        private System.Windows.Forms.Label lblBrokerType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerTypes;
        private System.Windows.Forms.Label lblAccountGroupName;
        private System.Windows.Forms.Label lblParentOwner;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtParentOwnerName;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOwnerName;
        private System.Windows.Forms.Label lblOwnerName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountGroupName;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentOwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCollateral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unallocated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utilized;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayInShortage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayOutShortage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollateralforTrading;
    }
}
