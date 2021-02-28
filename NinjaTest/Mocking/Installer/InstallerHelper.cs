using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader fileDownloader;
        private string setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            this.fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                fileDownloader.DownloadFile(
                    String.Format($"http://example.com/{customerName}/{installerName}"), 
                    setupDestinationFile);
                
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
