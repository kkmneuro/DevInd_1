namespace BOADMIN_NEW.Forms
{
    partial class frmTradingGateway
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
            this.uctlGatewayMain1 = new BOADMIN_NEW.Uctl.uctlGatewayMain();
            this.SuspendLayout();
            // 
            // uctlGatewayMain1
            // 
            this.uctlGatewayMain1.AutoScroll = true;
            this.uctlGatewayMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlGatewayMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlGatewayMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlGatewayMain1.Name = "uctlGatewayMain1";
            this.uctlGatewayMain1.Size = new System.Drawing.Size(875, 349);
            this.uctlGatewayMain1.TabIndex = 0;
            // 
            // frmTradingGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 349);
            this.Controls.Add(this.uctlGatewayMain1);
            this.Name = "frmTradingGateway";
            this.Text = "Trading Gateway";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTradingGateway_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlGatewayMain uctlGatewayMain1;
    }
}