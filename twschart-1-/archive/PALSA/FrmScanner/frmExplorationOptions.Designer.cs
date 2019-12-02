namespace PALSA.FrmScanner
{
    partial class frmExplorationOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExplorationOptions));
            this.gbDate = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.rbSpecificDate = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbRecentDate = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.dtpSpecificdate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.gbPeriodicity = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.cbTick = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblTimeUnit = new System.Windows.Forms.Label();
            this.rbWeekly = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbYearly = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbQuarterly = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbMonthly = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbIntraDay = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbDaily = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.gbDate.SuspendLayout();
            this.gbPeriodicity.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.lblDate);
            this.gbDate.Controls.Add(this.rbSpecificDate);
            this.gbDate.Controls.Add(this.rbRecentDate);
            this.gbDate.Controls.Add(this.dtpSpecificdate);
            this.gbDate.Location = new System.Drawing.Point(12, 12);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(303, 81);
            this.gbDate.TabIndex = 0;
            this.gbDate.TabStop = false;
            this.gbDate.Text = "Exploration Date";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Enabled = false;
            this.lblDate.Location = new System.Drawing.Point(118, 46);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // rbSpecificDate
            // 
            this.rbSpecificDate.AutoSize = true;
            this.rbSpecificDate.ButtonProperties.BorderOffset = 2;
            this.rbSpecificDate.Location = new System.Drawing.Point(23, 46);
            this.rbSpecificDate.Name = "rbSpecificDate";
            this.rbSpecificDate.Size = new System.Drawing.Size(89, 17);
            this.rbSpecificDate.TabIndex = 1;
            this.rbSpecificDate.Text = "Specific Date";
            this.rbSpecificDate.CheckedChanged += new System.EventHandler(this.rbSpecificDate_CheckedChanged);
            // 
            // rbRecentDate
            // 
            this.rbRecentDate.AutoSize = true;
            this.rbRecentDate.ButtonProperties.BorderOffset = 2;
            this.rbRecentDate.Checked = true;
            this.rbRecentDate.Location = new System.Drawing.Point(23, 23);
            this.rbRecentDate.Name = "rbRecentDate";
            this.rbRecentDate.Size = new System.Drawing.Size(112, 17);
            this.rbRecentDate.TabIndex = 0;
            this.rbRecentDate.TabStop = true;
            this.rbRecentDate.Text = "Most Recent Date";
            // 
            // dtpSpecificdate
            // 
            this.dtpSpecificdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dtpSpecificdate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpSpecificdate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtpSpecificdate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dtpSpecificdate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dtpSpecificdate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.dtpSpecificdate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpSpecificdate.Enabled = false;
            this.dtpSpecificdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpSpecificdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSpecificdate.Location = new System.Drawing.Point(157, 42);
            this.dtpSpecificdate.Name = "dtpSpecificdate";
            this.dtpSpecificdate.Size = new System.Drawing.Size(128, 21);
            this.dtpSpecificdate.TabIndex = 2;
            // 
            // gbPeriodicity
            // 
            this.gbPeriodicity.Controls.Add(this.cbTick);
            this.gbPeriodicity.Controls.Add(this.lblTimeUnit);
            this.gbPeriodicity.Controls.Add(this.rbWeekly);
            this.gbPeriodicity.Controls.Add(this.rbYearly);
            this.gbPeriodicity.Controls.Add(this.rbQuarterly);
            this.gbPeriodicity.Controls.Add(this.rbMonthly);
            this.gbPeriodicity.Controls.Add(this.rbIntraDay);
            this.gbPeriodicity.Controls.Add(this.rbDaily);
            this.gbPeriodicity.Location = new System.Drawing.Point(12, 99);
            this.gbPeriodicity.Name = "gbPeriodicity";
            this.gbPeriodicity.Size = new System.Drawing.Size(303, 164);
            this.gbPeriodicity.TabIndex = 1;
            this.gbPeriodicity.TabStop = false;
            this.gbPeriodicity.Text = "Exploration Periodicity";
            // 
            // cbTick
            // 
            this.cbTick.Editable = true;
            this.cbTick.Enabled = false;
            this.cbTick.InteractiveBorder = true;
            this.cbTick.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Tick", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("5", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("10", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("30", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("60", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("120", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("300", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("600", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cbTick.Location = new System.Drawing.Point(103, 19);
            this.cbTick.Name = "cbTick";
            this.cbTick.Size = new System.Drawing.Size(48, 22);
            this.cbTick.TabIndex = 7;
            this.cbTick.Text = "Tick";
            // 
            // lblTimeUnit
            // 
            this.lblTimeUnit.AutoSize = true;
            this.lblTimeUnit.Location = new System.Drawing.Point(157, 24);
            this.lblTimeUnit.Name = "lblTimeUnit";
            this.lblTimeUnit.Size = new System.Drawing.Size(39, 13);
            this.lblTimeUnit.TabIndex = 6;
            this.lblTimeUnit.Text = "Minute";
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.ButtonProperties.BorderOffset = 2;
            this.rbWeekly.Location = new System.Drawing.Point(23, 70);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(61, 17);
            this.rbWeekly.TabIndex = 2;
            this.rbWeekly.Text = "Weekly";
            // 
            // rbYearly
            // 
            this.rbYearly.AutoSize = true;
            this.rbYearly.ButtonProperties.BorderOffset = 2;
            this.rbYearly.Location = new System.Drawing.Point(23, 139);
            this.rbYearly.Name = "rbYearly";
            this.rbYearly.Size = new System.Drawing.Size(54, 17);
            this.rbYearly.TabIndex = 5;
            this.rbYearly.Text = "Yearly";
            // 
            // rbQuarterly
            // 
            this.rbQuarterly.AutoSize = true;
            this.rbQuarterly.ButtonProperties.BorderOffset = 2;
            this.rbQuarterly.Location = new System.Drawing.Point(23, 116);
            this.rbQuarterly.Name = "rbQuarterly";
            this.rbQuarterly.Size = new System.Drawing.Size(67, 17);
            this.rbQuarterly.TabIndex = 4;
            this.rbQuarterly.Text = "Quarterly";
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.ButtonProperties.BorderOffset = 2;
            this.rbMonthly.Location = new System.Drawing.Point(23, 93);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rbMonthly.TabIndex = 3;
            this.rbMonthly.Text = "Monthly";
            // 
            // rbIntraDay
            // 
            this.rbIntraDay.AutoSize = true;
            this.rbIntraDay.ButtonProperties.BorderOffset = 2;
            this.rbIntraDay.Location = new System.Drawing.Point(23, 24);
            this.rbIntraDay.Name = "rbIntraDay";
            this.rbIntraDay.Size = new System.Drawing.Size(63, 17);
            this.rbIntraDay.TabIndex = 1;
            this.rbIntraDay.Text = "Intraday";
            this.rbIntraDay.CheckedChanged += new System.EventHandler(this.rbIntraDay_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.ButtonProperties.BorderOffset = 2;
            this.rbDaily.Checked = true;
            this.rbDaily.Location = new System.Drawing.Point(23, 47);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(48, 17);
            this.rbDaily.TabIndex = 0;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            // 
            // nCheckBox1
            // 
            this.nCheckBox1.AutoSize = true;
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Checked = true;
            this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nCheckBox1.Location = new System.Drawing.Point(12, 269);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(70, 17);
            this.nCheckBox1.TabIndex = 6;
            this.nCheckBox1.Text = "Use Filter";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(324, 29);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(324, 123);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmExplorationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 303);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nCheckBox1);
            this.Controls.Add(this.gbPeriodicity);
            this.Controls.Add(this.gbDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExplorationOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exploration Options";
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbPeriodicity.ResumeLayout(false);
            this.gbPeriodicity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGroupBox gbDate;
        private Nevron.UI.WinForm.Controls.NRadioButton rbSpecificDate;
        private Nevron.UI.WinForm.Controls.NRadioButton rbRecentDate;
        private Nevron.UI.WinForm.Controls.NGroupBox gbPeriodicity;
        private Nevron.UI.WinForm.Controls.NRadioButton rbWeekly;
        private Nevron.UI.WinForm.Controls.NRadioButton rbIntraDay;
        private Nevron.UI.WinForm.Controls.NRadioButton rbDaily;
        private Nevron.UI.WinForm.Controls.NRadioButton rbMonthly;
        private Nevron.UI.WinForm.Controls.NRadioButton rbQuarterly;
        private Nevron.UI.WinForm.Controls.NRadioButton rbYearly;
        private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnHelp;
        private Nevron.UI.WinForm.Controls.NDateTimePicker dtpSpecificdate;
        private System.Windows.Forms.Label lblDate;
        private Nevron.UI.WinForm.Controls.NComboBox cbTick;
        private System.Windows.Forms.Label lblTimeUnit;

    }
}