namespace BOADMIN_NEW.Forms
{
    partial class frmHolidays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHolidays));
            this.uctlHolidaysMain1 = new BOADMIN_NEW.Uctl.uctlHolidaysMain();
            this.SuspendLayout();
            // 
            // uctlHolidaysMain1
            // 
            this.uctlHolidaysMain1.AutoScroll = true;
            this.uctlHolidaysMain1.BackColor = System.Drawing.SystemColors.Control;
            this.uctlHolidaysMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlHolidaysMain1.Location = new System.Drawing.Point(0, 0);
            this.uctlHolidaysMain1.Name = "uctlHolidaysMain1";
            this.uctlHolidaysMain1.Size = new System.Drawing.Size(721, 223);
            this.uctlHolidaysMain1.TabIndex = 0;
            // 
            // frmHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 223);
            this.Controls.Add(this.uctlHolidaysMain1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHolidays";
            this.Text = "Holidays";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHolidays_FormClosing);
            this.Load += new System.EventHandler(this.frmHolidays_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BOADMIN_NEW.Uctl.uctlHolidaysMain uctlHolidaysMain1;
    }
}