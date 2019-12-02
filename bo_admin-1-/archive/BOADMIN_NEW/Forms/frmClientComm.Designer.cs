namespace BOADMIN_NEW.Forms
{
    partial class frmClientComm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientComm));
            this.objClientCommReport = new Reports.crClientCommission();
            this.ui_tlpClientCommission = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_ndtpTo = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerID = new System.Windows.Forms.Label();
            this.ui_lblDate = new System.Windows.Forms.Label();
            this.ui_ndtpDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_nbtnSearch1 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtAccountNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_lblAccountNumber = new System.Windows.Forms.Label();
            this.ui_rptvClientComm = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ui_tlpClientCommission.SuspendLayout();
            this.ui_ngbSearch.SuspendLayout();
            this.ui_npnlSearch1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tlpClientCommission
            // 
            this.ui_tlpClientCommission.ColumnCount = 2;
            this.ui_tlpClientCommission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpClientCommission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpClientCommission.Controls.Add(this.ui_ngbSearch, 0, 0);
            this.ui_tlpClientCommission.Controls.Add(this.ui_rptvClientComm, 0, 1);
            this.ui_tlpClientCommission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpClientCommission.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpClientCommission.Name = "ui_tlpClientCommission";
            this.ui_tlpClientCommission.RowCount = 2;
            this.ui_tlpClientCommission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpClientCommission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpClientCommission.Size = new System.Drawing.Size(1005, 481);
            this.ui_tlpClientCommission.TabIndex = 1;
            // 
            // ui_ngbSearch
            // 
            this.ui_tlpClientCommission.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(999, 47);
            this.ui_ngbSearch.TabIndex = 4;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.label1);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpTo);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch1);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblAccountNumber);
            this.ui_npnlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSearch1.Location = new System.Drawing.Point(3, 16);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(993, 28);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(149, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "To :";
            // 
            // ui_ndtpTo
            // 
            this.ui_ndtpTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpTo.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpTo.Location = new System.Drawing.Point(180, 3);
            this.ui_ndtpTo.Name = "ui_ndtpTo";
            this.ui_ndtpTo.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpTo.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpTo.TabIndex = 31;
            this.ui_ndtpTo.ValueChanged += new System.EventHandler(this.ui_ndtpTo_ValueChanged);
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(706, 5);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(95, 18);
            this.ui_ntxtBrokerID.TabIndex = 30;
            // 
            // ui_lblBrokerID
            // 
            this.ui_lblBrokerID.AutoSize = true;
            this.ui_lblBrokerID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerID.Location = new System.Drawing.Point(642, 7);
            this.ui_lblBrokerID.Name = "ui_lblBrokerID";
            this.ui_lblBrokerID.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerID.TabIndex = 29;
            this.ui_lblBrokerID.Text = "Broker ID :";
            // 
            // ui_lblDate
            // 
            this.ui_lblDate.AutoSize = true;
            this.ui_lblDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDate.Location = new System.Drawing.Point(3, 8);
            this.ui_lblDate.Name = "ui_lblDate";
            this.ui_lblDate.Size = new System.Drawing.Size(36, 13);
            this.ui_lblDate.TabIndex = 3;
            this.ui_lblDate.Text = "From :";
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
            this.ui_ndtpDate.Location = new System.Drawing.Point(43, 4);
            this.ui_ndtpDate.Name = "ui_ndtpDate";
            this.ui_ndtpDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpDate.TabIndex = 2;
            this.ui_ndtpDate.ValueChanged += new System.EventHandler(this.ui_ndtpDate_ValueChanged);
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(538, 5);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtSymbol.TabIndex = 11;
            this.ui_ntxtSymbol.Leave += new System.EventHandler(this.ui_ntxtSymbol_Leave);
            // 
            // ui_nbtnSearch1
            // 
            this.ui_nbtnSearch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch1.Location = new System.Drawing.Point(909, 4);
            this.ui_nbtnSearch1.Name = "ui_nbtnSearch1";
            this.ui_nbtnSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch1.Size = new System.Drawing.Size(66, 20);
            this.ui_nbtnSearch1.TabIndex = 16;
            this.ui_nbtnSearch1.Text = "Search";
            this.ui_nbtnSearch1.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch1.Click += new System.EventHandler(this.ui_nbtnSearch1_Click);
            // 
            // ui_ntxtAccountNumber
            // 
            this.ui_ntxtAccountNumber.Location = new System.Drawing.Point(379, 5);
            this.ui_ntxtAccountNumber.Name = "ui_ntxtAccountNumber";
            this.ui_ntxtAccountNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountNumber.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtAccountNumber.TabIndex = 10;
            this.ui_ntxtAccountNumber.Leave += new System.EventHandler(this.ui_ntxtAccountNumber_Leave);
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(485, 8);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 6;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_lblAccountNumber
            // 
            this.ui_lblAccountNumber.AutoSize = true;
            this.ui_lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountNumber.Location = new System.Drawing.Point(284, 8);
            this.ui_lblAccountNumber.Name = "ui_lblAccountNumber";
            this.ui_lblAccountNumber.Size = new System.Drawing.Size(93, 13);
            this.ui_lblAccountNumber.TabIndex = 5;
            this.ui_lblAccountNumber.Text = "Account Number :";
            // 
            // ui_rptvClientComm
            // 
            this.ui_tlpClientCommission.SetColumnSpan(this.ui_rptvClientComm, 2);
            this.ui_rptvClientComm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvClientComm.Location = new System.Drawing.Point(3, 56);
            this.ui_rptvClientComm.Name = "ui_rptvClientComm";
            this.ui_rptvClientComm.Size = new System.Drawing.Size(999, 422);
            this.ui_rptvClientComm.TabIndex = 5;                        
            this.ui_rptvClientComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;            
            this.ui_rptvClientComm.Cursor = System.Windows.Forms.Cursors.Default;        
            this.ui_rptvClientComm.ShowGroupTreeButton = false;
            this.ui_rptvClientComm.ShowLogo = false;
            this.ui_rptvClientComm.ShowParameterPanelButton = false;
            this.ui_rptvClientComm.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_rptvClientComm.ReportSource = this.objClientCommReport;
            // 
            // frmClientComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 481);
            this.Controls.Add(this.ui_tlpClientCommission);
            this.Icon = Properties.Resources.favicon;
            this.Name = "frmClientComm";
            this.Text = "Client Commission Report";
            this.Load += new System.EventHandler(this.frmClientComm_Load);
            this.ui_tlpClientCommission.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Reports.crClientCommission objClientCommReport;
        private System.Windows.Forms.TableLayoutPanel ui_tlpClientCommission;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private System.Windows.Forms.Label ui_lblDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpDate;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountNumber;
        private System.Windows.Forms.Label ui_lblSymbol;
        private System.Windows.Forms.Label ui_lblAccountNumber;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvClientComm;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerID;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpTo;
    }
}