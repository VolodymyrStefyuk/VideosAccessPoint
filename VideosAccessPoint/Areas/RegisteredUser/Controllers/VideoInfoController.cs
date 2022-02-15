using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain;
using VideosAccessPoint.Domain.Entities;
using VideosAccessPoint.Services;

namespace VideosAccessPoint.Areas.RegisteredUser.Controllers
{
    [Area("RegisteredUser")]
    public class VideoInfoController : Controller
    {
        private readonly DataManager _dataManager;
        public VideoInfoController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Create(Guid id)
        {
            var entity = id == default ? new VideoInfo( User.Identity.Name) : _dataManager.VideoInfo.GetVideoInfoById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Create(VideoInfo model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.VideoInfo.SaveVideoInfo(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View(_dataManager.VideoInfo.GetVideosInfo());
        }

    }
}
