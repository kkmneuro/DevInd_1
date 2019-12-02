namespace TWS.Frm
{
    partial class frmMostActiveProducts
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
            this.uctlMostActiveProducts1 = new CommonLibrary.UserControls.UctlMostActiveProducts();
            this.SuspendLayout();
            // 
            // uctlMostActiveProducts1
            // 
            this.uctlMostActiveProducts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMostActiveProducts1.Location = new System.Drawing.Point(0, 0);
            this.uctlMostActiveProducts1.Name = "uctlMostActiveProducts1";
            this.uctlMostActiveProducts1.Size = new System.Drawing.Size(712, 346);
            this.uctlMostActiveProducts1.TabIndex = 0;
            this.uctlMostActiveProducts1.Title = "Most Active Products";
            // 
            // frmMostActiveProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 346);
            this.Controls.Add(this.uctlMostActiveProducts1);
            this.Name = "frmMostActiveProducts";
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
            this.Text = "frmMostActiveProducts";
            this.Title = "frmMostActiveProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMostActiveProducts_FormClosed);
            this.Load += new System.EventHandler(this.frmMostActiveProducts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlMostActiveProducts uctlMostActiveProducts1;
    }
}