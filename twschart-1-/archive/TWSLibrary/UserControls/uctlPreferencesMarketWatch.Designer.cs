namespace CommonLibrary.UserControls
{
    partial class uctlPreferencesMarketWatch
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
            this.ui_nbtnRestoreDefault = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nlcPreferencesGeneral5 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nGrpClickMode = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_nrdbDoubleClick = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nrdbSingleClick = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nGrpExecutionMode = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.ui_nUDDefaultQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_nrdbShowOrderEntry = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nrdbDirectMarket = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_nChkEnableTradingOnMarketWatch = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nuiPanel1.SuspendLayout();
            this.ui_nGrpClickMode.SuspendLayout();
            this.ui_nGrpExecutionMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nUDDefaultQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_nbtnRestoreDefault);
            this.nuiPanel1.Controls.Add(this.ui_nlcPreferencesGeneral5);
            this.nuiPanel1.Controls.Add(this.ui_nGrpClickMode);
            this.nuiPanel1.Controls.Add(this.ui_nGrpExecutionMode);
            this.nuiPanel1.Controls.Add(this.ui_nChkEnableTradingOnMarketWatch);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(502, 336);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_nbtnRestoreDefault
            // 
            this.ui_nbtnRestoreDefault.Location = new System.Drawing.Point(398, 307);
            this.ui_nbtnRestoreDefault.Name = "ui_nbtnRestoreDefault";
            this.ui_nbtnRestoreDefault.Size = new System.Drawing.Size(95, 23);
            this.ui_nbtnRestoreDefault.TabIndex = 8;
            this.ui_nbtnRestoreDefault.Text = "Restore Default";
            this.ui_nbtnRestoreDefault.UseVisualStyleBackColor = false;
            this.ui_nbtnRestoreDefault.Click += new System.EventHandler(this.ui_nbtnRestoreDefault_Click);
            // 
            // ui_nlcPreferencesGeneral5
            // 
            this.ui_nlcPreferencesGeneral5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ui_nlcPreferencesGeneral5.Location = new System.Drawing.Point(7, 298);
            this.ui_nlcPreferencesGeneral5.Name = "ui_nlcPreferencesGeneral5";
            this.ui_nlcPreferencesGeneral5.Size = new System.Drawing.Size(487, 2);
            this.ui_nlcPreferencesGeneral5.Text = "On Event..Do";
            // 
            // ui_nGrpClickMode
            // 
            this.ui_nGrpClickMode.BackColor = System.Drawing.Color.Transparent;
            this.ui_nGrpClickMode.Controls.Add(this.ui_nrdbDoubleClick);
            this.ui_nGrpClickMode.Controls.Add(this.ui_nrdbSingleClick);
            this.ui_nGrpClickMode.Location = new System.Drawing.Point(18, 44);
            this.ui_nGrpClickMode.Name = "ui_nGrpClickMode";
            this.ui_nGrpClickMode.Size = new System.Drawing.Size(179, 67);
            this.ui_nGrpClickMode.TabIndex = 3;
            this.ui_nGrpClickMode.TabStop = false;
            this.ui_nGrpClickMode.Text = "Enable Order On";
            // 
            // ui_nrdbDoubleClick
            // 
            this.ui_nrdbDoubleClick.AutoSize = true;
            this.ui_nrdbDoubleClick.ButtonProperties.BorderOffset = 2;
            this.ui_nrdbDoubleClick.Location = new System.Drawing.Point(34, 43);
            this.ui_nrdbDoubleClick.Name = "ui_nrdbDoubleClick";
            this.ui_nrdbDoubleClick.Size = new System.Drawing.Size(85, 17);
            this.ui_nrdbDoubleClick.TabIndex = 2;
            this.ui_nrdbDoubleClick.Text = "Double Click";
            this.ui_nrdbDoubleClick.TransparentBackground = true;
            this.ui_nrdbDoubleClick.UseVisualStyleBackColor = false;
            // 
            // ui_nrdbSingleClick
            // 
            this.ui_nrdbSingleClick.AutoSize = true;
            this.ui_nrdbSingleClick.ButtonProperties.BorderOffset = 2;
            this.ui_nrdbSingleClick.Checked = true;
            this.ui_nrdbSingleClick.Location = new System.Drawing.Point(34, 19);
            this.ui_nrdbSingleClick.Name = "ui_nrdbSingleClick";
            this.ui_nrdbSingleClick.Size = new System.Drawing.Size(80, 17);
            this.ui_nrdbSingleClick.TabIndex = 1;
            this.ui_nrdbSingleClick.TabStop = true;
            this.ui_nrdbSingleClick.Text = "Single Click";
            this.ui_nrdbSingleClick.TransparentBackground = true;
            this.ui_nrdbSingleClick.UseVisualStyleBackColor = false;
            // 
            // ui_nGrpExecutionMode
            // 
            this.ui_nGrpExecutionMode.BackColor = System.Drawing.Color.Transparent;
            this.ui_nGrpExecutionMode.Controls.Add(this.ui_nUDDefaultQuantity);
            this.ui_nGrpExecutionMode.Controls.Add(this.label1);
            this.ui_nGrpExecutionMode.Controls.Add(this.ui_nrdbShowOrderEntry);
            this.ui_nGrpExecutionMode.Controls.Add(this.ui_nrdbDirectMarket);
            this.ui_nGrpExecutionMode.Location = new System.Drawing.Point(18, 117);
            this.ui_nGrpExecutionMode.Name = "ui_nGrpExecutionMode";
            this.ui_nGrpExecutionMode.Size = new System.Drawing.Size(358, 67);
            this.ui_nGrpExecutionMode.TabIndex = 2;
            this.ui_nGrpExecutionMode.TabStop = false;
            this.ui_nGrpExecutionMode.Text = "Order Execution Mode";
            // 
            // ui_nUDDefaultQuantity
            // 
            this.ui_nUDDefaultQuantity.Location = new System.Drawing.Point(281, 19);
            this.ui_nUDDefaultQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ui_nUDDefaultQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ui_nUDDefaultQuantity.Name = "ui_nUDDefaultQuantity";
            this.ui_nUDDefaultQuantity.Size = new System.Drawing.Size(59, 20);
            this.ui_nUDDefaultQuantity.TabIndex = 5;
            this.ui_nUDDefaultQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(185, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Default Quantity :";
            // 
            // ui_nrdbShowOrderEntry
            // 
            this.ui_nrdbShowOrderEntry.AutoSize = true;
            this.ui_nrdbShowOrderEntry.ButtonProperties.BorderOffset = 2;
            this.ui_nrdbShowOrderEntry.Checked = true;
            this.ui_nrdbShowOrderEntry.Location = new System.Drawing.Point(34, 43);
            this.ui_nrdbShowOrderEntry.Name = "ui_nrdbShowOrderEntry";
            this.ui_nrdbShowOrderEntry.Size = new System.Drawing.Size(108, 17);
            this.ui_nrdbShowOrderEntry.TabIndex = 2;
            this.ui_nrdbShowOrderEntry.TabStop = true;
            this.ui_nrdbShowOrderEntry.Text = "Show Order Entry";
            this.ui_nrdbShowOrderEntry.TransparentBackground = true;
            this.ui_nrdbShowOrderEntry.UseVisualStyleBackColor = false;
            // 
            // ui_nrdbDirectMarket
            // 
            this.ui_nrdbDirectMarket.AutoSize = true;
            this.ui_nrdbDirectMarket.ButtonProperties.BorderOffset = 2;
            this.ui_nrdbDirectMarket.Location = new System.Drawing.Point(34, 19);
            this.ui_nrdbDirectMarket.Name = "ui_nrdbDirectMarket";
            this.ui_nrdbDirectMarket.Size = new System.Drawing.Size(139, 17);
            this.ui_nrdbDirectMarket.TabIndex = 1;
            this.ui_nrdbDirectMarket.Text = "Direct Market Execution";
            this.ui_nrdbDirectMarket.TransparentBackground = true;
            this.ui_nrdbDirectMarket.UseVisualStyleBackColor = false;
            // 
            // ui_nChkEnableTradingOnMarketWatch
            // 
            this.ui_nChkEnableTradingOnMarketWatch.AutoSize = true;
            this.ui_nChkEnableTradingOnMarketWatch.ButtonProperties.BorderOffset = 2;
            this.ui_nChkEnableTradingOnMarketWatch.Checked = true;
            this.ui_nChkEnableTradingOnMarketWatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_nChkEnableTradingOnMarketWatch.Location = new System.Drawing.Point(24, 16);
            this.ui_nChkEnableTradingOnMarketWatch.Name = "ui_nChkEnableTradingOnMarketWatch";
            this.ui_nChkEnableTradingOnMarketWatch.Size = new System.Drawing.Size(179, 18);
            this.ui_nChkEnableTradingOnMarketWatch.TabIndex = 0;
            this.ui_nChkEnableTradingOnMarketWatch.Text = "EnableTradingOnMarketWatch";
            this.ui_nChkEnableTradingOnMarketWatch.TransparentBackground = true;
            this.ui_nChkEnableTradingOnMarketWatch.UseCompatibleTextRendering = true;
            this.ui_nChkEnableTradingOnMarketWatch.UseVisualStyleBackColor = false;
            this.ui_nChkEnableTradingOnMarketWatch.CheckedChanged += new System.EventHandler(this.ui_nChkEnableTradingOnMarketWatch_CheckedChanged);
            // 
            // uctlPreferencesMarketWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlPreferencesMarketWatch";
            this.Size = new System.Drawing.Size(502, 336);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ui_nGrpClickMode.ResumeLayout(false);
            this.ui_nGrpClickMode.PerformLayout();
            this.ui_nGrpExecutionMode.ResumeLayout(false);
            this.ui_nGrpExecutionMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nUDDefaultQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_nGrpClickMode;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_nrdbDoubleClick;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_nrdbSingleClick;
        private Nevron.UI.WinForm.Controls.NGroupBox ui_nGrpExecutionMode;
        private System.Windows.Forms.NumericUpDown ui_nUDDefaultQuantity;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_nrdbShowOrderEntry;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_nrdbDirectMarket;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_nChkEnableTradingOnMarketWatch;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRestoreDefault;
        private Nevron.UI.WinForm.Controls.NLineControl ui_nlcPreferencesGeneral5;
    }
}
