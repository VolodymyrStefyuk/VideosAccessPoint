using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideosAccessPoint.Domain;
using VideosAccessPoint.Domain.Entities;
using VideosAccessPoint.Models;
using VideosAccessPoint.Services;

namespace VideosAccessPoint.Areas.RegisteredUser.Controllers
{
    [Area("RegisteredUser")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public IActionResult Index()
        {
            return View(_dataManager.VideoInfo.GetVideosInfo());
        }

        
    }
}
