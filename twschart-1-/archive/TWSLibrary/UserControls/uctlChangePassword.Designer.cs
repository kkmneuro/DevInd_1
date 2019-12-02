namespace CommonLibrary.UserControls
{
    partial class UctlChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlChangePassword));
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_ntxtConfirmPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtNewPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtUserCode = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
            this.nGrouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
            this.nGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.nGrouper1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(363, 239);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // nGrouper1
            // 
            this.nGrouper1.BackColor = System.Drawing.Color.Gainsboro;
            this.nGrouper1.Controls.Add(this.ui_nbtnOk);
            this.nGrouper1.Controls.Add(this.ui_nbtnCancel);
            this.nGrouper1.Controls.Add(this.nGroupBoxEx1);
            this.nGrouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper1.FooterItem.Text = "Footer";
            this.nGrouper1.FooterItem.Visible = false;
            this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper1.HeaderItem.Text = "<b>Change Password</b>";
            this.nGrouper1.HeaderItem.Visible = false;
            this.nGrouper1.Location = new System.Drawing.Point(0, 0);
            this.nGrouper1.Name = "nGrouper1";
            this.nGrouper1.ShadowInfo.Draw = false;
            this.nGrouper1.Size = new System.Drawing.Size(361, 237);
            this.nGrouper1.TabIndex = 1;
            this.nGrouper1.Text = "nGrouper1";
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(136, 197);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(96, 24);
            this.ui_nbtnOk.TabIndex = 2;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(251, 197);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(96, 24);
            this.ui_nbtnCancel.TabIndex = 3;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // nGroupBoxEx1
            // 
            this.nGroupBoxEx1.BackColor = System.Drawing.Color.Transparent;
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtConfirmPassword);
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtNewPassword);
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtUserCode);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer3);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer4);
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtPassword);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer1);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer2);
            this.nGroupBoxEx1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nGroupBoxEx1.HeaderItem.AutoPaintText = false;
            this.nGroupBoxEx1.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGroupBoxEx1.HeaderItem.Image")));
            this.nGroupBoxEx1.HeaderItem.ImageTextSpacing = 0;
            this.nGroupBoxEx1.HeaderItem.ItemStyle = Nevron.UI.ItemStyle.Image;
            this.nGroupBoxEx1.HeaderItem.Padding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nGroupBoxEx1.HeaderItem.Text = "NGroupBoxEx";
            this.nGroupBoxEx1.HeaderStrokeInfo.Draw = false;
            this.nGroupBoxEx1.HeaderStrokeInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
            this.nGroupBoxEx1.HeaderStrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
            this.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 5;
            this.nGroupBoxEx1.HeaderStrokeInfo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.nGroupBoxEx1.Location = new System.Drawing.Point(8, 7);
            this.nGroupBoxEx1.Name = "nGroupBoxEx1";
            this.nGroupBoxEx1.ShadowInfo.Draw = false;
            this.nGroupBoxEx1.Size = new System.Drawing.Size(344, 180);
            this.nGroupBoxEx1.StrokeInfo.Rounding = 5;
            this.nGroupBoxEx1.TabIndex = 1;
            // 
            // ui_ntxtConfirmPassword
            // 
            this.ui_ntxtConfirmPassword.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtConfirmPassword.Location = new System.Drawing.Point(132, 148);
            this.ui_ntxtConfirmPassword.Name = "ui_ntxtConfirmPassword";
            this.ui_ntxtConfirmPassword.PasswordChar = '●';
            this.ui_ntxtConfirmPassword.Size = new System.Drawing.Size(182, 15);
            this.ui_ntxtConfirmPassword.TabIndex = 6;
            this.ui_ntxtConfirmPassword.UseSystemPasswordChar = true;
            this.ui_ntxtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtConfirmPassword_KeyPress);
            // 
            // ui_ntxtNewPassword
            // 
            this.ui_ntxtNewPassword.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtNewPassword.Location = new System.Drawing.Point(114, 116);
            this.ui_ntxtNewPassword.Name = "ui_ntxtNewPassword";
            this.ui_ntxtNewPassword.PasswordChar = '●';
            this.ui_ntxtNewPassword.Size = new System.Drawing.Size(201, 15);
            this.ui_ntxtNewPassword.TabIndex = 5;
            this.ui_ntxtNewPassword.UseSystemPasswordChar = true;
            this.ui_ntxtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtNewPassword_KeyPress);
            // 
            // ui_ntxtUserCode
            // 
            this.ui_ntxtUserCode.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtUserCode.Enabled = false;
            this.ui_ntxtUserCode.Location = new System.Drawing.Point(115, 50);
            this.ui_ntxtUserCode.Name = "ui_ntxtUserCode";
            this.ui_ntxtUserCode.Size = new System.Drawing.Size(201, 15);
            this.ui_ntxtUserCode.TabIndex = 0;
            this.ui_ntxtUserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtUserCode_KeyPress);
            // 
            // nEntryContainer3
            // 
            this.nEntryContainer3.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer3.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer3.Location = new System.Drawing.Point(24, 142);
            this.nEntryContainer3.Name = "nEntryContainer3";
            this.nEntryContainer3.Size = new System.Drawing.Size(304, 32);
            this.nEntryContainer3.StrokeInfo.Rounding = 5;
            this.nEntryContainer3.TabIndex = 4;
            this.nEntryContainer3.TabStop = false;
            this.nEntryContainer3.Text = "Confirm Password <font color=\'red\'><b>*</b></font>:";
            // 
            // nEntryContainer4
            // 
            this.nEntryContainer4.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer4.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer4.Location = new System.Drawing.Point(24, 110);
            this.nEntryContainer4.Name = "nEntryContainer4";
            this.nEntryContainer4.Size = new System.Drawing.Size(304, 32);
            this.nEntryContainer4.StrokeInfo.Rounding = 5;
            this.nEntryContainer4.TabIndex = 3;
            this.nEntryContainer4.TabStop = false;
            this.nEntryContainer4.Text = "New Password<font color=\'red\'><b>*</b></font>:";
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtPassword.Location = new System.Drawing.Point(115, 82);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.PasswordChar = '●';
            this.ui_ntxtPassword.Size = new System.Drawing.Size(201, 15);
            this.ui_ntxtPassword.TabIndex = 1;
            this.ui_ntxtPassword.UseSystemPasswordChar = true;
            this.ui_ntxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtPassword_KeyPress);
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer1.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer1.Location = new System.Drawing.Point(24, 44);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.Size = new System.Drawing.Size(304, 32);
            this.nEntryContainer1.StrokeInfo.Rounding = 5;
            this.nEntryContainer1.TabIndex = 0;
            this.nEntryContainer1.TabStop = false;
            this.nEntryContainer1.Text = "User Code<font color=\'red\'><b>*</b></font>:";
            // 
            // nEntryContainer2
            // 
            this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer2.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer2.Location = new System.Drawing.Point(24, 76);
            this.nEntryContainer2.Name = "nEntryContainer2";
            this.nEntryContainer2.Size = new System.Drawing.Size(304, 32);
            this.nEntryContainer2.StrokeInfo.Rounding = 5;
            this.nEntryContainer2.TabIndex = 2;
            this.nEntryContainer2.TabStop = false;
            this.nEntryContainer2.Text = "Old Password <font color=\'red\'><b>*</b></font>:";
            // 
            // UctlChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "UctlChangePassword";
            this.Size = new System.Drawing.Size(363, 239);
            this.Load += new System.EventHandler(this.UctlChangePassword_Load);
            this.nuiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
            this.nGrouper1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
            this.nGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtUserCode;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtConfirmPassword;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtNewPassword;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
    }
}
