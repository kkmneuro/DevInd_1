namespace PALSA.Frm
{
    partial class frmAlertSendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertSendMail));
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.rtxtAlertmail = new Nevron.UI.WinForm.Controls.NRichTextBox();
            this.txtMail = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblSub = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new Nevron.UI.WinForm.Controls.NTextBox();
            this.cboTo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.SuspendLayout();
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 244);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(403, 22);
            this.nStatusBar1.TabIndex = 0;
            this.nStatusBar1.Text = "nStatusBar1";
            // 
            // rtxtAlertmail
            // 
            this.rtxtAlertmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtxtAlertmail.Location = new System.Drawing.Point(0, 60);
            this.rtxtAlertmail.Name = "rtxtAlertmail";
            this.rtxtAlertmail.Size = new System.Drawing.Size(403, 184);
            this.rtxtAlertmail.TabIndex = 2;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(65, 34);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(245, 18);
            this.txtMail.TabIndex = 1;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(13, 36);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(46, 13);
            this.lblSub.TabIndex = 4;
            this.lblSub.Text = "Subject:";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.btnSend.Location = new System.Drawing.Point(317, 16);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 27);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(13, 9);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(66, 9);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(245, 18);
            this.txtTo.TabIndex = 0;
            // 
            // cboTo
            // 
            this.cboTo.ListProperties.ColumnOnLeft = false;
            this.cboTo.Location = new System.Drawing.Point(66, 9);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(244, 18);
            this.cboTo.TabIndex = 6;
            this.cboTo.Text = "nComboBox1";
            // 
            // frmAlertSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Controls.Add(this.cboTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.rtxtAlertmail);
            this.Controls.Add(this.nStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlertSendMail";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Mail message";
            this.Load += new System.EventHandler(this.frmAlertSendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        private Nevron.UI.WinForm.Controls.NRichTextBox rtxtAlertmail;
        private Nevron.UI.WinForm.Controls.NTextBox txtMail;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblTo;
        private Nevron.UI.WinForm.Controls.NTextBox txtTo;
        private Nevron.UI.WinForm.Controls.NComboBox cboTo;
    }
}