namespace CommonLibrary.UserControls
{
    partial class UctlAboutUs
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
            this.tblpnl1 = new System.Windows.Forms.TableLayoutPanel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblContactAdd = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.tblpnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tblpnl1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(401, 277);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tblpnl1
            // 
            this.tblpnl1.BackColor = System.Drawing.Color.Transparent;
            this.tblpnl1.ColumnCount = 4;
            this.tblpnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.05521F));
            this.tblpnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.255639F));
            this.tblpnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.79755F));
            this.tblpnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblpnl1.Controls.Add(this.picBox, 0, 0);
            this.tblpnl1.Controls.Add(this.nLineControl1, 1, 0);
            this.tblpnl1.Controls.Add(this.nButton1, 3, 1);
            this.tblpnl1.Controls.Add(this.lblVersion, 0, 1);
            this.tblpnl1.Controls.Add(this.lblCopyright, 2, 1);
            this.tblpnl1.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tblpnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnl1.Location = new System.Drawing.Point(0, 0);
            this.tblpnl1.Name = "tblpnl1";
            this.tblpnl1.RowCount = 2;
            this.tblpnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            this.tblpnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tblpnl1.Size = new System.Drawing.Size(399, 275);
            this.tblpnl1.TabIndex = 0;
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(3, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(153, 218);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // nLineControl1
            // 
            this.nLineControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nLineControl1.Location = new System.Drawing.Point(162, 8);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tblpnl1.SetRowSpan(this.nLineControl1, 2);
            this.nLineControl1.Size = new System.Drawing.Size(2, 259);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // nButton1
            // 
            this.nButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButton1.Location = new System.Drawing.Point(307, 237);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(63, 25);
            this.nButton1.TabIndex = 1;
            this.nButton1.Text = "Close";
            this.nButton1.UseVisualStyleBackColor = false;
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Location = new System.Drawing.Point(3, 227);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(3);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(153, 45);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyright.Location = new System.Drawing.Point(168, 227);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(3);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(107, 45);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tblpnl1.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblProductName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblContactAdd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNotice, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(168, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.18653F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.81347F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 218);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(3, 3);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(222, 19);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // lblContactAdd
            // 
            this.lblContactAdd.AutoSize = true;
            this.lblContactAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContactAdd.Location = new System.Drawing.Point(3, 28);
            this.lblContactAdd.Margin = new System.Windows.Forms.Padding(3);
            this.lblContactAdd.Name = "lblContactAdd";
            this.lblContactAdd.Size = new System.Drawing.Size(222, 87);
            this.lblContactAdd.TabIndex = 1;
            this.lblContactAdd.Text = "Contact Address";
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotice.Location = new System.Drawing.Point(3, 121);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(3);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(222, 94);
            this.lblNotice.TabIndex = 2;
            this.lblNotice.Text = "Notice";
            // 
            // UctlAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "UctlAboutUs";
            this.Size = new System.Drawing.Size(401, 277);
            this.nuiPanel1.ResumeLayout(false);
            this.tblpnl1.ResumeLayout(false);
            this.tblpnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tblpnl1;
        private System.Windows.Forms.PictureBox picBox;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton nButton1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblContactAdd;
        private System.Windows.Forms.Label lblNotice;
    }
}
