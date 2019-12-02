namespace BOADMIN_NEW.Uctl
{
    partial class uctlHolidays
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
            this.ui_chkEveryYear = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.ui_btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_txtDescription = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_cmbSymbol = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_chkEnable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.ui_txtTo = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_txtTimeFrom = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.lblTime2 = new System.Windows.Forms.Label();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.ui_ndtpDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.Button2 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnDate = new Nevron.UI.WinForm.Controls.NButton();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_btnDate);
            this.nuiPanel1.Controls.Add(this.ui_chkEveryYear);
            this.nuiPanel1.Controls.Add(this.lblContent);
            this.nuiPanel1.Controls.Add(this.ui_btnCancel);
            this.nuiPanel1.Controls.Add(this.ui_btnOk);
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_txtDescription);
            this.nuiPanel1.Controls.Add(this.ui_cmbSymbol);
            this.nuiPanel1.Controls.Add(this.ui_chkEnable);
            this.nuiPanel1.Controls.Add(this.lblDescription);
            this.nuiPanel1.Controls.Add(this.lblSymbol);
            this.nuiPanel1.Controls.Add(this.ui_txtTo);
            this.nuiPanel1.Controls.Add(this.ui_txtTimeFrom);
            this.nuiPanel1.Controls.Add(this.lblTime2);
            this.nuiPanel1.Controls.Add(this.lblTime1);
            this.nuiPanel1.Controls.Add(this.lblDate);
            this.nuiPanel1.Controls.Add(this.ui_ndtpDate);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(589, 226);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_chkEveryYear
            // 
            this.ui_chkEveryYear.AutoSize = true;
            this.ui_chkEveryYear.ButtonProperties.BorderOffset = 2;
            this.ui_chkEveryYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_chkEveryYear.Location = new System.Drawing.Point(190, 78);
            this.ui_chkEveryYear.Name = "ui_chkEveryYear";
            this.ui_chkEveryYear.Size = new System.Drawing.Size(89, 17);
            this.ui_chkEveryYear.TabIndex = 39;
            this.ui_chkEveryYear.TabStop = false;
            this.ui_chkEveryYear.Text = "Every Year";
            this.ui_chkEveryYear.TransparentBackground = true;
            this.ui_chkEveryYear.UseVisualStyleBackColor = false;
            this.ui_chkEveryYear.CheckedChanged += new System.EventHandler(this.ui_chkEveryYear_CheckedChanged);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(5, 9);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(570, 26);
            this.lblContent.TabIndex = 36;
            this.lblContent.Text = "Holidays are used for restriction of trading time for symbols. You can set the da" +
                "te of a holiday and\r\nrange of working hours for any symbols";
            // 
            // ui_btnCancel
            // 
            this.ui_btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btnCancel.Location = new System.Drawing.Point(504, 189);
            this.ui_btnCancel.Name = "ui_btnCancel";
            this.ui_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_btnCancel.TabIndex = 6;
            this.ui_btnCancel.Text = "&Cancel";
            this.ui_btnCancel.UseVisualStyleBackColor = false;
            this.ui_btnCancel.Click += new System.EventHandler(this.ui_btnCancel_Click);
            // 
            // ui_btnOk
            // 
            this.ui_btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_btnOk.Location = new System.Drawing.Point(418, 189);
            this.ui_btnOk.Name = "ui_btnOk";
            this.ui_btnOk.Size = new System.Drawing.Size(75, 23);
            this.ui_btnOk.TabIndex = 5;
            this.ui_btnOk.Text = "&OK";
            this.ui_btnOk.UseVisualStyleBackColor = false;
            this.ui_btnOk.Click += new System.EventHandler(this.ui_btnOk_Click);
            // 
            // nLineControl1
            // 
            this.nLineControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nLineControl1.Location = new System.Drawing.Point(10, 175);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(573, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_txtDescription
            // 
            this.ui_txtDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtDescription.Location = new System.Drawing.Point(96, 141);
            this.ui_txtDescription.MaxLength = 256;
            this.ui_txtDescription.Name = "ui_txtDescription";
            this.ui_txtDescription.Size = new System.Drawing.Size(483, 19);
            this.ui_txtDescription.TabIndex = 4;
            // 
            // ui_cmbSymbol
            // 
            this.ui_cmbSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ui_cmbSymbol.ListProperties.ColumnOnLeft = false;
            this.ui_cmbSymbol.Location = new System.Drawing.Point(96, 110);
            this.ui_cmbSymbol.Name = "ui_cmbSymbol";
            this.ui_cmbSymbol.Size = new System.Drawing.Size(483, 18);
            this.ui_cmbSymbol.TabIndex = 3;
            this.ui_cmbSymbol.TooltipInfo.ContentText = "Select Symbol Name";
            this.ui_cmbSymbol.TooltipInfo.InitialDelay = 300;
            // 
            // ui_chkEnable
            // 
            this.ui_chkEnable.AutoSize = true;
            this.ui_chkEnable.ButtonProperties.BorderOffset = 2;
            this.ui_chkEnable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_chkEnable.Location = new System.Drawing.Point(96, 48);
            this.ui_chkEnable.Name = "ui_chkEnable";
            this.ui_chkEnable.Size = new System.Drawing.Size(64, 17);
            this.ui_chkEnable.TabIndex = 31;
            this.ui_chkEnable.TabStop = false;
            this.ui_chkEnable.Text = "Enable";
            this.ui_chkEnable.TransparentBackground = true;
            this.ui_chkEnable.UseVisualStyleBackColor = false;
            this.ui_chkEnable.Click += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(13, 144);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 13);
            this.lblDescription.TabIndex = 30;
            this.lblDescription.Text = "Description :";
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.BackColor = System.Drawing.Color.Transparent;
            this.lblSymbol.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbol.Location = new System.Drawing.Point(34, 110);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(59, 13);
            this.lblSymbol.TabIndex = 29;
            this.lblSymbol.Text = "Symbol :";
            // 
            // ui_txtTo
            // 
            this.ui_txtTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_txtTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_txtTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_txtTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_txtTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_txtTo.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_txtTo.CustomFormat = "HH:mm";
            this.ui_txtTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_txtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_txtTo.Location = new System.Drawing.Point(487, 76);
            this.ui_txtTo.Name = "ui_txtTo";
            this.ui_txtTo.ShowUpDown = true;
            this.ui_txtTo.Size = new System.Drawing.Size(92, 22);
            this.ui_txtTo.TabIndex = 2;
            this.ui_txtTo.Value = new System.DateTime(2011, 3, 2, 0, 0, 0, 0);
            // 
            // ui_txtTimeFrom
            // 
            this.ui_txtTimeFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_txtTimeFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_txtTimeFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_txtTimeFrom.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_txtTimeFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_txtTimeFrom.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_txtTimeFrom.CustomFormat = "HH:mm";
            this.ui_txtTimeFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_txtTimeFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_txtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_txtTimeFrom.Location = new System.Drawing.Point(375, 76);
            this.ui_txtTimeFrom.Name = "ui_txtTimeFrom";
            this.ui_txtTimeFrom.ShowUpDown = true;
            this.ui_txtTimeFrom.Size = new System.Drawing.Size(91, 22);
            this.ui_txtTimeFrom.TabIndex = 1;
            this.ui_txtTimeFrom.Value = new System.DateTime(2011, 3, 2, 0, 0, 0, 0);
            // 
            // lblTime2
            // 
            this.lblTime2.AutoSize = true;
            this.lblTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblTime2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime2.Location = new System.Drawing.Point(465, 80);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(30, 13);
            this.lblTime2.TabIndex = 26;
            this.lblTime2.Text = "To :";
            // 
            // lblTime1
            // 
            this.lblTime1.AutoSize = true;
            this.lblTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblTime1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(277, 80);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(111, 13);
            this.lblTime1.TabIndex = 25;
            this.lblTime1.Text = "Work Time From :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(50, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 13);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date :";
            // 
            // ui_ndtpDate
            // 
            this.ui_ndtpDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpDate.CustomFormat = "dd/MM/yyyy";
            this.ui_ndtpDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ndtpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpDate.Location = new System.Drawing.Point(96, 76);
            this.ui_ndtpDate.Name = "ui_ndtpDate";
            this.ui_ndtpDate.Size = new System.Drawing.Size(86, 22);
            this.ui_ndtpDate.TabIndex = 0;
            this.ui_ndtpDate.Value = new System.DateTime(2012, 10, 4, 0, 0, 0, 0);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(303, 185);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 35;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = false;
            // 
            // ui_btnDate
            // 
            this.ui_btnDate.Image = global::BOADMIN_NEW.Properties.Resources.downarrow;
            this.ui_btnDate.Location = new System.Drawing.Point(164, 76);
            this.ui_btnDate.Name = "ui_btnDate";
            this.ui_btnDate.Size = new System.Drawing.Size(20, 22);
            this.ui_btnDate.TabIndex = 41;
            this.ui_btnDate.UseVisualStyleBackColor = false;
            this.ui_btnDate.Click += new System.EventHandler(this.ui_btnDate_Click);
            // 
            // uctlHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlHolidays";
            this.Size = new System.Drawing.Size(589, 226);
            this.Load += new System.EventHandler(this.uctlHolidays_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lblContent;
        private Nevron.UI.WinForm.Controls.NButton ui_btnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_btnOk;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NTextBox ui_txtDescription;
        private Nevron.UI.WinForm.Controls.NComboBox ui_cmbSymbol;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_chkEnable;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSymbol;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_txtTimeFrom;
        private System.Windows.Forms.Label lblTime2;
        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpDate;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_chkEveryYear;
        private Nevron.UI.WinForm.Controls.NButton Button2;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_txtTo;
        private Nevron.UI.WinForm.Controls.NButton ui_btnDate;

    }
}
