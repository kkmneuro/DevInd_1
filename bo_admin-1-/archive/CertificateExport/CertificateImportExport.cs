using System;

using System.Security.Cryptography.X509Certificates;

namespace CertificateImportExport
{
    public class CertificateImport
    {
        //Code for Importing certificates
        public void ImportCertificates()
        {
            X509Store objX509StorePrivateKey = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Store objX509Store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);

            objX509StorePrivateKey.Open(OpenFlags.ReadWrite);
            objX509Store.Open(OpenFlags.ReadWrite);

            X509Certificate2Collection objX509C2Collection = new X509Certificate2Collection();
            objX509C2Collection = objX509StorePrivateKey.Certificates.Find(X509FindType.FindBySubjectName, "ServerSide", false);
            if(objX509C2Collection.Count==0)
            {
                X509Certificate2 objX509Certificate2Cert1 = new X509Certificate2(@"Certificates\ClientSide.pfx", "admin");
                X509Certificate2 objX509Certificate2Cert2 = new X509Certificate2(@"Certificates\ServerSide.pfx", "admin");
                objX509C2Collection.Add(objX509Certificate2Cert1);
                objX509C2Collection.Add(objX509Certificate2Cert2);
                objX509StorePrivateKey.AddRange(objX509C2Collection);
            }

            objX509C2Collection.Clear();

            objX509C2Collection = objX509Store.Certificates.Find(X509FindType.FindBySubjectName, "ServerSide", false);
            if (objX509C2Collection.Count == 0)
            {
                X509Certificate2 objX509Certificate2Cert3 = new X509Certificate2(@"Certificates\ClientSide.cer");
                X509Certificate2 objX509Certificate2Cert4 = new X509Certificate2(@"Certificates\ServerSide.cer");
                objX509C2Collection.Add(objX509Certificate2Cert3);
                objX509C2Collection.Add(objX509Certificate2Cert4);
                objX509Store.AddRange(objX509C2Collection);
            }
            // byte[] encodedCert = objX509Certificate2.GetRawCertData();

            // objX509Store.Add(objX509Certificate2);

        }
    }

    public class CertificateImportExport
    {
        public void ExportCertificates()
        {
            X509Store objExportStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Store objImportStore = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);

            objExportStore.Open(OpenFlags.ReadOnly);
            objExportStore.Open(OpenFlags.ReadWrite);

            X509Certificate2 objCertificate1 =objExportStore.Certificates[1];
            byte[] encodedCert = objCertificate1.Export(X509ContentType.Pfx, "admin");

            X509Certificate2 objExport = new X509Certificate2(encodedCert);

            objImportStore.Add(objExport);

        }
    }
}
