namespace BOADMIN_NEW.Uctl
{
    partial class uctlOperationsLog
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntpnlTrades = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ndtgOperationLog = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_nbtnRefresh = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblToDate = new System.Windows.Forms.Label();
            this.ui_lblFromDate = new System.Windows.Forms.Label();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ncmbBrokerID = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblBrokerID = new System.Windows.Forms.Label();
            this.ui_npnlControlContainer.SuspendLayout();
            this.ui_ntpnlTrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgOperationLog)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntpnlTrades);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(804, 286);
            this.ui_npnlControlContainer.TabIndex = 1;
            // 
            // ui_ntpnlTrades
            // 
            this.ui_ntpnlTrades.BackColor = System.Drawing.Color.Transparent;
            this.ui_ntpnlTrades.ColumnCount = 11;
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.35635F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03047F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.686301F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.69849F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.48502F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47589F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.498045F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.76945F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.ui_ntpnlTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtgOperationLog, 0, 1);
            this.ui_ntpnlTrades.Controls.Add(this.ui_nbtnRefresh, 10, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtpFromDate, 1, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ndtpToDate, 3, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblToDate, 2, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblFromDate, 0, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_nbtnSearch, 8, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_ncmbBrokerID, 5, 0);
            this.ui_ntpnlTrades.Controls.Add(this.ui_lblBrokerID, 4, 0);
            this.ui_ntpnlTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ntpnlTrades.Location = new System.Drawing.Point(0, 0);
            this.ui_ntpnlTrades.Name = "ui_ntpnlTrades";
            this.ui_ntpnlTrades.RowCount = 2;
            this.ui_ntpnlTrades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ui_ntpnlTrades.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_ntpnlTrades.Size = new System.Drawing.Size(802, 284);
            this.ui_ntpnlTrades.TabIndex = 3;
            // 
            // ui_ndtgOperationLog
            // 
            this.ui_ndtgOperationLog.AllowUserToAddRows = false;
            this.ui_ndtgOperationLog.AllowUserToDeleteRows = false;
            this.ui_ndtgOperationLog.AllowUserToOrderColumns = true;
            this.ui_ndtgOperationLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_ndtgOperationLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_ndtgOperationLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ndtgOperationLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndtgOperationLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.ui_ndtgOperationLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndtgOperationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_ntpnlTrades.SetColumnSpan(this.ui_ndtgOperationLog, 11);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_ndtgOperationLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_ndtgOperationLog.DisplayChildRelations = false;
            this.ui_ndtgOperationLog.EnableCellCustomDraw = false;
            this.ui_ndtgOperationLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndtgOperationLog.Location = new System.Drawing.Point(3, 33);
            this.ui_ndtgOperationLog.MultiSelect = false;
            this.ui_ndtgOperationLog.Name = "ui_ndtgOperationLog";
            this.ui_ndtgOperationLog.ReadOnly = true;
            this.ui_ndtgOperationLog.RowHeadersVisible = false;
            this.ui_ndtgOperationLog.RowHeadersWidth = 20;
            this.ui_ndtgOperationLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndtgOperationLog.ShowCellErrors = false;
            this.ui_ndtgOperationLog.ShowRowErrors = false;
            this.ui_ndtgOperationLog.Size = new System.Drawing.Size(796, 248);
            this.ui_ndtgOperationLog.TabIndex = 11;
            this.ui_ndtgOperationLog.UseColumnContextMenu = false;
            // 
            // ui_nbtnRefresh
            // 
            this.ui_nbtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnRefresh.Location = new System.Drawing.Point(687, 3);
            this.ui_nbtnRefresh.Name = "ui_nbtnRefresh";
            this.ui_nbtnRefresh.Size = new System.Drawing.Size(112, 24);
            this.ui_nbtnRefresh.TabIndex = 20;
            this.ui_nbtnRefresh.Text = "&Refresh";
            this.ui_nbtnRefresh.UseVisualStyleBackColor = false;
            this.ui_nbtnRefresh.Click += new System.EventHandler(this.ui_nbtnRefresh_Click);
            // 
            // ui_ndtpFromDate
            // 
            this.ui_ndtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ndtpFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpFromDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpFromDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpFromDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpFromDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(71, 4);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(82, 21);
            this.ui_ndtpFromDate.TabIndex = 22;
            // 
            // ui_ndtpToDate
            // 
            this.ui_ndtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ndtpToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpToDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpToDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpToDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpToDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpToDate.Location = new System.Drawing.Point(219, 4);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Size = new System.Drawing.Size(86, 21);
            this.ui_ndtpToDate.TabIndex = 23;            
            // 
            // ui_lblToDate
            // 
            this.ui_lblToDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblToDate.AutoSize = true;
            this.ui_lblToDate.Location = new System.Drawing.Point(161, 8);
            this.ui_lblToDate.Name = "ui_lblToDate";
            this.ui_lblToDate.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToDate.TabIndex = 24;
            this.ui_lblToDate.Text = "To Date :";
            // 
            // ui_lblFromDate
            // 
            this.ui_lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_lblFromDate.AutoSize = true;
            this.ui_lblFromDate.Location = new System.Drawing.Point(3, 8);
            this.ui_lblFromDate.Name = "ui_lblFromDate";
            this.ui_lblFromDate.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromDate.TabIndex = 25;
            this.ui_lblFromDate.Text = "From Date :";
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch.Location = new System.Drawing.Point(599, 3);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Size = new System.Drawing.Size(74, 24);
            this.ui_nbtnSearch.TabIndex = 21;
            this.ui_nbtnSearch.Text = "Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_ncmbBrokerID
            // 
            this.ui_ncmbBrokerID.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbBrokerID.Location = new System.Drawing.Point(381, 3);
            this.ui_ncmbBrokerID.Name = "ui_ncmbBrokerID";
            this.ui_ncmbBrokerID.Size = new System.Drawing.Size(103, 22);
            this.ui_ncmbBrokerID.TabIndex = 26;
            // 
            // ui_lblBrokerID
            // 
            this.ui_lblBrokerID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_lblBrokerID.AutoSize = true;
            this.ui_lblBrokerID.Location = new System.Drawing.Point(313, 8);
            this.ui_lblBrokerID.Name = "ui_lblBrokerID";
            this.ui_lblBrokerID.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerID.TabIndex = 27;
            this.ui_lblBrokerID.Text = "Broker ID :";
            // 
            // uctlOperationsLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlOperationsLog";
            this.Size = new System.Drawing.Size(804, 286);
            this.Load += new System.EventHandler(this.uctlOperationsLog_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_ntpnlTrades.ResumeLayout(false);
            this.ui_ntpnlTrades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndtgOperationLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.TableLayoutPanel ui_ntpnlTrades;
        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndtgOperationLog;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRefresh;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private System.Windows.Forms.Label ui_lblToDate;
        private System.Windows.Forms.Label ui_lblFromDate;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerID;
        public Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        public Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
    }
}
