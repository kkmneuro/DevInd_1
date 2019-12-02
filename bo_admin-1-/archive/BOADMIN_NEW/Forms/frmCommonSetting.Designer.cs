namespace BOADMIN_NEW.Forms
{
    partial class frmCommonSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommonSetting));
            this.uctlCommonSetting1 = new BOADMIN_NEW.Uctl.uctlCommonSetting();
            this.SuspendLayout();
            // 
            // uctlCommonSetting1
            // 
            this.uctlCommonSetting1.AutoScroll = true;
            this.uctlCommonSetting1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlCommonSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlCommonSetting1.Location = new System.Drawing.Point(0, 0);
            this.uctlCommonSetting1.Name = "uctlCommonSetting1";
            this.uctlCommonSetting1.Size = new System.Drawing.Size(426, 255);
            this.uctlCommonSetting1.TabIndex = 0;
            // 
            // frmCommonSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 255);
            this.Controls.Add(this.uctlCommonSetting1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCommonSetting";
            this.Text = "Common Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCommonSetting_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlCommonSetting uctlCommonSetting1;
    }
}