namespace BOADMIN_NEW.Uctl
{
    partial class uctlFeesMaster
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
            this.ui_npnlFeesMaster = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncmbLevyOn = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblLevyOn = new System.Windows.Forms.Label();
            this.ui_ncmbFeesMode = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblFeesMode = new System.Windows.Forms.Label();
            this.ui_ncmbInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ntxtChargesName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_nchkIsTaxable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_lblInterval = new System.Windows.Forms.Label();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtDescription = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtMaximumVolume = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtMinimumVolume = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblDescription = new System.Windows.Forms.Label();
            this.ui_lblMaximumValue = new System.Windows.Forms.Label();
            this.ui_lblMinimumValue = new System.Windows.Forms.Label();
            this.ui_lblCharges = new System.Windows.Forms.Label();
            this.ui_ncmbPerDay = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblDayInterval = new System.Windows.Forms.Label();
            this.ui_npnlFeesMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlFeesMaster
            // 
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ncmbPerDay);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblDayInterval);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ncmbLevyOn);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblLevyOn);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ncmbFeesMode);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblFeesMode);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ncmbInterval);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ntxtChargesName);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_nchkIsTaxable);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblInterval);
            this.ui_npnlFeesMaster.Controls.Add(this.nLineControl1);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_nbtnOK);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ntxtDescription);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ntxtMaximumVolume);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_ntxtMinimumVolume);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblDescription);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblMaximumValue);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblMinimumValue);
            this.ui_npnlFeesMaster.Controls.Add(this.ui_lblCharges);
            this.ui_npnlFeesMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlFeesMaster.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlFeesMaster.Name = "ui_npnlFeesMaster";
            this.ui_npnlFeesMaster.Size = new System.Drawing.Size(354, 285);
            this.ui_npnlFeesMaster.TabIndex = 0;
            this.ui_npnlFeesMaster.Text = "nuiPanel1";
            // 
            // ui_ncmbLevyOn
            // 
            this.ui_ncmbLevyOn.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Profit", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Trade", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbLevyOn.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbLevyOn.Location = new System.Drawing.Point(86, 145);
            this.ui_ncmbLevyOn.Name = "ui_ncmbLevyOn";
            this.ui_ncmbLevyOn.Size = new System.Drawing.Size(249, 19);
            this.ui_ncmbLevyOn.TabIndex = 32;
            // 
            // ui_lblLevyOn
            // 
            this.ui_lblLevyOn.AutoSize = true;
            this.ui_lblLevyOn.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLevyOn.Location = new System.Drawing.Point(18, 148);
            this.ui_lblLevyOn.Name = "ui_lblLevyOn";
            this.ui_lblLevyOn.Size = new System.Drawing.Size(53, 13);
            this.ui_lblLevyOn.TabIndex = 33;
            this.ui_lblLevyOn.Text = "Levy On :";
            // 
            // ui_ncmbFeesMode
            // 
            this.ui_ncmbFeesMode.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Percentage", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Fixed", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbFeesMode.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbFeesMode.Location = new System.Drawing.Point(86, 120);
            this.ui_ncmbFeesMode.Name = "ui_ncmbFeesMode";
            this.ui_ncmbFeesMode.Size = new System.Drawing.Size(249, 19);
            this.ui_ncmbFeesMode.TabIndex = 30;
            // 
            // ui_lblFeesMode
            // 
            this.ui_lblFeesMode.AutoSize = true;
            this.ui_lblFeesMode.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblFeesMode.Location = new System.Drawing.Point(18, 123);
            this.ui_lblFeesMode.Name = "ui_lblFeesMode";
            this.ui_lblFeesMode.Size = new System.Drawing.Size(66, 13);
            this.ui_lblFeesMode.TabIndex = 31;
            this.ui_lblFeesMode.Text = "Fees Mode :";
            // 
            // ui_ncmbInterval
            // 
            this.ui_ncmbInterval.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Per Volume", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Per Day", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Profit", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Trade", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Weekly", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Day", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbInterval.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbInterval.Location = new System.Drawing.Point(86, 167);
            this.ui_ncmbInterval.Name = "ui_ncmbInterval";
            this.ui_ncmbInterval.Size = new System.Drawing.Size(249, 19);
            this.ui_ncmbInterval.TabIndex = 4;
            this.ui_ncmbInterval.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbInterval_SelectedIndexChanged);
            // 
            // ui_ntxtChargesName
            // 
            this.ui_ntxtChargesName.Location = new System.Drawing.Point(86, 13);
            this.ui_ntxtChargesName.MaxLength = 50;
            this.ui_ntxtChargesName.Name = "ui_ntxtChargesName";
            this.ui_ntxtChargesName.Size = new System.Drawing.Size(249, 18);
            this.ui_ntxtChargesName.TabIndex = 0;
            // 
            // ui_nchkIsTaxable
            // 
            this.ui_nchkIsTaxable.AutoSize = true;
            this.ui_nchkIsTaxable.ButtonProperties.BorderOffset = 2;
            this.ui_nchkIsTaxable.Location = new System.Drawing.Point(90, 214);
            this.ui_nchkIsTaxable.Name = "ui_nchkIsTaxable";
            this.ui_nchkIsTaxable.Size = new System.Drawing.Size(75, 17);
            this.ui_nchkIsTaxable.TabIndex = 28;
            this.ui_nchkIsTaxable.TabStop = false;
            this.ui_nchkIsTaxable.Text = "Is Taxable";
            this.ui_nchkIsTaxable.TransparentBackground = true;
            this.ui_nchkIsTaxable.UseVisualStyleBackColor = false;
            // 
            // ui_lblInterval
            // 
            this.ui_lblInterval.AutoSize = true;
            this.ui_lblInterval.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblInterval.Location = new System.Drawing.Point(18, 170);
            this.ui_lblInterval.Name = "ui_lblInterval";
            this.ui_lblInterval.Size = new System.Drawing.Size(63, 13);
            this.ui_lblInterval.TabIndex = 20;
            this.ui_lblInterval.Text = "Interval      :";
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(17, 237);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(321, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(264, 248);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 6;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(182, 248);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOK.TabIndex = 5;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_ntxtDescription
            // 
            this.ui_ntxtDescription.Location = new System.Drawing.Point(86, 93);
            this.ui_ntxtDescription.MaxLength = 256;
            this.ui_ntxtDescription.Name = "ui_ntxtDescription";
            this.ui_ntxtDescription.Size = new System.Drawing.Size(249, 18);
            this.ui_ntxtDescription.TabIndex = 3;
            // 
            // ui_ntxtMaximumVolume
            // 
            this.ui_ntxtMaximumVolume.Location = new System.Drawing.Point(86, 67);
            this.ui_ntxtMaximumVolume.MaxLength = 18;
            this.ui_ntxtMaximumVolume.Name = "ui_ntxtMaximumVolume";
            this.ui_ntxtMaximumVolume.Size = new System.Drawing.Size(249, 18);
            this.ui_ntxtMaximumVolume.TabIndex = 2;
            this.ui_ntxtMaximumVolume.Leave += new System.EventHandler(this.ui_ntxtMaximumVolume_Leave);
            this.ui_ntxtMaximumVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtMaximumVolume_KeyPress);
            // 
            // ui_ntxtMinimumVolume
            // 
            this.ui_ntxtMinimumVolume.Location = new System.Drawing.Point(86, 41);
            this.ui_ntxtMinimumVolume.MaxLength = 18;
            this.ui_ntxtMinimumVolume.Name = "ui_ntxtMinimumVolume";
            this.ui_ntxtMinimumVolume.Size = new System.Drawing.Size(249, 18);
            this.ui_ntxtMinimumVolume.TabIndex = 1;
            this.ui_ntxtMinimumVolume.Leave += new System.EventHandler(this.ui_ntxtMinimumVolume_Leave);
            this.ui_ntxtMinimumVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtMinimumVolume_KeyPress);
            // 
            // ui_lblDescription
            // 
            this.ui_lblDescription.AutoSize = true;
            this.ui_lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDescription.Location = new System.Drawing.Point(18, 96);
            this.ui_lblDescription.Name = "ui_lblDescription";
            this.ui_lblDescription.Size = new System.Drawing.Size(66, 13);
            this.ui_lblDescription.TabIndex = 4;
            this.ui_lblDescription.Text = "Description :";
            // 
            // ui_lblMaximumValue
            // 
            this.ui_lblMaximumValue.AutoSize = true;
            this.ui_lblMaximumValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblMaximumValue.Location = new System.Drawing.Point(18, 70);
            this.ui_lblMaximumValue.Name = "ui_lblMaximumValue";
            this.ui_lblMaximumValue.Size = new System.Drawing.Size(66, 13);
            this.ui_lblMaximumValue.TabIndex = 2;
            this.ui_lblMaximumValue.Text = "Max. Value :";
            // 
            // ui_lblMinimumValue
            // 
            this.ui_lblMinimumValue.AutoSize = true;
            this.ui_lblMinimumValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblMinimumValue.Location = new System.Drawing.Point(18, 44);
            this.ui_lblMinimumValue.Name = "ui_lblMinimumValue";
            this.ui_lblMinimumValue.Size = new System.Drawing.Size(66, 13);
            this.ui_lblMinimumValue.TabIndex = 1;
            this.ui_lblMinimumValue.Text = "Min. Value  :";
            // 
            // ui_lblCharges
            // 
            this.ui_lblCharges.AutoSize = true;
            this.ui_lblCharges.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblCharges.Location = new System.Drawing.Point(18, 16);
            this.ui_lblCharges.Name = "ui_lblCharges";
            this.ui_lblCharges.Size = new System.Drawing.Size(64, 13);
            this.ui_lblCharges.TabIndex = 0;
            this.ui_lblCharges.Text = "Charges     :";
            // 
            // ui_ncmbPerDay
            // 
            this.ui_ncmbPerDay.Enabled = false;
            this.ui_ncmbPerDay.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Monday", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Tuesday", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("WednesDay", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Thursday", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Friday", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Saturday", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Sunday", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbPerDay.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbPerDay.Location = new System.Drawing.Point(86, 192);
            this.ui_ncmbPerDay.Name = "ui_ncmbPerDay";
            this.ui_ncmbPerDay.Size = new System.Drawing.Size(249, 19);
            this.ui_ncmbPerDay.TabIndex = 35;
            // 
            // ui_lblDayInterval
            // 
            this.ui_lblDayInterval.AutoSize = true;
            this.ui_lblDayInterval.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDayInterval.Location = new System.Drawing.Point(18, 195);
            this.ui_lblDayInterval.Name = "ui_lblDayInterval";
            this.ui_lblDayInterval.Size = new System.Drawing.Size(32, 13);
            this.ui_lblDayInterval.TabIndex = 36;
            this.ui_lblDayInterval.Text = "Day :";
            // 
            // uctlFeesMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlFeesMaster);
            this.Name = "uctlFeesMaster";
            this.Size = new System.Drawing.Size(354, 285);
            this.Load += new System.EventHandler(this.uctlFeesMaster_Load);
            this.ui_npnlFeesMaster.ResumeLayout(false);
            this.ui_npnlFeesMaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlFeesMaster;
        private System.Windows.Forms.Label ui_lblDescription;
        private System.Windows.Forms.Label ui_lblMaximumValue;
        private System.Windows.Forms.Label ui_lblMinimumValue;
        private System.Windows.Forms.Label ui_lblCharges;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtMaximumVolume;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtMinimumVolume;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtDescription;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private System.Windows.Forms.Label ui_lblInterval;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nchkIsTaxable;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtChargesName;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbInterval;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbLevyOn;
        private System.Windows.Forms.Label ui_lblLevyOn;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbFeesMode;
        private System.Windows.Forms.Label ui_lblFeesMode;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbPerDay;
        private System.Windows.Forms.Label ui_lblDayInterval;
    }
}
