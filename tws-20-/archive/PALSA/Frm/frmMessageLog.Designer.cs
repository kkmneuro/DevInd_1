namespace TWS.Frm
{
    partial class frmMessageLog
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
            this.uctlMessagLog1 = new CommonLibrary.UserControls.UctlMessagLog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // uctlMessagLog1
            // 
            this.uctlMessagLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMessagLog1.Location = new System.Drawing.Point(0, 0);
            this.uctlMessagLog1.Name = "uctlMessagLog1";
            this.uctlMessagLog1.OrderFilter = null;
            this.uctlMessagLog1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlMessagLog1.Size = new System.Drawing.Size(814, 284);
            this.uctlMessagLog1.TabIndex = 0;
            this.uctlMessagLog1.Title = " ";
            this.uctlMessagLog1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlMessagLog1_OnGridMouseDown);
            this.uctlMessagLog1.OnMessageFilterItemClilck += new System.Action<string>(this.uctlMessagLog1_OnMessageFilterItemClilck);
            this.uctlMessagLog1.OnMessageFilterOkClick += new System.Action<string, string, string, string>(this.uctlMessagLog1_OnMessageFilterOkClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmMessageLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 284);
            this.Controls.Add(this.uctlMessagLog1);
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(600, 220);
            this.Name = "frmMessageLog";
            this.Text = "Message Log";
            this.Title = "Message Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMessageLog_FormClosed);
            this.Load += new System.EventHandler(this.frmMessageLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CommonLibrary.UserControls.UctlMessagLog uctlMessagLog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}