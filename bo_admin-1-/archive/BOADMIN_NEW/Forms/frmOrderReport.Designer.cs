namespace BOADMIN_NEW.Forms
{
    partial class frmOrderReport
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
            this.objOpenOrdersReport = new Reports.crOpenOrders();
            this.ui_tlpOrders = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ngbSearch = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_npnlSearch1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncmbTIF = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblTIF = new System.Windows.Forms.Label();
            this.ui_ntxtBrokerID = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblBrokerId = new System.Windows.Forms.Label();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblSymbol = new System.Windows.Forms.Label();
            this.ui_ncmbOrderType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbSide = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ntxtOrderNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblOrderNumber = new System.Windows.Forms.Label();
            this.ui_lblToDate = new System.Windows.Forms.Label();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblFromDate = new System.Windows.Forms.Label();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblSide = new System.Windows.Forms.Label();
            this.ui_nbtnSearch1 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtAccountNumber = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblOrderType = new System.Windows.Forms.Label();
            this.ui_lblAccountNumber = new System.Windows.Forms.Label();
            this.ui_rptvOrder = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ui_tlpOrders.SuspendLayout();
            this.ui_ngbSearch.SuspendLayout();
            this.ui_npnlSearch1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_tlpOrders
            // 
            this.ui_tlpOrders.ColumnCount = 2;
            this.ui_tlpOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpOrders.Controls.Add(this.ui_ngbSearch, 0, 0);
            this.ui_tlpOrders.Controls.Add(this.ui_rptvOrder, 0, 1);
            this.ui_tlpOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_tlpOrders.Location = new System.Drawing.Point(0, 0);
            this.ui_tlpOrders.Name = "ui_tlpOrders";
            this.ui_tlpOrders.RowCount = 2;
            this.ui_tlpOrders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpOrders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tlpOrders.Size = new System.Drawing.Size(1017, 491);
            this.ui_tlpOrders.TabIndex = 0;
            // 
            // ui_ngbSearch
            // 
            this.ui_tlpOrders.SetColumnSpan(this.ui_ngbSearch, 2);
            this.ui_ngbSearch.Controls.Add(this.ui_npnlSearch1);
            this.ui_ngbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ngbSearch.Location = new System.Drawing.Point(3, 3);
            this.ui_ngbSearch.Name = "ui_ngbSearch";
            this.ui_ngbSearch.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ngbSearch.Size = new System.Drawing.Size(1011, 75);
            this.ui_ngbSearch.TabIndex = 4;
            this.ui_ngbSearch.TabStop = false;
            this.ui_ngbSearch.Text = "Search";
            // 
            // ui_npnlSearch1
            // 
            this.ui_npnlSearch1.Controls.Add(this.ui_ncmbTIF);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblTIF);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtBrokerID);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblBrokerId);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSymbol);
            this.ui_npnlSearch1.Controls.Add(this.ui_ncmbOrderType);
            this.ui_npnlSearch1.Controls.Add(this.ui_ncmbSide);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtOrderNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblOrderNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpToDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblFromDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_ndtpFromDate);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblSide);
            this.ui_npnlSearch1.Controls.Add(this.ui_nbtnSearch1);
            this.ui_npnlSearch1.Controls.Add(this.ui_ntxtAccountNumber);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblOrderType);
            this.ui_npnlSearch1.Controls.Add(this.ui_lblAccountNumber);
            this.ui_npnlSearch1.Location = new System.Drawing.Point(6, 14);
            this.ui_npnlSearch1.Name = "ui_npnlSearch1";
            this.ui_npnlSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_npnlSearch1.Size = new System.Drawing.Size(1019, 60);
            this.ui_npnlSearch1.TabIndex = 15;
            this.ui_npnlSearch1.Text = "nuiPanel1";
            // 
            // ui_ncmbTIF
            // 
            this.ui_ncmbTIF.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbTIF.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbTIF.Location = new System.Drawing.Point(447, 33);
            this.ui_ncmbTIF.Name = "ui_ncmbTIF";
            this.ui_ncmbTIF.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ncmbTIF.Size = new System.Drawing.Size(108, 18);
            this.ui_ncmbTIF.TabIndex = 32;
            // 
            // ui_lblTIF
            // 
            this.ui_lblTIF.AutoSize = true;
            this.ui_lblTIF.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTIF.Location = new System.Drawing.Point(338, 36);
            this.ui_lblTIF.Name = "ui_lblTIF";
            this.ui_lblTIF.Size = new System.Drawing.Size(106, 13);
            this.ui_lblTIF.TabIndex = 31;
            this.ui_lblTIF.Text = "Time In Force( TIF ) :";
            // 
            // ui_ntxtBrokerID
            // 
            this.ui_ntxtBrokerID.Location = new System.Drawing.Point(72, 33);
            this.ui_ntxtBrokerID.Name = "ui_ntxtBrokerID";
            this.ui_ntxtBrokerID.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtBrokerID.Size = new System.Drawing.Size(92, 18);
            this.ui_ntxtBrokerID.TabIndex = 30;
            // 
            // ui_lblBrokerId
            // 
            this.ui_lblBrokerId.AutoSize = true;
            this.ui_lblBrokerId.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblBrokerId.Location = new System.Drawing.Point(7, 36);
            this.ui_lblBrokerId.Name = "ui_lblBrokerId";
            this.ui_lblBrokerId.Size = new System.Drawing.Size(58, 13);
            this.ui_lblBrokerId.TabIndex = 29;
            this.ui_lblBrokerId.Text = "Broker ID :";
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(229, 33);
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(94, 18);
            this.ui_ntxtSymbol.TabIndex = 28;
            // 
            // ui_lblSymbol
            // 
            this.ui_lblSymbol.AutoSize = true;
            this.ui_lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbol.Location = new System.Drawing.Point(178, 36);
            this.ui_lblSymbol.Name = "ui_lblSymbol";
            this.ui_lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.ui_lblSymbol.TabIndex = 27;
            this.ui_lblSymbol.Text = "Symbol :";
            // 
            // ui_ncmbOrderType
            // 
            this.ui_ncmbOrderType.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbOrderType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderType.Location = new System.Drawing.Point(666, 33);
            this.ui_ncmbOrderType.Name = "ui_ncmbOrderType";
            this.ui_ncmbOrderType.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ncmbOrderType.Size = new System.Drawing.Size(108, 18);
            this.ui_ncmbOrderType.TabIndex = 26;
            // 
            // ui_ncmbSide
            // 
            this.ui_ncmbSide.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbSide.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSide.Location = new System.Drawing.Point(447, 6);
            this.ui_ncmbSide.Name = "ui_ncmbSide";
            this.ui_ncmbSide.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ncmbSide.Size = new System.Drawing.Size(108, 18);
            this.ui_ncmbSide.TabIndex = 25;
            // 
            // ui_ntxtOrderNumber
            // 
            this.ui_ntxtOrderNumber.Location = new System.Drawing.Point(879, 6);
            this.ui_ntxtOrderNumber.Name = "ui_ntxtOrderNumber";
            this.ui_ntxtOrderNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtOrderNumber.Size = new System.Drawing.Size(108, 18);
            this.ui_ntxtOrderNumber.TabIndex = 12;
            // 
            // ui_lblOrderNumber
            // 
            this.ui_lblOrderNumber.AutoSize = true;
            this.ui_lblOrderNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderNumber.Location = new System.Drawing.Point(794, 8);
            this.ui_lblOrderNumber.Name = "ui_lblOrderNumber";
            this.ui_lblOrderNumber.Size = new System.Drawing.Size(79, 13);
            this.ui_lblOrderNumber.TabIndex = 7;
            this.ui_lblOrderNumber.Text = "Order Number :";
            // 
            // ui_lblToDate
            // 
            this.ui_lblToDate.AutoSize = true;
            this.ui_lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblToDate.Location = new System.Drawing.Point(173, 9);
            this.ui_lblToDate.Name = "ui_lblToDate";
            this.ui_lblToDate.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToDate.TabIndex = 24;
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
            this.ui_ndtpToDate.Location = new System.Drawing.Point(229, 5);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpToDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpToDate.TabIndex = 23;
            this.ui_ndtpToDate.ValueChanged += new System.EventHandler(this.ui_ndtpToDate_ValueChanged);
            // 
            // ui_lblFromDate
            // 
            this.ui_lblFromDate.AutoSize = true;
            this.ui_lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFromDate.Location = new System.Drawing.Point(3, 9);
            this.ui_lblFromDate.Name = "ui_lblFromDate";
            this.ui_lblFromDate.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromDate.TabIndex = 22;
            this.ui_lblFromDate.Text = "From Date :";
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
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(70, 5);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(94, 21);
            this.ui_ndtpFromDate.TabIndex = 21;
            this.ui_ndtpFromDate.ValueChanged += new System.EventHandler(this.ui_ndtpFromDate_ValueChanged);
            // 
            // ui_lblSide
            // 
            this.ui_lblSide.AutoSize = true;
            this.ui_lblSide.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSide.Location = new System.Drawing.Point(410, 9);
            this.ui_lblSide.Name = "ui_lblSide";
            this.ui_lblSide.Size = new System.Drawing.Size(34, 13);
            this.ui_lblSide.TabIndex = 4;
            this.ui_lblSide.Text = "Side :";
            // 
            // ui_nbtnSearch1
            // 
            this.ui_nbtnSearch1.Location = new System.Drawing.Point(879, 30);
            this.ui_nbtnSearch1.Name = "ui_nbtnSearch1";
            this.ui_nbtnSearch1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nbtnSearch1.Size = new System.Drawing.Size(108, 25);
            this.ui_nbtnSearch1.TabIndex = 16;
            this.ui_nbtnSearch1.Text = "Search";
            this.ui_nbtnSearch1.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch1.Click += new System.EventHandler(this.ui_nbtnSearch1_Click);
            // 
            // ui_ntxtAccountNumber
            // 
            this.ui_ntxtAccountNumber.Location = new System.Drawing.Point(666, 6);
            this.ui_ntxtAccountNumber.Name = "ui_ntxtAccountNumber";
            this.ui_ntxtAccountNumber.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_ntxtAccountNumber.Size = new System.Drawing.Size(108, 18);
            this.ui_ntxtAccountNumber.TabIndex = 10;
            this.ui_ntxtAccountNumber.Leave += new System.EventHandler(this.ui_ntxtAccountNumber_Leave);
            // 
            // ui_lblOrderType
            // 
            this.ui_lblOrderType.AutoSize = true;
            this.ui_lblOrderType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderType.Location = new System.Drawing.Point(596, 36);
            this.ui_lblOrderType.Name = "ui_lblOrderType";
            this.ui_lblOrderType.Size = new System.Drawing.Size(66, 13);
            this.ui_lblOrderType.TabIndex = 6;
            this.ui_lblOrderType.Text = "Order Type :";
            // 
            // ui_lblAccountNumber
            // 
            this.ui_lblAccountNumber.AutoSize = true;
            this.ui_lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccountNumber.Location = new System.Drawing.Point(569, 9);
            this.ui_lblAccountNumber.Name = "ui_lblAccountNumber";
            this.ui_lblAccountNumber.Size = new System.Drawing.Size(93, 13);
            this.ui_lblAccountNumber.TabIndex = 5;
            this.ui_lblAccountNumber.Text = "Account Number :";
            // 
            // ui_rptvOrder
            // 
            this.ui_rptvOrder.ActiveViewIndex = -1;
            this.ui_rptvOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_tlpOrders.SetColumnSpan(this.ui_rptvOrder, 2);
            this.ui_rptvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_rptvOrder.Location = new System.Drawing.Point(3, 84);
            this.ui_rptvOrder.Name = "ui_rptvOrder";
            this.ui_rptvOrder.Size = new System.Drawing.Size(1011, 404);
            this.ui_rptvOrder.TabIndex = 5;
            //this.ui_rptvOrder.ShowExportButton = false;
            this.ui_rptvOrder.ShowGroupTreeButton = false;
            this.ui_rptvOrder.ShowLogo = false;
            this.ui_rptvOrder.ShowParameterPanelButton = false;
            this.ui_rptvOrder.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ui_rptvOrder.ReportSource = this.objOpenOrdersReport;
            // 
            // frmOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 491);
            this.Controls.Add(this.ui_tlpOrders);
            this.Name = "frmOrderReport";
            this.Text = "Order Report";
            this.Load += new System.EventHandler(this.frmOrderReport_Load);
            this.ui_tlpOrders.ResumeLayout(false);
            this.ui_ngbSearch.ResumeLayout(false);
            this.ui_npnlSearch1.ResumeLayout(false);
            this.ui_npnlSearch1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ui_tlpOrders;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_ngbSearch;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSearch1;
        private System.Windows.Forms.Label ui_lblSide;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtAccountNumber;
        private System.Windows.Forms.Label ui_lblOrderType;
        private System.Windows.Forms.Label ui_lblAccountNumber;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOrderNumber;
        private System.Windows.Forms.Label ui_lblOrderNumber;
        private System.Windows.Forms.Label ui_lblToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
        private System.Windows.Forms.Label ui_lblFromDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSide;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderType;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        private System.Windows.Forms.Label ui_lblSymbol;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtBrokerID;
        private System.Windows.Forms.Label ui_lblBrokerId;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbTIF;
        private System.Windows.Forms.Label ui_lblTIF;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ui_rptvOrder;
        private Reports.crOpenOrders objOpenOrdersReport;
    }
}