namespace CommonLibrary.UserControls
{
    partial class UctlMarketWatchCustomize
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
            this.ui_npnl = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncbAlertTriggerColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_lblAlertTriggerColor = new System.Windows.Forms.Label();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ncbDownTrendColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_ncbUpTrendColor = new Nevron.UI.WinForm.Controls.NColorButton();
            this.ui_lblDownTrendColor = new System.Windows.Forms.Label();
            this.ui_lblUpTrendColor = new System.Windows.Forms.Label();
            this.ui_npnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnl
            // 
            this.ui_npnl.Controls.Add(this.ui_ncbAlertTriggerColor);
            this.ui_npnl.Controls.Add(this.ui_lblAlertTriggerColor);
            this.ui_npnl.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnl.Controls.Add(this.ui_nbtnOk);
            this.ui_npnl.Controls.Add(this.ui_ncbDownTrendColor);
            this.ui_npnl.Controls.Add(this.ui_ncbUpTrendColor);
            this.ui_npnl.Controls.Add(this.ui_lblDownTrendColor);
            this.ui_npnl.Controls.Add(this.ui_lblUpTrendColor);
            this.ui_npnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnl.Location = new System.Drawing.Point(0, 0);
            this.ui_npnl.Name = "ui_npnl";
            this.ui_npnl.Size = new System.Drawing.Size(248, 140);
            this.ui_npnl.TabIndex = 0;
            this.ui_npnl.Text = "nuiPanel1";
            // 
            // ui_ncbAlertTriggerColor
            // 
            this.ui_ncbAlertTriggerColor.ArrowClickOptions = false;
            this.ui_ncbAlertTriggerColor.ArrowWidth = 14;
            this.ui_ncbAlertTriggerColor.Location = new System.Drawing.Point(116, 74);
            this.ui_ncbAlertTriggerColor.Name = "ui_ncbAlertTriggerColor";
            this.ui_ncbAlertTriggerColor.Size = new System.Drawing.Size(121, 23);
            this.ui_ncbAlertTriggerColor.TabIndex = 7;
            this.ui_ncbAlertTriggerColor.UseVisualStyleBackColor = false;
            // 
            // ui_lblAlertTriggerColor
            // 
            this.ui_lblAlertTriggerColor.AutoSize = true;
            this.ui_lblAlertTriggerColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAlertTriggerColor.Location = new System.Drawing.Point(9, 79);
            this.ui_lblAlertTriggerColor.Name = "ui_lblAlertTriggerColor";
            this.ui_lblAlertTriggerColor.Size = new System.Drawing.Size(100, 13);
            this.ui_lblAlertTriggerColor.TabIndex = 6;
            this.ui_lblAlertTriggerColor.Text = "Alert Trigger Color : ";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(139, 109);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(58, 23);
            this.ui_nbtnCancel.TabIndex = 5;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(55, 109);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(58, 23);
            this.ui_nbtnOk.TabIndex = 4;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_ncbDownTrendColor
            // 
            this.ui_ncbDownTrendColor.ArrowClickOptions = false;
            this.ui_ncbDownTrendColor.ArrowWidth = 14;
            this.ui_ncbDownTrendColor.Location = new System.Drawing.Point(116, 42);
            this.ui_ncbDownTrendColor.Name = "ui_ncbDownTrendColor";
            this.ui_ncbDownTrendColor.Size = new System.Drawing.Size(121, 23);
            this.ui_ncbDownTrendColor.TabIndex = 3;
            this.ui_ncbDownTrendColor.UseVisualStyleBackColor = false;
            // 
            // ui_ncbUpTrendColor
            // 
            this.ui_ncbUpTrendColor.ArrowClickOptions = false;
            this.ui_ncbUpTrendColor.ArrowWidth = 14;
            this.ui_ncbUpTrendColor.Location = new System.Drawing.Point(115, 11);
            this.ui_ncbUpTrendColor.Name = "ui_ncbUpTrendColor";
            this.ui_ncbUpTrendColor.Size = new System.Drawing.Size(121, 23);
            this.ui_ncbUpTrendColor.TabIndex = 2;
            this.ui_ncbUpTrendColor.UseVisualStyleBackColor = false;
            // 
            // ui_lblDownTrendColor
            // 
            this.ui_lblDownTrendColor.AutoSize = true;
            this.ui_lblDownTrendColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDownTrendColor.Location = new System.Drawing.Point(7, 47);
            this.ui_lblDownTrendColor.Name = "ui_lblDownTrendColor";
            this.ui_lblDownTrendColor.Size = new System.Drawing.Size(102, 13);
            this.ui_lblDownTrendColor.TabIndex = 1;
            this.ui_lblDownTrendColor.Text = "Down Trend Color : ";
            // 
            // ui_lblUpTrendColor
            // 
            this.ui_lblUpTrendColor.AutoSize = true;
            this.ui_lblUpTrendColor.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblUpTrendColor.Location = new System.Drawing.Point(21, 16);
            this.ui_lblUpTrendColor.Name = "ui_lblUpTrendColor";
            this.ui_lblUpTrendColor.Size = new System.Drawing.Size(88, 13);
            this.ui_lblUpTrendColor.TabIndex = 0;
            this.ui_lblUpTrendColor.Text = "Up Trend Color : ";
            // 
            // uctlMarketWatchCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnl);
            this.Name = "UctlMarketWatchCustomize";
            this.Size = new System.Drawing.Size(248, 140);
            this.Load += new System.EventHandler(this.uctlMarketWatchCustomize_Load);
            this.ui_npnl.ResumeLayout(false);
            this.ui_npnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnl;
        private System.Windows.Forms.Label ui_lblDownTrendColor;
        private System.Windows.Forms.Label ui_lblUpTrendColor;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbDownTrendColor;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbUpTrendColor;
        private Nevron.UI.WinForm.Controls.NColorButton ui_ncbAlertTriggerColor;
        private System.Windows.Forms.Label ui_lblAlertTriggerColor;
    }
}
