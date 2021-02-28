using NinjaTest.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideo();
    }

    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideo()
        {
            using (var context = new VideoContext())
            {
                var videos = context.Videos.Where(v => !v.IsProcessed).ToList();

                return videos;
            }
        }
    }
}
