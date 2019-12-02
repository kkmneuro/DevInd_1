namespace TWS.Frm
{
    partial class frmMarketWatchNew
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
            this.uctlMarketWatch1 = new CommonLibrary.UserControls.uctlMarketWatchNew();
            this.SuspendLayout();
            // 
            // uctlMarketWatch1
            // 
            this.uctlMarketWatch1.AlertTriggerColor = System.Drawing.Color.Blue;
            this.uctlMarketWatch1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctlMarketWatch1.CurrentPortfolioName = "";
            this.uctlMarketWatch1.CurrentProfileName = "";
            this.uctlMarketWatch1.DefaultFontSize = global::TWS.Properties.Settings.Default.DefaultFontSize;
            this.uctlMarketWatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMarketWatch1.DownTrendColor = System.Drawing.Color.Red;
            this.uctlMarketWatch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uctlMarketWatch1.Location = new System.Drawing.Point(0, 0);
            this.uctlMarketWatch1.Name = "uctlMarketWatch1";
            this.uctlMarketWatch1.Portfolios = null;
            this.uctlMarketWatch1.Profiles = null;
            this.uctlMarketWatch1.SavedWorkSpace = null;
            this.uctlMarketWatch1.Size = new System.Drawing.Size(1009, 312);
            this.uctlMarketWatch1.TabIndex = 0;
            this.uctlMarketWatch1.Title = "Market Watch";
            this.uctlMarketWatch1.UpTrendColor = System.Drawing.Color.Blue;
            this.uctlMarketWatch1.ViewColor = System.Drawing.Color.White;
            this.uctlMarketWatch1.OnScriptPortfolioApplyClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioApplyClick);
            this.uctlMarketWatch1.OnScriptPortfolioModifyClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioModifyClick);
            this.uctlMarketWatch1.OnScriptPortfolioRemoveClick += new System.Action<string>(this.uctlMarketWatch1_OnScriptPortfolioRemoveClick);
            this.uctlMarketWatch1.OnMarketWatchLoadClick += new System.Action<string>(this.uctlMarketWatch1_OnMarketWatchLoadClick);
            this.uctlMarketWatch1.OnMarketWatchRemoveClick += new System.Action<string>(this.uctlMarketWatch1_OnMarketWatchRemoveClick);
            this.uctlMarketWatch1.OnProfileSaveClick += new System.Action<object, string>(this.uctlMarketWatch1_OnProfileSaveClick);
            this.uctlMarketWatch1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlMarketWatch1_OnProfileRemoveClick);
            this.uctlMarketWatch1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlMarketWatch1_OnSetDefaultProfileClick);
            this.uctlMarketWatch1.OnUpDownTrendColorChanged += new System.Action<System.Drawing.Color, System.Drawing.Color, System.Drawing.Color>(this.uctlMarketWatch1_OnUpDownTrendColorChanged);
            this.uctlMarketWatch1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlMarketWatch1_OnGridMouseDown);
            this.uctlMarketWatch1.OnGridMouseClick += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlMarketWatch1_OnGridMouseClick);
            this.uctlMarketWatch1.OnGridDragEnter += new System.Action<object, System.Windows.Forms.DragEventArgs>(this.uctlMarketWatch1_OnGridDragEnter);
            this.uctlMarketWatch1.OnGridDragDrop += new System.Action<object, System.Windows.Forms.DragEventArgs>(this.uctlMarketWatch1_OnGridDragDrop);
            this.uctlMarketWatch1.OnGridKeyDown += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.uctlMarketWatch1_OnGridKeyDown);
            // 
            // frmMarketWatchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1009, 312);
            this.Controls.Add(this.uctlMarketWatch1);
            this.MaximumSize = new System.Drawing.Size(1600, 800);
            //this.MaximumSize = new System.Drawing.Size(1300, 800);
            this.MinimumSize = new System.Drawing.Size(922, 350);
            this.Name = "frmMarketWatchNew";
            this.Text = "Market Watch";
            this.Title = "Market Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketWatchNew_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketWatchNew_FormClosed);
            this.Load += new System.EventHandler(this.frmMarketWatchNew_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMarketWatch_KeyDown);
            this.Resize += new System.EventHandler(this.frmMarketWatchNew_Resize);
            this.ResumeLayout(false);

        }


        #endregion

        public CommonLibrary.UserControls.uctlMarketWatchNew uctlMarketWatch1;


    }
}