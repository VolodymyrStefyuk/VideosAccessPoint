using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Entities;
using VideosAccessPoint.Domain.Repositories.Abstract;

namespace VideosAccessPoint.Domain.Repositories.EntityFramework
{
    public class EFVideoInfoRepository : IVideoInfoRepository
    {
        private AppDbContext _context;

        public EFVideoInfoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public VideoInfo GetVideoInfoById(Guid id)
        {
            return _context.VideosInfo.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<VideoInfo> GetVideosInfo()
        {
            return _context.VideosInfo;
        }

        public void SaveVideoInfo(VideoInfo videoInfo)
        {
            if (videoInfo.Id == default)
                _context.Entry(videoInfo).State = EntityState.Added;
            else
                _context.Entry(videoInfo).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
