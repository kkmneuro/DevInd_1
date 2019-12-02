namespace CommonLibrary.UserControls
{
    partial class UctlNetPosition
    {
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlNetPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public UctlGrid ui_uctlGridNetPosition;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlNetPosition));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlNetPosition = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_pnlFilter = new System.Windows.Forms.Panel();
            this.ui_nchkTradingCurrency = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_lblProduct = new System.Windows.Forms.Label();
            this.ui_ncmbProduct = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbTradingCurrency = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbAccountNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbClientName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbOminiID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbAccountType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbContracts = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblClient = new System.Windows.Forms.Label();
            this.ui_lblClientName = new System.Windows.Forms.Label();
            this.ui_lblOminiID = new System.Windows.Forms.Label();
            this.ui_lblAccountType = new System.Windows.Forms.Label();
            this.ui_lblContracts = new System.Windows.Forms.Label();
            this.ui_nbtnHideFilter = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_uctlGridNetPosition = new CommonLibrary.UserControls.UctlGrid();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlNetPosition.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ui_pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlNetPosition
            // 
            this.ui_npnlNetPosition.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlNetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlNetPosition.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlNetPosition.Name = "ui_npnlNetPosition";
            this.ui_npnlNetPosition.Size = new System.Drawing.Size(566, 347);
            this.ui_npnlNetPosition.TabIndex = 0;
            this.ui_npnlNetPosition.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ui_pnlFilter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnHideFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_uctlGridNetPosition, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(564, 345);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ui_pnlFilter
            // 
            this.ui_pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.ui_pnlFilter.Controls.Add(this.ui_nchkTradingCurrency);
            this.ui_pnlFilter.Controls.Add(this.ui_lblProduct);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbProduct);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbTradingCurrency);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbAccountNo);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbClientName);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbOminiID);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbAccountType);
            this.ui_pnlFilter.Controls.Add(this.ui_ncmbContracts);
            this.ui_pnlFilter.Controls.Add(this.ui_lblClient);
            this.ui_pnlFilter.Controls.Add(this.ui_lblClientName);
            this.ui_pnlFilter.Controls.Add(this.ui_lblOminiID);
            this.ui_pnlFilter.Controls.Add(this.ui_lblAccountType);
            this.ui_pnlFilter.Controls.Add(this.ui_lblContracts);
            this.ui_pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_pnlFilter.Location = new System.Drawing.Point(3, 24);
            this.ui_pnlFilter.Name = "ui_pnlFilter";
            this.ui_pnlFilter.Size = new System.Drawing.Size(558, 50);
            this.ui_pnlFilter.TabIndex = 3;
            this.ui_pnlFilter.VisibleChanged += new System.EventHandler(this.ui_pnlFilter_VisibleChanged);
            // 
            // ui_nchkTradingCurrency
            // 
            this.ui_nchkTradingCurrency.AutoSize = true;
            this.ui_nchkTradingCurrency.ButtonProperties.BorderOffset = 2;
            this.ui_nchkTradingCurrency.Location = new System.Drawing.Point(266, 42);
            this.ui_nchkTradingCurrency.Name = "ui_nchkTradingCurrency";
            this.ui_nchkTradingCurrency.Size = new System.Drawing.Size(107, 17);
            this.ui_nchkTradingCurrency.TabIndex = 25;
            this.ui_nchkTradingCurrency.TabStop = false;
            this.ui_nchkTradingCurrency.Text = "Trading Currenc&y";
            this.ui_nchkTradingCurrency.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ui_nchkTradingCurrency.Visible = false;
            // 
            // ui_lblProduct
            // 
            this.ui_lblProduct.AutoSize = true;
            this.ui_lblProduct.Location = new System.Drawing.Point(379, 52);
            this.ui_lblProduct.Name = "ui_lblProduct";
            this.ui_lblProduct.Size = new System.Drawing.Size(50, 13);
            this.ui_lblProduct.TabIndex = 12;
            this.ui_lblProduct.Text = "Produc&t :";
            this.ui_lblProduct.Visible = false;
            // 
            // ui_ncmbProduct
            // 
            this.ui_ncmbProduct.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProduct.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProduct.Location = new System.Drawing.Point(379, 50);
            this.ui_ncmbProduct.Name = "ui_ncmbProduct";
            this.ui_ncmbProduct.Size = new System.Drawing.Size(75, 18);
            this.ui_ncmbProduct.TabIndex = 7;
            this.ui_ncmbProduct.Text = "nComboBox1";
            this.ui_ncmbProduct.Visible = false;
            // 
            // ui_ncmbTradingCurrency
            // 
            this.ui_ncmbTradingCurrency.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbTradingCurrency.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbTradingCurrency.Location = new System.Drawing.Point(269, 55);
            this.ui_ncmbTradingCurrency.Name = "ui_ncmbTradingCurrency";
            this.ui_ncmbTradingCurrency.Size = new System.Drawing.Size(86, 10);
            this.ui_ncmbTradingCurrency.TabIndex = 6;
            this.ui_ncmbTradingCurrency.Text = "nComboBox1";
            this.ui_ncmbTradingCurrency.Visible = false;
            // 
            // ui_ncmbAccountNo
            // 
            this.ui_ncmbAccountNo.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("ALL", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAccountNo.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountNo.Location = new System.Drawing.Point(11, 20);
            this.ui_ncmbAccountNo.Name = "ui_ncmbAccountNo";
            this.ui_ncmbAccountNo.Size = new System.Drawing.Size(126, 18);
            this.ui_ncmbAccountNo.TabIndex = 5;
            this.ui_ncmbAccountNo.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbClient_SelectedIndexChanged);
            // 
            // ui_ncmbClientName
            // 
            this.ui_ncmbClientName.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbClientName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbClientName.Location = new System.Drawing.Point(192, 42);
            this.ui_ncmbClientName.Name = "ui_ncmbClientName";
            this.ui_ncmbClientName.Size = new System.Drawing.Size(86, 18);
            this.ui_ncmbClientName.TabIndex = 4;
            this.ui_ncmbClientName.Text = "nComboBox4";
            this.ui_ncmbClientName.Visible = false;
            // 
            // ui_ncmbOminiID
            // 
            this.ui_ncmbOminiID.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbOminiID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOminiID.Location = new System.Drawing.Point(98, 42);
            this.ui_ncmbOminiID.Name = "ui_ncmbOminiID";
            this.ui_ncmbOminiID.Size = new System.Drawing.Size(86, 18);
            this.ui_ncmbOminiID.TabIndex = 3;
            this.ui_ncmbOminiID.Text = "nComboBox3";
            this.ui_ncmbOminiID.Visible = false;
            // 
            // ui_ncmbAccountType
            // 
            this.ui_ncmbAccountType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAccountType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountType.Location = new System.Drawing.Point(12, 42);
            this.ui_ncmbAccountType.Name = "ui_ncmbAccountType";
            this.ui_ncmbAccountType.Size = new System.Drawing.Size(86, 18);
            this.ui_ncmbAccountType.TabIndex = 2;
            this.ui_ncmbAccountType.Text = "nComboBox2";
            this.ui_ncmbAccountType.Visible = false;
            // 
            // ui_ncmbContracts
            // 
            this.ui_ncmbContracts.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("ALL", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbContracts.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbContracts.Location = new System.Drawing.Point(158, 19);
            this.ui_ncmbContracts.Name = "ui_ncmbContracts";
            this.ui_ncmbContracts.Size = new System.Drawing.Size(126, 18);
            this.ui_ncmbContracts.TabIndex = 1;
            this.ui_ncmbContracts.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbContracts_SelectedIndexChanged);
            // 
            // ui_lblClient
            // 
            this.ui_lblClient.AutoSize = true;
            this.ui_lblClient.Location = new System.Drawing.Point(8, 2);
            this.ui_lblClient.Name = "ui_lblClient";
            this.ui_lblClient.Size = new System.Drawing.Size(70, 13);
            this.ui_lblClient.TabIndex = 4;
            this.ui_lblClient.Text = "Account No :";
            // 
            // ui_lblClientName
            // 
            this.ui_lblClientName.AutoSize = true;
            this.ui_lblClientName.Location = new System.Drawing.Point(193, 47);
            this.ui_lblClientName.Name = "ui_lblClientName";
            this.ui_lblClientName.Size = new System.Drawing.Size(70, 13);
            this.ui_lblClientName.TabIndex = 3;
            this.ui_lblClientName.Text = "C&lient Name :";
            this.ui_lblClientName.Visible = false;
            // 
            // ui_lblOminiID
            // 
            this.ui_lblOminiID.AutoSize = true;
            this.ui_lblOminiID.Location = new System.Drawing.Point(104, 42);
            this.ui_lblOminiID.Name = "ui_lblOminiID";
            this.ui_lblOminiID.Size = new System.Drawing.Size(53, 13);
            this.ui_lblOminiID.TabIndex = 2;
            this.ui_lblOminiID.Text = "&Omini ID :";
            this.ui_lblOminiID.Visible = false;
            // 
            // ui_lblAccountType
            // 
            this.ui_lblAccountType.AutoSize = true;
            this.ui_lblAccountType.Location = new System.Drawing.Point(10, 42);
            this.ui_lblAccountType.Name = "ui_lblAccountType";
            this.ui_lblAccountType.Size = new System.Drawing.Size(80, 13);
            this.ui_lblAccountType.TabIndex = 1;
            this.ui_lblAccountType.Text = "Accou&nt Type :";
            this.ui_lblAccountType.Visible = false;
            // 
            // ui_lblContracts
            // 
            this.ui_lblContracts.AutoSize = true;
            this.ui_lblContracts.Location = new System.Drawing.Point(156, 2);
            this.ui_lblContracts.Name = "ui_lblContracts";
            this.ui_lblContracts.Size = new System.Drawing.Size(58, 13);
            this.ui_lblContracts.TabIndex = 0;
            this.ui_lblContracts.Text = "Contracts :";
            // 
            // ui_nbtnHideFilter
            // 
            this.ui_nbtnHideFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_nbtnHideFilter.Location = new System.Drawing.Point(3, 3);
            this.ui_nbtnHideFilter.Name = "ui_nbtnHideFilter";
            this.ui_nbtnHideFilter.Size = new System.Drawing.Size(89, 15);
            this.ui_nbtnHideFilter.TabIndex = 0;
            this.ui_nbtnHideFilter.Text = "Hide &Filter >>";
            this.ui_nbtnHideFilter.UseVisualStyleBackColor = false;
            this.ui_nbtnHideFilter.Click += new System.EventHandler(this.ui_nbtnHideFilter_Click);
            // 
            // ui_uctlGridNetPosition
            // 
            this.ui_uctlGridNetPosition.AllowUserToAddRows = false;
            this.ui_uctlGridNetPosition.AllowUserToDeleteRows = false;
            this.ui_uctlGridNetPosition.AllowUserToOrderColumns = true;
            this.ui_uctlGridNetPosition.AllowUserToResizeColumns = true;
            this.ui_uctlGridNetPosition.AllowUserToResizeRows = false;
            this.ui_uctlGridNetPosition.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridNetPosition.AutoSize = true;
            this.ui_uctlGridNetPosition.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.ui_uctlGridNetPosition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridNetPosition.BackColor = System.Drawing.SystemColors.Control;
            this.ui_uctlGridNetPosition.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridNetPosition.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridNetPosition.ColumnHeaderHeight = 32;
            this.ui_uctlGridNetPosition.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridNetPosition.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridNetPosition.ColumnHeadersHeight = 0;
            this.ui_uctlGridNetPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_uctlGridNetPosition.ColumnHeadersVisible = true;
            this.ui_uctlGridNetPosition.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridNetPosition.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridNetPosition.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridNetPosition.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridNetPosition.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridNetPosition.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridNetPosition.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridNetPosition.DataSource = null;
            this.ui_uctlGridNetPosition.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridNetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridNetPosition.EnableCellCustomDraw = false;
            this.ui_uctlGridNetPosition.EnableHeaderCustomDraw = true;
            this.ui_uctlGridNetPosition.EnableHeadersVisualStyles = true;
            this.ui_uctlGridNetPosition.EnableMultiSelect = false;
            this.ui_uctlGridNetPosition.EnableSkinning = true;
            this.ui_uctlGridNetPosition.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridNetPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ui_uctlGridNetPosition.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridNetPosition.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridNetPosition.GridPalette")));
            this.ui_uctlGridNetPosition.IColIndex = -1;
            this.ui_uctlGridNetPosition.IRowIndex = -1;
            this.ui_uctlGridNetPosition.IsGridReadOnly = true;
            this.ui_uctlGridNetPosition.IsGridVisible = true;
            this.ui_uctlGridNetPosition.IsRowHeadersVisible = false;
            this.ui_uctlGridNetPosition.Location = new System.Drawing.Point(4, 81);
            this.ui_uctlGridNetPosition.Margin = new System.Windows.Forms.Padding(4);
            this.ui_uctlGridNetPosition.Name = "ui_uctlGridNetPosition";
            this.ui_uctlGridNetPosition.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridNetPosition.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridNetPosition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridNetPosition.RowHeight = 23;
            this.ui_uctlGridNetPosition.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridNetPosition.Size = new System.Drawing.Size(556, 260);
            this.ui_uctlGridNetPosition.TabIndex = 0;
            this.ui_uctlGridNetPosition.Title = null;
            this.ui_uctlGridNetPosition.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridNetPosition_OnGridMouseDown);
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnApply.Location = new System.Drawing.Point(456, 18);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(87, 20);
            this.ui_nbtnApply.TabIndex = 8;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // UctlNetPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlNetPosition);
            this.Name = "UctlNetPosition";
            this.Size = new System.Drawing.Size(566, 347);
            this.Load += new System.EventHandler(this.uctlNetPosition_Load);
            this.ui_npnlNetPosition.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ui_pnlFilter.ResumeLayout(false);
            this.ui_pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkTradingCurrency;
        private System.Windows.Forms.Label ui_lblProduct;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProduct;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbTradingCurrency;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountNo;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbClientName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOminiID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbContracts;
        private System.Windows.Forms.Label ui_lblClient;
        private System.Windows.Forms.Label ui_lblClientName;
        private System.Windows.Forms.Label ui_lblOminiID;
        private System.Windows.Forms.Label ui_lblAccountType;
        private System.Windows.Forms.Label ui_lblContracts;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
        public System.Windows.Forms.Panel ui_pnlFilter;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnHideFilter;


    }
}
