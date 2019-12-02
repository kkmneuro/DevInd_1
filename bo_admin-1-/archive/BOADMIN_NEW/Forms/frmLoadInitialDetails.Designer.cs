namespace BOADMIN_NEW.Forms
{
    partial class frmLoadInitialDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nwbInitialDetails = new Nevron.UI.WinForm.Controls.NWaitingBar();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading Initial Details....";
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.label1);
            this.nuiPanel1.Controls.Add(this.ui_nwbInitialDetails);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.nuiPanel1.Size = new System.Drawing.Size(282, 140);
            this.nuiPanel1.TabIndex = 2;
            // 
            // ui_nwbInitialDetails
            // 
            this.ui_nwbInitialDetails.Location = new System.Drawing.Point(35, 50);
            this.ui_nwbInitialDetails.Name = "ui_nwbInitialDetails";
            this.ui_nwbInitialDetails.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Office2007Blue;
            this.ui_nwbInitialDetails.Properties.Text = "Loading... Please, wait!";
            this.ui_nwbInitialDetails.Size = new System.Drawing.Size(211, 24);
            this.ui_nwbInitialDetails.TabIndex = 0;
            // 
            // frmLoadInitialDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 140);
            this.Controls.Add(this.nuiPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoadInitialDetails";
            this.Text = "frmLoadInitialDetails";
            this.Load += new System.EventHandler(this.frmLoadInitialDetails_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NWaitingBar ui_nwbInitialDetails;
    }
}