using Moq;
using NinjaTest.Mocking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService videoService;
        private Mock<IFileReader> fileReader;
        private Mock<IVideoRepository> repository;

        [SetUp]
        public void SetUp()
        {
            fileReader = new Mock<IFileReader>();
            repository = new Mock<IVideoRepository>(); 
            videoService = new VideoService(fileReader.Object, repository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            repository.Setup(r => r.GetUnprocessedVideo()).Returns(new List<Video>());

            var result = videoService.GetUnprocessedVidoeCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            repository.Setup(r => r.GetUnprocessedVideo()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            var result = videoService.GetUnprocessedVidoeCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
