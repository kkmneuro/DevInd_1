namespace TWS.Frm
{
    partial class frmMarketPictureNew
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
            this.uctlMarketPicture1 = new CommonLibrary.UserControls.uctlMarketPictureNew();
            this.SuspendLayout();
            // 
            // uctlMarketPicture1
            //             
            this.uctlMarketPicture1.Dock = System.Windows.Forms.DockStyle.Fill;            
            this.uctlMarketPicture1.Location = new System.Drawing.Point(0, 0);            
            this.uctlMarketPicture1.Name = "uctlMarketPicture1";            
            this.uctlMarketPicture1.Size = new System.Drawing.Size(533, 183);
            this.uctlMarketPicture1.TabIndex = 0;
            this.uctlMarketPicture1.Title = " Market Picture";            
            this.uctlMarketPicture1.Load += new System.EventHandler(this.uctlMarketPicture1_Load);
            // 
            // frmMarketPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 183);
            this.Controls.Add(this.uctlMarketPicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(763, 244);
            this.MinimumSize = new System.Drawing.Size(532, 185);
            this.Name = "frmMarketPicture";
            this.Text = "frmMarketPicture";
            this.Title = "frmMarketPicture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketPicture_FormClosed);
            this.Load += new System.EventHandler(this.frmMarketPicture_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.uctlMarketPictureNew uctlMarketPicture1;
    }
}