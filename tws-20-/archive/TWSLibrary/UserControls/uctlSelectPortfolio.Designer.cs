namespace CommonLibrary.UserControls
{
    partial class UctlSelectPortfolio
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
            this.ui_npnlSelectPortfolio = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_lblSelectProtfolioMessage = new System.Windows.Forms.Label();
            this.ui_nbtnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnModify = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nlbSelectPortfolio = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_npnlSelectPortfolio.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlSelectPortfolio
            // 
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_lblSelectProtfolioMessage);
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_nbtnRemove);
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_nbtnModify);
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_nbtnCancel);
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_nbtnApply);
            this.ui_npnlSelectPortfolio.Controls.Add(this.ui_nlbSelectPortfolio);
            this.ui_npnlSelectPortfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlSelectPortfolio.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlSelectPortfolio.Name = "ui_npnlSelectPortfolio";
            this.ui_npnlSelectPortfolio.Size = new System.Drawing.Size(275, 219);
            this.ui_npnlSelectPortfolio.TabIndex = 0;
            this.ui_npnlSelectPortfolio.Text = "nuiPanel1";
            // 
            // ui_lblSelectProtfolioMessage
            // 
            this.ui_lblSelectProtfolioMessage.AutoSize = true;
            this.ui_lblSelectProtfolioMessage.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSelectProtfolioMessage.Location = new System.Drawing.Point(5, 151);
            this.ui_lblSelectProtfolioMessage.Name = "ui_lblSelectProtfolioMessage";
            this.ui_lblSelectProtfolioMessage.Size = new System.Drawing.Size(180, 52);
            this.ui_lblSelectProtfolioMessage.TabIndex = 6;
            this.ui_lblSelectProtfolioMessage.Text = "Select a portfolio for Market Watch/\r\nTicker.A Portfolio can be modified by\r\nsele" +
                "cting from the list and clicking on\r\nModify button.";
            // 
            // ui_nbtnRemove
            // 
            this.ui_nbtnRemove.Enabled = false;
            this.ui_nbtnRemove.Location = new System.Drawing.Point(186, 107);
            this.ui_nbtnRemove.Name = "ui_nbtnRemove";
            this.ui_nbtnRemove.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnRemove.TabIndex = 4;
            this.ui_nbtnRemove.Text = "&Remove";
            this.ui_nbtnRemove.UseVisualStyleBackColor = false;
            this.ui_nbtnRemove.Click += new System.EventHandler(this.ui_nbtnRemove_Click);
            // 
            // ui_nbtnModify
            // 
            this.ui_nbtnModify.Enabled = false;
            this.ui_nbtnModify.Location = new System.Drawing.Point(186, 74);
            this.ui_nbtnModify.Name = "ui_nbtnModify";
            this.ui_nbtnModify.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnModify.TabIndex = 3;
            this.ui_nbtnModify.Text = "&Modify";
            this.ui_nbtnModify.UseVisualStyleBackColor = false;
            this.ui_nbtnModify.Click += new System.EventHandler(this.ui_nbtnModify_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(186, 41);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 2;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Enabled = false;
            this.ui_nbtnApply.Location = new System.Drawing.Point(186, 8);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnApply.TabIndex = 1;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // ui_nlbSelectPortfolio
            // 
            this.ui_nlbSelectPortfolio.ColumnOnLeft = false;
            this.ui_nlbSelectPortfolio.ItemHeight = 14;
            this.ui_nlbSelectPortfolio.Location = new System.Drawing.Point(5, 8);
            this.ui_nlbSelectPortfolio.Name = "ui_nlbSelectPortfolio";
            this.ui_nlbSelectPortfolio.Size = new System.Drawing.Size(170, 130);
            this.ui_nlbSelectPortfolio.TabIndex = 0;
            this.ui_nlbSelectPortfolio.TabStop = false;
            this.ui_nlbSelectPortfolio.SelectedIndexChanged += new System.EventHandler(this.ui_nlbSelectPortfolio_SelectedIndexChanged);
            this.ui_nlbSelectPortfolio.DoubleClick += new System.EventHandler(this.ui_nlbSelectPortfolio_DoubleClick);
            // 
            // uctlSelectPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlSelectPortfolio);
            this.Name = "UctlSelectPortfolio";
            this.Size = new System.Drawing.Size(275, 219);
            this.Load += new System.EventHandler(this.uctlSelectPortfolio_Load);
            this.ui_npnlSelectPortfolio.ResumeLayout(false);
            this.ui_npnlSelectPortfolio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlSelectPortfolio;
        private System.Windows.Forms.Label ui_lblSelectProtfolioMessage;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRemove;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnModify;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
        private Nevron.UI.WinForm.Controls.NListBox ui_nlbSelectPortfolio;
    }
}
