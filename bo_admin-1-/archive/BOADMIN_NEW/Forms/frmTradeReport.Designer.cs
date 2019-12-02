namespace BOADMIN_NEW.Forms
{
    partial class frmTradeReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.objTradeReport = new Reports.crTrades();
            this.ui_tlpTradeReport = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerID = new System.Windows.Forms.Label();
            this.ui_lblToDate = new System.Windows.Forms.Label();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ncmbOrderType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbSide = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblFromDate = new System.Windows.Forms.Label();
            this.ui_lblSide = new System.Windows.Forms.Label();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_nbtnSearch1 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtAccountNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblOrderType = new System.Windows.Forms.Label();
            this.ui_lblAccountNumber = new System.Windows.Forms.Label();
            this.ui_npnlSearch2 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtTradeNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_nbtnSearch2 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtOrderNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblTradeNumber = new System.Windows.Forms.Label();
            this.ui_lblOrderNumber = new System.Windows.Forms.Label();
            this.ui_trRvTrade = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ui_tlpTradeReport.SuspendLayout();
            this.ui_ngbSearch.SuspendLayout();
            this.ui_npnlSearch1.SuspendLayout();
            this.ui_npnlSearch2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tlpTradeReport
            // 
            this.ui_tlpTradeReport.ColumnCount = 2;
            this.ui_tlpTradeReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tlpTradeReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tlpTradeReport.Controls.Add(this.ui_ngbSearch, 0, 0);
            this.ui_tlpTradeReport.Controls.Add(this.ui_trRvTrade, 0, 1);
            this.ui_tlpTradeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpTradeReport.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpTradeReport.Name = "ui_tlpTradeReport";
            this.ui_tlpTradeReport.RowCount = 2;
            this.ui_tlpTradeReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpTradeReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpTradeReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpTradeReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpTradeReport.Size = new System.Drawing.Size(1212, 602);
            this.ui_tlpTradeReport.TabIndex = 3;
            // 
            // ui_ngbSearch
            // 
            this.ui_tlpTradeReport.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch2);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(1206, 80);
            this.ui_ngbSearch.TabIndex = 3;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ncmbOrderType);
            this.ui_npnlSearch1.Controls.Add(this.ui_ncmbSide);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblFromDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSide);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpFromDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch1);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblOrderType);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblAccountNumber);
            this.ui_npnlSearch1.Location = new System.Drawing.Point(6, 14);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(707, 60);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(234, 34);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(94, 18);
            this.ui_ntxtSymbol.TabIndex = 30;
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(182, 37);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 29;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(82, 34);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(84, 18);
            this.ui_ntxtBrokerID.TabIndex = 28;
            // 
            // ui_lblBrokerID
            // 
            this.ui_lblBrokerID.AutoSize = true;
            this.ui_lblBrokerID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerID.Location = new System.Drawing.Point(18, 37);
            this.ui_lblBrokerID.Name = "ui_lblBrokerID";
            this.ui_lblBrokerID.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerID.TabIndex = 27;
            this.ui_lblBrokerID.Text = "Broker ID :";
            // 
            // ui_lblToDate
            // 
            this.ui_lblToDate.AutoSize = true;
            this.ui_lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblToDate.Location = new System.Drawing.Point(177, 9);
            this.ui_lblToDate.Name = "ui_lblToDate";
            this.ui_lblToDate.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToDate.TabIndex = 26;
            this.ui_lblToDate.Text = "To Date :";
            // 
            // ui_ndtpToDate
            // 
            this.ui_ndtpToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpToDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpToDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpToDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpToDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpToDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpToDate.Location = new System.Drawing.Point(234, 5);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpToDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpToDate.TabIndex = 25;
            // 
            // ui_ncmbOrderType
            // 
            this.ui_ncmbOrderType.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbOrderType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderType.Location = new System.Drawing.Point(411, 34);
            this.ui_ncmbOrderType.Name = "ui_ncmbOrderType";
            this.ui_ncmbOrderType.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ncmbOrderType.Size = new System.Drawing.Size(105, 18);
            this.ui_ncmbOrderType.TabIndex = 18;
            this.ui_ncmbOrderType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbOrderType_SelectedIndexChanged);
            // 
            // ui_ncmbSide
            // 
            this.ui_ncmbSide.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbSide.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSide.Location = new System.Drawing.Point(411, 6);
            this.ui_ncmbSide.Name = "ui_ncmbSide";
            this.ui_ncmbSide.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ncmbSide.Size = new System.Drawing.Size(105, 18);
            this.ui_ncmbSide.TabIndex = 17;
            this.ui_ncmbSide.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbSide_SelectedIndexChanged);
            // 
            // ui_lblFromDate
            // 
            this.ui_lblFromDate.AutoSize = true;
            this.ui_lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFromDate.Location = new System.Drawing.Point(14, 9);
            this.ui_lblFromDate.Name = "ui_lblFromDate";
            this.ui_lblFromDate.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromDate.TabIndex = 3;
            this.ui_lblFromDate.Text = "From Date :";
            // 
            // ui_lblSide
            // 
            this.ui_lblSide.AutoSize = true;
            this.ui_lblSide.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSide.Location = new System.Drawing.Point(374, 9);
            this.ui_lblSide.Name = "ui_lblSide";
            this.ui_lblSide.Size = new System.Drawing.Size(34, 13);
            this.ui_lblSide.TabIndex = 4;
            this.ui_lblSide.Text = "Side :";
            // 
            // ui_ndtpFromDate
            // 
            this.ui_ndtpFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpFromDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpFromDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpFromDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(82, 5);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(84, 21);
            this.ui_ndtpFromDate.TabIndex = 2;
            this.ui_ndtpFromDate.ValueChanged += new System.EventHandler(this.ui_ndtpDate_ValueChanged);
            // 
            // ui_nbtnSearch1
            // 
            this.ui_nbtnSearch1.Location = new System.Drawing.Point(620, 28);
            this.ui_nbtnSearch1.Name = "ui_nbtnSearch1";
            this.ui_nbtnSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch1.Size = new System.Drawing.Size(75, 27);
            this.ui_nbtnSearch1.TabIndex = 16;
            this.ui_nbtnSearch1.Text = "Search";
            this.ui_nbtnSearch1.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch1.Click += new System.EventHandler(this.ui_nbtnSearch1_Click);
            // 
            // ui_ntxtAccountNumber
            // 
            this.ui_ntxtAccountNumber.Location = new System.Drawing.Point(620, 6);
            this.ui_ntxtAccountNumber.Name = "ui_ntxtAccountNumber";
            this.ui_ntxtAccountNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountNumber.Size = new System.Drawing.Size(75, 18);
            this.ui_ntxtAccountNumber.TabIndex = 10;
            this.ui_ntxtAccountNumber.Leave += new System.EventHandler(this.ui_ntxtAccountNumber_Leave);
            // 
            // ui_lblOrderType
            // 
            this.ui_lblOrderType.AutoSize = true;
            this.ui_lblOrderType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderType.Location = new System.Drawing.Point(342, 37);
            this.ui_lblOrderType.Name = "ui_lblOrderType";
            this.ui_lblOrderType.Size = new System.Drawing.Size(66, 13);
            this.ui_lblOrderType.TabIndex = 6;
            this.ui_lblOrderType.Text = "Order Type :";
            // 
            // ui_lblAccountNumber
            // 
            this.ui_lblAccountNumber.AutoSize = true;
            this.ui_lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountNumber.Location = new System.Drawing.Point(523, 9);
            this.ui_lblAccountNumber.Name = "ui_lblAccountNumber";
            this.ui_lblAccountNumber.Size = new System.Drawing.Size(93, 13);
            this.ui_lblAccountNumber.TabIndex = 5;
            this.ui_lblAccountNumber.Text = "Account Number :";
            // 
            // ui_npnlSearch2
            // 
            this.ui_npnlSearch2.Controls.Add(this.ui_ntxtTradeNumber);
            this.ui_npnlSearch2.Controls.Add(this.ui_nbtnSearch2);
            this.ui_npnlSearch2.Controls.Add(this.ui_ntxtOrderNumber);
            this.ui_npnlSearch2.Controls.Add(this.ui_lblTradeNumber);
            this.ui_npnlSearch2.Controls.Add(this.ui_lblOrderNumber);
            this.ui_npnlSearch2.Location = new System.Drawing.Point(721, 14);
            this.ui_npnlSearch2.Name = "ui_npnlSearch2";
            this.ui_npnlSearch2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch2.Size = new System.Drawing.Size(262, 60);
            this.ui_npnlSearch2.TabIndex = 16;
            this.ui_npnlSearch2.Text = "nuiPanel1";
            // 
            // ui_ntxtTradeNumber
            // 
            this.ui_ntxtTradeNumber.Location = new System.Drawing.Point(84, 34);
            this.ui_ntxtTradeNumber.Name = "ui_ntxtTradeNumber";
            this.ui_ntxtTradeNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtTradeNumber.Size = new System.Drawing.Size(95, 18);
            this.ui_ntxtTradeNumber.TabIndex = 13;
            this.ui_ntxtTradeNumber.Leave += new System.EventHandler(this.ui_ntxtTradeNumber_Leave);
            // 
            // ui_nbtnSearch2
            // 
            this.ui_nbtnSearch2.Location = new System.Drawing.Point(185, 6);
            this.ui_nbtnSearch2.Name = "ui_nbtnSearch2";
            this.ui_nbtnSearch2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch2.Size = new System.Drawing.Size(65, 46);
            this.ui_nbtnSearch2.TabIndex = 14;
            this.ui_nbtnSearch2.Text = "Search";
            this.ui_nbtnSearch2.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch2.Click += new System.EventHandler(this.ui_nbtnSearch2_Click);
            // 
            // ui_ntxtOrderNumber
            // 
            this.ui_ntxtOrderNumber.Location = new System.Drawing.Point(84, 6);
            this.ui_ntxtOrderNumber.Name = "ui_ntxtOrderNumber";
            this.ui_ntxtOrderNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtOrderNumber.Size = new System.Drawing.Size(95, 18);
            this.ui_ntxtOrderNumber.TabIndex = 12;
            // 
            // ui_lblTradeNumber
            // 
            this.ui_lblTradeNumber.AutoSize = true;
            this.ui_lblTradeNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTradeNumber.Location = new System.Drawing.Point(5, 37);
            this.ui_lblTradeNumber.Name = "ui_lblTradeNumber";
            this.ui_lblTradeNumber.Size = new System.Drawing.Size(81, 13);
            this.ui_lblTradeNumber.TabIndex = 8;
            this.ui_lblTradeNumber.Text = "Trade Number :";
            // 
            // ui_lblOrderNumber
            // 
            this.ui_lblOrderNumber.AutoSize = true;
            this.ui_lblOrderNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderNumber.Location = new System.Drawing.Point(5, 9);
            this.ui_lblOrderNumber.Name = "ui_lblOrderNumber";
            this.ui_lblOrderNumber.Size = new System.Drawing.Size(79, 13);
            this.ui_lblOrderNumber.TabIndex = 7;
            this.ui_lblOrderNumber.Text = "Order Number :";
            // 
            // ui_trRvTrade
            // 
            this.ui_trRvTrade.ActiveViewIndex = -1;
            this.ui_trRvTrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_tlpTradeReport.SetColumnSpan(this.ui_trRvTrade, 2);
            this.ui_trRvTrade.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_trRvTrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_trRvTrade.Location = new System.Drawing.Point(3, 89);
            this.ui_trRvTrade.Name = "ui_trRvTrade";
            //this.ui_trRvTrade.ShowExportButton = false;
            this.ui_trRvTrade.ShowGroupTreeButton = false;
            this.ui_trRvTrade.ShowLogo = false;
            this.ui_trRvTrade.ShowParameterPanelButton = false;
            this.ui_trRvTrade.Size = new System.Drawing.Size(1206, 510);
            this.ui_trRvTrade.TabIndex = 4;
            this.ui_trRvTrade.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_trRvTrade.ReportSource = this.objTradeReport;
            // 
            // frmTradeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1212, 602);
            this.Controls.Add(this.ui_tlpTradeReport);
            this.MaximumSize = new System.Drawing.Size(1502, 788);
            this.MinimumSize = new System.Drawing.Size(1022, 488);
            this.Name = "frmTradeReport";
            this.Text = "Trade Report";
            this.Load += new System.EventHandler(this.frmTradeReport_Load);
            this.ui_tlpTradeReport.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ui_npnlSearch2.ResumeLayout(false);
            this.ui_npnlSearch2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel ui_tlpTradeReport;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private System.Windows.Forms.Label ui_lblSymbol;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerID;
        private System.Windows.Forms.Label ui_lblToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSide;
        private System.Windows.Forms.Label ui_lblFromDate;
        private System.Windows.Forms.Label ui_lblSide;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountNumber;
        private System.Windows.Forms.Label ui_lblOrderType;
        private System.Windows.Forms.Label ui_lblAccountNumber;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch2;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtTradeNumber;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch2;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOrderNumber;
        private System.Windows.Forms.Label ui_lblTradeNumber;
        private System.Windows.Forms.Label ui_lblOrderNumber;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_trRvTrade;
        private Reports.crTrades objTradeReport;
    }
}