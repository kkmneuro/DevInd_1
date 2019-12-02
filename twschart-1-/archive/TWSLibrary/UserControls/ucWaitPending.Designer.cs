namespace GTS.Ctrl
{
    partial class ucWaitPending
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
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(137, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "Please Wait";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(42, 122);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(311, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "You can revoke your request by pressing \"Cancel order\" button";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(10, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(374, 27);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ucWaitPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label20);
            this.Name = "ucWaitPending";
            this.Size = new System.Drawing.Size(394, 254);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCancel;
    }
}
