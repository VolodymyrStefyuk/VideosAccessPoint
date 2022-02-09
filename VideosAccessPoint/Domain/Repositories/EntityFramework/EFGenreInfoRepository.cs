using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Entities;
using VideosAccessPoint.Domain.Repositories.Abstract;

namespace VideosAccessPoint.Domain.Repositories.EntityFramework
{
    public class EFGenreInfoRepository : IGenreInfoRepository
    {
        private AppDbContext _context;
        public EFGenreInfoRepository(AppDbContext context)
        {
            _context = context;
        }
        public GenreInfo GetGenreInfoById(Guid id)
        {
            return _context.GenresInfo.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<GenreInfo> GetGenresInfo()
        {
            return _context.GenresInfo;
        }

        public void SaveGenreInfo(GenreInfo genreInfo)
        {
            if (genreInfo.Id == default)
                _context.Entry(genreInfo).State = EntityState.Added;
            else
                _context.Entry(genreInfo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
