using System;
using TWS.Properties;
using System.Windows.Forms;
using System.Reflection;

namespace TWS.Frm
{
    public partial class FrmAboutUs : frmBase
    {
        public FrmAboutUs()
        {
            InitializeComponent();
            this.Icon = Cls.ClsGlobal.Icon;
            uctlAboutUS1.OnCloseAboutUs += uctlAboutUS1_OnCloseAboutUs;

            this.uctlAboutUS1.Logo = Cls.ClsGlobal.AboutImage;
            uctlAboutUS1.ContactAddText = Cls.ClsGlobal.ContactAddress;
            uctlAboutUS1.CopyrightText = Cls.ClsGlobal.Copyright;
            uctlAboutUS1.ProductNameText = Cls.ClsGlobal.ProductName;
           
        }

        private void uctlAboutUS1_OnCloseAboutUs(object arg1, EventArgs arg2)
        {
            Close();
        }

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            var version = GetApplicationVersionNumber();
            uctlAboutUS1.VersionText = string.Format("version {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private Version GetApplicationVersionNumber()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            return assembly.GetName().Version;
        }
    }
}