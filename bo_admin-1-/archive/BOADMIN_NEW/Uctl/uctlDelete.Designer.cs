namespace BOADMIN_NEW.Uctl
{
    partial class uctlDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlDelete));
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_txtAuto = new System.Windows.Forms.TextBox();
            this.lblAuto = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblContent2 = new System.Windows.Forms.Label();
            this.lblContent1 = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.label1);
            this.nuiPanel1.Controls.Add(this.ui_btnCancel);
            this.nuiPanel1.Controls.Add(this.ui_btnOK);
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_txtAuto);
            this.nuiPanel1.Controls.Add(this.lblAuto);
            this.nuiPanel1.Controls.Add(this.picLogo);
            this.nuiPanel1.Controls.Add(this.lblContent2);
            this.nuiPanel1.Controls.Add(this.lblContent1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(433, 186);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // ui_btnCancel
            // 
            this.ui_btnCancel.Location = new System.Drawing.Point(219, 146);
            this.ui_btnCancel.Name = "ui_btnCancel";
            this.ui_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_btnCancel.TabIndex = 2;
            this.ui_btnCancel.Text = "Cancel";
            this.ui_btnCancel.UseVisualStyleBackColor = false;
            this.ui_btnCancel.Click += new System.EventHandler(this.ui_btnCancel_Click);
            // 
            // ui_btnOK
            // 
            this.ui_btnOK.Location = new System.Drawing.Point(144, 146);
            this.ui_btnOK.Name = "ui_btnOK";
            this.ui_btnOK.Size = new System.Drawing.Size(69, 23);
            this.ui_btnOK.TabIndex = 1;
            this.ui_btnOK.Text = "OK";
            this.ui_btnOK.UseVisualStyleBackColor = false;
            this.ui_btnOK.Click += new System.EventHandler(this.ui_btnOK_Click);
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(2, 138);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(427, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_txtAuto
            // 
            this.ui_txtAuto.Location = new System.Drawing.Point(276, 103);
            this.ui_txtAuto.Name = "ui_txtAuto";
            this.ui_txtAuto.Size = new System.Drawing.Size(100, 20);
            this.ui_txtAuto.TabIndex = 0;
            this.ui_txtAuto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_txtAuto_KeyDown);
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuto.Location = new System.Drawing.Point(114, 97);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(0, 26);
            this.lblAuto.TabIndex = 12;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(2, 16);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(69, 64);
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            // 
            // lblContent2
            // 
            this.lblContent2.AutoSize = true;
            this.lblContent2.BackColor = System.Drawing.Color.Transparent;
            this.lblContent2.Location = new System.Drawing.Point(77, 54);
            this.lblContent2.Name = "lblContent2";
            this.lblContent2.Size = new System.Drawing.Size(321, 26);
            this.lblContent2.TabIndex = 10;
            this.lblContent2.Text = "To confirm the exection of this operation , please type the following\r\ncombinatio" +
                "n of symbols";
            // 
            // lblContent1
            // 
            this.lblContent1.AutoSize = true;
            this.lblContent1.BackColor = System.Drawing.Color.Transparent;
            this.lblContent1.Location = new System.Drawing.Point(77, 16);
            this.lblContent1.Name = "lblContent1";
            this.lblContent1.Size = new System.Drawing.Size(279, 26);
            this.lblContent1.TabIndex = 9;
            this.lblContent1.Text = "This operation could lead to serious changes in the server\r\n configuration";
            // 
            // uctlDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlDelete";
            this.Size = new System.Drawing.Size(433, 186);
            this.Load += new System.EventHandler(this.uctlDelete_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NButton ui_btnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_btnOK;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private System.Windows.Forms.TextBox ui_txtAuto;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblContent2;
        private System.Windows.Forms.Label lblContent1;
        private System.Windows.Forms.Label label1;

    }
}
