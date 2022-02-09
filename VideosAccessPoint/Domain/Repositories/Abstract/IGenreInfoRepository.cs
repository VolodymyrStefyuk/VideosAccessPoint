using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain.Entities;

namespace VideosAccessPoint.Domain.Repositories.Abstract
{
    public interface IGenreInfoRepository
    {
        IQueryable<GenreInfo> GetGenresInfo();
        GenreInfo GetGenreInfoById(Guid id);
        void SaveGenreInfo(GenreInfo genreInfo);
    }
}
