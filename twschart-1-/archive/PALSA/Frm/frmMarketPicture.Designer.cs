namespace PALSA.Frm
{
    partial class frmMarketPicture
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
            this.uctlMarketPicture1 = new CommonLibrary.UserControls.UctlMarketPicture();
            this.SuspendLayout();
            // 
            // uctlMarketPicture1
            // 
            this.uctlMarketPicture1.ATP = "00.00";
            this.uctlMarketPicture1.ChangePercentage = "00.00";
            this.uctlMarketPicture1.Close = "00.00";
            this.uctlMarketPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlMarketPicture1.DPR = "00.00";
            this.uctlMarketPicture1.High = "00.00";
            this.uctlMarketPicture1.LeftNumericValue = "0";
            this.uctlMarketPicture1.LifeTimeHigh = "00.00";
            this.uctlMarketPicture1.LifeTimeLow = "00.00";
            this.uctlMarketPicture1.Location = new System.Drawing.Point(0, 0);
            this.uctlMarketPicture1.Low = "00.00";
            this.uctlMarketPicture1.LTP = "00.00";
            this.uctlMarketPicture1.LTQ = "00";
            this.uctlMarketPicture1.LTT = "date&time";
            this.uctlMarketPicture1.LUT = "date&time";
            this.uctlMarketPicture1.Name = "uctlMarketPicture1";
            this.uctlMarketPicture1.OI = "00";
            this.uctlMarketPicture1.Open = "00.00";
            this.uctlMarketPicture1.RightNumericValue = "0";
            this.uctlMarketPicture1.Size = new System.Drawing.Size(757, 216);
            this.uctlMarketPicture1.TabIndex = 0;
            this.uctlMarketPicture1.Title = " Market Picture";
            this.uctlMarketPicture1.Value = "00.00";
            this.uctlMarketPicture1.Volume = "00";
            this.uctlMarketPicture1.OnProductTextChanged += new System.Action<string, string>(this.uctlMarketPicture1_OnProductTextChanged);
            this.uctlMarketPicture1.OnProductSelectedIndexChanged += new System.Action<string, string>(this.uctlMarketPicture1_OnProductSelectedIndexChanged);
            this.uctlMarketPicture1.OnExpiryDateSelectedIndexChanged += new System.Action<string, string, string>(this.uctlMarketPicture1_OnExpiryDateSelectedIndexChanged);
            this.uctlMarketPicture1.OnProductTypeSelectedIndexChanged += new System.Action<string>(this.uctlMarketPicture1_OnProductTypeSelectedIndexChanged);
            this.uctlMarketPicture1.Load += new System.EventHandler(this.uctlMarketPicture1_Load);
            // 
            // frmMarketPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 216);
            this.Controls.Add(this.uctlMarketPicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(763, 244);
            this.MinimumSize = new System.Drawing.Size(763, 244);
            this.Name = "frmMarketPicture";
            this.Text = "frmMarketPicture";
            this.Title = "frmMarketPicture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarketPicture_FormClosed);
            this.Load += new System.EventHandler(this.frmMarketPicture_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlMarketPicture uctlMarketPicture1;
    }
}