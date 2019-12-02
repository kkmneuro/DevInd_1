namespace CommonLibrary.UserControls
{
    partial class uctlPendingNew
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPendingInfo = new System.Windows.Forms.Label();
            this.dtpickerGTD = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.cmbTIF = new Nevron.UI.WinForm.Controls.NComboBox();
            this.cmbSide = new Nevron.UI.WinForm.Controls.NComboBox();
            this.btnPlace = new Nevron.UI.WinForm.Controls.NButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPrice = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.2149F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.26075F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPendingInfo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpickerGTD, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIF, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbSide, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlace, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbPrice, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrice, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 226);
            this.tableLayoutPanel1.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Type :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPendingInfo
            // 
            this.lblPendingInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPendingInfo.AutoSize = true;
            this.lblPendingInfo.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblPendingInfo, 3);
            this.lblPendingInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingInfo.Location = new System.Drawing.Point(12, 196);
            this.lblPendingInfo.Name = "lblPendingInfo";
            this.lblPendingInfo.Size = new System.Drawing.Size(325, 13);
            this.lblPendingInfo.TabIndex = 58;
            this.lblPendingInfo.Text = "Open price you set must differ from market price by at least 4 pips";
            // 
            // dtpickerGTD
            // 
            this.dtpickerGTD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpickerGTD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dtpickerGTD.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpickerGTD.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtpickerGTD.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dtpickerGTD.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dtpickerGTD.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.dtpickerGTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpickerGTD.Location = new System.Drawing.Point(235, 102);
            this.dtpickerGTD.Name = "dtpickerGTD";
            this.dtpickerGTD.Size = new System.Drawing.Size(111, 21);
            this.dtpickerGTD.TabIndex = 63;
            this.dtpickerGTD.ValueChanged += new System.EventHandler(this.dtpickerGTD_ValueChanged);
            // 
            // cmbTIF
            // 
            this.cmbTIF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTIF.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("DAY", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("GTC", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cmbTIF.ListProperties.ColumnOnLeft = false;
            this.cmbTIF.Location = new System.Drawing.Point(91, 102);
            this.cmbTIF.Name = "cmbTIF";
            this.cmbTIF.Size = new System.Drawing.Size(138, 21);
            this.cmbTIF.TabIndex = 61;
            this.cmbTIF.Text = "nComboBox2";
            this.cmbTIF.SelectedIndexChanged += new System.EventHandler(this.cmbTIF_SelectedIndexChanged);
            // 
            // cmbSide
            // 
            this.cmbSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSide.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Buy Limit", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Buy Stop", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Sell Limit", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Sell Stop", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cmbSide.ListProperties.ColumnOnLeft = false;
            this.cmbSide.Location = new System.Drawing.Point(91, 12);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(138, 21);
            this.cmbSide.TabIndex = 59;
            this.cmbSide.SelectedIndexChanged += new System.EventHandler(this.cmbSide_SelectedIndexChanged);
            // 
            // btnPlace
            // 
            this.btnPlace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlace.Location = new System.Drawing.Point(244, 54);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(93, 26);
            this.btnPlace.TabIndex = 62;
            this.btnPlace.Text = "Place";
            this.btnPlace.UseVisualStyleBackColor = false;
            this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(3, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 54;
            this.label19.Text = "Price :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(3, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 55;
            this.label17.Text = "Time In Force :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPrice
            // 
            this.cmbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrice.Location = new System.Drawing.Point(235, 12);
            this.cmbPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(111, 20);
            this.cmbPrice.TabIndex = 64;
            this.cmbPrice.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(91, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(138, 20);
            this.txtPrice.TabIndex = 65;
            this.txtPrice.Text = "0";
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPrice_MouseDown);
            // 
            // uctlPendingNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlPendingNew";
            this.Size = new System.Drawing.Size(351, 228);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lblPendingInfo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox cmbSide;
        private Nevron.UI.WinForm.Controls.NComboBox cmbTIF;
        private Nevron.UI.WinForm.Controls.NButton btnPlace;
        private Nevron.UI.WinForm.Controls.NDateTimePicker dtpickerGTD;
        private Nevron.UI.WinForm.Controls.NNumericUpDown cmbPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPrice;
    }
}
