namespace TWS.Frm
{
    partial class frmMarketWatchSave
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
            this.uctlSaveMarketWatch1 = new CommonLibrary.UserControls.uctlSaveMarketWatch();
            this.SuspendLayout();
            // 
            // uctlSaveMarketWatch1
            // 
            this.uctlSaveMarketWatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlSaveMarketWatch1.Location = new System.Drawing.Point(0, 0);
            this.uctlSaveMarketWatch1.Name = "uctlSaveMarketWatch1";
            this.uctlSaveMarketWatch1.Size = new System.Drawing.Size(266, 141);
            this.uctlSaveMarketWatch1.TabIndex = 0;
            this.uctlSaveMarketWatch1.Title = null;
            this.uctlSaveMarketWatch1.OnSaveClick += new System.Action(this.uctlSaveMarketWatch1_OnSaveClick);
            // 
            // frmMarketWatchSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 141);
            this.Controls.Add(this.uctlSaveMarketWatch1);
            this.MinimizeBox = false;
            this.Name = "frmMarketWatchSave";
            this.Text = "Save Market Watch";
            this.Title = "Save Market Watch";
            this.Load += new System.EventHandler(this.frmMarketWatchSave_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMarketWatchSave_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.uctlSaveMarketWatch uctlSaveMarketWatch1;

    }
}