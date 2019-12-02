namespace BOADMIN_NEW.Forms
{
    partial class frmAccountTransReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountTransReport));
            this.objAccountTransReport = new Reports.crAccountTransactions();
            this.ui_tblPAccountTrans = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerID = new System.Windows.Forms.Label();
            this.ui_ntxtAccountNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblAccountNumber = new System.Windows.Forms.Label();
            this.ui_lblToDate = new System.Windows.Forms.Label();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblFromDate = new System.Windows.Forms.Label();
            this.ui_rptvAccountTrans = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ui_tblPAccountTrans.SuspendLayout();
            this.ui_ngbSearch.SuspendLayout();
            this.ui_npnlSearch1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tblPAccountTrans
            // 
            this.ui_tblPAccountTrans.ColumnCount = 2;
            this.ui_tblPAccountTrans.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPAccountTrans.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPAccountTrans.Controls.Add(this.ui_ngbSearch, 0, 0);
            this.ui_tblPAccountTrans.Controls.Add(this.ui_rptvAccountTrans, 0, 1);
            this.ui_tblPAccountTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tblPAccountTrans.Location = new System.Drawing.Point(0, 0);
            this.ui_tblPAccountTrans.Name = "ui_tblPAccountTrans";
            this.ui_tblPAccountTrans.RowCount = 2;
            this.ui_tblPAccountTrans.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPAccountTrans.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPAccountTrans.Size = new System.Drawing.Size(934, 364);
            this.ui_tblPAccountTrans.TabIndex = 2;
            // 
            // ui_ngbSearch
            // 
            this.ui_tblPAccountTrans.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(928, 50);
            this.ui_ngbSearch.TabIndex = 5;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblAccountNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpFromDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblFromDate);
            this.ui_npnlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSearch1.Location = new System.Drawing.Point(3, 16);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(922, 31);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(574, 6);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(84, 18);
            this.ui_ntxtBrokerID.TabIndex = 32;
            // 
            // ui_lblBrokerID
            // 
            this.ui_lblBrokerID.AutoSize = true;
            this.ui_lblBrokerID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerID.Location = new System.Drawing.Point(513, 9);
            this.ui_lblBrokerID.Name = "ui_lblBrokerID";
            this.ui_lblBrokerID.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerID.TabIndex = 31;
            this.ui_lblBrokerID.Text = "Broker ID :";
            // 
            // ui_ntxtAccountNumber
            // 
            this.ui_ntxtAccountNumber.Location = new System.Drawing.Point(420, 6);
            this.ui_ntxtAccountNumber.Name = "ui_ntxtAccountNumber";
            this.ui_ntxtAccountNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountNumber.Size = new System.Drawing.Size(86, 18);
            this.ui_ntxtAccountNumber.TabIndex = 22;
            // 
            // ui_lblAccountNumber
            // 
            this.ui_lblAccountNumber.AutoSize = true;
            this.ui_lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountNumber.Location = new System.Drawing.Point(325, 9);
            this.ui_lblAccountNumber.Name = "ui_lblAccountNumber";
            this.ui_lblAccountNumber.Size = new System.Drawing.Size(93, 13);
            this.ui_lblAccountNumber.TabIndex = 21;
            this.ui_lblAccountNumber.Text = "Account Number :";
            // 
            // ui_lblToDate
            // 
            this.ui_lblToDate.AutoSize = true;
            this.ui_lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblToDate.Location = new System.Drawing.Point(162, 9);
            this.ui_lblToDate.Name = "ui_lblToDate";
            this.ui_lblToDate.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToDate.TabIndex = 20;
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
            this.ui_ndtpToDate.Location = new System.Drawing.Point(220, 5);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpToDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpToDate.TabIndex = 19;
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
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(62, 5);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpFromDate.TabIndex = 2;
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch.Location = new System.Drawing.Point(837, 5);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch.Size = new System.Drawing.Size(66, 20);
            this.ui_nbtnSearch.TabIndex = 16;
            this.ui_nbtnSearch.Text = "Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_lblFromDate
            // 
            this.ui_lblFromDate.AutoSize = true;
            this.ui_lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFromDate.Location = new System.Drawing.Point(3, 9);
            this.ui_lblFromDate.Name = "ui_lblFromDate";
            this.ui_lblFromDate.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromDate.TabIndex = 3;
            this.ui_lblFromDate.Text = "From Date :";
            // 
            // ui_rptvAccountTrans
            // 
            this.ui_tblPAccountTrans.SetColumnSpan(this.ui_rptvAccountTrans, 2);
            this.ui_rptvAccountTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvAccountTrans.Location = new System.Drawing.Point(3, 59);
            this.ui_rptvAccountTrans.Name = "ui_rptvAccountTrans";
            this.ui_rptvAccountTrans.Size = new System.Drawing.Size(928, 302);
            this.ui_rptvAccountTrans.TabIndex = 6;
            this.ui_rptvAccountTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_rptvAccountTrans.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_rptvAccountTrans.ShowGroupTreeButton = false;
            this.ui_rptvAccountTrans.ShowLogo = false;
            this.ui_rptvAccountTrans.ShowParameterPanelButton = false;
            this.ui_rptvAccountTrans.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_rptvAccountTrans.ReportSource = this.objAccountTransReport;
            // 
            // frmAccountTransReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 364);
            this.Controls.Add(this.ui_tblPAccountTrans);
            this.Icon = Properties.Resources.favicon;
            this.Name = "frmAccountTransReport";
            this.Text = "Account Transaction Report";
            this.Load += new System.EventHandler(this.frmAccountTransReport_Load);
            this.ui_tblPAccountTrans.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ui_tblPAccountTrans;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private System.Windows.Forms.Label ui_lblToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private System.Windows.Forms.Label ui_lblFromDate;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvAccountTrans;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountNumber;
        private System.Windows.Forms.Label ui_lblAccountNumber;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerID;
        private Reports.crAccountTransactions objAccountTransReport;
        
    }
}