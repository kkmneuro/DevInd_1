namespace BOADMIN_NEW.Uctl
{
    partial class uctlAccounts
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_rdoSecurity = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_rdoTrades = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_rdoPersonal = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.ui_pnlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.pnlFooter = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlFooter);
            this.splitContainer1.Size = new System.Drawing.Size(800, 374);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ui_pnlContainer);
            this.splitContainer2.Size = new System.Drawing.Size(800, 336);
            this.splitContainer2.SplitterDistance = 133;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.ui_rdoSecurity);
            this.pnlLeft.Controls.Add(this.ui_rdoTrades);
            this.pnlLeft.Controls.Add(this.ui_rdoPersonal);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(133, 336);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Text = "nuiPanel3";
            // 
            // ui_rdoSecurity
            // 
            this.ui_rdoSecurity.Appearance = System.Windows.Forms.Appearance.Button;
            this.ui_rdoSecurity.ButtonProperties.BorderOffset = 2;
            this.ui_rdoSecurity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_rdoSecurity.Location = new System.Drawing.Point(7, 279);
            this.ui_rdoSecurity.Name = "ui_rdoSecurity";
            this.ui_rdoSecurity.Size = new System.Drawing.Size(118, 23);
            this.ui_rdoSecurity.TabIndex = 18;
            this.ui_rdoSecurity.Text = "Security";
            this.ui_rdoSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ui_rdoSecurity.CheckedChanged += new System.EventHandler(this.ui_rdoSecurity_CheckedChanged);
            // 
            // ui_rdoTrades
            // 
            this.ui_rdoTrades.Appearance = System.Windows.Forms.Appearance.Button;
            this.ui_rdoTrades.ButtonProperties.BorderOffset = 2;
            this.ui_rdoTrades.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_rdoTrades.Location = new System.Drawing.Point(7, 157);
            this.ui_rdoTrades.Name = "ui_rdoTrades";
            this.ui_rdoTrades.Size = new System.Drawing.Size(118, 23);
            this.ui_rdoTrades.TabIndex = 17;
            this.ui_rdoTrades.Text = "Trades";
            this.ui_rdoTrades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ui_rdoTrades.CheckedChanged += new System.EventHandler(this.ui_rdoTrades_CheckedChanged);
            // 
            // ui_rdoPersonal
            // 
            this.ui_rdoPersonal.Appearance = System.Windows.Forms.Appearance.Button;
            this.ui_rdoPersonal.ButtonProperties.BorderOffset = 2;
            this.ui_rdoPersonal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_rdoPersonal.Location = new System.Drawing.Point(7, 35);
            this.ui_rdoPersonal.Name = "ui_rdoPersonal";
            this.ui_rdoPersonal.Size = new System.Drawing.Size(118, 23);
            this.ui_rdoPersonal.TabIndex = 16;
            this.ui_rdoPersonal.Text = "Personal";
            this.ui_rdoPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ui_rdoPersonal.CheckedChanged += new System.EventHandler(this.ui_rdoPersonal_CheckedChanged);
            // 
            // ui_pnlContainer
            // 
            this.ui_pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_pnlContainer.Name = "ui_pnlContainer";
            this.ui_pnlContainer.Size = new System.Drawing.Size(663, 336);
            this.ui_pnlContainer.TabIndex = 0;
            this.ui_pnlContainer.Text = "nuiPanel2";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.ui_btnHelp);
            this.pnlFooter.Controls.Add(this.ui_btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(0, 0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 34);
            this.pnlFooter.TabIndex = 0;
            this.pnlFooter.Text = "nuiPanel1";
            // 
            // ui_btnHelp
            // 
            this.ui_btnHelp.Location = new System.Drawing.Point(683, 4);
            this.ui_btnHelp.Name = "ui_btnHelp";
            this.ui_btnHelp.Size = new System.Drawing.Size(75, 23);
            this.ui_btnHelp.TabIndex = 1;
            this.ui_btnHelp.Text = "Help";
            this.ui_btnHelp.UseVisualStyleBackColor = false;
            // 
            // ui_btnCancel
            // 
            this.ui_btnCancel.Location = new System.Drawing.Point(596, 4);
            this.ui_btnCancel.Name = "ui_btnCancel";
            this.ui_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_btnCancel.TabIndex = 0;
            this.ui_btnCancel.Text = "Cancel";
            this.ui_btnCancel.UseVisualStyleBackColor = false;
            this.ui_btnCancel.Click += new System.EventHandler(this.ui_btnCancel_Click);
            // 
            // uctlAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uctlAccounts";
            this.Size = new System.Drawing.Size(800, 374);
            this.Load += new System.EventHandler(this.uctlAccounts_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Nevron.UI.WinForm.Controls.NUIPanel pnlLeft;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_pnlContainer;
        private Nevron.UI.WinForm.Controls.NUIPanel pnlFooter;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_rdoTrades;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_rdoPersonal;
        private Nevron.UI.WinForm.Controls.NRadioButton ui_rdoSecurity;
        private Nevron.UI.WinForm.Controls.NButton ui_btnHelp;
        private Nevron.UI.WinForm.Controls.NButton ui_btnCancel;

    }
}
