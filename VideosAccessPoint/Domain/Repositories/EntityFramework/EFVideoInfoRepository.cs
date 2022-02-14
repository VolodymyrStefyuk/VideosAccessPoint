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

        public IQueryable<VideoInfo> GetLast100Videos()
        {
            return _context.VideosInfo.Take(100);
        }

        public IQueryable<VideoInfo> GetLast100VideosByGenre(string genre)
        {
            return _context.VideosInfo.Where(x => x.Genre == genre).Take(100);
        }

        public VideoInfo GetVideoInfoById(Guid id)
        {
            return _context.VideosInfo.FirstOrDefault(x => x.Id == id);
        }

        public VideoInfo GetVideoInfoByTitle(string title)
        {
            return _context.VideosInfo.FirstOrDefault(x => x.Title == title);
        }

        public IQueryable<VideoInfo> GetVideosInfo()
        {
            return _context.VideosInfo;
        }

        public IQueryable<VideoInfo> GetVideosOverTime(DateTime startDate, DateTime endDate = default)
        {
            if (endDate == default) 
                endDate = DateTime.UtcNow;
            return _context.VideosInfo.Where(x => x.DateAdded > startDate && x.DateAdded < endDate);
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
