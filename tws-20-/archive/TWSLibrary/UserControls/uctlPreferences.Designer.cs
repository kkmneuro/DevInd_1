namespace CommonLibrary.UserControls
{
    partial class UctlPreferences
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_nbtnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntbPreferences = new Nevron.UI.WinForm.Controls.NTabControl();
            this.ui_ntcPreferencesGeneral = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlPreferencesGeneral = new CommonLibrary.UserControls.UctlPreferencesGeneral();
            this.ui_ntcPreferencesOrder = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlPreferencesOrder = new CommonLibrary.UserControls.UctlPreferencesOrder();
            this.ui_ntcPreferencesAlert = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlPreferencesAlerts = new CommonLibrary.UserControls.UctlPreferencesAlerts();
            this.ui_ntcPreferencesWorkSpace = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlPreferencesPortfolio = new CommonLibrary.UserControls.uctlPreferencesPortfolio();
            this.ui_uctlPreferencesWorkSpace = new CommonLibrary.UserControls.uctlPreferencesWorkSpace();
            this.ui_ntcPreferencesHotKeysSettings = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlHotKeysSettings = new CommonLibrary.UserControls.UctlHotKeysSettings();
            this.ui_ntpForexPair = new Nevron.UI.WinForm.Controls.NTabPage();
            this.ui_uctlPreferencesForexPair = new CommonLibrary.UserControls.UctlPreferencesForexPair();
            this.nuiPanel1.SuspendLayout();
            this.ui_ntbPreferences.SuspendLayout();
            this.ui_ntcPreferencesGeneral.SuspendLayout();
            this.ui_ntcPreferencesOrder.SuspendLayout();
            this.ui_ntcPreferencesAlert.SuspendLayout();
            this.ui_ntcPreferencesWorkSpace.SuspendLayout();
            this.ui_ntcPreferencesHotKeysSettings.SuspendLayout();
            this.ui_ntpForexPair.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_nbtnApply);
            this.nuiPanel1.Controls.Add(this.ui_nbtnCancel);
            this.nuiPanel1.Controls.Add(this.ui_nbtnOK);
            this.nuiPanel1.Controls.Add(this.ui_ntbPreferences);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(510, 409);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // ui_nbtnApply
            // 
            this.ui_nbtnApply.Location = new System.Drawing.Point(422, 380);
            this.ui_nbtnApply.Name = "ui_nbtnApply";
            this.ui_nbtnApply.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnApply.TabIndex = 3;
            this.ui_nbtnApply.Text = "&Apply";
            this.ui_nbtnApply.UseVisualStyleBackColor = false;
            this.ui_nbtnApply.Click += new System.EventHandler(this.ui_nbtnApply_Click);
            // 
            // ui_nbtnCancel
            // 
            this.ui_nbtnCancel.Location = new System.Drawing.Point(341, 380);
            this.ui_nbtnCancel.Name = "ui_nbtnCancel";
            this.ui_nbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnCancel.TabIndex = 2;
            this.ui_nbtnCancel.Text = "&Cancel";
            this.ui_nbtnCancel.UseVisualStyleBackColor = false;
            this.ui_nbtnCancel.Click += new System.EventHandler(this.ui_nbtnCancel_Click);
            // 
            // ui_nbtnOK
            // 
            this.ui_nbtnOK.Location = new System.Drawing.Point(260, 380);
            this.ui_nbtnOK.Name = "ui_nbtnOK";
            this.ui_nbtnOK.Size = new System.Drawing.Size(75, 23);
            this.ui_nbtnOK.TabIndex = 1;
            this.ui_nbtnOK.Text = "&OK";
            this.ui_nbtnOK.UseVisualStyleBackColor = false;
            this.ui_nbtnOK.Click += new System.EventHandler(this.ui_nbtnOK_Click);
            // 
            // ui_ntbPreferences
            // 
            this.ui_ntbPreferences.Controls.Add(this.ui_ntcPreferencesGeneral);
            this.ui_ntbPreferences.Controls.Add(this.ui_ntcPreferencesOrder);
            this.ui_ntbPreferences.Controls.Add(this.ui_ntcPreferencesAlert);
            this.ui_ntbPreferences.Controls.Add(this.ui_ntcPreferencesWorkSpace);
            this.ui_ntbPreferences.Controls.Add(this.ui_ntcPreferencesHotKeysSettings);
            this.ui_ntbPreferences.Controls.Add(this.ui_ntpForexPair);
            this.ui_ntbPreferences.Dock = System.Windows.Forms.DockStyle.Top;
            this.ui_ntbPreferences.Location = new System.Drawing.Point(0, 0);
            this.ui_ntbPreferences.Name = "ui_ntbPreferences";
            this.ui_ntbPreferences.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.ui_ntbPreferences.Selectable = true;
            this.ui_ntbPreferences.SelectedIndex = 0;
            this.ui_ntbPreferences.Size = new System.Drawing.Size(508, 375);
            this.ui_ntbPreferences.TabIndex = 0;
            this.ui_ntbPreferences.SelectedTabChanged += new System.EventHandler(this.ui_ntbPreferences_SelectedTabChanged);
            // 
            // ui_ntcPreferencesGeneral
            // 
            this.ui_ntcPreferencesGeneral.Controls.Add(this.ui_uctlPreferencesGeneral);
            this.ui_ntcPreferencesGeneral.Location = new System.Drawing.Point(4, 29);
            this.ui_ntcPreferencesGeneral.Name = "ui_ntcPreferencesGeneral";
            this.ui_ntcPreferencesGeneral.Size = new System.Drawing.Size(500, 342);
            this.ui_ntcPreferencesGeneral.TabIndex = 0;
            this.ui_ntcPreferencesGeneral.Text = "&General";
            // 
            // ui_uctlPreferencesGeneral
            // 
            this.ui_uctlPreferencesGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPreferencesGeneral.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferencesGeneral.Name = "ui_uctlPreferencesGeneral";
            this.ui_uctlPreferencesGeneral.Size = new System.Drawing.Size(500, 342);
            this.ui_uctlPreferencesGeneral.TabIndex = 0;
            this.ui_uctlPreferencesGeneral.Title = "General";
            // 
            // ui_ntcPreferencesOrder
            // 
            this.ui_ntcPreferencesOrder.Controls.Add(this.ui_uctlPreferencesOrder);
            this.ui_ntcPreferencesOrder.Location = new System.Drawing.Point(4, 29);
            this.ui_ntcPreferencesOrder.Name = "ui_ntcPreferencesOrder";
            this.ui_ntcPreferencesOrder.Size = new System.Drawing.Size(500, 342);
            this.ui_ntcPreferencesOrder.TabIndex = 1;
            this.ui_ntcPreferencesOrder.Text = "&Order";
            // 
            // ui_uctlPreferencesOrder
            // 
            this.ui_uctlPreferencesOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPreferencesOrder.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferencesOrder.Name = "ui_uctlPreferencesOrder";
            this.ui_uctlPreferencesOrder.Size = new System.Drawing.Size(500, 342);
            this.ui_uctlPreferencesOrder.TabIndex = 0;
            this.ui_uctlPreferencesOrder.Title = "Order";
            // 
            // ui_ntcPreferencesAlert
            // 
            this.ui_ntcPreferencesAlert.Controls.Add(this.ui_uctlPreferencesAlerts);
            this.ui_ntcPreferencesAlert.Location = new System.Drawing.Point(4, 29);
            this.ui_ntcPreferencesAlert.Name = "ui_ntcPreferencesAlert";
            this.ui_ntcPreferencesAlert.Size = new System.Drawing.Size(500, 342);
            this.ui_ntcPreferencesAlert.TabIndex = 2;
            this.ui_ntcPreferencesAlert.Text = "A&lert";
            // 
            // ui_uctlPreferencesAlerts
            // 
            this.ui_uctlPreferencesAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPreferencesAlerts.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferencesAlerts.Name = "ui_uctlPreferencesAlerts";
            this.ui_uctlPreferencesAlerts.Size = new System.Drawing.Size(500, 342);
            this.ui_uctlPreferencesAlerts.TabIndex = 0;
            this.ui_uctlPreferencesAlerts.Title = "Alerts";
            // 
            // ui_ntcPreferencesWorkSpace
            // 
            this.ui_ntcPreferencesWorkSpace.Controls.Add(this.ui_uctlPreferencesPortfolio);
            this.ui_ntcPreferencesWorkSpace.Controls.Add(this.ui_uctlPreferencesWorkSpace);
            this.ui_ntcPreferencesWorkSpace.Location = new System.Drawing.Point(4, 29);
            this.ui_ntcPreferencesWorkSpace.Name = "ui_ntcPreferencesWorkSpace";
            this.ui_ntcPreferencesWorkSpace.Size = new System.Drawing.Size(500, 342);
            this.ui_ntcPreferencesWorkSpace.TabIndex = 3;
            this.ui_ntcPreferencesWorkSpace.Text = "&WorkSpace and Portfolio";
            // 
            // ui_uctlPreferencesPortfolio
            // 
            this.ui_uctlPreferencesPortfolio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ui_uctlPreferencesPortfolio.Location = new System.Drawing.Point(0, 173);
            this.ui_uctlPreferencesPortfolio.Name = "ui_uctlPreferencesPortfolio";
            this.ui_uctlPreferencesPortfolio.PortfolioList = null;
            this.ui_uctlPreferencesPortfolio.Size = new System.Drawing.Size(500, 169);
            this.ui_uctlPreferencesPortfolio.TabIndex = 0;
            this.ui_uctlPreferencesPortfolio.Title = "Portfolio";
            // 
            // ui_uctlPreferencesWorkSpace
            // 
            this.ui_uctlPreferencesWorkSpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.ui_uctlPreferencesWorkSpace.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferencesWorkSpace.Name = "ui_uctlPreferencesWorkSpace";
            this.ui_uctlPreferencesWorkSpace.Size = new System.Drawing.Size(500, 175);
            this.ui_uctlPreferencesWorkSpace.TabIndex = 0;
            this.ui_uctlPreferencesWorkSpace.Title = "WorkSpace";
            // 
            // ui_ntcPreferencesHotKeysSettings
            // 
            this.ui_ntcPreferencesHotKeysSettings.Controls.Add(this.ui_uctlHotKeysSettings);
            this.ui_ntcPreferencesHotKeysSettings.Location = new System.Drawing.Point(4, 29);
            this.ui_ntcPreferencesHotKeysSettings.Name = "ui_ntcPreferencesHotKeysSettings";
            this.ui_ntcPreferencesHotKeysSettings.Size = new System.Drawing.Size(500, 342);
            this.ui_ntcPreferencesHotKeysSettings.TabIndex = 5;
            this.ui_ntcPreferencesHotKeysSettings.Text = "&Hot Keys Settings";
            // 
            // ui_uctlHotKeysSettings
            // 
            this.ui_uctlHotKeysSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlHotKeysSettings.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlHotKeysSettings.Name = "ui_uctlHotKeysSettings";
            this.ui_uctlHotKeysSettings.Size = new System.Drawing.Size(500, 342);
            this.ui_uctlHotKeysSettings.TabIndex = 0;
            this.ui_uctlHotKeysSettings.Title = "  ";
            // 
            // ui_ntpForexPair
            // 
            this.ui_ntpForexPair.Controls.Add(this.ui_uctlPreferencesForexPair);
            this.ui_ntpForexPair.Location = new System.Drawing.Point(4, 29);
            this.ui_ntpForexPair.Name = "ui_ntpForexPair";
            this.ui_ntpForexPair.Size = new System.Drawing.Size(500, 342);
            this.ui_ntpForexPair.TabIndex = 6;
            this.ui_ntpForexPair.Text = "Forex Pair";
            // 
            // ui_uctlPreferencesForexPair
            // 
            this.ui_uctlPreferencesForexPair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlPreferencesForexPair.Location = new System.Drawing.Point(0, 0);
            this.ui_uctlPreferencesForexPair.Name = "ui_uctlPreferencesForexPair";
            this.ui_uctlPreferencesForexPair.Size = new System.Drawing.Size(500, 342);
            this.ui_uctlPreferencesForexPair.TabIndex = 0;
            // 
            // UctlPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "UctlPreferences";
            this.Size = new System.Drawing.Size(510, 409);
            this.Load += new System.EventHandler(this.uctlPreferences_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.ui_ntbPreferences.ResumeLayout(false);
            this.ui_ntcPreferencesGeneral.ResumeLayout(false);
            this.ui_ntcPreferencesOrder.ResumeLayout(false);
            this.ui_ntcPreferencesAlert.ResumeLayout(false);
            this.ui_ntcPreferencesWorkSpace.ResumeLayout(false);
            this.ui_ntcPreferencesHotKeysSettings.ResumeLayout(false);
            this.ui_ntpForexPair.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NTabControl ui_ntbPreferences;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntcPreferencesGeneral;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntcPreferencesOrder;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntcPreferencesWorkSpace;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnApply;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnCancel;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnOK;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntcPreferencesHotKeysSettings;
        private UctlHotKeysSettings ui_uctlHotKeysSettings;
        public uctlPreferencesWorkSpace ui_uctlPreferencesWorkSpace;
        public UctlPreferencesAlerts ui_uctlPreferencesAlerts;
        public UctlPreferencesGeneral ui_uctlPreferencesGeneral;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntcPreferencesAlert;
        public uctlPreferencesPortfolio ui_uctlPreferencesPortfolio;
        public UctlPreferencesOrder ui_uctlPreferencesOrder;
        private Nevron.UI.WinForm.Controls.NTabPage ui_ntpForexPair;
        public UctlPreferencesForexPair ui_uctlPreferencesForexPair;
    }
}
