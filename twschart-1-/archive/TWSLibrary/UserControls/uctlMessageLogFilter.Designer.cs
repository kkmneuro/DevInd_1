namespace CommonLibrary.UserControls
{
    partial class UctlMessageLogFilter
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
            this.ui_npnlMessageLogFilter = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpToTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpFromTime = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpToDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_ndtpFromDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblToTime = new System.Windows.Forms.Label();
            this.ui_lblFromTime = new System.Windows.Forms.Label();
            this.ui_nchkTimeRange = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_npnlMessageLogFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlMessageLogFilter
            // 
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_nbtnOK);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_ndtpToTime);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_ndtpFromTime);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_ndtpToDate);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_ndtpFromDate);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_lblToTime);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_lblFromTime);
            this.ui_npnlMessageLogFilter.Controls.Add(this.ui_nchkTimeRange);
            this.ui_npnlMessageLogFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlMessageLogFilter.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlMessageLogFilter.Name = "ui_npnlMessageLogFilter";
            this.ui_npnlMessageLogFilter.Size = new System.Drawing.Size(208, 165);
            this.ui_npnlMessageLogFilter.TabIndex = 0;
            this.ui_npnlMessageLogFilter.Text = "nuiPanel1";
            this.ui_npnlMessageLogFilter.Click += new System.EventHandler(this.ui_npnlMessageLogFilter_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(109, 126);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(89, 23);
            this.ui_nbtnCancel.TabIndex = 6;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(8, 126);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(89, 23);
            this.ui_nbtnOK.TabIndex = 5;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_ndtpToTime
            // 
            this.ui_ndtpToTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpToTime.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpToTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpToTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpToTime.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpToTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ui_ndtpToTime.Location = new System.Drawing.Point(109, 92);
            this.ui_ndtpToTime.Name = "ui_ndtpToTime";
            this.ui_ndtpToTime.ShowUpDown = true;
            this.ui_ndtpToTime.Size = new System.Drawing.Size(89, 21);
            this.ui_ndtpToTime.Value = new System.DateTime(2012, 3, 30, 0, 0, 0, 0);
            this.ui_ndtpToTime.TabIndex = 4;
            // 
            // ui_ndtpFromTime
            // 
            this.ui_ndtpFromTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpFromTime.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpFromTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpFromTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpFromTime.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpFromTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ui_ndtpFromTime.Location = new System.Drawing.Point(109, 50);
            this.ui_ndtpFromTime.Name = "ui_ndtpFromTime";
            this.ui_ndtpFromTime.ShowUpDown = true;
            this.ui_ndtpFromTime.Size = new System.Drawing.Size(89, 21);
            this.ui_ndtpFromTime.TabIndex = 2;
            this.ui_ndtpFromTime.Value = new System.DateTime(2012, 3, 30, 0, 0, 0, 0);
            // 
            // ui_ndtpToDate
            // 
            this.ui_ndtpToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpToDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpToDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpToDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpToDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpToDate.CustomFormat = "dd/MM/yyyy";
            this.ui_ndtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpToDate.Location = new System.Drawing.Point(8, 92);
            this.ui_ndtpToDate.Name = "ui_ndtpToDate";
            this.ui_ndtpToDate.Size = new System.Drawing.Size(89, 21);
            this.ui_ndtpToDate.TabIndex = 3;
            // 
            // ui_ndtpFromDate
            // 
            this.ui_ndtpFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpFromDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpFromDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpFromDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpFromDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.ui_ndtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpFromDate.Location = new System.Drawing.Point(8, 50);
            this.ui_ndtpFromDate.Name = "ui_ndtpFromDate";
            this.ui_ndtpFromDate.Size = new System.Drawing.Size(89, 21);
            this.ui_ndtpFromDate.TabIndex = 1;
            // 
            // ui_lblToTime
            // 
            this.ui_lblToTime.AutoSize = true;
            this.ui_lblToTime.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblToTime.Location = new System.Drawing.Point(8, 75);
            this.ui_lblToTime.Name = "ui_lblToTime";
            this.ui_lblToTime.Size = new System.Drawing.Size(52, 13);
            this.ui_lblToTime.TabIndex = 2;
            this.ui_lblToTime.Text = "To Time :";
            // 
            // ui_lblFromTime
            // 
            this.ui_lblFromTime.AutoSize = true;
            this.ui_lblFromTime.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFromTime.Location = new System.Drawing.Point(8, 34);
            this.ui_lblFromTime.Name = "ui_lblFromTime";
            this.ui_lblFromTime.Size = new System.Drawing.Size(62, 13);
            this.ui_lblFromTime.TabIndex = 1;
            this.ui_lblFromTime.Text = "From Time :";
            // 
            // ui_nchkTimeRange
            // 
            this.ui_nchkTimeRange.AutoSize = true;
            this.ui_nchkTimeRange.ButtonProperties.BorderOffset = 2;
            this.ui_nchkTimeRange.Location = new System.Drawing.Point(11, 8);
            this.ui_nchkTimeRange.Name = "ui_nchkTimeRange";
            this.ui_nchkTimeRange.Size = new System.Drawing.Size(90, 17);
            this.ui_nchkTimeRange.TabIndex = 0;
            this.ui_nchkTimeRange.Text = "Time Range :";
            this.ui_nchkTimeRange.TransparentBackground = true;
            this.ui_nchkTimeRange.UseVisualStyleBackColor = false;
            // 
            // uctlMessageLogFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlMessageLogFilter);
            this.Name = "UctlMessageLogFilter";
            this.Size = new System.Drawing.Size(208, 165);
            this.Load += new System.EventHandler(this.uctlMessageLogFilter_Load);
            this.ui_npnlMessageLogFilter.ResumeLayout(false);
            this.ui_npnlMessageLogFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlMessageLogFilter;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkTimeRange;
        private System.Windows.Forms.Label ui_lblToTime;
        private System.Windows.Forms.Label ui_lblFromTime;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToDate;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromDate;
        public Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpToTime;
        public Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpFromTime;
    }
}
