namespace BOADMIN_NEW.Uctl
{
    partial class uctlSymbolMain
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
            System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonView;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblSecurityType = new System.Windows.Forms.Label();
            this.ui_dtgSymbol = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonAddContract = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblExpiryDate = new System.Windows.Forms.Label();
            this.ui_ncmbSecurityType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblProductName = new System.Windows.Forms.Label();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ncmbProductName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_pnlBankCountry = new System.Windows.Forms.Panel();
            this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpExpiryDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Execution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Long = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Short = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Digits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ui_contextmnuCommonView = new System.Windows.Forms.ToolStripMenuItem();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgSymbol)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.ui_pnlBankCountry.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_contextmnuCommonView
            // 
            ui_contextmnuCommonView.Name = "ui_contextmnuCommonView";
            ui_contextmnuCommonView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            ui_contextmnuCommonView.Size = new System.Drawing.Size(192, 22);
            ui_contextmnuCommonView.Text = "View";
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(948, 434);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ui_lblSecurityType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_dtgSymbol, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nbtnSearch, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblExpiryDate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbSecurityType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblProductName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ntxtSymbol, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbProductName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblSymbol, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_pnlBankCountry, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 432);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // ui_lblSecurityType
            // 
            this.ui_lblSecurityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblSecurityType.AutoSize = true;
            this.ui_lblSecurityType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSecurityType.Location = new System.Drawing.Point(3, 9);
            this.ui_lblSecurityType.Name = "ui_lblSecurityType";
            this.ui_lblSecurityType.Size = new System.Drawing.Size(78, 13);
            this.ui_lblSecurityType.TabIndex = 7;
            this.ui_lblSecurityType.Text = "Security Type :";
            // 
            // ui_dtgSymbol
            // 
            this.ui_dtgSymbol.AllowUserToAddRows = false;
            this.ui_dtgSymbol.AllowUserToDeleteRows = false;
            this.ui_dtgSymbol.AllowUserToOrderColumns = true;
            this.ui_dtgSymbol.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgSymbol.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgSymbol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dtgSymbol.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgSymbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_dtgSymbol, 9);
            this.ui_dtgSymbol.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgSymbol.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgSymbol.EnableCellCustomDraw = false;
            this.ui_dtgSymbol.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgSymbol.Location = new System.Drawing.Point(3, 35);
            this.ui_dtgSymbol.MultiSelect = false;
            this.ui_dtgSymbol.Name = "ui_dtgSymbol";
            this.ui_dtgSymbol.ReadOnly = true;
            this.ui_dtgSymbol.RowHeadersVisible = false;
            this.ui_dtgSymbol.RowHeadersWidth = 20;
            this.ui_dtgSymbol.RowTemplate.Height = 24;
            this.ui_dtgSymbol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgSymbol.Size = new System.Drawing.Size(940, 374);
            this.ui_dtgSymbol.TabIndex = 0;
            this.ui_dtgSymbol.UseColumnContextMenu = false;
            this.ui_dtgSymbol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgSymbol_CellContentClick);
            this.ui_dtgSymbol.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgSymbol_CellDoubleClick);
            this.ui_dtgSymbol.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_dtgSymbol_DataError);
            this.ui_dtgSymbol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgSymbol_MouseDown);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ui_contextmnuCommonView,
            this.ui_contextmnuCommonAddContract,
            this.ui_contextmnuCommonNew,
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(193, 114);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            // 
            // ui_contextmnuCommonAddContract
            // 
            this.ui_contextmnuCommonAddContract.Name = "ui_contextmnuCommonAddContract";
            this.ui_contextmnuCommonAddContract.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ui_contextmnuCommonAddContract.Size = new System.Drawing.Size(192, 22);
            this.ui_contextmnuCommonAddContract.Text = "Add Contract";
            // 
            // ui_contextmnuCommonNew
            // 
            this.ui_contextmnuCommonNew.Name = "ui_contextmnuCommonNew";
            this.ui_contextmnuCommonNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonNew.Size = new System.Drawing.Size(192, 22);
            this.ui_contextmnuCommonNew.Text = "New Contract";
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(192, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(192, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            // 
            // nbtnSearch
            // 
            this.nbtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nbtnSearch.Location = new System.Drawing.Point(868, 5);
            this.nbtnSearch.Name = "nbtnSearch";
            this.nbtnSearch.Size = new System.Drawing.Size(75, 21);
            this.nbtnSearch.TabIndex = 9;
            this.nbtnSearch.Text = "Search";
            this.nbtnSearch.UseVisualStyleBackColor = false;
            this.nbtnSearch.Click += new System.EventHandler(this.nbtnSearch_Click);
            // 
            // ui_lblExpiryDate
            // 
            this.ui_lblExpiryDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblExpiryDate.AutoSize = true;
            this.ui_lblExpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblExpiryDate.Location = new System.Drawing.Point(607, 9);
            this.ui_lblExpiryDate.Name = "ui_lblExpiryDate";
            this.ui_lblExpiryDate.Size = new System.Drawing.Size(67, 13);
            this.ui_lblExpiryDate.TabIndex = 12;
            this.ui_lblExpiryDate.Text = "Expiry Date :";
            // 
            // ui_ncmbSecurityType
            // 
            this.ui_ncmbSecurityType.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbSecurityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbSecurityType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSecurityType.Location = new System.Drawing.Point(103, 7);
            this.ui_ncmbSecurityType.Name = "ui_ncmbSecurityType";
            this.ui_ncmbSecurityType.Size = new System.Drawing.Size(114, 18);
            this.ui_ncmbSecurityType.TabIndex = 0;
            this.ui_ncmbSecurityType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbSecurityType_SelectedIndexChanged);
            // 
            // ui_lblProductName
            // 
            this.ui_lblProductName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblProductName.AutoSize = true;
            this.ui_lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProductName.Location = new System.Drawing.Point(223, 9);
            this.ui_lblProductName.Name = "ui_lblProductName";
            this.ui_lblProductName.Size = new System.Drawing.Size(81, 13);
            this.ui_lblProductName.TabIndex = 6;
            this.ui_lblProductName.Text = "Product Name :";
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ntxtSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(487, 7);
            this.ui_ntxtSymbol.MaxLength = 20;
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(114, 18);
            this.ui_ntxtSymbol.TabIndex = 2;
            this.ui_ntxtSymbol.TextChanged += new System.EventHandler(this.ui_ntxtSymbol_TextChanged);
            // 
            // ui_ncmbProductName
            // 
            this.ui_ncmbProductName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbProductName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductName.Location = new System.Drawing.Point(312, 7);
            this.ui_ncmbProductName.Name = "ui_ncmbProductName";
            this.ui_ncmbProductName.Size = new System.Drawing.Size(114, 18);
            this.ui_ncmbProductName.TabIndex = 1;
            this.ui_ncmbProductName.Text = "nComboBox1";
            this.ui_ncmbProductName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductName_SelectedIndexChanged);
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(432, 9);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 8;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_pnlBankCountry
            // 
            this.ui_pnlBankCountry.Controls.Add(this.nButton1);
            this.ui_pnlBankCountry.Controls.Add(this.ui_ndtpExpiryDate);
            this.ui_pnlBankCountry.Location = new System.Drawing.Point(685, 3);
            this.ui_pnlBankCountry.Name = "ui_pnlBankCountry";
            this.ui_pnlBankCountry.Size = new System.Drawing.Size(114, 26);
            this.ui_pnlBankCountry.TabIndex = 121;
            // 
            // nButton1
            // 
            this.nButton1.Image = global::BOADMIN_NEW.Properties.Resources.downarrow;
            this.nButton1.Location = new System.Drawing.Point(134, 0);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(20, 21);
            this.nButton1.TabIndex = 4;
            this.nButton1.UseVisualStyleBackColor = false;
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // ui_ndtpExpiryDate
            // 
            this.ui_ndtpExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ndtpExpiryDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpExpiryDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpExpiryDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpExpiryDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpExpiryDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpExpiryDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpExpiryDate.CustomFormat = "ddMMMyyyy";
            this.ui_ndtpExpiryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpExpiryDate.Location = new System.Drawing.Point(0, 0);
            this.ui_ndtpExpiryDate.Name = "ui_ndtpExpiryDate";
            this.ui_ndtpExpiryDate.Size = new System.Drawing.Size(114, 21);
            this.ui_ndtpExpiryDate.TabIndex = 3;
            this.ui_ndtpExpiryDate.ValueChanged += new System.EventHandler(this.ui_ndtpExpiryDate_ValueChanged);
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Execution
            // 
            this.Execution.HeaderText = "Execution ";
            this.Execution.Name = "Execution";
            this.Execution.ReadOnly = true;
            // 
            // Filter
            // 
            this.Filter.HeaderText = "Filter ";
            this.Filter.Name = "Filter";
            this.Filter.ReadOnly = true;
            // 
            // Spread
            // 
            this.Spread.HeaderText = "Spread";
            this.Spread.Name = "Spread";
            this.Spread.ReadOnly = true;
            // 
            // Stops
            // 
            this.Stops.HeaderText = "Stops";
            this.Stops.Name = "Stops";
            this.Stops.ReadOnly = true;
            // 
            // Long
            // 
            this.Long.HeaderText = "Long ";
            this.Long.Name = "Long";
            this.Long.ReadOnly = true;
            // 
            // Short
            // 
            this.Short.HeaderText = "Short";
            this.Short.Name = "Short";
            this.Short.ReadOnly = true;
            // 
            // Digits
            // 
            this.Digits.HeaderText = "Digits";
            this.Digits.Name = "Digits";
            this.Digits.ReadOnly = true;
            // 
            // Trade
            // 
            this.Trade.HeaderText = "Trade";
            this.Trade.Name = "Trade";
            this.Trade.ReadOnly = true;
            // 
            // uctlSymbolMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uctlSymbolMain";
            this.Size = new System.Drawing.Size(948, 434);
            this.Load += new System.EventHandler(this.uctlSymbolMain_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgSymbol)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ui_pnlBankCountry.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_dtgSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Execution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spread;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stops;
        private System.Windows.Forms.DataGridViewTextBoxColumn Long;
        private System.Windows.Forms.DataGridViewTextBoxColumn Short;
        private System.Windows.Forms.DataGridViewTextBoxColumn Digits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trade;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonAddContract;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonNew;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSecurityType;
        private System.Windows.Forms.Label ui_lblSecurityType;
        private System.Windows.Forms.Label ui_lblProductName;
        private System.Windows.Forms.Label ui_lblSymbol;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private Nevron.UI.WinForm.Controls.NButton nbtnSearch;
        private System.Windows.Forms.Label ui_lblExpiryDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpExpiryDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ui_pnlBankCountry;
        private Nevron.UI.WinForm.Controls.NButton nButton1;
    }
}
