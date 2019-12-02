namespace TWS.Frm
{
    partial class frmSurveillance
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uctlSurveillance1 = new CommonLibrary.UserControls.UctlSurveillance();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uctlSurveillance1
            // 
            this.uctlSurveillance1.CurrentProfileName = "";
            this.uctlSurveillance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlSurveillance1.Location = new System.Drawing.Point(0, 0);
            this.uctlSurveillance1.Name = "uctlSurveillance1";
            this.uctlSurveillance1.Profiles = null;
            this.uctlSurveillance1.Size = new System.Drawing.Size(1172, 171);
            this.uctlSurveillance1.TabIndex = 0;
            this.uctlSurveillance1.Title = "Serveillance";
            this.uctlSurveillance1.OnProfileSaveClick += new System.Action<object, string>(this.uctlSurveillance1_OnProfileSaveClick);
            this.uctlSurveillance1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlSurveillance1_OnProfileRemoveClick);
            this.uctlSurveillance1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlSurveillance1_OnSetDefaultProfileClick);
            // 
            // frmSurveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 171);
            this.Controls.Add(this.uctlSurveillance1);
            this.MinimumSize = new System.Drawing.Size(650, 217);
            this.Name = "frmSurveillance";
            this.Text = "Surveillance";
            this.Title = "Surveillance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSurveillance_FormClosed);
            this.Load += new System.EventHandler(this.frmSurveillance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlSurveillance uctlSurveillance1;
        private System.Windows.Forms.Timer timer1;
    }
}