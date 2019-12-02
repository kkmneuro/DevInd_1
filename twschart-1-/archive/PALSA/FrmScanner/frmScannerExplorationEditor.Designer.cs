namespace PALSA.FrmScanner
{
    partial class frmScannerExplorationEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerExplorationEditor));
            this.grpBoxTitle = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new Nevron.UI.WinForm.Controls.NTextBox();
            this.txtName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.tcParent = new Nevron.UI.WinForm.Controls.NTabControl();
            this.tabA = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabB = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabC = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabD = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabE = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabF = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabG = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabH = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabI = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabJ = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabK = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabL = new Nevron.UI.WinForm.Controls.NTabPage();
            this.tabFilter = new Nevron.UI.WinForm.Controls.NTabPage();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnFunctions = new Nevron.UI.WinForm.Controls.NButton();
            this.btnSecurities = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOptions = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.txtDescriptionDeatil = new Nevron.UI.WinForm.Controls.NTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grpBoxTitle)).BeginInit();
            this.grpBoxTitle.SuspendLayout();
            this.tcParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxTitle
            // 
            this.grpBoxTitle.Controls.Add(this.lblName);
            this.grpBoxTitle.Controls.Add(this.lblNotes);
            this.grpBoxTitle.Controls.Add(this.txtNotes);
            this.grpBoxTitle.Controls.Add(this.txtName);
            this.grpBoxTitle.HeaderItem.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.grpBoxTitle.HeaderItem.Text = "General";
            this.grpBoxTitle.Location = new System.Drawing.Point(12, 12);
            this.grpBoxTitle.Name = "grpBoxTitle";
            this.grpBoxTitle.Size = new System.Drawing.Size(554, 166);
            this.grpBoxTitle.TabIndex = 0;
            this.grpBoxTitle.Text = "General";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(21, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(21, 64);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 5;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(72, 64);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(469, 86);
            this.txtNotes.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 18);
            this.txtName.TabIndex = 2;
            // 
            // tcParent
            // 
            this.tcParent.Controls.Add(this.tabA);
            this.tcParent.Controls.Add(this.tabB);
            this.tcParent.Controls.Add(this.tabC);
            this.tcParent.Controls.Add(this.tabD);
            this.tcParent.Controls.Add(this.tabE);
            this.tcParent.Controls.Add(this.tabF);
            this.tcParent.Controls.Add(this.tabG);
            this.tcParent.Controls.Add(this.tabH);
            this.tcParent.Controls.Add(this.tabI);
            this.tcParent.Controls.Add(this.tabJ);
            this.tcParent.Controls.Add(this.tabK);
            this.tcParent.Controls.Add(this.tabL);
            this.tcParent.Controls.Add(this.tabFilter);
            this.tcParent.Location = new System.Drawing.Point(12, 182);
            this.tcParent.Name = "tcParent";
            this.tcParent.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.tcParent.Selectable = true;
            this.tcParent.SelectedIndex = 0;
            this.tcParent.Size = new System.Drawing.Size(554, 177);
            this.tcParent.TabIndex = 1;
            this.tcParent.SelectedTabChanged += new System.EventHandler(this.tcParent_SelectedTabChanged);
            // 
            // tabA
            // 
            this.tabA.Location = new System.Drawing.Point(4, 29);
            this.tabA.Name = "tabA";
            this.tabA.Size = new System.Drawing.Size(546, 144);
            this.tabA.TabIndex = 1;
            this.tabA.Text = "A";
            // 
            // tabB
            // 
            this.tabB.Location = new System.Drawing.Point(4, 29);
            this.tabB.Name = "tabB";
            this.tabB.Size = new System.Drawing.Size(546, 144);
            this.tabB.TabIndex = 14;
            this.tabB.Text = "B";
            // 
            // tabC
            // 
            this.tabC.Location = new System.Drawing.Point(4, 29);
            this.tabC.Name = "tabC";
            this.tabC.Size = new System.Drawing.Size(546, 144);
            this.tabC.TabIndex = 3;
            this.tabC.Text = "C";
            // 
            // tabD
            // 
            this.tabD.Location = new System.Drawing.Point(4, 29);
            this.tabD.Name = "tabD";
            this.tabD.Size = new System.Drawing.Size(546, 144);
            this.tabD.TabIndex = 4;
            this.tabD.Text = "D";
            // 
            // tabE
            // 
            this.tabE.Location = new System.Drawing.Point(4, 29);
            this.tabE.Name = "tabE";
            this.tabE.Size = new System.Drawing.Size(546, 144);
            this.tabE.TabIndex = 5;
            this.tabE.Text = "E";
            // 
            // tabF
            // 
            this.tabF.Location = new System.Drawing.Point(4, 29);
            this.tabF.Name = "tabF";
            this.tabF.Size = new System.Drawing.Size(546, 144);
            this.tabF.TabIndex = 6;
            this.tabF.Text = "F";
            // 
            // tabG
            // 
            this.tabG.Location = new System.Drawing.Point(4, 29);
            this.tabG.Name = "tabG";
            this.tabG.Size = new System.Drawing.Size(546, 144);
            this.tabG.TabIndex = 7;
            this.tabG.Text = "G";
            // 
            // tabH
            // 
            this.tabH.Location = new System.Drawing.Point(4, 29);
            this.tabH.Name = "tabH";
            this.tabH.Size = new System.Drawing.Size(546, 144);
            this.tabH.TabIndex = 8;
            this.tabH.Text = "H";
            // 
            // tabI
            // 
            this.tabI.Location = new System.Drawing.Point(4, 29);
            this.tabI.Name = "tabI";
            this.tabI.Size = new System.Drawing.Size(546, 144);
            this.tabI.TabIndex = 9;
            this.tabI.Text = "I";
            // 
            // tabJ
            // 
            this.tabJ.Location = new System.Drawing.Point(4, 29);
            this.tabJ.Name = "tabJ";
            this.tabJ.Size = new System.Drawing.Size(546, 144);
            this.tabJ.TabIndex = 10;
            this.tabJ.Text = "J";
            // 
            // tabK
            // 
            this.tabK.Location = new System.Drawing.Point(4, 29);
            this.tabK.Name = "tabK";
            this.tabK.Size = new System.Drawing.Size(546, 144);
            this.tabK.TabIndex = 11;
            this.tabK.Text = "K";
            // 
            // tabL
            // 
            this.tabL.Location = new System.Drawing.Point(4, 29);
            this.tabL.Name = "tabL";
            this.tabL.Size = new System.Drawing.Size(546, 144);
            this.tabL.TabIndex = 12;
            this.tabL.Text = "L";
            // 
            // tabFilter
            // 
            this.tabFilter.Location = new System.Drawing.Point(4, 29);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Size = new System.Drawing.Size(546, 144);
            this.tabFilter.TabIndex = 13;
            this.tabFilter.Text = "Filter";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(13, 453);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(109, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFunctions
            // 
            this.btnFunctions.Location = new System.Drawing.Point(203, 453);
            this.btnFunctions.Name = "btnFunctions";
            this.btnFunctions.Size = new System.Drawing.Size(75, 23);
            this.btnFunctions.TabIndex = 4;
            this.btnFunctions.Text = "Functions...";
            this.btnFunctions.UseVisualStyleBackColor = false;
            this.btnFunctions.Click += new System.EventHandler(this.btnFunctions_Click);
            // 
            // btnSecurities
            // 
            this.btnSecurities.Location = new System.Drawing.Point(298, 453);
            this.btnSecurities.Name = "btnSecurities";
            this.btnSecurities.Size = new System.Drawing.Size(75, 23);
            this.btnSecurities.TabIndex = 5;
            this.btnSecurities.Text = "Securities...";
            this.btnSecurities.UseVisualStyleBackColor = false;
            this.btnSecurities.Click += new System.EventHandler(this.btnSecurities_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Enabled = false;
            this.btnOptions.Location = new System.Drawing.Point(398, 453);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = "Options...";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(492, 453);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // txtDescriptionDeatil
            // 
            this.txtDescriptionDeatil.Enabled = false;
            this.txtDescriptionDeatil.Location = new System.Drawing.Point(13, 365);
            this.txtDescriptionDeatil.Multiline = true;
            this.txtDescriptionDeatil.Name = "txtDescriptionDeatil";
            this.txtDescriptionDeatil.ReadOnly = true;
            this.txtDescriptionDeatil.Size = new System.Drawing.Size(554, 79);
            this.txtDescriptionDeatil.TabIndex = 3;
            // 
            // frmScannerExplorationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 488);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtDescriptionDeatil);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnSecurities);
            this.Controls.Add(this.btnFunctions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcParent);
            this.Controls.Add(this.grpBoxTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScannerExplorationEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exploration Editor";
            this.Load += new System.EventHandler(this.frmScannerExplorationEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpBoxTitle)).EndInit();
            this.grpBoxTitle.ResumeLayout(false);
            this.grpBoxTitle.PerformLayout();
            this.tcParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGroupBoxEx grpBoxTitle;
        private Nevron.UI.WinForm.Controls.NTabControl tcParent;
        private Nevron.UI.WinForm.Controls.NTabPage tabA;
   
        private Nevron.UI.WinForm.Controls.NTabPage tabC;
        private Nevron.UI.WinForm.Controls.NTabPage tabD;
        private Nevron.UI.WinForm.Controls.NTabPage tabE;
        private Nevron.UI.WinForm.Controls.NTabPage tabF;
        private Nevron.UI.WinForm.Controls.NTabPage tabG;
        private Nevron.UI.WinForm.Controls.NTabPage tabH;
        private Nevron.UI.WinForm.Controls.NTabPage tabI;
        private Nevron.UI.WinForm.Controls.NTabPage tabJ;
        private Nevron.UI.WinForm.Controls.NTabPage tabK;
        private Nevron.UI.WinForm.Controls.NTabPage tabL;
        private Nevron.UI.WinForm.Controls.NTabPage tabFilter;
        private Nevron.UI.WinForm.Controls.NTextBox txtName;
        private Nevron.UI.WinForm.Controls.NTextBox txtNotes;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnFunctions;
        private Nevron.UI.WinForm.Controls.NButton btnSecurities;
        private Nevron.UI.WinForm.Controls.NButton btnOptions;
        private Nevron.UI.WinForm.Controls.NButton btnHelp;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblName;
        private Nevron.UI.WinForm.Controls.NTextBox txtDescriptionDeatil;
        private Nevron.UI.WinForm.Controls.NTabPage tabB;


    }
}