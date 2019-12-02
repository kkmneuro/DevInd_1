namespace TWS.Frm
{
    partial class frmIndexView
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
            this.uctlIndexView1 = new CommonLibrary.UserControls.UctlIndexView();
            this.SuspendLayout();
            // 
            // uctlIndexView1
            // 
            this.uctlIndexView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlIndexView1.Location = new System.Drawing.Point(0, 0);
            this.uctlIndexView1.Name = "uctlIndexView1";
            this.uctlIndexView1.Size = new System.Drawing.Size(643, 117);
            this.uctlIndexView1.TabIndex = 0;
            this.uctlIndexView1.Title = " ";
            // 
            // frmIndexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 117);
            this.Controls.Add(this.uctlIndexView1);
            this.Name = "frmIndexView";
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmIndexView";
            this.Load += new System.EventHandler(this.frmIndexView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlIndexView uctlIndexView1;
    }
}