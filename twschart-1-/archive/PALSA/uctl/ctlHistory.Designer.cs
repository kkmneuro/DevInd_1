namespace PALSA.uctl
{
    partial class ctlHistory
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
            this.uctlHistory = new CommonLibrary.UserControls.UctlPendingOrder();
            this.SuspendLayout();
            // 
            // uctlHistory
            // 
            this.uctlHistory.AlertSound = null;
            this.uctlHistory.CurrentProfileName = null;
            this.uctlHistory.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlHistory.Location = new System.Drawing.Point(0, 0);
            this.uctlHistory.Name = "uctlHistory";
            this.uctlHistory.Profiles = null;
            this.uctlHistory.Size = new System.Drawing.Size(891, 342);
            this.uctlHistory.TabIndex = 0;
            this.uctlHistory.Title = "Pending Order";
            // 
            // ctlHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uctlHistory);
            this.Name = "ctlHistory";
            this.Size = new System.Drawing.Size(891, 342);
            this.Load += new System.EventHandler(this.ctlPendingOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlPendingOrder uctlHistory;
    }
}
