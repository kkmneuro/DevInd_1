using System;
namespace TWS.Frm
{
    partial class frmMarketWatch
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
            this.uctlMarketWatch1 = new CommonLibrary.UserControls.UctlMarketWatch();
            this.SuspendLayout();
            // 
            // uctlMarketWatch1
            // 
            this.uctlMarketWatch1.AlertTriggerColor = System.Drawing.Color.Blue;
            this.uctlMarketWatch1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctlMarketWatch1.CurrentPortfolioName = "";
            this.uctlMarketWatch1.CurrentProfileName = "";
            this.uctlMarketWatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMarketWatch1.DownTrendColor = System.Drawing.Color.Red;
            this.uctlMarketWatch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.uctlMarketWatch1.Location = new System.Drawing.Point(0, 0);
            this.uctlMarketWatch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uctlMarketWatch1.Name = "uctlMarketWatch1";
            this.uctlMarketWatch1.Portfolios = null;
            this.uctlMarketWatch1.Profiles = null;
            this.uctlMarketWatch1.Size = new System.Drawing.Size(1009, 312);
            this.uctlMarketWatch1.TabIndex = 0;
            this.uctlMarketWatch1.Title = "Market Watch";
            this.uctlMarketWatch1.UpTrendColor = System.Drawing.Color.Blue;
            this.uctlMarketWatch1.ViewColor = System.Drawing.Color.White;
            this.uctlMarketWatch1.OnScriptPortfolioApplyClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioApplyClick);
            this.uctlMarketWatch1.OnScriptPortfolioModifyClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioModifyClick);
            this.uctlMarketWatch1.OnScriptPortfolioRemoveClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioRemoveClick);
            this.uctlMarketWatch1.OnProfileSaveClick += new System.Action<object, string>(this.uctlMarketWatch1_OnProfileSaveClick);
            this.uctlMarketWatch1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlMarketWatch1_OnProfileRemoveClick);
            this.uctlMarketWatch1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlMarketWatch1_OnSetDefaultProfileClick);
            this.uctlMarketWatch1.OnUpDownTrendColorChanged += new System.Action<System.Drawing.Color, System.Drawing.Color, System.Drawing.Color>(this.uctlMarketWatch1_OnUpDownTrendColorChanged);
            this.uctlMarketWatch1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlMarketWatch1_OnGridMouseDown);
            // 
            // frmMarketWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1009, 312);
            this.Controls.Add(this.uctlMarketWatch1);
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(922, 350);
            this.Name = "frmMarketWatch";
            this.Text = "Market Watch";
            this.Title = "Market Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketWatch_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketWatch_FormClosed);
            this.Load += new System.EventHandler(this.frmMarketWatch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMarketWatch_KeyDown);
            this.Resize += new System.EventHandler(this.frmMarketWatch_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public CommonLibrary.UserControls.UctlMarketWatch uctlMarketWatch1;



    }
}