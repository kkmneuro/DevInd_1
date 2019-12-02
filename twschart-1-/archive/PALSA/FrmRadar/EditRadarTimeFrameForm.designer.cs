namespace PALSA.FrmRadar
{
    partial class EditRadarTimeFrameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRadarTimeFrameForm));
            this.cboPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblPeriodicity = new System.Windows.Forms.Label();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.m_ImgList3 = new System.Windows.Forms.ImageList(this.components);
            this.lblInterval = new System.Windows.Forms.Label();
            this.cboInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.SuspendLayout();
            // 
            // cboPeriodicity
            // 
            this.cboPeriodicity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Minute", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Hour", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Day", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Week", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboPeriodicity.ListProperties.ColumnOnLeft = false;
            this.cboPeriodicity.Location = new System.Drawing.Point(73, 9);
            this.cboPeriodicity.Name = "cboPeriodicity";
            this.cboPeriodicity.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboPeriodicity.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboPeriodicity.Size = new System.Drawing.Size(186, 22);
            this.cboPeriodicity.TabIndex = 0;
            this.cboPeriodicity.Text = "NComboBox1";
            this.cboPeriodicity.SelectedIndexChanged += new System.EventHandler(this.cboPeriodicity_SelectedIndexChanged);
            // 
            // lblPeriodicity
            // 
            this.lblPeriodicity.AutoSize = true;
            this.lblPeriodicity.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodicity.Location = new System.Drawing.Point(12, 9);
            this.lblPeriodicity.Name = "lblPeriodicity";
            this.lblPeriodicity.Size = new System.Drawing.Size(55, 13);
            this.lblPeriodicity.TabIndex = 20;
            this.lblPeriodicity.Text = "Periodicity";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(185, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.ButtonProperties.ShowFocusRect = false;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(104, 65);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.TransparentBackground = true;
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // m_ImgList3
            // 
            this.m_ImgList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImgList3.ImageStream")));
            this.m_ImgList3.TransparentColor = System.Drawing.Color.Fuchsia;
            this.m_ImgList3.Images.SetKeyName(0, "Bars.bmp");
            this.m_ImgList3.Images.SetKeyName(1, "PointAndFigure.bmp");
            this.m_ImgList3.Images.SetKeyName(2, "Renko.bmp");
            this.m_ImgList3.Images.SetKeyName(3, "ThreeLineBreak.bmp");
            this.m_ImgList3.Images.SetKeyName(4, "Candles.bmp");
            this.m_ImgList3.Images.SetKeyName(5, "CandleVolume.bmp");
            this.m_ImgList3.Images.SetKeyName(6, "EquiVolume.bmp");
            this.m_ImgList3.Images.SetKeyName(7, "EquiVolumeShadow.bmp");
            this.m_ImgList3.Images.SetKeyName(8, "Kagi.bmp");
            this.m_ImgList3.Images.SetKeyName(9, "Indicator.bmp");
            this.m_ImgList3.Images.SetKeyName(10, "Bands.bmp");
            this.m_ImgList3.Images.SetKeyName(11, "CustomIndicator.png");
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.ForeColor = System.Drawing.Color.Black;
            this.lblInterval.Location = new System.Drawing.Point(12, 39);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 16;
            this.lblInterval.Text = "Interval";
            // 
            // cboInterval
            // 
            this.cboInterval.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("5", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("10", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("20", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("30", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboInterval.ListProperties.ColumnOnLeft = false;
            this.cboInterval.Location = new System.Drawing.Point(73, 37);
            this.cboInterval.Name = "cboInterval";
            this.cboInterval.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboInterval.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboInterval.Size = new System.Drawing.Size(186, 20);
            this.cboInterval.TabIndex = 35;
            // 
            // EditRadarTimeFrameForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(283, 105);
            this.Controls.Add(this.cboInterval);
            this.Controls.Add(this.cboPeriodicity);
            this.Controls.Add(this.lblPeriodicity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblInterval);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRadarTimeFrameForm";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Time Frame";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Nevron.UI.WinForm.Controls.NComboBox cboPeriodicity;
        private System.Windows.Forms.Label lblPeriodicity;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnOk;
        internal System.Windows.Forms.ImageList m_ImgList3;
        private System.Windows.Forms.Label lblInterval;
        internal Nevron.UI.WinForm.Controls.NComboBox cboInterval;
    }
}