namespace TWS.Frm
{
    partial class frmTopGainersLosers
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
            this.ui_uctlTopGainerLoser = new CommonLibrary.UserControls.UctlTopGainerLoser();
            this.uctlTopGainerLoser1 = new CommonLibrary.UserControls.UctlTopGainerLoser();
            this.SuspendLayout();
            // 
            // ui_uctlTopGainerLoser
            // 
            this.ui_uctlTopGainerLoser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlTopGainerLoser.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlTopGainerLoser.Name = "ui_uctlTopGainerLoser";
            this.ui_uctlTopGainerLoser.Size = new System.Drawing.Size(647, 392);
            this.ui_uctlTopGainerLoser.TabIndex = 0;
            this.ui_uctlTopGainerLoser.Title = "Top Gainers/Losers";
            // 
            // uctlTopGainerLoser1
            // 
            this.uctlTopGainerLoser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTopGainerLoser1.Location = new System.Drawing.Point(0, 0);
            this.uctlTopGainerLoser1.Name = "uctlTopGainerLoser1";
            this.uctlTopGainerLoser1.Size = new System.Drawing.Size(647, 392);
            this.uctlTopGainerLoser1.TabIndex = 0;
            this.uctlTopGainerLoser1.Title = "Top Gainers/Losers";
            // 
            // frmTopGainersLosers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 392);
            this.Controls.Add(this.ui_uctlTopGainerLoser);
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(337, 220);
            this.Name = "frmTopGainersLosers";
            this.Text = "frmTopGainersLosers";
            this.Title = "frmTopGainersLosers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTopGainersLosers_FormClosed);
            this.Load += new System.EventHandler(this.frmTopGainersLosers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlTopGainerLoser ui_uctlTopGainerLoser;
        private CommonLibrary.UserControls.UctlTopGainerLoser uctlTopGainerLoser1;
    }
}