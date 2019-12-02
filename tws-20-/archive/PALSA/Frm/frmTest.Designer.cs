namespace PALSA.Frm
{
    partial class frmTest
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
            this.nDataGridView1 = new Nevron.UI.WinForm.Controls.NDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nDataGridView1
            // 
            this.nDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.nDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.nDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.nDataGridView1.Name = "nDataGridView1";
            this.nDataGridView1.Size = new System.Drawing.Size(284, 262);
            this.nDataGridView1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.nDataGridView1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView nDataGridView1;
    }
}