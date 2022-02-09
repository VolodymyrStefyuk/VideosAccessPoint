using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Entities;

namespace VideosAccessPoint.Domain.Repositories.Abstract
{
    public interface IVideoInfoRepository
    {
        IQueryable<VideoInfo> GetVideosInfo();
        VideoInfo GetVideoInfoById(Guid id);
        void SaveVideoInfo(VideoInfo videoInfo);
       
    }
}
