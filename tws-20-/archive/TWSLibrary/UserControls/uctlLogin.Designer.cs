namespace CommonLibrary.UserControls
{
    partial class UctlLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlLogin));
            this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.ui_nbtnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.ui_ntxtUserCode = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nchkSavePassword = new Nevron.UI.WinForm.Controls.NCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
            this.nGrouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
            this.nGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // nGrouper1
            // 
            this.nGrouper1.BackColor = System.Drawing.Color.Gainsboro;
            this.nGrouper1.Controls.Add(this.nchkSavePassword);
            this.nGrouper1.Controls.Add(this.ui_nbtnOk);
            this.nGrouper1.Controls.Add(this.ui_nbtnCancel);
            this.nGrouper1.Controls.Add(this.nGroupBoxEx1);
            this.nGrouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper1.FooterItem.Text = "Footer";
            this.nGrouper1.FooterItem.Visible = false;
            this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper1.HeaderItem.Text = "<b>Login</b>";
            this.nGrouper1.Location = new System.Drawing.Point(0, 0);
            this.nGrouper1.Name = "nGrouper1";
            this.nGrouper1.ShadowInfo.Draw = false;
            this.nGrouper1.Size = new System.Drawing.Size(332, 197);
            this.nGrouper1.TabIndex = 0;
            this.nGrouper1.TabStop = false;
            this.nGrouper1.Text = "nGrouper1";
            // 
            // ui_nbtnOk
            // 
            this.ui_nbtnOk.Location = new System.Drawing.Point(119, 158);
            this.ui_nbtnOk.Name = "ui_nbtnOk";
            this.ui_nbtnOk.Size = new System.Drawing.Size(96, 24);
            this.ui_nbtnOk.TabIndex = 2;
            this.ui_nbtnOk.Text = "&Ok";
            this.ui_nbtnOk.UseVisualStyleBackColor = false;
            this.ui_nbtnOk.Click += new System.EventHandler(this.ui_nbtnOk_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(222, 158);
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
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtUserCode);
            this.nGroupBoxEx1.Controls.Add(this.ui_ntxtPassword);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer2);
            this.nGroupBoxEx1.Controls.Add(this.nEntryContainer1);
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
            this.nGroupBoxEx1.Location = new System.Drawing.Point(10, 30);
            this.nGroupBoxEx1.Name = "nGroupBoxEx1";
            this.nGroupBoxEx1.ShadowInfo.Draw = false;
            this.nGroupBoxEx1.Size = new System.Drawing.Size(308, 118);
            this.nGroupBoxEx1.StrokeInfo.Rounding = 5;
            this.nGroupBoxEx1.TabIndex = 0;
            this.nGroupBoxEx1.TabStop = false;
            // 
            // ui_ntxtUserCode
            // 
            this.ui_ntxtUserCode.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtUserCode.Location = new System.Drawing.Point(85, 50);
            this.ui_ntxtUserCode.Name = "ui_ntxtUserCode";
            this.ui_ntxtUserCode.Size = new System.Drawing.Size(171, 15);
            this.ui_ntxtUserCode.TabIndex = 0;
            this.ui_ntxtUserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtUserCode_KeyPress);
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_ntxtPassword.Location = new System.Drawing.Point(85, 82);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.PasswordChar = '●';
            this.ui_ntxtPassword.Size = new System.Drawing.Size(171, 15);
            this.ui_ntxtPassword.TabIndex = 1;
            this.ui_ntxtPassword.UseSystemPasswordChar = true;
            this.ui_ntxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtPassword_KeyPress);
            // 
            // nEntryContainer2
            // 
            this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer2.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer2.Location = new System.Drawing.Point(12, 76);
            this.nEntryContainer2.Name = "nEntryContainer2";
            this.nEntryContainer2.Size = new System.Drawing.Size(290, 32);
            this.nEntryContainer2.StrokeInfo.Rounding = 5;
            this.nEntryContainer2.TabIndex = 1;
            this.nEntryContainer2.TabStop = false;
            this.nEntryContainer2.Text = "Password <font color=\'red\'><b>*</b></font>:";
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer1.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer1.Location = new System.Drawing.Point(12, 44);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.Size = new System.Drawing.Size(290, 32);
            this.nEntryContainer1.StrokeInfo.Rounding = 5;
            this.nEntryContainer1.TabIndex = 0;
            this.nEntryContainer1.TabStop = false;
            this.nEntryContainer1.Text = "User Code<font color=\'red\'><b>*</b></font>:";
            // 
            // nchkSavePassword
            // 
            this.nchkSavePassword.AutoSize = true;
            this.nchkSavePassword.ButtonProperties.BorderOffset = 2;
            this.nchkSavePassword.Location = new System.Drawing.Point(10, 162);
            this.nchkSavePassword.Name = "nchkSavePassword";
            this.nchkSavePassword.Size = new System.Drawing.Size(100, 17);
            this.nchkSavePassword.TabIndex = 4;
            this.nchkSavePassword.Text = "Save Password";
            this.nchkSavePassword.UseVisualStyleBackColor = false;
            // 
            // UctlLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nGrouper1);
            this.Name = "UctlLogin";
            this.Size = new System.Drawing.Size(332, 197);
            this.Load += new System.EventHandler(this.uctlLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
            this.nGrouper1.ResumeLayout(false);
            this.nGrouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
            this.nGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOk;
        public Nevron.UI.WinForm.Controls.NCheckBox nchkSavePassword;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtUserCode;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
    }
}
