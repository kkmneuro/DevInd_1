namespace BOADMIN_NEW.Forms
{
    partial class frmDataLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataLogin));
            this.nGrouper2 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnLogin = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtPassword = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_ntxtLoginId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper2)).BeginInit();
            this.nGrouper2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nGrouper2
            // 
            this.nGrouper2.BackColor = System.Drawing.SystemColors.Control;
            this.nGrouper2.Controls.Add(this.ui_nbtnCancel);
            this.nGrouper2.Controls.Add(this.ui_btnLogin);
            this.nGrouper2.Controls.Add(this.ui_ntxtPassword);
            this.nGrouper2.Controls.Add(this.label3);
            this.nGrouper2.Controls.Add(this.ui_ntxtLoginId);
            this.nGrouper2.Controls.Add(this.label4);
            this.nGrouper2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nGrouper2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.nGrouper2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.nGrouper2.FillInfo.GradientAngle = 15F;
            this.nGrouper2.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
            this.nGrouper2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nGrouper2.FooterFillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.nGrouper2.FooterFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
            this.nGrouper2.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper2.FooterItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper2.FooterItem.Text = "Provide user name and password";
            this.nGrouper2.FooterStrokeInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.nGrouper2.HeaderFillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(132)))), ((int)(((byte)(248)))));
            this.nGrouper2.HeaderFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
            this.nGrouper2.HeaderFillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(233)))), ((int)(((byte)(248)))));
            this.nGrouper2.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGrouper2.HeaderItem.Image")));
            this.nGrouper2.HeaderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper2.HeaderItem.ImageSize = new Nevron.GraphicsCore.NSize(32, 32);
            this.nGrouper2.HeaderItem.ImageTextRelation = Nevron.UI.ImageTextRelation.TextBeforeImage;
            this.nGrouper2.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper2.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper2.HeaderItem.Text = "<font color=\'white\' Size=\'16\' style=\'bold\'><b>Login</b></font>";
            this.nGrouper2.HeaderItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nGrouper2.HeaderItem.TreatAsOneEntity = false;
            this.nGrouper2.HeaderStrokeInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.nGrouper2.Location = new System.Drawing.Point(0, 0);
            this.nGrouper2.Name = "nGrouper2";
            this.nGrouper2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
            this.nGrouper2.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.nGrouper2.ShadowInfo.Color = System.Drawing.Color.Transparent;
            this.nGrouper2.ShadowInfo.OffsetX = 0;
            this.nGrouper2.ShadowInfo.OffsetY = 0;
            this.nGrouper2.Size = new System.Drawing.Size(268, 215);
            this.nGrouper2.StrokeInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.nGrouper2.TabIndex = 1;
            this.nGrouper2.Text = "nGrouper1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(171, 155);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
            this.ui_nbtnCancel.Size = new System.Drawing.Size(62, 24);
            this.ui_nbtnCancel.TabIndex = 3;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            // 
            // ui_btnLogin
            // 
            this.ui_btnLogin.Location = new System.Drawing.Point(96, 155);
            this.ui_btnLogin.Name = "ui_btnLogin";
            this.ui_btnLogin.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
            this.ui_btnLogin.Size = new System.Drawing.Size(62, 24);
            this.ui_btnLogin.TabIndex = 2;
            this.ui_btnLogin.Text = "&Login";
            this.ui_btnLogin.UseVisualStyleBackColor = false;
            this.ui_btnLogin.Click += new System.EventHandler(this.ui_btnLogin_Click);
            // 
            // ui_ntxtPassword
            // 
            this.ui_ntxtPassword.Location = new System.Drawing.Point(102, 116);
            this.ui_ntxtPassword.Name = "ui_ntxtPassword";
            this.ui_ntxtPassword.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
            this.ui_ntxtPassword.PasswordChar = '*';
            this.ui_ntxtPassword.Size = new System.Drawing.Size(137, 20);
            this.ui_ntxtPassword.TabIndex = 1;
            this.ui_ntxtPassword.TextChanged += new System.EventHandler(this.ui_ntxtPassword_TextChanged);
            this.ui_ntxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ntxtPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_ntxtLoginId
            // 
            this.ui_ntxtLoginId.Location = new System.Drawing.Point(102, 80);
            this.ui_ntxtLoginId.Name = "ui_ntxtLoginId";
            this.ui_ntxtLoginId.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
            this.ui_ntxtLoginId.Size = new System.Drawing.Size(137, 20);
            this.ui_ntxtLoginId.TabIndex = 0;
            this.ui_ntxtLoginId.TextChanged += new System.EventHandler(this.ui_ntxtLoginId_TextChanged);
            this.ui_ntxtLoginId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ui_ntxtLoginId_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Login ID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmDataLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ui_nbtnCancel;
            this.ClientSize = new System.Drawing.Size(268, 215);
            this.Controls.Add(this.nGrouper2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDataLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmDataLogin_Load);
            this.Activated += new System.EventHandler(this.frmDataLogin_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper2)).EndInit();
            this.nGrouper2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGrouper nGrouper2;
        private Nevron.UI.WinForm.Controls.NButton ui_btnLogin;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPassword;
        private System.Windows.Forms.Label label3;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtLoginId;
        private System.Windows.Forms.Label label4;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;

    }
}