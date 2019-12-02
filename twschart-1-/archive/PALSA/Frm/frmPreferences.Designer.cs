namespace PALSA.Frm
{
    partial class frmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.ui_uctlPreferences = new CommonLibrary.UserControls.UctlPreferences();
            this.SuspendLayout();
            // 
            // ui_uctlPreferences
            // 
            this.ui_uctlPreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPreferences.HotKeySettingsHashTable = null;
            this.ui_uctlPreferences.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferences.Name = "ui_uctlPreferences";
            this.ui_uctlPreferences.Size = new System.Drawing.Size(509, 412);
            this.ui_uctlPreferences.TabIndex = 0;
            this.ui_uctlPreferences.Title = "Preferences";
            this.ui_uctlPreferences.Load += new System.EventHandler(this.ui_uctlPreferences_Load);
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 412);
            this.Controls.Add(this.ui_uctlPreferences);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Title = "Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPreferences_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlPreferences ui_uctlPreferences;
    }
}