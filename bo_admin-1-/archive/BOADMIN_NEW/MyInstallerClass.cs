using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Security.Cryptography.X509Certificates;


namespace BOADMIN_NEW
{
    [RunInstaller(true)]
    public partial class MyInstallerClass : Installer
    {
        public MyInstallerClass()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            string path = string.Empty;
            foreach (string k in savedState.Keys)
            {
                if (k == "TargetDir")
                {
                    path = savedState[k].ToString();
                }
            }
            ImportCertificates(path);
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            stateSaver.Add("TargetDir", Context.Parameters["DP_TargetDir"].ToString());
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

        public void ImportCertificates(string targetDir)
        {
            //MessageBox.Show(targetDir + @"\Certificates\ClientSide.pfx");
            X509Store objX509StorePrivateKey = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Store objX509Store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);

            objX509StorePrivateKey.Open(OpenFlags.ReadWrite);
            objX509Store.Open(OpenFlags.ReadWrite);

            X509Certificate2Collection objX509C2Collection = new X509Certificate2Collection();
            objX509C2Collection = objX509StorePrivateKey.Certificates.Find(X509FindType.FindBySubjectName, "ServerSide", false);
            if (objX509C2Collection.Count == 0)
            {
                X509Certificate2 objX509Certificate2Cert1 = new X509Certificate2(targetDir + @"Certificates\ClientSide.pfx", "admin");
                X509Certificate2 objX509Certificate2Cert2 = new X509Certificate2(targetDir + @"Certificates\ServerSide.pfx", "admin");
                objX509C2Collection.Add(objX509Certificate2Cert1);
                objX509C2Collection.Add(objX509Certificate2Cert2);
                objX509StorePrivateKey.AddRange(objX509C2Collection);
            }

            objX509C2Collection.Clear();

            objX509C2Collection = objX509Store.Certificates.Find(X509FindType.FindBySubjectName, "ServerSide", false);
            if (objX509C2Collection.Count == 0)
            {
                X509Certificate2 objX509Certificate2Cert3 = new X509Certificate2(targetDir + @"Certificates\ClientSide.cer");
                X509Certificate2 objX509Certificate2Cert4 = new X509Certificate2(targetDir + @"Certificates\ServerSide.cer");
                objX509C2Collection.Add(objX509Certificate2Cert3);
                objX509C2Collection.Add(objX509Certificate2Cert4);
                objX509Store.AddRange(objX509C2Collection);
            }

            // byte[] encodedCert = objX509Certificate2.GetRawCertData();

            // objX509Store.Add(objX509Certificate2);

        } 
    }
}
