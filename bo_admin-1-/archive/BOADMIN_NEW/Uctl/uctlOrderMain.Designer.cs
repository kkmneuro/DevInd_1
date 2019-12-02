namespace BOADMIN_NEW.Uctl
{
    partial class uctlOrderMain
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
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Swap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_npnlOrders = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntpnlOrders = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndtgOrders = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_ncmbaccountID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbBrokerName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAccountID = new System.Windows.Forms.Label();
            this.ui_lblBrokerName = new System.Windows.Forms.Label();
            this.ui_lblStartDate = new System.Windows.Forms.Label();
            this.ui_lblEndDate = new System.Windows.Forms.Label();
            this.ui_ndtpStartTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpEndDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_nbrnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnRefresh = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_contextmnuCommon.SuspendLayout();
            this.ui_npnlOrders.SuspendLayout();
            this.ui_ntpnlOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.ShowImageMargin = false;
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(124, 48);   ;
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Enabled = false;
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(123, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            this.ui_contextmnuCommonEdit.Visible = false;
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Enabled = false;
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(123, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            this.ui_contextmnuCommonDelete.Visible = false;
            // 
            // Deal
            // 
            this.Deal.HeaderText = "Deal";
            this.Deal.Name = "Deal";
            this.Deal.ReadOnly = true;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Time";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Lots
            // 
            this.Lots.HeaderText = "Lots";
            this.Lots.Name = "Lots";
            this.Lots.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Sl
            // 
            this.Sl.HeaderText = "S/L";
            this.Sl.Name = "Sl";
            this.Sl.ReadOnly = true;
            // 
            // TP
            // 
            this.TP.HeaderText = "T/P";
            this.TP.Name = "TP";
            this.TP.ReadOnly = true;
            // 
            // Swap
            // 
            this.Swap.HeaderText = "Swap";
            this.Swap.Name = "Swap";
            this.Swap.ReadOnly = true;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            // 
            // ui_npnlOrders
            // 
            this.ui_npnlOrders.Controls.Add(this.ui_ntpnlOrders);
            this.ui_npnlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlOrders.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlOrders.Name = "ui_npnlOrders";
            this.ui_npnlOrders.Size = new System.Drawing.Size(1005, 252);
            this.ui_npnlOrders.TabIndex = 1;
            this.ui_npnlOrders.Text = "nuiPanel1";
            // 
            // ui_ntpnlOrders
            // 
            this.ui_ntpnlOrders.AutoScroll = true;
            this.ui_ntpnlOrders.AutoSize = true;
            this.ui_ntpnlOrders.BackColor = System.Drawing.Color.Transparent;
            this.ui_ntpnlOrders.ColumnCount = 10;
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.4534F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.73552F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.3199F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.49118F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.690176F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.45078F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.419689F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.32124F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.ui_ntpnlOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.ui_ntpnlOrders.Controls.Add(this.ui_ndtgOrders, 0, 1);
            this.ui_ntpnlOrders.Controls.Add(this.ui_ncmbaccountID, 3, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_ncmbBrokerName, 1, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_lblAccountID, 2, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_lblBrokerName, 0, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_lblStartDate, 4, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_lblEndDate, 6, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_ndtpStartTime, 5, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_ndtpEndDate, 7, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_nbrnSearch, 8, 0);
            this.ui_ntpnlOrders.Controls.Add(this.ui_nbtnRefresh, 9, 0);
            this.ui_ntpnlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ntpnlOrders.Location = new System.Drawing.Point(0, 0);
            this.ui_ntpnlOrders.Name = "ui_ntpnlOrders";
            this.ui_ntpnlOrders.RowCount = 2;
            this.ui_ntpnlOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ui_ntpnlOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_ntpnlOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_ntpnlOrders.Size = new System.Drawing.Size(1003, 250);
            this.ui_ntpnlOrders.TabIndex = 2;
            // 
            // ui_ndtgOrders
            // 
            this.ui_ndtgOrders.AllowUserToAddRows = false;
            this.ui_ndtgOrders.AllowUserToDeleteRows = false;
            this.ui_ndtgOrders.AllowUserToOrderColumns = true;
            this.ui_ndtgOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndtgOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndtgOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndtgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ntpnlOrders.SetColumnSpan(this.ui_ndtgOrders, 10);
            this.ui_ndtgOrders.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndtgOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndtgOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndtgOrders.EnableCellCustomDraw = false;
            this.ui_ndtgOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndtgOrders.Location = new System.Drawing.Point(3, 43);
            this.ui_ndtgOrders.MultiSelect = false;
            this.ui_ndtgOrders.Name = "ui_ndtgOrders";
            this.ui_ndtgOrders.ReadOnly = true;
            this.ui_ndtgOrders.RowHeadersVisible = false;
            this.ui_ndtgOrders.RowHeadersWidth = 20;
            this.ui_ndtgOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndtgOrders.Size = new System.Drawing.Size(997, 204);
            this.ui_ndtgOrders.TabIndex = 11;
            this.ui_ndtgOrders.UseColumnContextMenu = false;
            this.ui_ndtgOrders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndtgOrders_MouseDown);
            this.ui_ndtgOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndtgOrders_CellDoubleClick);
            this.ui_ndtgOrders.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndtgOrders_CellMouseEnter);
            this.ui_ndtgOrders.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_ndtgOrders_DataError);
            // 
            // ui_ncmbaccountID
            // 
            this.ui_ncmbaccountID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbaccountID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbaccountID.Location = new System.Drawing.Point(286, 11);
            this.ui_ncmbaccountID.Name = "ui_ncmbaccountID";
            this.ui_ncmbaccountID.Size = new System.Drawing.Size(115, 18);
            this.ui_ncmbaccountID.TabIndex = 1;
            this.ui_ncmbaccountID.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbaccountID_SelectedIndexChanged);
            // 
            // ui_ncmbBrokerName
            // 
            this.ui_ncmbBrokerName.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbBrokerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbBrokerName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerName.Location = new System.Drawing.Point(89, 11);
            this.ui_ncmbBrokerName.Name = "ui_ncmbBrokerName";
            this.ui_ncmbBrokerName.Size = new System.Drawing.Size(109, 18);
            this.ui_ncmbBrokerName.TabIndex = 0;
            this.ui_ncmbBrokerName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerName_SelectedIndexChanged);
            // 
            // ui_lblAccountID
            // 
            this.ui_lblAccountID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblAccountID.AutoSize = true;
            this.ui_lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountID.Location = new System.Drawing.Point(210, 13);
            this.ui_lblAccountID.Name = "ui_lblAccountID";
            this.ui_lblAccountID.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountID.TabIndex = 14;
            this.ui_lblAccountID.Text = "Account ID :";
            // 
            // ui_lblBrokerName
            // 
            this.ui_lblBrokerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblBrokerName.AutoSize = true;
            this.ui_lblBrokerName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerName.Location = new System.Drawing.Point(3, 13);
            this.ui_lblBrokerName.Name = "ui_lblBrokerName";
            this.ui_lblBrokerName.Size = new System.Drawing.Size(75, 13);
            this.ui_lblBrokerName.TabIndex = 15;
            this.ui_lblBrokerName.Text = "Broker Name :";
            // 
            // ui_lblStartDate
            // 
            this.ui_lblStartDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblStartDate.AutoSize = true;
            this.ui_lblStartDate.Location = new System.Drawing.Point(417, 13);
            this.ui_lblStartDate.Name = "ui_lblStartDate";
            this.ui_lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblStartDate.TabIndex = 18;
            this.ui_lblStartDate.Text = "Start Date :";
            // 
            // ui_lblEndDate
            // 
            this.ui_lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblEndDate.AutoSize = true;
            this.ui_lblEndDate.Location = new System.Drawing.Point(624, 13);
            this.ui_lblEndDate.Name = "ui_lblEndDate";
            this.ui_lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.ui_lblEndDate.TabIndex = 19;
            this.ui_lblEndDate.Text = "End Date :";
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
            this.ui_ndtpStartTime.Location = new System.Drawing.Point(484, 9);
            this.ui_ndtpStartTime.Name = "ui_ndtpStartTime";
            this.ui_ndtpStartTime.Size = new System.Drawing.Size(129, 22);
            this.ui_ndtpStartTime.TabIndex = 2;
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
            this.ui_ndtpEndDate.Location = new System.Drawing.Point(688, 9);
            this.ui_ndtpEndDate.Name = "ui_ndtpEndDate";
            this.ui_ndtpEndDate.Size = new System.Drawing.Size(128, 22);
            this.ui_ndtpEndDate.TabIndex = 3;
            // 
            // ui_nbrnSearch
            // 
            this.ui_nbrnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbrnSearch.Location = new System.Drawing.Point(822, 8);
            this.ui_nbrnSearch.Name = "ui_nbrnSearch";
            this.ui_nbrnSearch.Size = new System.Drawing.Size(73, 23);
            this.ui_nbrnSearch.TabIndex = 4;
            this.ui_nbrnSearch.Text = "&Search";
            this.ui_nbrnSearch.UseVisualStyleBackColor = false;
            this.ui_nbrnSearch.Click += new System.EventHandler(this.ui_nbrnSearch_Click);
            // 
            // ui_nbtnRefresh
            // 
            this.ui_nbtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnRefresh.Location = new System.Drawing.Point(913, 8);
            this.ui_nbtnRefresh.Name = "ui_nbtnRefresh";
            this.ui_nbtnRefresh.Size = new System.Drawing.Size(74, 23);
            this.ui_nbtnRefresh.TabIndex = 20;
            this.ui_nbtnRefresh.Text = "&Refresh";
            this.ui_nbtnRefresh.UseVisualStyleBackColor = false;
            this.ui_nbtnRefresh.Click += new System.EventHandler(this.ui_nbtnRefresh_Click);
            // 
            // uctlOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlOrders);
            this.Name = "uctlOrderMain";
            this.Size = new System.Drawing.Size(1005, 252);
            this.Load += new System.EventHandler(this.uctlOrderMain_Load);
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ui_npnlOrders.ResumeLayout(false);
            this.ui_npnlOrders.PerformLayout();
            this.ui_ntpnlOrders.ResumeLayout(false);
            this.ui_ntpnlOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Deal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lots;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn TP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Swap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlOrders;
        private System.Windows.Forms.TableLayoutPanel ui_ntpnlOrders;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbaccountID;
        private System.Windows.Forms.Label ui_lblBrokerName;
        private System.Windows.Forms.Label ui_lblAccountID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerName;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndtgOrders;
        private System.Windows.Forms.Label ui_lblStartDate;
        private System.Windows.Forms.Label ui_lblEndDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpStartTime;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpEndDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbrnSearch;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRefresh;
    }
}
