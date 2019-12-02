namespace BOADMIN_NEW.Uctl
{
    partial class uctlTradeMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nbtnNewTrade = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnHideFilter = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtgTrades = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonNewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_npnlFilter = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ncmbOrderStatus = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblBrokerName = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAccountID = new System.Windows.Forms.Label();
            this.ui_ncmbAccountID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_ncmbOrderNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblStartDate = new System.Windows.Forms.Label();
            this.ui_ndtpStartTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblEndDate = new System.Windows.Forms.Label();
            this.ui_ndtpEndDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_ncmbTradeNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_nbtnRefresh = new Nevron.UI.WinForm.Controls.NButton();
            this.MytoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgTrades)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.ui_npnlFilter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(933, 398);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnNewTrade, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnHideFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ndtgTrades, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ui_npnlFilter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnRefresh, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ui_nbtnNewTrade
            // 
            this.ui_nbtnNewTrade.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_nbtnNewTrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnNewTrade.Location = new System.Drawing.Point(784, 3);
            this.ui_nbtnNewTrade.Name = "ui_nbtnNewTrade";
            this.ui_nbtnNewTrade.Size = new System.Drawing.Size(89, 21);
            this.ui_nbtnNewTrade.TabIndex = 2;
            this.ui_nbtnNewTrade.Text = "New Trade";
            this.MytoolTip.SetToolTip(this.ui_nbtnNewTrade, "New Trade");
            this.ui_nbtnNewTrade.UseVisualStyleBackColor = false;
            this.ui_nbtnNewTrade.Click += new System.EventHandler(this.ui_nbtnNewTrade_Click);
            // 
            // ui_nbtnHideFilter
            // 
            this.ui_nbtnHideFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_nbtnHideFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnHideFilter.Location = new System.Drawing.Point(3, 3);
            this.ui_nbtnHideFilter.Name = "ui_nbtnHideFilter";
            this.ui_nbtnHideFilter.Size = new System.Drawing.Size(89, 21);
            this.ui_nbtnHideFilter.TabIndex = 1;
            this.ui_nbtnHideFilter.Text = "Hide &Filter <<";
            this.MytoolTip.SetToolTip(this.ui_nbtnHideFilter, "Hide Filter");
            this.ui_nbtnHideFilter.UseVisualStyleBackColor = false;
            this.ui_nbtnHideFilter.Click += new System.EventHandler(this.ui_nbtnHideFilter_Click);
            // 
            // ui_ndtgTrades
            // 
            this.ui_ndtgTrades.AllowUserToAddRows = false;
            this.ui_ndtgTrades.AllowUserToDeleteRows = false;
            this.ui_ndtgTrades.AllowUserToOrderColumns = true;
            this.ui_ndtgTrades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndtgTrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndtgTrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndtgTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_ndtgTrades, 3);
            this.ui_ndtgTrades.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndtgTrades.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndtgTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndtgTrades.EnableCellCustomDraw = false;
            this.ui_ndtgTrades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndtgTrades.Location = new System.Drawing.Point(3, 103);
            this.ui_ndtgTrades.MultiSelect = false;
            this.ui_ndtgTrades.Name = "ui_ndtgTrades";
            this.ui_ndtgTrades.ReadOnly = true;
            this.ui_ndtgTrades.RowHeadersVisible = false;
            this.ui_ndtgTrades.RowHeadersWidth = 20;
            this.ui_ndtgTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndtgTrades.Size = new System.Drawing.Size(925, 290);
            this.ui_ndtgTrades.TabIndex = 12;
            this.ui_ndtgTrades.UseColumnContextMenu = false;
            this.ui_ndtgTrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndtgTrades_CellClick);
            this.ui_ndtgTrades.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndtgTrades_CellMouseEnter);
            this.ui_ndtgTrades.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_ndtgTrades_DataError);
            this.ui_ndtgTrades.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ui_ndtgTrades_RowsAdded);
            this.ui_ndtgTrades.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndtgTrades_MouseDown);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonNewAccount});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(175, 48);
            // 
            // ui_contextmnuCommonNewAccount
            // 
            this.ui_contextmnuCommonNewAccount.Name = "ui_contextmnuCommonNewAccount";
            this.ui_contextmnuCommonNewAccount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ui_contextmnuCommonNewAccount.Size = new System.Drawing.Size(174, 22);
            this.ui_contextmnuCommonNewAccount.Text = "New Order";
            this.ui_contextmnuCommonNewAccount.Click += new System.EventHandler(this.ui_contextmnuCommonNewAccount_Click);
            // 
            // ui_npnlFilter
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ui_npnlFilter, 3);
            this.ui_npnlFilter.Controls.Add(this.tableLayoutPanel2);
            this.ui_npnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlFilter.Location = new System.Drawing.Point(3, 30);
            this.ui_npnlFilter.Name = "ui_npnlFilter";
            this.ui_npnlFilter.Size = new System.Drawing.Size(925, 67);
            this.ui_npnlFilter.TabIndex = 4;
            this.ui_npnlFilter.Text = "nuiPanel2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.16814F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.83186F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbOrderStatus, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblBrokerName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbBrokerName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblAccountID, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbAccountID, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbOrderNo, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblStartDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ui_ndtpStartTime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.ui_lblEndDate, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.ui_ndtpEndDate, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_ncmbTradeNo, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.ui_nbtnSearch, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(923, 65);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ui_ncmbOrderStatus
            // 
            this.ui_ncmbOrderStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbOrderStatus.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("All", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Open", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Settled", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbOrderStatus.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderStatus.Location = new System.Drawing.Point(527, 39);
            this.ui_ncmbOrderStatus.Name = "ui_ncmbOrderStatus";
            this.ui_ncmbOrderStatus.Size = new System.Drawing.Size(146, 18);
            this.ui_ncmbOrderStatus.TabIndex = 31;
            // 
            // ui_lblBrokerName
            // 
            this.ui_lblBrokerName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblBrokerName.AutoSize = true;
            this.ui_lblBrokerName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerName.Location = new System.Drawing.Point(5, 9);
            this.ui_lblBrokerName.Name = "ui_lblBrokerName";
            this.ui_lblBrokerName.Size = new System.Drawing.Size(75, 13);
            this.ui_lblBrokerName.TabIndex = 16;
            this.ui_lblBrokerName.Text = "Broker Name :";
            // 
            // ui_ncmbBrokerName
            // 
            this.ui_ncmbBrokerName.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbBrokerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbBrokerName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerName.Location = new System.Drawing.Point(86, 7);
            this.ui_ncmbBrokerName.Name = "ui_ncmbBrokerName";
            this.ui_ncmbBrokerName.Size = new System.Drawing.Size(134, 18);
            this.ui_ncmbBrokerName.TabIndex = 17;
            this.ui_ncmbBrokerName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerName_SelectedIndexChanged);
            // 
            // ui_lblAccountID
            // 
            this.ui_lblAccountID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblAccountID.AutoSize = true;
            this.ui_lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountID.Location = new System.Drawing.Point(229, 9);
            this.ui_lblAccountID.Name = "ui_lblAccountID";
            this.ui_lblAccountID.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountID.TabIndex = 18;
            this.ui_lblAccountID.Text = "Account ID :";
            // 
            // ui_ncmbAccountID
            // 
            this.ui_ncmbAccountID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbAccountID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountID.Location = new System.Drawing.Point(302, 7);
            this.ui_ncmbAccountID.Name = "ui_ncmbAccountID";
            this.ui_ncmbAccountID.Size = new System.Drawing.Size(146, 18);
            this.ui_ncmbAccountID.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Order No. :";
            // 
            // ui_ncmbOrderNo
            // 
            this.ui_ncmbOrderNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbOrderNo.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderNo.Location = new System.Drawing.Point(527, 7);
            this.ui_ncmbOrderNo.Name = "ui_ncmbOrderNo";
            this.ui_ncmbOrderNo.Size = new System.Drawing.Size(146, 18);
            this.ui_ncmbOrderNo.TabIndex = 23;
            this.ui_ncmbOrderNo.Text = "nComboBox1";
            // 
            // ui_lblStartDate
            // 
            this.ui_lblStartDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblStartDate.AutoSize = true;
            this.ui_lblStartDate.Location = new System.Drawing.Point(19, 42);
            this.ui_lblStartDate.Name = "ui_lblStartDate";
            this.ui_lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblStartDate.TabIndex = 24;
            this.ui_lblStartDate.Text = "Start Date :";
            // 
            // ui_ndtpStartTime
            // 
            this.ui_ndtpStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ndtpStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpStartTime.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpStartTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpStartTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpStartTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpStartTime.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ui_ndtpStartTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ndtpStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpStartTime.Location = new System.Drawing.Point(86, 37);
            this.ui_ndtpStartTime.Name = "ui_ndtpStartTime";
            this.ui_ndtpStartTime.Size = new System.Drawing.Size(134, 22);
            this.ui_ndtpStartTime.TabIndex = 25;
            // 
            // ui_lblEndDate
            // 
            this.ui_lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblEndDate.AutoSize = true;
            this.ui_lblEndDate.Location = new System.Drawing.Point(238, 42);
            this.ui_lblEndDate.Name = "ui_lblEndDate";
            this.ui_lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.ui_lblEndDate.TabIndex = 26;
            this.ui_lblEndDate.Text = "End Date :";
            // 
            // ui_ndtpEndDate
            // 
            this.ui_ndtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ndtpEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpEndDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpEndDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpEndDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpEndDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpEndDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ui_ndtpEndDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ndtpEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpEndDate.Location = new System.Drawing.Point(302, 37);
            this.ui_ndtpEndDate.Name = "ui_ndtpEndDate";
            this.ui_ndtpEndDate.Size = new System.Drawing.Size(146, 22);
            this.ui_ndtpEndDate.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Trade No. :";
            // 
            // ui_ncmbTradeNo
            // 
            this.ui_ncmbTradeNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_ncmbTradeNo.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbTradeNo.Location = new System.Drawing.Point(774, 7);
            this.ui_ncmbTradeNo.Name = "ui_ncmbTradeNo";
            this.ui_ncmbTradeNo.Size = new System.Drawing.Size(146, 18);
            this.ui_ncmbTradeNo.TabIndex = 23;
            this.ui_ncmbTradeNo.Text = "nComboBox1";
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_nbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnSearch.Location = new System.Drawing.Point(842, 37);
            this.ui_nbtnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnSearch.TabIndex = 28;
            this.ui_nbtnSearch.Text = "&Search";
            this.MytoolTip.SetToolTip(this.ui_nbtnSearch, "Search");
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Status :";
            // 
            // ui_nbtnRefresh
            // 
            this.ui_nbtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnRefresh.Image = global::BOADMIN_NEW.Properties.Resources.refresh;
            this.ui_nbtnRefresh.Location = new System.Drawing.Point(883, 3);
            this.ui_nbtnRefresh.Name = "ui_nbtnRefresh";
            this.ui_nbtnRefresh.Size = new System.Drawing.Size(40, 21);
            this.ui_nbtnRefresh.TabIndex = 3;
            this.MytoolTip.SetToolTip(this.ui_nbtnRefresh, "Refresh");
            this.ui_nbtnRefresh.UseVisualStyleBackColor = false;
            this.ui_nbtnRefresh.Click += new System.EventHandler(this.ui_nbtnRefresh_Click);
            // 
            // uctlTradeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlTradeMain";
            this.Size = new System.Drawing.Size(933, 398);
            this.Load += new System.EventHandler(this.uctlTradeMain_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgTrades)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ui_npnlFilter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnHideFilter;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndtgTrades;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnNewTrade;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRefresh;
        private System.Windows.Forms.Label ui_lblBrokerName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerName;
        private System.Windows.Forms.Label ui_lblAccountID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountID;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderNo;
        private System.Windows.Forms.Label ui_lblStartDate;
        private System.Windows.Forms.Label ui_lblEndDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpEndDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbTradeNo;
        private System.Windows.Forms.ToolTip MytoolTip;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpStartTime;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderStatus;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        public System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonNewAccount;
    }
}
