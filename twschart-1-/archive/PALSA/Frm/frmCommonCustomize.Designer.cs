namespace PALSA.Frm
{
    partial class frmCommonCustomize
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
            this.uctlCommonCustomize1 = new CommonLibrary.UserControls.UctlCommonCustomize();
            this.SuspendLayout();
            // 
            // uctlCommonCustomize1
            // 
            this.uctlCommonCustomize1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlCommonCustomize1.Location = new System.Drawing.Point(0, 0);
            this.uctlCommonCustomize1.Name = "uctlCommonCustomize1";
            this.uctlCommonCustomize1.Size = new System.Drawing.Size(432, 459);
            this.uctlCommonCustomize1.TabIndex = 0;
            this.uctlCommonCustomize1.Title = null;
            // 
            // frmCommonCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 459);
            this.Controls.Add(this.uctlCommonCustomize1);
            this.MinimizeBox = false;
            this.Name = "frmCommonCustomize";
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
            this.Text = "frmCommonCustomize";
            this.Title = "frmCommonCustomize";
            this.Load += new System.EventHandler(this.frmCommonCustomize_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlCommonCustomize uctlCommonCustomize1;
    }
}