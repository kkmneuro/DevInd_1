namespace PALSA.Frm
{
    partial class frmLockWorkStation
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
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_lblText = new System.Windows.Forms.Label();
            this.ui_lblPassword = new System.Windows.Forms.Label();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_npnlControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblText);
            this.ui_npnlControlContainer.Controls.Add(this.ui_lblPassword);
            this.ui_npnlControlContainer.Controls.Add(this.ui_ntxtPassword);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(1137, 42);
            this.ui_npnlControlContainer.TabIndex = 0;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // ui_lblText
            // 
            this.ui_lblText.AutoSize = true;
            this.ui_lblText.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblText.ForeColor = System.Drawing.Color.Maroon;
            this.ui_lblText.Location = new System.Drawing.Point(215, 14);
            this.ui_lblText.Name = "ui_lblText";
            this.ui_lblText.Size = new System.Drawing.Size(164, 13);
            this.ui_lblText.TabIndex = 2;
            this.ui_lblText.Text = "Enter password to resume trading";
            // 
            // ui_lblPassword
            // 
            this.ui_lblPassword.AutoSize = true;
            this.ui_lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPassword.ForeColor = System.Drawing.Color.Maroon;
            this.ui_lblPassword.Location = new System.Drawing.Point(34, 14);
            this.ui_lblPassword.Name = "ui_lblPassword";
            this.ui_lblPassword.Size = new System.Drawing.Size(59, 13);
            this.ui_lblPassword.TabIndex = 1;
            this.ui_lblPassword.Text = "Password :";
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Location = new System.Drawing.Point(100, 11);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.PasswordChar = '●';
            this.ui_ntxtPassword.Size = new System.Drawing.Size(106, 18);
            this.ui_ntxtPassword.TabIndex = 0;
            this.ui_ntxtPassword.UseSystemPasswordChar = true;
            this.ui_ntxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ntxtPassword_KeyDown);
            // 
            // frmLockWorkStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 42);
            this.Controls.Add(this.ui_npnlControlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLockWorkStation";
            this.ShowInTaskbar = false;
            this.Text = "frmLockWorkStation";
            this.TopMost = true;
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.ui_npnlControlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.Label ui_lblText;
        private System.Windows.Forms.Label ui_lblPassword;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
    }
}