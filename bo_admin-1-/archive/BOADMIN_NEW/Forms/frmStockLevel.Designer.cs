namespace BOADMIN_NEW.Forms
{
    partial class frmStockLevel
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
            this.objStockLevel = new Reports.crStockLevel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockLevel));
            this.ui_tblPStockLevel = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerId = new System.Windows.Forms.Label();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtProductType = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblProductType = new System.Windows.Forms.Label();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblToDate = new System.Windows.Forms.Label();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblFromDate = new System.Windows.Forms.Label();
            this.ui_rptvStockLevel = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.ui_tblPStockLevel.Controls.Add(this.ui_rptvStockLevel, 0, 1);
            this.ui_tblPStockLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tblPStockLevel.Location = new System.Drawing.Point(0, 0);
            this.ui_tblPStockLevel.Name = "ui_tblPStockLevel";
            this.ui_tblPStockLevel.RowCount = 2;
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.Size = new System.Drawing.Size(804, 354);
            this.ui_tblPStockLevel.TabIndex = 1;
            // 
            // ui_ngbSearch
            // 
            this.ui_tblPStockLevel.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Controls.Add(this.ui_ndtpToDate);
            this.ui_ngbSearch.Controls.Add(this.ui_lblToDate);
            this.ui_ngbSearch.Controls.Add(this.ui_ndtpFromDate);
            this.ui_ngbSearch.Controls.Add(this.ui_lblFromDate);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(798, 45);
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
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtProductType);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblProductType);
            this.ui_npnlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSearch1.Location = new System.Drawing.Point(3, 16);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(792, 26);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(414, 3);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(90, 18);
            this.ui_ntxtBrokerID.TabIndex = 32;
            // 
            // ui_lblBrokerId
            // 
            this.ui_lblBrokerId.AutoSize = true;
            this.ui_lblBrokerId.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerId.Location = new System.Drawing.Point(351, 6);
            this.ui_lblBrokerId.Name = "ui_lblBrokerId";
            this.ui_lblBrokerId.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerId.TabIndex = 31;
            this.ui_lblBrokerId.Text = "Broker ID :";
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(241, 3);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtSymbol.TabIndex = 18;
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(192, 6);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 17;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch.Location = new System.Drawing.Point(711, 2);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch.Size = new System.Drawing.Size(66, 20);
            this.ui_nbtnSearch.TabIndex = 16;
            this.ui_nbtnSearch.Text = "Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_ntxtProductType
            // 
            this.ui_ntxtProductType.Location = new System.Drawing.Point(85, 3);
            this.ui_ntxtProductType.Name = "ui_ntxtProductType";
            this.ui_ntxtProductType.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtProductType.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtProductType.TabIndex = 10;
            // 
            // ui_lblProductType
            // 
            this.ui_lblProductType.AutoSize = true;
            this.ui_lblProductType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProductType.Location = new System.Drawing.Point(6, 6);
            this.ui_lblProductType.Name = "ui_lblProductType";
            this.ui_lblProductType.Size = new System.Drawing.Size(77, 13);
            this.ui_lblProductType.TabIndex = 5;
            this.ui_lblProductType.Text = "Product Type :";
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
            this.ui_ndtpToDate.Location = new System.Drawing.Point(534, -4);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpToDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpToDate.TabIndex = 19;
            this.ui_ndtpToDate.Visible = false;
            // 
            // ui_lblToDate
            // 
            this.ui_lblToDate.AutoSize = true;
            this.ui_lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblToDate.Location = new System.Drawing.Point(634, -3);
            this.ui_lblToDate.Name = "ui_lblToDate";
            this.ui_lblToDate.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToDate.TabIndex = 20;
            this.ui_lblToDate.Text = "To Date :";
            this.ui_lblToDate.Visible = false;
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
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(434, 0);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpFromDate.TabIndex = 2;
            this.ui_ndtpFromDate.Visible = false;
            this.ui_ndtpFromDate.ValueChanged += new System.EventHandler(this.ui_ndtpFromDate_ValueChanged);
            // 
            // ui_lblFromDate
            // 
            this.ui_lblFromDate.AutoSize = true;
            this.ui_lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFromDate.Location = new System.Drawing.Point(378, 0);
            this.ui_lblFromDate.Name = "ui_lblFromDate";
            this.ui_lblFromDate.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromDate.TabIndex = 3;
            this.ui_lblFromDate.Text = "From Date :";
            this.ui_lblFromDate.Visible = false;
            // 
            // ui_rptvStockLevel
            // 
            this.ui_tblPStockLevel.SetColumnSpan(this.ui_rptvStockLevel, 2);
            this.ui_rptvStockLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvStockLevel.Location = new System.Drawing.Point(3, 54);
            this.ui_rptvStockLevel.Name = "ui_rptvStockLevel";
            this.ui_rptvStockLevel.Size = new System.Drawing.Size(798, 297);
            this.ui_rptvStockLevel.TabIndex = 6;            
            this.ui_rptvStockLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_rptvStockLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_rptvStockLevel.ShowGroupTreeButton = false;
            this.ui_rptvStockLevel.ShowLogo = false;
            this.ui_rptvStockLevel.ShowParameterPanelButton = false;
            this.ui_rptvStockLevel.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_rptvStockLevel.ReportSource = this.objStockLevel;
            // 
            // frmStockLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 354);
            this.Controls.Add(this.ui_tblPStockLevel);
            this.Icon = Properties.Resources.favicon;
            this.Name = "frmStockLevel";
            this.ShowInTaskbar = false;
            this.Text = "Stock Level Report";
            this.Load += new System.EventHandler(this.frmStockLevel_Load);
            this.ui_tblPStockLevel.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_ngbSearch.PerformLayout();
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ui_tblPStockLevel;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private System.Windows.Forms.Label ui_lblFromDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtProductType;
        private System.Windows.Forms.Label ui_lblProductType;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private System.Windows.Forms.Label ui_lblSymbol;
        private System.Windows.Forms.Label ui_lblToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvStockLevel;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerId;
        private Reports.crStockLevel objStockLevel;
    }
}