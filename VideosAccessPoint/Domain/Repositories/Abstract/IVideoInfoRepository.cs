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

        IQueryable<VideoInfo> GetLast100Videos();
        IQueryable<VideoInfo> GetLast100VideosByGenre(string genre);

        IQueryable<VideoInfo> GetVideosOverTime(DateTime startDate, DateTime endDate = default);
        VideoInfo GetVideoInfoById(Guid id);
        VideoInfo GetVideoInfoByTitle(string name);
        void SaveVideoInfo(VideoInfo videoInfo);
    }
}
