using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Entities;

namespace VideosAccessPoint.Areas.RegisteredUser.Views.VideoGenreViewModel
{
    public class VideoGenreViewModel
    {

        public VideoGenreViewModel()
        {
            Take100 = true;
            DateEnd = DateTime.UtcNow;
        }
        public List<VideoInfo>? Videos { get; set; }
        public SelectList? Genres { get; set; }
        public string? VideoGenre { get; set; }
        public string? SearchString { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Author { get; set; }

        public bool? Take100 { get; set; }
    }
}
