namespace BOADMIN_NEW.Uctl
{
    partial class uctlEditBrokersCollateralInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlEditBrokersCollateralInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nEntryBox3 = new Nevron.UI.WinForm.Controls.NEntryBox();
            this.ui_ndgvEntryCollateral = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ECollateralType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollateralTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ui_ndgvSummeryCollateral = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.CollateralType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_clmTransactionHistory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ui_nbtnSave = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtOwner = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtParent = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_nEBoxAccountGroup = new Nevron.UI.WinForm.Controls.NEntryBox();
            this.nEntryBox2 = new Nevron.UI.WinForm.Controls.NEntryBox();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvEntryCollateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvSummeryCollateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nEBoxAccountGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(560, 410);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Controls.Add(this.nEntryBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndgvEntryCollateral, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndgvSummeryCollateral, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnSave, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnCancel, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtOwner, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtParent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nEBoxAccountGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nEntryBox2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.23916F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.274183F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.74017F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.74649F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nEntryBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nEntryBox3, 5);
            this.nEntryBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.nEntryBox3.EditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nEntryBox3.EditControl.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.nEntryBox3.EditControl.Enabled = false;
            this.nEntryBox3.EditControl.Location = new System.Drawing.Point(136, 3);
            this.nEntryBox3.EditControl.Name = "";
            this.nEntryBox3.EditControl.Size = new System.Drawing.Size(415, 14);
            this.nEntryBox3.EditControl.TabIndex = 0;
            this.nEntryBox3.EditControl.Visible = false;
            this.nEntryBox3.EditControl.WordWrap = false;
            this.nEntryBox3.Enabled = false;
            this.nEntryBox3.FillEntryControlBounds = false;
            this.nEntryBox3.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.nEntryBox3.FillInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal;
            this.nEntryBox3.FillInfo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.nEntryBox3.FillInfo.TextureMode = Nevron.UI.WinForm.Controls.TextureMode.Center;
            this.nEntryBox3.Item.ActionButton = System.Windows.Forms.MouseButtons.None;
            this.nEntryBox3.Item.AllowCapture = false;
            this.nEntryBox3.Item.AllowFocus = false;
            this.nEntryBox3.Item.KeyboardInputEnabled = false;
            this.nEntryBox3.Item.Style.Background = new Nevron.UI.NUISmartShape(System.Drawing.Drawing2D.SmoothingMode.Default, new Nevron.GraphicsCore.NSize(0, 0), new Nevron.UI.NPadding(0, 0, 0, 0), null, null, null, ((Nevron.SmartShapes.NSmartShape)(resources.GetObject("resource.Background"))));
            this.nEntryBox3.Item.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 8.5F, Nevron.GraphicsCore.FontStyleEx.Bold);
            this.nEntryBox3.Location = new System.Drawing.Point(2, 65);
            this.nEntryBox3.Margin = new System.Windows.Forms.Padding(0);
            this.nEntryBox3.Name = "nEntryBox3";
            this.nEntryBox3.ShadowInfo.Draw = false;
            this.nEntryBox3.Size = new System.Drawing.Size(554, 20);
            this.nEntryBox3.StrokeInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.nEntryBox3.StrokeInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal;
            this.nEntryBox3.TabIndex = 3;
            this.nEntryBox3.Text = "Summary of Collateral";
            // 
            // ui_ndgvEntryCollateral
            // 
            this.ui_ndgvEntryCollateral.AllowUserToAddRows = false;
            this.ui_ndgvEntryCollateral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvEntryCollateral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndgvEntryCollateral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvEntryCollateral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvEntryCollateral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ndgvEntryCollateral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ECollateralType,
            this.EAmount,
            this.CollateralTypeId,
            this.TransactionType});
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndgvEntryCollateral, 5);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvEntryCollateral.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_ndgvEntryCollateral.DisplayChildRelations = false;
            this.ui_ndgvEntryCollateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvEntryCollateral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ui_ndgvEntryCollateral.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvEntryCollateral.Location = new System.Drawing.Point(2, 239);
            this.ui_ndgvEntryCollateral.Margin = new System.Windows.Forms.Padding(0);
            this.ui_ndgvEntryCollateral.Name = "ui_ndgvEntryCollateral";
            this.ui_ndgvEntryCollateral.RowHeadersVisible = false;
            this.ui_ndgvEntryCollateral.Size = new System.Drawing.Size(554, 131);
            this.ui_ndgvEntryCollateral.TabIndex = 11;
            this.ui_ndgvEntryCollateral.TabStop = false;
            this.ui_ndgvEntryCollateral.UseColumnContextMenu = false;
            this.ui_ndgvEntryCollateral.EditModeChanged += new System.EventHandler(this.ui_ndgvEntryCollateral_EditModeChanged);
            // 
            // ECollateralType
            // 
            this.ECollateralType.DataPropertyName = "CollateralType";
            this.ECollateralType.FillWeight = 150F;
            this.ECollateralType.HeaderText = "Collateral Type";
            this.ECollateralType.MinimumWidth = 100;
            this.ECollateralType.Name = "ECollateralType";
            this.ECollateralType.ReadOnly = true;
            // 
            // EAmount
            // 
            this.EAmount.HeaderText = "Amount";
            this.EAmount.MaxInputLength = 16;
            this.EAmount.Name = "EAmount";
            // 
            // CollateralTypeId
            // 
            this.CollateralTypeId.DataPropertyName = "CollateralTypeId";
            this.CollateralTypeId.HeaderText = "Collateral Type Id";
            this.CollateralTypeId.Name = "CollateralTypeId";
            // 
            // TransactionType
            // 
            dataGridViewCellStyle2.NullValue = "Deposit";
            this.TransactionType.DefaultCellStyle = dataGridViewCellStyle2;
            this.TransactionType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransactionType.HeaderText = "Transaction Type";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TransactionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ui_ndgvSummeryCollateral
            // 
            this.ui_ndgvSummeryCollateral.AllowUserToAddRows = false;
            this.ui_ndgvSummeryCollateral.AllowUserToDeleteRows = false;
            this.ui_ndgvSummeryCollateral.AllowUserToOrderColumns = true;
            this.ui_ndgvSummeryCollateral.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndgvSummeryCollateral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_ndgvSummeryCollateral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvSummeryCollateral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvSummeryCollateral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ndgvSummeryCollateral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CollateralType,
            this.Amount,
            this.TotalAmount,
            this.TransType,
            this.TransactionDate,
            this.ui_clmTransactionHistory});
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndgvSummeryCollateral, 5);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndgvSummeryCollateral.DefaultCellStyle = dataGridViewCellStyle6;
            this.ui_ndgvSummeryCollateral.DisplayChildRelations = false;
            this.ui_ndgvSummeryCollateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvSummeryCollateral.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvSummeryCollateral.Location = new System.Drawing.Point(2, 85);
            this.ui_ndgvSummeryCollateral.Margin = new System.Windows.Forms.Padding(0);
            this.ui_ndgvSummeryCollateral.Name = "ui_ndgvSummeryCollateral";
            this.ui_ndgvSummeryCollateral.RowHeadersVisible = false;
            this.ui_ndgvSummeryCollateral.Size = new System.Drawing.Size(554, 134);
            this.ui_ndgvSummeryCollateral.TabIndex = 1;
            this.ui_ndgvSummeryCollateral.TabStop = false;
            this.ui_ndgvSummeryCollateral.UseColumnContextMenu = false;
            this.ui_ndgvSummeryCollateral.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndgvSummeryCollateral_CellClick);
            // 
            // CollateralType
            // 
            this.CollateralType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CollateralType.DataPropertyName = "CollateralType";
            this.CollateralType.FillWeight = 150F;
            this.CollateralType.HeaderText = "Collateral Type";
            this.CollateralType.MinimumWidth = 100;
            this.CollateralType.Name = "CollateralType";
            this.CollateralType.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // TransType
            // 
            this.TransType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TransType.DataPropertyName = "TransactionType";
            this.TransType.HeaderText = "Transaction Type";
            this.TransType.Name = "TransType";
            this.TransType.ReadOnly = true;
            // 
            // TransactionDate
            // 
            this.TransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TransactionDate.DataPropertyName = "TransactionDate";
            this.TransactionDate.HeaderText = "Transaction Date";
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            // 
            // ui_clmTransactionHistory
            // 
            this.ui_clmTransactionHistory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Trans History";
            this.ui_clmTransactionHistory.DefaultCellStyle = dataGridViewCellStyle5;
            this.ui_clmTransactionHistory.HeaderText = "Trans History";
            this.ui_clmTransactionHistory.Name = "ui_clmTransactionHistory";
            // 
            // ui_nbtnSave
            // 
            this.ui_nbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSave.Location = new System.Drawing.Point(390, 374);
            this.ui_nbtnSave.Name = "ui_nbtnSave";
            this.ui_nbtnSave.Size = new System.Drawing.Size(77, 28);
            this.ui_nbtnSave.TabIndex = 5;
            this.ui_nbtnSave.Text = "Save";
            this.ui_nbtnSave.UseVisualStyleBackColor = false;
            this.ui_nbtnSave.Click += new System.EventHandler(this.ui_nbtnSave_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnCancel.Location = new System.Drawing.Point(473, 374);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(80, 28);
            this.ui_nbtnCancel.TabIndex = 6;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_ntxtOwner
            // 
            this.ui_ntxtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ntxtOwner, 2);
            this.ui_ntxtOwner.Location = new System.Drawing.Point(390, 41);
            this.ui_ntxtOwner.Name = "ui_ntxtOwner";
            this.ui_ntxtOwner.ReadOnly = true;
            this.ui_ntxtOwner.Size = new System.Drawing.Size(163, 18);
            this.ui_ntxtOwner.TabIndex = 2;
            // 
            // ui_ntxtParent
            // 
            this.ui_ntxtParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtParent.Location = new System.Drawing.Point(84, 41);
            this.ui_ntxtParent.Name = "ui_ntxtParent";
            this.ui_ntxtParent.ReadOnly = true;
            this.ui_ntxtParent.Size = new System.Drawing.Size(247, 18);
            this.ui_ntxtParent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parent :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Owner :";
            // 
            // ui_nEBoxAccountGroup
            // 
            this.ui_nEBoxAccountGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_nEBoxAccountGroup, 5);
            this.ui_nEBoxAccountGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.ui_nEBoxAccountGroup.EditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nEBoxAccountGroup.EditControl.Border.Style = Nevron.UI.BorderStyle3D.Flat;
            this.ui_nEBoxAccountGroup.EditControl.Location = new System.Drawing.Point(138, 7);
            this.ui_nEBoxAccountGroup.EditControl.Name = "";
            this.ui_nEBoxAccountGroup.EditControl.ReadOnly = true;
            this.ui_nEBoxAccountGroup.EditControl.Size = new System.Drawing.Size(413, 18);
            this.ui_nEBoxAccountGroup.EditControl.TabIndex = 0;
            this.ui_nEBoxAccountGroup.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.ui_nEBoxAccountGroup.FillInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal;
            this.ui_nEBoxAccountGroup.FillInfo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.ui_nEBoxAccountGroup.FillInfo.TextureMode = Nevron.UI.WinForm.Controls.TextureMode.Center;
            this.ui_nEBoxAccountGroup.Item.ActionButton = System.Windows.Forms.MouseButtons.None;
            this.ui_nEBoxAccountGroup.Item.AllowCapture = false;
            this.ui_nEBoxAccountGroup.Item.AllowFocus = false;
            this.ui_nEBoxAccountGroup.Item.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 8.25F, Nevron.GraphicsCore.FontStyleEx.Bold);
            this.ui_nEBoxAccountGroup.Location = new System.Drawing.Point(2, 2);
            this.ui_nEBoxAccountGroup.Margin = new System.Windows.Forms.Padding(0);
            this.ui_nEBoxAccountGroup.Name = "ui_nEBoxAccountGroup";
            this.ui_nEBoxAccountGroup.ShadowInfo.Draw = false;
            this.ui_nEBoxAccountGroup.Size = new System.Drawing.Size(554, 33);
            this.ui_nEBoxAccountGroup.TabIndex = 0;
            this.ui_nEBoxAccountGroup.Text = "Account Group Name :";
            // 
            // nEntryBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nEntryBox2, 5);
            this.nEntryBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            // 
            // 
            // 
            this.nEntryBox2.EditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nEntryBox2.EditControl.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.nEntryBox2.EditControl.Enabled = false;
            this.nEntryBox2.EditControl.Location = new System.Drawing.Point(174, 2);
            this.nEntryBox2.EditControl.Name = "";
            this.nEntryBox2.EditControl.Size = new System.Drawing.Size(377, 15);
            this.nEntryBox2.EditControl.TabIndex = 0;
            this.nEntryBox2.EditControl.Visible = false;
            this.nEntryBox2.EditControl.WordWrap = false;
            this.nEntryBox2.Enabled = false;
            this.nEntryBox2.FillEntryControlBounds = false;
            this.nEntryBox2.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.nEntryBox2.FillInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal;
            this.nEntryBox2.FillInfo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.nEntryBox2.FillInfo.TextureMode = Nevron.UI.WinForm.Controls.TextureMode.Center;
            this.nEntryBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nEntryBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nEntryBox2.Item.ActionButton = System.Windows.Forms.MouseButtons.None;
            this.nEntryBox2.Item.AllowCapture = false;
            this.nEntryBox2.Item.AllowFocus = false;
            this.nEntryBox2.Item.KeyboardInputEnabled = false;
            this.nEntryBox2.Item.Style.Background = new Nevron.UI.NUISmartShape(System.Drawing.Drawing2D.SmoothingMode.Default, new Nevron.GraphicsCore.NSize(0, 0), new Nevron.UI.NPadding(0, 0, 0, 0), null, null, null, ((Nevron.SmartShapes.NSmartShape)(resources.GetObject("resource.Background1"))));
            this.nEntryBox2.Item.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 8.5F, Nevron.GraphicsCore.FontStyleEx.Bold);
            this.nEntryBox2.Location = new System.Drawing.Point(2, 219);
            this.nEntryBox2.Margin = new System.Windows.Forms.Padding(0);
            this.nEntryBox2.Name = "nEntryBox2";
            this.nEntryBox2.ShadowInfo.Draw = false;
            this.nEntryBox2.Size = new System.Drawing.Size(554, 20);
            this.nEntryBox2.StrokeInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.nEntryBox2.StrokeInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal;
            this.nEntryBox2.TabIndex = 4;
            this.nEntryBox2.Text = "Entry For Collateral Updation";
            // 
            // uctlEditBrokersCollateralInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlEditBrokersCollateralInfo";
            this.Size = new System.Drawing.Size(560, 410);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvEntryCollateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvSummeryCollateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nEBoxAccountGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSave;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtParent;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOwner;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvEntryCollateral;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvSummeryCollateral;
        private Nevron.UI.WinForm.Controls.NEntryBox ui_nEBoxAccountGroup;
        private Nevron.UI.WinForm.Controls.NEntryBox nEntryBox2;
        private Nevron.UI.WinForm.Controls.NEntryBox nEntryBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollateralType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewButtonColumn ui_clmTransactionHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECollateralType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollateralTypeId;
        private System.Windows.Forms.DataGridViewComboBoxColumn TransactionType;
    }
}
