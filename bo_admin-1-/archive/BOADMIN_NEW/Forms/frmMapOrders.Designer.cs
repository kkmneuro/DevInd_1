namespace BOADMIN_NEW.Forms
{
    partial class frmMapOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapOrders));
            this.uctlMapOrders1 = new BOADMIN_NEW.Uctl.uctlMapOrders();
            this.SuspendLayout();
            // 
            // uctlMapOrders1
            // 
            this.uctlMapOrders1.AutoSize = true;
            this.uctlMapOrders1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMapOrders1.Location = new System.Drawing.Point(0, 0);
            this.uctlMapOrders1.Name = "uctlMapOrders1";
            this.uctlMapOrders1.Size = new System.Drawing.Size(696, 269);
            this.uctlMapOrders1.TabIndex = 0;
            // 
            // frmMapOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 269);
            this.Controls.Add(this.uctlMapOrders1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapOrders";
            this.Text = "Map Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMapOrders_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlMapOrders uctlMapOrders1;
    }
}