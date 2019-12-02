namespace PALSA.Frm
{
  partial class frmSymbol
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSymbol));
        this.cmdCancel = new Nevron.UI.WinForm.Controls.NButton();
        this.cmdOK = new Nevron.UI.WinForm.Controls.NButton();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
        this.SuspendLayout();
        // 
        // cmdCancel
        // 
        this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdCancel.Location = new System.Drawing.Point(94, 51);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(63, 23);
        this.cmdCancel.TabIndex = 7;
        this.cmdCancel.Text = "&Cancel";
        this.cmdCancel.UseVisualStyleBackColor = false;
        this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
        // 
        // cmdOK
        // 
        this.cmdOK.Location = new System.Drawing.Point(19, 51);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(63, 23);
        this.cmdOK.TabIndex = 6;
        this.cmdOK.Text = "&OK";
        this.cmdOK.UseVisualStyleBackColor = false;
        this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.ForeColor = System.Drawing.Color.Black;
        this.Label1.Location = new System.Drawing.Point(18, 19);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(41, 13);
        this.Label1.TabIndex = 8;
        this.Label1.Text = "Symbol";
        // 
        // txtSymbol
        // 
        this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        this.txtSymbol.Location = new System.Drawing.Point(66, 16);
        this.txtSymbol.Name = "txtSymbol";
        this.txtSymbol.Palette.Border = System.Drawing.SystemColors.ControlDark;
        this.txtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
        this.txtSymbol.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
        this.txtSymbol.Size = new System.Drawing.Size(91, 18);
        this.txtSymbol.TabIndex = 5;
        // 
        // frmSymbol
        // 
        this.AcceptButton = this.cmdOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.cmdCancel;
        this.ClientSize = new System.Drawing.Size(150, 73);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.txtSymbol);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(177, 121);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(177, 121);
        this.Name = "frmSymbol";
        this.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
        this.Load += new System.EventHandler(this.frmSymbol_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    internal Nevron.UI.WinForm.Controls.NButton cmdCancel;
    internal Nevron.UI.WinForm.Controls.NButton cmdOK;
    internal System.Windows.Forms.Label Label1;
    internal Nevron.UI.WinForm.Controls.NTextBox txtSymbol;

  }
}