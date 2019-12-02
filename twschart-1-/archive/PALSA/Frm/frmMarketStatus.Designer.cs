namespace PALSA.Frm
{
    partial class frmMarketStatus
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
            this.uctlMarketStatus1 = new CommonLibrary.UserControls.UctlMarketStatus();
            this.SuspendLayout();
            // 
            // uctlMarketStatus1
            // 
            this.uctlMarketStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMarketStatus1.Location = new System.Drawing.Point(0, 0);
            this.uctlMarketStatus1.Name = "uctlMarketStatus1";
            this.uctlMarketStatus1.Size = new System.Drawing.Size(423, 165);
            this.uctlMarketStatus1.TabIndex = 0;
            this.uctlMarketStatus1.Title = " ";
            // 
            // frmMarketStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 165);
            this.Controls.Add(this.uctlMarketStatus1);
            this.Name = "frmMarketStatus";
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
            this.Text = "frmMarketStatus";
            this.Title = "frmMarketStatus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketStatus_FormClosed);
            this.Load += new System.EventHandler(this.frmMarketStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlMarketStatus uctlMarketStatus1;
    }
}