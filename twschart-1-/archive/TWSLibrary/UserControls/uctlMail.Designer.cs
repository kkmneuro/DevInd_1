namespace CommonLibrary.UserControls
{
    partial class UctlMail
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
            this.ui_npnlMailContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnSend = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblSubject = new System.Windows.Forms.Label();
            this.ui_lblTo = new System.Windows.Forms.Label();
            this.ui_ncmbTo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_txtMailDetails = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtSubject = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_npnlMailContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlMailContainer
            // 
            this.ui_npnlMailContainer.Controls.Add(this.ui_nbtnSend);
            this.ui_npnlMailContainer.Controls.Add(this.ui_lblSubject);
            this.ui_npnlMailContainer.Controls.Add(this.ui_lblTo);
            this.ui_npnlMailContainer.Controls.Add(this.ui_ncmbTo);
            this.ui_npnlMailContainer.Controls.Add(this.ui_txtMailDetails);
            this.ui_npnlMailContainer.Controls.Add(this.ui_ntxtSubject);
            this.ui_npnlMailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlMailContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlMailContainer.Name = "ui_npnlMailContainer";
            this.ui_npnlMailContainer.Size = new System.Drawing.Size(453, 302);
            this.ui_npnlMailContainer.TabIndex = 0;
            this.ui_npnlMailContainer.Text = "nuiPanel1";
            // 
            // ui_nbtnSend
            // 
            this.ui_nbtnSend.Location = new System.Drawing.Point(357, 21);
            this.ui_nbtnSend.Name = "ui_nbtnSend";
            this.ui_nbtnSend.Size = new System.Drawing.Size(72, 23);
            this.ui_nbtnSend.TabIndex = 2;
            this.ui_nbtnSend.Text = "&Send";
            this.ui_nbtnSend.UseVisualStyleBackColor = false;
            // 
            // ui_lblSubject
            // 
            this.ui_lblSubject.AutoSize = true;
            this.ui_lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSubject.Location = new System.Drawing.Point(12, 39);
            this.ui_lblSubject.Name = "ui_lblSubject";
            this.ui_lblSubject.Size = new System.Drawing.Size(52, 13);
            this.ui_lblSubject.TabIndex = 4;
            this.ui_lblSubject.Text = "Subject : ";
            // 
            // ui_lblTo
            // 
            this.ui_lblTo.AutoSize = true;
            this.ui_lblTo.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTo.Location = new System.Drawing.Point(12, 15);
            this.ui_lblTo.Name = "ui_lblTo";
            this.ui_lblTo.Size = new System.Drawing.Size(29, 13);
            this.ui_lblTo.TabIndex = 3;
            this.ui_lblTo.Text = "To : ";
            // 
            // ui_ncmbTo
            // 
            this.ui_ncmbTo.Location = new System.Drawing.Point(70, 12);
            this.ui_ncmbTo.Name = "ui_ncmbTo";
            this.ui_ncmbTo.Size = new System.Drawing.Size(266, 18);
            this.ui_ncmbTo.TabIndex = 0;
            this.ui_ncmbTo.Text = "nComboBox1";
            // 
            // ui_txtMailDetails
            // 
            this.ui_txtMailDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ui_txtMailDetails.Location = new System.Drawing.Point(0, 65);
            this.ui_txtMailDetails.Multiline = true;
            this.ui_txtMailDetails.Name = "ui_txtMailDetails";
            this.ui_txtMailDetails.Size = new System.Drawing.Size(453, 237);
            this.ui_txtMailDetails.TabIndex = 1;
            // 
            // ui_ntxtSubject
            // 
            this.ui_ntxtSubject.Location = new System.Drawing.Point(70, 36);
            this.ui_ntxtSubject.Name = "ui_ntxtSubject";
            this.ui_ntxtSubject.Size = new System.Drawing.Size(266, 18);
            this.ui_ntxtSubject.TabIndex = 1;
            // 
            // uctlMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlMailContainer);
            this.Name = "UctlMail";
            this.Size = new System.Drawing.Size(453, 302);
            this.Load += new System.EventHandler(this.uctlMail_Load);
            this.ui_npnlMailContainer.ResumeLayout(false);
            this.ui_npnlMailContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlMailContainer;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSend;
        private System.Windows.Forms.Label ui_lblSubject;
        private System.Windows.Forms.Label ui_lblTo;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbTo;
        private Nevron.UI.WinForm.Controls.NTextBox ui_txtMailDetails;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSubject;
    }
}
