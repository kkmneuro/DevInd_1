namespace TWS.Frm
{
    partial class frmParticipaintList
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
            this.uctlParticipantList1 = new CommonLibrary.UserControls.UctlParticipantList();
            this.SuspendLayout();
            // 
            // uctlParticipantList1
            // 
            this.uctlParticipantList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlParticipantList1.Location = new System.Drawing.Point(0, 0);
            this.uctlParticipantList1.Name = "uctlParticipantList1";
            this.uctlParticipantList1.Size = new System.Drawing.Size(289, 151);
            this.uctlParticipantList1.TabIndex = 0;
            this.uctlParticipantList1.Title = "Participant List";
            this.uctlParticipantList1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlParticipantList1_OnGridMouseDown);
            // 
            // frmParticipaintList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 151);
            this.Controls.Add(this.uctlParticipantList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmParticipaintList";
            this.Sizable = false;
            this.Text = "Participant List";
            this.Title = "Participant List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmParticipaintList_FormClosed);
            this.Load += new System.EventHandler(this.frmParticipaintList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonLibrary.UserControls.UctlParticipantList uctlParticipantList1;
    }
}