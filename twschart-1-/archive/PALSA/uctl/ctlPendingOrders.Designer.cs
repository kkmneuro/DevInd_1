namespace PALSA.uctl
{
    partial class ctlPendingOrders
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
            this.uctlPendingOrder1 = new CommonLibrary.UserControls.UctlPendingOrder();
            this.SuspendLayout();
            // 
            // uctlPendingOrder1
            // 
            this.uctlPendingOrder1.AlertSound = null;
            this.uctlPendingOrder1.CurrentProfileName = null;
            this.uctlPendingOrder1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlPendingOrder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlPendingOrder1.Location = new System.Drawing.Point(0, 0);
            this.uctlPendingOrder1.Name = "uctlPendingOrder1";
            this.uctlPendingOrder1.Profiles = null;
            this.uctlPendingOrder1.Size = new System.Drawing.Size(891, 342);
            this.uctlPendingOrder1.TabIndex = 0;
            this.uctlPendingOrder1.Title = "Pending Order";
            // 
            // ctlPendingOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uctlPendingOrder1);
            this.Name = "ctlPendingOrders";
            this.Size = new System.Drawing.Size(891, 342);
            this.Load += new System.EventHandler(this.ctlPendingOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlPendingOrder uctlPendingOrder1;
    }
}
