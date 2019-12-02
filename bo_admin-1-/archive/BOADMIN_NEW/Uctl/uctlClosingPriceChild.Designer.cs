namespace BOADMIN_NEW.Uctl
{
    partial class uctlClosingPriceChild
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nButton4 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpClosingDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ncmbSymbolName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblSymbolName = new System.Windows.Forms.Label();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtClosingPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtSymbolClosingPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblClosingDate = new System.Windows.Forms.Label();
            this.ui_lblClosingPrice = new System.Windows.Forms.Label();
            this.ui_lblSymbolClosingPrice = new System.Windows.Forms.Label();
            this.ui_npnlControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.nButton4);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ndtpClosingDate);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ncmbSymbolName);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblSymbolName);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnOK);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtClosingPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtSymbolClosingPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblClosingDate);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblClosingPrice);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblSymbolClosingPrice);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(331, 138);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // nButton4
            // 
            this.nButton4.Image = global::BOADMIN_NEW.Properties.Resources.downarrow;
            this.nButton4.Location = new System.Drawing.Point(293, 64);
            this.nButton4.Name = "nButton4";
            this.nButton4.Size = new System.Drawing.Size(20, 21);
            this.nButton4.TabIndex = 129;
            this.nButton4.UseVisualStyleBackColor = false;
            this.nButton4.Click += new System.EventHandler(this.nButton4_Click);
            // 
            // ui_ndtpClosingDate
            // 
            this.ui_ndtpClosingDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpClosingDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpClosingDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpClosingDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpClosingDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpClosingDate.CustomFormat = "";
            this.ui_ndtpClosingDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.ui_ndtpClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ui_ndtpClosingDate.Location = new System.Drawing.Point(126, 64);
            this.ui_ndtpClosingDate.Name = "ui_ndtpClosingDate";
            this.ui_ndtpClosingDate.Size = new System.Drawing.Size(187, 21);
            this.ui_ndtpClosingDate.TabIndex = 128;
            // 
            // ui_ncmbSymbolName
            // 
            this.ui_ncmbSymbolName.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Per Volume", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Per Day", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbSymbolName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSymbolName.Location = new System.Drawing.Point(126, 14);
            this.ui_ncmbSymbolName.Name = "ui_ncmbSymbolName";
            this.ui_ncmbSymbolName.Size = new System.Drawing.Size(187, 19);
            this.ui_ncmbSymbolName.TabIndex = 26;
            this.ui_ncmbSymbolName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbSymbolName_SelectedIndexChanged);
            // 
            // ui_lblSymbolName
            // 
            this.ui_lblSymbolName.AutoSize = true;
            this.ui_lblSymbolName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbolName.Location = new System.Drawing.Point(46, 17);
            this.ui_lblSymbolName.Name = "ui_lblSymbolName";
            this.ui_lblSymbolName.Size = new System.Drawing.Size(78, 13);
            this.ui_lblSymbolName.TabIndex = 30;
            this.ui_lblSymbolName.Text = "Symbol Name :";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(238, 101);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 29;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(156, 101);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOK.TabIndex = 28;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_ntxtClosingPrice
            // 
            this.ui_ntxtClosingPrice.Location = new System.Drawing.Point(126, 40);
            this.ui_ntxtClosingPrice.MaxLength = 18;
            this.ui_ntxtClosingPrice.Name = "ui_ntxtClosingPrice";
            this.ui_ntxtClosingPrice.Size = new System.Drawing.Size(187, 18);
            this.ui_ntxtClosingPrice.TabIndex = 23;
            this.ui_ntxtClosingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ntxtClosingPrice_KeyDown);
            this.ui_ntxtClosingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtClosingPrice_KeyPress);
            // 
            // ui_ntxtSymbolClosingPrice
            // 
            this.ui_ntxtSymbolClosingPrice.InputMode = Nevron.UI.WinForm.Controls.TextBoxInputMode.NumericInteger;
            this.ui_ntxtSymbolClosingPrice.Location = new System.Drawing.Point(26, 128);
            this.ui_ntxtSymbolClosingPrice.MaxLength = 18;
            this.ui_ntxtSymbolClosingPrice.Name = "ui_ntxtSymbolClosingPrice";
            this.ui_ntxtSymbolClosingPrice.Size = new System.Drawing.Size(58, 18);
            this.ui_ntxtSymbolClosingPrice.TabIndex = 21;
            this.ui_ntxtSymbolClosingPrice.Visible = false;
            // 
            // ui_lblClosingDate
            // 
            this.ui_lblClosingDate.AutoSize = true;
            this.ui_lblClosingDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClosingDate.Location = new System.Drawing.Point(51, 68);
            this.ui_lblClosingDate.Name = "ui_lblClosingDate";
            this.ui_lblClosingDate.Size = new System.Drawing.Size(73, 13);
            this.ui_lblClosingDate.TabIndex = 27;
            this.ui_lblClosingDate.Text = "Closing Date :";
            // 
            // ui_lblClosingPrice
            // 
            this.ui_lblClosingPrice.AutoSize = true;
            this.ui_lblClosingPrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClosingPrice.Location = new System.Drawing.Point(50, 43);
            this.ui_lblClosingPrice.Name = "ui_lblClosingPrice";
            this.ui_lblClosingPrice.Size = new System.Drawing.Size(74, 13);
            this.ui_lblClosingPrice.TabIndex = 24;
            this.ui_lblClosingPrice.Text = "Closing Price :";
            // 
            // ui_lblSymbolClosingPrice
            // 
            this.ui_lblSymbolClosingPrice.AutoSize = true;
            this.ui_lblSymbolClosingPrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSymbolClosingPrice.Location = new System.Drawing.Point(2, 112);
            this.ui_lblSymbolClosingPrice.Name = "ui_lblSymbolClosingPrice";
            this.ui_lblSymbolClosingPrice.Size = new System.Drawing.Size(114, 13);
            this.ui_lblSymbolClosingPrice.TabIndex = 22;
            this.ui_lblSymbolClosingPrice.Text = "Symbol Closing Price  :";
            this.ui_lblSymbolClosingPrice.Visible = false;
            // 
            // uctlClosingPriceChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlClosingPriceChild";
            this.Size = new System.Drawing.Size(331, 138);
            this.Load += new System.EventHandler(this.uctlClosingPriceChild_Load);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSymbolName;
        private System.Windows.Forms.Label ui_lblSymbolName;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClosingPrice;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbolClosingPrice;
        private System.Windows.Forms.Label ui_lblClosingDate;
        private System.Windows.Forms.Label ui_lblClosingPrice;
        private System.Windows.Forms.Label ui_lblSymbolClosingPrice;
        private Nevron.UI.WinForm.Controls.NButton nButton4;
        public Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpClosingDate;
    }
}
