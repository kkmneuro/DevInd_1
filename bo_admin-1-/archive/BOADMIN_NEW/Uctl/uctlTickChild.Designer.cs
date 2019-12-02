namespace BOADMIN_NEW.Uctl
{
    partial class uctlTickChild
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
            this.nButton7 = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ndtpDate = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.ui_lblDate = new System.Windows.Forms.Label();
            this.ui_lblClose = new System.Windows.Forms.Label();
            this.ui_ntxtClose = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblVolume = new System.Windows.Forms.Label();
            this.ui_ntxtVolume = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblLow = new System.Windows.Forms.Label();
            this.ui_ntxtLow = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblHigh = new System.Windows.Forms.Label();
            this.ui_ntxtHigh = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblOpen = new System.Windows.Forms.Label();
            this.ui_ntxtOpen = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_npnlControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.nButton7);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlControlContainer.Controls.Add(this.ui_nbtnOk);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ndtpDate);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblDate);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblClose);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtClose);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblVolume);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtVolume);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblLow);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtLow);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblHigh);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtHigh);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblOpen);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtOpen);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(640, 110);
            this.ui_npnlControlContainer.TabIndex = 0;
            // 
            // nButton7
            // 
            this.nButton7.Image = global::BOADMIN_NEW.Properties.Resources.downarrow;
            this.nButton7.Location = new System.Drawing.Point(191, 11);
            this.nButton7.Name = "nButton7";
            this.nButton7.Size = new System.Drawing.Size(20, 21);
            this.nButton7.TabIndex = 131;
            this.nButton7.UseVisualStyleBackColor = false;
            this.nButton7.Click += new System.EventHandler(this.nButton7_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(543, 77);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 20);
            this.ui_nbtnCancel.TabIndex = 13;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(455, 77);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(75, 20);
            this.ui_nbtnOk.TabIndex = 12;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_ndtpDate
            // 
            this.ui_ndtpDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ui_ndtpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ui_ndtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ui_ndtpDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ui_ndtpDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ui_ndtpDate.CustomFormat = "dd/MM/yyyy hh:MM:ss";
            this.ui_ndtpDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.ui_ndtpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ui_ndtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ui_ndtpDate.Location = new System.Drawing.Point(69, 11);
            this.ui_ndtpDate.Name = "ui_ndtpDate";
            this.ui_ndtpDate.Size = new System.Drawing.Size(142, 21);
            this.ui_ndtpDate.TabIndex = 11;
            // 
            // ui_lblDate
            // 
            this.ui_lblDate.AutoSize = true;
            this.ui_lblDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDate.Location = new System.Drawing.Point(26, 15);
            this.ui_lblDate.Name = "ui_lblDate";
            this.ui_lblDate.Size = new System.Drawing.Size(36, 13);
            this.ui_lblDate.TabIndex = 10;
            this.ui_lblDate.Text = "Date :";
            // 
            // ui_lblClose
            // 
            this.ui_lblClose.AutoSize = true;
            this.ui_lblClose.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClose.Location = new System.Drawing.Point(472, 45);
            this.ui_lblClose.Name = "ui_lblClose";
            this.ui_lblClose.Size = new System.Drawing.Size(39, 13);
            this.ui_lblClose.TabIndex = 9;
            this.ui_lblClose.Text = "Close :";
            // 
            // ui_ntxtClose
            // 
            this.ui_ntxtClose.Location = new System.Drawing.Point(518, 42);
            this.ui_ntxtClose.Name = "ui_ntxtClose";
            this.ui_ntxtClose.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtClose.TabIndex = 8;
            // 
            // ui_lblVolume
            // 
            this.ui_lblVolume.AutoSize = true;
            this.ui_lblVolume.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblVolume.Location = new System.Drawing.Point(463, 14);
            this.ui_lblVolume.Name = "ui_lblVolume";
            this.ui_lblVolume.Size = new System.Drawing.Size(48, 13);
            this.ui_lblVolume.TabIndex = 7;
            this.ui_lblVolume.Text = "Volume :";
            // 
            // ui_ntxtVolume
            // 
            this.ui_ntxtVolume.Location = new System.Drawing.Point(518, 11);
            this.ui_ntxtVolume.Name = "ui_ntxtVolume";
            this.ui_ntxtVolume.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtVolume.TabIndex = 6;
            // 
            // ui_lblLow
            // 
            this.ui_lblLow.AutoSize = true;
            this.ui_lblLow.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLow.Location = new System.Drawing.Point(325, 45);
            this.ui_lblLow.Name = "ui_lblLow";
            this.ui_lblLow.Size = new System.Drawing.Size(33, 13);
            this.ui_lblLow.TabIndex = 5;
            this.ui_lblLow.Text = "Low :";
            // 
            // ui_ntxtLow
            // 
            this.ui_ntxtLow.Location = new System.Drawing.Point(365, 42);
            this.ui_ntxtLow.Name = "ui_ntxtLow";
            this.ui_ntxtLow.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtLow.TabIndex = 4;
            // 
            // ui_lblHigh
            // 
            this.ui_lblHigh.AutoSize = true;
            this.ui_lblHigh.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblHigh.Location = new System.Drawing.Point(176, 45);
            this.ui_lblHigh.Name = "ui_lblHigh";
            this.ui_lblHigh.Size = new System.Drawing.Size(35, 13);
            this.ui_lblHigh.TabIndex = 3;
            this.ui_lblHigh.Text = "High :";
            // 
            // ui_ntxtHigh
            // 
            this.ui_ntxtHigh.Location = new System.Drawing.Point(218, 42);
            this.ui_ntxtHigh.Name = "ui_ntxtHigh";
            this.ui_ntxtHigh.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtHigh.TabIndex = 2;
            // 
            // ui_lblOpen
            // 
            this.ui_lblOpen.AutoSize = true;
            this.ui_lblOpen.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOpen.Location = new System.Drawing.Point(23, 45);
            this.ui_lblOpen.Name = "ui_lblOpen";
            this.ui_lblOpen.Size = new System.Drawing.Size(39, 13);
            this.ui_lblOpen.TabIndex = 1;
            this.ui_lblOpen.Text = "Open :";
            // 
            // ui_ntxtOpen
            // 
            this.ui_ntxtOpen.Location = new System.Drawing.Point(69, 42);
            this.ui_ntxtOpen.Name = "ui_ntxtOpen";
            this.ui_ntxtOpen.Size = new System.Drawing.Size(100, 18);
            this.ui_ntxtOpen.TabIndex = 0;
            // 
            // uctlTickChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlTickChild";
            this.Size = new System.Drawing.Size(640, 110);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.Label ui_lblClose;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClose;
        private System.Windows.Forms.Label ui_lblVolume;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtVolume;
        private System.Windows.Forms.Label ui_lblLow;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtLow;
        private System.Windows.Forms.Label ui_lblHigh;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtHigh;
        private System.Windows.Forms.Label ui_lblOpen;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtOpen;
        private Nevron.UI.WinForm.Controls.NDateTimePicker ui_ndtpDate;
        private System.Windows.Forms.Label ui_lblDate;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NButton nButton7;
    }
}
