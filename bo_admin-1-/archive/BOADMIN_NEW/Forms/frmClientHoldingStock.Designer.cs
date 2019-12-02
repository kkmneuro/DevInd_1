using BOADMIN_NEW.Reports;

namespace BOADMIN_NEW.Forms
{
    partial class frmClientHoldingStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientHoldingStock));
            this.objCrClientHoldingStock = new BOADMIN_NEW.Reports.crClientHoldingStock();
            this.ui_tblPStockLevel = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerID = new System.Windows.Forms.Label();
            this.ui_ntxtClientName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblClientName = new System.Windows.Forms.Label();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_lblTradeDate = new System.Windows.Forms.Label();
            this.ui_ndtpTradeDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtAccountID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblAccountNumber = new System.Windows.Forms.Label();
            this.ui_rptvClientHoldingStock = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.ui_tblPStockLevel.Controls.Add(this.ui_rptvClientHoldingStock, 0, 1);
            this.ui_tblPStockLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tblPStockLevel.Location = new System.Drawing.Point(0, 0);
            this.ui_tblPStockLevel.Name = "ui_tblPStockLevel";
            this.ui_tblPStockLevel.RowCount = 2;
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPStockLevel.Size = new System.Drawing.Size(931, 474);
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
            this.ui_ngbSearch.Size = new System.Drawing.Size(925, 50);
            this.ui_ngbSearch.TabIndex = 5;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtClientName);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblClientName);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblTradeDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpTradeDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblAccountNumber);
            this.ui_npnlSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSearch1.Location = new System.Drawing.Point(3, 16);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(919, 31);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(392, 6);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(84, 18);
            this.ui_ntxtBrokerID.TabIndex = 30;
            // 
            // ui_lblBrokerID
            // 
            this.ui_lblBrokerID.AutoSize = true;
            this.ui_lblBrokerID.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerID.Location = new System.Drawing.Point(331, 9);
            this.ui_lblBrokerID.Name = "ui_lblBrokerID";
            this.ui_lblBrokerID.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerID.TabIndex = 29;
            this.ui_lblBrokerID.Text = "Broker ID :";
            // 
            // ui_ntxtClientName
            // 
            this.ui_ntxtClientName.Location = new System.Drawing.Point(811, 6);
            this.ui_ntxtClientName.Name = "ui_ntxtClientName";
            this.ui_ntxtClientName.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtClientName.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtClientName.TabIndex = 20;
            this.ui_ntxtClientName.Visible = false;
            // 
            // ui_lblClientName
            // 
            this.ui_lblClientName.AutoSize = true;
            this.ui_lblClientName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClientName.Location = new System.Drawing.Point(736, 9);
            this.ui_lblClientName.Name = "ui_lblClientName";
            this.ui_lblClientName.Size = new System.Drawing.Size(70, 13);
            this.ui_lblClientName.TabIndex = 19;
            this.ui_lblClientName.Text = "Client Name :";
            this.ui_lblClientName.Visible = false;
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(223, 6);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtSymbol.TabIndex = 18;
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(171, 9);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 17;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_lblTradeDate
            // 
            this.ui_lblTradeDate.AutoSize = true;
            this.ui_lblTradeDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTradeDate.Location = new System.Drawing.Point(3, 9);
            this.ui_lblTradeDate.Name = "ui_lblTradeDate";
            this.ui_lblTradeDate.Size = new System.Drawing.Size(67, 13);
            this.ui_lblTradeDate.TabIndex = 3;
            this.ui_lblTradeDate.Text = "Trade Date :";
            // 
            // ui_ndtpTradeDate
            // 
            this.ui_ndtpTradeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ui_ndtpTradeDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpTradeDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.ui_ndtpTradeDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(149)))));
            this.ui_ndtpTradeDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.ui_ndtpTradeDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ui_ndtpTradeDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(65)))), ((int)(((byte)(181)))));
            this.ui_ndtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpTradeDate.Location = new System.Drawing.Point(72, 5);
            this.ui_ndtpTradeDate.Name = "ui_ndtpTradeDate";
            this.ui_ndtpTradeDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpTradeDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpTradeDate.TabIndex = 2;
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Location = new System.Drawing.Point(669, 5);
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
            this.ui_ntxtAccountID.Location = new System.Drawing.Point(555, 6);
            this.ui_ntxtAccountID.Name = "ui_ntxtAccountID";
            this.ui_ntxtAccountID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountID.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtAccountID.TabIndex = 10;
            // 
            // ui_lblAccountNumber
            // 
            this.ui_lblAccountNumber.AutoSize = true;
            this.ui_lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountNumber.Location = new System.Drawing.Point(481, 9);
            this.ui_lblAccountNumber.Name = "ui_lblAccountNumber";
            this.ui_lblAccountNumber.Size = new System.Drawing.Size(67, 13);
            this.ui_lblAccountNumber.TabIndex = 5;
            this.ui_lblAccountNumber.Text = "Account ID :";
            // 
            // ui_rptvClientHoldingStock
            // 
            this.ui_rptvClientHoldingStock.ActiveViewIndex = 0;
            this.ui_rptvClientHoldingStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_tblPStockLevel.SetColumnSpan(this.ui_rptvClientHoldingStock, 2);
            this.ui_rptvClientHoldingStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.ui_rptvClientHoldingStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvClientHoldingStock.Location = new System.Drawing.Point(3, 59);
            this.ui_rptvClientHoldingStock.Name = "ui_rptvClientHoldingStock";
            this.ui_rptvClientHoldingStock.ReportSource = this.objCrClientHoldingStock;
           // this.ui_rptvClientHoldingStock.ShowExportButton = false;
            this.ui_rptvClientHoldingStock.ShowGroupTreeButton = false;
            this.ui_rptvClientHoldingStock.ShowLogo = false;
            this.ui_rptvClientHoldingStock.ShowParameterPanelButton = false;
            this.ui_rptvClientHoldingStock.Size = new System.Drawing.Size(925, 412);
            this.ui_rptvClientHoldingStock.TabIndex = 0;
            this.ui_rptvClientHoldingStock.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmClientHoldingStockNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(931, 474);
            this.Controls.Add(this.ui_tblPStockLevel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClientHoldingStockNew";
            this.ShowInTaskbar = false;
            this.Text = "Client Holding Stock Report";
            this.Load += new System.EventHandler(this.frmClientHoldingStockNew_Load);
            this.ui_tblPStockLevel.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private crClientHoldingStock objCrClientHoldingStock;
        private System.Windows.Forms.TableLayoutPanel ui_tblPStockLevel;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerID;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClientName;
        private System.Windows.Forms.Label ui_lblClientName;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private System.Windows.Forms.Label ui_lblSymbol;
        private System.Windows.Forms.Label ui_lblTradeDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpTradeDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountID;
        private System.Windows.Forms.Label ui_lblAccountNumber;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvClientHoldingStock;
    }
}
