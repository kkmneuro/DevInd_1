namespace PALSA.Frm
{
    partial class FrmAboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAboutUs));
            this.uctlAboutUS1 = new CommonLibrary.UserControls.UctlAboutUs();
            this.SuspendLayout();
            // 
            // uctlAboutUS1
            // 
            this.uctlAboutUS1.ContactAddText = "ContactAdd";
            this.uctlAboutUS1.CopyrightText = "Copyright © 2005-2014 LTech India Software Systems Pvt. Ltd. ";
            this.uctlAboutUS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlAboutUS1.Location = new System.Drawing.Point(0, 0);
            this.uctlAboutUS1.Logo = global::PALSA.Properties.Resources.LTechLogo;
            this.uctlAboutUS1.Name = "uctlAboutUS1";
            this.uctlAboutUS1.NoticeText = resources.GetString("uctlAboutUS1.NoticeText");
            this.uctlAboutUS1.ProductNameText = "LTech India Trader";
            this.uctlAboutUS1.Size = new System.Drawing.Size(596, 290);
            this.uctlAboutUS1.TabIndex = 0;
            this.uctlAboutUS1.Title = "About";
            this.uctlAboutUS1.VersionText = "Version 1.0.0.9";
            // 
            // FrmAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 290);
            this.Controls.Add(this.uctlAboutUS1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmAboutUs";
            this.ShowCaptionImage = true;
            this.ShowIcon = true;
            this.Text = "About";
            this.Title = "About";
            this.Load += new System.EventHandler(this.FrmAboutUs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlAboutUs uctlAboutUS1;



    }
}