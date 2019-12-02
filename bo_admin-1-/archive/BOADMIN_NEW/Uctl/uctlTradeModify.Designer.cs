namespace BOADMIN_NEW.Uctl
{
    partial class uctlTradeModify
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
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnModify = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_nbtnCancel);
            this.nuiPanel1.Controls.Add(this.ui_nbtnModify);
            this.nuiPanel1.Controls.Add(this.ui_ntxtPrice);
            this.nuiPanel1.Controls.Add(this.label6);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(190, 93);
            this.nuiPanel1.TabIndex = 1;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(17, 46);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(166, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnCancel.Location = new System.Drawing.Point(102, 63);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(81, 23);
            this.ui_nbtnCancel.TabIndex = 17;
            this.ui_nbtnCancel.Text = "Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnModify
            // 
            this.ui_nbtnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnModify.Location = new System.Drawing.Point(17, 63);
            this.ui_nbtnModify.Name = "ui_nbtnModify";
            this.ui_nbtnModify.Size = new System.Drawing.Size(81, 23);
            this.ui_nbtnModify.TabIndex = 16;
            this.ui_nbtnModify.Text = "Modify";
            this.ui_nbtnModify.UseVisualStyleBackColor = false;
            this.ui_nbtnModify.Click += new System.EventHandler(this.ui_nbtnModify_Click);
            // 
            // ui_ntxtPrice
            // 
            this.ui_ntxtPrice.Location = new System.Drawing.Point(57, 12);
            this.ui_ntxtPrice.Name = "ui_ntxtPrice";
            this.ui_ntxtPrice.Size = new System.Drawing.Size(126, 18);
            this.ui_ntxtPrice.TabIndex = 14;
            this.ui_ntxtPrice.Leave += new System.EventHandler(this.ui_ntxtPrice_Leave);
            this.ui_ntxtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtPrice_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Price :";
            // 
            // uctlTradeModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlTradeModify";
            this.Size = new System.Drawing.Size(190, 93);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnModify;
        private System.Windows.Forms.Label label6;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPrice;
    }
}
