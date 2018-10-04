using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CertMgr2
{
    class Program
    {
        static void Main(string[] args)
        {
            string certUrl = "http://sysnet.blob.core.windows.net/temp/stjeong.cer";
            string certFilePath = null;

            try
            {
                certFilePath = DownloadCertifcate(certUrl);

                InstallCertificate(StoreLocation.LocalMachine, StoreName.Root, certFilePath);
                InstallCertificate(StoreLocation.LocalMachine, StoreName.TrustedPublisher, certFilePath);

                Console.WriteLine("Installed: " + certUrl);
            }
            finally
            {
                if (File.Exists(certFilePath) == true)
                {
                    File.Decrypt(certFilePath);
                }
            }
        }

        private static string DownloadCertifcate(string certUrl)
        {
            string tempFilePath = Path.GetTempFileName();

            WebClient wc = new WebClient();
            wc.DownloadFile(certUrl, tempFilePath);

            return tempFilePath;
        }

        private static void InstallCertificate(StoreLocation storeLocation, StoreName storeName, string certFilePath)
        {
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadWrite);
            store.Add(new X509Certificate2(X509Certificate2.CreateFromCertFile(certFilePath)));
            store.Close();
        }
    }
}
