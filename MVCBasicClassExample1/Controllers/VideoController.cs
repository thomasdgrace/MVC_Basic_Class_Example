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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Video model)
        {
            if(ModelState.IsValid)
            {
                var video = new Video()
                {
                    Title = model.Title,
                    Genre = model.Genre
                };
                _context.Add(video);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = video.Id });
            }
            return View(model);
        }
    }
}
