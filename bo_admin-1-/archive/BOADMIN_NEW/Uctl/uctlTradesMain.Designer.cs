namespace BOADMIN_NEW.Uctl
{
    partial class uctlTradesMain
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
            this.ui_npnlTrades = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntpnlTrades = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndtgTrades = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_lblBrokerName = new System.Windows.Forms.Label();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpEndDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblEndDate = new System.Windows.Forms.Label();
            this.ui_ndtpStartTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblStartDate = new System.Windows.Forms.Label();
            this.ui_ncmbBrokerName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAccountID = new System.Windows.Forms.Label();
            this.ui_ncmbAccountID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_ncmbOrderNo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nbtnRefresh = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlTrades.SuspendLayout();
            this.ui_ntpnlTrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgTrades)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlTrades
            // 
            this.ui_npnlTrades.Controls.Add(this.ui_ntpnlTrades);
            this.ui_npnlTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlTrades.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlTrades.Name = "ui_npnlTrades";
            this.ui_npnlTrades.Size = new System.Drawing.Size(1065, 252);
            this.ui_npnlTrades.TabIndex = 2;
            this.ui_npnlTrades.Text = "nuiPanel1";
            // 
            // ui_ntpnlTrades
            // 
            this.ui_ntpnlTrades.BackColor = System.Drawing.Color.Transparent;
            this.ui_ntpnlTrades.ColumnCount = 11;
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.1737F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.26055F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.29777F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01241F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.436724F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.88089F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.188584F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.74938F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtgTrades, 0, 2);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblBrokerName, 0, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_nbtnSearch, 10, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtpEndDate, 9, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblEndDate, 8, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtpStartTime, 7, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblStartDate, 6, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ncmbBrokerName, 1, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblAccountID, 2, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ncmbAccountID, 3, 0);
            this.ui_ntpnlTrades.Controls.Add(this.label1, 4, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ncmbOrderNo, 5, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_nbtnRefresh, 10, 1);
            this.ui_ntpnlTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ntpnlTrades.Location = new System.Drawing.Point(0, 0);
            this.ui_ntpnlTrades.Name = "ui_ntpnlTrades";
            this.ui_ntpnlTrades.RowCount = 3;
            this.ui_ntpnlTrades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ui_ntpnlTrades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ui_ntpnlTrades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_ntpnlTrades.Size = new System.Drawing.Size(1063, 250);
            this.ui_ntpnlTrades.TabIndex = 2;
            // 
            // ui_ndtgTrades
            // 
            this.ui_ndtgTrades.AllowUserToAddRows = false;
            this.ui_ndtgTrades.AllowUserToDeleteRows = false;
            this.ui_ndtgTrades.AllowUserToOrderColumns = true;
            this.ui_ndtgTrades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndtgTrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndtgTrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndtgTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ntpnlTrades.SetColumnSpan(this.ui_ndtgTrades, 11);
            this.ui_ndtgTrades.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
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
            this.ui_ndtgTrades.Location = new System.Drawing.Point(3, 83);
            this.ui_ndtgTrades.MultiSelect = false;
            this.ui_ndtgTrades.Name = "ui_ndtgTrades";
            this.ui_ndtgTrades.ReadOnly = true;
            this.ui_ndtgTrades.RowHeadersVisible = false;
            this.ui_ndtgTrades.RowHeadersWidth = 20;
            this.ui_ndtgTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndtgTrades.Size = new System.Drawing.Size(1057, 164);
            this.ui_ndtgTrades.TabIndex = 11;
            this.ui_ndtgTrades.UseColumnContextMenu = false;
            this.ui_ndtgTrades.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndtgTrades_MouseDown);
            this.ui_ndtgTrades.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_ndtgTrades_CellMouseEnter);
            this.ui_ndtgTrades.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ui_ndtgTrades_DataError);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.ShowImageMargin = false;
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(130, 48);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            this.ui_contextmnuCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ui_contextmnuCommon_Opening);
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Enabled = false;
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(129, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            this.ui_contextmnuCommonEdit.Visible = false;
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Enabled = false;
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(129, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            this.ui_contextmnuCommonDelete.Visible = false;
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
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnSearch.Location = new System.Drawing.Point(1026, 8);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Size = new System.Drawing.Size(31, 23);
            this.ui_nbtnSearch.TabIndex = 4;
            this.ui_nbtnSearch.Text = "&Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
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
            this.ui_ndtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpEndDate.Location = new System.Drawing.Point(977, 9);
            this.ui_ndtpEndDate.Name = "ui_ndtpEndDate";
            this.ui_ndtpEndDate.Size = new System.Drawing.Size(41, 22);
            this.ui_ndtpEndDate.TabIndex = 3;
            // 
            // ui_lblEndDate
            // 
            this.ui_lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblEndDate.AutoSize = true;
            this.ui_lblEndDate.Location = new System.Drawing.Point(913, 13);
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
            this.ui_ndtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpStartTime.Location = new System.Drawing.Point(750, 9);
            this.ui_ndtpStartTime.Name = "ui_ndtpStartTime";
            this.ui_ndtpStartTime.Size = new System.Drawing.Size(124, 22);
            this.ui_ndtpStartTime.TabIndex = 2;
            // 
            // ui_lblStartDate
            // 
            this.ui_lblStartDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblStartDate.AutoSize = true;
            this.ui_lblStartDate.Location = new System.Drawing.Point(683, 13);
            this.ui_lblStartDate.Name = "ui_lblStartDate";
            this.ui_lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblStartDate.TabIndex = 18;
            this.ui_lblStartDate.Text = "Start Date :";
            // 
            // ui_ncmbBrokerName
            // 
            this.ui_ncmbBrokerName.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbBrokerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbBrokerName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerName.Location = new System.Drawing.Point(94, 11);
            this.ui_ncmbBrokerName.Name = "ui_ncmbBrokerName";
            this.ui_ncmbBrokerName.Size = new System.Drawing.Size(113, 18);
            this.ui_ncmbBrokerName.TabIndex = 0;
            this.ui_ncmbBrokerName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbBrokerName_SelectedIndexChanged_1);
            // 
            // ui_lblAccountID
            // 
            this.ui_lblAccountID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblAccountID.AutoSize = true;
            this.ui_lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountID.Location = new System.Drawing.Point(250, 13);
            this.ui_lblAccountID.Name = "ui_lblAccountID";
            this.ui_lblAccountID.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountID.TabIndex = 14;
            this.ui_lblAccountID.Text = "Account ID :";
            // 
            // ui_ncmbAccountID
            // 
            this.ui_ncmbAccountID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbAccountID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountID.Location = new System.Drawing.Point(323, 11);
            this.ui_ncmbAccountID.Name = "ui_ncmbAccountID";
            this.ui_ncmbAccountID.Size = new System.Drawing.Size(113, 18);
            this.ui_ncmbAccountID.TabIndex = 1;
            this.ui_ncmbAccountID.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbaccountID_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Order No. :";
            // 
            // ui_ncmbOrderNo
            // 
            this.ui_ncmbOrderNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbOrderNo.Location = new System.Drawing.Point(534, 9);
            this.ui_ncmbOrderNo.Name = "ui_ncmbOrderNo";
            this.ui_ncmbOrderNo.Size = new System.Drawing.Size(113, 22);
            this.ui_ncmbOrderNo.TabIndex = 22;
            this.ui_ncmbOrderNo.Text = "nComboBox1";
            // 
            // ui_nbtnRefresh
            // 
            this.ui_nbtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_nbtnRefresh.Location = new System.Drawing.Point(1024, 48);
            this.ui_nbtnRefresh.Name = "ui_nbtnRefresh";
            this.ui_nbtnRefresh.Size = new System.Drawing.Size(36, 23);
            this.ui_nbtnRefresh.TabIndex = 20;
            this.ui_nbtnRefresh.Text = "&Refresh";
            this.ui_nbtnRefresh.UseVisualStyleBackColor = false;
            this.ui_nbtnRefresh.Click += new System.EventHandler(this.ui_nbtnRefresh_Click);
            // 
            // uctlTradesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlTrades);
            this.Name = "uctlTradesMain";
            this.Size = new System.Drawing.Size(1065, 252);
            this.Load += new System.EventHandler(this.uctlTradesMain_Load);
            this.ui_npnlTrades.ResumeLayout(false);
            this.ui_ntpnlTrades.ResumeLayout(false);
            this.ui_ntpnlTrades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgTrades)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlTrades;
        private System.Windows.Forms.TableLayoutPanel ui_ntpnlTrades;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndtgTrades;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountID;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerName;
        private System.Windows.Forms.Label ui_lblAccountID;
        private System.Windows.Forms.Label ui_lblBrokerName;
        private System.Windows.Forms.Label ui_lblStartDate;
        private System.Windows.Forms.Label ui_lblEndDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpStartTime;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpEndDate;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRefresh;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderNo;
    }
}
