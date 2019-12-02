namespace BOADMIN_NEW.Forms
{
    partial class frmDayClosingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayClosingReport));
            objDayClosingReport = new Reports.crDayClosing();
            this.ui_tblPStockLevel = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerId = new System.Windows.Forms.Label();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_lblDate = new System.Windows.Forms.Label();
            this.ui_ndtpDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtAccountID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_rptvDayClosing = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ui_tblPStockLevel.SuspendLayout();
            this.ui_ngbSearch.SuspendLayout();
            this.ui_npnlSearch1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tblPStockLevel
            // 
            this.ui_tblPStockLevel.ColumnCount = 2;
            this.ui_tblPStockLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPStockLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPStockLevel.Controls.Add(this.ui_ngbSearch, 0, 0);
            this.ui_tblPStockLevel.Controls.Add(this.ui_rptvDayClosing, 0, 1);
            this.ui_tblPStockLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tblPStockLevel.Location = new System.Drawing.Point(0, 0);
            this.ui_tblPStockLevel.Name = "ui_tblPStockLevel";
            this.ui_tblPStockLevel.RowCount = 2;
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.Size = new System.Drawing.Size(935, 386);
            this.ui_tblPStockLevel.TabIndex = 3;
            // 
            // ui_ngbSearch
            // 
            this.ui_tblPStockLevel.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(929, 45);
            this.ui_ngbSearch.TabIndex = 5;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerId);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountID);
            this.ui_npnlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSearch1.Location = new System.Drawing.Point(3, 16);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(923, 26);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(387, 3);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(92, 18);
            this.ui_ntxtBrokerID.TabIndex = 32;
            this.ui_ntxtBrokerID.TextChanged += new System.EventHandler(this.ui_ntxtBrokerID_TextChanged);
            // 
            // ui_lblBrokerId
            // 
            this.ui_lblBrokerId.AutoSize = true;
            this.ui_lblBrokerId.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerId.Location = new System.Drawing.Point(322, 6);
            this.ui_lblBrokerId.Name = "ui_lblBrokerId";
            this.ui_lblBrokerId.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerId.TabIndex = 31;
            this.ui_lblBrokerId.Text = "Broker ID :";
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(206, 3);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtSymbol.TabIndex = 18;
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(154, 6);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 17;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_lblDate
            // 
            this.ui_lblDate.AutoSize = true;
            this.ui_lblDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDate.Location = new System.Drawing.Point(3, 6);
            this.ui_lblDate.Name = "ui_lblDate";
            this.ui_lblDate.Size = new System.Drawing.Size(36, 13);
            this.ui_lblDate.TabIndex = 3;
            this.ui_lblDate.Text = "Date :";
            // 
            // ui_ndtpDate
            // 
            this.ui_ndtpDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpDate.Location = new System.Drawing.Point(45, 2);
            this.ui_ndtpDate.Name = "ui_ndtpDate";
            this.ui_ndtpDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpDate.TabIndex = 2;
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch.Location = new System.Drawing.Point(842, 2);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch.Size = new System.Drawing.Size(66, 20);
            this.ui_nbtnSearch.TabIndex = 16;
            this.ui_nbtnSearch.Text = "Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_ntxtAccountID
            // 
            this.ui_ntxtAccountID.Location = new System.Drawing.Point(722, 3);
            this.ui_ntxtAccountID.Name = "ui_ntxtAccountID";
            this.ui_ntxtAccountID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountID.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtAccountID.TabIndex = 10;
            this.ui_ntxtAccountID.Visible = false;
            // 
            // ui_rptvDayClosing
            // 
            this.ui_tblPStockLevel.SetColumnSpan(this.ui_rptvDayClosing, 2);
            this.ui_rptvDayClosing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvDayClosing.Location = new System.Drawing.Point(3, 54);
            this.ui_rptvDayClosing.Name = "ui_rptvDayClosing";
            this.ui_rptvDayClosing.Size = new System.Drawing.Size(929, 329);
            this.ui_rptvDayClosing.TabIndex = 6;
            this.ui_rptvDayClosing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_rptvDayClosing.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_rptvDayClosing.ShowGroupTreeButton = false;
            this.ui_rptvDayClosing.ShowLogo = false;
            this.ui_rptvDayClosing.ShowParameterPanelButton = false;
            this.ui_rptvDayClosing.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_rptvDayClosing.ReportSource = this.objDayClosingReport;
            // 
            // frmDayClosingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 386);
            this.Controls.Add(this.ui_tblPStockLevel);
            this.Icon = Properties.Resources.favicon;
            this.Name = "frmDayClosingReport";
            this.Text = "Day Closing Report";
            this.Load += new System.EventHandler(this.frmDayClosingReport_Load);
            this.ui_tblPStockLevel.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ui_tblPStockLevel;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private System.Windows.Forms.Label ui_lblSymbol;
        private System.Windows.Forms.Label ui_lblDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountID;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvDayClosing;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerId;
        private Reports.crDayClosing objDayClosingReport;
    }
}