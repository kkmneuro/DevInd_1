namespace CommonLibrary.UserControls
{
    partial class UctlOrderBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlOrderBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlOrderBook = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tlpnlOrderBookTable = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nbtnHideFilter = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_uctlGridOrderBook = new CommonLibrary.UserControls.UctlGrid();
            this.ui_npnlFilter = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ncmbAccountNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_lblInstrumentName = new System.Windows.Forms.Label();
            this.ui_ndtpTo = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpFrom = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblTo = new System.Windows.Forms.Label();
            this.ui_ncmbProductType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblOrderType = new System.Windows.Forms.Label();
            this.ui_ncmbOrderType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblFrom = new System.Windows.Forms.Label();
            this.ui_lblBS = new System.Windows.Forms.Label();
            this.ui_ncmbOrderStatus = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbBS = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblOrderStatus = new System.Windows.Forms.Label();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nsbOrderSatusBar = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.ui_nsbFilterLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbFilterValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbBuyQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSellQtyLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbSelQtyValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbNoOfOrdersLabel = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_nsbNoOfOrdersValue = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.ui_npnlOrderBook.SuspendLayout();
            this.ui_tlpnlOrderBookTable.SuspendLayout();
            this.ui_npnlFilter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSelQtyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbNoOfOrdersLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbNoOfOrdersValue)).BeginInit();
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
            this.ui_tlpnlOrderBookTable.ColumnCount = 2;
            this.ui_tlpnlOrderBookTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.613375F));
            this.ui_tlpnlOrderBookTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.38663F));
            this.ui_tlpnlOrderBookTable.Controls.Add(this.ui_nbtnHideFilter, 0, 0);
            this.ui_tlpnlOrderBookTable.Controls.Add(this.ui_uctlGridOrderBook, 0, 1);
            this.ui_tlpnlOrderBookTable.Controls.Add(this.ui_npnlFilter, 1, 0);
            this.ui_tlpnlOrderBookTable.Controls.Add(this.ui_nsbOrderSatusBar, 1, 2);
            this.ui_tlpnlOrderBookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpnlOrderBookTable.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpnlOrderBookTable.Name = "ui_tlpnlOrderBookTable";
            this.ui_tlpnlOrderBookTable.RowCount = 3;
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpnlOrderBookTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpnlOrderBookTable.Size = new System.Drawing.Size(992, 340);
            this.ui_tlpnlOrderBookTable.TabIndex = 2;
            this.ui_tlpnlOrderBookTable.Paint += new System.Windows.Forms.PaintEventHandler(this.ui_tlpnlOrderBookTable_Paint);
            // 
            // ui_nbtnHideFilter
            // 
            this.ui_nbtnHideFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnHideFilter.Location = new System.Drawing.Point(5, 3);
            this.ui_nbtnHideFilter.Name = "ui_nbtnHideFilter";
            this.ui_nbtnHideFilter.Size = new System.Drawing.Size(85, 27);
            this.ui_nbtnHideFilter.TabIndex = 2;
            this.ui_nbtnHideFilter.Text = "Hide &Filter <<";
            this.ui_nbtnHideFilter.UseVisualStyleBackColor = false;
            this.ui_nbtnHideFilter.Visible = false;
            this.ui_nbtnHideFilter.Click += new System.EventHandler(this.ui_nbtnHideFilter_Click);
            // 
            // ui_uctlGridOrderBook
            // 
            this.ui_uctlGridOrderBook.AllowUserToAddRows = false;
            this.ui_uctlGridOrderBook.AllowUserToDeleteRows = false;
            this.ui_uctlGridOrderBook.AllowUserToOrderColumns = true;
            this.ui_uctlGridOrderBook.AllowUserToResizeColumns = true;
            this.ui_uctlGridOrderBook.AllowUserToResizeRows = true;
            this.ui_uctlGridOrderBook.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridOrderBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_uctlGridOrderBook.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ui_uctlGridOrderBook.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ui_uctlGridOrderBook.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridOrderBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridOrderBook.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridOrderBook.ColumnHeaderHeight = 4;
            this.ui_uctlGridOrderBook.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridOrderBook.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridOrderBook.ColumnHeadersHeight = 0;
            this.ui_uctlGridOrderBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridOrderBook.ColumnHeadersVisible = true;
            this.ui_tlpnlOrderBookTable.SetColumnSpan(this.ui_uctlGridOrderBook, 2);
            this.ui_uctlGridOrderBook.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridOrderBook.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridOrderBook.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridOrderBook.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridOrderBook.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridOrderBook.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridOrderBook.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridOrderBook.DataSource = null;
            this.ui_uctlGridOrderBook.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridOrderBook.EnableCellCustomDraw = false;
            this.ui_uctlGridOrderBook.EnableHeaderCustomDraw = true;
            this.ui_uctlGridOrderBook.EnableHeadersVisualStyles = true;
            this.ui_uctlGridOrderBook.EnableMultiSelect = false;
            this.ui_uctlGridOrderBook.EnableSkinning = true;
            this.ui_uctlGridOrderBook.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridOrderBook.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridOrderBook.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridOrderBook.GridPalette")));
            this.ui_uctlGridOrderBook.IColIndex = -1;
            this.ui_uctlGridOrderBook.IRowIndex = -1;
            this.ui_uctlGridOrderBook.IsGridReadOnly = true;
            this.ui_uctlGridOrderBook.IsGridVisible = true;
            this.ui_uctlGridOrderBook.IsRowHeadersVisible = false;
            this.ui_uctlGridOrderBook.Location = new System.Drawing.Point(1, 34);
            this.ui_uctlGridOrderBook.Margin = new System.Windows.Forms.Padding(1);
            this.ui_uctlGridOrderBook.Name = "ui_uctlGridOrderBook";
            this.ui_uctlGridOrderBook.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridOrderBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridOrderBook.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridOrderBook.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridOrderBook.Size = new System.Drawing.Size(990, 285);
            this.ui_uctlGridOrderBook.TabIndex = 6;
            this.ui_uctlGridOrderBook.Title = null;
            this.ui_uctlGridOrderBook.OnRowsAdded += new CommonLibrary.UserControls.UctlGrid.DataGridViewRowsAddedEventHandeler(this.ui_uctlGridOrderBook_OnRowsAdded);
            this.ui_uctlGridOrderBook.OnRowsRemoved += new CommonLibrary.UserControls.UctlGrid.DataGridViewRowsRemovedEventHandeler(this.ui_uctlGridOrderBook_OnRowsRemoved);
            this.ui_uctlGridOrderBook.OnGridMouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_uctlGridOrderBook_OnGridMouseDown);
            this.ui_uctlGridOrderBook.OnGridCellEnter += new System.Action<object, System.Windows.Forms.DataGridViewCellEventArgs>(this.ui_uctlGridOrderBook_OnGridCellEnter);
            // 
            // ui_npnlFilter
            // 
            this.ui_npnlFilter.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlFilter.Location = new System.Drawing.Point(96, 1);
            this.ui_npnlFilter.Margin = new System.Windows.Forms.Padding(1);
            this.ui_npnlFilter.Name = "ui_npnlFilter";
            this.ui_npnlFilter.Size = new System.Drawing.Size(895, 31);
            this.ui_npnlFilter.TabIndex = 3;
            this.ui_npnlFilter.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbAccountNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblInstrumentName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndtpTo, 13, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndtpFrom, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblTo, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbProductType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblOrderType, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbOrderType, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblFrom, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblBS, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbOrderStatus, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbBS, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblOrderStatus, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnSearch, 14, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 29);
            this.tableLayoutPanel1.TabIndex = 78;
            this.tableLayoutPanel1.Visible = false;
            // 
            // ui_ncmbAccountNo
            // 
            this.ui_ncmbAccountNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbAccountNo.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountNo.Location = new System.Drawing.Point(76, 5);
            this.ui_ncmbAccountNo.Name = "ui_ncmbAccountNo";
            this.ui_ncmbAccountNo.Size = new System.Drawing.Size(76, 18);
            this.ui_ncmbAccountNo.TabIndex = 80;
            this.ui_ncmbAccountNo.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAccountNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Account No:";
            // 
            // ui_lblInstrumentName
            // 
            this.ui_lblInstrumentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblInstrumentName.AutoSize = true;
            this.ui_lblInstrumentName.Location = new System.Drawing.Point(158, 8);
            this.ui_lblInstrumentName.Name = "ui_lblInstrumentName";
            this.ui_lblInstrumentName.Size = new System.Drawing.Size(77, 13);
            this.ui_lblInstrumentName.TabIndex = 66;
            this.ui_lblInstrumentName.Text = "Product Type :";
            // 
            // ui_ndtpTo
            // 
            this.ui_ndtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ndtpTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpTo.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpTo.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            this.ui_ndtpTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpTo.Location = new System.Drawing.Point(741, 4);
            this.ui_ndtpTo.Name = "ui_ndtpTo";
            this.ui_ndtpTo.ShowUpDown = true;
            this.ui_ndtpTo.Size = new System.Drawing.Size(85, 21);
            this.ui_ndtpTo.TabIndex = 77;
            this.ui_ndtpTo.Visible = false;
            this.ui_ndtpTo.ValueChanged += new System.EventHandler(this.ui_ndtpTo_ValueChanged);
            // 
            // ui_ndtpFrom
            // 
            this.ui_ndtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ndtpFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpFrom.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpFrom.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpFrom.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            this.ui_ndtpFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpFrom.Location = new System.Drawing.Point(618, 4);
            this.ui_ndtpFrom.Name = "ui_ndtpFrom";
            this.ui_ndtpFrom.ShowUpDown = true;
            this.ui_ndtpFrom.Size = new System.Drawing.Size(85, 21);
            this.ui_ndtpFrom.TabIndex = 76;
            this.ui_ndtpFrom.Visible = false;
            this.ui_ndtpFrom.ValueChanged += new System.EventHandler(this.ui_ndtpFrom_ValueChanged);
            // 
            // ui_lblTo
            // 
            this.ui_lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblTo.AutoSize = true;
            this.ui_lblTo.Location = new System.Drawing.Point(709, 8);
            this.ui_lblTo.Name = "ui_lblTo";
            this.ui_lblTo.Size = new System.Drawing.Size(26, 13);
            this.ui_lblTo.TabIndex = 75;
            this.ui_lblTo.Text = "To :";
            this.ui_lblTo.Visible = false;
            // 
            // ui_ncmbProductType
            // 
            this.ui_ncmbProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbProductType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductType.Location = new System.Drawing.Point(241, 5);
            this.ui_ncmbProductType.Name = "ui_ncmbProductType";
            this.ui_ncmbProductType.Size = new System.Drawing.Size(76, 18);
            this.ui_ncmbProductType.TabIndex = 67;
            this.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductType_SelectedIndexChanged);
            // 
            // ui_lblOrderType
            // 
            this.ui_lblOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblOrderType.AutoSize = true;
            this.ui_lblOrderType.Location = new System.Drawing.Point(323, 8);
            this.ui_lblOrderType.Name = "ui_lblOrderType";
            this.ui_lblOrderType.Size = new System.Drawing.Size(66, 13);
            this.ui_lblOrderType.TabIndex = 68;
            this.ui_lblOrderType.Text = "Order Type :";
            // 
            // ui_ncmbOrderType
            // 
            this.ui_ncmbOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbOrderType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderType.Location = new System.Drawing.Point(395, 5);
            this.ui_ncmbOrderType.Name = "ui_ncmbOrderType";
            this.ui_ncmbOrderType.Size = new System.Drawing.Size(87, 18);
            this.ui_ncmbOrderType.TabIndex = 69;
            this.ui_ncmbOrderType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbOrderType_SelectedIndexChanged);
            // 
            // ui_lblFrom
            // 
            this.ui_lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblFrom.AutoSize = true;
            this.ui_lblFrom.Location = new System.Drawing.Point(576, 8);
            this.ui_lblFrom.Name = "ui_lblFrom";
            this.ui_lblFrom.Size = new System.Drawing.Size(36, 13);
            this.ui_lblFrom.TabIndex = 73;
            this.ui_lblFrom.Text = "From :";
            this.ui_lblFrom.Visible = false;
            // 
            // ui_lblBS
            // 
            this.ui_lblBS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblBS.AutoSize = true;
            this.ui_lblBS.Location = new System.Drawing.Point(488, 8);
            this.ui_lblBS.Name = "ui_lblBS";
            this.ui_lblBS.Size = new System.Drawing.Size(32, 13);
            this.ui_lblBS.TabIndex = 70;
            this.ui_lblBS.Text = "B/S :";
            // 
            // ui_ncmbOrderStatus
            // 
            this.ui_ncmbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbOrderStatus.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderStatus.Location = new System.Drawing.Point(669, 5);
            this.ui_ncmbOrderStatus.Name = "ui_ncmbOrderStatus";
            this.ui_ncmbOrderStatus.Size = new System.Drawing.Size(1, 18);
            this.ui_ncmbOrderStatus.TabIndex = 74;
            this.ui_ncmbOrderStatus.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbOrderStatus_SelectedIndexChanged);
            // 
            // ui_ncmbBS
            // 
            this.ui_ncmbBS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbBS.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBS.Location = new System.Drawing.Point(526, 5);
            this.ui_ncmbBS.Name = "ui_ncmbBS";
            this.ui_ncmbBS.Size = new System.Drawing.Size(59, 18);
            this.ui_ncmbBS.TabIndex = 71;
            this.ui_ncmbBS.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBS_SelectedIndexChanged);
            // 
            // ui_lblOrderStatus
            // 
            this.ui_lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblOrderStatus.AutoSize = true;
            this.ui_lblOrderStatus.Location = new System.Drawing.Point(591, 8);
            this.ui_lblOrderStatus.Name = "ui_lblOrderStatus";
            this.ui_lblOrderStatus.Size = new System.Drawing.Size(72, 13);
            this.ui_lblOrderStatus.TabIndex = 72;
            this.ui_lblOrderStatus.Text = "Order Status :";
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_nbtnSearch.Location = new System.Drawing.Point(832, 3);
            this.ui_nbtnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Size = new System.Drawing.Size(51, 23);
            this.ui_nbtnSearch.TabIndex = 78;
            this.ui_nbtnSearch.Text = "Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Visible = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_nsbOrderSatusBar
            // 
            this.ui_tlpnlOrderBookTable.SetColumnSpan(this.ui_nsbOrderSatusBar, 2);
            this.ui_nsbOrderSatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_nsbOrderSatusBar.Location = new System.Drawing.Point(1, 321);
            this.ui_nsbOrderSatusBar.Margin = new System.Windows.Forms.Padding(1);
            this.ui_nsbOrderSatusBar.Name = "ui_nsbOrderSatusBar";
            this.ui_nsbOrderSatusBar.Panels.AddRange(new Nevron.UI.WinForm.Controls.NStatusBarPanel[] {
            this.ui_nsbFilterLabel,
            this.ui_nsbFilterValue,
            this.ui_nsbBuyQtyLabel,
            this.ui_nsbBuyQtyValue,
            this.ui_nsbSellQtyLabel,
            this.ui_nsbSelQtyValue,
            this.ui_nsbNoOfOrdersLabel,
            this.ui_nsbNoOfOrdersValue});
            this.ui_nsbOrderSatusBar.ShowPanels = true;
            this.ui_nsbOrderSatusBar.Size = new System.Drawing.Size(990, 20);
            this.ui_nsbOrderSatusBar.TabIndex = 7;
            // 
            // ui_nsbFilterLabel
            // 
            this.ui_nsbFilterLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbFilterLabel.Name = "ui_nsbFilterLabel";
            this.ui_nsbFilterLabel.Text = "Filters :";
            this.ui_nsbFilterLabel.Width = 40;
            // 
            // ui_nsbFilterValue
            // 
            this.ui_nsbFilterValue.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.ui_nsbFilterValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbFilterValue.Name = "ui_nsbFilterValue";
            this.ui_nsbFilterValue.Width = 603;
            // 
            // ui_nsbBuyQtyLabel
            // 
            this.ui_nsbBuyQtyLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyQtyLabel.Name = "ui_nsbBuyQtyLabel";
            this.ui_nsbBuyQtyLabel.Text = "BuyQty :";
            this.ui_nsbBuyQtyLabel.Width = 50;
            // 
            // ui_nsbBuyQtyValue
            // 
            this.ui_nsbBuyQtyValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbBuyQtyValue.Name = "ui_nsbBuyQtyValue";
            this.ui_nsbBuyQtyValue.Width = 50;
            // 
            // ui_nsbSellQtyLabel
            // 
            this.ui_nsbSellQtyLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSellQtyLabel.Name = "ui_nsbSellQtyLabel";
            this.ui_nsbSellQtyLabel.Text = "SellQty :";
            this.ui_nsbSellQtyLabel.Width = 50;
            // 
            // ui_nsbSelQtyValue
            // 
            this.ui_nsbSelQtyValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbSelQtyValue.Name = "ui_nsbSelQtyValue";
            this.ui_nsbSelQtyValue.Width = 50;
            // 
            // ui_nsbNoOfOrdersLabel
            // 
            this.ui_nsbNoOfOrdersLabel.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbNoOfOrdersLabel.Name = "ui_nsbNoOfOrdersLabel";
            this.ui_nsbNoOfOrdersLabel.Text = "No Of Orders :";
            this.ui_nsbNoOfOrdersLabel.Width = 80;
            // 
            // ui_nsbNoOfOrdersValue
            // 
            this.ui_nsbNoOfOrdersValue.BorderStyle = Nevron.UI.BorderStyle3D.None;
            this.ui_nsbNoOfOrdersValue.Name = "ui_nsbNoOfOrdersValue";
            this.ui_nsbNoOfOrdersValue.Width = 50;
            // 
            // UctlOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlOrderBook);
            this.Name = "UctlOrderBook";
            this.Size = new System.Drawing.Size(994, 342);
            this.Load += new System.EventHandler(this.uctlOrderBook_Load);
            this.Click += new System.EventHandler(this.uctlOrderBook_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uctlOrderBook_MouseClick);
            this.ui_npnlOrderBook.ResumeLayout(false);
            this.ui_npnlOrderBook.PerformLayout();
            this.ui_tlpnlOrderBookTable.ResumeLayout(false);
            this.ui_npnlFilter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbFilterValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbBuyQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSellQtyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbSelQtyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbNoOfOrdersLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nsbNoOfOrdersValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlOrderBook;
        private System.Windows.Forms.TableLayoutPanel ui_tlpnlOrderBookTable;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnHideFilter;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlFilter;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpTo;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFrom;
        private System.Windows.Forms.Label ui_lblTo;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderStatus;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBS;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductType;
        private System.Windows.Forms.Label ui_lblFrom;
        private System.Windows.Forms.Label ui_lblOrderStatus;
        private System.Windows.Forms.Label ui_lblBS;
        private System.Windows.Forms.Label ui_lblOrderType;
        private System.Windows.Forms.Label ui_lblInstrumentName;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel1;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel2;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel3;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel4;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel5;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel6;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel7;
        //private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel8;
        public UctlGrid ui_uctlGridOrderBook;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountNo;
        private System.Windows.Forms.Label label1;
        public Nevron.UI.WinForm.Controls.NStatusBar ui_nsbOrderSatusBar;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbFilterLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbBuyQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSellQtyLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbSelQtyValue;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbNoOfOrdersLabel;
        private Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbNoOfOrdersValue;
        public Nevron.UI.WinForm.Controls.NStatusBarPanel ui_nsbFilterValue;

    }
}
