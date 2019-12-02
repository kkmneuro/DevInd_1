using System;
namespace PALSA.Frm
{
    partial class frmProductInfo
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
            this.uctlContractInformation1 = new CommonLibrary.UserControls.UctlContractInformation();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // uctlContractInformation1
            // 
            this.uctlContractInformation1.ExpiryDate = "";
            this.uctlContractInformation1.Location = new System.Drawing.Point(0, 0);
            this.uctlContractInformation1.Name = "uctlContractInformation1";
            this.uctlContractInformation1.ProductType = "";
            this.uctlContractInformation1.SelectedInstrumentId = null;
            this.uctlContractInformation1.Size = new System.Drawing.Size(483, 429);
            this.uctlContractInformation1.Symbol = "";
            this.uctlContractInformation1.TabIndex = 0;
            this.uctlContractInformation1.Title = "Contract Information";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 432);
            this.Controls.Add(this.uctlContractInformation1);
            this.KeyPreview = true;
            this.Name = "frmProductInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductInfo";
            this.Title = "frmProductInfo";
            this.Load += new System.EventHandler(this.frmProductInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductInfo_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlContractInformation uctlContractInformation1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}