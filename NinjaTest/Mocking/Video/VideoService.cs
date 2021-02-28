using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Mocking
{
    public class VideoService
    {
        private readonly IFileReader fileReader;
        private readonly IVideoRepository repository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            this.fileReader = fileReader ?? new FileReader();
            this.repository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);

            if (video == null)
            {
                return "Error parsing the video";
            }

            return video.Title;
        }

        public string GetUnprocessedVidoeCsv()
        {
            var videoIds = new List<int>();

            var videos = repository.GetUnprocessedVideo();
            foreach (var v in videos)
            {
                videoIds.Add(v.Id);
            }

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
