namespace PALSA.uctl
{
    partial class ctlNetPosition
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
            this.uctlNetPosition1 = new CommonLibrary.UserControls.UctlNetPosition();
            this.SuspendLayout();
            // 
            // uctlNetPosition1
            // 
            this.uctlNetPosition1.AccountNo = "---SELECT---";
            //this.uctlNetPosition1.AccountType = "---SELECT---";
            //this.uctlNetPosition1.ClientName = "---SELECT---";
            this.uctlNetPosition1.CurrentProfileName = null;
            this.uctlNetPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlNetPosition1.InstrumentList = " ";
            this.uctlNetPosition1.Location = new System.Drawing.Point(0, 0);
            this.uctlNetPosition1.Name = "uctlNetPosition1";
            //this.uctlNetPosition1.OminiID = "---SELECT---";
            //this.uctlNetPosition1.Product = "---SELECT---";
            this.uctlNetPosition1.Profiles = null;
            this.uctlNetPosition1.Size = new System.Drawing.Size(1204, 208);
            this.uctlNetPosition1.TabIndex = 0;
            this.uctlNetPosition1.Title = " ";
            //this.uctlNetPosition1.TradingCurrency = "---SELECT---";
            this.uctlNetPosition1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlNetPosition1_OnProfileRemoveClick);
            this.uctlNetPosition1.OnProfileSaveClick += new System.Action<object, string>(this.uctlNetPosition1_OnProfileSaveClick);
            this.uctlNetPosition1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlNetPosition1_OnSetDefaultProfileClick);
            this.uctlNetPosition1.OnAccountChanged += new System.Action(this.uctlNetPosition1_OnAccountChanged);
            this.uctlNetPosition1.OnApplyClick += new System.Action<string, string>(this.uctlNetPosition1_OnApplyClick);
            this.uctlNetPosition1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlNetPosition1_OnGridMouseDown);
            // 
            // ctlNetPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uctlNetPosition1);
            this.Name = "ctlNetPosition";
            this.Size = new System.Drawing.Size(1204, 208);
            this.Load += new System.EventHandler(this.ctlNetPosition_Load);
            this.ResumeLayout(false);

        }

     

        #endregion

        private CommonLibrary.UserControls.UctlNetPosition uctlNetPosition1;
    }
}
