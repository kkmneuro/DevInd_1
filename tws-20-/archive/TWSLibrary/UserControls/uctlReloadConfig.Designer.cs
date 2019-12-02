namespace CommonLibrary.UserControls
{
    partial class uctlReloadConfig
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
            this.ui_npnlReloadConfig = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncmbConfig = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_nbtnReloadConfig = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_npnlReloadConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlReloadConfig
            // 
            this.ui_npnlReloadConfig.Controls.Add(this.ui_ncmbConfig);
            this.ui_npnlReloadConfig.Controls.Add(this.label1);
            this.ui_npnlReloadConfig.Controls.Add(this.ui_nbtnReloadConfig);
            this.ui_npnlReloadConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlReloadConfig.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(169)))), ((int)(((byte)(193)))));
            this.ui_npnlReloadConfig.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlReloadConfig.Name = "ui_npnlReloadConfig";
            this.ui_npnlReloadConfig.Size = new System.Drawing.Size(276, 150);
            this.ui_npnlReloadConfig.TabIndex = 0;
            this.ui_npnlReloadConfig.Text = "nuiPanel1";
            // 
            // ui_ncmbConfig
            // 
            this.ui_ncmbConfig.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("--SELECT CONFIG--", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Reload Markup", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Reload enabled groups", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbConfig.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbConfig.Location = new System.Drawing.Point(128, 41);
            this.ui_ncmbConfig.Name = "ui_ncmbConfig";
            this.ui_ncmbConfig.Size = new System.Drawing.Size(137, 22);
            this.ui_ncmbConfig.TabIndex = 2;
            this.ui_ncmbConfig.Text = "nComboBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Configuration :";
            // 
            // ui_nbtnReloadConfig
            // 
            this.ui_nbtnReloadConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ui_nbtnReloadConfig.Location = new System.Drawing.Point(75, 92);
            this.ui_nbtnReloadConfig.Name = "ui_nbtnReloadConfig";
            this.ui_nbtnReloadConfig.Size = new System.Drawing.Size(126, 27);
            this.ui_nbtnReloadConfig.TabIndex = 0;
            this.ui_nbtnReloadConfig.Text = "Reload Configuration";
            this.ui_nbtnReloadConfig.UseVisualStyleBackColor = false;
            this.ui_nbtnReloadConfig.Click += new System.EventHandler(this.ui_nbtnReloadConfig_Click);
            // 
            // uctlReloadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlReloadConfig);
            this.Name = "uctlReloadConfig";
            this.Size = new System.Drawing.Size(276, 150);
            this.Load += new System.EventHandler(this.uctlReloadConfig_Load);
            this.ui_npnlReloadConfig.ResumeLayout(false);
            this.ui_npnlReloadConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlReloadConfig;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbConfig;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnReloadConfig;
    }
}
