using Moq;
using NinjaTest.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper installerHelper;
        private Mock<IFileDownloader> fileDownloader;

        [SetUp]
        public void SetUp()
        {
            fileDownloader = new Mock<IFileDownloader>();
            installerHelper = new InstallerHelper(fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            var result = installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }

    }
}
