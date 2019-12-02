namespace BOADMIN_NEW.Forms
{
    partial class frmOrders
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
            this.uctlOrderMain1 = new BOADMIN_NEW.Uctl.uctlOrderMain();
            this.SuspendLayout();
            // 
            // uctlOrderMain1
            // 
            this.uctlOrderMain1.AutoScroll = true;
            this.uctlOrderMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlOrderMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlOrderMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlOrderMain1.Name = "uctlOrderMain1";
            this.uctlOrderMain1.Size = new System.Drawing.Size(1008, 256);
            this.uctlOrderMain1.TabIndex = 0;
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 256);
            this.Controls.Add(this.uctlOrderMain1);
            this.Name = "frmOrders";
            this.Text = "Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrders_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlOrderMain uctlOrderMain1;
    }
}