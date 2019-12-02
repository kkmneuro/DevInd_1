using System;
using PALSA.Properties;
using System.Windows.Forms;
using System.Reflection;

namespace PALSA.Frm
{
    public partial class FrmAboutUs : frmBase
    {
        public FrmAboutUs()
        {
            InitializeComponent();
            uctlAboutUS1.OnCloseAboutUs += uctlAboutUS1_OnCloseAboutUs;
            
                uctlAboutUS1.Logo = Resources.LTechLogo;
                uctlAboutUS1.ContactAddText = "LTECH INDIA SOFTWARE SYSTEMS PVT. LTD. " + Environment.NewLine
                                               + "C.P.-5, Anurag Plaza, IIIrd Floor, Sect-I, Ashiyana" + Environment.NewLine
                                               + "Lucknow-INDIA" + Environment.NewLine
                                               + "Call : +91-522-4080618" + Environment.NewLine
                                               + "FAX  : +91-522-4080618" + Environment.NewLine;
                //"Frazer House, 32-38 Leman Street," + Environment.NewLine
                //                          + "London E1 8EW" + Environment.NewLine
                //                          + "United Kingdom" + Environment.NewLine
                //                          + "Phone - +44 (0) 207 173 6131" + Environment.NewLine
                //                          + "Fax - +44 (0) 207 173 6001" + Environment.NewLine;
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