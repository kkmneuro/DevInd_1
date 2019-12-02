namespace PALSA.uctl
{
    partial class ctlScannerExplorationEdit
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
            this.nudBarCount = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.cboInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.txtColumnName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.rbBuy = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.rbSell = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.btnSound = new Nevron.UI.WinForm.Controls.NButton();
            this.btnPlay = new Nevron.UI.WinForm.Controls.NButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCount)).BeginInit();
            this.SuspendLayout();
            // 
            // nudBarCount
            // 
            this.nudBarCount.Location = new System.Drawing.Point(263, 119);
            this.nudBarCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudBarCount.Name = "nudBarCount";
            this.nudBarCount.Size = new System.Drawing.Size(94, 20);
            this.nudBarCount.TabIndex = 170;
            this.nudBarCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Location = new System.Drawing.Point(260, 103);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(64, 13);
            this.Label8.TabIndex = 169;
            this.Label8.Text = "Bar History :";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Location = new System.Drawing.Point(132, 103);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(61, 13);
            this.Label7.TabIndex = 168;
            this.Label7.Text = "Periodicity :";
            // 
            // cboPeriodicity
            // 
            this.cboPeriodicity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Minute", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Hour", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Day", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Week", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Month", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboPeriodicity.ListProperties.ColumnOnLeft = false;
            this.cboPeriodicity.Location = new System.Drawing.Point(135, 119);
            this.cboPeriodicity.Name = "cboPeriodicity";
            this.cboPeriodicity.Size = new System.Drawing.Size(94, 20);
            this.cboPeriodicity.TabIndex = 167;
            this.cboPeriodicity.SelectedIndexChanged += new System.EventHandler(this.cboPeriodicity_SelectedIndexChanged);
            // 
            // cboInterval
            // 
            this.cboInterval.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("5", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("30", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboInterval.ListProperties.ColumnOnLeft = false;
            this.cboInterval.Location = new System.Drawing.Point(8, 119);
            this.cboInterval.Name = "cboInterval";
            this.cboInterval.Size = new System.Drawing.Size(94, 20);
            this.cboInterval.TabIndex = 166;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Location = new System.Drawing.Point(5, 104);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(67, 13);
            this.Label6.TabIndex = 165;
            this.Label6.Text = "Bar Interval :";
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(121, 6);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(417, 88);
            this.txtScript.TabIndex = 8;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            this.txtScript.Enter += new System.EventHandler(this.txtScript_Enter);
            this.txtScript.Leave += new System.EventHandler(this.txtScript_Leave);
            // 
            // txtColumnName
            // 
            this.txtColumnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnName.Location = new System.Drawing.Point(7, 76);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(111, 18);
            this.txtColumnName.TabIndex = 9;
            this.txtColumnName.Leave += new System.EventHandler(this.txtColumnName_Leave);
            // 
            // lblColumnName
            // 
            this.lblColumnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Location = new System.Drawing.Point(4, 60);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(56, 13);
            this.lblColumnName.TabIndex = 10;
            this.lblColumnName.Text = "Col.Name:";
            // 
            // rbBuy
            // 
            this.rbBuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBuy.AutoSize = true;
            this.rbBuy.ButtonProperties.BorderOffset = 2;
            this.rbBuy.Checked = true;
            this.rbBuy.Location = new System.Drawing.Point(7, 7);
            this.rbBuy.Name = "rbBuy";
            this.rbBuy.Size = new System.Drawing.Size(43, 17);
            this.rbBuy.TabIndex = 171;
            this.rbBuy.TabStop = true;
            this.rbBuy.Text = "Buy";
            // 
            // rbSell
            // 
            this.rbSell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSell.AutoSize = true;
            this.rbSell.ButtonProperties.BorderOffset = 2;
            this.rbSell.Location = new System.Drawing.Point(7, 30);
            this.rbSell.Name = "rbSell";
            this.rbSell.Size = new System.Drawing.Size(42, 17);
            this.rbSell.TabIndex = 172;
            this.rbSell.Text = "Sell";
            // 
            // btnSound
            // 
            this.btnSound.Location = new System.Drawing.Point(376, 104);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(106, 34);
            this.btnSound.TabIndex = 174;
            this.btnSound.Text = "Select Sound";
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(489, 104);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 34);
            this.btnPlay.TabIndex = 175;
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ctlScannerExplorationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.rbSell);
            this.Controls.Add(this.rbBuy);
            this.Controls.Add(this.nudBarCount);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.cboPeriodicity);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.cboInterval);
            this.Controls.Add(this.Label6);
            this.Name = "ctlScannerExplorationEdit";
            this.Size = new System.Drawing.Size(543, 145);
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NNumericUpDown nudBarCount;
        private Nevron.UI.WinForm.Controls.NTextBox txtScript;
        private Nevron.UI.WinForm.Controls.NTextBox txtColumnName;
        private System.Windows.Forms.Label lblColumnName;
        private Nevron.UI.WinForm.Controls.NRadioButton rbBuy;
        private Nevron.UI.WinForm.Controls.NRadioButton rbSell;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label6;
        private Nevron.UI.WinForm.Controls.NComboBox cboPeriodicity;
        private Nevron.UI.WinForm.Controls.NComboBox cboInterval;
        private Nevron.UI.WinForm.Controls.NButton btnSound;
        private Nevron.UI.WinForm.Controls.NButton btnPlay;

    }
}
