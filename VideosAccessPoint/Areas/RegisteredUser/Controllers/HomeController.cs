using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Areas.RegisteredUser.Views.VideoGenreViewModel;
using VideosAccessPoint.Domain;
using VideosAccessPoint.Domain.Entities;
using VideosAccessPoint.Models;
using VideosAccessPoint.Services;

namespace VideosAccessPoint.Areas.RegisteredUser.Controllers
{
    [Area("RegisteredUser")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly DataManager _dataManager;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string videoGenre, string searchString, string Author, DateTime DateStart, DateTime DateEnd, bool Take100)
        {
            IQueryable<string> genreQuery = from m in _context.VideosInfo
                                               orderby m.Genre
                                               select m.Genre;
            var videos = from v in _context.VideosInfo select v;
            if (!string.IsNullOrEmpty(searchString))
                videos = videos.Where(s => s.Title!.Contains(searchString));

            if (!string.IsNullOrEmpty(videoGenre))
                videos = videos.Where(x => x.Genre == videoGenre);

            if (!string.IsNullOrEmpty(Author))
                videos = videos.Where(x => x.UserName== Author);

            if (DateStart != default)
                videos = videos.Where(x => x.DateAdded > DateStart);

            if (DateEnd != default)
                videos = videos.Where(x => x.DateAdded < DateEnd);

            if (Take100 == true)
                videos = videos.Take(100);

            var videoGenreVM = new VideoGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Videos = await videos.ToListAsync()
            };
            return View(videoGenreVM);  
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new VideoInfo(User.Identity.Name) : _dataManager.VideoInfo.GetVideoInfoById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(VideoInfo model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.VideoInfo.SaveVideoInfo(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var video = await _context.VideosInfo.FirstOrDefaultAsync(v => v.Id == id);
            if (video == null)
                return NotFound();
            return View(video);
        }
    }
}
