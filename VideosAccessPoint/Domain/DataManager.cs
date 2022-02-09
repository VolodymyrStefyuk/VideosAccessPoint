using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Repositories.Abstract;

namespace VideosAccessPoint.Domain
{
    public class DataManager
    {
        public IVideoInfoRepository VideoInfo { get; set; }
        public IGenreInfoRepository GenreInfo { get; set; }

        public DataManager(IVideoInfoRepository videoInfo, IGenreInfoRepository genreInfo)
        {
            VideoInfo = videoInfo;
            GenreInfo = genreInfo;
        }
    }
}
