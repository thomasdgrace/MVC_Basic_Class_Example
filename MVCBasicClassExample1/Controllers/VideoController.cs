using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasicClassExample1.Models;

namespace MVCBasicClassExample1.Controllers
{
    public class VideoController:Controller
    {

        private readonly VideoDbContext _context;
        public VideoController(VideoDbContext Context)
        {
            _context = Context;
        }
        public ViewResult Index()
        {
            //var model = new Video { Id = 1, Title = "Shrek", Genre = "Animated" };
            var model = _context.Videos.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _context.Find<Video>(id);
            return View(model);
        }
    }
}
