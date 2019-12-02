namespace BOADMIN_NEW.Uctl
{
    partial class uctlFind
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.grpDirection = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnFind = new Nevron.UI.WinForm.Controls.NButton();
            this.cmbFind = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.grpDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.btnCancel);
            this.nuiPanel1.Controls.Add(this.grpDirection);
            this.nuiPanel1.Controls.Add(this.btnFind);
            this.nuiPanel1.Controls.Add(this.cmbFind);
            this.nuiPanel1.Controls.Add(this.lblFind);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(442, 171);
            this.nuiPanel1.TabIndex = 1;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(352, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // grpDirection
            // 
            this.grpDirection.Controls.Add(this.radioButton2);
            this.grpDirection.Controls.Add(this.radioButton1);
            this.grpDirection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpDirection.Location = new System.Drawing.Point(94, 64);
            this.grpDirection.Name = "grpDirection";
            this.grpDirection.Size = new System.Drawing.Size(242, 88);
            this.grpDirection.TabIndex = 3;
            this.grpDirection.TabStop = false;
            this.grpDirection.Text = "Direction";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(65, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Down";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(65, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Up";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(352, 28);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Next";
            this.btnFind.UseVisualStyleBackColor = false;
            // 
            // cmbFind
            // 
            this.cmbFind.Location = new System.Drawing.Point(94, 28);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(242, 22);
            this.cmbFind.TabIndex = 1;
            this.cmbFind.Text = "nComboBox1";
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.BackColor = System.Drawing.Color.Transparent;
            this.lblFind.Location = new System.Drawing.Point(18, 33);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(59, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Find What:";
            // 
            // uctlFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlFind";
            this.Size = new System.Drawing.Size(442, 171);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.grpDirection.ResumeLayout(false);
            this.grpDirection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.Label lblFind;
        private Nevron.UI.WinForm.Controls.NGroupBox grpDirection;
        private Nevron.UI.WinForm.Controls.NButton btnFind;
        private Nevron.UI.WinForm.Controls.NComboBox cmbFind;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
    }
}
